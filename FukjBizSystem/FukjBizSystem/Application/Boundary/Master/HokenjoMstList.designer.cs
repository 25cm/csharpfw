namespace FukjBizSystem.Application.Boundary.Master
{
    partial class HokenjoMstListForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hokenjyoListDataGridView = new System.Windows.Forms.DataGridView();
            this.hokenjoMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hokenjoMstDataSet = new FukjBizSystem.Application.DataSet.HokenjoMstDataSet();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.hokenjyoCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hokenjyoCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.hokenjyoNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.HokenjyoListPanel = new System.Windows.Forms.Panel();
            this.hokenjyoListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.HokenjyoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HokenjyoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HokenjyoZipCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HokenjyoTelNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HokenjyoAdrCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hokenjoNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hokenjoZipCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hokenjoTelNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hokenjoAdrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.hokenjyoListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hokenjoMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hokenjoMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.HokenjyoListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // hokenjyoListDataGridView
            // 
            this.hokenjyoListDataGridView.AllowUserToAddRows = false;
            this.hokenjyoListDataGridView.AllowUserToDeleteRows = false;
            this.hokenjyoListDataGridView.AllowUserToResizeRows = false;
            this.hokenjyoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hokenjyoListDataGridView.AutoGenerateColumns = false;
            this.hokenjyoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hokenjyoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HokenjyoCdCol,
            this.HokenjyoNmCol,
            this.HokenjyoZipCdCol,
            this.HokenjyoTelNoCol,
            this.HokenjyoAdrCol,
            this.DelFlgCol,
            this.hokenjoCdDataGridViewTextBoxColumn,
            this.hokenjoNmDataGridViewTextBoxColumn,
            this.hokenjoZipCdDataGridViewTextBoxColumn,
            this.hokenjoTelNoDataGridViewTextBoxColumn,
            this.hokenjoAdrDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn});
            this.hokenjyoListDataGridView.DataMember = "HokenjoMstKensaku";
            this.hokenjyoListDataGridView.DataSource = this.hokenjoMstDataSetBindingSource;
            this.hokenjyoListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.hokenjyoListDataGridView.MultiSelect = false;
            this.hokenjyoListDataGridView.Name = "hokenjyoListDataGridView";
            this.hokenjyoListDataGridView.RowHeadersVisible = false;
            this.hokenjyoListDataGridView.RowTemplate.Height = 21;
            this.hokenjyoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hokenjyoListDataGridView.Size = new System.Drawing.Size(1100, 389);
            this.hokenjyoListDataGridView.TabIndex = 2;
            this.hokenjyoListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hokenjyoListDataGridView_CellDoubleClick);
            // 
            // hokenjoMstDataSetBindingSource
            // 
            this.hokenjoMstDataSetBindingSource.DataSource = this.hokenjoMstDataSet;
            this.hokenjoMstDataSetBindingSource.Position = 0;
            // 
            // hokenjoMstDataSet
            // 
            this.hokenjoMstDataSet.DataSetName = "HokenjoMstDataSet";
            this.hokenjoMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(727, 544);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 3;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.hokenjyoCdToTextBox);
            this.searchPanel.Controls.Add(this.hokenjyoCdFromTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.hokenjyoNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 119);
            this.searchPanel.TabIndex = 0;
            // 
            // hokenjyoCdToTextBox
            // 
            this.hokenjyoCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hokenjyoCdToTextBox.CustomDigitParts = 0;
            this.hokenjyoCdToTextBox.CustomFormat = null;
            this.hokenjyoCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hokenjyoCdToTextBox.CustomReadOnly = false;
            this.hokenjyoCdToTextBox.Location = new System.Drawing.Point(198, 36);
            this.hokenjyoCdToTextBox.MaxLength = 2;
            this.hokenjyoCdToTextBox.Name = "hokenjyoCdToTextBox";
            this.hokenjyoCdToTextBox.Size = new System.Drawing.Size(48, 27);
            this.hokenjyoCdToTextBox.TabIndex = 4;
            this.hokenjyoCdToTextBox.Leave += new System.EventHandler(this.hokenjyoCdToTextBox_Leave);
            // 
            // hokenjyoCdFromTextBox
            // 
            this.hokenjyoCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hokenjyoCdFromTextBox.CustomDigitParts = 0;
            this.hokenjyoCdFromTextBox.CustomFormat = null;
            this.hokenjyoCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hokenjyoCdFromTextBox.CustomReadOnly = false;
            this.hokenjyoCdFromTextBox.Location = new System.Drawing.Point(116, 36);
            this.hokenjyoCdFromTextBox.MaxLength = 2;
            this.hokenjyoCdFromTextBox.Name = "hokenjyoCdFromTextBox";
            this.hokenjyoCdFromTextBox.Size = new System.Drawing.Size(48, 27);
            this.hokenjyoCdFromTextBox.TabIndex = 2;
            this.hokenjyoCdFromTextBox.Leave += new System.EventHandler(this.hokenjyoCdFromTextBox_Leave);
            // 
            // hokenjyoNmTextBox
            // 
            this.hokenjyoNmTextBox.Location = new System.Drawing.Point(116, 69);
            this.hokenjyoNmTextBox.MaxLength = 24;
            this.hokenjyoNmTextBox.Name = "hokenjyoNmTextBox";
            this.hokenjyoNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.hokenjyoNmTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "保健所名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 9;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "保健所コード";
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
            this.clearButton.Location = new System.Drawing.Point(884, 75);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 74);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 8;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(863, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 4;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(591, 544);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:新規登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // HokenjyoListPanel
            // 
            this.HokenjyoListPanel.Controls.Add(this.hokenjyoListCountLabel);
            this.HokenjyoListPanel.Controls.Add(this.label4);
            this.HokenjyoListPanel.Controls.Add(this.hokenjyoListDataGridView);
            this.HokenjyoListPanel.Location = new System.Drawing.Point(0, 118);
            this.HokenjyoListPanel.Name = "HokenjyoListPanel";
            this.HokenjyoListPanel.Size = new System.Drawing.Size(1103, 416);
            this.HokenjyoListPanel.TabIndex = 1;
            // 
            // hokenjyoListCountLabel
            // 
            this.hokenjyoListCountLabel.AutoSize = true;
            this.hokenjyoListCountLabel.Location = new System.Drawing.Point(987, 4);
            this.hokenjyoListCountLabel.Name = "hokenjyoListCountLabel";
            this.hokenjyoListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.hokenjyoListCountLabel.TabIndex = 1;
            this.hokenjyoListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "検索結果：";
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(999, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // HokenjyoCdCol
            // 
            this.HokenjyoCdCol.DataPropertyName = "HokenjoCd";
            this.HokenjyoCdCol.HeaderText = "保健所コード";
            this.HokenjyoCdCol.MinimumWidth = 120;
            this.HokenjyoCdCol.Name = "HokenjyoCdCol";
            this.HokenjyoCdCol.ReadOnly = true;
            this.HokenjyoCdCol.Width = 120;
            // 
            // HokenjyoNmCol
            // 
            this.HokenjyoNmCol.DataPropertyName = "HokenjoNm";
            this.HokenjyoNmCol.HeaderText = "保健所名称";
            this.HokenjyoNmCol.MinimumWidth = 300;
            this.HokenjyoNmCol.Name = "HokenjyoNmCol";
            this.HokenjyoNmCol.ReadOnly = true;
            this.HokenjyoNmCol.Width = 300;
            // 
            // HokenjyoZipCdCol
            // 
            this.HokenjyoZipCdCol.DataPropertyName = "HokenjoZipCd";
            this.HokenjyoZipCdCol.HeaderText = "郵便番号";
            this.HokenjyoZipCdCol.MinimumWidth = 100;
            this.HokenjyoZipCdCol.Name = "HokenjyoZipCdCol";
            this.HokenjyoZipCdCol.ReadOnly = true;
            // 
            // HokenjyoTelNoCol
            // 
            this.HokenjyoTelNoCol.DataPropertyName = "HokenjoTelNo";
            this.HokenjyoTelNoCol.HeaderText = "電話番号";
            this.HokenjyoTelNoCol.MinimumWidth = 120;
            this.HokenjyoTelNoCol.Name = "HokenjyoTelNoCol";
            this.HokenjyoTelNoCol.ReadOnly = true;
            this.HokenjyoTelNoCol.Width = 120;
            // 
            // HokenjyoAdrCol
            // 
            this.HokenjyoAdrCol.DataPropertyName = "HokenjoAdr";
            this.HokenjyoAdrCol.HeaderText = "住所";
            this.HokenjyoAdrCol.MinimumWidth = 300;
            this.HokenjyoAdrCol.Name = "HokenjyoAdrCol";
            this.HokenjyoAdrCol.ReadOnly = true;
            this.HokenjyoAdrCol.Width = 300;
            // 
            // DelFlgCol
            // 
            this.DelFlgCol.DataPropertyName = "DelFlg";
            this.DelFlgCol.FalseValue = "0";
            this.DelFlgCol.HeaderText = "削除フラグ";
            this.DelFlgCol.MinimumWidth = 100;
            this.DelFlgCol.Name = "DelFlgCol";
            this.DelFlgCol.ReadOnly = true;
            this.DelFlgCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DelFlgCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DelFlgCol.TrueValue = "1";
            // 
            // hokenjoCdDataGridViewTextBoxColumn
            // 
            this.hokenjoCdDataGridViewTextBoxColumn.DataPropertyName = "HokenjoCd";
            this.hokenjoCdDataGridViewTextBoxColumn.HeaderText = "HokenjoCd";
            this.hokenjoCdDataGridViewTextBoxColumn.Name = "hokenjoCdDataGridViewTextBoxColumn";
            this.hokenjoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // hokenjoNmDataGridViewTextBoxColumn
            // 
            this.hokenjoNmDataGridViewTextBoxColumn.DataPropertyName = "HokenjoNm";
            this.hokenjoNmDataGridViewTextBoxColumn.HeaderText = "HokenjoNm";
            this.hokenjoNmDataGridViewTextBoxColumn.Name = "hokenjoNmDataGridViewTextBoxColumn";
            this.hokenjoNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // hokenjoZipCdDataGridViewTextBoxColumn
            // 
            this.hokenjoZipCdDataGridViewTextBoxColumn.DataPropertyName = "HokenjoZipCd";
            this.hokenjoZipCdDataGridViewTextBoxColumn.HeaderText = "HokenjoZipCd";
            this.hokenjoZipCdDataGridViewTextBoxColumn.Name = "hokenjoZipCdDataGridViewTextBoxColumn";
            this.hokenjoZipCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // hokenjoTelNoDataGridViewTextBoxColumn
            // 
            this.hokenjoTelNoDataGridViewTextBoxColumn.DataPropertyName = "HokenjoTelNo";
            this.hokenjoTelNoDataGridViewTextBoxColumn.HeaderText = "HokenjoTelNo";
            this.hokenjoTelNoDataGridViewTextBoxColumn.Name = "hokenjoTelNoDataGridViewTextBoxColumn";
            this.hokenjoTelNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // hokenjoAdrDataGridViewTextBoxColumn
            // 
            this.hokenjoAdrDataGridViewTextBoxColumn.DataPropertyName = "HokenjoAdr";
            this.hokenjoAdrDataGridViewTextBoxColumn.HeaderText = "HokenjoAdr";
            this.hokenjoAdrDataGridViewTextBoxColumn.Name = "hokenjoAdrDataGridViewTextBoxColumn";
            this.hokenjoAdrDataGridViewTextBoxColumn.Visible = false;
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
            // HokenjoMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.HokenjyoListPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HokenjoMstListForm";
            this.Text = "保健所マスタ検索";
            this.Load += new System.EventHandler(this.HokenjoMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HokenjoMstListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.hokenjyoListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hokenjoMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hokenjoMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.HokenjyoListPanel.ResumeLayout(false);
            this.HokenjyoListPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView hokenjyoListDataGridView;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox hokenjyoNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel HokenjyoListPanel;
        private System.Windows.Forms.Label hokenjyoListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.BindingSource hokenjoMstDataSetBindingSource;
        private DataSet.HokenjoMstDataSet hokenjoMstDataSet;
        private Control.NumberTextBox hokenjyoCdFromTextBox;
        private Control.NumberTextBox hokenjyoCdToTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn HokenjyoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HokenjyoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HokenjyoZipCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HokenjyoTelNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HokenjyoAdrCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DelFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hokenjoNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hokenjoZipCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hokenjoTelNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hokenjoAdrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;
    }
}