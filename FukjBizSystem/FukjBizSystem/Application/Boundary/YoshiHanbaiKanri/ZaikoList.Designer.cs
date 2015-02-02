namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class ZaikoListForm
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
            this.shishoMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shishoMstDataSet = new FukjBizSystem.Application.DataSet.ShishoMstDataSet();
            this.yoshiMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yoshiMstDataSet = new FukjBizSystem.Application.DataSet.YoshiMstDataSet();
            this.yoshiZaikoTblKensakuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yoshiZaikoTblDataSet = new FukjBizSystem.Application.DataSet.YoshiZaikoTblDataSet();
            this.shishoMstTableAdapter = new FukjBizSystem.Application.DataSet.ShishoMstDataSetTableAdapters.ShishoMstTableAdapter();
            this.yoshiMstTableAdapter = new FukjBizSystem.Application.DataSet.YoshiMstDataSetTableAdapters.YoshiMstTableAdapter();
            this.yoshiZaikoTblKensakuTableAdapter = new FukjBizSystem.Application.DataSet.YoshiZaikoTblDataSetTableAdapters.YoshiZaikoTblKensakuTableAdapter();
            this.outputButton = new System.Windows.Forms.Button();
            this.koshinButton = new System.Windows.Forms.Button();
            this.zaikoListPanel = new System.Windows.Forms.Panel();
            this.zaikoListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.zaikoListDataGridView = new System.Windows.Forms.DataGridView();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.shishoNmComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.yoshiCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.yoshiCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.yoshiNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.shishoMstExceptJimukyokuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shishoMstExceptJimukyokuTableAdapter = new FukjBizSystem.Application.DataSet.ShishoMstDataSetTableAdapters.ShishoMstExceptJimukyokuTableAdapter();
            this.ShishoCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.YoshiCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SuryoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InsertDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertTarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuryoOldCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiZaikoTblKensakuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiZaikoTblDataSet)).BeginInit();
            this.zaikoListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zaikoListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstExceptJimukyokuBindingSource)).BeginInit();
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
            // yoshiMstBindingSource
            // 
            this.yoshiMstBindingSource.DataMember = "YoshiMst";
            this.yoshiMstBindingSource.DataSource = this.yoshiMstDataSet;
            // 
            // yoshiMstDataSet
            // 
            this.yoshiMstDataSet.DataSetName = "YoshiMstDataSet";
            this.yoshiMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yoshiZaikoTblKensakuBindingSource
            // 
            this.yoshiZaikoTblKensakuBindingSource.DataMember = "YoshiZaikoTblKensaku";
            this.yoshiZaikoTblKensakuBindingSource.DataSource = this.yoshiZaikoTblDataSet;
            // 
            // yoshiZaikoTblDataSet
            // 
            this.yoshiZaikoTblDataSet.DataSetName = "YoshiZaikoTblDataSet";
            this.yoshiZaikoTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shishoMstTableAdapter
            // 
            this.shishoMstTableAdapter.ClearBeforeFill = true;
            // 
            // yoshiMstTableAdapter
            // 
            this.yoshiMstTableAdapter.ClearBeforeFill = true;
            // 
            // yoshiZaikoTblKensakuTableAdapter
            // 
            this.yoshiZaikoTblKensakuTableAdapter.ClearBeforeFill = true;
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(862, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 14;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // koshinButton
            // 
            this.koshinButton.Location = new System.Drawing.Point(728, 544);
            this.koshinButton.Name = "koshinButton";
            this.koshinButton.Size = new System.Drawing.Size(101, 37);
            this.koshinButton.TabIndex = 13;
            this.koshinButton.Text = "F1:確定";
            this.koshinButton.UseVisualStyleBackColor = true;
            this.koshinButton.Click += new System.EventHandler(this.koshinButton_Click);
            // 
            // zaikoListPanel
            // 
            this.zaikoListPanel.Controls.Add(this.zaikoListCountLabel);
            this.zaikoListPanel.Controls.Add(this.label4);
            this.zaikoListPanel.Controls.Add(this.zaikoListDataGridView);
            this.zaikoListPanel.Location = new System.Drawing.Point(0, 153);
            this.zaikoListPanel.Name = "zaikoListPanel";
            this.zaikoListPanel.Size = new System.Drawing.Size(1100, 375);
            this.zaikoListPanel.TabIndex = 12;
            // 
            // zaikoListCountLabel
            // 
            this.zaikoListCountLabel.AutoSize = true;
            this.zaikoListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.zaikoListCountLabel.Name = "zaikoListCountLabel";
            this.zaikoListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.zaikoListCountLabel.TabIndex = 1;
            this.zaikoListCountLabel.Text = "0件";
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
            // zaikoListDataGridView
            // 
            this.zaikoListDataGridView.AllowUserToResizeRows = false;
            this.zaikoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zaikoListDataGridView.AutoGenerateColumns = false;
            this.zaikoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zaikoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShishoCol,
            this.YoshiCol,
            this.SuryoCdCol,
            this.DeleteFlgCol,
            this.InsertDt,
            this.InsertUser,
            this.InsertTarm,
            this.UpdateDt,
            this.UpdateUser,
            this.UpdateTarm,
            this.SuryoOldCol});
            this.zaikoListDataGridView.DataSource = this.yoshiZaikoTblKensakuBindingSource;
            this.zaikoListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.zaikoListDataGridView.MultiSelect = false;
            this.zaikoListDataGridView.Name = "zaikoListDataGridView";
            this.zaikoListDataGridView.RowHeadersVisible = false;
            this.zaikoListDataGridView.RowTemplate.Height = 21;
            this.zaikoListDataGridView.Size = new System.Drawing.Size(1095, 348);
            this.zaikoListDataGridView.TabIndex = 2;
            this.zaikoListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.zaikoListDataGridView_CellFormatting);
            this.zaikoListDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.zaikoListDataGridView_CellValueChanged);
            this.zaikoListDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.zaikoListDataGridView_CurrentCellDirtyStateChanged);
            this.zaikoListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.zaikoListDataGridView_DataError);
            this.zaikoListDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.zaikoListDataGridView_EditingControlShowing);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.shishoNmComboBox);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.yoshiCdFromTextBox);
            this.searchPanel.Controls.Add(this.yoshiCdToTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.yoshiNameTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1100, 148);
            this.searchPanel.TabIndex = 11;
            // 
            // shishoNmComboBox
            // 
            this.shishoNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shishoNmComboBox.FormattingEnabled = true;
            this.shishoNmComboBox.Location = new System.Drawing.Point(112, 31);
            this.shishoNmComboBox.Name = "shishoNmComboBox";
            this.shishoNmComboBox.Size = new System.Drawing.Size(130, 28);
            this.shishoNmComboBox.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "支所";
            // 
            // yoshiCdFromTextBox
            // 
            this.yoshiCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.yoshiCdFromTextBox.CustomDigitParts = 0;
            this.yoshiCdFromTextBox.CustomFormat = null;
            this.yoshiCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.yoshiCdFromTextBox.CustomReadOnly = false;
            this.yoshiCdFromTextBox.Location = new System.Drawing.Point(112, 65);
            this.yoshiCdFromTextBox.MaxLength = 2;
            this.yoshiCdFromTextBox.Name = "yoshiCdFromTextBox";
            this.yoshiCdFromTextBox.Size = new System.Drawing.Size(48, 27);
            this.yoshiCdFromTextBox.TabIndex = 4;
            this.yoshiCdFromTextBox.Leave += new System.EventHandler(this.yoshiCdFromTextBox_Leave);
            // 
            // yoshiCdToTextBox
            // 
            this.yoshiCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.yoshiCdToTextBox.CustomDigitParts = 0;
            this.yoshiCdToTextBox.CustomFormat = null;
            this.yoshiCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.yoshiCdToTextBox.CustomReadOnly = false;
            this.yoshiCdToTextBox.Location = new System.Drawing.Point(194, 65);
            this.yoshiCdToTextBox.MaxLength = 2;
            this.yoshiCdToTextBox.Name = "yoshiCdToTextBox";
            this.yoshiCdToTextBox.Size = new System.Drawing.Size(48, 27);
            this.yoshiCdToTextBox.TabIndex = 6;
            this.yoshiCdToTextBox.Leave += new System.EventHandler(this.yoshiCdToTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // yoshiNameTextBox
            // 
            this.yoshiNameTextBox.Location = new System.Drawing.Point(112, 98);
            this.yoshiNameTextBox.MaxLength = 60;
            this.yoshiNameTextBox.Name = "yoshiNameTextBox";
            this.yoshiNameTextBox.Size = new System.Drawing.Size(617, 27);
            this.yoshiNameTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1068, 3);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 11;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "用紙コード";
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
            this.clearButton.Location = new System.Drawing.Point(889, 102);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(996, 101);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 10;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(996, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 15;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // shishoMstExceptJimukyokuBindingSource
            // 
            this.shishoMstExceptJimukyokuBindingSource.DataMember = "ShishoMstExceptJimukyoku";
            this.shishoMstExceptJimukyokuBindingSource.DataSource = this.shishoMstDataSet;
            // 
            // shishoMstExceptJimukyokuTableAdapter
            // 
            this.shishoMstExceptJimukyokuTableAdapter.ClearBeforeFill = true;
            // 
            // ShishoCol
            // 
            this.ShishoCol.DataPropertyName = "YoshiZaikoShishoCd";
            this.ShishoCol.DataSource = this.shishoMstExceptJimukyokuBindingSource;
            this.ShishoCol.DisplayMember = "ShishoNm";
            this.ShishoCol.HeaderText = "支所";
            this.ShishoCol.MinimumWidth = 200;
            this.ShishoCol.Name = "ShishoCol";
            this.ShishoCol.ValueMember = "ShishoCd";
            this.ShishoCol.Width = 200;
            // 
            // YoshiCol
            // 
            this.YoshiCol.DataPropertyName = "YoshiZaikoYoshiCd";
            this.YoshiCol.DataSource = this.yoshiMstBindingSource;
            this.YoshiCol.DisplayMember = "YoshiNm";
            this.YoshiCol.HeaderText = "用紙名";
            this.YoshiCol.MinimumWidth = 400;
            this.YoshiCol.Name = "YoshiCol";
            this.YoshiCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.YoshiCol.ValueMember = "YoshiCd";
            this.YoshiCol.Width = 400;
            // 
            // SuryoCdCol
            // 
            this.SuryoCdCol.DataPropertyName = "YoshiZaikoSuryo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = null;
            this.SuryoCdCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.SuryoCdCol.HeaderText = "在庫数";
            this.SuryoCdCol.MaxInputLength = 6;
            this.SuryoCdCol.MinimumWidth = 100;
            this.SuryoCdCol.Name = "SuryoCdCol";
            this.SuryoCdCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeleteFlgCol
            // 
            this.DeleteFlgCol.FalseValue = "0";
            this.DeleteFlgCol.HeaderText = "削除";
            this.DeleteFlgCol.IndeterminateValue = "";
            this.DeleteFlgCol.MinimumWidth = 100;
            this.DeleteFlgCol.Name = "DeleteFlgCol";
            this.DeleteFlgCol.TrueValue = "1";
            // 
            // InsertDt
            // 
            this.InsertDt.DataPropertyName = "InsertDt";
            this.InsertDt.HeaderText = "InsertDt";
            this.InsertDt.Name = "InsertDt";
            this.InsertDt.Visible = false;
            // 
            // InsertUser
            // 
            this.InsertUser.DataPropertyName = "InsertUser";
            this.InsertUser.HeaderText = "InsertUser";
            this.InsertUser.Name = "InsertUser";
            this.InsertUser.Visible = false;
            // 
            // InsertTarm
            // 
            this.InsertTarm.DataPropertyName = "InsertTarm";
            this.InsertTarm.HeaderText = "InsertTarm";
            this.InsertTarm.Name = "InsertTarm";
            this.InsertTarm.Visible = false;
            // 
            // UpdateDt
            // 
            this.UpdateDt.DataPropertyName = "UpdateDt";
            this.UpdateDt.HeaderText = "UpdateDt";
            this.UpdateDt.Name = "UpdateDt";
            this.UpdateDt.Visible = false;
            // 
            // UpdateUser
            // 
            this.UpdateUser.DataPropertyName = "UpdateUser";
            this.UpdateUser.HeaderText = "UpdateUser";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Visible = false;
            // 
            // UpdateTarm
            // 
            this.UpdateTarm.DataPropertyName = "UpdateTarm";
            this.UpdateTarm.HeaderText = "UpdateTarm";
            this.UpdateTarm.Name = "UpdateTarm";
            this.UpdateTarm.Visible = false;
            // 
            // SuryoOldCol
            // 
            this.SuryoOldCol.HeaderText = "SuryoOld";
            this.SuryoOldCol.Name = "SuryoOldCol";
            this.SuryoOldCol.Visible = false;
            // 
            // ZaikoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.koshinButton);
            this.Controls.Add(this.zaikoListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ZaikoListForm";
            this.Text = "在庫一覧";
            this.Load += new System.EventHandler(this.ZaikoListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZaikoListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiZaikoTblKensakuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiZaikoTblDataSet)).EndInit();
            this.zaikoListPanel.ResumeLayout(false);
            this.zaikoListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zaikoListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shishoMstExceptJimukyokuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button koshinButton;
        private System.Windows.Forms.DataGridView zaikoListDataGridView;
        private System.Windows.Forms.TextBox yoshiNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel zaikoListPanel;
        private System.Windows.Forms.Label zaikoListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private Control.NumberTextBox yoshiCdFromTextBox;
        private Control.NumberTextBox yoshiCdToTextBox;
        private System.Windows.Forms.ComboBox shishoNmComboBox;
        private System.Windows.Forms.Label label8;
        private DataSet.YoshiZaikoTblDataSet yoshiZaikoTblDataSet;
        private System.Windows.Forms.BindingSource yoshiZaikoTblKensakuBindingSource;
        private DataSet.YoshiZaikoTblDataSetTableAdapters.YoshiZaikoTblKensakuTableAdapter yoshiZaikoTblKensakuTableAdapter;
        private DataSet.ShishoMstDataSet shishoMstDataSet;
        private System.Windows.Forms.BindingSource shishoMstBindingSource;
        private DataSet.ShishoMstDataSetTableAdapters.ShishoMstTableAdapter shishoMstTableAdapter;
        private DataSet.YoshiMstDataSet yoshiMstDataSet;
        private System.Windows.Forms.BindingSource yoshiMstBindingSource;
        private DataSet.YoshiMstDataSetTableAdapters.YoshiMstTableAdapter yoshiMstTableAdapter;
        private System.Windows.Forms.BindingSource shishoMstExceptJimukyokuBindingSource;
        private DataSet.ShishoMstDataSetTableAdapters.ShishoMstExceptJimukyokuTableAdapter shishoMstExceptJimukyokuTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShishoCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn YoshiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuryoCdCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DeleteFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertTarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuryoOldCol;
    }
}