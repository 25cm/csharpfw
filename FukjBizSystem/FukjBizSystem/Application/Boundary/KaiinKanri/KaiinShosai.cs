using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KaiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaiinShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaiinShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
        }
        #endregion

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// 端末
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// insert Date
        /// </summary>
        private DateTime insertDate;

        /// <summary>
        /// insert user
        /// </summary>
        private string insertUser = string.Empty;

        /// <summary>
        /// insert tarm
        /// </summary>
        private string insertTarm = string.Empty;

        /// <summary>
        /// 業者コード
        /// </summary>
        private string _gyoshaCd = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Edited data in DGV
        /// </summary>
        private bool editFlg = false;

        /// <summary>
        /// Loaded form
        /// </summary>
        private bool isLoad = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KaiinShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KaiinShosaiForm(string gyoshaCd)
        {
            InitializeComponent();

            this._gyoshaCd = gyoshaCd;

            this.gyoshaBukaiListDataGridView.Rows.Add("製造部会");
            this.gyoshaBukaiListDataGridView.Rows.Add("工事部会");
            this.gyoshaBukaiListDataGridView.Rows.Add("保守部会");
            this.gyoshaBukaiListDataGridView.Rows.Add("清掃部会");
        }
        #endregion

        #region イベント

        #region KaiinShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaiinShosaiForm_Load
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
        private void KaiinShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _dispMode = DispMode.Detail;

                DoFormLoad();

                isLoad = true;
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

                if (_dispMode == DispMode.Detail)
                {
                    _dispMode = DispMode.Edit;
                }
                else
                {
                    if (!UnitCheck()) { return; }

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
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： DeleteButton_Click
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/07/21  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？")
        //            == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
        //            alInput.GyoshaCd = _gyoshaCd;
        //            IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

        //            if (alOutput.Result)
        //            {
        //                KaiinListForm form = new KaiinListForm();
        //                Program.mForm.ShowForm(form);
        //            }
        //            else
        //            {
        //                MessageForm.Show2(MessageForm.DispModeType.Error,
        //                    string.Format("該当するデータは登録されていません。[業者コード：{0}]", new string[] { _gyoshaCd }));
        //            }
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

                if (_dispMode == DispMode.Confirm)
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

                //DoUpdate();
                // 20141121 AnhNV ADD Start
                gyoshaBukaiListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                // Current system date
                DateTime now = Common.Common.GetCurrentTimestamp();
                IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();
                alInput.SystemDt = now;
                alInput.GyoshaCd = gyoshaCdTextBox.Text;
                alInput.GyoshaBukaiDgv = gyoshaBukaiListDataGridView;
                new DecisionBtnClickApplicationLogic().Execute(alInput);

                //KaiinListForm frm = new KaiinListForm();
                //Program.mForm.ShowForm(frm);
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
                    if (editFlg)
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                                != System.Windows.Forms.DialogResult.Yes)
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

        #region KaiinShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaiinShosaiForm_KeyDown
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
        private void KaiinShosaiForm_KeyDown(object sender, KeyEventArgs e)
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

                    //case Keys.F3:
                    //    deleteButton.PerformClick();
                    //    break;

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

        #region gyoshaBukaiListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaBukaiListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaBukaiListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                e.Control.KeyPress += new KeyPressEventHandler(ControlKeyPress);
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

        #region gyoshaBukaiListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaBukaiListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/31  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaBukaiListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (isLoad)
                {
                    editFlg = true;

                    string colName = gyoshaBukaiListDataGridView.Columns[e.ColumnIndex].Name;

                    if (colName == "bukaiSetsubishiDaihyoshaNmCol")
                    {
                        // don't handled
                    }
                    else
                    {
                        decimal num;

                        if (gyoshaBukaiListDataGridView.CurrentRow.Cells[e.ColumnIndex].Value != null)
                        {
                            if (!string.IsNullOrEmpty(gyoshaBukaiListDataGridView.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Trim()))
                            {
                                if (!decimal.TryParse(gyoshaBukaiListDataGridView.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Trim(), out num))
                                {
                                    gyoshaBukaiListDataGridView.CurrentRow.Cells[e.ColumnIndex].Value = null;
                                }
                            }
                        }
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            Common.Common.SetGyoshaNmByCd(_gyoshaCd, gyoshaCdTextBox, gyoshaNmTextBox);

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.GyoshaCd = _gyoshaCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            if (alOutput.GyoshaMstDataTable != null && alOutput.GyoshaMstDataTable.Count > 0
                && alOutput.GyoshaBukaiMstDataTable != null && alOutput.GyoshaBukaiMstDataTable.Count > 0)
            {
                SetValues(alOutput.GyoshaBukaiMstDataTable);
            }                     

            SetControlModeView();
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
        /// 2014/07/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Edit:

                    foreach (DataGridViewColumn col in gyoshaBukaiListDataGridView.Columns)
                    {
                        if (col.DisplayIndex == 0)
                        {
                            col.ReadOnly = true;
                        }
                        else
                        {
                            col.ReadOnly = false;
                        }
                    }
                    
                    // 登録ボタン 
                    entryButton.Visible = true;

                    // 削除ボタン
                    //deleteButton.Visible = false;

                    // 再入力ボタン
                    reInputButton.Visible = false;

                    // 確定ボタン　
                    decisionButton.Visible = false;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    this.Text = "会員登録変更";
                    Program.mForm.Text = "会員登録変更";

                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    foreach (DataGridViewColumn col in gyoshaBukaiListDataGridView.Columns)
                    {
                        col.ReadOnly = true;
                    }

                    // 登録ボタン 
                    entryButton.Visible = true;

                    // 削除ボタン 
                    //deleteButton.Visible = true;

                    // 再入力ボタン 
                    reInputButton.Visible = false;

                    // 確定ボタン　
                    decisionButton.Visible = false;

                    // 閉じるボタン 
                    closeButton.Visible = true;

                    this.Text = "会員登録詳細";
                    Program.mForm.Text = "会員登録詳細";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    foreach (DataGridViewColumn col in gyoshaBukaiListDataGridView.Columns)
                    {
                        col.ReadOnly = true;
                    }

                    // 登録ボタン
                    entryButton.Visible = false;
                    
                    // 削除ボタン 
                    //deleteButton.Visible = false;

                    // 再入力ボタン
                    reInputButton.Visible = true;

                    // 確定ボタン
                    decisionButton.Visible = true;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    this.Text = "会員入力確認";
                    Program.mForm.Text = "会員入力確認";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                default:
                    break;
            }
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
        /// 2014/07/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable gyoshaBukaiMstDT)
        {
            #region SetDefaultValues
            foreach (DataGridViewRow dgvRow in gyoshaBukaiListDataGridView.Rows)
            {
                dgvRow.Cells["BukaiKaiinCdCol"].Value = string.Empty;
                dgvRow.Cells["bukaiNyukaiDtCol"].Value = string.Empty;
                dgvRow.Cells["bukaiTaikaiDtCol"].Value = string.Empty;
                dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value = string.Empty;
                dgvRow.Cells["bukaiMenJoNoCol"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value = string.Empty;
                dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value = string.Empty;
                dgvRow.Cells["bukaiTantoShichoson1Col"].Value = string.Empty;
                dgvRow.Cells["bukaiTantoShichoson2Col"].Value = string.Empty;
                dgvRow.Cells["bukaiTantoShichoson3Col"].Value = string.Empty;
                dgvRow.Cells["bukaiTantoShichoson4Col"].Value = string.Empty;
                dgvRow.Cells["bukaiTantoShichoson5Col"].Value = string.Empty;
                dgvRow.Cells["BukaiTantoShichoson6Col"].Value = string.Empty;
                dgvRow.Cells["BukaiTantoShichoson7Col"].Value = string.Empty;
                dgvRow.Cells["BukaiTantoShichoson8Col"].Value = string.Empty;
                dgvRow.Cells["bukaiTantoShichoson9Col"].Value = string.Empty;
                dgvRow.Cells["bukaiTantoShichoson10Col"].Value = string.Empty;
            }
            #endregion

            foreach (GyoshaBukaiMstDataSet.GyoshaBukaiMstRow row in gyoshaBukaiMstDT)
            {
                DataGridViewRow dgvRow = gyoshaBukaiListDataGridView.Rows[Convert.ToInt32(row.BukaiKbn) - 1];

                // 20142111 AnhNV ADD Start
                //dgvRow.Cells[BukaiKbnCol.Name].Value = row.BukaiKbn;
                // 20142111 AnhNV ADD End

                // 業者コード
                dgvRow.Cells["bukaiGyoshaCdCol"].Value = row.BukaiKaiinCd.Trim();

                // 会員コード 7
                dgvRow.Cells["BukaiKaiinCdCol"].Value = row.BukaiKaiinCd.Trim();
                
                // 入会日 8
                dgvRow.Cells["bukaiNyukaiDtCol"].Value = row.BukaiNyukaiDt.Trim();

                // 退会日 9
                dgvRow.Cells["bukaiTaikaiDtCol"].Value = row.BukaiTaikaiDt.Trim();

                // 設備士代表者氏名（管理管士）10
                dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value = row.BukaiSetsubishiDaihyoshaNm.Trim();

                // 免状番号 11
                dgvRow.Cells["bukaiMenJoNoCol"].Value = row.BukaiMenJoNo.Trim();

                #region BukaiKankeiHokenjo
                // 関係保係健所１  12
                dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value = row.BukaiKankeiHokenjo1.Trim();

                // 関係保係健所２  13
                dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value = row.BukaiKankeiHokenjo2.Trim();

                // 関係保係健所３  14
                dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value = row.BukaiKankeiHokenjo3.Trim();

                // 関係保係健所4  15
                dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value = row.BukaiKankeiHokenjo4.Trim();

                // 関係保係健所5  16
                dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value = row.BukaiKankeiHokenjo5.Trim();

                // 関係保係健所6  17
                dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value = row.BukaiKankeiHokenjo6.Trim();

                // 関係保係健所7  18
                dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value = row.BukaiKankeiHokenjo7.Trim();

                // 関係保係健所8  19
                dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value = row.BukaiKankeiHokenjo8.Trim();

                // 関係保係健所9  20
                dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value = row.BukaiKankeiHokenjo9.Trim();

                // 関係保係健所10  21
                dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value = row.BukaiKankeiHokenjo10.Trim();

                // 関係保係健所11  22
                dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value = row.BukaiKankeiHokenjo11;

                // 関係保係健所12  23
                dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value = row.BukaiKankeiHokenjo12;

                // 関係保係健所13  24
                dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value = row.BukaiKankeiHokenjo13;

                // 関係保係健所14  25
                dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value = row.BukaiKankeiHokenjo14;

                // 関係保係健所15  26
                dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value = row.BukaiKankeiHokenjo15;
                #endregion

                #region BukaiTantoShichoson
                // 担当市当町村１  27
                dgvRow.Cells["bukaiTantoShichoson1Col"].Value = row.BukaiTantoShichoson1.Trim();

                // 担当市当町村2  28
                dgvRow.Cells["bukaiTantoShichoson2Col"].Value = row.BukaiTantoShichoson2.Trim();

                // 担当市当町村3  29
                dgvRow.Cells["bukaiTantoShichoson3Col"].Value = row.BukaiTantoShichoson3.Trim();

                // 担当市当町村4  30
                dgvRow.Cells["bukaiTantoShichoson4Col"].Value = row.BukaiTantoShichoson4.Trim();

                // 担当市当町村5  31
                dgvRow.Cells["bukaiTantoShichoson5Col"].Value = row.BukaiTantoShichoson5.Trim();

                // 担当市当町村6  32
                dgvRow.Cells["BukaiTantoShichoson6Col"].Value = row.BukaiTantoShichoson6.Trim();

                // 担当市当町村7  33
                dgvRow.Cells["BukaiTantoShichoson7Col"].Value = row.BukaiTantoShichoson7.Trim();

                // 担当市当町村8  34
                dgvRow.Cells["BukaiTantoShichoson8Col"].Value = row.BukaiTantoShichoson8.Trim();

                // 担当市当町村9  35
                dgvRow.Cells["bukaiTantoShichoson9Col"].Value = row.BukaiTantoShichoson9.Trim();

                // 担当市当町村10  36
                dgvRow.Cells["bukaiTantoShichoson10Col"].Value = row.BukaiTantoShichoson10.Trim();
                #endregion

                // 登録日時
                dgvRow.Cells["InsertDtCol"].Value = row.InsertDt;

                // 登録者
                dgvRow.Cells["InsertUserCol"].Value = row.InsertUser;

                // 登録端末
                dgvRow.Cells["InsertTarmCol"].Value = row.InsertTarm;

                // 更新日時
                dgvRow.Cells["UpdateDtCol"].Value = row.UpdateDt;

                // 更新者
                dgvRow.Cells["UpdateUserCol"].Value = row.UpdateUser;

                // 更新端末
                dgvRow.Cells["UpdateTarmCol"].Value = row.UpdateTarm;

                insertDate = row.InsertDt;
                insertUser = row.InsertUser;
                insertTarm = row.InsertTarm;
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
        /// 2014/07/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable dataTable = new GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable();
            
            foreach (DataGridViewRow dgvRow in gyoshaBukaiListDataGridView.Rows)
            {
                if (
                    //(dgvRow.Cells["BukaiKaiinCdCol"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["BukaiKaiinCdCol"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiNyukaiDtCol"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiNyukaiDtCol"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTaikaiDtCol"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTaikaiDtCol"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiMenJoNoCol"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiMenJoNoCol"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTantoShichoson1Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson1Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTantoShichoson2Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson2Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTantoShichoson3Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson3Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTantoShichoson4Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson4Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTantoShichoson5Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson5Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["BukaiTantoShichoson6Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson6Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["BukaiTantoShichoson7Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson7Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["BukaiTantoShichoson8Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson8Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTantoShichoson9Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson9Col"].Value.ToString().Trim()))
                    //&& (dgvRow.Cells["bukaiTantoShichoson10Col"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson10Col"].Value.ToString().Trim()))
                    dgvRow.Cells["bukaiGyoshaCdCol"].Value == null
                    )
                {
                    // don't add to table
                }
                else
                {
                    GyoshaBukaiMstDataSet.GyoshaBukaiMstRow row = dataTable.NewGyoshaBukaiMstRow();

                    // 業者コード
                    row.BukaiGyoshaCd = gyoshaCdTextBox.Text;

                    // 連番
                    if (dgvRow.Cells["BukaiCol"].Value.ToString() == "製造部会")
                    {
                        row.BukaiKbn = "1";
                    }
                    else if (dgvRow.Cells["BukaiCol"].Value.ToString() == "工事部会")
                    {
                        row.BukaiKbn = "2";
                    }
                    else if (dgvRow.Cells["BukaiCol"].Value.ToString() == "保守部会")
                    {
                        row.BukaiKbn = "3";
                    }
                    else if (dgvRow.Cells["BukaiCol"].Value.ToString() == "清掃部会")
                    {
                        row.BukaiKbn = "4";
                    }

                    // 会員コード 7
                    row.BukaiKaiinCd = dgvRow.Cells["BukaiKaiinCdCol"].Value == null ? string.Empty : dgvRow.Cells["BukaiKaiinCdCol"].Value.ToString().Trim();

                    // 入会日 8
                    row.BukaiNyukaiDt = dgvRow.Cells["bukaiNyukaiDtCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiNyukaiDtCol"].Value.ToString().Trim();

                    // 退会日 9
                    row.BukaiTaikaiDt = dgvRow.Cells["bukaiTaikaiDtCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiTaikaiDtCol"].Value.ToString().Trim();

                    // 設備士代表者氏名（管理管士）10
                    row.BukaiSetsubishiDaihyoshaNm = dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value.ToString().Trim();

                    // 免状番号 11
                    row.BukaiMenJoNo = dgvRow.Cells["bukaiMenJoNoCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiMenJoNoCol"].Value.ToString().Trim();

                    #region BukaiKankeiHokenjo
                    // 関係保係健所１  12
                    row.BukaiKankeiHokenjo1 = dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value.ToString().Trim();

                    // 関係保係健所２  13
                    row.BukaiKankeiHokenjo2 = dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value.ToString().Trim();

                    // 関係保係健所３  14
                    row.BukaiKankeiHokenjo3 = dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value.ToString().Trim();

                    // 関係保係健所4  15
                    row.BukaiKankeiHokenjo4 = dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value.ToString().Trim();

                    // 関係保係健所5  16
                    row.BukaiKankeiHokenjo5 = dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value.ToString().Trim();

                    // 関係保係健所6  17
                    row.BukaiKankeiHokenjo6 = dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value.ToString().Trim();

                    // 関係保係健所7  18
                    row.BukaiKankeiHokenjo7 = dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value.ToString().Trim();

                    // 関係保係健所8  19
                    row.BukaiKankeiHokenjo8 = dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value.ToString().Trim();

                    // 関係保係健所9  20
                    row.BukaiKankeiHokenjo9 = dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value.ToString().Trim();

                    // 関係保係健所10  21
                    row.BukaiKankeiHokenjo10 = dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value.ToString().Trim();

                    // 関係保係健所11  22
                    row.BukaiKankeiHokenjo11 = dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value.ToString().Trim();

                    // 関係保係健所12  23
                    row.BukaiKankeiHokenjo12 = dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value.ToString().Trim();

                    // 関係保係健所13  24
                    row.BukaiKankeiHokenjo13 = dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value.ToString().Trim();

                    // 関係保係健所14  25
                    row.BukaiKankeiHokenjo14 = dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value.ToString().Trim();

                    // 関係保係健所15  26
                    row.BukaiKankeiHokenjo15 = dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value.ToString().Trim();
                    #endregion

                    #region BukaiTantoShichoson
                    // 担当市当町村１  27
                    row.BukaiTantoShichoson1 = dgvRow.Cells["bukaiTantoShichoson1Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson1Col"].Value.ToString().Trim();

                    // 担当市当町村2  28
                    row.BukaiTantoShichoson2 = dgvRow.Cells["bukaiTantoShichoson2Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson2Col"].Value.ToString().Trim();

                    // 担当市当町村3  29
                    row.BukaiTantoShichoson3 = dgvRow.Cells["bukaiTantoShichoson3Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson3Col"].Value.ToString().Trim();

                    // 担当市当町村4  30
                    row.BukaiTantoShichoson4 = dgvRow.Cells["bukaiTantoShichoson4Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson4Col"].Value.ToString().Trim();

                    // 担当市当町村5  31
                    row.BukaiTantoShichoson5 = dgvRow.Cells["bukaiTantoShichoson5Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson5Col"].Value.ToString().Trim();

                    // 担当市当町村6  32
                    row.BukaiTantoShichoson6 = dgvRow.Cells["BukaiTantoShichoson6Col"].Value == null ? string.Empty : dgvRow.Cells["BukaiTantoShichoson6Col"].Value.ToString().Trim();

                    // 担当市当町村7  33
                    row.BukaiTantoShichoson7 = dgvRow.Cells["BukaiTantoShichoson7Col"].Value == null ? string.Empty : dgvRow.Cells["BukaiTantoShichoson7Col"].Value.ToString().Trim();

                    // 担当市当町村8  34
                    row.BukaiTantoShichoson8 = dgvRow.Cells["BukaiTantoShichoson8Col"].Value == null ? string.Empty : dgvRow.Cells["BukaiTantoShichoson8Col"].Value.ToString().Trim();

                    // 担当市当町村9  35
                    row.BukaiTantoShichoson9 = dgvRow.Cells["bukaiTantoShichoson9Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson9Col"].Value.ToString().Trim();

                    // 担当市当町村10  36
                    row.BukaiTantoShichoson10 = dgvRow.Cells["bukaiTantoShichoson10Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson10Col"].Value.ToString().Trim();
                    #endregion
                    
                    if (!string.IsNullOrEmpty(insertUser))
                    {
                        // 登録日時
                        row.InsertDt = insertDate;

                        // 登録者
                        row.InsertUser = insertUser;

                        // 登録端末
                        row.InsertTarm = insertTarm;
                    }
                    else
                    {
                        // 登録日時
                        row.InsertDt = now;

                        // 登録者
                        row.InsertUser = loginUser;

                        // 登録端末
                        row.InsertTarm = pcUpdate;
                    }

                    // 更新日時
                    row.UpdateDt = now;

                    // 更新者
                    row.UpdateUser = loginUser;

                    // 更新端末
                    row.UpdateTarm = pcUpdate;

                    // 行を挿入
                    dataTable.AddGyoshaBukaiMstRow(row);

                    // 行の状態を設定
                    row.AcceptChanges();

                    // 行の状態を設定（新規）
                    row.SetAdded();
                }
            }

            IDecisionBtnClickALInput alInput    = new DecisionBtnClickALInput();
            alInput.GyoshaCd                    = gyoshaCdTextBox.Text;
            //alInput.GyoshaBukaiMstDataTable     = dataTable;
            IDecisionBtnClickALOutput alOutput  = new DecisionBtnClickApplicationLogic().Execute(alInput);
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
        /// 2014/07/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMess = new StringBuilder();

            #region variables check
            string rowIndexRelationCheck = string.Empty;
            string maxLengthBukaiKaiinCd        = string.Empty;
            string maxLengthBukaiNyukaiDt       = string.Empty;
            string maxLengthBukaiTaikaiDt       = string.Empty;
            string maxLengthNm                  = string.Empty;
            string maxLengthBukaiMenJoNo        = string.Empty;
            string maxLengthBukaiKankeiHokenjo1 = string.Empty;
            string maxLengthBukaiKankeiHokenjo2 = string.Empty;
            string maxLengthBukaiKankeiHokenjo3 = string.Empty;
            string maxLengthBukaiKankeiHokenjo4 = string.Empty;
            string maxLengthBukaiKankeiHokenjo5 = string.Empty;
            string maxLengthBukaiKankeiHokenjo6 = string.Empty;
            string maxLengthBukaiKankeiHokenjo7 = string.Empty;
            string maxLengthBukaiKankeiHokenjo8 = string.Empty;
            string maxLengthBukaiKankeiHokenjo9 = string.Empty;
            string maxLengthBukaiKankeiHokenjo10 = string.Empty;
            string maxLengthBukaiKankeiHokenjo11 = string.Empty;
            string maxLengthBukaiKankeiHokenjo12 = string.Empty;
            string maxLengthBukaiKankeiHokenjo13 = string.Empty;
            string maxLengthBukaiKankeiHokenjo14 = string.Empty;
            string maxLengthBukaiKankeiHokenjo15 = string.Empty;
            string maxLengthBukaiTantoShichoson1 = string.Empty;
            string maxLengthBukaiTantoShichoson2 = string.Empty;
            string maxLengthBukaiTantoShichoson3 = string.Empty;
            string maxLengthBukaiTantoShichoson4 = string.Empty;
            string maxLengthBukaiTantoShichoson5 = string.Empty;
            string maxLengthBukaiTantoShichoson6 = string.Empty;
            string maxLengthBukaiTantoShichoson7 = string.Empty;
            string maxLengthBukaiTantoShichoson8 = string.Empty;
            string maxLengthBukaiTantoShichoson9 = string.Empty;
            string maxLengthBukaiTantoShichoson10 = string.Empty;
            #endregion

            for (int i = 0; i < gyoshaBukaiListDataGridView.RowCount; i++)
            {
                DataGridViewRow dgvRow =  gyoshaBukaiListDataGridView.Rows[i];
                
                // 入会日が未入力でそれ以外の項目が入力ありの場合
                if (dgvRow.Cells["bukaiNyukaiDtCol"].Value == null 
                    || string.IsNullOrEmpty(dgvRow.Cells["bukaiNyukaiDtCol"].Value.ToString().Trim()))
                {
                    #region Relation check

                    if ((dgvRow.Cells["BukaiKaiinCdCol"].Value == null              || string.IsNullOrEmpty(dgvRow.Cells["BukaiKaiinCdCol"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTaikaiDtCol"].Value == null          || string.IsNullOrEmpty(dgvRow.Cells["bukaiTaikaiDtCol"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value == null || string.IsNullOrEmpty(dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiMenJoNoCol"].Value == null           || string.IsNullOrEmpty(dgvRow.Cells["bukaiMenJoNoCol"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value == null    || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTantoShichoson1Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson1Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTantoShichoson2Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson2Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTantoShichoson3Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson3Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTantoShichoson4Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson4Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTantoShichoson5Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson5Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["BukaiTantoShichoson6Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson6Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["BukaiTantoShichoson7Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson7Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["BukaiTantoShichoson8Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson8Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTantoShichoson9Col"].Value == null   || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson9Col"].Value.ToString().Trim()))
                        && (dgvRow.Cells["bukaiTantoShichoson10Col"].Value == null  || string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson10Col"].Value.ToString().Trim()))
                        )
                    {
                        // don't handled
                    }
                    else if((dgvRow.Cells["BukaiKaiinCdCol"].Value != null              && !string.IsNullOrEmpty(dgvRow.Cells["BukaiKaiinCdCol"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTaikaiDtCol"].Value != null              && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTaikaiDtCol"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiMenJoNoCol"].Value != null               && !string.IsNullOrEmpty(dgvRow.Cells["bukaiMenJoNoCol"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value != null        && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTantoShichoson1Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson1Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTantoShichoson2Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson2Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTantoShichoson3Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson3Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTantoShichoson4Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson4Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTantoShichoson5Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson5Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["BukaiTantoShichoson6Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson6Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["BukaiTantoShichoson7Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson7Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["BukaiTantoShichoson8Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["BukaiTantoShichoson8Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTantoShichoson9Col"].Value != null       && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson9Col"].Value.ToString().Trim()))
                        || (dgvRow.Cells["bukaiTantoShichoson10Col"].Value != null      && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson10Col"].Value.ToString().Trim()))
                        )
                    {
                        // Relation check
                        rowIndexRelationCheck += (i + 1) + ", ";
                    }

                    #endregion
                }
                else // Input Check
                {
                    #region Input Check

                    if (dgvRow.Cells["BukaiKaiinCdCol"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["BukaiKaiinCdCol"].Value.ToString().Trim()) && dgvRow.Cells["BukaiKaiinCdCol"].Value.ToString().Trim().Length != 4)
                    {
                        maxLengthBukaiKaiinCd += (i + 1) + ", ";
                    }

                    if (dgvRow.Cells["bukaiNyukaiDtCol"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiNyukaiDtCol"].Value.ToString().Trim()) && dgvRow.Cells["bukaiNyukaiDtCol"].Value.ToString().Trim().Length != 8)
                    {
                        maxLengthBukaiNyukaiDt += (i + 1) + ", ";
                    }

                    if (dgvRow.Cells["bukaiTaikaiDtCol"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTaikaiDtCol"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTaikaiDtCol"].Value.ToString().Trim().Length != 8)
                    {
                        maxLengthBukaiTaikaiDt += (i + 1) + ", ";
                    }

                    if (dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value.ToString().Trim()) && dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value.ToString().Trim().Length > 20)
                    {
                        maxLengthNm += (i + 1) + ", ";
                    }

                    if (dgvRow.Cells["bukaiMenJoNoCol"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiMenJoNoCol"].Value.ToString().Trim()) && dgvRow.Cells["bukaiMenJoNoCol"].Value.ToString().Trim().Length != 10)
                    {
                        maxLengthBukaiMenJoNo += (i + 1) + ", ";
                    }

                    #region bukaiKankeiHokenjo1Col
                    if (dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo1 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo2 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo3 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo4 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo5 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo6 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo7 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo8 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo9 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo10 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo11 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo12 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo13 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo14 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value.ToString().Trim().Length != 2)
                    {
                        maxLengthBukaiKankeiHokenjo15 += (i + 1) + ", ";
                    }
                    #endregion

                    #region bukaiTantoShichoson1Col
                    if (dgvRow.Cells["bukaiTantoShichoson1Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson1Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson1Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson1 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson2Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson2Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson2Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson2 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson3Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson3Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson3Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson3 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson4Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson4Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson4Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson4 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson5Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson5Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson5Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson5 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson6Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson6Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson6Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson6 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson7Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson7Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson7Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson7 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson8Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson8Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson8Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson8 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson9Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson9Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson9Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson9 += (i + 1) + ", ";
                    }
                    if (dgvRow.Cells["bukaiTantoShichoson10Col"].Value != null && !string.IsNullOrEmpty(dgvRow.Cells["bukaiTantoShichoson10Col"].Value.ToString().Trim()) && dgvRow.Cells["bukaiTantoShichoson10Col"].Value.ToString().Trim().Length != 5)
                    {
                        maxLengthBukaiTantoShichoson10 += (i + 1) + ", ";
                    }       
                    #endregion

                    #endregion
                }
            }

            if (!string.IsNullOrEmpty(rowIndexRelationCheck))
            {
                errMess.Append("行 : " + rowIndexRelationCheck.Remove(rowIndexRelationCheck.Length - 2) + " : 必須項目：入会日は必須です \r\n");
            }

            // 会員コード
            if (!string.IsNullOrEmpty(maxLengthBukaiKaiinCd))
            {
                errMess.Append("行 : " + maxLengthBukaiKaiinCd.Remove(maxLengthBukaiKaiinCd.Length - 2) + " : 会員コードは4桁で入力して下さい。 \r\n");
            }

            // 入会日
            if (!string.IsNullOrEmpty(maxLengthBukaiNyukaiDt))
            {
                errMess.Append("行 : " + maxLengthBukaiNyukaiDt.Remove(maxLengthBukaiNyukaiDt.Length - 2) + " : 入会日は8桁で入力して下さい。 \r\n");
            }

            // 退会日
            if (!string.IsNullOrEmpty(maxLengthBukaiTaikaiDt))
            {
                errMess.Append("行 : " + maxLengthBukaiTaikaiDt.Remove(maxLengthBukaiTaikaiDt.Length - 2) + " : 退会日は8桁で入力して下さい。 \r\n");
            }

            // 設備士代表者氏名（管理管士）
            if (!string.IsNullOrEmpty(maxLengthNm))
            {
                errMess.Append("行 : " + maxLengthNm.Remove(maxLengthNm.Length - 2) + " : 設備士代表者氏名（管理管士）は20文字以下で入力して下さい。 \r\n");
            }

            // 免状番号
            if (!string.IsNullOrEmpty(maxLengthBukaiMenJoNo))
            {
                errMess.Append("行 : " + maxLengthBukaiMenJoNo.Remove(maxLengthBukaiMenJoNo.Length - 2) + " : 免状番号は10桁で入力して下さい。 \r\n");
            }

            #region 関係保健所
            // 関係保健所１
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo1))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo1.Remove(maxLengthBukaiKankeiHokenjo1.Length - 2) + " : 関係保係健所１は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所2
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo2))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo2.Remove(maxLengthBukaiKankeiHokenjo2.Length - 2) + " : 関係保係健所２は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所3
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo3))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo3.Remove(maxLengthBukaiKankeiHokenjo3.Length - 2) + " : 関係保係健所３は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所4
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo4))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo4.Remove(maxLengthBukaiKankeiHokenjo4.Length - 2) + " : 関係保係健所４は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所5
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo5))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo5.Remove(maxLengthBukaiKankeiHokenjo5.Length - 2) + " : 関係保係健所５は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所6
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo6))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo6.Remove(maxLengthBukaiKankeiHokenjo6.Length - 2) + " : 関係保係健所６は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所7
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo7))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo7.Remove(maxLengthBukaiKankeiHokenjo7.Length - 2) + " : 関係保係健所７は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所8
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo8))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo8.Remove(maxLengthBukaiKankeiHokenjo8.Length - 2) + " : 関係保係健所８は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所9
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo9))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo9.Remove(maxLengthBukaiKankeiHokenjo9.Length - 2) + " : 関係保係健所９は2桁で入力して下さい。 \r\n");
            }
            // 関係保健所１0
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo10))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo10.Remove(maxLengthBukaiKankeiHokenjo10.Length - 2) + " : 関係保係健所１０は2桁で入力して下さい。\r\n");
            }
            // 関係保健所１1
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo11))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo11.Remove(maxLengthBukaiKankeiHokenjo11.Length - 2) + " : 関係保係健所１１は2桁で入力して下さい。\r\n");
            }
            // 関係保健所１2
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo12))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo12.Remove(maxLengthBukaiKankeiHokenjo12.Length - 2) + " : 関係保係健所１２は2桁で入力して下さい。\r\n");
            }
            // 関係保健所１3
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo13))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo13.Remove(maxLengthBukaiKankeiHokenjo13.Length - 2) + " : 関係保係健所１３は2桁で入力して下さい。\r\n");
            }
            // 関係保健所１4
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo14))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo14.Remove(maxLengthBukaiKankeiHokenjo14.Length - 2) + " : 関係保係健所１４は2桁で入力して下さい。\r\n");
            }
            // 関係保健所１5
            if (!string.IsNullOrEmpty(maxLengthBukaiKankeiHokenjo15))
            {
                errMess.Append("行 : " + maxLengthBukaiKankeiHokenjo15.Remove(maxLengthBukaiKankeiHokenjo15.Length - 2) + " : 関係保係健所１５は2桁で入力して下さい。\r\n");
            }
            #endregion

            #region 担当市町村
            // 担当市町村1
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson1))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson1.Remove(maxLengthBukaiTantoShichoson1.Length - 2) + " : 担当市当町村１は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村2
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson2))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson2.Remove(maxLengthBukaiTantoShichoson2.Length - 2) + " : 担当市当町村２は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村3
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson3))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson3.Remove(maxLengthBukaiTantoShichoson3.Length - 2) + " : 担当市当町村３は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村4
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson4))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson4.Remove(maxLengthBukaiTantoShichoson4.Length - 2) + " : 担当市当町村４は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村5
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson5))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson5.Remove(maxLengthBukaiTantoShichoson5.Length - 2) + " : 担当市当町村５は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村6
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson6))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson6.Remove(maxLengthBukaiTantoShichoson6.Length - 2) + " : 担当市当町村６は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村7
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson7))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson7.Remove(maxLengthBukaiTantoShichoson7.Length - 2) + " : 担当市当町村７は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村8
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson8))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson8.Remove(maxLengthBukaiTantoShichoson8.Length - 2) + " : 担当市当町村８は5桁で入力して下さい。\r\n");
            }
            // 担当市町村9
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson9))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson9.Remove(maxLengthBukaiTantoShichoson9.Length - 2) + " : 担当市当町村９は5桁で入力して下さい。 \r\n");
            }
            // 担当市町村10
            if (!string.IsNullOrEmpty(maxLengthBukaiTantoShichoson10))
            {
                errMess.Append("行 : " + maxLengthBukaiTantoShichoson10.Remove(maxLengthBukaiTantoShichoson10.Length - 2) + " : 担当市当町村１０は5桁で入力して下さい。 \r\n");
            }

            #endregion

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            string colName = gyoshaBukaiListDataGridView.Columns[gyoshaBukaiListDataGridView.CurrentCell.ColumnIndex].Name;

            if (colName == "bukaiSetsubishiDaihyoshaNmCol")
            {
                // don't handled
            }
            else
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
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

        #endregion

    }
    #endregion
}
