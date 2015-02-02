namespace FukjTabletSystem.Application.Boundary.MapWorks
{
    partial class MapWorksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapWorksForm));
            this.mwView = new MapWorks50.MWView();
            this.cntmnuPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPopupRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPopupCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.cntdelPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.キャンセルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpsTimer = new System.Windows.Forms.Timer(this.components);
            this.messageCheckBox = new System.Windows.Forms.CheckBox();
            this.textInputCheckBox = new System.Windows.Forms.CheckBox();
            this.lineInputCheckBox = new System.Windows.Forms.CheckBox();
            this.freeInputCheckBox = new System.Windows.Forms.CheckBox();
            this.gpsCheckBox = new System.Windows.Forms.CheckBox();
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
            this.backButton = new Zynas.Control.ZButton(this.components);
            this.zoomOutButton = new Zynas.Control.ZButton(this.components);
            this.zoomInButton = new Zynas.Control.ZButton(this.components);
            this.addressLabel = new System.Windows.Forms.Label();
            this.keidoLabel = new System.Windows.Forms.Label();
            this.idoLabel = new System.Windows.Forms.Label();
            this.cntmnuPopup.SuspendLayout();
            this.cntdelPopup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mwView
            // 
            this.mwView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mwView.BackColor = System.Drawing.Color.White;
            this.mwView.BorderStyle = ((short)(0));
            this.mwView.ControlID = 1;
            this.mwView.CurLayerNo = 0;
            this.mwView.CursorType = MapWorks50.mwcCursorType.CURSOR_NONE;
            this.mwView.EditMode = MapWorks50.mwcEditMode.EM_NONE;
            this.mwView.Location = new System.Drawing.Point(3, 3);
            this.mwView.MapCache = 32;
            this.mwView.MapDrawMode = MapWorks50.mwcMapDrawMode.MDM_DRAW_1_PASS;
            this.mwView.MapScale = 0;
            this.mwView.MapScaleMode = MapWorks50.mwcMapScaleMode.MSM_ZMD;
            this.mwView.MapSelColor = System.Drawing.Color.Red;
            this.mwView.MapType = MapWorks50.mwcMapType.MT_NONE;
            this.mwView.MapTypeEx = ((ulong)(0ul));
            this.mwView.MouseMode = MapWorks50.mwcMouseMode.MM_HAND_SCROLL;
            this.mwView.MWEnvPath = null;
            this.mwView.Name = "mwView";
            this.mwView.PickDistance = 5;
            this.mwView.PickMode = MapWorks50.mwcPickMode.PKM_NORMAL;
            this.mwView.Rotation = 0F;
            this.mwView.ScaleMode = MapWorks50.mwcScaleMode.SM_BL;
            this.mwView.ScreenRegion = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.mwView.ScrollCursor = true;
            this.mwView.ScrollPeriod = ((short)(10));
            this.mwView.ScrollRange = ((short)(50));
            this.mwView.Size = new System.Drawing.Size(794, 956);
            this.mwView.TabIndex = 0;
            this.mwView.TenKeyControl = true;
            this.mwView.Text = "mwView";
            this.mwView.UseGaijiFont = true;
            this.mwView.ZoomMode = MapWorks50.mwcZoomMode.ZM_NONE;
            this.mwView.MWClick += new MapWorks50.MWClickEventHandler(this.mwView_MWClick);
            this.mwView.DoubleClick += new System.EventHandler(this.mwView_DoubleClick);
            this.mwView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mwView_MouseDown);
            this.mwView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mwView_MouseMove);
            this.mwView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mwView_MouseUp);
            // 
            // cntmnuPopup
            // 
            this.cntmnuPopup.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cntmnuPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPopupRegister,
            this.toolStripSeparator3,
            this.mnuPopupCancel});
            this.cntmnuPopup.Name = "cntmnuPopup";
            this.cntmnuPopup.Size = new System.Drawing.Size(211, 90);
            // 
            // mnuPopupRegister
            // 
            this.mnuPopupRegister.Name = "mnuPopupRegister";
            this.mnuPopupRegister.Size = new System.Drawing.Size(210, 40);
            this.mnuPopupRegister.Text = "登録";
            this.mnuPopupRegister.Click += new System.EventHandler(this.mnuPopupRegister_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // mnuPopupCancel
            // 
            this.mnuPopupCancel.Name = "mnuPopupCancel";
            this.mnuPopupCancel.Size = new System.Drawing.Size(210, 40);
            this.mnuPopupCancel.Text = "キャンセル";
            this.mnuPopupCancel.Click += new System.EventHandler(this.mnuPopupCancel_Click);
            // 
            // cntdelPopup
            // 
            this.cntdelPopup.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cntdelPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPopupDelete,
            this.toolStripSeparator1,
            this.キャンセルToolStripMenuItem});
            this.cntdelPopup.Name = "cntdelPopup";
            this.cntdelPopup.Size = new System.Drawing.Size(211, 90);
            // 
            // mnuPopupDelete
            // 
            this.mnuPopupDelete.Name = "mnuPopupDelete";
            this.mnuPopupDelete.Size = new System.Drawing.Size(210, 40);
            this.mnuPopupDelete.Text = "削除";
            this.mnuPopupDelete.Click += new System.EventHandler(this.mnuPopupDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // キャンセルToolStripMenuItem
            // 
            this.キャンセルToolStripMenuItem.Name = "キャンセルToolStripMenuItem";
            this.キャンセルToolStripMenuItem.Size = new System.Drawing.Size(210, 40);
            this.キャンセルToolStripMenuItem.Text = "キャンセル";
            this.キャンセルToolStripMenuItem.Click += new System.EventHandler(this.mnuPopupCancel_Click);
            // 
            // gpsTimer
            // 
            this.gpsTimer.Interval = 15000;
            this.gpsTimer.Tick += new System.EventHandler(this.gpsTimer_Tick);
            // 
            // messageCheckBox
            // 
            this.messageCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.messageCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.messageCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.messageCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.messageCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_message;
            this.messageCheckBox.Location = new System.Drawing.Point(190, 12);
            this.messageCheckBox.Name = "messageCheckBox";
            this.messageCheckBox.Size = new System.Drawing.Size(80, 64);
            this.messageCheckBox.TabIndex = 3;
            this.messageCheckBox.TabStop = false;
            this.messageCheckBox.UseVisualStyleBackColor = true;
            this.messageCheckBox.CheckedChanged += new System.EventHandler(this.messageCheckBox_CheckedChanged);
            // 
            // textInputCheckBox
            // 
            this.textInputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textInputCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.textInputCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.textInputCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.textInputCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textInputCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_text;
            this.textInputCheckBox.Location = new System.Drawing.Point(276, 12);
            this.textInputCheckBox.Name = "textInputCheckBox";
            this.textInputCheckBox.Size = new System.Drawing.Size(80, 64);
            this.textInputCheckBox.TabIndex = 4;
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
            this.lineInputCheckBox.Location = new System.Drawing.Point(362, 12);
            this.lineInputCheckBox.Name = "lineInputCheckBox";
            this.lineInputCheckBox.Size = new System.Drawing.Size(80, 64);
            this.lineInputCheckBox.TabIndex = 5;
            this.lineInputCheckBox.TabStop = false;
            this.lineInputCheckBox.UseVisualStyleBackColor = true;
            this.lineInputCheckBox.CheckedChanged += new System.EventHandler(this.lineInputCheckBox_CheckedChanged);
            // 
            // freeInputCheckBox
            // 
            this.freeInputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.freeInputCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.freeInputCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.freeInputCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.freeInputCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.freeInputCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_input;
            this.freeInputCheckBox.Location = new System.Drawing.Point(448, 12);
            this.freeInputCheckBox.Name = "freeInputCheckBox";
            this.freeInputCheckBox.Size = new System.Drawing.Size(80, 64);
            this.freeInputCheckBox.TabIndex = 6;
            this.freeInputCheckBox.TabStop = false;
            this.freeInputCheckBox.UseVisualStyleBackColor = true;
            this.freeInputCheckBox.CheckedChanged += new System.EventHandler(this.freeInputCheckBox_CheckedChanged);
            // 
            // gpsCheckBox
            // 
            this.gpsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.gpsCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.gpsCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.gpsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpsCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_gps;
            this.gpsCheckBox.Location = new System.Drawing.Point(708, 12);
            this.gpsCheckBox.Name = "gpsCheckBox";
            this.gpsCheckBox.Size = new System.Drawing.Size(80, 64);
            this.gpsCheckBox.TabIndex = 9;
            this.gpsCheckBox.TabStop = false;
            this.gpsCheckBox.UseVisualStyleBackColor = true;
            this.gpsCheckBox.CheckedChanged += new System.EventHandler(this.gpsCheckBox_CheckedChanged);
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.selectCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.selectCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectCheckBox.Image = global::FukjTabletSystem.Properties.Resources.btn_remove;
            this.selectCheckBox.Location = new System.Drawing.Point(101, 12);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Size = new System.Drawing.Size(80, 64);
            this.selectCheckBox.TabIndex = 2;
            this.selectCheckBox.TabStop = false;
            this.selectCheckBox.UseVisualStyleBackColor = true;
            this.selectCheckBox.CheckedChanged += new System.EventHandler(this.selectCheckBox_CheckedChanged);
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 64);
            this.backButton.TabIndex = 1;
            this.backButton.TabStop = false;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomOutButton.Image = global::FukjTabletSystem.Properties.Resources.btn_zoom_out;
            this.zoomOutButton.Location = new System.Drawing.Point(622, 12);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(80, 64);
            this.zoomOutButton.TabIndex = 8;
            this.zoomOutButton.TabStop = false;
            this.zoomOutButton.UseVisualStyleBackColor = false;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomInButton.Image = global::FukjTabletSystem.Properties.Resources.btn_zoom_in;
            this.zoomInButton.Location = new System.Drawing.Point(536, 12);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(80, 64);
            this.zoomInButton.TabIndex = 7;
            this.zoomInButton.TabStop = false;
            this.zoomInButton.UseVisualStyleBackColor = false;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addressLabel.AutoSize = true;
            this.addressLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addressLabel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addressLabel.Location = new System.Drawing.Point(12, 933);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(94, 20);
            this.addressLabel.TabIndex = 10;
            this.addressLabel.Text = "<不明な住所>";
            // 
            // keidoLabel
            // 
            this.keidoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.keidoLabel.AutoSize = true;
            this.keidoLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.keidoLabel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.keidoLabel.Location = new System.Drawing.Point(112, 933);
            this.keidoLabel.Name = "keidoLabel";
            this.keidoLabel.Size = new System.Drawing.Size(153, 20);
            this.keidoLabel.TabIndex = 11;
            this.keidoLabel.Text = "経度: 000° 00′ 00″ 000";
            // 
            // idoLabel
            // 
            this.idoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.idoLabel.AutoSize = true;
            this.idoLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.idoLabel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.idoLabel.Location = new System.Drawing.Point(271, 933);
            this.idoLabel.Name = "idoLabel";
            this.idoLabel.Size = new System.Drawing.Size(145, 20);
            this.idoLabel.TabIndex = 12;
            this.idoLabel.Text = "緯度: 00° 00′ 00″ 000";
            // 
            // MapWorksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 962);
            this.Controls.Add(this.idoLabel);
            this.Controls.Add(this.keidoLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.messageCheckBox);
            this.Controls.Add(this.textInputCheckBox);
            this.Controls.Add(this.lineInputCheckBox);
            this.Controls.Add(this.freeInputCheckBox);
            this.Controls.Add(this.gpsCheckBox);
            this.Controls.Add(this.selectCheckBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.zoomOutButton);
            this.Controls.Add(this.zoomInButton);
            this.Controls.Add(this.mwView);
            this.Name = "MapWorksForm";
            this.Text = "MapWorksForm";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapWorksForm_FormClosing);
            this.Load += new System.EventHandler(this.MapWorksForm_Load);
            this.Shown += new System.EventHandler(this.MapWorksForm_Shown);
            this.cntmnuPopup.ResumeLayout(false);
            this.cntdelPopup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zynas.Control.ZButton zoomOutButton;
        private Zynas.Control.ZButton zoomInButton;
        private Zynas.Control.ZButton backButton;
        private MapWorks50.MWView mwView;
        private System.Windows.Forms.ContextMenuStrip cntmnuPopup;
        private System.Windows.Forms.ToolStripMenuItem mnuPopupRegister;
        private System.Windows.Forms.ToolStripMenuItem mnuPopupCancel;
        private System.Windows.Forms.CheckBox selectCheckBox;
        private System.Windows.Forms.ContextMenuStrip cntdelPopup;
        private System.Windows.Forms.ToolStripMenuItem mnuPopupDelete;
        private System.Windows.Forms.ToolStripMenuItem キャンセルToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer gpsTimer;
        private System.Windows.Forms.CheckBox gpsCheckBox;
        private System.Windows.Forms.CheckBox freeInputCheckBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox lineInputCheckBox;
        private System.Windows.Forms.CheckBox textInputCheckBox;
        private System.Windows.Forms.CheckBox messageCheckBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label keidoLabel;
        private System.Windows.Forms.Label idoLabel;
    }
}