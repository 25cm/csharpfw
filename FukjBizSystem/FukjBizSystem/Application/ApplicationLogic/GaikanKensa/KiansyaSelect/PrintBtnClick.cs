using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KiansyaSelect;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KiansyaSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput
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

        /// <summary>
        /// ShishoNm
        /// </summary>
        string ShishoNm { get; set; }

        /// <summary>
        /// BushoNm
        /// </summary>
        string BushoNm { get; set; }

        /// <summary>
        /// ShokuinNm
        /// </summary>
        string ShokuinNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IPrintBtnClickALInput
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

        /// <summary>
        /// ShishoNm
        /// </summary>
        public string ShishoNm { get; set; }

        /// <summary>
        /// BushoNm
        /// </summary>
        public string BushoNm { get; set; }

        /// <summary>
        /// ShokuinNm
        /// </summary>
        public string ShokuinNm { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所名[{0}], 部署名[{1}], 検査員名[{2}]", ShishoNm, BushoNm, ShokuinNm);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALOutput : IPrintBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KianSyaSelect：PrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintBtnClickApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                KensaIraiTblDataSet.KensaTorisagePrintInfoDataTable printDataTable = new KensaIraiTblDataSet.KensaTorisagePrintInfoDataTable();
                IGetKensaTorisagePrintInfoBLInput getPrintInfoBLInput = new GetKensaTorisagePrintInfoBLInput();
                
                getPrintInfoBLInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                getPrintInfoBLInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                getPrintInfoBLInput.KensaIraiNendo = input.KensaIraiNendo;
                getPrintInfoBLInput.KensaIraiRenban = input.KensaIraiRenban;

                printDataTable = new GetKensaTorisagePrintInfoBusinessLogic().Execute(getPrintInfoBLInput).KensaTorisagePrintInfoDataTable;

                if (printDataTable.Count == 0) return output;

                printDataTable[0].ShishoNm = input.ShishoNm;
                printDataTable[0].BushoNm = input.BushoNm;
                printDataTable[0].ShokuinNm = input.ShokuinNm;

                //print KensaTorisage
                IPrintKensaTorisageBLInput printBLInput = new PrintKensaTorisageBLInput();
                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensaIraiToriatsukaiFormatFile;
                printBLInput.AfterDispFlg = true;
                printBLInput.KensaTorisagePrintInfoDataTable = printDataTable;

                new PrintKensaTorisageBusinessLogic().Execute(printBLInput);

            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
