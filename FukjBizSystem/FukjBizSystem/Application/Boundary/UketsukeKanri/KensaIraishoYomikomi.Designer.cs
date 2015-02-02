namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    partial class KensaIraishoYomikomiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.startButton = new System.Windows.Forms.Button();
            this.srhListPanel = new System.Windows.Forms.Panel();
            this.startCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.srhListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KensaIraishoYomikomiDataGridView = new System.Windows.Forms.DataGridView();
            this.kensaIraishoDataSet = new FukjBizSystem.Application.Boundary.UketsukeKanri.KensaIraishoDataSet();
            this.stopButton = new System.Windows.Forms.Button();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.kensaKbnComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ketteiButton = new System.Windows.Forms.Button();
            this.shisyoComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.torokuButton = new System.Windows.Forms.Button();
            this.hakiButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.uketsukeListButton = new System.Windows.Forms.Button();
            this.rowindexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srhListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KensaIraishoYomikomiDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraishoDataSet)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 544);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(101, 37);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "F2:読込開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // srhListPanel
            // 
            this.srhListPanel.Controls.Add(this.startCountLabel);
            this.srhListPanel.Controls.Add(this.label3);
            this.srhListPanel.Controls.Add(this.srhListCountLabel);
            this.srhListPanel.Controls.Add(this.label4);
            this.srhListPanel.Controls.Add(this.KensaIraishoYomikomiDataGridView);
            this.srhListPanel.Location = new System.Drawing.Point(1, 74);
            this.srhListPanel.Name = "srhListPanel";
            this.srhListPanel.Size = new System.Drawing.Size(1090, 464);
            this.srhListPanel.TabIndex = 1;
            // 
            // startCountLabel
            // 
            this.startCountLabel.Location = new System.Drawing.Point(109, 0);
            this.startCountLabel.Name = "startCountLabel";
            this.startCountLabel.Size = new System.Drawing.Size(65, 20);
            this.startCountLabel.TabIndex = 1;
            this.startCountLabel.Text = "000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "開始受付番号：";
            // 
            // srhListCountLabel
            // 
            this.srhListCountLabel.AutoSize = true;
            this.srhListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.srhListCountLabel.Name = "srhListCountLabel";
            this.srhListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.srhListCountLabel.TabIndex = 3;
            this.srhListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "読込結果：";
            // 
            // KensaIraishoYomikomiDataGridView
            // 
            this.KensaIraishoYomikomiDataGridView.AllowUserToAddRows = false;
            this.KensaIraishoYomikomiDataGridView.AllowUserToDeleteRows = false;
            this.KensaIraishoYomikomiDataGridView.AllowUserToResizeRows = false;
            this.KensaIraishoYomikomiDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KensaIraishoYomikomiDataGridView.AutoGenerateColumns = false;
            this.KensaIraishoYomikomiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KensaIraishoYomikomiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KensaIraishoYomikomiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowindexDataGridViewTextBoxColumn,
            this.shishoDataGridViewTextBoxColumn,
            this.nendoDataGridViewTextBoxColumn,
            this.renbanDataGridViewTextBoxColumn,
            this.barcodeDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.KensaIraishoYomikomiDataGridView.DataMember = "ReadList";
            this.KensaIraishoYomikomiDataGridView.DataSource = this.kensaIraishoDataSet;
            this.KensaIraishoYomikomiDataGridView.Location = new System.Drawing.Point(2, 24);
            this.KensaIraishoYomikomiDataGridView.MultiSelect = false;
            this.KensaIraishoYomikomiDataGridView.Name = "KensaIraishoYomikomiDataGridView";
            this.KensaIraishoYomikomiDataGridView.RowHeadersVisible = false;
            this.KensaIraishoYomikomiDataGridView.RowTemplate.Height = 21;
            this.KensaIraishoYomikomiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.KensaIraishoYomikomiDataGridView.Size = new System.Drawing.Size(1085, 437);
            this.KensaIraishoYomikomiDataGridView.TabIndex = 4;
            // 
            // kensaIraishoDataSet
            // 
            this.kensaIraishoDataSet.DataSetName = "KensaIraishoDataSet";
            this.kensaIraishoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(119, 544);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(101, 37);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "F3:読込停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 0;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.kensaKbnComboBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.ketteiButton);
            this.searchPanel.Controls.Add(this.shisyoComboBox);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 74);
            this.searchPanel.TabIndex = 0;
            // 
            // kensaKbnComboBox
            // 
            this.kensaKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensaKbnComboBox.FormattingEnabled = true;
            this.kensaKbnComboBox.Location = new System.Drawing.Point(89, 35);
            this.kensaKbnComboBox.Name = "kensaKbnComboBox";
            this.kensaKbnComboBox.Size = new System.Drawing.Size(191, 28);
            this.kensaKbnComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "検査区分";
            // 
            // ketteiButton
            // 
            this.ketteiButton.Location = new System.Drawing.Point(556, 31);
            this.ketteiButton.Name = "ketteiButton";
            this.ketteiButton.Size = new System.Drawing.Size(101, 37);
            this.ketteiButton.TabIndex = 6;
            this.ketteiButton.Text = "F1:決定";
            this.ketteiButton.UseVisualStyleBackColor = true;
            this.ketteiButton.Click += new System.EventHandler(this.ketteiButton_Click);
            // 
            // shisyoComboBox
            // 
            this.shisyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shisyoComboBox.FormattingEnabled = true;
            this.shisyoComboBox.Location = new System.Drawing.Point(343, 35);
            this.shisyoComboBox.Name = "shisyoComboBox";
            this.shisyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.shisyoComboBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "支所";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "読込条件";
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(440, 544);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 5;
            this.torokuButton.Text = "F5:登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // hakiButton
            // 
            this.hakiButton.Location = new System.Drawing.Point(333, 544);
            this.hakiButton.Name = "hakiButton";
            this.hakiButton.Size = new System.Drawing.Size(101, 37);
            this.hakiButton.TabIndex = 4;
            this.hakiButton.Text = "F4:破棄";
            this.hakiButton.UseVisualStyleBackColor = true;
            this.hakiButton.Click += new System.EventHandler(this.hakiButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(990, 544);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // uketsukeListButton
            // 
            this.uketsukeListButton.Location = new System.Drawing.Point(883, 544);
            this.uketsukeListButton.Name = "uketsukeListButton";
            this.uketsukeListButton.Size = new System.Drawing.Size(101, 37);
            this.uketsukeListButton.TabIndex = 6;
            this.uketsukeListButton.Text = "F11:受付一覧";
            this.uketsukeListButton.UseVisualStyleBackColor = true;
            this.uketsukeListButton.Click += new System.EventHandler(this.uketsukeListButton_Click);
            // 
            // rowindexDataGridViewTextBoxColumn
            // 
            this.rowindexDataGridViewTextBoxColumn.DataPropertyName = "Rowindex";
            this.rowindexDataGridViewTextBoxColumn.FillWeight = 5F;
            this.rowindexDataGridViewTextBoxColumn.HeaderText = "No.";
            this.rowindexDataGridViewTextBoxColumn.Name = "rowindexDataGridViewTextBoxColumn";
            this.rowindexDataGridViewTextBoxColumn.ReadOnly = true;
            this.rowindexDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // shishoDataGridViewTextBoxColumn
            // 
            this.shishoDataGridViewTextBoxColumn.DataPropertyName = "Shisho";
            this.shishoDataGridViewTextBoxColumn.FillWeight = 20F;
            this.shishoDataGridViewTextBoxColumn.HeaderText = "支所";
            this.shishoDataGridViewTextBoxColumn.Name = "shishoDataGridViewTextBoxColumn";
            this.shishoDataGridViewTextBoxColumn.ReadOnly = true;
            this.shishoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nendoDataGridViewTextBoxColumn
            // 
            this.nendoDataGridViewTextBoxColumn.DataPropertyName = "Nendo";
            this.nendoDataGridViewTextBoxColumn.FillWeight = 10F;
            this.nendoDataGridViewTextBoxColumn.HeaderText = "年度";
            this.nendoDataGridViewTextBoxColumn.Name = "nendoDataGridViewTextBoxColumn";
            this.nendoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nendoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // renbanDataGridViewTextBoxColumn
            // 
            this.renbanDataGridViewTextBoxColumn.DataPropertyName = "Renban";
            this.renbanDataGridViewTextBoxColumn.FillWeight = 10F;
            this.renbanDataGridViewTextBoxColumn.HeaderText = "受付番号";
            this.renbanDataGridViewTextBoxColumn.Name = "renbanDataGridViewTextBoxColumn";
            this.renbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.renbanDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            dataGridViewCellStyle1.NullValue = null;
            this.barcodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.barcodeDataGridViewTextBoxColumn.FillWeight = 15F;
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "バーコード";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.FillWeight = 50F;
            this.remarkDataGridViewTextBoxColumn.HeaderText = "備考";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarkDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KensaIraishoYomikomiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.uketsukeListButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.hakiButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.srhListPanel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KensaIraishoYomikomiForm";
            this.Text = "水質検査依頼書読込";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KensaIraishoYomikomiForm_FormClosing);
            this.Load += new System.EventHandler(this.KensaIraishoYomikomiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaIraishoYomikomiForm_KeyDown);
            this.srhListPanel.ResumeLayout(false);
            this.srhListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KensaIraishoYomikomiDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraishoDataSet)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView KensaIraishoYomikomiDataGridView;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel srhListPanel;
        private System.Windows.Forms.Label srhListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox shisyoComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Button hakiButton;
        private System.Windows.Forms.Button closeButton;
        private KensaIraishoDataSet kensaIraishoDataSet;
        private System.Windows.Forms.Button ketteiButton;
        private System.Windows.Forms.Label startCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox kensaKbnComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uketsukeListButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowindexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn renbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;

    }
}