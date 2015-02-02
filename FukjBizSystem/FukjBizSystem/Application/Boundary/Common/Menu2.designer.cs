namespace FukjBizSystem.Application.Boundary.Common2
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.formPanel = new System.Windows.Forms.Panel();
            this.rootMenuPanel = new System.Windows.Forms.Panel();
            this.sonotaButton = new System.Windows.Forms.Button();
            this.suishitsuKensaButton = new System.Windows.Forms.Button();
            this.hoteiKensaButton = new System.Windows.Forms.Button();
            this.keiriButton = new System.Windows.Forms.Button();
            this.kaiinButton = new System.Windows.Forms.Button();
            this.saisuiinButton = new System.Windows.Forms.Button();
            this.yoshiHanbaiButton = new System.Windows.Forms.Button();
            this.kinoHoshoButton = new System.Windows.Forms.Button();
            this.masterButton = new System.Windows.Forms.Button();
            this.daichoButton = new System.Windows.Forms.Button();
            this.userSettingButton = new System.Windows.Forms.Button();
            this.workListButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersionVal = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.strShokuinNm = new System.Windows.Forms.Label();
            this.lblLoginNm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.rootMenuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.formPanel.Location = new System.Drawing.Point(160, 68);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(1103, 593);
            this.formPanel.TabIndex = 2;
            // 
            // rootMenuPanel
            // 
            this.rootMenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rootMenuPanel.BackColor = System.Drawing.Color.PaleGreen;
            this.rootMenuPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rootMenuPanel.BackgroundImage")));
            this.rootMenuPanel.Controls.Add(this.sonotaButton);
            this.rootMenuPanel.Controls.Add(this.suishitsuKensaButton);
            this.rootMenuPanel.Controls.Add(this.hoteiKensaButton);
            this.rootMenuPanel.Controls.Add(this.keiriButton);
            this.rootMenuPanel.Controls.Add(this.kaiinButton);
            this.rootMenuPanel.Controls.Add(this.saisuiinButton);
            this.rootMenuPanel.Controls.Add(this.yoshiHanbaiButton);
            this.rootMenuPanel.Controls.Add(this.kinoHoshoButton);
            this.rootMenuPanel.Controls.Add(this.masterButton);
            this.rootMenuPanel.Controls.Add(this.daichoButton);
            this.rootMenuPanel.Controls.Add(this.userSettingButton);
            this.rootMenuPanel.Controls.Add(this.workListButton);
            this.rootMenuPanel.Font = new System.Drawing.Font("メイリオ", 10F);
            this.rootMenuPanel.Location = new System.Drawing.Point(0, 60);
            this.rootMenuPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rootMenuPanel.Name = "rootMenuPanel";
            this.rootMenuPanel.Size = new System.Drawing.Size(153, 630);
            this.rootMenuPanel.TabIndex = 1;
            // 
            // sonotaButton
            // 
            this.sonotaButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sonotaButton.Location = new System.Drawing.Point(8, 409);
            this.sonotaButton.Name = "sonotaButton";
            this.sonotaButton.Size = new System.Drawing.Size(138, 29);
            this.sonotaButton.TabIndex = 11;
            this.sonotaButton.Text = "その他";
            this.sonotaButton.UseVisualStyleBackColor = true;
            this.sonotaButton.Visible = false;
            this.sonotaButton.Click += new System.EventHandler(this.sonotaButton_Click);
            // 
            // suishitsuKensaButton
            // 
            this.suishitsuKensaButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suishitsuKensaButton.Location = new System.Drawing.Point(8, 374);
            this.suishitsuKensaButton.Name = "suishitsuKensaButton";
            this.suishitsuKensaButton.Size = new System.Drawing.Size(138, 29);
            this.suishitsuKensaButton.TabIndex = 10;
            this.suishitsuKensaButton.Text = "水質検査管理";
            this.suishitsuKensaButton.UseVisualStyleBackColor = true;
            this.suishitsuKensaButton.Visible = false;
            this.suishitsuKensaButton.Click += new System.EventHandler(this.suishitsuKensaButton_Click);
            // 
            // hoteiKensaButton
            // 
            this.hoteiKensaButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hoteiKensaButton.Location = new System.Drawing.Point(8, 339);
            this.hoteiKensaButton.Name = "hoteiKensaButton";
            this.hoteiKensaButton.Size = new System.Drawing.Size(138, 29);
            this.hoteiKensaButton.TabIndex = 9;
            this.hoteiKensaButton.Text = "法定検査管理";
            this.hoteiKensaButton.UseVisualStyleBackColor = true;
            this.hoteiKensaButton.Visible = false;
            this.hoteiKensaButton.Click += new System.EventHandler(this.hoteiKensaButton_Click);
            // 
            // keiriButton
            // 
            this.keiriButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.keiriButton.Location = new System.Drawing.Point(7, 304);
            this.keiriButton.Name = "keiriButton";
            this.keiriButton.Size = new System.Drawing.Size(138, 29);
            this.keiriButton.TabIndex = 8;
            this.keiriButton.Text = "経理管理";
            this.keiriButton.UseVisualStyleBackColor = true;
            this.keiriButton.Visible = false;
            this.keiriButton.Click += new System.EventHandler(this.keiriButton_Click);
            // 
            // kaiinButton
            // 
            this.kaiinButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kaiinButton.Location = new System.Drawing.Point(7, 269);
            this.kaiinButton.Name = "kaiinButton";
            this.kaiinButton.Size = new System.Drawing.Size(138, 29);
            this.kaiinButton.TabIndex = 7;
            this.kaiinButton.Text = "会員管理";
            this.kaiinButton.UseVisualStyleBackColor = true;
            this.kaiinButton.Visible = false;
            this.kaiinButton.Click += new System.EventHandler(this.kaiinButton_Click);
            // 
            // saisuiinButton
            // 
            this.saisuiinButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saisuiinButton.Location = new System.Drawing.Point(7, 231);
            this.saisuiinButton.Name = "saisuiinButton";
            this.saisuiinButton.Size = new System.Drawing.Size(138, 29);
            this.saisuiinButton.TabIndex = 6;
            this.saisuiinButton.Text = "採水員管理";
            this.saisuiinButton.UseVisualStyleBackColor = true;
            this.saisuiinButton.Visible = false;
            this.saisuiinButton.Click += new System.EventHandler(this.saisuiinButton_Click);
            // 
            // yoshiHanbaiButton
            // 
            this.yoshiHanbaiButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yoshiHanbaiButton.Location = new System.Drawing.Point(8, 193);
            this.yoshiHanbaiButton.Name = "yoshiHanbaiButton";
            this.yoshiHanbaiButton.Size = new System.Drawing.Size(138, 29);
            this.yoshiHanbaiButton.TabIndex = 5;
            this.yoshiHanbaiButton.Text = "用紙販売管理";
            this.yoshiHanbaiButton.UseVisualStyleBackColor = true;
            this.yoshiHanbaiButton.Visible = false;
            this.yoshiHanbaiButton.Click += new System.EventHandler(this.yoshiHanbaiButton_Click);
            // 
            // kinoHoshoButton
            // 
            this.kinoHoshoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kinoHoshoButton.Location = new System.Drawing.Point(8, 158);
            this.kinoHoshoButton.Name = "kinoHoshoButton";
            this.kinoHoshoButton.Size = new System.Drawing.Size(138, 29);
            this.kinoHoshoButton.TabIndex = 4;
            this.kinoHoshoButton.Text = "機能保証管理";
            this.kinoHoshoButton.UseVisualStyleBackColor = true;
            this.kinoHoshoButton.Visible = false;
            this.kinoHoshoButton.Click += new System.EventHandler(this.kinoHoshoButton_Click);
            // 
            // masterButton
            // 
            this.masterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.masterButton.Location = new System.Drawing.Point(8, 123);
            this.masterButton.Name = "masterButton";
            this.masterButton.Size = new System.Drawing.Size(138, 29);
            this.masterButton.TabIndex = 3;
            this.masterButton.Text = "マスタ管理";
            this.masterButton.UseVisualStyleBackColor = true;
            this.masterButton.Visible = false;
            this.masterButton.Click += new System.EventHandler(this.masterButton_Click);
            // 
            // daichoButton
            // 
            this.daichoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.daichoButton.Location = new System.Drawing.Point(8, 88);
            this.daichoButton.Name = "daichoButton";
            this.daichoButton.Size = new System.Drawing.Size(138, 29);
            this.daichoButton.TabIndex = 2;
            this.daichoButton.Text = "台帳管理";
            this.daichoButton.UseVisualStyleBackColor = true;
            this.daichoButton.Click += new System.EventHandler(this.daichoButton_Click);
            // 
            // userSettingButton
            // 
            this.userSettingButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userSettingButton.Location = new System.Drawing.Point(8, 53);
            this.userSettingButton.Name = "userSettingButton";
            this.userSettingButton.Size = new System.Drawing.Size(138, 29);
            this.userSettingButton.TabIndex = 1;
            this.userSettingButton.Text = "ユーザー設定";
            this.userSettingButton.UseVisualStyleBackColor = true;
            this.userSettingButton.Click += new System.EventHandler(this.userSettingButton_Click);
            // 
            // workListButton
            // 
            this.workListButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.workListButton.Location = new System.Drawing.Point(8, 18);
            this.workListButton.Name = "workListButton";
            this.workListButton.Size = new System.Drawing.Size(138, 29);
            this.workListButton.TabIndex = 0;
            this.workListButton.Text = "作業一覧";
            this.workListButton.UseVisualStyleBackColor = true;
            this.workListButton.Click += new System.EventHandler(this.workListButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FukjBizSystem.Properties.Resources.title_bg;
            this.panel1.Controls.Add(this.lblVersionVal);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.strShokuinNm);
            this.panel1.Controls.Add(this.lblLoginNm);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1263, 62);
            this.panel1.TabIndex = 0;
            // 
            // lblVersionVal
            // 
            this.lblVersionVal.AutoSize = true;
            this.lblVersionVal.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVersionVal.Location = new System.Drawing.Point(896, 9);
            this.lblVersionVal.Name = "lblVersionVal";
            this.lblVersionVal.Size = new System.Drawing.Size(59, 20);
            this.lblVersionVal.TabIndex = 4;
            this.lblVersionVal.Text = "_.__.__";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVersion.Location = new System.Drawing.Point(834, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(56, 20);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "【Ver】";
            // 
            // strShokuinNm
            // 
            this.strShokuinNm.AutoSize = true;
            this.strShokuinNm.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.strShokuinNm.Location = new System.Drawing.Point(885, 32);
            this.strShokuinNm.Name = "strShokuinNm";
            this.strShokuinNm.Size = new System.Drawing.Size(65, 20);
            this.strShokuinNm.TabIndex = 6;
            this.strShokuinNm.Text = "＿＿ ＿＿";
            // 
            // lblLoginNm
            // 
            this.lblLoginNm.AutoSize = true;
            this.lblLoginNm.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLoginNm.Location = new System.Drawing.Point(790, 32);
            this.lblLoginNm.Name = "lblLoginNm";
            this.lblLoginNm.Size = new System.Drawing.Size(100, 20);
            this.lblLoginNm.TabIndex = 5;
            this.lblLoginNm.Text = "【ログイン者】";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fukuoka Johkasou Association";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "一般財団法人　福岡県浄化槽協会";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(272, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "業務管理システム";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(1113, 21);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(138, 29);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "終了";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 662);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.rootMenuPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1278, 700);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.rootMenuPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel rootMenuPanel;
        private System.Windows.Forms.Button workListButton;
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label strShokuinNm;
        private System.Windows.Forms.Label lblLoginNm;
        private System.Windows.Forms.Button userSettingButton;
        private System.Windows.Forms.Button daichoButton;
        private System.Windows.Forms.Button masterButton;
        private System.Windows.Forms.Button kinoHoshoButton;
        private System.Windows.Forms.Button saisuiinButton;
        private System.Windows.Forms.Button yoshiHanbaiButton;
        private System.Windows.Forms.Button keiriButton;
        private System.Windows.Forms.Button kaiinButton;
        private System.Windows.Forms.Button hoteiKensaButton;
        private System.Windows.Forms.Button suishitsuKensaButton;
        private System.Windows.Forms.Button sonotaButton;
        private System.Windows.Forms.Label lblVersionVal;
        private System.Windows.Forms.Label lblVersion;

    }
}