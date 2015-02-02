using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaSetMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKensaSetMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKensaSetMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKensaSetMstBySearchCondBLInput : ISelectSuishitsuKensaSetMstBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaSetMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaSetMstBySearchCondBLInput : IGetSuishitsuKensaSetMstBySearchCondBLInput
    {
        /// <summary>
        /// セットコード（開始）
        /// </summary>
        public String SetCdFrom { get; set; }

        /// <summary>
        /// セットコード（終了）
        /// </summary>
        public String SetCdTo { get; set; }

        /// <summary>
        /// セット名称（正式）
        /// </summary>
        public String SetNm { get; set; }

        /// <summary>
        /// セット名称（略式）
        /// </summary>
        public String SetNmRyakusho { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKensaSetMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKensaSetMstBySearchCondBLOutput : ISelectSuishitsuKensaSetMstBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaSetMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaSetMstBySearchCondBLOutput : IGetSuishitsuKensaSetMstBySearchCondBLOutput
    {
        /// <summary>
        /// SuishitsuKensaSetMstKensakuDataTable
        /// </summary>
        public SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstKensakuDataTable SuishitsuKensaSetMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaSetMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaSetMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetSuishitsuKensaSetMstBySearchCondBLInput, IGetSuishitsuKensaSetMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuKensaSetMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuKensaSetMstBySearchCondBusinessLogic()
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
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuKensaSetMstBySearchCondBLOutput Execute(IGetSuishitsuKensaSetMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuKensaSetMstBySearchCondBLOutput output = new GetSuishitsuKensaSetMstBySearchCondBLOutput();

            try
            {
                output.SuishitsuKensaSetMstKensakuDT = new SelectSuishitsuKensaSetMstBySearchCondDataAccess().Execute(input).SuishitsuKensaSetMstKensakuDT;
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
