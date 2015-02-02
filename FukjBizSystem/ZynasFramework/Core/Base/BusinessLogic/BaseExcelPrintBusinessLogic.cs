using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Base.BusinessLogic
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IBasePrintBLInput
    /// <summary>
    /// 帳票ベースビジネスロジックの入力インターフェイス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/07/13　稗田　　    新規作成
    /// 2010/10/18　垣迫　　    TeraJobWatcher機能追加のため修正
    /// 2010/11/29　稗田　　    修正(FAX送信改善)
    /// 2014/08/18　土生　　    印刷処理パラメータを追加
    /// 2014/10/27　土生　　    印刷部数パラメータを追加
    /// 2014/10/27　土生　　    PDF出力を追加
    /// 2014/12/11  豊田        Excelの終了制御を修正、Copyメソッドの呼び出し後にクリップボードをクリアするよう修正
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 保存ファイルモード(0:xls/xlsx,1:PDF)
        /// </summary>
        int SaveFileMode { get; set; }

        /// <summary>
        /// ＥＸＣＥＬ書式へのパス
        /// </summary>
        string FormatPath { get; set; }

        /// <summary>
        /// 帳票ディレクトリパス
        /// </summary>
        string PrintDirectory { get; set; }

        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        string SavePath { get; set; }

        /// <summary>
        /// 処理後ＥＸＣＥＬ表示フラグ
        /// </summary>
        bool AfterDispFlg { get; set; }

        /// <summary>
        /// 処理後印刷フラグ
        /// </summary>
        bool AfterPrintFlg { get; set; }

        /// <summary>
        /// 印刷プリンタ名
        /// </summary>
        string PrinterName { get; set; }

        /// <summary>
        /// 印刷部数
        /// </summary>
        int CopyCount { get; set; }

        /// <summary>
        /// 印刷単位(true:部単位,false:ページ単位)
        /// </summary>
        bool Collate { get; set; }
    }
    #endregion

    #region BaseExcelPrintBLInputImpl
    /// <summary>
    /// IBaseExcelPrintBLInputの規定の実装クラス
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　土生　　    BLInputの規定実装を追加
    /// </history>
    public class BaseExcelPrintBLInputImpl
    {
        /// <summary>
        /// 保存ファイルモード(0:xls/xlsx,1:PDF)
        /// </summary>
        public int SaveFileMode { get; set; }

        /// <summary>
        /// ＥＸＣＥＬ書式へのパス
        /// </summary>
        public string FormatPath { get; set; }

        /// <summary>
        /// 帳票ディレクトリパス
        /// </summary>
        public string PrintDirectory { get; set; }

        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// 処理後ＥＸＣＥＬ表示フラグ
        /// </summary>
        public bool AfterDispFlg { get; set; }

        /// <summary>
        /// 処理後印刷フラグ
        /// </summary>
        public bool AfterPrintFlg { get; set; }

        /// <summary>
        /// 印刷プリンタ名
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// 印刷部数
        /// </summary>
        public int CopyCount { get; set; }

        /// <summary>
        /// 印刷単位(true:部単位,false:ページ単位)
        /// </summary>
        public bool Collate { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectOfficeListByTantouBLOutput
    /// <summary>
    /// 帳票ベースビジネスロジックの出力インターフェイス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/07/13　稗田　　    新規作成
    /// 2010/10/18　垣迫　　    TeraJobWatcher機能追加のため修正
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface IBaseExcelPrintBLOutput
    {
        /// <summary>
        /// 保存パス
        /// </summary>
        string SavePath { get; set; }
    }
    #endregion

    #region BaseExcelPrintBLOutputImpl
    /// <summary>
    /// IBaseExcelPrintBLOutputの規定の実装クラス
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　土生　　    BLOutputの規定実装を追加
    /// </history>
    public class BaseExcelPrintBLOutputImpl
    {
        /// <summary>
        /// 保存パス
        /// </summary>
        public string SavePath { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BasePrintBusinessLogic
    /// <summary>
    /// 帳票ベースビジネスロジッククラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/07/13　稗田　　    新規作成
    /// 2010/10/18　垣迫　　    TeraJobWatcher機能追加のため修正
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public abstract class BaseExcelPrintBusinessLogic<INPUT, OUTPUT>
        where INPUT : IBaseExcelPrintBLInput
        where OUTPUT : IBaseExcelPrintBLOutput
    {
        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： Execute
        /// <summary>
        /// ベースビジネスロジックの実行
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/13　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public OUTPUT Execute(INPUT input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            OUTPUT output;

            // Ｅｘｃｅｌのアプリケーションオブジェクトを定義
            Microsoft.Office.Interop.Excel.Application excel = null;
            // Ｅｘｃｅｌのブックオブジェクトを定義
            Microsoft.Office.Interop.Excel.Workbook book = null;

            try
            {
                // Ｅｘｃｅｌのアプリケーションオブジェクトを作成
                excel = new Microsoft.Office.Interop.Excel.Application();

                // 非表示状態に設定
                excel.Visible = false;

                // 2014.12.11 toyoda Delete
                //// 20130218 abe シート削除対応のため追加 Start
                //// 警告メッセージを非表示
                //excel.DisplayAlerts = false;
                //// 20130218 abe シート削除対応のため追加 End

                // Ｅｘｃｅｌを開いてブックオブジェクトを取得
                book = excel.Workbooks.Open(
                    input.FormatPath,
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

                // 2014.12.11 toyoda Delete
                //// 20130218 abe シート削除対応のため追加 Start
                //// 警告メッセージを非表示
                //excel.DisplayAlerts = false;
                //// 20130218 abe シート削除対応のため追加 End

                // 20141026 yschew 改ページ挿入対策　START
                // 標準ビューの設定
                excel.ActiveWindow.View = Microsoft.Office.Interop.Excel.XlWindowView.xlNormalView;
                // 20141026 yschew 改ページ挿入対策　END

                // 2014.12.28 toyoda シート削除時にダイアログが出力され削除ができないことがあるため、SetBook中のダイアログを抑制
                bool preDisplayAlert = excel.DisplayAlerts;
                excel.DisplayAlerts = false;

                // ＥＸＣＥＬのブックオブジェクトにデータを設定する
                output = SetBook(input, book);

                // 2014.12.28 toyoda シート削除時にダイアログが出力され削除ができないことがあるため、SetBook中のダイアログを抑制
                excel.DisplayAlerts = preDisplayAlert;

                // 保存パスの取得
                string savePath = string.IsNullOrEmpty(input.SavePath) ? GetSavePath(input.PrintDirectory, input.FormatPath) : input.SavePath;

                if (input.SaveFileMode == SaveFileMode.Excel)
                {
                    // 保存
                    book.SaveAs(
                        savePath,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value);
                }
                else if (input.SaveFileMode == SaveFileMode.Pdf)
                {
                    // 保存先ファイルパスをPDFに変更する
                    string dir = Path.GetDirectoryName(savePath);
                    savePath = Path.Combine(dir, Path.GetFileNameWithoutExtension(savePath) + ".pdf");

                    // PDF保存実行
                    book.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, savePath);
                }

                // 保存パスの設定
                output.SavePath = savePath;

                // 処理終了後
                // 印刷指定の場合は印刷
                if (input.AfterPrintFlg)
                {
                    // 印刷実行
                    BookPrintOut(book, input.PrinterName, false, input.CopyCount, input.Collate);
                }

                if (input.AfterDispFlg)
                {
                    // 表示状態に設定
                    excel.Visible = true;

                    // 2014.12.11 toyoda Delete
                    //// 20130218 abe シート削除対応のため追加 Start
                    //excel.DisplayAlerts = true;
                    //// 20130218 abe シート削除対応のため追加 End
                }

            }
            //2012.03.22 habu MOD Start CustomException発生時にResultCodeが書き換わるのに対応
            catch (CustomException ce)
            {
                // 2014.12.11 toyoda Delete オブジェクトの後処理はfinallyで行う
                //if (excel != null)
                //{
                //    // 2011/08/02 Hieda Mod Start 例外処理時に例外が発生した場合にユーザー操作により書式が上書きされる可能性があるのを修正
                //    try
                //    {
                //        // 確認ダイアログを表示させない
                //        excel.DisplayAlerts = false;
                //    }
                //    catch (Exception e2)
                //    {
                //        // トレースログ出力
                //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e2.ToString());
                //    }

                //    try
                //    {
                //        // ＥＸＥＣＬを終了
                //        excel.Quit();
                //    }
                //    catch (Exception e3)
                //    {
                //        // トレースログ出力
                //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e3.ToString());
                //    }

                //    // 確認ダイアログを表示させない
                //    excel.DisplayAlerts = false;
                //    // ＥＸＥＣＬを終了
                //    //excel.Quit();

                //    // 2011/08/02 Hieda Mod End
                //}

                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ce.ToString());

                // CustomExceptionを上位ロジックに返す
                // 2014.12.11 toyoda Mod スタックトレースが途切れる
                //throw ce;
                throw;
            }
            //2012.03.22 habu MOD Start End
            catch (Exception e)
            {
                // 2014.12.11 toyoda Delete オブジェクトの後処理はfinallyで行う
                //if (excel != null)
                //{
                //    // 2011/08/02 Hieda Mod Start 例外処理時に例外が発生した場合にユーザー操作により書式が上書きされる可能性があるのを修正
                //    try
                //    {
                //        // 確認ダイアログを表示させない
                //        excel.DisplayAlerts = false;
                //    }
                //    catch (Exception e2)
                //    {
                //        // トレースログ出力
                //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e2.ToString());
                //    }

                //    try
                //    {
                //        // ＥＸＥＣＬを終了
                //        excel.Quit();
                //    }
                //    catch (Exception e3)
                //    {
                //        // トレースログ出力
                //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e3.ToString());
                //    }

                //// 確認ダイアログを表示させない
                //excel.DisplayAlerts = false;
                //// ＥＸＥＣＬを終了
                //excel.Quit();

                //// 2011/08/02 Hieda Mod End

                //}

                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e.ToString());
                // ＤＢエラー
                throw new CustomException(ResultCode.OtherError, string.Format("エラー内容:{0}", e.Message));
            }
            finally
            {
                if (!input.AfterDispFlg)
                {
                    // Ｅｘｃｅｌのブックオブジェクトを解放
                    if (book != null)
                    {
                        // ブックを閉じる
                        int count = 0;
                        while (count < 10)
                        {
                            try
                            {
                                // 変更を保存しない
                                book.Close(false, Type.Missing, Type.Missing);
                                break;
                            }
                            catch
                            {
                                // PDF変換出力中に閉じようとするとエラーとなる為、リトライする
                            }

                            System.Threading.Thread.Sleep(500);

                            count++;
                        }

                        Marshal.ReleaseComObject(book);
                    }

                    if (excel != null)
                    {
                        // ＥＸＥＣＬを終了
                        excel.Quit();

                        Marshal.ReleaseComObject(excel);
                    }

                }
                else
                {
                    // Ｅｘｃｅｌのブックオブジェクトを解放
                    if (book != null)
                    {
                        Marshal.ReleaseComObject(book);
                    }

                    if (excel != null)
                    {
                        Marshal.ReleaseComObject(excel);
                    }
                }

                GC.Collect();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

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
        /// 2010/07/13　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected abstract OUTPUT SetBook(INPUT input, Microsoft.Office.Interop.Excel.Workbook book);
        #endregion

        #region CellOutput
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： CellOutput
        /// <summary>
        /// ＥＸＣＥＬのセルオブジェクトにデータを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="row">行番号</param>
        /// <param name="col">列番号</param>
        /// <param name="obj">セルオブジェクトに設定するオブジェクト</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/13　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CellOutput(Microsoft.Office.Interop.Excel.Worksheet sheet, int row, int col, object obj)
        {
            // Ｅｘｃｅｌのレンジオブジェクトを定義
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                // Ｅｘｃｅｌのレンジオブジェクトを設定
                range = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[row + 1, col + 1];
                // Ｅｘｃｅｌのレンジオブジェクトにオブジェクトを設定
                range.Value2 = obj;
            }
            finally
            {
                // Ｅｘｃｅｌのレンジオブジェクトを解放
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }
        #endregion
        
        #region InsertRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertRow
        /// <summary>
        /// ＥＸＣＥＬのシートに行を挿入する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="row">行番号</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/07　土生　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void InsertRow(Microsoft.Office.Interop.Excel.Worksheet sheet, int row)
        {
            Microsoft.Office.Interop.Excel.Range rows = null;
            try
            {
                rows = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[row + 1, Type.Missing];

                // 行を挿入
                rows.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
            }
            finally
            {
                if (rows != null)
                {
                    Marshal.ReleaseComObject(rows);
                }
            }
        }
        #endregion

        #region InsertColumn
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertColumn
        /// <summary>
        /// ＥＸＣＥＬのシートに列を挿入する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="col">列番号</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/03/09　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void InsertColumn(Microsoft.Office.Interop.Excel.Worksheet sheet, int col)
        {
            Microsoft.Office.Interop.Excel.Range columns = null;
            try
            {
                columns = (Microsoft.Office.Interop.Excel.Range)sheet.Columns[col + 1, Type.Missing];

                // 行を挿入
                columns.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
            }
            finally
            {
                if (columns != null)
                {
                    Marshal.ReleaseComObject(columns);
                }
            }
        }
        #endregion

        #region CopyRange
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CopyRange
        /// <summary>
        /// ＥＸＣＥＬのシートの範囲をコピー
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="book"></param>
        /// <param name="fromSheetNo"></param>
        /// <param name="fromRowNum"></param>
        /// <param name="fromColNum"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <param name="toSheetNo"></param>
        /// <param name="toRowNum"></param>
        /// <param name="toColNum"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/01　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CopyRange(Microsoft.Office.Interop.Excel.Workbook book, int fromSheetNo, int fromRowNum, int fromColNum, int rowCount, int colCount, int toSheetNo, int toRowNum, int toColNum)
        {
            Microsoft.Office.Interop.Excel.Range rangeBegin = null;
            Microsoft.Office.Interop.Excel.Range rangeEnd = null;
            Microsoft.Office.Interop.Excel.Range rangeFrom = null;
            Microsoft.Office.Interop.Excel.Range rangeTo = null;

            try
            {

                rangeBegin = (Microsoft.Office.Interop.Excel.Range)((Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[fromSheetNo]).Cells[fromRowNum, fromColNum];

                rangeEnd = (Microsoft.Office.Interop.Excel.Range)((Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[fromSheetNo]).Cells[fromRowNum + rowCount - 1, fromColNum + colCount - 1];

                rangeFrom = (Microsoft.Office.Interop.Excel.Range)((Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[fromSheetNo]).Range[rangeBegin, rangeEnd];

                rangeTo = (Microsoft.Office.Interop.Excel.Range)((Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[toSheetNo]).Cells[toRowNum, toColNum];

                rangeFrom.Copy(rangeTo);
            }
            finally
            {
                //クリップボードをクリアする
                System.Windows.Forms.Clipboard.Clear();

                if (rangeBegin != null)
                {
                    Marshal.ReleaseComObject(rangeBegin);
                }
                if (rangeEnd != null)
                {
                    Marshal.ReleaseComObject(rangeEnd);
                }
                if (rangeFrom != null)
                {
                    Marshal.ReleaseComObject(rangeFrom);
                }
                if (rangeTo != null)
                {
                    Marshal.ReleaseComObject(rangeTo);
                }
            }
        }
        #endregion

        #region CopyRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CopyRow
        /// <summary>
        /// ＥＸＣＥＬのシートの行をコピー
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="rowFrom">コピー元行番号(0-origin)</param>
        /// <param name="rowCnt">コピー行数(コピー元側の行数)</param>
        /// <param name="rowTo">コピー先行番号(0-origin)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/07　土生　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CopyRow(Microsoft.Office.Interop.Excel.Worksheet sheet, int rowFrom, int rowCnt, int rowTo)
        {
            Microsoft.Office.Interop.Excel.Range rangeBegin = null;
            Microsoft.Office.Interop.Excel.Range rangeEnd = null;
            Microsoft.Office.Interop.Excel.Range rangeFrom = null;
            Microsoft.Office.Interop.Excel.Range rangeTo = null;

            try
            {
                rangeBegin = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[rowFrom + 1];
                rangeEnd = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[rowFrom + rowCnt];
                rangeFrom = (Microsoft.Office.Interop.Excel.Range)sheet.Range[rangeBegin, rangeEnd];
                rangeTo = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[rowTo + 1];

                rangeFrom.Copy(rangeTo);
            }
            finally
            {
                //クリップボードをクリアする
                System.Windows.Forms.Clipboard.Clear();

                if (rangeBegin != null)
                {
                    Marshal.ReleaseComObject(rangeBegin);
                }
                if (rangeEnd != null)
                {
                    Marshal.ReleaseComObject(rangeEnd);
                }
                if (rangeFrom != null)
                {
                    Marshal.ReleaseComObject(rangeFrom);
                }
                if (rangeTo != null)
                {
                    Marshal.ReleaseComObject(rangeTo);
                }
            }
        }
        #endregion

        #region CopyRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetFrom"></param>
        /// <param name="rowFrom"></param>
        /// <param name="rowCnt"></param>
        /// <param name="sheetTo"></param>
        /// <param name="rowTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15　土生　　    新規作成
        /// </history>
        protected void CopyRow(Microsoft.Office.Interop.Excel.Worksheet sheetFrom, int rowFrom, int rowCnt, Microsoft.Office.Interop.Excel.Worksheet sheetTo, int rowTo)
        {
            Microsoft.Office.Interop.Excel.Range rangeBegin = null;
            Microsoft.Office.Interop.Excel.Range rangeEnd = null;
            Microsoft.Office.Interop.Excel.Range rangeFrom = null;
            Microsoft.Office.Interop.Excel.Range rangeTo = null;

            try
            {
                rangeBegin = (Microsoft.Office.Interop.Excel.Range)sheetFrom.Rows[rowFrom + 1];
                rangeEnd = (Microsoft.Office.Interop.Excel.Range)sheetFrom.Rows[rowFrom + rowCnt];
                rangeFrom = (Microsoft.Office.Interop.Excel.Range)sheetFrom.Range[rangeBegin, rangeEnd];
                rangeTo = (Microsoft.Office.Interop.Excel.Range)sheetTo.Rows[rowTo + 1];

                rangeFrom.Copy(rangeTo);
            }
            finally
            {
                //クリップボードをクリアする
                System.Windows.Forms.Clipboard.Clear();

                if (rangeBegin != null)
                {
                    Marshal.ReleaseComObject(rangeBegin);
                }
                if (rangeEnd != null)
                {
                    Marshal.ReleaseComObject(rangeEnd);
                }
                if (rangeFrom != null)
                {
                    Marshal.ReleaseComObject(rangeFrom);
                }
                if (rangeTo != null)
                {
                    Marshal.ReleaseComObject(rangeTo);
                }
            }
        }
        #endregion

        #region CopyColumn
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CopyColumn
        /// <summary>
        /// ＥＸＣＥＬのシートの列をコピー
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="rowFrom">コピー元行番号</param>
        /// <param name="rowCnt">コピー行数</param>
        /// <param name="rowTo">コピー先行番号</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/03/09　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CopyColumn(Microsoft.Office.Interop.Excel.Worksheet sheet, int columnFrom, int columnCnt, int columnTo)
        {
            Microsoft.Office.Interop.Excel.Range rangeBegin = null;
            Microsoft.Office.Interop.Excel.Range rangeEnd = null;
            Microsoft.Office.Interop.Excel.Range rangeFrom = null;
            Microsoft.Office.Interop.Excel.Range rangeTo = null;

            try
            {
                rangeBegin = (Microsoft.Office.Interop.Excel.Range)sheet.Columns[columnFrom + 1];
                rangeEnd = (Microsoft.Office.Interop.Excel.Range)sheet.Columns[columnFrom + columnCnt];
                rangeFrom = (Microsoft.Office.Interop.Excel.Range)sheet.Range[rangeBegin, rangeEnd];
                rangeTo = (Microsoft.Office.Interop.Excel.Range)sheet.Columns[columnTo + 1];

                rangeFrom.Copy(rangeTo);
            }
            finally
            {
                //クリップボードをクリアする
                System.Windows.Forms.Clipboard.Clear();

                if (rangeBegin != null)
                {
                    Marshal.ReleaseComObject(rangeBegin);
                }
                if (rangeEnd != null)
                {
                    Marshal.ReleaseComObject(rangeEnd);
                }
                if (rangeFrom != null)
                {
                    Marshal.ReleaseComObject(rangeFrom);
                }
                if (rangeTo != null)
                {
                    Marshal.ReleaseComObject(rangeTo);
                }
            }
        }
        #endregion

        #region DeleteRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteRow
        /// <summary>
        /// ＥＸＣＥＬのシートの行を削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="rowFrom">削除行番号</param>
        /// <param name="rowCnt">削除行数</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/07　土生　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void DeleteRow(Microsoft.Office.Interop.Excel.Worksheet sheet, int rowFrom, int rowCnt)
        {
            Microsoft.Office.Interop.Excel.Range rangeBegin = null;
            Microsoft.Office.Interop.Excel.Range rangeEnd = null;
            Microsoft.Office.Interop.Excel.Range rangeFrom = null;

            try
            {
                rangeBegin = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[rowFrom + 1];
                rangeEnd = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[rowFrom + rowCnt];
                rangeFrom = (Microsoft.Office.Interop.Excel.Range)sheet.Range[rangeBegin, rangeEnd];

                rangeFrom.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);
            }
            finally
            {
                if (rangeBegin != null)
                {
                    Marshal.ReleaseComObject(rangeBegin);
                }
                if (rangeEnd != null)
                {
                    Marshal.ReleaseComObject(rangeEnd);
                }
                if (rangeFrom != null)
                {
                    Marshal.ReleaseComObject(rangeFrom);
                }
            }
        }
        #endregion

        #region DeleteColumn
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteColumn
        /// <summary>
        /// ＥＸＣＥＬのシートの列を削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="columnFrom">削除列番号</param>
        /// <param name="columnCnt">削除列数</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/03/09　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void DeleteColumn(Microsoft.Office.Interop.Excel.Worksheet sheet, int columnFrom, int columnCnt)
        {
            Microsoft.Office.Interop.Excel.Range rangeBegin = null;
            Microsoft.Office.Interop.Excel.Range rangeEnd = null;
            Microsoft.Office.Interop.Excel.Range rangeFrom = null;

            try
            {
                rangeBegin = (Microsoft.Office.Interop.Excel.Range)sheet.Columns[columnFrom + 1];
                rangeEnd = (Microsoft.Office.Interop.Excel.Range)sheet.Columns[columnFrom + columnCnt];
                rangeFrom = (Microsoft.Office.Interop.Excel.Range)sheet.Range[rangeBegin, rangeEnd];

                rangeFrom.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftToLeft);
            }
            finally
            {
                if (rangeBegin != null)
                {
                    Marshal.ReleaseComObject(rangeBegin);
                }
                if (rangeEnd != null)
                {
                    Marshal.ReleaseComObject(rangeEnd);
                }
                if (rangeFrom != null)
                {
                    Marshal.ReleaseComObject(rangeFrom);
                }
            }
        }
        #endregion
        
        #region SetPageBreak
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetPageBreak
        /// <summary>
        /// ＥＸＣＥＬのシートの指定行の上に改ページを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="row">行番号</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/07　土生　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void SetPageBreak(Microsoft.Office.Interop.Excel.Worksheet sheet, int row)
        {
            Microsoft.Office.Interop.Excel.Range range = null;
            try
            {
                range = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[row + 1, Type.Missing];
                range.PageBreak = (int)Microsoft.Office.Interop.Excel.XlPageBreak.xlPageBreakManual;
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

        #region CopySheet
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CopySheet
        /// <summary>
        /// ＥＸＣＥＬのシートをコピーする
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="book">ブックオブジェクト</param>
        /// <param name="fromIdx">コピー元シート番号</param>
        /// <param name="toIdx">コピー先シート番号</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/07　土生　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CopySheet(Microsoft.Office.Interop.Excel.Workbook book, int fromIdx, int toIdx)
        {
            Microsoft.Office.Interop.Excel.Worksheet fromSheet = null;
            Microsoft.Office.Interop.Excel.Worksheet toSheet = null;

            // Excelアプリケーション
            Microsoft.Office.Interop.Excel.Application excel = null;

            try
            {
                // Visibleの状態を退避
                excel = (Microsoft.Office.Interop.Excel.Application)book.Application;
                bool preVisible = excel.Visible;

                fromSheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[fromIdx + 1];
                if (toIdx >= book.Sheets.Count)
                {
                    toSheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[book.Sheets.Count];

                    fromSheet.Copy(Type.Missing, toSheet);
                }
                else
                {
                    toSheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[toIdx + 1];

                    fromSheet.Copy(toSheet, Type.Missing);
                }

                // 強制的にVisibleを戻す(変わっていた場合のみ)
                if (excel.Visible != preVisible)
                {
                    excel.Visible = preVisible;
                }
            }
            finally
            {
                //クリップボードをクリアする
                System.Windows.Forms.Clipboard.Clear();

                if (fromSheet != null)
                {
                    Marshal.ReleaseComObject(fromSheet);
                }
                if (toSheet != null)
                {
                    Marshal.ReleaseComObject(toSheet);
                }                
                if (excel != null)
                {
                    Marshal.ReleaseComObject(excel);
                }
            }
        }
        #endregion

        #region DeleteSheet
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteSheet
        /// <summary>
        /// ＥＸＣＥＬのシートを削除する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="book">ブックオブジェクト</param>
        /// <param name="idx">シート番号</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/12/11　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void DeleteSheet(Microsoft.Office.Interop.Excel.Workbook book, int idx)
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Application excel = null;

            try
            {
                excel = book.Application;

                bool preDisplayAlerts = excel.DisplayAlerts;

                excel.DisplayAlerts = false;

                sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[idx];

                sheet.Delete();

                excel.DisplayAlerts = preDisplayAlerts;
            }
            finally
            {
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }

                if (excel != null)
                {
                    Marshal.ReleaseComObject(excel);
                }
            }
        }
        #endregion

        #region GetSheetIdxByName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15　habu　　    新規作成
        /// </history>
        protected int GetSheetIdxByName(Microsoft.Office.Interop.Excel.Workbook book, string sheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Sheets sheets = null;

            try
            {
                sheets = book.Sheets;
                sheet = (Worksheet)sheets[sheetName];

                return sheet.Index - 1;
            }
            finally
            {
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }

                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }
            }
        }
        #endregion

        #region GetSheetByName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15　habu　　    新規作成
        /// </history>
        protected Worksheet GetSheetByName(Microsoft.Office.Interop.Excel.Workbook book, string sheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Sheets sheets = null;

            try
            {
                sheets = book.Sheets;
                sheet = (Worksheet)sheets[sheetName];

                return sheet;
            }
            finally
            {
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }

                // Reserve sheet unreleased
            }
        }
        #endregion

        #region GetSheetCount
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　habu　　    新規作成
        /// </history>
        protected int GetSheetCount(Workbook book)
        {
            Microsoft.Office.Interop.Excel.Sheets sheets = null;

            try
            {
                sheets = book.Sheets;

                return sheets.Count;
            }
            finally
            {
                if (sheets != null)
                {
                    Marshal.ReleaseComObject(sheets);
                }
            }
        }
        #endregion

        #region CreateShapeOval
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShapeOval
        /// <summary>
        /// ＥＸＣＥＬの指定位置に指定の大きさのオートシェイプ（正円）を作成
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="diameter"></param>
        /// <param name="backColor"></param>
        /// <param name="lineColor"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/01　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CreateShapeOval(Microsoft.Office.Interop.Excel.Worksheet sheet, float left, float top, float diameter, Color backColor, Color? lineColor)
        {
            Microsoft.Office.Interop.Excel.Shape shape = null;
            
            try
            {
                shape = sheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, left, top, diameter, diameter);

                shape.Fill.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(int.Parse(backColor.R.ToString()), int.Parse(backColor.G.ToString()), int.Parse(backColor.B.ToString()));

                if (lineColor.HasValue)
                {
                    shape.Line.Weight = 1;
                    shape.Line.ForeColor.RGB = Microsoft.VisualBasic.Information.RGB(int.Parse(lineColor.Value.R.ToString()), int.Parse(lineColor.Value.G.ToString()), int.Parse(lineColor.Value.B.ToString()));
                }
                else
                {
                    shape.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                }
            }
            finally
            {
                if (shape != null)
                {
                    Marshal.ReleaseComObject(shape);
                }
            }
        }
        #endregion

        #region SetShapeText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <param name="fontColor"></param>
        protected void SetShapeText(Microsoft.Office.Interop.Excel.Worksheet sheet, string name, string text, Color fontColor)
        {
            // Ｅｘｃｅｌのテキストボックスオブジェクトを定義
            Microsoft.Office.Interop.Excel.Shape shape = null;

            Microsoft.Office.Interop.Excel.TextFrame textFrame = null;

            try
            {
                shape = sheet.Shapes.Item(name);

                textFrame = shape.TextFrame;

                textFrame.Characters(null, null).Text = text;

                textFrame.Characters(null, null).Font.Color = Microsoft.VisualBasic.Information.RGB(int.Parse(fontColor.R.ToString()), int.Parse(fontColor.G.ToString()), int.Parse(fontColor.B.ToString()));
            }
            finally
            {
                if (textFrame != null)
                {
                    Marshal.ReleaseComObject(textFrame);
                }

                if (shape != null)
                {
                    Marshal.ReleaseComObject(shape);
                }
            }
        }
        #endregion

        #region SetShapeText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        protected void SetShapeText(Microsoft.Office.Interop.Excel.Worksheet sheet, string name, string text)
        {
            // Ｅｘｃｅｌのテキストボックスオブジェクトを定義
            Microsoft.Office.Interop.Excel.Shape oShape = null;

            try
            {
                // Ｅｘｃｅｌのテキストボックスオブジェクトを設定
                oShape = sheet.Shapes.Item(name);
                // Ｅｘｃｅｌのテキストボックスオブジェクトにテキストを設定
                oShape.TextFrame.Characters(Type.Missing, Type.Missing).Text = text;
            }
            finally
            {
                // Ｅｘｃｅｌのテキストボックスオブジェクトを解放
                if (oShape != null) { Marshal.ReleaseComObject(oShape); }
            }
        }
        #endregion

        #region SetShapeFontColor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <param name="fontColor"></param>
        protected void SetShapeFontColor(Microsoft.Office.Interop.Excel.Worksheet sheet, string name, Color fontColor)
        {
            // Ｅｘｃｅｌのテキストボックスオブジェクトを定義
            Microsoft.Office.Interop.Excel.Shape shape = null;

            Microsoft.Office.Interop.Excel.TextFrame textFrame = null;

            try
            {
                shape = sheet.Shapes.Item(name);

                textFrame = shape.TextFrame;
                
                textFrame.Characters(null, null).Font.Color = Microsoft.VisualBasic.Information.RGB(int.Parse(fontColor.R.ToString()), int.Parse(fontColor.G.ToString()), int.Parse(fontColor.B.ToString()));
            }
            finally
            {
                if (textFrame != null)
                {
                    Marshal.ReleaseComObject(textFrame);
                }

                if (shape != null)
                {
                    Marshal.ReleaseComObject(shape);
                }
            }
        }
        #endregion

        #region SetShapeFontColor
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetShapeFontColor
        /// <summary>
        /// set color for character 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <param name="fontColor"></param>
        /// <param name="startIdxFillColor"></param>
        /// <param name="characterCount"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/21　HuyTX      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void SetShapeFontColor(Microsoft.Office.Interop.Excel.Worksheet sheet, string name, Color fontColor, int startIdxFillColor, int characterCount)
        {
            // Ｅｘｃｅｌのテキストボックスオブジェクトを定義
            Microsoft.Office.Interop.Excel.Shape shape = null;

            Microsoft.Office.Interop.Excel.TextFrame textFrame = null;

            try
            {
                shape = sheet.Shapes.Item(name);

                textFrame = shape.TextFrame;

                textFrame.Characters(startIdxFillColor, characterCount).Font.Color = Microsoft.VisualBasic.Information.RGB(int.Parse(fontColor.R.ToString()), int.Parse(fontColor.G.ToString()), int.Parse(fontColor.B.ToString()));
            }
            finally
            {
                if (textFrame != null)
                {
                    Marshal.ReleaseComObject(textFrame);
                }

                if (shape != null)
                {
                    Marshal.ReleaseComObject(shape);
                }
            }
        }
        #endregion

        #region GetWidth
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetWidth
        /// <summary>
        /// ＥＸＣＥＬのレンジオブジェクトの巾を取得する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="columnFrom">開始列番号</param>
        /// <param name="columnCnt">列数</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/06/28　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected float GetWidth(Microsoft.Office.Interop.Excel.Worksheet sheet, int columnFrom, int columnCnt)
        {
            if (columnCnt < 1)
            {
                return 0;
            }

            // Ｅｘｃｅｌのレンジオブジェクトを定義
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                // Ｅｘｃｅｌのレンジオブジェクトを設定
                range = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range(sheet.Cells[1, columnFrom], sheet.Cells[1, columnFrom + columnCnt - 1]);
                // レンジの巾を取得

                return float.Parse(range.Width.ToString());
            }
            finally
            {
                // Ｅｘｃｅｌのレンジオブジェクトを解放
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }
        #endregion

        #region GetHeight
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetHeight
        /// <summary>
        /// ＥＸＣＥＬのレンジオブジェクトの高さを取得する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="rowFrom">開始行番号</param>
        /// <param name="rowCnt">行数</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/06/28　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected float GetHeight(Microsoft.Office.Interop.Excel.Worksheet sheet, int rowFrom, int rowCnt)
        {
            if (rowCnt < 1)
            {
                return 0;
            }

            // Ｅｘｃｅｌのレンジオブジェクトを定義
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                // Ｅｘｃｅｌのレンジオブジェクトを設定
                range = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range(sheet.Cells[rowFrom, 1], sheet.Cells[rowFrom + rowCnt - 1, 1]);
                // レンジの巾を取得

                return float.Parse(range.Height.ToString());
            }
            finally
            {
                // Ｅｘｃｅｌのレンジオブジェクトを解放
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }
        #endregion

        #region SetRowGroup
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetRowGroup
        /// <summary>
        /// ＥＸＣＥＬの行のグループ化を設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="rowFrom">開始行番号</param>
        /// <param name="rowCnt">行数</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/06/28　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void SetRowGroup(Microsoft.Office.Interop.Excel.Worksheet sheet, int rowFrom, int rowCnt)
        {
            if (rowCnt < 1)
            {
                return;
            }

            // Ｅｘｃｅｌのレンジオブジェクトを定義
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                // Ｅｘｃｅｌのレンジオブジェクトを設定
                range = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[string.Format("{0}:{1}", rowFrom, rowFrom + rowCnt - 1), Type.Missing];
                // 範囲のグループ化
                range.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            finally
            {
                // Ｅｘｃｅｌのレンジオブジェクトを解放
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }
        #endregion

        #region SetUnderLine
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetUnderLine
        /// <summary>
        /// ＥＸＣＥＬの行に下線を引く
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="row">行番号</param>
        /// <param name="columnFrom">開始列数</param>
        /// <param name="columnTo">終了列数</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/07/01　安部　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void SetUnderLine(Microsoft.Office.Interop.Excel.Worksheet sheet, int row, int columnFrom, int columnTo)
        {
            // Ｅｘｃｅｌのレンジオブジェクトを定義
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                // Ｅｘｃｅｌのレンジオブジェクトを設定
                range = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range(sheet.Cells[row, columnFrom], sheet.Cells[row, columnTo]);
                // 範囲に太字下線を表示
                range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            }
            finally
            {
                // Ｅｘｃｅｌのレンジオブジェクトを解放
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }
        #endregion

        #region SetTopLine
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetTopLine
        /// <summary>
        /// ＥＸＣＥＬの行に上線を引く
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シートオブジェクト</param>
        /// <param name="row">行番号</param>
        /// <param name="columnFrom">開始列数</param>
        /// <param name="columnTo">終了列数</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/07/01　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void SetTopLine(Microsoft.Office.Interop.Excel.Worksheet sheet, int row, int columnFrom, int columnTo)
        {
            // Ｅｘｃｅｌのレンジオブジェクトを定義
            Microsoft.Office.Interop.Excel.Range range = null;

            try
            {
                // Ｅｘｃｅｌのレンジオブジェクトを設定
                range = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range(sheet.Cells[row, columnFrom], sheet.Cells[row, columnTo]);
                // 範囲に太字上線を表示
                range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            }
            finally
            {
                // Ｅｘｃｅｌのレンジオブジェクトを解放
                if (range != null) { Marshal.ReleaseComObject(range); }
            }
        }
        #endregion

        #region BookPrintOut
        /// <summary>
        /// 指定ブックの全ページを印刷する
        /// </summary>
        /// <param name="book">印刷対象Excelブック</param>
        /// <param name="activePrinter">Windowsプリンタ名。省略時は既定のプリンタを使用</param>
        /// <param name="preview">trueの場合印刷プレビューウィンドウを表示する</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　土生　　    新規作成
        /// 2014/10/27　土生　　    Added CopyCount,Collate
        /// </history>
        public void BookPrintOut(Workbook book, string activePrinter, bool preview, int copies, bool collate)
        {
            // プリンタ未指定の場合は既定のプリンタを使用する
            object targetPrinter = Type.Missing;
            if (!string.IsNullOrEmpty(activePrinter))
            {
                targetPrinter = activePrinter;
            }

            // 部数未指定の場合は、1部印刷する
            if (copies == default(int) || copies < 1)
            {
                copies = 1;
            }

            // 印刷実行
            book.PrintOutEx(
                Type.Missing
                , Type.Missing
                , copies
                , preview
                , targetPrinter
                , Type.Missing
                , collate
                , Type.Missing
                , Type.Missing
                );
        }
        #endregion

        #region SelectCell
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SelectCell
        /// <summary>
        /// 改ページを挿入
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sheet">シート</param>
        /// <param name="row">行番号</param>
        /// <param name="col">列番号</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void SelectCell(Microsoft.Office.Interop.Excel.Worksheet sheet, int row, int col)
        {
            Range range = null;
            try
            {
                // 行を選択
                range = (Range)sheet.Cells[row, col];

                // アクティブ
                range.Activate();
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

        #region DeleteShape
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： DeleteShape
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HuyTX      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void DeleteShape(Microsoft.Office.Interop.Excel.Worksheet sheet, string name)
        {
            // Ｅｘｃｅｌのテキストボックスオブジェクトを定義
            Microsoft.Office.Interop.Excel.Shape oShape = null;

            try
            {
                // Ｅｘｃｅｌのテキストボックスオブジェクトを設定
                oShape = sheet.Shapes.Item(name);

                oShape.Delete();
            }
            finally
            {
                // Ｅｘｃｅｌのテキストボックスオブジェクトを解放
                if (oShape != null) { Marshal.ReleaseComObject(oShape); }
            }
        }
        #endregion

        #region SetLineTopLocation
        /// <summary>
        /// 線オブジェクトの表示位置を調整する
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <param name="fontColor"></param>
        protected void SetLineTopLocation(Microsoft.Office.Interop.Excel.Worksheet sheet, string name, float top)
        {
            // Ｅｘｃｅｌのテキストボックスオブジェクトを定義
            Microsoft.Office.Interop.Excel.Shape shape = null;


            try
            {
                shape = sheet.Shapes.Item(name);

                shape.Top = top;
            }
            finally
            {
                if (shape != null)
                {
                    Marshal.ReleaseComObject(shape);
                }
            }
        }
        #endregion

        #region SetPrintArea
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="topRow">0-origin</param>
        /// <param name="leftCol">0-origin</param>
        /// <param name="bottomRow">0-origin</param>
        /// <param name="rightCol">0-origin</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16　habu　　    新規作成
        /// </history>
        protected static void SetPrintArea(Worksheet sheet, int topRow, int leftCol, int bottomRow, int rightCol)
        {
            PageSetup ps = null;
            Range leftTop = null;
            Range rightBottom = null;
            Range printRange = null;

            try
            {
                ps = sheet.PageSetup;

                leftTop = (Range)sheet.Cells[topRow + 1, leftCol + 1];
                rightBottom = (Range)sheet.Cells[bottomRow + 1, rightCol + 1];
                printRange = sheet.Range[leftTop, rightBottom];

                ps.PrintArea = printRange.get_Address();
            }
            finally
            {
                if (ps != null)
                {
                    Marshal.ReleaseComObject(ps);
                }
                if (leftTop != null)
                {
                    Marshal.ReleaseComObject(leftTop);
                }
                if (rightBottom != null)
                {
                    Marshal.ReleaseComObject(rightBottom);
                }
                if (printRange != null)
                {
                    Marshal.ReleaseComObject(printRange);
                }
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region GetSavePath
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetSavePath
        /// <summary>
        /// 保存パスの取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="formatPath">ＥＸＣＥＬ書式へのパス</param>
        /// <returns>保存パス</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/13　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetSavePath(string printDirectory, string formatPath)
        {
            // ファイル名の作成
            string fileName = Path.GetFileNameWithoutExtension(formatPath) + @"_"
                + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(formatPath);
            // 保存パスを作成して戻す
            return Path.Combine(printDirectory, fileName);
        }
        #endregion

        #endregion
    }
    #endregion
}
