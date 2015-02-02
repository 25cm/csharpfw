namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class HenkinShosaiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.nyukinshaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kakuteiButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nenkaihiRadioButton = new System.Windows.Forms.RadioButton();
            this.seikyuRadioButton = new System.Windows.Forms.RadioButton();
            this.maeukekinRadioButton = new System.Windows.Forms.RadioButton();
            this.yoshiHanbaiRadioButton = new System.Windows.Forms.RadioButton();
            this.kensaTesuryoRadioButton = new System.Windows.Forms.RadioButton();
            this.eiryoSyomeiRadioButton = new System.Windows.Forms.RadioButton();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.kansaiCheckBox = new System.Windows.Forms.CheckBox();
            this.shishoNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.heninZanGakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.heninsumiGakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.nyukinGakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.nyukinDtTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.nyukinHohoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.henkinGakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.henkinDtTextBox = new Zynas.Control.ZDate(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.nyukinNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.henkinInputButton = new System.Windows.Forms.Button();
            this.settishaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.henkinListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.renbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.henkinDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.henkinGakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kaikeiSumiCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.torokuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torokuDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torokuTanmatsuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.henkinRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.henkinDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.henkinGakuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kaikeiRendoFlagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.henkinShosaiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.henkinTblDataSet = new FukjBizSystem.Application.DataSet.HenkinTblDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.kojinRadioButton = new System.Windows.Forms.RadioButton();
            this.gyoshaRadioButton = new System.Windows.Forms.RadioButton();
            this.gyoshaCdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.henkinShosaiTableAdapter = new FukjBizSystem.Application.DataSet.HenkinTblDataSetTableAdapters.HenkinShosaiTableAdapter();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.henkinListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.henkinShosaiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.henkinTblDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "入金者";
            // 
            // nyukinshaNmTextBox
            // 
            this.nyukinshaNmTextBox.AllowDropDown = false;
            this.nyukinshaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.nyukinshaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nyukinshaNmTextBox.CustomReadOnly = false;
            this.nyukinshaNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.nyukinshaNmTextBox.Location = new System.Drawing.Point(104, 144);
            this.nyukinshaNmTextBox.MaxLength = 60;
            this.nyukinshaNmTextBox.Name = "nyukinshaNmTextBox";
            this.nyukinshaNmTextBox.ReadOnly = true;
            this.nyukinshaNmTextBox.Size = new System.Drawing.Size(403, 27);
            this.nyukinshaNmTextBox.TabIndex = 13;
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Location = new System.Drawing.Point(870, 543);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(101, 37);
            this.kakuteiButton.TabIndex = 40;
            this.kakuteiButton.Text = "F5:確定";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.clearButton);
            this.mainPanel.Controls.Add(this.kensakuButton);
            this.mainPanel.Controls.Add(this.kansaiCheckBox);
            this.mainPanel.Controls.Add(this.shishoNmTextBox);
            this.mainPanel.Controls.Add(this.heninZanGakuTextBox);
            this.mainPanel.Controls.Add(this.heninsumiGakuTextBox);
            this.mainPanel.Controls.Add(this.nyukinGakuTextBox);
            this.mainPanel.Controls.Add(this.label16);
            this.mainPanel.Controls.Add(this.nyukinDtTextBox);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.nyukinHohoTextBox);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.henkinGakuTextBox);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.henkinDtTextBox);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.nyukinNoTextBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.label20);
            this.mainPanel.Controls.Add(this.henkinInputButton);
            this.mainPanel.Controls.Add(this.settishaNmTextBox);
            this.mainPanel.Controls.Add(this.gyoshaNmTextBox);
            this.mainPanel.Controls.Add(this.henkinListDataGridView);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.kojinRadioButton);
            this.mainPanel.Controls.Add(this.gyoshaRadioButton);
            this.mainPanel.Controls.Add(this.gyoshaCdTextBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.nyukinshaNmTextBox);
            this.mainPanel.Controls.Add(this.kakuteiButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nenkaihiRadioButton);
            this.panel1.Controls.Add(this.seikyuRadioButton);
            this.panel1.Controls.Add(this.maeukekinRadioButton);
            this.panel1.Controls.Add(this.yoshiHanbaiRadioButton);
            this.panel1.Controls.Add(this.kensaTesuryoRadioButton);
            this.panel1.Controls.Add(this.eiryoSyomeiRadioButton);
            this.panel1.Location = new System.Drawing.Point(104, 177);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 26);
            this.panel1.TabIndex = 15;
            // 
            // nenkaihiRadioButton
            // 
            this.nenkaihiRadioButton.AutoSize = true;
            this.nenkaihiRadioButton.Enabled = false;
            this.nenkaihiRadioButton.Location = new System.Drawing.Point(273, 0);
            this.nenkaihiRadioButton.Name = "nenkaihiRadioButton";
            this.nenkaihiRadioButton.Size = new System.Drawing.Size(117, 24);
            this.nenkaihiRadioButton.TabIndex = 4;
            this.nenkaihiRadioButton.Text = "年会費(請求外)";
            this.nenkaihiRadioButton.UseVisualStyleBackColor = true;
            // 
            // seikyuRadioButton
            // 
            this.seikyuRadioButton.AutoSize = true;
            this.seikyuRadioButton.Checked = true;
            this.seikyuRadioButton.Enabled = false;
            this.seikyuRadioButton.Location = new System.Drawing.Point(0, 0);
            this.seikyuRadioButton.Name = "seikyuRadioButton";
            this.seikyuRadioButton.Size = new System.Drawing.Size(53, 24);
            this.seikyuRadioButton.TabIndex = 1;
            this.seikyuRadioButton.TabStop = true;
            this.seikyuRadioButton.Text = "請求";
            this.seikyuRadioButton.UseVisualStyleBackColor = true;
            // 
            // maeukekinRadioButton
            // 
            this.maeukekinRadioButton.AutoSize = true;
            this.maeukekinRadioButton.Enabled = false;
            this.maeukekinRadioButton.Location = new System.Drawing.Point(66, 0);
            this.maeukekinRadioButton.Name = "maeukekinRadioButton";
            this.maeukekinRadioButton.Size = new System.Drawing.Size(66, 24);
            this.maeukekinRadioButton.TabIndex = 2;
            this.maeukekinRadioButton.Text = "前受金";
            this.maeukekinRadioButton.UseVisualStyleBackColor = true;
            // 
            // yoshiHanbaiRadioButton
            // 
            this.yoshiHanbaiRadioButton.AutoSize = true;
            this.yoshiHanbaiRadioButton.Enabled = false;
            this.yoshiHanbaiRadioButton.Location = new System.Drawing.Point(142, 0);
            this.yoshiHanbaiRadioButton.Name = "yoshiHanbaiRadioButton";
            this.yoshiHanbaiRadioButton.Size = new System.Drawing.Size(130, 24);
            this.yoshiHanbaiRadioButton.TabIndex = 3;
            this.yoshiHanbaiRadioButton.Text = "用紙販売(請求外)";
            this.yoshiHanbaiRadioButton.UseVisualStyleBackColor = true;
            // 
            // kensaTesuryoRadioButton
            // 
            this.kensaTesuryoRadioButton.AutoSize = true;
            this.kensaTesuryoRadioButton.Enabled = false;
            this.kensaTesuryoRadioButton.Location = new System.Drawing.Point(526, 0);
            this.kensaTesuryoRadioButton.Name = "kensaTesuryoRadioButton";
            this.kensaTesuryoRadioButton.Size = new System.Drawing.Size(143, 24);
            this.kensaTesuryoRadioButton.TabIndex = 0;
            this.kensaTesuryoRadioButton.Text = "検査手数料(請求外)";
            this.kensaTesuryoRadioButton.UseVisualStyleBackColor = true;
            // 
            // eiryoSyomeiRadioButton
            // 
            this.eiryoSyomeiRadioButton.AutoSize = true;
            this.eiryoSyomeiRadioButton.Enabled = false;
            this.eiryoSyomeiRadioButton.Location = new System.Drawing.Point(390, 0);
            this.eiryoSyomeiRadioButton.Name = "eiryoSyomeiRadioButton";
            this.eiryoSyomeiRadioButton.Size = new System.Drawing.Size(130, 24);
            this.eiryoSyomeiRadioButton.TabIndex = 5;
            this.eiryoSyomeiRadioButton.Text = "計量証明(請求外)";
            this.eiryoSyomeiRadioButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(322, 9);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(215, 9);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 3;
            this.kensakuButton.Text = "F6:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // kansaiCheckBox
            // 
            this.kansaiCheckBox.AutoSize = true;
            this.kansaiCheckBox.Location = new System.Drawing.Point(1018, 298);
            this.kansaiCheckBox.Name = "kansaiCheckBox";
            this.kansaiCheckBox.Size = new System.Drawing.Size(54, 24);
            this.kansaiCheckBox.TabIndex = 38;
            this.kansaiCheckBox.Text = "完済";
            this.kansaiCheckBox.UseVisualStyleBackColor = true;
            // 
            // shishoNmTextBox
            // 
            this.shishoNmTextBox.AllowDropDown = false;
            this.shishoNmTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.shishoNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.shishoNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shishoNmTextBox.CustomReadOnly = false;
            this.shishoNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.shishoNmTextBox.Location = new System.Drawing.Point(102, 50);
            this.shishoNmTextBox.MaxLength = 10;
            this.shishoNmTextBox.Name = "shishoNmTextBox";
            this.shishoNmTextBox.ReadOnly = true;
            this.shishoNmTextBox.Size = new System.Drawing.Size(155, 27);
            this.shishoNmTextBox.TabIndex = 6;
            // 
            // heninZanGakuTextBox
            // 
            this.heninZanGakuTextBox.AllowDropDown = false;
            this.heninZanGakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.heninZanGakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.heninZanGakuTextBox.CustomReadOnly = false;
            this.heninZanGakuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.heninZanGakuTextBox.Location = new System.Drawing.Point(903, 296);
            this.heninZanGakuTextBox.MaxLength = 10;
            this.heninZanGakuTextBox.Name = "heninZanGakuTextBox";
            this.heninZanGakuTextBox.ReadOnly = true;
            this.heninZanGakuTextBox.Size = new System.Drawing.Size(109, 27);
            this.heninZanGakuTextBox.TabIndex = 37;
            this.heninZanGakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // heninsumiGakuTextBox
            // 
            this.heninsumiGakuTextBox.AllowDropDown = false;
            this.heninsumiGakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.heninsumiGakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.heninsumiGakuTextBox.CustomReadOnly = false;
            this.heninsumiGakuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.heninsumiGakuTextBox.Location = new System.Drawing.Point(108, 232);
            this.heninsumiGakuTextBox.MaxLength = 10;
            this.heninsumiGakuTextBox.Name = "heninsumiGakuTextBox";
            this.heninsumiGakuTextBox.ReadOnly = true;
            this.heninsumiGakuTextBox.Size = new System.Drawing.Size(109, 27);
            this.heninsumiGakuTextBox.TabIndex = 26;
            this.heninsumiGakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nyukinGakuTextBox
            // 
            this.nyukinGakuTextBox.AllowDropDown = false;
            this.nyukinGakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.nyukinGakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.nyukinGakuTextBox.CustomReadOnly = false;
            this.nyukinGakuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nyukinGakuTextBox.Location = new System.Drawing.Point(108, 207);
            this.nyukinGakuTextBox.MaxLength = 10;
            this.nyukinGakuTextBox.Name = "nyukinGakuTextBox";
            this.nyukinGakuTextBox.ReadOnly = true;
            this.nyukinGakuTextBox.Size = new System.Drawing.Size(109, 27);
            this.nyukinGakuTextBox.TabIndex = 22;
            this.nyukinGakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 239);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 20);
            this.label16.TabIndex = 25;
            this.label16.Text = "返金済額";
            // 
            // nyukinDtTextBox
            // 
            this.nyukinDtTextBox.AllowDropDown = false;
            this.nyukinDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.nyukinDtTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nyukinDtTextBox.CustomReadOnly = false;
            this.nyukinDtTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.nyukinDtTextBox.Location = new System.Drawing.Point(356, 236);
            this.nyukinDtTextBox.MaxLength = 10;
            this.nyukinDtTextBox.Name = "nyukinDtTextBox";
            this.nyukinDtTextBox.ReadOnly = true;
            this.nyukinDtTextBox.Size = new System.Drawing.Size(93, 27);
            this.nyukinDtTextBox.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(81, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "*";
            // 
            // nyukinHohoTextBox
            // 
            this.nyukinHohoTextBox.AllowDropDown = false;
            this.nyukinHohoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.nyukinHohoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nyukinHohoTextBox.CustomReadOnly = false;
            this.nyukinHohoTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.nyukinHohoTextBox.Location = new System.Drawing.Point(356, 204);
            this.nyukinHohoTextBox.MaxLength = 10;
            this.nyukinHohoTextBox.Name = "nyukinHohoTextBox";
            this.nyukinHohoTextBox.ReadOnly = true;
            this.nyukinHohoTextBox.Size = new System.Drawing.Size(93, 27);
            this.nyukinHohoTextBox.TabIndex = 24;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 266);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 20);
            this.label17.TabIndex = 29;
            this.label17.Text = "今回返金額";
            // 
            // henkinGakuTextBox
            // 
            this.henkinGakuTextBox.AllowDropDown = false;
            this.henkinGakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.henkinGakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.henkinGakuTextBox.CustomReadOnly = false;
            this.henkinGakuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.henkinGakuTextBox.Location = new System.Drawing.Point(108, 263);
            this.henkinGakuTextBox.MaxLength = 10;
            this.henkinGakuTextBox.Name = "henkinGakuTextBox";
            this.henkinGakuTextBox.Size = new System.Drawing.Size(109, 27);
            this.henkinGakuTextBox.TabIndex = 31;
            this.henkinGakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.henkinGakuTextBox.Leave += new System.EventHandler(this.henkinGakuTextBox_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 294);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "返金日";
            // 
            // henkinDtTextBox
            // 
            this.henkinDtTextBox.CustomFormat = "yyyy/MM/dd";
            this.henkinDtTextBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.henkinDtTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.henkinDtTextBox.Location = new System.Drawing.Point(108, 294);
            this.henkinDtTextBox.Name = "henkinDtTextBox";
            this.henkinDtTextBox.Size = new System.Drawing.Size(113, 27);
            this.henkinDtTextBox.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(92, 294);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 20);
            this.label15.TabIndex = 33;
            this.label15.Text = "*";
            // 
            // nyukinNoTextBox
            // 
            this.nyukinNoTextBox.AllowDropDown = false;
            this.nyukinNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.nyukinNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.nyukinNoTextBox.CustomReadOnly = false;
            this.nyukinNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nyukinNoTextBox.Location = new System.Drawing.Point(102, 14);
            this.nyukinNoTextBox.MaxLength = 11;
            this.nyukinNoTextBox.Name = "nyukinNoTextBox";
            this.nyukinNoTextBox.Size = new System.Drawing.Size(98, 27);
            this.nyukinNoTextBox.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "入金No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "返金可能額";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "入金方法";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "入金種別";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "支所";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(268, 239);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 20);
            this.label19.TabIndex = 27;
            this.label19.Text = "入金日";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(92, 266);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 20);
            this.label20.TabIndex = 30;
            this.label20.Text = "*";
            // 
            // henkinInputButton
            // 
            this.henkinInputButton.Location = new System.Drawing.Point(256, 286);
            this.henkinInputButton.Name = "henkinInputButton";
            this.henkinInputButton.Size = new System.Drawing.Size(118, 37);
            this.henkinInputButton.TabIndex = 35;
            this.henkinInputButton.Text = "F9:返金入力";
            this.henkinInputButton.UseVisualStyleBackColor = true;
            this.henkinInputButton.Click += new System.EventHandler(this.henkinInputButton_Click);
            // 
            // settishaNmTextBox
            // 
            this.settishaNmTextBox.AllowDropDown = false;
            this.settishaNmTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.settishaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.settishaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settishaNmTextBox.CustomReadOnly = false;
            this.settishaNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.settishaNmTextBox.Location = new System.Drawing.Point(103, 111);
            this.settishaNmTextBox.MaxLength = 60;
            this.settishaNmTextBox.Name = "settishaNmTextBox";
            this.settishaNmTextBox.ReadOnly = true;
            this.settishaNmTextBox.Size = new System.Drawing.Size(404, 27);
            this.settishaNmTextBox.TabIndex = 11;
            // 
            // gyoshaNmTextBox
            // 
            this.gyoshaNmTextBox.AllowDropDown = false;
            this.gyoshaNmTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.gyoshaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.gyoshaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaNmTextBox.CustomReadOnly = false;
            this.gyoshaNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.gyoshaNmTextBox.Location = new System.Drawing.Point(155, 81);
            this.gyoshaNmTextBox.MaxLength = 40;
            this.gyoshaNmTextBox.Name = "gyoshaNmTextBox";
            this.gyoshaNmTextBox.ReadOnly = true;
            this.gyoshaNmTextBox.Size = new System.Drawing.Size(404, 27);
            this.gyoshaNmTextBox.TabIndex = 9;
            // 
            // henkinListDataGridView
            // 
            this.henkinListDataGridView.AllowUserToAddRows = false;
            this.henkinListDataGridView.AllowUserToDeleteRows = false;
            this.henkinListDataGridView.AllowUserToResizeRows = false;
            this.henkinListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.henkinListDataGridView.AutoGenerateColumns = false;
            this.henkinListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.henkinListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.renbanCol,
            this.henkinDtCol,
            this.henkinGakuCol,
            this.kaikeiSumiCol,
            this.torokuNmCol,
            this.torokuDtCol,
            this.torokuTanmatsuCol,
            this.deleteButton,
            this.henkinRenbanDataGridViewTextBoxColumn,
            this.henkinDtDataGridViewTextBoxColumn,
            this.henkinGakuDataGridViewTextBoxColumn,
            this.kaikeiRendoFlagDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn});
            this.henkinListDataGridView.DataSource = this.henkinShosaiBindingSource;
            this.henkinListDataGridView.Location = new System.Drawing.Point(24, 329);
            this.henkinListDataGridView.Name = "henkinListDataGridView";
            this.henkinListDataGridView.RowHeadersVisible = false;
            this.henkinListDataGridView.RowHeadersWidth = 30;
            this.henkinListDataGridView.RowTemplate.Height = 21;
            this.henkinListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.henkinListDataGridView.Size = new System.Drawing.Size(1065, 208);
            this.henkinListDataGridView.TabIndex = 39;
            this.henkinListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.henkinListDataGridView_CellContentClick);
            // 
            // renbanCol
            // 
            this.renbanCol.DataPropertyName = "HenkinRenban";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.renbanCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.renbanCol.HeaderText = "連番";
            this.renbanCol.MinimumWidth = 90;
            this.renbanCol.Name = "renbanCol";
            this.renbanCol.ReadOnly = true;
            this.renbanCol.Width = 90;
            // 
            // henkinDtCol
            // 
            this.henkinDtCol.DataPropertyName = "HenkinDt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.henkinDtCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.henkinDtCol.HeaderText = "返金日";
            this.henkinDtCol.MinimumWidth = 150;
            this.henkinDtCol.Name = "henkinDtCol";
            this.henkinDtCol.ReadOnly = true;
            this.henkinDtCol.Width = 150;
            // 
            // henkinGakuCol
            // 
            this.henkinGakuCol.DataPropertyName = "HenkinGaku";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.henkinGakuCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.henkinGakuCol.HeaderText = "返金額";
            this.henkinGakuCol.MinimumWidth = 120;
            this.henkinGakuCol.Name = "henkinGakuCol";
            this.henkinGakuCol.ReadOnly = true;
            this.henkinGakuCol.Width = 120;
            // 
            // kaikeiSumiCol
            // 
            this.kaikeiSumiCol.DataPropertyName = "KaikeiRendoFlag";
            this.kaikeiSumiCol.FalseValue = "0";
            this.kaikeiSumiCol.HeaderText = "会計済";
            this.kaikeiSumiCol.MinimumWidth = 90;
            this.kaikeiSumiCol.Name = "kaikeiSumiCol";
            this.kaikeiSumiCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.kaikeiSumiCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.kaikeiSumiCol.TrueValue = "1";
            this.kaikeiSumiCol.Width = 90;
            // 
            // torokuNmCol
            // 
            this.torokuNmCol.DataPropertyName = "InsertUser";
            this.torokuNmCol.HeaderText = "登録者（隠し）";
            this.torokuNmCol.Name = "torokuNmCol";
            this.torokuNmCol.Visible = false;
            // 
            // torokuDtCol
            // 
            this.torokuDtCol.DataPropertyName = "InsertDt";
            this.torokuDtCol.HeaderText = "登録日時（隠し）";
            this.torokuDtCol.Name = "torokuDtCol";
            this.torokuDtCol.Visible = false;
            // 
            // torokuTanmatsuCol
            // 
            this.torokuTanmatsuCol.DataPropertyName = "InsertTarm";
            this.torokuTanmatsuCol.HeaderText = "登録端末（隠し）";
            this.torokuTanmatsuCol.Name = "torokuTanmatsuCol";
            this.torokuTanmatsuCol.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.HeaderText = "削除";
            this.deleteButton.MinimumWidth = 60;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseColumnTextForButtonValue = true;
            this.deleteButton.Width = 60;
            // 
            // henkinRenbanDataGridViewTextBoxColumn
            // 
            this.henkinRenbanDataGridViewTextBoxColumn.DataPropertyName = "HenkinRenban";
            this.henkinRenbanDataGridViewTextBoxColumn.HeaderText = "HenkinRenban";
            this.henkinRenbanDataGridViewTextBoxColumn.Name = "henkinRenbanDataGridViewTextBoxColumn";
            this.henkinRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // henkinDtDataGridViewTextBoxColumn
            // 
            this.henkinDtDataGridViewTextBoxColumn.DataPropertyName = "HenkinDt";
            this.henkinDtDataGridViewTextBoxColumn.HeaderText = "HenkinDt";
            this.henkinDtDataGridViewTextBoxColumn.Name = "henkinDtDataGridViewTextBoxColumn";
            this.henkinDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // henkinGakuDataGridViewTextBoxColumn
            // 
            this.henkinGakuDataGridViewTextBoxColumn.DataPropertyName = "HenkinGaku";
            this.henkinGakuDataGridViewTextBoxColumn.HeaderText = "HenkinGaku";
            this.henkinGakuDataGridViewTextBoxColumn.Name = "henkinGakuDataGridViewTextBoxColumn";
            this.henkinGakuDataGridViewTextBoxColumn.Visible = false;
            // 
            // kaikeiRendoFlagDataGridViewTextBoxColumn
            // 
            this.kaikeiRendoFlagDataGridViewTextBoxColumn.DataPropertyName = "KaikeiRendoFlag";
            this.kaikeiRendoFlagDataGridViewTextBoxColumn.HeaderText = "KaikeiRendoFlag";
            this.kaikeiRendoFlagDataGridViewTextBoxColumn.Name = "kaikeiRendoFlagDataGridViewTextBoxColumn";
            this.kaikeiRendoFlagDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn
            // 
            this.insertUserDataGridViewTextBoxColumn.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.Name = "insertUserDataGridViewTextBoxColumn";
            this.insertUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn
            // 
            this.insertTarmDataGridViewTextBoxColumn.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.Name = "insertTarmDataGridViewTextBoxColumn";
            this.insertTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // henkinShosaiBindingSource
            // 
            this.henkinShosaiBindingSource.DataMember = "HenkinShosai";
            this.henkinShosaiBindingSource.DataSource = this.henkinTblDataSet;
            // 
            // henkinTblDataSet
            // 
            this.henkinTblDataSet.DataSetName = "HenkinTblDataSet";
            this.henkinTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(809, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "返金残合計";
            // 
            // kojinRadioButton
            // 
            this.kojinRadioButton.AutoSize = true;
            this.kojinRadioButton.Enabled = false;
            this.kojinRadioButton.Location = new System.Drawing.Point(11, 112);
            this.kojinRadioButton.Name = "kojinRadioButton";
            this.kojinRadioButton.Size = new System.Drawing.Size(66, 24);
            this.kojinRadioButton.TabIndex = 10;
            this.kojinRadioButton.Text = "設置者";
            this.kojinRadioButton.UseVisualStyleBackColor = true;
            // 
            // gyoshaRadioButton
            // 
            this.gyoshaRadioButton.AutoSize = true;
            this.gyoshaRadioButton.Checked = true;
            this.gyoshaRadioButton.Enabled = false;
            this.gyoshaRadioButton.Location = new System.Drawing.Point(11, 82);
            this.gyoshaRadioButton.Name = "gyoshaRadioButton";
            this.gyoshaRadioButton.Size = new System.Drawing.Size(53, 24);
            this.gyoshaRadioButton.TabIndex = 7;
            this.gyoshaRadioButton.TabStop = true;
            this.gyoshaRadioButton.Text = "業者";
            this.gyoshaRadioButton.UseVisualStyleBackColor = true;
            // 
            // gyoshaCdTextBox
            // 
            this.gyoshaCdTextBox.AllowDropDown = false;
            this.gyoshaCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyoshaCdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaCdTextBox.CustomReadOnly = false;
            this.gyoshaCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyoshaCdTextBox.Location = new System.Drawing.Point(102, 81);
            this.gyoshaCdTextBox.MaxLength = 4;
            this.gyoshaCdTextBox.Name = "gyoshaCdTextBox";
            this.gyoshaCdTextBox.ReadOnly = true;
            this.gyoshaCdTextBox.Size = new System.Drawing.Size(47, 27);
            this.gyoshaCdTextBox.TabIndex = 8;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(988, 543);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 41;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // henkinShosaiTableAdapter
            // 
            this.henkinShosaiTableAdapter.ClearBeforeFill = true;
            // 
            // HenkinShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HenkinShosaiForm";
            this.Text = "返金入力";
            this.Load += new System.EventHandler(this.HenkinShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HenkinShosaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.henkinListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.henkinShosaiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.henkinTblDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Control.ZTextBox nyukinshaNmTextBox;
        private System.Windows.Forms.Button kakuteiButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RadioButton kojinRadioButton;
        private System.Windows.Forms.RadioButton gyoshaRadioButton;
        private Control.ZTextBox gyoshaCdTextBox;
        private Zynas.Control.ZDataGridView.ZDataGridView henkinListDataGridView;
        private Control.ZTextBox gyoshaNmTextBox;
        private System.Windows.Forms.Button henkinInputButton;
        private Control.ZTextBox settishaNmTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton maeukekinRadioButton;
        private System.Windows.Forms.RadioButton seikyuRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private Zynas.Control.ZDate henkinDtTextBox;
        private System.Windows.Forms.Label label15;
        private Control.ZTextBox nyukinNoTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private Control.ZTextBox heninsumiGakuTextBox;
        private Control.ZTextBox nyukinGakuTextBox;
        private System.Windows.Forms.Label label16;
        private Control.ZTextBox nyukinDtTextBox;
        private System.Windows.Forms.Label label11;
        private Control.ZTextBox nyukinHohoTextBox;
        private Control.ZTextBox henkinGakuTextBox;
        private Control.ZTextBox heninZanGakuTextBox;
        private Control.ZTextBox shishoNmTextBox;
        private System.Windows.Forms.RadioButton kensaTesuryoRadioButton;
        private System.Windows.Forms.RadioButton eiryoSyomeiRadioButton;
        private System.Windows.Forms.RadioButton nenkaihiRadioButton;
        private System.Windows.Forms.RadioButton yoshiHanbaiRadioButton;
        private System.Windows.Forms.CheckBox kansaiCheckBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.BindingSource henkinShosaiBindingSource;
        private DataSet.HenkinTblDataSet henkinTblDataSet;
        private DataSet.HenkinTblDataSetTableAdapters.HenkinShosaiTableAdapter henkinShosaiTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn renbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn henkinDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn henkinGakuCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kaikeiSumiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn torokuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn torokuDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn torokuTanmatsuCol;
        private System.Windows.Forms.DataGridViewButtonColumn deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn henkinRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn henkinDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn henkinGakuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kaikeiRendoFlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
    }
}