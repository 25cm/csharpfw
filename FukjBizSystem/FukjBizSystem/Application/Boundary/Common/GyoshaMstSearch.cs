using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common.GyoshaMstSearch;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GyoshaMstSearchForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GyoshaMstSearchForm : FukjBaseForm
    {
        #region プロパティ(public)

        /// <summary>
        /// Selected dgv row
        /// </summary>
        public GyoshaMstDataSet.GyoshaMstKensakuRow _selectedRow;

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

        /// <summary>
        /// 工事業者区分
        /// </summary>
        private string _kojiGyoshaKbn = string.Empty;

        /// <summary>
        /// 製造業者区分
        /// </summary>
        private string _seizoGyoShaKbn = string.Empty;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GyoshaMstSearchForm
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GyoshaMstSearchForm()
        {
            InitializeComponent();
        }
        #endregion
        
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GyoshaMstSearchForm
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kojiGyoshaKbn"></param>
        /// <param name="seizoGyoShaKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 22014/07/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GyoshaMstSearchForm(string kojiGyoshaKbn, string seizoGyoShaKbn)
        {
            this._kojiGyoshaKbn = kojiGyoshaKbn;
            this._seizoGyoShaKbn = seizoGyoShaKbn;
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region GyoshaMstSearchForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GyoshaMstSearchForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaMstSearchForm_Load(object sender, EventArgs e)
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
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region ViewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
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
                else // 検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }

                Boundary.Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.gyoshaListPanel,
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
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DataCheck())
                {
                    return;
                }

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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gyoshaListDataGridView.RowCount == 0) 
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return; 
                }

                this._selectedRow = (GyoshaMstDataSet.GyoshaMstKensakuRow)((DataRowView)gyoshaListDataGridView.CurrentRow.DataBoundItem).Row;

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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
                
        #region gyoshaListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                this._selectedRow = (GyoshaMstDataSet.GyoshaMstKensakuRow)((DataRowView)gyoshaListDataGridView.CurrentRow.DataBoundItem).Row;

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
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //業者コード（開始）
                gyoshaCdFromTextBox.Text = string.Empty;

                //業者コード（終了）
                gyoshaCdToTextBox.Text = string.Empty;

                //業者名称
                gyoshaNmTextBox.Text = string.Empty;

                //業者カナ名
                gyoshaKanaTextBox.Text = string.Empty;

                // 製造業者区分
                seizoGyoShaKbnCheckBox.Checked = false;

                // 工事業者区分
                kojiGyoshaKbnCheckBox.Checked = false;

                // 保守業者区分
                hoshuGyoshaKbnCheckBox.Checked = false;

                // 清掃業者区分
                seisoGyoshaKbnCheckBox.Checked = false;

                // 取扱業者区分
                toriatsukaiGyoshaKbnCheckBox.Checked = false;

                // その他業者区分
                sonotaGyoshaKbnCheckBox.Checked = false;
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

        #region GyoshaMstSearchForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GyoshaMstSearchForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaMstSearchForm_KeyDown(object sender, KeyEventArgs e)
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
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
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

        #region gyoshaListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        /// 2014/07/16  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Default search cond
            GyoshaMstSearchCond searchCond = new GyoshaMstSearchCond();
            searchCond.SeizoGyoShaKbn = _seizoGyoShaKbn;
            searchCond.KojiGyoshaKbn = _kojiGyoshaKbn;

            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.GyoshaMstSearchCond = searchCond;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            //検索結果件数
            gyoshaListCountLabel.Text = alOutput.GyoshaMstKensakuDT.Count + "件";

            //set data for display gridview
            gyoshaListDataGridView.DataSource = alOutput.GyoshaMstKensakuDT;

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.gyoshaListPanel.Top;
            this._defaultListPanelHeight = this.gyoshaListPanel.Height;
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
        /// 2014/07/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            gyoshaListDataGridView.DataSource = null;
            gyoshaListDataGridView.Rows.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            GyoshaMstSearchCond searchCond  = new GyoshaMstSearchCond();

            searchCond.GyoshaCdFrom         = gyoshaCdFromTextBox.Text.Trim();
            searchCond.GyoshaCdTo           = gyoshaCdToTextBox.Text.Trim();
            searchCond.GyoshaNm             = gyoshaNmTextBox.Text.Trim();
            searchCond.GyoshaKana           = gyoshaKanaTextBox.Text.Trim();
            searchCond.SeizoGyoShaKbn       = seizoGyoShaKbnCheckBox.Checked        ? "1" : string.Empty;
            searchCond.KojiGyoshaKbn        = kojiGyoshaKbnCheckBox.Checked         ? "1" : string.Empty;
            searchCond.HoshuGyoshaKbn       = hoshuGyoshaKbnCheckBox.Checked        ? "1" : string.Empty;
            searchCond.SeisoGyoshaKbn       = seisoGyoshaKbnCheckBox.Checked        ? "1" : string.Empty;
            searchCond.ToriatsukaiGyoshaKbn = toriatsukaiGyoshaKbnCheckBox.Checked  ? "1" : string.Empty;
            searchCond.SonotaGyoshaKbn      = sonotaGyoshaKbnCheckBox.Checked       ? "1" : string.Empty;

            alInput.GyoshaMstSearchCond = searchCond;

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.GyoshaMstKensakuDT == null || alOutput.GyoshaMstKensakuDT.Count == 0)
            {
                gyoshaListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                gyoshaListCountLabel.Text = alOutput.GyoshaMstKensakuDT.Count + "件";
                gyoshaListDataGridView.DataSource = alOutput.GyoshaMstKensakuDT;
            }
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <returns>True/False</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            //業者コード（開始）
            if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && gyoshaCdFromTextBox.Text.Length != 4)
            {
                errMsg.AppendLine("業者コード（開始）は4桁で入力して下さい。");
            }

            //業者コード（終了）
            if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text) && gyoshaCdToTextBox.Text.Length != 4)
            {
                errMsg.AppendLine("業者コード（終了）は4桁で入力して下さい。");
            }

            if (string.IsNullOrEmpty(errMsg.ToString()) && !string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
            {
                if (Convert.ToInt32(gyoshaCdFromTextBox.Text) > Convert.ToInt32(gyoshaCdToTextBox.Text))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
                }
            }

            //業者名称
            if (gyoshaNmTextBox.Text.Trim().Length > 40)
            {
                errMsg.AppendLine("業者名称は40文字以下で入力して下さい。");
            }

            //業者カナ名
            if (gyoshaKanaTextBox.Text.Trim().Length > 40)
            {
                errMsg.AppendLine("業者カナ名は40文字以下で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #endregion

    }
    #endregion
}
