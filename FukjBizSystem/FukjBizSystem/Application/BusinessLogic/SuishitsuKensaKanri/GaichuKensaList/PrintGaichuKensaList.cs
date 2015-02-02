using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.GyoshaMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.GaichuKensaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintGaichuKensaListBLInput
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
    interface IPrintGaichuKensaListBLInput : IBaseExcelPrintBLInput
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
        /// 依頼日
        /// </summary>
        DateTime IraiDt { get; set; }

        /// <summary>
        /// 依頼日
        /// </summary>
        string ShishoNm { get; set; }

        /// <summary>
        /// GaichuKensaListDataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable GaichuKensaListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintGaichuKensaListBLInput
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
    class PrintGaichuKensaListBLInput : BaseExcelPrintBLInputImpl, IPrintGaichuKensaListBLInput
    {
        /// <summary>
        /// 依頼日
        /// </summary>
        public DateTime IraiDt { get; set; }

        /// <summary>
        /// 依頼日
        /// </summary>
        public string ShishoNm { get; set; }

        /// <summary>
        /// GaichuKensaListDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable GaichuKensaListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintGaichuKensaListBLOutput
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
    interface IPrintGaichuKensaListBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintGaichuKensaListBLOutput
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
    class PrintGaichuKensaListBLOutput : BaseExcelPrintBLOutputImpl, IPrintGaichuKensaListBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintGaichuKensaListBusinessLogic
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
    class PrintGaichuKensaListBusinessLogic : BaseExcelPrintBusinessLogic<IPrintGaichuKensaListBLInput, IPrintGaichuKensaListBLOutput>
    {
        #region 置換文字列

        /// <summary>
        /// Number of rows per page
        /// </summary>
        private const int ROW_IN_PAGE = 50;

        #region private

        private string _strGyoshaNm = String.Empty;

        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintGaichuKensaListBusinessLogic
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
        public PrintGaichuKensaListBusinessLogic()
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintGaichuKensaListBLOutput SetBook(IPrintGaichuKensaListBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintGaichuKensaListBLOutput output = new PrintGaichuKensaListBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;
                //Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.
                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Output sheet                
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                tempSheet.Copy(tempSheet, Type.Missing);
                outputSheet = (Worksheet)book.ActiveSheet;
                outputSheet.Name = "Sheet1 ";
                // Index of detail row
                int curRow = 0;
                int pageCount = 0;
                string strDoubleQuote = @"""○""";
                int pageNo = (int)input.GaichuKensaListDataTable.Count / 40;
                string strWareki = Utility.DateUtility.ConvertToWareki(input.IraiDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
                string strGyoshaCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_054, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                ISelectGyoshaMstByKeyDAInput daInput = new SelectGyoshaMstByKeyDAInput();
                daInput.GyoshaCd = strGyoshaCd;

                GyoshaMstDataSet.GyoshaMstDataTable dataTbl = new SelectGyoshaMstByKeyDataAccess().Execute(daInput).GyoshaMstDataTable;
                _strGyoshaNm = dataTbl.Count > 0 ? dataTbl[0].GyoshaNm : String.Empty;
                // (1)
                CellOutput(outputSheet, 3, 0, _strGyoshaNm);
                // (2)
                CellOutput(outputSheet, 0, 11, String.Concat("NO.", pageCount + 1));
                // (3)
                CellOutput(outputSheet, 2, 9, strWareki);
                // (4)
                CellOutput(outputSheet, 5, 0, input.ShishoNm + "検査センター");
                foreach (KeiryoShomeiIraiTblDataSet.GaichuKensaListRow row in input.GaichuKensaListDataTable)
                {
                    // No checkbox was checked
                    if (!(
                        row.daichokinCol.Equals("0") &&
                        row.codCol.Equals("0") &&
                        row.tnCol.Equals("0") &&
                        row.tpCol.Equals("0") &&
                        row.yubunCol.Equals("0") &&
                        row.yubunKouCol.Equals("0") &&
                        row.yubunDouCol.Equals("0") &&
                        row.mbasCol.Equals("0") &&
                        row.znCol.Equals("0") &&
                        row.pbCol.Equals("0") &&
                        row.fCol.Equals("0")
                        ))
                    {
                        // Next page
                        if (pageCount == 0)
                        {
                            if (curRow > 0 && curRow % 48 == 0)
                            {                                
                                SetTotalCellOutput(outputSheet, curRow, strDoubleQuote);
                                pageCount++;
                                // Break page
                                outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow + 3, 1]);
                                // copy row
                                //RowCopy(tempSheet, outputSheet, 1, ROW_IN_PAGE, curRow + 3, XlPasteType.xlPasteAll);
                                CopyRow(tempSheet, 0, ROW_IN_PAGE, outputSheet, curRow + 2);

                                SetHeader(outputSheet, row, curRow + 2, pageCount, strWareki, input.ShishoNm);
                                curRow += 10;
                            }
                        }
                        else
                        {
                            if (curRow > 0 && curRow - 50 * pageCount == 48)
                            {                                
                                SetTotalCellOutput(outputSheet, curRow, strDoubleQuote);
                                pageCount++;
                                // Break page
                                outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow + 3, 1]);
                                // copy row
                                //RowCopy(tempSheet, outputSheet, 1, ROW_IN_PAGE, curRow + 3, XlPasteType.xlPasteAll);
                                CopyRow(tempSheet, 0, ROW_IN_PAGE, outputSheet, curRow + 2);

                                SetHeader(outputSheet, row, curRow + 2, pageCount, strWareki, input.ShishoNm);
                                curRow += 10;

                            }
                        }

                        if (curRow == 0)
                        {
                            curRow += 8;
                        }
                        if (pageNo == 0)
                        {
                            CellOutput(outputSheet, 48, 0, "合計");
                        }
                        SetDetail(outputSheet, row, curRow, pageNo);

                        curRow++;
                    }
                }
                if (pageCount > 0)
                {
                    SetLastTotalOutputCell(outputSheet, pageCount, curRow, strDoubleQuote);

                    // 2014/12/18 AnhNV ADD Start
                    int totalPage = input.GaichuKensaListDataTable.Count % 40 == 0
                        ? (int)input.GaichuKensaListDataTable.Count / 40 : (int)input.GaichuKensaListDataTable.Count / 40 + 1;
                    int totalRow = 8 * totalPage + totalPage * 41 + totalPage; // header rows + detail rows + padding rows per page
                    // Set print area
                    outputSheet.PageSetup.PrintArea = string.Format("A1:L{0}", totalRow);
                    // 2014/12/18 AnhNV ADD End
                }

                tempSheet.Delete();
            }
            catch
            {
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

        #region SetLastTotalOutputCell
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetLastTotalOutputCell
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="pageCount"></param>
        /// <param name="curRow"></param>
        /// <param name="strDoubleQuote"></param>        
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成        
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetLastTotalOutputCell
            (
                Worksheet sheet, 
                int pageCount,
                int curRow,
                string strDoubleQuote
            )
        {
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 0, "合計");
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 1, String.Format("=COUNTIF(B{0}:B{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 2, String.Format("=COUNTIF(C{0}:C{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 3, String.Format("=COUNTIF(D{0}:D{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 4, String.Format("=COUNTIF(E{0}:E{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 5, String.Format("=COUNTIF(F{0}:F{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 6, String.Format("=COUNTIF(G{0}:G{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 7, String.Format("=COUNTIF(H{0}:H{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 8, String.Format("=COUNTIF(I{0}:I{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 9, String.Format("=COUNTIF(J{0}:J{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 10, String.Format("=COUNTIF(K{0}:K{1},{2})", 9, curRow, strDoubleQuote));
            CellOutput(sheet, (49 * (pageCount + 1)) + pageCount - 1, 11, String.Format("=COUNTIF(L{0}:L{1},{2})", 9, curRow, strDoubleQuote));
            sheet.HPageBreaks.Add((Range)sheet.Cells[(49 * (pageCount + 1)) + pageCount + 2, 1]);
        }
        #endregion

        #region SetTotalCellOutput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetTotalCellOutput
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="curRow"></param>
        /// <param name="strDoubleQuote"></param>        
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成        
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetTotalCellOutput
            (
                Worksheet sheet, 
                int curRow, 
                string strDoubleQuote
            )
        {
            CellOutput(sheet, curRow, 0, "小計");
            CellOutput(sheet, curRow, 1, String.Format("=COUNTIF(B{0}:B{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 2, String.Format("=COUNTIF(C{0}:C{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 3, String.Format("=COUNTIF(D{0}:D{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 4, String.Format("=COUNTIF(E{0}:E{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 5, String.Format("=COUNTIF(F{0}:F{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 6, String.Format("=COUNTIF(G{0}:G{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 7, String.Format("=COUNTIF(H{0}:H{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 8, String.Format("=COUNTIF(I{0}:I{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 9, String.Format("=COUNTIF(J{0}:J{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 10, String.Format("=COUNTIF(K{0}:K{1},{2})", curRow - 40, curRow, strDoubleQuote));
            CellOutput(sheet, curRow, 11, String.Format("=COUNTIF(L{0}:L{1},{2})", curRow - 40, curRow, strDoubleQuote));        
        }
        #endregion

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
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <param name="strWareki"></param>
        /// <param name="shishoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成        
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader
            (
                Worksheet sheet,
                KeiryoShomeiIraiTblDataSet.GaichuKensaListRow row,
                int curRow,
                int pageNo,
                string strWareki,
                string shishoNm
            )
        {
            // (1)
            CellOutput(sheet, curRow + 3, 0, _strGyoshaNm);
            // (2)
            CellOutput(sheet, curRow, 11, String.Concat("NO.", pageNo + 1));
            // (3)
            CellOutput(sheet, curRow + 2, 9, strWareki);
            // (4)
            CellOutput(sheet, curRow + 5, 0, shishoNm + "検査センター");
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
        /// <param name="daihyoshaNm"></param>
        /// <param name="hakkoDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成        
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail
            (
                Worksheet sheet,
                KeiryoShomeiIraiTblDataSet.GaichuKensaListRow row,
                int curRow,
                int pageNo
            )
        {
            // (5)
            CellOutput(sheet, curRow, 0, String.Concat("'", row.KeiryoShomeiIraiRenban));
            // (6)
            CellOutput(sheet, curRow, 1, row.daichokinCol.Equals("1") ? "○" : String.Empty);
            // (7)
            CellOutput(sheet, curRow, 2, row.codCol.Equals("1") ? "○" : String.Empty);
            // (8)
            CellOutput(sheet, curRow, 3, row.tnCol.Equals("1") ? "○" : String.Empty);
            // (9)
            CellOutput(sheet, curRow, 4, row.tpCol.Equals("1") ? "○" : String.Empty);
            // (10)
            CellOutput(sheet, curRow, 5, row.yubunCol.Equals("1") ? "○" : String.Empty);
            // (11)
            CellOutput(sheet, curRow, 6, row.yubunKouCol.Equals("1") ? "○" : String.Empty);
            // (12)
            CellOutput(sheet, curRow, 7, row.yubunDouCol.Equals("1") ? "○" : String.Empty);
            // (13)
            CellOutput(sheet, curRow, 8, row.mbasCol.Equals("1") ? "○" : String.Empty);
            // (14)
            CellOutput(sheet, curRow, 9, row.znCol.Equals("1") ? "○" : String.Empty);
            // (15)
            CellOutput(sheet, curRow, 10, row.pbCol.Equals("1") ? "○" : String.Empty);
            // (16)
            CellOutput(sheet, curRow, 11, row.fCol.Equals("1") ? "○" : String.Empty);
        }
        #endregion

        #endregion
    }
    #endregion
}
