using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.GyoshaMst;
using FukjBizSystem.Application.DataAccess.KaikeiRendoDtlTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSuitouUkagaishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSuitouUkagaishoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KaikeiRendoHdrTblKensakuRow
        /// </summary>
        KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow KaikeiRendoHdrTblKensakuRow { get; set; }

        /// <summary>
        /// KeikeiRenban
        /// </summary>
        string KeikeiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSuitouUkagaishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuitouUkagaishoBLInput : BaseExcelPrintBLInputImpl, IPrintSuitouUkagaishoBLInput
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
        /// KaikeiRendoHdrTblKensakuRow
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow KaikeiRendoHdrTblKensakuRow { get; set; }

        /// <summary>
        /// KeikeiRenban
        /// </summary>
        public string KeikeiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSuitouUkagaishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSuitouUkagaishoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSuitouUkagaishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuitouUkagaishoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSuitouUkagaishoBLOutput
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
    //  クラス名 ： PrintSuitouUkagaishoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuitouUkagaishoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSuitouUkagaishoBLInput, IPrintSuitouUkagaishoBLOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// ROW_IDX_START_PASTE
        /// </summary>
        private const int ROW_IDX_START_PASTE = 105;

        /// <summary>
        /// ROW_COUNT_PAGE1 
        /// </summary>
        private const int ROW_COUNT_PAGE1 = 56;

        /// <summary>
        /// ROW_COUNT_PAGE2 
        /// </summary>
        private const int ROW_COUNT_PAGE2 = 49;

        /// <summary>
        /// COUNT_RECORD_IN_PAGE1 
        /// </summary>
        private const int COUNT_RECORD_IN_PAGE1 = 8;

        /// <summary>
        /// COUNT_RECORD_IN_PAGE2 
        /// </summary>
        private const int COUNT_RECORD_IN_PAGE2 = 20;

        /// <summary>
        /// shozokushisho
        /// </summary>
        string shozokushisho = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSuitouUkagaishoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSuitouUkagaishoBusinessLogic()
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
        /// 2014/09/15  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSuitouUkagaishoBLOutput SetBook(IPrintSuitouUkagaishoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSuitouUkagaishoBLOutput output = new PrintSuitouUkagaishoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow[] dtlRows = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet) book.Sheets["Sheet1"];
                string kaikeiNo = input.KaikeiRendoHdrTblKensakuRow.KaikeiNo;
                int totalPage = 1;

                KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable kaikeiRendoDtlTblDT = new KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable();
                ISelectKaikeiRendoDtlTblInfoDAInput getKaikeiRendoDtlInput = new SelectKaikeiRendoDtlTblInfoDAInput();
                kaikeiRendoDtlTblDT = new SelectKaikeiRendoDtlTblInfoDataAccess().Execute(getKaikeiRendoDtlInput).KaikeiRendoDtlTblDataTable;

                if (string.IsNullOrEmpty(input.KeikeiRenban))
                {
                    dtlRows = (KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow[])kaikeiRendoDtlTblDT.Select(string.Format("KaikeiNo = '{0}' AND OutputKbn = '1'", kaikeiNo), "KeikeiRenban");
                }
                else
                {
                    dtlRows = (KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow[])kaikeiRendoDtlTblDT.Select(string.Format("KaikeiNo = '{0}' AND KeikeiRenban = {1} AND OutputKbn = '1'", kaikeiNo, input.KeikeiRenban));
                }
                
                totalPage = (dtlRows.Length < 9) ? 1 : (((dtlRows.Length - 8) % 20 == 0) ? ((dtlRows.Length - 8) / 20) + 1 : ((dtlRows.Length - 8) / 20) + 2);

                //copy header of first page
                CopyRow(outputSheet, 0, ROW_COUNT_PAGE1, ROW_IDX_START_PASTE);

                #region output page1(header)

                //output header page1
                OutputHeaderPage1(book, outputSheet, input.KaikeiRendoHdrTblKensakuRow, ROW_IDX_START_PASTE, totalPage, input.KeikeiRenban, dtlRows);

                if (!string.IsNullOrEmpty(input.KeikeiRenban) && dtlRows.Length > 0)
                {
                    //(24)
                    ISelectGyoshaMstByKeyDAInput getGyoshaDAInput = new SelectGyoshaMstByKeyDAInput();
                    getGyoshaDAInput.GyoshaCd = dtlRows[0].IsKaikeiGyosyaCdNull() ? string.Empty : dtlRows[0].KaikeiGyosyaCd;
                    ISelectGyoshaMstByKeyDAOutput getGyoshaDAOutput = new SelectGyoshaMstByKeyDataAccess().Execute(getGyoshaDAInput);

                    CellOutput(outputSheet, 17 + ROW_IDX_START_PASTE, 3, (getGyoshaDAOutput.GyoshaMstDataTable.Count > 0) ? getGyoshaDAOutput.GyoshaMstDataTable[0].GyoshaNm : string.Empty);
                }

                #endregion

                int rowIdx = 0;
                bool isNewPage2 = false;
                int pasteRow = ROW_IDX_START_PASTE;
                int rowDtlIdx = 0;
                int pageIdx = 1;

                for (int i = 0; i < dtlRows.Length; i++)
                {
                    KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow printRow = dtlRows[i];

                    if (i < 8)
                    {
                        rowIdx = (i == 0) ? pasteRow : rowIdx += 2;

                        //output content page1
                        OutputContentPage1(outputSheet, rowIdx, printRow);
                    }
                    else
                    {
                        #region output next page

                        //copy second page
                        if (i == COUNT_RECORD_IN_PAGE1)
                        {
                            pasteRow += ROW_COUNT_PAGE1;
                            CopyRow(outputSheet, ROW_COUNT_PAGE1, ROW_COUNT_PAGE2, pasteRow);
                            isNewPage2 = true;
                        }
                        else if ((i - 8) % COUNT_RECORD_IN_PAGE2 == 0)
                        {
                            pasteRow += ROW_COUNT_PAGE2;
                            CopyRow(outputSheet, ROW_COUNT_PAGE1, ROW_COUNT_PAGE2, pasteRow);
                            isNewPage2 = true;
                        }

                        rowIdx += 2;

                        if (isNewPage2)
                        {
                            rowDtlIdx = 0;
                            rowIdx = pasteRow + rowDtlIdx;

                            //set break page
                            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[pasteRow + 1, 1]);
                            pageIdx++;

                            //output header next page
                            OutputHeaderNextPage(book, outputSheet, pasteRow, pageIdx, input.KaikeiRendoHdrTblKensakuRow, totalPage);
                        }

                        //output content next page
                        OutputContentNextPage(outputSheet, rowIdx, printRow);

                        #endregion

                        rowDtlIdx++;
                        isNewPage2 = false;
                    }
                }

                //delete template row
                DeleteRow(outputSheet, 0, ROW_IDX_START_PASTE);

                //set vertical break page
                DeleteColumn(outputSheet, 24, 100);

                //Set print area
                SetPrintArea(outputSheet, 0, 0, ((totalPage - 1) * ROW_COUNT_PAGE2 + ROW_COUNT_PAGE1) - 1, 23);

            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region OutputHeaderPage1
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： OutputHeaderPage1
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="outputSheet"></param>
        /// <param name="kaikeiRendoHdrRow"></param>
        /// <param name="startPasteRow"></param>
        /// <param name="totalPage"></param>
        /// <param name="keikeiRenban"></param>
        /// <param name="kaikeiRendoDtlRows"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　HuyTX    新規作成
        /// 2015/01/15　HuyTX    Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputHeaderPage1(Microsoft.Office.Interop.Excel.Workbook book, 
            Worksheet outputSheet, 
            KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow kaikeiRendoHdrRow,
            int startPasteRow,
            int totalPage,
            string keikeiRenban,
            KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow[] kaikeiRendoDtlRows)
        {
            #region output page1(header)

            DateTime kaikeiMakeDt = new DateTime();
            DateTime kaikeiHaniFromDt = new DateTime();
            DateTime kaikeiHaniToDt = new DateTime();

            //会計No (1)
            CellOutput(outputSheet, startPasteRow, 15, string.IsNullOrEmpty(keikeiRenban) ? "'" + kaikeiRendoHdrRow.KaikeiNo : "'" + kaikeiRendoHdrRow.KaikeiNo + "-" + keikeiRenban.PadLeft(2, '0'));

            //(2)
            CellOutput(outputSheet, startPasteRow, 22, "1/");

            //(3)
            CellOutput(outputSheet, startPasteRow, 23, totalPage);

            //(4), (6)
            if (shozokushisho != "0")
            {
                //(4)
                Range cellRange = outputSheet.get_Range("Z3");
                cellRange.Characters[7, 2].Insert(Boundary.Common.Common.GetShishoNmByShishoCd(Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd));

                CopyRange(book, 1, 3, 26, 1, 24, 1, 3 + startPasteRow, 1);

                //(6)
                CopyRange(book, 1, 7, 26, 7, 24, 1, 7 + startPasteRow, 1);
            }

            //(5)
            CellOutput(outputSheet, 4 + startPasteRow, 19, (DateTime.TryParse(kaikeiRendoHdrRow.KaikeiMakeDt, out kaikeiMakeDt)) ?
                Utility.DateUtility.ConvertToWareki(kaikeiMakeDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki)
                : string.Empty);

            //(7)
            if (DateTime.TryParse(kaikeiRendoHdrRow.KaikeiHaniFromDt, out kaikeiHaniFromDt))
            {
                CellOutput(outputSheet, 14 + startPasteRow, 0, Utility.DateUtility.ConvertToWareki(Utility.DateUtility.GetNendo(kaikeiHaniFromDt).ToString(), "yy"));
            }

            if (string.IsNullOrEmpty(keikeiRenban))
            {
                //(10)
                CellOutput(outputSheet, 16 + startPasteRow, 10, !kaikeiRendoHdrRow.IsKarikataKingakuNull() ? kaikeiRendoHdrRow.KarikataKingaku.ToString() : string.Empty);

                //(11)
                if (DateTime.TryParse(kaikeiRendoHdrRow.KaikeiHaniFromDt, out kaikeiHaniFromDt)
                    && DateTime.TryParse(kaikeiRendoHdrRow.KaikeiHaniToDt, out kaikeiHaniToDt))
                {
                    string makeKbn = string.Format("{0}{1}{2}{3}",
                        new string[]{(kaikeiRendoHdrRow.Yubin == "○") ? "郵便・" : string.Empty,
                                    (kaikeiRendoHdrRow.Bank == "○") ? "銀行・" : string.Empty,
                                    (kaikeiRendoHdrRow.Genkin == "○") ? "現金・" : string.Empty,
                                    (kaikeiRendoHdrRow.Shiharai == "○") ? "支払・" : string.Empty
                        });

                    //Ver1.03 Mod start
                    //CellOutput(outputSheet, 18 + startPasteRow, 3, string.Format("{0}～{1}/{2}/{3}/{4}",
                    //    new string[]{
                    //        Utility.DateUtility.ConvertToWareki(kaikeiHaniFromDt.ToString("yyyyMMdd"), "yy.MM.dd"),
                    //        Utility.DateUtility.ConvertToWareki(kaikeiHaniToDt.ToString("yyyyMMdd"), "yy.MM.dd"),
                    //        kaikeiRendoHdrRow.ShishoNm,
                    //        kaikeiRendoHdrRow.UriageNyukinKbn,
                    //        (!string.IsNullOrEmpty(makeKbn)) ? makeKbn.Remove(makeKbn.Length - 1, 1) : string.Empty}));

                    CellOutput(outputSheet, 18 + startPasteRow, 3, string.Format("{0}～{1}{2}/{3}{4}",
                        new string[]{
                            Utility.DateUtility.ConvertToWareki(kaikeiHaniFromDt.ToString("yyyyMMdd"), "yy.MM.dd"),
                            Utility.DateUtility.ConvertToWareki(kaikeiHaniToDt.ToString("yyyyMMdd"), "yy.MM.dd"),
                            !string.IsNullOrEmpty(kaikeiRendoHdrRow.KaikeiShisyoCd) ? string.Concat("/",kaikeiRendoHdrRow.ShishoNm) : string.Empty,
                            kaikeiRendoHdrRow.UriageNyukinKbn,
                            kaikeiRendoHdrRow.UriageNyukinKbnOrg == "2" ? string.Concat("/", ((!string.IsNullOrEmpty(makeKbn)) ? makeKbn.Remove(makeKbn.Length - 1, 1) : string.Empty))
                                                                     : string.Empty
                        }));
                    //End
                }
            }
            else
            {
                //(10)
                CellOutput(outputSheet, 16 + startPasteRow, 10, kaikeiRendoDtlRows.Length > 0 && !kaikeiRendoDtlRows[0].IsKarikataKingakuNull() ? kaikeiRendoDtlRows[0].KarikataKingaku.ToString() : string.Empty);
            }
            
            #endregion
        }

        #endregion

        #region OutputContentPage1
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： OutputContentPage1
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="rowIdx"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputContentPage1(Worksheet outputSheet, int rowIdx, KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow printRow)
        {
            //(12)
            CellOutput(outputSheet, 25 + rowIdx, 0, !printRow.IsKarikataKingakuNull() ? printRow.KarikataKingaku.ToString() : string.Empty);

            //(13)
            CellOutput(outputSheet, 25 + rowIdx, 4, !printRow.IsKarikataZeiKbnNull() ? printRow.KarikataZeiKbn : string.Empty);

            //(14)
            CellOutput(outputSheet, 26 + rowIdx, 4, !printRow.IsKarikataJigyoCdNull() ? printRow.KarikataJigyoCd : string.Empty);

            //(15)
            CellOutput(outputSheet, 25 + rowIdx, 5, !printRow.IsKarikataKamokuNmNull() ? printRow.KarikataKamokuNm : string.Empty);

            //(16)
            CellOutput(outputSheet, 26 + rowIdx, 5, !printRow.IsKarikataHojoKamokuNmNull() ? printRow.KarikataHojoKamokuNm : string.Empty);

            //(17)
            CellOutput(outputSheet, 25 + rowIdx, 8, !printRow.IsTekiyoNull() ? printRow.Tekiyo : string.Empty);

            //(18)
            CellOutput(outputSheet, 25 + rowIdx, 15, !printRow.IsKashikataKamokuNmNull() ? printRow.KashikataKamokuNm : string.Empty);

            //(19)
            CellOutput(outputSheet, 26 + rowIdx, 15, !printRow.IsKashikataHojoKamokuNmNull() ? printRow.KashikataHojoKamokuNm : string.Empty);

            //(20)
            CellOutput(outputSheet, 25 + rowIdx, 19, !printRow.IsKashikataZeiKbnNull() ? printRow.KashikataZeiKbn : string.Empty);

            //(21)
            CellOutput(outputSheet, 26 + rowIdx, 19, !printRow.IsKashikataJigyoCdNull() ? printRow.KashikataJigyoCd : string.Empty);

            //(22)
            CellOutput(outputSheet, 25 + rowIdx, 21, !printRow.IsKashikataKingakuNull() ? printRow.KashikataKingaku.ToString() : string.Empty);

            //(23)
            CellOutput(outputSheet, 26 + rowIdx, 21, (printRow.IsSyohizeiGakuNull() || printRow.SyohizeiGaku == 0) ? string.Empty : printRow.SyohizeiGaku.ToString());
        }
        #endregion

        #region OutputHeaderNextPage
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： OutputHeaderNextPage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="outputSheet"></param>
        /// <param name="pasteRow"></param>
        /// <param name="pageIdx"></param>
        /// <param name="kaikeiRendoHdrRow"></param>
        /// <param name="totalPage"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputHeaderNextPage(Microsoft.Office.Interop.Excel.Workbook book,
            Worksheet outputSheet,
            int pasteRow,
            int pageIdx,
            KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow kaikeiRendoHdrRow,
            int totalPage)
        {
            DateTime kaikeiMakeDt = new DateTime();

            //会計No (1)
            CellOutput(outputSheet, 0 + pasteRow, 15, "'" + kaikeiRendoHdrRow.KaikeiNo);

            //(2)
            CellOutput(outputSheet, 0 + pasteRow, 22, pageIdx + "/");

            //(3)
            CellOutput(outputSheet, 0 + pasteRow, 23, totalPage);

            //(4)
            if (shozokushisho != "0")
            {
                CopyRange(book, 1, 3, 26, 1, 24, 1, 4 + pasteRow, 1);
            }

            //(5)
            CellOutput(outputSheet, 5 + pasteRow, 19, (DateTime.TryParse(kaikeiRendoHdrRow.KaikeiMakeDt, out kaikeiMakeDt)) ?
                Utility.DateUtility.ConvertToWareki(kaikeiMakeDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki)
                : string.Empty);
        }

        #endregion

        #region OutputContentNextPage
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： OutputContentNextPage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="rowIdx"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputContentNextPage(Worksheet outputSheet, int rowIdx, KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow printRow)
        {
            //(12)
            CellOutput(outputSheet, 8 + rowIdx, 0, !printRow.IsKarikataKingakuNull() ? printRow.KarikataKingaku.ToString() : string.Empty);

            //(13)
            CellOutput(outputSheet, 8 + rowIdx, 4, !printRow.IsKarikataZeiKbnNull() ? printRow.KarikataZeiKbn : string.Empty);

            //(14)
            CellOutput(outputSheet, 9 + rowIdx, 4, !printRow.IsKarikataJigyoCdNull() ? printRow.KarikataJigyoCd : string.Empty);

            //(15)
            CellOutput(outputSheet, 8 + rowIdx, 5, !printRow.IsKarikataKamokuNmNull() ? printRow.KarikataKamokuNm : string.Empty);

            //(16)
            CellOutput(outputSheet, 9 + rowIdx, 5, !printRow.IsKarikataHojoKamokuNmNull() ? printRow.KarikataHojoKamokuNm : string.Empty);

            //(17)
            CellOutput(outputSheet, 8 + rowIdx, 8, !printRow.IsTekiyoNull() ? printRow.Tekiyo : string.Empty);

            //(18)
            CellOutput(outputSheet, 8 + rowIdx, 15, !printRow.IsKashikataKamokuNmNull() ? printRow.KashikataKamokuNm : string.Empty);

            //(19)
            CellOutput(outputSheet, 9 + rowIdx, 15, !printRow.IsKashikataHojoKamokuNmNull() ? printRow.KashikataHojoKamokuNm : string.Empty);

            //(20)
            CellOutput(outputSheet, 8 + rowIdx, 19, !printRow.IsKashikataZeiKbnNull() ? printRow.KashikataZeiKbn : string.Empty);

            //(21)
            CellOutput(outputSheet, 9 + rowIdx, 19, !printRow.IsKashikataJigyoCdNull() ? printRow.KashikataJigyoCd : string.Empty);

            //(22)
            CellOutput(outputSheet, 8 + rowIdx, 21, !printRow.IsKashikataKingakuNull() ? printRow.KashikataKingaku.ToString() : string.Empty);

            //(23)
            CellOutput(outputSheet, 9 + rowIdx, 21, (printRow.IsSyohizeiGakuNull() || printRow.SyohizeiGaku == 0) ? string.Empty : printRow.SyohizeiGaku.ToString());
        }
        #endregion

        #endregion

    }
    #endregion
}
