using System.Reflection;
using FukjBizSystem.Application.Boundary.KensaKekka;
using FukjBizSystem.Application.BusinessLogic.KensaKekka.KensaKekkaList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KensaKekka.KensaKekkaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFaxPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFaxPrintBtnClickALInput : IBseALInput
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
        /// PrintMode
        /// </summary>
        KensaKekkaListForm.PrintMode PrintMode { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FaxPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FaxPrintBtnClickALInput : IFaxPrintBtnClickALInput
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
        /// PrintMode
        /// </summary>
        public KensaKekkaListForm.PrintMode PrintMode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("区分[{0}], 保健所コード[{1}], 年度[{2}], 連番[{3}]", 
                    new string[]{KensaIraiHoteiKbn, KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban});
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFaxPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFaxPrintBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FaxPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FaxPrintBtnClickALOutput : IFaxPrintBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FaxPrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FaxPrintBtnClickApplicationLogic : BaseApplicationLogic<IFaxPrintBtnClickALInput, IFaxPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKekkaList：FaxPrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FaxPrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FaxPrintBtnClickApplicationLogic()
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
        /// 2014/08/15　HuyTX　　    新規作成
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
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFaxPrintBtnClickALOutput Execute(IFaxPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFaxPrintBtnClickALOutput output = new FaxPrintBtnClickALOutput();

            try
            {
                if (input.PrintMode == KensaKekkaListForm.PrintMode.FaxHoken)
                {
                    PrintSouShinhyo1Info(input);
                }
                else
                {
                    PrintSouShinhyo2Info(input);
                }

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

        #region メソッド(private)

        #region PrintSouShinhyo1Info
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintSouShinhyo1Info
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintSouShinhyo1Info(IFaxPrintBtnClickALInput input)
        {
            IGetSouShinhyo1PrintInfoBLInput getPrintInfoBLInput = new GetSouShinhyo1PrintInfoBLInput();

            getPrintInfoBLInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
            getPrintInfoBLInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
            getPrintInfoBLInput.KensaIraiNendo = input.KensaIraiNendo;
            getPrintInfoBLInput.KensaIraiRenban = input.KensaIraiRenban;

            IGetSouShinhyo1PrintInfoBLOutput printInfoBLOutput = new GetSouShinhyo1PrintInfoBusinessLogic().Execute(getPrintInfoBLInput);

            if (printInfoBLOutput.SouShinhyo1PrintInfoDataTable.Count == 0) return;

            //print SouShinhyo2PrintInfo
            IPrintSouShinhyo1InfoBLInput printBLInput = new PrintSouShinhyo1InfoBLInput();

            printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
            printBLInput.AfterDispFlg = true;
            printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SouShishyo1FormatFile;
            printBLInput.SouShinhyo1PrintInfoDataTable = printInfoBLOutput.SouShinhyo1PrintInfoDataTable;

            //execute
            new PrintSouShinhyo1InfoBusinessLogic().Execute(printBLInput);
        }
        #endregion

        #region PrintSouShinhyo2Info
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintSouShinhyo2Info
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintSouShinhyo2Info(IFaxPrintBtnClickALInput input)
        {
            IGetSouShinhyo2PrintInfoBLInput getPrintInfoBLInput = new GetSouShinhyo2PrintInfoBLInput();

            getPrintInfoBLInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
            getPrintInfoBLInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
            getPrintInfoBLInput.KensaIraiNendo = input.KensaIraiNendo;
            getPrintInfoBLInput.KensaIraiRenban = input.KensaIraiRenban;

            IGetSouShinhyo2PrintInfoBLOutput printInfoBLOutput = new GetSouShinhyo2PrintInfoBusinessLogic().Execute(getPrintInfoBLInput);

            if (printInfoBLOutput.SouShinhyo2PrintInfoDataTable.Count == 0) return;

            //print SouShinhyo2PrintInfo
            IPrintSouShinhyo2InfoBLInput printBLInput = new PrintSouShinhyo2InfoBLInput();

            printBLInput.PrintMode = input.PrintMode;
            printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
            printBLInput.AfterDispFlg = true;
            printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SouShishyo2FormatFile;
            printBLInput.SouShinhyo2PrintInfoDataTable = printInfoBLOutput.SouShinhyo2PrintInfoDataTable;

            //execute
            new PrintSouShinhyo2InfoBusinessLogic().Execute(printBLInput);
        }
        #endregion

        #endregion
    }
    #endregion
}
