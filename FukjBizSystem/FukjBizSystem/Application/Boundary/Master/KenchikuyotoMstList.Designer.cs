namespace FukjBizSystem.Application.Boundary.Master
{
    partial class KenchikuyotoMstListForm
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
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.kenchikuyotoListPanel = new System.Windows.Forms.Panel();
            this.kenchikuyotoListCountLabel = new System.Windows.Forms.Label();
            this.kenchikuyotoListDataGridView = new System.Windows.Forms.DataGridView();
            this.KenchikuyotoDaibunruiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KenchikuyotoDaibunruiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KenchikuyotoShobunruiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KenchikuyotoShobunruiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KenchikuyotoRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KenchikuyotoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kenchikuyotoDaibunruiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kenchikuyotoShobunruiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kenchikuyotoRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kenchikuyotoNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kenchikuyotoShobunruiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kenchikuyotoMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kenchikuyotoMstDataSet = new FukjBizSystem.Application.DataSet.KenchikuyotoMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.kenchikuyotoDaibunruiNmComboBox = new System.Windows.Forms.ComboBox();
            this.kenchikuyotoNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.kenchikuyotoListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kenchikuyotoListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kenchikuyotoMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kenchikuyotoMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(860, 555);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 6;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(994, 555);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 7;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(726, 555);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 5;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(586, 555);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 4;
            this.torokuButton.Text = "F1:新規登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // kenchikuyotoListPanel
            // 
            this.kenchikuyotoListPanel.Controls.Add(this.kenchikuyotoListCountLabel);
            this.kenchikuyotoListPanel.Controls.Add(this.kenchikuyotoListDataGridView);
            this.kenchikuyotoListPanel.Controls.Add(this.label4);
            this.kenchikuyotoListPanel.Location = new System.Drawing.Point(0, 113);
            this.kenchikuyotoListPanel.Name = "kenchikuyotoListPanel";
            this.kenchikuyotoListPanel.Size = new System.Drawing.Size(1103, 438);
            this.kenchikuyotoListPanel.TabIndex = 3;
            // 
            // kenchikuyotoListCountLabel
            // 
            this.kenchikuyotoListCountLabel.AutoSize = true;
            this.kenchikuyotoListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.kenchikuyotoListCountLabel.Name = "kenchikuyotoListCountLabel";
            this.kenchikuyotoListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.kenchikuyotoListCountLabel.TabIndex = 0;
            this.kenchikuyotoListCountLabel.Text = "0件";
            // 
            // kenchikuyotoListDataGridView
            // 
            this.kenchikuyotoListDataGridView.AllowUserToAddRows = false;
            this.kenchikuyotoListDataGridView.AllowUserToDeleteRows = false;
            this.kenchikuyotoListDataGridView.AllowUserToResizeRows = false;
            this.kenchikuyotoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kenchikuyotoListDataGridView.AutoGenerateColumns = false;
            this.kenchikuyotoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kenchikuyotoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KenchikuyotoDaibunruiCdCol,
            this.KenchikuyotoDaibunruiNmCol,
            this.KenchikuyotoShobunruiCdCol,
            this.KenchikuyotoShobunruiNmCol,
            this.KenchikuyotoRenbanCol,
            this.KenchikuyotoNmCol,
            this.kenchikuyotoDaibunruiDataGridViewTextBoxColumn,
            this.kenchikuyotoShobunruiDataGridViewTextBoxColumn,
            this.kenchikuyotoRenbanDataGridViewTextBoxColumn,
            this.kenchikuyotoNmDataGridViewTextBoxColumn,
            this.kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn,
            this.kenchikuyotoShobunruiNmDataGridViewTextBoxColumn});
            this.kenchikuyotoListDataGridView.DataMember = "KenchikuyotoMstKensaku";
            this.kenchikuyotoListDataGridView.DataSource = this.kenchikuyotoMstDataSetBindingSource;
            this.kenchikuyotoListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.kenchikuyotoListDataGridView.MultiSelect = false;
            this.kenchikuyotoListDataGridView.Name = "kenchikuyotoListDataGridView";
            this.kenchikuyotoListDataGridView.ReadOnly = true;
            this.kenchikuyotoListDataGridView.RowHeadersVisible = false;
            this.kenchikuyotoListDataGridView.RowTemplate.Height = 21;
            this.kenchikuyotoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kenchikuyotoListDataGridView.Size = new System.Drawing.Size(1100, 412);
            this.kenchikuyotoListDataGridView.TabIndex = 1;
            this.kenchikuyotoListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kenchikuyotoListDataGridView_CellDoubleClick);
            // 
            // KenchikuyotoDaibunruiCdCol
            // 
            this.KenchikuyotoDaibunruiCdCol.DataPropertyName = "KenchikuyotoDaibunrui";
            this.KenchikuyotoDaibunruiCdCol.HeaderText = "建築用途大分類";
            this.KenchikuyotoDaibunruiCdCol.MinimumWidth = 130;
            this.KenchikuyotoDaibunruiCdCol.Name = "KenchikuyotoDaibunruiCdCol";
            this.KenchikuyotoDaibunruiCdCol.ReadOnly = true;
            this.KenchikuyotoDaibunruiCdCol.Width = 130;
            // 
            // KenchikuyotoDaibunruiNmCol
            // 
            this.KenchikuyotoDaibunruiNmCol.DataPropertyName = "KenchikuyotoDaibunruiNm";
            this.KenchikuyotoDaibunruiNmCol.HeaderText = "建築用途大分類名称";
            this.KenchikuyotoDaibunruiNmCol.MinimumWidth = 200;
            this.KenchikuyotoDaibunruiNmCol.Name = "KenchikuyotoDaibunruiNmCol";
            this.KenchikuyotoDaibunruiNmCol.ReadOnly = true;
            this.KenchikuyotoDaibunruiNmCol.Width = 200;
            // 
            // KenchikuyotoShobunruiCdCol
            // 
            this.KenchikuyotoShobunruiCdCol.DataPropertyName = "KenchikuyotoShobunrui";
            this.KenchikuyotoShobunruiCdCol.HeaderText = "建築用途小分類";
            this.KenchikuyotoShobunruiCdCol.MinimumWidth = 130;
            this.KenchikuyotoShobunruiCdCol.Name = "KenchikuyotoShobunruiCdCol";
            this.KenchikuyotoShobunruiCdCol.ReadOnly = true;
            this.KenchikuyotoShobunruiCdCol.Width = 130;
            // 
            // KenchikuyotoShobunruiNmCol
            // 
            this.KenchikuyotoShobunruiNmCol.DataPropertyName = "KenchikuyotoShobunruiNm";
            this.KenchikuyotoShobunruiNmCol.HeaderText = "建築用途小分類名称";
            this.KenchikuyotoShobunruiNmCol.MinimumWidth = 200;
            this.KenchikuyotoShobunruiNmCol.Name = "KenchikuyotoShobunruiNmCol";
            this.KenchikuyotoShobunruiNmCol.ReadOnly = true;
            this.KenchikuyotoShobunruiNmCol.Width = 200;
            // 
            // KenchikuyotoRenbanCol
            // 
            this.KenchikuyotoRenbanCol.DataPropertyName = "KenchikuyotoRenban";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KenchikuyotoRenbanCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.KenchikuyotoRenbanCol.HeaderText = "連番";
            this.KenchikuyotoRenbanCol.MinimumWidth = 100;
            this.KenchikuyotoRenbanCol.Name = "KenchikuyotoRenbanCol";
            this.KenchikuyotoRenbanCol.ReadOnly = true;
            // 
            // KenchikuyotoNmCol
            // 
            this.KenchikuyotoNmCol.DataPropertyName = "KenchikuyotoNm";
            this.KenchikuyotoNmCol.HeaderText = "建築用途名称";
            this.KenchikuyotoNmCol.MinimumWidth = 200;
            this.KenchikuyotoNmCol.Name = "KenchikuyotoNmCol";
            this.KenchikuyotoNmCol.ReadOnly = true;
            this.KenchikuyotoNmCol.Width = 200;
            // 
            // kenchikuyotoDaibunruiDataGridViewTextBoxColumn
            // 
            this.kenchikuyotoDaibunruiDataGridViewTextBoxColumn.DataPropertyName = "KenchikuyotoDaibunrui";
            this.kenchikuyotoDaibunruiDataGridViewTextBoxColumn.HeaderText = "KenchikuyotoDaibunrui";
            this.kenchikuyotoDaibunruiDataGridViewTextBoxColumn.Name = "kenchikuyotoDaibunruiDataGridViewTextBoxColumn";
            this.kenchikuyotoDaibunruiDataGridViewTextBoxColumn.ReadOnly = true;
            this.kenchikuyotoDaibunruiDataGridViewTextBoxColumn.Visible = false;
            // 
            // kenchikuyotoShobunruiDataGridViewTextBoxColumn
            // 
            this.kenchikuyotoShobunruiDataGridViewTextBoxColumn.DataPropertyName = "KenchikuyotoShobunrui";
            this.kenchikuyotoShobunruiDataGridViewTextBoxColumn.HeaderText = "KenchikuyotoShobunrui";
            this.kenchikuyotoShobunruiDataGridViewTextBoxColumn.Name = "kenchikuyotoShobunruiDataGridViewTextBoxColumn";
            this.kenchikuyotoShobunruiDataGridViewTextBoxColumn.ReadOnly = true;
            this.kenchikuyotoShobunruiDataGridViewTextBoxColumn.Visible = false;
            // 
            // kenchikuyotoRenbanDataGridViewTextBoxColumn
            // 
            this.kenchikuyotoRenbanDataGridViewTextBoxColumn.DataPropertyName = "KenchikuyotoRenban";
            this.kenchikuyotoRenbanDataGridViewTextBoxColumn.HeaderText = "KenchikuyotoRenban";
            this.kenchikuyotoRenbanDataGridViewTextBoxColumn.Name = "kenchikuyotoRenbanDataGridViewTextBoxColumn";
            this.kenchikuyotoRenbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.kenchikuyotoRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // kenchikuyotoNmDataGridViewTextBoxColumn
            // 
            this.kenchikuyotoNmDataGridViewTextBoxColumn.DataPropertyName = "KenchikuyotoNm";
            this.kenchikuyotoNmDataGridViewTextBoxColumn.HeaderText = "KenchikuyotoNm";
            this.kenchikuyotoNmDataGridViewTextBoxColumn.Name = "kenchikuyotoNmDataGridViewTextBoxColumn";
            this.kenchikuyotoNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.kenchikuyotoNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn
            // 
            this.kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn.DataPropertyName = "KenchikuyotoDaibunruiNm";
            this.kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn.HeaderText = "KenchikuyotoDaibunruiNm";
            this.kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn.Name = "kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn";
            this.kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // kenchikuyotoShobunruiNmDataGridViewTextBoxColumn
            // 
            this.kenchikuyotoShobunruiNmDataGridViewTextBoxColumn.DataPropertyName = "KenchikuyotoShobunruiNm";
            this.kenchikuyotoShobunruiNmDataGridViewTextBoxColumn.HeaderText = "KenchikuyotoShobunruiNm";
            this.kenchikuyotoShobunruiNmDataGridViewTextBoxColumn.Name = "kenchikuyotoShobunruiNmDataGridViewTextBoxColumn";
            this.kenchikuyotoShobunruiNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.kenchikuyotoShobunruiNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // kenchikuyotoMstDataSetBindingSource
            // 
            this.kenchikuyotoMstDataSetBindingSource.DataSource = this.kenchikuyotoMstDataSet;
            this.kenchikuyotoMstDataSetBindingSource.Position = 0;
            // 
            // kenchikuyotoMstDataSet
            // 
            this.kenchikuyotoMstDataSet.DataSetName = "KenchikuyotoMstDataSet";
            this.kenchikuyotoMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.kenchikuyotoDaibunruiNmComboBox);
            this.searchPanel.Controls.Add(this.kenchikuyotoNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 113);
            this.searchPanel.TabIndex = 2;
            // 
            // kenchikuyotoDaibunruiNmComboBox
            // 
            this.kenchikuyotoDaibunruiNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kenchikuyotoDaibunruiNmComboBox.FormattingEnabled = true;
            this.kenchikuyotoDaibunruiNmComboBox.Location = new System.Drawing.Point(148, 33);
            this.kenchikuyotoDaibunruiNmComboBox.Name = "kenchikuyotoDaibunruiNmComboBox";
            this.kenchikuyotoDaibunruiNmComboBox.Size = new System.Drawing.Size(300, 28);
            this.kenchikuyotoDaibunruiNmComboBox.TabIndex = 0;
            // 
            // kenchikuyotoNmTextBox
            // 
            this.kenchikuyotoNmTextBox.Location = new System.Drawing.Point(148, 67);
            this.kenchikuyotoNmTextBox.MaxLength = 20;
            this.kenchikuyotoNmTextBox.Name = "kenchikuyotoNmTextBox";
            this.kenchikuyotoNmTextBox.Size = new System.Drawing.Size(300, 27);
            this.kenchikuyotoNmTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "建築用途名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 4;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 20);
            this.label19.TabIndex = 11;
            this.label19.Text = "建築用途大分類名称";
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
            this.clearButton.Location = new System.Drawing.Point(878, 58);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(985, 58);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 3;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // KenchikuyotoMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.kenchikuyotoListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KenchikuyotoMstListForm";
            this.Text = "建築用途マスタ検索";
            this.Load += new System.EventHandler(this.KenchikuyotoMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KenchikuyotoMstListForm_KeyDown);
            this.kenchikuyotoListPanel.ResumeLayout(false);
            this.kenchikuyotoListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kenchikuyotoListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kenchikuyotoMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kenchikuyotoMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel kenchikuyotoListPanel;
        private System.Windows.Forms.Label kenchikuyotoListCountLabel;
        private System.Windows.Forms.DataGridView kenchikuyotoListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox kenchikuyotoNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.ComboBox kenchikuyotoDaibunruiNmComboBox;
        private System.Windows.Forms.BindingSource kenchikuyotoMstDataSetBindingSource;
        private DataSet.KenchikuyotoMstDataSet kenchikuyotoMstDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn KenchikuyotoDaibunruiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KenchikuyotoDaibunruiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KenchikuyotoShobunruiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KenchikuyotoShobunruiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KenchikuyotoRenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KenchikuyotoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kenchikuyotoDaibunruiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kenchikuyotoShobunruiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kenchikuyotoRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kenchikuyotoNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kenchikuyotoDaibunruiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kenchikuyotoShobunruiNmDataGridViewTextBoxColumn;

    }
}