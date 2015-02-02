namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    partial class DaichoMenuForm
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
            this.jokasoDaichoListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jokasoDaichoListButton
            // 
            this.jokasoDaichoListButton.Location = new System.Drawing.Point(21, 21);
            this.jokasoDaichoListButton.Margin = new System.Windows.Forms.Padding(12);
            this.jokasoDaichoListButton.Name = "jokasoDaichoListButton";
            this.jokasoDaichoListButton.Size = new System.Drawing.Size(135, 55);
            this.jokasoDaichoListButton.TabIndex = 0;
            this.jokasoDaichoListButton.Text = "浄化槽台帳一覧";
            this.jokasoDaichoListButton.UseVisualStyleBackColor = true;
            this.jokasoDaichoListButton.Click += new System.EventHandler(this.jokasoDaichoListButton_Click);
            // 
            // DaichoMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.jokasoDaichoListButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DaichoMenuForm";
            this.Text = "台帳管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button jokasoDaichoListButton;


    }
}