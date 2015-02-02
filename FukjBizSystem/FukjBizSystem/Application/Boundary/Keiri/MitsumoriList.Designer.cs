namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class MitsumoriListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MaeukekinListDataGridView = new System.Windows.Forms.DataGridView();
            this.MaeukeNo1Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShisyoCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShisyoNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaeukeNo2Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KinyuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NyukinDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FurikomiNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NyukingakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FurikomiKanaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torokuButton = new System.Windows.Forms.Button();
            this.MaeukekinListPanel = new System.Windows.Forms.Panel();
            this.suishitsuMstListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.shosaiButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.FurikomiNmTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ShisyoNmComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MitsumoriDtCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MitsumoriDtToTextBox = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.MitsumoriDtFromTextBox = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.suishitsuCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.suishitsuCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MaeukekinListDataGridView)).BeginInit();
            this.MaeukekinListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MaeukekinListDataGridView
            // 
            this.MaeukekinListDataGridView.AllowUserToAddRows = false;
            this.MaeukekinListDataGridView.AllowUserToResizeRows = false;
            this.MaeukekinListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaeukekinListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaeukekinListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaeukeNo1Col,
            this.ShisyoCd,
            this.ShisyoNm,
            this.MaeukeNo2Col,
            this.KinyuNmCol,
            this.NyukinDtCol,
            this.FurikomiNmCol,
            this.NyukingakuCol,
            this.FurikomiKanaCol});
            this.MaeukekinListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.MaeukekinListDataGridView.MultiSelect = false;
            this.MaeukekinListDataGridView.Name = "MaeukekinListDataGridView";
            this.MaeukekinListDataGridView.RowHeadersVisible = false;
            this.MaeukekinListDataGridView.RowTemplate.Height = 21;
            this.MaeukekinListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MaeukekinListDataGridView.Size = new System.Drawing.Size(1085, 312);
            this.MaeukekinListDataGridView.TabIndex = 0;
            // 
            // MaeukeNo1Col
            // 
            this.MaeukeNo1Col.HeaderText = "見積No";
            this.MaeukeNo1Col.MinimumWidth = 90;
            this.MaeukeNo1Col.Name = "MaeukeNo1Col";
            this.MaeukeNo1Col.ReadOnly = true;
            this.MaeukeNo1Col.Width = 90;
            // 
            // ShisyoCd
            // 
            this.ShisyoCd.HeaderText = "支所ｺｰﾄﾞ";
            this.ShisyoCd.MinimumWidth = 90;
            this.ShisyoCd.Name = "ShisyoCd";
            this.ShisyoCd.Width = 90;
            // 
            // ShisyoNm
            // 
            this.ShisyoNm.HeaderText = "支所名";
            this.ShisyoNm.MinimumWidth = 100;
            this.ShisyoNm.Name = "ShisyoNm";
            // 
            // MaeukeNo2Col
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaeukeNo2Col.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaeukeNo2Col.HeaderText = "業者ｺｰﾄﾞ";
            this.MaeukeNo2Col.MinimumWidth = 90;
            this.MaeukeNo2Col.Name = "MaeukeNo2Col";
            this.MaeukeNo2Col.ReadOnly = true;
            this.MaeukeNo2Col.Width = 90;
            // 
            // KinyuNmCol
            // 
            this.KinyuNmCol.HeaderText = "見積先名称";
            this.KinyuNmCol.MinimumWidth = 200;
            this.KinyuNmCol.Name = "KinyuNmCol";
            this.KinyuNmCol.ReadOnly = true;
            this.KinyuNmCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KinyuNmCol.Width = 200;
            // 
            // NyukinDtCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NyukinDtCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.NyukinDtCol.HeaderText = "見積日";
            this.NyukinDtCol.MinimumWidth = 90;
            this.NyukinDtCol.Name = "NyukinDtCol";
            this.NyukinDtCol.ReadOnly = true;
            this.NyukinDtCol.Width = 90;
            // 
            // FurikomiNmCol
            // 
            this.FurikomiNmCol.HeaderText = "見積件名";
            this.FurikomiNmCol.MinimumWidth = 200;
            this.FurikomiNmCol.Name = "FurikomiNmCol";
            this.FurikomiNmCol.ReadOnly = true;
            this.FurikomiNmCol.Width = 200;
            // 
            // NyukingakuCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NyukingakuCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.NyukingakuCol.HeaderText = "見積合計";
            this.NyukingakuCol.MinimumWidth = 90;
            this.NyukingakuCol.Name = "NyukingakuCol";
            this.NyukingakuCol.ReadOnly = true;
            this.NyukingakuCol.Width = 90;
            // 
            // FurikomiKanaCol
            // 
            this.FurikomiKanaCol.HeaderText = "有効期限";
            this.FurikomiKanaCol.MinimumWidth = 90;
            this.FurikomiKanaCol.Name = "FurikomiKanaCol";
            this.FurikomiKanaCol.ReadOnly = true;
            this.FurikomiKanaCol.Width = 90;
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(412, 544);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:新規見積";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // MaeukekinListPanel
            // 
            this.MaeukekinListPanel.Controls.Add(this.suishitsuMstListCountLabel);
            this.MaeukekinListPanel.Controls.Add(this.label4);
            this.MaeukekinListPanel.Controls.Add(this.MaeukekinListDataGridView);
            this.MaeukekinListPanel.Location = new System.Drawing.Point(1, 187);
            this.MaeukekinListPanel.Name = "MaeukekinListPanel";
            this.MaeukekinListPanel.Size = new System.Drawing.Size(1090, 339);
            this.MaeukekinListPanel.TabIndex = 1;
            // 
            // suishitsuMstListCountLabel
            // 
            this.suishitsuMstListCountLabel.AutoSize = true;
            this.suishitsuMstListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.suishitsuMstListCountLabel.Name = "suishitsuMstListCountLabel";
            this.suishitsuMstListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.suishitsuMstListCountLabel.TabIndex = 2;
            this.suishitsuMstListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "検索結果：";
            // 
            // shosaiButton
            // 
            this.shosaiButton.Location = new System.Drawing.Point(519, 544);
            this.shosaiButton.Name = "shosaiButton";
            this.shosaiButton.Size = new System.Drawing.Size(101, 37);
            this.shosaiButton.TabIndex = 3;
            this.shosaiButton.Text = "F2:詳細";
            this.shosaiButton.UseVisualStyleBackColor = true;
            this.shosaiButton.Click += new System.EventHandler(this.shosaiButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "～";
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(854, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 4;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // FurikomiNmTextBox
            // 
            this.FurikomiNmTextBox.Location = new System.Drawing.Point(388, 66);
            this.FurikomiNmTextBox.Name = "FurikomiNmTextBox";
            this.FurikomiNmTextBox.Size = new System.Drawing.Size(305, 27);
            this.FurikomiNmTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "見積先名";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 11;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "業者コード";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.panel1);
            this.searchPanel.Controls.Add(this.textBox1);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.ShisyoNmComboBox);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.MitsumoriDtCheckBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.MitsumoriDtToTextBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.MitsumoriDtFromTextBox);
            this.searchPanel.Controls.Add(this.suishitsuCdToTextBox);
            this.searchPanel.Controls.Add(this.suishitsuCdFromTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.FurikomiNmTextBox);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 184);
            this.searchPanel.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(391, 27);
            this.textBox1.TabIndex = 151;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 150;
            this.label8.Text = "見積件名";
            // 
            // ShisyoNmComboBox
            // 
            this.ShisyoNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShisyoNmComboBox.FormattingEnabled = true;
            this.ShisyoNmComboBox.Location = new System.Drawing.Point(108, 32);
            this.ShisyoNmComboBox.Name = "ShisyoNmComboBox";
            this.ShisyoNmComboBox.Size = new System.Drawing.Size(191, 28);
            this.ShisyoNmComboBox.TabIndex = 149;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 148;
            this.label6.Text = "支所";
            // 
            // MitsumoriDtCheckBox
            // 
            this.MitsumoriDtCheckBox.AutoSize = true;
            this.MitsumoriDtCheckBox.Location = new System.Drawing.Point(9, 139);
            this.MitsumoriDtCheckBox.Name = "MitsumoriDtCheckBox";
            this.MitsumoriDtCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MitsumoriDtCheckBox.TabIndex = 91;
            this.MitsumoriDtCheckBox.UseVisualStyleBackColor = true;
            this.MitsumoriDtCheckBox.CheckedChanged += new System.EventHandler(this.MitsumoriDtCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 90;
            this.label7.Text = "～";
            // 
            // MitsumoriDtToTextBox
            // 
            this.MitsumoriDtToTextBox.Enabled = false;
            this.MitsumoriDtToTextBox.Location = new System.Drawing.Point(285, 132);
            this.MitsumoriDtToTextBox.Name = "MitsumoriDtToTextBox";
            this.MitsumoriDtToTextBox.Size = new System.Drawing.Size(145, 27);
            this.MitsumoriDtToTextBox.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 88;
            this.label5.Text = "見積日";
            // 
            // MitsumoriDtFromTextBox
            // 
            this.MitsumoriDtFromTextBox.Enabled = false;
            this.MitsumoriDtFromTextBox.Location = new System.Drawing.Point(106, 132);
            this.MitsumoriDtFromTextBox.Name = "MitsumoriDtFromTextBox";
            this.MitsumoriDtFromTextBox.Size = new System.Drawing.Size(145, 27);
            this.MitsumoriDtFromTextBox.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索条件";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(878, 133);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(985, 132);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 10;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Location = new System.Drawing.Point(990, 544);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(626, 544);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "F3:見積複写";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(747, 544);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "F5:見積印刷";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // suishitsuCdToTextBox
            // 
            this.suishitsuCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.suishitsuCdToTextBox.CustomDigitParts = 0;
            this.suishitsuCdToTextBox.CustomFormat = null;
            this.suishitsuCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.suishitsuCdToTextBox.CustomReadOnly = false;
            this.suishitsuCdToTextBox.Location = new System.Drawing.Point(211, 66);
            this.suishitsuCdToTextBox.MaxLength = 6;
            this.suishitsuCdToTextBox.Name = "suishitsuCdToTextBox";
            this.suishitsuCdToTextBox.Size = new System.Drawing.Size(51, 27);
            this.suishitsuCdToTextBox.TabIndex = 6;
            // 
            // suishitsuCdFromTextBox
            // 
            this.suishitsuCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.suishitsuCdFromTextBox.CustomDigitParts = 0;
            this.suishitsuCdFromTextBox.CustomFormat = null;
            this.suishitsuCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.suishitsuCdFromTextBox.CustomReadOnly = false;
            this.suishitsuCdFromTextBox.Location = new System.Drawing.Point(108, 66);
            this.suishitsuCdFromTextBox.MaxLength = 6;
            this.suishitsuCdFromTextBox.Name = "suishitsuCdFromTextBox";
            this.suishitsuCdFromTextBox.Size = new System.Drawing.Size(51, 27);
            this.suishitsuCdFromTextBox.TabIndex = 4;
            this.suishitsuCdFromTextBox.Text = "1234";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(809, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 50);
            this.panel1.TabIndex = 152;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(13, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 41);
            this.label9.TabIndex = 0;
            this.label9.Text = "MockUp";
            // 
            // MitsumoriListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.MaeukekinListPanel);
            this.Controls.Add(this.shosaiButton);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.tojiruButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MitsumoriListForm";
            this.Text = "見積一覧";
            ((System.ComponentModel.ISupportInitialize)(this.MaeukekinListDataGridView)).EndInit();
            this.MaeukekinListPanel.ResumeLayout(false);
            this.MaeukekinListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MaeukekinListDataGridView;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel MaeukekinListPanel;
        private System.Windows.Forms.Label suishitsuMstListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button shosaiButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.TextBox FurikomiNmTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button tojiruButton;
        private Control.NumberTextBox suishitsuCdFromTextBox;
        private Control.NumberTextBox suishitsuCdToTextBox;
        private System.Windows.Forms.CheckBox MitsumoriDtCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker MitsumoriDtToTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker MitsumoriDtFromTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ShisyoNmComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaeukeNo1Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShisyoCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShisyoNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaeukeNo2Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn KinyuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NyukinDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FurikomiNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NyukingakuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FurikomiKanaCol;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;

    }
}