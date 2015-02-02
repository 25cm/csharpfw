using Zynas.Framework.Core.Base.ApplicationLogic;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Utility;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho
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
    /// 2015/01/06  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
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
    /// 2015/01/06  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}]", ShishoCd);
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
    /// 2015/01/06  宗    　    新規作成
    /// 2015/01/27  宗          取得する支所マスタを全件から事務局以外に変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmMstDt { get; set; }
        //ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }
        ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }
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
    /// 2015/01/06  宗    　    新規作成
    /// 2015/01/27  宗          取得する支所マスタを全件から事務局以外に変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        public SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmMstDt { get; set; }
        //public ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }
        public ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }
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
    /// 2015/01/06  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KeiryoShomeiDaicho：FormLoad";

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
        /// 2015/01/06  宗    　    新規作成
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
        /// 2015/01/06  宗    　    新規作成
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
        /// 2015/01/06  宗    　    新規作成
        /// 2015/01/27  宗          取得する支所マスタを全件から事務局以外に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();
            try
            {
                // 水質結果名称テーブル
                IGetSuishitsuKekkaNmMstBySearchCondFromToBLInput blInput = new GetSuishitsuKekkaNmMstBySearchCondFromToBLInput();
                blInput.ShishoCd = (input.ShishoCd == "0" ? "3" : input.ShishoCd); // 事務局→福岡
                blInput.SuishitsuKekkaNmCdFrom = string.Empty;
                blInput.SuishitsuKekkaNmCdTo = string.Empty;
                output.SuishitsuKekkaNmMstDt = new GetSuishitsuKekkaNmMstBySearchCondFromToBusinessLogic().Execute(blInput).SuishitsuKekkaNmMstDT;

                // 支所マスタ
                //IGetShishoMstInfoBLOutput shishoOutput = new GetShishoMstInfoBusinessLogic().Execute(new GetShishoMstInfoBLInput());
                //output.ShishoMstDataTable = shishoOutput.ShishoMstDT;
                IGetShishoMstExceptJimukyokuBLOutput shishoOutput = new GetShishoMstExceptJimukyokuBusinessLogic().Execute(new GetShishoMstExceptJimukyokuBLInput());
                output.ShishoMstExceptJimukyokuDataTable = shishoOutput.ShishoMstExceptJimukyokuDT;
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