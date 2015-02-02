using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.GyoshaMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GyoshaMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/02　AnhNV  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GyoshaMstShosaiForm : FukjBaseForm
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
        /// 一括請求先コード leave ok?
        /// </summary>
        private bool _isLeaveOK = true;

        /// <summary>
        /// 業者コード
        /// </summary>
        private string _gyoshaCd = string.Empty;

        /// <summary>
        /// GyoshaMstDataTable
        /// </summary>
        private GyoshaMstDataSet.GyoshaMstDataTable _gyoshaMst = new GyoshaMstDataSet.GyoshaMstDataTable();

        /// <summary>
        /// GyoshaMstDataTable
        /// </summary>
        private GyoshaMstDataSet.GyoshaMstDataTable _gyoshaInfoMst = new GyoshaMstDataSet.GyoshaMstDataTable();

        /// <summary>
        /// GyoshaMstDataTable
        /// </summary>
        private GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable _gyoshaBukaiMst = new GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable();

        /// <summary>
        /// GyoshaEigyoChikuMstDataTable
        /// </summary>
        private GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable _gyoshaEigyoChikuMst = new GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable();

        /// <summary>
        /// GyoshaEigyoshoMstDataTable
        /// </summary>
        private GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstDataTable _gyoshaEigyoshoMst = new GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstDataTable();

        // ADD 20140804 START ZynasSou
        /// <summary>
        /// 業者営業所の最大行数
        /// </summary>
        private int _gyoshaEigyoshoMaxRows = 9;
        // ADD 20140804 END ZynasSou

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GyoshaMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　AnhNV  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GyoshaMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GyoshaMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　AnhNV  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GyoshaMstShosaiForm(string gyoshaCd)
        {
            this._gyoshaCd = gyoshaCd;
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region GyoshaMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GyoshaMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Title for Add mode
                this.Text = "業者マスタ登録";

                // Detail mode
                if (!string.IsNullOrEmpty(this._gyoshaCd))
                {
                    this._dispMode = DispMode.Detail;
                    this.Text = "業者マスタ詳細";
                }

                // Load default values
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

        #region GyoshaMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GyoshaMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
                        if (_isLeaveOK) entryButton.PerformClick();
                        break;
                    case Keys.F2:
                        changeButton.Focus();
                        if (_isLeaveOK) changeButton.PerformClick();
                        break;
                    case Keys.F3:
                        deleteButton.Focus();
                        if (_isLeaveOK) deleteButton.PerformClick();
                        break;
                    case Keys.F4:
                        reInputButton.Focus();
                        if (_isLeaveOK) reInputButton.PerformClick();
                        break;
                    case Keys.F5:
                        decisionButton.Focus();
                        if (_isLeaveOK) decisionButton.PerformClick();
                        break;
                    case Keys.F12:
                        closeButton.Focus();
                        //if (_isLeaveOK) closeButton.PerformClick();
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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
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
                    delInput.GyoshaCd = gyoshaCdTextBox.Text;
                    IDeleteBtnClickALOutput delOutput = new DeleteBtnClickApplicationLogic().Execute(delInput);

                    // GyoshaCd does not exist
                    if (!string.IsNullOrEmpty(delOutput.ErrMsg))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, delOutput.ErrMsg);
                        return;
                    }

                    // Close this screen and back to GyoshaMstList form
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
        /// 2014/07/02　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._dispMode = string.IsNullOrEmpty(_gyoshaCd) ? DispMode.Add : DispMode.Edit;

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
        /// 2014/07/02　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Mode control
                this._dispMode = string.IsNullOrEmpty(this._gyoshaCd) ? DispMode.Add : DispMode.Edit;

                // Update success
                if (DoUpdate())
                {
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
        /// 2014/07/02　AnhNV　　    新規作成
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
                if (string.IsNullOrEmpty(_gyoshaCd))
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

        #region dataWatashiFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： dataWatashiFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void dataWatashiFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (dataWatashiFlgCheckBox.Checked)
                {
                    // Enable 業者送付データグループ(33)
                    gyoshaSofuDataGroupBox.Enabled = true;
                    return;
                }

                // Disable 業者送付データグループ(33)
                gyoshaSofuDataGroupBox.Enabled = false;
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

        #region zenEigyoKuikiFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zenEigyoKuikiFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zenEigyoKuikiFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (zenEigyoKuikiFlgCheckBox.Checked)
                {
                    // Enable 業者営業地区一覧データグリッドビュー(68)
                    // UPD START 20140718 ZynasSou
                    //DgvVisibleControl(gyoshaEigyoChikuListDataGridView, true);
                    DgvVisibleControl(gyoshaEigyoChikuListDataGridView, false);
                    // UPD END 20140718 ZynasSou
                    return;
                }

                // Disable 業者営業地区一覧データグリッドビュー(68)
                // UPD START 20140718 ZynasSou
                //DgvVisibleControl(gyoshaEigyoChikuListDataGridView, false);
                DgvVisibleControl(gyoshaEigyoChikuListDataGridView, true);
                // UPD END 20140718 ZynasSou
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

        #region gyoshaEigyoshoListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaEigyoshoListDataGridView_EditingControlShowing
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
        private void gyoshaEigyoshoListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex == 1
                    || gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex == 3
                    || gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex == 5
                    || gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex >= 6)
                {
                    gyoshaEigyoshoListDataGridView.ImeMode = ImeMode.Disable;
                    e.Control.KeyPress += new KeyPressEventHandler(gyoshaEigyoshoListDataGridView_ControlKeyPress);
                }
                else
                {
                    gyoshaEigyoshoListDataGridView.ImeMode = ImeMode.On;
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

        #region gyoshaEigyoChikuListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaEigyoChikuListDataGridView_EditingControlShowing
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
        private void gyoshaEigyoChikuListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                e.Control.KeyPress += new KeyPressEventHandler(gyoshaEigyoChikuListDataGridView_ControlKeyPress);
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

        #region gyoshaBukaiListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaBukaiListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10　AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaBukaiListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //if (gyoshaBukaiListDataGridView.CurrentCell.ColumnIndex != 5)
                //{
                //    e.Control.KeyPress += new KeyPressEventHandler(gyoshaBukaiListDataGridView_ControlKeyPress);
                //}
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

        #region sanjokaihiTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sanjokaihiTextBox_KeyPress
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
        private void sanjokaihiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                    /*&& e.KeyChar != '.'*/)
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                //if (e.KeyChar == '.'
                //    && (sender as TextBox).Text.IndexOf('.') > -1)
                //{
                //    e.Handled = true;
                //}
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

        #region gyoshaEigyoshoListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaEigyoshoListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoshoListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Current date time in DB
                DateTime now = Common.Common.GetCurrentTimestamp();

                // Get user name
                string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                // Get host name
                string host = Dns.GetHostName();

                // Set value for hidden columns in datagridviews
                BindingNewSourceForDgv(now, username, host);

                // Highlight duplicate rows
                DuplicationCheck(gyoshaEigyoshoListDataGridView, gyoshaEigyoshoRenbanCol.Name, false);
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

        #region gyoshaEigyoChikuListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaEigyoChikuListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoChikuListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Current date time in DB
                DateTime now = Common.Common.GetCurrentTimestamp();

                // Get user name
                string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                // Get host name
                string host = Dns.GetHostName();

                // Set value for hidden columns in datagridviews
                BindingNewSourceForDgv(now, username, host);

                // DEL 20140804 START ZynasSou
                //// Highlight duplicate rows
                //DuplicationCheck(gyoshaEigyoChikuListDataGridView, "GyoshaEigyoChikuRenbanCol.Name, false);
                // DEL 20140804 START ZynasSou
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

        #region gyoshaBukaiListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaBukaiListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15　AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaBukaiListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //// Current date time in DB
                //DateTime now = Common.Common.GetCurrentTimestamp();

                //// Get user name
                //string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                //// Get host name
                //string host = Dns.GetHostName();

                //// Set value for hidden columns in datagridviews
                //BindingNewSourceForDgv(now, username, host);

                //// Highlight duplicate rows
                //DuplicationCheck(gyoshaBukaiListDataGridView, "bukaiRenbanCol.Name, false);
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

        #region gyoshaZipCdTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaZipCdTextBox_KeyPress
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
        private void gyoshaZipCdTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        #region telTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： telTextBox_KeyPress
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
        private void telTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        #region gyoshaEigyoshoListDataGridView_UserAddedRow
        // ADD 20140804 START ZynasSou
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： 業者営業所リストの行追加後
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/04　宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoshoListDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            // 最大行数判定
            dgvMaxRowsCheck(gyoshaEigyoshoListDataGridView, _gyoshaEigyoshoMaxRows);

            // 初期値設定
            foreach(DataGridViewCell cell in gyoshaEigyoshoListDataGridView.SelectedCells)
            {
                // 連番に行番号+1を設定
                gyoshaEigyoshoListDataGridView[1, cell.RowIndex].Value = cell.RowIndex + 1;
            }
        }
        // ADD 20140804 END ZynasSou
        #endregion

        #region gyoshaEigyoshoListDataGridView_UserDeletedRow
        // ADD 20140804 START ZynasSou
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： 業者営業所リストの行削除後
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/04　宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoshoListDataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            // 最大行数判定
            dgvMaxRowsCheck(gyoshaEigyoshoListDataGridView, _gyoshaEigyoshoMaxRows);
        }
        // ADD 20140804 END ZynasSou
        #endregion

        #region gyoshaEigyoshoListDataGridView_CellEnter
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaEigyoshoListDataGridView_CellEnter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14　宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoshoListDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Control the IME mode of datagridview
                if (gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex == 1
                    || gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex == 3
                    || gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex == 5
                    || gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex >= 6)
                {
                    gyoshaEigyoshoListDataGridView.ImeMode = ImeMode.Disable;
                }
                else
                {
                    gyoshaEigyoshoListDataGridView.ImeMode = ImeMode.On;
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

        #region gyoshaBukaiListDataGridView_CellEnter
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaBukaiListDataGridView_CellEnter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14　宗　　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaBukaiListDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Control the IME mode of datagridview
                //if (gyoshaBukaiListDataGridView.CurrentCell.ColumnIndex == 5)
                //{
                //    gyoshaBukaiListDataGridView.ImeMode = ImeMode.On;
                //}
                //else
                //{
                //    gyoshaBukaiListDataGridView.ImeMode = ImeMode.Disable;
                //}
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

        #region sanjokaihiTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sanjokaihiTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void sanjokaihiTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(sanjokaihiTextBox.Text.Trim())) return;
                sanjokaihiTextBox.Text = Convert.ToDecimal(sanjokaihiTextBox.Text).ToString("N0");
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

        #region gyoshaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open 000-003
                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ikkatsuSeikyuSakiCdTextBox.Text = frm._selectedRow.GyoshaCd;
                    ikkatsuSeikyuSakiGyoshaNmTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region ikkatsuSeikyuSakiCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ikkatsuSeikyuSakiCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ikkatsuSeikyuSakiCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handler for empty value
                if (string.IsNullOrEmpty(ikkatsuSeikyuSakiCdTextBox.Text)) return;

                string gyoshaCd = ikkatsuSeikyuSakiCdTextBox.Text.PadLeft(4, '0');
                GyoshaMstDataSet.GyoshaMstRow[] gyoshaRow = (GyoshaMstDataSet.GyoshaMstRow[])_gyoshaInfoMst.Select(string.Format("GyoshaCd = '{0}'", gyoshaCd));

                // No record exist?
                if (gyoshaRow.Length > 0)
                {
                    ikkatsuSeikyuSakiCdTextBox.Text = gyoshaCd;
                    ikkatsuSeikyuSakiGyoshaNmTextBox.Text = gyoshaRow[0].GyoshaNm;
                }
                else
                {
                    // Error message
                    MessageForm.Show2(MessageForm.DispModeType.Error, "業者マスタに存在しません。");
                    // Clear gyosha textbox
                    ikkatsuSeikyuSakiCdTextBox.Text = string.Empty;
                    ikkatsuSeikyuSakiGyoshaNmTextBox.Text = string.Empty;
                    _isLeaveOK = false;
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

        #region gyoshaEigyoshoListDataGridView_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaEigyoshoListDataGridView_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.08
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoshoListDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Is Delete key pressed
                if (e.KeyData != Keys.Delete) { return; }
                // Is disable?
                if (_dispMode == DispMode.Detail || _dispMode == DispMode.Confirm) { return; }
                // Last row in dgv?
                if (gyoshaEigyoshoListDataGridView.CurrentRow.Index == gyoshaEigyoshoListDataGridView.Rows.Count - 1) { return; }

                // Perform a deletion action
                int curIdx = gyoshaEigyoshoListDataGridView.CurrentRow.Index;
                int rowCnt = gyoshaEigyoshoListDataGridView.Rows.Count;
                DataGridViewRow curRow = gyoshaEigyoshoListDataGridView.CurrentRow;
                int curValue = Convert.ToInt32(curRow.Cells[gyoshaEigyoshoRenbanCol.Name].Value);
                if (curIdx < rowCnt - 2)
                {
                    for (int i = curIdx; i < rowCnt - 2; i++)
                    {
                        // Set new order value for the row which stand before deleted row
                        gyoshaEigyoshoListDataGridView.Rows[i + 1].Cells[gyoshaEigyoshoRenbanCol.Name].Value = curValue;

                        if (curValue < 9)
                        {
                            curValue++;
                        }
                    }

                    // Delete selected row
                    gyoshaEigyoshoListDataGridView.Rows.Remove(curRow);
                }
                else // Last row which contains data
                {
                    gyoshaEigyoshoListDataGridView.Rows.Remove(gyoshaEigyoshoListDataGridView.CurrentRow);
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
        /// 2014/07/02  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// 2015/01/30　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.08
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.GyoshaCd = (this._dispMode == DispMode.Add) ? string.Empty : this._gyoshaCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            _gyoshaInfoMst = alOutput.GyoshaMstInfoDataTable;

            // Combobox 支払区分(43)
            Utility.Utility.SetComboBoxList(shiharaiKbnComboBox, alOutput.ConstMstDataTable, "ConstValue", "ConstRenban", true);
            // v1.08 AnhNV ADD Start
            DataTable toriatsuCbSource = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_075);
            // 取扱業者区分
            Utility.Utility.SetComboBoxList(toriatsukaiGyoshaKbnComboBox, toriatsuCbSource, "ConstNm", "ConstValue", true);
            // v1.08 AnhNV ADD End

            // Display default value in Detail mode
            if (this._dispMode == DispMode.Detail)
            {
                _gyoshaMst = alOutput.GyoshaMstDataTable;
                _gyoshaBukaiMst = alOutput.GyoshaBukaiMstDataTable;
                _gyoshaEigyoChikuMst = alOutput.GyoshaEigyoChikuMstDataTable;
                _gyoshaEigyoshoMst = alOutput.GyoshaEigyoshoMstDataTable;

                // Disable 業者営業地区一覧データグリッドビュー(68)
                // UPD START 20140718 ZynasSou
                //DgvVisibleControl(gyoshaEigyoChikuListDataGridView, _gyoshaMst[0].ZenEigyoKuikiFlg == "1" ? true : false);
                DgvVisibleControl(gyoshaEigyoChikuListDataGridView, false);
                // UPD END 20140718 ZynasSou

                // Disable 業者送付データグループ(33)
                gyoshaSofuDataGroupBox.Enabled = _gyoshaMst[0].ShiharaiKbn == "1" ? true : false;

                // Default value
                DisplayDefault();
            }
            else // Add mode
            {
                // Disable 業者営業地区一覧データグリッドビュー(68)
                // UPD START 20140718 ZynasSou
                //DgvVisibleControl(gyoshaEigyoChikuListDataGridView, false);
                DgvVisibleControl(gyoshaEigyoChikuListDataGridView, true);
                // UPD END 20140718 ZynasSou

                // Disable 業者送付データグループ(33)
                gyoshaSofuDataGroupBox.Enabled = false;
            }

            // Remove constrains before bind to dgv
            RemoveDgvSourceConstraints();

            // Binding source to datagridviews
            gyoshaEigyoshoListDataGridView.DataSource = _gyoshaEigyoshoMst;
            gyoshaEigyoChikuListDataGridView.DataSource = _gyoshaEigyoChikuMst;
            //gyoshaBukaiListDataGridView.DataSource = _gyoshaBukaiMst;

            // ADD 20140724 START ZynasSou
            gyoshaBukaiListInitialize();
            // ADD 20140724 START ZynasSou

            // ADD 20140804 START ZynasSou
            dgvMaxRowsCheck(gyoshaEigyoshoListDataGridView, _gyoshaEigyoshoMaxRows);
            // ADD 20140804 END ZynasSou

            // Unlimit input for datagridviews
            SetUnlimitInputForDgv();
        }
        #endregion

        // ADD 20140724 START ZynasSou
        #region gyoshaBukaiListInitialize
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： gyoshaBukaiListInitialize
        /// <summary>
        /// 業者部会リストの初期化
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  宗　　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaBukaiListInitialize()
        {
            // ユーザーの行追加禁止
            //gyoshaBukaiListDataGridView.AllowUserToAddRows = false;

            // 新規時レコード追加
            if (_dispMode == DispMode.Add)
            {
                // 業者部会リスト4行固定
                for (int row = 0; row < 4; row++)
                {
                    GyoshaBukaiMstDataSet.GyoshaBukaiMstRow newRow = _gyoshaBukaiMst.NewGyoshaBukaiMstRow();
                    // 部会区分
                    newRow.BukaiKbn = (row + 1).ToString();
                    // 行を挿入
                    _gyoshaBukaiMst.AddGyoshaBukaiMstRow(newRow);
                    // 行の状態を設定
                    newRow.AcceptChanges();
                    // 行の状態を設定（新規）
                    newRow.SetAdded();
                }
            }
            // 部会名表示
            // ※DataSet未連携の項目だと表示できない？　ラベル＆並べ替え無効で対応
            //foreach(DataGridViewRow dgvr in gyoshaBukaiListDataGridView.Rows)
            //{
            //    switch (dgvr.Cells[bukaiRenbanCol.Name].Value.ToString())
            //    {
            //        case "1":
            //            dgvr.Cells[bukaiNameCol.Name].Value = "製造部会";
            //            break;
            //        case "2":
            //            dgvr.Cells[bukaiNameCol.Name].Value = "工事部会";
            //            break;
            //        case "3":
            //            dgvr.Cells[bukaiNameCol.Name].Value = "保守部会";
            //            break;
            //        case "4":
            //            dgvr.Cells[bukaiNameCol.Name].Value = "清掃部会";
            //            break;
            //    }
            //}
            // 並べ替え無効
            //foreach (DataGridViewColumn col in gyoshaBukaiListDataGridView.Columns)
            //{
            //    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
        }
        #endregion
        // ADD 20140724 START ZynasSou

        #region SetScreenTitle
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetScreenTitle
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (_dispMode)
            {
                case DispMode.Detail:
                    Program.mForm.Text = "業者マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Add:
                    Program.mForm.Text = "業者マスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "業者マスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "業者マスタ変更";
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
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// 2014/11/04　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemControl()
        {
            #region Tab 1

            // 業者コード(7)
            // UPD 20140724 START ZynasSou
            //gyoshaCdTextBox.ReadOnly = _dispMode == DispMode.Add ? false : true;
            gyoshaCdTextBox.ReadOnly = true;
            // UPD 20140724 START ZynasSou

            // 業者名称(8)
            gyoshaNmTextBox.ReadOnly =

            // 業者カナ名(9)
            gyoshaKanaTextBox.ReadOnly =

            // 業者郵便番号(10)
            gyoshaZipCdTextBox.ReadOnly =

            // 業者住所(11)
            gyoshaAdrTextBox.ReadOnly =

            // 業者電話番号(12)
            gyoshaTelNoTextBox.ReadOnly =

            // 業者Fax番号(13)
            gyoshaFaxNoTextBox.ReadOnly =

            // 代表者氏名(14)
            daihyoshaNmTextBox.ReadOnly =

            // 工事登録番号(22)
            koujiTorokuNoTextBox.ReadOnly =

            // 県保守業者登録番号(23)
            kenHoshuGyoShaTorokuNoTextBox.ReadOnly =

            // 取扱業者コード(24)
            toriatsukaiGyoshaCdTextBox.ReadOnly =

            // 2014/11/04 AnhNV Add start
            // 福岡市登録番号(112)
            fukuokashiGyoShaTorokuNoTextBox.ReadOnly =

            // 久留米市登録番号(113)
            kurumeshiGyoShaTorokuNoTextBox.ReadOnly =
            // 2014/11/04 AnhNV Add End

            // メーカー名称(25)
            makerNmTextBox.ReadOnly = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? false : true;

            // 工事業者区分(16)
            kojiGyoshaKbnCheckBox.Enabled =

            // 保守業者区分(17)
            hoshuGyoshaKbnCheckBox.Enabled =

            // 取扱業者区分(18)
            toriatsukaiGyoshaKbnComboBox.Enabled =

            // 清掃業者区分(19)
            seisoGyoshaKbnCheckBox.Enabled =

            // 製造業者区分(20)
            seizoGyoShaKbnCheckBox.Enabled =

            // その他業者区分(21)
            sonotaGyoshaKbnCheckBox.Enabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false;

            #endregion

            #region Tab 2

            // 還付有無フラグ(27)
            kanpuUmuFlgCheckBox.Enabled =

            // データ渡フラグ(32)
            dataWatashiFlgCheckBox.Enabled =

            // 基本データフラグ(34)
            kihonDataFlgCheckBox.Enabled =

            // 水質データフラグ(35)
            suishitsuDataFlgCheckBox.Enabled =

            // 所見データフラグ(36)
            shokenDataFlgCheckBox.Enabled =

            // 外観データフラグ(37)
            gaikanDataFlgCheckBox.Enabled =

            // 書類検査データフラグ(38)
            shoruiDataFlgCheckBox.Enabled =

            // 5条データフラグ(39)
            jo5DataFlgCheckBox.Enabled =

            // 7条データフラグ(40)
            jo7DataFlgCheckBox.Enabled =

            // 11条水質データフラグ(41)
            jo11SuishitsuDataFlgCheckBox.Enabled =

            // 11条外観データフラグ(42)
            jo11GaikanDataFlgCheckBox.Enabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false;

            // 還付金集計先コード(28)
            kanpukinShukeisakiCdTextBox.ReadOnly =

            // 協同組合コード(29)
            kyodoKumiaiCdTextBox.ReadOnly =

            // 賛助会費(30)
            sanjokaihiTextBox.ReadOnly =

            // 送付先担当者氏名(31)
            sofusakiTantoshaNmTextBox.ReadOnly =

            // 2014/11/04 AnhNV Add start
            // 発送担当者(114)
            hassoTantoshaTextBox.ReadOnly = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? false : true;
            // 2014/11/04 AnhNV Add end

            #endregion

            #region Tab 3

            // UPD 20140718 ZynasSou
            //// 支払区分(43)
            //shiharaiKbnComboBox.Enabled =
            //
            //// 会員区分(51)
            //kaiinKbnCheckBox.Enabled =
            //
            //// 廃業フラグ(52)
            //haigyoFlgCheckBox.Enabled =
            //
            //// 請求分離フラグ(53)
            //seikyuBunriFlgCheckBox.Enabled =
            //
            //// 7条検査依頼一覧発行フラグ(54)
            //jo7KensaIraiIchiranHakkoFlgCheckBox.Enabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false;
            // 支払区分(43)
            shiharaiKbnComboBox.Enabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false;
            // UPD END 20140718 ZynasSou

            // ADD START 20140718 ZynasSou
            // 金融機関コード
            bankCdTextBox.ReadOnly =
            // ADD END 20140718 ZynasSou

            // 銀行名称(45)
            bankNmTextBox.ReadOnly =

            // ADD START 20140718 ZynasSou
            // 支店コード
            bankShitenCdTextBox.ReadOnly =
            // ADD END 20140718 ZynasSou

            // 銀行支店名称(46)
            bankShitenNmTextBox.ReadOnly =

            // 銀行口座種別名(47)
            bankKozaShubetsuNmTextBox.ReadOnly =

            // 銀行口座番号(48)
            bankKozaNoTextBox.ReadOnly =

            // 銀行口座名義(49)
            bankKozaMeigiTextBox.ReadOnly = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? false : true;

            // 会員価格適用区分(49-2)
            kaiinKbnCheckBox.Enabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false;

            // ADD 20140724 START ZynasSou
            // 廃業日(50)
            bukaiHaigyoDtTextBox.ReadOnly =

            // 廃業理由(51)
            bukaiHaigyoRiyuTextBox.ReadOnly = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? false : true;
            // ADD 20140724 END ZynasSou

            // 2014/11/04 AnhNV Add start
            // 一括請求先コード(115)
            ikkatsuSeikyuSakiCdTextBox.ReadOnly = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? false : true;
            // 一括請求先検索ボタン(117)
            gyoshaSearchButton.Visible = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false;
            // 2014/11/04 AnhNV Add end

            #endregion

            #region Tab 4

            // 業者営業所一覧データグリッドビュー
            DgvVisibleControl(gyoshaEigyoshoListDataGridView, (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false);
            #endregion

            #region Tab 5

            // 全営業区域フラグ(67)
            zenEigyoKuikiFlgCheckBox.Enabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false;

            // 業者営業地区一覧データグリッドビュー
            // UPD START 20140718 ZynasSou
            //DgvVisibleControl(gyoshaEigyoChikuListDataGridView, ((_dispMode == DispMode.Add || _dispMode == DispMode.Edit) && zenEigyoKuikiFlgCheckBox.Checked) ? true : false);
            DgvVisibleControl(gyoshaEigyoChikuListDataGridView, ((_dispMode == DispMode.Add || _dispMode == DispMode.Edit) && !zenEigyoKuikiFlgCheckBox.Checked) ? true : false);
            // UPD END 20140718 ZynasSou
            #endregion

            #region Tab 6

            // 業者部会一覧データグリッドビュー
            //DgvVisibleControl(gyoshaBukaiListDataGridView, (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? true : false);

            #endregion

            #region Buttons

            // 登録ボタン(106)
            entryButton.Visible = _dispMode == DispMode.Add ? true : false;

            // 変更ボタン(107)
            changeButton.Visible = (_dispMode == DispMode.Detail || _dispMode == DispMode.Edit) ? true : false;

            // 削除ボタン(108)
            deleteButton.Visible = _dispMode == DispMode.Detail ? true : false;

            // 再入力ボタン(109)
            reInputButton.Visible =

            // 確定ボタン(110)
            decisionButton.Visible = _dispMode == DispMode.Confirm ? true : false;

            #endregion
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
        /// 2014/07/02  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// 2014/11/04　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault()
        {
            #region Tab 1

            // 業者コード(7)
            gyoshaCdTextBox.Text = _gyoshaCd.Trim();

            // 業者名称(8)
            gyoshaNmTextBox.Text = _gyoshaMst[0].GyoshaNm;

            // 業者カナ名(9)
            gyoshaKanaTextBox.Text = _gyoshaMst[0].GyoshaKana;

            // 業者郵便番号(10)
            gyoshaZipCdTextBox.Text = _gyoshaMst[0].GyoshaZipCd.Trim();

            // 業者住所(11)
            gyoshaAdrTextBox.Text = _gyoshaMst[0].GyoshaAdr;

            // 業者電話番号(12)
            gyoshaTelNoTextBox.Text = _gyoshaMst[0].GyoshaTelNo.Trim();

            // 業者Fax番号(13)
            gyoshaFaxNoTextBox.Text = _gyoshaMst[0].GyoshaFaxNo.Trim();

            // 代表者氏名(14)
            daihyoshaNmTextBox.Text = _gyoshaMst[0].DaihyoshaNm;

            // 工事業者区分(16)
            kojiGyoshaKbnCheckBox.Checked = _gyoshaMst[0].KojiGyoshaKbn == "1" ? true : false;

            // 保守業者区分(17)
            hoshuGyoshaKbnCheckBox.Checked = _gyoshaMst[0].HoshuGyoshaKbn == "1" ? true : false;

            // 取扱業者区分(18)
            toriatsukaiGyoshaKbnComboBox.SelectedValue = _gyoshaMst[0].ToriatsukaiGyoshaKbn;

            // 清掃業者区分(19)
            seisoGyoshaKbnCheckBox.Checked = _gyoshaMst[0].SeisoGyoshaKbn == "1" ? true : false;

            // 製造業者区分(20)
            seizoGyoShaKbnCheckBox.Checked = _gyoshaMst[0].SeizoGyoShaKbn == "1" ? true : false;

            // その他業者区分(21)
            sonotaGyoshaKbnCheckBox.Checked = _gyoshaMst[0].SonotaGyoshaKbn == "1" ? true : false;

            // 工事登録番号(22)
            koujiTorokuNoTextBox.Text = _gyoshaMst[0].KoujiTorokuNo;

            // 県保守業者登録番号(23)
            kenHoshuGyoShaTorokuNoTextBox.Text = _gyoshaMst[0].KenHoshuGyoShaTorokuNo.Trim();

            // 取扱業者コード(24)
            toriatsukaiGyoshaCdTextBox.Text = _gyoshaMst[0].ToriatsukaiGyoshaCd.Trim();

            // メーカー名称(25)
            makerNmTextBox.Text = _gyoshaMst[0].MakerNm;

            // 2014/11/04 AnhNV Add start
            // 福岡市登録番号(112)
            fukuokashiGyoShaTorokuNoTextBox.Text = _gyoshaMst[0].FukuokashiGyoShaTorokuNo;
            // 久留米市登録番号(113)
            kurumeshiGyoShaTorokuNoTextBox.Text = _gyoshaMst[0].KurumeshiGyoShaTorokuNo;
            // 発送担当者(114)
            hassoTantoshaTextBox.Text = _gyoshaMst[0].HassoTantosha;
            // 一括請求先コード(115)
            ikkatsuSeikyuSakiCdTextBox.Text = _gyoshaMst[0].IkkatsuSeikyuSakiCd;
            // 一括請求先(116)
            string seikyuSakiCd = _gyoshaMst[0].IkkatsuSeikyuSakiCd;
            GyoshaMstDataSet.GyoshaMstRow[] gyoshaRow = (GyoshaMstDataSet.GyoshaMstRow[])_gyoshaInfoMst.Select(string.Format("GyoshaCd = '{0}'", seikyuSakiCd));
            ikkatsuSeikyuSakiGyoshaNmTextBox.Text = gyoshaRow.Length > 0 ? gyoshaRow[0].GyoshaNm : string.Empty;
            // 2014/11/04 AnhNV Add end

            #endregion

            #region Tab 2

            // 還付有無フラグ(27)
            kanpuUmuFlgCheckBox.Checked = _gyoshaMst[0].KanpuUmuFlg == "1" ? true : false;

            // 還付金集計先コード(28)
            kanpukinShukeisakiCdTextBox.Text = _gyoshaMst[0].KanpukinShukeisakiCd.Trim();

            // 協同組合コード(29)
            kyodoKumiaiCdTextBox.Text = _gyoshaMst[0].KyodoKumiaiCd.Trim();

            // 賛助会費(30)
            sanjokaihiTextBox.Text = _gyoshaMst[0].Sanjokaihi.ToString("N0");

            // 送付先担当者氏名(31)
            sofusakiTantoshaNmTextBox.Text = _gyoshaMst[0].SofusakiTantoshaNm;

            // データ渡フラグ(32)
            dataWatashiFlgCheckBox.Checked = _gyoshaMst[0].DataWatashiFlg == "1" ? true : false;

            // 基本データフラグ(34)
            kihonDataFlgCheckBox.Checked = _gyoshaMst[0].KihonDataFlg == "1" ? true : false;

            // 水質データフラグ(35)
            suishitsuDataFlgCheckBox.Checked = _gyoshaMst[0].SuishitsuDataFlg == "1" ? true : false;

            // 所見データフラグ(36)
            shokenDataFlgCheckBox.Checked = _gyoshaMst[0].ShokenDataFlg == "1" ? true : false;

            // 外観データフラグ(37)
            gaikanDataFlgCheckBox.Checked = _gyoshaMst[0].GaikanDataFlg == "1" ? true : false;

            // 書類検査データフラグ(38)
            shoruiDataFlgCheckBox.Checked = _gyoshaMst[0].ShoruiDataFlg == "1" ? true : false;

            // 5条データフラグ(39)
            jo5DataFlgCheckBox.Checked = _gyoshaMst[0]._5JoDataFlg == "1" ? true : false;

            // 7条データフラグ(40)
            jo7DataFlgCheckBox.Checked = _gyoshaMst[0]._7JoDataFlg == "1" ? true : false;

            // 11条水質データフラグ(41)
            jo11SuishitsuDataFlgCheckBox.Checked = _gyoshaMst[0]._11JoSuishitsuDataFlg == "1" ? true : false;

            // 11条外観データフラグ(42)
            jo11GaikanDataFlgCheckBox.Checked = _gyoshaMst[0]._11JoGaikanDataFlg == "1" ? true : false;

            #endregion

            #region Tab 3

            // 支払区分(43)
            shiharaiKbnComboBox.SelectedValue = _gyoshaMst[0].ShiharaiKbn;

            // ADD START 20140718 ZynasSou
            // 金融機関コード
            bankCdTextBox.Text = _gyoshaMst[0].BankCd.Trim();
            // ADD END 20140718 ZynasSou

            // 銀行名称(45)
            bankNmTextBox.Text = _gyoshaMst[0].BankNm;

            // ADD START 20140718 ZynasSou
            // 支店コード
            bankShitenCdTextBox.Text = _gyoshaMst[0].BankShitenCd.Trim();
            // ADD END 20140718 ZynasSou

            // 銀行支店名称(46)
            bankShitenNmTextBox.Text = _gyoshaMst[0].BankShitenNm;

            // 銀行口座種別名(47)
            bankKozaShubetsuNmTextBox.Text = _gyoshaMst[0].BankKozaShubetsuNm;

            // 銀行口座番号(48)
            bankKozaNoTextBox.Text = _gyoshaMst[0].BankKozaNo.Trim();

            // 銀行口座名義(49)
            bankKozaMeigiTextBox.Text = _gyoshaMst[0].BankKozaMeigi;

            // DEL START 20140718 ZynasSou
            //// 会員区分(51)
            //kaiinKbnCheckBox.Checked = _gyoshaMst[0].KaiinKbn == "1" ? true : false;
            //
            //// 廃業フラグ(52)
            //haigyoFlgCheckBox.Checked = _gyoshaMst[0].HaigyoFlg == "1" ? true : false;
            //
            //// 請求分離フラグ(53)
            //seikyuBunriFlgCheckBox.Checked = _gyoshaMst[0].SeikyuBunriFlg == "1" ? true : false;
            //
            //// 7条検査依頼一覧発行フラグ(54)
            //jo7KensaIraiIchiranHakkoFlgCheckBox.Checked = _gyoshaMst[0]._7JoKensaIraiIchiranHakkoFlg == "1" ? true : false;
            // DEL END 20140718 ZynasSou

            // ADD 20140724 START ZynasSou
            // 廃業日(50)
            bukaiHaigyoDtTextBox.Text = _gyoshaMst[0].HaigyoDt.Trim();

            // 廃業理由(51)
            bukaiHaigyoRiyuTextBox.Text = _gyoshaMst[0].HaigyoRiyu;
            // ADD 20140724 END ZynasSou

            // 会員価格適用区分(49-2)
            kaiinKbnCheckBox.Checked = _gyoshaMst[0].KaiinKbn == "1" ? true : false;

            #endregion

            // 全営業区域フラグ(67)
            zenEigyoKuikiFlgCheckBox.Checked = _gyoshaMst[0].ZenEigyoKuikiFlg == "1" ? true : false;
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
        /// 2014/07/02  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // ADD 20140728 START ZynasSou
            // タブ名
            string Base1TabNm = Gyosha1TabPage.Text;
            string Base2TabNm = Gyosha2TabPage.Text;
            string Base3TabNm = Gyosha3TabPage.Text;
            string EigyoshoTabNm = GyoshaEigyoshoTabPage.Text;
            string EigyoChikuTabNm = GyoshaEigyoChikuTabPage.Text;
            //string EigyoBukaiTabNm = EigyoBukaiTabPage.Text;
            // ADD 20140728 START ZynasSou

            #region 基本情報1 tab

            // DEL 20140724 START ZynasSou
            //// 業者コード(7)
            //if (string.IsNullOrEmpty(gyoshaCdTextBox.Text.Trim()))
            //{
            //    errMsg.AppendLine("必須項目：業者コードが入力されていません。");
            //}
            //else if (!Utility.Utility.IsDecimal(gyoshaCdTextBox.Text))
            //{
            //    errMsg.AppendLine("業者コードは半角数字で入力して下さい。");
            //}
            //else if (gyoshaCdTextBox.Text.Length != 4)
            //{
            //    errMsg.AppendLine("業者コードは4桁で入力して下さい。");
            //}
            // DEL 20140724 START ZynasSou

            // 業者名称(8)
            if (string.IsNullOrEmpty(gyoshaNmTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("必須項目：業者名称が入力されていません。");
                errMsg.AppendLine(string.Format("必須項目：{0}の業者名称が入力されていません。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (gyoshaNmTextBox.Text.Length > 40)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者名称は40文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の業者名称は40文字以下で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 業者カナ名(9)
            if (string.IsNullOrEmpty(gyoshaKanaTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("必須項目：業者カナ名が入力されていません。");
                errMsg.AppendLine(string.Format("必須項目：{0}の業者カナ名が入力されていません。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (gyoshaKanaTextBox.Text.Length > 40)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者カナ名は40文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の業者カナ名は40文字以下で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 業者郵便番号(10)
            if (string.IsNullOrEmpty(gyoshaZipCdTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("必須項目：業者郵便番号が入力されていません。");
                //errMsg.AppendLine(string.Format("必須項目：{0}の業者郵便番号が入力されていません。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (gyoshaZipCdTextBox.Text.Length != 8)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者郵便番号は8桁で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の業者郵便番号は8桁で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (!Utility.Utility.IsNumAndNegative(gyoshaZipCdTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者郵便番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の業者郵便番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (!Utility.Utility.IsZipCode(gyoshaZipCdTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者郵便番号の形式が不正です。");
                errMsg.AppendLine(string.Format("{0}の業者郵便番号の形式が不正です。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 業者住所(11)
            if (string.IsNullOrEmpty(gyoshaAdrTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("必須項目：業者住所が入力されていません。");
                //errMsg.AppendLine(string.Format("必須項目：{0}の業者住所が入力されていません。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (gyoshaAdrTextBox.Text.Length > 80)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者住所は80文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の業者住所は80文字以下で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 業者電話番号(12)
            if (string.IsNullOrEmpty(gyoshaTelNoTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("必須項目：業者電話番号が入力されていません。");
                //errMsg.AppendLine(string.Format("必須項目：{0}の業者電話番号が入力されていません。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (gyoshaTelNoTextBox.Text.Length < 12)
            {
                errMsg.AppendLine(string.Format("{0}の業者電話番号は12～13桁で入力して下さい。", Base1TabNm));
            }
            //else if (gyoshaTelNoTextBox.Text.Length != 13)
            //{
            //    // UPD 20140729 START ZynasSou
            //    //errMsg.AppendLine("業者電話番号は13桁で入力して下さい。");
            //    errMsg.AppendLine(string.Format("{0}の業者電話番号は13桁で入力して下さい。", Base1TabNm));
            //    // UPD 20140729 END ZynasSou
            //}
            else if (!Utility.Utility.IsNumAndNegative(gyoshaTelNoTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者電話番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の業者電話番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            //else if (!Utility.Utility.IsPhoneNumber(gyoshaTelNoTextBox.Text))
            //{
            //    // UPD 20140729 START ZynasSou
            //    //errMsg.AppendLine("業者電話番号の形式が不正です。");
            //    errMsg.AppendLine(string.Format("{0}の業者電話番号の形式が不正です。", Base1TabNm));
            //    // UPD 20140729 END ZynasSou
            //}

            // 業者Fax番号(13)
            if (string.IsNullOrEmpty(gyoshaFaxNoTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("必須項目：業者Fax番号が入力されていません。");
                //errMsg.AppendLine(string.Format("必須項目：{0}の業者Fax番号が入力されていません。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (gyoshaFaxNoTextBox.Text.Length < 12)
            {
                errMsg.AppendLine(string.Format("{0}の業者Fax番号は12～13桁で入力して下さい。", Base1TabNm));
            }
            //else if (gyoshaFaxNoTextBox.Text.Length != 13)
            //{
            //    // UPD 20140729 START ZynasSou
            //    //errMsg.AppendLine("業者Fax番号は13桁で入力して下さい。");
            //    errMsg.AppendLine(string.Format("{0}の業者Fax番号は13桁で入力して下さい。", Base1TabNm));
            //    // UPD 20140729 END ZynasSou
            //}
            else if (!Utility.Utility.IsNumAndNegative(gyoshaFaxNoTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("業者Fax番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の業者Fax番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            //else if (!Utility.Utility.IsPhoneNumber(gyoshaFaxNoTextBox.Text))
            //{
            //    // UPD 20140729 START ZynasSou
            //    //errMsg.AppendLine("業者Fax番号の形式が不正です。");
            //    errMsg.AppendLine(string.Format("{0}の業者Fax番号の形式が不正です。", Base1TabNm));
            //    // UPD 20140729 END ZynasSou
            //}

            // 代表者氏名(14)
            if (string.IsNullOrEmpty(daihyoshaNmTextBox.Text.Trim()))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("必須項目：代表者氏名が入力されていません。");
                //errMsg.AppendLine(string.Format("必須項目：{0}の代表者氏名が入力されていません。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (daihyoshaNmTextBox.Text.Length > 20)
            {
                // UPD 20140729 START ZynasSou
                ////errMsg.AppendLine("代表者氏名は20文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の代表者氏名は20文字以下で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 工事登録番号(22)
            if (string.IsNullOrEmpty(koujiTorokuNoTextBox.Text.Trim()))
            {

            }
            else if (koujiTorokuNoTextBox.Text.Length > 20)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("工事登録番号は20文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の工事登録番号は20桁以下で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 県保守業者登録番号(23)
            if (string.IsNullOrEmpty(kenHoshuGyoShaTorokuNoTextBox.Text.Trim()))
            {

            }
            //else if (!Utility.Utility.IsDecimal(kenHoshuGyoShaTorokuNoTextBox.Text))
            //{
            //    // UPD 20140729 START ZynasSou
            //    //errMsg.AppendLine("県保守業者登録番号は半角数字で入力して下さい。");
            //    errMsg.AppendLine(string.Format("{0}の県保守業者登録番号は半角数字で入力して下さい。", Base1TabNm));
            //    // UPD 20140729 END ZynasSou
            //}
            else if (kenHoshuGyoShaTorokuNoTextBox.Text.Length /*!= 4*/ > 4) // v1.08 change
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("県保守業者登録番号は4桁で入力して下さい。");
                // 2015.01.30 AnhNV MOD Start
                //errMsg.AppendLine(string.Format("{0}の県保守業者登録番号は4桁で入力して下さい。", Base1TabNm));
                errMsg.AppendLine(string.Format("{0}の県保守業者登録番号は4桁以下で入力して下さい。", Base1TabNm));
                // 2015.01.30 AnhNV MODE End

                // UPD 20140729 END ZynasSou
            }

            // 2014/11/04 AnhNV Add start
            // 福岡市登録番号(112)
            if (!string.IsNullOrEmpty(fukuokashiGyoShaTorokuNoTextBox.Text)
                && fukuokashiGyoShaTorokuNoTextBox.Text.Length != 4)
            {
                errMsg.AppendLine(string.Format("{0}の福岡市登録番号は4桁で入力して下さい。", Base1TabNm));
            }
            // 久留米市登録番号(113)
            if (!string.IsNullOrEmpty(kurumeshiGyoShaTorokuNoTextBox.Text)
                && kurumeshiGyoShaTorokuNoTextBox.Text.Length != 4)
            {
                errMsg.AppendLine(string.Format("{0}の久留米市登録番号は4桁で入力して下さい。", Base1TabNm));
            }
            // 2014/11/04 AnhNV Add end

            // 取扱業者コード(24)
            if (string.IsNullOrEmpty(toriatsukaiGyoshaCdTextBox.Text.Trim()))
            {

            }
            //else if (!Utility.Utility.IsDecimal(toriatsukaiGyoshaCdTextBox.Text))
            //{
            //    // UPD 20140729 START ZynasSou
            //    //errMsg.AppendLine("取扱業者コードは半角数字で入力して下さい。");
            //    errMsg.AppendLine(string.Format("{0}の取扱業者コードは半角数字で入力して下さい。", Base1TabNm));
            //    // UPD 20140729 END ZynasSou
            //}
            else if (toriatsukaiGyoshaCdTextBox.Text.Length != 4)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("取扱業者コードは4桁で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の取扱業者コードは4桁で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            // メーカー名称(25)
            if (string.IsNullOrEmpty(makerNmTextBox.Text.Trim()))
            {

            }
            else if (makerNmTextBox.Text.Length > 20)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("メーカー名称は20文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}のメーカー名称は20文字以下で入力して下さい。", Base1TabNm));
                // UPD 20140729 END ZynasSou
            }

            #endregion

            #region 基本情報2 tab

            // 還付金集計先コード(28)
            if (string.IsNullOrEmpty(kanpukinShukeisakiCdTextBox.Text.Trim()))
            {

            }
            else if (!Utility.Utility.IsDecimal(kanpukinShukeisakiCdTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("還付金集計先コードは半角数字で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の還付金集計先コードは半角数字で入力して下さい。", Base2TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (kanpukinShukeisakiCdTextBox.Text.Length != 4)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("還付金集計先コードは4桁で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の還付金集計先コードは4桁で入力して下さい。", Base2TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 協同組合コード(29)
            if (string.IsNullOrEmpty(kyodoKumiaiCdTextBox.Text.Trim()))
            {

            }
            else if (!Utility.Utility.IsDecimal(kyodoKumiaiCdTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("協同組合コードは半角数字で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の協同組合コードは半角数字で入力して下さい。", Base2TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (kyodoKumiaiCdTextBox.Text.Length != 5)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("協同組合コードは5桁で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の協同組合コードは5桁で入力して下さい。", Base2TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 賛助会費(30)
            if (string.IsNullOrEmpty(sanjokaihiTextBox.Text.Trim()))
            {

            }
            else if (!Utility.Utility.IsDecimal(sanjokaihiTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("賛助会費は半角数字で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の賛助会費は半角数字で入力して下さい。", Base2TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 送付先担当者氏名(31)
            if (string.IsNullOrEmpty(sofusakiTantoshaNmTextBox.Text.Trim()))
            {

            }
            else if (sofusakiTantoshaNmTextBox.Text.Length > 20)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("送付先担当者氏名は20文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の送付先担当者氏名は20文字以下で入力して下さい。", Base2TabNm));
                // UPD 20140729 END ZynasSou
            }

            #endregion

            #region 基本情報3 tab
            
            // ADD START 20140718 ZynasSou
            // 金融機関コード
            if (string.IsNullOrEmpty(bankCdTextBox.Text.Trim()))
            {

            }
            else if (!Utility.Utility.IsDecimal(bankCdTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("金融機関コードは半角数字で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の金融機関コードは半角数字で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (bankCdTextBox.Text.Length != 4)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("金融機関コードは4桁で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の金融機関コードは4桁で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            // ADD END 20140718 ZynasSou

            // 銀行名称(45)
            if (string.IsNullOrEmpty(bankNmTextBox.Text.Trim()))
            {

            }
            else if (bankNmTextBox.Text.Length > 30)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("銀行名称は30文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の銀行名称は30文字以下で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }

            // ADD START 20140718 ZynasSou
            // 支店コード
            if (string.IsNullOrEmpty(bankShitenCdTextBox.Text.Trim()))
            {

            }
            else if (!Utility.Utility.IsDecimal(bankShitenCdTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("支所コードは半角数字で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の支所コードは半角数字で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (bankShitenCdTextBox.Text.Length != 5)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("支所コードは5桁で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の支所コードは5桁で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            // ADD END 20140718 ZynasSou

            // 銀行支店名称(46)
            if (string.IsNullOrEmpty(bankShitenNmTextBox.Text.Trim()))
            {

            }
            else if (bankShitenNmTextBox.Text.Length > 20)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("銀行支店名称は20文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の銀行支店名称は20文字以下で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 銀行口座種別名(47)
            if (string.IsNullOrEmpty(bankKozaShubetsuNmTextBox.Text.Trim()))
            {

            }
            else if (bankKozaShubetsuNmTextBox.Text.Length > 8)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("銀行口座種別名は8文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の銀行口座種別名は8文字以下で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }

            // 銀行口座番号(48)
            if (string.IsNullOrEmpty(bankKozaNoTextBox.Text.Trim()))
            {

            }
            else if (!Utility.Utility.IsDecimal(bankKozaNoTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("銀行口座番号は半角数字で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の銀行口座番号は半角数字で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (bankKozaNoTextBox.Text.Length /*!= 10*/ > 10) // v1.08 change
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("銀行口座番号は10桁で入力して下さい。");
                // 2015.01.30 AnhNV MOD Start
                //errMsg.AppendLine(string.Format("{0}の銀行口座番号は10桁で入力して下さい。", Base3TabNm));
                errMsg.AppendLine(string.Format("{0}の銀行口座番号は10桁以下で入力して下さい。", Base3TabNm));
                // 2015.01.30 AnhNV MOD End
                // UPD 20140729 END ZynasSou
            }

            // 銀行口座名義(49)
            if (string.IsNullOrEmpty(bankKozaMeigiTextBox.Text.Trim()))
            {

            }
            else if (bankKozaMeigiTextBox.Text.Length > 60)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("銀行口座名義は60文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の銀行口座名義は60文字以下で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }

            // ADD 20140724 START ZynasSou
            // 廃業日
            if (string.IsNullOrEmpty(bukaiHaigyoDtTextBox.Text.Trim()))
            {

            }
            else if (!Utility.Utility.IsDecimal(bukaiHaigyoDtTextBox.Text))
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("廃業日は半角数字で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の廃業日は半角数字で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            else if (bukaiHaigyoDtTextBox.Text.Length != 8)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("廃業日は8桁で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の廃業日は8桁で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            // ADD 20140724 END ZynasSou

            // ADD 20140724 START ZynasSou
            // 廃業理由(49)
            if (string.IsNullOrEmpty(bukaiHaigyoRiyuTextBox.Text.Trim()))
            {

            }
            else if (bukaiHaigyoRiyuTextBox.Text.Length > 20)
            {
                // UPD 20140729 START ZynasSou
                //errMsg.AppendLine("廃業理由は20文字以下で入力して下さい。");
                errMsg.AppendLine(string.Format("{0}の廃業理由は20文字以下で入力して下さい。", Base3TabNm));
                // UPD 20140729 END ZynasSou
            }
            // ADD 20140724 END ZynasSou

            #endregion

            #region 業者営業所一覧データグリッドビュー(55)

            int rowCnt = 0;
            string err56_1 = string.Empty;
            string err56_2 = string.Empty;
            string err57_1 = string.Empty;
            string err58_1 = string.Empty;
            string err58_2 = string.Empty;
            string err58_3 = string.Empty;
            string err59_1 = string.Empty;
            string err60_1 = string.Empty;
            string err60_2 = string.Empty;
            string err60_3 = string.Empty;
            string err61_1 = string.Empty;
            string err61_2 = string.Empty;
            string err61_3 = string.Empty;
            string err62_1 = string.Empty;
            string err62_2 = string.Empty;
            string err63_1 = string.Empty;
            string err63_2 = string.Empty;
            string err64_1 = string.Empty;
            string err64_2 = string.Empty;
            string err65_1 = string.Empty;
            string err65_2 = string.Empty;
            string err66_1 = string.Empty;
            string err66_2 = string.Empty;
            foreach (DataGridViewRow dgvr in gyoshaEigyoshoListDataGridView.Rows)
            {
                // UPD 20140804 START ZynasSou
                //if (gyoshaEigyoshoListDataGridView.Rows.Count > 1 && gyoshaEigyoshoListDataGridView.Rows.Count - 1 == rowCnt) break;
                if (gyoshaEigyoshoListDataGridView.Rows.Count > 1 && gyoshaEigyoshoListDataGridView.Rows.Count < 10 && gyoshaEigyoshoListDataGridView.Rows.Count - 1 == rowCnt) break;
                // UPD 20140804 END ZynasSou

                // 連番(56)
                if (dgvr.Cells[gyoshaEigyoshoRenbanCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoRenbanCol.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[gyoshaEigyoshoRenbanCol.Name].Value.ToString()))
                {
                    err56_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 連番は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[gyoshaEigyoshoRenbanCol.Name].Value.ToString().Length != 1)
                {
                    err56_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 連番は1桁で入力して下さい。", rowCnt + 1));
                }

                // 業者営業所名称(57)
                if (dgvr.Cells[gyoshaEigyoshoNmCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoNmCol.Name].Value.ToString().Trim()))
                {

                }
                else if (dgvr.Cells[gyoshaEigyoshoNmCol.Name].Value.ToString().Length > 40)
                {
                    err57_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所名称は40文字以下で入力して下さい。", rowCnt + 1));
                }

                // 業者営業所郵便番号(58)
                if (dgvr.Cells[gyoshaEigyoshoZipCdCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoZipCdCol.Name].Value.ToString().Trim()))
                {

                }
                else if (dgvr.Cells[gyoshaEigyoshoZipCdCol.Name].Value.ToString().Length != 8)
                {
                    err58_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine("業者営業所郵便番号は8桁で入力して下さい。");
                }
                else if (!Utility.Utility.IsNumAndNegative(dgvr.Cells[gyoshaEigyoshoZipCdCol.Name].Value.ToString()))
                {
                    err58_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所郵便番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", rowCnt + 1));
                }
                else if (!Utility.Utility.IsZipCode(dgvr.Cells[gyoshaEigyoshoZipCdCol.Name].Value.ToString()))
                {
                    err58_3 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine("業者営業所郵便番号の形式が不正です。");
                }

                // 業者営業所住所(59)
                if (dgvr.Cells[gyoshaEigyoshoAdrCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoAdrCol.Name].Value.ToString().Trim()))
                {

                }
                else if (dgvr.Cells[gyoshaEigyoshoAdrCol.Name].Value.ToString().Length > 60)
                {
                    err59_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所住所は60文字以下で入力して下さい。", rowCnt + 1));
                }

                // 業者営業所電話番号(60)
                if (dgvr.Cells[gyoshaEigyoshoTelNoCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoTelNoCol.Name].Value.ToString().Trim()))
                {

                }
                else if (dgvr.Cells[gyoshaEigyoshoTelNoCol.Name].Value.ToString().Length < 12)
                {
                    err60_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine("業者営業所電話番号は13桁で入力して下さい。");
                }
                //else if (dgvr.Cells[gyoshaEigyoshoTelNoCol.Name].Value.ToString().Length != 13)
                //{
                //    err60_1 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine("業者営業所電話番号は13桁で入力して下さい。");
                //}
                else if (!Utility.Utility.IsNumAndNegative(dgvr.Cells[gyoshaEigyoshoTelNoCol.Name].Value.ToString().Trim()))
                {
                    err60_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所電話番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", rowCnt + 1));
                }
                //else if (!Utility.Utility.IsPhoneNumber(dgvr.Cells[gyoshaEigyoshoTelNoCol.Name].Value.ToString()))
                //{
                //    err60_3 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine("業者営業所電話番号の形式が不正です。");
                //}

                // 業者営業所ファックス(61)
                if (dgvr.Cells["gyoshaEigyoshoFaxNoCol"].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells["gyoshaEigyoshoFaxNoCol"].Value.ToString().Trim()))
                {

                }
                else if (dgvr.Cells["gyoshaEigyoshoFaxNoCol"].Value.ToString().Length < 12)
                {
                    err61_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine("業者営業所ファックス番号は13桁で入力して下さい。");
                }
                //else if (dgvr.Cells[gyoshaEigyoshoFaxNoCol.Name].Value.ToString().Length != 13)
                //{
                //    err61_1 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine("業者営業所ファックス番号は13桁で入力して下さい。");
                //}
                else if (!Utility.Utility.IsNumAndNegative(dgvr.Cells["gyoshaEigyoshoFaxNoCol"].Value.ToString().Trim()))
                {
                    err61_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所ファックス番号は半角数字で入力して下さい。", rowCnt + 1));
                }
                //else if (!Utility.Utility.IsPhoneNumber(dgvr.Cells[gyoshaEigyoshoFaxNoCol.Name].Value.ToString()))
                //{
                //    err61_3 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine("業者営業所ファックスの形式が不正です。");
                //}

                // 業者営業所保健所１(62)
                if (dgvr.Cells[gyoshaEigyoshoHokenjo1Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoHokenjo1Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[gyoshaEigyoshoHokenjo1Col.Name].Value.ToString()))
                {
                    err62_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所１は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[gyoshaEigyoshoHokenjo1Col.Name].Value.ToString().Length != 2)
                {
                    err62_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所１は2桁で入力して下さい。", rowCnt + 1));
                }

                // 業者営業所保健所２(63)
                if (dgvr.Cells[gyoshaEigyoshoHokenjo2Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoHokenjo2Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[gyoshaEigyoshoHokenjo2Col.Name].Value.ToString()))
                {
                    err63_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所２は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[gyoshaEigyoshoHokenjo2Col.Name].Value.ToString().Length != 2)
                {
                    err63_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所２は2桁で入力して下さい。", rowCnt + 1));
                }

                // 業者営業所保健所３(64)
                if (dgvr.Cells[gyoshaEigyoshoHokenjo3Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoHokenjo3Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[gyoshaEigyoshoHokenjo3Col.Name].Value.ToString()))
                {
                    err64_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所３は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[gyoshaEigyoshoHokenjo3Col.Name].Value.ToString().Length != 2)
                {
                    err64_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所３は2桁で入力して下さい。", rowCnt + 1));
                }

                // 業者営業所保健所４(65)
                if (dgvr.Cells[gyoshaEigyoshoHokenjo4Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoHokenjo4Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[gyoshaEigyoshoHokenjo4Col.Name].Value.ToString()))
                {
                    err65_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所４は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[gyoshaEigyoshoHokenjo4Col.Name].Value.ToString().Length != 2)
                {
                    err65_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所４は2桁で入力して下さい。", rowCnt + 1));
                }

                // 業者営業所保健所５(66)
                if (dgvr.Cells[gyoshaEigyoshoHokenjo5Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoshoHokenjo5Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[gyoshaEigyoshoHokenjo5Col.Name].Value.ToString()))
                {
                    err66_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所５は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[gyoshaEigyoshoHokenjo5Col.Name].Value.ToString().Length != 2)
                {
                    err66_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所５は2桁で入力して下さい。", rowCnt + 1));
                }

                // Next row
                rowCnt++;
            }

            if (err56_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 連番は半角数字で入力して下さい。", err56_1.Remove(err56_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 連番は半角数字で入力して下さい。", EigyoshoTabNm, err56_1.Remove(err56_1.Length - 2)));
            }

            if (err56_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 連番は1桁で入力して下さい。", err56_2.Remove(err56_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 連番は1桁で入力して下さい。", EigyoshoTabNm, err56_2.Remove(err56_2.Length - 2)));
            }

            if (err57_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所名称は40文字以下で入力して下さい。", err57_1.Remove(err57_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所名称は40文字以下で入力して下さい。", EigyoshoTabNm, err57_1.Remove(err57_1.Length - 2)));
            }

            if (err58_1 != string.Empty) //Length check
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所郵便番号は8桁で入力して下さい。", err58_1.Remove(err58_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所郵便番号は8桁で入力して下さい。", EigyoshoTabNm, err58_1.Remove(err58_1.Length - 2)));
            }

            if (err58_2 != string.Empty) // No number or no hyphen check
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所郵便番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", err58_2.Remove(err58_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所郵便番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", EigyoshoTabNm, err58_2.Remove(err58_2.Length - 2)));
            }

            if (err58_3 != string.Empty) // Wrong format
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所郵便番号の形式が不正です。", err58_3.Remove(err58_3.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所郵便番号の形式が不正です。", EigyoshoTabNm, err58_3.Remove(err58_3.Length - 2)));
            }

            if (err59_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所住所は60文字以下で入力して下さい。", err59_1.Remove(err59_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所住所は60文字以下で入力して下さい。", EigyoshoTabNm, err59_1.Remove(err59_1.Length - 2)));
            }

            if (err60_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所電話番号は13桁で入力して下さい。", err60_1.Remove(err60_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所電話番号は12～13桁で入力して下さい。", EigyoshoTabNm, err60_1.Remove(err60_1.Length - 2)));
            }

            if (err60_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所電話番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", err60_2.Remove(err60_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所電話番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", EigyoshoTabNm, err60_2.Remove(err60_2.Length - 2)));
                //errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所電話番号は形式が違います。", EigyoshoTabNm, err60_2.Remove(err60_2.Length - 2)));
            }

            //if (err60_3 != string.Empty)
            //{
            //    //errMsg.AppendLine(string.Format("行{0}: 業者営業所電話番号の形式が不正です。", err60_3.Remove(err60_3.Length - 2)));
            //    errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所電話番号の形式が不正です。", EigyoshoTabNm, err60_3.Remove(err60_3.Length - 2)));
            //}

            if (err61_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所ファックス番号は13桁で入力して下さい。", err61_1.Remove(err61_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所ファックス番号は12～13桁で入力して下さい。", EigyoshoTabNm, err61_1.Remove(err61_1.Length - 2)));
            }

            if (err61_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所ファックス番号は半角数字で入力して下さい。", err61_2.Remove(err61_2.Length - 2)));
                //errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所ファックス番号は半角数字で入力して下さい。", EigyoshoTabNm, err61_2.Remove(err61_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所ファックス番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。", EigyoshoTabNm, err61_2.Remove(err61_2.Length - 2)));
            }

            //if (err61_3 != string.Empty)
            //{
            //    //errMsg.AppendLine(string.Format("行{0}: 業者営業所ファックスの形式が不正です。", err61_3.Remove(err61_3.Length - 2)));
            //    errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所ファックスの形式が不正です。", EigyoshoTabNm, err61_3.Remove(err61_3.Length - 2)));
            //}

            if (err62_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所１は半角数字で入力して下さい。", err62_1.Remove(err62_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所１は半角数字で入力して下さい。", EigyoshoTabNm, err62_1.Remove(err62_1.Length - 2)));
            }

            if (err62_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所１は2桁で入力して下さい。", err62_2.Remove(err62_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所１は2桁で入力して下さい。", EigyoshoTabNm, err62_2.Remove(err62_2.Length - 2)));
            }

            if (err63_1 != string.Empty)
            {
                ////errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所２は半角数字で入力して下さい。", err63_1.Remove(err63_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所２は半角数字で入力して下さい。", EigyoshoTabNm, err63_1.Remove(err63_1.Length - 2)));
            }

            if (err63_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所２は2桁で入力して下さい。", err63_2.Remove(err63_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所２は2桁で入力して下さい。", EigyoshoTabNm, err63_2.Remove(err63_2.Length - 2)));
            }

            if (err64_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所３は半角数字で入力して下さい。", err64_1.Remove(err64_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所３は半角数字で入力して下さい。", EigyoshoTabNm, err64_1.Remove(err64_1.Length - 2)));
            }

            if (err64_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所３は2桁で入力して下さい。", err64_2.Remove(err64_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所３は2桁で入力して下さい。", EigyoshoTabNm, err64_2.Remove(err64_2.Length - 2)));
            }

            if (err65_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所４は半角数字で入力して下さい。", err65_1.Remove(err65_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所４は半角数字で入力して下さい。", EigyoshoTabNm, err65_1.Remove(err65_1.Length - 2)));
            }

            if (err65_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所４は2桁で入力して下さい。", err65_2.Remove(err65_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所４は2桁で入力して下さい。", EigyoshoTabNm, err65_2.Remove(err65_2.Length - 2)));
            }

            if (err66_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所５は半角数字で入力して下さい。", err66_1.Remove(err66_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所５は半角数字で入力して下さい。", EigyoshoTabNm, err66_1.Remove(err66_1.Length - 2)));
            }

            if (err66_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業所保健所５は2桁で入力して下さい。", err66_2.Remove(err66_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業所保健所５は2桁で入力して下さい。", EigyoshoTabNm, err66_2.Remove(err66_2.Length - 2)));
            }

            #endregion

            #region 業者営業地区一覧データグリッドビュー(68)

            rowCnt = 0;
            // DEL 20140728 START ZynasSou
            //string err69_1 = string.Empty;
            //string err69_2 = string.Empty;
            // DEL 20140728 END ZynasSou
            string err70_1 = string.Empty;
            string err70_2 = string.Empty;
            foreach (DataGridViewRow dgvr in gyoshaEigyoChikuListDataGridView.Rows)
            {
                if ((gyoshaEigyoChikuListDataGridView.Rows.Count > 1 && gyoshaEigyoChikuListDataGridView.Rows.Count - 1 == rowCnt)) break;

                // DEL 20140728 START ZynasSou
                //// 連番(69)
                //if (dgvr.Cells[gyoshaEigyoChikuRenbanCol.Name].Value == null ||
                //    string.IsNullOrEmpty(dgvr.Cells[gyoshaEigyoChikuRenbanCol.Name].Value.ToString().Trim()))
                //{

                //}
                //else if (!Utility.Utility.IsDecimal(dgvr.Cells[gyoshaEigyoChikuRenbanCol.Name].Value.ToString()))
                //{
                //    err69_1 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine(string.Format("行{0}: 連番は半角数字で入力して下さい。", rowCnt + 1));
                //}
                //else if (dgvr.Cells[gyoshaEigyoChikuRenbanCol.Name].Value.ToString().Length != 2)
                //{
                //    err69_2 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine(string.Format("行{0}: 連番は2桁で入力して下さい。", rowCnt + 1));
                //}
                // DEL 20140728 END ZynasSou

                // 業者営業地区コード(70)
                if (dgvr.Cells["gyoshaEigyoChikuCdCol"].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells["gyoshaEigyoChikuCdCol"].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells["gyoshaEigyoChikuCdCol"].Value.ToString()))
                {
                    err70_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業地区コードは半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells["gyoshaEigyoChikuCdCol"].Value.ToString().Length != 5)
                {
                    err70_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 業者営業地区コードは5桁で入力して下さい。", rowCnt + 1));
                }

                // Next row
                rowCnt++;
            }

            // DEL 20140728 START ZynasSou
            //if (err69_1 != string.Empty)
            //{
            //    errMsg.AppendLine(string.Format("行{0}: 連番は半角数字で入力して下さい。", err69_1.Remove(err69_1.Length - 2)));
            //}

            //if (err69_2 != string.Empty)
            //{
            //    errMsg.AppendLine(string.Format("行{0}: 連番は2桁で入力して下さい。", err69_2.Remove(err69_2.Length - 2)));
            //}
            // DEL 20140728 END ZynasSou

            if (err70_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業地区コードは半角数字で入力して下さい。", err70_1.Remove(err70_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業地区コードは半角数字で入力して下さい。", EigyoChikuTabNm, err70_1.Remove(err70_1.Length - 2)));
            }

            if (err70_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 業者営業地区コードは5桁で入力して下さい。", err70_2.Remove(err70_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 業者営業地区コードは5桁で入力して下さい。", EigyoChikuTabNm, err70_2.Remove(err70_2.Length - 2)));
            }

            #endregion

            #region 業者部会一覧データグリッドビュー(71)
            /*
            rowCnt = 0;
            // DEL 20140728 START ZynasSou
            //string err73_1 = string.Empty;
            //string err73_2 = string.Empty;
            // DEL 20140728 END ZynasSou
            string err74_1 = string.Empty;
            string err74_2 = string.Empty;
            string err75_1 = string.Empty;
            string err75_2 = string.Empty;
            string err76_1 = string.Empty;
            string err76_2 = string.Empty;
            string err77_1 = string.Empty;
            string err78_1 = string.Empty;
            string err78_2 = string.Empty;
            string err79_1 = string.Empty;
            string err79_2 = string.Empty;
            string err80_1 = string.Empty;
            string err81_1 = string.Empty;
            string err81_2 = string.Empty;
            string err82_1 = string.Empty;
            string err82_2 = string.Empty;
            string err83_1 = string.Empty;
            string err83_2 = string.Empty;
            string err84_1 = string.Empty;
            string err84_2 = string.Empty;
            string err85_1 = string.Empty;
            string err85_2 = string.Empty;
            string err86_1 = string.Empty;
            string err86_2 = string.Empty;
            string err87_1 = string.Empty;
            string err87_2 = string.Empty;
            string err88_1 = string.Empty;
            string err88_2 = string.Empty;
            string err89_1 = string.Empty;
            string err89_2 = string.Empty;
            string err90_1 = string.Empty;
            string err90_2 = string.Empty;
            string err91_1 = string.Empty;
            string err91_2 = string.Empty;
            string err92_1 = string.Empty;
            string err92_2 = string.Empty;
            string err93_1 = string.Empty;
            string err93_2 = string.Empty;
            string err94_1 = string.Empty;
            string err94_2 = string.Empty;
            string err95_1 = string.Empty;
            string err95_2 = string.Empty;
            string err96_1 = string.Empty;
            string err96_2 = string.Empty;
            string err97_1 = string.Empty;
            string err97_2 = string.Empty;
            string err98_1 = string.Empty;
            string err98_2 = string.Empty;
            string err99_1 = string.Empty;
            string err99_2 = string.Empty;
            string err100_1 = string.Empty;
            string err100_2 = string.Empty;
            string err101_1 = string.Empty;
            string err101_2 = string.Empty;
            string err102_1 = string.Empty;
            string err102_2 = string.Empty;
            string err103_1 = string.Empty;
            string err103_2 = string.Empty;
            string err104_1 = string.Empty;
            string err104_2 = string.Empty;
            string err105_1 = string.Empty;
            string err105_2 = string.Empty;
            foreach (DataGridViewRow dgvr in gyoshaBukaiListDataGridView.Rows)
            {
                if (gyoshaBukaiListDataGridView.Rows.Count > 1 && gyoshaBukaiListDataGridView.Rows.Count - 1 == rowCnt) break;

                // DEL 20140728 START ZynasSou
                //// 連番(73)
                //if (dgvr.Cells[bukaiRenbanCol.Name].Value == null ||
                //    string.IsNullOrEmpty(dgvr.Cells[bukaiRenbanCol.Name].Value.ToString().Trim()))
                //{

                //}
                //else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiRenbanCol.Name].Value.ToString()))
                //{
                //    err73_1 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine(string.Format("行{0}: 連番は半角数字で入力して下さい。", rowCnt + 1));
                //}
                //else if (dgvr.Cells[bukaiRenbanCol.Name].Value.ToString().Length != 1)
                //{
                //    err73_2 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine(string.Format("行{0}: 連番は1桁で入力して下さい。", rowCnt + 1));
                //}
                // DEL 20140728 END ZynasSou

                // 会員コード(74)
                if (dgvr.Cells[bukaiKaiinCdCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKaiinCdCol.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKaiinCdCol.Name].Value.ToString()))
                {
                    err74_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 会員コードは半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKaiinCdCol.Name].Value.ToString().Length != 4)
                {
                    err74_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 会員コードは4桁で入力して下さい。", rowCnt + 1));
                }

                // 入会日(75)
                if (dgvr.Cells[bukaiNyukaiDtCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiNyukaiDtCol.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiNyukaiDtCol.Name].Value.ToString()))
                {
                    err75_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 入会日は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiNyukaiDtCol.Name].Value.ToString().Length != 8)
                {
                    err75_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 入会日は8桁で入力して下さい。", rowCnt + 1));
                }

                // 退会日(76)
                if (dgvr.Cells[bukaiTaikaiDtCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTaikaiDtCol.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTaikaiDtCol.Name].Value.ToString()))
                {
                    err76_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 退会日は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTaikaiDtCol.Name].Value.ToString().Length != 8)
                {
                    err76_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 退会日は8桁で入力して下さい。", rowCnt + 1));
                }

                // 設備士代表者氏名（管理管士）(77)
                if (dgvr.Cells[bukaiSetsubishiDaihyoshaNmCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiSetsubishiDaihyoshaNmCol.Name].Value.ToString().Trim()))
                {

                }
                else if (dgvr.Cells[bukaiSetsubishiDaihyoshaNmCol.Name].Value.ToString().Length > 20)
                {
                    err77_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 設備士代表者氏名（管理管士）は20文字以下で入力して下さい。", rowCnt + 1));
                }

                // 免状番号(78)
                if (dgvr.Cells[bukaiMenJoNoCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiMenJoNoCol.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiMenJoNoCol.Name].Value.ToString()))
                {
                    err78_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 免状番号は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiMenJoNoCol.Name].Value.ToString().Length != 10)
                {
                    err78_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 免状番号は10桁で入力して下さい。", rowCnt + 1));
                }

                // DEL 20140724 START ZynasSou
                //// 廃業日(79)
                //if (dgvr.Cells[bukaiHaigyoDtCol.Name].Value == null ||
                //    string.IsNullOrEmpty(dgvr.Cells[bukaiHaigyoDtCol.Name].Value.ToString().Trim()))
                //{

                //}
                //else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiHaigyoDtCol.Name].Value.ToString()))
                //{
                //    err79_1 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine(string.Format("行{0}: 廃業日は半角数字で入力して下さい。", rowCnt + 1));
                //}
                //else if (dgvr.Cells[bukaiHaigyoDtCol.Name].Value.ToString().Length != 8)
                //{
                //    err79_2 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine(string.Format("行{0}: 廃業日は8桁で入力して下さい。", rowCnt + 1));
                //}
                // DEL 20140724 END ZynasSou

                // DEL 20140724 START ZynasSou
                //// 廃業理由(80)
                //if (dgvr.Cells[bukaiHaigyoRiyuCol.Name].Value == null ||
                //    string.IsNullOrEmpty(dgvr.Cells[bukaiHaigyoRiyuCol.Name].Value.ToString().Trim()))
                //{

                //}
                //else if (dgvr.Cells[bukaiHaigyoRiyuCol.Name].Value.ToString().Length > 20)
                //{
                //    err80_1 += rowCnt + 1 + ", ";
                //    //errMsg.AppendLine(string.Format("行{0}: 廃業理由は20文字以下で入力して下さい。", rowCnt + 1));
                //}
                // DEL 20140724 END ZynasSou

                // 関係保係健所１(81)
                if (dgvr.Cells[bukaiKankeiHokenjo1Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo1Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo1Col.Name].Value.ToString()))
                {
                    err81_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo1Col.Name].Value.ToString().Length != 2)
                {
                    err81_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所２(82)
                if (dgvr.Cells[bukaiKankeiHokenjo2Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo2Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo2Col.Name].Value.ToString()))
                {
                    err82_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所２は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo2Col.Name].Value.ToString().Length != 2)
                {
                    err82_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所２は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所３(83)
                if (dgvr.Cells[bukaiKankeiHokenjo3Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo3Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo3Col.Name].Value.ToString()))
                {
                    err83_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所３は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo3Col.Name].Value.ToString().Length != 2)
                {
                    err83_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所３は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所４(84)
                if (dgvr.Cells[bukaiKankeiHokenjo4Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo4Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo4Col.Name].Value.ToString()))
                {
                    err84_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所４は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo4Col.Name].Value.ToString().Length != 2)
                {
                    err84_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所４は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所５(85)
                if (dgvr.Cells[bukaiKankeiHokenjo5Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo5Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo5Col.Name].Value.ToString()))
                {
                    err85_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所５は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo5Col.Name].Value.ToString().Length != 2)
                {
                    err85_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所５は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所６(86)
                if (dgvr.Cells[bukaiKankeiHokenjo6Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo6Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo6Col.Name].Value.ToString()))
                {
                    err86_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所６は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo6Col.Name].Value.ToString().Length != 2)
                {
                    err86_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所６は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所７(87)
                if (dgvr.Cells[bukaiKankeiHokenjo7Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo7Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo7Col.Name].Value.ToString()))
                {
                    err87_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所７は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo7Col.Name].Value.ToString().Length != 2)
                {
                    err87_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所７は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所８(88)
                if (dgvr.Cells[bukaiKankeiHokenjo8Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo8Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo8Col.Name].Value.ToString()))
                {
                    err88_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所８は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo8Col.Name].Value.ToString().Length != 2)
                {
                    err88_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所８は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保係健所９(89)
                if (dgvr.Cells[bukaiKankeiHokenjo9Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo9Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo9Col.Name].Value.ToString()))
                {
                    err89_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所９は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo9Col.Name].Value.ToString().Length != 2)
                {
                    err89_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所９は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保健保所１０(90)
                if (dgvr.Cells[bukaiKankeiHokenjo10Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo10Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo10Col.Name].Value.ToString()))
                {
                    err90_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１０は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo10Col.Name].Value.ToString().Length != 2)
                {
                    err90_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１０は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保健保所１１(91)
                if (dgvr.Cells[bukaiKankeiHokenjo11Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo11Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo11Col.Name].Value.ToString()))
                {
                    err91_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１１は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo11Col.Name].Value.ToString().Length != 2)
                {
                    err91_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１１は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保健保所１２(92)
                if (dgvr.Cells[bukaiKankeiHokenjo12Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo12Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo12Col.Name].Value.ToString()))
                {
                    err92_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１２は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo12Col.Name].Value.ToString().Length != 2)
                {
                    err92_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１２は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保健保所１３(93)
                if (dgvr.Cells[bukaiKankeiHokenjo13Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo13Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo13Col.Name].Value.ToString()))
                {
                    err93_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１３は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo13Col.Name].Value.ToString().Length != 2)
                {
                    err93_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１３は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保健保所１４(94)
                if (dgvr.Cells[bukaiKankeiHokenjo14Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo14Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo14Col.Name].Value.ToString()))
                {
                    err94_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１４は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo14Col.Name].Value.ToString().Length != 2)
                {
                    err94_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１４は2桁で入力して下さい。", rowCnt + 1));
                }

                // 関係保健保所１５(95)
                if (dgvr.Cells[bukaiKankeiHokenjo15Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiKankeiHokenjo15Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiKankeiHokenjo15Col.Name].Value.ToString()))
                {
                    err95_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１５は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiKankeiHokenjo15Col.Name].Value.ToString().Length != 2)
                {
                    err95_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１５は2桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村１(96)
                if (dgvr.Cells[bukaiTantoShichoson1Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson1Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson1Col.Name].Value.ToString()))
                {
                    err96_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson1Col.Name].Value.ToString().Length != 5)
                {
                    err96_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村２(97)
                if (dgvr.Cells[bukaiTantoShichoson2Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson2Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson2Col.Name].Value.ToString()))
                {
                    err97_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村２は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson2Col.Name].Value.ToString().Length != 5)
                {
                    err97_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村２は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村３(98)
                if (dgvr.Cells[bukaiTantoShichoson3Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson3Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson3Col.Name].Value.ToString()))
                {
                    err98_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村３は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson3Col.Name].Value.ToString().Length != 5)
                {
                    err98_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村３は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村４(99)
                if (dgvr.Cells[bukaiTantoShichoson4Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson4Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson4Col.Name].Value.ToString()))
                {
                    err99_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村４は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson4Col.Name].Value.ToString().Length != 5)
                {
                    err99_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村４は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村５(100)
                if (dgvr.Cells[bukaiTantoShichoson5Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson5Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson5Col.Name].Value.ToString()))
                {
                    err100_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村５は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson5Col.Name].Value.ToString().Length != 5)
                {
                    err100_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村５は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村６(101)
                if (dgvr.Cells[bukaiTantoShichoson6Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson6Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson6Col.Name].Value.ToString()))
                {
                    err101_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村６は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson6Col.Name].Value.ToString().Length != 5)
                {
                    err101_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村６は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村７(102)
                if (dgvr.Cells[bukaiTantoShichoson7Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson7Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson7Col.Name].Value.ToString()))
                {
                    err102_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村７は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson7Col.Name].Value.ToString().Length != 5)
                {
                    err102_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村７は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村８(103)
                if (dgvr.Cells[bukaiTantoShichoson8Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson8Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson8Col.Name].Value.ToString()))
                {
                    err103_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村８は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson8Col.Name].Value.ToString().Length != 5)
                {
                    err103_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村８は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村９(104)
                if (dgvr.Cells[bukaiTantoShichoson9Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson9Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson9Col.Name].Value.ToString()))
                {
                    err104_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村９は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson9Col.Name].Value.ToString().Length != 5)
                {
                    err104_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村９は5桁で入力して下さい。", rowCnt + 1));
                }

                // 担当市当町村１０(105)
                if (dgvr.Cells[bukaiTantoShichoson10Col.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[bukaiTantoShichoson10Col.Name].Value.ToString().Trim()))
                {

                }
                else if (!Utility.Utility.IsDecimal(dgvr.Cells[bukaiTantoShichoson10Col.Name].Value.ToString()))
                {
                    err105_1 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１０は半角数字で入力して下さい。", rowCnt + 1));
                }
                else if (dgvr.Cells[bukaiTantoShichoson10Col.Name].Value.ToString().Length != 5)
                {
                    err105_2 += rowCnt + 1 + ", ";
                    //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１０は5桁で入力して下さい。", rowCnt + 1));
                }

                // Next row
                rowCnt++;
            }

            // DEL 20140728 START ZynasSou
            //if (err73_1 != string.Empty)
            //{
            //    errMsg.AppendLine(string.Format("行{0}: 連番は半角数字で入力して下さい。", err73_1.Remove(err73_1.Length - 2)));
            //}

            //if (err73_2 != string.Empty)
            //{
            //    errMsg.AppendLine(string.Format("行{0}: 連番は1桁で入力して下さい。", err73_2.Remove(err73_2.Length - 2)));
            //}
            // DEL 20140728 END ZynasSou

            if (err74_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 会員コードは半角数字で入力して下さい。", err74_1.Remove(err74_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 会員コードは半角数字で入力して下さい。", EigyoBukaiTabNm, err74_1.Remove(err74_1.Length - 2)));
            }

            if (err74_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 会員コードは4桁で入力して下さい。", err74_2.Remove(err74_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 会員コードは4桁で入力して下さい。", EigyoBukaiTabNm, err74_2.Remove(err74_2.Length - 2)));
            }

            if (err75_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 入会日は半角数字で入力して下さい。", err75_1.Remove(err75_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 入会日は半角数字で入力して下さい。", EigyoBukaiTabNm, err75_1.Remove(err75_1.Length - 2)));
            }

            if (err75_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 入会日は8桁で入力して下さい。", err75_2.Remove(err75_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 入会日は8桁で入力して下さい。", EigyoBukaiTabNm, err75_2.Remove(err75_2.Length - 2)));
            }

            if (err76_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 退会日は半角数字で入力して下さい。", err76_1.Remove(err76_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 退会日は半角数字で入力して下さい。", EigyoBukaiTabNm, err76_1.Remove(err76_1.Length - 2)));
            }

            if (err76_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 退会日は8桁で入力して下さい。", err76_2.Remove(err76_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 退会日は8桁で入力して下さい。", EigyoBukaiTabNm, err76_2.Remove(err76_2.Length - 2)));
            }

            if (err77_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 設備士代表者氏名（管理管士）は20文字以下で入力して下さい。", err77_1.Remove(err77_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 設備士代表者氏名（管理管士）は20文字以下で入力して下さい。", EigyoBukaiTabNm, err77_1.Remove(err77_1.Length - 2)));
            }

            if (err78_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 免状番号は半角数字で入力して下さい。", err78_1.Remove(err78_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 免状番号は半角数字で入力して下さい。", EigyoBukaiTabNm, err78_1.Remove(err78_1.Length - 2)));
            }

            if (err78_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 免状番号は10桁で入力して下さい。", err78_2.Remove(err78_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 免状番号は10桁で入力して下さい。", EigyoBukaiTabNm, err78_2.Remove(err78_2.Length - 2)));
            }

            if (err79_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 廃業日は半角数字で入力して下さい。", err79_1.Remove(err79_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 廃業日は半角数字で入力して下さい。", EigyoBukaiTabNm, err79_1.Remove(err79_1.Length - 2)));
            }

            if (err79_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 廃業日は8桁で入力して下さい。", err79_2.Remove(err79_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 廃業日は8桁で入力して下さい。", EigyoBukaiTabNm, err79_2.Remove(err79_2.Length - 2)));
            }

            if (err80_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 廃業理由は20文字以下で入力して下さい。", err80_1.Remove(err80_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 廃業理由は20文字以下で入力して下さい。", EigyoBukaiTabNm, err80_1.Remove(err80_1.Length - 2)));
            }

            if (err81_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１は半角数字で入力して下さい。", err81_1.Remove(err81_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１は半角数字で入力して下さい。", EigyoBukaiTabNm, err81_1.Remove(err81_1.Length - 2)));
            }

            if (err81_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１は2桁で入力して下さい。", err81_2.Remove(err81_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１は2桁で入力して下さい。", EigyoBukaiTabNm, err81_2.Remove(err81_2.Length - 2)));
            }

            if (err82_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所２は半角数字で入力して下さい。", err82_1.Remove(err82_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所２は半角数字で入力して下さい。", EigyoBukaiTabNm, err82_1.Remove(err82_1.Length - 2)));
            }

            if (err82_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所２は2桁で入力して下さい。", err82_2.Remove(err82_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所２は2桁で入力して下さい。", EigyoBukaiTabNm, err82_2.Remove(err82_2.Length - 2)));
            }

            if (err83_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所３は半角数字で入力して下さい。", err83_1.Remove(err83_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所３は半角数字で入力して下さい。", EigyoBukaiTabNm, err83_1.Remove(err83_1.Length - 2)));
            }

            if (err83_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所３は2桁で入力して下さい。", err83_2.Remove(err83_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所３は2桁で入力して下さい。", EigyoBukaiTabNm, err83_2.Remove(err83_2.Length - 2)));
            }

            if (err84_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所４は半角数字で入力して下さい。", err84_1.Remove(err84_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所４は半角数字で入力して下さい。", EigyoBukaiTabNm, err84_1.Remove(err84_1.Length - 2)));
            }

            if (err84_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所４は2桁で入力して下さい。", err84_2.Remove(err84_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所４は2桁で入力して下さい。", EigyoBukaiTabNm, err84_2.Remove(err84_2.Length - 2)));
            }

            if (err85_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所５は半角数字で入力して下さい。", err85_1.Remove(err85_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所５は半角数字で入力して下さい。", EigyoBukaiTabNm, err85_1.Remove(err85_1.Length - 2)));
            }

            if (err85_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所５は2桁で入力して下さい。", err85_2.Remove(err85_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所５は2桁で入力して下さい。", EigyoBukaiTabNm, err85_2.Remove(err85_2.Length - 2)));
            }

            if (err86_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所６は半角数字で入力して下さい。", err86_1.Remove(err86_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所６は半角数字で入力して下さい。", EigyoBukaiTabNm, err86_1.Remove(err86_1.Length - 2)));
            }

            if (err86_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所６は2桁で入力して下さい。", err86_2.Remove(err86_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所６は2桁で入力して下さい。", EigyoBukaiTabNm, err86_2.Remove(err86_2.Length - 2)));
            }

            if (err87_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所７は半角数字で入力して下さい。", err87_1.Remove(err87_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所７は半角数字で入力して下さい。", EigyoBukaiTabNm, err87_1.Remove(err87_1.Length - 2)));
            }

            if (err87_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所７は2桁で入力して下さい。", err87_2.Remove(err87_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所７は2桁で入力して下さい。", EigyoBukaiTabNm, err87_2.Remove(err87_2.Length - 2)));
            }

            if (err88_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所８は半角数字で入力して下さい。", err88_1.Remove(err88_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所８は半角数字で入力して下さい。", EigyoBukaiTabNm, err88_1.Remove(err88_1.Length - 2)));
            }

            if (err88_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所８は2桁で入力して下さい。", err88_2.Remove(err88_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所８は2桁で入力して下さい。", EigyoBukaiTabNm, err88_2.Remove(err88_2.Length - 2)));
            }

            if (err89_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所９は半角数字で入力して下さい。", err89_1.Remove(err89_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所９は半角数字で入力して下さい。", EigyoBukaiTabNm, err89_1.Remove(err89_1.Length - 2)));
            }

            if (err89_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所９は2桁で入力して下さい。", err89_2.Remove(err89_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所９は2桁で入力して下さい。", EigyoBukaiTabNm, err89_2.Remove(err89_2.Length - 2)));
            }

            if (err90_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１０は半角数字で入力して下さい。", err90_1.Remove(err90_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１０は半角数字で入力して下さい。", EigyoBukaiTabNm, err90_1.Remove(err90_1.Length - 2)));
            }

            if (err90_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１０は2桁で入力して下さい。", err90_2.Remove(err90_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１０は2桁で入力して下さい。", EigyoBukaiTabNm, err90_2.Remove(err90_2.Length - 2)));
            }

            if (err91_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１１は半角数字で入力して下さい。", err91_1.Remove(err91_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１１は半角数字で入力して下さい。", EigyoBukaiTabNm, err91_1.Remove(err91_1.Length - 2)));
            }

            if (err91_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１１は2桁で入力して下さい。", err91_2.Remove(err91_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１１は2桁で入力して下さい。", EigyoBukaiTabNm, err91_2.Remove(err91_2.Length - 2)));
            }

            if (err92_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１２は半角数字で入力して下さい。", err92_1.Remove(err92_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１２は半角数字で入力して下さい。", EigyoBukaiTabNm, err92_1.Remove(err92_1.Length - 2)));
            }

            if (err92_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１２は2桁で入力して下さい。", err92_2.Remove(err92_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１２は2桁で入力して下さい。", EigyoBukaiTabNm, err92_2.Remove(err92_2.Length - 2)));
            }

            if (err93_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１３は半角数字で入力して下さい。", err93_1.Remove(err93_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１３は半角数字で入力して下さい。", EigyoBukaiTabNm, err93_1.Remove(err93_1.Length - 2)));
            }

            if (err93_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１３は2桁で入力して下さい。", err93_2.Remove(err93_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１３は2桁で入力して下さい。", EigyoBukaiTabNm, err93_2.Remove(err93_2.Length - 2)));
            }

            if (err94_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１４は半角数字で入力して下さい。", err94_1.Remove(err94_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１４は半角数字で入力して下さい。", EigyoBukaiTabNm, err94_1.Remove(err94_1.Length - 2)));
            }

            if (err94_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１４は2桁で入力して下さい。", err94_2.Remove(err94_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１４は2桁で入力して下さい。", EigyoBukaiTabNm, err94_2.Remove(err94_2.Length - 2)));
            }

            if (err95_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１５は半角数字で入力して下さい。", err95_1.Remove(err95_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１５は半角数字で入力して下さい。", EigyoBukaiTabNm, err95_1.Remove(err95_1.Length - 2)));
            }

            if (err95_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 関係保係健所１５は2桁で入力して下さい。", err95_2.Remove(err95_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 関係保係健所１５は2桁で入力して下さい。", EigyoBukaiTabNm, err95_2.Remove(err95_2.Length - 2)));
            }

            if (err96_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１は半角数字で入力して下さい。", err96_1.Remove(err96_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村１は半角数字で入力して下さい。", EigyoBukaiTabNm, err96_1.Remove(err96_1.Length - 2)));
            }

            if (err96_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１は5桁で入力して下さい。", err96_2.Remove(err96_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村１は5桁で入力して下さい。", EigyoBukaiTabNm, err96_2.Remove(err96_2.Length - 2)));
            }

            if (err97_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村２は半角数字で入力して下さい。", err97_1.Remove(err97_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村２は半角数字で入力して下さい。", EigyoBukaiTabNm, err97_1.Remove(err97_1.Length - 2)));
            }

            if (err97_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村２は5桁で入力して下さい。", err97_2.Remove(err97_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村２は5桁で入力して下さい。", EigyoBukaiTabNm, err97_2.Remove(err97_2.Length - 2)));
            }

            if (err98_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村３は半角数字で入力して下さい。", err98_1.Remove(err98_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村３は半角数字で入力して下さい。", EigyoBukaiTabNm, err98_1.Remove(err98_1.Length - 2)));
            }

            if (err98_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村３は5桁で入力して下さい。", err98_2.Remove(err98_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村３は5桁で入力して下さい。", EigyoBukaiTabNm, err98_2.Remove(err98_2.Length - 2)));
            }

            if (err99_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村４は半角数字で入力して下さい。", err99_1.Remove(err99_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村４は半角数字で入力して下さい。", EigyoBukaiTabNm, err99_1.Remove(err99_1.Length - 2)));
            }

            if (err99_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村４は5桁で入力して下さい。", err99_2.Remove(err99_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村４は5桁で入力して下さい。", EigyoBukaiTabNm, err99_2.Remove(err99_2.Length - 2)));
            }

            if (err100_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村５は半角数字で入力して下さい。", err100_1.Remove(err100_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村５は半角数字で入力して下さい。", EigyoBukaiTabNm, err100_1.Remove(err100_1.Length - 2)));
            }

            if (err100_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村５は5桁で入力して下さい。", err100_2.Remove(err100_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村５は5桁で入力して下さい。", EigyoBukaiTabNm, err100_2.Remove(err100_2.Length - 2)));
            }

            if (err101_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村６は半角数字で入力して下さい。", err101_1.Remove(err101_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村６は半角数字で入力して下さい。", EigyoBukaiTabNm, err101_1.Remove(err101_1.Length - 2)));
            }

            if (err101_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村６は5桁で入力して下さい。", err101_2.Remove(err101_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村６は5桁で入力して下さい。", EigyoBukaiTabNm, err101_2.Remove(err101_2.Length - 2)));
            }

            if (err102_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村７は半角数字で入力して下さい。", err102_1.Remove(err102_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村７は半角数字で入力して下さい。", EigyoBukaiTabNm, err102_1.Remove(err102_1.Length - 2)));
            }

            if (err102_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村７は5桁で入力して下さい。", err102_2.Remove(err102_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村７は5桁で入力して下さい。", EigyoBukaiTabNm, err102_2.Remove(err102_2.Length - 2)));
            }

            if (err103_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村８は半角数字で入力して下さい。", err103_1.Remove(err103_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村８は半角数字で入力して下さい。", EigyoBukaiTabNm, err103_1.Remove(err103_1.Length - 2)));
            }

            if (err103_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村８は5桁で入力して下さい。", err103_2.Remove(err103_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村８は5桁で入力して下さい。", EigyoBukaiTabNm, err103_2.Remove(err103_2.Length - 2)));
            }

            if (err104_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村９は半角数字で入力して下さい。", err104_1.Remove(err104_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村９は半角数字で入力して下さい。", EigyoBukaiTabNm, err104_1.Remove(err104_1.Length - 2)));
            }

            if (err104_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村９は5桁で入力して下さい。", err104_2.Remove(err104_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村９は5桁で入力して下さい。", EigyoBukaiTabNm, err104_2.Remove(err104_2.Length - 2)));
            }

            if (err105_1 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１０は半角数字で入力して下さい。", err105_1.Remove(err105_1.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村１０は半角数字で入力して下さい。", EigyoBukaiTabNm, err105_1.Remove(err105_1.Length - 2)));
            }

            if (err105_2 != string.Empty)
            {
                //errMsg.AppendLine(string.Format("行{0}: 担当市当町村１０は5桁で入力して下さい。", err105_2.Remove(err105_2.Length - 2)));
                errMsg.AppendLine(string.Format("{0}の行{1}: 担当市当町村１０は5桁で入力して下さい。", EigyoBukaiTabNm, err105_2.Remove(err105_2.Length - 2)));
            }*/

            #endregion

            // Data check fail
            if (!string.IsNullOrEmpty(errMsg.ToString().Replace(Environment.NewLine, string.Empty)))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            // Check OK
            return true;
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
        /// 2014/07/02  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// 2014/11/06　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoUpdate()
        {
            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();

            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // Get host name
            string host = Dns.GetHostName();

            // Set value for hidden columns in datagridviews
            BindingNewSourceForDgv(now, username, host);

            // Define a space instead of null cell
            AlternateDbNull();

            // Duplicate keys check
            // UPD 20140804 START ZynasSou
            //if (DuplicationCheck(gyoshaEigyoshoListDataGridView, "gyoshaEigyoshoRenbanCol.Name, true)
            //    || DuplicationCheck(gyoshaEigyoChikuListDataGridView, "GyoshaEigyoChikuRenbanCol.Name, true)
            //    || DuplicationCheck(gyoshaBukaiListDataGridView, "bukaiRenbanCol.Name, true))
            if (DuplicationCheck(gyoshaEigyoshoListDataGridView, gyoshaEigyoshoRenbanCol.Name, true)
                /*|| DuplicationCheck(gyoshaBukaiListDataGridView, "bukaiRenbanCol.Name, true)*/)
            // UPD 20140804 START ZynasSou
            {
                // Exit handle
                return false;
            }

            // Update 業者マスタ
            IDecisionBtnClickALInput decInput = new DecisionBtnClickALInput();
            // 表示モード
            decInput.DispMode = this._dispMode;
            // 業者マスタ Data table
            decInput.GyoshaMstDataTable = (this._dispMode == DispMode.Add) ?
                CreateGyoshaMstInsert(now, username, host) : CreateGyoshaMstUpdate(_gyoshaMst, username, host);
            // 業者営業所マスタ
            // UPD 20140728 START ZynasSou
            //decInput.GyoshaEigyoshoMstDataTable = _gyoshaEigyoshoMst.Count == 0 ?
            //    CreateGyoshaEigyoshoMstDefaultForInsert(now, username, host) : _gyoshaEigyoshoMst;
            decInput.GyoshaEigyoshoMstDataTable = CreateGyoshaEigyoshoMstDefaultForInsert(now, username, host);
            // UPD 20140728 END ZynasSou
            // 業者営業地区マスタ
            // UPD 20140728 START ZynasSou
            //decInput.GyoshaEigyoChikuMstDataTable = _gyoshaEigyoChikuMst.Count == 0 ?
            //    CreateGyoshaEigyoChikuMstDefaultForInsert(now, username, host) : _gyoshaEigyoChikuMst;
            decInput.GyoshaEigyoChikuMstDataTable = CreateGyoshaEigyoChikuMstDefaultForInsert(now, username, host);
            // UPD 20140728 END ZynasSou
            // 業者部会マスタ
            // UPD 20140728 START ZynasSou
            //decInput.GyoshaBukaiMstDataTable = _gyoshaBukaiMst.Count == 0 ?
            //    CreateGyoshaBukaiMstDefaultForInsert(now, username, host) : _gyoshaBukaiMst;
            //decInput.GyoshaBukaiMstDataTable = CreateGyoshaBukaiMstDefaultForInsert(now, username, host);
            // UPD 20140728 START ZynasSou
            // Execute update

            // 2014/11/06 AnhNV ADD Start
            if (string.IsNullOrEmpty(_gyoshaCd))
            {
                decInput.GyoshaBukaiMstDataTable = CreateGyoshaBukaiMstDataTableInsert(now, username, host);
            }
            // 2014/11/06 AnhNV ADD End
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

        #region EditCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            #region Tab 1

            // 業者名称(8)
            if (gyoshaNmTextBox.Text != _gyoshaMst[0].GyoshaNm) return false;

            // 業者カナ名(9)
            if (gyoshaKanaTextBox.Text != _gyoshaMst[0].GyoshaKana) return false;

            // 業者郵便番号(10)
            if (gyoshaZipCdTextBox.Text != _gyoshaMst[0].GyoshaZipCd) return false;

            // 業者住所(11)
            if (gyoshaAdrTextBox.Text != _gyoshaMst[0].GyoshaAdr) return false;

            // 業者電話番号(12)
            if (gyoshaTelNoTextBox.Text != _gyoshaMst[0].GyoshaTelNo) return false;

            // 業者Fax番号(13)
            if (gyoshaFaxNoTextBox.Text != _gyoshaMst[0].GyoshaFaxNo) return false;

            // 代表者氏名(14)
            if (daihyoshaNmTextBox.Text != _gyoshaMst[0].DaihyoshaNm) return false;

            // 工事業者区分(16)
            if ((!kojiGyoshaKbnCheckBox.Checked && _gyoshaMst[0].KojiGyoshaKbn == "1")
                || (kojiGyoshaKbnCheckBox.Checked && _gyoshaMst[0].KojiGyoshaKbn == "0")) return false;

            // 保守業者区分(17)
            if ((!hoshuGyoshaKbnCheckBox.Checked && _gyoshaMst[0].HoshuGyoshaKbn == "1")
                || (hoshuGyoshaKbnCheckBox.Checked && _gyoshaMst[0].HoshuGyoshaKbn == "0")) return false;

            // 取扱業者区分(18)
            //if ((!toriatsukaiGyoshaKbnCheckBox.Checked && _gyoshaMst[0].ToriatsukaiGyoshaKbn == "1")
            //    || (toriatsukaiGyoshaKbnCheckBox.Checked && _gyoshaMst[0].ToriatsukaiGyoshaKbn == "0")) return false;
            // v1.08
            if (Convert.ToString(toriatsukaiGyoshaKbnComboBox.SelectedValue) != _gyoshaMst[0].ToriatsukaiGyoshaKbn) return false;

            // 清掃業者区分(19)
            if ((!seisoGyoshaKbnCheckBox.Checked && _gyoshaMst[0].SeisoGyoshaKbn == "1")
                || (seisoGyoshaKbnCheckBox.Checked && _gyoshaMst[0].SeisoGyoshaKbn == "0")) return false;

            // 製造業者区分(20)
            if ((!seizoGyoShaKbnCheckBox.Checked && _gyoshaMst[0].SeizoGyoShaKbn == "1")
                || (seizoGyoShaKbnCheckBox.Checked && _gyoshaMst[0].SeizoGyoShaKbn == "0")) return false; ;

            // その他業者区分(21)
            if ((!sonotaGyoshaKbnCheckBox.Checked && _gyoshaMst[0].SonotaGyoshaKbn == "1")
                || (sonotaGyoshaKbnCheckBox.Checked && _gyoshaMst[0].SonotaGyoshaKbn == "0")) return false;

            // 工事登録番号(22)
            if (koujiTorokuNoTextBox.Text != _gyoshaMst[0].KoujiTorokuNo) return false;

            // 県保守業者登録番号(23)
            if (kenHoshuGyoShaTorokuNoTextBox.Text != _gyoshaMst[0].KenHoshuGyoShaTorokuNo) return false;

            // 取扱業者コード(24)
            if (Convert.ToDecimal(!string.IsNullOrEmpty(toriatsukaiGyoshaCdTextBox.Text) ? toriatsukaiGyoshaCdTextBox.Text : "99999")
                != Convert.ToDecimal(!string.IsNullOrEmpty(_gyoshaMst[0].ToriatsukaiGyoshaCd) ? _gyoshaMst[0].ToriatsukaiGyoshaCd : "99999")) return false;

            // メーカー名称(25)
            if (makerNmTextBox.Text != _gyoshaMst[0].MakerNm) return false;

            // 福岡市登録番号(112)
            if (fukuokashiGyoShaTorokuNoTextBox.Text != _gyoshaMst[0].FukuokashiGyoShaTorokuNo) { return false; }

            // 久留米市登録番号(113)
            if (kurumeshiGyoShaTorokuNoTextBox.Text != _gyoshaMst[0].KurumeshiGyoShaTorokuNo) { return false; }

            #endregion

            #region Tab 2

            // 還付有無フラグ(27)
            if ((!kanpuUmuFlgCheckBox.Checked && _gyoshaMst[0].KanpuUmuFlg == "1")
                || (kanpuUmuFlgCheckBox.Checked && _gyoshaMst[0].KanpuUmuFlg == "0")) return false;

            // 還付金集計先コード(28)
            if (Convert.ToDecimal(!string.IsNullOrEmpty(kanpukinShukeisakiCdTextBox.Text) ? kanpukinShukeisakiCdTextBox.Text : "99999")
                != Convert.ToDecimal(!string.IsNullOrEmpty(_gyoshaMst[0].KanpukinShukeisakiCd) ? _gyoshaMst[0].KanpukinShukeisakiCd : "99999")) return false;

            // 協同組合コード(29)
            if (kyodoKumiaiCdTextBox.Text != _gyoshaMst[0].KyodoKumiaiCd) return false;

            // 賛助会費(30)
            if (sanjokaihiTextBox.Text != _gyoshaMst[0].Sanjokaihi.ToString("N0")) return false;

            // 送付先担当者氏名(31)
            if (sofusakiTantoshaNmTextBox.Text != _gyoshaMst[0].SofusakiTantoshaNm) return false;

            // データ渡フラグ(32)
            if ((!dataWatashiFlgCheckBox.Checked && _gyoshaMst[0].DataWatashiFlg == "1")
                || (dataWatashiFlgCheckBox.Checked && _gyoshaMst[0].DataWatashiFlg == "0")) return false;

            // 基本データフラグ(34)
            if ((!kihonDataFlgCheckBox.Checked && _gyoshaMst[0].KihonDataFlg == "1")
                || (kihonDataFlgCheckBox.Checked && _gyoshaMst[0].KihonDataFlg == "0")) return false;

            // 水質データフラグ(35)
            if ((!suishitsuDataFlgCheckBox.Checked && _gyoshaMst[0].SuishitsuDataFlg == "1")
                || (suishitsuDataFlgCheckBox.Checked && _gyoshaMst[0].SuishitsuDataFlg == "0")) return false;

            // 所見データフラグ(36)
            if ((!shokenDataFlgCheckBox.Checked && _gyoshaMst[0].ShokenDataFlg == "1")
                || (shokenDataFlgCheckBox.Checked && _gyoshaMst[0].ShokenDataFlg == "0")) return false;

            // 外観データフラグ(37)
            if ((!gaikanDataFlgCheckBox.Checked && _gyoshaMst[0].GaikanDataFlg == "1")
                || (gaikanDataFlgCheckBox.Checked && _gyoshaMst[0].GaikanDataFlg == "0")) return false;

            // 書類検査データフラグ(38)
            if ((!shoruiDataFlgCheckBox.Checked && _gyoshaMst[0].ShoruiDataFlg == "1")
                || (shoruiDataFlgCheckBox.Checked && _gyoshaMst[0].ShoruiDataFlg == "0")) return false;

            // 5条データフラグ(39)
            if ((!jo5DataFlgCheckBox.Checked && _gyoshaMst[0]._5JoDataFlg == "1")
                || (jo5DataFlgCheckBox.Checked && _gyoshaMst[0]._5JoDataFlg == "0")) return false;

            // 7条データフラグ(40)
            if ((!jo7DataFlgCheckBox.Checked && _gyoshaMst[0]._7JoDataFlg == "1")
                || (jo7DataFlgCheckBox.Checked && _gyoshaMst[0]._7JoDataFlg == "0")) return false;

            // 11条水質データフラグ(41)
            if ((!jo11SuishitsuDataFlgCheckBox.Checked && _gyoshaMst[0]._11JoSuishitsuDataFlg == "1")
                || (jo11SuishitsuDataFlgCheckBox.Checked && _gyoshaMst[0]._11JoSuishitsuDataFlg == "0")) return false;

            // 11条外観データフラグ(42)
            if ((!jo11GaikanDataFlgCheckBox.Checked && _gyoshaMst[0]._11JoGaikanDataFlg == "1")
                || (jo11GaikanDataFlgCheckBox.Checked && _gyoshaMst[0]._11JoGaikanDataFlg == "0")) return false;

            // 発送担当者
            if (hassoTantoshaTextBox.Text != _gyoshaMst[0].HassoTantosha) { return false; }

            #endregion

            #region Tab 3

            // 支払区分(43)
            if (shiharaiKbnComboBox.SelectedValue != null && shiharaiKbnComboBox.SelectedValue.ToString() != _gyoshaMst[0].ShiharaiKbn) return false;

            // ADD START 20140718 ZynasSou
            // 金融機関コード
            if (bankCdTextBox.Text != _gyoshaMst[0].BankCd) return false;
            // ADD END 20140718 ZynasSou

            // 銀行名称(45)
            if (bankNmTextBox.Text != _gyoshaMst[0].BankNm) return false;

            // ADD START 20140718 ZynasSou
            // 支店コード
            if (bankShitenCdTextBox.Text != _gyoshaMst[0].BankShitenCd) return false;
            // ADD END 20140718 ZynasSou

            // 銀行支店名称(46)
            if (bankShitenNmTextBox.Text != _gyoshaMst[0].BankShitenNm) return false;

            // 銀行口座種別名(47)
            if (bankKozaShubetsuNmTextBox.Text != _gyoshaMst[0].BankKozaShubetsuNm) return false;

            // 銀行口座番号(48)
            if (bankKozaNoTextBox.Text != _gyoshaMst[0].BankKozaNo) return false;

            // 銀行口座名義(49)
            if (bankKozaMeigiTextBox.Text != _gyoshaMst[0].BankKozaMeigi) return false;

            // 会員価格適用区分(49-2)
            if ((kaiinKbnCheckBox.Checked && _gyoshaMst[0].KaiinKbn != "1")
                || (!kaiinKbnCheckBox.Checked && _gyoshaMst[0].KaiinKbn != "0")) return false;

            // DEL START 20140718 ZynasSou
            //// 会員区分(51)
            //if ((!kaiinKbnCheckBox.Checked && _gyoshaMst[0].KaiinKbn == "1")
            //    || (kaiinKbnCheckBox.Checked && _gyoshaMst[0].KaiinKbn == "0")) return false;
            //
            //// 廃業フラグ(52)
            //if ((!haigyoFlgCheckBox.Checked && _gyoshaMst[0].HaigyoFlg == "1")
            //    || (haigyoFlgCheckBox.Checked && _gyoshaMst[0].HaigyoFlg == "0")) return false;
            //
            //// 請求分離フラグ(53)
            //if ((!seikyuBunriFlgCheckBox.Checked && _gyoshaMst[0].SeikyuBunriFlg == "1")
            //    || (seikyuBunriFlgCheckBox.Checked && _gyoshaMst[0].SeikyuBunriFlg == "0")) return false;
            //
            //// 7条検査依頼一覧発行フラグ(54)
            //if ((!jo7KensaIraiIchiranHakkoFlgCheckBox.Checked && _gyoshaMst[0]._7JoKensaIraiIchiranHakkoFlg == "1")
            //    || (jo7KensaIraiIchiranHakkoFlgCheckBox.Checked && _gyoshaMst[0]._7JoKensaIraiIchiranHakkoFlg == "0")) return false;
            // DEL END 20140718 ZynasSou

            // ADD 20140724 START ZynasSou
            // 廃業日(50)
            if (bukaiHaigyoDtTextBox.Text != _gyoshaMst[0].HaigyoDt) return false;

            // 廃業理由(51)
            if (bukaiHaigyoRiyuTextBox.Text != _gyoshaMst[0].HaigyoRiyu) return false;
            // ADD 20140724 END ZynasSou

            // 一括請求先コード(115)
            if (ikkatsuSeikyuSakiCdTextBox.Text != _gyoshaMst[0].IkkatsuSeikyuSakiCd) { return false; }

            #endregion

            #region Tab 5

            // 全営業区域フラグ
            if (zenEigyoKuikiFlgCheckBox.Checked && _gyoshaMst[0].ZenEigyoKuikiFlg == "0") { return false; }

            if (!zenEigyoKuikiFlgCheckBox.Checked && _gyoshaMst[0].ZenEigyoKuikiFlg == "1") { return false; }

            #endregion

            return true;
        }
        #endregion

        #region EditControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditControl()
        {
            #region Tab 1

            // 業者コード(7)
            if (!string.IsNullOrEmpty(gyoshaCdTextBox.Text)) return true;

            // 業者名称(8)
            if (!string.IsNullOrEmpty(gyoshaNmTextBox.Text)) return true;

            // 業者カナ名(9)
            if (!string.IsNullOrEmpty(gyoshaKanaTextBox.Text)) return true;

            // 業者郵便番号(10)
            if (!string.IsNullOrEmpty(gyoshaZipCdTextBox.Text)) return true;

            // 業者住所(11)
            if (!string.IsNullOrEmpty(gyoshaAdrTextBox.Text)) return true;

            // 業者電話番号(12)
            if (!string.IsNullOrEmpty(gyoshaTelNoTextBox.Text)) return true;

            // 業者Fax番号(13)
            if (!string.IsNullOrEmpty(gyoshaFaxNoTextBox.Text)) return true;

            // 代表者氏名(14)
            if (!string.IsNullOrEmpty(daihyoshaNmTextBox.Text)) return true;

            // 工事業者区分(16)
            if (kojiGyoshaKbnCheckBox.Checked) return true;

            // 保守業者区分(17)
            if (hoshuGyoshaKbnCheckBox.Checked) return true;

            // 取扱業者区分(18)
            //if (toriatsukaiGyoshaKbnComboBox.Checked) return true;

            // 清掃業者区分(19)
            if (seisoGyoshaKbnCheckBox.Checked) return true;

            // 製造業者区分(20)
            if (seizoGyoShaKbnCheckBox.Checked) return true; ;

            // その他業者区分(21)
            if (sonotaGyoshaKbnCheckBox.Checked) return true;

            // 工事登録番号(22)
            if (!string.IsNullOrEmpty(koujiTorokuNoTextBox.Text)) return true;

            // 県保守業者登録番号(23)
            if (!string.IsNullOrEmpty(kenHoshuGyoShaTorokuNoTextBox.Text)) return true;

            // 取扱業者コード(24)
            if (!string.IsNullOrEmpty(toriatsukaiGyoshaCdTextBox.Text)) return true;

            // メーカー名称(25)
            if (!string.IsNullOrEmpty(makerNmTextBox.Text)) return true;

            // 福岡市登録番号
            if (!string.IsNullOrEmpty(fukuokashiGyoShaTorokuNoTextBox.Text)) { return true; }

            // 久留米市登録番号
            if (!string.IsNullOrEmpty(kurumeshiGyoShaTorokuNoTextBox.Text)) { return true; }

            #endregion

            #region Tab 2

            // 還付有無フラグ(27)
            if (kanpuUmuFlgCheckBox.Checked) return true;

            // 還付金集計先コード(28)
            if (!string.IsNullOrEmpty(kanpukinShukeisakiCdTextBox.Text)) return true;

            // 協同組合コード(29)
            if (!string.IsNullOrEmpty(kyodoKumiaiCdTextBox.Text)) return true;

            // 賛助会費(30)
            if (!string.IsNullOrEmpty(sanjokaihiTextBox.Text)) return true;

            // 送付先担当者氏名(31)
            if (!string.IsNullOrEmpty(sofusakiTantoshaNmTextBox.Text)) return true;

            // データ渡フラグ(32)
            if (dataWatashiFlgCheckBox.Checked) return true;

            // 基本データフラグ(34)
            if (kihonDataFlgCheckBox.Checked) return true;

            // 水質データフラグ(35)
            if (suishitsuDataFlgCheckBox.Checked) return true;

            // 所見データフラグ(36)
            if (shokenDataFlgCheckBox.Checked) return true;

            // 外観データフラグ(37)
            if (gaikanDataFlgCheckBox.Checked) return true;

            // 書類検査データフラグ(38)
            if (shoruiDataFlgCheckBox.Checked) return true;

            // 5条データフラグ(39)
            if (jo5DataFlgCheckBox.Checked) return true;

            // 7条データフラグ(40)
            if (jo7DataFlgCheckBox.Checked) return true;

            // 11条水質データフラグ(41)
            if (jo11SuishitsuDataFlgCheckBox.Checked) return true;

            // 11条外観データフラグ(42)
            if (jo11GaikanDataFlgCheckBox.Checked) return true;

            // 発送担当者
            if (!string.IsNullOrEmpty(hassoTantoshaTextBox.Text)) { return true; }

            #endregion

            #region Tab 3

            // 支払区分(43)
            if (shiharaiKbnComboBox.SelectedIndex > 0) return true;

            // ADD START 20140718 ZynasSou
            // 金融機関コード
            if (!string.IsNullOrEmpty(bankCdTextBox.Text)) return true;
            // ADD END 20140718 ZynasSou

            // 銀行名称(45)
            if (!string.IsNullOrEmpty(bankNmTextBox.Text)) return true;

            // ADD START 20140718 ZynasSou
            // 支店コード
            if (!string.IsNullOrEmpty(bankShitenCdTextBox.Text)) return true;
            // ADD END 20140718 ZynasSou

            // 銀行支店名称(46)
            if (!string.IsNullOrEmpty(bankShitenNmTextBox.Text)) return true;

            // 銀行口座種別名(47)
            if (!string.IsNullOrEmpty(bankKozaShubetsuNmTextBox.Text)) return true;

            // 銀行口座番号(48)
            if (!string.IsNullOrEmpty(bankKozaNoTextBox.Text)) return true;

            // 銀行口座名義(49)
            if (!string.IsNullOrEmpty(bankKozaMeigiTextBox.Text)) return true;

            // 会員価格適用区分(49-2)
            if (kaiinKbnCheckBox.Checked) return true;

            // DEL START 20140718 ZynasSou
            //// 会員区分(51)
            //if (kaiinKbnCheckBox.Checked) return true;
            //
            //// 廃業フラグ(52)
            //if (haigyoFlgCheckBox.Checked) return true;
            //
            //// 請求分離フラグ(53)
            //if (seikyuBunriFlgCheckBox.Checked) return true;
            //
            //// 7条検査依頼一覧発行フラグ(54)
            //if (jo7KensaIraiIchiranHakkoFlgCheckBox.Checked) return true;
            // DEL END 20140718 ZynasSou

            // ADD 20140724 START ZynasSou
            // 廃業日(50)
            if (!string.IsNullOrEmpty(bukaiHaigyoDtTextBox.Text)) return true;

            // 廃業理由(51)
            if (!string.IsNullOrEmpty(bukaiHaigyoRiyuTextBox.Text)) return true;
            // ADD 20140724 END ZynasSou

            // 一括請求先コード(115)
            if (!string.IsNullOrEmpty(ikkatsuSeikyuSakiCdTextBox.Text)) { return true; }
            
            #endregion

            #region Tab 5

            // 全営業区域フラグ(67)
            if (zenEigyoKuikiFlgCheckBox.Checked) { return true; }

            #endregion

            return false;
        }
        #endregion

        #region BindingNewSourceForDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： BindingNewSourceForDgv
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="username"></param>
        /// <param name="hostname"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BindingNewSourceForDgv
            (
                DateTime now,
                string username,
                string hostname
            )
        {
            // 業者営業所一覧データグリッドビュー(55)
            foreach (DataGridViewRow dgvr in gyoshaEigyoshoListDataGridView.Rows)
            {
                // Break from the last row
                if (gyoshaEigyoshoListDataGridView.Rows.Count > 1 && dgvr.Index == gyoshaEigyoshoListDataGridView.Rows.Count - 1) break;

                // 業者コード
                dgvr.Cells[gyoshaEigyoshoGyoshaCdCol.Name].Value = gyoshaCdTextBox.Text;

                // 登録日時
                dgvr.Cells[eigyoInsertDtCol.Name].Value = (dgvr.Cells[eigyoInsertDtCol.Name].Value == null || string.IsNullOrEmpty(dgvr.Cells[eigyoInsertDtCol.Name].Value.ToString()))
                    ? now : dgvr.Cells[eigyoInsertDtCol.Name].Value;

                // 登録者
                dgvr.Cells[eigyoInsertUserCol.Name].Value = username;

                // 登録端末
                dgvr.Cells[eigyoInsertTarmCol.Name].Value = hostname;

                // 更新日時
                dgvr.Cells[eigyoUpdateDtCol.Name].Value = now;

                // 更新者
                dgvr.Cells[eigyoUpdateUserCol.Name].Value = username;

                // 更新端末
                dgvr.Cells[eigyoUpdateTarmCol.Name].Value = hostname;
            }

            // 業者営業地区一覧データグリッドビュー(68)
            foreach (DataGridViewRow dgvr in gyoshaEigyoChikuListDataGridView.Rows)
            {
                // Break from the last row
                if (gyoshaEigyoChikuListDataGridView.Rows.Count > 1 && dgvr.Index == gyoshaEigyoChikuListDataGridView.Rows.Count - 1) break;

                // 業者コード
                dgvr.Cells[gyoshaEigyoChikuGyoshaCdCol.Name].Value = gyoshaCdTextBox.Text;

                // 登録日時
                dgvr.Cells[chikuInsertDtCol.Name].Value = (dgvr.Cells[chikuInsertDtCol.Name].Value == null || string.IsNullOrEmpty(dgvr.Cells[chikuInsertDtCol.Name].Value.ToString()))
                    ? now : dgvr.Cells[chikuInsertDtCol.Name].Value;

                // 登録者
                dgvr.Cells[chikuInsertUserCol.Name].Value = username;

                // 登録端末
                dgvr.Cells[chikuInsertTarmCol.Name].Value = hostname;

                // 更新日時
                dgvr.Cells[chikuUpdateDtCol.Name].Value = now;

                // 更新者
                dgvr.Cells[chikuUpdateUserCol.Name].Value = username;

                // 更新端末
                dgvr.Cells[chikuUpdateTarmCol.Name].Value = hostname;
            }
            if (_dispMode == DispMode.Add) gyoshaEigyoChikuListDataGridView.DataSource = _gyoshaEigyoChikuMst;
            
            // 業者部会一覧データグリッドビュー(71)
            //foreach (DataGridViewRow dgvr in gyoshaBukaiListDataGridView.Rows)
            //{
            //    // Break from the last row
            //    if (gyoshaBukaiListDataGridView.Rows.Count > 1 && dgvr.Index == gyoshaBukaiListDataGridView.Rows.Count - 1) break;

            //    // 業者コード
            //    dgvr.Cells[bukaiGyoshaCdCol.Name].Value = gyoshaCdTextBox.Text;

            //    // 登録日時
            //    dgvr.Cells[bukaiInsertDtCol.Name].Value = (dgvr.Cells[bukaiInsertDtCol.Name].Value == null || string.IsNullOrEmpty(dgvr.Cells[bukaiInsertDtCol.Name].Value.ToString()))
            //        ? now : dgvr.Cells[bukaiInsertDtCol.Name].Value;

            //    // 登録者
            //    dgvr.Cells[bukaiInsertUserCol.Name].Value = username;

            //    // 登録端末
            //    dgvr.Cells[bukaiInsertTarmCol.Name].Value = hostname;

            //    // 更新日時
            //    dgvr.Cells[bukaiUpdateDtCol.Name].Value = now;

            //    // 更新者
            //    dgvr.Cells[bukaiUpdateUserCol.Name].Value = username;

            //    // 更新端末
            //    dgvr.Cells[bukaiUpdateTarmCol.Name].Value = hostname;
            //}
        }
        #endregion

        #region DgvVisibleControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DgvVisibleControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="enable">TRUE: enable, FALSE: disable</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DgvVisibleControl(DataGridView dgv, bool enable)
        {
            // Enable/Disable dgv
            dgv.ForeColor = !enable ? Color.Gray : DefaultForeColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = !enable ? Color.Gray : DefaultForeColor;
            dgv.EnableHeadersVisualStyles = enable;
            foreach (DataGridViewColumn dc in dgv.Columns)
            {
                dc.ReadOnly = !enable;
            }
        }
        #endregion

        #region SetUnlimitInputForDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetUnlimitInputForDgv
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="enable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetUnlimitInputForDgv()
        {
            // 業者営業所一覧データグリッドビュー(55)
            foreach (DataColumn dc in _gyoshaEigyoshoMst.Columns)
            {
                if (dc.Ordinal > 11) break;
                dc.MaxLength = Int32.MaxValue;
            }

            // 業者営業地区一覧データグリッドビュー(68)
            foreach (DataColumn dc in _gyoshaEigyoChikuMst.Columns)
            {
                // UPD 20140804 START ZynasSou
                //if (dc.Ordinal > 2) break;
                if (dc.Ordinal > 1) break;
                // UPD 20140804 END ZynasSou
                dc.MaxLength = Int32.MaxValue;
            }

            // 業者部会一覧データグリッドビュー(71)
            foreach (DataColumn dc in _gyoshaBukaiMst.Columns)
            {
                // UPD 20140724 START ZynasSou
                //if (dc.Ordinal > 33) break;
                if (dc.Ordinal > 31) break;
                // UPD 20140724 END ZynasSou
                dc.MaxLength = Int32.MaxValue;
            }
        }
        #endregion

        #region gyoshaEigyoshoListDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： gyoshaEigyoshoListDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoshoListDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (gyoshaEigyoshoListDataGridView.CurrentCell.ColumnIndex)
            {
                case 1:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    e.Handled = !IsOKForDecimalTextBox(e.KeyChar, sender as TextBox) ? true : false;
                    break;
                case 3:
                case 5:
                case 6:
                    e.Handled = !IsOKForDecimalWithNegativeTextBox(e.KeyChar, sender as TextBox) ? true : false;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region gyoshaEigyoChikuListDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： gyoshaEigyoChikuListDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaEigyoChikuListDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsOKForDecimalTextBox(e.KeyChar, sender as TextBox))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        #region gyoshaBukaiListDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： gyoshaBukaiListDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10　AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaBukaiListDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            //if (gyoshaBukaiListDataGridView.CurrentCell.ColumnIndex != 5)
            //{
            //    if (!IsOKForDecimalTextBox(e.KeyChar, sender as TextBox))
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
            //}
        }
        #endregion

        #region RemoveDgvSourceConstraints
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RemoveDgvSourceConstraints
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RemoveDgvSourceConstraints()
        {
            // 業者営業所一覧データグリッドビュー(55)
            _gyoshaEigyoshoMst.PrimaryKey = null;
            foreach (DataColumn dc in _gyoshaEigyoshoMst.Columns)
            {
                dc.AllowDBNull = true;
            }

            // 業者営業地区一覧データグリッドビュー(68)
            _gyoshaEigyoChikuMst.PrimaryKey = null;
            foreach (DataColumn dc in _gyoshaEigyoChikuMst.Columns)
            {
                dc.AllowDBNull = true;
            }

            // 業者部会一覧データグリッドビュー(71)
            _gyoshaBukaiMst.PrimaryKey = null;
            foreach (DataColumn dc in _gyoshaBukaiMst.Columns)
            {
                dc.AllowDBNull = true;
            }
        }
        #endregion

        #region IsOKForDecimalTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsOKForDecimalTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="textBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsOKForDecimalTextBox(char character, TextBox textBox)
        {
            if (!char.IsControl(character)
                && !char.IsDigit(character))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region IsOKForDecimalWithNegativeTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsOKForDecimalWithNegativeTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="textBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsOKForDecimalWithNegativeTextBox(char character, TextBox textBox)
        {
            if (!char.IsControl(character)
                && !char.IsDigit(character)
                && (character != '-'))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region AlternateDbNull
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AlternateDbNull
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/14　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void AlternateDbNull()
        {
            // 業者営業所一覧データグリッドビュー(55)
            foreach (GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstRow dr in _gyoshaEigyoshoMst)
            {
                if (dr["GyoshaEigyoshoGyoshaCd"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoGyoshaCd"] = gyoshaCdTextBox.Text;
                }

                if (dr["GyoshaEigyoshoRenban"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoRenban"] = " ";
                }

                if (dr["GyoshaEigyoshoNm"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoNm"] = " ";
                }

                if (dr["GyoshaEigyoshoZipCd"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoZipCd"] = " ";
                }

                if (dr["GyoshaEigyoshoAdr"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoAdr"] = " ";
                }

                if (dr["GyoshaEigyoshoTelNo"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoTelNo"] = " ";
                }

                if (dr["GyoshaEigyoshoFaxNo"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoFaxNo"] = " ";
                }

                if (dr["GyoshaEigyoshoHokenjo1"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoHokenjo1"] = " ";
                }

                if (dr["GyoshaEigyoshoHokenjo2"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoHokenjo2"] = " ";
                }

                if (dr["GyoshaEigyoshoHokenjo3"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoHokenjo3"] = " ";
                }

                if (dr["GyoshaEigyoshoHokenjo4"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoHokenjo4"] = " ";
                }

                if (dr["GyoshaEigyoshoHokenjo5"] == DBNull.Value)
                {
                    dr["GyoshaEigyoshoHokenjo5"] = " ";
                }
            }

            // 業者営業地区一覧データグリッドビュー(68)
            foreach (GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstRow dr in _gyoshaEigyoChikuMst)
            {
                if (dr["GyoshaEigyoChikuGyoshaCd"] == DBNull.Value)
                {
                    dr["GyoshaEigyoChikuGyoshaCd"] = gyoshaCdTextBox.Text;
                }

                // DEL 20140804 START ZynasSou
                //if (dr["GyoshaEigyoChikuRenban"] == DBNull.Value)
                //{
                //    dr["GyoshaEigyoChikuRenban"] = " ";
                //}
                // DEL 20140804 END ZynasSou

                if (dr["GyoshaEigyoChikuCd"] == DBNull.Value)
                {
                    dr["GyoshaEigyoChikuCd"] = " ";
                }
            }

            // 業者部会一覧データグリッドビュー(71)
            foreach (GyoshaBukaiMstDataSet.GyoshaBukaiMstRow dr in _gyoshaBukaiMst)
            {
                if (dr["BukaiGyoshaCd"] == DBNull.Value)
                {
                    dr["BukaiGyoshaCd"] = gyoshaCdTextBox.Text;
                }

                // UPD 20140724 START ZynasSou
                //if (dr["BukaiRenban"] == DBNull.Value)
                //{
                //    dr["BukaiRenban"] = " ";
                //}
                if (dr["BukaiKbn"] == DBNull.Value)
                {
                    dr["BukaiKbn"] = " ";
                }
                // UPD 20140724 START ZynasSou

                if (dr["BukaiKaiinCd"] == DBNull.Value)
                {
                    dr["BukaiKaiinCd"] = " ";
                }

                if (dr["BukaiNyukaiDt"] == DBNull.Value)
                {
                    dr["BukaiNyukaiDt"] = " ";
                }

                if (dr["BukaiTaikaiDt"] == DBNull.Value)
                {
                    dr["BukaiTaikaiDt"] = " ";
                }

                if (dr["BukaiSetsubishiDaihyoshaNm"] == DBNull.Value)
                {
                    dr["BukaiSetsubishiDaihyoshaNm"] = " ";
                }

                if (dr["BukaiMenJoNo"] == DBNull.Value)
                {
                    dr["BukaiMenJoNo"] = " ";
                }

                // DEL 20140724 START ZynasSou
                //if (dr["BukaiHaigyoDt"] == DBNull.Value)
                //{
                //    dr["BukaiHaigyoDt"] = " ";
                //}
                // DEL 20140724 END ZynasSou

                // DEL 20140724 START ZynasSou
                //if (dr["BukaiHaigyoRiyu"] == DBNull.Value)
                //{
                //    dr["BukaiHaigyoRiyu"] = " ";
                //}
                // DEL 20140724 END ZynasSou

                if (dr["BukaiKankeiHokenjo1"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo1"] = " ";
                }

                if (dr["BukaiKankeiHokenjo2"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo2"] = " ";
                }

                if (dr["BukaiKankeiHokenjo3"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo3"] = " ";
                }

                if (dr["BukaiKankeiHokenjo4"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo4"] = " ";
                }

                if (dr["BukaiKankeiHokenjo5"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo5"] = " ";
                }

                if (dr["BukaiKankeiHokenjo6"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo6"] = " ";
                }

                if (dr["BukaiKankeiHokenjo7"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo7"] = " ";
                }

                if (dr["BukaiKankeiHokenjo8"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo8"] = " ";
                }

                if (dr["BukaiKankeiHokenjo9"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo9"] = " ";
                }

                if (dr["BukaiKankeiHokenjo10"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo10"] = " ";
                }

                if (dr["BukaiKankeiHokenjo11"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo11"] = " ";
                }

                if (dr["BukaiKankeiHokenjo12"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo12"] = " ";
                }

                if (dr["BukaiKankeiHokenjo13"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo13"] = " ";
                }

                if (dr["BukaiKankeiHokenjo14"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo14"] = " ";
                }

                if (dr["BukaiKankeiHokenjo15"] == DBNull.Value)
                {
                    dr["BukaiKankeiHokenjo15"] = " ";
                }

                if (dr["BukaiTantoShichoson1"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson1"] = " ";
                }

                if (dr["BukaiTantoShichoson2"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson2"] = " ";
                }

                if (dr["BukaiTantoShichoson3"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson3"] = " ";
                }

                if (dr["BukaiTantoShichoson4"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson4"] = " ";
                }

                if (dr["BukaiTantoShichoson5"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson5"] = " ";
                }

                if (dr["BukaiTantoShichoson6"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson6"] = " ";
                }

                if (dr["BukaiTantoShichoson7"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson7"] = " ";
                }

                if (dr["BukaiTantoShichoson8"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson8"] = " ";
                }

                if (dr["BukaiTantoShichoson9"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson9"] = " ";
                }

                if (dr["BukaiTantoShichoson10"] == DBNull.Value)
                {
                    dr["BukaiTantoShichoson10"] = " ";
                }
            }
        }
        #endregion

        #region DuplicationCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DuplicationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnNm"></param>
        /// <param name="dgv"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DuplicationCheck(DataGridView dgv, string columnNm, bool showMsg)
        {
            bool isDuplicate = false;

            // Use the currentRow to compare against
            for (int currentRow = 0; currentRow < dgv.Rows.Count - 1; currentRow++)
            {
                bool unHighlight = true;

                DataGridViewRow rowToCompare = dgv.Rows[currentRow];
                for (int otherRow = 0; otherRow < dgv.Rows.Count - 1; otherRow++)
                {
                    bool duplicateRow = false;
                    DataGridViewRow row = dgv.Rows[otherRow];

                    // compare cell SetKomokuCdCol between the two rows
                    if (currentRow != otherRow
                        && !string.IsNullOrEmpty(rowToCompare.Cells[columnNm].Value.ToString())
                        && !string.IsNullOrEmpty(row.Cells[columnNm].Value.ToString())
                        && rowToCompare.Cells[columnNm].Value.Equals(row.Cells[columnNm].Value))
                    {
                        // UPD 20140728 START ZynasSou
                        //duplicateRow = true;
                        if (!string.IsNullOrEmpty(row.Cells[columnNm].Value.ToString()))
                        {
                            duplicateRow = true;
                        }
                        // UPD 20140728 START ZynasSou
                    }

                    // Constraint violation
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
                MessageForm.Show2(MessageForm.DispModeType.Error, "連番が重複しています。");
            }

            return isDuplicate;
        }
        #endregion

        #region CreateGyoshaMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGyoshaMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="username"></param>
        /// <param name="hostname"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GyoshaMstDataSet.GyoshaMstDataTable CreateGyoshaMstInsert
            (
                DateTime now,
                string username,
                string hostname
            )
        {
            GyoshaMstDataSet.GyoshaMstDataTable table = new GyoshaMstDataSet.GyoshaMstDataTable();
            GyoshaMstDataSet.GyoshaMstRow newRow = table.NewGyoshaMstRow();

            // ADD 20140724 START ZynasSou
            // 未入力項目の値設定（暫定）
            // 会員区分
            //newRow.KaiinKbn = string.Empty;
            newRow.KaiinKbn = kaiinKbnCheckBox.Checked ? "1" : "0";
            // 廃業フラグ
            newRow.HaigyoFlg = string.Empty;
            // 請求分離フラグ
            newRow.SeikyuBunriFlg = string.Empty;
            // 請求分離フラグ
            newRow._7JoKensaIraiIchiranHakkoFlg = string.Empty;
            // ADD 20140724 START ZynasSou

            // 業者コード(7)
            // ADD 20140724 START ZynasSou
            gyoshaCdTextBox.Text = Utility.Saiban.GetKeyRenban("GyoshaMst", "", "", "").PadLeft(4,'0');
            // ADD 20140724 START ZynasSou
            newRow.GyoshaCd = gyoshaCdTextBox.Text;
            // 業者名称(8)
            newRow.GyoshaNm = gyoshaNmTextBox.Text;
            // 業者カナ名(9)
            newRow.GyoshaKana = gyoshaKanaTextBox.Text;
            // 業者郵便番号(10)
            newRow.GyoshaZipCd = gyoshaZipCdTextBox.Text;
            // 業者住所(11)
            newRow.GyoshaAdr = gyoshaAdrTextBox.Text;
            // 業者電話番号(12)
            newRow.GyoshaTelNo = gyoshaTelNoTextBox.Text;
            // 業者Fax番号(13)
            newRow.GyoshaFaxNo = gyoshaFaxNoTextBox.Text;
            // 代表者氏名(14)
            newRow.DaihyoshaNm = daihyoshaNmTextBox.Text;
            // 工事業者区分(16)
            newRow.KojiGyoshaKbn = kojiGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 保守業者区分(17)
            newRow.HoshuGyoshaKbn = hoshuGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 取扱業者区分(18)
            //newRow.ToriatsukaiGyoshaKbn = toriatsukaiGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 清掃業者区分(19)
            newRow.SeisoGyoshaKbn = seisoGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 製造業者区分(20)
            newRow.SeizoGyoShaKbn = seizoGyoShaKbnCheckBox.Checked ? "1" : "0";
            // その他業者区分(21)
            newRow.SonotaGyoshaKbn = sonotaGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 工事登録番号(22)
            newRow.KoujiTorokuNo = koujiTorokuNoTextBox.Text;
            // 県保守業者登録番号(23)
            newRow.KenHoshuGyoShaTorokuNo = kenHoshuGyoShaTorokuNoTextBox.Text;
            // 取扱業者コード(24)
            newRow.ToriatsukaiGyoshaCd = toriatsukaiGyoshaCdTextBox.Text;
            // メーカー名称(25)
            newRow.MakerNm = makerNmTextBox.Text;
            // 還付有無フラグ(27)
            newRow.KanpuUmuFlg = kanpuUmuFlgCheckBox.Checked ? "1" : "0";
            // 還付金集計先コード(28)
            newRow.KanpukinShukeisakiCd = kanpukinShukeisakiCdTextBox.Text;
            // 協同組合コード(29)
            newRow.KyodoKumiaiCd = kyodoKumiaiCdTextBox.Text;
            // 賛助会費(30)
            newRow.Sanjokaihi = !string.IsNullOrEmpty(sanjokaihiTextBox.Text.Trim()) ? Convert.ToDecimal(sanjokaihiTextBox.Text) : 0;
            // 送付先担当者氏名(31)
            newRow.SofusakiTantoshaNm = sofusakiTantoshaNmTextBox.Text;
            // データ渡フラグ(32)
            newRow.DataWatashiFlg = dataWatashiFlgCheckBox.Checked ? "1" : "0";
            // 基本データフラグ(34)
            newRow.KihonDataFlg = kihonDataFlgCheckBox.Checked ? "1" : "0";
            // 水質データフラグ(35)
            newRow.SuishitsuDataFlg = suishitsuDataFlgCheckBox.Checked ? "1" : "0";
            // 所見データフラグ(36)
            newRow.ShokenDataFlg = shokenDataFlgCheckBox.Checked ? "1" : "0";
            // 外観データフラグ(37)
            newRow.GaikanDataFlg = gaikanDataFlgCheckBox.Checked ? "1" : "0";
            // 書類検査データフラグ(38)
            newRow.ShoruiDataFlg = shoruiDataFlgCheckBox.Checked ? "1" : "0";
            // 5条データフラグ(39)
            newRow._5JoDataFlg = jo5DataFlgCheckBox.Checked ? "1" : "0";
            // 7条データフラグ(40)
            newRow._7JoDataFlg = jo7DataFlgCheckBox.Checked ? "1" : "0";
            // 11条水質データフラグ(41)
            newRow._11JoSuishitsuDataFlg = jo11SuishitsuDataFlgCheckBox.Checked ? "1" : "0";
            // 11条外観データフラグ(42)
            newRow._11JoGaikanDataFlg = jo11GaikanDataFlgCheckBox.Checked ? "1" : "0";
            // 基本情報タブ.支払区分(43)
            newRow.ShiharaiKbn = (shiharaiKbnComboBox.SelectedValue != null) ? shiharaiKbnComboBox.SelectedValue.ToString() : string.Empty;

            // ADD START 20140718 ZynasSou
            // 金融機関コード
            newRow.BankCd = bankCdTextBox.Text;
            // ADD END 20140718 ZynasSou

            // 銀行名称(45)
            newRow.BankNm = bankNmTextBox.Text;

            // ADD START 20140718 ZynasSou
            // 支店コード
            newRow.BankShitenCd = bankShitenCdTextBox.Text;
            // ADD END 20140718 ZynasSou

            // 銀行支店名称(46)
            newRow.BankShitenNm = bankShitenNmTextBox.Text;
            // 銀行口座種別名(47)
            newRow.BankKozaShubetsuNm = bankKozaShubetsuNmTextBox.Text;
            // 銀行口座番号(48)
            newRow.BankKozaNo = bankKozaNoTextBox.Text;
            // 銀行口座名義(49)
            newRow.BankKozaMeigi = bankKozaMeigiTextBox.Text;

            // DEL START 20140718 ZynasSou
            //// 会員区分(51)
            //newRow.KaiinKbn = kaiinKbnCheckBox.Checked ? "1" : "0";
            //
            // 廃業日(49-3)
            newRow.HaigyoFlg = !string.IsNullOrEmpty(bukaiHaigyoDtTextBox.Text) ? "1" : "0";
            //
            //// 請求分離フラグ(53)
            //newRow.SeikyuBunriFlg = seikyuBunriFlgCheckBox.Checked ? "1" : "0";
            //
            //// 7条検査依頼一覧発行フラグ(54)
            //newRow._7JoKensaIraiIchiranHakkoFlg = jo7KensaIraiIchiranHakkoFlgCheckBox.Checked ? "1" : "0";
            // DEL END 20140718 ZynasSou

            // 全営業区域フラグ(67)
            newRow.ZenEigyoKuikiFlg = zenEigyoKuikiFlgCheckBox.Checked ? "1" : "0";

            // ADD 20140724 START ZynasSou
            // 廃業日
            newRow.HaigyoDt = bukaiHaigyoDtTextBox.Text;
            // ADD 20140724 END ZynasSou

            // ADD 20140724 START ZynasSou
            // 廃業理由
            newRow.HaigyoRiyu = bukaiHaigyoRiyuTextBox.Text;
            // ADD 20140724 END ZynasSou

            // 2014/11/04 AnhNV Add start
            // 福岡市登録番号(112)
            newRow.FukuokashiGyoShaTorokuNo = fukuokashiGyoShaTorokuNoTextBox.Text;
            // 久留米市登録番号(113)
            newRow.KurumeshiGyoShaTorokuNo = kurumeshiGyoShaTorokuNoTextBox.Text;
            // 発送担当者(114)
            newRow.HassoTantosha = hassoTantoshaTextBox.Text;
            // 一括請求先コード(115)
            newRow.IkkatsuSeikyuSakiCd = ikkatsuSeikyuSakiCdTextBox.Text;
            // 2014/11/04 AnhNV Add end

            // 登録日時
            newRow.InsertDt =
            // 更新日時
            newRow.UpdateDt = now;
            // 登録者
            newRow.InsertUser =
            // 更新者
            newRow.UpdateUser = username;
            // 登録端末
            newRow.InsertTarm =
            // 更新端末
            newRow.UpdateTarm = hostname;
            // 行を挿入
            table.AddGyoshaMstRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateGyoshaMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGyoshaMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="username"></param>
        /// <param name="hostname"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GyoshaMstDataSet.GyoshaMstDataTable CreateGyoshaMstUpdate
            (
                GyoshaMstDataSet.GyoshaMstDataTable table,
                string username,
                string hostname
            )
        {
            // 業者コード(7)
            table[0].GyoshaCd = gyoshaCdTextBox.Text;
            // 業者名称(8)
            table[0].GyoshaNm = gyoshaNmTextBox.Text;
            // 業者カナ名(9)
            table[0].GyoshaKana = gyoshaKanaTextBox.Text;
            // 業者郵便番号(10)
            table[0].GyoshaZipCd = gyoshaZipCdTextBox.Text;
            // 業者住所(11)
            table[0].GyoshaAdr = gyoshaAdrTextBox.Text;
            // 業者電話番号(12)
            table[0].GyoshaTelNo = gyoshaTelNoTextBox.Text;
            // 業者Fax番号(13)
            table[0].GyoshaFaxNo = gyoshaFaxNoTextBox.Text;
            // 代表者氏名(14)
            table[0].DaihyoshaNm = daihyoshaNmTextBox.Text;
            // 工事業者区分(16)
            table[0].KojiGyoshaKbn = kojiGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 保守業者区分(17)
            table[0].HoshuGyoshaKbn = hoshuGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 取扱業者区分(18)
            //table[0].ToriatsukaiGyoshaKbn = toriatsukaiGyoshaKbnCheckBox.Checked ? "1" : "0";
            // v1.08
            table[0].ToriatsukaiGyoshaKbn = Convert.ToString(toriatsukaiGyoshaKbnComboBox.SelectedValue);
            // 清掃業者区分(19)
            table[0].SeisoGyoshaKbn = seisoGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 製造業者区分(20)
            table[0].SeizoGyoShaKbn = seizoGyoShaKbnCheckBox.Checked ? "1" : "0";
            // その他業者区分(21)
            table[0].SonotaGyoshaKbn = sonotaGyoshaKbnCheckBox.Checked ? "1" : "0";
            // 工事登録番号(22)
            table[0].KoujiTorokuNo = koujiTorokuNoTextBox.Text;
            // 県保守業者登録番号(23)
            table[0].KenHoshuGyoShaTorokuNo = kenHoshuGyoShaTorokuNoTextBox.Text;
            // 取扱業者コード(24)
            table[0].ToriatsukaiGyoshaCd = toriatsukaiGyoshaCdTextBox.Text;
            // メーカー名称(25)
            table[0].MakerNm = makerNmTextBox.Text;
            // 還付有無フラグ(27)
            table[0].KanpuUmuFlg = kanpuUmuFlgCheckBox.Checked ? "1" : "0";
            // 還付金集計先コード(28)
            table[0].KanpukinShukeisakiCd = kanpukinShukeisakiCdTextBox.Text;
            // 協同組合コード(29)
            table[0].KyodoKumiaiCd = kyodoKumiaiCdTextBox.Text;
            // 賛助会費(30)
            table[0].Sanjokaihi = !string.IsNullOrEmpty(sanjokaihiTextBox.Text.Trim()) ? Convert.ToDecimal(sanjokaihiTextBox.Text) : 0;
            // 送付先担当者氏名(31)
            table[0].SofusakiTantoshaNm = sofusakiTantoshaNmTextBox.Text;
            // データ渡フラグ(32)
            table[0].DataWatashiFlg = dataWatashiFlgCheckBox.Checked ? "1" : "0";
            // 基本データフラグ(34)
            table[0].KihonDataFlg = kihonDataFlgCheckBox.Checked ? "1" : "0";
            // 水質データフラグ(35)
            table[0].SuishitsuDataFlg = suishitsuDataFlgCheckBox.Checked ? "1" : "0";
            // 所見データフラグ(36)
            table[0].ShokenDataFlg = shokenDataFlgCheckBox.Checked ? "1" : "0";
            // 外観データフラグ(37)
            table[0].GaikanDataFlg = gaikanDataFlgCheckBox.Checked ? "1" : "0";
            // 書類検査データフラグ(38)
            table[0].ShoruiDataFlg = shoruiDataFlgCheckBox.Checked ? "1" : "0";
            // 5条データフラグ(39)
            table[0]._5JoDataFlg = jo5DataFlgCheckBox.Checked ? "1" : "0";
            // 7条データフラグ(40)
            table[0]._7JoDataFlg = jo7DataFlgCheckBox.Checked ? "1" : "0";
            // 11条水質データフラグ(41)
            table[0]._11JoSuishitsuDataFlg = jo11SuishitsuDataFlgCheckBox.Checked ? "1" : "0";
            // 11条外観データフラグ(42)
            table[0]._11JoGaikanDataFlg = jo11GaikanDataFlgCheckBox.Checked ? "1" : "0";
            // 基本情報タブ.支払区分(43)
            table[0].ShiharaiKbn = (shiharaiKbnComboBox.SelectedValue != null) ? shiharaiKbnComboBox.SelectedValue.ToString() : string.Empty;
            
            // ADD START 20140718 ZynasSou
            // 金融機関コード
            table[0].BankCd = bankCdTextBox.Text;
            // ADD END 20140718 ZynasSou
            
            // 銀行名称(45)
            table[0].BankNm = bankNmTextBox.Text;

            // ADD START 20140718 ZynasSou
            // 支店コード
            table[0].BankShitenCd = bankShitenCdTextBox.Text;
            // ADD END 20140718 ZynasSou

            // 銀行支店名称(46)
            table[0].BankShitenNm = bankShitenNmTextBox.Text;
            // 銀行口座種別名(47)
            table[0].BankKozaShubetsuNm = bankKozaShubetsuNmTextBox.Text;
            // 銀行口座番号(48)
            table[0].BankKozaNo = bankKozaNoTextBox.Text;
            // 銀行口座名義(49)
            table[0].BankKozaMeigi = bankKozaMeigiTextBox.Text;

            // DEL START 20140718 ZynasSou
            // 会員区分(51)
            table[0].KaiinKbn = kaiinKbnCheckBox.Checked ? "1" : "0";
            // 廃業フラグ(52)
            table[0].HaigyoFlg = !string.IsNullOrEmpty(bukaiHaigyoDtTextBox.Text) ? "1" : "0";
            //
            //// 請求分離フラグ(53)
            //table[0].SeikyuBunriFlg = seikyuBunriFlgCheckBox.Checked ? "1" : "0";
            //
            //// 7条検査依頼一覧発行フラグ(54)
            //table[0]._7JoKensaIraiIchiranHakkoFlg = jo7KensaIraiIchiranHakkoFlgCheckBox.Checked ? "1" : "0";
            // DEL END 20140718 ZynasSou

            // ADD 20140724 START ZynasSou
            // 廃業日
            table[0].HaigyoDt = bukaiHaigyoDtTextBox.Text;
            // ADD 20140724 END ZynasSou

            // ADD 20140724 START ZynasSou
            // 廃業理由
            table[0].HaigyoRiyu = bukaiHaigyoRiyuTextBox.Text;
            // ADD 20140724 END ZynasSou

            // 全営業区域フラグ(67)
            table[0].ZenEigyoKuikiFlg = zenEigyoKuikiFlgCheckBox.Checked ? "1" : "0";

            // 2014/11/04 AnhNV Add start
            // 福岡市登録番号(112)
            table[0].FukuokashiGyoShaTorokuNo = fukuokashiGyoShaTorokuNoTextBox.Text;
            // 久留米市登録番号(113)
            table[0].KurumeshiGyoShaTorokuNo = kurumeshiGyoShaTorokuNoTextBox.Text;
            // 発送担当者(114)
            table[0].HassoTantosha = hassoTantoshaTextBox.Text;
            // 一括請求先コード(115)
            table[0].IkkatsuSeikyuSakiCd = ikkatsuSeikyuSakiCdTextBox.Text;
            // 2014/11/04 AnhNV Add end

            // 更新者
            table[0].UpdateUser = username;

            // 更新端末
            table[0].UpdateTarm = hostname;

            return table;
        }
        #endregion

        #region CreateGyoshaEigyoshoMstDefaultForInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGyoshaEigyoshoMstDefaultForInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstDataTable CreateGyoshaEigyoshoMstDefaultForInsert
            (
                DateTime now,
                string username,
                string hostname
            )
        {
            // UPD 20140728 START ZynasSou
            //// Create a new row
            //GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstRow newRow = _gyoshaEigyoshoMst.NewGyoshaEigyoshoMstRow();

            //// 業者コード
            //newRow.GyoshaEigyoshoGyoshaCd = gyoshaCdTextBox.Text;

            //// 連番
            //newRow.GyoshaEigyoshoRenban = " ";

            //// 業者営業所名称
            //newRow.GyoshaEigyoshoNm = " ";

            //// 業者営業所郵便番号
            //newRow.GyoshaEigyoshoZipCd = " ";

            //// 業者営業所住所
            //newRow.GyoshaEigyoshoAdr = " ";

            //// 業者営業所電話番号
            //newRow.GyoshaEigyoshoTelNo = " ";

            //// 業者営業所ファックス
            //newRow.GyoshaEigyoshoFaxNo = " ";

            //// 業者営業所保健所1
            //newRow.GyoshaEigyoshoHokenjo1 = " ";

            //// 業者営業所保健所2
            //newRow.GyoshaEigyoshoHokenjo2 = " ";

            //// 業者営業所保健所3
            //newRow.GyoshaEigyoshoHokenjo3 = " ";

            //// 業者営業所保健所4
            //newRow.GyoshaEigyoshoHokenjo4 = " ";

            //// 業者営業所保健所5
            //newRow.GyoshaEigyoshoHokenjo5 = " ";

            //// 登録日時
            //newRow.InsertDt = now;

            //// 登録者
            //newRow.InsertUser = username;

            //// 登録端末
            //newRow.InsertTarm = hostname;

            //// 更新日時
            //newRow.UpdateDt = now;

            //// 更新者
            //newRow.UpdateUser = username;

            //// 更新端末
            //newRow.UpdateTarm = hostname;

            //// 行を挿入
            //_gyoshaEigyoshoMst.AddGyoshaEigyoshoMstRow(newRow);

            //// 行の状態を設定
            //newRow.AcceptChanges();

            //// 行の状態を設定（新規）
            //newRow.SetAdded();

            foreach (GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstRow newRow in _gyoshaEigyoshoMst)
            {
                if (newRow.RowState == DataRowState.Added)
                {
                    // 業者コード
                    newRow.GyoshaEigyoshoGyoshaCd = gyoshaCdTextBox.Text;

                    // 連番
                    // UPD 20140804 START ZynasSou
                    //newRow.GyoshaEigyoshoRenban = Common.Common.GetKeyRenban("GyoshaEigyoshoMst", gyoshaCdTextBox.Text, "", "");
                    newRow.GyoshaEigyoshoRenban = newRow.GyoshaEigyoshoRenban;
                    // UPD 20140804 END ZynasSou

                    // 登録日時
                    newRow.InsertDt = now;
                    // 登録者
                    newRow.InsertUser = username;
                    // 登録端末
                    newRow.InsertTarm = hostname;
                    // 更新日時
                    newRow.UpdateDt = now;
                    // 更新者
                    newRow.UpdateUser = username;
                    // 更新端末
                    newRow.UpdateTarm = hostname;

                    // 行の状態を設定
                    newRow.AcceptChanges();
                    // 行の状態を設定（新規）
                    newRow.SetAdded();
                }
                else if (newRow.RowState == DataRowState.Modified)
                {
                    // 更新日時
                    newRow.UpdateDt = now;
                    // 更新者
                    newRow.UpdateUser = username;
                    // 更新端末
                    newRow.UpdateTarm = hostname;
                }
            }
            // UPD 20140728 END ZynasSou

            return _gyoshaEigyoshoMst;
        }
        #endregion

        #region CreateGyoshaEigyoChikuMstDefaultForInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGyoshaEigyoChikuMstDefaultForInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable CreateGyoshaEigyoChikuMstDefaultForInsert
            (
                DateTime now,
                string username,
                string hostname
            )
        {
            // UPD 20140728 START ZynasSou
            //// Create a new row
            //GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstRow newRow = _gyoshaEigyoChikuMst.NewGyoshaEigyoChikuMstRow();

            //// 業者コード
            //newRow.GyoshaEigyoChikuGyoshaCd = gyoshaCdTextBox.Text;

            //// 連番
            //newRow.GyoshaEigyoChikuRenban = " ";

            //// 業者営業地区コード
            //newRow.GyoshaEigyoChikuCd = " ";

            //// 登録日時
            //newRow.InsertDt = now;

            //// 登録者
            //newRow.InsertUser = username;

            //// 登録端末
            //newRow.InsertTarm = hostname;

            //// 更新日時
            //newRow.UpdateDt = now;

            //// 更新者
            //newRow.UpdateUser = username;

            //// 更新端末
            //newRow.UpdateTarm = hostname;

            //// 行を挿入
            //_gyoshaEigyoChikuMst.AddGyoshaEigyoChikuMstRow(newRow);

            //// 行の状態を設定
            //newRow.AcceptChanges();

            //// 行の状態を設定（新規）
            //newRow.SetAdded();

            foreach (GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstRow newRow in _gyoshaEigyoChikuMst)
            {
                if (newRow.RowState == DataRowState.Added)
                {
                    // 業者コード
                    newRow.GyoshaEigyoChikuGyoshaCd = gyoshaCdTextBox.Text;

                    // DEL 20140804 START ZynasSou
                    //// 連番
                    //newRow.GyoshaEigyoChikuRenban = Common.Common.GetKeyRenban("GyoshaEigyoChikuMst", gyoshaCdTextBox.Text, "", "");
                    // DEL 20140804 END ZynasSou

                    // 登録日時
                    newRow.InsertDt = now;
                    // 登録者
                    newRow.InsertUser = username;
                    // 登録端末
                    newRow.InsertTarm = hostname;
                    // 更新日時
                    newRow.UpdateDt = now;
                    // 更新者
                    newRow.UpdateUser = username;
                    // 更新端末
                    newRow.UpdateTarm = hostname;

                    // 行の状態を設定
                    newRow.AcceptChanges();
                    // 行の状態を設定（新規）
                    newRow.SetAdded();
                }
                else if (newRow.RowState == DataRowState.Modified)
                {
                    // 更新日時
                    newRow.UpdateDt = now;
                    // 更新者
                    newRow.UpdateUser = username;
                    // 更新端末
                    newRow.UpdateTarm = hostname;
                }
            }
            // UPD 20140728 START ZynasSou

            return _gyoshaEigyoChikuMst;
        }
        #endregion

        #region CreateGyoshaBukaiMstDefaultForInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGyoshaBukaiMstDefaultForInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15  AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable CreateGyoshaBukaiMstDefaultForInsert
        //    (
        //        DateTime now,
        //        string username,
        //        string hostname
        //    )
        //{
        //    foreach (GyoshaBukaiMstDataSet.GyoshaBukaiMstRow newRow in _gyoshaBukaiMst)
        //    {
        //        if (newRow.RowState == DataRowState.Added)
        //        {
        //            // 業者コード
        //            newRow.BukaiGyoshaCd = gyoshaCdTextBox.Text;

        //            // 登録日時
        //            newRow.InsertDt = now;

        //            // 登録者
        //            newRow.InsertUser = username;

        //            // 登録端末
        //            newRow.InsertTarm = hostname;

        //            // 更新日時
        //            newRow.UpdateDt = now;

        //            // 更新者
        //            newRow.UpdateUser = username;

        //            // 更新端末
        //            newRow.UpdateTarm = hostname;

        //            // 行の状態を設定
        //            newRow.AcceptChanges();

        //            // 行の状態を設定（新規）
        //            newRow.SetAdded();
        //        }
        //        else
        //        {
        //            // 更新日時
        //            newRow.UpdateDt = now;

        //            // 更新者
        //            newRow.UpdateUser = username;

        //            // 更新端末
        //            newRow.UpdateTarm = hostname;
        //        }
        //    }
        //    // UPD 20140728 END ZynasSou

        //    return _gyoshaBukaiMst;
        //}
        #endregion

        #region CreateGyoshaBukaiMstDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGyoshaBukaiMstDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable CreateGyoshaBukaiMstDataTableInsert(DateTime now, string user, string host)
        {
            GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable table = new GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable();

            for (int bukaiKbn = 1; bukaiKbn <= 4; bukaiKbn++)
            {
                // New row
                GyoshaBukaiMstDataSet.GyoshaBukaiMstRow newRow = table.NewGyoshaBukaiMstRow();

                // 業者コード
                newRow.BukaiGyoshaCd = gyoshaCdTextBox.Text;
                // 部会区分
                newRow.BukaiKbn = bukaiKbn.ToString();
                // 会員コード
                newRow.BukaiKaiinCd = string.Empty;
                // 入会日
                newRow.BukaiNyukaiDt = string.Empty;
                // 退会日
                newRow.BukaiTaikaiDt = string.Empty;
                // 設備士代表者氏名（管理管士）
                newRow.BukaiSetsubishiDaihyoshaNm = string.Empty;
                // 免状番号
                newRow.BukaiMenJoNo = string.Empty;
                // 関係保健所１
                newRow.BukaiKankeiHokenjo1 = string.Empty;
                // 関係保健所２
                newRow.BukaiKankeiHokenjo2 = string.Empty;
                // 関係保健所３
                newRow.BukaiKankeiHokenjo3 = string.Empty;
                // 関係保健所４
                newRow.BukaiKankeiHokenjo4 = string.Empty;
                // 関係保健所５
                newRow.BukaiKankeiHokenjo5 = string.Empty;
                // 関係保健所６
                newRow.BukaiKankeiHokenjo6 = string.Empty;
                // 関係保健所７
                newRow.BukaiKankeiHokenjo7 = string.Empty;
                // 関係保健所８
                newRow.BukaiKankeiHokenjo8 = string.Empty;
                // 関係保健所９
                newRow.BukaiKankeiHokenjo9 = string.Empty;
                // 関係保健所１０
                newRow.BukaiKankeiHokenjo10 = string.Empty;
                // 関係保健所１１
                newRow.BukaiKankeiHokenjo11 = string.Empty;
                // 関係保健所１２
                newRow.BukaiKankeiHokenjo12 = string.Empty;
                // 関係保健所１３
                newRow.BukaiKankeiHokenjo13 = string.Empty;
                // 関係保健所１４
                newRow.BukaiKankeiHokenjo14 = string.Empty;
                // 関係保健所１５
                newRow.BukaiKankeiHokenjo15 = string.Empty;
                // 担当市町村１
                newRow.BukaiTantoShichoson1 = string.Empty;
                // 担当市町村２
                newRow.BukaiTantoShichoson2 = string.Empty;
                // 担当市町村３
                newRow.BukaiTantoShichoson3 = string.Empty;
                // 担当市町村４
                newRow.BukaiTantoShichoson4 = string.Empty;
                // 担当市町村５
                newRow.BukaiTantoShichoson5 = string.Empty;
                // 担当市町村６
                newRow.BukaiTantoShichoson6 = string.Empty;
                // 担当市町村７
                newRow.BukaiTantoShichoson7 = string.Empty;
                // 担当市町村８
                newRow.BukaiTantoShichoson8 = string.Empty;
                // 担当市町村９
                newRow.BukaiTantoShichoson9 = string.Empty;
                // 担当市町村１０
                newRow.BukaiTantoShichoson10 = string.Empty;
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

                table.AddGyoshaBukaiMstRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();
            }

            return table;
        }
        #endregion

        #region dgvMaxRowsCheck
        // ADD 20140804 START ZynasSou
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DataGridViewの最大行判定
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="maxRows"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/04　宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void dgvMaxRowsCheck(DataGridView dgv, int maxRows)
        {
            // 最大行数判定
            if (dgv.Rows.Count > maxRows)
            {
                dgv.AllowUserToAddRows = false;
            }
            else
            {
                dgv.AllowUserToAddRows = true;
            }
        }
        // ADD 20140804 END ZynasSou
        #endregion

        #endregion
    }
    #endregion
}
