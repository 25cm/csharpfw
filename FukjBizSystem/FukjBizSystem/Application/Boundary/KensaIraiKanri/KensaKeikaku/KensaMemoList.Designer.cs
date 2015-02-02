namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    partial class KensaMemoList
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
            this.memoListDataGridView = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setisya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setibasyo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.memoPrintButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // memoListDataGridView
            // 
            this.memoListDataGridView.AllowUserToAddRows = false;
            this.memoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.date,
            this.no,
            this.setisya,
            this.setibasyo,
            this.memo});
            this.memoListDataGridView.Location = new System.Drawing.Point(12, 12);
            this.memoListDataGridView.Name = "memoListDataGridView";
            this.memoListDataGridView.RowHeadersVisible = false;
            this.memoListDataGridView.RowTemplate.Height = 21;
            this.memoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.memoListDataGridView.Size = new System.Drawing.Size(565, 370);
            this.memoListDataGridView.TabIndex = 0;
            this.memoListDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.memoListDataGridView_CellEndEdit);
            this.memoListDataGridView.SelectionChanged += new System.EventHandler(this.memoListDataGridView_SelectionChanged);
            // 
            // colKey
            // 
            this.colKey.HeaderText = "key";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Visible = false;
            // 
            // date
            // 
            this.date.HeaderText = "検査予定日";
            this.date.Name = "date";
            this.date.Width = 90;
            // 
            // no
            // 
            this.no.HeaderText = "検査番号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 80;
            // 
            // setisya
            // 
            this.setisya.HeaderText = "設置者";
            this.setisya.Name = "setisya";
            this.setisya.ReadOnly = true;
            this.setisya.Width = 90;
            // 
            // setibasyo
            // 
            this.setibasyo.HeaderText = "設置場所";
            this.setibasyo.Name = "setibasyo";
            this.setibasyo.ReadOnly = true;
            // 
            // memo
            // 
            this.memo.HeaderText = "重要なメモ(最大３つ)";
            this.memo.Name = "memo";
            this.memo.ReadOnly = true;
            this.memo.Width = 200;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(456, 388);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(121, 31);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // memoPrintButton
            // 
            this.memoPrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.memoPrintButton.Location = new System.Drawing.Point(329, 388);
            this.memoPrintButton.Name = "memoPrintButton";
            this.memoPrintButton.Size = new System.Drawing.Size(121, 31);
            this.memoPrintButton.TabIndex = 1;
            this.memoPrintButton.Text = "メモ一覧";
            this.memoPrintButton.UseVisualStyleBackColor = true;
            this.memoPrintButton.Click += new System.EventHandler(this.memoPrintButton_Click);
            // 
            // KensaMemoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 431);
            this.Controls.Add(this.memoPrintButton);
            this.Controls.Add(this.memoListDataGridView);
            this.Controls.Add(this.closeButton);
            this.Name = "KensaMemoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "メモ一覧";
            this.Load += new System.EventHandler(this.KensaMemoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView memoListDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn setisya;
        private System.Windows.Forms.DataGridViewTextBoxColumn setibasyo;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
        private System.Windows.Forms.Button memoPrintButton;
    }
}