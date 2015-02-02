using System.IO;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaIraishoOutputList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KensaIraishoOutputList
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
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable 
        /// </summary>
        JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }

        /// <summary>
        /// InsatsuKbn 
        /// </summary>
        string InsatsuKbn { get; set; }

        /// <summary>
        /// CopyCount 
        /// </summary>
        int CopyCount { get; set; }

        /// <summary>
        /// Shutsuryoku
        /// </summary>
        string Shutsuryoku { get; set; }
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
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IPrintBtnClickALInput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable 
        /// </summary>
        public JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }

        /// <summary>
        /// InsatsuKbn 
        /// </summary>
        public string InsatsuKbn { get; set; }

        /// <summary>
        /// CopyCount 
        /// </summary>
        public int CopyCount { get; set; }

        /// <summary>
        /// Shutsuryoku
        /// </summary>
        public string Shutsuryoku { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
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
    /// 2014/12/03  HuyTX　    新規作成
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
    /// 2014/12/03  HuyTX　    新規作成
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
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaIraishoOutputList：PrintBtnClick";

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
        /// 2014/12/03  HuyTX　    新規作成
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
        /// 2014/12/03  HuyTX　    新規作成
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
        /// 2014/12/03  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                //出力依頼書/11条水質
                if (input.Shutsuryoku == "1")
                {
                    IPrintJokasoSuishitsuKensaIraishoBLInput blInput = new PrintJokasoSuishitsuKensaIraishoBLInput();
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.JokasoSuishitsuKensaIraishoFormatFile);
                    //blInput.AfterDispFlg = true;
                    blInput.AfterPrintFlg = true;
                    blInput.CopyCount = input.CopyCount;
                    blInput.InsatsuKbn = input.InsatsuKbn;
                    blInput.KensaIraishoOutputListDataTable = input.KensaIraishoOutputListDataTable;
                    new PrintJokasoSuishitsuKensaIraishoBusinessLogic().Execute(blInput);
                }
                else //出力依頼書/計量証明
                {
                    IPrintKeiryoShomeiKensaIraishoBLInput blInput = new PrintKeiryoShomeiKensaIraishoBLInput();
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.KeiryoShomeiKensaIraishoFormatFile);
                    //blInput.AfterDispFlg = true;
                    blInput.AfterPrintFlg = true;
                    blInput.CopyCount = input.CopyCount;
                    blInput.InsatsuKbn = input.InsatsuKbn;
                    blInput.KensaIraishoOutputListDataTable = input.KensaIraishoOutputListDataTable;
                    new PrintKeiryoShomeiKensaIraishoBusinessLogic().Execute(blInput);
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

    }
    #endregion
}
