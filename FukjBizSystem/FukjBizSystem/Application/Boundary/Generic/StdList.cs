using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Generic.StdList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Control;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Generic
{
    // NOTICE focused to supports maijor part of search list form 
    // NOTICE 

    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/01　habu　　    新規作成
    /// </history>
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<StdListForm, Form>))]
    public /* abstract */ partial class StdListForm : FukjBaseForm
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        protected StandardControls _stdControls;
        /// <summary>
        /// 
        /// </summary>
        protected StandardParams _stdParams;

        #region ViewChangeButton state fields

        protected bool _searchShowFlg = true;
        protected int _defaultSearchPanelTop = 0;
        protected int _defaultSearchPanelHeight = 0;
        protected int _defaultListPanelTop = 0;
        protected int _defaultListPanelHeight = 0;

        #endregion

        #endregion

        #region Inner classes

        /// <summary>
        /// 
        /// </summary>
        public class StandardControls
        {
            /// <summary>
            /// represent search(kensaku) button
            /// </summary>
            public Button SearchButton;

            /// <summary>
            /// represent clear button
            /// </summary>
            public Button ClearButton;

            /// <summary>
            /// represent search result count label
            /// </summary>
            public Label SearchCntLabel;

            /// <summary>
            /// represent search result list grid
            /// </summary>
            public DataGridView SearchListDataGridView;

            /// <summary>
            /// represent select button
            /// </summary>
            public Button SelectButton;
            /// <summary>
            /// represent new entry(touroku) button
            /// </summary>
            public Button EntryButton;
            /// <summary>
            /// represent edit exist entry(shousai) button
            /// </summary>
            /// <remarks>
            /// if form has no entry button, don't set
            /// </remarks>
            public Button DetailButton;
            /// <summary>
            /// represent output excel (of search result list) button
            /// </summary>
            /// <remarks>
            /// if form has no detail button, don't set
            /// </remarks>
            public Button OutputButton;
            /// <summary>
            /// Required. represents close(tojiru) button
            /// </summary>
            public Button CloseButton;

            /// <summary>
            /// Required if using viewChangeButton. represents view change button
            /// </summary>
            public Button ViewChangeButton;
            /// <summary>
            /// Required if using viewChangeButton
            /// </summary>
            public Panel SearchPanel;
            /// <summary>
            /// Required if using viewChangeButton
            /// </summary>
            public Panel ListPanel;
        }

        /// <summary>
        /// 
        /// </summary>
        public class StandardParams
        {
            /// <summary>
            /// Required
            /// </summary>
            public Type ListDataTableType;
            /// <summary>
            /// Required
            /// </summary>
            public Type ListTableAdapterType;

            /// <summary>
            /// Required if using outputButton
            /// </summary>
            public string OutputFileName;

            /// <summary>
            /// true if search on FormLoad
            /// </summary>
            public bool DoInitSearch;

            /// <summary>
            /// set > 0 to limit search result count
            /// </summary>
            public int SearchCntLimit;

            // public string FormTitle;

            /// <summary>
            /// 
            /// </summary>
            public StandardParams()
            {
                // Set Default Values
                DoInitSearch = true;
                SearchCntLimit = -1;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public StdListForm()
        {
            InitializeComponent();

            _stdControls = new StandardControls();
            _stdParams = new StandardParams();

            // デザイナ表示時はイベント無効(disable events on form designer)
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                Load += StdListForm_Load;
            }
        }
        #endregion

        #region フォーム定義メソッド(Form Difinition Method)

        protected virtual void AssignStandardControls(StandardControls stdControls, StandardParams stdParams) { }

        #endregion

        #region 標準動作メソッド(Standard Action Method)

        /// <summary>
        /// clear search condition contents(equal to initial value)
        /// </summary>
        protected virtual void ClearCondition() { }

        /// <summary>
        /// validate search condition
        /// </summary>
        /// <param name="errMsg">returns error message if validation error occured</param>
        /// <returns>true if check is OK</returns>
        protected virtual bool CheckCondition(out string errMsg) { errMsg = string.Empty; return false; }

        /// <summary>
        /// initialize search condition object(parameter to lower search logic)
        /// </summary>
        /// <param name="searchAlInput"></param>
        protected virtual void MakeCondition(ISearchBtnClickALInput searchAlInput) { }

        /// <summary>
        /// display search result 
        /// </summary>
        /// <param name="searchAlOutput"></param>
        protected virtual void DispSearchResult(ISearchBtnClickALOutput searchAlOutput) { }

        /// <summary>
        /// create derived column value from search data
        /// </summary>
        /// <param name="searchAlOutput"></param>
        protected virtual void CreateDerivedColumn() { }

        /// <summary>
        /// some value of selected row to return to caller form
        /// </summary>
        protected virtual void DoSelectRow(DataGridViewRow selectedRow) { }

        /// <summary>
        /// show detail passing no key parameter
        /// </summary>
        protected virtual void ToNewDetailForm() { }

        /// <summary>
        /// show detail form passing key parameter
        /// </summary>
        /// <param name="selectedRow"></param>
        protected virtual void ToEditDetailForm(DataGridViewRow selectedRow) { }

        /// <summary>
        /// close itself and back to former form
        /// </summary>
        protected virtual void CloseForm() { }

        /// <summary>
        /// set control domain to form controls
        /// </summary>
        protected virtual void SetControlDomain() { }

        ///// <summary>
        ///// 
        ///// </summary>
        //protected abstract void InitDataMapping();

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetStdEventHandler() { }

        #endregion

        #region DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        protected virtual void DoFormLoad()
        {
            AssignStandardControls(_stdControls, _stdParams);

            // NOTICE この時点でパラメータチェックを行うべき(check parameter relation) => べき、だが今後の課題とする(呼出側が正常なら問題ない)

            #region Init viewChangeButton fields

            _searchShowFlg = true;
            _defaultSearchPanelTop = _stdControls.SearchPanel.Top;
            _defaultSearchPanelHeight = _stdControls.SearchPanel.Height;
            _defaultListPanelTop = _stdControls.ListPanel.Top;
            _defaultListPanelHeight = _stdControls.ListPanel.Height;

            #endregion

            SetButtonHandeler();

            SetOtherEventHandler();

            SetShortCutKey();

            SetControlDomain();

            // 当面、検索画面は直接にはデータ登録を行わない(currently, search list form doesn't entry (direct) to DB. DataMapping is not nessesary)
            //InitDataMapping();

            SetStdEventHandler();

            if (_stdParams.DoInitSearch)
            {
                DoSearch(false);
            }
        }
        #endregion

        #region DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispUiMessage">true if it display UI dialog on exception</param>
        public virtual void DoSearch(bool dispUiMessage)
        {
            ISearchBtnClickALInput input = new SearchBtnClickALInput();
            input.DataTableType = _stdParams.ListDataTableType;
            input.TableAdapterType = _stdParams.ListTableAdapterType;
            input.RowLimit = _stdParams.SearchCntLimit;

            MakeCondition(input);

            ISearchBtnClickALOutput output = new SearchBtnClickApplicationLogic().Execute(input);

            DispSearchResult(output);

            // update list count label
            if (output.SearchDataTable == null || output.SearchDataTable.Rows.Count == 0)
            {
                _stdControls.SearchCntLabel.Text = "0件";

                // unless init load event, disp 0 count message
                if (dispUiMessage)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                }
            }
            else
            {
                _stdControls.SearchCntLabel.Text = output.SearchDataTable.Rows.Count.ToString() + "件";
            }
        }
        #endregion

        #region OutputList
        /// <summary>
        /// 
        /// </summary>
        protected virtual void OutputList()
        {
            if (_stdControls.SearchListDataGridView == null)
            {
                return;
            }

            if (_stdControls.SearchListDataGridView.RowCount == 0)
            {
                return;
            }

            // Output list data to Excel file
            Common.Common.FlushGridviewDataToExcel(_stdControls.SearchListDataGridView, _stdParams.OutputFileName);
        }
        #endregion

        #region 標準初期ロードイベント(Standard Load Event Handler)

        #region StdListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void StdListForm_Load(object sender, EventArgs e)
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

                CloseForm();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region 標準ボタンイベント(Standard Button Event Handler)

        #region SetButtonHandeler
        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetButtonHandeler()
        {
            if (_stdControls.SelectButton != null)
            {
                _stdControls.SelectButton.Click += SelectButton_Click;
            }
            if (_stdControls.SearchButton != null)
            {
                _stdControls.SearchButton.Click += SearchButton_Click;
            }
            if (_stdControls.ClearButton != null)
            {
                _stdControls.ClearButton.Click += ClearButton_Click;
            }
            if (_stdControls.EntryButton != null)
            {
                _stdControls.EntryButton.Click += EntryButton_Click;
            }
            if (_stdControls.DetailButton != null)
            {
                _stdControls.DetailButton.Click += DetailButton_Click;
            }
            if (_stdControls.OutputButton != null)
            {
                _stdControls.OutputButton.Click += OutputButton_Click;
            }
            if (_stdControls.CloseButton != null)
            {
                _stdControls.CloseButton.Click += CloseButton_Click;
            }
            if (_stdControls.ViewChangeButton != null)
            {
                _stdControls.ViewChangeButton.Click += ViewChangeButton_Click;
            }
        }
        #endregion

        #region SelectButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SelectButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_stdControls.SearchListDataGridView == null)
                {
                    return;
                }

                if (_stdControls.SearchListDataGridView.CurrentRow == null)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // set return data to caller form
                DoSelectRow(_stdControls.SearchListDataGridView.CurrentRow);

                DialogResult = DialogResult.OK;
                Close();
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

        #region SearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string errorMsg = string.Empty;

                if (!CheckCondition(out errorMsg))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Warning, errorMsg);

                    return;
                }

                DoSearch(true);
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

        #region ClearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ClearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Clear Search Condition
                ClearCondition();

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

        #region EntryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EntryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ToNewDetailForm();
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

        #region DetailButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DetailButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_stdControls.SearchListDataGridView == null)
                {
                    return;
                }

                if (_stdControls.SearchListDataGridView.CurrentRow == null)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                ToEditDetailForm(_stdControls.SearchListDataGridView.CurrentRow);
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

        #region OutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                OutputList();
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

        #region CloseButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                CloseForm();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;

                // 検索条件を開く
                if (this._searchShowFlg)
                {
                    _stdControls.ViewChangeButton.Text = "▲";
                }
                // 検索条件を閉じる
                else
                {
                    _stdControls.ViewChangeButton.Text = "▼";
                }

                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    _stdControls.SearchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    _stdControls.ListPanel,
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

        #region SetShortCutKey
        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetShortCutKey()
        {
            if (_stdControls.SelectButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F1, _stdControls.SelectButton);
            }
            if (_stdControls.EntryButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F1, _stdControls.EntryButton);
            }
            if (_stdControls.DetailButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F2, _stdControls.DetailButton);
            }
            if (_stdControls.OutputButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F6, _stdControls.OutputButton);
            }
            if (_stdControls.ClearButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F7, _stdControls.ClearButton);
            }
            if (_stdControls.SearchButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F8, _stdControls.SearchButton);
            }
            if (_stdControls.CloseButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F12, _stdControls.CloseButton);
            }
        }
        #endregion

        #endregion

        #region その他標準イベント(Other Standard Event Handler)

        #region SetOtherEventHandler
        /// <summary>
        /// 
        /// </summary>
        protected void SetOtherEventHandler()
        {
            if (_stdControls.SearchListDataGridView != null)
            {
                _stdControls.SearchListDataGridView.CellDoubleClick += SearchListDataGridViewDataGridView_CellDoubleClick;
            }
            if (_stdControls.SearchListDataGridView != null)
            {
                _stdControls.SearchListDataGridView.DataBindingComplete += SearchListDataGridViewDataGridView_DataBindingComplete;
            }
        }
        #endregion

        #region SearchListDataGridViewDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchListDataGridViewDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_stdControls.SearchListDataGridView == null)
                {
                    return;
                }

                if (_stdControls.SearchListDataGridView.CurrentRow == null)
                {
                    return;
                }

                // ヘッダのクリックの場合は無効
                if (e.RowIndex < 0)
                {
                    return;
                }

                if (_stdControls.SelectButton != null)
                {
                    // set return data to caller form
                    DoSelectRow(_stdControls.SearchListDataGridView.CurrentRow);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (_stdControls.DetailButton != null)
                {
                    ToEditDetailForm(_stdControls.SearchListDataGridView.CurrentRow);
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

        #region SearchListDataGridViewDataGridView_DataBindingComplete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchListDataGridViewDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // create derived column value
                CreateDerivedColumn();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {

            }
        }
        #endregion

        #endregion

        #region Utiliy methods

        protected string GetControlValue(System.Windows.Forms.Control control)
        {
            // NOTICE Number場合は別扱いとする => SQL上は数値を文字列として扱う。数値として扱えればベターかもしれないが、保留
            //if (control is NumberTextBox)
            //{

            //}
            //else if (control is ZTextBox && (control as ZTextBox).CustomControlDomain == ZControlDomain.ZT_STD_NUM)
            //{

            //}
            //else
            {
                return control.Text.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        protected void AddEqualCond(ISearchBtnClickALInput cond, string colName, System.Windows.Forms.Control control)
        {
            if (!string.IsNullOrEmpty(control.Text.Trim()))
            {
                cond.Query.AddEqualCond(colName, GetControlValue(control));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        protected void AddEqualCondWarekiNendo(ISearchBtnClickALInput cond, string colName, System.Windows.Forms.Control control)
        {
            if (!string.IsNullOrEmpty(control.Text.Trim()))
            {
                // 和暦年度を西暦年度(平成)に変換
                cond.Query.AddEqualCond(colName, Common.Common.ConvertToHoshouNendoSeireki(GetControlValue(control)));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        protected void AddGreaterEqualCond(ISearchBtnClickALInput cond, string colName, System.Windows.Forms.Control control)
        {
            if (!string.IsNullOrEmpty(control.Text.Trim()))
            {
                cond.Query.AddGreaterEqualCond(colName, GetControlValue(control));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        protected void AddLesserEqualCond(ISearchBtnClickALInput cond, string colName, System.Windows.Forms.Control control)
        {
            if (!string.IsNullOrEmpty(control.Text.Trim()))
            {
                cond.Query.AddLesserEqualCond(colName, GetControlValue(control));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        protected void AddLikePartialCond(ISearchBtnClickALInput cond, string colName, System.Windows.Forms.Control control)
        {
            if (!string.IsNullOrEmpty(control.Text.Trim()))
            {
                cond.Query.AddLikeCond(colName, "%" + GetControlValue(control) + "%");
            }
        }

        /// <summary>
        /// OR検索用
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colNameList"></param>
        /// <param name="controls"></param>
        protected void AddLikePartialAnyCond(ISearchBtnClickALInput cond, IEnumerable<string> colNameList, IEnumerable<System.Windows.Forms.Control> controls)
        {
            StringBuilder buf = new StringBuilder();

            foreach (string colName in colNameList)
            {
                foreach (System.Windows.Forms.Control control in controls)
                {
                    if (!string.IsNullOrEmpty(control.Text.Trim()))
                    {
                        if (buf.Length > 0)
                        {
                            buf.AppendFormat(" OR ");
                        }

                        // TODO パラメータ化する
                        buf.AppendFormat("({0} LIKE '%{1}%')", colName, GetControlValue(control));
                    }
                }
            }

            if (buf.Length > 0)
            {
                cond.Query.AddCondUnit(string.Format("({0})", buf.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        protected void AddLikeFormerCond(ISearchBtnClickALInput cond, string colName, System.Windows.Forms.Control control)
        {
            if (!string.IsNullOrEmpty(control.Text.Trim()))
            {
                cond.Query.AddLikeCond(colName, GetControlValue(control) + "%");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        protected void AddLikeLaterCond(ISearchBtnClickALInput cond, string colName, System.Windows.Forms.Control control)
        {
            if (!string.IsNullOrEmpty(control.Text.Trim()))
            {
                cond.Query.AddLikeCond(colName, "%" + GetControlValue(control));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        protected void AddOrderCol(ISearchBtnClickALInput cond, string colName)
        {
            cond.Query.AddOrderCol(colName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="colName"></param>
        protected void AddOrderCol(ISearchBtnClickALInput cond, string colName, bool isAsc)
        {
            cond.Query.AddOrderCol(colName, isAsc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromTextBox"></param>
        /// <param name="toTextBox"></param>
        /// <param name="errMsg"></param>
        /// <param name="dispName"></param>
        /// <returns></returns>
        protected bool CheckRangeCondition(TextBox fromTextBox, TextBox toTextBox, out string errMsg, string dispName)
        {
            int from;
            int to;

            errMsg = string.Empty;

            if (int.TryParse(fromTextBox.Text, out from)
                && int.TryParse(toTextBox.Text, out to)
                && from > to)
            {
                errMsg = string.Format("範囲指定が正しくありません。{0}の大小関係を確認してください。", dispName);

                return false;
            }

            return true;
        }

        #endregion

    }
}
