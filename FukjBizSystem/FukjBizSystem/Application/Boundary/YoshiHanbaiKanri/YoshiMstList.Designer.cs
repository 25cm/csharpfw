namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class YoshiMstListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.outputButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.shiireListDataGridView = new System.Windows.Forms.DataGridView();
            this.YoshiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KaiinTankaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HiKaiinTankaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KaiinSetKakakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HiKaiinSetKakakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetBusuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KaiinTankaOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HiKaiinTankaOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KaiinSetKakakuOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HiKaiinSetKakakuOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetBusuOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUpdateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiCdOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiNmOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiKaiinUpOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiHiKaiinUpOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiKaiinSetKakakuOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiHiKaiinSetKakakuOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiSetBusuOriginalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertUserCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertTarmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUserCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTarmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiMstUpdateDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yoshiMstUpdateDataSet = new FukjBizSystem.Application.Boundary.YoshiHanbaiKanri.YoshiMstUpdateDataSet();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shiireListPanel = new System.Windows.Forms.Panel();
            this.shiireListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.yoshiCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.yoshiCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shiireListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstUpdateDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstUpdateDataSet)).BeginInit();
            this.shiireListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(862, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 14;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(728, 544);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 13;
            this.torokuButton.Text = "F1:登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // shiireListDataGridView
            // 
            this.shiireListDataGridView.AllowUserToResizeRows = false;
            this.shiireListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shiireListDataGridView.AutoGenerateColumns = false;
            this.shiireListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shiireListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YoshiCdCol,
            this.YoshiNmCol,
            this.KaiinTankaCol,
            this.HiKaiinTankaCol,
            this.KaiinSetKakakuCol,
            this.HiKaiinSetKakakuCol,
            this.SetBusuCol,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.KaiinTankaOriginalCol,
            this.HiKaiinTankaOriginalCol,
            this.KaiinSetKakakuOriginalCol,
            this.HiKaiinSetKakakuOriginalCol,
            this.SetBusuOriginalCol,
            this.IsUpdateCol,
            this.YoshiCdOriginalCol,
            this.YoshiNmOriginalCol,
            this.YoshiKaiinUpOriginalCol,
            this.YoshiHiKaiinUpOriginalCol,
            this.YoshiKaiinSetKakakuOriginalCol,
            this.YoshiHiKaiinSetKakakuOriginalCol,
            this.YoshiSetBusuOriginalCol,
            this.InsertDtCol,
            this.InsertUserCol,
            this.InsertTarmCol,
            this.UpdateDtCol,
            this.UpdateUserCol,
            this.UpdateTarmCol});
            this.shiireListDataGridView.DataMember = "YoshiMstUpdate";
            this.shiireListDataGridView.DataSource = this.yoshiMstUpdateDataSetBindingSource;
            this.shiireListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.shiireListDataGridView.MultiSelect = false;
            this.shiireListDataGridView.Name = "shiireListDataGridView";
            this.shiireListDataGridView.RowHeadersVisible = false;
            this.shiireListDataGridView.RowTemplate.Height = 21;
            this.shiireListDataGridView.Size = new System.Drawing.Size(1095, 365);
            this.shiireListDataGridView.TabIndex = 2;
            this.shiireListDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.shiireListDataGridView_CellValueChanged);
            this.shiireListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shiireListDataGridView_DataError);
            this.shiireListDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.shiireListDataGridView_EditingControlShowing);
            this.shiireListDataGridView.Sorted += new System.EventHandler(this.shiireListDataGridView_Sorted);
            // 
            // YoshiCdCol
            // 
            this.YoshiCdCol.DataPropertyName = "YoshiCd";
            this.YoshiCdCol.HeaderText = "用紙コード";
            this.YoshiCdCol.MaxInputLength = 2;
            this.YoshiCdCol.MinimumWidth = 100;
            this.YoshiCdCol.Name = "YoshiCdCol";
            this.YoshiCdCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // YoshiNmCol
            // 
            this.YoshiNmCol.DataPropertyName = "YoshiNm";
            this.YoshiNmCol.HeaderText = "用紙名称";
            this.YoshiNmCol.MaxInputLength = 60;
            this.YoshiNmCol.MinimumWidth = 450;
            this.YoshiNmCol.Name = "YoshiNmCol";
            this.YoshiNmCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.YoshiNmCol.Width = 450;
            // 
            // KaiinTankaCol
            // 
            this.KaiinTankaCol.DataPropertyName = "YoshiKaiinUp";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.KaiinTankaCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.KaiinTankaCol.HeaderText = "会員単価";
            this.KaiinTankaCol.MaxInputLength = 7;
            this.KaiinTankaCol.MinimumWidth = 100;
            this.KaiinTankaCol.Name = "KaiinTankaCol";
            // 
            // HiKaiinTankaCol
            // 
            this.HiKaiinTankaCol.DataPropertyName = "YoshiHiKaiinUp";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.HiKaiinTankaCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.HiKaiinTankaCol.HeaderText = "非会員単価";
            this.HiKaiinTankaCol.MaxInputLength = 7;
            this.HiKaiinTankaCol.MinimumWidth = 100;
            this.HiKaiinTankaCol.Name = "HiKaiinTankaCol";
            // 
            // KaiinSetKakakuCol
            // 
            this.KaiinSetKakakuCol.DataPropertyName = "YoshiKaiinSetKakaku";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.KaiinSetKakakuCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.KaiinSetKakakuCol.HeaderText = "会員セット価格";
            this.KaiinSetKakakuCol.MaxInputLength = 7;
            this.KaiinSetKakakuCol.MinimumWidth = 100;
            this.KaiinSetKakakuCol.Name = "KaiinSetKakakuCol";
            // 
            // HiKaiinSetKakakuCol
            // 
            this.HiKaiinSetKakakuCol.DataPropertyName = "YoshiHiKaiinSetKakaku";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.HiKaiinSetKakakuCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.HiKaiinSetKakakuCol.HeaderText = "非会員セット価格";
            this.HiKaiinSetKakakuCol.MaxInputLength = 7;
            this.HiKaiinSetKakakuCol.MinimumWidth = 100;
            this.HiKaiinSetKakakuCol.Name = "HiKaiinSetKakakuCol";
            // 
            // SetBusuCol
            // 
            this.SetBusuCol.DataPropertyName = "YoshiSetBusu";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.SetBusuCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.SetBusuCol.HeaderText = "セット部数";
            this.SetBusuCol.MaxInputLength = 3;
            this.SetBusuCol.MinimumWidth = 100;
            this.SetBusuCol.Name = "SetBusuCol";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "YoshiCd";
            this.dataGridViewTextBoxColumn1.HeaderText = "YoshiCd";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "YoshiNm";
            this.dataGridViewTextBoxColumn2.HeaderText = "YoshiNm";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // KaiinTankaOriginalCol
            // 
            this.KaiinTankaOriginalCol.DataPropertyName = "YoshiKaiinUpOriginal";
            this.KaiinTankaOriginalCol.HeaderText = "YoshiKaiinUp";
            this.KaiinTankaOriginalCol.Name = "KaiinTankaOriginalCol";
            this.KaiinTankaOriginalCol.Visible = false;
            // 
            // HiKaiinTankaOriginalCol
            // 
            this.HiKaiinTankaOriginalCol.DataPropertyName = "YoshiHiKaiinUpOriginal";
            this.HiKaiinTankaOriginalCol.HeaderText = "YoshiHiKaiinUp";
            this.HiKaiinTankaOriginalCol.Name = "HiKaiinTankaOriginalCol";
            this.HiKaiinTankaOriginalCol.Visible = false;
            // 
            // KaiinSetKakakuOriginalCol
            // 
            this.KaiinSetKakakuOriginalCol.DataPropertyName = "YoshiKaiinSetKakakuOriginal";
            this.KaiinSetKakakuOriginalCol.HeaderText = "YoshiKaiinSetKakaku";
            this.KaiinSetKakakuOriginalCol.Name = "KaiinSetKakakuOriginalCol";
            this.KaiinSetKakakuOriginalCol.Visible = false;
            // 
            // HiKaiinSetKakakuOriginalCol
            // 
            this.HiKaiinSetKakakuOriginalCol.DataPropertyName = "YoshiHiKaiinSetKakakuOriginal";
            this.HiKaiinSetKakakuOriginalCol.HeaderText = "YoshiHiKaiinSetKakaku";
            this.HiKaiinSetKakakuOriginalCol.Name = "HiKaiinSetKakakuOriginalCol";
            this.HiKaiinSetKakakuOriginalCol.Visible = false;
            // 
            // SetBusuOriginalCol
            // 
            this.SetBusuOriginalCol.DataPropertyName = "YoshiSetBusuOriginal";
            this.SetBusuOriginalCol.HeaderText = "YoshiSetBusu";
            this.SetBusuOriginalCol.Name = "SetBusuOriginalCol";
            this.SetBusuOriginalCol.Visible = false;
            // 
            // IsUpdateCol
            // 
            this.IsUpdateCol.DataPropertyName = "IsUpdate";
            this.IsUpdateCol.HeaderText = "IsUpdate";
            this.IsUpdateCol.Name = "IsUpdateCol";
            this.IsUpdateCol.Visible = false;
            // 
            // YoshiCdOriginalCol
            // 
            this.YoshiCdOriginalCol.DataPropertyName = "YoshiCdOriginal";
            this.YoshiCdOriginalCol.HeaderText = "YoshiCdOriginal";
            this.YoshiCdOriginalCol.Name = "YoshiCdOriginalCol";
            this.YoshiCdOriginalCol.Visible = false;
            // 
            // YoshiNmOriginalCol
            // 
            this.YoshiNmOriginalCol.DataPropertyName = "YoshiNmOriginal";
            this.YoshiNmOriginalCol.HeaderText = "YoshiNmOriginal";
            this.YoshiNmOriginalCol.Name = "YoshiNmOriginalCol";
            this.YoshiNmOriginalCol.Visible = false;
            // 
            // YoshiKaiinUpOriginalCol
            // 
            this.YoshiKaiinUpOriginalCol.DataPropertyName = "YoshiKaiinUpOriginal";
            this.YoshiKaiinUpOriginalCol.HeaderText = "YoshiKaiinUpOriginal";
            this.YoshiKaiinUpOriginalCol.Name = "YoshiKaiinUpOriginalCol";
            this.YoshiKaiinUpOriginalCol.Visible = false;
            // 
            // YoshiHiKaiinUpOriginalCol
            // 
            this.YoshiHiKaiinUpOriginalCol.DataPropertyName = "YoshiHiKaiinUpOriginal";
            this.YoshiHiKaiinUpOriginalCol.HeaderText = "YoshiHiKaiinUpOriginal";
            this.YoshiHiKaiinUpOriginalCol.Name = "YoshiHiKaiinUpOriginalCol";
            this.YoshiHiKaiinUpOriginalCol.Visible = false;
            // 
            // YoshiKaiinSetKakakuOriginalCol
            // 
            this.YoshiKaiinSetKakakuOriginalCol.DataPropertyName = "YoshiKaiinSetKakakuOriginal";
            this.YoshiKaiinSetKakakuOriginalCol.HeaderText = "YoshiKaiinSetKakakuOriginal";
            this.YoshiKaiinSetKakakuOriginalCol.Name = "YoshiKaiinSetKakakuOriginalCol";
            this.YoshiKaiinSetKakakuOriginalCol.Visible = false;
            // 
            // YoshiHiKaiinSetKakakuOriginalCol
            // 
            this.YoshiHiKaiinSetKakakuOriginalCol.DataPropertyName = "YoshiHiKaiinSetKakakuOriginal";
            this.YoshiHiKaiinSetKakakuOriginalCol.HeaderText = "YoshiHiKaiinSetKakakuOriginal";
            this.YoshiHiKaiinSetKakakuOriginalCol.Name = "YoshiHiKaiinSetKakakuOriginalCol";
            this.YoshiHiKaiinSetKakakuOriginalCol.Visible = false;
            // 
            // YoshiSetBusuOriginalCol
            // 
            this.YoshiSetBusuOriginalCol.DataPropertyName = "YoshiSetBusuOriginal";
            this.YoshiSetBusuOriginalCol.HeaderText = "YoshiSetBusuOriginal";
            this.YoshiSetBusuOriginalCol.Name = "YoshiSetBusuOriginalCol";
            this.YoshiSetBusuOriginalCol.Visible = false;
            // 
            // InsertDtCol
            // 
            this.InsertDtCol.DataPropertyName = "InsertDt";
            this.InsertDtCol.HeaderText = "InsertDt";
            this.InsertDtCol.Name = "InsertDtCol";
            this.InsertDtCol.Visible = false;
            // 
            // InsertUserCol
            // 
            this.InsertUserCol.DataPropertyName = "InsertUser";
            this.InsertUserCol.HeaderText = "InsertUser";
            this.InsertUserCol.Name = "InsertUserCol";
            this.InsertUserCol.Visible = false;
            // 
            // InsertTarmCol
            // 
            this.InsertTarmCol.DataPropertyName = "InsertTarm";
            this.InsertTarmCol.HeaderText = "InsertTarm";
            this.InsertTarmCol.Name = "InsertTarmCol";
            this.InsertTarmCol.Visible = false;
            // 
            // UpdateDtCol
            // 
            this.UpdateDtCol.DataPropertyName = "UpdateDt";
            this.UpdateDtCol.HeaderText = "UpdateDt";
            this.UpdateDtCol.Name = "UpdateDtCol";
            this.UpdateDtCol.Visible = false;
            // 
            // UpdateUserCol
            // 
            this.UpdateUserCol.DataPropertyName = "UpdateUser";
            this.UpdateUserCol.HeaderText = "UpdateUser";
            this.UpdateUserCol.Name = "UpdateUserCol";
            this.UpdateUserCol.Visible = false;
            // 
            // UpdateTarmCol
            // 
            this.UpdateTarmCol.DataPropertyName = "UpdateTarm";
            this.UpdateTarmCol.HeaderText = "UpdateTarm";
            this.UpdateTarmCol.Name = "UpdateTarmCol";
            this.UpdateTarmCol.Visible = false;
            // 
            // yoshiMstUpdateDataSetBindingSource
            // 
            this.yoshiMstUpdateDataSetBindingSource.DataSource = this.yoshiMstUpdateDataSet;
            this.yoshiMstUpdateDataSetBindingSource.Position = 0;
            // 
            // yoshiMstUpdateDataSet
            // 
            this.yoshiMstUpdateDataSet.DataSetName = "YoshiMstUpdateDataSet";
            this.yoshiMstUpdateDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(111, 71);
            this.nameTextBox.MaxLength = 60;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(617, 27);
            this.nameTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // shiireListPanel
            // 
            this.shiireListPanel.Controls.Add(this.shiireListCountLabel);
            this.shiireListPanel.Controls.Add(this.label4);
            this.shiireListPanel.Controls.Add(this.shiireListDataGridView);
            this.shiireListPanel.Location = new System.Drawing.Point(0, 136);
            this.shiireListPanel.Name = "shiireListPanel";
            this.shiireListPanel.Size = new System.Drawing.Size(1100, 392);
            this.shiireListPanel.TabIndex = 12;
            // 
            // shiireListCountLabel
            // 
            this.shiireListCountLabel.AutoSize = true;
            this.shiireListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.shiireListCountLabel.Name = "shiireListCountLabel";
            this.shiireListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.shiireListCountLabel.TabIndex = 1;
            this.shiireListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "検索結果：";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.yoshiCdFromTextBox);
            this.searchPanel.Controls.Add(this.yoshiCdToTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.nameTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1100, 128);
            this.searchPanel.TabIndex = 11;
            // 
            // yoshiCdFromTextBox
            // 
            this.yoshiCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.yoshiCdFromTextBox.CustomDigitParts = 0;
            this.yoshiCdFromTextBox.CustomFormat = null;
            this.yoshiCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.yoshiCdFromTextBox.CustomReadOnly = false;
            this.yoshiCdFromTextBox.Location = new System.Drawing.Point(111, 38);
            this.yoshiCdFromTextBox.MaxLength = 2;
            this.yoshiCdFromTextBox.Name = "yoshiCdFromTextBox";
            this.yoshiCdFromTextBox.Size = new System.Drawing.Size(48, 27);
            this.yoshiCdFromTextBox.TabIndex = 4;
            this.yoshiCdFromTextBox.Leave += new System.EventHandler(this.yoshiCdFromTextBox_Leave);
            // 
            // yoshiCdToTextBox
            // 
            this.yoshiCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.yoshiCdToTextBox.CustomDigitParts = 0;
            this.yoshiCdToTextBox.CustomFormat = null;
            this.yoshiCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.yoshiCdToTextBox.CustomReadOnly = false;
            this.yoshiCdToTextBox.Location = new System.Drawing.Point(193, 38);
            this.yoshiCdToTextBox.MaxLength = 2;
            this.yoshiCdToTextBox.Name = "yoshiCdToTextBox";
            this.yoshiCdToTextBox.Size = new System.Drawing.Size(48, 27);
            this.yoshiCdToTextBox.TabIndex = 6;
            this.yoshiCdToTextBox.Leave += new System.EventHandler(this.yoshiCdToTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1068, 3);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 11;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "用紙コード";
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
            this.clearButton.Location = new System.Drawing.Point(888, 75);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(995, 74);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 10;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(996, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 15;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // YoshiMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.shiireListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YoshiMstListForm";
            this.Text = "仕入入力";
            this.Load += new System.EventHandler(this.YoshiMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YoshiMstListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.shiireListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstUpdateDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiMstUpdateDataSet)).EndInit();
            this.shiireListPanel.ResumeLayout(false);
            this.shiireListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.DataGridView shiireListDataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel shiireListPanel;
        private System.Windows.Forms.Label shiireListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private Control.NumberTextBox yoshiCdFromTextBox;
        private Control.NumberTextBox yoshiCdToTextBox;
        private System.Windows.Forms.BindingSource yoshiMstUpdateDataSetBindingSource;
        private YoshiMstUpdateDataSet yoshiMstUpdateDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KaiinTankaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HiKaiinTankaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KaiinSetKakakuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HiKaiinSetKakakuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetBusuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KaiinTankaOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HiKaiinTankaOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KaiinSetKakakuOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HiKaiinSetKakakuOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetBusuOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUpdateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiCdOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiNmOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiKaiinUpOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiHiKaiinUpOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiKaiinSetKakakuOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiHiKaiinSetKakakuOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiSetBusuOriginalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertUserCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertTarmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateUserCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTarmCol;
    }
}