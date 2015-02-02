using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KiansyaSelect;
using FukjBizSystem.Application.BusinessLogic.Master.BushoMstShosai;
using FukjBizSystem.Application.BusinessLogic.Master.ShishoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.BusinessLogic.Master.ShozokuMstShosai;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KiansyaSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
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
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// ShokuinCd
        /// </summary>
        string ShokuinCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
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
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// ShokuinCd
        /// </summary>
        public string ShokuinCd { get; set; }

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
    //  インターフェイス名 ： IFormLoadALOutput
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
    interface IFormLoadALOutput
    {
        /// <summary>
        /// ShishoMstDataTable
        /// </summary>
        ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// BushoMstDataTable
        /// </summary>
        BushoMstDataSet.BushoMstDataTable BushoMstDataTable { get; set; }

        /// <summary>
        /// ShokuinMstDataTable
        /// </summary>
        ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// ShozokuMstDataTable
        /// </summary>
        ShozokuMstDataSet.ShozokuMstDataTable ShozokuMstDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
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
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// ShishoMstDataTable
        /// </summary>
        public ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// BushoMstDataTable
        /// </summary>
        public BushoMstDataSet.BushoMstDataTable BushoMstDataTable { get; set; }

        /// <summary>
        /// ShokuinMstDataTable
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// ShozokuMstDataTable
        /// </summary>
        public ShozokuMstDataSet.ShozokuMstDataTable ShozokuMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
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
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KiansyaSelect：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
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
        public FormLoadApplicationLogic()
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
        /// 2014/08/29  HuyTX　　    新規作成
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
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                //get ShishoMst
                IGetShishoMstInfoBLInput getShishoBLInput = new GetShishoMstInfoBLInput();
                output.ShishoMstDataTable = new GetShishoMstInfoBusinessLogic().Execute(getShishoBLInput).ShishoMstDT;

                //get BushoMst
                IGetBushoMstInfoBLInput getBushoBLInput = new GetBushoMstInfoBLInput();
                output.BushoMstDataTable = new GetBushoMstInfoBusinessLogic().Execute(getBushoBLInput).BushoMstDT;

                //get ShokuinMst
                IGetShokuinMstInfoBLInput getShokuinBLInput = new GetShokuinMstInfoBLInput();
                // 2015/01/29 YSCHEW ADD Start
                getShokuinBLInput.ShokuinTaishokuFlg = "0";
                // 2015/01/29 YSCHEW ADD end
                output.ShokuinMstDataTable = new GetShokuinMstInfoBusinessLogic().Execute(getShokuinBLInput).ShokuinMstDataTable;

                //get ShozokuMst
                IGetShozokuMstByShokuinCdBLInput getShozokuBLInput = new GetShozokuMstByShokuinCdBLInput();
                getShozokuBLInput.ShokuinCd = input.ShokuinCd;
                output.ShozokuMstDataTable = new GetShozokuMstByShokuinCdBusinessLogic().Execute(getShozokuBLInput).ShozokuMstDT;

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
