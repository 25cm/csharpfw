namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    partial class GenkinNyukinForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.kakuteiButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.stLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ryosyusyoButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.nyukinDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.kensaSyubetsuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaCdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.settishaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.settiBashoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.shishoNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kensaRyokinTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.shohizeiTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.nyukinTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検査種別";
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Location = new System.Drawing.Point(765, 543);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(101, 37);
            this.kakuteiButton.TabIndex = 19;
            this.kakuteiButton.Text = "F1:登録";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "業者";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.nyukinTextBox);
            this.mainPanel.Controls.Add(this.shohizeiTextBox);
            this.mainPanel.Controls.Add(this.kensaRyokinTextBox);
            this.mainPanel.Controls.Add(this.shishoNmTextBox);
            this.mainPanel.Controls.Add(this.settiBashoTextBox);
            this.mainPanel.Controls.Add(this.settishaNmTextBox);
            this.mainPanel.Controls.Add(this.gyoshaNmTextBox);
            this.mainPanel.Controls.Add(this.gyoshaCdTextBox);
            this.mainPanel.Controls.Add(this.kensaSyubetsuTextBox);
            this.mainPanel.Controls.Add(this.stLbl);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.ryosyusyoButton);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.nyukinDtDateTimePicker);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.kakuteiButton);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // stLbl
            // 
            this.stLbl.AutoSize = true;
            this.stLbl.Font = new System.Drawing.Font("Meiryo", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stLbl.ForeColor = System.Drawing.Color.Red;
            this.stLbl.Location = new System.Drawing.Point(967, 20);
            this.stLbl.Name = "stLbl";
            this.stLbl.Size = new System.Drawing.Size(99, 41);
            this.stLbl.TabIndex = 1;
            this.stLbl.Text = "入金済";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "入金金額";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "消費税";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "検査料金";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "受付支所";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 20);
            this.label14.TabIndex = 7;
            this.label14.Text = "設置場所";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "設置者名";
            // 
            // ryosyusyoButton
            // 
            this.ryosyusyoButton.Location = new System.Drawing.Point(872, 543);
            this.ryosyusyoButton.Name = "ryosyusyoButton";
            this.ryosyusyoButton.Size = new System.Drawing.Size(101, 37);
            this.ryosyusyoButton.TabIndex = 20;
            this.ryosyusyoButton.Text = "F6:領収書";
            this.ryosyusyoButton.UseVisualStyleBackColor = true;
            this.ryosyusyoButton.Click += new System.EventHandler(this.ryosyusyoButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(437, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 20);
            this.label11.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 289);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 20);
            this.label19.TabIndex = 17;
            this.label19.Text = "入金日";
            // 
            // nyukinDtDateTimePicker
            // 
            this.nyukinDtDateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.nyukinDtDateTimePicker.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nyukinDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nyukinDtDateTimePicker.Location = new System.Drawing.Point(100, 284);
            this.nyukinDtDateTimePicker.Name = "nyukinDtDateTimePicker";
            this.nyukinDtDateTimePicker.Size = new System.Drawing.Size(113, 27);
            this.nyukinDtDateTimePicker.TabIndex = 18;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(988, 543);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // kensaSyubetsuTextBox
            // 
            this.kensaSyubetsuTextBox.AllowDropDown = false;
            this.kensaSyubetsuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaSyubetsuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaSyubetsuTextBox.CustomReadOnly = true;
            this.kensaSyubetsuTextBox.Location = new System.Drawing.Point(100, 20);
            this.kensaSyubetsuTextBox.Name = "kensaSyubetsuTextBox";
            this.kensaSyubetsuTextBox.ReadOnly = true;
            this.kensaSyubetsuTextBox.Size = new System.Drawing.Size(144, 27);
            this.kensaSyubetsuTextBox.TabIndex = 22;
            this.kensaSyubetsuTextBox.TabStop = false;
            // 
            // gyoshaCdTextBox
            // 
            this.gyoshaCdTextBox.AllowDropDown = false;
            this.gyoshaCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gyoshaCdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaCdTextBox.CustomReadOnly = true;
            this.gyoshaCdTextBox.Location = new System.Drawing.Point(100, 53);
            this.gyoshaCdTextBox.Name = "gyoshaCdTextBox";
            this.gyoshaCdTextBox.ReadOnly = true;
            this.gyoshaCdTextBox.Size = new System.Drawing.Size(59, 27);
            this.gyoshaCdTextBox.TabIndex = 23;
            this.gyoshaCdTextBox.TabStop = false;
            // 
            // gyoshaNmTextBox
            // 
            this.gyoshaNmTextBox.AllowDropDown = false;
            this.gyoshaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gyoshaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaNmTextBox.CustomReadOnly = true;
            this.gyoshaNmTextBox.Location = new System.Drawing.Point(165, 53);
            this.gyoshaNmTextBox.Name = "gyoshaNmTextBox";
            this.gyoshaNmTextBox.ReadOnly = true;
            this.gyoshaNmTextBox.Size = new System.Drawing.Size(448, 27);
            this.gyoshaNmTextBox.TabIndex = 24;
            this.gyoshaNmTextBox.TabStop = false;
            // 
            // settishaNmTextBox
            // 
            this.settishaNmTextBox.AllowDropDown = false;
            this.settishaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.settishaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settishaNmTextBox.CustomReadOnly = true;
            this.settishaNmTextBox.Location = new System.Drawing.Point(100, 86);
            this.settishaNmTextBox.Name = "settishaNmTextBox";
            this.settishaNmTextBox.ReadOnly = true;
            this.settishaNmTextBox.Size = new System.Drawing.Size(269, 27);
            this.settishaNmTextBox.TabIndex = 25;
            this.settishaNmTextBox.TabStop = false;
            // 
            // settiBashoTextBox
            // 
            this.settiBashoTextBox.AllowDropDown = false;
            this.settiBashoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.settiBashoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settiBashoTextBox.CustomReadOnly = true;
            this.settiBashoTextBox.Location = new System.Drawing.Point(100, 119);
            this.settiBashoTextBox.Name = "settiBashoTextBox";
            this.settiBashoTextBox.ReadOnly = true;
            this.settiBashoTextBox.Size = new System.Drawing.Size(513, 27);
            this.settiBashoTextBox.TabIndex = 26;
            this.settiBashoTextBox.TabStop = false;
            // 
            // shishoNmTextBox
            // 
            this.shishoNmTextBox.AllowDropDown = false;
            this.shishoNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shishoNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shishoNmTextBox.CustomReadOnly = true;
            this.shishoNmTextBox.Location = new System.Drawing.Point(100, 152);
            this.shishoNmTextBox.Name = "shishoNmTextBox";
            this.shishoNmTextBox.ReadOnly = true;
            this.shishoNmTextBox.Size = new System.Drawing.Size(98, 27);
            this.shishoNmTextBox.TabIndex = 27;
            this.shishoNmTextBox.TabStop = false;
            // 
            // kensaRyokinTextBox
            // 
            this.kensaRyokinTextBox.AllowDropDown = false;
            this.kensaRyokinTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaRyokinTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaRyokinTextBox.CustomReadOnly = true;
            this.kensaRyokinTextBox.Location = new System.Drawing.Point(100, 185);
            this.kensaRyokinTextBox.Name = "kensaRyokinTextBox";
            this.kensaRyokinTextBox.ReadOnly = true;
            this.kensaRyokinTextBox.Size = new System.Drawing.Size(98, 27);
            this.kensaRyokinTextBox.TabIndex = 28;
            this.kensaRyokinTextBox.TabStop = false;
            // 
            // shohizeiTextBox
            // 
            this.shohizeiTextBox.AllowDropDown = false;
            this.shohizeiTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shohizeiTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shohizeiTextBox.CustomReadOnly = true;
            this.shohizeiTextBox.Location = new System.Drawing.Point(100, 218);
            this.shohizeiTextBox.Name = "shohizeiTextBox";
            this.shohizeiTextBox.ReadOnly = true;
            this.shohizeiTextBox.Size = new System.Drawing.Size(98, 27);
            this.shohizeiTextBox.TabIndex = 29;
            this.shohizeiTextBox.TabStop = false;
            // 
            // nyukinTextBox
            // 
            this.nyukinTextBox.AllowDropDown = false;
            this.nyukinTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.nyukinTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nyukinTextBox.CustomReadOnly = true;
            this.nyukinTextBox.Location = new System.Drawing.Point(100, 251);
            this.nyukinTextBox.Name = "nyukinTextBox";
            this.nyukinTextBox.ReadOnly = true;
            this.nyukinTextBox.Size = new System.Drawing.Size(98, 27);
            this.nyukinTextBox.TabIndex = 30;
            this.nyukinTextBox.TabStop = false;
            // 
            // GenkinNyukinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GenkinNyukinForm";
            this.Text = "現金入金";
            this.Load += new System.EventHandler(this.GenkinNyukinForm_Load);
            this.Shown += new System.EventHandler(this.GenkinNyukinForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenkinNyukinForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kakuteiButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label19;
        private Zynas.Control.ZDate nyukinDtDateTimePicker;
        private System.Windows.Forms.Button ryosyusyoButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label stLbl;
        private Control.ZTextBox kensaSyubetsuTextBox;
        private Control.ZTextBox gyoshaNmTextBox;
        private Control.ZTextBox gyoshaCdTextBox;
        private Control.ZTextBox settishaNmTextBox;
        private Control.ZTextBox settiBashoTextBox;
        private Control.ZTextBox nyukinTextBox;
        private Control.ZTextBox shohizeiTextBox;
        private Control.ZTextBox kensaRyokinTextBox;
        private Control.ZTextBox shishoNmTextBox;
    }
}