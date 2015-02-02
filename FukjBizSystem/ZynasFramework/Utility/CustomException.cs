using System;

namespace Zynas.Framework.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CustomException
    /// <summary>
    /// テラオフィス例外クラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/16　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class CustomException : Exception
    {
        #region プロパティ

        /// <summary>
        /// 戻り値コード
        /// </summary>
        private int resultCode;

        public int ResultCode
        {
            get { return resultCode; }
        }

        /// <summary>
        /// 拡張エラーコード
        /// </summary>
        private int extensionCode;

        public int ExtensionCode
        {
            get { return extensionCode; }
        }

        /// <summary>
        /// 拡張オブジェクト
        /// </summary>
        private Object[] extensionObjects;

        public Object[] ExtensionObjects
        {
            get { return extensionObjects; }
        }

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CustomException
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="resultCode">戻り値コード</param>
        /// <param name="extensionCode">拡張エラーコード</param>
        /// <param name="extensionObjects">拡張オブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/16　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CustomException(int resultCode, int extensionCode, Object[] extensionObjects, string message)
            : base(message)
        {
            // 戻り値コードの設定
            this.resultCode = resultCode;
            // 拡張エラーコードの設定
            this.extensionCode = extensionCode;
            // 拡張オブジェクトの設定
            this.extensionObjects = extensionObjects;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CustomException
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="resultCode">戻り値コード</param>
        /// <param name="extensionCode">拡張エラーコード</param>
        /// <param name="message">メッセージ</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/16　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CustomException(int resultCode, int extensionCode, string message)
            : base(message)
        {
            // 戻り値コードの設定
            this.resultCode = resultCode;
            // 業務エラーコードの設定
            this.extensionCode = extensionCode;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CustomException
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="resultCode">戻り値コード</param>
        /// <param name="message">メッセージ</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/16　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CustomException(int resultCode, string message)
            : base(message)
        {
            // 戻り値コードの設定
            this.resultCode = resultCode;
        }
        #endregion

    }
    #endregion
}
