using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.SuishitsuMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuMstBySearchCondBLInput : ISelectSuishitsuMstBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuMstBySearchCondBLInput : IGetSuishitsuMstBySearchCondBLInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public String ShishoCd { get; set; }

        /// <summary>
        /// 水質コード FROM
        /// </summary>
        public String SuishitsuCdFrom { get; set; }

        /// <summary>
        /// 水質コード TO
        /// </summary>
        public String SuishitsuCdTo { get; set; }

        /// <summary>
        /// 水質名称
        /// </summary>
        public String SuishitsuNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuMstBySearchCondBLOutput : ISelectSuishitsuMstBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuMstBySearchCondBLOutput : IGetSuishitsuMstBySearchCondBLOutput
    {
        /// <summary>
        /// SuishitsuMstKensakuDataTable
        /// </summary>
        public SuishitsuMstDataSet.SuishitsuMstKensakuDataTable SuishitsuMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetSuishitsuMstBySearchCondBLInput, IGetSuishitsuMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuMstBySearchCondBusinessLogic()
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
        /// 2014/06/24  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuMstBySearchCondBLOutput Execute(IGetSuishitsuMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuMstBySearchCondBLOutput output = new GetSuishitsuMstBySearchCondBLOutput();

            try
            {
                output.SuishitsuMstKensakuDT = new SelectSuishitsuMstBySearchCondDataAccess().Execute(input).SuishitsuMstKensakuDT;
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
