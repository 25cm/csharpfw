namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    partial class KensaYoteiList
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
            this.kensaYoteiListDataGridView = new System.Windows.Forms.DataGridView();
            this.ColNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKensaYoteiDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKensaShubetsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKyokaiNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettisha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSettiBasho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMapNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUniComposite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNinsou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKenain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKanriGyosha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.kensaYoteiFromMonthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kensaKbnComboBox = new System.Windows.Forms.ComboBox();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ninsouTextBox = new System.Windows.Forms.TextBox();
            this.kensaNengetsuGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.kensaYoteiToDateTextBox = new System.Windows.Forms.TextBox();
            this.kensaYoteiToMonthTextBox = new System.Windows.Forms.TextBox();
            this.kensaYoteiMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.kensaYoteiFromDateTextBox = new System.Windows.Forms.TextBox();
            this.kensaYoteiDateRadioButton = new System.Windows.Forms.RadioButton();
            this.kensainComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kensaYoteiListDataGridView)).BeginInit();
            this.kensaNengetsuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // kensaYoteiListDataGridView
            // 
            this.kensaYoteiListDataGridView.AllowUserToAddRows = false;
            this.kensaYoteiListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kensaYoteiListDataGridView.ColumnHeadersHeight = 50;
            this.kensaYoteiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.kensaYoteiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNo,
            this.colKey,
            this.ColKensaYoteiDate,
            this.ColKensaShubetsu,
            this.ColKyokaiNo,
            this.ColSettisha,
            this.ColSettiBasho,
            this.ColMapNo,
            this.ColUniComposite,
            this.ColNinsou,
            this.ColKenain,
            this.ColKanriGyosha,
            this.ColMemo,
            this.Column15,
            this.Column16});
            this.kensaYoteiListDataGridView.Location = new System.Drawing.Point(12, 93);
            this.kensaYoteiListDataGridView.Name = "kensaYoteiListDataGridView";
            this.kensaYoteiListDataGridView.RowHeadersVisible = false;
            this.kensaYoteiListDataGridView.RowTemplate.Height = 21;
            this.kensaYoteiListDataGridView.Size = new System.Drawing.Size(1026, 207);
            this.kensaYoteiListDataGridView.TabIndex = 8;
            this.kensaYoteiListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kensaYoteiListDataGridView_CellContentClick);
            this.kensaYoteiListDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.kensaYoteiListDataGridView_CellEndEdit);
            this.kensaYoteiListDataGridView.SelectionChanged += new System.EventHandler(this.kensaYoteiListDataGridView_SelectionChanged);
            // 
            // ColNo
            // 
            this.ColNo.HeaderText = "行";
            this.ColNo.Name = "ColNo";
            this.ColNo.ReadOnly = true;
            this.ColNo.Width = 20;
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
            this.ColKensaYoteiDate.Width = 80;
            // 
            // ColKensaShubetsu
            // 
            this.ColKensaShubetsu.HeaderText = "検査種別";
            this.ColKensaShubetsu.Name = "ColKensaShubetsu";
            this.ColKensaShubetsu.ReadOnly = true;
            this.ColKensaShubetsu.Width = 38;
            // 
            // ColKyokaiNo
            // 
            this.ColKyokaiNo.HeaderText = "検査番号";
            this.ColKyokaiNo.Name = "ColKyokaiNo";
            this.ColKyokaiNo.ReadOnly = true;
            this.ColKyokaiNo.Width = 80;
            // 
            // ColSettisha
            // 
            this.ColSettisha.HeaderText = "設置者名";
            this.ColSettisha.Name = "ColSettisha";
            this.ColSettisha.ReadOnly = true;
            this.ColSettisha.Width = 80;
            // 
            // ColSettiBasho
            // 
            this.ColSettiBasho.HeaderText = "設置場所";
            this.ColSettiBasho.Name = "ColSettiBasho";
            this.ColSettiBasho.ReadOnly = true;
            this.ColSettiBasho.Width = 95;
            // 
            // ColMapNo
            // 
            this.ColMapNo.HeaderText = "地図番号";
            this.ColMapNo.Name = "ColMapNo";
            this.ColMapNo.ReadOnly = true;
            this.ColMapNo.Width = 70;
            // 
            // ColUniComposite
            // 
            this.ColUniComposite.HeaderText = "単/合";
            this.ColUniComposite.Name = "ColUniComposite";
            this.ColUniComposite.ReadOnly = true;
            this.ColUniComposite.Width = 60;
            // 
            // ColNinsou
            // 
            this.ColNinsou.HeaderText = "人槽";
            this.ColNinsou.Name = "ColNinsou";
            this.ColNinsou.ReadOnly = true;
            this.ColNinsou.Width = 40;
            // 
            // ColKenain
            // 
            this.ColKenain.HeaderText = "検査員";
            this.ColKenain.Name = "ColKenain";
            this.ColKenain.ReadOnly = true;
            // 
            // ColKanriGyosha
            // 
            this.ColKanriGyosha.HeaderText = "管理業者";
            this.ColKanriGyosha.Name = "ColKanriGyosha";
            this.ColKanriGyosha.ReadOnly = true;
            this.ColKanriGyosha.Width = 90;
            // 
            // ColMemo
            // 
            this.ColMemo.HeaderText = "メモ";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            this.ColMemo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColMemo.Width = 30;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "はがき種類";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column15.Width = 80;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "はがき";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 25;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(929, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(109, 25);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // kensaYoteiFromMonthTextBox
            // 
            this.kensaYoteiFromMonthTextBox.Location = new System.Drawing.Point(71, 42);
            this.kensaYoteiFromMonthTextBox.Name = "kensaYoteiFromMonthTextBox";
            this.kensaYoteiFromMonthTextBox.Size = new System.Drawing.Size(82, 19);
            this.kensaYoteiFromMonthTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "検査種別";
            // 
            // kensaKbnComboBox
            // 
            this.kensaKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensaKbnComboBox.FormattingEnabled = true;
            this.kensaKbnComboBox.Location = new System.Drawing.Point(367, 66);
            this.kensaKbnComboBox.Name = "kensaKbnComboBox";
            this.kensaKbnComboBox.Size = new System.Drawing.Size(121, 20);
            this.kensaKbnComboBox.TabIndex = 6;
            // 
            // kensakuButton
            // 
            this.kensakuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kensakuButton.Location = new System.Drawing.Point(814, 12);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(109, 25);
            this.kensakuButton.TabIndex = 7;
            this.kensakuButton.Text = "検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "検査員";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "人槽";
            // 
            // ninsouTextBox
            // 
            this.ninsouTextBox.Location = new System.Drawing.Point(367, 15);
            this.ninsouTextBox.Name = "ninsouTextBox";
            this.ninsouTextBox.Size = new System.Drawing.Size(56, 19);
            this.ninsouTextBox.TabIndex = 2;
            // 
            // kensaNengetsuGroupBox
            // 
            this.kensaNengetsuGroupBox.Controls.Add(this.label5);
            this.kensaNengetsuGroupBox.Controls.Add(this.label1);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiToDateTextBox);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiToMonthTextBox);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiMonthRadioButton);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiFromDateTextBox);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiDateRadioButton);
            this.kensaNengetsuGroupBox.Controls.Add(this.kensaYoteiFromMonthTextBox);
            this.kensaNengetsuGroupBox.Location = new System.Drawing.Point(12, 12);
            this.kensaNengetsuGroupBox.Name = "kensaNengetsuGroupBox";
            this.kensaNengetsuGroupBox.Size = new System.Drawing.Size(284, 70);
            this.kensaNengetsuGroupBox.TabIndex = 0;
            this.kensaNengetsuGroupBox.TabStop = false;
            this.kensaNengetsuGroupBox.Text = "検査年月";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "～";
            // 
            // kensaYoteiToDateTextBox
            // 
            this.kensaYoteiToDateTextBox.Location = new System.Drawing.Point(182, 17);
            this.kensaYoteiToDateTextBox.Name = "kensaYoteiToDateTextBox";
            this.kensaYoteiToDateTextBox.Size = new System.Drawing.Size(82, 19);
            this.kensaYoteiToDateTextBox.TabIndex = 3;
            // 
            // kensaYoteiToMonthTextBox
            // 
            this.kensaYoteiToMonthTextBox.Location = new System.Drawing.Point(182, 42);
            this.kensaYoteiToMonthTextBox.Name = "kensaYoteiToMonthTextBox";
            this.kensaYoteiToMonthTextBox.Size = new System.Drawing.Size(82, 19);
            this.kensaYoteiToMonthTextBox.TabIndex = 7;
            // 
            // kensaYoteiMonthRadioButton
            // 
            this.kensaYoteiMonthRadioButton.AutoSize = true;
            this.kensaYoteiMonthRadioButton.Location = new System.Drawing.Point(6, 43);
            this.kensaYoteiMonthRadioButton.Name = "kensaYoteiMonthRadioButton";
            this.kensaYoteiMonthRadioButton.Size = new System.Drawing.Size(47, 16);
            this.kensaYoteiMonthRadioButton.TabIndex = 4;
            this.kensaYoteiMonthRadioButton.TabStop = true;
            this.kensaYoteiMonthRadioButton.Text = "年月";
            this.kensaYoteiMonthRadioButton.UseVisualStyleBackColor = true;
            // 
            // kensaYoteiFromDateTextBox
            // 
            this.kensaYoteiFromDateTextBox.Location = new System.Drawing.Point(71, 17);
            this.kensaYoteiFromDateTextBox.Name = "kensaYoteiFromDateTextBox";
            this.kensaYoteiFromDateTextBox.Size = new System.Drawing.Size(82, 19);
            this.kensaYoteiFromDateTextBox.TabIndex = 1;
            // 
            // kensaYoteiDateRadioButton
            // 
            this.kensaYoteiDateRadioButton.AutoSize = true;
            this.kensaYoteiDateRadioButton.Location = new System.Drawing.Point(6, 18);
            this.kensaYoteiDateRadioButton.Name = "kensaYoteiDateRadioButton";
            this.kensaYoteiDateRadioButton.Size = new System.Drawing.Size(59, 16);
            this.kensaYoteiDateRadioButton.TabIndex = 0;
            this.kensaYoteiDateRadioButton.TabStop = true;
            this.kensaYoteiDateRadioButton.Text = "年月日";
            this.kensaYoteiDateRadioButton.UseVisualStyleBackColor = true;
            this.kensaYoteiDateRadioButton.CheckedChanged += new System.EventHandler(this.kensaYoteiDateRadioButton_CheckedChanged);
            // 
            // kensainComboBox
            // 
            this.kensainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensainComboBox.FormattingEnabled = true;
            this.kensainComboBox.Location = new System.Drawing.Point(367, 40);
            this.kensainComboBox.Name = "kensainComboBox";
            this.kensainComboBox.Size = new System.Drawing.Size(143, 20);
            this.kensainComboBox.TabIndex = 4;
            // 
            // KensaYoteiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 312);
            this.Controls.Add(this.kensainComboBox);
            this.Controls.Add(this.kensaNengetsuGroupBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ninsouTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kensakuButton);
            this.Controls.Add(this.kensaKbnComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.kensaYoteiListDataGridView);
            this.Name = "KensaYoteiList";
            this.Text = "検査予定日入力";
            this.Load += new System.EventHandler(this.KensaYoteiList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kensaYoteiListDataGridView)).EndInit();
            this.kensaNengetsuGroupBox.ResumeLayout(false);
            this.kensaNengetsuGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView kensaYoteiListDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox kensaYoteiFromMonthTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox kensaKbnComboBox;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ninsouTextBox;
        private System.Windows.Forms.GroupBox kensaNengetsuGroupBox;
        private System.Windows.Forms.RadioButton kensaYoteiMonthRadioButton;
        private System.Windows.Forms.RadioButton kensaYoteiDateRadioButton;
        private System.Windows.Forms.TextBox kensaYoteiToMonthTextBox;
        private System.Windows.Forms.TextBox kensaYoteiToDateTextBox;
        private System.Windows.Forms.TextBox kensaYoteiFromDateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKensaYoteiDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKensaShubetsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKyokaiNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettisha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSettiBasho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMapNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUniComposite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNinsou;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKenain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKanriGyosha;
        private System.Windows.Forms.DataGridViewLinkColumn ColMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.ComboBox kensainComboBox;
    }
}