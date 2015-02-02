namespace FukjBizSystem.Application.Boundary.Common
{
    partial class MemoMstSearchForm
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
            this.listCountLabel = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.memoCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.daibunruiCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.memoCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.daibunruiCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.searchWdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.torokuButton = new System.Windows.Forms.Button();
            this.memoDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.daibunruiCdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoCdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoWdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juyoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sentakuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDaibunruiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoJuyoFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juyoColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoSelectFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sentakuColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memoMstDataSet = new FukjBizSystem.Application.DataSet.MemoMstDataSet();
            this.listPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSet)).BeginInit();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listCountLabel
            // 
            this.listCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listCountLabel.AutoSize = true;
            this.listCountLabel.Location = new System.Drawing.Point(622, 4);
            this.listCountLabel.Name = "listCountLabel";
            this.listCountLabel.Size = new System.Drawing.Size(30, 20);
            this.listCountLabel.TabIndex = 1;
            this.listCountLabel.Text = "0件";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewChangeButton.Location = new System.Drawing.Point(662, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 13;
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
            // searchPanel
            // 
            this.searchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPanel.Controls.Add(this.memoCdToTextBox);
            this.searchPanel.Controls.Add(this.daibunruiCdToTextBox);
            this.searchPanel.Controls.Add(this.memoCdFromTextBox);
            this.searchPanel.Controls.Add(this.daibunruiCdFromTextBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.label4);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.searchWdTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Location = new System.Drawing.Point(6, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(694, 121);
            this.searchPanel.TabIndex = 0;
            // 
            // memoCdToTextBox
            // 
            this.memoCdToTextBox.AllowDropDown = false;
            this.memoCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.memoCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.memoCdToTextBox.CustomReadOnly = false;
            this.memoCdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.memoCdToTextBox.Location = new System.Drawing.Point(536, 34);
            this.memoCdToTextBox.MaxLength = 3;
            this.memoCdToTextBox.Name = "memoCdToTextBox";
            this.memoCdToTextBox.Size = new System.Drawing.Size(72, 27);
            this.memoCdToTextBox.TabIndex = 8;
            // 
            // daibunruiCdToTextBox
            // 
            this.daibunruiCdToTextBox.AllowDropDown = false;
            this.daibunruiCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.daibunruiCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.daibunruiCdToTextBox.CustomReadOnly = false;
            this.daibunruiCdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.daibunruiCdToTextBox.Location = new System.Drawing.Point(228, 34);
            this.daibunruiCdToTextBox.MaxLength = 2;
            this.daibunruiCdToTextBox.Name = "daibunruiCdToTextBox";
            this.daibunruiCdToTextBox.Size = new System.Drawing.Size(72, 27);
            this.daibunruiCdToTextBox.TabIndex = 4;
            // 
            // memoCdFromTextBox
            // 
            this.memoCdFromTextBox.AllowDropDown = false;
            this.memoCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.memoCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.memoCdFromTextBox.CustomReadOnly = false;
            this.memoCdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.memoCdFromTextBox.Location = new System.Drawing.Point(436, 34);
            this.memoCdFromTextBox.MaxLength = 3;
            this.memoCdFromTextBox.Name = "memoCdFromTextBox";
            this.memoCdFromTextBox.Size = new System.Drawing.Size(72, 27);
            this.memoCdFromTextBox.TabIndex = 6;
            // 
            // daibunruiCdFromTextBox
            // 
            this.daibunruiCdFromTextBox.AllowDropDown = false;
            this.daibunruiCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.daibunruiCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.daibunruiCdFromTextBox.CustomReadOnly = false;
            this.daibunruiCdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.daibunruiCdFromTextBox.Location = new System.Drawing.Point(124, 34);
            this.daibunruiCdFromTextBox.MaxLength = 2;
            this.daibunruiCdFromTextBox.Name = "daibunruiCdFromTextBox";
            this.daibunruiCdFromTextBox.Size = new System.Drawing.Size(72, 27);
            this.daibunruiCdFromTextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "メモコード";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "大分類コード";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.clearButton.Location = new System.Drawing.Point(482, 80);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kensakuButton.Location = new System.Drawing.Point(589, 79);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 12;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // searchWdTextBox
            // 
            this.searchWdTextBox.AllowDropDown = false;
            this.searchWdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.searchWdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.searchWdTextBox.CustomReadOnly = false;
            this.searchWdTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.searchWdTextBox.Location = new System.Drawing.Point(96, 72);
            this.searchWdTextBox.MaxLength = 100;
            this.searchWdTextBox.Name = "searchWdTextBox";
            this.searchWdTextBox.Size = new System.Drawing.Size(260, 27);
            this.searchWdTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "メモ内容";
            // 
            // torokuButton
            // 
            this.torokuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.torokuButton.Location = new System.Drawing.Point(490, 516);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:選択戻り";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // memoDataGridView
            // 
            this.memoDataGridView.AllowUserToAddRows = false;
            this.memoDataGridView.AllowUserToDeleteRows = false;
            this.memoDataGridView.AllowUserToResizeRows = false;
            this.memoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoDataGridView.AutoGenerateColumns = false;
            this.memoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.daibunruiCdColumn,
            this.memoCdColumn,
            this.memoWdColumn,
            this.juyoColumn,
            this.sentakuColumn,
            this.memoDaibunruiCdDataGridViewTextBoxColumn,
            this.memoCdDataGridViewTextBoxColumn,
            this.memoDataGridViewTextBoxColumn,
            this.memoJuyoFlgDataGridViewTextBoxColumn,
            this.juyoColDataGridViewTextBoxColumn,
            this.memoSelectFlgDataGridViewTextBoxColumn,
            this.sentakuColDataGridViewTextBoxColumn});
            this.memoDataGridView.DataMember = "MemoMstSearchList";
            this.memoDataGridView.DataSource = this.memoMstDataSetBindingSource;
            this.memoDataGridView.Location = new System.Drawing.Point(4, 28);
            this.memoDataGridView.MultiSelect = false;
            this.memoDataGridView.Name = "memoDataGridView";
            this.memoDataGridView.ReadOnly = true;
            this.memoDataGridView.RowHeadersVisible = false;
            this.memoDataGridView.RowTemplate.Height = 21;
            this.memoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.memoDataGridView.Size = new System.Drawing.Size(684, 346);
            this.memoDataGridView.TabIndex = 2;
            this.memoDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.memoDataGridView_CellDoubleClick);
            // 
            // daibunruiCdColumn
            // 
            this.daibunruiCdColumn.DataPropertyName = "MemoDaibunruiCd";
            this.daibunruiCdColumn.HeaderText = "大分類CD";
            this.daibunruiCdColumn.MaxInputLength = 2;
            this.daibunruiCdColumn.MinimumWidth = 80;
            this.daibunruiCdColumn.Name = "daibunruiCdColumn";
            this.daibunruiCdColumn.ReadOnly = true;
            this.daibunruiCdColumn.Width = 80;
            // 
            // memoCdColumn
            // 
            this.memoCdColumn.DataPropertyName = "MemoCd";
            this.memoCdColumn.HeaderText = "メモCD";
            this.memoCdColumn.MaxInputLength = 3;
            this.memoCdColumn.MinimumWidth = 80;
            this.memoCdColumn.Name = "memoCdColumn";
            this.memoCdColumn.ReadOnly = true;
            this.memoCdColumn.Width = 80;
            // 
            // memoWdColumn
            // 
            this.memoWdColumn.DataPropertyName = "Memo";
            this.memoWdColumn.HeaderText = "メモ内容";
            this.memoWdColumn.MaxInputLength = 160;
            this.memoWdColumn.MinimumWidth = 360;
            this.memoWdColumn.Name = "memoWdColumn";
            this.memoWdColumn.ReadOnly = true;
            this.memoWdColumn.Width = 360;
            // 
            // juyoColumn
            // 
            this.juyoColumn.DataPropertyName = "JuyoCol";
            this.juyoColumn.HeaderText = "重要";
            this.juyoColumn.MinimumWidth = 70;
            this.juyoColumn.Name = "juyoColumn";
            this.juyoColumn.ReadOnly = true;
            this.juyoColumn.Width = 70;
            // 
            // sentakuColumn
            // 
            this.sentakuColumn.DataPropertyName = "sentakuCol";
            this.sentakuColumn.HeaderText = "選択";
            this.sentakuColumn.MinimumWidth = 70;
            this.sentakuColumn.Name = "sentakuColumn";
            this.sentakuColumn.ReadOnly = true;
            this.sentakuColumn.Width = 70;
            // 
            // memoDaibunruiCdDataGridViewTextBoxColumn
            // 
            this.memoDaibunruiCdDataGridViewTextBoxColumn.DataPropertyName = "MemoDaibunruiCd";
            this.memoDaibunruiCdDataGridViewTextBoxColumn.HeaderText = "MemoDaibunruiCd";
            this.memoDaibunruiCdDataGridViewTextBoxColumn.Name = "memoDaibunruiCdDataGridViewTextBoxColumn";
            this.memoDaibunruiCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoDaibunruiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoCdDataGridViewTextBoxColumn
            // 
            this.memoCdDataGridViewTextBoxColumn.DataPropertyName = "MemoCd";
            this.memoCdDataGridViewTextBoxColumn.HeaderText = "MemoCd";
            this.memoCdDataGridViewTextBoxColumn.Name = "memoCdDataGridViewTextBoxColumn";
            this.memoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoDataGridViewTextBoxColumn
            // 
            this.memoDataGridViewTextBoxColumn.DataPropertyName = "Memo";
            this.memoDataGridViewTextBoxColumn.HeaderText = "Memo";
            this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            this.memoDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoJuyoFlgDataGridViewTextBoxColumn
            // 
            this.memoJuyoFlgDataGridViewTextBoxColumn.DataPropertyName = "MemoJuyoFlg";
            this.memoJuyoFlgDataGridViewTextBoxColumn.HeaderText = "MemoJuyoFlg";
            this.memoJuyoFlgDataGridViewTextBoxColumn.Name = "memoJuyoFlgDataGridViewTextBoxColumn";
            this.memoJuyoFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoJuyoFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // juyoColDataGridViewTextBoxColumn
            // 
            this.juyoColDataGridViewTextBoxColumn.DataPropertyName = "JuyoCol";
            this.juyoColDataGridViewTextBoxColumn.HeaderText = "JuyoCol";
            this.juyoColDataGridViewTextBoxColumn.Name = "juyoColDataGridViewTextBoxColumn";
            this.juyoColDataGridViewTextBoxColumn.ReadOnly = true;
            this.juyoColDataGridViewTextBoxColumn.Visible = false;
            // 
            // memoSelectFlgDataGridViewTextBoxColumn
            // 
            this.memoSelectFlgDataGridViewTextBoxColumn.DataPropertyName = "MemoSelectFlg";
            this.memoSelectFlgDataGridViewTextBoxColumn.HeaderText = "MemoSelectFlg";
            this.memoSelectFlgDataGridViewTextBoxColumn.Name = "memoSelectFlgDataGridViewTextBoxColumn";
            this.memoSelectFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoSelectFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // sentakuColDataGridViewTextBoxColumn
            // 
            this.sentakuColDataGridViewTextBoxColumn.DataPropertyName = "sentakuCol";
            this.sentakuColDataGridViewTextBoxColumn.HeaderText = "sentakuCol";
            this.sentakuColDataGridViewTextBoxColumn.Name = "sentakuColDataGridViewTextBoxColumn";
            this.sentakuColDataGridViewTextBoxColumn.ReadOnly = true;
            this.sentakuColDataGridViewTextBoxColumn.Visible = false;
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
            // listPanel
            // 
            this.listPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPanel.Controls.Add(this.listCountLabel);
            this.listPanel.Controls.Add(this.label1);
            this.listPanel.Controls.Add(this.memoDataGridView);
            this.listPanel.Location = new System.Drawing.Point(6, 126);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(696, 382);
            this.listPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索結果：";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(598, 516);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MemoMstSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 562);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 300);
            this.Name = "MemoMstSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "メモマスタ検索";
            this.Load += new System.EventHandler(this.MemoMstSearchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MemoMstSearchForm_KeyDown);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMstDataSet)).EndInit();
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label listCountLabel;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private Control.ZTextBox searchWdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button torokuButton;
        private Zynas.Control.ZDataGridView.ZDataGridView memoDataGridView;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private Control.ZTextBox memoCdToTextBox;
        private Control.ZTextBox daibunruiCdToTextBox;
        private Control.ZTextBox memoCdFromTextBox;
        private Control.ZTextBox daibunruiCdFromTextBox;
        private System.Windows.Forms.BindingSource memoMstDataSetBindingSource;
        private DataSet.MemoMstDataSet memoMstDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn daibunruiCdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoCdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoWdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn juyoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sentakuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDaibunruiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoJuyoFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn juyoColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoSelectFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sentakuColDataGridViewTextBoxColumn;
    }
}