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
    //  インターフェイス名 ： IPrintSeikyuMeisaiShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSeikyuMeisaiShoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// List of SeikyuNo gets from result search
        /// </summary>
        List<string> SeikyuNoList { get; set; }

        /// <summary>
        /// 請求完済フラグを条件に含めるか(1:含める 1以外:含めない)
        /// </summary>
        string SeikyuKansaiFlg { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSeikyuMeisaiShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSeikyuMeisaiShoBLInput : BaseExcelPrintBLInputImpl, IPrintSeikyuMeisaiShoBLInput
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

        /// <summary>
        /// SeikyuKansaiFlg
        /// </summary>
        public string SeikyuKansaiFlg { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSeikyuMeisaiShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSeikyuMeisaiShoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSeikyuMeisaiShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSeikyuMeisaiShoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSeikyuMeisaiShoBLOutput
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
    //  クラス名 ： PrintSeikyuMeisaiShoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSeikyuMeisaiShoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSeikyuMeisaiShoBLInput, IPrintSeikyuMeisaiShoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSeikyuMeisaiShoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSeikyuMeisaiShoBusinessLogic()
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
        /// 2014/09/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSeikyuMeisaiShoBLOutput SetBook(IPrintSeikyuMeisaiShoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSeikyuMeisaiShoBLOutput output = new PrintSeikyuMeisaiShoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Get print data table
                SeikyuHdrTblDataSet.SeikyuMeisaiShoDataTable printTable = GetPrintDataTable(input.SeikyuNoList, input.SeikyuKansaiFlg);
                
                // Paginator
                string tempSeikyuNo = "tempSeikyuNo";
                string tempHoteiKbn = "tempHoteiKbn";
                // Detail row index
                int curRow = 5;
                // Sheet index
                int sheetIdx = 1;

                foreach (SeikyuHdrTblDataSet.SeikyuMeisaiShoRow row in printTable.Select(string.Empty, "SeikyuNo, KensaIraiHoteiKbn"))
                {
                    // New page?
                    if (tempSeikyuNo != row.SeikyuNo || tempHoteiKbn != row.KensaIraiHoteiKbn)
                    {
                        // Copy a new sheet
                        tempSheet = (Worksheet)book.Sheets["Sheet1"];
                        tempSheet.Copy(tempSheet, Type.Missing);

                        // Set output sheet to current active sheet
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = string.Concat("請求明細書_", sheetIdx.ToString());

                        // Next sheet
                        sheetIdx++;

                        // Page header
                        SetHeader(outputSheet, row);

                        // Detail row index
                        curRow = 5;
                        // Record count
                        int recordNum = 0;
                        int greateRecordNum = 0;
                        // Total of 請求金額計(12)
                        decimal seikyuKingakuKeiTotal = 0;
                        decimal greateSeikyuKingakuKeiTotal = 0;

                        // Page detail
                        string uriageDt = string.Empty;
                        foreach (SeikyuHdrTblDataSet.SeikyuMeisaiShoRow detailRow in
                            printTable.Select(string.Format("SeikyuNo = '{0}' and KensaIraiHoteiKbn = '{1}'", row.SeikyuNo, row.KensaIraiHoteiKbn), "SyohinUriageDt, KyokaiNo"))
                        {
                            if (uriageDt != detailRow.SyohinUriageDt)
                            {
                                // New block
                                if (curRow > 5)
                                {
                                    // Small total text (13)
                                    CellOutput(outputSheet, curRow, 12, "☆日計☆");

                                    // Small Number of row (14)
                                    CellOutput(outputSheet, curRow, 22, string.Concat(recordNum, "件"));

                                    // Small Total of 請求金額計(15)
                                    CellOutput(outputSheet, curRow, 26, seikyuKingakuKeiTotal.ToString("N0") + "円");

                                    // 1 padding row
                                    //curRow++;
                                    curRow += 2;
                                    seikyuKingakuKeiTotal = 0;
                                    recordNum = 0;
                                }

                                // Detail row with UriageDt
                                SetDetail(outputSheet, detailRow, curRow, true);
                            }
                            else
                            {
                                // Detail row without UriageDt
                                SetDetail(outputSheet, detailRow, curRow, false);
                            }

                            // 請求金額計
                            seikyuKingakuKeiTotal += detailRow.IsSeikyuKingakuKeiNull() ? 0 : detailRow.SeikyuKingakuKei;
                            greateSeikyuKingakuKeiTotal += detailRow.IsSeikyuKingakuKeiNull() ? 0 : detailRow.SeikyuKingakuKei;

                            uriageDt = detailRow.SyohinUriageDt;
                            curRow++;
                            recordNum++;
                            greateRecordNum++;
                        }

                        // Small total text (13)
                        CellOutput(outputSheet, curRow, 12, "☆日計☆");

                        // Small Number of row (14)
                        CellOutput(outputSheet, curRow, 22, string.Concat(recordNum, "件"));

                        // Small Total of 請求金額計(15)
                        CellOutput(outputSheet, curRow, 26, seikyuKingakuKeiTotal.ToString("N0") + "円");

                        // Great total text(16)
                        CellOutput(outputSheet, curRow + 1, 12, "☆合計☆");

                        // Great Number of row (17)
                        CellOutput(outputSheet, curRow + 1, 22, string.Concat(greateRecordNum, "件"));

                        // Great Total of 請求金額計(18)
                        CellOutput(outputSheet, curRow + 1, 26, greateSeikyuKingakuKeiTotal.ToString("N0") + "円");

                        // Print area for each page
                        outputSheet.PageSetup.PrintArea = string.Format("A$1:AU${0}", curRow + 3);
                    }

                    tempSeikyuNo = row.SeikyuNo;
                    tempHoteiKbn = row.KensaIraiHoteiKbn;
                }

                // 2シート以上あるか？
                if (book.Sheets.Count > 1 && tempSheet != null)
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

        #region GetPrintDataTable
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetPrintDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="seikyuNoList"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuHdrTblDataSet.SeikyuMeisaiShoDataTable GetPrintDataTable(List<string> seikyuNoList, string seikyuKansaiFlg)
        {
            SeikyuHdrTblDataSet.SeikyuMeisaiShoDataTable table = new SeikyuHdrTblDataSet.SeikyuMeisaiShoDataTable();

            if (seikyuKansaiFlg == "1")
            {
                ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput daInput = new SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput();

                foreach (string seikyuNo in seikyuNoList)
                {
                    daInput.SeikyuNo = seikyuNo;
                    ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput daOutput = new SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDataAccess().Execute(daInput);
                    table.Merge(daOutput.SeikyuMeisaiShoDataTable);
                }
            }
            else
            {
                ISelectSeikyuMeisaiShoBySeikyuNoDAInput daInput = new SelectSeikyuMeisaiShoBySeikyuNoDAInput();

                foreach (string seikyuNo in seikyuNoList)
                {
                    daInput.SeikyuNo = seikyuNo;
                    ISelectSeikyuMeisaiShoBySeikyuNoDAOutput daOutput = new SelectSeikyuMeisaiShoBySeikyuNoDataAccess().Execute(daInput);
                    table.Merge(daOutput.SeikyuMeisaiShoDataTable);
                }
            }

            return table;
        }
        #endregion

        #region SetHeader
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeader
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader(Worksheet outputSheet, SeikyuHdrTblDataSet.SeikyuMeisaiShoRow row)
        {
            // 請求年月(1)
            CellOutput(outputSheet, 0, 1, string.Format("≪{0}≫", row.SeikyuYM));

            // 定数名称(2)
            CellOutput(outputSheet, 0, 10, row.ConstNm);

            // システム日付(3)
            CellOutput(outputSheet, 0, 28, row.SystemDate);

            // 請求先名称(4)
            CellOutput(outputSheet, 2, 1, row.SeikyusakiNm);

            // 業者コード(5)
            CellOutput(outputSheet, 2, 20, string.Concat("'", row.SeikyuGyosyaCd));
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <param name="difDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Worksheet outputSheet, SeikyuHdrTblDataSet.SeikyuMeisaiShoRow row, int curRow, bool difDt)
        {
            // 商品売上日(6)
            if (difDt) CellOutput(outputSheet, curRow, 1, row.SyohinUriageDt);

            // 協会No(7)
            CellOutput(outputSheet, curRow, 5, row.KyokaiNo);

            // 設置者名（漢字）/設置者氏名(8)
            CellOutput(outputSheet, curRow, 11, row.SetchishaNm);

            // 検査依頼設置場所（住所）/浄化槽設置場所住所(9)
            CellOutput(outputSheet, curRow, 20, row.SetchibashoAdr);

            // 処理方式種別名(10)
            CellOutput(outputSheet, curRow, 34, row.ShoriHoshikiShubetsuNm);

            // 処理対象人員/計量証明人槽(11)
            CellOutput(outputSheet, curRow, 38, string.Concat(row.Ninsou, "人"));

            // 請求金額計(12)
            CellOutput(outputSheet, curRow, 43, row.SeikyuKingakuKei.ToString("N0"));
        }
        #endregion

        #endregion
    }
    #endregion
}
