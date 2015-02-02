namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class SyokenKekkaSelectForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.syokenDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.shokenKekkaSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shokenMstDataSet = new FukjBizSystem.Application.DataSet.ShokenMstDataSet();
            this.label24 = new System.Windows.Forms.Label();
            this.checkItemCdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.checkItemNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.selectButton = new System.Windows.Forms.Button();
            this.checkItemComboBox = new System.Windows.Forms.ComboBox();
            this.sonyuIchiNumTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.hosokuDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.shokenKekkaSelectTableAdapter = new FukjBizSystem.Application.DataSet.ShokenMstDataSetTableAdapters.ShokenKekkaSelectTableAdapter();
            this.syokenKbnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syokenCdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syokenWdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juyodoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hanteiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bikoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenWdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juyodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hanteiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenBikoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokenJuyodoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokenHandanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokenHanteiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuikaFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shokenKbnDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenWdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juyodoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handanDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hanteiDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenBikoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.syokenDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenKekkaSelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hosokuDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(976, 521);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // syokenDataGridView
            // 
            this.syokenDataGridView.AllowUserToAddRows = false;
            this.syokenDataGridView.AllowUserToDeleteRows = false;
            this.syokenDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syokenDataGridView.AutoGenerateColumns = false;
            this.syokenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.syokenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.syokenKbnColumn,
            this.syokenCdColumn,
            this.syokenWdColumn,
            this.juyodoColumn,
            this.handanColumn,
            this.hanteiColumn,
            this.bikoColumn,
            this.shokenKbnDataGridViewTextBoxColumn,
            this.shokenCdDataGridViewTextBoxColumn,
            this.shokenWdDataGridViewTextBoxColumn,
            this.juyodoDataGridViewTextBoxColumn,
            this.handanDataGridViewTextBoxColumn,
            this.hanteiDataGridViewTextBoxColumn,
            this.shokenBikoDataGridViewTextBoxColumn,
            this.ShokenJuyodoCol,
            this.ShokenHandanCol,
            this.ShokenHanteiCol});
            this.syokenDataGridView.DataSource = this.shokenKekkaSelectBindingSource;
            this.syokenDataGridView.Location = new System.Drawing.Point(8, 48);
            this.syokenDataGridView.MultiSelect = false;
            this.syokenDataGridView.Name = "syokenDataGridView";
            this.syokenDataGridView.ReadOnly = true;
            this.syokenDataGridView.RowTemplate.Height = 21;
            this.syokenDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.syokenDataGridView.Size = new System.Drawing.Size(1067, 284);
            this.syokenDataGridView.TabIndex = 6;
            this.syokenDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.syokenDataGridView_CellDoubleClick);
            // 
            // shokenKekkaSelectBindingSource
            // 
            this.shokenKekkaSelectBindingSource.DataMember = "ShokenKekkaSelect";
            this.shokenKekkaSelectBindingSource.DataSource = this.shokenMstDataSet;
            // 
            // shokenMstDataSet
            // 
            this.shokenMstDataSet.DataSetName = "ShokenMstDataSet";
            this.shokenMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "チェック項目";
            // 
            // checkItemCdTextBox
            // 
            this.checkItemCdTextBox.AllowDropDown = false;
            this.checkItemCdTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.checkItemCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.checkItemCdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.checkItemCdTextBox.CustomReadOnly = true;
            this.checkItemCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.checkItemCdTextBox.Location = new System.Drawing.Point(100, 12);
            this.checkItemCdTextBox.MaxLength = 3;
            this.checkItemCdTextBox.Name = "checkItemCdTextBox";
            this.checkItemCdTextBox.ReadOnly = true;
            this.checkItemCdTextBox.Size = new System.Drawing.Size(52, 27);
            this.checkItemCdTextBox.TabIndex = 1;
            this.checkItemCdTextBox.TabStop = false;
            // 
            // checkItemNmTextBox
            // 
            this.checkItemNmTextBox.AllowDropDown = false;
            this.checkItemNmTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.checkItemNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.checkItemNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.checkItemNmTextBox.CustomReadOnly = true;
            this.checkItemNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.checkItemNmTextBox.Location = new System.Drawing.Point(152, 12);
            this.checkItemNmTextBox.MaxLength = 80;
            this.checkItemNmTextBox.Name = "checkItemNmTextBox";
            this.checkItemNmTextBox.ReadOnly = true;
            this.checkItemNmTextBox.Size = new System.Drawing.Size(284, 27);
            this.checkItemNmTextBox.TabIndex = 2;
            this.checkItemNmTextBox.TabStop = false;
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectButton.Location = new System.Drawing.Point(867, 521);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(101, 37);
            this.selectButton.TabIndex = 9;
            this.selectButton.Text = "F1:選択戻り";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // checkItemComboBox
            // 
            this.checkItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkItemComboBox.FormattingEnabled = true;
            this.checkItemComboBox.Location = new System.Drawing.Point(444, 12);
            this.checkItemComboBox.Name = "checkItemComboBox";
            this.checkItemComboBox.Size = new System.Drawing.Size(284, 28);
            this.checkItemComboBox.TabIndex = 3;
            this.checkItemComboBox.Visible = false;
            this.checkItemComboBox.SelectedIndexChanged += new System.EventHandler(this.checkItemComboBox_SelectedIndexChanged);
            // 
            // sonyuIchiNumTextBox
            // 
            this.sonyuIchiNumTextBox.AllowDropDown = false;
            this.sonyuIchiNumTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.sonyuIchiNumTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.sonyuIchiNumTextBox.CustomReadOnly = false;
            this.sonyuIchiNumTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.sonyuIchiNumTextBox.Location = new System.Drawing.Point(1032, 12);
            this.sonyuIchiNumTextBox.MaxLength = 2;
            this.sonyuIchiNumTextBox.Name = "sonyuIchiNumTextBox";
            this.sonyuIchiNumTextBox.Size = new System.Drawing.Size(42, 27);
            this.sonyuIchiNumTextBox.TabIndex = 5;
            this.sonyuIchiNumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(964, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "挿入位置";
            // 
            // hosokuDataGridView
            // 
            this.hosokuDataGridView.AllowUserToAddRows = false;
            this.hosokuDataGridView.AllowUserToDeleteRows = false;
            this.hosokuDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hosokuDataGridView.AutoGenerateColumns = false;
            this.hosokuDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hosokuDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TuikaFlgCol,
            this.shokenKbnDataGridViewTextBoxColumn2,
            this.shokenCdDataGridViewTextBoxColumn2,
            this.shokenWdDataGridViewTextBoxColumn2,
            this.juyodoDataGridViewTextBoxColumn1,
            this.handanDataGridViewTextBoxColumn1,
            this.hanteiDataGridViewTextBoxColumn1,
            this.shokenBikoDataGridViewTextBoxColumn1});
            this.hosokuDataGridView.DataSource = this.shokenKekkaSelectBindingSource;
            this.hosokuDataGridView.Location = new System.Drawing.Point(8, 368);
            this.hosokuDataGridView.MultiSelect = false;
            this.hosokuDataGridView.Name = "hosokuDataGridView";
            this.hosokuDataGridView.RowTemplate.Height = 21;
            this.hosokuDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hosokuDataGridView.Size = new System.Drawing.Size(1067, 140);
            this.hosokuDataGridView.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "補足";
            // 
            // shokenKekkaSelectTableAdapter
            // 
            this.shokenKekkaSelectTableAdapter.ClearBeforeFill = true;
            // 
            // syokenKbnColumn
            // 
            this.syokenKbnColumn.DataPropertyName = "ShokenKbn";
            this.syokenKbnColumn.HeaderText = "所見区分";
            this.syokenKbnColumn.MaxInputLength = 2;
            this.syokenKbnColumn.Name = "syokenKbnColumn";
            this.syokenKbnColumn.ReadOnly = true;
            this.syokenKbnColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.syokenKbnColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.syokenKbnColumn.Width = 80;
            // 
            // syokenCdColumn
            // 
            this.syokenCdColumn.DataPropertyName = "ShokenCd";
            this.syokenCdColumn.HeaderText = "所見CD";
            this.syokenCdColumn.MaxInputLength = 3;
            this.syokenCdColumn.Name = "syokenCdColumn";
            this.syokenCdColumn.ReadOnly = true;
            this.syokenCdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.syokenCdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.syokenCdColumn.Width = 80;
            // 
            // syokenWdColumn
            // 
            this.syokenWdColumn.DataPropertyName = "ShokenWd";
            this.syokenWdColumn.HeaderText = "内容";
            this.syokenWdColumn.Name = "syokenWdColumn";
            this.syokenWdColumn.ReadOnly = true;
            this.syokenWdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.syokenWdColumn.Width = 650;
            // 
            // juyodoColumn
            // 
            this.juyodoColumn.DataPropertyName = "Juyodo";
            this.juyodoColumn.HeaderText = "重要度";
            this.juyodoColumn.Name = "juyodoColumn";
            this.juyodoColumn.ReadOnly = true;
            this.juyodoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.juyodoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.juyodoColumn.Width = 30;
            // 
            // handanColumn
            // 
            this.handanColumn.DataPropertyName = "Handan";
            this.handanColumn.HeaderText = "判断";
            this.handanColumn.Name = "handanColumn";
            this.handanColumn.ReadOnly = true;
            this.handanColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.handanColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.handanColumn.Width = 30;
            // 
            // hanteiColumn
            // 
            this.hanteiColumn.DataPropertyName = "Hantei";
            this.hanteiColumn.HeaderText = "判定";
            this.hanteiColumn.Name = "hanteiColumn";
            this.hanteiColumn.ReadOnly = true;
            this.hanteiColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.hanteiColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bikoColumn
            // 
            this.bikoColumn.DataPropertyName = "ShokenBiko";
            this.bikoColumn.HeaderText = "備考";
            this.bikoColumn.Name = "bikoColumn";
            this.bikoColumn.ReadOnly = true;
            this.bikoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bikoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.bikoColumn.Width = 30;
            // 
            // shokenKbnDataGridViewTextBoxColumn
            // 
            this.shokenKbnDataGridViewTextBoxColumn.DataPropertyName = "ShokenKbn";
            this.shokenKbnDataGridViewTextBoxColumn.HeaderText = "ShokenKbn";
            this.shokenKbnDataGridViewTextBoxColumn.Name = "shokenKbnDataGridViewTextBoxColumn";
            this.shokenKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenCdDataGridViewTextBoxColumn
            // 
            this.shokenCdDataGridViewTextBoxColumn.DataPropertyName = "ShokenCd";
            this.shokenCdDataGridViewTextBoxColumn.HeaderText = "ShokenCd";
            this.shokenCdDataGridViewTextBoxColumn.Name = "shokenCdDataGridViewTextBoxColumn";
            this.shokenCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenWdDataGridViewTextBoxColumn
            // 
            this.shokenWdDataGridViewTextBoxColumn.DataPropertyName = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn.HeaderText = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn.Name = "shokenWdDataGridViewTextBoxColumn";
            this.shokenWdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenWdDataGridViewTextBoxColumn.Visible = false;
            // 
            // juyodoDataGridViewTextBoxColumn
            // 
            this.juyodoDataGridViewTextBoxColumn.DataPropertyName = "Juyodo";
            this.juyodoDataGridViewTextBoxColumn.HeaderText = "Juyodo";
            this.juyodoDataGridViewTextBoxColumn.Name = "juyodoDataGridViewTextBoxColumn";
            this.juyodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.juyodoDataGridViewTextBoxColumn.Visible = false;
            // 
            // handanDataGridViewTextBoxColumn
            // 
            this.handanDataGridViewTextBoxColumn.DataPropertyName = "Handan";
            this.handanDataGridViewTextBoxColumn.HeaderText = "Handan";
            this.handanDataGridViewTextBoxColumn.Name = "handanDataGridViewTextBoxColumn";
            this.handanDataGridViewTextBoxColumn.ReadOnly = true;
            this.handanDataGridViewTextBoxColumn.Visible = false;
            // 
            // hanteiDataGridViewTextBoxColumn
            // 
            this.hanteiDataGridViewTextBoxColumn.DataPropertyName = "Hantei";
            this.hanteiDataGridViewTextBoxColumn.HeaderText = "Hantei";
            this.hanteiDataGridViewTextBoxColumn.Name = "hanteiDataGridViewTextBoxColumn";
            this.hanteiDataGridViewTextBoxColumn.ReadOnly = true;
            this.hanteiDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenBikoDataGridViewTextBoxColumn
            // 
            this.shokenBikoDataGridViewTextBoxColumn.DataPropertyName = "ShokenBiko";
            this.shokenBikoDataGridViewTextBoxColumn.HeaderText = "ShokenBiko";
            this.shokenBikoDataGridViewTextBoxColumn.Name = "shokenBikoDataGridViewTextBoxColumn";
            this.shokenBikoDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenBikoDataGridViewTextBoxColumn.Visible = false;
            // 
            // ShokenJuyodoCol
            // 
            this.ShokenJuyodoCol.DataPropertyName = "ShokenJuyodo";
            this.ShokenJuyodoCol.HeaderText = "ShokenJuyodo";
            this.ShokenJuyodoCol.Name = "ShokenJuyodoCol";
            this.ShokenJuyodoCol.ReadOnly = true;
            this.ShokenJuyodoCol.Visible = false;
            // 
            // ShokenHandanCol
            // 
            this.ShokenHandanCol.DataPropertyName = "ShokenHandan";
            this.ShokenHandanCol.HeaderText = "ShokenHandan";
            this.ShokenHandanCol.Name = "ShokenHandanCol";
            this.ShokenHandanCol.ReadOnly = true;
            this.ShokenHandanCol.Visible = false;
            // 
            // ShokenHanteiCol
            // 
            this.ShokenHanteiCol.DataPropertyName = "ShokenHantei";
            this.ShokenHanteiCol.HeaderText = "ShokenHantei";
            this.ShokenHanteiCol.Name = "ShokenHanteiCol";
            this.ShokenHanteiCol.ReadOnly = true;
            this.ShokenHanteiCol.Visible = false;
            // 
            // TuikaFlgCol
            // 
            this.TuikaFlgCol.HeaderText = "追加";
            this.TuikaFlgCol.Name = "TuikaFlgCol";
            this.TuikaFlgCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TuikaFlgCol.Width = 30;
            // 
            // shokenKbnDataGridViewTextBoxColumn2
            // 
            this.shokenKbnDataGridViewTextBoxColumn2.DataPropertyName = "ShokenKbn";
            this.shokenKbnDataGridViewTextBoxColumn2.HeaderText = "所見区分";
            this.shokenKbnDataGridViewTextBoxColumn2.Name = "shokenKbnDataGridViewTextBoxColumn2";
            this.shokenKbnDataGridViewTextBoxColumn2.ReadOnly = true;
            this.shokenKbnDataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.shokenKbnDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shokenKbnDataGridViewTextBoxColumn2.Width = 80;
            // 
            // shokenCdDataGridViewTextBoxColumn2
            // 
            this.shokenCdDataGridViewTextBoxColumn2.DataPropertyName = "ShokenCd";
            this.shokenCdDataGridViewTextBoxColumn2.HeaderText = "所見CD";
            this.shokenCdDataGridViewTextBoxColumn2.Name = "shokenCdDataGridViewTextBoxColumn2";
            this.shokenCdDataGridViewTextBoxColumn2.ReadOnly = true;
            this.shokenCdDataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.shokenCdDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shokenCdDataGridViewTextBoxColumn2.Width = 80;
            // 
            // shokenWdDataGridViewTextBoxColumn2
            // 
            this.shokenWdDataGridViewTextBoxColumn2.DataPropertyName = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn2.HeaderText = "内容";
            this.shokenWdDataGridViewTextBoxColumn2.Name = "shokenWdDataGridViewTextBoxColumn2";
            this.shokenWdDataGridViewTextBoxColumn2.ReadOnly = true;
            this.shokenWdDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shokenWdDataGridViewTextBoxColumn2.Width = 700;
            // 
            // juyodoDataGridViewTextBoxColumn1
            // 
            this.juyodoDataGridViewTextBoxColumn1.DataPropertyName = "Juyodo";
            this.juyodoDataGridViewTextBoxColumn1.HeaderText = "Juyodo";
            this.juyodoDataGridViewTextBoxColumn1.Name = "juyodoDataGridViewTextBoxColumn1";
            this.juyodoDataGridViewTextBoxColumn1.Visible = false;
            // 
            // handanDataGridViewTextBoxColumn1
            // 
            this.handanDataGridViewTextBoxColumn1.DataPropertyName = "Handan";
            this.handanDataGridViewTextBoxColumn1.HeaderText = "Handan";
            this.handanDataGridViewTextBoxColumn1.Name = "handanDataGridViewTextBoxColumn1";
            this.handanDataGridViewTextBoxColumn1.Visible = false;
            // 
            // hanteiDataGridViewTextBoxColumn1
            // 
            this.hanteiDataGridViewTextBoxColumn1.DataPropertyName = "Hantei";
            this.hanteiDataGridViewTextBoxColumn1.HeaderText = "Hantei";
            this.hanteiDataGridViewTextBoxColumn1.Name = "hanteiDataGridViewTextBoxColumn1";
            this.hanteiDataGridViewTextBoxColumn1.Visible = false;
            // 
            // shokenBikoDataGridViewTextBoxColumn1
            // 
            this.shokenBikoDataGridViewTextBoxColumn1.DataPropertyName = "ShokenBiko";
            this.shokenBikoDataGridViewTextBoxColumn1.HeaderText = "ShokenBiko";
            this.shokenBikoDataGridViewTextBoxColumn1.Name = "shokenBikoDataGridViewTextBoxColumn1";
            this.shokenBikoDataGridViewTextBoxColumn1.Visible = false;
            // 
            // SyokenKekkaSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 563);
            this.Controls.Add(this.sonyuIchiNumTextBox);
            this.Controls.Add(this.checkItemComboBox);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.checkItemCdTextBox);
            this.Controls.Add(this.checkItemNmTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.hosokuDataGridView);
            this.Controls.Add(this.syokenDataGridView);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 200);
            this.Name = "SyokenKekkaSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "項目チェック";
            this.Load += new System.EventHandler(this.SyokenKekkaSelectForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SyokenKekkaSelectForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.syokenDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenKekkaSelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hosokuDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private Zynas.Control.ZDataGridView.ZDataGridView syokenDataGridView;
        private System.Windows.Forms.Label label24;
        private Control.ZTextBox checkItemCdTextBox;
        private Control.ZTextBox checkItemNmTextBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ComboBox checkItemComboBox;
        private Control.ZTextBox sonyuIchiNumTextBox;
        private System.Windows.Forms.Label label1;
        private DataSet.ShokenMstDataSet shokenMstDataSet;
        private System.Windows.Forms.BindingSource shokenKekkaSelectBindingSource;
        private DataSet.ShokenMstDataSetTableAdapters.ShokenKekkaSelectTableAdapter shokenKekkaSelectTableAdapter;
        private Zynas.Control.ZDataGridView.ZDataGridView hosokuDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn syokenKbnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn syokenCdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn syokenWdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn juyodoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanteiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bikoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenWdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn juyodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanteiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenBikoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokenJuyodoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokenHandanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokenHanteiCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TuikaFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenKbnDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCdDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenWdDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn juyodoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn handanDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanteiDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenBikoDataGridViewTextBoxColumn1;
    }
}