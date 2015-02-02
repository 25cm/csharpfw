using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FukjBizSystem.Application.DataAccess.ShishoMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintFutekiseiJokasoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintFutekiseiJokasoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintFutekiseiJokasoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintFutekiseiJokasoBLInput : BaseExcelPrintBLInputImpl, IPrintFutekiseiJokasoBLInput
    {
        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintFutekiseiJokasoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintFutekiseiJokasoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintFutekiseiJokasoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintFutekiseiJokasoBLOutput : IPrintFutekiseiJokasoBLOutput
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
    //  クラス名 ： PrintFutekiseiJokasoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintFutekiseiJokasoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintFutekiseiJokasoBLInput, IPrintFutekiseiJokasoBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// START_ROW_IDX 
        /// </summary>
        private const int START_ROW_IDX = 4;

        /// <summary>
        /// START_ROW_IDX_SHASHIN 
        /// </summary>
        private const int START_ROW_IDX_SHASHIN = 1;

        /// <summary>
        /// ROW_COUNT_SHASHIN 
        /// </summary>
        private const int ROW_COUNT_SHASHIN = 28;

        /// <summary>
        /// MAX_ROW_IDX 
        /// </summary>
        private const int MAX_ROW_IDX = 27;

        /// <summary>
        /// MAX_ROW_SHASHIN
        /// </summary>
        private const int MAX_ROW_SHASHIN = 60;

        /// <summary>
        /// ROW_COUNT_IN_PAGE 
        /// </summary>
        //private const int ROW_COUNT_IN_PAGE = 30;
        private const int ROW_COUNT_IN_PAGE = 24;

        /// <summary>
        /// ROW_COUNT_HEADER 
        /// </summary>
        private const int ROW_COUNT_HEADER = 4;

        /// <summary>
        /// OUTPUT_SHEET_NAME 
        /// </summary>
        private string OUTPUT_SHEET_NAME = "無管理浄化槽一覧({0})";

        /// <summary>
        /// SHASHIN_SHEET_NAME 
        /// </summary>
        private string SHASHIN_SHEET_NAME = "写真添付({0})";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintFutekiseiJokasoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/28  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintFutekiseiJokasoBusinessLogic()
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
        /// 2014/10/28  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintFutekiseiJokasoBLOutput SetBook(IPrintFutekiseiJokasoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintFutekiseiJokasoBLOutput output = new PrintFutekiseiJokasoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempOutputSheet = null;
            Worksheet outputSheet = null;
            Worksheet tempShashinSheet = null;
            Worksheet shashinSheet = null;

            try
            {
                int rowIdx = START_ROW_IDX;
                int sheetIdx = 1;
                int rowIdxShashin = START_ROW_IDX_SHASHIN;
                application = book.Application;
                application.DisplayAlerts = false;
                tempOutputSheet = (Worksheet)book.Sheets["一覧"];
                tempShashinSheet = (Worksheet)book.Sheets["写真添付"];

                ISelectShishoMstByKeyDAInput getShishoInput = new SelectShishoMstByKeyDAInput();
                getShishoInput.ShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
                ISelectShishoMstByKeyDAOutput getShishoOutput = new SelectShishoMstByKeyDataAccess().Execute(getShishoInput);

                JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow[] syukeiListRows = (JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow[])
                    input.JokasoDaichoSyukeiListDataTable.Select("", "KensaIraiHokenjoCd, KensaDtCol");

                for (int i = 0; i < syukeiListRows.Length; i++)
                {
                    JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow printRow = input.JokasoDaichoSyukeiListDataTable[i];
                    JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow previousRow = input.JokasoDaichoSyukeiListDataTable[(i <= 1) ? 0 : (i - 1)];

                    if (rowIdx - ROW_COUNT_HEADER >= ROW_COUNT_IN_PAGE && (rowIdx - ROW_COUNT_HEADER) % ROW_COUNT_IN_PAGE == 0)
                    {
                        SetPageBreak(outputSheet, rowIdx);
                    }


                    #region output header

                    if (i == 0 || printRow.KensaIraiHokenjoCd != previousRow.KensaIraiHokenjoCd)
                    {
                        if (rowIdx - ROW_COUNT_HEADER >= ROW_COUNT_IN_PAGE)
                        {
                            //set print area
                            SetPrintArea(outputSheet, 0, 0, rowIdx - 1, 16);
                        }

                        if (rowIdxShashin >= MAX_ROW_SHASHIN)
                        {
                            SetPrintArea(shashinSheet, 0, 0, rowIdxShashin, 10);
                        }

                        //copy temp sheet
                        tempOutputSheet.Copy(tempOutputSheet, Type.Missing);
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = string.Format(OUTPUT_SHEET_NAME, sheetIdx);

                        //tempShashinSheet.Copy(tempShashinSheet, Type.Missing);
                        tempShashinSheet.Copy(Type.Missing, outputSheet);
                        shashinSheet = (Worksheet)book.ActiveSheet;
                        shashinSheet.Name = string.Format(SHASHIN_SHEET_NAME, sheetIdx);

                        //(1)保健所名
                        CellOutput(outputSheet, 1, 1, !string.IsNullOrEmpty(printRow.HokenjoNm) ? printRow.HokenjoNm : string.Empty);

                        //(2)支所名称 
                        CellOutput(outputSheet, 2, 8, getShishoOutput.ShishoMstDataTable.Count > 0 ? string.Format("{0}検査センター", getShishoOutput.ShishoMstDataTable[0].ShishoNm) : string.Empty);

                        rowIdx = START_ROW_IDX;
                        rowIdxShashin = START_ROW_IDX_SHASHIN;
                        sheetIdx++;
                    }
                    #endregion

                    #region output content

                    if (rowIdx > MAX_ROW_IDX)
                    {
                        CopyRow(outputSheet, MAX_ROW_IDX, 1, rowIdx);
                        //No
                        CellOutput(outputSheet, rowIdx, 1, string.Format("'{0}", (rowIdx + 1) - ROW_COUNT_HEADER));
                    }

                    //(3)保健所受理番号
                    CellOutput(outputSheet, rowIdx, 2, !string.IsNullOrEmpty(printRow.UketsukeNoCol) ? printRow.UketsukeNoCol : string.Empty);

                    //(4)受理日 
                    CellOutput(outputSheet, rowIdx, 3, !string.IsNullOrEmpty(printRow.KensaDtCol) ? Utility.DateUtility.ConvertToWareki(DateTime.ParseExact(printRow.KensaDtCol, "yyyy/MM/dd", null).ToString("yyyyMMdd"), "yy.MM.dd") : string.Empty);

                    //(5)検査依頼法定区分
                    CellOutput(outputSheet, rowIdx, 4, !string.IsNullOrEmpty(printRow.KensaKbnCol) ? printRow.KensaKbnCol : string.Empty);

                    //(6)設置者名（漢字）
                    CellOutput(outputSheet, rowIdx, 5, !string.IsNullOrEmpty(printRow.KanrisyaNmCol) ? printRow.KanrisyaNmCol : string.Empty);

                    //(7)住所＋改行＋(電話番号)
                    //CellOutput(outputSheet, rowIdx, 6, !string.IsNullOrEmpty(printRow.AdrCol) ? printRow.AdrCol + "\r\n" + printRow.KensaIraiSetchishaTelNo : "\r\n" + printRow.KensaIraiSetchishaTelNo);
                    CellOutput(outputSheet, rowIdx, 6, !string.IsNullOrEmpty(printRow.AdrCol) ? printRow.AdrCol + string.Format("\r\n({0})", printRow.KensaIraiSetchishaTelNo) : string.Format("\r\n({0})", printRow.KensaIraiSetchishaTelNo));

                    //(8)処理方式区分 
                    CellOutput(outputSheet, rowIdx, 7, !string.IsNullOrEmpty(printRow.ShoriHosikiCol) ? printRow.ShoriHosikiCol : string.Empty);

                    //(9)処理対象人員
                    CellOutput(outputSheet, rowIdx, 8, !printRow.IsNinsoColNull() ? printRow.NinsoCol.ToString() : string.Empty);

                    //(10)生物化学酸素要求量
                    CellOutput(outputSheet, rowIdx, 9, !printRow.IsHoryuBodColNull() ? printRow.HoryuBodCol.ToString() : string.Empty);

                    //(11)所見略称
                    CellOutput(outputSheet, rowIdx, 10, !printRow.IsShitekiColNull() ? printRow.ShitekiCol : string.Empty);

                    //(12)ファイルパス 
                    CellOutput(outputSheet, rowIdx, 11, !string.IsNullOrEmpty(printRow.SyashinPath1Col) ? "1" : string.Empty);
                    CellOutput(outputSheet, rowIdx, 12, !string.IsNullOrEmpty(printRow.SyashinPath2Col) ? "2" : string.Empty);
                    CellOutput(outputSheet, rowIdx, 13, !string.IsNullOrEmpty(printRow.SyashinPath3Col) ? "3" : string.Empty);

                    //(13)業者名称 
                    CellOutput(outputSheet, rowIdx, 14, !string.IsNullOrEmpty(printRow.HosyuTenkenGyosyaCol) ? printRow.HosyuTenkenGyosyaCol : string.Empty);

                    #endregion

                    #region output shashinSheet
                    
                    if (!string.IsNullOrEmpty(printRow.SyashinPath1Col))
                    {
                        OutputShashin(shashinSheet, printRow, rowIdxShashin, printRow.SyashinPath1Col, 1);
                        rowIdxShashin += ROW_COUNT_SHASHIN;
                    }
                    if (!string.IsNullOrEmpty(printRow.SyashinPath2Col))
                    {
                        OutputShashin(shashinSheet, printRow, rowIdxShashin, printRow.SyashinPath2Col, 2);
                        rowIdxShashin += ROW_COUNT_SHASHIN;
                    }
                    if (!string.IsNullOrEmpty(printRow.SyashinPath3Col))
                    {
                        OutputShashin(shashinSheet, printRow, rowIdxShashin, printRow.SyashinPath3Col, 3);
                        rowIdxShashin += ROW_COUNT_SHASHIN;
                    }

                    #endregion

                    rowIdx++;
                }

                #region set print area for last sheet

                //set print area for last sheet
                if (rowIdx - ROW_COUNT_HEADER >= ROW_COUNT_IN_PAGE)
                {
                    SetPageBreak(outputSheet, rowIdx);
                    //set print area
                    SetPrintArea(outputSheet, 0, 0, rowIdx - 1, 16);
                }

                if (rowIdxShashin >= MAX_ROW_SHASHIN)
                {
                    SetPrintArea(shashinSheet, 0, 0, rowIdxShashin, 10);
                }
                #endregion

                //delete template sheet
                if (book.Sheets.Count > 2)
                {
                    tempOutputSheet.Delete();
                    tempShashinSheet.Delete();
                }

                //set selected first cell
                ((Worksheet)book.Sheets[1]).Select();
                SelectCell((Worksheet)book.Sheets[1], 1, 1);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(tempOutputSheet); }
                if (shashinSheet != null) { Marshal.ReleaseComObject(tempShashinSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                if (shashinSheet != null) { Marshal.ReleaseComObject(shashinSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region OutputShashin
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputShashin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shashinSheet"></param>
        /// <param name="printRow"></param>
        /// <param name="row"></param>
        /// <param name="filePath"></param>
        /// <param name="shashinNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputShashin(Worksheet shashinSheet, 
                                    JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow printRow, 
                                    int row, 
                                    string filePath,
                                    int shashinNo)
        {
            Range rng = null;
            Image genbaImg = null;

            Range boldRng = (Range)shashinSheet.Cells[row + 1, 2];
            boldRng.Font.Bold = true;
            CellOutput(shashinSheet, row, 1, string.Format("写真No{0}", shashinNo));

            //(15)
            CellOutput(shashinSheet, row + 1, 2, string.Format("浄化槽管理者名：{0}", !string.IsNullOrEmpty(printRow.KanrisyaNmCol) ? printRow.KanrisyaNmCol : string.Empty));

            //(16)
            CellOutput(shashinSheet, row + 2, 2, string.Format("指摘内容：{0}", !printRow.IsShitekiColNull() ? printRow.ShitekiCol : string.Empty));

            if (File.Exists(filePath))
            {
                rng = (Range)shashinSheet.Cells[row + 5, 3];
                genbaImg = Image.FromFile(filePath);
                Clipboard.SetDataObject(genbaImg, true);
                shashinSheet.Paste(rng, genbaImg);
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
