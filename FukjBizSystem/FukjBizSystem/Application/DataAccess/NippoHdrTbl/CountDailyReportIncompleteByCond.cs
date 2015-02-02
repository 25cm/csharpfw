using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.NippoHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountDailyReportIncompleteByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountDailyReportIncompleteByCondDAInput
    {
        /// <summary>
        /// 検査年月
        /// </summary>
        string KensaIraiKensaNenTsuki { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        ///業者コード（終了）
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// 締め区分
        /// </summary>
        string ShimeKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDailyReportIncompleteByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountDailyReportIncompleteByCondDAInput : ICountDailyReportIncompleteByCondDAInput
    {
        /// <summary>
        /// 検査年月
        /// </summary>
        public string KensaIraiKensaNenTsuki { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        ///業者コード（終了）
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 締め区分
        /// </summary>
        public string ShimeKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountDailyReportIncompleteByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountDailyReportIncompleteByCondDAOutput
    {
        /// <summary>
        /// DailyReportInCompleteCount
        /// </summary>
        int DailyReportInCompleteCount { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDailyReportIncompleteByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountDailyReportIncompleteByCondDAOutput : ICountDailyReportIncompleteByCondDAOutput
    {
        /// <summary>
        /// DailyReportInCompleteCount
        /// </summary>
        public int DailyReportInCompleteCount { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDailyReportIncompleteByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountDailyReportIncompleteByCondDataAccess : BaseDataAccess<ICountDailyReportIncompleteByCondDAInput, ICountDailyReportIncompleteByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private DailyIncompleteCountTableAdapter tableAdapter = new DailyIncompleteCountTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CountDailyReportIncompleteByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CountDailyReportIncompleteByCondDataAccess()
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
        /// 2014/09/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICountDailyReportIncompleteByCondDAOutput Execute(ICountDailyReportIncompleteByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICountDailyReportIncompleteByCondDAOutput output = new CountDailyReportIncompleteByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.DailyReportInCompleteCount = tableAdapter.CountDailyReportIncomplete(input.KensaIraiKensaNenTsuki, 
                                                                                            input.GyoshaCdFrom, 
                                                                                            input.GyoshaCdTo,
                                                                                            input.ShimeKbn);

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
