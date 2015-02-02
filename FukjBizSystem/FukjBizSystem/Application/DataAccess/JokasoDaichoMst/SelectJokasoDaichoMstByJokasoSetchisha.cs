using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JokasoDaichoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJokasoDaichoMstByJokasoSetchishaDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/29　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoMstByJokasoSetchishaDAInput
    {
        /// <summary>
        /// 設置者区分
        /// </summary>
        String JokasoSetchishaKbn { get; set; }

        /// <summary>
        /// 設置者コード
        /// </summary>
        String JokasoSetchishaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstByJokasoSetchishaDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/29　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstByJokasoSetchishaDAInput : ISelectJokasoDaichoMstByJokasoSetchishaDAInput
    {
        /// <summary>
        /// 設置者区分
        /// </summary>
        public String JokasoSetchishaKbn { get; set; }

        /// <summary>
        /// 設置者コード
        /// </summary>
        public String JokasoSetchishaCd { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJokasoDaichoMstByJokasoSetchishaDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/29　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoMstByJokasoSetchishaDAOutput
    {
        /// <summary>
        /// 浄化槽台帳マスタ情報
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstByJokasoSetchishaDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/29　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstByJokasoSetchishaDAOutput : ISelectJokasoDaichoMstByJokasoSetchishaDAOutput
    {
        /// <summary>
        /// 浄化槽台帳マスタ情報
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstByJokasoSetchishaDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/29　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstByJokasoSetchishaDataAccess : BaseDataAccess<ISelectJokasoDaichoMstByJokasoSetchishaDAInput, ISelectJokasoDaichoMstByJokasoSetchishaDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JokasoDaichoMstTableAdapter tableAdapter = new JokasoDaichoMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJokasoDaichoMstByJokasoSetchishaDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/29　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJokasoDaichoMstByJokasoSetchishaDataAccess()
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
        /// 2014/11/29　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJokasoDaichoMstByJokasoSetchishaDAOutput Execute(ISelectJokasoDaichoMstByJokasoSetchishaDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJokasoDaichoMstByJokasoSetchishaDAOutput output = new SelectJokasoDaichoMstByJokasoSetchishaDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 設置者区分、設置者コードで一意の浄化槽台帳マスタのレコードを取得
                output.JokasoDaichoMstDT = tableAdapter.GetDataByJokasoSetchisha(input.JokasoSetchishaKbn, input.JokasoSetchishaCd);

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
