namespace FukjBizSystem.Application.Boundary.Others
{
    partial class TuckSealListForm
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
            this.listDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.KbnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GyosyaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HokenjoNmCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NengetsuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChikuCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrhBtnCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZipNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdrCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printButton = new System.Windows.Forms.Button();
            this.srhListPanel = new System.Windows.Forms.Panel();
            this.srhListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gyosyaRadioButton = new System.Windows.Forms.RadioButton();
            this.hokenjoRadioButton = new System.Windows.Forms.RadioButton();
            this.settisyaRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.hokenjoComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mikanyuCheckBox = new System.Windows.Forms.CheckBox();
            this.seizoCheckBox = new System.Windows.Forms.CheckBox();
            this.seisoCheckBox = new System.Windows.Forms.CheckBox();
            this.hosyuCheckBox = new System.Windows.Forms.CheckBox();
            this.kojiCheckBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.cdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.cdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.nengetsuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.shichosonRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.printSofujoButton = new System.Windows.Forms.Button();
            this.printPositionComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.printPositionPictureBox = new System.Windows.Forms.PictureBox();
            this.busuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.printAllButton = new System.Windows.Forms.Button();
            this.yoteiMisuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).BeginInit();
            this.srhListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printPositionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listDataGridView
            // 
            this.listDataGridView.AllowUserToDeleteRows = false;
            this.listDataGridView.AllowUserToResizeRows = false;
            this.listDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KbnCol,
            this.GyosyaCdCol,
            this.HokenjoNmCol,
            this.NengetsuCol,
            this.RenbanCol,
            this.ChikuCdCol,
            this.SrhBtnCol,
            this.NmCol,
            this.ZipNoCol,
            this.AdrCol});
            this.listDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.listDataGridView.Location = new System.Drawing.Point(2, 24);
            this.listDataGridView.MultiSelect = false;
            this.listDataGridView.Name = "listDataGridView";
            this.listDataGridView.RowHeadersVisible = false;
            this.listDataGridView.RowTemplate.Height = 21;
            this.listDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listDataGridView.Size = new System.Drawing.Size(1085, 333);
            this.listDataGridView.TabIndex = 2;
            this.listDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDataGridView_CellClick);
            this.listDataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDataGridView_CellLeave);
            this.listDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDataGridView_CellValueChanged);
            this.listDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.listDataGridView_DataError);
            this.listDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.listDataGridView_EditingControlShowing);
            this.listDataGridView.Sorted += new System.EventHandler(this.listDataGridView_Sorted);
            this.listDataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.listDataGridView_UserAddedRow);
            // 
            // KbnCol
            // 
            this.KbnCol.FalseValue = "0";
            this.KbnCol.HeaderText = "印刷";
            this.KbnCol.MinimumWidth = 65;
            this.KbnCol.Name = "KbnCol";
            this.KbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KbnCol.TrueValue = "1";
            this.KbnCol.Width = 65;
            // 
            // GyosyaCdCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.GyosyaCdCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.GyosyaCdCol.HeaderText = "業者コード";
            this.GyosyaCdCol.MaxInputLength = 4;
            this.GyosyaCdCol.MinimumWidth = 80;
            this.GyosyaCdCol.Name = "GyosyaCdCol";
            this.GyosyaCdCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GyosyaCdCol.Width = 80;
            // 
            // HokenjoNmCol
            // 
            this.HokenjoNmCol.HeaderText = "保健所名";
            this.HokenjoNmCol.MinimumWidth = 120;
            this.HokenjoNmCol.Name = "HokenjoNmCol";
            this.HokenjoNmCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HokenjoNmCol.Width = 120;
            // 
            // NengetsuCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NengetsuCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.NengetsuCol.HeaderText = "登録年度";
            this.NengetsuCol.MaxInputLength = 4;
            this.NengetsuCol.MinimumWidth = 70;
            this.NengetsuCol.Name = "NengetsuCol";
            this.NengetsuCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NengetsuCol.Width = 70;
            // 
            // RenbanCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RenbanCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.RenbanCol.HeaderText = "連番";
            this.RenbanCol.MinimumWidth = 60;
            this.RenbanCol.Name = "RenbanCol";
            this.RenbanCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RenbanCol.Width = 60;
            // 
            // ChikuCdCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ChikuCdCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.ChikuCdCol.HeaderText = "地区コード";
            this.ChikuCdCol.MaxInputLength = 5;
            this.ChikuCdCol.MinimumWidth = 80;
            this.ChikuCdCol.Name = "ChikuCdCol";
            this.ChikuCdCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ChikuCdCol.Width = 80;
            // 
            // SrhBtnCol
            // 
            this.SrhBtnCol.DataPropertyName = "SrhBtnCol";
            this.SrhBtnCol.HeaderText = "検索";
            this.SrhBtnCol.MinimumWidth = 65;
            this.SrhBtnCol.Name = "SrhBtnCol";
            this.SrhBtnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SrhBtnCol.Width = 65;
            // 
            // NmCol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NmCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.NmCol.HeaderText = "宛先名称";
            this.NmCol.MaxInputLength = 60;
            this.NmCol.MinimumWidth = 200;
            this.NmCol.Name = "NmCol";
            this.NmCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NmCol.Width = 200;
            // 
            // ZipNoCol
            // 
            this.ZipNoCol.HeaderText = "郵便番号";
            this.ZipNoCol.MaxInputLength = 8;
            this.ZipNoCol.MinimumWidth = 90;
            this.ZipNoCol.Name = "ZipNoCol";
            this.ZipNoCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ZipNoCol.Width = 90;
            // 
            // AdrCol
            // 
            this.AdrCol.HeaderText = "住所";
            this.AdrCol.MaxInputLength = 80;
            this.AdrCol.MinimumWidth = 360;
            this.AdrCol.Name = "AdrCol";
            this.AdrCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AdrCol.Width = 360;
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(593, 543);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(149, 37);
            this.printButton.TabIndex = 6;
            this.printButton.Text = "F1:タックシール印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // srhListPanel
            // 
            this.srhListPanel.Controls.Add(this.srhListCountLabel);
            this.srhListPanel.Controls.Add(this.label4);
            this.srhListPanel.Controls.Add(this.listDataGridView);
            this.srhListPanel.Location = new System.Drawing.Point(1, 166);
            this.srhListPanel.Name = "srhListPanel";
            this.srhListPanel.Size = new System.Drawing.Size(1090, 360);
            this.srhListPanel.TabIndex = 1;
            // 
            // srhListCountLabel
            // 
            this.srhListCountLabel.AutoSize = true;
            this.srhListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.srhListCountLabel.Name = "srhListCountLabel";
            this.srhListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.srhListCountLabel.TabIndex = 1;
            this.srhListCountLabel.Text = "0件";
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
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(880, 543);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 8;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(987, 543);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 9;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(986, 119);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 20;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(879, 120);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 19;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
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
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 16;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "発行区分";
            // 
            // gyosyaRadioButton
            // 
            this.gyosyaRadioButton.AutoSize = true;
            this.gyosyaRadioButton.Checked = true;
            this.gyosyaRadioButton.Location = new System.Drawing.Point(108, 36);
            this.gyosyaRadioButton.Name = "gyosyaRadioButton";
            this.gyosyaRadioButton.Size = new System.Drawing.Size(53, 24);
            this.gyosyaRadioButton.TabIndex = 0;
            this.gyosyaRadioButton.TabStop = true;
            this.gyosyaRadioButton.Text = "業者";
            this.gyosyaRadioButton.UseVisualStyleBackColor = true;
            this.gyosyaRadioButton.CheckedChanged += new System.EventHandler(this.gyosyaRadioButton_CheckedChanged);
            // 
            // hokenjoRadioButton
            // 
            this.hokenjoRadioButton.AutoSize = true;
            this.hokenjoRadioButton.Location = new System.Drawing.Point(167, 36);
            this.hokenjoRadioButton.Name = "hokenjoRadioButton";
            this.hokenjoRadioButton.Size = new System.Drawing.Size(66, 24);
            this.hokenjoRadioButton.TabIndex = 1;
            this.hokenjoRadioButton.Text = "保健所";
            this.hokenjoRadioButton.UseVisualStyleBackColor = true;
            this.hokenjoRadioButton.CheckedChanged += new System.EventHandler(this.hokenjoRadioButton_CheckedChanged);
            // 
            // settisyaRadioButton
            // 
            this.settisyaRadioButton.AutoSize = true;
            this.settisyaRadioButton.Location = new System.Drawing.Point(311, 36);
            this.settisyaRadioButton.Name = "settisyaRadioButton";
            this.settisyaRadioButton.Size = new System.Drawing.Size(66, 24);
            this.settisyaRadioButton.TabIndex = 3;
            this.settisyaRadioButton.Text = "設置者";
            this.settisyaRadioButton.UseVisualStyleBackColor = true;
            this.settisyaRadioButton.CheckedChanged += new System.EventHandler(this.settisyaRadioButton_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "保健所";
            // 
            // hokenjoComboBox
            // 
            this.hokenjoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hokenjoComboBox.FormattingEnabled = true;
            this.hokenjoComboBox.Location = new System.Drawing.Point(108, 66);
            this.hokenjoComboBox.Name = "hokenjoComboBox";
            this.hokenjoComboBox.Size = new System.Drawing.Size(191, 28);
            this.hokenjoComboBox.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "コード";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(198, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "～";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(326, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "登録年度";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.groupBox1);
            this.searchPanel.Controls.Add(this.nameTextBox);
            this.searchPanel.Controls.Add(this.cdToTextBox);
            this.searchPanel.Controls.Add(this.cdFromTextBox);
            this.searchPanel.Controls.Add(this.nengetsuTextBox);
            this.searchPanel.Controls.Add(this.shichosonRadioButton);
            this.searchPanel.Controls.Add(this.label9);
            this.searchPanel.Controls.Add(this.hokenjoComboBox);
            this.searchPanel.Controls.Add(this.label12);
            this.searchPanel.Controls.Add(this.label10);
            this.searchPanel.Controls.Add(this.label11);
            this.searchPanel.Controls.Add(this.settisyaRadioButton);
            this.searchPanel.Controls.Add(this.hokenjoRadioButton);
            this.searchPanel.Controls.Add(this.gyosyaRadioButton);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 166);
            this.searchPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mikanyuCheckBox);
            this.groupBox1.Controls.Add(this.seizoCheckBox);
            this.groupBox1.Controls.Add(this.seisoCheckBox);
            this.groupBox1.Controls.Add(this.hosyuCheckBox);
            this.groupBox1.Controls.Add(this.kojiCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(502, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 84);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会員区分";
            // 
            // mikanyuCheckBox
            // 
            this.mikanyuCheckBox.AutoSize = true;
            this.mikanyuCheckBox.Location = new System.Drawing.Point(17, 56);
            this.mikanyuCheckBox.Name = "mikanyuCheckBox";
            this.mikanyuCheckBox.Size = new System.Drawing.Size(67, 24);
            this.mikanyuCheckBox.TabIndex = 18;
            this.mikanyuCheckBox.Text = "会員外";
            this.mikanyuCheckBox.UseVisualStyleBackColor = true;
            // 
            // seizoCheckBox
            // 
            this.seizoCheckBox.AutoSize = true;
            this.seizoCheckBox.Location = new System.Drawing.Point(17, 26);
            this.seizoCheckBox.Name = "seizoCheckBox";
            this.seizoCheckBox.Size = new System.Drawing.Size(54, 24);
            this.seizoCheckBox.TabIndex = 14;
            this.seizoCheckBox.Text = "製造";
            this.seizoCheckBox.UseVisualStyleBackColor = true;
            // 
            // seisoCheckBox
            // 
            this.seisoCheckBox.AutoSize = true;
            this.seisoCheckBox.Location = new System.Drawing.Point(195, 26);
            this.seisoCheckBox.Name = "seisoCheckBox";
            this.seisoCheckBox.Size = new System.Drawing.Size(54, 24);
            this.seisoCheckBox.TabIndex = 17;
            this.seisoCheckBox.Text = "清掃";
            this.seisoCheckBox.UseVisualStyleBackColor = true;
            // 
            // hosyuCheckBox
            // 
            this.hosyuCheckBox.AutoSize = true;
            this.hosyuCheckBox.Location = new System.Drawing.Point(135, 26);
            this.hosyuCheckBox.Name = "hosyuCheckBox";
            this.hosyuCheckBox.Size = new System.Drawing.Size(54, 24);
            this.hosyuCheckBox.TabIndex = 16;
            this.hosyuCheckBox.Text = "保守";
            this.hosyuCheckBox.UseVisualStyleBackColor = true;
            // 
            // kojiCheckBox
            // 
            this.kojiCheckBox.AutoSize = true;
            this.kojiCheckBox.Location = new System.Drawing.Point(75, 26);
            this.kojiCheckBox.Name = "kojiCheckBox";
            this.kojiCheckBox.Size = new System.Drawing.Size(54, 24);
            this.kojiCheckBox.TabIndex = 15;
            this.kojiCheckBox.Text = "工事";
            this.kojiCheckBox.UseVisualStyleBackColor = true;
            // 
            // nameTextBox
            // 
            this.nameTextBox.AllowDropDown = false;
            this.nameTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.nameTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nameTextBox.CustomReadOnly = false;
            this.nameTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.nameTextBox.Location = new System.Drawing.Point(108, 100);
            this.nameTextBox.MaxLength = 60;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(305, 27);
            this.nameTextBox.TabIndex = 9;
            // 
            // cdToTextBox
            // 
            this.cdToTextBox.AllowDropDown = false;
            this.cdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.cdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.cdToTextBox.CustomReadOnly = false;
            this.cdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cdToTextBox.Location = new System.Drawing.Point(226, 133);
            this.cdToTextBox.MaxLength = 6;
            this.cdToTextBox.Name = "cdToTextBox";
            this.cdToTextBox.Size = new System.Drawing.Size(83, 27);
            this.cdToTextBox.TabIndex = 13;
            this.cdToTextBox.Leave += new System.EventHandler(this.cdToTextBox_Leave);
            // 
            // cdFromTextBox
            // 
            this.cdFromTextBox.AllowDropDown = false;
            this.cdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.cdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.cdFromTextBox.CustomReadOnly = false;
            this.cdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cdFromTextBox.Location = new System.Drawing.Point(109, 133);
            this.cdFromTextBox.MaxLength = 6;
            this.cdFromTextBox.Name = "cdFromTextBox";
            this.cdFromTextBox.Size = new System.Drawing.Size(83, 27);
            this.cdFromTextBox.TabIndex = 11;
            this.cdFromTextBox.Leave += new System.EventHandler(this.cdFromTextBox_Leave);
            // 
            // nengetsuTextBox
            // 
            this.nengetsuTextBox.AllowDropDown = false;
            this.nengetsuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_NENDO;
            this.nengetsuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.nengetsuTextBox.CustomReadOnly = false;
            this.nengetsuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nengetsuTextBox.Location = new System.Drawing.Point(397, 66);
            this.nengetsuTextBox.MaxLength = 4;
            this.nengetsuTextBox.Name = "nengetsuTextBox";
            this.nengetsuTextBox.Size = new System.Drawing.Size(83, 27);
            this.nengetsuTextBox.TabIndex = 7;
            this.nengetsuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // shichosonRadioButton
            // 
            this.shichosonRadioButton.AutoSize = true;
            this.shichosonRadioButton.Location = new System.Drawing.Point(239, 36);
            this.shichosonRadioButton.Name = "shichosonRadioButton";
            this.shichosonRadioButton.Size = new System.Drawing.Size(66, 24);
            this.shichosonRadioButton.TabIndex = 2;
            this.shichosonRadioButton.Text = "市町村";
            this.shichosonRadioButton.UseVisualStyleBackColor = true;
            this.shichosonRadioButton.CheckedChanged += new System.EventHandler(this.shichosonRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "部数";
            // 
            // printSofujoButton
            // 
            this.printSofujoButton.Location = new System.Drawing.Point(748, 543);
            this.printSofujoButton.Name = "printSofujoButton";
            this.printSofujoButton.Size = new System.Drawing.Size(116, 37);
            this.printSofujoButton.TabIndex = 7;
            this.printSofujoButton.Text = "F2:送付状印刷";
            this.printSofujoButton.UseVisualStyleBackColor = true;
            this.printSofujoButton.Click += new System.EventHandler(this.printSofujoButton_Click);
            // 
            // printPositionComboBox
            // 
            this.printPositionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printPositionComboBox.FormattingEnabled = true;
            this.printPositionComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.printPositionComboBox.Location = new System.Drawing.Point(283, 548);
            this.printPositionComboBox.Name = "printPositionComboBox";
            this.printPositionComboBox.Size = new System.Drawing.Size(47, 28);
            this.printPositionComboBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 540);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 40);
            this.label5.TabIndex = 2;
            this.label5.Text = "タックシール\r\n印刷位置";
            // 
            // printPositionPictureBox
            // 
            this.printPositionPictureBox.Image = global::FukjBizSystem.Properties.Resources.PrintPosition;
            this.printPositionPictureBox.InitialImage = global::FukjBizSystem.Properties.Resources.PrintPosition;
            this.printPositionPictureBox.Location = new System.Drawing.Point(110, 529);
            this.printPositionPictureBox.Name = "printPositionPictureBox";
            this.printPositionPictureBox.Size = new System.Drawing.Size(74, 62);
            this.printPositionPictureBox.TabIndex = 167;
            this.printPositionPictureBox.TabStop = false;
            // 
            // busuTextBox
            // 
            this.busuTextBox.AllowDropDown = false;
            this.busuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.busuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.busuTextBox.CustomReadOnly = false;
            this.busuTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.busuTextBox.Location = new System.Drawing.Point(382, 549);
            this.busuTextBox.MaxLength = 2;
            this.busuTextBox.Name = "busuTextBox";
            this.busuTextBox.Size = new System.Drawing.Size(51, 27);
            this.busuTextBox.TabIndex = 5;
            this.busuTextBox.Text = "1";
            this.busuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // printAllButton
            // 
            this.printAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.printAllButton.Location = new System.Drawing.Point(9, 535);
            this.printAllButton.Name = "printAllButton";
            this.printAllButton.Size = new System.Drawing.Size(62, 37);
            this.printAllButton.TabIndex = 1;
            this.printAllButton.Text = "↑ALL";
            this.printAllButton.UseVisualStyleBackColor = false;
            // 
            // yoteiMisuTextBox
            // 
            this.yoteiMisuTextBox.AllowDropDown = false;
            this.yoteiMisuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.yoteiMisuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.yoteiMisuTextBox.CustomReadOnly = false;
            this.yoteiMisuTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.yoteiMisuTextBox.Location = new System.Drawing.Point(526, 548);
            this.yoteiMisuTextBox.MaxLength = 2;
            this.yoteiMisuTextBox.Name = "yoteiMisuTextBox";
            this.yoteiMisuTextBox.ReadOnly = true;
            this.yoteiMisuTextBox.Size = new System.Drawing.Size(51, 27);
            this.yoteiMisuTextBox.TabIndex = 170;
            this.yoteiMisuTextBox.TabStop = false;
            this.yoteiMisuTextBox.Text = "1";
            this.yoteiMisuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 169;
            this.label6.Text = "予定枚数";
            // 
            // TuckSealListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.yoteiMisuTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.printAllButton);
            this.Controls.Add(this.printPositionPictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.printPositionComboBox);
            this.Controls.Add(this.printSofujoButton);
            this.Controls.Add(this.busuTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.srhListPanel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1103, 593);
            this.Name = "TuckSealListForm";
            this.Text = "タックシール・送付状印刷";
            this.Load += new System.EventHandler(this.TuckSealListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TuckSealListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).EndInit();
            this.srhListPanel.ResumeLayout(false);
            this.srhListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printPositionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zynas.Control.ZDataGridView.ZDataGridView listDataGridView;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Panel srhListPanel;
        private System.Windows.Forms.Label srhListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton gyosyaRadioButton;
        private System.Windows.Forms.RadioButton hokenjoRadioButton;
        private System.Windows.Forms.RadioButton settisyaRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox hokenjoComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private FukjBizSystem.Control.ZTextBox busuTextBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn KbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GyosyaCdCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn HokenjoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NengetsuCol;
        private System.Windows.Forms.DataGridViewButtonColumn SrhBtnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdrCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChikuCdCol;
        private System.Windows.Forms.Button printSofujoButton;
        private System.Windows.Forms.ComboBox printPositionComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox printPositionPictureBox;
        private System.Windows.Forms.RadioButton shichosonRadioButton;
        private Control.ZTextBox nengetsuTextBox;
        private Control.ZTextBox nameTextBox;
        private Control.ZTextBox cdToTextBox;
        private Control.ZTextBox cdFromTextBox;
        private System.Windows.Forms.Button printAllButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private Control.ZTextBox yoteiMisuTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox mikanyuCheckBox;
        private System.Windows.Forms.CheckBox seizoCheckBox;
        private System.Windows.Forms.CheckBox seisoCheckBox;
        private System.Windows.Forms.CheckBox hosyuCheckBox;
        private System.Windows.Forms.CheckBox kojiCheckBox;

    }
}