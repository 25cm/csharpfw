namespace FukjBizSystem.Application.Boundary.Master
{
    partial class SuishitsuKensaSetMstListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.suishitsuKensaSetListPanel = new System.Windows.Forms.Panel();
            this.gyoshaListCountLabel = new System.Windows.Forms.Label();
            this.suishitsuKensaSetListDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.setCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.setCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.setNmRyakushoTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.setNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.suishitsuKensaSetMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suishitsuKensaSetMstDataSet = new FukjBizSystem.Application.DataSet.SuishitsuKensaSetMstDataSet();
            this.SetCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetNmRyakushoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetRyoukinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetHikaiinRyoukinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setRyoukinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setNmRyakushoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suishitsuKensaSetListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKensaSetListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKensaSetMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKensaSetMstDataSet)).BeginInit();
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
            this.tojiruButton.Click += new System.EventHandler(this.TojiruButton_Click);
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
            this.torokuButton.Click += new System.EventHandler(this.TorokuButton_Click);
            // 
            // suishitsuKensaSetListPanel
            // 
            this.suishitsuKensaSetListPanel.Controls.Add(this.gyoshaListCountLabel);
            this.suishitsuKensaSetListPanel.Controls.Add(this.suishitsuKensaSetListDataGridView);
            this.suishitsuKensaSetListPanel.Controls.Add(this.label4);
            this.suishitsuKensaSetListPanel.Location = new System.Drawing.Point(0, 154);
            this.suishitsuKensaSetListPanel.Name = "suishitsuKensaSetListPanel";
            this.suishitsuKensaSetListPanel.Size = new System.Drawing.Size(1103, 397);
            this.suishitsuKensaSetListPanel.TabIndex = 12;
            // 
            // gyoshaListCountLabel
            // 
            this.gyoshaListCountLabel.AutoSize = true;
            this.gyoshaListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.gyoshaListCountLabel.Name = "gyoshaListCountLabel";
            this.gyoshaListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.gyoshaListCountLabel.TabIndex = 1;
            this.gyoshaListCountLabel.Text = "0件";
            // 
            // suishitsuKensaSetListDataGridView
            // 
            this.suishitsuKensaSetListDataGridView.AllowUserToAddRows = false;
            this.suishitsuKensaSetListDataGridView.AllowUserToDeleteRows = false;
            this.suishitsuKensaSetListDataGridView.AllowUserToResizeRows = false;
            this.suishitsuKensaSetListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.suishitsuKensaSetListDataGridView.AutoGenerateColumns = false;
            this.suishitsuKensaSetListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suishitsuKensaSetListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SetCdCol,
            this.SetNmCol,
            this.SetNmRyakushoCol,
            this.SetRyoukinCol,
            this.SetHikaiinRyoukinCol,
            this.setCdDataGridViewTextBoxColumn,
            this.setRyoukinDataGridViewTextBoxColumn,
            this.setNmDataGridViewTextBoxColumn,
            this.setNmRyakushoDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn});
            this.suishitsuKensaSetListDataGridView.DataMember = "SuishitsuKensaSetMstKensaku";
            this.suishitsuKensaSetListDataGridView.DataSource = this.suishitsuKensaSetMstDataSetBindingSource;
            this.suishitsuKensaSetListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.suishitsuKensaSetListDataGridView.MultiSelect = false;
            this.suishitsuKensaSetListDataGridView.Name = "suishitsuKensaSetListDataGridView";
            this.suishitsuKensaSetListDataGridView.RowHeadersVisible = false;
            this.suishitsuKensaSetListDataGridView.RowTemplate.Height = 21;
            this.suishitsuKensaSetListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suishitsuKensaSetListDataGridView.Size = new System.Drawing.Size(1100, 371);
            this.suishitsuKensaSetListDataGridView.TabIndex = 2;
            this.suishitsuKensaSetListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suishitsuKensaSetListDataGridView_CellDoubleClick);
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
            this.searchPanel.Controls.Add(this.setCdToTextBox);
            this.searchPanel.Controls.Add(this.setCdFromTextBox);
            this.searchPanel.Controls.Add(this.setNmRyakushoTextBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.setNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 152);
            this.searchPanel.TabIndex = 11;
            // 
            // setCdToTextBox
            // 
            this.setCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.setCdToTextBox.CustomDigitParts = 0;
            this.setCdToTextBox.CustomFormat = null;
            this.setCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.setCdToTextBox.CustomReadOnly = false;
            this.setCdToTextBox.Location = new System.Drawing.Point(230, 36);
            this.setCdToTextBox.MaxLength = 3;
            this.setCdToTextBox.Name = "setCdToTextBox";
            this.setCdToTextBox.Size = new System.Drawing.Size(45, 27);
            this.setCdToTextBox.TabIndex = 4;
            this.setCdToTextBox.Leave += new System.EventHandler(this.setCdToTextBox_Leave);
            // 
            // setCdFromTextBox
            // 
            this.setCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.setCdFromTextBox.CustomDigitParts = 0;
            this.setCdFromTextBox.CustomFormat = null;
            this.setCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.setCdFromTextBox.CustomReadOnly = false;
            this.setCdFromTextBox.Location = new System.Drawing.Point(148, 36);
            this.setCdFromTextBox.MaxLength = 3;
            this.setCdFromTextBox.Name = "setCdFromTextBox";
            this.setCdFromTextBox.Size = new System.Drawing.Size(45, 27);
            this.setCdFromTextBox.TabIndex = 2;
            this.setCdFromTextBox.Leave += new System.EventHandler(this.setCdFromTextBox_Leave);
            // 
            // setNmRyakushoTextBox
            // 
            this.setNmRyakushoTextBox.Location = new System.Drawing.Point(148, 102);
            this.setNmRyakushoTextBox.MaxLength = 30;
            this.setNmRyakushoTextBox.Name = "setNmRyakushoTextBox";
            this.setNmRyakushoTextBox.Size = new System.Drawing.Size(356, 27);
            this.setNmRyakushoTextBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "セット名称（略称）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // setNmTextBox
            // 
            this.setNmTextBox.Location = new System.Drawing.Point(148, 69);
            this.setNmTextBox.MaxLength = 80;
            this.setNmTextBox.Name = "setNmTextBox";
            this.setNmTextBox.Size = new System.Drawing.Size(356, 27);
            this.setNmTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "セット名称（正式）";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
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
            this.label19.Location = new System.Drawing.Point(16, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "セットコード";
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
            this.clearButton.Location = new System.Drawing.Point(884, 108);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 107);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 10;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // suishitsuKensaSetMstDataSetBindingSource
            // 
            this.suishitsuKensaSetMstDataSetBindingSource.DataSource = this.suishitsuKensaSetMstDataSet;
            this.suishitsuKensaSetMstDataSetBindingSource.Position = 0;
            // 
            // suishitsuKensaSetMstDataSet
            // 
            this.suishitsuKensaSetMstDataSet.DataSetName = "SuishitsuKensaSetMstDataSet";
            this.suishitsuKensaSetMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SetCdCol
            // 
            this.SetCdCol.DataPropertyName = "SetCd";
            this.SetCdCol.HeaderText = "セットコード";
            this.SetCdCol.MinimumWidth = 120;
            this.SetCdCol.Name = "SetCdCol";
            this.SetCdCol.ReadOnly = true;
            this.SetCdCol.Width = 120;
            // 
            // SetNmCol
            // 
            this.SetNmCol.DataPropertyName = "SetNm";
            this.SetNmCol.HeaderText = "セット名称（正式）";
            this.SetNmCol.MinimumWidth = 300;
            this.SetNmCol.Name = "SetNmCol";
            this.SetNmCol.ReadOnly = true;
            this.SetNmCol.Width = 300;
            // 
            // SetNmRyakushoCol
            // 
            this.SetNmRyakushoCol.DataPropertyName = "SetNmRyakusho";
            this.SetNmRyakushoCol.HeaderText = "セット名称（略称）";
            this.SetNmRyakushoCol.MinimumWidth = 250;
            this.SetNmRyakushoCol.Name = "SetNmRyakushoCol";
            this.SetNmRyakushoCol.ReadOnly = true;
            this.SetNmRyakushoCol.Width = 250;
            // 
            // SetRyoukinCol
            // 
            this.SetRyoukinCol.DataPropertyName = "SetRyoukin";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.SetRyoukinCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.SetRyoukinCol.HeaderText = "セット会員料金";
            this.SetRyoukinCol.MinimumWidth = 110;
            this.SetRyoukinCol.Name = "SetRyoukinCol";
            this.SetRyoukinCol.ReadOnly = true;
            this.SetRyoukinCol.Width = 110;
            // 
            // SetHikaiinRyoukinCol
            // 
            this.SetHikaiinRyoukinCol.DataPropertyName = "SetHikaiinRyoukin";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.SetHikaiinRyoukinCol.DefaultCellStyle = dataGridViewCellStyle6;
            this.SetHikaiinRyoukinCol.HeaderText = "セット非会員料金";
            this.SetHikaiinRyoukinCol.Name = "SetHikaiinRyoukinCol";
            this.SetHikaiinRyoukinCol.ReadOnly = true;
            // 
            // setCdDataGridViewTextBoxColumn
            // 
            this.setCdDataGridViewTextBoxColumn.DataPropertyName = "SetCd";
            this.setCdDataGridViewTextBoxColumn.HeaderText = "SetCd";
            this.setCdDataGridViewTextBoxColumn.Name = "setCdDataGridViewTextBoxColumn";
            this.setCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // setRyoukinDataGridViewTextBoxColumn
            // 
            this.setRyoukinDataGridViewTextBoxColumn.DataPropertyName = "SetRyoukin";
            this.setRyoukinDataGridViewTextBoxColumn.HeaderText = "SetRyoukin";
            this.setRyoukinDataGridViewTextBoxColumn.Name = "setRyoukinDataGridViewTextBoxColumn";
            this.setRyoukinDataGridViewTextBoxColumn.Visible = false;
            // 
            // setNmDataGridViewTextBoxColumn
            // 
            this.setNmDataGridViewTextBoxColumn.DataPropertyName = "SetNm";
            this.setNmDataGridViewTextBoxColumn.HeaderText = "SetNm";
            this.setNmDataGridViewTextBoxColumn.Name = "setNmDataGridViewTextBoxColumn";
            this.setNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // setNmRyakushoDataGridViewTextBoxColumn
            // 
            this.setNmRyakushoDataGridViewTextBoxColumn.DataPropertyName = "SetNmRyakusho";
            this.setNmRyakushoDataGridViewTextBoxColumn.HeaderText = "SetNmRyakusho";
            this.setNmRyakushoDataGridViewTextBoxColumn.Name = "setNmRyakushoDataGridViewTextBoxColumn";
            this.setNmRyakushoDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn
            // 
            this.insertUserDataGridViewTextBoxColumn.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.Name = "insertUserDataGridViewTextBoxColumn";
            this.insertUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn
            // 
            this.insertTarmDataGridViewTextBoxColumn.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.Name = "insertTarmDataGridViewTextBoxColumn";
            this.insertTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDtDataGridViewTextBoxColumn
            // 
            this.updateDtDataGridViewTextBoxColumn.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.Name = "updateDtDataGridViewTextBoxColumn";
            this.updateDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateUserDataGridViewTextBoxColumn
            // 
            this.updateUserDataGridViewTextBoxColumn.DataPropertyName = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.HeaderText = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.Name = "updateUserDataGridViewTextBoxColumn";
            this.updateUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateTarmDataGridViewTextBoxColumn
            // 
            this.updateTarmDataGridViewTextBoxColumn.DataPropertyName = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.HeaderText = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.Name = "updateTarmDataGridViewTextBoxColumn";
            this.updateTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // SuishitsuKensaSetMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.suishitsuKensaSetListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SuishitsuKensaSetMstListForm";
            this.Text = "水質検査セットマスタ検索";
            this.Load += new System.EventHandler(this.SuishitsuKensaSetMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuishitsuKensaSetMstListForm_KeyDown);
            this.suishitsuKensaSetListPanel.ResumeLayout(false);
            this.suishitsuKensaSetListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKensaSetListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKensaSetMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuKensaSetMstDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel suishitsuKensaSetListPanel;
        private System.Windows.Forms.Label gyoshaListCountLabel;
        private System.Windows.Forms.DataGridView suishitsuKensaSetListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox setNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.TextBox setNmRyakushoTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource suishitsuKensaSetMstDataSetBindingSource;
        private DataSet.SuishitsuKensaSetMstDataSet suishitsuKensaSetMstDataSet;
        private Control.NumberTextBox setCdFromTextBox;
        private Control.NumberTextBox setCdToTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetNmRyakushoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetRyoukinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetHikaiinRyoukinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn setCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setRyoukinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setNmRyakushoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;

    }
}