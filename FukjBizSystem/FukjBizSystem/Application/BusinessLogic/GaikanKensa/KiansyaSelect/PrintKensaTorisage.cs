using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KiansyaSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaTorisageBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaTorisageBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensaTorisagePrintInfoDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaTorisagePrintInfoDataTable KensaTorisagePrintInfoDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaTorisageBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaTorisageBLInput : BaseExcelPrintBLInputImpl, IPrintKensaTorisageBLInput
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
        /// KensaTorisagePrintInfoDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaTorisagePrintInfoDataTable KensaTorisagePrintInfoDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaTorisageBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaTorisageBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaTorisageBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaTorisageBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensaTorisageBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaTorisageBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaTorisageBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensaTorisageBLInput, IPrintKensaTorisageBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensaTorisageBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensaTorisageBusinessLogic()
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
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensaTorisageBLOutput SetBook(IPrintKensaTorisageBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensaTorisageBLOutput output = new PrintKensaTorisageBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                KensaIraiTblDataSet.KensaTorisagePrintInfoRow printRow = input.KensaTorisagePrintInfoDataTable[0];

                //支所名＋部署名 (1)
                CellOutput(outputSheet, 6, 7, printRow.ShishoNm + " " + printRow.BushoNm);

                //検査員名 (2)
                CellOutput(outputSheet, 7, 7, printRow.ShokuinNm);

                //設置者名（漢字）(3)
                CellOutput(outputSheet, 8, 7, printRow.KensaIraiSetchishaNm);

                //入金先金融機関 (4)
                CellOutput(outputSheet, 9, 7, printRow.MaeukekinKinyukikanValue);

                //入金日付 (5)
                CellOutput(outputSheet, 10, 7, Utility.DateUtility.ConvertToWareki(printRow.MaeukekinNyukinDt, "yy年MM月dd日"));

                //システム日付 (6)
                CellOutput(outputSheet, 6, 21, Utility.DateUtility.ConvertToWareki(currentDateTime.ToString("yyyyMMdd"), "yy年MM月dd日"));

                // (7)
                CellOutput(outputSheet, 7, 21, Utility.DateUtility.ConvertToWareki(string.Concat(printRow.KensaIraiNen, printRow.KensaIraiTsuki, printRow.KensaIraiBi), "yy年MM月dd日"));

                //設置者（電話番号）(8)
                CellOutput(outputSheet, 8, 21, printRow.KensaIraiSetchishaTelNo);

                //前受照合番号 (9)
                CellOutput(outputSheet, 9, 20, printRow.MaeukekinSyogoNo);

                //検査番号(10)
                //CellOutput(outputSheet, 10, 20, printRow.JokasoNo);
                //update version
                CellOutput(outputSheet, 10, 20, string.Format("{0}-{1}-{2}", printRow.KensaIraiHokenjoCd, 
                                                                            Utility.DateUtility.ConvertToWareki(printRow.KensaIraiNendo, "yy"), 
                                                                            printRow.KensaIraiRenban));

                //入金額 (11)
                CellOutput(outputSheet, 23, 7, !printRow.IsMaeukekinNyukinAmtNull() ? printRow.MaeukekinNyukinAmt.ToString() : string.Empty);

                //振込人名カナ (12)
                CellOutput(outputSheet, 26, 8, printRow.MaeukekinFurikomininKana);

            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
