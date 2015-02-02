using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.GaichuKensaList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaichuKensaListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GaichuKensaListForm : FukjBaseForm
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
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();
        ///// <summary>
        ///// ShishoMstDataTable
        ///// </summary>
        //private ShishoMstDataSet.ShishoMstDataTable _shishoMst = new ShishoMstDataSet.ShishoMstDataTable();
        /// <summary>
        /// GaichuKensaListDataTable
        /// </summary>
        private KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable _gaichuKensaListDataTable = new KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable();
        /// <summary>
        /// Display  Datatable
        /// </summary>
        private KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable _displayTbl = new KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable();
        /// <summary>
        /// Print  Datatable
        /// </summary>
        private KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable _printTbl = new KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GaichuKensaListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GaichuKensaListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region GaichuKensaListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GaichuKensaListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GaichuKensaListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Default value for panel
                this._searchShowFlg = true;
                this._defaultSearchPanelTop = this.searchPanel.Top;
                this._defaultSearchPanelHeight = this.searchPanel.Height;
                this._defaultListPanelTop = this.srhListPanel.Top;
                this._defaultListPanelHeight = this.srhListPanel.Height;
                // 依頼日 (30)
                iraiDtDateTimePicker.Value = today;

                SetDefaultValues();

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
        /// 2014/11/24  ThanhVX　    新規作成
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SetDefaultValues();
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Validator
                if (!ValidateFormValue()) return;
                // Excute search
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

        #region uketsukeDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (uketsukeDtUseCheckBox.Checked)
                {
                    uketsukeDtFromDateTimePicker.Enabled = true;
                    uketsukeDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    uketsukeDtFromDateTimePicker.Enabled = false;
                    uketsukeDtToDateTimePicker.Enabled = false;
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

        #region suikenNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suikenNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suikenNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (suikenNoFromTextBox.Text.Length > 0 && suikenNoFromTextBox.Text.Length < 7)
                {
                    int lenght = suikenNoFromTextBox.Text.Length;
                    for (int i = 0; i < 6 - lenght; i++)
                    {
                        suikenNoFromTextBox.Text = "0" + suikenNoFromTextBox.Text;
                    }
                    suikenNoToTextBox.Text = suikenNoFromTextBox.Text;
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

        #region suikenNoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suikenNoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suikenNoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (suikenNoToTextBox.Text.Length > 0 && suikenNoToTextBox.Text.Length < 7)
                {
                    int lenght = suikenNoToTextBox.Text.Length;
                    for (int i = 0; i < 6 - lenght; i++)
                    {
                        suikenNoToTextBox.Text = "0" + suikenNoToTextBox.Text;
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

        #region printButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： printButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // No data on grid view
                if (gaichuListDataGridView.RowCount <= 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "印刷できるデータがありません。");
                }
                else
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "水質検査委託依頼書を印刷します。よろしいですか？") == DialogResult.Yes)
                    {
                        _printTbl.Clear();

                        foreach (DataGridViewRow row in gaichuListDataGridView.Rows)
                        {
                            if (
                                (row.Cells[daichokinCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[daichokinCol.Name].Value.ToString())
                                    || row.Cells[daichokinCol.Name].Value.ToString() == "0")
                                && (row.Cells[codCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[codCol.Name].Value.ToString())
                                    || row.Cells[codCol.Name].Value.ToString() == "0")
                                && (row.Cells[tnCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[tnCol.Name].Value.ToString())
                                    || row.Cells[tnCol.Name].Value.ToString() == "0")
                                && (row.Cells[tpCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[tpCol.Name].Value.ToString())
                                    || row.Cells[tpCol.Name].Value.ToString() == "0")
                                && (row.Cells[yubunCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[yubunCol.Name].Value.ToString())
                                    || row.Cells[yubunCol.Name].Value.ToString() == "0")
                                && (row.Cells[yubunKouCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[yubunKouCol.Name].Value.ToString())
                                    || row.Cells[yubunKouCol.Name].Value.ToString() == "0")
                                && (row.Cells[yubunDouCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[yubunDouCol.Name].Value.ToString())
                                    || row.Cells[yubunDouCol.Name].Value.ToString() == "0")
                                && (row.Cells[znCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[znCol.Name].Value.ToString())
                                    || row.Cells[znCol.Name].Value.ToString() == "0")
                                && (row.Cells[pbCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[pbCol.Name].Value.ToString())
                                    || row.Cells[pbCol.Name].Value.ToString() == "0")
                                && (row.Cells[fCol.Name].Value == null
                                    || string.IsNullOrEmpty(row.Cells[fCol.Name].Value.ToString())
                                    || row.Cells[fCol.Name].Value.ToString() == "0")
                                )
                            {
                            }
                            else
                            {
                                KeiryoShomeiIraiTblDataSet.GaichuKensaListRow printRow = (KeiryoShomeiIraiTblDataSet.GaichuKensaListRow)((DataRowView)row.DataBoundItem).Row;
                                _printTbl.ImportRow(printRow);
                            }
                        }


                        //DataTable dataTbl = new DataTable();
                        //dataTbl = (DataTable)gaichuListDataGridView.DataSource;
                        //_printTbl.Merge(dataTbl);


                        IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                        alInput.GaichuKensaListDataTable = _printTbl;
                        // for test print function                        
                        alInput.GaichuKensaListDataTable = _printTbl;
                        alInput.IraiDt = iraiDtDateTimePicker.Value;
                        alInput.ShishoNm = shishoComboBox.Text;
                        new PrintBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2014/12/17 AnhNV hot fixed
                //this.Close();
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

        #region GaichuKensaListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GaichuKensaListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GaichuKensaListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodBase.GetCurrentMethod());
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
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodBase.GetCurrentMethod());
                Cursor.Current = preCursor;
            }
        }
        #endregion

        #region uketsukeDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　PhuongDT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                uketsukeDtToDateTimePicker.Value = uketsukeDtFromDateTimePicker.Value;
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

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： DoSearch
        /// <summary>
        /// Excute search
        /// </summary>        
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            SetSearchCondition(ref alInput);
            _gaichuKensaListDataTable = new KensakuBtnClickApplicationLogic().Execute(alInput).GaichuKensaListDataTable;
            // Setting grid view
            gaichuListDataGridView.AutoGenerateColumns = false;
            gaichuListDataGridView.DataSource = null;            
            
            // No data was found
            if (_gaichuKensaListDataTable.Count <= 0)
            {
                srhListCountLabel.Text = gaichuListDataGridView.RowCount + "件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                _displayTbl.Clear();
                string keiryoShomeiIraiNendo = String.Empty;
                string keiryoShomeiIraiSishoCd = String.Empty;
                string keiryoShomeiIraiRenban = String.Empty;
                int index = -1;
                KeiryoShomeiIraiTblDataSet.GaichuKensaListRow importRow = _displayTbl.NewGaichuKensaListRow();
                foreach (KeiryoShomeiIraiTblDataSet.GaichuKensaListRow row in _gaichuKensaListDataTable)
                {
                    if (keiryoShomeiIraiNendo != row.KeiryoShomeiIraiNendo ||
                        keiryoShomeiIraiSishoCd != row.KeiryoShomeiIraiSishoCd ||
                        keiryoShomeiIraiRenban != row.KeiryoShomeiIraiRenban)
                    {                        
                        _displayTbl.ImportRow(row);
                        index++;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(row.daichokinCol))
                            _displayTbl[index].daichokinCol = row.daichokinCol;
                        if (!String.IsNullOrEmpty(row.codCol))
                            _displayTbl[index].codCol = row.codCol;
                        if (!String.IsNullOrEmpty(row.tnCol))
                            _displayTbl[index].tnCol = row.tnCol;
                        if (!String.IsNullOrEmpty(row.tpCol))
                            _displayTbl[index].tpCol = row.tpCol;
                        if (!String.IsNullOrEmpty(row.yubunCol))
                            _displayTbl[index].yubunCol = row.yubunCol;
                        if (!String.IsNullOrEmpty(row.yubunKouCol))
                            _displayTbl[index].yubunKouCol = row.yubunKouCol;
                        if (!String.IsNullOrEmpty(row.yubunDouCol))
                            _displayTbl[index].yubunDouCol = row.yubunDouCol;
                        if (!String.IsNullOrEmpty(row.mbasCol))
                            _displayTbl[index].mbasCol = row.mbasCol;
                        if (!String.IsNullOrEmpty(row.znCol))
                            _displayTbl[index].znCol = row.znCol;
                        if (!String.IsNullOrEmpty(row.pbCol))
                            _displayTbl[index].pbCol = row.pbCol;
                        if (!String.IsNullOrEmpty(row.fCol))
                            _displayTbl[index].fCol = row.fCol;                        
                    }

                    keiryoShomeiIraiNendo = row.KeiryoShomeiIraiNendo;
                    keiryoShomeiIraiSishoCd = row.KeiryoShomeiIraiSishoCd;
                    keiryoShomeiIraiRenban = row.KeiryoShomeiIraiRenban;
                }                
                gaichuListDataGridView.DataSource = _displayTbl;
               
                // Setting property column grid view
                for (int i = 0; i < gaichuListDataGridView.RowCount; i++)
                {
                    for (int j = 6; j < gaichuListDataGridView.Columns.Count; j++)
                    {                        
                        if (!gaichuListDataGridView.Rows[i].Cells[j].Value.Equals("1"))
                        {
                            DataGridViewTextBoxCell dgvc = new DataGridViewTextBoxCell();
                            dgvc.Value = String.Empty;
                            gaichuListDataGridView.Rows[i].Cells[j] = dgvc;
                            // 2014/12/17 AnhNV hot fix
                            gaichuListDataGridView.Rows[i].Cells[j].ReadOnly = true;
                            // 2014/12/17 end
                        }
                        else
                        {
                            gaichuListDataGridView.Rows[i].Cells[j].ReadOnly = false;
                        }
                    }
                }
                srhListCountLabel.Text = gaichuListDataGridView.RowCount + "件";
            }
        }
        #endregion

        #region ValidateFormValue
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： ValidateFormValue
        /// <summary>
        /// Validate data on form
        /// </summary>        
        /// <history>
        /// <returns>False is error otherwise True</returns>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool ValidateFormValue()
        {
            StringBuilder errMsg = new StringBuilder();

            // 水検No（開始＆終了）
            if (!String.IsNullOrEmpty(suikenNoFromTextBox.Text) && !String.IsNullOrEmpty(suikenNoToTextBox.Text))
            {
                if (Int32.Parse(suikenNoFromTextBox.Text) > Int32.Parse(suikenNoToTextBox.Text))
                {
                    errMsg.Append("範囲指定が正しくありません。水検Noの大小関係を確認してください。\r\n");
                }
            }
            // 受付日（開始＆終了）
            if (uketsukeDtUseCheckBox.Checked)
            {
                if (uketsukeDtFromDateTimePicker.Value > uketsukeDtToDateTimePicker.Value)
                {
                    errMsg.Append("範囲指定が正しくありません。受付日の大小関係を確認してください。\r\n");
                }
            }
            // 支所
            if (String.IsNullOrEmpty(shishoComboBox.Text))
            {
                errMsg.Append("支所を選択してください。\r\n");
            }
            // 年度
            if (String.IsNullOrEmpty(nendoTextBox.Text))
            {
                errMsg.Append("年度を入力してください。\r\n");
            }
            if (!String.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }
            return true;
        }
        #endregion

        #region SetSearchCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetSearchCondition
        /// <summary>
        /// Set value to input
        /// </summary>        
        /// <history>
        /// <paramref name="input"/>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSearchCondition(ref IKensakuBtnClickALInput input)
        {
            // 支所
            input.ShishoCd = shishoComboBox.SelectedValue.ToString();
            // 年度
            input.Nendo = nendoTextBox.Text;
            // 水検No (開始)
            input.SuikenNoFrom = !String.IsNullOrEmpty(suikenNoFromTextBox.Text) ? suikenNoFromTextBox.Text : String.Empty;
            // 水検No (終了)
            input.SuikenNoTo = !String.IsNullOrEmpty(suikenNoToTextBox.Text) ? suikenNoToTextBox.Text : String.Empty;
            if (uketsukeDtUseCheckBox.Checked)
            {
                input.UketsukeDtFrom = uketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                input.UketsukeDtTo = uketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }
            else
            {
                input.UketsukeDtFrom = String.Empty;
                input.UketsukeDtTo = String.Empty;
            }
        }
        #endregion

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetDefaultValues
        /// <summary>
        /// Set default value to form
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 支所 (1)
            shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 年度 (2)
            int nendo = Utility.DateUtility.GetNendo(Boundary.Common.Common.GetCurrentTimestamp());
            nendoTextBox.Text = nendo.ToString();
            // 水検No (開始) (3)
            suikenNoFromTextBox.Clear();
            // 水検No (終了) (4)
            suikenNoToTextBox.Clear();
            // 受付日検索使用フラグ (5)
            uketsukeDtUseCheckBox.Checked = false;
            // 受付日（開始）(6)
            uketsukeDtFromDateTimePicker.Value = today;
            // 受付日（終了）(7)
            uketsukeDtToDateTimePicker.Value = today;
        }
        #endregion

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： DoFormLoad
        /// <summary>
        /// Excute form load
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            SetControlDomain();
            // Default value for data grid view
            _gaichuKensaListDataTable.Clear();
            gaichuListDataGridView.AutoGenerateColumns = false;
            gaichuListDataGridView.DataSource = _gaichuKensaListDataTable;

            IFormLoadALInput alInput = new FormLoadALInput();
            //20150128 HuyTX Mod 課題対応 No279 支所コンボから事務局除外対応
            //_shishoMst = new FormLoadApplicationLogic().Execute(alInput).ShishoMstDataTable;
            //if (_shishoMst.Count > 0) Utility.Utility.SetComboBoxList(shishoComboBox, _shishoMst, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shishoComboBox, 
                                            new FormLoadApplicationLogic().Execute(alInput).ShishoMstExceptJimukyokuDataTable, 
                                            "ShishoNm", 
                                            "ShishoCd", 
                                            true);
            //End
            shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 年度
            nendoTextBox.SetControlDomain(ZControlDomain.ZT_NENDO);
            // 水検No (開始)
            suikenNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            // 水検No (終了)
            suikenNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // 2014/12/17 AnhNV EDIT Start
            // 年度(13)
            gaichuListDataGridView.SetStdControlDomain(nendoCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            // 支所(14)
            gaichuListDataGridView.SetStdControlDomain(shishoNmCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            // 水検No(15)
            gaichuListDataGridView.SetStdControlDomain(suikenNoCol.Index, ZControlDomain.ZG_STD_NUM, 6);
            // 受付日(16)
            gaichuListDataGridView.SetStdControlDomain(yoteiDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            // 浄化槽番号(17)
            gaichuListDataGridView.SetStdControlDomain(jokasoNoCol.Index, ZControlDomain.ZG_STD_NAME, 11);
            // 設置者名(18)
            gaichuListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            // 2014/12/17 AnhNV EDIT End
        }
        #endregion

        #endregion
    }
    #endregion
}
