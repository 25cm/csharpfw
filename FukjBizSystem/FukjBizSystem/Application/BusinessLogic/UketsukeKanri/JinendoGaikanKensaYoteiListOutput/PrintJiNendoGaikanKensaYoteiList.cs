using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJiNendoGaikanKensaYoteiListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJiNendoGaikanKensaYoteiListBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable PrintTable { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        string Nendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJiNendoGaikanKensaYoteiListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJiNendoGaikanKensaYoteiListBLInput : BaseExcelPrintBLInputImpl, IPrintJiNendoGaikanKensaYoteiListBLInput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        public ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable PrintTable { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        public string Nendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJiNendoGaikanKensaYoteiListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJiNendoGaikanKensaYoteiListBLOutput : IBaseExcelPrintBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJiNendoGaikanKensaYoteiListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJiNendoGaikanKensaYoteiListBLOutput : IPrintJiNendoGaikanKensaYoteiListBLOutput
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
    //  クラス名 ： PrintJiNendoGaikanKensaYoteiListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJiNendoGaikanKensaYoteiListBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJiNendoGaikanKensaYoteiListBLInput, IPrintJiNendoGaikanKensaYoteiListBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintJiNendoGaikanKensaYoteiListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJiNendoGaikanKensaYoteiListBusinessLogic()
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
        /// 2014/11/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJiNendoGaikanKensaYoteiListBLOutput SetBook(IPrintJiNendoGaikanKensaYoteiListBLInput input, Excel.Workbook book)
        {
            IPrintJiNendoGaikanKensaYoteiListBLOutput output = new PrintJiNendoGaikanKensaYoteiListBLOutput();

            Excel.Application application = null;
            Excel.Worksheet outputSheet = null;
            Excel.Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Template sheet
                tempSheet = (Excel.Worksheet)book.Sheets["Sheet1"];
                // Each gyoshaCd place in 1 sheet
                string tempGyoshaCd = "GyoshaCd";
                // Start detail row
                int curRow = 3;
                // 年度
                string nendo = Utility.DateUtility.ConvertToWareki(input.Nendo, "gyy年度", Utility.DateUtility.GengoKbn.Wareki);
                int rowNumber = 31;

                foreach (ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuRow row in input.PrintTable.Select(string.Empty, "GyoshaCd ASC"))
                {
                    // New GyoshaCd or full row in sheet
                    //20141208_HuyTX_MOD
                    //if (tempGyoshaCd != row.GyoshaCd || curRow == 33) // 30 detail row + 3 header row
                    if (tempGyoshaCd != row.GyoshaCd)
                    //ENd
                    {
                        //20141208 HuyTX set print area
                        if (curRow != 3)
                        {
                            outputSheet.PageSetup.PrintArea = string.Format("A1:N{0}", rowNumber + 2);
                        }
                        //End

                        // Copy a new sheet
                        tempSheet.Copy(tempSheet, Type.Missing);

                        // Set output sheet to current active sheet
                        outputSheet = (Excel.Worksheet)book.ActiveSheet;
                        outputSheet.Name = string.Concat("次年度外観検査依頼一覧表_", row.GyoshaCd);

                        // Get 年度
                        //nendo = row.ZenkaiKensaDt.Length > 4 ? row.ZenkaiKensaDt.Substring(0, 4) : string.Empty;
                        //nendo = Utility.DateUtility.ConvertToWareki(nendo, "gyy年度", Utility.DateUtility.GengoKbn.Wareki);

                        // Header
                        SetHeader(outputSheet, row.GyoshaCd, row.GyoshaNm, nendo);

                        // Starting from row 1
                        curRow = 3;
                        rowNumber = 31;
                    }

                    //20141208_HuyTX output data to next page
                    if (curRow >= 33)
                    {
                        if ((rowNumber - 1) % 30 == 0)
                        {
                            // 改ページを追加
                            outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[curRow + 1, 1]);    // RowBase "1"
                            // 印刷範囲を拡張する
                            outputSheet.PageSetup.PrintArea = string.Format("A1:N{0}", curRow + 30);    // RowBase "1"
                            // 次ページ分の枠を30行分コピーする
                            CopyRow(outputSheet, 3, 30, curRow);    // RowBase "0"
                            // 次ページ分の内容をクリアする
                            outputSheet.Range[outputSheet.Cells[curRow+1, 1], outputSheet.Cells[curRow + 30, 14]].Value = String.Empty;    // RowBase "1"
                            // 行番号を書き込む
                            for (int rnCnt = 0; rnCnt < 30; rnCnt++)
                            {
                                CellOutput(outputSheet, curRow + rnCnt, 1, rowNumber + rnCnt);    // RowBase "0"
                            }
                        }
                        //CopyRow(outputSheet, 32, 1, curRow);
                        //CellOutput(outputSheet, curRow, 1, rowNumber++);
                        rowNumber++;
                    }
                    //End

                    // Detail sheet
                    SetDetail(outputSheet, row, curRow);

                    // Next row
                    curRow++;
                    tempGyoshaCd = row.GyoshaCd;
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
        /// <param name="sheet"></param>
        /// <param name="gyoshaCd"></param>
        /// <param name="gyoshaNm"></param>
        /// <param name="nendo"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  AnhNV　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader(Excel.Worksheet sheet, string gyoshaCd, string gyoshaNm, string nendo)
        {
            // 業者名(1)
            CellOutput(sheet, 1, 1, gyoshaNm);
            // 業者コード(2)
            CellOutput(sheet, 1, 4, gyoshaCd);
            // 年度(3)
            CellOutput(sheet, 1, 12, nendo);
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  AnhNV　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Excel.Worksheet sheet, ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuRow row, int curRow)
        {
            // 市町村(5)
            CellOutput(sheet, curRow, 2, row.ShichosonNm);
            // 設置者名(6)
            CellOutput(sheet, curRow, 3, row.SetchishaNm);
            // 設置住所(7)
            CellOutput(sheet, curRow, 4, row.SetchishaAdr);
            // 人槽(8)
            CellOutput(sheet, curRow, 5, row.Ninso);
            // 処理方式(9)
            CellOutput(sheet, curRow, 6, row.ConstNm);
            // 前回検査日(10)
            string zenkaiDt = Utility.DateUtility.ConvertToWareki(row.ZenkaiKensaDt, "yy.MM.dd");
            CellOutput(sheet, curRow, 7, zenkaiDt);
            // 検査区分(11)
            CellOutput(sheet, curRow, 8, row.kensaKbnCol);
            // 空白(12)
            //CellOutput(sheet, 1, 1, string.Empty);
            // 空白(13)
            //CellOutput(sheet, 1, 1, string.Empty);
            // 設置者区分+設置者コード(14)
            CellOutput(sheet, curRow, 11, string.Concat(row.SetchishaKbn, "-", row.SetchishaCd));
            // 浄化槽番号(15)
            CellOutput(sheet, curRow, 12, "'" + row.jokasoCdCol);
        }
        #endregion

        #endregion
    }
    #endregion
}
