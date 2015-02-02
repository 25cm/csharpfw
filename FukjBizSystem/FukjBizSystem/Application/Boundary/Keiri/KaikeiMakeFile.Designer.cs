namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class KaikeiMakeFileForm
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
            this.syukeiButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.msgTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shiharaiCheckBox = new System.Windows.Forms.CheckBox();
            this.yubinCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bankCheckBox = new System.Windows.Forms.CheckBox();
            this.genkinCheckBox = new System.Windows.Forms.CheckBox();
            this.sabunRadioButton = new System.Windows.Forms.RadioButton();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uriageBatchCheckBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.shisyoComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nyukinRadioButton = new System.Windows.Forms.RadioButton();
            this.uriageRadioButton = new System.Windows.Forms.RadioButton();
            this.taisyoToDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.taisyoFromDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // syukeiButton
            // 
            this.syukeiButton.Location = new System.Drawing.Point(391, 332);
            this.syukeiButton.Name = "syukeiButton";
            this.syukeiButton.Size = new System.Drawing.Size(101, 37);
            this.syukeiButton.TabIndex = 15;
            this.syukeiButton.Text = "F1:集計";
            this.syukeiButton.UseVisualStyleBackColor = true;
            this.syukeiButton.Click += new System.EventHandler(this.syukeiButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.msgTextBox);
            this.mainPanel.Controls.Add(this.groupBox2);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.shisyoComboBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.nyukinRadioButton);
            this.mainPanel.Controls.Add(this.uriageRadioButton);
            this.mainPanel.Controls.Add(this.taisyoToDtDateTimePicker);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.taisyoFromDtDateTimePicker);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.syukeiButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(620, 372);
            this.mainPanel.TabIndex = 0;
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(21, 228);
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.ReadOnly = true;
            this.msgTextBox.Size = new System.Drawing.Size(591, 98);
            this.msgTextBox.TabIndex = 228;
            this.msgTextBox.TabStop = false;
            this.msgTextBox.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shiharaiCheckBox);
            this.groupBox2.Controls.Add(this.yubinCheckBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.bankCheckBox);
            this.groupBox2.Controls.Add(this.genkinCheckBox);
            this.groupBox2.Controls.Add(this.sabunRadioButton);
            this.groupBox2.Controls.Add(this.allRadioButton);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(227, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入金集計条件";
            // 
            // shiharaiCheckBox
            // 
            this.shiharaiCheckBox.AutoSize = true;
            this.shiharaiCheckBox.Location = new System.Drawing.Point(279, 26);
            this.shiharaiCheckBox.Name = "shiharaiCheckBox";
            this.shiharaiCheckBox.Size = new System.Drawing.Size(54, 24);
            this.shiharaiCheckBox.TabIndex = 12;
            this.shiharaiCheckBox.Text = "支払";
            this.shiharaiCheckBox.UseVisualStyleBackColor = true;
            this.shiharaiCheckBox.Visible = false;
            // 
            // yubinCheckBox
            // 
            this.yubinCheckBox.AutoSize = true;
            this.yubinCheckBox.Checked = true;
            this.yubinCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yubinCheckBox.Location = new System.Drawing.Point(99, 26);
            this.yubinCheckBox.Name = "yubinCheckBox";
            this.yubinCheckBox.Size = new System.Drawing.Size(54, 24);
            this.yubinCheckBox.TabIndex = 9;
            this.yubinCheckBox.Text = "郵便";
            this.yubinCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 169;
            this.label3.Text = "作成対象\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(76, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 174;
            this.label1.Text = "*";
            // 
            // bankCheckBox
            // 
            this.bankCheckBox.AutoSize = true;
            this.bankCheckBox.Checked = true;
            this.bankCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bankCheckBox.Location = new System.Drawing.Point(159, 26);
            this.bankCheckBox.Name = "bankCheckBox";
            this.bankCheckBox.Size = new System.Drawing.Size(54, 24);
            this.bankCheckBox.TabIndex = 10;
            this.bankCheckBox.Text = "銀行";
            this.bankCheckBox.UseVisualStyleBackColor = true;
            // 
            // genkinCheckBox
            // 
            this.genkinCheckBox.AutoSize = true;
            this.genkinCheckBox.Checked = true;
            this.genkinCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.genkinCheckBox.Location = new System.Drawing.Point(219, 26);
            this.genkinCheckBox.Name = "genkinCheckBox";
            this.genkinCheckBox.Size = new System.Drawing.Size(54, 24);
            this.genkinCheckBox.TabIndex = 11;
            this.genkinCheckBox.Text = "現金";
            this.genkinCheckBox.UseVisualStyleBackColor = true;
            // 
            // sabunRadioButton
            // 
            this.sabunRadioButton.AutoSize = true;
            this.sabunRadioButton.Checked = true;
            this.sabunRadioButton.Location = new System.Drawing.Point(190, 47);
            this.sabunRadioButton.Name = "sabunRadioButton";
            this.sabunRadioButton.Size = new System.Drawing.Size(143, 24);
            this.sabunRadioButton.TabIndex = 14;
            this.sabunRadioButton.TabStop = true;
            this.sabunRadioButton.Text = "対象差分(入金のみ)";
            this.sabunRadioButton.UseVisualStyleBackColor = true;
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Location = new System.Drawing.Point(99, 45);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(79, 24);
            this.allRadioButton.TabIndex = 13;
            this.allRadioButton.Text = "対象全件";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(7, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(334, 20);
            this.label10.TabIndex = 182;
            this.label10.Text = "※全件とした場合、会計連動済の内容も作成されます。";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 180;
            this.label8.Text = "作成範囲";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(76, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 20);
            this.label9.TabIndex = 181;
            this.label9.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uriageBatchCheckBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(21, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "売上集計条件";
            // 
            // uriageBatchCheckBox
            // 
            this.uriageBatchCheckBox.AutoSize = true;
            this.uriageBatchCheckBox.Location = new System.Drawing.Point(10, 30);
            this.uriageBatchCheckBox.Name = "uriageBatchCheckBox";
            this.uriageBatchCheckBox.Size = new System.Drawing.Size(158, 24);
            this.uriageBatchCheckBox.TabIndex = 7;
            this.uriageBatchCheckBox.Text = "売上集計バッチも実行";
            this.uriageBatchCheckBox.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(9, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(178, 20);
            this.label14.TabIndex = 225;
            this.label14.Text = "※集計に時間がかかります。";
            // 
            // shisyoComboBox
            // 
            this.shisyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shisyoComboBox.FormattingEnabled = true;
            this.shisyoComboBox.Location = new System.Drawing.Point(115, 30);
            this.shisyoComboBox.Name = "shisyoComboBox";
            this.shisyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.shisyoComboBox.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 222;
            this.label13.Text = "支所";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(91, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 20);
            this.label11.TabIndex = 186;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 20);
            this.label12.TabIndex = 185;
            this.label12.Text = "対象区分";
            // 
            // nyukinRadioButton
            // 
            this.nyukinRadioButton.AutoSize = true;
            this.nyukinRadioButton.Checked = true;
            this.nyukinRadioButton.Location = new System.Drawing.Point(176, 5);
            this.nyukinRadioButton.Name = "nyukinRadioButton";
            this.nyukinRadioButton.Size = new System.Drawing.Size(53, 24);
            this.nyukinRadioButton.TabIndex = 2;
            this.nyukinRadioButton.TabStop = true;
            this.nyukinRadioButton.Text = "入金";
            this.nyukinRadioButton.UseVisualStyleBackColor = true;
            // 
            // uriageRadioButton
            // 
            this.uriageRadioButton.AutoSize = true;
            this.uriageRadioButton.Location = new System.Drawing.Point(114, 5);
            this.uriageRadioButton.Name = "uriageRadioButton";
            this.uriageRadioButton.Size = new System.Drawing.Size(53, 24);
            this.uriageRadioButton.TabIndex = 1;
            this.uriageRadioButton.Text = "売上";
            this.uriageRadioButton.UseVisualStyleBackColor = true;
            // 
            // taisyoToDtDateTimePicker
            // 
            this.taisyoToDtDateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.taisyoToDtDateTimePicker.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.taisyoToDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.taisyoToDtDateTimePicker.Location = new System.Drawing.Point(262, 64);
            this.taisyoToDtDateTimePicker.Name = "taisyoToDtDateTimePicker";
            this.taisyoToDtDateTimePicker.Size = new System.Drawing.Size(113, 27);
            this.taisyoToDtDateTimePicker.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 172;
            this.label5.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 171;
            this.label4.Text = "処理メッセージ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 159;
            this.label2.Text = "対象日";
            // 
            // taisyoFromDtDateTimePicker
            // 
            this.taisyoFromDtDateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.taisyoFromDtDateTimePicker.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.taisyoFromDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.taisyoFromDtDateTimePicker.Location = new System.Drawing.Point(115, 64);
            this.taisyoFromDtDateTimePicker.Name = "taisyoFromDtDateTimePicker";
            this.taisyoFromDtDateTimePicker.Size = new System.Drawing.Size(113, 27);
            this.taisyoFromDtDateTimePicker.TabIndex = 4;
            this.taisyoFromDtDateTimePicker.ValueChanged += new System.EventHandler(this.taisyoFromDtDateTimePicker_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(92, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 146;
            this.label7.Text = "*";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(512, 332);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // KaikeiMakeFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 377);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KaikeiMakeFileForm";
            this.Text = "出納データ集計";
            this.Load += new System.EventHandler(this.KaikeiMakeFileForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KaikeiMakeFileForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button syukeiButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private Zynas.Control.ZDate taisyoFromDtDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox yubinCheckBox;
        private System.Windows.Forms.Label label4;
        private Zynas.Control.ZDate taisyoToDtDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox shiharaiCheckBox;
        private System.Windows.Forms.CheckBox genkinCheckBox;
        private System.Windows.Forms.CheckBox bankCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton sabunRadioButton;
        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton nyukinRadioButton;
        private System.Windows.Forms.RadioButton uriageRadioButton;
        private System.Windows.Forms.ComboBox shisyoComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox uriageBatchCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox msgTextBox;
    }
}