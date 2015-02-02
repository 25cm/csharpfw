namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    partial class RyosyuPrintForm
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
            this.printButton = new System.Windows.Forms.Button();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.atenaTextBox = new System.Windows.Forms.TextBox();
            this.outputDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.printButton.Location = new System.Drawing.Point(254, 163);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(166, 94);
            this.printButton.TabIndex = 4;
            this.printButton.Text = "印刷";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // tojiruButton
            // 
            this.tojiruButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tojiruButton.Location = new System.Drawing.Point(438, 163);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(166, 94);
            this.tojiruButton.TabIndex = 5;
            this.tojiruButton.Text = "閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "領収書宛先";
            // 
            // atenaTextBox
            // 
            this.atenaTextBox.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.atenaTextBox.Location = new System.Drawing.Point(133, 24);
            this.atenaTextBox.Name = "atenaTextBox";
            this.atenaTextBox.Size = new System.Drawing.Size(471, 39);
            this.atenaTextBox.TabIndex = 1;
            // 
            // outputDtDateTimePicker
            // 
            this.outputDtDateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.outputDtDateTimePicker.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.outputDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.outputDtDateTimePicker.Location = new System.Drawing.Point(133, 72);
            this.outputDtDateTimePicker.Name = "outputDtDateTimePicker";
            this.outputDtDateTimePicker.Size = new System.Drawing.Size(212, 39);
            this.outputDtDateTimePicker.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(12, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 31);
            this.label7.TabIndex = 19;
            this.label7.Text = "発行日";
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.clearButton.Location = new System.Drawing.Point(492, 72);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(112, 54);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // RyosyuPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 297);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.outputDtDateTimePicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.atenaTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.printButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RyosyuPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "領収書印刷";
            this.Load += new System.EventHandler(this.RyosyuPrintForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox atenaTextBox;
        private Zynas.Control.ZDate outputDtDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button clearButton;

    }
}