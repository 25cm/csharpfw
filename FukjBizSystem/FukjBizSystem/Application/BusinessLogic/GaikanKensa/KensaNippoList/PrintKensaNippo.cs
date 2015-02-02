using System;
using System.Globalization;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.MonitoringTbl;
using FukjBizSystem.Application.DataAccess.NippoDtlTbl;
using FukjBizSystem.Application.DataAccess.NippoHdrTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaNippoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaNippoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaNippoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// NippoKensaDt
        /// </summary>
        string NippoKensaDt { get; set; }

        /// <summary>
        /// NippoKensainCd
        /// </summary>
        string NippoKensainCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaNippoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaNippoBLInput : BaseExcelPrintBLInputImpl, IPrintKensaNippoBLInput
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
        ///// 処理後ＥＸＣＥＬ表示フラグ
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

        /// <summary>
        /// NippoKensaDt
        /// </summary>
        public string NippoKensaDt { get; set; }

        /// <summary>
        /// NippoKensainCd
        /// </summary>
        public string NippoKensainCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaNippoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaNippoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaNippoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaNippoBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensaNippoBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaNippoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaNippoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensaNippoBLInput, IPrintKensaNippoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensaNippoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensaNippoBusinessLogic()
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
        /// 2014/10/22  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensaNippoBLOutput SetBook(IPrintKensaNippoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensaNippoBLOutput output = new PrintKensaNippoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;

                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                ISelectKensaNippoPrintInfoByCondDAInput daInput = new SelectKensaNippoPrintInfoByCondDAInput();
                daInput.NippoKensaDt = input.NippoKensaDt;
                daInput.NippoKensainCd = input.NippoKensainCd;
                ISelectKensaNippoPrintInfoByCondDAOutput daOutput = new SelectKensaNippoPrintInfoByCondDataAccess().Execute(daInput);
                ISelectMonitoringTblInfoDAInput getMonitoringInput = new SelectMonitoringTblInfoDAInput();
                ISelectMonitoringTblInfoDAOutput getMonitoringOutput = new SelectMonitoringTblInfoDataAccess().Execute(getMonitoringInput);

                #region output for case not exist data in NippoDtl

                if (daOutput.KensaNippoPrintInfoDataTable.Count == 1 && string.IsNullOrEmpty(daOutput.KensaNippoPrintInfoDataTable[0].NippoDtlKensainCd))
                {
                    NippoDtlTblDataSet.KensaNippoPrintInfoRow printRow = daOutput.KensaNippoPrintInfoDataTable[0];

                    //(1)
                    CellOutput(outputSheet, 1, 2, !printRow.IsShishoNmNull() ? printRow.ShishoNm : string.Empty);

                    //(2)
                    CellOutput(outputSheet, 1, 18, !printRow.IsNippoKensaDtNull() ? printRow.NippoKensaDt : string.Empty);

                    //(3)
                    //auto fill by formulas
                    //output confirmation data
                    OutputConfirmationContent(outputSheet, printRow);

                    //(38)
                    CellOutput(outputSheet, 32, 1, !printRow.IsNippoHokokujikoNull() ? printRow.NippoHokokujiko : string.Empty);

                    //(39)
                    CellOutput(outputSheet, 33, 1, !printRow.IsNippoShijinaiyoNull() ? printRow.NippoShijinaiyo : string.Empty);

                    //(40)
                    CellOutput(outputSheet, 33, 19, !printRow.IsNippoFukukachoCheckFlgValueNull() ? printRow.NippoFukukachoCheckFlgValue : string.Empty);

                    //(41)
                    CellOutput(outputSheet, 33, 20, !printRow.IsNippoKachoCheckFlgValueNull() ? printRow.NippoKachoCheckFlgValue : string.Empty);

                    return output;
                }
                #endregion

                #region output header 

                //(1)
                CellOutput(outputSheet, 1, 2, (daOutput.KensaNippoPrintInfoDataTable != null && daOutput.KensaNippoPrintInfoDataTable.Count > 0) 
                    ? daOutput.KensaNippoPrintInfoDataTable[0].ShishoNm : string.Empty);

                //(2)
                CellOutput(outputSheet, 1, 18, (daOutput.KensaNippoPrintInfoDataTable != null && daOutput.KensaNippoPrintInfoDataTable.Count > 0) 
                    ? daOutput.KensaNippoPrintInfoDataTable[0].NippoKensaDt : string.Empty);

                #endregion

                #region output data to line 1 ~ 20

				bool summaryOutputFlg = false;	//受入20141218 add
                int rowIdx = 4;
                foreach (NippoDtlTblDataSet.KensaNippoPrintInfoRow printRow in daOutput.KensaNippoPrintInfoDataTable.Select(" NippoDtlKensaChushiFlg <> '1' "))
                {
                    #region output header & confirmation info

                    if (rowIdx == 4)
                    {
                        ////(1)
                        //CellOutput(outputSheet, 1, 2, !printRow.IsShishoNmNull() ? printRow.ShishoNm : string.Empty);

                        ////(2)
                        //CellOutput(outputSheet, 1, 18, !printRow.IsNippoKensaDtNull() ? printRow.NippoKensaDt : string.Empty);

                        //(3)
                        //auto fill by formulas
                        //output confirmation data
                        OutputConfirmationContent(outputSheet, printRow);

						summaryOutputFlg = true;	//受入20141218 add
                    }

                    #endregion

                    if (rowIdx == 24) break;

                    //output NippoDtl
                    OutputContent(outputSheet, rowIdx, printRow, getMonitoringOutput.MonitoringTblInfoDataTable);

                    rowIdx++;
                }

                #endregion

                #region output data to line 28 ~ 32

                rowIdx = 27;
                foreach (NippoDtlTblDataSet.KensaNippoPrintInfoRow printRow in daOutput.KensaNippoPrintInfoDataTable.Select(" NippoDtlKensaChushiFlg = '1' "))
                {
					//受入20141218 add sta
					if (!summaryOutputFlg)
					{
						// (19) から (36)までの集計結果は、中止かどうかに関係なく出力する。
						// 中止ではないデータの所で出力されていなければ、ここで出力。

						//(3)
						//auto fill by formulas
						//output confirmation data
						OutputConfirmationContent(outputSheet, printRow);
					}
					//受入20141218 add end

                    #region output footer

                    if (rowIdx == 27)
                    {
                        // 2014/12/11 AnhNV DEL Start
                        ////(38)
                        //CellOutput(outputSheet, 32, 1, !printRow.IsNippoHokokujikoNull() ? printRow.NippoHokokujiko : string.Empty);

                        ////(39)
                        //CellOutput(outputSheet, 33, 1, !printRow.IsNippoShijinaiyoNull() ? printRow.NippoShijinaiyo : string.Empty);
                        // 2014/12/11 AnhNV DEL End

                        // 2014/12/11 AnhNV ADD Start
                        //(38)
                        CellOutput(outputSheet, 32, 4, !printRow.IsNippoHokokujikoNull() ? printRow.NippoHokokujiko : string.Empty);

                        //(39)
                        CellOutput(outputSheet, 33, 4, !printRow.IsNippoShijinaiyoNull() ? printRow.NippoShijinaiyo : string.Empty);
                        // 2014/12/11 AnhNV ADD End

                        //(40)
                        CellOutput(outputSheet, 33, 19, !printRow.IsNippoFukukachoCheckFlgValueNull() ? printRow.NippoFukukachoCheckFlgValue : string.Empty);

                        //(41)
                        CellOutput(outputSheet, 33, 20, !printRow.IsNippoKachoCheckFlgValueNull() ? printRow.NippoKachoCheckFlgValue : string.Empty);
                    }

                    #endregion

                    if (rowIdx == 32) break;

                    //output footer data
                    OutputFooterContent(outputSheet, rowIdx, printRow);

                    rowIdx++;
                }

                #endregion

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

        #region メソッド(private)

        #region OutputContent
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputContent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="rowIdx"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  HuyTX　  新規作成
        /// 2014/11/06  HuyTX　  Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputContent(Worksheet outputSheet, int rowIdx, NippoDtlTblDataSet.KensaNippoPrintInfoRow printRow, MonitoringTblDataSet.MonitoringTblInfoDataTable monitoringDT)
        {
            //(4)
            CellOutput(outputSheet, rowIdx, 2, !printRow.IsNippoDtlKensainNmNull() ? printRow.NippoDtlKensainNm : string.Empty);

            //(5)
            CellOutput(outputSheet, rowIdx, 3, !printRow.IsNippoDtlHojoinCdNmNull() ? printRow.NippoDtlHojoinCdNm : string.Empty);

            //(6)
            CellOutput(outputSheet, rowIdx, 4, !printRow.IsNippoDtlKensaSyubetsuValueNull() ? printRow.NippoDtlKensaSyubetsuValue : string.Empty);

            //(7)
            CellOutput(outputSheet, rowIdx, 5, !printRow.IsChikuRyakushoNull() ? printRow.ChikuRyakusho : string.Empty);

            //(8)
            CellOutput(outputSheet, rowIdx, 6, !printRow.IsKensaIraiSuishitsuIraiNoNull() ? printRow.KensaIraiSuishitsuIraiNo : string.Empty);

            //(9)
            CellOutput(outputSheet, rowIdx, 7, !printRow.IsKensaIraiSetchishaNmNull() ? printRow.KensaIraiSetchishaNm : string.Empty);

            //(10)
            CellOutput(outputSheet, rowIdx, 10, !printRow.IsKensaIraiShorihoshikiKbnValueNull() ? printRow.KensaIraiShorihoshikiKbnValue : string.Empty);

            //(11)
            CellOutput(outputSheet, rowIdx, 11, !printRow.IsKensaIraiShoritaishoJininNull() ? printRow.KensaIraiShoritaishoJinin : 0);

            //Ver1.03 Start
            //(12)
            CellOutput(outputSheet, rowIdx, 12, !printRow.IsKensaKekkaKensaTimesNull() ? printRow.KensaKekkaKensaTimes.ToString() : string.Empty);
            //Ver1.03 End

            //(13)
            CellOutput(outputSheet, rowIdx, 13, !printRow.IsKensaIraiNyukinHohoKbnValueNull() ? printRow.KensaIraiNyukinHohoKbnValue : string.Empty);

            //(14)
            CellOutput(outputSheet, rowIdx, 15, (!printRow.IsNippoDtlKensaSyubetsuValueNull() && printRow.NippoDtlKensaSyubetsu == "2") ? printRow.GyoshaNm : string.Empty);

            //Ver1.03 Start
            //(15)
            CellOutput(outputSheet, rowIdx, 17, (!printRow.IsKensaKekkaZaitakuUmuNull()) ? printRow.KensaKekkaZaitakuUmu : string.Empty);

            //(16)
            string monitoringGroupNm = string.Empty;
            MonitoringTblDataSet.MonitoringTblInfoRow[] monitoringRows = (MonitoringTblDataSet.MonitoringTblInfoRow[])monitoringDT.Select(string.Format("KensaIraiHoteiKbn = '{0}' AND KensaIraiHokenjoCd = '{1}' AND KensaIraiNendo = '{2}' AND KensaIraiRenban = '{3}'",
                                                                            new string[] {printRow.NippoDtlKensaSyubetsu,
                                                                                            printRow.NippoDtlKensaIraiHokenjoCd,
                                                                                            printRow.NippoDtlKensaIraiNendo,
                                                                                            printRow.NippoDtlKensaIraiRenban,
                                                                                            }));
            monitoringGroupNm = monitoringRows.Length == 0 ? string.Empty : (monitoringRows.Length == 1 ? monitoringRows[0].MonitoringGroupNm : string.Concat(monitoringRows[0].MonitoringGroupNm, "、他"));

            CellOutput(outputSheet, rowIdx, 18, monitoringGroupNm);

            //(17)	//結合20141227 DbNull care.
            CellOutput(outputSheet, rowIdx, 19, !printRow.IsShokenIraiHoteiKbn1Null() ? (!string.IsNullOrEmpty(printRow.ShokenIraiHoteiKbn1) ? "要" : string.Empty) : String.Empty );

			//(18)	//結合20141227 DbNull care.
            CellOutput(outputSheet, rowIdx, 20, !printRow.IsShokenIraiHoteiKbn2Null() ? (!string.IsNullOrEmpty(printRow.ShokenIraiHoteiKbn2) ? "要" : string.Empty) : String.Empty );

            //Ver1.03 End
        }
        #endregion

        #region OutputConfirmationContent
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputConfirmationContent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  HuyTX　  新規作成
        /// 2014/11/06  HuyTX　  Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputConfirmationContent(Worksheet outputSheet, NippoDtlTblDataSet.KensaNippoPrintInfoRow printRow)
        {
            //(19)
            CellOutput(outputSheet, 24, 3, !printRow.IsCntHdrByYMNull() ? printRow.CntHdrByYM.ToString() : string.Empty);

            //(20)
            CellOutput(outputSheet, 25, 3, !printRow.IsCnt1Null() ? printRow.Cnt1.ToString() : string.Empty);

            //(21)
            CellOutput(outputSheet, 26, 3, !printRow.IsNippoHdrAvgNull() ? printRow.NippoHdrAvg.ToString() : string.Empty);

            //(22)
            CellOutput(outputSheet, 24, 5, !printRow.IsCntDtlByYMNull() ? printRow.CntDtlByYM.ToString() : string.Empty);

            //(23)
            CellOutput(outputSheet, 25, 5, !printRow.IsCntDtlByMNull() ? printRow.CntDtlByM.ToString() : string.Empty);

            //(24) auto fill by formulas

            //(25)
            CellOutput(outputSheet, 24, 8, !printRow.IsNippoSokoKyoriNull() ? printRow.NippoSokoKyori.ToString() : string.Empty);

            //(26)
            CellOutput(outputSheet, 25, 8, !printRow.IsCntNippoSokoKyoriByYMNull() ? printRow.CntNippoSokoKyoriByYM.ToString() : string.Empty);

            //(27)
            CellOutput(outputSheet, 26, 8, !printRow.IsCntNippoSokoKyoriByMNull() ? printRow.CntNippoSokoKyoriByM.ToString() : string.Empty);

            //(28)
            CellOutput(outputSheet, 24, 12, !printRow.IsNippoKyuyuNull() ? printRow.NippoKyuyu.ToString() : string.Empty);

            //(29)
            CellOutput(outputSheet, 25, 12, CalcNenpi(printRow.NippoKensainCd, printRow.OrginalNippoKensaDt));

            //(30)
            CellOutput(outputSheet, 26, 12, !printRow.IsCntNippoKyuyuByMNull() ? printRow.CntNippoKyuyuByM.ToString() : string.Empty);

            //Ver1.03 Start
            //(31) 
            CellOutput(outputSheet, 24, 16, !printRow.IsKensaKekkaKensaTimesByKensaDtNull() ? printRow.KensaKekkaKensaTimesByKensaDt.ToString() : string.Empty);

            //(32) 
            CellOutput(outputSheet, 25, 16, !printRow.IsKensaKekkaKensaTimesByKensainCdNull() ? printRow.KensaKekkaKensaTimesByKensainCd.ToString() : string.Empty);
            //Ver1.03 End

            //(33)
            CellOutput(outputSheet, 26, 16, !printRow.IsNippoCrosscheckKensuNull() ? printRow.NippoCrosscheckKensu.ToString() : string.Empty);

            //(34)
            CellOutput(outputSheet, 24, 19, !printRow.IsNippoJitchichosaKensuNull() ? printRow.NippoJitchichosaKensu.ToString() : string.Empty);

            //(35)
            CellOutput(outputSheet, 25, 19, !printRow.IsNippoChokageninchosaKensuNull() ? printRow.NippoChokageninchosaKensu.ToString() : string.Empty);

            //(36)
            CellOutput(outputSheet, 26, 19, !printRow.IsNippoSharyoTenkenKirokuNull() ? printRow.NippoSharyoTenkenKiroku.ToString() : string.Empty);
        }
        #endregion

        #region OutputFooterContent
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputFooterContent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="rowIdx"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputFooterContent(Worksheet outputSheet, int rowIdx, NippoDtlTblDataSet.KensaNippoPrintInfoRow printRow)
        {
            //(4)
            CellOutput(outputSheet, rowIdx, 2, !printRow.IsNippoDtlKensainNmNull() ? printRow.NippoDtlKensainNm : string.Empty);

            //(5)
            CellOutput(outputSheet, rowIdx, 3, !printRow.IsNippoDtlHojoinCdNmNull() ? printRow.NippoDtlHojoinCdNm : string.Empty);

            //(6)
            CellOutput(outputSheet, rowIdx, 4, !printRow.IsNippoDtlKensaSyubetsuValueNull() ? printRow.NippoDtlKensaSyubetsuValue : string.Empty);

            //(7)
            CellOutput(outputSheet, rowIdx, 5, !printRow.IsChikuRyakushoNull() ? printRow.ChikuRyakusho : string.Empty);

            //(8)
            CellOutput(outputSheet, rowIdx, 6, !printRow.IsKensaIraiSuishitsuIraiNoNull() ? printRow.KensaIraiSuishitsuIraiNo : string.Empty);

            //(9)
            CellOutput(outputSheet, rowIdx, 7, !printRow.IsKensaIraiSetchishaNmNull() ? printRow.KensaIraiSetchishaNm : string.Empty);

            //(10)
            CellOutput(outputSheet, rowIdx, 10, !printRow.IsKensaIraiShorihoshikiKbnValueNull() ? printRow.KensaIraiShorihoshikiKbnValue : string.Empty);

            //(11)
            CellOutput(outputSheet, rowIdx, 11, !printRow.IsKensaIraiShoritaishoJininNull() ? printRow.KensaIraiShoritaishoJinin : 0);

            // 20141218 habu column became not null
            //(37)
            CellOutput(outputSheet, rowIdx, 17, printRow.NippoDtlKensaChushiRiyu);
            //CellOutput(outputSheet, rowIdx, 17, !printRow.IsNippoDtlKensaChushiRiyuNull() ? printRow.NippoDtlKensaChushiRiyu : string.Empty);
        }
        #endregion

        #region CalcNenpi
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CalcNenpi
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nippoKensainCd"></param>
        /// <param name="nippoKensaDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CalcNenpi(string nippoKensainCd, string nippoKensaDt)
        {
            string nenpi = string.Empty;

            // Get NippoHdrTbl by NippoKensainCd
            ISelectNippoHdrTblByNippoKensainCdDAInput nInput = new SelectNippoHdrTblByNippoKensainCdDAInput();
            nInput.NippoKensainCd = nippoKensainCd;
            ISelectNippoHdrTblByNippoKensainCdDAOutput nOutput = new SelectNippoHdrTblByNippoKensainCdDataAccess().Execute(nInput);

            if (nOutput.NippoHdrTblDataTable != null && nOutput.NippoHdrTblDataTable.Count > 0)
            {
                string defaultNendo = Utility.DateUtility.GetNendo(DateTime.ParseExact(nippoKensaDt, "yyyyMMdd", CultureInfo.InvariantCulture)) + "0401";

                // 指定検査員の全ての検査日報ヘッダから、当年度分かつ過去分かつ給油有りのデータを検査日の降順で取得する
                NippoHdrTblDataSet.NippoHdrTblRow[] hdrRow
                    = (NippoHdrTblDataSet.NippoHdrTblRow[])nOutput.NippoHdrTblDataTable
                        .Select(string.Format("NippoKensaDt >= '{0}' AND NippoKensaDt < '{1}' AND NippoKyuyu > 0", defaultNendo, nippoKensaDt), "NippoKensaDt DESC");

                if (hdrRow.Length == 0 || hdrRow[0].IsNippoKyuyuNull())
                {
                    // 直近の給油実績無しの場合、燃費は計算しない。
                    return nenpi;
                }

                // Get the last 1st NippoKensaDt
                string last1stDt = hdrRow[0].NippoKensaDt;    //直近の給油日

                // 前回給油時点の、年度内総走行距離
                object zenkaiSokoKyori = nOutput.NippoHdrTblDataTable.Compute(
                    "SUM(NippoSokoKyori)", string.Format("NippoKensaDt >= '{0}' AND NippoKensaDt <= '{1}'", defaultNendo, last1stDt));

                // 今回の年度内総走行距離
                object konkaiSokoKyori = nOutput.NippoHdrTblDataTable.Compute(
                    "SUM(NippoSokoKyori)", string.Format("NippoKensaDt >= '{0}' AND NippoKensaDt <= '{1}'", defaultNendo, nippoKensaDt));

                // 前回の年度内総給油量
                object zenkaiKyuyuTotal = nOutput.NippoHdrTblDataTable.Compute(
                    "SUM(NippoKyuyu)", string.Format("NippoKensaDt >= '{0}' AND NippoKensaDt <= '{1}'", defaultNendo, last1stDt));

                // 今回の年度内総給油量
                object konkaiKyuyuTotal = nOutput.NippoHdrTblDataTable.Compute(
                    "SUM(NippoKyuyu)", string.Format("NippoKensaDt >= '{0}' AND NippoKensaDt <= '{1}'", defaultNendo, nippoKensaDt));

                decimal zenkaiKmTotal = 0;
                decimal konkaiKmTotal = 0;
                decimal zenkaiLiTotal = 0;
                decimal konkaiLiTotal = 0;

                if(zenkaiSokoKyori != null)
                {    // 前回給油時点での総走行距離
                    zenkaiKmTotal = !string.IsNullOrEmpty(zenkaiSokoKyori.ToString()) ? Convert.ToDecimal(zenkaiSokoKyori) : 0;
                }

                if (konkaiSokoKyori != null)
                {    // 今回の総走行距離（今回は給油の有無は問わない）
                    konkaiKmTotal = !string.IsNullOrEmpty(konkaiSokoKyori.ToString()) ? Convert.ToDecimal(konkaiSokoKyori) : 0;
                }

                if (zenkaiKyuyuTotal != null)
                {    // 前回給油時点での、総給油量
                    zenkaiLiTotal = !string.IsNullOrEmpty(zenkaiKyuyuTotal.ToString()) ? Convert.ToDecimal(zenkaiKyuyuTotal) : 0;
                }

                if (konkaiKyuyuTotal != null)
                {    // 今回の総給油量（今回は給油の有無は問わない）
                    konkaiLiTotal = !string.IsNullOrEmpty(konkaiKyuyuTotal.ToString()) ? Convert.ToDecimal(konkaiKyuyuTotal) : 0;
                }

                //燃費は、前回給油時点から今回までの走行距離　÷　前回給油時点から今回までの給油量
                if ((konkaiLiTotal - zenkaiLiTotal) > 0)
                {    // 今回が給油有りで、前回からの総給油量に差異がある場合　Last to Current
                    nenpi = ((konkaiKmTotal - zenkaiKmTotal) / (konkaiLiTotal - zenkaiLiTotal)).ToString("N1");
                }
                else
                {
                    // 差異が無い（前回給油時点から総給油量に変化が無い）場合は、前回給油時点の燃費を継続して表示する 2ndLast to Last

                    // Get the last 2nd NippoKensaDt
                    // 今回を除いた給油有りの検査日報ヘッダから、前々回の日付を取得する。
                    if (hdrRow.Length > 1)
                    {    // 前々回の検査日報ヘッダが存在する場合

                        string last2ndDt = hdrRow[1].NippoKensaDt;    // 前々回の検査日

                        // 前々回給油時点の、年度内総走行距離
                        object zenzenkaiSokoKyori = nOutput.NippoHdrTblDataTable.Compute(
                            "SUM(NippoSokoKyori)", string.Format("NippoKensaDt >= '{0}' AND NippoKensaDt <= '{1}'", defaultNendo, last2ndDt));

                        // 前々回の年度内総給油量
                        object zenzenkaiKyuyuTotal = nOutput.NippoHdrTblDataTable.Compute(
                            "SUM(NippoKyuyu)", string.Format("NippoKensaDt >= '{0}' AND NippoKensaDt <= '{1}'", defaultNendo, last2ndDt));

                        decimal zenzenkaiKmTotal = 0;
                        decimal zenzenkaiLiTotal = 0;

                        if (zenzenkaiSokoKyori != null)
                        {    // 前々回給油時点での総走行距離
                            zenzenkaiKmTotal = !string.IsNullOrEmpty(zenzenkaiSokoKyori.ToString()) ? Convert.ToDecimal(zenzenkaiSokoKyori) : 0;
                        }

                        if (zenzenkaiKyuyuTotal != null)
                        {    // 前々回給油時点での、総給油量
                            zenzenkaiLiTotal = !string.IsNullOrEmpty(zenzenkaiKyuyuTotal.ToString()) ? Convert.ToDecimal(zenzenkaiKyuyuTotal) : 0;
                        }

                        if ((zenkaiLiTotal - zenzenkaiLiTotal) > 0)
                        {
                            nenpi = ((zenkaiKmTotal - zenzenkaiKmTotal) / (zenkaiLiTotal - zenzenkaiLiTotal)).ToString("N1");    // 前回給油時点での燃費
                        }
                        else
                        {
                            nenpi = string.Empty;    // zero division or minus
                        }

                    }
                    else
                    {    // 前々回の給油有り検査日報ヘッダが存在しない場合
                        nenpi = string.Empty;    // not exists 2ndLast
                    }
                }
            }

            return nenpi;
        }
        #endregion

        #endregion

    }
    #endregion
}
