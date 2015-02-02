namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class TyumonListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TyumonListForm));
            this.tyumonListDataGridView = new System.Windows.Forms.DataGridView();
            this.TyumonNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyumonDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GyosyaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanbaiTotalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GyoshaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaiChumonNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaiDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaiHdrTblDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yoshiHanbaiHdrTblDataSet = new FukjBizSystem.Application.DataSet.YoshiHanbaiHdrTblDataSet();
            this.torokuButton = new System.Windows.Forms.Button();
            this.tyumonListPanel = new System.Windows.Forms.Panel();
            this.tyumonListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.gyosyaSrhButton = new System.Windows.Forms.Button();
            this.gyosyaNmTextBox = new System.Windows.Forms.TextBox();
            this.gyosyaCdTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.tyumonDtToDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.tyumonDtFromDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tyumonNoToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.tyumonNoFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.ryosyuButton = new System.Windows.Forms.Button();
            this.atenaButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tyumonListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSet)).BeginInit();
            this.tyumonListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tyumonListDataGridView
            // 
            this.tyumonListDataGridView.AllowUserToAddRows = false;
            this.tyumonListDataGridView.AllowUserToDeleteRows = false;
            this.tyumonListDataGridView.AllowUserToResizeRows = false;
            this.tyumonListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tyumonListDataGridView.AutoGenerateColumns = false;
            this.tyumonListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tyumonListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TyumonNoCol,
            this.TyumonDtCol,
            this.GyosyaNmCol,
            this.HanbaiTotalCol,
            this.GyoshaCdCol,
            this.yoshiHanbaiChumonNoDataGridViewTextBoxColumn,
            this.yoshiHanbaiDtDataGridViewTextBoxColumn,
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn,
            this.gyoshaNmDataGridViewTextBoxColumn});
            this.tyumonListDataGridView.DataMember = "YoshiHanbaiHdrTblKensaku";
            this.tyumonListDataGridView.DataSource = this.yoshiHanbaiHdrTblDataSetBindingSource;
            this.tyumonListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.tyumonListDataGridView.MultiSelect = false;
            this.tyumonListDataGridView.Name = "tyumonListDataGridView";
            this.tyumonListDataGridView.ReadOnly = true;
            this.tyumonListDataGridView.RowHeadersVisible = false;
            this.tyumonListDataGridView.RowTemplate.Height = 21;
            this.tyumonListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tyumonListDataGridView.Size = new System.Drawing.Size(1251, 330);
            this.tyumonListDataGridView.TabIndex = 1;
            this.tyumonListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tyumonListDataGridView_CellDoubleClick);
            // 
            // TyumonNoCol
            // 
            this.TyumonNoCol.DataPropertyName = "YoshiHanbaiChumonNo";
            this.TyumonNoCol.HeaderText = "注文番号";
            this.TyumonNoCol.MinimumWidth = 200;
            this.TyumonNoCol.Name = "TyumonNoCol";
            this.TyumonNoCol.ReadOnly = true;
            this.TyumonNoCol.Width = 200;
            // 
            // TyumonDtCol
            // 
            this.TyumonDtCol.DataPropertyName = "YoshiHanbaiDt";
            this.TyumonDtCol.HeaderText = "販売日付";
            this.TyumonDtCol.MinimumWidth = 200;
            this.TyumonDtCol.Name = "TyumonDtCol";
            this.TyumonDtCol.ReadOnly = true;
            this.TyumonDtCol.Width = 200;
            // 
            // GyosyaNmCol
            // 
            this.GyosyaNmCol.DataPropertyName = "GyoshaNm";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.GyosyaNmCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.GyosyaNmCol.HeaderText = "販売先業者名称";
            this.GyosyaNmCol.MinimumWidth = 600;
            this.GyosyaNmCol.Name = "GyosyaNmCol";
            this.GyosyaNmCol.ReadOnly = true;
            this.GyosyaNmCol.Width = 600;
            // 
            // HanbaiTotalCol
            // 
            this.HanbaiTotalCol.DataPropertyName = "YoshiHanbaiGokeiKingaku";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.HanbaiTotalCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.HanbaiTotalCol.HeaderText = "販売合計金額";
            this.HanbaiTotalCol.MinimumWidth = 200;
            this.HanbaiTotalCol.Name = "HanbaiTotalCol";
            this.HanbaiTotalCol.ReadOnly = true;
            this.HanbaiTotalCol.Width = 200;
            // 
            // GyoshaCdCol
            // 
            this.GyoshaCdCol.DataPropertyName = "GyoshaCd";
            this.GyoshaCdCol.HeaderText = "GyoshaCd";
            this.GyoshaCdCol.Name = "GyoshaCdCol";
            this.GyoshaCdCol.ReadOnly = true;
            this.GyoshaCdCol.Visible = false;
            // 
            // yoshiHanbaiChumonNoDataGridViewTextBoxColumn
            // 
            this.yoshiHanbaiChumonNoDataGridViewTextBoxColumn.DataPropertyName = "YoshiHanbaiChumonNo";
            this.yoshiHanbaiChumonNoDataGridViewTextBoxColumn.HeaderText = "YoshiHanbaiChumonNo";
            this.yoshiHanbaiChumonNoDataGridViewTextBoxColumn.Name = "yoshiHanbaiChumonNoDataGridViewTextBoxColumn";
            this.yoshiHanbaiChumonNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.yoshiHanbaiChumonNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoshiHanbaiDtDataGridViewTextBoxColumn
            // 
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.DataPropertyName = "YoshiHanbaiDt";
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.HeaderText = "YoshiHanbaiDt";
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.Name = "yoshiHanbaiDtDataGridViewTextBoxColumn";
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn
            // 
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.DataPropertyName = "YoshiHanbaiGokeiKingaku";
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.HeaderText = "YoshiHanbaiGokeiKingaku";
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.Name = "yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn";
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.ReadOnly = true;
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.Visible = false;
            // 
            // gyoshaNmDataGridViewTextBoxColumn
            // 
            this.gyoshaNmDataGridViewTextBoxColumn.DataPropertyName = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.HeaderText = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.Name = "gyoshaNmDataGridViewTextBoxColumn";
            this.gyoshaNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.gyoshaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoshiHanbaiHdrTblDataSetBindingSource
            // 
            this.yoshiHanbaiHdrTblDataSetBindingSource.DataSource = this.yoshiHanbaiHdrTblDataSet;
            this.yoshiHanbaiHdrTblDataSetBindingSource.Position = 0;
            // 
            // yoshiHanbaiHdrTblDataSet
            // 
            this.yoshiHanbaiHdrTblDataSet.DataSetName = "YoshiHanbaiHdrTblDataSet";
            this.yoshiHanbaiHdrTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // torokuButton
            // 
            this.torokuButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.torokuButton.Location = new System.Drawing.Point(12, 631);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(166, 87);
            this.torokuButton.TabIndex = 3;
            this.torokuButton.Text = "F1:注文入力";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // tyumonListPanel
            // 
            this.tyumonListPanel.Controls.Add(this.tyumonListCountLabel);
            this.tyumonListPanel.Controls.Add(this.label4);
            this.tyumonListPanel.Controls.Add(this.tyumonListDataGridView);
            this.tyumonListPanel.Location = new System.Drawing.Point(12, 268);
            this.tyumonListPanel.Name = "tyumonListPanel";
            this.tyumonListPanel.Size = new System.Drawing.Size(1256, 357);
            this.tyumonListPanel.TabIndex = 2;
            // 
            // tyumonListCountLabel
            // 
            this.tyumonListCountLabel.AutoSize = true;
            this.tyumonListCountLabel.Font = new System.Drawing.Font("Meiryo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tyumonListCountLabel.Location = new System.Drawing.Point(1197, -3);
            this.tyumonListCountLabel.Name = "tyumonListCountLabel";
            this.tyumonListCountLabel.Size = new System.Drawing.Size(36, 24);
            this.tyumonListCountLabel.TabIndex = 0;
            this.tyumonListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(1115, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "検索結果：";
            // 
            // shosaiButton
            // 
            this.shosaiButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shosaiButton.Location = new System.Drawing.Point(184, 631);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(166, 87);
            this.shosaiButton.TabIndex = 4;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.outputButton.Location = new System.Drawing.Point(375, 631);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(166, 87);
            this.outputButton.TabIndex = 5;
            this.outputButton.Text = "F3:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1204, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(52, 40);
            this.viewChangeButton.TabIndex = 9;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(11, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 31);
            this.label19.TabIndex = 3;
            this.label19.Text = "注文番号";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.gyosyaSrhButton);
            this.searchPanel.Controls.Add(this.gyosyaNmTextBox);
            this.searchPanel.Controls.Add(this.gyosyaCdTextBox);
            this.searchPanel.Controls.Add(this.tyumonDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.tyumonDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.tyumonNoToTextBox);
            this.searchPanel.Controls.Add(this.tyumonNoFromTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(12, 78);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1256, 184);
            this.searchPanel.TabIndex = 1;
            // 
            // gyosyaSrhButton
            // 
            this.gyosyaSrhButton.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.gyosyaSrhButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gyosyaSrhButton.Location = new System.Drawing.Point(718, 45);
            this.gyosyaSrhButton.Name = "gyosyaSrhButton";
            this.gyosyaSrhButton.Size = new System.Drawing.Size(30, 33);
            this.gyosyaSrhButton.TabIndex = 2;
            this.gyosyaSrhButton.UseVisualStyleBackColor = true;
            this.gyosyaSrhButton.Click += new System.EventHandler(this.gyosyaSrhButton_Click);
            // 
            // gyosyaNmTextBox
            // 
            this.gyosyaNmTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.gyosyaNmTextBox.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gyosyaNmTextBox.Location = new System.Drawing.Point(187, 42);
            this.gyosyaNmTextBox.Name = "gyosyaNmTextBox";
            this.gyosyaNmTextBox.ReadOnly = true;
            this.gyosyaNmTextBox.Size = new System.Drawing.Size(525, 39);
            this.gyosyaNmTextBox.TabIndex = 1;
            // 
            // gyosyaCdTextBox
            // 
            this.gyosyaCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gyosyaCdTextBox.CustomDigitParts = 0;
            this.gyosyaCdTextBox.CustomFormat = null;
            this.gyosyaCdTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gyosyaCdTextBox.CustomReadOnly = false;
            this.gyosyaCdTextBox.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gyosyaCdTextBox.Location = new System.Drawing.Point(115, 42);
            this.gyosyaCdTextBox.MaxLength = 4;
            this.gyosyaCdTextBox.Name = "gyosyaCdTextBox";
            this.gyosyaCdTextBox.Size = new System.Drawing.Size(66, 39);
            this.gyosyaCdTextBox.TabIndex = 0;
            this.gyosyaCdTextBox.Leave += new System.EventHandler(this.gyosyaCdTextBox_Leave);
            // 
            // tyumonDtToDateTimePicker
            // 
            this.tyumonDtToDateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.tyumonDtToDateTimePicker.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tyumonDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tyumonDtToDateTimePicker.Location = new System.Drawing.Point(352, 132);
            this.tyumonDtToDateTimePicker.Name = "tyumonDtToDateTimePicker";
            this.tyumonDtToDateTimePicker.Size = new System.Drawing.Size(169, 39);
            this.tyumonDtToDateTimePicker.TabIndex = 6;
            // 
            // tyumonDtFromDateTimePicker
            // 
            this.tyumonDtFromDateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.tyumonDtFromDateTimePicker.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tyumonDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tyumonDtFromDateTimePicker.Location = new System.Drawing.Point(116, 132);
            this.tyumonDtFromDateTimePicker.Name = "tyumonDtFromDateTimePicker";
            this.tyumonDtFromDateTimePicker.Size = new System.Drawing.Size(169, 39);
            this.tyumonDtFromDateTimePicker.TabIndex = 5;
            this.tyumonDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.tyumonDtFromDateTimePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(302, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(12, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 31);
            this.label7.TabIndex = 14;
            this.label7.Text = "販売日付";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(12, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "業者";
            // 
            // tyumonNoToTextBox
            // 
            this.tyumonNoToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.tyumonNoToTextBox.CustomDigitParts = 0;
            this.tyumonNoToTextBox.CustomFormat = null;
            this.tyumonNoToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.tyumonNoToTextBox.CustomReadOnly = false;
            this.tyumonNoToTextBox.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tyumonNoToTextBox.Location = new System.Drawing.Point(302, 87);
            this.tyumonNoToTextBox.MaxLength = 10;
            this.tyumonNoToTextBox.Name = "tyumonNoToTextBox";
            this.tyumonNoToTextBox.Size = new System.Drawing.Size(140, 39);
            this.tyumonNoToTextBox.TabIndex = 4;
            // 
            // tyumonNoFromTextBox
            // 
            this.tyumonNoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.tyumonNoFromTextBox.CustomDigitParts = 0;
            this.tyumonNoFromTextBox.CustomFormat = null;
            this.tyumonNoFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.tyumonNoFromTextBox.CustomReadOnly = false;
            this.tyumonNoFromTextBox.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tyumonNoFromTextBox.Location = new System.Drawing.Point(115, 87);
            this.tyumonNoFromTextBox.MaxLength = 10;
            this.tyumonNoFromTextBox.Name = "tyumonNoFromTextBox";
            this.tyumonNoFromTextBox.Size = new System.Drawing.Size(140, 39);
            this.tyumonNoFromTextBox.TabIndex = 3;
            this.tyumonNoFromTextBox.Leave += new System.EventHandler(this.tyumonNoFromTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(261, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(-1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索条件";
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clearButton.Location = new System.Drawing.Point(934, 114);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(150, 57);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kensakuButton.Location = new System.Drawing.Point(1090, 114);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(150, 57);
            this.kensakuButton.TabIndex = 8;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tojiruButton.Location = new System.Drawing.Point(1086, 631);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(166, 87);
            this.tojiruButton.TabIndex = 9;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // ryosyuButton
            // 
            this.ryosyuButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ryosyuButton.Location = new System.Drawing.Point(547, 631);
            this.ryosyuButton.Name = "ryosyuButton";
            this.ryosyuButton.Size = new System.Drawing.Size(166, 87);
            this.ryosyuButton.TabIndex = 6;
            this.ryosyuButton.Text = "F4:領収書出力";
            this.ryosyuButton.UseVisualStyleBackColor = true;
            this.ryosyuButton.Click += new System.EventHandler(this.ryosyuButton_Click);
            // 
            // atenaButton
            // 
            this.atenaButton.Font = new System.Drawing.Font("Meiryo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.atenaButton.Location = new System.Drawing.Point(891, 631);
            this.atenaButton.Name = "atenaButton";
            this.atenaButton.Size = new System.Drawing.Size(166, 87);
            this.atenaButton.TabIndex = 8;
            this.atenaButton.Text = "F6:タックシール・送り状印刷";
            this.atenaButton.UseVisualStyleBackColor = true;
            this.atenaButton.Click += new System.EventHandler(this.atenaButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(2, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 70);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(3, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 72);
            this.label5.TabIndex = 3;
            this.label5.Text = "注文一覧";
            // 
            // TyumonListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 724);
            this.Controls.Add(this.atenaButton);
            this.Controls.Add(this.ryosyuButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.tyumonListPanel);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TyumonListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注文一覧";
            this.Load += new System.EventHandler(this.TyumonListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TyumonListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tyumonListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSet)).EndInit();
            this.tyumonListPanel.ResumeLayout(false);
            this.tyumonListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tyumonListDataGridView;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel tyumonListPanel;
        private System.Windows.Forms.Label tyumonListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Zynas.Control.ZDate tyumonDtFromDateTimePicker;
        private System.Windows.Forms.Label label3;
        private Control.NumberTextBox tyumonNoToTextBox;
        private Control.NumberTextBox tyumonNoFromTextBox;
        private System.Windows.Forms.Label label2;
        private Zynas.Control.ZDate tyumonDtToDateTimePicker;
        private System.Windows.Forms.Button ryosyuButton;
        private System.Windows.Forms.Button atenaButton;
        private System.Windows.Forms.Button gyosyaSrhButton;
        private System.Windows.Forms.TextBox gyosyaNmTextBox;
        private Control.NumberTextBox gyosyaCdTextBox;
        private System.Windows.Forms.BindingSource yoshiHanbaiHdrTblDataSetBindingSource;
        private DataSet.YoshiHanbaiHdrTblDataSet yoshiHanbaiHdrTblDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyumonNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyumonDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GyosyaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanbaiTotalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GyoshaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoshiHanbaiChumonNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoshiHanbaiDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmDataGridViewTextBoxColumn;

    }
}