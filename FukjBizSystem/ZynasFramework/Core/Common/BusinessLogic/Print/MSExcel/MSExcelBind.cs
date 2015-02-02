using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Zynas.Framework.Core.Common.BusinessLogic.Print.MSExcel
{
    public class MSExcelBind : ExcelBind
    {
        // NOTICE MSExcelUtilityのメソッドを呼び出す => 将来的には、移行していく
        Worksheet currentSheet = null;
        Workbook book = null;

        // NOTICE オーバーロード系のメソッドは、ベースクラスに逃がす => 将来的には、移行していく

        public MSExcelBind(Microsoft.Office.Interop.Excel.Workbook book)
        {
            this.book = book;
        }

        public override void SetCurrentSheet(int sheetIdx)
        {
            Sheets sheets = null;

            try
            {
                sheets = book.Sheets;

                if ((sheetIdx + MSExcelUtility.IDX_OFFSET) > sheets.Count)
                {
                    return;
                }

                if (currentSheet != null)
                {
                    Marshal.ReleaseComObject(currentSheet);
                }

                currentSheet = (Worksheet)sheets[sheetIdx + MSExcelUtility.IDX_OFFSET];
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
        /// <param name="sheetIdx"></param>
        public override void SetDispSheet(int sheetIdx)
        {
            Worksheet tempSheet = null;
            Sheets sheets = null;

            try
            {
                sheets = book.Sheets;
                tempSheet = (Worksheet)sheets[sheetIdx + MSExcelUtility.IDX_OFFSET];

                tempSheet.Activate();
            }
            finally
            {
                if (tempSheet != null)
                {
                    Marshal.ReleaseComObject(tempSheet);
                }
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SelectAllSheet()
        {
            Worksheet tempSheet = null;
            Sheets sheets = null;

            try
            {
                sheets = book.Sheets;

                sheets.Select();
            }
            finally
            {
                if (tempSheet != null)
                {
                    Marshal.ReleaseComObject(tempSheet);
                }
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public override void CellOutput(int row, int col, object value)
        {
            MSExcelUtility.CellOutput(currentSheet, row, col, value);
        }

        public override void RowCopy(int fromSheetIdx, int fromRowIdx, int toSheetIdx, int toRowIdx, int rowCnt)
        {
            Worksheet fromSheet = null;
            Worksheet toSheet = null;
            Sheets sheets = null;

            try
            {
                sheets = book.Sheets;

                fromSheet = (Worksheet)sheets[fromSheetIdx + MSExcelUtility.IDX_OFFSET];
                toSheet = (Worksheet)sheets[toSheetIdx + MSExcelUtility.IDX_OFFSET];

                MSExcelUtility.RowCopy(fromSheet, fromRowIdx, toSheet, toRowIdx, rowCnt);
            }
            finally
            {
                if (fromSheet != null)
                {
                    Marshal.ReleaseComObject(fromSheet);
                }
                if (toSheet != null)
                {
                    Marshal.ReleaseComObject(toSheet);
                }
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
            }
        }

        /*
        public override void RowCopy(int fromRowIdx, int toRowIdx, int rowCnt)
        {
            MSExcelUtility.RowCopy(currentSheet, fromRowIdx, currentSheet, toRowIdx, rowCnt);
        }
        */

        public override void SheetCopy(int fromSheetIdx)
        {
            MSExcelUtility.SheetCopy(book, fromSheetIdx);

            // 現在のシートを設定
            // NOTICE ここで(カレントシート設定を)自動でやるべきかは、再度検討 => 今回の使用範囲では、1シート出力の為、不要
            SetCurrentSheet(MSExcelUtility.GetSheetCount(book) - 1);
        }

        public override void SheetDelete(int sheetIdx)
        {
            MSExcelUtility.SheetDelete(book, sheetIdx);
        }

        public override void SetPageRowBreak(int rowIdx)
        {
            MSExcelUtility.SetPageBreak(currentSheet, rowIdx);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public override int GetSheetIdx(string sheetName)
        {
            return MSExcelUtility.GetSheetIndex(book, sheetName);
        }

        public override int GetCurrentSheetIdx()
        {
            if (currentSheet != null)
            {
                return GetSheetIdx(currentSheet.Name);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topRow"></param>
        /// <param name="leftCol"></param>
        /// <param name="bottomRow"></param>
        /// <param name="rightCol"></param>
        public override void SetPrintArea(int topRow, int leftCol, int bottomRow, int rightCol)
        {
            MSExcelUtility.SetPrintArea(currentSheet, topRow, leftCol, bottomRow, rightCol);
        }
    }
}
