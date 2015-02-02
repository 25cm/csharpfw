namespace Zynas.Control.Setting
{
    partial class SettingControl
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
            this.closeButton = new System.Windows.Forms.Button();
            this.entryButton = new System.Windows.Forms.Button();
            this.itemLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(506, 346);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // entryButton
            // 
            this.entryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.entryButton.Location = new System.Drawing.Point(425, 346);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(75, 23);
            this.entryButton.TabIndex = 1;
            this.entryButton.Text = "確定";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // itemLayoutPanel
            // 
            this.itemLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemLayoutPanel.AutoScroll = true;
            this.itemLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.itemLayoutPanel.Name = "itemLayoutPanel";
            this.itemLayoutPanel.Size = new System.Drawing.Size(569, 328);
            this.itemLayoutPanel.TabIndex = 0;
            // 
            // SettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 381);
            this.Controls.Add(this.itemLayoutPanel);
            this.Controls.Add(this.entryButton);
            this.Controls.Add(this.closeButton);
            this.Name = "SettingControl";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.PrinterSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.FlowLayoutPanel itemLayoutPanel;
    }
}