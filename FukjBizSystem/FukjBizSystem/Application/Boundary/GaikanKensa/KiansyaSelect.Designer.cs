namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class KiansyaSelectForm
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
            this.label15 = new System.Windows.Forms.Label();
            this.kianshaComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.syozokuBusyoComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.syozokuShisyoComboBox = new System.Windows.Forms.ComboBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(260, 174);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(101, 37);
            this.printButton.TabIndex = 9;
            this.printButton.Text = "F1:印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.kianshaComboBox);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.syozokuBusyoComboBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.syozokuShisyoComboBox);
            this.mainPanel.Controls.Add(this.printButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(515, 226);
            this.mainPanel.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 20);
            this.label15.TabIndex = 197;
            this.label15.Text = "起案者";
            // 
            // kianshaComboBox
            // 
            this.kianshaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kianshaComboBox.FormattingEnabled = true;
            this.kianshaComboBox.Items.AddRange(new object[] {
            "検査員太郎",
            "検査員次郎"});
            this.kianshaComboBox.Location = new System.Drawing.Point(136, 99);
            this.kianshaComboBox.Name = "kianshaComboBox";
            this.kianshaComboBox.Size = new System.Drawing.Size(191, 28);
            this.kianshaComboBox.TabIndex = 196;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 195;
            this.label5.Text = "所属部署";
            // 
            // syozokuBusyoComboBox
            // 
            this.syozokuBusyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syozokuBusyoComboBox.FormattingEnabled = true;
            this.syozokuBusyoComboBox.Items.AddRange(new object[] {
            "法定検査課"});
            this.syozokuBusyoComboBox.Location = new System.Drawing.Point(136, 65);
            this.syozokuBusyoComboBox.Name = "syozokuBusyoComboBox";
            this.syozokuBusyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.syozokuBusyoComboBox.TabIndex = 194;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 193;
            this.label13.Text = "所属支所";
            // 
            // syozokuShisyoComboBox
            // 
            this.syozokuShisyoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syozokuShisyoComboBox.FormattingEnabled = true;
            this.syozokuShisyoComboBox.Items.AddRange(new object[] {
            "筑　豊",
            "筑　後",
            "福　岡"});
            this.syozokuShisyoComboBox.Location = new System.Drawing.Point(136, 31);
            this.syozokuShisyoComboBox.Name = "syozokuShisyoComboBox";
            this.syozokuShisyoComboBox.Size = new System.Drawing.Size(191, 28);
            this.syozokuShisyoComboBox.TabIndex = 192;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(381, 174);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // KiansyaSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 232);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KiansyaSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "起案者";
            this.Load += new System.EventHandler(this.KiansyaSelectForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KiansyaSelectForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox kianshaComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox syozokuBusyoComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox syozokuShisyoComboBox;
    }
}