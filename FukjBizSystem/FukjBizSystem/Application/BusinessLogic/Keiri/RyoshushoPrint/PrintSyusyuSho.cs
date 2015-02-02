using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.HoteiKanriMst;
using FukjBizSystem.Application.DataAccess.ShishoMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.RyoshushoPrint
{
    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyusyuShoData
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SyusyuShoData
    {
        /// <summary>
        /// 郵便番号
        /// </summary>
        public string ZipNo { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public string Adr { get; set; }

        /// <summary>
        /// TEL
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// FAX
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 宛名
        /// </summary>
        public string GyoshaNm { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// 発行No
        /// </summary>
        public string HakkoNo { get; set; }

        /// <summary>
        /// 発行日
        /// </summary>
        public string HakkoDt { get; set; }

        /// <summary>
        /// 職員名
        /// </summary>
        public string ShokuinNm { get; set; }

        /// <summary>
        /// 口座名
        /// </summary>
        public string KozaNm { get; set; }

        /// <summary>
        /// 1: Pattern 1
        /// 2: Pattern 2
        /// 3: Pattern 3
        /// </summary>
        public string PatternNo { get; set; }

        /// <summary>
        /// 1: 消費税区分/内税(13)
        /// 2: 消費税区分/外税(14)
        /// 3: 消費税区分/なし(15)
        /// </summary>
        public string ShohizeiKbn { get; set; }

        /// <summary>
        /// 補足事項(29)
        /// </summary>
        public string Hoshoku { get; set; }

        /// <summary>
        /// 消費税額(30)
        /// </summary>
        public decimal Shohizei { get; set; }

        /// <summary>
        /// 合計金額(31)
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// RyushushoPrintDataTable
        /// </summary>
        public YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSyusyuShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSyusyuShoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SyusyuShoData
        /// </summary>
        SyusyuShoData SyusyuShoData { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSyusyuShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSyusyuShoBLInput : BaseExcelPrintBLInputImpl, IPrintSyusyuShoBLInput
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
        /// SyusyuShoData
        /// </summary>
        public SyusyuShoData SyusyuShoData { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSyusyuShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSyusyuShoBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSyusyuShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSyusyuShoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSyusyuShoBLOutput
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
    //  クラス名 ： PrintSyusyuShoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSyusyuShoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSyusyuShoBLInput, IPrintSyusyuShoBLOutput>
    {
        #region 置換文字列



        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSyusyuShoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSyusyuShoBusinessLogic()
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
        /// 2014/09/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSyusyuShoBLOutput SetBook(IPrintSyusyuShoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSyusyuShoBLOutput output = new PrintSyusyuShoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;
            Worksheet delSheet1 = null;
            Worksheet delSheet2 = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Copy a new sheet
                switch (input.SyusyuShoData.PatternNo)
                {
                    case "1":
                        tempSheet = (Worksheet)book.Sheets["パターン１"];
                        delSheet1 = (Worksheet)book.Sheets["パターン２"];
                        delSheet2 = (Worksheet)book.Sheets["パターン３"];
                        break;
                    case "2":
                        tempSheet = (Worksheet)book.Sheets["パターン２"];
                        delSheet1 = (Worksheet)book.Sheets["パターン１"];
                        delSheet2 = (Worksheet)book.Sheets["パターン３"];
                        break;
                    case "3":
                        tempSheet = (Worksheet)book.Sheets["パターン３"];
                        delSheet1 = (Worksheet)book.Sheets["パターン１"];
                        delSheet2 = (Worksheet)book.Sheets["パターン２"];
                        break;
                    default:
                        break;
                }
                tempSheet.Copy(tempSheet, Type.Missing);

                // Set output sheet to current active sheet
                outputSheet = (Worksheet)book.ActiveSheet;
                outputSheet.Name = "領収書";

                // Get 法定管理マスタ by key
                ISelectHoteiKanriMstByKeyDAInput hoteiInput = new SelectHoteiKanriMstByKeyDAInput();
                hoteiInput.JimukyokuKbn = "0";
                ISelectHoteiKanriMstByKeyDAOutput hoteiOutput = new SelectHoteiKanriMstByKeyDataAccess().Execute(hoteiInput);
                // 事務局代表者名
                string daihoshaNm = hoteiOutput.HoteiKanriMstDataTable.Count > 0 ? hoteiOutput.HoteiKanriMstDataTable[0].JimukyokuDaihyoshaNm : string.Empty;

                // Get 支所マスタ by key
                ISelectShishoMstByKeyDAInput shishoInput = new SelectShishoMstByKeyDAInput();
                shishoInput.ShishoCd = input.SyusyuShoData.ShishoCd;
                ISelectShishoMstByKeyDAOutput shishoOutput = new SelectShishoMstByKeyDataAccess().Execute(shishoInput);
                ShishoMstDataSet.ShishoMstRow shishoRow = shishoOutput.ShishoMstDataTable[0];

                // 品名(22) + 数量(23) + 単位(24)
                string hinmeiSuryoTani = GetHinmeiSuryoTani(input.SyusyuShoData.PrintTable);

                // Which pattern is using?
                switch (input.SyusyuShoData.PatternNo)
                {
                    // Pattern 1
                    case "1":
                        // 上段
                        PrintTypeA(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, hinmeiSuryoTani, 0);
                        // 中段
                        PrintTypeA(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, hinmeiSuryoTani, 24);
                        // 下段
                        PrintTypeB(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, 48);
                        break;
                    // Pattern 2
                    case "2":
                        // 上段
                        PrintTypeA(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, hinmeiSuryoTani, 0);
                        // 中段
                        PrintTypeA(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, hinmeiSuryoTani, 24);
                        // 下段
                        PrintTypeA(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, hinmeiSuryoTani, 48);
                        break;
                    // Pattern 3
                    case "3":
                        // 上段
                        PrintTypeB(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, 0);
                        // 中段
                        PrintTypeB(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, 27);
                        // 下段
                        PrintTypeB(outputSheet, input.SyusyuShoData, shishoRow, daihoshaNm, 54);
                        break;
                    default:
                        break;
                }

                // 2シート以上あるか？
                if (book.Sheets.Count > 3)
                {
                    // テンプレートシートを削除
                    tempSheet.Delete();
                    delSheet1.Delete();
                    delSheet2.Delete();
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

        #region PrintTypeA
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintTypeA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printData"></param>
        /// <param name="shishoRow"></param>
        /// <param name="daihoshaNm"></param>
        /// <param name="hinmeiSuryoTani"></param>
        /// <param name="startRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintTypeA
            (
                Worksheet outputSheet,
                SyusyuShoData printData,
                ShishoMstDataSet.ShishoMstRow shishoRow,
                string daihoshaNm,
                string hinmeiSuryoTani,
                int startRow
            )
        {
            // 郵便番号(1)
            CellOutput(outputSheet, startRow + 1, 4, "'" + printData.ZipNo);

            // 住所(2)
            CellOutput(outputSheet, startRow + 2, 3, printData.Adr);

            // TEL(3)
            CellOutput(outputSheet, startRow + 4, 5, "'" + printData.Tel);

            // FAX(4)
            CellOutput(outputSheet, startRow + 4, 12, "'" + printData.Fax);

            // 業者（宛名）(5)
            CellOutput(outputSheet, startRow + 5, 3, printData.GyoshaNm);

            // 業者コード(6)
            CellOutput(outputSheet, startRow + 7, 7, "'" + printData.GyoshaCd);

            // 発行番号(7)
            CellOutput(outputSheet, startRow + 1, 30, "'" + printData.HakkoNo);

            // 発行日(8)
            CellOutput(outputSheet, startRow + 2, 29, printData.HakkoDt);

            // 合計金額(9)
            CellOutput(outputSheet, startRow + 4, 24, printData.Total.ToString("N0"));

            // 事務局代表者名(10)
            CellOutput(outputSheet, startRow + 11, 23, daihoshaNm);

            // 支所郵便番号(11)
            CellOutput(outputSheet, startRow + 12, 20, "〒" + shishoRow.ShishoZipCd);

            // 支所住所(12)
            CellOutput(outputSheet, startRow + 13, 20, shishoRow.ShishoAdr);

            // 支所電話番号(13)
            CellOutput(outputSheet, startRow + 14, 20, "TEL." + shishoRow.ShishoTelNo);

            // 支所Fax番号(14)
            CellOutput(outputSheet, startRow + 14, 26, "FAX." + shishoRow.ShishoFaxNo);

            // 発行者(15)
            CellOutput(outputSheet, startRow + 15, 23, printData.ShokuinNm);

            // 合計金額 - パターン１(16)
            CellOutput(outputSheet, startRow + 13, 6, printData.PatternNo == "1" ? printData.Total.ToString("N0") : string.Empty);

            // 合計金額 - パターン2, パターン3(17)
            CellOutput(outputSheet, startRow + 15, 6, printData.PatternNo == "1" ? string.Empty : printData.Total.ToString("N0"));

            // 合計金額(18) - All Pattern(18)
            CellOutput(outputSheet, startRow + 20, 6, printData.Total.ToString("N0"));

            // 20141223 habu Mod 
            // ｛品名｝｛数量｝｛単位}(19)
            // 出力先様式に合わせて、省略形とする
            if (hinmeiSuryoTani.Length > 70)
            {
                hinmeiSuryoTani = hinmeiSuryoTani.Substring(0, (70 - 3)) + "・・・";
            }
            CellOutput(outputSheet, startRow + 16, 13, hinmeiSuryoTani);
            //CellOutput(outputSheet, startRow + 16, 13, hinmeiSuryoTani);

            // 口座名(20)
            CellOutput(outputSheet, startRow + 20, 16, printData.KozaNm);
        }
        #endregion

        #region PrintTypeB
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintTypeB
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printData"></param>
        /// <param name="shishoRow"></param>
        /// <param name="daihoshaNm"></param>
        /// <param name="startRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  AnhNV　　    新規作成
        /// 2014/12/19  kiyokuni　　 消費税対象外の場合は、消費税欄を出力しない、（株）が入っていたのを削除
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintTypeB
            (
                Worksheet outputSheet,
                SyusyuShoData printData,
                ShishoMstDataSet.ShishoMstRow shishoRow,
                string daihoshaNm,
                int startRow
            )
        {
            // 郵便番号(1)
            CellOutput(outputSheet, startRow + 2, 4, "'" + printData.ZipNo);

            // 住所(2)
            CellOutput(outputSheet, startRow + 3, 3, printData.Adr);

            // TEL(3)
            CellOutput(outputSheet, startRow + 5, 5, "'" + printData.Tel);

            // FAX(4)
            CellOutput(outputSheet, startRow + 5, 12, "'" + printData.Fax);

            // 業者（宛名）(5)
            CellOutput(outputSheet, startRow + 6, 3, printData.GyoshaNm);

            // 業者コード(6)
            CellOutput(outputSheet, startRow + 8, 7, "'" + printData.GyoshaCd);

            // 発行番号(7)
            CellOutput(outputSheet, startRow + 3, 31, "'" + printData.HakkoNo);

            // 発行日(8)
            CellOutput(outputSheet, startRow + 3, 20, printData.HakkoDt);

            // 合計金額(9)
            //CellOutput(outputSheet, startRow, 4, printData.ZipNo);

            // 事務局代表者名(10)
            CellOutput(outputSheet, startRow + 8, 23, daihoshaNm);

            // 支所郵便番号(11)
            CellOutput(outputSheet, startRow + 9, 20, "〒" + shishoRow.ShishoZipCd);

            // 支所住所(12)
            CellOutput(outputSheet, startRow + 10, 20, shishoRow.ShishoAdr);

            // 支所電話番号(13)
            CellOutput(outputSheet, startRow + 11, 20, "TEL." + shishoRow.ShishoTelNo);

            // 支所Fax番号(14)
            CellOutput(outputSheet, startRow + 11, 26, "FAX." + shishoRow.ShishoFaxNo);

            // 発行者(15)
            CellOutput(outputSheet, startRow + 3, 26, printData.ShokuinNm);

            // 5 detail rows
            int rowIdx = 1;
            foreach (YoshiHanbaiDtlTblDataSet.RyushushoPrintRow row in printData.PrintTable)
            {
                // 品番(16)
                CellOutput(outputSheet, startRow + 13 + rowIdx, 2, row.Hinban);
                
                // 品名(17)
                CellOutput(outputSheet, startRow + 14 + rowIdx, 2, row.HinNm);
                
                // 数量(18)
                CellOutput(outputSheet, startRow + 13 + rowIdx, 16, row.IsSuiRyoNull() ? string.Empty : row.SuiRyo.ToString());

                // 単位(19)
                CellOutput(outputSheet, startRow + 13 + rowIdx, 19, row.TaniNm);

                // 消費税区分(20)
                if (!row.IsKingakuNull())
                {
                    CellOutput(outputSheet, startRow + 13 + rowIdx, 21, GetShohizeiText(printData.ShohizeiKbn, row.ShouhizeiUmu));
                }

                // 単価(21)
                CellOutput(outputSheet, startRow + 13 + rowIdx, 22, row.IsTankaNull() ? string.Empty : row.Tanka.ToString("N0"));

                // 金額(22)
                CellOutput(outputSheet, startRow + 13 + rowIdx, 26, row.IsKingakuNull() ? string.Empty : row.Kingaku.ToString("N0"));

                // 備考(23)
                CellOutput(outputSheet, startRow + 13 + rowIdx, 30, row.Bikou);

                // Next row
                rowIdx += 2;
            }

            // 補足事項(24)
            CellOutput(outputSheet, startRow + 24, 2, printData.Hoshoku);

            // 消費税区分(25)
            CellOutput(outputSheet, startRow + 24, 23, printData.ShohizeiKbn == "1" ? "内" : (printData.ShohizeiKbn == "2" ? "外" : string.Empty));

            if (printData.ShohizeiKbn == "1" || printData.ShohizeiKbn == "2")
            {
                // 消費税額(26)
                CellOutput(outputSheet, startRow + 24, 24, printData.Shohizei.ToString("N0"));
            }
            // 合計金額(27)
            CellOutput(outputSheet, startRow + 24, 30, printData.Total.ToString("N0"));
        }
        #endregion

        #region GetShohizeiText
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetShohizeiText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shohizeiKbn">消費税区分</param>
        /// <param name="shohizei">消費税</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetShohizeiText(string shohizeiKbn, string shohizei)
        {
            string shohizeiText = string.Empty;

            switch (shohizeiKbn)
            {
                // 消費税区分/なし(15) is ON
                case "3":
                    shohizeiText = string.Empty;
                    break;
                // 消費税区分/内税(13) is ON
                case "1":
                    shohizeiText = shohizei == "1" ? "内" : "非";
                    break;
                // 消費税区分/外税(14) is ON
                case "2":
                    shohizeiText = shohizei == "1" ? "外" : "非";
                    break;
                default:
                    break;
            }

            return shohizeiText;
        }
        #endregion

        #region GetHinmeiSuryoTani
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetHinmeiSuryoTani
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetHinmeiSuryoTani(YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable table)
        {
            string res = string.Empty;
            string suiryo = string.Empty;

            foreach (YoshiHanbaiDtlTblDataSet.RyushushoPrintRow row in table)
            {
                suiryo = row.IsSuiRyoNull() ? string.Empty : row.SuiRyo.ToString();

                // Skip blank row(s)
                if (row.HinNm + suiryo + row.TaniNm == string.Empty) continue;

                // 品名(22) + 数量(23) + 単位(24)
                res += row.HinNm + suiryo + row.TaniNm + "・";
            }

            // Pop the last "." as result
            return res.Length > 1 ? res.Remove(res.Length - 1) : res;
        }
        #endregion

        #endregion
    }
    #endregion
}
