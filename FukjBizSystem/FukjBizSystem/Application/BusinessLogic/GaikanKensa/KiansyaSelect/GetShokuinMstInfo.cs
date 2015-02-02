using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShokuinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KiansyaSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokuinMstInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokuinMstInfoBLInput : ISelectShokuinMstInfoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokuinMstInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinMstInfoBLInput : IGetShokuinMstInfoBLInput
    {
        /// <summary>
        /// ShokuinTaishokuFlg
        /// </summary>
        public string ShokuinTaishokuFlg { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokuinMstInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokuinMstInfoBLOutput : ISelectShokuinMstInfoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokuinMstInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinMstInfoBLOutput : IGetShokuinMstInfoBLOutput
    {
        /// <summary>
        /// ShokuinMstDataTable
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokuinMstInfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinMstInfoBusinessLogic : BaseBusinessLogic<IGetShokuinMstInfoBLInput, IGetShokuinMstInfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShokuinMstInfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShokuinMstInfoBusinessLogic()
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
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShokuinMstInfoBLOutput Execute(IGetShokuinMstInfoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokuinMstInfoBLOutput output = new GetShokuinMstInfoBLOutput();

            try
            {
                // 2015/01/29 YSCHEW MOD Start
                if(string.IsNullOrEmpty(input.ShokuinTaishokuFlg))
                {
                    output.ShokuinMstDataTable = new SelectShokuinMstInfoDataAccess().Execute(input).ShokuinMstDataTable;
                }
                else{
                    SelectShokuinMstByShokuinTaishokuFlgDAInput taishokuFlgInput = new SelectShokuinMstByShokuinTaishokuFlgDAInput();
                    taishokuFlgInput.ShokuinTaishokuFlg = input.ShokuinTaishokuFlg;
                    output.ShokuinMstDataTable = new SelectShokuinMstByShokuinTaishokuFlgDataAccess().Execute(taishokuFlgInput).ShokuinMstDT;
                }
                // 2015/01/29 YSCHEW MOD End


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
