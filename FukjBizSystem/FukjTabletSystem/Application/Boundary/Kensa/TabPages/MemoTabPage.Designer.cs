namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    partial class MemoTabPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsuikaButton = new Zynas.Control.ZButton(this.components);
            this.memoTextBox = new FukjTabletSystem.Controls.ZTextBox(this.components);
            this.memoDaibunruiListBox = new System.Windows.Forms.ListBox();
            this.memoListDataSet = new FukjTabletSystem.Application.Boundary.Kensa.TabPages.MemoListDataSet();
            this.memoMstListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.memoListDataGridView = new System.Windows.Forms.DataGridView();
            this.RowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoMemoJokasoRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoMemoDaibunruiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoMemoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.tegakiMemoTextBox = new FukjTabletSystem.Controls.ZTextBox(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.kakuteiButton = new Zynas.Control.ZButton(this.components);
            this.hukaJouhouGridView = new System.Windows.Forms.DataGridView();
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiFileShubetsuCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKanrenFilePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertDtDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertUserDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTarmDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUserDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTarmDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaNenTextBox = new FukjTabletSystem.Controls.ZTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hukaJouhouGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tsuikaButton
            // 
            this.tsuikaButton.Location = new System.Drawing.Point(477, 265);
            this.tsuikaButton.Name = "tsuikaButton";
            this.tsuikaButton.Size = new System.Drawing.Size(122, 47);
            this.tsuikaButton.TabIndex = 20;
            this.tsuikaButton.Text = "追加";
            this.tsuikaButton.UseVisualStyleBackColor = true;
            this.tsuikaButton.Click += new System.EventHandler(this.tsuikaButton_Click);
            // 
            // memoTextBox
            // 
            this.memoTextBox.AllowDropDown = false;
            this.memoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.memoTextBox.CustomInputMode = FukjTabletSystem.Controls.ZTextBox.InputMode.None;
            this.memoTextBox.CustomReadOnly = true;
            this.memoTextBox.Location = new System.Drawing.Point(20, 228);
            this.memoTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.memoTextBox.MaxLength = 40;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.ReadOnly = true;
            this.memoTextBox.Size = new System.Drawing.Size(579, 31);
            this.memoTextBox.TabIndex = 19;
            this.memoTextBox.TabStop = false;
            // 
            // memoDaibunruiListBox
            // 
            this.memoDaibunruiListBox.DataSource = this.memoListDataSet;
            this.memoDaibunruiListBox.DisplayMember = "MemoDaibunruiMst.MemoDaibunruiNm";
            this.memoDaibunruiListBox.FormattingEnabled = true;
            this.memoDaibunruiListBox.ItemHeight = 24;
            this.memoDaibunruiListBox.Location = new System.Drawing.Point(20, 15);
            this.memoDaibunruiListBox.Name = "memoDaibunruiListBox";
            this.memoDaibunruiListBox.Size = new System.Drawing.Size(360, 172);
            this.memoDaibunruiListBox.TabIndex = 17;
            this.memoDaibunruiListBox.ValueMember = "MemoDaibunruiMst.MemoDaibunruiCd";
            this.memoDaibunruiListBox.SelectedValueChanged += new System.EventHandler(this.memoDaibunruiListBox_SelectedValueChanged);
            // 
            // memoListDataSet
            // 
            this.memoListDataSet.DataSetName = "MemoListDataSet";
            this.memoListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // memoMstListBox
            // 
            this.memoMstListBox.DataSource = this.memoListDataSet;
            this.memoMstListBox.DisplayMember = "MemoMst.Memo";
            this.memoMstListBox.FormattingEnabled = true;
            this.memoMstListBox.ItemHeight = 24;
            this.memoMstListBox.Location = new System.Drawing.Point(386, 15);
            this.memoMstListBox.Name = "memoMstListBox";
            this.memoMstListBox.Size = new System.Drawing.Size(695, 172);
            this.memoMstListBox.TabIndex = 21;
            this.memoMstListBox.ValueMember = "MemoMst.MemoCd";
            this.memoMstListBox.SelectedValueChanged += new System.EventHandler(this.memoMstListBox_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Green;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(20, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(579, 31);
            this.label6.TabIndex = 22;
            this.label6.Text = "選択されたメモ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memoListDataGridView
            // 
            this.memoListDataGridView.AllowUserToAddRows = false;
            this.memoListDataGridView.AllowUserToDeleteRows = false;
            this.memoListDataGridView.AllowUserToResizeRows = false;
            this.memoListDataGridView.AutoGenerateColumns = false;
            this.memoListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.memoListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.memoListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.memoListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.memoListDataGridView.ColumnHeadersHeight = 45;
            this.memoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.memoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIndex,
            this.jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn,
            this.jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn,
            this.jokasoMemoJokasoRenbanDataGridViewTextBoxColumn,
            this.jokasoMemoDaibunruiCdDataGridViewTextBoxColumn,
            this.jokasoMemoCdDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn,
            this.insertUserDataGridViewTextBoxColumn,
            this.insertTarmDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn,
            this.updateUserDataGridViewTextBoxColumn,
            this.updateTarmDataGridViewTextBoxColumn,
            this.memoDataGridViewTextBoxColumn,
            this.Delete});
            this.memoListDataGridView.DataMember = "JokasoMemoList";
            this.memoListDataGridView.DataSource = this.memoListDataSet;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.memoListDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.memoListDataGridView.EnableHeadersVisualStyles = false;
            this.memoListDataGridView.Location = new System.Drawing.Point(20, 318);
            this.memoListDataGridView.MultiSelect = false;
            this.memoListDataGridView.Name = "memoListDataGridView";
            this.memoListDataGridView.ReadOnly = true;
            this.memoListDataGridView.RowHeadersVisible = false;
            this.memoListDataGridView.RowTemplate.Height = 51;
            this.memoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.memoListDataGridView.Size = new System.Drawing.Size(579, 231);
            this.memoListDataGridView.TabIndex = 23;
            this.memoListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.memoListDataGridView_CellClick);
            // 
            // RowIndex
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RowIndex.DefaultCellStyle = dataGridViewCellStyle2;
            this.RowIndex.FillWeight = 15F;
            this.RowIndex.HeaderText = "No.";
            this.RowIndex.Name = "RowIndex";
            this.RowIndex.ReadOnly = true;
            this.RowIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowIndex.Visible = false;
            // 
            // jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn
            // 
            this.jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn.DataPropertyName = "JokasoMemoJokasoHokenjoCd";
            this.jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn.HeaderText = "JokasoMemoJokasoHokenjoCd";
            this.jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn.Name = "jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn";
            this.jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn
            // 
            this.jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn.DataPropertyName = "JokasoMemoJokasoTorokuNendo";
            this.jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn.HeaderText = "JokasoMemoJokasoTorokuNendo";
            this.jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn.Name = "jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn";
            this.jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoMemoJokasoRenbanDataGridViewTextBoxColumn
            // 
            this.jokasoMemoJokasoRenbanDataGridViewTextBoxColumn.DataPropertyName = "JokasoMemoJokasoRenban";
            this.jokasoMemoJokasoRenbanDataGridViewTextBoxColumn.HeaderText = "JokasoMemoJokasoRenban";
            this.jokasoMemoJokasoRenbanDataGridViewTextBoxColumn.Name = "jokasoMemoJokasoRenbanDataGridViewTextBoxColumn";
            this.jokasoMemoJokasoRenbanDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoMemoJokasoRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoMemoDaibunruiCdDataGridViewTextBoxColumn
            // 
            this.jokasoMemoDaibunruiCdDataGridViewTextBoxColumn.DataPropertyName = "JokasoMemoDaibunruiCd";
            this.jokasoMemoDaibunruiCdDataGridViewTextBoxColumn.HeaderText = "JokasoMemoDaibunruiCd";
            this.jokasoMemoDaibunruiCdDataGridViewTextBoxColumn.Name = "jokasoMemoDaibunruiCdDataGridViewTextBoxColumn";
            this.jokasoMemoDaibunruiCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoMemoDaibunruiCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoMemoCdDataGridViewTextBoxColumn
            // 
            this.jokasoMemoCdDataGridViewTextBoxColumn.DataPropertyName = "JokasoMemoCd";
            this.jokasoMemoCdDataGridViewTextBoxColumn.HeaderText = "JokasoMemoCd";
            this.jokasoMemoCdDataGridViewTextBoxColumn.Name = "jokasoMemoCdDataGridViewTextBoxColumn";
            this.jokasoMemoCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jokasoMemoCdDataGridViewTextBoxColumn.Visible = false;
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
            // memoDataGridViewTextBoxColumn
            // 
            this.memoDataGridViewTextBoxColumn.DataPropertyName = "Memo";
            this.memoDataGridViewTextBoxColumn.HeaderText = "選択済みメモ一覧";
            this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            this.memoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 15F;
            this.Delete.HeaderText = "取消";
            this.Delete.Image = global::FukjTabletSystem.Properties.Resources.top_close;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // tegakiMemoTextBox
            // 
            this.tegakiMemoTextBox.AllowDropDown = false;
            this.tegakiMemoTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.tegakiMemoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.tegakiMemoTextBox.CustomInputMode = FukjTabletSystem.Controls.ZTextBox.InputMode.None;
            this.tegakiMemoTextBox.CustomReadOnly = false;
            this.tegakiMemoTextBox.Location = new System.Drawing.Point(608, 228);
            this.tegakiMemoTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tegakiMemoTextBox.MaxLength = 100;
            this.tegakiMemoTextBox.Multiline = true;
            this.tegakiMemoTextBox.Name = "tegakiMemoTextBox";
            this.tegakiMemoTextBox.Size = new System.Drawing.Size(473, 118);
            this.tegakiMemoTextBox.TabIndex = 25;
            this.tegakiMemoTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Gold;
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label42.Location = new System.Drawing.Point(608, 196);
            this.label42.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(473, 31);
            this.label42.TabIndex = 24;
            this.label42.Text = "手書きメモ（最大100文字）";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.SkyBlue;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label24.Location = new System.Drawing.Point(608, 349);
            this.label24.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(140, 31);
            this.label24.TabIndex = 35;
            this.label24.Text = "検査日";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kakuteiButton.Location = new System.Drawing.Point(974, 514);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(122, 47);
            this.kakuteiButton.TabIndex = 44;
            this.kakuteiButton.Text = "確定登録";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // hukaJouhouGridView
            // 
            this.hukaJouhouGridView.AllowUserToAddRows = false;
            this.hukaJouhouGridView.AllowUserToDeleteRows = false;
            this.hukaJouhouGridView.AllowUserToResizeRows = false;
            this.hukaJouhouGridView.AutoGenerateColumns = false;
            this.hukaJouhouGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hukaJouhouGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hukaJouhouGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hukaJouhouGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.hukaJouhouGridView.ColumnHeadersHeight = 31;
            this.hukaJouhouGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.hukaJouhouGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kensaIraiHoteiKbnDataGridViewTextBoxColumn,
            this.kensaIraiHokenjoCdDataGridViewTextBoxColumn,
            this.kensaIraiNendoDataGridViewTextBoxColumn,
            this.kensaIraiRenbanDataGridViewTextBoxColumn,
            this.kensaIraiFileShubetsuCdDataGridViewTextBoxColumn,
            this.kensaIraiKanrenFilePathDataGridViewTextBoxColumn,
            this.kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn,
            this.insertDtDataGridViewTextBoxColumn1,
            this.insertUserDataGridViewTextBoxColumn1,
            this.insertTarmDataGridViewTextBoxColumn1,
            this.updateDtDataGridViewTextBoxColumn1,
            this.updateUserDataGridViewTextBoxColumn1,
            this.updateTarmDataGridViewTextBoxColumn1});
            this.hukaJouhouGridView.DataMember = "KensaIraiKanrenFileTbl";
            this.hukaJouhouGridView.DataSource = this.memoListDataSet;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hukaJouhouGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.hukaJouhouGridView.EnableHeadersVisualStyles = false;
            this.hukaJouhouGridView.Location = new System.Drawing.Point(608, 383);
            this.hukaJouhouGridView.MultiSelect = false;
            this.hukaJouhouGridView.Name = "hukaJouhouGridView";
            this.hukaJouhouGridView.ReadOnly = true;
            this.hukaJouhouGridView.RowHeadersVisible = false;
            this.hukaJouhouGridView.RowTemplate.Height = 31;
            this.hukaJouhouGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hukaJouhouGridView.Size = new System.Drawing.Size(473, 125);
            this.hukaJouhouGridView.TabIndex = 45;
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
            // kensaIraiFileShubetsuCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiFileShubetsuCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiFileShubetsuCd";
            this.kensaIraiFileShubetsuCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiFileShubetsuCd";
            this.kensaIraiFileShubetsuCdDataGridViewTextBoxColumn.Name = "kensaIraiFileShubetsuCdDataGridViewTextBoxColumn";
            this.kensaIraiFileShubetsuCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiFileShubetsuCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKanrenFilePathDataGridViewTextBoxColumn
            // 
            this.kensaIraiKanrenFilePathDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKanrenFilePath";
            this.kensaIraiKanrenFilePathDataGridViewTextBoxColumn.HeaderText = "KensaIraiKanrenFilePath";
            this.kensaIraiKanrenFilePathDataGridViewTextBoxColumn.Name = "kensaIraiKanrenFilePathDataGridViewTextBoxColumn";
            this.kensaIraiKanrenFilePathDataGridViewTextBoxColumn.ReadOnly = true;
            this.kensaIraiKanrenFilePathDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn
            // 
            this.kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKanrenFileMidashi";
            this.kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn.HeaderText = "検査付加情報（見出し）";
            this.kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn.Name = "kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn";
            this.kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insertDtDataGridViewTextBoxColumn1
            // 
            this.insertDtDataGridViewTextBoxColumn1.DataPropertyName = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn1.HeaderText = "InsertDt";
            this.insertDtDataGridViewTextBoxColumn1.Name = "insertDtDataGridViewTextBoxColumn1";
            this.insertDtDataGridViewTextBoxColumn1.ReadOnly = true;
            this.insertDtDataGridViewTextBoxColumn1.Visible = false;
            // 
            // insertUserDataGridViewTextBoxColumn1
            // 
            this.insertUserDataGridViewTextBoxColumn1.DataPropertyName = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn1.HeaderText = "InsertUser";
            this.insertUserDataGridViewTextBoxColumn1.Name = "insertUserDataGridViewTextBoxColumn1";
            this.insertUserDataGridViewTextBoxColumn1.ReadOnly = true;
            this.insertUserDataGridViewTextBoxColumn1.Visible = false;
            // 
            // insertTarmDataGridViewTextBoxColumn1
            // 
            this.insertTarmDataGridViewTextBoxColumn1.DataPropertyName = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn1.HeaderText = "InsertTarm";
            this.insertTarmDataGridViewTextBoxColumn1.Name = "insertTarmDataGridViewTextBoxColumn1";
            this.insertTarmDataGridViewTextBoxColumn1.ReadOnly = true;
            this.insertTarmDataGridViewTextBoxColumn1.Visible = false;
            // 
            // updateDtDataGridViewTextBoxColumn1
            // 
            this.updateDtDataGridViewTextBoxColumn1.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn1.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn1.Name = "updateDtDataGridViewTextBoxColumn1";
            this.updateDtDataGridViewTextBoxColumn1.ReadOnly = true;
            this.updateDtDataGridViewTextBoxColumn1.Visible = false;
            // 
            // updateUserDataGridViewTextBoxColumn1
            // 
            this.updateUserDataGridViewTextBoxColumn1.DataPropertyName = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn1.HeaderText = "UpdateUser";
            this.updateUserDataGridViewTextBoxColumn1.Name = "updateUserDataGridViewTextBoxColumn1";
            this.updateUserDataGridViewTextBoxColumn1.ReadOnly = true;
            this.updateUserDataGridViewTextBoxColumn1.Visible = false;
            // 
            // updateTarmDataGridViewTextBoxColumn1
            // 
            this.updateTarmDataGridViewTextBoxColumn1.DataPropertyName = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn1.HeaderText = "UpdateTarm";
            this.updateTarmDataGridViewTextBoxColumn1.Name = "updateTarmDataGridViewTextBoxColumn1";
            this.updateTarmDataGridViewTextBoxColumn1.ReadOnly = true;
            this.updateTarmDataGridViewTextBoxColumn1.Visible = false;
            // 
            // kensaNenTextBox
            // 
            this.kensaNenTextBox.AllowDropDown = false;
            this.kensaNenTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaNenTextBox.CustomInputMode = FukjTabletSystem.Controls.ZTextBox.InputMode.None;
            this.kensaNenTextBox.CustomReadOnly = true;
            this.kensaNenTextBox.Location = new System.Drawing.Point(748, 349);
            this.kensaNenTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.kensaNenTextBox.MaxLength = 40;
            this.kensaNenTextBox.Name = "kensaNenTextBox";
            this.kensaNenTextBox.ReadOnly = true;
            this.kensaNenTextBox.Size = new System.Drawing.Size(333, 31);
            this.kensaNenTextBox.TabIndex = 36;
            this.kensaNenTextBox.TabStop = false;
            // 
            // MemoTabPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.kensaNenTextBox);
            this.Controls.Add(this.hukaJouhouGridView);
            this.Controls.Add(this.kakuteiButton);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tegakiMemoTextBox);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.memoListDataGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.memoMstListBox);
            this.Controls.Add(this.tsuikaButton);
            this.Controls.Add(this.memoTextBox);
            this.Controls.Add(this.memoDaibunruiListBox);
            this.DisplayName = "メモ";
            this.Name = "MemoTabPage";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hukaJouhouGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zynas.Control.ZButton tsuikaButton;
        private Controls.ZTextBox memoTextBox;
        private System.Windows.Forms.ListBox memoDaibunruiListBox;
        private System.Windows.Forms.ListBox memoMstListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView memoListDataGridView;
        private Controls.ZTextBox tegakiMemoTextBox;
		private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label24;
        private Zynas.Control.ZButton kakuteiButton;
        private System.Windows.Forms.DataGridView hukaJouhouGridView;
        private MemoListDataSet memoListDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoMemoJokasoRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoMemoDaibunruiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoMemoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHoteiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiFileShubetsuCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKanrenFilePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKanrenFileMidashiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertDtDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertUserDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTarmDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateUserDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTarmDataGridViewTextBoxColumn1;
		private Controls.ZTextBox kensaNenTextBox;

    }
}
