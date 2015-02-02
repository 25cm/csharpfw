using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanYoteiListHassoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJinendoGaikanYoteiListHassoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJinendoGaikanYoteiListHassoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensaYoteiListWrkDataTable
        /// </summary>
        KensaYoteiListWrkDataSet.KensaYoteiListWrkDataTable KensaYoteiListWrkDataTable { get; set; }

        /// <summary>
        /// MakeList 
        /// </summary>
        string MakeList { get; set; }

        /// <summary>
        /// Sort1
        /// </summary>
        string Sort1 { get; set; }

        /// <summary>
        /// Sort2
        /// </summary>
        string Sort2 { get; set; }

        /// <summary>
        /// PrintType1
        /// </summary>
        string PrintType1 { get; set; }

        /// <summary>
        /// PrintType2
        /// </summary>
        string PrintType2 { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJinendoGaikanYoteiListHassoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanYoteiListHassoBLInput : BaseExcelPrintBLInputImpl, IPrintJinendoGaikanYoteiListHassoBLInput
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
        /// KensaYoteiListWrkDataTable
        /// </summary>
        public KensaYoteiListWrkDataSet.KensaYoteiListWrkDataTable KensaYoteiListWrkDataTable { get; set; }

        /// <summary>
        /// MakeList 
        /// </summary>
        public string MakeList { get; set; }

        /// <summary>
        /// Sort1
        /// </summary>
        public string Sort1 { get; set; }

        /// <summary>
        /// Sort2
        /// </summary>
        public string Sort2 { get; set; }

        /// <summary>
        /// PrintType1
        /// </summary>
        public string PrintType1 { get; set; }

        /// <summary>
        /// PrintType2
        /// </summary>
        public string PrintType2 { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJinendoGaikanYoteiListHassoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJinendoGaikanYoteiListHassoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJinendoGaikanYoteiListHassoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanYoteiListHassoBLOutput : BaseExcelPrintBLOutputImpl, IPrintJinendoGaikanYoteiListHassoBLOutput
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
    //  クラス名 ： PrintJinendoGaikanYoteiListHassoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanYoteiListHassoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJinendoGaikanYoteiListHassoBLInput, IPrintJinendoGaikanYoteiListHassoBLOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// START_OUTPUT_ROW 
        /// </summary>
        private const int START_OUTPUT_ROW = 5;

        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_HEADER = 5;

        /// <summary>
        /// 
        /// </summary>
        private const int ROW_COUNT_DETAIL = 39;
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintJinendoGaikanYoteiListHassoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJinendoGaikanYoteiListHassoBusinessLogic()
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
        /// 2014/09/26  HuyTX　　    新規作成
        /// 2014/12/15  habu　　    Modified page break
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJinendoGaikanYoteiListHassoBLOutput SetBook(IPrintJinendoGaikanYoteiListHassoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintJinendoGaikanYoteiListHassoBLOutput output = new PrintJinendoGaikanYoteiListHassoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet templateSheet = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                templateSheet = (Worksheet)book.Sheets["Sheet1"];

                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
                //DEL_20141119_Ver1.01 Start
                //string condition = string.Format("{0}{1}{2}", (input.MakeList == "2") ? "KensaIraiHoteiKbn = '2'" : string.Empty, (input.MakeList == "2" && input.PrintType2 == "2") ? " AND " : string.Empty, (input.PrintType2 == "2") ? "Jo7KensaKbn = '0'" : string.Empty);
                //DEL_20141119_Ver1.01 End
                
                //sort by 23
                string sort1 = string.Format("{0}ShishoCd, KensaIraiNendo", (input.PrintType1 == "1") ? "NinsoKbn, " : string.Empty);
                //sort by 17
                string sort2 = string.Format("GyoshaCd, {0} KensaYoteiTsuki, ShichosonCd", (input.PrintType1 == "1") ? "NinsoKbn," : string.Empty);
                //sort by 18
                string sort3 = string.Format("ShichosonCd, {0} {1}", (input.PrintType1 == "1") ? "NinsoKbn," : string.Empty, (input.Sort2 == "1") ? "KensaYoteiTsuki, GyoshaCd" : "GyoshaCd, KensaYoteiTsuki");

                string sorting = string.Format("{0}, KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban", (input.Sort1 == "1") ? sort2 : sort3);

                KensaYoteiListWrkDataSet.KensaYoteiListWrkRow[] kensaYoteiRows = (KensaYoteiListWrkDataSet.KensaYoteiListWrkRow[])input.KensaYoteiListWrkDataTable.Select("", sorting);

                //print data
                int sheetNo = 1;
                int pasteRow = START_OUTPUT_ROW;
                for (int i = 0; i < kensaYoteiRows.Length; i++)
                {
                    KensaYoteiListWrkDataSet.KensaYoteiListWrkRow currentRow = kensaYoteiRows[i];
                    KensaYoteiListWrkDataSet.KensaYoteiListWrkRow previousRow = kensaYoteiRows[(i > 0) ? (i - 1) : 0];

                    //condition copy sheet
                    if (i == 0
                        || (input.Sort1 == "1" && currentRow.GyoshaCd != previousRow.GyoshaCd)
                        || (input.Sort1 == "2" && currentRow.ShichosonCd != previousRow.ShichosonCd)
                        || (input.PrintType1 == "1" && currentRow.NinsoKbn != previousRow.NinsoKbn)
                        )
                    {

                        // 20141215 habu Mod
                        //delete row template(case copy new sheet)
                        //if (i > 0)
                        //{
                        //    DeleteRow(outputSheet, 5, 1);
                        //}
                        // 20141215 End

                        templateSheet.Copy(templateSheet, Type.Missing);
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = "Sheet_" + sheetNo;
                        sheetNo++;

                        //output header
                        OutputHeader(outputSheet, input, currentRow, currentDateTime);

                        pasteRow = START_OUTPUT_ROW;
                    }

                    // 20141215 habu Mod
                    //Copy row template
                    //CopyRow(outputSheet, 5, 1, pasteRow);
                    // 20141215 End

                    // if first row in page
                    if (((pasteRow - ROW_COUNT_HEADER) % ROW_COUNT_DETAIL) == 0)
                    {
                        // copy detail rows from template
                        CopyRow(templateSheet, ROW_COUNT_HEADER, ROW_COUNT_DETAIL, outputSheet, pasteRow);

                        // set page break
                        SetPageBreak(outputSheet, pasteRow + ROW_COUNT_DETAIL);
                    }

                    //output content
                    OutputContent(outputSheet, pasteRow, input, currentRow);

                    // 20141215 habu Mod
                    //delete row template
                    //if (i == kensaYoteiRows.Length - 1)
                    //{
                    //    DeleteRow(outputSheet, 5, 1);
                    //}
                    // 20141215 End

                    pasteRow++;
                }

                //delete template sheet
                if (book.Sheets.Count > 1)
                {
                    templateSheet.Delete();
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (templateSheet != null) { Marshal.ReleaseComObject(templateSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region OutputHeader
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputHeader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="input"></param>
        /// <param name="printRow"></param>
        /// <param name="currentDateTime"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputHeader(Worksheet outputSheet, 
            IPrintJinendoGaikanYoteiListHassoBLInput input, 
            KensaYoteiListWrkDataSet.KensaYoteiListWrkRow printRow,
            DateTime currentDateTime)
        {
            //(1)
            CellOutput(outputSheet, 0, 0, string.Format("{0}/04/01", printRow.KensaIraiNendo));

            //(2)
            CellOutput(outputSheet, 2, 0, input.Sort1 == "1" ? "依頼事業者" : "市町村");

            //(3)
            CellOutput(outputSheet, 2, 7, input.Sort1 == "1" ? printRow.GyoshaNm : printRow.ShichosonNm);

            //(4)
            CellOutput(outputSheet, 2, 34, string.Format("'{0}", input.Sort1 == "1" ? printRow.GyoshaCd : printRow.ShichosonCd));

            //(5)
            CellOutput(outputSheet, 2, 45, input.Sort1 == "1" ? printRow.GyoshaTelNo : printRow.HokenjoTelNo);

            //(6)
            CellOutput(outputSheet, 3, 6, input.Sort1 == "1" ? printRow.GyoshaZipCd : printRow.HokenjoZipCd);

            //(7)
            CellOutput(outputSheet, 3, 19, input.Sort1 == "1" ? printRow.GyoshaAdr : printRow.HokenjoAdr);

            //(8)
            //CellOutput(outputSheet, 3, 77, string.Format("{0}年{1}月{2}日",
            //                                            Boundary.Common.Common.ConvertToHoshouNendoWareki(currentDateTime.ToString("yyyy")),
            //                                            currentDateTime.ToString("MM"),
            //                                            currentDateTime.ToString("dd")
            //                                            ));
            CellOutput(outputSheet, 3, 75, currentDateTime.ToString("yyyy/MM/dd"));

            //(9)
            CellOutput(outputSheet, 4, input.Sort2 == "1" ? 4 : 0, input.Sort1 == "1" ? "市町村" : "依頼事業者");
        }
        #endregion

        #region OutputContent
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputContent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="pasteRow"></param>
        /// <param name="input"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  HuyTX　  新規作成
        /// 2014/11/19  HuyTX　  041_次年度外観予定一覧発送リスト_帳票設計書(Ver1.01)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputContent(Worksheet outputSheet, 
            int pasteRow,
            IPrintJinendoGaikanYoteiListHassoBLInput input, 
            KensaYoteiListWrkDataSet.KensaYoteiListWrkRow printRow)
        {
            //(10)
            CellOutput(outputSheet, pasteRow, 0, input.Sort2 == "1" ? printRow.KensaYoteiTsuki + "月" : input.Sort1 == "1" ? printRow.ShichosonNm : printRow.GyoshaNm);

            //(11)
            CellOutput(outputSheet, pasteRow, input.Sort2 == "1" ? 4 : 16, input.Sort2 == "2" ? printRow.KensaYoteiTsuki + "月" : input.Sort1 == "1" ? printRow.ShichosonNm : printRow.GyoshaNm);

            //(12)
            CellOutput(outputSheet, pasteRow, 20, string.Format("{0}-{1}-{2}", printRow.KensaIraiHokenjoCd, Utility.DateUtility.ConvertToWareki(printRow.KensaIraiNendo, "yy"), printRow.KensaIraiRenban));

            //(13)
            CellOutput(outputSheet, pasteRow, 28, printRow.SetchishaNm);

            //(14)
            CellOutput(outputSheet, pasteRow, 43, printRow.SetchibashoAdr);

            //(15)
            CellOutput(outputSheet, pasteRow, 71, printRow.ShorihoshikiKbnNm);

            //(16)
            CellOutput(outputSheet, pasteRow, 75, !string.IsNullOrEmpty(printRow.Ninso) ? printRow.Ninso + "人" : string.Empty);

            //(17)
            //MOD_Ver1.01_Start
            //CellOutput(outputSheet, pasteRow, 82, string.Format("{0}-{1}", printRow.SetchishaKbn, printRow.SetchishaCd));
            CellOutput(outputSheet, pasteRow, 80, string.Format("{0}-{1}-{2}", printRow.JokasoHokenjoCd, Utility.DateUtility.ConvertToWareki(printRow.JokasoTorokuNendo, "yy"), printRow.JokasoRenban));
            //MOD_Ver1.01_End
        }
        #endregion

        #endregion

    }
    #endregion
}
