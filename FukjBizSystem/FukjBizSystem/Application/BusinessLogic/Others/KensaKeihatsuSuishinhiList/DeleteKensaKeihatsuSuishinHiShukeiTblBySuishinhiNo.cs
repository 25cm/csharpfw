using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput : IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput : IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput
    {
        /// <summary>
        /// 推進費No
        /// </summary>
        public string SuishinhiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput : IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBusinessLogic : BaseBusinessLogic<IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput, IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBusinessLogic()
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
        /// 2014/10/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput Execute(IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput output = new DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput();

            try
            {
                new DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDataAccess().Execute(input);
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
