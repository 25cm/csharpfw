namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    partial class SofuDtInputForm
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
            this.torokuButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sofuDtInputDataTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // torokuButton
            // 
            this.torokuButton.Location = new System.Drawing.Point(142, 91);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 2;
            this.torokuButton.Text = "F1:登録";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.sofuDtInputDataTimePicker);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.torokuButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(376, 140);
            this.mainPanel.TabIndex = 0;
            // 
            // sofuDtInputDataTimePicker
            // 
            this.sofuDtInputDataTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.sofuDtInputDataTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sofuDtInputDataTimePicker.Location = new System.Drawing.Point(100, 34);
            this.sofuDtInputDataTimePicker.Name = "sofuDtInputDataTimePicker";
            this.sofuDtInputDataTimePicker.Size = new System.Drawing.Size(143, 27);
            this.sofuDtInputDataTimePicker.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "送付日";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(263, 91);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SofuDtInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 141);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SofuDtInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "送付日入力";
            this.Load += new System.EventHandler(this.SofuDtInputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SofuDtInputForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker sofuDtInputDataTimePicker;
    }
}