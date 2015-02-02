using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FukjTabletSystem.Application.Boundary.Common;
using Zynas.Control;
using Zynas.Control.Common;
using FukjTabletSystem.Application.Utility;

namespace FukjTabletSystem.Controls
{
    /// <summary>
    /// 拡張テキストボックスクラス
    /// 継承元：TextBoxコントロール
    /// </summary>
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

        // ドメイン対応
        private ZControlDomain controlDomain;

        // カスタム入力制御
        private InputMode customInputMode;

        // 表示するスクリーンきーぼどのタイプを指定する
        private bool isNumberInput = false;

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

        #region IsNumberInput
        /// <summary>
        /// 背景色を変える読み取り専用プロパティ
        /// </summary>
        [Description("trueに設定した場合、数値入力キーボードを表示します。"), Category("動作")]
        public bool IsNumberInput
        {
            get { return isNumberInput; }
            set { isNumberInput = value; }
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
        private void SetControlProperty()
        {
            #region 共通プロパティ指定

            // 高さは25ポイント固定
            Height = 25;
            TextAlign = HorizontalAlignment.Left;

            #endregion

            #region ドメイン個別プロパティ指定

            //if (controlDomain == ZControlDomain.ZT_KBN)
            //{
            //    MaxLength = 1;
            //    Width = 27;
            //}
            //else 
            if (controlDomain == ZControlDomain.ZT_HOTEI_KBN)
            {
                MaxLength = 1;
            }
            else if (controlDomain == ZControlDomain.ZT_HOKENJO_CD)
            {
                MaxLength = 2;
            }
            else if (controlDomain == ZControlDomain.ZT_SHISHO_CD)
            {
                MaxLength = 1;
            }
            else if (controlDomain == ZControlDomain.ZT_NENDO)
            {
                MaxLength = 4;
            }
            else if (controlDomain == ZControlDomain.ZT_DT)
            {
                MaxLength = 8;
            }
            else if (controlDomain == ZControlDomain.ZT_YMD)
            {
                MaxLength = 8;
            }
            else if (controlDomain == ZControlDomain.ZT_NEN)
            {
                MaxLength = 4;
            }
            else if (controlDomain == ZControlDomain.ZT_TSUKI)
            {
                MaxLength = 2;
            }
            else if (controlDomain == ZControlDomain.ZT_BI)
            {
                MaxLength = 2;
            }
            else if (controlDomain == ZControlDomain.ZT_FLG)
            {
                MaxLength = 1;
            }
            else if (controlDomain == ZControlDomain.ZT_TEL_NO)
            {
                MaxLength = 13;
            }
            else if (controlDomain == ZControlDomain.ZT_ZIP_CD)
            {
                MaxLength = 8;
            }
            else if (controlDomain == ZControlDomain.ZT_SETCHISHA_KBN)
            {
                MaxLength = 1;
            }
            else if (controlDomain == ZControlDomain.ZT_SETCHISHA_CD)
            {
                MaxLength = 7;
            }
            else if (controlDomain == ZControlDomain.ZT_KENSAIN_CD)
            {
                MaxLength = 3;
            }
            else if (controlDomain == ZControlDomain.ZT_CHIKU_CD)
            {
                MaxLength = 5;
            }
            else if (controlDomain == ZControlDomain.ZT_SAISUIIN_CD)
            {
                MaxLength = 5;
            }
            else if (controlDomain == ZControlDomain.ZT_GYOSHA_CD)
            {
                MaxLength = 4;
            }
            else if (controlDomain == ZControlDomain.ZT_ADR)
            {
                MaxLength = 80;
            }
            else if (controlDomain == ZControlDomain.ZT_NEN_GETSU)
            {
                MaxLength = 6;
            }

            #endregion

        }
        #endregion

        private Color? preBackColor = null;

        private void ZTextBox_Enter(object sender, System.EventArgs e)
        {
            if (FukjTabletSystem.Application.Boundary.Common.Utility.IsInDesignMode)
            {
                return;
            }
            
            if (Enabled && !ReadOnly && !CustomReadOnly)
            {
                preBackColor = this.BackColor;

                this.BackColor = Color.LightPink;
                
                if (!isNumberInput)
                {
                    Utility.ExecScreenKeybord();
                }
                else
                {
                    NumberInput.Show(this);
                }
            }
        }

        private void ZTextBox_Leave(object sender, System.EventArgs e)
        {
            if (FukjTabletSystem.Application.Boundary.Common.Utility.IsInDesignMode)
            {
                return;
            }

            if (Enabled && !ReadOnly && !CustomReadOnly)
            {
                if (preBackColor != null)
                {
                    this.BackColor = preBackColor.Value;

                    preBackColor = null;
                }
            }
        }
    }
}
