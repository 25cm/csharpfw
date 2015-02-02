using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensa7To11JoIkoJokyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensa7To11JoIkoJokyoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// Kensa7To11JoIkoJokyoDataTable
        /// </summary>
        IkoJokyoShukeiWrkDataSet.Kensa7To11JoIkoJokyoDataTable Kensa7To11JoIkoJokyoDataTable { get; set; }

        /// <summary>
        /// ShukeiKaishiNendo 
        /// </summary>
        int ShukeiKaishiNendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensa7To11JoIkoJokyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensa7To11JoIkoJokyoBLInput : BaseExcelPrintBLInputImpl, IPrintKensa7To11JoIkoJokyoBLInput
    {
        /// <summary>
        /// Kensa7To11JoIkoJokyoDataTable
        /// </summary>
        public IkoJokyoShukeiWrkDataSet.Kensa7To11JoIkoJokyoDataTable Kensa7To11JoIkoJokyoDataTable { get; set; }

        /// <summary>
        /// ShukeiKaishiNendo 
        /// </summary>
        public int ShukeiKaishiNendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensa7To11JoIkoJokyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensa7To11JoIkoJokyoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensa7To11JoIkoJokyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensa7To11JoIkoJokyoBLOutput : IPrintKensa7To11JoIkoJokyoBLOutput
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
    //  クラス名 ： PrintKensa7To11JoIkoJokyoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensa7To11JoIkoJokyoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensa7To11JoIkoJokyoBLInput, IPrintKensa7To11JoIkoJokyoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensa7To11JoIkoJokyoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensa7To11JoIkoJokyoBusinessLogic()
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
        /// 2014/10/29  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensa7To11JoIkoJokyoBLOutput SetBook(IPrintKensa7To11JoIkoJokyoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensa7To11JoIkoJokyoBLOutput output = new PrintKensa7To11JoIkoJokyoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                DateTime currentDt = Boundary.Common.Common.GetCurrentTimestamp();
                int colIdx = 2;
                int rowIdx = 4;
                int sheetIdx = 1;
                string fomulas = string.Empty;

                for (int i = 0; i < input.Kensa7To11JoIkoJokyoDataTable.Count; i++)
                {
                    IkoJokyoShukeiWrkDataSet.Kensa7To11JoIkoJokyoRow printRow = input.Kensa7To11JoIkoJokyoDataTable[i];
                    IkoJokyoShukeiWrkDataSet.Kensa7To11JoIkoJokyoRow previousRow = input.Kensa7To11JoIkoJokyoDataTable[(i <= 1) ? 0 : (i - 1)];
                    IkoJokyoShukeiWrkDataSet.Kensa7To11JoIkoJokyoRow nextRow = input.Kensa7To11JoIkoJokyoDataTable[i < input.Kensa7To11JoIkoJokyoDataTable.Count - 2 ? (i + 1) : i];

                    #region output header

                    if (i == 0 || printRow.KensaIraiHokenjoCd != previousRow.KensaIraiHokenjoCd)
                    {
						//受入20141226 mod
						//if (rowIdx >= 30 || i == input.Kensa7To11JoIkoJokyoDataTable.Count - 1)
						if (outputSheet != null && rowIdx >= 30)
						{
							//outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[rowIdx + 1, 1]);
							DeleteRow(outputSheet, 30, 1);
							//set print area
							SetPrintArea(outputSheet, 0, 0, rowIdx, 17);
						}

                        //copy temp sheet
                        tempSheet.Copy(tempSheet, Type.Missing);
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = string.Format("7条⇒11条検査移行状況表({0})", sheetIdx);

                        //(1)保健所名
                        CellOutput(outputSheet, 1, 1, !string.IsNullOrEmpty(printRow.HokenjoNm) ? printRow.HokenjoNm : string.Empty);

                        //(2)システム日付
                        CellOutput(outputSheet, 1, 14, currentDt.ToString("yyyy/MM/dd"));

                        //(3)
                        CellOutput(outputSheet, 2, 2, Utility.DateUtility.ConvertToWareki(string.Concat(input.ShukeiKaishiNendo.ToString(), "0101"), "gyy年度", Utility.DateUtility.GengoKbn.Wareki));

                        //(4)
                        CellOutput(outputSheet, 2, 5, Utility.DateUtility.ConvertToWareki(string.Concat((input.ShukeiKaishiNendo + 1).ToString(), "0101"), "gyy年度", Utility.DateUtility.GengoKbn.Wareki));

                        //(5)
                        CellOutput(outputSheet, 2, 8, Utility.DateUtility.ConvertToWareki(string.Concat((input.ShukeiKaishiNendo + 2).ToString(), "0101"), "gyy年度", Utility.DateUtility.GengoKbn.Wareki));

                        //(6)
                        CellOutput(outputSheet, 2, 11, Utility.DateUtility.ConvertToWareki(string.Concat((input.ShukeiKaishiNendo + 3).ToString(), "0101"), "gyy年度", Utility.DateUtility.GengoKbn.Wareki));

                        rowIdx = 4;
                        sheetIdx++;
                    }

                    #endregion

                    #region output content

                    if (rowIdx >= 30)
                    {
                        rowIdx = (rowIdx == 30) ? (rowIdx + 1) : rowIdx;
                        CopyRow(outputSheet, 30, 1, rowIdx);
                    }

                    //(7)地区名称 
                    CellOutput(outputSheet, rowIdx, 1, printRow.ChikuNm);

                    if (printRow.KensaIraiNendo == input.ShukeiKaishiNendo.ToString())
                    {
                        colIdx = 2;
                        fomulas = string.Format("=D{0}/C{0}", rowIdx + 1);
                    }
                    else if (printRow.KensaIraiNendo == (input.ShukeiKaishiNendo + 1).ToString())
                    {
                        colIdx = 5;
                        fomulas = string.Format("=G{0}/F{0}", rowIdx + 1);
                    }
                    else if (printRow.KensaIraiNendo == (input.ShukeiKaishiNendo + 2).ToString())
                    {
                        colIdx = 8;
                        fomulas = string.Format("=J{0}/I{0}", rowIdx + 1);
                    }
                    else if (printRow.KensaIraiNendo == (input.ShukeiKaishiNendo + 3).ToString())
                    {
                        colIdx = 11;
                        fomulas = string.Format("=M{0}/L{0}", rowIdx + 1);
                    }

                    //(8), (11), (14), (17)7条実施数
                    CellOutput(outputSheet, rowIdx, colIdx, !printRow.IsKensa7JoJisshiCntNull() ? printRow.Kensa7JoJisshiCnt.ToString() : string.Empty);

                    //(9), (12), (15), (18)移行済数
                    CellOutput(outputSheet, rowIdx, colIdx + 1, !printRow.IsIkoSumiCntNull() ? printRow.IkoSumiCnt.ToString() : string.Empty);

                    //(10), (13), (16), (19)
                    CellOutput(outputSheet, rowIdx, colIdx + 2, fomulas);

                    //(20)
                    CellOutput(outputSheet, rowIdx, 14, string.Format("=SUM(C{0},F{0},I{0},L{0})", rowIdx + 1));

                    //(21)
                    CellOutput(outputSheet, rowIdx, 15, string.Format("=SUM(D{0},G{0},J{0},M{0})", rowIdx + 1));

                    //(22)
                    CellOutput(outputSheet, rowIdx, 16, string.Format("=P{0}/O{0}", rowIdx + 1));

                    if (printRow.JokasoGenChikuCd != nextRow.JokasoGenChikuCd)
                    {
                        rowIdx++;
                    }

                    #endregion

                }

                //delete template sheet
                if (book.Sheets.Count > 1 && tempSheet != null)
                {
                    tempSheet.Delete();
                }

                //set select first sheet
                ((Worksheet)book.Sheets[1]).Select(Type.Missing);
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
