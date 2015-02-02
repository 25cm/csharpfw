namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    partial class KensaYoteiWariateForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.kakuteiButton = new System.Windows.Forms.Button();
            this.leftDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightKensainTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.setchiBashoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.kensaNengetsuGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.kensaYoteiToDateTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kensaYoteiToMonthTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kensaYoteiMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.kensaYoteiFromDateTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kensaYoteiDateRadioButton = new System.Windows.Forms.RadioButton();
            this.kensaYoteiFromMonthTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.filterButton = new System.Windows.Forms.Button();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKensaYoteiDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHoteiKbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNinsou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettiBasho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.leftDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.kensaNengetsuGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(943, 544);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(148, 37);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kakuteiButton.Location = new System.Drawing.Point(749, 544);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(148, 37);
            this.kakuteiButton.TabIndex = 8;
            this.kakuteiButton.Text = "振替確定";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // leftDataGridView
            // 
            this.leftDataGridView.AllowUserToAddRows = false;
            this.leftDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.ColKensaYoteiDate,
            this.ColHoteiKbn,
            this.ColNinsou,
            this.ColSettiBasho});
            this.leftDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftDataGridView.Location = new System.Drawing.Point(0, 0);
            this.leftDataGridView.Name = "leftDataGridView";
            this.leftDataGridView.RowHeadersVisible = false;
            this.leftDataGridView.RowTemplate.Height = 21;
            this.leftDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.leftDataGridView.Size = new System.Drawing.Size(487, 381);
            this.leftDataGridView.TabIndex = 0;
            this.leftDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDataGridView_CellEndEdit);
            this.leftDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.listDataGridView_CellValidating);
            // 
            // rightButton
            // 
            this.rightButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rightButton.Location = new System.Drawing.Point(20, 163);
            this.rightButton.Margin = new System.Windows.Forms.Padding(20, 40, 20, 40);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(52, 43);
            this.rightButton.TabIndex = 0;
            this.rightButton.Text = "＞";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.leftButton.Location = new System.Drawing.Point(20, 40);
            this.leftButton.Margin = new System.Windows.Forms.Padding(20, 40, 20, 40);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(52, 43);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "＜";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightKensainTextBox
            // 
            this.rightKensainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightKensainTextBox.Location = new System.Drawing.Point(661, 124);
            this.rightKensainTextBox.Name = "rightKensainTextBox";
            this.rightKensainTextBox.ReadOnly = true;
            this.rightKensainTextBox.Size = new System.Drawing.Size(108, 27);
            this.rightKensainTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(607, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "検査員";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "未割当検査予定";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rightDataGridView);
            this.panel1.Controls.Add(this.leftDataGridView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 381);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.leftButton);
            this.panel2.Controls.Add(this.rightButton);
            this.panel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel2.Location = new System.Drawing.Point(493, 6);
            this.panel2.MinimumSize = new System.Drawing.Size(93, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(93, 375);
            this.panel2.TabIndex = 1;
            // 
            // setchiBashoTextBox
            // 
            this.setchiBashoTextBox.AllowDropDown = false;
            this.setchiBashoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.setchiBashoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.setchiBashoTextBox.CustomReadOnly = false;
            this.setchiBashoTextBox.Location = new System.Drawing.Point(395, 38);
            this.setchiBashoTextBox.Name = "setchiBashoTextBox";
            this.setchiBashoTextBox.Size = new System.Drawing.Size(201, 27);
            this.setchiBashoTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "設置場所";
            // 
            // kensaNengetsuGroupBox
            // 
            this.kensaNengetsuGroupBox.Controls.Add(this.label5);
            this.kensaNengetsuGroupBox.Controls.Add(this.label6);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiToDateTextBox);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiToMonthTextBox);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiMonthRadioButton);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiFromDateTextBox);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiDateRadioButton);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiFromMonthTextBox);
            this.kensaNengetsuGroupBox.Location = new System.Drawing.Point(12, 12);
            this.kensaNengetsuGroupBox.Name = "kensaNengetsuGroupBox";
            this.kensaNengetsuGroupBox.Size = new System.Drawing.Size(310, 99);
            this.kensaNengetsuGroupBox.TabIndex = 0;
            this.kensaNengetsuGroupBox.TabStop = false;
            this.kensaNengetsuGroupBox.Text = "検査予定";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "～";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "～";
            // 
            // kensaYoteiToDateTextBox
            // 
            this.kensaYoteiToDateTextBox.AllowDropDown = false;
            this.kensaYoteiToDateTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaYoteiToDateTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaYoteiToDateTextBox.CustomReadOnly = false;
            this.kensaYoteiToDateTextBox.Location = new System.Drawing.Point(201, 26);
            this.kensaYoteiToDateTextBox.Name = "kensaYoteiToDateTextBox";
            this.kensaYoteiToDateTextBox.Size = new System.Drawing.Size(82, 27);
            this.kensaYoteiToDateTextBox.TabIndex = 3;
            // 
            // kensaYoteiToMonthTextBox
            // 
            this.kensaYoteiToMonthTextBox.AllowDropDown = false;
            this.kensaYoteiToMonthTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaYoteiToMonthTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaYoteiToMonthTextBox.CustomReadOnly = false;
            this.kensaYoteiToMonthTextBox.Location = new System.Drawing.Point(202, 59);
            this.kensaYoteiToMonthTextBox.Name = "kensaYoteiToMonthTextBox";
            this.kensaYoteiToMonthTextBox.Size = new System.Drawing.Size(82, 27);
            this.kensaYoteiToMonthTextBox.TabIndex = 7;
            // 
            // kensaYoteiMonthRadioButton
            // 
            this.kensaYoteiMonthRadioButton.AutoSize = true;
            this.kensaYoteiMonthRadioButton.Location = new System.Drawing.Point(13, 60);
            this.kensaYoteiMonthRadioButton.Name = "kensaYoteiMonthRadioButton";
            this.kensaYoteiMonthRadioButton.Size = new System.Drawing.Size(53, 24);
            this.kensaYoteiMonthRadioButton.TabIndex = 4;
            this.kensaYoteiMonthRadioButton.TabStop = true;
            this.kensaYoteiMonthRadioButton.Text = "年月";
            this.kensaYoteiMonthRadioButton.UseVisualStyleBackColor = true;
            // 
            // kensaYoteiFromDateTextBox
            // 
            this.kensaYoteiFromDateTextBox.AllowDropDown = false;
            this.kensaYoteiFromDateTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaYoteiFromDateTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaYoteiFromDateTextBox.CustomReadOnly = false;
            this.kensaYoteiFromDateTextBox.Location = new System.Drawing.Point(85, 26);
            this.kensaYoteiFromDateTextBox.Name = "kensaYoteiFromDateTextBox";
            this.kensaYoteiFromDateTextBox.Size = new System.Drawing.Size(82, 27);
            this.kensaYoteiFromDateTextBox.TabIndex = 1;
            // 
            // kensaYoteiDateRadioButton
            // 
            this.kensaYoteiDateRadioButton.AutoSize = true;
            this.kensaYoteiDateRadioButton.Location = new System.Drawing.Point(13, 27);
            this.kensaYoteiDateRadioButton.Name = "kensaYoteiDateRadioButton";
            this.kensaYoteiDateRadioButton.Size = new System.Drawing.Size(66, 24);
            this.kensaYoteiDateRadioButton.TabIndex = 0;
            this.kensaYoteiDateRadioButton.TabStop = true;
            this.kensaYoteiDateRadioButton.Text = "年月日";
            this.kensaYoteiDateRadioButton.UseVisualStyleBackColor = true;
            // 
            // kensaYoteiFromMonthTextBox
            // 
            this.kensaYoteiFromMonthTextBox.AllowDropDown = false;
            this.kensaYoteiFromMonthTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaYoteiFromMonthTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaYoteiFromMonthTextBox.CustomReadOnly = false;
            this.kensaYoteiFromMonthTextBox.Location = new System.Drawing.Point(86, 59);
            this.kensaYoteiFromMonthTextBox.Name = "kensaYoteiFromMonthTextBox";
            this.kensaYoteiFromMonthTextBox.Size = new System.Drawing.Size(82, 27);
            this.kensaYoteiFromMonthTextBox.TabIndex = 5;
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterButton.Location = new System.Drawing.Point(610, 33);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(148, 37);
            this.filterButton.TabIndex = 3;
            this.filterButton.Text = "抽出";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // colKey
            // 
            this.colKey.HeaderText = "key";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Visible = false;
            // 
            // ColKensaYoteiDate
            // 
            this.ColKensaYoteiDate.HeaderText = "予定日";
            this.ColKensaYoteiDate.Name = "ColKensaYoteiDate";
            this.ColKensaYoteiDate.ReadOnly = true;
            this.ColKensaYoteiDate.Width = 90;
            // 
            // ColHoteiKbn
            // 
            this.ColHoteiKbn.HeaderText = "区分";
            this.ColHoteiKbn.Name = "ColHoteiKbn";
            this.ColHoteiKbn.ReadOnly = true;
            this.ColHoteiKbn.Width = 70;
            // 
            // ColNinsou
            // 
            this.ColNinsou.HeaderText = "人槽";
            this.ColNinsou.Name = "ColNinsou";
            this.ColNinsou.ReadOnly = true;
            this.ColNinsou.Width = 70;
            // 
            // ColSettiBasho
            // 
            this.ColSettiBasho.HeaderText = "設置場所";
            this.ColSettiBasho.Name = "ColSettiBasho";
            this.ColSettiBasho.ReadOnly = true;
            this.ColSettiBasho.Width = 180;
            // 
            // rightDataGridView
            // 
            this.rightDataGridView.AllowUserToAddRows = false;
            this.rightDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rightDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.rightDataGridView.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightDataGridView.Location = new System.Drawing.Point(592, 0);
            this.rightDataGridView.Name = "rightDataGridView";
            this.rightDataGridView.RowHeadersVisible = false;
            this.rightDataGridView.RowTemplate.Height = 21;
            this.rightDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rightDataGridView.Size = new System.Drawing.Size(487, 381);
            this.rightDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "key";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "予定日";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "区分";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "人槽";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "設置場所";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 180;
            // 
            // KensaYoteiWariateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.kensaNengetsuGroupBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setchiBashoTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightKensainTextBox);
            this.Controls.Add(this.kakuteiButton);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KensaYoteiWariateForm";
            this.Text = "検査予定割当";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.KensaYoteiWariateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.kensaNengetsuGroupBox.ResumeLayout(false);
            this.kensaNengetsuGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button kakuteiButton;
        private Zynas.Control.ZDataGridView.ZDataGridView leftDataGridView;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.TextBox rightKensainTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel panel2;
        private FukjBizSystem.Control.ZTextBox setchiBashoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox kensaNengetsuGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private FukjBizSystem.Control.ZTextBox kensaYoteiToDateTextBox;
        private FukjBizSystem.Control.ZTextBox kensaYoteiToMonthTextBox;
        private System.Windows.Forms.RadioButton kensaYoteiMonthRadioButton;
        private FukjBizSystem.Control.ZTextBox kensaYoteiFromDateTextBox;
        private System.Windows.Forms.RadioButton kensaYoteiDateRadioButton;
        private FukjBizSystem.Control.ZTextBox kensaYoteiFromMonthTextBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKensaYoteiDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHoteiKbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNinsou;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettiBasho;
        private Zynas.Control.ZDataGridView.ZDataGridView rightDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}