using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectDisplayJokasoDaichoInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectDisplayJokasoDaichoInfoDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        string JokasoHokenjoCd { get; set; }
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        string JokasoTorokuNendo { get; set; }
        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDisplayJokasoDaichoInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDisplayJokasoDaichoInfoDAInput : ISelectDisplayJokasoDaichoInfoDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }
        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectDisplayJokasoDaichoInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectDisplayJokasoDaichoInfoDAOutput
    {
        /// <summary>
        /// 詳細画面表示用浄化槽台帳マスタ情報
        /// </summary>
        SuishitsuKensaUketsukeDataSet.DisplayJokasoDaichoInfoDataTable jokasoDaichoInfoDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDisplayJokasoDaichoInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDisplayJokasoDaichoInfoDAOutput : ISelectDisplayJokasoDaichoInfoDAOutput
    {
        /// <summary>
        /// 詳細画面表示用浄化槽台帳マスタ情報
        /// </summary>
        public SuishitsuKensaUketsukeDataSet.DisplayJokasoDaichoInfoDataTable jokasoDaichoInfoDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDisplayJokasoDaichoInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDisplayJokasoDaichoInfoDataAccess : BaseDataAccess<ISelectDisplayJokasoDaichoInfoDAInput, ISelectDisplayJokasoDaichoInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private DisplayJokasoDaichoInfoTableAdapter tableAdapter = new DisplayJokasoDaichoInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectDisplayJokasoDaichoInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectDisplayJokasoDaichoInfoDataAccess()
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
        /// 2014/12/11  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectDisplayJokasoDaichoInfoDAOutput Execute(ISelectDisplayJokasoDaichoInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectDisplayJokasoDaichoInfoDAOutput output = new SelectDisplayJokasoDaichoInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.jokasoDaichoInfoDT = 
                    tableAdapter.GetData(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban);

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
