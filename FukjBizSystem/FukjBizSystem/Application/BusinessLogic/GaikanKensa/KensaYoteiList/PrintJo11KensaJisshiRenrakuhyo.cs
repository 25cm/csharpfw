using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaYoteiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJo11KensaJisshiRenrakuhyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJo11KensaJisshiRenrakuhyoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensaYoteiListDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaYoteiListDataTable KensaYoteiListDataTable { get; set; }

        /// <summary>
        /// KensaYoteiPrintCheck
        /// </summary>
        bool KensaYoteiPrintCheck { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJo11KensaJisshiRenrakuhyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo11KensaJisshiRenrakuhyoBLInput : BaseExcelPrintBLInputImpl, IPrintJo11KensaJisshiRenrakuhyoBLInput
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
        /// KensaYoteiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaYoteiListDataTable KensaYoteiListDataTable { get; set; }

        /// <summary>
        /// KensaYoteiPrintCheck
        /// </summary>
        public bool KensaYoteiPrintCheck { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJo11KensaJisshiRenrakuhyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJo11KensaJisshiRenrakuhyoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJo11KensaJisshiRenrakuhyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo11KensaJisshiRenrakuhyoBLOutput : BaseExcelPrintBLOutputImpl, IPrintJo11KensaJisshiRenrakuhyoBLOutput
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
    //  クラス名 ： PrintJo11KensaJisshiRenrakuhyoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo11KensaJisshiRenrakuhyoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJo11KensaJisshiRenrakuhyoBLInput, IPrintJo11KensaJisshiRenrakuhyoBLOutput>
    {
        #region プロパティ

        ///// <summary>
        ///// ROW_COPY_IDX 
        ///// </summary>
        //private const int ROW_CONTENT_COPY_IDX = 11;

        ///// <summary>
        ///// ROW_COUNT_TITLE_COPY 
        ///// </summary>
        //private const int ROW_COUNT_TITLE_COPY = 11;

        ///// <summary>
        ///// PASTE_START_ROW_IDX 
        ///// </summary>
        //private const int PASTE_START_ROW_IDX = 12;
        
        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_HEADER = 11;

        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_DETAIL = 40;

        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_DETAIL2 = 50;

        /// <summary>
        /// HEADER_TEXT
        /// </summary>
        private const string HEADER_TEXT = "11条検査実施連絡票 （{0}検査予定）";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintJo11KensaJisshiRenrakuhyoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJo11KensaJisshiRenrakuhyoBusinessLogic()
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
        /// 2014/09/10  HuyTX　　    新規作成
        /// 2014/12/15  habu　　    Modified page break
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJo11KensaJisshiRenrakuhyoBLOutput SetBook(IPrintJo11KensaJisshiRenrakuhyoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintJo11KensaJisshiRenrakuhyoBLOutput output = new PrintJo11KensaJisshiRenrakuhyoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                // 最初にLINQでグループ化、ソートし、出力する
                // ページ切替を伴うソートここで実行する
                var yoteiGyoshaGroups = from yotei in input.KensaYoteiListDataTable.AsEnumerable()
                                        group yotei by
                                            TypeUtility.GetString(yotei[input.KensaYoteiListDataTable.KensaIraiHoshutenkenGyoshaCdColumn])
                                            + TypeUtility.GetString(yotei[input.KensaYoteiListDataTable.KensaIraiKensaYoteiNenColumn])
                                            + TypeUtility.GetString(yotei[input.KensaYoteiListDataTable.KensaIraiKensaYoteiTsukiColumn])
                                            //20141219 HuyTX Del (Not group by KensaIraiKensaYoteiBi)
                                            //+ TypeUtility.GetString(yotei[input.KensaYoteiListDataTable.KensaIraiKensaYoteiBiColumn])
                                            //End
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
                if(yoteiGyoshaGroups.Count() > 0)
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
                SetPrintArea(outputSheet, 0, 0, totalRowCnt - 1, 6);

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

                        //(1)
                        CellOutput(outputSheet, 0 + pasteRow, 0, string.Format(HEADER_TEXT, Utility.DateUtility.ConvertToWareki(string.Concat(printRow.KensaIraiKensaYoteiNen, printRow.KensaIraiKensaYoteiTsuki), "yy年MM月")));

                        //(2)
                        CellOutput(outputSheet, 1 + pasteRow, 1, printRow.GyoshaNm);

                        //(3)
                        CellOutput(outputSheet, 2 + pasteRow, 4, printRow.ShishoAdr);

                        //(4)
                        CellOutput(outputSheet, 3 + pasteRow, 5, printRow.ShishoFaxNo);

                        //(5)
                        CellOutput(outputSheet, 4 + pasteRow, 5, printRow.ShishoTelNo);

                        //(6)
                        CellOutput(outputSheet, 9 + pasteRow, 5, printRow.ShokuinNm);

                        #endregion
                    }
                    pasteRow += ROW_COUNT_HEADER;

                    // 浄化槽キーでソート
                    // ページ切替を伴わないソートはここで実行する
                    var printRows = from yotei in gyoshaGroup
                                    orderby TypeUtility.GetString(yotei[input.KensaYoteiListDataTable.JokasoHokenjoCdColumn])
                                    orderby TypeUtility.GetString(yotei[input.KensaYoteiListDataTable.JokasoTorokuNendoColumn])
                                    orderby TypeUtility.GetString(yotei[input.KensaYoteiListDataTable.JokasoRenbanColumn])
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

                        //(7)
                        CellOutput(outputSheet, pasteRow, 1, printRow.KensaIraiSetchishaNm);

                        //(8)
                        CellOutput(outputSheet, pasteRow, 2, printRow.KensaIraiSetchibashoAdr);

                        // 20141218 type changed
                        //(9)
                        //20141219 Mod (check null value)
                        //CellOutput(outputSheet, pasteRow, 3, string.Format("{0}{1}{2}", printRow.ShoriHoshikiShubetsuNm, printRow.KensaIraiShoritaishoJinin, !printRow.IsKensaIraiShoritaishoJininNull() ? "人" : string.Empty));
                        CellOutput(outputSheet, pasteRow, 3, string.Format("{0}{1}", printRow.ShoriHoshikiShubetsuNm, !printRow.IsKensaIraiShoritaishoJininNull() ? (printRow.KensaIraiShoritaishoJinin + "人") : string.Empty));
                        //End
                        //CellOutput(outputSheet, pasteRow, 3, string.Format("{0}{1}{2}", printRow.ShoriHoshikiShubetsuNm, printRow.KensaIraiShoritaishoJinin, !string.IsNullOrEmpty(printRow.KensaIraiShoritaishoJinin) ? "人" : string.Empty));

                        //(11)
                        string kensaYoteiNenTsuki = string.Concat(printRow.KensaIraiKensaYoteiNen, printRow.KensaIraiKensaYoteiTsuki);
                        CellOutput(outputSheet, pasteRow, 5, (input.KensaYoteiPrintCheck && !string.IsNullOrEmpty(kensaYoteiNenTsuki)) ? Utility.DateUtility.ConvertToWareki(kensaYoteiNenTsuki, "yy/MM") + "/" + printRow.KensaIraiKensaYoteiBi : string.Empty);

                        #endregion

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
                //KensaIraiTblDataSet.KensaYoteiListRow[] listRowPrint = (KensaIraiTblDataSet.KensaYoteiListRow[])input.KensaYoteiListDataTable.Select("", "KensaIraiHoshutenkenGyoshaCd, KensaIraiKensaYoteiNen, KensaIraiKensaYoteiTsuki, KensaIraiKensaYoteiBi, JokasoHokenjoCd, JokasoTorokuNendo, JokasoRenban");

                //int pasteRow = PASTE_START_ROW_IDX;
                //string kensaYoteiNenTsuki = string.Empty;

                //for (int i = 0; i < listRowPrint.Length; i++)
                //{
                //    KensaIraiTblDataSet.KensaYoteiListRow printRow = listRowPrint[i];

                //    #region output data to header

                //    if (i == 0 
                //        || (printRow.KensaIraiHoshutenkenGyoshaCd != listRowPrint[i - 1].KensaIraiHoshutenkenGyoshaCd)
                //        || string.Concat(printRow.KensaIraiKensaYoteiNen, printRow.KensaIraiKensaYoteiTsuki) != string.Concat(listRowPrint[i - 1].KensaIraiKensaYoteiNen, listRowPrint[i - 1].KensaIraiKensaYoteiTsuki))
                //    {
                //        if (i > 0)
                //        {
                //            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[pasteRow + 1, 1]);
                //        }

                //        //copy header
                //        CopyRow(outputSheet, 0, ROW_COUNT_TITLE_COPY, pasteRow);

                //        //(1)
                //        CellOutput(outputSheet, 0 + pasteRow, 0, string.Format(HEADER_TEXT, Utility.DateUtility.ConvertToWareki(string.Concat(printRow.KensaIraiKensaYoteiNen, printRow.KensaIraiKensaYoteiTsuki), "yy年MM月")));

                //        //(2)
                //        CellOutput(outputSheet, 1 + pasteRow, 1, printRow.GyoshaNm);

                //        //(3)
                //        CellOutput(outputSheet, 2 + pasteRow, 4, printRow.ShishoAdr);

                //        //(4)
                //        CellOutput(outputSheet, 3 + pasteRow, 5, printRow.ShishoFaxNo);

                //        //(5)
                //        CellOutput(outputSheet, 4 + pasteRow, 5, printRow.ShishoTelNo);

                //        //(6)
                //        CellOutput(outputSheet, 9 + pasteRow, 5, printRow.ShokuinNm);

                //        pasteRow += ROW_COUNT_TITLE_COPY;
                //    }

                //    #endregion

                //    #region output content

                //    //copy row content
                //    CopyRow(outputSheet, ROW_CONTENT_COPY_IDX, 1, pasteRow);

                //    //(7)
                //    CellOutput(outputSheet, pasteRow, 1, printRow.KensaIraiSetchishaNm);

                //    //(8)
                //    CellOutput(outputSheet, pasteRow, 2, printRow.KensaIraiSetchibashoAdr);

                //    //(9)
                //    CellOutput(outputSheet, pasteRow, 3, string.Format("{0}{1}{2}", printRow.ShoriHoshikiShubetsuNm, printRow.KensaIraiShoritaishoJinin, !string.IsNullOrEmpty(printRow.KensaIraiShoritaishoJinin) ? "人" : string.Empty));

                //    //(11)
                //    kensaYoteiNenTsuki = string.Concat(printRow.KensaIraiKensaYoteiNen, printRow.KensaIraiKensaYoteiTsuki);
                //    CellOutput(outputSheet, pasteRow, 5, (input.KensaYoteiPrintCheck && !string.IsNullOrEmpty(kensaYoteiNenTsuki)) ? Utility.DateUtility.ConvertToWareki(kensaYoteiNenTsuki, "yy/MM") + "/" + printRow.KensaIraiKensaYoteiBi : string.Empty);

                //    pasteRow++;

                //    #endregion
                //}

                ////delete template row
                //DeleteRow(outputSheet, 0, PASTE_START_ROW_IDX);
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
