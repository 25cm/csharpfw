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
    //  インターフェイス名 ： ISelectPrintHotei11joIjoListCountByConditionDAInput
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
    interface ISelectPrintHotei11joIjoListCountByConditionDAInput
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
    //  クラス名 ： SelectPrintHotei11joIjoListCountByConditionDAInput
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
    class SelectPrintHotei11joIjoListCountByConditionDAInput : ISelectPrintHotei11joIjoListCountByConditionDAInput
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
    //  インターフェイス名 ： ISelectPrintHotei11joIjoListCountByConditionDAOutput
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
    interface ISelectPrintHotei11joIjoListCountByConditionDAOutput
    {
        /// <summary>
        /// PrintHotei11joIjoList
        /// </summary>
        SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListCountDataTable PrintHotei11joIjoList { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintHotei11joIjoListCountByConditionDAOutput
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
    class SelectPrintHotei11joIjoListCountByConditionDAOutput : ISelectPrintHotei11joIjoListCountByConditionDAOutput
    {
        /// <summary>
        /// PrintHotei11joIjoList
        /// </summary>
        public SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListCountDataTable PrintHotei11joIjoList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintHotei11joIjoListCountByConditionDataAccess
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
    class SelectPrintHotei11joIjoListCountByConditionDataAccess : BaseDataAccess<ISelectPrintHotei11joIjoListCountByConditionDAInput, ISelectPrintHotei11joIjoListCountByConditionDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private PrintHotei11joIjoListCountTableAdapter tableAdapter = new PrintHotei11joIjoListCountTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrintHotei11joIjoListCountByConditionDataAccess
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
        public SelectPrintHotei11joIjoListCountByConditionDataAccess()
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
        public override ISelectPrintHotei11joIjoListCountByConditionDAOutput Execute(ISelectPrintHotei11joIjoListCountByConditionDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrintHotei11joIjoListCountByConditionDAOutput output = new SelectPrintHotei11joIjoListCountByConditionDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.PrintHotei11joIjoList = tableAdapter.GetDataByCondition(
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
