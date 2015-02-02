using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KeiryoShomeiIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountKeiryoShomeiReportIncompleteByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountKeiryoShomeiReportIncompleteByCondDAInput
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
    //  クラス名 ： CountKeiryoShomeiReportIncompleteByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountKeiryoShomeiReportIncompleteByCondDAInput : ICountKeiryoShomeiReportIncompleteByCondDAInput
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
    //  インターフェイス名 ： ICountKeiryoShomeiReportIncompleteByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountKeiryoShomeiReportIncompleteByCondDAOutput
    {
        /// <summary>
        /// KeiryouShomeiIncompleteCount
        /// </summary>
        int KeiryouShomeiIncompleteCount { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountKeiryoShomeiReportIncompleteByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountKeiryoShomeiReportIncompleteByCondDAOutput : ICountKeiryoShomeiReportIncompleteByCondDAOutput
    {
        /// <summary>
        /// KeiryouShomeiIncompleteCount
        /// </summary>
        public int KeiryouShomeiIncompleteCount { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountKeiryoShomeiReportIncompleteByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountKeiryoShomeiReportIncompleteByCondDataAccess : BaseDataAccess<ICountKeiryoShomeiReportIncompleteByCondDAInput, ICountKeiryoShomeiReportIncompleteByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryouShomeiIncompleteCountTableAdapter tableAdapter = new KeiryouShomeiIncompleteCountTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CountKeiryoShomeiReportIncompleteByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CountKeiryoShomeiReportIncompleteByCondDataAccess()
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
        /// 2014/10/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICountKeiryoShomeiReportIncompleteByCondDAOutput Execute(ICountKeiryoShomeiReportIncompleteByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICountKeiryoShomeiReportIncompleteByCondDAOutput output = new CountKeiryoShomeiReportIncompleteByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KeiryouShomeiIncompleteCount = tableAdapter.CountKeiryouShomeiDailyReportIncomplete(input.KensaIraiKensaNenTsuki, input.GyoshaCdFrom,
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
