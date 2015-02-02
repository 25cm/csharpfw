using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetUserFunctionByShokuinCdALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetUserFunctionByShokuinCdALInput : IBseALInput, IGetUserFunctionByShokuinCdBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetUserFunctionByShokuinCdALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetUserFunctionByShokuinCdALInput : IGetUserFunctionByShokuinCdALInput
    {
        /// <summary>
        /// 職員コード 
        /// </summary>
        public string ShokuinCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetUserFunctionByShokuinCdALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetUserFunctionByShokuinCdALOutput : IGetUserFunctionByShokuinCdBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetUserFunctionByShokuinCdALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetUserFunctionByShokuinCdALOutput : IGetUserFunctionByShokuinCdALOutput
    {
        /// <summary>
        /// UserFunctionDataTable
        /// </summary>
        public FunctionMstDataSet.UserFunctionDataTable UserFunction { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetUserFunctionByShokuinCdApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetUserFunctionByShokuinCdApplicationLogic : BaseApplicationLogic<IGetUserFunctionByShokuinCdALInput, IGetUserFunctionByShokuinCdALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "共通処理機能：GetUserFunctionByShokuinCdApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetUserFunctionByShokuinCdApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetUserFunctionByShokuinCdApplicationLogic()
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
        /// 2014/12/18  豊田　　    新規作成
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
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetUserFunctionByShokuinCdALOutput Execute(IGetUserFunctionByShokuinCdALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetUserFunctionByShokuinCdALOutput output = new GetUserFunctionByShokuinCdALOutput();

            try
            {
                IGetUserFunctionByShokuinCdBLOutput blOutput = new GetUserFunctionByShokuinCdBusinessLogic().Execute(input);
                output.UserFunction = blOutput.UserFunction;
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
