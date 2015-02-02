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
    //  インターフェイス名 ： ISelectJokasoDaichoMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoMstInfoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstInfoDAInput : ISelectJokasoDaichoMstInfoDAInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJokasoDaichoMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoMstInfoDAOutput
    {
        /// <summary>
        /// JokasoDaichoMstDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstInfoDAOutput : ISelectJokasoDaichoMstInfoDAOutput
    {
        /// <summary>
        /// JokasoDaichoMstDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoMstInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoMstInfoDataAccess : BaseDataAccess<ISelectJokasoDaichoMstInfoDAInput, ISelectJokasoDaichoMstInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JokasoDaichoMstTableAdapter tableAdapter= new JokasoDaichoMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJokasoDaichoMstInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJokasoDaichoMstInfoDataAccess()
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
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJokasoDaichoMstInfoDAOutput Execute(ISelectJokasoDaichoMstInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJokasoDaichoMstInfoDAOutput output = new SelectJokasoDaichoMstInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JokasoDaichoMstDT = tableAdapter.GetData();

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
