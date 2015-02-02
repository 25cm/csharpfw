namespace FukjBizSystem.Application.Boundary.Master
{
    partial class ShokuinMstListForm
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
            this.OutputButton = new System.Windows.Forms.Button();
            this.TojiruButton = new System.Windows.Forms.Button();
            this.ShosaiButton = new System.Windows.Forms.Button();
            this.TorokuButton = new System.Windows.Forms.Button();
            this.shokuinListPanel = new System.Windows.Forms.Panel();
            this.shokuinListCountLabel = new System.Windows.Forms.Label();
            this.shokuinListDataGridView = new System.Windows.Forms.DataGridView();
            this.shokuinMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shokuinMstDataSet = new FukjBizSystem.Application.DataSet.ShokuinMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.shokuinCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokuinCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokuinKanaTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.shozokuShishoComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shokuinNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.KensakuButton = new System.Windows.Forms.Button();
            this.ShokuinShozokuShishoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinKanaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinSeinengappiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinNyushaDtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinKensainFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShokuinShukeiJogaiFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShokuinTaishokuDtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinTaishokuFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShokuinPasswordCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinInjiJunCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinShozokuShishoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinKanaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinSeinengappiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokuinKensainFlg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinTaishokuFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinPasswordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinInjiJunDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokuinListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokuinListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokuinMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokuinMstDataSet)).BeginInit();
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
            // shokuinListPanel
            // 
            this.shokuinListPanel.Controls.Add(this.shokuinListCountLabel);
            this.shokuinListPanel.Controls.Add(this.shokuinListDataGridView);
            this.shokuinListPanel.Controls.Add(this.label4);
            this.shokuinListPanel.Location = new System.Drawing.Point(0, 183);
            this.shokuinListPanel.Name = "shokuinListPanel";
            this.shokuinListPanel.Size = new System.Drawing.Size(1103, 368);
            this.shokuinListPanel.TabIndex = 12;
            // 
            // shokuinListCountLabel
            // 
            this.shokuinListCountLabel.AutoSize = true;
            this.shokuinListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.shokuinListCountLabel.Name = "shokuinListCountLabel";
            this.shokuinListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.shokuinListCountLabel.TabIndex = 1;
            this.shokuinListCountLabel.Text = "0件";
            // 
            // shokuinListDataGridView
            // 
            this.shokuinListDataGridView.AllowUserToAddRows = false;
            this.shokuinListDataGridView.AllowUserToDeleteRows = false;
            this.shokuinListDataGridView.AllowUserToResizeRows = false;
            this.shokuinListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shokuinListDataGridView.AutoGenerateColumns = false;
            this.shokuinListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shokuinListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShokuinShozokuShishoCdCol,
            this.ShishoNmCol,
            this.ShokuinCdCol,
            this.ShokuinNmCol,
            this.ShokuinKanaCol,
            this.ShokuinSeinengappiCol,
            this.ShokuinNyushaDtColumn,
            this.ShokuinKensainFlgCol,
            this.ShokuinShukeiJogaiFlgCol,
            this.ShokuinTaishokuDtColumn,
            this.ShokuinTaishokuFlgCol,
            this.ShokuinPasswordCol,
            this.ShokuinInjiJunCol,
            this.shokuinCdDataGridViewTextBoxColumn,
            this.shokuinShozokuShishoCdDataGridViewTextBoxColumn,
            this.shokuinNmDataGridViewTextBoxColumn,
            this.shokuinKanaDataGridViewTextBoxColumn,
            this.shokuinSeinengappiDataGridViewTextBoxColumn,
            this.ShokuinKensainFlg,
            this.shokuinTaishokuFlgDataGridViewTextBoxColumn,
            this.shokuinPasswordDataGridViewTextBoxColumn,
            this.shokuinInjiJunDataGridViewTextBoxColumn,
            this.shishoNmDataGridViewTextBoxColumn});
            this.shokuinListDataGridView.DataMember = "ShokuinMstKensaku";
            this.shokuinListDataGridView.DataSource = this.shokuinMstDataSetBindingSource;
            this.shokuinListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.shokuinListDataGridView.MultiSelect = false;
            this.shokuinListDataGridView.Name = "shokuinListDataGridView";
            this.shokuinListDataGridView.RowHeadersVisible = false;
            this.shokuinListDataGridView.RowTemplate.Height = 21;
            this.shokuinListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shokuinListDataGridView.Size = new System.Drawing.Size(1100, 342);
            this.shokuinListDataGridView.TabIndex = 2;
            this.shokuinListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shokuinListDataGridView_CellDoubleClick);
            this.shokuinListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shokuinListDataGridView_DataError);
            // 
            // shokuinMstDataSetBindingSource
            // 
            this.shokuinMstDataSetBindingSource.DataSource = this.shokuinMstDataSet;
            this.shokuinMstDataSetBindingSource.Position = 0;
            // 
            // shokuinMstDataSet
            // 
            this.shokuinMstDataSet.DataSetName = "ShokuinMstDataSet";
            this.shokuinMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.shokuinCdToTextBox);
            this.searchPanel.Controls.Add(this.shokuinCdFromTextBox);
            this.searchPanel.Controls.Add(this.shokuinKanaTextBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.shozokuShishoComboBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.shokuinNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.ViewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.ClearButton);
            this.searchPanel.Controls.Add(this.KensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 184);
            this.searchPanel.TabIndex = 11;
            // 
            // shokuinCdToTextBox
            // 
            this.shokuinCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokuinCdToTextBox.CustomDigitParts = 0;
            this.shokuinCdToTextBox.CustomFormat = null;
            this.shokuinCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokuinCdToTextBox.CustomReadOnly = false;
            this.shokuinCdToTextBox.Location = new System.Drawing.Point(181, 70);
            this.shokuinCdToTextBox.MaxLength = 3;
            this.shokuinCdToTextBox.Name = "shokuinCdToTextBox";
            this.shokuinCdToTextBox.Size = new System.Drawing.Size(50, 27);
            this.shokuinCdToTextBox.TabIndex = 6;
            this.shokuinCdToTextBox.Leave += new System.EventHandler(this.shokuinCdToTextBox_Leave);
            // 
            // shokuinCdFromTextBox
            // 
            this.shokuinCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokuinCdFromTextBox.CustomDigitParts = 0;
            this.shokuinCdFromTextBox.CustomFormat = null;
            this.shokuinCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokuinCdFromTextBox.CustomReadOnly = false;
            this.shokuinCdFromTextBox.Location = new System.Drawing.Point(96, 70);
            this.shokuinCdFromTextBox.MaxLength = 3;
            this.shokuinCdFromTextBox.Name = "shokuinCdFromTextBox";
            this.shokuinCdFromTextBox.Size = new System.Drawing.Size(50, 27);
            this.shokuinCdFromTextBox.TabIndex = 4;
            this.shokuinCdFromTextBox.Leave += new System.EventHandler(this.shokuinCdFromTextBox_Leave);
            // 
            // shokuinKanaTextBox
            // 
            this.shokuinKanaTextBox.Location = new System.Drawing.Point(96, 136);
            this.shokuinKanaTextBox.MaxLength = 20;
            this.shokuinKanaTextBox.Name = "shokuinKanaTextBox";
            this.shokuinKanaTextBox.Size = new System.Drawing.Size(321, 27);
            this.shokuinKanaTextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "職員名カナ";
            // 
            // shozokuShishoComboBox
            // 
            this.shozokuShishoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shozokuShishoComboBox.FormattingEnabled = true;
            this.shozokuShishoComboBox.Location = new System.Drawing.Point(96, 36);
            this.shozokuShishoComboBox.Name = "shozokuShishoComboBox";
            this.shozokuShishoComboBox.Size = new System.Drawing.Size(135, 28);
            this.shozokuShishoComboBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "所属支所";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // shokuinNmTextBox
            // 
            this.shokuinNmTextBox.Location = new System.Drawing.Point(96, 103);
            this.shokuinNmTextBox.MaxLength = 20;
            this.shokuinNmTextBox.Name = "shokuinNmTextBox";
            this.shokuinNmTextBox.Size = new System.Drawing.Size(321, 27);
            this.shokuinNmTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "職員名";
            // 
            // ViewChangeButton
            // 
            this.ViewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.ViewChangeButton.Name = "ViewChangeButton";
            this.ViewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.ViewChangeButton.TabIndex = 13;
            this.ViewChangeButton.Text = "▲";
            this.ViewChangeButton.UseVisualStyleBackColor = true;
            this.ViewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "職員コード";
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
            this.ClearButton.Location = new System.Drawing.Point(884, 141);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(101, 37);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "F7:クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // KensakuButton
            // 
            this.KensakuButton.Location = new System.Drawing.Point(991, 140);
            this.KensakuButton.Name = "KensakuButton";
            this.KensakuButton.Size = new System.Drawing.Size(101, 37);
            this.KensakuButton.TabIndex = 12;
            this.KensakuButton.Text = "F8:検索";
            this.KensakuButton.UseVisualStyleBackColor = true;
            this.KensakuButton.Click += new System.EventHandler(this.KensakuButton_Click);
            // 
            // ShokuinShozokuShishoCdCol
            // 
            this.ShokuinShozokuShishoCdCol.DataPropertyName = "ShokuinShozokuShishoCd";
            this.ShokuinShozokuShishoCdCol.HeaderText = "所属支所コード";
            this.ShokuinShozokuShishoCdCol.MinimumWidth = 150;
            this.ShokuinShozokuShishoCdCol.Name = "ShokuinShozokuShishoCdCol";
            this.ShokuinShozokuShishoCdCol.ReadOnly = true;
            this.ShokuinShozokuShishoCdCol.Width = 150;
            // 
            // ShishoNmCol
            // 
            this.ShishoNmCol.DataPropertyName = "ShishoNm";
            this.ShishoNmCol.HeaderText = "所属支所名称";
            this.ShishoNmCol.MinimumWidth = 150;
            this.ShishoNmCol.Name = "ShishoNmCol";
            this.ShishoNmCol.ReadOnly = true;
            this.ShishoNmCol.Width = 150;
            // 
            // ShokuinCdCol
            // 
            this.ShokuinCdCol.DataPropertyName = "ShokuinCd";
            this.ShokuinCdCol.HeaderText = "職員コード";
            this.ShokuinCdCol.MinimumWidth = 100;
            this.ShokuinCdCol.Name = "ShokuinCdCol";
            this.ShokuinCdCol.ReadOnly = true;
            // 
            // ShokuinNmCol
            // 
            this.ShokuinNmCol.DataPropertyName = "ShokuinNm";
            this.ShokuinNmCol.HeaderText = "職員名";
            this.ShokuinNmCol.MinimumWidth = 100;
            this.ShokuinNmCol.Name = "ShokuinNmCol";
            this.ShokuinNmCol.ReadOnly = true;
            // 
            // ShokuinKanaCol
            // 
            this.ShokuinKanaCol.DataPropertyName = "ShokuinKana";
            this.ShokuinKanaCol.HeaderText = "職員名カナ";
            this.ShokuinKanaCol.MinimumWidth = 100;
            this.ShokuinKanaCol.Name = "ShokuinKanaCol";
            this.ShokuinKanaCol.ReadOnly = true;
            // 
            // ShokuinSeinengappiCol
            // 
            this.ShokuinSeinengappiCol.DataPropertyName = "ShokuinSeinengappi";
            this.ShokuinSeinengappiCol.HeaderText = "生年月日";
            this.ShokuinSeinengappiCol.MinimumWidth = 100;
            this.ShokuinSeinengappiCol.Name = "ShokuinSeinengappiCol";
            this.ShokuinSeinengappiCol.ReadOnly = true;
            // 
            // ShokuinNyushaDtColumn
            // 
            this.ShokuinNyushaDtColumn.DataPropertyName = "ShokuinNyushaDt";
            this.ShokuinNyushaDtColumn.HeaderText = "入社日付";
            this.ShokuinNyushaDtColumn.MinimumWidth = 100;
            this.ShokuinNyushaDtColumn.Name = "ShokuinNyushaDtColumn";
            this.ShokuinNyushaDtColumn.ReadOnly = true;
            // 
            // ShokuinKensainFlgCol
            // 
            this.ShokuinKensainFlgCol.DataPropertyName = "ShokuinKensainFlg";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "0";
            this.ShokuinKensainFlgCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShokuinKensainFlgCol.FalseValue = "0";
            this.ShokuinKensainFlgCol.HeaderText = "検査員フラグ";
            this.ShokuinKensainFlgCol.MinimumWidth = 100;
            this.ShokuinKensainFlgCol.Name = "ShokuinKensainFlgCol";
            this.ShokuinKensainFlgCol.ReadOnly = true;
            this.ShokuinKensainFlgCol.TrueValue = "1";
            // 
            // ShokuinShukeiJogaiFlgCol
            // 
            this.ShokuinShukeiJogaiFlgCol.DataPropertyName = "ShokuinShukeiJogaiFlg";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "0";
            this.ShokuinShukeiJogaiFlgCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.ShokuinShukeiJogaiFlgCol.FalseValue = "0";
            this.ShokuinShukeiJogaiFlgCol.HeaderText = "検査員月報役職フラグ";
            this.ShokuinShukeiJogaiFlgCol.MinimumWidth = 100;
            this.ShokuinShukeiJogaiFlgCol.Name = "ShokuinShukeiJogaiFlgCol";
            this.ShokuinShukeiJogaiFlgCol.ReadOnly = true;
            this.ShokuinShukeiJogaiFlgCol.TrueValue = "1";
            // 
            // ShokuinTaishokuDtColumn
            // 
            this.ShokuinTaishokuDtColumn.DataPropertyName = "ShokuinTaishokuDt";
            this.ShokuinTaishokuDtColumn.HeaderText = "退職日付";
            this.ShokuinTaishokuDtColumn.MinimumWidth = 100;
            this.ShokuinTaishokuDtColumn.Name = "ShokuinTaishokuDtColumn";
            this.ShokuinTaishokuDtColumn.ReadOnly = true;
            // 
            // ShokuinTaishokuFlgCol
            // 
            this.ShokuinTaishokuFlgCol.DataPropertyName = "ShokuinTaishokuFlg";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "0";
            this.ShokuinTaishokuFlgCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.ShokuinTaishokuFlgCol.FalseValue = "0";
            this.ShokuinTaishokuFlgCol.HeaderText = "退職フラグ";
            this.ShokuinTaishokuFlgCol.MinimumWidth = 100;
            this.ShokuinTaishokuFlgCol.Name = "ShokuinTaishokuFlgCol";
            this.ShokuinTaishokuFlgCol.ReadOnly = true;
            this.ShokuinTaishokuFlgCol.TrueValue = "1";
            // 
            // ShokuinPasswordCol
            // 
            this.ShokuinPasswordCol.DataPropertyName = "ShokuinPassword";
            this.ShokuinPasswordCol.HeaderText = "パスワード";
            this.ShokuinPasswordCol.MinimumWidth = 100;
            this.ShokuinPasswordCol.Name = "ShokuinPasswordCol";
            this.ShokuinPasswordCol.ReadOnly = true;
            // 
            // ShokuinInjiJunCol
            // 
            this.ShokuinInjiJunCol.DataPropertyName = "ShokuinInjiJun";
            this.ShokuinInjiJunCol.HeaderText = "印字順";
            this.ShokuinInjiJunCol.MinimumWidth = 100;
            this.ShokuinInjiJunCol.Name = "ShokuinInjiJunCol";
            this.ShokuinInjiJunCol.ReadOnly = true;
            // 
            // shokuinCdDataGridViewTextBoxColumn
            // 
            this.shokuinCdDataGridViewTextBoxColumn.DataPropertyName = "ShokuinCd";
            this.shokuinCdDataGridViewTextBoxColumn.HeaderText = "ShokuinCd";
            this.shokuinCdDataGridViewTextBoxColumn.Name = "shokuinCdDataGridViewTextBoxColumn";
            this.shokuinCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokuinShozokuShishoCdDataGridViewTextBoxColumn
            // 
            this.shokuinShozokuShishoCdDataGridViewTextBoxColumn.DataPropertyName = "ShokuinShozokuShishoCd";
            this.shokuinShozokuShishoCdDataGridViewTextBoxColumn.HeaderText = "ShokuinShozokuShishoCd";
            this.shokuinShozokuShishoCdDataGridViewTextBoxColumn.Name = "shokuinShozokuShishoCdDataGridViewTextBoxColumn";
            this.shokuinShozokuShishoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokuinNmDataGridViewTextBoxColumn
            // 
            this.shokuinNmDataGridViewTextBoxColumn.DataPropertyName = "ShokuinNm";
            this.shokuinNmDataGridViewTextBoxColumn.HeaderText = "ShokuinNm";
            this.shokuinNmDataGridViewTextBoxColumn.Name = "shokuinNmDataGridViewTextBoxColumn";
            this.shokuinNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokuinKanaDataGridViewTextBoxColumn
            // 
            this.shokuinKanaDataGridViewTextBoxColumn.DataPropertyName = "ShokuinKana";
            this.shokuinKanaDataGridViewTextBoxColumn.HeaderText = "ShokuinKana";
            this.shokuinKanaDataGridViewTextBoxColumn.Name = "shokuinKanaDataGridViewTextBoxColumn";
            this.shokuinKanaDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokuinSeinengappiDataGridViewTextBoxColumn
            // 
            this.shokuinSeinengappiDataGridViewTextBoxColumn.DataPropertyName = "ShokuinSeinengappi";
            this.shokuinSeinengappiDataGridViewTextBoxColumn.HeaderText = "ShokuinSeinengappi";
            this.shokuinSeinengappiDataGridViewTextBoxColumn.Name = "shokuinSeinengappiDataGridViewTextBoxColumn";
            this.shokuinSeinengappiDataGridViewTextBoxColumn.Visible = false;
            // 
            // ShokuinKensainFlg
            // 
            this.ShokuinKensainFlg.DataPropertyName = "ShokuinKensainFlg";
            this.ShokuinKensainFlg.HeaderText = "ShokuinKensainFlg";
            this.ShokuinKensainFlg.Name = "ShokuinKensainFlg";
            this.ShokuinKensainFlg.Visible = false;
            // 
            // shokuinTaishokuFlgDataGridViewTextBoxColumn
            // 
            this.shokuinTaishokuFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokuinTaishokuFlg";
            this.shokuinTaishokuFlgDataGridViewTextBoxColumn.HeaderText = "ShokuinTaishokuFlg";
            this.shokuinTaishokuFlgDataGridViewTextBoxColumn.Name = "shokuinTaishokuFlgDataGridViewTextBoxColumn";
            this.shokuinTaishokuFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokuinPasswordDataGridViewTextBoxColumn
            // 
            this.shokuinPasswordDataGridViewTextBoxColumn.DataPropertyName = "ShokuinPassword";
            this.shokuinPasswordDataGridViewTextBoxColumn.HeaderText = "ShokuinPassword";
            this.shokuinPasswordDataGridViewTextBoxColumn.Name = "shokuinPasswordDataGridViewTextBoxColumn";
            this.shokuinPasswordDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokuinInjiJunDataGridViewTextBoxColumn
            // 
            this.shokuinInjiJunDataGridViewTextBoxColumn.DataPropertyName = "ShokuinInjiJun";
            this.shokuinInjiJunDataGridViewTextBoxColumn.HeaderText = "ShokuinInjiJun";
            this.shokuinInjiJunDataGridViewTextBoxColumn.Name = "shokuinInjiJunDataGridViewTextBoxColumn";
            this.shokuinInjiJunDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoNmDataGridViewTextBoxColumn
            // 
            this.shishoNmDataGridViewTextBoxColumn.DataPropertyName = "ShishoNm";
            this.shishoNmDataGridViewTextBoxColumn.HeaderText = "ShishoNm";
            this.shishoNmDataGridViewTextBoxColumn.Name = "shishoNmDataGridViewTextBoxColumn";
            this.shishoNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // ShokuinMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.TojiruButton);
            this.Controls.Add(this.ShosaiButton);
            this.Controls.Add(this.TorokuButton);
            this.Controls.Add(this.shokuinListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShokuinMstListForm";
            this.Text = "職員マスタ検索";
            this.Load += new System.EventHandler(this.ShokuinMstList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShokuinMstList_KeyDown);
            this.shokuinListPanel.ResumeLayout(false);
            this.shokuinListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokuinListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokuinMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokuinMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.Button TojiruButton;
        private System.Windows.Forms.Button ShosaiButton;
        private System.Windows.Forms.Button TorokuButton;
        private System.Windows.Forms.Panel shokuinListPanel;
        private System.Windows.Forms.Label shokuinListCountLabel;
        private System.Windows.Forms.DataGridView shokuinListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shokuinNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ViewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button KensakuButton;
        private System.Windows.Forms.ComboBox shozokuShishoComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox shokuinKanaTextBox;
        private System.Windows.Forms.Label label7;
        private Control.NumberTextBox shokuinCdToTextBox;
        private Control.NumberTextBox shokuinCdFromTextBox;
        private System.Windows.Forms.BindingSource shokuinMstDataSetBindingSource;
        private DataSet.ShokuinMstDataSet shokuinMstDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinShozokuShishoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinKanaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinSeinengappiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinNyushaDtColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShokuinKensainFlgCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShokuinShukeiJogaiFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinTaishokuDtColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShokuinTaishokuFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinPasswordCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinInjiJunCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinShozokuShishoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinKanaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinSeinengappiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokuinKensainFlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinTaishokuFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinPasswordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokuinInjiJunDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoNmDataGridViewTextBoxColumn;

    }
}