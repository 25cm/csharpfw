using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaTanKomokuMst;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaIraishoOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKeiryoShomeiKensaIraishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKeiryoShomeiKensaIraishoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable 
        /// </summary>
        JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }

        /// <summary>
        /// InsatsuKbn 
        /// </summary>
        string InsatsuKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKeiryoShomeiKensaIraishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKeiryoShomeiKensaIraishoBLInput : BaseExcelPrintBLInputImpl, IPrintKeiryoShomeiKensaIraishoBLInput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable 
        /// </summary>
        public JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }

        /// <summary>
        /// InsatsuKbn 
        /// </summary>
        public string InsatsuKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKeiryoShomeiKensaIraishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKeiryoShomeiKensaIraishoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKeiryoShomeiKensaIraishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKeiryoShomeiKensaIraishoBLOutput : IPrintKeiryoShomeiKensaIraishoBLOutput
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
    //  クラス名 ： PrintKeiryoShomeiKensaIraishoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKeiryoShomeiKensaIraishoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKeiryoShomeiKensaIraishoBLInput, IPrintKeiryoShomeiKensaIraishoBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// printDataTable
        /// </summary>
        JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoDataTable _printDataTable;

        /// <summary>
        /// currentDt 
        /// </summary>
        DateTime _currentDt = Boundary.Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// copyCount
        /// </summary>
        int _copyCount;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKeiryoShomeiKensaIraishoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKeiryoShomeiKensaIraishoBusinessLogic()
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
        /// 2014/12/04  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKeiryoShomeiKensaIraishoBLOutput SetBook(IPrintKeiryoShomeiKensaIraishoBLInput input, Excel.Workbook book)
        {
            IPrintKeiryoShomeiKensaIraishoBLOutput output = new PrintKeiryoShomeiKensaIraishoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;

            try
            {
                string barCode = string.Empty;
                string saibanStr = string.Empty;
                string tokushuKomoku = string.Empty;
                string currentDt = Boundary.Common.Common.GetCurrentTimestamp().ToString("yyyyMMdd");
                decimal kensaRyokin = 0m;
                decimal shohizei = 0m;
                string setNm = string.Empty;
                string komokuNm = string.Empty;

                application = book.Application;
                application.DisplayAlerts = false;
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                _copyCount = input.CopyCount;

                ISelectDaichoSuishitsuKensaTanKomokuMstInfoDAInput getDaichoSuishitsuInput = new SelectDaichoSuishitsuKensaTanKomokuMstInfoDAInput();
                ISelectDaichoSuishitsuKensaTanKomokuMstInfoDAOutput getDaichoSuishitsuOutput = new SelectDaichoSuishitsuKensaTanKomokuMstInfoDataAccess().Execute(getDaichoSuishitsuInput);
                DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstRow[] daichoSuishitsuRows;

                _printDataTable = MakeDataPrint(input.KensaIraishoOutputListDataTable);

                foreach (JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoRow printRow in _printDataTable)
                {
                    for (int i = 0; i < _copyCount; i++)
                    {
                        // 2014.01.05 toyoda Modify Start
                        //tempSheet.Copy(tempSheet, Type.Missing);
                        //outputSheet = (Worksheet)book.ActiveSheet;
                        CopySheet(book, tempSheet.Index - 1, tempSheet.Index);
                        outputSheet = (Worksheet)book.Sheets[tempSheet.Index + 1];
                        // 2014.01.05 toyoda Modify End


                        if (input.InsatsuKbn == "1") //印刷区分/選択浄化槽分
                        {

                            barCode = string.Concat(new string[] {printRow.JokasoSuisitsuSishoCd.PadLeft(2, '0'),
                                                                    printRow.JokasoHokenjoCd,
                                                                    printRow.JokasoTorokuNendo,
                                                                    printRow.JokasoRenban,
                                                                    "0"
                                                                    });

                        }
                        else //case for 印刷区分/空番印刷
                        {
                            saibanStr = string.Empty;
                            barCode = CreateBarCode(printRow, saibanStr);
                        }

                        //set Sheet name
                        outputSheet.Name = barCode;

                        #region (1) ~ (10)

                        //(1)希釈倍率
                        SetShapeText(outputSheet, "bodKishakuTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsBodKishakuNull() ? "＊" + printRow.BodKishaku : string.Empty));

                        //(2)設置者氏名 
                        SetShapeText(outputSheet, "settishaNm1TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaNmNull() ? printRow.JokasoSetchishaNm : string.Empty));
                        SetShapeText(outputSheet, "settishaNm2TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaNmNull() ? printRow.JokasoSetchishaNm : string.Empty));
                        SetShapeText(outputSheet, "settishaNm3TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaNmNull() ? printRow.JokasoSetchishaNm : string.Empty));


                        if (input.InsatsuKbn == "2")
                        {
                            //(3)処理方式区分 
                            SetShapeText(outputSheet, "shoriHoshikiKbn1-1TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn1-2TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn2-1TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn2-2TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn3-1TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn3-2TextBox", string.Empty);

                            //(16)
                            SetShapeText(outputSheet, "shoriHoshikiKbn4-1TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn4-2TextBox", string.Empty);

                        }
                        else
                        {
							if (!printRow.IsJokasoShoriHosikiKbnNull())
							{
								//(3)処理方式区分 
								SetShapeText(outputSheet, printRow.JokasoShoriHosikiKbn == Utility.Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU ? "shoriHoshikiKbn1-2TextBox" : "shoriHoshikiKbn1-1TextBox", string.Empty);
								SetShapeText(outputSheet, printRow.JokasoShoriHosikiKbn == Utility.Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU ? "shoriHoshikiKbn2-2TextBox" : "shoriHoshikiKbn2-1TextBox", string.Empty);
								SetShapeText(outputSheet, printRow.JokasoShoriHosikiKbn == Utility.Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU ? "shoriHoshikiKbn3-2TextBox" : "shoriHoshikiKbn3-1TextBox", string.Empty);

								//(16)
								SetShapeText(outputSheet, printRow.JokasoShoriHosikiKbn == Utility.Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU ? "shoriHoshikiKbn4-2TextBox" : "shoriHoshikiKbn4-1TextBox", string.Empty);
							}
                        }

                        //(4)採水業者の業者名称を表示
                        SetShapeText(outputSheet, "saisuiGyoha1TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsSaisuiGyoshaNmNull() ? printRow.SaisuiGyoshaNm : string.Empty));
                        SetShapeText(outputSheet, "saisuiGyoha2TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsSaisuiGyoshaNmNull() ? printRow.SaisuiGyoshaNm : string.Empty));
                        SetShapeText(outputSheet, "saisuiGyoha3TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsSaisuiGyoshaNmNull() ? printRow.SaisuiGyoshaNm : string.Empty));

                        //(5)バーコード
                        CellOutput(outputSheet, 9, 52, barCode);

                        #region (6)台帳検査項目枝番
                        //台帳検査項目枝番
                        tokushuKomoku = string.Empty;
                        daichoSuishitsuRows = (DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstRow[])
                            getDaichoSuishitsuOutput.DaichoSuishitsuKensaTanKomokuMstDataTable.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '1' ",
                            new string[]{getDaichoSuishitsuOutput.DaichoSuishitsuKensaTanKomokuMstDataTable.JokasoHokenjoCdColumn.ColumnName,
                                printRow.JokasoHokenjoCd,
                                getDaichoSuishitsuOutput.DaichoSuishitsuKensaTanKomokuMstDataTable.JokasoTorokuNendoColumn.ColumnName,
                                printRow.JokasoTorokuNendo,
                                getDaichoSuishitsuOutput.DaichoSuishitsuKensaTanKomokuMstDataTable.JokasoRenbanColumn.ColumnName,
                                printRow.JokasoRenban,
                                getDaichoSuishitsuOutput.DaichoSuishitsuKensaTanKomokuMstDataTable.DaichoKensaSetKomokuKbnColumn.ColumnName}));

                        Utility.KeiryoShomeiUtility.GetJokasoSuishitsuTanKigoNm(printRow.JokasoHokenjoCd,
                                                                                printRow.JokasoTorokuNendo,
                                                                                printRow.JokasoRenban,
                                                                                printRow.KensaKomokuEdaban,
                                                                                out tokushuKomoku);
                        tokushuKomoku = daichoSuishitsuRows == null || daichoSuishitsuRows.Length == 0 ? tokushuKomoku + " のみ" : tokushuKomoku;
                        SetShapeText(outputSheet, "tokushuKomokuTextBox", input.InsatsuKbn == "2" ? string.Empty : tokushuKomoku);

                        #endregion

                        //(7)設置者カナ名 
                        SetShapeText(outputSheet, "settishaKanaTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaKanaNull() ? printRow.JokasoSetchishaKana : string.Empty));

                        //(8)設置者氏名 
                        SetShapeText(outputSheet, "settishaNm4TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaNmNull() ? printRow.JokasoSetchishaNm : string.Empty));

                        //(9)浄化槽設置者住所  
                        SetShapeText(outputSheet, "settishaAdrTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaAdrNull() ? printRow.JokasoSetchishaAdr : string.Empty));

                        //(10)設置者電話番号  
                        SetShapeText(outputSheet, "settishaTelTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaTelNoNull() ? printRow.JokasoSetchishaTelNo : string.Empty));

                        #endregion

                        #region (11) ~ (21)

                        //(11)浄化槽設置場所住所
                        SetShapeText(outputSheet, "settiBashoTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchiBashoAdrNull() ? printRow.JokasoSetchiBashoAdr : string.Empty));

                        //(12)採水業者の業者名称を表示
                        SetShapeText(outputSheet, "saisuiGyoha4TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsSaisuiGyoshaNmNull() ? printRow.SaisuiGyoshaNm : string.Empty));

                        #region (13)
                        //(13)
                        string kenchikuyotoText = string.Empty;
                        //建築用途 1
                        if (!string.IsNullOrEmpty(printRow.KenchikuyotoDaibunruiNm1)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm1)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoNm1)
                            )
                        {
                            kenchikuyotoText += string.Format("{0}({1}) {2} / ", printRow.KenchikuyotoDaibunruiNm1, printRow.KenchikuyotoShobunruiNm1, printRow.KenchikuyotoNm1);
                        }
                        //建築用途 2
                        if (!string.IsNullOrEmpty(printRow.KenchikuyotoDaibunruiNm2)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm2)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoNm2)
                            )
                        {
                            kenchikuyotoText += string.Format("{0}({1}) {2} / ", printRow.KenchikuyotoDaibunruiNm2, printRow.KenchikuyotoShobunruiNm2, printRow.KenchikuyotoNm2);
                        }

                        //建築用途 3
                        if (!string.IsNullOrEmpty(printRow.KenchikuyotoDaibunruiNm3)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm3)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoNm3)
                            )
                        {
                            kenchikuyotoText += string.Format("{0}({1}) {2} / ", printRow.KenchikuyotoDaibunruiNm3, printRow.KenchikuyotoShobunruiNm3, printRow.KenchikuyotoNm3);
                        }

                        //建築用途 4
                        if (!string.IsNullOrEmpty(printRow.KenchikuyotoDaibunruiNm4)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm4)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoNm4)
                            )
                        {
                            kenchikuyotoText += string.Format("{0}({1}) {2} / ", printRow.KenchikuyotoDaibunruiNm4, printRow.KenchikuyotoShobunruiNm4, printRow.KenchikuyotoNm4);
                        }

                        //建築用途 5
                        if (!string.IsNullOrEmpty(printRow.KenchikuyotoDaibunruiNm5)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm5)
                            && !string.IsNullOrEmpty(printRow.KenchikuyotoNm5)
                            )
                        {
                            kenchikuyotoText += string.Format("{0}({1}) {2} / ", printRow.KenchikuyotoDaibunruiNm5, printRow.KenchikuyotoShobunruiNm5, printRow.KenchikuyotoNm5);
                        }

                        SetShapeText(outputSheet, "kenchikuYotoTextBox", input.InsatsuKbn == "2" ? string.Empty : (!string.IsNullOrEmpty(kenchikuyotoText) ? kenchikuyotoText.Remove(kenchikuyotoText.Length - 2, 2) : string.Empty));

                        #endregion

                        //(14)メーカー業者の業者名称を表示
                        SetShapeText(outputSheet, "makerGyoshaTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsMekaGyoshaNmNull() ? printRow.MekaGyoshaNm : string.Empty));

                        //(15)型式名称 
                        SetShapeText(outputSheet, "katashikiNmTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsKatashikiNmNull() ? printRow.KatashikiNm : string.Empty));

                        //(17)処理目標水質 
                        SetShapeText(outputSheet, "shoriMokuhyoTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSyoriMokuhyoBODNull() ? printRow.JokasoSyoriMokuhyoBOD.ToString() : string.Empty));

                        //(18)処理方式名 
                        SetShapeText(outputSheet, "shoriHoshikiNmTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsShoriHoshikiNmNull() ? printRow.ShoriHoshikiNm : string.Empty));

                        //(19)処理対象人員 
                        SetShapeText(outputSheet, "shoriTaishoJininTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoShoriTaishoJininNull() ? printRow.JokasoShoriTaishoJinin.ToString() : string.Empty));

                        //(20)
                        Utility.KeiryoShomeiUtility.KeiryoshomeiKensaRyokinShukei(currentDt,
                            printRow.JokasoHokenjoCd,
                            printRow.JokasoTorokuNendo,
                            printRow.JokasoRenban,
                            printRow.KensaKomokuEdaban,
                            out kensaRyokin,
                            out shohizei);

                        SetShapeText(outputSheet, "kensaRyokinTextBox", input.InsatsuKbn == "2" ? string.Empty : (string.IsNullOrEmpty(printRow.KensaKomokuEdaban) ? string.Empty : Math.Truncate(kensaRyokin).ToString("N0")));

                        //(21)
                        Utility.KeiryoShomeiUtility.GetJokasoSuishitsuSetKomokuNm(printRow.JokasoHokenjoCd,
                            printRow.JokasoTorokuNendo,
                            printRow.JokasoRenban,
                            printRow.KensaKomokuEdaban,
                            out setNm,
                            out komokuNm);

                        SetShapeText(outputSheet, "tekiyoTextBox", input.InsatsuKbn == "2" ? string.Empty : (string.IsNullOrEmpty(printRow.KensaKomokuEdaban) ? string.Empty : string.Format("セット名：{0}\n{1}", setNm, komokuNm.TrimEnd('、'))));

                        #endregion

                        //case 印刷区分/選択浄化槽分 (34 = ON) only output 1 sheet - 1 bar code
                        if (input.InsatsuKbn == "1") break;
                    }
                }

                //delete template sheet
                if (book.Sheets.Count > 1)
                {
                    tempSheet.Delete();
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region MakeDataPrint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeDataPrint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraishoOutputDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoDataTable MakeDataPrint(JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable iraishoOutputDT)
        {
            JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoDataTable keiryoShomeiDT = new JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoDataTable();
            ISelectKeiryoShomeiKensaIraishoInfoDAInput daInput = new SelectKeiryoShomeiKensaIraishoInfoDAInput();
            ISelectKeiryoShomeiKensaIraishoInfoDAOutput daOutput = new SelectKeiryoShomeiKensaIraishoInfoDataAccess().Execute(daInput);
            JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoRow[] keiryoShomeiRows;

            foreach (JokasoDaichoMstDataSet.KensaIraishoOutputListRow iraishoRow in iraishoOutputDT)
            {
                if (string.IsNullOrEmpty(iraishoRow.selectCol) || iraishoRow.selectCol == "0") continue;

                keiryoShomeiRows = (JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoRow[])
                    daOutput.KeiryoShomeiKensaIraishoDataTable.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
                    new string[]{daOutput.KeiryoShomeiKensaIraishoDataTable.JokasoHokenjoCdColumn.ColumnName,
                                iraishoRow.JokasoHokenjoCd,
                                daOutput.KeiryoShomeiKensaIraishoDataTable.JokasoTorokuNendoColumn.ColumnName,
                                iraishoRow.JokasoTorokuNendo,
                                daOutput.KeiryoShomeiKensaIraishoDataTable.JokasoRenbanColumn.ColumnName,
                                iraishoRow.JokasoRenban}));

                if (keiryoShomeiRows != null && keiryoShomeiRows.Length > 0)
                {
                    //suishitsuKensaRows[0].BodKishaku = iraishoRow.kishakuBairitsuCol;
                    keiryoShomeiRows[0].BodKishaku = Boundary.Common.Common.GetConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_064, iraishoRow.kishakuBairitsuCol);
                    keiryoShomeiRows[0].KensaKomokuEdaban = iraishoRow.kensaKomokuEdabanCol;
                    keiryoShomeiDT.ImportRow(keiryoShomeiRows[0]);
                }
            }

            return keiryoShomeiDT;
        }
        #endregion

        #region CreateBarCode
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateBarCode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="printRow"></param>
        /// <param name="saibanStr"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CreateBarCode(JokasoDaichoMstDataSet.KeiryoShomeiKensaIraishoRow printRow, string saibanStr)
        {
            saibanStr = Utility.Saiban.GetSaibanRenban(Utility.DateUtility.GetNendo(_currentDt).ToString(), "6" + printRow.JokasoSuisitsuSishoCd, _copyCount);

            return string.Format("{0}{1}{2}0", new string[]{printRow.JokasoSuisitsuSishoCd == "1" ? "8" : printRow.JokasoSuisitsuSishoCd == "2" ? "7" : printRow.JokasoSuisitsuSishoCd == "3" ? "9" : "0",
                                                            Utility.DateUtility.GetNendo(_currentDt).ToString(),
                                                            saibanStr.PadLeft(8, '0')});
        }
        #endregion

        #endregion
    }
    #endregion
}
