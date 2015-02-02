namespace FukjBizSystem.Application.Boundary.Master
{
    partial class NameMstEditListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nameMstNameKbn000BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameMstDataSet = new FukjBizSystem.Application.DataSet.NameMstDataSet();
            this.nameMstNameKbn000TableAdapter = new FukjBizSystem.Application.DataSet.NameMstDataSetTableAdapters.NameMstNameKbn000TableAdapter();
            this.outputButton = new System.Windows.Forms.Button();
            this.koshinButton = new System.Windows.Forms.Button();
            this.nameListPanel = new System.Windows.Forms.Panel();
            this.nameListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameListDataGridView = new System.Windows.Forms.DataGridView();
            this.NameKbnCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NameCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NameKbnOldCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCdOldCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOldCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteFlgOldCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUpdateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.nameCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.nameCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.nameKbnComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nameMstNameKbn000BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameMstDataSet)).BeginInit();
            this.nameListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameMstNameKbn000BindingSource
            // 
            this.nameMstNameKbn000BindingSource.DataMember = "NameMstNameKbn000";
            this.nameMstNameKbn000BindingSource.DataSource = this.nameMstDataSet;
            // 
            // nameMstDataSet
            // 
            this.nameMstDataSet.DataSetName = "NameMstDataSet";
            this.nameMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nameMstNameKbn000TableAdapter
            // 
            this.nameMstNameKbn000TableAdapter.ClearBeforeFill = true;
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
            this.koshinButton.Text = "F1:登録";
            this.koshinButton.UseVisualStyleBackColor = true;
            this.koshinButton.Click += new System.EventHandler(this.koshinButton_Click);
            // 
            // nameListPanel
            // 
            this.nameListPanel.Controls.Add(this.nameListCountLabel);
            this.nameListPanel.Controls.Add(this.label4);
            this.nameListPanel.Controls.Add(this.nameListDataGridView);
            this.nameListPanel.Location = new System.Drawing.Point(0, 153);
            this.nameListPanel.Name = "nameListPanel";
            this.nameListPanel.Size = new System.Drawing.Size(1100, 375);
            this.nameListPanel.TabIndex = 12;
            // 
            // nameListCountLabel
            // 
            this.nameListCountLabel.AutoSize = true;
            this.nameListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.nameListCountLabel.Name = "nameListCountLabel";
            this.nameListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.nameListCountLabel.TabIndex = 1;
            this.nameListCountLabel.Text = "0件";
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
            // nameListDataGridView
            // 
            this.nameListDataGridView.AllowUserToResizeRows = false;
            this.nameListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nameListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameKbnCol,
            this.NameCdCol,
            this.NameCol,
            this.DeleteFlgCol,
            this.NameKbnOldCol,
            this.NameCdOldCol,
            this.NameOldCol,
            this.DeleteFlgOldCol,
            this.IsUpdateCol});
            this.nameListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.nameListDataGridView.MultiSelect = false;
            this.nameListDataGridView.Name = "nameListDataGridView";
            this.nameListDataGridView.RowHeadersVisible = false;
            this.nameListDataGridView.RowTemplate.Height = 21;
            this.nameListDataGridView.Size = new System.Drawing.Size(1095, 348);
            this.nameListDataGridView.TabIndex = 2;
            this.nameListDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.nameListDataGridView_CellValueChanged);
            this.nameListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.nameListDataGridView_DataError);
            this.nameListDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.nameListDataGridView_EditingControlShowing);
            this.nameListDataGridView.Sorted += new System.EventHandler(this.nameListDataGridView_Sorted);
            // 
            // NameKbnCol
            // 
            this.NameKbnCol.DataSource = this.nameMstNameKbn000BindingSource;
            this.NameKbnCol.DisplayMember = "Name";
            this.NameKbnCol.HeaderText = "名称区分";
            this.NameKbnCol.MinimumWidth = 150;
            this.NameKbnCol.Name = "NameKbnCol";
            this.NameKbnCol.ValueMember = "NameCd";
            this.NameKbnCol.Width = 150;
            // 
            // NameCdCol
            // 
            this.NameCdCol.DataPropertyName = "NameCdNew";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.NameCdCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.NameCdCol.HeaderText = "名称コード";
            this.NameCdCol.MinimumWidth = 110;
            this.NameCdCol.Name = "NameCdCol";
            this.NameCdCol.ReadOnly = true;
            this.NameCdCol.Width = 110;
            // 
            // NameCol
            // 
            this.NameCol.DataPropertyName = "Name";
            this.NameCol.HeaderText = "名称";
            this.NameCol.MaxInputLength = 60;
            this.NameCol.MinimumWidth = 600;
            this.NameCol.Name = "NameCol";
            this.NameCol.Width = 600;
            // 
            // DeleteFlgCol
            // 
            this.DeleteFlgCol.DataPropertyName = "DeleteFlg";
            this.DeleteFlgCol.FalseValue = "0";
            this.DeleteFlgCol.HeaderText = "削除フラグ";
            this.DeleteFlgCol.MinimumWidth = 100;
            this.DeleteFlgCol.Name = "DeleteFlgCol";
            this.DeleteFlgCol.TrueValue = "1";
            // 
            // NameKbnOldCol
            // 
            this.NameKbnOldCol.DataPropertyName = "NameKbnOld";
            this.NameKbnOldCol.HeaderText = "NameKbnOldCol";
            this.NameKbnOldCol.Name = "NameKbnOldCol";
            this.NameKbnOldCol.Visible = false;
            // 
            // NameCdOldCol
            // 
            this.NameCdOldCol.DataPropertyName = "NameCdOld";
            this.NameCdOldCol.HeaderText = "NameCdOldCol";
            this.NameCdOldCol.Name = "NameCdOldCol";
            this.NameCdOldCol.Visible = false;
            // 
            // NameOldCol
            // 
            this.NameOldCol.DataPropertyName = "NameOld";
            this.NameOldCol.HeaderText = "NameOldCol";
            this.NameOldCol.Name = "NameOldCol";
            this.NameOldCol.Visible = false;
            // 
            // DeleteFlgOldCol
            // 
            this.DeleteFlgOldCol.DataPropertyName = "DeleteFlgOld";
            this.DeleteFlgOldCol.HeaderText = "DeleteFlgOldCol";
            this.DeleteFlgOldCol.Name = "DeleteFlgOldCol";
            this.DeleteFlgOldCol.Visible = false;
            // 
            // IsUpdateCol
            // 
            this.IsUpdateCol.DataPropertyName = "IsUpdate";
            this.IsUpdateCol.HeaderText = "IsUpdateCol";
            this.IsUpdateCol.Name = "IsUpdateCol";
            this.IsUpdateCol.Visible = false;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.nameCdFromTextBox);
            this.searchPanel.Controls.Add(this.nameCdToTextBox);
            this.searchPanel.Controls.Add(this.nameKbnComboBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.nameTextBox);
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
            // nameCdFromTextBox
            // 
            this.nameCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.nameCdFromTextBox.CustomDigitParts = 0;
            this.nameCdFromTextBox.CustomFormat = null;
            this.nameCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.nameCdFromTextBox.CustomReadOnly = false;
            this.nameCdFromTextBox.Location = new System.Drawing.Point(112, 65);
            this.nameCdFromTextBox.MaxLength = 3;
            this.nameCdFromTextBox.Name = "nameCdFromTextBox";
            this.nameCdFromTextBox.Size = new System.Drawing.Size(48, 27);
            this.nameCdFromTextBox.TabIndex = 4;
            this.nameCdFromTextBox.Leave += new System.EventHandler(this.nameCdFromTextBox_Leave);
            // 
            // nameCdToTextBox
            // 
            this.nameCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.nameCdToTextBox.CustomDigitParts = 0;
            this.nameCdToTextBox.CustomFormat = null;
            this.nameCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.nameCdToTextBox.CustomReadOnly = false;
            this.nameCdToTextBox.Location = new System.Drawing.Point(194, 65);
            this.nameCdToTextBox.MaxLength = 3;
            this.nameCdToTextBox.Name = "nameCdToTextBox";
            this.nameCdToTextBox.Size = new System.Drawing.Size(48, 27);
            this.nameCdToTextBox.TabIndex = 6;
            this.nameCdToTextBox.Leave += new System.EventHandler(this.nameCdToTextBox_Leave);
            // 
            // nameKbnComboBox
            // 
            this.nameKbnComboBox.DisplayMember = "NameKbnNm";
            this.nameKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameKbnComboBox.FormattingEnabled = true;
            this.nameKbnComboBox.Location = new System.Drawing.Point(112, 31);
            this.nameKbnComboBox.Name = "nameKbnComboBox";
            this.nameKbnComboBox.Size = new System.Drawing.Size(132, 28);
            this.nameKbnComboBox.TabIndex = 2;
            this.nameKbnComboBox.ValueMember = "NameKbnCd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "名称区分";
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
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(112, 98);
            this.nameTextBox.MaxLength = 60;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(617, 27);
            this.nameTextBox.TabIndex = 8;
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
            this.label19.Text = "名称コード";
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
            // NameMstEditListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.koshinButton);
            this.Controls.Add(this.nameListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NameMstEditListForm";
            this.Text = "名称マスタ検索＆編集";
            this.Load += new System.EventHandler(this.NameMstEditListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameMstEditListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nameMstNameKbn000BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameMstDataSet)).EndInit();
            this.nameListPanel.ResumeLayout(false);
            this.nameListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button koshinButton;
        private System.Windows.Forms.DataGridView nameListDataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel nameListPanel;
        private System.Windows.Forms.Label nameListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox nameKbnComboBox;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private DataSet.NameMstDataSet nameMstDataSet;
        private System.Windows.Forms.BindingSource nameMstNameKbn000BindingSource;
        private DataSet.NameMstDataSetTableAdapters.NameMstNameKbn000TableAdapter nameMstNameKbn000TableAdapter;
        private Control.NumberTextBox nameCdFromTextBox;
        private Control.NumberTextBox nameCdToTextBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn NameKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DeleteFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameKbnOldCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCdOldCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOldCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteFlgOldCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUpdateCol;
    }
}