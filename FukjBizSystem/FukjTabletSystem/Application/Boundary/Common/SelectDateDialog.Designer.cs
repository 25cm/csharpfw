namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class SelectDateDialog
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
            this.ketteiButton = new Zynas.Control.ZButton(this.components);
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.monthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.label3);
            this.contentsPanel.Controls.Add(this.label2);
            this.contentsPanel.Controls.Add(this.label1);
            this.contentsPanel.Controls.Add(this.dayNumericUpDown);
            this.contentsPanel.Controls.Add(this.monthNumericUpDown);
            this.contentsPanel.Controls.Add(this.ketteiButton);
            this.contentsPanel.Controls.Add(this.yearNumericUpDown);
            this.contentsPanel.Size = new System.Drawing.Size(773, 79);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Size = new System.Drawing.Size(773, 50);
            this.topPanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.topPanel.Controls.SetChildIndex(this.closeButton, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(307, 5);
            this.titleLabel.Size = new System.Drawing.Size(183, 36);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "検査予定日選択";
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
            // ketteiButton
            // 
            this.ketteiButton.Location = new System.Drawing.Point(602, 12);
            this.ketteiButton.Name = "ketteiButton";
            this.ketteiButton.Size = new System.Drawing.Size(160, 55);
            this.ketteiButton.TabIndex = 0;
            this.ketteiButton.Text = "決定";
            this.ketteiButton.UseVisualStyleBackColor = true;
            this.ketteiButton.Click += new System.EventHandler(this.ketteiButton_Click);
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yearNumericUpDown.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.yearNumericUpDown.Location = new System.Drawing.Point(10, 12);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.yearNumericUpDown.Minimum = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(160, 55);
            this.yearNumericUpDown.TabIndex = 1;
            this.yearNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yearNumericUpDown.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // monthNumericUpDown
            // 
            this.monthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.monthNumericUpDown.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.monthNumericUpDown.Location = new System.Drawing.Point(234, 12);
            this.monthNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.monthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthNumericUpDown.Name = "monthNumericUpDown";
            this.monthNumericUpDown.Size = new System.Drawing.Size(120, 55);
            this.monthNumericUpDown.TabIndex = 3;
            this.monthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.monthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dayNumericUpDown
            // 
            this.dayNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dayNumericUpDown.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dayNumericUpDown.Location = new System.Drawing.Point(418, 12);
            this.dayNumericUpDown.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.dayNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dayNumericUpDown.Name = "dayNumericUpDown";
            this.dayNumericUpDown.Size = new System.Drawing.Size(120, 55);
            this.dayNumericUpDown.TabIndex = 5;
            this.dayNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dayNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(176, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "年";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(360, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "月";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(544, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "日";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectDateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 131);
            this.Name = "SelectDateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "日付選択";
            this.Load += new System.EventHandler(this.Form_Load);
            this.contentsPanel.ResumeLayout(false);
            this.contentsPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton closeButton;
        private Zynas.Control.ZButton ketteiButton;
        private System.Windows.Forms.NumericUpDown dayNumericUpDown;
        private System.Windows.Forms.NumericUpDown monthNumericUpDown;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}