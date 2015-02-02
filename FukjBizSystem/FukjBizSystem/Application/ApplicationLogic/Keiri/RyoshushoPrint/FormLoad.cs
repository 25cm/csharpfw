using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.RyoshushoPrint;
using FukjBizSystem.Application.BusinessLogic.Master.NameMstEditList;
using FukjBizSystem.Application.BusinessLogic.Master.ShishoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.RyoshushoPrint
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
    /// 2014/09/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput/*, IGetRyushushoPrintByCondBLInput*/
    {
        
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
    /// 2014/09/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        ///// <summary>
        ///// RyushushoPrint search cond
        ///// </summary>
        //public RyoshushoPrintData SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                //return string.Format("注文番号[{0}]", SearchCond.YoshiHanbaiChumonNo);
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
    /// 2014/09/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// 職員マスタ
        /// </summary>
        ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// 支所マスタ
        /// </summary>
        ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// 名称マスタ
        /// </summary>
        NameMstDataSet.NameMstDataTable NameMstDataTable { get; set; }

        ///// <summary>
        ///// RyushushoPrintDataTable
        ///// </summary>
        //YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable RyushushoPrintDataTable { get; set; }
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
    /// 2014/09/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// 職員マスタ
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// 支所マスタ
        /// </summary>
        public ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// 名称マスタ
        /// </summary>
        public NameMstDataSet.NameMstDataTable NameMstDataTable { get; set; }

        ///// <summary>
        ///// RyushushoPrintDataTable
        ///// </summary>
        //public YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable RyushushoPrintDataTable { get; set; }
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
    /// 2014/09/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "RyushushoPrintForm：FormLoad";

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
        /// 2014/09/26　AnhNV　　    新規作成
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
        /// 2014/09/26　AnhNV　　    新規作成
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
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Get list of 職員マスタ
                //IGetShokuinMstInfoBLOutput shokuinOutput = new GetShokuinMstInfoBusinessLogic().Execute(new GetShokuinMstInfoBLInput());
                //output.ShokuinMstDataTable = shokuinOutput.ShokuinMstDataTable;
                IGetShokuinMstByShokuinTaishokuFlgBLInput shokuinInput = new GetShokuinMstByShokuinTaishokuFlgBLInput();
                shokuinInput.ShokuinTaishokuFlg = "0";
                output.ShokuinMstDataTable = new IGetShokuinMstByShokuinTaishokuFlgBusinessLogic().Execute(shokuinInput).ShokuinMstDT;

                // Get list of 支所マスタ
                IGetShishoMstInfoBLOutput shishoOutput = new GetShishoMstInfoBusinessLogic().Execute(new GetShishoMstInfoBLInput());
                output.ShishoMstDataTable = shishoOutput.ShishoMstDT;

                // Get list of 名称マスタ
                IGetNameMstByNameKbnBLInput nameInput = new GetNameMstByNameKbnBLInput();
                nameInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_006;
                IGetNameMstByNameKbnBLOutput nameOutput = new GetNameMstByNameKbnBusinessLogic().Execute(nameInput);
                output.NameMstDataTable = nameOutput.NameMstDT;

                //if (null != input.SearchCond && !string.IsNullOrEmpty(input.SearchCond.YoshiHanbaiChumonNo))
                //{
                //    IGetRyushushoPrintByCondBLInput ryuInput = new GetRyushushoPrintByCondBLInput();
                //    ryuInput.SearchCond = input.SearchCond;
                //    IGetRyushushoPrintByCondBLOutput ryuOutput = new GetRyushushoPrintByCondBusinessLogic().Execute(ryuInput);
                //    output.RyushushoPrintDataTable = ryuOutput.RyushushoPrintDataTable;
                //}
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
