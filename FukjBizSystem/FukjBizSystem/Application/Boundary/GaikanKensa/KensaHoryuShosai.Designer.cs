namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class KensaHoryuShosaiForm
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
            this.uketsukeShisyoComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entryButton = new System.Windows.Forms.Button();
            this.jokyoHaakuMakeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.genkyoHokokuLabel = new FukjBizSystem.Control.ZTextBox(this.components);
            this.jokyoHaakuLabel = new FukjBizSystem.Control.ZTextBox(this.components);
            this.genkyoHokokuSaveButton = new System.Windows.Forms.Button();
            this.jokyoHaakuSaveButton = new System.Windows.Forms.Button();
            this.horyuNaiyoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.settisyaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiNo2TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiNo3TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiNo1TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.genkyoHokokuDeleteButton = new System.Windows.Forms.Button();
            this.genkyoHokokuMakeButton = new System.Windows.Forms.Button();
            this.jokyoHaakuDeleteButton = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.jikaiKakuninDtTextBox = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.kakuninDtTextBox = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.horyuRiyuComboBox = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tantoKensainComboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.RenzokuGroupBox = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.kihyosyaComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.syozokuBusyoComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.syozokuShisyoComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.RenzokuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uketsukeShisyoComboBox
            // 
            this.uketsukeShisyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uketsukeShisyoComboBox.FormattingEnabled = true;
            this.uketsukeShisyoComboBox.Items.AddRange(new object[] {
            "筑　豊",
            "筑　後",
            "福　岡"});
            this.uketsukeShisyoComboBox.Location = new System.Drawing.Point(119, 88);
            this.uketsukeShisyoComboBox.Name = "uketsukeShisyoComboBox";
            this.uketsukeShisyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.uketsukeShisyoComboBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "設置者名";
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(119, 543);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 27;
            this.entryButton.Text = "F1:更新";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // jokyoHaakuMakeButton
            // 
            this.jokyoHaakuMakeButton.Location = new System.Drawing.Point(341, 543);
            this.jokyoHaakuMakeButton.Name = "jokyoHaakuMakeButton";
            this.jokyoHaakuMakeButton.Size = new System.Drawing.Size(107, 37);
            this.jokyoHaakuMakeButton.TabIndex = 29;
            this.jokyoHaakuMakeButton.Text = "F5:作成・編集";
            this.jokyoHaakuMakeButton.UseVisualStyleBackColor = true;
            this.jokyoHaakuMakeButton.Click += new System.EventHandler(this.jokyoHaakuMakeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(226, 543);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "F3:保留取消";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.genkyoHokokuLabel);
            this.mainPanel.Controls.Add(this.jokyoHaakuLabel);
            this.mainPanel.Controls.Add(this.genkyoHokokuSaveButton);
            this.mainPanel.Controls.Add(this.jokyoHaakuSaveButton);
            this.mainPanel.Controls.Add(this.horyuNaiyoTextBox);
            this.mainPanel.Controls.Add(this.settisyaNmTextBox);
            this.mainPanel.Controls.Add(this.kyokaiNo2TextBox);
            this.mainPanel.Controls.Add(this.kyokaiNo3TextBox);
            this.mainPanel.Controls.Add(this.kyokaiNo1TextBox);
            this.mainPanel.Controls.Add(this.genkyoHokokuDeleteButton);
            this.mainPanel.Controls.Add(this.genkyoHokokuMakeButton);
            this.mainPanel.Controls.Add(this.jokyoHaakuDeleteButton);
            this.mainPanel.Controls.Add(this.label30);
            this.mainPanel.Controls.Add(this.label31);
            this.mainPanel.Controls.Add(this.jikaiKakuninDtTextBox);
            this.mainPanel.Controls.Add(this.label29);
            this.mainPanel.Controls.Add(this.label28);
            this.mainPanel.Controls.Add(this.kakuninDtTextBox);
            this.mainPanel.Controls.Add(this.label27);
            this.mainPanel.Controls.Add(this.horyuRiyuComboBox);
            this.mainPanel.Controls.Add(this.label26);
            this.mainPanel.Controls.Add(this.tantoKensainComboBox);
            this.mainPanel.Controls.Add(this.label21);
            this.mainPanel.Controls.Add(this.label22);
            this.mainPanel.Controls.Add(this.RenzokuGroupBox);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.uketsukeShisyoComboBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.jokyoHaakuMakeButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1102, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(989, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = " ";
            // 
            // genkyoHokokuLabel
            // 
            this.genkyoHokokuLabel.AllowDropDown = false;
            this.genkyoHokokuLabel.BackColor = System.Drawing.Color.LemonChiffon;
            this.genkyoHokokuLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.genkyoHokokuLabel.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.genkyoHokokuLabel.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.genkyoHokokuLabel.CustomReadOnly = false;
            this.genkyoHokokuLabel.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.genkyoHokokuLabel.Location = new System.Drawing.Point(667, 510);
            this.genkyoHokokuLabel.MaxLength = 60;
            this.genkyoHokokuLabel.Name = "genkyoHokokuLabel";
            this.genkyoHokokuLabel.ReadOnly = true;
            this.genkyoHokokuLabel.Size = new System.Drawing.Size(316, 27);
            this.genkyoHokokuLabel.TabIndex = 25;
            this.genkyoHokokuLabel.TabStop = false;
            this.genkyoHokokuLabel.Text = "現況報告書ラベル";
            this.genkyoHokokuLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genkyoHokokuLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.haakuLabel_MouseDown);
            // 
            // jokyoHaakuLabel
            // 
            this.jokyoHaakuLabel.AllowDropDown = false;
            this.jokyoHaakuLabel.BackColor = System.Drawing.Color.PeachPuff;
            this.jokyoHaakuLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.jokyoHaakuLabel.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.jokyoHaakuLabel.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.jokyoHaakuLabel.CustomReadOnly = false;
            this.jokyoHaakuLabel.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.jokyoHaakuLabel.Location = new System.Drawing.Point(341, 510);
            this.jokyoHaakuLabel.MaxLength = 60;
            this.jokyoHaakuLabel.Name = "jokyoHaakuLabel";
            this.jokyoHaakuLabel.ReadOnly = true;
            this.jokyoHaakuLabel.Size = new System.Drawing.Size(308, 27);
            this.jokyoHaakuLabel.TabIndex = 24;
            this.jokyoHaakuLabel.TabStop = false;
            this.jokyoHaakuLabel.Text = "状況把握票ラベル";
            this.jokyoHaakuLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.jokyoHaakuLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.haakuLabel_MouseDown);
            // 
            // genkyoHokokuSaveButton
            // 
            this.genkyoHokokuSaveButton.Location = new System.Drawing.Point(780, 543);
            this.genkyoHokokuSaveButton.Name = "genkyoHokokuSaveButton";
            this.genkyoHokokuSaveButton.Size = new System.Drawing.Size(118, 37);
            this.genkyoHokokuSaveButton.TabIndex = 33;
            this.genkyoHokokuSaveButton.Text = "F9:サーバー保存";
            this.genkyoHokokuSaveButton.UseVisualStyleBackColor = true;
            this.genkyoHokokuSaveButton.Click += new System.EventHandler(this.genkyoHokokuSaveButton_Click);
            // 
            // jokyoHaakuSaveButton
            // 
            this.jokyoHaakuSaveButton.Location = new System.Drawing.Point(454, 543);
            this.jokyoHaakuSaveButton.Name = "jokyoHaakuSaveButton";
            this.jokyoHaakuSaveButton.Size = new System.Drawing.Size(118, 37);
            this.jokyoHaakuSaveButton.TabIndex = 30;
            this.jokyoHaakuSaveButton.Text = "F6:サーバー保存";
            this.jokyoHaakuSaveButton.UseVisualStyleBackColor = true;
            this.jokyoHaakuSaveButton.Click += new System.EventHandler(this.jokyoHaakuSaveButton_Click);
            // 
            // horyuNaiyoTextBox
            // 
            this.horyuNaiyoTextBox.AllowDropDown = false;
            this.horyuNaiyoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.horyuNaiyoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.horyuNaiyoTextBox.CustomReadOnly = false;
            this.horyuNaiyoTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.horyuNaiyoTextBox.Location = new System.Drawing.Point(119, 190);
            this.horyuNaiyoTextBox.MaxLength = 80;
            this.horyuNaiyoTextBox.Multiline = true;
            this.horyuNaiyoTextBox.Name = "horyuNaiyoTextBox";
            this.horyuNaiyoTextBox.Size = new System.Drawing.Size(470, 48);
            this.horyuNaiyoTextBox.TabIndex = 16;
            // 
            // settisyaNmTextBox
            // 
            this.settisyaNmTextBox.AllowDropDown = false;
            this.settisyaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.settisyaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settisyaNmTextBox.CustomReadOnly = false;
            this.settisyaNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.settisyaNmTextBox.Location = new System.Drawing.Point(119, 55);
            this.settisyaNmTextBox.MaxLength = 60;
            this.settisyaNmTextBox.Name = "settisyaNmTextBox";
            this.settisyaNmTextBox.ReadOnly = true;
            this.settisyaNmTextBox.Size = new System.Drawing.Size(448, 27);
            this.settisyaNmTextBox.TabIndex = 7;
            // 
            // kyokaiNo2TextBox
            // 
            this.kyokaiNo2TextBox.AllowDropDown = false;
            this.kyokaiNo2TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kyokaiNo2TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiNo2TextBox.CustomReadOnly = false;
            this.kyokaiNo2TextBox.Location = new System.Drawing.Point(169, 22);
            this.kyokaiNo2TextBox.Name = "kyokaiNo2TextBox";
            this.kyokaiNo2TextBox.ReadOnly = true;
            this.kyokaiNo2TextBox.Size = new System.Drawing.Size(31, 27);
            this.kyokaiNo2TextBox.TabIndex = 3;
            // 
            // kyokaiNo3TextBox
            // 
            this.kyokaiNo3TextBox.AllowDropDown = false;
            this.kyokaiNo3TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kyokaiNo3TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiNo3TextBox.CustomReadOnly = false;
            this.kyokaiNo3TextBox.Location = new System.Drawing.Point(218, 22);
            this.kyokaiNo3TextBox.Name = "kyokaiNo3TextBox";
            this.kyokaiNo3TextBox.ReadOnly = true;
            this.kyokaiNo3TextBox.Size = new System.Drawing.Size(59, 27);
            this.kyokaiNo3TextBox.TabIndex = 5;
            // 
            // kyokaiNo1TextBox
            // 
            this.kyokaiNo1TextBox.AllowDropDown = false;
            this.kyokaiNo1TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kyokaiNo1TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiNo1TextBox.CustomReadOnly = false;
            this.kyokaiNo1TextBox.Location = new System.Drawing.Point(119, 22);
            this.kyokaiNo1TextBox.Name = "kyokaiNo1TextBox";
            this.kyokaiNo1TextBox.ReadOnly = true;
            this.kyokaiNo1TextBox.Size = new System.Drawing.Size(31, 27);
            this.kyokaiNo1TextBox.TabIndex = 1;
            // 
            // genkyoHokokuDeleteButton
            // 
            this.genkyoHokokuDeleteButton.Location = new System.Drawing.Point(904, 543);
            this.genkyoHokokuDeleteButton.Name = "genkyoHokokuDeleteButton";
            this.genkyoHokokuDeleteButton.Size = new System.Drawing.Size(79, 37);
            this.genkyoHokokuDeleteButton.TabIndex = 34;
            this.genkyoHokokuDeleteButton.Text = "F10:削除";
            this.genkyoHokokuDeleteButton.UseVisualStyleBackColor = true;
            this.genkyoHokokuDeleteButton.Click += new System.EventHandler(this.genkyoHokokuDeleteButton_Click);
            // 
            // genkyoHokokuMakeButton
            // 
            this.genkyoHokokuMakeButton.Location = new System.Drawing.Point(667, 543);
            this.genkyoHokokuMakeButton.Name = "genkyoHokokuMakeButton";
            this.genkyoHokokuMakeButton.Size = new System.Drawing.Size(107, 37);
            this.genkyoHokokuMakeButton.TabIndex = 32;
            this.genkyoHokokuMakeButton.Text = "F8:作成・編集";
            this.genkyoHokokuMakeButton.UseVisualStyleBackColor = true;
            this.genkyoHokokuMakeButton.Click += new System.EventHandler(this.genkyoHokokuMakeButton_Click);
            // 
            // jokyoHaakuDeleteButton
            // 
            this.jokyoHaakuDeleteButton.Location = new System.Drawing.Point(578, 543);
            this.jokyoHaakuDeleteButton.Name = "jokyoHaakuDeleteButton";
            this.jokyoHaakuDeleteButton.Size = new System.Drawing.Size(71, 37);
            this.jokyoHaakuDeleteButton.TabIndex = 31;
            this.jokyoHaakuDeleteButton.Text = "F7:削除";
            this.jokyoHaakuDeleteButton.UseVisualStyleBackColor = true;
            this.jokyoHaakuDeleteButton.Click += new System.EventHandler(this.jokyoHaakuDeleteButton_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(96, 282);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 20);
            this.label30.TabIndex = 21;
            this.label30.Text = "*";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(21, 274);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(61, 20);
            this.label31.TabIndex = 20;
            this.label31.Text = "次回確認";
            // 
            // jikaiKakuninDtTextBox
            // 
            this.jikaiKakuninDtTextBox.CustomFormat = "yyyy/MM/dd";
            this.jikaiKakuninDtTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jikaiKakuninDtTextBox.Location = new System.Drawing.Point(119, 277);
            this.jikaiKakuninDtTextBox.Name = "jikaiKakuninDtTextBox";
            this.jikaiKakuninDtTextBox.Size = new System.Drawing.Size(145, 27);
            this.jikaiKakuninDtTextBox.TabIndex = 22;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Location = new System.Drawing.Point(96, 249);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 20);
            this.label29.TabIndex = 18;
            this.label29.Text = "*";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(21, 249);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 20);
            this.label28.TabIndex = 17;
            this.label28.Text = "確認日";
            // 
            // kakuninDtTextBox
            // 
            this.kakuninDtTextBox.CustomFormat = "yyyy/MM/dd";
            this.kakuninDtTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kakuninDtTextBox.Location = new System.Drawing.Point(119, 244);
            this.kakuninDtTextBox.Name = "kakuninDtTextBox";
            this.kakuninDtTextBox.Size = new System.Drawing.Size(145, 27);
            this.kakuninDtTextBox.TabIndex = 19;
            this.kakuninDtTextBox.Leave += new System.EventHandler(this.kakuninDtTextBox_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(21, 159);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 20);
            this.label27.TabIndex = 12;
            this.label27.Text = "保留の理由";
            // 
            // horyuRiyuComboBox
            // 
            this.horyuRiyuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horyuRiyuComboBox.FormattingEnabled = true;
            this.horyuRiyuComboBox.Items.AddRange(new object[] {
            "未建築",
            "建築中",
            "３ヶ月未満",
            "６ヶ月未満",
            "未入居",
            "その他"});
            this.horyuRiyuComboBox.Location = new System.Drawing.Point(119, 156);
            this.horyuRiyuComboBox.Name = "horyuRiyuComboBox";
            this.horyuRiyuComboBox.Size = new System.Drawing.Size(333, 28);
            this.horyuRiyuComboBox.TabIndex = 14;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(21, 125);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 20);
            this.label26.TabIndex = 10;
            this.label26.Text = "担当検査員";
            // 
            // tantoKensainComboBox
            // 
            this.tantoKensainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tantoKensainComboBox.FormattingEnabled = true;
            this.tantoKensainComboBox.Items.AddRange(new object[] {
            "検査員太郎",
            "検査員次郎"});
            this.tantoKensainComboBox.Location = new System.Drawing.Point(119, 122);
            this.tantoKensainComboBox.Name = "tantoKensainComboBox";
            this.tantoKensainComboBox.Size = new System.Drawing.Size(191, 28);
            this.tantoKensainComboBox.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(196, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "－";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(150, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(22, 20);
            this.label22.TabIndex = 2;
            this.label22.Text = "－";
            // 
            // RenzokuGroupBox
            // 
            this.RenzokuGroupBox.Controls.Add(this.label15);
            this.RenzokuGroupBox.Controls.Add(this.kihyosyaComboBox);
            this.RenzokuGroupBox.Controls.Add(this.label5);
            this.RenzokuGroupBox.Controls.Add(this.syozokuBusyoComboBox);
            this.RenzokuGroupBox.Controls.Add(this.label13);
            this.RenzokuGroupBox.Controls.Add(this.syozokuShisyoComboBox);
            this.RenzokuGroupBox.Location = new System.Drawing.Point(25, 326);
            this.RenzokuGroupBox.Name = "RenzokuGroupBox";
            this.RenzokuGroupBox.Size = new System.Drawing.Size(448, 137);
            this.RenzokuGroupBox.TabIndex = 24;
            this.RenzokuGroupBox.TabStop = false;
            this.RenzokuGroupBox.Text = "新規作成時起票者";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "起票者";
            // 
            // kihyosyaComboBox
            // 
            this.kihyosyaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kihyosyaComboBox.FormattingEnabled = true;
            this.kihyosyaComboBox.Items.AddRange(new object[] {
            "検査員太郎",
            "検査員次郎"});
            this.kihyosyaComboBox.Location = new System.Drawing.Point(111, 94);
            this.kihyosyaComboBox.Name = "kihyosyaComboBox";
            this.kihyosyaComboBox.Size = new System.Drawing.Size(191, 28);
            this.kihyosyaComboBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "所属部署";
            // 
            // syozokuBusyoComboBox
            // 
            this.syozokuBusyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syozokuBusyoComboBox.FormattingEnabled = true;
            this.syozokuBusyoComboBox.Items.AddRange(new object[] {
            "法定検査課"});
            this.syozokuBusyoComboBox.Location = new System.Drawing.Point(111, 60);
            this.syozokuBusyoComboBox.Name = "syozokuBusyoComboBox";
            this.syozokuBusyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.syozokuBusyoComboBox.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "所属支所";
            // 
            // syozokuShisyoComboBox
            // 
            this.syozokuShisyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syozokuShisyoComboBox.FormattingEnabled = true;
            this.syozokuShisyoComboBox.Items.AddRange(new object[] {
            "筑　豊",
            "筑　後",
            "福　岡"});
            this.syozokuShisyoComboBox.Location = new System.Drawing.Point(111, 26);
            this.syozokuShisyoComboBox.Name = "syozokuShisyoComboBox";
            this.syozokuShisyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.syozokuShisyoComboBox.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "期限日";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 193);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "保留内容";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(96, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "受付支所";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "検査番号";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(988, 543);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 35;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // KensaHoryuShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KensaHoryuShosaiForm";
            this.Text = "７条検査保留情報";
            this.Load += new System.EventHandler(this.KensaHoryuShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaHoryuShosaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.RenzokuGroupBox.ResumeLayout(false);
            this.RenzokuGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox uketsukeShisyoComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button jokyoHaakuMakeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox RenzokuGroupBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox horyuRiyuComboBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox tantoKensainComboBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button genkyoHokokuDeleteButton;
        private System.Windows.Forms.Button genkyoHokokuMakeButton;
        private System.Windows.Forms.Button jokyoHaakuDeleteButton;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker jikaiKakuninDtTextBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker kakuninDtTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox kihyosyaComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox syozokuBusyoComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox syozokuShisyoComboBox;
        private Control.ZTextBox kyokaiNo2TextBox;
        private Control.ZTextBox kyokaiNo3TextBox;
        private Control.ZTextBox kyokaiNo1TextBox;
        private Control.ZTextBox settisyaNmTextBox;
        private Control.ZTextBox horyuNaiyoTextBox;
        private System.Windows.Forms.Button jokyoHaakuSaveButton;
        private System.Windows.Forms.Button genkyoHokokuSaveButton;
        private Control.ZTextBox genkyoHokokuLabel;
        private Control.ZTextBox jokyoHaakuLabel;
        private System.Windows.Forms.Label label2;
    }
}