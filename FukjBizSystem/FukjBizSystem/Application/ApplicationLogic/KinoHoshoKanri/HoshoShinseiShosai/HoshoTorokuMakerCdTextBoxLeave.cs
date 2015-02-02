using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.GyoshaMstList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IHoshoTorokuMakerCdTextBoxLeaveALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IHoshoTorokuMakerCdTextBoxLeaveALInput : IBseALInput, IGetGyoshaMstBySearchCondBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoTorokuMakerCdTextBoxLeaveALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HoshoTorokuMakerCdTextBoxLeaveALInput : IHoshoTorokuMakerCdTextBoxLeaveALInput
    {
        /// <summary>
        /// GyoshaMstSearchCond
        /// </summary>
        public GyoshaMstSearchCond GyoshaMstSearchCond { get; set; }

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
    //  インターフェイス名 ： IHoshoTorokuMakerCdTextBoxLeaveALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IHoshoTorokuMakerCdTextBoxLeaveALOutput : IGetGyoshaMstBySearchCondBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoTorokuMakerCdTextBoxLeaveALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HoshoTorokuMakerCdTextBoxLeaveALOutput : IHoshoTorokuMakerCdTextBoxLeaveALOutput
    {
        /// <summary>
        /// GyoshaMstKensakuDT
        /// </summary>
        public GyoshaMstDataSet.GyoshaMstKensakuDataTable GyoshaMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoTorokuMakerCdTextBoxLeaveApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HoshoTorokuMakerCdTextBoxLeaveApplicationLogic : BaseApplicationLogic<IHoshoTorokuMakerCdTextBoxLeaveALInput, IHoshoTorokuMakerCdTextBoxLeaveALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoshoShinseiShosai：HoshoTorokuMakerCdTextBoxLeave";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HoshoTorokuMakerCdTextBoxLeaveApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HoshoTorokuMakerCdTextBoxLeaveApplicationLogic()
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
        /// 2015/01/21　AnhNV　　    新規作成
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
        /// 2015/01/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IHoshoTorokuMakerCdTextBoxLeaveALOutput Execute(IHoshoTorokuMakerCdTextBoxLeaveALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IHoshoTorokuMakerCdTextBoxLeaveALOutput output = new HoshoTorokuMakerCdTextBoxLeaveALOutput();

            try
            {
                IGetGyoshaMstBySearchCondBLOutput blOutput = new GetGyoshaMstBySearchCondBusinessLogic().Execute(input);
                output.GyoshaMstKensakuDT = blOutput.GyoshaMstKensakuDT;
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
