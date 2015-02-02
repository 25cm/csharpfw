using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Zynas.Framework.Core.Common.BusinessLogic.Print.MSExcel
{
    /// <summary>
    /// Excelを直接操作(セル出力、行コピー、挿入、削除など)するメソッド郡
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18　habu　　    新規作成
    /// </history>
    public class MSExcelUtility
    {
        // NOTICE IDX_ORIGINをパラメータにより、可変とする(0がデフォルトだが、1も考慮) -> 今回は固定構成とする
        /// <summary>
        /// 
        /// </summary>
        public static int IDX_ORIGIN
        {
            get { return 0; }
        }

        public static int IDX_OFFSET
        {
            get { return 1; }
        }

        // NOTICE 必要なメソッド類を適宜実装する（行追加、削除、コピー、ブロックコピー等） => 必要なものを随時追加する

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="obj"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15　habu　　    新規作成
        /// </history>
        public static void CellOutput(Microsoft.Office.Interop.Excel.Worksheet sheet, int row, int col, object obj)
        {
            // Ｅｘｃｅｌのレンジオブジェクトを定義
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                // Ｅｘｃｅｌのレンジオブジェクトを設定
                range = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[row + IDX_OFFSET, col + IDX_OFFSET];

                // Ｅｘｃｅｌのレンジオブジェクトにオブジェクトを設定
                range.Value2 = obj;
            }
            finally
            {
                // Ｅｘｃｅｌのレンジオブジェクトを解放
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }

        // NOTICE 必要なメソッドを適宜実装する => 必要なものを、随時追加する
        public static void RowCopy(Workbook book, int sheetFromIdx, int rowFrom, int sheetToIdx, int rowTo, int rowCnt)
        {
            Worksheet sheetFrom = null;
            Worksheet sheetTo = null;
            Sheets sheets = null;

            try
            {
                sheets = book.Sheets;

                sheetFrom = (Worksheet)sheets[sheetFromIdx + IDX_OFFSET];
                sheetTo = (Worksheet)sheets[sheetToIdx + IDX_OFFSET];
            }
            finally
            {
                if (sheetFrom != null)
                {
                    Marshal.ReleaseComObject(sheetFrom);
                }
                if (sheetTo != null)
                {
                    Marshal.ReleaseComObject(sheetTo);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetFrom"></param>
        /// <param name="rowFrom"></param>
        /// <param name="sheetTo"></param>
        /// <param name="rowTo"></param>
        /// <param name="rowCnt"></param>
        public static void RowCopy(Worksheet sheetFrom, int rowFrom, Worksheet sheetTo, int rowTo, int rowCnt)
        {
            Range fromRowBegin = null;
            Range fromRowEnd = null;
            Range fromRowRange = null;
            Range toRow = null;

            try
            {
                fromRowBegin = (Range)sheetFrom.Rows[rowFrom + IDX_OFFSET];
                fromRowEnd = (Range)sheetFrom.Rows[rowFrom + rowCnt - 1 + IDX_OFFSET];
                fromRowRange = sheetFrom.get_Range(fromRowBegin, fromRowEnd);
                toRow = (Range)sheetTo.Rows[rowTo + IDX_OFFSET];

                fromRowRange.Copy(toRow);
            }
            finally
            {
                if (fromRowBegin != null)
                {
                    Marshal.ReleaseComObject(fromRowBegin);
                }
                if (fromRowEnd != null)
                {
                    Marshal.ReleaseComObject(fromRowEnd);
                }
                if (fromRowRange != null)
                {
                    Marshal.ReleaseComObject(fromRowRange);
                }
                if (toRow != null)
                {
                    Marshal.ReleaseComObject(toRow);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetFrom"></param>
        /// <param name="rowFrom"></param>
        /// <param name="sheetTo"></param>
        /// <param name="rowTo"></param>
        /// <param name="rowCnt"></param>
        public static void RowInsert(Worksheet sheetFrom, int rowFrom, Worksheet sheetTo, int rowTo, int rowCnt)
        {
            Range toRowRange = null;
            Range toRowBegin = null;
            Range toRowEnd = null;

            try
            {
                toRowBegin = (Range)sheetTo.Rows[rowTo + IDX_OFFSET];
                toRowEnd = (Range)sheetTo.Rows[rowTo + rowCnt - 1 + IDX_OFFSET];
                toRowRange = sheetTo.Range[toRowBegin, toRowEnd];

                toRowRange.Insert(XlInsertShiftDirection.xlShiftDown);
            }
            finally
            {
                if (toRowBegin != null)
                {
                    Marshal.ReleaseComObject(toRowBegin);
                }
                if (toRowEnd != null)
                {
                    Marshal.ReleaseComObject(toRowEnd);
                }
                if (toRowRange != null)
                {
                    Marshal.ReleaseComObject(toRowRange);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="templateSheet"></param>
        public static Worksheet SheetCopy(Workbook book, Worksheet templateSheet)
        {
            Sheets sheets = null;
            Worksheet afterSheet = null;

            try
            {
                sheets = book.Sheets;
                afterSheet = (Worksheet)sheets[sheets.Count - 1 + IDX_OFFSET];

                templateSheet.Copy(After: afterSheet);

                return (Worksheet)sheets[sheets.Count - 1 + IDX_OFFSET];
            }
            finally
            {
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
                if (afterSheet != null)
                {
                    Marshal.ReleaseComObject(afterSheet);
                }
            }
        }

        public static void SheetCopy(Workbook book, int fromSheetIdx)
        {
            Worksheet sheet = null;
            Sheets sheets = null;

            try
            {
                sheets = book.Sheets;

                sheet = (Worksheet)sheets[fromSheetIdx + MSExcelUtility.IDX_OFFSET];

                MSExcelUtility.SheetCopy(book, sheet);
            }
            finally
            {
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
            }
        }

        public static int GetSheetCount(Workbook book)
        {
            Sheets sheets = null;

            try
            {
                sheets = book.Sheets;

                return sheets.Count;
            }
            finally
            {
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="sheetIdx">Excelシートインデックス。0始まり。</param>
        public static void SheetDelete(Workbook book, int sheetIdx)
        {
            Sheets sheets = null;
            Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Application app = null;

            try
            {
                app = book.Application;
                bool preDispAlters = app.DisplayAlerts;
                try
                {
                    app.DisplayAlerts = false;

                    sheets = book.Sheets;

                    sheet = (Worksheet)sheets[sheetIdx + IDX_OFFSET];

                    sheet.Delete();
                }
                finally
                {
                    app.DisplayAlerts = preDispAlters;
                }
            }
            finally
            {
                if (app != null)
                {
                    Marshal.ReleaseComObject(app);
                }
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row">Excel行番号。0始まり。</param>
        public static void SetPageBreak(Worksheet sheet, int row)
        {
            Range rowRange = null;

            try
            {
                rowRange = (Range)sheet.Rows[row + 1 + IDX_OFFSET];
                rowRange.PageBreak = (int)XlPageBreak.xlPageBreakManual;
            }
            finally
            {
                if (rowRange != null)
                {
                    Marshal.ReleaseComObject(rowRange);
                    rowRange = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="topRow"></param>
        /// <param name="leftCol"></param>
        /// <param name="bottomRow"></param>
        /// <param name="rightCol"></param>
        public static void SetPrintArea(Worksheet sheet, int topRow, int leftCol, int bottomRow, int rightCol)
        {
            PageSetup ps = null;
            Range leftTop = null;
            Range rightBottom = null;
            Range printRange = null;

            try
            {
                ps = sheet.PageSetup;

                leftTop = (Range)sheet.Cells[topRow + IDX_OFFSET, leftCol + IDX_OFFSET];
                rightBottom = (Range)sheet.Cells[bottomRow + IDX_OFFSET, rightCol + IDX_OFFSET];
                printRange = sheet.Range[leftTop, rightBottom];

                ps.PrintArea = printRange.get_Address();
            }
            finally
            {
                if (ps != null)
                {
                    Marshal.ReleaseComObject(ps);
                }
                if (leftTop != null)
                {
                    Marshal.ReleaseComObject(leftTop);
                }
                if (rightBottom != null)
                {
                    Marshal.ReleaseComObject(rightBottom);
                }
                if (printRange != null)
                {
                    Marshal.ReleaseComObject(printRange);
                }
            }
        }

        public static void SetSheetName(Worksheet sheet, string sheetName)
        {
            sheet.Name = EscapeExcelSheetName(sheetName);
        }

        public static int GetSheetIndex(Workbook book, string sheetName)
        {
            Worksheet sheet = null;
            try
            {
                sheet = (Worksheet)book.Sheets[sheetName];

                return sheet.Index - MSExcelUtility.IDX_OFFSET;
            }
            finally
            {
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }
            }
        }

        public static string EscapeExcelSheetName(string sheetName)
        {
            string newSheetName = sheetName;

            if (newSheetName.Length > 31)
            {
                newSheetName = newSheetName.Substring(0, 31);
            }

            newSheetName.Replace(':', '_');
            newSheetName.Replace('\\', '_');
            newSheetName.Replace('?', '_');
            newSheetName.Replace('/', '_');
            newSheetName.Replace('*', '_');

            newSheetName.Replace('[', '(');
            newSheetName.Replace(']', ')');

            newSheetName.Replace('：', '_');
            newSheetName.Replace('＼', '_');
            newSheetName.Replace('？', '_');
            newSheetName.Replace('／', '_');
            newSheetName.Replace('＊', '_');

            newSheetName.Replace('［', '(');
            newSheetName.Replace('］', ')');

            return newSheetName;
        }

        // NOTICE プリンタ名を指定できるバージョンを用意する => 今後の課題(今回はBasePrint側で対応される)
        // NOTICE 帳票毎に異なる用紙(のプリンタ)を指定できる仕組みを用意する(今回はApplication側で対応される)
        // NOTICE Excel側は、ローカルプリンタ設定名を認識する（Canon LBP3300など）

        public static void PrintOut(Workbook book)
        {
            book.PrintOutEx();
        }

        public static void PrintOut(Worksheet sheet)
        {
            sheet.PrintOutEx();
        }
    }
}
