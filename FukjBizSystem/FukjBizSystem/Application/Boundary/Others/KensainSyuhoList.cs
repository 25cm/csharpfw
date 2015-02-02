using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.KensainSyuhoList;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensainSyuhoListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/14  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensainSyuhoListForm : FukjBaseForm
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
        /// DateTime Today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        private string day1 = string.Empty;
        private string day2 = string.Empty;
        private string day3 = string.Empty;
        private string day4 = string.Empty;
        private string day5 = string.Empty;
        private string day6 = string.Empty;

        /// <summary>
        /// weekList
        /// </summary>
        private List<string> _weekList = new List<string>();

        /// <summary>
        /// kensainSyuhoListDT
        /// </summary>
        private KensainSyuhoListDataSet.KensainSyuhoListDataTable _kensainSyuhoListDT = new KensainSyuhoListDataSet.KensainSyuhoListDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensainSyuhoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensainSyuhoListForm()
        {
            InitializeComponent();
            syuhoListDataGridView.DefaultCellStyle.Font = new Font(syuhoListDataGridView.Font.Name, 9);
            syuhoListDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(syuhoListDataGridView.Font.Name, 9);
            syuhoListDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        #endregion

        #region イベント

        #region KensainSyuhoListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensainSyuhoListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensainSyuhoListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetStdControlDomain();

                SetDefaultValues();

                SetWeekText();

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
        /// 2014/08/14  DatNT　  新規作成
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
                    this.syuhoListPanel,
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
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14  DatNT　  新規作成
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
        /// 2014/08/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetWeekText();
                
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
        /// 2014/08/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査員別検査実施数一覧を印刷します。よろしいですか？") != DialogResult.Yes) return;
                
                SetWeekList();

                IOutputBtnClickALInput alInput = new OutputBtnClickALInput();
                alInput.KensainSyuhoListDT = _kensainSyuhoListDT;
                alInput.WeekList = _weekList;
                new OutputBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/08/14  DatNT　  新規作成
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

        #region KensainSyuhoListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensainSyuhoListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensainSyuhoListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
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
        /// 2014/08/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            //List<string> listDay = new List<string>();

            //listDay.Add(day1);
            //listDay.Add(day2);
            //listDay.Add(day3);
            //listDay.Add(day4);
            //listDay.Add(day5);
            //listDay.Add(day6);

            //IFormLoadALInput alInput = new FormLoadALInput();

            //alInput.ListDateStr = listDay;

            //IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //if (alOutput.KensainSyuhoListDT != null && alOutput.KensainSyuhoListDT.Count > 0)
            //{
            //    syuhoListDataGridView.DataSource = alOutput.KensainSyuhoListDT;
            //    _kensainSyuhoListDT = alOutput.KensainSyuhoListDT;

            //    outputButton.Enabled = true;
            //}
            //else 
            //{
                outputButton.Enabled = false;
            //}

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.syuhoListPanel.Top;
            this._defaultListPanelHeight = this.syuhoListPanel.Height;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clickBtnSearch"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            syuhoListDataGridView.DataSource = null;

            List<string> listDay = new List<string>();

            listDay.Add(day1);
            listDay.Add(day2);
            listDay.Add(day3);
            listDay.Add(day4);
            listDay.Add(day5);
            listDay.Add(day6);

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            alInput.ListDateStr = listDay;

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.KensainSyuhoListDT != null && alOutput.KensainSyuhoListDT.Count > 0)
            {
                syuhoListDataGridView.DataSource = alOutput.KensainSyuhoListDT;
                _kensainSyuhoListDT = alOutput.KensainSyuhoListDT;

                outputButton.Enabled = true;
            }
            else
            {
                outputButton.Enabled = false;

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力できるデータがありません。");
            }
        }
        #endregion
        
        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // ｛週報出力日｝ ＝ 当日
            syuhoDtDateTimePicker.Value = today;
        }
        #endregion

        #region SetWeekText
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetWeekText
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetWeekText()
        {
            DateTime today = syuhoDtDateTimePicker.Value;

            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:

                    week1TextBox.Text = ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + "/" + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString()) + " 月曜";
                    week2TextBox.Text = ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + "/" + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString()) + " 火曜";
                    week3TextBox.Text = ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + "/" + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString()) + " 水曜";
                    week4TextBox.Text = ((today.AddDays(3).Month < 10) ? ("0" + today.AddDays(3).Month) : today.AddDays(3).Month.ToString()) + "/" + ((today.AddDays(3).Day < 10) ? ("0" + today.AddDays(3).Day) : today.AddDays(3).Day.ToString()) + " 木曜";
                    week5TextBox.Text = ((today.AddDays(4).Month < 10) ? ("0" + today.AddDays(4).Month) : today.AddDays(4).Month.ToString()) + "/" + ((today.AddDays(4).Day < 10) ? ("0" + today.AddDays(4).Day) : today.AddDays(4).Day.ToString()) + " 金曜";
                    week6TextBox.Text = ((today.AddDays(5).Month < 10) ? ("0" + today.AddDays(5).Month) : today.AddDays(5).Month.ToString()) + "/" + ((today.AddDays(5).Day < 10) ? ("0" + today.AddDays(5).Day) : today.AddDays(5).Day.ToString()) + " 土曜";

                    day1 = today.Year + ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString());
                    day2 = today.AddDays(1).Year + ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString());
                    day3 = today.AddDays(2).Year + ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString());
                    day4 = today.AddDays(3).Year + ((today.AddDays(3).Month < 10) ? ("0" + today.AddDays(3).Month) : today.AddDays(3).Month.ToString()) + ((today.AddDays(3).Day < 10) ? ("0" + today.AddDays(3).Day) : today.AddDays(3).Day.ToString());
                    day5 = today.AddDays(4).Year + ((today.AddDays(4).Month < 10) ? ("0" + today.AddDays(4).Month) : today.AddDays(4).Month.ToString()) + ((today.AddDays(4).Day < 10) ? ("0" + today.AddDays(4).Day) : today.AddDays(4).Day.ToString());
                    day6 = today.AddDays(5).Year + ((today.AddDays(5).Month < 10) ? ("0" + today.AddDays(5).Month) : today.AddDays(5).Month.ToString()) + ((today.AddDays(5).Day < 10) ? ("0" + today.AddDays(5).Day) : today.AddDays(5).Day.ToString());

                    break;

                case DayOfWeek.Tuesday:

                    week1TextBox.Text = ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + "/" + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString()) + " 月曜";
                    week2TextBox.Text = ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + "/" + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString()) + " 火曜";
                    week3TextBox.Text = ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + "/" + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString()) + " 水曜";
                    week4TextBox.Text = ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + "/" + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString()) + " 木曜";
                    week5TextBox.Text = ((today.AddDays(3).Month < 10) ? ("0" + today.AddDays(3).Month) : today.AddDays(3).Month.ToString()) + "/" + ((today.AddDays(3).Day < 10) ? ("0" + today.AddDays(3).Day) : today.AddDays(3).Day.ToString()) + " 金曜";
                    week6TextBox.Text = ((today.AddDays(4).Month < 10) ? ("0" + today.AddDays(4).Month) : today.AddDays(4).Month.ToString()) + "/" + ((today.AddDays(4).Day < 10) ? ("0" + today.AddDays(4).Day) : today.AddDays(4).Day.ToString()) + " 土曜";

                    day1 = today.AddDays(-1).Year + ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString());
                    day2 = today.Year + ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString());
                    day3 = today.AddDays(1).Year + ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString());
                    day4 = today.AddDays(2).Year + ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString());
                    day5 = today.AddDays(3).Year + ((today.AddDays(3).Month < 10) ? ("0" + today.AddDays(3).Month) : today.AddDays(3).Month.ToString()) + ((today.AddDays(3).Day < 10) ? ("0" + today.AddDays(3).Day) : today.AddDays(3).Day.ToString());
                    day6 = today.AddDays(4).Year + ((today.AddDays(4).Month < 10) ? ("0" + today.AddDays(4).Month) : today.AddDays(4).Month.ToString()) + ((today.AddDays(4).Day < 10) ? ("0" + today.AddDays(4).Day) : today.AddDays(4).Day.ToString());

                    break;

                case DayOfWeek.Wednesday:

                    week1TextBox.Text = ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + "/" + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString()) + " 月曜";
                    week2TextBox.Text = ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + "/" + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString()) + " 火曜";
                    week3TextBox.Text = ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + "/" + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString()) + " 水曜";
                    week4TextBox.Text = ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + "/" + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString()) + " 木曜";
                    week5TextBox.Text = ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + "/" + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString()) + " 金曜";
                    week6TextBox.Text = ((today.AddDays(3).Month < 10) ? ("0" + today.AddDays(3).Month) : today.AddDays(3).Month.ToString()) + "/" + ((today.AddDays(3).Day < 10) ? ("0" + today.AddDays(3).Day) : today.AddDays(3).Day.ToString()) + " 土曜";

                    day1 = today.AddDays(-2).Year + ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString());
                    day2 = today.AddDays(-1).Year + ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString());
                    day3 = today.Year + ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString());
                    day4 = today.AddDays(1).Year + ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString());
                    day5 = today.AddDays(2).Year + ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString());
                    day6 = today.AddDays(3).Year + ((today.AddDays(3).Month < 10) ? ("0" + today.AddDays(3).Month) : today.AddDays(3).Month.ToString()) + ((today.AddDays(3).Day < 10) ? ("0" + today.AddDays(3).Day) : today.AddDays(3).Day.ToString());

                    break;

                case DayOfWeek.Thursday:

                    week1TextBox.Text = ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + "/" + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString()) + " 月曜";
                    week2TextBox.Text = ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + "/" + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString()) + " 火曜";
                    week3TextBox.Text = ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + "/" + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString()) + " 水曜";
                    week4TextBox.Text = ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + "/" + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString()) + " 木曜";
                    week5TextBox.Text = ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + "/" + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString()) + " 金曜";
                    week6TextBox.Text = ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + "/" + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString()) + " 土曜";

                    day1 = today.AddDays(-3).Year + ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString());
                    day2 = today.AddDays(-2).Year + ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString());
                    day3 = today.AddDays(-1).Year + ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString());
                    day4 = today.Year + ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString());
                    day5 = today.AddDays(1).Year + ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString());
                    day6 = today.AddDays(2).Year + ((today.AddDays(2).Month < 10) ? ("0" + today.AddDays(2).Month) : today.AddDays(2).Month.ToString()) + ((today.AddDays(2).Day < 10) ? ("0" + today.AddDays(2).Day) : today.AddDays(2).Day.ToString());

                    break;

                case DayOfWeek.Friday:

                    week1TextBox.Text = ((today.AddDays(-4).Month < 10) ? ("0" + today.AddDays(-4).Month) : today.AddDays(-4).Month.ToString()) + "/" + ((today.AddDays(-4).Day < 10) ? ("0" + today.AddDays(-4).Day) : today.AddDays(-4).Day.ToString()) + " 月曜";
                    week2TextBox.Text = ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + "/" + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString()) + " 火曜";
                    week3TextBox.Text = ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + "/" + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString()) + " 水曜";
                    week4TextBox.Text = ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + "/" + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString()) + " 木曜";
                    week5TextBox.Text = ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + "/" + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString()) + " 金曜";
                    week6TextBox.Text = ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + "/" + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString()) + " 土曜";

                    day1 = today.AddDays(-4).Year + ((today.AddDays(-4).Month < 10) ? ("0" + today.AddDays(-4).Month) : today.AddDays(-4).Month.ToString()) + ((today.AddDays(-4).Day < 10) ? ("0" + today.AddDays(-4).Day) : today.AddDays(-4).Day.ToString());
                    day2 = today.AddDays(-3).Year + ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString());
                    day3 = today.AddDays(-2).Year + ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString());
                    day4 = today.AddDays(-1).Year + ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString());
                    day5 = today.Year + ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString());
                    day6 = today.AddDays(1).Year + ((today.AddDays(1).Month < 10) ? ("0" + today.AddDays(1).Month) : today.AddDays(1).Month.ToString()) + ((today.AddDays(1).Day < 10) ? ("0" + today.AddDays(1).Day) : today.AddDays(1).Day.ToString());

                    break;

                case DayOfWeek.Saturday:

                    week1TextBox.Text = ((today.AddDays(-5).Month < 10) ? ("0" + today.AddDays(-5).Month) : today.AddDays(-5).Month.ToString()) + "/" + ((today.AddDays(-5).Day < 10) ? ("0" + today.AddDays(-5).Day) : today.AddDays(-5).Day.ToString()) + " 月曜";
                    week2TextBox.Text = ((today.AddDays(-4).Month < 10) ? ("0" + today.AddDays(-4).Month) : today.AddDays(-4).Month.ToString()) + "/" + ((today.AddDays(-4).Day < 10) ? ("0" + today.AddDays(-4).Day) : today.AddDays(-4).Day.ToString()) + " 火曜";
                    week3TextBox.Text = ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + "/" + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString()) + " 水曜";
                    week4TextBox.Text = ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + "/" + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString()) + " 木曜";
                    week5TextBox.Text = ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + "/" + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString()) + " 金曜";
                    week6TextBox.Text = ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + "/" + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString()) + " 土曜";

                    day1 = today.AddDays(-5).Year + ((today.AddDays(-5).Month < 10) ? ("0" + today.AddDays(-5).Month) : today.AddDays(-5).Month.ToString()) + ((today.AddDays(-5).Day < 10) ? ("0" + today.AddDays(-5).Day) : today.AddDays(-5).Day.ToString());
                    day2 = today.AddDays(-4).Year + ((today.AddDays(-4).Month < 10) ? ("0" + today.AddDays(-4).Month) : today.AddDays(-4).Month.ToString()) + ((today.AddDays(-4).Day < 10) ? ("0" + today.AddDays(-4).Day) : today.AddDays(-4).Day.ToString());
                    day3 = today.AddDays(-3).Year + ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString());
                    day4 = today.AddDays(-2).Year + ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString());
                    day5 = today.AddDays(-1).Year + ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString());
                    day6 = today.Year + ((today.Month < 10) ? ("0" + today.Month) : today.Month.ToString()) + ((today.Day < 10) ? ("0" + today.Day) : today.Day.ToString());

                    break;

                case DayOfWeek.Sunday:

                    week1TextBox.Text = ((today.AddDays(-6).Month < 10) ? ("0" + today.AddDays(-6).Month) : today.AddDays(-6).Month.ToString()) + "/" + ((today.AddDays(-6).Day < 10) ? ("0" + today.AddDays(-6).Day) : today.AddDays(-6).Day.ToString()) + " 月曜";
                    week2TextBox.Text = ((today.AddDays(-5).Month < 10) ? ("0" + today.AddDays(-5).Month) : today.AddDays(-5).Month.ToString()) + "/" + ((today.AddDays(-5).Day < 10) ? ("0" + today.AddDays(-5).Day) : today.AddDays(-5).Day.ToString()) + " 火曜";
                    week3TextBox.Text = ((today.AddDays(-4).Month < 10) ? ("0" + today.AddDays(-4).Month) : today.AddDays(-4).Month.ToString()) + "/" + ((today.AddDays(-4).Day < 10) ? ("0" + today.AddDays(-4).Day) : today.AddDays(-4).Day.ToString()) + " 水曜";
                    week4TextBox.Text = ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + "/" + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString()) + " 木曜";
                    week5TextBox.Text = ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + "/" + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString()) + " 金曜";
                    week6TextBox.Text = ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + "/" + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString()) + " 土曜";

                    day1 = today.AddDays(-6).Year + ((today.AddDays(-6).Month < 10) ? ("0" + today.AddDays(-6).Month) : today.AddDays(-6).Month.ToString()) + ((today.AddDays(-6).Day < 10) ? ("0" + today.AddDays(-6).Day) : today.AddDays(-6).Day.ToString());
                    day2 = today.AddDays(-5).Year + ((today.AddDays(-5).Month < 10) ? ("0" + today.AddDays(-5).Month) : today.AddDays(-5).Month.ToString()) + ((today.AddDays(-5).Day < 10) ? ("0" + today.AddDays(-5).Day) : today.AddDays(-5).Day.ToString());
                    day3 = today.AddDays(-4).Year + ((today.AddDays(-4).Month < 10) ? ("0" + today.AddDays(-4).Month) : today.AddDays(-4).Month.ToString()) + ((today.AddDays(-4).Day < 10) ? ("0" + today.AddDays(-4).Day) : today.AddDays(-4).Day.ToString());
                    day4 = today.AddDays(-3).Year + ((today.AddDays(-3).Month < 10) ? ("0" + today.AddDays(-3).Month) : today.AddDays(-3).Month.ToString()) + ((today.AddDays(-3).Day < 10) ? ("0" + today.AddDays(-3).Day) : today.AddDays(-3).Day.ToString());
                    day5 = today.AddDays(-2).Year + ((today.AddDays(-2).Month < 10) ? ("0" + today.AddDays(-2).Month) : today.AddDays(-2).Month.ToString()) + ((today.AddDays(-2).Day < 10) ? ("0" + today.AddDays(-2).Day) : today.AddDays(-2).Day.ToString());
                    day6 = today.AddDays(-1).Year + ((today.AddDays(-1).Month < 10) ? ("0" + today.AddDays(-1).Month) : today.AddDays(-1).Month.ToString()) + ((today.AddDays(-1).Day < 10) ? ("0" + today.AddDays(-1).Day) : today.AddDays(-1).Day.ToString());

                    break;

                default:
                    break;
            }

        }
        #endregion

        #region SetWeekList
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetWeekList
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetWeekList()
        {
            _weekList = new List<string>();
            _weekList.Add(day1);
            _weekList.Add(day6);
            _weekList.Add(week1TextBox.Text);
            _weekList.Add(week2TextBox.Text);
            _weekList.Add(week3TextBox.Text);
            _weekList.Add(week4TextBox.Text);
            _weekList.Add(week5TextBox.Text);
            _weekList.Add(week6TextBox.Text);
        }
        #endregion

        #region SetStdControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12  DatNT   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // 月曜日ヘッダ
            week1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10, HorizontalAlignment.Center);

            // 火曜日ヘッダ
            week2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10, HorizontalAlignment.Center);

            // 水曜日ヘッダ
            week3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10, HorizontalAlignment.Center);

            // 木曜日ヘッダ
            week4TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10, HorizontalAlignment.Center);

            // 金曜日ヘッダ
            week5TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10, HorizontalAlignment.Center);

            // 土曜日ヘッダ
            week6TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10, HorizontalAlignment.Center);

            // 合計ヘッダ
            totalTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10, HorizontalAlignment.Center);

            // 支所
            syuhoListDataGridView.SetStdControlDomain(ShisyoCol.Index, ZControlDomain.ZG_STD_NAME, 10);

            // 検査員
            syuhoListDataGridView.SetStdControlDomain(KensainNmCol.Index, ZControlDomain.ZG_STD_NAME, 20);

            // 7条/月曜日
            syuhoListDataGridView.SetStdControlDomain(Week1_7JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 11条/月曜日
            syuhoListDataGridView.SetStdControlDomain(Week1_11JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 計/月曜日
            syuhoListDataGridView.SetStdControlDomain(Week1_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 7条/火曜日
            syuhoListDataGridView.SetStdControlDomain(Week2_7JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 11条/火曜日
            syuhoListDataGridView.SetStdControlDomain(Week2_11JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 計/火曜日
            syuhoListDataGridView.SetStdControlDomain(Week2_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 7条/水曜日
            syuhoListDataGridView.SetStdControlDomain(Week3_7JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 11条/水曜日
            syuhoListDataGridView.SetStdControlDomain(Week3_11JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 計/水曜日
            syuhoListDataGridView.SetStdControlDomain(Week3_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 7条/木曜日
            syuhoListDataGridView.SetStdControlDomain(Week4_7JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 11条/木曜日
            syuhoListDataGridView.SetStdControlDomain(Week4_11JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 計/木曜日
            syuhoListDataGridView.SetStdControlDomain(Week4_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 7条/金曜日
            syuhoListDataGridView.SetStdControlDomain(Week5_7JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 11条/金曜日
            syuhoListDataGridView.SetStdControlDomain(Week5_11JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 計/金曜日
            syuhoListDataGridView.SetStdControlDomain(Week5_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 7条/土曜日
            syuhoListDataGridView.SetStdControlDomain(Week6_7JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 11条/土曜日
            syuhoListDataGridView.SetStdControlDomain(Week6_11JoCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 計/土曜日
            syuhoListDataGridView.SetStdControlDomain(Week6_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 2);

            // 7条/合計
            syuhoListDataGridView.SetStdControlDomain(Gokei_7JoCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 11条/合計
            syuhoListDataGridView.SetStdControlDomain(Gokei_11JoCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 計/合計
            syuhoListDataGridView.SetStdControlDomain(Gokei_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 平均（件数/日）
            syuhoListDataGridView.SetStdControlDomain(Gokei_TotalCol.Index, ZControlDomain.ZG_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
        }
        #endregion

        #endregion

    }
    #endregion
}
