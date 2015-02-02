using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiSyukei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLInput
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
    interface IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLInput : ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLInput
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
    class GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLInput : IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput
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
    interface IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput : ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput
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
    class GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput : IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinHiShukeiTblDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBusinessLogic
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
    class GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBusinessLogic : BaseBusinessLogic<IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLInput, IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBusinessLogic
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
        public GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBusinessLogic()
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
        public override IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput Execute(IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput output = new GetKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtBLOutput();

            try
            {
                output.KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT = new SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDataAccess().Execute(input).KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT;
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
