namespace FukjTabletSystem.Application.Boundary.Kensa.Dialog
{
    partial class ShokenHanteiDialog
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
            this.groupListBox = new System.Windows.Forms.ListBox();
            this.shokenHanteiDataSet = new FukjTabletSystem.Application.Boundary.Kensa.Dialog.ShokenHanteiDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.shokenTextBox = new FukjTabletSystem.Controls.ZTextBox(this.components);
            this.ketteiButton = new Zynas.Control.ZButton(this.components);
            this.koumokuListBox = new System.Windows.Forms.ListBox();
            this.joukyouListBox = new System.Windows.Forms.ListBox();
            this.teidoListBox = new System.Windows.Forms.ListBox();
            this.checkPanel = new System.Windows.Forms.Panel();
            this.renrakuKoujiGyoushaCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuSeisouKaisuuCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuMakerCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuTenkenKaisuuCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuSeisouGyoushaCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuHoshuKeiyakuCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuTenkenGyoushaCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuHokenjoCheckBox = new System.Windows.Forms.CheckBox();
            this.renrakuSecchishaCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hosokuBunButton = new Zynas.Control.ZButton(this.components);
            this.contentsPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokenHanteiDataSet)).BeginInit();
            this.checkPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentsPanel
            // 
            this.contentsPanel.Controls.Add(this.hosokuBunButton);
            this.contentsPanel.Controls.Add(this.checkPanel);
            this.contentsPanel.Controls.Add(this.teidoListBox);
            this.contentsPanel.Controls.Add(this.joukyouListBox);
            this.contentsPanel.Controls.Add(this.koumokuListBox);
            this.contentsPanel.Controls.Add(this.ketteiButton);
            this.contentsPanel.Controls.Add(this.shokenTextBox);
            this.contentsPanel.Controls.Add(this.label6);
            this.contentsPanel.Controls.Add(this.groupListBox);
            this.contentsPanel.Size = new System.Drawing.Size(1094, 559);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Size = new System.Drawing.Size(1094, 50);
            this.topPanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.topPanel.Controls.SetChildIndex(this.closeButton, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(468, 5);
            this.titleLabel.Size = new System.Drawing.Size(159, 36);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "所見自動判定";
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
            // groupListBox
            // 
            this.groupListBox.DataSource = this.shokenHanteiDataSet;
            this.groupListBox.DisplayMember = "TaniSochiGroupMst.TaniSochiGroupNm";
            this.groupListBox.FormattingEnabled = true;
            this.groupListBox.ItemHeight = 24;
            this.groupListBox.Location = new System.Drawing.Point(21, 13);
            this.groupListBox.Name = "groupListBox";
            this.groupListBox.Size = new System.Drawing.Size(233, 268);
            this.groupListBox.TabIndex = 0;
            this.groupListBox.ValueMember = "TaniSochiGroupMst.TaniSochiGroupCd";
            this.groupListBox.SelectedValueChanged += new System.EventHandler(this.groupListBox_SelectedValueChanged);
            // 
            // shokenHanteiDataSet
            // 
            this.shokenHanteiDataSet.DataSetName = "ShokenHanteiDataSet";
            this.shokenHanteiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Green;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 290);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(836, 31);
            this.label6.TabIndex = 4;
            this.label6.Text = "選択された所見";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shokenTextBox
            // 
            this.shokenTextBox.AllowDropDown = false;
            this.shokenTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenTextBox.CustomInputMode = FukjTabletSystem.Controls.ZTextBox.InputMode.None;
            this.shokenTextBox.CustomReadOnly = true;
            this.shokenTextBox.Location = new System.Drawing.Point(21, 322);
            this.shokenTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.shokenTextBox.MaxLength = 40;
            this.shokenTextBox.Multiline = true;
            this.shokenTextBox.Name = "shokenTextBox";
            this.shokenTextBox.ReadOnly = true;
            this.shokenTextBox.Size = new System.Drawing.Size(836, 81);
            this.shokenTextBox.TabIndex = 5;
            this.shokenTextBox.TabStop = false;
            // 
            // ketteiButton
            // 
            this.ketteiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ketteiButton.Location = new System.Drawing.Point(960, 501);
            this.ketteiButton.Name = "ketteiButton";
            this.ketteiButton.Size = new System.Drawing.Size(122, 47);
            this.ketteiButton.TabIndex = 16;
            this.ketteiButton.Text = "決定";
            this.ketteiButton.UseVisualStyleBackColor = true;
            this.ketteiButton.Click += new System.EventHandler(this.ketteiButton_Click);
            // 
            // koumokuListBox
            // 
            this.koumokuListBox.DataSource = this.shokenHanteiDataSet;
            this.koumokuListBox.DisplayMember = "TaniSochiKensaKomokuMst.TaniSochiKensaKomokuNm";
            this.koumokuListBox.FormattingEnabled = true;
            this.koumokuListBox.ItemHeight = 24;
            this.koumokuListBox.Location = new System.Drawing.Point(260, 13);
            this.koumokuListBox.Name = "koumokuListBox";
            this.koumokuListBox.Size = new System.Drawing.Size(233, 268);
            this.koumokuListBox.TabIndex = 1;
            this.koumokuListBox.ValueMember = "TaniSochiKensaKomokuMst.TaniSochiKensaKomokuCd";
            this.koumokuListBox.SelectedValueChanged += new System.EventHandler(this.koumokuListBox_SelectedValueChanged);
            // 
            // joukyouListBox
            // 
            this.joukyouListBox.DataSource = this.shokenHanteiDataSet;
            this.joukyouListBox.DisplayMember = "TaniSochiKensaJokyoMst.TaniSochiKensaJokyoNm";
            this.joukyouListBox.FormattingEnabled = true;
            this.joukyouListBox.ItemHeight = 24;
            this.joukyouListBox.Location = new System.Drawing.Point(499, 13);
            this.joukyouListBox.Name = "joukyouListBox";
            this.joukyouListBox.Size = new System.Drawing.Size(285, 268);
            this.joukyouListBox.TabIndex = 2;
            this.joukyouListBox.ValueMember = "TaniSochiKensaJokyoMst.TaniSochiKensaJokyoCd";
            this.joukyouListBox.SelectedValueChanged += new System.EventHandler(this.joukyouListBox_SelectedValueChanged);
            // 
            // teidoListBox
            // 
            this.teidoListBox.DataSource = this.shokenHanteiDataSet;
            this.teidoListBox.DisplayMember = "TaniSochiKensaJokyoTeidoMst.TaniSochiKensaJokyoTeidoNm";
            this.teidoListBox.FormattingEnabled = true;
            this.teidoListBox.ItemHeight = 24;
            this.teidoListBox.Location = new System.Drawing.Point(790, 13);
            this.teidoListBox.Name = "teidoListBox";
            this.teidoListBox.Size = new System.Drawing.Size(285, 268);
            this.teidoListBox.TabIndex = 3;
            this.teidoListBox.ValueMember = "TaniSochiKensaJokyoTeidoMst.TaniSochiKensaJokyoTeidoCd";
            this.teidoListBox.SelectedValueChanged += new System.EventHandler(this.teidoListBox_SelectedValueChanged);
            // 
            // checkPanel
            // 
            this.checkPanel.Controls.Add(this.renrakuKoujiGyoushaCheckBox);
            this.checkPanel.Controls.Add(this.renrakuSeisouKaisuuCheckBox);
            this.checkPanel.Controls.Add(this.renrakuMakerCheckBox);
            this.checkPanel.Controls.Add(this.renrakuTenkenKaisuuCheckBox);
            this.checkPanel.Controls.Add(this.renrakuSeisouGyoushaCheckBox);
            this.checkPanel.Controls.Add(this.renrakuHoshuKeiyakuCheckBox);
            this.checkPanel.Controls.Add(this.renrakuTenkenGyoushaCheckBox);
            this.checkPanel.Controls.Add(this.renrakuHokenjoCheckBox);
            this.checkPanel.Controls.Add(this.renrakuSecchishaCheckBox);
            this.checkPanel.Controls.Add(this.label1);
            this.checkPanel.Location = new System.Drawing.Point(12, 409);
            this.checkPanel.Name = "checkPanel";
            this.checkPanel.Size = new System.Drawing.Size(856, 147);
            this.checkPanel.TabIndex = 17;
            // 
            // renrakuKoujiGyoushaCheckBox
            // 
            this.renrakuKoujiGyoushaCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuKoujiGyoushaCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuKoujiGyoushaCheckBox.Enabled = false;
            this.renrakuKoujiGyoushaCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuKoujiGyoushaCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuKoujiGyoushaCheckBox.Location = new System.Drawing.Point(570, 41);
            this.renrakuKoujiGyoushaCheckBox.Name = "renrakuKoujiGyoushaCheckBox";
            this.renrakuKoujiGyoushaCheckBox.Size = new System.Drawing.Size(135, 47);
            this.renrakuKoujiGyoushaCheckBox.TabIndex = 21;
            this.renrakuKoujiGyoushaCheckBox.Text = "工事業者";
            this.renrakuKoujiGyoushaCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuKoujiGyoushaCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuSeisouKaisuuCheckBox
            // 
            this.renrakuSeisouKaisuuCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuSeisouKaisuuCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuSeisouKaisuuCheckBox.Enabled = false;
            this.renrakuSeisouKaisuuCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuSeisouKaisuuCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuSeisouKaisuuCheckBox.Location = new System.Drawing.Point(422, 93);
            this.renrakuSeisouKaisuuCheckBox.Name = "renrakuSeisouKaisuuCheckBox";
            this.renrakuSeisouKaisuuCheckBox.Size = new System.Drawing.Size(200, 47);
            this.renrakuSeisouKaisuuCheckBox.TabIndex = 25;
            this.renrakuSeisouKaisuuCheckBox.Text = "清掃回数　要確認";
            this.renrakuSeisouKaisuuCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuSeisouKaisuuCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuMakerCheckBox
            // 
            this.renrakuMakerCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuMakerCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuMakerCheckBox.Enabled = false;
            this.renrakuMakerCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuMakerCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuMakerCheckBox.Location = new System.Drawing.Point(430, 41);
            this.renrakuMakerCheckBox.Name = "renrakuMakerCheckBox";
            this.renrakuMakerCheckBox.Size = new System.Drawing.Size(135, 47);
            this.renrakuMakerCheckBox.TabIndex = 20;
            this.renrakuMakerCheckBox.Text = "メーカー";
            this.renrakuMakerCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuMakerCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuTenkenKaisuuCheckBox
            // 
            this.renrakuTenkenKaisuuCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuTenkenKaisuuCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuTenkenKaisuuCheckBox.Enabled = false;
            this.renrakuTenkenKaisuuCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuTenkenKaisuuCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuTenkenKaisuuCheckBox.Location = new System.Drawing.Point(216, 93);
            this.renrakuTenkenKaisuuCheckBox.Name = "renrakuTenkenKaisuuCheckBox";
            this.renrakuTenkenKaisuuCheckBox.Size = new System.Drawing.Size(200, 47);
            this.renrakuTenkenKaisuuCheckBox.TabIndex = 24;
            this.renrakuTenkenKaisuuCheckBox.Text = "点検回数　要確認";
            this.renrakuTenkenKaisuuCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuTenkenKaisuuCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuSeisouGyoushaCheckBox
            // 
            this.renrakuSeisouGyoushaCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuSeisouGyoushaCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuSeisouGyoushaCheckBox.Enabled = false;
            this.renrakuSeisouGyoushaCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuSeisouGyoushaCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuSeisouGyoushaCheckBox.Location = new System.Drawing.Point(290, 41);
            this.renrakuSeisouGyoushaCheckBox.Name = "renrakuSeisouGyoushaCheckBox";
            this.renrakuSeisouGyoushaCheckBox.Size = new System.Drawing.Size(135, 47);
            this.renrakuSeisouGyoushaCheckBox.TabIndex = 19;
            this.renrakuSeisouGyoushaCheckBox.Text = "清掃業者";
            this.renrakuSeisouGyoushaCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuSeisouGyoushaCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuHoshuKeiyakuCheckBox
            // 
            this.renrakuHoshuKeiyakuCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuHoshuKeiyakuCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuHoshuKeiyakuCheckBox.Enabled = false;
            this.renrakuHoshuKeiyakuCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuHoshuKeiyakuCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuHoshuKeiyakuCheckBox.Location = new System.Drawing.Point(10, 94);
            this.renrakuHoshuKeiyakuCheckBox.Name = "renrakuHoshuKeiyakuCheckBox";
            this.renrakuHoshuKeiyakuCheckBox.Size = new System.Drawing.Size(200, 47);
            this.renrakuHoshuKeiyakuCheckBox.TabIndex = 23;
            this.renrakuHoshuKeiyakuCheckBox.Text = "保守契約　要確認";
            this.renrakuHoshuKeiyakuCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuHoshuKeiyakuCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuTenkenGyoushaCheckBox
            // 
            this.renrakuTenkenGyoushaCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuTenkenGyoushaCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuTenkenGyoushaCheckBox.Enabled = false;
            this.renrakuTenkenGyoushaCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuTenkenGyoushaCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuTenkenGyoushaCheckBox.Location = new System.Drawing.Point(150, 41);
            this.renrakuTenkenGyoushaCheckBox.Name = "renrakuTenkenGyoushaCheckBox";
            this.renrakuTenkenGyoushaCheckBox.Size = new System.Drawing.Size(135, 47);
            this.renrakuTenkenGyoushaCheckBox.TabIndex = 18;
            this.renrakuTenkenGyoushaCheckBox.Text = "点検業者";
            this.renrakuTenkenGyoushaCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuTenkenGyoushaCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuHokenjoCheckBox
            // 
            this.renrakuHokenjoCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuHokenjoCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuHokenjoCheckBox.Enabled = false;
            this.renrakuHokenjoCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuHokenjoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuHokenjoCheckBox.Location = new System.Drawing.Point(710, 41);
            this.renrakuHokenjoCheckBox.Name = "renrakuHokenjoCheckBox";
            this.renrakuHokenjoCheckBox.Size = new System.Drawing.Size(135, 47);
            this.renrakuHokenjoCheckBox.TabIndex = 22;
            this.renrakuHokenjoCheckBox.Text = "保健所等";
            this.renrakuHokenjoCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuHokenjoCheckBox.UseVisualStyleBackColor = false;
            // 
            // renrakuSecchishaCheckBox
            // 
            this.renrakuSecchishaCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.renrakuSecchishaCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.renrakuSecchishaCheckBox.Enabled = false;
            this.renrakuSecchishaCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow;
            this.renrakuSecchishaCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renrakuSecchishaCheckBox.Location = new System.Drawing.Point(9, 41);
            this.renrakuSecchishaCheckBox.Name = "renrakuSecchishaCheckBox";
            this.renrakuSecchishaCheckBox.Size = new System.Drawing.Size(135, 47);
            this.renrakuSecchishaCheckBox.TabIndex = 17;
            this.renrakuSecchishaCheckBox.Text = "設置者";
            this.renrakuSecchishaCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.renrakuSecchishaCheckBox.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(836, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "関係者への連絡事項";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hosokuBunButton
            // 
            this.hosokuBunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hosokuBunButton.Location = new System.Drawing.Point(960, 356);
            this.hosokuBunButton.Name = "hosokuBunButton";
            this.hosokuBunButton.Size = new System.Drawing.Size(122, 47);
            this.hosokuBunButton.TabIndex = 18;
            this.hosokuBunButton.Text = "補足文";
            this.hosokuBunButton.UseVisualStyleBackColor = true;
            this.hosokuBunButton.Click += new System.EventHandler(this.hosokuBunButton_Click);
            // 
            // ShokenHanteiDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1094, 611);
            this.Name = "ShokenHanteiDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "所見自動判定";
            this.Load += new System.EventHandler(this.Form_Load);
            this.contentsPanel.ResumeLayout(false);
            this.contentsPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shokenHanteiDataSet)).EndInit();
            this.checkPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Zynas.Control.ZButton closeButton;
        private System.Windows.Forms.ListBox groupListBox;
        private System.Windows.Forms.Label label6;
        private Controls.ZTextBox shokenTextBox;
        private System.Windows.Forms.ListBox teidoListBox;
        private System.Windows.Forms.ListBox joukyouListBox;
        private System.Windows.Forms.ListBox koumokuListBox;
        private Zynas.Control.ZButton ketteiButton;
        private System.Windows.Forms.Panel checkPanel;
        private System.Windows.Forms.CheckBox renrakuKoujiGyoushaCheckBox;
        private System.Windows.Forms.CheckBox renrakuSeisouKaisuuCheckBox;
        private System.Windows.Forms.CheckBox renrakuMakerCheckBox;
        private System.Windows.Forms.CheckBox renrakuTenkenKaisuuCheckBox;
        private System.Windows.Forms.CheckBox renrakuSeisouGyoushaCheckBox;
        private System.Windows.Forms.CheckBox renrakuHoshuKeiyakuCheckBox;
        private System.Windows.Forms.CheckBox renrakuTenkenGyoushaCheckBox;
        private System.Windows.Forms.CheckBox renrakuHokenjoCheckBox;
        private System.Windows.Forms.CheckBox renrakuSecchishaCheckBox;
        private System.Windows.Forms.Label label1;
        private Zynas.Control.ZButton hosokuBunButton;
        private ShokenHanteiDataSet shokenHanteiDataSet;
    }
}