namespace FukjBizSystem.Application.Boundary.Master
{
    partial class HokenjoMstShosaiForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.hokenjyoAdrTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.hokenjyoCdTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.hokenjyoTelNoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hokenjyoZipCdTextBox = new System.Windows.Forms.TextBox();
            this.entryButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.decisionButton = new System.Windows.Forms.Button();
            this.reInputButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.hokenjyoNmTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.delFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(205, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "例)810-0123　(半角)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "保健所コード";
            // 
            // hokenjyoAdrTextBox
            // 
            this.hokenjyoAdrTextBox.Location = new System.Drawing.Point(107, 145);
            this.hokenjyoAdrTextBox.MaxLength = 80;
            this.hokenjyoAdrTextBox.Name = "hokenjyoAdrTextBox";
            this.hokenjyoAdrTextBox.Size = new System.Drawing.Size(838, 27);
            this.hokenjyoAdrTextBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "住所";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "電話番号";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.delFlgCheckBox);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.label10);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.hokenjyoCdTextBox);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.hokenjyoAdrTextBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.hokenjyoTelNoTextBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.hokenjyoZipCdTextBox);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.changeButton);
            this.mainPanel.Controls.Add(this.decisionButton);
            this.mainPanel.Controls.Add(this.reInputButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.hokenjyoNmTextBox);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 593);
            this.mainPanel.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Meiryo", 9F);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(48, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 18);
            this.label12.TabIndex = 16;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Meiryo", 9F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(66, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Meiryo", 9F);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(79, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 18);
            this.label10.TabIndex = 5;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Meiryo", 9F);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(66, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 18);
            this.label9.TabIndex = 8;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Meiryo", 9F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(88, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "*";
            // 
            // hokenjyoCdTextBox
            // 
            this.hokenjyoCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.hokenjyoCdTextBox.CustomDigitParts = 0;
            this.hokenjyoCdTextBox.CustomFormat = null;
            this.hokenjyoCdTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.hokenjyoCdTextBox.CustomReadOnly = false;
            this.hokenjyoCdTextBox.Location = new System.Drawing.Point(107, 15);
            this.hokenjyoCdTextBox.MaxLength = 2;
            this.hokenjyoCdTextBox.Name = "hokenjyoCdTextBox";
            this.hokenjyoCdTextBox.Size = new System.Drawing.Size(50, 27);
            this.hokenjyoCdTextBox.TabIndex = 3;
            this.hokenjyoCdTextBox.Leave += new System.EventHandler(this.hokenjyoCdTextBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(250, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "例)092-0123-4567　(半角)";
            // 
            // hokenjyoTelNoTextBox
            // 
            this.hokenjyoTelNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hokenjyoTelNoTextBox.Location = new System.Drawing.Point(107, 112);
            this.hokenjyoTelNoTextBox.MaxLength = 13;
            this.hokenjyoTelNoTextBox.Name = "hokenjyoTelNoTextBox";
            this.hokenjyoTelNoTextBox.Size = new System.Drawing.Size(137, 27);
            this.hokenjyoTelNoTextBox.TabIndex = 13;
            this.hokenjyoTelNoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hokenjyoTelNoTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "郵便番号";
            // 
            // hokenjyoZipCdTextBox
            // 
            this.hokenjyoZipCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hokenjyoZipCdTextBox.Location = new System.Drawing.Point(107, 79);
            this.hokenjyoZipCdTextBox.MaxLength = 8;
            this.hokenjyoZipCdTextBox.Name = "hokenjyoZipCdTextBox";
            this.hokenjyoZipCdTextBox.Size = new System.Drawing.Size(92, 27);
            this.hokenjyoZipCdTextBox.TabIndex = 9;
            this.hokenjyoZipCdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hokenjyoZipCdTextBox_KeyPress);
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(421, 553);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 20;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(528, 553);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(101, 37);
            this.changeButton.TabIndex = 21;
            this.changeButton.Text = "F2:変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.Location = new System.Drawing.Point(849, 553);
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(101, 37);
            this.decisionButton.TabIndex = 24;
            this.decisionButton.Text = "F5:確定";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.decisionButton_Click);
            // 
            // reInputButton
            // 
            this.reInputButton.Location = new System.Drawing.Point(742, 553);
            this.reInputButton.Name = "reInputButton";
            this.reInputButton.Size = new System.Drawing.Size(101, 37);
            this.reInputButton.TabIndex = 23;
            this.reInputButton.Text = "F4:再入力";
            this.reInputButton.UseVisualStyleBackColor = true;
            this.reInputButton.Click += new System.EventHandler(this.reInputButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(635, 553);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 22;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "保健所名称";
            // 
            // hokenjyoNmTextBox
            // 
            this.hokenjyoNmTextBox.Location = new System.Drawing.Point(107, 46);
            this.hokenjyoNmTextBox.MaxLength = 24;
            this.hokenjyoNmTextBox.Name = "hokenjyoNmTextBox";
            this.hokenjyoNmTextBox.Size = new System.Drawing.Size(410, 27);
            this.hokenjyoNmTextBox.TabIndex = 6;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 25;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 178);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "削除フラグ";
            // 
            // delFlgCheckBox
            // 
            this.delFlgCheckBox.AutoSize = true;
            this.delFlgCheckBox.Location = new System.Drawing.Point(107, 180);
            this.delFlgCheckBox.Name = "delFlgCheckBox";
            this.delFlgCheckBox.Size = new System.Drawing.Size(15, 14);
            this.delFlgCheckBox.TabIndex = 19;
            this.delFlgCheckBox.UseVisualStyleBackColor = true;
            // 
            // HokenjoMstShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HokenjoMstShosaiForm";
            this.Text = "保健所情報";
            this.Load += new System.EventHandler(this.HokenjoMstShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HokenjoMstShosaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox hokenjyoAdrTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox hokenjyoTelNoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hokenjyoZipCdTextBox;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button decisionButton;
        private System.Windows.Forms.Button reInputButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox hokenjyoNmTextBox;
        private System.Windows.Forms.Button closeButton;
        private Control.NumberTextBox hokenjyoCdTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox delFlgCheckBox;
    }
}