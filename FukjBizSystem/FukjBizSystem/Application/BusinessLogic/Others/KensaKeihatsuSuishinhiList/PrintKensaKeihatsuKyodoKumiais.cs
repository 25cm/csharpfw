using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.HoteiKanriMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaKeihatsuKyodoKumiaisBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaKeihatsuKyodoKumiaisBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 支払票印刷第○号(44)
        /// </summary>
        string PrintNo { get; set; }

        /// <summary>
        /// 職員名
        /// </summary>
        string LoginNm { get; set; }

        /// <summary>
        /// Current datetime in DB
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaKeihatsuKyodoKumiaissBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/20　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaKeihatsuKyodoKumiaisBLInput : BaseExcelPrintBLInputImpl, IPrintKensaKeihatsuKyodoKumiaisBLInput
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
        /// 支払票印刷第○号(44)
        /// </summary>
        public string PrintNo { get; set; }

        /// <summary>
        /// 職員名
        /// </summary>
        public string LoginNm { get; set; }

        /// <summary>
        /// Current datetime in DB
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaKeihatsuKyodoKumiaisBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaKeihatsuKyodoKumiaisBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaKeihatsuKyodoKumiaisBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/20　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaKeihatsuKyodoKumiaisBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensaKeihatsuKyodoKumiaisBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaKeihatsuKyodoKumiaisBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaKeihatsuKyodoKumiaisBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensaKeihatsuKyodoKumiaisBLInput, IPrintKensaKeihatsuKyodoKumiaisBLOutput>
    {
        #region 置換文字列

        /// <summary>
        /// Number of header rows
        /// </summary>
        private const int HEADER_ROW_NUM = 54;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensaKeihatsuKyodoKumiaisBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/20　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensaKeihatsuKyodoKumiaisBusinessLogic()
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
        /// 2014/08/20　AnhNV　　    新規作成
        /// 2014/10/17　AnhNV　　    021_検査啓発推進費支払票(協同組合)_帳票設計書_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensaKeihatsuKyodoKumiaisBLOutput SetBook(IPrintKensaKeihatsuKyodoKumiaisBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensaKeihatsuKyodoKumiaisBLOutput output = new PrintKensaKeihatsuKyodoKumiaisBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Template sheet
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                tempSheet.Copy(tempSheet, Type.Missing);

                // Set output sheet to current active sheet
                outputSheet = (Worksheet)book.ActiveSheet;
                outputSheet.Name = "検査啓発推進費支払票(協同組合)";

                // Current row in process
                int curRow = 0;
                int shiharaiSogakuRow = 0;
                string tempKyodoKumiaiCd = string.Empty;
                bool firstPage = true;

                // For text 集計年月(開始) ~ 集計年月(終了)
                int shukeiNendo = 0;
                DateTime shukeiFromDt = new DateTime();
                DateTime shukeiToDt = new DateTime();
                string shukeiText = string.Empty;

                // Get 事務局電話番号
                string jimukyokuTelNo = GetJimukyokuTelNo();

                foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow pRow in
                    input.KensaKeihatsuSuishinListDataTable.Select("ToriatsukaiGyoshaKbn = '2' and KyodoKumiaiCd <> ''"))
                {
                    if (tempKyodoKumiaiCd != pRow.KyodoKumiaiCd)
                    {
                        // Copy a new page
                        if (curRow > 0)
                        {
                            // Page break 1
                            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow, 1]);
                            shiharaiSogakuRow = curRow;

                            // Page break 2
                            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow + 45, 1]);

                            // Copy rows
                            //RowCopy(tempSheet, outputSheet, 1, HEADER_ROW_NUM + 1, curRow, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, 0, HEADER_ROW_NUM + 1, outputSheet, curRow - 1);

                            // Index for output data
                            curRow -= 1;

                            // Set row height for header pages
                            SetRowHeight(outputSheet, curRow);
                        }

                        // Get 集計年月(開始), 集計年月(終了)
                        shukeiFromDt = DateTime.ParseExact(pRow.ShukeiFromNengetsu, "yyyyMM", null);
                        shukeiToDt = DateTime.ParseExact(pRow.ShukeiToNengetsu, "yyyyMM", null);
                        shukeiNendo = Utility.DateUtility.GetNendo(shukeiFromDt);
                        shukeiText = GetShukeiText(shukeiFromDt, shukeiToDt, shukeiNendo);

                        // Set header
                        SetHeaderPage(outputSheet, pRow, input, jimukyokuTelNo, shukeiText, curRow);

                        // 支払合計(15)
                        decimal shiharaiTotal = 0;
                        // 計量証明持込件数(16)
                        decimal keiryoSyomeiMochiCnt = 0;
                        // 11条水質持込件数(17)
                        decimal kensa11SuishitsuMochiCnt = 0;
                        // 11条外観件数(18)
                        decimal kensa11GaikanCnt = 0;
                        foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow row in
                            input.KensaKeihatsuSuishinListDataTable.Select(string.Format("KyodoKumiaiCd = '{0}' and ToriatsukaiGyoshaKbn = '2' and KyodoKumiaiCd <> ''", pRow.KyodoKumiaiCd)))
                        {
                            // Row height for detail from page 3
                            if (curRow > 0)
                            {
                                outputSheet.Range[string.Format("A{0}", HEADER_ROW_NUM + curRow + 1), string.Format("A{0}", HEADER_ROW_NUM + curRow + 1)].RowHeight = 19.5;
                            }

                            // Set detail
                            SetDetailPage(outputSheet, row, HEADER_ROW_NUM + curRow);

                            // Copy a detail row
                            //RowCopy(tempSheet, outputSheet, HEADER_ROW_NUM + 1, 1, HEADER_ROW_NUM + curRow + 2, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, HEADER_ROW_NUM, 1, outputSheet, HEADER_ROW_NUM + curRow + 1);

							//受入20141224 mod  DbNull care.

							// 支払合計(15)
                            shiharaiTotal += (!row.IsShiharaiTotalNull() ? row.ShiharaiTotal : (decimal)0) ;
                            // 計量証明持込件数(16)
                            keiryoSyomeiMochiCnt += (!row.IsKeiryoShomeiMochiCntNull() ? row.KeiryoShomeiMochiCnt : (int)0 );
                            // 11条水質持込件数(17)
                            kensa11SuishitsuMochiCnt += (!row.IsKensa11SuishitsuMochiCntNull() ? row.Kensa11SuishitsuMochiCnt : (int)0 );
                            // 11条外観件数(18)
                            kensa11GaikanCnt += (!row.IsKensa11GaikanCntNull() ? row.Kensa11GaikanCnt : (int)0 );

                            // Next detail row
                            curRow++;
                        }

                        // Format 合 計 cell
                        outputSheet.Range[string.Format("A{0}", HEADER_ROW_NUM + curRow + 1), string.Format("A{0}", HEADER_ROW_NUM + curRow + 1)].RowHeight = 19.5;
                        outputSheet.get_Range(string.Format("B{0}", HEADER_ROW_NUM + curRow + 1), string.Format("B{0}", HEADER_ROW_NUM + curRow + 1)).HorizontalAlignment
                            = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        // 合 計
                        CellOutput(outputSheet, HEADER_ROW_NUM + curRow, 1, "合      計");
                        CellOutput(outputSheet, HEADER_ROW_NUM + curRow, 11, shiharaiTotal);
                        CellOutput(outputSheet, HEADER_ROW_NUM + curRow, 16, keiryoSyomeiMochiCnt);
                        CellOutput(outputSheet, HEADER_ROW_NUM + curRow, 21, kensa11SuishitsuMochiCnt);
                        CellOutput(outputSheet, HEADER_ROW_NUM + curRow, 26, kensa11GaikanCnt);

                        // 支払総額(5)
                        CellOutput(outputSheet, !firstPage ? shiharaiSogakuRow + 22 : 23, 9, shiharaiTotal);

                        // Next page
                        curRow += HEADER_ROW_NUM + 3;
                        firstPage = false;
                    }

                    // Reset buffer
                    tempKyodoKumiaiCd = pRow.KyodoKumiaiCd;
                }

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

        #region SetRowHeight
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetRowHeight
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetRowHeight(Worksheet outputSheet, int curRow)
        {
            outputSheet.Range[string.Format("A{0}", curRow + 1), string.Format("A{0}", curRow + 1)].RowHeight = 24.75;
            outputSheet.Range[string.Format("A{0}", curRow + 2), string.Format("A{0}", curRow + 2)].RowHeight = 22.5;
            outputSheet.Range[string.Format("A{0}", curRow + 3), string.Format("A{0}", curRow + 3)].RowHeight = 25.5;
            outputSheet.Range[string.Format("A{0}", curRow + 4), string.Format("A{0}", curRow + 4)].RowHeight = 14.25;
            outputSheet.Range[string.Format("A{0}", curRow + 5), string.Format("A{0}", curRow + 5)].RowHeight = 23.25;
            outputSheet.Range[string.Format("A{0}", curRow + 7), string.Format("A{0}", curRow + 7)].RowHeight = 18.75;
            outputSheet.Range[string.Format("A{0}", curRow + 8), string.Format("A{0}", curRow + 8)].RowHeight = 14.25;
            outputSheet.Range[string.Format("A{0}", curRow + 9), string.Format("A{0}", curRow + 9)].RowHeight = 14.25;
            outputSheet.Range[string.Format("A{0}", curRow + 10), string.Format("A{0}", curRow + 10)].RowHeight = 18.75;
            outputSheet.Range[string.Format("A{0}", curRow + 11), string.Format("A{0}", curRow + 11)].RowHeight = 18.75;
            outputSheet.Range[string.Format("A{0}", curRow + 12), string.Format("A{0}", curRow + 12)].RowHeight = 14.25;
            outputSheet.Range[string.Format("A{0}", curRow + 14), string.Format("A{0}", curRow + 14)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 15), string.Format("A{0}", curRow + 15)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 16), string.Format("A{0}", curRow + 16)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 17), string.Format("A{0}", curRow + 17)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 18), string.Format("A{0}", curRow + 18)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 23), string.Format("A{0}", curRow + 23)].RowHeight = 17.25;
            outputSheet.Range[string.Format("A{0}", curRow + 38), string.Format("A{0}", curRow + 38)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 41), string.Format("A{0}", curRow + 41)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 42), string.Format("A{0}", curRow + 42)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 43), string.Format("A{0}", curRow + 43)].RowHeight = 19.5;
            outputSheet.Range[string.Format("A{0}", curRow + 44), string.Format("A{0}", curRow + 44)].RowHeight = 19.5;
        }
        #endregion

        #region GetJimukyokuTelNo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetJimukyokuTelNo
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetJimukyokuTelNo()
        {
            string jimukyokuTelNo = string.Empty;

            // Get 事務局電話番号
            ISelectHoteiKanriMstByKeyDAInput hoteiInp = new SelectHoteiKanriMstByKeyDAInput();
            hoteiInp.JimukyokuKbn = "0";
            ISelectHoteiKanriMstByKeyDAOutput hoteiOutp = new SelectHoteiKanriMstByKeyDataAccess().Execute(hoteiInp);

            if (hoteiOutp.HoteiKanriMstDataTable.Count > 0)
            {
                jimukyokuTelNo = hoteiOutp.HoteiKanriMstDataTable[0].JimukyokuTelNo;
            }

            return jimukyokuTelNo;
        }
        #endregion

        #region SetHeaderPage
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeaderPage
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="input"></param>
        /// <param name="jimukyokuTelNo"></param>
        /// <param name="shukeiText"></param>
        /// <param name="curRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　AnhNV　　    新規作成
        /// 2014/10/17　AnhNV　　    021_検査啓発推進費支払票(協同組合)_帳票設計書_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeaderPage
            (
                Worksheet sheet,
                KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow row,
                IPrintKensaKeihatsuKyodoKumiaisBLInput input,
                string jimukyokuTelNo,
                string shukeiText,
                int curRow
            )
        {
			//受入20141224 mod  DbNull care.

            // 支払票印刷第○号(1)
            CellOutput(sheet, curRow, 28, input.PrintNo);

            // システム日付(2)
            string systemDt = Utility.DateUtility.ConvertToWareki(input.SystemDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
            CellOutput(sheet, curRow + 1, 23, systemDt);

            // 組合名称(3)
			CellOutput(sheet, curRow + 2, 1, !row.IsKumiaiNmNull() ? row.KumiaiNm + "長" : String.Empty);	//受入20141225 宛名は「組合長」宛てとする。

            //// 年度(4)
            //CellOutput(sheet, curRow + 9, 0, string.Format("平成{0}年度{1}検査啓発推進費等の支払について",
            //    Boundary.Common.Common.ConvertToHoshouNendoWareki(row.SuishinhiNendo),
            //    row.KamiShimoKbn == "1" ? "上半期" : "下半期"));

            // 年度(4)
            CellOutput(sheet, curRow + 9, 0, shukeiText);

            // Total of 9条持込金額(5)
            // Auto fill by excel formula

            // 支払計上日(6)
            if (!row.IsShiharaiDtNull() && !string.IsNullOrEmpty(row.ShiharaiDt.Trim()))
            {
				//受入20141224 mod
                //string shiharaiDt = Utility.DateUtility.ConvertToWareki(row.ShiharaiDt, "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
				string shiharaiDt = Utility.DateUtility.ConvertToWareki(row.ShiharaiDt.Replace("/", string.Empty), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
                CellOutput(sheet, curRow + 25, 9, shiharaiDt);
            }
            else
            {
                CellOutput(sheet, curRow + 25, 9, "'平成 年 月 日");
            }

            // 職員名(7)
            CellOutput(sheet, curRow + 40, 23, input.LoginNm);

            // 事務局電話番号(8)
            CellOutput(sheet, curRow + 41, 20, jimukyokuTelNo);

            //// 年度(9)
            //CellOutput(sheet, curRow + 47, 0, string.Format("平成{0}年度{1}検査啓発推進費",
            //    Boundary.Common.Common.ConvertToHoshouNendoWareki(row.SuishinhiNendo),
            //    row.KamiShimoKbn == "1" ? " (４月～９月）" : "（１０月～３月分）"));

            // 年度(9)
            CellOutput(sheet, curRow + 47, 0, shukeiText);

            // 組合名称(10)
            CellOutput(sheet, curRow + 49, 1, !row.IsKumiaiNmNull() ? row.KumiaiNm : String.Empty );

            // 計量証明持込単価 (11)
            CellOutput(sheet, curRow + 53, 16, !row.IsKeiryoShomeiMochiUpNull() ? row.KeiryoShomeiMochiUp.ToString() : String.Empty );

            // 11条水質持込単価 (12)
            CellOutput(sheet, curRow + 53, 21, !row.IsKensa11SuishitsuMochiUpNull() ? row.Kensa11SuishitsuMochiUp.ToString() : String.Empty );

            // 11条外観単価(13)
            CellOutput(sheet, curRow + 53, 26, !row.IsKensa11GaikanUpNull() ? row.Kensa11GaikanUp.ToString() : String.Empty );
        }
        #endregion

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
        /// <param name="detailRow"></param>
        /// <param name="detailIdxRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetailPage(Worksheet sheet, KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow detailRow, int detailIdxRow)
        {
			//受入20141224 mod  DbNull care.

			// 業者名称(14)
            CellOutput(sheet, detailIdxRow, 1, !detailRow.IsGyoshaNmNull() ? detailRow.GyoshaNm : String.Empty );

            // 支払合計(15)
            CellOutput(sheet, detailIdxRow, 11, !detailRow.IsShiharaiTotalNull() ? detailRow.ShiharaiTotal.ToString() : String.Empty );

            // 計量証明持込件数(16)
            CellOutput(sheet, detailIdxRow, 16, !detailRow.IsKeiryoShomeiMochiCntNull() ? detailRow.KeiryoShomeiMochiCnt.ToString() : String.Empty );

            // 11条水質持込件数(17)
            CellOutput(sheet, detailIdxRow, 21, !detailRow.IsKensa11SuishitsuMochiCntNull() ? detailRow.Kensa11SuishitsuMochiCnt.ToString() : String.Empty );

            // 11条外観件数(18)
            CellOutput(sheet, detailIdxRow, 26, !detailRow.IsKensa11GaikanCntNull() ? detailRow.Kensa11GaikanCnt.ToString() : String.Empty );
        }
        #endregion

        #region GetShukeiText
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetShukeiText
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="shukeiFromDt"></param>
        /// <param name="shukeiToDt"></param>
        /// <param name="shukeiNendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　AnhNV　　    021_検査啓発推進費支払票(協同組合)_帳票設計書_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetShukeiText(DateTime shukeiFromDt, DateTime shukeiToDt, int shukeiNendo)
        {
            string fixedText = "検査啓発推進費等の支払について";
            string shukeiText = string.Empty;
            string nendo = Utility.DateUtility.ConvertToWareki(shukeiNendo.ToString(), "gyy年", Utility.DateUtility.GengoKbn.Wareki);

            // 4月～9月だった場合
            if (shukeiFromDt.Month == 4 && shukeiToDt.Month == 9 && shukeiFromDt.Year == shukeiToDt.Year)
            {
                shukeiText = string.Format("{0}度上半期", nendo);
            }
            else if (shukeiFromDt.Month == 10 && shukeiToDt.Month == 3 && shukeiToDt.Year == shukeiFromDt.Year + 1) // 10月～次年3月だった場合
            {
                shukeiText = string.Format("{0}度下半期", nendo);
            }
            else // others
            {
                shukeiText = string.Format("{0}～{1}", Utility.DateUtility.ConvertToWareki(shukeiFromDt.ToString("yyyyMM"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki),
                                                        Utility.DateUtility.ConvertToWareki(shukeiToDt.ToString("yyyyMM"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki));
            }

            return shukeiText + fixedText;
        }
        #endregion

        #endregion
    }
    #endregion
}
