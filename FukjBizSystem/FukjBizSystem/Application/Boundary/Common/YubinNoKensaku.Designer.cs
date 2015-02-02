namespace FukjBizSystem.Application.Boundary.Common
{
    partial class YubinNoKensaku
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
            this.todofukenComboBox = new System.Windows.Forms.ComboBox();
            this.todofukenInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yubinNoAdrMstDataSet = new FukjBizSystem.Application.DataSet.YubinNoAdrMstKensakuDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yubinNoAdrMstDataGridView = new System.Windows.Forms.DataGridView();
            this.zipCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todofukenNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shikuchosonNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choikiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chihoKokyoDantaiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yubinNoAdrMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.todofukenInfoTableAdapter = new FukjBizSystem.Application.DataSet.YubinNoAdrMstKensakuDataSetTableAdapters.TodofukenInfoTableAdapter();
            this.adrTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.todofukenInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // todofukenComboBox
            // 
            this.todofukenComboBox.DataSource = this.todofukenInfoBindingSource;
            this.todofukenComboBox.DisplayMember = "TodofukenNm";
            this.todofukenComboBox.FormattingEnabled = true;
            this.todofukenComboBox.Location = new System.Drawing.Point(86, 23);
            this.todofukenComboBox.Name = "todofukenComboBox";
            this.todofukenComboBox.Size = new System.Drawing.Size(121, 28);
            this.todofukenComboBox.TabIndex = 0;
            // 
            // todofukenInfoBindingSource
            // 
            this.todofukenInfoBindingSource.DataMember = "TodofukenInfo";
            this.todofukenInfoBindingSource.DataSource = this.yubinNoAdrMstDataSet;
            // 
            // yubinNoAdrMstDataSet
            // 
            this.yubinNoAdrMstDataSet.DataSetName = "YubinNoAdrMstDataSet";
            this.yubinNoAdrMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "都道府県";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "住所";
            // 
            // yubinNoAdrMstDataGridView
            // 
            this.yubinNoAdrMstDataGridView.AllowUserToAddRows = false;
            this.yubinNoAdrMstDataGridView.AllowUserToDeleteRows = false;
            this.yubinNoAdrMstDataGridView.AutoGenerateColumns = false;
            this.yubinNoAdrMstDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yubinNoAdrMstDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zipCdDataGridViewTextBoxColumn,
            this.todofukenNmDataGridViewTextBoxColumn,
            this.shikuchosonNmDataGridViewTextBoxColumn,
            this.choikiNmDataGridViewTextBoxColumn,
            this.chihoKokyoDantaiCdDataGridViewTextBoxColumn});
            this.yubinNoAdrMstDataGridView.DataMember = "YubinNoAdrMst";
            this.yubinNoAdrMstDataGridView.DataSource = this.yubinNoAdrMstDataSetBindingSource;
            this.yubinNoAdrMstDataGridView.Location = new System.Drawing.Point(23, 72);
            this.yubinNoAdrMstDataGridView.MultiSelect = false;
            this.yubinNoAdrMstDataGridView.Name = "yubinNoAdrMstDataGridView";
            this.yubinNoAdrMstDataGridView.ReadOnly = true;
            this.yubinNoAdrMstDataGridView.RowHeadersVisible = false;
            this.yubinNoAdrMstDataGridView.RowTemplate.Height = 21;
            this.yubinNoAdrMstDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.yubinNoAdrMstDataGridView.Size = new System.Drawing.Size(633, 283);
            this.yubinNoAdrMstDataGridView.TabIndex = 3;
            this.yubinNoAdrMstDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.yubinNoAdrMstDataGridView_CellDoubleClick);
            // 
            // zipCdDataGridViewTextBoxColumn
            // 
            this.zipCdDataGridViewTextBoxColumn.DataPropertyName = "ZipCd";
            this.zipCdDataGridViewTextBoxColumn.HeaderText = "郵便番号";
            this.zipCdDataGridViewTextBoxColumn.Name = "zipCdDataGridViewTextBoxColumn";
            this.zipCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.zipCdDataGridViewTextBoxColumn.Width = 90;
            // 
            // todofukenNmDataGridViewTextBoxColumn
            // 
            this.todofukenNmDataGridViewTextBoxColumn.DataPropertyName = "TodofukenNm";
            this.todofukenNmDataGridViewTextBoxColumn.HeaderText = "都道府県名";
            this.todofukenNmDataGridViewTextBoxColumn.Name = "todofukenNmDataGridViewTextBoxColumn";
            this.todofukenNmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shikuchosonNmDataGridViewTextBoxColumn
            // 
            this.shikuchosonNmDataGridViewTextBoxColumn.DataPropertyName = "ShikuchosonNm";
            this.shikuchosonNmDataGridViewTextBoxColumn.HeaderText = "市区町村名";
            this.shikuchosonNmDataGridViewTextBoxColumn.Name = "shikuchosonNmDataGridViewTextBoxColumn";
            this.shikuchosonNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.shikuchosonNmDataGridViewTextBoxColumn.Width = 150;
            // 
            // choikiNmDataGridViewTextBoxColumn
            // 
            this.choikiNmDataGridViewTextBoxColumn.DataPropertyName = "ChoikiNm";
            this.choikiNmDataGridViewTextBoxColumn.HeaderText = "町域名";
            this.choikiNmDataGridViewTextBoxColumn.Name = "choikiNmDataGridViewTextBoxColumn";
            this.choikiNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.choikiNmDataGridViewTextBoxColumn.Width = 170;
            // 
            // chihoKokyoDantaiCdDataGridViewTextBoxColumn
            // 
            this.chihoKokyoDantaiCdDataGridViewTextBoxColumn.DataPropertyName = "ChihoKokyoDantaiCd";
            this.chihoKokyoDantaiCdDataGridViewTextBoxColumn.HeaderText = "地区コード";
            this.chihoKokyoDantaiCdDataGridViewTextBoxColumn.Name = "chihoKokyoDantaiCdDataGridViewTextBoxColumn";
            this.chihoKokyoDantaiCdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yubinNoAdrMstDataSetBindingSource
            // 
            this.yubinNoAdrMstDataSetBindingSource.DataSource = this.yubinNoAdrMstDataSet;
            this.yubinNoAdrMstDataSetBindingSource.Position = 0;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(421, 361);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(101, 37);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "F1:選択戻り";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(555, 361);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(555, 19);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 2;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // todofukenInfoTableAdapter
            // 
            this.todofukenInfoTableAdapter.ClearBeforeFill = true;
            // 
            // adrTextBox
            // 
            this.adrTextBox.AllowDropDown = false;
            this.adrTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.adrTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.adrTextBox.CustomReadOnly = false;
            this.adrTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.adrTextBox.Location = new System.Drawing.Point(273, 24);
            this.adrTextBox.Name = "adrTextBox";
            this.adrTextBox.Size = new System.Drawing.Size(275, 27);
            this.adrTextBox.TabIndex = 1;
            // 
            // YubinNoKensaku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 410);
            this.Controls.Add(this.kensakuButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.yubinNoAdrMstDataGridView);
            this.Controls.Add(this.adrTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.todofukenComboBox);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YubinNoKensaku";
            this.Text = "郵便番号・住所検索";
            this.Load += new System.EventHandler(this.YubinNoKensaku_Load);
            ((System.ComponentModel.ISupportInitialize)(this.todofukenInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yubinNoAdrMstDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox todofukenComboBox;
        private System.Windows.Forms.Label label1;
        private Control.ZTextBox adrTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView yubinNoAdrMstDataGridView;
        private System.Windows.Forms.BindingSource yubinNoAdrMstDataSetBindingSource;
        private DataSet.YubinNoAdrMstKensakuDataSet yubinNoAdrMstDataSet;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn zipCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn todofukenNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shikuchosonNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn choikiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chihoKokyoDantaiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource todofukenInfoBindingSource;
        private DataSet.YubinNoAdrMstKensakuDataSetTableAdapters.TodofukenInfoTableAdapter todofukenInfoTableAdapter;

    }
}