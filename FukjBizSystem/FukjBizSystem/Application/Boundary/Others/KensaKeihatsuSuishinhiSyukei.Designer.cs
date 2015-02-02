namespace FukjBizSystem.Application.Boundary.Others
{
    partial class KensaKeihatsuSuishinhiSyukeiForm
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
			this.entryButton = new System.Windows.Forms.Button();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.gyosyaCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
			this.gyosyaCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
			this.yearToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
			this.yearFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.monthToComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.monthFromComboBox = new System.Windows.Forms.ComboBox();
			this.messageTextBox = new System.Windows.Forms.RichTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.shiharaiDtDateTimePicker = new Zynas.Control.ZDate(this.components);
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.closeButton = new System.Windows.Forms.Button();
			this.mainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// entryButton
			// 
			this.entryButton.Location = new System.Drawing.Point(391, 366);
			this.entryButton.Name = "entryButton";
			this.entryButton.Size = new System.Drawing.Size(101, 37);
			this.entryButton.TabIndex = 16;
			this.entryButton.Text = "F1:集計";
			this.entryButton.UseVisualStyleBackColor = true;
			this.entryButton.Click += new System.EventHandler(this.EntryButton_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.gyosyaCdToTextBox);
			this.mainPanel.Controls.Add(this.gyosyaCdFromTextBox);
			this.mainPanel.Controls.Add(this.yearToTextBox);
			this.mainPanel.Controls.Add(this.yearFromTextBox);
			this.mainPanel.Controls.Add(this.label1);
			this.mainPanel.Controls.Add(this.label19);
			this.mainPanel.Controls.Add(this.monthToComboBox);
			this.mainPanel.Controls.Add(this.label5);
			this.mainPanel.Controls.Add(this.monthFromComboBox);
			this.mainPanel.Controls.Add(this.messageTextBox);
			this.mainPanel.Controls.Add(this.label4);
			this.mainPanel.Controls.Add(this.label2);
			this.mainPanel.Controls.Add(this.shiharaiDtDateTimePicker);
			this.mainPanel.Controls.Add(this.label7);
			this.mainPanel.Controls.Add(this.label10);
			this.mainPanel.Controls.Add(this.label11);
			this.mainPanel.Controls.Add(this.entryButton);
			this.mainPanel.Controls.Add(this.closeButton);
			this.mainPanel.Location = new System.Drawing.Point(2, 1);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(620, 406);
			this.mainPanel.TabIndex = 0;
			// 
			// gyosyaCdToTextBox
			// 
			this.gyosyaCdToTextBox.AllowDropDown = false;
			this.gyosyaCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
			this.gyosyaCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
			this.gyosyaCdToTextBox.CustomReadOnly = false;
			this.gyosyaCdToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.gyosyaCdToTextBox.Location = new System.Drawing.Point(224, 90);
			this.gyosyaCdToTextBox.MaxLength = 4;
			this.gyosyaCdToTextBox.Name = "gyosyaCdToTextBox";
			this.gyosyaCdToTextBox.Size = new System.Drawing.Size(51, 27);
			this.gyosyaCdToTextBox.TabIndex = 13;
			this.gyosyaCdToTextBox.Leave += new System.EventHandler(this.gyosyaCdToTextBox_Leave);
			// 
			// gyosyaCdFromTextBox
			// 
			this.gyosyaCdFromTextBox.AllowDropDown = false;
			this.gyosyaCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
			this.gyosyaCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
			this.gyosyaCdFromTextBox.CustomReadOnly = false;
			this.gyosyaCdFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.gyosyaCdFromTextBox.Location = new System.Drawing.Point(120, 90);
			this.gyosyaCdFromTextBox.MaxLength = 4;
			this.gyosyaCdFromTextBox.Name = "gyosyaCdFromTextBox";
			this.gyosyaCdFromTextBox.Size = new System.Drawing.Size(51, 27);
			this.gyosyaCdFromTextBox.TabIndex = 11;
			this.gyosyaCdFromTextBox.Leave += new System.EventHandler(this.gyosyaCdFromTextBox_Leave);
			// 
			// yearToTextBox
			// 
			this.yearToTextBox.AllowDropDown = false;
			this.yearToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_NEN;
			this.yearToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
			this.yearToTextBox.CustomReadOnly = false;
			this.yearToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.yearToTextBox.Location = new System.Drawing.Point(281, 22);
			this.yearToTextBox.MaxLength = 4;
			this.yearToTextBox.Name = "yearToTextBox";
			this.yearToTextBox.Size = new System.Drawing.Size(51, 27);
			this.yearToTextBox.TabIndex = 5;
			this.yearToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// yearFromTextBox
			// 
			this.yearFromTextBox.AllowDropDown = false;
			this.yearFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_NEN;
			this.yearFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
			this.yearFromTextBox.CustomReadOnly = false;
			this.yearFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.yearFromTextBox.Location = new System.Drawing.Point(120, 22);
			this.yearFromTextBox.MaxLength = 4;
			this.yearFromTextBox.Name = "yearFromTextBox";
			this.yearFromTextBox.Size = new System.Drawing.Size(51, 27);
			this.yearFromTextBox.TabIndex = 2;
			this.yearFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(187, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 20);
			this.label1.TabIndex = 12;
			this.label1.Text = "～";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(21, 93);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(74, 20);
			this.label19.TabIndex = 10;
			this.label19.Text = "業者コード";
			// 
			// monthToComboBox
			// 
			this.monthToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.monthToComboBox.Items.AddRange(new object[] {
            "1月",
            "2月",
            "3月",
            "4月",
            "5月",
            "6月",
            "7月",
            "8月",
            "9月",
            "10月",
            "11月",
            "12月"});
			this.monthToComboBox.Location = new System.Drawing.Point(338, 22);
			this.monthToComboBox.Name = "monthToComboBox";
			this.monthToComboBox.Size = new System.Drawing.Size(60, 28);
			this.monthToComboBox.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(253, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 20);
			this.label5.TabIndex = 4;
			this.label5.Text = "～";
			// 
			// monthFromComboBox
			// 
			this.monthFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.monthFromComboBox.FormattingEnabled = true;
			this.monthFromComboBox.Items.AddRange(new object[] {
            "1月",
            "2月",
            "3月",
            "4月",
            "5月",
            "6月",
            "7月",
            "8月",
            "9月",
            "10月",
            "11月",
            "12月"});
			this.monthFromComboBox.Location = new System.Drawing.Point(177, 22);
			this.monthFromComboBox.Name = "monthFromComboBox";
			this.monthFromComboBox.Size = new System.Drawing.Size(60, 28);
			this.monthFromComboBox.TabIndex = 3;
			// 
			// messageTextBox
			// 
			this.messageTextBox.Location = new System.Drawing.Point(25, 209);
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.ReadOnly = true;
			this.messageTextBox.Size = new System.Drawing.Size(588, 146);
			this.messageTextBox.TabIndex = 15;
			this.messageTextBox.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 186);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 20);
			this.label4.TabIndex = 14;
			this.label4.Text = "処理メッセージ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "支払日";
			// 
			// shiharaiDtDateTimePicker
			// 
			this.shiharaiDtDateTimePicker.CustomFormat = "yyyy/MM/dd";
			this.shiharaiDtDateTimePicker.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.shiharaiDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.shiharaiDtDateTimePicker.Location = new System.Drawing.Point(120, 55);
			this.shiharaiDtDateTimePicker.Name = "shiharaiDtDateTimePicker";
			this.shiharaiDtDateTimePicker.Size = new System.Drawing.Size(117, 27);
			this.shiharaiDtDateTimePicker.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(92, 60);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(17, 20);
			this.label7.TabIndex = 8;
			this.label7.Text = "*";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.Color.Red;
			this.label10.Location = new System.Drawing.Point(92, 25);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(17, 20);
			this.label10.TabIndex = 1;
			this.label10.Text = "*";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(21, 25);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(61, 20);
			this.label11.TabIndex = 0;
			this.label11.Text = "集計年月";
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(512, 366);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(101, 37);
			this.closeButton.TabIndex = 17;
			this.closeButton.Text = "F12:閉じる";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// KensaKeihatsuSuishinhiSyukeiForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(627, 419);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "KensaKeihatsuSuishinhiSyukeiForm";
			this.Text = "検査啓発推進費集計";
			this.Load += new System.EventHandler(this.KensaKeihatsuSuishinhiSyukeiForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaKeihatsuSuishinhiSyukeiForm_KeyDown);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private Zynas.Control.ZDate shiharaiDtDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox messageTextBox;
		private System.Windows.Forms.ComboBox monthToComboBox;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox monthFromComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
		private Control.ZTextBox gyosyaCdToTextBox;
		private Control.ZTextBox gyosyaCdFromTextBox;
		private Control.ZTextBox yearToTextBox;
		private Control.ZTextBox yearFromTextBox;
    }
}