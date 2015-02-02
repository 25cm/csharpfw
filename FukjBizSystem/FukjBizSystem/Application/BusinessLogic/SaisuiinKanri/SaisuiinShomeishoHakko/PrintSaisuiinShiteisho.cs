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
    //  インターフェイス名 ： IPrintSaisuiinShiteishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　AnhNV　　    新規作成
    /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSaisuiinShiteishoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 発行日 
        /// </summary>
        DateTime HakkoDt { get; set; }

        /// <summary>
        /// SaisuiinShomeishoHakkoKensakuDataTable
        /// </summary>
        SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable SaisuiinShomeishoHakkoKensakuDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSaisuiinShiteishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　AnhNV　　    新規作成
    /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaisuiinShiteishoBLInput : BaseExcelPrintBLInputImpl, IPrintSaisuiinShiteishoBLInput
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
        /// 発行日 
        /// </summary>
        public DateTime HakkoDt { get; set; }

        /// <summary>
        /// SaisuiinShomeishoHakkoKensakuDataTable
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable SaisuiinShomeishoHakkoKensakuDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSaisuiinShiteishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSaisuiinShiteishoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSaisuiinShiteishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaisuiinShiteishoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSaisuiinShiteishoBLOutput
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
    //  クラス名 ： PrintSaisuiinShiteishoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSaisuiinShiteishoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSaisuiinShiteishoBLInput, IPrintSaisuiinShiteishoBLOutput>
    {
        #region 置換文字列

        /// <summary>
        /// Number of rows per page
        /// </summary>
        private const int ROW_IN_PAGE = 35;

        #region ヘッダー

        #endregion

        #region 明細
        //private const string REPLACE_CELL_SHITEINO = "#SHITEINO";
        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSaisuiinShiteishoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSaisuiinShiteishoBusinessLogic()
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
        /// 2014/08/06　AnhNV　　    新規作成
        /// 2014/10/08　AnhNV　　    014_指定採水員証明書_帳票設計書_v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSaisuiinShiteishoBLOutput SetBook(IPrintSaisuiinShiteishoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSaisuiinShiteishoBLOutput output = new PrintSaisuiinShiteishoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Output sheet
                outputSheet = (Worksheet)book.Sheets["Sheet1"];
                outputSheet.Name = "指定採水員指定書";

                // Index of detail row
                int curRow = 1;

                // Get 法定管理マスタ by key
                ISelectHoteiKanriMstByKeyDAInput daInput = new SelectHoteiKanriMstByKeyDAInput();
                daInput.JimukyokuKbn = "0";
                ISelectHoteiKanriMstByKeyDAOutput daOutput = new SelectHoteiKanriMstByKeyDataAccess().Execute(daInput);
                string daihyoshaNm = daOutput.HoteiKanriMstDataTable.Count > 0 ? daOutput.HoteiKanriMstDataTable[0].JimukyokuDaihyoshaNm : string.Empty;

                foreach (SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuRow row in input.SaisuiinShomeishoHakkoKensakuDataTable)
                {
                    // Page break
                    if (curRow > 1)
                    {
                        // Break page
                        outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow, 1]);

                        // New page
                        CopyRow(outputSheet, 1, ROW_IN_PAGE, curRow);
                    }

                    // Detail for each rows
                    SetDetail(outputSheet, row, curRow, daihyoshaNm, input.HakkoDt);

                    // Row in next page
                    curRow += ROW_IN_PAGE;
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
        /// <param name="daihyoshaNm"></param>
        /// <param name="hakkoDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06　AnhNV　　    新規作成
        /// 2014/11/05　AnhNV　　    013_指定採水員指定書_帳票設計書_V1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail
            (
                Worksheet sheet,
                SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuRow row,
                int curRow,
                string daihyoshaNm,
                DateTime hakkoDt
            )
        {
            // 採水員指定No(1)
            CellOutput(sheet, curRow, 25, string.Concat("'", row.SaisuiinCd));

            // 業者名称 (2)
            CellOutput(sheet, curRow + 6, 7, row.GyoshaNm);

            // 採水員住所(3)
            CellOutput(sheet, curRow + 8, 7, row.SaisuiinAdr);

            // 採水員名 (4)
            CellOutput(sheet, curRow + 10, 7, row.SaisuiinNm);

            // 採水員生年月日(5)
            CellOutput(sheet, curRow + 13, 17, string.IsNullOrEmpty(row.SaisuiinSeinegappi) ? string.Empty : Convert.ToDateTime(row.SaisuiinSeinegappi).ToString("yyyy"));
            CellOutput(sheet, curRow + 13, 21, string.IsNullOrEmpty(row.SaisuiinSeinegappi) ? string.Empty : Convert.ToDateTime(row.SaisuiinSeinegappi).ToString("MM"));
            CellOutput(sheet, curRow + 13, 24, string.IsNullOrEmpty(row.SaisuiinSeinegappi) ? string.Empty : Convert.ToDateTime(row.SaisuiinSeinegappi).ToString("dd"));

            // 受講日(6)
            CellOutput(sheet, curRow + 19, 14, string.IsNullOrEmpty(row.JukoDt) ? string.Empty : Convert.ToDateTime(row.JukoDt).ToString("yyyy"));
            CellOutput(sheet, curRow + 19, 18, string.IsNullOrEmpty(row.JukoDt) ? string.Empty : Convert.ToDateTime(row.JukoDt).ToString("MM"));
            CellOutput(sheet, curRow + 19, 21, string.IsNullOrEmpty(row.JukoDt) ? string.Empty : Convert.ToDateTime(row.JukoDt).ToString("dd"));

            // 採水員有効期限(7)
            CellOutput(sheet, curRow + 21, 14, string.IsNullOrEmpty(row.SaisuiinYukokigenDt) ? string.Empty : Convert.ToDateTime(row.SaisuiinYukokigenDt).ToString("yyyy"));
            CellOutput(sheet, curRow + 21, 18, string.IsNullOrEmpty(row.SaisuiinYukokigenDt) ? string.Empty : Convert.ToDateTime(row.SaisuiinYukokigenDt).ToString("MM"));
            CellOutput(sheet, curRow + 21, 21, string.IsNullOrEmpty(row.SaisuiinYukokigenDt) ? string.Empty : Convert.ToDateTime(row.SaisuiinYukokigenDt).ToString("dd"));

            // 採水員取得日(8)
            CellOutput(sheet, curRow + 24, 10, hakkoDt.ToString("yyyy"));
            CellOutput(sheet, curRow + 24, 14, hakkoDt.ToString("MM"));
            CellOutput(sheet, curRow + 24, 17, hakkoDt.ToString("dd"));

            // 事務局代表者名(9)
            CellOutput(sheet, curRow + 30, 12, string.Concat("'", daihyoshaNm));
        }
        #endregion

        #endregion
    }
    #endregion
}
