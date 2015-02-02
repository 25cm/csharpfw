namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    partial class SaisuiinInfoListForm
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
            this.saisuiinKanriListPanel = new System.Windows.Forms.Panel();
            this.saisuiinKanriListCountLabel = new System.Windows.Forms.Label();
            this.saisuiinKanriListDataGridView = new System.Windows.Forms.DataGridView();
            this.SaisuiinCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaisuiinNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyozokuGyosyaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyozokuGyosyaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaisuiinSyutokuDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JukoDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaisuiinYukokigenDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saisuiinCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saisuiinNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syozokuGyosyaCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jukoDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jukoDtColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saisuiinSyutokuDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saisuiinSyutokuDtColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saisuiinYukokigenDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saisuiinYukokigenDtColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saisuiinMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saisuiinMstDataSet = new FukjBizSystem.Application.DataSet.SaisuiinMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.jukoDtToDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.jukoDtFromDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.saisuiinCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.saisuiinCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.syozokuGyosyaCdToTextBox = new System.Windows.Forms.TextBox();
            this.syozokuGyosyaCdFromTextBox = new System.Windows.Forms.TextBox();
            this.gyoshaToSearchButton = new System.Windows.Forms.Button();
            this.gyoshaFromSearchButton = new System.Windows.Forms.Button();
            this.addConditionsFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.saisuiinNmTextBox = new System.Windows.Forms.TextBox();
            this.gyoshaNmToTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gyoshaNmFromTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.KensakuButton = new System.Windows.Forms.Button();
            this.saisuiinKanriListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saisuiinKanriListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saisuiinMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saisuiinMstDataSet)).BeginInit();
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
            // saisuiinKanriListPanel
            // 
            this.saisuiinKanriListPanel.Controls.Add(this.saisuiinKanriListCountLabel);
            this.saisuiinKanriListPanel.Controls.Add(this.saisuiinKanriListDataGridView);
            this.saisuiinKanriListPanel.Controls.Add(this.label4);
            this.saisuiinKanriListPanel.Location = new System.Drawing.Point(0, 178);
            this.saisuiinKanriListPanel.Name = "saisuiinKanriListPanel";
            this.saisuiinKanriListPanel.Size = new System.Drawing.Size(1103, 373);
            this.saisuiinKanriListPanel.TabIndex = 12;
            // 
            // saisuiinKanriListCountLabel
            // 
            this.saisuiinKanriListCountLabel.AutoSize = true;
            this.saisuiinKanriListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.saisuiinKanriListCountLabel.Name = "saisuiinKanriListCountLabel";
            this.saisuiinKanriListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.saisuiinKanriListCountLabel.TabIndex = 1;
            this.saisuiinKanriListCountLabel.Text = "0件";
            // 
            // saisuiinKanriListDataGridView
            // 
            this.saisuiinKanriListDataGridView.AllowUserToAddRows = false;
            this.saisuiinKanriListDataGridView.AllowUserToDeleteRows = false;
            this.saisuiinKanriListDataGridView.AllowUserToResizeRows = false;
            this.saisuiinKanriListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saisuiinKanriListDataGridView.AutoGenerateColumns = false;
            this.saisuiinKanriListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saisuiinKanriListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaisuiinCdCol,
            this.SaisuiinNmCol,
            this.SyozokuGyosyaCdCol,
            this.SyozokuGyosyaNmCol,
            this.SaisuiinSyutokuDtCol,
            this.JukoDtCol,
            this.SaisuiinYukokigenDtCol,
            this.saisuiinCdDataGridViewTextBoxColumn,
            this.saisuiinNmDataGridViewTextBoxColumn,
            this.syozokuGyosyaCdDataGridViewTextBoxColumn,
            this.jukoDtDataGridViewTextBoxColumn,
            this.jukoDtColDataGridViewTextBoxColumn,
            this.saisuiinSyutokuDtDataGridViewTextBoxColumn,
            this.saisuiinSyutokuDtColDataGridViewTextBoxColumn,
            this.saisuiinYukokigenDtDataGridViewTextBoxColumn,
            this.saisuiinYukokigenDtColDataGridViewTextBoxColumn,
            this.gyoshaNmDataGridViewTextBoxColumn});
            this.saisuiinKanriListDataGridView.DataMember = "SaisuiinInfoList";
            this.saisuiinKanriListDataGridView.DataSource = this.saisuiinMstDataSetBindingSource;
            this.saisuiinKanriListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.saisuiinKanriListDataGridView.MultiSelect = false;
            this.saisuiinKanriListDataGridView.Name = "saisuiinKanriListDataGridView";
            this.saisuiinKanriListDataGridView.ReadOnly = true;
            this.saisuiinKanriListDataGridView.RowHeadersVisible = false;
            this.saisuiinKanriListDataGridView.RowTemplate.Height = 21;
            this.saisuiinKanriListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saisuiinKanriListDataGridView.Size = new System.Drawing.Size(1100, 347);
            this.saisuiinKanriListDataGridView.TabIndex = 2;
            this.saisuiinKanriListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.saisuiinKanriListDataGridView_CellDoubleClick);
            // 
            // SaisuiinCdCol
            // 
            this.SaisuiinCdCol.DataPropertyName = "SaisuiinCd";
            this.SaisuiinCdCol.HeaderText = "採水員コード";
            this.SaisuiinCdCol.MinimumWidth = 100;
            this.SaisuiinCdCol.Name = "SaisuiinCdCol";
            this.SaisuiinCdCol.ReadOnly = true;
            this.SaisuiinCdCol.Width = 120;
            // 
            // SaisuiinNmCol
            // 
            this.SaisuiinNmCol.DataPropertyName = "SaisuiinNm";
            this.SaisuiinNmCol.HeaderText = "採水員名";
            this.SaisuiinNmCol.MinimumWidth = 200;
            this.SaisuiinNmCol.Name = "SaisuiinNmCol";
            this.SaisuiinNmCol.ReadOnly = true;
            this.SaisuiinNmCol.Width = 250;
            // 
            // SyozokuGyosyaCdCol
            // 
            this.SyozokuGyosyaCdCol.DataPropertyName = "SyozokuGyosyaCd";
            this.SyozokuGyosyaCdCol.HeaderText = "所属業者コード";
            this.SyozokuGyosyaCdCol.MinimumWidth = 100;
            this.SyozokuGyosyaCdCol.Name = "SyozokuGyosyaCdCol";
            this.SyozokuGyosyaCdCol.ReadOnly = true;
            this.SyozokuGyosyaCdCol.Width = 130;
            // 
            // SyozokuGyosyaNmCol
            // 
            this.SyozokuGyosyaNmCol.DataPropertyName = "GyoshaNm";
            this.SyozokuGyosyaNmCol.HeaderText = "所属業者名";
            this.SyozokuGyosyaNmCol.MinimumWidth = 200;
            this.SyozokuGyosyaNmCol.Name = "SyozokuGyosyaNmCol";
            this.SyozokuGyosyaNmCol.ReadOnly = true;
            this.SyozokuGyosyaNmCol.Width = 250;
            // 
            // SaisuiinSyutokuDtCol
            // 
            this.SaisuiinSyutokuDtCol.DataPropertyName = "SaisuiinSyutokuDtCol";
            this.SaisuiinSyutokuDtCol.HeaderText = "取得日";
            this.SaisuiinSyutokuDtCol.MinimumWidth = 100;
            this.SaisuiinSyutokuDtCol.Name = "SaisuiinSyutokuDtCol";
            this.SaisuiinSyutokuDtCol.ReadOnly = true;
            this.SaisuiinSyutokuDtCol.Width = 110;
            // 
            // JukoDtCol
            // 
            this.JukoDtCol.DataPropertyName = "JukoDtCol";
            this.JukoDtCol.HeaderText = "受講日";
            this.JukoDtCol.MinimumWidth = 100;
            this.JukoDtCol.Name = "JukoDtCol";
            this.JukoDtCol.ReadOnly = true;
            this.JukoDtCol.Width = 110;
            // 
            // SaisuiinYukokigenDtCol
            // 
            this.SaisuiinYukokigenDtCol.DataPropertyName = "SaisuiinYukokigenDtCol";
            this.SaisuiinYukokigenDtCol.HeaderText = "有効期限";
            this.SaisuiinYukokigenDtCol.MinimumWidth = 100;
            this.SaisuiinYukokigenDtCol.Name = "SaisuiinYukokigenDtCol";
            this.SaisuiinYukokigenDtCol.ReadOnly = true;
            this.SaisuiinYukokigenDtCol.Width = 110;
            // 
            // saisuiinCdDataGridViewTextBoxColumn
            // 
            this.saisuiinCdDataGridViewTextBoxColumn.DataPropertyName = "SaisuiinCd";
            this.saisuiinCdDataGridViewTextBoxColumn.HeaderText = "SaisuiinCd";
            this.saisuiinCdDataGridViewTextBoxColumn.Name = "saisuiinCdDataGridViewTextBoxColumn";
            this.saisuiinCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.saisuiinCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // saisuiinNmDataGridViewTextBoxColumn
            // 
            this.saisuiinNmDataGridViewTextBoxColumn.DataPropertyName = "SaisuiinNm";
            this.saisuiinNmDataGridViewTextBoxColumn.HeaderText = "SaisuiinNm";
            this.saisuiinNmDataGridViewTextBoxColumn.Name = "saisuiinNmDataGridViewTextBoxColumn";
            this.saisuiinNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.saisuiinNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // syozokuGyosyaCdDataGridViewTextBoxColumn
            // 
            this.syozokuGyosyaCdDataGridViewTextBoxColumn.DataPropertyName = "SyozokuGyosyaCd";
            this.syozokuGyosyaCdDataGridViewTextBoxColumn.HeaderText = "SyozokuGyosyaCd";
            this.syozokuGyosyaCdDataGridViewTextBoxColumn.Name = "syozokuGyosyaCdDataGridViewTextBoxColumn";
            this.syozokuGyosyaCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.syozokuGyosyaCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // jukoDtDataGridViewTextBoxColumn
            // 
            this.jukoDtDataGridViewTextBoxColumn.DataPropertyName = "JukoDt";
            this.jukoDtDataGridViewTextBoxColumn.HeaderText = "JukoDt";
            this.jukoDtDataGridViewTextBoxColumn.Name = "jukoDtDataGridViewTextBoxColumn";
            this.jukoDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.jukoDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // jukoDtColDataGridViewTextBoxColumn
            // 
            this.jukoDtColDataGridViewTextBoxColumn.DataPropertyName = "JukoDtCol";
            this.jukoDtColDataGridViewTextBoxColumn.HeaderText = "JukoDtCol";
            this.jukoDtColDataGridViewTextBoxColumn.Name = "jukoDtColDataGridViewTextBoxColumn";
            this.jukoDtColDataGridViewTextBoxColumn.ReadOnly = true;
            this.jukoDtColDataGridViewTextBoxColumn.Visible = false;
            // 
            // saisuiinSyutokuDtDataGridViewTextBoxColumn
            // 
            this.saisuiinSyutokuDtDataGridViewTextBoxColumn.DataPropertyName = "SaisuiinSyutokuDt";
            this.saisuiinSyutokuDtDataGridViewTextBoxColumn.HeaderText = "SaisuiinSyutokuDt";
            this.saisuiinSyutokuDtDataGridViewTextBoxColumn.Name = "saisuiinSyutokuDtDataGridViewTextBoxColumn";
            this.saisuiinSyutokuDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.saisuiinSyutokuDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // saisuiinSyutokuDtColDataGridViewTextBoxColumn
            // 
            this.saisuiinSyutokuDtColDataGridViewTextBoxColumn.DataPropertyName = "SaisuiinSyutokuDtCol";
            this.saisuiinSyutokuDtColDataGridViewTextBoxColumn.HeaderText = "SaisuiinSyutokuDtCol";
            this.saisuiinSyutokuDtColDataGridViewTextBoxColumn.Name = "saisuiinSyutokuDtColDataGridViewTextBoxColumn";
            this.saisuiinSyutokuDtColDataGridViewTextBoxColumn.ReadOnly = true;
            this.saisuiinSyutokuDtColDataGridViewTextBoxColumn.Visible = false;
            // 
            // saisuiinYukokigenDtDataGridViewTextBoxColumn
            // 
            this.saisuiinYukokigenDtDataGridViewTextBoxColumn.DataPropertyName = "SaisuiinYukokigenDt";
            this.saisuiinYukokigenDtDataGridViewTextBoxColumn.HeaderText = "SaisuiinYukokigenDt";
            this.saisuiinYukokigenDtDataGridViewTextBoxColumn.Name = "saisuiinYukokigenDtDataGridViewTextBoxColumn";
            this.saisuiinYukokigenDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.saisuiinYukokigenDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // saisuiinYukokigenDtColDataGridViewTextBoxColumn
            // 
            this.saisuiinYukokigenDtColDataGridViewTextBoxColumn.DataPropertyName = "SaisuiinYukokigenDtCol";
            this.saisuiinYukokigenDtColDataGridViewTextBoxColumn.HeaderText = "SaisuiinYukokigenDtCol";
            this.saisuiinYukokigenDtColDataGridViewTextBoxColumn.Name = "saisuiinYukokigenDtColDataGridViewTextBoxColumn";
            this.saisuiinYukokigenDtColDataGridViewTextBoxColumn.ReadOnly = true;
            this.saisuiinYukokigenDtColDataGridViewTextBoxColumn.Visible = false;
            // 
            // gyoshaNmDataGridViewTextBoxColumn
            // 
            this.gyoshaNmDataGridViewTextBoxColumn.DataPropertyName = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.HeaderText = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.Name = "gyoshaNmDataGridViewTextBoxColumn";
            this.gyoshaNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.gyoshaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // saisuiinMstDataSetBindingSource
            // 
            this.saisuiinMstDataSetBindingSource.DataSource = this.saisuiinMstDataSet;
            this.saisuiinMstDataSetBindingSource.Position = 0;
            // 
            // saisuiinMstDataSet
            // 
            this.saisuiinMstDataSet.DataSetName = "SaisuiinMstDataSet";
            this.saisuiinMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.jukoDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.jukoDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.saisuiinCdToTextBox);
            this.searchPanel.Controls.Add(this.saisuiinCdFromTextBox);
            this.searchPanel.Controls.Add(this.syozokuGyosyaCdToTextBox);
            this.searchPanel.Controls.Add(this.syozokuGyosyaCdFromTextBox);
            this.searchPanel.Controls.Add(this.gyoshaToSearchButton);
            this.searchPanel.Controls.Add(this.gyoshaFromSearchButton);
            this.searchPanel.Controls.Add(this.addConditionsFlgCheckBox);
            this.searchPanel.Controls.Add(this.label11);
            this.searchPanel.Controls.Add(this.label9);
            this.searchPanel.Controls.Add(this.saisuiinNmTextBox);
            this.searchPanel.Controls.Add(this.gyoshaNmToTextBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.gyoshaNmFromTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.ViewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.ClearButton);
            this.searchPanel.Controls.Add(this.KensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 178);
            this.searchPanel.TabIndex = 11;
            // 
            // jukoDtToDateTimePicker
            // 
            this.jukoDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.jukoDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jukoDtToDateTimePicker.Location = new System.Drawing.Point(303, 131);
            this.jukoDtToDateTimePicker.Name = "jukoDtToDateTimePicker";
            this.jukoDtToDateTimePicker.Size = new System.Drawing.Size(147, 27);
            this.jukoDtToDateTimePicker.TabIndex = 19;
            // 
            // jukoDtFromDateTimePicker
            // 
            this.jukoDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.jukoDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jukoDtFromDateTimePicker.Location = new System.Drawing.Point(122, 131);
            this.jukoDtFromDateTimePicker.Name = "jukoDtFromDateTimePicker";
            this.jukoDtFromDateTimePicker.Size = new System.Drawing.Size(147, 27);
            this.jukoDtFromDateTimePicker.TabIndex = 7;
            this.jukoDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.jukoDtFromDateTimePicker_ValueChanged);
            // 
            // saisuiinCdToTextBox
            // 
            this.saisuiinCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.saisuiinCdToTextBox.CustomDigitParts = 0;
            this.saisuiinCdToTextBox.CustomFormat = null;
            this.saisuiinCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.saisuiinCdToTextBox.CustomReadOnly = false;
            this.saisuiinCdToTextBox.Location = new System.Drawing.Point(236, 32);
            this.saisuiinCdToTextBox.MaxLength = 5;
            this.saisuiinCdToTextBox.Name = "saisuiinCdToTextBox";
            this.saisuiinCdToTextBox.Size = new System.Drawing.Size(80, 27);
            this.saisuiinCdToTextBox.TabIndex = 4;
            this.saisuiinCdToTextBox.Leave += new System.EventHandler(this.saisuiinCdToTextBox_Leave);
            // 
            // saisuiinCdFromTextBox
            // 
            this.saisuiinCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.saisuiinCdFromTextBox.CustomDigitParts = 0;
            this.saisuiinCdFromTextBox.CustomFormat = null;
            this.saisuiinCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.saisuiinCdFromTextBox.CustomReadOnly = false;
            this.saisuiinCdFromTextBox.Location = new System.Drawing.Point(122, 32);
            this.saisuiinCdFromTextBox.MaxLength = 5;
            this.saisuiinCdFromTextBox.Name = "saisuiinCdFromTextBox";
            this.saisuiinCdFromTextBox.Size = new System.Drawing.Size(80, 27);
            this.saisuiinCdFromTextBox.TabIndex = 2;
            this.saisuiinCdFromTextBox.Leave += new System.EventHandler(this.saisuiinCdFromTextBox_Leave);
            // 
            // syozokuGyosyaCdToTextBox
            // 
            this.syozokuGyosyaCdToTextBox.Location = new System.Drawing.Point(680, 65);
            this.syozokuGyosyaCdToTextBox.Name = "syozokuGyosyaCdToTextBox";
            this.syozokuGyosyaCdToTextBox.Size = new System.Drawing.Size(46, 27);
            this.syozokuGyosyaCdToTextBox.TabIndex = 13;
            this.syozokuGyosyaCdToTextBox.Visible = false;
            // 
            // syozokuGyosyaCdFromTextBox
            // 
            this.syozokuGyosyaCdFromTextBox.Location = new System.Drawing.Point(628, 65);
            this.syozokuGyosyaCdFromTextBox.Name = "syozokuGyosyaCdFromTextBox";
            this.syozokuGyosyaCdFromTextBox.Size = new System.Drawing.Size(46, 27);
            this.syozokuGyosyaCdFromTextBox.TabIndex = 12;
            this.syozokuGyosyaCdFromTextBox.Visible = false;
            // 
            // gyoshaToSearchButton
            // 
            this.gyoshaToSearchButton.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.gyoshaToSearchButton.Location = new System.Drawing.Point(595, 65);
            this.gyoshaToSearchButton.Name = "gyoshaToSearchButton";
            this.gyoshaToSearchButton.Size = new System.Drawing.Size(27, 28);
            this.gyoshaToSearchButton.TabIndex = 11;
            this.gyoshaToSearchButton.UseVisualStyleBackColor = true;
            this.gyoshaToSearchButton.Click += new System.EventHandler(this.gyoshaToSearchButton_Click);
            // 
            // gyoshaFromSearchButton
            // 
            this.gyoshaFromSearchButton.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.gyoshaFromSearchButton.Location = new System.Drawing.Point(328, 64);
            this.gyoshaFromSearchButton.Name = "gyoshaFromSearchButton";
            this.gyoshaFromSearchButton.Size = new System.Drawing.Size(27, 28);
            this.gyoshaFromSearchButton.TabIndex = 8;
            this.gyoshaFromSearchButton.UseVisualStyleBackColor = true;
            this.gyoshaFromSearchButton.Click += new System.EventHandler(this.gyoshaFromSearchButton_Click);
            // 
            // addConditionsFlgCheckBox
            // 
            this.addConditionsFlgCheckBox.AutoSize = true;
            this.addConditionsFlgCheckBox.Location = new System.Drawing.Point(13, 135);
            this.addConditionsFlgCheckBox.Name = "addConditionsFlgCheckBox";
            this.addConditionsFlgCheckBox.Size = new System.Drawing.Size(67, 24);
            this.addConditionsFlgCheckBox.TabIndex = 16;
            this.addConditionsFlgCheckBox.Text = "受講日";
            this.addConditionsFlgCheckBox.UseVisualStyleBackColor = true;
            this.addConditionsFlgCheckBox.CheckedChanged += new System.EventHandler(this.AddConditionsFlgCheckBox_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(322, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "例) 01234 (半角";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "～";
            // 
            // saisuiinNmTextBox
            // 
            this.saisuiinNmTextBox.Location = new System.Drawing.Point(122, 98);
            this.saisuiinNmTextBox.MaxLength = 40;
            this.saisuiinNmTextBox.Name = "saisuiinNmTextBox";
            this.saisuiinNmTextBox.Size = new System.Drawing.Size(400, 27);
            this.saisuiinNmTextBox.TabIndex = 15;
            // 
            // gyoshaNmToTextBox
            // 
            this.gyoshaNmToTextBox.Location = new System.Drawing.Point(389, 65);
            this.gyoshaNmToTextBox.Name = "gyoshaNmToTextBox";
            this.gyoshaNmToTextBox.ReadOnly = true;
            this.gyoshaNmToTextBox.Size = new System.Drawing.Size(200, 27);
            this.gyoshaNmToTextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "採水員名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // gyoshaNmFromTextBox
            // 
            this.gyoshaNmFromTextBox.Location = new System.Drawing.Point(122, 65);
            this.gyoshaNmFromTextBox.Name = "gyoshaNmFromTextBox";
            this.gyoshaNmFromTextBox.ReadOnly = true;
            this.gyoshaNmFromTextBox.Size = new System.Drawing.Size(200, 27);
            this.gyoshaNmFromTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "所属業者";
            // 
            // ViewChangeButton
            // 
            this.ViewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.ViewChangeButton.Name = "ViewChangeButton";
            this.ViewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.ViewChangeButton.TabIndex = 22;
            this.ViewChangeButton.Text = "▲";
            this.ViewChangeButton.UseVisualStyleBackColor = true;
            this.ViewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "採水員コード";
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
            this.ClearButton.Location = new System.Drawing.Point(884, 135);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(101, 37);
            this.ClearButton.TabIndex = 20;
            this.ClearButton.Text = "F7:クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // KensakuButton
            // 
            this.KensakuButton.Location = new System.Drawing.Point(991, 134);
            this.KensakuButton.Name = "KensakuButton";
            this.KensakuButton.Size = new System.Drawing.Size(101, 37);
            this.KensakuButton.TabIndex = 21;
            this.KensakuButton.Text = "F8:検索";
            this.KensakuButton.UseVisualStyleBackColor = true;
            this.KensakuButton.Click += new System.EventHandler(this.KensakuButton_Click);
            // 
            // SaisuiinInfoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.TojiruButton);
            this.Controls.Add(this.ShosaiButton);
            this.Controls.Add(this.TorokuButton);
            this.Controls.Add(this.saisuiinKanriListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SaisuiinInfoListForm";
            this.Text = "採水員情報検索";
            this.Load += new System.EventHandler(this.SaisuiinInfoList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaisuiinInfoList_KeyDown);
            this.saisuiinKanriListPanel.ResumeLayout(false);
            this.saisuiinKanriListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saisuiinKanriListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saisuiinMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saisuiinMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.Button TojiruButton;
        private System.Windows.Forms.Button ShosaiButton;
        private System.Windows.Forms.Button TorokuButton;
        private System.Windows.Forms.Panel saisuiinKanriListPanel;
        private System.Windows.Forms.Label saisuiinKanriListCountLabel;
        private System.Windows.Forms.DataGridView saisuiinKanriListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gyoshaNmFromTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ViewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button KensakuButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox saisuiinNmTextBox;
        private System.Windows.Forms.TextBox gyoshaNmToTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox addConditionsFlgCheckBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox syozokuGyosyaCdToTextBox;
        private System.Windows.Forms.TextBox syozokuGyosyaCdFromTextBox;
        private System.Windows.Forms.Button gyoshaToSearchButton;
        private System.Windows.Forms.Button gyoshaFromSearchButton;
        private Control.NumberTextBox saisuiinCdToTextBox;
        private Control.NumberTextBox saisuiinCdFromTextBox;
        private System.Windows.Forms.BindingSource saisuiinMstDataSetBindingSource;
        private DataSet.SaisuiinMstDataSet saisuiinMstDataSet;
        private Zynas.Control.ZDate jukoDtToDateTimePicker;
        private Zynas.Control.ZDate jukoDtFromDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaisuiinCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaisuiinNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyozokuGyosyaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyozokuGyosyaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaisuiinSyutokuDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JukoDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaisuiinYukokigenDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn saisuiinCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saisuiinNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn syozokuGyosyaCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jukoDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jukoDtColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saisuiinSyutokuDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saisuiinSyutokuDtColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saisuiinYukokigenDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saisuiinYukokigenDtColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmDataGridViewTextBoxColumn;

    }
}