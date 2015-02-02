namespace FukjBizSystem.Application.Boundary.Master
{
    partial class MemoMstShosaiForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.juyodoCheckBox = new System.Windows.Forms.CheckBox();
            this.sentakuFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.memoCdTextBox = new System.Windows.Forms.TextBox();
            this.memoTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.memoDaibunruiListBox = new System.Windows.Forms.ListBox();
            this.entryButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.decisionButton = new System.Windows.Forms.Button();
            this.reInputButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.groupBox2);
            this.mainPanel.Controls.Add(this.groupBox4);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.changeButton);
            this.mainPanel.Controls.Add(this.decisionButton);
            this.mainPanel.Controls.Add(this.reInputButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1091, 593);
            this.mainPanel.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.juyodoCheckBox);
            this.groupBox2.Controls.Add(this.sentakuFlgCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(361, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 286);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "その他設定";
            // 
            // juyodoCheckBox
            // 
            this.juyodoCheckBox.AutoSize = true;
            this.juyodoCheckBox.Location = new System.Drawing.Point(21, 26);
            this.juyodoCheckBox.Name = "juyodoCheckBox";
            this.juyodoCheckBox.Size = new System.Drawing.Size(54, 24);
            this.juyodoCheckBox.TabIndex = 0;
            this.juyodoCheckBox.Text = "重要";
            this.juyodoCheckBox.UseVisualStyleBackColor = true;
            // 
            // sentakuFlgCheckBox
            // 
            this.sentakuFlgCheckBox.AutoSize = true;
            this.sentakuFlgCheckBox.Location = new System.Drawing.Point(21, 58);
            this.sentakuFlgCheckBox.Name = "sentakuFlgCheckBox";
            this.sentakuFlgCheckBox.Size = new System.Drawing.Size(80, 24);
            this.sentakuFlgCheckBox.TabIndex = 1;
            this.sentakuFlgCheckBox.Text = "選択不可";
            this.sentakuFlgCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.memoCdTextBox);
            this.groupBox4.Controls.Add(this.memoTextBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(502, 95);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "メモコード";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "メモ";
            // 
            // memoCdTextBox
            // 
            this.memoCdTextBox.Location = new System.Drawing.Point(91, 23);
            this.memoCdTextBox.Name = "memoCdTextBox";
            this.memoCdTextBox.ReadOnly = true;
            this.memoCdTextBox.Size = new System.Drawing.Size(41, 27);
            this.memoCdTextBox.TabIndex = 1;
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(91, 56);
            this.memoTextBox.MaxLength = 100;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(400, 27);
            this.memoTextBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(40, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.memoDaibunruiListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "大分類";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(50, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // memoDaibunruiListBox
            // 
            this.memoDaibunruiListBox.FormattingEnabled = true;
            this.memoDaibunruiListBox.ItemHeight = 20;
            this.memoDaibunruiListBox.Location = new System.Drawing.Point(15, 26);
            this.memoDaibunruiListBox.Name = "memoDaibunruiListBox";
            this.memoDaibunruiListBox.Size = new System.Drawing.Size(300, 244);
            this.memoDaibunruiListBox.TabIndex = 1;
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(421, 553);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 4;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(528, 553);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(101, 37);
            this.changeButton.TabIndex = 5;
            this.changeButton.Text = "F2:変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.Location = new System.Drawing.Point(849, 553);
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(101, 37);
            this.decisionButton.TabIndex = 8;
            this.decisionButton.Text = "F5:確定";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.decisionButton_Click);
            // 
            // reInputButton
            // 
            this.reInputButton.Location = new System.Drawing.Point(742, 553);
            this.reInputButton.Name = "reInputButton";
            this.reInputButton.Size = new System.Drawing.Size(101, 37);
            this.reInputButton.TabIndex = 7;
            this.reInputButton.Text = "F4:再入力";
            this.reInputButton.UseVisualStyleBackColor = true;
            this.reInputButton.Click += new System.EventHandler(this.reInputButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(635, 553);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MemoMstShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MemoMstShosaiForm";
            this.Text = "メモマスタ情報";
            this.Load += new System.EventHandler(this.MemoMstShosai_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MemoMstShosai_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button decisionButton;
        private System.Windows.Forms.Button reInputButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox juyodoCheckBox;
        private System.Windows.Forms.CheckBox sentakuFlgCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox memoTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox memoDaibunruiListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox memoCdTextBox;
    }
}