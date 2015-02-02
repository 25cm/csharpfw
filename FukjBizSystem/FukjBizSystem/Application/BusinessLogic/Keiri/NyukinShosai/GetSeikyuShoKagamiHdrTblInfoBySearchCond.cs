using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyusyoKagamiHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput
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
    interface IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput : ISelectSeikyuShoKagamiHdrTblInfoBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput
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
    class GetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput : IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public SeikyushoKagamiHdrSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput
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
    interface IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput : ISelectSeikyuShoKagamiHdrTblInfoBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput
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
    class GetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput : IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput
    {
        /// <summary>
        /// SeikyushoKagamiHdrInfoDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable SeikyushoKagamiHdrInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShoKagamiHdrTblInfoBySearchCondBusinessLogic
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
    class GetSeikyuShoKagamiHdrTblInfoBySearchCondBusinessLogic : BaseBusinessLogic<IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput, IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuShoKagamiHdrTblInfoBySearchCondBusinessLogic
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
        public GetSeikyuShoKagamiHdrTblInfoBySearchCondBusinessLogic()
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
        public override IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput Execute(IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput output = new GetSeikyuShoKagamiHdrTblInfoBySearchCondBLOutput();

            try
            {
                output.SeikyushoKagamiHdrInfoDataTable = new SelectSeikyuShoKagamiHdrTblInfoBySearchCondDataAccess().Execute(input).SeikyushoKagamiHdrInfoDataTable;

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
