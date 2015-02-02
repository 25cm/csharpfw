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
    //  インターフェイス名 ： ISelectPrint9joKensaDaichoDtlByConditionDAInput
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
    interface ISelectPrint9joKensaDaichoDtlByConditionDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        
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
    //  クラス名 ： SelectPrint9joKensaDaichoDtlByConditionDAInput
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
    class SelectPrint9joKensaDaichoDtlByConditionDAInput : ISelectPrint9joKensaDaichoDtlByConditionDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

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
    //  インターフェイス名 ： ISelectPrint9joKensaDaichoDtlByConditionDAOutput
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
    interface ISelectPrint9joKensaDaichoDtlByConditionDAOutput
    {
        /// <summary>
        /// Print9joKensaDaichoDtl
        /// </summary>
        SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoDtlDataTable Print9joKensaDaichoDtl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrint9joKensaDaichoDtlByConditionDAOutput
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
    class SelectPrint9joKensaDaichoDtlByConditionDAOutput : ISelectPrint9joKensaDaichoDtlByConditionDAOutput
    {
        /// <summary>
        /// Print9joKensaDaichoDtl
        /// </summary>
        public SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoDtlDataTable Print9joKensaDaichoDtl { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrint9joKensaDaichoDtlByConditionDataAccess
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
    class SelectPrint9joKensaDaichoDtlByConditionDataAccess : BaseDataAccess<ISelectPrint9joKensaDaichoDtlByConditionDAInput, ISelectPrint9joKensaDaichoDtlByConditionDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Print9joKensaDaichoDtlTableAdapter tableAdapter = new Print9joKensaDaichoDtlTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrint9joKensaDaichoDtlByConditionDataAccess
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
        public SelectPrint9joKensaDaichoDtlByConditionDataAccess()
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
        public override ISelectPrint9joKensaDaichoDtlByConditionDAOutput Execute(ISelectPrint9joKensaDaichoDtlByConditionDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrint9joKensaDaichoDtlByConditionDAOutput output = new SelectPrint9joKensaDaichoDtlByConditionDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Print9joKensaDaichoDtl = tableAdapter.GetDataByCondition(input.ShishoCd, input.Nendo, input.IraiDateKbn, input.IraiDateFrom, input.IraiDateTo, input.IraiNoFrom, input.IraiNoTo);
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
