using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.MaeukekinShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MaeukekinShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// 2014/12/19  habu　  不具合対応
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MaeukekinShosaiForm : FukjBaseForm
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

        #region プロパティ(private)

        /// <summary>
        /// DateTime Today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// 端末
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// 前受照合番号１
        /// </summary>
        private string _maeukekinSyogoNo1 = string.Empty;

        /// <summary>
        /// 前受照合番号２
        /// </summary>
        private string _maeukekinSyogoNo2 = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Update mode
        /// </summary>
        private DispMode _updateMode;

        /// <summary>
        /// MaeukekinTblDataTable
        /// </summary>
        private MaeukekinTblDataSet.MaeukekinTblDataTable _dispDT;

        /// <summary>
        /// NyukinTblDataTable
        /// </summary>
        private NyukinTblDataSet.NyukinTblDataTable _nyukinTblDT;

        /// <summary>
        /// Visible Renzoku
        /// </summary>
        private bool visibleRenzoku = false;

        /// <summary>
        /// 
        /// </summary>
        private bool flg = false;

        // 20141219 habu Add
        private bool _entryDone = false;
        // 20141219 End

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MaeukekinShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MaeukekinShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MaeukekinShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="maeukekinSyogoNo1"></param>
        /// <param name="maeukekinSyogoNo2"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MaeukekinShosaiForm(string maeukekinSyogoNo1, string maeukekinSyogoNo2)
        {
            InitializeComponent();

            this._maeukekinSyogoNo1 = maeukekinSyogoNo1;
            this._maeukekinSyogoNo2 = maeukekinSyogoNo2;
        }
        #endregion

        #region イベント

        #region MaeukekinShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MaeukekinShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MaeukekinShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

                //kyoseiUriGakuTextBox.KeyPress       += new KeyPressEventHandler(NumberKeyPress);
                nyukingakuTextBox.KeyPress          += new KeyPressEventHandler(NumberKeyPress);
                zankinTextBox.KeyPress              += new KeyPressEventHandler(NumberKeyPress);
                //henkingakuTextBox.KeyPress          += new KeyPressEventHandler(NumberKeyPress);
                //nyukinDtTextBox.KeyPress            += new KeyPressEventHandler(NumberKeyPress);
                //uriageDtTextBox.KeyPress            += new KeyPressEventHandler(NumberKeyPress);
                torisageDtTextBox.KeyPress          += new KeyPressEventHandler(NumberKeyPress);
                //nyukinToriatukaiDtTextBox.KeyPress  += new KeyPressEventHandler(NumberKeyPress);
                //henkinDtTextBox.KeyPress            += new KeyPressEventHandler(NumberKeyPress);

                if (string.IsNullOrEmpty(_maeukekinSyogoNo1) && string.IsNullOrEmpty(_maeukekinSyogoNo2))
                {
                    _dispMode = DispMode.Add;
                    visibleRenzoku = true;
                }
                else
                {
                    _dispMode = DispMode.Detail;
                    visibleRenzoku = false;
                }

                DoFormLoad();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

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

        #region EntryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： EntryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void EntryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!UnitCheck()) { return; }

                if (kisaiAriRadioButton.Checked)
                {
                    if (!CheckExist())
                    {
                        return;
                    }
                }

                // update mode
                _updateMode = _dispMode;

                // display mode
                _dispMode = DispMode.Confirm;

                SetControlModeView();

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

        #region ChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_dispMode == DispMode.Detail)
                {
                    _dispMode = DispMode.Edit;
                }
                else if (_dispMode == DispMode.Edit)
                {
                    if (!UnitCheck()) { return; }

                    if (!DeleteUpdateCheck())
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "既に処理されているため、変更・削除できません。");
                        return;
                    }

                    // update mode = EDIT
                    _updateMode = _dispMode;

                    // display mode
                    _dispMode = DispMode.Confirm;
                }

                SetControlModeView();
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

        #region DeleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DeleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DeleteUpdateCheck())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "既に処理されているため、変更・削除できません。");
                    return;
                }

                // データを削除する際に、警告を表示する。
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？")
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                    alInput.MaeukekinSyogoNo1 = _maeukekinSyogoNo1;
                    alInput.MaeukekinSyogoNo2 = _maeukekinSyogoNo2;
                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    if (alOutput.Result)
                    {
                        //MaeukekinListForm form = new MaeukekinListForm();
                        //Program.mForm.ShowForm(form);
                        this.DialogResult = DialogResult.OK;
                        Program.mForm.MovePrev();
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error,
                            string.Format("該当するデータは登録されていません。[前受金No：{0}]",
                            new string[] { _maeukekinSyogoNo1 + "-" + _maeukekinSyogoNo2 }));
                    }
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

        #region ReInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ReInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ReInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_updateMode == DispMode.Add)
                {
                    _dispMode = DispMode.Add;
                }
                else if (_updateMode == DispMode.Edit)
                {
                    _dispMode = DispMode.Edit;
                }

                SetControlModeView();
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

        #region DecisionButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DecisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DecisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoUpdate();

                // 20141219 habu Add
                _entryDone = true;
                // 20141219 End
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

        #region CloseButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CloseButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_dispMode != DispMode.Detail)
                {
                    if (!CheckEdit())
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                                == System.Windows.Forms.DialogResult.Yes)
                        {
                            // 一度でも登録された場合、完了後に一覧側でリロードを行う
                            if (_entryDone) { DialogResult = DialogResult.OK; }

                            Program.mForm.MovePrev();
                            Program.mForm.SetMenuEnabled(true);
                        }
                    }
                    else
                    {
                        if (_entryDone) { DialogResult = DialogResult.OK; }

                        Program.mForm.MovePrev();
                        Program.mForm.SetMenuEnabled(true);
                    }
                }
                else
                {
                    if (_entryDone) { DialogResult = DialogResult.OK; }

                    Program.mForm.MovePrev();
                    Program.mForm.SetMenuEnabled(true);
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

        #region kisaiAriRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kisaiAriRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kisaiAriRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kisaiAriRadioButton.Checked)
                {
                    maeukeNoTextBox.Enabled = true;
                }
                else
                {
                    maeukeNoTextBox.Enabled = false;
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

        #region MaeukekinShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MaeukekinShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MaeukekinShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
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

                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        henkinButton.Focus();
                        henkinButton.PerformClick();
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

        #region NumberKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NumberKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NumberKeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
                {
                    e.Handled = true;
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

        #region nyukinDtDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinDtDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nyukinDtDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                nyukinToriatukaiDtDateTimePicker.Value = nyukinDtDateTimePicker.Value;
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

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();
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

        #region henkinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void henkinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckEdit())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                            != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (_nyukinTblDT != null && _nyukinTblDT.Count > 0)
                {
                    string nyukinNo = _nyukinTblDT[0].NyukinNo;

                    IHenkinBtnClickALInput alInput = new HenkinBtnClickALInput();
                    alInput.NyukinNo = nyukinNo;
                    IHenkinBtnClickALOutput alOutput = new HenkinBtnClickApplicationLogic().Execute(alInput);

                    if (alOutput.IsExist)
                    {
                        HenkinShosaiForm frm = new HenkinShosaiForm(nyukinNo);
                        Program.mForm.MoveNext(frm, FormEnd);
                    }
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

        #region kyoseiUriCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyoseiUriCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyoseiUriCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_dispMode == DispMode.Edit && flg)
                {
                    return;
                }

                if (kyoseiUriCheckBox.Checked)
                {
                    uriageDtDateTimePicker.Enabled = true;
                }
                else
                {
                    uriageDtDateTimePicker.Enabled = false;
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
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.MaeukekinSyogoNo1   = _maeukekinSyogoNo1;
            alInput.MaeukekinSyogoNo2   = _maeukekinSyogoNo2;
            //alInput.NameKbn             = Utility.Constants.NameKbnConstant.NAME_KBN_006;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            //Utility.Utility.SetComboBoxList(kinyuNmComboBox, alOutput.NameMstDT, "NAME", "NAMECD", true);
            Utility.Utility.SetComboBoxList(kinyuNmComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_002), "ConstValue", "ConstRenban", true);

            if (alOutput.MaeukekinTblDT != null && alOutput.MaeukekinTblDT.Count > 0)
            {
                _dispDT = alOutput.MaeukekinTblDT;

                _nyukinTblDT = alOutput.NyukinTblDT;
            }

            SetControlModeView();

            SetValues();

            // 前受金No
            maeukeNoTextBox.Enabled = true;
        }
        #endregion

        #region SetValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.03
        /// 2015/01/19  HuyTX   Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues()
        {
            if (_dispDT != null && _dispDT.Count > 0)
            {
                MaeukekinTblDataSet.MaeukekinTblRow row = _dispDT[0];

                if (row.MaeukekinSyogoNo1 == "0")
                {
                    // 振込用紙記載No
                    kisaiAriRadioButton.Checked = true;
                }
                else if (row.MaeukekinSyogoNo1 == "1")
                {
                    // 自動採番
                    kisaiNashiRadioButton.Checked = true;
                }

                // 振込用紙記載No
                maeukeNoTextBox.Text = row.MaeukekinSyogoNo2;

                // 金融機関
                if (!row.IsMaeukekinKinyukikanNull())
                {
                    kinyuNmComboBox.SelectedValue = row.MaeukekinKinyukikan.ToString();
                }

                // 入金日
                //nyukinDtTextBox.Text = row.MaeukekinNyukinDt;
                if (!row.IsMaeukekinNyukinDtNull() && !string.IsNullOrEmpty(row.MaeukekinNyukinDt))
                {
                    nyukinDtDateTimePicker.Value = new DateTime(Convert.ToInt32(row.MaeukekinNyukinDt.Substring(0, 4)),
                                                                Convert.ToInt32(row.MaeukekinNyukinDt.Substring(4, 2)),
                                                                Convert.ToInt32(row.MaeukekinNyukinDt.Substring(6, 2)));

                }

                // 入金取扱日付
                if (!row.IsMaeukekinNyukintoriatukaiDtNull() && !string.IsNullOrEmpty(row.MaeukekinNyukintoriatukaiDt))
                {
                    nyukinToriatukaiDtDateTimePicker.Value = new DateTime(Convert.ToInt32(row.MaeukekinNyukintoriatukaiDt.Substring(0, 4)),
                                                                            Convert.ToInt32(row.MaeukekinNyukintoriatukaiDt.Substring(4, 2)),
                                                                            Convert.ToInt32(row.MaeukekinNyukintoriatukaiDt.Substring(6, 2)));
                }
                
                // 入金額
                //20150119 HuyTX Mod Start
                nyukingakuTextBox.Text = row.MaeukekinNyukinAmt.ToString("N0");
                nyukingakuTextBox.Text = !row.IsMaeukekinNyukinAmtNull() ? row.MaeukekinNyukinAmt.ToString("N0") : string.Empty;
                //End

                // 振込人
                furikomiNmTextBox.Text = row.MaeukekinFurikomininNm;

                // 振込人カナ
                furikomiKanaTextBox.Text = row.MaeukekinFurikomininKana;

                // 備考
                bikoTextBox.Text = row.MaeukekinBiko;

                // 売上日付
                //uriageDtTextBox.Text = row.MaeukekinUriageDt;
                if (!row.IsMaeukekinUriageDtNull() && !string.IsNullOrEmpty(row.MaeukekinUriageDt))
                {
                    uriageDtDateTimePicker.Value = new DateTime(Convert.ToInt32(row.MaeukekinUriageDt.Substring(0, 4)),
                                                                Convert.ToInt32(row.MaeukekinUriageDt.Substring(4, 2)),
                                                                Convert.ToInt32(row.MaeukekinUriageDt.Substring(6, 2)));
                }

                // 取下日付
                torisageDtTextBox.Text = row.MaeukekinTorisageDt;

                //// 検査依頼法定区分
                //hoteiKbnTextBox.Text = row.MaeukekinKensaIraiHoteiKbn;

                //// 検査依頼保健所コード
                //hokenjoCdTextBox.Text = row.MaeukekinKensaIraiHokenjoCd;

                //// 検査依頼年度
                //iraiNendoTextBox.Text = row.MaeukekinKensaIraiNendo;

                //// 検査依頼連番
                //iraiRenbanTextBox.Text = row.MaeukekinKensaIraiRenban;

                //// 強制売上金額
                //kyoseiUriGakuTextBox.Text = row.MaeukekinKyoseiUriageAmt.ToString("N0");

                // 強制売上フラグ
                if (row.MaeukekinKyoseiUriageFlg == "1")
                {
                    kyoseiUriCheckBox.Checked = true;
                }
                else if (row.MaeukekinKyoseiUriageFlg == "0")
                {
                    kyoseiUriCheckBox.Checked = false;
                }

                // 入金取扱日付
                //nyukinToriatukaiDtTextBox.Text = row.MaeukekinNyukintoriatukaiDt;

                //// 一部返金日
                //henkinDtTextBox.Text = row.MaeukekinIchibuHenkinDt;

                //// 一部返金額
                //henkingakuTextBox.Text = row.MaeukekinIchibuHenkinAmt.ToString("N0");

                // 残金
                //20150119 HuyTX Mod Start
                //zankinTextBox.Text = row.MaeukekinZanAmt.ToString("N0");
                zankinTextBox.Text = !row.IsMaeukekinZanAmtNull() ? row.MaeukekinZanAmt.ToString("N0") : string.Empty;
                //End

                // 前回返金日
                oldHenkinDtTextBox.Text = row.IsMaeukekinIchibuHenkinDtNull() ? string.Empty : row.MaeukekinIchibuHenkinDt;

                // 前回返金額
                oldHenkingakuTextBox.Text = row.IsMaeukekinIchibuHenkinAmtNull() ? string.Empty : row.MaeukekinIchibuHenkinAmt.ToString("N0");

                // 返金日
                torisageDtTextBox.Text = row.IsMaeukekinTorisageDtNull() ? string.Empty : row.MaeukekinTorisageDt;

                //// 浄化槽台帳保健所コード
                //daichoHokenjoTextBox.Text = row.IsMaeukekinJokasoHokenjoCdNull() ? string.Empty : row.MaeukekinJokasoHokenjoCd;

                //// 浄化槽台帳登録年月
                //daichoNendoTextBox.Text = row.IsMaeukekinJokasoTorokuNendoNull() ? string.Empty : row.MaeukekinJokasoTorokuNendo;

                //// 浄化槽台帳連番
                //daichoRenbanTextBox.Text = row.IsMaeukekinJokasoRenbanNull() ? string.Empty : row.MaeukekinJokasoRenban;

                StringBuilder check = new StringBuilder();

                if (!row.IsMaeukekinKensaIraiHoteiKbnNull())
                {
                    if (!string.IsNullOrEmpty(row.MaeukekinKensaIraiHoteiKbn))
                    {
                        flg = true;
                    }
                }

                if (!row.IsMaeukekinKensaIraiHokenjoCdNull())
                {
                    if (!string.IsNullOrEmpty(row.MaeukekinKensaIraiHokenjoCd))
                    {
                        flg = true;
                    }
                }

                if (!row.IsMaeukekinKensaIraiNendoNull())
                {
                    if (!string.IsNullOrEmpty(row.MaeukekinKensaIraiNendo))
                    {
                        flg = true;
                    }
                }

                if (!row.IsMaeukekinKensaIraiRenbanNull())
                {
                    if (!string.IsNullOrEmpty(row.MaeukekinKensaIraiRenban))
                    {
                        flg = true;
                    }
                }

                if (flg)
                {
                    // 依頼連像済ラベル
                    IraiRendoLbl.Visible = true;

                    // 強制売上フラグ
                    kyoseiUriCheckBox.Enabled = false;

                    // 売上日付
                    uriageDtDateTimePicker.Enabled = false;
                }
                else
                {
                    // 依頼連像済ラベル
                    IraiRendoLbl.Visible = false;

                    // 売上日付
                    uriageDtDateTimePicker.Enabled = false;
                }

                //Ver1.05 Start
                //連動検査番号1
                kensaNo1TextBox.Text = row.MaeukekinKensaIraiHokenjoCd;

                //連動検査番号2
                kensaNo2TextBox.Text = !string.IsNullOrEmpty(row.MaeukekinKensaIraiNendo) 
                                        ? Utility.DateUtility.ConvertToWareki(row.MaeukekinKensaIraiNendo + "0101", "yy") 
                                        : string.Empty;
                //連動検査番号3
                kensaNo3TextBox.Text = row.MaeukekinKensaIraiRenban;

                //浄化槽番号1
                jokasoNo1TextBox.Text = row.MaeukekinJokasoHokenjoCd;

                //浄化槽番号2
                jokasoNo2TextBox.Text = !string.IsNullOrEmpty(row.MaeukekinJokasoTorokuNendo) 
                                        ? Utility.DateUtility.ConvertToWareki(row.MaeukekinJokasoTorokuNendo + "0101", "yy")
                                        : string.Empty;
                //浄化槽番号3
                jokasoNo3TextBox.Text = row.MaeukekinJokasoRenban;

                //Ver1.05 End
            }
            else
            {
                // 振込用紙記載No
                kisaiAriRadioButton.Checked = true;

                // 依頼連像済ラベル
                IraiRendoLbl.Visible = false;

                // 2015.02.01 toyoda Modify Start
                //// 連続入力グループボックス
                //renzokuGroupBox.Visible = true;

                // 連続入力
                renzokuNyuryokuCheckBox.Visible = true;
                // 2015.02.01 toyoda Modify End

                // 売上日付
                uriageDtDateTimePicker.Enabled = false;

                // 入金日
                nyukinDtDateTimePicker.Value = today;

                // 入金取扱日付
                nyukinToriatukaiDtDateTimePicker.Value = today;

                // 売上日付
                uriageDtDateTimePicker.Value = today;
            }
        }
        #endregion

        #region SetControlModeView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlModeView
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // 前受金No区分
                    kisaiAriRadioButton.Enabled = true;
                    kisaiNashiRadioButton.Enabled = true;

                    // 前受金No
                    maeukeNoTextBox.ReadOnly = false;

                    // 金融機関
                    kinyuNmComboBox.Enabled = true;

                    // 入金日
                    nyukinDtDateTimePicker.Enabled = true;

                    // 入金額
                    nyukingakuTextBox.ReadOnly = false;

                    // 振込人名
                    furikomiNmTextBox.ReadOnly = false;

                    // 振込人カナ
                    furikomiKanaTextBox.ReadOnly = false;

                    // 備考
                    bikoTextBox.ReadOnly = false;

                    // 売上日付
                    uriageDtDateTimePicker.Enabled = kyoseiUriCheckBox.Checked;

                    // 取下日付
                    torisageDtTextBox.ReadOnly = false;
                    // 強制売上
                    kyoseiUriCheckBox.Enabled = true;

                    // 入金取扱日
                    nyukinToriatukaiDtDateTimePicker.Enabled = true;

                    // 2015.02.01 toyoda Modify Start
                    //// 連続入力
                    //renzokuRadionButton.Enabled = true;

                    //// 確定後閉じる
                    //kakuteiRadioButton.Enabled = true;

                    // 連続入力
                    renzokuNyuryokuCheckBox.Enabled = true;
                    // 2015.02.01 toyoda Modify End

                    // 残金
                    zankinTextBox.ReadOnly = false;

                    // 登録ボタン 
                    entryButton.Visible = true;

                    // 変更ボタン 
                    changeButton.Visible = false;

                    // 削除ボタン
                    deleteButton.Visible = false;

                    // 再入力ボタン
                    reInputButton.Visible = false;

                    // 確定ボタン
                    decisionButton.Visible = false;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    // クリアボタン
                    clearButton.Visible = true;

                    // 返金処理ボタン
                    henkinButton.Visible = false;

                    // 2015.02.01 toyoda Modify Start
                    //renzokuGroupBox.Visible = true;

                    renzokuNyuryokuCheckBox.Visible = true;
                    // 2015.02.01 toyoda Modify End

                    this.Text = "前受金登録";
                    Program.mForm.Text = "前受金登録";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:

                    // 前受金No区分
                    kisaiAriRadioButton.Enabled = false;
                    kisaiNashiRadioButton.Enabled = false;

                    // 前受金No
                    maeukeNoTextBox.ReadOnly = true;

                    // 金融機関
                    kinyuNmComboBox.Enabled = true;

                    // 入金日
                    //nyukinDtTextBox.ReadOnly = false;
                    nyukinDtDateTimePicker.Enabled = true;

                    // 入金額
                    nyukingakuTextBox.ReadOnly = false;

                    // 振込人名
                    furikomiNmTextBox.ReadOnly = false;

                    // 振込人カナ
                    furikomiKanaTextBox.ReadOnly = false;

                    // 備考
                    bikoTextBox.ReadOnly = false;

                    // 売上日付
                    if (flg)
                    {
                        uriageDtDateTimePicker.Enabled = true;
                    }
                    else
                    {
                        uriageDtDateTimePicker.Enabled = kyoseiUriCheckBox.Checked;
                    }

                    // 取下日付
                    torisageDtTextBox.ReadOnly = false;
                    
                    // 強制売上
                    kyoseiUriCheckBox.Enabled = true;

                    // 入金取扱日
                    nyukinToriatukaiDtDateTimePicker.Enabled = true;
                    
                    // 残金
                    zankinTextBox.ReadOnly = false;

                    // 2015.02.01 toyoda Modify Start
                    //// 連続入力
                    //renzokuRadionButton.Enabled = true;

                    //// 確定後閉じる
                    //kakuteiRadioButton.Enabled = true;

                    // 連続入力
                    renzokuNyuryokuCheckBox.Enabled = true;
                    // 2015.02.01 toyoda Modify End

                    // 登録ボタン 
                    entryButton.Visible = false;

                    // 変更ボタン 
                    changeButton.Visible = true;

                    // 削除ボタン
                    deleteButton.Visible = false;

                    // 再入力ボタン
                    reInputButton.Visible = false;

                    // 確定ボタン
                    decisionButton.Visible = false;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    // クリアボタン
                    clearButton.Visible = false;

                    // 返金処理ボタン
                    henkinButton.Visible = true;

                    // 2015.02.01 toyoda Modify Start
                    //renzokuGroupBox.Visible = false;

                    renzokuNyuryokuCheckBox.Visible = false;
                    // 2015.02.01 toyoda Modify End

                    this.Text = "前受金変更";
                    Program.mForm.Text = "前受金変更";
                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // 前受金No区分
                    kisaiAriRadioButton.Enabled = false;
                    kisaiNashiRadioButton.Enabled = false;

                    // 前受金No
                    maeukeNoTextBox.ReadOnly = true;

                    // 金融機関
                    kinyuNmComboBox.Enabled = false;

                    // 入金日
                    nyukinDtDateTimePicker.Enabled = false;

                    // 入金額
                    nyukingakuTextBox.ReadOnly = true;

                    // 振込人名
                    furikomiNmTextBox.ReadOnly = true;

                    // 振込人カナ
                    furikomiKanaTextBox.ReadOnly = true;

                    // 備考
                    bikoTextBox.ReadOnly = true;

                    // 売上日付
                    uriageDtDateTimePicker.Enabled = false;

                    // 取下日付
                    torisageDtTextBox.ReadOnly = true;
                    
                    // 強制売上
                    kyoseiUriCheckBox.Enabled = false;

                    // 入金取扱日
                    nyukinToriatukaiDtDateTimePicker.Enabled = false;
                    
                    // 残金
                    zankinTextBox.ReadOnly = true;

                    // 2015.02.01 toyoda Modify Start
                    //// 連続入力
                    //renzokuRadionButton.Enabled = false;

                    //// 確定後閉じる
                    //kakuteiRadioButton.Enabled = false;

                    // 連続入力
                    renzokuNyuryokuCheckBox.Enabled = false;
                    // 2015.02.01 toyoda Modify End

                    // 登録ボタン 
                    entryButton.Visible = false;

                    // 変更ボタン 
                    changeButton.Visible = true;

                    // 削除ボタン
                    deleteButton.Visible = true;

                    // 再入力ボタン
                    reInputButton.Visible = false;

                    // 確定ボタン
                    decisionButton.Visible = false;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    // クリアボタン
                    clearButton.Visible = false;

                    // 返金処理ボタン
                    henkinButton.Visible = false;

                    // 返金処理ボタン
                    henkinButton.Visible = true;

                    // 2015.02.01 toyoda Modify Start
                    //renzokuGroupBox.Visible = false;

                    renzokuNyuryokuCheckBox.Visible = false;
                    // 2015.02.01 toyoda Modify End

                    this.Text = "前受金詳細";
                    Program.mForm.Text = "前受金詳細";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // 前受金No区分
                    kisaiAriRadioButton.Enabled = false;
                    kisaiNashiRadioButton.Enabled = false;

                    // 前受金No
                    maeukeNoTextBox.ReadOnly = true;

                    // 金融機関
                    kinyuNmComboBox.Enabled = false;

                    // 入金日
                    nyukinDtDateTimePicker.Enabled = false;

                    // 入金額
                    nyukingakuTextBox.ReadOnly = true;

                    // 振込人名
                    furikomiNmTextBox.ReadOnly = true;

                    // 振込人カナ
                    furikomiKanaTextBox.ReadOnly = true;

                    // 備考
                    bikoTextBox.ReadOnly = true;

                    // 売上日付
                    uriageDtDateTimePicker.Enabled = false;

                    // 取下日付
                    torisageDtTextBox.ReadOnly = true;
                    
                    // 強制売上
                    kyoseiUriCheckBox.Enabled = false;

                    // 入金取扱日
                    nyukinToriatukaiDtDateTimePicker.Enabled = false;

                    // 残金
                    zankinTextBox.ReadOnly = true;

                    // 2015.02.01 toyoda Modify Start
                    //// 連続入力
                    //renzokuRadionButton.Enabled = false;

                    //// 確定後閉じる
                    //kakuteiRadioButton.Enabled = false;

                    // 連続入力
                    renzokuNyuryokuCheckBox.Enabled = false;
                    // 2015.02.01 toyoda Modify End

                    // 登録ボタン
                    entryButton.Visible = false;

                    // 変更ボタン
                    changeButton.Visible = false;

                    // 削除ボタン
                    deleteButton.Visible = false;

                    // 再入力ボタン 
                    reInputButton.Visible = true;

                    // 確定ボタン　
                    decisionButton.Visible = true;

                    // 閉じるボタン 
                    closeButton.Visible = true;

                    // クリアボタン
                    clearButton.Visible = false;

                    // 返金処理ボタン
                    henkinButton.Visible = false;
                    
                    // 2015.02.01 toyoda Modify Start
                    //renzokuGroupBox.Visible = visibleRenzoku;

                    renzokuNyuryokuCheckBox.Visible = visibleRenzoku;
                    // 2015.02.01 toyoda Modify End

                    if (_updateMode == DispMode.Add)
                    {
                        this.Text = "前受金確認";
                        Program.mForm.Text = "前受金確認";
                    }
                    else
                    {
                        this.Text = "前受金入力確認";
                        Program.mForm.Text = "前受金入力確認";
                    }


                    Program.mForm.SetMenuEnabled(true);

                    break;

                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
            }
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            MaeukekinTblDataSet.MaeukekinTblDataTable updateDT = new MaeukekinTblDataSet.MaeukekinTblDataTable();

            NyukinTblDataSet.NyukinTblDataTable nyukinDT = new NyukinTblDataSet.NyukinTblDataTable();

            if (_updateMode == DispMode.Add)
            {
                DateTime now = Common.Common.GetCurrentTimestamp();

                string nendo = Utility.DateUtility.GetNendo(now).ToString();

                string maeukekinSyogoNo2 = string.Concat(nendo.Substring(2, 2), 
                                                            Utility.Saiban.GetSaibanRenban(nendo, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_03));

                // [自動採番チェック]
                if (kisaiNashiRadioButton.Checked)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, string.Format("自動採番されました[前受金No：{0}]", maeukekinSyogoNo2));
                }

                updateDT = CreateDataInsert(now, maeukekinSyogoNo2);

                nyukinDT = CreateNyukinTblDTInsert(updateDT, now);
            }
            else
            {
                updateDT = CreateDataUpdate(_dispDT);

                nyukinDT = _nyukinTblDT;
            }

            IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();
            alInput.DispMode = _updateMode;
            alInput.MaeukekinTblDT = updateDT;
            alInput.NyukinTblDataTable = nyukinDT;
            IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

            if (!string.IsNullOrEmpty(alOutput.ErrMessage))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                return;
            }

            //MessageForm.Show2(MessageForm.DispModeType.Infomation, string.Format("既に登録済みです。[前受金No：{0}]", updateDT[0].MaeukekinSyogoNo2));

            if (_updateMode == DispMode.Add)
            {
                // 2015.02.01 toyoda Modify Start
                //if (renzokuRadionButton.Checked)
                //{
                //    // 振込用紙記載No
                //    kisaiAriRadioButton.Checked = true;

                //    // 前受金No
                //    maeukeNoTextBox.Clear();

                //    // 入金額
                //    nyukingakuTextBox.Clear();

                //    // 備考
                //    bikoTextBox.Clear();

                //    // 強制売上フラグ
                //    kyoseiUriCheckBox.Checked = false;

                //    // 売上日付
                //    uriageDtDateTimePicker.Value = today;

                //    // 返金日
                //    torisageDtTextBox.Clear();

                //    _dispMode = DispMode.Add;

                //    SetControlModeView();
                //}
                //else
                //{
                //    this.DialogResult = DialogResult.OK;
                //    Program.mForm.MovePrev();
                //}
                if (renzokuNyuryokuCheckBox.Checked)
                {
                    // 振込用紙記載No
                    kisaiAriRadioButton.Checked = true;

                    // 前受金No
                    maeukeNoTextBox.Clear();
                    
                    _dispMode = DispMode.Add;

                    SetControlModeView();
                }
                else
                {

                    // 振込用紙記載No
                    kisaiAriRadioButton.Checked = true;

                    // 前受金No
                    maeukeNoTextBox.Clear();

                    // 入金方法
                    kinyuNmComboBox.SelectedIndex = -1;
                    
                    // 入金額
                    nyukingakuTextBox.Clear();

                    // 振込人
                    furikomiNmTextBox.Clear();

                    // 振込人カナ
                    furikomiKanaTextBox.Clear();

                    // 備考
                    bikoTextBox.Clear();

                    // 強制売上フラグ
                    kyoseiUriCheckBox.Checked = false;

                    // 売上日付
                    uriageDtDateTimePicker.Value = today;

                    // 返金日
                    torisageDtTextBox.Clear();

                    // 前回返金日
                    oldHenkinDtTextBox.Clear();

                    // 前回返金額
                    oldHenkingakuTextBox.Clear();

                    // 残金
                    zankinTextBox.Clear();

                    _dispMode = DispMode.Add;

                    SetControlModeView();
                }
                // 2015.02.01 toyoda Modify End
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();
            }
        }
        #endregion

        #region CreateDataInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="maeukekinSyogoNo2"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private MaeukekinTblDataSet.MaeukekinTblDataTable CreateDataInsert(DateTime now, string maeukekinSyogoNo2)
        {
            MaeukekinTblDataSet.MaeukekinTblDataTable insertDT = new MaeukekinTblDataSet.MaeukekinTblDataTable();

            MaeukekinTblDataSet.MaeukekinTblRow insertRow = insertDT.NewMaeukekinTblRow();

            // 前受照合番号１
            insertRow.MaeukekinSyogoNo1 = kisaiAriRadioButton.Checked ? "0" : "1";

            // 前受照合番号２
            if (kisaiAriRadioButton.Checked)
            {
                insertRow.MaeukekinSyogoNo2 = maeukeNoTextBox.Text;
            }
            else
            {
                insertRow.MaeukekinSyogoNo2 = maeukekinSyogoNo2;
            }

            // 入金先金融機関
            if (kinyuNmComboBox.SelectedValue != null)
            {
                insertRow.MaeukekinKinyukikan = kinyuNmComboBox.SelectedValue.ToString();
            }

            // 入金日付
            insertRow.MaeukekinNyukinDt = nyukinDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 入金額
            insertRow.MaeukekinNyukinAmt = Convert.ToDecimal(nyukingakuTextBox.Text);

            // 振込人名
            insertRow.MaeukekinFurikomininNm = furikomiNmTextBox.Text.Trim();

            // 振込人名カナ
            insertRow.MaeukekinFurikomininKana = furikomiKanaTextBox.Text.Trim();

            // 備考
            insertRow.MaeukekinBiko = bikoTextBox.Text.Trim();

            // 売上日付
            insertRow.MaeukekinUriageDt = kyoseiUriCheckBox.Checked ? uriageDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 取下日付
            insertRow.MaeukekinTorisageDt = torisageDtTextBox.Text;

            // 検査依頼法定区分
            insertRow.MaeukekinKensaIraiHoteiKbn = string.Empty;

            // 検査依頼保健所コード
            insertRow.MaeukekinKensaIraiHokenjoCd = string.Empty;

            // 検査依頼年度
            insertRow.MaeukekinKensaIraiNendo = string.Empty;

            // 検査依頼連番
            insertRow.MaeukekinKensaIraiRenban = string.Empty;

            // 強制売上金額
            if (kyoseiUriCheckBox.Checked)
            {
                insertRow.MaeukekinKyoseiUriageAmt = Convert.ToDecimal(nyukingakuTextBox.Text);
            }

            // 強制売上フラグ
            insertRow.MaeukekinKyoseiUriageFlg = (kyoseiUriCheckBox.Checked) ? "1" : "0";

            // 入金取扱日付
            insertRow.MaeukekinNyukintoriatukaiDt = nyukinToriatukaiDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 一部返金日
            insertRow.MaeukekinIchibuHenkinDt = string.Empty;

            // 一部返金額
            //insertRow.MaeukekinIchibuHenkinAmt = string.Empty;

            // 残金
            insertRow.MaeukekinZanAmt = string.IsNullOrEmpty(zankinTextBox.Text) ? 0 : Convert.ToDecimal(zankinTextBox.Text);

            // 浄化槽台帳保健所コード
            insertRow.MaeukekinJokasoHokenjoCd = string.Empty;

            // 浄化槽台帳登録年月
            insertRow.MaeukekinJokasoTorokuNendo = string.Empty;

            // 浄化槽台帳連番
            insertRow.MaeukekinJokasoRenban = string.Empty;
            
            insertRow.InsertDt = now;
            insertRow.InsertTarm = pcUpdate;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = pcUpdate;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddMaeukekinTblRow(insertRow);

            // 行の状態を設定
            insertRow.AcceptChanges();

            // 行の状態を設定（新規）
            insertRow.SetAdded();

            return insertDT;
        }
        #endregion

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private MaeukekinTblDataSet.MaeukekinTblDataTable CreateDataUpdate(
            MaeukekinTblDataSet.MaeukekinTblDataTable dataTable)
        {
            // 入金先金融機関
            dataTable[0].MaeukekinKinyukikan = kinyuNmComboBox.SelectedValue.ToString();

            // 入金日付
            dataTable[0].MaeukekinNyukinDt = nyukinDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 入金額
            dataTable[0].MaeukekinNyukinAmt = Convert.ToDecimal(nyukingakuTextBox.Text);

            // 振込人名
            dataTable[0].MaeukekinFurikomininNm = furikomiNmTextBox.Text.Trim();

            // 振込人名カナ
            dataTable[0].MaeukekinFurikomininKana = furikomiKanaTextBox.Text.Trim();

            // 備考
            dataTable[0].MaeukekinBiko = bikoTextBox.Text.Trim();

            // 売上日付
            dataTable[0].MaeukekinUriageDt = uriageDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 入金取扱日付
            dataTable[0].MaeukekinNyukintoriatukaiDt = nyukinToriatukaiDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 取下日付
            dataTable[0].MaeukekinTorisageDt = torisageDtTextBox.Text;

            //// 検査依頼法定区分
            //dataTable[0].MaeukekinKensaIraiHoteiKbn = hoteiKbnTextBox.Text;

            //// 検査依頼保健所コード
            //dataTable[0].MaeukekinKensaIraiHokenjoCd = hokenjoCdTextBox.Text;

            //// 検査依頼年度
            //dataTable[0].MaeukekinKensaIraiNendo = iraiNendoTextBox.Text;

            //// 検査依頼連番
            //dataTable[0].MaeukekinKensaIraiRenban = iraiRenbanTextBox.Text;

            //// 強制売上金額
            //dataTable[0].MaeukekinKyoseiUriageAmt = Convert.ToDecimal(kyoseiUriGakuTextBox.Text);

            // 強制売上フラグ
            dataTable[0].MaeukekinKyoseiUriageFlg = (kyoseiUriCheckBox.Checked) ? "1" : "0";

            // 入金取扱日付
            //dataTable[0].MaeukekinNyukintoriatukaiDt = nyukinToriatukaiDtTextBox.Text;

            //// 一部返金日
            //dataTable[0].MaeukekinIchibuHenkinDt = henkinDtTextBox.Text;

            //// 一部返金額
            //dataTable[0].MaeukekinIchibuHenkinAmt = Convert.ToDecimal(henkingakuTextBox.Text);

            // 残金
            dataTable[0].MaeukekinZanAmt = Convert.ToDecimal(zankinTextBox.Text);

            return dataTable;
        }
        #endregion

        #region UnitCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UnitCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // 前受金No 
            if (kisaiAriRadioButton.Checked && !string.IsNullOrEmpty(maeukeNoTextBox.Text) && maeukeNoTextBox.Text.Length != 6)
            {
                errMess.Append("前受金は6桁で入力して下さい。\r\n");
            }

            if (kisaiAriRadioButton.Checked && string.IsNullOrEmpty(maeukeNoTextBox.Text))
            {
                errMess.Append("振込用紙記載Noを入力してくだいさい。\r\n");
            }
            
            // 金融機関
            if (kinyuNmComboBox.SelectedIndex == 0 || kinyuNmComboBox.SelectedIndex == -1)
            {
                errMess.Append("必須項目：金融機関が選択されていません。\r\n");
            }

            // 入金日
            //if (string.IsNullOrEmpty(nyukinDtTextBox.Text))
            //{
            //    errMess.Append("必須項目：入金日が入力されていません。\r\n");
            //}
            //else
            //{
            //    if (nyukinDtTextBox.Text.Length != 8)
            //    {
            //        errMess.Append("入金日は8桁で入力して下さい。\r\n");
            //    }
            //}

            // 入金額
            if (string.IsNullOrEmpty(nyukingakuTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：入金額が入力されていません。\r\n");
            }

            // 振込人名
            if (string.IsNullOrEmpty(furikomiNmTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：振込人が入力されていません。\r\n");
            }
            else
            {
                if (furikomiNmTextBox.Text.Trim().Length > 20)
                {
                    errMess.Append("振込人名は20文字以下で入力して下さい。\r\n");
                }
            }

            // 振込人名カナ
            if (string.IsNullOrEmpty(furikomiKanaTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：振込人カナが入力されていません。\r\n");
            }
            else
            {
                if (furikomiKanaTextBox.Text.Trim().Length > 20)
                {
                    errMess.Append("振込人名カナは20文字以下で入力して下さい。\r\n");
                }
            }

            // 備考
            if (bikoTextBox.Text.Trim().Length > 40)
            {
                errMess.Append("備考は40文字以下で入力して下さい。\r\n");
            }

            // 売上日付
            //if (!string.IsNullOrEmpty(uriageDtTextBox.Text) && uriageDtTextBox.Text.Length != 8)
            //{
            //    errMess.Append("売上日付は8桁で入力して下さい。\r\n");
            //}

            // 取下日付
            if (!string.IsNullOrEmpty(torisageDtTextBox.Text) && torisageDtTextBox.Text.Length != 8)
            {
                errMess.Append("取下日付は8桁で入力して下さい。\r\n");
            }

            //// 強制売上
            //if (kyoseiUriCheckBox.Checked && string.IsNullOrEmpty(kyoseiUriGakuTextBox.Text))
            //{
            //    errMess.Append("必須項目：強制売上金額が入力されていません。");
            //}

            // 入金取扱日付
            //if (!string.IsNullOrEmpty(nyukinToriatukaiDtTextBox.Text) && nyukinToriatukaiDtTextBox.Text.Length != 8)
            //{
            //    errMess.Append("入金取扱日付は8桁で入力して下さい。\r\n");
            //}

            //// 一部返金日
            //if (!string.IsNullOrEmpty(henkinDtTextBox.Text) && henkinDtTextBox.Text.Length != 8)
            //{
            //    errMess.Append("一部返金日は8桁で入力して下さい。\r\n");
            //}

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region CheckEdit
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckEdit
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            //check edit mode add
            if (string.IsNullOrEmpty(_maeukekinSyogoNo1) && string.IsNullOrEmpty(_maeukekinSyogoNo2))
            {
                if (maeukeNoTextBox.Text != string.Empty
                    || kinyuNmComboBox.SelectedIndex != 0
                    || nyukinDtDateTimePicker.Value != today
                    || nyukinToriatukaiDtDateTimePicker.Value != today
                    || nyukingakuTextBox.Text != string.Empty
                    || furikomiNmTextBox.Text != string.Empty
                    || furikomiKanaTextBox.Text != string.Empty
                    || bikoTextBox.Text != string.Empty
                    || kyoseiUriCheckBox.Checked != false
                    || torisageDtTextBox.Text != string.Empty
                    || zankinTextBox.Text != string.Empty
                    )
                {
                    return false;
                }
            }

            if (_dispDT != null && _dispDT.Count > 0)
            {
                if (maeukeNoTextBox.Text != _dispDT[0].MaeukekinSyogoNo2
                        || kinyuNmComboBox.SelectedValue.ToString() != _dispDT[0].MaeukekinKinyukikan
                        || nyukinDtDateTimePicker.Value.ToString("yyyyMMdd") != _dispDT[0].MaeukekinNyukinDt
                        || nyukinToriatukaiDtDateTimePicker.Value.ToString("yyyyMMdd") != _dispDT[0].MaeukekinNyukintoriatukaiDt
                        || (Convert.ToDecimal(nyukingakuTextBox.Text) != _dispDT[0].MaeukekinNyukinAmt)
                        || furikomiNmTextBox.Text != _dispDT[0].MaeukekinFurikomininNm
                        || furikomiKanaTextBox.Text != _dispDT[0].MaeukekinFurikomininKana
                        || bikoTextBox.Text != _dispDT[0].MaeukekinBiko
                        || (kyoseiUriCheckBox.Checked && _dispDT[0].MaeukekinKyoseiUriageFlg == "0")
                        || (!kyoseiUriCheckBox.Checked && _dispDT[0].MaeukekinKyoseiUriageFlg == "1")
                        || torisageDtTextBox.Text != _dispDT[0].MaeukekinTorisageDt
                        || (Convert.ToDecimal(zankinTextBox.Text) != _dispDT[0].MaeukekinZanAmt)
                    )
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region DeleteUpdateCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DeleteUpdateCheck()
        {
            //// 検査依頼法定区分
            //if (!string.IsNullOrEmpty(hoteiKbnTextBox.Text.Trim()))
            //{
            //    return false;
            //}

            //// 検査依頼保健所コード
            //if (!string.IsNullOrEmpty(hokenjoCdTextBox.Text.Trim()))
            //{
            //    return false;
            //}

            //// 検査依頼年度
            //if (!string.IsNullOrEmpty(iraiNendoTextBox.Text.Trim()))
            //{
            //    return false;
            //}

            //// 検査依頼連番
            //if (!string.IsNullOrEmpty(iraiRenbanTextBox.Text.Trim()))
            //{
            //    return false;
            //}

            //// 浄化槽台帳保健所コード
            //if (!string.IsNullOrEmpty(daichoHokenjoTextBox.Text.Trim()))
            //{
            //    return false;
            //}

            //// 浄化槽台帳登録年月
            //if (!string.IsNullOrEmpty(daichoNendoTextBox.Text.Trim()))
            //{
            //    return false;
            //}

            //// 浄化槽台帳連番
            //if (!string.IsNullOrEmpty(daichoRenbanTextBox.Text.Trim()))
            //{
            //    return false;
            //}

            return true;
        }
        #endregion

        #region CheckExist
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckExist
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckExist()
        {
            IEntryBtnClickBLInput alInput   = new EntryBtnClickBLInput();
            alInput.MaeukekinSyogoNo1       = "0";
            alInput.MaeukekinSyogoNo2       = maeukeNoTextBox.Text;
            IEntryBtnClickBLOutput alOutput = new EntryBtnClickBusinessLogic().Execute(alInput);

            if (!alOutput.Result)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("既に登録済みです。[前受金No：{0}-{1}]",
                                    new string[] { alInput.MaeukekinSyogoNo1, alInput.MaeukekinSyogoNo2 }));
                return false;
            }

            return true;
        }
        #endregion

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 振込用紙記載No
            kisaiAriRadioButton.Checked = true;

            // 前受金No
            maeukeNoTextBox.Clear();

            // 入金方法
            kinyuNmComboBox.SelectedIndex = -1;

            // 入金日
            nyukinDtDateTimePicker.Value = today;

            // 入金取扱日付
            nyukinToriatukaiDtDateTimePicker.Value = today;

            // 入金額
            nyukingakuTextBox.Clear();

            // 振込人
            furikomiNmTextBox.Clear();

            // 振込人カナ
            furikomiKanaTextBox.Clear();

            // 備考
            bikoTextBox.Clear();

            // 強制売上フラグ
            kyoseiUriCheckBox.Checked = false;

            // 売上日付
            uriageDtDateTimePicker.Value = today;

            // 返金日
            torisageDtTextBox.Clear();

            // 前回返金日
            oldHenkinDtTextBox.Clear();

            // 前回返金額
            oldHenkingakuTextBox.Clear();

            // 残金
            zankinTextBox.Clear();
        }
        #endregion

        #region CreateNyukinTblDTInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblDTInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NyukinTblDataSet.NyukinTblDataTable CreateNyukinTblDTInsert(
            MaeukekinTblDataSet.MaeukekinTblDataTable dataTable,
            DateTime now)
        {
            NyukinTblDataSet.NyukinTblDataTable insertDT = new NyukinTblDataSet.NyukinTblDataTable();

            NyukinTblDataSet.NyukinTblRow insertRow = insertDT.NewNyukinTblRow();

            // 入金No
            insertRow.NyukinNo = Utility.Saiban.GetSaibanNendo(now.ToString("yyyyMMdd"), Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_07);

            // 支所コード
            insertRow.NyukinShisyoCd = "0";

            // 入金日
            insertRow.NyukinDt = nyukinDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 入金取扱日
            insertRow.NyukinToriatukaiDt = nyukinToriatukaiDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 入金種別
            insertRow.NyukinSyubetsu = "2";

            // 連携No
            insertRow.NyukinRenkeiNo = dataTable[0].MaeukekinSyogoNo1 + dataTable[0].MaeukekinSyogoNo2;

            // 計量証明検査依頼年度
            insertRow.KeiryoShomeiIraiNendo = string.Empty;

            // 計量証明支所コード
            insertRow.KeiryoShomeiIraiSishoCd = string.Empty;

            // 計量証明依頼連番
            insertRow.KeiryoShomeiIraiRenban = string.Empty;

            // 検査依頼法定区分
            insertRow.KensaIraiHoteiKbn = string.Empty;

            // 検査依頼保健所コード
            insertRow.KensaIraiHokenjoCd = string.Empty;

            // 検査依頼年度
            insertRow.KensaIraiNendo = string.Empty;

            // 検査依頼連番
            insertRow.KensaIraiRenban = string.Empty;

            // 入金方法
            insertRow.NyukinHoho = kinyuNmComboBox.SelectedValue.ToString();

            // 入金口座
            insertRow.NyukinKoza = string.Empty;

            // 請求額
            insertRow.SeikyuGaku = Convert.ToDecimal(nyukingakuTextBox.Text);

            // 入金入力額
            insertRow.NyukinGaku = Convert.ToDecimal(nyukingakuTextBox.Text);

            // 手数料
            //insertRow.TesuryoGaku = string.Empty;

            // 手数料内外区分
            insertRow.TesuryoNaigaiKbn = string.Empty;

            // 実入金額
            insertRow.JitsuNyukinGaku = Convert.ToDecimal(nyukingakuTextBox.Text);

            // 入金元区分
            insertRow.NyukinmotoKbn = string.Empty;

            // 業者コード
            insertRow.NyukinGyosyaCd = string.Empty;

            // 浄化槽保健所コード
            insertRow.JokasoHokenjoCd = string.Empty;

            // 浄化槽台帳登録年度
            insertRow.JokasoTorokuNendo = string.Empty;

            // 浄化槽台帳連番
            insertRow.JokasoRenban = string.Empty;

            // 入金者名称
            insertRow.NyukinsyaNm = furikomiNmTextBox.Text;

            // 割振り済フラグ
            //2015.01.06 mod kiyokuni
            //insertRow.WarifuriFlg = "0";
            insertRow.WarifuriFlg = "1";

            // 割振り済金額
            insertRow.WarifuriGaku = Convert.ToDecimal(nyukingakuTextBox.Text);

            // 返金額合計
            insertRow.HenkinGaku = 0;

            // 完済フラグ
            insertRow.KansaiFlag = "0";

            // 次回繰り越し金
            insertRow.JikaiKurikoshiKin = 0;

            // 繰り越し金
            insertRow.KurikoshiKin = 0;

            insertRow.InsertDt = now;
            insertRow.InsertTarm = pcUpdate;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = pcUpdate;
            insertRow.UpdateUser = loginUser;


            insertDT.AddNyukinTblRow(insertRow);
            insertRow.AcceptChanges();
            insertRow.SetAdded();

            return insertDT;
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
        /// 2014/12/02  DatNT   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 前受金No
            maeukeNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // 入金額
            nyukingakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 9);

            // 振込人
            furikomiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);

            //// 振込人カナ
            furikomiKanaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME_KANA_HALF_BOTH, 20);

            // 備考
            bikoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
        }
        #endregion

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
            // 子画面が正常終了した場合
            if (childForm.DialogResult == DialogResult.OK)
            {
                DoFormLoad();
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
