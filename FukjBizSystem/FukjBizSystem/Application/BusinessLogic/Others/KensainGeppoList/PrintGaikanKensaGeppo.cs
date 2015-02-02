using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensainGeppoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintGaikanKensaGeppoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintGaikanKensaGeppoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensainGeppoListDgv 
        /// </summary>
        DataGridView KensainGeppoListDgv { get; set; }

        /// <summary>
        /// TaisyoYMFrom
        /// </summary>
        string TaisyoYMFrom { get; set; }

        /// <summary>
        /// TaisyoYMTo
        /// </summary>
        string TaisyoYMTo { get; set; }

        /// <summary>
        /// ShishoCd
        /// </summary>
        string ShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintGaikanKensaGeppoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintGaikanKensaGeppoBLInput : BaseExcelPrintBLInputImpl, IPrintGaikanKensaGeppoBLInput
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
        /// KensainGeppoListDgv 
        /// </summary>
        public DataGridView KensainGeppoListDgv { get; set; }

        /// <summary>
        /// TaisyoYMFrom
        /// </summary>
        public string TaisyoYMFrom { get; set; }

        /// <summary>
        /// TaisyoYMTo
        /// </summary>
        public string TaisyoYMTo { get; set; }

        /// <summary>
        /// ShishoCd
        /// </summary>
        public string ShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintGaikanKensaGeppoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintGaikanKensaGeppoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintGaikanKensaGeppoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintGaikanKensaGeppoBLOutput : BaseExcelPrintBLOutputImpl, IPrintGaikanKensaGeppoBLOutput
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
    //  クラス名 ： PrintGaikanKensaGeppoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintGaikanKensaGeppoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintGaikanKensaGeppoBLInput, IPrintGaikanKensaGeppoBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// FIRST_ROW_COPY_IDX 
        /// </summary>
        private const int FIRST_ROW_COPY_IDX = 5;

        /// <summary>
        /// NEXT_ROW_COPY_IDX 
        /// </summary>
        private const int NEXT_ROW_COPY_IDX = 8;

        /// <summary>
        /// TOTAL_ROW_COPY_IDX 
        /// </summary>
        private const int TOTAL_ROW_COPY_IDX = 11;

        /// <summary>
        /// TOTAL_ALL_ROW_COPY_IDX 
        /// </summary>
        private const int TOTAL_ALL_ROW_COPY_IDX = 14;

        /// <summary>
        /// START_PASTE_ROW 
        /// </summary>
        private const int START_PASTE_ROW = 4;

        /// <summary>
        /// 
        /// </summary>
        private const int DETAIL_ROW_COUNT = 87;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintGaikanKensaGeppoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintGaikanKensaGeppoBusinessLogic()
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
        /// 2014/09/18  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintGaikanKensaGeppoBLOutput SetBook(IPrintGaikanKensaGeppoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintGaikanKensaGeppoBLOutput output = new PrintGaikanKensaGeppoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet templateSheet = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                templateSheet = GetSheetByName(book, "TemplateSheet");
                outputSheet = GetSheetByName(book, "OutputSheet");
                //templateSheet = (Worksheet)book.Sheets["TemplateSheet"];
                //outputSheet = (Worksheet)book.Sheets["OutputSheet"];
                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                #region output header

                //(1)
                CellOutput(outputSheet, 1, 1, string.Format("対象期間：{0}～{1}",
                    new string[]{Utility.DateUtility.ConvertToWareki(input.TaisyoYMFrom, "gyy年MM月分", Utility.DateUtility.GengoKbn.Wareki),
                                Utility.DateUtility.ConvertToWareki(input.TaisyoYMTo, "gyy年MM月分", Utility.DateUtility.GengoKbn.Wareki)
                                }));

                //(2)
                CellOutput(outputSheet, 1, 15, Utility.DateUtility.ConvertToWareki(currentDateTime.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

                #endregion

                int pasteRow = START_PASTE_ROW;
                List<int> listRow = new List<int>();
                List<int> listRowTotal = new List<int>();

                for (int i = 0; i < input.KensainGeppoListDgv.RowCount; i++)
                {
                    DataGridViewRow printRow = input.KensainGeppoListDgv.Rows[i];
                    DataGridViewRow nextRow = input.KensainGeppoListDgv.Rows[(i < input.KensainGeppoListDgv.RowCount - 1) ? (i + 1) : i];

                    #region output data

                    // 支所テンプレートコピー
                    if ((printRow.Cells["ShisyoCol"].Value != null && !string.IsNullOrEmpty(printRow.Cells["ShisyoCol"].Value.ToString())) || i == 0)
                    {
                        //copy first row
                        //RowCopy(templateSheet, outputSheet, FIRST_ROW_COPY_IDX, 2, pasteRow + 1, XlPasteType.xlPasteAll);
                        CopyRow(templateSheet, FIRST_ROW_COPY_IDX - 1, 3, outputSheet, pasteRow);

                        //支所名称 (3)
                        CellOutput(outputSheet, pasteRow, 1, printRow.Cells["ShisyoCol"].Value);
                        listRow = new List<int>();
                        listRow.Add(pasteRow + 1);
                    }
                    // 職員テンプレートコピー
                    else if (printRow.Cells["SyokuinCdCol"].Value != null && printRow.Cells["SyokuinCdCol"].Value.ToString() != "")
                    {
                        //copy next row
                        //RowCopy(templateSheet, outputSheet, NEXT_ROW_COPY_IDX, 2, pasteRow + 1, XlPasteType.xlPasteAll);
                        CopyRow(templateSheet, NEXT_ROW_COPY_IDX - 1, 3, outputSheet, pasteRow);

                        listRow.Add(pasteRow + 1);
                    }

                    //Output data
                    OutputData(outputSheet, printRow, pasteRow);

                    pasteRow++;

                    // 20141223 habu Add 最低限の改ページ処理を追加
                    if ((pasteRow - START_PASTE_ROW) % DETAIL_ROW_COUNT == 0)
                    {
                        SetPageBreak(outputSheet, pasteRow);
                    }

                    #endregion

                    #region output total

                    // 支所合計を出力
                    if (printRow.Cells["ShishoCdCol"].Value.ToString() != nextRow.Cells["ShishoCdCol"].Value.ToString()
                        || i == input.KensainGeppoListDgv.RowCount - 1)
                    {
                        //copy row total
                        //RowCopy(templateSheet, outputSheet, TOTAL_ROW_COPY_IDX, 2, pasteRow + 1, XlPasteType.xlPasteAll);
                        CopyRow(templateSheet, TOTAL_ROW_COPY_IDX - 1, 3, outputSheet, pasteRow);

                        listRowTotal.Add(pasteRow + 1);

                        //OutputTotalCol
                        OutputTotalCol(outputSheet, pasteRow, listRow);

                        pasteRow += 3;

                        // 20141223 habu Add 最低限の改ページ処理を追加
                        if ((pasteRow - START_PASTE_ROW) % DETAIL_ROW_COUNT == 0)
                        {
                            SetPageBreak(outputSheet, pasteRow);
                        }
                    }

                    // 総合計を出力
                    if (i == input.KensainGeppoListDgv.RowCount - 1)
                    {
                        //copy row total all
                        //RowCopy(templateSheet, outputSheet, TOTAL_ALL_ROW_COPY_IDX, 2, pasteRow + 1, XlPasteType.xlPasteAll);
                        CopyRow(templateSheet, TOTAL_ALL_ROW_COPY_IDX - 1, 3, outputSheet, pasteRow);

                        //OutputTotalCol
                        OutputTotalCol(outputSheet, pasteRow, listRowTotal);

                        pasteRow += 3;
                        //copy next row
                        //RowCopy(templateSheet, outputSheet, NEXT_ROW_COPY_IDX, 2, pasteRow + 1, XlPasteType.xlPasteAll);

                        // 20141222 habu Add SetPrintArea
                        SetPrintArea(outputSheet, 0, 0, pasteRow - 1, 17);
                    }

                    #endregion
                }

                //delete template sheet
                if (GetSheetCount(book) > 1)
                //if (book.Sheets.Count > 1)
                {
                    templateSheet.Delete();
                }

                //set selected first cell
                SelectCell(outputSheet, 1, 1);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (templateSheet != null) { Marshal.ReleaseComObject(templateSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region OutputData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printRow"></param>
        /// <param name="rowIdx"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputData(Worksheet outputSheet, DataGridViewRow printRow, int rowIdx)
        {
            if (printRow.Cells["KensainNmCol"].Value != null && printRow.Cells["KensainNmCol"].Value.ToString() != "")
            {
                ////職員名 (4)
                CellOutput(outputSheet, rowIdx, 2, printRow.Cells["KensainNmCol"].Value);
            }

            //7条件数, 11条件数 (5),(6), (7)
            CellOutput(outputSheet, rowIdx, 3, printRow.Cells["Month4Col"].Value);
            CellOutput(outputSheet, rowIdx, 4, printRow.Cells["Month5Col"].Value);
            CellOutput(outputSheet, rowIdx, 5, printRow.Cells["Month6Col"].Value);
            CellOutput(outputSheet, rowIdx, 6, printRow.Cells["Month7Col"].Value);
            CellOutput(outputSheet, rowIdx, 7, printRow.Cells["Month8Col"].Value);
            CellOutput(outputSheet, rowIdx, 8, printRow.Cells["Month9Col"].Value);
            CellOutput(outputSheet, rowIdx, 9, printRow.Cells["Month10Col"].Value);
            CellOutput(outputSheet, rowIdx, 10, printRow.Cells["Month11Col"].Value);
            CellOutput(outputSheet, rowIdx, 11, printRow.Cells["Month12Col"].Value);
            CellOutput(outputSheet, rowIdx, 12, printRow.Cells["Month1Col"].Value);
            CellOutput(outputSheet, rowIdx, 13, printRow.Cells["Month2Col"].Value);
            CellOutput(outputSheet, rowIdx, 14, printRow.Cells["Month3Col"].Value);
            CellOutput(outputSheet, rowIdx, 15, printRow.Cells["TotalCol"].Value);
            CellOutput(outputSheet, rowIdx, 16, printRow.Cells["KingakuCol"].Value);
        }
        #endregion

        #region OutputTotalCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputTotalCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="outputRow"></param>
        /// <param name="listRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputTotalCol(Worksheet outputSheet, int outputRow, List<int> listRow)
        {
            #region total Kensa7JoCnt

            CellOutput(outputSheet, outputRow, 3, MakeSum7JoCntCol("D", listRow));
            CellOutput(outputSheet, outputRow, 4, MakeSum7JoCntCol("E", listRow));
            CellOutput(outputSheet, outputRow, 5, MakeSum7JoCntCol("F", listRow));
            CellOutput(outputSheet, outputRow, 6, MakeSum7JoCntCol("G", listRow));
            CellOutput(outputSheet, outputRow, 7, MakeSum7JoCntCol("H", listRow));
            CellOutput(outputSheet, outputRow, 8, MakeSum7JoCntCol("I", listRow));
            CellOutput(outputSheet, outputRow, 9, MakeSum7JoCntCol("J", listRow));
            CellOutput(outputSheet, outputRow, 10, MakeSum7JoCntCol("K", listRow));
            CellOutput(outputSheet, outputRow, 11, MakeSum7JoCntCol("L", listRow));
            CellOutput(outputSheet, outputRow, 12, MakeSum7JoCntCol("M", listRow));
            CellOutput(outputSheet, outputRow, 13, MakeSum7JoCntCol("N", listRow));
            CellOutput(outputSheet, outputRow, 14, MakeSum7JoCntCol("O", listRow));
            CellOutput(outputSheet, outputRow, 15, MakeSum7JoCntCol("P", listRow));
            CellOutput(outputSheet, outputRow, 16, MakeSum7JoCntCol("Q", listRow));

            #endregion

            #region total Kensa11JoCnt

            CellOutput(outputSheet, outputRow + 1, 3, MakeSum11JoCntCol("D", listRow));
            CellOutput(outputSheet, outputRow + 1, 4, MakeSum11JoCntCol("E", listRow));
            CellOutput(outputSheet, outputRow + 1, 5, MakeSum11JoCntCol("F", listRow));
            CellOutput(outputSheet, outputRow + 1, 6, MakeSum11JoCntCol("G", listRow));
            CellOutput(outputSheet, outputRow + 1, 7, MakeSum11JoCntCol("H", listRow));
            CellOutput(outputSheet, outputRow + 1, 8, MakeSum11JoCntCol("I", listRow));
            CellOutput(outputSheet, outputRow + 1, 9, MakeSum11JoCntCol("J", listRow));
            CellOutput(outputSheet, outputRow + 1, 10, MakeSum11JoCntCol("K", listRow));
            CellOutput(outputSheet, outputRow + 1, 11, MakeSum11JoCntCol("L", listRow));
            CellOutput(outputSheet, outputRow + 1, 12, MakeSum11JoCntCol("M", listRow));
            CellOutput(outputSheet, outputRow + 1, 13, MakeSum11JoCntCol("N", listRow));
            CellOutput(outputSheet, outputRow + 1, 14, MakeSum11JoCntCol("O", listRow));
            CellOutput(outputSheet, outputRow + 1, 15, MakeSum11JoCntCol("P", listRow));
            CellOutput(outputSheet, outputRow + 1, 16, MakeSum11JoCntCol("Q", listRow));

            #endregion

            #region total Kensa7JoCnt + Kensa7JoCnt

            CellOutput(outputSheet, outputRow + 2, 3, MakeSumTotalCol("D", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 4, MakeSumTotalCol("E", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 5, MakeSumTotalCol("F", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 6, MakeSumTotalCol("G", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 7, MakeSumTotalCol("H", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 8, MakeSumTotalCol("I", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 9, MakeSumTotalCol("J", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 10, MakeSumTotalCol("K", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 11, MakeSumTotalCol("L", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 12, MakeSumTotalCol("M", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 13, MakeSumTotalCol("N", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 14, MakeSumTotalCol("O", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 15, MakeSumTotalCol("P", outputRow + 2));
            CellOutput(outputSheet, outputRow + 2, 16, MakeSumTotalCol("Q", outputRow + 2));

            #endregion
        }
        #endregion

        #region MakeSum7JoCntCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSum7JoCntCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="listRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string MakeSum7JoCntCol(string colName, List<int> listRow)
        {
            string strSum = string.Empty;
            foreach (int row in listRow)
            {
                strSum += string.Concat(colName, row, ", ");
            }

            if (!string.IsNullOrEmpty(strSum))
            {
                strSum.Remove(strSum.Length - 2, 2);
                strSum = string.Concat("SUM(", strSum, ")");
            }

            return string.Format("=IF({0}=0,\"\", {0})", strSum);
        }
        #endregion

        #region MakeSum11JoCntCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSum11JoCntCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="listRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string MakeSum11JoCntCol(string colName, List<int> listRow)
        {
            string strSum = string.Empty;
            foreach (int row in listRow)
            {
                strSum += string.Concat(colName, row + 1, ", ");
            }

            if (!string.IsNullOrEmpty(strSum))
            {
                strSum.Remove(strSum.Length - 2, 2);
                strSum = string.Concat("SUM(", strSum, ")");
            }

            return string.Format("=IF({0}=0,\"\", {0})", strSum);
        }
        #endregion

        #region MakeSumTotalCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSumTotalCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="outputRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string MakeSumTotalCol(string colName, int outputRow)
        {
            return string.Format("=IF(SUM({0}{1}, {0}{2})=0, \"\", SUM({0}{1}, {0}{2}))", colName, outputRow - 1, outputRow);
        }
        #endregion

        #endregion

    }
    #endregion
}
