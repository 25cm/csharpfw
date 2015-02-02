using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKeiryoShomeiOutputListType2BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成    
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKeiryoShomeiOutputListType2BLInput : IBaseExcelPrintBLInput
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
        /// KeiryoShomeiIraiNendo
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        string Renban { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        string SishoCd { get; set; }

        /// <summary>
        /// Convert file status
        /// </summary>
        bool ConvertStatus { get; set; }

        /// <summary>
        /// Pdf filename
        /// </summary>
        string FileNamePdf { get; set; }

        /// <summary>
        /// Save file directory
        /// </summary>
        string ServerSavePath { get; set; }

        /// <summary>
        /// KeiryoShomeiShomeishoInsatsuCnt
        /// </summary>
        bool IsPlusCnt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKeiryoShomeiOutputListType2BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成    
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKeiryoShomeiOutputListType2BLInput : BaseExcelPrintBLInputImpl, IPrintKeiryoShomeiOutputListType2BLInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        public string Renban { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        public string SishoCd { get; set; }

        /// <summary>
        /// Convert file status
        /// </summary>
        public bool ConvertStatus { get; set; }

        /// <summary>
        /// Pdf filename
        /// </summary>
        public string FileNamePdf { get; set; }

        /// <summary>
        /// Save file directory
        /// </summary>
        public string ServerSavePath { get; set; }

        /// <summary>
        /// KeiryoShomeiShomeishoInsatsuCnt
        /// </summary>
        public bool IsPlusCnt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKeiryoShomeiOutputListType2BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKeiryoShomeiOutputListType2BLOutput : IBaseExcelPrintBLOutput
    {
        /// <summary>
        /// Print Exception
        /// </summary>
        bool PrintErr { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKeiryoShomeiOutputListType2BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成    
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKeiryoShomeiOutputListType2BLOutput : BaseExcelPrintBLOutputImpl, IPrintKeiryoShomeiOutputListType2BLOutput
    {
        /// <summary>
        /// Print Exception
        /// </summary>
        public bool PrintErr { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKeiryoShomeiOutputListType2BusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKeiryoShomeiOutputListType2BusinessLogic : BaseExcelPrintBusinessLogic<IPrintKeiryoShomeiOutputListType2BLInput, IPrintKeiryoShomeiOutputListType2BLOutput>
    {
        #region 置換文字列

        /// <summary>
        /// Number of rows per page
        /// </summary>
        private const int ROW_IN_PAGE = 50;

        #region private

        ///// <summary>
        ///// PrintKeriyoShomeiType2DataTable
        ///// </summary>
        //private KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable _printTbl = new KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable();

        ///// <summary>
        ///// Today
        ///// </summary>
        //private DateTime _today = Boundary.Common.Common.GetCurrentTimestamp();

        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKeiryoShomeiOutputListType2BusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKeiryoShomeiOutputListType2BusinessLogic()
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// 2014/12/15  AnhNV　    refs #8116
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKeiryoShomeiOutputListType2BLOutput SetBook(IPrintKeiryoShomeiOutputListType2BLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKeiryoShomeiOutputListType2BLOutput output = new PrintKeiryoShomeiOutputListType2BLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;
                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Output sheet                
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                tempSheet.Copy(tempSheet, Type.Missing);
                outputSheet = (Worksheet)book.ActiveSheet;
                //outputSheet.Name = "Sheet 1";
                outputSheet.Name = "分析結果報告書";

                // Index of detail row
                int curRow = 0;
                // Start print position
                int printPoint = 0;
                // Page counter
                int pageCount = 0;
                DateTime curDt = Boundary.Common.Common.GetCurrentTimestamp();

                ISelectKeiryoShomeiIraiTblByKeyDAInput daByKeyInput = new SelectKeiryoShomeiIraiTblByKeyDAInput();
                daByKeyInput.KeiryoShomeiIraiNendo = input.Nendo;
                daByKeyInput.KeiryoShomeiIraiRenban = input.Renban;
                daByKeyInput.KeiryoShomeiIraiSishoCd = input.SishoCd;
                output.KeiryoShomeiIraiTblDataTable = new SelectKeiryoShomeiIraiTblByKeyDataAccess().Execute(daByKeyInput).KeiryoShomeiIraiTblDT;

                // Get print table
                KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable printTable = new KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable();
                ISelectPrintKeriyoShomeiType2TblDAInput daInput = new SelectPrintKeriyoShomeiType2TblDAInput();
                daInput.Nendo = input.Nendo;
                daInput.Renban = input.Renban;
                daInput.ShishoCd = input.SishoCd;
                printTable = new SelectPrintKeriyoShomeiType2TblDataAccess().Execute(daInput).PrintKeriyoShomeiType2DataTable;
                
                // Total page
                int pageNo = 1;/*printTable.Count % 14 == 0 ? (int)printTable.Count / 14 : (int)printTable.Count / 14 + 1;*/
                // Total of print data
                int totalDetailRow = printTable.Count;
                // Total of row in sheet
                int totalRowInSheet = 63; // default 1 page

                // Get total page
                if (totalDetailRow <= 14)
                {
                    // There is 1 page only
                }
                else
                {
                    pageNo += (totalDetailRow - 14) % 26 == 0 ? (int)(totalDetailRow - 14) / 26 : (int)(totalDetailRow - 14) / 26 + 1;
                }

                // Calculate the total of row in sheet
                if (pageNo > 1)
                {
                    // = 63 rows in page 1 + number of rows from page 2 + number of padding rows for each page
                    totalRowInSheet = 63 + 62 * (pageNo - 1) + (pageNo - 1);
                }

                foreach (KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2Row row in printTable)
                {
                    // First page
                    if (pageCount == 0)
                    {
                        // Process in first page
                        if (curRow == 0)
                        {
                            // Set header - 1 time only
                            SetHeader(outputSheet, printTable, curRow, pageNo, pageCount + 1, input.IsPlusCnt, curDt);
                        }

                        // Finish page 1?
                        if (curRow == 14)
                        {
                            // Move to page 2
                            curRow = 0;
                            printPoint += 11;
                            pageCount++;
                        }
                    }
                    else // From page 2
                    {
                        // From page 2, there are 26 detail rows per page
                        if (curRow % 26 == 0)
                        {
                            // Next print position
                            printPoint += 11;

                            // Copy detail rows from page 2 in template
                            //RowCopy(tempSheet, outputSheet, 65, 62, printPoint - 1, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, 64, 62, outputSheet, printPoint - 2);
                            // Page break
                            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[printPoint - 2, 1]);

                            // Next page
                            pageCount++;
                        }
                    }

                    // First detail row
                    if (pageCount == 0 && curRow == 0)
                    {
                        printPoint += 27;
                    }

                    // Detail from page 2
                    SetDetail(outputSheet, row, printPoint, pageNo, pageCount, totalDetailRow);

                    // Next detail row
                    printPoint += 2;
                    curRow++;
                }

                // More than 1 page
                if (pageNo > 1)
                {
                }
                else // There is only 1 page
                {
                    // Delete page 2
                    DeleteRow(outputSheet, 63, 63);
                }

                // 《   以   下   余   白   》- last detail row
                if (printTable.Count % 14 != 0 // in case of 1 page
                    || (printTable.Count - 14) / 26 != 0) // in case of multiple pages
                {
                    Microsoft.Office.Interop.Excel.Range rangeFrom = rangeFrom = outputSheet.get_Range(outputSheet.Cells[printPoint + 1, 15], outputSheet.Cells[printPoint + 1, 34]);
                    rangeFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    CellOutput(outputSheet, printPoint, 14, "《   以   下   余   白   》");
                }

                // Set Print area
                outputSheet.PageSetup.PrintArea = string.Format("A1:AW{0}", totalRowInSheet + 1); // 1 padding row

                // Focus to first cell in worksheet
                Range rng = outputSheet.get_Range("A1");
                rng.Select();

                // Delete template sheet
                if (book.Sheets.Count > 1)
                {
                    tempSheet.Delete();
                }

                #region comments
                //// Output sheet                
                //tempSheet = (Worksheet)book.Sheets["Sheet1"];
                //tempSheet.Copy(tempSheet, Type.Missing);
                //outputSheet = (Worksheet)book.ActiveSheet;
                //outputSheet.Name = "分析結果報告書";
                //// Index of detail row
                //int curRow = 0;
                //// output position
                //int printPoint = 0;
                //// page number
                //int pageCount = 0;
                //// Total of rows in sheet
                //int totalRow = 0;

                //// Get table by key
                //ISelectKeiryoShomeiIraiTblByKeyDAInput daByKeyInput = new SelectKeiryoShomeiIraiTblByKeyDAInput();
                //daByKeyInput.KeiryoShomeiIraiNendo = input.Nendo;
                //daByKeyInput.KeiryoShomeiIraiRenban = input.Renban;
                //daByKeyInput.KeiryoShomeiIraiSishoCd = input.SishoCd;
                //output.KeiryoShomeiIraiTblDataTable = new SelectKeiryoShomeiIraiTblByKeyDataAccess().Execute(daByKeyInput).KeiryoShomeiIraiTblDT;

                //ISelectPrintKeriyoShomeiType2TblDAInput daInput = new SelectPrintKeriyoShomeiType2TblDAInput();
                //daInput.Nendo = input.Nendo;
                //daInput.Renban = input.Renban;
                //daInput.ShishoCd = input.SishoCd;
                //_printTbl = new SelectPrintKeriyoShomeiType2TblDataAccess().Execute(daInput).PrintKeriyoShomeiType2DataTable;
                //DeleteRow(outputSheet, 63, 62);
                //// For test next page
                ////for (int i = 0; i < 120; i++)
                ////{
                ////    KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2Row importRow = _printTbl.NewPrintKeriyoShomeiType2Row();
                ////    importRow.JokasoSetchishaNm = "Test JokasoSetchishaNm" + i;
                ////    importRow.ShishoNm = "Test ShishoNm " + i;
                ////    importRow.JokasoNo = "Test JokasoNo" + i;
                ////    importRow.ShishoNmTorokuNo = "Test ShishoNmTorokuNo" + i;
                ////    importRow.ShishoAdr = "Test ShishoAdr" + i;
                ////    importRow.ShishoTelNo = "Test ShishoTelNo" + i;
                ////    importRow.ShishoKeiryoKanrisha = "Test ShishoKeiryoKanrisha" + i;
                ////    //importRow.ShishoKankyoKeiryoshiNo = "Test ShishoKankyoKeiryoshiNo" + i;
                ////    importRow.JokasoSetchiBashoAdr = "Test JokasoSetchiBashoAdr" + i;
                ////    importRow.ShoriHoshikiShubetsuNm = "Test ShoriHoshikiShubetsuNm " + i;
                ////    importRow.KeiryoShomeiIraiUketsukeDt = "20141204";
                ////    importRow.HokenjoNm = "Test HokenjoNm " + i;
                ////    importRow.KeiryoShomeiNinsou = "Test KeiryoShomeiNinsou " + i;
                ////    importRow.KeiryoShomeiHiHeikinOsuiRyo = i;
                ////    importRow.SuishitsuNm = "Test SuishitsuNm " + i;
                ////    importRow.GyoshaNm = "Test GyoshaNm " + i;
                ////    importRow.SeishikiNm = "Test SeishikiNm " + i;
                ////    importRow.KeiryouHouhouNmUp = "Test KeiryouHouhouNmUp " + i;
                ////    importRow.KeiryouHouhouNmDown = "Test KeiryouHouhouNmDown " + i;
                ////    importRow.BunsekiKekka = "Test BunsekiKekka " + i;
                ////    //importRow.KeiryouKekka = "Test KeiryouKekka " + i;
                ////    //importRow.Teiryou = "Test Teiryou " + i;
                ////    //importRow.KeiryoShomeiGaibuItakuFlg = "1";
                ////    _printTbl.AddPrintKeriyoShomeiType2Row(importRow);
                ////}
                //// total page number
                //int pageNo = _printTbl.Count % 14 == 0 ? (int)_printTbl.Count / 14 : (int)_printTbl.Count / 14 + 1;
                //if (_printTbl.Count > 0)
                //{
                //    // Total row in sheet = Header rows num (24 rows) + total pages * detail row num (38 rows) + padding rows (1 padding row/1 page)
                //    totalRow = 24 + pageNo * 38 + pageNo;

                //    // Print header
                //    SetHeader(outputSheet, _printTbl[0], curRow, pageNo, pageCount + 1, input.IsPlusCnt);
                //    foreach (KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2Row row in _printTbl)
                //    {
                //        if (curRow > 0 && curRow % 14 == 0 && _printTbl.Count > 14) // next page
                //        {
                //            printPoint += 11;
                //            // Break page
                //            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[printPoint - 2, 1]);
                //            // copy row                            
                //            RowCopy(tempSheet, outputSheet, 25, 63, printPoint - 2, XlPasteType.xlPasteAll);
                //            pageCount++;
                //        }
                //        if (curRow == 0)
                //        {
                //            printPoint += 27;
                //        }
                //        // Print details
                //        SetDetail(outputSheet, row, printPoint, pageNo, pageCount);

                //        curRow++;
                //        printPoint += 2;
                //    }
                //    // 《   以   下   余   白   》
                //    if (_printTbl.Count % 14 != 0)
                //    {
                //        Microsoft.Office.Interop.Excel.Range rangeFrom = rangeFrom = outputSheet.get_Range(outputSheet.Cells[printPoint + 1, 15], outputSheet.Cells[printPoint + 1, 34]);
                //        rangeFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //        CellOutput(outputSheet, printPoint, 14, "《   以   下   余   白   》");
                //    }
                //}

                //// 2014/12/13 AnhNV ADD Start
                //// Set Print area
                //outputSheet.PageSetup.PrintArea = string.Format("A1:AW{0}", totalRow + 1); // 1 padding row
                //if (pageNo > 1)
                //{
                //    // Delete unused rows from the last page
                //    DeleteRow(outputSheet, totalRow, totalRow + 38);
                //}

                //// Focus to first cell in worksheet
                //Range rng = outputSheet.get_Range("A1");
                //rng.Select();

                //// Delete template sheet
                //if (book.Sheets.Count > 1)
                //{
                //    tempSheet.Delete();
                //}
                //// 2014/12/13 AnhNV ADD End
                #endregion
            }
            catch
            {
                output.PrintErr = true;
                throw;
            }
            finally
            {
                #region オブジェクトを解放
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
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
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="printTable"></param>
        /// <param name="curRow"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageCount"></param>
        /// <param name="isPlus"></param>
        /// <param name="curDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成        
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader
            (
                Worksheet sheet,
                KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable printTable,/*KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2Row row*/
                int curRow,
                int pageNo,
                int pageCount,
                bool isPlus,
                DateTime curDt
            )
        {
            if (pageNo > 0 && printTable.Count > 14)
            {
                // Page count
                CellOutput(sheet, curRow, 44, String.Concat(pageCount, "/", pageNo));
            }

            string wareki = Utility.DateUtility.ConvertToWareki(curDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
            string uketsukeDt = Utility.DateUtility.ConvertToWareki(printTable[0].IsKeiryoShomeiIraiUketsukeDtNull() ? String.Empty : printTable[0].KeiryoShomeiIraiUketsukeDt, "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
            int cnt = printTable[0].IsKeiryoShomeiShomeishoInsatsuCntNull() ? 0 : Int32.Parse(printTable[0].KeiryoShomeiShomeishoInsatsuCnt);
            if (isPlus) cnt = cnt + 1;
            // (1)
            CellOutput(sheet, curRow + 6, 1, printTable[0].IsNull("JokasoSetchishaNm") ? String.Empty : printTable[0].JokasoSetchishaNm);
            if (cnt > 0)
            {
                // (2)
                CellOutput(sheet, curRow + 3, 40, printTable[0].IsNull("ShishoNm") ? String.Empty : String.Concat(printTable[0].ShishoNm, "-", cnt));
            }
            else
            {
                // (2)
                CellOutput(sheet, curRow + 3, 40, printTable[0].IsNull("ShishoNm") ? String.Empty : printTable[0].ShishoNm);
            }
            
            // (3)
            CellOutput(sheet, curRow + 4, 39, printTable[0].IsNull("JokasoNo") ? String.Empty : printTable[0].JokasoNo);
            // (4)
            CellOutput(sheet, curRow + 5, 39, wareki);
            // (5)
            CellOutput(sheet, curRow + 8, 35, printTable[0].IsNull("ShishoNmTorokuNo") ? String.Empty : printTable[0].ShishoNmTorokuNo);
            // (6)
            CellOutput(sheet, curRow + 9, 35, printTable[0].IsNull("ShishoAdr") ? String.Empty : printTable[0].ShishoAdr);
            // (7)
            CellOutput(sheet, curRow + 10, 37, printTable[0].IsNull("ShishoTelNo") ? String.Empty : printTable[0].ShishoTelNo);
            // (8)
            CellOutput(sheet, curRow + 12, 37, printTable[0].IsNull("ShishoKeiryoKanrisha") ? String.Empty : printTable[0].ShishoKeiryoKanrisha);
            // (10)
            CellOutput(sheet, curRow + 16, 8, printTable[0].IsNull("JokasoSetchiBashoAdr") ? String.Empty : printTable[0].JokasoSetchiBashoAdr);
            // (11)
            CellOutput(sheet, curRow + 18, 8, printTable[0].IsNull("ShoriHoshikiShubetsuNm") ? String.Empty : printTable[0].ShoriHoshikiShubetsuNm);
            // (12)
            CellOutput(sheet, curRow + 20, 8, uketsukeDt);
            // (13)
            CellOutput(sheet, curRow + 22, 8, printTable[0].IsHokenjoNmNull() ? String.Empty : printTable[0].HokenjoNm);
            // (14)
            CellOutput(sheet, curRow + 18, 34, printTable[0].IsKeiryoShomeiNinsouNull() ? String.Empty : printTable[0].KeiryoShomeiNinsou);
            // (15)
            CellOutput(sheet, curRow + 18, 40, printTable[0].IsKeiryoShomeiHiHeikinOsuiRyoNull() ? String.Empty : printTable[0].KeiryoShomeiHiHeikinOsuiRyo.ToString());
            // (16)
            CellOutput(sheet, curRow + 20, 34, printTable[0].IsSuishitsuNmNull() ? String.Empty : String.Concat("'", printTable[0].SuishitsuNm));
            // (17)
            CellOutput(sheet, curRow + 22, 34, printTable[0].IsGyoshaNmNull() ? String.Empty : printTable[0].GyoshaNm);
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDetail
        /// <summary>
        /// 預券明細情報をセット
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageCount"></param>
        /// <param name="totalPrintRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成        
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail
            (
                Worksheet sheet,
                KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2Row row,
                int curRow,
                int pageNo,
                int pageCount,
                int totalPrintRow
            )
        {
            // Page number
            if (pageNo > 0 && /*_printTbl.Count*/totalPrintRow > 14 && pageCount > 0)
            {
                Microsoft.Office.Interop.Excel.Range rangeFrom = rangeFrom = sheet.get_Range(sheet.Cells[curRow - 2, 45], sheet.Cells[curRow - 2, 48]);
                rangeFrom.Merge(Type.Missing);
                rangeFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                CellOutput(sheet, curRow - 3, 44, String.Concat("'", pageCount + 1, "/", pageNo));
            }
            // (18)
            CellOutput(sheet, curRow, 1, row.IsSeishikiNmNull() ? String.Empty : row.SeishikiNm);
            // (19)
            CellOutput(sheet, curRow, 14, row.IsKeiryouHouhouNmUpNull() ? String.Empty : row.KeiryouHouhouNmUp);
            // (20)
            CellOutput(sheet, curRow + 1, 14, row.IsKeiryouHouhouNmDownNull() ? String.Empty : row.KeiryouHouhouNmDown);
            // (21)
            CellOutput(sheet, curRow, 35, row.IsBunsekiKekkaNull() ? String.Empty : row.BunsekiKekka);
        }
        #endregion

        #endregion
    }
    #endregion
}
