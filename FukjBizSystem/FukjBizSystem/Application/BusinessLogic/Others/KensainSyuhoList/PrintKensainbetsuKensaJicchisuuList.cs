using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.Boundary.Others;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensainSyuhoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensainbetsuKensaJicchisuuListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensainbetsuKensaJicchisuuListBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// WeekList
        /// </summary>
        List<string> WeekList { get; set; }

        /// <summary>
        /// KensainSyuhoListDT
        /// </summary>
        KensainSyuhoListDataSet.KensainSyuhoListDataTable KensainSyuhoListDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainbetsuKensaJicchisuuListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainbetsuKensaJicchisuuListBLInput : BaseExcelPrintBLInputImpl, IPrintKensainbetsuKensaJicchisuuListBLInput
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
        /// WeekList
        /// </summary>
        public List<string> WeekList { get; set; }

        /// <summary>
        /// KensainSyuhoListDT
        /// </summary>
        public KensainSyuhoListDataSet.KensainSyuhoListDataTable KensainSyuhoListDT { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensainbetsuKensaJicchisuuListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensainbetsuKensaJicchisuuListBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainbetsuKensaJicchisuuListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainbetsuKensaJicchisuuListBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensainbetsuKensaJicchisuuListBLOutput
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
    //  クラス名 ： PrintKensainbetsuKensaJicchisuuListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainbetsuKensaJicchisuuListBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensainbetsuKensaJicchisuuListBLInput, IPrintKensainbetsuKensaJicchisuuListBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// ROW_OUTPUT_COPY
        /// </summary>
        private const int ROW_OUTPUT_COPY = 5;

        /// <summary>
        /// ROW_TOTAL_COPY
        /// </summary>
        private const int ROW_TOTAL_COPY = 10;

        /// <summary>
        /// ROW_TOTAL_ALL_COPY
        /// </summary>
        private const int ROW_TOTAL_ALL_COPY = 11;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensainbetsuKensaJicchisuuListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensainbetsuKensaJicchisuuListBusinessLogic()
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
        /// 2014/09/03  HuyTX　　    新規作成
        /// 2014/10/08  HuyTX　　    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensainbetsuKensaJicchisuuListBLOutput SetBook(IPrintKensainbetsuKensaJicchisuuListBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensainbetsuKensaJicchisuuListBLOutput output = new PrintKensainbetsuKensaJicchisuuListBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;
            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                tempSheet = (Worksheet)book.Sheets["TemplateSheet"];
                outputSheet = (Worksheet)book.Sheets["検査員別検査実施数一覧"];

                //DateTime startDate = DateTime.ParseExact(input.WeekList[0], "yyyyMMdd", CultureInfo.InvariantCulture);
                //DateTime toDate = DateTime.ParseExact(input.WeekList[1], "yyyyMMdd", CultureInfo.InvariantCulture);
                string startDate = input.WeekList[0];
                string toDate = input.WeekList[1];

                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
                int startRowSum = 0;
                int toRowSum = 0;
                int pasteRow = 5;
                bool isOutputShisho = true;
                List<string> listRow = new List<string>();
                Dictionary<string, float> avgByShisho = new Dictionary<string, float>();
                avgByShisho.Add("listWeek", 0);
                avgByShisho.Add("listTotal", 0);
                avgByShisho.Add("listWeekAll", 0);
                avgByShisho.Add("listTotalAll", 0);

                #region output header

                //(1)
                CellOutput(outputSheet, 1, 1, string.Format("対象期間：{0}～{1}",
                    new string[] { Utility.DateUtility.ConvertToWareki(startDate, "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki),
                                   Utility.DateUtility.ConvertToWareki(toDate, "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki)
                                }));

                //システム日付 (2)
                CellOutput(outputSheet, 1, 22, Utility.DateUtility.ConvertToWareki(currentDateTime.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

                // (3) ~ (8)
                CellOutput(outputSheet, 2, 3, input.WeekList[2]);
                CellOutput(outputSheet, 2, 6, input.WeekList[3]);
                CellOutput(outputSheet, 2, 9, input.WeekList[4]);
                CellOutput(outputSheet, 2, 12, input.WeekList[5]);
                CellOutput(outputSheet, 2, 15, input.WeekList[6]);
                CellOutput(outputSheet, 2, 18, input.WeekList[7]);

                #endregion

                #region output content

                for (int i = 0; i < input.KensainSyuhoListDT.Count; i++)
                {
                    KensainSyuhoListDataSet.KensainSyuhoListRow printRow = input.KensainSyuhoListDT[i];

                    if (i != 0 && printRow.ShishoCd != input.KensainSyuhoListDT[i - 1].ShishoCd)
                    {
                        isOutputShisho = true;
                        toRowSum = pasteRow - 1;

                        //copy row total
                        //RowCopy(tempSheet, outputSheet, ROW_TOTAL_COPY, 0, pasteRow, XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, ROW_TOTAL_COPY - 1, 1, outputSheet, pasteRow - 1);

                        //make formula row total
                        MakeSumCol(outputSheet, pasteRow - 1, startRowSum, toRowSum, avgByShisho);
                        listRow.Add(pasteRow.ToString());
                        avgByShisho["listWeekAll"] = avgByShisho["listWeekAll"] + avgByShisho["listWeek"];
                        avgByShisho["listTotalAll"] = avgByShisho["listTotalAll"] + avgByShisho["listTotal"];

                        pasteRow++;
                    }

                    //RowCopy(tempSheet, outputSheet, ROW_OUTPUT_COPY, 0, pasteRow, XlPasteType.xlPasteAll);
                    CopyRow(tempSheet, ROW_OUTPUT_COPY - 1, 1, outputSheet, pasteRow - 1);

                    if (isOutputShisho)
                    {
                        startRowSum = pasteRow;
                        avgByShisho["listWeek"] = 0;
                        avgByShisho["listTotal"] = 0;
                    }

                    //output data
                    avgByShisho = OutputData(outputSheet, pasteRow - 1, printRow, isOutputShisho, avgByShisho);

                    isOutputShisho = false;
                    pasteRow++;

                    if (i == input.KensainSyuhoListDT.Count - 1)
                    {
                        //copy row total 
                        //RowCopy(tempSheet, outputSheet, ROW_TOTAL_COPY, 0, pasteRow, XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, ROW_TOTAL_COPY - 1, 1, outputSheet, pasteRow - 1);

                        //make formula row total
                        MakeSumCol(outputSheet, pasteRow - 1, startRowSum, pasteRow - 1, avgByShisho);
                        listRow.Add(pasteRow.ToString());
                        avgByShisho["listWeekAll"] = avgByShisho["listWeekAll"] + avgByShisho["listWeek"];
                        avgByShisho["listTotalAll"] = avgByShisho["listTotalAll"] + avgByShisho["listTotal"];

                        pasteRow++;

                        //copy row total all
                        //RowCopy(tempSheet, outputSheet, ROW_TOTAL_ALL_COPY, 0, pasteRow, XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, ROW_TOTAL_ALL_COPY - 1, 1, outputSheet, pasteRow - 1);

                        if (listRow.Count > 0)
                        {
                            //make formula row total all
                            MakeSumTotalCol(outputSheet, pasteRow - 1, listRow, avgByShisho);
                        }
                        pasteRow++;
                        //RowCopy(tempSheet, outputSheet, ROW_OUTPUT_COPY, 4, pasteRow, XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, ROW_OUTPUT_COPY - 1, 4, outputSheet, pasteRow - 1);

                        outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[pasteRow + 5, 1]);
                        outputSheet.VPageBreaks.Add(outputSheet.Range["AA6"]);
                    }
                }

                #endregion

                if (book.Sheets.Count > 1)
                {
                    tempSheet.Delete();
                }

                SelectCell(outputSheet, 1, 1);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region MakeSumCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSumCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="outputRow"></param>
        /// <param name="startRow"></param>
        /// <param name="toRow"></param>
        /// <param name="avgByShisho"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSumCol(Worksheet outputSheet, int outputRow, int startRow, int toRow, Dictionary<string, float> avgByShisho)
        {
            CellOutput(outputSheet, outputRow, 3, string.Format("=SUM(D{0}:D{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 4, string.Format("=SUM(E{0}:E{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 5, string.Format("=SUM(F{0}:F{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 6, string.Format("=SUM(G{0}:G{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 7, string.Format("=SUM(H{0}:H{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 8, string.Format("=SUM(I{0}:I{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 9, string.Format("=SUM(J{0}:J{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 10, string.Format("=SUM(K{0}:K{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 11, string.Format("=SUM(L{0}:L{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 12, string.Format("=SUM(M{0}:M{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 13, string.Format("=SUM(N{0}:N{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 14, string.Format("=SUM(O{0}:O{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 15, string.Format("=SUM(P{0}:P{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 16, string.Format("=SUM(Q{0}:Q{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 17, string.Format("=SUM(R{0}:R{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 18, string.Format("=SUM(S{0}:S{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 19, string.Format("=SUM(T{0}:T{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 20, string.Format("=SUM(U{0}:U{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 21, string.Format("=SUM(V{0}:V{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 22, string.Format("=SUM(W{0}:W{1})", startRow, toRow));
            CellOutput(outputSheet, outputRow, 23, string.Format("=SUM(X{0}:X{1})", startRow, toRow));
            //CellOutput(outputSheet, outputRow, 24, string.Format("=IF(SUM(Y{0}:Y{1})=0,0,AVERAGE(Y{0}:Y{1}))", startRow, toRow));
            CellOutput(outputSheet, outputRow, 24, (avgByShisho["listWeek"] != 0) ? (avgByShisho["listTotal"] / avgByShisho["listWeek"]) : 0);
        }
        #endregion

        #region MakeSumTotalCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSumTotalCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="outputRow"></param>
        /// <param name="listRow"></param>
        /// <param name="avgByShisho"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSumTotalCol(Worksheet outputSheet, int outputRow, List<string> listRow, Dictionary<string, float> avgByShisho)
        {
            CellOutput(outputSheet, outputRow, 3, GetSumToltalCol("D", listRow));
            CellOutput(outputSheet, outputRow, 4, GetSumToltalCol("E", listRow));
            CellOutput(outputSheet, outputRow, 5, GetSumToltalCol("F", listRow));
            CellOutput(outputSheet, outputRow, 6, GetSumToltalCol("G", listRow));
            CellOutput(outputSheet, outputRow, 7, GetSumToltalCol("H", listRow));
            CellOutput(outputSheet, outputRow, 8, GetSumToltalCol("I", listRow));
            CellOutput(outputSheet, outputRow, 9, GetSumToltalCol("J", listRow));
            CellOutput(outputSheet, outputRow, 10, GetSumToltalCol("K", listRow));
            CellOutput(outputSheet, outputRow, 11, GetSumToltalCol("L", listRow));
            CellOutput(outputSheet, outputRow, 12, GetSumToltalCol("M", listRow));
            CellOutput(outputSheet, outputRow, 13, GetSumToltalCol("N", listRow));
            CellOutput(outputSheet, outputRow, 14, GetSumToltalCol("O", listRow));
            CellOutput(outputSheet, outputRow, 15, GetSumToltalCol("P", listRow));
            CellOutput(outputSheet, outputRow, 16, GetSumToltalCol("Q", listRow));
            CellOutput(outputSheet, outputRow, 17, GetSumToltalCol("R", listRow));
            CellOutput(outputSheet, outputRow, 18, GetSumToltalCol("S", listRow));
            CellOutput(outputSheet, outputRow, 19, GetSumToltalCol("T", listRow));
            CellOutput(outputSheet, outputRow, 20, GetSumToltalCol("U", listRow));
            CellOutput(outputSheet, outputRow, 21, GetSumToltalCol("V", listRow));
            CellOutput(outputSheet, outputRow, 22, GetSumToltalCol("W", listRow));
            CellOutput(outputSheet, outputRow, 23, GetSumToltalCol("X", listRow));
            //CellOutput(outputSheet, outputRow, 24, GetAvgToltalCol("Y", listRow));
            CellOutput(outputSheet, outputRow, 24, (avgByShisho["listWeekAll"] != 0) ? string.Format("{0:F1}", (avgByShisho["listTotalAll"] / avgByShisho["listWeekAll"])) : "0");
        }
        #endregion

        #region GetSumToltalByCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSumToltalCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="listRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetSumToltalCol(string colName, List<string> listRow)
        {
            string strSum = string.Empty;
            foreach (string row in listRow)
            {
                strSum += string.Concat(colName, row, ", ");
            }

            if (!string.IsNullOrEmpty(strSum))
            {
                strSum.Remove(strSum.Length - 2, 2);
                strSum = string.Concat("=SUM(", strSum, ")");
            }

            return strSum;
        }
        #endregion

        #region GetAvgToltalCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetAvgToltalCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="listRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetAvgToltalCol(string colName, List<string> listRow)
        {
            string strAvg = string.Empty;
            foreach (string row in listRow)
            {
                strAvg += string.Concat(colName, row, ", ");
            }

            if (!string.IsNullOrEmpty(strAvg))
            {
                strAvg.Remove(strAvg.Length - 2, 2);
                strAvg = string.Concat("=AVERAGE(", strAvg, ")");
            }

            return strAvg;
        }
        #endregion

        #region OutputData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="outputRow"></param>
        /// <param name="printRow"></param>
        /// <param name="isOutputShisho"></param>
        /// <param name="avgByShisho"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private Dictionary<string, float> OutputData(Worksheet outputSheet, int outputRow, KensainSyuhoListDataSet.KensainSyuhoListRow printRow, bool isOutputShisho, Dictionary<string, float> avgByShisho)
        {
            CellOutput(outputSheet, outputRow, 1, (!isOutputShisho) ? "" : printRow.ShisyoCol);
            CellOutput(outputSheet, outputRow, 2, printRow.KensainNmCol);
            CellOutput(outputSheet, outputRow, 3, printRow.Week1_7JoCol);
            CellOutput(outputSheet, outputRow, 4, printRow.Week1_11JoCol);
            CellOutput(outputSheet, outputRow, 5, printRow.Week1_TotalCol);
            avgByShisho["listWeek"] = !string.IsNullOrEmpty(printRow.Week1_TotalCol) ? avgByShisho["listWeek"] += 1 : avgByShisho["listWeek"];

            CellOutput(outputSheet, outputRow, 6, printRow.Week2_7JoCol);
            CellOutput(outputSheet, outputRow, 7, printRow.Week2_11JoCol);
            CellOutput(outputSheet, outputRow, 8, printRow.Week2_TotalCol);
            avgByShisho["listWeek"] = !string.IsNullOrEmpty(printRow.Week2_TotalCol) ? avgByShisho["listWeek"] += 1 : avgByShisho["listWeek"];

            CellOutput(outputSheet, outputRow, 9, printRow.Week3_7JoCol);
            CellOutput(outputSheet, outputRow, 10, printRow.Week3_11JoCol);
            CellOutput(outputSheet, outputRow, 11, printRow.Week3_TotalCol);
            avgByShisho["listWeek"] = !string.IsNullOrEmpty(printRow.Week3_TotalCol) ? avgByShisho["listWeek"] += 1 : avgByShisho["listWeek"];

            CellOutput(outputSheet, outputRow, 12, printRow.Week4_7JoCol);
            CellOutput(outputSheet, outputRow, 13, printRow.Week4_11JoCol);
            CellOutput(outputSheet, outputRow, 14, printRow.Week4_TotalCol);
            avgByShisho["listWeek"] = !string.IsNullOrEmpty(printRow.Week4_TotalCol) ? avgByShisho["listWeek"] += 1 : avgByShisho["listWeek"];

            CellOutput(outputSheet, outputRow, 15, printRow.Week5_7JoCol);
            CellOutput(outputSheet, outputRow, 16, printRow.Week5_11JoCol);
            CellOutput(outputSheet, outputRow, 17, printRow.Week5_TotalCol);
            avgByShisho["listWeek"] = !string.IsNullOrEmpty(printRow.Week5_TotalCol) ? avgByShisho["listWeek"] += 1 : avgByShisho["listWeek"];

            CellOutput(outputSheet, outputRow, 18, printRow.Week6_7JoCol);
            CellOutput(outputSheet, outputRow, 19, printRow.Week6_11JoCol);
            CellOutput(outputSheet, outputRow, 20, printRow.Week6_TotalCol);
            avgByShisho["listWeek"] = !string.IsNullOrEmpty(printRow.Week6_TotalCol) ? avgByShisho["listWeek"] += 1 : avgByShisho["listWeek"];

            CellOutput(outputSheet, outputRow, 21, printRow.Gokei_7JoCol);
            CellOutput(outputSheet, outputRow, 22, printRow.Gokei_11JoCol);
            CellOutput(outputSheet, outputRow, 23, printRow.Gokei_TotalCol);
            avgByShisho["listTotal"] = !string.IsNullOrEmpty(printRow.Gokei_TotalCol) ? (avgByShisho["listTotal"] + Int32.Parse(printRow.Gokei_TotalCol)) : avgByShisho["listTotal"];
            CellOutput(outputSheet, outputRow, 24, printRow.AveCol);

            return avgByShisho;
        }
        #endregion

        #endregion

    }
    #endregion
}
