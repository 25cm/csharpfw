using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensaKeihatsuSuishinhiList
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
    /// 2014/08/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 上下期区分/全件/上期/下期
        /// </summary>
        string Option { get; set; }

        /// <summary>
        /// 集計年度
        /// </summary>
        string SyukeiNendo { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }
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
    /// 2014/08/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALInput : IOutputBtnClickALInput
    {
        /// <summary>
        /// 上下期区分/全件/上期/下期
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// 集計年度
        /// </summary>
        public string SyukeiNendo { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("上下期区分/[{0}]", Option == "1" ? "全件" : (Option == "2" ? "上期" : "下期"));
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
    /// 2014/08/22　AnhNV　　    新規作成
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
    /// 2014/08/22　AnhNV　　    新規作成
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
    /// 2014/08/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickApplicationLogic : BaseApplicationLogic<IOutputBtnClickALInput, IOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeihatsuSuishinhiList：OutputBtnClick";

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
        /// 2014/08/22　AnhNV　　    新規作成
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
        /// 2014/08/22　AnhNV　　    新規作成
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
        /// 2014/08/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IOutputBtnClickALOutput Execute(IOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IOutputBtnClickALOutput output = new OutputBtnClickALOutput();

            try
            {
                IPrintKensaKeihatsuIchiranBLInput blInput = new PrintKensaKeihatsuIchiranBLInput();
                blInput.AfterDispFlg = true;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensaKeihatsuIchiranFormatFile;
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.Option = input.Option;
                blInput.SyukeiNendo = input.SyukeiNendo;
                blInput.KensaKeihatsuSuishinListDataTable = input.KensaKeihatsuSuishinListDataTable;
                new PrintKensaKeihatsuIchiranBusinessLogic().Execute(blInput);
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
