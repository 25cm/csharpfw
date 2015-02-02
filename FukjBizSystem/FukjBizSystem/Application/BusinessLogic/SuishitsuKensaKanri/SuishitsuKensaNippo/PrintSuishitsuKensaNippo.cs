using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.SuishitsuKensaNippo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSuishitsuKensaNippoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSuishitsuKensaNippoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SuishitsuKensaNippoPrintDataTable
        /// </summary>
        SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintDataTable SuishitsuKensaNippoPrintDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSuishitsuKensaNippoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuishitsuKensaNippoBLInput : BaseExcelPrintBLInputImpl, IPrintSuishitsuKensaNippoBLInput
    {
        /// <summary>
        /// SuishitsuKensaNippoPrintDataTable
        /// </summary>
        public SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintDataTable SuishitsuKensaNippoPrintDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSuishitsuKensaNippoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSuishitsuKensaNippoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSuishitsuKensaNippoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuishitsuKensaNippoBLOutput : IPrintSuishitsuKensaNippoBLOutput
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
    //  クラス名 ： PrintSuishitsuKensaNippoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuishitsuKensaNippoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSuishitsuKensaNippoBLInput, IPrintSuishitsuKensaNippoBLOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// ROW_COUNT_IN_PAGE 
        /// </summary>
        private const int ROW_COUNT_IN_PAGE = 45;

        /// <summary>
        /// ROW_COUNT_HEADER
        /// </summary>
        private const int ROW_COUNT_HEADER = 4;

        /// <summary>
        /// ROW_COUNT_FOOTER 
        /// </summary>
        private const int ROW_COUNT_FOOTER = 5;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSuishitsuKensaNippoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSuishitsuKensaNippoBusinessLogic()
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
        /// 2014/12/07  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSuishitsuKensaNippoBLOutput SetBook(IPrintSuishitsuKensaNippoBLInput input, Excel.Workbook book)
        {
            IPrintSuishitsuKensaNippoBLOutput output = new PrintSuishitsuKensaNippoBLOutput();

            Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;

            try
            {
                DateTime currentDt = Boundary.Common.Common.GetCurrentTimestamp();
                int rowIdx = ROW_COUNT_HEADER;

                application = book.Application;
                application.DisplayAlerts = false;
                tempSheet = (Worksheet)book.Sheets["設計１"];
                tempSheet.Copy(tempSheet, Type.Missing);
                outputSheet = (Worksheet)book.ActiveSheet;
                outputSheet.Name = "Sheet1";
                DeleteRow(outputSheet, 0, 14);

                //copy header
                //RowCopy(tempSheet, outputSheet, 1, ROW_COUNT_HEADER, 1, XlPasteType.xlPasteAll);
                CopyRow(tempSheet, 0, ROW_COUNT_HEADER, outputSheet, 0);

                //(1)受付日
                CellOutput(outputSheet, 0, 5, input.SuishitsuKensaNippoPrintDataTable[0].UketsukeDtDate);

                //(2)支所
                CellOutput(outputSheet, 1, 1, input.SuishitsuKensaNippoPrintDataTable[0].ShishoNm);

                //(3)システム日付
                CellOutput(outputSheet, 1, 39, currentDt.ToString("yyyy/MM/dd"));

                int pageCnt = (input.SuishitsuKensaNippoPrintDataTable.Count - 1) / 41;
                int mod = (input.SuishitsuKensaNippoPrintDataTable.Count - 1) % 41;
                pageCnt = mod == 0 ? pageCnt : pageCnt + 1;

                int pageIdx = 1;

                //output page count
                CellOutput(outputSheet, 0, 51, mod + ROW_COUNT_HEADER + ROW_COUNT_FOOTER > ROW_COUNT_IN_PAGE ? pageCnt + 1 : pageCnt);

                for (int i = 1; i< input.SuishitsuKensaNippoPrintDataTable.Count; i++)
                {
                    SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintRow printRow = input.SuishitsuKensaNippoPrintDataTable[i];
                    SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintRow previousRow = input.SuishitsuKensaNippoPrintDataTable[i <= 2 ? 1 : (i - 1)];
                    InsertRow(outputSheet, rowIdx);
                    if (printRow.RecordType == "2")
                    {
                        //copy row Total by Gyosha
                        //RowCopy(tempSheet, outputSheet, 7, 0, (rowIdx + 1), XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, 6, 0, outputSheet, rowIdx);
                    }
                    else if (printRow.RecordType == "3")
                    {
                        //copy row Total all
                        //RowCopy(tempSheet, outputSheet, 8, 0, (rowIdx + 1), XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, 7, 0, outputSheet, rowIdx);
                    }
                    else
                    {
                        //RowCopy(tempSheet, outputSheet, 6, 0, (rowIdx + 1), XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, 5, 0, outputSheet, rowIdx);
                    }

                    //(4)事業所名
                    CellOutput(outputSheet, rowIdx, 1, (i == 1 || printRow.GyoshaCd != previousRow.GyoshaCd) ? printRow.GyoshaNm : string.Empty);

                    //(5)コード
                    CellOutput(outputSheet, rowIdx, 12, (i == 1 || printRow.GyoshaCd != previousRow.GyoshaCd) ? "'" + printRow.GyoshaCd : string.Empty);

                    //(6)検査種別
                    CellOutput(outputSheet, rowIdx, (i == input.SuishitsuKensaNippoPrintDataTable.Count - 1) ? 1 : 15, printRow.KensaShubetsu);

                    //(7)会員外
                    CellOutput(outputSheet, rowIdx, 32, printRow.KaiingaiFlg == "1" ? "＊" : string.Empty);

                    //(8)現金
                    CellOutput(outputSheet, rowIdx, 33, printRow.GenkinFlg == "1" ? "＊" : string.Empty);

                    //(9)検査料金
                    CellOutput(outputSheet, rowIdx, 34, printRow.KensaRyokin);

                    //(10)持込
                    CellOutput(outputSheet, rowIdx, 38, printRow.Mochikomi);

                    //(11)収集
                    CellOutput(outputSheet, rowIdx, 41, printRow.Shushu);

                    //(12)金額
                    CellOutput(outputSheet, rowIdx, 44, printRow.Kingaku);

                    //(12)入金額
                    CellOutput(outputSheet, rowIdx, 48, printRow.Nyukingaku);

                    //////////////////
                    if ((rowIdx + 1) % ROW_COUNT_IN_PAGE == 0)
                    {
                        SetCellBottomBorder(outputSheet, rowIdx + 1);
                        SetPageBreak(outputSheet, rowIdx + 1);
                        CopyRow(outputSheet, 0, ROW_COUNT_HEADER, rowIdx + 1);
                        pageIdx++;
                        CellOutput(outputSheet, rowIdx + 1, 49, pageIdx);
                        rowIdx += ROW_COUNT_HEADER;
                    }

                    if (i == input.SuishitsuKensaNippoPrintDataTable.Count - 1)
                    {
                        if (mod + ROW_COUNT_HEADER + ROW_COUNT_FOOTER > ROW_COUNT_IN_PAGE)
                        {
                            rowIdx = pageCnt * ROW_COUNT_IN_PAGE;
                            SetPageBreak(outputSheet, rowIdx + 1);
                            CopyRow(outputSheet, 0, ROW_COUNT_HEADER, rowIdx);
                            pageIdx++;
                            CellOutput(outputSheet, rowIdx + 1, 49, pageIdx);
                            rowIdx += (ROW_COUNT_HEADER - 1);
                        }
                        //copy footer
                        //RowCopy(tempSheet, outputSheet, 9, ROW_COUNT_FOOTER, rowIdx + 2, XlPasteType.xlPasteAll);
                        CopyRow(tempSheet, 8, ROW_COUNT_FOOTER, outputSheet, rowIdx + 1);
                    }

                    //////////////////

                    rowIdx++;
                }
                
                //9条検査
                //(16)
                CellOutput(outputSheet, rowIdx + 2, 10, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNo9joFrom) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNo9joFrom : string.Empty);
                //(17)
                CellOutput(outputSheet, rowIdx + 2, 15, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNo9joTo) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNo9joTo : string.Empty);
                //(18)
                CellOutput(outputSheet, rowIdx + 2, 20, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeHonsu9jo) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeHonsu9jo : string.Empty);

                //水質11条
                //(19)
                CellOutput(outputSheet, rowIdx + 3, 10, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoSuishitsu11joFrom) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoSuishitsu11joFrom : string.Empty);
                //(20)
                CellOutput(outputSheet, rowIdx + 3, 15, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoSuishitsu11joTo) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoSuishitsu11joTo : string.Empty);
                //(21)
                CellOutput(outputSheet, rowIdx + 3, 20, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeHonsuSuishitsu11jo) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeHonsuSuishitsu11jo : string.Empty);

                //外観11条
                //(22)
                CellOutput(outputSheet, rowIdx + 4, 10, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoGaikanFrom) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoGaikanFrom : string.Empty);
                //(23)
                CellOutput(outputSheet, rowIdx + 4, 15, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoGaikanTo) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeNoGaikanTo : string.Empty);
                //(24)
                CellOutput(outputSheet, rowIdx + 4, 20, !string.IsNullOrEmpty(input.SuishitsuKensaNippoPrintDataTable[0].UketsukeHonsuGaikan) ? "'" + input.SuishitsuKensaNippoPrintDataTable[0].UketsukeHonsuGaikan : string.Empty);

                //delete template sheet
                if (book.Sheets.Count > 1 && tempSheet != null)
                {
                    tempSheet.Delete();
                }

                SelectCell(outputSheet, 1, 1); 
            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SetCellBottomBorder
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetCellBottomBorder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetCellBottomBorder(Worksheet sheet, int row)
        {
            Range range = null;

            try
            {
                range = sheet.get_Range(string.Format("B{0}:AZ{0}", row));
                range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = 2;
                range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            }
            finally
            {
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
