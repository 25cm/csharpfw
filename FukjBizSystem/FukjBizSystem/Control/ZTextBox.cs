using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Zynas.Control;
using Zynas.Control.Common;

namespace FukjBizSystem.Control
{
    /// <summary>
    /// 拡張テキストボックスクラス
    /// 継承元：TextBoxコントロール
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  habu　　    Modified DomainControl methods/props
    /// </history>
    public partial class ZTextBox : TextBox
    {
        #region 入力モード
        /// <summary>
        /// 入力モード
        /// </summary>
        public enum InputMode
        {
            /// <summary>
            /// 指定なし
            /// </summary>
            None,

            /// <summary>
            /// 数値
            /// </summary>
            Number,

            /// <summary>
            /// 郵便番号,電話番号
            /// </summary>
            ZipCdTelNo,

            /// <summary>
            /// 数字+記号(数値関連[InputManの"#"に該当])+英字（大文字、小文字）
            /// </summary>
            Aa9Mark,

            /// <summary>
            /// ひらがな
            /// </summary>
            Hiragana,

        }
        #endregion

        #region フィールド

        // 背景色を変える読み取り専用にするフラグ
        private bool customReadOnly = false;

        // ドロップダウン機能を使用するかどうかのフラグ
        private bool allowDropDownFlg = false;

        private KeyPressEventHandler currentStdKeyPressHandler = null;

        // ドメイン対応
        #region ドメイン対応

        private ZControlDomain controlDomain;

        private InputValidateUtility.SignFlg signFlg;

        private int numberScaleLength = 0;

        /// <summary>
        /// ZT_STD_NAMEで長さを省略した場合の桁数
        /// </summary>
        private static readonly int DEFAULT_MAX_LENGTH_NAME = 1023;
        /// <summary>
        /// ZT_STD_NUMで長さを省略した場合の桁数
        /// </summary>
        private static readonly int DEFAULT_MAX_LENGTH_NUM = 9;

        #endregion

        // カスタム入力制御
        private InputMode customInputMode;

        #region イベント定義用
        /// <summary>
        /// 背景色を変える読み取り専用プロパティ変更のイベントハンドラデリゲート
        /// </summary>
        /// <param name="sender">送信元</param>
        /// <param name="e">現在の読み取り専用状態を含む</param>
        public delegate void CustomReadOnlyChangedEventHandler(object sender, Zynas.Control.CustomReadOnlyChangedEventArgs e);

        /// <summary>
        /// 背景色を変える読み取り専用プロパティ変更時のイベント
        /// </summary>
        [Description("背景色を変える読み取り専用プロパティが変更されたときに発生します。"), Category("プロパティ変更")]
        private event CustomReadOnlyChangedEventHandler CustomReadOnlyChanged;

        #endregion

        #endregion

        #region プロパティ

        #region AllowDropDown
        /// <summary>
        /// ドロップダウンを表示するかどうかを取得または設定します。
        /// </summary>
        [Description("ドロップダウンの表示を許可するかどうかを取得または設定します。"), Category("動作")]
        public bool AllowDropDown
        {
            get { return allowDropDownFlg; }
            set
            {
                if (allowDropDownFlg == value)
                {
                    return;
                }
                allowDropDownFlg = value;
                //this.DropDown.AllowDrop = value;
            }
        }
        #endregion

        #region CustomReadOnly
        /// <summary>
        /// 背景色を変える読み取り専用プロパティ
        /// </summary>
        [Description("読み取り専用にするかどうかを取得または設定し、背景色を変更します。"), Category("動作")]
        public bool CustomReadOnly
        {
            get { return customReadOnly; }
            set
            {
                if (customReadOnly == value)
                {
                    return;
                }

                customReadOnly = value;
                // イベント発行準備
                raiseCustomReadOnlyChanged(value);
            }
        }
        #endregion

        #region CustomInputMode
        /// <summary>
        /// テキストボックスの入力種別を設定します。
        /// </summary>
        [Description("テキストボックスの入力種別を設定します。"), Category("動作")]
        public InputMode CustomInputMode
        {
            get { return this.customInputMode; }
            set { this.customInputMode = value; }
        }
        #endregion

        #region CustomControlDomain
        /// <summary>
        /// テキストボックスのドメインを設定します。
        /// </summary>
        [Description("テキストボックスのドメインを設定します。"), Category("動作")]
        public ZControlDomain CustomControlDomain
        {
            get { return controlDomain; }
            set
            {
                if (controlDomain == value)
                {
                    return;
                }

                this.controlDomain = value;

                SetControlProperty();
            }
        }
        #endregion

        #region Textプロパティのオーバーライド
        /// <summary>
        /// Textプロパティのオーバーライド（Textのトリム） 
        /// </summary>
        public override string Text
        {
            get
            {
                if (string.IsNullOrEmpty(base.Text))
                {
                    return base.Text;
                }
                else
                {
                    // TextプロパティをTrimして返却
                    return base.Text.Trim();
                }
            }
            set
            {
                base.Text = value;
            }
        }
        #endregion

        #endregion

        #region コンストラクタ
        /// <summary>
        /// デザイナで表示時のコンストラクタ
        /// </summary>
        public ZTextBox()
        {
            #region デザイナによる初期化
            InitializeComponent();
            #endregion

            // 共通の初期化
            commonUserInitilization();
        }

        /// <summary>
        /// プログラム実行時のコンストラクタ
        /// </summary>
        /// <param name="container"></param>
        public ZTextBox(IContainer container)
        {
            #region デザイナによる初期化
            container.Add(this);

            InitializeComponent();
            #endregion

            // 共通の初期化
            commonUserInitilization();
        }

        /// <summary>
        /// ユーザーによる共通の初期化処理
        /// </summary>
        private void commonUserInitilization()
        {
            // 読み取り専用プロパティ変更時のイベントを登録
            this.CustomReadOnlyChanged += new CustomReadOnlyChangedEventHandler(this.ZTextBox_CustomReadOnlyChanged);
        }
        #endregion

        #region イベント定義用

        #region raiseCustomReadOnlyChanged
        /// <summary>
        /// イベント時の引数を準備する処理
        /// </summary>
        /// <param name="readOnlyValue">読み取り専用プロパティの値</param>
        private void raiseCustomReadOnlyChanged(bool readOnlyValue)
        {
            // イベント引数
            CustomReadOnlyChangedEventArgs e = new CustomReadOnlyChangedEventArgs(readOnlyValue);

            // イベント発行関数に渡す
            OnCustomReadOnlyChanged(e);
        }
        #endregion

        #region OnCustomReadOnlyChanged
        /// <summary>
        /// イベント発行処理
        /// </summary>
        /// <param name="eArgs">読み取り専用フラグを含むイベント引数</param>
        protected virtual void OnCustomReadOnlyChanged(CustomReadOnlyChangedEventArgs eArgs)
        {
            if (CustomReadOnlyChanged != null)
            {
                // イベントハンドラが登録されているときイベントを発行
                CustomReadOnlyChanged(this, eArgs);
            }
        }
        #endregion

        #region OnKeyPress
        /// <summary>
        /// 入力を制御する
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (this.customInputMode)
            {
                case InputMode.None:

                    break;

                case InputMode.Number:

                    if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
                    {
                        e.Handled = true;
                    }

                    break;

                case InputMode.ZipCdTelNo:

                    if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '-') && (e.KeyChar != '\b'))
                    {
                        e.Handled = true;
                    }

                    break;

                case InputMode.Aa9Mark:

                    string enableString = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ+-$%/,._@";

                    if (e.KeyChar != '\b' && !enableString.Contains(e.KeyChar.ToString()))
                    {
                        e.Handled = true;
                        return;
                    }

                    break;

                case InputMode.Hiragana:

                    Regex regex = new Regex(@"^[あ-を]+$");
                    if (e.KeyChar != '\b' && !regex.IsMatch(e.KeyChar.ToString()))
                    {
                        e.Handled = true;
                        return;
                    }

                    break;
            }

            base.OnKeyPress(e);
        }
        #endregion

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 背景色を含む読み取り専用プロパティが変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">読み取り専用フラグを含むイベント引数</param>
        private void ZTextBox_CustomReadOnlyChanged(object sender, CustomReadOnlyChangedEventArgs e)
        {
            // 読み取り専用プロパティを与えられた値に変更
            this.ReadOnly = e.ReadOnly;

            if (e.ReadOnly == true)
            {
                // 読み取り専用状態になるとき

                // タブストップ変更
                this.TabStop = false;
            }
            else
            {
                // 読み取り専用でなくなるとき

                // タブストップ変更
                this.TabStop = true;
            }
        }
        #endregion

        #region ドメイン定義

        /// <summary>
        /// 
        /// </summary>
        private void SetControlProperty()
        {
            const char HALF_WHITE_SPACE = ' ';
            const char FULL_WHITE_SPACE = '　';

            #region 共通プロパティ指定

            // 高さは25ピクセル固定
            //Height = 25;

            #endregion

            #region ドメイン個別プロパティ指定

            // NOTICE ドメイン定義追加の場合は、KeyPressFilterを追加する(必要であれば)
            if (controlDomain == ZControlDomain.ZT_STD_NUM || controlDomain == ZControlDomain.ZG_STD_NUM)
            {
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Right;

                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter(InputValidateUtility.CreateNumerFormat(numberScaleLength, signFlg)));
            }
            else if (controlDomain == ZControlDomain.ZT_STD_CD || controlDomain == ZControlDomain.ZG_STD_CD)
            {
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("Aa9"));
            }
            else if (controlDomain == ZControlDomain.ZT_STD_ALPHA_NUM)
            {
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("Aa9-"));
            }
            else if (controlDomain == ZControlDomain.ZT_STD_NAME || controlDomain == ZControlDomain.ZG_STD_NAME)
            {
                ImeMode = ImeMode.Hiragana;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(null);
            }
            else if (controlDomain == ZControlDomain.ZT_STD_NAME_KANA || controlDomain == ZControlDomain.ZG_STD_NAME_KANA)
            {
                ImeMode = ImeMode.Katakana;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("ア" + FULL_WHITE_SPACE));
            }
            else if (controlDomain == ZControlDomain.ZT_STD_NAME_KANA_HALF || controlDomain == ZControlDomain.ZG_STD_NAME_KANA_HALF)
            {
                ImeMode = ImeMode.KatakanaHalf;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("ｱ" + HALF_WHITE_SPACE));
            }
            else if (controlDomain == ZControlDomain.ZT_STD_NAME_KANA_HALF_BOTH)
            {
                ImeMode = ImeMode.KatakanaHalf;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("アｱ" + HALF_WHITE_SPACE + FULL_WHITE_SPACE));
            }
            else if (controlDomain == ZControlDomain.ZT_HOTEI_KBN)
            {
                MaxLength = 1;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_HOKENJO_CD)
            {
                MaxLength = 2;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_SHISHO_CD)
            {
                MaxLength = 1;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_NENDO)
            {
                MaxLength = 4;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_DT)
            {
                MaxLength = 8;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(null);
            }
            else if (controlDomain == ZControlDomain.ZT_YMD)
            {
                MaxLength = 8;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_NEN_WAREKI)
            {
                MaxLength = 3;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(null);
            }
            else if (controlDomain == ZControlDomain.ZT_NEN)
            {
                MaxLength = 4;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_TSUKI)
            {
                MaxLength = 2;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_BI)
            {
                MaxLength = 2;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_FLG)
            {
                MaxLength = 1;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_TEL_NO)
            {
                MaxLength = 13;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9-"));
            }
            else if (controlDomain == ZControlDomain.ZT_ZIP_CD)
            {
                MaxLength = 8;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9-"));
            }
            else if (controlDomain == ZControlDomain.ZT_SETCHISHA_KBN)
            {
                MaxLength = 1;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_SETCHISHA_CD)
            {
                MaxLength = 7;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_KENSAIN_CD)
            {
                MaxLength = 3;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_CHIKU_CD)
            {
                MaxLength = 5;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_SAISUIIN_CD)
            {
                MaxLength = 5;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_GYOSHA_CD)
            {
                MaxLength = 4;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }
            else if (controlDomain == ZControlDomain.ZT_ADR)
            {
                MaxLength = 80;
                ImeMode = ImeMode.Hiragana;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(null);
            }
            else if (controlDomain == ZControlDomain.ZT_NEN_GETSU)
            {
                MaxLength = 6;
                ImeMode = ImeMode.Off;
                TextAlign = HorizontalAlignment.Left;
                SetStdKeypressFilter(InputValidateUtility.GetKeyPressFilter("9"));
            }

            #endregion

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void SetControlDomain(ZControlDomain domain)
        {
            controlDomain = domain;

            SetControlProperty();
        }

        /// <summary>
        /// (Set standard domain ZT_STD_XXX)
        /// Use this if it nesessary(length not defined and could not confirm at that time)
        /// </summary>
        /// <param name="domain"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(ZControlDomain domain)
        {
            if (domain == ZControlDomain.ZT_STD_NUM || domain == ZControlDomain.ZG_STD_NUM)
            {
                SetStdControlDomain(domain, DEFAULT_MAX_LENGTH_NUM);
            }
            // NOTICE STD_XXX以外が渡された場合、振替える処置が望ましい
            // NOTICE (呼出側で長さが指定されていれば、問題ない)
            else
            {
                SetStdControlDomain(domain, DEFAULT_MAX_LENGTH_NAME);
            }
        }

        /// <summary>
        /// (Set standard domain ZT_STD_XXX and input length)
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="maxLength"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(ZControlDomain domain, int maxLength)
        {
            controlDomain = domain;

            SetControlProperty();

            MaxLength = maxLength;
        }

        /// <summary>
        /// (Set standard domain ZT_STD_XXX and input length, content display alignment)
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="maxLength"></param>
        /// <param name="align"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// 2014/11/06  habu　　    オーバーロードに置換え
        /// </history>
        public void SetStdControlDomain(ZControlDomain domain, int maxLength, HorizontalAlignment align)
        {
            SetStdControlDomain(domain, maxLength);

            TextAlign = align;
        }

        /// <summary>
        /// (Set number standard domain ZT_STD_NUM, integer length, decimal length, sign flg)
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="precisionLength">number integer length(exclude point ".")</param>
        /// <param name="scaleLength">number decimal part length</param>
        /// <param name="sign">PositiveNegative allowed or PositiveOnly allowed</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// 2014/11/07  habu　　    Fixed length calc
        /// </history>
        public void SetStdControlDomain(ZControlDomain domain, int precisionLength, int scaleLength, InputValidateUtility.SignFlg sign)
        {
            controlDomain = domain;
            signFlg = sign;
            numberScaleLength = scaleLength;

            SetControlProperty();

            int signCnt = sign == InputValidateUtility.SignFlg.Positive ? 0 : 1;
            int fpointCnt = scaleLength > 0 ? 1 : 0;

            MaxLength = precisionLength + fpointCnt + signCnt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="precisionLength">number integer length(exclude point ".")</param>
        /// <param name="scaleLength">number decimal part length</param>
        /// <param name="sign">PositiveNegative allowed or PositiveOnly allowed</param>
        /// <param name="align"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// 2014/11/06  habu　　    オーバーロードに置換え
        /// </history>
        public void SetStdControlDomain(ZControlDomain domain, int precisionLength, int scaleLength, InputValidateUtility.SignFlg sign, HorizontalAlignment align)
        {
            SetStdControlDomain(domain, precisionLength, scaleLength, sign);

            TextAlign = align;
        }

        #region Standard Input Filter

        private void SetStdKeypressFilter(KeyPressEventHandler newHandler)
        {
            // StdKeypressFilter Eventは1つのみ保持可能とする。再設定時は、前回のものを削除する
            if (currentStdKeyPressHandler != null)
            {
                KeyPress -= currentStdKeyPressHandler;
            }

            currentStdKeyPressHandler = newHandler;

            KeyPress += newHandler;
        }

        #endregion

        #region Domain Standard Validate

        #region DoValidate
        /// <summary>
        /// 該当コントロールの入力バリデーションを行う。
        /// Validatingイベントは実行タイミングを指定できないため別個にチェックメソッドを用意する
        /// (Invoke Standard validation process(which denpends to control domain)
        /// </summary>
        /// <param name="isNesessary">Set true if the control is nesessary input. Set false if not,</param>
        /// <param name="controlDispName">Contol's DisplayName(Typically control's label.Text)</param>
        /// <param name="errorMsg">Returns standard validation error message</param>
        /// <param name="autoFocus">If validation failed, focus to error occured control</param>
        /// <returns>Returns true if validation is OK , false if error</returns>
        public bool DoValidate(bool isNesessary, string controlDispName, out string errorMsg, bool autoFocus)
        {
            bool validateOk = true;
            errorMsg = string.Empty;

            string checkValue = Text;
            
            // 必須チェック
            if (isNesessary && string.IsNullOrEmpty(checkValue))
            {
                validateOk = false;
                errorMsg = string.Format("必須項目：{0}が入力されていません。", controlDispName);
            }
            else if (controlDomain == ZControlDomain.ZT_STD_NAME || controlDomain == ZControlDomain.ZG_STD_NAME)
            {

            }
            else if (controlDomain == ZControlDomain.ZT_STD_CD || controlDomain == ZControlDomain.ZG_STD_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角英数字で入力して下さい。"; }

                // コードの場合は入力桁数が規定値丁度である事(入力がある場合)
                if (!string.IsNullOrEmpty(checkValue) && checkValue.Length != MaxLength)
                {
                    validateOk = false;
                    errorMsg = string.Format("{0}は{1}桁で入力して下さい。", controlDispName, MaxLength);
                }
            }
            else if (controlDomain == ZControlDomain.ZT_STD_ALPHA_NUM)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9-");
                if (!validateOk) { errorMsg = controlDispName + "は半角英数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_STD_NUM || controlDomain == ZControlDomain.ZG_STD_NUM)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, InputValidateUtility.CreateNumerFormat(numberScaleLength, signFlg));
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_HOTEI_KBN)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角英数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_HOKENJO_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角英数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_SHISHO_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角英数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_NENDO)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_DT)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9/");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_YMD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9/");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_NEN_WAREKI)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "A9");
                if (!validateOk) { errorMsg = controlDispName + "は年号、半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_NEN)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_TSUKI)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_BI)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_FLG)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_TEL_NO || controlDomain == ZControlDomain.ZG_TEL_NO)
            {
                // 電話番号は個別ロジックでチェック
                validateOk = InputValidateUtility.ValidateTelNo(checkValue);
            }
            else if (controlDomain == ZControlDomain.ZT_ZIP_CD || controlDomain == ZControlDomain.ZG_ZIP_CD)
            {
                // 郵便番号は個別ロジックでチェック
                validateOk = InputValidateUtility.ValidateZipCd(checkValue);
            }
            else if (controlDomain == ZControlDomain.ZT_SETCHISHA_KBN)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_SETCHISHA_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_KENSAIN_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_CHIKU_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_SAISUIIN_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_GYOSHA_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZT_ADR)
            {

            }
            else if (controlDomain == ZControlDomain.ZT_NEN_GETSU)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9/");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }

            // 該当コントロールにフォーカス
            if (!validateOk && autoFocus)
            {
                Focus();
            }

            return validateOk;
        }

        #region DoValidate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNesessary"></param>
        /// <param name="controlDispName"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public bool DoValidate(bool isNesessary, string controlDispName, out string errorMsg)
        {
            // デフォルトはフォーカスfalseとする
            return DoValidate(isNesessary, controlDispName, out errorMsg, false);
        }
        #endregion

        #region DoValidate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNesessary"></param>
        /// <param name="controlDispName"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public bool DoValidate(bool isNesessary)
        {
            string errorMsg = string.Empty;
            return DoValidate(isNesessary, string.Empty, out errorMsg, false);
        }
        #endregion

        #endregion

        #endregion

    }
}
