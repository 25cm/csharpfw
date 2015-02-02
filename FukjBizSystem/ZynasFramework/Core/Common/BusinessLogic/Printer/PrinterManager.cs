using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.BusinessLogic.Printer
{
    // TODO to be removed
    public partial class PrinterManager
    {
        // TODO 帳票毎のプリンタ対応付けは、アプリケーションコード側で行う事
        public class PrinterSelector
        {
            /// <summary>
            /// 端末識別子(Windowsコンピュータ名 or IPアドレス)
            /// </summary>
            public string machineId;

            /// <summary>
            /// 出力対象種別(帳票種別など)
            /// </summary>
            public int printFormatType;

            /// <summary>
            /// ローカルプリンタ名
            /// </summary>
            public string printerName;
        }

        static List<PrinterSelector> printerMap;

        public static void SetPrinterMap(PrinterSelector[] printers)
        {
            printerMap = new List<PrinterSelector>(printers);
        }

        public static string GetPrinterName(int printFormatType)
        {
            foreach (PrinterSelector sel in printerMap)
            {
                if (sel.printFormatType == printFormatType)
                {
                    return sel.printerName;
                }
            }

            return null;
        }

        //private static string[] GetPrinterNames()
        //{
        //    // TODO Windowsプリンタ名一覧取得

        //    return null;
        //}
    }
}
