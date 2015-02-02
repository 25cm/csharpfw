namespace FukjBizSystem.Application.Boundary.Demo
{
    partial class SuishitsuKensaNippoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OutputButton = new System.Windows.Forms.Button();
            this.TojiruButton = new System.Windows.Forms.Button();
            this.NippoOutputButton = new System.Windows.Forms.Button();
            this.GyoshaListPanel = new System.Windows.Forms.Panel();
            this.NippoListDataGridView = new System.Windows.Forms.DataGridView();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.UketsukeDtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.ViewChangeButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.KensakuButton = new System.Windows.Forms.Button();
            this.KakuteiButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.UketsukeHonsuGaikan11joTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeNoGaikan11joToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeNoGaikan11joFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeHonsuSuishitsu11joTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeNoSuishitsu11joToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeNoSuishitsu11joFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeHonsu9joTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeNo9joToTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.UketsukeNo9joFromTextBox = new FukjBizSystem.Control.NumberTextBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AllCheckCheckBox = new System.Windows.Forms.CheckBox();
            this.gyoshaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaShubetsuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kaiingaiFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.genkinFlgCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kensaRyokinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motikomiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shushuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kingkauCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyukingakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kakuninCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RecordTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GyoshaListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NippoListDataGridView)).BeginInit();
            this.SearchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputButton
            // 
            this.OutputButton.Location = new System.Drawing.Point(860, 551);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(101, 37);
            this.OutputButton.TabIndex = 16;
            this.OutputButton.Text = "F6:一覧出力";
            this.OutputButton.UseVisualStyleBackColor = true;
            this.OutputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // TojiruButton
            // 
            this.TojiruButton.Location = new System.Drawing.Point(994, 551);
            this.TojiruButton.Name = "TojiruButton";
            this.TojiruButton.Size = new System.Drawing.Size(101, 37);
            this.TojiruButton.TabIndex = 15;
            this.TojiruButton.Text = "F12:閉じる";
            this.TojiruButton.UseVisualStyleBackColor = true;
            this.TojiruButton.Click += new System.EventHandler(this.TojiruButton_Click);
            // 
            // NippoOutputButton
            // 
            this.NippoOutputButton.Location = new System.Drawing.Point(726, 551);
            this.NippoOutputButton.Name = "NippoOutputButton";
            this.NippoOutputButton.Size = new System.Drawing.Size(101, 37);
            this.NippoOutputButton.TabIndex = 14;
            this.NippoOutputButton.Text = "F2:日報出力";
            this.NippoOutputButton.UseVisualStyleBackColor = true;
            this.NippoOutputButton.Click += new System.EventHandler(this.NippoOutputButton_Click);
            // 
            // GyoshaListPanel
            // 
            this.GyoshaListPanel.Controls.Add(this.groupBox2);
            this.GyoshaListPanel.Controls.Add(this.groupBox1);
            this.GyoshaListPanel.Controls.Add(this.NippoListDataGridView);
            this.GyoshaListPanel.Location = new System.Drawing.Point(0, 75);
            this.GyoshaListPanel.Name = "GyoshaListPanel";
            this.GyoshaListPanel.Size = new System.Drawing.Size(1103, 471);
            this.GyoshaListPanel.TabIndex = 12;
            // 
            // NippoListDataGridView
            // 
            this.NippoListDataGridView.AllowUserToAddRows = false;
            this.NippoListDataGridView.AllowUserToDeleteRows = false;
            this.NippoListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NippoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NippoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gyoshaNmCol,
            this.gyoshaCdCol,
            this.kensaShubetsuCol,
            this.kaiingaiFlgCol,
            this.genkinFlgCol,
            this.kensaRyokinCol,
            this.motikomiCol,
            this.shushuCol,
            this.kingkauCol,
            this.nyukingakuCol,
            this.kakuninCol,
            this.RecordTypeCol});
            this.NippoListDataGridView.Location = new System.Drawing.Point(2, 67);
            this.NippoListDataGridView.Name = "NippoListDataGridView";
            this.NippoListDataGridView.RowHeadersVisible = false;
            this.NippoListDataGridView.RowTemplate.Height = 21;
            this.NippoListDataGridView.Size = new System.Drawing.Size(1100, 401);
            this.NippoListDataGridView.TabIndex = 6;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.UketsukeDtDateTimePicker);
            this.SearchPanel.Controls.Add(this.panel1);
            this.SearchPanel.Controls.Add(this.ViewChangeButton);
            this.SearchPanel.Controls.Add(this.label19);
            this.SearchPanel.Controls.Add(this.label1);
            this.SearchPanel.Controls.Add(this.ClearButton);
            this.SearchPanel.Controls.Add(this.KensakuButton);
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(1103, 74);
            this.SearchPanel.TabIndex = 11;
            // 
            // UketsukeDtDateTimePicker
            // 
            this.UketsukeDtDateTimePicker.Location = new System.Drawing.Point(70, 31);
            this.UketsukeDtDateTimePicker.Name = "UketsukeDtDateTimePicker";
            this.UketsukeDtDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.UketsukeDtDateTimePicker.TabIndex = 73;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(260, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 39);
            this.panel1.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(12, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 41);
            this.label6.TabIndex = 0;
            this.label6.Text = "MockUp";
            // 
            // ViewChangeButton
            // 
            this.ViewChangeButton.Location = new System.Drawing.Point(1071, -1);
            this.ViewChangeButton.Name = "ViewChangeButton";
            this.ViewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.ViewChangeButton.TabIndex = 5;
            this.ViewChangeButton.Text = "▲";
            this.ViewChangeButton.UseVisualStyleBackColor = true;
            this.ViewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 20);
            this.label19.TabIndex = 11;
            this.label19.Text = "受付日";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "検索条件";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(884, 33);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(101, 37);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "F7:クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // KensakuButton
            // 
            this.KensakuButton.Location = new System.Drawing.Point(991, 32);
            this.KensakuButton.Name = "KensakuButton";
            this.KensakuButton.Size = new System.Drawing.Size(101, 37);
            this.KensakuButton.TabIndex = 4;
            this.KensakuButton.Text = "F8:検索";
            this.KensakuButton.UseVisualStyleBackColor = true;
            this.KensakuButton.Click += new System.EventHandler(this.KensakuButton_Click);
            // 
            // KakuteiButton
            // 
            this.KakuteiButton.Location = new System.Drawing.Point(586, 551);
            this.KakuteiButton.Name = "KakuteiButton";
            this.KakuteiButton.Size = new System.Drawing.Size(101, 37);
            this.KakuteiButton.TabIndex = 13;
            this.KakuteiButton.Text = "F1:確定";
            this.KakuteiButton.UseVisualStyleBackColor = true;
            this.KakuteiButton.Click += new System.EventHandler(this.KakuteiButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.UketsukeHonsuGaikan11joTextBox);
            this.groupBox1.Controls.Add(this.UketsukeNoGaikan11joToTextBox);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.UketsukeNoGaikan11joFromTextBox);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.UketsukeHonsuSuishitsu11joTextBox);
            this.groupBox1.Controls.Add(this.UketsukeNoSuishitsu11joToTextBox);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.UketsukeNoSuishitsu11joFromTextBox);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.UketsukeHonsu9joTextBox);
            this.groupBox1.Controls.Add(this.UketsukeNo9joToTextBox);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.UketsukeNo9joFromTextBox);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 56);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "受付No";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(908, 23);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(22, 20);
            this.label29.TabIndex = 120;
            this.label29.Text = "本";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(770, 23);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(22, 20);
            this.label30.TabIndex = 117;
            this.label30.Text = "～";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(634, 23);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 20);
            this.label31.TabIndex = 115;
            this.label31.Text = "外観11条";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(592, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(22, 20);
            this.label26.TabIndex = 114;
            this.label26.Text = "本";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(454, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(22, 20);
            this.label27.TabIndex = 111;
            this.label27.Text = "～";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(318, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 20);
            this.label28.TabIndex = 109;
            this.label28.Text = "水質11条";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(279, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(22, 20);
            this.label25.TabIndex = 108;
            this.label25.Text = "本";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(141, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 20);
            this.label24.TabIndex = 102;
            this.label24.Text = "～";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(13, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 20);
            this.label32.TabIndex = 92;
            this.label32.Text = "9条検査";
            // 
            // UketsukeHonsuGaikan11joTextBox
            // 
            this.UketsukeHonsuGaikan11joTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeHonsuGaikan11joTextBox.CustomDigitParts = 0;
            this.UketsukeHonsuGaikan11joTextBox.CustomFormat = "";
            this.UketsukeHonsuGaikan11joTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeHonsuGaikan11joTextBox.CustomReadOnly = false;
            this.UketsukeHonsuGaikan11joTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeHonsuGaikan11joTextBox.Location = new System.Drawing.Point(865, 20);
            this.UketsukeHonsuGaikan11joTextBox.MaxLength = 6;
            this.UketsukeHonsuGaikan11joTextBox.Name = "UketsukeHonsuGaikan11joTextBox";
            this.UketsukeHonsuGaikan11joTextBox.ReadOnly = true;
            this.UketsukeHonsuGaikan11joTextBox.Size = new System.Drawing.Size(37, 27);
            this.UketsukeHonsuGaikan11joTextBox.TabIndex = 119;
            this.UketsukeHonsuGaikan11joTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeNoGaikan11joToTextBox
            // 
            this.UketsukeNoGaikan11joToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeNoGaikan11joToTextBox.CustomDigitParts = 0;
            this.UketsukeNoGaikan11joToTextBox.CustomFormat = "";
            this.UketsukeNoGaikan11joToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeNoGaikan11joToTextBox.CustomReadOnly = false;
            this.UketsukeNoGaikan11joToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeNoGaikan11joToTextBox.Location = new System.Drawing.Point(798, 20);
            this.UketsukeNoGaikan11joToTextBox.MaxLength = 6;
            this.UketsukeNoGaikan11joToTextBox.Name = "UketsukeNoGaikan11joToTextBox";
            this.UketsukeNoGaikan11joToTextBox.ReadOnly = true;
            this.UketsukeNoGaikan11joToTextBox.Size = new System.Drawing.Size(60, 27);
            this.UketsukeNoGaikan11joToTextBox.TabIndex = 118;
            this.UketsukeNoGaikan11joToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeNoGaikan11joFromTextBox
            // 
            this.UketsukeNoGaikan11joFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeNoGaikan11joFromTextBox.CustomDigitParts = 0;
            this.UketsukeNoGaikan11joFromTextBox.CustomFormat = "";
            this.UketsukeNoGaikan11joFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeNoGaikan11joFromTextBox.CustomReadOnly = false;
            this.UketsukeNoGaikan11joFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeNoGaikan11joFromTextBox.Location = new System.Drawing.Point(704, 20);
            this.UketsukeNoGaikan11joFromTextBox.MaxLength = 6;
            this.UketsukeNoGaikan11joFromTextBox.Name = "UketsukeNoGaikan11joFromTextBox";
            this.UketsukeNoGaikan11joFromTextBox.ReadOnly = true;
            this.UketsukeNoGaikan11joFromTextBox.Size = new System.Drawing.Size(60, 27);
            this.UketsukeNoGaikan11joFromTextBox.TabIndex = 116;
            this.UketsukeNoGaikan11joFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeHonsuSuishitsu11joTextBox
            // 
            this.UketsukeHonsuSuishitsu11joTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeHonsuSuishitsu11joTextBox.CustomDigitParts = 0;
            this.UketsukeHonsuSuishitsu11joTextBox.CustomFormat = "";
            this.UketsukeHonsuSuishitsu11joTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeHonsuSuishitsu11joTextBox.CustomReadOnly = false;
            this.UketsukeHonsuSuishitsu11joTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeHonsuSuishitsu11joTextBox.Location = new System.Drawing.Point(549, 20);
            this.UketsukeHonsuSuishitsu11joTextBox.MaxLength = 6;
            this.UketsukeHonsuSuishitsu11joTextBox.Name = "UketsukeHonsuSuishitsu11joTextBox";
            this.UketsukeHonsuSuishitsu11joTextBox.ReadOnly = true;
            this.UketsukeHonsuSuishitsu11joTextBox.Size = new System.Drawing.Size(37, 27);
            this.UketsukeHonsuSuishitsu11joTextBox.TabIndex = 113;
            this.UketsukeHonsuSuishitsu11joTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeNoSuishitsu11joToTextBox
            // 
            this.UketsukeNoSuishitsu11joToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeNoSuishitsu11joToTextBox.CustomDigitParts = 0;
            this.UketsukeNoSuishitsu11joToTextBox.CustomFormat = "";
            this.UketsukeNoSuishitsu11joToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeNoSuishitsu11joToTextBox.CustomReadOnly = false;
            this.UketsukeNoSuishitsu11joToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeNoSuishitsu11joToTextBox.Location = new System.Drawing.Point(482, 20);
            this.UketsukeNoSuishitsu11joToTextBox.MaxLength = 6;
            this.UketsukeNoSuishitsu11joToTextBox.Name = "UketsukeNoSuishitsu11joToTextBox";
            this.UketsukeNoSuishitsu11joToTextBox.ReadOnly = true;
            this.UketsukeNoSuishitsu11joToTextBox.Size = new System.Drawing.Size(60, 27);
            this.UketsukeNoSuishitsu11joToTextBox.TabIndex = 112;
            this.UketsukeNoSuishitsu11joToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeNoSuishitsu11joFromTextBox
            // 
            this.UketsukeNoSuishitsu11joFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeNoSuishitsu11joFromTextBox.CustomDigitParts = 0;
            this.UketsukeNoSuishitsu11joFromTextBox.CustomFormat = "";
            this.UketsukeNoSuishitsu11joFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeNoSuishitsu11joFromTextBox.CustomReadOnly = false;
            this.UketsukeNoSuishitsu11joFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeNoSuishitsu11joFromTextBox.Location = new System.Drawing.Point(388, 20);
            this.UketsukeNoSuishitsu11joFromTextBox.MaxLength = 6;
            this.UketsukeNoSuishitsu11joFromTextBox.Name = "UketsukeNoSuishitsu11joFromTextBox";
            this.UketsukeNoSuishitsu11joFromTextBox.ReadOnly = true;
            this.UketsukeNoSuishitsu11joFromTextBox.Size = new System.Drawing.Size(60, 27);
            this.UketsukeNoSuishitsu11joFromTextBox.TabIndex = 110;
            this.UketsukeNoSuishitsu11joFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeHonsu9joTextBox
            // 
            this.UketsukeHonsu9joTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeHonsu9joTextBox.CustomDigitParts = 0;
            this.UketsukeHonsu9joTextBox.CustomFormat = "";
            this.UketsukeHonsu9joTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeHonsu9joTextBox.CustomReadOnly = false;
            this.UketsukeHonsu9joTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeHonsu9joTextBox.Location = new System.Drawing.Point(236, 20);
            this.UketsukeHonsu9joTextBox.MaxLength = 6;
            this.UketsukeHonsu9joTextBox.Name = "UketsukeHonsu9joTextBox";
            this.UketsukeHonsu9joTextBox.ReadOnly = true;
            this.UketsukeHonsu9joTextBox.Size = new System.Drawing.Size(37, 27);
            this.UketsukeHonsu9joTextBox.TabIndex = 104;
            this.UketsukeHonsu9joTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeNo9joToTextBox
            // 
            this.UketsukeNo9joToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeNo9joToTextBox.CustomDigitParts = 0;
            this.UketsukeNo9joToTextBox.CustomFormat = "";
            this.UketsukeNo9joToTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeNo9joToTextBox.CustomReadOnly = false;
            this.UketsukeNo9joToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeNo9joToTextBox.Location = new System.Drawing.Point(169, 20);
            this.UketsukeNo9joToTextBox.MaxLength = 6;
            this.UketsukeNo9joToTextBox.Name = "UketsukeNo9joToTextBox";
            this.UketsukeNo9joToTextBox.ReadOnly = true;
            this.UketsukeNo9joToTextBox.Size = new System.Drawing.Size(60, 27);
            this.UketsukeNo9joToTextBox.TabIndex = 103;
            this.UketsukeNo9joToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UketsukeNo9joFromTextBox
            // 
            this.UketsukeNo9joFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.UketsukeNo9joFromTextBox.CustomDigitParts = 0;
            this.UketsukeNo9joFromTextBox.CustomFormat = "";
            this.UketsukeNo9joFromTextBox.CustomInputMode = FukjBizSystem.Control.NumberTextBox.InputMode.Int;
            this.UketsukeNo9joFromTextBox.CustomReadOnly = false;
            this.UketsukeNo9joFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UketsukeNo9joFromTextBox.Location = new System.Drawing.Point(75, 20);
            this.UketsukeNo9joFromTextBox.MaxLength = 6;
            this.UketsukeNo9joFromTextBox.Name = "UketsukeNo9joFromTextBox";
            this.UketsukeNo9joFromTextBox.ReadOnly = true;
            this.UketsukeNo9joFromTextBox.Size = new System.Drawing.Size(60, 27);
            this.UketsukeNo9joFromTextBox.TabIndex = 93;
            this.UketsukeNo9joFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AllCheckCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(967, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 56);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            // 
            // AllCheckCheckBox
            // 
            this.AllCheckCheckBox.Location = new System.Drawing.Point(22, 22);
            this.AllCheckCheckBox.Name = "AllCheckCheckBox";
            this.AllCheckCheckBox.Size = new System.Drawing.Size(80, 24);
            this.AllCheckCheckBox.TabIndex = 1;
            this.AllCheckCheckBox.Text = "全て確認";
            this.AllCheckCheckBox.UseVisualStyleBackColor = true;
            this.AllCheckCheckBox.CheckedChanged += new System.EventHandler(this.AllCheckCheckBox_CheckedChanged);
            // 
            // gyoshaNmCol
            // 
            this.gyoshaNmCol.HeaderText = "事業者名";
            this.gyoshaNmCol.Name = "gyoshaNmCol";
            this.gyoshaNmCol.ReadOnly = true;
            this.gyoshaNmCol.Width = 200;
            // 
            // gyoshaCdCol
            // 
            this.gyoshaCdCol.HeaderText = "コード";
            this.gyoshaCdCol.Name = "gyoshaCdCol";
            this.gyoshaCdCol.ReadOnly = true;
            this.gyoshaCdCol.Width = 75;
            // 
            // kensaShubetsuCol
            // 
            this.kensaShubetsuCol.HeaderText = "検査種別";
            this.kensaShubetsuCol.Name = "kensaShubetsuCol";
            this.kensaShubetsuCol.ReadOnly = true;
            this.kensaShubetsuCol.Width = 200;
            // 
            // kaiingaiFlgCol
            // 
            this.kaiingaiFlgCol.FalseValue = "0";
            this.kaiingaiFlgCol.HeaderText = "会員外";
            this.kaiingaiFlgCol.Name = "kaiingaiFlgCol";
            this.kaiingaiFlgCol.ReadOnly = true;
            this.kaiingaiFlgCol.TrueValue = "1";
            this.kaiingaiFlgCol.Width = 60;
            // 
            // genkinFlgCol
            // 
            this.genkinFlgCol.FalseValue = "0";
            this.genkinFlgCol.HeaderText = "現金";
            this.genkinFlgCol.Name = "genkinFlgCol";
            this.genkinFlgCol.ReadOnly = true;
            this.genkinFlgCol.TrueValue = "1";
            this.genkinFlgCol.Width = 45;
            // 
            // kensaRyokinCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.kensaRyokinCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.kensaRyokinCol.HeaderText = "検査料金";
            this.kensaRyokinCol.Name = "kensaRyokinCol";
            this.kensaRyokinCol.ReadOnly = true;
            this.kensaRyokinCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.kensaRyokinCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.kensaRyokinCol.Width = 90;
            // 
            // motikomiCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.motikomiCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.motikomiCol.HeaderText = "持込";
            this.motikomiCol.Name = "motikomiCol";
            this.motikomiCol.ReadOnly = true;
            this.motikomiCol.Width = 60;
            // 
            // shushuCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.shushuCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.shushuCol.HeaderText = "収集";
            this.shushuCol.Name = "shushuCol";
            this.shushuCol.ReadOnly = true;
            this.shushuCol.Width = 60;
            // 
            // kingkauCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.kingkauCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.kingkauCol.HeaderText = "金額";
            this.kingkauCol.Name = "kingkauCol";
            this.kingkauCol.ReadOnly = true;
            this.kingkauCol.Width = 90;
            // 
            // nyukingakuCol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.nyukingakuCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.nyukingakuCol.HeaderText = "入金額";
            this.nyukingakuCol.Name = "nyukingakuCol";
            this.nyukingakuCol.ReadOnly = true;
            this.nyukingakuCol.Width = 90;
            // 
            // kakuninCol
            // 
            this.kakuninCol.FalseValue = "0";
            this.kakuninCol.HeaderText = "確認";
            this.kakuninCol.Name = "kakuninCol";
            this.kakuninCol.TrueValue = "1";
            this.kakuninCol.Width = 45;
            // 
            // RecordTypeCol
            // 
            this.RecordTypeCol.HeaderText = "データ種別";
            this.RecordTypeCol.Name = "RecordTypeCol";
            this.RecordTypeCol.Visible = false;
            // 
            // SuishitsuKensaNippoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.TojiruButton);
            this.Controls.Add(this.NippoOutputButton);
            this.Controls.Add(this.KakuteiButton);
            this.Controls.Add(this.GyoshaListPanel);
            this.Controls.Add(this.SearchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SuishitsuKensaNippoForm";
            this.Text = "水質検査日報";
            this.GyoshaListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NippoListDataGridView)).EndInit();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.Button TojiruButton;
        private System.Windows.Forms.Button NippoOutputButton;
        private System.Windows.Forms.Panel GyoshaListPanel;
        private System.Windows.Forms.DataGridView NippoListDataGridView;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Button ViewChangeButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button KensakuButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker UketsukeDtDateTimePicker;
        private System.Windows.Forms.Button KakuteiButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label29;
        private Control.NumberTextBox UketsukeHonsuGaikan11joTextBox;
        private Control.NumberTextBox UketsukeNoGaikan11joToTextBox;
        private System.Windows.Forms.Label label30;
        private Control.NumberTextBox UketsukeNoGaikan11joFromTextBox;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label26;
        private Control.NumberTextBox UketsukeHonsuSuishitsu11joTextBox;
        private Control.NumberTextBox UketsukeNoSuishitsu11joToTextBox;
        private System.Windows.Forms.Label label27;
        private Control.NumberTextBox UketsukeNoSuishitsu11joFromTextBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label25;
        private Control.NumberTextBox UketsukeHonsu9joTextBox;
        private Control.NumberTextBox UketsukeNo9joToTextBox;
        private System.Windows.Forms.Label label24;
        private Control.NumberTextBox UketsukeNo9joFromTextBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox AllCheckCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaShubetsuCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kaiingaiFlgCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn genkinFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaRyokinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn motikomiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shushuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kingkauCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyukingakuCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kakuninCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordTypeCol;

    }
}