using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.HoteiKensaDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISuishitsuIjoPrintBtnClickFollowALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/07  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISuishitsuIjoPrintBtnClickFollowALInput : IBseALInput
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

        /// <summary>
        /// 支所
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// メッセージの有無
        /// </summary>
        bool MassageFlg { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuIjoPrintBtnClickFollowALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/07  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SuishitsuIjoPrintBtnClickFollowALInput : ISuishitsuIjoPrintBtnClickFollowALInput
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
        /// 支所
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// メッセージの有無
        /// </summary>
        public bool MassageFlg { get; set; }

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
    //  インターフェイス名 ： ISuishitsuIjoPrintBtnClickFollowALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/07  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISuishitsuIjoPrintBtnClickFollowALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuIjoPrintBtnClickFollowALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/07  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SuishitsuIjoPrintBtnClickFollowALOutput : ISuishitsuIjoPrintBtnClickFollowALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuIjoPrintBtnClickFollowApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/07  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SuishitsuIjoPrintBtnClickFollowApplicationLogic : BaseApplicationLogic<ISuishitsuIjoPrintBtnClickFollowALInput, ISuishitsuIjoPrintBtnClickFollowALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoteiKensaDaicho：SuishitsuIjoPrintBtnClickFollow";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuIjoPrintBtnClickFollowApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/07  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuIjoPrintBtnClickFollowApplicationLogic()
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
        /// 2015/01/07  宗  　　    新規作成
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
        /// 2015/01/07  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISuishitsuIjoPrintBtnClickFollowALOutput Execute(ISuishitsuIjoPrintBtnClickFollowALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISuishitsuIjoPrintBtnClickFollowALOutput output = new SuishitsuIjoPrintBtnClickFollowALOutput();

            try
            {
                // フォロー検査対象一覧表印刷
                IPrintFollowKensaListBLInput printBLInput = new PrintFollowKensaListBLInput();

                printBLInput.Nendo = input.Nendo;
                printBLInput.IraiDateKbn = input.IraiDateKbn;
                printBLInput.IraiDateFrom = input.IraiDateFrom;
                printBLInput.IraiDateTo = input.IraiDateTo;
                printBLInput.IraiNoFrom = input.IraiNoFrom;
                printBLInput.IraiNoTo = input.IraiNoTo;
                printBLInput.ShishoCd = input.ShishoCd;

                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.AfterDispFlg = true;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.FollowKensaListFormatFile;

                //execute
                new PrintFollowKensaListBusinessLogic().Execute(printBLInput);
            }
            catch (CustomException ce)
            {
                if ((ce.ResultCode == ResultCode.OperationError) && (ce.ExtensionCode == (int)PrintHotei11joIjoListBusinessLogic.OperationErr.NoDataFound))
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), "出力データがありません。[フォロー検査対象一覧表]");
                    if (input.MassageFlg)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力データがありません。[フォロー検査対象一覧表]");
                    }
                }
                else
                {
                    throw;
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
