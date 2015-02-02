using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.BusinessLogic.Master.ShishoMstShosai;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.UketsukeKanri;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaChienHokokushoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaChienHokokushoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// Jo7KensaChienInputListRow
        /// </summary>
        Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow Jo7KensaChienInputListRow { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaChienHokokushoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaChienHokokushoBLInput : BaseExcelPrintBLInputImpl, IPrintKensaChienHokokushoBLInput
    {
        /// <summary>
        /// Jo7KensaChienInputListRow
        /// </summary>
        public Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow Jo7KensaChienInputListRow { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensaChienHokokushoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensaChienHokokushoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensaChienHokokushoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaChienHokokushoBLOutput : IPrintKensaChienHokokushoBLOutput
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
    //  クラス名 ： PrintKensaChienHokokushoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensaChienHokokushoBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensaChienHokokushoBLInput, IPrintKensaChienHokokushoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensaChienHokokushoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensaChienHokokushoBusinessLogic()
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
        /// 2014/10/31  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensaChienHokokushoBLOutput SetBook(IPrintKensaChienHokokushoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensaChienHokokushoBLOutput output = new PrintKensaChienHokokushoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet)book.Sheets["prt7条検査遅延報告書"];
                DateTime currentDt = Boundary.Common.Common.GetCurrentTimestamp(); 
                ShokuinMstDataSet.ShokuinMstRow shokuinRow = Utility.ShokuinInfo.GetShokuinInfo().Shokuin;

                IGetShishoMstByKeyBLInput getShishoInput = new GetShishoMstByKeyBLInput();
                getShishoInput.ShishoCd = shokuinRow.ShokuinShozokuShishoCd;
                IGetShishoMstByKeyBLOutput getShishoOutput = new GetShishoMstByKeyBusinessLogic().Execute(getShishoInput);

                string shishoNm = getShishoOutput.ShishoMstDataTable != null && getShishoOutput.ShishoMstDataTable.Count > 0 ? getShishoOutput.ShishoMstDataTable[0].ShishoNm : string.Empty;


                //(1)報告者の所属支所
                CellOutput(outputSheet, 9, 12, !string.IsNullOrEmpty(shishoNm) ? string.Format("{0} 検査センター", shishoNm) : string.Empty);

                //(2)ログインユーザー名
                CellOutput(outputSheet, 11, 12, shokuinRow.ShokuinNm);

                //(3)検査実施者
                CellOutput(outputSheet, 13, 12, !input.Jo7KensaChienInputListRow.IsShokuinNmNull() ? input.Jo7KensaChienInputListRow.ShokuinNm : string.Empty);

                //(4)設置者
                CellOutput(outputSheet, 15, 5, !input.Jo7KensaChienInputListRow.IsKensaIraiSetchishaNmNull() ? input.Jo7KensaChienInputListRow.KensaIraiSetchishaNm : string.Empty);

                //(5)検査番号 
                CellOutput(outputSheet, 15, 12, !input.Jo7KensaChienInputListRow.IskyokaiNoColNull() ? input.Jo7KensaChienInputListRow.kyokaiNoCol : string.Empty);

                //(6)設置場所
                CellOutput(outputSheet, 16, 5, !input.Jo7KensaChienInputListRow.IsKensaIraiSetchibashoAdrNull() ? input.Jo7KensaChienInputListRow.KensaIraiSetchibashoAdr : string.Empty);

                //(7)人槽
                if (!input.Jo7KensaChienInputListRow.IsKensaIraiShoritaishoJininNull())
                {
                    CellOutput(outputSheet, 16, 12, input.Jo7KensaChienInputListRow.KensaIraiShoritaishoJinin);
                }

                //(8)使用開始日
                CellOutput(outputSheet, 17, 5, !input.Jo7KensaChienInputListRow.IskensaIraiShiyoKaishiDtColNull() ? input.Jo7KensaChienInputListRow.kensaIraiShiyoKaishiDtCol : string.Empty);

                //(9)検査実施期限日
                CellOutput(outputSheet, 17, 12, !input.Jo7KensaChienInputListRow.IskensaJisshiKigenDtColNull() ? input.Jo7KensaChienInputListRow.kensaJisshiKigenDtCol : string.Empty);

                //(10)検査実施日
                CellOutput(outputSheet, 18, 5, !input.Jo7KensaChienInputListRow.IskensaIraiKensaDtColNull() ? input.Jo7KensaChienInputListRow.kensaIraiKensaDtCol : string.Empty);

                //(11)期限日からの経過日数
                CellOutput(outputSheet, 18, 12, !input.Jo7KensaChienInputListRow.IskeikaDtColNull() ? input.Jo7KensaChienInputListRow.keikaDtCol : string.Empty);

                //(12)システム日付
                CellOutput(outputSheet, 3, 13, Utility.DateUtility.ConvertToWareki(currentDt.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki));

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
