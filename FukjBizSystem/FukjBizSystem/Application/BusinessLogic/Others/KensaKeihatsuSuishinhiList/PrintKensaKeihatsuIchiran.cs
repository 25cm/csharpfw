using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.ChikuMst;
using FukjBizSystem.Application.DataAccess.ConstMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaKeihatsuIchiranBLInput
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
    interface IPrintKensaKeihatsuIchiranBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 上下期区分/全件/上期/下期
        /// </summary>
        string Option { get; set; }

        /// <summary>
        /// 集計年度
        /// </summary>
        string SyukeiNendo { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaKeihatsuIchiranBLInput
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
    class PrintKensaKeihatsuIchiranBLInput : BaseExcelPrintBLInputImpl, IPrintKensaKeihatsuIchiranBLInput
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
        /// 上下期区分/全件/上期/下期
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// 集計年度
        /// </summary>
        public string SyukeiNendo { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaKeihatsuIchiranBLOutput
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
    interface IPrintKensaKeihatsuIchiranBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaKeihatsuIchiranBLOutput
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
    class PrintKensaKeihatsuIchiranBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensaKeihatsuIchiranBLOutput
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
    //  クラス名 ： PrintKensaKeihatsuIchiranBusinessLogic
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
    class PrintKensaKeihatsuIchiranBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensaKeihatsuIchiranBLInput, IPrintKensaKeihatsuIchiranBLOutput>
    {
        #region 置換文字列

        /// <summary>
        /// Represent for a null and empty string
        /// </summary>
        private const string NULL_REPLACE_STR = "zzzzz";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensaKeihatsuIchiranBusinessLogic
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
        public PrintKensaKeihatsuIchiranBusinessLogic()
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
        /// 2014/10/17　AnhNV　　    022_検査啓発推進費一覧_帳票設計書_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensaKeihatsuIchiranBLOutput SetBook(IPrintKensaKeihatsuIchiranBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensaKeihatsuIchiranBLOutput output = new PrintKensaKeihatsuIchiranBLOutput();

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
                outputSheet.Name = "検査啓発推進費一覧";

                // Index variables
                int curRow = 6;
                int startGyoshaSumRow = 6;
                int startEmptyKumiai = 0;
                int greatSumStartRow = 0;
                // Flag variables
                bool endKyodoKumiai = false;
                // Paginator variables
                string tempKyodoKuimiaiCd = string.Empty;
                // Storage variables
                decimal syomeiMochiCnt = 0;
                decimal syomeiMochiGaku = 0;
                decimal syomeiSyusyuCnt = 0;
                decimal syomeiSyusyuGaku = 0;
                decimal syomeiToriCnt = 0;
                decimal syomeiToriGaku = 0;
                decimal suishitsuMochiCnt = 0;
                decimal suishitsuMochiGaku = 0;
                decimal suishitsuSyusyuCnt = 0;
                decimal suishitsuSyusyuGaku = 0;
                decimal suishitsuToriCnt = 0;
                decimal suishitsuToriGaku = 0;
                decimal gaikanCnt = 0;
                decimal gaikanGaku = 0;

                // For text 集計年月(開始) ~ 集計年月(終了)
                int shukeiNendo = 0;
                DateTime shukeiFromDt = new DateTime();
                DateTime shukeiToDt = new DateTime();
                string shukeiText = string.Empty;

                // Select ChikuMst by key
                ISelectChikuMstByKeyDAInput chikuInp = new SelectChikuMstByKeyDAInput();

                // Push all empty KyodoKumiaiCd rows to the last of the table
                PushEmptyKyodoKumiaiCdRowToLast(input.KensaKeihatsuSuishinListDataTable);

                // Not empty KyodoKumiai
                foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow row in
                    input.KensaKeihatsuSuishinListDataTable.Select(string.Empty, "KyodoKumiaiCd"))
                {
                    if (curRow == 6)
                    {
                        // Get 集計年月(開始), 集計年月(終了)
                        shukeiFromDt = DateTime.ParseExact(row.ShukeiFromNengetsu, "yyyyMM", null);
                        shukeiToDt = DateTime.ParseExact(row.ShukeiToNengetsu, "yyyyMM", null);
                        shukeiNendo = Utility.DateUtility.GetNendo(shukeiFromDt);
                        shukeiText = GetShukeiText(shukeiFromDt, shukeiToDt, shukeiNendo);

                        // Print page header - 1 time only
                        SetHeader(outputSheet, row, input.Option, input.SyukeiNendo, shukeiText);
                    }

                    // Not empty KyodoKumiaiCd rows
					if (!row.IsKyodoKumiaiCdNull() && row.KyodoKumiaiCd != NULL_REPLACE_STR && tempKyodoKuimiaiCd != row.KyodoKumiaiCd) //受入20141224 mod  DbNull care.
                    {
                        // Condition for ChikuMst search
                        chikuInp.ChikuMstCd = row.KyodoKumiaiCd;

                        foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow gyoshaRow in
                            input.KensaKeihatsuSuishinListDataTable.Select(string.Format("KyodoKumiaiCd = '{0}'", row.KyodoKumiaiCd), "KyodoKumiaiCd, GyoshaCd"))
                        {
                            // Copy a new gyosha row
                            //RowCopy(tempSheet, outputSheet, 6, 1, curRow, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, 5, 1, outputSheet, curRow - 1);

                            // Detail for each gyosha row
                            SetDetail(outputSheet, gyoshaRow, curRow - 1);

                            // Next detail row
                            curRow++;

							//受入20141224 mod  DbNull care.

                            // Total
                            syomeiMochiCnt += (!gyoshaRow.IsKeiryoShomeiMochiCntNull() ? gyoshaRow.KeiryoShomeiMochiCnt : (int)0 );
                            syomeiMochiGaku += (!gyoshaRow.IsKeiryoShomeiMochiAmtNull() ? gyoshaRow.KeiryoShomeiMochiAmt : (decimal)0 );
							syomeiSyusyuCnt += (!gyoshaRow.IsKeiryoShomeiShushuCntNull() ? gyoshaRow.KeiryoShomeiShushuCnt : (int)0 );
                            syomeiSyusyuGaku += (!gyoshaRow.IsKeiryoShomeiShushuAmtNull() ? gyoshaRow.KeiryoShomeiShushuAmt : (decimal)0 );
                            syomeiToriCnt += (!gyoshaRow.IsKeiryoShomeiToriCntNull() ? gyoshaRow.KeiryoShomeiToriCnt : (int)0 );
                            syomeiToriGaku += (!gyoshaRow.IsKeiryoShomeiToriAmtNull() ? gyoshaRow.KeiryoShomeiToriAmt : (decimal)0 );
                            suishitsuMochiCnt += (!gyoshaRow.IsKensa11SuishitsuMochiCntNull() ? gyoshaRow.Kensa11SuishitsuMochiCnt : (int)0 );
                            suishitsuMochiGaku += (!gyoshaRow.IsKensa11SuishitsuMochiAmtNull() ? gyoshaRow.Kensa11SuishitsuMochiAmt : (decimal)0 );
                            suishitsuSyusyuCnt += (!gyoshaRow.IsKensa11SuishitsuShushuCntNull() ? gyoshaRow.Kensa11SuishitsuShushuCnt : (int)0 );
                            suishitsuSyusyuGaku += (!gyoshaRow.IsKensa11SuishitsuShushuAmtNull() ? gyoshaRow.Kensa11SuishitsuShushuAmt : (decimal)0 );
							suishitsuToriCnt += (!gyoshaRow.IsKensa11SuishitsuToriCntNull() ? gyoshaRow.Kensa11SuishitsuToriCnt : (int)0 );
                            suishitsuToriGaku += (!gyoshaRow.IsKensa11SuishitsuToriAmtNull() ? gyoshaRow.Kensa11SuishitsuToriAmt : (decimal)0 );
							gaikanCnt += (!gyoshaRow.IsKensa11GaikanCntNull() ? gyoshaRow.Kensa11GaikanCnt : (int)0 );
							gaikanGaku += (!gyoshaRow.IsKensa11GaikanAmtNull() ? gyoshaRow.Kensa11GaikanAmt : (decimal)0 );
                        }

                        // 組合名
                        SetChikuRyakusho(outputSheet, chikuInp, false, startGyoshaSumRow > 6 ? startGyoshaSumRow + 1 : startGyoshaSumRow, curRow);

                        // 合    計 (sum for not empty KyodoKumiaiCd rows)
                        //RowCopy(tempSheet, outputSheet, 7, 1, curRow, XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, 6, 1, outputSheet, curRow - 1);
                        MakeSumCol(outputSheet, startGyoshaSumRow > 6 ? startGyoshaSumRow + 1 : startGyoshaSumRow, curRow - 1);

                        // Next gyosha sum row
                        startGyoshaSumRow = curRow;
                        tempKyodoKuimiaiCd = row.KyodoKumiaiCd;
                        curRow++;
                    }
					else if (row.IsKyodoKumiaiCdNull() || row.KyodoKumiaiCd == NULL_REPLACE_STR) // Empty KyodoKumiaiCd rows	//受入20141224 mod  DbNull care.
                    {
                        if (!endKyodoKumiai)
                        {
                            // 組合総合計 (sum for not empty KyodoKumiaiCd rows) - 1 time only
                            //RowCopy(tempSheet, outputSheet, 8, 1, curRow, XlPasteType.xlPasteAll);
                            CopyRow(tempSheet, 7, 1, outputSheet, curRow - 1);
                            CellOutput(outputSheet, curRow - 1, 11, syomeiMochiCnt);
                            CellOutput(outputSheet, curRow - 1, 13, syomeiMochiGaku);
                            CellOutput(outputSheet, curRow - 1, 17, syomeiSyusyuCnt);
                            CellOutput(outputSheet, curRow - 1, 19, syomeiSyusyuGaku);
                            CellOutput(outputSheet, curRow - 1, 23, syomeiToriCnt);
                            CellOutput(outputSheet, curRow - 1, 25, syomeiToriGaku);
                            CellOutput(outputSheet, curRow - 1, 33, suishitsuMochiCnt);
                            CellOutput(outputSheet, curRow - 1, 35, suishitsuMochiGaku);
                            CellOutput(outputSheet, curRow - 1, 39, suishitsuSyusyuCnt);
                            CellOutput(outputSheet, curRow - 1, 41, suishitsuSyusyuGaku);
                            CellOutput(outputSheet, curRow - 1, 45, suishitsuToriCnt);
                            CellOutput(outputSheet, curRow - 1, 47, suishitsuToriGaku);
                            CellOutput(outputSheet, curRow - 1, 51, gaikanCnt);
                            CellOutput(outputSheet, curRow - 1, 53, gaikanGaku);

                            // 組合総合計 合計金額
                            decimal gokeiKingaku = syomeiMochiGaku + syomeiSyusyuGaku + syomeiToriGaku + suishitsuMochiGaku + suishitsuSyusyuGaku + suishitsuToriGaku + gaikanGaku;
                            CellOutput(outputSheet, curRow - 1, 61, gokeiKingaku);

                            // Don't make sum twice!
                            endKyodoKumiai = true;

                            // Move to empty KyodoKumiaiCd rows
                            greatSumStartRow = curRow;
                            curRow++;
                            startEmptyKumiai = curRow;
                        }

                        // Copy a new gyosha row
                        //RowCopy(tempSheet, outputSheet, 6, 1, curRow, XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, 5, 1, outputSheet, curRow - 1);

                        // Detail for each gyosha row
                        SetDetail(outputSheet, row, curRow - 1);

                        // Next empty KyodoKumiaiCd row
                        curRow++;
                    }
                }

                if (startEmptyKumiai > 0)
                {
                    // Merge cell 組合名 (for empty KyodoKumiai rows)
                    SetChikuRyakusho(outputSheet, null, true, startEmptyKumiai, curRow);
                }

                // 合    計 (sum for empty KyodoKumiaiCd rows)
                //RowCopy(tempSheet, outputSheet, 7, 1, curRow + 1, XlPasteType.xlPasteAll);
				// 受入20141225 mod sta
				//CopyRow(tempSheet, 6, 1, outputSheet, curRow);
				CopyRow(tempSheet, 6, 1, outputSheet, curRow - 1);
				// 受入20141225 mod end
				MakeSumCol(outputSheet, startEmptyKumiai, curRow - 1);

                // 総   合   計 (great sum - end of file)
                //RowCopy(tempSheet, outputSheet, 9, 1, curRow + 1, XlPasteType.xlPasteAll);
                CopyRow(tempSheet, 8, 1, outputSheet, curRow);
                MakeGreaterSumCol(outputSheet, startEmptyKumiai - 1, curRow);

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
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="option"></param>
        /// <param name="syukeiNendo"></param>
        /// <param name="shukeiText"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// 2014/10/17　AnhNV　　    022_検査啓発推進費一覧_帳票設計書_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader
            (
                Worksheet sheet,
                KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow row,
                string option,
                string syukeiNendo,
                string shukeiText
            )
        {
            // Get list of ConstMst where ConstKbn = 005
            List<string> constLst = GetListConstMstByKbn005();

            // Date header (1)
            CellOutput(sheet, 1, 0, shukeiText);

            // 定数値 (001)
            CellOutput(sheet, 3, 13, string.Format("X{0}円", constLst[0]));

            // 定数値 (002)
            CellOutput(sheet, 3, 19, string.Format("X{0}円", constLst[1]));

            // 定数値 (003)
            CellOutput(sheet, 3, 25, string.Format("X{0}円", constLst[2]));

            // 定数値 (004)
            CellOutput(sheet, 3, 35, string.Format("X{0}円", constLst[3]));

            // 定数値 (005)
            CellOutput(sheet, 3, 41, string.Format("X{0}円", constLst[4]));

            // 定数値 (006)
            CellOutput(sheet, 3, 47, string.Format("X{0}円", constLst[5]));

            // 定数値 (007)
            CellOutput(sheet, 3, 53, string.Format("X{0}円", constLst[6]));
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
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail
            (
                Worksheet sheet,
                KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow row,
                int curRow
            )
        {
            //受入20141224 mod  DbNull care.
			
			// 業者名称(3)
            CellOutput(sheet, curRow, 3, !row.IsGyoshaNmNull() ? row.GyoshaNm : String.Empty );

            // 計量証明持込件数(11)
            CellOutput(sheet, curRow, 11, !row.IsKeiryoShomeiMochiCntNull() ? row.KeiryoShomeiMochiCnt.ToString() : String.Empty );

            // 計量証明持込金額(12)
            CellOutput(sheet, curRow, 13, !row.IsKeiryoShomeiMochiAmtNull() ? row.KeiryoShomeiMochiAmt.ToString() : String.Empty );

            // 計量証明収集件数(13)
            CellOutput(sheet, curRow, 17, !row.IsKeiryoShomeiShushuCntNull() ? row.KeiryoShomeiShushuCnt.ToString() : String.Empty );

            // 計量証明収集金額(14)
            CellOutput(sheet, curRow, 19, !row.IsKeiryoShomeiShushuAmtNull() ? row.KeiryoShomeiShushuAmt.ToString() : String.Empty );

            // 計量証明取扱件数(15)
            CellOutput(sheet, curRow, 23, !row.IsKeiryoShomeiToriCntNull() ? row.KeiryoShomeiToriCnt.ToString() : String.Empty );

            // 計量証明取扱金額(16)
            CellOutput(sheet, curRow, 25, !row.IsKeiryoShomeiToriAmtNull() ? row.KeiryoShomeiToriAmt.ToString() : String.Empty );

            // 11条水質持込件数(18)
            CellOutput(sheet, curRow, 33, !row.IsKensa11SuishitsuMochiCntNull() ? row.Kensa11SuishitsuMochiCnt.ToString() : String.Empty );

            // 11条水質持込金額(19)
            CellOutput(sheet, curRow, 35, !row.IsKensa11SuishitsuMochiAmtNull() ? row.Kensa11SuishitsuMochiAmt.ToString() : String.Empty );

            // 11条水質収集件数(20)
            CellOutput(sheet, curRow, 39, !row.IsKensa11SuishitsuShushuCntNull() ? row.Kensa11SuishitsuShushuCnt.ToString() : String.Empty );

            // 11条水質収集金額(21)
            CellOutput(sheet, curRow, 41, !row.IsKensa11SuishitsuShushuAmtNull() ? row.Kensa11SuishitsuShushuAmt.ToString() : String.Empty );

            // 11条水質取扱件数(22)
            CellOutput(sheet, curRow, 45, !row.IsKensa11SuishitsuToriCntNull() ? row.Kensa11SuishitsuToriCnt.ToString() : String.Empty );

            // 11条水質取扱金額(23)
            CellOutput(sheet, curRow, 47, !row.IsKensa11SuishitsuToriAmtNull() ? row.Kensa11SuishitsuToriAmt.ToString() : String.Empty );

            // 11条外観件数(24)
            CellOutput(sheet, curRow, 51, !row.IsKensa11GaikanCntNull() ? row.Kensa11GaikanCnt.ToString() : String.Empty );

            // 11条外観金額(25)
            CellOutput(sheet, curRow, 53, !row.IsKensa11GaikanAmtNull() ? row.Kensa11GaikanAmt.ToString() : String.Empty );
        }
        #endregion

        #region SetChikuRyakusho
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetChikuRyakusho
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="outputSheet"></param>
        /// <param name="chikuInp"></param>
        /// <param name="isEmptyKyodoKumiai"></param>
        /// <param name="fromRow"></param>
        /// <param name="toRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetChikuRyakusho
            (
                Worksheet outputSheet,
                ISelectChikuMstByKeyDAInput chikuInp,
                bool isEmptyKyodoKumiai,
                int fromRow,
                int toRow
            )
        {
            string chikuRyakusho = string.Empty;

            if (!isEmptyKyodoKumiai)
            {
                // Execute select
                ISelectChikuMstByKeyDAOutput chikuOutp = new SelectChikuMstByKeyDataAccess().Execute(chikuInp);

                if (chikuOutp.ChikuMstDT.Count > 0)
                {
                    chikuRyakusho = chikuOutp.ChikuMstDT[0].ChikuRyakusho;
                }
            }
            else
            {
                chikuRyakusho = "福環" + Environment.NewLine + "連外";
            }

            if (fromRow < toRow - 1)
            {
                // Merge cell and output
                outputSheet.get_Range("A" + fromRow, "C" + (toRow - 1)).Merge();
            }

            // Output chikuRyakusho
            CellOutput(outputSheet, fromRow - 1, 0, chikuRyakusho);
        }
        #endregion

        #region GetDtHeader
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDtHeader
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="option"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// 2014/10/13　AnhNV　　    022_検査啓発推進費一覧_帳票設計書_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private string GetDtHeader(string option, string nendo)
        //{
        //    string dtHeader = string.Format("平成{0}年度", nendo);

        //    switch (option)
        //    {
        //        case "1": // 上下期区分/全件
        //            dtHeader += "（26年４月～２７年３月）";
        //            break;
        //        case "2": // 上下期区分/上期
        //            dtHeader += "（26年４月～２６年９月）";
        //            break;
        //        case "3": // 上下期区分/下期
        //            dtHeader += "（２６年１０月～２７年３月）";
        //            break;
        //        default:
        //            break;
        //    }

        //    return dtHeader;
        //}
        #endregion

        #region GetListConstMstByKbn005
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetListConstMstByKbn005
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private List<string> GetListConstMstByKbn005()
        {
            List<string> constLst = new List<string>();
            
            // Select ConstMst info
            ISelectConstMstInfoDAOutput constOutput = new SelectConstMstInfoDataAccess().Execute(new SelectConstMstInfoDAInput());
            ConstMstDataSet.ConstMstRow constRow001 = (ConstMstDataSet.ConstMstRow)constOutput.ConstMstDataTable.Select("ConstKbn = '005' and ConstRenban = '001'")[0];
            ConstMstDataSet.ConstMstRow constRow002 = (ConstMstDataSet.ConstMstRow)constOutput.ConstMstDataTable.Select("ConstKbn = '005' and ConstRenban = '002'")[0];
            ConstMstDataSet.ConstMstRow constRow003 = (ConstMstDataSet.ConstMstRow)constOutput.ConstMstDataTable.Select("ConstKbn = '005' and ConstRenban = '003'")[0];
            ConstMstDataSet.ConstMstRow constRow004 = (ConstMstDataSet.ConstMstRow)constOutput.ConstMstDataTable.Select("ConstKbn = '005' and ConstRenban = '004'")[0];
            ConstMstDataSet.ConstMstRow constRow005 = (ConstMstDataSet.ConstMstRow)constOutput.ConstMstDataTable.Select("ConstKbn = '005' and ConstRenban = '005'")[0];
            ConstMstDataSet.ConstMstRow constRow006 = (ConstMstDataSet.ConstMstRow)constOutput.ConstMstDataTable.Select("ConstKbn = '005' and ConstRenban = '006'")[0];
            ConstMstDataSet.ConstMstRow constRow007 = (ConstMstDataSet.ConstMstRow)constOutput.ConstMstDataTable.Select("ConstKbn = '005' and ConstRenban = '007'")[0];
            
            constLst.Add(constRow001.ConstValue);
            constLst.Add(constRow002.ConstValue);
            constLst.Add(constRow003.ConstValue);
            constLst.Add(constRow004.ConstValue);
            constLst.Add(constRow005.ConstValue);
            constLst.Add(constRow006.ConstValue);
            constLst.Add(constRow007.ConstValue);

            return constLst;
        }
        #endregion

        #region MakeSumCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSumCol
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="outputSheet"></param>
        /// <param name="fromRow"></param>
        /// <param name="toRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSumCol(Worksheet outputSheet, int fromRow, int toRow)
        {
            CellOutput(outputSheet, toRow, 11, string.Format("=sum(L{0}:L{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 13, string.Format("=sum(N{0}:N{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 17, string.Format("=sum(R{0}:R{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 19, string.Format("=sum(T{0}:T{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 23, string.Format("=sum(X{0}:X{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 25, string.Format("=sum(Z{0}:Z{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 33, string.Format("=sum(AH{0}:AH{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 35, string.Format("=sum(AJ{0}:AJ{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 39, string.Format("=sum(AN{0}:AN{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 41, string.Format("=sum(AP{0}:AP{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 45, string.Format("=sum(AT{0}:AT{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 47, string.Format("=sum(AV{0}:AV{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 51, string.Format("=sum(AZ{0}:AZ{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 53, string.Format("=sum(BB{0}:BB{1})", fromRow, toRow));
        }
        #endregion

        #region MakeGreaterSumCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeGreaterSumCol
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="outputSheet"></param>
        /// <param name="fromRow"></param>
        /// <param name="toRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeGreaterSumCol(Worksheet outputSheet, int fromRow, int toRow)
        {
            CellOutput(outputSheet, toRow, 11, string.Format("=sum(L{0},L{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 13, string.Format("=sum(N{0},N{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 17, string.Format("=sum(R{0},R{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 19, string.Format("=sum(T{0},T{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 23, string.Format("=sum(X{0},X{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 25, string.Format("=sum(Z{0},Z{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 33, string.Format("=sum(AH{0},AH{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 35, string.Format("=sum(AJ{0},AJ{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 39, string.Format("=sum(AN{0},AN{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 41, string.Format("=sum(AP{0},AP{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 45, string.Format("=sum(AT{0},AT{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 47, string.Format("=sum(AV{0},AV{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 51, string.Format("=sum(AZ{0},AZ{1})", fromRow, toRow));
            CellOutput(outputSheet, toRow, 53, string.Format("=sum(BB{0},BB{1})", fromRow, toRow));
        }
        #endregion

        #region PushEmptyKyodoKumiaiCdRowToLast
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PushEmptyKyodoKumiaiCdRowToLast
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="table"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PushEmptyKyodoKumiaiCdRowToLast(KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable table)
        {
            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow row in table)
            {
                // Replace null KyodoKumiaiCd cells with default value, it keeps current row at last of the table
				if (row.IsKyodoKumiaiCdNull() || string.IsNullOrEmpty(row.KyodoKumiaiCd.Trim()))	//受入20141224 mod  DbNull care.  KyodoKumiaiCd exists DbNull???
                {
                    row.KyodoKumiaiCd = NULL_REPLACE_STR;
                }
            }
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
            //受入20141225 mod sta
			//string fixedText = "検査啓発推進費等の支払について";
			string fixedText = "";
			//受入20141225 mod end
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
