using System;
using System.ComponentModel;
using System.Windows.Forms;
using Zynas.Control;
using Zynas.Control.Common;

namespace FukjBizSystem.Control
{
    /// <summary>
    /// 拡張テキストボックスクラス
    /// 継承元：TextBoxコントロール
    /// </summary>
    public partial class NumberTextBox : TextBox
    {
        #region 入力モード
        /// <summary>
        /// 入力モード
        /// </summary>
        public enum InputMode
        {
            /// <summary>
            /// 整数値
            /// </summary>
            Int,

            /// <summary>
            /// 整数値（正数のみ）
            /// </summary>
            PositiveInt,

            /// <summary>
            /// 小数値
            /// </summary>
            Decimal,
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
        /// カスタム少数桁数
        /// </summary>
        private int customDigitParts;

        /// <summary>
        /// 書式適用前のValue
        /// </summary>
        private string originalValue;

        /// <summary>
        /// 手入力による変更
        /// </summary>
        private bool IsManualSet = false;

        /// <summary>
        /// ドメイン定義
        /// </summary>
        private ZControlDomain controlDomain;

        // 背景色を変える読み取り専用にするフラグ
        private bool customReadOnly = false;

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
                this.originalValue = this.Text;

                switch (this.customInputMode)
                {
                    case InputMode.Int:
                    case InputMode.PositiveInt:
                    case InputMode.Decimal:

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
            set 
            { 
                this.customInputMode = value;
                if (this.customInputMode != InputMode.Decimal)
                {
                    this.customDigitParts = 0;
                }                
            }
        }        
        #endregion

        #region CustomDigitParts
        /// <summary>
        /// 少数部の桁数を設定します。
        /// </summary>
        [Description("少数部の桁数を設定します。"), Category("動作")]
        public int CustomDigitParts
        {
            get { return this.customDigitParts; }
            set 
            {
                this.customDigitParts = value;
            }
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

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NumberTextBox()
        {
            InitializeComponent();

            // 共通の初期化
            commonUserInitilization();
        }

        /// <summary>
        /// プログラム実行時のコンストラクタ
        /// </summary>
        /// <param name="container"></param>
        public NumberTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
         
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

                case InputMode.Decimal:

                    if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.'))
                    {
                        e.Handled = true;
                        return;
                    }

                    string checkStr = this.Text + e.KeyChar;
                    decimal dec = 0;

                    if (e.KeyChar != '\b' && !decimal.TryParse(checkStr, out dec))
                    {
                        e.Handled = true;
                        return;
                    }

                    int leftDecimal = checkStr.IndexOf('.');
                    
                    if ((customDigitParts == 0 && leftDecimal != -1)
                        || ((e.KeyChar != '\b') && (e.KeyChar != '.') && leftDecimal != -1 && (checkStr.Substring(leftDecimal + 1).Length > customDigitParts)))
                    {
                        e.Handled = true;
                        return;
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
            //this.Text = this.originalValue;
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

                try
                {
                    // 数値に変換して書式を設定
                    string formatText = string.Format(this.customFormat, decimal.Parse(this.Text).ToString("N0"));
                    this.Text = formatText;
                }
                catch
                {
                    this.Text = string.Empty;
                }

                this.originalValue = this.Text;
            }
            else
            {
                this.originalValue = this.Text;
                
                try
                {
                    // 数値に変換して書式を設定

                    string formatText = decimal.Parse(this.Text).ToString();

                    // DatNT
                    if (decimal.Parse(this.Text) >= 0)
                    {
                        string zeroNum = string.Empty;
                        if (formatText.Length != this.Text.Length)
                        {
                            for (int i = 0; i < this.Text.Length - formatText.Length; i++)
                            {
                                zeroNum += "0";
                            }
                        }

                        this.Text = zeroNum + formatText;
                    }
                    else
                    {
                        if (this.customInputMode == InputMode.PositiveInt)
                        {
                            this.Text = string.Empty;
                        }
                    }
                    // End DatNT
                }
                catch
                {
                    this.Text = string.Empty;
                }

                this.originalValue = this.Text;

            }
        }
        #endregion

        #region ドメイン定義
        private void SetControlProperty()
        {
            // 高さは25ポイント固定
            Height = 25;
            TextAlign = HorizontalAlignment.Right;
            
            // 手数料単価
            if (controlDomain == ZControlDomain.ZN_TESURYO_TANKA)
            {
                this.MaxLength = 8;
                this.Width = 72;
            }
            // チケット枚数
            else if (controlDomain == ZControlDomain.ZN_TICKET_NUM)
            {
                this.MaxLength = 6;
                this.Width = 62;
            }
            // 伝票明細番号
            else if (controlDomain == ZControlDomain.ZN_DENPYO_DTL)
            {
                this.MaxLength = 4;
                this.Width = 42;
            }
            // 世代管理日付
            else if (controlDomain == ZControlDomain.ZN_SEDAI_MNG_DT)
            {
                this.MaxLength = 8;
                this.Width = 72;
            }
            // 在庫履歴番号
            else if (controlDomain == ZControlDomain.ZN_ZAIKO_RIREKI_NO)
            {
                this.MaxLength = 4;
                this.Width = 42;
            }
            // 金額
            else if (controlDomain == ZControlDomain.ZN_AMT)
            {
                this.MaxLength = 10;
                this.Width = 104;
            }
            // ECサイトKey
            else if (controlDomain == ZControlDomain.ZN_ECSITE_KEY)
            {
                this.MaxLength = 11;
                this.Width = 110;
            }
            // 単価
            else if (controlDomain == ZControlDomain.ZN_TANKA)
            {
                this.MaxLength = 14;
                this.Width = 140;
            }
            // 表示順
            else if (controlDomain == ZControlDomain.ZN_HYOJI)
            {
                this.MaxLength = 6;
                this.Width = 58;
            }
        }
        #endregion

        #endregion
    }
}
