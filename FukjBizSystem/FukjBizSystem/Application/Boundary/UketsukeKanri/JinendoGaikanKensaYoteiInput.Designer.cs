namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    partial class JinendoGaikanKensaYoteiInputForm
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
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.kensaIraiListPanel = new System.Windows.Forms.Panel();
            this.kensaIraiListCountLabel = new System.Windows.Forms.Label();
            this.kensaIraiListDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.kensaNendoTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.gyoshaCdTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.gyosyaSearchButton = new Zynas.Control.ZButton(this.components);
            this.gyoshaNmTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.henkoButton = new System.Windows.Forms.Button();
            this.torikesiButton = new System.Windows.Forms.Button();
            this.kakuteiButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.jinendoGaikanInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jokasoDaichoMstDataSet = new FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSet();
            this.jinendoGaikanInputTableAdapter = new FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters.JinendoGaikanInputTableAdapter();
            this.kensaIraiHoteiKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHokenjoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiNendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settisyaKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setchishaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoSetchishaKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoSetchishaCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setchishaCdHiddenCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settisyaKbnHiddenCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nendoHiddenCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiListDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jinendoGaikanInputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jokasoDaichoMstDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(863, 555);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 6;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(994, 555);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 7;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // kensaIraiListPanel
            // 
            this.kensaIraiListPanel.Controls.Add(this.kensaIraiListCountLabel);
            this.kensaIraiListPanel.Controls.Add(this.kensaIraiListDataGridView);
            this.kensaIraiListPanel.Controls.Add(this.label4);
            this.kensaIraiListPanel.Location = new System.Drawing.Point(0, 101);
            this.kensaIraiListPanel.Name = "kensaIraiListPanel";
            this.kensaIraiListPanel.Size = new System.Drawing.Size(1103, 450);
            this.kensaIraiListPanel.TabIndex = 1;
            // 
            // kensaIraiListCountLabel
            // 
            this.kensaIraiListCountLabel.AutoSize = true;
            this.kensaIraiListCountLabel.Location = new System.Drawing.Point(987, 1);
            this.kensaIraiListCountLabel.Name = "kensaIraiListCountLabel";
            this.kensaIraiListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.kensaIraiListCountLabel.TabIndex = 1;
            this.kensaIraiListCountLabel.Text = "0件";
            // 
            // kensaIraiListDataGridView
            // 
            this.kensaIraiListDataGridView.AllowUserToAddRows = false;
            this.kensaIraiListDataGridView.AllowUserToDeleteRows = false;
            this.kensaIraiListDataGridView.AllowUserToResizeRows = false;
            this.kensaIraiListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kensaIraiListDataGridView.AutoGenerateColumns = false;
            this.kensaIraiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kensaIraiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kensaIraiHoteiKbnCol,
            this.kensaIraiHokenjoCdCol,
            this.kensaIraiNendoCol,
            this.kensaIraiRenbanCol,
            this.settisyaKbnCol,
            this.setchishaCdCol,
            this.nendoCol,
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn,
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn,
            this.kensaIraiNendoDataGridViewTextBoxColumn,
            this.kensaIraiRenbanDataGridViewTextBoxColumn,
            this.jokasoSetchishaKbnDataGridViewTextBoxColumn,
            this.jokasoSetchishaCdDataGridViewTextBoxColumn,
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn,
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn,
            this.kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn,
            this.setchishaCdHiddenCol,
            this.settisyaKbnHiddenCol,
            this.nendoHiddenCol,
            this.UpdateDtCol});
            this.kensaIraiListDataGridView.DataSource = this.jinendoGaikanInputBindingSource;
            this.kensaIraiListDataGridView.Location = new System.Drawing.Point(2, 25);
            this.kensaIraiListDataGridView.Name = "kensaIraiListDataGridView";
            this.kensaIraiListDataGridView.RowHeadersVisible = false;
            this.kensaIraiListDataGridView.RowTemplate.Height = 21;
            this.kensaIraiListDataGridView.Size = new System.Drawing.Size(1100, 424);
            this.kensaIraiListDataGridView.TabIndex = 2;
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
            this.searchPanel.Controls.Add(this.kensaNendoTextBox);
            this.searchPanel.Controls.Add(this.gyoshaCdTextBox);
            this.searchPanel.Controls.Add(this.gyosyaSearchButton);
            this.searchPanel.Controls.Add(this.gyoshaNmTextBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label10);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 100);
            this.searchPanel.TabIndex = 0;
            // 
            // kensaNendoTextBox
            // 
            this.kensaNendoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaNendoTextBox.CustomDigitParts = 0;
            this.kensaNendoTextBox.CustomFormat = null;
            this.kensaNendoTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.kensaNendoTextBox.CustomReadOnly = false;
            this.kensaNendoTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.kensaNendoTextBox.Location = new System.Drawing.Point(102, 67);
            this.kensaNendoTextBox.MaxLength = 4;
            this.kensaNendoTextBox.Name = "kensaNendoTextBox";
            this.kensaNendoTextBox.Size = new System.Drawing.Size(47, 27);
            this.kensaNendoTextBox.TabIndex = 8;
            // 
            // gyoshaCdTextBox
            // 
            this.gyoshaCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gyoshaCdTextBox.CustomDigitParts = 0;
            this.gyoshaCdTextBox.CustomFormat = null;
            this.gyoshaCdTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gyoshaCdTextBox.CustomReadOnly = false;
            this.gyoshaCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.gyoshaCdTextBox.Location = new System.Drawing.Point(102, 34);
            this.gyoshaCdTextBox.MaxLength = 4;
            this.gyoshaCdTextBox.Name = "gyoshaCdTextBox";
            this.gyoshaCdTextBox.Size = new System.Drawing.Size(47, 27);
            this.gyoshaCdTextBox.TabIndex = 3;
            // 
            // gyosyaSearchButton
            // 
            this.gyosyaSearchButton.Image = global::FukjBizSystem.Properties.Resources.icon_search;
            this.gyosyaSearchButton.Location = new System.Drawing.Point(461, 33);
            this.gyosyaSearchButton.Name = "gyosyaSearchButton";
            this.gyosyaSearchButton.Size = new System.Drawing.Size(28, 26);
            this.gyosyaSearchButton.TabIndex = 5;
            this.gyosyaSearchButton.UseVisualStyleBackColor = true;
            this.gyosyaSearchButton.Click += new System.EventHandler(this.gyosyaSearchButton_Click);
            // 
            // gyoshaNmTextBox
            // 
            this.gyoshaNmTextBox.Location = new System.Drawing.Point(155, 34);
            this.gyoshaNmTextBox.MaxLength = 40;
            this.gyoshaNmTextBox.Name = "gyoshaNmTextBox";
            this.gyoshaNmTextBox.Size = new System.Drawing.Size(300, 27);
            this.gyoshaNmTextBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(73, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(85, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "業者コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(155, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "例) 2000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "検査年度";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 12;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
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
            this.clearButton.Location = new System.Drawing.Point(884, 58);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 57);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 11;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // henkoButton
            // 
            this.henkoButton.Location = new System.Drawing.Point(514, 555);
            this.henkoButton.Name = "henkoButton";
            this.henkoButton.Size = new System.Drawing.Size(101, 37);
            this.henkoButton.TabIndex = 3;
            this.henkoButton.Text = "F1:変更";
            this.henkoButton.UseVisualStyleBackColor = true;
            this.henkoButton.Click += new System.EventHandler(this.henkoButton_Click);
            // 
            // torikesiButton
            // 
            this.torikesiButton.Location = new System.Drawing.Point(624, 555);
            this.torikesiButton.Name = "torikesiButton";
            this.torikesiButton.Size = new System.Drawing.Size(101, 37);
            this.torikesiButton.TabIndex = 4;
            this.torikesiButton.Text = "F2:取消";
            this.torikesiButton.UseVisualStyleBackColor = true;
            this.torikesiButton.Click += new System.EventHandler(this.torikesiButton_Click);
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Location = new System.Drawing.Point(731, 555);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(101, 37);
            this.kakuteiButton.TabIndex = 5;
            this.kakuteiButton.Text = "F3:確定";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(281, 555);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(201, 37);
            this.printButton.TabIndex = 2;
            this.printButton.Text = "F4:11条検査依頼一覧表印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // jinendoGaikanInputBindingSource
            // 
            this.jinendoGaikanInputBindingSource.DataMember = "JinendoGaikanInput";
            this.jinendoGaikanInputBindingSource.DataSource = this.jokasoDaichoMstDataSet;
            // 
            // jokasoDaichoMstDataSet
            // 
            this.jokasoDaichoMstDataSet.DataSetName = "JokasoDaichoMstDataSet";
            this.jokasoDaichoMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jinendoGaikanInputTableAdapter
            // 
            this.jinendoGaikanInputTableAdapter.ClearBeforeFill = true;
            // 
            // kensaIraiHoteiKbnCol
            // 
            this.kensaIraiHoteiKbnCol.DataPropertyName = "KensaIraiHoteiKbn";
            this.kensaIraiHoteiKbnCol.HeaderText = "検査依頼法定区分";
            this.kensaIraiHoteiKbnCol.Name = "kensaIraiHoteiKbnCol";
            this.kensaIraiHoteiKbnCol.Visible = false;
            // 
            // kensaIraiHokenjoCdCol
            // 
            this.kensaIraiHokenjoCdCol.DataPropertyName = "KensaIraiHokenjoCd";
            this.kensaIraiHokenjoCdCol.HeaderText = "検査依頼保健所コード";
            this.kensaIraiHokenjoCdCol.Name = "kensaIraiHokenjoCdCol";
            this.kensaIraiHokenjoCdCol.Visible = false;
            // 
            // kensaIraiNendoCol
            // 
            this.kensaIraiNendoCol.DataPropertyName = "KensaIraiNendo";
            this.kensaIraiNendoCol.HeaderText = "検査依頼年度";
            this.kensaIraiNendoCol.Name = "kensaIraiNendoCol";
            this.kensaIraiNendoCol.Visible = false;
            // 
            // kensaIraiRenbanCol
            // 
            this.kensaIraiRenbanCol.DataPropertyName = "KensaIraiRenban";
            this.kensaIraiRenbanCol.HeaderText = "検査依頼連番";
            this.kensaIraiRenbanCol.Name = "kensaIraiRenbanCol";
            this.kensaIraiRenbanCol.Visible = false;
            // 
            // settisyaKbnCol
            // 
            this.settisyaKbnCol.DataPropertyName = "JokasoSetchishaKbn";
            this.settisyaKbnCol.HeaderText = "設置者区分";
            this.settisyaKbnCol.MaxInputLength = 1;
            this.settisyaKbnCol.Name = "settisyaKbnCol";
            // 
            // setchishaCdCol
            // 
            this.setchishaCdCol.DataPropertyName = "JokasoSetchishaCd";
            this.setchishaCdCol.HeaderText = "設置者コード";
            this.setchishaCdCol.MaxInputLength = 7;
            this.setchishaCdCol.Name = "setchishaCdCol";
            this.setchishaCdCol.Width = 110;
            // 
            // nendoCol
            // 
            this.nendoCol.DataPropertyName = "KensaIraiKensaYoteiTsuki";
            this.nendoCol.HeaderText = "予定月";
            this.nendoCol.MaxInputLength = 2;
            this.nendoCol.Name = "nendoCol";
            // 
            // kensaIraiHoteiKbnDataGridViewTextBoxColumn
            // 
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiHoteiKbn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.HeaderText = "KensaIraiHoteiKbn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.Name = "kensaIraiHoteiKbnDataGridViewTextBoxColumn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiHokenjoCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiHokenjoCd";
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiHokenjoCd";
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.Name = "kensaIraiHokenjoCdDataGridViewTextBoxColumn";
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiNendoDataGridViewTextBoxColumn
            // 
            this.kensaIraiNendoDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiNendo";
            this.kensaIraiNendoDataGridViewTextBoxColumn.HeaderText = "KensaIraiNendo";
            this.kensaIraiNendoDataGridViewTextBoxColumn.Name = "kensaIraiNendoDataGridViewTextBoxColumn";
            this.kensaIraiNendoDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiRenbanDataGridViewTextBoxColumn
            // 
            this.kensaIraiRenbanDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiRenban";
            this.kensaIraiRenbanDataGridViewTextBoxColumn.HeaderText = "KensaIraiRenban";
            this.kensaIraiRenbanDataGridViewTextBoxColumn.Name = "kensaIraiRenbanDataGridViewTextBoxColumn";
            this.kensaIraiRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoSetchishaKbnDataGridViewTextBoxColumn
            // 
            this.jokasoSetchishaKbnDataGridViewTextBoxColumn.DataPropertyName = "JokasoSetchishaKbn";
            this.jokasoSetchishaKbnDataGridViewTextBoxColumn.HeaderText = "JokasoSetchishaKbn";
            this.jokasoSetchishaKbnDataGridViewTextBoxColumn.Name = "jokasoSetchishaKbnDataGridViewTextBoxColumn";
            this.jokasoSetchishaKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoSetchishaCdDataGridViewTextBoxColumn
            // 
            this.jokasoSetchishaCdDataGridViewTextBoxColumn.DataPropertyName = "JokasoSetchishaCd";
            this.jokasoSetchishaCdDataGridViewTextBoxColumn.HeaderText = "JokasoSetchishaCd";
            this.jokasoSetchishaCdDataGridViewTextBoxColumn.Name = "jokasoSetchishaCdDataGridViewTextBoxColumn";
            this.jokasoSetchishaCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn
            // 
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKensaYoteiTsuki";
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.HeaderText = "KensaIraiKensaYoteiTsuki";
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.Name = "kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn";
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKensaYoteiNenDataGridViewTextBoxColumn
            // 
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKensaYoteiNen";
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.HeaderText = "KensaIraiKensaYoteiNen";
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.Name = "kensaIraiKensaYoteiNenDataGridViewTextBoxColumn";
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiIkkatsuSeikyusakiCd";
            this.kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiIkkatsuSeikyusakiCd";
            this.kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn.Name = "kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn";
            this.kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // setchishaCdHiddenCol
            // 
            this.setchishaCdHiddenCol.HeaderText = "setchishaCdHiddenCol";
            this.setchishaCdHiddenCol.Name = "setchishaCdHiddenCol";
            this.setchishaCdHiddenCol.Visible = false;
            // 
            // settisyaKbnHiddenCol
            // 
            this.settisyaKbnHiddenCol.HeaderText = "settisyaKbnHiddenCol";
            this.settisyaKbnHiddenCol.Name = "settisyaKbnHiddenCol";
            this.settisyaKbnHiddenCol.Visible = false;
            // 
            // nendoHiddenCol
            // 
            this.nendoHiddenCol.HeaderText = "nendoHiddenCol";
            this.nendoHiddenCol.Name = "nendoHiddenCol";
            this.nendoHiddenCol.Visible = false;
            // 
            // UpdateDtCol
            // 
            this.UpdateDtCol.DataPropertyName = "UpdateDt";
            this.UpdateDtCol.HeaderText = "UpdateDtCol";
            this.UpdateDtCol.Name = "UpdateDtCol";
            this.UpdateDtCol.Visible = false;
            // 
            // JinendoGaikanKensaYoteiInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.kakuteiButton);
            this.Controls.Add(this.torikesiButton);
            this.Controls.Add(this.henkoButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.kensaIraiListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "JinendoGaikanKensaYoteiInputForm";
            this.Text = "次年度外観検査予定入力";
            this.Load += new System.EventHandler(this.JinendoGaikanKensaYoteiInputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JinendoGaikanKensaYoteiInputForm_KeyDown);
            this.kensaIraiListPanel.ResumeLayout(false);
            this.kensaIraiListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiListDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jinendoGaikanInputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jokasoDaichoMstDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Panel kensaIraiListPanel;
        private System.Windows.Forms.Label kensaIraiListCountLabel;
        private System.Windows.Forms.DataGridView kensaIraiListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox gyoshaNmTextBox;
        private System.Windows.Forms.Label label7;
        private Zynas.Control.ZButton gyosyaSearchButton;
        private System.Windows.Forms.Button henkoButton;
        private System.Windows.Forms.Button torikesiButton;
        private System.Windows.Forms.Button kakuteiButton;
        private System.Windows.Forms.Button printButton;
        private Control.NumberTextBox gyoshaCdTextBox;
        private Control.NumberTextBox kensaNendoTextBox;
        private System.Windows.Forms.BindingSource jinendoGaikanInputBindingSource;
        private DataSet.JokasoDaichoMstDataSet jokasoDaichoMstDataSet;
        private DataSet.JokasoDaichoMstDataSetTableAdapters.JinendoGaikanInputTableAdapter jinendoGaikanInputTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHoteiKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHokenjoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiNendoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiRenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn settisyaKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn setchishaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nendoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHoteiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoSetchishaKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoSetchishaCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKensaYoteiNenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiIkkatsuSeikyusakiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setchishaCdHiddenCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn settisyaKbnHiddenCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nendoHiddenCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDtCol;

    }
}