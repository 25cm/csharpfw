using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.TaniSoshiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTaniSochiListByMakerCdKatashikiCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetTaniSochiListByMakerCdKatashikiCdBLInput : ISelectTaniSochiListByMakerCdKatashikiCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiListByMakerCdKatashikiCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetTaniSochiListByMakerCdKatashikiCdBLInput : IGetTaniSochiListByMakerCdKatashikiCdBLInput
    {
        /// <summary>
        /// KatashikiMakerCd
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// KatashikiCd
        /// </summary>
        public String KatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTaniSochiListByMakerCdKatashikiCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetTaniSochiListByMakerCdKatashikiCdBLOutput : ISelectTaniSochiListByMakerCdKatashikiCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiListByMakerCdKatashikiCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetTaniSochiListByMakerCdKatashikiCdBLOutput : IGetTaniSochiListByMakerCdKatashikiCdBLOutput
    {
        /// <summary>
        /// TaniSochiListDataTable
        /// </summary>
        public TaniSochiMstDataSet.TaniSochiListDataTable TaniSochiListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiListByMakerCdKatashikiCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetTaniSochiListByMakerCdKatashikiCdBusinessLogic : BaseBusinessLogic<IGetTaniSochiListByMakerCdKatashikiCdBLInput, IGetTaniSochiListByMakerCdKatashikiCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetTaniSochiListByMakerCdKatashikiCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetTaniSochiListByMakerCdKatashikiCdBusinessLogic()
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
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetTaniSochiListByMakerCdKatashikiCdBLOutput Execute(IGetTaniSochiListByMakerCdKatashikiCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetTaniSochiListByMakerCdKatashikiCdBLOutput output = new GetTaniSochiListByMakerCdKatashikiCdBLOutput();

            try
            {
                output.TaniSochiListDT = new SelectTaniSochiListByMakerCdKatashikiCdDataAccess().Execute(input).TaniSochiListDT;
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
