namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class SyokenManualInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyokenManualInputForm));
            this.syokenWdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.insertPositionTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.checkItemNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.clearButton = new System.Windows.Forms.Button();
            this.shitekiKasyoNoComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.handanComboBox = new System.Windows.Forms.ComboBox();
            this.torokuButton = new System.Windows.Forms.Button();
            this.syokiboGappeiPictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.syokiboGappeiPanel = new System.Windows.Forms.Panel();
            this.bakkiGataPanel = new System.Windows.Forms.Panel();
            this.bakkiGataPictureBox = new System.Windows.Forms.PictureBox();
            this.gappeiPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.gappeiPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.syokiboGappeiPictureBox)).BeginInit();
            this.syokiboGappeiPanel.SuspendLayout();
            this.bakkiGataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bakkiGataPictureBox)).BeginInit();
            this.gappeiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gappeiPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // syokenWdTextBox
            // 
            this.syokenWdTextBox.AllowDropDown = false;
            this.syokenWdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.syokenWdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.syokenWdTextBox.CustomReadOnly = false;
            this.syokenWdTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.syokenWdTextBox.Location = new System.Drawing.Point(84, 12);
            this.syokenWdTextBox.MaxLength = 88;
            this.syokenWdTextBox.Name = "syokenWdTextBox";
            this.syokenWdTextBox.Size = new System.Drawing.Size(616, 27);
            this.syokenWdTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "所見入力";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "挿入位置";
            // 
            // insertPositionTextBox
            // 
            this.insertPositionTextBox.AllowDropDown = false;
            this.insertPositionTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.insertPositionTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.insertPositionTextBox.CustomReadOnly = false;
            this.insertPositionTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.insertPositionTextBox.Location = new System.Drawing.Point(84, 44);
            this.insertPositionTextBox.MaxLength = 2;
            this.insertPositionTextBox.Name = "insertPositionTextBox";
            this.insertPositionTextBox.Size = new System.Drawing.Size(56, 27);
            this.insertPositionTextBox.TabIndex = 3;
            this.insertPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "チェック項目No";
            // 
            // checkItemNoTextBox
            // 
            this.checkItemNoTextBox.AllowDropDown = false;
            this.checkItemNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.checkItemNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.checkItemNoTextBox.CustomReadOnly = false;
            this.checkItemNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.checkItemNoTextBox.Location = new System.Drawing.Point(268, 44);
            this.checkItemNoTextBox.MaxLength = 2;
            this.checkItemNoTextBox.Name = "checkItemNoTextBox";
            this.checkItemNoTextBox.Size = new System.Drawing.Size(56, 27);
            this.checkItemNoTextBox.TabIndex = 5;
            this.checkItemNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(724, 36);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // shitekiKasyoNoComboBox
            // 
            this.shitekiKasyoNoComboBox.DisplayMember = "TodofukenNm";
            this.shitekiKasyoNoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shitekiKasyoNoComboBox.FormattingEnabled = true;
            this.shitekiKasyoNoComboBox.Location = new System.Drawing.Point(412, 44);
            this.shitekiKasyoNoComboBox.Name = "shitekiKasyoNoComboBox";
            this.shitekiKasyoNoComboBox.Size = new System.Drawing.Size(152, 28);
            this.shitekiKasyoNoComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "指摘箇所";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(725, 464);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 15;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(580, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "判断";
            // 
            // handanComboBox
            // 
            this.handanComboBox.DisplayMember = "TodofukenNm";
            this.handanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.handanComboBox.FormattingEnabled = true;
            this.handanComboBox.Location = new System.Drawing.Point(620, 44);
            this.handanComboBox.Name = "handanComboBox";
            this.handanComboBox.Size = new System.Drawing.Size(80, 28);
            this.handanComboBox.TabIndex = 9;
            // 
            // torokuButton
            // 
            this.torokuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.torokuButton.Location = new System.Drawing.Point(613, 464);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 14;
            this.torokuButton.Text = "F1:設定";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // syokiboGappeiPictureBox
            // 
            this.syokiboGappeiPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.syokiboGappeiPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("syokiboGappeiPictureBox.Image")));
            this.syokiboGappeiPictureBox.Location = new System.Drawing.Point(12, 24);
            this.syokiboGappeiPictureBox.Name = "syokiboGappeiPictureBox";
            this.syokiboGappeiPictureBox.Size = new System.Drawing.Size(560, 332);
            this.syokiboGappeiPictureBox.TabIndex = 16;
            this.syokiboGappeiPictureBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "小規模合併";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "単独 (ばっ気型)";
            // 
            // syokiboGappeiPanel
            // 
            this.syokiboGappeiPanel.Controls.Add(this.label6);
            this.syokiboGappeiPanel.Controls.Add(this.syokiboGappeiPictureBox);
            this.syokiboGappeiPanel.Location = new System.Drawing.Point(680, 80);
            this.syokiboGappeiPanel.Name = "syokiboGappeiPanel";
            this.syokiboGappeiPanel.Size = new System.Drawing.Size(584, 368);
            this.syokiboGappeiPanel.TabIndex = 13;
            // 
            // bakkiGataPanel
            // 
            this.bakkiGataPanel.Controls.Add(this.label7);
            this.bakkiGataPanel.Controls.Add(this.bakkiGataPictureBox);
            this.bakkiGataPanel.Location = new System.Drawing.Point(92, 80);
            this.bakkiGataPanel.Name = "bakkiGataPanel";
            this.bakkiGataPanel.Size = new System.Drawing.Size(584, 368);
            this.bakkiGataPanel.TabIndex = 11;
            // 
            // bakkiGataPictureBox
            // 
            this.bakkiGataPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bakkiGataPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("bakkiGataPictureBox.Image")));
            this.bakkiGataPictureBox.Location = new System.Drawing.Point(12, 24);
            this.bakkiGataPictureBox.Name = "bakkiGataPictureBox";
            this.bakkiGataPictureBox.Size = new System.Drawing.Size(560, 332);
            this.bakkiGataPictureBox.TabIndex = 17;
            this.bakkiGataPictureBox.TabStop = false;
            // 
            // gappeiPanel
            // 
            this.gappeiPanel.Controls.Add(this.label9);
            this.gappeiPanel.Controls.Add(this.gappeiPictureBox);
            this.gappeiPanel.Location = new System.Drawing.Point(16, 300);
            this.gappeiPanel.Name = "gappeiPanel";
            this.gappeiPanel.Size = new System.Drawing.Size(584, 368);
            this.gappeiPanel.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "合併";
            // 
            // gappeiPictureBox
            // 
            this.gappeiPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gappeiPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("gappeiPictureBox.Image")));
            this.gappeiPictureBox.Location = new System.Drawing.Point(12, 24);
            this.gappeiPictureBox.Name = "gappeiPictureBox";
            this.gappeiPictureBox.Size = new System.Drawing.Size(560, 332);
            this.gappeiPictureBox.TabIndex = 16;
            this.gappeiPictureBox.TabStop = false;
            // 
            // SyokenManualInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 510);
            this.Controls.Add(this.bakkiGataPanel);
            this.Controls.Add(this.gappeiPanel);
            this.Controls.Add(this.syokiboGappeiPanel);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.handanComboBox);
            this.Controls.Add(this.shitekiKasyoNoComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.checkItemNoTextBox);
            this.Controls.Add(this.insertPositionTextBox);
            this.Controls.Add(this.syokenWdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(851, 547);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(851, 547);
            this.Name = "SyokenManualInputForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "所見手入力";
            this.Load += new System.EventHandler(this.SyokenManualInputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SyokenManualInputForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.syokiboGappeiPictureBox)).EndInit();
            this.syokiboGappeiPanel.ResumeLayout(false);
            this.syokiboGappeiPanel.PerformLayout();
            this.bakkiGataPanel.ResumeLayout(false);
            this.bakkiGataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bakkiGataPictureBox)).EndInit();
            this.gappeiPanel.ResumeLayout(false);
            this.gappeiPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gappeiPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.ZTextBox syokenWdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Control.ZTextBox insertPositionTextBox;
        private System.Windows.Forms.Label label3;
        private Control.ZTextBox checkItemNoTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ComboBox shitekiKasyoNoComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox handanComboBox;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.PictureBox syokiboGappeiPictureBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel syokiboGappeiPanel;
        private System.Windows.Forms.Panel bakkiGataPanel;
        private System.Windows.Forms.Panel gappeiPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox gappeiPictureBox;
        private System.Windows.Forms.PictureBox bakkiGataPictureBox;
    }
}