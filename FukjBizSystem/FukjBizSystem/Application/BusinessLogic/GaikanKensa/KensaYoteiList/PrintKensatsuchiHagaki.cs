using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaYoteiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensatsuchiHagakiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensatsuchiHagakiBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensaYoteiListDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaYoteiListDataTable KensaYoteiListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensatsuchiHagakiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensatsuchiHagakiBLInput : BaseExcelPrintBLInputImpl, IPrintKensatsuchiHagakiBLInput
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
        /// KensaYoteiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaYoteiListDataTable KensaYoteiListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensatsuchiHagakiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensatsuchiHagakiBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensatsuchiHagakiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensatsuchiHagakiBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensatsuchiHagakiBLOutput
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
    //  クラス名 ： PrintKensatsuchiHagakiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensatsuchiHagakiBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensatsuchiHagakiBLInput, IPrintKensatsuchiHagakiBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// ROW_COUNT_HEADER 
        /// </summary>
        //private const int ROW_COUNT_HEADER = 30;
        private const int ROW_COUNT_HEADER = 29;

        /// <summary>
        /// ROW_IDX_FOOTER_JO11 
        /// </summary>
        //private const int ROW_IDX_FOOTER_JO11 = 30;
        private const int ROW_IDX_FOOTER_JO11 = 29;

        /// <summary>
        /// ROW_IDX_FOOTER_JO7
        /// </summary>
        //private const int ROW_IDX_FOOTER_JO7 = 66;
        private const int ROW_IDX_FOOTER_JO7 = 65;

        /// <summary>
        /// ROW_COUNT_FOOTER 
        /// </summary>
        //private const int ROW_COUNT_FOOTER = 35;
        private const int ROW_COUNT_FOOTER = 36;

        /// <summary>
        /// PASTE_ROW_START 
        /// </summary>
        //private const int PASTE_ROW_START = 102;
        private const int PASTE_ROW_START = 103;

        /// <summary>
        /// JO7_ANNAI_TEXT 
        /// </summary>
        private const string JO7_ANNAI_TEXT = "浄化槽の法定検査(７条検査)実施のご案内";

        /// <summary>
        /// JO11_ANNAI_TEXT 
        /// </summary>
        private const string JO11_ANNAI_TEXT = "浄化槽の法定検査(１１条検査)実施のご案内";

        /// <summary>
        /// MSG_7JO1_TEXT 
        /// </summary>
        private const string MSG_7JO1_TEXT = "浄化槽設置届時にあなたが設置された浄化槽の検査依頼がありました。\nつきましては、下記検査日に浄化槽第７条に基づく法定検査を実施する予定ですので、お知らせいたします。";

        /// <summary>
        /// MSG_7JO2_TEXT 
        /// </summary>
        private const string MSG_7JO2_TEXT = "{0}長から、 あなたが使用されている浄化槽について、検査依頼がありました。\nつきましては、下記検査日に浄化槽第７条に基づく法定検査を実施する予定ですので、お知らせいたします。";

        /// <summary>
        /// MSG_11JO1_TEXT 
        /// </summary>
        private const string MSG_11JO1_TEXT = "{0}様から、 あなたが使用されている浄化槽について、 検査依頼がありました。\nつきましては、下記検査日に浄化槽第１１条に基づく法定検査を実施する予定ですので、お知らせいたします。";

        /// <summary>
        /// MSG_11JO2_TEXT 
        /// </summary>
        private const string MSG_11JO2_TEXT = "{0}長から、 あなたが使用されている浄化槽について、検査依頼がありました。\nつきましては、下記検査日に浄化槽第１１条に基づく法定検査を実施する予定ですので、お知らせいたします。";

        /// <summary>
        /// TESUTYO_SUMI_TEXT1 
        /// </summary>
        private const string TESUTYO_SUMI_TEXT1 = " 検査手数料は設置申請時に納入済みのため必要ありません。";

        /// <summary>
        /// TESUTYO_SUMI_TEXT2 
        /// </summary>
        private const string TESUTYO_SUMI_TEXT2 = "※検査手数料は、後日請求させていただきます。";

        /// <summary>
        /// TUSHIN_TEXT 
        /// </summary>
        private const string TUSHIN_TEXT = "検査日に次のものの準備をお願いします。\n① 保守点検・清掃の記録用紙\n②  機械室がある場合には、そのカギ。";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensatsuchiHagakiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensatsuchiHagakiBusinessLogic()
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
        /// 2014/09/09  HuyTX　　    新規作成
        /// 2014/11/26  HuyTX　　    Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensatsuchiHagakiBLOutput SetBook(IPrintKensatsuchiHagakiBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensatsuchiHagakiBLOutput output = new PrintKensatsuchiHagakiBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                int pasteRow = PASTE_ROW_START;
                string tesuryoSumi = string.Empty;
                string dayOfWeek = string.Empty;

                foreach (KensaIraiTblDataSet.KensaYoteiListRow printRow in input.KensaYoteiListDataTable)
                {
                    if (printRow.JokasoHagakiKbn == "9") continue;

                    char[] postArr = new char[8];
                    string adrTextBox = string.Empty;
                    string atenaTextBox = string.Empty;
                    DateTime yoteiDt = new DateTime();

                    #region switch JokasoHagakiSoufusakiKbn

                    switch ((printRow.JokasoHagakiSoufusakiKbn == null) ? "" : printRow.JokasoHagakiSoufusakiKbn)
                    {
                        case "0":
                            postArr = printRow.JokasoSetchiBashoZipCd.ToCharArray();
                            adrTextBox = printRow.JokasoSetchiBashoAdr;
                            atenaTextBox = printRow.JokasoSetchishaNm;
                            break;
                        case "1":
                            postArr = printRow.JokasoSoufusakiZipCd.ToCharArray();
                            adrTextBox = printRow.JokasoSoufusakiAdr;
                            atenaTextBox = printRow.JokasoSoufusakiNm;
                            break;
                        case "2":
                            postArr = printRow.JokasoSeikyusakiZipCd.ToCharArray();
                            adrTextBox = printRow.JokasoSeikyusakiAdr;
                            atenaTextBox = printRow.JokasoSeikyusakiNm;
                            break;
                        case "3":
                            postArr = printRow.JokasoSetchishaZipCd.ToCharArray();
                            adrTextBox = printRow.JokasoSetchishaAdr;
                            atenaTextBox = printRow.JokasoSetchishaNm;
                            break;
                        case "4":
                            postArr = printRow.JokasoRenrakusakiZipCd.ToCharArray();
                            adrTextBox = printRow.JokasoRenrakusakiAdr;
                            atenaTextBox = printRow.JokasoRenrakusakiNm;
                            break;
                        default:
                            break;
                    }

                    #endregion

                    //(1)
                    if (postArr.Length == 8)
                    {
                        SetShapeText(outputSheet, "post1TextBox", postArr[0].ToString());
                        SetShapeText(outputSheet, "post2TextBox", postArr[1].ToString());
                        SetShapeText(outputSheet, "post3TextBox", postArr[2].ToString());
                        SetShapeText(outputSheet, "post4TextBox", postArr[4].ToString());
                        SetShapeText(outputSheet, "post5TextBox", postArr[5].ToString());
                        SetShapeText(outputSheet, "post6TextBox", postArr[6].ToString());
                        SetShapeText(outputSheet, "post7TextBox", postArr[7].ToString());
                    }

                    //(2)
                    SetShapeText(outputSheet, "adrTextBox", adrTextBox);

                    //(3)
                    SetShapeText(outputSheet, "atenaTextBox", atenaTextBox);

                    //(4)
                    SetShapeText(outputSheet, "annaiTextBox", (printRow.KensaIraiHoteiKbn == "1") ? JO7_ANNAI_TEXT : JO11_ANNAI_TEXT); 

                    //(5)
                    if (printRow.KensaIraiHoteiKbn == "1")
                    {
                        //jo7
                        SetShapeText(outputSheet, "msgJoTextBox", (printRow.KensaIraiShichosonSetchigata == "1") ? string.Format(MSG_7JO2_TEXT, printRow.ChikuNm) : MSG_7JO1_TEXT);   
                    }else
                    {
                        //jo11
                        SetShapeText(outputSheet, "msgJoTextBox", (printRow.KensaIraiShichosonSetchigata == "1") ? string.Format(MSG_11JO2_TEXT, printRow.ChikuNm) : string.Format(MSG_11JO1_TEXT, printRow.IkkatsuSeikyusakiNm));
                    }

                    decimal kensaIraiGokeiAmt;
                    decimal kensaIraiNyukinzumiAmt;

                    // TODO test required(modified due to DataSet maintainance)
                    kensaIraiGokeiAmt = printRow.KensaIraiGokeiAmt;
                    kensaIraiNyukinzumiAmt = printRow.KensaIraiNyukinzumiAmt;

                    //(6)
                    tesuryoSumi = string.Empty;
                    if (printRow.KensaIraiHoteiKbn == "1"
                        // TODO test required(modified due to DataSet maintainance)
                        //&& decimal.TryParse(printRow.KensaIraiGokeiAmt, out kensaIraiGokeiAmt)
                        //&& decimal.TryParse(printRow.KensaIraiNyukinzumiAmt, out kensaIraiNyukinzumiAmt)
                        )
                    {
                        if (kensaIraiGokeiAmt == kensaIraiNyukinzumiAmt)
                        {
                            tesuryoSumi = TESUTYO_SUMI_TEXT1;
                        }
                        else if (kensaIraiGokeiAmt > kensaIraiNyukinzumiAmt)
                        {
                            tesuryoSumi = TESUTYO_SUMI_TEXT2;
                        }
                    }
                    SetShapeText(outputSheet, "tesuryoSumiTextBox", tesuryoSumi);

                    //(7)
                    dayOfWeek = string.Empty;
                    if (DateTime.TryParse(printRow.yoteiDtCol, out yoteiDt))
                    {
                        //string dayOfWeek = string.Empty;

                        #region switch day of week

                        switch (yoteiDt.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                dayOfWeek = "月";
                                break;
                            case DayOfWeek.Tuesday:
                                dayOfWeek = "火";
                                break;
                            case DayOfWeek.Wednesday:
                                dayOfWeek = "水";
                                break;
                            case DayOfWeek.Thursday:
                                dayOfWeek = "木";
                                break;
                            case DayOfWeek.Friday:
                                dayOfWeek = "金";
                                break;
                            case DayOfWeek.Saturday:
                                dayOfWeek = "土";
                                break;
                            case DayOfWeek.Sunday:
                                dayOfWeek = "日";
                                break;
                            default:
                                break;
                        }

                        #endregion

                        //SetShapeText(outputSheet, "kensabiTextBox", string.Format("{0}({1})", 
                        //    new string[]{
                        //        Utility.DateUtility.ConvertToWareki(kensaDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki),
                        //        dayOfWeek
                        //    }));
                    }

                    //Ver1.03
                    SetShapeText(outputSheet, "kensabiTextBox", !string.IsNullOrEmpty(printRow.KensaIraiKensaYoteiBi) && printRow.KensaIraiKensaYoteiBi != "00" ? string.Format("{0}({1})",
                        new string[]{
                                Utility.DateUtility.ConvertToWareki(yoteiDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki),
                                dayOfWeek
                            }) : string.Empty);

                    // 20141218 type changed
                    //(8)
                    SetShapeText(outputSheet, "ninsoTextBox", printRow.IsKensaIraiShoritaishoJininNull() ? "" : printRow.KensaIraiShoritaishoJinin + "人槽");
                    //SetShapeText(outputSheet, "ninsoTextBox", string.IsNullOrEmpty(printRow.KensaIraiShoritaishoJinin.Trim()) ? "" : printRow.KensaIraiShoritaishoJinin.Trim() + "人槽");

                    //(9)
                    SetShapeText(outputSheet, "settiAdrTextBox", printRow.KensaIraiSetchibashoAdr);

                    //(10)
                    SetShapeText(outputSheet, "tushinTextBox", (printRow.JokasoHagakiKbn == "2") ? TUSHIN_TEXT : "");

                    //(11)
                    SetShapeText(outputSheet, "shisyoTextBox", !string.IsNullOrEmpty(printRow.ShishoNm) ? string.Concat(printRow.ShishoNm, "　検査センター") : string.Empty);

                    //(12)
                    SetShapeText(outputSheet, "shisyoAdrTextBox", printRow.ShishoAdr);

                    //(13)
                    SetShapeText(outputSheet, "shishoFreeDialTextBox", !string.IsNullOrEmpty(printRow.ShishoFreeDial) ? string.Concat("ﾌﾘｰﾀﾞｲﾔﾙ ", printRow.ShishoFreeDial) : string.Empty);

                    //(14)
                    SetShapeText(outputSheet, "kensainNmTextBox", !string.IsNullOrEmpty(printRow.ShokuinNm) ? string.Concat("担当者　", printRow.ShokuinNm) : string.Empty);

                    //copy row header
                    CopyRow(outputSheet, 0, ROW_COUNT_HEADER, pasteRow);
                    pasteRow += ROW_COUNT_HEADER;

                    //set break page
                    outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[pasteRow, 1]);

                    //(15)
                    if (printRow.KensaIraiHoteiKbn == "1")
                    {
                        CopyRow(outputSheet, ROW_IDX_FOOTER_JO7, ROW_COUNT_FOOTER, pasteRow);
                    }
                    else if (printRow.KensaIraiHoteiKbn == "2" || printRow.KensaIraiHoteiKbn == "3")
                    {
                        CopyRow(outputSheet, ROW_IDX_FOOTER_JO11, ROW_COUNT_FOOTER, pasteRow);
                    }

                    pasteRow += ROW_COUNT_FOOTER;

                    //set break page
                    outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[pasteRow, 1]);
                }

                //delete row template
                DeleteRow(outputSheet, 0, PASTE_ROW_START);

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

    }
    #endregion
}
