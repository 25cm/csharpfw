using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KatashikiBurowaMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput
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
    interface IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput : ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput
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
    class GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput : IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput
    {
        /// <summary>
        /// BurowaKatashikiMakerCd
        /// </summary>
        public String BurowaKatashikiMakerCd { get; set; }

        /// <summary>
        /// BurowaKatashikiCd
        /// </summary>
        public String BurowaKatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput
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
    interface IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput : ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput
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
    class GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput : IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput
    {
        /// <summary>
        /// KatashikiBurowaMstDataTable
        /// </summary>
        public KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable KatashikiBurowaMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic
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
    class GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic : BaseBusinessLogic<IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput, IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic
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
        public GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic()
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
        public override IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput Execute(IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput output = new GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput();

            try
            {
                output.KatashikiBurowaMstDT = new SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDataAccess().Execute(input).KatashikiBurowaMstDT;
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
