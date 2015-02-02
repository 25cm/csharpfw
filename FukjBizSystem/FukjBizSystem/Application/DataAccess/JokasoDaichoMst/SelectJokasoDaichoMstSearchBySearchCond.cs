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
    //  インターフェイス名 ： ISelectJokasoDaichoMstSearchBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoMstSearchBySearchCondDAInput
    {
        /// <summary>
        /// JokasoDaichoMstSearchCond
        /// </summary>
        JokasoDaichoMstSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstSearchBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstSearchBySearchCondDAInput : ISelectJokasoDaichoMstSearchBySearchCondDAInput
    {
        /// <summary>
        /// JokasoDaichoMstSearchCond
        /// </summary>
        public JokasoDaichoMstSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJokasoDaichoMstSearchBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoMstSearchBySearchCondDAOutput
    {
        /// <summary>
        /// JokasoDaichoMstSearchDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable JokasoDaichoMstSearchDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstSearchBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstSearchBySearchCondDAOutput : ISelectJokasoDaichoMstSearchBySearchCondDAOutput
    {
        /// <summary>
        /// JokasoDaichoMstSearchDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable JokasoDaichoMstSearchDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstSearchBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstSearchBySearchCondDataAccess : BaseDataAccess<ISelectJokasoDaichoMstSearchBySearchCondDAInput, ISelectJokasoDaichoMstSearchBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JokasoDaichoMstSearchTableAdapter tableAdapter = new JokasoDaichoMstSearchTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJokasoDaichoMstSearchBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJokasoDaichoMstSearchBySearchCondDataAccess()
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
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJokasoDaichoMstSearchBySearchCondDAOutput Execute(ISelectJokasoDaichoMstSearchBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJokasoDaichoMstSearchBySearchCondDAOutput output = new SelectJokasoDaichoMstSearchBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JokasoDaichoMstSearchDataTable = tableAdapter.GetDataBySearchCond(input.SearchCond);
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
