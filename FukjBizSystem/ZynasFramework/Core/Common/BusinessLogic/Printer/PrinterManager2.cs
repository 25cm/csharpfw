using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.BusinessLogic.Printer
{
    // TODO to be removed
    /// <summary>
    /// 実際には、アプリケーションコード内で固有の設定を指定する
    /// </summary>
    public partial class PrinterManager
    {
        public enum PrintFormatType
        {
            // TODO 帳票形式定義
        }

        public static string GetPrinterName(PrintFormatType printFormatType)
        {
            return GetPrinterName((int)printFormatType);
        }

        public static void InitPrinterMap()
        {
            // TODO アプリケーション固有の方法により、プリンター設定を取得・保持する(DB,ファイルなどから取得)
            List<PrinterSelector> printers = new List<PrinterSelector>();
            {
                PrinterSelector sel = new PrinterSelector();
                sel.printFormatType = 1;
                printers.Add(sel);
            }
            {
                PrinterSelector sel = new PrinterSelector();
                sel.printFormatType = 2;
                printers.Add(sel);
            }
            {
                PrinterSelector sel = new PrinterSelector();
                sel.printFormatType = 3;
                printers.Add(sel);
            }
            {
                PrinterSelector sel = new PrinterSelector();
                sel.printFormatType = 4;
                printers.Add(sel);
            }

            SetPrinterMap(printers.ToArray());
        }

        //private static string[] GetPrinterNames()
        //{
        //    // TODO Windowsプリンタ名一覧取得

        //    return null;
        //}
    }
}
