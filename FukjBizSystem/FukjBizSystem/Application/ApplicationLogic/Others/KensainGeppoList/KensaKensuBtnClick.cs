using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.Others.KensainGeppoList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensainGeppoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensaKensuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensaKensuBtnClickALInput : IBseALInput
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
        /// PrintKensainGeppoListDataTable
        /// </summary>
        KensainGeppoTblDataSet.PrintKensainGeppoListDataTable PrintKensainGeppoListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKensuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensaKensuBtnClickALInput : IKensaKensuBtnClickALInput
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
        /// PrintKensainGeppoListDataTable
        /// </summary>
        public KensainGeppoTblDataSet.PrintKensainGeppoListDataTable PrintKensainGeppoListDataTable { get; set; }

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
    //  インターフェイス名 ： IKensaKensuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensaKensuBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKensuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensaKensuBtnClickALOutput : IKensaKensuBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKensuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensaKensuBtnClickApplicationLogic : BaseApplicationLogic<IKensaKensuBtnClickALInput, IKensaKensuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensainGeppoList：KensaKensuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKensuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKensuBtnClickApplicationLogic()
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
        /// 2014/09/16  HuyTX　　    新規作成
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
        /// 2014/09/16  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensaKensuBtnClickALOutput Execute(IKensaKensuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensaKensuBtnClickALOutput output = new KensaKensuBtnClickALOutput();

            try
            {
                PrintKensainGeppoListBLInput blInput = new PrintKensainGeppoListBLInput();
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensainGeppoListFormatFile;
                blInput.AfterDispFlg = true;
                blInput.KensainGeppoListDgv = input.KensainGeppoListDgv;
                blInput.TaisyoYMFrom = input.TaisyoYMFrom;
                blInput.TaisyoYMTo = input.TaisyoYMTo;
                blInput.PrintKensainGeppoListDataTable = input.PrintKensainGeppoListDataTable;

                new PrintKensainGeppoListBusinessLogic().Execute(blInput);

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
