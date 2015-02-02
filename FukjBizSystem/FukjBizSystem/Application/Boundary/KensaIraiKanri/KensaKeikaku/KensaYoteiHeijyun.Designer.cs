namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    partial class KensaYoteiHeijyunForm
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
            this.currentMonthTextBox = new System.Windows.Forms.TextBox();
            this.prevMonthButton = new System.Windows.Forms.Button();
            this.nextMonthButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.kensaTantouListDataGridView = new System.Windows.Forms.DataGridView();
            this.furikaeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.avg11JouIkaTextBox = new System.Windows.Forms.TextBox();
            this.avg11JouIzyouTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colKensaInCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKensaIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKadouRitsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col11JouIka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col11JouIkaDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col11JouIzyou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col11JouIzyouDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col7JouKensu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kensaTantouListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // currentMonthTextBox
            // 
            this.currentMonthTextBox.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.currentMonthTextBox.Location = new System.Drawing.Point(458, 12);
            this.currentMonthTextBox.Name = "currentMonthTextBox";
            this.currentMonthTextBox.ReadOnly = true;
            this.currentMonthTextBox.Size = new System.Drawing.Size(186, 30);
            this.currentMonthTextBox.TabIndex = 0;
            this.currentMonthTextBox.Text = "平成26年10月";
            this.currentMonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // prevMonthButton
            // 
            this.prevMonthButton.Location = new System.Drawing.Point(400, 14);
            this.prevMonthButton.Name = "prevMonthButton";
            this.prevMonthButton.Size = new System.Drawing.Size(52, 26);
            this.prevMonthButton.TabIndex = 1;
            this.prevMonthButton.Text = "＜＜";
            this.prevMonthButton.UseVisualStyleBackColor = true;
            this.prevMonthButton.Click += new System.EventHandler(this.prevMonthButton_Click);
            // 
            // nextMonthButton
            // 
            this.nextMonthButton.Location = new System.Drawing.Point(650, 14);
            this.nextMonthButton.Name = "nextMonthButton";
            this.nextMonthButton.Size = new System.Drawing.Size(52, 26);
            this.nextMonthButton.TabIndex = 2;
            this.nextMonthButton.Text = "＞＞";
            this.nextMonthButton.UseVisualStyleBackColor = true;
            this.nextMonthButton.Click += new System.EventHandler(this.nextMonthButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.closeButton.Location = new System.Drawing.Point(943, 544);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(148, 37);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // kensaTantouListDataGridView
            // 
            this.kensaTantouListDataGridView.AllowUserToAddRows = false;
            this.kensaTantouListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kensaTantouListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kensaTantouListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKensaInCd,
            this.ColKensaIn,
            this.ColKadouRitsu,
            this.Col11JouIka,
            this.Col11JouIkaDiff,
            this.Col11JouIzyou,
            this.Col11JouIzyouDiff,
            this.Col7JouKensu});
            this.kensaTantouListDataGridView.Location = new System.Drawing.Point(12, 115);
            this.kensaTantouListDataGridView.Name = "kensaTantouListDataGridView";
            this.kensaTantouListDataGridView.RowHeadersVisible = false;
            this.kensaTantouListDataGridView.RowTemplate.Height = 21;
            this.kensaTantouListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kensaTantouListDataGridView.Size = new System.Drawing.Size(1079, 423);
            this.kensaTantouListDataGridView.TabIndex = 8;
            this.kensaTantouListDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.kensaTantouListDataGridView_CellEndEdit);
            // 
            // furikaeButton
            // 
            this.furikaeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.furikaeButton.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.furikaeButton.Location = new System.Drawing.Point(737, 544);
            this.furikaeButton.Name = "furikaeButton";
            this.furikaeButton.Size = new System.Drawing.Size(148, 37);
            this.furikaeButton.TabIndex = 9;
            this.furikaeButton.Text = "予定振替";
            this.furikaeButton.UseVisualStyleBackColor = true;
            this.furikaeButton.Click += new System.EventHandler(this.furikaeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "平均値";
            // 
            // avg11JouIkaTextBox
            // 
            this.avg11JouIkaTextBox.Location = new System.Drawing.Point(160, 49);
            this.avg11JouIkaTextBox.Name = "avg11JouIkaTextBox";
            this.avg11JouIkaTextBox.ReadOnly = true;
            this.avg11JouIkaTextBox.Size = new System.Drawing.Size(100, 27);
            this.avg11JouIkaTextBox.TabIndex = 5;
            // 
            // avg11JouIzyouTextBox
            // 
            this.avg11JouIzyouTextBox.Location = new System.Drawing.Point(160, 82);
            this.avg11JouIzyouTextBox.Name = "avg11JouIzyouTextBox";
            this.avg11JouIzyouTextBox.ReadOnly = true;
            this.avg11JouIzyouTextBox.Size = new System.Drawing.Size(100, 27);
            this.avg11JouIzyouTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "50人槽以下";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "51人槽以上";
            // 
            // colKensaInCd
            // 
            this.colKensaInCd.HeaderText = "kensaInCd";
            this.colKensaInCd.Name = "colKensaInCd";
            this.colKensaInCd.ReadOnly = true;
            this.colKensaInCd.Visible = false;
            // 
            // ColKensaIn
            // 
            this.ColKensaIn.HeaderText = "検査員";
            this.ColKensaIn.Name = "ColKensaIn";
            this.ColKensaIn.ReadOnly = true;
            this.ColKensaIn.Width = 120;
            // 
            // ColKadouRitsu
            // 
            this.ColKadouRitsu.HeaderText = "予定稼働率";
            this.ColKadouRitsu.Name = "ColKadouRitsu";
            // 
            // Col11JouIka
            // 
            this.Col11JouIka.HeaderText = "11条(50人槽以下)";
            this.Col11JouIka.Name = "Col11JouIka";
            this.Col11JouIka.ReadOnly = true;
            this.Col11JouIka.Width = 90;
            // 
            // Col11JouIkaDiff
            // 
            this.Col11JouIkaDiff.HeaderText = "平均との差";
            this.Col11JouIkaDiff.Name = "Col11JouIkaDiff";
            this.Col11JouIkaDiff.ReadOnly = true;
            this.Col11JouIkaDiff.Width = 90;
            // 
            // Col11JouIzyou
            // 
            this.Col11JouIzyou.HeaderText = "11条(51人槽以上)";
            this.Col11JouIzyou.Name = "Col11JouIzyou";
            this.Col11JouIzyou.ReadOnly = true;
            this.Col11JouIzyou.Width = 90;
            // 
            // Col11JouIzyouDiff
            // 
            this.Col11JouIzyouDiff.HeaderText = "平均との差";
            this.Col11JouIzyouDiff.Name = "Col11JouIzyouDiff";
            this.Col11JouIzyouDiff.ReadOnly = true;
            this.Col11JouIzyouDiff.Width = 90;
            // 
            // Col7JouKensu
            // 
            this.Col7JouKensu.HeaderText = "7条(参考)";
            this.Col7JouKensu.Name = "Col7JouKensu";
            this.Col7JouKensu.ReadOnly = true;
            this.Col7JouKensu.Width = 90;
            // 
            // KensaYoteiHeijyunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.avg11JouIzyouTextBox);
            this.Controls.Add(this.avg11JouIkaTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.furikaeButton);
            this.Controls.Add(this.kensaTantouListDataGridView);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.nextMonthButton);
            this.Controls.Add(this.prevMonthButton);
            this.Controls.Add(this.currentMonthTextBox);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KensaYoteiHeijyunForm";
            this.Text = "検査予定平準化";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.KensaYoteiHeijyunForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kensaTantouListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currentMonthTextBox;
        private System.Windows.Forms.Button prevMonthButton;
        private System.Windows.Forms.Button nextMonthButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView kensaTantouListDataGridView;
        private System.Windows.Forms.Button furikaeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox avg11JouIkaTextBox;
        private System.Windows.Forms.TextBox avg11JouIzyouTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKensaInCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKensaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKadouRitsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col11JouIka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col11JouIkaDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col11JouIzyou;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col11JouIzyouDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col7JouKensu;
    }
}