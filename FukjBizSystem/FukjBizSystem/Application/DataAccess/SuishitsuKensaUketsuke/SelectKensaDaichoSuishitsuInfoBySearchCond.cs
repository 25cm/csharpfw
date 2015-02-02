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
    //  インターフェイス名 ： ISelectKensaDaichoSuishitsuInfoBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaichoSuishitsuInfoBySearchCondDAInput
    {
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 受付日(YYYYMMDD)
        /// </summary>
        string KensaIraiUketsukeDt { get; set; }
        /// <summary>
        /// 検体番号（開始）(6桁ゼロパディング)
        /// </summary>
        string KentaiFromNo { get; set; }
        /// <summary>
        /// 検体番号（終了）(6桁ゼロパディング)
        /// </summary>
        string KentaiToNo { get; set; }
        /// 残留塩素の試験項目コード(3桁ゼロパディング)
        /// </summary>
        string ZanryuEnsoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoSuishitsuInfoBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoSuishitsuInfoBySearchCondDAInput : ISelectKensaDaichoSuishitsuInfoBySearchCondDAInput
    {
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 受付日(YYYYMMDD)
        /// </summary>
        public string KensaIraiUketsukeDt { get; set; }
        /// <summary>
        /// 検体番号（開始）(6桁ゼロパディング)
        /// </summary>
        public string KentaiFromNo { get; set; }
        /// <summary>
        /// 検体番号（終了）(6桁ゼロパディング)
        /// </summary>
        public string KentaiToNo { get; set; }
        /// 残留塩素の試験項目コード(3桁ゼロパディング)
        /// </summary>
        public string ZanryuEnsoCd { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaichoSuishitsuInfoBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaichoSuishitsuInfoBySearchCondDAOutput
    {
        /// <summary>
        /// 検査受付一覧－水質検査用情報
        /// </summary>
        SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoDataTable KensaDaichoSuishitsuInfoDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoSuishitsuInfoBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoSuishitsuInfoBySearchCondDAOutput : ISelectKensaDaichoSuishitsuInfoBySearchCondDAOutput
    {
        /// <summary>
        /// 検査受付一覧－水質検査用情報
        /// </summary>
        public SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoDataTable KensaDaichoSuishitsuInfoDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoSuishitsuInfoBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoSuishitsuInfoBySearchCondDataAccess : BaseDataAccess<ISelectKensaDaichoSuishitsuInfoBySearchCondDAInput, ISelectKensaDaichoSuishitsuInfoBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaDaichoSuishitsuInfoTableAdapter tableAdapter = new KensaDaichoSuishitsuInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaDaichoSuishitsuInfoBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaDaichoSuishitsuInfoBySearchCondDataAccess()
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
        /// 2014/12/05  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaDaichoSuishitsuInfoBySearchCondDAOutput Execute(ISelectKensaDaichoSuishitsuInfoBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaDaichoSuishitsuInfoBySearchCondDAOutput output = new SelectKensaDaichoSuishitsuInfoBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                // 検査受付一覧－水質検査用情報取得
                output.KensaDaichoSuishitsuInfoDT = tableAdapter.GetDataBySearchCond(input.IraiNendo, input.ShishoCd, input.KensaIraiUketsukeDt, input.KentaiFromNo, input.KentaiToNo, input.ZanryuEnsoCd);

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
