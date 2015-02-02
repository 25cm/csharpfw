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

namespace FukjBizSystem.Application.BusinessLogic.Temp.PrintKentaiJujuHyou
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKentaiJujuHyouBLInput
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
    interface IPrintKentaiJujuHyouBLInput : IBaseExcelPrintBLInput
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
    //  クラス名 ： PrintKentaiJujuHyouBLInput
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
    class PrintKentaiJujuHyouBLInput : BaseExcelPrintBLInputImpl, IPrintKentaiJujuHyouBLInput
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
    //  インターフェイス名 ： IPrintKentaiJujuHyouBLOutput
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
    interface IPrintKentaiJujuHyouBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKentaiJujuHyouBLOutput
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
    class PrintKentaiJujuHyouBLOutput : BaseExcelPrintBLOutputImpl, IPrintKentaiJujuHyouBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKentaiJujuHyouBusinessLogic
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
    class PrintKentaiJujuHyouBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKentaiJujuHyouBLInput, IPrintKentaiJujuHyouBLOutput>
    {
        #region プロパティ

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKentaiJujuHyouBusinessLogic
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
        public PrintKentaiJujuHyouBusinessLogic()
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
        protected override IPrintKentaiJujuHyouBLOutput SetBook(IPrintKentaiJujuHyouBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKentaiJujuHyouBLOutput output = new PrintKentaiJujuHyouBLOutput();

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
                header.SetPageArea(0, 0, 4, 13);

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

                header.SetFixData(input.KensaYoteiDate, 1, 11);

                DateTime outputDate = Boundary.Common.Common.GetCurrentTimestamp();
                header.SetFixData(outputDate, 2, 11);

                printObj.SetHeaderSection(header);
                printObj.SetHeaderData(input.PrintDataTable);

                #endregion

                #region 明細部定義

                BaseSection detail = new BaseSection();

                detail.sectionRowOrigin = 4;
                detail.SetPageArea(4, 0, 20, 13);

                detail.SetNoCol(1, 0, 1);

                // 検体番号
                detail.SetMapping(input.PrintDataTable.SuishitsuKensaIraiNoColumn.ColumnName, 2);
                // 検査依頼番号
                // 法定区分、保健所コード、連番を連結して出力する
                detail.OutputRow += delegate(ExcelBind excel, DataRow row, int rowIdx)
                {
                    string val = string.Join(string.Empty
                        , new string[] {
                          (string)row[input.PrintDataTable.KensaIraiHoteiKbnColumn.ColumnName] 
                          ,(string)row[input.PrintDataTable.KensaIraiHokenjoCdColumn.ColumnName] 
                          ,(string)row[input.PrintDataTable.KensaIraiNendoColumn.ColumnName] 
                          ,(string)row[input.PrintDataTable.KensaIraiRenbanColumn.ColumnName] 
                    });

                    excel.CellOutput(rowIdx, 3, val);
                    // TODO バーコード出力方法検討(バーコードコントロールの実行時コピーが必要)
                };

                // 設置者名
                detail.SetMapping(input.PrintDataTable.JokasoSetchishaNmColumn.ColumnName, 4);
                // 設置場所
                detail.SetMapping(input.PrintDataTable.JokasoSetchiBashoAdrColumn.ColumnName, 5);
                // 連絡先
                detail.SetMapping(input.PrintDataTable.JokasoRenrakusakiTelNoColumn.ColumnName, 6);
                // 処理方式(単/合)
                detail.SetMapping(input.PrintDataTable.ConstNmShoriColumn.ColumnName, 7);
                // 人槽
                detail.SetMapping(input.PrintDataTable.JokasoShoriTaishoJininColumn.ColumnName, 8);
                // 検査種別
                detail.SetMapping(input.PrintDataTable.ConstNmKensaShubetsuColumn.ColumnName, 9);
                //// 検査種別
                //detail.SetMapping(input.PrintDataTable.ConstNmHoteiColumn.ColumnName, 9);
                //// スクリーニング種別
                //detail.SetMapping(input.PrintDataTable.ConstNmScreeningColumn.ColumnName, 10);
                // 依頼業者
                // TODO 保守点検業者で良いか
                detail.SetMapping(input.PrintDataTable.GyoshaNmHoshutenkenColumn.ColumnName, 11);

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
