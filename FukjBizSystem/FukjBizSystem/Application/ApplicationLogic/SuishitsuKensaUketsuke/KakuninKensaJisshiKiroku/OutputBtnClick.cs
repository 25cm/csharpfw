using System.IO;
using System.Reflection;
//using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.JisshiKirokuOutput;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// SearchCond
        /// </summary>
        KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALInput : IOutputBtnClickALInput
    {
        /// <summary>
        /// SearchCond
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }

        /// <summary>
        /// PrintKbn 
        /// </summary>
        public string PrintKbn { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("{0}", PrintKbn == "1" ? "11条水質/11条外観" : "9条");
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALOutput : IOutputBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickApplicationLogic : BaseApplicationLogic<IOutputBtnClickALInput, IOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KakuninKensaJisshiKiroku：OutputBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： OutputBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public OutputBtnClickApplicationLogic()
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
        /// 2014/12/05  HuyTX　    新規作成
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
        /// 2014/12/05  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IOutputBtnClickALOutput Execute(IOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IOutputBtnClickALOutput output = new OutputBtnClickALOutput();

            try
            {
                if (input.SearchCond.KensaKbn == "1")
                {
                    // Print 047_9条検査確認検査実施記録_帳票設計書.xlsx
                    IPrintJo9KakuninKensaJisshiKirokuBLInput blInput = new PrintJo9KakuninKensaJisshiKirokuBLInput();
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.Jo9KakuninKensaJisshiKirokuFormatFile);
                    blInput.AfterPrintFlg = true;
                    blInput.SearchCond = input.SearchCond;

                    new PrintJo9KakuninKensaJisshiKirokuBusinessLogic().Execute(blInput);
                }
                else
                {
                    // Print 049_11条検査確認検査実施記録_帳票設計書.xlsx
                    IPrintJo11KakuninKensaJisshiKirokuBLInput blInput = new PrintJo11KakuninKensaJisshiKirokuBLInput();
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.Jo11KakuninKensaJisshiKirokuFormatFile);
                    blInput.AfterPrintFlg = true;
                    blInput.SearchCond = input.SearchCond;

                    new PrintJo11KakuninKensaJisshiKirokuBusinessLogic().Execute(blInput);
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
