using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GyoshaBukaiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.GyoshaBukaiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKaiinPrintInfoByGyoshaCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/14　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKaiinPrintInfoByGyoshaCdDAInput
    {
        /// <summary>
        /// GyoshaCd 
        /// </summary>
        string GyoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaiinPrintInfoByGyoshaCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/14　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaiinPrintInfoByGyoshaCdDAInput : ISelectKaiinPrintInfoByGyoshaCdDAInput
    {
        /// <summary>
        /// GyoshaCd 
        /// </summary>
        public string GyoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKaiinPrintInfoByGyoshaCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/14　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKaiinPrintInfoByGyoshaCdDAOutput
    {
        /// <summary>
        /// KaiinPrintInfoDataTable
        /// </summary>
        GyoshaBukaiMstDataSet.KaiinPrintInfoDataTable KaiinPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaiinPrintInfoByGyoshaCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/14　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaiinPrintInfoByGyoshaCdDAOutput : ISelectKaiinPrintInfoByGyoshaCdDAOutput
    {
        /// <summary>
        /// KaiinPrintInfoDataTable
        /// </summary>
        public GyoshaBukaiMstDataSet.KaiinPrintInfoDataTable KaiinPrintInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaiinPrintInfoByGyoshaCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/14　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaiinPrintInfoByGyoshaCdDataAccess : BaseDataAccess<ISelectKaiinPrintInfoByGyoshaCdDAInput, ISelectKaiinPrintInfoByGyoshaCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KaiinPrintInfoTableAdapter tableAdapter = new KaiinPrintInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKaiinPrintInfoByGyoshaCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKaiinPrintInfoByGyoshaCdDataAccess()
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
        /// 2014/08/14　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKaiinPrintInfoByGyoshaCdDAOutput Execute(ISelectKaiinPrintInfoByGyoshaCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKaiinPrintInfoByGyoshaCdDAOutput output = new SelectKaiinPrintInfoByGyoshaCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KaiinPrintInfoDataTable = tableAdapter.GetDataByGyoshaCd(input.GyoshaCd);

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
