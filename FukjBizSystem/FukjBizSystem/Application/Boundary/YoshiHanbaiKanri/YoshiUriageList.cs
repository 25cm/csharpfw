using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.YoshiUriageList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiUriageListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YoshiUriageListForm : FukjBaseForm
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
        /// Today date time
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YoshiUriageListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public YoshiUriageListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region YoshiUriageListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YoshiUriageListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YoshiUriageListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValue();

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
        /// 2014/07/18  DatNT　  新規作成
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
                    this.uriageListPanel,
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValue();
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (dayRadioButton.Checked)
                {
                    if (srhDtFromDateTimePicker.Value > srhDtToDateTimePicker.Value)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。日付の大小関係を確認してください。");
                        return;
                    }
                }
                else
                {
                    if(Convert.ToInt32(srhDtFromDateTimePicker.Value.ToString("yyyyMM")) > Convert.ToInt32(srhDtToDateTimePicker.Value.ToString("yyyyMM")))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。日付の大小関係を確認してください。");
                        return;
                    }
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (uriageListDataGridView.RowCount == 0) { return; }

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "用紙販売ヘッダテーブル一覧";
                Common.Common.FlushGridviewDataToExcel(this.uriageListDataGridView, outputFilename);
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //YoshiMenuForm frm = new YoshiMenuForm();
                //Program.mForm.ShowForm(frm);
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

        #region YoshiUriageListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YoshiUriageListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YoshiUriageListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
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

        #region srhDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： srhDtFromDateTimePicker_ValueChanged
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
        private void srhDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                srhDtToDateTimePicker.Value = srhDtFromDateTimePicker.Value;
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.GroupByDay          = true;
            alInput.YoshiHanbaiDtFrom   = srhDtFromDateTimePicker.Value.ToString("yyyyMMdd");
            alInput.YoshiHanbaiDtTo     = srhDtToDateTimePicker.Value.ToString("yyyyMMdd");
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            if (alOutput.YoshiUriageListDT == null || alOutput.YoshiUriageListDT.Count == 0)
            {
                uriageListCountLabel.Text = "0件";

                outputButton.Enabled = false;
            }
            else
            {
                uriageListCountLabel.Text = alOutput.YoshiUriageListDT.Count.ToString() + "件";
                
                uriageListDataGridView.DataSource = DispYoshiUriageListDT(true, alOutput.YoshiUriageListDT);

                outputButton.Enabled = true;
            }

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.uriageListPanel.Top;
            this._defaultListPanelHeight = this.uriageListPanel.Height;
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            uriageListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            alInput.GroupByDay = dayRadioButton.Checked;

            if (dayRadioButton.Checked)
            {
                alInput.YoshiHanbaiDtFrom = srhDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                alInput.YoshiHanbaiDtTo = srhDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }
            else
            {
                alInput.YoshiHanbaiDtFrom = srhDtFromDateTimePicker.Value.ToString("yyyyMM");
                alInput.YoshiHanbaiDtTo = srhDtToDateTimePicker.Value.ToString("yyyyMM");
            }
            
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.YoshiUriageListDT == null || alOutput.YoshiUriageListDT.Count == 0)
            {
                uriageListCountLabel.Text = "0件";

                outputButton.Enabled = false;

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                uriageListCountLabel.Text = alOutput.YoshiUriageListDT.Count.ToString() + "件";
                
                uriageListDataGridView.DataSource = DispYoshiUriageListDT(dayRadioButton.Checked, alOutput.YoshiUriageListDT);

                outputButton.Enabled = true;
            }
        }
        #endregion

        #region DispYoshiUriageListDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispYoshiUriageListDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupByDay"></param>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiHanbaiHdrTblDataSet.YoshiUriageListDataTable DispYoshiUriageListDT(
            bool groupByDay,
            YoshiHanbaiHdrTblDataSet.YoshiUriageListDataTable dataTable)
        {
            YoshiHanbaiHdrTblDataSet.YoshiUriageListDataTable dispDT = new YoshiHanbaiHdrTblDataSet.YoshiUriageListDataTable();

            foreach (YoshiHanbaiHdrTblDataSet.YoshiUriageListRow row in dataTable)
            {
                if (groupByDay)
                {
                    row.YoshiHanbaiDt = row.YoshiHanbaiDt.Substring(0,4) + "/" + row.YoshiHanbaiDt.Substring(4,2) + "/" + row.YoshiHanbaiDt.Substring(6,2);
                }
                else
                {
                    row.YoshiHanbaiDt = row.YoshiHanbaiDt.Substring(0, 4) + "/" + row.YoshiHanbaiDt.Substring(4, 2);
                }

                dispDT.ImportRow(row);
            }

            return dispDT;
        }
        #endregion

        #region SetDefaultValue
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValue
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValue()
        {
            // 検索種別          =   日別
            dayRadioButton.Checked = true;

            // 日付（開始）      =　当月1日
            srhDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);

            // 日付（終了）      =　当日
            srhDtToDateTimePicker.Value = today;
        }
        #endregion

        #endregion

    }
    #endregion
}
