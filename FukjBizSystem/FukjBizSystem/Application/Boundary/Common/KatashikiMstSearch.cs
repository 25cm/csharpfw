using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Generic;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KatashikiMstDataSetTableAdapters;
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
    public partial class KatashikiMstSearchForm : StdListForm
    {
        #region Property

        public string MakerGyoshaCd = string.Empty;

        public string MakerGyoshaNm = string.Empty;

        public string KatashikiCd = string.Empty;

        public string KatashikiNm = string.Empty;

        public string ShoriHoshikiKbn = string.Empty;

        public string ShoriHoshikiCd = string.Empty;

        public string _ShoriHoshikiShubetsuKbn = string.Empty;

        public string _ShoriHoshikiShubetsuNm = string.Empty;

        public string _ShoriHoshikiNm = string.Empty;

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
        public KatashikiMstSearchForm()
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

            stdParams.ListDataTableType = typeof(KatashikiMstDataSet.KatashikiMstSearchDataTable);
            stdParams.ListTableAdapterType = typeof(KatashikiMstSearchTableAdapter);
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
            katashikiMakerCdFromTextBox.Clear();
            katashikiMakerCdToTextBox.Clear();
            gyoshaNmTextBox.Clear();

            katashikiCdFromTextBox.Clear();
            katashikiCdToTextBox.Clear();
            katashikiNmTextBox.Clear();
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

            if (int.TryParse(katashikiMakerCdFromTextBox.Text, out from)
                && int.TryParse(katashikiMakerCdToTextBox.Text, out to)
                && from > to)
            {
                errMsg = "範囲指定が正しくありません。メーカー業者コードの大小関係を確認してください。";

                return false;
            }

            if (int.TryParse(katashikiCdFromTextBox.Text, out from)
                && int.TryParse(katashikiCdToTextBox.Text, out to)
                && from > to)
            {
                errMsg = "範囲指定が正しくありません。型式コードの大小関係を確認してください。";

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
            KatashikiMstDataSet.KatashikiMstSearchDataTable templateTable = new KatashikiMstDataSet.KatashikiMstSearchDataTable();

            AddGreaterEqualCond(searchAlInput, templateTable.KatashikiMakerCdColumn.ColumnName, katashikiMakerCdFromTextBox);
            AddLesserEqualCond(searchAlInput, templateTable.KatashikiMakerCdColumn.ColumnName, katashikiMakerCdToTextBox);
            AddLikePartialCond(searchAlInput, templateTable.GyoshaNmColumn.ColumnName, gyoshaNmTextBox);

            AddGreaterEqualCond(searchAlInput, templateTable.KatashikiCdColumn.ColumnName, katashikiCdFromTextBox);
            AddLesserEqualCond(searchAlInput, templateTable.KatashikiCdColumn.ColumnName, katashikiCdToTextBox);
            AddLikePartialCond(searchAlInput, templateTable.KatashikiNmColumn.ColumnName, katashikiNmTextBox);

            AddOrderCol(searchAlInput, templateTable.KatashikiMakerCdColumn.ColumnName);
            AddOrderCol(searchAlInput, templateTable.KatashikiCdColumn.ColumnName);
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
            katashikiMstDataSet.Clear();

            // display search result 
            katashikiMstDataSet.Merge(searchAlOutput.SearchDataTable);
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
        /// 2014/12/20  habu        処理方式情報も返すように変更
        /// </history>
        protected override void DoSelectRow(DataGridViewRow selectedRow)
        {
            MakerGyoshaCd = (string)selectedRow.Cells[katashikiMakerCdDataGridViewTextBoxColumn.Index].Value;
            MakerGyoshaNm = (string)selectedRow.Cells[GyoshaNmDataGridViewTextBoxColumn.Index].Value;
            KatashikiCd = (string)selectedRow.Cells[katashikiCdDataGridViewTextBoxColumn.Index].Value;
            KatashikiNm = (string)selectedRow.Cells[katashikiNmDataGridViewTextBoxColumn.Index].Value;

            // 処理方式情報も返すように変更
            ShoriHoshikiKbn = (string)selectedRow.Cells[KatashikiShorihoushikiKbnTextBoxColumn.Index].Value;
            ShoriHoshikiCd = (string)selectedRow.Cells[KatashikiShorihoushikiCdTextBoxColumn.Index].Value;
            _ShoriHoshikiShubetsuKbn = (string)selectedRow.Cells[ShoriHoshikiShubetsuKbnTextBoxColumn.Index].Value;
            _ShoriHoshikiShubetsuNm = (string)selectedRow.Cells[ShoriHoshikiShubetsuNmTextBoxColumn.Index].Value;
            _ShoriHoshikiNm = (string)selectedRow.Cells[ShoriHoshikiNmTextBoxColumn.Index].Value;
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
            katashikiMakerCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            katashikiMakerCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            gyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            katashikiCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            katashikiCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            katashikiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);
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

            Common.SetRangeCdAutoFill(katashikiMakerCdFromTextBox, katashikiMakerCdToTextBox);
            Common.SetRangeCdAutoFill(katashikiCdFromTextBox, katashikiCdToTextBox);
        }
        #endregion

        #endregion
    }
    #endregion
}
