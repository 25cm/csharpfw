namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    partial class KensaYoteiMap
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
            this.iconBlinkTimer = new System.Windows.Forms.Timer(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.decisionButton = new System.Windows.Forms.Button();
            this.modeMoveButton = new System.Windows.Forms.Button();
            this.modeNormalButton = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.mwView = new FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku.ZMapControlMW();
            this.allButton = new System.Windows.Forms.Button();
            this.yoteiListButton = new System.Windows.Forms.Button();
            this.calenderButton = new System.Windows.Forms.Button();
            this.memoListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iconBlinkTimer
            // 
            this.iconBlinkTimer.Interval = 1000;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(992, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(99, 33);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.Location = new System.Drawing.Point(844, 12);
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(99, 33);
            this.decisionButton.TabIndex = 10;
            this.decisionButton.Text = "確定";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.decisionButton_Click);
            // 
            // modeMoveButton
            // 
            this.modeMoveButton.Location = new System.Drawing.Point(739, 12);
            this.modeMoveButton.Name = "modeMoveButton";
            this.modeMoveButton.Size = new System.Drawing.Size(99, 33);
            this.modeMoveButton.TabIndex = 9;
            this.modeMoveButton.Text = "住所移動モード";
            this.modeMoveButton.UseVisualStyleBackColor = true;
            this.modeMoveButton.Click += new System.EventHandler(this.modeMoveButton_Click);
            // 
            // modeNormalButton
            // 
            this.modeNormalButton.Location = new System.Drawing.Point(634, 12);
            this.modeNormalButton.Name = "modeNormalButton";
            this.modeNormalButton.Size = new System.Drawing.Size(99, 33);
            this.modeNormalButton.TabIndex = 8;
            this.modeNormalButton.Text = "通常モード";
            this.modeNormalButton.UseVisualStyleBackColor = true;
            this.modeNormalButton.Click += new System.EventHandler(this.modeNormalButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Location = new System.Drawing.Point(528, 12);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(42, 33);
            this.zoomOutButton.TabIndex = 7;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.Location = new System.Drawing.Point(478, 12);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(44, 33);
            this.zoomInButton.TabIndex = 6;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // mwView
            // 
            this.mwView.BackColor = System.Drawing.Color.White;
            this.mwView.Location = new System.Drawing.Point(12, 51);
            this.mwView.Name = "mwView";
            this.mwView.Size = new System.Drawing.Size(1079, 530);
            this.mwView.TabIndex = 0;
            this.mwView.Text = "mwView1";
            // 
            // allButton
            // 
            this.allButton.Location = new System.Drawing.Point(338, 12);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(99, 33);
            this.allButton.TabIndex = 4;
            this.allButton.Text = "全て";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // yoteiListButton
            // 
            this.yoteiListButton.Location = new System.Drawing.Point(222, 12);
            this.yoteiListButton.Name = "yoteiListButton";
            this.yoteiListButton.Size = new System.Drawing.Size(99, 33);
            this.yoteiListButton.TabIndex = 3;
            this.yoteiListButton.Text = "予定入力";
            this.yoteiListButton.UseVisualStyleBackColor = true;
            this.yoteiListButton.Click += new System.EventHandler(this.yoteiListButton_Click);
            // 
            // calenderButton
            // 
            this.calenderButton.Location = new System.Drawing.Point(117, 12);
            this.calenderButton.Name = "calenderButton";
            this.calenderButton.Size = new System.Drawing.Size(99, 33);
            this.calenderButton.TabIndex = 2;
            this.calenderButton.Text = "カレンダー";
            this.calenderButton.UseVisualStyleBackColor = true;
            this.calenderButton.Click += new System.EventHandler(this.calenderButton_Click);
            // 
            // memoListButton
            // 
            this.memoListButton.Location = new System.Drawing.Point(12, 12);
            this.memoListButton.Name = "memoListButton";
            this.memoListButton.Size = new System.Drawing.Size(99, 33);
            this.memoListButton.TabIndex = 1;
            this.memoListButton.Text = "メモ一覧";
            this.memoListButton.UseVisualStyleBackColor = true;
            this.memoListButton.Click += new System.EventHandler(this.memoListButton_Click);
            // 
            // KensaYoteiMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.decisionButton);
            this.Controls.Add(this.modeMoveButton);
            this.Controls.Add(this.modeNormalButton);
            this.Controls.Add(this.zoomOutButton);
            this.Controls.Add(this.zoomInButton);
            this.Controls.Add(this.mwView);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.yoteiListButton);
            this.Controls.Add(this.calenderButton);
            this.Controls.Add(this.memoListButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KensaYoteiMap";
            this.Text = "検査計画";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KensaYoteiMap_FormClosing);
            this.Load += new System.EventHandler(this.KensaYoteiMap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button memoListButton;
        private System.Windows.Forms.Button calenderButton;
        private System.Windows.Forms.Button yoteiListButton;
        private System.Windows.Forms.Button allButton;
        private ZMapControlMW mwView;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.Button zoomOutButton;
        private System.Windows.Forms.Button modeNormalButton;
        private System.Windows.Forms.Button modeMoveButton;
        private System.Windows.Forms.Timer iconBlinkTimer;
        private System.Windows.Forms.Button decisionButton;
        private System.Windows.Forms.Button closeButton;
    }
}

