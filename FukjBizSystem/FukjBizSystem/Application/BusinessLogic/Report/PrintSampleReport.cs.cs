using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Report
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSampleReportBLInput
    /// <summary>
    /// 入力インターフェイス定義
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/01　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSampleReportBLInput : IBaseExcelPrintBLInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSampleReportBLInput
    /// <summary>
    /// 入力クラス定義
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/01　豊田　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSampleReportBLInput : BaseExcelPrintBLInputImpl, IPrintSampleReportBLInput
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
        ///// 作成したExcelファイルを起動する(true)／しない(false)
        ///// 印刷プレビュー後にExcelを終了しない(true)／する(false)
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSampleReportBLOutput
    /// <summary>
    /// 出力インターフェイス定義
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/01　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSampleReportBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSampleReportBLOutput
    /// <summary>
    /// 出力クラス定義
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/01　豊田　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSampleReportBLOutput : BaseExcelPrintBLOutputImpl, IPrintSampleReportBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSampleReportBusinessLogic
    /// <summary>
    /// レポート出力サンプル
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/01　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSampleReportBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSampleReportBLInput, IPrintSampleReportBLOutput>
    {
        #region 定数
        
        /// <summary>
        /// 1ページ行数
        /// </summary>
        private static readonly int PAGE_ROW_CNT = 43;

        /// <summary>
        /// 部品行数
        /// </summary>
        private static readonly int PARTS_COLUMN_COUNT = 19;

        /// <summary>
        /// 部品列番号
        /// </summary>
        private static readonly int PARTS_COLUMN_INDEX = 2;

        /// <summary>
        /// 部品行数
        /// </summary>
        private static readonly int PARTS_ROW_COUNT = 12;

        /// <summary>
        /// 部品１行番号
        /// </summary>
        private static readonly int PARTS1_ROW_INDEX = 2;

        /// <summary>
        /// 部品２行番号
        /// </summary>
        private static readonly int PARTS2_ROW_INDEX = 15;

        /// <summary>
        /// 部品３行番号
        /// </summary>
        private static readonly int PARTS3_ROW_INDEX = 28;

        #endregion 定義

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSampleReportBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/01　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSampleReportBusinessLogic()
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
        /// 2014/08/01　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSampleReportBLOutput SetBook(IPrintSampleReportBLInput input, Workbook book)
        {
            IPrintSampleReportBLOutput output = new PrintSampleReportBLOutput();

            Worksheet sheet = null;

            try
            {
                // 3ページ分作成する
                int pageCount = 3;

                // 各ページの開始行番号
                int startRowIndex = 0;

                // シートの取得
                sheet = (Worksheet)book.Sheets[1];

                // テンプレートの複製
                CopyTemplate(sheet, pageCount);

                // 1ページづつ出力
                for (int i = 0; i < pageCount; i++)
                {
                    startRowIndex = i * PAGE_ROW_CNT;

                    if (i == 0)
                    {
                        // 部品のコピー
                        CopyRange(book, 2, PARTS1_ROW_INDEX, PARTS_COLUMN_INDEX, PARTS_ROW_COUNT, PARTS_COLUMN_COUNT, 1, startRowIndex + 31, 2);

                        // 円オブジェクトの作成
                        CreateShapeOval(sheet, GetWidth(sheet, 1, 21), GetHeight(sheet, 1, startRowIndex + 40) + 1, GetHeight(sheet, startRowIndex + 40, 2) - 2, Color.HotPink, Color.Red);
                    }
                    else if (i == 1)
                    {
                        // 部品のコピー
                        CopyRange(book, 2, PARTS2_ROW_INDEX, PARTS_COLUMN_INDEX, PARTS_ROW_COUNT, PARTS_COLUMN_COUNT, 1, startRowIndex + 31, 2);

                        // 円オブジェクトの作成
                        CreateShapeOval(sheet, GetWidth(sheet, 1, 23), GetHeight(sheet, 1, startRowIndex + 40) + 1, GetHeight(sheet, startRowIndex + 40, 2) - 2, Color.PaleTurquoise, Color.Blue);
                    }
                    else
                    {
                        // 部品のコピー
                        CopyRange(book, 2, PARTS3_ROW_INDEX, PARTS_COLUMN_INDEX, PARTS_ROW_COUNT, PARTS_COLUMN_COUNT, 1, startRowIndex + 31, 2);

                        // 円オブジェクトの作成
                        CreateShapeOval(sheet, GetWidth(sheet, 1, 25), GetHeight(sheet, 1, startRowIndex + 40) + 1, GetHeight(sheet, startRowIndex + 40, 2) - 2, SystemColors.Control, Color.Black);
                    }

                    // テキストボックスの編集（テキストのみ）
                    SetShapeText(sheet, "TB_LABEL1", DateTime.Now.ToString("yyyy年MM月dd日"));

                    // テキストボックスの編集（テキスト＋色）
                    SetShapeText(sheet, "TB_LABEL2", DateTime.Now.ToString("HH時mm分ss秒"), Color.Red);

                    // テキストボックスの編集（色のみ）
                    SetShapeFontColor(sheet, "TB_LABEL3", Color.Blue);
                }

                // 部品シートを削除
                DeleteSheet(book, 2);
            }
            finally
            {
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CopyTemplate
        /// <summary>
        /// 指定ページ数分テンプレートをコピー
        /// </summary>
        /// <param name="count"></param>
        private void CopyTemplate(Worksheet sheet, int count)
        {
            int idx = 0;

            // 指定ページ数分繰り返す
            for (int i = 1; i < count; i++)
            {
                // 行範囲コピー
                CopyRow(sheet, 0, PAGE_ROW_CNT, idx + PAGE_ROW_CNT);

                //改ページを設定
                SetPageBreak(sheet, idx + PAGE_ROW_CNT);

                idx += PAGE_ROW_CNT;
            }
        }
        #endregion

        #endregion


    }
    #endregion
}
