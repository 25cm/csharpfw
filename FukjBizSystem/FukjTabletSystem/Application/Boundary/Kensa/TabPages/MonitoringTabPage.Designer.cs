namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    partial class MonitoringTabPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoringTabPage));
            this.monitorItemsView = new FukjTabletSystem.Controls.TriStateTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kakuteiButton = new Zynas.Control.ZButton(this.components);
            this.SuspendLayout();
            // 
            // monitorItemsView
            // 
            this.monitorItemsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorItemsView.CheckBoxes = true;
            this.monitorItemsView.CheckedImageIndex = 3;
            this.monitorItemsView.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.monitorItemsView.ImageIndex = 0;
            this.monitorItemsView.ImageList = this.imageList1;
            this.monitorItemsView.Indent = 70;
            this.monitorItemsView.IndeterminateImageIndex = 4;
            this.monitorItemsView.ItemHeight = 64;
            this.monitorItemsView.Location = new System.Drawing.Point(20, 15);
            this.monitorItemsView.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.monitorItemsView.Name = "monitorItemsView";
            this.monitorItemsView.SelectedImageIndex = 0;
            this.monitorItemsView.ShowPlusMinus = false;
            this.monitorItemsView.Size = new System.Drawing.Size(1062, 460);
            this.monitorItemsView.TabIndex = 4;
            this.monitorItemsView.UncheckedImageIndex = 5;
            this.monitorItemsView.UseCustomImages = true;
            this.monitorItemsView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.monitorItemsView_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "0.png");
            this.imageList1.Images.SetKeyName(1, "1.png");
            this.imageList1.Images.SetKeyName(2, "2.png");
            this.imageList1.Images.SetKeyName(3, "3.png");
            this.imageList1.Images.SetKeyName(4, "4.png");
            this.imageList1.Images.SetKeyName(5, "5.png");
            // 
            // kakuteiButton
            // 
            this.kakuteiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kakuteiButton.Location = new System.Drawing.Point(974, 514);
            this.kakuteiButton.Name = "kakuteiButton";
            this.kakuteiButton.Size = new System.Drawing.Size(122, 47);
            this.kakuteiButton.TabIndex = 30;
            this.kakuteiButton.Text = "確定登録";
            this.kakuteiButton.UseVisualStyleBackColor = true;
            this.kakuteiButton.Click += new System.EventHandler(this.kakuteiButton_Click);
            // 
            // MonitoringTabPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.kakuteiButton);
            this.Controls.Add(this.monitorItemsView);
            this.DisplayName = "モニタリング";
            this.Name = "MonitoringTabPage";
            this.Load += new System.EventHandler(this.MonitoringTabPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TriStateTreeView monitorItemsView;
        private Zynas.Control.ZButton kakuteiButton;
        private System.Windows.Forms.ImageList imageList1;

    }
}
