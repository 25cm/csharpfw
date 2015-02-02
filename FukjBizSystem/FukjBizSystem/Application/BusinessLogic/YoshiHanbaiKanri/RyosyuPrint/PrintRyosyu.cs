using System;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using System.Runtime.InteropServices;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.RyosyuPrint
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintRyosyuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintRyosyuBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// RyosyuPrintInfoDataTable
        /// </summary>
        YoshiHanbaiHdrTblDataSet.RyosyuPrintInfoDataTable RyosyuPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintRyosyuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintRyosyuBLInput : BaseExcelPrintBLInputImpl, IPrintRyosyuBLInput
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
        /// RyosyuPrintInfoDataTable
        /// </summary>
        public YoshiHanbaiHdrTblDataSet.RyosyuPrintInfoDataTable RyosyuPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintRyosyuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintRyosyuBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintRyosyuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintRyosyuBLOutput : BaseExcelPrintBLOutputImpl, IPrintRyosyuBLOutput
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
    //  クラス名 ： PrintRyosyuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintRyosyuBusinessLogic : BaseExcelPrintBusinessLogic<IPrintRyosyuBLInput, IPrintRyosyuBLOutput>
    {
        #region 置換文字列

        private const string REPLACE_CELL_CHUMON_NO = "#CHUMON_NO";
        private const string REPLACE_CELL_YEAR = "#YEAR";
        private const string REPLACE_CELL_MON = "#MON";
        private const string REPLACE_CELL_DAY = "#DAY";
        private const string REPLACE_CELL_GYOSHA_NM = "#GYOSHA_NM";
        private const string REPLACE_CELL_YOSHI_HANBAI_GOKEI_KINGGAKU = "#YOSHI_HANBAI_GOKEI_KINGGAKU";
        private const string REPLACE_CELL_JIMUKYOKU_NM = "#JIMUKYOKU_NM";
        private const string REPLACE_CELL_JIMUKYOKU_ZIP_CD = "#JIMUKYOKU_ZIP_CD";
        private const string REPLACE_CELL_JIMUKYOKU_HOTEI_KANRI_ADR = "#JIMUKYOKU_HOTEI_KANRI_ADR";
        private const string REPLACE_CELL_JIMUKYOKU_TEL_NO = "#JIMUKYOKU_TEL_NO";
        private const string REPLACE_CELL_JIMUKYOKU_FAX_NO = "#JIMUKYOKU_FAX_NO";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintRyosyuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/05　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintRyosyuBusinessLogic()
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
        /// 2014/08/05　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintRyosyuBLOutput SetBook(IPrintRyosyuBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintRyosyuBLOutput output = new PrintRyosyuBLOutput();

            Worksheet outputSheet = null;
            try
            {
                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                if (input.RyosyuPrintInfoDataTable.Count != 0)
                {
                    CellReplace(outputSheet, REPLACE_CELL_CHUMON_NO, input.RyosyuPrintInfoDataTable[0].YoshiHanbaiChumonNo);
                    CellReplace(outputSheet, REPLACE_CELL_YEAR, input.RyosyuPrintInfoDataTable[0].YoshiHanbaiDt.Substring(0, 4));
                    CellReplace(outputSheet, REPLACE_CELL_MON, input.RyosyuPrintInfoDataTable[0].YoshiHanbaiDt.Substring(4, 2));
                    CellReplace(outputSheet, REPLACE_CELL_DAY, input.RyosyuPrintInfoDataTable[0].YoshiHanbaiDt.Substring(6, 2));
                    CellReplace(outputSheet, REPLACE_CELL_GYOSHA_NM, input.RyosyuPrintInfoDataTable[0].GyoshaNm);
                    CellReplace(outputSheet, REPLACE_CELL_YOSHI_HANBAI_GOKEI_KINGGAKU, "￥  " + input.RyosyuPrintInfoDataTable[0].YoshiHanbaiGokeiKingaku.ToString("N0") + "  -");
                    CellReplace(outputSheet, REPLACE_CELL_JIMUKYOKU_NM, input.RyosyuPrintInfoDataTable[0].JimukyokuNm);
                    CellReplace(outputSheet, REPLACE_CELL_JIMUKYOKU_ZIP_CD, "〒" + input.RyosyuPrintInfoDataTable[0].JimukyokuZipCd);
                    CellReplace(outputSheet, REPLACE_CELL_JIMUKYOKU_HOTEI_KANRI_ADR, input.RyosyuPrintInfoDataTable[0].JimukyokuHoteiKanriAdr);
                    CellReplace(outputSheet, REPLACE_CELL_JIMUKYOKU_TEL_NO, "TEL:" + input.RyosyuPrintInfoDataTable[0].JimukyokuTelNo);
                    CellReplace(outputSheet, REPLACE_CELL_JIMUKYOKU_FAX_NO, "FAX:" + input.RyosyuPrintInfoDataTable[0].JimukyokuFaxNo);
                }
            }
            finally
            {
                if (outputSheet != null)
                {
                    Marshal.ReleaseComObject(outputSheet);
                }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CellReplace
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CellReplace
        /// <summary>
        /// シート中の文字列の置き換えを実行する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">対象シート</param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/05　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CellReplace(Worksheet sheet, string oldValue, string newValue)
        {
            bool preAlerts = sheet.Application.DisplayAlerts;

            try
            {
                sheet.Application.DisplayAlerts = false;

                sheet.Cells.Replace(oldValue, newValue,
                    Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    Type.Missing, false);
            }
            finally
            {
                sheet.Application.DisplayAlerts = preAlerts;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
