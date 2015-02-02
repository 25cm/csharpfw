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
    //  インターフェイス名 ： ISelectPrint9joKensaDaichoHdrByConditionDAInput
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
    interface ISelectPrint9joKensaDaichoHdrByConditionDAInput
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
    //  クラス名 ： SelectPrint9joKensaDaichoHdrByConditionDAInput
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
    class SelectPrint9joKensaDaichoHdrByConditionDAInput : ISelectPrint9joKensaDaichoHdrByConditionDAInput
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
    //  インターフェイス名 ： ISelectPrint9joKensaDaichoHdrByConditionDAOutput
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
    interface ISelectPrint9joKensaDaichoHdrByConditionDAOutput
    {
        /// <summary>
        /// Print9joKensaDaichoHdr
        /// </summary>
        SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoHdrDataTable Print9joKensaDaichoHdr { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrint9joKensaDaichoHdrByConditionDAOutput
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
    class SelectPrint9joKensaDaichoHdrByConditionDAOutput : ISelectPrint9joKensaDaichoHdrByConditionDAOutput
    {
        /// <summary>
        /// Print9joKensaDaichoHdr
        /// </summary>
        public SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoHdrDataTable Print9joKensaDaichoHdr { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrint9joKensaDaichoHdrByConditionDataAccess
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
    class SelectPrint9joKensaDaichoHdrByConditionDataAccess : BaseDataAccess<ISelectPrint9joKensaDaichoHdrByConditionDAInput, ISelectPrint9joKensaDaichoHdrByConditionDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Print9joKensaDaichoHdrTableAdapter tableAdapter = new Print9joKensaDaichoHdrTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrint9joKensaDaichoHdrByConditionDataAccess
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
        public SelectPrint9joKensaDaichoHdrByConditionDataAccess()
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
        public override ISelectPrint9joKensaDaichoHdrByConditionDAOutput Execute(ISelectPrint9joKensaDaichoHdrByConditionDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrint9joKensaDaichoHdrByConditionDAOutput output = new SelectPrint9joKensaDaichoHdrByConditionDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Print9joKensaDaichoHdr = tableAdapter.GetDataByCondition(input.ShishoCd, input.Nendo, input.IraiDateKbn, input.IraiDateFrom, input.IraiDateTo, input.IraiNoFrom, input.IraiNoTo);
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
