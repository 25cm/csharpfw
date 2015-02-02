namespace FukjBizSystem.Application.Boundary.Common
{
    partial class GenbaShashinListForm
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
            this.GenbaShashinListDataGridView = new System.Windows.Forms.DataGridView();
            this.FileSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genbaShashinKensaNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genbaShashinKensaRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genbaShashinCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genbaShashinFilePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genbaShashinListDataSet = new FukjBizSystem.Application.Boundary.Common.GenbaShashinListDataSet();
            this.closeButton = new System.Windows.Forms.Button();
            this.entryButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GenbaShashinListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genbaShashinListDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // GenbaShashinListDataGridView
            // 
            this.GenbaShashinListDataGridView.AllowUserToAddRows = false;
            this.GenbaShashinListDataGridView.AllowUserToDeleteRows = false;
            this.GenbaShashinListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenbaShashinListDataGridView.AutoGenerateColumns = false;
            this.GenbaShashinListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GenbaShashinListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GenbaShashinListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileSeq,
            this.FileName,
            this.genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn,
            this.genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn,
            this.genbaShashinKensaNendoDataGridViewTextBoxColumn,
            this.genbaShashinKensaRenbanDataGridViewTextBoxColumn,
            this.genbaShashinCdDataGridViewTextBoxColumn,
            this.genbaShashinFilePathDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn});
            this.GenbaShashinListDataGridView.DataMember = "GenbaShashinTbl";
            this.GenbaShashinListDataGridView.DataSource = this.genbaShashinListDataSet;
            this.GenbaShashinListDataGridView.Location = new System.Drawing.Point(12, 12);
            this.GenbaShashinListDataGridView.MultiSelect = false;
            this.GenbaShashinListDataGridView.Name = "GenbaShashinListDataGridView";
            this.GenbaShashinListDataGridView.ReadOnly = true;
            this.GenbaShashinListDataGridView.RowHeadersVisible = false;
            this.GenbaShashinListDataGridView.RowTemplate.Height = 21;
            this.GenbaShashinListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GenbaShashinListDataGridView.Size = new System.Drawing.Size(560, 494);
            this.GenbaShashinListDataGridView.TabIndex = 0;
            this.GenbaShashinListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GenbaShashinListDataGridView_CellDoubleClick);
            // 
            // FileSeq
            // 
            this.FileSeq.FillWeight = 20F;
            this.FileSeq.HeaderText = "No.";
            this.FileSeq.Name = "FileSeq";
            this.FileSeq.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.FillWeight = 80F;
            this.FileName.HeaderText = "ファイル名";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn
            // 
            this.genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn.DataPropertyName = "GenbaShashinKensaHoteiKbn";
            this.genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn.HeaderText = "GenbaShashinKensaHoteiKbn";
            this.genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn.Name = "genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn";
            this.genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn
            // 
            this.genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn.DataPropertyName = "GenbaShashinKensaHokenjoCd";
            this.genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn.HeaderText = "GenbaShashinKensaHokenjoCd";
            this.genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn.Name = "genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn";
            this.genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // genbaShashinKensaNendoDataGridViewTextBoxColumn
            // 
            this.genbaShashinKensaNendoDataGridViewTextBoxColumn.DataPropertyName = "GenbaShashinKensaNendo";
            this.genbaShashinKensaNendoDataGridViewTextBoxColumn.HeaderText = "GenbaShashinKensaNendo";
            this.genbaShashinKensaNendoDataGridViewTextBoxColumn.Name = "genbaShashinKensaNendoDataGridViewTextBoxColumn";
            this.genbaShashinKensaNendoDataGridViewTextBoxColumn.ReadOnly = true;
            this.genbaShashinKensaNendoDataGridViewTextBoxColumn.Visible = false;
            // 
            // genbaShashinKensaRenbanDataGridViewTextBoxColumn
            // 
            this.genbaShashinKensaRenbanDataGridViewTextBoxColumn.DataPropertyName = "GenbaShashinKensaRenban";
            this.genbaShashinKensaRenbanDataGridViewTextBoxColumn.HeaderText = "GenbaShashinKensaRenban";
            this.genbaShashinKensaRenbanDataGridViewTextBoxColumn.Name = "genbaShashinKensaRenbanDataGridViewTextBoxColumn";
            this.genbaShashinKensaRenbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.genbaShashinKensaRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // genbaShashinCdDataGridViewTextBoxColumn
            // 
            this.genbaShashinCdDataGridViewTextBoxColumn.DataPropertyName = "GenbaShashinCd";
            this.genbaShashinCdDataGridViewTextBoxColumn.HeaderText = "GenbaShashinCd";
            this.genbaShashinCdDataGridViewTextBoxColumn.Name = "genbaShashinCdDataGridViewTextBoxColumn";
            this.genbaShashinCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.genbaShashinCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // genbaShashinFilePathDataGridViewTextBoxColumn
            // 
            this.genbaShashinFilePathDataGridViewTextBoxColumn.DataPropertyName = "GenbaShashinFilePath";
            this.genbaShashinFilePathDataGridViewTextBoxColumn.HeaderText = "GenbaShashinFilePath";
            this.genbaShashinFilePathDataGridViewTextBoxColumn.Name = "genbaShashinFilePathDataGridViewTextBoxColumn";
            this.genbaShashinFilePathDataGridViewTextBoxColumn.ReadOnly = true;
            this.genbaShashinFilePathDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn
            // 
            this.insertUserDataGridViewTextBoxColumn.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.Name = "insertUserDataGridViewTextBoxColumn";
            this.insertUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn
            // 
            this.insertTarmDataGridViewTextBoxColumn.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.Name = "insertTarmDataGridViewTextBoxColumn";
            this.insertTarmDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDtDataGridViewTextBoxColumn
            // 
            this.updateDtDataGridViewTextBoxColumn.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.Name = "updateDtDataGridViewTextBoxColumn";
            this.updateDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateUserDataGridViewTextBoxColumn
            // 
            this.updateUserDataGridViewTextBoxColumn.DataPropertyName = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.HeaderText = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.Name = "updateUserDataGridViewTextBoxColumn";
            this.updateUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateTarmDataGridViewTextBoxColumn
            // 
            this.updateTarmDataGridViewTextBoxColumn.DataPropertyName = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.HeaderText = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.Name = "updateTarmDataGridViewTextBoxColumn";
            this.updateTarmDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // genbaShashinListDataSet
            // 
            this.genbaShashinListDataSet.DataSetName = "GenbaShashinListDataSet";
            this.genbaShashinListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(471, 512);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // entryButton
            // 
            this.entryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.entryButton.Location = new System.Drawing.Point(12, 512);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 1;
            this.entryButton.Text = "F1:追加";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(119, 512);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // GenbaShashinListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.entryButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.GenbaShashinListDataGridView);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "GenbaShashinListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "現場写真一覧";
            this.Load += new System.EventHandler(this.GenbaShashinListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenbaShashinListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GenbaShashinListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genbaShashinListDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GenbaShashinListDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button deleteButton;
        private GenbaShashinListDataSet genbaShashinListDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genbaShashinKensaNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genbaShashinKensaRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genbaShashinCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genbaShashinFilePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;
    }
}