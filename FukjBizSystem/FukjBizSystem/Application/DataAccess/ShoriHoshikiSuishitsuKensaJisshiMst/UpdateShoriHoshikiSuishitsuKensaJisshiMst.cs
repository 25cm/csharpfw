using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShoriHoshikiSuishitsuKensaJisshiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstDataTable
        /// </summary>
        ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMstDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput : IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMstDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput : IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateShoriHoshikiSuishitsuKensaJisshiMstDataAccess : BaseDataAccess<IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput, IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShoriHoshikiSuishitsuKensaJisshiMstTableAdapter tableAdapter = new ShoriHoshikiSuishitsuKensaJisshiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateShoriHoshikiSuishitsuKensaJisshiMstDataAccess()
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
        /// 2015/01/27  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput Execute(IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput output = new UpdateShoriHoshikiSuishitsuKensaJisshiMstDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.Update(input.ShoriHoshikiSuishitsuKensaJisshiMstDataTable);

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
