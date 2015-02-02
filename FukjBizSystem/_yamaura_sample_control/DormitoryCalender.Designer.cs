namespace MealReservationManager.Control
{
    partial class DormitoryCalender
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblYearMonth = new System.Windows.Forms.Label();
            this.dgvDate = new System.Windows.Forms.DataGridView();
            this.Sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fryday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYearMonth
            // 
            this.lblYearMonth.AutoSize = true;
            this.lblYearMonth.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYearMonth.Location = new System.Drawing.Point(0, 0);
            this.lblYearMonth.Margin = new System.Windows.Forms.Padding(0);
            this.lblYearMonth.Name = "lblYearMonth";
            this.lblYearMonth.Size = new System.Drawing.Size(72, 15);
            this.lblYearMonth.TabIndex = 2;
            this.lblYearMonth.Text = "yyyy/MM";
            // 
            // dgvDate
            // 
            this.dgvDate.AllowUserToAddRows = false;
            this.dgvDate.AllowUserToDeleteRows = false;
            this.dgvDate.AllowUserToResizeColumns = false;
            this.dgvDate.AllowUserToResizeRows = false;
            this.dgvDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDate.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDate.ColumnHeadersVisible = false;
            this.dgvDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sunday,
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Fryday,
            this.Saturday});
            this.dgvDate.Location = new System.Drawing.Point(3, 18);
            this.dgvDate.MultiSelect = false;
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            this.dgvDate.RowHeadersVisible = false;
            this.dgvDate.RowTemplate.Height = 21;
            this.dgvDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDate.Size = new System.Drawing.Size(180, 143);
            this.dgvDate.TabIndex = 3;
            this.dgvDate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDate_CellClick);
            // 
            // Sunday
            // 
            this.Sunday.HeaderText = "日";
            this.Sunday.Name = "Sunday";
            this.Sunday.ReadOnly = true;
            this.Sunday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Monday
            // 
            this.Monday.HeaderText = "月";
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            this.Monday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "火";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            this.Tuesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "水";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            this.Wednesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "木";
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            this.Thursday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Fryday
            // 
            this.Fryday.HeaderText = "金";
            this.Fryday.Name = "Fryday";
            this.Fryday.ReadOnly = true;
            this.Fryday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Saturday
            // 
            this.Saturday.HeaderText = "土";
            this.Saturday.Name = "Saturday";
            this.Saturday.ReadOnly = true;
            this.Saturday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DormitoryCalender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dgvDate);
            this.Controls.Add(this.lblYearMonth);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
            this.Name = "DormitoryCalender";
            this.Size = new System.Drawing.Size(185, 165);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblYearMonth;
        internal System.Windows.Forms.DataGridView dgvDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Sunday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Fryday;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Saturday;

    }
}
