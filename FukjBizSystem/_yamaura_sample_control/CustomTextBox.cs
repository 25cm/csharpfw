using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MealReservationManager.Control
{
    /// <summary>
    /// 拡張テキストボックスクラス
    /// 継承元：TextBoxコントロール
    /// </summary>
    public partial class CustomTextBox : TextBox
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
            /// 整数値
            /// </summary>
            Int,

            /// <summary>
            /// 整数値（正数のみ）
            /// </summary>
            PositiveInt,


            /// <summary>
            /// 利用者ID（整形された数値、通常の文字列）
            /// </summary>
            UserID,

        }
        #endregion

        #region フィールド

        /// <summary>
        /// カスタム書式
        /// </summary>
        private string customFormat;

        /// <summary>
        /// カスタム入力制御
        /// </summary>
        private InputMode customInputMode;

        /// <summary>
        /// 書式適用前のValue
        /// </summary>
        private string originalValue;

        /// <summary>
        /// 手入力による変更
        /// </summary>
        private bool IsManualSet = false;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region プロパティ

        #region Textプロパティ
        /// <summary>
        /// 画面入力以外から値をセットした場合の書式設定
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                if (!IsManualSet && !string.IsNullOrEmpty(base.Text) &&
                    this.originalValue != this.Text)
                {
                    // 書式を設定
                    SetFormat();
                }
                else
                {
                    IsManualSet = false;
                }
            }
        }
        #endregion

        #region CustomValue
        /// <summary>
        /// テキストボックスの表示内容を取得します。
        /// </summary>
        [Description("テキストボックスの表示内容を取得します。"), Category("動作")]
        public object CustomValue
        {
            get
            {
                if (!string.IsNullOrEmpty(this.customFormat))
                {
                    this.originalValue = this.Text;

                    switch (this.customInputMode)
                    {
                        case InputMode.None:
                        case InputMode.UserID:

                            return this.Text;

                        case InputMode.Int:
                        case InputMode.PositiveInt:

                            decimal? numericText = null;

                            try
                            {
                                // 数値に変換して書式を設定
                                numericText = decimal.Parse(this.originalValue);
                            }
                            catch
                            {
                            }

                            return numericText;

                        default:

                            return this.Text;
                    }
                }
                else
                {
                    return this.originalValue;
                }
            }
        }
        #endregion

        #region CustomFormat
        /// <summary>
        /// テキストボックスの表示書式を設定します。
        /// </summary>
        [Description("テキストボックスの表示書式を設定します。"), Category("動作")]
        public string CustomFormat
        {
            get { return this.customFormat; }
            set { this.customFormat = value; }
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

        #endregion

        #region protected メソッドオーバーライド

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
                case InputMode.UserID:
                    
                    break;

                case InputMode.Int:

                    if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '-') && (e.KeyChar != '\b'))
                    {
                        e.Handled = true;
                    }

                    break;

                case InputMode.PositiveInt:

                    if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
                    {
                        e.Handled = true;
                    }

                    break;
            }

            base.OnKeyPress(e);
        }
        #endregion
        
        #region OnEnter
        /// <summary>
        /// フォーマットを開放する
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            if (!this.ReadOnly)
            {
                // 書式を開放
                ReleaseFormat();
            }

            base.OnEnter(e);
        }
        #endregion

        #region OnLeave
        /// <summary>
        /// フォーマットを設定する
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            if (!this.ReadOnly)
            {
                IsManualSet = true;

                // 書式を設定
                SetFormat();
            }

            base.OnLeave(e);
        }
        #endregion

        #endregion

        #region privateメソッド

        #region ReleaseFormat
        /// <summary>
        /// 書式解放
        /// </summary>
        private void ReleaseFormat()
        {
            this.Text = this.originalValue;
        }
        #endregion

        #region SetFormat
        /// <summary>
        /// 書式設定
        /// </summary>
        private void SetFormat()
        {
            if (!string.IsNullOrEmpty(this.customFormat))
            {
                this.originalValue = this.Text;

                switch (this.customInputMode)
                {
                    case InputMode.None:

                        try
                        {
                            // 書式を設定
                            this.Text = string.Format(this.customFormat, this.Text);
                        }
                        catch
                        {
                            this.Text = string.Empty;
                            this.originalValue = this.Text;
                        }

                        break;

                    case InputMode.Int:
                    case InputMode.PositiveInt:

                        try
                        {
                            // 数値に変換して書式を設定
                            string formatText = string.Format(this.customFormat, decimal.Parse(this.Text));
                            this.Text = formatText;
                        }
                        catch
                        {
                            this.Text = string.Empty;
                            this.originalValue = this.Text;
                        }

                        break;

                    case InputMode.UserID:

                        // 利用者IDの場合、数値に見える入力は数値に変換して書式を適用する

                        try
                        {
                            decimal num = 0;
                            if (decimal.TryParse(this.Text, out num))
                            {
                                this.Text = string.Format(this.customFormat, num);
                            }
                            else
                            {
                                // 書式を設定
                                this.Text = string.Format(this.customFormat, this.Text);
                            }
                        }
                        catch
                        {
                            this.Text = string.Empty;
                            this.originalValue = this.Text;
                        }

                        break;
                }
            }
        }
        #endregion

        #endregion
    }
}
