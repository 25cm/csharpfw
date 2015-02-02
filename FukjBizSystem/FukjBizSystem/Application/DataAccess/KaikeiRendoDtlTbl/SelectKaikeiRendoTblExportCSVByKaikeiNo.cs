using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.Common;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KaikeiRendoDtlTblDataSetTableAdapters;

namespace FukjBizSystem.Application.DataAccess.KaikeiRendoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKaikeiRendoTblExportCSVByKaikeiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKaikeiRendoTblExportCSVByKaikeiNoDAInput
    {
        /// <summary>
        /// KaikeiNo
        /// </summary>
        string KaikeiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaikeiRendoTblExportCSVByKaikeiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaikeiRendoTblExportCSVByKaikeiNoDAInput : ISelectKaikeiRendoTblExportCSVByKaikeiNoDAInput
    {
        /// <summary>
        /// KaikeiNo
        /// </summary>
        public string KaikeiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput
    {
        /// <summary>
        /// KaikeiRendoTblExportCSVDataTable
        /// </summary>
        KaikeiRendoDtlTblDataSet.KaikeiRendoTblExportCSVDataTable KaikeiRendoTblExportCSVDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput : ISelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput
    {
        /// <summary>
        /// KaikeiRendoTblExportCSVDataTable
        /// </summary>
        public KaikeiRendoDtlTblDataSet.KaikeiRendoTblExportCSVDataTable KaikeiRendoTblExportCSVDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaikeiRendoTblExportCSVByKaikeiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaikeiRendoTblExportCSVByKaikeiNoDataAccess : BaseDataAccess<ISelectKaikeiRendoTblExportCSVByKaikeiNoDAInput, ISelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KaikeiRendoTblExportCSVTableAdapter tableAdapter = new KaikeiRendoTblExportCSVTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKaikeiRendoTblExportCSVByKaikeiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKaikeiRendoTblExportCSVByKaikeiNoDataAccess()
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
        /// 2014/09/12  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput Execute(ISelectKaikeiRendoTblExportCSVByKaikeiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput output = new SelectKaikeiRendoTblExportCSVByKaikeiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KaikeiRendoTblExportCSVDataTable = tableAdapter.GetDataByKaikeiNo(input.KaikeiNo);

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
