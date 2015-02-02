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
    //  インターフェイス名 ： IGetYachoCsvDataBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYachoCsvDataBLInput
    {
        /// <summary>
        /// CsvFilePath
        /// </summary>
        string CsvFilePath { get; set; }
        /// <summary>
        /// 水質試験項目コード
        /// </summary>
        string KoumokuCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYachoCsvDataBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYachoCsvDataBLInput : IGetYachoCsvDataBLInput
    {
        /// <summary>
        /// CsvFilePath
        /// </summary>
        public string CsvFilePath { get; set; }
        /// <summary>
        /// 水質試験項目コード
        /// </summary>
        public string KoumokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYachoCsvDataBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYachoCsvDataBLOutput
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
    //  クラス名 ： GetYachoCsvDataBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYachoCsvDataBLOutput : IGetYachoCsvDataBLOutput
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
    //  クラス名 ： GetYachoCsvDataBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYachoCsvDataBusinessLogic : BaseBusinessLogic<IGetYachoCsvDataBLInput, IGetYachoCsvDataBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYachoCsvDataBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYachoCsvDataBusinessLogic()
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
        /// 2014/12/08　HieuNH　　　新規作成
        /// 2014/12/20　小松  　　　温度有用と無用の読み込みを切替えるように修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYachoCsvDataBLOutput Execute(IGetYachoCsvDataBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // pH用（温度あり）取込
            bool ondoFlg = false;
            // 試験項目コード(pH)
            string shikenCdPH = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
            if (shikenCdPH == input.KoumokuCd)
            {
                // pHの取込
                ondoFlg = true;
            }

            // Ｅｘｃｅｌのアプリケーションオブジェクトを定義
            Microsoft.Office.Interop.Excel.Application excel = null;
            // Ｅｘｃｅｌのブックオブジェクトを定義
            Microsoft.Office.Interop.Excel.Workbooks books = null;
            // Ｅｘｃｅｌのシートオブジェクトを定義
            Worksheet sheet = null;

            // 出力クラスの実体作成
            IGetYachoCsvDataBLOutput output = new GetYachoCsvDataBLOutput();

            output.ErrorCode = 0;

            try
            {
                // Ｅｘｃｅｌのアプリケーションオブジェクトを作成
                excel = new Microsoft.Office.Interop.Excel.Application();

                books = excel.Workbooks;

                // 非表示状態に設定
                excel.Visible = false;

                // Ｅｘｃｅｌを開いてブックオブジェクトを取得
                books.OpenText(
                    input.CsvFilePath,
                    Type.Missing,
                    2,
                    XlTextParsingType.xlDelimited,
                    XlTextQualifier.xlTextQualifierDoubleQuote,
                    Type.Missing,
                    Type.Missing,
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
                    Type.Missing);


                // 再度非表示状態に設定
                excel.Visible = false;

                //継続申込シート
                sheet = (Worksheet)books[1].Worksheets.get_Item(1);

                YachoDataSet.YachoTorikomiDataTable dataTbl = new YachoDataSet.YachoTorikomiDataTable();

                // ３列以上
                if (sheet.UsedRange.Columns.Count >= 3)
                {

                    // 明細の出力
                    // 1行目はヘッダ見出し
                    for (int i = 2; i <= sheet.UsedRange.Rows.Count; i++)
                    {
                        YachoDataSet.YachoTorikomiRow row = dataTbl.NewYachoTorikomiRow();
                        row.SuishitsuKensaIraiNo = string.Empty;
                        row.KekkaValue = 0;
                        row.Hani = "0";
                        row.KekkaCd = string.Empty;
                        row.Ondo = 0;

                        // 水質検査依頼番号
                        Range range = (Range)sheet.Cells[i, 1];

                        if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                        {
                            if (!IsNumeric(range.Value.ToString()))
                            {
                                output.ErrorCode = 2;
                                output.ErrorMessage = string.Format(@"取込データの型が不正です。行番号：{0}　カラム名：{1}", (i + 1).ToString(), 1);
                                break;
                            }
                            row.SuishitsuKensaIraiNo = range.Value.ToString().Trim().PadLeft(6, '0');
                        }
                        else
                        {
                            output.ErrorCode = 1;
                            break;
                        }

                        // 測定値
                        range = (Range)sheet.Cells[i, 2];

                        if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                        {
                            if (!IsNumeric(range.Value.ToString()))
                            {
                                output.ErrorCode = 2;
                                output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", (i + 1).ToString(), 2);
                                break;
                            }
                            decimal kekkaValue = 0;

                            if (range.Value != null)
                            {
                                if (!Decimal.TryParse(range.Value.ToString(), out kekkaValue))
                                    kekkaValue = 0;
                            }
                            row.KekkaValue = kekkaValue;
                        }
                        else
                        {
                            output.ErrorCode = 1;
                            break;
                        }

                        if (!ondoFlg)
                        {
                            // 範囲（区分）
                            range = (Range)sheet.Cells[i, 3];

                            if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                            {
                                if (!IsNumeric(range.Value.ToString()))
                                {
                                    output.ErrorCode = 2;
                                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", (i + 1).ToString(), 3);
                                    break;
                                }
                                row.Hani = range.Value.ToString().Trim();

                                // CSVファイルの区分から、新システムでの範囲区分(027)に変換
                                if (row.Hani == "1")
                                {
                                    // 以下：1->2
                                    row.Hani = "2";
                                }
                                else if (row.Hani == "2")
                                {
                                    // 未満：2->3
                                    row.Hani = "3";
                                }
                            }
                            else
                            {
                                // この項目は未指定の場合もあり
                                //output.ErrorCode = 1;
                                //break;
                            }
                        }
                        else
                        {
                            // 温度
                            range = (Range)sheet.Cells[i, 3];

                            if (range.Value != null && !string.IsNullOrEmpty(range.Value.ToString()))
                            {
                                if (!IsNumeric(range.Value.ToString()))
                                {
                                    output.ErrorCode = 2;
                                    output.ErrorMessage = string.Format("取込データの型が不正です。行番号：{0}　カラム名：{1}", (i + 1).ToString(), 4);
                                    break;
                                }
                                decimal ondo = 0;

                                if (range.Value != null)
                                {
                                    if (!Decimal.TryParse(range.Value.ToString(), out ondo))
                                        ondo = 0;
                                }

                                row.Ondo = ondo;
                            }
                            else
                            {
                                // この項目は未指定の場合もあり
                                //output.ErrorCode = 1;
                                //break;
                            }
                        }

                        dataTbl.AddYachoTorikomiRow(row);
                    }

                    output.YachoTorikomiDataTable = dataTbl;
                }
                else
                {
                    output.ErrorCode = 1;
                }
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
                    if (books != null)
                    {
                        if (sheet != null)
                        {
                            Marshal.ReleaseComObject(sheet);
                        }
                        books.get_Item(1).Close(false, false, Type.Missing);
                        Marshal.ReleaseComObject(books);
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
