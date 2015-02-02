namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class TyumonPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TyumonPrintForm));
            this.YoshiListDataGridView = new System.Windows.Forms.DataGridView();
            this.YoshiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YoshiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectKbnCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.suishitsuMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suishitsuMstDataSet = new FukjBizSystem.Application.DataSet.SuishitsuMstDataSet();
            this.label8 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.GyosyaNmTextBox = new System.Windows.Forms.TextBox();
            this.GyosyaCdTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.YoshiListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // YoshiListDataGridView
            // 
            this.YoshiListDataGridView.AllowUserToResizeRows = false;
            this.YoshiListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YoshiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.YoshiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YoshiCdCol,
            this.YoshiNmCol,
            this.SelectKbnCol});
            this.YoshiListDataGridView.Location = new System.Drawing.Point(21, 176);
            this.YoshiListDataGridView.MultiSelect = false;
            this.YoshiListDataGridView.Name = "YoshiListDataGridView";
            this.YoshiListDataGridView.RowHeadersVisible = false;
            this.YoshiListDataGridView.RowTemplate.Height = 21;
            this.YoshiListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.YoshiListDataGridView.Size = new System.Drawing.Size(1236, 439);
            this.YoshiListDataGridView.TabIndex = 0;
            // 
            // YoshiCdCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.YoshiCdCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.YoshiCdCol.HeaderText = "用紙コード";
            this.YoshiCdCol.MinimumWidth = 150;
            this.YoshiCdCol.Name = "YoshiCdCol";
            this.YoshiCdCol.ReadOnly = true;
            this.YoshiCdCol.Width = 150;
            // 
            // YoshiNmCol
            // 
            this.YoshiNmCol.HeaderText = "用紙名";
            this.YoshiNmCol.MinimumWidth = 600;
            this.YoshiNmCol.Name = "YoshiNmCol";
            this.YoshiNmCol.ReadOnly = true;
            this.YoshiNmCol.Width = 600;
            // 
            // SelectKbnCol
            // 
            this.SelectKbnCol.HeaderText = "選択";
            this.SelectKbnCol.MinimumWidth = 110;
            this.SelectKbnCol.Name = "SelectKbnCol";
            this.SelectKbnCol.ReadOnly = true;
            this.SelectKbnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectKbnCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectKbnCol.Width = 110;
            // 
            // suishitsuMstDataSetBindingSource
            // 
            this.suishitsuMstDataSetBindingSource.DataSource = this.suishitsuMstDataSet;
            this.suishitsuMstDataSetBindingSource.Position = 0;
            // 
            // suishitsuMstDataSet
            // 
            this.suishitsuMstDataSet.DataSetName = "SuishitsuMstDataSet";
            this.suishitsuMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(20, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 41);
            this.label8.TabIndex = 1;
            this.label8.Text = "業者";
            // 
            // outputButton
            // 
            this.outputButton.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.outputButton.Location = new System.Drawing.Point(919, 621);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(166, 87);
            this.outputButton.TabIndex = 8;
            this.outputButton.Text = "F6:注文書出力";
            this.outputButton.UseVisualStyleBackColor = true;
            // 
            // tojiruButton
            // 
            this.tojiruButton.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tojiruButton.Location = new System.Drawing.Point(1091, 621);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(166, 87);
            this.tojiruButton.TabIndex = 9;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 72);
            this.label1.TabIndex = 3;
            this.label1.Text = "注文書出力";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 70);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(20, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 41);
            this.label2.TabIndex = 11;
            this.label2.Text = "注文商品選択";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(696, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 33);
            this.button1.TabIndex = 25;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GyosyaNmTextBox
            // 
            this.GyosyaNmTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.GyosyaNmTextBox.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GyosyaNmTextBox.Location = new System.Drawing.Point(165, 85);
            this.GyosyaNmTextBox.Name = "GyosyaNmTextBox";
            this.GyosyaNmTextBox.Size = new System.Drawing.Size(525, 39);
            this.GyosyaNmTextBox.TabIndex = 24;
            // 
            // GyosyaCdTextBox
            // 
            this.GyosyaCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.GyosyaCdTextBox.CustomDigitParts = 0;
            this.GyosyaCdTextBox.CustomFormat = null;
            this.GyosyaCdTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.GyosyaCdTextBox.CustomReadOnly = false;
            this.GyosyaCdTextBox.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GyosyaCdTextBox.Location = new System.Drawing.Point(93, 85);
            this.GyosyaCdTextBox.MaxLength = 10;
            this.GyosyaCdTextBox.Name = "GyosyaCdTextBox";
            this.GyosyaCdTextBox.Size = new System.Drawing.Size(66, 39);
            this.GyosyaCdTextBox.TabIndex = 23;
            this.GyosyaCdTextBox.Text = "1234";
            // 
            // TyumonPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GyosyaNmTextBox);
            this.Controls.Add(this.GyosyaCdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.YoshiListDataGridView);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TyumonPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注文書出力";
            ((System.ComponentModel.ISupportInitialize)(this.YoshiListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suishitsuMstDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView YoshiListDataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource suishitsuMstDataSetBindingSource;
        private DataSet.SuishitsuMstDataSet suishitsuMstDataSet;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YoshiNmCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectKbnCol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox GyosyaNmTextBox;
        private Control.NumberTextBox GyosyaCdTextBox;

    }
}