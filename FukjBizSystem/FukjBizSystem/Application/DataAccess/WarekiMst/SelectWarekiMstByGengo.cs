using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.WarekiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.WarekiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectWarekiMstByGengoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectWarekiMstByGengoDAInput
    {
        /// <summary>
        /// 和暦の元号
        /// </summary>
        string Gengo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectWarekiMstByGengoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectWarekiMstByGengoDAInput : ISelectWarekiMstByGengoDAInput
    {
        /// <summary>
        /// 和暦の元号
        /// </summary>
        public string Gengo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectWarekiMstByGengoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectWarekiMstByGengoDAOutput
    {
        /// <summary>
        /// 和暦マスタ情報
        /// </summary>
        WarekiMstDataSet.WarekiMstDataTable WarekiMstDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectWarekiMstByGengoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectWarekiMstByGengoDAOutput : ISelectWarekiMstByGengoDAOutput
    {
        /// <summary>
        /// 和暦マスタ情報
        /// </summary>
        public WarekiMstDataSet.WarekiMstDataTable WarekiMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectWarekiMstByGengoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectWarekiMstByGengoDataAccess : BaseDataAccess<ISelectWarekiMstByGengoDAInput, ISelectWarekiMstByGengoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private WarekiMstTableAdapter tableAdapter = new WarekiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectWarekiMstByGengoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectWarekiMstByGengoDataAccess()
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
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectWarekiMstByGengoDAOutput Execute(ISelectWarekiMstByGengoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectWarekiMstByGengoDAOutput output = new SelectWarekiMstByGengoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 指定の和暦の元号に一致する和暦レコードを取得
                output.WarekiMstDataTable = tableAdapter.GetDataByGengo(input.Gengo);
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
