namespace FukjBizSystem.Application.Boundary.Master
{
    partial class MemoMstListForm
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
            this.memoListPanel = new System.Windows.Forms.Panel();
            this.memoListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.memoListDataGridView = new System.Windows.Forms.DataGridView();
            this.MemoDaibunruiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoDaibunruiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoJuyoFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MemoSelectFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.memoDaibunruiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoJuyoFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoSelectFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDaibunruiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memoMstDataSet = new FukjBizSystem.Application.DataSet.MemoMstDataSet();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.sentakuHukaCheckBox = new System.Windows.Forms.CheckBox();
            this.sentakuKaCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hutsuCheckBox = new System.Windows.Forms.CheckBox();
            this.juyoCheckBox = new System.Windows.Forms.CheckBox();
            this.memoDaibunruiNmComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.memoNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.KensakuButton = new System.Windows.Forms.Button();
            this.memoListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSet)).BeginInit();
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
            // memoListPanel
            // 
            this.memoListPanel.Controls.Add(this.memoListCountLabel);
            this.memoListPanel.Controls.Add(this.label4);
            this.memoListPanel.Controls.Add(this.memoListDataGridView);
            this.memoListPanel.Location = new System.Drawing.Point(0, 152);
            this.memoListPanel.Name = "memoListPanel";
            this.memoListPanel.Size = new System.Drawing.Size(1103, 399);
            this.memoListPanel.TabIndex = 12;
            // 
            // memoListCountLabel
            // 
            this.memoListCountLabel.AutoSize = true;
            this.memoListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.memoListCountLabel.Name = "memoListCountLabel";
            this.memoListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.memoListCountLabel.TabIndex = 1;
            this.memoListCountLabel.Text = "0件";
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
            // memoListDataGridView
            // 
            this.memoListDataGridView.AllowUserToAddRows = false;
            this.memoListDataGridView.AllowUserToDeleteRows = false;
            this.memoListDataGridView.AllowUserToResizeRows = false;
            this.memoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoListDataGridView.AutoGenerateColumns = false;
            this.memoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemoDaibunruiCdCol,
            this.MemoDaibunruiNmCol,
            this.MemoCdCol,
            this.MemoCol,
            this.MemoJuyoFlgCol,
            this.MemoSelectFlgCol,
            this.memoDaibunruiCdDataGridViewTextBoxColumn,
            this.memoCdDataGridViewTextBoxColumn,
            this.memoDataGridViewTextBoxColumn,
            this.memoJuyoFlgDataGridViewTextBoxColumn,
            this.memoSelectFlgDataGridViewTextBoxColumn,
            this.memoDaibunruiNmDataGridViewTextBoxColumn});
            this.memoListDataGridView.DataMember = "MemoMstKensaku";
            this.memoListDataGridView.DataSource = this.memoMstDataSetBindingSource;
            this.memoListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.memoListDataGridView.MultiSelect = false;
            this.memoListDataGridView.Name = "memoListDataGridView";
            this.memoListDataGridView.RowHeadersVisible = false;
            this.memoListDataGridView.RowTemplate.Height = 21;
            this.memoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.memoListDataGridView.Size = new System.Drawing.Size(1100, 373);
            this.memoListDataGridView.TabIndex = 2;
            this.memoListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.memoListDataGridView_CellDoubleClick);
            // 
            // MemoDaibunruiCdCol
            // 
            this.MemoDaibunruiCdCol.DataPropertyName = "MemoDaibunruiCd";
            this.MemoDaibunruiCdCol.HeaderText = "大分類コード";
            this.MemoDaibunruiCdCol.MinimumWidth = 150;
            this.MemoDaibunruiCdCol.Name = "MemoDaibunruiCdCol";
            this.MemoDaibunruiCdCol.ReadOnly = true;
            this.MemoDaibunruiCdCol.Width = 150;
            // 
            // MemoDaibunruiNmCol
            // 
            this.MemoDaibunruiNmCol.DataPropertyName = "MemoDaibunruiNm";
            this.MemoDaibunruiNmCol.HeaderText = "大分類名称";
            this.MemoDaibunruiNmCol.MinimumWidth = 250;
            this.MemoDaibunruiNmCol.Name = "MemoDaibunruiNmCol";
            this.MemoDaibunruiNmCol.ReadOnly = true;
            this.MemoDaibunruiNmCol.Width = 250;
            // 
            // MemoCdCol
            // 
            this.MemoCdCol.DataPropertyName = "MemoCd";
            this.MemoCdCol.HeaderText = "メモコード";
            this.MemoCdCol.MinimumWidth = 150;
            this.MemoCdCol.Name = "MemoCdCol";
            this.MemoCdCol.ReadOnly = true;
            this.MemoCdCol.Width = 150;
            // 
            // MemoCol
            // 
            this.MemoCol.DataPropertyName = "Memo";
            this.MemoCol.HeaderText = "メモ";
            this.MemoCol.MinimumWidth = 250;
            this.MemoCol.Name = "MemoCol";
            this.MemoCol.ReadOnly = true;
            this.MemoCol.Width = 250;
            // 
            // MemoJuyoFlgCol
            // 
            this.MemoJuyoFlgCol.DataPropertyName = "MemoJuyoFlg";
            this.MemoJuyoFlgCol.FalseValue = "0";
            this.MemoJuyoFlgCol.HeaderText = "重要";
            this.MemoJuyoFlgCol.MinimumWidth = 80;
            this.MemoJuyoFlgCol.Name = "MemoJuyoFlgCol";
            this.MemoJuyoFlgCol.ReadOnly = true;
            this.MemoJuyoFlgCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MemoJuyoFlgCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MemoJuyoFlgCol.TrueValue = "1";
            this.MemoJuyoFlgCol.Width = 80;
            // 
            // MemoSelectFlgCol
            // 
            this.MemoSelectFlgCol.DataPropertyName = "MemoSelectFlg";
            this.MemoSelectFlgCol.FalseValue = "0";
            this.MemoSelectFlgCol.HeaderText = "選択不可";
            this.MemoSelectFlgCol.MinimumWidth = 100;
            this.MemoSelectFlgCol.Name = "MemoSelectFlgCol";
            this.MemoSelectFlgCol.ReadOnly = true;
            this.MemoSelectFlgCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MemoSelectFlgCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MemoSelectFlgCol.TrueValue = "1";
            // 
            // memoDaibunruiCdDataGridViewTextBoxColumn
            // 
            this.memoDaibunruiCdDataGridViewTextBoxColumn.DataPropertyName = "MemoDaibunruiCd";
            this.memoDaibunruiCdDataGridViewTextBoxColumn.HeaderText = "MemoDaibunruiCd";
            this.memoDaibunruiCdDataGridViewTextBoxColumn.Name = "memoDaibunruiCdDataGridViewTextBoxColumn";
            this.memoDaibunruiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoCdDataGridViewTextBoxColumn
            // 
            this.memoCdDataGridViewTextBoxColumn.DataPropertyName = "MemoCd";
            this.memoCdDataGridViewTextBoxColumn.HeaderText = "MemoCd";
            this.memoCdDataGridViewTextBoxColumn.Name = "memoCdDataGridViewTextBoxColumn";
            this.memoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoDataGridViewTextBoxColumn
            // 
            this.memoDataGridViewTextBoxColumn.DataPropertyName = "Memo";
            this.memoDataGridViewTextBoxColumn.HeaderText = "Memo";
            this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            this.memoDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoJuyoFlgDataGridViewTextBoxColumn
            // 
            this.memoJuyoFlgDataGridViewTextBoxColumn.DataPropertyName = "MemoJuyoFlg";
            this.memoJuyoFlgDataGridViewTextBoxColumn.HeaderText = "MemoJuyoFlg";
            this.memoJuyoFlgDataGridViewTextBoxColumn.Name = "memoJuyoFlgDataGridViewTextBoxColumn";
            this.memoJuyoFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoSelectFlgDataGridViewTextBoxColumn
            // 
            this.memoSelectFlgDataGridViewTextBoxColumn.DataPropertyName = "MemoSelectFlg";
            this.memoSelectFlgDataGridViewTextBoxColumn.HeaderText = "MemoSelectFlg";
            this.memoSelectFlgDataGridViewTextBoxColumn.Name = "memoSelectFlgDataGridViewTextBoxColumn";
            this.memoSelectFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoDaibunruiNmDataGridViewTextBoxColumn
            // 
            this.memoDaibunruiNmDataGridViewTextBoxColumn.DataPropertyName = "MemoDaibunruiNm";
            this.memoDaibunruiNmDataGridViewTextBoxColumn.HeaderText = "MemoDaibunruiNm";
            this.memoDaibunruiNmDataGridViewTextBoxColumn.Name = "memoDaibunruiNmDataGridViewTextBoxColumn";
            this.memoDaibunruiNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoMstDataSetBindingSource
            // 
            this.memoMstDataSetBindingSource.DataSource = this.memoMstDataSet;
            this.memoMstDataSetBindingSource.Position = 0;
            // 
            // memoMstDataSet
            // 
            this.memoMstDataSet.DataSetName = "MemoMstDataSet";
            this.memoMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.sentakuHukaCheckBox);
            this.searchPanel.Controls.Add(this.sentakuKaCheckBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.hutsuCheckBox);
            this.searchPanel.Controls.Add(this.juyoCheckBox);
            this.searchPanel.Controls.Add(this.memoDaibunruiNmComboBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.memoNmTextBox);
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
            // sentakuHukaCheckBox
            // 
            this.sentakuHukaCheckBox.AutoSize = true;
            this.sentakuHukaCheckBox.Location = new System.Drawing.Point(178, 124);
            this.sentakuHukaCheckBox.Name = "sentakuHukaCheckBox";
            this.sentakuHukaCheckBox.Size = new System.Drawing.Size(80, 24);
            this.sentakuHukaCheckBox.TabIndex = 10;
            this.sentakuHukaCheckBox.Text = "選択不可";
            this.sentakuHukaCheckBox.UseVisualStyleBackColor = true;
            // 
            // sentakuKaCheckBox
            // 
            this.sentakuKaCheckBox.AutoSize = true;
            this.sentakuKaCheckBox.Location = new System.Drawing.Point(98, 124);
            this.sentakuKaCheckBox.Name = "sentakuKaCheckBox";
            this.sentakuKaCheckBox.Size = new System.Drawing.Size(67, 24);
            this.sentakuKaCheckBox.TabIndex = 9;
            this.sentakuKaCheckBox.Text = "選択可";
            this.sentakuKaCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "選択";
            // 
            // hutsuCheckBox
            // 
            this.hutsuCheckBox.AutoSize = true;
            this.hutsuCheckBox.Location = new System.Drawing.Point(178, 100);
            this.hutsuCheckBox.Name = "hutsuCheckBox";
            this.hutsuCheckBox.Size = new System.Drawing.Size(67, 24);
            this.hutsuCheckBox.TabIndex = 7;
            this.hutsuCheckBox.Text = "普通　";
            this.hutsuCheckBox.UseVisualStyleBackColor = true;
            // 
            // juyoCheckBox
            // 
            this.juyoCheckBox.AutoSize = true;
            this.juyoCheckBox.Location = new System.Drawing.Point(98, 100);
            this.juyoCheckBox.Name = "juyoCheckBox";
            this.juyoCheckBox.Size = new System.Drawing.Size(67, 24);
            this.juyoCheckBox.TabIndex = 6;
            this.juyoCheckBox.Text = "重要　";
            this.juyoCheckBox.UseVisualStyleBackColor = true;
            // 
            // memoDaibunruiNmComboBox
            // 
            this.memoDaibunruiNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memoDaibunruiNmComboBox.FormattingEnabled = true;
            this.memoDaibunruiNmComboBox.Location = new System.Drawing.Point(96, 31);
            this.memoDaibunruiNmComboBox.Name = "memoDaibunruiNmComboBox";
            this.memoDaibunruiNmComboBox.Size = new System.Drawing.Size(300, 28);
            this.memoDaibunruiNmComboBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "重要度";
            // 
            // memoNmTextBox
            // 
            this.memoNmTextBox.Location = new System.Drawing.Point(96, 65);
            this.memoNmTextBox.MaxLength = 100;
            this.memoNmTextBox.Name = "memoNmTextBox";
            this.memoNmTextBox.Size = new System.Drawing.Size(600, 27);
            this.memoNmTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "メモ";
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
            this.label19.Location = new System.Drawing.Point(16, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "大分類";
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
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "F7:クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // KensakuButton
            // 
            this.KensakuButton.Location = new System.Drawing.Point(991, 109);
            this.KensakuButton.Name = "KensakuButton";
            this.KensakuButton.Size = new System.Drawing.Size(101, 37);
            this.KensakuButton.TabIndex = 12;
            this.KensakuButton.Text = "F8:検索";
            this.KensakuButton.UseVisualStyleBackColor = true;
            this.KensakuButton.Click += new System.EventHandler(this.KensakuButton_Click);
            // 
            // MemoMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.TojiruButton);
            this.Controls.Add(this.ShosaiButton);
            this.Controls.Add(this.TorokuButton);
            this.Controls.Add(this.memoListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MemoMstListForm";
            this.Text = "メモマスタ検索";
            this.Load += new System.EventHandler(this.MemoMstList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MemoMstList_KeyDown);
            this.memoListPanel.ResumeLayout(false);
            this.memoListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.Button TojiruButton;
        private System.Windows.Forms.Button ShosaiButton;
        private System.Windows.Forms.Button TorokuButton;
        private System.Windows.Forms.Panel memoListPanel;
        private System.Windows.Forms.Label memoListCountLabel;
        private System.Windows.Forms.DataGridView memoListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox memoNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ViewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button KensakuButton;
        private System.Windows.Forms.ComboBox memoDaibunruiNmComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox sentakuHukaCheckBox;
        private System.Windows.Forms.CheckBox sentakuKaCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox hutsuCheckBox;
        private System.Windows.Forms.CheckBox juyoCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoDaibunruiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoDaibunruiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MemoJuyoFlgCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MemoSelectFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDaibunruiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoJuyoFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoSelectFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDaibunruiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource memoMstDataSetBindingSource;
        private DataSet.MemoMstDataSet memoMstDataSet;

    }
}