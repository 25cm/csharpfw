using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKaiinInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKaiinInfoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KaiinPrintInfoDataTable
        /// </summary>
        GyoshaBukaiMstDataSet.KaiinPrintInfoDataTable KaiinPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKaiinInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKaiinInfoBLInput : BaseExcelPrintBLInputImpl, IPrintKaiinInfoBLInput
    {
        ///// <summary>
        ///// 保存ファイルモード
        ///// </summary>
        //public int SaveFileMode
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// ＥＸＣＥＬ書式へのパス
        ///// </summary>
        //public string FormatPath
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 帳票ディレクトリパス
        ///// </summary>
        //public string PrintDirectory
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 指定保存パス
        ///// 未指定の場合は、帳票出力ディレクトリに出力されます
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 処理後ＥＸＣＥＬ表示フラグ
        ///// </summary>
        //public bool AfterDispFlg
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 処理後印刷フラグ
        ///// </summary>
        //public bool AfterPrintFlg { get; set; }

        ///// <summary>
        ///// 印刷プリンタ名
        ///// </summary>
        //public string PrinterName { get; set; }

        /// <summary>
        /// KaiinPrintInfoDataTable
        /// </summary>
        public GyoshaBukaiMstDataSet.KaiinPrintInfoDataTable KaiinPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKaiinInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKaiinInfoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKaiinInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKaiinInfoBLOutput : BaseExcelPrintBLOutputImpl, IPrintKaiinInfoBLOutput
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
    //  クラス名 ： PrintKaiinInfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKaiinInfoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKaiinInfoBLInput, IPrintKaiinInfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKaiinInfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKaiinInfoBusinessLogic()
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
        /// 2014/08/06　HuyTX　　    新規作成
        /// 2014/10/13　HuyTX　　    Ver1.01
        /// 2015/01/30　HuyTX　　    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKaiinInfoBLOutput SetBook(IPrintKaiinInfoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKaiinInfoBLOutput output = new PrintKaiinInfoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                //outputSheet = (Worksheet)book.Sheets["Sheet1"];
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
                bool isOutput = false;

                // Ver1.04 Mod Start
                //foreach (GyoshaBukaiMstDataSet.KaiinPrintInfoRow row in input.KaiinPrintInfoDataTable)
                for (int i = 0; i < input.KaiinPrintInfoDataTable.Count; i++)
                {
                    GyoshaBukaiMstDataSet.KaiinPrintInfoRow preRow = input.KaiinPrintInfoDataTable[i > 1 ? (i - 1) : 0];
                    GyoshaBukaiMstDataSet.KaiinPrintInfoRow printRow = input.KaiinPrintInfoDataTable[i];

                    //if (i == 0 || printRow.GyoshaC)
                    //{

                    //}
                    tempSheet.Copy(tempSheet, Type.Missing);
                    outputSheet = (Worksheet)book.ActiveSheet;
                    //outputSheet.Name = row.GyoshaNm;

                }
                // Ver1.04 Mod End

                //事務局代表者名 (1)
                CellOutput(outputSheet, 6, 5, input.KaiinPrintInfoDataTable[0].JimukyokuDaihyoshaNm);

                //システム日付 (2)
                // 20140811 habu Aggregated Hoshou Toroku No Convertion To Date Utility
                CellOutput(outputSheet, 4, 26, Utility.DateUtility.ConvertToWareki(currentDateTime.Year.ToString(), "y"));
                //CellOutput(outputSheet, 4, 26, Utility.Utility.ConvertToHeisei(currentDateTime.Year));
                // 20140811 habu End

                CellOutput(outputSheet, 4, 29, "'" + currentDateTime.ToString("MM"));
                CellOutput(outputSheet, 4, 32, "'" + currentDateTime.ToString("dd"));

                //業者住所 (3)
                CellOutput(outputSheet, 8, 23, input.KaiinPrintInfoDataTable[0].GyoshaAdr);

                //業者名称  (4)
                CellOutput(outputSheet, 10, 23, input.KaiinPrintInfoDataTable[0].GyoshaNm);

                //代表者氏名 (5)
                CellOutput(outputSheet, 11, 23, input.KaiinPrintInfoDataTable[0].DaihyoshaNm);

                //業者電話番号 (6)
                CellOutput(outputSheet, 12, 23, input.KaiinPrintInfoDataTable[0].GyoshaTelNo);

                //業者Fax番号 (7)
                CellOutput(outputSheet, 13, 23, input.KaiinPrintInfoDataTable[0].GyoshaFaxNo);

                foreach (GyoshaBukaiMstDataSet.KaiinPrintInfoRow rowPrint in input.KaiinPrintInfoDataTable)
                {
                    if (!string.IsNullOrEmpty(rowPrint.BukaiNyukaiDt.Trim())
                        && string.IsNullOrEmpty(rowPrint.BukaiTaikaiDt.Trim()))
                    {
                        isOutput = true;
                    }

                    switch (rowPrint.BukaiKbn)
                    {
                        case "1":
                            if (isOutput) { CellOutput(outputSheet, 18, 6, "〇"); }
                            break;

                        case "2":
                            if (isOutput)
                            {
                                CellOutput(outputSheet, 19, 6, "〇");
                                //設備士代表者氏名（管理管士）& 免状番号 (12)
                                CellOutput(outputSheet, 20, 15, rowPrint.BukaiSetsubishiDaihyoshaNm + "\n" + rowPrint.BukaiMenJoNo);

                                //関係保健所１～１５ (13)
                                CellOutput(outputSheet, 20, 22, rowPrint.BukaiKankeiHokenjo);
                            }
                            break;

                        case "3":
                            if (isOutput)
                            {
                                CellOutput(outputSheet, 21, 6, "〇");

                                //設備士代表者氏名（管理管士）& 免状番号 (14)
                                CellOutput(outputSheet, 22, 15, rowPrint.BukaiSetsubishiDaihyoshaNm + "\n" + rowPrint.BukaiMenJoNo);

                                //関係保健所１～１５ (15)
                                CellOutput(outputSheet, 22, 22, rowPrint.BukaiKankeiHokenjo);
                            }
                            
                            break;

                        case "4":
                            if (isOutput)
                            {
                                CellOutput(outputSheet, 23, 6, "〇");

                                //担当市町村１～１０ (16)
                                CellOutput(outputSheet, 24, 15, rowPrint.BukaiTantoShichoson);
                            }
                            break;

                        default:
                            break;
                    }

                    isOutput = false;
                }

                //事務局FAX番号 (17)
                CellOutput(outputSheet, 31, 12, input.KaiinPrintInfoDataTable[0].JimukyokuFaxNo);
            }
            catch (Exception)
            {
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

    }
    #endregion
}
