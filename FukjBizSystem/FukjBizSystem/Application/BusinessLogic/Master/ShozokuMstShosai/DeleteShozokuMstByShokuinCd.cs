using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShozokuMst;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShozokuMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShozokuMstByShokuinCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShozokuMstByShokuinCdBLInput : IDeleteShozokuMstByShokuinCdDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShozokuMstByShokuinCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShozokuMstByShokuinCdBLInput : IDeleteShozokuMstByShokuinCdBLInput
    {
        /// <summary>
        /// ShokuinCd
        /// </summary>
        public string ShokuinCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShozokuMstByShokuinCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShozokuMstByShokuinCdBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShozokuMstByShokuinCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShozokuMstByShokuinCdBLOutput : IDeleteShozokuMstByShokuinCdBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShozokuMstByShokuinCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShozokuMstByShokuinCdBusinessLogic : BaseBusinessLogic<IDeleteShozokuMstByShokuinCdBLInput, IDeleteShozokuMstByShokuinCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteShozokuMstByShokuinCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteShozokuMstByShokuinCdBusinessLogic()
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
        /// 2014/07/08　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteShozokuMstByShokuinCdBLOutput Execute(IDeleteShozokuMstByShokuinCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteShozokuMstByShokuinCdBLOutput output = new DeleteShozokuMstByShokuinCdBLOutput();

            try
            {
                new DeleteShozokuMstByShokuinCdDataAccess().Execute(input);
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
