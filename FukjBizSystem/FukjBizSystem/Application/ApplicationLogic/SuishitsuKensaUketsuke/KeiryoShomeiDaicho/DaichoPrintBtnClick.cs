using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDaichoPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDaichoPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        KeiryoShomeiDaichoSearchCond SearchCond { get; set; }

        #region to be removed
        ///// <summary>
        ///// 年度
        ///// </summary>
        //string Nendo { get; set; }

        ///// <summary>
        ///// 条件追加区分
        ///// </summary>
        //string IraiDateKbn { get; set; }

        ///// <summary>
        ///// 依頼受付日（開始）
        ///// </summary>
        //string IraiDateFrom { get; set; }

        ///// <summary>
        ///// 依頼受付日（終了）
        ///// </summary>
        //string IraiDateTo { get; set; }

        ///// <summary>
        ///// 依頼番号（開始）
        ///// </summary>
        //string IraiNoFrom { get; set; }

        ///// <summary>
        ///// 依頼番号（終了）
        ///// </summary>
        //string IraiNoTo { get; set; }
        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DaichoPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DaichoPrintBtnClickALInput : IBseALInputImpl, IDaichoPrintBtnClickALInput
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }

        #region to be removed
        ///// <summary>
        ///// 年度
        ///// </summary>
        //public string Nendo { get; set; }

        ///// <summary>
        ///// 条件追加区分
        ///// </summary>
        //public string IraiDateKbn { get; set; }

        ///// <summary>
        ///// 依頼受付日（開始）
        ///// </summary>
        //public string IraiDateFrom { get; set; }

        ///// <summary>
        ///// 依頼受付日（終了）
        ///// </summary>
        //public string IraiDateTo { get; set; }

        ///// <summary>
        ///// 依頼番号（開始）
        ///// </summary>
        //public string IraiNoFrom { get; set; }

        ///// <summary>
        ///// 依頼番号（終了）
        ///// </summary>
        //public string IraiNoTo { get; set; }

        ///// <summary>
        ///// ログ出力用データ文字列取得
        ///// </summary>
        //public string DataString
        //{
        //    get
        //    {
        //        return string.Format("年度[{0}], 条件追加区分[{1}], 依頼受付日（開始）[{2}], 依頼受付日（終了）[{3}], 依頼番号（開始）[{4}], 依頼番号（開始）[{5}]",
        //            new string[] { Nendo, IraiDateKbn, IraiDateFrom, IraiDateTo, IraiNoFrom, IraiNoTo });
        //    }
        //}
        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDaichoPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDaichoPrintBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DaichoPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DaichoPrintBtnClickALOutput : IDaichoPrintBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DaichoPrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DaichoPrintBtnClickApplicationLogic : BaseApplicationLogic<IDaichoPrintBtnClickALInput, IDaichoPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KeiryoShomeiDaicho：DaichoPrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DaichoPrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DaichoPrintBtnClickApplicationLogic()
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
        /// 2014/12/15  宗  　　    新規作成
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
        /// 2014/12/15  宗  　　    新規作成
        /// 2015/01/19  habu　　    出力条件指定を検索に合わせる
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDaichoPrintBtnClickALOutput Execute(IDaichoPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDaichoPrintBtnClickALOutput output = new DaichoPrintBtnClickALOutput();

            try
            {
                // 9条検査台帳印刷
                IPrint9joKensaDaichoBLInput printBLInput = new Print9joKensaDaichoBLInput();

                printBLInput.SearchCond = input.SearchCond;

                #region to be removed
                //printBLInput.Nendo = input.Nendo;
                //printBLInput.IraiDateKbn = input.IraiDateKbn;
                //printBLInput.IraiDateFrom = input.IraiDateFrom;
                //printBLInput.IraiDateTo = input.IraiDateTo;
                //printBLInput.IraiNoFrom = input.IraiNoFrom;
                //printBLInput.IraiNoTo = input.IraiNoTo;
                #endregion

                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.AfterDispFlg = true;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.Jo9KensaDaichoFormatFile;

                new Print9joKensaDaichoBusinessLogic().Execute(printBLInput);
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
