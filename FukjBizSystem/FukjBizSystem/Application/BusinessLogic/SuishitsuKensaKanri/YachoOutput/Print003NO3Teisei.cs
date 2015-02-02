using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using System;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint003NO3TeiseiBLInput
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
    interface IPrint003NO3TeiseiBLInput : IBaseExcelPrintBLInput
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
    //  クラス名 ： Print003NO3TeiseiBLInput
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
    class Print003NO3TeiseiBLInput : BaseExcelPrintBLInputImpl, IPrint003NO3TeiseiBLInput
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
    //  インターフェイス名 ： IPrint003NO3TeiseiBLOutput
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
    interface IPrint003NO3TeiseiBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print003NO3TeiseiBLOutput
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
    class Print003NO3TeiseiBLOutput : IPrint003NO3TeiseiBLOutput
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
    //  クラス名 ： Print003NO3TeiseiBusinessLogic
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
    class Print003NO3TeiseiBusinessLogic : BaseExcelPrintBusinessLogic<IPrint003NO3TeiseiBLInput, IPrint003NO3TeiseiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Print003NO3TeiseiBusinessLogic
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
        public Print003NO3TeiseiBusinessLogic()
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
        /// 2014/12/20　小松  　　　１列目、２列目に正しく設定するように修正
        /// 2014/12/24  小松　　　　正しく設定されない（左、右のセットで次の行へ）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrint003NO3TeiseiBLOutput SetBook(IPrint003NO3TeiseiBLInput input, Excel.Workbook book)
        {
            IPrint003NO3TeiseiBLOutput output = new Print003NO3TeiseiBLOutput();

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
                int curRow = 4;

                KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] rows = (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])input.PrintTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc");

                for (int i = 0; i < rows.Length; i++)
                {
                    // Header - 1 time only
                    if (curRow == 4)
                    {
                        // Header
                        CellOutput(outputSheet, 1, 1, input.SystemDt.ToString("yyyy/MM/dd"));
                    }

                    if ((i % 2) == 0)
                    {
                        // (2)
                        CellOutput(outputSheet, curRow, 1, "'" + rows[i].SuishitsuKensaIraiNoCol);
                    }
                    else
                    {
                        // (4)
                        CellOutput(outputSheet, curRow, 4, "'" + rows[i].SuishitsuKensaIraiNoCol);
                        // 左、右のセットで次の行へ
                        curRow += 1;
                    }

                    //curRow += 1;
                }
                //foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in input.PrintTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))
                //{
                //    // Header - 1 time only
                //    if (curRow == 4)
                //    {
                //        // Header
                //        CellOutput(outputSheet, 1, 1, input.SystemDt.ToString("yyyy/MM/dd"));
                //    }

                //    // (2)
                //    CellOutput(outputSheet, curRow, 1, "'" + row.SuishitsuKensaIraiNoCol);
                //    // (4)
                //    CellOutput(outputSheet, curRow, 4, "'" + row.SuishitsuKensaIraiNoCol);

                //    curRow += 1;
                //}
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
