using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.Others.KensainGeppoList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensainGeppoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGaikanGeppoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGaikanGeppoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// KensainGeppoListDgv 
        /// </summary>
        DataGridView KensainGeppoListDgv { get; set; }

        /// <summary>
        /// TaisyoYMFrom
        /// </summary>
        string TaisyoYMFrom { get; set; }

        /// <summary>
        /// TaisyoYMTo
        /// </summary>
        string TaisyoYMTo { get; set; }

        /// <summary>
        /// ShishoCd
        /// </summary>
        string ShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaikanGeppoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GaikanGeppoBtnClickALInput : IGaikanGeppoBtnClickALInput
    {
        /// <summary>
        /// KensainGeppoListDgv 
        /// </summary>
        public DataGridView KensainGeppoListDgv { get; set; }

        /// <summary>
        /// TaisyoYMFrom
        /// </summary>
        public string TaisyoYMFrom { get; set; }

        /// <summary>
        /// TaisyoYMTo
        /// </summary>
        public string TaisyoYMTo { get; set; }

        /// <summary>
        /// ShishoCd
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所[{0}]", ShishoCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGaikanGeppoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGaikanGeppoBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaikanGeppoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GaikanGeppoBtnClickALOutput : IGaikanGeppoBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaikanGeppoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GaikanGeppoBtnClickApplicationLogic : BaseApplicationLogic<IGaikanGeppoBtnClickALInput, IGaikanGeppoBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensainGeppoList：GaikanGeppoBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GaikanGeppoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GaikanGeppoBtnClickApplicationLogic()
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
        /// 2014/09/18  HuyTX　　    新規作成
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
        /// 2014/09/18  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGaikanGeppoBtnClickALOutput Execute(IGaikanGeppoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGaikanGeppoBtnClickALOutput output = new GaikanGeppoBtnClickALOutput();

            try
            {
                IPrintGaikanKensaGeppoBLInput blInput = new PrintGaikanKensaGeppoBLInput();
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.GaikanKensaGeppoFormatFile;
                blInput.AfterDispFlg = true;
                
                blInput.KensainGeppoListDgv = input.KensainGeppoListDgv;
                blInput.TaisyoYMFrom = input.TaisyoYMFrom;
                blInput.TaisyoYMTo = input.TaisyoYMTo;
                blInput.ShishoCd = input.ShishoCd;

                new PrintGaikanKensaGeppoBusinessLogic().Execute(blInput);

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
