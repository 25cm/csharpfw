using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuShikenKoumokuMstList;
using FukjBizSystem.Application.DataAccess.SuishitsuShikenKoumokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.YachoTorikomi
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
    /// 2014/12/04　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
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
    /// 2014/12/04　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {

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
    /// 2014/12/04　HieuNH　　　新規作成
    /// 2015/01/29  宗          外観検査用の選択リストを追加で取得
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        ///// <summary>
        ///// 支所マスタ
        ///// </summary>
        //ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// ShishoMstExceptJimukyokuDataTable 
        /// </summary>
        ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }

        /// <summary>
        /// 水質試験項目マスタ
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable SuishitsuShikenKoumokuMstDataTable { get; set; }

        /// <summary>
        /// 法定検査用水質試験項目マスタ
        /// </summary>
        //SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable HoteiSuishitsuShikenKoumokuMstDataTable { get; set; }
        SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiSuishitsuShikenKoumokuMstSelectListDataTable { get; set; }
        /// <summary>
        /// 計量証明用水質試験項目マスタ
        /// </summary>
        //SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable KeiryoSuishitsuShikenKoumokuMstDataTable { get; set; }
        SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable KeiryoSuishitsuShikenKoumokuMstSelectListDataTable { get; set; }
        /// <summary>
        /// 法定検査用外観試験項目マスタ
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiGaikanShikenKoumokuMstSelectListDataTable { get; set; }
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
    /// 2014/12/04　HieuNH　　　新規作成
    /// 2015/01/29  宗          外観検査用の選択リストを追加で取得
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        ///// <summary>
        ///// 支所マスタ
        ///// </summary>
        //public ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// ShishoMstExceptJimukyokuDataTable 
        /// </summary>
        public ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }

        /// <summary>
        /// 水質試験項目マスタ
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable SuishitsuShikenKoumokuMstDataTable { get; set; }

        /// <summary>
        /// 法定検査用水質試験項目マスタ
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiSuishitsuShikenKoumokuMstSelectListDataTable { get; set; }
        /// <summary>
        /// 計量証明用水質試験項目マスタ
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable KeiryoSuishitsuShikenKoumokuMstSelectListDataTable { get; set; }
        /// <summary>
        /// 法定検査用外観試験項目マスタ
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiGaikanShikenKoumokuMstSelectListDataTable { get; set; }
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
    /// 2014/12/04　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "YachoTorikomi：FormLoad";

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
        /// 2014/12/04　HieuNH　　　新規作成
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
        /// 2014/12/04　HieuNH　　　新規作成
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
        /// 2014/12/04　HieuNH　　　新規作成
        /// 2015/01/29  宗          外観検査用の選択リストを追加で取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                //20150128 HuyTX Mod 課題対応 No279 支所コンボから事務局除外対応
                // Get shishoMst info
                //IGetShishoMstInfoBLOutput shishoOutput = new GetShishoMstInfoBusinessLogic().Execute(new GetShishoMstInfoBLInput());
                //output.ShishoMstDataTable = shishoOutput.ShishoMstDT;
                IGetShishoMstExceptJimukyokuBLOutput shishoOutput = new GetShishoMstExceptJimukyokuBusinessLogic().Execute(new GetShishoMstExceptJimukyokuBLInput());
                output.ShishoMstExceptJimukyokuDataTable = shishoOutput.ShishoMstExceptJimukyokuDT;
                //End


                IGetSuishitsuShikenKoumokuMstInfoBLOutput sskmOutput = new GetSuishitsuShikenKoumokuMstInfoBusinessLogic().Execute(new GetSuishitsuShikenKoumokuMstInfoBLInput());
                output.SuishitsuShikenKoumokuMstDataTable = sskmOutput.SuishitsuShikenKoumokuMstDataTable;

                // 20150119 sou Start
                // 法定検査用水質試験項目マスタ
                //ISelectSuishitsuShikenKoumokuMstByConstKbnDAInput hoteiIn = new SelectSuishitsuShikenKoumokuMstByConstKbnDAInput();
                ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput hoteiIn = new SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput();
                hoteiIn.ConstKbn = "048";
                output.HoteiSuishitsuShikenKoumokuMstSelectListDataTable = (new SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDataAccess().Execute(hoteiIn)).SuishitsuShikenKoumokuMstSelectListDataTable;

                // 計量証明用水質試験項目マスタ
                //ISelectSuishitsuShikenKoumokuMstByConstKbnDAInput keiryoIn = new SelectSuishitsuShikenKoumokuMstByConstKbnDAInput();
                ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput keiryoIn = new SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput();
                keiryoIn.ConstKbn = "049";
                output.KeiryoSuishitsuShikenKoumokuMstSelectListDataTable = (new SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDataAccess().Execute(keiryoIn)).SuishitsuShikenKoumokuMstSelectListDataTable;
                // 20150119 sou End

                // 20150129 sou Start
                // 法定検査用外観試験項目マスタ
                ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput hoteiGaikanIn = new SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput();
                hoteiGaikanIn.ConstKbn = "078";
                output.HoteiGaikanShikenKoumokuMstSelectListDataTable = (new SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDataAccess().Execute(hoteiGaikanIn)).SuishitsuShikenKoumokuMstSelectListDataTable;
                // 20150129 sou End
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
