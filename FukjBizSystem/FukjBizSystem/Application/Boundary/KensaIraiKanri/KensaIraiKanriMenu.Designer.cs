namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    partial class KensaIraiKanriMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kensaIraiToroku7joButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kensaIraiToroku7joButton
            // 
            this.kensaIraiToroku7joButton.Location = new System.Drawing.Point(12, 12);
            this.kensaIraiToroku7joButton.Name = "kensaIraiToroku7joButton";
            this.kensaIraiToroku7joButton.Size = new System.Drawing.Size(135, 55);
            this.kensaIraiToroku7joButton.TabIndex = 2;
            this.kensaIraiToroku7joButton.Text = "７条依頼入力";
            this.kensaIraiToroku7joButton.UseVisualStyleBackColor = true;
            this.kensaIraiToroku7joButton.Click += new System.EventHandler(this.kensaIraiToroku7joButton_Click);
            // 
            // KensaIraiKanriMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.kensaIraiToroku7joButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KensaIraiKanriMenu";
            this.Text = "機能選択";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kensaIraiToroku7joButton;
    }
}