using System;
using System.Data;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using FukjBizSystem.Application.Utility;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Core.Common.BusinessLogic.Print;
using Zynas.Framework.Core.Common.BusinessLogic.Print.MSExcel;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Temp.PrintKentaiLabel
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKentaiLabelBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKentaiLabelBLInput : IBaseExcelPrintBLInput
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
        GaikanKensaPrintDataSet.PrintKentaiJujuHyouDataTable PrintDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKentaiLabelBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKentaiLabelBLInput : BaseExcelPrintBLInputImpl, IPrintKentaiLabelBLInput
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
        public GaikanKensaPrintDataSet.PrintKentaiJujuHyouDataTable PrintDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKentaiLabelBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKentaiLabelBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKentaiLabelBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKentaiLabelBLOutput : BaseExcelPrintBLOutputImpl, IPrintKentaiLabelBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKentaiLabelBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKentaiLabelBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKentaiLabelBLInput, IPrintKentaiLabelBLOutput>
    {
        #region プロパティ

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKentaiLabelBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKentaiLabelBusinessLogic()
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
        /// 2015/01/29  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKentaiLabelBLOutput SetBook(IPrintKentaiLabelBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKentaiLabelBLOutput output = new PrintKentaiLabelBLOutput();

            Worksheet outputSheet = null;

            try
            {
                MSExcelBind excelBind = new MSExcelBind(book);

                // 職員情報取得
                ShokuinMstDataSet.ShokuinMstDataTable shokuinInfo = MstUtility.ShokuinMst.GetShokuinMstByShokuinCd(input.KensainCd);

                string shokuinNm = string.Empty;
                if (shokuinInfo.Count > 0)
                {
                    shokuinNm = shokuinInfo[0].ShokuinNm;
                }

                const int LABEL_CNT = 6;

                // 出力分のシートをコピー
                int targetSheetCnt = input.PrintDataTable.Rows.Count % LABEL_CNT == 0 ? input.PrintDataTable.Rows.Count / LABEL_CNT : input.PrintDataTable.Rows.Count / LABEL_CNT + 1;

                for (int i = 0; i < targetSheetCnt; i++)
                {
                    excelBind.SheetCopy(excelBind.GetSheetIdx("Template"));
                }

                int sheetIdx = 1;
                int posIdx = 0;

                excelBind.SetCurrentSheet(sheetIdx);

                // 出力実行
                foreach (GaikanKensaPrintDataSet.PrintKentaiJujuHyouRow printRow in input.PrintDataTable)
                {

                    int rowBase;
                    int colBase;

                    // 出力ベース算出
                    colBase = (posIdx % 2) * 5;
                    rowBase = ((posIdx / 2) % 3) * 6;

                    excelBind.CellOutput(0 + rowBase, 1 + colBase, printRow[input.PrintDataTable.JokasoSetchishaNmColumn]);
                    // TODO 前回検査でBOD希釈倍率を標準から変更した場合、変更した倍率を使用する必要があるか?(現在は、変更した希釈倍率を保存していない)
                    excelBind.CellOutput(0 + rowBase, 3 + colBase, "*" + TypeUtility.GetString(printRow[input.PrintDataTable.ConstNmBODColumn]));

                    excelBind.CellOutput(1 + rowBase, 0 + colBase, printRow[input.PrintDataTable.ConstNmShoriColumn]);
                    excelBind.CellOutput(1 + rowBase, 2 + colBase, TypeUtility.GetString(printRow[input.PrintDataTable.JokasoShoriTaishoJininColumn]) + "人");

                    excelBind.CellOutput(3 + rowBase, 0 + colBase, input.KensaYoteiDate);
                    excelBind.CellOutput(3 + rowBase, 2 + colBase, shokuinNm);

                    string val = string.Join(string.Empty
                        , new string[] {
                          (string)printRow[input.PrintDataTable.KensaIraiHoteiKbnColumn.ColumnName] 
                          ,(string)printRow[input.PrintDataTable.KensaIraiHokenjoCdColumn.ColumnName] 
                          ,(string)printRow[input.PrintDataTable.KensaIraiNendoColumn.ColumnName] 
                          ,(string)printRow[input.PrintDataTable.KensaIraiRenbanColumn.ColumnName] 
                    });

                    excelBind.CellOutput(4 + rowBase, 0 + colBase, val);

                    posIdx++;

                    // シート切替判定
                    if (posIdx == LABEL_CNT)
                    {
                        posIdx = 0;
                        sheetIdx++;
                        excelBind.SetCurrentSheet(sheetIdx);
                    }
                }

                // テンプレートを削除
                excelBind.SheetDelete(excelBind.GetSheetIdx("Template"));

                // 表示シートを1枚目とする
                excelBind.SetDispSheet(0);

                // 全シートを選択(印刷対象として)
                excelBind.SelectAllSheet();
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
