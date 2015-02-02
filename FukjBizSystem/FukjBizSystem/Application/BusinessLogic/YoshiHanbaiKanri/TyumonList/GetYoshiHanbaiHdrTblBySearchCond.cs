using System.Reflection;
using FukjBizSystem.Application.DataAccess.YoshiHanbaiHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYoshiHanbaiHdrTblBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYoshiHanbaiHdrTblBySearchCondBLInput : ISelectYoshiHanbaiHdrTblBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiHanbaiHdrTblBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiHanbaiHdrTblBySearchCondBLInput : IGetYoshiHanbaiHdrTblBySearchCondBLInput
    {
        /// <summary>
        /// GyoshaCd
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// YoshiHanbaiChumonNoFrom
        /// </summary>
        public string YoshiHanbaiChumonNoFrom { get; set; }

        /// <summary>
        /// YoshiHanbaiChumonNoTo
        /// </summary>
        public string YoshiHanbaiChumonNoTo { get; set; }

        /// <summary>
        /// YoshiHanbaiDtFrom
        /// </summary>
        public string YoshiHanbaiDtFrom { get; set; }

        /// <summary>
        /// YoshiHanbaiDtTo
        /// </summary>
        public string YoshiHanbaiDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYoshiHanbaiHdrTblBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYoshiHanbaiHdrTblBySearchCondBLOutput : ISelectYoshiHanbaiHdrTblBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiHanbaiHdrTblBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiHanbaiHdrTblBySearchCondBLOutput : IGetYoshiHanbaiHdrTblBySearchCondBLOutput
    {
        /// <summary>
        /// YoshiHanbaiHdrTblKensakuDT
        /// </summary>
        public YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblKensakuDataTable YoshiHanbaiHdrTblKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiHanbaiHdrTblBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiHanbaiHdrTblBySearchCondBusinessLogic : BaseBusinessLogic<IGetYoshiHanbaiHdrTblBySearchCondBLInput, IGetYoshiHanbaiHdrTblBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYoshiHanbaiHdrTblBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYoshiHanbaiHdrTblBySearchCondBusinessLogic()
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
        /// 2014/07/23　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYoshiHanbaiHdrTblBySearchCondBLOutput Execute(IGetYoshiHanbaiHdrTblBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetYoshiHanbaiHdrTblBySearchCondBLOutput output = new GetYoshiHanbaiHdrTblBySearchCondBLOutput();

            try
            {
                output.YoshiHanbaiHdrTblKensakuDT = new SelectYoshiHanbaiHdrTblBySearchCondDataAccess().Execute(input).YoshiHanbaiHdrTblKensakuDT;

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
