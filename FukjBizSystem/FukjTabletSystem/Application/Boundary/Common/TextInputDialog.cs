using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// 文字入力支援ダイアログ
    /// </summary>
    public partial class TextInputDialog : Form
    {
        #region 入力情報返却用

        /// <summary>
        /// 入力された文字列
        /// </summary>
        /// <returns></returns>
        public string InputText()
        {
            return inputTextBox.Text;
        }

        /// <summary>
        /// 行数
        /// </summary>
        /// <returns></returns>
        public int InputLineCount()
        {
            return inputTextBox.Lines.Length;
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TextInputDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region TextInputDialog_Load(object sender, EventArgs e)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextInputDialog_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            
            // キーボード起動
            keybordButton.PerformClick();
        }
        #endregion

        #region TextInputDialog_FormClosing(object sender, FormClosingEventArgs e)
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextInputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //OSの情報を取得する
            System.OperatingSystem os = System.Environment.OSVersion;

            // windows 8以前の場合
            if (os.Version.Major < 6 || os.Version.Minor < 2)
            {
                return;
            }

            System.Diagnostics.Process[] ps =
            System.Diagnostics.Process.GetProcesses();

            // 起動している場合は終了させる
            foreach (System.Diagnostics.Process p in ps)
            {
                if (p.ProcessName == "TabTip")
                {
                    p.Kill();
                    break;
                }
            }
        }
        #endregion

        #region okButton_Click(object sender, EventArgs e)
        /// <summary>
        /// OKボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text.Length > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region keybordButton_Click(object sender, EventArgs e)
        /// <summary>
        /// キーボード起動ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keybordButton_Click(object sender, EventArgs e)
        {
            //OSの情報を取得する
            System.OperatingSystem os = System.Environment.OSVersion;

            // windows 8以前の場合
            if (os.Version.Major < 6 || os.Version.Minor < 2)
            {
                return;
            }

            System.Diagnostics.Process[] ps =
            System.Diagnostics.Process.GetProcesses();

            // 既に起動している場合は一度終了させる（非表示の場合が有るの為）
            foreach (System.Diagnostics.Process p in ps)
            {
                if (p.ProcessName == "TabTip")
                {
                    p.Kill();
                    break;
                }
            }

            // 起動
            Process keybord = new Process();
            keybord.StartInfo.FileName = @"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe";
            keybord.Start();

            this.ActiveControl = inputTextBox;
        }
        #endregion

        #region inputTextBox_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// 入力内容変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            int linecnt = 1;

            while (true)
            {
                int ret = inputTextBox.GetFirstCharIndexFromLine(linecnt++);

                if (ret == -1)
                {
                    break;
                }
            }

            inputTextBox.Height = 80 * (linecnt - 1);
            int hightDiff = this.Height - (inputTextBox.Height + 78);
            this.Top += hightDiff;
            this.Height = inputTextBox.Height + 78;
        }
        #endregion

        #endregion
    }
}
