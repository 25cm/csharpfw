namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class LineSelectDialog
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
            this.ok_StraightButton = new Zynas.Control.ZButton(this.components);
            this.ok_ArrowButton = new Zynas.Control.ZButton(this.components);
            this.ok_RectangleButton = new Zynas.Control.ZButton(this.components);
            this.SuspendLayout();
            // 
            // ok_StraightButton
            // 
            this.ok_StraightButton.BackColor = System.Drawing.SystemColors.Control;
            this.ok_StraightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_StraightButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ok_StraightButton.ForeColor = System.Drawing.Color.Black;
            this.ok_StraightButton.Location = new System.Drawing.Point(3, 3);
            this.ok_StraightButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ok_StraightButton.Name = "ok_StraightButton";
            this.ok_StraightButton.Size = new System.Drawing.Size(100, 100);
            this.ok_StraightButton.TabIndex = 1;
            this.ok_StraightButton.TabStop = false;
            this.ok_StraightButton.Text = "折れ線";
            this.ok_StraightButton.UseVisualStyleBackColor = false;
            this.ok_StraightButton.Click += new System.EventHandler(this.ok_StraightButton_Click);
            // 
            // ok_ArrowButton
            // 
            this.ok_ArrowButton.BackColor = System.Drawing.SystemColors.Control;
            this.ok_ArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_ArrowButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold);
            this.ok_ArrowButton.ForeColor = System.Drawing.Color.Black;
            this.ok_ArrowButton.Location = new System.Drawing.Point(106, 3);
            this.ok_ArrowButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ok_ArrowButton.Name = "ok_ArrowButton";
            this.ok_ArrowButton.Size = new System.Drawing.Size(100, 100);
            this.ok_ArrowButton.TabIndex = 2;
            this.ok_ArrowButton.TabStop = false;
            this.ok_ArrowButton.Text = "矢印";
            this.ok_ArrowButton.UseVisualStyleBackColor = false;
            this.ok_ArrowButton.Click += new System.EventHandler(this.ok_ArrowButton_Click);
            // 
            // ok_RectangleButton
            // 
            this.ok_RectangleButton.BackColor = System.Drawing.SystemColors.Control;
            this.ok_RectangleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_RectangleButton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold);
            this.ok_RectangleButton.ForeColor = System.Drawing.Color.Black;
            this.ok_RectangleButton.Location = new System.Drawing.Point(209, 3);
            this.ok_RectangleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ok_RectangleButton.Name = "ok_RectangleButton";
            this.ok_RectangleButton.Size = new System.Drawing.Size(100, 100);
            this.ok_RectangleButton.TabIndex = 3;
            this.ok_RectangleButton.TabStop = false;
            this.ok_RectangleButton.Text = "多角形";
            this.ok_RectangleButton.UseVisualStyleBackColor = false;
            this.ok_RectangleButton.Click += new System.EventHandler(this.ok_RectangleButton_Click);
            // 
            // LineSelectDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(312, 106);
            this.ControlBox = false;
            this.Controls.Add(this.ok_RectangleButton);
            this.Controls.Add(this.ok_ArrowButton);
            this.Controls.Add(this.ok_StraightButton);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LineSelectDialog";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TextInputForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton ok_StraightButton;
        private Zynas.Control.ZButton ok_ArrowButton;
        private Zynas.Control.ZButton ok_RectangleButton;
    }
}