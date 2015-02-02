using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KatashikiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKatashikiMstBySearchCondBLInput : ISelectKatashikiMstBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiMstBySearchCondBLInput : IGetKatashikiMstBySearchCondBLInput
    {
        /// <summary>
        /// メーカー業者コード（開始）
        /// </summary>
        public String KatashikiMakerCdFrom { get; set; }

        /// <summary>
        /// メーカー業者コード（終了）
        /// </summary>
        public String KatashikiMakerCdTo { get; set; }

        /// <summary>
        /// メーカー業者名称
        /// </summary>
        public String GyoshaNm { get; set; }

        /// <summary>
        /// 型式コード（開始）
        /// </summary>
        public String KatashikiCdFrom { get; set; }

        /// <summary>
        /// 型式コード（終了）
        /// </summary>
        public String KatashikiCdTo { get; set; }

        /// <summary>
        /// 型式名称
        /// </summary>
        public String KatashikiNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKatashikiMstBySearchCondBLOutput : ISelectKatashikiMstBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiMstBySearchCondBLOutput : IGetKatashikiMstBySearchCondBLOutput
    {
        /// <summary>
        /// KatashikiMstKensakuDataTable
        /// </summary>
        public KatashikiMstDataSet.KatashikiMstKensakuDataTable KatashikiMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetKatashikiMstBySearchCondBLInput, IGetKatashikiMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKatashikiMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKatashikiMstBySearchCondBusinessLogic()
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
        /// 2014/07/03  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKatashikiMstBySearchCondBLOutput Execute(IGetKatashikiMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKatashikiMstBySearchCondBLOutput output = new GetKatashikiMstBySearchCondBLOutput();

            try
            {
                output.KatashikiMstKensakuDT = new SelectKatashikiMstBySearchCondDataAccess().Execute(input).KatashikiMstKensakuDT;
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
