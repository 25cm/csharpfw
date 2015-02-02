using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KatashikiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKatashikiMstByKeyBLInput : ISelectKatashikiMstByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiMstByKeyBLInput : IGetKatashikiMstByKeyBLInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        public String KatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKatashikiMstByKeyBLOutput : ISelectKatashikiMstByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiMstByKeyBLOutput : IGetKatashikiMstByKeyBLOutput
    {
        /// <summary>
        /// KatashikiMstDataTable
        /// </summary>
        public KatashikiMstDataSet.KatashikiMstDataTable KatashikiMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiMstByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiMstByKeyBusinessLogic : BaseBusinessLogic<IGetKatashikiMstByKeyBLInput, IGetKatashikiMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKatashikiMstByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKatashikiMstByKeyBusinessLogic()
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKatashikiMstByKeyBLOutput Execute(IGetKatashikiMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKatashikiMstByKeyBLOutput output = new GetKatashikiMstByKeyBLOutput();

            try
            {
                output.KatashikiMstDT = new SelectKatashikiMstByKeyDataAccess().Execute(input).KatashikiMstDT;
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
