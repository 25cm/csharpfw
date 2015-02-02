using System.Reflection;
using FukjBizSystem.Application.DataAccess.KurikoshiKinTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaxKurikoshiKinNoBLInput
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
    interface IGetMaxKurikoshiKinNoBLInput : ISelectMaxKurikoshiKinNoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxKurikoshiKinNoBLInput
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
    class GetMaxKurikoshiKinNoBLInput : IGetMaxKurikoshiKinNoBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaxKurikoshiKinNoBLOutput
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
    interface IGetMaxKurikoshiKinNoBLOutput : ISelectMaxKurikoshiKinNoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxKurikoshiKinNoBLOutput
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
    class GetMaxKurikoshiKinNoBLOutput : IGetMaxKurikoshiKinNoBLOutput
    {
        /// <summary>
        /// MaxKurikoshikinNo
        /// </summary>
        public string MaxKurikoshikinNo { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxKurikoshiKinNoBusinessLogic
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
    class GetMaxKurikoshiKinNoBusinessLogic : BaseBusinessLogic<IGetMaxKurikoshiKinNoBLInput, IGetMaxKurikoshiKinNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMaxKurikoshiKinNoBusinessLogic
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
        public GetMaxKurikoshiKinNoBusinessLogic()
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
        public override IGetMaxKurikoshiKinNoBLOutput Execute(IGetMaxKurikoshiKinNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMaxKurikoshiKinNoBLOutput output = new GetMaxKurikoshiKinNoBLOutput();

            try
            {
                output.MaxKurikoshikinNo = new SelectMaxKurikoshiKinNoDataAccess().Execute(input).MaxKurikoshikinNo;

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
