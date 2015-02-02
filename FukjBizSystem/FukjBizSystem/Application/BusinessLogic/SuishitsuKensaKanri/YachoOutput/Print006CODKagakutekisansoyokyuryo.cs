using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint006CODKagakutekisansoyokyuryoBLInput
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
    interface IPrint006CODKagakutekisansoyokyuryoBLInput : IBaseExcelPrintBLInput
    {
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
    //  クラス名 ： Print006CODKagakutekisansoyokyuryoBLInput
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
    class Print006CODKagakutekisansoyokyuryoBLInput : BaseExcelPrintBLInputImpl, IPrint006CODKagakutekisansoyokyuryoBLInput
    {
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
    //  インターフェイス名 ： IPrint006CODKagakutekisansoyokyuryoBLOutput
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
    interface IPrint006CODKagakutekisansoyokyuryoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print006CODKagakutekisansoyokyuryoBLOutput
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
    class Print006CODKagakutekisansoyokyuryoBLOutput : IPrint006CODKagakutekisansoyokyuryoBLOutput
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
    //  クラス名 ： Print006CODKagakutekisansoyokyuryoBusinessLogic
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
    class Print006CODKagakutekisansoyokyuryoBusinessLogic : BaseExcelPrintBusinessLogic<IPrint006CODKagakutekisansoyokyuryoBLInput, IPrint006CODKagakutekisansoyokyuryoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Print006CODKagakutekisansoyokyuryoBusinessLogic
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
        public Print006CODKagakutekisansoyokyuryoBusinessLogic()
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
        protected override IPrint006CODKagakutekisansoyokyuryoBLOutput SetBook(IPrint006CODKagakutekisansoyokyuryoBLInput input, Excel.Workbook book)
        {
            IPrint006CODKagakutekisansoyokyuryoBLOutput output = new Print006CODKagakutekisansoyokyuryoBLOutput();

            Excel.Application application = null;
            Excel.Worksheet outputSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Output sheet
                outputSheet = (Excel.Worksheet)book.Sheets[1];
                outputSheet.Name = "野帳";

                // Current processing row
                int curRow = 24;

                foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in input.PrintTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))
                {
                    // Header - 1 time only
                    if (curRow == 24)
                    {
                        // Header
                        CellOutput(outputSheet, 2, 11, input.SystemDt.ToString("yyyy/MM/dd"));
                    }

                    // 1st block
                    if (curRow < 74) // 50 detail row + 24 header row
                    {
                        // (2)
                        CellOutput(outputSheet, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                        // (3)
                        CellOutput(outputSheet, curRow, 1, "'" + row.SetchishaNmCol);
                    }
                    else // 2nd block
                    {
                        if (curRow == 74)
                        {
                            curRow += 16;
                        }

                        // (2)
                        CellOutput(outputSheet, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                        // (3)
                        CellOutput(outputSheet, curRow, 1, "'" + row.SetchishaNmCol);
                    }

                    curRow += 5;
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
                #endregion
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
