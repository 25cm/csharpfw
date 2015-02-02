using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuShikenKoumokuMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuShikenKoumokuMstShosai
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuShikenKoumokuMstShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Add,        // 登録モード
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
        }

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// Display mode
        /// </summary>
        public DispMode _displayMode = DispMode.Add;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 水質試験項目コード
        /// </summary>
        private string _suishitsuShikenKoumokuCd = string.Empty;

        /// <summary>
        /// SuishitsuShikenKoumokuDataTable
        /// </summary>
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable _suishitsuShikenKoumokuDT = new SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuShikenKoumokuMstShosai
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuShikenKoumokuMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuShikenKoumokuMstShosai
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="suishitsuShikenKoumokuCd"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuShikenKoumokuMstShosaiForm(string suishitsuShikenKoumokuCd)
        {
            _suishitsuShikenKoumokuCd = suishitsuShikenKoumokuCd;
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SuishitsuShikenKoumokuMstShosai_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuShikenKoumokuMstShosai_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuShikenKoumokuMstShosai_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();

                SetDisplayControl();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 画面を終了（前画面に戻る）
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region entryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： entryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DataCheck())
                {
                    return;
                }

                this._displayMode = DispMode.Confirm;

                SetDisplayControl();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region changeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： changeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._displayMode == DispMode.Edit)
                {
                    if (!DataCheck())
                    {
                        return;
                    }
                    this._displayMode = DispMode.Confirm;
                }

                if (this._displayMode == DispMode.Detail)
                {
                    this._displayMode = DispMode.Edit;
                }

                SetDisplayControl();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region deleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") == DialogResult.Yes)
                {
                    IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                    alInput.SuishitsuShikenKoumokuCd = this._suishitsuShikenKoumokuCd;

                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    //check not exist record
                    if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                        return;
                    }

                    //close form and redirect SuishitsuShikenKoumokuMstListForm
                    this.DialogResult = DialogResult.OK;
                    Program.mForm.MovePrev();
                }

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region reInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： reInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(this._suishitsuShikenKoumokuCd))
                {
                    this._displayMode = DispMode.Add;
                }
                else
                {
                    this._displayMode = DispMode.Edit;
                }

                SetDisplayControl();

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region decisionButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： decisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();

                //insert data
                if (string.IsNullOrEmpty(this._suishitsuShikenKoumokuCd))
                {
                    alInput.DisplayMode = DispMode.Add;
                    alInput.SuishitsuShikenKoumokuMstDataTable = CreateSuishitsuShikenKoumokuMstInsert();
                }
                else
                {
                    //update data
                    alInput.DisplayMode = DispMode.Edit;
                    alInput.SuishitsuShikenKoumokuMstDataTable = CreateSuishitsuShikenKoumokuMstUpdate(this._suishitsuShikenKoumokuDT);
                }

                IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                    return;
                }

                //close form and redirect SuishitsuShikenKoumokuMstListForm
                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();

            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._displayMode != DispMode.Detail)
                {
                    if ((string.IsNullOrEmpty(this._suishitsuShikenKoumokuCd) && IsEditedControlModeAdd())
                        || (!string.IsNullOrEmpty(this._suishitsuShikenKoumokuCd) && IsEditedControlModeEdit())
                        )
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                }

                Program.mForm.SetMenuEnabled(true);
                Program.mForm.MovePrev();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region SuishitsuShikenKoumokuMstShosai_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuShikenKoumokuMstShosai_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuShikenKoumokuMstShosai_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        entryButton.Focus();
                        entryButton.PerformClick();
                        break;
                    case Keys.F2:
                        changeButton.Focus();
                        changeButton.PerformClick();
                        break;
                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
                        break;
                    case Keys.F4:
                        reInputButton.Focus();
                        reInputButton.PerformClick();
                        break;
                    case Keys.F5:
                        decisionButton.Focus();
                        decisionButton.PerformClick();
                        break;
                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SuishitsuShikenKoumokuCd = this._suishitsuShikenKoumokuCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            this._suishitsuShikenKoumokuDT = alOutput.SuishitsuShikenKoumokuMstDataTable;

            if (!string.IsNullOrEmpty(this._suishitsuShikenKoumokuCd))
            {
                _displayMode = DispMode.Detail;
                this.Text = "水質試験項目マスタ詳細";

                SetDefaultValueControl();
            }

        }
        #endregion

        #region SetDefaultValueControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValueControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX    新規作成
        /// 2015/01/26　HuyTX    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            if (this._suishitsuShikenKoumokuDT.Count > 0)
            {
                //水質試験項目コード(1)
                suishitsuShikenKoumokuCdTextBox.Text = this._suishitsuShikenKoumokuDT[0].SuishitsuShikenKoumokuCd;

                //正式名称(2)
                seishikiNmTextBox.Text = this._suishitsuShikenKoumokuDT[0].SeishikiNm;

                //略式名称(3)
                ryakushikiNmTextBox.Text = this._suishitsuShikenKoumokuDT[0].RyakushikiNm;

                //計量方法名称（上段）(4)
                keiryouHouhouNmUpTextBox.Text = this._suishitsuShikenKoumokuDT[0].KeiryouHouhouNmUp;

                //計量方法名称（上段）(5)
                keiryouHouhouNmDownTextBox.Text = this._suishitsuShikenKoumokuDT[0].KeiryouHouhouNmDown;

                //水質試験項目料金(6)
                suishitsuShikenKomokuAmtTextBox.Text = this._suishitsuShikenKoumokuDT[0].SuishitsuShikenKomokuAmt.ToString("#,###");

                //上部印字(7)
                injiKbnUpRadioButton.Checked = (this._suishitsuShikenKoumokuDT[0].InjiKbn == "1") ? true : false;

                //下部印字(8)
                injiKbnDownRadioButton.Checked = (this._suishitsuShikenKoumokuDT[0].InjiKbn == "2") ? true : false;

                //印字順(9)
                injiJyunTextBox.Text = this._suishitsuShikenKoumokuDT[0].InjiJyun;

                //外注委託区分(10)
                gaichuItakuKbnCheckBox.Checked = (this._suishitsuShikenKoumokuDT[0].GaichuItakuKbn == "1") ? true : false;

                //小数部桁数(11)
                shosubuKetasuTextBox.Text = this._suishitsuShikenKoumokuDT[0].ShosubuKetasu;

                //有効桁数(12)
                yukoKetasuTextBox.Text = this._suishitsuShikenKoumokuDT[0].YukoKetasu;

                //単位(13)
                unitTextBox.Text = this._suishitsuShikenKoumokuDT[0].Unit;

                //ゼロ表示(14)
                zeroHyojiKbnCheckBox.Checked = (this._suishitsuShikenKoumokuDT[0].ZeroHyojiKbn == "1") ? true : false;

                //結果入力省略不可(15)
                kekkaNyuryokuShoryakuKbnCheckBox.Checked = (this._suishitsuShikenKoumokuDT[0].KekkaNyuryokuShoryakuKbn == "1") ? true : false;

                //定量下限値1(16)
                teiryoKagenchi1TextBox.Text = this._suishitsuShikenKoumokuDT[0].TeiryoKagenchi1.ToString().Trim();

                //定量下限値2(17)
                teiryoKagenchi2TextBox.Text = this._suishitsuShikenKoumokuDT[0].TeiryoKagenchi2.ToString().Trim();

                //定量表示用1(18)
                teiryoHyojiyo1TextBox.Text = this._suishitsuShikenKoumokuDT[0].TeiryoHyojiyo1.ToString().Trim();

                //定量表示用2(19)
                teiryoHyojiyo2TextBox.Text = this._suishitsuShikenKoumokuDT[0].TeiryoHyojiyo2.Trim();

                //Ver1.02 Start
                //計量証明書発行対象フラグ
                keiryoshomeiHakkoFlgCheckBox.Checked = this._suishitsuShikenKoumokuDT[0].KeiryoshomeiHakkoFlg == "1" ? true : false;
                //End
            }
        }
        #endregion

        #region SetDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX    新規作成
        /// 2015/01/26　HuyTX    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            //水質試験項目コード(1)
            // UPD 20140724 START ZynasSou
            //suishitsuShikenKoumokuCdTextBox.ReadOnly = (this._displayMode == DispMode.Add) ? false : true;
            suishitsuShikenKoumokuCdTextBox.ReadOnly = true;
            // UPD 20140724 START ZynasSou

            //正式名称(2)
            seishikiNmTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //略式名称(3)
            ryakushikiNmTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //計量方法名称（上段）(4)
            keiryouHouhouNmUpTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //計量方法名称（上段）(5)
            keiryouHouhouNmDownTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //水質試験項目料金(6)
            suishitsuShikenKomokuAmtTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //上部印字(7)
            injiKbnUpRadioButton.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //下部印字(8)
            injiKbnDownRadioButton.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //印字順(9)
            injiJyunTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //外注委託区分(10)
            gaichuItakuKbnCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //小数部桁数(11)
            shosubuKetasuTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //有効桁数(12)  
            yukoKetasuTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //単位(13)
            unitTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //ゼロ表示(14)
            zeroHyojiKbnCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //結果入力省略不可(15)
            kekkaNyuryokuShoryakuKbnCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //定量下限値1(16)
            teiryoKagenchi1TextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //定量下限値2(17)
            teiryoKagenchi2TextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //定量表示用1(18)
            teiryoHyojiyo1TextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //定量表示用2(19)
            teiryoHyojiyo2TextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //Ver1.02 Start
            //計量証明書発行対象フラグ
            keiryoshomeiHakkoFlgCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;
            //End

            //登録ボタン (20)
            entryButton.Visible = (this._displayMode == DispMode.Add) ? true : false;

            //変更ボタン (21)
            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            //削除ボタン (22)
            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            //再入力ボタン (23) 
            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //確定ボタン (24) 
            decisionButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //change screen title
            SetScreenTitle();
        }
        #endregion

        #region SetScreenTitle
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetScreenTitle
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (this._displayMode)
            {
                case DispMode.Add:
                    Program.mForm.Text = "水質試験項目マスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "水質試験項目マスタ変更";
                    Program.mForm.SetMenuEnabled(false);
                    break;
                case DispMode.Detail:
                    Program.mForm.Text = "水質試験項目マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "水質試験項目マスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
            }
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();
            Regex regex = new Regex("[0-9]");

            // DEL 20140724 START ZynasSou
            ////水質試験項目コード(1)
            //if (string.IsNullOrEmpty(suishitsuShikenKoumokuCdTextBox.Text))
            //{
            //    errMsg.AppendLine("必須項目：水質試験項目コードが入力されていません。");
            //}
            //else if (suishitsuShikenKoumokuCdTextBox.TextLength != 3)
            //{
            //    errMsg.AppendLine("水質試験項目コードは3桁で入力して下さい。");
            //}
            // DEL 20140724 END ZynasSou

            //正式名称(2)
            if (string.IsNullOrEmpty(seishikiNmTextBox.Text))
            {
                errMsg.AppendLine("必須項目：正式名称が入力されていません。");
            }
            else if (seishikiNmTextBox.Text.Trim().Length > 30)
            {
                errMsg.AppendLine("正式名称は30文字以下で入力して下さい。");
            }

            //略式名称(3)
            if (string.IsNullOrEmpty(ryakushikiNmTextBox.Text))
            {
                errMsg.AppendLine("必須項目：略式名称が入力されていません。");
            }
            else if (ryakushikiNmTextBox.Text.Trim().Length > 10)
            {
                errMsg.AppendLine("略式名称は10文字以下で入力して下さい。");
            }

            //計量方法名称（上段）(4)
            if (string.IsNullOrEmpty(keiryouHouhouNmUpTextBox.Text))
            {
                errMsg.AppendLine("必須項目：計量方法名称（上段）が入力されていません。");
            }
            else if (keiryouHouhouNmUpTextBox.Text.Trim().Length > 44)
            {
                errMsg.AppendLine("計量方法名称（上段）は44文字以下で入力して下さい。");
            }

            //計量方法名称（下段）(5)
            if (string.IsNullOrEmpty(keiryouHouhouNmDownTextBox.Text))
            {
                errMsg.AppendLine("必須項目：計量方法名称（下段）が入力されていません。");
            }
            else if (keiryouHouhouNmDownTextBox.Text.Trim().Length > 44)
            {
                errMsg.AppendLine("計量方法名称（下段）は44文字以下で入力して下さい。");
            }

            //水質試験項目料金(6)
            if (string.IsNullOrEmpty(suishitsuShikenKomokuAmtTextBox.Text))
            {
                errMsg.AppendLine("必須項目：水質試験項目料金が入力されていません。");
            }
            else if (!Utility.Utility.IsDecimal(suishitsuShikenKomokuAmtTextBox.Text))
            {
                errMsg.AppendLine("水質試験項目料金は半角数字で入力して下さい。");
            }

            //印字順(9)
            if (string.IsNullOrEmpty(injiJyunTextBox.Text))
            {
                errMsg.AppendLine("必須項目：印字順が入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(injiJyunTextBox.Text))
                {
                    errMsg.AppendLine("印字順は半角数字で入力して下さい。");
                }
                else if (injiJyunTextBox.TextLength != 3)
                {
                    errMsg.AppendLine("印字順は3桁で入力して下さい。");
                }
            }

            //小数部桁数(11)
            if (string.IsNullOrEmpty(shosubuKetasuTextBox.Text))
            {
                errMsg.AppendLine("必須項目：小数部桁数が入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(shosubuKetasuTextBox.Text))
                {
                    errMsg.AppendLine("小数部桁数は半角数字で入力して下さい。");
                }
                else if (shosubuKetasuTextBox.TextLength != 1)
                {
                    errMsg.AppendLine("小数部桁数は1桁で入力して下さい。");
                }
            }

            //有効桁数(12)
            if (string.IsNullOrEmpty(yukoKetasuTextBox.Text))
            {
                errMsg.AppendLine("必須項目：有効桁数が入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(yukoKetasuTextBox.Text))
                {
                    errMsg.AppendLine("有効桁数は半角数字で入力して下さい。");
                }
                else if (yukoKetasuTextBox.TextLength != 1)
                {
                    errMsg.AppendLine("有効桁数は1桁で入力して下さい。");
                }
            }

            //単位(15)
            if (unitTextBox.Text.Trim().Length > 10)
            {
                errMsg.AppendLine("単位は10文字以下で入力して下さい。");
            }

            //定量下限値1(16)
            if (!string.IsNullOrEmpty(teiryoKagenchi1TextBox.Text.Trim()))
            {
                if (!regex.Match(teiryoKagenchi1TextBox.Text.Trim()).Success)
                {
                    errMsg.AppendLine("定量下限値1は半角数字で入力して下さい。");
                }
                else if (teiryoKagenchi1TextBox.TextLength > 53)
                {
                    errMsg.AppendLine("定量下限値1は53桁以下で入力して下さい。");
                }
            }

            //定量表示用1(17)
            if (!string.IsNullOrEmpty(teiryoHyojiyo1TextBox.Text))
            {
                if (!Utility.Utility.IsDecimal(teiryoHyojiyo1TextBox.Text))
                {
                    errMsg.AppendLine("定量表示用1は半角数字で入力して下さい。");
                }
                else if (teiryoHyojiyo1TextBox.TextLength > 5)
                {
                    errMsg.AppendLine("定量表示用1は5桁以下で入力して下さい。");
                }
            }

            //定量下限値2(18)
            if (!string.IsNullOrEmpty(teiryoKagenchi2TextBox.Text))
            {
                if (!regex.Match(teiryoKagenchi2TextBox.Text.Trim()).Success)
                {
                    errMsg.AppendLine("定量下限値2は半角数字で入力して下さい。");
                }
                else if (teiryoKagenchi2TextBox.TextLength > 53)
                {
                    errMsg.AppendLine("定量下限値2は53桁以下で入力して下さい。");
                }
            }

            //定量表示用2(19)
            if (!string.IsNullOrEmpty(teiryoHyojiyo2TextBox.Text.Trim()))
            {
                if (!Utility.Utility.IsDecimal(teiryoHyojiyo2TextBox.Text))
                {
                    errMsg.AppendLine("定量表示用2は半角数字で入力して下さい。");
                }
                else if (teiryoHyojiyo2TextBox.TextLength > 5)
                {
                    errMsg.AppendLine("定量表示用2は5桁以下で入力して下さい。");
                }
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region IsEditedControlModeAdd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsEditedControlModeAdd
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  HuyTX　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedControlModeAdd()
        {
            if (!string.IsNullOrEmpty(suishitsuShikenKoumokuCdTextBox.Text)
                || !string.IsNullOrEmpty(seishikiNmTextBox.Text)
                || !string.IsNullOrEmpty(ryakushikiNmTextBox.Text)
                || !string.IsNullOrEmpty(keiryouHouhouNmUpTextBox.Text)
                || !string.IsNullOrEmpty(keiryouHouhouNmDownTextBox.Text)
                || !string.IsNullOrEmpty(suishitsuShikenKomokuAmtTextBox.Text)
                || injiKbnUpRadioButton.Checked == false
                || !string.IsNullOrEmpty(injiJyunTextBox.Text)
                || gaichuItakuKbnCheckBox.Checked == true
                || !string.IsNullOrEmpty(shosubuKetasuTextBox.Text)
                || !string.IsNullOrEmpty(yukoKetasuTextBox.Text)
                || !string.IsNullOrEmpty(unitTextBox.Text)
                || zeroHyojiKbnCheckBox.Checked == true
                || kekkaNyuryokuShoryakuKbnCheckBox.Checked == true
                || !string.IsNullOrEmpty(teiryoKagenchi1TextBox.Text)
                || !string.IsNullOrEmpty(teiryoKagenchi2TextBox.Text)
                || !string.IsNullOrEmpty(teiryoHyojiyo1TextBox.Text)
                || !string.IsNullOrEmpty(teiryoHyojiyo2TextBox.Text)
                //Ver1.02 Start
                || keiryoshomeiHakkoFlgCheckBox.Checked == true
                //End
                )
            {
                return true;
            }

            return false;
        }
        #endregion

        #region IsEditedControlModeEdit
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsEditedControlModeEdit
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  HuyTX　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedControlModeEdit()
        {
            if (this._suishitsuShikenKoumokuDT.Count != 0)
            {
                if (suishitsuShikenKoumokuCdTextBox.Text != this._suishitsuShikenKoumokuDT[0].SuishitsuShikenKoumokuCd
                || seishikiNmTextBox.Text != this._suishitsuShikenKoumokuDT[0].SeishikiNm
                || ryakushikiNmTextBox.Text != this._suishitsuShikenKoumokuDT[0].RyakushikiNm
                || keiryouHouhouNmUpTextBox.Text != this._suishitsuShikenKoumokuDT[0].KeiryouHouhouNmUp
                || keiryouHouhouNmDownTextBox.Text != this._suishitsuShikenKoumokuDT[0].KeiryouHouhouNmDown
                || suishitsuShikenKomokuAmtTextBox.Text != this._suishitsuShikenKoumokuDT[0].SuishitsuShikenKomokuAmt.ToString("#,###")
                || (injiKbnUpRadioButton.Checked && this._suishitsuShikenKoumokuDT[0].InjiKbn == "2")
                || (injiKbnDownRadioButton.Checked && this._suishitsuShikenKoumokuDT[0].InjiKbn == "1")
                || injiJyunTextBox.Text != this._suishitsuShikenKoumokuDT[0].InjiJyun
                || gaichuItakuKbnCheckBox.Checked != (this._suishitsuShikenKoumokuDT[0].GaichuItakuKbn == "1") ? true : false
                || shosubuKetasuTextBox.Text != this._suishitsuShikenKoumokuDT[0].ShosubuKetasu
                || yukoKetasuTextBox.Text != this._suishitsuShikenKoumokuDT[0].YukoKetasu
                || unitTextBox.Text != this._suishitsuShikenKoumokuDT[0].Unit
                || zeroHyojiKbnCheckBox.Checked != (this._suishitsuShikenKoumokuDT[0].ZeroHyojiKbn == "1") ? true : false
                || kekkaNyuryokuShoryakuKbnCheckBox.Checked != (this._suishitsuShikenKoumokuDT[0].KekkaNyuryokuShoryakuKbn == "1") ? true : false
                || teiryoKagenchi1TextBox.Text != this._suishitsuShikenKoumokuDT[0].TeiryoKagenchi1.ToString().Trim()
                || teiryoKagenchi2TextBox.Text != this._suishitsuShikenKoumokuDT[0].TeiryoKagenchi2.ToString().Trim()
                || teiryoHyojiyo1TextBox.Text != this._suishitsuShikenKoumokuDT[0].TeiryoHyojiyo1.Trim()
                || teiryoHyojiyo2TextBox.Text != this._suishitsuShikenKoumokuDT[0].TeiryoHyojiyo2.Trim()
                //Ver1.02 Start
                || (keiryoshomeiHakkoFlgCheckBox.Checked == true && this._suishitsuShikenKoumokuDT[0].KeiryoshomeiHakkoFlg != "1")
                || (keiryoshomeiHakkoFlgCheckBox.Checked == false && this._suishitsuShikenKoumokuDT[0].KeiryoshomeiHakkoFlg == "1")
                //End
                )
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region CreateSuishitsuShikenKoumokuMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuShikenKoumokuMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  HuyTX　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable CreateSuishitsuShikenKoumokuMstInsert()
        {
            SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable suishitsuShikenKoumokuMstDT = new SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable();
            SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstRow newRow = suishitsuShikenKoumokuMstDT.NewSuishitsuShikenKoumokuMstRow();

            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string shokuinNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;


            //水質試験項目コード(1)
            // UPD 20140724 START ZynasSou
            //newRow.SuishitsuShikenKoumokuCd = suishitsuShikenKoumokuCdTextBox.Text;
            newRow.SuishitsuShikenKoumokuCd = Utility.Saiban.GetKeyRenban("SuishitsuShikenKoumokuMst", "", "", "").PadLeft(3,'0');
            // UPD 20140724 START ZynasSou

            //正式名称(2)
            newRow.SeishikiNm = seishikiNmTextBox.Text;

            //略式名称(3)
            newRow.RyakushikiNm = ryakushikiNmTextBox.Text;

            //計量方法名称（上段）(4)
            newRow.KeiryouHouhouNmUp = keiryouHouhouNmUpTextBox.Text;

            //計量方法名称（上段）(5)
            newRow.KeiryouHouhouNmDown = keiryouHouhouNmDownTextBox.Text;

            //水質試験項目料金(6)
            newRow.SuishitsuShikenKomokuAmt = Convert.ToDecimal(suishitsuShikenKomokuAmtTextBox.Text);

            //印字区分(7, 8)
            newRow.InjiKbn = (injiKbnUpRadioButton.Checked) ? "1" : "2";

            //印字順(9)
            newRow.InjiJyun = injiJyunTextBox.Text;

            //外注委託区分(10)
            newRow.GaichuItakuKbn = (gaichuItakuKbnCheckBox.Checked) ? "1" : "0";

            //小数部桁数(11)
            newRow.ShosubuKetasu = shosubuKetasuTextBox.Text;

            //有効桁数(12)
            newRow.YukoKetasu = yukoKetasuTextBox.Text;

            //単位(13)
            newRow.Unit = unitTextBox.Text.Trim();

            //ゼロ表示(14)
            newRow.ZeroHyojiKbn = (zeroHyojiKbnCheckBox.Checked) ? "1" : "2";

            //結果入力省略不可(15)
            newRow.KekkaNyuryokuShoryakuKbn = (kekkaNyuryokuShoryakuKbnCheckBox.Checked) ? "1" : "2";

            //定量下限値1(16)
            newRow.TeiryoKagenchi1 = (string.IsNullOrEmpty(teiryoKagenchi1TextBox.Text)) ? 0 : Double.Parse(teiryoKagenchi1TextBox.Text);

            //定量下限値2(17)
            newRow.TeiryoKagenchi2 = (string.IsNullOrEmpty(teiryoKagenchi2TextBox.Text)) ? 0 : Double.Parse(teiryoKagenchi2TextBox.Text);

            //定量表示用1(18)
            newRow.TeiryoHyojiyo1 = teiryoHyojiyo1TextBox.Text;

            //定量表示用2(19)
            newRow.TeiryoHyojiyo2 = teiryoHyojiyo2TextBox.Text;

            //Ver1.02 Start
            //計量証明書発行対象フラグ
            newRow.KeiryoshomeiHakkoFlg = keiryoshomeiHakkoFlgCheckBox.Checked ? "1" : "0";
            //End

            //登録日
            newRow.InsertDt = currentDateTime;

            //登録者
            newRow.InsertUser = shokuinNm;

            //登録端末
            newRow.InsertTarm = Dns.GetHostName();

            //更新日
            newRow.UpdateDt = currentDateTime;

            //更新者
            newRow.UpdateUser = shokuinNm;

            //更新端末
            newRow.UpdateTarm = Dns.GetHostName();

            // 行を挿入
            suishitsuShikenKoumokuMstDT.AddSuishitsuShikenKoumokuMstRow(newRow);

            //行の状態を設定
            newRow.AcceptChanges();

            newRow.SetAdded();

            return suishitsuShikenKoumokuMstDT;

        }
        #endregion

        #region CreateSuishitsuShikenKoumokuMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuShikenKoumokuMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  HuyTX　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable CreateSuishitsuShikenKoumokuMstUpdate(SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable suishitsuShikenKoumokuMstDT)
        {
            //水質試験項目コード(1)
            suishitsuShikenKoumokuMstDT[0].SuishitsuShikenKoumokuCd = suishitsuShikenKoumokuCdTextBox.Text;

            //正式名称(2)
            suishitsuShikenKoumokuMstDT[0].SeishikiNm = seishikiNmTextBox.Text;

            //略式名称(3)
            suishitsuShikenKoumokuMstDT[0].RyakushikiNm = ryakushikiNmTextBox.Text;

            //計量方法名称（上段）(4)
            suishitsuShikenKoumokuMstDT[0].KeiryouHouhouNmUp = keiryouHouhouNmUpTextBox.Text;

            //計量方法名称（上段）(5)
            suishitsuShikenKoumokuMstDT[0].KeiryouHouhouNmDown = keiryouHouhouNmDownTextBox.Text;

            //水質試験項目料金(6)
            suishitsuShikenKoumokuMstDT[0].SuishitsuShikenKomokuAmt = Convert.ToDecimal(suishitsuShikenKomokuAmtTextBox.Text);

            //印字区分(7, 8)
            suishitsuShikenKoumokuMstDT[0].InjiKbn = (injiKbnUpRadioButton.Checked) ? "1" : "2";

            //印字順(9)
            suishitsuShikenKoumokuMstDT[0].InjiJyun = injiJyunTextBox.Text;

            //外注委託区分(10)
            suishitsuShikenKoumokuMstDT[0].GaichuItakuKbn = (gaichuItakuKbnCheckBox.Checked) ? "1" : "0";

            //小数部桁数(11)
            suishitsuShikenKoumokuMstDT[0].ShosubuKetasu = shosubuKetasuTextBox.Text;

            //有効桁数(12)
            suishitsuShikenKoumokuMstDT[0].YukoKetasu = yukoKetasuTextBox.Text;

            //単位(13)
            suishitsuShikenKoumokuMstDT[0].Unit = unitTextBox.Text.Trim();

            //ゼロ表示(14)
            suishitsuShikenKoumokuMstDT[0].ZeroHyojiKbn = (zeroHyojiKbnCheckBox.Checked) ? "1" : "2";

            //結果入力省略不可(15)
            suishitsuShikenKoumokuMstDT[0].KekkaNyuryokuShoryakuKbn = (kekkaNyuryokuShoryakuKbnCheckBox.Checked) ? "1" : "2";

            //定量下限値1(16)
            suishitsuShikenKoumokuMstDT[0].TeiryoKagenchi1 = (string.IsNullOrEmpty(teiryoKagenchi1TextBox.Text)) ? 0 : Double.Parse(teiryoKagenchi1TextBox.Text);

            //定量下限値2(17)
            suishitsuShikenKoumokuMstDT[0].TeiryoKagenchi2 = (string.IsNullOrEmpty(teiryoKagenchi2TextBox.Text)) ? 0 : Double.Parse(teiryoKagenchi2TextBox.Text);

            //定量表示用1(18)
            suishitsuShikenKoumokuMstDT[0].TeiryoHyojiyo1 = teiryoHyojiyo1TextBox.Text;

            //定量表示用2(19)
            suishitsuShikenKoumokuMstDT[0].TeiryoHyojiyo2 = teiryoHyojiyo2TextBox.Text;

            //Ver1.02 Start
            //計量証明書発行対象フラグ
            suishitsuShikenKoumokuMstDT[0].KeiryoshomeiHakkoFlg = keiryoshomeiHakkoFlgCheckBox.Checked ? "1" : "0";
            //End

            //更新者
            suishitsuShikenKoumokuMstDT[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //更新端末
            suishitsuShikenKoumokuMstDT[0].UpdateTarm = Dns.GetHostName();

            return suishitsuShikenKoumokuMstDT;

        }
        #endregion

        #endregion
    }
    #endregion
}
