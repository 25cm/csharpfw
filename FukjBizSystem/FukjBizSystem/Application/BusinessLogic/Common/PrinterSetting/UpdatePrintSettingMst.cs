using System.Reflection;
using FukjBizSystem.Application.DataAccess.PrintSettingMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdatePrintSettingMstBLInput
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
    interface IUpdatePrintSettingMstBLInput : IUpdatePrintSettingMstDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdatePrintSettingMstBLInput
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
    class UpdatePrintSettingMstBLInput : IUpdatePrintSettingMstBLInput
    {
        /// <summary>
        /// PrintSettingMstDT
        /// </summary>
        public PrintSettingMstDataSet.PrintSettingMstDataTable PrintSettingMstDT { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdatePrintSettingMstBLOutput
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
    interface IUpdatePrintSettingMstBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdatePrintSettingMstBLOutput
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
    class UpdatePrintSettingMstBLOutput : IUpdatePrintSettingMstBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdatePrintSettingMstBusinessLogic
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
    class UpdatePrintSettingMstBusinessLogic : BaseBusinessLogic<IUpdatePrintSettingMstBLInput, IUpdatePrintSettingMstBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdatePrintSettingMstBusinessLogic
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
        public UpdatePrintSettingMstBusinessLogic()
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
        public override IUpdatePrintSettingMstBLOutput Execute(IUpdatePrintSettingMstBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdatePrintSettingMstBLOutput output = new UpdatePrintSettingMstBLOutput();

            try
            {
                new UpdatePrintSettingMstDataAccess().Execute(input);
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
