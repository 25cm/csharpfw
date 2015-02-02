using System.Reflection;
//using FukjBizSystem.Application.Boundary.KensaKekka;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.HoteiKensaDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISuishitsuIjoPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISuishitsuIjoPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// 条件追加区分
        /// </summary>
        string IraiDateKbn { get; set; }

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        string IraiDateFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        string IraiDateTo { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        string IraiNoTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuIjoPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SuishitsuIjoPrintBtnClickALInput : ISuishitsuIjoPrintBtnClickALInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 条件追加区分
        /// </summary>
        public string IraiDateKbn { get; set; }

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        public string IraiDateFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        public string IraiDateTo { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        public string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        public string IraiNoTo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("年度[{0}], 条件追加区分[{1}], 依頼受付日（開始）[{2}], 依頼受付日（終了）[{3}], 依頼番号（開始）[{4}], 依頼番号（開始）[{5}]",
                    new string[] { Nendo, IraiDateKbn, IraiDateFrom, IraiDateTo, IraiNoFrom, IraiNoTo });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISuishitsuIjoPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISuishitsuIjoPrintBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuIjoPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SuishitsuIjoPrintBtnClickALOutput : ISuishitsuIjoPrintBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuIjoPrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SuishitsuIjoPrintBtnClickApplicationLogic : BaseApplicationLogic<ISuishitsuIjoPrintBtnClickALInput, ISuishitsuIjoPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoteiKensaDaicho：SuishitsuIjoPrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuIjoPrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuIjoPrintBtnClickApplicationLogic()
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
        /// 2014/12/12  宗  　　    新規作成
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
        /// 2014/12/12  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISuishitsuIjoPrintBtnClickALOutput Execute(ISuishitsuIjoPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISuishitsuIjoPrintBtnClickALOutput output = new SuishitsuIjoPrintBtnClickALOutput();

            try
            {
                PrintScreeningList(input);
                PrintFollowList(input);
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

        #region PrintScreeningList
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintScreeningList
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintScreeningList(ISuishitsuIjoPrintBtnClickALInput input)
        {
            // 法定11条水質異常一覧表印刷
            IPrintHotei11joIjoListBLInput printBLInput = new PrintHotei11joIjoListBLInput();

            printBLInput.Nendo = input.Nendo;
            printBLInput.IraiDateKbn = input.IraiDateKbn;
            printBLInput.IraiDateFrom = input.IraiDateFrom;
            printBLInput.IraiDateTo = input.IraiDateTo;
            printBLInput.IraiNoFrom = input.IraiNoFrom;
            printBLInput.IraiNoTo = input.IraiNoTo;

            printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
            printBLInput.AfterDispFlg = true;
            printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.Hotei11joIjoListFormatFile;

            new PrintHotei11joIjoListBusinessLogic().Execute(printBLInput);
        }
        #endregion

        #region PrintFollowList
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFollowList
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFollowList(ISuishitsuIjoPrintBtnClickALInput input)
        {
            // フォロー検査対象一覧表印刷
            IPrintFollowKensaListBLInput printBLInput = new PrintFollowKensaListBLInput();

            printBLInput.Nendo = input.Nendo;
            printBLInput.IraiDateKbn = input.IraiDateKbn;
            printBLInput.IraiDateFrom = input.IraiDateFrom;
            printBLInput.IraiDateTo = input.IraiDateTo;
            printBLInput.IraiNoFrom = input.IraiNoFrom;
            printBLInput.IraiNoTo = input.IraiNoTo;

            printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
            printBLInput.AfterDispFlg = true;
            printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.FollowKensaListFormatFile;

            //execute
            new PrintFollowKensaListBusinessLogic().Execute(printBLInput);
        }
        #endregion

        #endregion
    }
    #endregion
}
