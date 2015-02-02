using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaTanKomokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaTanKomokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput
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
    interface ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput
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
    //  クラス名 ： SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput
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
    class SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput : ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput
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
    //  インターフェイス名 ： ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput
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
    interface ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput
    {
        /// <summary>
        /// 浄化槽台帳水質検査単項目マスタ情報
        /// </summary>
        DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable KensaTanKomokuMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput
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
    class SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput : ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput
    {
        /// <summary>
        /// 浄化槽台帳水質検査単項目マスタ情報
        /// </summary>
        public DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable KensaTanKomokuMstDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDataAccess
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
    class SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDataAccess : BaseDataAccess<ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput, ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private DaichoSuishitsuKensaTanKomokuMstTableAdapter tableAdapter = new DaichoSuishitsuKensaTanKomokuMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDataAccess
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
        public SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDataAccess()
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
        public override ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput Execute(ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput output = new SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 浄化槽台帳水質検査単項目マスタ情報取得（浄化槽台帳水質検査項目マスタの主キー値で取得（複数））
                output.KensaTanKomokuMstDT = tableAdapter.GetDataByKensaKomokuMstPK(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban, input.DaichoKensaKomokuEdaban);

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
