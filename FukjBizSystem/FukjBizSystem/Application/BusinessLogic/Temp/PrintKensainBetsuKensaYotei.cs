using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using FukjBizSystem.Application.Utility;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Core.Common.BusinessLogic.Print;
using Zynas.Framework.Core.Common.BusinessLogic.Print.MSExcel;

namespace FukjBizSystem.Application.BusinessLogic.Temp.PrintKensainBetsuKensaYotei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensainBetsuKensaYoteiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensainBetsuKensaYoteiBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 検査員
        /// </summary>
        string KensainCd { get; set; }

        /// <summary>
        /// 検査予定日
        /// </summary>
        DateTime KensaYoteiDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        GaikanKensaPrintDataSet.PrintKensainBetsuKensaYoteiDataTable PrintDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        GaikanKensaPrintDataSet.PrintKensainBetsuKensaYoteiMemoDataTable PrintDataTableMemo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainBetsuKensaYoteiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainBetsuKensaYoteiBLInput : BaseExcelPrintBLInputImpl, IPrintKensainBetsuKensaYoteiBLInput
    {
        /// <summary>
        /// 検査員
        /// </summary>
        public string KensainCd { get; set; }

        /// <summary>
        /// 検査予定日
        /// </summary>
        public DateTime KensaYoteiDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GaikanKensaPrintDataSet.PrintKensainBetsuKensaYoteiDataTable PrintDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GaikanKensaPrintDataSet.PrintKensainBetsuKensaYoteiMemoDataTable PrintDataTableMemo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensainBetsuKensaYoteiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensainBetsuKensaYoteiBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainBetsuKensaYoteiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainBetsuKensaYoteiBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensainBetsuKensaYoteiBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainBetsuKensaYoteiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainBetsuKensaYoteiBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensainBetsuKensaYoteiBLInput, IPrintKensainBetsuKensaYoteiBLOutput>
    {
        #region プロパティ

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensainBetsuKensaYoteiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensainBetsuKensaYoteiBusinessLogic()
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
        /// 2014/11/14  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensainBetsuKensaYoteiBLOutput SetBook(IPrintKensainBetsuKensaYoteiBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensainBetsuKensaYoteiBLOutput output = new PrintKensainBetsuKensaYoteiBLOutput();

            Worksheet outputSheet = null;

            try
            {
                PrintHelper printObj = new PrintHelper();
                printObj.excel = new MSExcelBind(book);
                printObj.DuplicateHeader = false;
                printObj.templateSheetName = "Sheet1";

                #region ヘッダ部定義

                BaseSection header = new BaseSection();

                header.sectionRowOrigin = 0;
                header.SetPageArea(0, 0, 4, 17);

                // 職員情報取得
                ShokuinMstDataSet.ShokuinMstDataTable shokuinInfo = MstUtility.ShokuinMst.GetShokuinMstByShokuinCd(input.KensainCd);

                string sishoNm = string.Empty;
                if (shokuinInfo.Count > 0)
                {
                    sishoNm = Boundary.Common.Common.GetShishoNmByShishoCd(shokuinInfo[0].ShokuinShozokuShishoCd);
                }

                header.SetFixData(sishoNm, 1, 1);

                string shokuinNm = string.Empty;
                if (shokuinInfo.Count > 0)
                {
                    shokuinNm = shokuinInfo[0].ShokuinNm;
                }

                header.SetFixData(shokuinNm, 2, 2);

                header.SetFixData(input.KensaYoteiDate, 1, 14);

                DateTime outputDate = Boundary.Common.Common.GetCurrentTimestamp();
                header.SetFixData(outputDate, 2, 14);

                printObj.SetHeaderSection(header);
                printObj.SetHeaderData(input.PrintDataTable);

                #endregion

                #region 明細部定義

                BaseSection detail = new BaseSection(2);

                detail.sectionRowOrigin = 4;
                detail.SetPageArea(4, 0, 70, 17);

                detail.SetNoCol(1, 0, 1);

                detail.SetMapping(input.PrintDataTable.JokasoChizuNendoColumn.ColumnName, 0, 2);
                detail.SetMapping(input.PrintDataTable.JokasoChizuPageNoColumn.ColumnName, 0, 3);
                detail.SetMapping(input.PrintDataTable.JokasoChizuNendo1Column.ColumnName, 1, 2);
                detail.SetMapping(input.PrintDataTable.JokasoChizuPageNo1Column.ColumnName, 1, 3);

                detail.SetMapping(input.PrintDataTable.ChikuNmColumn.ColumnName, 0, 4);
                detail.SetMapping(input.PrintDataTable.JokasoSetchishaNmColumn.ColumnName, 0, 5);
                detail.SetMapping(input.PrintDataTable.JokasoSetchiBashoAdrColumn.ColumnName, 0, 6);
                detail.SetMapping(input.PrintDataTable.JokasoRenrakusakiTelNoColumn.ColumnName, 0, 7);
                detail.SetMapping(input.PrintDataTable.ConstNmShoriColumn.ColumnName, 0, 8);
                detail.SetMapping(input.PrintDataTable.JokasoShoriTaishoJininColumn.ColumnName, 0, 9);
                detail.SetMapping(input.PrintDataTable.ConstNmHoteiColumn.ColumnName, 0, 10);
                detail.SetMapping(input.PrintDataTable.ConstNmScreeningColumn.ColumnName, 0, 11);
                // TODO 保守点検業者で良いか
                detail.SetMapping(input.PrintDataTable.GyoshaNmHoshutenkenColumn.ColumnName, 0, 12);
                // メモ情報
                detail.OutputRow += delegate(ExcelBind excel, DataRow row, int idxRow)
                {
                    // メモ情報組立
                    var memo = from memoRow in input.PrintDataTableMemo
                               where memoRow.JokasoMemoJokasoHokenjoCd == (string)row[input.PrintDataTable.JokasoHokenjoCdColumn.ColumnName]
                               && memoRow.JokasoMemoJokasoTorokuNendo == (string)row[input.PrintDataTable.JokasoTorokuNendoColumn.ColumnName]
                               && memoRow.JokasoMemoJokasoRenban == (string)row[input.PrintDataTable.JokasoRenbanColumn.ColumnName]
                               select memoRow;

                    // TODO 必要であれば、手書きメモ情報も出力する(文字数が多くなる可能性があるので、要検討 -> QA確認)

                    StringBuilder memoBuf = new StringBuilder();

                    foreach (var memoRow in memo)
                    {
                        memoBuf.AppendLine(memoRow.Memo);
                    }

                    // メモ情報出力
                    excel.CellOutput(idxRow, 13, memoBuf.ToString());
                };

                // 備考
                detail.OutputRow += delegate(ExcelBind excel, DataRow row, int idxRow)
                {
                    StringBuilder bikouBuf = new StringBuilder();

                    bikouBuf.AppendFormat("保守点検({0})", row[input.PrintDataTable.GyoshaNmHoshutenkenColumn.ColumnName]);

                    excel.CellOutput(idxRow, 14, bikouBuf.ToString());
                };

                printObj.SetDetailSection(detail);
                printObj.SetDetailData(input.PrintDataTable);

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
