using FukjBizSystem.Control;
using Zynas.Control.ZDataGridView;
namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    partial class GaichuKensaListForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.iraiDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.printButton = new System.Windows.Forms.Button();
            this.srhListPanel = new System.Windows.Forms.Panel();
            this.srhListCountLabel = new System.Windows.Forms.Label();
            this.kensakuKekkaLabel = new System.Windows.Forms.Label();
            this.gaichuListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.nendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suikenNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoteiDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settisyaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daichokinCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tpCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.yubunCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.yubunKouCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.yubunDouCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mbasCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.znCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pbCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.shishoComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.suikenNoToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.suikenNoFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nendoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.uketsukeDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uketsukeDtToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uketsukeDtFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.srhListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaichuListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "依頼日";
            // 
            // iraiDtDateTimePicker
            // 
            this.iraiDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.iraiDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.iraiDtDateTimePicker.Location = new System.Drawing.Point(676, 547);
            this.iraiDtDateTimePicker.Name = "iraiDtDateTimePicker";
            this.iraiDtDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.iraiDtDateTimePicker.TabIndex = 4;
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(879, 544);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(101, 37);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "F1:印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // srhListPanel
            // 
            this.srhListPanel.Controls.Add(this.srhListCountLabel);
            this.srhListPanel.Controls.Add(this.kensakuKekkaLabel);
            this.srhListPanel.Controls.Add(this.gaichuListDataGridView);
            this.srhListPanel.Location = new System.Drawing.Point(1, 140);
            this.srhListPanel.Name = "srhListPanel";
            this.srhListPanel.Size = new System.Drawing.Size(1090, 386);
            this.srhListPanel.TabIndex = 2;
            this.srhListPanel.TabStop = true;
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
            // kensakuKekkaLabel
            // 
            this.kensakuKekkaLabel.AutoSize = true;
            this.kensakuKekkaLabel.Location = new System.Drawing.Point(905, 0);
            this.kensakuKekkaLabel.Name = "kensakuKekkaLabel";
            this.kensakuKekkaLabel.Size = new System.Drawing.Size(74, 20);
            this.kensakuKekkaLabel.TabIndex = 0;
            this.kensakuKekkaLabel.Text = "検索結果：";
            // 
            // gaichuListDataGridView
            // 
            this.gaichuListDataGridView.AllowUserToAddRows = false;
            this.gaichuListDataGridView.AllowUserToDeleteRows = false;
            this.gaichuListDataGridView.AllowUserToResizeRows = false;
            this.gaichuListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gaichuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gaichuListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nendoCol,
            this.shishoNmCol,
            this.suikenNoCol,
            this.yoteiDtCol,
            this.jokasoNoCol,
            this.settisyaCol,
            this.daichokinCol,
            this.codCol,
            this.tnCol,
            this.tpCol,
            this.yubunCol,
            this.yubunKouCol,
            this.yubunDouCol,
            this.mbasCol,
            this.znCol,
            this.pbCol,
            this.fCol});
            this.gaichuListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.gaichuListDataGridView.Name = "gaichuListDataGridView";
            this.gaichuListDataGridView.RowHeadersVisible = false;
            this.gaichuListDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gaichuListDataGridView.RowTemplate.Height = 21;
            this.gaichuListDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gaichuListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gaichuListDataGridView.Size = new System.Drawing.Size(1085, 359);
            this.gaichuListDataGridView.TabIndex = 2;
            // 
            // nendoCol
            // 
            this.nendoCol.DataPropertyName = "KeiryoShomeiIraiNendo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nendoCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.nendoCol.HeaderText = "年度";
            this.nendoCol.MinimumWidth = 50;
            this.nendoCol.Name = "nendoCol";
            this.nendoCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nendoCol.Width = 50;
            // 
            // shishoNmCol
            // 
            this.shishoNmCol.DataPropertyName = "ShishoNm";
            this.shishoNmCol.HeaderText = "支所";
            this.shishoNmCol.MinimumWidth = 55;
            this.shishoNmCol.Name = "shishoNmCol";
            this.shishoNmCol.ReadOnly = true;
            this.shishoNmCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shishoNmCol.Width = 55;
            // 
            // suikenNoCol
            // 
            this.suikenNoCol.DataPropertyName = "KeiryoShomeiIraiRenban";
            this.suikenNoCol.HeaderText = "水検No";
            this.suikenNoCol.MinimumWidth = 65;
            this.suikenNoCol.Name = "suikenNoCol";
            this.suikenNoCol.ReadOnly = true;
            this.suikenNoCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.suikenNoCol.Width = 65;
            // 
            // yoteiDtCol
            // 
            this.yoteiDtCol.DataPropertyName = "KeiryoShomeiIraiUketsukeDt";
            this.yoteiDtCol.HeaderText = "受付日";
            this.yoteiDtCol.MinimumWidth = 90;
            this.yoteiDtCol.Name = "yoteiDtCol";
            this.yoteiDtCol.ReadOnly = true;
            this.yoteiDtCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.yoteiDtCol.Width = 90;
            // 
            // jokasoNoCol
            // 
            this.jokasoNoCol.DataPropertyName = "jokasoNoCol";
            this.jokasoNoCol.HeaderText = "浄化槽番号";
            this.jokasoNoCol.MinimumWidth = 95;
            this.jokasoNoCol.Name = "jokasoNoCol";
            this.jokasoNoCol.ReadOnly = true;
            this.jokasoNoCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.jokasoNoCol.Width = 95;
            // 
            // settisyaCol
            // 
            this.settisyaCol.DataPropertyName = "JokasoSetchishaNm";
            this.settisyaCol.HeaderText = "設置者名";
            this.settisyaCol.MinimumWidth = 90;
            this.settisyaCol.Name = "settisyaCol";
            this.settisyaCol.ReadOnly = true;
            this.settisyaCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.settisyaCol.Width = 90;
            // 
            // daichokinCol
            // 
            this.daichokinCol.DataPropertyName = "daichokinCol";
            this.daichokinCol.FalseValue = "0";
            this.daichokinCol.HeaderText = "大腸菌";
            this.daichokinCol.MinimumWidth = 55;
            this.daichokinCol.Name = "daichokinCol";
            this.daichokinCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.daichokinCol.TrueValue = "1";
            this.daichokinCol.Width = 55;
            // 
            // codCol
            // 
            this.codCol.DataPropertyName = "codCol";
            this.codCol.FalseValue = "0";
            this.codCol.HeaderText = "COD";
            this.codCol.MinimumWidth = 55;
            this.codCol.Name = "codCol";
            this.codCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.codCol.TrueValue = "1";
            this.codCol.Width = 55;
            // 
            // tnCol
            // 
            this.tnCol.DataPropertyName = "tnCol";
            this.tnCol.FalseValue = "0";
            this.tnCol.HeaderText = "T-N";
            this.tnCol.MinimumWidth = 55;
            this.tnCol.Name = "tnCol";
            this.tnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tnCol.TrueValue = "1";
            this.tnCol.Width = 55;
            // 
            // tpCol
            // 
            this.tpCol.DataPropertyName = "tpCol";
            this.tpCol.FalseValue = "0";
            this.tpCol.HeaderText = "T-P";
            this.tpCol.MinimumWidth = 55;
            this.tpCol.Name = "tpCol";
            this.tpCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tpCol.TrueValue = "1";
            this.tpCol.Width = 55;
            // 
            // yubunCol
            // 
            this.yubunCol.DataPropertyName = "yubunCol";
            this.yubunCol.FalseValue = "0";
            this.yubunCol.HeaderText = "油分";
            this.yubunCol.MinimumWidth = 55;
            this.yubunCol.Name = "yubunCol";
            this.yubunCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.yubunCol.TrueValue = "1";
            this.yubunCol.Width = 55;
            // 
            // yubunKouCol
            // 
            this.yubunKouCol.DataPropertyName = "yubunKouCol";
            this.yubunKouCol.FalseValue = "0";
            this.yubunKouCol.HeaderText = "油分(鉱)";
            this.yubunKouCol.MinimumWidth = 67;
            this.yubunKouCol.Name = "yubunKouCol";
            this.yubunKouCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.yubunKouCol.TrueValue = "1";
            this.yubunKouCol.Width = 67;
            // 
            // yubunDouCol
            // 
            this.yubunDouCol.DataPropertyName = "yubunDouCol";
            this.yubunDouCol.FalseValue = "0";
            this.yubunDouCol.HeaderText = "油分(動)";
            this.yubunDouCol.MinimumWidth = 67;
            this.yubunDouCol.Name = "yubunDouCol";
            this.yubunDouCol.TrueValue = "1";
            this.yubunDouCol.Width = 67;
            // 
            // mbasCol
            // 
            this.mbasCol.DataPropertyName = "mbasCol";
            this.mbasCol.FalseValue = "0";
            this.mbasCol.HeaderText = "MBAS";
            this.mbasCol.MinimumWidth = 55;
            this.mbasCol.Name = "mbasCol";
            this.mbasCol.TrueValue = "1";
            this.mbasCol.Width = 55;
            // 
            // znCol
            // 
            this.znCol.DataPropertyName = "znCol";
            this.znCol.FalseValue = "0";
            this.znCol.HeaderText = "Zn";
            this.znCol.MinimumWidth = 55;
            this.znCol.Name = "znCol";
            this.znCol.TrueValue = "1";
            this.znCol.Width = 55;
            // 
            // pbCol
            // 
            this.pbCol.DataPropertyName = "pbCol";
            this.pbCol.FalseValue = "0";
            this.pbCol.HeaderText = "Pb";
            this.pbCol.MinimumWidth = 55;
            this.pbCol.Name = "pbCol";
            this.pbCol.TrueValue = "1";
            this.pbCol.Width = 55;
            // 
            // fCol
            // 
            this.fCol.DataPropertyName = "fCol";
            this.fCol.FalseValue = "0";
            this.fCol.HeaderText = "F";
            this.fCol.MinimumWidth = 55;
            this.fCol.Name = "fCol";
            this.fCol.TrueValue = "1";
            this.fCol.Width = 55;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.shishoComboBox);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.suikenNoToTextBox);
            this.searchPanel.Controls.Add(this.suikenNoFromTextBox);
            this.searchPanel.Controls.Add(this.label17);
            this.searchPanel.Controls.Add(this.label18);
            this.searchPanel.Controls.Add(this.nendoTextBox);
            this.searchPanel.Controls.Add(this.uketsukeDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.uketsukeDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.uketsukeDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 142);
            this.searchPanel.TabIndex = 0;
            this.searchPanel.TabStop = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(318, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "年度";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "支所";
            // 
            // suikenNoToTextBox
            // 
            this.suikenNoToTextBox.AllowDropDown = false;
            this.suikenNoToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.suikenNoToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.suikenNoToTextBox.CustomReadOnly = false;
            this.suikenNoToTextBox.Location = new System.Drawing.Point(205, 68);
            this.suikenNoToTextBox.MaxLength = 6;
            this.suikenNoToTextBox.Name = "suikenNoToTextBox";
            this.suikenNoToTextBox.Size = new System.Drawing.Size(59, 27);
            this.suikenNoToTextBox.TabIndex = 8;
            this.suikenNoToTextBox.Leave += new System.EventHandler(this.suikenNoToTextBox_Leave);
            // 
            // suikenNoFromTextBox
            // 
            this.suikenNoFromTextBox.AllowDropDown = false;
            this.suikenNoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.suikenNoFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.suikenNoFromTextBox.CustomReadOnly = false;
            this.suikenNoFromTextBox.Location = new System.Drawing.Point(108, 68);
            this.suikenNoFromTextBox.MaxLength = 6;
            this.suikenNoFromTextBox.Name = "suikenNoFromTextBox";
            this.suikenNoFromTextBox.Size = new System.Drawing.Size(59, 27);
            this.suikenNoFromTextBox.TabIndex = 6;
            this.suikenNoFromTextBox.Leave += new System.EventHandler(this.suikenNoFromTextBox_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(173, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 20);
            this.label17.TabIndex = 7;
            this.label17.Text = "～";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 20);
            this.label18.TabIndex = 5;
            this.label18.Text = "水検No";
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
            this.nendoTextBox.Size = new System.Drawing.Size(44, 27);
            this.nendoTextBox.TabIndex = 4;
            this.nendoTextBox.Text = "2014";
            // 
            // uketsukeDtUseCheckBox
            // 
            this.uketsukeDtUseCheckBox.AutoSize = true;
            this.uketsukeDtUseCheckBox.Location = new System.Drawing.Point(17, 103);
            this.uketsukeDtUseCheckBox.Name = "uketsukeDtUseCheckBox";
            this.uketsukeDtUseCheckBox.Size = new System.Drawing.Size(67, 24);
            this.uketsukeDtUseCheckBox.TabIndex = 9;
            this.uketsukeDtUseCheckBox.Text = "受付日";
            this.uketsukeDtUseCheckBox.UseVisualStyleBackColor = true;
            this.uketsukeDtUseCheckBox.CheckedChanged += new System.EventHandler(this.uketsukeDtUseCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "～";
            // 
            // uketsukeDtToDateTimePicker
            // 
            this.uketsukeDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.uketsukeDtToDateTimePicker.Enabled = false;
            this.uketsukeDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uketsukeDtToDateTimePicker.Location = new System.Drawing.Point(287, 99);
            this.uketsukeDtToDateTimePicker.Name = "uketsukeDtToDateTimePicker";
            this.uketsukeDtToDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.uketsukeDtToDateTimePicker.TabIndex = 12;
            // 
            // uketsukeDtFromDateTimePicker
            // 
            this.uketsukeDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.uketsukeDtFromDateTimePicker.Enabled = false;
            this.uketsukeDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uketsukeDtFromDateTimePicker.Location = new System.Drawing.Point(108, 99);
            this.uketsukeDtFromDateTimePicker.Name = "uketsukeDtFromDateTimePicker";
            this.uketsukeDtFromDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.uketsukeDtFromDateTimePicker.TabIndex = 10;
            this.uketsukeDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.uketsukeDtFromDateTimePicker_ValueChanged);
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 15;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
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
            this.clearButton.Location = new System.Drawing.Point(869, 97);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(976, 96);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 14;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(990, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // GaichuKensaListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iraiDtDateTimePicker);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.srhListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GaichuKensaListForm";
            this.Text = "外注検査一覧";
            this.Load += new System.EventHandler(this.GaichuKensaListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GaichuKensaListForm_KeyDown);
            this.srhListPanel.ResumeLayout(false);
            this.srhListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaichuListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZDataGridView gaichuListDataGridView;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Panel srhListPanel;
        private System.Windows.Forms.Label srhListCountLabel;
        private System.Windows.Forms.Label kensakuKekkaLabel;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.DateTimePicker uketsukeDtFromDateTimePicker;
        private System.Windows.Forms.DateTimePicker uketsukeDtToDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox uketsukeDtUseCheckBox;
        private ZTextBox nendoTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private ZTextBox suikenNoFromTextBox;
        private ZTextBox suikenNoToTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox shishoComboBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.DateTimePicker iraiDtDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nendoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn suikenNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoteiDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn settisyaCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn daichokinCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn codCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tnCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tpCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn yubunCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn yubunKouCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn yubunDouCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mbasCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn znCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pbCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fCol;

    }
}