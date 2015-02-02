using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsuke;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuNippoCheckInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuNippoCheckInfoALInput : IBseALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 水質検査受付日(yyyyMMdd)
        /// </summary>
        string SuishistsuUketsukeDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoCheckInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoCheckInfoALInput : IGetSuishitsuNippoCheckInfoALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 水質検査受付日(yyyyMMdd)
        /// </summary>
        public string SuishistsuUketsukeDt { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}], 水質検査受付日[{1}]",
                    new string[] { ShishoCd, SuishistsuUketsukeDt });
            }
        }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuNippoCheckInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuNippoCheckInfoALOutput
    {
        /// <summary>
        /// チェック結果
        /// </summary>
        int CheckCnt { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoCheckInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoCheckInfoALOutput : IGetSuishitsuNippoCheckInfoALOutput
    {
        /// <summary>
        /// チェック結果
        /// </summary>
        public int CheckCnt { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoCheckInfoApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoCheckInfoApplicationLogic : BaseApplicationLogic<IGetSuishitsuNippoCheckInfoALInput, IGetSuishitsuNippoCheckInfoALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaUketsukeList：GetSuishitsuNippoCheckInfo";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuNippoCheckInfoApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuNippoCheckInfoApplicationLogic()
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
        /// 2014/12/09　小松　　    新規作成
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
        /// 2014/12/09　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuNippoCheckInfoALOutput Execute(IGetSuishitsuNippoCheckInfoALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuNippoCheckInfoALOutput output = new GetSuishitsuNippoCheckInfoALOutput();

            try
            {
                // データ検索⑬
                ISelectSuishitsuNippoCheckInfoDAInput inda = new SelectSuishitsuNippoCheckInfoDAInput();
                inda.ShishoCd = input.ShishoCd;
                inda.SuishistsuUketsukeDt = input.SuishistsuUketsukeDt;
                output.CheckCnt = new SelectSuishitsuNippoCheckInfoDataAccess().Execute(inda).CheckCnt;
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
