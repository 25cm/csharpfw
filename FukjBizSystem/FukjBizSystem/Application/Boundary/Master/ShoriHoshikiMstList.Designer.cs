namespace FukjBizSystem.Application.Boundary.Master
{
    partial class ShoriHoshikiMstListForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shoriHoshikiShubetsuNmTextBox = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.shoriHoshikiNmTextBox = new System.Windows.Forms.TextBox();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.shoriHoshikiListPanel = new System.Windows.Forms.Panel();
            this.shoriHoshikiListCountLabel = new System.Windows.Forms.Label();
            this.shoriHoshikiListDataGridView = new System.Windows.Forms.DataGridView();
            this.shoriHoshikiMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shoriHoshikiMstDataSet = new FukjBizSystem.Application.DataSet.ShoriHoshikiMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.shoriHoshikiCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shoriHoshikiCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shoriHoshikiKbnToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shoriHoshikiKbnFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.ShoriHoshikiKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiShubetsuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiShubetsuKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiNaibuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiNaibuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "処理方式名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "～";
            // 
            // shoriHoshikiShubetsuNmTextBox
            // 
            this.shoriHoshikiShubetsuNmTextBox.Location = new System.Drawing.Point(139, 97);
            this.shoriHoshikiShubetsuNmTextBox.MaxLength = 14;
            this.shoriHoshikiShubetsuNmTextBox.Name = "shoriHoshikiShubetsuNmTextBox";
            this.shoriHoshikiShubetsuNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.shoriHoshikiShubetsuNmTextBox.TabIndex = 10;
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(860, 549);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 15;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(994, 549);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 16;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // shoriHoshikiNmTextBox
            // 
            this.shoriHoshikiNmTextBox.Location = new System.Drawing.Point(139, 130);
            this.shoriHoshikiNmTextBox.MaxLength = 80;
            this.shoriHoshikiNmTextBox.Name = "shoriHoshikiNmTextBox";
            this.shoriHoshikiNmTextBox.Size = new System.Drawing.Size(707, 27);
            this.shoriHoshikiNmTextBox.TabIndex = 12;
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(726, 549);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 14;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // shoriHoshikiListPanel
            // 
            this.shoriHoshikiListPanel.Controls.Add(this.shoriHoshikiListCountLabel);
            this.shoriHoshikiListPanel.Controls.Add(this.shoriHoshikiListDataGridView);
            this.shoriHoshikiListPanel.Controls.Add(this.label4);
            this.shoriHoshikiListPanel.Location = new System.Drawing.Point(0, 183);
            this.shoriHoshikiListPanel.Name = "shoriHoshikiListPanel";
            this.shoriHoshikiListPanel.Size = new System.Drawing.Size(1103, 360);
            this.shoriHoshikiListPanel.TabIndex = 12;
            // 
            // shoriHoshikiListCountLabel
            // 
            this.shoriHoshikiListCountLabel.AutoSize = true;
            this.shoriHoshikiListCountLabel.Location = new System.Drawing.Point(987, -1);
            this.shoriHoshikiListCountLabel.Name = "shoriHoshikiListCountLabel";
            this.shoriHoshikiListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.shoriHoshikiListCountLabel.TabIndex = 1;
            this.shoriHoshikiListCountLabel.Text = "0件";
            // 
            // shoriHoshikiListDataGridView
            // 
            this.shoriHoshikiListDataGridView.AllowUserToAddRows = false;
            this.shoriHoshikiListDataGridView.AllowUserToDeleteRows = false;
            this.shoriHoshikiListDataGridView.AllowUserToResizeRows = false;
            this.shoriHoshikiListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shoriHoshikiListDataGridView.AutoGenerateColumns = false;
            this.shoriHoshikiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shoriHoshikiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShoriHoshikiKbnCol,
            this.ShoriHoshikiCdCol,
            this.ShoriHoshikiShubetsuNmCol,
            this.ShoriHoshikiNmCol,
            this.ShoriHoshikiShubetsuKbnCol,
            this.ShoriHoshikiNaibuNmCol,
            this.shoriHoshikiKbnDataGridViewTextBoxColumn,
            this.shoriHoshikiCdDataGridViewTextBoxColumn,
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn,
            this.shoriHoshikiNmDataGridViewTextBoxColumn,
            this.shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn,
            this.shoriHoshikiNaibuNmDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn});
            this.shoriHoshikiListDataGridView.DataMember = "ShoriHoshikiMstKensaku";
            this.shoriHoshikiListDataGridView.DataSource = this.shoriHoshikiMstDataSetBindingSource;
            this.shoriHoshikiListDataGridView.Location = new System.Drawing.Point(2, 23);
            this.shoriHoshikiListDataGridView.MultiSelect = false;
            this.shoriHoshikiListDataGridView.Name = "shoriHoshikiListDataGridView";
            this.shoriHoshikiListDataGridView.RowHeadersVisible = false;
            this.shoriHoshikiListDataGridView.RowTemplate.Height = 21;
            this.shoriHoshikiListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shoriHoshikiListDataGridView.Size = new System.Drawing.Size(1100, 334);
            this.shoriHoshikiListDataGridView.TabIndex = 2;
            this.shoriHoshikiListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shoriHoshikiListDataGridView_CellDoubleClick);
            // 
            // shoriHoshikiMstDataSetBindingSource
            // 
            this.shoriHoshikiMstDataSetBindingSource.DataSource = this.shoriHoshikiMstDataSet;
            this.shoriHoshikiMstDataSetBindingSource.Position = 0;
            // 
            // shoriHoshikiMstDataSet
            // 
            this.shoriHoshikiMstDataSet.DataSetName = "ShoriHoshikiMst";
            this.shoriHoshikiMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "検索結果：";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.shoriHoshikiCdToTextBox);
            this.searchPanel.Controls.Add(this.shoriHoshikiCdFromTextBox);
            this.searchPanel.Controls.Add(this.shoriHoshikiKbnToTextBox);
            this.searchPanel.Controls.Add(this.shoriHoshikiKbnFromTextBox);
            this.searchPanel.Controls.Add(this.shoriHoshikiNmTextBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.shoriHoshikiShubetsuNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 1);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 176);
            this.searchPanel.TabIndex = 11;
            // 
            // shoriHoshikiCdToTextBox
            // 
            this.shoriHoshikiCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiCdToTextBox.CustomDigitParts = 0;
            this.shoriHoshikiCdToTextBox.CustomFormat = null;
            this.shoriHoshikiCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shoriHoshikiCdToTextBox.CustomReadOnly = false;
            this.shoriHoshikiCdToTextBox.Location = new System.Drawing.Point(213, 64);
            this.shoriHoshikiCdToTextBox.MaxLength = 3;
            this.shoriHoshikiCdToTextBox.Name = "shoriHoshikiCdToTextBox";
            this.shoriHoshikiCdToTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiCdToTextBox.TabIndex = 8;
            this.shoriHoshikiCdToTextBox.Leave += new System.EventHandler(this.shoriHoshikiCdToTextBox_Leave);
            // 
            // shoriHoshikiCdFromTextBox
            // 
            this.shoriHoshikiCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiCdFromTextBox.CustomDigitParts = 0;
            this.shoriHoshikiCdFromTextBox.CustomFormat = null;
            this.shoriHoshikiCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shoriHoshikiCdFromTextBox.CustomReadOnly = false;
            this.shoriHoshikiCdFromTextBox.Location = new System.Drawing.Point(139, 64);
            this.shoriHoshikiCdFromTextBox.MaxLength = 3;
            this.shoriHoshikiCdFromTextBox.Name = "shoriHoshikiCdFromTextBox";
            this.shoriHoshikiCdFromTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiCdFromTextBox.TabIndex = 6;
            this.shoriHoshikiCdFromTextBox.Leave += new System.EventHandler(this.shoriHoshikiCdFromTextBox_Leave);
            // 
            // shoriHoshikiKbnToTextBox
            // 
            this.shoriHoshikiKbnToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiKbnToTextBox.CustomDigitParts = 0;
            this.shoriHoshikiKbnToTextBox.CustomFormat = null;
            this.shoriHoshikiKbnToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shoriHoshikiKbnToTextBox.CustomReadOnly = false;
            this.shoriHoshikiKbnToTextBox.Location = new System.Drawing.Point(213, 32);
            this.shoriHoshikiKbnToTextBox.MaxLength = 1;
            this.shoriHoshikiKbnToTextBox.Name = "shoriHoshikiKbnToTextBox";
            this.shoriHoshikiKbnToTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiKbnToTextBox.TabIndex = 4;
            // 
            // shoriHoshikiKbnFromTextBox
            // 
            this.shoriHoshikiKbnFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiKbnFromTextBox.CustomDigitParts = 0;
            this.shoriHoshikiKbnFromTextBox.CustomFormat = null;
            this.shoriHoshikiKbnFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shoriHoshikiKbnFromTextBox.CustomReadOnly = false;
            this.shoriHoshikiKbnFromTextBox.Location = new System.Drawing.Point(139, 32);
            this.shoriHoshikiKbnFromTextBox.MaxLength = 1;
            this.shoriHoshikiKbnFromTextBox.Name = "shoriHoshikiKbnFromTextBox";
            this.shoriHoshikiKbnFromTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiKbnFromTextBox.TabIndex = 2;
            this.shoriHoshikiKbnFromTextBox.Leave += new System.EventHandler(this.shoriHoshikiKbnFromTextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "～";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "処理方式区分";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "処理方式種別名";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 15;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 20);
            this.label19.TabIndex = 5;
            this.label19.Text = "処理方式コード";
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
            this.clearButton.Location = new System.Drawing.Point(884, 134);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 133);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 14;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(586, 549);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 13;
            this.torokuButton.Text = "F1:新規登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // ShoriHoshikiKbnCol
            // 
            this.ShoriHoshikiKbnCol.DataPropertyName = "ShoriHoshikiKbn";
            this.ShoriHoshikiKbnCol.HeaderText = "処理方式区分";
            this.ShoriHoshikiKbnCol.MinimumWidth = 110;
            this.ShoriHoshikiKbnCol.Name = "ShoriHoshikiKbnCol";
            this.ShoriHoshikiKbnCol.ReadOnly = true;
            this.ShoriHoshikiKbnCol.Width = 110;
            // 
            // ShoriHoshikiCdCol
            // 
            this.ShoriHoshikiCdCol.DataPropertyName = "ShoriHoshikiCd";
            this.ShoriHoshikiCdCol.HeaderText = "処理方式コード";
            this.ShoriHoshikiCdCol.MinimumWidth = 110;
            this.ShoriHoshikiCdCol.Name = "ShoriHoshikiCdCol";
            this.ShoriHoshikiCdCol.ReadOnly = true;
            this.ShoriHoshikiCdCol.Width = 110;
            // 
            // ShoriHoshikiShubetsuNmCol
            // 
            this.ShoriHoshikiShubetsuNmCol.DataPropertyName = "ShoriHoshikiShubetsuNm";
            this.ShoriHoshikiShubetsuNmCol.HeaderText = "処理方式種別名";
            this.ShoriHoshikiShubetsuNmCol.MinimumWidth = 200;
            this.ShoriHoshikiShubetsuNmCol.Name = "ShoriHoshikiShubetsuNmCol";
            this.ShoriHoshikiShubetsuNmCol.ReadOnly = true;
            this.ShoriHoshikiShubetsuNmCol.Width = 200;
            // 
            // ShoriHoshikiNmCol
            // 
            this.ShoriHoshikiNmCol.DataPropertyName = "ShoriHoshikiNm";
            this.ShoriHoshikiNmCol.HeaderText = "処理方式名";
            this.ShoriHoshikiNmCol.MinimumWidth = 300;
            this.ShoriHoshikiNmCol.Name = "ShoriHoshikiNmCol";
            this.ShoriHoshikiNmCol.ReadOnly = true;
            this.ShoriHoshikiNmCol.Width = 300;
            // 
            // ShoriHoshikiShubetsuKbnCol
            // 
            this.ShoriHoshikiShubetsuKbnCol.DataPropertyName = "ShoriHoshikiShubetsuKbn";
            this.ShoriHoshikiShubetsuKbnCol.HeaderText = "処理方式種別区分";
            this.ShoriHoshikiShubetsuKbnCol.MinimumWidth = 110;
            this.ShoriHoshikiShubetsuKbnCol.Name = "ShoriHoshikiShubetsuKbnCol";
            this.ShoriHoshikiShubetsuKbnCol.ReadOnly = true;
            this.ShoriHoshikiShubetsuKbnCol.Width = 110;
            // 
            // ShoriHoshikiNaibuNmCol
            // 
            this.ShoriHoshikiNaibuNmCol.DataPropertyName = "ShoriHoshikiNaibuNm";
            this.ShoriHoshikiNaibuNmCol.HeaderText = "処理方式内部名";
            this.ShoriHoshikiNaibuNmCol.MinimumWidth = 200;
            this.ShoriHoshikiNaibuNmCol.Name = "ShoriHoshikiNaibuNmCol";
            this.ShoriHoshikiNaibuNmCol.ReadOnly = true;
            this.ShoriHoshikiNaibuNmCol.Width = 200;
            // 
            // shoriHoshikiKbnDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiKbn";
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiKbn";
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.Name = "shoriHoshikiKbnDataGridViewTextBoxColumn";
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // shoriHoshikiCdDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiCdDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiCd";
            this.shoriHoshikiCdDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiCd";
            this.shoriHoshikiCdDataGridViewTextBoxColumn.Name = "shoriHoshikiCdDataGridViewTextBoxColumn";
            this.shoriHoshikiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shoriHoshikiShubetsuNmDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiShubetsuNm";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiShubetsuNm";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.Name = "shoriHoshikiShubetsuNmDataGridViewTextBoxColumn";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // shoriHoshikiNmDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiNmDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiNm";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiNm";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.Name = "shoriHoshikiNmDataGridViewTextBoxColumn";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiShubetsuKbn";
            this.shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiShubetsuKbn";
            this.shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn.Name = "shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn";
            this.shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // shoriHoshikiNaibuNmDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiNaibuNmDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiNaibuNm";
            this.shoriHoshikiNaibuNmDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiNaibuNm";
            this.shoriHoshikiNaibuNmDataGridViewTextBoxColumn.Name = "shoriHoshikiNaibuNmDataGridViewTextBoxColumn";
            this.shoriHoshikiNaibuNmDataGridViewTextBoxColumn.Visible = false;
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
            // ShoriHoshikiMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.shoriHoshikiListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.torokuButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShoriHoshikiMstListForm";
            this.Text = "処理方式マスタ検索";
            this.Load += new System.EventHandler(this.ShoriHoshikiMst_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShoriHoshikiMstListForm_KeyDown);
            this.shoriHoshikiListPanel.ResumeLayout(false);
            this.shoriHoshikiListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shoriHoshikiShubetsuNmTextBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.TextBox shoriHoshikiNmTextBox;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Panel shoriHoshikiListPanel;
        private System.Windows.Forms.Label shoriHoshikiListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.DataGridView shoriHoshikiListDataGridView;
        private System.Windows.Forms.BindingSource shoriHoshikiMstDataSetBindingSource;
        private DataSet.ShoriHoshikiMstDataSet shoriHoshikiMstDataSet;
        private Control.NumberTextBox shoriHoshikiKbnToTextBox;
        private Control.NumberTextBox shoriHoshikiKbnFromTextBox;
        private Control.NumberTextBox shoriHoshikiCdToTextBox;
        private Control.NumberTextBox shoriHoshikiCdFromTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiShubetsuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiShubetsuKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiNaibuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiShubetsuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiShubetsuKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiNaibuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;
    }
}