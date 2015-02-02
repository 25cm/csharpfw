using FukjBizSystem.Control;
namespace FukjBizSystem.Application.Boundary.Master
{
    partial class ShokuinMstShosaiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.shokuinShukeiJogaiFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.shokuinKensainFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.shokuinCdTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.shokuinTaishokuDtTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.shokuinTaishokuFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.yakushokuListDataGridView = new System.Windows.Forms.DataGridView();
            this.BushoComboBoxCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bushoMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bushoMstDataSet = new FukjBizSystem.Application.DataSet.BushoMstDataSet();
            this.YakushokuComboBoxCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.yakushokuMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yakushokuMstDataSet = new FukjBizSystem.Application.DataSet.YakushokuMstDataSet();
            this.InsertDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertUserCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertTarmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUserCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTarmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShozokuShokuinCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShozokuBushoCdOrgCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShozokuYakushokuCdOrgCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BushoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YakushokuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shozokuMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shozokuMstDataSet = new FukjBizSystem.Application.DataSet.ShozokuMstDataSet();
            this.label21 = new System.Windows.Forms.Label();
            this.shokuinInjiJunTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.shokuinPasswordTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.shokuinNyushaDtTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.shokuinSeinengappiTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.shokuinKanaTextBox = new System.Windows.Forms.TextBox();
            this.shozokuShishoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.shokuinNmTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.entryButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.decisionButton = new System.Windows.Forms.Button();
            this.reInputButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.bushoMstTableAdapter = new FukjBizSystem.Application.DataSet.BushoMstDataSetTableAdapters.BushoMstTableAdapter();
            this.yakushokuMstTableAdapter = new FukjBizSystem.Application.DataSet.YakushokuMstDataSetTableAdapters.YakushokuMstTableAdapter();
            this.shozokuMstTableAdapter = new FukjBizSystem.Application.DataSet.ShozokuMstDataSetTableAdapters.ShozokuMstTableAdapter();
            this.mainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shozokuMstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shozokuMstDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "職員コード";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.shokuinShukeiJogaiFlgCheckBox);
            this.mainPanel.Controls.Add(this.label28);
            this.mainPanel.Controls.Add(this.shokuinKensainFlgCheckBox);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.shokuinCdTextBox);
            this.mainPanel.Controls.Add(this.label27);
            this.mainPanel.Controls.Add(this.label26);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.label24);
            this.mainPanel.Controls.Add(this.label22);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.yakushokuListDataGridView);
            this.mainPanel.Controls.Add(this.label21);
            this.mainPanel.Controls.Add(this.shokuinInjiJunTextBox);
            this.mainPanel.Controls.Add(this.label18);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.shokuinPasswordTextBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.shokuinNyushaDtTextBox);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.shokuinSeinengappiTextBox);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.shokuinKanaTextBox);
            this.mainPanel.Controls.Add(this.shozokuShishoComboBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.shokuinNmTextBox);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.changeButton);
            this.mainPanel.Controls.Add(this.decisionButton);
            this.mainPanel.Controls.Add(this.reInputButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1099, 593);
            this.mainPanel.TabIndex = 0;
            // 
            // shokuinShukeiJogaiFlgCheckBox
            // 
            this.shokuinShukeiJogaiFlgCheckBox.AutoSize = true;
            this.shokuinShukeiJogaiFlgCheckBox.Location = new System.Drawing.Point(437, 222);
            this.shokuinShukeiJogaiFlgCheckBox.Name = "shokuinShukeiJogaiFlgCheckBox";
            this.shokuinShukeiJogaiFlgCheckBox.Size = new System.Drawing.Size(15, 14);
            this.shokuinShukeiJogaiFlgCheckBox.TabIndex = 26;
            this.shokuinShukeiJogaiFlgCheckBox.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(294, 218);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(139, 20);
            this.label28.TabIndex = 25;
            this.label28.Text = "検査員月報役職フラグ";
            // 
            // shokuinKensainFlgCheckBox
            // 
            this.shokuinKensainFlgCheckBox.AutoSize = true;
            this.shokuinKensainFlgCheckBox.Location = new System.Drawing.Point(437, 197);
            this.shokuinKensainFlgCheckBox.Name = "shokuinKensainFlgCheckBox";
            this.shokuinKensainFlgCheckBox.Size = new System.Drawing.Size(301, 24);
            this.shokuinKensainFlgCheckBox.TabIndex = 24;
            this.shokuinKensainFlgCheckBox.Text = "（※検査員の場合はチェックを付けて下さい）";
            this.shokuinKensainFlgCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "検査員フラグ";
            // 
            // shokuinCdTextBox
            // 
            this.shokuinCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokuinCdTextBox.CustomDigitParts = 0;
            this.shokuinCdTextBox.CustomFormat = null;
            this.shokuinCdTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokuinCdTextBox.CustomReadOnly = false;
            this.shokuinCdTextBox.Location = new System.Drawing.Point(111, 57);
            this.shokuinCdTextBox.MaxLength = 3;
            this.shokuinCdTextBox.Name = "shokuinCdTextBox";
            this.shokuinCdTextBox.Size = new System.Drawing.Size(35, 27);
            this.shokuinCdTextBox.TabIndex = 5;
            this.shokuinCdTextBox.Leave += new System.EventHandler(this.shokuinCdTextBox_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(20, 513);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(373, 20);
            this.label27.TabIndex = 31;
            this.label27.Text = "（※役職を兼任している場合は全ての役職を入力して下さい）";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(76, 227);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 20);
            this.label26.TabIndex = 28;
            this.label26.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.shokuinTaishokuDtTextBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.shokuinTaishokuFlgCheckBox);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Location = new System.Drawing.Point(337, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 108);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(206, 58);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(134, 20);
            this.label23.TabIndex = 4;
            this.label23.Text = "例)20140101 (半角)";
            // 
            // shokuinTaishokuDtTextBox
            // 
            this.shokuinTaishokuDtTextBox.Location = new System.Drawing.Point(100, 53);
            this.shokuinTaishokuDtTextBox.MaxLength = 8;
            this.shokuinTaishokuDtTextBox.Name = "shokuinTaishokuDtTextBox";
            this.shokuinTaishokuDtTextBox.Size = new System.Drawing.Size(100, 27);
            this.shokuinTaishokuDtTextBox.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "退職日付";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "退職フラグ";
            // 
            // shokuinTaishokuFlgCheckBox
            // 
            this.shokuinTaishokuFlgCheckBox.AutoSize = true;
            this.shokuinTaishokuFlgCheckBox.Location = new System.Drawing.Point(100, 22);
            this.shokuinTaishokuFlgCheckBox.Name = "shokuinTaishokuFlgCheckBox";
            this.shokuinTaishokuFlgCheckBox.Size = new System.Drawing.Size(301, 24);
            this.shokuinTaishokuFlgCheckBox.TabIndex = 1;
            this.shokuinTaishokuFlgCheckBox.Text = "（※退職者の場合はチェックを付けて下さい）";
            this.shokuinTaishokuFlgCheckBox.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(15, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(451, 20);
            this.label25.TabIndex = 5;
            this.label25.Text = "（※退職日付は退職フラグにチェックを付けている場合のみ必須入力です）";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 493);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(199, 20);
            this.label24.TabIndex = 30;
            this.label24.Text = "（※1件以上の入力が必須です）";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(543, 60);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(134, 20);
            this.label22.TabIndex = 21;
            this.label22.Text = "例)20140101 (半角)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(543, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(134, 20);
            this.label17.TabIndex = 18;
            this.label17.Text = "例)20140101 (半角)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "役職一覧";
            // 
            // yakushokuListDataGridView
            // 
            this.yakushokuListDataGridView.AllowUserToResizeRows = false;
            this.yakushokuListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.yakushokuListDataGridView.AutoGenerateColumns = false;
            this.yakushokuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yakushokuListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BushoComboBoxCol,
            this.YakushokuComboBoxCol,
            this.InsertDtCol,
            this.InsertUserCol,
            this.InsertTarmCol,
            this.UpdateDtCol,
            this.UpdateUserCol,
            this.UpdateTarmCol,
            this.ShozokuShokuinCdCol,
            this.ShozokuBushoCdOrgCol,
            this.ShozokuYakushokuCdOrgCol,
            this.IsUpdate,
            this.BushoNmCol,
            this.YakushokuNmCol});
            this.yakushokuListDataGridView.DataSource = this.shozokuMstBindingSource;
            this.yakushokuListDataGridView.Location = new System.Drawing.Point(24, 248);
            this.yakushokuListDataGridView.Name = "yakushokuListDataGridView";
            this.yakushokuListDataGridView.RowHeadersVisible = false;
            this.yakushokuListDataGridView.RowTemplate.Height = 21;
            this.yakushokuListDataGridView.Size = new System.Drawing.Size(756, 242);
            this.yakushokuListDataGridView.TabIndex = 29;
            this.yakushokuListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.yakushokuListDataGridView_DataError);
            this.yakushokuListDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.yakushokuListDataGridView_DefaultValuesNeeded);
            // 
            // BushoComboBoxCol
            // 
            this.BushoComboBoxCol.DataPropertyName = "ShozokuBushoCd";
            this.BushoComboBoxCol.DataSource = this.bushoMstBindingSource;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BushoComboBoxCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.BushoComboBoxCol.DisplayMember = "BushoNm";
            this.BushoComboBoxCol.HeaderText = "部署*";
            this.BushoComboBoxCol.MinimumWidth = 200;
            this.BushoComboBoxCol.Name = "BushoComboBoxCol";
            this.BushoComboBoxCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BushoComboBoxCol.ValueMember = "BushoCd";
            this.BushoComboBoxCol.Width = 200;
            // 
            // bushoMstBindingSource
            // 
            this.bushoMstBindingSource.DataMember = "BushoMst";
            this.bushoMstBindingSource.DataSource = this.bushoMstDataSet;
            // 
            // bushoMstDataSet
            // 
            this.bushoMstDataSet.DataSetName = "BushoMstDataSet";
            this.bushoMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // YakushokuComboBoxCol
            // 
            this.YakushokuComboBoxCol.DataPropertyName = "ShozokuYakushokuCd";
            this.YakushokuComboBoxCol.DataSource = this.yakushokuMstBindingSource;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.YakushokuComboBoxCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.YakushokuComboBoxCol.DisplayMember = "YakushokuNm";
            this.YakushokuComboBoxCol.HeaderText = "役職*";
            this.YakushokuComboBoxCol.MinimumWidth = 200;
            this.YakushokuComboBoxCol.Name = "YakushokuComboBoxCol";
            this.YakushokuComboBoxCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.YakushokuComboBoxCol.ValueMember = "YakushokuCd";
            this.YakushokuComboBoxCol.Width = 200;
            // 
            // yakushokuMstBindingSource
            // 
            this.yakushokuMstBindingSource.DataMember = "YakushokuMst";
            this.yakushokuMstBindingSource.DataSource = this.yakushokuMstDataSet;
            // 
            // yakushokuMstDataSet
            // 
            this.yakushokuMstDataSet.DataSetName = "YakushokuMstDataSet";
            this.yakushokuMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // InsertDtCol
            // 
            this.InsertDtCol.DataPropertyName = "InsertDt";
            this.InsertDtCol.HeaderText = "InsertDtCol";
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
            // ShozokuShokuinCdCol
            // 
            this.ShozokuShokuinCdCol.DataPropertyName = "ShozokuShokuinCd";
            this.ShozokuShokuinCdCol.HeaderText = "ShozokuShokuinCd";
            this.ShozokuShokuinCdCol.Name = "ShozokuShokuinCdCol";
            this.ShozokuShokuinCdCol.Visible = false;
            // 
            // ShozokuBushoCdOrgCol
            // 
            this.ShozokuBushoCdOrgCol.DataPropertyName = "ShozokuBushoCdOrg";
            this.ShozokuBushoCdOrgCol.HeaderText = "ShozokuBushoCdOrg";
            this.ShozokuBushoCdOrgCol.Name = "ShozokuBushoCdOrgCol";
            this.ShozokuBushoCdOrgCol.Visible = false;
            // 
            // ShozokuYakushokuCdOrgCol
            // 
            this.ShozokuYakushokuCdOrgCol.DataPropertyName = "ShozokuYakushokuCdOrg";
            this.ShozokuYakushokuCdOrgCol.HeaderText = "ShozokuYakushokuCdOrg";
            this.ShozokuYakushokuCdOrgCol.Name = "ShozokuYakushokuCdOrgCol";
            this.ShozokuYakushokuCdOrgCol.Visible = false;
            // 
            // IsUpdate
            // 
            this.IsUpdate.DataPropertyName = "IsUpdate";
            this.IsUpdate.HeaderText = "IsUpdate";
            this.IsUpdate.Name = "IsUpdate";
            this.IsUpdate.Visible = false;
            // 
            // BushoNmCol
            // 
            this.BushoNmCol.DataPropertyName = "BushoNm";
            this.BushoNmCol.HeaderText = "BushoNm";
            this.BushoNmCol.Name = "BushoNmCol";
            this.BushoNmCol.Visible = false;
            // 
            // YakushokuNmCol
            // 
            this.YakushokuNmCol.DataPropertyName = "YakushokuNm";
            this.YakushokuNmCol.HeaderText = "YakushokuNm";
            this.YakushokuNmCol.Name = "YakushokuNmCol";
            this.YakushokuNmCol.Visible = false;
            // 
            // shozokuMstBindingSource
            // 
            this.shozokuMstBindingSource.DataMember = "ShozokuMst";
            this.shozokuMstBindingSource.DataSource = this.shozokuMstDataSet;
            // 
            // shozokuMstDataSet
            // 
            this.shozokuMstDataSet.DataSetName = "ShozokuMstDataSet";
            this.shozokuMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 192);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 20);
            this.label21.TabIndex = 14;
            this.label21.Text = "印字順";
            // 
            // shokuinInjiJunTextBox
            // 
            this.shokuinInjiJunTextBox.Location = new System.Drawing.Point(111, 189);
            this.shokuinInjiJunTextBox.MaxLength = 5;
            this.shokuinInjiJunTextBox.Name = "shokuinInjiJunTextBox";
            this.shokuinInjiJunTextBox.Size = new System.Drawing.Size(100, 27);
            this.shokuinInjiJunTextBox.TabIndex = 15;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(89, 161);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 20);
            this.label18.TabIndex = 12;
            this.label18.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 159);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 11;
            this.label19.Text = "パスワード";
            // 
            // shokuinPasswordTextBox
            // 
            this.shokuinPasswordTextBox.AllowDropDown = false;
            this.shokuinPasswordTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokuinPasswordTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shokuinPasswordTextBox.CustomReadOnly = false;
            this.shokuinPasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.shokuinPasswordTextBox.Location = new System.Drawing.Point(111, 156);
            this.shokuinPasswordTextBox.MaxLength = 10;
            this.shokuinPasswordTextBox.Name = "shokuinPasswordTextBox";
            this.shokuinPasswordTextBox.Size = new System.Drawing.Size(100, 27);
            this.shokuinPasswordTextBox.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(346, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "入社日付";
            // 
            // shokuinNyushaDtTextBox
            // 
            this.shokuinNyushaDtTextBox.Location = new System.Drawing.Point(437, 56);
            this.shokuinNyushaDtTextBox.MaxLength = 8;
            this.shokuinNyushaDtTextBox.Name = "shokuinNyushaDtTextBox";
            this.shokuinNyushaDtTextBox.Size = new System.Drawing.Size(100, 27);
            this.shokuinNyushaDtTextBox.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(346, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "生年月日";
            // 
            // shokuinSeinengappiTextBox
            // 
            this.shokuinSeinengappiTextBox.Location = new System.Drawing.Point(437, 23);
            this.shokuinSeinengappiTextBox.MaxLength = 8;
            this.shokuinSeinengappiTextBox.Name = "shokuinSeinengappiTextBox";
            this.shokuinSeinengappiTextBox.Size = new System.Drawing.Size(100, 27);
            this.shokuinSeinengappiTextBox.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "職員カナ";
            // 
            // shokuinKanaTextBox
            // 
            this.shokuinKanaTextBox.Location = new System.Drawing.Point(111, 123);
            this.shokuinKanaTextBox.MaxLength = 20;
            this.shokuinKanaTextBox.Name = "shokuinKanaTextBox";
            this.shokuinKanaTextBox.Size = new System.Drawing.Size(200, 27);
            this.shokuinKanaTextBox.TabIndex = 10;
            // 
            // shozokuShishoComboBox
            // 
            this.shozokuShishoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shozokuShishoComboBox.FormattingEnabled = true;
            this.shozokuShishoComboBox.Location = new System.Drawing.Point(111, 23);
            this.shozokuShishoComboBox.Name = "shozokuShishoComboBox";
            this.shozokuShishoComboBox.Size = new System.Drawing.Size(200, 28);
            this.shozokuShishoComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(62, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "職員名";
            // 
            // shokuinNmTextBox
            // 
            this.shokuinNmTextBox.Location = new System.Drawing.Point(111, 90);
            this.shokuinNmTextBox.MaxLength = 20;
            this.shokuinNmTextBox.Name = "shokuinNmTextBox";
            this.shokuinNmTextBox.Size = new System.Drawing.Size(200, 27);
            this.shokuinNmTextBox.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(76, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(88, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "所属支所";
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(421, 553);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 32;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(528, 553);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(101, 37);
            this.changeButton.TabIndex = 33;
            this.changeButton.Text = "F2:変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.Location = new System.Drawing.Point(849, 553);
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(101, 37);
            this.decisionButton.TabIndex = 36;
            this.decisionButton.Text = "F5:確定";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.decisionButton_Click);
            // 
            // reInputButton
            // 
            this.reInputButton.Location = new System.Drawing.Point(742, 553);
            this.reInputButton.Name = "reInputButton";
            this.reInputButton.Size = new System.Drawing.Size(101, 37);
            this.reInputButton.TabIndex = 35;
            this.reInputButton.Text = "F4:再入力";
            this.reInputButton.UseVisualStyleBackColor = true;
            this.reInputButton.Click += new System.EventHandler(this.reInputButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(635, 553);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 34;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 37;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // bushoMstTableAdapter
            // 
            this.bushoMstTableAdapter.ClearBeforeFill = true;
            // 
            // yakushokuMstTableAdapter
            // 
            this.yakushokuMstTableAdapter.ClearBeforeFill = true;
            // 
            // shozokuMstTableAdapter
            // 
            this.shozokuMstTableAdapter.ClearBeforeFill = true;
            // 
            // ShokuinMstShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShokuinMstShosaiForm";
            this.Text = "職員マスタ登録";
            this.Load += new System.EventHandler(this.ShokuinMstShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShokuinMstShosaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushoMstDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yakushokuMstDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shozokuMstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shozokuMstDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button decisionButton;
        private System.Windows.Forms.Button reInputButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox shozokuShishoComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox shokuinNmTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox shokuinInjiJunTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private ZTextBox shokuinPasswordTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox shokuinNyushaDtTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox shokuinSeinengappiTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox shokuinKanaTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView yakushokuListDataGridView;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox shokuinTaishokuDtTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox shokuinTaishokuFlgCheckBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private Control.NumberTextBox shokuinCdTextBox;
        private DataSet.BushoMstDataSet bushoMstDataSet;
        private System.Windows.Forms.BindingSource bushoMstBindingSource;
        private DataSet.BushoMstDataSetTableAdapters.BushoMstTableAdapter bushoMstTableAdapter;
        private DataSet.YakushokuMstDataSet yakushokuMstDataSet;
        private System.Windows.Forms.BindingSource yakushokuMstBindingSource;
        private DataSet.YakushokuMstDataSetTableAdapters.YakushokuMstTableAdapter yakushokuMstTableAdapter;
        private DataSet.ShozokuMstDataSet shozokuMstDataSet;
        private System.Windows.Forms.BindingSource shozokuMstBindingSource;
        private DataSet.ShozokuMstDataSetTableAdapters.ShozokuMstTableAdapter shozokuMstTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn BushoComboBoxCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn YakushokuComboBoxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertUserCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertTarmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateUserCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTarmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShozokuShokuinCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShozokuBushoCdOrgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShozokuYakushokuCdOrgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BushoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YakushokuNmCol;
        private System.Windows.Forms.CheckBox shokuinKensainFlgCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox shokuinShukeiJogaiFlgCheckBox;
        private System.Windows.Forms.Label label28;
    }
}