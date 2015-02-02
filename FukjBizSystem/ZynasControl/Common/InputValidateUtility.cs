using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zynas.Control.Common
{
    /// <summary>
    /// 入力文字列チェック用クラス
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  habu　　    新規作成
    /// </history>
    public class InputValidateUtility
    {
        #region 符号指定

        /// <summary>
        /// 符号指定
        /// </summary>
        public enum SignFlg
        {
            /// <summary>
            /// 正数及び負数
            /// </summary>
            PositiveNegative,

            /// <summary>
            /// 正数
            /// </summary>
            Positive,

            /// <summary>
            /// 負数
            /// </summary>
            Negative,
        }

        #endregion

        #region Fields

        /// <summary>
        /// KeyPressFilterキャッシュ(同じフォーマットのものをキャッシュする)
        /// </summary>
        private static Dictionary<string, KeyPressEventHandler> cachedKeyPressFilter = new Dictionary<string, KeyPressEventHandler>();

        #endregion

        #region ValidateString
        /// <summary>
        /// 入力文字列が書式文字列に合致するかチェックする(validate input text whether it matches to validFormat)
        /// </summary>
        /// <param name="text">入力文字列(input text)</param>
        /// <param name="validFormat">書式文字列(複数指定可)(format string (can apply combination))</param>
        /// <returns>入力文字列が書式に合致する場合true(returns true if input text is matches to validFormat)</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// 2015/02/01  habu　　    半角/全角スペースの指定を追加
        /// </history>
        public static bool ValidateString(string text, string validFormat)
        {
            const char HALF_WHITE_SPACE = ' ';
            const char FULL_WHITE_SPACE = '　';

            bool result = true;

            // 書式指定なしの場合は常にOKとする
            if (string.IsNullOrEmpty(validFormat))
            {
                return true;
            }

            // 各文字ごとにチェック
            foreach (char c in text)
            {
                bool charOk = false;

                // NOTICE 処理速度などが問題であれば、適宜処理の見直しを行う -> 特に問題はない模様

                // 指定書式文字の全てでチェックエラーとなれば、入力文字列全体をエラーとする
                // 半角英字チェック
                if (validFormat.Contains('A'))
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        charOk = true;
                    }
                }
                // 半角英字チェック
                if (validFormat.Contains('a'))
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        charOk = true;
                    }
                }
                // 数値チェック
                if (validFormat.Contains('9'))
                {
                    string charList = "1234567890";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                // 記号チェック
                if (validFormat.Contains('#'))
                {
                    string charList = "+-()./";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                // 全角カナチェック
                if (validFormat.Contains('ア'))
                {
                    if (IsFullwidthKatakana(c))
                    {
                        charOk = true;
                    }
                }
                // 半角カナチェック
                if (validFormat.Contains('ｱ'))
                {
                    if (IsHalfwidthKatakana(c))
                    {
                        charOk = true;
                    }
                }
                // 半角スペースチェック
                if (validFormat.Contains(HALF_WHITE_SPACE))
                {
                    if (c == HALF_WHITE_SPACE)
                    {
                        charOk = true;
                    }
                }
                // 全角スペースチェック
                if (validFormat.Contains(FULL_WHITE_SPACE))
                {
                    if (c == FULL_WHITE_SPACE)
                    {
                        charOk = true;
                    }
                }
                #region 個別記号文字
                if (validFormat.Contains('+'))
                {
                    string charList = "+";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                if (validFormat.Contains('-'))
                {
                    string charList = "-";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                if (validFormat.Contains('('))
                {
                    string charList = "(";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                if (validFormat.Contains(')'))
                {
                    string charList = ")";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                if (validFormat.Contains('.'))
                {
                    string charList = ".";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                if (validFormat.Contains('/'))
                {
                    string charList = "/";

                    if (charList.Contains(c))
                    {
                        charOk = true;
                    }
                }
                #endregion

                if (!charOk)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
        #endregion

        #region ValidNumber
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalPrecisionLength"></param>
        /// <param name="scaleLength"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static bool ValidNumber(string text, int totalPrecisionLength, int scaleLength, SignFlg sign)
        {
            //decimal outNum;

            // これは2重に行う形になるかも(不要か?)
            // 数値としてパースできないものは対象外
            //if (!decimal.TryParse(text, out outNum))
            //{
            //    return false;
            //}

            // +指定のみで-を含む場合はエラー
            if (sign == SignFlg.Positive && text.Contains('-'))
            {
                return false;
            }

            // 先頭以外に符号がある場合はエラー
            if (text.IndexOf('-') >= 1)
            {
                return false;
            }

            // 符号を複数含む場合はエラー
            if (text.IndexOf('-') != text.LastIndexOf('-'))
            {
                return false;
            }

            int decimalPoint = text.Replace("-", "").IndexOf('.');
            int decimalPointLast = text.Replace("-", "").LastIndexOf('.');

            // 小数部なし指定の場合に小数点を含む場合はエラー
            if (scaleLength <= 0 && decimalPoint != -1)
            {
                return false;
            }

            // 小数部指定桁数を超える場合はエラー
            if (decimalPoint >= 0 && text.Replace("-", "").Substring(decimalPoint).Length - 1 > scaleLength)
            {
                return false;
            }

            // 小数点を複数含む場合はエラー
            if (decimalPoint != decimalPointLast)
            {
                return false;
            }

            // 整数部指定桁数を超える場合はエラー
            if (decimalPoint >= 0)
            {
                if (text.Replace("-", "").Substring(0, decimalPoint).Length > (totalPrecisionLength - scaleLength))
                {
                    return false;
                }
            }
            else
            {
                if (text.Replace("-", "").Length > (totalPrecisionLength - scaleLength))
                {
                    return false;
                }
            }

            // 数値桁数が総桁数を超える場合はエラー
            if (text.Replace("-", "").Replace(".", "").Length > totalPrecisionLength)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ValidateZipCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public static bool ValidateZipCd(string text)
        {
            // TODO 以下の形式のみ許可する、、、としたいが、移行データのとの兼ね合いがある
            // NOTICE 7桁郵便番号(xxx-xxxx)
            // NOTICE 5桁郵便番号(xxx-xx)

            if (!ValidateString(text, "9-"))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ValidateTelNo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public static bool ValidateTelNo(string text)
        {
            // TODO 以下の形式のみ許可する、、、としたいが、移行データのとの兼ね合いがある
            // NOTICE (携帯、IP電話（xxx-xxxx-xxxx）)
            // NOTICE (固定電話（xxxxxxxxxx + -が2つ）)

            if (!ValidateString(text, "9-"))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region CreateNumerFormat
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slgn"></param>
        /// <returns></returns>
        public static string CreateNumerFormat(int scaleLength, SignFlg signFlg)
        {
            string numberFormat = string.Empty;

            if (signFlg == SignFlg.PositiveNegative)
            {
                numberFormat = "9+-";
                if (scaleLength > 0) { numberFormat += "."; }
            }
            else if (signFlg == SignFlg.Positive)
            {
                numberFormat = "9+";
                if (scaleLength > 0) { numberFormat += "."; }
            }
            else if (signFlg == SignFlg.Negative)
            {
                numberFormat = "9-";
                if (scaleLength > 0) { numberFormat += "."; }
            }
            else
            {
                numberFormat = "9#";
                if (scaleLength > 0) { numberFormat += "."; }
            }

            return numberFormat;
        }
        #endregion

        #region CreateKeyPressFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validFormat"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        private static KeyPressEventHandler CreateKeyPressFilter(string validFormat)
        {
            KeyPressEventHandler handler = delegate(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !ValidateString(e.KeyChar.ToString(), validFormat))
                {
                    e.Handled = true;
                }
            };

            return handler;
        }
        #endregion

        #region GetKeyPressFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validFormat"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public static KeyPressEventHandler GetKeyPressFilter(string validFormat)
        {
            if (cachedKeyPressFilter.ContainsKey(validFormat))
            {
                return cachedKeyPressFilter[validFormat];
            }
            else
            {
                cachedKeyPressFilter.Add(validFormat, CreateKeyPressFilter(validFormat));
                return cachedKeyPressFilter[validFormat];
            }
        }
        #endregion

        #region CreateNumberKeyPressFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalPrecisionLength"></param>
        /// <param name="scaleLength"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/08  habu　　    新規作成
        /// </history>
        public static KeyPressEventHandler CreateNumberKeyPressFilter(int totalPrecisionLength, int scaleLength, SignFlg sign)
        {
            KeyPressEventHandler handler = delegate(object sender, KeyPressEventArgs e)
            {
                string validFormat = CreateNumerFormat(scaleLength, sign);

                if (char.IsControl(e.KeyChar))
                {
                    return;
                }

                // 入力文字単独でのチェック
                if (!char.IsControl(e.KeyChar) && !ValidateString(e.KeyChar.ToString(), validFormat))
                {
                    e.Handled = true;
                    return;
                }

                // NOTICE 現状では、テキストボックス派生クラスのみ対象とする
                if (!(sender is System.Windows.Forms.TextBoxBase))
                {
                    return;
                }

                System.Windows.Forms.TextBoxBase control = (System.Windows.Forms.TextBoxBase)sender;
                
                // 編集前文字列
                string numberStr = control.Text;
                
                // 編集後文字列(現在のカーソル位置に入力文字を挿入)
                string checkTargetStr = numberStr.Insert(control.SelectionStart, e.KeyChar.ToString());

                if (!ValidNumber(checkTargetStr, totalPrecisionLength, scaleLength, sign))
                {
                    e.Handled = true;
                }
            };

            return handler;
        }
        #endregion

        #region GetNumberKeyPressFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalPrecisionLength"></param>
        /// <param name="scaleLength"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/08  habu　　    新規作成
        /// </history>
        public static KeyPressEventHandler GetNumberKeyPressFilter(int totalPrecisionLength, int scaleLength, SignFlg sign)
        {
            string key = string.Format("{0},{1},{2}", totalPrecisionLength, scaleLength, sign);

            if (cachedKeyPressFilter.ContainsKey(key))
            {
                return cachedKeyPressFilter[key];
            }
            else
            {
                cachedKeyPressFilter.Add(key, CreateNumberKeyPressFilter(totalPrecisionLength, scaleLength, sign));
                return cachedKeyPressFilter[key];
            }
        }
        #endregion

        #region 文字判定用

        /// <summary>
        /// 指定した Unicode 文字が、全角カタカナかどうかを示します。
        /// </summary>
        /// <param name="c">評価する Unicode 文字。</param>
        /// <returns>c が全角カタカナである場合は true。それ以外の場合は false。</returns>
        public static bool IsFullwidthKatakana(char c)
        {
            //「ダブルハイフン」から「コト」までと、カタカナフリガナ拡張と、
            //濁点と半濁点を全角カタカナとする
            //中点と長音記号も含む
            return ('\u30A0' <= c && c <= '\u30FF')
                || ('\u31F0' <= c && c <= '\u31FF')
                || ('\u3099' <= c && c <= '\u309C');
        }

        /// <summary>
        /// 指定した Unicode 文字が、半角カタカナかどうかを示します。
        /// </summary>
        /// <param name="c">評価する Unicode 文字。</param>
        /// <returns>c が半角カタカナである場合は true。それ以外の場合は false。</returns>
        public static bool IsHalfwidthKatakana(char c)
        {
            //「･」から「ﾟ」までを半角カタカナとする
            return '\uFF65' <= c && c <= '\uFF9F';
        }

        #endregion
    }
}
