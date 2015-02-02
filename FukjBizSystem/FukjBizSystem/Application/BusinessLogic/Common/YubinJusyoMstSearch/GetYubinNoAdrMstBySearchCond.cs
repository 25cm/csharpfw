using System.Reflection;
using FukjBizSystem.Application.DataAccess.YubinNoAdrMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common.YubinJusyoMstSearch
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstBySearchCondBLInput : ISelectYubinNoAdrMstBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstBySearchCondBLInput : IGetYubinNoAdrMstBySearchCondBLInput
    {
        /// <summary>
        /// ZipCd
        /// </summary>
        public string ZipCd { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstBySearchCondBLOutput : ISelectYubinNoAdrMstBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstBySearchCondBLOutput : IGetYubinNoAdrMstBySearchCondBLOutput
    {
        /// <summary>
        /// YubinNoAdrMstDT
        /// </summary>
        public YubinNoAdrMstDataSet.YubinNoAdrMstKensakuDataTable YubinNoAdrMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetYubinNoAdrMstBySearchCondBLInput, IGetYubinNoAdrMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYubinNoAdrMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYubinNoAdrMstBySearchCondBusinessLogic()
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
        /// 2014/07/16　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYubinNoAdrMstBySearchCondBLOutput Execute(IGetYubinNoAdrMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetYubinNoAdrMstBySearchCondBLOutput output = new GetYubinNoAdrMstBySearchCondBLOutput();

            try
            {
                output.YubinNoAdrMstDT = new SelectYubinNoAdrMstBySearchCondDataAccess().Execute(input).YubinNoAdrMstDT;

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
