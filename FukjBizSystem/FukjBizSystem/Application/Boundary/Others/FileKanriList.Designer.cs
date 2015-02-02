namespace FukjBizSystem.Application.Boundary.Others
{
    partial class FileKanriListForm
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
            this.fileListDataGridView = new System.Windows.Forms.DataGridView();
            this.FileNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileNmBeforeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TorokuDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNmBeforeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePathCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileKanriTblDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileKanriTblDataSet = new FukjBizSystem.Application.DataSet.FileKanriTblDataSet();
            this.fileListPanel = new System.Windows.Forms.Panel();
            this.fileListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.torokuDtToDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.torokuDtFromDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.fileNmTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.torokuDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.entryButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.fileOpenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileKanriTblDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileKanriTblDataSet)).BeginInit();
            this.fileListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileListDataGridView
            // 
            this.fileListDataGridView.AllowUserToAddRows = false;
            this.fileListDataGridView.AllowUserToDeleteRows = false;
            this.fileListDataGridView.AllowUserToResizeRows = false;
            this.fileListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListDataGridView.AutoGenerateColumns = false;
            this.fileListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileNoCol,
            this.FileNmBeforeCol,
            this.TorokuDtCol,
            this.FileKbnCol,
            this.fileNoDataGridViewTextBoxColumn,
            this.fileNmBeforeDataGridViewTextBoxColumn,
            this.FileNmCol,
            this.FilePathCol,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn});
            this.fileListDataGridView.DataMember = "FileKanriTblKensaku";
            this.fileListDataGridView.DataSource = this.fileKanriTblDataSetBindingSource;
            this.fileListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.fileListDataGridView.MultiSelect = false;
            this.fileListDataGridView.Name = "fileListDataGridView";
            this.fileListDataGridView.RowHeadersVisible = false;
            this.fileListDataGridView.RowTemplate.Height = 21;
            this.fileListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fileListDataGridView.Size = new System.Drawing.Size(1085, 374);
            this.fileListDataGridView.TabIndex = 2;
            this.fileListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fileListDataGridView_CellDoubleClick);
            // 
            // FileNoCol
            // 
            this.FileNoCol.DataPropertyName = "FileNo";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FileNoCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.FileNoCol.HeaderText = "ファイルNo";
            this.FileNoCol.MinimumWidth = 140;
            this.FileNoCol.Name = "FileNoCol";
            this.FileNoCol.ReadOnly = true;
            this.FileNoCol.Width = 140;
            // 
            // FileNmBeforeCol
            // 
            this.FileNmBeforeCol.DataPropertyName = "FileNmBefore";
            this.FileNmBeforeCol.HeaderText = "ファイル名";
            this.FileNmBeforeCol.MinimumWidth = 550;
            this.FileNmBeforeCol.Name = "FileNmBeforeCol";
            this.FileNmBeforeCol.ReadOnly = true;
            this.FileNmBeforeCol.Width = 550;
            // 
            // TorokuDtCol
            // 
            this.TorokuDtCol.DataPropertyName = "InsertDt";
            dataGridViewCellStyle2.Format = "yyyy/MM/dd";
            dataGridViewCellStyle2.NullValue = null;
            this.TorokuDtCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.TorokuDtCol.HeaderText = "登録日";
            this.TorokuDtCol.MinimumWidth = 150;
            this.TorokuDtCol.Name = "TorokuDtCol";
            this.TorokuDtCol.ReadOnly = true;
            this.TorokuDtCol.Width = 150;
            // 
            // FileKbnCol
            // 
            this.FileKbnCol.DataPropertyName = "FileKbn";
            this.FileKbnCol.HeaderText = "FileKbn";
            this.FileKbnCol.Name = "FileKbnCol";
            this.FileKbnCol.Visible = false;
            // 
            // fileNoDataGridViewTextBoxColumn
            // 
            this.fileNoDataGridViewTextBoxColumn.DataPropertyName = "FileNo";
            this.fileNoDataGridViewTextBoxColumn.HeaderText = "FileNo";
            this.fileNoDataGridViewTextBoxColumn.Name = "fileNoDataGridViewTextBoxColumn";
            this.fileNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // fileNmBeforeDataGridViewTextBoxColumn
            // 
            this.fileNmBeforeDataGridViewTextBoxColumn.DataPropertyName = "FileNmBefore";
            this.fileNmBeforeDataGridViewTextBoxColumn.HeaderText = "FileNmBefore";
            this.fileNmBeforeDataGridViewTextBoxColumn.Name = "fileNmBeforeDataGridViewTextBoxColumn";
            this.fileNmBeforeDataGridViewTextBoxColumn.Visible = false;
            // 
            // FileNmCol
            // 
            this.FileNmCol.DataPropertyName = "FileNm";
            this.FileNmCol.HeaderText = "FileNm";
            this.FileNmCol.Name = "FileNmCol";
            this.FileNmCol.Visible = false;
            // 
            // FilePathCol
            // 
            this.FilePathCol.DataPropertyName = "FilePath";
            this.FilePathCol.HeaderText = "FilePath";
            this.FilePathCol.Name = "FilePathCol";
            this.FilePathCol.Visible = false;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn
            // 
            this.insertUserDataGridViewTextBoxColumn.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.Name = "insertUserDataGridViewTextBoxColumn";
            this.insertUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn
            // 
            this.insertTarmDataGridViewTextBoxColumn.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.Name = "insertTarmDataGridViewTextBoxColumn";
            this.insertTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDtDataGridViewTextBoxColumn
            // 
            this.updateDtDataGridViewTextBoxColumn.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.Name = "updateDtDataGridViewTextBoxColumn";
            this.updateDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateUserDataGridViewTextBoxColumn
            // 
            this.updateUserDataGridViewTextBoxColumn.DataPropertyName = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.HeaderText = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.Name = "updateUserDataGridViewTextBoxColumn";
            this.updateUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateTarmDataGridViewTextBoxColumn
            // 
            this.updateTarmDataGridViewTextBoxColumn.DataPropertyName = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.HeaderText = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.Name = "updateTarmDataGridViewTextBoxColumn";
            this.updateTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // fileKanriTblDataSetBindingSource
            // 
            this.fileKanriTblDataSetBindingSource.DataSource = this.fileKanriTblDataSet;
            this.fileKanriTblDataSetBindingSource.Position = 0;
            // 
            // fileKanriTblDataSet
            // 
            this.fileKanriTblDataSet.DataSetName = "FileKanriTblDataSet";
            this.fileKanriTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fileListPanel
            // 
            this.fileListPanel.Controls.Add(this.fileListCountLabel);
            this.fileListPanel.Controls.Add(this.label4);
            this.fileListPanel.Controls.Add(this.fileListDataGridView);
            this.fileListPanel.Location = new System.Drawing.Point(1, 125);
            this.fileListPanel.Name = "fileListPanel";
            this.fileListPanel.Size = new System.Drawing.Size(1090, 401);
            this.fileListPanel.TabIndex = 1;
            // 
            // fileListCountLabel
            // 
            this.fileListCountLabel.AutoSize = true;
            this.fileListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.fileListCountLabel.Name = "fileListCountLabel";
            this.fileListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.fileListCountLabel.TabIndex = 2;
            this.fileListCountLabel.Text = "0件";
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
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(854, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 6;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 10;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.torokuDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.torokuDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.fileNmTextBox);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.torokuDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 131);
            this.searchPanel.TabIndex = 0;
            // 
            // torokuDtToDateTimePicker
            // 
            this.torokuDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.torokuDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.torokuDtToDateTimePicker.Location = new System.Drawing.Point(336, 77);
            this.torokuDtToDateTimePicker.Name = "torokuDtToDateTimePicker";
            this.torokuDtToDateTimePicker.Size = new System.Drawing.Size(200, 27);
            this.torokuDtToDateTimePicker.TabIndex = 7;
            // 
            // torokuDtFromDateTimePicker
            // 
            this.torokuDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.torokuDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.torokuDtFromDateTimePicker.Location = new System.Drawing.Point(102, 77);
            this.torokuDtFromDateTimePicker.Name = "torokuDtFromDateTimePicker";
            this.torokuDtFromDateTimePicker.Size = new System.Drawing.Size(200, 27);
            this.torokuDtFromDateTimePicker.TabIndex = 5;
            this.torokuDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.torokuDtFromDateTimePicker_ValueChanged);
            // 
            // fileNmTextBox
            // 
            this.fileNmTextBox.Location = new System.Drawing.Point(102, 42);
            this.fileNmTextBox.MaxLength = 100;
            this.fileNmTextBox.Name = "fileNmTextBox";
            this.fileNmTextBox.Size = new System.Drawing.Size(434, 27);
            this.fileNmTextBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "ファイル名";
            // 
            // torokuDtUseCheckBox
            // 
            this.torokuDtUseCheckBox.AutoSize = true;
            this.torokuDtUseCheckBox.Location = new System.Drawing.Point(5, 83);
            this.torokuDtUseCheckBox.Name = "torokuDtUseCheckBox";
            this.torokuDtUseCheckBox.Size = new System.Drawing.Size(15, 14);
            this.torokuDtUseCheckBox.TabIndex = 3;
            this.torokuDtUseCheckBox.UseVisualStyleBackColor = true;
            this.torokuDtUseCheckBox.CheckedChanged += new System.EventHandler(this.torokuDtUseCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "登録日";
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
            this.clearButton.Location = new System.Drawing.Point(870, 82);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(977, 81);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 9;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(990, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 7;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(383, 544);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 2;
            this.entryButton.Text = "F1:新規登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(490, 544);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(101, 37);
            this.changeButton.TabIndex = 3;
            this.changeButton.Text = "F2:変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(597, 544);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // fileOpenButton
            // 
            this.fileOpenButton.Location = new System.Drawing.Point(704, 544);
            this.fileOpenButton.Name = "fileOpenButton";
            this.fileOpenButton.Size = new System.Drawing.Size(144, 37);
            this.fileOpenButton.TabIndex = 5;
            this.fileOpenButton.Text = "F5:ファイルを開く";
            this.fileOpenButton.UseVisualStyleBackColor = true;
            this.fileOpenButton.Click += new System.EventHandler(this.fileOpenButton_Click);
            // 
            // FileKanriListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.fileOpenButton);
            this.Controls.Add(this.entryButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.fileListPanel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileKanriListForm";
            this.Text = "受検啓発履歴一覧";
            this.Load += new System.EventHandler(this.FileKanriListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileKanriListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileKanriTblDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileKanriTblDataSet)).EndInit();
            this.fileListPanel.ResumeLayout(false);
            this.fileListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView fileListDataGridView;
        private System.Windows.Forms.Panel fileListPanel;
        private System.Windows.Forms.Label fileListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.CheckBox torokuDtUseCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fileNmTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button fileOpenButton;
        private System.Windows.Forms.BindingSource fileKanriTblDataSetBindingSource;
        private DataSet.FileKanriTblDataSet fileKanriTblDataSet;
        private Zynas.Control.ZDate torokuDtToDateTimePicker;
        private Zynas.Control.ZDate torokuDtFromDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNmBeforeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TorokuDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNmBeforeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePathCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;

    }
}