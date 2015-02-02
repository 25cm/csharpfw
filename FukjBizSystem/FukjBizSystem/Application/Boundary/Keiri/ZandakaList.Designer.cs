namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class ZandakaListForm
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
            this.seikyuListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.oyaSeikyuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saiseikyuCntCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyosyaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuKamokuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syohinNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuGakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyukinGakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saiseikyuCntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuGyosyaCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyusakiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuKomokuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuKingakuKeiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyukinTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zandakaListKensakuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seikyuHdrTblDataSet = new FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSet();
            this.srhListPanel = new System.Windows.Forms.Panel();
            this.srhListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nyukinInputButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.syohinNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.seikyuNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyosyaCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyosyaCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.hoshoTorokuCheckBox = new System.Windows.Forms.CheckBox();
            this.kensa11SuishitsuCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nenkaihiCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.yoshiHanbaiCheckBox = new System.Windows.Forms.CheckBox();
            this.kensa7JoCheckBox = new System.Windows.Forms.CheckBox();
            this.keiryoShomeiCheckBox = new System.Windows.Forms.CheckBox();
            this.kensa11GaikanCheckBox = new System.Windows.Forms.CheckBox();
            this.seikyuDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.seikyuDtToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.seikyuDtFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.saiseikyuButton = new System.Windows.Forms.Button();
            this.ikkatsuSeikyuButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.zandakaListKensakuTableAdapter = new FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSetTableAdapters.ZandakaListKensakuTableAdapter();
            this.saiseikyuNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zandakaListKensakuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuHdrTblDataSet)).BeginInit();
            this.srhListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.oyaSeikyuNoCol,
            this.seikyuNoCol,
            this.seikyuRenbanCol,
            this.saiseikyuCntCol,
            this.gyosyaCdCol,
            this.seikyuNmCol,
            this.seikyuDtCol,
            this.seikyuKamokuCol,
            this.syohinNmCol,
            this.seikyuGakuCol,
            this.nyukinGakuCol,
            this.seikyuNoDataGridViewTextBoxColumn,
            this.seikyuRenbanDataGridViewTextBoxColumn,
            this.saiseikyuCntDataGridViewTextBoxColumn,
            this.seikyuGyosyaCdDataGridViewTextBoxColumn,
            this.seikyusakiNmDataGridViewTextBoxColumn,
            this.seikyuDtDataGridViewTextBoxColumn,
            this.seikyuKomokuNmDataGridViewTextBoxColumn,
            this.seikyuKingakuKeiDataGridViewTextBoxColumn,
            this.nyukinTotalDataGridViewTextBoxColumn});
            this.seikyuListDataGridView.DataSource = this.zandakaListKensakuBindingSource;
            this.seikyuListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.seikyuListDataGridView.MultiSelect = false;
            this.seikyuListDataGridView.Name = "seikyuListDataGridView";
            this.seikyuListDataGridView.ReadOnly = true;
            this.seikyuListDataGridView.RowHeadersVisible = false;
            this.seikyuListDataGridView.RowTemplate.Height = 21;
            this.seikyuListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.seikyuListDataGridView.Size = new System.Drawing.Size(1085, 327);
            this.seikyuListDataGridView.TabIndex = 0;
            // 
            // oyaSeikyuNoCol
            // 
            this.oyaSeikyuNoCol.DataPropertyName = "OyaSeikyuNo";
            this.oyaSeikyuNoCol.HeaderText = "請求No";
            this.oyaSeikyuNoCol.Name = "oyaSeikyuNoCol";
            this.oyaSeikyuNoCol.ReadOnly = true;
            // 
            // seikyuNoCol
            // 
            this.seikyuNoCol.DataPropertyName = "SeikyuNo";
            this.seikyuNoCol.HeaderText = "請求No（隠し）";
            this.seikyuNoCol.MaxInputLength = 10;
            this.seikyuNoCol.MinimumWidth = 90;
            this.seikyuNoCol.Name = "seikyuNoCol";
            this.seikyuNoCol.ReadOnly = true;
            this.seikyuNoCol.Visible = false;
            this.seikyuNoCol.Width = 90;
            // 
            // seikyuRenbanCol
            // 
            this.seikyuRenbanCol.DataPropertyName = "SeikyuRenban";
            this.seikyuRenbanCol.HeaderText = "連番";
            this.seikyuRenbanCol.MaxInputLength = 2;
            this.seikyuRenbanCol.MinimumWidth = 60;
            this.seikyuRenbanCol.Name = "seikyuRenbanCol";
            this.seikyuRenbanCol.ReadOnly = true;
            this.seikyuRenbanCol.Width = 60;
            // 
            // saiseikyuCntCol
            // 
            this.saiseikyuCntCol.DataPropertyName = "SaiseikyuCnt";
            this.saiseikyuCntCol.HeaderText = "再請求回数";
            this.saiseikyuCntCol.MaxInputLength = 2;
            this.saiseikyuCntCol.MinimumWidth = 80;
            this.saiseikyuCntCol.Name = "saiseikyuCntCol";
            this.saiseikyuCntCol.ReadOnly = true;
            this.saiseikyuCntCol.Width = 80;
            // 
            // gyosyaCdCol
            // 
            this.gyosyaCdCol.DataPropertyName = "SeikyuGyosyaCd";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gyosyaCdCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.gyosyaCdCol.HeaderText = "業者ｺｰﾄﾞ";
            this.gyosyaCdCol.MaxInputLength = 4;
            this.gyosyaCdCol.MinimumWidth = 70;
            this.gyosyaCdCol.Name = "gyosyaCdCol";
            this.gyosyaCdCol.ReadOnly = true;
            this.gyosyaCdCol.Width = 70;
            // 
            // seikyuNmCol
            // 
            this.seikyuNmCol.DataPropertyName = "SeikyusakiNm";
            this.seikyuNmCol.HeaderText = "請求先名称";
            this.seikyuNmCol.MaxInputLength = 60;
            this.seikyuNmCol.MinimumWidth = 180;
            this.seikyuNmCol.Name = "seikyuNmCol";
            this.seikyuNmCol.ReadOnly = true;
            this.seikyuNmCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seikyuNmCol.Width = 180;
            // 
            // seikyuDtCol
            // 
            this.seikyuDtCol.DataPropertyName = "SeikyuDt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.seikyuDtCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.seikyuDtCol.HeaderText = "請求日";
            this.seikyuDtCol.MaxInputLength = 10;
            this.seikyuDtCol.MinimumWidth = 90;
            this.seikyuDtCol.Name = "seikyuDtCol";
            this.seikyuDtCol.ReadOnly = true;
            this.seikyuDtCol.Width = 90;
            // 
            // seikyuKamokuCol
            // 
            this.seikyuKamokuCol.DataPropertyName = "SeikyuKomokuNm";
            this.seikyuKamokuCol.HeaderText = "請求科目";
            this.seikyuKamokuCol.MaxInputLength = 40;
            this.seikyuKamokuCol.MinimumWidth = 100;
            this.seikyuKamokuCol.Name = "seikyuKamokuCol";
            this.seikyuKamokuCol.ReadOnly = true;
            // 
            // syohinNmCol
            // 
            this.syohinNmCol.DataPropertyName = "SeikyuSyohinNm";
            this.syohinNmCol.HeaderText = "商品名";
            this.syohinNmCol.MaxInputLength = 60;
            this.syohinNmCol.MinimumWidth = 200;
            this.syohinNmCol.Name = "syohinNmCol";
            this.syohinNmCol.ReadOnly = true;
            this.syohinNmCol.Width = 200;
            // 
            // seikyuGakuCol
            // 
            this.seikyuGakuCol.DataPropertyName = "SeikyuKingakuKei";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.seikyuGakuCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.seikyuGakuCol.HeaderText = "請求額";
            this.seikyuGakuCol.MaxInputLength = 10;
            this.seikyuGakuCol.MinimumWidth = 90;
            this.seikyuGakuCol.Name = "seikyuGakuCol";
            this.seikyuGakuCol.ReadOnly = true;
            this.seikyuGakuCol.Width = 90;
            // 
            // nyukinGakuCol
            // 
            this.nyukinGakuCol.DataPropertyName = "NyukinTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.nyukinGakuCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.nyukinGakuCol.HeaderText = "入金額";
            this.nyukinGakuCol.MaxInputLength = 10;
            this.nyukinGakuCol.MinimumWidth = 90;
            this.nyukinGakuCol.Name = "nyukinGakuCol";
            this.nyukinGakuCol.ReadOnly = true;
            this.nyukinGakuCol.Width = 90;
            // 
            // seikyuNoDataGridViewTextBoxColumn
            // 
            this.seikyuNoDataGridViewTextBoxColumn.DataPropertyName = "SeikyuNo";
            this.seikyuNoDataGridViewTextBoxColumn.HeaderText = "SeikyuNo";
            this.seikyuNoDataGridViewTextBoxColumn.Name = "seikyuNoDataGridViewTextBoxColumn";
            this.seikyuNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyuNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // seikyuRenbanDataGridViewTextBoxColumn
            // 
            this.seikyuRenbanDataGridViewTextBoxColumn.DataPropertyName = "SeikyuRenban";
            this.seikyuRenbanDataGridViewTextBoxColumn.HeaderText = "SeikyuRenban";
            this.seikyuRenbanDataGridViewTextBoxColumn.Name = "seikyuRenbanDataGridViewTextBoxColumn";
            this.seikyuRenbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyuRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // saiseikyuCntDataGridViewTextBoxColumn
            // 
            this.saiseikyuCntDataGridViewTextBoxColumn.DataPropertyName = "SaiseikyuCnt";
            this.saiseikyuCntDataGridViewTextBoxColumn.HeaderText = "SaiseikyuCnt";
            this.saiseikyuCntDataGridViewTextBoxColumn.Name = "saiseikyuCntDataGridViewTextBoxColumn";
            this.saiseikyuCntDataGridViewTextBoxColumn.ReadOnly = true;
            this.saiseikyuCntDataGridViewTextBoxColumn.Visible = false;
            // 
            // seikyuGyosyaCdDataGridViewTextBoxColumn
            // 
            this.seikyuGyosyaCdDataGridViewTextBoxColumn.DataPropertyName = "SeikyuGyosyaCd";
            this.seikyuGyosyaCdDataGridViewTextBoxColumn.HeaderText = "SeikyuGyosyaCd";
            this.seikyuGyosyaCdDataGridViewTextBoxColumn.Name = "seikyuGyosyaCdDataGridViewTextBoxColumn";
            this.seikyuGyosyaCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyuGyosyaCdDataGridViewTextBoxColumn.Visible = false;
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
            // seikyuKomokuNmDataGridViewTextBoxColumn
            // 
            this.seikyuKomokuNmDataGridViewTextBoxColumn.DataPropertyName = "SeikyuKomokuNm";
            this.seikyuKomokuNmDataGridViewTextBoxColumn.HeaderText = "SeikyuKomokuNm";
            this.seikyuKomokuNmDataGridViewTextBoxColumn.Name = "seikyuKomokuNmDataGridViewTextBoxColumn";
            this.seikyuKomokuNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyuKomokuNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // seikyuKingakuKeiDataGridViewTextBoxColumn
            // 
            this.seikyuKingakuKeiDataGridViewTextBoxColumn.DataPropertyName = "SeikyuKingakuKei";
            this.seikyuKingakuKeiDataGridViewTextBoxColumn.HeaderText = "SeikyuKingakuKei";
            this.seikyuKingakuKeiDataGridViewTextBoxColumn.Name = "seikyuKingakuKeiDataGridViewTextBoxColumn";
            this.seikyuKingakuKeiDataGridViewTextBoxColumn.ReadOnly = true;
            this.seikyuKingakuKeiDataGridViewTextBoxColumn.Visible = false;
            // 
            // nyukinTotalDataGridViewTextBoxColumn
            // 
            this.nyukinTotalDataGridViewTextBoxColumn.DataPropertyName = "NyukinTotal";
            this.nyukinTotalDataGridViewTextBoxColumn.HeaderText = "NyukinTotal";
            this.nyukinTotalDataGridViewTextBoxColumn.Name = "nyukinTotalDataGridViewTextBoxColumn";
            this.nyukinTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.nyukinTotalDataGridViewTextBoxColumn.Visible = false;
            // 
            // zandakaListKensakuBindingSource
            // 
            this.zandakaListKensakuBindingSource.DataMember = "ZandakaListKensaku";
            this.zandakaListKensakuBindingSource.DataSource = this.seikyuHdrTblDataSet;
            // 
            // seikyuHdrTblDataSet
            // 
            this.seikyuHdrTblDataSet.DataSetName = "SeikyuHdrTblDataSet";
            this.seikyuHdrTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // srhListPanel
            // 
            this.srhListPanel.Controls.Add(this.srhListCountLabel);
            this.srhListPanel.Controls.Add(this.label4);
            this.srhListPanel.Controls.Add(this.seikyuListDataGridView);
            this.srhListPanel.Location = new System.Drawing.Point(1, 187);
            this.srhListPanel.Name = "srhListPanel";
            this.srhListPanel.Size = new System.Drawing.Size(1090, 351);
            this.srhListPanel.TabIndex = 1;
            // 
            // srhListCountLabel
            // 
            this.srhListCountLabel.AutoSize = true;
            this.srhListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.srhListCountLabel.Name = "srhListCountLabel";
            this.srhListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.srhListCountLabel.TabIndex = 2;
            this.srhListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "検索結果：";
            // 
            // nyukinInputButton
            // 
            this.nyukinInputButton.Location = new System.Drawing.Point(492, 544);
            this.nyukinInputButton.Name = "nyukinInputButton";
            this.nyukinInputButton.Size = new System.Drawing.Size(101, 37);
            this.nyukinInputButton.TabIndex = 5;
            this.nyukinInputButton.Text = "F2:入金入力";
            this.nyukinInputButton.UseVisualStyleBackColor = true;
            this.nyukinInputButton.Click += new System.EventHandler(this.nyukinInputButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(854, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 8;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "請求先名";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 24;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "業者コード";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.syohinNmTextBox);
            this.searchPanel.Controls.Add(this.seikyuNmTextBox);
            this.searchPanel.Controls.Add(this.gyosyaCdToTextBox);
            this.searchPanel.Controls.Add(this.gyosyaCdFromTextBox);
            this.searchPanel.Controls.Add(this.hoshoTorokuCheckBox);
            this.searchPanel.Controls.Add(this.kensa11SuishitsuCheckBox);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.nenkaihiCheckBox);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.yoshiHanbaiCheckBox);
            this.searchPanel.Controls.Add(this.kensa7JoCheckBox);
            this.searchPanel.Controls.Add(this.keiryoShomeiCheckBox);
            this.searchPanel.Controls.Add(this.kensa11GaikanCheckBox);
            this.searchPanel.Controls.Add(this.seikyuDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.seikyuDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.seikyuDtFromDateTimePicker);
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
            // syohinNmTextBox
            // 
            this.syohinNmTextBox.AllowDropDown = false;
            this.syohinNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.syohinNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.syohinNmTextBox.CustomReadOnly = false;
            this.syohinNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.syohinNmTextBox.Location = new System.Drawing.Point(107, 96);
            this.syohinNmTextBox.MaxLength = 60;
            this.syohinNmTextBox.Name = "syohinNmTextBox";
            this.syohinNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.syohinNmTextBox.TabIndex = 16;
            // 
            // seikyuNmTextBox
            // 
            this.seikyuNmTextBox.AllowDropDown = false;
            this.seikyuNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.seikyuNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.seikyuNmTextBox.CustomReadOnly = false;
            this.seikyuNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.seikyuNmTextBox.Location = new System.Drawing.Point(387, 35);
            this.seikyuNmTextBox.MaxLength = 60;
            this.seikyuNmTextBox.Name = "seikyuNmTextBox";
            this.seikyuNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.seikyuNmTextBox.TabIndex = 6;
            // 
            // gyosyaCdToTextBox
            // 
            this.gyosyaCdToTextBox.AllowDropDown = false;
            this.gyosyaCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyosyaCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.gyosyaCdToTextBox.CustomReadOnly = false;
            this.gyosyaCdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyosyaCdToTextBox.Location = new System.Drawing.Point(210, 35);
            this.gyosyaCdToTextBox.MaxLength = 4;
            this.gyosyaCdToTextBox.Name = "gyosyaCdToTextBox";
            this.gyosyaCdToTextBox.Size = new System.Drawing.Size(51, 27);
            this.gyosyaCdToTextBox.TabIndex = 4;
            this.gyosyaCdToTextBox.Leave += new System.EventHandler(this.GyoshaCdTextBox_Leave);
            // 
            // gyosyaCdFromTextBox
            // 
            this.gyosyaCdFromTextBox.AllowDropDown = false;
            this.gyosyaCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyosyaCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.gyosyaCdFromTextBox.CustomReadOnly = false;
            this.gyosyaCdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyosyaCdFromTextBox.Location = new System.Drawing.Point(108, 34);
            this.gyosyaCdFromTextBox.MaxLength = 4;
            this.gyosyaCdFromTextBox.Name = "gyosyaCdFromTextBox";
            this.gyosyaCdFromTextBox.Size = new System.Drawing.Size(51, 27);
            this.gyosyaCdFromTextBox.TabIndex = 2;
            this.gyosyaCdFromTextBox.Leave += new System.EventHandler(this.GyoshaCdTextBox_Leave);
            // 
            // hoshoTorokuCheckBox
            // 
            this.hoshoTorokuCheckBox.AutoSize = true;
            this.hoshoTorokuCheckBox.Checked = true;
            this.hoshoTorokuCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hoshoTorokuCheckBox.Location = new System.Drawing.Point(534, 68);
            this.hoshoTorokuCheckBox.Name = "hoshoTorokuCheckBox";
            this.hoshoTorokuCheckBox.Size = new System.Drawing.Size(80, 24);
            this.hoshoTorokuCheckBox.TabIndex = 12;
            this.hoshoTorokuCheckBox.Text = "保証登録";
            this.hoshoTorokuCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensa11SuishitsuCheckBox
            // 
            this.kensa11SuishitsuCheckBox.AutoSize = true;
            this.kensa11SuishitsuCheckBox.Checked = true;
            this.kensa11SuishitsuCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensa11SuishitsuCheckBox.Location = new System.Drawing.Point(321, 68);
            this.kensa11SuishitsuCheckBox.Name = "kensa11SuishitsuCheckBox";
            this.kensa11SuishitsuCheckBox.Size = new System.Drawing.Size(121, 24);
            this.kensa11SuishitsuCheckBox.TabIndex = 10;
            this.kensa11SuishitsuCheckBox.Text = "11条検査(水質)";
            this.kensa11SuishitsuCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "商品名";
            // 
            // nenkaihiCheckBox
            // 
            this.nenkaihiCheckBox.AutoSize = true;
            this.nenkaihiCheckBox.Checked = true;
            this.nenkaihiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nenkaihiCheckBox.Location = new System.Drawing.Point(693, 68);
            this.nenkaihiCheckBox.Name = "nenkaihiCheckBox";
            this.nenkaihiCheckBox.Size = new System.Drawing.Size(67, 24);
            this.nenkaihiCheckBox.TabIndex = 14;
            this.nenkaihiCheckBox.Text = "年会費";
            this.nenkaihiCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "請求科目";
            // 
            // yoshiHanbaiCheckBox
            // 
            this.yoshiHanbaiCheckBox.AutoSize = true;
            this.yoshiHanbaiCheckBox.Checked = true;
            this.yoshiHanbaiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yoshiHanbaiCheckBox.Location = new System.Drawing.Point(614, 68);
            this.yoshiHanbaiCheckBox.Name = "yoshiHanbaiCheckBox";
            this.yoshiHanbaiCheckBox.Size = new System.Drawing.Size(80, 24);
            this.yoshiHanbaiCheckBox.TabIndex = 13;
            this.yoshiHanbaiCheckBox.Text = "用紙販売";
            this.yoshiHanbaiCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensa7JoCheckBox
            // 
            this.kensa7JoCheckBox.AutoSize = true;
            this.kensa7JoCheckBox.Checked = true;
            this.kensa7JoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensa7JoCheckBox.Location = new System.Drawing.Point(108, 68);
            this.kensa7JoCheckBox.Name = "kensa7JoCheckBox";
            this.kensa7JoCheckBox.Size = new System.Drawing.Size(75, 24);
            this.kensa7JoCheckBox.TabIndex = 8;
            this.kensa7JoCheckBox.Text = "7条検査";
            this.kensa7JoCheckBox.UseVisualStyleBackColor = true;
            // 
            // keiryoShomeiCheckBox
            // 
            this.keiryoShomeiCheckBox.AutoSize = true;
            this.keiryoShomeiCheckBox.Checked = true;
            this.keiryoShomeiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keiryoShomeiCheckBox.Location = new System.Drawing.Point(448, 68);
            this.keiryoShomeiCheckBox.Name = "keiryoShomeiCheckBox";
            this.keiryoShomeiCheckBox.Size = new System.Drawing.Size(80, 24);
            this.keiryoShomeiCheckBox.TabIndex = 11;
            this.keiryoShomeiCheckBox.Text = "計量証明";
            this.keiryoShomeiCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensa11GaikanCheckBox
            // 
            this.kensa11GaikanCheckBox.AutoSize = true;
            this.kensa11GaikanCheckBox.Checked = true;
            this.kensa11GaikanCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensa11GaikanCheckBox.Location = new System.Drawing.Point(194, 68);
            this.kensa11GaikanCheckBox.Name = "kensa11GaikanCheckBox";
            this.kensa11GaikanCheckBox.Size = new System.Drawing.Size(121, 24);
            this.kensa11GaikanCheckBox.TabIndex = 9;
            this.kensa11GaikanCheckBox.Text = "11条検査(外観)";
            this.kensa11GaikanCheckBox.UseVisualStyleBackColor = true;
            // 
            // seikyuDtUseCheckBox
            // 
            this.seikyuDtUseCheckBox.AutoSize = true;
            this.seikyuDtUseCheckBox.Location = new System.Drawing.Point(9, 139);
            this.seikyuDtUseCheckBox.Name = "seikyuDtUseCheckBox";
            this.seikyuDtUseCheckBox.Size = new System.Drawing.Size(15, 14);
            this.seikyuDtUseCheckBox.TabIndex = 17;
            this.seikyuDtUseCheckBox.UseVisualStyleBackColor = true;
            this.seikyuDtUseCheckBox.CheckedChanged += new System.EventHandler(this.seikyuDtUseCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "～";
            // 
            // seikyuDtToDateTimePicker
            // 
            this.seikyuDtToDateTimePicker.CustomFormat = "yyyy年M月d日";
            this.seikyuDtToDateTimePicker.Enabled = false;
            this.seikyuDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seikyuDtToDateTimePicker.Location = new System.Drawing.Point(286, 131);
            this.seikyuDtToDateTimePicker.Name = "seikyuDtToDateTimePicker";
            this.seikyuDtToDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.seikyuDtToDateTimePicker.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "請求日";
            // 
            // seikyuDtFromDateTimePicker
            // 
            this.seikyuDtFromDateTimePicker.CustomFormat = "yyyy年M月d日";
            this.seikyuDtFromDateTimePicker.Enabled = false;
            this.seikyuDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seikyuDtFromDateTimePicker.Location = new System.Drawing.Point(107, 131);
            this.seikyuDtFromDateTimePicker.Name = "seikyuDtFromDateTimePicker";
            this.seikyuDtFromDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.seikyuDtFromDateTimePicker.TabIndex = 19;
            this.seikyuDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.seikyuDtFromDateTimePicker_ValueChanged);
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
            this.clearButton.TabIndex = 22;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(985, 132);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 23;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(990, 544);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saiseikyuButton
            // 
            this.saiseikyuButton.Location = new System.Drawing.Point(599, 544);
            this.saiseikyuButton.Name = "saiseikyuButton";
            this.saiseikyuButton.Size = new System.Drawing.Size(113, 37);
            this.saiseikyuButton.TabIndex = 6;
            this.saiseikyuButton.Text = "F3:再請求願い";
            this.saiseikyuButton.UseVisualStyleBackColor = true;
            this.saiseikyuButton.Click += new System.EventHandler(this.saiseikyuButton_Click);
            // 
            // ikkatsuSeikyuButton
            // 
            this.ikkatsuSeikyuButton.Location = new System.Drawing.Point(718, 544);
            this.ikkatsuSeikyuButton.Name = "ikkatsuSeikyuButton";
            this.ikkatsuSeikyuButton.Size = new System.Drawing.Size(117, 37);
            this.ikkatsuSeikyuButton.TabIndex = 7;
            this.ikkatsuSeikyuButton.Text = "F4:再請求明細";
            this.ikkatsuSeikyuButton.UseVisualStyleBackColor = true;
            this.ikkatsuSeikyuButton.Click += new System.EventHandler(this.ikkatsuSeikyuButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(174, 552);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "号";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 552);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "再請求印刷  第";
            // 
            // zandakaListKensakuTableAdapter
            // 
            this.zandakaListKensakuTableAdapter.ClearBeforeFill = true;
            // 
            // saiseikyuNoTextBox
            // 
            this.saiseikyuNoTextBox.AllowDropDown = false;
            this.saiseikyuNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.saiseikyuNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.saiseikyuNoTextBox.CustomReadOnly = false;
            this.saiseikyuNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.saiseikyuNoTextBox.Location = new System.Drawing.Point(117, 549);
            this.saiseikyuNoTextBox.MaxLength = 5;
            this.saiseikyuNoTextBox.Name = "saiseikyuNoTextBox";
            this.saiseikyuNoTextBox.Size = new System.Drawing.Size(51, 27);
            this.saiseikyuNoTextBox.TabIndex = 25;
            this.saiseikyuNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ZandakaListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.saiseikyuNoTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ikkatsuSeikyuButton);
            this.Controls.Add(this.saiseikyuButton);
            this.Controls.Add(this.srhListPanel);
            this.Controls.Add(this.nyukinInputButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ZandakaListForm";
            this.Text = "請求残高一覧";
            this.Load += new System.EventHandler(this.ZandakaListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZandakaListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zandakaListKensakuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuHdrTblDataSet)).EndInit();
            this.srhListPanel.ResumeLayout(false);
            this.srhListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zynas.Control.ZDataGridView.ZDataGridView seikyuListDataGridView;
        private System.Windows.Forms.Panel srhListPanel;
        private System.Windows.Forms.Label srhListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button nyukinInputButton;
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
        private System.Windows.Forms.CheckBox seikyuDtUseCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker seikyuDtToDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker seikyuDtFromDateTimePicker;
        private System.Windows.Forms.Button saiseikyuButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox nenkaihiCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox yoshiHanbaiCheckBox;
        private System.Windows.Forms.CheckBox kensa7JoCheckBox;
        private System.Windows.Forms.CheckBox keiryoShomeiCheckBox;
        private System.Windows.Forms.CheckBox kensa11GaikanCheckBox;
        private System.Windows.Forms.CheckBox kensa11SuishitsuCheckBox;
        private System.Windows.Forms.CheckBox hoshoTorokuCheckBox;
        private System.Windows.Forms.Button ikkatsuSeikyuButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DataSet.SeikyuHdrTblDataSet seikyuHdrTblDataSet;
        private System.Windows.Forms.BindingSource zandakaListKensakuBindingSource;
        private DataSet.SeikyuHdrTblDataSetTableAdapters.ZandakaListKensakuTableAdapter zandakaListKensakuTableAdapter;
        private Control.ZTextBox gyosyaCdToTextBox;
        private Control.ZTextBox gyosyaCdFromTextBox;
        private Control.ZTextBox seikyuNmTextBox;
        private Control.ZTextBox syohinNmTextBox;
        private Control.ZTextBox saiseikyuNoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn oyaSeikyuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuRenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn saiseikyuCntCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyosyaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuKamokuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn syohinNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuGakuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyukinGakuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saiseikyuCntDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuGyosyaCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyusakiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuKomokuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuKingakuKeiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyukinTotalDataGridViewTextBoxColumn;

    }
}