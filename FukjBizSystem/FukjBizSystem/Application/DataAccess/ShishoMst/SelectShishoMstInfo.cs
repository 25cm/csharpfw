using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShishoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShishoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShishoMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShishoMstInfoDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShishoMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShishoMstInfoDAInput : ISelectShishoMstInfoDAInput
    {

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShishoMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShishoMstInfoDAOutput
    {
        /// <summary>
        /// shishoMstDataTable
        /// </summary>
        ShishoMstDataSet.ShishoMstDataTable ShishoMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShishoMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShishoMstInfoDAOutput : ISelectShishoMstInfoDAOutput
    {
        /// <summary>
        /// shishoMstDataTable
        /// </summary>
        public ShishoMstDataSet.ShishoMstDataTable ShishoMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShishoMstInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShishoMstInfoDataAccess : BaseDataAccess<ISelectShishoMstInfoDAInput, ISelectShishoMstInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShishoMstTableAdapter tableAdapter = new ShishoMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShishoMstInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShishoMstInfoDataAccess()
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
        /// 2014/06/25　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShishoMstInfoDAOutput Execute(ISelectShishoMstInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShishoMstInfoDAOutput output = new SelectShishoMstInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShishoMstDT = tableAdapter.GetData();

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
