namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    partial class KeiryoShomeiOutputListForm
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
            this.printButton = new System.Windows.Forms.Button();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.keiryoListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.nendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suikenNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoteiDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settisyaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shomeishoPrintCntCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keiryoShomeiListCountLabel = new System.Windows.Forms.Label();
            this.kensakuKekkaLabel = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.senyoRadioButton = new System.Windows.Forms.RadioButton();
            this.senyoshiRadioButton = new System.Windows.Forms.RadioButton();
            this.tsujoRadioButton = new System.Windows.Forms.RadioButton();
            this.busuLabel = new System.Windows.Forms.Label();
            this.edabanCheckBox = new System.Windows.Forms.CheckBox();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.settishaLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uketsukeDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.suikenNoLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.shishoLabel = new System.Windows.Forms.Label();
            this.shishoComboBox = new System.Windows.Forms.ComboBox();
            this.nendoLabel = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.keiryoShomeiRadioButton = new System.Windows.Forms.RadioButton();
            this.bunssekiHokokuRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uketsukeOrderRadioButton = new System.Windows.Forms.RadioButton();
            this.gyoshaOrderRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chouHyouKubunLabel = new System.Windows.Forms.Label();
            this.uketsukeDtToTextBox = new System.Windows.Forms.DateTimePicker();
            this.uketsukeDtFromTextBox = new System.Windows.Forms.DateTimePicker();
            this.settishaTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.suikenNoToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.suikenNoFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.nendoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.insatsuKubunLabel = new System.Windows.Forms.Label();
            this.insatsuHaniLabel = new System.Windows.Forms.Label();
            this.tujoRadioButton = new System.Windows.Forms.RadioButton();
            this.busuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.insatsuKubunPanel = new System.Windows.Forms.Panel();
            this.insatsuHaniPanel = new System.Windows.Forms.Panel();
            this.outputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keiryoListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.insatsuKubunPanel.SuspendLayout();
            this.insatsuHaniPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(776, 544);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(101, 37);
            this.printButton.TabIndex = 8;
            this.printButton.Text = "F1:印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.keiryoListDataGridView);
            this.outputPanel.Controls.Add(this.keiryoShomeiListCountLabel);
            this.outputPanel.Controls.Add(this.kensakuKekkaLabel);
            this.outputPanel.Location = new System.Drawing.Point(1, 199);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(1090, 327);
            this.outputPanel.TabIndex = 1;
            // 
            // keiryoListDataGridView
            // 
            this.keiryoListDataGridView.AllowUserToAddRows = false;
            this.keiryoListDataGridView.AllowUserToDeleteRows = false;
            this.keiryoListDataGridView.AllowUserToResizeRows = false;
            this.keiryoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keiryoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keiryoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nendoCol,
            this.shishoNmCol,
            this.suikenNoCol,
            this.yoteiDtCol,
            this.jokasoNoCol,
            this.settisyaCol,
            this.shomeishoPrintCntCol,
            this.gyoshaCdCol,
            this.gyoshaNmCol});
            this.keiryoListDataGridView.Location = new System.Drawing.Point(3, 23);
            this.keiryoListDataGridView.Name = "keiryoListDataGridView";
            this.keiryoListDataGridView.ReadOnly = true;
            this.keiryoListDataGridView.RowHeadersVisible = false;
            this.keiryoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.keiryoListDataGridView.Size = new System.Drawing.Size(1084, 301);
            this.keiryoListDataGridView.TabIndex = 2;
            // 
            // nendoCol
            // 
            this.nendoCol.DataPropertyName = "KeiryoShomeiIraiNendo";
            this.nendoCol.HeaderText = "年度";
            this.nendoCol.MinimumWidth = 80;
            this.nendoCol.Name = "nendoCol";
            this.nendoCol.ReadOnly = true;
            this.nendoCol.Width = 80;
            // 
            // shishoNmCol
            // 
            this.shishoNmCol.DataPropertyName = "ShishoNm";
            this.shishoNmCol.HeaderText = "支所";
            this.shishoNmCol.MinimumWidth = 70;
            this.shishoNmCol.Name = "shishoNmCol";
            this.shishoNmCol.ReadOnly = true;
            this.shishoNmCol.Width = 70;
            // 
            // suikenNoCol
            // 
            this.suikenNoCol.DataPropertyName = "KeiryoShomeiIraiRenban";
            this.suikenNoCol.HeaderText = "受付番号";
            this.suikenNoCol.MinimumWidth = 90;
            this.suikenNoCol.Name = "suikenNoCol";
            this.suikenNoCol.ReadOnly = true;
            this.suikenNoCol.Width = 90;
            // 
            // yoteiDtCol
            // 
            this.yoteiDtCol.DataPropertyName = "KeiryoShomeiIraiUketsukeDt";
            this.yoteiDtCol.HeaderText = "受付日";
            this.yoteiDtCol.MinimumWidth = 120;
            this.yoteiDtCol.Name = "yoteiDtCol";
            this.yoteiDtCol.ReadOnly = true;
            this.yoteiDtCol.Width = 120;
            // 
            // jokasoNoCol
            // 
            this.jokasoNoCol.DataPropertyName = "jokasoNoCol";
            this.jokasoNoCol.HeaderText = "浄化槽番号";
            this.jokasoNoCol.MinimumWidth = 120;
            this.jokasoNoCol.Name = "jokasoNoCol";
            this.jokasoNoCol.ReadOnly = true;
            this.jokasoNoCol.Width = 120;
            // 
            // settisyaCol
            // 
            this.settisyaCol.DataPropertyName = "JokasoSetchishaNm";
            this.settisyaCol.HeaderText = "設置者名";
            this.settisyaCol.MinimumWidth = 200;
            this.settisyaCol.Name = "settisyaCol";
            this.settisyaCol.ReadOnly = true;
            this.settisyaCol.Width = 200;
            // 
            // shomeishoPrintCntCol
            // 
            this.shomeishoPrintCntCol.DataPropertyName = "KeiryoShomeiShomeishoInsatsuCnt";
            this.shomeishoPrintCntCol.HeaderText = "証明書印刷回数(隠し)";
            this.shomeishoPrintCntCol.Name = "shomeishoPrintCntCol";
            this.shomeishoPrintCntCol.ReadOnly = true;
            this.shomeishoPrintCntCol.Visible = false;
            // 
            // gyoshaCdCol
            // 
            this.gyoshaCdCol.DataPropertyName = "KeiryoShomeiSeikyuGyoshaCd";
            this.gyoshaCdCol.HeaderText = "業者コード";
            this.gyoshaCdCol.Name = "gyoshaCdCol";
            this.gyoshaCdCol.ReadOnly = true;
            // 
            // gyoshaNmCol
            // 
            this.gyoshaNmCol.DataPropertyName = "GyoshaNm";
            this.gyoshaNmCol.HeaderText = "業者名";
            this.gyoshaNmCol.Name = "gyoshaNmCol";
            this.gyoshaNmCol.ReadOnly = true;
            this.gyoshaNmCol.Width = 200;
            // 
            // keiryoShomeiListCountLabel
            // 
            this.keiryoShomeiListCountLabel.AutoSize = true;
            this.keiryoShomeiListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.keiryoShomeiListCountLabel.Name = "keiryoShomeiListCountLabel";
            this.keiryoShomeiListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.keiryoShomeiListCountLabel.TabIndex = 1;
            this.keiryoShomeiListCountLabel.Text = "0件";
            // 
            // kensakuKekkaLabel
            // 
            this.kensakuKekkaLabel.AutoSize = true;
            this.kensakuKekkaLabel.Location = new System.Drawing.Point(905, 0);
            this.kensakuKekkaLabel.Name = "kensakuKekkaLabel";
            this.kensakuKekkaLabel.Size = new System.Drawing.Size(74, 20);
            this.kensakuKekkaLabel.TabIndex = 0;
            this.kensakuKekkaLabel.Text = "検索結果：";
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(883, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 9;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(990, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 10;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // senyoRadioButton
            // 
            this.senyoRadioButton.AutoSize = true;
            this.senyoRadioButton.Location = new System.Drawing.Point(84, 3);
            this.senyoRadioButton.Name = "senyoRadioButton";
            this.senyoRadioButton.Size = new System.Drawing.Size(92, 24);
            this.senyoRadioButton.TabIndex = 1;
            this.senyoRadioButton.TabStop = true;
            this.senyoRadioButton.Text = "専用紙印刷";
            this.senyoRadioButton.UseVisualStyleBackColor = true;
            this.senyoRadioButton.CheckedChanged += new System.EventHandler(this.senyoshiRadioButton_CheckedChanged);
            // 
            // senyoshiRadioButton
            // 
            this.senyoshiRadioButton.AutoSize = true;
            this.senyoshiRadioButton.Location = new System.Drawing.Point(75, 4);
            this.senyoshiRadioButton.Name = "senyoshiRadioButton";
            this.senyoshiRadioButton.Size = new System.Drawing.Size(53, 24);
            this.senyoshiRadioButton.TabIndex = 1;
            this.senyoshiRadioButton.TabStop = true;
            this.senyoshiRadioButton.Text = "一括";
            this.senyoshiRadioButton.UseVisualStyleBackColor = true;
            // 
            // tsujoRadioButton
            // 
            this.tsujoRadioButton.AutoSize = true;
            this.tsujoRadioButton.Checked = true;
            this.tsujoRadioButton.Location = new System.Drawing.Point(3, 4);
            this.tsujoRadioButton.Name = "tsujoRadioButton";
            this.tsujoRadioButton.Size = new System.Drawing.Size(66, 24);
            this.tsujoRadioButton.TabIndex = 0;
            this.tsujoRadioButton.TabStop = true;
            this.tsujoRadioButton.Text = "選択分";
            this.tsujoRadioButton.UseVisualStyleBackColor = true;
            // 
            // busuLabel
            // 
            this.busuLabel.AutoSize = true;
            this.busuLabel.Location = new System.Drawing.Point(674, 552);
            this.busuLabel.Name = "busuLabel";
            this.busuLabel.Size = new System.Drawing.Size(35, 20);
            this.busuLabel.TabIndex = 6;
            this.busuLabel.Text = "部数";
            // 
            // edabanCheckBox
            // 
            this.edabanCheckBox.AutoSize = true;
            this.edabanCheckBox.Location = new System.Drawing.Point(178, 3);
            this.edabanCheckBox.Name = "edabanCheckBox";
            this.edabanCheckBox.Size = new System.Drawing.Size(54, 24);
            this.edabanCheckBox.TabIndex = 2;
            this.edabanCheckBox.Text = "枝番";
            this.edabanCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(985, 153);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 19;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(878, 154);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 18;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
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
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 20;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // settishaLabel
            // 
            this.settishaLabel.AutoSize = true;
            this.settishaLabel.Location = new System.Drawing.Point(32, 104);
            this.settishaLabel.Name = "settishaLabel";
            this.settishaLabel.Size = new System.Drawing.Size(48, 20);
            this.settishaLabel.TabIndex = 9;
            this.settishaLabel.Text = "設置者";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "～";
            // 
            // uketsukeDtUseCheckBox
            // 
            this.uketsukeDtUseCheckBox.AutoSize = true;
            this.uketsukeDtUseCheckBox.Location = new System.Drawing.Point(18, 138);
            this.uketsukeDtUseCheckBox.Name = "uketsukeDtUseCheckBox";
            this.uketsukeDtUseCheckBox.Size = new System.Drawing.Size(67, 24);
            this.uketsukeDtUseCheckBox.TabIndex = 11;
            this.uketsukeDtUseCheckBox.Text = "受付日";
            this.uketsukeDtUseCheckBox.UseVisualStyleBackColor = true;
            this.uketsukeDtUseCheckBox.CheckedChanged += new System.EventHandler(this.uketsukeDtUseCheckBox_CheckedChanged);
            // 
            // suikenNoLabel
            // 
            this.suikenNoLabel.AutoSize = true;
            this.suikenNoLabel.Location = new System.Drawing.Point(32, 71);
            this.suikenNoLabel.Name = "suikenNoLabel";
            this.suikenNoLabel.Size = new System.Drawing.Size(61, 20);
            this.suikenNoLabel.TabIndex = 5;
            this.suikenNoLabel.Text = "受付番号";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(179, 71);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(22, 20);
            this.toLabel.TabIndex = 7;
            this.toLabel.Text = "～";
            // 
            // shishoLabel
            // 
            this.shishoLabel.AutoSize = true;
            this.shishoLabel.Location = new System.Drawing.Point(32, 37);
            this.shishoLabel.Name = "shishoLabel";
            this.shishoLabel.Size = new System.Drawing.Size(35, 20);
            this.shishoLabel.TabIndex = 1;
            this.shishoLabel.Text = "支所";
            // 
            // shishoComboBox
            // 
            this.shishoComboBox.DisplayMember = "ShishoNm";
            this.shishoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shishoComboBox.FormattingEnabled = true;
            this.shishoComboBox.Location = new System.Drawing.Point(109, 34);
            this.shishoComboBox.Name = "shishoComboBox";
            this.shishoComboBox.Size = new System.Drawing.Size(191, 28);
            this.shishoComboBox.TabIndex = 2;
            this.shishoComboBox.ValueMember = "ShishoCd";
            // 
            // nendoLabel
            // 
            this.nendoLabel.AutoSize = true;
            this.nendoLabel.Location = new System.Drawing.Point(318, 37);
            this.nendoLabel.Name = "nendoLabel";
            this.nendoLabel.Size = new System.Drawing.Size(35, 20);
            this.nendoLabel.TabIndex = 3;
            this.nendoLabel.Text = "年度";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.panel2);
            this.searchPanel.Controls.Add(this.panel1);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.chouHyouKubunLabel);
            this.searchPanel.Controls.Add(this.uketsukeDtToTextBox);
            this.searchPanel.Controls.Add(this.uketsukeDtFromTextBox);
            this.searchPanel.Controls.Add(this.settishaTextBox);
            this.searchPanel.Controls.Add(this.suikenNoToTextBox);
            this.searchPanel.Controls.Add(this.suikenNoFromTextBox);
            this.searchPanel.Controls.Add(this.nendoTextBox);
            this.searchPanel.Controls.Add(this.nendoLabel);
            this.searchPanel.Controls.Add(this.shishoComboBox);
            this.searchPanel.Controls.Add(this.shishoLabel);
            this.searchPanel.Controls.Add(this.toLabel);
            this.searchPanel.Controls.Add(this.suikenNoLabel);
            this.searchPanel.Controls.Add(this.uketsukeDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.settishaLabel);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 196);
            this.searchPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.keiryoShomeiRadioButton);
            this.panel2.Controls.Add(this.bunssekiHokokuRadioButton);
            this.panel2.Location = new System.Drawing.Point(108, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 26);
            this.panel2.TabIndex = 15;
            // 
            // keiryoShomeiRadioButton
            // 
            this.keiryoShomeiRadioButton.AutoSize = true;
            this.keiryoShomeiRadioButton.Checked = true;
            this.keiryoShomeiRadioButton.Location = new System.Drawing.Point(3, 1);
            this.keiryoShomeiRadioButton.Name = "keiryoShomeiRadioButton";
            this.keiryoShomeiRadioButton.Size = new System.Drawing.Size(79, 24);
            this.keiryoShomeiRadioButton.TabIndex = 0;
            this.keiryoShomeiRadioButton.TabStop = true;
            this.keiryoShomeiRadioButton.Text = "計量証明";
            this.keiryoShomeiRadioButton.UseVisualStyleBackColor = true;
            // 
            // bunssekiHokokuRadioButton
            // 
            this.bunssekiHokokuRadioButton.AutoSize = true;
            this.bunssekiHokokuRadioButton.Location = new System.Drawing.Point(88, 1);
            this.bunssekiHokokuRadioButton.Name = "bunssekiHokokuRadioButton";
            this.bunssekiHokokuRadioButton.Size = new System.Drawing.Size(79, 24);
            this.bunssekiHokokuRadioButton.TabIndex = 1;
            this.bunssekiHokokuRadioButton.TabStop = true;
            this.bunssekiHokokuRadioButton.Text = "分析報告";
            this.bunssekiHokokuRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uketsukeOrderRadioButton);
            this.panel1.Controls.Add(this.gyoshaOrderRadioButton);
            this.panel1.Location = new System.Drawing.Point(358, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 28);
            this.panel1.TabIndex = 16;
            // 
            // uketsukeOrderRadioButton
            // 
            this.uketsukeOrderRadioButton.AutoSize = true;
            this.uketsukeOrderRadioButton.Checked = true;
            this.uketsukeOrderRadioButton.Location = new System.Drawing.Point(5, 1);
            this.uketsukeOrderRadioButton.Name = "uketsukeOrderRadioButton";
            this.uketsukeOrderRadioButton.Size = new System.Drawing.Size(92, 24);
            this.uketsukeOrderRadioButton.TabIndex = 0;
            this.uketsukeOrderRadioButton.TabStop = true;
            this.uketsukeOrderRadioButton.Text = "受付番号順";
            this.uketsukeOrderRadioButton.UseVisualStyleBackColor = true;
            // 
            // gyoshaOrderRadioButton
            // 
            this.gyoshaOrderRadioButton.AutoSize = true;
            this.gyoshaOrderRadioButton.Location = new System.Drawing.Point(105, 1);
            this.gyoshaOrderRadioButton.Name = "gyoshaOrderRadioButton";
            this.gyoshaOrderRadioButton.Size = new System.Drawing.Size(66, 24);
            this.gyoshaOrderRadioButton.TabIndex = 1;
            this.gyoshaOrderRadioButton.TabStop = true;
            this.gyoshaOrderRadioButton.Text = "業者順";
            this.gyoshaOrderRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "表示順";
            // 
            // chouHyouKubunLabel
            // 
            this.chouHyouKubunLabel.AutoSize = true;
            this.chouHyouKubunLabel.Location = new System.Drawing.Point(32, 171);
            this.chouHyouKubunLabel.Name = "chouHyouKubunLabel";
            this.chouHyouKubunLabel.Size = new System.Drawing.Size(61, 20);
            this.chouHyouKubunLabel.TabIndex = 15;
            this.chouHyouKubunLabel.Text = "帳票区分";
            // 
            // uketsukeDtToTextBox
            // 
            this.uketsukeDtToTextBox.CustomFormat = "yyyy年MM月dd日";
            this.uketsukeDtToTextBox.Enabled = false;
            this.uketsukeDtToTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uketsukeDtToTextBox.Location = new System.Drawing.Point(278, 134);
            this.uketsukeDtToTextBox.Name = "uketsukeDtToTextBox";
            this.uketsukeDtToTextBox.Size = new System.Drawing.Size(145, 27);
            this.uketsukeDtToTextBox.TabIndex = 14;
            // 
            // uketsukeDtFromTextBox
            // 
            this.uketsukeDtFromTextBox.CustomFormat = "yyyy年MM月dd日";
            this.uketsukeDtFromTextBox.Enabled = false;
            this.uketsukeDtFromTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uketsukeDtFromTextBox.Location = new System.Drawing.Point(108, 134);
            this.uketsukeDtFromTextBox.Name = "uketsukeDtFromTextBox";
            this.uketsukeDtFromTextBox.Size = new System.Drawing.Size(145, 27);
            this.uketsukeDtFromTextBox.TabIndex = 12;
            this.uketsukeDtFromTextBox.ValueChanged += new System.EventHandler(this.uketsukeDtFromTextBox_ValueChanged);
            // 
            // settishaTextBox
            // 
            this.settishaTextBox.AllowDropDown = false;
            this.settishaTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZG_STD_NAME;
            this.settishaTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settishaTextBox.CustomReadOnly = false;
            this.settishaTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.settishaTextBox.Location = new System.Drawing.Point(109, 101);
            this.settishaTextBox.MaxLength = 1;
            this.settishaTextBox.Name = "settishaTextBox";
            this.settishaTextBox.Size = new System.Drawing.Size(314, 27);
            this.settishaTextBox.TabIndex = 10;
            // 
            // suikenNoToTextBox
            // 
            this.suikenNoToTextBox.AllowDropDown = false;
            this.suikenNoToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_SHISHO_CD;
            this.suikenNoToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.suikenNoToTextBox.CustomReadOnly = false;
            this.suikenNoToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.suikenNoToTextBox.Location = new System.Drawing.Point(205, 68);
            this.suikenNoToTextBox.MaxLength = 1;
            this.suikenNoToTextBox.Name = "suikenNoToTextBox";
            this.suikenNoToTextBox.Size = new System.Drawing.Size(67, 27);
            this.suikenNoToTextBox.TabIndex = 8;
            this.suikenNoToTextBox.Leave += new System.EventHandler(this.suikenNoToTextBox_Leave);
            // 
            // suikenNoFromTextBox
            // 
            this.suikenNoFromTextBox.AllowDropDown = false;
            this.suikenNoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_SHISHO_CD;
            this.suikenNoFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.suikenNoFromTextBox.CustomReadOnly = false;
            this.suikenNoFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.suikenNoFromTextBox.Location = new System.Drawing.Point(108, 68);
            this.suikenNoFromTextBox.MaxLength = 1;
            this.suikenNoFromTextBox.Name = "suikenNoFromTextBox";
            this.suikenNoFromTextBox.Size = new System.Drawing.Size(68, 27);
            this.suikenNoFromTextBox.TabIndex = 6;
            this.suikenNoFromTextBox.Leave += new System.EventHandler(this.suikenNoFromTextBox_Leave);
            // 
            // nendoTextBox
            // 
            this.nendoTextBox.AllowDropDown = false;
            this.nendoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_NENDO;
            this.nendoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nendoTextBox.CustomReadOnly = false;
            this.nendoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nendoTextBox.Location = new System.Drawing.Point(359, 34);
            this.nendoTextBox.MaxLength = 4;
            this.nendoTextBox.Name = "nendoTextBox";
            this.nendoTextBox.Size = new System.Drawing.Size(54, 27);
            this.nendoTextBox.TabIndex = 4;
            // 
            // insatsuKubunLabel
            // 
            this.insatsuKubunLabel.AutoSize = true;
            this.insatsuKubunLabel.Location = new System.Drawing.Point(20, 534);
            this.insatsuKubunLabel.Name = "insatsuKubunLabel";
            this.insatsuKubunLabel.Size = new System.Drawing.Size(61, 20);
            this.insatsuKubunLabel.TabIndex = 2;
            this.insatsuKubunLabel.Text = "印刷区分";
            // 
            // insatsuHaniLabel
            // 
            this.insatsuHaniLabel.AutoSize = true;
            this.insatsuHaniLabel.Location = new System.Drawing.Point(20, 561);
            this.insatsuHaniLabel.Name = "insatsuHaniLabel";
            this.insatsuHaniLabel.Size = new System.Drawing.Size(61, 20);
            this.insatsuHaniLabel.TabIndex = 4;
            this.insatsuHaniLabel.Text = "印刷範囲";
            // 
            // tujoRadioButton
            // 
            this.tujoRadioButton.AutoSize = true;
            this.tujoRadioButton.Checked = true;
            this.tujoRadioButton.Location = new System.Drawing.Point(3, 3);
            this.tujoRadioButton.Name = "tujoRadioButton";
            this.tujoRadioButton.Size = new System.Drawing.Size(79, 24);
            this.tujoRadioButton.TabIndex = 0;
            this.tujoRadioButton.TabStop = true;
            this.tujoRadioButton.Text = "通常印刷";
            this.tujoRadioButton.UseVisualStyleBackColor = true;
            this.tujoRadioButton.CheckedChanged += new System.EventHandler(this.tujoRadioButton_CheckedChanged);
            // 
            // busuTextBox
            // 
            this.busuTextBox.AllowDropDown = false;
            this.busuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.busuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.busuTextBox.CustomReadOnly = false;
            this.busuTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.busuTextBox.Location = new System.Drawing.Point(713, 549);
            this.busuTextBox.MaxLength = 2;
            this.busuTextBox.Name = "busuTextBox";
            this.busuTextBox.Size = new System.Drawing.Size(38, 27);
            this.busuTextBox.TabIndex = 7;
            this.busuTextBox.Text = "1";
            this.busuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // insatsuKubunPanel
            // 
            this.insatsuKubunPanel.Controls.Add(this.tujoRadioButton);
            this.insatsuKubunPanel.Controls.Add(this.senyoRadioButton);
            this.insatsuKubunPanel.Controls.Add(this.edabanCheckBox);
            this.insatsuKubunPanel.Location = new System.Drawing.Point(87, 529);
            this.insatsuKubunPanel.Name = "insatsuKubunPanel";
            this.insatsuKubunPanel.Size = new System.Drawing.Size(234, 32);
            this.insatsuKubunPanel.TabIndex = 3;
            // 
            // insatsuHaniPanel
            // 
            this.insatsuHaniPanel.Controls.Add(this.tsujoRadioButton);
            this.insatsuHaniPanel.Controls.Add(this.senyoshiRadioButton);
            this.insatsuHaniPanel.Location = new System.Drawing.Point(87, 556);
            this.insatsuHaniPanel.Name = "insatsuHaniPanel";
            this.insatsuHaniPanel.Size = new System.Drawing.Size(139, 28);
            this.insatsuHaniPanel.TabIndex = 5;
            // 
            // KeiryoShomeiOutputListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.insatsuHaniPanel);
            this.Controls.Add(this.insatsuKubunPanel);
            this.Controls.Add(this.insatsuHaniLabel);
            this.Controls.Add(this.insatsuKubunLabel);
            this.Controls.Add(this.busuLabel);
            this.Controls.Add(this.busuTextBox);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KeiryoShomeiOutputListForm";
            this.Text = "計量証明出力";
            this.Load += new System.EventHandler(this.KeiryoShomeiOutputListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeiryoShomeiOutputListForm_KeyDown);
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keiryoListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.insatsuKubunPanel.ResumeLayout(false);
            this.insatsuKubunPanel.PerformLayout();
            this.insatsuHaniPanel.ResumeLayout(false);
            this.insatsuHaniPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Label keiryoShomeiListCountLabel;
        private System.Windows.Forms.Label kensakuKekkaLabel;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.RadioButton senyoRadioButton;
        private System.Windows.Forms.RadioButton senyoshiRadioButton;
        private System.Windows.Forms.RadioButton tsujoRadioButton;
        private Control.ZTextBox busuTextBox;
        private System.Windows.Forms.Label busuLabel;
        private System.Windows.Forms.CheckBox edabanCheckBox;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label settishaLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox uketsukeDtUseCheckBox;
        private System.Windows.Forms.Label suikenNoLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label shishoLabel;
        private System.Windows.Forms.ComboBox shishoComboBox;
        private System.Windows.Forms.Label nendoLabel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label insatsuKubunLabel;
        private System.Windows.Forms.Label insatsuHaniLabel;
        private System.Windows.Forms.RadioButton tujoRadioButton;
        private Control.ZTextBox nendoTextBox;
        private Control.ZTextBox suikenNoToTextBox;
        private Control.ZTextBox suikenNoFromTextBox;
        private Control.ZTextBox settishaTextBox;
        private Zynas.Control.ZDataGridView.ZDataGridView keiryoListDataGridView;
        private System.Windows.Forms.DateTimePicker uketsukeDtFromTextBox;
        private System.Windows.Forms.DateTimePicker uketsukeDtToTextBox;
        private System.Windows.Forms.Panel insatsuKubunPanel;
        private System.Windows.Forms.Panel insatsuHaniPanel;
        private System.Windows.Forms.RadioButton bunssekiHokokuRadioButton;
        private System.Windows.Forms.RadioButton keiryoShomeiRadioButton;
        private System.Windows.Forms.Label chouHyouKubunLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton uketsukeOrderRadioButton;
        private System.Windows.Forms.RadioButton gyoshaOrderRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nendoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn suikenNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoteiDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn settisyaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shomeishoPrintCntCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmCol;

    }
}