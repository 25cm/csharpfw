using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoKanri;
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
    /// 2014/08/28　habu　　    新規作成
    /// </history>
    public partial class JokasoDaichoShosai : FukjBaseForm
    {
        // TODO データ編集チェックを簡便に行う仕組みを用意する(Load時のデータと比較する)

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
            View,       // 参照のみ(履歴表示)
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

        private JokasoDaichoKanriDataSet.JokasoKensaRirekiDataTable _kensaRirekiDT = new JokasoDaichoKanriDataSet.JokasoKensaRirekiDataTable();

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

        /// <summary>
        /// 
        /// </summary>
        public JokasoDaichoShosai()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjoCd"></param>
        /// <param name="torokuNendo"></param>
        /// <param name="renban"></param>
        public JokasoDaichoShosai(string hokenjoCd, string torokuNendo, string renban)
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
        /// <param name="initDispMode">初期表示モード(履歴表示で遷移する場合は、Viewを指定する)</param>
        public JokasoDaichoShosai(string hokenjoCd, string torokuNendo, string renban, DispMode initDispMode)
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
        private void JokasoDaichoShosai_Load(object sender, EventArgs e)
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

                // 画面起動引数チェック
                if (string.IsNullOrEmpty(this._hokenjoCd)
                    || string.IsNullOrEmpty(this._torokuNendo)
                    || string.IsNullOrEmpty(this._renban))
                {
                    this._displayMode = DispMode.Add;
                    this._initDisplayMode = this._displayMode;

                    // 初期登録時は、システム日時を年度として初期設定する
                    DateTime sysDt = Common.Common.GetCurrentTimestamp();
                    string nendo = Utility.DateUtility.GetNendo(sysDt).ToString("00");

                    // 20150119 habu 年度を西暦とする
                    //nendo = Common.Common.ConvertToHoshouNendoWareki(nendo);

                    torokuNendoTextBox.Text = nendo;
                    hokenjoJyuriNendoTextBox.Text = nendo;

                    // 初期登録時は、告示区分は告示外を初期値とする
                    koujiKbnComboBox.SelectedValue = "1";
                }
                else
                {
                    if (_initDisplayMode != DispMode.View)
                    {
                        this._displayMode = DispMode.Detail;
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

                    // 参照モード(履歴表示時)は、履歴タブを初期選択する
                    if (_initDisplayMode == DispMode.View)
                    {
                        mainTabControl.SelectedTab = kensaRirekiTabPage;
                    }
                }

                SetDisplayControl();
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

        #region deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {

                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") == DialogResult.Yes)
                    {
                        IDeleteBtnCllickALInput input = new DeleteBtnCllickALInput();
                        input.HokenjoCd = _hokenjoCd;
                        input.TorokuNendo = _torokuNendo;
                        input.Renban = _renban;

                        IDeleteBtnCllickALOutput output = new DeleteBtnCllickApplicationLogic().Execute(input);

                        // Target data not exits(JokasoDaichoMst)
                        if (!string.IsNullOrEmpty(output.ErrMessage))
                        {
                            MessageForm.Show2(MessageForm.DispModeType.Error, output.ErrMessage);
                            return;
                        }

                        CloseForm();
                    }
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
                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable table = CreateEditInsertData();
                        DateTime sysDt = Common.Common.GetCurrentTimestamp();

                        // 保健所コードは必須入力されるものとする
                        string hokenjoCd = hokenjoCdTextBox.Text;
                        // 20150119 habu 年度は西暦表示とする
                        // 年度は必須入力されるものとする
                        string nendo = torokuNendoTextBox.Text;
                        //string nendo = Common.Common.ConvertToHoshouNendoSeireki(torokuNendoTextBox.Text);

                        string renban = Application.Utility.Saiban.GetSaibanRenban(nendo, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_JOKASO_DAICHO);

                        // 受理年度、受理年度は手入力されるものとする
                        // 20150119 habu 年度は西暦表示とする
                        // 受理年度は西暦に変換する
                        string jyuriNendo = hokenjoJyuriNendoTextBox.Text;
                        //string jyuriNendo = Common.Common.ConvertToHoshouNendoSeireki(hokenjoJyuriNendoTextBox.Text);
                        
                        //// 年度は必須入力されるものとする
                        //string juriNendo = Utility.DateUtility.GetNendo(sysDt).ToString();
                        //// 受理連番は(採番でなく)手入力とする
                        //string juriRenban = Application.Utility.Saiban.GetSaibanRenban(sysDt, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_HOKENJO_JURI_NO);

                        foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in table)
                        {
                            row.JokasoHokenjoCd = hokenjoCd;
                            row.JokasoTorokuNendo = nendo;
                            row.JokasoRenban = renban;

                            row.JokasoHokenjoJuriNoHokenCd = hokenjoCd;

                            // 浄化槽台帳新規登録時は、設置場所保健所コードを設定する
                            row.JokasoSetchiBashoHokenjoCd = hokenjoCd;

                            row.JokasoHokenjoJuriNoNendo = jyuriNendo;
                            // 受理年度、受理年度は手入力されるものとする
                            //row.JokasoHokenjoJuriNoNendo = juriNendo;
                            //row.JokasoHokenjoJuriNoRenban = juriRenban;
                        }

                        alInput.UpdateDataTable = table;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaKomokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 浄化槽台帳水質検査項目マスタへ遷移

                    JokasoDaichoSuishitsuKensaKomokuInfoForm frm = new JokasoDaichoSuishitsuKensaKomokuInfoForm(_hokenjoCd, _torokuNendo, _renban);

                    Program.mForm.MoveNext(frm);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kakkashoButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (kensaRirekiDataGridView.Rows.Count == 0)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                        return;
                    }

                    DataGridViewRow gridRow = kensaRirekiDataGridView.CurrentRow;

                    string hoteiKbn = TypeUtility.GetString(gridRow.Cells[kensaHoteiKbnDataGridViewTextBoxColumn.Index].Value);

                    string hokenjoCd = TypeUtility.GetString(gridRow.Cells[iraiCdDataGridViewTextBoxColumn.Index].Value);
                    string nendo = TypeUtility.GetString(gridRow.Cells[iraiNendoDataGridViewTextBoxColumn.Index].Value);
                    string renban = TypeUtility.GetString(gridRow.Cells[iraiRenbanDataGridViewTextBoxColumn.Index].Value);

                    // 外観検査の場合
                    if (!string.IsNullOrEmpty(hoteiKbn))
                    {
                        // 結果書出力を実行
                        int result = 0;
                        result = KekkashoUtility.KekkashoOutput(hoteiKbn, hokenjoCd, nendo, renban);

                        switch (result)
                        {
                            case 2:
                                MessageForm.Show2(MessageForm.DispModeType.Error, "対象のデータが見つかりません。");
                                break;
                            case 3:
                                MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                                break;
                            case 4:
                                MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが存在しません。システム管理者に連絡してください。");
                                break;
                            case 9:
                                MessageForm.Show2(MessageForm.DispModeType.Error, "結果書作成に失敗しました。システム管理者に連絡してください。");
                                break;
                            default:
                                break;
                        }
                    }
                    // 計量証明の場合
                    else
                    {
                        // TODO 計量証明の場合も結果書(濃度分析など)が必要か?
                        MessageForm.Show2(MessageForm.DispModeType.Error, "法定検査のデータを選択して下さい。");
                        return;
                    }
                });
        }

        #region sanjishoriCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sanjishoriCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sanjishoriCheckBox.Checked == true)
            {
                sanjishoriTypeTextBox.Enabled = true;
            }
            else
            {
                sanjishoriTypeTextBox.Text = string.Empty;
                sanjishoriTypeTextBox.Enabled = false;
            }
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
            this._kensaRirekiDT = alOutput.RirekiDataTable;
        }
        #endregion

        #region SetControlData
        /// <summary>
        /// 
        /// </summary>
        private void SetControlData()
        {
            _inDataBind.FillToControl(_jokasoDaichoMstDT);

            // 履歴表示
            jokasoDaichoDataSet.JokasoKensaRireki.Merge(_kensaRirekiDT);

            #region 履歴表示用データ作成
            foreach (DataGridViewRow gridRow in kensaRirekiDataGridView.Rows)
            {
                string kensaDateStr = (string)TypeUtility.GetConvertedValueForDB(gridRow.Cells[kensaDateDataGridViewTextBoxColumn.Index].Value, typeof(string));

                DateTime tDate;

                if (DateTime.TryParseExact(kensaDateStr, "yyyyMMdd", null, DateTimeStyles.NoCurrentDateDefault, out tDate))
                {
                    kensaDateStr = tDate.ToString("yyyy/MM/dd");
                }

                gridRow.Cells[KensaDateDisp.Name].Value = kensaDateStr;

                string kensaKbn = TypeUtility.GetString(gridRow.Cells[kensaKbnDataGridViewTextBoxColumn.Index].Value);

                string hoteiKbn = TypeUtility.GetString(gridRow.Cells[kensaHoteiKbnDataGridViewTextBoxColumn.Index].Value);

                string scrKbn = TypeUtility.GetString(gridRow.Cells[kensaIraiScreeningKbnDataGridViewTextBoxColumn.Index].Value);

                string hoteiKbnNm = string.Empty;
                string kensaNo = string.Empty;

                string hokenjoCd = TypeUtility.GetString(gridRow.Cells[iraiCdDataGridViewTextBoxColumn.Index].Value);
                string nendo = TypeUtility.GetString(gridRow.Cells[iraiNendoDataGridViewTextBoxColumn.Index].Value);
                string renban = TypeUtility.GetString(gridRow.Cells[iraiRenbanDataGridViewTextBoxColumn.Index].Value);

                // 検査種別名作成
                if (hoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN
                    || hoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN
                    || (hoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU && scrKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_NONE))
                {
                    hoteiKbnNm = TypeUtility.GetString(gridRow.Cells[kensaHoteiKbnNmDataGridViewTextBoxColumn.Index].Value);
                }
                else if (hoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU)
                {
                    hoteiKbnNm = TypeUtility.GetString(gridRow.Cells[kensaIraiScreeningKbnNmDataGridViewTextBoxColumn.Index].Value);
                }
                else
                {
                    hoteiKbnNm = TypeUtility.GetString(gridRow.Cells[kensaHoteiKbnNmDataGridViewTextBoxColumn.Index].Value);
                }

                // 検査番号組立
                if (!string.IsNullOrEmpty(hoteiKbn))
                {
                    kensaNo = Common.Common.CreateKensaIraiNoString(hokenjoCd, nendo, renban);
                }
                else
                {
                    kensaNo = Common.Common.CreateKeiryoShomeiNoString(hokenjoCd, nendo, renban);
                }

                gridRow.Cells[KensaShubetsuDisp.Name].Value = hoteiKbnNm;
                gridRow.Cells[KensaIraiNoDisp.Name].Value = kensaNo;
            }
            #endregion

            // 20150119 habu 年度を西暦とする
            //// 登録年度を和暦に変換
            //torokuNendoTextBox.Text = Common.Common.ConvertToHoshouNendoWareki(torokuNendoTextBox.Text);
            //hokenjoJyuriNendoTextBox.Text = Common.Common.ConvertToHoshouNendoWareki(hokenjoJyuriNendoTextBox.Text);

            // 新規登録時は、システム日付から、(画面初期表示として)年度を初期設定する
            if (_displayMode == DispMode.Add)
            {
                DateTime sysDate = Common.Common.GetCurrentTimestamp();

                int nendo = Utility.DateUtility.GetNendo(sysDate);

                if (string.IsNullOrEmpty(torokuNendoTextBox.Text))
                {
                    torokuNendoTextBox.Text = nendo.ToString();
                }
                if (string.IsNullOrEmpty(hokenjoJyuriNendoTextBox.Text))
                {
                    hokenjoJyuriNendoTextBox.Text = nendo.ToString();
                }
            }
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

                hokenjoJyuriNendoTextBox.ReadOnly = disabled;
                hokenjoJyuriRenbanTextBox.ReadOnly = disabled;

                houteiShishoComboBox.Enabled = !disabled;
                suishitsuShishoComboBox.Enabled = !disabled;

                #region Tab1(設置者・設置場所)

                setchishaNmTextBox.ReadOnly = disabled;
                setchishaKanaTextBox.ReadOnly = disabled;
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

                todokedeNmTextBox.ReadOnly = disabled;
                todokedeZipCdTextBox.ReadOnly = disabled;
                todokedeAdrTextBox.ReadOnly = disabled;
                todokedeTelNoTextBox.ReadOnly = disabled;

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

                #region 検索ボタン類

                soufusakiZipKensakuButton.Enabled = !disabled;
                seikyusakiZipKensakuButton.Enabled = !disabled;
                renrakusakiZipKensakuButton.Enabled = !disabled;

                setchishaZipKensakuButton.Enabled = !disabled;
                setchibashoZipKensakuButton.Enabled = !disabled;
                shiyoshaZipKensakuButton.Enabled = !disabled;

                makerKensakuButton.Enabled = !disabled;
                katashikiKensakuButton.Enabled = !disabled;
                koujiGyoshaKensakuButton.Enabled = !disabled;
                shoriHoshikiKensakuButton.Enabled = !disabled;

                itkatsuSoufuGyoshaKensakuButton.Enabled = !disabled;
                bettoSoufuGyosha1KensakuButton.Enabled = !disabled;
                bettoSoufuGyosha2KensakuButton.Enabled = !disabled;
                bettoSoufuGyosha3KensakuButton.Enabled = !disabled;
                itkatsuSeikyuGyoshaKensakuButton.Enabled = !disabled;

                hoshuTenkenGyoshaKensakuButton.Enabled = !disabled;
                hoshuYoteiGyoshaKensaku.Enabled = !disabled;
                seisouGyoshaKensakuButton.Enabled = !disabled;
                saisuiGyoshaKensakuButton.Enabled = !disabled;
                motikomiGyoshaKensakuButton.Enabled = !disabled;
                seikyuGyoshaKensakuButton.Enabled = !disabled;

                #endregion
            }

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

            #endregion

            #region command buttons

            entryButton.Visible = (this._displayMode == DispMode.Add) ? true : false;

            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            decisionButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            kensaKomokuButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            #endregion
        }
        #endregion

        #region CreateEditInsertData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private JokasoDaichoMstDataSet.JokasoDaichoMstDataTable CreateEditInsertData()
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable table = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBind.FillToDataRow(table, now, username, host, true);

            // 登録年度を西暦に変換
            foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in table)
            {
                // 20150119 habu 年度は西暦表示とする
                //row.JokasoTorokuNendo = Common.Common.ConvertToHoshouNendoSeireki(row.JokasoTorokuNendo);
                //row.JokasoHokenjoJuriNoNendo = Common.Common.ConvertToHoshouNendoSeireki(row.JokasoHokenjoJuriNoNendo);

                // 浄化槽状態は、新規登録時は1:現行
                row.JokasoJotaiKbn = Utility.Constants.JokasoJotaiKbnConstant.GENZAI;

                // 受付日 = 登録日とする
                row.JokasoUketsukeBi = now.ToString("yyyyMMdd");
            }

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetAdded();
            }

            return table;
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

            // ロード時のデータをコピーする
            _outDataBind.CopyDataTable(table, _jokasoDaichoMstDT);

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBind.FillToDataRow(table, now, username, host, false);

            // 処理目標水質はデフォルト0となる

            // 登録年度を西暦に変換
            foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in table)
            {
                // 20150119 habu 年度は西暦表示とする
                //row.JokasoTorokuNendo = Common.Common.ConvertToHoshouNendoSeireki(row.JokasoTorokuNendo);
                //row.JokasoHokenjoJuriNoNendo = Common.Common.ConvertToHoshouNendoSeireki(row.JokasoHokenjoJuriNoNendo);

                // 更新時は、現状の浄化槽状態を保持
            }

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
            // 2014/10/22 AnhNV DEL Start
            //JokasoDaichoList frm = new JokasoDaichoList();
            //Program.mForm.ShowForm(frm);
            // 2014/10/22 AnhNV DEL End

            // 2014/10/22 AnhNV ADD Start
            Program.mForm.MovePrev();
            // 2014/10/22 AnhNV ADD End
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
            if (!hokenjoCdTextBox.DoValidate(true, "保健所コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!torokuNendoTextBox.DoValidate(true, "年度", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            // 受理年度、受理連番は相関必須とする
            {
                bool jyuriInput = !string.IsNullOrEmpty(hokenjoJyuriNendoTextBox.Text) || !string.IsNullOrEmpty(hokenjoJyuriRenbanTextBox.Text);

                if (!hokenjoJyuriNendoTextBox.DoValidate(jyuriInput, "保健所受理年度", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
                if (!hokenjoJyuriRenbanTextBox.DoValidate(jyuriInput, "保健所受理連番", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            }

            if (houteiShishoComboBox.SelectedIndex <= 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "法定支所"));
            }
            if (suishitsuShishoComboBox.SelectedIndex <= 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "水質支所"));
            }

            #region Tab1(設置者・設置場所)

            if (!setchishaNmTextBox.DoValidate(true, "設置者名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaKanaTextBox.DoValidate(true, "設置者名称カナ", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaZipCdTextBox.DoValidate(false, "設置者郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaAdrTextBox.DoValidate(true, "設置者住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaTelNoTextBox.DoValidate(false, "設置者電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!shisetsuNmTextBox.DoValidate(false, "施設名", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchibashoZipCdTextBox.DoValidate(false, "設置場所郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchibashoAdrTextBox.DoValidate(true, "設置場所住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchibashoTelNoTextBox.DoValidate(false, "設置場所電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!oldChikuCdTextBox.DoValidate(false, "設置場所旧地区コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!nowChikuCdTextBox.DoValidate(true, "設置場所現地区コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (chikuwariComboBox.SelectedIndex < 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "地区割コード"));
            }

            if (!setchishaCdTextBox.DoValidate(false, "設置者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            #region Tab2(届出設置者・使用者)

            if (!todokedeNmTextBox.DoValidate(false, "届出設置者氏名", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!todokedeZipCdTextBox.DoValidate(false, "届出設置者郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!todokedeAdrTextBox.DoValidate(false, "届出設置者住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!todokedeTelNoTextBox.DoValidate(false, "届出設置者電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!shiyoshaNmTextBox.DoValidate(false, "使用者氏名", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyoshaZipCdTextBox.DoValidate(false, "使用者郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyoshaAdrTextBox.DoValidate(false, "使用者住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyoshaTelNoTextBox.DoValidate(false, "使用者電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            #region Tab3(浄化槽情報)

            if (konkyoHoreiComboBox.SelectedIndex < 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "根拠法令"));
            }

            if (!chakkoNenTextBox.DoValidate(false, "設置日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!chakkoTsukiTextBox.DoValidate(false, "設置日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!chakkoBiTextBox.DoValidate(false, "設置日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!shiyokaishiNenTextBox.DoValidate(false, "使用開始日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyokaishiTsukiTextBox.DoValidate(false, "使用開始日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyokaishiBiTextBox.DoValidate(false, "使用開始日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!haishiNenTextBox.DoValidate(false, "廃止日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!haishiTsukiTextBox.DoValidate(false, "廃止日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!haishiBiTextBox.DoValidate(false, "廃止日", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!makerCdTextBox.DoValidate(false, "メーカー業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!makerNmTextBox.DoValidate(false, "メーカー業者名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!katashikiTextBox.DoValidate(false, "型式", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shohinNmTextBox.DoValidate(false, "商品名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            //if (!koujiKbnTextBox.DoValidate(false, "告示区分", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!koujiNenTextBox.DoValidate(false, "告示年", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!koujiNoTextBox.DoValidate(false, "告示番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!ninteiNoTextBox.DoValidate(false, "認定番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!koujiGyoshaCdTextBox.DoValidate(false, "工事業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!shoriHoshikiShubetsuNmTextBox.DoValidate(true, "処理方式種別", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shoriHoshikiNmTextBox.DoValidate(false, "処理方式", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (shoriMokuhyoBodComboBox.SelectedIndex < 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "処理目標水質"));
            }

            if (!shoriTaishoJininTextBox.DoValidate(true, "処理対象人員", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!hiHeikinOsuiRyoTextBox.DoValidate(false, "日平均汚水量", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!JitsuSiyoJininTextBox.DoValidate(false, "実使用人員", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!jitsuSiyoJininSuchiTextBox.DoValidate(false, "実使用人員数値", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!jitsuHiHeikinOsuiRyoTextBox.DoValidate(false, "実日平均汚水量", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!bodJyokyoTextBox.DoValidate(false, "BOD除去率", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!bodHosuityuTextBox.DoValidate(false, "放流水中のBOD", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!kasaageTakasaTextBox.DoValidate(false, "嵩上げ高さ", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!ryunyuTairyuTakasaTextBox.DoValidate(false, "流入滞留高さ", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!houryuTairyuTakasaTextBox.DoValidate(false, "放流滞留高さ", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!sanjishoriTypeTextBox.DoValidate(false, "3次処理タイプ", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            #region Tab4(送付・請求先情報)

            if (!soufusakiNmTextBox.DoValidate(false, "送付先名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!soufusakiTelNoTextBox.DoValidate(false, "送付先電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!soufusakiZipCdTextBox.DoValidate(false, "送付先郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!soufusakiAdrTextBox.DoValidate(false, "送付先住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!itkatsuSoufuGyoshaCdTextBox.DoValidate(false, "一括送付業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!bettoSoufuGyoshaCd1TextBox.DoValidate(false, "別途送付業者コード1", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!bettoSoufuGyoshaCd2TextBox.DoValidate(false, "別途送付業者コード2", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!bettoSoufuGyoshaCd3TextBox.DoValidate(false, "別途送付業者コード3", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!seikyusakiNmTextBox.DoValidate(false, "請求先名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!seikyusakiTelNoTextBox.DoValidate(false, "請求先電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!seikyusakiZipCdTextBox.DoValidate(false, "請求先郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!seikyusakiAdrTextBox.DoValidate(false, "請求先住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!renrakusakiNmTextBox.DoValidate(false, "連絡先名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!renrakusakiTelNoTextBox.DoValidate(false, "連絡先電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!renrakusakiZipCdTextBox.DoValidate(false, "連絡先郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!renrakusakiAdrTextBox.DoValidate(false, "連絡先住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            #region Tab5(業者情報)

            if (!hoshuTenkenGyoshaCdTextBox.DoValidate(false, "保守点検業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!hoshuYoteiGyoshaCdTextBox.DoValidate(false, "保守予定業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!seisouGyoshaCdTextBox.DoValidate(false, "清掃業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!saisuiGyoshaCdTextBox.DoValidate(false, "採水業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!mochikomiGyoshaCdTextBox.DoValidate(false, "持込業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!seikyuGyoshaCdTextBox.DoValidate(false, "請求業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!itkatsuSeikyuGyoshaCdTextBox.DoValidate(false, "一括請求業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            #region Tab6(メモ)

            if (!memo1TextBox.DoValidate(false, "手書きメモ1", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!memo2TextBox.DoValidate(false, "手書きメモ2", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

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
            // 20150119 habu 年度を西暦とする
            torokuNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            //torokuNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            renbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            // 20150119 habu 年度を西暦とする
            hokenjoJyuriNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            //hokenjoJyuriNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            hokenjoJyuriRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            #region Tab1(設置者・設置場所)

            setchishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            setchishaKanaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME_KANA_HALF, 60);
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

            nobeMensekiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 2, InputValidateUtility.SignFlg.Positive);

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

            #region 検査履歴

            kensaRirekiDataGridView.SetStdControlDomain(kensaKekkaHanteiNmDataGridViewTextBoxColumn.Index, ZControlDomain.ZG_STD_NAME, 100, DataGridViewContentAlignment.TopCenter);

            kensaRirekiDataGridView.SetStdControlDomain(kensaKekkaBODDataGridViewTextBoxColumn.Index, ZControlDomain.ZG_STD_NUM, 8);
            kensaRirekiDataGridView.SetStdControlDomain(kensaKekkaTrDataGridViewTextBoxColumn.Index, ZControlDomain.ZG_STD_NUM, 8);
            kensaRirekiDataGridView.SetStdControlDomain(kensaKekkaPhDataGridViewTextBoxColumn.Index, ZControlDomain.ZG_STD_NUM, 8);
            kensaRirekiDataGridView.SetStdControlDomain(kensaKekkaClDataGridViewTextBoxColumn.Index, ZControlDomain.ZG_STD_NUM, 8);
            kensaRirekiDataGridView.SetStdControlDomain(KensaKekkaZanen.Index, ZControlDomain.ZG_STD_NUM, 8);
            kensaRirekiDataGridView.SetStdControlDomain(KensaKekkaDo.Index, ZControlDomain.ZG_STD_NUM, 8);

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

            // template table(カラム情報は必要なので)
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable templateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            bind.AddControlBind(hokenjoCdTextBox, templateTable.JokasoHokenjoCdColumn);
            bind.AddControlBind(torokuNendoTextBox, templateTable.JokasoTorokuNendoColumn);
            bind.AddControlBind(renbanTextBox, templateTable.JokasoRenbanColumn);

            // 浄化槽保健所コード = 保健所受理番号保健所コードとする
            bind.AddControlBind(hokenjoCdTextBox, templateTable.JokasoHokenjoJuriNoHokenCdColumn);

            bind.AddControlBind(hokenjoJyuriNendoTextBox, templateTable.JokasoHokenjoJuriNoNendoColumn);
            bind.AddControlBind(hokenjoJyuriRenbanTextBox, templateTable.JokasoHokenjoJuriNoRenbanColumn);

            bind.AddControlBind(houteiShishoComboBox, templateTable.JokasoHoteiSishoCdColumn);
            bind.AddControlBind(suishitsuShishoComboBox, templateTable.JokasoSuisitsuSishoCdColumn);

            #region Tab1(設置者・設置場所)

            bind.AddControlBind(setchishaNmTextBox, templateTable.JokasoSetchishaNmColumn);
            bind.AddControlBind(setchishaKanaTextBox, templateTable.JokasoSetchishaKanaColumn);
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

            #region 建物用途

            bind.AddControlBind(tatemonoYoto1ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui1Column, templateTable.KenchikuyotoShobunrui1Column, templateTable.KenchikuyotoRenban1Column });
            bind.AddControlBind(tatemonoYoto2ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui2Column, templateTable.KenchikuyotoShobunrui2Column, templateTable.KenchikuyotoRenban2Column });
            bind.AddControlBind(tatemonoYoto3ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui3Column, templateTable.KenchikuyotoShobunrui3Column, templateTable.KenchikuyotoRenban3Column });
            bind.AddControlBind(tatemonoYoto4ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui4Column, templateTable.KenchikuyotoShobunrui4Column, templateTable.KenchikuyotoRenban4Column });
            bind.AddControlBind(tatemonoYoto5ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui5Column, templateTable.KenchikuyotoShobunrui5Column, templateTable.KenchikuyotoRenban5Column });

            bind.AddControlBind(nobeMensekiTextBox, templateTable.JokasoTatemonoNobeMensekiColumn);

            bind.AddControlBind(oldTatemonoYotoComboBox, templateTable.JokasoOldKentikuYoutoCdColumn);

            #endregion

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

            bind.AddControlBind(koujiNenTextBox, templateTable.JokasoKoujiNenColumn);
            bind.AddControlBind(koujiNoTextBox, templateTable.JokasoKoujiNoColumn);
            bind.AddControlBind(ninteiNoTextBox, templateTable.JokasoNinteiNoColumn);

            bind.AddControlBind(koujiGyoshaCdTextBox, templateTable.JokasoKojiGyoshaKbnColumn);

            bind.AddControlBind(_shoriHoshikiKbn, templateTable.JokasoShoriHosikiKbnColumn);
            bind.AddControlBind(_shoriHoshikiCd, templateTable.JokasoShoriHosikiCdColumn);
            bind.AddControlBind(_shoriHoshikiShubetsu, templateTable.JokasoShoriHosikiShubetuColumn);

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
            Common.Common.SetStdButtonKey(this, Keys.F6, kensaKomokuButton);
            Common.Common.SetStdButtonKey(this, Keys.F12, closeButton);

            Common.Common.SetCdAutoPad(hokenjoCdTextBox);
            Common.Common.SetCdAutoPad(torokuNendoTextBox);

            Common.Common.SetCdAutoPad(hokenjoJyuriNendoTextBox);
            Common.Common.SetCdAutoPad(hokenjoJyuriRenbanTextBox);

            Common.Common.SetCdAutoPad(oldChikuCdTextBox);
            Common.Common.SetCdAutoPad(nowChikuCdTextBox);
            Common.Common.SetCdAutoPad(setchishaCdTextBox);

            Common.Common.SetCdAutoPad(chakkoNenTextBox);
            Common.Common.SetCdAutoPad(chakkoTsukiTextBox);
            Common.Common.SetCdAutoPad(chakkoBiTextBox);

            Common.Common.SetCdAutoPad(shiyokaishiNenTextBox);
            Common.Common.SetCdAutoPad(shiyokaishiTsukiTextBox);
            Common.Common.SetCdAutoPad(shiyokaishiBiTextBox);

            Common.Common.SetCdAutoPad(haishiNenTextBox);
            Common.Common.SetCdAutoPad(haishiTsukiTextBox);
            Common.Common.SetCdAutoPad(haishiBiTextBox);

            Common.Common.SetCdAutoPad(makerCdTextBox);
            Common.Common.SetCdAutoPad(katashikiTextBox);
            Common.Common.SetCdAutoPad(koujiGyoshaCdTextBox);

            Common.Common.SetCdAutoPad(itkatsuSoufuGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(bettoSoufuGyoshaCd1TextBox);
            Common.Common.SetCdAutoPad(bettoSoufuGyoshaCd2TextBox);
            Common.Common.SetCdAutoPad(bettoSoufuGyoshaCd3TextBox);

            Common.Common.SetCdAutoPad(hoshuYoteiGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(hoshuTenkenGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(seisouGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(saisuiGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(mochikomiGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(seikyuGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(itkatsuSeikyuGyoshaCdTextBox);

            #region ZipCd

            AdrUtility.ZipCd.SetStdZipCdSearchButton(setchishaZipKensakuButton, setchishaZipCdTextBox, setchishaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdSearchButton(setchibashoZipKensakuButton, setchibashoZipCdTextBox, setchibashoAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdSearchButton(shiyoshaZipKensakuButton, shiyoshaZipCdTextBox, shiyoshaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdSearchButton(soufusakiZipKensakuButton, soufusakiZipCdTextBox, soufusakiAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdSearchButton(seikyusakiZipKensakuButton, seikyusakiZipCdTextBox, seikyusakiAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdSearchButton(renrakusakiZipKensakuButton, renrakusakiZipCdTextBox, renrakusakiAdrTextBox);

            AdrUtility.ZipCd.SetStdZipCdChanged(setchishaZipCdTextBox, setchishaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdChanged(setchibashoZipCdTextBox, setchibashoAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdChanged(shiyoshaZipCdTextBox, shiyoshaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdChanged(soufusakiZipCdTextBox, soufusakiAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdChanged(seikyusakiZipCdTextBox, seikyusakiAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdChanged(renrakusakiZipCdTextBox, renrakusakiAdrTextBox);

            #endregion

            #region GyoshaCd

            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(koujiGyoshaKensakuButton, koujiGyoshaCdTextBox, koujiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(hoshuTenkenGyoshaKensakuButton, hoshuTenkenGyoshaCdTextBox, hoshuTenkenGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(hoshuYoteiGyoshaKensaku, hoshuYoteiGyoshaCdTextBox, hoshuYoteiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(seisouGyoshaKensakuButton, seisouGyoshaCdTextBox, seisouGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(saisuiGyoshaKensakuButton, saisuiGyoshaCdTextBox, saisuiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(motikomiGyoshaKensakuButton, mochikomiGyoshaCdTextBox, mochikomiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(seikyuGyoshaKensakuButton, seikyuGyoshaCdTextBox, seikyuGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(itkatsuSeikyuGyoshaKensakuButton, itkatsuSeikyuGyoshaCdTextBox, itkatsuSeikyuGyoshaNmTextBox);
            // TODO メーカーが変わった場合は、一旦型式はクリアされるべきか、、、
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(makerKensakuButton, makerCdTextBox, makerNmTextBox);

            // code only(no name area)
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(bettoSoufuGyosha1KensakuButton, bettoSoufuGyoshaCd1TextBox, null);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(bettoSoufuGyosha2KensakuButton, bettoSoufuGyoshaCd2TextBox, null);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(bettoSoufuGyosha3KensakuButton, bettoSoufuGyoshaCd3TextBox, null);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(itkatsuSoufuGyoshaKensakuButton, itkatsuSoufuGyoshaCdTextBox, null);

            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(koujiGyoshaCdTextBox, koujiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(hoshuTenkenGyoshaCdTextBox, hoshuTenkenGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(hoshuYoteiGyoshaCdTextBox, hoshuYoteiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(seisouGyoshaCdTextBox, seisouGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(saisuiGyoshaCdTextBox, saisuiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(mochikomiGyoshaCdTextBox, mochikomiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(seikyuGyoshaCdTextBox, seikyuGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(itkatsuSeikyuGyoshaCdTextBox, itkatsuSeikyuGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(makerCdTextBox, makerNmTextBox);

            #endregion

            #region HokenjoCd

            AdrUtility.HokenjoCd.SetStdHokenjoCdAdrChanged(setchibashoAdrTextBox, hokenjoCdTextBox, false);
            AdrUtility.HokenjoCd.SetStdHokenjoCdZipCdChanged(setchibashoZipCdTextBox, hokenjoCdTextBox, false);

            #endregion

            #region ChikuCd

            // TODO 旧地区コードは、コンボボックスとする（複数候補がある場合は、選択してもらう）(テキスト入力も可能とする)

            // 旧地区コード
            AdrUtility.KyuChikuCd.SetStdKyuChikuCdAdrChanged(setchibashoAdrTextBox, oldChikuCdTextBox, false);
            AdrUtility.KyuChikuCd.SetStdKyuChikuCdZipCdChanged(setchibashoZipCdTextBox, oldChikuCdTextBox, false);

            // 現地区コード
            AdrUtility.GenChikuCd.SetStdGenChikuCdAdrChanged(setchibashoAdrTextBox, nowChikuCdTextBox, false);
            AdrUtility.GenChikuCd.SetStdGenChikuCdZipCdChanged(setchibashoZipCdTextBox, nowChikuCdTextBox, false);

            #endregion

            #region other

            MstUtility.KatashikiMst.SetStdKatashikiSearchButton(katashikiKensakuButton
                , makerCdTextBox, makerNmTextBox
                , katashikiTextBox, shohinNmTextBox
                , _shoriHoshikiKbn, _shoriHoshikiCd, _shoriHoshikiShubetsu
                , shoriHoshikiShubetsuNmTextBox, shoriHoshikiNmTextBox
                , true);
            //MstUtility.KatashikiMst.SetStdKatashikiSearchButton(katashikiKensakuButton, makerCdTextBox, makerNmTextBox, katashikiTextBox, shohinNmTextBox, true);

            MstUtility.ShoriHoshikiMst.SetStdShoriHoshikiSearchButton(shoriHoshikiKensakuButton, _shoriHoshikiKbn, _shoriHoshikiCd, _shoriHoshikiShubetsu, shoriHoshikiShubetsuNmTextBox, shoriHoshikiNmTextBox, true);

            KatashikiMstDataSet.KatashikiMstSearchDataTable katashikiTalble = new KatashikiMstDataSet.KatashikiMstSearchDataTable();

            MstUtility.Generic.SetStdMstCdChanged(
                new TextBox[] { makerCdTextBox, katashikiTextBox }
                , new TextBox[] { shohinNmTextBox
                    , _shoriHoshikiKbn, _shoriHoshikiCd, _shoriHoshikiShubetsu
                    , shoriHoshikiShubetsuNmTextBox,shoriHoshikiNmTextBox }
                , new string[] { katashikiTalble.KatashikiMakerCdColumn.ColumnName, katashikiTalble.KatashikiCdColumn.ColumnName }
                , new string[] { katashikiTalble.KatashikiNmColumn.ColumnName
                    , katashikiTalble.KatashikiShorihoushikiKbnColumn.ColumnName, katashikiTalble.KatashikiShorihoushikiCdColumn.ColumnName, katashikiTalble.ShoriHoshikiShubetsuKbnColumn.ColumnName 
                    , katashikiTalble.ShoriHoshikiShubetsuNmColumn.ColumnName , katashikiTalble.ShoriHoshikiNmColumn.ColumnName }
                , typeof(KatashikiMstDataSet.KatashikiMstSearchDataTable)
                , typeof(KatashikiMstSearchTableAdapter), true);

            ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable shoriTable = new ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

            #endregion
        }
        #endregion

        #endregion

        #endregion

    }
}
