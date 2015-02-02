using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.HokenjoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.HokenjoMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHokenjoMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHokenjoMstBySearchCondBLInput : ISelectHokenjoMstBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHokenjoMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHokenjoMstBySearchCondBLInput : IGetHokenjoMstBySearchCondBLInput
    {
        /// <summary>
        /// 保健所コード（開始）
        /// </summary>
        public String HokenjyoCdFrom { get; set; }

        /// <summary>
        /// 保健所コード（終了）
        /// </summary>
        public String HokenjyoCdTo { get; set; }

        /// <summary>
        /// 保健所名称
        /// </summary>
        public String HokenjyoNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHokenjoMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHokenjoMstBySearchCondBLOutput : ISelectHokenjoMstBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHokenjoMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHokenjoMstBySearchCondBLOutput : IGetHokenjoMstBySearchCondBLOutput
    {
        /// <summary>
        /// HokenjoMstKensakuDataTable
        /// </summary>
        public HokenjoMstDataSet.HokenjoMstKensakuDataTable HokenjoMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHokenjoMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHokenjoMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetHokenjoMstBySearchCondBLInput, IGetHokenjoMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHokenjoMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHokenjoMstBySearchCondBusinessLogic()
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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHokenjoMstBySearchCondBLOutput Execute(IGetHokenjoMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHokenjoMstBySearchCondBLOutput output = new GetHokenjoMstBySearchCondBLOutput();

            try
            {
                ISelectHokenjoMstBySearchCondDAInput daInput   = new SelectHokenjoMstBySearchCondDAInput();
                daInput.HokenjyoCdFrom                         = input.HokenjyoCdFrom;
                daInput.HokenjyoCdTo                           = input.HokenjyoCdTo;
                daInput.HokenjyoNm                             = input.HokenjyoNm;
                ISelectHokenjoMstBySearchCondDAOutput daOutput = new SelectHokenjoMstBySearchCondDataAccess().Execute(daInput);

                output.HokenjoMstKensakuDT                     = daOutput.HokenjoMstKensakuDT;

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
