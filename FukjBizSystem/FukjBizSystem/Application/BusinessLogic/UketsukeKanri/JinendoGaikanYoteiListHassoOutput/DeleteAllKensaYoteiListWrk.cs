using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaYoteiListWrk;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanYoteiListHassoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllKensaYoteiListWrkBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteAllKensaYoteiListWrkBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllKensaYoteiListWrkBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllKensaYoteiListWrkBLInput : IDeleteAllKensaYoteiListWrkBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllKensaYoteiListWrkBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteAllKensaYoteiListWrkBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllKensaYoteiListWrkBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllKensaYoteiListWrkBLOutput : IDeleteAllKensaYoteiListWrkBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllKensaYoteiListWrkBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllKensaYoteiListWrkBusinessLogic : BaseBusinessLogic<IDeleteAllKensaYoteiListWrkBLInput, IDeleteAllKensaYoteiListWrkBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteAllKensaYoteiListWrkBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteAllKensaYoteiListWrkBusinessLogic()
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
        /// 2014/09/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteAllKensaYoteiListWrkBLOutput Execute(IDeleteAllKensaYoteiListWrkBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteAllKensaYoteiListWrkBLOutput output = new DeleteAllKensaYoteiListWrkBLOutput();

            try
            {
                IDeleteAllKensaYoteiListWrkDAInput deleteDAInput = new DeleteAllKensaYoteiListWrkDAInput();
                new DeleteAllKensaYoteiListWrkDataAccess().Execute(deleteDAInput);

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
