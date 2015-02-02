using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint004NO2TeiryoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrint004NO2TeiryoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// Starting print row
        /// </summary>
        int RowIdx { get; set; }

        /// <summary>
        /// Number of book printed
        /// </summary>
        int BookCnt { get; set; }

        /// <summary>
        /// 当日
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// YachoOutputKensaListDataTable
        /// </summary>
        KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print004NO2TeiryoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print004NO2TeiryoBLInput : BaseExcelPrintBLInputImpl, IPrint004NO2TeiryoBLInput
    {
        /// <summary>
        /// Starting print row
        /// </summary>
        public int RowIdx { get; set; }

        /// <summary>
        /// Number of book printed
        /// </summary>
        public int BookCnt { get; set; }

        /// <summary>
        /// 当日
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// YachoOutputKensaListDataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable PrintTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint004NO2TeiryoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrint004NO2TeiryoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print004NO2TeiryoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print004NO2TeiryoBLOutput : IPrint004NO2TeiryoBLOutput
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
    //  クラス名 ： Print004NO2TeiryoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print004NO2TeiryoBusinessLogic : BaseExcelPrintBusinessLogic<IPrint004NO2TeiryoBLInput, IPrint004NO2TeiryoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Print004NO2TeiryoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Print004NO2TeiryoBusinessLogic()
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
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrint004NO2TeiryoBLOutput SetBook(IPrint004NO2TeiryoBLInput input, Excel.Workbook book)
        {
            IPrint004NO2TeiryoBLOutput output = new Print004NO2TeiryoBLOutput();

            Excel.Application application = null;
            Excel.Worksheet outputSheet1 = null;
            Excel.Worksheet outputSheet2 = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Output sheet
                outputSheet1 = (Excel.Worksheet)book.Sheets[1];
                outputSheet1.Name = "野帳（NO2-N）";
                // Output sheet
                outputSheet2 = (Excel.Worksheet)book.Sheets[2];
                outputSheet2.Name = "野帳（NO2-N(凝集沈殿あり)）";

                // Current processing row
                int curRow = 28; int curRow2 = 28;
                // Number of row in print table
                int numRow = 1;

                // Print 野帳（NO2-N）sheet
                foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in input.PrintTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))
                {
                    // Header - 1 time only
                    if (numRow == 1)
                    {
                        // Header
                        CellOutput(outputSheet1, 6, 1, input.SystemDt.ToString("yyyy/MM/dd"));
                        CellOutput(outputSheet2, 6, 1, input.SystemDt.ToString("yyyy/MM/dd"));
                    }

                    // First book
                    if (input.BookCnt == 0)
                    {
                        if (numRow <= 7)
                        {
                            // Print sheet 1
                            CellOutput(outputSheet1, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                            CellOutput(outputSheet1, curRow, 1, "'" + row.SetchishaNmCol);
                        }
                        else
                        {
                            break;
                        }

                        if (numRow <= 6)
                        {
                            // Print sheet 2
                            CellOutput(outputSheet2, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                            CellOutput(outputSheet2, curRow, 1, "'" + row.SetchishaNmCol);
                        }

                        curRow += 3;
                    }
                    else // From book No.2
                    {
                        if (7* input.BookCnt < numRow
                            && numRow <= 14 * input.BookCnt)
                        {
                            // Print sheet 1
                            CellOutput(outputSheet1, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                            CellOutput(outputSheet1, curRow, 1, "'" + row.SetchishaNmCol);

                            curRow += 3;
                        }
                        else if (numRow > 14 * input.BookCnt)
                        {
                            break;
                        }

                        if (6 * input.BookCnt < numRow
                            && numRow <= 12 * input.BookCnt)
                        {
                            // Print sheet 2
                            CellOutput(outputSheet2, curRow2, 0, "'" + row.SuishitsuKensaIraiNoCol);
                            CellOutput(outputSheet2, curRow2, 1, "'" + row.SetchishaNmCol);

                            curRow2 += 3;
                        }
                    }

                    numRow++;
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
                if (outputSheet1 != null) { Marshal.ReleaseComObject(outputSheet1); }
                if (outputSheet2 != null) { Marshal.ReleaseComObject(outputSheet2); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
