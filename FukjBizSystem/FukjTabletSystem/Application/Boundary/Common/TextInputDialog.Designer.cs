namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class TextInputDialog
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
            this.closeButton = new Zynas.Control.ZButton(this.components);
            this.okButton = new Zynas.Control.ZButton(this.components);
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.keybordButton = new Zynas.Control.ZButton(this.components);
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeButton.Location = new System.Drawing.Point(432, 86);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(233, 69);
            this.closeButton.TabIndex = 4;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "キャンセル";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.Location = new System.Drawing.Point(3, 86);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(426, 69);
            this.okButton.TabIndex = 1;
            this.okButton.TabStop = false;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("メイリオ", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.inputTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.inputTextBox.Location = new System.Drawing.Point(3, 3);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputTextBox.Size = new System.Drawing.Size(744, 80);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // keybordButton
            // 
            this.keybordButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.keybordButton.Image = global::FukjTabletSystem.Properties.Resources.btn_keybord;
            this.keybordButton.Location = new System.Drawing.Point(667, 86);
            this.keybordButton.Name = "keybordButton";
            this.keybordButton.Size = new System.Drawing.Size(80, 69);
            this.keybordButton.TabIndex = 5;
            this.keybordButton.TabStop = false;
            this.keybordButton.UseVisualStyleBackColor = true;
            this.keybordButton.Click += new System.EventHandler(this.keybordButton_Click);
            // 
            // TextInputDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(750, 158);
            this.ControlBox = false;
            this.Controls.Add(this.keybordButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TextInputDialog";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TextInputForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextInputDialog_FormClosing);
            this.Load += new System.EventHandler(this.TextInputDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zynas.Control.ZButton closeButton;
        private Zynas.Control.ZButton okButton;
        private System.Windows.Forms.TextBox inputTextBox;
        private Zynas.Control.ZButton keybordButton;
    }
}