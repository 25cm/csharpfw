namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class SeikyuShimeForm
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
            this.shimesyoriButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.msgTextBox = new System.Windows.Forms.RichTextBox();
            this.shimeDtTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.chikuRadioButton = new System.Windows.Forms.RadioButton();
            this.jimukyokuRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shimeSumiCheckBox = new System.Windows.Forms.CheckBox();
            this.gyoshaCdToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.gyoshaCdFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seikyuDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // shimesyoriButton
            // 
            this.shimesyoriButton.Location = new System.Drawing.Point(391, 366);
            this.shimesyoriButton.Name = "shimesyoriButton";
            this.shimesyoriButton.Size = new System.Drawing.Size(101, 37);
            this.shimesyoriButton.TabIndex = 18;
            this.shimesyoriButton.Text = "F1:締め処理";
            this.shimesyoriButton.UseVisualStyleBackColor = true;
            this.shimesyoriButton.Click += new System.EventHandler(this.shimesyoriButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.msgTextBox);
            this.mainPanel.Controls.Add(this.shimeDtTextBox);
            this.mainPanel.Controls.Add(this.chikuRadioButton);
            this.mainPanel.Controls.Add(this.jimukyokuRadioButton);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.shimeSumiCheckBox);
            this.mainPanel.Controls.Add(this.gyoshaCdToTextBox);
            this.mainPanel.Controls.Add(this.gyoshaCdFromTextBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.seikyuDtDateTimePicker);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.label10);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.shimesyoriButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(620, 406);
            this.mainPanel.TabIndex = 0;
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(21, 209);
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.ReadOnly = true;
            this.msgTextBox.Size = new System.Drawing.Size(591, 151);
            this.msgTextBox.TabIndex = 17;
            this.msgTextBox.Text = "";
            // 
            // shimeDtTextBox
            // 
            this.shimeDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_NEN;
            this.shimeDtTextBox.CustomDigitParts = 0;
            this.shimeDtTextBox.CustomFormat = null;
            this.shimeDtTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shimeDtTextBox.CustomReadOnly = false;
            this.shimeDtTextBox.Location = new System.Drawing.Point(115, 22);
            this.shimeDtTextBox.MaxLength = 6;
            this.shimeDtTextBox.Name = "shimeDtTextBox";
            this.shimeDtTextBox.Size = new System.Drawing.Size(86, 27);
            this.shimeDtTextBox.TabIndex = 2;
            this.shimeDtTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chikuRadioButton
            // 
            this.chikuRadioButton.AutoSize = true;
            this.chikuRadioButton.Location = new System.Drawing.Point(203, 122);
            this.chikuRadioButton.Name = "chikuRadioButton";
            this.chikuRadioButton.Size = new System.Drawing.Size(117, 24);
            this.chikuRadioButton.TabIndex = 13;
            this.chikuRadioButton.Text = "筑豊(水質検査)";
            this.chikuRadioButton.UseVisualStyleBackColor = true;
            // 
            // jimukyokuRadioButton
            // 
            this.jimukyokuRadioButton.AutoSize = true;
            this.jimukyokuRadioButton.Checked = true;
            this.jimukyokuRadioButton.Location = new System.Drawing.Point(115, 122);
            this.jimukyokuRadioButton.Name = "jimukyokuRadioButton";
            this.jimukyokuRadioButton.Size = new System.Drawing.Size(66, 24);
            this.jimukyokuRadioButton.TabIndex = 12;
            this.jimukyokuRadioButton.TabStop = true;
            this.jimukyokuRadioButton.Text = "事務局";
            this.jimukyokuRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "締め区分";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "処理メッセージ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "締め済業者";
            // 
            // shimeSumiCheckBox
            // 
            this.shimeSumiCheckBox.AutoSize = true;
            this.shimeSumiCheckBox.Location = new System.Drawing.Point(115, 155);
            this.shimeSumiCheckBox.Name = "shimeSumiCheckBox";
            this.shimeSumiCheckBox.Size = new System.Drawing.Size(132, 24);
            this.shimeSumiCheckBox.TabIndex = 15;
            this.shimeSumiCheckBox.Text = "削除・再作成する";
            this.shimeSumiCheckBox.UseVisualStyleBackColor = true;
            // 
            // gyoshaCdToTextBox
            // 
            this.gyoshaCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_SAISUIIN_CD;
            this.gyoshaCdToTextBox.CustomDigitParts = 0;
            this.gyoshaCdToTextBox.CustomFormat = null;
            this.gyoshaCdToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gyoshaCdToTextBox.CustomReadOnly = false;
            this.gyoshaCdToTextBox.Location = new System.Drawing.Point(218, 88);
            this.gyoshaCdToTextBox.MaxLength = 4;
            this.gyoshaCdToTextBox.Name = "gyoshaCdToTextBox";
            this.gyoshaCdToTextBox.Size = new System.Drawing.Size(51, 27);
            this.gyoshaCdToTextBox.TabIndex = 10;
            this.gyoshaCdToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gyoshaCdToTextBox.Leave += new System.EventHandler(this.gyoshaCdToTextBox_Leave);
            // 
            // gyoshaCdFromTextBox
            // 
            this.gyoshaCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyoshaCdFromTextBox.CustomDigitParts = 0;
            this.gyoshaCdFromTextBox.CustomFormat = null;
            this.gyoshaCdFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.gyoshaCdFromTextBox.CustomReadOnly = false;
            this.gyoshaCdFromTextBox.Location = new System.Drawing.Point(115, 88);
            this.gyoshaCdFromTextBox.MaxLength = 4;
            this.gyoshaCdFromTextBox.Name = "gyoshaCdFromTextBox";
            this.gyoshaCdFromTextBox.Size = new System.Drawing.Size(51, 27);
            this.gyoshaCdFromTextBox.TabIndex = 8;
            this.gyoshaCdFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.gyoshaCdFromTextBox.TextChanged += new System.EventHandler(this.gyoshaCdFromTextBox_TextChanged);
            this.gyoshaCdFromTextBox.Leave += new System.EventHandler(this.gyoshaCdFromTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "～";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 7;
            this.label19.Text = "業者コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "請求日";
            // 
            // seikyuDtDateTimePicker
            // 
            this.seikyuDtDateTimePicker.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.seikyuDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.seikyuDtDateTimePicker.Location = new System.Drawing.Point(115, 55);
            this.seikyuDtDateTimePicker.Name = "seikyuDtDateTimePicker";
            this.seikyuDtDateTimePicker.Size = new System.Drawing.Size(113, 27);
            this.seikyuDtDateTimePicker.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(92, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(202, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 20);
            this.label17.TabIndex = 3;
            this.label17.Text = "例)201401 (半角)";
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
            this.label11.Text = "締め年月";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(512, 366);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 19;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SeikyuShimeForm
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
            this.Name = "SeikyuShimeForm";
            this.Text = "請求締め処理";
            this.Load += new System.EventHandler(this.SeikyuShimeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeikyuShimeForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button shimesyoriButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private Zynas.Control.ZDate seikyuDtDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox shimeSumiCheckBox;
        private Control.NumberTextBox gyoshaCdToTextBox;
        private Control.NumberTextBox gyoshaCdFromTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton chikuRadioButton;
        private System.Windows.Forms.RadioButton jimukyokuRadioButton;
        private Control.NumberTextBox shimeDtTextBox;
        private System.Windows.Forms.RichTextBox msgTextBox;
    }
}