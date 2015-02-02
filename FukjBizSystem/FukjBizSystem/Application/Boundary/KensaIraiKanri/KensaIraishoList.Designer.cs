namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    partial class KensaIraishoList
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
            this.fileListDataGridView = new System.Windows.Forms.DataGridView();
            this.PdfFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.fileListDataGridView.AllowUserToAddRows = false;
            this.fileListDataGridView.AllowUserToDeleteRows = false;
            this.fileListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PdfFilePath,
            this.CreatDate});
            this.fileListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.fileListDataGridView.MultiSelect = false;
            this.fileListDataGridView.Name = "dataGridView1";
            this.fileListDataGridView.ReadOnly = true;
            this.fileListDataGridView.RowHeadersVisible = false;
            this.fileListDataGridView.RowTemplate.Height = 21;
            this.fileListDataGridView.Size = new System.Drawing.Size(527, 215);
            this.fileListDataGridView.TabIndex = 0;
            this.fileListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fileListDataGridView_CellClick);
            // 
            // PdfFilePath
            // 
            this.PdfFilePath.HeaderText = "ファイル";
            this.PdfFilePath.Name = "PdfFilePath";
            this.PdfFilePath.Width = 250;
            // 
            // CreatDate
            // 
            this.CreatDate.HeaderText = "作成日";
            this.CreatDate.Name = "CreatDate";
            this.CreatDate.Width = 250;
            // 
            // KensaIraishoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 215);
            this.Controls.Add(this.fileListDataGridView);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KensaIraishoList";
            this.Text = "依頼書リスト";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KensaIraishoList_FormClosing);
            this.Load += new System.EventHandler(this.KensaIraishoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView fileListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PdfFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatDate;

    }
}