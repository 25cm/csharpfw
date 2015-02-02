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

namespace FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaYoteiWariate
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDataLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDataLoadALInput : IBseALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string SishoCd { get; set; }

        /// <summary>
        /// 職員コード
        /// </summary>
        string ShokuinCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DataLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DataLoadALInput : IBseALInputImpl, IDataLoadALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string SishoCd { get; set; }

        /// <summary>
        /// 職員コード
        /// </summary>
        public string ShokuinCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDataLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDataLoadALOutput
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
    //  クラス名 ： DataLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DataLoadALOutput : IDataLoadALOutput
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
    //  クラス名 ： DataLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DataLoadApplicationLogic : BaseApplicationLogic<IDataLoadALInput, IDataLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaYoteiWariate：DataLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DataLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DataLoadApplicationLogic()
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
        /// 2014/12/20　habu　　    新規作成
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
        /// 2014/12/20　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDataLoadALOutput Execute(IDataLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDataLoadALOutput output = new DataLoadALOutput();

            try
            {
                #region get lock object

                {
                    // TODO Filteredと同じように条件を指定できるようにする
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

                    // TODO 以下の条件で取得する。未割当の場合は、所属支所の依頼のみ。割当済みの場合は支所が異なっても取得・表示する

                    blInput.Query.AddLesserCond(templateTable.KensaIraiStatusKbnColumn.ColumnName, Utility.Constants.KensaIraiStatusConstant.STATUS_KENSA_MOCHIDASHI);
                    blInput.Query.AddEqualCond(templateTable.KensaIraiUketsukeShishoKbnColumn.ColumnName, input.SishoCd);
                    blInput.Query.AddCondUnit(string.Format("({0} = '{1}' OR {0} = '' OR {0} IS NULL)", templateTable.KensaIraiKensaTantoshaCdColumn.ColumnName, input.ShokuinCd));

                    blInput.Query.AddOrderCol(templateTable.KensaIraiKensaYoteiNenColumn.ColumnName);
                    blInput.Query.AddOrderCol(templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName);
                    blInput.Query.AddOrderCol(templateTable.KensaIraiKensaYoteiBiColumn.ColumnName);

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
