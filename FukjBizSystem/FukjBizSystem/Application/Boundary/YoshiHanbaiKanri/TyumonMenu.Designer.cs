namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class TyumonMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TyumonMenu));
            this.tojiru = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TyumonInput = new System.Windows.Forms.Button();
            this.TyumonList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tojiru
            // 
            this.tojiru.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tojiru.Location = new System.Drawing.Point(12, 77);
            this.tojiru.Name = "tojiru";
            this.tojiru.Size = new System.Drawing.Size(119, 56);
            this.tojiru.TabIndex = 1;
            this.tojiru.Text = "閉じる";
            this.tojiru.UseVisualStyleBackColor = true;
            this.tojiru.Click += new System.EventHandler(this.tojiru_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 70);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(-2, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 72);
            this.label1.TabIndex = 3;
            this.label1.Text = "用紙販売管理 - 注文管理";
            // 
            // TyumonInput
            // 
            this.TyumonInput.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TyumonInput.Location = new System.Drawing.Point(180, 248);
            this.TyumonInput.Name = "TyumonInput";
            this.TyumonInput.Size = new System.Drawing.Size(352, 225);
            this.TyumonInput.TabIndex = 3;
            this.TyumonInput.Text = "注文入力";
            this.TyumonInput.UseVisualStyleBackColor = true;
            this.TyumonInput.Click += new System.EventHandler(this.TyumonInput_Click);
            // 
            // TyumonList
            // 
            this.TyumonList.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TyumonList.Location = new System.Drawing.Point(674, 248);
            this.TyumonList.Name = "TyumonList";
            this.TyumonList.Size = new System.Drawing.Size(352, 225);
            this.TyumonList.TabIndex = 4;
            this.TyumonList.Text = "注文一覧";
            this.TyumonList.UseVisualStyleBackColor = true;
            this.TyumonList.Click += new System.EventHandler(this.TyumonList_Click);
            // 
            // TyumonMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.TyumonList);
            this.Controls.Add(this.TyumonInput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tojiru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TyumonMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注文";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tojiru;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TyumonInput;
        private System.Windows.Forms.Button TyumonList;
    }
}