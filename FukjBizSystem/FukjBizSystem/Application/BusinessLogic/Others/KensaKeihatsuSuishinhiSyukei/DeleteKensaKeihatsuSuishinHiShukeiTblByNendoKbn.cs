using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiSyukei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput : IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput : IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput
    {
        /// <summary>
        /// 年度 
        /// </summary>
        public string SuishinhiNendo { get; set; }

        /// <summary>
        /// 上下期区分
        /// </summary>
        public string KamiShimoKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput : IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput : IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic : BaseBusinessLogic<IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput, IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic()
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
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput Execute(IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput output = new DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput();

            try
            {
                new DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnDataAccess().Execute(input);
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
