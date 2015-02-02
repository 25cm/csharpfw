using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.Utility;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Core.Common.BusinessLogic.Print;
using Zynas.Framework.Core.Common.BusinessLogic.Print.MSExcel;

namespace FukjBizSystem.Application.BusinessLogic.KensaKeikaku.PrintJokasoMemoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJokasoMemoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJokasoMemoListBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 印刷データ
        /// </summary>
        KensaKeikakuDataSet.KensaKeikakuListRow[] PrintData { get; set; }

        /// <summary>
        /// 印刷データ
        /// </summary>
        KensaKeikakuDataSet.KensaKeikakuMemoTblRow[] PrintMemoData { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJokasoMemoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJokasoMemoListBLInput : BaseExcelPrintBLInputImpl, IPrintJokasoMemoListBLInput
    {
        /// <summary>
        /// 印刷データ
        /// </summary>
        public KensaKeikakuDataSet.KensaKeikakuListRow[] PrintData { get; set; }

        /// <summary>
        /// 印刷データ
        /// </summary>
        public KensaKeikakuDataSet.KensaKeikakuMemoTblRow[] PrintMemoData { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJokasoMemoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJokasoMemoListBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJokasoMemoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJokasoMemoListBLOutput : BaseExcelPrintBLOutputImpl, IPrintJokasoMemoListBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJokasoMemoListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJokasoMemoListBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJokasoMemoListBLInput, IPrintJokasoMemoListBLOutput>
    {
        #region プロパティ

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintJokasoMemoListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJokasoMemoListBusinessLogic()
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
        /// 2015/01/30  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJokasoMemoListBLOutput SetBook(IPrintJokasoMemoListBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintJokasoMemoListBLOutput output = new PrintJokasoMemoListBLOutput();

            Worksheet outputSheet = null;

            try
            {
                KensaKeikakuDataSet.KensaKeikakuListDataTable template = new KensaKeikakuDataSet.KensaKeikakuListDataTable();
                KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable templateMemo = new KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable();

                PrintHelper printObj = new PrintHelper();
                printObj.excel = new MSExcelBind(book);
                printObj.DuplicateHeader = false;
                printObj.templateSheetName = "Sheet1";

                #region ヘッダ部定義

                BaseSection header = new BaseSection();

                header.sectionRowOrigin = 0;
                header.SetPageArea(0, 0, 4, 9);

                DateTime outputDate = Boundary.Common.Common.GetCurrentTimestamp();
                header.SetFixData(outputDate, 2, 7);

                printObj.SetHeaderSection(header);
                printObj.SetHeaderData(input.PrintData);

                #endregion

                #region 明細部定義

                BaseSection detail = new BaseSection(1);

                detail.sectionRowOrigin = 4;
                detail.SetPageArea(4, 0, 20, 9);

                detail.SetNoCol(1, 0, 1);

                detail.SetMapping(template.JokasoSetchishaNmColumn.ColumnName, 0, 4);
                detail.SetMapping(template.JokasoSetchiBashoAdrColumn.ColumnName, 0, 5);

                // メモ情報、手書きメモ、予定日、検査番号
                detail.OutputRow += delegate(ExcelBind excel, DataRow row, int idxRow)
                {
                    // 検査予定日
                    {
                        string yoteiDate = string.Join("/",
                            new string[] { 
                                (string)row[template.KensaIraiKensaYoteiTsukiColumn.ColumnName]
                                ,(string)row[template.KensaIraiKensaYoteiBiColumn.ColumnName]
                            }
                            );

                        // 検査予定日出力
                        excel.CellOutput(idxRow, 3, yoteiDate);
                    }

                    // 検査番号
                    {
                        string iraiNo = string.Join("-",
                            new string[] { 
                                (string)row[template.KensaIraiHokenjoCdColumn.ColumnName]
                                ,Boundary.Common.Common.ConvertToHoshouNendoWareki((string)row[template.KensaIraiNendoColumn.ColumnName])
                                ,(string)row[template.KensaIraiRenbanColumn.ColumnName]
                            }
                            );

                        // 検査番号出力
                        excel.CellOutput(idxRow, 3, iraiNo);
                    }

                    // メモ情報組立
                    {
                        var memo = from memoRow in input.PrintMemoData
                                   where memoRow.JokasoMemoJokasoHokenjoCd == (string)row[template.JokasoHokenjoCdColumn.ColumnName]
                                   && memoRow.JokasoMemoJokasoTorokuNendo == (string)row[template.JokasoTorokuNendoColumn.ColumnName]
                                   && memoRow.JokasoMemoJokasoRenban == (string)row[template.JokasoRenbanColumn.ColumnName]
                                   select memoRow;

                        StringBuilder memoBuf = new StringBuilder();

                        foreach (var memoRow in memo)
                        {
                            memoBuf.AppendLine(memoRow.Memo);
                        }

                        // メモ情報出力
                        excel.CellOutput(idxRow, 6, memoBuf.ToString());
                    }

                    // 手書きメモ
                    {
                        StringBuilder memoBuf = new StringBuilder();

                        memoBuf.AppendLine((string)row[template.JokasoTegakiMemoColumn.ColumnName]);
                        memoBuf.AppendLine((string)row[template.JokasoTegakiMemo2Column.ColumnName]);

                        // 手書きメモ出力
                        excel.CellOutput(idxRow, 7, memoBuf.ToString());
                    }
                };

                printObj.SetDetailSection(detail);
                printObj.SetDetailData(input.PrintData);

                #endregion

                // 出力実行
                printObj.Output();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (outputSheet != null)
                {
                    Marshal.ReleaseComObject(outputSheet);
                }
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
