namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    partial class BatchInputForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.zanryuEnsoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.saisuiinNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.saisuiinCdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.saisuiinSearchButton = new Zynas.Control.ZButton(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uketsukeKbnGroupBox = new System.Windows.Forms.GroupBox();
            this.shushuRadioButton = new System.Windows.Forms.RadioButton();
            this.motikomiRadioButton = new System.Windows.Forms.RadioButton();
            this.haneiButton = new Zynas.Control.ZButton(this.components);
            this.tojiruButton = new Zynas.Control.ZButton(this.components);
            this.mainPanel.SuspendLayout();
            this.uketsukeKbnGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.zanryuEnsoTextBox);
            this.mainPanel.Controls.Add(this.saisuiinNmTextBox);
            this.mainPanel.Controls.Add(this.saisuiinCdTextBox);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.saisuiinSearchButton);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.uketsukeKbnGroupBox);
            this.mainPanel.Controls.Add(this.haneiButton);
            this.mainPanel.Controls.Add(this.tojiruButton);
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(477, 178);
            this.mainPanel.TabIndex = 0;
            // 
            // zanryuEnsoTextBox
            // 
            this.zanryuEnsoTextBox.AllowDropDown = false;
            this.zanryuEnsoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.zanryuEnsoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.zanryuEnsoTextBox.CustomReadOnly = false;
            this.zanryuEnsoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.zanryuEnsoTextBox.Location = new System.Drawing.Point(104, 96);
            this.zanryuEnsoTextBox.MaxLength = 4;
            this.zanryuEnsoTextBox.Name = "zanryuEnsoTextBox";
            this.zanryuEnsoTextBox.Size = new System.Drawing.Size(76, 27);
            this.zanryuEnsoTextBox.TabIndex = 7;
            // 
            // saisuiinNmTextBox
            // 
            this.saisuiinNmTextBox.AllowDropDown = false;
            this.saisuiinNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.saisuiinNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.saisuiinNmTextBox.CustomReadOnly = false;
            this.saisuiinNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.saisuiinNmTextBox.Location = new System.Drawing.Point(160, 64);
            this.saisuiinNmTextBox.MaxLength = 4;
            this.saisuiinNmTextBox.Name = "saisuiinNmTextBox";
            this.saisuiinNmTextBox.ReadOnly = true;
            this.saisuiinNmTextBox.Size = new System.Drawing.Size(248, 27);
            this.saisuiinNmTextBox.TabIndex = 4;
            this.saisuiinNmTextBox.TabStop = false;
            // 
            // saisuiinCdTextBox
            // 
            this.saisuiinCdTextBox.AllowDropDown = false;
            this.saisuiinCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.saisuiinCdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.saisuiinCdTextBox.CustomReadOnly = false;
            this.saisuiinCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.saisuiinCdTextBox.Location = new System.Drawing.Point(104, 64);
            this.saisuiinCdTextBox.MaxLength = 4;
            this.saisuiinCdTextBox.Name = "saisuiinCdTextBox";
            this.saisuiinCdTextBox.Size = new System.Drawing.Size(52, 27);
            this.saisuiinCdTextBox.TabIndex = 3;
            this.saisuiinCdTextBox.Leave += new System.EventHandler(this.saisuiinCdTextBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "mg/L";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "残留塩素濃度";
            // 
            // saisuiinSearchButton
            // 
            this.saisuiinSearchButton.Image = global::FukjBizSystem.Properties.Resources.icon_search;
            this.saisuiinSearchButton.Location = new System.Drawing.Point(412, 64);
            this.saisuiinSearchButton.Name = "saisuiinSearchButton";
            this.saisuiinSearchButton.Size = new System.Drawing.Size(28, 26);
            this.saisuiinSearchButton.TabIndex = 5;
            this.saisuiinSearchButton.TabStop = false;
            this.saisuiinSearchButton.UseVisualStyleBackColor = true;
            this.saisuiinSearchButton.Click += new System.EventHandler(this.saisuiinSearchButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "採水員";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "受付区分";
            // 
            // uketsukeKbnGroupBox
            // 
            this.uketsukeKbnGroupBox.Controls.Add(this.shushuRadioButton);
            this.uketsukeKbnGroupBox.Controls.Add(this.motikomiRadioButton);
            this.uketsukeKbnGroupBox.Location = new System.Drawing.Point(104, 12);
            this.uketsukeKbnGroupBox.Name = "uketsukeKbnGroupBox";
            this.uketsukeKbnGroupBox.Size = new System.Drawing.Size(132, 46);
            this.uketsukeKbnGroupBox.TabIndex = 1;
            this.uketsukeKbnGroupBox.TabStop = false;
            // 
            // shushuRadioButton
            // 
            this.shushuRadioButton.AutoSize = true;
            this.shushuRadioButton.Location = new System.Drawing.Point(7, 16);
            this.shushuRadioButton.Name = "shushuRadioButton";
            this.shushuRadioButton.Size = new System.Drawing.Size(53, 24);
            this.shushuRadioButton.TabIndex = 0;
            this.shushuRadioButton.Text = "収集";
            this.shushuRadioButton.UseVisualStyleBackColor = true;
            // 
            // motikomiRadioButton
            // 
            this.motikomiRadioButton.AutoSize = true;
            this.motikomiRadioButton.Checked = true;
            this.motikomiRadioButton.Location = new System.Drawing.Point(68, 16);
            this.motikomiRadioButton.Name = "motikomiRadioButton";
            this.motikomiRadioButton.Size = new System.Drawing.Size(53, 24);
            this.motikomiRadioButton.TabIndex = 1;
            this.motikomiRadioButton.TabStop = true;
            this.motikomiRadioButton.Text = "持込";
            this.motikomiRadioButton.UseVisualStyleBackColor = true;
            // 
            // haneiButton
            // 
            this.haneiButton.Location = new System.Drawing.Point(241, 128);
            this.haneiButton.Name = "haneiButton";
            this.haneiButton.Size = new System.Drawing.Size(101, 37);
            this.haneiButton.TabIndex = 9;
            this.haneiButton.Text = "F1:反映";
            this.haneiButton.UseVisualStyleBackColor = true;
            this.haneiButton.Click += new System.EventHandler(this.haneiButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(362, 128);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 10;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // BatchInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 180);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一括入力";
            this.Load += new System.EventHandler(this.BatchInputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BatchInputForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.uketsukeKbnGroupBox.ResumeLayout(false);
            this.uketsukeKbnGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton haneiButton;
        private System.Windows.Forms.Panel mainPanel;
        private Zynas.Control.ZButton tojiruButton;
        private System.Windows.Forms.GroupBox uketsukeKbnGroupBox;
        private System.Windows.Forms.RadioButton shushuRadioButton;
        private System.Windows.Forms.RadioButton motikomiRadioButton;
        private System.Windows.Forms.Label label1;
        private Zynas.Control.ZButton saisuiinSearchButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Control.ZTextBox saisuiinCdTextBox;
        private Control.ZTextBox zanryuEnsoTextBox;
        private Control.ZTextBox saisuiinNmTextBox;
    }
}