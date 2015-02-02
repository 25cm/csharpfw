using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.TuckSealList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.TuckSealList
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
    /// 2014/08/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetTuckSealListBySearchCondBLInput
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
    /// 2014/08/07　AnhNV　　   新規作成
    /// 2014/12/26　豊田　　    初期ロード時に浄化槽台帳マスタの検索を行わないよう変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// TuckSealSearchCond
        /// </summary>
        public TuckSealSearchCond SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("発行区分/業者[{0}]", "1");
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
    /// 2014/08/07　AnhNV　　    新規作成
    /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// 業者マスタ
        /// </summary>
        TuckSealListDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        /// <summary>
        /// 保健所マスタ
        /// </summary>
        TuckSealListDataSet.HokenjoMstDataTable HokenjoMstDataTable { get; set; }

        // 2014.12.26 toyoda Delete Start
        ///// <summary>
        ///// 浄化槽台帳マスタ
        ///// </summary>
        //TuckSealListDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDataTable { get; set; }
        // 2014.12.26 toyoda Delete End

        /// <summary>
        /// 地区マスタ
        /// </summary>
        TuckSealListDataSet.ChikuMstDataTable ChikuMstDataTable { get; set; }
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
    /// 2014/08/07　AnhNV　　    新規作成
    /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// 業者マスタ
        /// </summary>
        public TuckSealListDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        /// <summary>
        /// 保健所マスタ
        /// </summary>
        public TuckSealListDataSet.HokenjoMstDataTable HokenjoMstDataTable { get; set; }

        // 2014.12.26 toyoda Delete Start
        ///// <summary>
        ///// 浄化槽台帳マスタ
        ///// </summary>
        //public TuckSealListDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDataTable { get; set; }
        // 2014.12.26 toyoda Delete End

        /// <summary>
        /// 地区マスタ
        /// </summary>
        public TuckSealListDataSet.ChikuMstDataTable ChikuMstDataTable { get; set; }
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
    /// 2014/08/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TuckSealList：FormLoad";

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
        /// 2014/08/07　AnhNV　　    新規作成
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
        /// 2014/08/07　AnhNV　　    新規作成
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
        /// 2014/08/07　AnhNV　　    新規作成
        /// 2014/10/10  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Get 業者マスタ info
                IGetGyoshaMstInfoBLOutput gyoshaOutp = new GetGyoshaMstInfoBusinessLogic().Execute(new GetGyoshaMstInfoBLInput());
                output.GyoshaMstDataTable = gyoshaOutp.GyoshaMstDataTable;

                // Get 保健所マスタ info
                IGetHokenjoMstInfoBLOutput hokenjoOutp = new GetHokenjoMstInfoBusinessLogic().Execute(new GetHokenjoMstInfoBLInput());
                output.HokenjoMstDataTable = hokenjoOutp.HokenjoMstDT;

                // 2014.12.26 toyoda Delete Start
                //// Get 浄化槽台帳マスタ info
                //IGetJokasoDaichoMstInfoBLOutput jokasoOutp = new GetJokasoDaichoMstInfoBusinessLogic().Execute(new GetJokasoDaichoMstInfoBLInput());
                //output.JokasoDaichoMstDataTable = jokasoOutp.JokasoDaichoMstDT;
                // 2014.12.26 toyoda Delete End

                // Get 地区マスタ info
                IGetChikuMstInfoBLOutput chikuOutput = new GetChikuMstInfoBusinessLogic().Execute(new GetChikuMstInfoBLInput());
                output.ChikuMstDataTable = chikuOutput.ChikuMstDataTable;
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
