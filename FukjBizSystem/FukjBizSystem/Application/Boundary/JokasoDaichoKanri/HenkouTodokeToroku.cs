using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.HenkouTodokeToroku;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KatashikiMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.ShoriHoshikiMstDataSetTableAdapters;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.JokasoDaichoKanri
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　habu　　    新規作成
    /// </history>
    public partial class HenkoTodokeToroku : FukjBaseForm
    {
        #region 定義(public)

        // NOTICE 変更、廃止届などは、別途画面を作成する
        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Add,        // 登録モード
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
            View,       // 参照のみ
        }
        #endregion

        #endregion

        #region プロパティ(public)

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// displayMode
        /// </summary>
        private DispMode _displayMode = DispMode.Add;
        /// <summary>
        /// 
        /// </summary>
        private DispMode _initDisplayMode = DispMode.Add;

        #region 画面起動引数
        /// <summary>
        /// hokenjoCd
        /// </summary>
        private string _hokenjoCd = string.Empty;

        /// <summary>
        /// torokuNendo
        /// </summary>
        private string _torokuNendo = string.Empty;

        /// <summary>
        /// renban
        /// </summary>
        private string _renban = string.Empty;
        #endregion

        #region 処理状態保持データ

        /// <summary>
        /// jokasoDaichoMstDT
        /// </summary>
        private JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable _jokasoDaichoMstDT = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();

        private DataTable _lockDataTable = new DataTable();

        /// <summary>
        /// コントロールデータマッピング
        /// </summary>
        private DataBindingHelper _inDataBind;
        /// <summary>
        /// コントロールデータマッピング
        /// </summary>
        private DataBindingHelper _outDataBind;

        FukjBizSystem.Control.ZTextBox _shoriHoshikiKbn = new Control.ZTextBox();
        FukjBizSystem.Control.ZTextBox _shoriHoshikiCd = new Control.ZTextBox();
        FukjBizSystem.Control.ZTextBox _shoriHoshikiShubetsu = new Control.ZTextBox();

        #endregion

        #endregion

        #region コンストラクタ

        ///// <summary>
        ///// 
        ///// </summary>
        //public HenkoTodokeToroku()
        //{
        //    InitializeComponent();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjoCd"></param>
        /// <param name="torokuNendo"></param>
        /// <param name="renban"></param>
        public HenkoTodokeToroku(string hokenjoCd, string torokuNendo, string renban)
        {
            this._hokenjoCd = hokenjoCd;
            this._torokuNendo = torokuNendo;
            this._renban = renban;

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjoCd"></param>
        /// <param name="torokuNendo"></param>
        /// <param name="renban"></param>
        /// <param name="initDispMode"></param>
        public HenkoTodokeToroku(string hokenjoCd, string torokuNendo, string renban, DispMode initDispMode)
        {
            this._hokenjoCd = hokenjoCd;
            this._torokuNendo = torokuNendo;
            this._renban = renban;
            this._initDisplayMode = initDispMode;

            InitializeComponent();
        }

        #endregion

        #region イベント

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HenkoTodokeToroku_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Set control domain
                SetControlDomain();

                // Set data mapping
                // DB -> Form
                _inDataBind = InitInDataMapping();
                // Form -> DB
                _outDataBind = InitOutDataMapping();

                // Set Std Control Event
                SetStdHandler();

                // NOTICE 変更届情報は保健所から受領する(紙の形式ではない模様)

                // 画面起動引数チェック
                {
                    if (_initDisplayMode != DispMode.View)
                    {
                        this._displayMode = DispMode.Edit;
                        this._initDisplayMode = this._displayMode;
                    }
                    // 参照モードの場合、例外的に扱う
                    else
                    {
                        this._displayMode = DispMode.View;
                        this._initDisplayMode = this._displayMode;
                    }

                    // 表示データ取得
                    GetControlData();

                    // 表示データ設定
                    SetControlData();
                }

                SetDisplayControl();

                // 届出タブを初期表示
                mainTabControl.SelectedTab = TodokedeShiyoshaTabPage;

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                CloseForm();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }

        #region closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    CloseForm();
                });
        }
        #endregion

        #region entryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 入力チェック
                    if (!DoValidate())
                    {
                        return;
                    }

                    this._displayMode = DispMode.Confirm;

                    SetDisplayControl();
                });
        }
        #endregion

        #region changeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (this._displayMode == DispMode.Edit)
                    {
                        // 入力チェック
                        if (!DoValidate())
                        {
                            return;
                        }

                        this._displayMode = DispMode.Confirm;
                    }
                    else if (this._displayMode == DispMode.Detail)
                    {
                        this._displayMode = DispMode.Edit;
                    }

                    SetDisplayControl();
                });
        }
        #endregion

        #region reInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reInputButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    this._displayMode = this._initDisplayMode;

                    SetDisplayControl();
                });
        }
        #endregion

        #region decisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decisionButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();

                    //insert data
                    if (_initDisplayMode == DispMode.Add)
                    {
                        // 登録モードは存在しない
                    }
                    else
                    {
                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable table = CreateEditUpdateData();

                        alInput.UpdateDataTable = table;
                        alInput.LockDataTable = this._lockDataTable;
                    }

                    IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                    if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                        return;
                    }

                    CloseForm();
                });
        }
        #endregion

        #endregion

        #region メソッド(privete)

        #region GetControlData
        /// <summary>
        /// 
        /// </summary>
        private void GetControlData()
        {
            IFormLoadALInput alInput = new FormLoadALInput();

            alInput.HokenjoCd = this._hokenjoCd;
            alInput.TorokuNendo = this._torokuNendo;
            alInput.Renban = this._renban;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            this._jokasoDaichoMstDT = alOutput.EditDataTable;
            this._lockDataTable = alOutput.LockTable;
        }
        #endregion

        #region SetControlData
        /// <summary>
        /// 
        /// </summary>
        private void SetControlData()
        {
            _inDataBind.FillToControl(_jokasoDaichoMstDT);

            // 20150119 habu 年度は西暦とする
            //// 登録年度を和暦に変換
            //torokuNendoTextBox.Text = Common.Common.ConvertToHoshouNendoWareki(torokuNendoTextBox.Text);
        }
        #endregion

        #region SetDisplayControl
        /// <summary>
        /// 
        /// </summary>
        private void SetDisplayControl()
        {
            #region db value controls

            bool disabled = true;
            bool keyContDisabled = true;

            // 編集不可モードの場合は、各コントロールを無効にする
            if (_displayMode == DispMode.Confirm || _displayMode == DispMode.Detail || _displayMode == DispMode.Edit)
            {
                keyContDisabled = true;
            }
            else if (_displayMode == DispMode.Add)
            {
                keyContDisabled = false;
            }
            if (_displayMode == DispMode.Confirm || _displayMode == DispMode.Detail)
            {
                disabled = true;
            }
            else if (_displayMode == DispMode.Add || _displayMode == DispMode.Edit)
            {
                disabled = false;
            }

            {
                hokenjoCdTextBox.ReadOnly = keyContDisabled;
                torokuNendoTextBox.ReadOnly = keyContDisabled;

                #region 届出設置者

                todokedeNmTextBox.ReadOnly = disabled;
                todokedeZipCdTextBox.ReadOnly = disabled;
                todokedeAdrTextBox.ReadOnly = disabled;
                todokedeTelNoTextBox.ReadOnly = disabled;
                todokedeZipKensakuButton.Enabled = !disabled;

                #endregion

            }

            // 常に無効の項目(マスタ名称など)
            disabled = true;
            {
                hokenjoJyuriNendoTextBox.ReadOnly = disabled;
                hokenjoJyuriRenbanTextBox.ReadOnly = disabled;

                houteiShishoComboBox.Enabled = !disabled;
                suishitsuShishoComboBox.Enabled = !disabled;

                #region Tab1(設置者・設置場所)

                setchishaNmTextBox.ReadOnly = disabled;
                setchishaKanaTextBox.ReadOnly = disabled;
                kensakuKanaTextBox.ReadOnly = disabled;
                setchishaZipCdTextBox.ReadOnly = disabled;
                setchishaAdrTextBox.ReadOnly = disabled;
                setchishaTelNoTextBox.ReadOnly = disabled;

                setchishaKbnComboBox.Enabled = !disabled;
                setchiKbnComboBox.Enabled = !disabled;

                shisetsuNmTextBox.ReadOnly = disabled;
                setchibashoZipCdTextBox.ReadOnly = disabled;
                setchibashoAdrTextBox.ReadOnly = disabled;
                setchibashoTelNoTextBox.ReadOnly = disabled;

                oldChikuCdTextBox.ReadOnly = disabled;
                nowChikuCdTextBox.ReadOnly = disabled;
                chikuwariComboBox.Enabled = !disabled;
                setchishaCdTextBox.ReadOnly = disabled;

                tatemonoYoto1ComboBox.Enabled = !disabled;
                tatemonoYoto2ComboBox.Enabled = !disabled;
                tatemonoYoto3ComboBox.Enabled = !disabled;
                tatemonoYoto4ComboBox.Enabled = !disabled;
                tatemonoYoto5ComboBox.Enabled = !disabled;

                nobeMensekiTextBox.ReadOnly = disabled;

                oldTatemonoYotoComboBox.Enabled = !disabled;

                #endregion

                #region Tab2(届出設置者・使用者)

                shiyoshaNmTextBox.ReadOnly = disabled;
                shiyoshaZipCdTextBox.ReadOnly = disabled;
                shiyoshaAdrTextBox.ReadOnly = disabled;
                shiyoshaTelNoTextBox.ReadOnly = disabled;

                #endregion

                #region Tab3(浄化槽情報)

                konkyoHoreiComboBox.Enabled = !disabled;

                chakkoNenTextBox.ReadOnly = disabled;
                chakkoTsukiTextBox.ReadOnly = disabled;
                chakkoBiTextBox.ReadOnly = disabled;

                shiyokaishiNenTextBox.ReadOnly = disabled;
                shiyokaishiTsukiTextBox.ReadOnly = disabled;
                shiyokaishiBiTextBox.ReadOnly = disabled;

                haishiNenTextBox.ReadOnly = disabled;
                haishiTsukiTextBox.ReadOnly = disabled;
                haishiBiTextBox.ReadOnly = disabled;

                makerCdTextBox.ReadOnly = disabled;
                katashikiTextBox.ReadOnly = disabled;
                shohinNmTextBox.ReadOnly = disabled;

                koujiKbnComboBox.Enabled = !disabled;
                //koujiKbnTextBox.ReadOnly = disabled;

                koujiNenTextBox.ReadOnly = disabled;
                koujiNoTextBox.ReadOnly = disabled;
                ninteiNoTextBox.ReadOnly = disabled;

                koujiGyoshaCdTextBox.ReadOnly = disabled;
                suishitsuKensakuKaisuTextBox.ReadOnly = disabled;

                shoriMokuhyoBodComboBox.Enabled = !disabled;

                shoriTaishoJininTextBox.ReadOnly = disabled;
                hiHeikinOsuiRyoTextBox.ReadOnly = disabled;
                JitsuSiyoJininTextBox.ReadOnly = disabled;
                jitsuSiyoJininSuchiTextBox.ReadOnly = disabled;
                jitsuHiHeikinOsuiRyoTextBox.ReadOnly = disabled;

                bodJyokyoTextBox.ReadOnly = disabled;
                bodHosuityuTextBox.ReadOnly = disabled;

                kasaageTakasaTextBox.ReadOnly = disabled;
                ryunyuTairyuTakasaTextBox.ReadOnly = disabled;
                houryuTairyuTakasaTextBox.ReadOnly = disabled;

                sanjishoriCheckBox.Enabled = !disabled;
                sanjishoriTypeTextBox.ReadOnly = disabled;
                gensuiCheckBox.Enabled = !disabled;
                horyuCheckBox.Enabled = !disabled;
                DisupozaCheckBox.Enabled = !disabled;

                #endregion

                #region Tab4(送付・請求先情報)

                soufusakiNmTextBox.ReadOnly = disabled;
                soufusakiTelNoTextBox.ReadOnly = disabled;
                soufusakiZipCdTextBox.ReadOnly = disabled;
                soufusakiAdrTextBox.ReadOnly = disabled;

                itkatsuSoufuGyoshaCdTextBox.ReadOnly = disabled;
                bettoSoufuGyoshaCd1TextBox.ReadOnly = disabled;
                bettoSoufuGyoshaCd2TextBox.ReadOnly = disabled;
                bettoSoufuGyoshaCd3TextBox.ReadOnly = disabled;

                seikyusakiNmTextBox.ReadOnly = disabled;
                seikyusakiTelNoTextBox.ReadOnly = disabled;
                seikyusakiZipCdTextBox.ReadOnly = disabled;
                seikyusakiAdrTextBox.ReadOnly = disabled;

                renrakusakiNmTextBox.ReadOnly = disabled;
                renrakusakiTelNoTextBox.ReadOnly = disabled;
                renrakusakiZipCdTextBox.ReadOnly = disabled;
                renrakusakiAdrTextBox.ReadOnly = disabled;

                hagakiKbnComboBox.Enabled = !disabled;
                hagakiSoufuComboBox.Enabled = !disabled;

                #endregion

                #region Tab5(業者情報)

                hoshuTenkenGyoshaCdTextBox.ReadOnly = disabled;
                hoshuYoteiGyoshaCdTextBox.ReadOnly = disabled;
                seisouGyoshaCdTextBox.ReadOnly = disabled;
                saisuiGyoshaCdTextBox.ReadOnly = disabled;
                mochikomiGyoshaCdTextBox.ReadOnly = disabled;
                seikyuGyoshaCdTextBox.ReadOnly = disabled;
                itkatsuSeikyuGyoshaCdTextBox.ReadOnly = disabled;

                #endregion

                #region Tab6(メモ)

                memo1TextBox.ReadOnly = disabled;
                memo2TextBox.ReadOnly = disabled;

                #endregion
                // 常に無効の項目(マスタ名称など)
                disabled = true;
                {
                    renbanTextBox.ReadOnly = disabled;

                    makerNmTextBox.ReadOnly = disabled;
                    shohinNmTextBox.ReadOnly = disabled;

                    shoriHoshikiShubetsuNmTextBox.ReadOnly = disabled;
                    shoriHoshikiNmTextBox.ReadOnly = disabled;

                    koujiGyoshaNmTextBox.ReadOnly = disabled;
                    hoshuTenkenGyoshaNmTextBox.ReadOnly = disabled;

                    oldTatemonoYotoComboBox.Enabled = !disabled;
                    setchishaCdTextBox.ReadOnly = disabled;
                }
                {
                    hoshuTenkenGyoshaNmTextBox.ReadOnly = disabled;
                    hoshuYoteiGyoshaNmTextBox.ReadOnly = disabled;
                    seisouGyoshaNmTextBox.ReadOnly = disabled;
                    saisuiGyoshaNmTextBox.ReadOnly = disabled;
                    mochikomiGyoshaNmTextBox.ReadOnly = disabled;
                    seikyuGyoshaNmTextBox.ReadOnly = disabled;
                    itkatsuSeikyuGyoshaNmTextBox.ReadOnly = disabled;
                }
            }

            #endregion

            #region command buttons

            entryButton.Visible = (this._displayMode == DispMode.Add) ? true : false;

            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            decisionButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            #endregion
        }
        #endregion

        #region CreateEditUpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private JokasoDaichoMstDataSet.JokasoDaichoMstDataTable CreateEditUpdateData()
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable table = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            // 読み込みデータをコピー
            new DataBindingHelper().CopyDataTable(table, _jokasoDaichoMstDT);

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBind.FillToDataRow(table, now, username, host, false);

            //// 登録年度を西暦に変換
            //foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in table)
            //{
            //    row.JokasoTorokuNendo = Common.Common.ConvertToHoshouNendoSeireki(row.JokasoTorokuNendo);
            //}

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetModified();
            }

            return table;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        protected void CloseForm()
        {
            Program.mForm.MovePrev();
        }

        #region DoValidate
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool DoValidate()
        {
            StringBuilder errMsgBuf = new StringBuilder();

            string errMsg = string.Empty;

            // 標準バリデーション実行

            #region Tab2(届出設置者・使用者)

            if (!todokedeNmTextBox.DoValidate(false, "届出設置者氏名", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!todokedeZipCdTextBox.DoValidate(false, "届出設置者郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!todokedeAdrTextBox.DoValidate(false, "届出設置者住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!todokedeTelNoTextBox.DoValidate(false, "届出設置者電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            if (errMsgBuf.Length > 0)
            {
                // メッセージ表示
                MessageForm.Show2(MessageForm.DispModeType.Warning, errMsgBuf.ToString());

                return false;
            }

            return true;
        }
        #endregion

        #region Form Difinition Methods

        #region SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        private void SetControlDomain()
        {
            hokenjoCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            torokuNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            renbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            hokenjoJyuriNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            hokenjoJyuriRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            #region Tab1(設置者・設置場所)

            setchishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            setchishaKanaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME_KANA_HALF, 60);
            kensakuKanaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME_KANA_HALF, 10);
            setchishaZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            setchishaAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            setchishaTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            shisetsuNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            setchibashoZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            setchibashoAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            setchibashoTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            oldChikuCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);
            nowChikuCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            setchishaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 7);

            #endregion

            #region Tab2(届出設置者・使用者)

            todokedeNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            todokedeZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            todokedeAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            todokedeTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            shiyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            shiyoshaZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            shiyoshaAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            shiyoshaTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            #endregion

            #region Tab3(浄化槽情報)

            // 現状、コンボボックスに対しては特にドメインを設定しない

            chakkoNenTextBox.SetControlDomain(ZControlDomain.ZT_NEN);
            chakkoTsukiTextBox.SetControlDomain(ZControlDomain.ZT_TSUKI);
            chakkoBiTextBox.SetControlDomain(ZControlDomain.ZT_BI);

            shiyokaishiNenTextBox.SetControlDomain(ZControlDomain.ZT_NEN);
            shiyokaishiTsukiTextBox.SetControlDomain(ZControlDomain.ZT_TSUKI);
            shiyokaishiBiTextBox.SetControlDomain(ZControlDomain.ZT_BI);

            haishiNenTextBox.SetControlDomain(ZControlDomain.ZT_NEN);
            haishiTsukiTextBox.SetControlDomain(ZControlDomain.ZT_TSUKI);
            haishiBiTextBox.SetControlDomain(ZControlDomain.ZT_BI);

            makerCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            katashikiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            shohinNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);

            // 20141228 habu 告示区分はコンボボックス選択とする
            //koujiKbnTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 1);

            koujiNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            koujiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);
            ninteiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_ALPHA_NUM, 15);

            koujiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            suishitsuKensakuKaisuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);

            shoriHoshikiShubetsuNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 14);
            shoriHoshikiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            shoriTaishoJininTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            hiHeikinOsuiRyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            JitsuSiyoJininTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);
            jitsuSiyoJininSuchiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);
            jitsuHiHeikinOsuiRyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);

            bodJyokyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            bodHosuityuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);

            kasaageTakasaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
            ryunyuTairyuTakasaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            houryuTairyuTakasaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);

            sanjishoriTypeTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            #endregion

            #region Tab4(送付・請求先情報)

            soufusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            soufusakiTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);
            soufusakiZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            soufusakiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            itkatsuSoufuGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            bettoSoufuGyoshaCd1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            bettoSoufuGyoshaCd2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            bettoSoufuGyoshaCd3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            seikyusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            seikyusakiTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);
            seikyusakiZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            seikyusakiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            renrakusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            renrakusakiTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);
            renrakusakiZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            renrakusakiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            #endregion

            #region Tab5(業者情報)

            hoshuTenkenGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            hoshuYoteiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            seisouGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            saisuiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            mochikomiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            seikyuGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            itkatsuSeikyuGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            #endregion

            #region Tab6(メモ)

            memo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            memo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);

            #endregion

            #region disp only

            makerNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            koujiGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            hoshuTenkenGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            hoshuYoteiGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            seisouGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            saisuiGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            mochikomiGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            seikyuGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            itkatsuSeikyuGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            #endregion

            #region コンボボックス設定

            // 根拠法令
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_029);
                Utility.Utility.SetComboBoxList(konkyoHoreiComboBox, table, "ConstNm", "ConstValue", false);
            }
            // はがき区分
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_020);
                Utility.Utility.SetComboBoxList(hagakiKbnComboBox, table, "ConstNm", "ConstValue", true);
            }
            // はがき送付先
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_018);
                Utility.Utility.SetComboBoxList(hagakiSoufuComboBox, table, "ConstNm", "ConstValue", true);
            }
            // 処理目標水質
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_070);
                Utility.Utility.SetComboBoxList(shoriMokuhyoBodComboBox, table, "ConstNm", "ConstValue", false);
            }
            // 市町村設置区分
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_030);
                Utility.Utility.SetComboBoxList(setchiKbnComboBox, table, "ConstNm", "ConstValue", true);
            }
            // 旧建築用途
            {
                DataTable table = MstUtility.NameMst.GetNameTable(Utility.Constants.NameKbnConstant.NAME_KBN_007, true);
                Utility.Utility.SetComboBoxList(oldTatemonoYotoComboBox, table, "Name", "NameCd", true);
            }
            // 告示区分
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_KOKUJIKBN);
                Utility.Utility.SetComboBoxList(koujiKbnComboBox, table, "ConstNm", "ConstValue", true);
            }

            // 地区割
            {
                IEnumerable<string> chikuwariList = AdrUtility.Chikuwari.GetChikuwariList(false);

                chikuwariComboBox.DataSource = chikuwariList;
            }

            // 支所
            {
                // 20150127 sou Start 取得する支所マスタを全件から事務局以外に変更
                //ShishoMstDataSet.ShishoMstDataTable table = MstUtility.ShishoMst.GetShishoMst();
                ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable table = MstUtility.ShishoMst.GetShishoMstExceptJimukyoku();
                // 20150127 sou End

                Utility.Utility.SetComboBoxList(houteiShishoComboBox, table, table.ShishoNmColumn.ColumnName, table.ShishoCdColumn.ColumnName, true);
                Utility.Utility.SetComboBoxList(suishitsuShishoComboBox, table, table.ShishoNmColumn.ColumnName, table.ShishoCdColumn.ColumnName, true);
            }

            // 建築用途1～5
            {
                KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable tempTable = MstUtility.KenchikuyotoMst.GetKenchikuyotoMstKensaku();

                const string colCd = "Cd";
                const string colNm = "Nm";

                const string valDelim = ":";

                DataTable table = new DataTable();
                table.Columns.Add(colCd, typeof(string));
                table.Columns.Add(colNm, typeof(string));

                // Valueはデリミタで連結した値を設定する(大分類(2),小分類(2),連番からなる)
                // 名称も連結して表示する
                foreach (KenchikuyotoMstDataSet.KenchikuyotoMstKensakuRow tempRow in tempTable)
                {
                    DataRow row = table.NewRow();
                    row[colCd] = string.Join(valDelim, new string[] { tempRow.KenchikuyotoDaibunrui, tempRow.KenchikuyotoShobunrui, tempRow.KenchikuyotoRenban.ToString() });
                    string dispNm = string.Format("{0}({1}){2}", tempRow.KenchikuyotoDaibunruiNm, tempRow.KenchikuyotoShobunruiNm, tempRow.KenchikuyotoNm);
                    row[colNm] = dispNm;

                    table.Rows.Add(row);
                }

                Utility.Utility.SetComboBoxList(tatemonoYoto1ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto2ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto3ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto4ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto5ComboBox, table, colNm, colCd, true);
            }

            #endregion
        }
        #endregion

        #region InitInDataMapping
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataBindingHelper InitInDataMapping()
        {
            DataBindingHelper bind = new DataBindingHelper();

            // template table(カラム情報は必要なので)
            JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable templateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();

            bind.AddControlBind(hokenjoCdTextBox, templateTable.JokasoHokenjoCdColumn);
            bind.AddControlBind(torokuNendoTextBox, templateTable.JokasoTorokuNendoColumn);
            bind.AddControlBind(renbanTextBox, templateTable.JokasoRenbanColumn);

            // 保健所受理番号保健所の設定は不要
            bind.AddControlBind(hokenjoJyuriNendoTextBox, templateTable.JokasoHokenjoJuriNoNendoColumn);
            bind.AddControlBind(hokenjoJyuriRenbanTextBox, templateTable.JokasoHokenjoJuriNoRenbanColumn);

            bind.AddControlBind(houteiShishoComboBox, templateTable.JokasoHoteiSishoCdColumn);
            bind.AddControlBind(suishitsuShishoComboBox, templateTable.JokasoSuisitsuSishoCdColumn);

            #region Tab1(設置者・設置場所)

            bind.AddControlBind(setchishaNmTextBox, templateTable.JokasoSetchishaNmColumn);
            bind.AddControlBind(setchishaKanaTextBox, templateTable.JokasoSetchishaKanaColumn);
            bind.AddControlBind(kensakuKanaTextBox, templateTable.JokasoKensakuKanaColumn);
            bind.AddControlBind(setchishaZipCdTextBox, templateTable.JokasoSetchishaZipCdColumn);
            bind.AddControlBind(setchishaAdrTextBox, templateTable.JokasoSetchishaAdrColumn);
            bind.AddControlBind(setchishaTelNoTextBox, templateTable.JokasoSetchishaTelNoColumn);

            bind.AddControlBind(setchishaKbnComboBox, templateTable.JokasoSetchishaKbnColumn);
            bind.AddControlBind(setchiKbnComboBox, templateTable.JokasoSichosonSetchiKbnColumn);

            bind.AddControlBind(shisetsuNmTextBox, templateTable.JokasoShisetsuNmColumn);
            bind.AddControlBind(setchibashoZipCdTextBox, templateTable.JokasoSetchiBashoZipCdColumn);
            bind.AddControlBind(setchibashoAdrTextBox, templateTable.JokasoSetchiBashoAdrColumn);
            bind.AddControlBind(setchibashoTelNoTextBox, templateTable.JokasoSetchiBashoTelNoColumn);

            bind.AddControlBind(oldChikuCdTextBox, templateTable.JokasoKyuChikuCdColumn);
            bind.AddControlBind(nowChikuCdTextBox, templateTable.JokasoGenChikuCdColumn);

            bind.AddControlBind(chikuwariComboBox, templateTable.JokasoGaikanTikuwariKbnColumn);
            bind.AddControlBind(setchishaCdTextBox, templateTable.JokasoSetchishaCdColumn);

            #endregion

            #region 建物用途

            bind.AddControlBind(tatemonoYoto1ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui1Column, templateTable.KenchikuyotoShobunrui1Column, templateTable.KenchikuyotoRenban1Column });
            bind.AddControlBind(tatemonoYoto2ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui2Column, templateTable.KenchikuyotoShobunrui2Column, templateTable.KenchikuyotoRenban2Column });
            bind.AddControlBind(tatemonoYoto3ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui3Column, templateTable.KenchikuyotoShobunrui3Column, templateTable.KenchikuyotoRenban3Column });
            bind.AddControlBind(tatemonoYoto4ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui4Column, templateTable.KenchikuyotoShobunrui4Column, templateTable.KenchikuyotoRenban4Column });
            bind.AddControlBind(tatemonoYoto5ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui5Column, templateTable.KenchikuyotoShobunrui5Column, templateTable.KenchikuyotoRenban5Column });

            bind.AddControlBind(nobeMensekiTextBox, templateTable.JokasoTatemonoNobeMensekiColumn);

            bind.AddControlBind(oldTatemonoYotoComboBox, templateTable.JokasoOldKentikuYoutoCdColumn);

            #endregion

            #region Tab2(届出設置者・使用者)

            bind.AddControlBind(todokedeNmTextBox, templateTable.JokasoTodokedeSetchishaNmColumn);
            bind.AddControlBind(todokedeZipCdTextBox, templateTable.JokasoTodokedeSetchishaZipCdColumn);
            bind.AddControlBind(todokedeAdrTextBox, templateTable.JokasoTodokedeSetchishaAdrColumn);
            bind.AddControlBind(todokedeTelNoTextBox, templateTable.JokasoTodokedeSetchishaTelNoColumn);

            bind.AddControlBind(shiyoshaNmTextBox, templateTable.JokasoShiyoshaNmColumn);
            bind.AddControlBind(shiyoshaZipCdTextBox, templateTable.JokasoShiyoshaZipCdColumn);
            bind.AddControlBind(shiyoshaAdrTextBox, templateTable.JokasoShiyoshaAdrColumn);
            bind.AddControlBind(shiyoshaTelNoTextBox, templateTable.JokasoShiyoshaTelNoColumn);

            #endregion

            #region Tab3(浄化槽情報)

            bind.AddControlBind(konkyoHoreiComboBox, templateTable.JokasoHouKonkyoKbnColumn);

            bind.AddControlBind(chakkoNenTextBox, templateTable.JokasoSetchiNenColumn);
            bind.AddControlBind(chakkoTsukiTextBox, templateTable.JokasoSetchiTsukiColumn);
            bind.AddControlBind(chakkoBiTextBox, templateTable.JokasoSetchiBiColumn);

            bind.AddControlBind(shiyokaishiNenTextBox, templateTable.JokasoSiyokaisiNenColumn);
            bind.AddControlBind(shiyokaishiTsukiTextBox, templateTable.JokasoSiyokaisiTsukiColumn);
            bind.AddControlBind(shiyokaishiBiTextBox, templateTable.JokasoSiyokaisiBiColumn);

            bind.AddControlBindDate(haishiNenTextBox, haishiTsukiTextBox, haishiBiTextBox, templateTable.JokasoHaishiBiColumn);

            bind.AddControlBind(makerCdTextBox, templateTable.JokasoMekaGyoshaCdColumn);
            bind.AddControlBind(katashikiTextBox, templateTable.JokasoKatashikiCdColumn);
            bind.AddControlBind(shohinNmTextBox, templateTable.JokasoShohinNmColumn);

            bind.AddControlBind(koujiKbnComboBox, templateTable.JokasoKoujiKbnColumn);
            //bind.AddControlBind(koujiKbnTextBox, templateTable.JokasoKoujiKbnColumn);

            bind.AddControlBind(koujiNenTextBox, templateTable.JokasoKoujiNenColumn);
            bind.AddControlBind(koujiNoTextBox, templateTable.JokasoKoujiNoColumn);
            bind.AddControlBind(ninteiNoTextBox, templateTable.JokasoNinteiNoColumn);

            bind.AddControlBind(koujiGyoshaCdTextBox, templateTable.JokasoKojiGyoshaKbnColumn);
            bind.AddControlBind(suishitsuKensakuKaisuTextBox, templateTable.JokasoSuisitsuKensaKaisuColumn);

            bind.AddControlBind(_shoriHoshikiKbn, templateTable.JokasoShoriHosikiKbnColumn);
            bind.AddControlBind(_shoriHoshikiCd, templateTable.JokasoShoriHosikiCdColumn);
            bind.AddControlBind(_shoriHoshikiShubetsu, templateTable.JokasoShoriHosikiShubetuColumn);

            // TODO 移行データBOD目標値は、定数マスタの設定値と、全て同じであること(定数マスタに設定済みの値のみ使用可能となるため)
            bind.AddControlBind(shoriMokuhyoBodComboBox, templateTable.JokasoSyoriMokuhyoBODColumn);

            bind.AddControlBind(shoriTaishoJininTextBox, templateTable.JokasoShoriTaishoJininColumn);
            bind.AddControlBind(hiHeikinOsuiRyoTextBox, templateTable.JokasoHiHeikinOsuiRyoColumn);
            bind.AddControlBind(JitsuSiyoJininTextBox, templateTable.JokasoJitsuSiyoJininColumn);
            bind.AddControlBind(jitsuSiyoJininSuchiTextBox, templateTable.JokasoJitsuSiyouJininSuchiColumn);
            bind.AddControlBind(jitsuHiHeikinOsuiRyoTextBox, templateTable.JokasoJitsuHiHeikinOsuiRyoColumn);

            bind.AddControlBind(bodJyokyoTextBox, templateTable.JokasoBODJyokyoRitsuColumn);
            bind.AddControlBind(bodHosuityuTextBox, templateTable.JokasoBODHoryuChuColumn);

            bind.AddControlBind(kasaageTakasaTextBox, templateTable.JokasoKasaageTakasaColumn);
            bind.AddControlBind(ryunyuTairyuTakasaTextBox, templateTable.JokasoRyunyuTairyuTakasaColumn);
            bind.AddControlBind(houryuTairyuTakasaTextBox, templateTable.JokasoHouryuTairyuTakasaColumn);

            bind.AddControlBind(sanjishoriCheckBox, templateTable.Jokaso3JiShoriFlgColumn);
            bind.AddControlBind(sanjishoriTypeTextBox, templateTable.Jokaso3JiShoriTypeColumn);
            bind.AddControlBind(gensuiCheckBox, templateTable.JokasoGensuiPonpuFlgColumn);
            bind.AddControlBind(horyuCheckBox, templateTable.JokasoHoryuPonpuFlgColumn);
            bind.AddControlBind(DisupozaCheckBox, templateTable.JokasoDisupozaFlgColumn);

            #endregion

            #region Tab4(送付・請求先情報)

            bind.AddControlBind(soufusakiNmTextBox, templateTable.JokasoSoufusakiNmColumn);
            bind.AddControlBind(soufusakiTelNoTextBox, templateTable.JokasoSoufusakiTelNoColumn);
            bind.AddControlBind(soufusakiZipCdTextBox, templateTable.JokasoSoufusakiZipCdColumn);
            bind.AddControlBind(soufusakiAdrTextBox, templateTable.JokasoSoufusakiAdrColumn);

            bind.AddControlBind(itkatsuSoufuGyoshaCdTextBox, templateTable.JokasoItkatsuSoufuGyoshaCdColumn);
            bind.AddControlBind(bettoSoufuGyoshaCd1TextBox, templateTable.JokasoBettoSoufuGyoshaCd1Column);
            bind.AddControlBind(bettoSoufuGyoshaCd2TextBox, templateTable.JokasoBettoSoufuGyoshaCd2Column);
            bind.AddControlBind(bettoSoufuGyoshaCd3TextBox, templateTable.JokasoBettoSoufuGyoshaCd3Column);

            bind.AddControlBind(seikyusakiNmTextBox, templateTable.JokasoSeikyusakiNmColumn);
            bind.AddControlBind(seikyusakiTelNoTextBox, templateTable.JokasoSeikyusakiTelNoColumn);
            bind.AddControlBind(seikyusakiZipCdTextBox, templateTable.JokasoSeikyusakiZipCdColumn);
            bind.AddControlBind(seikyusakiAdrTextBox, templateTable.JokasoSeikyusakiAdrColumn);

            bind.AddControlBind(renrakusakiNmTextBox, templateTable.JokasoRenrakusakiNmColumn);
            bind.AddControlBind(renrakusakiTelNoTextBox, templateTable.JokasoRenrakusakiTelNoColumn);
            bind.AddControlBind(renrakusakiZipCdTextBox, templateTable.JokasoRenrakusakiZipCdColumn);
            bind.AddControlBind(renrakusakiAdrTextBox, templateTable.JokasoRenrakusakiAdrColumn);

            bind.AddControlBind(hagakiKbnComboBox, templateTable.JokasoHagakiKbnColumn);
            bind.AddControlBind(hagakiSoufuComboBox, templateTable.JokasoHagakiSoufusakiKbnColumn);

            #endregion

            #region Tab5(業者情報)

            bind.AddControlBind(hoshuTenkenGyoshaCdTextBox, templateTable.JokasoHoshutenkenGyoshaCdColumn);
            bind.AddControlBind(hoshuYoteiGyoshaCdTextBox, templateTable.JokasoHoshuyoteiGyoshaCdColumn);
            bind.AddControlBind(seisouGyoshaCdTextBox, templateTable.JokasoSeisouGyoshaCdColumn);
            bind.AddControlBind(saisuiGyoshaCdTextBox, templateTable.JokasoSaisuiGyoshaCdColumn);
            bind.AddControlBind(mochikomiGyoshaCdTextBox, templateTable.JokasoMochikomiGyoshaCdColumn);
            bind.AddControlBind(seikyuGyoshaCdTextBox, templateTable.JokasoSeikyuGyoshaCdColumn);
            bind.AddControlBind(itkatsuSeikyuGyoshaCdTextBox, templateTable.JokasoItkatsuSeikyuGyoshaCdColumn);

            #endregion

            #region Tab6(メモ)

            bind.AddControlBind(memo1TextBox, templateTable.JokasoTegakiMemoColumn);
            bind.AddControlBind(memo2TextBox, templateTable.JokasoTegakiMemo2Column);

            #endregion

            #region disp only

            bind.AddControlBind(shoriHoshikiShubetsuNmTextBox, templateTable.ShoriHoshikiShubetsuNmColumn);
            bind.AddControlBind(shoriHoshikiNmTextBox, templateTable.ShoriHoshikiNmColumn);

            bind.AddControlBind(makerNmTextBox, templateTable.MekaGyoshaNmColumn);
            bind.AddControlBind(koujiGyoshaNmTextBox, templateTable.KojiGyoshaNmColumn);

            bind.AddControlBind(hoshuTenkenGyoshaNmTextBox, templateTable.HoshutenkenGyoshaNmColumn);
            bind.AddControlBind(hoshuYoteiGyoshaNmTextBox, templateTable.HoshuyoteiGyoshaNmColumn);
            bind.AddControlBind(seisouGyoshaNmTextBox, templateTable.SeisouGyoshaNmColumn);
            bind.AddControlBind(saisuiGyoshaNmTextBox, templateTable.SaisuiGyoshaNmColumn);
            bind.AddControlBind(mochikomiGyoshaNmTextBox, templateTable.MochikomiGyoshaNmColumn);
            bind.AddControlBind(seikyuGyoshaNmTextBox, templateTable.SeikyuGyoshaNmColumn);
            bind.AddControlBind(itkatsuSeikyuGyoshaNmTextBox, templateTable.ItkatsuSeikyuGyoshaNmColumn);

            #endregion

            return bind;
        }
        #endregion

        #region InitOutDataMapping
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataBindingHelper InitOutDataMapping()
        {
            DataBindingHelper bind = new DataBindingHelper();

            // TODO 不要な項目は削除する

            // template table(カラム情報は必要なので)
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable templateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            #region Tab2(届出設置者・使用者)

            bind.AddControlBind(todokedeNmTextBox, templateTable.JokasoTodokedeSetchishaNmColumn);
            bind.AddControlBind(todokedeZipCdTextBox, templateTable.JokasoTodokedeSetchishaZipCdColumn);
            bind.AddControlBind(todokedeAdrTextBox, templateTable.JokasoTodokedeSetchishaAdrColumn);
            bind.AddControlBind(todokedeTelNoTextBox, templateTable.JokasoTodokedeSetchishaTelNoColumn);

            #endregion

            return bind;
        }
        #endregion

        #region SetStdHandler
        /// <summary>
        /// 
        /// </summary>
        private void SetStdHandler()
        {
            Common.Common.SetStdButtonKey(this, Keys.F1, entryButton);
            Common.Common.SetStdButtonKey(this, Keys.F2, changeButton);
            Common.Common.SetStdButtonKey(this, Keys.F3, deleteButton);
            Common.Common.SetStdButtonKey(this, Keys.F4, reInputButton);
            Common.Common.SetStdButtonKey(this, Keys.F5, decisionButton);
            Common.Common.SetStdButtonKey(this, Keys.F12, closeButton);

            #region ZipCd

            AdrUtility.ZipCd.SetStdZipCdSearchButton(todokedeZipKensakuButton, todokedeZipCdTextBox, todokedeAdrTextBox);

            AdrUtility.ZipCd.SetStdZipCdChanged(todokedeZipCdTextBox, todokedeAdrTextBox);

            #endregion

        }
        #endregion

        private void sanjishoriCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

    }
}
