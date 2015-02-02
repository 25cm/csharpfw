namespace FukjTabletSystem.Application.Boundary.Kensa
{
    partial class KensaListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KensaListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kensaListDataGridView = new System.Windows.Forms.DataGridView();
            this.kensaDataSet = new FukjTabletSystem.Application.Boundary.Kensa.KensaDataSet();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.backButton = new Zynas.Control.ZButton(this.components);
            this.mapButton = new Zynas.Control.ZButton(this.components);
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoteiKbnNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyuukinHouhouKbnNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.screeningKbnNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoSetchishaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoSetchiBashoAdrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyuukinHouhouKbnValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaJoukyouKbnNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaKekkaKensaJoukyouKbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoZenrinKeidoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaKekkaKensaTimesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoZenrinIdoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shubetsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seikyu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Times = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.Kensa = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rireki = new System.Windows.Forms.DataGridViewImageColumn();
            this.Map = new System.Windows.Forms.DataGridViewImageColumn();
            this.Files = new System.Windows.Forms.DataGridViewImageColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpsButton = new Zynas.Control.ZButton(this.components);
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kensaListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.kensaListDataGridView);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.gpsButton);
            this.topPanel.Controls.Add(this.backButton);
            this.topPanel.Controls.Add(this.mapButton);
            this.topPanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.topPanel.Controls.SetChildIndex(this.mapButton, 0);
            this.topPanel.Controls.SetChildIndex(this.backButton, 0);
            this.topPanel.Controls.SetChildIndex(this.gpsButton, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "検査予定一覧";
            this.titleLabel.DoubleClick += new System.EventHandler(this.titleLabel_DoubleClick);
            // 
            // kensaListDataGridView
            // 
            this.kensaListDataGridView.AllowUserToAddRows = false;
            this.kensaListDataGridView.AllowUserToDeleteRows = false;
            this.kensaListDataGridView.AllowUserToResizeRows = false;
            this.kensaListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kensaListDataGridView.AutoGenerateColumns = false;
            this.kensaListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kensaListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kensaListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kensaListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.kensaListDataGridView.ColumnHeadersHeight = 45;
            this.kensaListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.kensaListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn,
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn,
            this.kensaIraiNendoDataGridViewTextBoxColumn,
            this.kensaIraiRenbanDataGridViewTextBoxColumn,
            this.hoteiKbnNmDataGridViewTextBoxColumn,
            this.nyuukinHouhouKbnNmDataGridViewTextBoxColumn,
            this.screeningKbnNmDataGridViewTextBoxColumn,
            this.jokasoSetchishaNmDataGridViewTextBoxColumn,
            this.jokasoSetchiBashoAdrDataGridViewTextBoxColumn,
            this.nyuukinHouhouKbnValueDataGridViewTextBoxColumn,
            this.kensaJoukyouKbnNmDataGridViewTextBoxColumn,
            this.KensaKekkaKensaJoukyouKbn,
            this.jokasoZenrinKeidoCdDataGridViewTextBoxColumn,
            this.kensaKekkaKensaTimesDataGridViewTextBoxColumn,
            this.jokasoZenrinIdoCdDataGridViewTextBoxColumn,
            this.RowIndex,
            this.Shubetsu,
            this.Seikyu,
            this.JokasoName,
            this.Times,
            this.Status,
            this.Kensa,
            this.Rireki,
            this.Map,
            this.Files,
            this.Picture});
            this.kensaListDataGridView.DataMember = "KensaYoteiList";
            this.kensaListDataGridView.DataSource = this.kensaDataSet;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kensaListDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.kensaListDataGridView.EnableHeadersVisualStyles = false;
            this.kensaListDataGridView.Location = new System.Drawing.Point(1, 0);
            this.kensaListDataGridView.MultiSelect = false;
            this.kensaListDataGridView.Name = "kensaListDataGridView";
            this.kensaListDataGridView.ReadOnly = true;
            this.kensaListDataGridView.RowHeadersVisible = false;
            this.kensaListDataGridView.RowTemplate.Height = 51;
            this.kensaListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kensaListDataGridView.Size = new System.Drawing.Size(1272, 679);
            this.kensaListDataGridView.TabIndex = 80;
            this.kensaListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kensaListDataGridView_CellClick);
            // 
            // kensaDataSet
            // 
            this.kensaDataSet.DataSetName = "KensaDataSet";
            this.kensaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 10F;
            this.dataGridViewImageColumn1.HeaderText = "状況";
            this.dataGridViewImageColumn1.Image = global::FukjTabletSystem.Properties.Resources.list_pin_default;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 81;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 10F;
            this.dataGridViewImageColumn2.HeaderText = "検査ﾒﾆｭｰ";
            this.dataGridViewImageColumn2.Image = global::FukjTabletSystem.Properties.Resources.list_kensa;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 82;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.FillWeight = 10F;
            this.dataGridViewImageColumn3.HeaderText = "地図";
            this.dataGridViewImageColumn3.Image = global::FukjTabletSystem.Properties.Resources.list_map;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Width = 82;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.FillWeight = 10F;
            this.dataGridViewImageColumn4.HeaderText = "添付書類";
            this.dataGridViewImageColumn4.Image = global::FukjTabletSystem.Properties.Resources.list_info;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Width = 81;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.FillWeight = 10F;
            this.dataGridViewImageColumn5.HeaderText = "添付書類";
            this.dataGridViewImageColumn5.Image = global::FukjTabletSystem.Properties.Resources.list_info;
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.Width = 76;
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(1, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(70, 48);
            this.backButton.TabIndex = 11;
            this.backButton.TabStop = false;
            this.backButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // mapButton
            // 
            this.mapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapButton.FlatAppearance.BorderSize = 0;
            this.mapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mapButton.Image = global::FukjTabletSystem.Properties.Resources.top_map;
            this.mapButton.Location = new System.Drawing.Point(1203, 1);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(70, 48);
            this.mapButton.TabIndex = 8;
            this.mapButton.TabStop = false;
            this.mapButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mapButton.UseVisualStyleBackColor = false;
            this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
            // 
            // kensaIraiHoteiKbnDataGridViewTextBoxColumn
            // 
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiHoteiKbn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.HeaderText = "KensaIraiHoteiKbn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.Name = "kensaIraiHoteiKbnDataGridViewTextBoxColumn";
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiHokenjoCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiHokenjoCd";
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiHokenjoCd";
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.Name = "kensaIraiHokenjoCdDataGridViewTextBoxColumn";
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiNendoDataGridViewTextBoxColumn
            // 
            this.kensaIraiNendoDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiNendo";
            this.kensaIraiNendoDataGridViewTextBoxColumn.HeaderText = "KensaIraiNendo";
            this.kensaIraiNendoDataGridViewTextBoxColumn.Name = "kensaIraiNendoDataGridViewTextBoxColumn";
            this.kensaIraiNendoDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiNendoDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiRenbanDataGridViewTextBoxColumn
            // 
            this.kensaIraiRenbanDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiRenban";
            this.kensaIraiRenbanDataGridViewTextBoxColumn.HeaderText = "KensaIraiRenban";
            this.kensaIraiRenbanDataGridViewTextBoxColumn.Name = "kensaIraiRenbanDataGridViewTextBoxColumn";
            this.kensaIraiRenbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // hoteiKbnNmDataGridViewTextBoxColumn
            // 
            this.hoteiKbnNmDataGridViewTextBoxColumn.DataPropertyName = "HoteiKbnNm";
            this.hoteiKbnNmDataGridViewTextBoxColumn.HeaderText = "HoteiKbnNm";
            this.hoteiKbnNmDataGridViewTextBoxColumn.Name = "hoteiKbnNmDataGridViewTextBoxColumn";
            this.hoteiKbnNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.hoteiKbnNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // nyuukinHouhouKbnNmDataGridViewTextBoxColumn
            // 
            this.nyuukinHouhouKbnNmDataGridViewTextBoxColumn.DataPropertyName = "NyuukinHouhouKbnNm";
            this.nyuukinHouhouKbnNmDataGridViewTextBoxColumn.HeaderText = "NyuukinHouhouKbnNm";
            this.nyuukinHouhouKbnNmDataGridViewTextBoxColumn.Name = "nyuukinHouhouKbnNmDataGridViewTextBoxColumn";
            this.nyuukinHouhouKbnNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.nyuukinHouhouKbnNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // screeningKbnNmDataGridViewTextBoxColumn
            // 
            this.screeningKbnNmDataGridViewTextBoxColumn.DataPropertyName = "ScreeningKbnNm";
            this.screeningKbnNmDataGridViewTextBoxColumn.HeaderText = "ScreeningKbnNm";
            this.screeningKbnNmDataGridViewTextBoxColumn.Name = "screeningKbnNmDataGridViewTextBoxColumn";
            this.screeningKbnNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.screeningKbnNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoSetchishaNmDataGridViewTextBoxColumn
            // 
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.DataPropertyName = "JokasoSetchishaNm";
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.HeaderText = "JokasoSetchishaNm";
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.Name = "jokasoSetchishaNmDataGridViewTextBoxColumn";
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoSetchishaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoSetchiBashoAdrDataGridViewTextBoxColumn
            // 
            this.jokasoSetchiBashoAdrDataGridViewTextBoxColumn.DataPropertyName = "JokasoSetchiBashoAdr";
            this.jokasoSetchiBashoAdrDataGridViewTextBoxColumn.HeaderText = "JokasoSetchiBashoAdr";
            this.jokasoSetchiBashoAdrDataGridViewTextBoxColumn.Name = "jokasoSetchiBashoAdrDataGridViewTextBoxColumn";
            this.jokasoSetchiBashoAdrDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoSetchiBashoAdrDataGridViewTextBoxColumn.Visible = false;
            // 
            // nyuukinHouhouKbnValueDataGridViewTextBoxColumn
            // 
            this.nyuukinHouhouKbnValueDataGridViewTextBoxColumn.DataPropertyName = "NyuukinHouhouKbnValue";
            this.nyuukinHouhouKbnValueDataGridViewTextBoxColumn.HeaderText = "NyuukinHouhouKbnValue";
            this.nyuukinHouhouKbnValueDataGridViewTextBoxColumn.Name = "nyuukinHouhouKbnValueDataGridViewTextBoxColumn";
            this.nyuukinHouhouKbnValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.nyuukinHouhouKbnValueDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaJoukyouKbnNmDataGridViewTextBoxColumn
            // 
            this.kensaJoukyouKbnNmDataGridViewTextBoxColumn.DataPropertyName = "KensaJoukyouKbnNm";
            this.kensaJoukyouKbnNmDataGridViewTextBoxColumn.HeaderText = "KensaJoukyouKbnNm";
            this.kensaJoukyouKbnNmDataGridViewTextBoxColumn.Name = "kensaJoukyouKbnNmDataGridViewTextBoxColumn";
            this.kensaJoukyouKbnNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaJoukyouKbnNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // KensaKekkaKensaJoukyouKbn
            // 
            this.KensaKekkaKensaJoukyouKbn.DataPropertyName = "KensaKekkaKensaJoukyouKbn";
            this.KensaKekkaKensaJoukyouKbn.HeaderText = "KensaKekkaKensaJoukyouKbn";
            this.KensaKekkaKensaJoukyouKbn.Name = "KensaKekkaKensaJoukyouKbn";
            this.KensaKekkaKensaJoukyouKbn.ReadOnly = true;
            this.KensaKekkaKensaJoukyouKbn.Visible = false;
            // 
            // jokasoZenrinKeidoCdDataGridViewTextBoxColumn
            // 
            this.jokasoZenrinKeidoCdDataGridViewTextBoxColumn.DataPropertyName = "JokasoZenrinKeidoCd";
            this.jokasoZenrinKeidoCdDataGridViewTextBoxColumn.HeaderText = "JokasoZenrinKeidoCd";
            this.jokasoZenrinKeidoCdDataGridViewTextBoxColumn.Name = "jokasoZenrinKeidoCdDataGridViewTextBoxColumn";
            this.jokasoZenrinKeidoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoZenrinKeidoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaKekkaKensaTimesDataGridViewTextBoxColumn
            // 
            this.kensaKekkaKensaTimesDataGridViewTextBoxColumn.DataPropertyName = "KensaKekkaKensaTimes";
            this.kensaKekkaKensaTimesDataGridViewTextBoxColumn.HeaderText = "KensaKekkaKensaTimes";
            this.kensaKekkaKensaTimesDataGridViewTextBoxColumn.Name = "kensaKekkaKensaTimesDataGridViewTextBoxColumn";
            this.kensaKekkaKensaTimesDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaKekkaKensaTimesDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoZenrinIdoCdDataGridViewTextBoxColumn
            // 
            this.jokasoZenrinIdoCdDataGridViewTextBoxColumn.DataPropertyName = "JokasoZenrinIdoCd";
            this.jokasoZenrinIdoCdDataGridViewTextBoxColumn.HeaderText = "JokasoZenrinIdoCd";
            this.jokasoZenrinIdoCdDataGridViewTextBoxColumn.Name = "jokasoZenrinIdoCdDataGridViewTextBoxColumn";
            this.jokasoZenrinIdoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoZenrinIdoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // RowIndex
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RowIndex.DefaultCellStyle = dataGridViewCellStyle2;
            this.RowIndex.FillWeight = 6F;
            this.RowIndex.HeaderText = "No.";
            this.RowIndex.Name = "RowIndex";
            this.RowIndex.ReadOnly = true;
            this.RowIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Shubetsu
            // 
            this.Shubetsu.FillWeight = 20F;
            this.Shubetsu.HeaderText = "種別";
            this.Shubetsu.Name = "Shubetsu";
            this.Shubetsu.ReadOnly = true;
            this.Shubetsu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Seikyu
            // 
            this.Seikyu.FillWeight = 20F;
            this.Seikyu.HeaderText = "請求方法";
            this.Seikyu.Name = "Seikyu";
            this.Seikyu.ReadOnly = true;
            this.Seikyu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // JokasoName
            // 
            this.JokasoName.FillWeight = 40F;
            this.JokasoName.HeaderText = "浄化槽管理者名／設置場所";
            this.JokasoName.Name = "JokasoName";
            this.JokasoName.ReadOnly = true;
            this.JokasoName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Times
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Times.DefaultCellStyle = dataGridViewCellStyle3;
            this.Times.FillWeight = 10F;
            this.Times.HeaderText = "検査時間";
            this.Times.Name = "Times";
            this.Times.ReadOnly = true;
            this.Times.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.FillWeight = 10F;
            this.Status.HeaderText = "状況";
            this.Status.Image = global::FukjTabletSystem.Properties.Resources.list_pin_complete;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Kensa
            // 
            this.Kensa.FillWeight = 10F;
            this.Kensa.HeaderText = "検査ﾒﾆｭｰ";
            this.Kensa.Image = global::FukjTabletSystem.Properties.Resources.list_kensa;
            this.Kensa.Name = "Kensa";
            this.Kensa.ReadOnly = true;
            // 
            // Rireki
            // 
            this.Rireki.FillWeight = 10F;
            this.Rireki.HeaderText = "検査履歴";
            this.Rireki.Image = global::FukjTabletSystem.Properties.Resources.list_rireki;
            this.Rireki.Name = "Rireki";
            this.Rireki.ReadOnly = true;
            // 
            // Map
            // 
            this.Map.FillWeight = 10F;
            this.Map.HeaderText = "地図";
            this.Map.Image = global::FukjTabletSystem.Properties.Resources.list_map;
            this.Map.Name = "Map";
            this.Map.ReadOnly = true;
            // 
            // Files
            // 
            this.Files.FillWeight = 10F;
            this.Files.HeaderText = "添付書類";
            this.Files.Image = global::FukjTabletSystem.Properties.Resources.list_pdf;
            this.Files.Name = "Files";
            this.Files.ReadOnly = true;
            // 
            // Picture
            // 
            this.Picture.FillWeight = 10F;
            this.Picture.HeaderText = "写真落書";
            this.Picture.Image = global::FukjTabletSystem.Properties.Resources.list_photo;
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            // 
            // gpsButton
            // 
            this.gpsButton.FlatAppearance.BorderSize = 0;
            this.gpsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpsButton.Image = global::FukjTabletSystem.Properties.Resources.top_gps;
            this.gpsButton.Location = new System.Drawing.Point(77, 1);
            this.gpsButton.Name = "gpsButton";
            this.gpsButton.Size = new System.Drawing.Size(70, 48);
            this.gpsButton.TabIndex = 17;
            this.gpsButton.TabStop = false;
            this.gpsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gpsButton.UseVisualStyleBackColor = false;
            this.gpsButton.Visible = false;
            this.gpsButton.Click += new System.EventHandler(this.gpsButton_Click);
            // 
            // KensaListForm
            // 
            this.ClientSize = new System.Drawing.Size(1274, 731);
            this.Name = "KensaListForm";
            this.Text = "検査予定一覧";
            this.Load += new System.EventHandler(this.KensaListForm_Load);
            this.contentsPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kensaListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView kensaListDataGridView;
        private Zynas.Control.ZButton mapButton;
        private Zynas.Control.ZButton backButton;
        private KensaDataSet kensaDataSet;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHoteiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoteiKbnNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyuukinHouhouKbnNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn screeningKbnNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoSetchishaNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoSetchiBashoAdrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyuukinHouhouKbnValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaJoukyouKbnNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaKekkaKensaJoukyouKbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoZenrinKeidoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaKekkaKensaTimesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoZenrinIdoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shubetsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seikyu;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Times;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn Kensa;
        private System.Windows.Forms.DataGridViewImageColumn Rireki;
        private System.Windows.Forms.DataGridViewImageColumn Map;
        private System.Windows.Forms.DataGridViewImageColumn Files;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private Zynas.Control.ZButton gpsButton;




    }
}