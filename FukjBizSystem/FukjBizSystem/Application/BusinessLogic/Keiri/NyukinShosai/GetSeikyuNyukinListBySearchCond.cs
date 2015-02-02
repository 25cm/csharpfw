using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuNyukinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuNyukinListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuNyukinListBySearchCondBLInput : ISelectSeikyuNyukinListBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuNyukinListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuNyukinListBySearchCondBLInput : IGetSeikyuNyukinListBySearchCondBLInput
    {
        /// <summary>
        /// SearchCond
        /// </summary>
        public SeikyushoKagamiHdrSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuNyukinListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuNyukinListBySearchCondBLOutput : ISelectSeikyuNyukinListBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuNyukinListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuNyukinListBySearchCondBLOutput : IGetSeikyuNyukinListBySearchCondBLOutput
    {
        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        public SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuNyukinListBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuNyukinListBySearchCondBusinessLogic : BaseBusinessLogic<IGetSeikyuNyukinListBySearchCondBLInput, IGetSeikyuNyukinListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuNyukinListBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/13  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSeikyuNyukinListBySearchCondBusinessLogic()
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
        /// 2014/11/13  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSeikyuNyukinListBySearchCondBLOutput Execute(IGetSeikyuNyukinListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuNyukinListBySearchCondBLOutput output = new GetSeikyuNyukinListBySearchCondBLOutput();

            try
            {
                output.SeikyuNyukinTblListDataTable = new SelectSeikyuNyukinListBySearchCondDataAccess().Execute(input).SeikyuNyukinTblListDataTable;

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
