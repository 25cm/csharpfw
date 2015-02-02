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
    //  インターフェイス名 ： IPrintMochikomiGyoshaBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintMochikomiGyoshaBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// PrintNo
        /// </summary>
        string PrintNo { get; set; }

        /// <summary>
        /// SystemDt
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListRows
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[] KensaKeihatsuSuishinListRows { get; set; }

        /// <summary>
        /// LoginNm 
        /// </summary>
        string LoginNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintMochikomiGyoshaBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintMochikomiGyoshaBLInput : BaseExcelPrintBLInputImpl, IPrintMochikomiGyoshaBLInput
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
        /// PrintNo
        /// </summary>
        public string PrintNo { get; set; }

        /// <summary>
        /// SystemDt
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListRows
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[] KensaKeihatsuSuishinListRows { get; set; }

        /// <summary>
        /// LoginNm 
        /// </summary>
        public string LoginNm { get; set; }

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintMochikomiGyoshaBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintMochikomiGyoshaBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintMochikomiGyoshaBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintMochikomiGyoshaBLOutput : BaseExcelPrintBLOutputImpl, IPrintMochikomiGyoshaBLOutput
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
    //  クラス名 ： PrintMochikomiGyoshaBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintMochikomiGyoshaBusinessLogic : BaseExcelPrintBusinessLogic<IPrintMochikomiGyoshaBLInput, IPrintMochikomiGyoshaBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintMochikomiGyoshaBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintMochikomiGyoshaBusinessLogic()
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
        /// 2014/08/21　HuyTX　　    新規作成
        /// 2014/10/17　HuyTX　　    Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintMochikomiGyoshaBLOutput SetBook(IPrintMochikomiGyoshaBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintMochikomiGyoshaBLOutput output = new PrintMochikomiGyoshaBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                ISelectHoteiKanriMstByKeyDAInput daInput = new SelectHoteiKanriMstByKeyDAInput();
                daInput.JimukyokuKbn = "0";
                ISelectHoteiKanriMstByKeyDAOutput daOutput = new SelectHoteiKanriMstByKeyDataAccess().Execute(daInput);

                int pageIdx = 1;
                int rowCount = 49;
                int shukeiNendo = 0;
                DateTime shukeiFromDt = new DateTime();
                DateTime shukeiToDt = new DateTime();
                string shukeiText = string.Empty;

                foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow printRow in input.KensaKeihatsuSuishinListRows)
                {
                    shukeiFromDt = DateTime.ParseExact(printRow.ShukeiFromNengetsu, "yyyyMM", null);
                    shukeiToDt = DateTime.ParseExact(printRow.ShukeiToNengetsu, "yyyyMM", null);
                    shukeiNendo = Utility.DateUtility.GetNendo(shukeiFromDt);

                    //画面の支払票印刷号番号(1)
                    CellOutput(outputSheet, 0, 28, "'" + input.PrintNo);

                    //システム日付 (2)
                    CellOutput(outputSheet, 1, 23, Utility.DateUtility.ConvertToWareki(input.SystemDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

                    //業者名称 (3)
					CellOutput(outputSheet, 2, 1, !printRow.IsGyoshaNmNull() ? printRow.GyoshaNm : String.Empty);	//受入20141224 mod  DbNull care.

                    //事務局代表者名 (4)
                    CellOutput(outputSheet, 5, 23, daOutput.HoteiKanriMstDataTable[0].JimukyokuDaihyoshaNm);

                    // 2014/11/10 AnhNV DEL Start
                    ////集計年月(5)
                    //if ((shukeiFromDt.Month >= 4 && shukeiFromDt.Month <= 9)
                    //    && (shukeiToDt.Month >= 4 && shukeiToDt.Month <= 9))
                    //{
                    //    shukeiText = string.Format("{0}度上半期", Utility.DateUtility.ConvertToWareki(shukeiNendo.ToString(), "gyy年", Utility.DateUtility.GengoKbn.Wareki));
                    //}
                    //else if ((shukeiFromDt.Month <= 3 || shukeiFromDt.Month >= 10)
                    //    && (shukeiToDt.Month <= 3 || shukeiToDt.Month >= 10))
                    //{
                    //    shukeiText = string.Format("{0}度下半期", Utility.DateUtility.ConvertToWareki(shukeiNendo.ToString(), "gyy年", Utility.DateUtility.GengoKbn.Wareki));
                    //}
                    //else
                    //{
                    //    shukeiText = string.Format("{0}～{1}", Utility.DateUtility.ConvertToWareki(shukeiFromDt.ToString("yyyyMM"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki),
                    //                                            Utility.DateUtility.ConvertToWareki(shukeiToDt.ToString("yyyyMM"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki));
                    //}
                    // 2014/11/10 AnhNV DEL End

                    // 2014/11/10 AnhNV ADD Start
                    shukeiText = GetShukeiText(shukeiFromDt, shukeiToDt, shukeiNendo);
                    // 2014/11/10 AnhNV ADD End

                    //CellOutput(outputSheet, 9, 0, string.Format("{0}検査啓発推進費等の支払について", shukeiText));
                    CellOutput(outputSheet, 9, 0, shukeiText);

                    //11条水質持込単価 (6)
                    CellOutput(outputSheet, 24, 10, !printRow.IsKensa11SuishitsuMochiUpNull() ? printRow.Kensa11SuishitsuMochiUp.ToString() : string.Empty);

                    //11条外観単価 (7)
                    CellOutput(outputSheet, 27, 10, !printRow.IsKensa11GaikanUpNull() ? printRow.Kensa11GaikanUp.ToString() : string.Empty);

                    //計量証明持込単価 (8)
                    CellOutput(outputSheet, 30, 10, !printRow.IsKeiryoShomeiMochiUpNull() ? printRow.KeiryoShomeiMochiUp.ToString() : string.Empty);

                    //11条水質持込件数 (9)
                    CellOutput(outputSheet, 24, 17, !printRow.IsKensa11SuishitsuMochiCntNull() ? printRow.Kensa11SuishitsuMochiCnt.ToString() : string.Empty);

                    //11条外観件数 (10)
                    CellOutput(outputSheet, 27, 17, !printRow.IsKensa11GaikanCntNull() ? printRow.Kensa11GaikanCnt.ToString() : string.Empty);

                    //計量証明持込件数 (11)
                    CellOutput(outputSheet, 30, 17, !printRow.IsKeiryoShomeiMochiCntNull() ? printRow.KeiryoShomeiMochiCnt.ToString() : string.Empty);

                    //11条水質持込金額 (12)
                    CellOutput(outputSheet, 24, 23, !printRow.IsKensa11SuishitsuMochiAmtNull() ? printRow.Kensa11SuishitsuMochiAmt.ToString() : string.Empty);

                    //11条外観金額 (13)
                    CellOutput(outputSheet, 27, 23, !printRow.IsKensa11GaikanAmtNull() ? printRow.Kensa11GaikanAmt.ToString() : string.Empty);

                    //計量証明持込金額 (14)
                    CellOutput(outputSheet, 30, 23, !printRow.IsKeiryoShomeiMochiAmtNull() ? printRow.KeiryoShomeiMochiAmt.ToString() : string.Empty);

                    //支払合計 (15)
                    CellOutput(outputSheet, 33, 23, !printRow.IsShiharaiTotalNull() ? printRow.ShiharaiTotal.ToString() : string.Empty);

                    //職員名 (16)
                    CellOutput(outputSheet, 43, 23, input.LoginNm);

                    //事務局電話番号 (17)
                    CellOutput(outputSheet, 44, 20, daOutput.HoteiKanriMstDataTable[0].JimukyokuTelNo);

                    CopyRow(outputSheet, 0, rowCount - 1, rowCount * pageIdx);
                    outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[(rowCount * pageIdx) + 1, 1]);
                    pageIdx++;
                    
                }

                //delete first page
                DeleteRow(outputSheet, 0, rowCount);
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

        #region メソッド(private)

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
