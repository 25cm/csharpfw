namespace FukjTabletSystem.Application.Boundary.Kensa
{
    partial class KensaMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KensaMenuForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.kihonJouhouTabPage = new System.Windows.Forms.TabPage();
            this.kihonJouhou = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.KihonJouhouTabPage();
            this.shoruiKensaTabPage = new System.Windows.Forms.TabPage();
            this.shoruikensa = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.ShoruiKensaTabPage();
            this.suishitsuKensaTabPage = new System.Windows.Forms.TabPage();
            this.suishitsuKensa = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.SuishitsuKensaTabPage();
            this.gaikanKensaTabPage = new System.Windows.Forms.TabPage();
            this.gaikanKensa1 = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.GaikanKensaTabPage();
            this.suuchiNyuuryokuTabPage = new System.Windows.Forms.TabPage();
            this.suuchiNyuuryoku = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.SuuchiNyuuryokuTabPage();
            this.memoTabPage = new System.Windows.Forms.TabPage();
            this.memo = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.MemoTabPage();
            this.kekkashoTabPage = new System.Windows.Forms.TabPage();
            this.monitoringTabPage = new System.Windows.Forms.TabPage();
            this.monitoring = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.MonitoringTabPage();
            this.kensaShuuryouTabPage = new System.Windows.Forms.TabPage();
            this.backButton = new Zynas.Control.ZButton(this.components);
            this.paintButton = new Zynas.Control.ZButton(this.components);
            this.gpsButton = new Zynas.Control.ZButton(this.components);
            this.cameraButton = new Zynas.Control.ZButton(this.components);
            this.kensaDataSet = new FukjTabletSystem.Application.Boundary.Kensa.KensaDataSet();
            this.kensaListDataGridView = new System.Windows.Forms.DataGridView();
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
            this.Rireki = new System.Windows.Forms.DataGridViewImageColumn();
            this.Map = new System.Windows.Forms.DataGridViewImageColumn();
            this.Files = new System.Windows.Forms.DataGridViewImageColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.locationInfoLabel = new System.Windows.Forms.Label();
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.kihonJouhouTabPage.SuspendLayout();
            this.shoruiKensaTabPage.SuspendLayout();
            this.suishitsuKensaTabPage.SuspendLayout();
            this.gaikanKensaTabPage.SuspendLayout();
            this.suuchiNyuuryokuTabPage.SuspendLayout();
            this.memoTabPage.SuspendLayout();
            this.monitoringTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kensaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.kensaListDataGridView);
            this.contentsPanel.Controls.Add(this.tabControl);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.locationInfoLabel);
            this.topPanel.Controls.Add(this.label4);
            this.topPanel.Controls.Add(this.backButton);
            this.topPanel.Controls.Add(this.paintButton);
            this.topPanel.Controls.Add(this.gpsButton);
            this.topPanel.Controls.Add(this.cameraButton);
            this.topPanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.topPanel.Controls.SetChildIndex(this.cameraButton, 0);
            this.topPanel.Controls.SetChildIndex(this.gpsButton, 0);
            this.topPanel.Controls.SetChildIndex(this.paintButton, 0);
            this.topPanel.Controls.SetChildIndex(this.backButton, 0);
            this.topPanel.Controls.SetChildIndex(this.label4, 0);
            this.topPanel.Controls.SetChildIndex(this.locationInfoLabel, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "検査メニュー";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.kihonJouhouTabPage);
            this.tabControl.Controls.Add(this.shoruiKensaTabPage);
            this.tabControl.Controls.Add(this.suishitsuKensaTabPage);
            this.tabControl.Controls.Add(this.gaikanKensaTabPage);
            this.tabControl.Controls.Add(this.suuchiNyuuryokuTabPage);
            this.tabControl.Controls.Add(this.memoTabPage);
            this.tabControl.Controls.Add(this.kekkashoTabPage);
            this.tabControl.Controls.Add(this.monitoringTabPage);
            this.tabControl.Controls.Add(this.kensaShuuryouTabPage);
            this.tabControl.Location = new System.Drawing.Point(1, 97);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1272, 581);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // kihonJouhouTabPage
            // 
            this.kihonJouhouTabPage.Controls.Add(this.kihonJouhou);
            this.kihonJouhouTabPage.Location = new System.Drawing.Point(4, 33);
            this.kihonJouhouTabPage.Name = "kihonJouhouTabPage";
            this.kihonJouhouTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.kihonJouhouTabPage.Size = new System.Drawing.Size(1264, 544);
            this.kihonJouhouTabPage.TabIndex = 0;
            this.kihonJouhouTabPage.Text = "基本情報";
            this.kihonJouhouTabPage.UseVisualStyleBackColor = true;
            // 
            // kihonJouhou
            // 
            this.kihonJouhou.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kihonJouhou.DisplayName = "基本情報";
            this.kihonJouhou.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kihonJouhou.Location = new System.Drawing.Point(2, 4);
            this.kihonJouhou.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.kihonJouhou.Name = "kihonJouhou";
            this.kihonJouhou.Size = new System.Drawing.Size(1260, 540);
            this.kihonJouhou.TabIndex = 0;
            // 
            // shoruiKensaTabPage
            // 
            this.shoruiKensaTabPage.Controls.Add(this.shoruikensa);
            this.shoruiKensaTabPage.Location = new System.Drawing.Point(4, 33);
            this.shoruiKensaTabPage.Name = "shoruiKensaTabPage";
            this.shoruiKensaTabPage.Size = new System.Drawing.Size(1264, 544);
            this.shoruiKensaTabPage.TabIndex = 2;
            this.shoruiKensaTabPage.Text = "書類検査";
            this.shoruiKensaTabPage.UseVisualStyleBackColor = true;
            // 
            // shoruikensa
            // 
            this.shoruikensa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shoruikensa.DisplayName = "書類検査";
            this.shoruikensa.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shoruikensa.Location = new System.Drawing.Point(2, 4);
            this.shoruikensa.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.shoruikensa.Name = "shoruikensa";
            this.shoruikensa.Size = new System.Drawing.Size(1260, 540);
            this.shoruikensa.TabIndex = 0;
            // 
            // suishitsuKensaTabPage
            // 
            this.suishitsuKensaTabPage.Controls.Add(this.suishitsuKensa);
            this.suishitsuKensaTabPage.Location = new System.Drawing.Point(4, 33);
            this.suishitsuKensaTabPage.Name = "suishitsuKensaTabPage";
            this.suishitsuKensaTabPage.Size = new System.Drawing.Size(1264, 544);
            this.suishitsuKensaTabPage.TabIndex = 3;
            this.suishitsuKensaTabPage.Text = "水質検査";
            this.suishitsuKensaTabPage.UseVisualStyleBackColor = true;
            // 
            // suishitsuKensa
            // 
            this.suishitsuKensa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suishitsuKensa.DisplayName = "水質検査";
            this.suishitsuKensa.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.suishitsuKensa.Location = new System.Drawing.Point(2, 4);
            this.suishitsuKensa.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.suishitsuKensa.Name = "suishitsuKensa";
            this.suishitsuKensa.Size = new System.Drawing.Size(1260, 540);
            this.suishitsuKensa.TabIndex = 0;
            // 
            // gaikanKensaTabPage
            // 
            this.gaikanKensaTabPage.Controls.Add(this.gaikanKensa1);
            this.gaikanKensaTabPage.Location = new System.Drawing.Point(4, 33);
            this.gaikanKensaTabPage.Name = "gaikanKensaTabPage";
            this.gaikanKensaTabPage.Size = new System.Drawing.Size(1264, 544);
            this.gaikanKensaTabPage.TabIndex = 4;
            this.gaikanKensaTabPage.Text = "外観検査";
            this.gaikanKensaTabPage.UseVisualStyleBackColor = true;
            // 
            // gaikanKensa1
            // 
            this.gaikanKensa1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gaikanKensa1.DisplayName = "外観検査";
            this.gaikanKensa1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gaikanKensa1.Location = new System.Drawing.Point(2, 4);
            this.gaikanKensa1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gaikanKensa1.Name = "gaikanKensa1";
            this.gaikanKensa1.Size = new System.Drawing.Size(1260, 540);
            this.gaikanKensa1.TabIndex = 0;
            // 
            // suuchiNyuuryokuTabPage
            // 
            this.suuchiNyuuryokuTabPage.Controls.Add(this.suuchiNyuuryoku);
            this.suuchiNyuuryokuTabPage.Location = new System.Drawing.Point(4, 33);
            this.suuchiNyuuryokuTabPage.Name = "suuchiNyuuryokuTabPage";
            this.suuchiNyuuryokuTabPage.Size = new System.Drawing.Size(1264, 544);
            this.suuchiNyuuryokuTabPage.TabIndex = 5;
            this.suuchiNyuuryokuTabPage.Text = "数値入力";
            this.suuchiNyuuryokuTabPage.UseVisualStyleBackColor = true;
            // 
            // suuchiNyuuryoku
            // 
            this.suuchiNyuuryoku.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suuchiNyuuryoku.DisplayName = "数値入力";
            this.suuchiNyuuryoku.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.suuchiNyuuryoku.Location = new System.Drawing.Point(2, 4);
            this.suuchiNyuuryoku.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.suuchiNyuuryoku.Name = "suuchiNyuuryoku";
            this.suuchiNyuuryoku.Size = new System.Drawing.Size(1260, 540);
            this.suuchiNyuuryoku.TabIndex = 0;
            // 
            // memoTabPage
            // 
            this.memoTabPage.Controls.Add(this.memo);
            this.memoTabPage.Location = new System.Drawing.Point(4, 33);
            this.memoTabPage.Name = "memoTabPage";
            this.memoTabPage.Size = new System.Drawing.Size(1264, 544);
            this.memoTabPage.TabIndex = 6;
            this.memoTabPage.Text = "メモ";
            this.memoTabPage.UseVisualStyleBackColor = true;
            // 
            // memo
            // 
            this.memo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memo.DisplayName = "メモ";
            this.memo.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.memo.Location = new System.Drawing.Point(2, 4);
            this.memo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(1260, 540);
            this.memo.TabIndex = 0;
            // 
            // kekkashoTabPage
            // 
            this.kekkashoTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.kekkashoTabPage.Location = new System.Drawing.Point(4, 33);
            this.kekkashoTabPage.Name = "kekkashoTabPage";
            this.kekkashoTabPage.Size = new System.Drawing.Size(1264, 544);
            this.kekkashoTabPage.TabIndex = 7;
            this.kekkashoTabPage.Text = "結果書";
            // 
            // monitoringTabPage
            // 
            this.monitoringTabPage.Controls.Add(this.monitoring);
            this.monitoringTabPage.Location = new System.Drawing.Point(4, 33);
            this.monitoringTabPage.Name = "monitoringTabPage";
            this.monitoringTabPage.Size = new System.Drawing.Size(1264, 544);
            this.monitoringTabPage.TabIndex = 8;
            this.monitoringTabPage.Text = "モニタリング";
            this.monitoringTabPage.UseVisualStyleBackColor = true;
            // 
            // monitoring
            // 
            this.monitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitoring.DisplayName = "モニタリング";
            this.monitoring.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.monitoring.Location = new System.Drawing.Point(2, 4);
            this.monitoring.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.monitoring.Name = "monitoring";
            this.monitoring.Size = new System.Drawing.Size(1260, 540);
            this.monitoring.TabIndex = 0;
            // 
            // kensaShuuryouTabPage
            // 
            this.kensaShuuryouTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.kensaShuuryouTabPage.Location = new System.Drawing.Point(4, 33);
            this.kensaShuuryouTabPage.Name = "kensaShuuryouTabPage";
            this.kensaShuuryouTabPage.Size = new System.Drawing.Size(1264, 544);
            this.kensaShuuryouTabPage.TabIndex = 9;
            this.kensaShuuryouTabPage.Text = "検査終了";
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(1, 1);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(70, 48);
            this.backButton.TabIndex = 10;
            this.backButton.TabStop = false;
            this.backButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // paintButton
            // 
            this.paintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paintButton.FlatAppearance.BorderSize = 0;
            this.paintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintButton.Image = global::FukjTabletSystem.Properties.Resources.top_input;
            this.paintButton.Location = new System.Drawing.Point(1203, 1);
            this.paintButton.Name = "paintButton";
            this.paintButton.Size = new System.Drawing.Size(70, 48);
            this.paintButton.TabIndex = 9;
            this.paintButton.TabStop = false;
            this.paintButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.paintButton.UseVisualStyleBackColor = false;
            this.paintButton.Click += new System.EventHandler(this.paintButton_Click);
            // 
            // gpsButton
            // 
            this.gpsButton.FlatAppearance.BorderSize = 0;
            this.gpsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpsButton.Image = global::FukjTabletSystem.Properties.Resources.top_gps;
            this.gpsButton.Location = new System.Drawing.Point(75, 1);
            this.gpsButton.Name = "gpsButton";
            this.gpsButton.Size = new System.Drawing.Size(70, 48);
            this.gpsButton.TabIndex = 8;
            this.gpsButton.TabStop = false;
            this.gpsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gpsButton.UseVisualStyleBackColor = false;
            this.gpsButton.Click += new System.EventHandler(this.gpsButton_Click);
            // 
            // cameraButton
            // 
            this.cameraButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraButton.FlatAppearance.BorderSize = 0;
            this.cameraButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cameraButton.Image = global::FukjTabletSystem.Properties.Resources.top_camera;
            this.cameraButton.Location = new System.Drawing.Point(1129, 1);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(70, 48);
            this.cameraButton.TabIndex = 7;
            this.cameraButton.TabStop = false;
            this.cameraButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cameraButton.UseVisualStyleBackColor = false;
            this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
            // 
            // kensaDataSet
            // 
            this.kensaDataSet.DataSetName = "KensaDataSet";
            this.kensaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kensaListDataGridView
            // 
            this.kensaListDataGridView.AllowUserToAddRows = false;
            this.kensaListDataGridView.AllowUserToDeleteRows = false;
            this.kensaListDataGridView.AllowUserToResizeRows = false;
            this.kensaListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kensaListDataGridView.AutoGenerateColumns = false;
            this.kensaListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kensaListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kensaListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Rireki,
            this.Map,
            this.Files,
            this.Picture});
            this.kensaListDataGridView.DataMember = "KensaYoteiList";
            this.kensaListDataGridView.DataSource = this.kensaDataSet;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kensaListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.kensaListDataGridView.EnableHeadersVisualStyles = false;
            this.kensaListDataGridView.Location = new System.Drawing.Point(1, 0);
            this.kensaListDataGridView.MultiSelect = false;
            this.kensaListDataGridView.Name = "kensaListDataGridView";
            this.kensaListDataGridView.ReadOnly = true;
            this.kensaListDataGridView.RowHeadersVisible = false;
            this.kensaListDataGridView.RowTemplate.Height = 52;
            this.kensaListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kensaListDataGridView.Size = new System.Drawing.Size(1272, 97);
            this.kensaListDataGridView.TabIndex = 81;
            this.kensaListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kensaListDataGridView_CellClick);
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
            this.JokasoName.FillWeight = 70F;
            this.JokasoName.HeaderText = "浄化槽管理者名／設置場所";
            this.JokasoName.Name = "JokasoName";
            this.JokasoName.ReadOnly = true;
            this.JokasoName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(151, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "位置情報取得日時";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // locationInfoLabel
            // 
            this.locationInfoLabel.AutoSize = true;
            this.locationInfoLabel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.locationInfoLabel.Location = new System.Drawing.Point(151, 25);
            this.locationInfoLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.locationInfoLabel.Name = "locationInfoLabel";
            this.locationInfoLabel.Size = new System.Drawing.Size(152, 20);
            this.locationInfoLabel.TabIndex = 12;
            this.locationInfoLabel.Text = "yyyy/MM/dd hh:mm";
            this.locationInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KensaMenuForm
            // 
            this.ClientSize = new System.Drawing.Size(1274, 731);
            this.Name = "KensaMenuForm";
            this.Text = "検査メニュー";
            this.Load += new System.EventHandler(this.KensaMenuForm_Load);
            this.Shown += new System.EventHandler(this.KensaMenuForm_Shown);
            this.contentsPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.kihonJouhouTabPage.ResumeLayout(false);
            this.shoruiKensaTabPage.ResumeLayout(false);
            this.suishitsuKensaTabPage.ResumeLayout(false);
            this.gaikanKensaTabPage.ResumeLayout(false);
            this.suuchiNyuuryokuTabPage.ResumeLayout(false);
            this.memoTabPage.ResumeLayout(false);
            this.monitoringTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kensaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage kihonJouhouTabPage;
        private System.Windows.Forms.TabPage shoruiKensaTabPage;
        private System.Windows.Forms.TabPage suishitsuKensaTabPage;
        private System.Windows.Forms.TabPage gaikanKensaTabPage;
        private System.Windows.Forms.TabPage suuchiNyuuryokuTabPage;
        private System.Windows.Forms.TabPage memoTabPage;
        private System.Windows.Forms.TabPage kekkashoTabPage;
        private System.Windows.Forms.TabPage monitoringTabPage;
        private Zynas.Control.ZButton backButton;
        private Zynas.Control.ZButton paintButton;
        private Zynas.Control.ZButton gpsButton;
        private Zynas.Control.ZButton cameraButton;
        private System.Windows.Forms.TabPage kensaShuuryouTabPage;
        private FukjTabletSystem.Application.Boundary.Kensa.TabPages.KihonJouhouTabPage kihonJouhou;
        private FukjTabletSystem.Application.Boundary.Kensa.TabPages.ShoruiKensaTabPage shoruikensa;
        private FukjTabletSystem.Application.Boundary.Kensa.TabPages.SuishitsuKensaTabPage suishitsuKensa;
        private FukjTabletSystem.Application.Boundary.Kensa.TabPages.GaikanKensaTabPage gaikanKensa1;
        private FukjTabletSystem.Application.Boundary.Kensa.TabPages.SuuchiNyuuryokuTabPage suuchiNyuuryoku;
        private FukjTabletSystem.Application.Boundary.Kensa.TabPages.MemoTabPage memo;
        private FukjTabletSystem.Application.Boundary.Kensa.TabPages.MonitoringTabPage monitoring;
        private KensaDataSet kensaDataSet;
        private System.Windows.Forms.DataGridView kensaListDataGridView;
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
        private System.Windows.Forms.DataGridViewImageColumn Rireki;
        private System.Windows.Forms.DataGridViewImageColumn Map;
        private System.Windows.Forms.DataGridViewImageColumn Files;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.Label locationInfoLabel;
        private System.Windows.Forms.Label label4;
    }
}