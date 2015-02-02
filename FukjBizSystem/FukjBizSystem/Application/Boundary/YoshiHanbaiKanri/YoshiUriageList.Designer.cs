namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class YoshiUriageListForm
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
            this.outputButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.uriageListPanel = new System.Windows.Forms.Panel();
            this.uriageListDataGridView = new System.Windows.Forms.DataGridView();
            this.GyosyaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GyosyaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanbaiDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UriageTotalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaiDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoshiHanbaiHdrTblDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yoshiHanbaiHdrTblDataSet = new FukjBizSystem.Application.DataSet.YoshiHanbaiHdrTblDataSet();
            this.uriageListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.srhDtToDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.srhDtFromDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.dayRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.uriageListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uriageListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "～";
            // 
            // uriageListPanel
            // 
            this.uriageListPanel.Controls.Add(this.uriageListDataGridView);
            this.uriageListPanel.Controls.Add(this.uriageListCountLabel);
            this.uriageListPanel.Controls.Add(this.label4);
            this.uriageListPanel.Location = new System.Drawing.Point(0, 103);
            this.uriageListPanel.Name = "uriageListPanel";
            this.uriageListPanel.Size = new System.Drawing.Size(1100, 435);
            this.uriageListPanel.TabIndex = 12;
            // 
            // uriageListDataGridView
            // 
            this.uriageListDataGridView.AllowUserToAddRows = false;
            this.uriageListDataGridView.AllowUserToDeleteRows = false;
            this.uriageListDataGridView.AllowUserToResizeRows = false;
            this.uriageListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uriageListDataGridView.AutoGenerateColumns = false;
            this.uriageListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uriageListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GyosyaCdCol,
            this.GyosyaNmCol,
            this.HanbaiDtCol,
            this.UriageTotalCol,
            this.gyoshaNmDataGridViewTextBoxColumn,
            this.yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn,
            this.yoshiHanbaiDtDataGridViewTextBoxColumn,
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn});
            this.uriageListDataGridView.DataMember = "YoshiUriageList";
            this.uriageListDataGridView.DataSource = this.yoshiHanbaiHdrTblDataSetBindingSource;
            this.uriageListDataGridView.Location = new System.Drawing.Point(3, 23);
            this.uriageListDataGridView.MultiSelect = false;
            this.uriageListDataGridView.Name = "uriageListDataGridView";
            this.uriageListDataGridView.ReadOnly = true;
            this.uriageListDataGridView.RowHeadersVisible = false;
            this.uriageListDataGridView.RowTemplate.Height = 21;
            this.uriageListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uriageListDataGridView.Size = new System.Drawing.Size(1100, 404);
            this.uriageListDataGridView.TabIndex = 7;
            // 
            // GyosyaCdCol
            // 
            this.GyosyaCdCol.DataPropertyName = "YoshiHanbaisakiGyoshaCd";
            this.GyosyaCdCol.HeaderText = "業者コード";
            this.GyosyaCdCol.MinimumWidth = 100;
            this.GyosyaCdCol.Name = "GyosyaCdCol";
            this.GyosyaCdCol.ReadOnly = true;
            this.GyosyaCdCol.Width = 120;
            // 
            // GyosyaNmCol
            // 
            this.GyosyaNmCol.DataPropertyName = "GyoshaNm";
            this.GyosyaNmCol.HeaderText = "業者名称";
            this.GyosyaNmCol.MinimumWidth = 300;
            this.GyosyaNmCol.Name = "GyosyaNmCol";
            this.GyosyaNmCol.ReadOnly = true;
            this.GyosyaNmCol.Width = 450;
            // 
            // HanbaiDtCol
            // 
            this.HanbaiDtCol.DataPropertyName = "YoshiHanbaiDt";
            this.HanbaiDtCol.HeaderText = "販売日/販売月";
            this.HanbaiDtCol.MinimumWidth = 150;
            this.HanbaiDtCol.Name = "HanbaiDtCol";
            this.HanbaiDtCol.ReadOnly = true;
            this.HanbaiDtCol.Width = 200;
            // 
            // UriageTotalCol
            // 
            this.UriageTotalCol.DataPropertyName = "YoshiHanbaiGokeiKingaku";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.UriageTotalCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.UriageTotalCol.HeaderText = "売上合計";
            this.UriageTotalCol.MinimumWidth = 100;
            this.UriageTotalCol.Name = "UriageTotalCol";
            this.UriageTotalCol.ReadOnly = true;
            this.UriageTotalCol.Width = 150;
            // 
            // gyoshaNmDataGridViewTextBoxColumn
            // 
            this.gyoshaNmDataGridViewTextBoxColumn.DataPropertyName = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.HeaderText = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.Name = "gyoshaNmDataGridViewTextBoxColumn";
            this.gyoshaNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.gyoshaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn
            // 
            this.yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn.DataPropertyName = "YoshiHanbaisakiGyoshaCd";
            this.yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn.HeaderText = "YoshiHanbaisakiGyoshaCd";
            this.yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn.Name = "yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn";
            this.yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoshiHanbaiDtDataGridViewTextBoxColumn
            // 
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.DataPropertyName = "YoshiHanbaiDt";
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.HeaderText = "YoshiHanbaiDt";
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.Name = "yoshiHanbaiDtDataGridViewTextBoxColumn";
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.yoshiHanbaiDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn
            // 
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.DataPropertyName = "YoshiHanbaiGokeiKingaku";
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.HeaderText = "YoshiHanbaiGokeiKingaku";
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.Name = "yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn";
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.ReadOnly = true;
            this.yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoshiHanbaiHdrTblDataSetBindingSource
            // 
            this.yoshiHanbaiHdrTblDataSetBindingSource.DataSource = this.yoshiHanbaiHdrTblDataSet;
            this.yoshiHanbaiHdrTblDataSetBindingSource.Position = 0;
            // 
            // yoshiHanbaiHdrTblDataSet
            // 
            this.yoshiHanbaiHdrTblDataSet.DataSetName = "YoshiHanbaiHdrTblDataSet";
            this.yoshiHanbaiHdrTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uriageListCountLabel
            // 
            this.uriageListCountLabel.AutoSize = true;
            this.uriageListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.uriageListCountLabel.Name = "uriageListCountLabel";
            this.uriageListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.uriageListCountLabel.TabIndex = 1;
            this.uriageListCountLabel.Text = "0件";
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
            this.searchPanel.Controls.Add(this.srhDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.srhDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.monthRadioButton);
            this.searchPanel.Controls.Add(this.dayRadioButton);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(0, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1100, 105);
            this.searchPanel.TabIndex = 11;
            // 
            // srhDtToDateTimePicker
            // 
            this.srhDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.srhDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.srhDtToDateTimePicker.Location = new System.Drawing.Point(333, 61);
            this.srhDtToDateTimePicker.Name = "srhDtToDateTimePicker";
            this.srhDtToDateTimePicker.Size = new System.Drawing.Size(162, 27);
            this.srhDtToDateTimePicker.TabIndex = 7;
            // 
            // srhDtFromDateTimePicker
            // 
            this.srhDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.srhDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.srhDtFromDateTimePicker.Location = new System.Drawing.Point(113, 61);
            this.srhDtFromDateTimePicker.Name = "srhDtFromDateTimePicker";
            this.srhDtFromDateTimePicker.Size = new System.Drawing.Size(162, 27);
            this.srhDtFromDateTimePicker.TabIndex = 5;
            this.srhDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.srhDtFromDateTimePicker_ValueChanged);
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Location = new System.Drawing.Point(194, 33);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(53, 24);
            this.monthRadioButton.TabIndex = 3;
            this.monthRadioButton.Text = "月別";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            // 
            // dayRadioButton
            // 
            this.dayRadioButton.AutoSize = true;
            this.dayRadioButton.Checked = true;
            this.dayRadioButton.Location = new System.Drawing.Point(113, 33);
            this.dayRadioButton.Name = "dayRadioButton";
            this.dayRadioButton.Size = new System.Drawing.Size(53, 24);
            this.dayRadioButton.TabIndex = 2;
            this.dayRadioButton.TabStop = true;
            this.dayRadioButton.Text = "日別";
            this.dayRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "検索分類";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1068, 3);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 10;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "日付";
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
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(991, 57);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 9;
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
            // YoshiUriageListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.uriageListPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YoshiUriageListForm";
            this.Text = "用紙売上実績一覧";
            this.Load += new System.EventHandler(this.YoshiUriageListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YoshiUriageListForm_KeyDown);
            this.uriageListPanel.ResumeLayout(false);
            this.uriageListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uriageListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiHanbaiHdrTblDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel uriageListPanel;
        private System.Windows.Forms.Label uriageListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.RadioButton dayRadioButton;
        private Zynas.Control.ZDate srhDtToDateTimePicker;
        private Zynas.Control.ZDate srhDtFromDateTimePicker;
        private System.Windows.Forms.DataGridView uriageListDataGridView;
        private System.Windows.Forms.BindingSource yoshiHanbaiHdrTblDataSetBindingSource;
        private DataSet.YoshiHanbaiHdrTblDataSet yoshiHanbaiHdrTblDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn GyosyaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GyosyaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanbaiDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UriageTotalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoshiHanbaisakiGyoshaCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoshiHanbaiDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoshiHanbaiGokeiKingakuDataGridViewTextBoxColumn;
    }
}