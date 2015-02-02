using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuNippoCheckInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuNippoCheckInfoDAInput
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
    //  クラス名 ： SelectSuishitsuNippoCheckInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuNippoCheckInfoDAInput : ISelectSuishitsuNippoCheckInfoDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 水質検査受付日(yyyyMMdd)
        /// </summary>
        public string SuishistsuUketsukeDt { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuNippoCheckInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuNippoCheckInfoDAOutput
    {
        /// <summary>
        /// チェック結果
        /// </summary>
        int CheckCnt { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuNippoCheckInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuNippoCheckInfoDAOutput : ISelectSuishitsuNippoCheckInfoDAOutput
    {
        /// <summary>
        /// チェック結果
        /// </summary>
        public int CheckCnt { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuNippoCheckInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuNippoCheckInfoDataAccess : BaseDataAccess<ISelectSuishitsuNippoCheckInfoDAInput, ISelectSuishitsuNippoCheckInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuNippoCheckInfoTableAdapter tableAdapter = new SuishitsuNippoCheckInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuNippoCheckInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuNippoCheckInfoDataAccess()
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
        /// 2014/12/04  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuNippoCheckInfoDAOutput Execute(ISelectSuishitsuNippoCheckInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuNippoCheckInfoDAOutput output = new SelectSuishitsuNippoCheckInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                // 日報の確認状況取得取得（１件）
                SuishitsuKensaUketsukeDataSet.SuishitsuNippoCheckInfoDataTable chkInfoDt = tableAdapter.GetData(input.ShishoCd, input.SuishistsuUketsukeDt);
                // チェックカウント(NULLはない)
                output.CheckCnt = chkInfoDt[0].CheckCnt;
            }
            catch (Exception e)
            {
                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("エラー内容:{0}", e.Message));

                // ＤＢエラー
                throw new CustomException(ResultCode.DBError, string.Format("エラー内容:{0}", e.Message));
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
