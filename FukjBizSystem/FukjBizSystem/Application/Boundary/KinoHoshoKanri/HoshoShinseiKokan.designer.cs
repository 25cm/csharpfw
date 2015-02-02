namespace FukjBizSystem.Application.Boundary.KinoHoshoKanri
{
    partial class HoshoShinseiKokanForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.maisuTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.newHoshoTorokuNoFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.oldHoshoTorokuInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.newHoshoTorokuNoToTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exChangeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.OldHoshoTorokuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoshoTorokuTorisageDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoshoTorokuHanbaisakiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoshoTorokuUriageDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewHoshoTorokuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoshoTorokuShishoKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoshoTorokuHanbaisakiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldHoshoTorokuInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(832, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "新保証No(開始)";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.maisuTextBox);
            this.mainPanel.Controls.Add(this.newHoshoTorokuNoFromTextBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.oldHoshoTorokuInfoDataGridView);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.newHoshoTorokuNoToTextBox);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.exChangeButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 593);
            this.mainPanel.TabIndex = 4;
            // 
            // maisuTextBox
            // 
            this.maisuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.maisuTextBox.CustomDigitParts = 0;
            this.maisuTextBox.CustomFormat = null;
            this.maisuTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.maisuTextBox.CustomReadOnly = false;
            this.maisuTextBox.Location = new System.Drawing.Point(954, 78);
            this.maisuTextBox.Name = "maisuTextBox";
            this.maisuTextBox.Size = new System.Drawing.Size(120, 27);
            this.maisuTextBox.TabIndex = 3;
            this.maisuTextBox.Leave += new System.EventHandler(this.maisuTextBox_Leave);
            // 
            // newHoshoTorokuNoFromTextBox
            // 
            this.newHoshoTorokuNoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.newHoshoTorokuNoFromTextBox.CustomDigitParts = 0;
            this.newHoshoTorokuNoFromTextBox.CustomFormat = null;
            this.newHoshoTorokuNoFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.newHoshoTorokuNoFromTextBox.CustomReadOnly = false;
            this.newHoshoTorokuNoFromTextBox.Location = new System.Drawing.Point(954, 12);
            this.newHoshoTorokuNoFromTextBox.MaxLength = 11;
            this.newHoshoTorokuNoFromTextBox.Name = "newHoshoTorokuNoFromTextBox";
            this.newHoshoTorokuNoFromTextBox.Size = new System.Drawing.Size(120, 27);
            this.newHoshoTorokuNoFromTextBox.TabIndex = 1;
            this.newHoshoTorokuNoFromTextBox.Leave += new System.EventHandler(this.newHoshoTorokuNoFromTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(862, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 117;
            this.label2.Text = "*";
            // 
            // oldHoshoTorokuInfoDataGridView
            // 
            this.oldHoshoTorokuInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oldHoshoTorokuInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OldHoshoTorokuNoCol,
            this.HoshoTorokuTorisageDtCol,
            this.ShishoNmCol,
            this.HoshoTorokuHanbaisakiNmCol,
            this.HoshoTorokuUriageDtCol,
            this.NewHoshoTorokuNoCol,
            this.HoshoTorokuShishoKbnCol,
            this.HoshoTorokuHanbaisakiCdCol,
            this.UpdateDtCol});
            this.oldHoshoTorokuInfoDataGridView.Location = new System.Drawing.Point(12, 12);
            this.oldHoshoTorokuInfoDataGridView.Name = "oldHoshoTorokuInfoDataGridView";
            this.oldHoshoTorokuInfoDataGridView.RowHeadersVisible = false;
            this.oldHoshoTorokuInfoDataGridView.RowTemplate.Height = 21;
            this.oldHoshoTorokuInfoDataGridView.Size = new System.Drawing.Size(801, 511);
            this.oldHoshoTorokuInfoDataGridView.TabIndex = 0;
            this.oldHoshoTorokuInfoDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.oldHoshoTorokuInfoDataGridView_CellValidating);
            this.oldHoshoTorokuInfoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.oldHoshoTorokuInfoDataGridView_EditingControlShowing);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(832, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "新保証No(終了)";
            // 
            // newHoshoTorokuNoToTextBox
            // 
            this.newHoshoTorokuNoToTextBox.Enabled = false;
            this.newHoshoTorokuNoToTextBox.Location = new System.Drawing.Point(954, 45);
            this.newHoshoTorokuNoToTextBox.Name = "newHoshoTorokuNoToTextBox";
            this.newHoshoTorokuNoToTextBox.Size = new System.Drawing.Size(120, 27);
            this.newHoshoTorokuNoToTextBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(930, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(832, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "枚数";
            // 
            // exChangeButton
            // 
            this.exChangeButton.Location = new System.Drawing.Point(849, 553);
            this.exChangeButton.Name = "exChangeButton";
            this.exChangeButton.Size = new System.Drawing.Size(101, 37);
            this.exChangeButton.TabIndex = 4;
            this.exChangeButton.Text = "F1:交換";
            this.exChangeButton.UseVisualStyleBackColor = true;
            this.exChangeButton.Click += new System.EventHandler(this.exChangeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // OldHoshoTorokuNoCol
            // 
            this.OldHoshoTorokuNoCol.HeaderText = "旧保証No";
            this.OldHoshoTorokuNoCol.MaxInputLength = 11;
            this.OldHoshoTorokuNoCol.MinimumWidth = 120;
            this.OldHoshoTorokuNoCol.Name = "OldHoshoTorokuNoCol";
            this.OldHoshoTorokuNoCol.Width = 120;
            // 
            // HoshoTorokuTorisageDtCol
            // 
            this.HoshoTorokuTorisageDtCol.HeaderText = "取下日";
            this.HoshoTorokuTorisageDtCol.MaxInputLength = 8;
            this.HoshoTorokuTorisageDtCol.MinimumWidth = 100;
            this.HoshoTorokuTorisageDtCol.Name = "HoshoTorokuTorisageDtCol";
            // 
            // ShishoNmCol
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.ShishoNmCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShishoNmCol.HeaderText = "支所";
            this.ShishoNmCol.MinimumWidth = 200;
            this.ShishoNmCol.Name = "ShishoNmCol";
            this.ShishoNmCol.ReadOnly = true;
            this.ShishoNmCol.Width = 200;
            // 
            // HoshoTorokuHanbaisakiNmCol
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.HoshoTorokuHanbaisakiNmCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.HoshoTorokuHanbaisakiNmCol.HeaderText = "販売先";
            this.HoshoTorokuHanbaisakiNmCol.MinimumWidth = 200;
            this.HoshoTorokuHanbaisakiNmCol.Name = "HoshoTorokuHanbaisakiNmCol";
            this.HoshoTorokuHanbaisakiNmCol.ReadOnly = true;
            this.HoshoTorokuHanbaisakiNmCol.Width = 200;
            // 
            // HoshoTorokuUriageDtCol
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.HoshoTorokuUriageDtCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.HoshoTorokuUriageDtCol.HeaderText = "売上日";
            this.HoshoTorokuUriageDtCol.MinimumWidth = 100;
            this.HoshoTorokuUriageDtCol.Name = "HoshoTorokuUriageDtCol";
            this.HoshoTorokuUriageDtCol.ReadOnly = true;
            // 
            // NewHoshoTorokuNoCol
            // 
            this.NewHoshoTorokuNoCol.HeaderText = "新保証No";
            this.NewHoshoTorokuNoCol.Name = "NewHoshoTorokuNoCol";
            this.NewHoshoTorokuNoCol.Visible = false;
            // 
            // HoshoTorokuShishoKbnCol
            // 
            this.HoshoTorokuShishoKbnCol.HeaderText = "支所区分";
            this.HoshoTorokuShishoKbnCol.Name = "HoshoTorokuShishoKbnCol";
            this.HoshoTorokuShishoKbnCol.ReadOnly = true;
            this.HoshoTorokuShishoKbnCol.Visible = false;
            // 
            // HoshoTorokuHanbaisakiCdCol
            // 
            this.HoshoTorokuHanbaisakiCdCol.HeaderText = "販売先コード";
            this.HoshoTorokuHanbaisakiCdCol.Name = "HoshoTorokuHanbaisakiCdCol";
            this.HoshoTorokuHanbaisakiCdCol.ReadOnly = true;
            this.HoshoTorokuHanbaisakiCdCol.Visible = false;
            // 
            // UpdateDtCol
            // 
            this.UpdateDtCol.HeaderText = "UpdateDt";
            this.UpdateDtCol.Name = "UpdateDtCol";
            this.UpdateDtCol.Visible = false;
            // 
            // HoshoShinseiKokanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HoshoShinseiKokanForm";
            this.Text = "保証申請書交換";
            this.Load += new System.EventHandler(this.HoshoShinseiKokanForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HoshoShinseiKokanForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldHoshoTorokuInfoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button exChangeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox newHoshoTorokuNoToTextBox;
        private System.Windows.Forms.DataGridView oldHoshoTorokuInfoDataGridView;
        private System.Windows.Forms.Label label2;
        private Control.NumberTextBox newHoshoTorokuNoFromTextBox;
        private Control.NumberTextBox maisuTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldHoshoTorokuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoshoTorokuTorisageDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoshoTorokuHanbaisakiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoshoTorokuUriageDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewHoshoTorokuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoshoTorokuShishoKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoshoTorokuHanbaisakiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDtCol;
    }
}