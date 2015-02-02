using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShokuinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.RyoshushoPrint
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokuinMstByShokuinTaishokuFlgBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokuinMstByShokuinTaishokuFlgBLInput : ISelectShokuinMstByShokuinTaishokuFlgDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IGetShokuinMstByShokuinTaishokuFlgBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinMstByShokuinTaishokuFlgBLInput : IGetShokuinMstByShokuinTaishokuFlgBLInput
    {
        /// <summary>
        /// ShokuinTaishokuFlg
        /// </summary>
        public string ShokuinTaishokuFlg { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIGetShokuinMstByShokuinTaishokuFlgBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokuinMstByShokuinTaishokuFlgBLOutput : ISelectShokuinMstByShokuinTaishokuFlgDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IGetShokuinMstByShokuinTaishokuFlgBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinMstByShokuinTaishokuFlgBLOutput : IGetShokuinMstByShokuinTaishokuFlgBLOutput
    {
        /// <summary>
        /// ShokuinMstDataTable
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IGetShokuinMstByShokuinTaishokuFlgBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IGetShokuinMstByShokuinTaishokuFlgBusinessLogic : BaseBusinessLogic<IGetShokuinMstByShokuinTaishokuFlgBLInput, IGetShokuinMstByShokuinTaishokuFlgBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： IGetShokuinMstByShokuinTaishokuFlgBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public IGetShokuinMstByShokuinTaishokuFlgBusinessLogic()
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
        /// 2015/01/28　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShokuinMstByShokuinTaishokuFlgBLOutput Execute(IGetShokuinMstByShokuinTaishokuFlgBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokuinMstByShokuinTaishokuFlgBLOutput output = new GetShokuinMstByShokuinTaishokuFlgBLOutput();

            try
            {
                output.ShokuinMstDT = new SelectShokuinMstByShokuinTaishokuFlgDataAccess().Execute(input).ShokuinMstDT;
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
