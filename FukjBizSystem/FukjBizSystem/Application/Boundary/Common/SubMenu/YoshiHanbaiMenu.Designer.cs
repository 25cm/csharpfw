namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    partial class YoshiHanbaiMenuForm
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
            this.zaikoListButton = new System.Windows.Forms.Button();
            this.shiireNyuryokuButton = new System.Windows.Forms.Button();
            this.chumonButton = new System.Windows.Forms.Button();
            this.yoshiUriageJissekiButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zaikoListButton
            // 
            this.zaikoListButton.Location = new System.Drawing.Point(21, 21);
            this.zaikoListButton.Margin = new System.Windows.Forms.Padding(12);
            this.zaikoListButton.Name = "zaikoListButton";
            this.zaikoListButton.Size = new System.Drawing.Size(135, 55);
            this.zaikoListButton.TabIndex = 0;
            this.zaikoListButton.Text = "在庫一覧";
            this.zaikoListButton.UseVisualStyleBackColor = true;
            this.zaikoListButton.Click += new System.EventHandler(this.zaikoListButton_Click);
            // 
            // shiireNyuryokuButton
            // 
            this.shiireNyuryokuButton.Location = new System.Drawing.Point(180, 21);
            this.shiireNyuryokuButton.Margin = new System.Windows.Forms.Padding(12);
            this.shiireNyuryokuButton.Name = "shiireNyuryokuButton";
            this.shiireNyuryokuButton.Size = new System.Drawing.Size(135, 55);
            this.shiireNyuryokuButton.TabIndex = 1;
            this.shiireNyuryokuButton.Text = "仕入入力";
            this.shiireNyuryokuButton.UseVisualStyleBackColor = true;
            this.shiireNyuryokuButton.Click += new System.EventHandler(this.shiireNyuryokuButton_Click);
            // 
            // chumonButton
            // 
            this.chumonButton.Location = new System.Drawing.Point(339, 21);
            this.chumonButton.Margin = new System.Windows.Forms.Padding(12);
            this.chumonButton.Name = "chumonButton";
            this.chumonButton.Size = new System.Drawing.Size(135, 55);
            this.chumonButton.TabIndex = 2;
            this.chumonButton.Text = "注文関連";
            this.chumonButton.UseVisualStyleBackColor = true;
            this.chumonButton.Click += new System.EventHandler(this.chumonButton_Click);
            // 
            // yoshiUriageJissekiButton
            // 
            this.yoshiUriageJissekiButton.Location = new System.Drawing.Point(498, 21);
            this.yoshiUriageJissekiButton.Margin = new System.Windows.Forms.Padding(12);
            this.yoshiUriageJissekiButton.Name = "yoshiUriageJissekiButton";
            this.yoshiUriageJissekiButton.Size = new System.Drawing.Size(135, 55);
            this.yoshiUriageJissekiButton.TabIndex = 3;
            this.yoshiUriageJissekiButton.Text = "用紙売上実績一覧";
            this.yoshiUriageJissekiButton.UseVisualStyleBackColor = true;
            this.yoshiUriageJissekiButton.Click += new System.EventHandler(this.yoshiUriageJissekiButton_Click);
            // 
            // YoshiHanbaiMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.zaikoListButton);
            this.Controls.Add(this.yoshiUriageJissekiButton);
            this.Controls.Add(this.shiireNyuryokuButton);
            this.Controls.Add(this.chumonButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YoshiHanbaiMenuForm";
            this.Text = "用紙販売管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zaikoListButton;
        private System.Windows.Forms.Button shiireNyuryokuButton;
        private System.Windows.Forms.Button chumonButton;
        private System.Windows.Forms.Button yoshiUriageJissekiButton;

    }
}