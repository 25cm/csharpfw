namespace FukjBizSystem.Application.Boundary.Master
{
    partial class YakushokuMstListForm
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
            this.yakushokuListPanel = new System.Windows.Forms.Panel();
            this.yakushokuListCountLabel = new System.Windows.Forms.Label();
            this.yakushokuListDataGridView = new System.Windows.Forms.DataGridView();
            this.YakushokuCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YakushokuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YakushokuKbnCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YakushokuKbnNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yakushokuCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yakushokuKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yakushokuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yakushokuMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yakushokuMstDataSet = new FukjBizSystem.Application.DataSet.YakushokuMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.yakushokuCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.yakushokuCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.yakushokuKbnComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yakushokuNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.KensakuButton = new System.Windows.Forms.Button();
            this.yakushokuListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstDataSet)).BeginInit();
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
            // yakushokuListPanel
            // 
            this.yakushokuListPanel.Controls.Add(this.yakushokuListCountLabel);
            this.yakushokuListPanel.Controls.Add(this.yakushokuListDataGridView);
            this.yakushokuListPanel.Controls.Add(this.label4);
            this.yakushokuListPanel.Location = new System.Drawing.Point(0, 152);
            this.yakushokuListPanel.Name = "yakushokuListPanel";
            this.yakushokuListPanel.Size = new System.Drawing.Size(1103, 399);
            this.yakushokuListPanel.TabIndex = 12;
            // 
            // yakushokuListCountLabel
            // 
            this.yakushokuListCountLabel.AutoSize = true;
            this.yakushokuListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.yakushokuListCountLabel.Name = "yakushokuListCountLabel";
            this.yakushokuListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.yakushokuListCountLabel.TabIndex = 1;
            this.yakushokuListCountLabel.Text = "0件";
            // 
            // yakushokuListDataGridView
            // 
            this.yakushokuListDataGridView.AllowUserToAddRows = false;
            this.yakushokuListDataGridView.AllowUserToDeleteRows = false;
            this.yakushokuListDataGridView.AllowUserToResizeRows = false;
            this.yakushokuListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yakushokuListDataGridView.AutoGenerateColumns = false;
            this.yakushokuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yakushokuListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YakushokuCdCol,
            this.YakushokuNmCol,
            this.YakushokuKbnCdCol,
            this.YakushokuKbnNmCol,
            this.yakushokuCdDataGridViewTextBoxColumn,
            this.yakushokuKbnDataGridViewTextBoxColumn,
            this.yakushokuNmDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.yakushokuListDataGridView.DataMember = "YakushokuMstKensaku";
            this.yakushokuListDataGridView.DataSource = this.yakushokuMstDataSetBindingSource;
            this.yakushokuListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.yakushokuListDataGridView.MultiSelect = false;
            this.yakushokuListDataGridView.Name = "yakushokuListDataGridView";
            this.yakushokuListDataGridView.RowHeadersVisible = false;
            this.yakushokuListDataGridView.RowTemplate.Height = 21;
            this.yakushokuListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.yakushokuListDataGridView.Size = new System.Drawing.Size(1100, 373);
            this.yakushokuListDataGridView.TabIndex = 2;
            this.yakushokuListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.yakushokuListDataGridView_CellDoubleClick);
            // 
            // YakushokuCdCol
            // 
            this.YakushokuCdCol.DataPropertyName = "YakushokuCd";
            this.YakushokuCdCol.HeaderText = "役職コード";
            this.YakushokuCdCol.MinimumWidth = 120;
            this.YakushokuCdCol.Name = "YakushokuCdCol";
            this.YakushokuCdCol.ReadOnly = true;
            this.YakushokuCdCol.Width = 120;
            // 
            // YakushokuNmCol
            // 
            this.YakushokuNmCol.DataPropertyName = "YakushokuNm";
            this.YakushokuNmCol.HeaderText = "役職名";
            this.YakushokuNmCol.MinimumWidth = 200;
            this.YakushokuNmCol.Name = "YakushokuNmCol";
            this.YakushokuNmCol.ReadOnly = true;
            this.YakushokuNmCol.Width = 200;
            // 
            // YakushokuKbnCdCol
            // 
            this.YakushokuKbnCdCol.DataPropertyName = "YakushokuKbn";
            this.YakushokuKbnCdCol.HeaderText = "役職区分";
            this.YakushokuKbnCdCol.MinimumWidth = 110;
            this.YakushokuKbnCdCol.Name = "YakushokuKbnCdCol";
            this.YakushokuKbnCdCol.ReadOnly = true;
            this.YakushokuKbnCdCol.Width = 110;
            // 
            // YakushokuKbnNmCol
            // 
            this.YakushokuKbnNmCol.DataPropertyName = "Name";
            this.YakushokuKbnNmCol.HeaderText = "役職区分名";
            this.YakushokuKbnNmCol.MinimumWidth = 300;
            this.YakushokuKbnNmCol.Name = "YakushokuKbnNmCol";
            this.YakushokuKbnNmCol.ReadOnly = true;
            this.YakushokuKbnNmCol.Width = 300;
            // 
            // yakushokuCdDataGridViewTextBoxColumn
            // 
            this.yakushokuCdDataGridViewTextBoxColumn.DataPropertyName = "YakushokuCd";
            this.yakushokuCdDataGridViewTextBoxColumn.HeaderText = "YakushokuCd";
            this.yakushokuCdDataGridViewTextBoxColumn.Name = "yakushokuCdDataGridViewTextBoxColumn";
            this.yakushokuCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // yakushokuKbnDataGridViewTextBoxColumn
            // 
            this.yakushokuKbnDataGridViewTextBoxColumn.DataPropertyName = "YakushokuKbn";
            this.yakushokuKbnDataGridViewTextBoxColumn.HeaderText = "YakushokuKbn";
            this.yakushokuKbnDataGridViewTextBoxColumn.Name = "yakushokuKbnDataGridViewTextBoxColumn";
            this.yakushokuKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // yakushokuNmDataGridViewTextBoxColumn
            // 
            this.yakushokuNmDataGridViewTextBoxColumn.DataPropertyName = "YakushokuNm";
            this.yakushokuNmDataGridViewTextBoxColumn.HeaderText = "YakushokuNm";
            this.yakushokuNmDataGridViewTextBoxColumn.Name = "yakushokuNmDataGridViewTextBoxColumn";
            this.yakushokuNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // yakushokuMstDataSetBindingSource
            // 
            this.yakushokuMstDataSetBindingSource.DataSource = this.yakushokuMstDataSet;
            this.yakushokuMstDataSetBindingSource.Position = 0;
            // 
            // yakushokuMstDataSet
            // 
            this.yakushokuMstDataSet.DataSetName = "YakushokuMstDataSet";
            this.yakushokuMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.yakushokuCdToTextBox);
            this.searchPanel.Controls.Add(this.yakushokuCdFromTextBox);
            this.searchPanel.Controls.Add(this.yakushokuKbnComboBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.yakushokuNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.ViewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.ClearButton);
            this.searchPanel.Controls.Add(this.KensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 153);
            this.searchPanel.TabIndex = 11;
            // 
            // yakushokuCdToTextBox
            // 
            this.yakushokuCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.yakushokuCdToTextBox.CustomDigitParts = 0;
            this.yakushokuCdToTextBox.CustomFormat = null;
            this.yakushokuCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.yakushokuCdToTextBox.CustomReadOnly = false;
            this.yakushokuCdToTextBox.Location = new System.Drawing.Point(170, 32);
            this.yakushokuCdToTextBox.MaxLength = 2;
            this.yakushokuCdToTextBox.Name = "yakushokuCdToTextBox";
            this.yakushokuCdToTextBox.Size = new System.Drawing.Size(40, 27);
            this.yakushokuCdToTextBox.TabIndex = 4;
            this.yakushokuCdToTextBox.Leave += new System.EventHandler(this.yakushokuCdToTextBox_Leave);
            // 
            // yakushokuCdFromTextBox
            // 
            this.yakushokuCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.yakushokuCdFromTextBox.CustomDigitParts = 0;
            this.yakushokuCdFromTextBox.CustomFormat = null;
            this.yakushokuCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.yakushokuCdFromTextBox.CustomReadOnly = false;
            this.yakushokuCdFromTextBox.Location = new System.Drawing.Point(96, 32);
            this.yakushokuCdFromTextBox.MaxLength = 2;
            this.yakushokuCdFromTextBox.Name = "yakushokuCdFromTextBox";
            this.yakushokuCdFromTextBox.Size = new System.Drawing.Size(40, 27);
            this.yakushokuCdFromTextBox.TabIndex = 2;
            this.yakushokuCdFromTextBox.Leave += new System.EventHandler(this.yakushokuCdFromTextBox_Leave);
            // 
            // yakushokuKbnComboBox
            // 
            this.yakushokuKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yakushokuKbnComboBox.FormattingEnabled = true;
            this.yakushokuKbnComboBox.Location = new System.Drawing.Point(96, 96);
            this.yakushokuKbnComboBox.Name = "yakushokuKbnComboBox";
            this.yakushokuKbnComboBox.Size = new System.Drawing.Size(200, 28);
            this.yakushokuKbnComboBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "役職区分";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // yakushokuNmTextBox
            // 
            this.yakushokuNmTextBox.Location = new System.Drawing.Point(96, 63);
            this.yakushokuNmTextBox.MaxLength = 10;
            this.yakushokuNmTextBox.Name = "yakushokuNmTextBox";
            this.yakushokuNmTextBox.Size = new System.Drawing.Size(114, 27);
            this.yakushokuNmTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "役職名";
            // 
            // ViewChangeButton
            // 
            this.ViewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.ViewChangeButton.Name = "ViewChangeButton";
            this.ViewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.ViewChangeButton.TabIndex = 11;
            this.ViewChangeButton.Text = "▲";
            this.ViewChangeButton.UseVisualStyleBackColor = true;
            this.ViewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "役職コード";
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
            this.ClearButton.Location = new System.Drawing.Point(884, 110);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(101, 37);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "F7:クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // KensakuButton
            // 
            this.KensakuButton.Location = new System.Drawing.Point(991, 109);
            this.KensakuButton.Name = "KensakuButton";
            this.KensakuButton.Size = new System.Drawing.Size(101, 37);
            this.KensakuButton.TabIndex = 10;
            this.KensakuButton.Text = "F8:検索";
            this.KensakuButton.UseVisualStyleBackColor = true;
            this.KensakuButton.Click += new System.EventHandler(this.KensakuButton_Click);
            // 
            // YakushokuMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.TojiruButton);
            this.Controls.Add(this.ShosaiButton);
            this.Controls.Add(this.TorokuButton);
            this.Controls.Add(this.yakushokuListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YakushokuMstListForm";
            this.Text = "役職マスタ検索";
            this.Load += new System.EventHandler(this.YakushokuMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YakushokuMstListForm_KeyDown);
            this.yakushokuListPanel.ResumeLayout(false);
            this.yakushokuListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.Button TojiruButton;
        private System.Windows.Forms.Button ShosaiButton;
        private System.Windows.Forms.Button TorokuButton;
        private System.Windows.Forms.Panel yakushokuListPanel;
        private System.Windows.Forms.Label yakushokuListCountLabel;
        private System.Windows.Forms.DataGridView yakushokuListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yakushokuNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ViewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button KensakuButton;
        private System.Windows.Forms.ComboBox yakushokuKbnComboBox;
        private System.Windows.Forms.Label label5;
        private Control.NumberTextBox yakushokuCdToTextBox;
        private Control.NumberTextBox yakushokuCdFromTextBox;
        private System.Windows.Forms.BindingSource yakushokuMstDataSetBindingSource;
        private DataSet.YakushokuMstDataSet yakushokuMstDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn YakushokuCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YakushokuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YakushokuKbnCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YakushokuKbnNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn yakushokuCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yakushokuKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yakushokuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;

    }
}