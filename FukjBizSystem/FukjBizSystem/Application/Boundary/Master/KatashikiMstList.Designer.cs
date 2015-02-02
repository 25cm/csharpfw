using Zynas.Control.ZDataGridView;
namespace FukjBizSystem.Application.Boundary.Master
{
    partial class KatashikiMstListForm
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
            this.tojiruButton = new System.Windows.Forms.Button();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.katashikiListPanel = new System.Windows.Forms.Panel();
            this.katashikiListCountLabel = new System.Windows.Forms.Label();
            this.katashikiListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.KatashikiMakerCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GyoshaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KatashikiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KatashikiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZenjorenTourokuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZenjorenTourokuBiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokuChoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeinohyokakataKbnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KonpakutokataKbnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BODKodoshorikataKbnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ChissojokyokataKbnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RinjokyokataKbnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KatashikiShorihoushikiKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KatashikiShorihoushikiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenkenKaisuTsukiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenkenKaisuShuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiMakerCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zenjorenTourokuNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zenjorenTourokuBiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokuChoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seinohyokakataKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.konpakutokataKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiShorihoushikiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiShorihoushikiKbnColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.katashikiMstDataSet = new FukjBizSystem.Application.DataSet.KatashikiMstDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.katashikiCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.katashikiCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.katashikiMakerCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.katashikiMakerCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.gyoshaNmTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.katashikiNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.katashikiListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
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
            // katashikiListPanel
            // 
            this.katashikiListPanel.Controls.Add(this.katashikiListCountLabel);
            this.katashikiListPanel.Controls.Add(this.katashikiListDataGridView);
            this.katashikiListPanel.Controls.Add(this.label4);
            this.katashikiListPanel.Location = new System.Drawing.Point(0, 182);
            this.katashikiListPanel.Name = "katashikiListPanel";
            this.katashikiListPanel.Size = new System.Drawing.Size(1103, 369);
            this.katashikiListPanel.TabIndex = 12;
            // 
            // katashikiListCountLabel
            // 
            this.katashikiListCountLabel.AutoSize = true;
            this.katashikiListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.katashikiListCountLabel.Name = "katashikiListCountLabel";
            this.katashikiListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.katashikiListCountLabel.TabIndex = 1;
            this.katashikiListCountLabel.Text = "0件";
            // 
            // katashikiListDataGridView
            // 
            this.katashikiListDataGridView.AllowUserToAddRows = false;
            this.katashikiListDataGridView.AllowUserToDeleteRows = false;
            this.katashikiListDataGridView.AllowUserToResizeRows = false;
            this.katashikiListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.katashikiListDataGridView.AutoGenerateColumns = false;
            this.katashikiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.katashikiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KatashikiMakerCdCol,
            this.GyoshaNmCol,
            this.KatashikiCdCol,
            this.KatashikiNmCol,
            this.ZenjorenTourokuNoCol,
            this.ZenjorenTourokuBiCol,
            this.TokuChoCol,
            this.SeinohyokakataKbnCol,
            this.KonpakutokataKbnCol,
            this.BODKodoshorikataKbnCol,
            this.ChissojokyokataKbnCol,
            this.RinjokyokataKbnCol,
            this.KatashikiShorihoushikiKbnCol,
            this.KatashikiShorihoushikiCdCol,
            this.ShoriHoshikiNmCol,
            this.TenkenKaisuTsukiCol,
            this.TenkenKaisuShuCol,
            this.katashikiMakerCdDataGridViewTextBoxColumn,
            this.katashikiCdDataGridViewTextBoxColumn,
            this.katashikiNmDataGridViewTextBoxColumn,
            this.zenjorenTourokuNoDataGridViewTextBoxColumn,
            this.zenjorenTourokuBiDataGridViewTextBoxColumn,
            this.tokuChoDataGridViewTextBoxColumn,
            this.seinohyokakataKbnDataGridViewTextBoxColumn,
            this.konpakutokataKbnDataGridViewTextBoxColumn,
            this.katashikiShorihoushikiCdDataGridViewTextBoxColumn,
            this.katashikiShorihoushikiKbnColDataGridViewTextBoxColumn,
            this.gyoshaNmDataGridViewTextBoxColumn,
            this.shoriHoshikiNmDataGridViewTextBoxColumn});
            this.katashikiListDataGridView.DataMember = "KatashikiMstKensaku";
            this.katashikiListDataGridView.DataSource = this.katashikiMstDataSetBindingSource;
            this.katashikiListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.katashikiListDataGridView.MultiSelect = false;
            this.katashikiListDataGridView.Name = "katashikiListDataGridView";
            this.katashikiListDataGridView.RowHeadersVisible = false;
            this.katashikiListDataGridView.RowTemplate.Height = 21;
            this.katashikiListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.katashikiListDataGridView.Size = new System.Drawing.Size(1100, 343);
            this.katashikiListDataGridView.TabIndex = 2;
            this.katashikiListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.katashikiListDataGridView_CellDoubleClick);
            this.katashikiListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.katashikiListDataGridView_DataError);
            // 
            // KatashikiMakerCdCol
            // 
            this.KatashikiMakerCdCol.DataPropertyName = "KatashikiMakerCd";
            this.KatashikiMakerCdCol.HeaderText = "メーカー業者コード";
            this.KatashikiMakerCdCol.MinimumWidth = 80;
            this.KatashikiMakerCdCol.Name = "KatashikiMakerCdCol";
            this.KatashikiMakerCdCol.ReadOnly = true;
            // 
            // GyoshaNmCol
            // 
            this.GyoshaNmCol.DataPropertyName = "GyoshaNm";
            this.GyoshaNmCol.HeaderText = "メーカー業者名称";
            this.GyoshaNmCol.MinimumWidth = 100;
            this.GyoshaNmCol.Name = "GyoshaNmCol";
            this.GyoshaNmCol.ReadOnly = true;
            this.GyoshaNmCol.Width = 140;
            // 
            // KatashikiCdCol
            // 
            this.KatashikiCdCol.DataPropertyName = "KatashikiCd";
            this.KatashikiCdCol.HeaderText = "型式コード";
            this.KatashikiCdCol.MinimumWidth = 80;
            this.KatashikiCdCol.Name = "KatashikiCdCol";
            this.KatashikiCdCol.ReadOnly = true;
            // 
            // KatashikiNmCol
            // 
            this.KatashikiNmCol.DataPropertyName = "KatashikiNm";
            this.KatashikiNmCol.HeaderText = "型式名称";
            this.KatashikiNmCol.MinimumWidth = 80;
            this.KatashikiNmCol.Name = "KatashikiNmCol";
            this.KatashikiNmCol.ReadOnly = true;
            // 
            // ZenjorenTourokuNoCol
            // 
            this.ZenjorenTourokuNoCol.DataPropertyName = "ZenjorenTourokuNo";
            this.ZenjorenTourokuNoCol.HeaderText = "全浄連登録番号";
            this.ZenjorenTourokuNoCol.MinimumWidth = 80;
            this.ZenjorenTourokuNoCol.Name = "ZenjorenTourokuNoCol";
            this.ZenjorenTourokuNoCol.ReadOnly = true;
            // 
            // ZenjorenTourokuBiCol
            // 
            this.ZenjorenTourokuBiCol.DataPropertyName = "ZenjorenTourokuBi";
            this.ZenjorenTourokuBiCol.HeaderText = "全浄連登録日";
            this.ZenjorenTourokuBiCol.MinimumWidth = 80;
            this.ZenjorenTourokuBiCol.Name = "ZenjorenTourokuBiCol";
            this.ZenjorenTourokuBiCol.ReadOnly = true;
            // 
            // TokuChoCol
            // 
            this.TokuChoCol.DataPropertyName = "TokuCho";
            this.TokuChoCol.HeaderText = "特徴";
            this.TokuChoCol.MinimumWidth = 80;
            this.TokuChoCol.Name = "TokuChoCol";
            this.TokuChoCol.ReadOnly = true;
            // 
            // SeinohyokakataKbnCol
            // 
            this.SeinohyokakataKbnCol.DataPropertyName = "SeinohyokakataKbn";
            this.SeinohyokakataKbnCol.FalseValue = "0";
            this.SeinohyokakataKbnCol.HeaderText = "性能評価型区分";
            this.SeinohyokakataKbnCol.MinimumWidth = 80;
            this.SeinohyokakataKbnCol.Name = "SeinohyokakataKbnCol";
            this.SeinohyokakataKbnCol.ReadOnly = true;
            this.SeinohyokakataKbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeinohyokakataKbnCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SeinohyokakataKbnCol.TrueValue = "1";
            // 
            // KonpakutokataKbnCol
            // 
            this.KonpakutokataKbnCol.DataPropertyName = "KonpakutokataKbn";
            this.KonpakutokataKbnCol.FalseValue = "0";
            this.KonpakutokataKbnCol.HeaderText = "コンパクト型区分";
            this.KonpakutokataKbnCol.MinimumWidth = 80;
            this.KonpakutokataKbnCol.Name = "KonpakutokataKbnCol";
            this.KonpakutokataKbnCol.ReadOnly = true;
            this.KonpakutokataKbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KonpakutokataKbnCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.KonpakutokataKbnCol.TrueValue = "1";
            // 
            // BODKodoshorikataKbnCol
            // 
            this.BODKodoshorikataKbnCol.DataPropertyName = "BODKodoshorikataKbn";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "0";
            this.BODKodoshorikataKbnCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.BODKodoshorikataKbnCol.FalseValue = "0";
            this.BODKodoshorikataKbnCol.HeaderText = "ＢＯＤ高度処理型区分";
            this.BODKodoshorikataKbnCol.MinimumWidth = 100;
            this.BODKodoshorikataKbnCol.Name = "BODKodoshorikataKbnCol";
            this.BODKodoshorikataKbnCol.ReadOnly = true;
            this.BODKodoshorikataKbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BODKodoshorikataKbnCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BODKodoshorikataKbnCol.TrueValue = "1";
            // 
            // ChissojokyokataKbnCol
            // 
            this.ChissojokyokataKbnCol.DataPropertyName = "ChissojokyokataKbn";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "0";
            this.ChissojokyokataKbnCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.ChissojokyokataKbnCol.FalseValue = "0";
            this.ChissojokyokataKbnCol.HeaderText = "窒素除去型区分";
            this.ChissojokyokataKbnCol.MinimumWidth = 100;
            this.ChissojokyokataKbnCol.Name = "ChissojokyokataKbnCol";
            this.ChissojokyokataKbnCol.ReadOnly = true;
            this.ChissojokyokataKbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChissojokyokataKbnCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChissojokyokataKbnCol.TrueValue = "1";
            // 
            // RinjokyokataKbnCol
            // 
            this.RinjokyokataKbnCol.DataPropertyName = "RinjokyokataKbn";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "0";
            this.RinjokyokataKbnCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.RinjokyokataKbnCol.FalseValue = "0";
            this.RinjokyokataKbnCol.HeaderText = "リン除去型区分";
            this.RinjokyokataKbnCol.Name = "RinjokyokataKbnCol";
            this.RinjokyokataKbnCol.ReadOnly = true;
            this.RinjokyokataKbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RinjokyokataKbnCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RinjokyokataKbnCol.TrueValue = "1";
            // 
            // KatashikiShorihoushikiKbnCol
            // 
            this.KatashikiShorihoushikiKbnCol.DataPropertyName = "KatashikiShorihoushikiKbnCol";
            this.KatashikiShorihoushikiKbnCol.HeaderText = "処理方式区分";
            this.KatashikiShorihoushikiKbnCol.MinimumWidth = 80;
            this.KatashikiShorihoushikiKbnCol.Name = "KatashikiShorihoushikiKbnCol";
            this.KatashikiShorihoushikiKbnCol.ReadOnly = true;
            this.KatashikiShorihoushikiKbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // KatashikiShorihoushikiCdCol
            // 
            this.KatashikiShorihoushikiCdCol.DataPropertyName = "KatashikiShorihoushikiCd";
            this.KatashikiShorihoushikiCdCol.HeaderText = "処理方式コード";
            this.KatashikiShorihoushikiCdCol.MinimumWidth = 80;
            this.KatashikiShorihoushikiCdCol.Name = "KatashikiShorihoushikiCdCol";
            this.KatashikiShorihoushikiCdCol.ReadOnly = true;
            // 
            // ShoriHoshikiNmCol
            // 
            this.ShoriHoshikiNmCol.DataPropertyName = "ShoriHoshikiNm";
            this.ShoriHoshikiNmCol.HeaderText = "処理方式名";
            this.ShoriHoshikiNmCol.MinimumWidth = 80;
            this.ShoriHoshikiNmCol.Name = "ShoriHoshikiNmCol";
            this.ShoriHoshikiNmCol.ReadOnly = true;
            this.ShoriHoshikiNmCol.Width = 120;
            // 
            // TenkenKaisuTsukiCol
            // 
            this.TenkenKaisuTsukiCol.DataPropertyName = "TenkenKaisuKbn";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.TenkenKaisuTsukiCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.TenkenKaisuTsukiCol.HeaderText = "点検回数区分";
            this.TenkenKaisuTsukiCol.MinimumWidth = 80;
            this.TenkenKaisuTsukiCol.Name = "TenkenKaisuTsukiCol";
            this.TenkenKaisuTsukiCol.ReadOnly = true;
            this.TenkenKaisuTsukiCol.Width = 80;
            // 
            // TenkenKaisuShuCol
            // 
            this.TenkenKaisuShuCol.DataPropertyName = "SeisoKaisuKbn";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.TenkenKaisuShuCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.TenkenKaisuShuCol.HeaderText = "清掃回数区分";
            this.TenkenKaisuShuCol.MinimumWidth = 80;
            this.TenkenKaisuShuCol.Name = "TenkenKaisuShuCol";
            this.TenkenKaisuShuCol.ReadOnly = true;
            this.TenkenKaisuShuCol.Width = 80;
            // 
            // katashikiMakerCdDataGridViewTextBoxColumn
            // 
            this.katashikiMakerCdDataGridViewTextBoxColumn.DataPropertyName = "KatashikiMakerCd";
            this.katashikiMakerCdDataGridViewTextBoxColumn.HeaderText = "KatashikiMakerCd";
            this.katashikiMakerCdDataGridViewTextBoxColumn.Name = "katashikiMakerCdDataGridViewTextBoxColumn";
            this.katashikiMakerCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // katashikiCdDataGridViewTextBoxColumn
            // 
            this.katashikiCdDataGridViewTextBoxColumn.DataPropertyName = "KatashikiCd";
            this.katashikiCdDataGridViewTextBoxColumn.HeaderText = "KatashikiCd";
            this.katashikiCdDataGridViewTextBoxColumn.Name = "katashikiCdDataGridViewTextBoxColumn";
            this.katashikiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // katashikiNmDataGridViewTextBoxColumn
            // 
            this.katashikiNmDataGridViewTextBoxColumn.DataPropertyName = "KatashikiNm";
            this.katashikiNmDataGridViewTextBoxColumn.HeaderText = "KatashikiNm";
            this.katashikiNmDataGridViewTextBoxColumn.Name = "katashikiNmDataGridViewTextBoxColumn";
            this.katashikiNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // zenjorenTourokuNoDataGridViewTextBoxColumn
            // 
            this.zenjorenTourokuNoDataGridViewTextBoxColumn.DataPropertyName = "ZenjorenTourokuNo";
            this.zenjorenTourokuNoDataGridViewTextBoxColumn.HeaderText = "ZenjorenTourokuNo";
            this.zenjorenTourokuNoDataGridViewTextBoxColumn.Name = "zenjorenTourokuNoDataGridViewTextBoxColumn";
            this.zenjorenTourokuNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // zenjorenTourokuBiDataGridViewTextBoxColumn
            // 
            this.zenjorenTourokuBiDataGridViewTextBoxColumn.DataPropertyName = "ZenjorenTourokuBi";
            this.zenjorenTourokuBiDataGridViewTextBoxColumn.HeaderText = "ZenjorenTourokuBi";
            this.zenjorenTourokuBiDataGridViewTextBoxColumn.Name = "zenjorenTourokuBiDataGridViewTextBoxColumn";
            this.zenjorenTourokuBiDataGridViewTextBoxColumn.Visible = false;
            // 
            // tokuChoDataGridViewTextBoxColumn
            // 
            this.tokuChoDataGridViewTextBoxColumn.DataPropertyName = "TokuCho";
            this.tokuChoDataGridViewTextBoxColumn.HeaderText = "TokuCho";
            this.tokuChoDataGridViewTextBoxColumn.Name = "tokuChoDataGridViewTextBoxColumn";
            this.tokuChoDataGridViewTextBoxColumn.Visible = false;
            // 
            // seinohyokakataKbnDataGridViewTextBoxColumn
            // 
            this.seinohyokakataKbnDataGridViewTextBoxColumn.DataPropertyName = "SeinohyokakataKbn";
            this.seinohyokakataKbnDataGridViewTextBoxColumn.HeaderText = "SeinohyokakataKbn";
            this.seinohyokakataKbnDataGridViewTextBoxColumn.Name = "seinohyokakataKbnDataGridViewTextBoxColumn";
            this.seinohyokakataKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // konpakutokataKbnDataGridViewTextBoxColumn
            // 
            this.konpakutokataKbnDataGridViewTextBoxColumn.DataPropertyName = "KonpakutokataKbn";
            this.konpakutokataKbnDataGridViewTextBoxColumn.HeaderText = "KonpakutokataKbn";
            this.konpakutokataKbnDataGridViewTextBoxColumn.Name = "konpakutokataKbnDataGridViewTextBoxColumn";
            this.konpakutokataKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // katashikiShorihoushikiCdDataGridViewTextBoxColumn
            // 
            this.katashikiShorihoushikiCdDataGridViewTextBoxColumn.DataPropertyName = "KatashikiShorihoushikiCd";
            this.katashikiShorihoushikiCdDataGridViewTextBoxColumn.HeaderText = "KatashikiShorihoushikiCd";
            this.katashikiShorihoushikiCdDataGridViewTextBoxColumn.Name = "katashikiShorihoushikiCdDataGridViewTextBoxColumn";
            this.katashikiShorihoushikiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // katashikiShorihoushikiKbnColDataGridViewTextBoxColumn
            // 
            this.katashikiShorihoushikiKbnColDataGridViewTextBoxColumn.DataPropertyName = "KatashikiShorihoushikiKbnCol";
            this.katashikiShorihoushikiKbnColDataGridViewTextBoxColumn.HeaderText = "KatashikiShorihoushikiKbnCol";
            this.katashikiShorihoushikiKbnColDataGridViewTextBoxColumn.Name = "katashikiShorihoushikiKbnColDataGridViewTextBoxColumn";
            this.katashikiShorihoushikiKbnColDataGridViewTextBoxColumn.ReadOnly = true;
            this.katashikiShorihoushikiKbnColDataGridViewTextBoxColumn.Visible = false;
            // 
            // gyoshaNmDataGridViewTextBoxColumn
            // 
            this.gyoshaNmDataGridViewTextBoxColumn.DataPropertyName = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.HeaderText = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.Name = "gyoshaNmDataGridViewTextBoxColumn";
            this.gyoshaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // shoriHoshikiNmDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiNmDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiNm";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiNm";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.Name = "shoriHoshikiNmDataGridViewTextBoxColumn";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // katashikiMstDataSetBindingSource
            // 
            this.katashikiMstDataSetBindingSource.DataSource = this.katashikiMstDataSet;
            this.katashikiMstDataSetBindingSource.Position = 0;
            // 
            // katashikiMstDataSet
            // 
            this.katashikiMstDataSet.DataSetName = "KatashikiMstDataSet";
            this.katashikiMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.katashikiCdToTextBox);
            this.searchPanel.Controls.Add(this.katashikiCdFromTextBox);
            this.searchPanel.Controls.Add(this.katashikiMakerCdToTextBox);
            this.searchPanel.Controls.Add(this.katashikiMakerCdFromTextBox);
            this.searchPanel.Controls.Add(this.gyoshaNmTextBox);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.katashikiNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 183);
            this.searchPanel.TabIndex = 11;
            // 
            // katashikiCdToTextBox
            // 
            this.katashikiCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiCdToTextBox.CustomDigitParts = 0;
            this.katashikiCdToTextBox.CustomFormat = null;
            this.katashikiCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.katashikiCdToTextBox.CustomReadOnly = false;
            this.katashikiCdToTextBox.Location = new System.Drawing.Point(241, 102);
            this.katashikiCdToTextBox.MaxLength = 4;
            this.katashikiCdToTextBox.Name = "katashikiCdToTextBox";
            this.katashikiCdToTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiCdToTextBox.TabIndex = 10;
            this.katashikiCdToTextBox.Leave += new System.EventHandler(this.katashikiCdToTextBox_Leave);
            // 
            // katashikiCdFromTextBox
            // 
            this.katashikiCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiCdFromTextBox.CustomDigitParts = 0;
            this.katashikiCdFromTextBox.CustomFormat = null;
            this.katashikiCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.katashikiCdFromTextBox.CustomReadOnly = false;
            this.katashikiCdFromTextBox.Location = new System.Drawing.Point(148, 102);
            this.katashikiCdFromTextBox.MaxLength = 4;
            this.katashikiCdFromTextBox.Name = "katashikiCdFromTextBox";
            this.katashikiCdFromTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiCdFromTextBox.TabIndex = 8;
            this.katashikiCdFromTextBox.Leave += new System.EventHandler(this.katashikiCdFromTextBox_Leave);
            // 
            // katashikiMakerCdToTextBox
            // 
            this.katashikiMakerCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiMakerCdToTextBox.CustomDigitParts = 0;
            this.katashikiMakerCdToTextBox.CustomFormat = null;
            this.katashikiMakerCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.katashikiMakerCdToTextBox.CustomReadOnly = false;
            this.katashikiMakerCdToTextBox.Location = new System.Drawing.Point(241, 36);
            this.katashikiMakerCdToTextBox.MaxLength = 4;
            this.katashikiMakerCdToTextBox.Name = "katashikiMakerCdToTextBox";
            this.katashikiMakerCdToTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiMakerCdToTextBox.TabIndex = 4;
            this.katashikiMakerCdToTextBox.Leave += new System.EventHandler(this.katashikiMakerCdToTextBox_Leave);
            // 
            // katashikiMakerCdFromTextBox
            // 
            this.katashikiMakerCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiMakerCdFromTextBox.CustomDigitParts = 0;
            this.katashikiMakerCdFromTextBox.CustomFormat = null;
            this.katashikiMakerCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.katashikiMakerCdFromTextBox.CustomReadOnly = false;
            this.katashikiMakerCdFromTextBox.Location = new System.Drawing.Point(148, 36);
            this.katashikiMakerCdFromTextBox.MaxLength = 4;
            this.katashikiMakerCdFromTextBox.Name = "katashikiMakerCdFromTextBox";
            this.katashikiMakerCdFromTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiMakerCdFromTextBox.TabIndex = 2;
            this.katashikiMakerCdFromTextBox.Leave += new System.EventHandler(this.katashikiMakerCdFromTextBox_Leave);
            // 
            // gyoshaNmTextBox
            // 
            this.gyoshaNmTextBox.Location = new System.Drawing.Point(148, 69);
            this.gyoshaNmTextBox.MaxLength = 40;
            this.gyoshaNmTextBox.Name = "gyoshaNmTextBox";
            this.gyoshaNmTextBox.Size = new System.Drawing.Size(385, 27);
            this.gyoshaNmTextBox.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "メーカー業者名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "型式コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "～";
            // 
            // katashikiNmTextBox
            // 
            this.katashikiNmTextBox.Location = new System.Drawing.Point(148, 135);
            this.katashikiNmTextBox.MaxLength = 20;
            this.katashikiNmTextBox.Name = "katashikiNmTextBox";
            this.katashikiNmTextBox.Size = new System.Drawing.Size(385, 27);
            this.katashikiNmTextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "型式名称";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 15;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "メーカー業者コード";
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
            this.clearButton.Location = new System.Drawing.Point(884, 141);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 140);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 14;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // KatashikiMstListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.katashikiListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KatashikiMstListForm";
            this.Text = "型式マスタ検索";
            this.Load += new System.EventHandler(this.KatashikiMstListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KatashikiMstListForm_KeyDown);
            this.katashikiListPanel.ResumeLayout(false);
            this.katashikiListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel katashikiListPanel;
        private System.Windows.Forms.Label katashikiListCountLabel;
        private ZDataGridView katashikiListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox katashikiNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.TextBox gyoshaNmTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource katashikiMstDataSetBindingSource;
        private DataSet.KatashikiMstDataSet katashikiMstDataSet;
        private Control.NumberTextBox katashikiCdToTextBox;
        private Control.NumberTextBox katashikiCdFromTextBox;
        private Control.NumberTextBox katashikiMakerCdToTextBox;
        private Control.NumberTextBox katashikiMakerCdFromTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn KatashikiMakerCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GyoshaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KatashikiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KatashikiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZenjorenTourokuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZenjorenTourokuBiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokuChoCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SeinohyokakataKbnCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn KonpakutokataKbnCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BODKodoshorikataKbnCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChissojokyokataKbnCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RinjokyokataKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KatashikiShorihoushikiKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KatashikiShorihoushikiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenkenKaisuTsukiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenkenKaisuShuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiMakerCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zenjorenTourokuNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zenjorenTourokuBiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokuChoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seinohyokakataKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn konpakutokataKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiShorihoushikiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiShorihoushikiKbnColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiNmDataGridViewTextBoxColumn;

    }
}