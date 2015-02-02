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
    //  インターフェイス名 ： ISelectPrint11joKensaDaichoByConditionDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrint11joKensaDaichoByConditionDAInput
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
        /// 検査区分
        /// </summary>
        string KensaKbn { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        string IraiNoTo { get; set; }

        /// <summary>
        /// 試験項目コード(pH)
        /// </summary>
        string kmkCdPh { get; set; }

        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        string kmkCdTr { get; set; }

        /// <summary>
        /// 試験項目コード(BOD)
        /// </summary>
        string kmkCdBod { get; set; }

        /// <summary>
        /// 試験項目コード(残塩)
        /// </summary>
        string kmkCdZanen { get; set; }

        /// <summary>
        /// 試験項目コード(塩化物イオン)
        /// </summary>
        string kmkCdCl { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrint11joKensaDaichoByConditionDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrint11joKensaDaichoByConditionDAInput : ISelectPrint11joKensaDaichoByConditionDAInput
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
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        public string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        public string IraiNoTo { get; set; }

        /// <summary>
        /// 試験項目コード(pH)
        /// </summary>
        public string kmkCdPh { get; set; }

        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        public string kmkCdTr { get; set; }

        /// <summary>
        /// 試験項目コード(BOD)
        /// </summary>
        public string kmkCdBod { get; set; }

        /// <summary>
        /// 試験項目コード(残塩)
        /// </summary>
        public string kmkCdZanen { get; set; }

        /// <summary>
        /// 試験項目コード(塩化物イオン)
        /// </summary>
        public string kmkCdCl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrint11joKensaDaichoByConditionDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrint11joKensaDaichoByConditionDAOutput
    {
        /// <summary>
        /// Print11joKensaDaicho
        /// </summary>
        SuishitsuKensaUketsukeReportDataSet.Print11joKensaDaichoDataTable Print11joKensaDaicho { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrint11joKensaDaichoByConditionDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrint11joKensaDaichoByConditionDAOutput : ISelectPrint11joKensaDaichoByConditionDAOutput
    {
        /// <summary>
        /// Print11joKensaDaicho
        /// </summary>
        public SuishitsuKensaUketsukeReportDataSet.Print11joKensaDaichoDataTable Print11joKensaDaicho { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrint11joKensaDaichoByConditionDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrint11joKensaDaichoByConditionDataAccess : BaseDataAccess<ISelectPrint11joKensaDaichoByConditionDAInput, ISelectPrint11joKensaDaichoByConditionDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Print11joKensaDaichoTableAdapter tableAdapter = new Print11joKensaDaichoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrint11joKensaDaichoByConditionDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16　宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectPrint11joKensaDaichoByConditionDataAccess()
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
        /// 2014/12/16　宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectPrint11joKensaDaichoByConditionDAOutput Execute(ISelectPrint11joKensaDaichoByConditionDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrint11joKensaDaichoByConditionDAOutput output = new SelectPrint11joKensaDaichoByConditionDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Print11joKensaDaicho = tableAdapter.GetDataByCondition(input.ShishoCd, input.Nendo, input.IraiDateKbn, input.IraiDateFrom, input.IraiDateTo, input.KensaKbn, input.IraiNoFrom, input.IraiNoTo,
                    input.kmkCdPh, input.kmkCdTr, input.kmkCdBod, input.kmkCdZanen, input.kmkCdCl);
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
