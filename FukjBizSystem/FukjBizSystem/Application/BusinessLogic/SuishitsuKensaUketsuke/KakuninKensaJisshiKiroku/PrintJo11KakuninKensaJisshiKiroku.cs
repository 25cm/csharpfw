using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJo11KakuninKensaJisshiKirokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJo11KakuninKensaJisshiKirokuBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJo11KakuninKensaJisshiKirokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo11KakuninKensaJisshiKirokuBLInput : BaseExcelPrintBLInputImpl, IPrintJo11KakuninKensaJisshiKirokuBLInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJo11KakuninKensaJisshiKirokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJo11KakuninKensaJisshiKirokuBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJo11KakuninKensaJisshiKirokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo11KakuninKensaJisshiKirokuBLOutput : IPrintJo11KakuninKensaJisshiKirokuBLOutput
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
    //  クラス名 ： PrintJo11KakuninKensaJisshiKirokuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJo11KakuninKensaJisshiKirokuBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJo11KakuninKensaJisshiKirokuBLInput, IPrintJo11KakuninKensaJisshiKirokuBLOutput>
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
        //  コンストラクタ名 ： PrintJo11KakuninKensaJisshiKirokuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJo11KakuninKensaJisshiKirokuBusinessLogic()
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
        /// 2014/12/06  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJo11KakuninKensaJisshiKirokuBLOutput SetBook(IPrintJo11KakuninKensaJisshiKirokuBLInput input, Excel.Workbook book)
        {
            IPrintJo11KakuninKensaJisshiKirokuBLOutput output = new PrintJo11KakuninKensaJisshiKirokuBLOutput();

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
                //outputSheet.Name = "9条検査確認検査実施記録";
                outputSheet.Name = "11条検査確認検査実施記録";

                //20150115 sou Start 画面の検索処理と同じクエリを使用してデータを取得する
                //ISelectJo11KakuninKensaJisshiKirokuBySearchCondDAInput daInput = new SelectJo11KakuninKensaJisshiKirokuBySearchCondDAInput();
                //daInput.SearchCond = input.SearchCond;
                //ISelectJo11KakuninKensaJisshiKirokuBySearchCondDAOutput daOutput = new SelectJo11KakuninKensaJisshiKirokuBySearchCondDataAccess().Execute(daInput);
                IGetKakuninKensaJisshiKiroku1BySearchCondBLInput daInput = new GetKakuninKensaJisshiKiroku1BySearchCondBLInput();
                daInput.ShishoCd = input.SearchCond.ShishoCd;
                daInput.IraiUketsukeDtFrom = input.SearchCond.IraiUketsukeFromDt;
                daInput.IraiUketsukeDtTo = input.SearchCond.IraiUketsukeToDt;
                daInput.RadioChoosed = input.SearchCond.KensaKbn;
                daInput.SuishitsuIraiNoFrom = input.SearchCond.IraiNoFrom;
                daInput.SuishitsuIraiNoTo = input.SearchCond.IraiNoTo;
                daInput.Nendo = input.SearchCond.Nendo;
                // 20150121 sou Start
                daInput.kmkCdBodA = input.SearchCond.KmkCdBodA;
                daInput.kmkCdBodB = input.SearchCond.KmkCdBodB;
                daInput.kmkCdTr = input.SearchCond.KmkCdTr;
                daInput.kmkCdGaikan = input.SearchCond.KmkCdGaikan;
                daInput.kmkCdShuki = input.SearchCond.KmkCdShuki;
                daInput.kmkCdNo2n = input.SearchCond.KmkCdNo2nTeisei;
                daInput.kmkCdNo3n = input.SearchCond.KmkCdNo3nTeisei;
                daInput.kmkCdCl = input.SearchCond.KmkCdCl;
                // 20150121 sou End
                IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput daOutput = new GetKakuninKensaJisshiKiroku1BySearchCondBLOutput();
                daOutput.KakuninKensaJisshiKiroku1DT = new SelectKakuninKensaJisshiKiroku1BySearchCondDataAccess().Execute(daInput).KakuninKensaJisshiKiroku1DT;
                //20150115 sou End

                //output header
                //(1)
                CellOutput(outputSheet, 6, 1, "'" + input.SearchCond.IraiNoFrom);

                //(2)
                CellOutput(outputSheet, 6, 3, "'" + input.SearchCond.IraiNoTo);

                // 20150116 sou Start
                //for (int i = 0; i < daOutput.Jo11KakuninKensaJisshiKirokuDataTable.Count; i++)
                //{
                //    KensaDaicho11joHdrTblDataSet.Jo11KakuninKensaJisshiKirokuRow printRow = daOutput.Jo11KakuninKensaJisshiKirokuDataTable[i];
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
                //    //CellOutput(outputSheet, rowIdx, 3, printRow.ShikenkoumokuCd == shikenkoumokuCd ? (printRow.OldKekkaValue + printRow.OldKekkaNm)
                //    //    : string.Format("{0}({1}){2}", printRow.OldKekkaValue, printRow.OldKekkaOndo, printRow.OldKekkaNm));
                //    CellOutput(outputSheet, rowIdx, 3, printRow.ShikenkoumokuCd == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsOldKekkaValueNull() ? string.Empty : printRow.OldKekkaValue.ToString()))
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsOldKekkaOndoNull() ? string.Empty : printRow.OldKekkaOndo.ToString()))
                //        , printRow.OldKekkaNm)
                //        : ((printRow.IsOldKekkaValueNull() ? string.Empty : printRow.OldKekkaValue.ToString()) + printRow.OldKekkaNm));
                //    // 20141219 sou End
                //
                //    //(6)
                //    // 20141219 sou Start
                //    //CellOutput(outputSheet, rowIdx, 4, printRow.ShikenkoumokuCd == shikenkoumokuCd ? (printRow.NewKekkaValue + printRow.NewKekkaNm)
                //    //    : string.Format("{0}({1}){2}", printRow.NewKekkaValue, printRow.NewKekkaOndo, printRow.NewKekkaNm));
                //    CellOutput(outputSheet, rowIdx, 4, printRow.ShikenkoumokuCd == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsNewKekkaValueNull() ? string.Empty : printRow.NewKekkaValue.ToString()))
                //        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IsNewKekkaOndoNull() ? string.Empty : printRow.NewKekkaOndo.ToString()))
                //        , printRow.NewKekkaNm)
                //        : ((printRow.IsNewKekkaValueNull() ? string.Empty : printRow.NewKekkaValue.ToString()) + printRow.NewKekkaNm));
                //    // 20141219 sou End
                //
                //    //(7)
                //    CellOutput(outputSheet, rowIdx, 5, printRow.OldSaiyoKbn == "1" ? false : printRow.NewSaiyoKbn == "1" ? true : false);
                //
                //    //(8)
                //    CellOutput(outputSheet, rowIdx, 6, printRow.SotiNm);
                //
                //    //(9)
                //    CellOutput(outputSheet, rowIdx, 7, printRow.HukuKachoKeninKbn == "1" ? true : false);
                //
                //    //(10)
                //    CellOutput(outputSheet, rowIdx, 8, printRow.KachoKeninKbn == "1" ? true : false);
                //
                //    //(11)
                //    CellOutput(outputSheet, rowIdx, 9, printRow.YachoKinyuKakuninKbn == "1" ? true : false);
                //
                //    rowIdx++;
                //}
                for (int i = 0; i < daOutput.KakuninKensaJisshiKiroku1DT.Count; i++)
                {
                    KensaDaicho11joHdrTblDataSet.KakuninKensaJisshiKiroku1Row printRow = daOutput.KakuninKensaJisshiKiroku1DT[i];

                    if (rowIdx >= MAX_LIMIT_ROW)
                    {
                        //copy new row to end list
                        CopyRow(outputSheet, START_ROW_COPY, 1, rowIdx);

                    }

                    //// 検査区分が指定条件と一致しない場合は出力しない
                    //if(printRow.kensaKbnCol != input.SearchCond.KensaKbn)
                    //{
                    //    continue;
                    //}

                    //(3)水質検査依頼番号
                    CellOutput(outputSheet, rowIdx, 0, "'" + printRow.iraiNoCol);

                    //(4)正式名称
                    CellOutput(outputSheet, rowIdx, 1, printRow.komokuNmCol);

                    //(5)
                    CellOutput(outputSheet, rowIdx, 3, printRow.komokuCdCol == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IspH1ColNull() ? string.Empty : printRow.pH1Col.ToString()))
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.Isondo1ColNull() ? string.Empty : printRow.ondo1Col.ToString()))
                        , (printRow.Isph1KekkaNmColNull() ? string.Empty : printRow.ph1KekkaNmCol))
                        : ((printRow.IspH1ColNull() ? string.Empty : printRow.pH1Col.ToString()) 
                            + (printRow.Isph1KekkaNmColNull() ? string.Empty : printRow.ph1KekkaNmCol)));

                    //(6)
                    CellOutput(outputSheet, rowIdx, 4, printRow.komokuCdCol == shikenkoumokuCd ? string.Format("{0}({1}){2}"
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.IspH2ColNull() ? string.Empty : printRow.pH2Col.ToString()))
                        , Utility.KensaHanteiUtility.HyojiKetasuHosei(shikenkoumokuCd, (printRow.Isondo2ColNull() ? string.Empty : printRow.ondo2Col.ToString()))
                        , (printRow.Isph2KekkaNmColNull() ? string.Empty : printRow.ph2KekkaNmCol))
                        : ((printRow.IspH2ColNull() ? string.Empty : printRow.pH2Col.ToString()) 
                            + (printRow.Isph2KekkaNmColNull() ? string.Empty : printRow.ph2KekkaNmCol)));

                    //(7)
                    CellOutput(outputSheet, rowIdx, 5, printRow.saiyotipH2Col == "1" ? true : false);

                    //(8)
                    CellOutput(outputSheet, rowIdx, 6, (printRow.IskakuninKekkaSotiNmColNull() ? string.Empty :  printRow.kakuninKekkaSotiNmCol));

                    //(9)
                    CellOutput(outputSheet, rowIdx, 7, printRow.hukuKachoKeninCol == "1" ? true : false);

                    //(10)
                    CellOutput(outputSheet, rowIdx, 8, printRow.kachoKeninCol == "1" ? true : false);

                    //(11)
                    CellOutput(outputSheet, rowIdx, 9, printRow.yachoKakuninCol == "1" ? true : false);

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
