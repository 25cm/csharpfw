using System.Windows.Forms;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Common.Boundary
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MessageForm
    /// <summary>
    /// メッセージ画面表示クラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/19　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class MessageForm
    {
        #region 定義

        /// <summary>
        /// 表示モードの定義
        /// </summary>
        public enum DispModeType
        {
            // 情報
            Infomation = 1,
            // 警告
            Warning,
            // エラー
            Error,
            // 確認
            Question
        }

        #endregion

        #region 静的メソッド(public)

        #region Show
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Show
        /// <summary>
        /// メッセージ画面の表示
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="dispMode">表示モード</param>
        /// <param name="dispMsg">表示メッセージ</param>
        /// <returns>メッセージ画面で選択されたボタン</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/19　稗田　　    新規作成
        /// 2010/10/12　稗田　　    修正(イメージ画面の裏に表示されない対応)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static DialogResult Show(DispModeType dispMode, string msgId, params string[] strList)
        {
            // メッセージ文字列の作成
            string dispMsg = string.Format(MessageResouce.GetMessage(msgId), strList);
            // 親画面の設定
            Form parent = null;
            // 表示するボタンの設定
            MessageBoxButtons buttons = GetMessageBoxButtons(dispMode);
            // 表示するアイコンの設定
            MessageBoxIcon icon = GetMessageBoxIcon(dispMode);

            // メッセージの表示
            if (dispMode == DispModeType.Question)
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon, MessageBoxDefaultButton.Button1);
            }
            else
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon);
            }

        }
        #endregion

        #region Show
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Show
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="defaultButton"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        ///  <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/08/31　柴田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static DialogResult Show(DispModeType dispMode, string msgId, MessageBoxDefaultButton defaultButton, params string[] strList)
        {
            // メッセージ文字列の作成
            string dispMsg = string.Format(MessageResouce.GetMessage(msgId), strList);
            // 親画面の設定
            Form parent = null;
            // 表示するボタンの設定
            MessageBoxButtons buttons = GetMessageBoxButtons(dispMode);
            // 表示するアイコンの設定
            MessageBoxIcon icon = GetMessageBoxIcon(dispMode);

            // メッセージの表示
            if (dispMode == DispModeType.Question)
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon, defaultButton);
            }
            else
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon);
            }

        }
        #endregion

        #region Show2
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Show2
        /// <summary>
        /// メッセージ画面の表示
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="dispMode">表示モード</param>
        /// <param name="dispMsg">表示メッセージ</param>
        /// <returns>メッセージ画面で選択されたボタン</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/19　稗田　　    新規作成
        /// 2010/10/12　稗田　　    修正(イメージ画面の裏に表示されない対応)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static DialogResult Show2(DispModeType dispMode, string dispMsg)
        {
            // 親画面の設定
            Form parent = null;
            // 表示するボタンの設定
            MessageBoxButtons buttons = GetMessageBoxButtons(dispMode);
            // 表示するアイコンの設定
            MessageBoxIcon icon = GetMessageBoxIcon(dispMode);

            // メッセージの表示
            if (dispMode == DispModeType.Question)
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon, MessageBoxDefaultButton.Button1);
            }
            else
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon);
            }

        }
        #endregion

        #region Show2
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Show2
        /// <summary>
        /// メッセージ画面の表示
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="dispMode">表示モード</param>
        /// <param name="dispMsg">表示メッセージ</param>
        /// <returns>メッセージ画面で選択されたボタン</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/19　稗田　　    新規作成
        /// 2010/10/12　稗田　　    修正(イメージ画面の裏に表示されない対応)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static DialogResult Show2(DispModeType dispMode, string dispMsg, MessageBoxDefaultButton defaultButton)
        {
            // 親画面の設定
            Form parent = null;
            // 表示するボタンの設定
            MessageBoxButtons buttons = GetMessageBoxButtons(dispMode);
            // 表示するアイコンの設定
            MessageBoxIcon icon = GetMessageBoxIcon(dispMode);

            // メッセージの表示
            if (dispMode == DispModeType.Question)
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon, defaultButton);
            }
            else
            {
                return MessageBox.Show(parent, dispMsg, Application.ProductName, buttons, icon);
            }
        }
        #endregion

        #endregion

        #region 静的メソッド(private)

        #region MessageBoxButtons
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MessageBoxButtons
        /// <summary>
        /// 表示するボタンの取得メッセージ画面の表示
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="dispMode">表示モード</param>
        /// <returns>ボタン</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/10/12　稗田　　    新規作成(イメージ画面の裏に表示されない対応)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static MessageBoxButtons GetMessageBoxButtons(DispModeType dispMode)
        {
            if (dispMode == DispModeType.Question)
            {
                return MessageBoxButtons.YesNo;
            }
            else
            {
                return MessageBoxButtons.OK;
            }
        }
        #endregion

        #region MessageBoxIcon
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MessageBoxIcon
        /// <summary>
        /// 表示するアイコンの取得メッセージ画面の表示
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="dispMode">表示モード</param>
        /// <returns>アイコン</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/10/12　稗田　　    新規作成(イメージ画面の裏に表示されない対応)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static MessageBoxIcon GetMessageBoxIcon(DispModeType dispMode)
        {
            // 情報
            if (dispMode == DispModeType.Infomation)
            {
                return MessageBoxIcon.Information;
            }
            // 警告
            else if (dispMode == DispModeType.Warning)
            {
                return MessageBoxIcon.Warning;
            }
            // エラー
            else if (dispMode == DispModeType.Error)
            {
                return MessageBoxIcon.Error;
            }
            // 確認
            else
            {
                return MessageBoxIcon.Question;
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
