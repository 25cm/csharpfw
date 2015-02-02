using System.Reflection;
using FukjBizSystem.Application.DataAccess.FunctionMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetUserFunctionByShokuinCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田     　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetUserFunctionByShokuinCdBLInput : ISelectUserFunctionByShokuinCdDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetUserFunctionByShokuinCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田     　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetUserFunctionByShokuinCdBLInput : IGetUserFunctionByShokuinCdBLInput
    {
        /// <summary>
        /// 職員コード 
        /// </summary>
        public string ShokuinCd { get; set; }
    }

    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetUserFunctionByShokuinCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田     　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetUserFunctionByShokuinCdBLOutput : ISelectUserFunctionByShokuinCdDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetUserFunctionByShokuinCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田     　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetUserFunctionByShokuinCdBLOutput : IGetUserFunctionByShokuinCdBLOutput
    {
        /// <summary>
        /// UserFunctionDataTable
        /// </summary>
        public FunctionMstDataSet.UserFunctionDataTable UserFunction { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetUserFunctionByShokuinCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田     　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetUserFunctionByShokuinCdBusinessLogic : BaseBusinessLogic<IGetUserFunctionByShokuinCdBLInput, IGetUserFunctionByShokuinCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetUserFunctionByShokuinCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田     　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetUserFunctionByShokuinCdBusinessLogic()
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
        /// 2014/12/18  豊田     　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetUserFunctionByShokuinCdBLOutput Execute(IGetUserFunctionByShokuinCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetUserFunctionByShokuinCdBLOutput output = new GetUserFunctionByShokuinCdBLOutput();

            try
            {
                output.UserFunction = new SelectUserFunctionByShokuinCdDataAccess().Execute(input).UserFunction;
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
