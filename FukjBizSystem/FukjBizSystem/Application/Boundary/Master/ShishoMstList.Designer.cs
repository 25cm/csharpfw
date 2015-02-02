namespace FukjBizSystem.Application.Boundary.Master
{
    partial class ShishoMstListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.shishoMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shishoMstDataSet = new FukjBizSystem.Application.DataSet.ShishoMstDataSet();
            this.shishoMstTableAdapter = new FukjBizSystem.Application.DataSet.ShishoMstDataSetTableAdapters.ShishoMstTableAdapter();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.sishoMstListPanel = new System.Windows.Forms.Panel();
            this.sishoMstListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sishoMstListDataGridView = new System.Windows.Forms.DataGridView();
            this.SishoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoChoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZipCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SishoAdrCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaxCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuridaiaruCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoKeiryoKanrishaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoKenTorokuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoKankyoKeiryoshiNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoZipCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoAdrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoTelNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoFaxNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoFreeDialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.sishoCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.sishoCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.sishoNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstDataSet)).BeginInit();
            this.sishoMstListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sishoMstListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // shishoMstBindingSource
            // 
            this.shishoMstBindingSource.DataMember = "ShishoMst";
            this.shishoMstBindingSource.DataSource = this.shishoMstDataSet;
            // 
            // shishoMstDataSet
            // 
            this.shishoMstDataSet.DataSetName = "ShishoMstDataSet";
            this.shishoMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shishoMstTableAdapter
            // 
            this.shishoMstTableAdapter.ClearBeforeFill = true;
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(994, 553);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(726, 553);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 3;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(586, 553);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:新規登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // sishoMstListPanel
            // 
            this.sishoMstListPanel.Controls.Add(this.sishoMstListCountLabel);
            this.sishoMstListPanel.Controls.Add(this.label4);
            this.sishoMstListPanel.Controls.Add(this.sishoMstListDataGridView);
            this.sishoMstListPanel.Location = new System.Drawing.Point(2, 128);
            this.sishoMstListPanel.Name = "sishoMstListPanel";
            this.sishoMstListPanel.Size = new System.Drawing.Size(1103, 419);
            this.sishoMstListPanel.TabIndex = 1;
            // 
            // sishoMstListCountLabel
            // 
            this.sishoMstListCountLabel.AutoSize = true;
            this.sishoMstListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.sishoMstListCountLabel.Name = "sishoMstListCountLabel";
            this.sishoMstListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.sishoMstListCountLabel.TabIndex = 1;
            this.sishoMstListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "検索結果：";
            // 
            // sishoMstListDataGridView
            // 
            this.sishoMstListDataGridView.AllowUserToAddRows = false;
            this.sishoMstListDataGridView.AllowUserToDeleteRows = false;
            this.sishoMstListDataGridView.AllowUserToResizeRows = false;
            this.sishoMstListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sishoMstListDataGridView.AutoGenerateColumns = false;
            this.sishoMstListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sishoMstListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SishoCdCol,
            this.SishoNmCol,
            this.ShishoChoNmCol,
            this.ZipCdCol,
            this.SishoAdrCol,
            this.TelCol,
            this.FaxCol,
            this.FuridaiaruCol,
            this.ShishoKeiryoKanrishaCol,
            this.ShishoKenTorokuNoCol,
            this.ShishoKankyoKeiryoshiNoCol,
            this.shishoCdDataGridViewTextBoxColumn,
            this.shishoNmDataGridViewTextBoxColumn,
            this.shishoZipCdDataGridViewTextBoxColumn,
            this.shishoAdrDataGridViewTextBoxColumn,
            this.shishoTelNoDataGridViewTextBoxColumn,
            this.shishoFaxNoDataGridViewTextBoxColumn,
            this.shishoFreeDialDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn});
            this.sishoMstListDataGridView.DataSource = this.shishoMstBindingSource;
            this.sishoMstListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.sishoMstListDataGridView.MultiSelect = false;
            this.sishoMstListDataGridView.Name = "sishoMstListDataGridView";
            this.sishoMstListDataGridView.RowHeadersVisible = false;
            this.sishoMstListDataGridView.RowTemplate.Height = 21;
            this.sishoMstListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sishoMstListDataGridView.Size = new System.Drawing.Size(1090, 379);
            this.sishoMstListDataGridView.TabIndex = 2;
            this.sishoMstListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sishoMstListDataGridView_CellDoubleClick);
            // 
            // SishoCdCol
            // 
            this.SishoCdCol.DataPropertyName = "ShishoCd";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SishoCdCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.SishoCdCol.HeaderText = "支所コード";
            this.SishoCdCol.MinimumWidth = 110;
            this.SishoCdCol.Name = "SishoCdCol";
            this.SishoCdCol.ReadOnly = true;
            this.SishoCdCol.Width = 110;
            // 
            // SishoNmCol
            // 
            this.SishoNmCol.DataPropertyName = "ShishoNm";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SishoNmCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.SishoNmCol.HeaderText = "支所名称";
            this.SishoNmCol.MinimumWidth = 200;
            this.SishoNmCol.Name = "SishoNmCol";
            this.SishoNmCol.ReadOnly = true;
            this.SishoNmCol.Width = 200;
            // 
            // ShishoChoNmCol
            // 
            this.ShishoChoNmCol.DataPropertyName = "ShishoChoNm";
            this.ShishoChoNmCol.HeaderText = "支所長名称";
            this.ShishoChoNmCol.MinimumWidth = 100;
            this.ShishoChoNmCol.Name = "ShishoChoNmCol";
            this.ShishoChoNmCol.ReadOnly = true;
            // 
            // ZipCdCol
            // 
            this.ZipCdCol.DataPropertyName = "ShishoZipCd";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ZipCdCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.ZipCdCol.HeaderText = "郵便番号";
            this.ZipCdCol.MinimumWidth = 110;
            this.ZipCdCol.Name = "ZipCdCol";
            this.ZipCdCol.ReadOnly = true;
            this.ZipCdCol.Width = 110;
            // 
            // SishoAdrCol
            // 
            this.SishoAdrCol.DataPropertyName = "ShishoAdr";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SishoAdrCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.SishoAdrCol.HeaderText = "住所";
            this.SishoAdrCol.MinimumWidth = 200;
            this.SishoAdrCol.Name = "SishoAdrCol";
            this.SishoAdrCol.ReadOnly = true;
            this.SishoAdrCol.Width = 200;
            // 
            // TelCol
            // 
            this.TelCol.DataPropertyName = "ShishoTelNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TelCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.TelCol.HeaderText = "電話番号";
            this.TelCol.MinimumWidth = 140;
            this.TelCol.Name = "TelCol";
            this.TelCol.ReadOnly = true;
            this.TelCol.Width = 140;
            // 
            // FaxCol
            // 
            this.FaxCol.DataPropertyName = "ShishoFaxNo";
            this.FaxCol.HeaderText = "ファックス";
            this.FaxCol.MinimumWidth = 140;
            this.FaxCol.Name = "FaxCol";
            this.FaxCol.ReadOnly = true;
            this.FaxCol.Width = 140;
            // 
            // FuridaiaruCol
            // 
            this.FuridaiaruCol.DataPropertyName = "ShishoFreeDial";
            this.FuridaiaruCol.HeaderText = "フリーダイヤル";
            this.FuridaiaruCol.MinimumWidth = 140;
            this.FuridaiaruCol.Name = "FuridaiaruCol";
            this.FuridaiaruCol.ReadOnly = true;
            this.FuridaiaruCol.Width = 140;
            // 
            // ShishoKeiryoKanrishaCol
            // 
            this.ShishoKeiryoKanrishaCol.DataPropertyName = "ShishoKeiryoKanrisha";
            this.ShishoKeiryoKanrishaCol.HeaderText = "支所計量管理者(分析管理者)";
            this.ShishoKeiryoKanrishaCol.MinimumWidth = 130;
            this.ShishoKeiryoKanrishaCol.Name = "ShishoKeiryoKanrishaCol";
            this.ShishoKeiryoKanrishaCol.ReadOnly = true;
            this.ShishoKeiryoKanrishaCol.Width = 130;
            // 
            // ShishoKenTorokuNoCol
            // 
            this.ShishoKenTorokuNoCol.DataPropertyName = "ShishoKenTorokuNo";
            this.ShishoKenTorokuNoCol.HeaderText = "支所県登録番号";
            this.ShishoKenTorokuNoCol.MinimumWidth = 130;
            this.ShishoKenTorokuNoCol.Name = "ShishoKenTorokuNoCol";
            this.ShishoKenTorokuNoCol.ReadOnly = true;
            this.ShishoKenTorokuNoCol.Width = 130;
            // 
            // ShishoKankyoKeiryoshiNoCol
            // 
            this.ShishoKankyoKeiryoshiNoCol.DataPropertyName = "ShishoKankyoKeiryoshiNo";
            this.ShishoKankyoKeiryoshiNoCol.HeaderText = "支所環境計量士登録番号";
            this.ShishoKankyoKeiryoshiNoCol.MinimumWidth = 130;
            this.ShishoKankyoKeiryoshiNoCol.Name = "ShishoKankyoKeiryoshiNoCol";
            this.ShishoKankyoKeiryoshiNoCol.ReadOnly = true;
            this.ShishoKankyoKeiryoshiNoCol.Width = 130;
            // 
            // shishoCdDataGridViewTextBoxColumn
            // 
            this.shishoCdDataGridViewTextBoxColumn.DataPropertyName = "ShishoCd";
            this.shishoCdDataGridViewTextBoxColumn.HeaderText = "ShishoCd";
            this.shishoCdDataGridViewTextBoxColumn.Name = "shishoCdDataGridViewTextBoxColumn";
            this.shishoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoNmDataGridViewTextBoxColumn
            // 
            this.shishoNmDataGridViewTextBoxColumn.DataPropertyName = "ShishoNm";
            this.shishoNmDataGridViewTextBoxColumn.HeaderText = "ShishoNm";
            this.shishoNmDataGridViewTextBoxColumn.Name = "shishoNmDataGridViewTextBoxColumn";
            this.shishoNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoZipCdDataGridViewTextBoxColumn
            // 
            this.shishoZipCdDataGridViewTextBoxColumn.DataPropertyName = "ShishoZipCd";
            this.shishoZipCdDataGridViewTextBoxColumn.HeaderText = "ShishoZipCd";
            this.shishoZipCdDataGridViewTextBoxColumn.Name = "shishoZipCdDataGridViewTextBoxColumn";
            this.shishoZipCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoAdrDataGridViewTextBoxColumn
            // 
            this.shishoAdrDataGridViewTextBoxColumn.DataPropertyName = "ShishoAdr";
            this.shishoAdrDataGridViewTextBoxColumn.HeaderText = "ShishoAdr";
            this.shishoAdrDataGridViewTextBoxColumn.Name = "shishoAdrDataGridViewTextBoxColumn";
            this.shishoAdrDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoTelNoDataGridViewTextBoxColumn
            // 
            this.shishoTelNoDataGridViewTextBoxColumn.DataPropertyName = "ShishoTelNo";
            this.shishoTelNoDataGridViewTextBoxColumn.HeaderText = "ShishoTelNo";
            this.shishoTelNoDataGridViewTextBoxColumn.Name = "shishoTelNoDataGridViewTextBoxColumn";
            this.shishoTelNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoFaxNoDataGridViewTextBoxColumn
            // 
            this.shishoFaxNoDataGridViewTextBoxColumn.DataPropertyName = "ShishoFaxNo";
            this.shishoFaxNoDataGridViewTextBoxColumn.HeaderText = "ShishoFaxNo";
            this.shishoFaxNoDataGridViewTextBoxColumn.Name = "shishoFaxNoDataGridViewTextBoxColumn";
            this.shishoFaxNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoFreeDialDataGridViewTextBoxColumn
            // 
            this.shishoFreeDialDataGridViewTextBoxColumn.DataPropertyName = "ShishoFreeDial";
            this.shishoFreeDialDataGridViewTextBoxColumn.HeaderText = "ShishoFreeDial";
            this.shishoFreeDialDataGridViewTextBoxColumn.Name = "shishoFreeDialDataGridViewTextBoxColumn";
            this.shishoFreeDialDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn
            // 
            this.insertUserDataGridViewTextBoxColumn.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.Name = "insertUserDataGridViewTextBoxColumn";
            this.insertUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn
            // 
            this.insertTarmDataGridViewTextBoxColumn.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.Name = "insertTarmDataGridViewTextBoxColumn";
            this.insertTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDtDataGridViewTextBoxColumn
            // 
            this.updateDtDataGridViewTextBoxColumn.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.Name = "updateDtDataGridViewTextBoxColumn";
            this.updateDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateUserDataGridViewTextBoxColumn
            // 
            this.updateUserDataGridViewTextBoxColumn.DataPropertyName = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.HeaderText = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.Name = "updateUserDataGridViewTextBoxColumn";
            this.updateUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateTarmDataGridViewTextBoxColumn
            // 
            this.updateTarmDataGridViewTextBoxColumn.DataPropertyName = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.HeaderText = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.Name = "updateTarmDataGridViewTextBoxColumn";
            this.updateTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.sishoCdToTextBox);
            this.searchPanel.Controls.Add(this.sishoCdFromTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.sishoNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(2, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 119);
            this.searchPanel.TabIndex = 0;
            // 
            // sishoCdToTextBox
            // 
            this.sishoCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.sishoCdToTextBox.CustomDigitParts = 0;
            this.sishoCdToTextBox.CustomFormat = null;
            this.sishoCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.sishoCdToTextBox.CustomReadOnly = false;
            this.sishoCdToTextBox.Location = new System.Drawing.Point(184, 36);
            this.sishoCdToTextBox.MaxLength = 1;
            this.sishoCdToTextBox.Name = "sishoCdToTextBox";
            this.sishoCdToTextBox.Size = new System.Drawing.Size(48, 27);
            this.sishoCdToTextBox.TabIndex = 4;
            // 
            // sishoCdFromTextBox
            // 
            this.sishoCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.sishoCdFromTextBox.CustomDigitParts = 0;
            this.sishoCdFromTextBox.CustomFormat = null;
            this.sishoCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.sishoCdFromTextBox.CustomReadOnly = false;
            this.sishoCdFromTextBox.Location = new System.Drawing.Point(102, 36);
            this.sishoCdFromTextBox.MaxLength = 1;
            this.sishoCdFromTextBox.Name = "sishoCdFromTextBox";
            this.sishoCdFromTextBox.Size = new System.Drawing.Size(48, 27);
            this.sishoCdFromTextBox.TabIndex = 2;
            this.sishoCdFromTextBox.Leave += new System.EventHandler(this.sishoCdFromTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // sishoNmTextBox
            // 
            this.sishoNmTextBox.Location = new System.Drawing.Point(102, 69);
            this.sishoNmTextBox.MaxLength = 10;
            this.sishoNmTextBox.Name = "sishoNmTextBox";
            this.sishoNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.sishoNmTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "支所名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 9;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "支所コード";
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
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(884, 75);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 74);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 8;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(860, 553);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 4;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // ShishoMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.sishoMstListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.outputButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShishoMstListForm";
            this.Text = "支所マスタ検索";
            this.Load += new System.EventHandler(this.ShishoMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShishoMstListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstDataSet)).EndInit();
            this.sishoMstListPanel.ResumeLayout(false);
            this.sishoMstListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sishoMstListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Label sishoMstListCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sishoNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.DataGridView sishoMstListDataGridView;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel sishoMstListPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Button outputButton;
        private DataSet.ShishoMstDataSet shishoMstDataSet;
        private System.Windows.Forms.BindingSource shishoMstBindingSource;
        private DataSet.ShishoMstDataSetTableAdapters.ShishoMstTableAdapter shishoMstTableAdapter;
        private Control.NumberTextBox sishoCdToTextBox;
        private Control.NumberTextBox sishoCdFromTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SishoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoChoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SishoAdrCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuridaiaruCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoKeiryoKanrishaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoKenTorokuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoKankyoKeiryoshiNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoZipCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoAdrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoTelNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoFaxNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoFreeDialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;
    }
}