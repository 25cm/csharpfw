namespace FukjBizSystem.Application.Boundary.Master
{
    partial class GaikankensaKomokuMstListForm
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
            this.OutputButton = new System.Windows.Forms.Button();
            this.TojiruButton = new System.Windows.Forms.Button();
            this.ShosaiButton = new System.Windows.Forms.Button();
            this.TorokuButton = new System.Windows.Forms.Button();
            this.gaikankensaKomokuListPanel = new System.Windows.Forms.Panel();
            this.gaikankensaKomokuListCountLabel = new System.Windows.Forms.Label();
            this.gaikankensaKomokuListDataGridView = new System.Windows.Forms.DataGridView();
            this.GaikankensaKomokuCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GaikankensaKomokuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZenGaikankensaKomokuCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZenGaikankensaKomokuRyakumeiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gaikankensaKomokuCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gaikankensaKomokuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zenGaikankensaKomokuCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gaikankensaKomokuMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gaikankensaKomokuMstDataSet = new FukjBizSystem.Application.DataSet.GaikankensaKomokuMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.gaikankensaKomokuCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.gaikankensaKomokuCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.gaikankensaKomokuNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.KensakuButton = new System.Windows.Forms.Button();
            this.gaikankensaKomokuListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaikankensaKomokuListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaikankensaKomokuMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaikankensaKomokuMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputButton
            // 
            this.OutputButton.Location = new System.Drawing.Point(860, 555);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(101, 37);
            this.OutputButton.TabIndex = 15;
            this.OutputButton.Text = "F6:一覧出力";
            this.OutputButton.UseVisualStyleBackColor = true;
            this.OutputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // TojiruButton
            // 
            this.TojiruButton.Location = new System.Drawing.Point(994, 555);
            this.TojiruButton.Name = "TojiruButton";
            this.TojiruButton.Size = new System.Drawing.Size(101, 37);
            this.TojiruButton.TabIndex = 16;
            this.TojiruButton.Text = "F12:閉じる";
            this.TojiruButton.UseVisualStyleBackColor = true;
            this.TojiruButton.Click += new System.EventHandler(this.TojiruButton_Click);
            // 
            // ShosaiButton
            // 
            this.ShosaiButton.Location = new System.Drawing.Point(726, 555);
            this.ShosaiButton.Name = "ShosaiButton";
            this.ShosaiButton.Size = new System.Drawing.Size(101, 37);
            this.ShosaiButton.TabIndex = 14;
            this.ShosaiButton.Text = "F2:詳細";
            this.ShosaiButton.UseVisualStyleBackColor = true;
            this.ShosaiButton.Click += new System.EventHandler(this.ShosaiButton_Click);
            // 
            // TorokuButton
            // 
            this.TorokuButton.Location = new System.Drawing.Point(586, 555);
            this.TorokuButton.Name = "TorokuButton";
            this.TorokuButton.Size = new System.Drawing.Size(101, 37);
            this.TorokuButton.TabIndex = 13;
            this.TorokuButton.Text = "F1:新規登録";
            this.TorokuButton.UseVisualStyleBackColor = true;
            this.TorokuButton.Click += new System.EventHandler(this.TorokuButton_Click);
            // 
            // gaikankensaKomokuListPanel
            // 
            this.gaikankensaKomokuListPanel.Controls.Add(this.gaikankensaKomokuListCountLabel);
            this.gaikankensaKomokuListPanel.Controls.Add(this.gaikankensaKomokuListDataGridView);
            this.gaikankensaKomokuListPanel.Controls.Add(this.label4);
            this.gaikankensaKomokuListPanel.Location = new System.Drawing.Point(0, 112);
            this.gaikankensaKomokuListPanel.Name = "gaikankensaKomokuListPanel";
            this.gaikankensaKomokuListPanel.Size = new System.Drawing.Size(1103, 439);
            this.gaikankensaKomokuListPanel.TabIndex = 12;
            // 
            // gaikankensaKomokuListCountLabel
            // 
            this.gaikankensaKomokuListCountLabel.AutoSize = true;
            this.gaikankensaKomokuListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.gaikankensaKomokuListCountLabel.Name = "gaikankensaKomokuListCountLabel";
            this.gaikankensaKomokuListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.gaikankensaKomokuListCountLabel.TabIndex = 1;
            this.gaikankensaKomokuListCountLabel.Text = "0件";
            // 
            // gaikankensaKomokuListDataGridView
            // 
            this.gaikankensaKomokuListDataGridView.AllowUserToAddRows = false;
            this.gaikankensaKomokuListDataGridView.AllowUserToDeleteRows = false;
            this.gaikankensaKomokuListDataGridView.AllowUserToResizeRows = false;
            this.gaikankensaKomokuListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gaikankensaKomokuListDataGridView.AutoGenerateColumns = false;
            this.gaikankensaKomokuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gaikankensaKomokuListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GaikankensaKomokuCdCol,
            this.GaikankensaKomokuNmCol,
            this.ZenGaikankensaKomokuCdCol,
            this.ZenGaikankensaKomokuRyakumeiCol,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.gaikankensaKomokuCdDataGridViewTextBoxColumn,
            this.gaikankensaKomokuNmDataGridViewTextBoxColumn,
            this.zenGaikankensaKomokuCdDataGridViewTextBoxColumn,
            this.zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn});
            this.gaikankensaKomokuListDataGridView.DataMember = "GaikankensaKomokuMstKensaku";
            this.gaikankensaKomokuListDataGridView.DataSource = this.gaikankensaKomokuMstDataSetBindingSource;
            this.gaikankensaKomokuListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.gaikankensaKomokuListDataGridView.MultiSelect = false;
            this.gaikankensaKomokuListDataGridView.Name = "gaikankensaKomokuListDataGridView";
            this.gaikankensaKomokuListDataGridView.ReadOnly = true;
            this.gaikankensaKomokuListDataGridView.RowHeadersVisible = false;
            this.gaikankensaKomokuListDataGridView.RowTemplate.Height = 21;
            this.gaikankensaKomokuListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gaikankensaKomokuListDataGridView.Size = new System.Drawing.Size(1100, 413);
            this.gaikankensaKomokuListDataGridView.TabIndex = 2;
            this.gaikankensaKomokuListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gaikankensaKomokuListDataGridView_CellDoubleClick);
            // 
            // GaikankensaKomokuCdCol
            // 
            this.GaikankensaKomokuCdCol.DataPropertyName = "GaikankensaKomokuCd";
            this.GaikankensaKomokuCdCol.HeaderText = "外観検査項目コード";
            this.GaikankensaKomokuCdCol.MinimumWidth = 120;
            this.GaikankensaKomokuCdCol.Name = "GaikankensaKomokuCdCol";
            this.GaikankensaKomokuCdCol.ReadOnly = true;
            this.GaikankensaKomokuCdCol.Width = 120;
            // 
            // GaikankensaKomokuNmCol
            // 
            this.GaikankensaKomokuNmCol.DataPropertyName = "GaikankensaKomokuNm";
            this.GaikankensaKomokuNmCol.HeaderText = "外観検査項目名称";
            this.GaikankensaKomokuNmCol.MinimumWidth = 300;
            this.GaikankensaKomokuNmCol.Name = "GaikankensaKomokuNmCol";
            this.GaikankensaKomokuNmCol.ReadOnly = true;
            this.GaikankensaKomokuNmCol.Width = 300;
            // 
            // ZenGaikankensaKomokuCdCol
            // 
            this.ZenGaikankensaKomokuCdCol.DataPropertyName = "ZenGaikankensaKomokuCd";
            this.ZenGaikankensaKomokuCdCol.HeaderText = "前外観検査項目コード";
            this.ZenGaikankensaKomokuCdCol.MinimumWidth = 120;
            this.ZenGaikankensaKomokuCdCol.Name = "ZenGaikankensaKomokuCdCol";
            this.ZenGaikankensaKomokuCdCol.ReadOnly = true;
            this.ZenGaikankensaKomokuCdCol.Visible = false;
            this.ZenGaikankensaKomokuCdCol.Width = 120;
            // 
            // ZenGaikankensaKomokuRyakumeiCol
            // 
            this.ZenGaikankensaKomokuRyakumeiCol.DataPropertyName = "ZenGaikankensaKomokuRyakumei";
            this.ZenGaikankensaKomokuRyakumeiCol.HeaderText = "前外観検査項目略名";
            this.ZenGaikankensaKomokuRyakumeiCol.MinimumWidth = 300;
            this.ZenGaikankensaKomokuRyakumeiCol.Name = "ZenGaikankensaKomokuRyakumeiCol";
            this.ZenGaikankensaKomokuRyakumeiCol.ReadOnly = true;
            this.ZenGaikankensaKomokuRyakumeiCol.Visible = false;
            this.ZenGaikankensaKomokuRyakumeiCol.Width = 300;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "登録日時";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "登録者";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "登録端末";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "更新日時";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "更新者";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "更新端末";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // gaikankensaKomokuCdDataGridViewTextBoxColumn
            // 
            this.gaikankensaKomokuCdDataGridViewTextBoxColumn.DataPropertyName = "GaikankensaKomokuCd";
            this.gaikankensaKomokuCdDataGridViewTextBoxColumn.HeaderText = "GaikankensaKomokuCd";
            this.gaikankensaKomokuCdDataGridViewTextBoxColumn.Name = "gaikankensaKomokuCdDataGridViewTextBoxColumn";
            this.gaikankensaKomokuCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.gaikankensaKomokuCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // gaikankensaKomokuNmDataGridViewTextBoxColumn
            // 
            this.gaikankensaKomokuNmDataGridViewTextBoxColumn.DataPropertyName = "GaikankensaKomokuNm";
            this.gaikankensaKomokuNmDataGridViewTextBoxColumn.HeaderText = "GaikankensaKomokuNm";
            this.gaikankensaKomokuNmDataGridViewTextBoxColumn.Name = "gaikankensaKomokuNmDataGridViewTextBoxColumn";
            this.gaikankensaKomokuNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.gaikankensaKomokuNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // zenGaikankensaKomokuCdDataGridViewTextBoxColumn
            // 
            this.zenGaikankensaKomokuCdDataGridViewTextBoxColumn.DataPropertyName = "ZenGaikankensaKomokuCd";
            this.zenGaikankensaKomokuCdDataGridViewTextBoxColumn.HeaderText = "ZenGaikankensaKomokuCd";
            this.zenGaikankensaKomokuCdDataGridViewTextBoxColumn.Name = "zenGaikankensaKomokuCdDataGridViewTextBoxColumn";
            this.zenGaikankensaKomokuCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.zenGaikankensaKomokuCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn
            // 
            this.zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn.DataPropertyName = "ZenGaikankensaKomokuRyakumei";
            this.zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn.HeaderText = "ZenGaikankensaKomokuRyakumei";
            this.zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn.Name = "zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn";
            this.zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn.ReadOnly = true;
            this.zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn
            // 
            this.insertUserDataGridViewTextBoxColumn.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.Name = "insertUserDataGridViewTextBoxColumn";
            this.insertUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn
            // 
            this.insertTarmDataGridViewTextBoxColumn.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.Name = "insertTarmDataGridViewTextBoxColumn";
            this.insertTarmDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDtDataGridViewTextBoxColumn
            // 
            this.updateDtDataGridViewTextBoxColumn.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.Name = "updateDtDataGridViewTextBoxColumn";
            this.updateDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateUserDataGridViewTextBoxColumn
            // 
            this.updateUserDataGridViewTextBoxColumn.DataPropertyName = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.HeaderText = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.Name = "updateUserDataGridViewTextBoxColumn";
            this.updateUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateTarmDataGridViewTextBoxColumn
            // 
            this.updateTarmDataGridViewTextBoxColumn.DataPropertyName = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.HeaderText = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.Name = "updateTarmDataGridViewTextBoxColumn";
            this.updateTarmDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // gaikankensaKomokuMstDataSetBindingSource
            // 
            this.gaikankensaKomokuMstDataSetBindingSource.DataSource = this.gaikankensaKomokuMstDataSet;
            this.gaikankensaKomokuMstDataSetBindingSource.Position = 0;
            // 
            // gaikankensaKomokuMstDataSet
            // 
            this.gaikankensaKomokuMstDataSet.DataSetName = "GaikankensaKomokuMstDataSet";
            this.gaikankensaKomokuMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "検索結果：";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.gaikankensaKomokuCdToTextBox);
            this.searchPanel.Controls.Add(this.gaikankensaKomokuCdFromTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.gaikankensaKomokuNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.ViewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.ClearButton);
            this.searchPanel.Controls.Add(this.KensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 113);
            this.searchPanel.TabIndex = 11;
            // 
            // gaikankensaKomokuCdToTextBox
            // 
            this.gaikankensaKomokuCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gaikankensaKomokuCdToTextBox.CustomDigitParts = 0;
            this.gaikankensaKomokuCdToTextBox.CustomFormat = null;
            this.gaikankensaKomokuCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gaikankensaKomokuCdToTextBox.CustomReadOnly = false;
            this.gaikankensaKomokuCdToTextBox.Location = new System.Drawing.Point(231, 37);
            this.gaikankensaKomokuCdToTextBox.MaxLength = 3;
            this.gaikankensaKomokuCdToTextBox.Name = "gaikankensaKomokuCdToTextBox";
            this.gaikankensaKomokuCdToTextBox.Size = new System.Drawing.Size(45, 27);
            this.gaikankensaKomokuCdToTextBox.TabIndex = 4;
            this.gaikankensaKomokuCdToTextBox.Leave += new System.EventHandler(this.gaikankensaKomokuCdToTextBox_Leave);
            // 
            // gaikankensaKomokuCdFromTextBox
            // 
            this.gaikankensaKomokuCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gaikankensaKomokuCdFromTextBox.CustomDigitParts = 0;
            this.gaikankensaKomokuCdFromTextBox.CustomFormat = null;
            this.gaikankensaKomokuCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gaikankensaKomokuCdFromTextBox.CustomReadOnly = false;
            this.gaikankensaKomokuCdFromTextBox.Location = new System.Drawing.Point(152, 37);
            this.gaikankensaKomokuCdFromTextBox.MaxLength = 3;
            this.gaikankensaKomokuCdFromTextBox.Name = "gaikankensaKomokuCdFromTextBox";
            this.gaikankensaKomokuCdFromTextBox.Size = new System.Drawing.Size(45, 27);
            this.gaikankensaKomokuCdFromTextBox.TabIndex = 2;
            this.gaikankensaKomokuCdFromTextBox.Leave += new System.EventHandler(this.gaikankensaKomokuCdFromTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // gaikankensaKomokuNmTextBox
            // 
            this.gaikankensaKomokuNmTextBox.Location = new System.Drawing.Point(152, 70);
            this.gaikankensaKomokuNmTextBox.MaxLength = 80;
            this.gaikankensaKomokuNmTextBox.Name = "gaikankensaKomokuNmTextBox";
            this.gaikankensaKomokuNmTextBox.Size = new System.Drawing.Size(675, 27);
            this.gaikankensaKomokuNmTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "外観検査項目名称";
            // 
            // ViewChangeButton
            // 
            this.ViewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.ViewChangeButton.Name = "ViewChangeButton";
            this.ViewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.ViewChangeButton.TabIndex = 9;
            this.ViewChangeButton.Text = "▲";
            this.ViewChangeButton.UseVisualStyleBackColor = true;
            this.ViewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "外観検査項目コード";
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
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(884, 72);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(101, 37);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "F7:クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // KensakuButton
            // 
            this.KensakuButton.Location = new System.Drawing.Point(991, 71);
            this.KensakuButton.Name = "KensakuButton";
            this.KensakuButton.Size = new System.Drawing.Size(101, 37);
            this.KensakuButton.TabIndex = 8;
            this.KensakuButton.Text = "F8:検索";
            this.KensakuButton.UseVisualStyleBackColor = true;
            this.KensakuButton.Click += new System.EventHandler(this.KensakuButton_Click);
            // 
            // GaikankensaKomokuMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.TojiruButton);
            this.Controls.Add(this.ShosaiButton);
            this.Controls.Add(this.TorokuButton);
            this.Controls.Add(this.gaikankensaKomokuListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GaikankensaKomokuMstListForm";
            this.Text = "外観検査項目マスタ検索";
            this.Load += new System.EventHandler(this.GaikankensaKomokuMstList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GaikankensaKomokuMstListForm_KeyDown);
            this.gaikankensaKomokuListPanel.ResumeLayout(false);
            this.gaikankensaKomokuListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaikankensaKomokuListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaikankensaKomokuMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaikankensaKomokuMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.Button TojiruButton;
        private System.Windows.Forms.Button ShosaiButton;
        private System.Windows.Forms.Button TorokuButton;
        private System.Windows.Forms.Panel gaikankensaKomokuListPanel;
        private System.Windows.Forms.Label gaikankensaKomokuListCountLabel;
        private System.Windows.Forms.DataGridView gaikankensaKomokuListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gaikankensaKomokuNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ViewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button KensakuButton;
        private System.Windows.Forms.BindingSource gaikankensaKomokuMstDataSetBindingSource;
        private DataSet.GaikankensaKomokuMstDataSet gaikankensaKomokuMstDataSet;
        private Control.NumberTextBox gaikankensaKomokuCdToTextBox;
        private Control.NumberTextBox gaikankensaKomokuCdFromTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn GaikankensaKomokuCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GaikankensaKomokuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZenGaikankensaKomokuCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZenGaikankensaKomokuRyakumeiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn gaikankensaKomokuCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gaikankensaKomokuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zenGaikankensaKomokuCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zenGaikankensaKomokuRyakumeiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;

    }
}