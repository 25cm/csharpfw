using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.SaisuiinMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiinMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiinMstShosaiForm : FukjBaseForm
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
        public DispMode _dispMode = DispMode.Add;

        #endregion

        #region プロパティ(private)

        ///// <summary>
        ///// Form loaded or not?
        ///// </summary>
        //private bool _isLoad = false;

        /// <summary>
        /// 採水員コード
        /// </summary>
        private string _saisuiinCd;

        /// <summary>
        /// SaisuiinMstDataTable
        /// </summary>
        private SaisuiinMstDataSet.SaisuiinMstDataTable _dispTable = new SaisuiinMstDataSet.SaisuiinMstDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaisuiinMstShosai
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiinMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaisuiinMstShosai
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiinMstShosaiForm(string saisuiinCd)
        {
            this._saisuiinCd = saisuiinCd;
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SaisuiinMstShosai_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinMstShosai_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinMstShosai_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Add mode title
                this.Text = "採水員マスタ登録";

                // Detail mode
                if (!string.IsNullOrEmpty(this._saisuiinCd))
                {
                    this._dispMode = DispMode.Detail;
                    this.Text = "採水員マスタ詳細";
                }

                // Load and display default value
                DoFormLoad();

                // Title of screen
                SetScreenTitle();

                // Display/Input control
                ItemControl();

                //// Loaded OK
                //this._isLoad = true;
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

        #region gyoushaCdTextBox_TextChanged
        // 2014/11/04 DatNT v1.02 DEL Start
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： gyoushaCdTextBox_TextChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/06/24　AnhNV　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void gyoushaCdTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        gyoshaNmComboBox.SelectedValue = gyoushaCdTextBox.Text;
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        // 2014/11/04 DatNT v1.02 DEL End
        #endregion

        #region gyoshaNmComboBox_SelectedIndexChanged
        // 2014/11/04 DatNT v1.02 DEL Start
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： gyoshaNmComboBox_SelectedIndexChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/06/24　AnhNV　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void gyoshaNmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        // Default selected
        //        if (gyoshaNmComboBox.SelectedIndex == -1)
        //        {
        //            gyoushaCdTextBox.Text = string.Empty;
        //            return;
        //        }

        //        // Other selected value
        //        if (this._isLoad)
        //        {
        //            gyoushaCdTextBox.Text = gyoshaNmComboBox.SelectedValue.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        // 2014/11/04 DatNT v1.02 DEL End
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
        /// 2014/06/24　AnhNV　　    新規作成
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
        /// 2014/06/24　AnhNV　　    新規作成
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
        /// 2014/06/24　AnhNV　　    新規作成
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
        /// 2014/06/24　AnhNV　　    新規作成
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
        /// 2014/06/24　AnhNV　　    新規作成
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
                decInput.SaisuiinMstDataTable = (this._dispMode == DispMode.Add) ? CreateSaisuiinMstInsert() : CreateSaisuiinMstUpdate(_dispTable);
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
        /// 2014/06/24　AnhNV　　    新規作成
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

        #region SaisuiinMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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

        #region zipNoTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zipNoTextBox_KeyPress
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
        private void zipNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        #region telNoTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： telNoTextBox_KeyPress
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
        private void telNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        #region dateTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： dateTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void dateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utility.Utility.IsNumAndSlash(e.KeyChar.ToString())) e.Handled = true;
        }
        #endregion

        #region gyoushaCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoushaCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoushaCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyoushaCdTextBox.Text))
                {
                    shozokuGyosyaNmTextBox.Clear();

                    gyoushaCdTextBox.Text = gyoushaCdTextBox.Text.PadLeft(4, '0');

                    Common.Common.SetGyoshaNmByCd(gyoushaCdTextBox.Text, gyoushaCdTextBox, shozokuGyosyaNmTextBox);

                    if (string.IsNullOrEmpty(gyoushaCdTextBox.Text))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "業者マスタに存在しません。");
                        return;
                    }
                }
                else
                {
                    shozokuGyosyaNmTextBox.Clear();
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
        /// 2014/11/04　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shozokuGyosyaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gyoushaCdTextBox.Text = frm._selectedRow.GyoshaCd;
                    shozokuGyosyaNmTextBox.Text = frm._selectedRow.GyoshaNm;
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
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT     v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SaisuiinCd = (this._dispMode == DispMode.Add) ? string.Empty : this._saisuiinCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 2014/11/04 DatNT v1.02 DEL Start
            //// Set default combobox for all modes
            //Utility.Utility.SetComboBoxList(gyoshaNmComboBox, alOutput.GyoshaMstDataTable, "GyoshaNm", "GyoshaCd", true);
            // 2014/11/04 DatNT v1.02 DEL End

            // Display default value in Detail mode
            if (this._dispMode == DispMode.Detail)
            {
                this._dispTable = alOutput.SaisuiinMstDataTable;

                // Default value
                DisplayDefault();

                // Control the display of gyosha combobox
                gyoushaCdTextBox.Text = this._dispTable[0].SyozokuGyosyaCd;
                gyoushaCdTextBox_Leave(null, null);
                // 2014/11/04 DatNT v1.02 DEL Start
                //gyoshaNmComboBox.SelectedValue = this._dispTable[0].SyozokuGyosyaCd;
                // 2014/11/04 DatNT v1.02 DEL End
            }
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
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT       v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault()
        {
            // 採水員コード(2)
            saisuiinCdTextBox.Text = _dispTable[0].SaisuiinCd;

            // 採水員名(3)
            saisuiinNmTextBox.Text = _dispTable[0].SaisuiinNm;

            // カナ名(4)
            saisuiinKanaTextBox.Text = _dispTable[0].SaisuiinKana;

            // 2014/11/04 DatNT v1.02 DEL Start
            //// 指定№(7)
            //siteiNoTextBox.Text = _dispTable[0].SaisuiinShiteiNo.Trim();
            // 2014/11/04 DatNT v1.02 DEL End

            // 所属業者名
            

            // 取得日(8)
            shutokuDtTextBox.Text = !string.IsNullOrEmpty(_dispTable[0].SaisuiinSyutokuDt.Trim())
                ? DateTime.ParseExact(_dispTable[0].SaisuiinSyutokuDt, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") : string.Empty;

            // 受講日(9)
            jukouDtTextBox.Text = !string.IsNullOrEmpty(_dispTable[0].JukoDt.Trim())
                ? DateTime.ParseExact(_dispTable[0].JukoDt, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") : string.Empty;

            // 前回受講日(10)
            zenkaiJyukouDtTextBox.Text = !string.IsNullOrEmpty(_dispTable[0].ZenkaiJukoDt.Trim())
                ? DateTime.ParseExact(_dispTable[0].ZenkaiJukoDt, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") : string.Empty;

            // 有効期限(11)
            yukoKigenDtTextBox.Text = !string.IsNullOrEmpty(_dispTable[0].SaisuiinYukokigenDt.Trim())
                ? DateTime.ParseExact(_dispTable[0].SaisuiinYukokigenDt, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") : string.Empty;
            
            // 郵便番号(12)
            zipNoTextBox.Text = _dispTable[0].SaisuiinZipCd;

            // 住所(13)
            addressTextBox.Text = _dispTable[0].SaisuiinAdr;

            // 電話番号(14)
            telNoTextBox.Text = _dispTable[0].SaisuiinTelNo;

            // 生年月日(15)
            seinengappiTextBox.Text = !string.IsNullOrEmpty(_dispTable[0].SaisuiinSeinegappi.Trim())
                ? DateTime.ParseExact(_dispTable[0].SaisuiinSeinegappi, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") : string.Empty;

            // 管理士№(16)
            kanrishiNoTextBox.Text = _dispTable[0].KanrishiNo.Trim();

            // 管理士取得日(17)
            kanrishiShutokuBiTextBox.Text = !string.IsNullOrEmpty(_dispTable[0].KanrishiSyutokuDt.Trim())
                ? DateTime.ParseExact(_dispTable[0].KanrishiSyutokuDt, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") : string.Empty;

            // 取消日(18)
            torikeshiDtTextBox.Text = !string.IsNullOrEmpty(_dispTable[0].SaisuiinTorikeshiDt.Trim())
                ? DateTime.ParseExact(_dispTable[0].SaisuiinTorikeshiDt, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd") : string.Empty;
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
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            // Hide/unhide required mark(*)
            RequiredMarkControl();

            switch (_dispMode)
            {
                case DispMode.Detail:
                    Program.mForm.Text = "採水員マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    // 所属業者検索ボタン
                    shozokuGyosyaSearchButton.Visible = false;
                    break;
                case DispMode.Add:
                    Program.mForm.Text = "採水員マスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    // 所属業者検索ボタン
                    shozokuGyosyaSearchButton.Visible = true;
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "採水員マスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    // 所属業者検索ボタン
                    shozokuGyosyaSearchButton.Visible = false;
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "採水員マスタ変更";
                    Program.mForm.SetMenuEnabled(false);
                    // 所属業者検索ボタン
                    shozokuGyosyaSearchButton.Visible = true;
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
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT       v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemControl()
        {
            // 採水員コード(2)
            // UPD 20140724 START ZynasSou
            //saisuiinCdTextBox.ReadOnly = (this._dispMode == DispMode.Add) ? false : true;
            saisuiinCdTextBox.ReadOnly = true;
            // UPD 20140724 END ZynasSou

            // 採水員名(3)
            saisuiinNmTextBox.ReadOnly = 

            // カナ名(4)
            saisuiinKanaTextBox.ReadOnly = 

            // 所属業者コード(5)
            gyoushaCdTextBox.ReadOnly =

            // 2014/11/04 DatNT v1.02 DEL Start
            //// 指定№(7)
            //siteiNoTextBox.ReadOnly =
            // 2014/11/04 DatNT v1.02 DEL End

            // 取得日(8)
            shutokuDtTextBox.ReadOnly = 

            // 受講日(9)
            jukouDtTextBox.ReadOnly = 

            // 前回受講日(10)
            zenkaiJyukouDtTextBox.ReadOnly = 

            // 有効期限(11)
            yukoKigenDtTextBox.ReadOnly = 

            // 郵便番号(12)
            zipNoTextBox.ReadOnly = 

            // 住所(13)
            addressTextBox.ReadOnly = 

            // 電話番号(14)
            telNoTextBox.ReadOnly = 

            // 生年月日(15)
            seinengappiTextBox.ReadOnly = 

            // 管理士№(16)
            kanrishiNoTextBox.ReadOnly = 

            // 管理士取得日(17)
            kanrishiShutokuBiTextBox.ReadOnly = 

            // 取消日(18)
            torikeshiDtTextBox.ReadOnly = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? false : true;

            // 2014/11/04 DatNT v1.02 DEL Start
            // 所属業者名(6)
            //gyoshaNmComboBox.Enabled = (this._dispMode == DispMode.Detail || this._dispMode == DispMode.Confirm) ? false : true;
            // 2014/11/04 DatNT v1.02 DEL End

            // 登録ボタン(19)
            entryButton.Visible = (this._dispMode == DispMode.Add) ? true : false;

            // 変更ボタン(20)
            changeButton.Visible = (this._dispMode == DispMode.Detail || this._dispMode == DispMode.Edit) ? true : false;

            // 削除ボタン(21)
            deleteButton.Visible = (this._dispMode == DispMode.Detail) ? true : false;

            // 再入力ボタン(22)
            reInputButton.Visible =

            // 確定ボタン(23)
            decisionButton.Visible = (this._dispMode == DispMode.Confirm) ? true : false;
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
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT       v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();

            // DEL 20140724 START ZynasSou
            // 採水員コード(2)
            //if (string.IsNullOrEmpty(saisuiinCdTextBox.Text))
            //{
            //    errMsg.Append("必須項目：採水員コードが入力されていません。\r\n");
            //}
            //else if (!Utility.Utility.IsDecimal(saisuiinCdTextBox.Text))
            //{
            //    errMsg.Append("採水員コードは半角数字で入力して下さい。\r\n");
            //}
            //else if (saisuiinCdTextBox.Text.Length != 5)
            //{
            //    errMsg.Append("採水員コードは5桁で入力して下さい。\r\n");
            //}
            // DEL 20140724 END ZynasSou

            // 採水員名(3)
            if (string.IsNullOrEmpty(saisuiinNmTextBox.Text))
            {
                errMsg.Append("必須項目：採水員名が入力されていません。\r\n");
            }
            else if (saisuiinNmTextBox.Text.Length > 40)
            {
                errMsg.Append("採水員名は40文字以下で入力して下さい。\r\n");
            }

            // カナ名(4)
            if (string.IsNullOrEmpty(saisuiinKanaTextBox.Text))
            {
                errMsg.Append("必須項目：カナ名が入力されていません。\r\n");
            }
            else if (saisuiinKanaTextBox.Text.Length > 40)
            {
                errMsg.Append("カナ名は40文字以下で入力して下さい。\r\n");
            }

            //// 所属業者コード(5)
            //if (string.IsNullOrEmpty(gyoushaCdTextBox.Text))
            //{
            //    errMsg.Append("必須項目：所属業者コードが入力されていません。\r\n");
            //}
            //else if (!Utility.Utility.IsDecimal(gyoushaCdTextBox.Text))
            //{
            //    errMsg.Append("所属業者コードは半角数字で入力して下さい。\r\n");
            //}
            //else if (gyoushaCdTextBox.Text.Length != 4)
            //{
            //    errMsg.Append("所属業者コードは4桁で入力して下さい。\r\n");
            //}

            // 2014/11/04 DatNT DEL Start
            //// 所属業者名(6)
            //if (gyoshaNmComboBox.SelectedIndex <= 0)
            //{
            //    errMsg.Append("必須項目：所属業者名が選択されていません。\r\n");
            //}
            //else if (gyoushaCdTextBox.Text.Length > 4)
            //{
            //    errMsg.Append("所属業者コードは4桁で入力して下さい。\r\n");
            //}
            
            //// 指定№(7)
            //if (string.IsNullOrEmpty(siteiNoTextBox.Text))
            //{
            //    errMsg.Append("必須項目：指定No.が入力されていません。\r\n");
            //}
            //else if (!Utility.Utility.IsDecimal(siteiNoTextBox.Text))
            //{
            //    errMsg.Append("指定Noは半角数字で入力して下さい。\r\n");
            //}
            //else if (siteiNoTextBox.Text.Length != 5)
            //{
            //    errMsg.Append("指定Noは5桁で入力して下さい。\r\n");
            //}
            // 2014/11/04 DatNT DEL End

            // 取得日(8)
            if (string.IsNullOrEmpty(shutokuDtTextBox.Text))
            {
                //errMsg.Append("必須項目：取得日が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDateFormat(shutokuDtTextBox.Text))
            {
                errMsg.Append("取得日は日付の書式で入力して下さい。\r\n");
            }

            // 受講日(9)
            if (string.IsNullOrEmpty(jukouDtTextBox.Text))
            {
                // DEL 20140718 ZynasSou
                //errMsg.Append("必須項目：受講日が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDateFormat(jukouDtTextBox.Text))
            {
                errMsg.Append("受講日は日付の書式で入力して下さい。\r\n");
            }

            // 前回受講日(10)
            if (string.IsNullOrEmpty(zenkaiJyukouDtTextBox.Text))
            {
                // DEL 20140718 ZynasSou
                //errMsg.Append("必須項目：前回受講日が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDateFormat(zenkaiJyukouDtTextBox.Text))
            {
                errMsg.Append("前回受講日は日付の書式で入力して下さい。\r\n");
            }

            // 有効期限(11)
            if (string.IsNullOrEmpty(yukoKigenDtTextBox.Text))
            {
                //errMsg.Append("必須項目：有効期限が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDateFormat(yukoKigenDtTextBox.Text))
            {
                errMsg.Append("有効期限は日付の書式で入力して下さい。\r\n");
            }

            // 郵便番号(12)
            if (string.IsNullOrEmpty(zipNoTextBox.Text))
            {
                //errMsg.Append("必須項目：郵便番号が入力されていません。\r\n");
            }
            else if (zipNoTextBox.Text.Length != 8)
            {
                errMsg.Append("郵便番号は8桁で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsNumAndNegative(zipNoTextBox.Text))
            {
                errMsg.Append("郵便番号は半角数字と-(半角ハイフン)で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsZipCode(zipNoTextBox.Text))
            {
                errMsg.Append("郵便番号の形式が不正です。\r\n");
            }

            // 住所(13)
            if (string.IsNullOrEmpty(addressTextBox.Text))
            {
                //errMsg.Append("必須項目：住所が入力されていません。\r\n");
            }
            else if (addressTextBox.Text.Length > 80)
            {
                errMsg.Append("住所は80文字以下で入力して下さい。\r\n");
            }

            // 電話番号(14)
            if (string.IsNullOrEmpty(telNoTextBox.Text))
            {
                //errMsg.Append("必須項目：電話番号が入力されていません。\r\n");
            }
            else if (telNoTextBox.Text.Length < 12)
            {
                errMsg.Append("電話番号は12～13桁で入力して下さい。\r\n");
            }
            //else if (telNoTextBox.Text.Length != 13)
            //{
            //    errMsg.Append("電話番号は13文字で入力して下さい。\r\n");
            //}
            else if (!Utility.Utility.IsNumAndNegative(telNoTextBox.Text.Trim()))
            {
                errMsg.Append("電話番号は半角数字と-(半角ハイフン)で入力して下さい。\r\n");
            }
            //else if (!Utility.Utility.IsPhoneNumber(telNoTextBox.Text))
            //{
            //    errMsg.Append("電話番号の形式が不正です。\r\n");
            //}

            // 生年月日(15)
            if (string.IsNullOrEmpty(seinengappiTextBox.Text))
            {
                //errMsg.Append("必須項目：生年月日が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDateFormat(seinengappiTextBox.Text))
            {
                errMsg.Append("生年月日は日付の書式で入力して下さい。\r\n");
            }

            // 管理士№(16)
            if (string.IsNullOrEmpty(kanrishiNoTextBox.Text))
            {
                //errMsg.Append("必須項目：管理士No.が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(kanrishiNoTextBox.Text))
            {
                errMsg.Append("管理士Noは半角数字で入力して下さい。\r\n");
            }
            else if (kanrishiNoTextBox.Text.Length != 10)
            {
                errMsg.Append("管理士Noは10桁で入力して下さい。\r\n");
            }

            // 管理士取得日(17)
            if (string.IsNullOrEmpty(kanrishiShutokuBiTextBox.Text))
            {
                //errMsg.Append("必須項目：管理士取得日が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDateFormat(kanrishiShutokuBiTextBox.Text))
            {
                errMsg.Append("管理士取得日は日付の書式で入力して下さい。\r\n");
            }

            // 取消日(18)
            if (string.IsNullOrEmpty(torikeshiDtTextBox.Text))
            {
                //errMsg.Append("必須項目：取消日が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDateFormat(torikeshiDtTextBox.Text))
            {
                errMsg.Append("取消日は日付の書式で入力して下さい。\r\n");
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

        #region InputCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InputCheck
        /// <summary>
        /// Validate the data type
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT       v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool InputCheck()
        {
            // DEL 20140724 START ZynasSou
            //// 採水員コード(2)
            //if (!Utility.Utility.IsDecimal(saisuiinCdTextBox.Text))
            //{
            //    MessageForm.Show2(MessageForm.DispModeType.Error, "採水員コードは半角数字で入力して下さい。");
            //    return false;
            //}
            // DEL 20140724 END ZynasSou

            // DEL 20140724 START ZynasSou
            //// 採水員コード(2)
            //if (saisuiinCdTextBox.Text.Length != 5)
            //{
            //    MessageForm.Show2(MessageForm.DispModeType.Error, "採水員コードは5桁で入力して下さい。");
            //    return false;
            //}
            // DEL 20140724 END ZynasSou

            // 採水員名(3)
            if (saisuiinNmTextBox.Text.Length > 40)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "採水員名は40文字以下で入力して下さい。");
                return false;
            }

            // カナ名(4)
            if (saisuiinKanaTextBox.Text.Length > 40)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "カナ名は40文字以下で入力して下さい。");
                return false;
            }

            // 所属業者コード(5)
            if (!Utility.Utility.IsDecimal(gyoushaCdTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "所属業者コードは半角数字で入力して下さい。");
                return false;
            }

            // 所属業者コード(5)
            if (gyoushaCdTextBox.Text.Length != 4)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "所属業者コードは40桁で入力して下さい。");
                return false;
            }

            // 所属業者コード(5)
            if (gyoushaCdTextBox.Text.Length > 4)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "所属業者コードは4桁で入力して下さい。");
                return false;
            }

            // 2014/11/04 DatNT v1.02 DEL Start
            //// 指定№(7)
            //if (!Utility.Utility.IsDecimal(siteiNoTextBox.Text))
            //{
            //    MessageForm.Show2(MessageForm.DispModeType.Error, "指定Noは半角数字で入力して下さい。");
            //    return false;
            //}

            //// 指定№(7)
            //if (siteiNoTextBox.Text.Length != 5)
            //{
            //    MessageForm.Show2(MessageForm.DispModeType.Error, "指定Noは5桁で入力して下さい。");
            //    return false;
            //}
            // 2014/11/04 DatNT v1.02 DEL End

            // 取得日(8)
            if (!Utility.Utility.IsDateFormat(shutokuDtTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "取得日は日付の書式で入力して下さい。");
                return false;
            }

            // 受講日(9)
            if (!Utility.Utility.IsDateFormat(jukouDtTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "受講日は日付の書式で入力して下さい。");
                return false;
            }

            // 前回受講日(10)
            if (!Utility.Utility.IsDateFormat(zenkaiJyukouDtTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "前回受講日は日付の書式で入力して下さい。");
                return false;
            }

            // 有効期限(11)
            if (!Utility.Utility.IsDateFormat(yukoKigenDtTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "有効期限は日付の書式で入力して下さい。");
                return false;
            }

            // 郵便番号(12)
            if (!Utility.Utility.IsZipCode(zipNoTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "郵便番号は半角数字と-(半角ハイフン)で入力して下さい。");
                return false;
            }

            // 住所(13)
            if (addressTextBox.Text.Length > 80)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "住所は80文字以下で入力して下さい。");
                return false;
            }

            // 電話番号(14)
            if (!Utility.Utility.IsPhoneNumber(telNoTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "電話番号は半角数字と-(半角ハイフン)で入力して下さい。");
                return false;
            }

            // 生年月日(15)
            if (!Utility.Utility.IsDateFormat(seinengappiTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "生年月日は日付の書式で入力して下さい。");
                return false;
            }

            // 管理士№(16)
            if (!Utility.Utility.IsDecimal(kanrishiNoTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "管理士Noは半角数字で入力して下さい。");
                return false;
            }

            // 管理士№(16)
            if (kanrishiNoTextBox.Text.Length != 10)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "管理士Noは10桁で入力して下さい。");
                return false;
            }

            // 管理士取得日(17)
            if (!Utility.Utility.IsDateFormat(kanrishiShutokuBiTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "管理士取得日は日付の書式で入力して下さい。");
                return false;
            }

            // 取消日(18)
            if (!Utility.Utility.IsDateFormat(torikeshiDtTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "取消日は日付の書式で入力して下さい。");
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
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT       v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            // 採水員コード(2)
            if (saisuiinCdTextBox.Text != _dispTable[0].SaisuiinCd) return false;

            // 採水員名(3)
            if (saisuiinNmTextBox.Text != _dispTable[0].SaisuiinNm ) return false;

            // カナ名(4)
            if (saisuiinKanaTextBox.Text != _dispTable[0].SaisuiinKana) return false;

            // 所属業者コード(5)
            if (gyoushaCdTextBox.Text != _dispTable[0].SyozokuGyosyaCd) return false;

            // 2014/11/04 DatNT v1.02 DEL Start
            //// 指定№(7)
            //if (siteiNoTextBox.Text != _dispTable[0].SaisuiinShiteiNo.Trim()) return false;
            // 2014/11/04 DatNT v1.02 DEL End

            // 取得日(8)
            if (shutokuDtTextBox.Text.Replace(@"/", string.Empty) != _dispTable[0].SaisuiinSyutokuDt) return false;

            // 受講日(9)
            if (jukouDtTextBox.Text.Replace(@"/", string.Empty) != _dispTable[0].JukoDt) return false;

            // 前回受講日(10)
            if (zenkaiJyukouDtTextBox.Text.Replace(@"/", string.Empty) != _dispTable[0].ZenkaiJukoDt) return false;

            // 有効期限(11)
            if (yukoKigenDtTextBox.Text.Replace(@"/", string.Empty) != _dispTable[0].SaisuiinYukokigenDt) return false;

            // 郵便番号(12)
            if (zipNoTextBox.Text != _dispTable[0].SaisuiinZipCd) return false;

            // 住所(13)
            if (addressTextBox.Text != _dispTable[0].SaisuiinAdr) return false;

            // 電話番号(14)
            if (telNoTextBox.Text != _dispTable[0].SaisuiinTelNo) return false;

            // 生年月日(15)
            if (seinengappiTextBox.Text.Replace(@"/", string.Empty) != _dispTable[0].SaisuiinSeinegappi) return false;

            // 管理士№(16)
            if (kanrishiNoTextBox.Text != _dispTable[0].KanrishiNo.Trim()) return false;

            // 管理士取得日(17)
            if (kanrishiShutokuBiTextBox.Text.Replace(@"/", string.Empty) != _dispTable[0].KanrishiSyutokuDt) return false;

            // 取消日(18)
            if (torikeshiDtTextBox.Text.Replace(@"/", string.Empty) != _dispTable[0].SaisuiinTorikeshiDt) return false;

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
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT       v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditControl()
        {
            // Any item is edited
            if (!string.IsNullOrEmpty(saisuiinCdTextBox.Text)
                || !string.IsNullOrEmpty(saisuiinNmTextBox.Text)
                || !string.IsNullOrEmpty(saisuiinKanaTextBox.Text)
                || !string.IsNullOrEmpty(gyoushaCdTextBox.Text)
                // 2014/11/04 DatNT v1.02 DEL Start
                //|| (gyoshaNmComboBox.SelectedIndex > 0)
                //|| !string.IsNullOrEmpty(siteiNoTextBox.Text)
                // 2014/11/04 DatNT v1.02 DEL End
                || !string.IsNullOrEmpty(shutokuDtTextBox.Text)
                || !string.IsNullOrEmpty(jukouDtTextBox.Text)
                || !string.IsNullOrEmpty(zenkaiJyukouDtTextBox.Text)
                || !string.IsNullOrEmpty(yukoKigenDtTextBox.Text)
                || !string.IsNullOrEmpty(zipNoTextBox.Text)
                || !string.IsNullOrEmpty(addressTextBox.Text)
                || !string.IsNullOrEmpty(telNoTextBox.Text)
                || !string.IsNullOrEmpty(seinengappiTextBox.Text)
                || !string.IsNullOrEmpty(kanrishiNoTextBox.Text)
                || !string.IsNullOrEmpty(kanrishiShutokuBiTextBox.Text)
                || !string.IsNullOrEmpty(torikeshiDtTextBox.Text))
            {
                return true;
            }

            // No items is edited
            return false;
        }
        #endregion

        #region RequiredMarkControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RequiredMarkControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RequiredMarkControl()
        {
            //bool visibleFlg = true;

            //if (this._dispMode == DispMode.Detail || this._dispMode == DispMode.Confirm)
            //{
            //    visibleFlg = false;
            //}

            //foreach (System.Windows.Forms.Control c in this.Controls)
            //{
            //    if (c.GetType() != typeof(Label)) continue;
            //    if (c.Name == "keyCode")
            //    {
            //        if (this._dispMode == DispMode.Add)
            //        {
            //            c.Visible = true;
            //        }
            //        else
            //        {
            //            c.Visible = false;
            //        }
            //    }
            //    else if (c.Text == "*")
            //    {
            //        c.Visible = visibleFlg;
            //    }
            //}
        }
        #endregion

        #region CreateSaisuiinMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaisuiinMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <returns>SaisuiinMstDataSet.SaisuiinMstDataTable</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstDataSet.SaisuiinMstDataTable CreateSaisuiinMstInsert()
        {
            // Instances a new table
            SaisuiinMstDataSet.SaisuiinMstDataTable table = new SaisuiinMstDataSet.SaisuiinMstDataTable();
            SaisuiinMstDataSet.SaisuiinMstRow newRow = table.NewSaisuiinMstRow();

            // 採水員コード(2)
            // UPD 20140724 START ZynasSou
            //newRow.SaisuiinCd = saisuiinCdTextBox.Text;
            newRow.SaisuiinCd = Utility.Saiban.GetKeyRenban("SaisuiinMst","","","").PadLeft(5,'0');
            // UPD 20140724 END ZynasSou

            // 採水員名(3)
            newRow.SaisuiinNm = saisuiinNmTextBox.Text;

            // カナ名(4)
            newRow.SaisuiinKana = saisuiinKanaTextBox.Text;

            // 所属業者コード(5)
            newRow.SyozokuGyosyaCd = gyoushaCdTextBox.Text;

            // 2014/11/04 DatNT v1.02 MOD Start
            // 指定№(7)
            //newRow.SaisuiinShiteiNo = siteiNoTextBox.Text.PadLeft(5, ' ');
            newRow.SaisuiinShiteiNo = string.Empty;
            // 2014/11/04 DatNT v1.02 MOD End

            // 取得日(8)
            newRow.SaisuiinSyutokuDt = shutokuDtTextBox.Text.Replace(@"/", string.Empty);

            // 受講日(9)
            newRow.JukoDt = jukouDtTextBox.Text.Replace(@"/", string.Empty);

            // 前回受講日(10)
            newRow.ZenkaiJukoDt = zenkaiJyukouDtTextBox.Text.Replace(@"/", string.Empty);

            // 有効期限(11)
            newRow.SaisuiinYukokigenDt = yukoKigenDtTextBox.Text.Replace(@"/", string.Empty);

            // 郵便番号(12)
            newRow.SaisuiinZipCd = zipNoTextBox.Text;

            // 住所(13)
            newRow.SaisuiinAdr = addressTextBox.Text;

            // 電話番号(14)
            newRow.SaisuiinTelNo = telNoTextBox.Text;

            // 生年月日(15)
            newRow.SaisuiinSeinegappi = seinengappiTextBox.Text.Replace(@"/", string.Empty);

            // 管理士№(16)
            newRow.KanrishiNo = kanrishiNoTextBox.Text.PadLeft(10, ' ');

            // 管理士取得日(17)
            newRow.KanrishiSyutokuDt = kanrishiShutokuBiTextBox.Text.Replace(@"/", string.Empty);

            // 取消日(18)
            newRow.SaisuiinTorikeshiDt = torikeshiDtTextBox.Text.Replace(@"/", string.Empty);

            // 登録日
            newRow.InsertDt =

            // 更新日
            newRow.UpdateDt = Common.Common.GetCurrentTimestamp();

            // 登録者
            newRow.InsertUser =

            // 更新者
            newRow.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 登録端末
            newRow.InsertTarm =

            // 更新端末
            newRow.UpdateTarm = Dns.GetHostName();

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
        /// <returns>SaisuiinMstDataSet.SaisuiinMstDataTable</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/11/04  DatNT       v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstDataSet.SaisuiinMstDataTable CreateSaisuiinMstUpdate(SaisuiinMstDataSet.SaisuiinMstDataTable table)
        {
            // 採水員コード(2)
            table[0].SaisuiinCd = saisuiinCdTextBox.Text;

            // 採水員名(3)
            table[0].SaisuiinNm = saisuiinNmTextBox.Text;

            // カナ名(4)
            table[0].SaisuiinKana = saisuiinKanaTextBox.Text;

            // 所属業者コード(5)
            table[0].SyozokuGyosyaCd = gyoushaCdTextBox.Text;

            // 2014/11/04 DatNT v1.02 DEL Start
            //// 指定№(7)
            //table[0].SaisuiinShiteiNo = siteiNoTextBox.Text.PadLeft(5, ' ');
            // 2014/11/04 DatNT v1.02 DEL End

            // 取得日(8)
            table[0].SaisuiinSyutokuDt = shutokuDtTextBox.Text.Replace(@"/", string.Empty);

            // 受講日(9)
            table[0].JukoDt = jukouDtTextBox.Text.Replace(@"/", string.Empty);

            // 前回受講日(10)
            table[0].ZenkaiJukoDt = zenkaiJyukouDtTextBox.Text.Replace(@"/", string.Empty);

            // 有効期限(11)
            table[0].SaisuiinYukokigenDt = yukoKigenDtTextBox.Text.Replace(@"/", string.Empty);

            // 郵便番号(12)
            table[0].SaisuiinZipCd = zipNoTextBox.Text;

            // 住所(13)
            table[0].SaisuiinAdr = addressTextBox.Text;

            // 電話番号(14)
            table[0].SaisuiinTelNo = telNoTextBox.Text;

            // 生年月日(15)
            table[0].SaisuiinSeinegappi = seinengappiTextBox.Text.Replace(@"/", string.Empty);

            // 管理士№(16)
            table[0].KanrishiNo = kanrishiNoTextBox.Text.PadLeft(10, ' ');

            // 管理士取得日(17)
            table[0].KanrishiSyutokuDt = kanrishiShutokuBiTextBox.Text.Replace(@"/", string.Empty);

            // 取消日(18)
            table[0].SaisuiinTorikeshiDt = torikeshiDtTextBox.Text.Replace(@"/", string.Empty);

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
