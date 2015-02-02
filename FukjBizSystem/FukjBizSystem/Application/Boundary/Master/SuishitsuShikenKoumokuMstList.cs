using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuShikenKoumokuMstList;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuShikenKoumokuMstListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuShikenKoumokuMstListForm : FukjBaseForm
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
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuShikenKoumokuMstListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuShikenKoumokuMstListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SuishitsuShikenKoumokuMstListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuShikenKoumokuMstListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuShikenKoumokuMstListForm_Load(object sender, EventArgs e)
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
        /// 2014/07/01　AnhNV　　    新規作成
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
                    this.suishitsuShikenKoumokuListPanel,
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
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Reset search cond. to default
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
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //unitcheck & relationcheck
                if (!string.IsNullOrEmpty(DataCheck()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, DataCheck());
                    return;
                }

                // Execute search
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
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Call to register screen
                SuishitsuShikenKoumokuMstShosaiForm frm = new SuishitsuShikenKoumokuMstShosaiForm();
                Program.mForm.MoveNext(frm, FormEnd);
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

        #region shosaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shosaiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No rows was selected in dgv
                if (suishitsuShikenKoumokuListDataGridView.SelectedRows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                SuishitsuShikenKoumokuMstShosaiForm frm = new SuishitsuShikenKoumokuMstShosaiForm(suishitsuShikenKoumokuListDataGridView.CurrentRow.Cells["suishitsuShikenKoumokuCdCol"].Value.ToString());
                Program.mForm.MoveNext(frm, FormEnd);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No record was found
                if (suishitsuShikenKoumokuListDataGridView.Rows.Count == 0) return;

                string outputFilename = "水質試験項目マスタ一覧";
                Common.Common.FlushGridviewDataToExcel(this.suishitsuShikenKoumokuListDataGridView, outputFilename);
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
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region SuishitsuShikenKoumokuMstListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuShikenKoumokuMstListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuShikenKoumokuMstListForm_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F2:
                        shosaiButton.Focus();
                        shosaiButton.PerformClick();
                        break;
                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;
                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #region suishitsuShikenKoumokuListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuShikenKoumokuListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuShikenKoumokuListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) return;

                SuishitsuShikenKoumokuMstShosaiForm frm = new SuishitsuShikenKoumokuMstShosaiForm(suishitsuShikenKoumokuListDataGridView.Rows[e.RowIndex].Cells["suishitsuShikenKoumokuCdCol"].Value.ToString());
                Program.mForm.MoveNext(frm, FormEnd);
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

        #region suishitsuShikenKoumokuListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuShikenKoumokuListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　DatNT　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuShikenKoumokuListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region suishitsuShikenKoumokuCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuShikenKoumokuCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　DatNT　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuShikenKoumokuCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(suishitsuShikenKoumokuCdFromTextBox, suishitsuShikenKoumokuCdFromTextBox, suishitsuShikenKoumokuCdToTextBox);
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

        #region suishitsuShikenKoumokuCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuShikenKoumokuCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　DatNT　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuShikenKoumokuCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(suishitsuShikenKoumokuCdToTextBox, suishitsuShikenKoumokuCdToTextBox, suishitsuShikenKoumokuCdToTextBox);
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
        /// 2014/07/01  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.suishitsuShikenKoumokuListPanel.Top;
            this._defaultListPanelHeight = this.suishitsuShikenKoumokuListPanel.Height;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

            // 検索結果件数
            suishitsuShikenKoumokuListCountLabel.Text = string.Concat(alOutput.SuishitsuShikenKoumokuMstKensakuDataTable.Count, "件");

            // Binding source to dgv
            suishitsuShikenKoumokuListDataGridView.DataSource = alOutput.SuishitsuShikenKoumokuMstKensakuDataTable;
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
        /// 2014/07/01  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSearchCond(IKensakuBtnClickALInput input)
        {
            // 水質試験項目コードFROM
            input.SuishitsuShikenKoumokuCdFrom = suishitsuShikenKoumokuCdFromTextBox.Text;

            // 水質試験項目コードTO
            input.SuishitsuShikenKoumokuCdTo = suishitsuShikenKoumokuCdToTextBox.Text;

            // 正式名称(5)
            if (!string.IsNullOrEmpty(seishikiNmTextBox.Text.Trim()))
            {
                input.SeishikiNm = seishikiNmTextBox.Text.Trim();
            }

            // 略式名称(6)
            if (!string.IsNullOrEmpty(ryakushikiNmTextBox.Text.Trim()))
            {
                input.RyakushikiNm = ryakushikiNmTextBox.Text.Trim();
            }
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
        /// 2014/07/01  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 水質試験項目コード（開始）
            if (!string.IsNullOrEmpty(suishitsuShikenKoumokuCdFromTextBox.Text)
                && suishitsuShikenKoumokuCdFromTextBox.Text.Length != 3)
            {
                errMsg.AppendLine("水質試験項目コード（開始）は3桁で入力して下さい。");
            }

            // 水質試験項目コード（終了）
            if (!string.IsNullOrEmpty(suishitsuShikenKoumokuCdToTextBox.Text)
                && suishitsuShikenKoumokuCdToTextBox.Text.Length != 3)
            {
                errMsg.AppendLine("水質試験項目コード（終了）は3桁で入力して下さい。");
            }

            // 水質試験項目コード（開始）　must less than or equal　水質試験項目コード（終了）
            if (string.IsNullOrEmpty(errMsg.ToString()) && Convert.ToInt32(!string.IsNullOrEmpty(suishitsuShikenKoumokuCdFromTextBox.Text) ? suishitsuShikenKoumokuCdFromTextBox.Text : "0")
                > Convert.ToInt32(!string.IsNullOrEmpty(suishitsuShikenKoumokuCdToTextBox.Text) ? suishitsuShikenKoumokuCdToTextBox.Text : "999"))
            {
                errMsg.AppendLine("範囲指定が正しくありません。水質試験項目コードの大小関係を確認してください。");
            }

            // 正式名称
            if (seishikiNmTextBox.Text.Trim().Length > 30)
            {
                errMsg.AppendLine("正式名称は30文字以下で入力して下さい。");
            }

            // 略式名称
            if (ryakushikiNmTextBox.Text.Trim().Length > 10)
            {
                errMsg.AppendLine("略式名称は10文字以下で入力して下さい。");
            }

            return errMsg.ToString();
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
        /// 2014/07/01  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            suishitsuShikenKoumokuListDataGridView.DataSource = null;
            suishitsuShikenKoumokuListDataGridView.Rows.Clear();
            suishitsuShikenKoumokuListDataGridView.AutoGenerateColumns = false;

            IKensakuBtnClickALInput searchInput = new KensakuBtnClickALInput();
            SetSearchCond(searchInput);
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.SuishitsuShikenKoumokuMstKensakuDataTable.Count == 0)
            {
                // 検索結果件数
                suishitsuShikenKoumokuListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            suishitsuShikenKoumokuListCountLabel.Text = string.Concat(alOutput.SuishitsuShikenKoumokuMstKensakuDataTable.Count, "件");

            // Binding source to dgv
            suishitsuShikenKoumokuListDataGridView.DataSource = alOutput.SuishitsuShikenKoumokuMstKensakuDataTable;
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
        /// 2014/07/01  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 水質試験項目コードFROM
            suishitsuShikenKoumokuCdFromTextBox.Clear();

            // 水質試験項目コードTO
            suishitsuShikenKoumokuCdToTextBox.Clear();

            // 正式名称
            seishikiNmTextBox.Clear();

            // 略式名称
            ryakushikiNmTextBox.Clear();
        }
        #endregion

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
            // 子画面が正常終了した場合
            if (childForm.DialogResult == DialogResult.OK)
            {
                kensakuButton.PerformClick();
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
