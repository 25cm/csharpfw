using System.Drawing;
using System.Windows.Forms;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// 拡張メッセージボックス
    /// </summary>
    public partial class MessageDialog : FukjTabBaseDialog
    {
        #region メッセージタイプ

        public enum MessageType
        {
            Info,

            Warn,

            Error,

            YesNo,
        }

        #endregion

        #region フィールド(private)

        private MessageType myType;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="type"></param>
        public MessageDialog(string message, string title, int type, Color? bgColor, Color? fColor)
        {
            InitializeComponent();

            // タイトル
            titleLabel.Text = title;

            // 本文
            messageTextBox.Text = message;

            // ボタン制御
            myType = (MessageType)type;

            if (bgColor.HasValue)
            {
                this.BackColor = bgColor.Value;
                this.contentsPanel.BackColor = bgColor.Value;
                this.messageTextBox.BackColor = bgColor.Value;
            }

            if (fColor.HasValue)
            {
                this.ForeColor = fColor.Value;
                this.contentsPanel.ForeColor = fColor.Value;
                this.messageTextBox.ForeColor = fColor.Value;
            }

            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(40, 40);

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            switch (myType)
            {
                case MessageType.Info:

                    //システムの情報アイコン(WIN32: IDI_INFORMATION)
                    g.DrawIcon(SystemIcons.Information, 4, 4);

                    // OKボタン
                    okButton.Visible = true;
                    okButton.Text = "ＯＫ";
                    okButton.Left = (this.Width / 2) - (okButton.Width / 2);

                    // キャンセルボタン
                    cancelButton.Visible = false;

                    break;

                case MessageType.Warn:

                    //システムの警告アイコン(WIN32: IDI_WARNING)
                    g.DrawIcon(SystemIcons.Warning, 4, 4);

                    // OKボタン
                    okButton.Visible = true;
                    okButton.Text = "ＯＫ";
                    okButton.Left = (this.Width / 2) - (okButton.Width / 2);

                    // キャンセルボタン
                    cancelButton.Visible = false;

                    break;

                case MessageType.Error:

                    //システムのエラーアイコン(WIN32: IDI_ERROR)
                    g.DrawIcon(SystemIcons.Error, 4, 4);

                    // OKボタン
                    okButton.Visible = true;
                    okButton.Text = "ＯＫ";
                    okButton.Left = (this.Width / 2) - (okButton.Width / 2);

                    // キャンセルボタン
                    cancelButton.Visible = false;

                    break;

                case MessageType.YesNo:

                    //システムの疑問符アイコン(WIN32: IDI_QUESTION)
                    g.DrawIcon(SystemIcons.Question, 4, 4);

                    // OKボタン
                    okButton.Visible = true;
                    okButton.Text = "ＯＫ";
                    okButton.Text = "はい";

                    // キャンセルボタン
                    cancelButton.Visible = true;
                    cancelButton.Text = "いいえ";

                    break;
            }

            g.Dispose();

            // 高画質リサイズ
            int w = (int)((float)canvas.Width * 2);
            int h = (int)((float)canvas.Height * 2);
            Bitmap dest = new Bitmap(w, h);
            Graphics g2 = Graphics.FromImage(dest);
            g2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g2.DrawImage(canvas, 0, 0, w, h);

            //iconPictureBoxに表示する
            iconPictureBox.Image = dest;
        }
        #endregion
        
        #region MessageDialog_Load(object sender, System.EventArgs e)
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageDialog_Load(object sender, System.EventArgs e)
        {
            ActiveControl = okButton;
        }
        #endregion

        #region okButton_Click(object sender, System.EventArgs e)
        /// <summary>
        /// OKボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, System.EventArgs e)
        {
            switch (myType)
            {
                case MessageType.Info:
                case MessageType.Warn:
                case MessageType.Error:

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    break;

                case MessageType.YesNo:

                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;

                    break;
            }

            this.Close();
        }
        #endregion

        #region cancelButton_Click(object sender, System.EventArgs e)
        /// <summary>
        /// キャンセルボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            switch (myType)
            {
                case MessageType.Info:
                case MessageType.Warn:
                case MessageType.Error:

                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                    break;

                case MessageType.YesNo:

                    this.DialogResult = System.Windows.Forms.DialogResult.No;

                    break;
            }

            this.Close();
        }
        #endregion

    }
}
