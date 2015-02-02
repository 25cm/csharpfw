namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    partial class KensaIraishoUketsukeListForm
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
            this.outputButton = new System.Windows.Forms.Button();
            this.srhListPanel = new System.Windows.Forms.Panel();
            this.srhListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KensaIraishoUketsukeListDataGridView = new System.Windows.Forms.DataGridView();
            this.suishitsuIraiUketsukeWrkDataSet = new FukjBizSystem.Application.DataSet.SuishitsuIraiUketsukeWrkDataSet();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.outputDtAddFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.uketsukeDtAddFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.includeOutputFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.outputDtToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.outputDtFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.uketsukeNoToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.uketsukeNoFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.uketsukeDtToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uketsukeDtFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.kensaKbnComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.shisyoComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.iraiUketsukeKensaKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iraiUketsukeShishoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iraiUketsukeNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iraiUketsukeNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iraiUketsukeBarCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srhListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KensaIraishoUketsukeListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuIraiUketsukeWrkDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(12, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 2;
            this.outputButton.Text = "F3:CSV出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // srhListPanel
            // 
            this.srhListPanel.Controls.Add(this.srhListCountLabel);
            this.srhListPanel.Controls.Add(this.label4);
            this.srhListPanel.Controls.Add(this.KensaIraishoUketsukeListDataGridView);
            this.srhListPanel.Location = new System.Drawing.Point(1, 138);
            this.srhListPanel.Name = "srhListPanel";
            this.srhListPanel.Size = new System.Drawing.Size(1090, 400);
            this.srhListPanel.TabIndex = 1;
            // 
            // srhListCountLabel
            // 
            this.srhListCountLabel.AutoSize = true;
            this.srhListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.srhListCountLabel.Name = "srhListCountLabel";
            this.srhListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.srhListCountLabel.TabIndex = 3;
            this.srhListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "検索結果：";
            // 
            // KensaIraishoUketsukeListDataGridView
            // 
            this.KensaIraishoUketsukeListDataGridView.AllowUserToAddRows = false;
            this.KensaIraishoUketsukeListDataGridView.AllowUserToDeleteRows = false;
            this.KensaIraishoUketsukeListDataGridView.AllowUserToResizeRows = false;
            this.KensaIraishoUketsukeListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KensaIraishoUketsukeListDataGridView.AutoGenerateColumns = false;
            this.KensaIraishoUketsukeListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KensaIraishoUketsukeListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KensaIraishoUketsukeListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iraiUketsukeKensaKbnDataGridViewTextBoxColumn,
            this.constNmDataGridViewTextBoxColumn,
            this.iraiUketsukeShishoCdDataGridViewTextBoxColumn,
            this.shishoNmDataGridViewTextBoxColumn,
            this.iraiUketsukeNendoDataGridViewTextBoxColumn,
            this.iraiUketsukeNoDataGridViewTextBoxColumn,
            this.iraiUketsukeBarCdDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn});
            this.KensaIraishoUketsukeListDataGridView.DataMember = "KensaIraiUketsukeList";
            this.KensaIraishoUketsukeListDataGridView.DataSource = this.suishitsuIraiUketsukeWrkDataSet;
            this.KensaIraishoUketsukeListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.KensaIraishoUketsukeListDataGridView.MultiSelect = false;
            this.KensaIraishoUketsukeListDataGridView.Name = "KensaIraishoUketsukeListDataGridView";
            this.KensaIraishoUketsukeListDataGridView.RowHeadersVisible = false;
            this.KensaIraishoUketsukeListDataGridView.RowTemplate.Height = 21;
            this.KensaIraishoUketsukeListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.KensaIraishoUketsukeListDataGridView.Size = new System.Drawing.Size(1085, 373);
            this.KensaIraishoUketsukeListDataGridView.TabIndex = 4;
            // 
            // suishitsuIraiUketsukeWrkDataSet
            // 
            this.suishitsuIraiUketsukeWrkDataSet.DataSetName = "SuishitsuIraiUketsukeWrkDataSet";
            this.suishitsuIraiUketsukeWrkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 1;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.outputDtAddFlgCheckBox);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.uketsukeDtAddFlgCheckBox);
            this.searchPanel.Controls.Add(this.includeOutputFlgCheckBox);
            this.searchPanel.Controls.Add(this.outputDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.outputDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.label9);
            this.searchPanel.Controls.Add(this.uketsukeNoToTextBox);
            this.searchPanel.Controls.Add(this.uketsukeNoFromTextBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.uketsukeDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.uketsukeDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.kensaKbnComboBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Controls.Add(this.shisyoComboBox);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 138);
            this.searchPanel.TabIndex = 0;
            // 
            // outputDtAddFlgCheckBox
            // 
            this.outputDtAddFlgCheckBox.AutoSize = true;
            this.outputDtAddFlgCheckBox.Checked = true;
            this.outputDtAddFlgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outputDtAddFlgCheckBox.Location = new System.Drawing.Point(326, 105);
            this.outputDtAddFlgCheckBox.Name = "outputDtAddFlgCheckBox";
            this.outputDtAddFlgCheckBox.Size = new System.Drawing.Size(67, 24);
            this.outputDtAddFlgCheckBox.TabIndex = 15;
            this.outputDtAddFlgCheckBox.Text = "出力日";
            this.outputDtAddFlgCheckBox.UseVisualStyleBackColor = true;
            this.outputDtAddFlgCheckBox.CheckedChanged += new System.EventHandler(this.outputDtAddFlgCheckBox_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(866, 98);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 19;
            this.clearButton.Text = "F1:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // uketsukeDtAddFlgCheckBox
            // 
            this.uketsukeDtAddFlgCheckBox.AutoSize = true;
            this.uketsukeDtAddFlgCheckBox.Checked = true;
            this.uketsukeDtAddFlgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uketsukeDtAddFlgCheckBox.Location = new System.Drawing.Point(326, 37);
            this.uketsukeDtAddFlgCheckBox.Name = "uketsukeDtAddFlgCheckBox";
            this.uketsukeDtAddFlgCheckBox.Size = new System.Drawing.Size(67, 24);
            this.uketsukeDtAddFlgCheckBox.TabIndex = 10;
            this.uketsukeDtAddFlgCheckBox.Text = "受付日";
            this.uketsukeDtAddFlgCheckBox.UseVisualStyleBackColor = true;
            this.uketsukeDtAddFlgCheckBox.CheckedChanged += new System.EventHandler(this.uketsukeDtAddFlgCheckBox_CheckedChanged);
            // 
            // includeOutputFlgCheckBox
            // 
            this.includeOutputFlgCheckBox.AutoSize = true;
            this.includeOutputFlgCheckBox.Checked = true;
            this.includeOutputFlgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeOutputFlgCheckBox.Location = new System.Drawing.Point(326, 71);
            this.includeOutputFlgCheckBox.Name = "includeOutputFlgCheckBox";
            this.includeOutputFlgCheckBox.Size = new System.Drawing.Size(132, 24);
            this.includeOutputFlgCheckBox.TabIndex = 14;
            this.includeOutputFlgCheckBox.Text = "出力済みを含める";
            this.includeOutputFlgCheckBox.UseVisualStyleBackColor = true;
            this.includeOutputFlgCheckBox.CheckedChanged += new System.EventHandler(this.includeOutputFlgCheckBox_CheckedChanged);
            // 
            // outputDtToDateTimePicker
            // 
            this.outputDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.outputDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.outputDtToDateTimePicker.Location = new System.Drawing.Point(574, 103);
            this.outputDtToDateTimePicker.Name = "outputDtToDateTimePicker";
            this.outputDtToDateTimePicker.Size = new System.Drawing.Size(141, 27);
            this.outputDtToDateTimePicker.TabIndex = 18;
            // 
            // outputDtFromDateTimePicker
            // 
            this.outputDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.outputDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.outputDtFromDateTimePicker.Location = new System.Drawing.Point(399, 103);
            this.outputDtFromDateTimePicker.Name = "outputDtFromDateTimePicker";
            this.outputDtFromDateTimePicker.Size = new System.Drawing.Size(141, 27);
            this.outputDtFromDateTimePicker.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(546, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "～";
            // 
            // uketsukeNoToTextBox
            // 
            this.uketsukeNoToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.uketsukeNoToTextBox.CustomDigitParts = 0;
            this.uketsukeNoToTextBox.CustomFormat = null;
            this.uketsukeNoToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.uketsukeNoToTextBox.CustomReadOnly = false;
            this.uketsukeNoToTextBox.Location = new System.Drawing.Point(203, 103);
            this.uketsukeNoToTextBox.MaxLength = 6;
            this.uketsukeNoToTextBox.Name = "uketsukeNoToTextBox";
            this.uketsukeNoToTextBox.Size = new System.Drawing.Size(80, 27);
            this.uketsukeNoToTextBox.TabIndex = 9;
            // 
            // uketsukeNoFromTextBox
            // 
            this.uketsukeNoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.uketsukeNoFromTextBox.CustomDigitParts = 0;
            this.uketsukeNoFromTextBox.CustomFormat = null;
            this.uketsukeNoFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.uketsukeNoFromTextBox.CustomReadOnly = false;
            this.uketsukeNoFromTextBox.Location = new System.Drawing.Point(89, 103);
            this.uketsukeNoFromTextBox.MaxLength = 6;
            this.uketsukeNoFromTextBox.Name = "uketsukeNoFromTextBox";
            this.uketsukeNoFromTextBox.Size = new System.Drawing.Size(80, 27);
            this.uketsukeNoFromTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "～";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 106);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 20);
            this.label19.TabIndex = 6;
            this.label19.Text = "受付番号";
            // 
            // uketsukeDtToDateTimePicker
            // 
            this.uketsukeDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.uketsukeDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uketsukeDtToDateTimePicker.Location = new System.Drawing.Point(574, 36);
            this.uketsukeDtToDateTimePicker.Name = "uketsukeDtToDateTimePicker";
            this.uketsukeDtToDateTimePicker.Size = new System.Drawing.Size(141, 27);
            this.uketsukeDtToDateTimePicker.TabIndex = 13;
            // 
            // uketsukeDtFromDateTimePicker
            // 
            this.uketsukeDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.uketsukeDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uketsukeDtFromDateTimePicker.Location = new System.Drawing.Point(399, 36);
            this.uketsukeDtFromDateTimePicker.Name = "uketsukeDtFromDateTimePicker";
            this.uketsukeDtFromDateTimePicker.Size = new System.Drawing.Size(141, 27);
            this.uketsukeDtFromDateTimePicker.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "～";
            // 
            // kensaKbnComboBox
            // 
            this.kensaKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensaKbnComboBox.FormattingEnabled = true;
            this.kensaKbnComboBox.Location = new System.Drawing.Point(89, 35);
            this.kensaKbnComboBox.Name = "kensaKbnComboBox";
            this.kensaKbnComboBox.Size = new System.Drawing.Size(191, 28);
            this.kensaKbnComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "検査区分";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(973, 98);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(101, 37);
            this.searchButton.TabIndex = 20;
            this.searchButton.Text = "F2:検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // shisyoComboBox
            // 
            this.shisyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shisyoComboBox.FormattingEnabled = true;
            this.shisyoComboBox.Location = new System.Drawing.Point(89, 69);
            this.shisyoComboBox.Name = "shisyoComboBox";
            this.shisyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.shisyoComboBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "支所";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索条件";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(990, 544);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // iraiUketsukeKensaKbnDataGridViewTextBoxColumn
            // 
            this.iraiUketsukeKensaKbnDataGridViewTextBoxColumn.DataPropertyName = "IraiUketsukeKensaKbn";
            this.iraiUketsukeKensaKbnDataGridViewTextBoxColumn.HeaderText = "IraiUketsukeKensaKbn";
            this.iraiUketsukeKensaKbnDataGridViewTextBoxColumn.Name = "iraiUketsukeKensaKbnDataGridViewTextBoxColumn";
            this.iraiUketsukeKensaKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.iraiUketsukeKensaKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // constNmDataGridViewTextBoxColumn
            // 
            this.constNmDataGridViewTextBoxColumn.DataPropertyName = "ConstNm";
            this.constNmDataGridViewTextBoxColumn.FillWeight = 20F;
            this.constNmDataGridViewTextBoxColumn.HeaderText = "検査区分";
            this.constNmDataGridViewTextBoxColumn.Name = "constNmDataGridViewTextBoxColumn";
            this.constNmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iraiUketsukeShishoCdDataGridViewTextBoxColumn
            // 
            this.iraiUketsukeShishoCdDataGridViewTextBoxColumn.DataPropertyName = "IraiUketsukeShishoCd";
            this.iraiUketsukeShishoCdDataGridViewTextBoxColumn.HeaderText = "IraiUketsukeShishoCd";
            this.iraiUketsukeShishoCdDataGridViewTextBoxColumn.Name = "iraiUketsukeShishoCdDataGridViewTextBoxColumn";
            this.iraiUketsukeShishoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.iraiUketsukeShishoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoNmDataGridViewTextBoxColumn
            // 
            this.shishoNmDataGridViewTextBoxColumn.DataPropertyName = "ShishoNm";
            this.shishoNmDataGridViewTextBoxColumn.FillWeight = 20F;
            this.shishoNmDataGridViewTextBoxColumn.HeaderText = "支所";
            this.shishoNmDataGridViewTextBoxColumn.Name = "shishoNmDataGridViewTextBoxColumn";
            this.shishoNmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iraiUketsukeNendoDataGridViewTextBoxColumn
            // 
            this.iraiUketsukeNendoDataGridViewTextBoxColumn.DataPropertyName = "IraiUketsukeNendo";
            this.iraiUketsukeNendoDataGridViewTextBoxColumn.FillWeight = 10F;
            this.iraiUketsukeNendoDataGridViewTextBoxColumn.HeaderText = "年度";
            this.iraiUketsukeNendoDataGridViewTextBoxColumn.Name = "iraiUketsukeNendoDataGridViewTextBoxColumn";
            this.iraiUketsukeNendoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iraiUketsukeNoDataGridViewTextBoxColumn
            // 
            this.iraiUketsukeNoDataGridViewTextBoxColumn.DataPropertyName = "IraiUketsukeNo";
            this.iraiUketsukeNoDataGridViewTextBoxColumn.FillWeight = 20F;
            this.iraiUketsukeNoDataGridViewTextBoxColumn.HeaderText = "受付番号";
            this.iraiUketsukeNoDataGridViewTextBoxColumn.Name = "iraiUketsukeNoDataGridViewTextBoxColumn";
            this.iraiUketsukeNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iraiUketsukeBarCdDataGridViewTextBoxColumn
            // 
            this.iraiUketsukeBarCdDataGridViewTextBoxColumn.DataPropertyName = "IraiUketsukeBarCd";
            this.iraiUketsukeBarCdDataGridViewTextBoxColumn.FillWeight = 20F;
            this.iraiUketsukeBarCdDataGridViewTextBoxColumn.HeaderText = "バーコード番号";
            this.iraiUketsukeBarCdDataGridViewTextBoxColumn.Name = "iraiUketsukeBarCdDataGridViewTextBoxColumn";
            this.iraiUketsukeBarCdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.insertDtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.insertDtDataGridViewTextBoxColumn.FillWeight = 15F;
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "受付日";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn
            // 
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn.DataPropertyName = "IraiUketsukeCsvOutputDt";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn.FillWeight = 15F;
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn.HeaderText = "出力日";
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn.Name = "iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn";
            this.iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // KensaIraishoUketsukeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.srhListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KensaIraishoUketsukeListForm";
            this.Text = "水質検査依頼受付一覧";
            this.Load += new System.EventHandler(this.KensaIraishoUketsukeListForm_Load);
            this.Shown += new System.EventHandler(this.KensaIraishoUketsukeListForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaIraishoUketsukeListForm_KeyDown);
            this.srhListPanel.ResumeLayout(false);
            this.srhListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KensaIraishoUketsukeListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuIraiUketsukeWrkDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView KensaIraishoUketsukeListDataGridView;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Panel srhListPanel;
        private System.Windows.Forms.Label srhListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox shisyoComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox kensaKbnComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker uketsukeDtToDateTimePicker;
        private System.Windows.Forms.DateTimePicker uketsukeDtFromDateTimePicker;
        private System.Windows.Forms.Label label7;
        private Control.NumberTextBox uketsukeNoToTextBox;
        private Control.NumberTextBox uketsukeNoFromTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker outputDtToDateTimePicker;
        private System.Windows.Forms.DateTimePicker outputDtFromDateTimePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox includeOutputFlgCheckBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox outputDtAddFlgCheckBox;
        private System.Windows.Forms.CheckBox uketsukeDtAddFlgCheckBox;
        private DataSet.SuishitsuIraiUketsukeWrkDataSet suishitsuIraiUketsukeWrkDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn iraiUketsukeKensaKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn constNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iraiUketsukeShishoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iraiUketsukeNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iraiUketsukeNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iraiUketsukeBarCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iraiUketsukeCsvOutputDtDataGridViewTextBoxColumn;

    }
}