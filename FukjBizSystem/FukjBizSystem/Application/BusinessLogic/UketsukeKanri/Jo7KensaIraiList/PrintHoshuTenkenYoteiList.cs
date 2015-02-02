using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaIraiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintHoshuTenkenYoteiListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintHoshuTenkenYoteiListBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensaIraiDtFrom
        /// </summary>
        DateTime KensaIraiDtFrom { get; set; }

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        DateTime KensaIraiDtTo { get; set; }

        /// <summary>
        /// Jo7KensaIraiListDataTable
        /// </summary>
        KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }

        /// <summary>
        /// KensaIraiDtJokenTuikaFlg 
        /// </summary>
        bool KensaIraiDtJokenTuikaFlg { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHoshuTenkenYoteiListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintHoshuTenkenYoteiListBLInput : BaseExcelPrintBLInputImpl, IPrintHoshuTenkenYoteiListBLInput
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
        /// KensaIraiDtFrom
        /// </summary>
        public DateTime KensaIraiDtFrom { get; set; }

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        public DateTime KensaIraiDtTo { get; set; }

        /// <summary>
        /// Jo7KensaIraiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }

        /// <summary>
        /// KensaIraiDtJokenTuikaFlg 
        /// </summary>
        public bool KensaIraiDtJokenTuikaFlg { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintHoshuTenkenYoteiListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintHoshuTenkenYoteiListBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHoshuTenkenYoteiListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintHoshuTenkenYoteiListBLOutput : BaseExcelPrintBLOutputImpl, IPrintHoshuTenkenYoteiListBLOutput
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
    //  クラス名 ： PrintHoshuTenkenYoteiListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintHoshuTenkenYoteiListBusinessLogic : BaseExcelPrintBusinessLogic<IPrintHoshuTenkenYoteiListBLInput, IPrintHoshuTenkenYoteiListBLOutput>
    {
        #region プロパティ

        ///// <summary>
        ///// ROW_COPY_IDX 
        ///// </summary>
        //private const int ROW_CONTENT_COPY_IDX = 9;

        ///// <summary>
        ///// ROW_COUNT_TITLE_COPY 
        ///// </summary>
        //private const int ROW_COUNT_TITLE_COPY = 9;

        ///// <summary>
        ///// PASTE_START_ROW_IDX 
        ///// </summary>
        //private const int PASTE_START_ROW_IDX = 10;

        ///// <summary>
        ///// ROW_COUNT_DELETE 
        ///// </summary>
        //private const int ROW_COUNT_DELETE = 10;

        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_HEADER = 9;

        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_DETAIL = 25;

        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_DETAIL2 = 30;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintHoshuTenkenYoteiListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintHoshuTenkenYoteiListBusinessLogic()
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
        /// 2014/09/08  HuyTX　　    新規作成
        /// 2014/11/24  HuyTX　　    Ver1.03(038_保守点検予定一覧_帳票設計書)
        /// 2014/12/15  habu　　    Modified page break
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintHoshuTenkenYoteiListBLOutput SetBook(IPrintHoshuTenkenYoteiListBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintHoshuTenkenYoteiListBLOutput output = new PrintHoshuTenkenYoteiListBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["OutputSheet"];

                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                // 最初にLINQでグループ化、ソートし、出力する
                // ページ切替を伴うソートここで実行する
                var yoteiGyoshaGroups = from yotei in input.Jo7KensaIraiListDataTable.AsEnumerable()
                                        group yotei by TypeUtility.GetString(yotei[input.Jo7KensaIraiListDataTable.JokasoHoshuyoteiGyoshaCdColumn])
                                            into yoteiGroup
                                            orderby yoteiGroup.Key
                                            select yoteiGroup;

                #region template

                // 最初に明細行部分を1ページ分コピーする(1ページ分のテンプレートを作成する)
                for (int i = 0; i < ROW_COUNT_DETAIL - 1; i++)
                {
                    CopyRow(outputSheet, ROW_COUNT_HEADER, 1, ROW_COUNT_HEADER + 1 + i);

                }
                // 改ページ設定
                SetPageBreak(outputSheet, ROW_COUNT_HEADER + ROW_COUNT_DETAIL);

                int copyIdx = ROW_COUNT_HEADER + ROW_COUNT_DETAIL;

                // 最初の業者が2ページ以上の場合は明細部コピー
                int firstDtlPageCnt = 0;
                if (yoteiGyoshaGroups.Count() > 0)
                {
                    if (yoteiGyoshaGroups.ElementAt(0).Count() <= ROW_COUNT_DETAIL)
                    {
                        firstDtlPageCnt = 1;
                    }
                    // 2ページ目以降でページ数が異なるのを考慮
                    else
                    {
                        firstDtlPageCnt = 1 + (int)Math.Ceiling((decimal)(yoteiGyoshaGroups.ElementAt(0).Count() - ROW_COUNT_DETAIL) / ROW_COUNT_DETAIL2);
                    }
                }
                if (firstDtlPageCnt > 1)
                {
                    // 明細部追加コピー
                    for (int i = 0; i < firstDtlPageCnt - 1; i++)
                    {
                        // 見出しコピー
                        CopyRow(outputSheet, ROW_COUNT_HEADER - 1, 1, copyIdx);
                        copyIdx += 1;

                        CopyRow(outputSheet, ROW_COUNT_HEADER, ROW_COUNT_DETAIL, copyIdx);
                        copyIdx += ROW_COUNT_DETAIL;
                        // 2ページ目以降はヘッダが無い分、明細行数が増える
                        CopyRow(outputSheet, ROW_COUNT_HEADER, ROW_COUNT_DETAIL2 - ROW_COUNT_DETAIL, copyIdx);
                        copyIdx += ROW_COUNT_DETAIL2 - ROW_COUNT_DETAIL;

                        // 改ページ設定
                        SetPageBreak(outputSheet, copyIdx);
                    }
                }

                int idx = 0;
                int totalRowCnt = 0;
                foreach (var gyoshaGroup in yoteiGyoshaGroups)
                {
                    int gyoshaPageCnt = 0;
                    if (gyoshaGroup.Count() <= ROW_COUNT_DETAIL)
                    {
                        gyoshaPageCnt = 1;
                    }
                    // 2ページ目以降でページ数が異なるのを考慮
                    else
                    {
                        gyoshaPageCnt = 1 + (int)Math.Ceiling((decimal)(gyoshaGroup.Count() - ROW_COUNT_DETAIL) / ROW_COUNT_DETAIL2);
                    }
                    totalRowCnt += (ROW_COUNT_HEADER - 1) + gyoshaPageCnt * (ROW_COUNT_DETAIL2 + 1) - (ROW_COUNT_DETAIL2 - ROW_COUNT_DETAIL);

                    if (idx == 0)
                    {
                        idx++;
                        continue;
                    }

                    // 業者毎に1回ヘッダ部をコピーする
                    CopyRow(outputSheet, 0, ROW_COUNT_HEADER, copyIdx);
                    copyIdx += ROW_COUNT_HEADER;

                    for (int i = 0; i < gyoshaPageCnt; i++)
                    {
                        // 2ページ目以降の見出しのみコピー
                        if (i > 0)
                        {
                            // 見出しコピー
                            CopyRow(outputSheet, ROW_COUNT_HEADER - 1, 1, copyIdx);
                            copyIdx += 1;
                        }

                        // 明細部は業者内のページ数分コピーする
                        if (i == 0)
                        {
                            CopyRow(outputSheet, ROW_COUNT_HEADER, ROW_COUNT_DETAIL, copyIdx);
                            copyIdx += ROW_COUNT_DETAIL;
                        }
                        else
                        {
                            CopyRow(outputSheet, ROW_COUNT_HEADER, ROW_COUNT_DETAIL, copyIdx);
                            copyIdx += ROW_COUNT_DETAIL;
                            // 2ページ目以降はヘッダが無い分、明細行数が増える
                            CopyRow(outputSheet, ROW_COUNT_HEADER, ROW_COUNT_DETAIL2 - ROW_COUNT_DETAIL, copyIdx);
                            copyIdx += ROW_COUNT_DETAIL2 - ROW_COUNT_DETAIL;
                        }

                        // 改ページ設定
                        SetPageBreak(outputSheet, copyIdx);
                    }
                }

                // 印刷範囲設定
                SetPrintArea(outputSheet, 0, 0, totalRowCnt - 1, 17);

                #endregion

                int pasteRow = 0;
                int gyoshaBeginIdx = 0;
                foreach (var gyoshaGroup in yoteiGyoshaGroups)
                {
                    pasteRow = gyoshaBeginIdx;
                    {
                        // ヘッダ部は、1行目を対象とする
                        var printRow = gyoshaGroup.ElementAt(0);

                        #region output header

                        //(1) 業者郵便番号
                        CellOutput(outputSheet, 1 + pasteRow, 1, printRow.GyoshaZipCd);

                        //(2) 業者住所
                        CellOutput(outputSheet, 2 + pasteRow, 0, printRow.GyoshaAdr);

                        //(3) 保守予定業者名称
                        CellOutput(outputSheet, 4 + pasteRow, 0, printRow.HoshugyoshaNm);

                        //(4) 保守予定業者コード
                        //MOD_20141031 Ver1.05 Start
                        //CellOutput(outputSheet, 5 + pasteRow, 7, printRow.KensaIraiHoshutenkenGyoshaCd);
                        CellOutput(outputSheet, 5 + pasteRow, 7, printRow.JokasoHoshuyoteiGyoshaCd);
                        //MOD_End

                        //MOD_Ver 1.03(038_保守点検予定一覧_帳票設計書) Start
                        //(5) 対象期間(開始)
                        //CellOutput(outputSheet, 7 + pasteRow, 2, Utility.DateUtility.ConvertToWareki(input.KensaIraiDtFrom.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));
                        CellOutput(outputSheet, 7 + pasteRow, 2, input.KensaIraiDtJokenTuikaFlg ? Utility.DateUtility.ConvertToWareki(input.KensaIraiDtFrom.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki) : string.Empty);

                        //(6) 対象期間(終了)
                        //CellOutput(outputSheet, 7 + pasteRow, 5, Utility.DateUtility.ConvertToWareki(input.KensaIraiDtTo.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));
                        CellOutput(outputSheet, 7 + pasteRow, 5, input.KensaIraiDtJokenTuikaFlg ? Utility.DateUtility.ConvertToWareki(input.KensaIraiDtTo.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki) : string.Empty);
                        //MOD_Ver 1.03 End

                        //(7) 出力行数
                        CellOutput(outputSheet, 7 + pasteRow, 14, gyoshaGroup.Count());

                        //(8) 出力日
                        CellOutput(outputSheet, 7 + pasteRow, 16, Utility.DateUtility.ConvertToWareki(currentDateTime.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

                        #endregion
                    }
                    pasteRow += ROW_COUNT_HEADER;

                    bool isNewPage = true;
                    string lastChikuNm = string.Empty;

                    // 地区名、設置者名でソート
                    // ページ切替を伴わないソートはここで実行する
                    var printRows = from yotei in gyoshaGroup
                                    orderby TypeUtility.GetString(yotei[input.Jo7KensaIraiListDataTable.ChikuNmColumn])
                                    orderby TypeUtility.GetString(yotei[input.Jo7KensaIraiListDataTable.KensaIraiSetchishaNmColumn])
                                    select yotei;

                    int pasteRowInPage = 0;
                    int idxPage = 0;
                    foreach (var printRow in printRows)
                    {
                        // 見出しの場合はスキップする
                        if ((idxPage == 0 && pasteRowInPage == ROW_COUNT_DETAIL)
                            || (idxPage > 0 && pasteRowInPage == ROW_COUNT_DETAIL2))
                        {
                            pasteRow++;
                            pasteRowInPage = 0;
                            idxPage++;
                        }

                        #region output detail

                        // 地区名称はページ先頭行、または地区名称切り替わり時のみ出力する
                        string chikuNm = TypeUtility.GetString(printRow[input.Jo7KensaIraiListDataTable.ChikuNmColumn]);

                        //(9) 地区名称
                        CellOutput(outputSheet, pasteRow, 0, (isNewPage || chikuNm != lastChikuNm ? TypeUtility.GetString(printRow[input.Jo7KensaIraiListDataTable.ChikuNmColumn]) : string.Empty));

                        //(10) 設置者名
                        CellOutput(outputSheet, pasteRow, 2, printRow.KensaIraiSetchishaNm);

                        //(11) 設置場所住所
                        CellOutput(outputSheet, pasteRow, 5, printRow.KensaIraiSetchibashoAdr);

                        // 20141218 habu column type changed
                        //(12) 人槽
                        CellOutput(outputSheet, pasteRow, 11, printRow.IsKensaIraiShoritaishoJininNull() ? "" : printRow.KensaIraiShoritaishoJinin + "人");
                        //CellOutput(outputSheet, pasteRow, 11, (string.IsNullOrEmpty(printRow.KensaIraiShoritaishoJinin)) ? "" : printRow.KensaIraiShoritaishoJinin + "人");

                        //(13) 処理方式
                        CellOutput(outputSheet, pasteRow, 12, printRow.Name);

                        //(14) 処理方式
                        CellOutput(outputSheet, pasteRow, 13, printRow.ShoriHoshikiNm);

                        //(15) 使用開始予定日
                        CellOutput(outputSheet, pasteRow, 14, Utility.DateUtility.ConvertToWareki(printRow.KensaIraiShiyoKaishiYM, "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki));

                        //(16) 保健所受理番号
                        CellOutput(outputSheet, pasteRow, 15, printRow.HokenjyoUketukeNo);

                        //(17) 工事業者名称
                        CellOutput(outputSheet, pasteRow, 16, printRow.KojigyoshaNm);

                        #endregion

                        isNewPage = false;
                        lastChikuNm = chikuNm;

                        pasteRow++;
                        pasteRowInPage++;
                    }

                    int gyoshaPageCnt = 0;
                    if (gyoshaGroup.Count() <= ROW_COUNT_DETAIL)
                    {
                        gyoshaPageCnt = 1;
                    }
                    // 2ページ目以降でページ数が異なるのを考慮
                    else
                    {
                        gyoshaPageCnt = 1 + (int)Math.Ceiling((decimal)(gyoshaGroup.Count() - ROW_COUNT_DETAIL) / ROW_COUNT_DETAIL2);
                    }
                    // 1行の見出し分を考慮
                    gyoshaBeginIdx += (ROW_COUNT_HEADER - 1) + gyoshaPageCnt * (ROW_COUNT_DETAIL2 + 1) - (ROW_COUNT_DETAIL2 - ROW_COUNT_DETAIL);
                }

                #region to be removed
                //KensaIraiTblDataSet.Jo7KensaIraiListRow[] listRowPrint = (KensaIraiTblDataSet.Jo7KensaIraiListRow[])input.Jo7KensaIraiListDataTable.Select("", "KensaIraiHoshutenkenGyoshaCd, ChikuNm, KensaIraiSetchishaNm");
                //KensaIraiTblDataSet.Jo7KensaIraiListRow[] listRowPrint = (KensaIraiTblDataSet.Jo7KensaIraiListRow[])input.Jo7KensaIraiListDataTable.Select("", "JokasoHoshuyoteiGyoshaCd, ChikuNm, KensaIraiSetchishaNm");

                //int pasteRow = PASTE_START_ROW_IDX;
                //int breakPage = 0;
                //int rowCountByHoshutenkenGyoshaCd = 0;
                //bool isNewPage = false;

                //for (int i = 0; i < listRowPrint.Length; i++)
                //{
                //    KensaIraiTblDataSet.Jo7KensaIraiListRow printRow = listRowPrint[i];

                //    #region output data to header

                //    isNewPage = false;
                //    //MOD_20141031 Ver1.05
                //    //if (i == 0 || printRow.KensaIraiHoshutenkenGyoshaCd != listRowPrint[i - 1].KensaIraiHoshutenkenGyoshaCd)
                //    if (i == 0 || printRow.JokasoHoshuyoteiGyoshaCd != listRowPrint[i - 1].JokasoHoshuyoteiGyoshaCd)
                //    {
                //        if (i > 0)
                //        {
                //            breakPage = pasteRow + 1;
                //            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[breakPage, 1]);
                //        }

                //        //copy header
                //        CopyRow(outputSheet, 0, ROW_COUNT_TITLE_COPY, pasteRow);

                //        //(1)
                //        CellOutput(outputSheet, 1 + pasteRow, 1, printRow.GyoshaZipCd);

                //        //(2)
                //        CellOutput(outputSheet, 2 + pasteRow, 0, printRow.GyoshaAdr);

                //        //(3)
                //        CellOutput(outputSheet, 4 + pasteRow, 0, printRow.HoshugyoshaNm);

                //        //(4)
                //        //MOD_20141031 Ver1.05 Start
                //        //CellOutput(outputSheet, 5 + pasteRow, 7, printRow.KensaIraiHoshutenkenGyoshaCd);
                //        CellOutput(outputSheet, 5 + pasteRow, 7, printRow.JokasoHoshuyoteiGyoshaCd);
                //        //MOD_End

                //        //MOD_Ver 1.03(038_保守点検予定一覧_帳票設計書) Start
                //        //(5)
                //        //CellOutput(outputSheet, 7 + pasteRow, 2, Utility.DateUtility.ConvertToWareki(input.KensaIraiDtFrom.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));
                //        CellOutput(outputSheet, 7 + pasteRow, 2, input.KensaIraiDtJokenTuikaFlg ? Utility.DateUtility.ConvertToWareki(input.KensaIraiDtFrom.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki) : string.Empty);

                //        //(6)
                //        //CellOutput(outputSheet, 7 + pasteRow, 5, Utility.DateUtility.ConvertToWareki(input.KensaIraiDtTo.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));
                //        CellOutput(outputSheet, 7 + pasteRow, 5, input.KensaIraiDtJokenTuikaFlg ? Utility.DateUtility.ConvertToWareki(input.KensaIraiDtTo.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki) : string.Empty);
                //        //MOD_Ver 1.03 End

                //        if (i > 0)
                //        {
                //            //(7)
                //            rowCountByHoshutenkenGyoshaCd = i - rowCountByHoshutenkenGyoshaCd;
                //            CellOutput(outputSheet, pasteRow - rowCountByHoshutenkenGyoshaCd - 2, 14, rowCountByHoshutenkenGyoshaCd);
                //            rowCountByHoshutenkenGyoshaCd = i;
                //        }

                //        //(8)
                //        CellOutput(outputSheet, 7 + pasteRow, 16, Utility.DateUtility.ConvertToWareki(currentDateTime.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

                //        pasteRow += ROW_COUNT_TITLE_COPY;
                //        isNewPage = true;
                //    }

                //    #endregion

                //    #region output content

                //    //copy row content
                //    CopyRow(outputSheet, ROW_CONTENT_COPY_IDX, 1, pasteRow);

                //    //(9)
                //    CellOutput(outputSheet, pasteRow, 0, (isNewPage || printRow.ChikuNm != listRowPrint[i - 1].ChikuNm) ? printRow.ChikuNm : string.Empty);

                //    //(10)
                //    CellOutput(outputSheet, pasteRow, 2, printRow.KensaIraiSetchishaNm);

                //    //(11)
                //    CellOutput(outputSheet, pasteRow, 5, printRow.KensaIraiSetchibashoAdr);

                //    //(12)
                //    CellOutput(outputSheet, pasteRow, 11, (string.IsNullOrEmpty(printRow.KensaIraiShoritaishoJinin)) ? "" : printRow.KensaIraiShoritaishoJinin + "人");

                //    //(13)
                //    CellOutput(outputSheet, pasteRow, 12, printRow.Name);

                //    //(14)
                //    CellOutput(outputSheet, pasteRow, 13, printRow.ShoriHoshikiNm);

                //    //(15)
                //    CellOutput(outputSheet, pasteRow, 14, Utility.DateUtility.ConvertToWareki(printRow.KensaIraiShiyoKaishiYM, "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki));

                //    //(16)
                //    CellOutput(outputSheet, pasteRow, 15, printRow.HokenjyoUketukeNo);

                //    //(17)
                //    CellOutput(outputSheet, pasteRow, 16, printRow.KojigyoshaNm);

                //    if (i == listRowPrint.Length - 1)
                //    {
                //        //(7)
                //        rowCountByHoshutenkenGyoshaCd = listRowPrint.Length - rowCountByHoshutenkenGyoshaCd;
                //        CellOutput(outputSheet, pasteRow - rowCountByHoshutenkenGyoshaCd - 1, 14, rowCountByHoshutenkenGyoshaCd);
                //    }

                //    pasteRow++;

                //    #endregion
                //}

                ////delete template row
                //DeleteRow(outputSheet, 0, ROW_COUNT_DELETE);
                #endregion
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

    }
    #endregion
}
