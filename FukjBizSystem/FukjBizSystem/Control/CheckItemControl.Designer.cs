namespace FukjBizSystem.Control
{
    partial class CheckItemControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.itemNoLabel = new System.Windows.Forms.Label();
            this.itemTextBox = new System.Windows.Forms.Label();
            this.hanteiTextLabel = new System.Windows.Forms.Label();
            this.hanteiBaseLabel = new System.Windows.Forms.Label();
            this.itemTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itemNoLabel
            // 
            this.itemNoLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemNoLabel.Location = new System.Drawing.Point(0, 0);
            this.itemNoLabel.Name = "itemNoLabel";
            this.itemNoLabel.Size = new System.Drawing.Size(24, 20);
            this.itemNoLabel.TabIndex = 0;
            this.itemNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itemTextBox
            // 
            this.itemTextBox.BackColor = System.Drawing.Color.LightGreen;
            this.itemTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemTextBox.Location = new System.Drawing.Point(27, 3);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(105, 16);
            this.itemTextBox.TabIndex = 2;
            this.itemTextBox.Click += new System.EventHandler(this.itemTextBox_Click);
            // 
            // hanteiTextLabel
            // 
            this.hanteiTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.hanteiTextLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.hanteiTextLabel.Location = new System.Drawing.Point(140, 3);
            this.hanteiTextLabel.Name = "hanteiTextLabel";
            this.hanteiTextLabel.Size = new System.Drawing.Size(18, 16);
            this.hanteiTextLabel.TabIndex = 4;
            this.hanteiTextLabel.Text = "○";
            // 
            // hanteiBaseLabel
            // 
            this.hanteiBaseLabel.BackColor = System.Drawing.SystemColors.Control;
            this.hanteiBaseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hanteiBaseLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.hanteiBaseLabel.Location = new System.Drawing.Point(136, 0);
            this.hanteiBaseLabel.Name = "hanteiBaseLabel";
            this.hanteiBaseLabel.Size = new System.Drawing.Size(27, 20);
            this.hanteiBaseLabel.TabIndex = 3;
            this.hanteiBaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // itemTextLabel
            // 
            this.itemTextLabel.BackColor = System.Drawing.Color.LightGreen;
            this.itemTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemTextLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemTextLabel.Location = new System.Drawing.Point(24, 0);
            this.itemTextLabel.Name = "itemTextLabel";
            this.itemTextLabel.Size = new System.Drawing.Size(112, 20);
            this.itemTextLabel.TabIndex = 1;
            this.itemTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hanteiTextLabel);
            this.Controls.Add(this.hanteiBaseLabel);
            this.Controls.Add(this.itemTextBox);
            this.Controls.Add(this.itemNoLabel);
            this.Controls.Add(this.itemTextLabel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CheckItemControl";
            this.Size = new System.Drawing.Size(164, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label itemNoLabel;
        private System.Windows.Forms.Label itemTextBox;
        private System.Windows.Forms.Label hanteiTextLabel;
        private System.Windows.Forms.Label hanteiBaseLabel;
        private System.Windows.Forms.Label itemTextLabel;

    }
}
