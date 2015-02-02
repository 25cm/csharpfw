namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    partial class JisshiKirokuOutputForm
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
            this.tojiruButton = new Zynas.Control.ZButton(this.components);
            this.outputButton = new Zynas.Control.ZButton(this.components);
            this.gaikanRadioButton = new System.Windows.Forms.RadioButton();
            this.keiryoShomeiRadioButton = new System.Windows.Forms.RadioButton();
            this.suishitsuRadioButton = new System.Windows.Forms.RadioButton();
            this.iraiNoFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.iraiNoToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.iraiUketsukeDtToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.iraiUketsukeDtFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.nendoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(301, 166);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(120, 32);
            this.tojiruButton.TabIndex = 14;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(175, 166);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(120, 32);
            this.outputButton.TabIndex = 13;
            this.outputButton.Text = "F1:印刷";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // gaikanRadioButton
            // 
            this.gaikanRadioButton.AutoSize = true;
            this.gaikanRadioButton.Location = new System.Drawing.Point(128, 88);
            this.gaikanRadioButton.Name = "gaikanRadioButton";
            this.gaikanRadioButton.Size = new System.Drawing.Size(79, 24);
            this.gaikanRadioButton.TabIndex = 7;
            this.gaikanRadioButton.Text = "外観検査";
            this.gaikanRadioButton.UseVisualStyleBackColor = true;
            // 
            // keiryoShomeiRadioButton
            // 
            this.keiryoShomeiRadioButton.AutoSize = true;
            this.keiryoShomeiRadioButton.Location = new System.Drawing.Point(216, 88);
            this.keiryoShomeiRadioButton.Name = "keiryoShomeiRadioButton";
            this.keiryoShomeiRadioButton.Size = new System.Drawing.Size(79, 24);
            this.keiryoShomeiRadioButton.TabIndex = 8;
            this.keiryoShomeiRadioButton.Text = "計量証明";
            this.keiryoShomeiRadioButton.UseVisualStyleBackColor = true;
            // 
            // suishitsuRadioButton
            // 
            this.suishitsuRadioButton.AutoSize = true;
            this.suishitsuRadioButton.Checked = true;
            this.suishitsuRadioButton.Location = new System.Drawing.Point(37, 88);
            this.suishitsuRadioButton.Name = "suishitsuRadioButton";
            this.suishitsuRadioButton.Size = new System.Drawing.Size(82, 24);
            this.suishitsuRadioButton.TabIndex = 6;
            this.suishitsuRadioButton.TabStop = true;
            this.suishitsuRadioButton.Text = "11条水質";
            this.suishitsuRadioButton.UseVisualStyleBackColor = true;
            // 
            // iraiNoFromTextBox
            // 
            this.iraiNoFromTextBox.AllowDropDown = false;
            this.iraiNoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.iraiNoFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.iraiNoFromTextBox.CustomReadOnly = false;
            this.iraiNoFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.iraiNoFromTextBox.Location = new System.Drawing.Point(114, 118);
            this.iraiNoFromTextBox.MaxLength = 6;
            this.iraiNoFromTextBox.Name = "iraiNoFromTextBox";
            this.iraiNoFromTextBox.Size = new System.Drawing.Size(60, 27);
            this.iraiNoFromTextBox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "依頼No";
            // 
            // iraiNoToTextBox
            // 
            this.iraiNoToTextBox.AllowDropDown = false;
            this.iraiNoToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.iraiNoToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.iraiNoToTextBox.CustomReadOnly = false;
            this.iraiNoToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.iraiNoToTextBox.Location = new System.Drawing.Point(208, 118);
            this.iraiNoToTextBox.MaxLength = 6;
            this.iraiNoToTextBox.Name = "iraiNoToTextBox";
            this.iraiNoToTextBox.Size = new System.Drawing.Size(57, 27);
            this.iraiNoToTextBox.TabIndex = 12;
            // 
            // iraiUketsukeDtToTextBox
            // 
            this.iraiUketsukeDtToTextBox.AllowDropDown = false;
            this.iraiUketsukeDtToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.iraiUketsukeDtToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.iraiUketsukeDtToTextBox.CustomReadOnly = false;
            this.iraiUketsukeDtToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.iraiUketsukeDtToTextBox.Location = new System.Drawing.Point(215, 45);
            this.iraiUketsukeDtToTextBox.MaxLength = 6;
            this.iraiUketsukeDtToTextBox.Name = "iraiUketsukeDtToTextBox";
            this.iraiUketsukeDtToTextBox.Size = new System.Drawing.Size(80, 27);
            this.iraiUketsukeDtToTextBox.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(194, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 20);
            this.label17.TabIndex = 4;
            this.label17.Text = "～";
            // 
            // iraiUketsukeDtFromTextBox
            // 
            this.iraiUketsukeDtFromTextBox.AllowDropDown = false;
            this.iraiUketsukeDtFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.iraiUketsukeDtFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.iraiUketsukeDtFromTextBox.CustomReadOnly = false;
            this.iraiUketsukeDtFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.iraiUketsukeDtFromTextBox.Location = new System.Drawing.Point(114, 45);
            this.iraiUketsukeDtFromTextBox.MaxLength = 6;
            this.iraiUketsukeDtFromTextBox.Name = "iraiUketsukeDtFromTextBox";
            this.iraiUketsukeDtFromTextBox.Size = new System.Drawing.Size(80, 27);
            this.iraiUketsukeDtFromTextBox.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "依頼受付日";
            // 
            // nendoTextBox
            // 
            this.nendoTextBox.AllowDropDown = false;
            this.nendoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.nendoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nendoTextBox.CustomReadOnly = false;
            this.nendoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nendoTextBox.Location = new System.Drawing.Point(114, 12);
            this.nendoTextBox.MaxLength = 4;
            this.nendoTextBox.Name = "nendoTextBox";
            this.nendoTextBox.Size = new System.Drawing.Size(60, 27);
            this.nendoTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "年度";
            // 
            // JisshiKirokuOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 209);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.gaikanRadioButton);
            this.Controls.Add(this.keiryoShomeiRadioButton);
            this.Controls.Add(this.suishitsuRadioButton);
            this.Controls.Add(this.iraiNoFromTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.iraiNoToTextBox);
            this.Controls.Add(this.iraiUketsukeDtToTextBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.iraiUketsukeDtFromTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nendoTextBox);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(465, 247);
            this.MinimumSize = new System.Drawing.Size(465, 247);
            this.Name = "JisshiKirokuOutputForm";
            this.Text = "検査台帳出力";
            this.Load += new System.EventHandler(this.JisshiKirokuOutputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JisshiKirokuOutputForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zynas.Control.ZButton tojiruButton;
        private Zynas.Control.ZButton outputButton;
        private System.Windows.Forms.RadioButton gaikanRadioButton;
        private System.Windows.Forms.RadioButton keiryoShomeiRadioButton;
        private System.Windows.Forms.RadioButton suishitsuRadioButton;
        private Control.ZTextBox iraiNoFromTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Control.ZTextBox iraiNoToTextBox;
        private Control.ZTextBox iraiUketsukeDtToTextBox;
        private System.Windows.Forms.Label label17;
        private Control.ZTextBox iraiUketsukeDtFromTextBox;
        private System.Windows.Forms.Label label11;
        private Control.ZTextBox nendoTextBox;
        private System.Windows.Forms.Label label2;
    }
}