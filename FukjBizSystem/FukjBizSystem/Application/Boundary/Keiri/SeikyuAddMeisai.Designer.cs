using FukjBizSystem.Control;
namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class SeikyuAddMeisaiForm
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
            this.kakuteiButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.meisaiNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.sotozeiRadioButton = new System.Windows.Forms.RadioButton();
            this.uchizeiRadioButton = new System.Windows.Forms.RadioButton();
            this.taisyogaiRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.kingakuTextBox = new ZTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Location = new System.Drawing.Point(252, 141);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(101, 37);
            this.kakuteiButton.TabIndex = 8;
            this.kakuteiButton.Text = "F1:明細追加";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.meisaiNmTextBox);
            this.mainPanel.Controls.Add(this.sotozeiRadioButton);
            this.mainPanel.Controls.Add(this.uchizeiRadioButton);
            this.mainPanel.Controls.Add(this.taisyogaiRadioButton);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.kingakuTextBox);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.kakuteiButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(515, 226);
            this.mainPanel.TabIndex = 0;
            // 
            // meisaiNmTextBox
            // 
            this.meisaiNmTextBox.AllowDropDown = false;
            this.meisaiNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.meisaiNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.meisaiNmTextBox.CustomReadOnly = false;
            this.meisaiNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.meisaiNmTextBox.Location = new System.Drawing.Point(97, 24);
            this.meisaiNmTextBox.MaxLength = 40;
            this.meisaiNmTextBox.Name = "meisaiNmTextBox";
            this.meisaiNmTextBox.Size = new System.Drawing.Size(312, 27);
            this.meisaiNmTextBox.TabIndex = 1;
            // 
            // sotozeiRadioButton
            // 
            this.sotozeiRadioButton.AutoSize = true;
            this.sotozeiRadioButton.Location = new System.Drawing.Point(169, 98);
            this.sotozeiRadioButton.Name = "sotozeiRadioButton";
            this.sotozeiRadioButton.Size = new System.Drawing.Size(117, 24);
            this.sotozeiRadioButton.TabIndex = 6;
            this.sotozeiRadioButton.Text = "税抜金額(外税)";
            this.sotozeiRadioButton.UseVisualStyleBackColor = true;
            // 
            // uchizeiRadioButton
            // 
            this.uchizeiRadioButton.AutoSize = true;
            this.uchizeiRadioButton.Location = new System.Drawing.Point(292, 98);
            this.uchizeiRadioButton.Name = "uchizeiRadioButton";
            this.uchizeiRadioButton.Size = new System.Drawing.Size(117, 24);
            this.uchizeiRadioButton.TabIndex = 7;
            this.uchizeiRadioButton.Text = "税込金額(内税)";
            this.uchizeiRadioButton.UseVisualStyleBackColor = true;
            // 
            // taisyogaiRadioButton
            // 
            this.taisyogaiRadioButton.AutoSize = true;
            this.taisyogaiRadioButton.Checked = true;
            this.taisyogaiRadioButton.Location = new System.Drawing.Point(97, 98);
            this.taisyogaiRadioButton.Name = "taisyogaiRadioButton";
            this.taisyogaiRadioButton.Size = new System.Drawing.Size(66, 24);
            this.taisyogaiRadioButton.TabIndex = 5;
            this.taisyogaiRadioButton.TabStop = true;
            this.taisyogaiRadioButton.Text = "対象外";
            this.taisyogaiRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "消費税";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "金額";
            // 
            // kingakuTextBox
            // 
            this.kingakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.kingakuTextBox.CustomReadOnly = false;
            this.kingakuTextBox.Location = new System.Drawing.Point(97, 57);
            this.kingakuTextBox.MaxLength = 6;
            this.kingakuTextBox.Name = "kingakuTextBox";
            this.kingakuTextBox.Size = new System.Drawing.Size(109, 27);
            this.kingakuTextBox.TabIndex = 3;
            this.kingakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "明細名目";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(373, 141);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SeikyuAddMeisaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 232);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeikyuAddMeisaiForm";
            this.Text = "請求明細追加";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeikyuAddMeisaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kakuteiButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton sotozeiRadioButton;
        private System.Windows.Forms.RadioButton uchizeiRadioButton;
        private System.Windows.Forms.RadioButton taisyogaiRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private ZTextBox kingakuTextBox;
        private Control.ZTextBox meisaiNmTextBox;
    }
}