using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.ShoyoSanteiJininShukeiTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintShoyoSanteiJininBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintShoyoSanteiJininBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// ShukeiKaishiNendo 
        /// </summary>
        int ShukeiKaishiNendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintShoyoSanteiJininBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintShoyoSanteiJininBLInput : BaseExcelPrintBLInputImpl, IPrintShoyoSanteiJininBLInput
    {
        /// <summary>
        /// ShukeiKaishiNendo 
        /// </summary>
        public int ShukeiKaishiNendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintShoyoSanteiJininBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintShoyoSanteiJininBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintShoyoSanteiJininBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintShoyoSanteiJininBLOutput : IPrintShoyoSanteiJininBLOutput
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
    //  クラス名 ： PrintShoyoSanteiJininBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintShoyoSanteiJininBusinessLogic : BaseExcelPrintBusinessLogic<IPrintShoyoSanteiJininBLInput, IPrintShoyoSanteiJininBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// OUT_ROW_IDX_SHISHO3 
        /// </summary>
        private const int START_ROW_IDX_SHISHO3 = 6;

        /// <summary>
        /// START_ROW_IDX_SHISHO2 
        /// </summary>
        private const int START_ROW_IDX_SHISHO2 = 18;

        /// <summary>
        /// START_ROW_IDX_SHISHO1
        /// </summary>
        private const int START_ROW_IDX_SHISHO1 = 30;

        /// <summary>
        /// START_ROW_IDX_FOOTER 
        /// </summary>
        private const int START_ROW_IDX_FOOTER = 42;

        /// <summary>
        /// CHIKUHO_SHISHO
        /// </summary>
        private const string CHIKUHO_SHISHO = "1";

        /// <summary>
        /// CHIKUGO_SHISHO
        /// </summary>
        private const string CHIKUGO_SHISHO = "2";

        /// <summary>
        /// FUKUOKA_SHISHO
        /// </summary>
        private const string FUKUOKA_SHISHO = "3";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintShoyoSanteiJininBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintShoyoSanteiJininBusinessLogic()
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
        /// 2014/12/23  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintShoyoSanteiJininBLOutput SetBook(IPrintShoyoSanteiJininBLInput input, Excel.Workbook book)
        {
            IPrintShoyoSanteiJininBLOutput output = new PrintShoyoSanteiJininBLOutput();

            Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                int rowIdx = 0;
                application = book.Application;
                application.DisplayAlerts = false;

                outputSheet = (Worksheet)book.Sheets["Sheet1"];

                //get data ShoyoSanteiJininShukei
                ISelectShoyoSanteiJininInfoByNendoDAInput getShoyoSanteiJininInput = new SelectShoyoSanteiJininInfoByNendoDAInput();
                getShoyoSanteiJininInput.Nendo = input.ShukeiKaishiNendo;
                ISelectShoyoSanteiJininInfoByNendoDAOutput getShoyoSanteiJininOutput = new SelectShoyoSanteiJininInfoByNendoDataAccess().Execute(getShoyoSanteiJininInput);
                int rowIdxFooter = START_ROW_IDX_FOOTER;
                int nendo = 0;
                for (int i = 0; i < getShoyoSanteiJininOutput.ShoyoSanteiJininInfoDataTable.Count; i++)
                {
                    ShoyoSanteiJininShukeiTblDataSet.ShoyoSanteiJininInfoRow printRow = getShoyoSanteiJininOutput.ShoyoSanteiJininInfoDataTable[i];
                    ShoyoSanteiJininShukeiTblDataSet.ShoyoSanteiJininInfoRow preRow = getShoyoSanteiJininOutput.ShoyoSanteiJininInfoDataTable[i > 1 ? (i - 1) : 0];

                    if (printRow.ShishoCd == FUKUOKA_SHISHO) { rowIdx = START_ROW_IDX_SHISHO3; }
                    else if (printRow.ShishoCd == CHIKUGO_SHISHO) { rowIdx = START_ROW_IDX_SHISHO2; }
                    else if (printRow.ShishoCd == CHIKUHO_SHISHO) { rowIdx = START_ROW_IDX_SHISHO1; }

                    nendo = Convert.ToInt32(printRow.Nendo);
                    rowIdx += nendo - (input.ShukeiKaishiNendo - 4);

                    //output detail
                    OutputDetail(outputSheet, printRow, rowIdx);

                    rowIdxFooter = START_ROW_IDX_FOOTER;
                    rowIdxFooter += nendo - (input.ShukeiKaishiNendo - 4);
                    //output footer
                    OutputFooter(outputSheet, printRow, rowIdxFooter);
                }

                //(24)法定検査/計量証明
                CellOutput(outputSheet, 50, 20, Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_050, 
                                                                                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001));

                //(25)特殊項目
                CellOutput(outputSheet, 51, 20, Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_050,
                                                                                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002));

                //(26)年度 
                CellOutput(outputSheet, 0, 1, string.Format("{0}年度 所要算定人員予測", 
                        Utility.DateUtility.ConvertToWareki(input.ShukeiKaishiNendo.ToString(), "gyy", Utility.DateUtility.GengoKbn.Wareki)));

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

        #region OutputDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printRow"></param>
        /// <param name="rowIdx"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputDetail(Worksheet outputSheet, 
                                    ShoyoSanteiJininShukeiTblDataSet.ShoyoSanteiJininInfoRow printRow,
                                    int rowIdx)
        {
            //(1)年度
            CellOutput(outputSheet, rowIdx, 1, Utility.DateUtility.ConvertToWareki(printRow.Nendo, "yy"));
            //(2)外観検査地区 
            CellOutput(outputSheet, rowIdx, 2, !printRow.IsGaikanChikuwariKbnNull() ? printRow.GaikanChikuwariKbn : string.Empty);
            //(3)7条検査件数 
            CellOutput(outputSheet, rowIdx, 3, !printRow.IsKensa7JoCntNull() ? printRow.Kensa7JoCnt : 0);
            //(4)外観（5～20）件数
            CellOutput(outputSheet, rowIdx, 4, !printRow.IsKensa11JoCnt1Null() ? printRow.Kensa11JoCnt1 : 0);
            //(5)外観（21～50）件数 
            CellOutput(outputSheet, rowIdx, 5, !printRow.IsKensa11JoCnt2Null() ? printRow.Kensa11JoCnt2 : 0);
            //(6)外観（51～100）件数 
            CellOutput(outputSheet, rowIdx, 6, !printRow.IsKensa11JoCnt3Null() ? printRow.Kensa11JoCnt3 : 0);
            //(7)外観（101～300）件数 
            CellOutput(outputSheet, rowIdx, 7, !printRow.IsKensa11JoCnt4Null() ? printRow.Kensa11JoCnt4 : 0);
            //(8)外観（301～500）件数 
            CellOutput(outputSheet, rowIdx, 8, !printRow.IsKensa11JoCnt5Null() ? printRow.Kensa11JoCnt5 : 0);
            //(9)外観（501～1000）件数 
            CellOutput(outputSheet, rowIdx, 9, !printRow.IsKensa11JoCnt6Null() ? printRow.Kensa11JoCnt6 : 0);
            //(10)外観（1001以上）件数 
            CellOutput(outputSheet, rowIdx, 10, !printRow.IsKensa11JoCnt7Null() ? printRow.Kensa11JoCnt7 : 0);
            //(11) 自動計算

            //(12)スクリーニング件数 
            CellOutput(outputSheet, rowIdx, 12, !printRow.IsScreeningCntNull() ? printRow.ScreeningCnt : 0);
            //(13)フォロー件数 
            CellOutput(outputSheet, rowIdx, 13, !printRow.IsFollowCntNull() ? printRow.FollowCnt : 0);
            //(14)自動計算

            //(15)法定所要人員 
            CellOutput(outputSheet, rowIdx, 15, !printRow.IsHoteiShoyoJininNull() ? printRow.HoteiShoyoJinin : 0);
            //(16)法定配置人員 
            CellOutput(outputSheet, rowIdx, 16, !printRow.IsHoteiHaichiJininNull() ? printRow.HoteiHaichiJinin : 0);
            //(17)自動計算

            //(18)水質検査数
            CellOutput(outputSheet, rowIdx, 18, !printRow.IsSuishitsuCntNull() ? printRow.SuishitsuCnt : 0);
            //(19)計量証明数 
            CellOutput(outputSheet, rowIdx, 19, !printRow.IsKeiryoShomeiCntNull() ? printRow.KeiryoShomeiCnt : 0);
            //(20)特殊項目数 
            CellOutput(outputSheet, rowIdx, 20, !printRow.IsTokushuKomokuCntNull() ? printRow.TokushuKomokuCnt : 0);
            //(21)水質所要人員 
            CellOutput(outputSheet, rowIdx, 21, !printRow.IsSuishitsuShoyoJininNull() ? printRow.SuishitsuShoyoJinin : 0);
            //(22)水質配置人員 
            CellOutput(outputSheet, rowIdx, 22, !printRow.IsSuishitsuHaichiJininNull() ? printRow.SuishitsuHaichiJinin : 0);
            //(23)自動計算

        }
        #endregion

        #region OutputFooter
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： OutputFooter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="printRow"></param>
        /// <param name="rowIdx"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputFooter(Worksheet outputSheet,
                                    ShoyoSanteiJininShukeiTblDataSet.ShoyoSanteiJininInfoRow printRow,
                                    int rowIdx)
        {
            //(1)年度
            CellOutput(outputSheet, rowIdx, 1, Utility.DateUtility.ConvertToWareki(printRow.Nendo, "yy"));
            //(2)外観検査地区 
            CellOutput(outputSheet, rowIdx, 2, !printRow.IsGaikanChikuwariKbnNull() ? printRow.GaikanChikuwariKbn : string.Empty);
        }
        #endregion

        #endregion
    }
    #endregion
}
