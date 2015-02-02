using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zynas.Framework.Core.Base.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLocation
    /// <summary>
    /// レジストリ操作の抽象クラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/14　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public abstract class Registry
    {
        #region プロパティ(private)

        // NOTICE アプリケーション名応じたキーのルートを設定する事 => 福岡浄化槽では、下記を使用する
        /// <summary>
        /// レジストリキー(固定部分)
        /// </summary>
        private const string BaseKeyName = @"SOFTWARE\Zynas\Fukj";

        #endregion

        #region プロパティ(protected)

        /// <summary>
        /// レジストリキー(固有部分)
        /// </summary>
        abstract protected string NativeKeyName
        {
            get;
        }

        #endregion

        #region メソッド(protected)

        #region Write
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Write
        /// <summary>
        /// 値の設定
        /// </summary>
        /// <param name="user">利用者ID</param>
        /// <param name="subKey">サブキー</param>
        /// <param name="value">設定する値</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/14　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void Write(string user, string subKey, object value)
        {
            // キーでオープン
            Microsoft.Win32.RegistryKey rKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                SubKey(user), Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            // キーが登録されていない場合
            if (rKey == null)
            {
                // キーを登録
                rKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(
                    SubKey(user), Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            // 値を設定
            rKey.SetValue(subKey, value);
            rKey.Close();
        }
        #endregion

        #region Read
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Read
        /// <summary>
        /// 値の取得
        /// </summary>
        /// <param name="user">利用者ID</param>
        /// <param name="subKey">サブキー</param>
        /// <param name="defValue">初期値</param>
        /// <returns>取得した値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/14　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected object Read(string user, string subKey, object defValue)
        {
            // キーでオープン
            Microsoft.Win32.RegistryKey rKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                SubKey(user), Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            // キーが登録されている場合
            if (rKey != null)
            {
                // 値を取得
                object value = rKey.GetValue(subKey, defValue);
                rKey.Close();

                // 変換した位置を戻す
                return value;
            }

            // 初期データを戻す
            return defValue;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SubKey
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SubKey
        /// <summary>
        /// レジストリキーを取得する
        /// </summary>
        /// <param name="user">利用者ID</param>
        /// <returns>レジストリキー文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string SubKey(string user)
        {
            // レジストリキーの作成
            return BaseKeyName + @"\" + (string.IsNullOrEmpty(user) ? @"Default" : user) + @"\" + NativeKeyName;
        }
        #endregion

        #endregion
    }

    #endregion
}
