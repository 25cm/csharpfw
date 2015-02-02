namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class Login
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
            this.LoginButton = new Zynas.Control.ZButton(this.components);
            this.versionLabel = new System.Windows.Forms.Label();
            this.CloseButton = new Zynas.Control.ZButton(this.components);
            this.PasswordTextBox = new FukjTabletSystem.Controls.ZTextBox(this.components);
            this.UserIdTextBox = new FukjTabletSystem.Controls.ZTextBox(this.components);
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.LoginButton);
            this.contentsPanel.Controls.Add(this.versionLabel);
            this.contentsPanel.Controls.Add(this.CloseButton);
            this.contentsPanel.Controls.Add(this.PasswordTextBox);
            this.contentsPanel.Controls.Add(this.UserIdTextBox);
            this.contentsPanel.Controls.Add(this.PasswordLabel);
            this.contentsPanel.Controls.Add(this.UserIdLabel);
            this.contentsPanel.Size = new System.Drawing.Size(290, 193);
            // 
            // topPanel
            // 
            this.topPanel.Size = new System.Drawing.Size(290, 50);
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(77, 5);
            this.titleLabel.Text = "ログイン";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(17, 138);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(122, 43);
            this.LoginButton.TabIndex = 11;
            this.LoginButton.Text = "ログイン";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.ForeColor = System.Drawing.Color.Black;
            this.versionLabel.Location = new System.Drawing.Point(141, 14);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(137, 24);
            this.versionLabel.TabIndex = 8;
            this.versionLabel.Text = "XX.XX.XX.XX";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(151, 138);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(122, 43);
            this.CloseButton.TabIndex = 12;
            this.CloseButton.Text = "終了";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.AllowDropDown = false;
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.PasswordTextBox.CustomInputMode = FukjTabletSystem.Controls.ZTextBox.InputMode.None;
            this.PasswordTextBox.CustomReadOnly = false;
            this.PasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PasswordTextBox.IsNumberInput = true;
            this.PasswordTextBox.Location = new System.Drawing.Point(124, 84);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(138, 31);
            this.PasswordTextBox.TabIndex = 10;
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.AllowDropDown = false;
            this.UserIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserIdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UserIdTextBox.CustomInputMode = FukjTabletSystem.Controls.ZTextBox.InputMode.None;
            this.UserIdTextBox.CustomReadOnly = false;
            this.UserIdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.UserIdTextBox.IsNumberInput = true;
            this.UserIdTextBox.Location = new System.Drawing.Point(124, 46);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.Size = new System.Drawing.Size(138, 31);
            this.UserIdTextBox.TabIndex = 7;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(29, 87);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(3);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(90, 24);
            this.PasswordLabel.TabIndex = 9;
            this.PasswordLabel.Text = "パスワード";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.AutoSize = true;
            this.UserIdLabel.Location = new System.Drawing.Point(42, 49);
            this.UserIdLabel.Margin = new System.Windows.Forms.Padding(3);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(79, 24);
            this.UserIdLabel.TabIndex = 6;
            this.UserIdLabel.Text = "ユーザID";
            this.UserIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 244);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "福岡県浄化槽タブレットシステム";
            this.Load += new System.EventHandler(this.Login_Load);
            this.contentsPanel.ResumeLayout(false);
            this.contentsPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton LoginButton;
        private System.Windows.Forms.Label versionLabel;
        private Zynas.Control.ZButton CloseButton;
        private Controls.ZTextBox PasswordTextBox;
        private Controls.ZTextBox UserIdTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UserIdLabel;

    }
}