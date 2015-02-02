namespace FukjTabletSystem.Application.Boundary.Common
{
    partial class TopMenuForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.versionLabel = new System.Windows.Forms.Label();
            this.syncDataButton = new Zynas.Control.ZButton(this.components);
            this.syncOVLButton = new Zynas.Control.ZButton(this.components);
            this.syncMasterButton = new Zynas.Control.ZButton(this.components);
            this.closeButton = new Zynas.Control.ZButton(this.components);
            this.kensaListButton = new Zynas.Control.ZButton(this.components);
            this.lastDownloadLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastUploadLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lastSyncLabel = new System.Windows.Forms.Label();
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.label3);
            this.contentsPanel.Controls.Add(this.lastSyncLabel);
            this.contentsPanel.Controls.Add(this.label2);
            this.contentsPanel.Controls.Add(this.lastUploadLabel);
            this.contentsPanel.Controls.Add(this.label1);
            this.contentsPanel.Controls.Add(this.lastDownloadLabel);
            this.contentsPanel.Controls.Add(this.kensaListButton);
            this.contentsPanel.Controls.Add(this.versionLabel);
            this.contentsPanel.Controls.Add(this.syncDataButton);
            this.contentsPanel.Controls.Add(this.syncOVLButton);
            this.contentsPanel.Controls.Add(this.syncMasterButton);
            this.contentsPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.TabIndex = 1;
            this.topPanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.topPanel.Controls.SetChildIndex(this.closeButton, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "タブレットメニュー（仮）";
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.Location = new System.Drawing.Point(1076, 643);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(186, 28);
            this.versionLabel.TabIndex = 10;
            this.versionLabel.Text = "XX.XX.XX.XX";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // syncDataButton
            // 
            this.syncDataButton.Enabled = false;
            this.syncDataButton.Image = global::FukjTabletSystem.Properties.Resources.menu_sync_push;
            this.syncDataButton.Location = new System.Drawing.Point(40, 174);
            this.syncDataButton.Name = "syncDataButton";
            this.syncDataButton.Size = new System.Drawing.Size(390, 100);
            this.syncDataButton.TabIndex = 3;
            this.syncDataButton.Text = "　　検査結果データをアップロード　";
            this.syncDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.syncDataButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.syncDataButton.UseVisualStyleBackColor = true;
            this.syncDataButton.Click += new System.EventHandler(this.syncDataButton_Click);
            // 
            // syncOVLButton
            // 
            this.syncOVLButton.Enabled = false;
            this.syncOVLButton.Image = global::FukjTabletSystem.Properties.Resources.btn_map;
            this.syncOVLButton.Location = new System.Drawing.Point(40, 442);
            this.syncOVLButton.Name = "syncOVLButton";
            this.syncOVLButton.Size = new System.Drawing.Size(390, 100);
            this.syncOVLButton.TabIndex = 7;
            this.syncOVLButton.Text = "　　マップ情報（レイヤー）を同期　";
            this.syncOVLButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.syncOVLButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.syncOVLButton.UseVisualStyleBackColor = true;
            this.syncOVLButton.Click += new System.EventHandler(this.syncOVLButton_Click);
            // 
            // syncMasterButton
            // 
            this.syncMasterButton.Image = global::FukjTabletSystem.Properties.Resources.menu_sync_pull;
            this.syncMasterButton.Location = new System.Drawing.Point(40, 40);
            this.syncMasterButton.Name = "syncMasterButton";
            this.syncMasterButton.Size = new System.Drawing.Size(390, 100);
            this.syncMasterButton.TabIndex = 0;
            this.syncMasterButton.Text = "　　マスタ、検査予定をダウンロード";
            this.syncMasterButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.syncMasterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.syncMasterButton.UseVisualStyleBackColor = true;
            this.syncMasterButton.Click += new System.EventHandler(this.syncMasterButton_Click);
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
            // kensaListButton
            // 
            this.kensaListButton.Image = global::FukjTabletSystem.Properties.Resources.btn_kensa;
            this.kensaListButton.Location = new System.Drawing.Point(40, 308);
            this.kensaListButton.Name = "kensaListButton";
            this.kensaListButton.Size = new System.Drawing.Size(390, 100);
            this.kensaListButton.TabIndex = 6;
            this.kensaListButton.Text = "　　検査予定一覧　　　　　　　　　";
            this.kensaListButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kensaListButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.kensaListButton.UseVisualStyleBackColor = true;
            this.kensaListButton.Click += new System.EventHandler(this.kensaListButton_Click);
            // 
            // lastDownloadLabel
            // 
            this.lastDownloadLabel.AutoSize = true;
            this.lastDownloadLabel.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lastDownloadLabel.Location = new System.Drawing.Point(452, 92);
            this.lastDownloadLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lastDownloadLabel.Name = "lastDownloadLabel";
            this.lastDownloadLabel.Size = new System.Drawing.Size(198, 31);
            this.lastDownloadLabel.TabIndex = 2;
            this.lastDownloadLabel.Text = "____/__/__ (＿)";
            this.lastDownloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "端末にダウンロードされている検査予定日付";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "アップロードが完了した検査日付";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastUploadLabel
            // 
            this.lastUploadLabel.AutoSize = true;
            this.lastUploadLabel.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lastUploadLabel.Location = new System.Drawing.Point(452, 226);
            this.lastUploadLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lastUploadLabel.Name = "lastUploadLabel";
            this.lastUploadLabel.Size = new System.Drawing.Size(198, 31);
            this.lastUploadLabel.TabIndex = 5;
            this.lastUploadLabel.Text = "____/__/__ (＿)";
            this.lastUploadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 464);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "前回同期を実行した日時";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastSyncLabel
            // 
            this.lastSyncLabel.AutoSize = true;
            this.lastSyncLabel.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lastSyncLabel.Location = new System.Drawing.Point(452, 494);
            this.lastSyncLabel.Margin = new System.Windows.Forms.Padding(3);
            this.lastSyncLabel.Name = "lastSyncLabel";
            this.lastSyncLabel.Size = new System.Drawing.Size(269, 31);
            this.lastSyncLabel.TabIndex = 9;
            this.lastSyncLabel.Text = "____/__/__ (＿) __:__";
            this.lastSyncLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TopMenuForm
            // 
            this.ClientSize = new System.Drawing.Size(1274, 731);
            this.Name = "TopMenuForm";
            this.Text = "トップメニュー";
            this.Load += new System.EventHandler(this.TopMenuForm_Load);
            this.contentsPanel.ResumeLayout(false);
            this.contentsPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton syncMasterButton;
        private Zynas.Control.ZButton syncDataButton;
        private Zynas.Control.ZButton syncOVLButton;
        private System.Windows.Forms.Label versionLabel;
        private Zynas.Control.ZButton closeButton;
        private Zynas.Control.ZButton kensaListButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lastSyncLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lastUploadLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastDownloadLabel;




    }
}