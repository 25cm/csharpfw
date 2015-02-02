using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeReportDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeReport
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrintFollowKensaListCountByConditionDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/11  宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintFollowKensaListCountByConditionDAInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// 条件追加区分
        /// </summary>
        string IraiDateKbn { get; set; }

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        string IraiDateFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        string IraiDateTo { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        string IraiNoTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintFollowKensaListCountByConditionDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/11  宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintFollowKensaListCountByConditionDAInput : ISelectPrintFollowKensaListCountByConditionDAInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 条件追加区分
        /// </summary>
        public string IraiDateKbn { get; set; }

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        public string IraiDateFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        public string IraiDateTo { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        public string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        public string IraiNoTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrintFollowKensaListCountByConditionDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/11  宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintFollowKensaListCountByConditionDAOutput
    {
        /// <summary>
        /// PrintFollowKensaList
        /// </summary>
        SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListCountDataTable PrintFollowKensaList { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintFollowKensaListCountByConditionDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/11  宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintFollowKensaListCountByConditionDAOutput : ISelectPrintFollowKensaListCountByConditionDAOutput
    {
        /// <summary>
        /// PrintFollowKensaList
        /// </summary>
        public SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListCountDataTable PrintFollowKensaList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintFollowKensaListCountByConditionDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/11  宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintFollowKensaListCountByConditionDataAccess : BaseDataAccess<ISelectPrintFollowKensaListCountByConditionDAInput, ISelectPrintFollowKensaListCountByConditionDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private PrintFollowKensaListCountTableAdapter tableAdapter = new PrintFollowKensaListCountTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrintFollowKensaListCountByConditionDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectPrintFollowKensaListCountByConditionDataAccess()
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
        /// 2015/01/11  宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectPrintFollowKensaListCountByConditionDAOutput Execute(ISelectPrintFollowKensaListCountByConditionDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrintFollowKensaListCountByConditionDAOutput output = new SelectPrintFollowKensaListCountByConditionDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.PrintFollowKensaList = tableAdapter.GetDataByCondition(
                    input.Nendo, input.IraiDateKbn, input.IraiDateFrom, input.IraiDateTo, input.IraiNoFrom, input.IraiNoTo);
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
