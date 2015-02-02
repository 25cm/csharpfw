using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaIraiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintShiyoKaishiHagakiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintShiyoKaishiHagakiBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// Jo7KensaIraiListDataTable
        /// </summary>
        KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintShiyoKaishiHagakiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintShiyoKaishiHagakiBLInput : BaseExcelPrintBLInputImpl, IPrintShiyoKaishiHagakiBLInput
    {
        ///// <summary>
        ///// 保存ファイルモード
        ///// </summary>
        //public int SaveFileMode { get; set; }

        ///// <summary>
        ///// ＥＸＣＥＬ書式へのパス
        ///// </summary>
        //public string FormatPath { get; set; }

        ///// <summary>
        ///// 帳票ディレクトリパス
        ///// </summary>
        //public string PrintDirectory { get; set; }

        ///// <summary>
        ///// 指定保存パス
        ///// 未指定の場合は、帳票出力ディレクトリに出力されます
        ///// </summary>
        //public string SavePath { get; set; }

        ///// <summary>
        ///// 処理後ＥＸＣＥＬ表示フラグ
        ///// </summary>
        //public bool AfterDispFlg { get; set; }

        ///// <summary>
        ///// 処理後印刷フラグ
        ///// </summary>
        //public bool AfterPrintFlg { get; set; }

        ///// <summary>
        ///// 印刷プリンタ名
        ///// </summary>
        //public string PrinterName { get; set; }

        /// <summary>
        /// Jo7KensaIraiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintShiyoKaishiHagakiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintShiyoKaishiHagakiBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintShiyoKaishiHagakiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintShiyoKaishiHagakiBLOutput : BaseExcelPrintBLOutputImpl, IPrintShiyoKaishiHagakiBLOutput
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
    //  クラス名 ： PrintShiyoKaishiHagakiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintShiyoKaishiHagakiBusinessLogic : BaseExcelPrintBusinessLogic<IPrintShiyoKaishiHagakiBLInput, IPrintShiyoKaishiHagakiBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// SETCHISHA_NM_ROW_IDX 
        /// </summary>
        private const int SETCHISHA_NM_ROW_IDX = 3;

        /// <summary>
        /// SETCHISHAADR_ROW_IDX 
        /// </summary>
        private const int SETCHISHA_ADR_ROW_IDX = 6;

        /// <summary>
        /// SETCHIBASHOADR_ROW_IDX 
        /// </summary>
        private const int SETCHIBASHO_ADR_ROW_IDX = 9;

        /// <summary>
        /// KYOKAI_NO_ROW_IDX 
        /// </summary>
        private const int KYOKAI_NO_ROW_IDX = 29;

        /// <summary>
        /// ROW_COUNT_OF_TEMPLATE_PAGE  
        /// </summary>
        private const int ROW_COUNT_OF_TEMPLATE_PAGE = 32;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintShiyoKaishiHagakiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintShiyoKaishiHagakiBusinessLogic()
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
        /// 2014/09/05  HuyTX　　    新規作成
        /// 2014/10/06  HuyTX　　    V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintShiyoKaishiHagakiBLOutput SetBook(IPrintShiyoKaishiHagakiBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintShiyoKaishiHagakiBLOutput output = new PrintShiyoKaishiHagakiBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                int pageIdx = 0;

                foreach (KensaIraiTblDataSet.Jo7KensaIraiListRow printRow in input.Jo7KensaIraiListDataTable)
                {
                    if (pageIdx > 0)
                    {
                        outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[(ROW_COUNT_OF_TEMPLATE_PAGE * pageIdx) + 1, 1]);

                        //copy row template
                        CopyRow(outputSheet, 0, ROW_COUNT_OF_TEMPLATE_PAGE, ROW_COUNT_OF_TEMPLATE_PAGE * pageIdx);
                    }

                    //(1)
                    CellOutput(outputSheet, SETCHISHA_NM_ROW_IDX + (ROW_COUNT_OF_TEMPLATE_PAGE * pageIdx), 3, printRow.KensaIraiSetchishaAdr);

                    //(2)
                    CellOutput(outputSheet, SETCHISHA_ADR_ROW_IDX + (ROW_COUNT_OF_TEMPLATE_PAGE * pageIdx), 3, printRow.KensaIraiSetchishaNm);

                    //(3)
                    CellOutput(outputSheet, SETCHIBASHO_ADR_ROW_IDX + (ROW_COUNT_OF_TEMPLATE_PAGE * pageIdx), 3, printRow.KensaIraiSetchibashoAdr);

                    //(4) 
                    CellOutput(outputSheet, KYOKAI_NO_ROW_IDX + (ROW_COUNT_OF_TEMPLATE_PAGE * pageIdx), 8, printRow.KyokaiNo);

                    pageIdx++;
                }
            }
            catch
            {
                throw;
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
