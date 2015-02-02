namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    partial class UserSettingMenuForm
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
            this.printerSettingButton = new System.Windows.Forms.Button();
            this.tuckSealPrintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printerSettingButton
            // 
            this.printerSettingButton.Location = new System.Drawing.Point(180, 21);
            this.printerSettingButton.Margin = new System.Windows.Forms.Padding(12);
            this.printerSettingButton.Name = "printerSettingButton";
            this.printerSettingButton.Size = new System.Drawing.Size(135, 55);
            this.printerSettingButton.TabIndex = 1;
            this.printerSettingButton.Text = "プリンタ設定";
            this.printerSettingButton.UseVisualStyleBackColor = true;
            this.printerSettingButton.Click += new System.EventHandler(this.printerSettingButton_Click);
            // 
            // tuckSealPrintButton
            // 
            this.tuckSealPrintButton.Location = new System.Drawing.Point(21, 21);
            this.tuckSealPrintButton.Margin = new System.Windows.Forms.Padding(12);
            this.tuckSealPrintButton.Name = "tuckSealPrintButton";
            this.tuckSealPrintButton.Size = new System.Drawing.Size(135, 55);
            this.tuckSealPrintButton.TabIndex = 0;
            this.tuckSealPrintButton.Text = "タックシール印刷";
            this.tuckSealPrintButton.UseVisualStyleBackColor = true;
            this.tuckSealPrintButton.Click += new System.EventHandler(this.tuckSealPrintButton_Click);
            // 
            // UserSettingMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.tuckSealPrintButton);
            this.Controls.Add(this.printerSettingButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserSettingMenuForm";
            this.Text = "ユーザー設定";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printerSettingButton;
        private System.Windows.Forms.Button tuckSealPrintButton;

    }
}