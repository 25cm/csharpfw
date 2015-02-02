namespace FukjBizSystem.Application.Boundary.KaiinKanri
{
    partial class KaiinNyukinForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.gyoshaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kakuteiButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.ryosyusyoButton = new System.Windows.Forms.Button();
            this.nennkaihiGakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.nyukaihiGakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.nyukaihiCheckBox = new System.Windows.Forms.CheckBox();
            this.nenkaihiCheckBox = new System.Windows.Forms.CheckBox();
            this.nyukinHohoComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.seikyuRadioButton = new System.Windows.Forms.RadioButton();
            this.genkinRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.uriageDtTextBox = new Zynas.Control.ZDate(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.seisoDtTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.hosyuDtTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.kojiDtTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.seizoDtTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nendoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaCdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "業者名称";
            // 
            // gyoshaNmTextBox
            // 
            this.gyoshaNmTextBox.AllowDropDown = false;
            this.gyoshaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.gyoshaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaNmTextBox.CustomReadOnly = false;
            this.gyoshaNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.gyoshaNmTextBox.Location = new System.Drawing.Point(101, 55);
            this.gyoshaNmTextBox.Name = "gyoshaNmTextBox";
            this.gyoshaNmTextBox.ReadOnly = true;
            this.gyoshaNmTextBox.Size = new System.Drawing.Size(448, 27);
            this.gyoshaNmTextBox.TabIndex = 3;
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Location = new System.Drawing.Point(765, 543);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(101, 37);
            this.kakuteiButton.TabIndex = 26;
            this.kakuteiButton.Text = "F1:登録";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "業者コード";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label16);
            this.mainPanel.Controls.Add(this.ryosyusyoButton);
            this.mainPanel.Controls.Add(this.nennkaihiGakuTextBox);
            this.mainPanel.Controls.Add(this.nyukaihiGakuTextBox);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.nyukaihiCheckBox);
            this.mainPanel.Controls.Add(this.nenkaihiCheckBox);
            this.mainPanel.Controls.Add(this.nyukinHohoComboBox);
            this.mainPanel.Controls.Add(this.label10);
            this.mainPanel.Controls.Add(this.seikyuRadioButton);
            this.mainPanel.Controls.Add(this.genkinRadioButton);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.uriageDtTextBox);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.seisoDtTextBox);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.hosyuDtTextBox);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.kojiDtTextBox);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.seizoDtTextBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.nendoTextBox);
            this.mainPanel.Controls.Add(this.gyoshaCdTextBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.gyoshaNmTextBox);
            this.mainPanel.Controls.Add(this.kakuteiButton);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 20);
            this.label16.TabIndex = 13;
            this.label16.Text = "登録年度";
            // 
            // ryosyusyoButton
            // 
            this.ryosyusyoButton.Location = new System.Drawing.Point(872, 543);
            this.ryosyusyoButton.Name = "ryosyusyoButton";
            this.ryosyusyoButton.Size = new System.Drawing.Size(101, 37);
            this.ryosyusyoButton.TabIndex = 27;
            this.ryosyusyoButton.Text = "F6:領収書";
            this.ryosyusyoButton.UseVisualStyleBackColor = true;
            this.ryosyusyoButton.Click += new System.EventHandler(this.ryosyusyoButton_Click);
            // 
            // nennkaihiGakuTextBox
            // 
            this.nennkaihiGakuTextBox.AllowDropDown = false;
            this.nennkaihiGakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.nennkaihiGakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.nennkaihiGakuTextBox.CustomReadOnly = false;
            this.nennkaihiGakuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nennkaihiGakuTextBox.Location = new System.Drawing.Point(116, 197);
            this.nennkaihiGakuTextBox.MaxLength = 10;
            this.nennkaihiGakuTextBox.Name = "nennkaihiGakuTextBox";
            this.nennkaihiGakuTextBox.Size = new System.Drawing.Size(109, 27);
            this.nennkaihiGakuTextBox.TabIndex = 16;
            this.nennkaihiGakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nyukaihiGakuTextBox
            // 
            this.nyukaihiGakuTextBox.AllowDropDown = false;
            this.nyukaihiGakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.nyukaihiGakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.nyukaihiGakuTextBox.CustomReadOnly = false;
            this.nyukaihiGakuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nyukaihiGakuTextBox.Location = new System.Drawing.Point(351, 197);
            this.nyukaihiGakuTextBox.MaxLength = 10;
            this.nyukaihiGakuTextBox.Name = "nyukaihiGakuTextBox";
            this.nyukaihiGakuTextBox.Size = new System.Drawing.Size(109, 27);
            this.nyukaihiGakuTextBox.TabIndex = 18;
            this.nyukaihiGakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(437, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 20);
            this.label11.TabIndex = 196;
            // 
            // nyukaihiCheckBox
            // 
            this.nyukaihiCheckBox.AutoSize = true;
            this.nyukaihiCheckBox.Location = new System.Drawing.Point(252, 199);
            this.nyukaihiCheckBox.Name = "nyukaihiCheckBox";
            this.nyukaihiCheckBox.Size = new System.Drawing.Size(93, 24);
            this.nyukaihiCheckBox.TabIndex = 17;
            this.nyukaihiCheckBox.Text = "入会費入金";
            this.nyukaihiCheckBox.UseVisualStyleBackColor = true;
            // 
            // nenkaihiCheckBox
            // 
            this.nenkaihiCheckBox.AutoSize = true;
            this.nenkaihiCheckBox.Checked = true;
            this.nenkaihiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nenkaihiCheckBox.Location = new System.Drawing.Point(19, 199);
            this.nenkaihiCheckBox.Name = "nenkaihiCheckBox";
            this.nenkaihiCheckBox.Size = new System.Drawing.Size(93, 24);
            this.nenkaihiCheckBox.TabIndex = 15;
            this.nenkaihiCheckBox.Text = "年会費入金";
            this.nenkaihiCheckBox.UseVisualStyleBackColor = true;
            // 
            // nyukinHohoComboBox
            // 
            this.nyukinHohoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nyukinHohoComboBox.FormattingEnabled = true;
            this.nyukinHohoComboBox.Location = new System.Drawing.Point(116, 262);
            this.nyukinHohoComboBox.Name = "nyukinHohoComboBox";
            this.nyukinHohoComboBox.Size = new System.Drawing.Size(109, 28);
            this.nyukinHohoComboBox.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "入金方法";
            // 
            // seikyuRadioButton
            // 
            this.seikyuRadioButton.AutoSize = true;
            this.seikyuRadioButton.Location = new System.Drawing.Point(190, 232);
            this.seikyuRadioButton.Name = "seikyuRadioButton";
            this.seikyuRadioButton.Size = new System.Drawing.Size(53, 24);
            this.seikyuRadioButton.TabIndex = 21;
            this.seikyuRadioButton.Text = "請求";
            this.seikyuRadioButton.UseVisualStyleBackColor = true;
            // 
            // genkinRadioButton
            // 
            this.genkinRadioButton.AutoSize = true;
            this.genkinRadioButton.Checked = true;
            this.genkinRadioButton.Location = new System.Drawing.Point(116, 232);
            this.genkinRadioButton.Name = "genkinRadioButton";
            this.genkinRadioButton.Size = new System.Drawing.Size(53, 24);
            this.genkinRadioButton.TabIndex = 20;
            this.genkinRadioButton.TabStop = true;
            this.genkinRadioButton.Text = "現金";
            this.genkinRadioButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "入金種別";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 301);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 24;
            this.label19.Text = "売上計上日";
            // 
            // uriageDtTextBox
            // 
            this.uriageDtTextBox.CustomFormat = "yyyy/MM/dd";
            this.uriageDtTextBox.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uriageDtTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uriageDtTextBox.Location = new System.Drawing.Point(116, 296);
            this.uriageDtTextBox.Name = "uriageDtTextBox";
            this.uriageDtTextBox.Size = new System.Drawing.Size(113, 27);
            this.uriageDtTextBox.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "清掃部会";
            // 
            // seisoDtTextBox
            // 
            this.seisoDtTextBox.AllowDropDown = false;
            this.seisoDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.seisoDtTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.seisoDtTextBox.CustomReadOnly = false;
            this.seisoDtTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.seisoDtTextBox.Location = new System.Drawing.Point(401, 123);
            this.seisoDtTextBox.Name = "seisoDtTextBox";
            this.seisoDtTextBox.ReadOnly = true;
            this.seisoDtTextBox.Size = new System.Drawing.Size(96, 27);
            this.seisoDtTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "保守部会";
            // 
            // hosyuDtTextBox
            // 
            this.hosyuDtTextBox.AllowDropDown = false;
            this.hosyuDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.hosyuDtTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.hosyuDtTextBox.CustomReadOnly = false;
            this.hosyuDtTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.hosyuDtTextBox.Location = new System.Drawing.Point(301, 123);
            this.hosyuDtTextBox.Name = "hosyuDtTextBox";
            this.hosyuDtTextBox.ReadOnly = true;
            this.hosyuDtTextBox.Size = new System.Drawing.Size(96, 27);
            this.hosyuDtTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "工事部会";
            // 
            // kojiDtTextBox
            // 
            this.kojiDtTextBox.AllowDropDown = false;
            this.kojiDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.kojiDtTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kojiDtTextBox.CustomReadOnly = false;
            this.kojiDtTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.kojiDtTextBox.Location = new System.Drawing.Point(200, 123);
            this.kojiDtTextBox.Name = "kojiDtTextBox";
            this.kojiDtTextBox.ReadOnly = true;
            this.kojiDtTextBox.Size = new System.Drawing.Size(96, 27);
            this.kojiDtTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "製造部会";
            // 
            // seizoDtTextBox
            // 
            this.seizoDtTextBox.AllowDropDown = false;
            this.seizoDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.seizoDtTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.seizoDtTextBox.CustomReadOnly = false;
            this.seizoDtTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.seizoDtTextBox.Location = new System.Drawing.Point(98, 123);
            this.seizoDtTextBox.Name = "seizoDtTextBox";
            this.seizoDtTextBox.ReadOnly = true;
            this.seizoDtTextBox.Size = new System.Drawing.Size(96, 27);
            this.seizoDtTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "入会日";
            // 
            // nendoTextBox
            // 
            this.nendoTextBox.AllowDropDown = false;
            this.nendoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_NENDO;
            this.nendoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.nendoTextBox.CustomReadOnly = false;
            this.nendoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nendoTextBox.Location = new System.Drawing.Point(116, 166);
            this.nendoTextBox.MaxLength = 4;
            this.nendoTextBox.Name = "nendoTextBox";
            this.nendoTextBox.Size = new System.Drawing.Size(50, 27);
            this.nendoTextBox.TabIndex = 14;
            // 
            // gyoshaCdTextBox
            // 
            this.gyoshaCdTextBox.AllowDropDown = false;
            this.gyoshaCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyoshaCdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.gyoshaCdTextBox.CustomReadOnly = false;
            this.gyoshaCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyoshaCdTextBox.Location = new System.Drawing.Point(101, 22);
            this.gyoshaCdTextBox.MaxLength = 4;
            this.gyoshaCdTextBox.Name = "gyoshaCdTextBox";
            this.gyoshaCdTextBox.ReadOnly = true;
            this.gyoshaCdTextBox.Size = new System.Drawing.Size(62, 27);
            this.gyoshaCdTextBox.TabIndex = 1;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(988, 543);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 28;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // KaiinNyukinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KaiinNyukinForm";
            this.Text = "会費入金入力";
            this.Load += new System.EventHandler(this.KaiinNyukinForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KaiinNyukinForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FukjBizSystem.Control.ZTextBox gyoshaNmTextBox;
        private System.Windows.Forms.Button kakuteiButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private Control.ZTextBox gyoshaCdTextBox;
        private System.Windows.Forms.Label label3;
        private FukjBizSystem.Control.ZTextBox seizoDtTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private FukjBizSystem.Control.ZTextBox seisoDtTextBox;
        private System.Windows.Forms.Label label6;
        private FukjBizSystem.Control.ZTextBox hosyuDtTextBox;
        private System.Windows.Forms.Label label4;
        private FukjBizSystem.Control.ZTextBox kojiDtTextBox;
        private Control.ZTextBox nennkaihiGakuTextBox;
        private System.Windows.Forms.RadioButton seikyuRadioButton;
        private System.Windows.Forms.RadioButton genkinRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label19;
        private Zynas.Control.ZDate uriageDtTextBox;
        private System.Windows.Forms.ComboBox nyukinHohoComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox nenkaihiCheckBox;
        private System.Windows.Forms.Button ryosyusyoButton;
        private Control.ZTextBox nyukaihiGakuTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox nyukaihiCheckBox;
        private System.Windows.Forms.Label label16;
        private Control.ZTextBox nendoTextBox;
    }
}