using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.YoshiMstList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiMstListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YoshiMstListForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;

        /// <summary>
        /// Edit Flag
        /// </summary>
        private bool editFlg = false;

        /// <summary>
        /// Loaded Form
        /// </summary>
        private bool isLoad = false;

        /// <summary>
        /// Login user
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// Terminal Name
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YoshiMstListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public YoshiMstListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region YoshiMstListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YoshiMstListForm_Load
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
        private void YoshiMstListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
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
        private void viewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;

                if (this._searchShowFlg) // 検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else //検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }

                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.shiireListPanel,
                    this._defaultListPanelTop,
                    this._defaultListPanelHeight);

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
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 用紙コード（開始）
                yoshiCdFromTextBox.Clear();

                // 用紙コード（終了）
                yoshiCdToTextBox.Clear();

                // 名称
                nameTextBox.Clear();
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

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
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
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckCondition()) { return; }

                DoSearch();

                editFlg = false;
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： koshinButton_Click
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
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                shiireListDataGridView.EndEdit();

                if (!editFlg) { return; }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "用紙一覧の編集内容を登録します。よろしいですか？")
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!InputCheck()) { return; }

                    DoUpdate();

                    editFlg = false;
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

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
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
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shiireListDataGridView.RowCount == 0) { return; }

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "用紙マスタ一覧";
                Common.Common.FlushGridviewDataToExcel(this.shiireListDataGridView, outputFilename);
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

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
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
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (editFlg)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                        == System.Windows.Forms.DialogResult.Yes)
                    {
                        //YoshiMenuForm frm = new YoshiMenuForm();
                        //Program.mForm.ShowForm(frm);
                        Program.mForm.MovePrev();
                    }
                }
                else
                {
                    //YoshiMenuForm frm = new YoshiMenuForm();
                    //Program.mForm.ShowForm(frm);
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

        #region YoshiMstListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YoshiMstListForm_KeyDown
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
        private void YoshiMstListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.Focus();
                        torokuButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;

                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                        tojiruButton.Focus();
                        tojiruButton.PerformClick();
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

        #region shiireListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shiireListDataGridView_EditingControlShowing
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
        private void shiireListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        #region shiireListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shiireListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shiireListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (isLoad)
                {
                    editFlg = true;

                    outputButton.Enabled = false;

                    DataGridViewColumn col = shiireListDataGridView.Columns[shiireListDataGridView.CurrentCell.ColumnIndex];

                    if (col.Name == "YoshiCdCol")
                    {
                        decimal number = -1;

                        if (!Decimal.TryParse(shiireListDataGridView.CurrentRow.Cells[col.Name].Value.ToString(), out number) || number < 0)
                        {
                            shiireListDataGridView.CurrentRow.Cells[col.Name].Value = string.Empty;
                        }
                    }
                    else
                    {
                        if (col.Name != "YoshiNmCol")
                        {
                            decimal number = -1;

                            if (!Decimal.TryParse(shiireListDataGridView.CurrentRow.Cells[col.Name].Value.ToString(), out number) || number < 0)
                            {
                                shiireListDataGridView.CurrentRow.Cells[col.Name].Value = 0;
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

        #region shiireListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shiireListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shiireListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<string> listKey = GetListDuplicate();
                ChangeBackground(listKey);
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

        #region shiireListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shiireListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shiireListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                string errMess = string.Empty;

                DataGridViewColumn col = shiireListDataGridView.Columns[shiireListDataGridView.CurrentCell.ColumnIndex];

                if (col.Name == "KaiinTankaCol")
                {
                    errMess = "会員単価は半角数字で入力して下さい。";
                }
                else if (col.Name == "HiKaiinTankaCol")
                {
                    errMess = "非会員単価は半角数字で入力して下さい。";
                }
                else if (col.Name == "KaiinSetKakakuCol")
                {
                    errMess = "会員セット価格は半角数字で入力して下さい。";
                }
                else if (col.Name == "HiKaiinSetKakakuCol")
                {
                    errMess = "非会員セット価格は半角数字で入力して下さい。";
                }
                else if (col.Name == "SetBusuCol")
                {
                    errMess = "セット部数は半角数字で入力して下さい。";
                }

                MessageForm.Show2(MessageForm.DispModeType.Error, errMess);
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

        #region yoshiCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(yoshiCdFromTextBox.Text))
                {
                    yoshiCdFromTextBox.Text = yoshiCdFromTextBox.Text.PadLeft(2, '0');

                    yoshiCdToTextBox.Text = yoshiCdFromTextBox.Text;
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

        #region yoshiCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(yoshiCdToTextBox.Text))
                {
                    yoshiCdToTextBox.Text = yoshiCdToTextBox.Text.PadLeft(2, '0');
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
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            shiireListDataGridView.DataSource = null;

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            YoshiMstUpdateDataSet.YoshiMstUpdateDataTable dataTable = CreateYoshiMstUpdateDT(alOutput.YoshiMstKensakuDT);

            shiireListDataGridView.DataSource = dataTable;
            
            if (alOutput.YoshiMstKensakuDT == null || alOutput.YoshiMstKensakuDT.Count == 0)
            {
                shiireListCountLabel.Text = "0件";

                outputButton.Enabled = false;
            }
            else
            {
                shiireListCountLabel.Text = alOutput.YoshiMstKensakuDT.Count.ToString() + "件";

                outputButton.Enabled = true;
            }

            DisplayColumns();

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.shiireListPanel.Top;
            this._defaultListPanelHeight = this.shiireListPanel.Height;
        }
        #endregion

        #region CheckCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 用紙コード（開始）
            if (!string.IsNullOrEmpty(yoshiCdFromTextBox.Text) && yoshiCdFromTextBox.Text.Length != 2)
            {
                errMess.Append("用紙コード（開始）は2桁で入力して下さい。\r\n");
            }

            // 用紙コード（終了）
            if (!string.IsNullOrEmpty(yoshiCdToTextBox.Text) && yoshiCdToTextBox.Text.Length != 2)
            {
                errMess.Append("用紙コード（終了）は2桁で入力して下さい。\r\n");
            }

            if(!string.IsNullOrEmpty(yoshiCdFromTextBox.Text) && !string.IsNullOrEmpty(yoshiCdToTextBox.Text)
                && string.IsNullOrEmpty(errMess.ToString()))
            {
                if (Convert.ToInt32(yoshiCdFromTextBox.Text) > Convert.ToInt32(yoshiCdToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。用紙コードの大小関係を確認してください。\r\n");
                }
            }

            // 名称
            if (!string.IsNullOrEmpty(nameTextBox.Text) && nameTextBox.Text.Trim().Length > 60)
            {
                errMess.Append("名称は60文字以下で入力して下さい。\r\n");
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            shiireListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            YoshiMstUpdateDataSet.YoshiMstUpdateDataTable dataTable = CreateYoshiMstUpdateDT(alOutput.YoshiMstKensakuDT);

            shiireListDataGridView.DataSource = dataTable;

            if (alOutput.YoshiMstKensakuDT == null || alOutput.YoshiMstKensakuDT.Count == 0)
            {
                shiireListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");

                outputButton.Enabled = false;
            }
            else
            {
                shiireListCountLabel.Text = alOutput.YoshiMstKensakuDT.Count.ToString() + "件";

                outputButton.Enabled = true;
            }

            DisplayColumns();
        }
        #endregion

        #region MakeSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alInput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 用紙コード（開始）
            alInput.YoshiCdFrom = yoshiCdFromTextBox.Text;

            // 用紙コード（終了）
            alInput.YoshiCdTo = yoshiCdToTextBox.Text;

            // 名称
            alInput.YoshiNm = nameTextBox.Text.Trim();
        }
        #endregion

        #region DisplayColumns
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayColumns
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayColumns()
        {
            foreach (DataGridViewColumn col in shiireListDataGridView.Columns)
            {
                if (col.Name == "YoshiCdCol"
                    || col.Name == "YoshiNmCol"
                    || col.Name == "KaiinTankaCol"
                    || col.Name == "HiKaiinTankaCol"
                    || col.Name == "KaiinSetKakakuCol"
                    || col.Name == "HiKaiinSetKakakuCol"
                    || col.Name == "SetBusuCol")
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }

            foreach (DataGridViewRow row in shiireListDataGridView.Rows)
            {
                if (row.Cells["IsUpdateCol"].Value != null && row.Cells["IsUpdateCol"].Value.ToString() == "1")
                {
                    row.Cells["YoshiCdCol"].ReadOnly = true;
                }
            }
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
        /// 2014/07/09　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            string colName = shiireListDataGridView.Columns[shiireListDataGridView.CurrentCell.ColumnIndex].Name;

            if (colName == "YoshiCdCol"
                || colName == "KaiinTankaCol"
                || colName == "HiKaiinTankaCol"
                || colName == "KaiinSetKakakuCol"
                || colName == "HiKaiinSetKakakuCol"
                || colName == "SetBusuCol"
                )
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

        #region CreateYoshiMstUpdateDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiMstUpdateDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensakuDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiMstUpdateDataSet.YoshiMstUpdateDataTable CreateYoshiMstUpdateDT(YoshiMstDataSet.YoshiMstKensakuDataTable kensakuDT)
        {
            YoshiMstUpdateDataSet.YoshiMstUpdateDataTable dataTable = new YoshiMstUpdateDataSet.YoshiMstUpdateDataTable();

            foreach (YoshiMstDataSet.YoshiMstKensakuRow row in kensakuDT)
            {
                YoshiMstUpdateDataSet.YoshiMstUpdateRow yoshiRow = dataTable.NewYoshiMstUpdateRow();

                yoshiRow.YoshiCd = row.YoshiCd;

                yoshiRow.YoshiNm = row.YoshiNm;

                yoshiRow.YoshiKaiinUp = row.YoshiKaiinUp;

                yoshiRow.YoshiHiKaiinUp = row.YoshiHiKaiinUp;

                yoshiRow.YoshiKaiinSetKakaku = row.YoshiKaiinSetKakaku;

                yoshiRow.YoshiHiKaiinSetKakaku = row.YoshiHiKaiinSetKakaku;

                yoshiRow.YoshiSetBusu = row.YoshiSetBusu;

                yoshiRow.YoshiCdOriginal = row.YoshiCd;

                yoshiRow.YoshiNmOriginal = row.YoshiNm;

                yoshiRow.YoshiKaiinUpOriginal = row.YoshiKaiinUp;

                yoshiRow.YoshiHiKaiinUpOriginal = row.YoshiHiKaiinUp;

                yoshiRow.YoshiKaiinSetKakakuOriginal = row.YoshiKaiinSetKakaku;

                yoshiRow.YoshiHiKaiinSetKakakuOriginal = row.YoshiHiKaiinSetKakaku;

                yoshiRow.YoshiSetBusuOriginal = row.YoshiSetBusu;

                yoshiRow.IsUpdate = "1";

                yoshiRow.InsertDt = row.InsertDt;

                yoshiRow.InsertTarm = row.InsertTarm;

                yoshiRow.InsertUser = row.InsertUser;

                yoshiRow.UpdateDt = row.UpdateDt;

                yoshiRow.UpdateTarm = row.UpdateTarm;

                yoshiRow.UpdateUser = row.UpdateUser;

                dataTable.AddYoshiMstUpdateRow(yoshiRow);

                yoshiRow.AcceptChanges();

                yoshiRow.SetAdded();

            }

            return dataTable;
        }
        #endregion

        #region InputCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InputCheck
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool InputCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // list key duplicate
            List<string> listKey = new List<string>();

            string emptyYoshiCd             = string.Empty;
            string emptyYoshiNm             = string.Empty;
            string emptyKaiinTanka          = string.Empty;
            string emptyHiKaiinTanka        = string.Empty;
            string emptyKaiinSetKakaku      = string.Empty;
            string maxLengthYoshiCd         = string.Empty;
            string maxLengthYoshiNm         = string.Empty;            

            for (int i = 0; i < shiireListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = shiireListDataGridView.Rows[i];

                if ((row.Cells["YoshiCdCol"].Value == null              || string.IsNullOrEmpty(row.Cells["YoshiCdCol"].Value.ToString()))
                    && (row.Cells["YoshiNmCol"].Value == null           || string.IsNullOrEmpty(row.Cells["YoshiNmCol"].Value.ToString()))
                    && (row.Cells["KaiinTankaCol"].Value == null        || string.IsNullOrEmpty(row.Cells["KaiinTankaCol"].Value.ToString()))
                    && (row.Cells["HiKaiinTankaCol"].Value == null      || string.IsNullOrEmpty(row.Cells["HiKaiinTankaCol"].Value.ToString()))
                    && (row.Cells["KaiinSetKakakuCol"].Value == null    || string.IsNullOrEmpty(row.Cells["KaiinSetKakakuCol"].Value.ToString()))
                    && (row.Cells["HiKaiinSetKakakuCol"].Value == null  || string.IsNullOrEmpty(row.Cells["HiKaiinSetKakakuCol"].Value.ToString()))
                    && (row.Cells["SetBusuCol"].Value == null           || string.IsNullOrEmpty(row.Cells["SetBusuCol"].Value.ToString())))
                {
                    // don't check
                }
                else
                {
                    if (row.Cells["YoshiCdCol"].Value == null || string.IsNullOrEmpty(row.Cells["YoshiCdCol"].Value.ToString()))
                    {
                        emptyYoshiCd += (i + 1).ToString() + ", ";
                    }
                    else
                    {
                        if (row.Cells["YoshiCdCol"].Value.ToString().Length != 2)
                        {
                            maxLengthYoshiCd += (i + 1).ToString() + ", ";
                        }
                    }

                    if (row.Cells["YoshiNmCol"].Value == null || string.IsNullOrEmpty(row.Cells["YoshiNmCol"].Value.ToString()))
                    {
                        emptyYoshiNm += (i + 1).ToString() + ", ";
                    }
                    else
                    {
                        if (row.Cells["YoshiNmCol"].Value.ToString().Trim().Length > 60)
                        {
                            maxLengthYoshiNm += (i + 1).ToString() + ", ";
                        }
                    }

                    if (row.Cells["KaiinTankaCol"].Value == null || string.IsNullOrEmpty(row.Cells["KaiinTankaCol"].Value.ToString()))
                    {
                        emptyKaiinTanka += (i + 1).ToString() + ", ";
                    }

                    if (row.Cells["HiKaiinTankaCol"].Value == null || string.IsNullOrEmpty(row.Cells["HiKaiinTankaCol"].Value.ToString()))
                    {
                        emptyHiKaiinTanka += (i + 1).ToString() + ", ";
                    }

                    if (row.Cells[KaiinSetKakakuCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[KaiinSetKakakuCol.Name].Value.ToString()))
                    {
                        row.Cells[KaiinSetKakakuCol.Name].Value = 0;
                    }

                    if (row.Cells[HiKaiinSetKakakuCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[HiKaiinSetKakakuCol.Name].Value.ToString()))
                    {
                        row.Cells[HiKaiinSetKakakuCol.Name].Value = 0;
                    }

                    if (row.Cells[SetBusuCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[SetBusuCol.Name].Value.ToString()))
                    {
                        row.Cells[SetBusuCol.Name].Value = 0;
                    }

                    if ((row.Cells[KaiinSetKakakuCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[KaiinSetKakakuCol.Name].Value.ToString()))
                        && (row.Cells[HiKaiinSetKakakuCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[HiKaiinSetKakakuCol.Name].Value.ToString()))
                        && (row.Cells[SetBusuCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[SetBusuCol.Name].Value.ToString())))
                    {
                        // don't handled
                    }
                    else if ((Convert.ToInt32(row.Cells[KaiinSetKakakuCol.Name].Value) == 0)
                        && (Convert.ToInt32(row.Cells[HiKaiinSetKakakuCol.Name].Value) == 0)
                        && (Convert.ToInt32(row.Cells[SetBusuCol.Name].Value) == 0))
                    {
                        // don't handled
                    }
                    else if ((Convert.ToInt32(row.Cells["KaiinSetKakakuCol"].Value) == 0)
                        || (Convert.ToInt32(row.Cells["HiKaiinSetKakakuCol"].Value) == 0)
                        || (Convert.ToInt32(row.Cells["SetBusuCol"].Value) == 0))
                    {
                        emptyKaiinSetKakaku += (i + 1).ToString() + ", ";
                    }
                }
            }

            // 用紙コード
            if (!string.IsNullOrEmpty(emptyYoshiCd))
            {
                errMess.Append("行 : " + emptyYoshiCd.Remove(emptyYoshiCd.Length - 2) + " : 必須項目：用紙コードが入力されていません。\r\n");
            }
            if (!string.IsNullOrEmpty(maxLengthYoshiCd))
            {
                errMess.Append("行 : " + maxLengthYoshiCd.Remove(maxLengthYoshiCd.Length - 2) + " : 用紙コードは2桁で入力して下さい。\r\n");
            }

            // 用紙名称
            if (!string.IsNullOrEmpty(emptyYoshiNm))
            {
                errMess.Append("行 : " + emptyYoshiNm.Remove(emptyYoshiNm.Length - 2) + " : 必須項目：用紙名称が入力されていません。\r\n");
            }
            if (!string.IsNullOrEmpty(maxLengthYoshiNm))
            {
                errMess.Append("行 : " + maxLengthYoshiNm.Remove(maxLengthYoshiNm.Length - 2) + " : 用紙名称は60文字以下で入力して下さい。\r\n");
            }
            
            // 会員単価
            if (!string.IsNullOrEmpty(emptyKaiinTanka))
            {
                errMess.Append("行 : " + emptyKaiinTanka.Remove(emptyKaiinTanka.Length - 2) + " : 必須項目：会員単価が入力されていません。\r\n");
            }

            // 非会員単価
            if (!string.IsNullOrEmpty(emptyHiKaiinTanka))
            {
                errMess.Append("行 : " + emptyHiKaiinTanka.Remove(emptyHiKaiinTanka.Length - 2) + " : 必須項目：非会員単価が入力されていません。\r\n");
            }

            // セット関連チェック
            if (!string.IsNullOrEmpty(emptyKaiinSetKakaku))
            {
                errMess.Append("行 : " + emptyKaiinSetKakaku.Remove(emptyKaiinSetKakaku.Length - 2) + " : 会員セット価格、非会員セット価格、セット部数を入力してください。\r\n");
            }

            listKey = GetListDuplicate();
            ChangeBackground(listKey);

            if (listKey.Count > 0)
            {
                errMess.Append("用紙コードが重複しています。\r\n");
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            // table insert
            YoshiMstDataSet.YoshiMstDataTable insertTable = new YoshiMstDataSet.YoshiMstDataTable();

            // table update
            YoshiMstUpdateDataSet.YoshiMstUpdateDataTable updateTable = new YoshiMstUpdateDataSet.YoshiMstUpdateDataTable();

            DateTime now = Common.Common.GetCurrentTimestamp();

            for (int i = 0; i < shiireListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = shiireListDataGridView.Rows[i];

                // update
                if (shiireListDataGridView.Rows[i].Cells["IsUpdateCol"].Value.ToString() == "1")
                {
                    if (row.Cells["YoshiCdCol"].Value.ToString()            != row.Cells["YoshiCdOriginalCol"].Value.ToString()
                        || row.Cells["YoshiNmCol"].Value.ToString()         != row.Cells["YoshiNmOriginalCol"].Value.ToString()
                        || row.Cells["KaiinTankaCol"].Value.ToString()      != row.Cells["KaiinTankaOriginalCol"].Value.ToString()
                        || row.Cells["HiKaiinTankaCol"].Value.ToString()    != row.Cells["HiKaiinTankaOriginalCol"].Value.ToString()
                        || row.Cells["KaiinSetKakakuCol"].Value.ToString()  != row.Cells["KaiinSetKakakuOriginalCol"].Value.ToString()
                        || row.Cells["HiKaiinSetKakakuCol"].Value.ToString() != row.Cells["HiKaiinSetKakakuOriginalCol"].Value.ToString()
                        || row.Cells["SetBusuCol"].Value.ToString()         != row.Cells["SetBusuOriginalCol"].Value.ToString())
                    {
                        YoshiMstUpdateDataSet.YoshiMstUpdateRow updateRow = updateTable.NewYoshiMstUpdateRow();

                        updateRow.YoshiCd = row.Cells["YoshiCdCol"].Value.ToString();

                        updateRow.YoshiNm = row.Cells["YoshiNmCol"].Value.ToString();

                        updateRow.YoshiKaiinUp = Convert.ToDecimal(row.Cells["KaiinTankaCol"].Value.ToString());

                        updateRow.YoshiHiKaiinUp = Convert.ToDecimal(row.Cells["HiKaiinTankaCol"].Value.ToString());

                        updateRow.YoshiKaiinSetKakaku = Convert.ToDecimal(row.Cells["KaiinSetKakakuCol"].Value.ToString());

                        updateRow.YoshiHiKaiinSetKakaku = Convert.ToDecimal(row.Cells["HiKaiinSetKakakuCol"].Value.ToString());

                        updateRow.YoshiSetBusu = Convert.ToInt32(row.Cells["SetBusuCol"].Value);

                        updateRow.YoshiCdOriginal = row.Cells["YoshiCdOriginalCol"].Value.ToString();

                        updateRow.YoshiNmOriginal = row.Cells["YoshiNmOriginalCol"].Value.ToString();

                        updateRow.InsertDt = (DateTime)row.Cells["InsertDtCol"].Value;

                        updateRow.InsertUser = row.Cells["InsertUserCol"].Value.ToString();

                        updateRow.InsertTarm = row.Cells["InsertTarmCol"].Value.ToString();

                        updateRow.UpdateDt = (DateTime)row.Cells["UpdateDtCol"].Value;

                        updateRow.UpdateUser = row.Cells["UpdateUserCol"].Value.ToString();

                        updateRow.UpdateTarm = row.Cells["UpdateTarmCol"].Value.ToString();
                        
                        updateTable.AddYoshiMstUpdateRow(updateRow);

                        updateRow.AcceptChanges();
                        updateRow.SetAdded();
                    }
                }
                else // insert
                {
                    if ((row.Cells["YoshiCdCol"].Value == null              || string.IsNullOrEmpty(row.Cells["YoshiCdCol"].Value.ToString()))
                        && (row.Cells["YoshiNmCol"].Value == null           || string.IsNullOrEmpty(row.Cells["YoshiNmCol"].Value.ToString()))
                        && (row.Cells["KaiinTankaCol"].Value == null        || string.IsNullOrEmpty(row.Cells["KaiinTankaCol"].Value.ToString()))
                        && (row.Cells["HiKaiinTankaCol"].Value == null      || string.IsNullOrEmpty(row.Cells["HiKaiinTankaCol"].Value.ToString()))
                        && (row.Cells["KaiinSetKakakuCol"].Value == null    || string.IsNullOrEmpty(row.Cells["KaiinSetKakakuCol"].Value.ToString()))
                        && (row.Cells["HiKaiinSetKakakuCol"].Value == null  || string.IsNullOrEmpty(row.Cells["HiKaiinSetKakakuCol"].Value.ToString()))
                        && (row.Cells["SetBusuCol"].Value == null           || string.IsNullOrEmpty(row.Cells["SetBusuCol"].Value.ToString())))
                    {
                        // don't insert
                    }
                    else
                    {
                        YoshiMstDataSet.YoshiMstRow insertRow = insertTable.NewYoshiMstRow();

                        insertRow.YoshiCd = row.Cells["YoshiCdCol"].Value.ToString();

                        insertRow.YoshiNm = row.Cells["YoshiNmCol"].Value.ToString();

                        insertRow.YoshiKaiinUp = Convert.ToDecimal(row.Cells["KaiinTankaCol"].Value);

                        insertRow.YoshiHiKaiinUp = Convert.ToDecimal(row.Cells["HiKaiinTankaCol"].Value);

                        insertRow.YoshiKaiinSetKakaku = (row.Cells["KaiinSetKakakuCol"].Value == null || string.IsNullOrEmpty(row.Cells["KaiinSetKakakuCol"].Value.ToString())) 
                                                                ? 0 : Convert.ToDecimal(row.Cells["KaiinSetKakakuCol"].Value);

                        insertRow.YoshiHiKaiinSetKakaku = (row.Cells["HiKaiinSetKakakuCol"].Value == null || string.IsNullOrEmpty(row.Cells["HiKaiinSetKakakuCol"].Value.ToString())) 
                                                                ? 0 : Convert.ToDecimal(row.Cells["HiKaiinSetKakakuCol"].Value);

                        insertRow.YoshiSetBusu = (row.Cells["SetBusuCol"].Value == null || string.IsNullOrEmpty(row.Cells["SetBusuCol"].Value.ToString())) 
                                                                ? 0 : Convert.ToInt32(row.Cells["SetBusuCol"].Value);

                        insertRow.InsertDt = now;

                        insertRow.InsertUser = loginUser;

                        insertRow.InsertTarm = pcUpdate;

                        insertRow.UpdateDt = now;

                        insertRow.UpdateUser = loginUser;

                        insertRow.UpdateTarm = pcUpdate;

                        insertTable.AddYoshiMstRow(insertRow);

                        insertRow.AcceptChanges();

                        insertRow.SetAdded();
                    }
                }
            }

            IKoshinBtnClickALInput alInput = new KoshinBtnClickALInput();
            alInput.YoshiMstUpdateDT = updateTable;
            alInput.YoshiMstInsertDT = insertTable;
            IKoshinBtnClickALOutput alOutput = new KoshinBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.ListKey.Count == 0)
            {
                DoSearch();
            }
            else
            {
                ChangeBackgroundUpdate(alOutput.ListKey);
            }
        }
        #endregion

        #region GetListDuplicate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetListDuplicate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public List<string> GetListDuplicate()
        {
            List<string> listKey = new List<string>();

            for (int i = 0; i < shiireListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = shiireListDataGridView.Rows[i];

                // RelationCheck
                if (row.Cells["YoshiCdCol"].Value != null)
                {
                    string yoshiPK = row.Cells["YoshiCdCol"].Value.ToString();

                    for (int j = i + 1; j < shiireListDataGridView.RowCount; j++)
                    {
                        DataGridViewRow rowJ = shiireListDataGridView.Rows[j];

                        if (rowJ.Cells["YoshiCdCol"].Value != null)
                        {
                            string key = rowJ.Cells["YoshiCdCol"].Value.ToString();

                            if (yoshiPK == key && !string.IsNullOrEmpty(key))
                            {
                                listKey.Add(key);
                            }
                        }
                    }
                }
            }

            return listKey;
        }
        #endregion

        #region ChangeBackground
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeBackground
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeBackground(List<string> listKey)
        {
            DataGridViewCellStyle styleWhite = new DataGridViewCellStyle();

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;

            // if have data duplicate
            if (listKey != null && listKey.Count > 0)
            {
                foreach (string key in listKey)
                {
                    foreach (DataGridViewRow row in shiireListDataGridView.Rows)
                    {
                        if (row.Cells["YoshiCdCol"].Value != null)
                        {
                            if (row.Cells["YoshiCdCol"].Value.ToString() == key)
                            {
                                row.DefaultCellStyle = style;
                            }
                            else
                            {
                                //row.DefaultCellStyle = styleWhite;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in shiireListDataGridView.Rows)
                {
                    row.DefaultCellStyle = styleWhite;
                }
            }
        }
        #endregion

        #region ChangeBackgroundUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeBackground
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeBackgroundUpdate(List<string> listKey)
        {
            DataGridViewCellStyle styleWhite = new DataGridViewCellStyle();

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;

            bool flg = false;

            // if have data duplicate
            if (listKey != null && listKey.Count > 0)
            {
                foreach (string key in listKey)
                {
                    foreach (DataGridViewRow row in shiireListDataGridView.Rows)
                    {
                        if (row.Cells["YoshiCdCol"].Value != null)
                        {
                            if (row.Cells["YoshiCdCol"].Value.ToString() == key)
                            {
                                row.DefaultCellStyle = style;
                                flg = true;
                            }
                            else
                            {
                                //row.DefaultCellStyle = styleWhite;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in shiireListDataGridView.Rows)
                {
                    row.DefaultCellStyle = styleWhite;
                }
            }

            if (flg)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "用紙コードが重複しています。\r\n");
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
