namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    partial class GaikanKensaTabPage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsuikaButton = new Zynas.Control.ZButton(this.components);
            this.kakuteiButton = new Zynas.Control.ZButton(this.components);
            this.souchiTsuikaButton = new Zynas.Control.ZButton(this.components);
            this.shokenKekkaListDataSet = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.ShokenKekkaListDataSet();
            this.shokenListDataGridView = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenWdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiShokenIraiNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiShokenRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenHyojiichiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenTegakiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCheckKomokuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenCheckHanteiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shokenShitekiKashoNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaniSochiNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.shokenKekkaListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tsuikaButton
            // 
            this.tsuikaButton.Location = new System.Drawing.Point(960, 447);
            this.tsuikaButton.Name = "tsuikaButton";
            this.tsuikaButton.Size = new System.Drawing.Size(122, 47);
            this.tsuikaButton.TabIndex = 30;
            this.tsuikaButton.Text = "所見追加";
            this.tsuikaButton.UseVisualStyleBackColor = true;
            this.tsuikaButton.Click += new System.EventHandler(this.tsuikaButton_Click);
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kakuteiButton.Location = new System.Drawing.Point(974, 514);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(122, 47);
            this.kakuteiButton.TabIndex = 29;
            this.kakuteiButton.Text = "確定登録";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // souchiTsuikaButton
            // 
            this.souchiTsuikaButton.Location = new System.Drawing.Point(832, 447);
            this.souchiTsuikaButton.Name = "souchiTsuikaButton";
            this.souchiTsuikaButton.Size = new System.Drawing.Size(122, 47);
            this.souchiTsuikaButton.TabIndex = 31;
            this.souchiTsuikaButton.Text = "装置追加";
            this.souchiTsuikaButton.UseVisualStyleBackColor = true;
            this.souchiTsuikaButton.Click += new System.EventHandler(this.souchiTsuikaButton_Click);
            // 
            // shokenKekkaListDataSet
            // 
            this.shokenKekkaListDataSet.DataSetName = "ShokenKekkaListDataSet";
            this.shokenKekkaListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shokenListDataGridView
            // 
            this.shokenListDataGridView.AllowUserToAddRows = false;
            this.shokenListDataGridView.AllowUserToDeleteRows = false;
            this.shokenListDataGridView.AllowUserToResizeRows = false;
            this.shokenListDataGridView.AutoGenerateColumns = false;
            this.shokenListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shokenListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shokenListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shokenListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.shokenListDataGridView.ColumnHeadersHeight = 45;
            this.shokenListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shokenListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.shokenWdDataGridViewTextBoxColumn,
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn,
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn,
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn,
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn,
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn,
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn,
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn,
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn,
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn,
            this.Delete,
            this.kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn,
            this.kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn,
            this.kensaIraiShokenIraiNendoDataGridViewTextBoxColumn,
            this.kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn,
            this.kensaIraiShokenRenbanDataGridViewTextBoxColumn,
            this.shokenKbnDataGridViewTextBoxColumn,
            this.shokenCdDataGridViewTextBoxColumn,
            this.shokenHyojiichiDataGridViewTextBoxColumn,
            this.shokenTegakiDataGridViewTextBoxColumn,
            this.shokenCheckKomokuDataGridViewTextBoxColumn,
            this.shokenCheckHanteiDataGridViewTextBoxColumn,
            this.shokenShitekiKashoNoDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn,
            this.TaniSochiNm});
            this.shokenListDataGridView.DataMember = "ShokenKekkaList";
            this.shokenListDataGridView.DataSource = this.shokenKekkaListDataSet;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shokenListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.shokenListDataGridView.EnableHeadersVisualStyles = false;
            this.shokenListDataGridView.Location = new System.Drawing.Point(20, 15);
            this.shokenListDataGridView.MultiSelect = false;
            this.shokenListDataGridView.Name = "shokenListDataGridView";
            this.shokenListDataGridView.ReadOnly = true;
            this.shokenListDataGridView.RowHeadersVisible = false;
            this.shokenListDataGridView.RowTemplate.Height = 51;
            this.shokenListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shokenListDataGridView.Size = new System.Drawing.Size(1062, 426);
            this.shokenListDataGridView.TabIndex = 11;
            this.shokenListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shokenListDataGridView_CellClick);
            this.shokenListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.shokenListDataGridView_CellFormatting);
            // 
            // RowNumber
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RowNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.RowNumber.FillWeight = 15F;
            this.RowNumber.HeaderText = "No.";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // shokenWdDataGridViewTextBoxColumn
            // 
            this.shokenWdDataGridViewTextBoxColumn.DataPropertyName = "ShokenWd";
            this.shokenWdDataGridViewTextBoxColumn.HeaderText = "選択された所見";
            this.shokenWdDataGridViewTextBoxColumn.Name = "shokenWdDataGridViewTextBoxColumn";
            this.shokenWdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenWdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn
            // 
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenSetchishaRenrakuFlg";
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn.HeaderText = "設置者";
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn.Name = "shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn";
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn
            // 
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenHoshuGyoshaRenrakuFlg";
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn.HeaderText = "点検業";
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn.Name = "shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn";
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn
            // 
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenSeisoGyoshaRenrakuFlg";
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn.HeaderText = "清掃業";
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn.Name = "shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn";
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shokenMakerRenrakuFlgDataGridViewTextBoxColumn
            // 
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenMakerRenrakuFlg";
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn.HeaderText = "ﾒｰｶｰ";
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn.Name = "shokenMakerRenrakuFlgDataGridViewTextBoxColumn";
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenMakerRenrakuFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn
            // 
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenKojiGyoshaRenrakuFlg";
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn.HeaderText = "工事業";
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn.Name = "shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn";
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn
            // 
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenHokenjoRenrakuFlg";
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn.HeaderText = "保健所";
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn.Name = "shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn";
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn
            // 
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenHoshuKeiyakuKakuninFlg";
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.HeaderText = "保守契約";
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.Name = "shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn";
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn
            // 
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenTenkenKaisuuKakuninFlg";
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.HeaderText = "点検回数";
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.Name = "shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn";
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn
            // 
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.DataPropertyName = "ShokenSeisouKaisuuKakuninFlg";
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.FillWeight = 15F;
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.HeaderText = "清掃回数";
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.Name = "shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn";
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.Visible = false;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 15F;
            this.Delete.HeaderText = "取消";
            this.Delete.Image = global::FukjTabletSystem.Properties.Resources.top_close;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn
            // 
            this.kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiShokanIraiHoteiKbn";
            this.kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn.HeaderText = "KensaIraiShokanIraiHoteiKbn";
            this.kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn.Name = "kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn";
            this.kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiShokenIraiHokenjoCd";
            this.kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiShokenIraiHokenjoCd";
            this.kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn.Name = "kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn";
            this.kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiShokenIraiNendoDataGridViewTextBoxColumn
            // 
            this.kensaIraiShokenIraiNendoDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiShokenIraiNendo";
            this.kensaIraiShokenIraiNendoDataGridViewTextBoxColumn.HeaderText = "KensaIraiShokenIraiNendo";
            this.kensaIraiShokenIraiNendoDataGridViewTextBoxColumn.Name = "kensaIraiShokenIraiNendoDataGridViewTextBoxColumn";
            this.kensaIraiShokenIraiNendoDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiShokenIraiNendoDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn
            // 
            this.kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiShokenIraiRenban";
            this.kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn.HeaderText = "KensaIraiShokenIraiRenban";
            this.kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn.Name = "kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn";
            this.kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiShokenRenbanDataGridViewTextBoxColumn
            // 
            this.kensaIraiShokenRenbanDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiShokenRenban";
            this.kensaIraiShokenRenbanDataGridViewTextBoxColumn.HeaderText = "KensaIraiShokenRenban";
            this.kensaIraiShokenRenbanDataGridViewTextBoxColumn.Name = "kensaIraiShokenRenbanDataGridViewTextBoxColumn";
            this.kensaIraiShokenRenbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiShokenRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenKbnDataGridViewTextBoxColumn
            // 
            this.shokenKbnDataGridViewTextBoxColumn.DataPropertyName = "ShokenKbn";
            this.shokenKbnDataGridViewTextBoxColumn.HeaderText = "ShokenKbn";
            this.shokenKbnDataGridViewTextBoxColumn.Name = "shokenKbnDataGridViewTextBoxColumn";
            this.shokenKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenCdDataGridViewTextBoxColumn
            // 
            this.shokenCdDataGridViewTextBoxColumn.DataPropertyName = "ShokenCd";
            this.shokenCdDataGridViewTextBoxColumn.HeaderText = "ShokenCd";
            this.shokenCdDataGridViewTextBoxColumn.Name = "shokenCdDataGridViewTextBoxColumn";
            this.shokenCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenHyojiichiDataGridViewTextBoxColumn
            // 
            this.shokenHyojiichiDataGridViewTextBoxColumn.DataPropertyName = "ShokenHyojiichi";
            this.shokenHyojiichiDataGridViewTextBoxColumn.HeaderText = "ShokenHyojiichi";
            this.shokenHyojiichiDataGridViewTextBoxColumn.Name = "shokenHyojiichiDataGridViewTextBoxColumn";
            this.shokenHyojiichiDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenHyojiichiDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenTegakiDataGridViewTextBoxColumn
            // 
            this.shokenTegakiDataGridViewTextBoxColumn.DataPropertyName = "ShokenTegaki";
            this.shokenTegakiDataGridViewTextBoxColumn.HeaderText = "ShokenTegaki";
            this.shokenTegakiDataGridViewTextBoxColumn.Name = "shokenTegakiDataGridViewTextBoxColumn";
            this.shokenTegakiDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenTegakiDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenCheckKomokuDataGridViewTextBoxColumn
            // 
            this.shokenCheckKomokuDataGridViewTextBoxColumn.DataPropertyName = "ShokenCheckKomoku";
            this.shokenCheckKomokuDataGridViewTextBoxColumn.HeaderText = "ShokenCheckKomoku";
            this.shokenCheckKomokuDataGridViewTextBoxColumn.Name = "shokenCheckKomokuDataGridViewTextBoxColumn";
            this.shokenCheckKomokuDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenCheckKomokuDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenCheckHanteiDataGridViewTextBoxColumn
            // 
            this.shokenCheckHanteiDataGridViewTextBoxColumn.DataPropertyName = "ShokenCheckHantei";
            this.shokenCheckHanteiDataGridViewTextBoxColumn.HeaderText = "ShokenCheckHantei";
            this.shokenCheckHanteiDataGridViewTextBoxColumn.Name = "shokenCheckHanteiDataGridViewTextBoxColumn";
            this.shokenCheckHanteiDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenCheckHanteiDataGridViewTextBoxColumn.Visible = false;
            // 
            // shokenShitekiKashoNoDataGridViewTextBoxColumn
            // 
            this.shokenShitekiKashoNoDataGridViewTextBoxColumn.DataPropertyName = "ShokenShitekiKashoNo";
            this.shokenShitekiKashoNoDataGridViewTextBoxColumn.HeaderText = "ShokenShitekiKashoNo";
            this.shokenShitekiKashoNoDataGridViewTextBoxColumn.Name = "shokenShitekiKashoNoDataGridViewTextBoxColumn";
            this.shokenShitekiKashoNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.shokenShitekiKashoNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertDtDataGridViewTextBoxColumn
            // 
            this.insertDtDataGridViewTextBoxColumn.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn.Name = "insertDtDataGridViewTextBoxColumn";
            this.insertDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn
            // 
            this.insertUserDataGridViewTextBoxColumn.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn.Name = "insertUserDataGridViewTextBoxColumn";
            this.insertUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn
            // 
            this.insertTarmDataGridViewTextBoxColumn.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn.Name = "insertTarmDataGridViewTextBoxColumn";
            this.insertTarmDataGridViewTextBoxColumn.ReadOnly = true;
            this.insertTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDtDataGridViewTextBoxColumn
            // 
            this.updateDtDataGridViewTextBoxColumn.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.Name = "updateDtDataGridViewTextBoxColumn";
            this.updateDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateDtDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateUserDataGridViewTextBoxColumn
            // 
            this.updateUserDataGridViewTextBoxColumn.DataPropertyName = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.HeaderText = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn.Name = "updateUserDataGridViewTextBoxColumn";
            this.updateUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateTarmDataGridViewTextBoxColumn
            // 
            this.updateTarmDataGridViewTextBoxColumn.DataPropertyName = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.HeaderText = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn.Name = "updateTarmDataGridViewTextBoxColumn";
            this.updateTarmDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateTarmDataGridViewTextBoxColumn.Visible = false;
            // 
            // TaniSochiNm
            // 
            this.TaniSochiNm.DataPropertyName = "TaniSochiNm";
            this.TaniSochiNm.HeaderText = "TaniSochiNm";
            this.TaniSochiNm.Name = "TaniSochiNm";
            this.TaniSochiNm.ReadOnly = true;
            this.TaniSochiNm.Visible = false;
            // 
            // GaikanKensaTabPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.souchiTsuikaButton);
            this.Controls.Add(this.tsuikaButton);
            this.Controls.Add(this.kakuteiButton);
            this.Controls.Add(this.shokenListDataGridView);
            this.DisplayName = "外観検査";
            this.Name = "GaikanKensaTabPage";
            this.Load += new System.EventHandler(this.GaikanKensaTabPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shokenKekkaListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shokenListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton kakuteiButton;
        private Zynas.Control.ZButton tsuikaButton;
        private Zynas.Control.ZButton souchiTsuikaButton;
        private ShokenKekkaListDataSet shokenKekkaListDataSet;
        private System.Windows.Forms.DataGridView shokenListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenWdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenMakerRenrakuFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShokenIraiNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShokenRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenHyojiichiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenTegakiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCheckKomokuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenCheckHanteiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shokenShitekiKashoNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaniSochiNm;

    }
}
