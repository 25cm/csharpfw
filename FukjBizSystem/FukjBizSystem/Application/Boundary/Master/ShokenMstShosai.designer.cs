using FukjBizSystem.Control;
namespace FukjBizSystem.Application.Boundary.Master
{
    partial class ShokenMstShosaiForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.shokenWdRyakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.shokenFollowFlgCheckBox = new System.Windows.Forms.CheckBox();
            this.shokenTaishoKensaBitMaskComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.shokenYusendoComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.shokenCheckHandanCombobox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.shokenCheckNoTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokenCdTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokenKbnTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.shokenCheckNoNmComboBox = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.gyoseiHokokuLevelComboBox = new System.Windows.Forms.ComboBox();
            this.shokenHanteiComboBox = new System.Windows.Forms.ComboBox();
            this.shokenHandanComboBox = new System.Windows.Forms.ComboBox();
            this.shokenShitekiKashoComboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.shokenShitekiKbnComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.shokenBikoTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.shokenBunshoTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.shokenKbnNmComboBox = new System.Windows.Forms.ComboBox();
            this.shokenJuyodoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.entryButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.decisionButton = new System.Windows.Forms.Button();
            this.reInputButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "所見区分";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.shokenWdRyakuTextBox);
            this.mainPanel.Controls.Add(this.label22);
            this.mainPanel.Controls.Add(this.shokenFollowFlgCheckBox);
            this.mainPanel.Controls.Add(this.shokenTaishoKensaBitMaskComboBox);
            this.mainPanel.Controls.Add(this.label20);
            this.mainPanel.Controls.Add(this.shokenYusendoComboBox);
            this.mainPanel.Controls.Add(this.label18);
            this.mainPanel.Controls.Add(this.shokenCheckHandanCombobox);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.shokenCheckNoTextBox);
            this.mainPanel.Controls.Add(this.shokenCdTextBox);
            this.mainPanel.Controls.Add(this.shokenKbnTextBox);
            this.mainPanel.Controls.Add(this.shokenCheckNoNmComboBox);
            this.mainPanel.Controls.Add(this.label23);
            this.mainPanel.Controls.Add(this.gyoseiHokokuLevelComboBox);
            this.mainPanel.Controls.Add(this.shokenHanteiComboBox);
            this.mainPanel.Controls.Add(this.shokenHandanComboBox);
            this.mainPanel.Controls.Add(this.shokenShitekiKashoComboBox);
            this.mainPanel.Controls.Add(this.label21);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.shokenShitekiKbnComboBox);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.shokenBikoTextBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.label10);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.shokenBunshoTextBox);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.shokenKbnNmComboBox);
            this.mainPanel.Controls.Add(this.shokenJuyodoComboBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.changeButton);
            this.mainPanel.Controls.Add(this.decisionButton);
            this.mainPanel.Controls.Add(this.reInputButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1091, 593);
            this.mainPanel.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(69, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "所見略文";
            // 
            // shokenWdRyakuTextBox
            // 
            this.shokenWdRyakuTextBox.AllowDropDown = false;
            this.shokenWdRyakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenWdRyakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shokenWdRyakuTextBox.CustomReadOnly = false;
            this.shokenWdRyakuTextBox.Location = new System.Drawing.Point(103, 344);
            this.shokenWdRyakuTextBox.MaxLength = 250;
            this.shokenWdRyakuTextBox.Multiline = true;
            this.shokenWdRyakuTextBox.Name = "shokenWdRyakuTextBox";
            this.shokenWdRyakuTextBox.Size = new System.Drawing.Size(672, 66);
            this.shokenWdRyakuTextBox.TabIndex = 34;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(220, 211);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(126, 20);
            this.label22.TabIndex = 26;
            this.label22.Text = "フォロー対象フラグ";
            // 
            // shokenFollowFlgCheckBox
            // 
            this.shokenFollowFlgCheckBox.AutoSize = true;
            this.shokenFollowFlgCheckBox.Location = new System.Drawing.Point(352, 215);
            this.shokenFollowFlgCheckBox.Name = "shokenFollowFlgCheckBox";
            this.shokenFollowFlgCheckBox.Size = new System.Drawing.Size(15, 14);
            this.shokenFollowFlgCheckBox.TabIndex = 27;
            this.shokenFollowFlgCheckBox.UseVisualStyleBackColor = true;
            // 
            // shokenTaishoKensaBitMaskComboBox
            // 
            this.shokenTaishoKensaBitMaskComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenTaishoKensaBitMaskComboBox.FormattingEnabled = true;
            this.shokenTaishoKensaBitMaskComboBox.Location = new System.Drawing.Point(482, 208);
            this.shokenTaishoKensaBitMaskComboBox.Name = "shokenTaishoKensaBitMaskComboBox";
            this.shokenTaishoKensaBitMaskComboBox.Size = new System.Drawing.Size(200, 28);
            this.shokenTaishoKensaBitMaskComboBox.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(403, 211);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 20);
            this.label20.TabIndex = 28;
            this.label20.Text = "対象検査";
            // 
            // shokenYusendoComboBox
            // 
            this.shokenYusendoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenYusendoComboBox.FormattingEnabled = true;
            this.shokenYusendoComboBox.Location = new System.Drawing.Point(428, 92);
            this.shokenYusendoComboBox.Name = "shokenYusendoComboBox";
            this.shokenYusendoComboBox.Size = new System.Drawing.Size(56, 28);
            this.shokenYusendoComboBox.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(324, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 20);
            this.label18.TabIndex = 11;
            this.label18.Text = "表記順優先度";
            // 
            // shokenCheckHandanCombobox
            // 
            this.shokenCheckHandanCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenCheckHandanCombobox.FormattingEnabled = true;
            this.shokenCheckHandanCombobox.Location = new System.Drawing.Point(131, 208);
            this.shokenCheckHandanCombobox.Name = "shokenCheckHandanCombobox";
            this.shokenCheckHandanCombobox.Size = new System.Drawing.Size(56, 28);
            this.shokenCheckHandanCombobox.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "同時チェック判断";
            // 
            // shokenCheckNoTextBox
            // 
            this.shokenCheckNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenCheckNoTextBox.CustomDigitParts = 0;
            this.shokenCheckNoTextBox.CustomFormat = null;
            this.shokenCheckNoTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokenCheckNoTextBox.CustomReadOnly = false;
            this.shokenCheckNoTextBox.Location = new System.Drawing.Point(131, 171);
            this.shokenCheckNoTextBox.MaxLength = 3;
            this.shokenCheckNoTextBox.Name = "shokenCheckNoTextBox";
            this.shokenCheckNoTextBox.Size = new System.Drawing.Size(45, 27);
            this.shokenCheckNoTextBox.TabIndex = 22;
            //this.shokenCheckNoTextBox.TextChanged += new System.EventHandler(this.shokenCheckNoTextBox_TextChanged);
            this.shokenCheckNoTextBox.Leave += new System.EventHandler(this.shokenCheckNoTextBox_Leave);
            // 
            // shokenCdTextBox
            // 
            this.shokenCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenCdTextBox.CustomDigitParts = 0;
            this.shokenCdTextBox.CustomFormat = null;
            this.shokenCdTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokenCdTextBox.CustomReadOnly = false;
            this.shokenCdTextBox.Location = new System.Drawing.Point(103, 54);
            this.shokenCdTextBox.MaxLength = 3;
            this.shokenCdTextBox.Name = "shokenCdTextBox";
            this.shokenCdTextBox.Size = new System.Drawing.Size(45, 27);
            this.shokenCdTextBox.TabIndex = 6;
            this.shokenCdTextBox.Leave += new System.EventHandler(this.shokenCdTextBox_Leave);
            // 
            // shokenKbnTextBox
            // 
            this.shokenKbnTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shokenKbnTextBox.CustomDigitParts = 0;
            this.shokenKbnTextBox.CustomFormat = null;
            this.shokenKbnTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.PositiveInt;
            this.shokenKbnTextBox.CustomReadOnly = false;
            this.shokenKbnTextBox.Location = new System.Drawing.Point(103, 21);
            this.shokenKbnTextBox.MaxLength = 3;
            this.shokenKbnTextBox.Name = "shokenKbnTextBox";
            this.shokenKbnTextBox.Size = new System.Drawing.Size(45, 27);
            this.shokenKbnTextBox.TabIndex = 2;
            this.shokenKbnTextBox.Leave += new System.EventHandler(this.shokenKbnTextBox_Leave);
            // 
            // shokenCheckNoNmComboBox
            // 
            this.shokenCheckNoNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenCheckNoNmComboBox.FormattingEnabled = true;
            this.shokenCheckNoNmComboBox.Location = new System.Drawing.Point(182, 170);
            this.shokenCheckNoNmComboBox.Name = "shokenCheckNoNmComboBox";
            this.shokenCheckNoNmComboBox.Size = new System.Drawing.Size(500, 28);
            this.shokenCheckNoNmComboBox.TabIndex = 23;
            this.shokenCheckNoNmComboBox.SelectedIndexChanged += new System.EventHandler(this.shokenCheckNoNmComboBox_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 174);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 20);
            this.label23.TabIndex = 21;
            this.label23.Text = "同時チェック番号";
            // 
            // gyoseiHokokuLevelComboBox
            // 
            this.gyoseiHokokuLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gyoseiHokokuLevelComboBox.FormattingEnabled = true;
            this.gyoseiHokokuLevelComboBox.Location = new System.Drawing.Point(374, 131);
            this.gyoseiHokokuLevelComboBox.Name = "gyoseiHokokuLevelComboBox";
            this.gyoseiHokokuLevelComboBox.Size = new System.Drawing.Size(56, 28);
            this.gyoseiHokokuLevelComboBox.TabIndex = 18;
            // 
            // shokenHanteiComboBox
            // 
            this.shokenHanteiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenHanteiComboBox.FormattingEnabled = true;
            this.shokenHanteiComboBox.Location = new System.Drawing.Point(573, 92);
            this.shokenHanteiComboBox.Name = "shokenHanteiComboBox";
            this.shokenHanteiComboBox.Size = new System.Drawing.Size(141, 28);
            this.shokenHanteiComboBox.TabIndex = 14;
            // 
            // shokenHandanComboBox
            // 
            this.shokenHandanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenHandanComboBox.FormattingEnabled = true;
            this.shokenHandanComboBox.Location = new System.Drawing.Point(239, 92);
            this.shokenHandanComboBox.Name = "shokenHandanComboBox";
            this.shokenHandanComboBox.Size = new System.Drawing.Size(56, 28);
            this.shokenHandanComboBox.TabIndex = 10;
            // 
            // shokenShitekiKashoComboBox
            // 
            this.shokenShitekiKashoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenShitekiKashoComboBox.FormattingEnabled = true;
            this.shokenShitekiKashoComboBox.Location = new System.Drawing.Point(546, 131);
            this.shokenShitekiKashoComboBox.Name = "shokenShitekiKashoComboBox";
            this.shokenShitekiKashoComboBox.Size = new System.Drawing.Size(200, 28);
            this.shokenShitekiKashoComboBox.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(467, 134);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 20);
            this.label21.TabIndex = 19;
            this.label21.Text = "指摘箇所";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(255, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 20);
            this.label19.TabIndex = 17;
            this.label19.Text = "行政報告レベル";
            // 
            // shokenShitekiKbnComboBox
            // 
            this.shokenShitekiKbnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenShitekiKbnComboBox.FormattingEnabled = true;
            this.shokenShitekiKbnComboBox.Location = new System.Drawing.Point(103, 131);
            this.shokenShitekiKbnComboBox.Name = "shokenShitekiKbnComboBox";
            this.shokenShitekiKbnComboBox.Size = new System.Drawing.Size(121, 28);
            this.shokenShitekiKbnComboBox.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 134);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 20);
            this.label17.TabIndex = 15;
            this.label17.Text = "指摘区分";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 432);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 20);
            this.label15.TabIndex = 35;
            this.label15.Text = "備考";
            // 
            // shokenBikoTextBox
            // 
            this.shokenBikoTextBox.Location = new System.Drawing.Point(103, 428);
            this.shokenBikoTextBox.MaxLength = 250;
            this.shokenBikoTextBox.Multiline = true;
            this.shokenBikoTextBox.Name = "shokenBikoTextBox";
            this.shokenBikoTextBox.Size = new System.Drawing.Size(672, 107);
            this.shokenBikoTextBox.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(520, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 13;
            this.label13.Text = "判定";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(68, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "所見文章";
            // 
            // shokenBunshoTextBox
            // 
            this.shokenBunshoTextBox.Location = new System.Drawing.Point(103, 247);
            this.shokenBunshoTextBox.MaxLength = 160;
            this.shokenBunshoTextBox.Multiline = true;
            this.shokenBunshoTextBox.Name = "shokenBunshoTextBox";
            this.shokenBunshoTextBox.Size = new System.Drawing.Size(672, 80);
            this.shokenBunshoTextBox.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "判断";
            // 
            // shokenKbnNmComboBox
            // 
            this.shokenKbnNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenKbnNmComboBox.FormattingEnabled = true;
            this.shokenKbnNmComboBox.Location = new System.Drawing.Point(154, 20);
            this.shokenKbnNmComboBox.Name = "shokenKbnNmComboBox";
            this.shokenKbnNmComboBox.Size = new System.Drawing.Size(500, 28);
            this.shokenKbnNmComboBox.TabIndex = 3;
            this.shokenKbnNmComboBox.SelectedIndexChanged += new System.EventHandler(this.shokenKbnNmComboBox_SelectedIndexChanged);
            // 
            // shokenJuyodoComboBox
            // 
            this.shokenJuyodoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shokenJuyodoComboBox.FormattingEnabled = true;
            this.shokenJuyodoComboBox.Location = new System.Drawing.Point(103, 92);
            this.shokenJuyodoComboBox.Name = "shokenJuyodoComboBox";
            this.shokenJuyodoComboBox.Size = new System.Drawing.Size(56, 28);
            this.shokenJuyodoComboBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(80, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "所見コード";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(68, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "重要度";
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(421, 553);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 37;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.entryButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(528, 553);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(101, 37);
            this.changeButton.TabIndex = 38;
            this.changeButton.Text = "F2:変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.Location = new System.Drawing.Point(849, 553);
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(101, 37);
            this.decisionButton.TabIndex = 41;
            this.decisionButton.Text = "F5:確定";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.decisionButton_Click);
            // 
            // reInputButton
            // 
            this.reInputButton.Location = new System.Drawing.Point(742, 553);
            this.reInputButton.Name = "reInputButton";
            this.reInputButton.Size = new System.Drawing.Size(101, 37);
            this.reInputButton.TabIndex = 40;
            this.reInputButton.Text = "F4:再入力";
            this.reInputButton.UseVisualStyleBackColor = true;
            this.reInputButton.Click += new System.EventHandler(this.reInputButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(635, 553);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 39;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(991, 553);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 42;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ShokenMstShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShokenMstShosaiForm";
            this.Text = "所見マスタ登録";
            this.Load += new System.EventHandler(this.ShokenMstShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShokenMstShosai_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button decisionButton;
        private System.Windows.Forms.Button reInputButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox shokenJuyodoComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox shokenKbnNmComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox shokenBunshoTextBox;
        private System.Windows.Forms.ComboBox shokenShitekiKashoComboBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox shokenShitekiKbnComboBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox shokenBikoTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox gyoseiHokokuLevelComboBox;
        private System.Windows.Forms.ComboBox shokenHanteiComboBox;
        private System.Windows.Forms.ComboBox shokenHandanComboBox;
        private System.Windows.Forms.ComboBox shokenCheckNoNmComboBox;
        private System.Windows.Forms.Label label23;
        private Control.NumberTextBox shokenKbnTextBox;
        private Control.NumberTextBox shokenCdTextBox;
        private Control.NumberTextBox shokenCheckNoTextBox;
        private System.Windows.Forms.ComboBox shokenCheckHandanCombobox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox shokenYusendoComboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox shokenFollowFlgCheckBox;
        private System.Windows.Forms.ComboBox shokenTaishoKensaBitMaskComboBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private ZTextBox shokenWdRyakuTextBox;
        private System.Windows.Forms.Label label8;
    }
}