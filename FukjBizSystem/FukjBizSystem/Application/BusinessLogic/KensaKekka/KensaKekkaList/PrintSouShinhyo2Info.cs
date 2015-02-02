using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.Boundary.KensaKekka;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.KensaKekka.KensaKekkaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSouShinhyo2InfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSouShinhyo2InfoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// PrintMode
        /// </summary>
        KensaKekkaListForm.PrintMode PrintMode { get; set; }

        /// <summary>
        /// SouShinhyo2PrintInfoDataTable
        /// </summary>
        KensaIraiTblDataSet.SouShinhyo2PrintInfoDataTable SouShinhyo2PrintInfoDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSouShinhyo2InfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSouShinhyo2InfoBLInput : BaseExcelPrintBLInputImpl, IPrintSouShinhyo2InfoBLInput
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

        /// <summary>
        /// PrintMode
        /// </summary>
        public KensaKekkaListForm.PrintMode PrintMode { get; set; }

        ///// <summary>
        ///// 処理後印刷フラグ
        ///// </summary>
        //public bool AfterPrintFlg { get; set; }

        ///// <summary>
        ///// 印刷プリンタ名
        ///// </summary>
        //public string PrinterName { get; set; }

        /// <summary>
        /// SouShinhyo2PrintInfoDataTable
        /// </summary>
        public KensaIraiTblDataSet.SouShinhyo2PrintInfoDataTable SouShinhyo2PrintInfoDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSouShinhyo2InfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSouShinhyo2InfoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSouShinhyo2InfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSouShinhyo2InfoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSouShinhyo2InfoBLOutput
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
    //  クラス名 ： PrintSouShinhyo2InfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSouShinhyo2InfoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSouShinhyo2InfoBLInput, IPrintSouShinhyo2InfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSouShinhyo2InfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSouShinhyo2InfoBusinessLogic()
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
        /// 2014/08/15　HuyTX　　    新規作成
        /// 2014/10/10　HuyTX　　    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSouShinhyo2InfoBLOutput SetBook(IPrintSouShinhyo2InfoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSouShinhyo2InfoBLOutput output = new PrintSouShinhyo2InfoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["Sheet1"];
                KensaIraiTblDataSet.SouShinhyo2PrintInfoRow printRow = input.SouShinhyo2PrintInfoDataTable[0];
                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                //業者名称 (1)
                switch (input.PrintMode)
                {
                    case KensaKekkaListForm.PrintMode.FaxMk:
                        CellOutput(outputSheet, 4, 1, printRow.GyoshaNmMaker);
                        break;
                    case KensaKekkaListForm.PrintMode.FaxHosyu:
                        CellOutput(outputSheet, 4, 1, printRow.GyoshaNmHoshutenken);
                        break;
                    case KensaKekkaListForm.PrintMode.FaxKoji:
                        CellOutput(outputSheet, 4, 1, printRow.GyoshaNmKoiji);
                        break;
                    default:
                        break;
                }

                //検査依頼法定区分 (2)
                CellOutput(outputSheet, 6, 3, string.Format("浄化槽の法定検査({0}条検査)の結果について", printRow.KensaIraiHoteiKbn == "1" ? "7" : "11"));

                //システム日付 (3)
                CellOutput(outputSheet, 3, 28, "'" + Utility.DateUtility.ConvertToWareki(currentDateTime.Year.ToString(), "y"));
                CellOutput(outputSheet, 3, 31, "'" + currentDateTime.ToString("MM"));
                CellOutput(outputSheet, 3, 34, "'" + currentDateTime.ToString("dd"));

                //支所名称 (4)
                CellOutput(outputSheet, 8, 26, printRow.ShishoNm);

                //支所電話番号 (5)
                CellOutput(outputSheet, 9, 26, printRow.ShishoTelNo);

                //支所Fax番号 (6)
                CellOutput(outputSheet, 10, 26, printRow.ShishoFaxNo);

                //検査担当者  (7)
                CellOutput(outputSheet, 11, 30, printRow.KensaIraiKensaTantoshaNm);

                //設置者名（漢字）(9)
                CellOutput(outputSheet, 18, 6, printRow.KensaIraiSetchishaNm);

                //検査依頼設置場所（住所）(10)
                CellOutput(outputSheet, 19, 6,printRow.KensaIraiSetchibashoAdr);

                //メーカコード (11)
                CellOutput(outputSheet, 20, 6, printRow.GyoshaNmMaker);

                //工事業者コード  (12)
                CellOutput(outputSheet, 21, 6, printRow.GyoshaNmKoiji);

                //保守点検業者コード  (13)
                CellOutput(outputSheet, 22, 6, printRow.GyoshaNmHoshutenken);

                //検査年 検査月 検査日 (14)
                CellOutput(outputSheet, 18, 25, Utility.DateUtility.ConvertToWareki(string.Concat(printRow.KensaIraiKensaNen, printRow.KensaIraiKensaTsuki, printRow.KensaIraiKensaBi), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));


                //施設名称 (15)
                CellOutput(outputSheet, 19, 25, printRow.KensaIraiShisetsuNm);

                //処理方式区分 (16)
                CellOutput(outputSheet, 20, 25, printRow.ShoriHoshikiShubetsuNm);

                // 20141218 habu changed to int
                //処理対象人員 (17)
                CellOutput(outputSheet, 21, 25, !printRow.IsKensaIraiShoritaishoJininNull() ? (printRow.KensaIraiShoritaishoJinin + "人槽") : string.Empty);
                //CellOutput(outputSheet, 21, 25, !string.IsNullOrEmpty(printRow.KensaIraiShoritaishoJinin) ? (printRow.KensaIraiShoritaishoJinin + "人槽") : string.Empty);

                //型式コード (18)
                CellOutput(outputSheet, 22, 25, printRow.KatashikiNm);

            }
            catch (Exception)
            {
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
