namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    partial class JyukoshaInputForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jyukoshaListDataGridView = new System.Windows.Forms.DataGridView();
            this.SaisuiinCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaisuiinNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyozokuGyosyaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yukokigenDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.kaisaibiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.entryButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jyukoshaListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.jyukoshaListDataGridView);
            this.mainPanel.Controls.Add(this.yukokigenDateTimePicker);
            this.mainPanel.Controls.Add(this.label25);
            this.mainPanel.Controls.Add(this.kaisaibiDateTimePicker);
            this.mainPanel.Controls.Add(this.label22);
            this.mainPanel.Controls.Add(this.label23);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 593);
            this.mainPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(85, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 188;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 187;
            this.label2.Text = "受講者一覧";
            // 
            // jyukoshaListDataGridView
            // 
            this.jyukoshaListDataGridView.AllowUserToResizeRows = false;
            this.jyukoshaListDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.jyukoshaListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jyukoshaListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaisuiinCdCol,
            this.SaisuiinNmCol,
            this.SyozokuGyosyaNmCol,
            this.UpdateDtCol});
            this.jyukoshaListDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.jyukoshaListDataGridView.Location = new System.Drawing.Point(19, 75);
            this.jyukoshaListDataGridView.MultiSelect = false;
            this.jyukoshaListDataGridView.Name = "jyukoshaListDataGridView";
            this.jyukoshaListDataGridView.RowHeadersVisible = false;
            this.jyukoshaListDataGridView.RowTemplate.Height = 21;
            this.jyukoshaListDataGridView.Size = new System.Drawing.Size(1072, 451);
            this.jyukoshaListDataGridView.TabIndex = 2;
            this.jyukoshaListDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.jyukoshaListDataGridView_CellValueChanged);
            this.jyukoshaListDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.jyukoshaListDataGridView_EditingControlShowing);
            // 
            // SaisuiinCdCol
            // 
            this.SaisuiinCdCol.HeaderText = "採水員コード";
            this.SaisuiinCdCol.MaxInputLength = 5;
            this.SaisuiinCdCol.MinimumWidth = 130;
            this.SaisuiinCdCol.Name = "SaisuiinCdCol";
            this.SaisuiinCdCol.Width = 130;
            // 
            // SaisuiinNmCol
            // 
            this.SaisuiinNmCol.HeaderText = "採水員名";
            this.SaisuiinNmCol.MinimumWidth = 300;
            this.SaisuiinNmCol.Name = "SaisuiinNmCol";
            this.SaisuiinNmCol.ReadOnly = true;
            this.SaisuiinNmCol.Width = 300;
            // 
            // SyozokuGyosyaNmCol
            // 
            this.SyozokuGyosyaNmCol.HeaderText = "所属業者";
            this.SyozokuGyosyaNmCol.MinimumWidth = 300;
            this.SyozokuGyosyaNmCol.Name = "SyozokuGyosyaNmCol";
            this.SyozokuGyosyaNmCol.ReadOnly = true;
            this.SyozokuGyosyaNmCol.Width = 300;
            // 
            // UpdateDtCol
            // 
            this.UpdateDtCol.HeaderText = "UpdateDt";
            this.UpdateDtCol.Name = "UpdateDtCol";
            this.UpdateDtCol.Visible = false;
            // 
            // yukokigenDateTimePicker
            // 
            this.yukokigenDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.yukokigenDateTimePicker.Enabled = false;
            this.yukokigenDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yukokigenDateTimePicker.Location = new System.Drawing.Point(324, 16);
            this.yukokigenDateTimePicker.Name = "yukokigenDateTimePicker";
            this.yukokigenDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.yukokigenDateTimePicker.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(257, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 20);
            this.label25.TabIndex = 183;
            this.label25.Text = "有効期限";
            // 
            // kaisaibiDateTimePicker
            // 
            this.kaisaibiDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kaisaibiDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kaisaibiDateTimePicker.Location = new System.Drawing.Point(80, 16);
            this.kaisaibiDateTimePicker.Name = "kaisaibiDateTimePicker";
            this.kaisaibiDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.kaisaibiDateTimePicker.TabIndex = 0;
            this.kaisaibiDateTimePicker.ValueChanged += new System.EventHandler(this.kaisaibiDateTimePicker_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(57, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 20);
            this.label22.TabIndex = 181;
            this.label22.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(15, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 20);
            this.label23.TabIndex = 180;
            this.label23.Text = "開催日";
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(849, 553);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 3;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // JyukoshaInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1103, 593);
            this.Name = "JyukoshaInputForm";
            this.Text = "受講者一覧";
            this.Load += new System.EventHandler(this.JyukoshaInputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JyukoshaInputForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jyukoshaListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView jyukoshaListDataGridView;
        private System.Windows.Forms.DateTimePicker yukokigenDateTimePicker;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker kaisaibiDateTimePicker;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaisuiinCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaisuiinNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyozokuGyosyaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDtCol;
    }
}