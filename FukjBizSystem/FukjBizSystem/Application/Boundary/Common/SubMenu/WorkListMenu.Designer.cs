namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    partial class workListMenuForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.WorkListDataGridView = new System.Windows.Forms.DataGridView();
            this.MenuIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SagyoNaiyo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shosai = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.WorkListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkListDataGridView
            // 
            this.WorkListDataGridView.AllowUserToAddRows = false;
            this.WorkListDataGridView.AllowUserToDeleteRows = false;
            this.WorkListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WorkListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.WorkListDataGridView.ColumnHeadersHeight = 30;
            this.WorkListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuIndex,
            this.SagyoNaiyo,
            this.Shosai});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WorkListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.WorkListDataGridView.Location = new System.Drawing.Point(12, 12);
            this.WorkListDataGridView.MultiSelect = false;
            this.WorkListDataGridView.Name = "WorkListDataGridView";
            this.WorkListDataGridView.ReadOnly = true;
            this.WorkListDataGridView.RowHeadersVisible = false;
            this.WorkListDataGridView.RowTemplate.Height = 30;
            this.WorkListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkListDataGridView.Size = new System.Drawing.Size(360, 300);
            this.WorkListDataGridView.TabIndex = 1;
            this.WorkListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkListDataGridView_CellContentClick);
            // 
            // MenuIndex
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.MenuIndex.DefaultCellStyle = dataGridViewCellStyle2;
            this.MenuIndex.FillWeight = 10F;
            this.MenuIndex.HeaderText = "No.";
            this.MenuIndex.Name = "MenuIndex";
            this.MenuIndex.ReadOnly = true;
            // 
            // SagyoNaiyo
            // 
            this.SagyoNaiyo.FillWeight = 60F;
            this.SagyoNaiyo.HeaderText = "作業内容";
            this.SagyoNaiyo.Name = "SagyoNaiyo";
            this.SagyoNaiyo.ReadOnly = true;
            this.SagyoNaiyo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Shosai
            // 
            this.Shosai.FillWeight = 30F;
            this.Shosai.HeaderText = "";
            this.Shosai.Name = "Shosai";
            this.Shosai.ReadOnly = true;
            this.Shosai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Shosai.Text = "";
            // 
            // workListMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.WorkListDataGridView);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "workListMenuForm";
            this.Text = "作業一覧";
            this.Load += new System.EventHandler(this.workListMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WorkListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WorkListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn SagyoNaiyo;
        private System.Windows.Forms.DataGridViewButtonColumn Shosai;

    }
}