using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.ChikuMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChikuMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ChikuMstShosaiForm : FukjBaseForm
    {
        #region 定義(public)

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
        }
        #endregion

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// displayMode
        /// </summary>
        public DispMode _displayMode = DispMode.Add;

        #endregion

        #region プロパティ(private)
        /// <summary>
        /// chikuCd
        /// </summary>
        private string _chikuCd = string.Empty;

        /// <summary>
        /// displayDT
        /// </summary>
        private ChikuMstDataSet.ChikuMstDataTable _displayDT = new ChikuMstDataSet.ChikuMstDataTable();

        /// <summary>
        /// isLoadForm
        /// </summary>
        private bool _isLoadForm = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ChikuMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ChikuMstShosaiForm()
            : base()
        {
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ChikuMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ChikuMstShosaiForm(string chikuCd)
            : base()
        {
            this._chikuCd = chikuCd;
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region イベント

        #region ChikuMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ChikuMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChikuMstShosaiForm_Load(object sender, EventArgs e)
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
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(DataCheck()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, DataCheck());
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
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._displayMode == DispMode.Detail)
                {
                    this._displayMode = DispMode.Edit;
                }
                else if (this._displayMode == DispMode.Edit)
                {
                    if (!string.IsNullOrEmpty(DataCheck()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, DataCheck());
                        return;
                    }
                    this._displayMode = DispMode.Confirm;
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
        /// 2014/06/25　HuyTX　　    新規作成
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
                    alInput.ChikuMstCd = chikuCdTextBox.Text;

                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    //check ChikuCd not exist 
                    if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                        return;
                    }

                    //close form and redirect ChikuMstListForm
                    //ChikuMstListForm frm = new ChikuMstListForm();
                    //Program.mForm.ShowForm(frm);
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
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(this._chikuCd))
                {
                    this._displayMode = DispMode.Add;
                }
                else
                {
                    this._displayMode = DispMode.Edit;
                }

                //set display control
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
        /// 2014/06/25　HuyTX　　    新規作成
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

                if (string.IsNullOrEmpty(this._chikuCd))
                {
                    alInput.DisplayMode = DispMode.Add;
                    alInput.ChikuMstDT = CreateChikuMstInsert();
                }
                else
                {
                    alInput.DisplayMode = DispMode.Edit;
                    alInput.ChikuMstDT = CreateChikuMstUpdate(this._displayDT);
                }

                IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                    return;
                }

                //ChikuMstListForm frm = new ChikuMstListForm();
                //Program.mForm.ShowForm(frm);
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
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ChikuMstListForm frm = new ChikuMstListForm();

                if (this._displayMode != DispMode.Detail && CheckEditControl())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // Enable menu
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

        #region kankatsuHokenjoCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kankatsuHokenjoCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kankatsuHokenjoCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                kankatsuHokenjoNmComboBox.SelectedValue = kankatsuHokenjoCdTextBox.Text;
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

        #region kankatsuHokenjoNmComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kankatsuHokenjoNmComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kankatsuHokenjoNmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (kankatsuHokenjoNmComboBox.SelectedIndex <= 0)
                {
                    kankatsuHokenjoCdTextBox.Text = string.Empty;
                    return;
                }
                if (this._isLoadForm)
                {
                    kankatsuHokenjoCdTextBox.Text = kankatsuHokenjoNmComboBox.SelectedValue.ToString();
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

        #region ChikuMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ChikuMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChikuMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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

        #region gaikanChikuwariCdTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gaikanChikuwariCdTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gaikanChikuwariCdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex("[A-E\b]");
            if (!regex.Match(e.KeyChar.ToString()).Success)
            {
                e.Handled = true;
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
        /// 2014/06/25　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ChikuMstCd = this._chikuCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            this._displayDT = alOutput.ChikuMstDT;

            // Set default Hokenjo combobox 
            Utility.Utility.SetComboBoxList(kankatsuHokenjoNmComboBox, alOutput.HokenjoMstDT, "HokenjoNm", "HokenjoCd", true);

            // Set default HoteiTantoShisho combobox 
            Utility.Utility.SetComboBoxList(hoteiTantoShishoNmComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);

            // Set default suishitsuTantoShisho combobox 
            Utility.Utility.SetComboBoxList(suishitsuTantoShishoNmComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);

            this.Text = "地区マスタ登録";

            if (!string.IsNullOrEmpty(this._chikuCd))
            {
                this._displayMode = DispMode.Detail;
                this.Text = "地区マスタ詳細";

                SetDefaultValueControl();
            }

            this._isLoadForm = true;
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
        /// 2014/06/25　HuyTX    新規作成
        /// 2015/01/23　HuyTX    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            chikuCdTextBox.ReadOnly = (this._displayMode == DispMode.Add) ? false : true;
            chikuNmTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuRyakushoTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            kankatsuHokenjoCdTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            kankatsuHokenjoNmComboBox.Enabled = !(this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            hoteiTantoShishoNmComboBox.Enabled = !(this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            suishitsuTantoShishoNmComboBox.Enabled = !(this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            gaikanChikuwariCdTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            gaikanChikuwari2CdTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            gappeigoChikuCdTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            //Ver1.01 Start
            chikuTantoKaTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuTantoYubinNoTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuTantoAdrTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuTantoTelNoTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuTantoFaxTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuHyojunChi7JoTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuHyojunChi11JoTandokuTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            chikuHyojunChi11JoGappeiTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            delFlgCheckBox.Enabled = !(this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            //End

            //登録ボタン (14)
            entryButton.Visible = (this._displayMode == DispMode.Add) ? true : false;

            //変更ボタン (15)
            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            //削除ボタン (16)
            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            //再入力ボタン (17) 
            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //確定ボタン (18) 
            decisionButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //change screen title
            SetFormTitle();
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
        /// 2014/06/25　HuyTX    新規作成
        /// 2015/01/23　HuyTX    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            if (this._displayDT.Count > 0)
            {
                chikuCdTextBox.Text = this._displayDT[0].ChikuCd;
                chikuNmTextBox.Text = this._displayDT[0].ChikuNm;
                chikuRyakushoTextBox.Text = this._displayDT[0].ChikuRyakusho;
                kankatsuHokenjoCdTextBox.Text = this._displayDT[0].KankatsuHokenjoCd;
                kankatsuHokenjoNmComboBox.SelectedValue = this._displayDT[0].KankatsuHokenjoCd;
                hoteiTantoShishoNmComboBox.SelectedValue = this._displayDT[0].HoteiTantoShishoCd;
                suishitsuTantoShishoNmComboBox.SelectedValue = this._displayDT[0].SuishitsuTantoShishoCd;
                gaikanChikuwariCdTextBox.Text = this._displayDT[0].GaikanChikuwariCd;
                gaikanChikuwari2CdTextBox.Text = this._displayDT[0].GaikanChikuwari2Cd;
                gappeigoChikuCdTextBox.Text = this._displayDT[0].GappeigoChikuCd;
                //Ver1.01 Start
                chikuTantoKaTextBox.Text = this._displayDT[0].ChikuTantoKa;
                chikuTantoYubinNoTextBox.Text = this._displayDT[0].ChikuTantoYubinNo;
                chikuTantoAdrTextBox.Text = this._displayDT[0].ChikuTantoAdr;
                chikuTantoTelNoTextBox.Text = this._displayDT[0].ChikuTantoTelNo;
                chikuTantoFaxTextBox.Text = this._displayDT[0].ChikuTantoFax;
                chikuHyojunChi7JoTextBox.Text = Convert.ToString(this._displayDT[0].ChikuHyojunChi7Jo);
                chikuHyojunChi11JoTandokuTextBox.Text = Convert.ToString(this._displayDT[0].ChikuHyojunChi11JoTandoku);
                chikuHyojunChi11JoGappeiTextBox.Text = Convert.ToString(this._displayDT[0].ChikuHyojunChi11JoGappei);
                delFlgCheckBox.Checked = this._displayDT[0].DelFlg == "1" ? true : false;
                //End
            }
        }
        #endregion

        #region SetFormTitle
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetFormTitle
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetFormTitle()
        {
            switch (this._displayMode)
            {
                case DispMode.Add:
                    Program.mForm.Text = "地区マスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "地区マスタ変更";
                    Program.mForm.SetMenuEnabled(false);
                    break;
                case DispMode.Detail:
                    Program.mForm.Text = "地区マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "地区マスタ入力確認";
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
        /// 2014/06/25　HuyTX    新規作成
        /// 2015/01/23　HuyTX    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();
            Regex regex = new Regex("[A-E]");

            //地区コード(2)
            if (String.IsNullOrEmpty(chikuCdTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：地区コードが入力されていません。");
            }
            else if (chikuCdTextBox.Text.Length != 5)
            {
                errMsg.AppendLine("地区コードは5桁で入力して下さい。");
            }

            //地区名称(3)
            if (String.IsNullOrEmpty(chikuNmTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：地区名称が入力されていません。");
            }
            else if (chikuNmTextBox.Text.Length > 20)
            {
                errMsg.AppendLine("地区名称は20文字以下で入力して下さい。");
            }

            //地区略称(4)
            if (String.IsNullOrEmpty(chikuRyakushoTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：地区略称が入力されていません。");
            }
            else if (chikuRyakushoTextBox.Text.Length > 10)
            {
                errMsg.AppendLine("地区略称は10文字以下で入力して下さい。");
            }

            //管轄保健所コード(5)
            if (String.IsNullOrEmpty(kankatsuHokenjoCdTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：管轄保健所コードが入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(kankatsuHokenjoCdTextBox.Text.Trim()))
                {
                    errMsg.AppendLine("管轄保健所コードは半角数字で入力して下さい。");
                }
                else if (kankatsuHokenjoCdTextBox.Text.Length != 2)
                {
                    errMsg.AppendLine("管轄保健所コードは2桁で入力して下さい。");
                }
            }

            //管轄保健所名称(6)
            if (kankatsuHokenjoNmComboBox.SelectedIndex <= 0)
            {
                errMsg.AppendLine("必須項目：管轄保健所名称が選択されていません。");
            }

            //法定担当支所名称(8)
            if (hoteiTantoShishoNmComboBox.SelectedIndex <= 0)
            {
                errMsg.AppendLine("必須項目：法定担当支所名称が選択されていません。");
            }

            //水質担当支所名称(10)
            if (suishitsuTantoShishoNmComboBox.SelectedIndex <= 0)
            {
                errMsg.AppendLine("必須項目：水質担当支所名称が選択されていません。");
            }

            ////外観地区割(11)
            //if (String.IsNullOrEmpty(gaikanChikuwariCdTextBox.Text.Trim()))
            //{
            //    errMsg.AppendLine("必須項目：外観地区割が入力されていません。");
            //}
            //else
            //{
            //    if (gaikanChikuwariCdTextBox.TextLength > 1)
            //    {
            //        errMsg.AppendLine("外観地区割は1桁で入力して下さい。");
            //    }
            //    else if (!regex.Match(gaikanChikuwariCdTextBox.Text).Success)
            //    {
            //        errMsg.AppendLine("外観地区割は半角英字（A～E)で入力して下さい。");
            //    }
            //}
            //外観地区割(11)
            if (String.IsNullOrEmpty(gaikanChikuwariCdTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：外観地区割が入力されていません。");
            }
            else
            {
                if (gaikanChikuwariCdTextBox.Text.Trim().Length > 1)
                {
                    errMsg.AppendLine("外観地区割は1桁で入力して下さい。");
                }
                else if (!regex.Match(gaikanChikuwariCdTextBox.Text).Success)
                {
                    errMsg.AppendLine("外観地区割は半角英字（A～E)で入力して下さい。");
                }
            }
            //外観地区割Ⅱ(12)
            if (!String.IsNullOrEmpty(gaikanChikuwari2CdTextBox.Text.Trim()))
            {
                if (gaikanChikuwari2CdTextBox.Text.Trim().Length > 1)
                {
                    errMsg.AppendLine("外観地区割Ⅱは1桁で入力して下さい。");
                }
                else if (!regex.Match(gaikanChikuwari2CdTextBox.Text).Success)
                {
                    errMsg.AppendLine("外観地区割Ⅱは半角英字（A～E)で入力して下さい。");
                }
            }

            //合併後地区コード(13)
            if (String.IsNullOrEmpty(gappeigoChikuCdTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：合併後地区コードが入力されていません。");
            }
            else if (gappeigoChikuCdTextBox.Text.Length != 5)
            {
                errMsg.AppendLine("合併後地区コードは5桁で入力して下さい。");
            }

            //Ver1.01 Start
            //担当郵便番号
            if (!string.IsNullOrEmpty(chikuTantoYubinNoTextBox.Text) && !Utility.Utility.IsNumAndNegative(chikuTantoYubinNoTextBox.Text))
            {
                errMsg.AppendLine("担当郵便番号は半角数字と-(半角ハイフン)で入力して下さい。");
            }

            //担当電話番号
            if (!string.IsNullOrEmpty(chikuTantoTelNoTextBox.Text) && !Utility.Utility.IsNumAndNegative(chikuTantoTelNoTextBox.Text))
            {
                errMsg.AppendLine("担当電話番号は半角数字と-(半角ハイフン)で入力して下さい。");
            }

            //担当FAX番号
            if (!string.IsNullOrEmpty(chikuTantoFaxTextBox.Text) && !Utility.Utility.IsNumAndNegative(chikuTantoFaxTextBox.Text))
            {
                errMsg.AppendLine("担当FAX番号は半角数字と-(半角ハイフン)で入力して下さい。");
            }

            //End

            return errMsg.ToString();
        }
        #endregion

        #region CheckEditControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckEditControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  HuyTX　　    新規作成
        /// 2015/01/23  HuyTX　　    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEditControl()
        {
            //check edit default value mode Add
            if (string.IsNullOrEmpty(this._chikuCd))
            {
                if (!string.IsNullOrEmpty(chikuCdTextBox.Text)
                    || !string.IsNullOrEmpty(chikuNmTextBox.Text)
                    || !string.IsNullOrEmpty(chikuRyakushoTextBox.Text)
                    || !string.IsNullOrEmpty(kankatsuHokenjoCdTextBox.Text)
                    || kankatsuHokenjoNmComboBox.SelectedIndex > 0
                    || hoteiTantoShishoNmComboBox.SelectedIndex > 0
                    || suishitsuTantoShishoNmComboBox.SelectedIndex > 0
                    || !string.IsNullOrEmpty(gaikanChikuwariCdTextBox.Text)
                    || !string.IsNullOrEmpty(gaikanChikuwari2CdTextBox.Text)
                    || !string.IsNullOrEmpty(gappeigoChikuCdTextBox.Text)
                    //Ver1.01 Start
                    || !string.IsNullOrEmpty(chikuTantoKaTextBox.Text)
                    || !string.IsNullOrEmpty(chikuTantoYubinNoTextBox.Text)
                    || !string.IsNullOrEmpty(chikuTantoAdrTextBox.Text)
                    || !string.IsNullOrEmpty(chikuTantoTelNoTextBox.Text)
                    || !string.IsNullOrEmpty(chikuTantoFaxTextBox.Text)
                    || !string.IsNullOrEmpty(chikuHyojunChi7JoTextBox.Text)
                    || !string.IsNullOrEmpty(chikuHyojunChi11JoTandokuTextBox.Text)
                    || !string.IsNullOrEmpty(chikuHyojunChi11JoGappeiTextBox.Text)
                    || delFlgCheckBox.Checked == true
                    //End
                 )
                {
                    return true;
                }
            }
            else
            {
                if (this._displayDT.Count != 0)
                {
                    if (chikuCdTextBox.Text != this._displayDT[0].ChikuCd
                        || chikuNmTextBox.Text != this._displayDT[0].ChikuNm
                        || chikuRyakushoTextBox.Text != this._displayDT[0].ChikuRyakusho
                        || kankatsuHokenjoCdTextBox.Text != this._displayDT[0].KankatsuHokenjoCd
                        || kankatsuHokenjoNmComboBox.SelectedValue.ToString() != this._displayDT[0].KankatsuHokenjoCd
                        || hoteiTantoShishoNmComboBox.SelectedValue.ToString() != this._displayDT[0].HoteiTantoShishoCd
                        || suishitsuTantoShishoNmComboBox.SelectedValue.ToString() != this._displayDT[0].SuishitsuTantoShishoCd
                        || gaikanChikuwariCdTextBox.Text != this._displayDT[0].GaikanChikuwariCd
                        || gaikanChikuwari2CdTextBox.Text != this._displayDT[0].GaikanChikuwari2Cd
                        || gappeigoChikuCdTextBox.Text != this._displayDT[0].GappeigoChikuCd
                        //Ver1.01 Start
                        || chikuTantoKaTextBox.Text != this._displayDT[0].ChikuTantoKa
                        || chikuTantoYubinNoTextBox.Text != this._displayDT[0].ChikuTantoYubinNo
                        || chikuTantoAdrTextBox.Text != this._displayDT[0].ChikuTantoAdr
                        || chikuTantoTelNoTextBox.Text != this._displayDT[0].ChikuTantoTelNo
                        || chikuTantoFaxTextBox.Text != this._displayDT[0].ChikuTantoFax
                        || chikuHyojunChi7JoTextBox.Text != Convert.ToString(this._displayDT[0].ChikuHyojunChi7Jo)
                        || chikuHyojunChi11JoTandokuTextBox.Text != Convert.ToString(this._displayDT[0].ChikuHyojunChi11JoTandoku)
                        || chikuHyojunChi11JoGappeiTextBox.Text != Convert.ToString(this._displayDT[0].ChikuHyojunChi11JoGappei)
                        || (delFlgCheckBox.Checked && this._displayDT[0].DelFlg != "1")
                        || (!delFlgCheckBox.Checked && this._displayDT[0].DelFlg == "1")
                        //End
                        )
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region CreateChikuMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateChikuMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  HuyTX　　    新規作成
        /// 2015/01/23  HuyTX　　    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ChikuMstDataSet.ChikuMstDataTable CreateChikuMstInsert()
        {
            ChikuMstDataSet.ChikuMstDataTable chikuMstDT = new ChikuMstDataSet.ChikuMstDataTable();
            ChikuMstDataSet.ChikuMstRow newRow = chikuMstDT.NewChikuMstRow();

            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string shokuinNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //地区コード(2)
            newRow.ChikuCd = chikuCdTextBox.Text;

            //地区名称 (3)
            newRow.ChikuNm = chikuNmTextBox.Text;

            //地区略称 (4)
            newRow.ChikuRyakusho = chikuRyakushoTextBox.Text;

            //管轄保健所コード (5)
            newRow.KankatsuHokenjoCd = kankatsuHokenjoCdTextBox.Text;

            //法定担当支所名称 (8)
            newRow.HoteiTantoShishoCd = hoteiTantoShishoNmComboBox.SelectedValue.ToString();

            //水質担当支所名称 (10)
            newRow.SuishitsuTantoShishoCd = suishitsuTantoShishoNmComboBox.SelectedValue.ToString();

            //外観地区割 (11)
            newRow.GaikanChikuwariCd = gaikanChikuwariCdTextBox.Text;

            //外観地区割Ⅱ(12)
            newRow.GaikanChikuwari2Cd = string.IsNullOrEmpty(gaikanChikuwari2CdTextBox.Text.Trim()) ? " " : gaikanChikuwari2CdTextBox.Text.Trim();

            //合併後地区コード (13)
            newRow.GappeigoChikuCd = gappeigoChikuCdTextBox.Text;

            //Ver1.01 Mod Start
            //// 20141018 HotFix
            //newRow.ChikuTantoKa = string.Empty;
            //newRow.ChikuTantoYubinNo = string.Empty;
            //newRow.ChikuTantoAdr = string.Empty;
            //newRow.ChikuTantoTelNo = string.Empty;
            //newRow.ChikuTantoFax = string.Empty;
            //// 20141120 HotFix
            //newRow.ChikuHyojunChi7Jo = 0;
            //newRow.ChikuHyojunChi11JoTandoku = 0;
            //newRow.ChikuHyojunChi11JoGappei = 0;

            //newRow.DelFlg = "0";

            //担当課
            newRow.ChikuTantoKa = chikuTantoKaTextBox.Text;
            //担当郵便番号
            newRow.ChikuTantoYubinNo = chikuTantoYubinNoTextBox.Text;
            //担当住所
            newRow.ChikuTantoAdr = chikuTantoAdrTextBox.Text;
            //担当電話番号
            newRow.ChikuTantoTelNo = chikuTantoTelNoTextBox.Text;
            //担当FAX
            newRow.ChikuTantoFax = chikuTantoFaxTextBox.Text;
            //標準値(7条)
            newRow.ChikuHyojunChi7Jo = !string.IsNullOrEmpty(chikuHyojunChi7JoTextBox.Text) ? Convert.ToInt32(chikuHyojunChi7JoTextBox.Text) : 0;
            //標準値(11条単独)
            newRow.ChikuHyojunChi11JoTandoku = !string.IsNullOrEmpty(chikuHyojunChi11JoTandokuTextBox.Text) ? Convert.ToInt32(chikuHyojunChi11JoTandokuTextBox.Text) : 0;
            //標準値(11条合併)
            newRow.ChikuHyojunChi11JoGappei = !string.IsNullOrEmpty(chikuHyojunChi11JoGappeiTextBox.Text) ? Convert.ToInt32(chikuHyojunChi11JoGappeiTextBox.Text) : 0;
            //削除フラグ
            newRow.DelFlg = delFlgCheckBox.Checked ? "1" : "0";
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
            chikuMstDT.AddChikuMstRow(newRow);

            //行の状態を設定
            newRow.AcceptChanges();

            newRow.SetAdded();

            return chikuMstDT;

        }
        #endregion

        #region CreateChikuMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateChikuMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chikuMstDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  HuyTX　　    新規作成
        /// 2015/01/23  HuyTX　　    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ChikuMstDataSet.ChikuMstDataTable CreateChikuMstUpdate(ChikuMstDataSet.ChikuMstDataTable chikuMstDT)
        {
            //地区コード(2)
            chikuMstDT[0].ChikuCd = chikuCdTextBox.Text;

            //地区名称 (3)
            chikuMstDT[0].ChikuNm = chikuNmTextBox.Text;

            //地区略称 (4)
            chikuMstDT[0].ChikuRyakusho = chikuRyakushoTextBox.Text;

            //管轄保健所コード (5)
            chikuMstDT[0].KankatsuHokenjoCd = kankatsuHokenjoCdTextBox.Text;

            //法定担当支所名称 (8)
            chikuMstDT[0].HoteiTantoShishoCd = hoteiTantoShishoNmComboBox.SelectedValue.ToString();

            //水質担当支所名称 (10)
            chikuMstDT[0].SuishitsuTantoShishoCd = suishitsuTantoShishoNmComboBox.SelectedValue.ToString();

            //外観地区割 (11)
            chikuMstDT[0].GaikanChikuwariCd = gaikanChikuwariCdTextBox.Text;

            //外観地区割Ⅱ(12)
            chikuMstDT[0].GaikanChikuwari2Cd = string.IsNullOrEmpty(gaikanChikuwari2CdTextBox.Text.Trim()) ? " " : gaikanChikuwari2CdTextBox.Text.Trim();

            //合併後地区コード (13)
            chikuMstDT[0].GappeigoChikuCd = gappeigoChikuCdTextBox.Text;

            //Ver1.01 Start
            //担当課
            chikuMstDT[0].ChikuTantoKa = chikuTantoKaTextBox.Text;
            //担当郵便番号
            chikuMstDT[0].ChikuTantoYubinNo = chikuTantoYubinNoTextBox.Text;
            //担当住所
            chikuMstDT[0].ChikuTantoAdr = chikuTantoAdrTextBox.Text;
            //担当電話番号
            chikuMstDT[0].ChikuTantoTelNo = chikuTantoTelNoTextBox.Text;
            //担当FAX
            chikuMstDT[0].ChikuTantoFax = chikuTantoFaxTextBox.Text;
            //標準値(7条)
            chikuMstDT[0].ChikuHyojunChi7Jo = !string.IsNullOrEmpty(chikuHyojunChi7JoTextBox.Text) ? Convert.ToInt32(chikuHyojunChi7JoTextBox.Text) : 0;
            //標準値(11条単独)
            chikuMstDT[0].ChikuHyojunChi11JoTandoku = !string.IsNullOrEmpty(chikuHyojunChi11JoTandokuTextBox.Text) ? Convert.ToInt32(chikuHyojunChi11JoTandokuTextBox.Text) : 0;
            //標準値(11条合併)
            chikuMstDT[0].ChikuHyojunChi11JoGappei = !string.IsNullOrEmpty(chikuHyojunChi11JoGappeiTextBox.Text) ? Convert.ToInt32(chikuHyojunChi11JoGappeiTextBox.Text) : 0;
            //削除フラグ
            chikuMstDT[0].DelFlg = delFlgCheckBox.Checked ? "1" : "0";
            //End

            //更新者
            chikuMstDT[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //更新端末
            chikuMstDT[0].UpdateTarm = Dns.GetHostName();

            return chikuMstDT;

        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23  HuyTX　　  Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            //担当課
            chikuTantoKaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            //担当郵便番号
            chikuTantoYubinNoTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            //担当住所
            chikuTantoAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            //担当電話番号
            chikuTantoTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);
            //担当FAX
            chikuTantoFaxTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);
            //標準値(7条)
            chikuHyojunChi7JoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
            //標準値(11条単独)
            chikuHyojunChi11JoTandokuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
            //標準値(11条合併)
            chikuHyojunChi11JoGappeiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
        }
        #endregion

        #endregion
    }
    #endregion
}
