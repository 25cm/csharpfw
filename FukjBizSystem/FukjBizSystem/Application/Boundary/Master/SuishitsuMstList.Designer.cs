namespace FukjBizSystem.Application.Boundary.Master
{
    partial class SuishitsuMstListForm
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
            this.suishitsuMstListDataGridView = new System.Windows.Forms.DataGridView();
            this.ShishoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuishitsuCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuishitsuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuShishoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoZipCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoAdrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoTelNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoFaxNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoFreeDialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suishitsuMstDataSet = new FukjBizSystem.Application.DataSet.SuishitsuMstDataSet();
            this.torokuButton = new System.Windows.Forms.Button();
            this.suishitsuMstListPanel = new System.Windows.Forms.Panel();
            this.suishitsuMstListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.suishitsuNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.shishoNmComboBox = new System.Windows.Forms.ComboBox();
            this.suishitsuCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.suishitsuCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSet)).BeginInit();
            this.suishitsuMstListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // suishitsuMstListDataGridView
            // 
            this.suishitsuMstListDataGridView.AllowUserToAddRows = false;
            this.suishitsuMstListDataGridView.AllowUserToDeleteRows = false;
            this.suishitsuMstListDataGridView.AllowUserToResizeRows = false;
            this.suishitsuMstListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suishitsuMstListDataGridView.AutoGenerateColumns = false;
            this.suishitsuMstListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suishitsuMstListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShishoCdCol,
            this.ShishoNmCol,
            this.SuishitsuCdCol,
            this.SuishitsuNmCol,
            this.suishitsuCdDataGridViewTextBoxColumn,
            this.suishitsuNmDataGridViewTextBoxColumn,
            this.suishitsuShishoCdDataGridViewTextBoxColumn,
            this.shishoCdDataGridViewTextBoxColumn,
            this.shishoNmDataGridViewTextBoxColumn,
            this.shishoZipCdDataGridViewTextBoxColumn,
            this.shishoAdrDataGridViewTextBoxColumn,
            this.shishoTelNoDataGridViewTextBoxColumn,
            this.shishoFaxNoDataGridViewTextBoxColumn,
            this.shishoFreeDialDataGridViewTextBoxColumn});
            this.suishitsuMstListDataGridView.DataMember = "SuishitsuMstKensaku";
            this.suishitsuMstListDataGridView.DataSource = this.suishitsuMstDataSetBindingSource;
            this.suishitsuMstListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.suishitsuMstListDataGridView.MultiSelect = false;
            this.suishitsuMstListDataGridView.Name = "suishitsuMstListDataGridView";
            this.suishitsuMstListDataGridView.RowHeadersVisible = false;
            this.suishitsuMstListDataGridView.RowTemplate.Height = 21;
            this.suishitsuMstListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suishitsuMstListDataGridView.Size = new System.Drawing.Size(1085, 312);
            this.suishitsuMstListDataGridView.TabIndex = 0;
            this.suishitsuMstListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suishitsuMstListDataGridView_CellDoubleClick);
            // 
            // ShishoCdCol
            // 
            this.ShishoCdCol.DataPropertyName = "ShishoCd";
            this.ShishoCdCol.HeaderText = "支所コード";
            this.ShishoCdCol.MinimumWidth = 110;
            this.ShishoCdCol.Name = "ShishoCdCol";
            this.ShishoCdCol.ReadOnly = true;
            this.ShishoCdCol.Width = 110;
            // 
            // ShishoNmCol
            // 
            this.ShishoNmCol.DataPropertyName = "ShishoNm";
            this.ShishoNmCol.HeaderText = "支所名";
            this.ShishoNmCol.MinimumWidth = 200;
            this.ShishoNmCol.Name = "ShishoNmCol";
            this.ShishoNmCol.ReadOnly = true;
            this.ShishoNmCol.Width = 200;
            // 
            // SuishitsuCdCol
            // 
            this.SuishitsuCdCol.DataPropertyName = "SuishitsuCd";
            this.SuishitsuCdCol.HeaderText = "水質コード";
            this.SuishitsuCdCol.MinimumWidth = 110;
            this.SuishitsuCdCol.Name = "SuishitsuCdCol";
            this.SuishitsuCdCol.ReadOnly = true;
            this.SuishitsuCdCol.Width = 110;
            // 
            // SuishitsuNmCol
            // 
            this.SuishitsuNmCol.DataPropertyName = "SuishitsuNm";
            this.SuishitsuNmCol.HeaderText = "水質名称";
            this.SuishitsuNmCol.MinimumWidth = 300;
            this.SuishitsuNmCol.Name = "SuishitsuNmCol";
            this.SuishitsuNmCol.ReadOnly = true;
            this.SuishitsuNmCol.Width = 300;
            // 
            // suishitsuCdDataGridViewTextBoxColumn
            // 
            this.suishitsuCdDataGridViewTextBoxColumn.DataPropertyName = "SuishitsuCd";
            this.suishitsuCdDataGridViewTextBoxColumn.HeaderText = "SuishitsuCd";
            this.suishitsuCdDataGridViewTextBoxColumn.Name = "suishitsuCdDataGridViewTextBoxColumn";
            this.suishitsuCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // suishitsuNmDataGridViewTextBoxColumn
            // 
            this.suishitsuNmDataGridViewTextBoxColumn.DataPropertyName = "SuishitsuNm";
            this.suishitsuNmDataGridViewTextBoxColumn.HeaderText = "SuishitsuNm";
            this.suishitsuNmDataGridViewTextBoxColumn.Name = "suishitsuNmDataGridViewTextBoxColumn";
            this.suishitsuNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // suishitsuShishoCdDataGridViewTextBoxColumn
            // 
            this.suishitsuShishoCdDataGridViewTextBoxColumn.DataPropertyName = "SuishitsuShishoCd";
            this.suishitsuShishoCdDataGridViewTextBoxColumn.HeaderText = "SuishitsuShishoCd";
            this.suishitsuShishoCdDataGridViewTextBoxColumn.Name = "suishitsuShishoCdDataGridViewTextBoxColumn";
            this.suishitsuShishoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoCdDataGridViewTextBoxColumn
            // 
            this.shishoCdDataGridViewTextBoxColumn.DataPropertyName = "ShishoCd";
            this.shishoCdDataGridViewTextBoxColumn.HeaderText = "ShishoCd";
            this.shishoCdDataGridViewTextBoxColumn.Name = "shishoCdDataGridViewTextBoxColumn";
            this.shishoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoNmDataGridViewTextBoxColumn
            // 
            this.shishoNmDataGridViewTextBoxColumn.DataPropertyName = "ShishoNm";
            this.shishoNmDataGridViewTextBoxColumn.HeaderText = "ShishoNm";
            this.shishoNmDataGridViewTextBoxColumn.Name = "shishoNmDataGridViewTextBoxColumn";
            this.shishoNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoZipCdDataGridViewTextBoxColumn
            // 
            this.shishoZipCdDataGridViewTextBoxColumn.DataPropertyName = "ShishoZipCd";
            this.shishoZipCdDataGridViewTextBoxColumn.HeaderText = "ShishoZipCd";
            this.shishoZipCdDataGridViewTextBoxColumn.Name = "shishoZipCdDataGridViewTextBoxColumn";
            this.shishoZipCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoAdrDataGridViewTextBoxColumn
            // 
            this.shishoAdrDataGridViewTextBoxColumn.DataPropertyName = "ShishoAdr";
            this.shishoAdrDataGridViewTextBoxColumn.HeaderText = "ShishoAdr";
            this.shishoAdrDataGridViewTextBoxColumn.Name = "shishoAdrDataGridViewTextBoxColumn";
            this.shishoAdrDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoTelNoDataGridViewTextBoxColumn
            // 
            this.shishoTelNoDataGridViewTextBoxColumn.DataPropertyName = "ShishoTelNo";
            this.shishoTelNoDataGridViewTextBoxColumn.HeaderText = "ShishoTelNo";
            this.shishoTelNoDataGridViewTextBoxColumn.Name = "shishoTelNoDataGridViewTextBoxColumn";
            this.shishoTelNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoFaxNoDataGridViewTextBoxColumn
            // 
            this.shishoFaxNoDataGridViewTextBoxColumn.DataPropertyName = "ShishoFaxNo";
            this.shishoFaxNoDataGridViewTextBoxColumn.HeaderText = "ShishoFaxNo";
            this.shishoFaxNoDataGridViewTextBoxColumn.Name = "shishoFaxNoDataGridViewTextBoxColumn";
            this.shishoFaxNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // shishoFreeDialDataGridViewTextBoxColumn
            // 
            this.shishoFreeDialDataGridViewTextBoxColumn.DataPropertyName = "ShishoFreeDial";
            this.shishoFreeDialDataGridViewTextBoxColumn.HeaderText = "ShishoFreeDial";
            this.shishoFreeDialDataGridViewTextBoxColumn.Name = "shishoFreeDialDataGridViewTextBoxColumn";
            this.shishoFreeDialDataGridViewTextBoxColumn.Visible = false;
            // 
            // suishitsuMstDataSetBindingSource
            // 
            this.suishitsuMstDataSetBindingSource.DataSource = this.suishitsuMstDataSet;
            this.suishitsuMstDataSetBindingSource.Position = 0;
            // 
            // suishitsuMstDataSet
            // 
            this.suishitsuMstDataSet.DataSetName = "SuishitsuMstDataSet";
            this.suishitsuMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(582, 544);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:新規登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // suishitsuMstListPanel
            // 
            this.suishitsuMstListPanel.Controls.Add(this.suishitsuMstListCountLabel);
            this.suishitsuMstListPanel.Controls.Add(this.label4);
            this.suishitsuMstListPanel.Controls.Add(this.suishitsuMstListDataGridView);
            this.suishitsuMstListPanel.Location = new System.Drawing.Point(1, 187);
            this.suishitsuMstListPanel.Name = "suishitsuMstListPanel";
            this.suishitsuMstListPanel.Size = new System.Drawing.Size(1090, 339);
            this.suishitsuMstListPanel.TabIndex = 1;
            // 
            // suishitsuMstListCountLabel
            // 
            this.suishitsuMstListCountLabel.AutoSize = true;
            this.suishitsuMstListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.suishitsuMstListCountLabel.Name = "suishitsuMstListCountLabel";
            this.suishitsuMstListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.suishitsuMstListCountLabel.TabIndex = 2;
            this.suishitsuMstListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "検索結果：";
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(718, 544);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 3;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "支所";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(854, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 4;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // suishitsuNmTextBox
            // 
            this.suishitsuNmTextBox.Location = new System.Drawing.Point(98, 108);
            this.suishitsuNmTextBox.MaxLength = 30;
            this.suishitsuNmTextBox.Name = "suishitsuNmTextBox";
            this.suishitsuNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.suishitsuNmTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "水質名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 11;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "水質コード";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.shishoNmComboBox);
            this.searchPanel.Controls.Add(this.suishitsuCdToTextBox);
            this.searchPanel.Controls.Add(this.suishitsuCdFromTextBox);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.suishitsuNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 184);
            this.searchPanel.TabIndex = 0;
            // 
            // shishoNmComboBox
            // 
            this.shishoNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shishoNmComboBox.FormattingEnabled = true;
            this.shishoNmComboBox.Location = new System.Drawing.Point(98, 35);
            this.shishoNmComboBox.Name = "shishoNmComboBox";
            this.shishoNmComboBox.Size = new System.Drawing.Size(130, 28);
            this.shishoNmComboBox.TabIndex = 2;
            // 
            // suishitsuCdToTextBox
            // 
            this.suishitsuCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.suishitsuCdToTextBox.CustomDigitParts = 0;
            this.suishitsuCdToTextBox.CustomFormat = null;
            this.suishitsuCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.suishitsuCdToTextBox.CustomReadOnly = false;
            this.suishitsuCdToTextBox.Location = new System.Drawing.Point(180, 75);
            this.suishitsuCdToTextBox.MaxLength = 3;
            this.suishitsuCdToTextBox.Name = "suishitsuCdToTextBox";
            this.suishitsuCdToTextBox.Size = new System.Drawing.Size(48, 27);
            this.suishitsuCdToTextBox.TabIndex = 6;
            this.suishitsuCdToTextBox.Leave += new System.EventHandler(this.suishitsuCdToTextBox_Leave);
            // 
            // suishitsuCdFromTextBox
            // 
            this.suishitsuCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.suishitsuCdFromTextBox.CustomDigitParts = 0;
            this.suishitsuCdFromTextBox.CustomFormat = null;
            this.suishitsuCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.suishitsuCdFromTextBox.CustomReadOnly = false;
            this.suishitsuCdFromTextBox.Location = new System.Drawing.Point(98, 75);
            this.suishitsuCdFromTextBox.MaxLength = 3;
            this.suishitsuCdFromTextBox.Name = "suishitsuCdFromTextBox";
            this.suishitsuCdFromTextBox.Size = new System.Drawing.Size(48, 27);
            this.suishitsuCdFromTextBox.TabIndex = 4;
            this.suishitsuCdFromTextBox.Leave += new System.EventHandler(this.suishitsuCdFromTextBox_Leave);
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
            this.clearButton.Location = new System.Drawing.Point(878, 133);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(985, 132);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 10;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(990, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // SuishitsuMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.suishitsuMstListPanel);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SuishitsuMstListForm";
            this.Text = "水質マスタ検索";
            this.Load += new System.EventHandler(this.SuishitsuMstList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuishitsuMstListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSet)).EndInit();
            this.suishitsuMstListPanel.ResumeLayout(false);
            this.suishitsuMstListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView suishitsuMstListDataGridView;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel suishitsuMstListPanel;
        private System.Windows.Forms.Label suishitsuMstListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.TextBox suishitsuNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.BindingSource suishitsuMstDataSetBindingSource;
        private DataSet.SuishitsuMstDataSet suishitsuMstDataSet;
        private Control.NumberTextBox suishitsuCdFromTextBox;
        private Control.NumberTextBox suishitsuCdToTextBox;
        private System.Windows.Forms.ComboBox shishoNmComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuishitsuCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuishitsuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn suishitsuCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suishitsuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suishitsuShishoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoZipCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoAdrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoTelNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoFaxNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoFreeDialDataGridViewTextBoxColumn;

    }
}