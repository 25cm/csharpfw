namespace FukjBizSystem.Application.Boundary.Others
{
    partial class KensaJokyoListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.jokyoListDataGridView = new System.Windows.Forms.DataGridView();
            this.KbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettisyaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShisetsuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaUketsukeDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanteiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoSetchishaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoShisetsuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaUketsukeDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hanteiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiTblDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kensaIraiTblDataSet = new FukjBizSystem.Application.DataSet.KensaIraiTblDataSet();
            this.jokyoListPanel = new System.Windows.Forms.Panel();
            this.jokyoListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.settisyaTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.settisyaCdTextBox = new System.Windows.Forms.TextBox();
            this.jokasoSrhButton = new System.Windows.Forms.Button();
            this.kensaKeiryoSyomeiCheckBox = new System.Windows.Forms.CheckBox();
            this.kensa11JoSuiShitsuCheckBox = new System.Windows.Forms.CheckBox();
            this.kensa11JoGaikanCheckBox = new System.Windows.Forms.CheckBox();
            this.kensa7JoCheckBox = new System.Windows.Forms.CheckBox();
            this.kensaDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.kensaDtToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.kensaDtFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.shisetsuNmTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kensaIraiDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.kensaIraiDtToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.kensaIraiDtFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.jokyoListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSet)).BeginInit();
            this.jokyoListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // jokyoListDataGridView
            // 
            this.jokyoListDataGridView.AllowUserToAddRows = false;
            this.jokyoListDataGridView.AllowUserToDeleteRows = false;
            this.jokyoListDataGridView.AllowUserToResizeRows = false;
            this.jokyoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jokyoListDataGridView.AutoGenerateColumns = false;
            this.jokyoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jokyoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KbnCol,
            this.JokasoCdCol,
            this.SettisyaNmCol,
            this.ShisetsuNmCol,
            this.KensaIraiCdCol,
            this.KensaIraiDtCol,
            this.KensaUketsukeDtCol,
            this.KensaDtCol,
            this.HanteiCol,
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn,
            this.constNmDataGridViewTextBoxColumn,
            this.jokasoCdDataGridViewTextBoxColumn,
            this.jokasoSetchishaNmDataGridViewTextBoxColumn,
            this.jokasoShisetsuNmDataGridViewTextBoxColumn,
            this.kensaIraiDtDataGridViewTextBoxColumn,
            this.kensaDtDataGridViewTextBoxColumn,
            this.kensaUketsukeDtDataGridViewTextBoxColumn,
            this.hanteiDataGridViewTextBoxColumn});
            this.jokyoListDataGridView.DataMember = "KensaJokyoList";
            this.jokyoListDataGridView.DataSource = this.kensaIraiTblDataSetBindingSource;
            this.jokyoListDataGridView.Location = new System.Drawing.Point(2, 23);
            this.jokyoListDataGridView.MultiSelect = false;
            this.jokyoListDataGridView.Name = "jokyoListDataGridView";
            this.jokyoListDataGridView.ReadOnly = true;
            this.jokyoListDataGridView.RowHeadersVisible = false;
            this.jokyoListDataGridView.RowTemplate.Height = 21;
            this.jokyoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jokyoListDataGridView.Size = new System.Drawing.Size(1085, 329);
            this.jokyoListDataGridView.TabIndex = 21;
            // 
            // KbnCol
            // 
            this.KbnCol.DataPropertyName = "ConstNm";
            this.KbnCol.HeaderText = "区分";
            this.KbnCol.MinimumWidth = 70;
            this.KbnCol.Name = "KbnCol";
            this.KbnCol.ReadOnly = true;
            this.KbnCol.Width = 70;
            // 
            // JokasoCdCol
            // 
            this.JokasoCdCol.DataPropertyName = "JokasoCd";
            this.JokasoCdCol.HeaderText = "浄化槽番号";
            this.JokasoCdCol.MinimumWidth = 120;
            this.JokasoCdCol.Name = "JokasoCdCol";
            this.JokasoCdCol.ReadOnly = true;
            this.JokasoCdCol.Width = 120;
            // 
            // SettisyaNmCol
            // 
            this.SettisyaNmCol.DataPropertyName = "JokasoSetchishaNm";
            this.SettisyaNmCol.HeaderText = "設置者名";
            this.SettisyaNmCol.MinimumWidth = 180;
            this.SettisyaNmCol.Name = "SettisyaNmCol";
            this.SettisyaNmCol.ReadOnly = true;
            this.SettisyaNmCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SettisyaNmCol.Width = 180;
            // 
            // ShisetsuNmCol
            // 
            this.ShisetsuNmCol.DataPropertyName = "JokasoShisetsuNm";
            this.ShisetsuNmCol.HeaderText = "施設名";
            this.ShisetsuNmCol.MinimumWidth = 180;
            this.ShisetsuNmCol.Name = "ShisetsuNmCol";
            this.ShisetsuNmCol.ReadOnly = true;
            this.ShisetsuNmCol.Width = 180;
            // 
            // KensaIraiCdCol
            // 
            this.KensaIraiCdCol.DataPropertyName = "KensaIraiCd";
            this.KensaIraiCdCol.HeaderText = "検査番号";
            this.KensaIraiCdCol.MinimumWidth = 120;
            this.KensaIraiCdCol.Name = "KensaIraiCdCol";
            this.KensaIraiCdCol.ReadOnly = true;
            this.KensaIraiCdCol.Width = 120;
            // 
            // KensaIraiDtCol
            // 
            this.KensaIraiDtCol.DataPropertyName = "KensaIraiDt";
            this.KensaIraiDtCol.HeaderText = "検査依頼日";
            this.KensaIraiDtCol.MinimumWidth = 100;
            this.KensaIraiDtCol.Name = "KensaIraiDtCol";
            this.KensaIraiDtCol.ReadOnly = true;
            // 
            // KensaUketsukeDtCol
            // 
            this.KensaUketsukeDtCol.DataPropertyName = "KensaUketsukeDt";
            this.KensaUketsukeDtCol.HeaderText = "検査受付日";
            this.KensaUketsukeDtCol.MinimumWidth = 100;
            this.KensaUketsukeDtCol.Name = "KensaUketsukeDtCol";
            this.KensaUketsukeDtCol.ReadOnly = true;
            // 
            // KensaDtCol
            // 
            this.KensaDtCol.DataPropertyName = "KensaDt";
            this.KensaDtCol.HeaderText = "検査日";
            this.KensaDtCol.MinimumWidth = 100;
            this.KensaDtCol.Name = "KensaDtCol";
            this.KensaDtCol.ReadOnly = true;
            // 
            // HanteiCol
            // 
            this.HanteiCol.DataPropertyName = "Hantei";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HanteiCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.HanteiCol.HeaderText = "検査結果";
            this.HanteiCol.MinimumWidth = 90;
            this.HanteiCol.Name = "HanteiCol";
            this.HanteiCol.ReadOnly = true;
            this.HanteiCol.Width = 90;
            // 
            // kensaIraiHoteiKbnDataGridViewTextBoxColumn
            // 
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiHoteiKbn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.HeaderText = "KensaIraiHoteiKbn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.Name = "kensaIraiHoteiKbnDataGridViewTextBoxColumn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // constNmDataGridViewTextBoxColumn
            // 
            this.constNmDataGridViewTextBoxColumn.DataPropertyName = "ConstNm";
            this.constNmDataGridViewTextBoxColumn.HeaderText = "ConstNm";
            this.constNmDataGridViewTextBoxColumn.Name = "constNmDataGridViewTextBoxColumn";
            this.constNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.constNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoCdDataGridViewTextBoxColumn
            // 
            this.jokasoCdDataGridViewTextBoxColumn.DataPropertyName = "JokasoCd";
            this.jokasoCdDataGridViewTextBoxColumn.HeaderText = "JokasoCd";
            this.jokasoCdDataGridViewTextBoxColumn.Name = "jokasoCdDataGridViewTextBoxColumn";
            this.jokasoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoSetchishaNmDataGridViewTextBoxColumn
            // 
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.DataPropertyName = "JokasoSetchishaNm";
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.HeaderText = "JokasoSetchishaNm";
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.Name = "jokasoSetchishaNmDataGridViewTextBoxColumn";
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoShisetsuNmDataGridViewTextBoxColumn
            // 
            this.jokasoShisetsuNmDataGridViewTextBoxColumn.DataPropertyName = "JokasoShisetsuNm";
            this.jokasoShisetsuNmDataGridViewTextBoxColumn.HeaderText = "JokasoShisetsuNm";
            this.jokasoShisetsuNmDataGridViewTextBoxColumn.Name = "jokasoShisetsuNmDataGridViewTextBoxColumn";
            this.jokasoShisetsuNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoShisetsuNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiDtDataGridViewTextBoxColumn
            // 
            this.kensaIraiDtDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiDt";
            this.kensaIraiDtDataGridViewTextBoxColumn.HeaderText = "KensaIraiDt";
            this.kensaIraiDtDataGridViewTextBoxColumn.Name = "kensaIraiDtDataGridViewTextBoxColumn";
            this.kensaIraiDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaDtDataGridViewTextBoxColumn
            // 
            this.kensaDtDataGridViewTextBoxColumn.DataPropertyName = "KensaDt";
            this.kensaDtDataGridViewTextBoxColumn.HeaderText = "KensaDt";
            this.kensaDtDataGridViewTextBoxColumn.Name = "kensaDtDataGridViewTextBoxColumn";
            this.kensaDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaUketsukeDtDataGridViewTextBoxColumn
            // 
            this.kensaUketsukeDtDataGridViewTextBoxColumn.DataPropertyName = "KensaUketsukeDt";
            this.kensaUketsukeDtDataGridViewTextBoxColumn.HeaderText = "KensaUketsukeDt";
            this.kensaUketsukeDtDataGridViewTextBoxColumn.Name = "kensaUketsukeDtDataGridViewTextBoxColumn";
            this.kensaUketsukeDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaUketsukeDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // hanteiDataGridViewTextBoxColumn
            // 
            this.hanteiDataGridViewTextBoxColumn.DataPropertyName = "Hantei";
            this.hanteiDataGridViewTextBoxColumn.HeaderText = "Hantei";
            this.hanteiDataGridViewTextBoxColumn.Name = "hanteiDataGridViewTextBoxColumn";
            this.hanteiDataGridViewTextBoxColumn.ReadOnly = true;
            this.hanteiDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiTblDataSetBindingSource
            // 
            this.kensaIraiTblDataSetBindingSource.DataSource = this.kensaIraiTblDataSet;
            this.kensaIraiTblDataSetBindingSource.Position = 0;
            // 
            // kensaIraiTblDataSet
            // 
            this.kensaIraiTblDataSet.DataSetName = "KensaIraiTblDataSet";
            this.kensaIraiTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jokyoListPanel
            // 
            this.jokyoListPanel.Controls.Add(this.jokyoListCountLabel);
            this.jokyoListPanel.Controls.Add(this.label4);
            this.jokyoListPanel.Controls.Add(this.jokyoListDataGridView);
            this.jokyoListPanel.Location = new System.Drawing.Point(1, 183);
            this.jokyoListPanel.Name = "jokyoListPanel";
            this.jokyoListPanel.Size = new System.Drawing.Size(1090, 355);
            this.jokyoListPanel.TabIndex = 2;
            // 
            // jokyoListCountLabel
            // 
            this.jokyoListCountLabel.AutoSize = true;
            this.jokyoListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.jokyoListCountLabel.Name = "jokyoListCountLabel";
            this.jokyoListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.jokyoListCountLabel.TabIndex = 2;
            this.jokyoListCountLabel.Text = "0件";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "検査区分";
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(854, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 3;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // settisyaTextBox
            // 
            this.settisyaTextBox.Location = new System.Drawing.Point(108, 66);
            this.settisyaTextBox.MaxLength = 60;
            this.settisyaTextBox.Name = "settisyaTextBox";
            this.settisyaTextBox.Size = new System.Drawing.Size(305, 27);
            this.settisyaTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "設置者";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 20;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.label9);
            this.searchPanel.Controls.Add(this.settisyaCdTextBox);
            this.searchPanel.Controls.Add(this.jokasoSrhButton);
            this.searchPanel.Controls.Add(this.kensaKeiryoSyomeiCheckBox);
            this.searchPanel.Controls.Add(this.kensa11JoSuiShitsuCheckBox);
            this.searchPanel.Controls.Add(this.kensa11JoGaikanCheckBox);
            this.searchPanel.Controls.Add(this.kensa7JoCheckBox);
            this.searchPanel.Controls.Add(this.kensaDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label10);
            this.searchPanel.Controls.Add(this.kensaDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.label11);
            this.searchPanel.Controls.Add(this.kensaDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.shisetsuNmTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.kensaIraiDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.kensaIraiDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.kensaIraiDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.settisyaTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 180);
            this.searchPanel.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(259, 20);
            this.label9.TabIndex = 191;
            this.label9.Text = "※11条水質検査、計量証明の場合は受付日";
            // 
            // settisyaCdTextBox
            // 
            this.settisyaCdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.settisyaCdTextBox.Location = new System.Drawing.Point(809, 66);
            this.settisyaCdTextBox.Name = "settisyaCdTextBox";
            this.settisyaCdTextBox.ReadOnly = true;
            this.settisyaCdTextBox.Size = new System.Drawing.Size(100, 27);
            this.settisyaCdTextBox.TabIndex = 10;
            this.settisyaCdTextBox.TabStop = false;
            // 
            // jokasoSrhButton
            // 
            this.jokasoSrhButton.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.jokasoSrhButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.jokasoSrhButton.Location = new System.Drawing.Point(915, 66);
            this.jokasoSrhButton.Name = "jokasoSrhButton";
            this.jokasoSrhButton.Size = new System.Drawing.Size(29, 26);
            this.jokasoSrhButton.TabIndex = 11;
            this.jokasoSrhButton.UseVisualStyleBackColor = true;
            this.jokasoSrhButton.Click += new System.EventHandler(this.jokasoSrhButton_Click);
            // 
            // kensaKeiryoSyomeiCheckBox
            // 
            this.kensaKeiryoSyomeiCheckBox.AutoSize = true;
            this.kensaKeiryoSyomeiCheckBox.Checked = true;
            this.kensaKeiryoSyomeiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensaKeiryoSyomeiCheckBox.Location = new System.Drawing.Point(368, 37);
            this.kensaKeiryoSyomeiCheckBox.Name = "kensaKeiryoSyomeiCheckBox";
            this.kensaKeiryoSyomeiCheckBox.Size = new System.Drawing.Size(80, 24);
            this.kensaKeiryoSyomeiCheckBox.TabIndex = 5;
            this.kensaKeiryoSyomeiCheckBox.Text = "計量証明";
            this.kensaKeiryoSyomeiCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensa11JoSuiShitsuCheckBox
            // 
            this.kensa11JoSuiShitsuCheckBox.AutoSize = true;
            this.kensa11JoSuiShitsuCheckBox.Checked = true;
            this.kensa11JoSuiShitsuCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensa11JoSuiShitsuCheckBox.Location = new System.Drawing.Point(279, 37);
            this.kensa11JoSuiShitsuCheckBox.Name = "kensa11JoSuiShitsuCheckBox";
            this.kensa11JoSuiShitsuCheckBox.Size = new System.Drawing.Size(83, 24);
            this.kensa11JoSuiShitsuCheckBox.TabIndex = 4;
            this.kensa11JoSuiShitsuCheckBox.Text = "11条水質";
            this.kensa11JoSuiShitsuCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensa11JoGaikanCheckBox
            // 
            this.kensa11JoGaikanCheckBox.AutoSize = true;
            this.kensa11JoGaikanCheckBox.Checked = true;
            this.kensa11JoGaikanCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensa11JoGaikanCheckBox.Location = new System.Drawing.Point(190, 37);
            this.kensa11JoGaikanCheckBox.Name = "kensa11JoGaikanCheckBox";
            this.kensa11JoGaikanCheckBox.Size = new System.Drawing.Size(83, 24);
            this.kensa11JoGaikanCheckBox.TabIndex = 3;
            this.kensa11JoGaikanCheckBox.Text = "11条外観";
            this.kensa11JoGaikanCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensa7JoCheckBox
            // 
            this.kensa7JoCheckBox.AutoSize = true;
            this.kensa7JoCheckBox.Checked = true;
            this.kensa7JoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensa7JoCheckBox.Location = new System.Drawing.Point(109, 37);
            this.kensa7JoCheckBox.Name = "kensa7JoCheckBox";
            this.kensa7JoCheckBox.Size = new System.Drawing.Size(75, 24);
            this.kensa7JoCheckBox.TabIndex = 2;
            this.kensa7JoCheckBox.Text = "7条検査";
            this.kensa7JoCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensaDtUseCheckBox
            // 
            this.kensaDtUseCheckBox.AutoSize = true;
            this.kensaDtUseCheckBox.Enabled = false;
            this.kensaDtUseCheckBox.Location = new System.Drawing.Point(12, 139);
            this.kensaDtUseCheckBox.Name = "kensaDtUseCheckBox";
            this.kensaDtUseCheckBox.Size = new System.Drawing.Size(15, 14);
            this.kensaDtUseCheckBox.TabIndex = 15;
            this.kensaDtUseCheckBox.UseVisualStyleBackColor = true;
            this.kensaDtUseCheckBox.Visible = false;
            this.kensaDtUseCheckBox.Click += new System.EventHandler(this.kensaDtUseCheckBox_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(260, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 20);
            this.label10.TabIndex = 159;
            this.label10.Text = "～";
            this.label10.Visible = false;
            // 
            // kensaDtToDateTimePicker
            // 
            this.kensaDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kensaDtToDateTimePicker.Enabled = false;
            this.kensaDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kensaDtToDateTimePicker.Location = new System.Drawing.Point(288, 132);
            this.kensaDtToDateTimePicker.Name = "kensaDtToDateTimePicker";
            this.kensaDtToDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.kensaDtToDateTimePicker.TabIndex = 17;
            this.kensaDtToDateTimePicker.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 157;
            this.label11.Text = "検査日";
            this.label11.Visible = false;
            // 
            // kensaDtFromDateTimePicker
            // 
            this.kensaDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kensaDtFromDateTimePicker.Enabled = false;
            this.kensaDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kensaDtFromDateTimePicker.Location = new System.Drawing.Point(109, 132);
            this.kensaDtFromDateTimePicker.Name = "kensaDtFromDateTimePicker";
            this.kensaDtFromDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.kensaDtFromDateTimePicker.TabIndex = 16;
            this.kensaDtFromDateTimePicker.Visible = false;
            // 
            // shisetsuNmTextBox
            // 
            this.shisetsuNmTextBox.Location = new System.Drawing.Point(498, 66);
            this.shisetsuNmTextBox.MaxLength = 60;
            this.shisetsuNmTextBox.Name = "shisetsuNmTextBox";
            this.shisetsuNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.shisetsuNmTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "施設名称";
            // 
            // kensaIraiDtUseCheckBox
            // 
            this.kensaIraiDtUseCheckBox.AutoSize = true;
            this.kensaIraiDtUseCheckBox.Checked = true;
            this.kensaIraiDtUseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kensaIraiDtUseCheckBox.Enabled = false;
            this.kensaIraiDtUseCheckBox.Location = new System.Drawing.Point(12, 106);
            this.kensaIraiDtUseCheckBox.Name = "kensaIraiDtUseCheckBox";
            this.kensaIraiDtUseCheckBox.Size = new System.Drawing.Size(15, 14);
            this.kensaIraiDtUseCheckBox.TabIndex = 12;
            this.kensaIraiDtUseCheckBox.UseVisualStyleBackColor = true;
            this.kensaIraiDtUseCheckBox.Visible = false;
            this.kensaIraiDtUseCheckBox.Click += new System.EventHandler(this.kensaIraiDtUseCheckBox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 90;
            this.label7.Text = "～";
            // 
            // kensaIraiDtToDateTimePicker
            // 
            this.kensaIraiDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kensaIraiDtToDateTimePicker.Enabled = false;
            this.kensaIraiDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kensaIraiDtToDateTimePicker.Location = new System.Drawing.Point(288, 99);
            this.kensaIraiDtToDateTimePicker.Name = "kensaIraiDtToDateTimePicker";
            this.kensaIraiDtToDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.kensaIraiDtToDateTimePicker.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 88;
            this.label5.Text = "検査日";
            // 
            // kensaIraiDtFromDateTimePicker
            // 
            this.kensaIraiDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kensaIraiDtFromDateTimePicker.Enabled = false;
            this.kensaIraiDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kensaIraiDtFromDateTimePicker.Location = new System.Drawing.Point(109, 99);
            this.kensaIraiDtFromDateTimePicker.Name = "kensaIraiDtFromDateTimePicker";
            this.kensaIraiDtFromDateTimePicker.Size = new System.Drawing.Size(145, 27);
            this.kensaIraiDtFromDateTimePicker.TabIndex = 13;
            this.kensaIraiDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.kensaIraiDtFromDateTimePicker_ValueChanged);
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
            this.clearButton.TabIndex = 18;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(985, 132);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 19;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(990, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 4;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // KensaJokyoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.jokyoListPanel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KensaJokyoListForm";
            this.Text = "検査状況一覧";
            this.Load += new System.EventHandler(this.KensaJokyoListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaJokyoListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.jokyoListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSet)).EndInit();
            this.jokyoListPanel.ResumeLayout(false);
            this.jokyoListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView jokyoListDataGridView;
        private System.Windows.Forms.Panel jokyoListPanel;
        private System.Windows.Forms.Label jokyoListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.TextBox settisyaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.CheckBox kensaIraiDtUseCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker kensaIraiDtToDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker kensaIraiDtFromDateTimePicker;
        private System.Windows.Forms.CheckBox kensaDtUseCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker kensaDtToDateTimePicker;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker kensaDtFromDateTimePicker;
        private System.Windows.Forms.TextBox shisetsuNmTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox kensaKeiryoSyomeiCheckBox;
        private System.Windows.Forms.CheckBox kensa11JoSuiShitsuCheckBox;
        private System.Windows.Forms.CheckBox kensa11JoGaikanCheckBox;
        private System.Windows.Forms.CheckBox kensa7JoCheckBox;
        private System.Windows.Forms.Button jokasoSrhButton;
        private System.Windows.Forms.TextBox settisyaCdTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource kensaIraiTblDataSetBindingSource;
        private DataSet.KensaIraiTblDataSet kensaIraiTblDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn KbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettisyaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShisetsuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaUketsukeDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanteiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHoteiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn constNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoSetchishaNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoShisetsuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaUketsukeDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanteiDataGridViewTextBoxColumn;

    }
}