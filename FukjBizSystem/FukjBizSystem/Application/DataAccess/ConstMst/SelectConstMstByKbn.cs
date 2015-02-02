using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ConstMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ConstMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectConstMstByKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectConstMstByKbnDAInput
    {
        /// <summary>
        /// 定数区分
        /// </summary>
        string ConstKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectConstMstByKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectConstMstByKbnDAInput : ISelectConstMstByKbnDAInput
    {
        /// <summary>
        /// 定数区分
        /// </summary>
        public string ConstKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectConstMstByKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectConstMstByKbnDAOutput
    {
        /// <summary>
        /// 
        /// </summary>
        ConstMstDataSet.ConstMstDataTable DataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectConstMstByKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectConstMstByKbnDAOutput : ISelectConstMstByKbnDAOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstMstDataSet.ConstMstDataTable DataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectConstMstByKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectConstMstByKbnDataAccess : BaseDataAccess<ISelectConstMstByKbnDAInput, ISelectConstMstByKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ConstMstTableAdapter tableAdapter = new ConstMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectConstMstByKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectConstMstByKbnDataAccess()
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
        /// 2014/08/07　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectConstMstByKbnDAOutput Execute(ISelectConstMstByKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectConstMstByKbnDAOutput output = new SelectConstMstByKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.DataTable = tableAdapter.GetDataByKbn(input.ConstKbn);

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
