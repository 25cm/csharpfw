using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.SeikyuHdrTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSeikyuShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSeikyuShoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// List of SeikyuNo gets from result search
        /// </summary>
        List<string> SeikyuNoList { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSeikyuShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSeikyuShoBLInput : BaseExcelPrintBLInputImpl, IPrintSeikyuShoBLInput
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
        /// List of SeikyuNo gets from result search
        /// </summary>
        public List<string> SeikyuNoList { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSeikyuShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSeikyuShoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSeikyuShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSeikyuShoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSeikyuShoBLOutput
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
    //  クラス名 ： PrintSeikyuShoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSeikyuShoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSeikyuShoBLInput, IPrintSeikyuShoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSeikyuShoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSeikyuShoBusinessLogic()
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
        /// 2014/09/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSeikyuShoBLOutput SetBook(IPrintSeikyuShoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSeikyuShoBLOutput output = new PrintSeikyuShoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Each seikyu no placed in one sheet!
                string tempSeikyuNo = string.Empty;

                // Get print data table
                SeikyuHdrTblDataSet.SeikyuShoDataTable printTable = GetPrintDataTable(input.SeikyuNoList);

                foreach (SeikyuHdrTblDataSet.SeikyuShoRow row in printTable.Select(string.Empty, "OyaSeikyuNo"))
                {
                    // Copy a new sheet and fill up the textboxes
                    if (tempSeikyuNo != row.OyaSeikyuNo)
                    {
                        // Copy a new sheet
                        tempSheet = (Worksheet)book.Sheets["Sheet1"];

                        // Set output sheet to current active sheet

                        // 2014.01.05 toyoda Modify Start
                        //tempSheet.Copy(tempSheet, Type.Missing);
                        //outputSheet = (Worksheet)book.ActiveSheet;
                        CopySheet(book, tempSheet.Index - 1, tempSheet.Index);
                        outputSheet = (Worksheet)book.Sheets[tempSheet.Index + 1];
                        // 2014.01.05 toyoda Modify End

                        outputSheet.Name = string.Concat("請求書_", row.OyaSeikyuNo);

                        // Header text
                        SetHeaderText(outputSheet, row);

                        // Detail row index
                        int rowIdx = 1;
                        // 合計内消費税
                        decimal syohizeiTotal = 0;

                        // Detail rows
                        foreach (SeikyuHdrTblDataSet.SeikyuShoRow detailRow in
                            printTable.Select(string.Format("OyaSeikyuNo = '{0}'", row.OyaSeikyuNo), "KagamiMeisaiNo"))
                        {
                            // 請求内訳名(8)
                            SetShapeText(outputSheet, string.Format("seikyuUchiwake{0}TextBox", rowIdx), detailRow.SeikyuUchiwakeNm);

                            // 数量合計(9)
                            SetShapeText(outputSheet, string.Format("seikyuSuryo{0}TextBox", rowIdx), detailRow.IsSeikyuSuryoCntNull() ? string.Empty : detailRow.SeikyuSuryoCnt.ToString("N0"));

                            // 金額(10)
                            SetShapeText(outputSheet, string.Format("seikyuKingaku{0}TextBox", rowIdx), detailRow.IsSeikyuKingakuNull() ? string.Empty : detailRow.SeikyuKingaku.ToString("N0"));

                            // 内消費税(11)
                            SetShapeText(outputSheet, string.Format("syohizei{0}TextBox", rowIdx), detailRow.IsUchiSyohizeiNull() ? string.Empty : detailRow.UchiSyohizei.ToString("N0"));

                            syohizeiTotal += detailRow.IsUchiSyohizeiNull() ? 0 : detailRow.UchiSyohizei;

                            // Next detail row
                            rowIdx++;
                        }

                        // 請求合計金額(12)
                        SetShapeText(outputSheet, "seikyuTotal2TextBox", row.IsHdrSeikyuKingakuNull() ? string.Empty : row.HdrSeikyuKingaku.ToString("N0"));

                        // 内消費税(13)
                        SetShapeText(outputSheet, "syohizeiTotalTextBox", syohizeiTotal.ToString("N0"));
                    }

                    // No change - no copy new sheet!
                    tempSeikyuNo = row.OyaSeikyuNo;
                }

                // 2シート以上あるか？
                if (book.Sheets.Count > 1 && outputSheet != null)
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

        #region SetHeaderText
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeaderText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeaderText(Worksheet outputSheet, SeikyuHdrTblDataSet.SeikyuShoRow row)
        {
            // Format 請求合計金額 (for 14 and 21 - design)
            char[] letters = row.IsHdrSeikyuKingakuNull() ? new char[]{} : row.HdrSeikyuKingaku.ToString("N0").ToCharArray();
            string seikyuTotalFormat = string.Empty;
            foreach (char c in letters)
            {
                if (c == ',') continue;
                seikyuTotalFormat += c + new string(' ', 3);
            }

            // 事務局代表者名(1)
            SetShapeText(outputSheet, "rijichoNmTextBox", row.JimukyokuDaihyoshaNm);

            // 請求日-Year(2)
            SetShapeText(outputSheet, "hakkoDtyearTextBox", row.HakkoDtYear);

            // 請求日-Month(2)
            SetShapeText(outputSheet, "hakkoDtMonthTextBox", row.HakkoDtMonth);

            // 請求日-Day(2)
            SetShapeText(outputSheet, "hakkoDtDayTextBox", row.HakkoDtDay);

            // 請求先郵便番号(3)
            SetShapeText(outputSheet, "zipNo1TextBox", row.SeikyusakisakiZipCd);

            // 請求先住所(4)
            SetShapeText(outputSheet, "adr1TextBox", row.SeikyusakiAdr);

            // 請求先名称(5)
            SetShapeText(outputSheet, "seikyusakiNm1TextBox", row.SeikyusakiNm);

            // 請求年月(6)
            SetShapeText(outputSheet, "seikyuMonthTextBox", row.SeikyuMonth);

            // 請求合計金額(7)
            SetShapeText(outputSheet, "seikyuTotal1TextBox", row.IsHdrSeikyuKingakuNull() ? string.Empty : row.HdrSeikyuKingaku.ToString("N0"));

            // 請求合計金額(14)
            SetShapeText(outputSheet, "seikyuTotal3TextBox", seikyuTotalFormat);

            // 請求先郵便番号(15)
            SetShapeText(outputSheet, "zipNo2TextBox", row.SeikyusakisakiZipCd);

            // 請求先住所(16)
            SetShapeText(outputSheet, "adr2TextBox", row.SeikyusakiAdr);

            // 請求先名称(17)
            SetShapeText(outputSheet, "seikyusakiNm2TextBox", row.SeikyusakiNm);

            // 請求No(18)
            CellOutput(outputSheet, 59, 13, row.OyaSeikyuNo);

            // 業者コード(19)
            SetShapeText(outputSheet, "gyosyaNoTextBox", row.IkkatsuSeikyuSakiCd);

            // 請求年月(20)
            SetShapeText(outputSheet, "seikyuNenGetsuTextBox", row.SeikyuNenGetsu);

            // 請求合計金額(21)
            SetShapeText(outputSheet, "seikyuTotal4TextBox", seikyuTotalFormat);

            // 請求先名称(22)
            SetShapeText(outputSheet, "seikyusakiNm3TextBox", row.SeikyusakiNm);
        }
        #endregion

        #region GetPrintDataTable
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetPrintDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seikyuNoList"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuHdrTblDataSet.SeikyuShoDataTable GetPrintDataTable(List<string> seikyuNoList)
        {
            SeikyuHdrTblDataSet.SeikyuShoDataTable table = new SeikyuHdrTblDataSet.SeikyuShoDataTable();
            ISelectSeikyuShoBySeikyuNoDAInput daInput = new SelectSeikyuShoBySeikyuNoDAInput();

            foreach (string seikyuNo in seikyuNoList)
            {
                daInput.SeikyuNo = seikyuNo;
                ISelectSeikyuShoBySeikyuNoDAOutput daOutput = new SelectSeikyuShoBySeikyuNoDataAccess().Execute(daInput);
                table.Merge(daOutput.SeikyuShoDataTable);
            }

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
