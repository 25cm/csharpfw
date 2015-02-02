using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Common.DataAccess;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Generic.StdList
{
    #region 入力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28　habu　　    新規作成
    /// </history>
    public interface ISearchBtnClickALInput : IBseALInput , IStdFilteredGetDataBLInput
    {

    }
    #endregion

    #region 入力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28　habu　　    新規作成
    /// </history>
    class SearchBtnClickALInput : IBseALInputImpl, ISearchBtnClickALInput
    {
        /// <summary>
        /// Type of TableAdapter. Use typeof(XXXTableAdapter)
        /// </summary>
        public Type TableAdapterType { get; set; }

        /// <summary>
        /// Type of DataTable. Use typeof(XXXDataTable)
        /// </summary>
        public Type DataTableType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public QueryBuilder Query { get; set; }

        /// <summary>
        /// Applies DISTINCT if true
        /// </summary>
        public bool IsDistinct { get; set; }

        /// <summary>
        /// Row Count Limit
        /// </summary>
        public int RowLimit { get; set; }

        /// <summary>
        /// Query CommantTimeout(seconds)
        /// </summary>
        public int CommandTimeOut { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SearchBtnClickALInput()
        {
            Query = new QueryBuilder();

            IsDistinct = false;
            RowLimit = -1;
            // NOTICE デフォルトのCommandTimeoutを設定する(暫定で10分)
            CommandTimeOut = Properties.Settings.Default.DefaultCommandTimeoutSec;
        }
    }
    #endregion

    #region 出力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28　habu　　    新規作成
    /// </history>
    public interface ISearchBtnClickALOutput
    {
        /// <summary>
        /// Select query result
        /// </summary>
        DataTable SearchDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28　habu　　    新規作成
    /// </history>
    class SearchBtnClickALOutput : ISearchBtnClickALOutput
    {
        /// <summary>
        /// Select query result
        /// </summary>
        public DataTable SearchDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28　habu　　    新規作成
    /// </history>
    class SearchBtnClickApplicationLogic : BaseApplicationLogic<ISearchBtnClickALInput, ISearchBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "StdList：SearchBtnClick";

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        public SearchBtnClickApplicationLogic()
        {

        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

        #endregion

        #region メソッド(public)

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        public override ISearchBtnClickALOutput Execute(ISearchBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISearchBtnClickALOutput output = new SearchBtnClickALOutput();

            try
            {
                IStdFilteredGetDataBLOutput blOutput = new StdFilteredGetDataBusinessLogic().Execute(input);

                output.SearchDataTable = blOutput.GetDataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
