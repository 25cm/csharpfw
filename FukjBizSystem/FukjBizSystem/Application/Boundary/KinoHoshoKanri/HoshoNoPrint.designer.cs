namespace FukjBizSystem.Application.Boundary.KinoHoshoKanri
{
    partial class HoshoNoPrintForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.printCountTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hoshoTorokuRenbanToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hoshoTorokuNendoToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hoshoTorokuKensakikanToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hoshoTorokuRenbanFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hoshoTorokuNendoFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hoshoTorokuKensakikanFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.torokuKakuninHojinNmComboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.kensaKikanNmComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tsuikaKisaiKomokuTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kakuninshaNmTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HakkoShubetsuGroupBox = new System.Windows.Forms.GroupBox();
            this.saiHakkoRadioButton = new System.Windows.Forms.RadioButton();
            this.shinkiHakkoRadioButton = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.HakkoShubetsuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.printCountTextBox);
            this.mainPanel.Controls.Add(this.hoshoTorokuRenbanToTextBox);
            this.mainPanel.Controls.Add(this.hoshoTorokuNendoToTextBox);
            this.mainPanel.Controls.Add(this.hoshoTorokuKensakikanToTextBox);
            this.mainPanel.Controls.Add(this.hoshoTorokuRenbanFromTextBox);
            this.mainPanel.Controls.Add(this.hoshoTorokuNendoFromTextBox);
            this.mainPanel.Controls.Add(this.hoshoTorokuKensakikanFromTextBox);
            this.mainPanel.Controls.Add(this.label20);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.label18);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.torokuKakuninHojinNmComboBox);
            this.mainPanel.Controls.Add(this.label21);
            this.mainPanel.Controls.Add(this.label22);
            this.mainPanel.Controls.Add(this.kensaKikanNmComboBox);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.tsuikaKisaiKomokuTextBox);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.label16);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.kakuninshaNmTextBox);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.HakkoShubetsuGroupBox);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.printButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1096, 593);
            this.mainPanel.TabIndex = 0;
            // 
            // printCountTextBox
            // 
            this.printCountTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.printCountTextBox.CustomDigitParts = 0;
            this.printCountTextBox.CustomFormat = null;
            this.printCountTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.printCountTextBox.CustomReadOnly = false;
            this.printCountTextBox.Location = new System.Drawing.Point(124, 133);
            this.printCountTextBox.MaxLength = 4;
            this.printCountTextBox.Name = "printCountTextBox";
            this.printCountTextBox.Size = new System.Drawing.Size(68, 27);
            this.printCountTextBox.TabIndex = 17;
            // 
            // hoshoTorokuRenbanToTextBox
            // 
            this.hoshoTorokuRenbanToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hoshoTorokuRenbanToTextBox.CustomDigitParts = 0;
            this.hoshoTorokuRenbanToTextBox.CustomFormat = null;
            this.hoshoTorokuRenbanToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hoshoTorokuRenbanToTextBox.CustomReadOnly = false;
            this.hoshoTorokuRenbanToTextBox.Location = new System.Drawing.Point(483, 70);
            this.hoshoTorokuRenbanToTextBox.MaxLength = 5;
            this.hoshoTorokuRenbanToTextBox.Name = "hoshoTorokuRenbanToTextBox";
            this.hoshoTorokuRenbanToTextBox.Size = new System.Drawing.Size(77, 27);
            this.hoshoTorokuRenbanToTextBox.TabIndex = 13;
            this.hoshoTorokuRenbanToTextBox.Leave += new System.EventHandler(this.hoshoTorokuRenbanToTextBox_Leave);
            // 
            // hoshoTorokuNendoToTextBox
            // 
            this.hoshoTorokuNendoToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hoshoTorokuNendoToTextBox.CustomDigitParts = 0;
            this.hoshoTorokuNendoToTextBox.CustomFormat = null;
            this.hoshoTorokuNendoToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hoshoTorokuNendoToTextBox.CustomReadOnly = false;
            this.hoshoTorokuNendoToTextBox.Location = new System.Drawing.Point(433, 70);
            this.hoshoTorokuNendoToTextBox.MaxLength = 2;
            this.hoshoTorokuNendoToTextBox.Name = "hoshoTorokuNendoToTextBox";
            this.hoshoTorokuNendoToTextBox.Size = new System.Drawing.Size(31, 27);
            this.hoshoTorokuNendoToTextBox.TabIndex = 11;
            this.hoshoTorokuNendoToTextBox.Leave += new System.EventHandler(this.hoshoTorokuNendoToTextBox_Leave);
            // 
            // hoshoTorokuKensakikanToTextBox
            // 
            this.hoshoTorokuKensakikanToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hoshoTorokuKensakikanToTextBox.CustomDigitParts = 0;
            this.hoshoTorokuKensakikanToTextBox.CustomFormat = null;
            this.hoshoTorokuKensakikanToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hoshoTorokuKensakikanToTextBox.CustomReadOnly = false;
            this.hoshoTorokuKensakikanToTextBox.Location = new System.Drawing.Point(359, 71);
            this.hoshoTorokuKensakikanToTextBox.MaxLength = 4;
            this.hoshoTorokuKensakikanToTextBox.Name = "hoshoTorokuKensakikanToTextBox";
            this.hoshoTorokuKensakikanToTextBox.Size = new System.Drawing.Size(56, 27);
            this.hoshoTorokuKensakikanToTextBox.TabIndex = 9;
            this.hoshoTorokuKensakikanToTextBox.Leave += new System.EventHandler(this.hoshoTorokuKensakikanToTextBox_Leave);
            // 
            // hoshoTorokuRenbanFromTextBox
            // 
            this.hoshoTorokuRenbanFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hoshoTorokuRenbanFromTextBox.CustomDigitParts = 0;
            this.hoshoTorokuRenbanFromTextBox.CustomFormat = null;
            this.hoshoTorokuRenbanFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hoshoTorokuRenbanFromTextBox.CustomReadOnly = false;
            this.hoshoTorokuRenbanFromTextBox.Location = new System.Drawing.Point(248, 71);
            this.hoshoTorokuRenbanFromTextBox.MaxLength = 5;
            this.hoshoTorokuRenbanFromTextBox.Name = "hoshoTorokuRenbanFromTextBox";
            this.hoshoTorokuRenbanFromTextBox.Size = new System.Drawing.Size(77, 27);
            this.hoshoTorokuRenbanFromTextBox.TabIndex = 7;
            this.hoshoTorokuRenbanFromTextBox.Leave += new System.EventHandler(this.hoshoTorokuRenbanFromTextBox_Leave);
            // 
            // hoshoTorokuNendoFromTextBox
            // 
            this.hoshoTorokuNendoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hoshoTorokuNendoFromTextBox.CustomDigitParts = 0;
            this.hoshoTorokuNendoFromTextBox.CustomFormat = null;
            this.hoshoTorokuNendoFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hoshoTorokuNendoFromTextBox.CustomReadOnly = false;
            this.hoshoTorokuNendoFromTextBox.Location = new System.Drawing.Point(198, 71);
            this.hoshoTorokuNendoFromTextBox.MaxLength = 2;
            this.hoshoTorokuNendoFromTextBox.Name = "hoshoTorokuNendoFromTextBox";
            this.hoshoTorokuNendoFromTextBox.Size = new System.Drawing.Size(31, 27);
            this.hoshoTorokuNendoFromTextBox.TabIndex = 5;
            this.hoshoTorokuNendoFromTextBox.Leave += new System.EventHandler(this.hoshoTorokuNendoFromTextBox_Leave);
            // 
            // hoshoTorokuKensakikanFromTextBox
            // 
            this.hoshoTorokuKensakikanFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hoshoTorokuKensakikanFromTextBox.CustomDigitParts = 0;
            this.hoshoTorokuKensakikanFromTextBox.CustomFormat = null;
            this.hoshoTorokuKensakikanFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hoshoTorokuKensakikanFromTextBox.CustomReadOnly = false;
            this.hoshoTorokuKensakikanFromTextBox.Location = new System.Drawing.Point(124, 72);
            this.hoshoTorokuKensakikanFromTextBox.MaxLength = 4;
            this.hoshoTorokuKensakikanFromTextBox.Name = "hoshoTorokuKensakikanFromTextBox";
            this.hoshoTorokuKensakikanFromTextBox.Size = new System.Drawing.Size(56, 27);
            this.hoshoTorokuKensakikanFromTextBox.TabIndex = 3;
            this.hoshoTorokuKensakikanFromTextBox.Leave += new System.EventHandler(this.hoshoTorokuKensakikanFromTextBox_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(355, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(168, 20);
            this.label20.TabIndex = 15;
            this.label20.Text = "例) 4000-25-01234 (半角";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(120, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(168, 20);
            this.label19.TabIndex = 14;
            this.label19.Text = "例) 4000-25-01234 (半角";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(466, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 12;
            this.label15.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(416, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 20);
            this.label18.TabIndex = 10;
            this.label18.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(331, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 20);
            this.label17.TabIndex = 8;
            this.label17.Text = "～";
            // 
            // torokuKakuninHojinNmComboBox
            // 
            this.torokuKakuninHojinNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.torokuKakuninHojinNmComboBox.FormattingEnabled = true;
            this.torokuKakuninHojinNmComboBox.Location = new System.Drawing.Point(124, 235);
            this.torokuKakuninHojinNmComboBox.Name = "torokuKakuninHojinNmComboBox";
            this.torokuKakuninHojinNmComboBox.Size = new System.Drawing.Size(274, 28);
            this.torokuKakuninHojinNmComboBox.TabIndex = 31;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(91, 240);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 20);
            this.label21.TabIndex = 30;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 238);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 20);
            this.label22.TabIndex = 29;
            this.label22.Text = "登録確認法人";
            // 
            // kensaKikanNmComboBox
            // 
            this.kensaKikanNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensaKikanNmComboBox.FormattingEnabled = true;
            this.kensaKikanNmComboBox.Location = new System.Drawing.Point(124, 167);
            this.kensaKikanNmComboBox.Name = "kensaKikanNmComboBox";
            this.kensaKikanNmComboBox.Size = new System.Drawing.Size(274, 28);
            this.kensaKikanNmComboBox.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(65, 274);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "*";
            // 
            // tsuikaKisaiKomokuTextBox
            // 
            this.tsuikaKisaiKomokuTextBox.Location = new System.Drawing.Point(124, 202);
            this.tsuikaKisaiKomokuTextBox.Name = "tsuikaKisaiKomokuTextBox";
            this.tsuikaKisaiKomokuTextBox.ReadOnly = true;
            this.tsuikaKisaiKomokuTextBox.Size = new System.Drawing.Size(447, 27);
            this.tsuikaKisaiKomokuTextBox.TabIndex = 28;
            this.tsuikaKisaiKomokuTextBox.Text = "保健所受付番号[　　　　　　]　保健所受付日[平成 　年　月　日]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "追加記載項目";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "保証登録番号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "確認者名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(65, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "*";
            // 
            // kakuninshaNmTextBox
            // 
            this.kakuninshaNmTextBox.Location = new System.Drawing.Point(124, 269);
            this.kakuninshaNmTextBox.MaxLength = 20;
            this.kakuninshaNmTextBox.Name = "kakuninshaNmTextBox";
            this.kakuninshaNmTextBox.Size = new System.Drawing.Size(274, 27);
            this.kakuninshaNmTextBox.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "検査機関";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "印刷枚数";
            // 
            // HakkoShubetsuGroupBox
            // 
            this.HakkoShubetsuGroupBox.Controls.Add(this.saiHakkoRadioButton);
            this.HakkoShubetsuGroupBox.Controls.Add(this.shinkiHakkoRadioButton);
            this.HakkoShubetsuGroupBox.Location = new System.Drawing.Point(124, 12);
            this.HakkoShubetsuGroupBox.Name = "HakkoShubetsuGroupBox";
            this.HakkoShubetsuGroupBox.Size = new System.Drawing.Size(274, 51);
            this.HakkoShubetsuGroupBox.TabIndex = 1;
            this.HakkoShubetsuGroupBox.TabStop = false;
            // 
            // saiHakkoRadioButton
            // 
            this.saiHakkoRadioButton.AutoSize = true;
            this.saiHakkoRadioButton.Location = new System.Drawing.Point(142, 18);
            this.saiHakkoRadioButton.Name = "saiHakkoRadioButton";
            this.saiHakkoRadioButton.Size = new System.Drawing.Size(66, 24);
            this.saiHakkoRadioButton.TabIndex = 1;
            this.saiHakkoRadioButton.Text = "再発行";
            this.saiHakkoRadioButton.UseVisualStyleBackColor = true;
            this.saiHakkoRadioButton.CheckedChanged += new System.EventHandler(this.saiHakkoRadioButton_CheckedChanged);
            // 
            // shinkiHakkoRadioButton
            // 
            this.shinkiHakkoRadioButton.AutoSize = true;
            this.shinkiHakkoRadioButton.Checked = true;
            this.shinkiHakkoRadioButton.Location = new System.Drawing.Point(20, 18);
            this.shinkiHakkoRadioButton.Name = "shinkiHakkoRadioButton";
            this.shinkiHakkoRadioButton.Size = new System.Drawing.Size(79, 24);
            this.shinkiHakkoRadioButton.TabIndex = 0;
            this.shinkiHakkoRadioButton.TabStop = true;
            this.shinkiHakkoRadioButton.Text = "新規発行";
            this.shinkiHakkoRadioButton.UseVisualStyleBackColor = true;
            this.shinkiHakkoRadioButton.CheckedChanged += new System.EventHandler(this.shinkiHakkoRadioButton_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "発行種別";
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(849, 553);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(101, 37);
            this.printButton.TabIndex = 35;
            this.printButton.Text = "F1:印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 36;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HoshoNoPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HoshoNoPrintForm";
            this.Text = "保証番号印刷";
            this.Load += new System.EventHandler(this.HoshoNoPrintForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HoshoNoPrint_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.HakkoShubetsuGroupBox.ResumeLayout(false);
            this.HakkoShubetsuGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.GroupBox HakkoShubetsuGroupBox;
        private System.Windows.Forms.RadioButton saiHakkoRadioButton;
        private System.Windows.Forms.RadioButton shinkiHakkoRadioButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox torokuKakuninHojinNmComboBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox kensaKikanNmComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tsuikaKisaiKomokuTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox kakuninshaNmTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Control.NumberTextBox hoshoTorokuRenbanToTextBox;
        private Control.NumberTextBox hoshoTorokuNendoToTextBox;
        private Control.NumberTextBox hoshoTorokuKensakikanToTextBox;
        private Control.NumberTextBox hoshoTorokuRenbanFromTextBox;
        private Control.NumberTextBox hoshoTorokuNendoFromTextBox;
        private Control.NumberTextBox hoshoTorokuKensakikanFromTextBox;
        private Control.NumberTextBox printCountTextBox;
    }
}