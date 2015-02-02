using System;
using System.Data;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.GyoshaMst;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKeiryoShomeiOutputListType1BLInput
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
    interface IPrintKeiryoShomeiOutputListType1BLInput : IBaseExcelPrintBLInput
    {
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
    //  クラス名 ： PrintKeiryoShomeiOutputListType1BLInput
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
    class PrintKeiryoShomeiOutputListType1BLInput : BaseExcelPrintBLInputImpl, IPrintKeiryoShomeiOutputListType1BLInput
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
    //  インターフェイス名 ： IPrintKeiryoShomeiOutputListType1BLOutput
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
    interface IPrintKeiryoShomeiOutputListType1BLOutput : IBaseExcelPrintBLOutput
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
    //  クラス名 ： PrintKeiryoShomeiOutputListType1BLOutput
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
    class PrintKeiryoShomeiOutputListType1BLOutput : BaseExcelPrintBLOutputImpl, IPrintKeiryoShomeiOutputListType1BLOutput
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
    //  クラス名 ： PrintKeiryoShomeiOutputListType1BusinessLogic
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
    class PrintKeiryoShomeiOutputListType1BusinessLogic : BaseExcelPrintBusinessLogic<IPrintKeiryoShomeiOutputListType1BLInput, IPrintKeiryoShomeiOutputListType1BLOutput>
    {
        #region 置換文字列

        #region private

        /// <summary>
        /// PrintKeriyoShomeiType1DataTable
        /// </summary>
        //private KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable _printTbl = new KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable();
        //private string _gyoshaNmAdr = String.Empty;

        /// <summary>
        /// Today
        /// </summary>
        //private DateTime _today = Boundary.Common.Common.GetCurrentTimestamp();
        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKeiryoShomeiOutputListType1BusinessLogic
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
        public PrintKeiryoShomeiOutputListType1BusinessLogic()
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
        protected override IPrintKeiryoShomeiOutputListType1BLOutput SetBook(IPrintKeiryoShomeiOutputListType1BLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKeiryoShomeiOutputListType1BLOutput output = new PrintKeiryoShomeiOutputListType1BLOutput();

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
                outputSheet.Name = "濃度計量証明書";

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
                KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable printTable = new KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable();
                ISelectPrintKeriyoShomeiType1TblDAInput daInput = new SelectPrintKeriyoShomeiType1TblDAInput();
                daInput.Nendo = input.Nendo;
                daInput.Renban = input.Renban;
                daInput.ShishoCd = input.SishoCd;
                printTable = new SelectPrintKeriyoShomeiType1TblDataAccess().Execute(daInput).PrintKeriyoShomeiType1DataTable;
                
                // GyoshaNm + Adr
                string gyoshaNmAdr = GetGyoshaNmAdr(printTable);

                // 20150131 sou Start
                string saisuiInfo = GetSaisuiInfo(output.KeiryoShomeiIraiTblDataTable);
                // 20150131 sou End

                // Total page
                int pageNo = 1;/*printTable.Count % 14 == 0 ? (int)printTable.Count / 14 : (int)printTable.Count / 14 + 1;*/
                // Total of print data
                int totalDetailRow = printTable.Count;
                // Total of row in sheet
                int totalRowInSheet = 64; // default 1 page

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
                    // = 64 rows in page 1 + number of rows from page 2 + number of padding rows for each page
                    totalRowInSheet = 64 + 62 * (pageNo - 1) + (pageNo - 1);
                }

                foreach (KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1Row row in printTable)
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
                            // Set GyoshaNm + Adr
                            // 20150131 sou Start
                            //CellOutput(outputSheet, printPoint + 1, 3, gyoshaNmAdr);
                            bikoOutput(outputSheet, printPoint + 1, 3, gyoshaNmAdr, saisuiInfo);
                            // 20150131 sou End

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
                            // Set GyoshaNm + Adr
                            // 20150131 sou Start
                            //CellOutput(outputSheet, printPoint + 1, 3, gyoshaNmAdr);
                            bikoOutput(outputSheet, printPoint + 1, 3, gyoshaNmAdr, saisuiInfo);
                            // 20150131 sou End

                            // Next print position
                            printPoint += 11;

                            // Copy detail rows from page 2 in template
                            //RowCopy(tempSheet, outputSheet, 66, 62, printPoint - 1, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, 65, 62, outputSheet, printPoint - 2);
                            // Page break
                            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[printPoint - 2, 1]);

                            // Next page
                            pageCount++;
                        }
                    }

                    // First detail row
                    if (pageCount == 0 && curRow == 0)
                    {
                        printPoint += 28;
                    }

                    // Detail from page 2
                    SetDetail(outputSheet, row, printPoint, pageNo, pageCount, totalDetailRow);

                    // Next detail row
                    printPoint += 2;
                    curRow++;
                }

                // More than 1 page
                // 20150131 sou Start 1ページ未満に収まるパターンを追加
                //if (pageNo > 1)
                if ((pageNo > 1) || ((pageNo == 1) && (curRow < 14)))
                // 20150131 sou End
                {
                    // Set GyoshaNm + Adr for last page
                    // 20150131 sou Start
                    //CellOutput(outputSheet, totalRowInSheet - 7, 3, gyoshaNmAdr);
                    bikoOutput(outputSheet, totalRowInSheet - 7, 3, gyoshaNmAdr, saisuiInfo);
                    // 20150131 sou End
                }
                else // There is only 1 page
                {
                    // Delete page 2
                    DeleteRow(outputSheet, 64, 63);
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
                //int pageNo = _printTbl.Count % 14 == 0 ? (int)_printTbl.Count / 14 : (int)_printTbl.Count / 14 + 1;
                //DataRow[] dataRow = _printTbl.Select("KeiryoShomeiGaibuItakuFlg = '1'", String.Empty);
                //if (dataRow.Length > 0)
                //{
                //    // 2014/12/13 AnhNV DEL Start
                //    //ISelectConstMstByKeyDAInput daConstMstInput = new SelectConstMstByKeyDAInput();
                //    //daConstMstInput.ConstKbn = Utility.Constants.ConstKbnConstanst.CONST_KBN_054;
                //    //daConstMstInput.ConstRenban = Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001;
                //    //ConstMstDataSet.ConstMstDataTable constMst = new SelectConstMstByKeyDataAccess().Execute(daConstMstInput).DataTable;
                //    // 2014/12/13 AnhNV DEL End

                //    // 2014/12/13 AnhNV ADD Start
                //    // Get ConstValue by ConstKbn 054 and ConstRenban 001
                //    string constValue = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_054, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                //    // 2014/12/13 AnhNV ADD End

                //    // 2014/12/13 AnhNV EDIT Start
                //    /*if (constMst.Count > 0)
                //    {*/
                //        ISelectGyoshaMstByKeyDAInput daGyoshaMstInput = new SelectGyoshaMstByKeyDAInput();
                //        //daGyoshaMstInput.GyoshaCd = constMst[0].ConstValue;
                //        daGyoshaMstInput.GyoshaCd = constValue;
                //        GyoshaMstDataSet.GyoshaMstDataTable gyoshaMst = new SelectGyoshaMstByKeyDataAccess().Execute(daGyoshaMstInput).GyoshaMstDataTable;
                //        if (gyoshaMst.Count > 0)
                //        {
                //            _gyoshaNmAdr = String.Concat("※１　", gyoshaMst[0].IsNull("GyoshaNm") ? String.Empty : gyoshaMst[0].GyoshaNm, "に計量を委託しています。（", gyoshaMst[0].IsNull("GyoshaAdr") ? String.Empty : gyoshaMst[0].GyoshaAdr, "）");
                //        }
                //    /*}*/
                //    // 2014/12/13 AnhNV EDIT End
                //}
                //if (_printTbl.Count > 0)
                //{
                //    // 2014/12/13 AnhNV ADD Start
                //    // Total row in sheet = Header rows num (25 rows) + total pages * detail row num (38 or 36 rows) + padding rows (1 padding row/1 page)
                //    totalRow = 25 + (38 * pageNo) + pageNo;
                //    //totalRow = 25 + (38 + (pageNo - 1) * 36) + pageNo;
                //    // 2014/12/13 AnhNV ADD End

                //    // Print header
                //    SetHeader(outputSheet, _printTbl[0], curRow, pageNo, pageCount + 1, input.IsPlusCnt);
                //    foreach (KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1Row row in _printTbl)
                //    {
                //        if (pageCount == 0) // first page
                //        {
                //            if (curRow > 0 && curRow % 14 == 0 && _printTbl.Count > 14) // next page
                //            {
                //                // (23)
                //                CellOutput(outputSheet, printPoint + 1, 3, _gyoshaNmAdr);
                //                //// 2014/12/13 AnhNV DEL Start
                //                //printPoint += 10;
                //                //// Break page
                //                //outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[printPoint - 2, 1]);
                //                //// copy row                            
                //                //RowCopy(tempSheet, outputSheet, 26, 64, printPoint - 2, XlPasteType.xlPasteAll);
                //                //pageCount++;
                //                // 2014/12/13 AnhNV DEL End

                //                // 2014/12/13 AnhNV ADD Start
                //                printPoint += 10;
                //                // copy row                            
                //                //RowCopy(tempSheet, outputSheet, 26, 64, printPoint, XlPasteType.xlPasteAll);
                //                RowCopy(tempSheet, outputSheet, 66, 54, printPoint, XlPasteType.xlPasteAll);
                //                pageCount++;
                //                // Delete 1 unused row from template
                //                //DeleteRow(outputSheet, printPoint - 2, 1);
                //                // Break page
                //                outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[printPoint - 1, 1]);

                //                // Next detail print position
                //                printPoint += 1;
                //                curRow = 0;
                //                // 2014/12/13 AnhNV ADD End
                //            }
                //        }
                //        else // from page 2
                //        {
                //            if (curRow % 26 == 0 && _printTbl.Count > 14) // next page
                //            {
                //                // (23)
                //                CellOutput(outputSheet, printPoint + 1, 3, _gyoshaNmAdr);
                //                printPoint += 10;
                //                // copy row                            
                //                RowCopy(tempSheet, outputSheet, 66, 54, printPoint, XlPasteType.xlPasteAll);
                //                pageCount++;
                //                // Delete 1 unused row from template
                //                //DeleteRow(outputSheet, printPoint - 2, 1);
                //                // Break page
                //                outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[printPoint - 1, 1]);

                //                // Next detail print position
                //                printPoint += 1;
                //            }
                //        }

                //        if (curRow == 0)
                //        {
                //            printPoint += 28;
                //        }
                //        // Print details
                //        SetDetail(outputSheet, row, printPoint, pageNo, pageCount);

                //        curRow++;
                //        printPoint += 2;
                //    }
                //    if (pageCount == 0)
                //    {
                //        // (23)
                //        CellOutput(outputSheet, 57, 3, _gyoshaNmAdr);
                //    }
                //    // 《   以   下   余   白   》
                //    if (_printTbl.Count % 14 != 0)
                //    {
                //        Microsoft.Office.Interop.Excel.Range rangeFrom = rangeFrom = outputSheet.get_Range(outputSheet.Cells[printPoint + 1, 15], outputSheet.Cells[printPoint + 1, 34]);
                //        rangeFrom.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //        CellOutput(outputSheet, printPoint, 14, "《   以   下   余   白   》");
                //    }

                //    // 2014/12/13 AnhNV EDIT Start
                //    //CellOutput(outputSheet, 63 + (38 * pageCount) - 6, 3, _gyoshaNmAdr);
                //    if (pageNo > 1)
                //    {
                //        // GyoshaNm + Adr for the last page
                //        CellOutput(outputSheet, totalRow - 7, 3, _gyoshaNmAdr);
                //    }
                //    // 2014/12/13 AnhNV EDIT End
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
                KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable printTable,
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
                CellOutput(sheet, curRow + 3, 40, printTable[0].IsNull("ShishoNm") ? String.Empty : String.Concat(printTable[0].ShishoNm, "-",cnt));
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
            CellOutput(sheet, curRow + 10, 35, printTable[0].IsNull("ShishoNmTorokuNo") ? String.Empty : printTable[0].ShishoNmTorokuNo);
            // (6)
            CellOutput(sheet, curRow + 11, 35, printTable[0].IsNull("ShishoAdr") ? String.Empty : printTable[0].ShishoAdr);
            // (7)
            CellOutput(sheet, curRow + 12, 37, printTable[0].IsNull("ShishoTelNo") ? String.Empty : printTable[0].ShishoTelNo);
            // (8)
            CellOutput(sheet, curRow + 14, 37, printTable[0].IsNull("ShishoKeiryoKanrisha") ? String.Empty : printTable[0].ShishoKeiryoKanrisha);
            // (9)
            CellOutput(sheet, curRow + 15, 33, printTable[0].IsNull("ShishoKankyoKeiryoshiNo") ? String.Empty : printTable[0].ShishoKankyoKeiryoshiNo);
            // (10)
            CellOutput(sheet, curRow + 17, 8, printTable[0].IsNull("JokasoSetchiBashoAdr") ? String.Empty : printTable[0].JokasoSetchiBashoAdr);
            // (11)
            CellOutput(sheet, curRow + 19, 8, printTable[0].IsNull("ShoriHoshikiShubetsuNm") ? String.Empty : printTable[0].ShoriHoshikiShubetsuNm);
            // (12)
            CellOutput(sheet, curRow + 21, 8, uketsukeDt);
            // (13)
            CellOutput(sheet, curRow + 23, 8, printTable[0].IsHokenjoNmNull() ? String.Empty : printTable[0].HokenjoNm);
            // (14)
            CellOutput(sheet, curRow + 19, 34, printTable[0].IsKeiryoShomeiNinsouNull() ? String.Empty : printTable[0].KeiryoShomeiNinsou);
            // (15)
            CellOutput(sheet, curRow + 19, 40, printTable[0].IsKeiryoShomeiHiHeikinOsuiRyoNull() ? String.Empty : printTable[0].KeiryoShomeiHiHeikinOsuiRyo);
            // (16)
            CellOutput(sheet, curRow + 21, 34, printTable[0].IsSuishitsuNmNull() ? String.Empty : String.Concat("'", printTable[0].SuishitsuNm));
            // (17)
            CellOutput(sheet, curRow + 23, 34, printTable[0].IsGyoshaNmNull() ? String.Empty : printTable[0].GyoshaNm);
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
                KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1Row row,
                int curRow,
                int pageNo,
                int pageCount,
                int totalPrintRow
            )
        {
            if (pageNo > 0 && /*printTable.Count*/totalPrintRow > 14 && pageCount > 0)
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
            CellOutput(sheet, curRow, 35, row.IsKeiryouKekkaNull() ? String.Empty : row.KeiryouKekka);
            // (22)
            CellOutput(sheet, curRow, 43, row.IsTeiryouNull() ? String.Empty : row.Teiryou);
        }
        #endregion

        #region GetGyoshaNmAdr
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetGyoshaNmAdr
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="printTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetGyoshaNmAdr(KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable printTable)
        {
            DataRow[] dataRow = printTable.Select("KeiryoShomeiGaibuItakuFlg = '1'", string.Empty);
            string gyoshaNmAdr = string.Empty;
            if (dataRow.Length > 0)
            {
                // Get ConstValue by ConstKbn 054 and ConstRenban 001
                string constValue = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_054, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                ISelectGyoshaMstByKeyDAInput daGyoshaMstInput = new SelectGyoshaMstByKeyDAInput();
                daGyoshaMstInput.GyoshaCd = constValue;
                GyoshaMstDataSet.GyoshaMstDataTable gyoshaMst = new SelectGyoshaMstByKeyDataAccess().Execute(daGyoshaMstInput).GyoshaMstDataTable;
                if (gyoshaMst.Count > 0)
                {
                    gyoshaNmAdr = String.Concat("※１　", gyoshaMst[0].IsNull("GyoshaNm") ? String.Empty : gyoshaMst[0].GyoshaNm, "に計量を委託しています。（", gyoshaMst[0].IsNull("GyoshaAdr") ? String.Empty : gyoshaMst[0].GyoshaAdr, "）");
                }
            }

            return gyoshaNmAdr;
        }
        #endregion

        #region GetSaisuiInfo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSaisuiInfo
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="iraiTbl"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetSaisuiInfo(KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable iraiTbl)
        {
            string saisuiInfo = string.Empty;
            if (iraiTbl.Count > 0)
            {
                string saisuiDT = string.Empty;
                string saisuiDate = string.Empty;
                string saisuiTime = string.Empty;
                string suion = string.Empty;
                string kion = string.Empty;

                // 採水日時(空白の時は表示しない)
                if (!iraiTbl[0].IsKeiryoShomeiSaisuiDtNull())
                {
                    if (iraiTbl[0].KeiryoShomeiSaisuiDt.Trim().Length == 8)
                    {
                        saisuiDate = iraiTbl[0].KeiryoShomeiSaisuiDt.Substring(0, 4) + "/"
                                   + iraiTbl[0].KeiryoShomeiSaisuiDt.Substring(4, 2) + "/"
                                   + iraiTbl[0].KeiryoShomeiSaisuiDt.Substring(6, 2);
                    }
                    else
                    {
                        saisuiDate = iraiTbl[0].KeiryoShomeiSaisuiDt.Trim();
                    }
                }
                if (!iraiTbl[0].IsKeiryoShomeiSaisuiTimeNull())
                {
                    if (iraiTbl[0].KeiryoShomeiSaisuiTime.Trim().Length == 4)
                    {
                        saisuiTime = iraiTbl[0].KeiryoShomeiSaisuiTime.Substring(0, 2) + ":"
                                   + iraiTbl[0].KeiryoShomeiSaisuiTime.Substring(2, 2);
                    }
                    else
                    {
                        saisuiTime = iraiTbl[0].KeiryoShomeiSaisuiTime.Trim();
                    }
                }
                if (!string.IsNullOrEmpty(saisuiDate) && !string.IsNullOrEmpty(saisuiTime))
                {
                    saisuiDT = "採水日時 " + saisuiDate + " " + saisuiTime + "  ";
                }

                // 水温
                if (!iraiTbl[0].IsKeiryoShomeiSuionNull())
                {
                    suion = iraiTbl[0].KeiryoShomeiSuion.ToString();
                }

                // 気温
                if (!iraiTbl[0].IsKeiryoShomeiKionNull())
                {
                    kion = iraiTbl[0].KeiryoShomeiKion.ToString();
                }
                
                // 採水情報
                saisuiInfo = saisuiDT + "水温 " + suion + "℃  気温 " + kion + "℃";
            }

            return saisuiInfo;
        }
        #endregion

        #region bikoOutput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： bikoOutput
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet">シートオブジェクト</param>
        /// <param name="row">行番号</param>
        /// <param name="col">列番号</param>
        /// <param name="gyoshaNmAdr">外注先情報</param>
        /// <param name="saisuiInfo">採水情報</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void bikoOutput(Worksheet outputSheet, int row, int col, string gyoshaNmAdr, string saisuiInfo)
        {
            if (string.IsNullOrEmpty(gyoshaNmAdr))
            {
                CellOutput(outputSheet, row, col, saisuiInfo);
            }
            else
            {
                CellOutput(outputSheet, row, col, gyoshaNmAdr);
                CellOutput(outputSheet, row + 1, col, saisuiInfo);
            }

            return;
        }
        #endregion

        #endregion
    }
    #endregion
}
