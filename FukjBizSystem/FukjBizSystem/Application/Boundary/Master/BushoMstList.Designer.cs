namespace FukjBizSystem.Application.Boundary.Master
{
    partial class BushoMstListForm
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
            this.bushoListPanel = new System.Windows.Forms.Panel();
            this.bushoListCountLabel = new System.Windows.Forms.Label();
            this.bushoListDataGridView = new System.Windows.Forms.DataGridView();
            this.BushoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BushoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bushoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bushoNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bushoMstKensakuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bushoMstDataSet = new FukjBizSystem.Application.DataSet.BushoMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.bushoCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.bushoCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bushoNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.bushoMstKensakuTableAdapter = new FukjBizSystem.Application.DataSet.BushoMstDataSetTableAdapters.BushoMstKensakuTableAdapter();
            this.bushoListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bushoListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstKensakuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstDataSet)).BeginInit();
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
            // bushoListPanel
            // 
            this.bushoListPanel.Controls.Add(this.bushoListCountLabel);
            this.bushoListPanel.Controls.Add(this.bushoListDataGridView);
            this.bushoListPanel.Controls.Add(this.label4);
            this.bushoListPanel.Location = new System.Drawing.Point(0, 121);
            this.bushoListPanel.Name = "bushoListPanel";
            this.bushoListPanel.Size = new System.Drawing.Size(1103, 430);
            this.bushoListPanel.TabIndex = 12;
            // 
            // bushoListCountLabel
            // 
            this.bushoListCountLabel.AutoSize = true;
            this.bushoListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.bushoListCountLabel.Name = "bushoListCountLabel";
            this.bushoListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.bushoListCountLabel.TabIndex = 72;
            this.bushoListCountLabel.Text = "0件";
            // 
            // bushoListDataGridView
            // 
            this.bushoListDataGridView.AllowUserToAddRows = false;
            this.bushoListDataGridView.AllowUserToDeleteRows = false;
            this.bushoListDataGridView.AllowUserToResizeRows = false;
            this.bushoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bushoListDataGridView.AutoGenerateColumns = false;
            this.bushoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bushoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BushoCdCol,
            this.BushoNmCol,
            this.bushoCdDataGridViewTextBoxColumn,
            this.bushoNmDataGridViewTextBoxColumn});
            this.bushoListDataGridView.DataSource = this.bushoMstKensakuBindingSource;
            this.bushoListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.bushoListDataGridView.MultiSelect = false;
            this.bushoListDataGridView.Name = "bushoListDataGridView";
            this.bushoListDataGridView.ReadOnly = true;
            this.bushoListDataGridView.RowHeadersVisible = false;
            this.bushoListDataGridView.RowTemplate.Height = 21;
            this.bushoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bushoListDataGridView.Size = new System.Drawing.Size(1098, 404);
            this.bushoListDataGridView.TabIndex = 6;
            this.bushoListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bushoListDataGridView_CellDoubleClick);
            // 
            // BushoCdCol
            // 
            this.BushoCdCol.DataPropertyName = "BushoCd";
            this.BushoCdCol.HeaderText = "部署コード";
            this.BushoCdCol.MinimumWidth = 100;
            this.BushoCdCol.Name = "BushoCdCol";
            this.BushoCdCol.ReadOnly = true;
            // 
            // BushoNmCol
            // 
            this.BushoNmCol.DataPropertyName = "BushoNm";
            this.BushoNmCol.HeaderText = "部署名";
            this.BushoNmCol.MinimumWidth = 300;
            this.BushoNmCol.Name = "BushoNmCol";
            this.BushoNmCol.ReadOnly = true;
            this.BushoNmCol.Width = 300;
            // 
            // bushoCdDataGridViewTextBoxColumn
            // 
            this.bushoCdDataGridViewTextBoxColumn.DataPropertyName = "BushoCd";
            this.bushoCdDataGridViewTextBoxColumn.HeaderText = "BushoCd";
            this.bushoCdDataGridViewTextBoxColumn.Name = "bushoCdDataGridViewTextBoxColumn";
            this.bushoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.bushoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // bushoNmDataGridViewTextBoxColumn
            // 
            this.bushoNmDataGridViewTextBoxColumn.DataPropertyName = "BushoNm";
            this.bushoNmDataGridViewTextBoxColumn.HeaderText = "BushoNm";
            this.bushoNmDataGridViewTextBoxColumn.Name = "bushoNmDataGridViewTextBoxColumn";
            this.bushoNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.bushoNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // bushoMstKensakuBindingSource
            // 
            this.bushoMstKensakuBindingSource.DataMember = "BushoMstKensaku";
            this.bushoMstKensakuBindingSource.DataSource = this.bushoMstDataSet;
            // 
            // bushoMstDataSet
            // 
            this.bushoMstDataSet.DataSetName = "BushoMstDataSet";
            this.bushoMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.bushoCdToTextBox);
            this.searchPanel.Controls.Add(this.bushoCdFromTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.bushoNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 120);
            this.searchPanel.TabIndex = 11;
            // 
            // bushoCdToTextBox
            // 
            this.bushoCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.bushoCdToTextBox.CustomDigitParts = 0;
            this.bushoCdToTextBox.CustomFormat = null;
            this.bushoCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.bushoCdToTextBox.CustomReadOnly = false;
            this.bushoCdToTextBox.Location = new System.Drawing.Point(165, 36);
            this.bushoCdToTextBox.MaxLength = 2;
            this.bushoCdToTextBox.Name = "bushoCdToTextBox";
            this.bushoCdToTextBox.Size = new System.Drawing.Size(35, 27);
            this.bushoCdToTextBox.TabIndex = 1;
            this.bushoCdToTextBox.Leave += new System.EventHandler(this.bushoCdToTextBox_Leave);
            // 
            // bushoCdFromTextBox
            // 
            this.bushoCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.bushoCdFromTextBox.CustomDigitParts = 0;
            this.bushoCdFromTextBox.CustomFormat = null;
            this.bushoCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.bushoCdFromTextBox.CustomReadOnly = false;
            this.bushoCdFromTextBox.Location = new System.Drawing.Point(96, 36);
            this.bushoCdFromTextBox.MaxLength = 2;
            this.bushoCdFromTextBox.Name = "bushoCdFromTextBox";
            this.bushoCdFromTextBox.Size = new System.Drawing.Size(35, 27);
            this.bushoCdFromTextBox.TabIndex = 0;
            this.bushoCdFromTextBox.Leave += new System.EventHandler(this.bushoCdFromTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "～";
            // 
            // bushoNmTextBox
            // 
            this.bushoNmTextBox.Location = new System.Drawing.Point(96, 69);
            this.bushoNmTextBox.MaxLength = 20;
            this.bushoNmTextBox.Name = "bushoNmTextBox";
            this.bushoNmTextBox.Size = new System.Drawing.Size(242, 27);
            this.bushoNmTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "部署名";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 5;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 11;
            this.label19.Text = "部署コード";
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
            this.clearButton.Location = new System.Drawing.Point(884, 58);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 57);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 4;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // bushoMstKensakuTableAdapter
            // 
            this.bushoMstKensakuTableAdapter.ClearBeforeFill = true;
            // 
            // BushoMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.bushoListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BushoMstListForm";
            this.Text = "部署マスタ検索";
            this.Load += new System.EventHandler(this.BushoMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BushoMstListForm_KeyDown);
            this.bushoListPanel.ResumeLayout(false);
            this.bushoListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bushoListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstKensakuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel bushoListPanel;
        private System.Windows.Forms.Label bushoListCountLabel;
        private System.Windows.Forms.DataGridView bushoListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bushoNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private Control.NumberTextBox bushoCdToTextBox;
        private Control.NumberTextBox bushoCdFromTextBox;
        private DataSet.BushoMstDataSet bushoMstDataSet;
        private System.Windows.Forms.BindingSource bushoMstKensakuBindingSource;
        private DataSet.BushoMstDataSetTableAdapters.BushoMstKensakuTableAdapter bushoMstKensakuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn BushoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BushoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn bushoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bushoNmDataGridViewTextBoxColumn;

    }
}