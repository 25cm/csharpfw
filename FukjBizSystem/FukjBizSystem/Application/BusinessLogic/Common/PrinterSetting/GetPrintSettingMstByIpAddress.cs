using System.Reflection;
using FukjBizSystem.Application.DataAccess.PrintSettingMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common.PrinterSetting
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetPrintSettingMstByIpAddressBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetPrintSettingMstByIpAddressBLInput : ISelectPrintSettingMstByIpAddressDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByIpAddressBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetPrintSettingMstByIpAddressBLInput : IGetPrintSettingMstByIpAddressBLInput
    {
        /// <summary>
        /// IpAddress
        /// </summary>
        public string IpAddress { get; set; }

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetPrintSettingMstByIpAddressBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetPrintSettingMstByIpAddressBLOutput : ISelectPrintSettingMstByIpAddressDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByIpAddressBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetPrintSettingMstByIpAddressBLOutput : IGetPrintSettingMstByIpAddressBLOutput
    {
        /// <summary>
        /// PrintSettingMstDt
        /// </summary>
        public PrintSettingMstDataSet.PrintSettingMstDataTable PrintSettingMstDt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByIpAddressBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetPrintSettingMstByIpAddressBusinessLogic : BaseBusinessLogic<IGetPrintSettingMstByIpAddressBLInput, IGetPrintSettingMstByIpAddressBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetPrintSettingMstByIpAddressBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetPrintSettingMstByIpAddressBusinessLogic()
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
        /// 2014/12/16  豊田    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetPrintSettingMstByIpAddressBLOutput Execute(IGetPrintSettingMstByIpAddressBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetPrintSettingMstByIpAddressBLOutput output = new GetPrintSettingMstByIpAddressBLOutput();

            try
            {
                output.PrintSettingMstDt = new SelectPrintSettingMstByIpAddressDataAccess().Execute(input).PrintSettingMstDt;
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
