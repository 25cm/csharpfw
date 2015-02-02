using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiMstBySearchCondBLInput : ISelectShoriHoshikiMstBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiMstBySearchCondBLInput : IGetShoriHoshikiMstBySearchCondBLInput
    {
        /// <summary>
        /// 処理方式区分（開始）
        /// </summary>
        public String ShoriHoshikiKbnFrom { get; set; }

        /// <summary>
        /// 処理方式区分（終了）
        /// </summary>
        public String ShoriHoshikiKbnTo { get; set; }

        /// <summary>
        /// 処理方式コード（開始）
        /// </summary>
        public String ShoriHoshikiCdFrom { get; set; }

        /// <summary>
        /// 処理方式コード（終了）
        /// </summary>
        public String ShoriHoshikiCdTo { get; set; }

        /// <summary>
        /// 処理方式種別名
        /// </summary>
        public String ShoriHoshikiShubetsuNm { get; set; }

        /// <summary>
        /// 処理方式名
        /// </summary>
        public String ShoriHoshikiNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiMstBySearchCondBLOutput : ISelectShoriHoshikiMstBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiMstBySearchCondBLOutput : IGetShoriHoshikiMstBySearchCondBLOutput
    {
        /// <summary>
        /// ShoriHoshikiMstKensakuDataTable
        /// </summary>
        public ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable ShoriHoshikiMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetShoriHoshikiMstBySearchCondBLInput, IGetShoriHoshikiMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShoriHoshikiMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShoriHoshikiMstBySearchCondBusinessLogic()
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShoriHoshikiMstBySearchCondBLOutput Execute(IGetShoriHoshikiMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShoriHoshikiMstBySearchCondBLOutput output = new GetShoriHoshikiMstBySearchCondBLOutput();

            try
            {
                output.ShoriHoshikiMstKensakuDT = new SelectShoriHoshikiMstBySearchCondDataAccess().Execute(input).ShoriHoshikiMstKensakuDT;
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
