using System.Reflection;
using FukjBizSystem.Application.DataAccess.KaikeiRendoDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKaikeiRendoTblExportCSVByKaikeiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKaikeiRendoTblExportCSVByKaikeiNoBLInput : ISelectKaikeiRendoTblExportCSVByKaikeiNoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaikeiRendoTblExportCSVByKaikeiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaikeiRendoTblExportCSVByKaikeiNoBLInput : IGetKaikeiRendoTblExportCSVByKaikeiNoBLInput
    {
        /// <summary>
        /// KaikeiNo
        /// </summary>
        public string KaikeiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKaikeiRendoTblExportCSVByKaikeiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKaikeiRendoTblExportCSVByKaikeiNoBLOutput : ISelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaikeiRendoTblExportCSVByKaikeiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaikeiRendoTblExportCSVByKaikeiNoBLOutput : IGetKaikeiRendoTblExportCSVByKaikeiNoBLOutput
    {
        /// <summary>
        /// KaikeiRendoTblExportCSVDataTable
        /// </summary>
        public KaikeiRendoDtlTblDataSet.KaikeiRendoTblExportCSVDataTable KaikeiRendoTblExportCSVDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaikeiRendoTblExportCSVByKaikeiNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaikeiRendoTblExportCSVByKaikeiNoBusinessLogic : BaseBusinessLogic<IGetKaikeiRendoTblExportCSVByKaikeiNoBLInput, IGetKaikeiRendoTblExportCSVByKaikeiNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKaikeiRendoTblExportCSVByKaikeiNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKaikeiRendoTblExportCSVByKaikeiNoBusinessLogic()
        {
        }
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
        /// 2014/09/12  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKaikeiRendoTblExportCSVByKaikeiNoBLOutput Execute(IGetKaikeiRendoTblExportCSVByKaikeiNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKaikeiRendoTblExportCSVByKaikeiNoBLOutput output = new GetKaikeiRendoTblExportCSVByKaikeiNoBLOutput();

            try
            {
                output.KaikeiRendoTblExportCSVDataTable = new SelectKaikeiRendoTblExportCSVByKaikeiNoDataAccess().Execute(input).KaikeiRendoTblExportCSVDataTable;

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
