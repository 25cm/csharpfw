namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class FukjTabBaseForm
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
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.kensainNameLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentsPanel = new System.Windows.Forms.Panel();
            this.dateTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.LightGreen;
            this.topPanel.Controls.Add(this.dateTimeLabel);
            this.topPanel.Controls.Add(this.kensainNameLabel);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1274, 50);
            this.topPanel.TabIndex = 0;
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeLabel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimeLabel.Location = new System.Drawing.Point(922, 4);
            this.dateTimeLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(204, 21);
            this.dateTimeLabel.TabIndex = 16;
            this.dateTimeLabel.Text = "yyyy/MM/dd (ddd) hh:mm";
            this.dateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kensainNameLabel
            // 
            this.kensainNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kensainNameLabel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kensainNameLabel.Location = new System.Drawing.Point(922, 25);
            this.kensainNameLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.kensainNameLabel.Name = "kensainNameLabel";
            this.kensainNameLabel.Size = new System.Drawing.Size(204, 21);
            this.kensainNameLabel.TabIndex = 15;
            this.kensainNameLabel.Text = "検査員:";
            this.kensainNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(355, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(565, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "FukjTabBaseForm";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentsPanel
            // 
            this.contentsPanel.AutoScroll = true;
            this.contentsPanel.Location = new System.Drawing.Point(0, 51);
            this.contentsPanel.Name = "contentsPanel";
            this.contentsPanel.Size = new System.Drawing.Size(1274, 680);
            this.contentsPanel.TabIndex = 1;
            // 
            // dateTimeTimer
            // 
            this.dateTimeTimer.Interval = 60000;
            this.dateTimeTimer.Tick += new System.EventHandler(this.dateTimeTimer_Tick);
            // 
            // FukjTabBaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1274, 731);
            this.ControlBox = false;
            this.Controls.Add(this.contentsPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FukjTabBaseForm";
            this.Text = "FukjTabBaseForm";
            this.Load += new System.EventHandler(this.FukjTabBaseForm_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel contentsPanel;
        public System.Windows.Forms.Panel topPanel;
        public System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Label kensainNameLabel;
        private System.Windows.Forms.Timer dateTimeTimer;




    }
}

