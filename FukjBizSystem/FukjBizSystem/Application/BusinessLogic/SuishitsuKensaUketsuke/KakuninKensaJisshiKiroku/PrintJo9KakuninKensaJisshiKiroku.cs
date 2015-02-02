using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
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

        // 20150112 sou Start
        private string phCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
        private string gaikanCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_027);
        private string shukiCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_028);
        private string ashosanTeseiCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_030);
        private string shosanTeiseiCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_031);
        // 20150112 sou End

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
                //string shikenkoumokuCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, 
                //                                                                Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                application = book.Application;
                application.DisplayAlerts = false;

                outputSheet = (Worksheet)book.Sheets["Sheet1"];
                outputSheet.Name = "9条検査確認検査実施記録";

                //20150115 sou Start 画面の検索処理と同じクエリを使用してデータを取得する
                //ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput daInput = new SelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput();
                //daInput.SearchCond = input.SearchCond;
                //ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput daOutput = new SelectJo9KakuninKensaJisshiKirokuBySearchCondDataAccess().Execute(daInput);
                IGetKakuninKensaJisshiKiroku2BySearchCondBLInput daInput = new GetKakuninKensaJisshiKiroku2BySearchCondBLInput();
                daInput.ShishoCd = input.SearchCond.ShishoCd;
                daInput.IraiUketsukeDtFrom = input.SearchCond.IraiUketsukeFromDt;
                daInput.IraiUketsukeDtTo = input.SearchCond.IraiUketsukeToDt;
                daInput.SuishitsuIraiNoFrom = input.SearchCond.IraiNoFrom;
                daInput.SuishitsuIraiNoTo = input.SearchCond.IraiNoTo;
                daInput.Nendo = input.SearchCond.Nendo;
                // 20150121 sou Start
                daInput.kmkCdBodA = input.SearchCond.KmkCdBodA;
                daInput.kmkCdBodB = input.SearchCond.KmkCdBodB;
                daInput.kmkCdTr = input.SearchCond.KmkCdTr;
                daInput.kmkCdCl = input.SearchCond.KmkCdCl;
                daInput.kmkCdSs = input.SearchCond.KmkCdSs;
                daInput.kmkCdNh4n = input.SearchCond.KmkCdNh4n;
                daInput.kmkCdTnA = input.SearchCond.KmkCdTnA;
                daInput.kmkCdTnB = input.SearchCond.KmkCdTnB;
                daInput.kmkCdCod = input.SearchCond.KmkCdCod;
                daInput.kmkCdGaikan = input.SearchCond.KmkCdGaikan;
                daInput.kmkCdShuki = input.SearchCond.KmkCdShuki;
                daInput.kmkCdNo2n = input.SearchCond.KmkCdNo2nTeisei;
                daInput.kmkCdNo3n = input.SearchCond.KmkCdNo3nTeisei;
                // 20150121 sou End
                IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput daOutput = new GetKakuninKensaJisshiKiroku2BySearchCondBLOutput();
                daOutput.KakuninKensaJisshiKiroku2DT = new SelectKakuninKensaJisshiKiroku2BySearchCondDataAccess().Execute(daInput).KakuninKensaJisshiKiroku2DT;
                // 20150115 sou End

                //output header
                //(1)
                CellOutput(outputSheet, 6, 1, "'" + input.SearchCond.IraiNoFrom);

                //(2)
                CellOutput(outputSheet, 6, 3, "'" + input.SearchCond.IraiNoTo);

                // 20150116 sou Start 使用するクエリが変更になった事でSelect時の項目名も変わっている→各設定値の名称を変更する
                //for (int i = 0; i < daOutput.Jo9KakuninKensaJisshiKirokuDataTable.Count; i++)
                //{
                //    KensaDaicho9joHdrTblDataSet.Jo9KakuninKensaJisshiKirokuRow printRow = daOutput.Jo9KakuninKensaJisshiKirokuDataTable[i];
                //
                //    if (rowIdx >= MAX_LIMIT_ROW)
                //    {
                //        //copy new row to end list
                //        CopyRow(outputSheet, START_ROW_COPY, 1, rowIdx);
                //
                //    }
                //
                //    //(3)水質検査依頼番号
                //    CellOutput(outputSheet, rowIdx, 0, "'" + printRow.SuishitsuKensaIraiNo);
                //
                //    //(4)正式名称
                //    CellOutput(outputSheet, rowIdx, 1, printRow.SeishikiNm);
                //
                //    //(5)
                //    // 20141219 sou Start
                //    ////CellOutput(outputSheet, rowIdx, 3, printRow.ShikenkoumokuCd == shikenkoumokuCd ? (printRow.OldKekkaValue + printRow.OldKekkaNm)
                //    ////    : string.Format("{0}({1}){2}", printRow.OldKekkaValue, printRow.OldKekkaOndo, printRow.OldKekkaNm));
                //    //CellOutput(outputSheet, rowIdx, 3, printRow.ShikenkoumokuCd == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                //    //    , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsOldKekkaValueNull() ? string.Empty : printRow.OldKekkaValue.ToString()))
                //    //    , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsOldKekkaOndoNull() ? string.Empty : printRow.OldKekkaOndo.ToString()))
                //    //    , printRow.OldKekkaNm)
                //    //    : ((printRow.IsOldKekkaValueNull() ? string.Empty : printRow.OldKekkaValue.ToString()) + printRow.OldKekkaNm));
                //    if (printRow.ShikenkoumokuCd == phCd)
                //    {
                //        CellOutput(outputSheet, rowIdx, 3, string.Format("{0}({1}){2}"
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.IsOldKekkaValueNull() ? string.Empty : printRow.OldKekkaValue.ToString()))
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.IsOldKekkaOndoNull() ? string.Empty : printRow.OldKekkaOndo.ToString()))
                //        , printRow.OldKekkaNm));
                //    }
                //    else if ((printRow.ShikenkoumokuCd == gaikanCd) || (printRow.ShikenkoumokuCd == shukiCd)
                //        || (printRow.ShikenkoumokuCd == ashosanTeseiCd) || (printRow.ShikenkoumokuCd == shosanTeiseiCd))
                //    {
                //        CellOutput(outputSheet, rowIdx, 3, printRow.OldKekkaNm);
                //    }
                //    else
                //    {
                //        CellOutput(outputSheet, rowIdx, 3, (printRow.IsOldKekkaValueNull() ? string.Empty : printRow.OldKekkaValue.ToString()) + printRow.OldKekkaNm);
                //    }
                //    // 20141219 sou End
                //
                //    //(6)
                //    // 20141219 sou Start
                //    ////CellOutput(outputSheet, rowIdx, 4, printRow.ShikenkoumokuCd == shikenkoumokuCd ? (printRow.NewKekkaValue + printRow.NewKekkaNm)
                //    ////    : string.Format("{0}({1}){2}", printRow.NewKekkaValue, printRow.NewKekkaOndo, printRow.NewKekkaNm));
                //    //CellOutput(outputSheet, rowIdx, 4, printRow.ShikenkoumokuCd == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                //    //    , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsNewKekkaValueNull() ? string.Empty : printRow.NewKekkaValue.ToString()))
                //    //    , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsNewKekkaOndoNull() ? string.Empty : printRow.NewKekkaOndo.ToString()))
                //    //    , printRow.NewKekkaNm)
                //    //    : ((printRow.IsNewKekkaValueNull() ? string.Empty : printRow.NewKekkaValue.ToString()) + printRow.NewKekkaNm));
                //    if (printRow.ShikenkoumokuCd == phCd)
                //    {
                //        CellOutput(outputSheet, rowIdx, 4, string.Format("{0}({1}){2}"
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.IsNewKekkaValueNull() ? string.Empty : printRow.NewKekkaValue.ToString()))
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.IsNewKekkaOndoNull() ? string.Empty : printRow.NewKekkaOndo.ToString()))
                //        , printRow.NewKekkaNm));
                //    }
                //    else if ((printRow.ShikenkoumokuCd == gaikanCd) || (printRow.ShikenkoumokuCd == shukiCd)
                //        || (printRow.ShikenkoumokuCd == ashosanTeseiCd) || (printRow.ShikenkoumokuCd == shosanTeiseiCd))
                //    {
                //        CellOutput(outputSheet, rowIdx, 4, printRow.NewKekkaNm);
                //    }
                //    else
                //    {
                //        CellOutput(outputSheet, rowIdx, 4, (printRow.IsNewKekkaValueNull() ? string.Empty : printRow.NewKekkaValue.ToString()) + printRow.NewKekkaNm);
                //    }
                //    // 20141219 sou End
                //
                //    //(7)
                //    CellOutput(outputSheet, rowIdx, 5, printRow.OldSaiyoKbn == "1" ? false : printRow.NewSaiyoKbn == "1" ? true : false);
                //
                //    //(8)
                //    CellOutput(outputSheet, rowIdx, 6, printRow.SotiNm);
                //
                //    //(9)
                //    CellOutput(outputSheet, rowIdx, 7, printRow.KeiryoKanrishaKeninKbn == "1" ? true : false);
                //
                //    //(10)
                //    CellOutput(outputSheet, rowIdx, 8, printRow.HukuKachoKeninKbn == "1" ? true : false);
                //
                //    //(11)
                //    CellOutput(outputSheet, rowIdx, 9, printRow.KachoKeninKbn == "1" ? true : false);
                //
                //    //(12)
                //    CellOutput(outputSheet, rowIdx, 10, printRow.YachoKinyuKakuninKbn == "1" ? true : false);
                //
                //    rowIdx++;
                //}
                for (int i = 0; i < daOutput.KakuninKensaJisshiKiroku2DT.Count; i++)
                {
                    KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2Row printRow = daOutput.KakuninKensaJisshiKiroku2DT[i];

                    if (rowIdx >= MAX_LIMIT_ROW)
                    {
                        //copy new row to end list
                        CopyRow(outputSheet, START_ROW_COPY, 1, rowIdx);

                    }

                    //(3)水質検査依頼番号
                    CellOutput(outputSheet, rowIdx, 0, "'" + printRow.iraiNoCol);

                    //(4)正式名称
                    CellOutput(outputSheet, rowIdx, 1, printRow.komokuNmCol);

                    //(5)
                    if (printRow.komokuCdCol == phCd)
                    {
                        CellOutput(outputSheet, rowIdx, 3, string.Format("{0}({1}){2}"
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.IspH1ColNull() ? string.Empty : printRow.pH1Col.ToString()))
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.Isondo1ColNull() ? string.Empty : printRow.ondo1Col.ToString()))
                        , (printRow.Isph1KekkaNmColNull() ? string.Empty : printRow.ph1KekkaNmCol)));
                    }
                    else if ((printRow.komokuCdCol == gaikanCd) || (printRow.komokuCdCol == shukiCd)
                        || (printRow.komokuCdCol == ashosanTeseiCd) || (printRow.komokuCdCol == shosanTeiseiCd))
                    {
                        CellOutput(outputSheet, rowIdx, 3, (printRow.Isph1KekkaNmColNull() ? string.Empty : printRow.ph1KekkaNmCol));
                    }
                    else
                    {
                        CellOutput(outputSheet, rowIdx, 3, (printRow.IspH1ColNull() ? string.Empty : printRow.pH1Col.ToString())
                            + (printRow.Isph2KekkaNmColNull() ? string.Empty : printRow.ph1KekkaNmCol));
                    }

                    //(6)
                    if (printRow.komokuCdCol == phCd)
                    {
                        CellOutput(outputSheet, rowIdx, 4, string.Format("{0}({1}){2}"
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.IspH2ColNull() ? string.Empty : printRow.pH2Col.ToString()))
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(phCd, (printRow.Isondo2ColNull() ? string.Empty : printRow.ondo2Col.ToString()))
                        , (printRow.Isph2KekkaNmColNull() ? string.Empty : printRow.ph2KekkaNmCol)));
                    }
                    else if ((printRow.komokuCdCol == gaikanCd) || (printRow.komokuCdCol == shukiCd)
                        || (printRow.komokuCdCol == ashosanTeseiCd) || (printRow.komokuCdCol == shosanTeiseiCd))
                    {
                        CellOutput(outputSheet, rowIdx, 4, (printRow.Isph2KekkaNmColNull() ? string.Empty : printRow.ph2KekkaNmCol));
                    }
                    else
                    {
                        CellOutput(outputSheet, rowIdx, 4, (printRow.IspH2ColNull() ? string.Empty : printRow.pH2Col.ToString()) 
                            + (printRow.Isph2KekkaNmColNull() ? string.Empty : printRow.ph2KekkaNmCol));
                    }

                    //(7)
                    CellOutput(outputSheet, rowIdx, 5, printRow.saiyotipH2Col == "1" ? true : false);

                    //(8)
                    CellOutput(outputSheet, rowIdx, 6, (printRow.IskakuninKekkaSotiNmColNull() ? string.Empty : printRow.kakuninKekkaSotiNmCol));

                    //(9)
                    CellOutput(outputSheet, rowIdx, 7, printRow.keiryokanrisyaKeninCol == "1" ? true : false);

                    //(10)
                    CellOutput(outputSheet, rowIdx, 8, printRow.hukuKachoKeninCol == "1" ? true : false);

                    //(11)
                    CellOutput(outputSheet, rowIdx, 9, printRow.kachoKeninCol == "1" ? true : false);

                    //(12)
                    CellOutput(outputSheet, rowIdx, 10, printRow.yachoKakuninCol == "1" ? true : false);

                    rowIdx++;
                }
                // 20150116 sou End

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
