namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class TaniSochiNmSelectForm
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
            this.taniSochiNmDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.selectButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.gaikanKensaKekkaTblDataSet = new FukjBizSystem.Application.DataSet.GaikanKensaKekkaTblDataSet();
            this.taniSochiNmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taniSochiNmTableAdapter = new FukjBizSystem.Application.DataSet.GaikanKensaKekkaTblDataSetTableAdapters.TaniSochiNmTableAdapter();
            this.taniSochiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.taniSochiNmDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaikanKensaKekkaTblDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taniSochiNmBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // taniSochiNmDataGridView
            // 
            this.taniSochiNmDataGridView.AllowUserToAddRows = false;
            this.taniSochiNmDataGridView.AllowUserToDeleteRows = false;
            this.taniSochiNmDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taniSochiNmDataGridView.AutoGenerateColumns = false;
            this.taniSochiNmDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taniSochiNmDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taniSochiNmDataGridViewTextBoxColumn});
            this.taniSochiNmDataGridView.DataSource = this.taniSochiNmBindingSource;
            this.taniSochiNmDataGridView.Location = new System.Drawing.Point(8, 16);
            this.taniSochiNmDataGridView.MultiSelect = false;
            this.taniSochiNmDataGridView.Name = "taniSochiNmDataGridView";
            this.taniSochiNmDataGridView.ReadOnly = true;
            this.taniSochiNmDataGridView.RowTemplate.Height = 21;
            this.taniSochiNmDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taniSochiNmDataGridView.Size = new System.Drawing.Size(414, 288);
            this.taniSochiNmDataGridView.TabIndex = 7;
            this.taniSochiNmDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taniSochiNmDataGridView_CellDoubleClick);
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectButton.Location = new System.Drawing.Point(210, 316);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(101, 37);
            this.selectButton.TabIndex = 11;
            this.selectButton.Text = "F1:選択戻り";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(319, 316);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 12;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // gaikanKensaKekkaTblDataSet
            // 
            this.gaikanKensaKekkaTblDataSet.DataSetName = "GaikanKensaKekkaTblDataSet";
            this.gaikanKensaKekkaTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taniSochiNmBindingSource
            // 
            this.taniSochiNmBindingSource.DataMember = "TaniSochiNm";
            this.taniSochiNmBindingSource.DataSource = this.gaikanKensaKekkaTblDataSet;
            // 
            // taniSochiNmTableAdapter
            // 
            this.taniSochiNmTableAdapter.ClearBeforeFill = true;
            // 
            // taniSochiNmDataGridViewTextBoxColumn
            // 
            this.taniSochiNmDataGridViewTextBoxColumn.DataPropertyName = "TaniSochiNm";
            this.taniSochiNmDataGridViewTextBoxColumn.HeaderText = "単位装置名";
            this.taniSochiNmDataGridViewTextBoxColumn.Name = "taniSochiNmDataGridViewTextBoxColumn";
            this.taniSochiNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.taniSochiNmDataGridViewTextBoxColumn.Width = 350;
            // 
            // TaniSochiNmSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 363);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.taniSochiNmDataGridView);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "TaniSochiNmSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "単位装置名選択";
            this.Load += new System.EventHandler(this.TaniSochiNmSelectForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TaniSochiNmSelectForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.taniSochiNmDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaikanKensaKekkaTblDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taniSochiNmBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZDataGridView.ZDataGridView taniSochiNmDataGridView;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button closeButton;
        private DataSet.GaikanKensaKekkaTblDataSet gaikanKensaKekkaTblDataSet;
        private System.Windows.Forms.BindingSource taniSochiNmBindingSource;
        private DataSet.GaikanKensaKekkaTblDataSetTableAdapters.TaniSochiNmTableAdapter taniSochiNmTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn taniSochiNmDataGridViewTextBoxColumn;
    }
}