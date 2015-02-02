namespace FukjBizSystem.Application.Boundary.Common
{
    partial class PrinterSettingForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.entryButton = new System.Windows.Forms.Button();
            this.seikyushoComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hagakiComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sofujoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kinoHoshoComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(351, 212);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // entryButton
            // 
            this.entryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.entryButton.Location = new System.Drawing.Point(12, 212);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 8;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // seikyushoComboBox
            // 
            this.seikyushoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seikyushoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seikyushoComboBox.FormattingEnabled = true;
            this.seikyushoComboBox.Location = new System.Drawing.Point(130, 31);
            this.seikyushoComboBox.Name = "seikyushoComboBox";
            this.seikyushoComboBox.Size = new System.Drawing.Size(271, 28);
            this.seikyushoComboBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "請求書専用紙";
            // 
            // hagakiComboBox
            // 
            this.hagakiComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hagakiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hagakiComboBox.FormattingEnabled = true;
            this.hagakiComboBox.Location = new System.Drawing.Point(130, 72);
            this.hagakiComboBox.Name = "hagakiComboBox";
            this.hagakiComboBox.Size = new System.Drawing.Size(271, 28);
            this.hagakiComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "はがき／ＤＭ用";
            // 
            // sofujoComboBox
            // 
            this.sofujoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sofujoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sofujoComboBox.FormattingEnabled = true;
            this.sofujoComboBox.Location = new System.Drawing.Point(130, 113);
            this.sofujoComboBox.Name = "sofujoComboBox";
            this.sofujoComboBox.Size = new System.Drawing.Size(271, 28);
            this.sofujoComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "送付状専用";
            // 
            // kinoHoshoComboBox
            // 
            this.kinoHoshoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kinoHoshoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kinoHoshoComboBox.FormattingEnabled = true;
            this.kinoHoshoComboBox.Location = new System.Drawing.Point(130, 154);
            this.kinoHoshoComboBox.Name = "kinoHoshoComboBox";
            this.kinoHoshoComboBox.Size = new System.Drawing.Size(271, 28);
            this.kinoHoshoComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "機能保証";
            // 
            // PrinterSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.kinoHoshoComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sofujoComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hagakiComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seikyushoComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.entryButton);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "PrinterSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "プリンター設定";
            this.Load += new System.EventHandler(this.PrinterSettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.ComboBox seikyushoComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox hagakiComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sofujoComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox kinoHoshoComboBox;
        private System.Windows.Forms.Label label3;
    }
}