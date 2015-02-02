using System.Reflection;
using FukjBizSystem.Application.DataAccess.PrintSettingMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common.PrinterSetting
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetPrintSettingMstByKeyBLInput
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
    interface IGetPrintSettingMstByKeyBLInput : ISelectPrintSettingMstByKeyDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByKeyBLInput
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
    class GetPrintSettingMstByKeyBLInput : IGetPrintSettingMstByKeyBLInput
    {
        /// <summary>
        /// IpAddress
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// PrintKbn
        /// </summary>
        public string PrintKbn { get; set; }
    }

    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetPrintSettingMstByKeyBLOutput
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
    interface IGetPrintSettingMstByKeyBLOutput : ISelectPrintSettingMstByKeyDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByKeyBLOutput
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
    class GetPrintSettingMstByKeyBLOutput : IGetPrintSettingMstByKeyBLOutput
    {
        /// <summary>
        /// PrintSettingMstDt
        /// </summary>
        public PrintSettingMstDataSet.PrintSettingMstDataTable PrintSettingMstDt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByKeyBusinessLogic
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
    class GetPrintSettingMstByKeyBusinessLogic : BaseBusinessLogic<IGetPrintSettingMstByKeyBLInput, IGetPrintSettingMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetPrintSettingMstByKeyBusinessLogic
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
        public GetPrintSettingMstByKeyBusinessLogic()
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
        public override IGetPrintSettingMstByKeyBLOutput Execute(IGetPrintSettingMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetPrintSettingMstByKeyBLOutput output = new GetPrintSettingMstByKeyBLOutput();

            try
            {
                output.PrintSettingMstDt = new SelectPrintSettingMstByKeyDataAccess().Execute(input).PrintSettingMstDt;
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
