using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.KekkashoPreviewTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaKekkaShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  HuyTX　    新規作成
    /// 2014/11/28  HuyTX　    Add param
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaKekkaShoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn 
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd 
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo 
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban 
        /// </summary>
        string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaKekkaShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaKekkaShoBLInput : BaseExcelPrintBLInputImpl, IPrintKensaKekkaShoBLInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn 
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd 
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo 
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban 
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaKekkaShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaKekkaShoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaKekkaShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaKekkaShoBLOutput : IPrintKensaKekkaShoBLOutput
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
    //  クラス名 ： PrintKensaKekkaShoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaKekkaShoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensaKekkaShoBLInput, IPrintKensaKekkaShoBLOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// COUNT_TIME_OUTPUT 
        /// </summary>
        private const int COUNT_TIME_OUTPUT = 5;

        /// <summary>
        /// mokuhyoSuishitsu 
        /// </summary>
        private int _mokuhyoSuishitsu = 0;

        /// <summary>
        /// scale1
        /// </summary>
        private int _scale1 = 0;

        /// <summary>
        /// scale2
        /// </summary>
        private int _scale2 = 0;

        /// <summary>
        /// scale3
        /// </summary>
        private int _scale3 = 0;

        /// <summary>
        /// scale4
        /// </summary>
        private int _scale4 = 0;

        /// <summary>
        /// scale5
        /// </summary>
        private int _scale5 = 0;

        /// <summary>
        /// SCALE1_LEFT_PIXEL
        /// </summary>
        private const int SCALE1_LEFT_PIXEL = 626;

        /// <summary>
        /// SCALE2_LEFT_PIXEL
        /// </summary>
        private const int SCALE2_LEFT_PIXEL = 704;

        /// <summary>
        /// SCALE3_LEFT_PIXEL
        /// </summary>
        private const int SCALE3_LEFT_PIXEL = 797;

        /// <summary>
        /// SCALE4_LEFT_PIXEL
        /// </summary>
        private const int SCALE4_LEFT_PIXEL = 909;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensaKekkaShoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensaKekkaShoBusinessLogic()
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
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensaKekkaShoBLOutput SetBook(IPrintKensaKekkaShoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensaKekkaShoBLOutput output = new PrintKensaKekkaShoBLOutput();

            Worksheet tempSheet = null;
            Worksheet outputSheet = null;
            Worksheet imageSheet = null;
            ISelectPrintShokenKekkaListByCondDAInput getShokenKekkaDAInput;
            StringBuilder shokenContent = new StringBuilder();
            DateTime currentDateTime = DateTime.Now;
            ConstMstDataSet.ConstMstDataTable constDT = (ConstMstDataSet.ConstMstDataTable)ConstMstList.Get(FukjBizSystem.Application.Utility.Constants.ConstKbnConstanst.CONST_KBN_037);
            string group = string.Empty;

            try
            {
                tempSheet = (Worksheet)book.Sheets["設計１"];
                imageSheet = (Worksheet)book.Sheets["イメージ切替"];

                //CreateShapeOval(tempSheet, 532, 948, 23, Color.Red, Color.Black); return output;

                //get data
                ISelectPrintKensaKekkaShoInfoByCondDAInput getKekkaShoInput = new SelectPrintKensaKekkaShoInfoByCondDAInput();
                getKekkaShoInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                getKekkaShoInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                getKekkaShoInput.KensaIraiNendo = input.KensaIraiNendo;
                getKekkaShoInput.KensaIraiRenban = input.KensaIraiRenban;

                ISelectPrintKensaKekkaShoInfoByCondDAOutput getKekkaShoOutput = new SelectPrintKensaKekkaShoInfoByCondDataAccess().Execute(getKekkaShoInput);

                if (getKekkaShoOutput.PrintKensaKekkaShoInfoDataTable == null) return output;

                for (int i = 0; i < getKekkaShoOutput.PrintKensaKekkaShoInfoDataTable.Count; i++)
                {
                    outputSheet = tempSheet;
                    outputSheet.Name = "検査結果書_" + (i + 1);
                    KensaKekkaTblDataSet.PrintKensaKekkaShoInfoRow printRow = getKekkaShoOutput.PrintKensaKekkaShoInfoDataTable[i];

                    #region output suishitsu info

                    //output suishitsu info
                    OutputSuishitsuInfo(outputSheet, printRow, currentDateTime);

                    group = printRow.KensaIraiShorihoshikiKbn == "2" ? "2" : (printRow.KensaIraiShorihoshikiKbn == "3" ? "3" : "1");

                    //(42)
                    if (group == "1")
                    {
                        CopyRange(book, imageSheet.Index, 1, 2, 11, 12, outputSheet.Index, 49, 2);
                    }
                    else if (group == "2")
                    {
                        CopyRange(book, imageSheet.Index, 1, 15, 11, 12, outputSheet.Index, 49, 2);
                    }
                    else if (group == "3")
                    {
                        CopyRange(book, imageSheet.Index, 1, 28, 11, 12, outputSheet.Index, 49, 2);
                    }


                    #region (40) ~ (41) (output shoken)

                    //(40)
                    getShokenKekkaDAInput = new SelectPrintShokenKekkaListByCondDAInput();
                    getShokenKekkaDAInput.KensaIraiShokanIraiHoteiKbn = printRow.KensaIraiHoteiKbn;
                    getShokenKekkaDAInput.KensaIraiShokenIraiHokenjoCd = printRow.KensaIraiHokenjoCd;
                    getShokenKekkaDAInput.KensaIraiShokenIraiNendo = printRow.KensaIraiNendo;
                    getShokenKekkaDAInput.KensaIraiShokenIraiRenban = printRow.KensaIraiRenban;

                    ISelectPrintShokenKekkaListByCondDAOutput getShokenKekkaDAOutput = new SelectPrintShokenKekkaListByCondDataAccess().Execute(getShokenKekkaDAInput);

                    //clear ShokenKekka data
                    shokenContent.Remove(0, shokenContent.Length);
                    //exist ShokenKekka
                    if (getShokenKekkaDAOutput.PrintShokenKekkaListDataTable.Count > 0)
                    {
                        shokenContent.AppendLine();
                        //(40)
                        OutputShoken1(outputSheet, getShokenKekkaDAOutput.PrintShokenKekkaListDataTable, shokenContent);

                        //(41)
                        OutputShoken2(outputSheet, getShokenKekkaDAOutput.PrintShokenKekkaListDataTable, group);

                    }
                    else
                    {
                        //(40) case ShokenKekkaTbl not exist data
                        OutputShoken3(outputSheet, printRow);
                    }

                    //(40-2)
                    //CellOutput(outputSheet, 20, 4, getShokenKekkaDAOutput.PrintShokenKekkaListDataTable.Count > 0 ? "【文頭の数字は異常が認められる項目】" : string.Empty);
                    CellOutput(outputSheet, 20, 4, getShokenKekkaDAOutput.PrintShokenKekkaListDataTable == null || getShokenKekkaDAOutput.PrintShokenKekkaListDataTable.Count == 0 ? "【文頭の数字は異常が認められる項目】" : string.Empty);

                    #endregion

                    #endregion

                    #region output kensa komoku

                    //(43), (44)
                    //output constant info
                    OutputConstInfo(outputSheet, constDT, printRow);

                    //output kensa komoku
                    OutputKensaKomokuKonkai(outputSheet, printRow);

                    //output kensakomoku of last time
                    OutputKensaKomokuZenkai(outputSheet, printRow);

                    //(45)
                    CellOutput(outputSheet, 58, 31, printRow.KensaKekkaHoshuTenkenKirokuUmu);
                    CellOutput(outputSheet, 59, 31, printRow.KensaKekkaTenkenKirokuHozon);
                    CellOutput(outputSheet, 60, 31, printRow.KensaKekkaHoshuTenkenKaisu);
                    CellOutput(outputSheet, 58, 36, printRow.KensaKekkaSeisoKirokuUmu);
                    CellOutput(outputSheet, 59, 36, printRow.KensaKekkaSeisoNaiyo);
                    CellOutput(outputSheet, 60, 36, printRow.KensaKekkaSeisoKaisu);

                    #endregion

                }

                if (book.Sheets.Count > 1 && imageSheet != null)
                {
                    imageSheet.Delete();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (tempSheet != null)
                {
                    Marshal.ReleaseComObject(tempSheet);
                }

                if (outputSheet != null)
                {
                    Marshal.ReleaseComObject(outputSheet);
                }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region OutputKensaKomokuKonkai
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputKensaKomokuKonkai
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputKensaKomokuKonkai(Worksheet outputSheet, KensaKekkaTblDataSet.PrintKensaKekkaShoInfoRow printRow)
        {
            //水素イオン濃度 
            CellOutput(outputSheet, 71, 57, printRow.KensaKekkaSuisoIonNodo);

            //水素イオン濃度ー判定
            CellOutput(outputSheet, 71, 59, printRow.KensaKekkaSuisoIonNodoHantei);

            //汚泥沈殿率 
            CellOutput(outputSheet, 72, 57, printRow.KensaKekkaOdeiChindenritsu);

            //汚泥沈殿率ー判定 
            CellOutput(outputSheet, 72, 59, printRow.KensaKekkaOdeiChindenritsuHantei);

            //溶存酸素量
            CellOutput(outputSheet, 73, 57, printRow.KensaKekkaYozonSansoryo);

            //溶存酸素量ー判定 
            CellOutput(outputSheet, 73, 59, printRow.KensaKekkaYozonSansoryoHantei);

            //塩素イオン濃度 
            CellOutput(outputSheet, 74, 57, printRow.KensaKekkaEnsoIonNodo);

            //塩素イオン濃度ー判定
            CellOutput(outputSheet, 74, 59, printRow.KensaKekkaEnsoIonNodoHantei);

            //透視度２次処理水 
            CellOutput(outputSheet, 75, 57, printRow.KensaKekkaToshido2jiSyorisui);

            //透視度ー判定２次処理水
            CellOutput(outputSheet, 75, 59, printRow.KensaKekkaToshidoHantei2jiSyorisui);

            //透視度 
            CellOutput(outputSheet, 76, 57, printRow.KensaKekkaToshido);

            //透視度ー判定 
            CellOutput(outputSheet, 76, 59, printRow.KensaKekkaToshidoHantei);

            //残留塩素濃度 
            CellOutput(outputSheet, 77, 57, printRow.KensaKekkaZanryuEnsoNodo);

            //残留塩素濃度ー判定
            CellOutput(outputSheet, 77, 59, printRow.KensaKekkaZanryuEnsoNodoHantei);

            //生物化学酸素要求量 
            CellOutput(outputSheet, 78, 57, printRow.KensaKekkaBOD);

            //生物化学酸素要求量ー判定
            CellOutput(outputSheet, 78, 59, printRow.KensaKekkaBODHantei);

            //(44)BODkonkaiValueTextbox
            SetShapeText(outputSheet, "BODkonkaiValueTextbox", string.Format("{0}㎎/ℓ", printRow.KensaKekkaBOD));

            //create BODKonkaiCircle
            float kensaKekkaBOD = 0;
            Color circleColor = (float.TryParse(printRow.KensaKekkaBOD, out kensaKekkaBOD) && kensaKekkaBOD > _mokuhyoSuishitsu) ? Color.Blue : Color.Red;

            //DeleteShape(outputSheet, "BODKonkaiCircle");
            CreateBODCircle(outputSheet, 948, 23, circleColor, kensaKekkaBOD);

        }
        #endregion

        #region OutputKensaKomokuZenkai
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputKensaKomokuZenkai
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="kensaKekkaShoRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputKensaKomokuZenkai(Worksheet outputSheet, KensaKekkaTblDataSet.PrintKensaKekkaShoInfoRow kensaKekkaShoRow)
        {
            ISelectPrintKensaKomokuInfoByKensaZenkaiDAInput daInput = new SelectPrintKensaKomokuInfoByKensaZenkaiDAInput();
            daInput.KensaIraiZenkaiHoteiKbn = kensaKekkaShoRow.KensaIraiZenkaiHoteiKbn;
            daInput.KensaIraiZenkaiHokenjoCd = kensaKekkaShoRow.KensaIraiZenkaiHokenjoCd;
            daInput.KensaIraiZenkaiNendo = kensaKekkaShoRow.KensaIraiZenkaiNendo;
            daInput.KensaIraiZenkaiRenban = kensaKekkaShoRow.KensaIraiZenkaiRenban;
            ISelectPrintKensaKomokuInfoByKensaZenkaiDAOutput daOutput = new SelectPrintKensaKomokuInfoByKensaZenkaiDataAccess().Execute(daInput);

            if (daOutput.PrintKensaKomokuInfoDataTable == null || daOutput.PrintKensaKomokuInfoDataTable.Count == 0) return;

            int colIdx = 60;
            KensaKekkaTblDataSet.PrintKensaKomokuInfoRow kensaKomokuRow = daOutput.PrintKensaKomokuInfoDataTable[0];

            //pH
            CellOutput(outputSheet, 71, colIdx, kensaKomokuRow.KensaKekkaSuisoIonNodo);

            //汚泥沈殿率(％)
            CellOutput(outputSheet, 72, colIdx, kensaKomokuRow.KensaKekkaOdeiChindenritsu);

            //溶存酸素量(mg/ℓ)
            CellOutput(outputSheet, 73, colIdx, kensaKomokuRow.KensaKekkaYozonSansoryo);

            //塩化物イオン濃度(mg/ℓ)
            CellOutput(outputSheet, 74, colIdx, kensaKomokuRow.KensaKekkaEnsoIonNodo);

            //透視度２次処理水 
            CellOutput(outputSheet, 75, colIdx, kensaKomokuRow.KensaKekkaToshido2jiSyorisui);

            //透視度 放流水
            CellOutput(outputSheet, 76, colIdx, kensaKomokuRow.KensaKekkaToshido);

            //残留塩素濃度(mg/ℓ)
            CellOutput(outputSheet, 77, colIdx, kensaKomokuRow.KensaKekkaZanryuEnsoNodo);

            //ＢＯＤ(mg/ℓ)
            CellOutput(outputSheet, 78, colIdx, kensaKomokuRow.KensaKekkaBOD);

            //(44)BODZenkaiValueTextbox
            SetShapeText(outputSheet, "BODZenkaiValueTextbox", string.Format("{0}㎎/ℓ", kensaKomokuRow.KensaKekkaBOD));

            //create BODZenkaiCircle
            float kensaKekkaBOD;
            //DeleteShape(outputSheet, "BODZenkaiCircle");
            CreateBODCircle(outputSheet, 980, 15, Color.White, (float.TryParse(kensaKomokuRow.KensaKekkaBOD, out kensaKekkaBOD) ? kensaKekkaBOD : 0));
        }
        #endregion

        #region OutputConstInfo
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputConstInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="constDT"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputConstInfo(Worksheet outputSheet, ConstMstDataSet.ConstMstDataTable constDT, KensaKekkaTblDataSet.PrintKensaKekkaShoInfoRow printRow)
        {
            if (constDT.Count == 0) return;

            string ph = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                        FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001))[0]).ConstValue;
            string odeiChindenRitsu = "－";
            string yozonSansoRyo = "－";
            string enkabutsuionNodo = "－";
            string toshido = "－";
            string zanryuEnsoNodo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                        FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_501))[0]).ConstValue;
            string bod = "－";
            int bodShoriSeino = 0;

            if (printRow.KensaIraiShorihoshikiKbn == "1")
            {
                //(範囲)汚泥沈殿率(％)
                odeiChindenRitsu = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_101))[0]).ConstValue;

                //(範囲)溶存酸素量(mg/ℓ)
                yozonSansoRyo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_201))[0]).ConstValue;

                //(範囲)塩化物イオン濃度(mg/ℓ)
                enkabutsuionNodo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_301))[0]).ConstValue;

                //透視度（度）
                toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_401))[0]).ConstValue;

                //(範囲)ＢＯＤ(mg/ℓ)
                bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_601))[0]).ConstValue;

                _mokuhyoSuishitsu = 90;
                _scale1 = 1;
                _scale2 = 10;
                _scale3 = 90;
                _scale4 = 1000;
                _scale5 = 8100;

            }
            else if (printRow.KensaIraiShorihoshikiKbn == "2" || printRow.KensaIraiShorihoshikiKbn == "3")
            {
                //(範囲)汚泥沈殿率(％)
                odeiChindenRitsu = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_102))[0]).ConstValue;

                //(範囲)溶存酸素量(mg/ℓ)
                yozonSansoRyo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_202))[0]).ConstValue;

                //透視度（度）
                //if (Int32.TryParse(printRow.KensaIraiBODShoriSeino, out bodShoriSeino))
                {
                    // 2015.01.09 toyoda Modify Start
                    // BOD処理性能がEmptyの時はゼロとして扱う（TryParseに失敗した場合、outにはゼロが返却される）
                    Int32.TryParse(printRow.KensaIraiBODShoriSeino, out bodShoriSeino);
                    // 2015.01.09 toyoda Modify End

                    if (bodShoriSeino <= 20)
                    {
                        //透視度（度）
                        toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                                FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_402))[0]).ConstValue;

                        //(範囲)ＢＯＤ(mg/ℓ)
                        bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                            FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_602))[0]).ConstValue;

                        //mokuhyoSuishitsu = "20";
                        _mokuhyoSuishitsu = 20;
                        _scale1 = 1;
                        _scale2 = 5;
                        _scale3 = 20;
                        _scale4 = 100;
                        _scale5 = 400;

                    }
                    else if (bodShoriSeino <= 30)
                    {
                        //透視度（度）
                        toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                                FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_403))[0]).ConstValue;

                        //(範囲)ＢＯＤ(mg/ℓ)
                        bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                            FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_603))[0]).ConstValue;

                        //mokuhyoSuishitsu = "30";
                        _mokuhyoSuishitsu = 30;
                        _scale1 = 1;
                        _scale2 = 5;
                        _scale3 = 30;
                        _scale4 = 150;
                        _scale5 = 900;
                    }
                    else if (bodShoriSeino <= 60)
                    {
                        //透視度（度）
                        toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                                FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_404))[0]).ConstValue;

                        //(範囲)ＢＯＤ(mg/ℓ)
                        bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                            FukjBizSystem.Application.Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_604))[0]).ConstValue;

                        //mokuhyoSuishitsu = "60";
                        _mokuhyoSuishitsu = 60;
                        _scale1 = 1;
                        _scale2 = 10;
                        _scale3 = 60;
                        _scale4 = 500;
                        _scale5 = 3600;
                    }
                }
            }

            //(範囲)pH
            CellOutput(outputSheet, 71, 62, ph);

            //(範囲)汚泥沈殿率(％)
            CellOutput(outputSheet, 72, 62, odeiChindenRitsu);

            //(範囲)溶存酸素量(mg/ℓ)
            CellOutput(outputSheet, 73, 62, yozonSansoRyo);

            //(範囲)塩化物イオン濃度(mg/ℓ)
            CellOutput(outputSheet, 74, 62, enkabutsuionNodo);

            //(範囲)透視度（度）
            CellOutput(outputSheet, 75, 62, toshido);

            //(範囲)残留塩素濃度(mg/ℓ)
            CellOutput(outputSheet, 77, 62, zanryuEnsoNodo);

            //(範囲)ＢＯＤ(mg/ℓ)
            CellOutput(outputSheet, 78, 62, bod);

            if (Int32.TryParse(printRow.KensaIraiBODShoriSeino, out bodShoriSeino) && bodShoriSeino > 60 && bodShoriSeino <= 120)
            {
                _scale1 = 1;
                _scale2 = 10;
                _scale3 = 120;
                _scale4 = 1500;
                _scale5 = 15000;
            }

            //(44)BODMokuhyoTextBox
            SetShapeText(outputSheet, "BODMokuhyoTextBox", string.Format("ＢＯＤ 目標水質 {0} ㎎/ℓ", _mokuhyoSuishitsu));
            
            SetShapeText(outputSheet, "Scale1TextBox", _scale1.ToString());
            SetShapeText(outputSheet, "Scale2TextBox", _scale2.ToString());
            SetShapeText(outputSheet, "Scale3TextBox", _scale3.ToString());
            SetShapeText(outputSheet, "Scale4TextBox", _scale4.ToString());
            //SetShapeText(outputSheet, "Scale5TextBox", _scale5.ToString());

        }
        #endregion

        #region OutputSuishitsuInfo
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputSuishitsuInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printRow"></param>
        /// <param name="currentDateTime"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputSuishitsuInfo(Worksheet outputSheet, KensaKekkaTblDataSet.PrintKensaKekkaShoInfoRow printRow, DateTime currentDateTime)
        {
            #region (1) ~ (28)

            //(1)
            SetShapeText(outputSheet, "SettisyaZipNoTextBox", !string.IsNullOrEmpty(printRow.KensaIraiSetchishaZipCd) ? string.Format("〒{0}", printRow.KensaIraiSetchishaZipCd) : string.Empty);

            //(2)
            SetShapeText(outputSheet, "SettisyaAdrTextBox", printRow.KensaIraiSetchishaAdr);

            //(3)
            SetShapeText(outputSheet, "SettisyaNmTextBox", printRow.KensaIraiSetchishaNm);

            //(4)
            CellOutput(outputSheet, 6, 2, string.Format("送付先 {0}", printRow.KensaIraiSofusakiNm));

            //(5)
            SetShapeText(outputSheet, "KensaJoTextBox", printRow.KensaIraiHoteiKbn == "1" ? "７" : "１１");

            //(6)
            SetShapeText(outputSheet, "UketukeDtTextBox", !string.IsNullOrEmpty(printRow.UketukeDt) ? Utility.DateUtility.ConvertToWareki(printRow.UketukeDt, "yy年MM月dd日") : string.Empty);

            //(7)
            SetShapeText(outputSheet, "KensaDtTextBox", !string.IsNullOrEmpty(printRow.KensaDt) ? Utility.DateUtility.ConvertToWareki(printRow.KensaDt, "yy年MM月dd日") : string.Empty);

            //(8)
            CellOutput(outputSheet, 0, 22, Utility.DateUtility.ConvertToWareki(currentDateTime.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

            //(9)
            SetShapeText(outputSheet, "JimukyokuAdrTextBox", printRow.JimukyokuHoteiKanriAdr);

            //(10)
            SetShapeText(outputSheet, "JimukyokuTelNoTextBox", !string.IsNullOrEmpty(printRow.JimukyokuTelNo) ? string.Format("TEL {0}", printRow.JimukyokuTelNo) : string.Empty);

            //(11)
            SetShapeText(outputSheet, "KyokaiNoTextBox", !printRow.IsKensaIraiKekkashoInsatsuCntNull() && printRow.KensaIraiKekkashoInsatsuCnt > 0 
                ? string.Format("{0}-{1}", printRow.KyokaiNo, printRow.KensaIraiKekkashoInsatsuCnt) 
                : printRow.KyokaiNo);

            //(12)
            SetShapeText(outputSheet, "SettisyaNoTextBox", printRow.JokasoNo);

            //(13)
            SetShapeText(outputSheet, "KensaTantoshaNmTextBox", printRow.KensaIraiKensaTantoshaNm);

            //(14)
            CellOutput(outputSheet, 7, 4, printRow.KensaIraiSetchishaNm);

            //(15)
            CellOutput(outputSheet, 8, 4, printRow.KensaIraiShisetsuNm);

            //(16)
            CellOutput(outputSheet, 9, 4, printRow.KensaIraiSetchibashoAdr);

            //(17)
            CellOutput(outputSheet, 10, 4, printRow.MakerGyoshaNm);

            //(18)
            CellOutput(outputSheet, 11, 4, printRow.KojiGyoshaNm);

            //(19)
            CellOutput(outputSheet, 12, 4, printRow.HoshuGyoshaNm);

            //(20)
            CellOutput(outputSheet, 13, 4, printRow.SeisoGyoshaNm);

            //(21), (22)
            //CellOutput(outputSheet, 14, 4, string.Format("{0} {1}", printRow.KensaIraiShorihoshikiKbnValue, printRow.ShoriHoshikiNm));
            //(21)
            CellOutput(outputSheet, 14, 4, printRow.KensaIraiShorihoshikiKbnValue);

            //(22)
            CellOutput(outputSheet, 14, 5, printRow.ShoriHoshikiNm);

            //(23)
            CellOutput(outputSheet, 7, 16, printRow.HokenjoNm);

            //(24)
            CellOutput(outputSheet, 7, 21, string.Format("受理No. {0}", printRow.HokenjoJyuriNo));

            //(25)
            CellOutput(outputSheet, 8, 16, !string.IsNullOrEmpty(printRow.KensaIraiBODShoriSeino) ? string.Format("{0} mg/ℓ以下", printRow.KensaIraiBODShoriSeino) : string.Empty);

            //(26)
            CellOutput(outputSheet, 9, 16, printRow.JokasoJokasoKumitateKbn == "1" ? "工場生産" : (printRow.JokasoJokasoKumitateKbn == "2" ? "現場打ち" : string.Empty));

            //(27)
            CellOutput(outputSheet, 9, 22, printRow.KatashikiNm);

            //(28)
            //CellOutput(outputSheet, 10, 16, printRow.KensaIraiKokujiNo);
            CellOutput(outputSheet, 10, 16, printRow.KensaIraiKokujiKbn == "1"
                ? string.Format("告示外 {0}", printRow.KensaIraiNinteiNo)
                : string.Format("告示第 {0}-{1}", printRow.KensaIraiKokujiNendo, printRow.KensaIraiKokujiNo));

            #endregion

            #region (29) ~ (33)

            //(29) ~ (33)
            if (!string.IsNullOrEmpty(printRow.KensaIraiTatemonoYoto))
            {
                //(29)
                CellOutput(outputSheet, 11, 16, printRow.KensaIraiTatemonoYotoValue);
            }
            else
            {
                //(29)
                CellOutput(outputSheet, 11, 16, string.Format("{0} {1}", printRow.KenchikuyotoDaibunruiNm1, !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm1) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm1) : string.Empty));
                CellOutput(outputSheet, 12, 16, printRow.KenchikuyotoNm1);

                //(30)
                CellOutput(outputSheet, 11, 18, string.Format("{0} {1}", printRow.KenchikuyotoDaibunruiNm2, !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm2) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm2) : string.Empty));
                CellOutput(outputSheet, 12, 18, printRow.KenchikuyotoNm2);

                //(31)
                CellOutput(outputSheet, 11, 20, string.Format("{0} {1}", printRow.KenchikuyotoDaibunruiNm3, !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm3) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm3) : string.Empty));
                CellOutput(outputSheet, 12, 20, printRow.KenchikuyotoNm3);

                //(32)
                CellOutput(outputSheet, 11, 22, string.Format("{0} {1}", printRow.KenchikuyotoDaibunruiNm4, !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm4) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm4) : string.Empty));
                CellOutput(outputSheet, 12, 22, printRow.KenchikuyotoNm4);

                //(33)
                CellOutput(outputSheet, 11, 24, string.Format("{0} {1}", printRow.KenchikuyotoDaibunruiNm5, !string.IsNullOrEmpty(printRow.KenchikuyotoShobunruiNm5) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm5) : string.Empty));
                CellOutput(outputSheet, 12, 24, printRow.KenchikuyotoNm5);
            }

            #endregion

            #region (34) ~ (39)

            //(34)
            CellOutput(outputSheet, 13, 16, printRow.KensaIraiHoryusakiCdValue);

            //(35)
            CellOutput(outputSheet, 14, 16, Utility.DateUtility.ConvertToWareki(printRow.ShiyoKaishiDt, "yy年MM月dd日"));

            //(36)
            CellOutput(outputSheet, 14, 22, Utility.DateUtility.ConvertToWareki(printRow.SetchiDt, "yy年MM月dd日"));

            //(37)
            CellOutput(outputSheet, 15, 16, printRow.KensaIraiShoritaishoJinin);

            //(38)
            CellOutput(outputSheet, 15, 22, printRow.KensaIraiJitsushiyoJinin);

            //(39)
            //CellOutput(outputSheet, 17, 4, printRow.KensaKekkaHanteiValue);
            CellOutput(outputSheet, 17, 4, printRow.KensaKekkaHantei == "1" ? "適正です。"
                : (printRow.KensaKekkaHantei == "2" ? "おおむね適正です。"
                : (printRow.KensaKekkaHantei == "3" ? "不適正 です。" : string.Empty)));

            #endregion
        }
        #endregion

        #region OutputShoken1
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputShoken1
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="shokenKekkaDT"></param>
        /// <param name="shokenContent"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputShoken1(Worksheet outputSheet, ShokenKekkaTblDataSet.PrintShokenKekkaListDataTable shokenKekkaDT, StringBuilder shokenContent)
        {
            for (int j = 0; j < shokenKekkaDT.Count; j++)
            {
                ShokenKekkaTblDataSet.PrintShokenKekkaListRow currentShokenRow = shokenKekkaDT[j];
                ShokenKekkaTblDataSet.PrintShokenKekkaListRow previousShokenRow = shokenKekkaDT[(j > 0 ? j : 1) - 1];
                
                string shokenKbn = string.Empty;

                if (!string.IsNullOrEmpty(currentShokenRow.ShokenKbn.Trim()) &&
                    ((currentShokenRow.ShokenKbn != previousShokenRow.ShokenKbn) || j == 0))
                {
                    shokenKbn = string.Format("【{0}】", currentShokenRow.ShokenKbn.Substring(currentShokenRow.ShokenKbn.Length - 2, 2));
                }
                else if (string.IsNullOrEmpty(currentShokenRow.ShokenKbn.Trim()) || currentShokenRow.ShokenKbn == previousShokenRow.ShokenKbn)
                {
                    shokenKbn = "      ";
                }

                shokenContent.AppendLine(string.Format("{0}{1} {2}",
                //shokenContent.AppendLine(string.Format("{0}・{1} {2}",
                new string[] { shokenKbn, 
                                //currentShokenRow.ShokenCd, 
                                currentShokenRow.ShokenWd, 
                                currentShokenRow.ShokenTegaki }));
            }

            SetShapeText(outputSheet, "SyoenTextBox", shokenContent.ToString());
        }
        #endregion

        #region OutputShoken2
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputShoken2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="shokenKekkaDT"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputShoken2(Worksheet outputSheet, ShokenKekkaTblDataSet.PrintShokenKekkaListDataTable shokenKekkaDT, string group)
        {
            int colIdx = 40;
            string shokenShitekiKashoNo = string.Empty;
            string shitekiTextBox = string.Empty;
            int shitekiKashoNo = 0;

            //(41)  
            for (int i = 0; i < shokenKekkaDT.Select("ShokenCheckHantei = '2' OR ShokenCheckHantei = '3'", "ShokenKbn").Length; i++)
            {
                //only output max 10 record
                if (i == 10) break;

                ShokenKekkaTblDataSet.PrintShokenKekkaListRow currentShokenRow = shokenKekkaDT[i];
                ShokenKekkaTblDataSet.PrintShokenKekkaListRow previousShokenRow = shokenKekkaDT[(i > 0 ? i : 1) - 1];

                if (!string.IsNullOrEmpty(currentShokenRow.ShokenKbn.Trim())
                    && (i == 0 || currentShokenRow.ShokenKbn != previousShokenRow.ShokenKbn))
                {
                    CellOutput(outputSheet, 64, colIdx, string.Format("【{0}】", currentShokenRow.ShokenKbn.Substring(currentShokenRow.ShokenKbn.Length - 2, 2)));
                    CellOutput(outputSheet, 65, colIdx, currentShokenRow.ShokenCheckHantei == "2" ? "△" : currentShokenRow.ShokenCheckHantei == "3" ? "×" : string.Empty);

                    #region switch ShokenShitekiKashoNo

                    if (Int32.TryParse(currentShokenRow.ShokenShitekiKashoNo, out shitekiKashoNo))
                    {
                        switch (shitekiKashoNo)
                        {
                            case 1:
                                shokenShitekiKashoNo = "①";
                                break;
                            case 2:
                                shokenShitekiKashoNo = "②";
                                break;
                            case 3:
                                shokenShitekiKashoNo = "③";
                                break;
                            case 4:
                                shokenShitekiKashoNo = "④";
                                break;
                            case 5:
                                shokenShitekiKashoNo = "⑤";
                                break;
                            case 6:
                                shokenShitekiKashoNo = "⑥";
                                break;
                            case 7:
                                shokenShitekiKashoNo = "⑦";
                                break;
                            case 8:
                                shokenShitekiKashoNo = "⑧";
                                break;
                            case 9:
                                shokenShitekiKashoNo = "⑨";
                                break;
                            case 10:
                                shokenShitekiKashoNo = "⑩";
                                break;
                            default:
                                shokenShitekiKashoNo = string.Empty;
                                break;
                        }
                    }

                    #endregion

                    CellOutput(outputSheet, 66, colIdx, shokenShitekiKashoNo);

                    colIdx++;

                    //check not found Shiteki?_?TextBox
                    if (((group == "1" || group == "2") & shitekiKashoNo == 9)
                        || (group == "3" && (shitekiKashoNo == 2 || shitekiKashoNo == 3))
                        ) continue;

                    if(!string.IsNullOrEmpty(currentShokenRow.ShokenShitekiKashoNo))
                    {
                        shitekiTextBox = string.Format("Shiteki{0}_{1}TextBox", group, currentShokenRow.ShokenShitekiKashoNo.PadLeft(2, '0'));
                        SetShapeFontColor(outputSheet, shitekiTextBox, Color.Red, 1, 1);
                    }

                }
            }
        }
        #endregion

        #region OutputShoken3
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputShoken3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="kensaKekkaShoRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputShoken3(Worksheet outputSheet, KensaKekkaTblDataSet.PrintKensaKekkaShoInfoRow kensaKekkaShoRow)
        {
            if (kensaKekkaShoRow.KensaKekkaHantei != "1") return;

            string shokenContent = string.Empty;

            if ((kensaKekkaShoRow.KensaIraiHoteiKbn == "1" || kensaKekkaShoRow.KensaIraiHoteiKbn == "2") && kensaKekkaShoRow.KensaIraiScreeningKbn == "0")
            {
                shokenContent = "・特に問題ありません。";
            }

            if (kensaKekkaShoRow.KensaIraiHoteiKbn == "3")
            {
                if (kensaKekkaShoRow.KensaIraiScreeningKbn == "0")
                {
                    shokenContent = "・水質検査の結果、特に問題ありません。";
                }
                else if (kensaKekkaShoRow.KensaIraiScreeningKbn == "1")
                {
                    shokenContent = "・水質検査の結果、水質が望ましい範囲にありませんでしたので、現場で浄化槽の稼働状況等の検査を行いました。\n（改行）\n(----実線----）\n（改行）\n・検査の結果、浄化槽の処理機能に問題はありませんでした。";
                }
                else if (kensaKekkaShoRow.KensaIraiScreeningKbn == "2")
                {
                    shokenContent = "・前回の法定検査において不適正と判定されましたので、現場において浄化槽の稼働状況等の検査を行いました。\n（改行）\n（----実線----）\n（改行）\n・特に問題ありません。（改行）\n・不適正に関する指摘事項は改善されています。";
                }
                else if (kensaKekkaShoRow.KensaIraiScreeningKbn == "3")
                {
                    shokenContent = "・前回の法定検査において不適正と判定され、今回の水質検査の結果、水質が望ましい範囲にありませんでしたので、現場において浄化槽の稼働状況等の検査を行いました。\n（改行）\n（----実線----）\n（改行）\n・特に問題ありません。（改行）\n・不適正に関する指摘事項は改善されています。";
                }

            }

            SetShapeText(outputSheet, "SyoenTextBox", shokenContent);

        }
        #endregion

        #region CreateBODCircle
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： CreateBODCircle
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="top"></param>
        /// <param name="diameter"></param>
        /// <param name="backColor"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateBODCircle(Worksheet outputSheet, float top, float diameter, Color backColor, float kensaKekkaBOD)
        {
            // 2015.01.08 toyoda Add Start
            if (kensaKekkaBOD <= 0)
            {
                // ゼロ及びマイナス(想定外)の場合は出力しない
                return;
            }
            // 2015.01.08 toyoda Add End

            float left = 0;
            float range12 = 79;
            float range23 = 94;
            float range34 = 113;
            float range45 = 91;

            if (kensaKekkaBOD >= _scale1)
            {
                left = SCALE1_LEFT_PIXEL + (range12 / (_scale2 - _scale1)) * (kensaKekkaBOD - _scale1);
            }

            if (kensaKekkaBOD >= _scale2)
            {
                left = SCALE2_LEFT_PIXEL + (range23 / (_scale3 - _scale2)) * (kensaKekkaBOD - _scale2);
            }

            if (kensaKekkaBOD >= _scale3)
            {
                left = SCALE3_LEFT_PIXEL + (range34 / (_scale4 - _scale3)) * (kensaKekkaBOD - _scale3);
            }

            if (kensaKekkaBOD >= _scale4)
            {
                left = SCALE4_LEFT_PIXEL + (range45 / (_scale5 - _scale4)) * (kensaKekkaBOD - _scale4);
            }

            // 2015.01.08 toyoda Add Start
            // pixcel→pointに変換、かつ半径point分左へシフトさせる
            left = (left / 1.333f) - (diameter / 2.0f);
            // 2015.01.08 toyoda Add End
            
            CreateShapeOval(outputSheet, left, top, diameter, backColor, Color.Black);
        }
        #endregion

        #endregion

    }
    #endregion
}
