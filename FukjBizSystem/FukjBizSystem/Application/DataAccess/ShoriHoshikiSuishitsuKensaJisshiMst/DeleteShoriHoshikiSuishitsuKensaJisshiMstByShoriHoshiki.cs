using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShoriHoshikiSuishitsuKensaJisshiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput
    {
        /// <summary>
        /// ShoriHoshikiKbn
        /// </summary>
        string ShoriHoshikiKbn { get; set; }

        /// <summary>
        /// ShoriHoshikiCd
        /// </summary>
        string ShoriHoshikiCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput : IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput
    {
        /// <summary>
        /// ShoriHoshikiKbn
        /// </summary>
        public string ShoriHoshikiKbn { get; set; }

        /// <summary>
        /// ShoriHoshikiCd
        /// </summary>
        public string ShoriHoshikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput : IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDataAccess : BaseDataAccess<IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput, IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        // TODO:使用するテーブルアダプタの実体を定義してください
        private ShoriHoshikiSuishitsuKensaJisshiMstTableAdapter tableAdapter = new ShoriHoshikiSuishitsuKensaJisshiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDataAccess()
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
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput Execute(IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput output = new DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByShoriHoshikiKbnAndShoriHoshikiCd(input.ShoriHoshikiKbn, input.ShoriHoshikiCd);

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
