using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaTanKomokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaKomokuMstDataSetTableAdapters;

namespace FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiKensaDaichoEntryInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiKensaDaichoEntryInfoDAInput
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
        /// <summary>
        /// 台帳検査項目枝番
        /// </summary>
        string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiKensaDaichoEntryInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiKensaDaichoEntryInfoDAInput : ISelectKeiryoShomeiKensaDaichoEntryInfoDAInput
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
        /// <summary>
        /// 台帳検査項目枝番
        /// </summary>
        public string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiKensaDaichoEntryInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiKensaDaichoEntryInfoDAOutput
    {
        /// <summary>
        /// 計量証明・検査台帳登録用情報
        /// </summary>
        DaichoSuishitsuKensaKomokuMstDataSet.KeiryoShomeiKensaDaichoEntryInfoDataTable EntryInfoDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiKensaDaichoEntryInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiKensaDaichoEntryInfoDAOutput : ISelectKeiryoShomeiKensaDaichoEntryInfoDAOutput
    {
        /// <summary>
        /// 計量証明・検査台帳登録用情報
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.KeiryoShomeiKensaDaichoEntryInfoDataTable EntryInfoDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiKensaDaichoEntryInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiKensaDaichoEntryInfoDataAccess : BaseDataAccess<ISelectKeiryoShomeiKensaDaichoEntryInfoDAInput, ISelectKeiryoShomeiKensaDaichoEntryInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiKensaDaichoEntryInfoTableAdapter tableAdapter = new KeiryoShomeiKensaDaichoEntryInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKeiryoShomeiKensaDaichoEntryInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKeiryoShomeiKensaDaichoEntryInfoDataAccess()
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
        /// 2014/12/02  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKeiryoShomeiKensaDaichoEntryInfoDAOutput Execute(ISelectKeiryoShomeiKensaDaichoEntryInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKeiryoShomeiKensaDaichoEntryInfoDAOutput output = new SelectKeiryoShomeiKensaDaichoEntryInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 計量証明・検査台帳登録用情報取得（協会番号＋枝番で取得（１件））
                output.EntryInfoDT = tableAdapter.GetData(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban, input.DaichoKensaKomokuEdaban);

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
