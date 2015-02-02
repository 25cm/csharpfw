using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKurosuChekkuHokokuBLInput
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
    interface IPrintKurosuChekkuHokokuBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKurosuChekkuHokokuBLInput
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
    class PrintKurosuChekkuHokokuBLInput : BaseExcelPrintBLInputImpl, IPrintKurosuChekkuHokokuBLInput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKurosuChekkuHokokuBLOutput
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
    interface IPrintKurosuChekkuHokokuBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKurosuChekkuHokokuBLOutput
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
    class PrintKurosuChekkuHokokuBLOutput : IPrintKurosuChekkuHokokuBLOutput
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
    //  クラス名 ： PrintKurosuChekkuHokokuBusinessLogic
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
    class PrintKurosuChekkuHokokuBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKurosuChekkuHokokuBLInput, IPrintKurosuChekkuHokokuBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKurosuChekkuHokokuBusinessLogic
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
        public PrintKurosuChekkuHokokuBusinessLogic()
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
        protected override IPrintKurosuChekkuHokokuBLOutput SetBook(IPrintKurosuChekkuHokokuBLInput input, Excel.Workbook book)
        {
            IPrintKurosuChekkuHokokuBLOutput output = new PrintKurosuChekkuHokokuBLOutput();

            Excel.Application application = null;
            Excel.Worksheet outputSheet = null;
            Excel.Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Copy a new sheet
                outputSheet = (Excel.Worksheet)book.Sheets[1];
                outputSheet.Name = "クロスチェック_調査報告書";

                foreach (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row in input.PrintTable)
                {
                    // EXCEL - SCREEN items
                    // (1)
                    CellOutput(outputSheet, 0, 72, row.ShishoNm + "　事例");
                    // (2) - (15)
                    CellOutput(outputSheet, 7, 11, GetHanteiString(row.KensaIraiCrossCheckHantei));
                    // (3) - (14)
                    CellOutput(outputSheet, 9, 11, "'" + row.KensaKekkaSuishitsuIraiNo);
                    // (4) - (31)
                    CellOutput(outputSheet, 11, 15, Utility.DateUtility.ConvertToWareki(row.ThisDate.Replace("/", string.Empty), "yy"));
                    CellOutput(outputSheet, 11, 20, Utility.DateUtility.ConvertToWareki(row.ThisDate.Replace("/", string.Empty), "MM"));
                    CellOutput(outputSheet, 11, 25, Utility.DateUtility.ConvertToWareki(row.ThisDate.Replace("/", string.Empty), "dd"));
                    // (5)
                    CellOutput(outputSheet, 13, 11, row.ShozokuGyoushaCol);
                    // (6)
                    CellOutput(outputSheet, 15, 11, row.SaisuiinNameCol);
                    // (7) - (20)
                    CellOutput(outputSheet, 17, 15, Utility.DateUtility.ConvertToWareki(row.KikitoriSeisobi.Replace("/", string.Empty), "yy"));
                    CellOutput(outputSheet, 17, 20, Utility.DateUtility.ConvertToWareki(row.KikitoriSeisobi.Replace("/", string.Empty), "MM"));
                    CellOutput(outputSheet, 17, 25, Utility.DateUtility.ConvertToWareki(row.KikitoriSeisobi.Replace("/", string.Empty), "dd"));
                    // (8)
                    CellOutput(outputSheet, 21, 11, row.Name);
                    // (9)
                    CellOutput(outputSheet, 7, 50, row.KensaIraiSetchishaNm);
                    // (10)
                    if (Utility.Utility.IsZipCode(row.KensaIraiSetchishaZipCd))
                    {
                        char[] zipParts = row.KensaIraiSetchishaZipCd.ToCharArray();
                        CellOutput(outputSheet, 7, 80, zipParts[0].ToString());
                        CellOutput(outputSheet, 7, 82, zipParts[1].ToString());
                        CellOutput(outputSheet, 7, 84, zipParts[2].ToString());
                        CellOutput(outputSheet, 7, 88, zipParts[4].ToString());
                        CellOutput(outputSheet, 7, 90, zipParts[5].ToString());
                        CellOutput(outputSheet, 7, 92, zipParts[6].ToString());
                        CellOutput(outputSheet, 7, 94, zipParts[7].ToString());
                    }
                    // (11)
                    CellOutput(outputSheet, 9, 50, row.KensaIraiSetchishaAdr);
                    // (12)
                    CellOutput(outputSheet, 11, 50, row.KensaIraiSetchibashoAdr);
                    // (13) - (19)
                    CellOutput(outputSheet, 13, 50, row.TatemonoYoutoCol);
                    // (14)
                    CellOutput(outputSheet, 15, 50, row.MekaGyoshaNm);
                    // (15)
                    CellOutput(outputSheet, 17, 54, row.ShoriHoushikiNmCol);
                    // (16)
                    CellOutput(outputSheet, 17, 93, row.Jokaso3JiShoriFlg);
                    // (17)
                    if (!row.IsKensaIraiShoriTaishoJininNull())
                    {
                        CellOutput(outputSheet, 19, 65, row.KensaIraiShoriTaishoJinin);
                    }
                    // (18) - (32)
                    if (!row.IsThisPHNull())
                    {
                        CellOutput(outputSheet, 30, 28, row.ThisPH);
                    }
                    {
                        // (19) - (33), (34)
                        string yozonFrom = row.IsThisYozonSansoRyoFromNull() ? string.Empty : Convert.ToString(row.ThisYozonSansoRyoFrom);
                        string yozonTo = row.IsThisYozonSansoRyoToNull() ? string.Empty : Convert.ToString(row.ThisYozonSansoRyoTo);
                        CellOutput(outputSheet, 32, 28, GetRangeString(yozonFrom, yozonTo));
                        // (20) - (35), (36)
                        string toshido = row.IsThisToshidoNull() ? string.Empty : Convert.ToString(row.ThisToshido);
                        CellOutput(outputSheet, 34, 28,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, toshido, row.ThisToshidoHani));
                        // (21) - (40)
                        if (!row.IsThisValueNull())
                        {
                            CellOutput(outputSheet, 36, 28, row.ThisValue);
                        }
                        // (22) - (37), (38)
                        string thisBOD = row.IsThisBODNull() ? string.Empty : Convert.ToString(row.ThisBOD);
                        CellOutput(outputSheet, 38, 28,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, thisBOD, row.ThisBODHani));
                    }

                    #region 過去１
                    {
                        // (23) - (42)
                        CellOutput(outputSheet, 28, 40, Utility.DateUtility.ConvertToWareki(row.PastDate1Col.Replace("/", string.Empty), "yy"));
                        CellOutput(outputSheet, 28, 46, Utility.DateUtility.ConvertToWareki(row.PastDate1Col.Replace("/", string.Empty), "MM"));
                        // (24) - (43)
                        CellOutput(outputSheet, 30, 40, row.IsPastPH1ColNull() || row.PastPH1Col == 0 ? "－" : Convert.ToString(row.PastPH1Col));
                        // (25) - (44), (45)
                        string yozonFrom = row.IsPastYozonSansoRyoFrom1ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoFrom1Col);
                        string yozonTo = row.IsPastYozonSansoRyoTo1ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoTo1Col);
                        CellOutput(outputSheet, 32, 40, GetRangeString(yozonFrom, yozonTo));
                        // (26) - (46), (47)
                        string toshido = row.IsPastToshido1ColNull() ? string.Empty : Convert.ToString(row.PastToshido1Col);
                        CellOutput(outputSheet, 34, 40,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, toshido, row.PastToshidoHani1Col));
                        // (27) - (51)
                        CellOutput(outputSheet, 36, 40, row.IsPastValue1ColNull() || row.PastValue1Col == 0 ? "－" : Convert.ToString(row.PastValue1Col));
                        // (28) - (48), (49)
                        string bod = row.IsPastBOD1ColNull() ? string.Empty : Convert.ToString(row.PastBOD1Col);
                        CellOutput(outputSheet, 38, 40,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, bod, row.PastBODHani1Col));
                        // (29) - (41)
                        CellOutput(outputSheet, 40, 40, GetHoteiKbnStringByKbn(row.PastHoteiKbn1Col));
                    }
                    #endregion

                    #region 過去２
                    {
                        // (30) - (53)
                        CellOutput(outputSheet, 28, 52, Utility.DateUtility.ConvertToWareki(row.PastDate2Col.Replace("/", string.Empty), "yy"));
                        CellOutput(outputSheet, 28, 58, Utility.DateUtility.ConvertToWareki(row.PastDate2Col.Replace("/", string.Empty), "MM"));
                        // (31) - (54)
                        CellOutput(outputSheet, 30, 52, row.IsPastPH2ColNull() || row.PastPH2Col == 0 ? "－" : Convert.ToString(row.PastPH2Col));
                        // (32) - (55), (56)
                        string yozonFrom = row.IsPastYozonSansoRyoFrom2ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoFrom2Col);
                        string yozonTo = row.IsPastYozonSansoRyoTo2ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoTo2Col);
                        CellOutput(outputSheet, 32, 52, GetRangeString(yozonFrom, yozonTo));
                        // (33) - (57), (58)
                        string toshido = row.IsPastToshido2ColNull() ? string.Empty : Convert.ToString(row.PastToshido2Col);
                        CellOutput(outputSheet, 34, 52,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, toshido, row.PastToshidoHani2Col));
                        // (34) - (62)
                        CellOutput(outputSheet, 36, 52, row.IsPastValue2ColNull() || row.PastValue2Col == 0 ? "－" : Convert.ToString(row.PastValue2Col));
                        // (35) - (59), (60)
                        string bod = row.IsPastBOD2ColNull() ? string.Empty : Convert.ToString(row.PastBOD2Col);
                        CellOutput(outputSheet, 38, 52,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, bod, row.PastBODHani2Col));
                        // (36) - (52)
                        CellOutput(outputSheet, 40, 52, GetHoteiKbnStringByKbn(row.PastHoteiKbn2Col));
                    }
                    #endregion

                    #region 過去３
                    {
                        // (37) - (64)
                        CellOutput(outputSheet, 28, 64, Utility.DateUtility.ConvertToWareki(row.PastDate3Col.Replace("/", string.Empty), "yy"));
                        CellOutput(outputSheet, 28, 70, Utility.DateUtility.ConvertToWareki(row.PastDate3Col.Replace("/", string.Empty), "MM"));
                        // (38) - (65)
                        CellOutput(outputSheet, 30, 64, row.IsPastPH3ColNull() || row.PastPH3Col == 0 ? "－" : Convert.ToString(row.PastPH3Col));
                        // (39) - (66), (67)
                        string yozonFrom = row.IsPastYozonSansoRyoFrom3ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoFrom3Col);
                        string yozonTo = row.IsPastYozonSansoRyoTo3ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoTo3Col);
                        CellOutput(outputSheet, 32, 64, GetRangeString(yozonFrom, yozonTo));
                        // (40) - (68), (69)
                        string toshido = row.IsPastToshido3ColNull() ? string.Empty : Convert.ToString(row.PastToshido3Col);
                        CellOutput(outputSheet, 34, 64,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, toshido, row.PastToshidoHani3Col));
                        // (41) - (73)
                        CellOutput(outputSheet, 36, 64, row.IsPastValue3ColNull() || row.PastValue3Col == 0 ? "－" : Convert.ToString(row.PastValue3Col));
                        // (42) - (70), (71)
                        string bod = row.IsPastBOD3ColNull() ? string.Empty : Convert.ToString(row.PastBOD3Col);
                        CellOutput(outputSheet, 38, 64,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, bod, row.PastBODHani3Col));
                        // (43) - (63)
                        CellOutput(outputSheet, 40, 64, GetHoteiKbnStringByKbn(row.PastHoteiKbn3Col));
                    }
                    #endregion

                    #region 過去４
                    {
                        // (44) - (75)
                        CellOutput(outputSheet, 28, 76, Utility.DateUtility.ConvertToWareki(row.PastDate4Col.Replace("/", string.Empty), "yy"));
                        CellOutput(outputSheet, 28, 82, Utility.DateUtility.ConvertToWareki(row.PastDate4Col.Replace("/", string.Empty), "MM"));
                        // (45) - (76)
                        CellOutput(outputSheet, 30, 76, row.IsPastPH4ColNull() || row.PastPH4Col == 0 ? "－" : Convert.ToString(row.PastPH4Col));
                        // (46) - (77), (78)
                        string yozonFrom = row.IsPastYozonSansoRyoFrom4ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoFrom4Col);
                        string yozonTo = row.IsPastYozonSansoRyoTo4ColNull() ? string.Empty : Convert.ToString(row.PastYozonSansoRyoTo4Col);
                        CellOutput(outputSheet, 32, 76, GetRangeString(yozonFrom, yozonTo));
                        // (47) - (79), (80)
                        string toshido = row.IsPastToshido4ColNull() ? string.Empty : Convert.ToString(row.PastToshido4Col);
                        CellOutput(outputSheet, 34, 76,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, toshido, row.PastToshidoHani4Col));
                        // (48) - (84)
                        CellOutput(outputSheet, 36, 76, row.IsPastValue4ColNull() || row.PastValue4Col == 0 ? "－" : Convert.ToString(row.PastValue4Col));
                        // (49) - (81), (82)
                        string bod = row.IsPastBOD4ColNull() ? string.Empty : Convert.ToString(row.PastBOD4Col);
                        CellOutput(outputSheet, 38, 76,
                            ConcatAsConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_027, bod, row.PastBODHani4Col));
                        // (50) - (74)
                        CellOutput(outputSheet, 40, 76, GetHoteiKbnStringByKbn(row.PastHoteiKbn4Col));
                    }
                    #endregion
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

        #region GetHanteiString
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetHanteiString
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="hanteiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetHanteiString(string hanteiKbn)
        {
            string res = string.Empty;

            switch (hanteiKbn)
            {
                case "1":
                    res = "処理方式";
                    break;
                case "2":
                    res = "過去との乖離";
                    break;
                case "3":
                    res = "処理方式、過去との乖離";
                    break;
                default:
                    break;
            }

            return res;
        }
        #endregion

        #region GetRangeString
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetRangeString
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetRangeString(string from, string to)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                result = from;
            }

            if (string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                result = to;
            }

            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                result = from + "～" + to;
            }

            if ((string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
                || (from == "0" && to == "0"))
            {
                result = "－";
            }

            return result;
        }
        #endregion

        #region ConcatAsConstNm
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： ConcatAsConstNm
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="constKbn"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string ConcatAsConstNm(string constKbn, string str1, string str2)
        {
            if ((string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2))
                || (str1 == "0" && str2 == "0"))
            {
                return "－";
            }

            string res = string.Empty;
            res = str1 + Boundary.Common.Common.GetConstNmByKbnValue(constKbn, str2);

            return res;
        }
        #endregion

        #region GetHoteiKbnStringByKbn
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetHoteiKbnStringByKbn
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
        private string GetHoteiKbnStringByKbn(string kbn)
        {
            string res = string.Empty;

            switch (kbn)
            {
                case "1":
                case "2":
                    res = "●検査員";
                    break;
                case "3":
                    res = "採水員";
                    break;
                default:
                    break;
            }

            return res;
        }
        #endregion

        #endregion
    }
    #endregion
}
