using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaIraishoOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJokasoSuishitsuKensaIraishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJokasoSuishitsuKensaIraishoBLInput : IBaseExcelPrintBLInput
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
    //  クラス名 ： PrintJokasoSuishitsuKensaIraishoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJokasoSuishitsuKensaIraishoBLInput : BaseExcelPrintBLInputImpl, IPrintJokasoSuishitsuKensaIraishoBLInput
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
    //  インターフェイス名 ： IPrintJokasoSuishitsuKensaIraishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJokasoSuishitsuKensaIraishoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJokasoSuishitsuKensaIraishoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJokasoSuishitsuKensaIraishoBLOutput : IPrintJokasoSuishitsuKensaIraishoBLOutput
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
    //  クラス名 ： PrintJokasoSuishitsuKensaIraishoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJokasoSuishitsuKensaIraishoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJokasoSuishitsuKensaIraishoBLInput, IPrintJokasoSuishitsuKensaIraishoBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// printDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoDataTable _printDataTable;

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
        //  コンストラクタ名 ： PrintJokasoSuishitsuKensaIraishoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJokasoSuishitsuKensaIraishoBusinessLogic()
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
        /// 2014/12/03  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJokasoSuishitsuKensaIraishoBLOutput SetBook(IPrintJokasoSuishitsuKensaIraishoBLInput input, Excel.Workbook book)
        {
            IPrintJokasoSuishitsuKensaIraishoBLOutput output = new PrintJokasoSuishitsuKensaIraishoBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;

            try
            {
                decimal kensaRyokin = 0m;
                string barCode = string.Empty;
                string saibanStr = string.Empty;

                application = book.Application;
                application.DisplayAlerts = false;
                tempSheet = (Worksheet)book.Sheets["Sheet1"];
                _copyCount = input.CopyCount;

                _printDataTable = MakeDataPrint(input.KensaIraishoOutputListDataTable);

                foreach (JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoRow printRow in _printDataTable)
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


                        if (input.InsatsuKbn == "2")
                        {
                            //(3)処理方式区分 
                            SetShapeText(outputSheet, "shoriHoshikiKbn1-1TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn1-2TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn2-1TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn2-2TextBox", string.Empty);

                            //(18)
                            SetShapeText(outputSheet, "shoriHoshikiKbn3-1TextBox", string.Empty);
                            SetShapeText(outputSheet, "shoriHoshikiKbn3-2TextBox", string.Empty);

                        }
                        else
                        {
							if (!printRow.IsJokasoShoriHosikiKbnNull())
							{
								//(3)処理方式区分 
								SetShapeText(outputSheet, printRow.JokasoShoriHosikiKbn == Utility.Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU ? "shoriHoshikiKbn1-2TextBox" : "shoriHoshikiKbn1-1TextBox", string.Empty);
								SetShapeText(outputSheet, printRow.JokasoShoriHosikiKbn == Utility.Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU ? "shoriHoshikiKbn2-2TextBox" : "shoriHoshikiKbn2-1TextBox", string.Empty);

								//(18)
								SetShapeText(outputSheet, printRow.JokasoShoriHosikiKbn == Utility.Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU ? "shoriHoshikiKbn3-2TextBox" : "shoriHoshikiKbn3-1TextBox", string.Empty);
							}
                        }

                        //(4)採水業者の業者名称を表示
                        SetShapeText(outputSheet, "saisuiGyoha1TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsSaisuiGyoshaNmNull() ? printRow.SaisuiGyoshaNm : string.Empty));
                        SetShapeText(outputSheet, "saisuiGyoha2TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsSaisuiGyoshaNmNull() ? printRow.SaisuiGyoshaNm : string.Empty));

                        //(5)バーコード
						CellOutput(outputSheet, 9, 52, barCode);

                        //(6)
                        SetShapeText(outputSheet, "uketsukeYearTextBox", string.Empty);
                        SetShapeText(outputSheet, "uketsukeMonthTextBox", string.Empty);
                        SetShapeText(outputSheet, "uketsukeDayTextBox", string.Empty);

                        //(7)設置者カナ名 
                        SetShapeText(outputSheet, "settishaKanaTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaKanaNull() ? printRow.JokasoSetchishaKana : string.Empty));

                        //(8)設置者氏名 
                        SetShapeText(outputSheet, "settishaNm3TextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaNmNull() ? printRow.JokasoSetchishaNm : string.Empty));

                        //(9)浄化槽設置者住所  
                        SetShapeText(outputSheet, "settishaAdrTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaAdrNull() ? printRow.JokasoSetchishaAdr : string.Empty));

                        //(10)設置者電話番号  
                        SetShapeText(outputSheet, "settishaTelTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchishaTelNoNull() ? printRow.JokasoSetchishaTelNo : string.Empty));

                        #endregion

                        #region (11) ~ (23)

                        //(11)浄化槽設置場所住所
                        SetShapeText(outputSheet, "settiBashoTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoSetchiBashoAdrNull() ? printRow.JokasoSetchiBashoAdr : string.Empty));

                        //(12)外観地区割区分
                        SetShapeText(outputSheet, "gaikanChikuTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoGaikanTikuwariKbnNull() ? printRow.JokasoGaikanTikuwariKbn : string.Empty));

                        //(13)保守点検業者の業者名称を表示
                        SetShapeText(outputSheet, "hoshuGyoshaTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsHoshuGyoshaNmNull() ? printRow.HoshuGyoshaNm : string.Empty));

                        //(14)清掃業者の業者名称を表示
                        SetShapeText(outputSheet, "seisoGyoshaTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsSeisouGyoshaNmNull() ? printRow.SeisouGyoshaNm : string.Empty));

                        #region (15)
                        //(15)
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

                        //(16)メーカー業者の業者名称を表示
                        SetShapeText(outputSheet, "makerGyoshaTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsMekaGyoshaNmNull() ? printRow.MekaGyoshaNm : string.Empty));

                        //(17)型式名称 
                        SetShapeText(outputSheet, "katashikiNmTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsKatashikiNmNull() ? printRow.KatashikiNm : string.Empty));

                        //(19)処理方式種別名 
                        SetShapeText(outputSheet, "shoriHoshikiShubetsuTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsShoriHoshikiShubetsuNmNull() ? printRow.ShoriHoshikiShubetsuNm : string.Empty));

                        //(20)処理方式名 
                        SetShapeText(outputSheet, "shoriHoshikiNmTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsShoriHoshikiNmNull() ? printRow.ShoriHoshikiNm : string.Empty));

                        //(21)処理対象人員 
                        SetShapeText(outputSheet, "shoriTaishoJininTextBox", input.InsatsuKbn == "2" ? string.Empty : (!printRow.IsJokasoShoriTaishoJininNull() ? printRow.JokasoShoriTaishoJinin.ToString() : string.Empty));

                        //(22)
                        kensaRyokin = Utility.HoteiKensaUtility.GetHoteiKensaRyokin(printRow.JokasoHokenjoCd, printRow.JokasoTorokuNendo, printRow.JokasoRenban, Utility.Constants.KensaShubetsuConstant.KENSA_SHUBETSU_2);
                        SetShapeText(outputSheet, "kensaRyokinTextBox", input.InsatsuKbn == "2" ? string.Empty : (kensaRyokin != 0 ? Math.Truncate(kensaRyokin).ToString("N0") : string.Empty));

                        //(23)none

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
        /// 2014/12/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoDataTable MakeDataPrint(JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable iraishoOutputDT)
        {
            JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoDataTable jokasoSuishitsuKensaIraishoDT = new JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoDataTable();
            ISelectJokasoSuishitsuKensaIraishoInfoDAInput daInput = new SelectJokasoSuishitsuKensaIraishoInfoDAInput();
            ISelectJokasoSuishitsuKensaIraishoInfoDAOutput daOutput = new SelectJokasoSuishitsuKensaIraishoInfoDataAccess().Execute(daInput);
            JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoRow[] suishitsuKensaRows;

            foreach (JokasoDaichoMstDataSet.KensaIraishoOutputListRow iraishoRow in iraishoOutputDT)
            {
                if (string.IsNullOrEmpty(iraishoRow.selectCol) || iraishoRow.selectCol == "0") continue;

                suishitsuKensaRows = (JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoRow[])
                    daOutput.JokasoSuishitsuKensaIraishoDataTable.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
                    new string[]{daOutput.JokasoSuishitsuKensaIraishoDataTable.JokasoHokenjoCdColumn.ColumnName,
                                iraishoRow.JokasoHokenjoCd,
                                daOutput.JokasoSuishitsuKensaIraishoDataTable.JokasoTorokuNendoColumn.ColumnName,
                                iraishoRow.JokasoTorokuNendo,
                                daOutput.JokasoSuishitsuKensaIraishoDataTable.JokasoRenbanColumn.ColumnName,
                                iraishoRow.JokasoRenban}));

                if (suishitsuKensaRows != null && suishitsuKensaRows.Length > 0)
                {
                    //suishitsuKensaRows[0].BodKishaku = iraishoRow.kishakuBairitsuCol;
                    suishitsuKensaRows[0].BodKishaku = Boundary.Common.Common.GetConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_064, iraishoRow.kishakuBairitsuCol);
                    jokasoSuishitsuKensaIraishoDT.ImportRow(suishitsuKensaRows[0]);
                }
            }

            return jokasoSuishitsuKensaIraishoDT;
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
        private string CreateBarCode(JokasoDaichoMstDataSet.JokasoSuishitsuKensaIraishoRow printRow, string saibanStr)
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
