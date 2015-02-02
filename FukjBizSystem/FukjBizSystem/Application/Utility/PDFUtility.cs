using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FukjBizSystem.Application.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class PDFUtility
    {
        /// <summary>
        /// PDFファイルを別プロセスで表示する
        /// </summary>
        /// <param name="filePath">PDFファイルフルパス</param>
        public static void DisplayPDF(string filePath)
        {
            System.Diagnostics.Process.Start(filePath);

            // TODO Adobe Readerが無い場合の配慮があると良い

        }
    }
}
