using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.HenkouTodokeToroku
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNendo
        /// </summary>
        string TorokuNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        string Renban { get; set; }
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    class FormLoadALInput : IBseALInputImpl, IFormLoadALInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNendo
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        public string Renban { get; set; }
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    interface IFormLoadALOutput
    {
        /// <summary>
        /// EditDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable EditDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DataTable LockTable { get; set; }
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// EditDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable EditDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable LockTable { get; set; }
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JokasoDaichoShosai：FormLoad";

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
        /// 2014/11/12　habu　　    新規作成
        /// </history>
        public FormLoadApplicationLogic()
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
        /// 2014/11/12　habu　　    新規作成
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
        /// 2014/11/12　habu　　    新規作成
        /// </history>
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();
            
            try
            {
                #region get lock object

                JokasoDaichoMstDataSet.JokasoDaichoMstDataTable lockTemplateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

                IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                lockBlInput.TableName = lockTemplateTable.TableName;
                lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoHokenjoCdColumn.ColumnName);
                lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoTorokuNendoColumn.ColumnName);
                lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoRenbanColumn.ColumnName);
                lockBlInput.SelColNameList = lockBlInput.WhereColNameList;
                lockBlInput.ValueList.Add(input.HokenjoCd);
                lockBlInput.ValueList.Add(input.TorokuNendo);
                lockBlInput.ValueList.Add(input.Renban);
                IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                output.LockTable = lockBlOutput.SelectDataTable;

                #endregion

                #region get edit data

                JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable templateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();

                IStdFilteredGetDataBLInput blInput = new StdFilteredGetDataBLInput();
                blInput.DataTableType = typeof(JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable);
                blInput.TableAdapterType  = typeof(JokasoDaichoMstListTableAdapter);
                blInput.Query.AddEqualCond(templateTable.JokasoHokenjoCdColumn.ColumnName, input.HokenjoCd);
                blInput.Query.AddEqualCond(templateTable.JokasoTorokuNendoColumn.ColumnName, input.TorokuNendo);
                blInput.Query.AddEqualCond(templateTable.JokasoRenbanColumn.ColumnName, input.Renban);

                IStdFilteredGetDataBLOutput blOutput = new StdFilteredGetDataBusinessLogic().Execute(blInput);

                output.EditDataTable = (JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable)blOutput.GetDataTable;

                #endregion
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
