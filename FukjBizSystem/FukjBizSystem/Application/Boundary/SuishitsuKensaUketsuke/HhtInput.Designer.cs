namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    partial class HhtInputForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.kensaIraiListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.butchInputButton = new Zynas.Control.ZButton(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.haneiButton = new Zynas.Control.ZButton(this.components);
            this.tojiruButton = new Zynas.Control.ZButton(this.components);
            this.kentaiNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShishoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoSetchishaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoHokenjoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoTorokuNendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiHoteiKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiHokenjoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiNendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EdabanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TorikomiJyokyoFlgCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoSetchishaKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kentaiNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.kensaIraiListDataGridView);
            this.mainPanel.Controls.Add(this.butchInputButton);
            this.mainPanel.Controls.Add(this.kentaiNoTextBox);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.haneiButton);
            this.mainPanel.Controls.Add(this.tojiruButton);
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(323, 405);
            this.mainPanel.TabIndex = 0;
            // 
            // kensaIraiListDataGridView
            // 
            this.kensaIraiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kensaIraiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kentaiNoCol,
            this.barcodeNoCol,
            this.ShishoCdCol,
            this.JokasoSetchishaCdCol,
            this.JokasoHokenjoCdCol,
            this.JokasoTorokuNendoCol,
            this.JokasoRenbanCol,
            this.KensaIraiHoteiKbnCol,
            this.KensaIraiHokenjoCdCol,
            this.KensaIraiNendoCol,
            this.KensaIraiRenbanCol,
            this.EdabanCol,
            this.TorikomiJyokyoFlgCol,
            this.JokasoSetchishaKbnCol});
            this.kensaIraiListDataGridView.Location = new System.Drawing.Point(3, 43);
            this.kensaIraiListDataGridView.Name = "kensaIraiListDataGridView";
            this.kensaIraiListDataGridView.RowTemplate.Height = 21;
            this.kensaIraiListDataGridView.Size = new System.Drawing.Size(315, 315);
            this.kensaIraiListDataGridView.TabIndex = 1;
            this.kensaIraiListDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.kensaIraiListDataGridView_CellValueChanged);
            // 
            // butchInputButton
            // 
            this.butchInputButton.Location = new System.Drawing.Point(110, 364);
            this.butchInputButton.Name = "butchInputButton";
            this.butchInputButton.Size = new System.Drawing.Size(101, 37);
            this.butchInputButton.TabIndex = 3;
            this.butchInputButton.Text = "F2:連番付与";
            this.butchInputButton.UseVisualStyleBackColor = true;
            this.butchInputButton.Click += new System.EventHandler(this.butchInputButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "検体番号(開始番号)";
            // 
            // haneiButton
            // 
            this.haneiButton.Location = new System.Drawing.Point(3, 364);
            this.haneiButton.Name = "haneiButton";
            this.haneiButton.Size = new System.Drawing.Size(101, 37);
            this.haneiButton.TabIndex = 2;
            this.haneiButton.Text = "F1:反映";
            this.haneiButton.UseVisualStyleBackColor = true;
            this.haneiButton.Click += new System.EventHandler(this.haneiButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(217, 364);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 4;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // kentaiNoCol
            // 
            this.kentaiNoCol.DataPropertyName = "KentaiNo";
            this.kentaiNoCol.HeaderText = "検体番号";
            this.kentaiNoCol.Name = "kentaiNoCol";
            // 
            // barcodeNoCol
            // 
            this.barcodeNoCol.DataPropertyName = "BarcodeNo";
            this.barcodeNoCol.HeaderText = "バーコード番号";
            this.barcodeNoCol.Name = "barcodeNoCol";
            this.barcodeNoCol.Width = 140;
            // 
            // ShishoCdCol
            // 
            this.ShishoCdCol.DataPropertyName = "ShishoCd";
            this.ShishoCdCol.HeaderText = "ShishoCd";
            this.ShishoCdCol.Name = "ShishoCdCol";
            this.ShishoCdCol.Visible = false;
            // 
            // JokasoSetchishaCdCol
            // 
            this.JokasoSetchishaCdCol.DataPropertyName = "JokasoSetchishaCd";
            this.JokasoSetchishaCdCol.HeaderText = "JokasoSetchishaCd";
            this.JokasoSetchishaCdCol.Name = "JokasoSetchishaCdCol";
            this.JokasoSetchishaCdCol.Visible = false;
            // 
            // JokasoHokenjoCdCol
            // 
            this.JokasoHokenjoCdCol.DataPropertyName = "JokasoHokenjoCd";
            this.JokasoHokenjoCdCol.HeaderText = "JokasoHokenjoCd";
            this.JokasoHokenjoCdCol.Name = "JokasoHokenjoCdCol";
            this.JokasoHokenjoCdCol.Visible = false;
            // 
            // JokasoTorokuNendoCol
            // 
            this.JokasoTorokuNendoCol.DataPropertyName = "JokasoTorokuNendo";
            this.JokasoTorokuNendoCol.HeaderText = "JokasoTorokuNendo";
            this.JokasoTorokuNendoCol.Name = "JokasoTorokuNendoCol";
            this.JokasoTorokuNendoCol.Visible = false;
            // 
            // JokasoRenbanCol
            // 
            this.JokasoRenbanCol.DataPropertyName = "JokasoRenban";
            this.JokasoRenbanCol.HeaderText = "JokasoRenban";
            this.JokasoRenbanCol.Name = "JokasoRenbanCol";
            this.JokasoRenbanCol.Visible = false;
            // 
            // KensaIraiHoteiKbnCol
            // 
            this.KensaIraiHoteiKbnCol.DataPropertyName = "KensaIraiHoteiKbn";
            this.KensaIraiHoteiKbnCol.HeaderText = "KensaIraiHoteiKbn";
            this.KensaIraiHoteiKbnCol.Name = "KensaIraiHoteiKbnCol";
            this.KensaIraiHoteiKbnCol.Visible = false;
            // 
            // KensaIraiHokenjoCdCol
            // 
            this.KensaIraiHokenjoCdCol.DataPropertyName = "KensaIraiHokenjoCd";
            this.KensaIraiHokenjoCdCol.HeaderText = "KensaIraiHokenjoCd";
            this.KensaIraiHokenjoCdCol.Name = "KensaIraiHokenjoCdCol";
            this.KensaIraiHokenjoCdCol.Visible = false;
            // 
            // KensaIraiNendoCol
            // 
            this.KensaIraiNendoCol.DataPropertyName = "KensaIraiNendo";
            this.KensaIraiNendoCol.HeaderText = "KensaIraiNendo";
            this.KensaIraiNendoCol.Name = "KensaIraiNendoCol";
            this.KensaIraiNendoCol.Visible = false;
            // 
            // KensaIraiRenbanCol
            // 
            this.KensaIraiRenbanCol.DataPropertyName = "KensaIraiRenban";
            this.KensaIraiRenbanCol.HeaderText = "KensaIraiRenban";
            this.KensaIraiRenbanCol.Name = "KensaIraiRenbanCol";
            this.KensaIraiRenbanCol.Visible = false;
            // 
            // EdabanCol
            // 
            this.EdabanCol.DataPropertyName = "Edaban";
            this.EdabanCol.HeaderText = "Edaban";
            this.EdabanCol.Name = "EdabanCol";
            this.EdabanCol.Visible = false;
            // 
            // TorikomiJyokyoFlgCol
            // 
            this.TorikomiJyokyoFlgCol.DataPropertyName = "TorikomiJyokyoFlg";
            this.TorikomiJyokyoFlgCol.HeaderText = "TorikomiJyokyoFlg";
            this.TorikomiJyokyoFlgCol.Name = "TorikomiJyokyoFlgCol";
            this.TorikomiJyokyoFlgCol.Visible = false;
            // 
            // JokasoSetchishaKbnCol
            // 
            this.JokasoSetchishaKbnCol.DataPropertyName = "JokasoSetchishaKbn";
            this.JokasoSetchishaKbnCol.HeaderText = "JokasoSetchishaKbn";
            this.JokasoSetchishaKbnCol.Name = "JokasoSetchishaKbnCol";
            this.JokasoSetchishaKbnCol.Visible = false;
            // 
            // kentaiNoTextBox
            // 
            this.kentaiNoTextBox.AllowDropDown = false;
            this.kentaiNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kentaiNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kentaiNoTextBox.CustomReadOnly = false;
            this.kentaiNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kentaiNoTextBox.Location = new System.Drawing.Point(135, 8);
            this.kentaiNoTextBox.MaxLength = 6;
            this.kentaiNoTextBox.Name = "kentaiNoTextBox";
            this.kentaiNoTextBox.Size = new System.Drawing.Size(76, 27);
            this.kentaiNoTextBox.TabIndex = 0;
            // 
            // HhtInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 407);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HhtInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "検査依頼手入力";
            this.Load += new System.EventHandler(this.HhtInputForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton haneiButton;
        private System.Windows.Forms.Panel mainPanel;
        private Zynas.Control.ZButton tojiruButton;
        private System.Windows.Forms.Label label7;
        private Control.ZTextBox kentaiNoTextBox;
        private Zynas.Control.ZButton butchInputButton;
        private Zynas.Control.ZDataGridView.ZDataGridView kensaIraiListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn kentaiNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShishoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoSetchishaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoHokenjoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoTorokuNendoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoRenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiHoteiKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiHokenjoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiNendoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiRenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn EdabanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TorikomiJyokyoFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoSetchishaKbnCol;
    }
}