using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using FukjBizSystem.Application.DataSet.GaikanKensa;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IMake7JoKensaSetchiJokyoHaakuHyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IMake7JoKensaSetchiJokyoHaakuHyoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        string KyokaiNo { get; set; }

        /// <summary>
        /// KensaHoryuShosaiDataTable
        /// </summary>
        KensaHoryuDataSet.KensaHoryuShosaiDataTable KensaHoryuShosaiDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Make7JoKensaSetchiJokyoHaakuHyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Make7JoKensaSetchiJokyoHaakuHyoBLInput : BaseExcelPrintBLInputImpl, IMake7JoKensaSetchiJokyoHaakuHyoBLInput
    {
        ///// <summary>
        ///// 保存ファイルモード
        ///// </summary>
        //public int SaveFileMode { get; set; }

        ///// <summary>
        ///// ＥＸＣＥＬ書式へのパス
        ///// </summary>
        //public string FormatPath { get; set; }

        ///// <summary>
        ///// 帳票ディレクトリパス
        ///// </summary>
        //public string PrintDirectory { get; set; }

        ///// <summary>
        ///// 指定保存パス
        ///// 未指定の場合は、帳票出力ディレクトリに出力されます
        ///// </summary>
        //public string SavePath { get; set; }

        ///// <summary>
        ///// 処理後ＥＸＣＥＬ表示フラグ
        ///// </summary>
        //public bool AfterDispFlg { get; set; }

        ///// <summary>
        ///// 処理後印刷フラグ
        ///// </summary>
        //public bool AfterPrintFlg { get; set; }

        ///// <summary>
        ///// 印刷プリンタ名
        ///// </summary>
        //public string PrinterName { get; set; }

        /// <summary>
        /// 協会No
        /// </summary>
        public string KyokaiNo { get; set; }

        /// <summary>
        /// KensaHoryuShosaiDataTable
        /// </summary>
        public KensaHoryuDataSet.KensaHoryuShosaiDataTable KensaHoryuShosaiDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IMake7JoKensaSetchiJokyoHaakuHyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IMake7JoKensaSetchiJokyoHaakuHyoBLOutput : IBaseExcelPrintBLOutput
    {
        /// <summary>
        /// FALSE: File created successfully, otherwise failed!
        /// </summary>
        bool FileCrash { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Make7JoKensaSetchiJokyoHaakuHyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Make7JoKensaSetchiJokyoHaakuHyoBLOutput : BaseExcelPrintBLOutputImpl, IMake7JoKensaSetchiJokyoHaakuHyoBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// FALSE: File created successfully, otherwise failed!
        /// </summary>
        public bool FileCrash { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Make7JoKensaSetchiJokyoHaakuHyoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Make7JoKensaSetchiJokyoHaakuHyoBusinessLogic : BaseExcelPrintBusinessLogic<IMake7JoKensaSetchiJokyoHaakuHyoBLInput, IMake7JoKensaSetchiJokyoHaakuHyoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Make7JoKensaSetchiJokyoHaakuHyoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Make7JoKensaSetchiJokyoHaakuHyoBusinessLogic()
        {
            
        }
        #endregion

        #region メソッド(protected)

        #region SetBook
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetBook
        /// <summary>
        /// ＥＸＣＥＬのブックオブジェクトにデータを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">入力</param>
        /// <param name="book">ＥＸＣＥＬのブックオブジェクト</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IMake7JoKensaSetchiJokyoHaakuHyoBLOutput SetBook(IMake7JoKensaSetchiJokyoHaakuHyoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IMake7JoKensaSetchiJokyoHaakuHyoBLOutput output = new Make7JoKensaSetchiJokyoHaakuHyoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Set output sheet to current active sheet
                outputSheet = (Worksheet)book.Sheets["Sheet1"];
                outputSheet.Name = "7条検査設置状況把握票";

                KensaHoryuDataSet.KensaHoryuShosaiRow row = input.KensaHoryuShosaiDataTable[0];
                
                // 検査番号(1)
                CellOutput(outputSheet, 2, 3, input.KyokaiNo);

                // 設置者名（漢字）(2)
                CellOutput(outputSheet, 2, 15, row.KensaIraiSetchishaNm);

                // 設置者（電話番号）(3)
                CellOutput(outputSheet, 2, 26, row.KensaIraiSetchishaTelNo);
            }
            catch
            {
                // Create file failed!
                output.FileCrash = true;
            }
            finally
            {
                #region オブジェクトを解放
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
