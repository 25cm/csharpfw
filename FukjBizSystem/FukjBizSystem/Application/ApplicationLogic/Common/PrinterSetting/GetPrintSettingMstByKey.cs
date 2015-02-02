using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common.PrinterSetting;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Common.PrinterSetting
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetPrintSettingMstByKeyALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetPrintSettingMstByKeyALInput : IBseALInput, IGetPrintSettingMstByKeyBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByKeyALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetPrintSettingMstByKeyALInput : IGetPrintSettingMstByKeyALInput
    {
        /// <summary>
        /// IpAddress
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// PrintKbn
        /// </summary>
        public string PrintKbn { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetPrintSettingMstByKeyALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetPrintSettingMstByKeyALOutput : IGetPrintSettingMstByKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByKeyALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetPrintSettingMstByKeyALOutput : IGetPrintSettingMstByKeyALOutput
    {
        /// <summary>
        /// PrintSettingMstDt
        /// </summary>
        public PrintSettingMstDataSet.PrintSettingMstDataTable PrintSettingMstDt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetPrintSettingMstByKeyApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetPrintSettingMstByKeyApplicationLogic : BaseApplicationLogic<IGetPrintSettingMstByKeyALInput, IGetPrintSettingMstByKeyALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "共通処理機能：GetPrintSettingMstByKeyApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetPrintSettingMstByKeyApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetPrintSettingMstByKeyApplicationLogic()
        {
            
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/12/16  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetPrintSettingMstByKeyALOutput Execute(IGetPrintSettingMstByKeyALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetPrintSettingMstByKeyALOutput output = new GetPrintSettingMstByKeyALOutput();

            try
            {
                IGetPrintSettingMstByKeyBLOutput blOutput = new GetPrintSettingMstByKeyBusinessLogic().Execute(input);

                output.PrintSettingMstDt = blOutput.PrintSettingMstDt;
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
