using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.NyukinTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintNyukinUchiwakeBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintNyukinUchiwakeBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 入金日検索使用フラグ
        /// </summary>
        bool IsNyukinDtUse { get; set; }

        /// <summary>
        /// 入金No(s)
        /// </summary>
        List<string> NyukinNoList { get; set; }

        /// <summary>
        /// 入金日（開始）
        /// </summary>
        DateTime NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日（終了）
        /// </summary>
        DateTime NyukinDtTo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintNyukinUchiwakeBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintNyukinUchiwakeBLInput : BaseExcelPrintBLInputImpl, IPrintNyukinUchiwakeBLInput
    {
        /// <summary>
        /// 入金日検索使用フラグ
        /// </summary>
        public bool IsNyukinDtUse { get; set; }

        /// <summary>
        /// 入金No(s)
        /// </summary>
        public List<string> NyukinNoList { get; set; }

        /// <summary>
        /// 入金日（開始）
        /// </summary>
        public DateTime NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日（終了）
        /// </summary>
        public DateTime NyukinDtTo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintNyukinUchiwakeBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintNyukinUchiwakeBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintNyukinUchiwakeBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintNyukinUchiwakeBLOutput : BaseExcelPrintBLOutputImpl, IPrintNyukinUchiwakeBLOutput
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
    //  クラス名 ： PrintNyukinUchiwakeBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintNyukinUchiwakeBusinessLogic : BaseExcelPrintBusinessLogic<IPrintNyukinUchiwakeBLInput, IPrintNyukinUchiwakeBLOutput>
    {
        #region 定義

        /// <summary>
        /// 日     計
        /// </summary>
        private const string NYUKIN_TOTAL_TEXT = "★日     計★";

        /// <summary>
        /// 支 所 計
        /// </summary>
        private const string SHISHO_TOTAL_TEXT = "★支 所 計★";

        /// <summary>
        /// 総 合 計
        /// </summary>
        private const string FINAL_TOTAL_TEXT = "★総 合 計★";

        /// <summary>
        /// Sorting text
        /// </summary>
        private const string NYUKIN_DT_SORT = "NyukinDt asc";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintNyukinUchiwakeBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintNyukinUchiwakeBusinessLogic()
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
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintNyukinUchiwakeBLOutput SetBook(IPrintNyukinUchiwakeBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintNyukinUchiwakeBLOutput output = new PrintNyukinUchiwakeBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Copy a new sheet
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                tempSheet.Copy(tempSheet, Type.Missing);

                // Set output sheet to current active sheet
                outputSheet = (Worksheet)book.ActiveSheet;
                outputSheet.Name = "入金内訳書";

                #region variables definition

                // Sum by shisho or not?
                bool isSumShisho = false;
                // Separate by shishoNm
                string tempShishoCd = string.Empty;
                // Separate by NyukinDt
                string tempNyukinDt = string.Empty;
                // Current processing row
                int curRow = 3;
                // 入金割振金額/実入金額(8) - Sum by NyukinDt
                decimal nyukinTotal8 = 0;
                // 入金割振金額/実入金額(9) - Sum by NyukinDt
                decimal nyukinTotal9 = 0;
                // 入金割振金額/実入金額(10) - Sum by NyukinDt
                decimal nyukinTotal10 = 0;
                // 入金割振金額/実入金額(11) - Sum by NyukinDt
                decimal nyukinTotal11 = 0;
                // 入金割振金額/実入金額(8) - sum by ShishoNm
                decimal shishoTotal8 = 0;
                // 入金割振金額/実入金額(9) - sum by ShishoNm
                decimal shishoTotal9 = 0;
                // 入金割振金額/実入金額(10) - sum by ShishoNm
                decimal shishoTotal10 = 0;
                // 入金割振金額/実入金額(11) - sum by ShishoNm
                decimal shishoTotal11 = 0;
                // 入金割振金額/実入金額(8) - final sum
                decimal finalTotal8 = 0;
                // 入金割振金額/実入金額(9) - final sum
                decimal finalTotal9 = 0;
                // 入金割振金額/実入金額(10) - final sum
                decimal finalTotal10 = 0;
                // 入金割振金額/実入金額(11) - final sum
                decimal finalTotal11 = 0;

                #endregion

                // Preparing data
                NyukinTblDataSet.NyukinUchiwakeDataTable printTable = MakePrintTable(input.NyukinNoList);

                // Header
                SetHeader(outputSheet, input);

                foreach (NyukinTblDataSet.NyukinUchiwakeRow row in printTable.Select(string.Empty, "NyukinShisyoCd, NyukinDt"))
                {
                    if (tempShishoCd != row.NyukinShisyoCd)
                    {
                        // 支所名称(3)
                        CellOutput(outputSheet, curRow, 1, row.ShishoNm);

                        foreach (NyukinTblDataSet.NyukinUchiwakeRow nyukinRow in
                            printTable.Select(string.Format("NyukinShisyoCd = '{0}'", row.NyukinShisyoCd), "NyukinDt asc"))
                        {
                            if (tempNyukinDt != nyukinRow.NyukinDt)
                            {
                                // Write nyukin total
                                if (curRow > 3 && !isSumShisho)
                                {
                                    // 1 row padding
                                    //curRow += 2;

                                    // ★日     計★ (sum by NyukinDt)
                                    MakeSumRow(outputSheet, curRow + 1, nyukinTotal8, nyukinTotal9, nyukinTotal10, nyukinTotal11, NYUKIN_TOTAL_TEXT);

                                    // Reset nyukin total
                                    nyukinTotal8 = 0;
                                    nyukinTotal9 = 0;
                                    nyukinTotal10 = 0;
                                    nyukinTotal11 = 0;

                                    // 1 row padding
                                    curRow += 3;
                                }

                                // 入金日(4)
                                CellOutput(outputSheet, curRow, 5, nyukinRow.NyukinDt);
                            }

                            // Detail row
                            SetDetail(outputSheet, nyukinRow, curRow);

                            // Set Nyukin total
                            nyukinTotal8 += nyukinRow.IsNyukinGakuNull() ? 0 : nyukinRow.NyukinGaku;
                            nyukinTotal9 += nyukinRow.IsNyukinGaku001Null() ? 0 : nyukinRow.NyukinGaku001;
                            nyukinTotal10 += nyukinRow.IsNyukinGaku002Null() ? 0 : nyukinRow.NyukinGaku002;
                            nyukinTotal11 += nyukinRow.IsNyukinGaku003Null() ? 0 : nyukinRow.NyukinGaku003;

                            // Set Shisho total
                            shishoTotal8 += nyukinRow.IsNyukinGakuNull() ? 0 : nyukinRow.NyukinGaku;
                            shishoTotal9 += nyukinRow.IsNyukinGaku001Null() ? 0 : nyukinRow.NyukinGaku001;
                            shishoTotal10 += nyukinRow.IsNyukinGaku002Null() ? 0 : nyukinRow.NyukinGaku002;
                            shishoTotal11 += nyukinRow.IsNyukinGaku003Null() ? 0 : nyukinRow.NyukinGaku003;

                            // Final total
                            finalTotal8 += nyukinRow.IsNyukinGakuNull() ? 0 : nyukinRow.NyukinGaku;
                            finalTotal9 += nyukinRow.IsNyukinGaku001Null() ? 0 : nyukinRow.NyukinGaku001;
                            finalTotal10 += nyukinRow.IsNyukinGaku002Null() ? 0 : nyukinRow.NyukinGaku002;
                            finalTotal11 += nyukinRow.IsNyukinGaku003Null() ? 0 : nyukinRow.NyukinGaku003;

                            // Separate or not?
                            tempNyukinDt = nyukinRow.NyukinDt;

                            // Moving to next row
                            curRow++;

                            // For next shisho block
                            isSumShisho = false;
                        }

                        // Padding row
                        curRow++;

                        // ★日     計★ (sum by NyukinDt)
                        MakeSumRow(outputSheet, curRow, nyukinTotal8, nyukinTotal9, nyukinTotal10, nyukinTotal11, NYUKIN_TOTAL_TEXT);

                        // ★支 所 計★ (sum by shishoNm)
                        MakeSumRow(outputSheet, curRow + 2, shishoTotal8, shishoTotal9, shishoTotal10, shishoTotal11, SHISHO_TOTAL_TEXT);

                        // Padding row
                        curRow += 4;

                        // Sumarized by shisho
                        isSumShisho = true;

                        // Reset nyukin total
                        nyukinTotal8 = 0;
                        nyukinTotal9 = 0;
                        nyukinTotal10 = 0;
                        nyukinTotal11 = 0;
                        // Reset shisho total
                        shishoTotal8 = 0;
                        shishoTotal9 = 0;
                        shishoTotal10 = 0;
                        shishoTotal11 = 0;
                    }

                    // Separate or not?
                    tempShishoCd = row.NyukinShisyoCd;
                }

                // ★総 合 計★(the last sum row)
                MakeSumRow(outputSheet, curRow, finalTotal8, finalTotal9, finalTotal10, finalTotal11, FINAL_TOTAL_TEXT);

                // Print area
                outputSheet.PageSetup.PrintArea = string.Format("A1:AT{0}", curRow + 2);

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

        #region SetHeader
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader(Worksheet sheet, IPrintNyukinUchiwakeBLInput input)
        {
            // 2014/12/16 AnhNV ADD Start
            if (input.IsNyukinDtUse)
            {
                // 入金日From、入金日To(1)
                CellOutput(sheet, 0, 1, string.Format("【対象日付  {0}~{1}】", input.NyukinDtFrom.ToString("yyyy年MM月dd日"), input.NyukinDtTo.ToString("yyyy年MM月dd日")));
            }
            else
            {
                // 入金日From、入金日To(1)
                CellOutput(sheet, 0, 1, string.Empty);
            }
            // 2014/12/16 AnhNV ADD End

            // システム日付(2)
            string warekiDt = Utility.DateUtility.ConvertToWareki(input.SystemDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
            CellOutput(sheet, 0, 31, warekiDt);
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Worksheet sheet, NyukinTblDataSet.NyukinUchiwakeRow row, int curRow)
        {
            // 請求項目名/定数名称(5)
            CellOutput(sheet, curRow, 9, row.KomokuNm);

            // 商品名/定数名称(6)
            CellOutput(sheet, curRow, 13, row.SyohinNm);

            // 定数名称(定数区分002)(7)
            CellOutput(sheet, curRow, 21, row.ConstNm);

            // 入金割振金額/実入金額(8)
            CellOutput(sheet, curRow, 25, row.IsNyukinGakuNull() ? "0" : row.NyukinGaku.ToString("N0"));

            // 入金割振金額/実入金額(9)
            CellOutput(sheet, curRow, 29, row.IsNyukinGaku001Null() ? "0" : row.NyukinGaku001.ToString("N0"));

            // 入金割振金額/実入金額(10)
            CellOutput(sheet, curRow, 32, row.IsNyukinGaku002Null() ? "0" : row.NyukinGaku002.ToString("N0"));

            // 入金割振金額/実入金額(11)
            CellOutput(sheet, curRow, 35, row.IsNyukinGaku003Null() ? "0" : row.NyukinGaku003.ToString("N0"));

            // 業者名称(12)
            CellOutput(sheet, curRow, 37, row.GyoshaNm);
        }
        #endregion

        #region MakeSumRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSumRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="curRow"></param>
        /// <param name="nyukinTotal8"></param>
        /// <param name="nyukinTotal9"></param>
        /// <param name="nyukinTotal10"></param>
        /// <param name="nyukinTotal11"></param>
        /// <param name="sumText"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSumRow
            (
                Worksheet outputSheet,
                int curRow,
                decimal total8,
                decimal total9,
                decimal total10,
                decimal total11,
                string sumText
            )
        {
            // ★sum text★
            CellOutput(outputSheet, curRow, 10, sumText);

            // Total of 入金割振金額/実入金額(8) by NyukinDt
            CellOutput(outputSheet, curRow, 25, total8.ToString("N0"));

            // Total of 入金割振金額/実入金額(9) by NyukinDt
            CellOutput(outputSheet, curRow, 29, total9.ToString("N0"));

            // Total of 入金割振金額/実入金額(10) by NyukinDt
            CellOutput(outputSheet, curRow, 32, total10.ToString("N0"));

            // Total of 入金割振金額/実入金額(11) by NyukinDt
            CellOutput(outputSheet, curRow, 35, total11.ToString("N0"));
        }
        #endregion

        #region MakePrintTable
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakePrintTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nyukinNoList"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NyukinTblDataSet.NyukinUchiwakeDataTable MakePrintTable(List<string> nyukinNoList)
        {
            NyukinTblDataSet.NyukinUchiwakeDataTable table = new NyukinTblDataSet.NyukinUchiwakeDataTable();
            // Get by NyukinNo
            ISelectNyukinUchiwakeByNyukinNoDAInput daInput = new SelectNyukinUchiwakeByNyukinNoDAInput();

            foreach (string nyukinNo in nyukinNoList)
            {
                daInput.NyukinNo = nyukinNo;
                ISelectNyukinUchiwakeByNyukinNoDAOutput daOutput = new SelectNyukinUchiwakeByNyukinNoDataAccess().Execute(daInput);

                // Merge to result
                table.Merge(daOutput.NyukinUchiwakeDataTable);
            }

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
