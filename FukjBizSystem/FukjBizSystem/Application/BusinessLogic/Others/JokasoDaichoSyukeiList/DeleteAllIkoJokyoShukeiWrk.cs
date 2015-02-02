using System.Reflection;
using FukjBizSystem.Application.DataAccess.IkoJokyoShukeiWrk;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllIkoJokyoShukeiWrkBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteAllIkoJokyoShukeiWrkBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllIkoJokyoShukeiWrkBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllIkoJokyoShukeiWrkBLInput : IDeleteAllIkoJokyoShukeiWrkBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllIkoJokyoShukeiWrkBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteAllIkoJokyoShukeiWrkBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllIkoJokyoShukeiWrkBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllIkoJokyoShukeiWrkBLOutput : IDeleteAllIkoJokyoShukeiWrkBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllIkoJokyoShukeiWrkBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllIkoJokyoShukeiWrkBusinessLogic : BaseBusinessLogic<IDeleteAllIkoJokyoShukeiWrkBLInput, IDeleteAllIkoJokyoShukeiWrkBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteAllIkoJokyoShukeiWrkBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/28  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteAllIkoJokyoShukeiWrkBusinessLogic()
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
        /// 2014/10/28  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteAllIkoJokyoShukeiWrkBLOutput Execute(IDeleteAllIkoJokyoShukeiWrkBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteAllIkoJokyoShukeiWrkBLOutput output = new DeleteAllIkoJokyoShukeiWrkBLOutput();

            try
            {
                IDeleteAllIkoJokyoShukeiWrkDAInput daInput = new DeleteAllIkoJokyoShukeiWrkDAInput();
                new DeleteAllIkoJokyoShukeiWrkDataAccess().Execute(daInput);

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
