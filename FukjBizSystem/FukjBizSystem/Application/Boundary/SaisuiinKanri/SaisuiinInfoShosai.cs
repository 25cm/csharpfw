using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.SaisuiinInfoShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiinInfoShosaiForm : FukjBaseForm
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
        /// 表示モード
        /// </summary>
        public DispMode _dispMode = DispMode.Add;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Form load completed?
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 採水員コード
        /// </summary>
        private string _saisuiinCd = string.Empty;

        /// <summary>
        /// SaisuiinInfoShosaiDataTable
        /// </summary>
        private SaisuiinMstDataSet.SaisuiinInfoShosaiDataTable _dispTable = new SaisuiinMstDataSet.SaisuiinInfoShosaiDataTable();

        /// <summary>
        /// 採水員マスタ
        /// </summary>
        private SaisuiinMstDataSet.SaisuiinMstDataTable _saisuiinMstDT = new SaisuiinMstDataSet.SaisuiinMstDataTable();

        /// <summary>
        /// 郵便番号住所マスタ
        /// </summary>
        private YubinNoAdrMstDataSet.YubinNoAdrMstDataTable _yubinNoAdrMstDT = new YubinNoAdrMstDataSet.YubinNoAdrMstDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaisuiinInfoShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiinInfoShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaisuiinInfoShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="saisuiinCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiinInfoShosaiForm(string saisuiinCd)
        {
            this._saisuiinCd = saisuiinCd;
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SaisuiinInfoShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinInfoShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinInfoShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Add mode title
                this.Text = "採水員情報登録";

                // Detail mode
                if (!string.IsNullOrEmpty(this._saisuiinCd))
                {
                    this._dispMode = DispMode.Detail;
                    this.Text = "採水員情報詳細";
                }

                // Load and display default value
                DoFormLoad();

                // Title of screen
                SetScreenTitle();

                // Display/Input control
                ItemControl();

                // Form load completed!
                _isLoad = true;
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

        #region SaisuiinInfoShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinInfoShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinInfoShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック + 入力内容チェック
                if (!DataCheck()) return;

                // Switches to confirm mode
                this._dispMode = DispMode.Confirm;

                // Set screen title
                SetScreenTitle();

                // Set input/read only property
                ItemControl();
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
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._dispMode == DispMode.Detail)
                {
                    // Switches to confirm mode
                    this._dispMode = DispMode.Edit;
                }
                else if (this._dispMode == DispMode.Edit)
                {
                    // 単項目チェック + 入力内容チェック
                    if (!DataCheck()) return;

                    // Switches to confirm mode
                    this._dispMode = DispMode.Confirm;
                }

                // Set screen title
                SetScreenTitle();

                // Set input/read only property
                ItemControl();
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
        /// 2014/07/29　AnhNV　　    新規作成
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
                    IDeleteBtnClickALInput delInput = new DeleteBtnClickALInput();
                    delInput.SaisuiinCd = saisuiinCdTextBox.Text;
                    IDeleteBtnClickALOutput delOutput = new DeleteBtnClickApplicationLogic().Execute(delInput);

                    // SaisuiinCd does not exist
                    if (!string.IsNullOrEmpty(delOutput.ErrMsg))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, delOutput.ErrMsg);
                        return;
                    }

                    // Close this screen and back to SaisuiinMst form
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
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._dispMode = string.IsNullOrEmpty(this._saisuiinCd) ? DispMode.Add : DispMode.Edit;

                // Screen title
                SetScreenTitle();

                // Item control display
                ItemControl();
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
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._dispMode = string.IsNullOrEmpty(this._saisuiinCd) ? DispMode.Add : DispMode.Edit;

                IDecisionBtnClickALInput decInput = new DecisionBtnClickALInput();
                decInput.DispMode = this._dispMode;
                decInput.SaisuiinMstDataTable = (this._dispMode == DispMode.Add) ? CreateSaisuiinMstInsert() : CreateSaisuiinMstUpdate(_saisuiinMstDT);
                IDecisionBtnClickALOutput decOutput = new DecisionBtnClickApplicationLogic().Execute(decInput);

                // Edit mode
                if (!string.IsNullOrEmpty(decOutput.ErrMsg))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, decOutput.ErrMsg);
                    return;
                }

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
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Detail mode
                if (this._dispMode == DispMode.Detail)
                {
                    goto SHOWFORM;
                }

                // Add mode
                if (string.IsNullOrEmpty(_saisuiinCd))
                {
                    if (!EditControl() || MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        goto SHOWFORM;
                    }

                    return;
                }

                // Other modes
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        goto SHOWFORM;
                    }

                    return;
                }

                SHOWFORM:
                //SaisuiinInfoListForm frm = new SaisuiinInfoListForm();
                //Program.mForm.ShowForm(frm);
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

        #region shozokuGyosyaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shozokuGyosyaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shozokuGyosyaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open 000-003 GyoshaSearch
                Common.GyoshaMstSearchForm frm = new Common.GyoshaMstSearchForm();
                frm.ShowDialog();

                // Avoid user close the form
                if (frm.DialogResult != DialogResult.OK) return;

                // No row was selected
                if (frm._selectedRow == null) return;

                // 所属業者コード(4)
                syozokuGyosyaCdTextBox.Text = frm._selectedRow.GyoshaCd;

                // 所属業者名(2)
                syozokuGyosyaNmTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region addressSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： addressSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void addressSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                YubinJusyoMstSearchForm form = new YubinJusyoMstSearchForm();
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 採水員郵便番号(7)
                saisuiinZipCdTextBox.Text = form._selectedRow.ZipCd;

                // 採水員住所(9)
                saisuiinAdrTextBox.Text = string.Concat(
                    form._selectedRow.TodofukenNm,
                    form._selectedRow.ShikuchosonNm,
                    form._selectedRow.ChoikiNm);
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

        #region syutokuDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syutokuDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syutokuDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Enable/Disable 採水員取得日(15)
                saisuiinSyutokuDtDateTimePicker.Enabled = syutokuDtAddFlgCheckBox.Checked;
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

        #region yukokigenAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yukokigenAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yukokigenAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Enable/Disable 採水員有効期限(18)
                saisuiinYukokigenDtDateTimePicker.Enabled = yukokigenAddFlgCheckBox.Checked;
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

        #region zenkaiJyukoDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zenkaiJyukoDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zenkaiJyukoDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Enable/Disable 前回受講日(20)
                zenkaiJukoDtDateTimePicker.Enabled = zenkaiJyukoDtAddFlgCheckBox.Checked;
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

        #region chancelDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chancelDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chancelDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Enable/Disable 採水員取消日(22)
                saisuiinTorikeshiDtDateTimePicker.Enabled = chancelDtAddFlgCheckBox.Checked;
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

        #region saisuiinZipCdTextBox_TextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinZipCdTextBox_TextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinZipCdTextBox_TextChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Form load incompleted
                if (!_isLoad) return;

                // Set address text for 採水員住所(9)
                TextBoxTextChanged(saisuiinZipCdTextBox, saisuiinAdrTextBox);
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

        #region saisuiinTelNoTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinTelNoTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinTelNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '-')
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

        #region saisuiinZipCdTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinZipCdTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinZipCdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '-')
                {
                    e.Handled = true;
                }

                // only allow one negative sign
                if (e.KeyChar == '-'
                    && (sender as TextBox).Text.IndexOf('-') > -1)
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
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SaisuiinCd = _saisuiinCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Common
            this._yubinNoAdrMstDT = alOutput.YubinNoAdrMstDataTable;

            if (_dispMode == DispMode.Detail)
            {
                this._dispTable = alOutput.SaisuiinInfoShosaiDataTable;
                this._saisuiinMstDT = alOutput.SaisuiinMstDataTable;

                // Default values
                DisplayDefault();
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
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoUpdate()
        {
            return true;
        }
        #endregion

        #region DisplayDefault
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDefault
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault()
        {
            // System date
            DateTime now = Common.Common.GetCurrentTimestamp();

            // 採水員コード(1)
            saisuiinCdTextBox.Text = _saisuiinCd;

            // 業者名称(2)
            syozokuGyosyaNmTextBox.Text = _dispTable[0].GyoshaNm;

            // 所属業者コード(4)
            syozokuGyosyaCdTextBox.Text = _dispTable[0].SyozokuGyosyaCd;

            // 採水員名(5)
            saisuiinNmTextBox.Text = _dispTable[0].SaisuiinNm;

            // 採水員名かな(6)
            saisuiinKanaTextBox.Text = _dispTable[0].SaisuiinKana;

            // 採水員郵便番号(7)
            saisuiinZipCdTextBox.Text = _dispTable[0].SaisuiinZipCd;

            // 採水員住所(9)
            saisuiinAdrTextBox.Text = _dispTable[0].SaisuiinAdr;

            // 採水員電話番号(10)
            saisuiinTelNoTextBox.Text = _dispTable[0].SaisuiinTelNo;

            // 採水員生年月日(11)
            saisuiinSeinegappiDateTimePicker.Value = _dispTable[0].IsSaisuiinSeinegappiNull() ? now : Convert.ToDateTime(_dispTable[0].SaisuiinSeinegappi);

            // 管理士No(12)
            kanrishiNoTextBox.Text = _dispTable[0].KanrishiNo;

            // 管理士取得日(13)
            kanrishiSyutokuDtDateTimePicker.Value = _dispTable[0].IsKanrishiSyutokuDtNull() ? now : Convert.ToDateTime(_dispTable[0].KanrishiSyutokuDt);

            // 取得日追加フラグ(14)
            syutokuDtAddFlgCheckBox.Checked = string.IsNullOrEmpty(_dispTable[0].SaisuiinSyutokuDt.Trim()) ? false : true;

            // 採水員取得日(15)
            saisuiinSyutokuDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].SaisuiinSyutokuDt.Trim()) ? now : Convert.ToDateTime(_dispTable[0].SaisuiinSyutokuDt);

            // 受講日(16)
            jukoDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].JukoDt.Trim()) ? now : Convert.ToDateTime(_dispTable[0].JukoDt);

            // 有効期限追加フラグ(17)
            yukokigenAddFlgCheckBox.Checked = string.IsNullOrEmpty(_dispTable[0].SaisuiinYukokigenDt.Trim()) ? false : true;

            // 採水員有効期限(18)
            saisuiinYukokigenDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].SaisuiinYukokigenDt.Trim()) ? now : Convert.ToDateTime(_dispTable[0].SaisuiinYukokigenDt);

            // 前回受講日追加フラグ(19)
            zenkaiJyukoDtAddFlgCheckBox.Checked = string.IsNullOrEmpty(_dispTable[0].ZenkaiJukoDt.Trim()) ? false : true;

            // 前回受講日(20)
            zenkaiJukoDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].ZenkaiJukoDt.Trim()) ? now : Convert.ToDateTime(_dispTable[0].ZenkaiJukoDt);

            // 取消日追加フラグ(21)
            chancelDtAddFlgCheckBox.Checked = string.IsNullOrEmpty(_dispTable[0].SaisuiinTorikeshiDt.Trim()) ? false : true;

            // 採水員取消日(22)
            saisuiinTorikeshiDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].SaisuiinTorikeshiDt.Trim()) ? now : Convert.ToDateTime(_dispTable[0].SaisuiinTorikeshiDt);
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
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (_dispMode)
            {
                case DispMode.Detail:
                    Program.mForm.Text = "採水員情報詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Add:
                    Program.mForm.Text = "採水員情報登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "採水員情報入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "採水員情報変更";
                    Program.mForm.SetMenuEnabled(false);
                    break;
                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
            }
        }
        #endregion

        #region ItemControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ItemControl
        /// <summary>
        /// Control the input/display property of all items
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemControl()
        {
            // 採水員コード(1)
            //saisuiinCdTextBox.ReadOnly = _dispMode == DispMode.Add ? false : true;

            // 業者名称(2)
            //syozokuGyosyaNmTextBox.ReadOnly = 

            // 採水員名(5)
            saisuiinNmTextBox.ReadOnly =

            // 採水員名かな(6)
            saisuiinKanaTextBox.ReadOnly =

            // 採水員郵便番号(7)
            saisuiinZipCdTextBox.ReadOnly = 

            // 採水員住所(9)
            saisuiinAdrTextBox.ReadOnly =

            // 採水員電話番号(10)
            saisuiinTelNoTextBox.ReadOnly =

            // 管理士No(12)
            kanrishiNoTextBox.ReadOnly = _dispMode == DispMode.Add || _dispMode == DispMode.Edit ? false : true;

            // 所属業者検索ボタン(3)
            shozokuGyosyaSearchButton.Enabled = 

            // 郵便番号住所検索ボタン(8)
            addressSearchButton.Enabled =

            // 採水員生年月日(11)
            saisuiinSeinegappiDateTimePicker.Enabled =

            // 管理士取得日(13)
            kanrishiSyutokuDtDateTimePicker.Enabled =

            // 取得日追加フラグ(14)
            syutokuDtAddFlgCheckBox.Enabled = 

            // 受講日(16)
            jukoDtDateTimePicker.Enabled =

            // 有効期限追加フラグ(17)
            yukokigenAddFlgCheckBox.Enabled =

            // 前回受講日追加フラグ(19)
            zenkaiJyukoDtAddFlgCheckBox.Enabled =

            // 取消日追加フラグ(21)
            chancelDtAddFlgCheckBox.Enabled = _dispMode == DispMode.Add || _dispMode == DispMode.Edit ? true : false;

            // 採水員取得日(15)
            saisuiinSyutokuDtDateTimePicker.Enabled =  _dispMode == DispMode.Edit && syutokuDtAddFlgCheckBox.Checked ? true : false;

            // 採水員有効期限(18)
            saisuiinYukokigenDtDateTimePicker.Enabled = _dispMode == DispMode.Edit && yukokigenAddFlgCheckBox.Checked ? true : false;

            // 前回受講日(20)
            zenkaiJukoDtDateTimePicker.Enabled = _dispMode == DispMode.Edit && zenkaiJyukoDtAddFlgCheckBox.Checked ? true : false;

            // 採水員取消日(22)
            saisuiinTorikeshiDtDateTimePicker.Enabled = _dispMode == DispMode.Edit && chancelDtAddFlgCheckBox.Checked ? true : false;

            // 登録ボタン(23)
            entryButton.Visible = _dispMode == DispMode.Add ? true : false;

            // 変更ボタン(24)
            changeButton.Visible = _dispMode == DispMode.Detail || _dispMode == DispMode.Edit ? true : false;

            // 削除ボタン(25)
            deleteButton.Visible = _dispMode == DispMode.Detail ? true : false;

            // 再入力ボタン(26)
            reInputButton.Visible = 

            // 確定ボタン(27)
            decisionButton.Visible = _dispMode == DispMode.Confirm ? true : false;
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
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();

            // 採水員コード(1)
            //if (string.IsNullOrEmpty(saisuiinCdTextBox.Text.Trim()))
            //{
            //    errMsg.Append("必須項目：採水員コードが入力されていません。\r\n");
            //}
            //else if (saisuiinCdTextBox.Text.Length != 5)
            //{
            //    errMsg.Append("採水員コードは5桁で入力して下さい。\r\n");
            //}

            // 業者名称(2)
            if (string.IsNullOrEmpty(syozokuGyosyaNmTextBox.Text))
            {
                errMsg.Append("必須項目：所属業者が選択されていません。\r\n");
            }
            
            // 採水員名(5)
            if (string.IsNullOrEmpty(saisuiinNmTextBox.Text))
            {
                errMsg.Append("必須項目：採水員名が入力されていません。\r\n");
            }
            else if (saisuiinNmTextBox.Text.Length > 40)
            {
                errMsg.Append("採水員名は40文字以下で入力して下さい。\r\n");
            }

            // 採水員名かな(6)
            if (string.IsNullOrEmpty(saisuiinKanaTextBox.Text))
            {
                errMsg.Append("必須項目：採水員名カナが入力されていません。\r\n");
            }
            else if (saisuiinKanaTextBox.Text.Length > 40)
            {
                errMsg.Append("採水員名カナは40文字以下で入力して下さい。\r\n");
            }

            // 採水員郵便番号(7)
            if (string.IsNullOrEmpty(saisuiinZipCdTextBox.Text))
            {
                errMsg.Append("必須項目：郵便番号が入力されていません。\r\n");
            }
            else if (saisuiinZipCdTextBox.Text.Length != 8)
            {
                errMsg.Append("郵便番号は8桁で入力して下さい。\r\n");
            }
            //else if (!Utility.Utility.IsNumAndNegative(saisuiinZipCdTextBox.Text))
            //{
                //errMsg.Append("郵便番号は半角数字と-(半角ハイフン)で入力して下さい。\r\n");
            //}
            else if (!Utility.Utility.IsZipCode(saisuiinZipCdTextBox.Text))
            {
                errMsg.Append("郵便番号の形式が不正です。\r\n");
                //errMsg.AppendLine("郵便番号は半角数字＋\" - \"で入力して下さい。");
            }

            // 採水員住所(9)
            if (string.IsNullOrEmpty(saisuiinAdrTextBox.Text))
            {
                errMsg.Append("必須項目：住所が入力されていません。\r\n");
            }
            else if (saisuiinAdrTextBox.Text.Length > 80)
            {
                errMsg.Append("住所は80文字以下で入力して下さい。\r\n");
            }

            // 採水員電話番号(10)
            if (string.IsNullOrEmpty(saisuiinTelNoTextBox.Text))
            {
                errMsg.Append("必須項目：電話番号が入力されていません。\r\n");
            }
            else if (saisuiinTelNoTextBox.Text.Length < 12)
            {
                errMsg.Append("電話番号は12～13桁で入力して下さい。\r\n");
            }
            //else if (saisuiinTelNoTextBox.Text.Length != 13)
            //{
            //    errMsg.Append("電話番号は13桁で入力して下さい。\r\n");
            //}
            else if (!Utility.Utility.IsNumAndNegative(saisuiinTelNoTextBox.Text.Trim()))
            {
                errMsg.Append("電話番号の形式が不正です。\r\n");
            }
            //else if (!Utility.Utility.IsPhoneNumber(saisuiinTelNoTextBox.Text))
            //{
            //    //errMsg.Append("電話番号の形式が不正です。\r\n");
            //    errMsg.AppendLine("電話番号は半角数字＋\" - \"で入力して下さい。");
            //}

            // 管理士No(12)
            if (string.IsNullOrEmpty(kanrishiNoTextBox.Text))
            {
                errMsg.Append("必須項目：管理士Noが入力されていません。\r\n");
            }
            else if (kanrishiNoTextBox.Text.Length != 10)
            {
                errMsg.Append("管理士Noは10桁で入力して下さい。\r\n");
            }

            // Throw error messages
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region EditCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditCheck
        /// <summary>
        /// Trigger when any item is modified
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            // System date
            string now = Common.Common.GetCurrentTimestamp().ToString("yyyy/MM/dd");

            // 業者名称(2)
            //if (syozokuGyosyaNmTextBox.Text != _dispTable[0].GyoshaNm) return false;

            // 所属業者コード(4)
            if (syozokuGyosyaCdTextBox.Text != _dispTable[0].SyozokuGyosyaCd) return false;

            // 採水員名(5)
            if (saisuiinNmTextBox.Text != _dispTable[0].SaisuiinNm) return false;

            // 採水員名かな(6)
            if (saisuiinKanaTextBox.Text != _dispTable[0].SaisuiinKana) return false;

            // 採水員郵便番号(7)
            if (saisuiinZipCdTextBox.Text != _dispTable[0].SaisuiinZipCd) return false;

            // 採水員住所(9)
            if (saisuiinAdrTextBox.Text != _dispTable[0].SaisuiinAdr) return false;

            // 採水員電話番号(10)
            if (saisuiinTelNoTextBox.Text != _dispTable[0].SaisuiinTelNo) return false;

            // 採水員生年月日(11)
            if (saisuiinSeinegappiDateTimePicker.Value !=
                Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].SaisuiinSeinegappi.Trim()) ? now : _dispTable[0].SaisuiinSeinegappi)) return false;

            // 管理士No(12)
            if (kanrishiNoTextBox.Text != _dispTable[0].KanrishiNo) return false;

            // 管理士取得日(13)
            if (kanrishiSyutokuDtDateTimePicker.Value !=
                Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].KanrishiSyutokuDt.Trim()) ? now : _dispTable[0].KanrishiSyutokuDt)) return false;

            // 取得日追加フラグ(14)
            if (string.IsNullOrEmpty(_dispTable[0].SaisuiinSyutokuDt.Trim()) && syutokuDtAddFlgCheckBox.Checked
                || !string.IsNullOrEmpty(_dispTable[0].SaisuiinSyutokuDt.Trim()) && !syutokuDtAddFlgCheckBox.Checked) return false;

            // 採水員取得日(15)
            if (saisuiinSyutokuDtDateTimePicker.Value.Date !=
                Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].SaisuiinSyutokuDt.Trim()) ? now : _dispTable[0].SaisuiinSyutokuDt).Date) return false;

            // 受講日(16)
            if (jukoDtDateTimePicker.Value.Date !=
                Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].JukoDt.Trim()) ? now : _dispTable[0].JukoDt).Date) return false;

            // 有効期限追加フラグ(17)
            if (string.IsNullOrEmpty(_dispTable[0].SaisuiinYukokigenDt.Trim()) && yukokigenAddFlgCheckBox.Checked
                || !string.IsNullOrEmpty(_dispTable[0].SaisuiinYukokigenDt.Trim()) && !yukokigenAddFlgCheckBox.Checked) return false;

            // 採水員有効期限(18)
            if (saisuiinYukokigenDtDateTimePicker.Value.Date !=
                Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].SaisuiinYukokigenDt.Trim()) ? now : _dispTable[0].SaisuiinYukokigenDt).Date) return false;

            // 前回受講日追加フラグ(19)
            if (string.IsNullOrEmpty(_dispTable[0].ZenkaiJukoDt.Trim()) && zenkaiJyukoDtAddFlgCheckBox.Checked
                || !string.IsNullOrEmpty(_dispTable[0].ZenkaiJukoDt.Trim()) && !zenkaiJyukoDtAddFlgCheckBox.Checked) return false;

            // 前回受講日(20)
            if (zenkaiJukoDtDateTimePicker.Value.Date !=
                Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].ZenkaiJukoDt.Trim()) ? now : _dispTable[0].ZenkaiJukoDt).Date) return false;

            // 取消日追加フラグ(21)
            if (string.IsNullOrEmpty(_dispTable[0].SaisuiinTorikeshiDt.Trim()) && chancelDtAddFlgCheckBox.Checked
                || !string.IsNullOrEmpty(_dispTable[0].SaisuiinTorikeshiDt.Trim()) && !chancelDtAddFlgCheckBox.Checked) return false;

            // 採水員取消日(22)
            if (saisuiinTorikeshiDtDateTimePicker.Value.Date !=
                Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].SaisuiinTorikeshiDt.Trim()) ? now : _dispTable[0].SaisuiinTorikeshiDt).Date) return false;

            return true;
        }
        #endregion

        #region EditControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditControl
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// TRUE: Control is edited
        /// FALSE: Control is not edited
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditControl()
        {
            // System date
            DateTime now = Common.Common.GetCurrentTimestamp();

            // 所属業者コード(4)
            if (!string.IsNullOrEmpty(syozokuGyosyaCdTextBox.Text)) return true;

            // 採水員名(5)
            if (!string.IsNullOrEmpty(saisuiinNmTextBox.Text)) return true;

            // 採水員名かな(6)
            if (!string.IsNullOrEmpty(saisuiinKanaTextBox.Text)) return true;

            // 採水員郵便番号(7)
            if (!string.IsNullOrEmpty(saisuiinZipCdTextBox.Text)) return true;

            // 採水員住所(9)
            if (!string.IsNullOrEmpty(saisuiinAdrTextBox.Text)) return true;

            // 採水員電話番号(10)
            if (!string.IsNullOrEmpty(saisuiinTelNoTextBox.Text)) return true;

            // 採水員生年月日(11)
            if (saisuiinSeinegappiDateTimePicker.Value.Date != now.Date) return true;

            // 管理士No(12)
            if (!string.IsNullOrEmpty(kanrishiNoTextBox.Text)) return true;

            // 管理士取得日(13)
            if (kanrishiSyutokuDtDateTimePicker.Value.Date != now.Date) return true;

            // 取得日追加フラグ(14)
            if (syutokuDtAddFlgCheckBox.Checked) return true;

            // 採水員取得日(15)
            if (saisuiinSyutokuDtDateTimePicker.Value.Date != now.Date) return true;

            // 受講日(16)
            if (jukoDtDateTimePicker.Value.Date != now.Date) return true;

            // 有効期限追加フラグ(17)
            if (yukokigenAddFlgCheckBox.Checked) return true;

            // 採水員有効期限(18)
            if (saisuiinYukokigenDtDateTimePicker.Value.Date != now.Date) return true;

            // 前回受講日追加フラグ(19)
            if (zenkaiJyukoDtAddFlgCheckBox.Checked) return true;

            // 前回受講日(20)
            if (zenkaiJukoDtDateTimePicker.Value.Date != now.Date) return true;

            // 取消日追加フラグ(21)
            if (chancelDtAddFlgCheckBox.Checked) return true;

            // 採水員取消日(22)
            if (saisuiinTorikeshiDtDateTimePicker.Value.Date != now.Date) return true;

            // No items is edited
            return false;
        }
        #endregion

        #region TextBoxTextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： TextBoxTextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceTextBox"></param>
        /// <param name="targetTextBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TextBoxTextChanged(TextBox sourceTextBox, TextBox targetTextBox)
        {
            string todofukenNm = string.Empty;
            string shichosonNm = string.Empty;
            string choikiNm = string.Empty;

            // Select address from YubinNoAdrMstDataSet
            foreach (YubinNoAdrMstDataSet.YubinNoAdrMstRow row in _yubinNoAdrMstDT.Select(
                string.Format("ZipCd = '{0}'", sourceTextBox.Text)))
            {
                todofukenNm = row.TodofukenNm;
                shichosonNm = row.ShikuchosonNm;
                choikiNm = row.ChoikiNm;
            }

            // Set result for target textbox
            //targetTextBox.Text = Common.Common.MakeSetchishaAdr(todofukenNm, shichosonNm, choikiNm);
            targetTextBox.Text = string.Concat(todofukenNm, shichosonNm, choikiNm);
        }
        #endregion

        #region CreateSaisuiinMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaisuiinMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstDataSet.SaisuiinMstDataTable CreateSaisuiinMstInsert()
        {
            // System date
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Login user
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Host name
            string host = Dns.GetHostName();

            SaisuiinMstDataSet.SaisuiinMstDataTable table = new SaisuiinMstDataSet.SaisuiinMstDataTable();
            SaisuiinMstDataSet.SaisuiinMstRow newRow = table.NewSaisuiinMstRow();

            // 採水員コード(1)
            newRow.SaisuiinCd = Utility.Saiban.GetKeyRenban("SaisuiinMst", string.Empty, string.Empty, string.Empty).PadLeft(5, '0');

            // 採水員名
            newRow.SaisuiinNm = saisuiinNmTextBox.Text;

            // 採水員名かな
            newRow.SaisuiinKana = saisuiinKanaTextBox.Text;

            // 所属業者コード
            newRow.SyozokuGyosyaCd = syozokuGyosyaCdTextBox.Text;

            // 採水員指定No
            newRow.SaisuiinShiteiNo = newRow.SaisuiinCd;

            // 採水員取得日
            newRow.SaisuiinSyutokuDt = syutokuDtAddFlgCheckBox.Checked ? saisuiinSyutokuDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 受講日
            newRow.JukoDt = jukoDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 前回受講日
            newRow.ZenkaiJukoDt = zenkaiJyukoDtAddFlgCheckBox.Checked ? zenkaiJukoDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 採水員有効期限
            newRow.SaisuiinYukokigenDt = yukokigenAddFlgCheckBox.Checked ? saisuiinYukokigenDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 採水員郵便番号
            newRow.SaisuiinZipCd = saisuiinZipCdTextBox.Text;

            // 採水員住所
            newRow.SaisuiinAdr = saisuiinAdrTextBox.Text;

            // 採水員電話番号
            newRow.SaisuiinTelNo = saisuiinTelNoTextBox.Text;

            // 採水員生年月日
            newRow.SaisuiinSeinegappi = saisuiinSeinegappiDateTimePicker.Value.ToString("yyyyMMdd");

            // 管理士No
            newRow.KanrishiNo = kanrishiNoTextBox.Text;

            // 管理士取得日
            newRow.KanrishiSyutokuDt = kanrishiSyutokuDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 採水員取消日
            newRow.SaisuiinTorikeshiDt = chancelDtAddFlgCheckBox.Checked ? saisuiinTorikeshiDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 登録日
            newRow.InsertDt = now;

            // 登録者
            newRow.InsertUser = user;

            // 登録端末
            newRow.InsertTarm = host;

            // 更新日
            newRow.UpdateDt = now;

            // 更新者
            newRow.UpdateUser = user;

            // 更新端末
            newRow.UpdateTarm = host;

            // 行を挿入
            table.AddSaisuiinMstRow(newRow);

            // 行の状態を設定
            newRow.AcceptChanges();

            // 行の状態を設定（新規）
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateSaisuiinMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaisuiinMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstDataSet.SaisuiinMstDataTable CreateSaisuiinMstUpdate(SaisuiinMstDataSet.SaisuiinMstDataTable table)
        {
            // Login user
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Host name
            string host = Dns.GetHostName();

            // 採水員名
            table[0].SaisuiinNm = saisuiinNmTextBox.Text;

            // 採水員名かな
            table[0].SaisuiinKana = saisuiinKanaTextBox.Text;

            // 所属業者コード
            table[0].SyozokuGyosyaCd = syozokuGyosyaCdTextBox.Text;

            // 採水員取得日
            table[0].SaisuiinSyutokuDt = syutokuDtAddFlgCheckBox.Checked ? saisuiinSyutokuDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 受講日
            table[0].JukoDt = jukoDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 前回受講日
            table[0].ZenkaiJukoDt = zenkaiJyukoDtAddFlgCheckBox.Checked ? zenkaiJukoDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 採水員有効期限
            table[0].SaisuiinYukokigenDt = yukokigenAddFlgCheckBox.Checked ? saisuiinYukokigenDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 採水員郵便番号
            table[0].SaisuiinZipCd = saisuiinZipCdTextBox.Text;

            // 採水員住所
            table[0].SaisuiinAdr = saisuiinAdrTextBox.Text;

            // 採水員電話番号
            table[0].SaisuiinTelNo = saisuiinTelNoTextBox.Text;

            // 採水員生年月日
            table[0].SaisuiinSeinegappi = saisuiinSeinegappiDateTimePicker.Value.ToString("yyyyMMdd");

            // 管理士No
            table[0].KanrishiNo = kanrishiNoTextBox.Text;

            // 管理士取得日
            table[0].KanrishiSyutokuDt = kanrishiSyutokuDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 採水員取消日
            table[0].SaisuiinTorikeshiDt = chancelDtAddFlgCheckBox.Checked ? saisuiinTorikeshiDtDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;
            
            // 更新者
            table[0].UpdateUser = user;

            // 更新端末
            table[0].UpdateTarm = host;

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
