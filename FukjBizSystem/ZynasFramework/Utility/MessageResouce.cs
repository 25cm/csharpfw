using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Zynas.Framework.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OperationLog
    /// <summary>
    /// 操作ログの出力を行います
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/08　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public static class MessageResouce
    {
        #region 定義

        #region 情報メッセージ

        /// <summary>
        /// 登録しました。
        /// </summary>
        public const string MSGID_I00001 = "I00001";

        /// <summary>
        /// 修正しました。
        /// </summary>
        public const string MSGID_I00002 = "I00002";

        /// <summary>
        /// 削除しました。
        /// </summary>
        public const string MSGID_I00003 = "I00003";

        /// <summary>
        /// 出力しました。
        /// </summary>
        public const string MSGID_I00004 = "I00004";

        /// <summary>
        /// 印刷しました。
        /// </summary>
        public const string MSGID_I00005 = "I00005";

        /// <summary>
        /// 送信しました。
        /// </summary>
        public const string MSGID_I00006 = "I00006";

        /// <summary>
        /// {0}を登録しました。
        /// </summary>
        public const string MSGID_I00007 = "I00007";

        /// <summary>
        /// {0}を修正しました。
        /// </summary>
        public const string MSGID_I00008 = "I00008";

        /// <summary>
        /// {0}を削除しました。
        /// </summary>
        public const string MSGID_I00009 = "I00009";

        /// <summary>
        /// {0}を出力しました。
        /// </summary>
        public const string MSGID_I00010 = "I00010";

        /// <summary>
        /// {0}を印刷しました。
        /// </summary>
        public const string MSGID_I00011 = "I00011";

        /// <summary>
        /// {0}を送信しました。
        /// </summary>
        public const string MSGID_I00012 = "I00012";

        /// <summary>
        /// {0}の登録が完了しました。
        /// </summary>
        public const string MSGID_I00013 = "I00013";

        /// <summary>
        /// 更新が完了しました。
        /// </summary>
        public const string MSGID_I00014 = "I00014";

        #endregion

        #region 警告メッセージ

        /// <summary>
        /// 画面は既に起動しています。&#10;&#10;&#10;&#10;タスクバーから該当画面を選択してください。
        /// </summary>
        public const string MSGID_W00001 = "W00001";

        /// <summary>
        /// 該当データはありませんでした。&#10;&#10;&#10;&#10;条件を再設定して検索し直してください。
        /// </summary>
        public const string MSGID_W00002 = "W00002";

        /// <summary>
        /// {0}件以上のデータがあります。条件を絞りこんでください。
        /// </summary>
        public const string MSGID_W00003 = "W00003";

        /// <summary>
        /// パスワードが正しくありません。&#10;&#10;&#10;&#10;正しいパスワードを入力してください。
        /// </summary>
        public const string MSGID_W00004 = "W00004";

        /// <summary>
        /// 従業員コードが存在しないか、パスワードが正しくありません。&#10;&#10;入力内容を確認してください。
        /// </summary>
        public const string MSGID_W00005 = "W00005";

        /// <summary>
        /// 必須入力項目「{0}」が入力されていません。
        /// </summary>
        public const string MSGID_W00006 = "W00006";

        /// <summary>
        /// 期間指定が正しくありません。&#10;&#10;&#10;&#10;項目間の大小関係を確認してください。
        /// </summary>
        public const string MSGID_W00007 = "W00007";

        /// <summary>
        /// 既に入力された{0}が存在します。&#10;&#10;&#10;&#10;入力内容を確認してください。
        /// </summary>
        public const string MSGID_W00008 = "W00008";

        /// <summary>
        /// 該当のデータは他の端末({0}:{1})で使用中です。
        /// </summary>
        public const string MSGID_W00009 = "W00009";

        /// <summary>
        /// {0}が１件も選択されていません。１件以上選択して下さい。
        /// </summary>
        public const string MSGID_W00011 = "W00011";

        /// <summary>
        /// 該当のデータは別画面で使用中です。
        /// </summary>
        public const string MSGID_W00012 = "W00012";

        /// <summary>
        /// 現在の利用者ではこの機能は使用できません。
        /// </summary>
        public const string MSGID_W00014 = "W00014";

        /// <summary>
        /// 該当する利用者IDが存在しません。
        /// </summary>
        public const string MSGID_W00015 = "W00015";

        /// <summary>
        /// パスワードが間違えています。
        /// </summary>
        public const string MSGID_W00016 = "W00016";

        /// <summary>
        /// {0}の形式に誤りがあります。{1}
        /// </summary>
        public const string MSGID_W00017 = "W00017";

        /// <summary>
        /// 番号間指定が正しくありません。&#10;&#10;&#10;&#10;項目間の大小関係を確認してください。
        /// </summary>
        public const string MSGID_W00018 = "W00018";

        /// <summary>
        /// 検索条件が未設定です。１つ以上の項目を設定してください。
        /// </summary>
        public const string MSGID_W00019 = "W00019";

        /// <summary>
        /// 対象のデータは、既に削除されていたため編集モードにできません。
        /// </summary>
        public const string MSGID_W00020 = "W00020";

        /// <summary>
        /// 対象の契約が別画面で使用中のため、{0}処理はできません。
        /// </summary>
        public const string MSGID_W00021 = "W00021";

        /// <summary>
        /// 対象の契約が他の端末({0}:{1})で使用中のため、{2}処理はできません。
        /// </summary>
        public const string MSGID_W00022 = "W00022";

        /// <summary>
        /// {0}は{1}以上の値を入力して下さい。
        /// </summary>
        public const string MSGID_W00023 = "W00023";

        /// <summary>
        /// 指定された{0}は存在しません。
        /// </summary>
        public const string MSGID_W00024 = "W00024";

        /// <summary>
        /// {0}に過去の日付が指定されています。未来の日付を指定してください。
        /// </summary>
        public const string MSGID_W00025 = "W00025";

        /// <summary>
        /// ログイン中の利用者情報に登録されているFelicaIDと一致しません。
        /// </summary>
        public const string MSGID_W00026 = "W00026";

        /// <summary>
        /// ログイン中の利用者情報にFelicaIDが登録されていません。
        /// </summary>
        public const string MSGID_W00027 = "W00027";

        /// <summary>
        /// {0}が選択されていません。
        /// </summary>
        public const string MSGID_W00028 = "W00028";

        /// <summary>
        /// 選択された{0}は他の端末により削除された可能性があります。再度、選択してください。
        /// </summary>
        public const string MSGID_W00029 = "W00029";

        /// <summary>
        /// 不正な文字が入力されています。数字またはハイフンを入力してください。
        /// </summary>
        public const string MSGID_W00030 = "W00030";

        /// <summary>
        /// 口座名義人として使用できない文字[{0}]が含まれています。
        /// </summary>
        public const string MSGID_W00031 = "W00031";

        /// <summary>
        /// 未来日付を指定して入金を処理することはできません。&#10;&#10;{0}を再度確認して下さい。
        /// </summary>
        public const string MSGID_W00032 = "W00032";

        /// <summary>
        /// 選択された{0}は既に削除されています。
        /// </summary>
        public const string MSGID_W00033 = "W00033";

        /// <summary>
        /// 未来日付を指定してください。
        /// </summary>
        public const string MSGID_W00034 = "W00034";

        /// <summary>
        /// 指定された{0}が見つかりません。
        /// </summary>
        public const string MSGID_W00035 = "W00035";

        #endregion

        #region エラーメッセージ

        /// <summary>
        /// 想定外のシステムエラーが発生しました。&#10;&#10;システム管理者へ連絡してください。&#10;&#10;{0}
        /// </summary>
        public const string MSGID_E00001 = "E00001";

        /// <summary>
        /// データの修正に失敗しました。&#10;&#10;&#10;&#10;ただいま処理が大変混み合っています。&#10;&#10;しばらく経ってから再度、処理してください。
        /// </summary>
        public const string MSGID_E00002 = "E00002";

        /// <summary>
        /// データの取得に失敗しました。&#10;&#10;&#10;&#10;ただいま処理が大変混み合っています。&#10;&#10;しばらく経ってから再度、処理してください。
        /// </summary>
        public const string MSGID_E00003 = "E00003";

        /// <summary>
        /// データの取得に失敗しました。&#10;&#10;&#10;&#10;他端末により変更された可能性があります。
        /// </summary>
        public const string MSGID_E00004 = "E00004";

        /// <summary>
        /// 「{0}」における登録可能件数を超えたため処理に失敗しました。&#10;&#10;&#10;&#10;システム管理者へ連絡してください。
        /// </summary>
        public const string MSGID_E00005 = "E00005";

        /// <summary>
        /// 既に起動されています。
        /// </summary>
        public const string MSGID_E00006 = "E00006";

        /// <summary>
        /// 選択行の取得に失敗しました。
        /// </summary>
        public const string MSGID_E00007 = "E00007";

        /// <summary>
        /// 該当の情報は更新されています。
        /// </summary>
        public const string MSGID_E00008 = "E00008";

        /// <summary>
        /// 対象の情報が更新されています。&#10;&#10;再度検索後、操作をやり直してください。
        /// </summary>
        public const string MSGID_E00009 = "E00009";

        #endregion

        #region 確認メッセージ

        /// <summary>
        /// {0}を削除します。よろしいですか？
        /// </summary>
        public const string MSGID_Q00001 = "Q00001";

        /// <summary>
        /// 検索条件の初期化を行います。よろしいですか？
        /// </summary>
        public const string MSGID_Q00002 = "Q00002";

        /// <summary>
        /// 入力内容を初期化を行います。よろしいですか？
        /// </summary>
        public const string MSGID_Q00003 = "Q00003";

        /// <summary>
        /// 入力内容に変更があります。&#10;入力内容は破棄されますがよろしいですか？
        /// </summary>
        public const string MSGID_Q00004 = "Q00004";

        /// <summary>
        /// ログインせずに終了しますか？
        /// </summary>
        public const string MSGID_Q00005 = "Q00005";

        /// <summary>
        /// {0}を登録します。よろしいですか？
        /// </summary>
        public const string MSGID_Q00006 = "Q00006";

        /// <summary>
        /// {0}を取り消します。よろしいですか？
        /// </summary>
        public const string MSGID_Q00007 = "Q00007";

        /// <summary>
        /// {0}の情報が修正されています。このまま削除を行うと変更内容が破棄されますが、よろしいですか？
        /// </summary>
        public const string MSGID_Q00008 = "Q00008";

        /// <summary>
        /// 選択された{0}は既に削除されています。処理を続行しますか？
        /// </summary>
        public const string MSGID_Q00009 = "Q00009";

        /// <summary>
        /// {0}を修正します。よろしいですか？
        /// </summary>
        public const string MSGID_Q00010 = "Q00010";

        /// <summary>
        /// {0}に過去日付が指定されています。&#10;&#10;このまま処理を続けてよろしいですか？
        /// </summary>
        public const string MSGID_Q00011 = "Q00011";

        /// <summary>
        /// {0}が設定されていませんが、{1}を開いてよろしいですか？{2}
        /// </summary>
        public const string MSGID_Q00012 = "Q00012";

        /// <summary>
        /// {0}を更新します。よろしいですか？
        /// </summary>
        public const string MSGID_Q00013 = "Q00013";

        #endregion

        #endregion

        #region 静的プロパティ(private)

        /// <summary>
        /// ファイル読込エラー時のメッセージ
        /// </summary>
        private static string FILE_READ_ERROR = "メッセージファイルの読込が失敗しました。\nシステム管理者に連絡してください。\n内容：{0}";

        /// <summary>
        /// タグ名(data)
        /// </summary>
        private static string TAG_NAME_DATA = "data";

        /// <summary>
        /// タイプ名(id)
        /// </summary>
        private static string TYPE_NAME_ID = "id";

        /// <summary>
        /// タイプ名(msg)
        /// </summary>
        private static string TYPE_NAME_MSG = "msg";

        /// <summary>
        /// メッセージを保持するディクショナリ
        /// </summary>
        private static Dictionary<string, string> MessageDic = new Dictionary<string,string>();

        #endregion

        #region 静的メソッド(public)

        #region LoadMessageFile
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： LoadMessageFile
        /// <summary>
        /// メッセージファイルを読み込みます
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>成否</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// 2010/10/21　稗田　　    修正(FAX送信改善)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool LoadMessageFile(string path)
        {
            try
            {
                // メッセージファイルを読み込む
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                // タグ名が｢data｣のエレメントを取得
                XmlNodeList elemList = doc.GetElementsByTagName(TAG_NAME_DATA);

                // 取得されたエレメント分繰返し
                foreach (XmlNode node in elemList)
                {
                    // ディクショナリに追加
                    MessageDic[node.Attributes[TYPE_NAME_ID].Value] = node.Attributes[TYPE_NAME_MSG].Value;
                }

                return true;
            }
            catch(Exception e)
            {
                // エラー内容を表示
                MessageBox.Show(string.Format(FILE_READ_ERROR, e.Message));

                return false;
            }
        }
        #endregion

        #region GetMessage
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetMessage
        /// <summary>
        /// メッセージ文字列を取得します
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">メッセージID</param>
        /// <returns>メッセージ文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string GetMessage(string id)
        {
            // メッセージIDに一致するメッセージ文字列を戻す
            return MessageDic[id];
        }
        #endregion

        #endregion
    }
    #endregion
}
