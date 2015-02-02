using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.JisshiKirokuOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJo9KakuninKensaJisshiKirokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJo9KakuninKensaJisshiKirokuBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJo9KakuninKensaJisshiKirokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo9KakuninKensaJisshiKirokuBLInput : BaseExcelPrintBLInputImpl, IPrintJo9KakuninKensaJisshiKirokuBLInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJo9KakuninKensaJisshiKirokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJo9KakuninKensaJisshiKirokuBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJo9KakuninKensaJisshiKirokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo9KakuninKensaJisshiKirokuBLOutput : IPrintJo9KakuninKensaJisshiKirokuBLOutput
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
    //  クラス名 ： PrintJo9KakuninKensaJisshiKirokuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo9KakuninKensaJisshiKirokuBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJo9KakuninKensaJisshiKirokuBLInput, IPrintJo9KakuninKensaJisshiKirokuBLOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// MAX_LIMIT_ROW 
        /// </summary>
        private const int MAX_LIMIT_ROW = 41;

        /// <summary>
        /// START_ROW_COPY
        /// </summary>
        private const int START_ROW_COPY = 10;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintJo9KakuninKensaJisshiKirokuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJo9KakuninKensaJisshiKirokuBusinessLogic()
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
        /// 2014/12/05  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJo9KakuninKensaJisshiKirokuBLOutput SetBook(IPrintJo9KakuninKensaJisshiKirokuBLInput input, Excel.Workbook book)
        {
            IPrintJo9KakuninKensaJisshiKirokuBLOutput output = new PrintJo9KakuninKensaJisshiKirokuBLOutput();

            Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                int rowIdx = 10;
                string shikenkoumokuCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, 
                                                                                Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                application = book.Application;
                application.DisplayAlerts = false;

                outputSheet = (Worksheet)book.Sheets["Sheet1"];
                outputSheet.Name = "9条検査確認検査実施記録";

                ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput daInput = new SelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput();
                daInput.SearchCond = input.SearchCond;
                ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput daOutput = new SelectJo9KakuninKensaJisshiKirokuBySearchCondDataAccess().Execute(daInput);

                //output header
                //(1)
                CellOutput(outputSheet, 6, 1, "'" + input.SearchCond.IraiNoFrom);

                //(2)
                CellOutput(outputSheet, 6, 3, "'" + input.SearchCond.IraiNoTo);

                for (int i = 0; i < daOutput.Jo9KakuninKensaJisshiKirokuDataTable.Count; i++)
                {
                    KensaDaicho9joHdrTblDataSet.Jo9KakuninKensaJisshiKirokuRow printRow = daOutput.Jo9KakuninKensaJisshiKirokuDataTable[i];

                    if (rowIdx >= MAX_LIMIT_ROW)
                    {
                        //copy new row to end list
                        CopyRow(outputSheet, START_ROW_COPY, 1, rowIdx);

                    }

                    //(3)水質検査依頼番号
                    CellOutput(outputSheet, rowIdx, 0, "'" + printRow.SuishitsuKensaIraiNo);

                    //(4)正式名称
                    CellOutput(outputSheet, rowIdx, 1, printRow.SeishikiNm);

                    //(5)
                    // 20141219 sou Start
                    //CellOutput(outputSheet, rowIdx, 3, printRow.ShikenkoumokuCd == shikenkoumokuCd ? (printRow.OldKekkaValue + printRow.OldKekkaNm)
                    //    : string.Format("{0}({1}){2}", printRow.OldKekkaValue, printRow.OldKekkaOndo, printRow.OldKekkaNm));
                    CellOutput(outputSheet, rowIdx, 3, printRow.ShikenkoumokuCd == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, printRow.OldKekkaValue.ToString())
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, printRow.OldKekkaOndo.ToString())
                        , printRow.OldKekkaNm)
                        : (printRow.OldKekkaValue + printRow.OldKekkaNm));
                    // 20141219 sou End

                    //(6)
                    // 20141219 sou Start
                    //CellOutput(outputSheet, rowIdx, 4, printRow.ShikenkoumokuCd == shikenkoumokuCd ? (printRow.NewKekkaValue + printRow.NewKekkaNm)
                    //    : string.Format("{0}({1}){2}", printRow.NewKekkaValue, printRow.NewKekkaOndo, printRow.NewKekkaNm));
                    CellOutput(outputSheet, rowIdx, 4, printRow.ShikenkoumokuCd == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, printRow.NewKekkaValue.ToString())
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, printRow.NewKekkaOndo.ToString())
                        , printRow.NewKekkaNm)
                        : (printRow.NewKekkaValue + printRow.NewKekkaNm));
                    // 20141219 sou End

                    //(7)
                    CellOutput(outputSheet, rowIdx, 5, printRow.OldSaiyoKbn == "1" ? false : printRow.NewSaiyoKbn == "1" ? true : false);

                    //(8)
                    CellOutput(outputSheet, rowIdx, 6, printRow.SotiNm);

                    //(9)
                    CellOutput(outputSheet, rowIdx, 7, printRow.KeiryoKanrishaKeninKbn == "1" ? true : false);

                    //(10)
                    CellOutput(outputSheet, rowIdx, 8, printRow.HukuKachoKeninKbn == "1" ? true : false);

                    //(11)
                    CellOutput(outputSheet, rowIdx, 9, printRow.KachoKeninKbn == "1" ? true : false);

                    //(12)
                    CellOutput(outputSheet, rowIdx, 10, printRow.YachoKinyuKakuninKbn == "1" ? true : false);

                    rowIdx++;
                }

                //set break page
                if (rowIdx > MAX_LIMIT_ROW)
                {
                    outputSheet.HPageBreaks.Add((Range)outputSheet.Cells[rowIdx + 1, 1]);
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
