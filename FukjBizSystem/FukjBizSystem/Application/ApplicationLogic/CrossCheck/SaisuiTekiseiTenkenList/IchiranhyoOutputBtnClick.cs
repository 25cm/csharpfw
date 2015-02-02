using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIchiranhyoOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　    　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIchiranhyoOutputBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        string SavePath { get; set; }

        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IchiranhyoOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　    　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IchiranhyoOutputBtnClickALInput : IIchiranhyoOutputBtnClickALInput
    {
        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("指定保存パス[{0}]", SavePath);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIchiranhyoOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　    　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIchiranhyoOutputBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IchiranhyoOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　    　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IchiranhyoOutputBtnClickALOutput : IIchiranhyoOutputBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IchiranhyoOutputBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　    　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IchiranhyoOutputBtnClickApplicationLogic : BaseApplicationLogic<IIchiranhyoOutputBtnClickALInput, IIchiranhyoOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SaisuiTekiseiTenkenList：IchiranhyoOutputBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： IchiranhyoOutputBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　    　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public IchiranhyoOutputBtnClickApplicationLogic()
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
        /// 2014/12/23　    　　    新規作成
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
        /// 2014/12/23　    　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IIchiranhyoOutputBtnClickALOutput Execute(IIchiranhyoOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IIchiranhyoOutputBtnClickALOutput output = new IchiranhyoOutputBtnClickALOutput();

            try
            {
                IPrintKurosuChekkuIchiranBLInput blInput = new PrintKurosuChekkuIchiranBLInput();
                //blInput.AfterDispFlg = true;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KurosuChekkuChosaIchiranpyoFormatFile;
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.PrintTable = input.PrintTable;
                blInput.SavePath = input.SavePath;
                new PrintKurosuChekkuIchiranBusinessLogic().Execute(blInput);
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
