using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.TuckSealList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSofujoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSofujoBLInput : IBaseExcelPrintBLInput
    {
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
    //  クラス名 ： PrintSofujoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSofujoBLInput : BaseExcelPrintBLInputImpl, IPrintSofujoBLInput
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
    //  インターフェイス名 ： IPrintSofujoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSofujoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSofujoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSofujoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSofujoBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSofujoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSofujoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSofujoBLInput, IPrintSofujoBLOutput>
    {
        #region 置換文字列
        
        /// <summary>
        /// Number of rows per page
        /// </summary>
        private const int ROW_PER_PAGE = 15;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSofujoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSofujoBusinessLogic()
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
        /// 2014/08/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSofujoBLOutput SetBook(IPrintSofujoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSofujoBLOutput output = new PrintSofujoBLOutput();

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
                outputSheet.Name = "送付状";

                // Current row in process
                int curRow = 0;

                // Zipcode part
                char[] zipcodePart = new char[8] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' };

                for (int i = 0; i < input.CopyNumber; i++)
                {
                    foreach (JokasoDaichoMstDataSet.TuckSealListRow row in input.TuckSealListDataTable)
                    {
                        // New page
                        if (curRow > 0 && curRow % 15 == 0)
                        {
                            // Page breaks
                            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow, 1]);

                            // Copy a new page
                            //RowCopy(tempSheet, outputSheet, 2, 15, curRow + 1, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, 1, 15, outputSheet, curRow);

                            // Row height
                            outputSheet.Range[string.Format("A{0}", curRow), string.Format("A{0}", curRow)].RowHeight = 6.75;
                            outputSheet.Range[string.Format("A{0}", curRow + 1), string.Format("A{0}", curRow + 1)].RowHeight = 31.5;
                            outputSheet.Range[string.Format("A{0}", curRow + 2), string.Format("A{0}", curRow + 3)].RowHeight = 31.5;
                            outputSheet.Range[string.Format("A{0}", curRow + 5), string.Format("A{0}", curRow + 6)].RowHeight = 23.25;
                        }

                        // Split zipcode
                        if (!string.IsNullOrEmpty(row.ZipNoCol))
                        {
                            zipcodePart = row.ZipNoCol.ToCharArray();
                        }

                        // Detail for each page
                        SetDetail(outputSheet, row, curRow == 0 ? curRow : curRow - 1, zipcodePart);

                        // Next page
                        curRow += ROW_PER_PAGE;
                    }
                }

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
        /// <param name="zipCdPart"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Worksheet sheet, JokasoDaichoMstDataSet.TuckSealListRow row, int curRow, char[] zipCdPart)
        {
            // 郵便番号
            CellOutput(sheet, curRow + 1, 3, zipCdPart[0].ToString());
            CellOutput(sheet, curRow + 1, 4, zipCdPart[1].ToString());
            CellOutput(sheet, curRow + 1, 5, zipCdPart[2].ToString());
            CellOutput(sheet, curRow + 1, 7, zipCdPart[4].ToString());
            CellOutput(sheet, curRow + 1, 8, zipCdPart[5].ToString());
            CellOutput(sheet, curRow + 1, 9, zipCdPart[6].ToString());
            CellOutput(sheet, curRow + 1, 10, zipCdPart[7].ToString());

            // 住所
            CellOutput(sheet, curRow + 2, 2, row.AdrCol);

            // 業者名/保健所名/設置者名
            CellOutput(sheet, curRow + 5, 2, row.NmCol);
        }
        #endregion

        #endregion
    }
    #endregion
}
