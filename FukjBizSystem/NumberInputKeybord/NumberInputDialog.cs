using System;
using System.Windows.Forms;

namespace NumberInputKeybord
{
    /// <summary>
    /// 文字入力支援ダイアログ
    /// </summary>
    public partial class NumberInputDialog : UnSelectableForm
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NumberInputDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region フォームをアクティブにしないための制御

        private const int WS_EX_NOACTIVATE = 0x8000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                if (!base.DesignMode)
                {
                    p.ExStyle = p.ExStyle | (WS_EX_NOACTIVATE);
                }
                return p;
            }
        }

        #endregion

        #region イベントハンドラ

        #region NumberInputDialog_Load(object sender, EventArgs e)
        /// <summary>
        /// フォームロード（表示位置の制御）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberInputDialog_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 40;
        }
        #endregion

        #region zButton_Click(object sender, EventArgs e)
        /// <summary>
        /// キー入力送信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send(((Button)sender).Text);
        }
        #endregion

        #region zButton10_Click(object sender, EventArgs e)
        /// <summary>
        /// キー入力送信(バックスペース)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zButton10_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BS}");
        }
        #endregion

        #region unSelectableButton2_Click(object sender, EventArgs e)
        /// <summary>
        /// キー入力送信(エンター)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unSelectableButton2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }
        #endregion

        #region unSelectableButton3_Click(object sender, EventArgs e)
        /// <summary>
        /// キー入力送信(タブ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unSelectableButton3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }
        #endregion
                
        #region closeButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        
        #endregion
    }
}
