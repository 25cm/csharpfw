namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class SeikyuListForm
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
            this.seikyuListKensakuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seikyuHdrTblDataSet = new FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSet();
            this.seikyuListKensakuTableAdapter = new FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSetTableAdapters.SeikyuListKensakuTableAdapter();
            this.ikkatsuSeikyuButton = new System.Windows.Forms.Button();
            this.shimeSyoriButton = new System.Windows.Forms.Button();
            this.srhListPanel = new System.Windows.Forms.Panel();
            this.srhListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.seikyuListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.seikyuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shimeKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyosyaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuTotalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shimeKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyusakiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyusyoHakkoFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oyaSeikyuNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuKingakuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.seikyuNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyosyaCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyosyaCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.shimeNenGetsuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.hakkozumiRadioButton = new System.Windows.Forms.RadioButton();
            this.miHakkoRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jimukyokuRadioButton = new System.Windows.Forms.RadioButton();
            this.chikuhoRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.seikyuDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.seikyuDtToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.seikyuDtFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListKensakuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuHdrTblDataSet)).BeginInit();
            this.srhListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // seikyuListKensakuBindingSource
            // 
            this.seikyuListKensakuBindingSource.DataMember = "SeikyuListKensaku";
            this.seikyuListKensakuBindingSource.DataSource = this.seikyuHdrTblDataSet;
            // 
            // seikyuHdrTblDataSet
            // 
            this.seikyuHdrTblDataSet.DataSetName = "SeikyuHdrTblDataSet";
            this.seikyuHdrTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // seikyuListKensakuTableAdapter
            // 
            this.seikyuListKensakuTableAdapter.ClearBeforeFill = true;
            // 
            // ikkatsuSeikyuButton
            // 
            this.ikkatsuSeikyuButton.Location = new System.Drawing.Point(729, 544);
            this.ikkatsuSeikyuButton.Name = "ikkatsuSeikyuButton";
            this.ikkatsuSeikyuButton.Size = new System.Drawing.Size(101, 37);
            this.ikkatsuSeikyuButton.TabIndex = 4;
            this.ikkatsuSeikyuButton.Text = "F3:一括請求";
            this.ikkatsuSeikyuButton.UseVisualStyleBackColor = true;
            this.ikkatsuSeikyuButton.Click += new System.EventHandler(this.ikkatsuSeikyuButton_Click);
            // 
            // shimeSyoriButton
            // 
            this.shimeSyoriButton.Location = new System.Drawing.Point(466, 544);
            this.shimeSyoriButton.Name = "shimeSyoriButton";
            this.shimeSyoriButton.Size = new System.Drawing.Size(101, 37);
            this.shimeSyoriButton.TabIndex = 2;
            this.shimeSyoriButton.Text = "F1:締め処理";
            this.shimeSyoriButton.UseVisualStyleBackColor = true;
            this.shimeSyoriButton.Click += new System.EventHandler(this.shimeSyoriButton_Click);
            // 
            // srhListPanel
            // 
            this.srhListPanel.Controls.Add(this.srhListCountLabel);
            this.srhListPanel.Controls.Add(this.label4);
            this.srhListPanel.Controls.Add(this.seikyuListDataGridView);
            this.srhListPanel.Location = new System.Drawing.Point(1, 187);
            this.srhListPanel.Name = "srhListPanel";
            this.srhListPanel.Size = new System.Drawing.Size(1090, 339);
            this.srhListPanel.TabIndex = 1;
            // 
            // srhListCountLabel
            // 
            this.srhListCountLabel.AutoSize = true;
            this.srhListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.srhListCountLabel.Name = "srhListCountLabel";
            this.srhListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.srhListCountLabel.TabIndex = 1;
            this.srhListCountLabel.Text = "0件";
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
            // seikyuListDataGridView
            // 
            this.seikyuListDataGridView.AllowUserToAddRows = false;
            this.seikyuListDataGridView.AllowUserToDeleteRows = false;
            this.seikyuListDataGridView.AllowUserToResizeRows = false;
            this.seikyuListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seikyuListDataGridView.AutoGenerateColumns = false;
            this.seikyuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seikyuListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seikyuNoCol,
            this.shimeKbnCol,
            this.gyosyaCdCol,
            this.seikyuNmCol,
            this.seikyuDtCol,
            this.seikyuTotalCol,
            this.kbnCol,
            this.shimeKbnDataGridViewTextBoxColumn,
            this.seikyusakiNmDataGridViewTextBoxColumn,
            this.seikyuDtDataGridViewTextBoxColumn,
            this.seikyusyoHakkoFlgDataGridViewTextBoxColumn,
            this.oyaSeikyuNoDataGridViewTextBoxColumn,
            this.ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn,
            this.seikyuKingakuDataGridViewTextBoxColumn});
            this.seikyuListDataGridView.DataSource = this.seikyuListKensakuBindingSource;
            this.seikyuListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.seikyuListDataGridView.MultiSelect = false;
            this.seikyuListDataGridView.Name = "seikyuListDataGridView";
            this.seikyuListDataGridView.ReadOnly = true;
            this.seikyuListDataGridView.RowHeadersVisible = false;
            this.seikyuListDataGridView.RowTemplate.Height = 21;
            this.seikyuListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.seikyuListDataGridView.Size = new System.Drawing.Size(1085, 312);
            this.seikyuListDataGridView.TabIndex = 2;
            // 
            // seikyuNoCol
            // 
            this.seikyuNoCol.DataPropertyName = "OyaSeikyuNo";
            this.seikyuNoCol.HeaderText = "請求No";
            this.seikyuNoCol.MinimumWidth = 90;
            this.seikyuNoCol.Name = "seikyuNoCol";
            this.seikyuNoCol.ReadOnly = true;
            this.seikyuNoCol.Width = 90;
            // 
            // shimeKbnCol
            // 
            this.shimeKbnCol.DataPropertyName = "ShimeKbn";
            this.shimeKbnCol.HeaderText = "締め区分";
            this.shimeKbnCol.MinimumWidth = 100;
            this.shimeKbnCol.Name = "shimeKbnCol";
            this.shimeKbnCol.ReadOnly = true;
            // 
            // gyosyaCdCol
            // 
            this.gyosyaCdCol.DataPropertyName = "IkkatsuSeikyuSakiCd";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gyosyaCdCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.gyosyaCdCol.HeaderText = "業者コード";
            this.gyosyaCdCol.MinimumWidth = 110;
            this.gyosyaCdCol.Name = "gyosyaCdCol";
            this.gyosyaCdCol.ReadOnly = true;
            this.gyosyaCdCol.Width = 110;
            // 
            // seikyuNmCol
            // 
            this.seikyuNmCol.DataPropertyName = "SeikyusakiNm";
            this.seikyuNmCol.HeaderText = "請求先名称";
            this.seikyuNmCol.MinimumWidth = 400;
            this.seikyuNmCol.Name = "seikyuNmCol";
            this.seikyuNmCol.ReadOnly = true;
            this.seikyuNmCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seikyuNmCol.Width = 400;
            // 
            // seikyuDtCol
            // 
            this.seikyuDtCol.DataPropertyName = "SeikyuDt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.seikyuDtCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.seikyuDtCol.HeaderText = "請求日";
            this.seikyuDtCol.MinimumWidth = 100;
            this.seikyuDtCol.Name = "seikyuDtCol";
            this.seikyuDtCol.ReadOnly = true;
            // 
            // seikyuTotalCol
            // 
            this.seikyuTotalCol.DataPropertyName = "SeikyuKingaku";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.seikyuTotalCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.seikyuTotalCol.HeaderText = "請求額";
            this.seikyuTotalCol.MinimumWidth = 150;
            this.seikyuTotalCol.Name = "seikyuTotalCol";
            this.seikyuTotalCol.ReadOnly = true;
            this.seikyuTotalCol.Width = 150;
            // 
            // kbnCol
            // 
            this.kbnCol.DataPropertyName = "SeikyusyoHakkoFlg";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kbnCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.kbnCol.HeaderText = "発行";
            this.kbnCol.MinimumWidth = 100;
            this.kbnCol.Name = "kbnCol";
            this.kbnCol.ReadOnly = true;
            // 
            // shimeKbnDataGridViewTextBoxColumn
            // 
            this.shimeKbnDataGridViewTextBoxColumn.DataPropertyName = "ShimeKbn";
            this.shimeKbnDataGridViewTextBoxColumn.HeaderText = "ShimeKbn";
            this.shimeKbnDataGridViewTextBoxColumn.Name = "shimeKbnDataGridViewTextBoxColumn";
            this.shimeKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.shimeKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // seikyusakiNmDataGridViewTextBoxColumn
            // 
            this.seikyusakiNmDataGridViewTextBoxColumn.DataPropertyName = "SeikyusakiNm";
            this.seikyusakiNmDataGridViewTextBoxColumn.HeaderText = "SeikyusakiNm";
            this.seikyusakiNmDataGridViewTextBoxColumn.Name = "seikyusakiNmDataGridViewTextBoxColumn";
            this.seikyusakiNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyusakiNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // seikyuDtDataGridViewTextBoxColumn
            // 
            this.seikyuDtDataGridViewTextBoxColumn.DataPropertyName = "SeikyuDt";
            this.seikyuDtDataGridViewTextBoxColumn.HeaderText = "SeikyuDt";
            this.seikyuDtDataGridViewTextBoxColumn.Name = "seikyuDtDataGridViewTextBoxColumn";
            this.seikyuDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyuDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // seikyusyoHakkoFlgDataGridViewTextBoxColumn
            // 
            this.seikyusyoHakkoFlgDataGridViewTextBoxColumn.DataPropertyName = "SeikyusyoHakkoFlg";
            this.seikyusyoHakkoFlgDataGridViewTextBoxColumn.HeaderText = "SeikyusyoHakkoFlg";
            this.seikyusyoHakkoFlgDataGridViewTextBoxColumn.Name = "seikyusyoHakkoFlgDataGridViewTextBoxColumn";
            this.seikyusyoHakkoFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyusyoHakkoFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // oyaSeikyuNoDataGridViewTextBoxColumn
            // 
            this.oyaSeikyuNoDataGridViewTextBoxColumn.DataPropertyName = "OyaSeikyuNo";
            this.oyaSeikyuNoDataGridViewTextBoxColumn.HeaderText = "OyaSeikyuNo";
            this.oyaSeikyuNoDataGridViewTextBoxColumn.Name = "oyaSeikyuNoDataGridViewTextBoxColumn";
            this.oyaSeikyuNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.oyaSeikyuNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn
            // 
            this.ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn.DataPropertyName = "IkkatsuSeikyuSakiCd";
            this.ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn.HeaderText = "IkkatsuSeikyuSakiCd";
            this.ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn.Name = "ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn";
            this.ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // seikyuKingakuDataGridViewTextBoxColumn
            // 
            this.seikyuKingakuDataGridViewTextBoxColumn.DataPropertyName = "SeikyuKingaku";
            this.seikyuKingakuDataGridViewTextBoxColumn.HeaderText = "SeikyuKingaku";
            this.seikyuKingakuDataGridViewTextBoxColumn.Name = "seikyuKingakuDataGridViewTextBoxColumn";
            this.seikyuKingakuDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyuKingakuDataGridViewTextBoxColumn.Visible = false;
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(602, 544);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 3;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(854, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 5;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.seikyuNmTextBox);
            this.searchPanel.Controls.Add(this.gyosyaCdToTextBox);
            this.searchPanel.Controls.Add(this.gyosyaCdFromTextBox);
            this.searchPanel.Controls.Add(this.shimeNenGetsuTextBox);
            this.searchPanel.Controls.Add(this.panel2);
            this.searchPanel.Controls.Add(this.panel1);
            this.searchPanel.Controls.Add(this.label9);
            this.searchPanel.Controls.Add(this.label17);
            this.searchPanel.Controls.Add(this.label11);
            this.searchPanel.Controls.Add(this.seikyuDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.seikyuDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.seikyuDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 184);
            this.searchPanel.TabIndex = 0;
            // 
            // seikyuNmTextBox
            // 
            this.seikyuNmTextBox.AllowDropDown = false;
            this.seikyuNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.seikyuNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.seikyuNmTextBox.CustomReadOnly = false;
            this.seikyuNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.seikyuNmTextBox.Location = new System.Drawing.Point(388, 66);
            this.seikyuNmTextBox.MaxLength = 60;
            this.seikyuNmTextBox.Name = "seikyuNmTextBox";
            this.seikyuNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.seikyuNmTextBox.TabIndex = 9;
            // 
            // gyosyaCdToTextBox
            // 
            this.gyosyaCdToTextBox.AllowDropDown = false;
            this.gyosyaCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyosyaCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.gyosyaCdToTextBox.CustomReadOnly = false;
            this.gyosyaCdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyosyaCdToTextBox.Location = new System.Drawing.Point(211, 66);
            this.gyosyaCdToTextBox.MaxLength = 4;
            this.gyosyaCdToTextBox.Name = "gyosyaCdToTextBox";
            this.gyosyaCdToTextBox.Size = new System.Drawing.Size(51, 27);
            this.gyosyaCdToTextBox.TabIndex = 7;
            this.gyosyaCdToTextBox.Leave += new System.EventHandler(this.GyoshaCdTextBox_Leave);
            // 
            // gyosyaCdFromTextBox
            // 
            this.gyosyaCdFromTextBox.AllowDropDown = false;
            this.gyosyaCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyosyaCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.gyosyaCdFromTextBox.CustomReadOnly = false;
            this.gyosyaCdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyosyaCdFromTextBox.Location = new System.Drawing.Point(108, 66);
            this.gyosyaCdFromTextBox.MaxLength = 4;
            this.gyosyaCdFromTextBox.Name = "gyosyaCdFromTextBox";
            this.gyosyaCdFromTextBox.Size = new System.Drawing.Size(51, 27);
            this.gyosyaCdFromTextBox.TabIndex = 5;
            this.gyosyaCdFromTextBox.Leave += new System.EventHandler(this.GyoshaCdTextBox_Leave);
            // 
            // shimeNenGetsuTextBox
            // 
            this.shimeNenGetsuTextBox.AllowDropDown = false;
            this.shimeNenGetsuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_NEN_GETSU;
            this.shimeNenGetsuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.shimeNenGetsuTextBox.CustomReadOnly = false;
            this.shimeNenGetsuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.shimeNenGetsuTextBox.Location = new System.Drawing.Point(107, 33);
            this.shimeNenGetsuTextBox.MaxLength = 6;
            this.shimeNenGetsuTextBox.Name = "shimeNenGetsuTextBox";
            this.shimeNenGetsuTextBox.Size = new System.Drawing.Size(81, 27);
            this.shimeNenGetsuTextBox.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.allRadioButton);
            this.panel2.Controls.Add(this.hakkozumiRadioButton);
            this.panel2.Controls.Add(this.miHakkoRadioButton);
            this.panel2.Location = new System.Drawing.Point(107, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 24);
            this.panel2.TabIndex = 11;
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Checked = true;
            this.allRadioButton.Location = new System.Drawing.Point(3, 2);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(53, 24);
            this.allRadioButton.TabIndex = 0;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "全件";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // hakkozumiRadioButton
            // 
            this.hakkozumiRadioButton.AutoSize = true;
            this.hakkozumiRadioButton.Location = new System.Drawing.Point(62, 2);
            this.hakkozumiRadioButton.Name = "hakkozumiRadioButton";
            this.hakkozumiRadioButton.Size = new System.Drawing.Size(66, 24);
            this.hakkozumiRadioButton.TabIndex = 1;
            this.hakkozumiRadioButton.Text = "発行済";
            this.hakkozumiRadioButton.UseVisualStyleBackColor = true;
            // 
            // miHakkoRadioButton
            // 
            this.miHakkoRadioButton.AutoSize = true;
            this.miHakkoRadioButton.Location = new System.Drawing.Point(134, 2);
            this.miHakkoRadioButton.Name = "miHakkoRadioButton";
            this.miHakkoRadioButton.Size = new System.Drawing.Size(66, 24);
            this.miHakkoRadioButton.TabIndex = 2;
            this.miHakkoRadioButton.Text = "未発行";
            this.miHakkoRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.jimukyokuRadioButton);
            this.panel1.Controls.Add(this.chikuhoRadioButton);
            this.panel1.Location = new System.Drawing.Point(107, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 25);
            this.panel1.TabIndex = 10;
            // 
            // jimukyokuRadioButton
            // 
            this.jimukyokuRadioButton.AutoSize = true;
            this.jimukyokuRadioButton.Checked = true;
            this.jimukyokuRadioButton.Location = new System.Drawing.Point(3, 3);
            this.jimukyokuRadioButton.Name = "jimukyokuRadioButton";
            this.jimukyokuRadioButton.Size = new System.Drawing.Size(66, 24);
            this.jimukyokuRadioButton.TabIndex = 0;
            this.jimukyokuRadioButton.TabStop = true;
            this.jimukyokuRadioButton.Text = "事務局";
            this.jimukyokuRadioButton.UseVisualStyleBackColor = true;
            // 
            // chikuhoRadioButton
            // 
            this.chikuhoRadioButton.AutoSize = true;
            this.chikuhoRadioButton.Location = new System.Drawing.Point(91, 3);
            this.chikuhoRadioButton.Name = "chikuhoRadioButton";
            this.chikuhoRadioButton.Size = new System.Drawing.Size(117, 24);
            this.chikuhoRadioButton.TabIndex = 1;
            this.chikuhoRadioButton.Text = "筑豊(水質検査)";
            this.chikuhoRadioButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "締め区分";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(207, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 20);
            this.label17.TabIndex = 3;
            this.label17.Text = "例)201401 (半角)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "締め年月";
            // 
            // seikyuDtUseCheckBox
            // 
            this.seikyuDtUseCheckBox.AutoSize = true;
            this.seikyuDtUseCheckBox.Location = new System.Drawing.Point(13, 161);
            this.seikyuDtUseCheckBox.Name = "seikyuDtUseCheckBox";
            this.seikyuDtUseCheckBox.Size = new System.Drawing.Size(15, 14);
            this.seikyuDtUseCheckBox.TabIndex = 12;
            this.seikyuDtUseCheckBox.UseVisualStyleBackColor = true;
            this.seikyuDtUseCheckBox.CheckedChanged += new System.EventHandler(this.seikyuDtUseCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "～";
            // 
            // seikyuDtToDateTimePicker
            // 
            this.seikyuDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.seikyuDtToDateTimePicker.Enabled = false;
            this.seikyuDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seikyuDtToDateTimePicker.Location = new System.Drawing.Point(289, 154);
            this.seikyuDtToDateTimePicker.Name = "seikyuDtToDateTimePicker";
            this.seikyuDtToDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.seikyuDtToDateTimePicker.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "請求日";
            // 
            // seikyuDtFromDateTimePicker
            // 
            this.seikyuDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.seikyuDtFromDateTimePicker.Enabled = false;
            this.seikyuDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seikyuDtFromDateTimePicker.Location = new System.Drawing.Point(108, 153);
            this.seikyuDtFromDateTimePicker.Name = "seikyuDtFromDateTimePicker";
            this.seikyuDtFromDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.seikyuDtFromDateTimePicker.TabIndex = 14;
            this.seikyuDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.seikyuDtFromDateTimePicker_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "発行区分";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "請求先名";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 19;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "業者コード";
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
            this.clearButton.Location = new System.Drawing.Point(878, 133);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 17;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(985, 132);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 18;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(990, 544);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SeikyuListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.ikkatsuSeikyuButton);
            this.Controls.Add(this.shimeSyoriButton);
            this.Controls.Add(this.srhListPanel);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SeikyuListForm";
            this.Text = "請求状況一覧";
            this.Load += new System.EventHandler(this.SeikyuListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeikyuListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListKensakuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuHdrTblDataSet)).EndInit();
            this.srhListPanel.ResumeLayout(false);
            this.srhListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZDataGridView.ZDataGridView seikyuListDataGridView;
        private System.Windows.Forms.Button shimeSyoriButton;
        private System.Windows.Forms.Panel srhListPanel;
        private System.Windows.Forms.Label srhListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RadioButton miHakkoRadioButton;
        private System.Windows.Forms.RadioButton hakkozumiRadioButton;
        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.CheckBox seikyuDtUseCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker seikyuDtToDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker seikyuDtFromDateTimePicker;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button ikkatsuSeikyuButton;
        private System.Windows.Forms.RadioButton chikuhoRadioButton;
        private System.Windows.Forms.RadioButton jimukyokuRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Control.ZTextBox seikyuNmTextBox;
        private Control.ZTextBox gyosyaCdToTextBox;
        private Control.ZTextBox gyosyaCdFromTextBox;
        private Control.ZTextBox shimeNenGetsuTextBox;
        private DataSet.SeikyuHdrTblDataSet seikyuHdrTblDataSet;
        private System.Windows.Forms.BindingSource seikyuListKensakuBindingSource;
        private DataSet.SeikyuHdrTblDataSetTableAdapters.SeikyuListKensakuTableAdapter seikyuListKensakuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shimeKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyosyaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuTotalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shimeKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyusakiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyusyoHakkoFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oyaSeikyuNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ikkatsuSeikyuSakiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuKingakuDataGridViewTextBoxColumn;

    }
}