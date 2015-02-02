namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class MessageDialog
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
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.okButton = new Zynas.Control.ZButton(this.components);
            this.cancelButton = new Zynas.Control.ZButton(this.components);
            this.messageTextBox = new FukjTabletSystem.Controls.ZTextBox(this.components);
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.messageTextBox);
            this.contentsPanel.Controls.Add(this.okButton);
            this.contentsPanel.Controls.Add(this.cancelButton);
            this.contentsPanel.Controls.Add(this.iconPictureBox);
            this.contentsPanel.Size = new System.Drawing.Size(594, 220);
            this.contentsPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Size = new System.Drawing.Size(594, 50);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleLabel.Location = new System.Drawing.Point(12, 5);
            this.titleLabel.Size = new System.Drawing.Size(570, 40);
            this.titleLabel.Text = "福岡県浄化槽タブレットシステム";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconPictureBox.Location = new System.Drawing.Point(18, 43);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(80, 80);
            this.iconPictureBox.TabIndex = 8;
            this.iconPictureBox.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(118, 165);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(160, 43);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(316, 164);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(160, 43);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.AllowDropDown = false;
            this.messageTextBox.BackColor = System.Drawing.Color.Honeydew;
            this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.messageTextBox.CustomInputMode = FukjTabletSystem.Controls.ZTextBox.InputMode.None;
            this.messageTextBox.CustomReadOnly = true;
            this.messageTextBox.Location = new System.Drawing.Point(107, 14);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.messageTextBox.MaxLength = 40;
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(475, 140);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.TabStop = false;
            // 
            // MessageDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(594, 271);
            this.Name = "MessageDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "福岡県浄化槽タブレットシステム";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MessageDialog_Load);
            this.contentsPanel.ResumeLayout(false);
            this.contentsPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconPictureBox;
        private Zynas.Control.ZButton okButton;
        private Zynas.Control.ZButton cancelButton;
        private Controls.ZTextBox messageTextBox;
    }
}