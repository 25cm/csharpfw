namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class InkCanvasDialog
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
            this.clearButton = new Zynas.Control.ZButton(this.components);
            this.eraceButton = new Zynas.Control.ZButton(this.components);
            this.widthButton = new Zynas.Control.ZButton(this.components);
            this.cancelButton = new Zynas.Control.ZButton(this.components);
            this.saveButton = new Zynas.Control.ZButton(this.components);
            this.ovalLargeCheckBox = new System.Windows.Forms.CheckBox();
            this.ovalSmallCheckBox = new System.Windows.Forms.CheckBox();
            this.textInputCheckBox = new System.Windows.Forms.CheckBox();
            this.lineInputCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Location = new System.Drawing.Point(383, 804);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(120, 42);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clerButton_Click);
            // 
            // eraceButton
            // 
            this.eraceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eraceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eraceButton.Location = new System.Drawing.Point(259, 804);
            this.eraceButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.eraceButton.Name = "eraceButton";
            this.eraceButton.Size = new System.Drawing.Size(120, 42);
            this.eraceButton.TabIndex = 2;
            this.eraceButton.Text = "消ゴム";
            this.eraceButton.UseVisualStyleBackColor = false;
            this.eraceButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // widthButton
            // 
            this.widthButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.widthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.widthButton.Location = new System.Drawing.Point(135, 804);
            this.widthButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.widthButton.Name = "widthButton";
            this.widthButton.Size = new System.Drawing.Size(120, 42);
            this.widthButton.TabIndex = 1;
            this.widthButton.Text = "太さ：1";
            this.widthButton.UseVisualStyleBackColor = false;
            this.widthButton.Click += new System.EventHandler(this.widthButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(629, 804);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(160, 42);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(11, 804);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 42);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ovalLargeCheckBox
            // 
            this.ovalLargeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalLargeCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ovalLargeCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ovalLargeCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.ovalLargeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ovalLargeCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_oval_l;
            this.ovalLargeCheckBox.Location = new System.Drawing.Point(451, 12);
            this.ovalLargeCheckBox.Name = "ovalLargeCheckBox";
            this.ovalLargeCheckBox.Size = new System.Drawing.Size(80, 64);
            this.ovalLargeCheckBox.TabIndex = 16;
            this.ovalLargeCheckBox.TabStop = false;
            this.ovalLargeCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ovalLargeCheckBox.UseVisualStyleBackColor = true;
            this.ovalLargeCheckBox.CheckedChanged += new System.EventHandler(this.ovalLargeCheckBox_CheckedChanged);
            // 
            // ovalSmallCheckBox
            // 
            this.ovalSmallCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalSmallCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ovalSmallCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ovalSmallCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.ovalSmallCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ovalSmallCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_oval_s;
            this.ovalSmallCheckBox.Location = new System.Drawing.Point(537, 12);
            this.ovalSmallCheckBox.Name = "ovalSmallCheckBox";
            this.ovalSmallCheckBox.Size = new System.Drawing.Size(80, 64);
            this.ovalSmallCheckBox.TabIndex = 15;
            this.ovalSmallCheckBox.TabStop = false;
            this.ovalSmallCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ovalSmallCheckBox.UseVisualStyleBackColor = true;
            this.ovalSmallCheckBox.CheckedChanged += new System.EventHandler(this.ovalSmallCheckBox_CheckedChanged);
            // 
            // textInputCheckBox
            // 
            this.textInputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textInputCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.textInputCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.textInputCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.textInputCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textInputCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_text;
            this.textInputCheckBox.Location = new System.Drawing.Point(623, 12);
            this.textInputCheckBox.Name = "textInputCheckBox";
            this.textInputCheckBox.Size = new System.Drawing.Size(80, 64);
            this.textInputCheckBox.TabIndex = 13;
            this.textInputCheckBox.TabStop = false;
            this.textInputCheckBox.UseVisualStyleBackColor = true;
            this.textInputCheckBox.CheckedChanged += new System.EventHandler(this.textInputCheckBox_CheckedChanged);
            // 
            // lineInputCheckBox
            // 
            this.lineInputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineInputCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.lineInputCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.lineInputCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.lineInputCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineInputCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_ruler;
            this.lineInputCheckBox.Location = new System.Drawing.Point(709, 12);
            this.lineInputCheckBox.Name = "lineInputCheckBox";
            this.lineInputCheckBox.Size = new System.Drawing.Size(80, 64);
            this.lineInputCheckBox.TabIndex = 12;
            this.lineInputCheckBox.TabStop = false;
            this.lineInputCheckBox.UseVisualStyleBackColor = true;
            this.lineInputCheckBox.CheckedChanged += new System.EventHandler(this.lineInputCheckBox_CheckedChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 858);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // InkCanvasDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 858);
            this.Controls.Add(this.ovalLargeCheckBox);
            this.Controls.Add(this.ovalSmallCheckBox);
            this.Controls.Add(this.textInputCheckBox);
            this.Controls.Add(this.lineInputCheckBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.eraceButton);
            this.Controls.Add(this.widthButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "InkCanvasDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "InkCanvasDialog";
            this.Load += new System.EventHandler(this.InkCanvasDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private Zynas.Control.ZButton cancelButton;
        private Zynas.Control.ZButton saveButton;
        private Zynas.Control.ZButton widthButton;
        private Zynas.Control.ZButton eraceButton;
        private Zynas.Control.ZButton clearButton;
        private System.Windows.Forms.CheckBox textInputCheckBox;
        private System.Windows.Forms.CheckBox lineInputCheckBox;
        private System.Windows.Forms.CheckBox ovalSmallCheckBox;
        private System.Windows.Forms.CheckBox ovalLargeCheckBox;
    }
}