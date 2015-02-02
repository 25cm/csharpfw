using FukjBizSystem.Control;
namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    partial class JinendoGaikanKensaYoteiListOutputForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.jinendoGaikanKensaYoteiListOutputPanel = new System.Windows.Forms.Panel();
            this.jinendoGaikanKensaYoteiListOutputCountLabel = new System.Windows.Forms.Label();
            this.jinendoGaikanKensaYoteiListOutputDataGridView = new System.Windows.Forms.DataGridView();
            this.outputKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sakuhyoKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chikuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiSetchishaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiSetchibashoAdrCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiShoritaishoJininCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoSetchishaKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoSetchishaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sakuhyoKbnColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaDtColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaKbnColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zenkaiKensaDataWrkDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zenkaiKensaDataWrkDataSet = new FukjBizSystem.Application.DataSet.ZenkaiKensaDataWrkDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.sakuhyoKbn3GroupBox = new System.Windows.Forms.GroupBox();
            this.sakuhyoKbn33RadioButton = new System.Windows.Forms.RadioButton();
            this.sakuhyoKbn32RadioButton = new System.Windows.Forms.RadioButton();
            this.sakuhyoKbn31RadioButton = new System.Windows.Forms.RadioButton();
            this.chikuCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.chikuCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kensaNendoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.sakuhyoKbn2GroupBox = new System.Windows.Forms.GroupBox();
            this.sakuhyoKbn23RadioButton = new System.Windows.Forms.RadioButton();
            this.sakuhyoKbn22RadioButton = new System.Windows.Forms.RadioButton();
            this.sakuhyoKbn21RadioButton = new System.Windows.Forms.RadioButton();
            this.sakuhyoKbn1GroupBox = new System.Windows.Forms.GroupBox();
            this.sakuhyoKbn13RadioButton = new System.Windows.Forms.RadioButton();
            this.sakuhyoKbn12RadioButton = new System.Windows.Forms.RadioButton();
            this.sakuhyoKbn11RadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.jinendoGaikanKensaYoteiListOutputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jinendoGaikanKensaYoteiListOutputDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zenkaiKensaDataWrkDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zenkaiKensaDataWrkDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.sakuhyoKbn3GroupBox.SuspendLayout();
            this.sakuhyoKbn2GroupBox.SuspendLayout();
            this.sakuhyoKbn1GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(863, 555);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 3;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(994, 555);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 4;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // jinendoGaikanKensaYoteiListOutputPanel
            // 
            this.jinendoGaikanKensaYoteiListOutputPanel.Controls.Add(this.jinendoGaikanKensaYoteiListOutputCountLabel);
            this.jinendoGaikanKensaYoteiListOutputPanel.Controls.Add(this.jinendoGaikanKensaYoteiListOutputDataGridView);
            this.jinendoGaikanKensaYoteiListOutputPanel.Controls.Add(this.label4);
            this.jinendoGaikanKensaYoteiListOutputPanel.Location = new System.Drawing.Point(0, 144);
            this.jinendoGaikanKensaYoteiListOutputPanel.Name = "jinendoGaikanKensaYoteiListOutputPanel";
            this.jinendoGaikanKensaYoteiListOutputPanel.Size = new System.Drawing.Size(1103, 407);
            this.jinendoGaikanKensaYoteiListOutputPanel.TabIndex = 1;
            // 
            // jinendoGaikanKensaYoteiListOutputCountLabel
            // 
            this.jinendoGaikanKensaYoteiListOutputCountLabel.AutoSize = true;
            this.jinendoGaikanKensaYoteiListOutputCountLabel.Location = new System.Drawing.Point(987, 1);
            this.jinendoGaikanKensaYoteiListOutputCountLabel.Name = "jinendoGaikanKensaYoteiListOutputCountLabel";
            this.jinendoGaikanKensaYoteiListOutputCountLabel.Size = new System.Drawing.Size(30, 20);
            this.jinendoGaikanKensaYoteiListOutputCountLabel.TabIndex = 1;
            this.jinendoGaikanKensaYoteiListOutputCountLabel.Text = "0件";
            // 
            // jinendoGaikanKensaYoteiListOutputDataGridView
            // 
            this.jinendoGaikanKensaYoteiListOutputDataGridView.AllowUserToAddRows = false;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.AllowUserToDeleteRows = false;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.AllowUserToResizeRows = false;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jinendoGaikanKensaYoteiListOutputDataGridView.AutoGenerateColumns = false;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.outputKbnCol,
            this.inputKbnCol,
            this.gyoshaCdCol,
            this.gyoshaNmCol,
            this.sakuhyoKbnCol,
            this.chikuNmCol,
            this.kensaIraiSetchishaNmCol,
            this.kensaIraiSetchibashoAdrCol,
            this.kensaIraiShoritaishoJininCol,
            this.shoriHoshikiCol,
            this.kensaDtCol,
            this.kensaKbnCol,
            this.jokasoSetchishaKbnCol,
            this.jokasoSetchishaCdCol,
            this.jokasoCdCol,
            this.sakuhyoKbnColDataGridViewTextBoxColumn,
            this.kensaDtColDataGridViewTextBoxColumn,
            this.kensaKbnColDataGridViewTextBoxColumn});
            this.jinendoGaikanKensaYoteiListOutputDataGridView.DataMember = "ZenkaiKensaDataWrkKensaku";
            this.jinendoGaikanKensaYoteiListOutputDataGridView.DataSource = this.zenkaiKensaDataWrkDataSetBindingSource;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.Location = new System.Drawing.Point(2, 25);
            this.jinendoGaikanKensaYoteiListOutputDataGridView.MultiSelect = false;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.Name = "jinendoGaikanKensaYoteiListOutputDataGridView";
            this.jinendoGaikanKensaYoteiListOutputDataGridView.ReadOnly = true;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.RowHeadersVisible = false;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.RowTemplate.Height = 21;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jinendoGaikanKensaYoteiListOutputDataGridView.Size = new System.Drawing.Size(1100, 381);
            this.jinendoGaikanKensaYoteiListOutputDataGridView.TabIndex = 2;
            // 
            // outputKbnCol
            // 
            this.outputKbnCol.DataPropertyName = "outputKbnCol";
            this.outputKbnCol.HeaderText = "出力";
            this.outputKbnCol.MinimumWidth = 60;
            this.outputKbnCol.Name = "outputKbnCol";
            this.outputKbnCol.ReadOnly = true;
            this.outputKbnCol.Width = 60;
            // 
            // inputKbnCol
            // 
            this.inputKbnCol.DataPropertyName = "inputKbnCol";
            this.inputKbnCol.HeaderText = "入力";
            this.inputKbnCol.MinimumWidth = 60;
            this.inputKbnCol.Name = "inputKbnCol";
            this.inputKbnCol.ReadOnly = true;
            this.inputKbnCol.Width = 60;
            // 
            // gyoshaCdCol
            // 
            this.gyoshaCdCol.DataPropertyName = "GyoshaCd";
            this.gyoshaCdCol.HeaderText = "業者コード";
            this.gyoshaCdCol.MinimumWidth = 100;
            this.gyoshaCdCol.Name = "gyoshaCdCol";
            this.gyoshaCdCol.ReadOnly = true;
            // 
            // gyoshaNmCol
            // 
            this.gyoshaNmCol.DataPropertyName = "GyoshaNm";
            this.gyoshaNmCol.HeaderText = "業者名";
            this.gyoshaNmCol.MinimumWidth = 100;
            this.gyoshaNmCol.Name = "gyoshaNmCol";
            this.gyoshaNmCol.ReadOnly = true;
            // 
            // sakuhyoKbnCol
            // 
            this.sakuhyoKbnCol.DataPropertyName = "sakuhyoKbnCol";
            this.sakuhyoKbnCol.HeaderText = "作表区分";
            this.sakuhyoKbnCol.MinimumWidth = 200;
            this.sakuhyoKbnCol.Name = "sakuhyoKbnCol";
            this.sakuhyoKbnCol.ReadOnly = true;
            this.sakuhyoKbnCol.Width = 200;
            // 
            // chikuNmCol
            // 
            this.chikuNmCol.DataPropertyName = "ShichosonNm";
            this.chikuNmCol.HeaderText = "市町村";
            this.chikuNmCol.MinimumWidth = 100;
            this.chikuNmCol.Name = "chikuNmCol";
            this.chikuNmCol.ReadOnly = true;
            // 
            // kensaIraiSetchishaNmCol
            // 
            this.kensaIraiSetchishaNmCol.DataPropertyName = "SetchishaNm";
            this.kensaIraiSetchishaNmCol.HeaderText = "設置者名";
            this.kensaIraiSetchishaNmCol.MinimumWidth = 100;
            this.kensaIraiSetchishaNmCol.Name = "kensaIraiSetchishaNmCol";
            this.kensaIraiSetchishaNmCol.ReadOnly = true;
            // 
            // kensaIraiSetchibashoAdrCol
            // 
            this.kensaIraiSetchibashoAdrCol.DataPropertyName = "SetchishaAdr";
            this.kensaIraiSetchibashoAdrCol.HeaderText = "設置場所";
            this.kensaIraiSetchibashoAdrCol.MinimumWidth = 100;
            this.kensaIraiSetchibashoAdrCol.Name = "kensaIraiSetchibashoAdrCol";
            this.kensaIraiSetchibashoAdrCol.ReadOnly = true;
            // 
            // kensaIraiShoritaishoJininCol
            // 
            this.kensaIraiShoritaishoJininCol.DataPropertyName = "Ninso";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.kensaIraiShoritaishoJininCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.kensaIraiShoritaishoJininCol.HeaderText = "人槽";
            this.kensaIraiShoritaishoJininCol.MinimumWidth = 80;
            this.kensaIraiShoritaishoJininCol.Name = "kensaIraiShoritaishoJininCol";
            this.kensaIraiShoritaishoJininCol.ReadOnly = true;
            this.kensaIraiShoritaishoJininCol.Width = 80;
            // 
            // shoriHoshikiCol
            // 
            this.shoriHoshikiCol.DataPropertyName = "ConstNm";
            this.shoriHoshikiCol.HeaderText = "処理方式";
            this.shoriHoshikiCol.MinimumWidth = 100;
            this.shoriHoshikiCol.Name = "shoriHoshikiCol";
            this.shoriHoshikiCol.ReadOnly = true;
            // 
            // kensaDtCol
            // 
            this.kensaDtCol.DataPropertyName = "kensaDtCol";
            this.kensaDtCol.HeaderText = "前回検査日";
            this.kensaDtCol.MinimumWidth = 100;
            this.kensaDtCol.Name = "kensaDtCol";
            this.kensaDtCol.ReadOnly = true;
            // 
            // kensaKbnCol
            // 
            this.kensaKbnCol.DataPropertyName = "kensaKbnCol";
            this.kensaKbnCol.HeaderText = "検査区分";
            this.kensaKbnCol.MinimumWidth = 100;
            this.kensaKbnCol.Name = "kensaKbnCol";
            this.kensaKbnCol.ReadOnly = true;
            // 
            // jokasoSetchishaKbnCol
            // 
            this.jokasoSetchishaKbnCol.DataPropertyName = "SetchishaKbn";
            this.jokasoSetchishaKbnCol.HeaderText = "設置者区分";
            this.jokasoSetchishaKbnCol.MinimumWidth = 100;
            this.jokasoSetchishaKbnCol.Name = "jokasoSetchishaKbnCol";
            this.jokasoSetchishaKbnCol.ReadOnly = true;
            // 
            // jokasoSetchishaCdCol
            // 
            this.jokasoSetchishaCdCol.DataPropertyName = "SetchishaCd";
            this.jokasoSetchishaCdCol.HeaderText = "設置者コード";
            this.jokasoSetchishaCdCol.MinimumWidth = 110;
            this.jokasoSetchishaCdCol.Name = "jokasoSetchishaCdCol";
            this.jokasoSetchishaCdCol.ReadOnly = true;
            this.jokasoSetchishaCdCol.Width = 110;
            // 
            // jokasoCdCol
            // 
            this.jokasoCdCol.DataPropertyName = "jokasoCdCol";
            this.jokasoCdCol.HeaderText = "浄化槽番号";
            this.jokasoCdCol.Name = "jokasoCdCol";
            this.jokasoCdCol.ReadOnly = true;
            // 
            // sakuhyoKbnColDataGridViewTextBoxColumn
            // 
            this.sakuhyoKbnColDataGridViewTextBoxColumn.DataPropertyName = "sakuhyoKbnCol";
            this.sakuhyoKbnColDataGridViewTextBoxColumn.HeaderText = "sakuhyoKbnCol";
            this.sakuhyoKbnColDataGridViewTextBoxColumn.Name = "sakuhyoKbnColDataGridViewTextBoxColumn";
            this.sakuhyoKbnColDataGridViewTextBoxColumn.ReadOnly = true;
            this.sakuhyoKbnColDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaDtColDataGridViewTextBoxColumn
            // 
            this.kensaDtColDataGridViewTextBoxColumn.DataPropertyName = "kensaDtCol";
            this.kensaDtColDataGridViewTextBoxColumn.HeaderText = "kensaDtCol";
            this.kensaDtColDataGridViewTextBoxColumn.Name = "kensaDtColDataGridViewTextBoxColumn";
            this.kensaDtColDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaDtColDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaKbnColDataGridViewTextBoxColumn
            // 
            this.kensaKbnColDataGridViewTextBoxColumn.DataPropertyName = "kensaKbnCol";
            this.kensaKbnColDataGridViewTextBoxColumn.HeaderText = "kensaKbnCol";
            this.kensaKbnColDataGridViewTextBoxColumn.Name = "kensaKbnColDataGridViewTextBoxColumn";
            this.kensaKbnColDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaKbnColDataGridViewTextBoxColumn.Visible = false;
            // 
            // zenkaiKensaDataWrkDataSetBindingSource
            // 
            this.zenkaiKensaDataWrkDataSetBindingSource.DataSource = this.zenkaiKensaDataWrkDataSet;
            this.zenkaiKensaDataWrkDataSetBindingSource.Position = 0;
            // 
            // zenkaiKensaDataWrkDataSet
            // 
            this.zenkaiKensaDataWrkDataSet.DataSetName = "ZenkaiKensaDataWrkDataSet";
            this.zenkaiKensaDataWrkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.searchPanel.Controls.Add(this.sakuhyoKbn3GroupBox);
            this.searchPanel.Controls.Add(this.chikuCdToTextBox);
            this.searchPanel.Controls.Add(this.chikuCdFromTextBox);
            this.searchPanel.Controls.Add(this.gyoshaCdToTextBox);
            this.searchPanel.Controls.Add(this.gyoshaCdFromTextBox);
            this.searchPanel.Controls.Add(this.kensaNendoTextBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.sakuhyoKbn2GroupBox);
            this.searchPanel.Controls.Add(this.sakuhyoKbn1GroupBox);
            this.searchPanel.Controls.Add(this.label9);
            this.searchPanel.Controls.Add(this.label10);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 144);
            this.searchPanel.TabIndex = 0;
            // 
            // sakuhyoKbn3GroupBox
            // 
            this.sakuhyoKbn3GroupBox.Controls.Add(this.sakuhyoKbn33RadioButton);
            this.sakuhyoKbn3GroupBox.Controls.Add(this.sakuhyoKbn32RadioButton);
            this.sakuhyoKbn3GroupBox.Controls.Add(this.sakuhyoKbn31RadioButton);
            this.sakuhyoKbn3GroupBox.Location = new System.Drawing.Point(683, 31);
            this.sakuhyoKbn3GroupBox.Name = "sakuhyoKbn3GroupBox";
            this.sakuhyoKbn3GroupBox.Size = new System.Drawing.Size(174, 107);
            this.sakuhyoKbn3GroupBox.TabIndex = 15;
            this.sakuhyoKbn3GroupBox.TabStop = false;
            this.sakuhyoKbn3GroupBox.Text = "差分出力";
            // 
            // sakuhyoKbn33RadioButton
            // 
            this.sakuhyoKbn33RadioButton.AutoSize = true;
            this.sakuhyoKbn33RadioButton.Checked = true;
            this.sakuhyoKbn33RadioButton.Location = new System.Drawing.Point(17, 76);
            this.sakuhyoKbn33RadioButton.Name = "sakuhyoKbn33RadioButton";
            this.sakuhyoKbn33RadioButton.Size = new System.Drawing.Size(66, 24);
            this.sakuhyoKbn33RadioButton.TabIndex = 2;
            this.sakuhyoKbn33RadioButton.TabStop = true;
            this.sakuhyoKbn33RadioButton.Text = "すべて";
            this.sakuhyoKbn33RadioButton.UseVisualStyleBackColor = true;
            // 
            // sakuhyoKbn32RadioButton
            // 
            this.sakuhyoKbn32RadioButton.AutoSize = true;
            this.sakuhyoKbn32RadioButton.Location = new System.Drawing.Point(17, 50);
            this.sakuhyoKbn32RadioButton.Name = "sakuhyoKbn32RadioButton";
            this.sakuhyoKbn32RadioButton.Size = new System.Drawing.Size(79, 24);
            this.sakuhyoKbn32RadioButton.TabIndex = 1;
            this.sakuhyoKbn32RadioButton.Text = "入力差分";
            this.sakuhyoKbn32RadioButton.UseVisualStyleBackColor = true;
            // 
            // sakuhyoKbn31RadioButton
            // 
            this.sakuhyoKbn31RadioButton.AutoSize = true;
            this.sakuhyoKbn31RadioButton.Location = new System.Drawing.Point(17, 23);
            this.sakuhyoKbn31RadioButton.Name = "sakuhyoKbn31RadioButton";
            this.sakuhyoKbn31RadioButton.Size = new System.Drawing.Size(79, 24);
            this.sakuhyoKbn31RadioButton.TabIndex = 0;
            this.sakuhyoKbn31RadioButton.Text = "出力差分";
            this.sakuhyoKbn31RadioButton.UseVisualStyleBackColor = true;
            // 
            // chikuCdToTextBox
            // 
            this.chikuCdToTextBox.AllowDropDown = false;
            this.chikuCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.chikuCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.chikuCdToTextBox.CustomReadOnly = false;
            this.chikuCdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.chikuCdToTextBox.Location = new System.Drawing.Point(186, 68);
            this.chikuCdToTextBox.MaxLength = 5;
            this.chikuCdToTextBox.Name = "chikuCdToTextBox";
            this.chikuCdToTextBox.Size = new System.Drawing.Size(60, 27);
            this.chikuCdToTextBox.TabIndex = 8;
            this.chikuCdToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chikuCdToTextBox.Leave += new System.EventHandler(this.chikuCdToTextBox_Leave);
            // 
            // chikuCdFromTextBox
            // 
            this.chikuCdFromTextBox.AllowDropDown = false;
            this.chikuCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.chikuCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.chikuCdFromTextBox.CustomReadOnly = false;
            this.chikuCdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.chikuCdFromTextBox.Location = new System.Drawing.Point(92, 68);
            this.chikuCdFromTextBox.MaxLength = 5;
            this.chikuCdFromTextBox.Name = "chikuCdFromTextBox";
            this.chikuCdFromTextBox.Size = new System.Drawing.Size(60, 27);
            this.chikuCdFromTextBox.TabIndex = 6;
            this.chikuCdFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chikuCdFromTextBox.Leave += new System.EventHandler(this.chikuCdFromTextBox_Leave);
            // 
            // gyoshaCdToTextBox
            // 
            this.gyoshaCdToTextBox.AllowDropDown = false;
            this.gyoshaCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.gyoshaCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaCdToTextBox.CustomReadOnly = false;
            this.gyoshaCdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyoshaCdToTextBox.Location = new System.Drawing.Point(173, 101);
            this.gyoshaCdToTextBox.MaxLength = 4;
            this.gyoshaCdToTextBox.Name = "gyoshaCdToTextBox";
            this.gyoshaCdToTextBox.Size = new System.Drawing.Size(47, 27);
            this.gyoshaCdToTextBox.TabIndex = 12;
            this.gyoshaCdToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gyoshaCdToTextBox.Leave += new System.EventHandler(this.gyoshaCdToTextBox_Leave);
            // 
            // gyoshaCdFromTextBox
            // 
            this.gyoshaCdFromTextBox.AllowDropDown = false;
            this.gyoshaCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.gyoshaCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaCdFromTextBox.CustomReadOnly = false;
            this.gyoshaCdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyoshaCdFromTextBox.Location = new System.Drawing.Point(92, 101);
            this.gyoshaCdFromTextBox.MaxLength = 4;
            this.gyoshaCdFromTextBox.Name = "gyoshaCdFromTextBox";
            this.gyoshaCdFromTextBox.Size = new System.Drawing.Size(47, 27);
            this.gyoshaCdFromTextBox.TabIndex = 10;
            this.gyoshaCdFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gyoshaCdFromTextBox.Leave += new System.EventHandler(this.gyoshaCdFromTextBox_Leave);
            // 
            // kensaNendoTextBox
            // 
            this.kensaNendoTextBox.AllowDropDown = false;
            this.kensaNendoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.kensaNendoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaNendoTextBox.CustomReadOnly = false;
            this.kensaNendoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kensaNendoTextBox.Location = new System.Drawing.Point(92, 35);
            this.kensaNendoTextBox.MaxLength = 4;
            this.kensaNendoTextBox.Name = "kensaNendoTextBox";
            this.kensaNendoTextBox.Size = new System.Drawing.Size(47, 27);
            this.kensaNendoTextBox.TabIndex = 3;
            this.kensaNendoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(68, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "*";
            // 
            // sakuhyoKbn2GroupBox
            // 
            this.sakuhyoKbn2GroupBox.Controls.Add(this.sakuhyoKbn23RadioButton);
            this.sakuhyoKbn2GroupBox.Controls.Add(this.sakuhyoKbn22RadioButton);
            this.sakuhyoKbn2GroupBox.Controls.Add(this.sakuhyoKbn21RadioButton);
            this.sakuhyoKbn2GroupBox.Location = new System.Drawing.Point(481, 31);
            this.sakuhyoKbn2GroupBox.Name = "sakuhyoKbn2GroupBox";
            this.sakuhyoKbn2GroupBox.Size = new System.Drawing.Size(182, 107);
            this.sakuhyoKbn2GroupBox.TabIndex = 14;
            this.sakuhyoKbn2GroupBox.TabStop = false;
            this.sakuhyoKbn2GroupBox.Text = "作表区分２（近年検査分）";
            // 
            // sakuhyoKbn23RadioButton
            // 
            this.sakuhyoKbn23RadioButton.AutoSize = true;
            this.sakuhyoKbn23RadioButton.Checked = true;
            this.sakuhyoKbn23RadioButton.Location = new System.Drawing.Point(17, 76);
            this.sakuhyoKbn23RadioButton.Name = "sakuhyoKbn23RadioButton";
            this.sakuhyoKbn23RadioButton.Size = new System.Drawing.Size(66, 24);
            this.sakuhyoKbn23RadioButton.TabIndex = 2;
            this.sakuhyoKbn23RadioButton.TabStop = true;
            this.sakuhyoKbn23RadioButton.Text = "すべて";
            this.sakuhyoKbn23RadioButton.UseVisualStyleBackColor = true;
            // 
            // sakuhyoKbn22RadioButton
            // 
            this.sakuhyoKbn22RadioButton.AutoSize = true;
            this.sakuhyoKbn22RadioButton.Location = new System.Drawing.Point(17, 50);
            this.sakuhyoKbn22RadioButton.Name = "sakuhyoKbn22RadioButton";
            this.sakuhyoKbn22RadioButton.Size = new System.Drawing.Size(157, 24);
            this.sakuhyoKbn22RadioButton.TabIndex = 1;
            this.sakuhyoKbn22RadioButton.Text = "その他（７条、水質）";
            this.sakuhyoKbn22RadioButton.UseVisualStyleBackColor = true;
            // 
            // sakuhyoKbn21RadioButton
            // 
            this.sakuhyoKbn21RadioButton.AutoSize = true;
            this.sakuhyoKbn21RadioButton.Location = new System.Drawing.Point(17, 23);
            this.sakuhyoKbn21RadioButton.Name = "sakuhyoKbn21RadioButton";
            this.sakuhyoKbn21RadioButton.Size = new System.Drawing.Size(118, 24);
            this.sakuhyoKbn21RadioButton.TabIndex = 0;
            this.sakuhyoKbn21RadioButton.Text = "近年検査実施分";
            this.sakuhyoKbn21RadioButton.UseVisualStyleBackColor = true;
            // 
            // sakuhyoKbn1GroupBox
            // 
            this.sakuhyoKbn1GroupBox.Controls.Add(this.sakuhyoKbn13RadioButton);
            this.sakuhyoKbn1GroupBox.Controls.Add(this.sakuhyoKbn12RadioButton);
            this.sakuhyoKbn1GroupBox.Controls.Add(this.sakuhyoKbn11RadioButton);
            this.sakuhyoKbn1GroupBox.Location = new System.Drawing.Point(285, 31);
            this.sakuhyoKbn1GroupBox.Name = "sakuhyoKbn1GroupBox";
            this.sakuhyoKbn1GroupBox.Size = new System.Drawing.Size(168, 107);
            this.sakuhyoKbn1GroupBox.TabIndex = 13;
            this.sakuhyoKbn1GroupBox.TabStop = false;
            this.sakuhyoKbn1GroupBox.Text = "作表区分１（人槽）";
            // 
            // sakuhyoKbn13RadioButton
            // 
            this.sakuhyoKbn13RadioButton.AutoSize = true;
            this.sakuhyoKbn13RadioButton.Checked = true;
            this.sakuhyoKbn13RadioButton.Location = new System.Drawing.Point(16, 77);
            this.sakuhyoKbn13RadioButton.Name = "sakuhyoKbn13RadioButton";
            this.sakuhyoKbn13RadioButton.Size = new System.Drawing.Size(66, 24);
            this.sakuhyoKbn13RadioButton.TabIndex = 2;
            this.sakuhyoKbn13RadioButton.TabStop = true;
            this.sakuhyoKbn13RadioButton.Text = "すべて";
            this.sakuhyoKbn13RadioButton.UseVisualStyleBackColor = true;
            // 
            // sakuhyoKbn12RadioButton
            // 
            this.sakuhyoKbn12RadioButton.AutoSize = true;
            this.sakuhyoKbn12RadioButton.Location = new System.Drawing.Point(16, 50);
            this.sakuhyoKbn12RadioButton.Name = "sakuhyoKbn12RadioButton";
            this.sakuhyoKbn12RadioButton.Size = new System.Drawing.Size(82, 24);
            this.sakuhyoKbn12RadioButton.TabIndex = 1;
            this.sakuhyoKbn12RadioButton.Text = "51人以上";
            this.sakuhyoKbn12RadioButton.UseVisualStyleBackColor = true;
            // 
            // sakuhyoKbn11RadioButton
            // 
            this.sakuhyoKbn11RadioButton.AutoSize = true;
            this.sakuhyoKbn11RadioButton.Location = new System.Drawing.Point(16, 23);
            this.sakuhyoKbn11RadioButton.Name = "sakuhyoKbn11RadioButton";
            this.sakuhyoKbn11RadioButton.Size = new System.Drawing.Size(82, 24);
            this.sakuhyoKbn11RadioButton.TabIndex = 0;
            this.sakuhyoKbn11RadioButton.Text = "50人以下";
            this.sakuhyoKbn11RadioButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(145, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "～";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "業者コード";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "地区コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(145, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "例) 2000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "指定年度";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 17;
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
            this.clearButton.Location = new System.Drawing.Point(884, 101);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 15;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 101);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 16;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(742, 555);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(115, 37);
            this.printButton.TabIndex = 2;
            this.printButton.Text = "F1:依頼書印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // JinendoGaikanKensaYoteiListOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.jinendoGaikanKensaYoteiListOutputPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "JinendoGaikanKensaYoteiListOutputForm";
            this.Text = "次年度外観検査予定一覧表出力";
            this.Load += new System.EventHandler(this.JinendoGaikanKensaYoteiListOutputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JinendoGaikanKensaYoteiListOutputForm_KeyDown);
            this.jinendoGaikanKensaYoteiListOutputPanel.ResumeLayout(false);
            this.jinendoGaikanKensaYoteiListOutputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jinendoGaikanKensaYoteiListOutputDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zenkaiKensaDataWrkDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zenkaiKensaDataWrkDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.sakuhyoKbn3GroupBox.ResumeLayout(false);
            this.sakuhyoKbn3GroupBox.PerformLayout();
            this.sakuhyoKbn2GroupBox.ResumeLayout(false);
            this.sakuhyoKbn2GroupBox.PerformLayout();
            this.sakuhyoKbn1GroupBox.ResumeLayout(false);
            this.sakuhyoKbn1GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Panel jinendoGaikanKensaYoteiListOutputPanel;
        private System.Windows.Forms.Label jinendoGaikanKensaYoteiListOutputCountLabel;
        private System.Windows.Forms.DataGridView jinendoGaikanKensaYoteiListOutputDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox sakuhyoKbn2GroupBox;
        private System.Windows.Forms.GroupBox sakuhyoKbn1GroupBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton sakuhyoKbn23RadioButton;
        private System.Windows.Forms.RadioButton sakuhyoKbn22RadioButton;
        private System.Windows.Forms.RadioButton sakuhyoKbn21RadioButton;
        private System.Windows.Forms.RadioButton sakuhyoKbn13RadioButton;
        private System.Windows.Forms.RadioButton sakuhyoKbn12RadioButton;
        private System.Windows.Forms.RadioButton sakuhyoKbn11RadioButton;
        private System.Windows.Forms.Label label7;
        private ZTextBox kensaNendoTextBox;
        private ZTextBox chikuCdToTextBox;
        private ZTextBox chikuCdFromTextBox;
        private ZTextBox gyoshaCdFromTextBox;
        private ZTextBox gyoshaCdToTextBox;
        private System.Windows.Forms.BindingSource zenkaiKensaDataWrkDataSetBindingSource;
        private DataSet.ZenkaiKensaDataWrkDataSet zenkaiKensaDataWrkDataSet;
        private System.Windows.Forms.GroupBox sakuhyoKbn3GroupBox;
        private System.Windows.Forms.RadioButton sakuhyoKbn33RadioButton;
        private System.Windows.Forms.RadioButton sakuhyoKbn32RadioButton;
        private System.Windows.Forms.RadioButton sakuhyoKbn31RadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn outputKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sakuhyoKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn chikuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiSetchishaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiSetchibashoAdrCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShoritaishoJininCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoSetchishaKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoSetchishaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sakuhyoKbnColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaDtColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaKbnColDataGridViewTextBoxColumn;

    }
}