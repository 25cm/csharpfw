namespace FukjBizSystem.Application.Boundary.Common
{
    partial class ImageImportForm
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
            this.ImageImportListDataGridView = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.entryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageImportListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageImportListDataGridView
            // 
            this.ImageImportListDataGridView.AllowUserToAddRows = false;
            this.ImageImportListDataGridView.AllowUserToDeleteRows = false;
            this.ImageImportListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageImportListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ImageImportListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ImageImportListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.FileName,
            this.TimeStamp,
            this.FilePath});
            this.ImageImportListDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ImageImportListDataGridView.MultiSelect = false;
            this.ImageImportListDataGridView.Name = "ImageImportListDataGridView";
            this.ImageImportListDataGridView.RowHeadersVisible = false;
            this.ImageImportListDataGridView.RowTemplate.Height = 21;
            this.ImageImportListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ImageImportListDataGridView.Size = new System.Drawing.Size(560, 494);
            this.ImageImportListDataGridView.TabIndex = 0;
            this.ImageImportListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ImageImportListDataGridView_CellDoubleClick);
            // 
            // Checked
            // 
            this.Checked.FillWeight = 10F;
            this.Checked.HeaderText = "選択";
            this.Checked.Name = "Checked";
            // 
            // FileName
            // 
            this.FileName.FillWeight = 60F;
            this.FileName.HeaderText = "ファイル名";
            this.FileName.Name = "FileName";
            // 
            // TimeStamp
            // 
            this.TimeStamp.FillWeight = 30F;
            this.TimeStamp.HeaderText = "撮影日時";
            this.TimeStamp.Name = "TimeStamp";
            // 
            // FilePath
            // 
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(471, 512);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 2;
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
            // ImageImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.entryButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.ImageImportListDataGridView);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "ImageImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "画像取り込み";
            this.Load += new System.EventHandler(this.ImageImportForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageImportForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ImageImportListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ImageImportListDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
    }
}