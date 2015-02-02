using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuNyukinTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetIsExistNyukinByNyukinNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/28  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetIsExistNyukinByNyukinNoBLInput : ISelectIsExistNyukinByNyukinNoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetIsExistNyukinByNyukinNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/28  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetIsExistNyukinByNyukinNoBLInput : IGetIsExistNyukinByNyukinNoBLInput
    {
        /// <summary>
        /// 入金No
        /// </summary>
        public string NyukinNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetIsExistNyukinByNyukinNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/28  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetIsExistNyukinByNyukinNoBLOutput : ISelectIsExistNyukinByNyukinNoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetIsExistNyukinByNyukinNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/28  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetIsExistNyukinByNyukinNoBLOutput : IGetIsExistNyukinByNyukinNoBLOutput
    {
        /// <summary>
        /// 分割入金有無
        /// </summary>
        public int? IsExistNyukin { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetIsExistNyukinByNyukinNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/28  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetIsExistNyukinByNyukinNoBusinessLogic : BaseBusinessLogic<IGetIsExistNyukinByNyukinNoBLInput, IGetIsExistNyukinByNyukinNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetIsExistNyukinByNyukinNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/28  豊田  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetIsExistNyukinByNyukinNoBusinessLogic()
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
        /// 2014/12/28  豊田  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetIsExistNyukinByNyukinNoBLOutput Execute(IGetIsExistNyukinByNyukinNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetIsExistNyukinByNyukinNoBLOutput output = new GetIsExistNyukinByNyukinNoBLOutput();

            try
            {
                output.IsExistNyukin = new SelectIsExistNyukinByNyukinNoDataAccess().Execute(input).IsExistNyukin;

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
