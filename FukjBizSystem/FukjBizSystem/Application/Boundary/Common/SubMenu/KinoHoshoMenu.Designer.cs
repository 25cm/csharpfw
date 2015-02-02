namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    partial class KinoHoshoMenuForm
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
            this.hoshouNoPrintButton = new System.Windows.Forms.Button();
            this.hoshouShinseiNyuryokuButton = new System.Windows.Forms.Button();
            this.hoshouShinseiKoukanButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hoshouNoPrintButton
            // 
            this.hoshouNoPrintButton.Location = new System.Drawing.Point(21, 21);
            this.hoshouNoPrintButton.Margin = new System.Windows.Forms.Padding(12);
            this.hoshouNoPrintButton.Name = "hoshouNoPrintButton";
            this.hoshouNoPrintButton.Size = new System.Drawing.Size(135, 55);
            this.hoshouNoPrintButton.TabIndex = 0;
            this.hoshouNoPrintButton.Text = "保証番号印刷";
            this.hoshouNoPrintButton.UseVisualStyleBackColor = true;
            this.hoshouNoPrintButton.Click += new System.EventHandler(this.hoshouNoPrintButton_Click);
            // 
            // hoshouShinseiNyuryokuButton
            // 
            this.hoshouShinseiNyuryokuButton.Location = new System.Drawing.Point(180, 21);
            this.hoshouShinseiNyuryokuButton.Margin = new System.Windows.Forms.Padding(12);
            this.hoshouShinseiNyuryokuButton.Name = "hoshouShinseiNyuryokuButton";
            this.hoshouShinseiNyuryokuButton.Size = new System.Drawing.Size(135, 55);
            this.hoshouShinseiNyuryokuButton.TabIndex = 1;
            this.hoshouShinseiNyuryokuButton.Text = "保証申請入力";
            this.hoshouShinseiNyuryokuButton.UseVisualStyleBackColor = true;
            this.hoshouShinseiNyuryokuButton.Click += new System.EventHandler(this.hoshouShinseiNyuryokuButton_Click);
            // 
            // hoshouShinseiKoukanButton
            // 
            this.hoshouShinseiKoukanButton.Location = new System.Drawing.Point(339, 21);
            this.hoshouShinseiKoukanButton.Margin = new System.Windows.Forms.Padding(12);
            this.hoshouShinseiKoukanButton.Name = "hoshouShinseiKoukanButton";
            this.hoshouShinseiKoukanButton.Size = new System.Drawing.Size(135, 55);
            this.hoshouShinseiKoukanButton.TabIndex = 2;
            this.hoshouShinseiKoukanButton.Text = "保証申請書交換";
            this.hoshouShinseiKoukanButton.UseVisualStyleBackColor = true;
            this.hoshouShinseiKoukanButton.Click += new System.EventHandler(this.hoshouShinseiKoukanButton_Click);
            // 
            // KinoHoshoMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.hoshouNoPrintButton);
            this.Controls.Add(this.hoshouShinseiKoukanButton);
            this.Controls.Add(this.hoshouShinseiNyuryokuButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KinoHoshoMenuForm";
            this.Text = "機能保証管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hoshouNoPrintButton;
        private System.Windows.Forms.Button hoshouShinseiNyuryokuButton;
        private System.Windows.Forms.Button hoshouShinseiKoukanButton;

    }
}