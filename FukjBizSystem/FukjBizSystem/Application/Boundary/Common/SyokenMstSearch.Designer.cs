namespace FukjBizSystem.Application.Boundary.Common
{
    partial class SyokenMstSearchForm
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
            this.shokenMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shokenMstDataSet = new FukjBizSystem.Application.DataSet.ShokenMstDataSet();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.searchWdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.syokenKbnComboBox = new System.Windows.Forms.ComboBox();
            this.shitekiKbnComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.torokuButton = new System.Windows.Forms.Button();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.syokenDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.syokenKbnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syokenCdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syokenWdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juyodoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hanteiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bikoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenWdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenJuyodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHandanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHanteiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenBikoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juyodoColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handanColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hanteiColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.listPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syokenDataGridView)).BeginInit();
            this.SuspendLayout();
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
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.searchWdTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label4);
            this.searchPanel.Controls.Add(this.syokenKbnComboBox);
            this.searchPanel.Controls.Add(this.shitekiKbnComboBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Location = new System.Drawing.Point(4, 4);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1076, 121);
            this.searchPanel.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(864, 80);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(971, 79);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 8;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1044, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 9;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "検索条件";
            // 
            // searchWdTextBox
            // 
            this.searchWdTextBox.AllowDropDown = false;
            this.searchWdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.searchWdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.searchWdTextBox.CustomReadOnly = false;
            this.searchWdTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.searchWdTextBox.Location = new System.Drawing.Point(96, 72);
            this.searchWdTextBox.MaxLength = 160;
            this.searchWdTextBox.Name = "searchWdTextBox";
            this.searchWdTextBox.Size = new System.Drawing.Size(260, 27);
            this.searchWdTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "所見文章";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "所見区分";
            // 
            // syokenKbnComboBox
            // 
            this.syokenKbnComboBox.DisplayMember = "TodofukenNm";
            this.syokenKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syokenKbnComboBox.FormattingEnabled = true;
            this.syokenKbnComboBox.Location = new System.Drawing.Point(356, 33);
            this.syokenKbnComboBox.Name = "syokenKbnComboBox";
            this.syokenKbnComboBox.Size = new System.Drawing.Size(172, 28);
            this.syokenKbnComboBox.TabIndex = 4;
            // 
            // shitekiKbnComboBox
            // 
            this.shitekiKbnComboBox.DisplayMember = "TodofukenNm";
            this.shitekiKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shitekiKbnComboBox.FormattingEnabled = true;
            this.shitekiKbnComboBox.Location = new System.Drawing.Point(96, 33);
            this.shitekiKbnComboBox.Name = "shitekiKbnComboBox";
            this.shitekiKbnComboBox.Size = new System.Drawing.Size(172, 28);
            this.shitekiKbnComboBox.TabIndex = 2;
            this.shitekiKbnComboBox.SelectedIndexChanged += new System.EventHandler(this.shitekiKbnComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "指摘区分";
            // 
            // torokuButton
            // 
            this.torokuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.torokuButton.Location = new System.Drawing.Point(868, 516);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:選択戻り";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // listPanel
            // 
            this.listPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPanel.Controls.Add(this.listCountLabel);
            this.listPanel.Controls.Add(this.label1);
            this.listPanel.Controls.Add(this.syokenDataGridView);
            this.listPanel.Location = new System.Drawing.Point(4, 128);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(1076, 380);
            this.listPanel.TabIndex = 1;
            // 
            // listCountLabel
            // 
            this.listCountLabel.AutoSize = true;
            this.listCountLabel.Location = new System.Drawing.Point(1004, 4);
            this.listCountLabel.Name = "listCountLabel";
            this.listCountLabel.Size = new System.Drawing.Size(30, 20);
            this.listCountLabel.TabIndex = 1;
            this.listCountLabel.Text = "0件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(924, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索結果：";
            // 
            // syokenDataGridView
            // 
            this.syokenDataGridView.AllowUserToAddRows = false;
            this.syokenDataGridView.AllowUserToDeleteRows = false;
            this.syokenDataGridView.AllowUserToResizeRows = false;
            this.syokenDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syokenDataGridView.AutoGenerateColumns = false;
            this.syokenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.syokenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.syokenKbnColumn,
            this.syokenCdColumn,
            this.syokenWdColumn,
            this.juyodoColumn,
            this.handanColumn,
            this.hanteiColumn,
            this.bikoColumn,
            this.shokenKbnDataGridViewTextBoxColumn,
            this.shokenCdDataGridViewTextBoxColumn,
            this.shokenWdDataGridViewTextBoxColumn,
            this.shokenJuyodoDataGridViewTextBoxColumn,
            this.shokenHandanDataGridViewTextBoxColumn,
            this.shokenHanteiDataGridViewTextBoxColumn,
            this.shokenBikoDataGridViewTextBoxColumn,
            this.juyodoColDataGridViewTextBoxColumn,
            this.handanColDataGridViewTextBoxColumn,
            this.hanteiColDataGridViewTextBoxColumn});
            this.syokenDataGridView.DataMember = "SyokenMstSearchList";
            this.syokenDataGridView.DataSource = this.shokenMstDataSetBindingSource;
            this.syokenDataGridView.Location = new System.Drawing.Point(4, 28);
            this.syokenDataGridView.MultiSelect = false;
            this.syokenDataGridView.Name = "syokenDataGridView";
            this.syokenDataGridView.ReadOnly = true;
            this.syokenDataGridView.RowHeadersVisible = false;
            this.syokenDataGridView.RowTemplate.Height = 21;
            this.syokenDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.syokenDataGridView.Size = new System.Drawing.Size(1068, 344);
            this.syokenDataGridView.TabIndex = 2;
            this.syokenDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.syokenDataGridView_CellDoubleClick);
            // 
            // syokenKbnColumn
            // 
            this.syokenKbnColumn.DataPropertyName = "ShokenKbn";
            this.syokenKbnColumn.HeaderText = "所見区分";
            this.syokenKbnColumn.MaxInputLength = 3;
            this.syokenKbnColumn.MinimumWidth = 90;
            this.syokenKbnColumn.Name = "syokenKbnColumn";
            this.syokenKbnColumn.ReadOnly = true;
            this.syokenKbnColumn.Width = 90;
            // 
            // syokenCdColumn
            // 
            this.syokenCdColumn.DataPropertyName = "ShokenCd";
            this.syokenCdColumn.HeaderText = "所見CD";
            this.syokenCdColumn.MaxInputLength = 3;
            this.syokenCdColumn.MinimumWidth = 80;
            this.syokenCdColumn.Name = "syokenCdColumn";
            this.syokenCdColumn.ReadOnly = true;
            this.syokenCdColumn.Width = 80;
            // 
            // syokenWdColumn
            // 
            this.syokenWdColumn.DataPropertyName = "ShokenWd";
            this.syokenWdColumn.HeaderText = "所見文章";
            this.syokenWdColumn.MaxInputLength = 160;
            this.syokenWdColumn.MinimumWidth = 500;
            this.syokenWdColumn.Name = "syokenWdColumn";
            this.syokenWdColumn.ReadOnly = true;
            this.syokenWdColumn.Width = 500;
            // 
            // juyodoColumn
            // 
            this.juyodoColumn.DataPropertyName = "juyodoCol";
            this.juyodoColumn.HeaderText = "重要度";
            this.juyodoColumn.MinimumWidth = 70;
            this.juyodoColumn.Name = "juyodoColumn";
            this.juyodoColumn.ReadOnly = true;
            this.juyodoColumn.Width = 70;
            // 
            // handanColumn
            // 
            this.handanColumn.DataPropertyName = "handanCol";
            this.handanColumn.HeaderText = "判断";
            this.handanColumn.MinimumWidth = 70;
            this.handanColumn.Name = "handanColumn";
            this.handanColumn.ReadOnly = true;
            this.handanColumn.Width = 70;
            // 
            // hanteiColumn
            // 
            this.hanteiColumn.DataPropertyName = "hanteiCol";
            this.hanteiColumn.HeaderText = "判定";
            this.hanteiColumn.MinimumWidth = 80;
            this.hanteiColumn.Name = "hanteiColumn";
            this.hanteiColumn.ReadOnly = true;
            this.hanteiColumn.Width = 80;
            // 
            // bikoColumn
            // 
            this.bikoColumn.DataPropertyName = "ShokenBiko";
            this.bikoColumn.HeaderText = "備考";
            this.bikoColumn.MinimumWidth = 150;
            this.bikoColumn.Name = "bikoColumn";
            this.bikoColumn.ReadOnly = true;
            this.bikoColumn.Width = 150;
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
            // shokenWdDataGridViewTextBoxColumn
            // 
            this.shokenWdDataGridViewTextBoxColumn.DataPropertyName = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn.HeaderText = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn.Name = "shokenWdDataGridViewTextBoxColumn";
            this.shokenWdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenWdDataGridViewTextBoxColumn.Visible = false;
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
            // juyodoColDataGridViewTextBoxColumn
            // 
            this.juyodoColDataGridViewTextBoxColumn.DataPropertyName = "juyodoCol";
            this.juyodoColDataGridViewTextBoxColumn.HeaderText = "juyodoCol";
            this.juyodoColDataGridViewTextBoxColumn.Name = "juyodoColDataGridViewTextBoxColumn";
            this.juyodoColDataGridViewTextBoxColumn.ReadOnly = true;
            this.juyodoColDataGridViewTextBoxColumn.Visible = false;
            // 
            // handanColDataGridViewTextBoxColumn
            // 
            this.handanColDataGridViewTextBoxColumn.DataPropertyName = "handanCol";
            this.handanColDataGridViewTextBoxColumn.HeaderText = "handanCol";
            this.handanColDataGridViewTextBoxColumn.Name = "handanColDataGridViewTextBoxColumn";
            this.handanColDataGridViewTextBoxColumn.ReadOnly = true;
            this.handanColDataGridViewTextBoxColumn.Visible = false;
            // 
            // hanteiColDataGridViewTextBoxColumn
            // 
            this.hanteiColDataGridViewTextBoxColumn.DataPropertyName = "hanteiCol";
            this.hanteiColDataGridViewTextBoxColumn.HeaderText = "hanteiCol";
            this.hanteiColDataGridViewTextBoxColumn.Name = "hanteiColDataGridViewTextBoxColumn";
            this.hanteiColDataGridViewTextBoxColumn.ReadOnly = true;
            this.hanteiColDataGridViewTextBoxColumn.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(976, 516);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SyokenMstSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 562);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 350);
            this.Name = "SyokenMstSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "所見マスタ検索";
            this.Load += new System.EventHandler(this.SyokenMstSearchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SyokenMstSearchForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syokenDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.ZTextBox searchWdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox syokenKbnComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox shitekiKbnComboBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private Zynas.Control.ZDataGridView.ZDataGridView syokenDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label listCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource shokenMstDataSetBindingSource;
        private DataSet.ShokenMstDataSet shokenMstDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn syokenKbnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn syokenCdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn syokenWdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn juyodoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanteiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bikoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenWdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenJuyodoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHandanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHanteiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenBikoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn juyodoColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handanColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanteiColDataGridViewTextBoxColumn;
    }
}