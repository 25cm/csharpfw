namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    partial class SaisuiinMenuForm
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
            this.jukouYoteishaListButton = new System.Windows.Forms.Button();
            this.jukoushaNyuryokuButton = new System.Windows.Forms.Button();
            this.saisuiinShomeiOutputButton = new System.Windows.Forms.Button();
            this.saisuiinInfoListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jukouYoteishaListButton
            // 
            this.jukouYoteishaListButton.Location = new System.Drawing.Point(21, 21);
            this.jukouYoteishaListButton.Margin = new System.Windows.Forms.Padding(12);
            this.jukouYoteishaListButton.Name = "jukouYoteishaListButton";
            this.jukouYoteishaListButton.Size = new System.Drawing.Size(135, 55);
            this.jukouYoteishaListButton.TabIndex = 0;
            this.jukouYoteishaListButton.Text = "受講予定者一覧";
            this.jukouYoteishaListButton.UseVisualStyleBackColor = true;
            this.jukouYoteishaListButton.Click += new System.EventHandler(this.jukouYoteishaListButton_Click);
            // 
            // jukoushaNyuryokuButton
            // 
            this.jukoushaNyuryokuButton.Location = new System.Drawing.Point(180, 21);
            this.jukoushaNyuryokuButton.Margin = new System.Windows.Forms.Padding(12);
            this.jukoushaNyuryokuButton.Name = "jukoushaNyuryokuButton";
            this.jukoushaNyuryokuButton.Size = new System.Drawing.Size(135, 55);
            this.jukoushaNyuryokuButton.TabIndex = 1;
            this.jukoushaNyuryokuButton.Text = "受講者入力";
            this.jukoushaNyuryokuButton.UseVisualStyleBackColor = true;
            this.jukoushaNyuryokuButton.Click += new System.EventHandler(this.jukoushaNyuryokuButton_Click);
            // 
            // saisuiinShomeiOutputButton
            // 
            this.saisuiinShomeiOutputButton.Location = new System.Drawing.Point(339, 21);
            this.saisuiinShomeiOutputButton.Margin = new System.Windows.Forms.Padding(12);
            this.saisuiinShomeiOutputButton.Name = "saisuiinShomeiOutputButton";
            this.saisuiinShomeiOutputButton.Size = new System.Drawing.Size(135, 55);
            this.saisuiinShomeiOutputButton.TabIndex = 2;
            this.saisuiinShomeiOutputButton.Text = "採水員証明書発行";
            this.saisuiinShomeiOutputButton.UseVisualStyleBackColor = true;
            this.saisuiinShomeiOutputButton.Click += new System.EventHandler(this.saisuiinShomeiOutputButton_Click);
            // 
            // saisuiinInfoListButton
            // 
            this.saisuiinInfoListButton.Location = new System.Drawing.Point(498, 21);
            this.saisuiinInfoListButton.Margin = new System.Windows.Forms.Padding(12);
            this.saisuiinInfoListButton.Name = "saisuiinInfoListButton";
            this.saisuiinInfoListButton.Size = new System.Drawing.Size(135, 55);
            this.saisuiinInfoListButton.TabIndex = 3;
            this.saisuiinInfoListButton.Text = "採水員情報一覧";
            this.saisuiinInfoListButton.UseVisualStyleBackColor = true;
            this.saisuiinInfoListButton.Click += new System.EventHandler(this.saisuiinInfoListButton_Click);
            // 
            // SaisuiinMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.jukouYoteishaListButton);
            this.Controls.Add(this.jukoushaNyuryokuButton);
            this.Controls.Add(this.saisuiinShomeiOutputButton);
            this.Controls.Add(this.saisuiinInfoListButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SaisuiinMenuForm";
            this.Text = "採水員管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button jukouYoteishaListButton;
        private System.Windows.Forms.Button jukoushaNyuryokuButton;
        private System.Windows.Forms.Button saisuiinShomeiOutputButton;
        private System.Windows.Forms.Button saisuiinInfoListButton;

    }
}