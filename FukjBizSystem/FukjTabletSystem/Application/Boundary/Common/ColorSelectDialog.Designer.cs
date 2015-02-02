namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class ColorSelectDialog
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
            this.components = new System.ComponentModel.Container();
            this.ok_BlackButton = new Zynas.Control.ZButton(this.components);
            this.ok_BlueButton = new Zynas.Control.ZButton(this.components);
            this.ok_RedButton = new Zynas.Control.ZButton(this.components);
            this.stampSButton = new Zynas.Control.ZButton(this.components);
            this.stampBButton = new Zynas.Control.ZButton(this.components);
            this.SuspendLayout();
            // 
            // ok_BlackButton
            // 
            this.ok_BlackButton.BackColor = System.Drawing.Color.Black;
            this.ok_BlackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_BlackButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ok_BlackButton.ForeColor = System.Drawing.Color.White;
            this.ok_BlackButton.Location = new System.Drawing.Point(3, 3);
            this.ok_BlackButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ok_BlackButton.Name = "ok_BlackButton";
            this.ok_BlackButton.Size = new System.Drawing.Size(100, 100);
            this.ok_BlackButton.TabIndex = 1;
            this.ok_BlackButton.TabStop = false;
            this.ok_BlackButton.Text = "黒";
            this.ok_BlackButton.UseVisualStyleBackColor = false;
            this.ok_BlackButton.Click += new System.EventHandler(this.ok_BlackButton_Click);
            // 
            // ok_BlueButton
            // 
            this.ok_BlueButton.BackColor = System.Drawing.Color.Blue;
            this.ok_BlueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_BlueButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold);
            this.ok_BlueButton.ForeColor = System.Drawing.Color.White;
            this.ok_BlueButton.Location = new System.Drawing.Point(106, 3);
            this.ok_BlueButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ok_BlueButton.Name = "ok_BlueButton";
            this.ok_BlueButton.Size = new System.Drawing.Size(100, 100);
            this.ok_BlueButton.TabIndex = 2;
            this.ok_BlueButton.TabStop = false;
            this.ok_BlueButton.Text = "青";
            this.ok_BlueButton.UseVisualStyleBackColor = false;
            this.ok_BlueButton.Click += new System.EventHandler(this.ok_BlueButton_Click);
            // 
            // ok_RedButton
            // 
            this.ok_RedButton.BackColor = System.Drawing.Color.Red;
            this.ok_RedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_RedButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold);
            this.ok_RedButton.ForeColor = System.Drawing.Color.White;
            this.ok_RedButton.Location = new System.Drawing.Point(209, 3);
            this.ok_RedButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ok_RedButton.Name = "ok_RedButton";
            this.ok_RedButton.Size = new System.Drawing.Size(100, 100);
            this.ok_RedButton.TabIndex = 3;
            this.ok_RedButton.TabStop = false;
            this.ok_RedButton.Text = "赤";
            this.ok_RedButton.UseVisualStyleBackColor = false;
            this.ok_RedButton.Click += new System.EventHandler(this.ok_RedButton_Click);
            // 
            // stampSButton
            // 
            this.stampSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stampSButton.ForeColor = System.Drawing.Color.White;
            this.stampSButton.Image = global::FukjTabletSystem.Properties.Resources.btn_stamp_s;
            this.stampSButton.Location = new System.Drawing.Point(415, 3);
            this.stampSButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stampSButton.Name = "stampSButton";
            this.stampSButton.Size = new System.Drawing.Size(100, 100);
            this.stampSButton.TabIndex = 5;
            this.stampSButton.TabStop = false;
            this.stampSButton.UseVisualStyleBackColor = false;
            this.stampSButton.Click += new System.EventHandler(this.stampSButton_Click);
            // 
            // stampBButton
            // 
            this.stampBButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stampBButton.ForeColor = System.Drawing.Color.White;
            this.stampBButton.Image = global::FukjTabletSystem.Properties.Resources.btn_stamp_b;
            this.stampBButton.Location = new System.Drawing.Point(312, 3);
            this.stampBButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stampBButton.Name = "stampBButton";
            this.stampBButton.Size = new System.Drawing.Size(100, 100);
            this.stampBButton.TabIndex = 4;
            this.stampBButton.TabStop = false;
            this.stampBButton.UseVisualStyleBackColor = false;
            this.stampBButton.Click += new System.EventHandler(this.stampBButton_Click);
            // 
            // ColorSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 106);
            this.ControlBox = false;
            this.Controls.Add(this.stampSButton);
            this.Controls.Add(this.stampBButton);
            this.Controls.Add(this.ok_RedButton);
            this.Controls.Add(this.ok_BlueButton);
            this.Controls.Add(this.ok_BlackButton);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ColorSelectDialog";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TextInputForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton ok_BlackButton;
        private Zynas.Control.ZButton ok_BlueButton;
        private Zynas.Control.ZButton ok_RedButton;
        private Zynas.Control.ZButton stampBButton;
        private Zynas.Control.ZButton stampSButton;
    }
}