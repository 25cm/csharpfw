namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class YoshiMenuForm
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
            this.ZaikoListButton = new System.Windows.Forms.Button();
            this.ShiireInput = new System.Windows.Forms.Button();
            this.Tyumon = new System.Windows.Forms.Button();
            this.Uriage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ZaikoListButton
            // 
            this.ZaikoListButton.Location = new System.Drawing.Point(12, 12);
            this.ZaikoListButton.Name = "ZaikoListButton";
            this.ZaikoListButton.Size = new System.Drawing.Size(135, 55);
            this.ZaikoListButton.TabIndex = 1;
            this.ZaikoListButton.Text = "在庫一覧";
            this.ZaikoListButton.UseVisualStyleBackColor = true;
            this.ZaikoListButton.Click += new System.EventHandler(this.ZaikoListButton_Click);
            // 
            // ShiireInput
            // 
            this.ShiireInput.Location = new System.Drawing.Point(12, 83);
            this.ShiireInput.Name = "ShiireInput";
            this.ShiireInput.Size = new System.Drawing.Size(135, 55);
            this.ShiireInput.TabIndex = 2;
            this.ShiireInput.Text = "仕入入力";
            this.ShiireInput.UseVisualStyleBackColor = true;
            this.ShiireInput.Click += new System.EventHandler(this.ShiireInput_Click);
            // 
            // Tyumon
            // 
            this.Tyumon.Location = new System.Drawing.Point(12, 155);
            this.Tyumon.Name = "Tyumon";
            this.Tyumon.Size = new System.Drawing.Size(135, 55);
            this.Tyumon.TabIndex = 3;
            this.Tyumon.Text = "注文関連";
            this.Tyumon.UseVisualStyleBackColor = true;
            this.Tyumon.Click += new System.EventHandler(this.Tyumon_Click);
            // 
            // Uriage
            // 
            this.Uriage.Location = new System.Drawing.Point(12, 229);
            this.Uriage.Name = "Uriage";
            this.Uriage.Size = new System.Drawing.Size(135, 55);
            this.Uriage.TabIndex = 4;
            this.Uriage.Text = "用紙売上実績一覧";
            this.Uriage.UseVisualStyleBackColor = true;
            this.Uriage.Click += new System.EventHandler(this.Uriage_Click);
            // 
            // YoshiMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.Uriage);
            this.Controls.Add(this.Tyumon);
            this.Controls.Add(this.ShiireInput);
            this.Controls.Add(this.ZaikoListButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YoshiMenuForm";
            this.Text = "機能選択";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ZaikoListButton;
        private System.Windows.Forms.Button ShiireInput;
        private System.Windows.Forms.Button Tyumon;
        private System.Windows.Forms.Button Uriage;
    }
}