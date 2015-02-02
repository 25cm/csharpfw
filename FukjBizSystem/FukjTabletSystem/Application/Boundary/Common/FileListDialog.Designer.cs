namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class FileListDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.closeButton = new Zynas.Control.ZButton(this.components);
            this.fileListDataSet = new FukjTabletSystem.Application.Boundary.Common.FileListDataSet();
            this.fileListDataGridView = new System.Windows.Forms.DataGridView();
            this.cdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.fileListDataGridView);
            this.contentsPanel.Size = new System.Drawing.Size(794, 319);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Size = new System.Drawing.Size(794, 50);
            this.topPanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.topPanel.Controls.SetChildIndex(this.closeButton, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(318, 5);
            this.titleLabel.Size = new System.Drawing.Size(159, 36);
            this.titleLabel.Text = "ファイル一覧";
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::FukjTabletSystem.Properties.Resources.top_close;
            this.closeButton.Location = new System.Drawing.Point(1, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(70, 48);
            this.closeButton.TabIndex = 3;
            this.closeButton.TabStop = false;
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // fileListDataSet
            // 
            this.fileListDataSet.DataSetName = "FileListDataSet";
            this.fileListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.fileListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fileListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fileListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fileListDataGridView.ColumnHeadersHeight = 45;
            this.fileListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fileListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdDataGridViewTextBoxColumn,
            this.filePathDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserNmDataGridViewTextBoxColumn,
            this.Selected});
            this.fileListDataGridView.DataMember = "FileList";
            this.fileListDataGridView.DataSource = this.fileListDataSet;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fileListDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.fileListDataGridView.EnableHeadersVisualStyles = false;
            this.fileListDataGridView.Location = new System.Drawing.Point(1, 0);
            this.fileListDataGridView.MultiSelect = false;
            this.fileListDataGridView.Name = "fileListDataGridView";
            this.fileListDataGridView.ReadOnly = true;
            this.fileListDataGridView.RowHeadersVisible = false;
            this.fileListDataGridView.RowTemplate.Height = 51;
            this.fileListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fileListDataGridView.Size = new System.Drawing.Size(792, 319);
            this.fileListDataGridView.TabIndex = 82;
            this.fileListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fileListDataGridView_CellClick);
            this.fileListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.fileListDataGridView_CellFormatting);
            // 
            // cdDataGridViewTextBoxColumn
            // 
            this.cdDataGridViewTextBoxColumn.DataPropertyName = "Cd";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cdDataGridViewTextBoxColumn.FillWeight = 10F;
            this.cdDataGridViewTextBoxColumn.HeaderText = "No.";
            this.cdDataGridViewTextBoxColumn.Name = "cdDataGridViewTextBoxColumn";
            this.cdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filePathDataGridViewTextBoxColumn
            // 
            this.filePathDataGridViewTextBoxColumn.DataPropertyName = "FilePath";
            this.filePathDataGridViewTextBoxColumn.HeaderText = "FilePath";
            this.filePathDataGridViewTextBoxColumn.Name = "filePathDataGridViewTextBoxColumn";
            this.filePathDataGridViewTextBoxColumn.ReadOnly = true;
            this.filePathDataGridViewTextBoxColumn.Visible = false;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.FillWeight = 55F;
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "ファイル名";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            dataGridViewCellStyle3.Format = "f";
            dataGridViewCellStyle3.NullValue = null;
            this.insertDtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.insertDtDataGridViewTextBoxColumn.FillWeight = 40F;
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "登録日";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insertUserNmDataGridViewTextBoxColumn
            // 
            this.insertUserNmDataGridViewTextBoxColumn.DataPropertyName = "InsertUserNm";
            this.insertUserNmDataGridViewTextBoxColumn.FillWeight = 30F;
            this.insertUserNmDataGridViewTextBoxColumn.HeaderText = "登録者";
            this.insertUserNmDataGridViewTextBoxColumn.Name = "insertUserNmDataGridViewTextBoxColumn";
            this.insertUserNmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Selected
            // 
            this.Selected.FillWeight = 20F;
            this.Selected.HeaderText = "";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            // 
            // FileListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 371);
            this.Name = "FileListDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ファイル一覧";
            this.Load += new System.EventHandler(this.Form_Load);
            this.contentsPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton closeButton;
        private FileListDataSet fileListDataSet;
        private System.Windows.Forms.DataGridView fileListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Selected;
    }
}