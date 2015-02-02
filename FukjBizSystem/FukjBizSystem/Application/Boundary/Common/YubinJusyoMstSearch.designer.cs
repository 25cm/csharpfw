namespace FukjBizSystem.Application.Boundary.Common
{
    partial class YubinJusyoMstSearchForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.jusyoListDataGridView = new System.Windows.Forms.DataGridView();
            this.ZipCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TodofukenCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShikutyosonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyoikiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChihokokyoDantaiCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldZipCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TodofukenKanaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShikutyosonKanaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyoikiKanaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChoikiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yubinNoAdrMstKensakuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yubinNoAdrMstDataSet = new FukjBizSystem.Application.DataSet.YubinNoAdrMstDataSet();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.sentakuButton = new System.Windows.Forms.Button();
            this.jusyoListCountLabel = new System.Windows.Forms.Label();
            this.jusyoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.jusyoListPanel = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.yubinBangoTextBox = new System.Windows.Forms.TextBox();
            this.yubinNoAdrMstKensakuTableAdapter = new FukjBizSystem.Application.DataSet.YubinNoAdrMstDataSetTableAdapters.YubinNoAdrMstKensakuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.jusyoListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstKensakuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataSet)).BeginInit();
            this.jusyoListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(905, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 69;
            this.label8.Text = "検索結果：";
            // 
            // jusyoListDataGridView
            // 
            this.jusyoListDataGridView.AllowUserToAddRows = false;
            this.jusyoListDataGridView.AllowUserToDeleteRows = false;
            this.jusyoListDataGridView.AllowUserToResizeRows = false;
            this.jusyoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jusyoListDataGridView.AutoGenerateColumns = false;
            this.jusyoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jusyoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZipCdCol,
            this.TodofukenCol,
            this.ShikutyosonCol,
            this.TyoikiCol,
            this.ChihokokyoDantaiCdCol,
            this.OldZipCdCol,
            this.TodofukenKanaCol,
            this.ShikutyosonKanaCol,
            this.TyoikiKanaCol,
            this.ChoikiNmCol});
            this.jusyoListDataGridView.DataSource = this.yubinNoAdrMstKensakuBindingSource;
            this.jusyoListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.jusyoListDataGridView.MultiSelect = false;
            this.jusyoListDataGridView.Name = "jusyoListDataGridView";
            this.jusyoListDataGridView.ReadOnly = true;
            this.jusyoListDataGridView.RowHeadersVisible = false;
            this.jusyoListDataGridView.RowTemplate.Height = 21;
            this.jusyoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jusyoListDataGridView.Size = new System.Drawing.Size(1098, 381);
            this.jusyoListDataGridView.TabIndex = 15;
            this.jusyoListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jusyoListDataGridView_CellDoubleClick);
            // 
            // ZipCdCol
            // 
            this.ZipCdCol.DataPropertyName = "ZipCd";
            this.ZipCdCol.HeaderText = "郵便番号";
            this.ZipCdCol.MinimumWidth = 120;
            this.ZipCdCol.Name = "ZipCdCol";
            this.ZipCdCol.ReadOnly = true;
            this.ZipCdCol.Width = 120;
            // 
            // TodofukenCol
            // 
            this.TodofukenCol.DataPropertyName = "TodofukenNm";
            this.TodofukenCol.HeaderText = "都道府県名";
            this.TodofukenCol.MinimumWidth = 120;
            this.TodofukenCol.Name = "TodofukenCol";
            this.TodofukenCol.ReadOnly = true;
            this.TodofukenCol.Width = 120;
            // 
            // ShikutyosonCol
            // 
            this.ShikutyosonCol.DataPropertyName = "ShikuchosonNm";
            this.ShikutyosonCol.HeaderText = "市区町村名";
            this.ShikutyosonCol.MinimumWidth = 300;
            this.ShikutyosonCol.Name = "ShikutyosonCol";
            this.ShikutyosonCol.ReadOnly = true;
            this.ShikutyosonCol.Width = 300;
            // 
            // TyoikiCol
            // 
            this.TyoikiCol.DataPropertyName = "ChoikiNm";
            this.TyoikiCol.HeaderText = "町域名";
            this.TyoikiCol.MinimumWidth = 200;
            this.TyoikiCol.Name = "TyoikiCol";
            this.TyoikiCol.ReadOnly = true;
            this.TyoikiCol.Width = 200;
            // 
            // ChihokokyoDantaiCdCol
            // 
            this.ChihokokyoDantaiCdCol.DataPropertyName = "ChihoKokyoDantaiCd";
            this.ChihokokyoDantaiCdCol.HeaderText = "全国地方公共団体コード";
            this.ChihokokyoDantaiCdCol.MinimumWidth = 200;
            this.ChihokokyoDantaiCdCol.Name = "ChihokokyoDantaiCdCol";
            this.ChihokokyoDantaiCdCol.ReadOnly = true;
            this.ChihokokyoDantaiCdCol.Width = 200;
            // 
            // OldZipCdCol
            // 
            this.OldZipCdCol.DataPropertyName = "OldZipCd";
            this.OldZipCdCol.HeaderText = "OldZipCd";
            this.OldZipCdCol.Name = "OldZipCdCol";
            this.OldZipCdCol.ReadOnly = true;
            this.OldZipCdCol.Visible = false;
            // 
            // TodofukenKanaCol
            // 
            this.TodofukenKanaCol.DataPropertyName = "TodofukenKana";
            this.TodofukenKanaCol.HeaderText = "TodofukenKana";
            this.TodofukenKanaCol.Name = "TodofukenKanaCol";
            this.TodofukenKanaCol.ReadOnly = true;
            this.TodofukenKanaCol.Visible = false;
            // 
            // ShikutyosonKanaCol
            // 
            this.ShikutyosonKanaCol.DataPropertyName = "ShikuchosonKana";
            this.ShikutyosonKanaCol.HeaderText = "ShikuchosonKana";
            this.ShikutyosonKanaCol.Name = "ShikutyosonKanaCol";
            this.ShikutyosonKanaCol.ReadOnly = true;
            this.ShikutyosonKanaCol.Visible = false;
            // 
            // TyoikiKanaCol
            // 
            this.TyoikiKanaCol.DataPropertyName = "ChoikiKana";
            this.TyoikiKanaCol.HeaderText = "ChoikiKana";
            this.TyoikiKanaCol.Name = "TyoikiKanaCol";
            this.TyoikiKanaCol.ReadOnly = true;
            this.TyoikiKanaCol.Visible = false;
            // 
            // ChoikiNmCol
            // 
            this.ChoikiNmCol.DataPropertyName = "ChoikiNm";
            this.ChoikiNmCol.HeaderText = "ChoikiNmCol";
            this.ChoikiNmCol.Name = "ChoikiNmCol";
            this.ChoikiNmCol.ReadOnly = true;
            this.ChoikiNmCol.Visible = false;
            // 
            // yubinNoAdrMstKensakuBindingSource
            // 
            this.yubinNoAdrMstKensakuBindingSource.DataMember = "YubinNoAdrMstKensaku";
            this.yubinNoAdrMstKensakuBindingSource.DataSource = this.yubinNoAdrMstDataSet;
            // 
            // yubinNoAdrMstDataSet
            // 
            this.yubinNoAdrMstDataSet.DataSetName = "YubinNoAdrMstDataSet";
            this.yubinNoAdrMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tojiruButton
            // 
            this.tojiruButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tojiruButton.Location = new System.Drawing.Point(993, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 17;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // sentakuButton
            // 
            this.sentakuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sentakuButton.Location = new System.Drawing.Point(885, 544);
            this.sentakuButton.Name = "sentakuButton";
            this.sentakuButton.Size = new System.Drawing.Size(101, 37);
            this.sentakuButton.TabIndex = 16;
            this.sentakuButton.Text = "F1:選択戻り";
            this.sentakuButton.UseVisualStyleBackColor = true;
            this.sentakuButton.Click += new System.EventHandler(this.sentakuButton_Click);
            // 
            // jusyoListCountLabel
            // 
            this.jusyoListCountLabel.AutoSize = true;
            this.jusyoListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.jusyoListCountLabel.Name = "jusyoListCountLabel";
            this.jusyoListCountLabel.Size = new System.Drawing.Size(33, 21);
            this.jusyoListCountLabel.TabIndex = 70;
            this.jusyoListCountLabel.Text = "0件";
            // 
            // jusyoTextBox
            // 
            this.jusyoTextBox.Location = new System.Drawing.Point(134, 67);
            this.jusyoTextBox.MaxLength = 50;
            this.jusyoTextBox.Name = "jusyoTextBox";
            this.jusyoTextBox.Size = new System.Drawing.Size(305, 27);
            this.jusyoTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "住所";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1071, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 5;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.viewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 21);
            this.label19.TabIndex = 1;
            this.label19.Text = "郵便番号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索条件";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(885, 71);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kensakuButton.Location = new System.Drawing.Point(992, 70);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 4;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // jusyoListPanel
            // 
            this.jusyoListPanel.Controls.Add(this.jusyoListCountLabel);
            this.jusyoListPanel.Controls.Add(this.label8);
            this.jusyoListPanel.Controls.Add(this.jusyoListDataGridView);
            this.jusyoListPanel.Location = new System.Drawing.Point(1, 130);
            this.jusyoListPanel.Name = "jusyoListPanel";
            this.jusyoListPanel.Size = new System.Drawing.Size(1103, 408);
            this.jusyoListPanel.TabIndex = 15;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.yubinBangoTextBox);
            this.searchPanel.Controls.Add(this.jusyoTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 122);
            this.searchPanel.TabIndex = 0;
            // 
            // yubinBangoTextBox
            // 
            this.yubinBangoTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.yubinBangoTextBox.Location = new System.Drawing.Point(134, 34);
            this.yubinBangoTextBox.MaxLength = 8;
            this.yubinBangoTextBox.Name = "yubinBangoTextBox";
            this.yubinBangoTextBox.Size = new System.Drawing.Size(82, 27);
            this.yubinBangoTextBox.TabIndex = 1;
            this.yubinBangoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yubinBangoTextBox_KeyPress);
            // 
            // yubinNoAdrMstKensakuTableAdapter
            // 
            this.yubinNoAdrMstKensakuTableAdapter.ClearBeforeFill = true;
            // 
            // YubinJusyoMstSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.sentakuButton);
            this.Controls.Add(this.jusyoListPanel);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("Meiryo", 10F);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1119, 631);
            this.Name = "YubinJusyoMstSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "郵便番号住所マスタ検索";
            this.Load += new System.EventHandler(this.YubinJusyoMstSearchForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YubinJusyoMstSearchForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.jusyoListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstKensakuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataSet)).EndInit();
            this.jusyoListPanel.ResumeLayout(false);
            this.jusyoListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView jusyoListDataGridView;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button sentakuButton;
        private System.Windows.Forms.Label jusyoListCountLabel;
        private System.Windows.Forms.TextBox jusyoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Panel jusyoListPanel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox yubinBangoTextBox;
        private DataSet.YubinNoAdrMstDataSet yubinNoAdrMstDataSet;
        private System.Windows.Forms.BindingSource yubinNoAdrMstKensakuBindingSource;
        private DataSet.YubinNoAdrMstDataSetTableAdapters.YubinNoAdrMstKensakuTableAdapter yubinNoAdrMstKensakuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TodofukenCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShikutyosonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyoikiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChihokokyoDantaiCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldZipCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TodofukenKanaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShikutyosonKanaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyoikiKanaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChoikiNmCol;
    }
}