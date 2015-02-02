
namespace Zynas.Framework.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ResultCode
    /// <summary>
    /// 戻り値コードの定義クラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/12　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class ResultCode
    {
        #region プロパティ(public)

        /// <summary>
        /// 正常終了
        /// </summary>
        public const int NormalEnd = 0;

        /// <summary>
        /// ＤＢエラー
        /// </summary>
        public const int DBError = 1;

        /// <summary>
        /// 業務エラー
        /// </summary>
        public const int OperationError = 2;

        /// <summary>
        /// 排他エラー
        /// </summary>
        public const int LockError = 3;

        /// <summary>
        /// 権限エラー
        /// </summary>
        public const int AuthorityError = 4;

        /// <summary>
        /// Felicaエラー
        /// </summary>
        public const int FelicaError = 10;

        /// <summary>
        /// その他エラー
        /// </summary>
        public const int OtherError = 100;

        #endregion
    }
    #endregion
}
