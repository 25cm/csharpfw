namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class KensaFukaJohoAddForm
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
            this.components = new System.ComponentModel.Container();
            this.midashiTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.torokuButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // midashiTextBox
            // 
            this.midashiTextBox.AllowDropDown = false;
            this.midashiTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.midashiTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.midashiTextBox.CustomReadOnly = false;
            this.midashiTextBox.Location = new System.Drawing.Point(64, 8);
            this.midashiTextBox.Name = "midashiTextBox";
            this.midashiTextBox.Size = new System.Drawing.Size(528, 27);
            this.midashiTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "見出し";
            // 
            // torokuButton
            // 
            this.torokuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.torokuButton.Location = new System.Drawing.Point(252, 48);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 3;
            this.torokuButton.Text = "F1:追加";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(499, 48);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadButton.Location = new System.Drawing.Point(360, 48);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(128, 37);
            this.uploadButton.TabIndex = 15;
            this.uploadButton.Text = "F5:アップロード";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // KensaFukaJohoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 95);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.midashiTextBox);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(624, 132);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(624, 132);
            this.Name = "KensaFukaJohoAddForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "検査付加情報追加";
            this.Load += new System.EventHandler(this.KensaFukaJohoAddForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaFukaJohoAddForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.ZTextBox midashiTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button uploadButton;

    }
}