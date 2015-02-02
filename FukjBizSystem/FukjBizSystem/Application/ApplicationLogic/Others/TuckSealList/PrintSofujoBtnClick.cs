using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.TuckSealList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.TuckSealList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSofujoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSofujoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// Printer name
        /// </summary>
        string PrinterName { get; set; }

        /// <summary>
        /// 部数
        /// </summary>
        int CopyNumber { get; set; }

        /// <summary>
        /// TuckSealListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.TuckSealListDataTable TuckSealListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSofujoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSofujoBtnClickALInput : IPrintSofujoBtnClickALInput
    {
        /// <summary>
        /// Printer name
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// 部数
        /// </summary>
        public int CopyNumber { get; set; }

        /// <summary>
        /// TuckSealListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.TuckSealListDataTable TuckSealListDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("部数[{0}]", CopyNumber);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintSofujoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintSofujoBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSofujoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSofujoBtnClickALOutput : IPrintSofujoBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintSofujoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintSofujoBtnClickApplicationLogic : BaseApplicationLogic<IPrintSofujoBtnClickALInput, IPrintSofujoBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TuckSealList：PrintSofujoBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintSofujoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintSofujoBtnClickApplicationLogic()
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
        /// 2014/08/19　AnhNV　　    新規作成
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
        /// 2014/08/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintSofujoBtnClickALOutput Execute(IPrintSofujoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintSofujoBtnClickALOutput output = new PrintSofujoBtnClickALOutput();

            try
            {
                IPrintSofujoBLInput blInput = new PrintSofujoBLInput();
                blInput.AfterPrintFlg = true;
                blInput.PrinterName = input.PrinterName;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SofujoFormatFile;
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.TuckSealListDataTable = input.TuckSealListDataTable;
                blInput.CopyNumber = input.CopyNumber;
                new PrintSofujoBusinessLogic().Execute(blInput);
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
