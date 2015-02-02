using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.TuckSealList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.YoshiHanbaiKanri;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TuckSealListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　AnhNV　　   新規作成
    /// 2014/12/26　豊田　　    浄化槽台帳マスタ初期ロード時に全読み込みするのではなく、必要都度DBアクセスを行うよう変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class TuckSealListForm : FukjBaseForm
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

        // Data property names
        private const string KBNCOL = "KbnCol";
        private const string CDCOL = "CdCol";
        private const string HOKENJONMCOL = "HokenjoNmCol";
        private const string NMCOL = "NmCol";
        private const string NENGETSUCOL = "NengetsuCol";
        private const string RENBANCOL = "RenbanCol";
        private const string ZIPNOCOL = "ZipNoCol";
        private const string ADRCOL = "AdrCol";

        /// <summary>
        /// Is dgv source change?
        /// </summary>
        private bool _isDgvEdit;

        /// <summary>
        /// Dgv is ready change?
        /// </summary>
        private bool _isDgvLoadOK = false;

        /// <summary>
        /// Radio button before checked changed
        /// </summary>
        private RadioButton _lastRdChecked;

        /// <summary>
        /// 業者マスタ
        /// </summary>
        private TuckSealListDataSet.GyoshaMstDataTable _gyoshaMst;

        /// <summary>
        /// 保健所マスタ
        /// </summary>
        private TuckSealListDataSet.HokenjoMstDataTable _hokenjoMst;

        // 2014.12.26 toyoda Delete Start
        ///// <summary>
        ///// 浄化槽台帳マスタ
        ///// </summary>
        //private TuckSealListDataSet.JokasoDaichoMstDataTable _jokasoDaichoMst;
        // 2014.12.26 toyoda Delete End

        /// <summary>
        /// 地区マスタ
        /// </summary>
        private TuckSealListDataSet.ChikuMstDataTable _chikuMst;

        /// <summary>
        /// isBackTouchPnl(back to touch panel 003-004)
        /// </summary>
        private bool _isBackTouchPnl = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TuckSealListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TuckSealListForm()
        {
            InitializeComponent();

            // ControlDomain
            SetStdControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TuckSealListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TuckSealListForm(bool isBackTouchPnl)
        {
            InitializeComponent();

            // ControlDomain
            SetStdControlDomain();

            _isBackTouchPnl = isBackTouchPnl;
        }
        #endregion

        #region イベント

        #region TuckSealListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TuckSealListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TuckSealListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default value
                DoFormLoad();

                // 発行区分/業者 is checked
                GyoshaRdCheckedChanged();

                // Load completed
                _isDgvLoadOK = true;
                _lastRdChecked = gyosyaRadioButton;
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

        #region TuckSealListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TuckSealListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TuckSealListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        printButton.Focus();
                        printButton.PerformClick();
                        break;
                    case Keys.F2:
                        printSofujoButton.Focus();
                        printSofujoButton.PerformClick();
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
                        busuTextBox.Focus();
                        listDataGridView.Focus();
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
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gyosyaRadioButton.Checked)
                {
                    // To fire event clear dgv
                    //hokenjoRadioButton.Checked = true;
                    if (_isDgvEdit)
                    {
                        // 一覧クリアチェック
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧内容がクリアされます。よろしいですか？") == DialogResult.Yes)
                        {
                            // Reset the dgv
                            ResetDgv();

                            // Checked changed
                            GyoshaRdCheckedChanged();

                            // Control the data property names
                            //SetDataProperties();

                            // Reset search cond
                            ClearSearchCond();

                            _isDgvEdit = false;
                            //_lastRdChecked = gyosyaRadioButton;
                        }
                        //else if (_lastRdChecked != null)
                        //{
                        //    _lastRdChecked.Checked = true;
                        //}
                    }
                    else
                    {
                        // Reset the dgv
                        ResetDgv();

                        // Checked changed
                        GyoshaRdCheckedChanged();

                        // Control the data property names
                        //SetDataProperties();

                        // Reset search cond
                        ClearSearchCond();

                        _isDgvEdit = false;
                        //_lastRdChecked = gyosyaRadioButton;
                    }
                }

                // 発行区分/業者(3)
                gyosyaRadioButton.Checked = true;

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
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Input check + relation check
                if (!DataCheck(cdFromTextBox.MaxLength,
                    gyosyaRadioButton.Checked ? "業者コード" : (hokenjoRadioButton.Checked ? "保健所コード" : "浄化槽台帳連番")))
                {
                    return;
                }

                // Dgv is loading
                _isDgvLoadOK = false;

                // Do search
                DoSearch();

                // Dgv load completed
                _isDgvLoadOK = true;
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

        #region printButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： printButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Dgv row count = 0
                if (listDataGridView.Rows.Count == 0) return;

                // No row selected
                if (!PrintCheck())
                {
                    //MessageForm.Show2(MessageForm.DispModeType.Error, "印刷する内容がありません。");
                    return;
                }

                // Confirmation message
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "タックシールを印刷します。よろしいですか？") == DialogResult.Yes)
                {
                    IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                    alInput.CopyNumber = !string.IsNullOrEmpty(busuTextBox.Text.Trim()) ? Convert.ToInt32(busuTextBox.Text) : 1;
                    alInput.PrintPosition = Convert.ToInt32(printPositionComboBox.SelectedIndex.ToString()) + 1;
                    alInput.TuckSealListDataTable = GetDataTableFromDgv();
                    new PrintBtnClickApplicationLogic().Execute(alInput);
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

        #region printSofujoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： printSofujoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printSofujoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Dgv row count = 0
                if (listDataGridView.Rows.Count == 0) return;

                // No row selected
                if (!PrintCheck())
                {
                    return;
                }

                // Printer is not installed
                // 2014.12.16 toyoda Mod Start プリンタ設定をDB保持に変更
                //string printer = Common.Common.GetPrinterName(Utility.Constants.PrinterConstant.PRINT_TYPE_SOFUJO);
                string printer = Common.Common.GetPrinterName(Utility.Constants.PrintKbn.PRINT_KBN_SOFUJO);
                // 2014.12.16 toyoda Mod End

                if (!Common.Common.PrinterExist(printer))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "印刷先のプリンターが設定されていません。");
                    return;
                }

                // Confirmation message
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "送付状を印刷します。よろしいですか？") == DialogResult.Yes)
                {
                    IPrintSofujoBtnClickALInput alInput = new PrintSofujoBtnClickALInput();
                    alInput.PrinterName = printer;
                    alInput.CopyNumber = !string.IsNullOrEmpty(busuTextBox.Text.Trim()) ? Convert.ToInt32(busuTextBox.Text) : 1;
                    alInput.TuckSealListDataTable = GetDataTableFromDgv();
                    new PrintSofujoBtnClickApplicationLogic().Execute(alInput);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Dgv row count = 0
                if (listDataGridView.Rows.Count == 0) return;

                // Make a copy of listDataGridView
                listDataGridView.AutoGenerateColumns = false;
                DataGridView printDgv = Common.Common.CopyDataGridView(listDataGridView);
                printDgv.Columns["HokenjoHiddenCol"].Visible = true;

                // Get hidden, button and combobox columns
                List<string> hiddenColNm = new List<string>();
                foreach (DataGridViewColumn dgvc in printDgv.Columns)
                {
                    if (dgvc.Visible == false
                        || dgvc.GetType() == typeof(DataGridViewButtonColumn)
                        || dgvc.Name == HokenjoNmCol.Name
                        || dgvc.Name == GyosyaCdCol.Name
                        || dgvc.Name == ChikuCdCol.Name)
                    {
                        hiddenColNm.Add(dgvc.Name);
                    }
                }

                // Copy combobox values to print datagridview
                foreach (DataGridViewRow dr in listDataGridView.Rows)
                {
                    if (hokenjoRadioButton.Checked || settisyaRadioButton.Checked)
                    {
                        DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dr.Cells[HokenjoNmCol.Name];
                        printDgv.Rows[dr.Index].Cells["HokenjoHiddenCol"].Value = cbCell.FormattedValue;
                    }
                    else if (gyosyaRadioButton.Checked)
                    {
                        printDgv.Rows[dr.Index].Cells["HokenjoHiddenCol"].Value = dr.Cells[GyosyaCdCol.Name].Value;
                    }
                    else
                    {
                        printDgv.Rows[dr.Index].Cells["HokenjoHiddenCol"].Value = dr.Cells[ChikuCdCol.Name].Value;
                    }
                }

                // Remove hidden, button and combobox columns
                foreach (string col in hiddenColNm)
                {
                    printDgv.Columns.Remove(col);
                }

                // File name
                string fileName = "タックシール・送付状印刷";
                Common.Common.FlushGridviewDataToExcel(printDgv, fileName);
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
        /// 2014/08/07　AnhNV　　    新規作成
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
                    this.srhListPanel,
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

        #region gyosyaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid CheckedChanged event fires twice
                RadioButton rd = sender as RadioButton;
                if (!rd.Checked || _lastRdChecked == rd) return;

                if (_isDgvEdit)
                {
                    // 一覧クリアチェック
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧内容がクリアされます。よろしいですか？") == DialogResult.Yes)
                    {
                        // Reset the dgv
                        ResetDgv();

                        // Checked changed
                        GyoshaRdCheckedChanged();

                        // Control the data property names
                        //SetDataProperties();

                        // Reset search cond
                        ClearSearchCond();

                        _isDgvEdit = false;
                        _lastRdChecked = gyosyaRadioButton;
                    }
                    else if (_lastRdChecked != null)
                    {
                        _lastRdChecked.Checked = true;
                    }
                }
                else
                {
                    // Reset the dgv
                    ResetDgv();

                    // Checked changed
                    GyoshaRdCheckedChanged();

                    // Control the data property names
                    //SetDataProperties();

                    // Reset search cond
                    ClearSearchCond();

                    _isDgvEdit = false;
                    _lastRdChecked = gyosyaRadioButton;
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

        #region hokenjoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hokenjoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hokenjoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid CheckedChanged event fires twice
                RadioButton rd = sender as RadioButton;
                if (!rd.Checked || _lastRdChecked == rd) return;

                if (_isDgvEdit)
                {
                    // 一覧クリアチェック
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧内容がクリアされます。よろしいですか？") == DialogResult.Yes)
                    {
                        // Reset the dgv
                        ResetDgv();

                        // Checked changed
                        HokenjoRdCheckedChanged();

                        // Control the data property names
                        //SetDataProperties();

                        // Reset search cond
                        ClearSearchCond();

                        _isDgvEdit = false;
                        _lastRdChecked = hokenjoRadioButton;
                    }
                    else
                    {
                        _lastRdChecked.Checked = true;
                    }
                }
                else
                {
                    // Reset the dgv
                    ResetDgv();

                    // Checked changed
                    HokenjoRdCheckedChanged();

                    // Control the data property names
                    //SetDataProperties();

                    // Reset search cond
                    ClearSearchCond();

                    _isDgvEdit = false;
                    _lastRdChecked = hokenjoRadioButton;
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

        #region shichosonRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shichosonRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shichosonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid CheckedChanged event fires twice
                RadioButton rd = sender as RadioButton;
                if (!rd.Checked || _lastRdChecked == rd) return;

                if (_isDgvEdit)
                {
                    // 一覧クリアチェック
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧内容がクリアされます。よろしいですか？") == DialogResult.Yes)
                    {
                        // Reset the dgv
                        ResetDgv();

                        // Checked changed
                        ShichosonRdCheckedChanged();

                        // Control the data property names
                        //SetDataProperties();

                        // Reset search cond
                        ClearSearchCond();

                        _lastRdChecked = shichosonRadioButton;
                        _isDgvEdit = false;
                    }
                    else
                    {
                        _lastRdChecked.Checked = true;
                    }
                }
                else
                {
                    // Reset the dgv
                    ResetDgv();

                    // Checked changed
                    ShichosonRdCheckedChanged();

                    // Control the data property names
                    //SetDataProperties();

                    // Reset search cond
                    ClearSearchCond();

                    _isDgvEdit = false;
                    _lastRdChecked = shichosonRadioButton;
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

        #region settisyaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： settisyaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void settisyaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid CheckedChanged event fires twice
                RadioButton rd = sender as RadioButton;
                if (!rd.Checked || _lastRdChecked == rd) return;

                if (_isDgvEdit)
                {
                    // 一覧クリアチェック
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧内容がクリアされます。よろしいですか？") == DialogResult.Yes)
                    {
                        // Reset the dgv
                        ResetDgv();

                        // Checked changed
                        SettisyaRdCheckedChanged();

                        // Control the data property names
                        //SetDataProperties();

                        // Reset search cond
                        ClearSearchCond();

                        _lastRdChecked = settisyaRadioButton;
                        _isDgvEdit = false;
                    }
                    else
                    {
                        _lastRdChecked.Checked = true;
                    }
                }
                else
                {
                    // Reset the dgv
                    ResetDgv();

                    // Checked changed
                    SettisyaRdCheckedChanged();

                    // Control the data property names
                    //SetDataProperties();

                    // Reset search cond
                    ClearSearchCond();

                    _isDgvEdit = false;
                    _lastRdChecked = settisyaRadioButton;
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
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //OthersMenuForm frm = new OthersMenuForm();
                //Program.mForm.ShowForm(frm);

                //ADD_HuyTX_20141023_START
                //call back touch panel
                if (_isBackTouchPnl)
                {
                    _isBackTouchPnl = false;
                    //this.Close();
                    Program.tyumonMenuFrm = null;
                    TyumonListForm frm = new TyumonListForm();
                    frm.ShowDialog();
                    return;
                }
                //ADD_HuyTX_20141023_END

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

        #region listDataGridView_CellLeave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellLeave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　AnhNV　　    新規作成
        /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// 2014/10/24  AnhNV　　    基本設計書_008_003_画面_TuckSealList_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Gyosha search
                if (gyosyaRadioButton.Checked && listDataGridView.Columns[e.ColumnIndex].Name == GyosyaCdCol.Name)
                {
                    listDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    // Current 業者コード
                    string gyoshaCd = string.Empty;
                    if (!string.IsNullOrEmpty(Convert.ToString(listDataGridView.CurrentRow.Cells[GyosyaCdCol.Name].Value)))
                    {
                        gyoshaCd = listDataGridView.CurrentRow.Cells[GyosyaCdCol.Name].Value.ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        SetNmZipCdAdr(string.Empty, string.Empty, string.Empty);
                        return;
                    }

                    // Padding '0' to GyoshaCd cell
                    listDataGridView.CurrentRow.Cells[GyosyaCdCol.Name].Value = gyoshaCd;

                    // Search in GyoshaMst
                    GyoshaSearch(gyoshaCd);
                }
                else if (shichosonRadioButton.Checked && listDataGridView.Columns[e.ColumnIndex].Name == ChikuCdCol.Name) // Chiku search
                {
                    listDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    // Get 地区コード
                    string chikuCd = string.Empty;
                    if (!string.IsNullOrEmpty(Convert.ToString(listDataGridView.CurrentRow.Cells[ChikuCdCol.Name].Value)))
                    {
                        chikuCd = listDataGridView.CurrentRow.Cells[ChikuCdCol.Name].Value.ToString().PadLeft(5, '0');
                    }
                    else
                    {
                        SetNmZipCdAdr(string.Empty, string.Empty, string.Empty);
                        return;
                    }

                    //// Get 地区コード
                    //string chikuCd = listDataGridView.CurrentRow.Cells[ChikuCdCol.Name].Value != null
                    //    ? listDataGridView.CurrentRow.Cells[ChikuCdCol.Name].Value.ToString().PadLeft(5, '0') : string.Empty;

                    // Padding '0' to ChikuCd cell
                    listDataGridView.CurrentRow.Cells[ChikuCdCol.Name].Value = chikuCd;

                    // Search in ChikuMst
                    TuckSealListDataSet.ChikuMstRow[] chikuRow = (TuckSealListDataSet.ChikuMstRow[])_chikuMst.Select(string.Format("ChikuCd = '{0}'", chikuCd));

                    // No record was found
                    if (chikuRow.Length == 0)
                    {
                        // Error
                        MessageForm.Show2(MessageForm.DispModeType.Error, "入力された地区コードは存在しません。");
                        // Clear cell values
                        listDataGridView.CurrentRow.Cells[ChikuCdCol.Name].Value = string.Empty;
                        listDataGridView.CurrentRow.Cells[NmCol.Name].Value = string.Empty;
                        listDataGridView.CurrentRow.Cells[ZipNoCol.Name].Value = string.Empty;
                        listDataGridView.CurrentRow.Cells[AdrCol.Name].Value = string.Empty;
                        return;
                    }

                    // 宛先名称(23) + 郵便番号(24) + 住所(25)
                    SetNmZipCdAdr(chikuRow[0].ChikuTantoKa, chikuRow[0].ChikuTantoYubinNo, chikuRow[0].ChikuTantoAdr);
                }
                else if (settisyaRadioButton.Checked &&
                    (listDataGridView.Columns[e.ColumnIndex].Name == NengetsuCol.Name || listDataGridView.Columns[e.ColumnIndex].Name == RenbanCol.Name)) // JokasoDaichoMst search
                {
                    listDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string hokenjoCd = !string.IsNullOrEmpty(Convert.ToString(listDataGridView.CurrentRow.Cells[HokenjoNmCol.Name].Value))
                        ? listDataGridView.CurrentRow.Cells[HokenjoNmCol.Name].Value.ToString() : string.Empty;
                    string nengetsu = !string.IsNullOrEmpty(Convert.ToString(listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value))
                        ? listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value.ToString().PadLeft(4, '0') : string.Empty;
                    string renban = !string.IsNullOrEmpty(Convert.ToString(listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value))
                        ? listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value.ToString().PadLeft(5, '0') : string.Empty;

                    // No handle for empty value
                    if (string.IsNullOrEmpty(nengetsu) && string.IsNullOrEmpty(renban))
                    {
                        return;
                    }

                    // Set value with padding
                    if (!string.IsNullOrEmpty(nengetsu))
                    {
                        listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value = nengetsu;
                    }
                    if (!string.IsNullOrEmpty(renban))
                    {
                        listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value = renban;
                    }

                    if (!string.IsNullOrEmpty(hokenjoCd) && !string.IsNullOrEmpty(nengetsu) && !string.IsNullOrEmpty(renban))
                    {
                        // Search in JokasoDaichoMst
                        JokasoDaichoSearch(hokenjoCd, nengetsu, renban);
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

        #region listDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　AnhNV　　    新規作成
        /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Prevent from input non-integer value to datagridview cells
                switch (listDataGridView.Columns[listDataGridView.CurrentCell.ColumnIndex].Name)
                {
                    case "GyosyaCdCol":
                    case "NengetsuCol":
                    case "RenbanCol":
                    case "ZipNoCol":
                    case "ChikuCdCol":
                        e.Control.KeyPress += new KeyPressEventHandler(listDataGridView_ControlKeyPress);
                        break;
                    default:
                        break;
                }

                // Click to 保健所 combobox
                if ((hokenjoRadioButton.Checked || settisyaRadioButton.Checked)
                    && listDataGridView.Columns[listDataGridView.CurrentCell.ColumnIndex].Name == HokenjoNmCol.Name)
                {
                    listDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    ComboBox cbo = e.Control as ComboBox;
                    if (cbo != null)
                    {
                        cbo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                        cbo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                    }

                    // Checked checkbox
                    //listDataGridView.CurrentRow.Cells[KbnCol.Name].Value = "1";
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

        #region listDataGridView_CellClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid user click to header
                if (e.RowIndex == -1) return;
                SetTextSrhBtnForDgvRow();

                // Gyosha search
                if (gyosyaRadioButton.Checked && listDataGridView.Columns[e.ColumnIndex].Name == SrhBtnCol.Name)
                {
                    // Open gyoshaMst search form
                    GyoshaMstSearchForm gFrm = new GyoshaMstSearchForm();
                    //Program.mForm.MoveNext(gFrm);
                    gFrm.ShowDialog();

                    // User close the form without selection
                    if (gFrm.DialogResult != DialogResult.OK) return;

                    // No row was selected
                    if (gFrm._selectedRow == null) return;

                    // 業者コード(17)
                    listDataGridView.CurrentRow.Cells[GyosyaCdCol.Name].Value = gFrm._selectedRow.GyoshaCd;
                    // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
                    SetNmZipCdAdr(
                        gFrm._selectedRow.GyoshaNm,
                        gFrm._selectedRow.GyoshaZipCd,
                        gFrm._selectedRow.GyoshaAdr);
                }
                else if (shichosonRadioButton.Checked && listDataGridView.Columns[e.ColumnIndex].Name == SrhBtnCol.Name) // Chiku search
                {
                    // Open ChikuMstSearchForm (000-006)
                    ChikuMstSearchForm cFrm = new ChikuMstSearchForm();
                    //Program.mForm.MoveNext(cFrm);
                    cFrm.ShowDialog();

                    // User close the form without selection
                    if (cFrm.DialogResult != DialogResult.OK) return;

                    // No row was selected
                    if (cFrm._selectedRow == null) return;

                    // 地区コード(34)
                    listDataGridView.CurrentRow.Cells[ChikuCdCol.Name].Value = cFrm._selectedRow.ChikuCd;
                    // 宛先名称(23)
                    listDataGridView.CurrentRow.Cells[NmCol.Name].Value = cFrm._selectedRow.ChikuTantoKa;
                    // 郵便番号(24)
                    listDataGridView.CurrentRow.Cells[ZipNoCol.Name].Value = cFrm._selectedRow.ChikuTantoYubinNo;
                    // 住所(25)
                    listDataGridView.CurrentRow.Cells[AdrCol.Name].Value = cFrm._selectedRow.ChikuTantoAdr;
                }
                else if (settisyaRadioButton.Checked && listDataGridView.Columns[e.ColumnIndex].Name == SrhBtnCol.Name) // Setchisa search
                {
                    // Open JokasoMstSearchForm
                    JokasoDaichoSearchForm jFrm = new JokasoDaichoSearchForm();
                    jFrm.ShowDialog();

                    // User close the form without selection
                    if (jFrm.DialogResult != DialogResult.OK) return;

                    // No row was selected
                    if (jFrm._selectedRow == null) return;

                    // 保健所名(18)
                    listDataGridView.CurrentRow.Cells[HokenjoNmCol.Name].Value = jFrm._selectedRow.JokasoHokenjoCd;
                    // 年月(19)
                    listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value = jFrm._selectedRow.JokasoTorokuNendo;
                    // 連番(20)
                    listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value = jFrm._selectedRow.JokasoRenban;
                    // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
                    SetNmZipCdAdr(
                        jFrm._selectedRow.JokasoSetchishaNm,
                        jFrm._selectedRow.JokasoSetchishaZipCd,
                        jFrm._selectedRow.JokasoSetchishaAdr);
                }

                if (e.RowIndex == listDataGridView.Rows.Count - 1
                    && listDataGridView.Columns[e.ColumnIndex].Name == SrhBtnCol.Name)
                {
                    // Add a blank row at the bottom of dgv
                    AddBlankRowToDgv(e.RowIndex);

                    if (settisyaRadioButton.Checked)
                    {
                        // Initialize comboboxCell
                        //SetCbSourceForDgvRow(e.RowIndex + 1);
                        foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                        {
                            // Source for hokenjoNm combobox in initialization
                            DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvr.Cells[HokenjoNmCol.Name];
                            cbCell.DataSource = _hokenjoMst;
                            cbCell.DisplayMember = "HokenjoNm";
                            cbCell.ValueMember = "HokenjoCd";
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

        #region listDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/20　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Datagridview was finished loading and edited?
                if (_isDgvLoadOK)
                {
                    _isDgvEdit = true;
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

        #region listDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    // Text for button column
                    DataGridViewButtonCell cell = (DataGridViewButtonCell)dgvr.Cells[SrhBtnCol.Name];
                    cell.Value = "検索";

                    // Source for hokenjoNm combobox
                    DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvr.Cells[HokenjoNmCol.Name];
                    cbCell.DataSource = _hokenjoMst;
                    cbCell.DisplayMember = "HokenjoNm";
                    cbCell.ValueMember = "HokenjoCd";
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

        #region cdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： cdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　AnhNV　　    基本設計書_008_003_画面_TuckSealList_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void cdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not fire this event when textbox is empty
                if (string.IsNullOrEmpty(cdFromTextBox.Text)) return;

                // Padding '0' to equal the max length digits
                cdFromTextBox.Text = cdFromTextBox.Text.PadLeft(cdFromTextBox.MaxLength, '0');

                // ~To
                cdToTextBox.Text = cdFromTextBox.Text;
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

        #region cdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： cdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　AnhNV　　    基本設計書_008_003_画面_TuckSealList_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void cdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not fire this event when textbox is empty
                if (string.IsNullOrEmpty(cdToTextBox.Text)) return;

                // Padding '0' to equal the max length digits
                cdToTextBox.Text = cdToTextBox.Text.PadLeft(cdToTextBox.MaxLength, '0');
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

        #region listDataGridView_UserAddedRow
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_UserAddedRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　AnhNV　　    基本設計書_008_003_画面_TuckSealList_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Initialize comboboxCell
                SetCbSourceForDgvRow(e.Row.Index);

                // Initialize buttonCell
                SetTextSrhBtnForDgvRow();

                // Checked checkbox column
                listDataGridView.CurrentRow.Cells[KbnCol.Name].Value = "1";
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

        #region listDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/19　AnhNV　　    基本設計書_008_003_画面_TuckSealList_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        /// 2014/08/07  AnhNV　　    新規作成
        /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            TuckSealSearchCond searchCond = new TuckSealSearchCond();
            searchCond.RdSelect = "1";

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SearchCond = searchCond;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Result tables
            _gyoshaMst = alOutput.GyoshaMstDataTable;
            _hokenjoMst = alOutput.HokenjoMstDataTable;
            
            // 2014.12.26 toyoda Delete Start
            //_jokasoDaichoMst = alOutput.JokasoDaichoMstDataTable;
            // 2014.12.26 toyoda Delete End

            _chikuMst = alOutput.ChikuMstDataTable;
            //_dispTable = alOutput.TuckSealListDataTable;

            // 検索結果件数
            //srhListCountLabel.Text = string.Concat(alOutput.TuckSealListDataTable.Count, "件");

            // 保健所(6)
            Utility.Utility.SetComboBoxList(hokenjoComboBox, alOutput.HokenjoMstDataTable, "HokenjoNm", "HokenjoCd", true);

            // タックシール印刷位置(28)
            printPositionComboBox.SelectedIndex = 0;

            // Load the initial status of datagridview
            ResetDgv();

            // Control the display of dgv
            DgvControl(_hokenjoMst);
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
        /// 2014/08/07  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Load the initial status of datagridview
            ResetDgv();

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            searchInput.SearchCond = SetSearchCond();
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.TuckSealListDataTable.Count == 0)
            {
                // 検索結果件数
                srhListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            srhListCountLabel.Text = string.Concat(alOutput.TuckSealListDataTable.Count, "件");

            // Binding source to dgv
            //SetDataProperties();
            listDataGridView.DataSource = alOutput.TuckSealListDataTable;

            // Control the display of dgv
            DgvControl(_hokenjoMst);

            // Dgv is changed
            _isDgvEdit = true;
        }
        #endregion

        #region DgvControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DgvControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbSource"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DgvControl(TuckSealListDataSet.HokenjoMstDataTable cbSource)
        {
            // 印刷(16)
            listDataGridView.Columns[KbnCol.Name].DisplayIndex = 0;

            // 業者コード(17)
            listDataGridView.Columns[GyosyaCdCol.Name].DisplayIndex = 1;

            // 保健所名(18)
            listDataGridView.Columns[HokenjoNmCol.Name].DisplayIndex = 2;

            // 年月(19)
            listDataGridView.Columns[NengetsuCol.Name].DisplayIndex = 3;

            // 連番(20)
            listDataGridView.Columns[RenbanCol.Name].DisplayIndex = 4;

            // 地区コード(34)
            listDataGridView.Columns[ChikuCdCol.Name].DisplayIndex = 5;

            // 検索ボタン(21)
            listDataGridView.Columns[SrhBtnCol.Name].DisplayIndex = 6;

            // 業者名/保健所名/設置者名(22)
            listDataGridView.Columns[NmCol.Name].DisplayIndex = 7;

            // 郵便番号(23)
            listDataGridView.Columns[ZipNoCol.Name].DisplayIndex = 8;

            // 住所(24)
            listDataGridView.Columns[AdrCol.Name].DisplayIndex = 9;

            foreach (DataGridViewRow dgvr in listDataGridView.Rows)
            {
                // Text for button column
                DataGridViewButtonCell cell = (DataGridViewButtonCell)dgvr.Cells[SrhBtnCol.Name];
                cell.Value = "検索";

                if (!shichosonRadioButton.Checked && !gyosyaRadioButton.Checked)
                {
                    // Source for hokenjoNm combobox
                    string cbVal = string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[GyosyaCdCol.Name].Value)) ? string.Empty : dgvr.Cells[GyosyaCdCol.Name].Value.ToString();
                    DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvr.Cells[HokenjoNmCol.Name];
                    cbCell.DataSource = cbSource;
                    cbCell.DisplayMember = "HokenjoNm";
                    cbCell.ValueMember = "HokenjoCd";
                    cbCell.Value = cbSource.AsEnumerable().Any(row => cbVal == row.Field<String>("HokenjoCd")) ? cbVal : string.Empty;
                }
            }
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
        /// 2014/08/07  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 保健所(6)
            hokenjoComboBox.SelectedIndex = 0;

            // 登録年月(7)
            nengetsuTextBox.Text = string.Empty;

            // コード（開始）(8)
            cdFromTextBox.Text = string.Empty;

            // コード（終了）(9)
            cdToTextBox.Text = string.Empty;

            // Name textbox(29)
            nameTextBox.Text = string.Empty;
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
        /// 2014/08/11  AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private TuckSealSearchCond SetSearchCond()
        {
            TuckSealSearchCond searchCond = new TuckSealSearchCond();

            // 発行区分
            searchCond.RdSelect = (gyosyaRadioButton.Checked) ? "1" : (hokenjoRadioButton.Checked ? "2" : (shichosonRadioButton.Checked ? "3" : "4"));

            // 保健所コード
            searchCond.HokenjoCd = hokenjoComboBox.SelectedValue != null ? hokenjoComboBox.SelectedValue.ToString() : string.Empty;

            // 登録年月
            searchCond.Nengetsu = nengetsuTextBox.Text;

            // コード（開始）
            searchCond.CdFrom = cdFromTextBox.Text;

            // コード（終了）
            searchCond.CdTo = cdToTextBox.Text;

            // 業者名称/保健所名/設置者氏名
            searchCond.SearchNm = nameTextBox.Text.Trim();

            return searchCond;
        }
        #endregion

        #region GyoshaRdCheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaRdCheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaRdCheckedChanged()
        {
            // 検索結果件数
            srhListCountLabel.Text = "0件";

            // 保健所コンボボックス(6)
            hokenjoComboBox.Enabled = false;

            // 登録年月(7)
            nengetsuTextBox.ReadOnly = true;

            // コードFrom(8)
            cdFromTextBox.ReadOnly = false;
            cdFromTextBox.MaxLength = 4;

            // コードTo(9)
            cdToTextBox.ReadOnly = false;
            cdToTextBox.MaxLength = 4;

            // 名称(29)
            nameTextBox.ReadOnly = false;

            // 印刷(16)
            listDataGridView.Columns[KbnCol.Name].Visible = true;

            // 業者コード(17)
            listDataGridView.Columns[GyosyaCdCol.Name].Visible = true;

            // 保健所名(18)
            listDataGridView.Columns[HokenjoNmCol.Name].Visible = false;

            // 年月(19)
            listDataGridView.Columns[NengetsuCol.Name].Visible = false;

            // 連番(20)
            listDataGridView.Columns[RenbanCol.Name].Visible = false;

            // 地区コード(34)
            listDataGridView.Columns[ChikuCdCol.Name].Visible = false;

            // 検索ボタン(21)
            listDataGridView.Columns[SrhBtnCol.Name].Visible = true;
            SetTextSrhBtnForDgvRow();

            // Control the display of dgv
            DgvControl(_hokenjoMst);
        }
        #endregion

        #region HokenjoRdCheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： HokenjoRdCheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HokenjoRdCheckedChanged()
        {
            // 検索結果件数
            srhListCountLabel.Text = "0件";

            // 保健所コンボボックス(6)
            hokenjoComboBox.Enabled = true;

            // 登録年月(7)
            nengetsuTextBox.ReadOnly = true;

            // コードFrom(8)
            cdFromTextBox.ReadOnly = false;
            cdFromTextBox.MaxLength = 2;

            // コードTo(9)
            cdToTextBox.ReadOnly = false;
            cdToTextBox.MaxLength = 2;

            // 名称(29)
            nameTextBox.ReadOnly = false;

            // 印刷(16)
            listDataGridView.Columns[KbnCol.Name].Visible = true;

            // 業者コード(17)
            listDataGridView.Columns[GyosyaCdCol.Name].Visible = false;

            // 保健所名(18)
            listDataGridView.Columns[HokenjoNmCol.Name].Visible = true;
            SetCbSourceForDgvRow(0);

            // 年月(19)
            listDataGridView.Columns[NengetsuCol.Name].Visible = false;

            // 連番(20)
            listDataGridView.Columns[RenbanCol.Name].Visible = false;

            // 地区コード(34)
            listDataGridView.Columns[ChikuCdCol.Name].Visible = false;

            // 検索ボタン(21)
            listDataGridView.Columns[SrhBtnCol.Name].Visible = false;

            // Control the display of dgv
            DgvControl(_hokenjoMst);
        }
        #endregion

        #region ShichosonRdCheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShichosonRdCheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShichosonRdCheckedChanged()
        {
            // 検索結果件数
            srhListCountLabel.Text = "0件";

            // 保健所コンボボックス(6)
            hokenjoComboBox.Enabled = false;

            // 登録年月(7)
            nengetsuTextBox.ReadOnly = true;

            // コードFrom(8)
            cdFromTextBox.ReadOnly = false;
            cdFromTextBox.MaxLength = 5;

            // コードTo(9)
            cdToTextBox.ReadOnly = false;
            cdToTextBox.MaxLength = 5;

            // 名称(29)
            nameTextBox.ReadOnly = false;

            // 印刷(16)
            listDataGridView.Columns[KbnCol.Name].Visible = true;

            // 業者コード(17)
            listDataGridView.Columns[GyosyaCdCol.Name].Visible = false;

            // 保健所名(18)
            listDataGridView.Columns[HokenjoNmCol.Name].Visible = false;

            // 年月(19)
            listDataGridView.Columns[NengetsuCol.Name].Visible = false;

            // 連番(20)
            listDataGridView.Columns[RenbanCol.Name].Visible = false;

            // 地区コード(34)
            listDataGridView.Columns[ChikuCdCol.Name].Visible = true;

            // 検索ボタン(21)
            listDataGridView.Columns[SrhBtnCol.Name].Visible = true;
            SetTextSrhBtnForDgvRow();

            // Control the display of dgv
            DgvControl(_hokenjoMst);
        }
        #endregion

        #region SettisyaRdCheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SettisyaRdCheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SettisyaRdCheckedChanged()
        {
            // 検索結果件数
            srhListCountLabel.Text = "0件";

            // 保健所コンボボックス(6)
            hokenjoComboBox.Enabled = true;

            // 登録年月(7)
            nengetsuTextBox.ReadOnly = false;

            // コードFrom(8)
            cdFromTextBox.ReadOnly = false;
            cdFromTextBox.MaxLength = 5;

            // コードTo(9)
            cdToTextBox.ReadOnly = false;
            cdToTextBox.MaxLength = 5;

            // 名称(29)
            nameTextBox.ReadOnly = false;

            // 印刷(16)
            listDataGridView.Columns[KbnCol.Name].Visible = true;

            // 業者コード(17)
            listDataGridView.Columns[GyosyaCdCol.Name].Visible = false;

            // 保健所名(18)
            listDataGridView.Columns[HokenjoNmCol.Name].Visible = true;
            SetCbSourceForDgvRow(0);

            // 年月(19)
            listDataGridView.Columns[NengetsuCol.Name].Visible = true;

            // 連番(20)
            listDataGridView.Columns[RenbanCol.Name].Visible = true;

            // 地区コード(34)
            listDataGridView.Columns[ChikuCdCol.Name].Visible = false;

            // 検索ボタン(21)
            listDataGridView.Columns[SrhBtnCol.Name].Visible = true;
            SetTextSrhBtnForDgvRow();

            // Control the display of dgv
            DgvControl(_hokenjoMst);
        }
        #endregion

        #region SetDataProperties
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDataProperties
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void SetDataProperties()
        //{
            //// 印刷(16)
            //listDataGridView.Columns["KbnCol"].DataPropertyName = KBNCOL;

            //// 業者コード(17)
            //listDataGridView.Columns["GyosyaCdCol"].DataPropertyName = CDCOL;

            //// 保健所名(18)
            //listDataGridView.Columns["HokenjoNmCol"].DataPropertyName = CDCOL;

            //// 年月(19)
            //listDataGridView.Columns["NengetsuCol"].DataPropertyName = NENGETSUCOL;

            //// 連番(20)
            //listDataGridView.Columns["RenbanCol"].DataPropertyName = RENBANCOL;

            //// 業者名/保健所名/設置者名(22)
            //listDataGridView.Columns["NmCol"].DataPropertyName = NMCOL;

            //// 郵便番号(23)
            //listDataGridView.Columns["ZipNoCol"].DataPropertyName = ZIPNOCOL;

            //// 住所(24)
            //listDataGridView.Columns["AdrCol"].DataPropertyName = ADRCOL;
        //}
        #endregion

        #region GyoshaSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaCdColLeave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  AnhNV　　    新規作成
        /// 2014/10/24  AnhNV　　    基本設計書_008_003_画面_TuckSealList_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaSearch(string gyoshaCd)
        {
            string gyoshaNm = string.Empty;
            string gyoshaZipCd = string.Empty;
            string gyoshaAdr = string.Empty;
            DataRow[] row = _gyoshaMst.Select(string.Format("GyoshaCd = '{0}'", gyoshaCd), string.Empty);

            // No record was found
            if (row.Length == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "入力された業者コードは存在しません。");
                // 業者コード(17)
                listDataGridView.CurrentRow.Cells[GyosyaCdCol.Name].Value = string.Empty;
                // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
                SetNmZipCdAdr(string.Empty, string.Empty, string.Empty);
                return;
            }

            gyoshaNm = row[0]["GyoshaNm"].ToString();
            gyoshaZipCd = row[0]["GyoshaZipCd"].ToString();
            gyoshaAdr = row[0]["GyoshaAdr"].ToString();

            // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
            SetNmZipCdAdr(gyoshaNm, gyoshaZipCd, gyoshaAdr);
        }
        #endregion

        #region JokasoDaichoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： HokenjoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjoCd"></param>
        /// <param name="nengetsu"></param>
        /// <param name="renban"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  AnhNV　　    新規作成
        /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoDaichoSearch(string hokenjoCd, string nengetsu, string renban)
        {
            // Error message
            StringBuilder errMsg = new StringBuilder();
            // 設置者氏名
            string name = string.Empty;
            // 設置者郵便番号
            string zipNo = string.Empty;
            // 浄化槽設置者住所
            string adr = string.Empty;

            // 年月(19) not equal 4 digits
            if (!string.IsNullOrEmpty(nengetsu) && nengetsu.Length != 4)
            {
                errMsg.Append("年月は4桁で入力して下さい。\r\n");
            }

            // 連番(20) not equal 5 digits
            //if (!string.IsNullOrEmpty(renban) && renban.Length != 5)
            //{
            //    errMsg.Append("連番は5桁で入力して下さい。");
            //}

            // Throw a new exception
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());

                // Clear input
                // 保健所名(18)
                listDataGridView.CurrentRow.Cells[HokenjoNmCol.Name].Value = string.Empty;
                // 年月(19)
                listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value = string.Empty;
                // 連番(20)
                listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value = string.Empty;
                // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
                SetNmZipCdAdr(string.Empty, string.Empty, string.Empty);

                return;
            }

            // Key pair is not valid
            if (string.IsNullOrEmpty(hokenjoCd)
                || string.IsNullOrEmpty(nengetsu)
                || string.IsNullOrEmpty(renban))
            {
                return;
            }

            // 2014.12.26 toyoda Mod Start
            //DataRow[] row = _jokasoDaichoMst.
            //    Select(string.Format("JokasoHokenjoCd = '{0}' and JokasoTorokuNendo = '{1}' and JokasoRenban = '{2}'", hokenjoCd, nengetsu, renban));
            IGetJokasoDaichoMstInfoALInput daichoInput = new GetJokasoDaichoMstInfoALInput();
            daichoInput.HokenjoCd = hokenjoCd;
            daichoInput.TorokuNendo = nengetsu;
            daichoInput.Renban = renban;
            IGetJokasoDaichoMstInfoALOutput daichoOutput = new GetJokasoDaichoMstInfoApplicationLogic().Execute(daichoInput);
            // 2014.12.26 toyoda Mod End

            // 2014.12.26 toyoda Mod Start
            // No record was found
            //if (row.Length == 0)
            if (daichoOutput.JokasoDaichoMstDT.Count == 0)
            // 2014.12.26 toyoda Mod End
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "入力された設置者は存在しません。");

                // 保健所名(18)
                listDataGridView.CurrentRow.Cells[HokenjoNmCol.Name].Value = string.Empty;
                // 年月(19)
                listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value = string.Empty;
                // 連番(20)
                listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value = string.Empty;
                // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
                SetNmZipCdAdr(string.Empty, string.Empty, string.Empty);

                return;
            }

            // 2014.12.26 toyoda Mod Start
            //name = row[0]["JokasoSetchishaNm"].ToString();
            //zipNo = row[0]["JokasoSetchishaZipCd"].ToString();
            //adr = row[0]["JokasoSetchishaAdr"].ToString();
            name = daichoOutput.JokasoDaichoMstDT[0]["JokasoSetchishaNm"].ToString();
            zipNo = daichoOutput.JokasoDaichoMstDT[0]["JokasoSetchishaZipCd"].ToString();
            adr = daichoOutput.JokasoDaichoMstDT[0]["JokasoSetchishaAdr"].ToString();
            // 2014.12.26 toyoda Mod End

            // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
            SetNmZipCdAdr(name, zipNo, adr);
        }
        #endregion

        #region ComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  AnhNV　　    新規作成
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

            // 保健所コード
            string hokenjoCd = cb.SelectedValue.ToString();
            //listDataGridView.CurrentRow.Cells["HiddenCdCol"].Value = hokenjoCd;

            // Hokenjo search
            if (hokenjoRadioButton.Checked)
            {
                // Hokenjo datarow
                DataRow[] row = _hokenjoMst.Select(string.Format("HokenjoCd = '{0}'", hokenjoCd), string.Empty);

                // 保健所名
                string hokenjoNm = row[0]["HokenjoNm"].ToString();
                // 保健所郵便番号
                string hokenjoZipCd = row[0]["HokenjoZipCd"].ToString();
                // 保健所住所
                string hokenjoAdr = row[0]["HokenjoAdr"].ToString();
                // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
                SetNmZipCdAdr(hokenjoNm, hokenjoZipCd, hokenjoAdr);
            }
            else if (settisyaRadioButton.Checked)
            {
                // 年月(19)
                string nengetsu = listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value != null
                    ? listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value.ToString() : string.Empty;
                // 連番(20)
                string renban = listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value != null
                    ? listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value.ToString() : string.Empty;

                JokasoDaichoSearch(hokenjoCd, nengetsu, renban);
            }
        }
        #endregion

        #region InitDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitDgv
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  AnhNV　　    新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InitDgv()
        {
            // 
            // KbnCol
            // 
            DataGridViewCheckBoxColumn ckCol = new DataGridViewCheckBoxColumn();
            ckCol.FalseValue = "0";
            ckCol.HeaderText = "印刷";
            ckCol.MinimumWidth = 65;
            ckCol.Name = "KbnCol";
            ckCol.DataPropertyName = "KbnCol";
            ckCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ckCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            ckCol.TrueValue = "1";
            ckCol.Width = 65;
            listDataGridView.Columns.Add(ckCol);
            // 
            // HokenjoHiddenCol
            // 
            DataGridViewTextBoxColumn hokenjoNmHiddenCol = new DataGridViewTextBoxColumn();
            hokenjoNmHiddenCol.HeaderText = (hokenjoRadioButton.Checked || settisyaRadioButton.Checked) ? "保健所名" : (gyosyaRadioButton.Checked ? "業者コード" : "地区コード");
            hokenjoNmHiddenCol.MinimumWidth = 120;
            hokenjoNmHiddenCol.Name = "HokenjoHiddenCol";
            hokenjoNmHiddenCol.DataPropertyName = CDCOL;
            hokenjoNmHiddenCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            hokenjoNmHiddenCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            hokenjoNmHiddenCol.Width = 120;
            hokenjoNmHiddenCol.Visible = false;
            listDataGridView.Columns.Add(hokenjoNmHiddenCol);
            // 
            // GyosyaCdCol
            // 
            DataGridViewTextBoxColumn gyosyaCdCol = new DataGridViewTextBoxColumn();
            gyosyaCdCol.HeaderText = "業者コード";
            gyosyaCdCol.MinimumWidth = 80;
            gyosyaCdCol.MaxInputLength = 4;
            gyosyaCdCol.Name = "GyosyaCdCol";
            gyosyaCdCol.DataPropertyName = CDCOL;
            gyosyaCdCol.Width = 80;
            gyosyaCdCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            listDataGridView.Columns.Add(gyosyaCdCol);
            // 
            // HokenjoNmCol
            // 
            DataGridViewComboBoxColumn hokenjoNmCol = new DataGridViewComboBoxColumn();
            hokenjoNmCol.HeaderText = "保健所名";
            hokenjoNmCol.MinimumWidth = 120;
            hokenjoNmCol.Name = "HokenjoNmCol";
            hokenjoNmCol.DataPropertyName = "CdCol";
            hokenjoNmCol.DataSource = _hokenjoMst;
            hokenjoNmCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            hokenjoNmCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            hokenjoNmCol.Width = 120;
            listDataGridView.Columns.Add(hokenjoNmCol);
            // 
            // NengetsuCol
            // 
            DataGridViewTextBoxColumn nengetsuCol = new DataGridViewTextBoxColumn();
            nengetsuCol.HeaderText = "登録年度";
            nengetsuCol.MinimumWidth = 70;
            nengetsuCol.MaxInputLength = 4;
            nengetsuCol.Name = "NengetsuCol";
            nengetsuCol.DataPropertyName = NENGETSUCOL;
            nengetsuCol.Width = 70;
            nengetsuCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            listDataGridView.Columns.Add(nengetsuCol);
            // 
            // RenbanCol
            // 
            DataGridViewTextBoxColumn renbanCol = new DataGridViewTextBoxColumn();
            renbanCol.HeaderText = "連番";
            renbanCol.MinimumWidth = 60;
            renbanCol.MaxInputLength = 5;
            renbanCol.Name = "RenbanCol";
            renbanCol.DataPropertyName = RENBANCOL;
            renbanCol.Width = 60;
            renbanCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            listDataGridView.Columns.Add(renbanCol);
            // 
            // ChikuCdCol
            // 
            DataGridViewTextBoxColumn chikuCdCol = new DataGridViewTextBoxColumn();
            chikuCdCol.HeaderText = "地区コード";
            chikuCdCol.MinimumWidth = 80;
            chikuCdCol.MaxInputLength = 5;
            chikuCdCol.Name = "ChikuCdCol";
            chikuCdCol.DataPropertyName = CDCOL;
            chikuCdCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            chikuCdCol.Width = 80;
            listDataGridView.Columns.Add(chikuCdCol);
            // 
            // SrhBtnCol
            // 
            DataGridViewButtonColumn srhBtnCol = new DataGridViewButtonColumn();
            srhBtnCol.HeaderText = "検索";
            srhBtnCol.MinimumWidth = 65;
            srhBtnCol.Name = "SrhBtnCol";
            srhBtnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            srhBtnCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            srhBtnCol.Width = 65;
            srhBtnCol.DataPropertyName = "SrhBtnCol";
            listDataGridView.Columns.Add(srhBtnCol);
            // 
            // NmCol
            // 
            DataGridViewTextBoxColumn nmCol = new DataGridViewTextBoxColumn();
            nmCol.HeaderText = "宛先名称";
            nmCol.MinimumWidth = 200;
            nmCol.Name = "NmCol";
            nmCol.DataPropertyName = NMCOL;
            nmCol.MaxInputLength = 60;
            //nmCol.ReadOnly = true;
            nmCol.Width = 200;
            nmCol.MaxInputLength = gyosyaRadioButton.Checked ? 40 : (hokenjoRadioButton.Checked ? 24 : 60);
            nmCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            //nmCol.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            listDataGridView.Columns.Add(nmCol);
            // 
            // ZipNoCol
            // 
            DataGridViewTextBoxColumn zipNoCol = new DataGridViewTextBoxColumn();
            zipNoCol.HeaderText = "郵便番号";
            zipNoCol.MinimumWidth = 90;
            zipNoCol.Name = "ZipNoCol";
            zipNoCol.DataPropertyName = ZIPNOCOL;
            //zipNoCol.ReadOnly = true;
            zipNoCol.Width = 90;
            zipNoCol.MaxInputLength = 8;
            zipNoCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            //zipNoCol.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            listDataGridView.Columns.Add(zipNoCol);
            // 
            // AdrCol
            // 
            DataGridViewTextBoxColumn adrCol = new DataGridViewTextBoxColumn();
            adrCol.HeaderText = "住所";
            adrCol.MinimumWidth = 360;
            adrCol.Name = "AdrCol";
            adrCol.DataPropertyName = ADRCOL;
            //adrCol.ReadOnly = true;
            adrCol.Width = 360;
            adrCol.MaxInputLength = 80;
            adrCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            //adrCol.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            listDataGridView.Columns.Add(adrCol);
        }
        #endregion

        #region ResetDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ResetDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ResetDgv()
        {
            listDataGridView.DataSource = null;
            listDataGridView.Rows.Clear();
            listDataGridView.Columns.Clear();
            InitDgv();

            // Binding source to dgv
            listDataGridView.DataSource = new JokasoDaichoMstDataSet.TuckSealListDataTable();

            if (gyosyaRadioButton.Checked)
            {
                GyoshaRdCheckedChanged();
            }
            else if (hokenjoRadioButton.Checked)
            {
                HokenjoRdCheckedChanged();
            }
            else if (shichosonRadioButton.Checked)
            {
                ShichosonRdCheckedChanged();
            }
            else
            {
                SettisyaRdCheckedChanged();
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
        /// 2014/08/12　AnhNV　　    新規作成
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
        /// 2014/08/19　AnhNV　　    新規作成
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

        #region listDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： listDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (listDataGridView.Columns[listDataGridView.CurrentCell.ColumnIndex].Name)
            {
                case "GyosyaCdCol":
                case "NengetsuCol":
                case "RenbanCol":
                case "ChikuCdCol":
                    e.Handled = !IsOKForDecimalTextBox(e.KeyChar, sender as TextBox) ? true : false;
                    break;
                case "ZipNoCol":
                    e.Handled = !IsOKForDecimalWithNegativeTextBox(e.KeyChar, sender as TextBox) ? true : false;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region PrintCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool PrintCheck()
        {
            bool result = false;
            int rowCnt = 0;
            string err58_1 = string.Empty;
            string err58_2 = string.Empty;
            string err58_3 = string.Empty;
            string errMsg = string.Empty;

            foreach (DataGridViewRow dgvr in listDataGridView.Rows)
            {
                // Any row is checked!
                if ((bool)dgvr.Cells[KbnCol.Name].FormattedValue == true
                    && !result)
                {
                    result = true;
                }

                if (dgvr.Cells[ZipNoCol.Name].Value == null ||
                    string.IsNullOrEmpty(dgvr.Cells[ZipNoCol.Name].Value.ToString().Trim()))
                {

                }
                else if (dgvr.Cells[ZipNoCol.Name].Value.ToString().Length != 8)
                {
                    err58_1 += rowCnt + 1 + ", ";
                }
                else if (!Utility.Utility.IsNumAndNegative(dgvr.Cells[ZipNoCol.Name].Value.ToString()))
                {
                    err58_2 += rowCnt + 1 + ", ";
                }
                else if (!Utility.Utility.IsZipCode(dgvr.Cells[ZipNoCol.Name].Value.ToString()))
                {
                    err58_3 += rowCnt + 1 + ", ";
                }

                rowCnt++;
            }

            // No row is checked
            if (!result)
            {
                errMsg += "印刷する内容がありません。\r\n";
            }

            if (err58_1 != string.Empty)
            {
                errMsg += string.Format("行{0}: 郵便番号は8桁で入力して下さい。\r\n", err58_1.Remove(err58_1.Length - 2));
            }

            if (err58_2 != string.Empty)
            {
                errMsg += string.Format("行{0}: 郵便番号は半角数字、及び\" - (半角ハイフン)\"で入力して下さい。\r\n", err58_2.Remove(err58_2.Length - 2));
            }

            if (err58_3 != string.Empty)
            {
                errMsg += string.Format("行{0}: 郵便番号の形式が不正です。\r\n", err58_3.Remove(err58_3.Length - 2));
            }

            // Data check fail
            if (!string.IsNullOrEmpty(errMsg.Replace(Environment.NewLine, string.Empty)))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg);
                result = false;
            }

            return result;
        }
        #endregion

        #region GetDataTableFromDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDataTableFromDgv
        /// <summary>
        /// Get DataTable from selected dgv rows
        /// </summary>
        /// <param name=""></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoDaichoMstDataSet.TuckSealListDataTable GetDataTableFromDgv()
        {
            JokasoDaichoMstDataSet.TuckSealListDataTable table = new JokasoDaichoMstDataSet.TuckSealListDataTable();

            foreach (DataGridViewRow row in listDataGridView.Rows)
            {
                if (row.Index < listDataGridView.Rows.Count - 1 && row.Cells[KbnCol.Name].Value.ToString() == "1")
                {
                    // 20141121 habu 画面上で追加した業者の印刷時にエラーになる
                    JokasoDaichoMstDataSet.TuckSealListRow newRow = table.NewTuckSealListRow();

                    newRow[table.KbnColColumn] = row.Cells[KbnCol.Name].Value;
                    if (gyosyaRadioButton.Checked) { newRow[table.CdColColumn] = row.Cells[GyosyaCdCol.Name].Value; }
                    if (hokenjoRadioButton.Checked) { newRow[table.CdColColumn] = row.Cells["HokenjoHiddenCol"].Value; }
                    if (shichosonRadioButton.Checked) { newRow[table.CdColColumn] = row.Cells[ChikuCdCol.Name].Value; }
                    //if (settisyaRadioButton.Checked) { newRow[table.CdColColumn] = row.Cells[set.Name].Value; }
                    newRow[table.NengetsuColColumn] = row.Cells[NengetsuCol.Name].Value;
                    newRow[table.RenbanColColumn] = row.Cells[RenbanCol.Name].Value;
                    newRow[table.NmColColumn] = row.Cells[NmCol.Name].Value;
                    newRow[table.ZipNoColColumn] = row.Cells[ZipNoCol.Name].Value;
                    newRow[table.AdrColColumn] = row.Cells[AdrCol.Name].Value;

                    table.AddTuckSealListRow(newRow);
                    // 20141121 End

                    // JokasoDaichoMstDataSet.TuckSealListRow dr = (JokasoDaichoMstDataSet.TuckSealListRow)(row.DataBoundItem as DataRowView).Row;

                    // table.ImportRow(dr);
                }
            }

            return table;
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdLen"></param>
        /// <param name="labelCd"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck(int cdLen, string labelCd)
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();
            bool lenCheckFail = false;

            // コード（開始）
            if (!string.IsNullOrEmpty(cdFromTextBox.Text)
                && cdFromTextBox.Text.Length != cdLen)
            {
                errMsg.AppendLine(string.Format("{0}（開始）は{1}桁で入力して下さい。", labelCd, cdLen));
                lenCheckFail = true;
            }

            // コード（終了）
            if (!string.IsNullOrEmpty(cdToTextBox.Text)
                && cdToTextBox.Text.Length != cdLen)
            {
                errMsg.AppendLine(string.Format("{0}（終了）は{1}桁で入力して下さい。", labelCd, cdLen));
                lenCheckFail = true;
            }

            // 関連チェック
            if (!lenCheckFail
                && !string.IsNullOrEmpty(cdFromTextBox.Text)
                && !string.IsNullOrEmpty(cdToTextBox.Text)
                && Convert.ToDecimal(cdFromTextBox.Text) > Convert.ToDecimal(cdToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。コードの大小関係を確認してください。");
            }

            // 登録年度(7)
            if (!string.IsNullOrEmpty(nengetsuTextBox.Text))
            {
                //// Not alphanumeric violation
                //if (!Utility.Utility.IsDecimal(nengetsuTextBox.Text))
                //{
                //    errMsg.AppendLine("登録年度は半角数字で入力して下さい。");
                //}

                // Length violation
                if (nengetsuTextBox.Text.Length != 4)
                {
                    errMsg.AppendLine("登録年度は4桁で入力して下さい。");
                }
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

        #region SetNmZipCdAdr
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetNmZipCdAdr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="zipCd"></param>
        /// <param name="adr"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetNmZipCdAdr(string name, string zipCd, string adr)
        {
            // 業者名/保健所名/設置者名(22)
            listDataGridView.CurrentRow.Cells[NmCol.Name].Value = name;

            // 郵便番号(23)
            listDataGridView.CurrentRow.Cells[ZipNoCol.Name].Value = zipCd;
            
            // 住所(24)
            listDataGridView.CurrentRow.Cells[AdrCol.Name].Value = adr;
        }
        #endregion

        #region JokasoFormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JokasoFormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoFormEnd(Form childForm)
        {
            // 子画面が正常終了した場合
            if (childForm.DialogResult == DialogResult.OK)
            {
                JokasoDaichoSearchForm jFrm = childForm as JokasoDaichoSearchForm;

                // 保健所名(18)
                listDataGridView.CurrentRow.Cells[HokenjoNmCol.Name].Value = jFrm._selectedRow.JokasoHokenjoCd;
                // 年月(19)
                listDataGridView.CurrentRow.Cells[NengetsuCol.Name].Value = jFrm._selectedRow.JokasoTorokuNendo;
                // 連番(20)
                listDataGridView.CurrentRow.Cells[RenbanCol.Name].Value = jFrm._selectedRow.JokasoRenban;
                // 業者名/保健所名/設置者名(22) + 郵便番号(23) + 住所(24)
                SetNmZipCdAdr(
                    jFrm._selectedRow.JokasoSetchishaNm,
                    jFrm._selectedRow.JokasoSetchishaZipCd,
                    jFrm._selectedRow.JokasoSetchishaAdr);
            }
        }
        #endregion

        #region SetStdControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // Textboxes
            nengetsuTextBox.SetControlDomain(ZControlDomain.ZT_NENDO);
            nameTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            cdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);
            cdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);
            busuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            
            // GridView
            listDataGridView.SetStdControlDomain(GyosyaCdCol.Index, ZControlDomain.ZG_STD_CD, 4);
            listDataGridView.SetStdControlDomain(NengetsuCol.Index, ZControlDomain.ZG_STD_NUM, 4, DataGridViewContentAlignment.MiddleLeft);
            listDataGridView.SetStdControlDomain(RenbanCol.Index, ZControlDomain.ZG_STD_CD, 5);
            listDataGridView.SetStdControlDomain(ChikuCdCol.Index, ZControlDomain.ZG_STD_CD, 5);
            listDataGridView.SetStdControlDomain(NmCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            listDataGridView.SetStdControlDomain(ZipNoCol.Index, ZControlDomain.ZG_STD_NAME, 8);
            listDataGridView.SetStdControlDomain(AdrCol.Index, ZControlDomain.ZG_STD_NAME, 80);
        }
        #endregion

        #region SetCbSourceForDgvRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetCbSourceForDgvRow
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="rowIdx"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetCbSourceForDgvRow(int rowIdx)
        {
            // Source for hokenjoNm combobox in initialization
            DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)listDataGridView.Rows[rowIdx].Cells[HokenjoNmCol.Name];
            cbCell.DataSource = _hokenjoMst;
            cbCell.DisplayMember = "HokenjoNm";
            cbCell.ValueMember = "HokenjoCd";
        }
        #endregion

        #region SetTextSrhBtnForDgvRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetTextSrhBtnForDgvRow
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetTextSrhBtnForDgvRow(/*int rowIdx*/)
        {
            foreach (DataGridViewRow dgvr in listDataGridView.Rows)
            {
                // Text for button column
                DataGridViewButtonCell cell = (DataGridViewButtonCell)dgvr.Cells[SrhBtnCol.Name];
                cell.Value = "検索";
            }
        }
        #endregion

        #region AddBlankRowToDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddBlankRowToDgv
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void AddBlankRowToDgv(int rowIdx)
        {
            JokasoDaichoMstDataSet.TuckSealListDataTable dgvSource = (JokasoDaichoMstDataSet.TuckSealListDataTable)listDataGridView.DataSource;

            // Add a new row at the bottom of datagridview
            JokasoDaichoMstDataSet.TuckSealListRow newRow = dgvSource.NewTuckSealListRow();
            dgvSource.AddTuckSealListRow(newRow);

            dgvSource.Rows.RemoveAt(rowIdx);
            listDataGridView.CurrentRow.Cells[KbnCol.Name].Value = "1";
            SetTextSrhBtnForDgvRow();
        }
        #endregion

        #endregion
    }
    #endregion
}