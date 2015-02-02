using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.HoteiKanriMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoNoPrint
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintHoshoNoInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintHoshoNoInfoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// HoshoNoPrintInfoDataTable
        /// </summary>
        HoshoTorokuTblDataSet.HoshoNoPrintInfoDataTable HoshoNoPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHoshoNoInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintHoshoNoInfoBLInput : BaseExcelPrintBLInputImpl, IPrintHoshoNoInfoBLInput
    {
        ///// <summary>
        ///// 保存ファイルモード
        ///// </summary>
        //public int SaveFileMode
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// ＥＸＣＥＬ書式へのパス
        ///// </summary>
        //public string FormatPath
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 帳票ディレクトリパス
        ///// </summary>
        //public string PrintDirectory
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 指定保存パス
        ///// 未指定の場合は、帳票出力ディレクトリに出力されます
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 処理後ＥＸＣＥＬ表示フラグ
        ///// </summary>
        //public bool AfterDispFlg
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 処理後印刷フラグ
        ///// </summary>
        //public bool AfterPrintFlg { get; set; }

        ///// <summary>
        ///// 印刷プリンタ名
        ///// </summary>
        //public string PrinterName { get; set; }

        /// <summary>
        /// HoshoNoPrintInfoDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoNoPrintInfoDataTable HoshoNoPrintInfoDataTable { get; set; }

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintHoshoNoInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintHoshoNoInfoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHoshoNoInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintHoshoNoInfoBLOutput : BaseExcelPrintBLOutputImpl, IPrintHoshoNoInfoBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHoshoNoInfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintHoshoNoInfoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintHoshoNoInfoBLInput, IPrintHoshoNoInfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintHoshoNoInfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintHoshoNoInfoBusinessLogic()
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
        /// 2014/08/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintHoshoNoInfoBLOutput SetBook(IPrintHoshoNoInfoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintHoshoNoInfoBLOutput output = new PrintHoshoNoInfoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["HoshoTorokuShinseisho"];

                if (input.HoshoNoPrintInfoDataTable.Count == 0) { return output; }

                ISelectHoteiKanriMstByKeyDAInput daInput = new SelectHoteiKanriMstByKeyDAInput();
                daInput.JimukyokuKbn = input.HoshoNoPrintInfoDataTable[0].JimukyokuKbn2;
                ISelectHoteiKanriMstByKeyDAOutput daOutput = new SelectHoteiKanriMstByKeyDataAccess().Execute(daInput);

                int pageIdx = 1;
                int rowCount = 61;
                foreach (HoshoTorokuTblDataSet.HoshoNoPrintInfoRow rowPrint in input.HoshoNoPrintInfoDataTable)
                {
                    SetShapeText(outputSheet, "HoshoTorokuKensaKikanTextBox", rowPrint.HoshoTorokuKensakikan);
                    // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
                    //SetShapeText(outputSheet, "HoshoTorokuNendoTextBox", Boundary.Common.Common.ConvertToHoshouNendoWareki(rowPrint.HoshoTorokuNendo));
                    SetShapeText(outputSheet, "HoshoTorokuNendoTextBox", Utility.DateUtility.ConvertToWareki(rowPrint.HoshoTorokuNendo, "yy"));
                    //SetShapeText(outputSheet, "HoshoTorokuNendoTextBox", Utility.Utility.ConvertToHeisei(Int32.Parse(rowPrint.HoshoTorokuNendo)));
                    // 20140811 habu End
                    SetShapeText(outputSheet, "HoshoTorokuRenbanTextBox", rowPrint.HoshoTorokuRenban);
                    SetShapeText(outputSheet, "KensaKikanTextBox", rowPrint.JimukyokuNm1);
                    SetShapeText(outputSheet, "ThuikaKisaiKomokuTextBox", rowPrint.TsuikaKisaiKomoku);
                    SetShapeText(outputSheet, "TorokuKakuninHojinNmTextBox", rowPrint.JimukyokuNm2);
                    SetShapeText(outputSheet, "TorokuKakuninHojinAdrTextBox", daOutput.HoteiKanriMstDataTable[0].JimukyokuHoteiKanriAdr);
                    SetShapeText(outputSheet, "TorokuKakuninHojinTelTextBox", "TEL  " + daOutput.HoteiKanriMstDataTable[0].JimukyokuTelNo);
                    SetShapeText(outputSheet, "TorokuKakuninHojinFaxTextBox", "FAX  " + daOutput.HoteiKanriMstDataTable[0].JimukyokuFaxNo);
                    SetShapeText(outputSheet, "KakuninShaNmTextBox", rowPrint.KakuninShaNm);

                    CopyRow(outputSheet, 0, rowCount - 1, rowCount * pageIdx);
                    SetPageBreak(outputSheet, rowCount * pageIdx);
                    pageIdx++;
                   
                }

                //delete first page
                DeleteRow(outputSheet, 0, rowCount);

            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
