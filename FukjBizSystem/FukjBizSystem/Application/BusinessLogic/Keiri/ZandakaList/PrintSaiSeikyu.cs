using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.SaiSeikyuSyukeiWrk;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.ZandakaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSaiSeikyuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSaiSeikyuBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 請求日（終了）
        /// </summary>
        DateTime SeikyuDtTo { get; set; }

        /// <summary>
        /// 再請求番号
        /// </summary>
        string SaiSeikyuNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSaiSeikyuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaiSeikyuBLInput : BaseExcelPrintBLInputImpl, IPrintSaiSeikyuBLInput
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
        /// 請求日（終了）
        /// </summary>
        public DateTime SeikyuDtTo { get; set; }

        /// <summary>
        /// 再請求番号
        /// </summary>
        public string SaiSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSaiSeikyuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSaiSeikyuBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSaiSeikyuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaiSeikyuBLOutput : BaseExcelPrintBLOutputImpl, IPrintSaiSeikyuBLOutput
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
    //  クラス名 ： PrintSaiSeikyuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaiSeikyuBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSaiSeikyuBLInput, IPrintSaiSeikyuBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSaiSeikyuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSaiSeikyuBusinessLogic()
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
        /// 2014/09/18　AnhNV　　    新規作成
        /// 2015/01/21　HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSaiSeikyuBLOutput SetBook(IPrintSaiSeikyuBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSaiSeikyuBLOutput output = new PrintSaiSeikyuBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Paginator
                string tempGyoshaCd = null;
                string tempJokasoCd = string.Empty;
                string jokasoCd = string.Empty;
                int sheetIdx = 1;
                // Start of detail row
                int curRow = 18;
                // Current system date
                DateTime systemDt = Boundary.Common.Common.GetCurrentTimestamp();

                // Preparing data
                ISelectSaiseiKyuShoInfoDAOutput daOutput = new SelectSaiseiKyuShoInfoDataAccess().Execute(new SelectSaiseiKyuShoInfoDAInput());
                SaiSeikyuSyukeiWrkDataSet.SaiseiKyuShoDataTable printTable = daOutput.SaiseiKyuShoDataTable;

                //foreach (SaiSeikyuSyukeiWrkDataSet.SaiseiKyuShoRow row in printTable.Select(string.Empty, "SeikyuGyosyaCd, SeikyuYM"))
                foreach (SaiSeikyuSyukeiWrkDataSet.SaiseiKyuShoRow row in printTable.Select(string.Empty, "SeikyusakiKbn, SeikyuGyosyaCd, JokasoHokenjoCd, JokasoTorokuNendo, JokasoRenban, SeikyuYM"))
                {
                    //Ver1.02
                    jokasoCd = string.Concat(row.JokasoHokenjoCd, row.JokasoTorokuNendo, row.JokasoRenban);

                    // New sheet?
                    //if (tempGyoshaCd != row.SeikyuGyosyaCd)
                    if (tempGyoshaCd != row.SeikyuGyosyaCd || jokasoCd != tempJokasoCd)
                    {
                        // From sheet >= 2?
                        if (curRow > 18)
                        {
                            // Sum before changing page
                            MakeSumRow(outputSheet, curRow);

                            // ログイン者名
                            CellOutput(outputSheet, curRow + 13, 20, Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm);
                        }

                        // Copy a new sheet
                        tempSheet = (Worksheet)book.Sheets["Sheet1"];
                        tempSheet.Copy(tempSheet, Type.Missing);

                        // Set output sheet to current active sheet
                        outputSheet = (Worksheet)book.ActiveSheet;
                        //outputSheet.Name = string.Concat("再請求書_", row.SeikyuGyosyaCd);
                        outputSheet.Name = string.Concat("再請求書_", sheetIdx);

                        // Header
                        SetHeader(outputSheet, row, input.SeikyuDtTo, systemDt, input.SaiSeikyuNo);

                        // Reset index of detail row
                        curRow = 18;
                        sheetIdx++;
                    }

                    // Insert a new detail row
                    if (curRow > 18)
                    {
                        // Insert a new row
                        InsertRow(outputSheet, curRow);

                        // Merge cells
                        MergeCells(outputSheet, curRow);

                        // Sum in line
                        CellOutput(outputSheet, curRow, 22, string.Format("=sum(G{0}:V{0})", curRow + 1));
                    }

                    // Detail
                    SetDetail(outputSheet, row, curRow);

                    // Reset paginator
                    tempGyoshaCd = row.SeikyuGyosyaCd;
                    tempJokasoCd = jokasoCd;

                    // Moving to next detail row
                    curRow++;
                }

                // At least 1 row added to 1 sheet?
                if (curRow > 18)
                {
                    // Sum for last page
                    MakeSumRow(outputSheet, curRow);

                    // ログイン者名 (last page)
                    CellOutput(outputSheet, curRow + 13, 20, Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm);
                }

                // 2シート以上あるか？
                if (book.Sheets.Count > 1 && tempSheet != null)
                {
                    // テンプレートシートを削除
                    tempSheet.Delete();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                #region オブジェクトを解放
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SetHeader
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <param name="seikyuDtTo"></param>
        /// <param name="systemDt"></param>
        /// <param name="saiSeikyuNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader
            (
                Worksheet outputSheet,
                SaiSeikyuSyukeiWrkDataSet.SaiseiKyuShoRow row,
                DateTime seikyuDtTo,
                DateTime systemDt,
                string saiSeikyuNo
            )
        {
            // 再請求番号
            CellOutput(outputSheet, 0, 23, string.Concat("'", saiSeikyuNo));

            // システム日付
            string wareki = string.Concat("'", Utility.DateUtility.ConvertToWareki(systemDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));
            CellOutput(outputSheet, 1, 19, wareki);

            // 業者名称
            CellOutput(outputSheet, 2, 1, row.GyoshaNm + "  殿");

            // 請求年月
            string seikyuYM = string.Concat("'", Utility.DateUtility.ConvertToWareki(row.SeikyuYM, "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki));
            CellOutput(outputSheet, 10, 12, seikyuYM);

            // 請求日To
            //CellOutput(outputSheet, 11, 1, string.Concat("平成", seikyuDtTo.Year - 1988, "年", seikyuDtTo.Month, "月", seikyuDtTo.Day, "日", "現在、"));
            CellOutput(outputSheet, 11, 1, string.Concat("'", Utility.DateUtility.ConvertToWareki(seikyuDtTo.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki) + "現在、"));
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Worksheet outputSheet, SaiSeikyuSyukeiWrkDataSet.SaiseiKyuShoRow row, int curRow)
        {
            // 請求年月
            string seikyuYM = string.Concat("'", Utility.DateUtility.ConvertToWareki(row.SeikyuYM, "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki), "分");
            CellOutput(outputSheet, curRow, 1, seikyuYM);

            // 11条水質検査
            CellOutput(outputSheet, curRow, 6, row.IsKensa11SuishitsuNull() ? string.Empty : row.Kensa11Suishitsu.ToString("N0"));

            // 11条外観検査
            CellOutput(outputSheet, curRow, 10, row.IsKensa11GaikanNull() ? string.Empty : row.Kensa11Gaikan.ToString("N0"));

            // 用紙販売
            CellOutput(outputSheet, curRow, 14, row.IsYoshiHanbaiNull() ? string.Empty : row.YoshiHanbai.ToString("N0"));

            // 年会費
            CellOutput(outputSheet, curRow, 18, row.IsNenkaihiNull() ? string.Empty : row.Nenkaihi.ToString("N0"));
        }
        #endregion

        #region MakeSumRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSumRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="curRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSumRow(Worksheet outputSheet, int curRow)
        {
            CellOutput(outputSheet, curRow, 6, string.Format("=sum(G19:J{0})", curRow));
            CellOutput(outputSheet, curRow, 10, string.Format("=sum(K19:N{0})", curRow));
            CellOutput(outputSheet, curRow, 14, string.Format("=sum(O19:R{0})", curRow));
            CellOutput(outputSheet, curRow, 18, string.Format("=sum(S19:V{0})", curRow));
        }
        #endregion

        #region MergeCells
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MergeCells
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="curRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MergeCells(Worksheet outputSheet, int curRow)
        {
            outputSheet.get_Range(string.Format("B{0}", curRow + 1), string.Format("F{0}", curRow + 1)).Merge();
            outputSheet.get_Range(string.Format("G{0}", curRow + 1), string.Format("J{0}", curRow + 1)).Merge();
            outputSheet.get_Range(string.Format("K{0}", curRow + 1), string.Format("N{0}", curRow + 1)).Merge();
            outputSheet.get_Range(string.Format("O{0}", curRow + 1), string.Format("R{0}", curRow + 1)).Merge();
            outputSheet.get_Range(string.Format("S{0}", curRow + 1), string.Format("V{0}", curRow + 1)).Merge();
            outputSheet.get_Range(string.Format("W{0}", curRow + 1), string.Format("Z{0}", curRow + 1)).Merge();
        }
        #endregion

        #endregion
    }
    #endregion
}
