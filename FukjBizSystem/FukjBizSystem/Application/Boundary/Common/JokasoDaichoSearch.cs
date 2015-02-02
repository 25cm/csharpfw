using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common.JokasoDaichoSearch;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoDaichoSearchForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/13　AnhNV　　   新規作成
    /// 2014/12/26　豊田　　    初期ロード時に浄化槽台帳マスタの検索を行わないよう変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JokasoDaichoSearchForm : FukjBaseForm
    {
        #region プロパティ(public)

        /// <summary>
        /// Selected dgv row
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstSearchRow _selectedRow = null;

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
        //  コンストラクタ名 ： JokasoDaichoSearchForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JokasoDaichoSearchForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region JokasoDaichoSearchForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JokasoDaichoSearchForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoDaichoSearchForm_Load(object sender, EventArgs e)
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

        #region JokasoDaichoSearchForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JokasoDaichoSearchForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoDaichoSearchForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/08/13　AnhNV　　    新規作成
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
                    this.jokasoDaichoListPanel,
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
        /// 2014/08/13　AnhNV　　    新規作成
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
        /// 2014/08/13　AnhNV　　    新規作成
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

        #region jokasoListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jokasoListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jokasoListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid user click to header row
                if (e.RowIndex == -1) return;

                this._selectedRow = (JokasoDaichoMstDataSet.JokasoDaichoMstSearchRow)((DataRowView)jokasoListDataGridView.CurrentRow.DataBoundItem).Row;
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
        /// 2014/08/13　AnhNV　　    新規作成
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
                if (jokasoListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                this._selectedRow = (JokasoDaichoMstDataSet.JokasoDaichoMstSearchRow)((DataRowView)jokasoListDataGridView.CurrentRow.DataBoundItem).Row;
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
        /// 2014/08/13　AnhNV　　    新規作成
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
        /// 2014/08/13  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.jokasoDaichoListPanel.Top;
            this._defaultListPanelHeight = this.jokasoDaichoListPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            
            // 2014.12.26 toyoda Delete Start
            //alInput.SearchCond = new JokasoDaichoMstSearchCond();
            // 2014.12.26 toyoda Delete Delete

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検索結果件数
            // 2014.12.26 toyoda Mod Start
            //jokasoDaichoListCountLabel.Text = string.Concat(alOutput.JokasoDaichoMstSearchDataTable.Count, "件");

            //// Binding source to dgv
            //jokasoListDataGridView.DataSource = alOutput.JokasoDaichoMstSearchDataTable;
            jokasoDaichoListCountLabel.Text = string.Concat(0, "件");
            // 2014.12.26 toyoda Mod End

            // 保健所
            Utility.Utility.SetComboBoxList(hokenjoNmComboBox, alOutput.HokenjoMstDataTable, "HokenjoNm", "HokenjoCd", true);
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
        /// 2014/08/13  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            jokasoListDataGridView.DataSource = null;
            jokasoListDataGridView.Rows.Clear();
            jokasoListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            searchInput.SearchCond = SetSearchCond();
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.JokasoDaichoMstSearchDataTable.Count == 0)
            {
                // 検索結果件数
                jokasoDaichoListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            jokasoDaichoListCountLabel.Text = string.Concat(alOutput.JokasoDaichoMstSearchDataTable.Count, "件");

            // Binding source to dgv
            jokasoListDataGridView.DataSource = alOutput.JokasoDaichoMstSearchDataTable;
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
        /// 2014/08/13  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();
            bool checkCdLenOK = true;

            // 台帳連番（開始）
            if (!string.IsNullOrEmpty(renbanFromTextBox.Text.Trim())
                && renbanFromTextBox.Text.Length != 5)
            {
                errMsg.Append("台帳連番（開始）は5桁で入力して下さい。\r\n");
                checkCdLenOK = false;
            }

            // 台帳連番（終了）
            if (!string.IsNullOrEmpty(renbanToTextBox.Text.Trim())
                && renbanToTextBox.Text.Length != 5)
            {
                errMsg.Append("台帳連番（終了）は5桁で入力して下さい。\r\n");
                checkCdLenOK = false;
            }

            // 台帳連番（開始）> 台帳連番（終了）
            if (!string.IsNullOrEmpty(renbanFromTextBox.Text.Trim())
                && !string.IsNullOrEmpty(renbanToTextBox.Text.Trim())
                && Convert.ToInt32(renbanFromTextBox.Text) > Convert.ToInt32(renbanToTextBox.Text)
                && checkCdLenOK)
            {
                errMsg.Append("範囲指定が正しくありません。台帳連番の大小関係を確認してください。\r\n");
            }

            // 設置者名
            if (settisyaNmTextBox.Text.Length > 60)
            {
                errMsg.Append("設置者名は60文字以下で入力して下さい。\r\n");
            }

            // 設置住所
            if (settiAdrTextBox.Text.Length > 80)
            {
                errMsg.Append("設置住所は80文字以下で入力して下さい。\r\n");
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
        /// 2014/08/13  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 保健所
            hokenjoNmComboBox.SelectedIndex = 0;

            // 登録年月
            torokuNendoTextBox.Clear();

            // 台帳連番（開始）
            renbanFromTextBox.Clear();

            // 台帳連番（終了）
            renbanToTextBox.Clear();

            // 設置者名
            settisyaNmTextBox.Clear();

            // 設置住所
            settiAdrTextBox.Clear();
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
        /// 2014/08/13  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoDaichoMstSearchCond SetSearchCond()
        {
            JokasoDaichoMstSearchCond searchCond = new JokasoDaichoMstSearchCond();

            // 保健所
            searchCond.HokenjoCd = hokenjoNmComboBox.SelectedIndex > 0 ? hokenjoNmComboBox.SelectedValue.ToString() : string.Empty;

            // 登録年月
            searchCond.JokasoTorokuNendo = torokuNendoTextBox.Text;

            // 台帳連番（開始）
            searchCond.RenbanFrom = renbanFromTextBox.Text;

            // 台帳連番（終了）
            searchCond.RenbanTo = renbanToTextBox.Text;

            // 設置者名
            searchCond.SettisyaNm = settisyaNmTextBox.Text.Trim();

            // 設置住所
            searchCond.SettiAdr = settiAdrTextBox.Text.Trim();

            return searchCond;
        }
        #endregion

        #endregion
    }
    #endregion
}
