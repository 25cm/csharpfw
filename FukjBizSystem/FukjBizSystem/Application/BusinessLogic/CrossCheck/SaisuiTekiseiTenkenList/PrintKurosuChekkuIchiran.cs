using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKurosuChekkuIchiranBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKurosuChekkuIchiranBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKurosuChekkuIchiranBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKurosuChekkuIchiranBLInput : BaseExcelPrintBLInputImpl, IPrintKurosuChekkuIchiranBLInput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKurosuChekkuIchiranBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKurosuChekkuIchiranBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKurosuChekkuIchiranBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKurosuChekkuIchiranBLOutput : IPrintKurosuChekkuIchiranBLOutput
    {
        /// <summary>
        /// 保存パス
        /// </summary>
        public string SavePath
        {
            get;
            set;
        }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKurosuChekkuIchiranBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKurosuChekkuIchiranBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKurosuChekkuIchiranBLInput, IPrintKurosuChekkuIchiranBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKurosuChekkuIchiranBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKurosuChekkuIchiranBusinessLogic()
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
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKurosuChekkuIchiranBLOutput SetBook(IPrintKurosuChekkuIchiranBLInput input, Excel.Workbook book)
        {
            IPrintKurosuChekkuIchiranBLOutput output = new PrintKurosuChekkuIchiranBLOutput();

            Excel.Application application = null;
            Excel.Worksheet outputSheet = null;
            Excel.Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Current process row
                int curRow = 13;
                // Sheet counter
                int sheetCnt = 0;
                // Row No.
                int rowNo = 16;
                // Paginator variables
                string tempShishoKbn = null;
                string tempMochikomiDtYear = null;
                string tempMochikomiDtMonth = null;

                foreach (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row
                    in input.PrintTable.Select(string.Empty, "KensaIraiUketsukeShishoKbn, ThisDate, KensaIraiSaisuiinCd"))
                {
                    // New page?
                    string mochikomiDtYear = row.ThisDate.Length == 10 ? row.ThisDate.Substring(0, 4) : string.Empty;
                    string mochikomiDtMonth = row.ThisDate.Length == 10 ? row.ThisDate.Substring(5, 2) : string.Empty;
                    if (tempShishoKbn != row.KensaIraiUketsukeShishoKbn // Next page
                        || tempMochikomiDtYear != mochikomiDtYear
                        || tempMochikomiDtMonth != mochikomiDtMonth)
                    {
                        // A new sheet is set
                        sheetCnt++;
                        curRow = 13;
                        rowNo = 16;

                        // Copy a new sheet
                        tempSheet = (Excel.Worksheet)book.Sheets["Sheet1"];
                        tempSheet.Copy(tempSheet, Type.Missing);
                        outputSheet = (Excel.Worksheet)book.ActiveSheet;
                        outputSheet.Name = "クロスチェック_調査一覧表_" + sheetCnt;

                        // Header
                        SetHeader(outputSheet, row);
                    }

                    // Detail
                    SetDetail(outputSheet, row, curRow);

                    // Reset the paginator
                    tempShishoKbn = row.KensaIraiUketsukeShishoKbn;
                    tempMochikomiDtYear = mochikomiDtYear;
                    tempMochikomiDtMonth = mochikomiDtMonth;
                    // Next row
                    curRow += 2;

                    // 15 rows overflow
                    if (curRow >= 43) // Last row in page
                    {
                        CopyRow(outputSheet, 41, 2, curRow);
                        CellOutput(outputSheet, curRow, 0, rowNo);

                        rowNo++;
                    }
                }

                // More than 1 sheet?
                if (book.Sheets.Count > 1)
                {
                    tempSheet.Delete();
                }
                else if (book.Sheets.Count == 2) // 1 sheet is printed only
                {
                    outputSheet.Name = "クロスチェック_調査一覧表";
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
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SetHeader
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetHeader
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader
        (
            Excel.Worksheet sheet,
            KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row
        )
        {
            int count04 = 0;
            int count05 = 0;
            int count06 = 0;
            int count07 = 0;
            double avg08 = 0;
            double avg09 = 0;

            ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput crsInput = new SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput();
            crsInput.KensaIraiUketsukeShishoKbn = row.KensaIraiUketsukeShishoKbn;
            crsInput.KensaKekkaMochikomiDt = row.ThisDate.Replace("/", string.Empty);
            ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput crsOutput = new SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDataAccess().Execute(crsInput);
            count04 = crsOutput.KurosuCheckuIchiranDataTable.Rows.Count;
            count06 = crsOutput.KurosuCheckuIchiranDataTable.Select("KensaIraiCrossCheckHantei > '0'").Length;
            avg08 = count04 > 0 ? (double)count06 / count04 : 0;
            Math.Round(avg08, 1);

            ISelectKensaIraiTblByShishoKbnNendoDAInput kitInput = new SelectKensaIraiTblByShishoKbnNendoDAInput();
            kitInput.KensaIraiUketsukeShishoKbn = row.KensaIraiUketsukeShishoKbn;
            kitInput.KensaIraiNendo = row.ThisDate.Length > 4 ? row.ThisDate.Substring(0, 4) : string.Empty;
            ISelectKensaIraiTblByShishoKbnNendoDAOutput kitOutput = new SelectKensaIraiTblByShishoKbnNendoDataAccess().Execute(kitInput);
            count05 = kitOutput.KensaIraiTblDataTable.Rows.Count;
            count07 = kitOutput.KensaIraiTblDataTable.Select("KensaIraiCrossCheckHantei > '0'").Length;
            avg09 = count05 > 0 ? (double)count07 / count05 : 0;
            Math.Round(avg09, 1);

            // (1)
            CellOutput(sheet, 3, 43, row.ShishoNm);
            // (2)
            CellOutput(sheet, 4, 46, row.ShishoChoNm);
            // (3)
            string mochikomiDt = Utility.DateUtility.ConvertToWareki(row.ThisDate.Replace("/", string.Empty), "(gyy年MM月度)", Utility.DateUtility.GengoKbn.Wareki);
            CellOutput(sheet, 4, 15, mochikomiDt);
            // (4)
            CellOutput(sheet, 8, 7, count04);
            // (5)
            CellOutput(sheet, 8, 12, count05);
            // (6)
            CellOutput(sheet, 8, 20, count06);
            // (7)
            CellOutput(sheet, 8, 25, count07);
            // (8)
            CellOutput(sheet, 8, 33, avg08);
            // (9)
            CellOutput(sheet, 8, 38, avg09);
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow">Starting of detail row</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail
        (
            Excel.Worksheet sheet,
            KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row,
            int curRow
        )
        {
            // EXCEL position - SCREEN position
            // (10) - (14)
            CellOutput(sheet, curRow, 1, "'" + row.KensaKekkaSuishitsuIraiNo);
            // (11) - (15)
            CellOutput(sheet, curRow + 1, 1, row.HanteiCol);
            // (12) -(21)
            CellOutput(sheet, curRow, 4, row.SaisuiinNameCol);
            // (13) - (22)
            CellOutput(sheet, curRow + 1, 4, row.ShozokuGyoushaCol);
            // (14) - (23)
            CellOutput(sheet, curRow, 8, row.ShoriHoushikiNmCol);
            // (15) - (25)
            if (!row.IsKensaIraiShoriTaishoJininNull())
            {
                CellOutput(sheet, curRow, 10, row.KensaIraiShoriTaishoJinin);
            }
            // (16) - (26)
            if (!row.IsPHColNull())
            {
                CellOutput(sheet, curRow, 11, row.PHCol);
            }
            // (17) - (27)
            if (!row.IsBODColNull())
            {
                CellOutput(sheet, curRow + 1, 11, row.BODCol);
            }
            // (18) - (39)
            if (!row.IsAverageValueColNull())
            {
                CellOutput(sheet, curRow, 13, row.AverageValueCol);
            }
            // (19) - (40)
            if (!row.IsThisValueNull())
            {
                CellOutput(sheet, curRow + 1, 13, row.ThisValue);
            }
            // (20) - (51), (41)
            if (!row.IsPastValue1ColNull())
            {
                CellOutput(sheet, curRow, 15, row.PastValue1Col);
            }
            CellOutput(sheet, curRow + 1, 15, GetKbnStringByKbn(row.PastHoteiKbn1Col));
            // (21) - (62), (52)
            if (!row.IsPastValue2ColNull())
            {
                CellOutput(sheet, curRow, 17, row.PastValue2Col);
            }
            CellOutput(sheet, curRow + 1, 17, GetKbnStringByKbn(row.PastHoteiKbn2Col));
            // (22) - (73), (63)
            if (!row.IsPastValue3ColNull())
            {
                CellOutput(sheet, curRow, 19, row.PastValue3Col);
            }
            CellOutput(sheet, curRow + 1, 19, GetKbnStringByKbn(row.PastHoteiKbn3Col));
            // (23) - (84), (74)
            if (!row.IsPastValue4ColNull())
            {
                CellOutput(sheet, curRow, 21, row.PastValue4Col);
            }
            CellOutput(sheet, curRow + 1, 21, GetKbnStringByKbn(row.PastHoteiKbn4Col));
            // (24) - (95), (85)
            if (!row.IsPastValue5ColNull())
            {
                CellOutput(sheet, curRow, 23, row.PastValue5Col);
            }
            CellOutput(sheet, curRow + 1, 23, GetKbnStringByKbn(row.PastHoteiKbn5Col));
            // (25) - (96)
            CellOutput(sheet, curRow, 25, row.KakuninSuuCol);
            // (26) - (97)
            CellOutput(sheet, curRow + 1, 25, row.SoSuuCol);
            // (27) - (98)
            if (!row.IsHasseiRateColNull())
            {
                CellOutput(sheet, curRow, 28, row.HasseiRateCol / 100);
            }
            // (28) - (17)
            CellOutput(sheet, curRow, 31, row.GaiyouCol);
            // (29) - (18)
            CellOutput(sheet, curRow + 1, 31, row.KikitoriTokkijiko);
            // (30) - (19)
            CellOutput(sheet, curRow, 39, row.TatemonoYoutoCol);
            // (31) - (20)
            CellOutput(sheet, curRow, 45, Utility.DateUtility.ConvertToWareki(row.KikitoriSeisobi.Replace("/", string.Empty), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.WarekiEiRyaku));
        }
        #endregion

        #region GetKbnStringByKbn
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetKbnStringByKbn
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetKbnStringByKbn(string kbn)
        {
            string kbnStr = string.Empty;

            switch (kbn)
            {
                case "1":
                    kbnStr = "７条";
                    break;
                case "2":
                    kbnStr = "１１条外";
                    break;
                case "3":
                default:
                    break;
            }

            return kbnStr;
        }
        #endregion

        #endregion
    }
    #endregion
}
