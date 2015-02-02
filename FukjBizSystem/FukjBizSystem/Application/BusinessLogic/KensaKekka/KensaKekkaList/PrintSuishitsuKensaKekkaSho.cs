using System;
using System.Runtime.InteropServices;
using System.Text;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.ShokenKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.KensaKekka.KensaKekkaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSuishitsuKensaKekkaShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSuishitsuKensaKekkaShoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// InsatsuKbn
        /// </summary>
        string InsatsuKbn { get; set; }

        /// <summary>
        /// IsOutputPages 
        /// </summary>
        bool IsOutputPages { get; set; }

        /// <summary>
        /// SuishitsuKensaKekkaInfoDataTable
        /// </summary>
        KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable SuishitsuKensaKekkaInfoDataTable { get; set; }

        /// <summary>
        /// PageNumbers
        /// </summary>
        int PageNumbers { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSuishitsuKensaKekkaShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuishitsuKensaKekkaShoBLInput : BaseExcelPrintBLInputImpl, IPrintSuishitsuKensaKekkaShoBLInput
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
        /// InsatsuKbn
        /// </summary>
        public string InsatsuKbn { get; set; }

        /// <summary>
        /// IsOutputPages 
        /// </summary>
        public bool IsOutputPages { get; set; }

        /// <summary>
        /// SuishitsuKensaKekkaInfoDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable SuishitsuKensaKekkaInfoDataTable { get; set; }

        /// <summary>
        /// PageNumbers
        /// </summary>
        public int PageNumbers { get; set; }

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSuishitsuKensaKekkaShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSuishitsuKensaKekkaShoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSuishitsuKensaKekkaShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuishitsuKensaKekkaShoBLOutput : BaseExcelPrintBLOutputImpl, IPrintSuishitsuKensaKekkaShoBLOutput
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
    //  クラス名 ： PrintSuishitsuKensaKekkaShoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSuishitsuKensaKekkaShoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintSuishitsuKensaKekkaShoBLInput, IPrintSuishitsuKensaKekkaShoBLOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// COUNT_TIME_OUTPUT 
        /// </summary>
        private const int COUNT_TIME_OUTPUT = 5;

        /// <summary>
        /// TOSHIDO_CHART_NAME 
        /// </summary>
        private const string TOSHIDO_CHART_NAME = "グラフ 8";

        /// <summary>
        /// BOD_CHART_NAME 
        /// </summary>
        private const string BOD_CHART_NAME = "グラフ 17";

        /// <summary>
        /// maxScaleToshido 
        /// </summary>
        private double _maxScaleToshido = 0;

        /// <summary>
        /// baseLinePosToshido 
        /// </summary>
        private int _baseLinePosToshido = 0;

        /// <summary>
        /// maxScaleBOD
        /// </summary>
        private double _maxScaleBOD = 0;

        /// <summary>
        /// baseLinePosBOD
        /// </summary>
        private int _baseLinePosBOD = 0;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSuishitsuKensaKekkaShoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSuishitsuKensaKekkaShoBusinessLogic()
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
        /// 2014/10/14  HuyTX　    新規作成
        /// 2014/11/11  HuyTX　    Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintSuishitsuKensaKekkaShoBLOutput SetBook(IPrintSuishitsuKensaKekkaShoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintSuishitsuKensaKekkaShoBLOutput output = new PrintSuishitsuKensaKekkaShoBLOutput();

            //Worksheet tempSheet1 = null;
            //Worksheet tempSheet2 = null;
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet tempSheet = null;
            Worksheet outputSheet = null;
            ISelectShokenKekkaListByCondDAInput getShokenKekkaDAInput;
            StringBuilder shokenContent = new StringBuilder();
            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
            //ShokenKekkaTblDataSet.ShokenKekkaListDataTable ShokenKekkaListDataTable = new ShokenKekkaTblDataSet.ShokenKekkaListDataTable();
            ConstMstDataSet.ConstMstDataTable constDT = (ConstMstDataSet.ConstMstDataTable)Boundary.Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_037);

            try
            {
                //DEL_Ver1.07 Start
                //tempSheet1 = (Worksheet)book.Sheets["Template1"];
                //tempSheet2 = (Worksheet)book.Sheets["Template2"];
                //tempSheet = input.InsatsuKbn == "1" ? tempSheet1 : tempSheet2;
                //DEL_Ver1.07 End
                application = book.Application;
                application.DisplayAlerts = false;
                tempSheet = (Worksheet)book.Sheets["設計１"];

                if (input.SuishitsuKensaKekkaInfoDataTable == null) return output;

                for (int i = 0; i < input.SuishitsuKensaKekkaInfoDataTable.Count; i++)
                {
                    //MOD_Ver1.07 Start
                    //if (input.InsatsuKbn == "1")
                    //{
                    //    tempSheet1.Copy(tempSheet1, Type.Missing);
                    //}
                    //else
                    //{
                    //    tempSheet2.Copy(tempSheet2, Type.Missing);
                    //}

                    //tempSheet.Copy(tempSheet, Type.Missing);
                    //outputSheet = (Worksheet)book.ActiveSheet;
                    outputSheet = tempSheet;
                    outputSheet.Name = "水質検査結果書_" + (i + 1);
                    KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoRow printRow = input.SuishitsuKensaKekkaInfoDataTable[i];
                    //MOD_Ver1.07 End

                    #region output suishitsu info

                    //output suishitsu info
                    OutputSuishitsuInfo(outputSheet, printRow, currentDateTime);

                    #region (40) ~ (41) (output shoken)

                    //(40)
                    getShokenKekkaDAInput = new SelectShokenKekkaListByCondDAInput();
                    getShokenKekkaDAInput.KensaIraiShokanIraiHoteiKbn = printRow.KensaIraiHoteiKbn;
                    getShokenKekkaDAInput.KensaIraiShokenIraiHokenjoCd = printRow.KensaIraiHokenjoCd;
                    getShokenKekkaDAInput.KensaIraiShokenIraiNendo = printRow.KensaIraiNendo;
                    getShokenKekkaDAInput.KensaIraiShokenIraiRenban = printRow.KensaIraiRenban;

                    ISelectShokenKekkaListByCondDAOutput getShokenKekkaDAOutput = new SelectShokenKekkaListByCondDataAccess().Execute(getShokenKekkaDAInput);

                    //clear ShokenKekka data
                    shokenContent.Remove(0, shokenContent.Length);
                    //exist ShokenKekka
                    if (getShokenKekkaDAOutput.ShokenKekkaListDataTable.Count > 0)
                    {
                        shokenContent.AppendLine();
                        for (int j = 0; j < getShokenKekkaDAOutput.ShokenKekkaListDataTable.Count; j++)
                        {
                            ShokenKekkaTblDataSet.ShokenKekkaListRow currentShokenRow = getShokenKekkaDAOutput.ShokenKekkaListDataTable[j];
                            ShokenKekkaTblDataSet.ShokenKekkaListRow previousShokenRow = getShokenKekkaDAOutput.ShokenKekkaListDataTable[(j > 0 ? j : 1) - 1];

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

                            // 20150111 habu 「・」は付与しない（データ側で付与されているものをそのまま使用）
                            shokenContent.AppendLine(string.Format("{0}{1} {2}",
                            //shokenContent.AppendLine(string.Format("{0}・{1} {2}",
                                new string[] { shokenKbn, 
                                            //currentShokenRow.ShokenCd, 
                                            currentShokenRow.ShokenWd, 
                                            currentShokenRow.ShokenTegaki }));
                        }

                        SetShapeText(outputSheet, "SyoenTextBox", shokenContent.ToString());
                    }

                    //(41)
                    //CellOutput(outputSheet, 20, 4, getShokenKekkaDAOutput.ShokenKekkaListDataTable.Count > 0 ? "【文頭の数字は異常が認められる項目】" : string.Empty);
                    CellOutput(outputSheet, 20, 4, getShokenKekkaDAOutput.ShokenKekkaListDataTable == null || getShokenKekkaDAOutput.ShokenKekkaListDataTable.Count == 0 ? "【文頭の数字は異常が認められる項目】" : string.Empty);

                    #endregion

                    #endregion

                    #region output kensa komoku

                    //(42)
                    //output kensa komoku
                    OutputKensaKomoku(outputSheet, printRow);

                    //output constant info
                    OutputConstInfo(outputSheet, constDT, printRow);

                    //output kensakomoku of previous time
                    OutputPreviousKensaKomoku(outputSheet, printRow);

                    //(43)
                    // 2014.12.16 toyoda Modfy Start 目標値ラインの出力方法を見直し
                    //SetChartLine(outputSheet, TOSHIDO_CHART_NAME, ConvertBaseLinePos(_baseLinePosToshido), _maxScaleToshido, "TODHIDO_BASE_LINE");
                    //SetChartLine(outputSheet, BOD_CHART_NAME, ConvertBaseLinePos(_baseLinePosBOD), _maxScaleBOD, "BOD_BASE_LINE");
                    SetChartLine(outputSheet, TOSHIDO_CHART_NAME, _baseLinePosToshido, _maxScaleToshido, "TOSHIDO_BASE_LINE");
                    SetChartLine(outputSheet, BOD_CHART_NAME, _baseLinePosBOD, _maxScaleBOD, "BOD_BASE_LINE");
                    // 2014.12.16 toyoda Modfy End
                    
                    #endregion

                }

                //MOD_Ver1.07 Start
                //delete template sheet
                //if (book.Sheets.Count >= 3)
                //{
                //    tempSheet1.Delete();
                //    tempSheet2.Delete();
                //}
                //if (book.Sheets.Count > 1)
                //{
                //    tempSheet.Delete();
                //}
                //MOD_Ver1.07 End

            }
            catch
            {
                throw;
            }
            finally
            {
                //DEL_Ver1.07 Start
                //if (tempSheet1 != null)
                //{
                //    Marshal.ReleaseComObject(tempSheet1);
                //}

                //if (tempSheet2 != null)
                //{
                //    Marshal.ReleaseComObject(tempSheet2);
                //}
                //DEL_Ver1.07 End
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region OutputKensaKomoku
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputKensaKomoku
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputKensaKomoku(Worksheet outputSheet, KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoRow printRow)
        {
            //水素イオン濃度 
            CellOutput(outputSheet, 39, 60, printRow.KensaKekkaSuisoIonNodo);

            //水素イオン濃度ー判定
            CellOutput(outputSheet, 39, 62, printRow.KensaKekkaSuisoIonNodoHantei);

            //汚泥沈殿率 
            CellOutput(outputSheet, 40, 60, printRow.KensaKekkaOdeiChindenritsu);

            //汚泥沈殿率ー判定 
            CellOutput(outputSheet, 40, 62, printRow.KensaKekkaOdeiChindenritsuHantei);

            //溶存酸素量
            CellOutput(outputSheet, 41, 60, printRow.KensaKekkaYozonSansoryo);

            //溶存酸素量ー判定 
            CellOutput(outputSheet, 41, 62, printRow.KensaKekkaYozonSansoryoHantei);

            //塩素イオン濃度 
            CellOutput(outputSheet, 42, 60, printRow.KensaKekkaEnsoIonNodo);

            //塩素イオン濃度ー判定
            CellOutput(outputSheet, 42, 62, printRow.KensaKekkaEnsoIonNodoHantei);

            //透視度２次処理水 
            CellOutput(outputSheet, 43, 60, printRow.KensaKekkaToshido2jiSyorisui);

            //透視度ー判定２次処理水
            CellOutput(outputSheet, 43, 62, printRow.KensaKekkaToshidoHantei2jiSyorisui);

            //透視度 
            CellOutput(outputSheet, 44, 60, printRow.KensaKekkaToshido);

            //透視度ー判定 
            CellOutput(outputSheet, 44, 62, printRow.KensaKekkaToshidoHantei);

            //残留塩素濃度 
            CellOutput(outputSheet, 45, 60, printRow.KensaKekkaZanryuEnsoNodo);

            //残留塩素濃度ー判定
            CellOutput(outputSheet, 45, 62, printRow.KensaKekkaZanryuEnsoNodoHantei);

            //生物化学酸素要求量 
            CellOutput(outputSheet, 46, 60, printRow.KensaKekkaBOD);

            //生物化学酸素要求量ー判定
            CellOutput(outputSheet, 46, 62, printRow.KensaKekkaBODHantei);

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
        /// 2014/10/15  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputConstInfo(Worksheet outputSheet, ConstMstDataSet.ConstMstDataTable constDT, KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoRow printRow)
        {
            if (constDT.Count == 0) return;

            string ph = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                        Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001))[0]).ConstValue;
            string odeiChindenRitsu = "－";
            string yozonSansoRyo = "－";
            string enkabutsuionNodo = "－";
            string toshido = "－";
            string zanryuEnsoNodo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                        Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_501))[0]).ConstValue;
            string bod = "－";

            if (printRow.KensaIraiShorihoshikiKbn == "1")
            {
                //(範囲)汚泥沈殿率(％)
                odeiChindenRitsu = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_101))[0]).ConstValue;

                //(範囲)溶存酸素量(mg/ℓ)
                yozonSansoRyo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_201))[0]).ConstValue;

                //(範囲)塩化物イオン濃度(mg/ℓ)
                enkabutsuionNodo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_301))[0]).ConstValue;

                //透視度（度）
                toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_401))[0]).ConstValue;

                //(範囲)ＢＯＤ(mg/ℓ)
                bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_601))[0]).ConstValue;

                _baseLinePosToshido = 7;
                _maxScaleToshido = 30;
                _baseLinePosBOD = 90;
                _maxScaleBOD = 120;

            }
            else if (printRow.KensaIraiShorihoshikiKbn == "2" || printRow.KensaIraiShorihoshikiKbn == "3")
            {
                //(範囲)汚泥沈殿率(％)
                odeiChindenRitsu = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_102))[0]).ConstValue;

                //(範囲)溶存酸素量(mg/ℓ)
                yozonSansoRyo = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_202))[0]).ConstValue;

                //透視度（度）
                int bodShoriSeino = 0;
                if (Int32.TryParse(printRow.KensaIraiBODShoriSeino, out bodShoriSeino))
                {
                    if (bodShoriSeino <= 20)
                    {
                        //透視度（度）
                        toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                                Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_402))[0]).ConstValue;

                        //(範囲)ＢＯＤ(mg/ℓ)
                        bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                            Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_602))[0]).ConstValue;

                        _baseLinePosToshido = 20;
                        _maxScaleToshido = 30;
                        _baseLinePosBOD = 20;
                        _maxScaleBOD = 30;
                    }
                    else if (bodShoriSeino <= 30)
                    {
                        //透視度（度）
                        toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                                Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_403))[0]).ConstValue;

                        //(範囲)ＢＯＤ(mg/ℓ)
                        bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                            Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_603))[0]).ConstValue;

                        _baseLinePosToshido = 15;
                        _maxScaleToshido = 30;
                        _baseLinePosBOD = 30;
                        _maxScaleBOD = 40;
                    }
                    else if (bodShoriSeino <= 60)
                    {
                        //透視度（度）
                        toshido = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                                Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_404))[0]).ConstValue;

                        //(範囲)ＢＯＤ(mg/ℓ)
                        bod = ((ConstMstDataSet.ConstMstRow)constDT.Select(string.Format("ConstRenban = '{0}'",
                            Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_604))[0]).ConstValue;

                        _baseLinePosToshido = 10;
                        _maxScaleToshido = 30;
                        _baseLinePosBOD = 60;
                        _maxScaleBOD = 80;
                    }
                }
            }

            //(範囲)pH
            CellOutput(outputSheet, 39, 63, ph);

            //(範囲)汚泥沈殿率(％)
            CellOutput(outputSheet, 40, 63, odeiChindenRitsu);

            //(範囲)溶存酸素量(mg/ℓ)
            CellOutput(outputSheet, 41, 63, yozonSansoRyo);

            //(範囲)塩化物イオン濃度(mg/ℓ)
            CellOutput(outputSheet, 42, 63, enkabutsuionNodo);

            //(範囲)透視度（度）
            CellOutput(outputSheet, 43, 63, toshido);

            //(範囲)残留塩素濃度(mg/ℓ)
            CellOutput(outputSheet, 45, 63, zanryuEnsoNodo);

            //(範囲)ＢＯＤ(mg/ℓ)
            CellOutput(outputSheet, 46, 63, bod);
        }
        #endregion

        #region OutputPreviousKensaKomoku
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： OutputPreviousKensaKomoku
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="suishitsuKensaKekkaRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputPreviousKensaKomoku(Worksheet outputSheet, KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoRow suishitsuKensaKekkaRow)
        {
            ISelectKensaKomokuInfoByJokasoCdDAInput daInput = new SelectKensaKomokuInfoByJokasoCdDAInput();
            daInput.KensaIraiJokasoHokenjoCd = suishitsuKensaKekkaRow.KensaIraiJokasoHokenjoCd;
            daInput.KensaIraiJokasoTorokuNendo = suishitsuKensaKekkaRow.KensaIraiJokasoTorokuNendo;
            daInput.KensaIraiJokasoRenban = suishitsuKensaKekkaRow.KensaIraiJokasoRenban;
            ISelectKensaKomokuInfoByJokasoCdDAOutput daOutput = new SelectKensaKomokuInfoByJokasoCdDataAccess().Execute(daInput);

            bool isOutput = false;
            int countOutput = 0;
            int colIdx = 77;
            string kensaBi = string.Empty;
            int rowIdx = 53;
            string noneStr = "－";

            #region exist data

            for (int i = 0; i < daOutput.KensaKomokuInfoDataTable.Count; i++)
            {
                KensaKekkaTblDataSet.KensaKomokuInfoRow kensaKomokuRow = daOutput.KensaKomokuInfoDataTable[i];
                if (isOutput && countOutput < COUNT_TIME_OUTPUT)
                {
                    colIdx -= 2;

                    //検査日
                    kensaBi = !string.IsNullOrEmpty(kensaKomokuRow.KensaIraiSuishitsuUketsukeDt) ?
                        Utility.DateUtility.ConvertToWareki(kensaKomokuRow.KensaIraiSuishitsuUketsukeDt, "gyy年M月", Utility.DateUtility.GengoKbn.WarekiEiRyaku) :
                        Utility.DateUtility.ConvertToWareki(kensaKomokuRow.KensaIraiDt, "gyy年M月", Utility.DateUtility.GengoKbn.WarekiEiRyaku);

                    CellOutput(outputSheet, 37, colIdx, kensaBi);

                    //20141206_ add cell BN 50 ~ BN 54
                    CellOutput(outputSheet, rowIdx--, 65, kensaBi);
                    //end
                    //判定
                    //CellOutput(outputSheet, 38, colIdx, kensaKomokuRow.KensaKekkaHanteiValue);
                    CellOutput(outputSheet, 38, colIdx, kensaKomokuRow.KensaKekkaHantei == "1" ? "適正" 
                        : (kensaKomokuRow.KensaKekkaHantei == "2" ? "おおむね適正"
                        : (kensaKomokuRow.KensaKekkaHantei == "3" ? "不適正" : string.Empty)));

                    //pH
                    CellOutput(outputSheet, 39, colIdx, kensaKomokuRow.KensaKekkaSuisoIonNodo);

                    //汚泥沈殿率(％)
                    CellOutput(outputSheet, 40, colIdx, kensaKomokuRow.KensaKekkaOdeiChindenritsu);

                    //溶存酸素量(mg/ℓ)
                    CellOutput(outputSheet, 41, colIdx, kensaKomokuRow.KensaKekkaYozonSansoryo);

                    //塩化物イオン濃度(mg/ℓ)
                    CellOutput(outputSheet, 42, colIdx, kensaKomokuRow.KensaKekkaEnsoIonNodo);

                    //透視度２次処理水 
                    CellOutput(outputSheet, 43, colIdx, kensaKomokuRow.KensaKekkaToshido2jiSyorisui);

                    //透視度 放流水
                    CellOutput(outputSheet, 44, colIdx, kensaKomokuRow.KensaKekkaToshido);

                    //残留塩素濃度(mg/ℓ)
                    CellOutput(outputSheet, 45, colIdx, kensaKomokuRow.KensaKekkaZanryuEnsoNodo);

                    //ＢＯＤ(mg/ℓ)
                    CellOutput(outputSheet, 46, colIdx, kensaKomokuRow.KensaKekkaBOD);

                    countOutput++;
                }

                //check to start output info of previous time 
                //if (kensaKomokuRow.KensaIraiHoteiKbn == kensaKomokuRow.KensaIraiHoteiKbn
                //    && kensaKomokuRow.KensaIraiHokenjoCd == kensaKomokuRow.KensaIraiHokenjoCd
                //    && kensaKomokuRow.KensaIraiNendo == kensaKomokuRow.KensaIraiNendo
                //    && kensaKomokuRow.KensaIraiRenban == kensaKomokuRow.KensaIraiRenban)
                if (kensaKomokuRow.KensaIraiHoteiKbn == suishitsuKensaKekkaRow.KensaIraiHoteiKbn
                    && kensaKomokuRow.KensaIraiHokenjoCd == suishitsuKensaKekkaRow.KensaIraiHokenjoCd
                    && kensaKomokuRow.KensaIraiNendo == suishitsuKensaKekkaRow.KensaIraiNendo
                    && kensaKomokuRow.KensaIraiRenban == suishitsuKensaKekkaRow.KensaIraiRenban)
                {
                    isOutput = true;
                }
            }

            #endregion

            #region case not exist data
            //20141206 set charater '-' to cell don't have data
            for (int j = 0; j < COUNT_TIME_OUTPUT - countOutput; j++)
            {
                colIdx -= 2;
                //検査日
                CellOutput(outputSheet, 37, colIdx, noneStr);
                //判定
                CellOutput(outputSheet, 38, colIdx, noneStr);
                //pH
                CellOutput(outputSheet, 39, colIdx, noneStr);
                //汚泥沈殿率(％)
                CellOutput(outputSheet, 40, colIdx, noneStr);
                //溶存酸素量(mg/ℓ)
                CellOutput(outputSheet, 41, colIdx, noneStr);
                //塩化物イオン濃度(mg/ℓ)
                CellOutput(outputSheet, 42, colIdx, noneStr);
                //透視度２次処理水 
                CellOutput(outputSheet, 43, colIdx, noneStr);
                //透視度 放流水
                CellOutput(outputSheet, 44, colIdx, noneStr);
                //残留塩素濃度(mg/ℓ)
                CellOutput(outputSheet, 45, colIdx, noneStr);
                //ＢＯＤ(mg/ℓ)
                CellOutput(outputSheet, 46, colIdx, noneStr);
                CellOutput(outputSheet, rowIdx--, 65, noneStr);
            }
            //end
            #endregion
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
        /// 2014/10/16  HuyTX　    新規作成
        /// 2014/12/25  小松　      外部結合で取得した名称等が DBNullの場合があるため IsNullメソッドで判定(検査依頼、検査結果、浄化槽台帳TBLは空文字になるはずだが、一応DBNullチェックを埋め込む)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputSuishitsuInfo(Worksheet outputSheet, KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoRow printRow, DateTime currentDateTime)
        {
            #region (1) ~ (28)

            //(1)
            SetShapeText(outputSheet, "SettisyaZipNoTextBox", !string.IsNullOrEmpty(printRow.IsKensaIraiSetchishaZipCdNull() ? string.Empty : printRow.KensaIraiSetchishaZipCd) ? string.Format("〒{0}", printRow.KensaIraiSetchishaZipCd) : string.Empty);

            //(2)
            SetShapeText(outputSheet, "SettisyaAdrTextBox", printRow.IsKensaIraiSetchishaAdrNull() ? string.Empty : printRow.KensaIraiSetchishaAdr);

            //(3)
            SetShapeText(outputSheet, "SettisyaNmTextBox", printRow.IsKensaIraiSetchishaNmNull() ? string.Empty : printRow.KensaIraiSetchishaNm);

            //(4)
            CellOutput(outputSheet, 6, 2, string.Format("送付先 {0}", printRow.IsKensaIraiSofusakiNmNull() ? string.Empty : printRow.KensaIraiSofusakiNm));

            //(5)
            SetShapeText(outputSheet, "KensaJoTextBox", printRow.KensaIraiHoteiKbn == "1" ? "７" : "１１");

            //(6)
            SetShapeText(outputSheet, "UketukeDtTextBox", !string.IsNullOrEmpty(printRow.IsUketukeDtNull() ? string.Empty : printRow.UketukeDt) ? Utility.DateUtility.ConvertToWareki(printRow.UketukeDt, "yy年MM月dd日") : string.Empty);

            //(7)blank

            //(8)
            CellOutput(outputSheet, 0, 22, Utility.DateUtility.ConvertToWareki(currentDateTime.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

            //(9)
            SetShapeText(outputSheet, "JimukyokuAdrTextBox", printRow.IsJimukyokuHoteiKanriAdrNull() ? string.Empty : printRow.JimukyokuHoteiKanriAdr);

            //(10)
            SetShapeText(outputSheet, "JimukyokuTelNoTextBox", !string.IsNullOrEmpty(printRow.IsJimukyokuTelNoNull() ? string.Empty : printRow.JimukyokuTelNo) ? string.Format("TEL {0}", printRow.JimukyokuTelNo) : string.Empty);

            //(11)
            SetShapeText(outputSheet, "KyokaiNoTextBox", !printRow.IsKensaIraiKekkashoInsatsuCntNull() && printRow.KensaIraiKekkashoInsatsuCnt > 0 ? string.Format("{0}-{1}", printRow.KyokaiNo, printRow.KensaIraiKekkashoInsatsuCnt) : printRow.KyokaiNo);

            //(12)
            SetShapeText(outputSheet, "SettisyaNoTextBox", printRow.IsJokasoNoNull() ? string.Empty : printRow.JokasoNo);

            //(13)
            SetShapeText(outputSheet, "KensaTantoshaNmTextBox", printRow.IsKensaIraiKensaTantoshaNmNull() ? string.Empty : printRow.KensaIraiKensaTantoshaNm);

            //(14)
            CellOutput(outputSheet, 7, 4, printRow.IsKensaIraiSetchishaNmNull() ? string.Empty : printRow.KensaIraiSetchishaNm);

            //(15)
            CellOutput(outputSheet, 8, 4, printRow.IsKensaIraiShisetsuNmNull() ? string.Empty : printRow.KensaIraiShisetsuNm);

            //(16)
            CellOutput(outputSheet, 9, 4, printRow.IsKensaIraiSetchibashoAdrNull() ? string.Empty : printRow.KensaIraiSetchibashoAdr);

            //(17)
            CellOutput(outputSheet, 10, 4, printRow.IsMakerGyoshaNmNull() ? string.Empty : printRow.MakerGyoshaNm);

            //(18)
            CellOutput(outputSheet, 11, 4, printRow.IsKojiGyoshaNmNull() ? string.Empty : printRow.KojiGyoshaNm);

            //(19)
            CellOutput(outputSheet, 12, 4, printRow.IsHoshuGyoshaNmNull() ? string.Empty : printRow.HoshuGyoshaNm);

            //(20)
            CellOutput(outputSheet, 13, 4, printRow.IsSeisoGyoshaNmNull() ? string.Empty : printRow.SeisoGyoshaNm);

            //(21), (22)
            CellOutput(outputSheet, 14, 4, string.Format("{0} {1}", printRow.IsKensaIraiShorihoshikiKbnValueNull() ? string.Empty : printRow.KensaIraiShorihoshikiKbnValue, printRow.IsShoriHoshikiNmNull() ? string.Empty : printRow.ShoriHoshikiNm));

            //(23)
            CellOutput(outputSheet, 7, 16, printRow.IsHokenjoNmNull() ? string.Empty : printRow.HokenjoNm);

            //(24)
            CellOutput(outputSheet, 7, 21, string.Format("受理No. {0}", printRow.IsHokenjoJyuriNoNull() ? string.Empty : printRow.HokenjoJyuriNo));

            //(25)
            CellOutput(outputSheet, 8, 16, !string.IsNullOrEmpty(printRow.IsKensaIraiBODShoriSeinoNull() ? string.Empty : printRow.KensaIraiBODShoriSeino) ? string.Format("{0} mg/ℓ以下", printRow.KensaIraiBODShoriSeino) : string.Empty);

            //(26)
            CellOutput(outputSheet, 9, 16, (printRow.IsJokasoJokasoKumitateKbnNull() ? string.Empty : printRow.JokasoJokasoKumitateKbn) == "1" ? "工場生産" : ((printRow.IsJokasoJokasoKumitateKbnNull() ? string.Empty : printRow.JokasoJokasoKumitateKbn) == "2" ? "現場打ち" : string.Empty));

            //(27)
            CellOutput(outputSheet, 9, 22, printRow.IsKatashikiNmNull() ? string.Empty : printRow.KatashikiNm);

            //(28)
            //CellOutput(outputSheet, 10, 16, printRow.KensaIraiKokujiNo);
            CellOutput(outputSheet, 10, 16, printRow.KensaIraiKokujiKbn == "1" 
                ? string.Format("告示外 {0}", printRow.KensaIraiNinteiNo)
                : string.Format("告示第 {0}-{1}", printRow.KensaIraiKokujiNendo, printRow.KensaIraiKokujiNo));

            #endregion

            #region (29) ~ (33)

            //(29) ~ (33)
            if (!string.IsNullOrEmpty(printRow.IsKensaIraiTatemonoYotoNull() ? string.Empty : printRow.KensaIraiTatemonoYoto))
            {
                //(29)
                CellOutput(outputSheet, 11, 16, printRow.IsKensaIraiTatemonoYotoValueNull() ? string.Empty : printRow.KensaIraiTatemonoYotoValue);
            }
            else
            {
                //(29)
                CellOutput(outputSheet, 11, 16, string.Format("{0} {1}", printRow.IsKenchikuyotoDaibunruiNm1Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm1,
                    !string.IsNullOrEmpty(printRow.IsKenchikuyotoDaibunruiNm1Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm1) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm1) : string.Empty));
                CellOutput(outputSheet, 12, 16, printRow.IsKenchikuyotoNm1Null() ? string.Empty : printRow.KenchikuyotoNm1);

                //(30)
                CellOutput(outputSheet, 11, 18, string.Format("{0} {1}", printRow.IsKenchikuyotoDaibunruiNm2Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm2,
                    !string.IsNullOrEmpty(printRow.IsKenchikuyotoDaibunruiNm2Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm2) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm2) : string.Empty));
                CellOutput(outputSheet, 12, 18, printRow.IsKenchikuyotoNm2Null() ? string.Empty : printRow.KenchikuyotoNm2);

                //(31)
                CellOutput(outputSheet, 11, 20, string.Format("{0} {1}", printRow.IsKenchikuyotoDaibunruiNm3Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm3,
                    !string.IsNullOrEmpty(printRow.IsKenchikuyotoDaibunruiNm3Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm3) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm3) : string.Empty));
                CellOutput(outputSheet, 12, 20, printRow.IsKenchikuyotoNm3Null() ? string.Empty : printRow.KenchikuyotoNm3);

                //(32)
                CellOutput(outputSheet, 11, 22, string.Format("{0} {1}", printRow.IsKenchikuyotoDaibunruiNm4Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm4,
                    !string.IsNullOrEmpty(printRow.IsKenchikuyotoDaibunruiNm4Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm4) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm4) : string.Empty));
                CellOutput(outputSheet, 12, 22, printRow.IsKenchikuyotoNm4Null() ? string.Empty : printRow.KenchikuyotoNm4);

                //(33)
                CellOutput(outputSheet, 11, 24, string.Format("{0} {1}", printRow.IsKenchikuyotoDaibunruiNm5Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm5,
                    !string.IsNullOrEmpty(printRow.IsKenchikuyotoDaibunruiNm5Null() ? string.Empty : printRow.KenchikuyotoDaibunruiNm5) ? string.Format("({0})", printRow.KenchikuyotoShobunruiNm5) : string.Empty));
                CellOutput(outputSheet, 12, 24, printRow.IsKenchikuyotoNm5Null() ? string.Empty : printRow.KenchikuyotoNm5);
            }

            #endregion

            #region (34) ~ (39)

            //(34)
            CellOutput(outputSheet, 13, 16, printRow.IsKensaIraiHoryusakiCdValueNull() ? string.Empty : printRow.KensaIraiHoryusakiCdValue);

            //(35)
            CellOutput(outputSheet, 14, 16, Utility.DateUtility.ConvertToWareki(printRow.IsShiyoKaishiDtNull() ? string.Empty : printRow.ShiyoKaishiDt, "yy年MM月dd日"));

            //(36)
            CellOutput(outputSheet, 14, 22, Utility.DateUtility.ConvertToWareki(printRow.IsSetchiDtNull() ? string.Empty : printRow.SetchiDt, "yy年MM月dd日"));

            //(37)
            CellOutput(outputSheet, 15, 16, printRow.IsKensaIraiShoritaishoJininNull() ? string.Empty : printRow.KensaIraiShoritaishoJinin);

            //(38)
            CellOutput(outputSheet, 15, 22, printRow.IsKensaIraiJitsushiyoJininNull() ? string.Empty : printRow.KensaIraiJitsushiyoJinin);

            //(39)
            //CellOutput(outputSheet, 17, 4, printRow.KensaKekkaHanteiValue);
            string kensaKekkaHantei = printRow.IsKensaKekkaHanteiNull() ? string.Empty : printRow.KensaKekkaHantei;
            CellOutput(outputSheet, 17, 4, kensaKekkaHantei == "1" ? "適正です。"
                : (kensaKekkaHantei == "2" ? "おおむね適正です。"
                : (kensaKekkaHantei == "3" ? "不適正 です。" : string.Empty)));


            #endregion
        }
        #endregion

        #region SetChartLine
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetChartLine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="chartName"></param>
        /// <param name="baseLinePos"></param>
        /// <param name="maximumScale"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06  HuyTX　    新規作成
        /// 2014/12/16  豊田　     処理見直し
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetChartLine(Worksheet outputSheet, string chartName, double baseLinePos, double maximumScale, string objectName)
        {
            // 2014.12.16 toyoda Modfy Start 目標値ラインの出力方法を見直し
            //double myH, myPt, Xp1, Xp2, Yp1, Yp2, Ymax, Ymin, Yline;
            //myPt = baseLinePos;

            //ChartObject xlCharts = (ChartObject)outputSheet.ChartObjects(chartName);
            //Chart chart = xlCharts.Chart;
            //Axis axis = chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary) as Axis;
            //axis.MaximumScale = maximumScale;
            //Xp1 = chart.PlotArea.InsideLeft - 4;
            //Xp2 = Xp1 + chart.PlotArea.InsideWidth + 7;
            //Yp1 = chart.PlotArea.InsideTop;
            //myH = chart.PlotArea.InsideHeight;
            //Ymax = axis.MaximumScale;
            //Ymin = axis.MinimumScale;
            //Yline = Yp1 + (myH * (100 / (Ymax - Ymin) * (1 - myPt / 100)));

            //Shape shape = chart.Shapes.AddLine((float)Xp1, (float)Yline, (float)Xp2, (float)Yline);
            //shape.Line.Weight = 2;
            //shape.Line.ForeColor.RGB = (int)Microsoft.Office.Interop.Excel.XlRgbColor.rgbRed;

            ChartObject xlCharts = null;
            Chart chart = null;
            Axis axis = null;

            try
            {
                xlCharts = (ChartObject)outputSheet.ChartObjects(chartName);
                chart = xlCharts.Chart;
                axis = chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary) as Axis;
                axis.MaximumScale = maximumScale;
            }
            finally
            {
                if (axis != null) { Marshal.ReleaseComObject(axis); }
                if (chart != null) { Marshal.ReleaseComObject(chart); }
                if (xlCharts != null) { Marshal.ReleaseComObject(xlCharts); }
            }

            double zeroLoc = GetHeight(outputSheet, 1, 57);
            double maxLoc = GetHeight(outputSheet, 1, 50);
            double topLoc = zeroLoc - (baseLinePos * ((zeroLoc - maxLoc) / maximumScale));

            SetLineTopLocation(outputSheet, objectName, (float)topLoc);
            // 2014.12.16 toyoda Modfy End

        }
        #endregion

        #region ConvertBaseLinePos
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： ConvertBaseLinePos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseLine"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private double ConvertBaseLinePos(int baseLine)
        {
            switch (baseLine)
            {
                case 7:
                    baseLine = 77;
                    break;
                case 10:
                case 60:
                    baseLine = 80;
                    break;
                case 15:
                    baseLine = 85;
                    break;
                case 20:
                case 30:
                    baseLine = 90;
                    break;
                case 90:
                    baseLine = 70;
                    break;
                default:
                    break;
            }

            return baseLine;
        }
        #endregion

        #endregion

    }
    #endregion
}
