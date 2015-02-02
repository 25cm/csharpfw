namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class KensainBetsuKensaYoteiPrintForm
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
            this.printButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.kensainComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kensaYoteiDtInputDataTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // printButton
            // 
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printButton.Location = new System.Drawing.Point(180, 128);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(101, 37);
            this.printButton.TabIndex = 4;
            this.printButton.Text = "F1:印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.kensainComboBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.kensaYoteiDtInputDataTimePicker);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.printButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(414, 177);
            this.mainPanel.TabIndex = 0;
            // 
            // kensainComboBox
            // 
            this.kensainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensainComboBox.FormattingEnabled = true;
            this.kensainComboBox.Location = new System.Drawing.Point(112, 36);
            this.kensainComboBox.Name = "kensainComboBox";
            this.kensainComboBox.Size = new System.Drawing.Size(143, 28);
            this.kensainComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検査員";
            // 
            // kensaYoteiDtInputDataTimePicker
            // 
            this.kensaYoteiDtInputDataTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kensaYoteiDtInputDataTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kensaYoteiDtInputDataTimePicker.Location = new System.Drawing.Point(112, 70);
            this.kensaYoteiDtInputDataTimePicker.Name = "kensaYoteiDtInputDataTimePicker";
            this.kensaYoteiDtInputDataTimePicker.Size = new System.Drawing.Size(143, 27);
            this.kensaYoteiDtInputDataTimePicker.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "検査予定日";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(301, 128);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // KensainBetsuKensaYoteiPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 177);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KensainBetsuKensaYoteiPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "検査員別検査予定出力";
            this.Load += new System.EventHandler(this.KensainBetsuKensaYoteiPrintForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensainBetsuKensaYoteiPrintForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker kensaYoteiDtInputDataTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox kensainComboBox;
    }
}