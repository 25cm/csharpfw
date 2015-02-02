namespace FukjBizSystem.Application.Boundary.Master
{
    partial class ShokenMstListForm
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
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.shokenMstListPanel = new System.Windows.Forms.Panel();
            this.shokenMstListCountLabel = new System.Windows.Forms.Label();
            this.shokenMstListDataGridView = new System.Windows.Forms.DataGridView();
            this.shokenKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenJuyodoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHandanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenWdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokenWdRyakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHanteiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenBikoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHokokuLevelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenShitekiKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenShitekiNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCheckNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShokenFollowFlgCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenJuyodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHandanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenWdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHanteiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenBikoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHokokuLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenShitekiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenShitekiNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenDojiCheckKomokuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shokenMstDataSet = new FukjBizSystem.Application.DataSet.ShokenMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.shokenCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokenCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokenKbnTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokenShitekiKbnComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gaikankensaKomokuNmComboBox = new System.Windows.Forms.ComboBox();
            this.shokenJuyodoComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.shokenMstListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(860, 555);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 4;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(994, 555);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(726, 555);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 3;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(586, 555);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:新規登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // shokenMstListPanel
            // 
            this.shokenMstListPanel.Controls.Add(this.shokenMstListCountLabel);
            this.shokenMstListPanel.Controls.Add(this.shokenMstListDataGridView);
            this.shokenMstListPanel.Controls.Add(this.label4);
            this.shokenMstListPanel.Location = new System.Drawing.Point(0, 176);
            this.shokenMstListPanel.Name = "shokenMstListPanel";
            this.shokenMstListPanel.Size = new System.Drawing.Size(1103, 375);
            this.shokenMstListPanel.TabIndex = 1;
            // 
            // shokenMstListCountLabel
            // 
            this.shokenMstListCountLabel.AutoSize = true;
            this.shokenMstListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.shokenMstListCountLabel.Name = "shokenMstListCountLabel";
            this.shokenMstListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.shokenMstListCountLabel.TabIndex = 72;
            this.shokenMstListCountLabel.Text = "0件";
            // 
            // shokenMstListDataGridView
            // 
            this.shokenMstListDataGridView.AllowUserToAddRows = false;
            this.shokenMstListDataGridView.AllowUserToDeleteRows = false;
            this.shokenMstListDataGridView.AllowUserToResizeRows = false;
            this.shokenMstListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shokenMstListDataGridView.AutoGenerateColumns = false;
            this.shokenMstListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shokenMstListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shokenKbnCol,
            this.shokenCdCol,
            this.shokenJuyodoCol,
            this.shokenHandanCol,
            this.shokenWdCol,
            this.ShokenWdRyakuCol,
            this.shokenHanteiCol,
            this.shokenBikoCol,
            this.shokenHokokuLevelCol,
            this.shokenShitekiKbnCol,
            this.shokenShitekiNoCol,
            this.shokenCheckNoCol,
            this.ShokenFollowFlgCol,
            this.shokenKbnDataGridViewTextBoxColumn,
            this.shokenCdDataGridViewTextBoxColumn,
            this.shokenJuyodoDataGridViewTextBoxColumn,
            this.shokenHandanDataGridViewTextBoxColumn,
            this.shokenWdDataGridViewTextBoxColumn,
            this.shokenHanteiDataGridViewTextBoxColumn,
            this.shokenBikoDataGridViewTextBoxColumn,
            this.shokenHokokuLevelDataGridViewTextBoxColumn,
            this.shokenShitekiKbnDataGridViewTextBoxColumn,
            this.shokenShitekiNoDataGridViewTextBoxColumn,
            this.shokenDojiCheckKomokuDataGridViewTextBoxColumn});
            this.shokenMstListDataGridView.DataMember = "ShokenMstKensaku";
            this.shokenMstListDataGridView.DataSource = this.shokenMstDataSetBindingSource;
            this.shokenMstListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.shokenMstListDataGridView.MultiSelect = false;
            this.shokenMstListDataGridView.Name = "shokenMstListDataGridView";
            this.shokenMstListDataGridView.ReadOnly = true;
            this.shokenMstListDataGridView.RowHeadersVisible = false;
            this.shokenMstListDataGridView.RowTemplate.Height = 21;
            this.shokenMstListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shokenMstListDataGridView.Size = new System.Drawing.Size(1100, 349);
            this.shokenMstListDataGridView.TabIndex = 6;
            this.shokenMstListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shokenMstListDataGridView_CellDoubleClick);
            // 
            // shokenKbnCol
            // 
            this.shokenKbnCol.DataPropertyName = "ShokenKbn";
            this.shokenKbnCol.HeaderText = "所見区分";
            this.shokenKbnCol.MinimumWidth = 100;
            this.shokenKbnCol.Name = "shokenKbnCol";
            this.shokenKbnCol.ReadOnly = true;
            // 
            // shokenCdCol
            // 
            this.shokenCdCol.DataPropertyName = "ShokenCd";
            this.shokenCdCol.HeaderText = "所見コード";
            this.shokenCdCol.MinimumWidth = 100;
            this.shokenCdCol.Name = "shokenCdCol";
            this.shokenCdCol.ReadOnly = true;
            // 
            // shokenJuyodoCol
            // 
            this.shokenJuyodoCol.DataPropertyName = "ShokenJuyodo";
            this.shokenJuyodoCol.HeaderText = "重要度";
            this.shokenJuyodoCol.MinimumWidth = 80;
            this.shokenJuyodoCol.Name = "shokenJuyodoCol";
            this.shokenJuyodoCol.ReadOnly = true;
            this.shokenJuyodoCol.Width = 80;
            // 
            // shokenHandanCol
            // 
            this.shokenHandanCol.DataPropertyName = "ShokenHandan";
            this.shokenHandanCol.HeaderText = "判断";
            this.shokenHandanCol.MinimumWidth = 80;
            this.shokenHandanCol.Name = "shokenHandanCol";
            this.shokenHandanCol.ReadOnly = true;
            this.shokenHandanCol.Width = 80;
            // 
            // shokenWdCol
            // 
            this.shokenWdCol.DataPropertyName = "ShokenWd";
            this.shokenWdCol.HeaderText = "所見文章";
            this.shokenWdCol.MinimumWidth = 100;
            this.shokenWdCol.Name = "shokenWdCol";
            this.shokenWdCol.ReadOnly = true;
            // 
            // ShokenWdRyakuCol
            // 
            this.ShokenWdRyakuCol.DataPropertyName = "ShokenWdRyaku";
            this.ShokenWdRyakuCol.HeaderText = "所見略文";
            this.ShokenWdRyakuCol.MinimumWidth = 80;
            this.ShokenWdRyakuCol.Name = "ShokenWdRyakuCol";
            this.ShokenWdRyakuCol.ReadOnly = true;
            this.ShokenWdRyakuCol.Width = 80;
            // 
            // shokenHanteiCol
            // 
            this.shokenHanteiCol.DataPropertyName = "ShokenHantei";
            this.shokenHanteiCol.HeaderText = "判定";
            this.shokenHanteiCol.MinimumWidth = 100;
            this.shokenHanteiCol.Name = "shokenHanteiCol";
            this.shokenHanteiCol.ReadOnly = true;
            // 
            // shokenBikoCol
            // 
            this.shokenBikoCol.DataPropertyName = "ShokenBiko";
            this.shokenBikoCol.HeaderText = "備考";
            this.shokenBikoCol.MinimumWidth = 100;
            this.shokenBikoCol.Name = "shokenBikoCol";
            this.shokenBikoCol.ReadOnly = true;
            // 
            // shokenHokokuLevelCol
            // 
            this.shokenHokokuLevelCol.DataPropertyName = "ShokenHokokuLevel";
            this.shokenHokokuLevelCol.HeaderText = "行政報告レベル";
            this.shokenHokokuLevelCol.MinimumWidth = 90;
            this.shokenHokokuLevelCol.Name = "shokenHokokuLevelCol";
            this.shokenHokokuLevelCol.ReadOnly = true;
            this.shokenHokokuLevelCol.Width = 90;
            // 
            // shokenShitekiKbnCol
            // 
            this.shokenShitekiKbnCol.DataPropertyName = "ShokenShitekiKbn";
            this.shokenShitekiKbnCol.HeaderText = "指摘区分";
            this.shokenShitekiKbnCol.MinimumWidth = 100;
            this.shokenShitekiKbnCol.Name = "shokenShitekiKbnCol";
            this.shokenShitekiKbnCol.ReadOnly = true;
            // 
            // shokenShitekiNoCol
            // 
            this.shokenShitekiNoCol.DataPropertyName = "ShokenShitekiNo";
            this.shokenShitekiNoCol.HeaderText = "指摘箇所No";
            this.shokenShitekiNoCol.MinimumWidth = 100;
            this.shokenShitekiNoCol.Name = "shokenShitekiNoCol";
            this.shokenShitekiNoCol.ReadOnly = true;
            // 
            // shokenCheckNoCol
            // 
            this.shokenCheckNoCol.DataPropertyName = "ShokenDojiCheckKomoku";
            this.shokenCheckNoCol.HeaderText = "チェック番号";
            this.shokenCheckNoCol.MinimumWidth = 90;
            this.shokenCheckNoCol.Name = "shokenCheckNoCol";
            this.shokenCheckNoCol.ReadOnly = true;
            this.shokenCheckNoCol.Width = 90;
            // 
            // ShokenFollowFlgCol
            // 
            this.ShokenFollowFlgCol.DataPropertyName = "ShokenFollowFlg";
            this.ShokenFollowFlgCol.HeaderText = "フォロー対象フラグ";
            this.ShokenFollowFlgCol.MinimumWidth = 100;
            this.ShokenFollowFlgCol.Name = "ShokenFollowFlgCol";
            this.ShokenFollowFlgCol.ReadOnly = true;
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
            // shokenJuyodoDataGridViewTextBoxColumn
            // 
            this.shokenJuyodoDataGridViewTextBoxColumn.DataPropertyName = "ShokenJuyodo";
            this.shokenJuyodoDataGridViewTextBoxColumn.HeaderText = "ShokenJuyodo";
            this.shokenJuyodoDataGridViewTextBoxColumn.Name = "shokenJuyodoDataGridViewTextBoxColumn";
            this.shokenJuyodoDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenJuyodoDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenHandanDataGridViewTextBoxColumn
            // 
            this.shokenHandanDataGridViewTextBoxColumn.DataPropertyName = "ShokenHandan";
            this.shokenHandanDataGridViewTextBoxColumn.HeaderText = "ShokenHandan";
            this.shokenHandanDataGridViewTextBoxColumn.Name = "shokenHandanDataGridViewTextBoxColumn";
            this.shokenHandanDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenHandanDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenWdDataGridViewTextBoxColumn
            // 
            this.shokenWdDataGridViewTextBoxColumn.DataPropertyName = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn.HeaderText = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn.Name = "shokenWdDataGridViewTextBoxColumn";
            this.shokenWdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenWdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenHanteiDataGridViewTextBoxColumn
            // 
            this.shokenHanteiDataGridViewTextBoxColumn.DataPropertyName = "ShokenHantei";
            this.shokenHanteiDataGridViewTextBoxColumn.HeaderText = "ShokenHantei";
            this.shokenHanteiDataGridViewTextBoxColumn.Name = "shokenHanteiDataGridViewTextBoxColumn";
            this.shokenHanteiDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenHanteiDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenBikoDataGridViewTextBoxColumn
            // 
            this.shokenBikoDataGridViewTextBoxColumn.DataPropertyName = "ShokenBiko";
            this.shokenBikoDataGridViewTextBoxColumn.HeaderText = "ShokenBiko";
            this.shokenBikoDataGridViewTextBoxColumn.Name = "shokenBikoDataGridViewTextBoxColumn";
            this.shokenBikoDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenBikoDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenHokokuLevelDataGridViewTextBoxColumn
            // 
            this.shokenHokokuLevelDataGridViewTextBoxColumn.DataPropertyName = "ShokenHokokuLevel";
            this.shokenHokokuLevelDataGridViewTextBoxColumn.HeaderText = "ShokenHokokuLevel";
            this.shokenHokokuLevelDataGridViewTextBoxColumn.Name = "shokenHokokuLevelDataGridViewTextBoxColumn";
            this.shokenHokokuLevelDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenHokokuLevelDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenShitekiKbnDataGridViewTextBoxColumn
            // 
            this.shokenShitekiKbnDataGridViewTextBoxColumn.DataPropertyName = "ShokenShitekiKbn";
            this.shokenShitekiKbnDataGridViewTextBoxColumn.HeaderText = "ShokenShitekiKbn";
            this.shokenShitekiKbnDataGridViewTextBoxColumn.Name = "shokenShitekiKbnDataGridViewTextBoxColumn";
            this.shokenShitekiKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenShitekiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenShitekiNoDataGridViewTextBoxColumn
            // 
            this.shokenShitekiNoDataGridViewTextBoxColumn.DataPropertyName = "ShokenShitekiNo";
            this.shokenShitekiNoDataGridViewTextBoxColumn.HeaderText = "ShokenShitekiNo";
            this.shokenShitekiNoDataGridViewTextBoxColumn.Name = "shokenShitekiNoDataGridViewTextBoxColumn";
            this.shokenShitekiNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenShitekiNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenDojiCheckKomokuDataGridViewTextBoxColumn
            // 
            this.shokenDojiCheckKomokuDataGridViewTextBoxColumn.DataPropertyName = "ShokenDojiCheckKomoku";
            this.shokenDojiCheckKomokuDataGridViewTextBoxColumn.HeaderText = "ShokenDojiCheckKomoku";
            this.shokenDojiCheckKomokuDataGridViewTextBoxColumn.Name = "shokenDojiCheckKomokuDataGridViewTextBoxColumn";
            this.shokenDojiCheckKomokuDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenDojiCheckKomokuDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenMstDataSetBindingSource
            // 
            this.shokenMstDataSetBindingSource.DataSource = this.shokenMstDataSet;
            this.shokenMstDataSetBindingSource.Position = 0;
            // 
            // shokenMstDataSet
            // 
            this.shokenMstDataSet.DataSetName = "ShokenMstDataSet";
            this.shokenMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 71;
            this.label4.Text = "検索結果：";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.shokenCdToTextBox);
            this.searchPanel.Controls.Add(this.shokenCdFromTextBox);
            this.searchPanel.Controls.Add(this.shokenKbnTextBox);
            this.searchPanel.Controls.Add(this.shokenShitekiKbnComboBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.gaikankensaKomokuNmComboBox);
            this.searchPanel.Controls.Add(this.shokenJuyodoComboBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 177);
            this.searchPanel.TabIndex = 0;
            // 
            // shokenCdToTextBox
            // 
            this.shokenCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenCdToTextBox.CustomDigitParts = 0;
            this.shokenCdToTextBox.CustomFormat = null;
            this.shokenCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokenCdToTextBox.CustomReadOnly = false;
            this.shokenCdToTextBox.Location = new System.Drawing.Point(175, 63);
            this.shokenCdToTextBox.MaxLength = 3;
            this.shokenCdToTextBox.Name = "shokenCdToTextBox";
            this.shokenCdToTextBox.Size = new System.Drawing.Size(45, 27);
            this.shokenCdToTextBox.TabIndex = 3;
            this.shokenCdToTextBox.Leave += new System.EventHandler(this.shokenCdToTextBox_Leave);
            // 
            // shokenCdFromTextBox
            // 
            this.shokenCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenCdFromTextBox.CustomDigitParts = 0;
            this.shokenCdFromTextBox.CustomFormat = null;
            this.shokenCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokenCdFromTextBox.CustomReadOnly = false;
            this.shokenCdFromTextBox.Location = new System.Drawing.Point(96, 63);
            this.shokenCdFromTextBox.MaxLength = 3;
            this.shokenCdFromTextBox.Name = "shokenCdFromTextBox";
            this.shokenCdFromTextBox.Size = new System.Drawing.Size(45, 27);
            this.shokenCdFromTextBox.TabIndex = 2;
            this.shokenCdFromTextBox.Leave += new System.EventHandler(this.shokenCdFromTextBox_Leave);
            // 
            // shokenKbnTextBox
            // 
            this.shokenKbnTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenKbnTextBox.CustomDigitParts = 0;
            this.shokenKbnTextBox.CustomFormat = null;
            this.shokenKbnTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokenKbnTextBox.CustomReadOnly = false;
            this.shokenKbnTextBox.Location = new System.Drawing.Point(96, 30);
            this.shokenKbnTextBox.MaxLength = 3;
            this.shokenKbnTextBox.Name = "shokenKbnTextBox";
            this.shokenKbnTextBox.Size = new System.Drawing.Size(45, 27);
            this.shokenKbnTextBox.TabIndex = 0;
            this.shokenKbnTextBox.Leave += new System.EventHandler(this.shokenKbnTextBox_Leave);
            // 
            // shokenShitekiKbnComboBox
            // 
            this.shokenShitekiKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenShitekiKbnComboBox.FormattingEnabled = true;
            this.shokenShitekiKbnComboBox.Location = new System.Drawing.Point(96, 130);
            this.shokenShitekiKbnComboBox.Name = "shokenShitekiKbnComboBox";
            this.shokenShitekiKbnComboBox.Size = new System.Drawing.Size(200, 28);
            this.shokenShitekiKbnComboBox.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 76;
            this.label7.Text = "指摘区分";
            // 
            // gaikankensaKomokuNmComboBox
            // 
            this.gaikankensaKomokuNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gaikankensaKomokuNmComboBox.FormattingEnabled = true;
            this.gaikankensaKomokuNmComboBox.Location = new System.Drawing.Point(147, 30);
            this.gaikankensaKomokuNmComboBox.Name = "gaikankensaKomokuNmComboBox";
            this.gaikankensaKomokuNmComboBox.Size = new System.Drawing.Size(500, 28);
            this.gaikankensaKomokuNmComboBox.TabIndex = 1;
            this.gaikankensaKomokuNmComboBox.SelectedIndexChanged += new System.EventHandler(this.gaikankensaKomokuNmComboBox_SelectedIndexChanged);
            // 
            // shokenJuyodoComboBox
            // 
            this.shokenJuyodoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenJuyodoComboBox.FormattingEnabled = true;
            this.shokenJuyodoComboBox.Location = new System.Drawing.Point(96, 96);
            this.shokenJuyodoComboBox.Name = "shokenJuyodoComboBox";
            this.shokenJuyodoComboBox.Size = new System.Drawing.Size(51, 28);
            this.shokenJuyodoComboBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "重要度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "所見区分";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 8;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 11;
            this.label19.Text = "所見コード";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "検索条件";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(884, 134);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 133);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 7;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // ShokenMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.shokenMstListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShokenMstListForm";
            this.Text = "所見マスタ検索";
            this.Load += new System.EventHandler(this.ShokenMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShokenMstListForm_KeyDown);
            this.shokenMstListPanel.ResumeLayout(false);
            this.shokenMstListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel shokenMstListPanel;
        private System.Windows.Forms.Label shokenMstListCountLabel;
        private System.Windows.Forms.DataGridView shokenMstListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.ComboBox shokenJuyodoComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox shokenShitekiKbnComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox gaikankensaKomokuNmComboBox;
        private Control.NumberTextBox shokenKbnTextBox;
        private Control.NumberTextBox shokenCdToTextBox;
        private Control.NumberTextBox shokenCdFromTextBox;
        private System.Windows.Forms.BindingSource shokenMstDataSetBindingSource;
        private DataSet.ShokenMstDataSet shokenMstDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenJuyodoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHandanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenWdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokenWdRyakuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHanteiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenBikoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHokokuLevelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenShitekiKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenShitekiNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCheckNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShokenFollowFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenJuyodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHandanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenWdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHanteiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenBikoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHokokuLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenShitekiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenShitekiNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenDojiCheckKomokuDataGridViewTextBoxColumn;

    }
}