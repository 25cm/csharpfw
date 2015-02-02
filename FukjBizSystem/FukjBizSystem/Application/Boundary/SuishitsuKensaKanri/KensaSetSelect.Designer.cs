namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    partial class KensaSetSelectForm
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
            this.choiceButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.kensaKomokuNaiyoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.kensaKomokuPatternComboBox = new System.Windows.Forms.ComboBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // choiceButton
            // 
            this.choiceButton.Location = new System.Drawing.Point(260, 174);
            this.choiceButton.Name = "choiceButton";
            this.choiceButton.Size = new System.Drawing.Size(101, 37);
            this.choiceButton.TabIndex = 3;
            this.choiceButton.Text = "F1:選択";
            this.choiceButton.UseVisualStyleBackColor = true;
            this.choiceButton.Click += new System.EventHandler(this.choiceButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.kensaKomokuNaiyoTextBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.kensaKomokuPatternComboBox);
            this.mainPanel.Controls.Add(this.choiceButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(515, 226);
            this.mainPanel.TabIndex = 0;
            // 
            // kensaKomokuNaiyoTextBox
            // 
            this.kensaKomokuNaiyoTextBox.AllowDropDown = false;
            this.kensaKomokuNaiyoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaKomokuNaiyoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaKomokuNaiyoTextBox.CustomReadOnly = false;
            this.kensaKomokuNaiyoTextBox.Location = new System.Drawing.Point(23, 56);
            this.kensaKomokuNaiyoTextBox.Multiline = true;
            this.kensaKomokuNaiyoTextBox.Name = "kensaKomokuNaiyoTextBox";
            this.kensaKomokuNaiyoTextBox.ReadOnly = true;
            this.kensaKomokuNaiyoTextBox.Size = new System.Drawing.Size(468, 113);
            this.kensaKomokuNaiyoTextBox.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "検査項目パターン";
            // 
            // kensaKomokuPatternComboBox
            // 
            this.kensaKomokuPatternComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensaKomokuPatternComboBox.FormattingEnabled = true;
            this.kensaKomokuPatternComboBox.Items.AddRange(new object[] {
            "0:パターンA",
            "1:パターンB"});
            this.kensaKomokuPatternComboBox.Location = new System.Drawing.Point(150, 17);
            this.kensaKomokuPatternComboBox.Name = "kensaKomokuPatternComboBox";
            this.kensaKomokuPatternComboBox.Size = new System.Drawing.Size(301, 28);
            this.kensaKomokuPatternComboBox.TabIndex = 1;
            this.kensaKomokuPatternComboBox.SelectedIndexChanged += new System.EventHandler(this.kensaKomokuPatternComboBox_SelectedIndexChanged);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(381, 174);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // KensaSetSelectForm
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
            this.Name = "KensaSetSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浄化槽台帳水質検査項目";
            this.Load += new System.EventHandler(this.KensaSetSelectForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaSetSelectForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button choiceButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox kensaKomokuPatternComboBox;
        private Control.ZTextBox kensaKomokuNaiyoTextBox;
    }
}