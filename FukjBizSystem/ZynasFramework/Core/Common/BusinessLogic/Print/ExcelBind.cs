using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.BusinessLogic.Print
{
    public abstract class ExcelBind
    {
        public abstract void CellOutput(int row, int col, object value);

        // NOTICE ブロック出力用 => 将来的には、対応する
        //public abstract void CellOutput(int row, int fromColIdx, int toColIdx, object[] value);

        // NOTICE Shape文字列設定用 => 将来的には、対応する
        //public abstract void ShapeOutput(string shapeName, string text);

        public abstract void RowCopy(int fromSheetIdx, int fromRowIdx, int toSheetIdx, int toRowIdx, int rowCnt);

        public virtual void RowCopy(int fromRowIdx, int toRowIdx, int rowCnt)
        {
            RowCopy(GetCurrentSheetIdx(), fromRowIdx, GetCurrentSheetIdx(), toRowIdx, rowCnt);
        }

        public virtual void RowCopy(int fromRowIdx, int toRowIdx)
        {
            RowCopy(fromRowIdx, toRowIdx, 1);
        }

        public virtual void RowCopy(int fromSheetIdx, int fromRowIdx, int toSheetIdx, int toRowIdx)
        {
            RowCopy(fromSheetIdx, fromRowIdx, toSheetIdx, toRowIdx, 1);
        }

        // NOTICE use clipBoard版を用意しても良い（後で。PasteSpecialを使う）-> 今回は使用しない

        // NOTICE 
        //public abstract void SheetCopy(int fromSheetIdx, int toSheetIdx);

        public abstract void SheetCopy(int fromSheetIdx);

        public abstract void SheetDelete(int sheetIdx);

        //指定行の下側に改ページを設定する
        public abstract void SetPageRowBreak(int rowIdx);

        //// NOTICE -> 実寸での出力を行う場合は実装する
        //public abstract int GetRowHeight(int row);

        public abstract int GetSheetIdx(string sheetName);

        public abstract int GetCurrentSheetIdx();

        public abstract void SetCurrentSheet(int sheetIdx);

        public virtual void SetCurrentSheet(string sheetName)
        {
            int sheetIdx = GetSheetIdx(sheetName);

            SetCurrentSheet(sheetIdx);
        }

        public abstract void SetDispSheet(int sheetIdx);

        public abstract void SelectAllSheet();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topRow"></param>
        /// <param name="leftCol"></param>
        /// <param name="bottomRow"></param>
        /// <param name="rightCol"></param>
        public abstract void SetPrintArea(int topRow, int leftCol, int bottomRow, int rightCol);

        /// <summary>
        /// 全てのシートを印刷
        /// </summary>
        //public abstract void PrintOut();
    }
}
