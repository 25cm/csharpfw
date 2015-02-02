using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace $rootnamespace$
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： I$safeitemname$BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface I$safeitemname$BLInput : IBaseExcelPrintBLInput
    {

        // TODO 入力インターフェイスを実装してください
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： $safeitemname$BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class $safeitemname$BLInput : I$safeitemname$BLInput
    {
        /// <summary>
        /// 保存ファイルモード
        /// </summary>
        public int SaveFileMode { get; set; }

        /// <summary>
        /// ＥＸＣＥＬ書式へのパス
        /// </summary>
        public string FormatPath { get; set; }

        /// <summary>
        /// 帳票ディレクトリパス
        /// </summary>
        public string PrintDirectory { get; set; }

        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// 処理後ＥＸＣＥＬ表示フラグ
        /// </summary>
        public bool AfterDispFlg { get; set; }

        /// <summary>
        /// 処理後印刷フラグ
        /// </summary>
        public bool AfterPrintFlg { get; set; }

        /// <summary>
        /// 印刷プリンタ名
        /// </summary>
        public string PrinterName { get; set; }

        // TODO 入力クラスを実装してください
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： I$safeitemname$BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface I$safeitemname$BLOutput : IBaseExcelPrintBLOutput
    {
        // TODO 出力クラスを実装してください
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： $safeitemname$BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class $safeitemname$BLOutput : I$safeitemname$BLOutput
    {
        /// <summary>
        /// 保存パス
        /// </summary>
        public string SavePath
        {
            get ;
            set ;
        }

        // TODO 出力クラスを実装してください
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： $safeitemname$BusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class $safeitemname$BusinessLogic : BaseExcelPrintBusinessLogic<I$safeitemname$BLInput, I$safeitemname$BLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： $safeitemname$BusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public $safeitemname$BusinessLogic()
        {
            // TODO コンストラクタを実装してください
        }
        #endregion

        #region メソッド(protected)

        #region SetBook
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetBook
        /// <summary>
        /// ＥＸＣＥＬのブックオブジェクトにデータを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">入力</param>
        /// <param name="book">ＥＸＣＥＬのブックオブジェクト</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override I$safeitemname$BLOutput SetBook(I$safeitemname$BLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            I$safeitemname$BLOutput output = new $safeitemname$BLOutput();
            
            // TODO ＥＸＣＥＬのブックオブジェクトにデータを設定してください

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
