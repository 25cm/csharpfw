using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuKensaSetMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaSetMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaSetMstShosaiForm : FukjBaseForm
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

        /// <summary>
        /// セットコード
        /// </summary>
        private string _setCd { get; set; }

        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        private SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable _suishitsuDT =
            new SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable();

        /// <summary>
        /// セット試験項目マスタ
        /// </summary>
        private SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable _setShikenDT =
            new SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable();

        /// <summary>
        /// SuishitsuKensaSetMstShosaiDataTable
        /// </summary>
        private SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstShosaiDataTable _dgvSource =
            new SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstShosaiDataTable();

        //20150128 HuyTX Ver1.02 Add
        /// <summary>
        /// listRowDeleted 
        /// </summary>
        List<string> _listRowDeleted = new List<string>();
        //End

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaSetMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaSetMstShosaiForm()
        {
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaSetMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaSetMstShosaiForm(string setCd)
        {
            this._setCd = setCd;
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region イベント

        #region SuishitsuKensaSetMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaSetMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaSetMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Add mode title
                this.Text = "水質検査セットマスタ登録";

                // Detail mode
                if (!string.IsNullOrEmpty(this._setCd))
                {
                    this._dispMode = DispMode.Detail;
                    this.Text = "水質検査セットマスタ詳細";
                }

                // Load and display default value
                DoFormLoad();

                // Title of screen
                SetScreenTitle();

                // Display/Input control
                ItemControl();
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
        /// 2014/07/04　AnhNV　　    新規作成
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

                // Focus to first displayed cell
                setShikenListDataGridView.CurrentCell = setShikenListDataGridView.FirstDisplayedCell;
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
        /// 2014/07/04　AnhNV　　    新規作成
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

                // Focus to first displayed cell
                setShikenListDataGridView.CurrentCell = setShikenListDataGridView.FirstDisplayedCell;
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
        /// 2014/07/04　AnhNV　　    新規作成
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
                    delInput.SetCd = setCdTextBox.Text;
                    IDeleteBtnClickALOutput delOutput = new DeleteBtnClickApplicationLogic().Execute(delInput);

                    // SetCd does not exist
                    if (!string.IsNullOrEmpty(delOutput.ErrMsg))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, delOutput.ErrMsg);
                        return;
                    }

                    // Close this screen and back to SuishitsuKensaSetMst form
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
        /// 2014/07/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._dispMode = string.IsNullOrEmpty(this._setCd) ? DispMode.Add : DispMode.Edit;

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
        /// 2014/07/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._dispMode = string.IsNullOrEmpty(this._setCd) ? DispMode.Add : DispMode.Edit;

                // Update successfully!!!
                if (DoUpdate())
                {
                    // Back to 001-025
                    this.DialogResult = DialogResult.OK;
                    Program.mForm.MovePrev();
                }
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

        #region shukeiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shukeiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shukeiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // セット料金(4)
                SetRyokin();
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

        #region setRyoukinTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setRyoukinTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setRyoukinTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.'
                    && (sender as TextBox).Text.IndexOf('.') > -1)
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

        #region setRyoukinTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setRyoukinTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setRyoukinTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(setRyoukinTextBox.Text.Trim()))
                {
                    setRyoukinTextBox.Text = Convert.ToDouble(setRyoukinTextBox.Text).ToString("N1");
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

        #region setShikenListDataGridView_DefaultValuesNeeded
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setShikenListDataGridView_DefaultValuesNeeded
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                e.Row.Cells["SetNm"].Value = string.Empty;
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

        #region setShikenListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setShikenListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // For debugging
                Exception ex = e.Exception;

                // Do not throw any exception
                e.ThrowException = false;
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

        #region setShikenListDataGridView_CellEndEdit
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setShikenListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Force to セット試験項目コード column
                if (e.ColumnIndex == 8)
                {
                    if (!Utility.Utility.IsDecimal(setShikenListDataGridView.CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                    {
                        setShikenListDataGridView.CurrentRow.Cells[e.ColumnIndex].Value = string.Empty;
                        setShikenListDataGridView.CurrentRow.Cells[SetKomokuRyokinCol.Name].Value = 0;
                    }
                    else
                    {
                        // セット試験項目コード(8) text changed
                        SetKomokuNmColTextChanged();
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

        #region setShikenListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setShikenListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Current column
                int colIndex = setShikenListDataGridView.CurrentCell.ColumnIndex;

                switch (colIndex)
                {
                    case 14: // セット試験項目名称(9) column
                        ComboBox combo = e.Control as ComboBox;
                        if (combo != null)
                        {
                            combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                            combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                        }
                        break;
                    case 8: // セット試験項目コード(8) column
                        e.Control.KeyPress += new KeyPressEventHandler(setShikenListDataGridView_ControlKeyPress);
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

        #region setShikenListDataGridView_Enter
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setShikenListDataGridView_Enter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_Enter(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Focus to first displayed cell
                setShikenListDataGridView.CurrentCell = setShikenListDataGridView.FirstDisplayedCell;
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

        #region SuishitsuKensaSetMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaSetMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaSetMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/07/04　AnhNV　　    新規作成
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
                if (string.IsNullOrEmpty(_setCd))
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

        #region setShikenListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setShikenListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                HighlightDuplicate(false);
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

        #region setHikaiinRyoukinTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setHikaiinRyoukinTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setHikaiinRyoukinTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(setHikaiinRyoukinTextBox.Text.Trim()))
                {
                    setHikaiinRyoukinTextBox.Text = Convert.ToDouble(setHikaiinRyoukinTextBox.Text).ToString("N1");
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

        #region setShikenListDataGridView_UserDeletingRow
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setShikenListDataGridView_UserDeletingRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string setKomokuCd = setShikenListDataGridView.CurrentRow.Cells[SetKomokuCdCol.Name].Value.ToString();
                SetShikenKomokuMstDataSet.SetShikenKomokuMstRow[] setShikenKomokuRows = (SetShikenKomokuMstDataSet.SetShikenKomokuMstRow[])_setShikenDT.Select(string.Format("SetKomokuSetCd = '{0}' AND SetKomokuCd = '{1}'",
                                                                                setCdTextBox.Text, setKomokuCd));
                if (setShikenKomokuRows.Length > 0)
                {
                    _listRowDeleted.Add(setKomokuCd);
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
        /// 2014/07/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this.suishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMst.PrimaryKey = null;
            // Binding source for セット試験項目名称(9)
            this.suishitsuShikenKoumokuMstTableAdapter.Fill(this.suishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMst);

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SetCd = (this._dispMode == DispMode.Add) ? string.Empty : this._setCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Display default value in Detail mode
            if (this._dispMode == DispMode.Detail)
            {
                this._suishitsuDT = alOutput.SuishitsuKensaSetMstDataTable;
                this._setShikenDT = alOutput.SetShikenKomokuMstDataTable;
                this._dgvSource = alOutput.SuishitsuKensaSetMstShosaiDataTable;

                // Default value
                DisplayDefault();
            }

            // Dgv source
            setShikenListDataGridView.DataSource = _dgvSource;

            // Display the dgv
            DgvControl();
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
        /// 2014/07/08  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoUpdate()
        {
            // Constraint violation
            if (HighlightDuplicate(true))
            {
                return false;
            }

            // Update 水質検査セットマスタ
            IDecisionBtnClickALInput decInput = new DecisionBtnClickALInput();
            decInput.DispMode = this._dispMode;
            decInput.SuishitsuKensaSetMstDataTable = (this._dispMode == DispMode.Add) ? CreateSuishitsuKensaSetMstInsert() : CreateSuishitsuKensaSetMstUpdate(_suishitsuDT);
            decInput.SetShikenKomokuMstDataTable = (this._dispMode == DispMode.Add) ? CreateSetShikenKomokuMstInsert(decInput.SuishitsuKensaSetMstDataTable) : CreateSetShikenKomokuMstUpdate(_setShikenDT);
            //20150128 HuyTX Ver1.02 Add
            decInput.DeletedRows = _listRowDeleted;
            //End

            // Execute update
            IDecisionBtnClickALOutput decOutput = new DecisionBtnClickApplicationLogic().Execute(decInput);

            // Edit mode
            if (!string.IsNullOrEmpty(decOutput.ErrMsg))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, decOutput.ErrMsg);
                return false;
            }

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
        /// 2014/07/04  AnhNV　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault()
        {
            // セットコード(1)
            setCdTextBox.Text = this._setCd;

            // セット名称(正式）(2)
            setNmTextBox.Text = _suishitsuDT[0].SetNm;

            // セット名称（略称）(3)
            setNmRyakushoTextBox.Text = _suishitsuDT[0].SetNmRyakusho;

            // セット会員料金(4)
            setRyoukinTextBox.Text = _suishitsuDT[0].SetRyoukin.ToString("N1");

            //Ver1.02 Start
            //セット非会員料金
            setHikaiinRyoukinTextBox.Text = _suishitsuDT[0].SetHikaiinRyoukin.ToString("N1");
            //End
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
        /// 2014/07/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (_dispMode)
            {
                case DispMode.Detail:
                    Program.mForm.Text = "水質検査セットマスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Add:
                    Program.mForm.Text = "水質検査セットマスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "水質検査セットマスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "水質検査セットマスタ変更";
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
        /// 2014/07/04  AnhNV　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemControl()
        {
            // セットコード(1)
            // UPD 20140724 START ZynasSou
            //setCdTextBox.ReadOnly = (this._dispMode == DispMode.Add) ? false : true;
            setCdTextBox.ReadOnly = true;
            // UPD 20140724 END ZynasSou

            // セット名称(正式）(2)
            setNmTextBox.ReadOnly = 

            // セット名称（略称）(3)
            setNmRyakushoTextBox.ReadOnly =

            // セット会員料金(4)
            setRyoukinTextBox.ReadOnly = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? false : true;

            //Ver1.02 Start
            //セット非会員料金
            setHikaiinRyoukinTextBox.ReadOnly = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? false : true;
            setShikenListDataGridView.AllowUserToDeleteRows = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? true : false;
            //End

            // 集計ボタン(5)
            shukeiButton.Enabled = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? true : false;

            // セット試験項目コード(8)
            setShikenListDataGridView.Columns["SetKomokuCdCol"].ReadOnly = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? false : true;
            
            // セット試験項目名称(9)
            setShikenListDataGridView.Columns["SetKomokuNmCol"].ReadOnly = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? false : true;
            
            // 証明書記載区分(11)
            setShikenListDataGridView.Columns["ShomeishoKisaiKbnCol"].ReadOnly = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? false : true;
            
            // 請求有無区分(12)
            setShikenListDataGridView.Columns["SetKomokuSeikyuUmuKbnCol"].ReadOnly = (this._dispMode == DispMode.Add || this._dispMode == DispMode.Edit) ? false : true;
            
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
        /// 2014/07/04  AnhNV　　    新規作成
        /// 2015/01/26  HuyTX　　    ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            List<string> errMsg = new List<string>();

            // DEL 20140724 START ZynasSou
            //// セットコード(1)
            //if (string.IsNullOrEmpty(setCdTextBox.Text.Trim()))
            //{
            //    errMsg.Add("必須項目：セットコードが選択されていません。\r\n");
            //}
            //else if (!Utility.Utility.IsDecimal(setCdTextBox.Text))
            //{
            //    errMsg.Add("セットコードは半角数字で入力して下さい。\r\n");
            //}
            //else if (setCdTextBox.Text.Length != 3)
            //{
            //    errMsg.Add("セットコードは3桁で入力して下さい。\r\n");
            //}
            // DEL 20140724 END ZynasSou

            // セット名称（正式）(2)
            if (string.IsNullOrEmpty(setNmTextBox.Text.Trim()))
            {
                errMsg.Add("必須項目：セット名称（正式）が入力されていません。\r\n");
            }
            else if (setNmTextBox.Text.Length > 80)
            {
                errMsg.Add("セット名称（正式）は80文字以下で入力して下さい。\r\n");
            }

            // セット名称（略称）(3)
            if (string.IsNullOrEmpty(setNmRyakushoTextBox.Text.Trim()))
            {
                errMsg.Add("必須項目：セット名称（略称）が入力されていません。\r\n");
            }
            else if (setNmRyakushoTextBox.Text.Length > 30)
            {
                errMsg.Add("セット名称（略称）は30文字以下で入力して下さい。\r\n");
            }

            // セット会員料金(4)
            if (string.IsNullOrEmpty(setRyoukinTextBox.Text.Trim()))
            {
                //Ver1.02 Mod
                //errMsg.Add("必須項目：セット料金が入力されていません。\r\n");
                errMsg.Add("必須項目：セット会員料金が入力されていません。\r\n");
                //End
            }
            else if (!Utility.Utility.IsDecimal(setRyoukinTextBox.Text))
            {
                //Ver1.02 Mod
                //errMsg.Add("セット料金は半角数字で入力して下さい。\r\n");
                errMsg.Add("セット会員料金は半角数字で入力して下さい。\r\n");
                //End
            }

            //Ver1.02 Add
            //セット非会員料金
            if (string.IsNullOrEmpty(setHikaiinRyoukinTextBox.Text.Trim()))
            {
                errMsg.Add("必須項目：セット非会員料金が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(setHikaiinRyoukinTextBox.Text))
            {
                errMsg.Add("セット非会員料金は半角数字で入力して下さい。\r\n");
            }
            //End

            // セット試験項目コード(8)
            int rowCnt = 0;
            List<string> requireLines = new List<string>();
            List<string> notNumLines = new List<string>();
            List<string> lengthLines = new List<string>();
            foreach (DataGridViewRow dgvr in setShikenListDataGridView.Rows)
            {
                // Break checking from the last row in dgv
                if (setShikenListDataGridView.Rows.Count > 1 && setShikenListDataGridView.Rows.Count - 1 == rowCnt) break;

                if (dgvr.Cells[SetKomokuCdCol.Name].Value == null 
                    || string.IsNullOrEmpty(dgvr.Cells[SetKomokuCdCol.Name].Value.ToString().Trim()))
                {
                    requireLines.Add(rowCnt + 1 + string.Empty);
                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[SetKomokuCdCol.Name].Value.ToString()))
                {
                    notNumLines.Add(rowCnt + 1 + string.Empty);
                }
                else if (dgvr.Cells[SetKomokuCdCol.Name].Value.ToString().Length != 3)
                {
                    lengthLines.Add(rowCnt + 1 + string.Empty);
                }

                // Next row
                rowCnt++;
            }

            if (requireLines.Count > 0)
            {
                errMsg.Add(string.Format("行{0}: 必須項目：セット試験項目コードが入力されていません。\r\n", string.Join(", ", requireLines.ToArray())));
            }

            if (notNumLines.Count > 0)
            {
                errMsg.Add(string.Format("行{0}: セット試験項目コードは半角数字で入力して下さい。\r\n", string.Join(", ", notNumLines.ToArray())));
            }

            if (lengthLines.Count > 0)
            {
                errMsg.Add(string.Format("行{0}: セット試験項目コードは3桁で入力して下さい。\r\n", string.Join(", ", lengthLines.ToArray())));
            }

            // Throw error messages
            if (errMsg.Count > 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Join(string.Empty, errMsg.ToArray()));
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
        /// 2014/07/04  AnhNV　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            // セット名称(正式）(2)
            if (setNmTextBox.Text != _suishitsuDT[0].SetNm) return false;

            // セット名称（略称）(3)
            if (setNmRyakushoTextBox.Text != _suishitsuDT[0].SetNmRyakusho) return false;

            // セット料金(4)
            if (string.IsNullOrEmpty(setRyoukinTextBox.Text.Trim())
                || Convert.ToDecimal(setRyoukinTextBox.Text) != _suishitsuDT[0].SetRyoukin) return false;

            //Ver1.02 Start
            //セット非会員料金
            if (string.IsNullOrEmpty(setHikaiinRyoukinTextBox.Text.Trim())
                || Convert.ToDecimal(setHikaiinRyoukinTextBox.Text) != _suishitsuDT[0].SetHikaiinRyoukin)
            {
                return false;
            }

            if (setShikenListDataGridView.Rows.Count - 1 != _setShikenDT.Count)
            {
                return false;
            }
            //End

            foreach (DataGridViewRow dgvr in setShikenListDataGridView.Rows)
            {
                if (dgvr.Index == setShikenListDataGridView.Rows.Count - 1) break;

                // セット試験項目コード(8)
                if (!dgvr.Cells[SetKomokuCdCol.Name].Value.Equals(dgvr.Cells[DefaultSetKomokuCdCol.Name].Value))
                {
                    return false;
                }

                // 証明書記載区分(11)
                if (!dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.Equals(dgvr.Cells[DefaultShomeishoKisaiKbnCol.Name].Value))
                {
                    return false;
                }

                // 請求有無区分(12)
                if (!dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.Equals(dgvr.Cells[DefaultSetKomokuSeikyuUmuKbnCol.Name].Value))
                {
                    return false;
                }
            }

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
        /// 2014/07/04  AnhNV　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditControl()
        {
            // Any item is edited
            if (!string.IsNullOrEmpty(setCdTextBox.Text)
                || !string.IsNullOrEmpty(setNmTextBox.Text)
                || !string.IsNullOrEmpty(setNmRyakushoTextBox.Text)
                || !string.IsNullOrEmpty(setRyoukinTextBox.Text)
                || (setShikenListDataGridView.Rows[0].Cells[SetKomokuCdCol.Name].Value != null
                    && !string.IsNullOrEmpty(setShikenListDataGridView.Rows[0].Cells[SetKomokuCdCol.Name].Value.ToString()))
                || (setShikenListDataGridView.Rows[0].Cells[ShomeishoKisaiKbnCol.Name].Value != null 
                    && setShikenListDataGridView.Rows[0].Cells[ShomeishoKisaiKbnCol.Name].Value.ToString() == "1")
                || (setShikenListDataGridView.Rows[0].Cells[SetKomokuSeikyuUmuKbnCol.Name].Value != null
                    && setShikenListDataGridView.Rows[0].Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString() == "1")
                //Ver1.02 Start
                || !string.IsNullOrEmpty(setHikaiinRyoukinTextBox.Text)
                //End
                )
            {
                return true;
            }

            // No items is edited
            return false;
        }
        #endregion

        #region SetRyokin
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetRyokin
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetRyokin()
        {
            // Total of 水質試験項目料金(10)
            decimal setRyokin = 0;

            foreach (DataGridViewRow dgvr in setShikenListDataGridView.Rows)
            {
                // Skip unchecked rows
                if ((bool)dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].FormattedValue == false) continue;

                // Sum all checked rows
                setRyokin += (dgvr.Cells[SetKomokuRyokinCol.Name].Value != null && !string.IsNullOrEmpty(dgvr.Cells[SetKomokuRyokinCol.Name].Value.ToString())) ?
                    Convert.ToDecimal(dgvr.Cells[SetKomokuRyokinCol.Name].Value) : 0;
            }

            // セット会員料金(4)
            setRyoukinTextBox.Text = setRyokin.ToString("N1");

            //20150126 HuyTX Ver1.02
            //セット非会員料金
            setHikaiinRyoukinTextBox.Text = setRyokin.ToString("N1");
            //End
        }
        #endregion

        #region DgvControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DgvControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DgvControl()
        {
            // Sort the dgv
            setShikenListDataGridView.Sort(this.setShikenListDataGridView.Columns["SetKomokuCdCol"], ListSortDirection.Ascending);

            // Unlimit input
            _dgvSource.Columns["SetKomokuCd"].MaxLength = Int32.MaxValue;

            // Dgv column order
            setShikenListDataGridView.Columns["SetKomokuNmCol"].DisplayIndex = 2;
            setShikenListDataGridView.Columns["SetKomokuRyokinCol"].DisplayIndex = 3;
            setShikenListDataGridView.Columns["ShomeishoKisaiKbnCol"].DisplayIndex = 4;
            setShikenListDataGridView.Columns["SetKomokuSeikyuUmuKbnCol"].DisplayIndex = 5;

            // Hide un-used columns
            setShikenListDataGridView.Columns["SetCd"].Visible = false;
            setShikenListDataGridView.Columns["SetRyoukin"].Visible = false;
            setShikenListDataGridView.Columns["SetNm"].Visible = false;
            setShikenListDataGridView.Columns["SetNmRyakusho"].Visible = false;
            setShikenListDataGridView.Columns["SeishikiNm"].Visible = false;

            // Default hidden values
            foreach (DataGridViewRow dgvr in setShikenListDataGridView.Rows)
            {
                if (dgvr.Index == setShikenListDataGridView.Rows.Count - 1) break;
                dgvr.Cells[DefaultSetKomokuCdCol.Name].Value = _setShikenDT[dgvr.Index].SetKomokuCd;
                dgvr.Cells[DefaultShomeishoKisaiKbnCol.Name].Value = _setShikenDT[dgvr.Index].ShomeishoKisaiKbn;
                dgvr.Cells[DefaultSetKomokuSeikyuUmuKbnCol.Name].Value = _setShikenDT[dgvr.Index].SetKomokuSeikyuUmuKbn;
            }
        }
        #endregion

        #region HighlightDuplicate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： HighlightDuplicate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool HighlightDuplicate(bool showMsg)
        {
            bool isDuplicate = false;

            // Use the currentRow to compare against
            for (int currentRow = 0; currentRow < setShikenListDataGridView.Rows.Count - 1; currentRow++)
            {
                bool unHighlight = true;

                DataGridViewRow rowToCompare = setShikenListDataGridView.Rows[currentRow];
                for (int otherRow = 0; otherRow < setShikenListDataGridView.Rows.Count - 1; otherRow++)
                {
                    bool duplicateRow = false;
                    DataGridViewRow row = setShikenListDataGridView.Rows[otherRow];

                    // compare cell SetKomokuCdCol between the two rows
                    if (currentRow != otherRow
                        && !string.IsNullOrEmpty(rowToCompare.Cells[SetKomokuCdCol.Name].Value.ToString())
                        && !string.IsNullOrEmpty(row.Cells[SetKomokuCdCol.Name].Value.ToString())
                        && rowToCompare.Cells[SetKomokuCdCol.Name].Value.Equals(row.Cells[SetKomokuCdCol.Name].Value))
                    {
                        duplicateRow = true;
                    }

                    // Highlight duplicate rows
                    if (duplicateRow)
                    {
                        rowToCompare.DefaultCellStyle.BackColor = Color.Red;
                        rowToCompare.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        unHighlight = false;
                        isDuplicate = true;
                    }
                }

                if (unHighlight)
                {
                    rowToCompare.DefaultCellStyle.BackColor = SystemColors.Window;
                }
            }

            if (isDuplicate && showMsg)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "セット試験項目コードが重複しています。");
            }

            return isDuplicate;
        }
        #endregion

        #region SetKomokuNmColTextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKomokuNmColTextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  AnhNV　　    新規作成
        /// 2015/01/26  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKomokuNmColTextChanged()
        {
            // User force to clear セット試験項目コード columns
            if (setShikenListDataGridView.CurrentRow.Cells[SetKomokuCdCol.Name].Value == null
                || string.IsNullOrEmpty(setShikenListDataGridView.CurrentRow.Cells[SetKomokuCdCol.Name].Value.ToString()))
            {
                // セット試験項目名称(9)
                setShikenListDataGridView.CurrentRow.Cells[SetKomokuNmCol.Name].Value = string.Empty;

                // 水質試験項目料金(10)
                setShikenListDataGridView.CurrentRow.Cells[SetKomokuRyokinCol.Name].Value = "0";

                return;
            }

            //Ver1.02 Start
            setShikenListDataGridView.CurrentRow.Cells[SetKomokuCdCol.Name].Value = Convert.ToString(setShikenListDataGridView.CurrentRow.Cells[SetKomokuCdCol.Name].Value).PadLeft(3, '0');
            //End

            ISetKomokuCdCellValueChangedALInput alInput = new SetKomokuCdCellValueChangedALInput();
            alInput.SuishitsuShikenKoumokuCd = setShikenListDataGridView.CurrentCell.Value.ToString();
            ISetKomokuCdCellValueChangedALOutput alOutput = new SetKomokuCdCellValueChangedApplicationLogic().Execute(alInput);

            // Input code does not match
            if (0 == alOutput.SuishitsuShikenKoumokuMstDataTable.Count)
            {
                // セット試験項目名称(9)
                setShikenListDataGridView.CurrentRow.Cells[SetKomokuNmCol.Name].Value = string.Empty;

                // 水質試験項目料金(10)
                setShikenListDataGridView.CurrentRow.Cells[SetKomokuRyokinCol.Name].Value = false;

                //Ver1.02 Start
                MessageForm.Show2(MessageForm.DispModeType.Error, "入力されたセット試験項目コードは存在しません。");
                //End

                return;
            }

            // セット試験項目名称(9)
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)setShikenListDataGridView.CurrentRow.Cells[SetKomokuNmCol.Name];
            cb.Value = setShikenListDataGridView.CurrentCell.Value.ToString();

            // 水質試験項目料金(10)
            setShikenListDataGridView.CurrentRow.Cells[SetKomokuRyokinCol.Name].Value = alOutput.SuishitsuShikenKoumokuMstDataTable[0].SuishitsuShikenKomokuAmt;
        }
        #endregion

        #region ComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            // No change in combobox
            if (cb.SelectedValue == null || cb.SelectedValue is System.Data.DataRowView)
            {
                return;
            }

            ISetKomokuCdCellValueChangedALInput alInput = new SetKomokuCdCellValueChangedALInput();
            alInput.SuishitsuShikenKoumokuCd = cb.SelectedValue.ToString();
            ISetKomokuCdCellValueChangedALOutput alOutput = new SetKomokuCdCellValueChangedApplicationLogic().Execute(alInput);

            // セット試験項目コード(8)
            setShikenListDataGridView.CurrentRow.Cells[SetKomokuCdCol.Name].Value = cb.SelectedValue;

            // 水質試験項目料金(10)
            setShikenListDataGridView.CurrentRow.Cells[SetKomokuRyokinCol.Name].Value = alOutput.SuishitsuShikenKoumokuMstDataTable[0].SuishitsuShikenKomokuAmt;
        }
        #endregion

        #region CreateSuishitsuKensaSetMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuKensaSetMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <returns>SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable CreateSuishitsuKensaSetMstInsert()
        {
            // Instances a new table
            SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable table = new SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable();
            SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstRow newRow = table.NewSuishitsuKensaSetMstRow();

            // セットコード(1)
            // UPD 20140724 START ZynasSou
            //newRow.SetCd = setCdTextBox.Text;
            newRow.SetCd = Utility.Saiban.GetKeyRenban("SuishitsuKensaSetMst", "", "", "").PadLeft(3, '0');
            // UPD 20140724 END ZynasSou

            // セット名称(正式）(2)
            newRow.SetNmRyakusho = setNmRyakushoTextBox.Text;

            // セット名称（略称）(3)
            newRow.SetNm = setNmTextBox.Text;

            // セット料金(4)
            newRow.SetRyoukin = Convert.ToDecimal(setRyoukinTextBox.Text);

            //20150126 HuyTX Ver1.02 Mod
            //// TODO 20141120 HotFix
            //// TODO 非会員料金を画面項目に追加する必要がある
            //newRow.SetHikaiinRyoukin = Convert.ToDecimal("0");
            newRow.SetHikaiinRyoukin = Convert.ToDecimal(setHikaiinRyoukinTextBox.Text);
            //End


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
            table.AddSuishitsuKensaSetMstRow(newRow);

            // 行の状態を設定
            newRow.AcceptChanges();

            // 行の状態を設定（新規）
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateSuishitsuKensaSetMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuKensaSetMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <returns>SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable CreateSuishitsuKensaSetMstUpdate(SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable table)
        {
            // セットコード(1)
            table[0].SetCd = setCdTextBox.Text;

            // セット名称(正式）(2)
            table[0].SetNmRyakusho = setNmRyakushoTextBox.Text;

            // セット名称（略称）(3)
            table[0].SetNm = setNmTextBox.Text;

            // セット料金(4)
            table[0].SetRyoukin = Convert.ToDecimal(setRyoukinTextBox.Text);

            //20150126 HuyTX Ver1.02 Add
            //セット非会員料金
            table[0].SetHikaiinRyoukin = Convert.ToDecimal(setHikaiinRyoukinTextBox.Text);
            //End

            // 更新者
            table[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            table[0].UpdateTarm = Dns.GetHostName();

            return table;
        }
        #endregion

        #region CreateSetShikenKomokuMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSetShikenKomokuMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <returns>SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable CreateSetShikenKomokuMstInsert(SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable setMstDT)
        {
            // Instance a new table
            SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable table = new SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable();

            // Get current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();

            // Get login user
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // Get host name
            string host = Dns.GetHostName();

            foreach (DataGridViewRow dgvr in setShikenListDataGridView.Rows)
            {
                // Skip the null last row
                if (dgvr.Index == setShikenListDataGridView.Rows.Count - 1) break;

                // Create a new row
                SetShikenKomokuMstDataSet.SetShikenKomokuMstRow newRow = table.NewSetShikenKomokuMstRow();

                // セットコード(7)
                //newRow.SetKomokuSetCd = setCdTextBox.Text;
                newRow.SetKomokuSetCd = setMstDT[0].SetCd;

                // セット試験項目コード(8)
                newRow.SetKomokuCd = dgvr.Cells[SetKomokuCdCol.Name].Value.ToString();

                // 証明書記載区分(11)
                newRow.ShomeishoKisaiKbn = !string.IsNullOrEmpty(dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString()) ?
                    dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString() : "2";

                // 請求有無区分(12)
                newRow.SetKomokuSeikyuUmuKbn = !string.IsNullOrEmpty(dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString()) ?
                    dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString() : "2";

                // 登録日時
                newRow.InsertDt = now;

                // 登録者
                newRow.InsertUser = user;

                // 登録端末
                newRow.InsertTarm = host;

                // 更新日時
                newRow.UpdateDt = now;

                // 更新者
                newRow.UpdateUser = user;

                // 更新端末
                newRow.UpdateTarm = host;

                // 行を挿入
                table.AddSetShikenKomokuMstRow(newRow);

                // 行の状態を設定
                newRow.AcceptChanges();

                // 行の状態を設定（新規）
                newRow.SetAdded();
            }

            return table;
        }
        #endregion

        #region CreateSetShikenKomokuMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSetShikenKomokuMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <returns>SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  AnhNV　　    新規作成
        /// 2015/01/28  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable CreateSetShikenKomokuMstUpdate(SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable table)
        {
            // Get current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();

            // Get login user
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            //Ver1.02 Add Start
            SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable updateDT = new SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable();
            SetShikenKomokuMstDataSet.SetShikenKomokuMstRow[] updateRows;
            //Ver1.02 Add End

            // Sort the dgv before update
            setShikenListDataGridView.Sort(this.setShikenListDataGridView.Columns["SetKomokuCdCol"], ListSortDirection.Ascending);

            foreach (DataGridViewRow dgvr in setShikenListDataGridView.Rows)
            {
                // Skip the last row of dgv
                if (dgvr.Index == setShikenListDataGridView.Rows.Count - 1) break;

                #region Remove Ver1.02 HuyTX 
                //// User add more rows
                //if (dgvr.Index > table.Count - 1)
                //{
                //    // Create a new row
                //    SetShikenKomokuMstDataSet.SetShikenKomokuMstRow newRow = table.NewSetShikenKomokuMstRow();

                //    // セットコード(7)
                //    newRow.SetKomokuSetCd = setCdTextBox.Text;

                //    // セット試験項目コード(8)
                //    newRow.SetKomokuCd = dgvr.Cells[SetKomokuCdCol.Name].Value.ToString();

                //    // 証明書記載区分(11)
                //    newRow.ShomeishoKisaiKbn = !string.IsNullOrEmpty(dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString()) ?
                //        dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString() : "2";

                //    // 請求有無区分(12)
                //    newRow.SetKomokuSeikyuUmuKbn = !string.IsNullOrEmpty(dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString()) ?
                //        dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString() : "2";

                //    // 登録日時
                //    newRow.InsertDt = now;

                //    // 登録者
                //    newRow.InsertUser = user;

                //    // 登録端末
                //    newRow.InsertTarm = host;

                //    // 更新日時
                //    newRow.UpdateDt = now;

                //    // 更新者
                //    newRow.UpdateUser = user;

                //    // 更新端末
                //    newRow.UpdateTarm = host;

                //    // 行を挿入
                //    table.AddSetShikenKomokuMstRow(newRow);

                //    // 行の状態を設定
                //    newRow.AcceptChanges();

                //    // 行の状態を設定（新規）
                //    newRow.SetAdded();
                //}
                //else
                //{
                //    // セット試験項目コード(8)
                //    table[dgvr.Index].SetKomokuCd = dgvr.Cells[SetKomokuCdCol.Name].Value.ToString();

                //    // 証明書記載区分(11)
                //    table[dgvr.Index].ShomeishoKisaiKbn = !string.IsNullOrEmpty(dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString()) ?
                //        dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString() : "2";

                //    // 請求有無区分(12)
                //    table[dgvr.Index].SetKomokuSeikyuUmuKbn = !string.IsNullOrEmpty(dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString()) ?
                //        dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString() : "2";

                //    // 更新日時
                //    table[dgvr.Index].UpdateDt = now;

                //    // 更新者
                //    table[dgvr.Index].UpdateUser = user;

                //    // 更新端末
                //    table[dgvr.Index].UpdateTarm = host;
                //}
                #endregion

                //Ver1.02 Add Start
                updateRows = (SetShikenKomokuMstDataSet.SetShikenKomokuMstRow[])table.Select(string.Format("SetKomokuSetCd = '{0}' AND SetKomokuCd = '{1}'", 
                                                                                                setCdTextBox.Text, dgvr.Cells[SetKomokuCdCol.Name].Value.ToString()));
                if (updateRows != null && updateRows.Length > 0)
                {
                    // セット試験項目コード(8)
                    //table[dgvr.Index].SetKomokuCd = dgvr.Cells[SetKomokuCdCol.Name].Value.ToString();

                    // 証明書記載区分(11)
                    updateRows[0].ShomeishoKisaiKbn = !string.IsNullOrEmpty(dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString()) ?
                        dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString() : "2";

                    // 請求有無区分(12)
                    updateRows[0].SetKomokuSeikyuUmuKbn = !string.IsNullOrEmpty(dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString()) ?
                        dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString() : "2";

                    // 更新日時
                    updateRows[0].UpdateDt = now;

                    // 更新者
                    updateRows[0].UpdateUser = user;

                    // 更新端末
                    updateRows[0].UpdateTarm = host;

                    updateDT.ImportRow(updateRows[0]);
                }
                else
                {
                    // Create a new row
                    SetShikenKomokuMstDataSet.SetShikenKomokuMstRow newRow = updateDT.NewSetShikenKomokuMstRow();

                    // セットコード(7)
                    newRow.SetKomokuSetCd = setCdTextBox.Text;

                    // セット試験項目コード(8)
                    newRow.SetKomokuCd = dgvr.Cells[SetKomokuCdCol.Name].Value.ToString();

                    // 証明書記載区分(11)
                    newRow.ShomeishoKisaiKbn = !string.IsNullOrEmpty(dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString()) ?
                        dgvr.Cells[ShomeishoKisaiKbnCol.Name].Value.ToString() : "2";

                    // 請求有無区分(12)
                    newRow.SetKomokuSeikyuUmuKbn = !string.IsNullOrEmpty(dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString()) ?
                        dgvr.Cells[SetKomokuSeikyuUmuKbnCol.Name].Value.ToString() : "2";

                    // 登録日時
                    newRow.InsertDt = now;

                    // 登録者
                    newRow.InsertUser = user;

                    // 登録端末
                    newRow.InsertTarm = host;

                    // 更新日時
                    newRow.UpdateDt = now;

                    // 更新者
                    newRow.UpdateUser = user;

                    // 更新端末
                    newRow.UpdateTarm = host;

                    // 行を挿入
                    updateDT.AddSetShikenKomokuMstRow(newRow);

                    // 行の状態を設定
                    newRow.AcceptChanges();

                    // 行の状態を設定（新規）
                    newRow.SetAdded();
                }
                //Ver1.02 Add End
            }

            //return table;
            return updateDT;
        }
        #endregion

        #region setShikenListDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： setShikenListDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setShikenListDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (setShikenListDataGridView.CurrentCell.ColumnIndex == 8)
            {
                if (!DecimalTextBoxCheck(e.KeyChar, sender as TextBox))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
        #endregion

        #region DecimalTextBoxCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DecimalTextBoxCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="textBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DecimalTextBoxCheck(char character, TextBox textBox)
        {
            if (!char.IsControl(character)
                && !char.IsDigit(character))
            {
                return false;
            }

            return true;
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
        /// 2015/01/26　HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            //セット試験項目コード
            setShikenListDataGridView.SetStdControlDomain(SetKomokuCdCol.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_CD, 3);
        }
        #endregion

        #endregion
    }
    #endregion
}
