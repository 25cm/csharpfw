namespace FukjBizSystem.Application.Boundary.Test
{
    partial class TestForm1
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
            this.textBox1 = new FukjBizSystem.Control.ZTextBox(this.components);
            this.zTextBox1 = new FukjBizSystem.Control.ZTextBox(this.components);
            this.zTextBox2 = new FukjBizSystem.Control.ZTextBox(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDropDown = false;
            this.textBox1.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.textBox1.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.textBox1.CustomReadOnly = false;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 19);
            this.textBox1.TabIndex = 10;
            // 
            // zTextBox1
            // 
            this.zTextBox1.AllowDropDown = false;
            this.zTextBox1.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.zTextBox1.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.zTextBox1.CustomReadOnly = false;
            this.zTextBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.zTextBox1.Location = new System.Drawing.Point(12, 37);
            this.zTextBox1.MaxLength = 4;
            this.zTextBox1.Name = "zTextBox1";
            this.zTextBox1.Size = new System.Drawing.Size(88, 19);
            this.zTextBox1.TabIndex = 11;
            // 
            // zTextBox2
            // 
            this.zTextBox2.AllowDropDown = false;
            this.zTextBox2.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.zTextBox2.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.zTextBox2.CustomReadOnly = false;
            this.zTextBox2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.zTextBox2.Location = new System.Drawing.Point(12, 62);
            this.zTextBox2.MaxLength = 4;
            this.zTextBox2.Name = "zTextBox2";
            this.zTextBox2.Size = new System.Drawing.Size(88, 19);
            this.zTextBox2.TabIndex = 12;
            // 
            // TestForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.zTextBox2);
            this.Controls.Add(this.zTextBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "TestForm1";
            this.Text = "TestForm1";
            this.Load += new System.EventHandler(this.TestForm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.ZTextBox textBox1;
        private Control.ZTextBox zTextBox1;
        private Control.ZTextBox zTextBox2;
    }
}