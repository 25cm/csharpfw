namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class FukjTabBaseDialog
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentsPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.LightGreen;
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(294, 50);
            this.topPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(79, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(137, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "FukjTabBaseDialog";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentsPanel
            // 
            this.contentsPanel.Location = new System.Drawing.Point(0, 51);
            this.contentsPanel.Name = "contentsPanel";
            this.contentsPanel.Size = new System.Drawing.Size(294, 220);
            this.contentsPanel.TabIndex = 1;
            // 
            // FukjTabBaseDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(294, 271);
            this.ControlBox = false;
            this.Controls.Add(this.contentsPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FukjTabBaseDialog";
            this.Text = "FukjTabBaseDialog";
            this.Load += new System.EventHandler(this.FukjTabBaseDialog_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel contentsPanel;
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Label titleLabel;




    }
}

