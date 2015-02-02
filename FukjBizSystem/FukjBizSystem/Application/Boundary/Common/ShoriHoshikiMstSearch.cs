using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Generic;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShoriHoshikiMstDataSetTableAdapters;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    /// <summary>
    /// メーカー型式マスタ検索ダイアログ
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  habu        新規作成
    /// </history>
    public partial class ShoriHoshikiMstSearchForm : StdListForm
    {
        #region Property

        public string ShoriHoshikiKbn = string.Empty;

        public string ShoriHoshikiCd = string.Empty;

        public string ShoriHoshikiShubetsu = string.Empty;

        public string ShoriHoshikiNm = string.Empty;

        public string ShoriHoshikiShubetsuNm = string.Empty;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        public ShoriHoshikiMstSearchForm()
        {
            InitializeComponent();
        }
        #endregion

        #region StdMethods(must override)

        #region AssignStandardControls
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void AssignStandardControls(StdListForm.StandardControls stdControls, StdListForm.StandardParams stdParams)
        {
            stdControls.ClearButton = clearButton;
            stdControls.CloseButton = closeButton;
            stdControls.ListPanel = listPanel;
            stdControls.SearchButton = kensakuButton;
            stdControls.SearchCntLabel = listCountLabel;
            stdControls.SearchListDataGridView = listDataGridView;
            stdControls.SearchPanel = searchPanel;
            stdControls.SelectButton = selectButton;
            stdControls.ViewChangeButton = viewChangeButton;

            // Specify DataTable of search result
            stdParams.ListDataTableType = typeof(ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable);
            // Specify TableAdapter of search operation(Using with StdListForm, TableAdapter must have non-parameter Fill/GetData Method)
            stdParams.ListTableAdapterType = typeof(ShoriHoshikiMstKensakuTableAdapter);
        }
        #endregion

        #region ClearCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void ClearCondition()
        {
            // clear search conditions
            shoriHoshikiKbnFromTextBox.Clear();
            shoriHoshikiKbnToTextBox.Clear();
            shoriHoshikiCdFromTextBox.Clear();
            shoriHoshikiCdToTextBox.Clear();
            shoriHoshikiNmTextBox.Clear();
        }
        #endregion

        #region CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override bool CheckCondition(out string errMsg)
        {
            int from;
            int to;

            errMsg = string.Empty;

            if (int.TryParse(shoriHoshikiKbnFromTextBox.Text, out from)
                && int.TryParse(shoriHoshikiKbnToTextBox.Text, out to)
                && from > to)
            {
                errMsg = "範囲指定が正しくありません。処理方式区分の大小関係を確認してください。";

                return false;
            }

            if (int.TryParse(shoriHoshikiCdFromTextBox.Text, out from)
                && int.TryParse(shoriHoshikiCdToTextBox.Text, out to)
                && from > to)
            {
                errMsg = "範囲指定が正しくありません。処理方式コードの大小関係を確認してください。";

                return false;
            }

            return true;
        }
        #endregion

        #region MakeCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void MakeCondition(ApplicationLogic.Generic.StdList.ISearchBtnClickALInput searchAlInput)
        {
            ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable templateTable = new ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable();

            AddGreaterEqualCond(searchAlInput, templateTable.ShoriHoshikiKbnColumn.ColumnName, shoriHoshikiKbnFromTextBox);
            AddLesserEqualCond(searchAlInput, templateTable.ShoriHoshikiKbnColumn.ColumnName, shoriHoshikiKbnToTextBox);
            AddGreaterEqualCond(searchAlInput, templateTable.ShoriHoshikiCdColumn.ColumnName, shoriHoshikiCdFromTextBox);
            AddLesserEqualCond(searchAlInput, templateTable.ShoriHoshikiCdColumn.ColumnName, shoriHoshikiCdToTextBox);

            AddLikePartialCond(searchAlInput, templateTable.ShoriHoshikiNmColumn.ColumnName, shoriHoshikiNmTextBox);

            AddOrderCol(searchAlInput, templateTable.ShoriHoshikiKbnColumn.ColumnName);
            AddOrderCol(searchAlInput, templateTable.ShoriHoshikiCdColumn.ColumnName);
        }
        #endregion

        #region DispSearchResult
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void DispSearchResult(ApplicationLogic.Generic.StdList.ISearchBtnClickALOutput searchAlOutput)
        {
            // Clear before fill
            shoriHoshikiMstDataSet.Clear();

            // display search result 
            shoriHoshikiMstDataSet.Merge(searchAlOutput.SearchDataTable);
        }
        #endregion

        #region DoSelectRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void DoSelectRow(DataGridViewRow selectedRow)
        {
            ShoriHoshikiKbn = (string)selectedRow.Cells[shoriHoshikiKbnDataGridViewTextBoxColumn.Index].Value;
            ShoriHoshikiCd = (string)selectedRow.Cells[shoriHoshikiCdDataGridViewTextBoxColumn.Index].Value;
            ShoriHoshikiShubetsu = (string)selectedRow.Cells[ShoriHoshikiShubetsuKbn.Index].Value;
            ShoriHoshikiNm = (string)selectedRow.Cells[shoriHoshikiNmDataGridViewTextBoxColumn.Index].Value;
            ShoriHoshikiShubetsuNm = (string)selectedRow.Cells[shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.Index].Value;
        }
        #endregion

        #region CloseForm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void CloseForm()
        {
            // Dialog forms simply close itself
            Close();
        }
        #endregion

        #region SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void SetControlDomain()
        {
            shoriHoshikiKbnFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 1);
            shoriHoshikiKbnToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 1);
            shoriHoshikiCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 3);
            shoriHoshikiCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 3);
            shoriHoshikiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
        }
        #endregion

        #region SetStdEventHandler
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu        新規作成
        /// </history>
        protected override void SetStdEventHandler()
        {
            Common.SetStdEnterTabEvent(this);

            Common.SetRangeCdAutoFill(shoriHoshikiKbnFromTextBox, shoriHoshikiKbnToTextBox);
            Common.SetRangeCdAutoFill(shoriHoshikiCdFromTextBox, shoriHoshikiCdToTextBox);
        }
        #endregion

        #endregion
    }
    #endregion
}
