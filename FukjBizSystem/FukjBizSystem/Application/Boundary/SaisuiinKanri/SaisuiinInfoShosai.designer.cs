namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    partial class SaisuiinInfoShosaiForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.saisuiinTorikeshiDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.chancelDtAddFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zenkaiJyukoDtAddFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.zenkaiJukoDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.yukokigenAddFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.jukoDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.syutokuDtAddFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.saisuiinYukokigenDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saisuiinSyutokuDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saisuiinCdTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.kanrishiNoTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label35 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.kanrishiSyutokuDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saisuiinSeinegappiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.syozokuGyosyaCdTextBox = new System.Windows.Forms.TextBox();
            this.shozokuGyosyaSearchButton = new System.Windows.Forms.Button();
            this.addressSearchButton = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.syozokuGyosyaNmTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saisuiinNmTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saisuiinKanaTextBox = new System.Windows.Forms.TextBox();
            this.saisuiinZipCdTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.saisuiinAdrTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.saisuiinTelNoTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.entryButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.decisionButton = new System.Windows.Forms.Button();
            this.reInputButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "採水員コード";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.saisuiinTorikeshiDtDateTimePicker);
            this.mainPanel.Controls.Add(this.chancelDtAddFlgCheckBox);
            this.mainPanel.Controls.Add(this.label33);
            this.mainPanel.Controls.Add(this.label31);
            this.mainPanel.Controls.Add(this.groupBox2);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.changeButton);
            this.mainPanel.Controls.Add(this.decisionButton);
            this.mainPanel.Controls.Add(this.reInputButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1102, 593);
            this.mainPanel.TabIndex = 0;
            // 
            // saisuiinTorikeshiDtDateTimePicker
            // 
            this.saisuiinTorikeshiDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.saisuiinTorikeshiDtDateTimePicker.Enabled = false;
            this.saisuiinTorikeshiDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saisuiinTorikeshiDtDateTimePicker.Location = new System.Drawing.Point(108, 493);
            this.saisuiinTorikeshiDtDateTimePicker.Name = "saisuiinTorikeshiDtDateTimePicker";
            this.saisuiinTorikeshiDtDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.saisuiinTorikeshiDtDateTimePicker.TabIndex = 5;
            // 
            // chancelDtAddFlgCheckBox
            // 
            this.chancelDtAddFlgCheckBox.AutoSize = true;
            this.chancelDtAddFlgCheckBox.Location = new System.Drawing.Point(26, 495);
            this.chancelDtAddFlgCheckBox.Name = "chancelDtAddFlgCheckBox";
            this.chancelDtAddFlgCheckBox.Size = new System.Drawing.Size(67, 24);
            this.chancelDtAddFlgCheckBox.TabIndex = 4;
            this.chancelDtAddFlgCheckBox.Text = "取消日";
            this.chancelDtAddFlgCheckBox.UseVisualStyleBackColor = true;
            this.chancelDtAddFlgCheckBox.CheckedChanged += new System.EventHandler(this.chancelDtAddFlgCheckBox_CheckedChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(19, 406);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(74, 20);
            this.label33.TabIndex = 2;
            this.label33.Text = "講習会情報";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(19, 30);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 20);
            this.label31.TabIndex = 0;
            this.label31.Text = "採水員情報";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zenkaiJyukoDtAddFlgCheckBox);
            this.groupBox2.Controls.Add(this.zenkaiJukoDtDateTimePicker);
            this.groupBox2.Controls.Add(this.yukokigenAddFlgCheckBox);
            this.groupBox2.Controls.Add(this.jukoDtDateTimePicker);
            this.groupBox2.Controls.Add(this.syutokuDtAddFlgCheckBox);
            this.groupBox2.Controls.Add(this.saisuiinYukokigenDtDateTimePicker);
            this.groupBox2.Controls.Add(this.saisuiinSyutokuDtDateTimePicker);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Location = new System.Drawing.Point(108, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 101);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // zenkaiJyukoDtAddFlgCheckBox
            // 
            this.zenkaiJyukoDtAddFlgCheckBox.AutoSize = true;
            this.zenkaiJyukoDtAddFlgCheckBox.Location = new System.Drawing.Point(294, 62);
            this.zenkaiJyukoDtAddFlgCheckBox.Name = "zenkaiJyukoDtAddFlgCheckBox";
            this.zenkaiJyukoDtAddFlgCheckBox.Size = new System.Drawing.Size(93, 24);
            this.zenkaiJyukoDtAddFlgCheckBox.TabIndex = 7;
            this.zenkaiJyukoDtAddFlgCheckBox.Text = "前回受講日";
            this.zenkaiJyukoDtAddFlgCheckBox.UseVisualStyleBackColor = true;
            this.zenkaiJyukoDtAddFlgCheckBox.CheckedChanged += new System.EventHandler(this.zenkaiJyukoDtAddFlgCheckBox_CheckedChanged);
            // 
            // zenkaiJukoDtDateTimePicker
            // 
            this.zenkaiJukoDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.zenkaiJukoDtDateTimePicker.Enabled = false;
            this.zenkaiJukoDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.zenkaiJukoDtDateTimePicker.Location = new System.Drawing.Point(403, 59);
            this.zenkaiJukoDtDateTimePicker.Name = "zenkaiJukoDtDateTimePicker";
            this.zenkaiJukoDtDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.zenkaiJukoDtDateTimePicker.TabIndex = 8;
            // 
            // yukokigenAddFlgCheckBox
            // 
            this.yukokigenAddFlgCheckBox.AutoSize = true;
            this.yukokigenAddFlgCheckBox.Location = new System.Drawing.Point(21, 58);
            this.yukokigenAddFlgCheckBox.Name = "yukokigenAddFlgCheckBox";
            this.yukokigenAddFlgCheckBox.Size = new System.Drawing.Size(80, 24);
            this.yukokigenAddFlgCheckBox.TabIndex = 5;
            this.yukokigenAddFlgCheckBox.Text = "有効期限";
            this.yukokigenAddFlgCheckBox.UseVisualStyleBackColor = true;
            this.yukokigenAddFlgCheckBox.CheckedChanged += new System.EventHandler(this.yukokigenAddFlgCheckBox_CheckedChanged);
            // 
            // jukoDtDateTimePicker
            // 
            this.jukoDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.jukoDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jukoDtDateTimePicker.Location = new System.Drawing.Point(403, 26);
            this.jukoDtDateTimePicker.Name = "jukoDtDateTimePicker";
            this.jukoDtDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.jukoDtDateTimePicker.TabIndex = 4;
            // 
            // syutokuDtAddFlgCheckBox
            // 
            this.syutokuDtAddFlgCheckBox.AutoSize = true;
            this.syutokuDtAddFlgCheckBox.Location = new System.Drawing.Point(21, 29);
            this.syutokuDtAddFlgCheckBox.Name = "syutokuDtAddFlgCheckBox";
            this.syutokuDtAddFlgCheckBox.Size = new System.Drawing.Size(67, 24);
            this.syutokuDtAddFlgCheckBox.TabIndex = 0;
            this.syutokuDtAddFlgCheckBox.Text = "取得日";
            this.syutokuDtAddFlgCheckBox.UseVisualStyleBackColor = true;
            this.syutokuDtAddFlgCheckBox.CheckedChanged += new System.EventHandler(this.syutokuDtAddFlgCheckBox_CheckedChanged);
            // 
            // saisuiinYukokigenDtDateTimePicker
            // 
            this.saisuiinYukokigenDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.saisuiinYukokigenDtDateTimePicker.Enabled = false;
            this.saisuiinYukokigenDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saisuiinYukokigenDtDateTimePicker.Location = new System.Drawing.Point(124, 59);
            this.saisuiinYukokigenDtDateTimePicker.Name = "saisuiinYukokigenDtDateTimePicker";
            this.saisuiinYukokigenDtDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.saisuiinYukokigenDtDateTimePicker.TabIndex = 6;
            // 
            // saisuiinSyutokuDtDateTimePicker
            // 
            this.saisuiinSyutokuDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.saisuiinSyutokuDtDateTimePicker.Enabled = false;
            this.saisuiinSyutokuDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saisuiinSyutokuDtDateTimePicker.Location = new System.Drawing.Point(124, 26);
            this.saisuiinSyutokuDtDateTimePicker.Name = "saisuiinSyutokuDtDateTimePicker";
            this.saisuiinSyutokuDtDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.saisuiinSyutokuDtDateTimePicker.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(352, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 20);
            this.label24.TabIndex = 3;
            this.label24.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(310, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 20);
            this.label25.TabIndex = 2;
            this.label25.Text = "受講日";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saisuiinCdTextBox);
            this.groupBox1.Controls.Add(this.kanrishiNoTextBox);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.kanrishiSyutokuDtDateTimePicker);
            this.groupBox1.Controls.Add(this.saisuiinSeinegappiDateTimePicker);
            this.groupBox1.Controls.Add(this.syozokuGyosyaCdTextBox);
            this.groupBox1.Controls.Add(this.shozokuGyosyaSearchButton);
            this.groupBox1.Controls.Add(this.addressSearchButton);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.syozokuGyosyaNmTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.saisuiinNmTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.saisuiinKanaTextBox);
            this.groupBox1.Controls.Add(this.saisuiinZipCdTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.saisuiinAdrTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.saisuiinTelNoTextBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(108, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 368);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // saisuiinCdTextBox
            // 
            this.saisuiinCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.saisuiinCdTextBox.CustomDigitParts = 0;
            this.saisuiinCdTextBox.CustomFormat = null;
            this.saisuiinCdTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.saisuiinCdTextBox.CustomReadOnly = false;
            this.saisuiinCdTextBox.Location = new System.Drawing.Point(124, 24);
            this.saisuiinCdTextBox.MaxLength = 5;
            this.saisuiinCdTextBox.Name = "saisuiinCdTextBox";
            this.saisuiinCdTextBox.ReadOnly = true;
            this.saisuiinCdTextBox.Size = new System.Drawing.Size(49, 27);
            this.saisuiinCdTextBox.TabIndex = 2;
            // 
            // kanrishiNoTextBox
            // 
            this.kanrishiNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kanrishiNoTextBox.CustomDigitParts = 0;
            this.kanrishiNoTextBox.CustomFormat = null;
            this.kanrishiNoTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.kanrishiNoTextBox.CustomReadOnly = false;
            this.kanrishiNoTextBox.Location = new System.Drawing.Point(124, 288);
            this.kanrishiNoTextBox.MaxLength = 10;
            this.kanrishiNoTextBox.Name = "kanrishiNoTextBox";
            this.kanrishiNoTextBox.Size = new System.Drawing.Size(100, 27);
            this.kanrishiNoTextBox.TabIndex = 32;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.Red;
            this.label35.Location = new System.Drawing.Point(230, 291);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(148, 20);
            this.label35.TabIndex = 33;
            this.label35.Text = "例) 0123456789 (半角";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(250, 225);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(168, 20);
            this.label30.TabIndex = 26;
            this.label30.Text = "例) 090-0123-4567 (半角";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Location = new System.Drawing.Point(179, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(108, 20);
            this.label29.TabIndex = 3;
            this.label29.Text = "例) 01234 (半角";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(243, 159);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(130, 20);
            this.label28.TabIndex = 19;
            this.label28.Text = "例) 810-0123 (半角";
            // 
            // kanrishiSyutokuDtDateTimePicker
            // 
            this.kanrishiSyutokuDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kanrishiSyutokuDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kanrishiSyutokuDtDateTimePicker.Location = new System.Drawing.Point(124, 321);
            this.kanrishiSyutokuDtDateTimePicker.Name = "kanrishiSyutokuDtDateTimePicker";
            this.kanrishiSyutokuDtDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.kanrishiSyutokuDtDateTimePicker.TabIndex = 36;
            // 
            // saisuiinSeinegappiDateTimePicker
            // 
            this.saisuiinSeinegappiDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.saisuiinSeinegappiDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saisuiinSeinegappiDateTimePicker.Location = new System.Drawing.Point(124, 255);
            this.saisuiinSeinegappiDateTimePicker.Name = "saisuiinSeinegappiDateTimePicker";
            this.saisuiinSeinegappiDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.saisuiinSeinegappiDateTimePicker.TabIndex = 29;
            // 
            // syozokuGyosyaCdTextBox
            // 
            this.syozokuGyosyaCdTextBox.Location = new System.Drawing.Point(363, 57);
            this.syozokuGyosyaCdTextBox.Name = "syozokuGyosyaCdTextBox";
            this.syozokuGyosyaCdTextBox.Size = new System.Drawing.Size(50, 27);
            this.syozokuGyosyaCdTextBox.TabIndex = 8;
            this.syozokuGyosyaCdTextBox.Visible = false;
            // 
            // shozokuGyosyaSearchButton
            // 
            this.shozokuGyosyaSearchButton.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.shozokuGyosyaSearchButton.Location = new System.Drawing.Point(330, 56);
            this.shozokuGyosyaSearchButton.Name = "shozokuGyosyaSearchButton";
            this.shozokuGyosyaSearchButton.Size = new System.Drawing.Size(27, 28);
            this.shozokuGyosyaSearchButton.TabIndex = 7;
            this.shozokuGyosyaSearchButton.UseVisualStyleBackColor = true;
            this.shozokuGyosyaSearchButton.Click += new System.EventHandler(this.shozokuGyosyaSearchButton_Click);
            // 
            // addressSearchButton
            // 
            this.addressSearchButton.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.addressSearchButton.Location = new System.Drawing.Point(210, 155);
            this.addressSearchButton.Name = "addressSearchButton";
            this.addressSearchButton.Size = new System.Drawing.Size(27, 28);
            this.addressSearchButton.TabIndex = 18;
            this.addressSearchButton.UseVisualStyleBackColor = true;
            this.addressSearchButton.Click += new System.EventHandler(this.addressSearchButton_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(97, 328);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 20);
            this.label20.TabIndex = 35;
            this.label20.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 326);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 20);
            this.label21.TabIndex = 34;
            this.label21.Text = "管理士取得日";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(79, 293);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 20);
            this.label18.TabIndex = 31;
            this.label18.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 291);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 20);
            this.label19.TabIndex = 30;
            this.label19.Text = "管理士No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "採水員名カナ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(101, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "*";
            // 
            // syozokuGyosyaNmTextBox
            // 
            this.syozokuGyosyaNmTextBox.Location = new System.Drawing.Point(124, 57);
            this.syozokuGyosyaNmTextBox.Name = "syozokuGyosyaNmTextBox";
            this.syozokuGyosyaNmTextBox.ReadOnly = true;
            this.syozokuGyosyaNmTextBox.Size = new System.Drawing.Size(200, 27);
            this.syozokuGyosyaNmTextBox.TabIndex = 6;
            this.syozokuGyosyaNmTextBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "所属業者";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(73, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "*";
            // 
            // saisuiinNmTextBox
            // 
            this.saisuiinNmTextBox.Location = new System.Drawing.Point(124, 90);
            this.saisuiinNmTextBox.MaxLength = 40;
            this.saisuiinNmTextBox.Name = "saisuiinNmTextBox";
            this.saisuiinNmTextBox.Size = new System.Drawing.Size(400, 27);
            this.saisuiinNmTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "採水員名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(73, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(99, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "*";
            // 
            // saisuiinKanaTextBox
            // 
            this.saisuiinKanaTextBox.Location = new System.Drawing.Point(124, 123);
            this.saisuiinKanaTextBox.MaxLength = 40;
            this.saisuiinKanaTextBox.Name = "saisuiinKanaTextBox";
            this.saisuiinKanaTextBox.Size = new System.Drawing.Size(400, 27);
            this.saisuiinKanaTextBox.TabIndex = 14;
            // 
            // saisuiinZipCdTextBox
            // 
            this.saisuiinZipCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.saisuiinZipCdTextBox.Location = new System.Drawing.Point(124, 156);
            this.saisuiinZipCdTextBox.MaxLength = 8;
            this.saisuiinZipCdTextBox.Name = "saisuiinZipCdTextBox";
            this.saisuiinZipCdTextBox.ShortcutsEnabled = false;
            this.saisuiinZipCdTextBox.Size = new System.Drawing.Size(80, 27);
            this.saisuiinZipCdTextBox.TabIndex = 17;
            this.saisuiinZipCdTextBox.TextChanged += new System.EventHandler(this.saisuiinZipCdTextBox_TextChanged);
            this.saisuiinZipCdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saisuiinZipCdTextBox_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "郵便番号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(73, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "*";
            // 
            // saisuiinAdrTextBox
            // 
            this.saisuiinAdrTextBox.Location = new System.Drawing.Point(124, 189);
            this.saisuiinAdrTextBox.MaxLength = 80;
            this.saisuiinAdrTextBox.Name = "saisuiinAdrTextBox";
            this.saisuiinAdrTextBox.Size = new System.Drawing.Size(400, 27);
            this.saisuiinAdrTextBox.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "住所";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(49, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "*";
            // 
            // saisuiinTelNoTextBox
            // 
            this.saisuiinTelNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.saisuiinTelNoTextBox.Location = new System.Drawing.Point(124, 222);
            this.saisuiinTelNoTextBox.MaxLength = 13;
            this.saisuiinTelNoTextBox.Name = "saisuiinTelNoTextBox";
            this.saisuiinTelNoTextBox.Size = new System.Drawing.Size(120, 27);
            this.saisuiinTelNoTextBox.TabIndex = 25;
            this.saisuiinTelNoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saisuiinTelNoTextBox_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 20);
            this.label15.TabIndex = 23;
            this.label15.Text = "電話番号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(73, 227);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 20);
            this.label14.TabIndex = 24;
            this.label14.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 260);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 20);
            this.label17.TabIndex = 27;
            this.label17.Text = "生年月日";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(74, 262);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 20);
            this.label16.TabIndex = 28;
            this.label16.Text = "*";
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(421, 553);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 6;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(528, 553);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(101, 37);
            this.changeButton.TabIndex = 7;
            this.changeButton.Text = "F2:変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.Location = new System.Drawing.Point(849, 553);
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(101, 37);
            this.decisionButton.TabIndex = 10;
            this.decisionButton.Text = "F5:確定";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.decisionButton_Click);
            // 
            // reInputButton
            // 
            this.reInputButton.Location = new System.Drawing.Point(742, 553);
            this.reInputButton.Name = "reInputButton";
            this.reInputButton.Size = new System.Drawing.Size(101, 37);
            this.reInputButton.TabIndex = 9;
            this.reInputButton.Text = "F4:再入力";
            this.reInputButton.UseVisualStyleBackColor = true;
            this.reInputButton.Click += new System.EventHandler(this.reInputButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(635, 553);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SaisuiinInfoShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SaisuiinInfoShosaiForm";
            this.Text = "保健所情報";
            this.Load += new System.EventHandler(this.SaisuiinInfoShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaisuiinInfoShosaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button decisionButton;
        private System.Windows.Forms.Button reInputButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox syozokuGyosyaNmTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox saisuiinTelNoTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox saisuiinAdrTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox saisuiinZipCdTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox saisuiinKanaTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox saisuiinNmTextBox;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button addressSearchButton;
        private System.Windows.Forms.DateTimePicker zenkaiJukoDtDateTimePicker;
        private System.Windows.Forms.DateTimePicker jukoDtDateTimePicker;
        private System.Windows.Forms.DateTimePicker saisuiinYukokigenDtDateTimePicker;
        private System.Windows.Forms.DateTimePicker saisuiinSyutokuDtDateTimePicker;
        private System.Windows.Forms.DateTimePicker kanrishiSyutokuDtDateTimePicker;
        private System.Windows.Forms.DateTimePicker saisuiinSeinegappiDateTimePicker;
        private System.Windows.Forms.TextBox syozokuGyosyaCdTextBox;
        private System.Windows.Forms.Button shozokuGyosyaSearchButton;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker saisuiinTorikeshiDtDateTimePicker;
        private System.Windows.Forms.CheckBox chancelDtAddFlgCheckBox;
        private System.Windows.Forms.CheckBox zenkaiJyukoDtAddFlgCheckBox;
        private System.Windows.Forms.CheckBox yukokigenAddFlgCheckBox;
        private System.Windows.Forms.CheckBox syutokuDtAddFlgCheckBox;
        private Control.NumberTextBox kanrishiNoTextBox;
        private Control.NumberTextBox saisuiinCdTextBox;
    }
}