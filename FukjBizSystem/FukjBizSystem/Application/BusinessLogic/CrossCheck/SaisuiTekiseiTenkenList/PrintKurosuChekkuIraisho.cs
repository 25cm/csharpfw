using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKurosuChekkuIraishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKurosuChekkuIraishoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKurosuChekkuIraishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKurosuChekkuIraishoBLInput : BaseExcelPrintBLInputImpl, IPrintKurosuChekkuIraishoBLInput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKurosuChekkuIraishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKurosuChekkuIraishoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKurosuChekkuIraishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKurosuChekkuIraishoBLOutput : IPrintKurosuChekkuIraishoBLOutput
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
    //  クラス名 ： PrintKurosuChekkuIraishoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKurosuChekkuIraishoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKurosuChekkuIraishoBLInput, IPrintKurosuChekkuIraishoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKurosuChekkuIraishoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKurosuChekkuIraishoBusinessLogic()
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
        /// 2014/12/23　AnhNV　　    新規作成
        /// 2014/12/30　小松　　　　出力順は「所属業者、採水員CD、水質検査持込日付、依頼番号」の昇順で、所属業者毎にシート出力
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKurosuChekkuIraishoBLOutput SetBook(IPrintKurosuChekkuIraishoBLInput input, Excel.Workbook book)
        {
            IPrintKurosuChekkuIraishoBLOutput output = new PrintKurosuChekkuIraishoBLOutput();

            Excel.Application application = null;
            Excel.Worksheet outputSheet = null;
            Excel.Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Current process row
                int curRow = 12;
                // Sheet counter
                int sheetCnt = 0;
                // Paginator variable
                string tempGyoshaCd = null;

                foreach (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row
                    //in input.PrintTable.Select(string.Empty, "KensaIraiSaisuiGyoshaCd, KensaIraiSaisuiinCd, ThisDate"))
                    in input.PrintTable.Select(string.Empty, "KensaIraiSaisuiGyoshaCd, KensaIraiSaisuiinCd, ThisDate, KensaKekkaSuishitsuIraiNo"))
                {
                    // New page?
                    if (tempGyoshaCd != row.KensaIraiSaisuiGyoshaCd)
                    {
                        // A new sheet is set
                        sheetCnt++;
                        curRow = 12;

                        // Copy a new sheet
                        tempSheet = (Excel.Worksheet)book.Sheets["Sheet1"];
                        tempSheet.Copy(tempSheet, Type.Missing);
                        outputSheet = (Excel.Worksheet)book.ActiveSheet;
                        outputSheet.Name = "クロスチェック_調査依頼票_" + sheetCnt;

                        // Header
                        SetHeader(outputSheet, row);
                    }

                    // Detail
                    SetDetail(outputSheet, row, curRow);

                    // Reset the paginator
                    tempGyoshaCd = row.KensaIraiSaisuiGyoshaCd;
                    // Next row
                    curRow += 3;

                    // 15 rows overflow
                    if (curRow >= 45) // Last row in page
                    {
                        CopyRow(outputSheet, 42, 3, curRow);
                    }
                }

                // More than 1 sheet?
                if (book.Sheets.Count > 1)
                {
                    tempSheet.Delete();
                }
                else if (book.Sheets.Count == 2) // 1 sheet is printed only
                {
                    outputSheet.Name = "クロスチェック_調査依頼票";
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
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SetHeader
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetHeader
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader
        (
            Excel.Worksheet sheet,
            KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row
        )
        {
            // (1)
            CellOutput(sheet, 3, 0, row.ShozokuGyoushaCol);
            // (2)
            CellOutput(sheet, 3, 8, "Tel：" + row.GyoshaTelNo);
            // (3)
            CellOutput(sheet, 4, 8, "Fax：" + row.GyoshaFaxNo);
            // (4)
            CellOutput(sheet, 3, 41, string.Format("一般財団法人　福岡県浄化槽協会　{0}検査センター", row.ShishoNm));
            // (5)
            CellOutput(sheet, 3, 42, "Tel：" + row.ShishoTelNo);
            // (6)
            CellOutput(sheet, 4, 42, "Fax：" + row.ShishoFaxNo);
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow">Starting of detail row</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail
        (
            Excel.Worksheet sheet,
            KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row,
            int curRow
        )
        {
            // EXCEL position - SCREEN position
            // (7) - (14)
            CellOutput(sheet, curRow, 0, "'" + row.KensaKekkaSuishitsuIraiNo);
            // (8) - (15)
            CellOutput(sheet, curRow, 2, row.HanteiCol);
            // (9) -(21)
            CellOutput(sheet, curRow, 3, row.SaisuiinNameCol);
            // (10)
            CellOutput(sheet, curRow, 7, row.KensaIraiSetchishaNm);
            // (11)
            CellOutput(sheet, curRow, 11, row.KensaIraiSetchibashoAdr);
            // (12) - (23), (24)
            CellOutput(sheet, curRow, 16, row.ShoriHoushikiCol + Environment.NewLine + row.ShoriHoushikiNmCol);
            //CellOutput(sheet, curRow + 1, 16, row.ShoriHoushikiNmCol);
            // (13) - (25)
            if (!row.IsKensaIraiShoriTaishoJininNull())
            {
                CellOutput(sheet, curRow, 20, row.KensaIraiShoriTaishoJinin);
            }
            // (14) - (40)
            if (!row.IsThisValueNull())
            {
                CellOutput(sheet, curRow, 22, row.ThisValue);
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
