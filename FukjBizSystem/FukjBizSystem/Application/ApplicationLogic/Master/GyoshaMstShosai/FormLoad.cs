using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.BushoMstList;
using FukjBizSystem.Application.BusinessLogic.Master.GyoshaMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.GyoshaMstShosai
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        string GyoshaCd { get; set; }
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("業者コード[{0}]", GyoshaCd);
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// 定数マスタ
        /// </summary>
        ConstMstDataSet.ConstMstDataTable ConstMstDataTable { get; set; }

        /// <summary>
        /// 業者マスタ
        /// </summary>
        GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        /// <summary>
        /// 業者マスタ
        /// </summary>
        GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstInfoDataTable { get; set; }

        /// <summary>
        /// 業者部会マスタ
        /// </summary>
        GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable GyoshaBukaiMstDataTable { get; set; }

        /// <summary>
        /// 業者営業地区マスタ
        /// </summary>
        GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable GyoshaEigyoChikuMstDataTable { get; set; }

        /// <summary>
        /// 業者営業所マスタ
        /// </summary>
        GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstDataTable GyoshaEigyoshoMstDataTable { get; set; }
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// 定数マスタ
        /// </summary>
        public ConstMstDataSet.ConstMstDataTable ConstMstDataTable { get; set; }

        /// <summary>
        /// 業者マスタ
        /// </summary>
        public GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        /// <summary>
        /// 業者マスタ
        /// </summary>
        public GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstInfoDataTable { get; set; }

        /// <summary>
        /// 業者部会マスタ
        /// </summary>
        public GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable GyoshaBukaiMstDataTable { get; set; }

        /// <summary>
        /// 業者営業地区マスタ
        /// </summary>
        public GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable GyoshaEigyoChikuMstDataTable { get; set; }

        /// <summary>
        /// 業者営業所マスタ
        /// </summary>
        public GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstDataTable GyoshaEigyoshoMstDataTable { get; set; }
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "GyoshaMstShosai：FormLoad";

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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Get ConstMst by NameKbn
                IGetConstMstByKbnBLInput constInput = new GetConstMstByKbnBLInput();
                constInput.ConstKbn = Utility.Constants.ConstKbnConstanst.CONST_KBN_002;
                IGetConstMstByKbnBLOutput constOutput = new GetConstMstByKbnBusinessLogic().Execute(constInput);
                output.ConstMstDataTable = constOutput.DataTable;

                // Display mode
                if (!string.IsNullOrEmpty(input.GyoshaCd))
                {
                    // Get GyoshaMst by key
                    IGetGyoshaMstByKeyBLInput gyoshaInp = new GetGyoshaMstByKeyBLInput();
                    gyoshaInp.GyoshaCd = input.GyoshaCd;
                    IGetGyoshaMstByKeyBLOutput gyoshaOutp = new GetGyoshaMstByKeyBusinessLogic().Execute(gyoshaInp);

                    // Get GyoshaEigyoshoMst by GyoshaCd
                    IGetGyoshaEigyoshoMstByGyoshaCdBLInput eigyoInp = new GetGyoshaEigyoshoMstByGyoshaCdBLInput();
                    eigyoInp.GyoshaCd = input.GyoshaCd;
                    IGetGyoshaEigyoshoMstByGyoshaCdBLOutput eigyoOutp = new GetGyoshaEigyoshoMstByGyoshaCdBusinessLogic().Execute(eigyoInp);

                    // Get GyoshaEigyoChikuMst by GyoshaCd
                    IGetGyoshaEigyoChikuMstByGyoshaCdBLInput chikuInp = new GetGyoshaEigyoChikuMstByGyoshaCdBLInput();
                    chikuInp.GyoshaCd = input.GyoshaCd;
                    IGetGyoshaEigyoChikuMstByGyoshaCdBLOutput chikuOutp = new GetGyoshaEigyoChikuMstByGyoshaCdBusinessLogic().Execute(chikuInp);

                    // Get GyoshaBukaiMst by GyoshaCd
                    IGetGyoshaBukaiMstByGyoshaCdBLInput bukaiInp = new GetGyoshaBukaiMstByGyoshaCdBLInput();
                    bukaiInp.GyoshaCd = input.GyoshaCd;
                    IGetGyoshaBukaiMstByGyoshaCdBLOutput bukaiOutp = new GetGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(bukaiInp);

                    // Output
                    output.GyoshaMstDataTable = gyoshaOutp.GyoshaMstDataTable;
                    output.GyoshaBukaiMstDataTable = bukaiOutp.GyoshaBukaiMstDataTable;
                    output.GyoshaEigyoChikuMstDataTable = chikuOutp.GyoshaEigyoChikuMstDataTable;
                    output.GyoshaEigyoshoMstDataTable = eigyoOutp.GyoshaEigyoshoMstDataTable;
                }

                // Get GyoshaMst info
                IGetGyoshaMstInfoBLOutput infoOutput = new GetGyoshaMstInfoBusinessLogic().Execute(new GetGyoshaMstInfoBLInput());
                output.GyoshaMstInfoDataTable = infoOutput.GyoshaMstDataTable;
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
