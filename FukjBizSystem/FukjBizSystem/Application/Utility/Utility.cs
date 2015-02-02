using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FukjBizSystem.Control;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Utility
{
    class Utility
    {
        #region OpenFormCheck

        #region OpenFormCheck
        ///////////////////////////////////////////////////////////////
        /// メソッド：OpenFormCheck
        /// <summary>
        /// ウィンドウが開かれているかをチェック
        /// 開かれている場合はフォーカスをあてる
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/07/21　吉浦  　    攻玉寮流用
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static Boolean OpenFormCheck(String formName)
        {
            return OpenFormCheck(formName, false);
        }
        #endregion

        #region OpenFormCheck
        ///////////////////////////////////////////////////////////////
        /// メソッド：OpenFormCheck
        /// <summary>
        /// ウィンドウが開かれているかをチェック
        /// 開かれている場合はフォーカスをあてる
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/07/21　吉浦  　    攻玉寮流用
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static Boolean OpenFormCheck(String formName, Boolean messageFlag)
        {
            try
            {
                // 開かれているフォームを取得
                foreach (Form form in System.Windows.Forms.Application.OpenForms)
                {
                    if (form.Name.Equals(formName))
                    {
                        // フォームが開かれている
                        form.Focus();

                        if (messageFlag)
                        {
                            MessageForm.Show2(MessageForm.DispModeType.Error,
                                "別のウィンドウが開いています。\r\n" +
                                "ウィンドウを閉じてから作業を行ってください。");
                        }

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, ex.Message);
                return true;
            }
        }
        #endregion

        #endregion

        #region SetComboBoxList
        /// <summary>
        /// データテーブルのデータをコンボボックスに設定する
        /// </summary>
        /// <param name="targetComboBox">設定するコンボボックス</param>
        /// <param name="dataTable">設定するデータテーブル</param>
        /// <param name="DisplayMember">コンボボックスに表示するカラム</param>
        /// <param name="ValueMember">SelectedValueでコンボボックスより取得するカラム</param>
        /// <param name="addEmpty">~行を追加するか</param>
        public static void SetComboBoxList(
            System.Windows.Forms.ComboBox targetComboBox,
            DataTable dataTable,
            string DisplayMember,
            string ValueMember,
            bool addEmpty)
        {
            // 初回のIndexを保持
            object selectedvalue = targetComboBox.SelectedValue;

            // 表示用にデータテーブルを作成（NULL制約を外す）
            DataTable dt = new DataTable();
            foreach (DataColumn col in dataTable.Columns)
            {
                dt.Columns.Add(col.ColumnName, col.DataType);
            }

            // 行データの詰め替え（MERGEは制約も移るため）
            foreach (DataRow row in dataTable.Rows)
            {
                dt.ImportRow(row);
            }

            // 空行追加（値を設定しない）
            if (addEmpty)
            {
                DataRow row = dt.NewRow();
                row[DisplayMember] = string.Empty;
                dt.Rows.InsertAt(row, 0);
            }

            // コンボボックスにデータを設定
            targetComboBox.DataSource = dt;
            targetComboBox.DisplayMember = DisplayMember;
            targetComboBox.ValueMember = ValueMember;
            // 2012/03/16 taniguchi 変更
            if (selectedvalue != null)
            {
                targetComboBox.SelectedValue = selectedvalue;
            }
            //targetComboBox.SelectedIndex = -1;
        }
        #endregion

        #region SetComboBoxColumnList
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetComboBoxColumnList
        /// <summary>
        /// データテーブルのデータをDataGridViewのコンボボックスカラムに設定する
        /// </summary>
        /// <param name="targetComboBoxColumn">設定するコンボボックスカラム</param>
        /// <param name="dataTable">設定するデータテーブル</param>
        /// <param name="DisplayMember">コンボボックスに表示するカラム</param>
        /// <param name="ValueMember">SelectedValueでコンボボックスより取得するカラム</param>
        /// <param name="addEmpty">~行を追加するか</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/22  小松        新規作成(SetComboBoxListを移植)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void SetComboBoxColumnList(
            System.Windows.Forms.DataGridViewComboBoxColumn targetComboBoxColumn,
            DataTable dataTable,
            string DisplayMember,
            string ValueMember,
            bool addEmpty)
        {
            // 表示用にデータテーブルを作成（NULL制約を外す）
            DataTable dt = new DataTable();
            foreach (DataColumn col in dataTable.Columns)
            {
                dt.Columns.Add(col.ColumnName, col.DataType);
            }

            // 行データの詰め替え（MERGEは制約も移るため）
            foreach (DataRow row in dataTable.Rows)
            {
                dt.ImportRow(row);
            }

            // 空行追加（値を設定しない）
            if (addEmpty)
            {
                DataRow row = dt.NewRow();
                row[DisplayMember] = string.Empty;
                row[ValueMember] = string.Empty;
                dt.Rows.InsertAt(row, 0);
            }

            // コンボボックスにデータを設定
            targetComboBoxColumn.DataSource = dt;
            targetComboBoxColumn.DisplayMember = DisplayMember;
            targetComboBoxColumn.ValueMember = ValueMember;
        }
        #endregion

        #region SetListBoxSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetListBoxSource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="dataTable"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void SetListBoxSource(ListBox listBox, DataTable dataTable, string displayMember, string valueMember)
        {
            listBox.DataSource = dataTable;
            listBox.DisplayMember = displayMember;
            listBox.ValueMember = valueMember;
        }
        #endregion

        #region IsDecimal
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsDecimal
        /// <summary>
        /// Is decimal or not?
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// TRUE: decimal
        /// FALSE: Not decimal
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool IsDecimal(string input)
        {
            decimal num;

            return Decimal.TryParse(input, out num) ? true : false;
        }
        #endregion

        #region IsDateFormat
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsDateFormat
        /// <summary>
        /// Is Date time format or not?
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// TRUE: datetime format
        /// FALSE: Not a datetime format
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool IsDateFormat(string input)
        {
            DateTime date;

            return DateTime.TryParseExact(input, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ? true : false;
        }
        #endregion

        #region IsZipCode
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsZipCode
        /// <summary>
        /// Is zipcode format or not?
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// TRUE: zipcode format
        /// FALSE: Not a zipcode format
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool IsZipCode(string input)
        {
            string zipRegex = @"^[0-9]{3}[-][0-9]{4}$";

            if (!Regex.Match(input, zipRegex).Success)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region IsPhoneNumber
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsPhoneNumber
        /// <summary>
        /// Is phone number format or not?
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// TRUE: phone number format
        /// FALSE: Not a phone number format
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool IsPhoneNumber(string input)
        {
            //string phoneRegex = @"^[0-9]{3}[-][0-9]{4}[-][0-9]{4}$";
            string phoneRegex = @"^0\d{1,4}-\d{1,4}-\d{4}$";


            if (!Regex.Match(input, phoneRegex).Success)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region IsNumAndNegative
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsNumAndNegative
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool IsNumAndNegative(string input)
        {
            string[] letters = input.ToCharArray().Select(c => c.ToString()).ToArray();

            if ((input.Distinct().Count() == 1 && letters.Contains("-")) // "-" only
                || !letters.Contains("-")) // number only
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ConvertToHeisei
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： ConvertToHeisei
        /// <summary>
        ///
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string ConvertToHeisei(int nendo)
        {
            CultureInfo culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            DateTime target = new DateTime(nendo, 8, 1);
            return target.ToString("yy", culture);
        }
        #endregion

        #region ConvertToSeireki
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： ConvertToSeireki
        /// <summary>
        ///
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string ConvertToSeireki(int nendo)
        {
            if (nendo == 0) { nendo = 1; }

            CultureInfo ci = new CultureInfo("ja-JP");
            ci.DateTimeFormat.Calendar = new JapaneseCalendar();
            DateTime dt = DateTime.ParseExact("" + nendo, "yy", ci);
            return dt.Year.ToString();
        }
        #endregion

        #region IsNumAndSlash
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsNumAndSlash
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool IsNumAndSlash(string input)
        {
            string regEx = @"^[0-9\/\b]*$";

            if (!Regex.Match(input, regEx).Success)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region IsValidKyokaiNo
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： IsValidKyokaiNo
        /// <summary>
        /// 協会No（開始）must be less than 協会No（終了）
        /// </summary>
        /// <param name="kyokaiFrom1TextBox"></param>
        /// <param name="kyokaiFrom2TextBox"></param>
        /// <param name="kyokaiFrom3TextBox"></param>
        /// <param name="kyokaiTo1TextBox"></param>
        /// <param name="kyokaiTo2TextBox"></param>
        /// <param name="kyokaiTo3TextBox"></param>
        /// <returns>
        /// TRUE: valid
        /// FALSE: invalid
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  AnhNV　    新規作成
        /// 2014/11/04  HuyTX　    Add case input full
        /// 2014/11/29  kiyokuni　 判定が間違っているので変更
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static bool IsValidKyokaiNo
            (
                ZTextBox kyokaiFrom1TextBox,
                ZTextBox kyokaiFrom2TextBox,
                ZTextBox kyokaiFrom3TextBox,
                ZTextBox kyokaiTo1TextBox,
                ZTextBox kyokaiTo2TextBox,
                ZTextBox kyokaiTo3TextBox
            )
        {
            //check case input full for KyokaiFrom and KyokaiTo
            string kyokaiFrom = string.Concat(kyokaiFrom1TextBox.Text.Trim(), kyokaiFrom2TextBox.Text.Trim(), kyokaiFrom3TextBox.Text.Trim());
            string kyokaiTo = string.Concat(kyokaiTo1TextBox.Text.Trim(), kyokaiTo2TextBox.Text.Trim(), kyokaiTo3TextBox.Text.Trim());

            //2014.11.19 Mod kiyokuni ---------- start
            if (string.IsNullOrEmpty(kyokaiFrom) || string.IsNullOrEmpty(kyokaiTo))
            {
                return true;
            }
            if (string.Compare(kyokaiFrom.Trim(), kyokaiTo.Trim()) > 0)
            {
                return false;
            }

            //if (kyokaiFrom.Length == 10 && kyokaiTo.Length == 10)
            //{
                //if (Convert.ToDecimal(kyokaiFrom) > Convert.ToDecimal(kyokaiTo))
                //{
                //    return false;
                //}
                //return true;
            //}
            //// 協会No（開始）
            //string kyokaiFrom1 = string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) ? "0" : kyokaiFrom1TextBox.Text;
            //string kyokaiFrom2 = string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) ? "0" : kyokaiFrom2TextBox.Text;
            //string kyokaiFrom3 = string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) ? "0" : kyokaiFrom3TextBox.Text;
            //// 協会No（終了）
            //string kyokaiTo1 = string.IsNullOrEmpty(kyokaiTo1TextBox.Text) ? "99" : kyokaiTo1TextBox.Text;
            //string kyokaiTo2 = string.IsNullOrEmpty(kyokaiTo2TextBox.Text) ? "99" : kyokaiTo2TextBox.Text;
            //string kyokaiTo3 = string.IsNullOrEmpty(kyokaiTo3TextBox.Text) ? "999999" : kyokaiTo3TextBox.Text;

            //if (Convert.ToDecimal(kyokaiFrom1) > Convert.ToDecimal(kyokaiTo1)
            //    || Convert.ToDecimal(kyokaiFrom2) > Convert.ToDecimal(kyokaiTo2)
            //    || Convert.ToDecimal(kyokaiFrom3) > Convert.ToDecimal(kyokaiTo3))
            //{
            //    return false;
            //}
            //2014.11.19 Mod kiyokuni ---------- end


            return true;
        }
        #endregion

        #region IsSaiSaisuiTarget
        ///////////////////////////////////////////////////////////////
        // メソッド名 ： IsSaiSaisuiTarget
        /// <summary>
        /// 11条水質のスクリーニングかの判定
        /// </summary>
        /// <param name="hoteiKbn"></param>
        /// <param name="screeningKbn"></param>
        /// <returns>true:スクリーニング/false:以外</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/07  habu　　    新規作成
        /// 2015/01/11  小松　　    外観検査から流用
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static bool IsSaiSaisuiTarget(string hoteiKbn, string screeningKbn)
        {
            // 11条水質の、スクリーニング or スクリーニング+フォローのみ再採水対象とする
            if (hoteiKbn != Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU)
            {
                return false;
            }
            if (screeningKbn != Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING
                && screeningKbn != Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING_FOLLOW)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
