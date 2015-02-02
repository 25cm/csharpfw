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
    //  インターフェイス名 ： ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAInput
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
    interface ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAInput
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
    //  クラス名 ： SelectShoriHoshikiSuishitsuKensaJisshiByCondDAInput
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
    class SelectShoriHoshikiSuishitsuKensaJisshiByCondDAInput : ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAInput
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
    //  インターフェイス名 ： ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput
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
    interface ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiListDataTable
        /// </summary>
        ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiListDataTable ShoriHoshikiSuishitsuKensaJisshiListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput
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
    class SelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput : ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiListDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiListDataTable ShoriHoshikiSuishitsuKensaJisshiListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiSuishitsuKensaJisshiByCondDataAccess
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
    class SelectShoriHoshikiSuishitsuKensaJisshiByCondDataAccess : BaseDataAccess<ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAInput, ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShoriHoshikiSuishitsuKensaJisshiListTableAdapter tableAdapter = new ShoriHoshikiSuishitsuKensaJisshiListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShoriHoshikiSuishitsuKensaJisshiByCondDataAccess
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
        public SelectShoriHoshikiSuishitsuKensaJisshiByCondDataAccess()
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
        public override ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput Execute(ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput output = new SelectShoriHoshikiSuishitsuKensaJisshiByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShoriHoshikiSuishitsuKensaJisshiListDataTable = tableAdapter.GetDataByCond(input.ShoriHoshikiKbn, input.ShoriHoshikiCd);

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
