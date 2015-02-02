using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.ShishoMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintMukanriJokasoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintMukanriJokasoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintMukanriJokasoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintMukanriJokasoBLInput : BaseExcelPrintBLInputImpl, IPrintMukanriJokasoBLInput
    {
        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintMukanriJokasoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintMukanriJokasoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintMukanriJokasoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintMukanriJokasoBLOutput : IPrintMukanriJokasoBLOutput
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
    //  クラス名 ： PrintMukanriJokasoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintMukanriJokasoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintMukanriJokasoBLInput, IPrintMukanriJokasoBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// ROW_COUNT_IN_PAGE
        /// </summary>
        private const int ROW_COUNT_IN_PAGE = 30;

        /// <summary>
        /// ROW_COUNT_HEADER 
        /// </summary>
        private const int ROW_COUNT_HEADER = 4;

        /// <summary>
        /// MAX_ROW_IDX 
        /// </summary>
        private const int MAX_ROW_IDX = 30;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintMukanriJokasoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintMukanriJokasoBusinessLogic()
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
        /// 2014/10/30  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintMukanriJokasoBLOutput SetBook(IPrintMukanriJokasoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintMukanriJokasoBLOutput output = new PrintMukanriJokasoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                int rowIdx = ROW_COUNT_HEADER;
                int sheetIdx = 1;

                ISelectShishoMstByKeyDAInput getShishoInput = new SelectShishoMstByKeyDAInput();
                getShishoInput.ShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
                ISelectShishoMstByKeyDAOutput getShishoOutput = new SelectShishoMstByKeyDataAccess().Execute(getShishoInput);

                JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow[] syukeiListRows = (JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow[])
                    input.JokasoDaichoSyukeiListDataTable.Select("", "JokasoHokenjoCd, JokasoTorokuNendo, JokasoRenban");

                for (int i = 0; i < syukeiListRows.Length; i++)
                {
                    JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow printRow = input.JokasoDaichoSyukeiListDataTable[i];
                    JokasoDaichoMstDataSet.JokasoDaichoSyukeiListRow previousRow = input.JokasoDaichoSyukeiListDataTable[(i <= 1) ? 0 : (i - 1)];

                    if (rowIdx - ROW_COUNT_HEADER >= ROW_COUNT_IN_PAGE && (rowIdx - ROW_COUNT_HEADER) % ROW_COUNT_IN_PAGE == 0)
                    {
                        SetPageBreak(outputSheet, rowIdx);
                    }

                    #region output header

                    if (i == 0 || printRow.JokasoHokenjoCd != previousRow.JokasoHokenjoCd)
                    {
                        if (rowIdx - ROW_COUNT_HEADER >= ROW_COUNT_IN_PAGE)
                        {
                            //set print area
                            SetPrintArea(outputSheet, 0, 0, rowIdx - 1, 11);
                        }

                        //copy temp sheet
                        tempSheet.Copy(tempSheet, Type.Missing);
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = string.Format("無管理浄化槽一覧({0})", sheetIdx);

                        //(1)保健所名
                        CellOutput(outputSheet, 1, 1, !string.IsNullOrEmpty(printRow.HokenjoNm) ? printRow.HokenjoNm : string.Empty);

                        //(2)支所名称 
                        CellOutput(outputSheet, 2, 8, getShishoOutput.ShishoMstDataTable.Count > 0 ? string.Format("{0}検査センター", getShishoOutput.ShishoMstDataTable[0].ShishoNm) : string.Empty);

                        rowIdx = 4;
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
                    CellOutput(outputSheet, rowIdx, 3, !string.IsNullOrEmpty(printRow.JokasoJuriBi) ? Utility.DateUtility.ConvertToWareki(printRow.JokasoJuriBi, "yy.MM.dd") : string.Empty);

                    //(5)11条検査日 
                    //CellOutput(outputSheet, rowIdx, 4, !string.IsNullOrEmpty(printRow.Jokaso11JokensaBi) ? Utility.DateUtility.ConvertToWareki(printRow.Jokaso11JokensaBi, "yy.MM.dd") : string.Empty);
                    CellOutput(outputSheet, rowIdx, 4, !string.IsNullOrEmpty(printRow.JokasoSaishuKensaBi) ? Utility.DateUtility.ConvertToWareki(printRow.JokasoSaishuKensaBi, "yy.MM.dd") : string.Empty);

                    //(6)設置者氏名 
                    CellOutput(outputSheet, rowIdx, 5, !string.IsNullOrEmpty(printRow.KanrisyaNmCol) ? printRow.KanrisyaNmCol : string.Empty);

                    //(7)浄化槽設置場所住所
                    CellOutput(outputSheet, rowIdx, 6, !string.IsNullOrEmpty(printRow.AdrCol) ? printRow.AdrCol : string.Empty);

                    //(8)設置者電話番号
                    CellOutput(outputSheet, rowIdx, 7, !string.IsNullOrEmpty(printRow.JokasoSetchishaTelNo) ? printRow.JokasoSetchishaTelNo : string.Empty);

                    //(9)処理対象人員 
                    CellOutput(outputSheet, rowIdx, 8, !printRow.IsNinsoColNull() ? printRow.NinsoCol.ToString() : string.Empty);

                    //(10)業者名称
                    CellOutput(outputSheet, rowIdx, 9, !string.IsNullOrEmpty(printRow.HosyuTenkenGyosyaCol) ? printRow.HosyuTenkenGyosyaCol : string.Empty);

                    #endregion

                    rowIdx++;
                }

                //set print area for last sheet
                if (rowIdx - ROW_COUNT_HEADER >= ROW_COUNT_IN_PAGE)
                {
                    SetPageBreak(outputSheet, rowIdx);
                    //set print area
                    SetPrintArea(outputSheet, 0, 0, rowIdx - 1, 11);
                }

                //delete template sheet
                if (book.Sheets.Count > 1)
                {
                    tempSheet.Delete();
                }

                //set select first sheet
                ((Worksheet)book.Sheets[1]).Select();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (tempSheet != null) Marshal.ReleaseComObject(tempSheet);
                if (outputSheet != null) Marshal.ReleaseComObject(outputSheet);
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
