namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class UriageListForm
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
            this.outputButton = new System.Windows.Forms.Button();
            this.UriageListDataGridView = new System.Windows.Forms.DataGridView();
            this.ShisyoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShisyoNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UriageKamoku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyohinNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UriageDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UriageCntCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UriageGakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.UriageListPanel = new System.Windows.Forms.Panel();
            this.nameListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.NenkaihiCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.YoshiHanbaiCheckBox = new System.Windows.Forms.CheckBox();
            this.Kensa7JoCheckBox = new System.Windows.Forms.CheckBox();
            this.KeiryoSyomeiCheckBox = new System.Windows.Forms.CheckBox();
            this.Kensa11JoCheckBox = new System.Windows.Forms.CheckBox();
            this.ShisyoNmComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SrhDtToTextBox = new Zynas.Control.ZDate(this.components);
            this.SrhDtFromTextBox = new Zynas.Control.ZDate(this.components);
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UriageListDataGridView)).BeginInit();
            this.UriageListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // UriageListDataGridView
            // 
            this.UriageListDataGridView.AllowUserToAddRows = false;
            this.UriageListDataGridView.AllowUserToResizeRows = false;
            this.UriageListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UriageListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UriageListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShisyoCdCol,
            this.ShisyoNameCol,
            this.UriageKamoku,
            this.SyohinNmCol,
            this.UriageDtCol,
            this.UriageCntCol,
            this.UriageGakuCol});
            this.UriageListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.UriageListDataGridView.MultiSelect = false;
            this.UriageListDataGridView.Name = "UriageListDataGridView";
            this.UriageListDataGridView.RowHeadersVisible = false;
            this.UriageListDataGridView.RowTemplate.Height = 21;
            this.UriageListDataGridView.Size = new System.Drawing.Size(1095, 377);
            this.UriageListDataGridView.TabIndex = 2;
            // 
            // ShisyoCdCol
            // 
            this.ShisyoCdCol.HeaderText = "支所コード";
            this.ShisyoCdCol.MinimumWidth = 100;
            this.ShisyoCdCol.Name = "ShisyoCdCol";
            this.ShisyoCdCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShisyoCdCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ShisyoNameCol
            // 
            this.ShisyoNameCol.HeaderText = "支所名称";
            this.ShisyoNameCol.MinimumWidth = 150;
            this.ShisyoNameCol.Name = "ShisyoNameCol";
            this.ShisyoNameCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShisyoNameCol.Width = 150;
            // 
            // UriageKamoku
            // 
            this.UriageKamoku.HeaderText = "売上科目";
            this.UriageKamoku.MinimumWidth = 200;
            this.UriageKamoku.Name = "UriageKamoku";
            this.UriageKamoku.Width = 200;
            // 
            // SyohinNmCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SyohinNmCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.SyohinNmCol.HeaderText = "商品名";
            this.SyohinNmCol.MinimumWidth = 250;
            this.SyohinNmCol.Name = "SyohinNmCol";
            this.SyohinNmCol.Width = 250;
            // 
            // UriageDtCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UriageDtCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.UriageDtCol.HeaderText = "売上日";
            this.UriageDtCol.MinimumWidth = 100;
            this.UriageDtCol.Name = "UriageDtCol";
            // 
            // UriageCntCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UriageCntCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.UriageCntCol.HeaderText = "売上数";
            this.UriageCntCol.MinimumWidth = 100;
            this.UriageCntCol.Name = "UriageCntCol";
            // 
            // UriageGakuCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UriageGakuCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.UriageGakuCol.HeaderText = "売上金額";
            this.UriageGakuCol.MinimumWidth = 100;
            this.UriageGakuCol.Name = "UriageGakuCol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // UriageListPanel
            // 
            this.UriageListPanel.Controls.Add(this.nameListCountLabel);
            this.UriageListPanel.Controls.Add(this.label4);
            this.UriageListPanel.Controls.Add(this.UriageListDataGridView);
            this.UriageListPanel.Location = new System.Drawing.Point(0, 134);
            this.UriageListPanel.Name = "UriageListPanel";
            this.UriageListPanel.Size = new System.Drawing.Size(1100, 404);
            this.UriageListPanel.TabIndex = 12;
            // 
            // nameListCountLabel
            // 
            this.nameListCountLabel.AutoSize = true;
            this.nameListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.nameListCountLabel.Name = "nameListCountLabel";
            this.nameListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.nameListCountLabel.TabIndex = 1;
            this.nameListCountLabel.Text = "0件";
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
            this.searchPanel.Controls.Add(this.panel1);
            this.searchPanel.Controls.Add(this.NenkaihiCheckBox);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.YoshiHanbaiCheckBox);
            this.searchPanel.Controls.Add(this.Kensa7JoCheckBox);
            this.searchPanel.Controls.Add(this.KeiryoSyomeiCheckBox);
            this.searchPanel.Controls.Add(this.Kensa11JoCheckBox);
            this.searchPanel.Controls.Add(this.ShisyoNmComboBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.SrhDtToTextBox);
            this.searchPanel.Controls.Add(this.SrhDtFromTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1100, 126);
            this.searchPanel.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(725, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 50);
            this.panel1.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(13, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 41);
            this.label3.TabIndex = 0;
            this.label3.Text = "MockUp";
            // 
            // NenkaihiCheckBox
            // 
            this.NenkaihiCheckBox.AutoSize = true;
            this.NenkaihiCheckBox.Checked = true;
            this.NenkaihiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NenkaihiCheckBox.Location = new System.Drawing.Point(450, 65);
            this.NenkaihiCheckBox.Name = "NenkaihiCheckBox";
            this.NenkaihiCheckBox.Size = new System.Drawing.Size(67, 24);
            this.NenkaihiCheckBox.TabIndex = 83;
            this.NenkaihiCheckBox.Text = "年会費";
            this.NenkaihiCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 82;
            this.label6.Text = "売上区分";
            // 
            // YoshiHanbaiCheckBox
            // 
            this.YoshiHanbaiCheckBox.AutoSize = true;
            this.YoshiHanbaiCheckBox.Checked = true;
            this.YoshiHanbaiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.YoshiHanbaiCheckBox.Location = new System.Drawing.Point(364, 65);
            this.YoshiHanbaiCheckBox.Name = "YoshiHanbaiCheckBox";
            this.YoshiHanbaiCheckBox.Size = new System.Drawing.Size(80, 24);
            this.YoshiHanbaiCheckBox.TabIndex = 79;
            this.YoshiHanbaiCheckBox.Text = "用紙販売";
            this.YoshiHanbaiCheckBox.UseVisualStyleBackColor = true;
            // 
            // Kensa7JoCheckBox
            // 
            this.Kensa7JoCheckBox.AutoSize = true;
            this.Kensa7JoCheckBox.Checked = true;
            this.Kensa7JoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Kensa7JoCheckBox.Location = new System.Drawing.Point(106, 65);
            this.Kensa7JoCheckBox.Name = "Kensa7JoCheckBox";
            this.Kensa7JoCheckBox.Size = new System.Drawing.Size(75, 24);
            this.Kensa7JoCheckBox.TabIndex = 81;
            this.Kensa7JoCheckBox.Text = "7条検査";
            this.Kensa7JoCheckBox.UseVisualStyleBackColor = true;
            // 
            // KeiryoSyomeiCheckBox
            // 
            this.KeiryoSyomeiCheckBox.AutoSize = true;
            this.KeiryoSyomeiCheckBox.Checked = true;
            this.KeiryoSyomeiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KeiryoSyomeiCheckBox.Location = new System.Drawing.Point(278, 65);
            this.KeiryoSyomeiCheckBox.Name = "KeiryoSyomeiCheckBox";
            this.KeiryoSyomeiCheckBox.Size = new System.Drawing.Size(80, 24);
            this.KeiryoSyomeiCheckBox.TabIndex = 78;
            this.KeiryoSyomeiCheckBox.Text = "計量証明";
            this.KeiryoSyomeiCheckBox.UseVisualStyleBackColor = true;
            // 
            // Kensa11JoCheckBox
            // 
            this.Kensa11JoCheckBox.AutoSize = true;
            this.Kensa11JoCheckBox.Checked = true;
            this.Kensa11JoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Kensa11JoCheckBox.Location = new System.Drawing.Point(192, 65);
            this.Kensa11JoCheckBox.Name = "Kensa11JoCheckBox";
            this.Kensa11JoCheckBox.Size = new System.Drawing.Size(83, 24);
            this.Kensa11JoCheckBox.TabIndex = 77;
            this.Kensa11JoCheckBox.Text = "11条検査";
            this.Kensa11JoCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShisyoNmComboBox
            // 
            this.ShisyoNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShisyoNmComboBox.FormattingEnabled = true;
            this.ShisyoNmComboBox.Location = new System.Drawing.Point(106, 31);
            this.ShisyoNmComboBox.Name = "ShisyoNmComboBox";
            this.ShisyoNmComboBox.Size = new System.Drawing.Size(191, 28);
            this.ShisyoNmComboBox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "支所";
            // 
            // SrhDtToTextBox
            // 
            this.SrhDtToTextBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SrhDtToTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SrhDtToTextBox.Location = new System.Drawing.Point(245, 92);
            this.SrhDtToTextBox.Name = "SrhDtToTextBox";
            this.SrhDtToTextBox.Size = new System.Drawing.Size(113, 27);
            this.SrhDtToTextBox.TabIndex = 27;
            // 
            // SrhDtFromTextBox
            // 
            this.SrhDtFromTextBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SrhDtFromTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SrhDtFromTextBox.Location = new System.Drawing.Point(106, 92);
            this.SrhDtFromTextBox.Name = "SrhDtFromTextBox";
            this.SrhDtFromTextBox.Size = new System.Drawing.Size(113, 27);
            this.SrhDtFromTextBox.TabIndex = 24;
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
            this.label19.Location = new System.Drawing.Point(18, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "売上日";
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
            this.clearButton.Location = new System.Drawing.Point(883, 76);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(990, 75);
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
            // UriageListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.UriageListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UriageListForm";
            this.Text = "用紙売上実績一覧";
            ((System.ComponentModel.ISupportInitialize)(this.UriageListDataGridView)).EndInit();
            this.UriageListPanel.ResumeLayout(false);
            this.UriageListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.DataGridView UriageListDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel UriageListPanel;
        private System.Windows.Forms.Label nameListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private Zynas.Control.ZDate SrhDtToTextBox;
        private Zynas.Control.ZDate SrhDtFromTextBox;
        private System.Windows.Forms.ComboBox ShisyoNmComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox YoshiHanbaiCheckBox;
        private System.Windows.Forms.CheckBox Kensa7JoCheckBox;
        private System.Windows.Forms.CheckBox KeiryoSyomeiCheckBox;
        private System.Windows.Forms.CheckBox Kensa11JoCheckBox;
        private System.Windows.Forms.CheckBox NenkaihiCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShisyoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShisyoNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UriageKamoku;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyohinNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UriageDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UriageCntCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UriageGakuCol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}