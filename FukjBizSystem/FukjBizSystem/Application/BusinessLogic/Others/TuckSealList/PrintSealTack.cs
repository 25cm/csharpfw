using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.TuckSealList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSealTackBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSealTackBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 印刷開始位置
        /// </summary>
        int PrintPosition { get; set; }

        /// <summary>
        /// 部数
        /// </summary>
        int CopyNumber { get; set; }

        /// <summary>
        /// TuckSealListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.TuckSealListDataTable TuckSealListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSealTackBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSealTackBLInput : BaseExcelPrintBLInputImpl, IPrintSealTackBLInput
    {
        ///// <summary>
        ///// 保存ファイルモード
        ///// </summary>
        //public int SaveFileMode
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// ＥＸＣＥＬ書式へのパス
        ///// </summary>
        //public string FormatPath
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 帳票ディレクトリパス
        ///// </summary>
        //public string PrintDirectory
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 指定保存パス
        ///// 未指定の場合は、帳票出力ディレクトリに出力されます
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 処理後ＥＸＣＥＬ表示フラグ
        ///// </summary>
        //public bool AfterDispFlg
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 処理後印刷フラグ
        ///// </summary>
        //public bool AfterPrintFlg { get; set; }

        ///// <summary>
        ///// 印刷プリンタ名
        ///// </summary>
        //public string PrinterName { get; set; }

        /// <summary>
        /// 印刷開始位置
        /// </summary>
        public int PrintPosition { get; set; }

        /// <summary>
        /// 部数
        /// </summary>
        public int CopyNumber { get; set; }

        /// <summary>
        /// TuckSealListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.TuckSealListDataTable TuckSealListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSealTackBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSealTackBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSealTackBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSealTackBLOutput : BaseExcelPrintBLOutputImpl, IPrintSealTackBLOutput
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
    //  クラス名 ： PrintSealTackBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSealTackBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSealTackBLInput, IPrintSealTackBLOutput>
    {
        #region 置換文字列

        /// <summary>
        /// Number of rows per block
        /// </summary>
        private const int ROW_PER_BLOCK = 9;

        /// <summary>
        /// Number of rows per page
        /// </summary>
        private const int ROW_PER_PAGE = 56;

        /// <summary>
        /// 印刷開始位置
        /// </summary>
        private const int PRINT_POSITION_ROW_1 = 1;
        private const int PRINT_POSITION_ROW_2 = 10;
        private const int PRINT_POSITION_ROW_3 = 19;
        private const int PRINT_POSITION_ROW_4 = 28;
        private const int PRINT_POSITION_ROW_5 = 37;
        private const int PRINT_POSITION_ROW_6 = 46;

        // Column index of 〒
        private const int PRINT_POSITION_COL_1 = 2;
        private const int PRINT_POSITION_COL_2 = 21;

        // Column index of 様
        private const int SAMA_POSITION_COL_1 = 17;
        private const int SAMA_POSITION_COL_2 = 36;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSealTackBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSealTackBusinessLogic()
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
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSealTackBLOutput SetBook(IPrintSealTackBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSealTackBLOutput output = new PrintSealTackBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Template sheet
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                tempSheet.Copy(tempSheet, Type.Missing);

                // Set output sheet to current active sheet
                outputSheet = (Worksheet)book.ActiveSheet;
                outputSheet.Name = "タックシール";

                // Number of page
                int pageIdx = 1;
                // Current row in process
                int curRow = 0;
                // Current column in process: 2 or 21
                int curCol = input.PrintPosition % 2 == 0 ? PRINT_POSITION_COL_2 : PRINT_POSITION_COL_1;

                #region Index of each block

                // Print from?
                switch (input.PrintPosition)
                {
                    case 1:
                    case 2:
                        curRow = PRINT_POSITION_ROW_1;
                        break;
                    case 3:
                    case 4:
                        curRow = PRINT_POSITION_ROW_2;
                        break;
                    case 5:
                    case 6:
                        curRow = PRINT_POSITION_ROW_3;
                        break;
                    case 7:
                    case 8:
                        curRow = PRINT_POSITION_ROW_4;
                        break;
                    case 9:
                    case 10:
                        curRow = PRINT_POSITION_ROW_5;
                        break;
                    case 11:
                    case 12:
                        curRow = PRINT_POSITION_ROW_6;
                        break;
                    default:
                        break;
                }

                #endregion

                // Number of copies
                for (int idx = 1; idx <= input.CopyNumber; idx++)
                {
                    foreach (JokasoDaichoMstDataSet.TuckSealListRow row in input.TuckSealListDataTable)
                    {
                        // New page?
                        if (curRow >= (ROW_PER_PAGE - pageIdx) * pageIdx)
                        {
                            // 20141221 habu Add added page break
                            // Page breaks
                            SetPageBreak(outputSheet, curRow);
                            //outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow, 1]);

                            // Copy a new page
                            //RowCopy(tempSheet, outputSheet, 2, ROW_PER_PAGE, curRow + 1, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, 1, ROW_PER_PAGE, outputSheet, curRow);

                            // Reset to first block in page
                            curCol = PRINT_POSITION_COL_1;

                            // Next page
                            pageIdx++;

                            // Row height
                            outputSheet.Range[string.Format("A{0}", curRow + 2), string.Format("A{0}", curRow + 2)].RowHeight = 6;
                            outputSheet.Range[string.Format("A{0}", curRow + 11), string.Format("A{0}", curRow + 11)].RowHeight = 6;
                            outputSheet.Range[string.Format("A{0}", curRow + 20), string.Format("A{0}", curRow + 20)].RowHeight = 6;
                            outputSheet.Range[string.Format("A{0}", curRow + 29), string.Format("A{0}", curRow + 29)].RowHeight = 6;
                            outputSheet.Range[string.Format("A{0}", curRow + 38), string.Format("A{0}", curRow + 38)].RowHeight = 6;
                            outputSheet.Range[string.Format("A{0}", curRow + 47), string.Format("A{0}", curRow + 47)].RowHeight = 6;
                        }

                        // Detail for each page
                        SetDetail(outputSheet, row, curRow, curCol);

                        // Next block
                        if (curCol == PRINT_POSITION_COL_2)
                        {
                            curRow += ROW_PER_BLOCK;
                        }

                        // Switch column index
                        curCol = curCol == PRINT_POSITION_COL_1 ? PRINT_POSITION_COL_2 : PRINT_POSITION_COL_1;
                    }
                }

                // Print area
                outputSheet.PageSetup.PrintArea = string.Format("A$1:AM${0}", curRow + 9);
                
                // 2シート以上あるか？
                if (book.Sheets.Count > 1)
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

        #region SetPrintPosition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetPrintPosition
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="printPosition"></param>
        /// <param name="curRow"></param>
        /// <param name="curCol"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetPrintPosition(int printPosition, int curRow, int curCol)
        {
            
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
        /// <param name="curCol"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Worksheet sheet, JokasoDaichoMstDataSet.TuckSealListRow row, int curRow, int curCol)
        {
            // 〒
            CellOutput(sheet, curRow, curCol, "〒");

            // 郵便番号
            CellOutput(sheet, curRow, curCol + 1, row.ZipNoCol);

            // 住所
            CellOutput(sheet, curRow + 2, curCol, row.AdrCol);

            // 業者名/保健所名/設置者名
            CellOutput(sheet, curRow + 4, curCol, row.NmCol);

            // 様
            CellOutput(sheet, curRow + 5, curCol + 15, "様");
        }
        #endregion

        #endregion
    }
    #endregion
}
