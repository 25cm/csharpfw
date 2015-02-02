using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJinendoGaikanIraiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJinendoGaikanIraiBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 一括請求先コード
        /// </summary>
        string SeikyusakiCd { get; set; }

        /// <summary>
        /// 検査予定年FROM
        /// </summary>
        string NendoFrom { get; set; }

        /// <summary>
        /// 検査予定年TO
        /// </summary>
        string NendoTo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJinendoGaikanIraiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanIraiBLInput : BaseExcelPrintBLInputImpl, IPrintJinendoGaikanIraiBLInput
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
        /// 一括請求先コード
        /// </summary>
        public string SeikyusakiCd { get; set; }

        /// <summary>
        /// 検査予定年FROM
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// 検査予定年TO
        /// </summary>
        public string NendoTo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJinendoGaikanIraiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJinendoGaikanIraiBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJinendoGaikanIraiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanIraiBLOutput : BaseExcelPrintBLOutputImpl, IPrintJinendoGaikanIraiBLOutput
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
    //  クラス名 ： PrintJinendoGaikanIraiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanIraiBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJinendoGaikanIraiBLInput, IPrintJinendoGaikanIraiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintJinendoGaikanIraiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJinendoGaikanIraiBusinessLogic()
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
        /// 2014/09/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJinendoGaikanIraiBLOutput SetBook(IPrintJinendoGaikanIraiBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintJinendoGaikanIraiBLOutput output = new PrintJinendoGaikanIraiBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Paginator
                string tempjSinSichosonCd = string.Empty;

                // Current detail row in page
                int curRow = 4;

                // Preparing data for print
                ISelectJinendoInputPrintBySeikyusakiCdNendoDAInput daInput = new SelectJinendoInputPrintBySeikyusakiCdNendoDAInput();
                daInput.SeikyusakiCd = input.SeikyusakiCd;
                daInput.NendoFrom = input.NendoFrom;
                daInput.NendoTo = input.NendoTo;
                ISelectJinendoInputPrintBySeikyusakiCdNendoDAOutput daOutput = new SelectJinendoInputPrintBySeikyusakiCdNendoDataAccess().Execute(daInput);
                JokasoDaichoMstDataSet.JinendoInputPrintDataTable printTable = daOutput.JinendoInputPrintDataTable;

                // 20141218 habu column changed JokasoSinSichosonCd -> JokasoGenChikuCd
                foreach (JokasoDaichoMstDataSet.JinendoInputPrintRow row in
                    printTable.Select(string.Empty, "JokasoGenChikuCd, JokasoHoteiSishoCd, KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban"))
                {
                    // Skip empty SinSichosonCd
                    if (row.IsJokasoGenChikuCdNull()) continue;

                    // New sheet?
                    if (tempjSinSichosonCd != row.JokasoGenChikuCd)
                    {
                        // Reset row index for new sheet
                        curRow = 4;

                        // Copy a new sheet
                        tempSheet = (Worksheet)book.Sheets["Sheet1"];
                        tempSheet.Copy(tempSheet, Type.Missing);

                        // Set output sheet to current active sheet
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = string.Concat("次年度外観依頼印刷チェックリスト_", row.JokasoGenChikuCd);

                        // Number of detail rows on each sheet
                        int rowCnt = printTable.Select(string.Format("JokasoGenChikuCd = '{0}'", row.JokasoGenChikuCd)).Length;

                        // Header
                        SetHeader(outputSheet, row, input.SystemDt, rowCnt);
                    }

                    // Detail page
                    SetDetail(outputSheet, row, curRow);

                    // Reset paginator
                    tempjSinSichosonCd = row.JokasoGenChikuCd;

                    // Next detail row
                    curRow++;
                }

                // 2シート以上あるか？
                if (book.Sheets.Count > 1)
                {
                    // テンプレートシートを削除
                    tempSheet.Delete();
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
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SetHeader
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <param name="now"></param>
        /// <param name="rowCnt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader(Worksheet outputSheet, JokasoDaichoMstDataSet.JinendoInputPrintRow row, DateTime now, int rowCnt)
        {
            // 検索結果の検査予定年
            CellOutput(outputSheet, 0, 0, string.Concat(row.KensaIraiKensaYoteiNen, "/04/01"));

            // 検索結果の支所名称
            CellOutput(outputSheet, 2, 7, row.ShishoNm);

            // 検査結果の地区名称
            CellOutput(outputSheet, 2, 21, row.ChikuNm);

            // 検査結果の新市町村コード
            CellOutput(outputSheet, 2, 35, string.Concat("'", row.JokasoGenChikuCd));

            // 検査結果の新市町村コード毎の件数
            CellOutput(outputSheet, 2, 50, rowCnt.ToString());

            // システム日付
            CellOutput(outputSheet, 2, 87, now);
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Worksheet outputSheet, JokasoDaichoMstDataSet.JinendoInputPrintRow row, int curRow)
        {
            // 検査結果の検査予定月(7)
            CellOutput(outputSheet, curRow, 0, string.Concat(row.KensaIraiKensaYoteiTsuki, "月"));

            // 検査結果の依頼業者名称(8)
            CellOutput(outputSheet, curRow, 4, row.IraiGyoshaNm);

            // 検査結果の保守点検業者名称(9)
            CellOutput(outputSheet, curRow, 13, row.HoshuGyoshaNm);

            // 検査結果の保健所コード/年度/連番(10)
            CellOutput(outputSheet, curRow, 22, string.Concat(row.KensaIraiHokenjoCd, "-",
                Boundary.Common.Common.ConvertToHoshouNendoWareki(row.KensaIraiNendo), "-", row.KensaIraiRenban));

            // 検査結果の設置者名（漢字）(11)
            CellOutput(outputSheet, curRow, 33, row.KensaIraiSetchishaNm);

            // 検査結果の検査依頼設置場所（住所）(12)
            CellOutput(outputSheet, curRow, 43, row.KensaIraiSetchibashoAdr);

            // 検査結果の処理方式区分名称(13)
            CellOutput(outputSheet, curRow, 58, row.ShoriHosikiKbnNm);

            // 検索結果の人槽(14)
            CellOutput(outputSheet, curRow, 62, row.Ninso);

            // 検索結果の検査依頼保健所コード/年度/連番(15)
            CellOutput(outputSheet, curRow, 66, string.Concat(row.Jo7NoHokenjoCd, "-",
                Boundary.Common.Common.ConvertToHoshouNendoWareki(row.Jo7NoNendo) + "0401", "-", row.Jo7NoRenban));

            // 検索結果の検査年/月/日(16)
            CellOutput(outputSheet, curRow, 78, string.Concat(row.KensaIraiKensaNen, "/", row.KensaIraiKensaTsuki, "/", row.KensaIraiKensaBi));

            // 検索結果の前回依頼保健所コード/年度/連番(17)
            CellOutput(outputSheet, curRow, 86, string.Concat(row.KensaIraiZenkaiHokenjoCd, "-",
                Boundary.Common.Common.ConvertToHoshouNendoWareki(row.KensaIraiZenkaiNendo), "0401", "-", row.KensaIraiZenkaiRenban));

            // 検索結果の前回検査日(18)
            CellOutput(outputSheet, curRow, 93, row.KensaIraiZenkaiKensaDt);
        }
        #endregion

        #endregion
    }
    #endregion
}
