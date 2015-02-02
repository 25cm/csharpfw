using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint015IrodoBLInput
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
    interface IPrint015IrodoBLInput : IBaseExcelPrintBLInput
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
    //  クラス名 ： Print015IrodoBLInput
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
    class Print015IrodoBLInput : BaseExcelPrintBLInputImpl, IPrint015IrodoBLInput
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
    //  インターフェイス名 ： IPrint015IrodoBLOutput
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
    interface IPrint015IrodoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print015IrodoBLOutput
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
    class Print015IrodoBLOutput : IPrint015IrodoBLOutput
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
    //  クラス名 ： Print015IrodoBusinessLogic
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
    class Print015IrodoBusinessLogic : BaseExcelPrintBusinessLogic<IPrint015IrodoBLInput, IPrint015IrodoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Print015IrodoBusinessLogic
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
        public Print015IrodoBusinessLogic()
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
        protected override IPrint015IrodoBLOutput SetBook(IPrint015IrodoBLInput input, Excel.Workbook book)
        {
            IPrint015IrodoBLOutput output = new Print015IrodoBLOutput();

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
                int curRow = 28;

                foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in input.PrintTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))
                {
                    // Header - 1 time only
                    if (curRow == 28)
                    {
                        // Header
                        CellOutput(outputSheet, 6, 1, input.SystemDt.ToString("yyyy/MM/dd"));
                    }

                    // (2)
                    CellOutput(outputSheet, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                    // (2)
                    CellOutput(outputSheet, curRow, 1, "'" + row.SetchishaNmCol);

                    curRow += 2;
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
