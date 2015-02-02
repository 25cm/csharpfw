using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.ZaikoList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ZaikoListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ZaikoListForm : FukjBaseForm
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
        /// yoshiZaikoTblKensakuDT
        /// </summary>
        private YoshiZaikoTblDataSet.YoshiZaikoTblKensakuDataTable _yoshiZaikoTblKensakuDT = new YoshiZaikoTblDataSet.YoshiZaikoTblKensakuDataTable();

        /// <summary>
        /// yoshiZaikoTblDT
        /// </summary>
        private YoshiZaikoTblDataSet.YoshiZaikoTblDataTable _yoshiZaikoTblDT = new YoshiZaikoTblDataSet.YoshiZaikoTblDataTable();

        /// <summary>
        /// isLoad
        /// </summary>
        private bool _isLoad = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ZaikoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ZaikoListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

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
        /// 2014/07/16　HuyTX　　    新規作成
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
                if (this._searchShowFlg)//検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else////検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }

                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.zaikoListPanel,
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

        #region ZaikoListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ZaikoListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ZaikoListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shishoMstDataSet.ShishoMstExceptJimukyoku' table. You can move, or remove it, as needed.
            this.shishoMstExceptJimukyokuTableAdapter.Fill(this.shishoMstDataSet.ShishoMstExceptJimukyoku);
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.yoshiMstTableAdapter.Fill(this.yoshiMstDataSet.YoshiMst);
                this.shishoMstTableAdapter.Fill(this.shishoMstDataSet.ShishoMst);
                this.yoshiZaikoTblKensakuTableAdapter.Fill(this.yoshiZaikoTblDataSet.YoshiZaikoTblKensaku);

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
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                shishoNmComboBox.SelectedIndex = -1;
                yoshiCdFromTextBox.Text = string.Empty;
                yoshiCdToTextBox.Text = string.Empty;
                yoshiNameTextBox.Text = string.Empty;

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
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidData())
                {
                    return;
                }

                DoSearch();

                outputButton.Enabled = true;
                this._isLoad = true;

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

        #region koshinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： koshinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void koshinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsEditedControl()) return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "在庫一覧の編集内容を確定します。よろしいですか？") == DialogResult.Yes)
                {
                    if (!IsRegisConfirm()) return;
                    if (!IsValidDataUpdate()) return;

                    IKoshinBtnClickALInput alInput = new KoshinBtnClickALInput();
                    alInput.ZaikoListDataGridView = zaikoListDataGridView;

                    new KoshinBtnClickApplicationLogic().Execute(alInput);

                    _isLoad = false;
                    outputButton.Enabled = true;

                    DoFormLoad();
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
        /// 2014/07/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (zaikoListDataGridView.RowCount == 1) return;

                DataGridView dgvOuput = CreateDataOutput();

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "在庫一覧";
                Common.Common.FlushGridviewDataToExcel(dgvOuput, outputFilename);

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
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (IsEditedControl())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes) return;
                }

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

        #region ZaikoListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ZaikoListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ZaikoListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        koshinButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.PerformClick();
                        break;

                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #region zaikoListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zaikoListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zaikoListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        #endregion

        #region zaikoListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zaikoListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zaikoListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._isLoad)
                {
                    outputButton.Enabled = false;
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

        #region zaikoListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zaikoListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zaikoListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (zaikoListDataGridView.Columns[zaikoListDataGridView.CurrentCell.ColumnIndex].Name == SuryoCdCol.Name)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(ControlKeyPress);

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

        #region zaikoListDataGridView_CellFormatting
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zaikoListDataGridView_CellFormatting
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zaikoListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.ColumnIndex == SuryoCdCol.Index && e.Value != null)
                {
                    long value = 0;
                    if (long.TryParse(e.Value.ToString(), out value))
                    {
                        e.Value = value.ToString("N0");
                        e.FormattingApplied = true;
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
        /// 2014/10/21　HuyTX　　  Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(yoshiCdFromTextBox.Text.Trim())) return;

                yoshiCdFromTextBox.Text = yoshiCdFromTextBox.Text.Trim().PadLeft(2, '0');
                yoshiCdToTextBox.Text = yoshiCdFromTextBox.Text.Trim().PadLeft(2, '0');
              
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
        /// 2014/10/21　HuyTX　　  Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(yoshiCdToTextBox.Text.Trim())) return;

                yoshiCdToTextBox.Text = yoshiCdToTextBox.Text.Trim().PadLeft(2, '0');

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

        #region zaikoListDataGridView_CurrentCellDirtyStateChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zaikoListDataGridView_CurrentCellDirtyStateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　HuyTX　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zaikoListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._isLoad)
                {
                    outputButton.Enabled = false;
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
        /// 2014/07/16　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.zaikoListPanel.Top;
            this._defaultListPanelHeight = this.zaikoListPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //get all record
            _yoshiZaikoTblDT = alOutput.YoshiZaikoTblDT;

            //get data kensaku
            _yoshiZaikoTblKensakuDT = alOutput.YoshiZaikoTblKensakuDT;

            //fill data to shisho combobox
            //Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);

            //検索結果件数
            zaikoListCountLabel.Text = alOutput.YoshiZaikoTblDT.Count + "件";

            //set data for display gridview
            zaikoListDataGridView.DataSource = _yoshiZaikoTblKensakuDT;

            //Set readonly shishoCombobox & yoshiComboBox
            SetReadonlyGridView();

            this._isLoad = true;
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
        /// 2014/07/16　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            zaikoListDataGridView.DataSource = null;
            zaikoListDataGridView.Rows.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            alInput.YoshiCdFrom = yoshiCdFromTextBox.Text.Trim();
            alInput.YoshiCdTo = yoshiCdToTextBox.Text.Trim();
            alInput.YoshiNm = yoshiNameTextBox.Text.Trim();

            if (shishoNmComboBox.SelectedIndex > 0)
            {
                alInput.ShishoCd = shishoNmComboBox.SelectedValue.ToString();
            }

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            //get all record
            _yoshiZaikoTblDT = alOutput.YoshiZaikoTblDT;

            //get data kensaku
            _yoshiZaikoTblKensakuDT = alOutput.YoshiZaikoTblKensakuDT;

            zaikoListCountLabel.Text = alOutput.YoshiZaikoTblKensakuDT.Count + "件";

            if (alOutput.YoshiZaikoTblKensakuDT.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            //set data kensaku for display gridview
            zaikoListDataGridView.DataSource = _yoshiZaikoTblKensakuDT;

            //Set readonly shishoCombobox & yoshiComboBox
            SetReadonlyGridView();
        }
        #endregion

        #region IsValidData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            //用紙コード（開始）
            if (!string.IsNullOrEmpty(yoshiCdFromTextBox.Text.Trim()))
            {
                if (yoshiCdFromTextBox.Text.Trim().Length != 2 || !Utility.Utility.IsDecimal(yoshiCdFromTextBox.Text.Trim()))
                {
                    errMsg.AppendLine("用紙コード（開始）は2桁で入力して下さい。");
                }
            }

            //用紙コード（終了）
            if (!string.IsNullOrEmpty(yoshiCdToTextBox.Text.Trim()))
            {
                if (yoshiCdToTextBox.Text.Trim().Length != 2 || !Utility.Utility.IsDecimal(yoshiCdToTextBox.Text.Trim()))
                {
                    errMsg.AppendLine("用紙コード（終了）は2桁で入力して下さい。");
                }
            }

            if (string.IsNullOrEmpty(errMsg.ToString()) && !string.IsNullOrEmpty(yoshiCdFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(yoshiCdToTextBox.Text.Trim()))
            {
                if (Convert.ToInt32(yoshiCdFromTextBox.Text.Trim()) > Convert.ToInt32(yoshiCdToTextBox.Text.Trim()))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。用紙コードの大小関係を確認してください。");
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

        #region CreateDataOutput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataOutput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private DataGridView CreateDataOutput()
        {

            DataGridView dgvOutput = new DataGridView();

            for (int rowIdx = 0; rowIdx < zaikoListDataGridView.RowCount - 1; rowIdx++)
            {
                DataGridViewRow row = (DataGridViewRow)zaikoListDataGridView.Rows[rowIdx].Clone();

                for (int colIdx = 0; colIdx < zaikoListDataGridView.ColumnCount; colIdx++)
                {
                    //create column name
                    if (rowIdx == 0)
                    {
                        dgvOutput.Columns.Add(zaikoListDataGridView.Columns[colIdx].Name, zaikoListDataGridView.Columns[colIdx].HeaderText);
                        dgvOutput.Columns[colIdx].Visible = zaikoListDataGridView.Columns[colIdx].Visible;
                    }

                    if (colIdx == 0 || colIdx == 1)
                    {
                        row.Cells[colIdx].Value = ((DataGridViewComboBoxCell)zaikoListDataGridView.Rows[rowIdx].Cells[colIdx]).FormattedValue;
                        continue;
                    }

                    if (zaikoListDataGridView.Columns[colIdx].Name == DeleteFlgCol.Name)
                    {
                        row.Cells[colIdx].Value = (zaikoListDataGridView.Rows[rowIdx].Cells[DeleteFlgCol.Name].Value == null) ? "0" : "1";
                        continue;
                    }

                    row.Cells[colIdx].Value = zaikoListDataGridView.Rows[rowIdx].Cells[colIdx].Value;
                }

                dgvOutput.Columns[DeleteFlgCol.Name].DisplayIndex = 3;

                dgvOutput.Rows.Add(row);

            }

            return dgvOutput;
        }
        #endregion

        #region IsRegisConfirm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsRegisConfirm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsRegisConfirm()
        {
            for (int i = 0; i < zaikoListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = zaikoListDataGridView.Rows[i];

                if (row.Cells[SuryoCdCol.Name].Value == null || !Utility.Utility.IsDecimal(row.Cells[SuryoCdCol.Name].Value.ToString())) continue;

                if (Int32.Parse(row.Cells[SuryoCdCol.Name].Value.ToString()) > 0 && (row.Cells[DeleteFlgCol.Name].Value != null && row.Cells[DeleteFlgCol.Name].Value.ToString() == "1"))
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "在庫が存在するデータが削除対象となっていますが、編集内容で在庫一覧を確定してよろしいですか？") == DialogResult.Yes)
                    {
                        return true;
                    }
                    else { return false; }
                }

            }

            return true;
        }
        #endregion

        #region IsValidDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidDataUpdate()
        {
            StringBuilder errMsg = new StringBuilder();
            List<string> listDuplicated = new List<string>();
            string emptyShishoCd = string.Empty;
            string emptyYoshiCd = string.Empty;
            string emptySuryo = string.Empty;
            string incorrectSuryo = string.Empty;

            #region Required Check

            if (zaikoListDataGridView.RowCount - 1 == 0)
            {
                emptyShishoCd += "1, ";
                emptyYoshiCd += "1, ";
                emptySuryo += "1, ";
            }
            else
            {
                for (int i = 0; i < zaikoListDataGridView.RowCount - 1; i++)
                {
                    DataGridViewRow row = zaikoListDataGridView.Rows[i];

                    //支所(新規追加行のみ)(10)
                    if (row.Cells[ShishoCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[ShishoCol.Name].Value.ToString()))
                    {
                        emptyShishoCd += (i + 1) + ", ";
                    }

                    //用紙(新規追加行のみ)(11)
                    if (row.Cells[YoshiCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[YoshiCol.Name].Value.ToString()))
                    {
                        emptyYoshiCd += (i + 1) + ", ";
                    }

                    //在庫数(12)
                    if (row.Cells[SuryoCdCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[SuryoCdCol.Name].Value.ToString()))
                    {
                        emptySuryo += (i + 1) + ", ";
                    }
                    else if (!Utility.Utility.IsDecimal(row.Cells[SuryoCdCol.Name].Value.ToString()))
                    {
                        incorrectSuryo += (i + 1) + ", ";
                    }
                }
            }

            //支所(新規追加行のみ)(10)
            if (!string.IsNullOrEmpty(emptyShishoCd))
            {
                errMsg.AppendLine("行 : " + emptyShishoCd.Remove(emptyShishoCd.Length - 2) + " : 必須項目：支所が選択されていません。");
            }

            //用紙(新規追加行のみ)(11)
            if (!string.IsNullOrEmpty(emptyYoshiCd))
            {
                errMsg.AppendLine("行 : " + emptyYoshiCd.Remove(emptyYoshiCd.Length - 2) + " : 必須項目：用紙が選択されていません。");
            }

            //在庫数(12)
            if (!string.IsNullOrEmpty(emptySuryo))
            {
                errMsg.AppendLine("行 : " + emptySuryo.Remove(emptySuryo.Length - 2) + " : 必須項目：在庫数が入力されていません。");
            }

            #endregion

            #region Input Check

            if (!string.IsNullOrEmpty(incorrectSuryo))
            {
                errMsg.AppendLine("行 : " + incorrectSuryo.Remove(incorrectSuryo.Length - 2) + " : 在庫数は半角数字で入力して下さい。");
            }

            #endregion

            #region Relation Check

            if (string.IsNullOrEmpty(errMsg.ToString()))
            {
                listDuplicated = GetDataDuplicated();

                //highlight back ground row duplicated
                ChangeBackGroundCell(listDuplicated);

                if (listDuplicated.Count > 0)
                {
                    errMsg.AppendLine("支所＆用紙コードが重複しています。");
                }
            }

            #endregion

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region GetDataDuplicated
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDataDuplicated
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private List<string> GetDataDuplicated()
        {
            List<string> list = new List<string>();

            int startRow = Convert.ToInt32(zaikoListCountLabel.Text.Remove(zaikoListCountLabel.Text.Length - 1));

            for (int i = startRow; i < zaikoListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = zaikoListDataGridView.Rows[i];

                string shishoCd = row.Cells[ShishoCol.Name].Value.ToString();
                string yoshiCd = row.Cells[YoshiCol.Name].Value.ToString();

                //check duplicated data with zaikolist default
                for (int j = 0; j < _yoshiZaikoTblDT.Count; j++)
                {
                    if (shishoCd == _yoshiZaikoTblDT[j].YoshiZaikoShishoCd && yoshiCd == _yoshiZaikoTblDT[j].YoshiZaikoYoshiCd)
                    {
                        if (!list.Contains(shishoCd + "-" + yoshiCd))
                        {
                            list.Add(shishoCd + "-" + yoshiCd);
                        }
                        break;
                    }
                }

                //check duplicated data with new record
                for (int k = i + 1; k < zaikoListDataGridView.RowCount - 1; k++)
                {
                    DataGridViewRow rowK = zaikoListDataGridView.Rows[k];
                    if (shishoCd == rowK.Cells[ShishoCol.Name].Value.ToString()
                        && yoshiCd == rowK.Cells[YoshiCol.Name].Value.ToString()
                        && !string.IsNullOrEmpty(shishoCd)
                        && !string.IsNullOrEmpty(yoshiCd)
                        )
                    {
                        if (!list.Contains(shishoCd + "-" + yoshiCd))
                        {
                            list.Add(shishoCd + "-" + yoshiCd);
                        }
                        break;
                    }
                }
            }

            return list;
        }
        #endregion

        #region ChangeBackGroundCell
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeBackGroundCell
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeBackGroundCell(List<string> listKey)
        {
            //Set background color default
            foreach (DataGridViewRow row in zaikoListDataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = SystemColors.Window;
            }

            //Set background color row duplicated
            foreach (string key in listKey)
            {
                string shishoCd = key.Split('-')[0];
                string yoshiCd = key.Split('-')[1];

                for (int i = 0; i < zaikoListDataGridView.RowCount - 1; i++)
                {
                    DataGridViewRow row = zaikoListDataGridView.Rows[i];
                    if (row.Cells[ShishoCol.Name].Value.ToString() == shishoCd
                        && row.Cells[YoshiCol.Name].Value.ToString() == yoshiCd)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
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
        /// 2014/07/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
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
        #endregion

        #region SetReadonlyGridView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetReadonlyGridView
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetReadonlyGridView()
        {
            for (int i = 0; i < zaikoListDataGridView.RowCount - 1; i++)
            {
                foreach (DataGridViewColumn col in zaikoListDataGridView.Columns)
                {
                    DataGridViewCell cell = zaikoListDataGridView.Rows[i].Cells[col.Name];
                    if (col.Name == ShishoCol.Name || col.Name == YoshiCol.Name)
                    {
                        cell.ReadOnly = true;
                    }

                    if (col.Name == SuryoOldCol.Name)
                    {
                        cell.Value = zaikoListDataGridView.Rows[i].Cells[SuryoCdCol.Name].Value;
                    }
                }
            }
        }
        #endregion

        #region IsEditedControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsEditedControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedControl()
        {
            for (int i = 0; i < zaikoListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = zaikoListDataGridView.Rows[i];

                if ((row.Cells[DeleteFlgCol.Name].Value != null && row.Cells[DeleteFlgCol.Name].Value.ToString() == "1")
                    || row.Cells[SuryoOldCol.Name].Value != null && (row.Cells[SuryoCdCol.Name].Value.ToString() != row.Cells[SuryoOldCol.Name].Value.ToString())
                    || zaikoListDataGridView.RowCount - 1 > Convert.ToInt32(zaikoListCountLabel.Text.Remove(zaikoListCountLabel.Text.Length - 1))
                    )
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion
    }
    #endregion
}
