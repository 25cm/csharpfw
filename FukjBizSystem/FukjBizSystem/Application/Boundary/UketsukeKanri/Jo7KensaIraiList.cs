using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.Jo7KensaIraiList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Jo7KensaIraiListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class Jo7KensaIraiListForm : FukjBaseForm
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
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// jo7KensaIraiListDataTable
        /// </summary>
        private KensaIraiTblDataSet.Jo7KensaIraiListDataTable _jo7KensaIraiListDataTable = new KensaIraiTblDataSet.Jo7KensaIraiListDataTable();

        /// <summary>
        /// kensaIraiDtJokenTuikaFlg 
        /// </summary>
        private bool _kensaIraiDtJokenTuikaFlg = true;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Jo7KensaIraiListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Jo7KensaIraiListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region Jo7KensaIraiListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Jo7KensaIraiListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Jo7KensaIraiListForm_Load(object sender, EventArgs e)
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
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
                    this.kensaIraiListPanel,
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

        #region kensaIraiDtJokenTuikaFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiDtJokenTuikaFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaIraiDtJokenTuikaFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaIraiDtFromDateTimePicker.Enabled = kensaIraiDtJokenTuikaFlgCheckBox.Checked;
                kensaIraiDtToDateTimePicker.Enabled = kensaIraiDtJokenTuikaFlgCheckBox.Checked;

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
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultDisplayControl();
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
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidInput()) return;

                DoSearch();

                _kensaIraiDtJokenTuikaFlg = kensaIraiDtJokenTuikaFlgCheckBox.Checked;

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

        #region selectAllButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： selectAllButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void selectAllButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in kensaIraiListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[selectFlgCol.Name];
                    chk.Value = chk.TrueValue;
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

        #region clearSelectButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearSelectButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearSelectButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in kensaIraiListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[selectFlgCol.Name];
                    chk.Value = chk.FalseValue;
                }

                kensaIraiListDataGridView.EndEdit();
                kensaIraiListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

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

        #region hagakiPrintButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hagakiPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hagakiPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsSelectedRowKensaIraiListDgv())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "使用開始はがきを出力します。よろしいですか？") != DialogResult.Yes) return;

                IHagakiPrintBtnClickALInput alInput = new HagakiPrintBtnClickALInput();
                _jo7KensaIraiListDataTable = GetDataTableFromDgv();
                alInput.Jo7KensaIraiListDataTable = _jo7KensaIraiListDataTable;

                new HagakiPrintBtnClickApplicationLogic().Execute(alInput);

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

        #region hosyuListPrintButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hosyuListPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hosyuListPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsSelectedRowKensaIraiListDgv())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "保守点検予定一覧を出力します。よろしいですか？") != DialogResult.Yes) return;

                IHosyuListPrintBtnClickALInput alInput = new HosyuListPrintBtnClickALInput();
                _jo7KensaIraiListDataTable = GetDataTableFromDgv();
                alInput.Jo7KensaIraiListDataTable = _jo7KensaIraiListDataTable;
                alInput.KensaIraiDtFrom = kensaIraiDtFromDateTimePicker.Value;
                alInput.KensaIraiDtTo = kensaIraiDtToDateTimePicker.Value;
                alInput.KensaIraiDtJokenTuikaFlg = _kensaIraiDtJokenTuikaFlg;

                new HosyuListPrintBtnClickApplicationLogic().Execute(alInput);
                
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

        #region sofubiTorokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sofubiTorokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void sofubiTorokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsSelectedRowKensaIraiListDgv())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                _jo7KensaIraiListDataTable = GetDataTableFromDgv();

                SofuDtInputForm frm = new SofuDtInputForm(_jo7KensaIraiListDataTable);
                frm.ShowDialog();

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
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaIraiListDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "7条検査依頼一覧";
                Common.Common.FlushGridviewDataToExcel(kensaIraiListDataGridView, outputFilename);

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
        /// 2014/09/04　HuyTX    新規作成
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

        #region Jo7KensaIraiListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Jo7KensaIraiListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Jo7KensaIraiListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F3:
                        hagakiPrintButton.PerformClick();
                        break;

                    case Keys.F4:
                        hosyuListPrintButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.PerformClick();
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

        #region kensaIraiDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiDtFromDateTimePicker_ValueChanged
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
        private void kensaIraiDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaIraiDtToDateTimePicker.Value = kensaIraiDtFromDateTimePicker.Value;
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
        /// 2014/09/05　HuyTX    新規作成
        /// 2014/12/23  小松     DataSet再作成に伴い、選択が読取列となっていた。（選択可能にコードで設定するように修正）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.kensaIraiListPanel.Top;
            this._defaultListPanelHeight = this.kensaIraiListPanel.Height;

            SetDefaultDisplayControl();

            string kensaIraiDtFrom = kensaIraiDtFromDateTimePicker.Value.ToString("yyyyMMdd");
            string kensaIraiDtTo = kensaIraiDtToDateTimePicker.Value.ToString("yyyyMMdd");

            IFormLoadALInput alInput = new FormLoadALInput();

            alInput.KensaIraiDtFrom= kensaIraiDtFrom;
            alInput.KensaIraiDtTo = kensaIraiDtTo;
            //alInput.IsCheckKensaIraiSofuDt = kensaIraiSofuDtTuikaFlgCheckBox.Checked;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            //_jo7KensaIraiListDataTable = GetJo7KensaIraiList(alOutput.Jo7KensaIraiListDataTable);
            _jo7KensaIraiListDataTable = alOutput.Jo7KensaIraiListDataTable;

            //検索結果件数
            kensaIraiListCountLabel.Text = _jo7KensaIraiListDataTable.Count + "件";

            // 選択フラグを使用可能にセット
            _jo7KensaIraiListDataTable.Columns[selectFlgCol.Index].ReadOnly = false;
            kensaIraiTblDataSet.Jo7KensaIraiList.SelectFlgColumn.ReadOnly = false;
            kensaIraiListDataGridView.Columns[selectFlgCol.Index].ReadOnly = false;

            //set data for display gridview
            kensaIraiListDataGridView.DataSource = _jo7KensaIraiListDataTable;

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
        /// 2014/09/05　HuyTX    新規作成
        /// 2014/10/31　HuyTX    Ver1.05
        /// 2014/12/23  小松     DataSet再作成に伴い、選択が読取列となっていた。（選択可能にコードで設定するように修正）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            kensaIraiListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            if (kensaIraiDtJokenTuikaFlgCheckBox.Checked)
            {
                alInput.KensaIraiDtFrom = kensaIraiDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                alInput.KensaIraiDtTo = kensaIraiDtToDateTimePicker.Value.ToString("yyyyMMdd");   
            }

            //alInput.IsCheckKensaIraiSofuDt = kensaIraiSofuDtTuikaFlgCheckBox.Checked;

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);
            //_jo7KensaIraiListDataTable = GetJo7KensaIraiList(alOutput.Jo7KensaIraiListDataTable);
            _jo7KensaIraiListDataTable = alOutput.Jo7KensaIraiListDataTable;

            kensaIraiListCountLabel.Text = _jo7KensaIraiListDataTable.Count + "件";

            if (alOutput.Jo7KensaIraiListDataTable.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 選択フラグを使用可能にセット
            _jo7KensaIraiListDataTable.Columns[selectFlgCol.Index].ReadOnly = false;
            kensaIraiTblDataSet.Jo7KensaIraiList.SelectFlgColumn.ReadOnly = false;
            kensaIraiListDataGridView.Columns[selectFlgCol.Index].ReadOnly = false;

            //set data for display gridview
            kensaIraiListDataGridView.DataSource = _jo7KensaIraiListDataTable;

        }
        #endregion

        #region IsValidInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidInput()
        {
            string errMsg = string.Empty;

            int kensaIraiDtFrom = Convert.ToInt32(kensaIraiDtFromDateTimePicker.Value.ToString("yyyyMMdd"));
            int kensaIraiDtTo = Convert.ToInt32(kensaIraiDtToDateTimePicker.Value.ToString("yyyyMMdd"));

            if (kensaIraiDtJokenTuikaFlgCheckBox.Checked && kensaIraiDtFrom > kensaIraiDtTo)
            {
                errMsg += "範囲指定が正しくありません。依頼受付日の大小関係を確認してください。";
            }
            
            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg);
                return false;
            }

            return true;
        }
        #endregion

        #region SetDefaultDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultDisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultDisplayControl()
        {
            int daysInMonth = DateTime.DaysInMonth(_currentDateTime.Year, _currentDateTime.Month);

            kensaIraiDtJokenTuikaFlgCheckBox.Checked = true;
            kensaIraiDtFromDateTimePicker.Value = new DateTime(_currentDateTime.Year, _currentDateTime.Month, 1);
            kensaIraiDtToDateTimePicker.Value = new DateTime(_currentDateTime.Year, _currentDateTime.Month, daysInMonth);
            //kensaIraiSofuDtTuikaFlgCheckBox.Checked = false;
        }
        #endregion

        #region IsSelectedRowKensaIraiListDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsSelectedRowKensaIraiListDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsSelectedRowKensaIraiListDgv()
        {
            bool isSelected = false;

            foreach (DataGridViewRow row in kensaIraiListDataGridView.Rows)
            {
                if (row.Cells[selectFlgCol.Name].Value != null && row.Cells[selectFlgCol.Name].Value.ToString() == "1")
                {
                    isSelected = true;
                    break;
                }
            }

            return isSelected;
        }
        #endregion

        #region GetDataTableFromDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDataTableFromDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.Jo7KensaIraiListDataTable GetDataTableFromDgv()
        {
            KensaIraiTblDataSet.Jo7KensaIraiListDataTable table = new KensaIraiTblDataSet.Jo7KensaIraiListDataTable();

            foreach (DataGridViewRow row in kensaIraiListDataGridView.Rows)
            {
                if (row.Cells[selectFlgCol.Name].Value != null && row.Cells[selectFlgCol.Name].Value.ToString() == "1")
                {
                    KensaIraiTblDataSet.Jo7KensaIraiListRow dr = (KensaIraiTblDataSet.Jo7KensaIraiListRow)(row.DataBoundItem as DataRowView).Row;

                    table.ImportRow(dr);
                }
            }

            return table;
        }
        #endregion

        #region DEL_20141118
        //#region GetJo7KensaIraiList
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： GetJo7KensaIraiList
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="jo7KensaIraiListDT"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/17　HuyTX    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaIraiTblDataSet.Jo7KensaIraiListDataTable GetJo7KensaIraiList(KensaIraiTblDataSet.Jo7KensaIraiListDataTable jo7KensaIraiListDT)
        //{
        //    foreach (KensaIraiTblDataSet.Jo7KensaIraiListRow row in jo7KensaIraiListDT.Rows)
        //    {
        //        row.KyokaiNo = string.Concat(row.KensaIraiHokenjoCd, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy"), "-", row.KensaIraiRenban);
        //        row.HokenjyoUketukeNo = string.Concat(row.KensaIraiHokenjoJyuriHokenjoCd, "-", 
        //                                            Utility.DateUtility.ConvertToWareki(row.KensaIraiHokenjoJyuriNendo, "yy"), "-", 
        //                                            row.KensaIraiHokenjoJyuriShichosonCd, "-", row.KensaIraiHokenjoJyuriRenban);
        //    }

        //    return jo7KensaIraiListDT;
        //}
        //#endregion
        #endregion

        #endregion

    }

    #endregion
}
