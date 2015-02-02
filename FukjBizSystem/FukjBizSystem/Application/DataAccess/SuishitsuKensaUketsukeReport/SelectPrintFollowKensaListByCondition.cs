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
    //  インターフェイス名 ： ISelectPrintFollowKensaListByConditionDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintFollowKensaListByConditionDAInput
    {
        /// <summary>
        /// 試験項目コード(pH)
        /// </summary>
        string ShikenKomokuCdPh { get; set; }

        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        string ShikenKomokuCdToshido { get; set; }

        /// <summary>
        /// 試験項目コード(BOD)
        /// </summary>
        string ShikenKomokuCdBod { get; set; }

        /// <summary>
        /// 試験項目コード(残塩)
        /// </summary>
        string ShikenKomokuCdZanen { get; set; }
        
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

        /// <summary>
        /// 支所
        /// </summary>
        string ShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintFollowKensaListByConditionDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintFollowKensaListByConditionDAInput : ISelectPrintFollowKensaListByConditionDAInput
    {
        /// <summary>
        /// 試験項目コード(pH)
        /// </summary>
        public string ShikenKomokuCdPh { get; set; }

        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        public string ShikenKomokuCdToshido { get; set; }

        /// <summary>
        /// 試験項目コード(BOD)
        /// </summary>
        public string ShikenKomokuCdBod { get; set; }

        /// <summary>
        /// 試験項目コード(残塩)
        /// </summary>
        public string ShikenKomokuCdZanen { get; set; }

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

        /// <summary>
        /// 支所
        /// </summary>
        public string ShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrintFollowKensaListByConditionDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintFollowKensaListByConditionDAOutput
    {
        /// <summary>
        /// PrintFollowKensaList
        /// </summary>
        SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListDataTable PrintFollowKensaList { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintFollowKensaListByConditionDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintFollowKensaListByConditionDAOutput : ISelectPrintFollowKensaListByConditionDAOutput
    {
        /// <summary>
        /// PrintFollowKensaList
        /// </summary>
        public SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListDataTable PrintFollowKensaList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintFollowKensaListByConditionDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintFollowKensaListByConditionDataAccess : BaseDataAccess<ISelectPrintFollowKensaListByConditionDAInput, ISelectPrintFollowKensaListByConditionDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private PrintFollowKensaListTableAdapter tableAdapter = new PrintFollowKensaListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrintFollowKensaListByConditionDataAccess
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
        public SelectPrintFollowKensaListByConditionDataAccess()
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
        /// 2014/12/12　豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectPrintFollowKensaListByConditionDAOutput Execute(ISelectPrintFollowKensaListByConditionDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrintFollowKensaListByConditionDAOutput output = new SelectPrintFollowKensaListByConditionDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.PrintFollowKensaList = tableAdapter.GetDataByCondition(input.ShikenKomokuCdPh, input.ShikenKomokuCdToshido, input.ShikenKomokuCdBod, input.ShikenKomokuCdZanen,
                    input.Nendo, input.IraiDateKbn, input.IraiDateFrom, input.IraiDateTo, input.IraiNoFrom, input.IraiNoTo, input.ShishoCd);
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
