using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanrenFileTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.DataSet.KensaIraiKanri.KensaKeikakuDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaKeikaku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDataLoadCalenderALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/24　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDataLoadCalenderALInput : IBseALInput
    {
        /// <summary>
        /// 
        /// </summary>
        string Year { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Month { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DataLoadCalenderALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/24　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DataLoadCalenderALInput : IBseALInputImpl, IDataLoadCalenderALInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Month { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDataLoadCalenderALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/24　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDataLoadCalenderALOutput
    {
        /// <summary>
        /// EditDataTable
        /// </summary>
        KensaKeikakuDataSet.KensaKeikakuListDataTable EditDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DataTable LockTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DataLoadCalenderALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/24　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DataLoadCalenderALOutput : IDataLoadCalenderALOutput
    {
        /// <summary>
        /// EditDataTable
        /// </summary>
        public KensaKeikakuDataSet.KensaKeikakuListDataTable EditDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable LockTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DataLoadCalenderApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/24　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DataLoadCalenderApplicationLogic : BaseApplicationLogic<IDataLoadCalenderALInput, IDataLoadCalenderALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeikaku：DataLoadCalender";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DataLoadCalenderApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/24　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DataLoadCalenderApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/24　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/24　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDataLoadCalenderALOutput Execute(IDataLoadCalenderALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDataLoadCalenderALOutput output = new DataLoadCalenderALOutput();

            try
            {
                #region get lock object

                {
                    //KensaIraiTblDataSet.KensaIraiTblDataTable lockTemplateTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                    //IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                    //lockBlInput.TableName = lockTemplateTable.TableName;
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiHoteiKbnColumn.ColumnName);
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiHokenjoCdColumn.ColumnName);
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiNendoColumn.ColumnName);
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiRenbanColumn.ColumnName);
                    //lockBlInput.SelColNameList = lockBlInput.WhereColNameList;
                    //// 法定区分は固定値を指定
                    //lockBlInput.ValueList.Add(KENSA_IRAI_7JO);
                    //lockBlInput.ValueList.Add(input.HokenjoCd);
                    //lockBlInput.ValueList.Add(input.IraiNendo);
                    //lockBlInput.ValueList.Add(input.Renban);
                    //IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                    //output.LockTable = lockBlOutput.SelectDataTable;
                }

                #endregion

                #region get edit data

                {
                    KensaKeikakuDataSet.KensaKeikakuListDataTable templateTable = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

                    IStdFilteredGetDataBLInput blInput = new StdFilteredGetDataBLInput();
                    blInput.DataTableType = typeof(KensaKeikakuDataSet.KensaKeikakuListDataTable);
                    blInput.TableAdapterType = typeof(KensaKeikakuListTableAdapter);
                    blInput.Query.AddEqualCond(templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, input.Year);
                    blInput.Query.AddEqualCond(templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, input.Month);

                    IStdFilteredGetDataBLOutput blOutput = new StdFilteredGetDataBusinessLogic().Execute(blInput);

                    output.EditDataTable = (KensaKeikakuDataSet.KensaKeikakuListDataTable)blOutput.GetDataTable;
                }

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
