namespace FukjBizSystem.Application.Boundary.Master
{
    partial class SuishitsuKekkaNmMstListForm
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
            this.suishitsuKekkaNmListPanel = new System.Windows.Forms.Panel();
            this.suishitsuKekkaNmListCountLabel = new System.Windows.Forms.Label();
            this.suishitsuKekkaNmListDataGridView = new System.Windows.Forms.DataGridView();
            this.SuishitsuKekkaShishoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuishitsuKekkaNmCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuishitsuKekkaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuKekkaShishoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuKekkaNmCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuKekkaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuKekkaNmMstKensakuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suishitsuKekkaNmMstDataSet = new FukjBizSystem.Application.DataSet.SuishitsuKekkaNmMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.gaikankensaKomokuCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.gaikankensaKomokuCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shishoNmComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gaikankensaKomokuNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.suishitsuKekkaNmMstKensakuTableAdapter = new FukjBizSystem.Application.DataSet.SuishitsuKekkaNmMstDataSetTableAdapters.SuishitsuKekkaNmMstKensakuTableAdapter();
            this.suishitsuKekkaNmListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKekkaNmListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKekkaNmMstKensakuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKekkaNmMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(860, 555);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 15;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(994, 555);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 16;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(726, 555);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 14;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(586, 555);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 13;
            this.torokuButton.Text = "F1:新規登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // suishitsuKekkaNmListPanel
            // 
            this.suishitsuKekkaNmListPanel.Controls.Add(this.suishitsuKekkaNmListCountLabel);
            this.suishitsuKekkaNmListPanel.Controls.Add(this.suishitsuKekkaNmListDataGridView);
            this.suishitsuKekkaNmListPanel.Controls.Add(this.label4);
            this.suishitsuKekkaNmListPanel.Location = new System.Drawing.Point(0, 147);
            this.suishitsuKekkaNmListPanel.Name = "suishitsuKekkaNmListPanel";
            this.suishitsuKekkaNmListPanel.Size = new System.Drawing.Size(1103, 404);
            this.suishitsuKekkaNmListPanel.TabIndex = 12;
            // 
            // suishitsuKekkaNmListCountLabel
            // 
            this.suishitsuKekkaNmListCountLabel.AutoSize = true;
            this.suishitsuKekkaNmListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.suishitsuKekkaNmListCountLabel.Name = "suishitsuKekkaNmListCountLabel";
            this.suishitsuKekkaNmListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.suishitsuKekkaNmListCountLabel.TabIndex = 72;
            this.suishitsuKekkaNmListCountLabel.Text = "0件";
            // 
            // suishitsuKekkaNmListDataGridView
            // 
            this.suishitsuKekkaNmListDataGridView.AllowUserToAddRows = false;
            this.suishitsuKekkaNmListDataGridView.AllowUserToDeleteRows = false;
            this.suishitsuKekkaNmListDataGridView.AllowUserToResizeRows = false;
            this.suishitsuKekkaNmListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suishitsuKekkaNmListDataGridView.AutoGenerateColumns = false;
            this.suishitsuKekkaNmListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suishitsuKekkaNmListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SuishitsuKekkaShishoCdCol,
            this.ShishoNmCol,
            this.SuishitsuKekkaNmCdCol,
            this.SuishitsuKekkaNmCol,
            this.suishitsuKekkaShishoCdDataGridViewTextBoxColumn,
            this.suishitsuKekkaNmCdDataGridViewTextBoxColumn,
            this.suishitsuKekkaNmDataGridViewTextBoxColumn});
            this.suishitsuKekkaNmListDataGridView.DataSource = this.suishitsuKekkaNmMstKensakuBindingSource;
            this.suishitsuKekkaNmListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.suishitsuKekkaNmListDataGridView.MultiSelect = false;
            this.suishitsuKekkaNmListDataGridView.Name = "suishitsuKekkaNmListDataGridView";
            this.suishitsuKekkaNmListDataGridView.ReadOnly = true;
            this.suishitsuKekkaNmListDataGridView.RowHeadersVisible = false;
            this.suishitsuKekkaNmListDataGridView.RowTemplate.Height = 21;
            this.suishitsuKekkaNmListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suishitsuKekkaNmListDataGridView.Size = new System.Drawing.Size(1100, 378);
            this.suishitsuKekkaNmListDataGridView.TabIndex = 6;
            this.suishitsuKekkaNmListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suishitsuKekkaNmListDataGridView_CellDoubleClick);
            // 
            // SuishitsuKekkaShishoCdCol
            // 
            this.SuishitsuKekkaShishoCdCol.DataPropertyName = "SuishitsuKekkaShishoCd";
            this.SuishitsuKekkaShishoCdCol.HeaderText = "支所コード";
            this.SuishitsuKekkaShishoCdCol.MinimumWidth = 100;
            this.SuishitsuKekkaShishoCdCol.Name = "SuishitsuKekkaShishoCdCol";
            this.SuishitsuKekkaShishoCdCol.ReadOnly = true;
            // 
            // ShishoNmCol
            // 
            this.ShishoNmCol.DataPropertyName = "ShishoNm";
            this.ShishoNmCol.HeaderText = "支所名称";
            this.ShishoNmCol.MinimumWidth = 150;
            this.ShishoNmCol.Name = "ShishoNmCol";
            this.ShishoNmCol.ReadOnly = true;
            this.ShishoNmCol.Width = 150;
            // 
            // SuishitsuKekkaNmCdCol
            // 
            this.SuishitsuKekkaNmCdCol.DataPropertyName = "SuishitsuKekkaNmCd";
            this.SuishitsuKekkaNmCdCol.HeaderText = "水質結果名称コード";
            this.SuishitsuKekkaNmCdCol.MinimumWidth = 200;
            this.SuishitsuKekkaNmCdCol.Name = "SuishitsuKekkaNmCdCol";
            this.SuishitsuKekkaNmCdCol.ReadOnly = true;
            this.SuishitsuKekkaNmCdCol.Width = 200;
            // 
            // SuishitsuKekkaNmCol
            // 
            this.SuishitsuKekkaNmCol.DataPropertyName = "SuishitsuKekkaNm";
            this.SuishitsuKekkaNmCol.HeaderText = "水質結果名称";
            this.SuishitsuKekkaNmCol.MinimumWidth = 400;
            this.SuishitsuKekkaNmCol.Name = "SuishitsuKekkaNmCol";
            this.SuishitsuKekkaNmCol.ReadOnly = true;
            this.SuishitsuKekkaNmCol.Width = 400;
            // 
            // suishitsuKekkaShishoCdDataGridViewTextBoxColumn
            // 
            this.suishitsuKekkaShishoCdDataGridViewTextBoxColumn.DataPropertyName = "SuishitsuKekkaShishoCd";
            this.suishitsuKekkaShishoCdDataGridViewTextBoxColumn.HeaderText = "SuishitsuKekkaShishoCd";
            this.suishitsuKekkaShishoCdDataGridViewTextBoxColumn.Name = "suishitsuKekkaShishoCdDataGridViewTextBoxColumn";
            this.suishitsuKekkaShishoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.suishitsuKekkaShishoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // suishitsuKekkaNmCdDataGridViewTextBoxColumn
            // 
            this.suishitsuKekkaNmCdDataGridViewTextBoxColumn.DataPropertyName = "SuishitsuKekkaNmCd";
            this.suishitsuKekkaNmCdDataGridViewTextBoxColumn.HeaderText = "SuishitsuKekkaNmCd";
            this.suishitsuKekkaNmCdDataGridViewTextBoxColumn.Name = "suishitsuKekkaNmCdDataGridViewTextBoxColumn";
            this.suishitsuKekkaNmCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.suishitsuKekkaNmCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // suishitsuKekkaNmDataGridViewTextBoxColumn
            // 
            this.suishitsuKekkaNmDataGridViewTextBoxColumn.DataPropertyName = "SuishitsuKekkaNm";
            this.suishitsuKekkaNmDataGridViewTextBoxColumn.HeaderText = "SuishitsuKekkaNm";
            this.suishitsuKekkaNmDataGridViewTextBoxColumn.Name = "suishitsuKekkaNmDataGridViewTextBoxColumn";
            this.suishitsuKekkaNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.suishitsuKekkaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // suishitsuKekkaNmMstKensakuBindingSource
            // 
            this.suishitsuKekkaNmMstKensakuBindingSource.DataMember = "SuishitsuKekkaNmMstKensaku";
            this.suishitsuKekkaNmMstKensakuBindingSource.DataSource = this.suishitsuKekkaNmMstDataSet;
            // 
            // suishitsuKekkaNmMstDataSet
            // 
            this.suishitsuKekkaNmMstDataSet.DataSetName = "SuishitsuKekkaNmMstDataSet";
            this.suishitsuKekkaNmMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.gaikankensaKomokuCdToTextBox);
            this.searchPanel.Controls.Add(this.gaikankensaKomokuCdFromTextBox);
            this.searchPanel.Controls.Add(this.shishoNmComboBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.gaikankensaKomokuNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 148);
            this.searchPanel.TabIndex = 11;
            // 
            // gaikankensaKomokuCdToTextBox
            // 
            this.gaikankensaKomokuCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gaikankensaKomokuCdToTextBox.CustomDigitParts = 0;
            this.gaikankensaKomokuCdToTextBox.CustomFormat = null;
            this.gaikankensaKomokuCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gaikankensaKomokuCdToTextBox.CustomReadOnly = false;
            this.gaikankensaKomokuCdToTextBox.Location = new System.Drawing.Point(222, 65);
            this.gaikankensaKomokuCdToTextBox.MaxLength = 3;
            this.gaikankensaKomokuCdToTextBox.Name = "gaikankensaKomokuCdToTextBox";
            this.gaikankensaKomokuCdToTextBox.Size = new System.Drawing.Size(35, 27);
            this.gaikankensaKomokuCdToTextBox.TabIndex = 9;
            this.gaikankensaKomokuCdToTextBox.Leave += new System.EventHandler(this.gaikankensaKomokuCdToTextBox_Leave);
            // 
            // gaikankensaKomokuCdFromTextBox
            // 
            this.gaikankensaKomokuCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gaikankensaKomokuCdFromTextBox.CustomDigitParts = 0;
            this.gaikankensaKomokuCdFromTextBox.CustomFormat = null;
            this.gaikankensaKomokuCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gaikankensaKomokuCdFromTextBox.CustomReadOnly = false;
            this.gaikankensaKomokuCdFromTextBox.Location = new System.Drawing.Point(153, 65);
            this.gaikankensaKomokuCdFromTextBox.MaxLength = 3;
            this.gaikankensaKomokuCdFromTextBox.Name = "gaikankensaKomokuCdFromTextBox";
            this.gaikankensaKomokuCdFromTextBox.Size = new System.Drawing.Size(35, 27);
            this.gaikankensaKomokuCdFromTextBox.TabIndex = 8;
            this.gaikankensaKomokuCdFromTextBox.Leave += new System.EventHandler(this.gaikankensaKomokuCdFromTextBox_Leave);
            // 
            // shishoNmComboBox
            // 
            this.shishoNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shishoNmComboBox.FormattingEnabled = true;
            this.shishoNmComboBox.Location = new System.Drawing.Point(153, 31);
            this.shishoNmComboBox.Name = "shishoNmComboBox";
            this.shishoNmComboBox.Size = new System.Drawing.Size(142, 28);
            this.shishoNmComboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 74;
            this.label5.Text = "支所";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "～";
            // 
            // gaikankensaKomokuNmTextBox
            // 
            this.gaikankensaKomokuNmTextBox.Location = new System.Drawing.Point(153, 98);
            this.gaikankensaKomokuNmTextBox.MaxLength = 28;
            this.gaikankensaKomokuNmTextBox.Name = "gaikankensaKomokuNmTextBox";
            this.gaikankensaKomokuNmTextBox.Size = new System.Drawing.Size(410, 27);
            this.gaikankensaKomokuNmTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "水質結果名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 13;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 20);
            this.label19.TabIndex = 11;
            this.label19.Text = "水質結果名称コード";
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
            this.clearButton.Location = new System.Drawing.Point(884, 105);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 104);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 12;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // suishitsuKekkaNmMstKensakuTableAdapter
            // 
            this.suishitsuKekkaNmMstKensakuTableAdapter.ClearBeforeFill = true;
            // 
            // SuishitsuKekkaNmMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.suishitsuKekkaNmListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SuishitsuKekkaNmMstListForm";
            this.Text = "水質結果名称マスタ検索";
            this.Load += new System.EventHandler(this.SuishitsuKekkaNmMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuishitsuKekkaNmMstListForm_KeyDown);
            this.suishitsuKekkaNmListPanel.ResumeLayout(false);
            this.suishitsuKekkaNmListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKekkaNmListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKekkaNmMstKensakuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKekkaNmMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel suishitsuKekkaNmListPanel;
        private System.Windows.Forms.Label suishitsuKekkaNmListCountLabel;
        private System.Windows.Forms.DataGridView suishitsuKekkaNmListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gaikankensaKomokuNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox shishoNmComboBox;
        private Control.NumberTextBox gaikankensaKomokuCdToTextBox;
        private Control.NumberTextBox gaikankensaKomokuCdFromTextBox;
        private DataSet.SuishitsuKekkaNmMstDataSet suishitsuKekkaNmMstDataSet;
        private System.Windows.Forms.BindingSource suishitsuKekkaNmMstKensakuBindingSource;
        private DataSet.SuishitsuKekkaNmMstDataSetTableAdapters.SuishitsuKekkaNmMstKensakuTableAdapter suishitsuKekkaNmMstKensakuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuishitsuKekkaShishoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuishitsuKekkaNmCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuishitsuKekkaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn suishitsuKekkaShishoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suishitsuKekkaNmCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suishitsuKekkaNmDataGridViewTextBoxColumn;

    }
}