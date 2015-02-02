using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint009TPZenzinBLInput
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
    interface IPrint009TPZenzinBLInput : IBaseExcelPrintBLInput
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
    //  クラス名 ： Print009TPZenzinBLInput
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
    class Print009TPZenzinBLInput : BaseExcelPrintBLInputImpl, IPrint009TPZenzinBLInput
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
    //  インターフェイス名 ： IPrint009TPZenzinBLOutput
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
    interface IPrint009TPZenzinBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print009TPZenzinBLOutput
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
    class Print009TPZenzinBLOutput : IPrint009TPZenzinBLOutput
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
    //  クラス名 ： Print009TPZenzinBusinessLogic
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
    class Print009TPZenzinBusinessLogic : BaseExcelPrintBusinessLogic<IPrint009TPZenzinBLInput, IPrint009TPZenzinBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Print009TPZenzinBusinessLogic
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
        public Print009TPZenzinBusinessLogic()
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
        protected override IPrint009TPZenzinBLOutput SetBook(IPrint009TPZenzinBLInput input, Excel.Workbook book)
        {
            IPrint009TPZenzinBLOutput output = new Print009TPZenzinBLOutput();

            Excel.Application application = null;
            Excel.Worksheet outputSheet1 = null;
            Excel.Worksheet outputSheet2 = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Output sheet 1
                outputSheet1 = (Excel.Worksheet)book.Sheets[1];
                outputSheet1.Name = "野帳（T-P）";
                // Output sheet 2
                outputSheet2 = (Excel.Worksheet)book.Sheets[2];
                outputSheet2.Name = "野帳（T-P(50mmセル)）";

                // Current processing row
                int curRow = 28;

                foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in input.PrintTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))
                {
                    // Header - 1 time only
                    if (curRow == 28)
                    {
                        // Header
                        string systemDt = Utility.DateUtility.ConvertToWareki(input.SystemDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
                        CellOutput(outputSheet1, 6, 1, systemDt);
                        CellOutput(outputSheet2, 6, 1, systemDt);
                    }

                    // (2)
                    CellOutput(outputSheet1, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                    CellOutput(outputSheet2, curRow, 0, "'" + row.SuishitsuKensaIraiNoCol);
                    // (3)
                    CellOutput(outputSheet1, curRow, 1, "'" + row.SetchishaNmCol);
                    CellOutput(outputSheet2, curRow, 1, "'" + row.SetchishaNmCol);

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
