using System;
using System.Reflection;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.Boundary.SuishitsuKensaKanri;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoTorikomi
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYachoExcelDataBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYachoExcelDataBLInput
    {
        /// <summary>
        /// ExcelPath
        /// </summary>
        string ExcelPath { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYachoExcelDataBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYachoExcelDataBLInput : IGetYachoExcelDataBLInput
    {
        /// <summary>
        /// ExcelPath
        /// </summary>
        public string ExcelPath { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYachoExcelDataBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYachoExcelDataBLOutput
    {
        /// <summary>
        /// YachoTorikomiDataTable
        /// </summary>
        YachoDataSet.YachoTorikomiDataTable YachoTorikomiDataTable { get; set; }

        /// <summary>
        /// ErrorCode
        /// 1: Column mismatch
        /// 2: Numeric check
        /// </summary>
        int ErrorCode { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        string ErrorMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYachoExcelDataBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYachoExcelDataBLOutput : IGetYachoExcelDataBLOutput
    {
        /// <summary>
        /// YachoTorikomiDataTable
        /// </summary>
        public YachoDataSet.YachoTorikomiDataTable YachoTorikomiDataTable { get; set; }

        /// <summary>
        /// ErrorCode
        /// 1: Column mismatch
        /// 2: Numeric check
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYachoExcelDataBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYachoExcelDataBusinessLogic : BaseBusinessLogic<IGetYachoExcelDataBLInput, IGetYachoExcelDataBLOutput>
    {
        #region ImportFormat



        #endregion

        IGetYachoExcelDataBLOutput output;

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYachoExcelDataBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYachoExcelDataBusinessLogic()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2014/12/20　小松  　　　結果コード、判定、NULLチェックなど色々修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYachoExcelDataBLOutput Execute(IGetYachoExcelDataBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            output = new GetYachoExcelDataBLOutput();

            output.ErrorCode = 0;

            // Ｅｘｃｅｌのアプリケーションオブジェクトを定義
            Microsoft.Office.Interop.Excel.Application excel = null;
            // Ｅｘｃｅｌのブックオブジェクトを定義
            Microsoft.Office.Interop.Excel.Workbook book = null;
            // Ｅｘｃｅｌのシートオブジェクトを定義
            Worksheet sheet = null;

            try
            {

                // Ｅｘｃｅｌのアプリケーションオブジェクトを作成
                excel = new Microsoft.Office.Interop.Excel.Application();

                // 非表示状態に設定
                excel.Visible = false;

                // Ｅｘｃｅｌを開いてブックオブジェクトを取得
                book = excel.Workbooks.Open(
                    input.ExcelPath,
                    Type.Missing,
                    true,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing);

                // 再度非表示状態に設定
                excel.Visible = false;

                //継続申込シート
                sheet = (Worksheet)book.Sheets[1];

                //継続申込シートの情報を取得
                output.YachoTorikomiDataTable = new YachoDataSet.YachoTorikomiDataTable();

                if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_001))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 5, 2, 2, Utility.Constants.YachoConstant.YACHO_001));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_002))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 5, 2, 1, Utility.Constants.YachoConstant.YACHO_002));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_003))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 5, 2, 1, Utility.Constants.YachoConstant.YACHO_003));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_004))
                {
                    // Check which sheet have data
                    Range range = (Range)sheet.Cells[29, 8];

                    if (range.Value == null || string.IsNullOrEmpty(range.Value.ToString().Trim()))
                    {
                        sheet = (Worksheet)book.Sheets[2];
                    }

                    range = (Range)sheet.Cells[29, 8];

                    if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                    {
                        output.YachoTorikomiDataTable = (SetSheet(sheet, 29, 1, 3, Utility.Constants.YachoConstant.YACHO_004));
                    }
                    else
                        output.YachoTorikomiDataTable = new YachoDataSet.YachoTorikomiDataTable();
                }
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_005))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 29, 1, 3, Utility.Constants.YachoConstant.YACHO_005));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_006))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 25, 1, 5, Utility.Constants.YachoConstant.YACHO_006));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_007))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 5, 2, 3, Utility.Constants.YachoConstant.YACHO_007));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_008))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 29, 1, 2, Utility.Constants.YachoConstant.YACHO_008));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_009))
                {
                    // Check which sheet have data
                    Range range = (Range)sheet.Cells[29, 8];

                    if (range.Value == null || string.IsNullOrEmpty(range.Value.ToString()))
                    {
                        sheet = (Worksheet)book.Sheets[2];
                    }

                    range = (Range)sheet.Cells[29, 8];

                    if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                    {
                        output.YachoTorikomiDataTable = (SetSheet(sheet, 29, 1, 2, Utility.Constants.YachoConstant.YACHO_009));
                    }
                    else
                        output.YachoTorikomiDataTable = new YachoDataSet.YachoTorikomiDataTable();
                }
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_010))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 12, 2, 5, Utility.Constants.YachoConstant.YACHO_010));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_011))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 30, 1, 3, Utility.Constants.YachoConstant.YACHO_011));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_012))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 5, 2, 1, Utility.Constants.YachoConstant.YACHO_012));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_013))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 5, 2, 1, Utility.Constants.YachoConstant.YACHO_013));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_014))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 29, 1, 2, Utility.Constants.YachoConstant.YACHO_014));
                else if (input.ExcelPath.Contains(Utility.Constants.YachoConstant.YACHO_015))
                    output.YachoTorikomiDataTable = (SetSheet(sheet, 29, 1, 2, Utility.Constants.YachoConstant.YACHO_015));

            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());

                //ExcelApplicationを終了させる             
                if (excel != null)
                {
                    if (book != null)
                    {
                        if (sheet != null)
                        {
                            Marshal.ReleaseComObject(sheet);
                        }
                        book.Close(false, false, Type.Missing);
                        Marshal.ReleaseComObject(book);
                    }
                    excel.DisplayAlerts = false;
                    excel.Quit();
                    Marshal.ReleaseComObject(excel);
                }

                GC.Collect();

            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region NamedCellOutput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： NamedCellOutput
        /// <summary>
        /// ＥＸＣＥＬのブックオブジェクトのセルにデータを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="book">Excelブックオブジェクト</param>
        /// <param name="name">セル名</param>
        /// <param name="value">セルにセットする値</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/26　紀野　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private Range NamedCellOutput(Worksheet sheet, string name, object value)
        {
            try
            {
                Name namedCell = sheet.Names.Item(name, Type.Missing, Type.Missing);
                namedCell.RefersToRange.Value2 = value;
                return (Range)namedCell.RefersToRange;
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

        }
        #endregion

        #region NamedCellReplace
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： NamedCellReplace
        /// <summary>
        /// ＥＸＣＥＬのブックオブジェクトのセルの内容を置換するにデータを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="book">Excelブックオブジェクト</param>
        /// <param name="name">セル名</param>
        /// <param name="from">置換元文字列</param>
        /// <param name="to">置換後文字列</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/26　紀野　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NamedCellReplace(Worksheet sheet, string name, string from, string to)
        {
            try
            {
                Name namedCell = sheet.Names.Item(sheet.Name + "!" + name, Type.Missing, Type.Missing);
                namedCell.RefersToRange.Replace(from, to, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region CellReplaceAll
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CellReplaceAll
        /// <summary>
        /// シートの全セルを対象に内容の置換を行う
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="book">Excelブックオブジェクト</param>
        /// <param name="replaceFrom">置換元文字列</param>
        /// <param name="replaceTo">置換後文字列</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/26　紀野　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CellReplaceAll(Worksheet sheet, string replaceFrom, string replaceTo)
        {
            Range rangeAll = sheet.get_Range(sheet.Cells[0, 0], sheet.Cells[sheet.Rows.Count, sheet.Columns.Count]);
            rangeAll.Replace(replaceFrom, replaceTo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
        #endregion

        #region RecordRead

        #region RecordRead_001
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_001
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataTbl">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_001(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {
            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                // 水質検査依頼番号
                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                range = (Range)sheet.Cells[row, col + 2];
                string kekkaValueStr = string.Empty;
                decimal kekkaValue;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                //１レコード出力
                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_002
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_002
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// （NO2-N（亜硝酸性窒素）（定性））
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataTbl">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_002(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {
                #region Left side

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                dataRow.KekkaValue = 0;

                // 範囲
                dataRow.Hani = "0";

                // 結果コード
                dataRow.KekkaCd = string.Empty;
                range = (Range)sheet.Cells[row, col + 1];
                if (range.Value != null)
                {
                    // 20150108 結果コードのパディングを行う
                    dataRow.KekkaCd = range.Value.ToString().Trim().PadLeft(3, '0');
                }

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);

                #endregion

                #region Right side

                // 右側は値がセットされている時のみ取込
                range = (Range)sheet.Cells[row, col + 4];
                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    dataRow = dataTbl.NewYachoTorikomiRow();

                    // 水質検査依頼番号
                    range = (Range)sheet.Cells[row, col + 3];
                    if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                    {
                        if (!IsNumeric(range.Value.ToString()))
                        {
                            output.ErrorCode = 2;
                            output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                        }
                        dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                    }
                    else
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }

                    // 測定値
                    dataRow.KekkaValue = 0;

                    // 範囲
                    dataRow.Hani = "0";

                    // 結果コード
                    dataRow.KekkaCd = string.Empty;
                    range = (Range)sheet.Cells[row, col + 4];
                    if (range.Value != null)
                    {
                        // 20150110 sou Start 結果コードのパディングを行う
                        //dataRow.KekkaCd = range.Value.ToString().Trim();
                        dataRow.KekkaCd = range.Value.ToString().Trim().PadLeft(3, '0');
                        // 20150110 sou End
                    }

                    // 温度
                    dataRow.Ondo = 0;

                    dataTbl.Rows.Add(dataRow);
                }

                #endregion
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_003
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_003
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// （ NO3-N（硝酸性窒素）（定性））
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_003(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                #region Left side

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                dataRow.KekkaValue = 0;

                // 範囲
                dataRow.Hani = "0";

                // 結果コード
                dataRow.KekkaCd = string.Empty;
                range = (Range)sheet.Cells[row, col + 1];
                if (range.Value != null)
                {
                    // 20150108 結果コードのパディングを行う
                    dataRow.KekkaCd = range.Value.ToString().Trim().PadLeft(3, '0');
                }

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);

                #endregion

                #region Right side

                // 右側は値がセットされている時のみ取込
                range = (Range)sheet.Cells[row, col + 4];
                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    dataRow = dataTbl.NewYachoTorikomiRow();

                    // 水質検査依頼番号
                    range = (Range)sheet.Cells[row, col + 3];
                    if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                    {
                        if (!IsNumeric(range.Value.ToString()))
                        {
                            output.ErrorCode = 2;
                            output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                        }
                        dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                    }
                    else
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }

                    // 測定値

                    dataRow.KekkaValue = 0;

                    // 範囲
                    dataRow.Hani = "0";

                    // 結果コード
                    dataRow.KekkaCd = string.Empty;
                    range = (Range)sheet.Cells[row, col + 4];
                    if (range.Value != null)
                    {
                        // 20150110 sou Start 結果コードのパディングを行う
                        //dataRow.KekkaCd = range.Value.ToString().Trim();
                        dataRow.KekkaCd = range.Value.ToString().Trim().PadLeft(3, '0');
                        // 20150110 sou End
                    }

                    // 温度
                    dataRow.Ondo = 0;

                    dataTbl.Rows.Add(dataRow);
                }

                #endregion
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_004
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_004
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_004(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                int rowChecked = 0;

                for (int i = 0; i < 3; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 10];
                    if (range.Value != null && range.Value.ToString().Equals("R"))
                        rowChecked = i;
                }

                range = (Range)sheet.Cells[row + rowChecked, col + 7];

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_005
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_005
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_005(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                int rowChecked = 0;

                for (int i = 0; i < 3; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 12];
                    if (range.Value != null && range.Value.ToString().Equals("R"))
                        rowChecked = i;
                }

                range = (Range)sheet.Cells[row + rowChecked, col + 9];

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_006
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_006
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_006(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {
                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                range = (Range)sheet.Cells[row + 1, col + 3];
                string kekkaValueStr = string.Empty;
                decimal kekkaValue;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_007
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_007
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_007(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {
                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                range = (Range)sheet.Cells[row, col + 9];
                string kekkaValueStr = string.Empty;
                decimal kekkaValue;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_008
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_008
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_008(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                int rowChecked = 0;

                for (int i = 0; i < 2; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 10];
                    if (range.Value != null && range.Value.ToString().Equals("R"))
                        rowChecked = i;
                }

                range = (Range)sheet.Cells[row + rowChecked, col + 7];

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_009
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_009
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_009(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                int rowChecked = 0;

                for (int i = 0; i < 2; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 10];
                    if (range.Value != null && range.Value.ToString().Equals("R"))
                        rowChecked = i;
                }

                range = (Range)sheet.Cells[row + rowChecked, col + 7];

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_010
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_010
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// （ヘキサン抽出物質）
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2014/12/25  小松　　　　検体番号の取得位置を正しい位置から取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_010(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                dataRow.SuishitsuKensaIraiNo = string.Empty;
                //for (int i = 0; i < 5; i++)
                for (int i = 0; i < 1; i++)
                {
                    range = (Range)sheet.Cells[row + i, col];
                    if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                    {
                        if (!IsNumeric(range.Value.ToString()))
                        {
                            output.ErrorCode = 2;
                            output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                            break;
                        }
                        dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                    }
                }

                if (string.IsNullOrEmpty(dataRow.SuishitsuKensaIraiNo))
                {
                    return;
                }

                if (string.IsNullOrEmpty(dataRow.SuishitsuKensaIraiNo.ToString()))
                    return;

                // 測定値

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                for (int i = 0; i < 5; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 10];
                    if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                    {
                        kekkaValueStr = range.Value.ToString().Trim();
                        break;
                    }
                }

                if (string.IsNullOrEmpty(kekkaValueStr))
                    kekkaValue = 0;
                else
                {
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (string.IsNullOrEmpty(kekkaValueStr))
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_011
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_011
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_011(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                int rowChecked = 0;

                for (int i = 0; i < 3; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 10];
                    if (range.Value != null && range.Value.ToString().Equals("R"))
                        rowChecked = i;
                }

                range = (Range)sheet.Cells[row + rowChecked, col + 7];

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲
                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_012
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_012
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// （外観）
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_012(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {
                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                dataRow.KekkaValue = 0;

                // 範囲
                dataRow.Hani = "0";

                // 結果コード
                dataRow.KekkaCd = string.Empty;
                range = (Range)sheet.Cells[row, col + 1];
                if (range.Value != null)
                {
                    // 20150108 結果コードのパディングを行う
                    dataRow.KekkaCd = range.Value.ToString().Trim().PadLeft(3, '0');
                }

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_013
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_013
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// （臭気）
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_013(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {
                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                dataRow.KekkaValue = 0;

                // 範囲
                dataRow.Hani = "0";

                // 結果コード
                dataRow.KekkaCd = string.Empty;
                range = (Range)sheet.Cells[row, col + 1];
                if (range.Value != null)
                {
                    // 20150108 結果コードのパディングを行う
                    dataRow.KekkaCd = range.Value.ToString().Trim().PadLeft(3, '0');
                }

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_014
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_014
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_014(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                int rowChecked = 0;

                for (int i = 0; i < 2; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 10];
                    if (range.Value != null && range.Value.ToString().Equals("R"))
                        rowChecked = i;
                }

                range = (Range)sheet.Cells[row + rowChecked, col + 7];

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲

                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #region RecordRead_015
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RecordRead_015
        /// <summary>
        /// Excelに請求情報１レコードを出力する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">出力対象シート</param>
        /// <param name="row">Excelの行</param>
        /// <param name="col">Excelの列</param>
        /// <param name="dataRow">出力データ１レコード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RecordRead_015(Worksheet sheet, int row, int col, YachoDataSet.YachoTorikomiDataTable dataTbl)
        {

            YachoDataSet.YachoTorikomiRow dataRow = dataTbl.NewYachoTorikomiRow();

            //Ｅｘｃｅｌの行のinsertは呼び出し元でやっている
            Range range = null;

            try
            {

                // 水質検査依頼番号
                range = (Range)sheet.Cells[row, col];

                if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                {
                    if (!IsNumeric(range.Value.ToString()))
                    {
                        output.ErrorCode = 2;
                        output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                    }
                    dataRow.SuishitsuKensaIraiNo = range.Value.ToString().PadLeft(6, '0');
                }
                else
                {
                    output.ErrorCode = 2;
                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", row.ToString(), "1");
                }

                // 測定値
                int rowChecked = 0;

                for (int i = 0; i < 2; i++)
                {
                    range = (Range)sheet.Cells[row + i, col + 7];
                    if (range.Value != null && range.Value.ToString().Equals("R"))
                        rowChecked = i;
                }

                range = (Range)sheet.Cells[row + rowChecked, col + 5];

                decimal kekkaValue;
                string kekkaValueStr = string.Empty;

                if (range.Value == null)
                    kekkaValue = 0;
                else
                {
                    kekkaValueStr = range.Value.ToString().Trim();
                    if (!Decimal.TryParse(range.Value.ToString().Replace("以下", "").Replace("未満", "").Trim(), out kekkaValue))
                    {
                        kekkaValue = 0;
                    }
                }

                dataRow.KekkaValue = kekkaValue;

                // 範囲

                if (range.Value == null)
                    dataRow.Hani = "0";
                else
                {
                    if (kekkaValueStr.EndsWith("以下"))
                        dataRow.Hani = "2";
                    else if (kekkaValueStr.EndsWith("未満"))
                        dataRow.Hani = "3";
                    else
                        dataRow.Hani = "0";
                }

                // 結果コード
                dataRow.KekkaCd = string.Empty;

                // 温度
                dataRow.Ondo = 0;

                dataTbl.Rows.Add(dataRow);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ReleaseComObject(range);
            }
        }
        #endregion

        #endregion

        #region SetSheet
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetSheet
        /// <summary>
        /// ＥＸＣＥＬのブックオブジェクトにデータを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="rowStart"></param>
        /// <param name="colStart"></param>
        /// <param name="rowInc"></param>
        /// <param name="importFormat"></param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YachoDataSet.YachoTorikomiDataTable SetSheet(Microsoft.Office.Interop.Excel.Worksheet sheet, int rowStart, int colStart, int rowInc, string importFormat)
        {
            Range range = null;
            try
            {
                sheet.Name = EscapeExcelSheetName(sheet.Name);

                YachoDataSet.YachoTorikomiDataTable dataTbl = new YachoDataSet.YachoTorikomiDataTable();

                int rowIdx = 0;

                //明細の出力
                for (int i = 0; i < sheet.UsedRange.Rows.Count; i++)
                {
                    range = (Range)sheet.Cells[rowStart + rowIdx, colStart];
                    if (!importFormat.Equals(Utility.Constants.YachoConstant.YACHO_010) && !importFormat.Equals(Utility.Constants.YachoConstant.YACHO_015))
                    {
                        if (range.Value == null || string.IsNullOrEmpty(range.Value.ToString().Trim()))
                        {
                            break;
                        }
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_015))
                    {
                        int suishitsuKensaIraiNo;
                        if (range.Value == null || (range.Value != null && !int.TryParse(range.Value.ToString(), out suishitsuKensaIraiNo)))
                        {
                            break;
                        }
                    }

                    if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_001))
                    {
                        RecordRead_001(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_002))
                    {
                        RecordRead_002(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_003))
                    {
                        RecordRead_003(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_004))
                    {
                        RecordRead_004(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_005))
                    {
                        RecordRead_005(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_006))
                    {
                        RecordRead_006(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_007))
                    {
                        RecordRead_007(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_008))
                    {
                        RecordRead_008(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_009))
                    {
                        RecordRead_009(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_010))
                    {
                        RecordRead_010(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_011))
                    {
                        RecordRead_011(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_012))
                    {
                        RecordRead_012(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_013))
                    {
                        RecordRead_013(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_014))
                    {
                        RecordRead_014(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }
                    else if (importFormat.Equals(Utility.Constants.YachoConstant.YACHO_015))
                    {
                        RecordRead_015(sheet, rowStart + rowIdx, colStart, dataTbl);
                    }

                    if (output.ErrorCode != 0)
                        break;

                    rowIdx += rowInc;
                }

                return dataTbl;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (range != null)
                {
                    Marshal.ReleaseComObject(range);
                }
            }

        }
        #endregion

        #region EscapeExcelSheetName
        /// <summary>
        /// エクセルのシート名をエスケープする
        /// </summary>
        /// <param name="originalName"></param>
        /// <returns></returns>
        private string EscapeExcelSheetName(string originalName)
        {
            originalName = originalName.Replace(":", string.Empty);
            originalName = originalName.Replace("*", string.Empty);
            originalName = originalName.Replace("?", string.Empty);
            originalName = originalName.Replace("[", string.Empty);
            originalName = originalName.Replace("]", string.Empty);
            originalName = originalName.Replace("/", string.Empty);
            originalName = originalName.Replace("\\", string.Empty);

            if (originalName.Length > 31)
            {
                originalName = originalName.Substring(0, 31);
            }

            return originalName;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CheckNumeric
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckNumeric
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsNumeric(string str)
        {
            decimal retVal = 0;
            if (decimal.TryParse(str, out retVal))
                return true;
            else
                return false;
        }
        #endregion

        #endregion
    }
    #endregion
}
