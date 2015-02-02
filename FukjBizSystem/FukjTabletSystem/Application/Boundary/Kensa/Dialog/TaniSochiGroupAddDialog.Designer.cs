namespace FukjTabletSystem.Application.Boundary.Kensa.Dialog
{
    partial class TaniSochiGroupAddDialog
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
            this.closeButton = new Zynas.Control.ZButton(this.components);
            this.groupListBox = new System.Windows.Forms.ListBox();
            this.shokenHanteiDataSet = new FukjTabletSystem.Application.Boundary.Kensa.Dialog.ShokenHanteiDataSet();
            this.ketteiButton = new Zynas.Control.ZButton(this.components);
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokenHanteiDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.ketteiButton);
            this.contentsPanel.Controls.Add(this.groupListBox);
            this.contentsPanel.Size = new System.Drawing.Size(394, 519);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Size = new System.Drawing.Size(394, 50);
            this.topPanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.topPanel.Controls.SetChildIndex(this.closeButton, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(75, 5);
            this.titleLabel.Size = new System.Drawing.Size(244, 36);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "保有単位装置GR追加";
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::FukjTabletSystem.Properties.Resources.top_close;
            this.closeButton.Location = new System.Drawing.Point(1, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(70, 48);
            this.closeButton.TabIndex = 0;
            this.closeButton.TabStop = false;
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // groupListBox
            // 
            this.groupListBox.DataSource = this.shokenHanteiDataSet;
            this.groupListBox.DisplayMember = "TaniSochiGroupMst.TaniSochiGroupNm";
            this.groupListBox.FormattingEnabled = true;
            this.groupListBox.ItemHeight = 24;
            this.groupListBox.Location = new System.Drawing.Point(21, 13);
            this.groupListBox.Name = "groupListBox";
            this.groupListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.groupListBox.Size = new System.Drawing.Size(359, 436);
            this.groupListBox.TabIndex = 0;
            this.groupListBox.ValueMember = "TaniSochiGroupMst.TaniSochiGroupCd";
            // 
            // shokenHanteiDataSet
            // 
            this.shokenHanteiDataSet.DataSetName = "ShokenHanteiDataSet";
            this.shokenHanteiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ketteiButton
            // 
            this.ketteiButton.Location = new System.Drawing.Point(258, 461);
            this.ketteiButton.Name = "ketteiButton";
            this.ketteiButton.Size = new System.Drawing.Size(122, 47);
            this.ketteiButton.TabIndex = 16;
            this.ketteiButton.Text = "決定";
            this.ketteiButton.UseVisualStyleBackColor = true;
            this.ketteiButton.Click += new System.EventHandler(this.ketteiButton_Click);
            // 
            // TaniSochiGroupAddDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(394, 571);
            this.Name = "TaniSochiGroupAddDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "保有単位装置グループ追加";
            this.Load += new System.EventHandler(this.Form_Load);
            this.contentsPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokenHanteiDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton closeButton;
        private System.Windows.Forms.ListBox groupListBox;
        private Zynas.Control.ZButton ketteiButton;
        private ShokenHanteiDataSet shokenHanteiDataSet;
    }
}