using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common.SaisuiinMstSearch;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiinMstSearchForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiinMstSearchForm : FukjBaseForm
    {
        #region プロパティ(public)

        /// <summary>
        /// Selected dgv row
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinMstKensakuRow _selectedRow = null;

        #endregion

        #region プロパティ(private)
        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaisuiinMstSearchForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiinMstSearchForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SaisuiinMstSearchForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinMstSearchForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinMstSearchForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
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
                Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.saisuiinMstListPanel,
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Clear all input
                ClearSearchCond();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック + 関連チェック
                if (!DataCheck()) return;

                // Do search
                DoSearch();
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
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Now row was found
                if (saisuiinMstListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                this._selectedRow = (SaisuiinMstDataSet.SaisuiinMstKensakuRow)((DataRowView)saisuiinMstListDataGridView.CurrentRow.DataBoundItem).Row;
                this.DialogResult = DialogResult.OK;
                this.Close();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.Close();
                //Program.mForm.MovePrev();
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

        #region saisuiinMstListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinMstListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinMstListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid user click to header row
                if (e.RowIndex == -1) return;

                this._selectedRow = (SaisuiinMstDataSet.SaisuiinMstKensakuRow)((DataRowView)saisuiinMstListDataGridView.CurrentRow.DataBoundItem).Row;
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        #region SaisuiinMstSearchForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinMstSearchForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinMstSearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.PerformClick();
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
        /// 2014/07/16  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.saisuiinMstListPanel.Top;
            this._defaultListPanelHeight = this.saisuiinMstListPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SearchCond = new SaisuiinMstSearchCond();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検索結果件数
            saisuiinMstListCountLabel.Text = string.Concat(alOutput.SaisuiinMstKensakuDataTable.Count, "件");

            // Binding source to dgv
            saisuiinMstListDataGridView.DataSource = alOutput.SaisuiinMstKensakuDataTable;
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
        /// 2014/07/16  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            saisuiinMstListDataGridView.DataSource = null;
            saisuiinMstListDataGridView.Rows.Clear();
            saisuiinMstListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            searchInput.SearchCond = SetSearchCond();
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.SaisuiinMstKensakuDataTable.Count == 0)
            {
                // 検索結果件数
                saisuiinMstListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            saisuiinMstListCountLabel.Text = string.Concat(alOutput.SaisuiinMstKensakuDataTable.Count, "件");

            // Binding source to dgv
            saisuiinMstListDataGridView.DataSource = alOutput.SaisuiinMstKensakuDataTable;
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
        /// 2014/07/16  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();

            // 採水員コード（開始）(3)
            if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text.Trim()) && saisuiinCdFromTextBox.Text.Length != 5)
            {
                errMsg.Append("採水員コード（開始）は5桁で入力して下さい。\r\n");
            }

            // 採水員コード（終了）(4)
            if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text.Trim()) && saisuiinCdToTextBox.Text.Length != 5)
            {
                errMsg.Append("採水員コード（終了）は5桁で入力して下さい。\r\n");
            }

            // 採水員コード（開始）must less than 採水員コード（終了)
            if (string.IsNullOrEmpty(errMsg.ToString()) && Convert.ToInt32(!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text) ? saisuiinCdFromTextBox.Text : "0")
                > Convert.ToInt32(!string.IsNullOrEmpty(saisuiinCdToTextBox.Text) ? saisuiinCdToTextBox.Text : "99999"))
            {
                errMsg.Append("範囲指定が正しくありません。採水員コードの大小関係を確認してください。\r\n");
            }

            // 採水員名(5)
            if (saisuiinNmTextBox.Text.Trim().Length > 40)
            {
                errMsg.Append("採水員名は40文字以下で入力して下さい。\r\n");
            }

            bool isGyoLenErr = false;
            // Check 所属業者コード（開始）(6) length
            if (!string.IsNullOrEmpty(gyoushaCdFromTextBox.Text.Trim()) && gyoushaCdFromTextBox.Text.Length != 4)
            {
                errMsg.Append("所属業者コード（開始）は4桁で入力して下さい。\r\n");
                isGyoLenErr = true;
            }

            // Check 所属業者コード（終了) (7) length
            if (!string.IsNullOrEmpty(gyoushaCdToTextBox.Text.Trim()) && gyoushaCdToTextBox.Text.Length != 4)
            {
                errMsg.Append("所属業者コード（終了) は4桁で入力して下さい。\r\n");
                isGyoLenErr = true;
            }

            // 所属業者コード（開始）must less than 所属業者コード（終了）
            if (!isGyoLenErr && Convert.ToInt32(!string.IsNullOrEmpty(gyoushaCdFromTextBox.Text.Trim()) ? gyoushaCdFromTextBox.Text.Trim() : "0")
                > Convert.ToInt32(!string.IsNullOrEmpty(gyoushaCdToTextBox.Text.Trim()) ? gyoushaCdToTextBox.Text.Trim() : "9999"))
            {
                errMsg.Append("範囲指定が正しくありません。所属業者コードの大小関係を確認してください。\r\n");
            }

            // 所属業者名(8)
            if (gyoushaNmTextBox.Text.Trim().Length > 40)
            {
                errMsg.Append("所属業者名は40文字以下で入力して下さい。\r\n");
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

        #region ClearSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 採水員コード（開始)(3)
            saisuiinCdFromTextBox.Clear();

            // 採水員コード（終了)(4)
            saisuiinCdToTextBox.Clear();

            // 採水員名(5)
            saisuiinNmTextBox.Clear();

            // 所属業者コード（開始)(6)
            gyoushaCdFromTextBox.Clear();

            // 所属業者コード（終了)(7)
            gyoushaCdToTextBox.Clear();

            // 所属業者名(8)
            gyoushaNmTextBox.Clear();
        }
        #endregion

        #region SetSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstSearchCond SetSearchCond()
        {
            SaisuiinMstSearchCond searchCond = new SaisuiinMstSearchCond();

            // 採水員コードFROM
            if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text))
            {
                searchCond.SaisuiinCdFrom = saisuiinCdFromTextBox.Text;
            }

            // 採水員コードTO
            if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text))
            {
                searchCond.SaisuiinCdTo = saisuiinCdToTextBox.Text;
            }

            // 採水員名
            if (!string.IsNullOrEmpty(saisuiinNmTextBox.Text.Trim()))
            {
                searchCond.SaisuiinNm = saisuiinNmTextBox.Text.Trim();
            }

            // 所属業者コードFROM
            if (!string.IsNullOrEmpty(gyoushaCdFromTextBox.Text))
            {
                searchCond.GyoshaCdFrom = gyoushaCdFromTextBox.Text;
            }

            // 所属業者コードTO
            if (!string.IsNullOrEmpty(gyoushaCdToTextBox.Text))
            {
                searchCond.GyoshaCdTo = gyoushaCdToTextBox.Text;
            }

            // 業者名
            if (!string.IsNullOrEmpty(gyoushaNmTextBox.Text.Trim()))
            {
                searchCond.GyoshaNm = gyoushaNmTextBox.Text.Trim();
            }

            return searchCond;
        }
        #endregion

        #endregion
    }
    #endregion
}
