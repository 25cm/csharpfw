using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.HoteiKanriMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.SaisuiinShomeishoHakko
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSaisuiinShomeishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSaisuiinShomeishoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SaisuiinShomeishoHakkoKensakuDataTable
        /// </summary>
        SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable SaisuiinShomeishoHakkoKensakuDataTable { get; set; }

        /// <summary>
        /// 発行日 
        /// </summary>
        DateTime HakkoDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSaisuiinShomeishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaisuiinShomeishoBLInput : BaseExcelPrintBLInputImpl, IPrintSaisuiinShomeishoBLInput
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
        /// SaisuiinShomeishoHakkoKensakuDataTable
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable SaisuiinShomeishoHakkoKensakuDataTable { get; set; }

        /// <summary>
        /// 発行日 
        /// </summary>
        public DateTime HakkoDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSaisuiinShomeishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSaisuiinShomeishoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSaisuiinShomeishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaisuiinShomeishoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSaisuiinShomeishoBLOutput
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
    //  クラス名 ： PrintSaisuiinShomeishoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaisuiinShomeishoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSaisuiinShomeishoBLInput, IPrintSaisuiinShomeishoBLOutput>
    {
        #region 定義

        /// <summary>
        /// Start index row for first 5 blocks
        /// 1 block = 1 指定採水員証明書
        /// </summary>
        private const int START_ROW_IN_SET_1 = 0;

        /// <summary>
        /// Start index row for last 5 blocks
        /// </summary>
        private const int START_ROW_IN_SET_2 = 27;

        /// <summary>
        /// Number of column per block
        /// </summary>
        private const int NUM_COL_PER_BLOCK = 14;

        /// <summary>
        /// Number of blocks which are in same line
        /// </summary>
        private const int NUM_BLOCK_IN_SAME_LINE = 5;

        #endregion

        #region 置換文字列

        /// <summary>
        /// Number of rows per page
        /// </summary>
        private const int ROW_IN_PAGE = 52;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSaisuiinShomeishoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSaisuiinShomeishoBusinessLogic()
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
        /// 2014/08/05　AnhNV　　    新規作成
        /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSaisuiinShomeishoBLOutput SetBook(IPrintSaisuiinShomeishoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSaisuiinShomeishoBLOutput output = new PrintSaisuiinShomeishoBLOutput();

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
                // Copy a new sheet
                tempSheet.Copy(tempSheet, Type.Missing);
                // Set output sheet to current active sheet
                outputSheet = (Worksheet)book.ActiveSheet;
                outputSheet.Name = "指定採水員証明書";

                // Row index is in process
                int curRow = START_ROW_IN_SET_1;
                // Column index is in process
                int curCol = 1;
                // Number of saisuiin
                int numBlock = 0;
                // Sheet index
                int sheetIdx = 1;

                // Get 法定管理マスタ by key
                ISelectHoteiKanriMstByKeyDAInput daInput = new SelectHoteiKanriMstByKeyDAInput();
                daInput.JimukyokuKbn = "0";
                ISelectHoteiKanriMstByKeyDAOutput daOutput = new SelectHoteiKanriMstByKeyDataAccess().Execute(daInput);
                string daihyoshaNm = daOutput.HoteiKanriMstDataTable.Count > 0 ? daOutput.HoteiKanriMstDataTable[0].JimukyokuDaihyoshaNm : string.Empty;

                foreach (SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuRow row in input.SaisuiinShomeishoHakkoKensakuDataTable)
                {
                    // Print 10 blocks per page?
                    if (numBlock == NUM_BLOCK_IN_SAME_LINE * 2)
                    {
                        // Copy a new sheet
                        tempSheet.Copy(tempSheet, Type.Missing);

                        // Set output sheet to current active sheet
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = "指定採水員証明書_" + sheetIdx;

                        // Reset counting variables
                        curCol = 1;
                        curRow = START_ROW_IN_SET_1;
                        numBlock = 0;

                        // New sheet
                        sheetIdx++;
                    }
                    else if (numBlock > 0 && numBlock % NUM_BLOCK_IN_SAME_LINE == 0) // Print 5 blocks in same line?
                    {
                        // Move to last 5 blocks
                        curRow = START_ROW_IN_SET_2;
                        curCol = 1;
                    }

                    // Detail for each rows
                    SetDetail(outputSheet, row, input.HakkoDt, curRow, curCol, daihyoshaNm);

                    // Next block
                    curCol += NUM_COL_PER_BLOCK;

                    // 1 block is filled data up
                    numBlock++;
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
        /// <param name="hakkoDt"></param>
        /// <param name="curRow"></param>
        /// <param name="curCol"></param>
        /// <param name="daihyoshaNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/05　AnhNV　　    新規作成
        /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
        /// 2014/11/05　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail
            (
                Worksheet sheet,
                SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuRow row,
                DateTime hakkoDt,
                int curRow,
                int curCol,
                string daihyoshaNm
            )
        {
            // 採水員指定No(1)
            CellOutput(sheet, curRow + 3, curCol + 4, string.Concat("'", row.SaisuiinCd));

            // 採水員名(2)
            CellOutput(sheet, curRow + 5, curCol + 4, row.SaisuiinNm);

            // 採水員生年月日(3)
            CellOutput(sheet, curRow + 8, curCol + 6, string.IsNullOrEmpty(row.SaisuiinSeinegappi) ? string.Empty : Convert.ToDateTime(row.SaisuiinSeinegappi).ToString("yyyy"));
            CellOutput(sheet, curRow + 8, curCol + 9, string.IsNullOrEmpty(row.SaisuiinSeinegappi) ? string.Empty : Convert.ToDateTime(row.SaisuiinSeinegappi).ToString("MM"));
            CellOutput(sheet, curRow + 8, curCol + 11, string.IsNullOrEmpty(row.SaisuiinSeinegappi) ? string.Empty : Convert.ToDateTime(row.SaisuiinSeinegappi).ToString("dd"));

            // 受講日(4)
            CellOutput(sheet, curRow + 16, curCol + 4, string.IsNullOrEmpty(row.JukoDt) ? string.Empty : Convert.ToDateTime(row.JukoDt).ToString("yyyy"));
            CellOutput(sheet, curRow + 16, curCol + 7, string.IsNullOrEmpty(row.JukoDt) ? string.Empty : Convert.ToDateTime(row.JukoDt).ToString("MM"));
            CellOutput(sheet, curRow + 16, curCol + 9, string.IsNullOrEmpty(row.JukoDt) ? string.Empty : Convert.ToDateTime(row.JukoDt).ToString("dd"));

            // 採水員有効期限(5)
            CellOutput(sheet, curRow + 18, curCol + 4, string.IsNullOrEmpty(row.SaisuiinYukokigenDt) ? string.Empty : Convert.ToDateTime(row.SaisuiinYukokigenDt).ToString("yyyy"));
            CellOutput(sheet, curRow + 18, curCol + 7, string.IsNullOrEmpty(row.SaisuiinYukokigenDt) ? string.Empty : Convert.ToDateTime(row.SaisuiinYukokigenDt).ToString("MM"));
            CellOutput(sheet, curRow + 18, curCol + 9, string.IsNullOrEmpty(row.SaisuiinYukokigenDt) ? string.Empty : Convert.ToDateTime(row.SaisuiinYukokigenDt).ToString("dd"));

            // 採水員取得日(6)
            CellOutput(sheet, curRow + 20, curCol + 3, hakkoDt.ToString("yyyy"));
            CellOutput(sheet, curRow + 20, curCol + 6, hakkoDt.ToString("MM"));
            CellOutput(sheet, curRow + 20, curCol + 8, hakkoDt.ToString("dd"));

            // 事務局代表者名(7)
            CellOutput(sheet, curRow + 24, curCol + 4, daihyoshaNm);
        }
        #endregion

        #endregion
    }
    #endregion
}
