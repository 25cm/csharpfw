using FukjBizSystem.Control;
using Zynas.Control.ZDataGridView;
namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class SeikyuShosaiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.telNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.adrTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.zipNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.seikyusakiNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.settishaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.seikyuYMTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.seikyuPrintLbl = new System.Windows.Forms.Label();
            this.kojinRadioButton = new System.Windows.Forms.RadioButton();
            this.gyoshaRadioButton = new System.Windows.Forms.RadioButton();
            this.gyoshaCdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.seikyuTotalTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.meisaiDelButton = new System.Windows.Forms.Button();
            this.meisaishoButton = new System.Windows.Forms.Button();
            this.seikyushoButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.seikyuDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.meisaiAddButton = new System.Windows.Forms.Button();
            this.seikyuNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.seikyuListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.seikyusakiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuKamokuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syohinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suryoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tankaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kingakuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syohizeiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyukinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kansaiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuKomokuKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kazeiFlagCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torokuNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torokuDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torokuTanmatsuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seikyuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shishoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changedFlgCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeikyuRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "請求先";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(520, 543);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(101, 37);
            this.updateButton.TabIndex = 29;
            this.updateButton.Text = "F2:更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(627, 543);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 30;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.telNoTextBox);
            this.mainPanel.Controls.Add(this.adrTextBox);
            this.mainPanel.Controls.Add(this.zipNoTextBox);
            this.mainPanel.Controls.Add(this.seikyusakiNmTextBox);
            this.mainPanel.Controls.Add(this.settishaNmTextBox);
            this.mainPanel.Controls.Add(this.gyoshaNmTextBox);
            this.mainPanel.Controls.Add(this.seikyuYMTextBox);
            this.mainPanel.Controls.Add(this.seikyuPrintLbl);
            this.mainPanel.Controls.Add(this.kojinRadioButton);
            this.mainPanel.Controls.Add(this.gyoshaRadioButton);
            this.mainPanel.Controls.Add(this.gyoshaCdTextBox);
            this.mainPanel.Controls.Add(this.seikyuTotalTextBox);
            this.mainPanel.Controls.Add(this.meisaiDelButton);
            this.mainPanel.Controls.Add(this.meisaishoButton);
            this.mainPanel.Controls.Add(this.seikyushoButton);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.seikyuDtDateTimePicker);
            this.mainPanel.Controls.Add(this.label20);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.meisaiAddButton);
            this.mainPanel.Controls.Add(this.seikyuNoTextBox);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.seikyuListDataGridView);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.label101);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.updateButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // telNoTextBox
            // 
            this.telNoTextBox.AllowDropDown = false;
            this.telNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZG_TEL_NO;
            this.telNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.ZipCdTelNo;
            this.telNoTextBox.CustomReadOnly = false;
            this.telNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.telNoTextBox.Location = new System.Drawing.Point(103, 218);
            this.telNoTextBox.MaxLength = 13;
            this.telNoTextBox.Name = "telNoTextBox";
            this.telNoTextBox.Size = new System.Drawing.Size(185, 27);
            this.telNoTextBox.TabIndex = 19;
            // 
            // adrTextBox
            // 
            this.adrTextBox.AllowDropDown = false;
            this.adrTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_ADR;
            this.adrTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.adrTextBox.CustomReadOnly = false;
            this.adrTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.adrTextBox.Location = new System.Drawing.Point(105, 186);
            this.adrTextBox.MaxLength = 80;
            this.adrTextBox.Name = "adrTextBox";
            this.adrTextBox.Size = new System.Drawing.Size(403, 27);
            this.adrTextBox.TabIndex = 17;
            // 
            // zipNoTextBox
            // 
            this.zipNoTextBox.AllowDropDown = false;
            this.zipNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZG_ZIP_CD;
            this.zipNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.ZipCdTelNo;
            this.zipNoTextBox.CustomReadOnly = false;
            this.zipNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.zipNoTextBox.Location = new System.Drawing.Point(105, 152);
            this.zipNoTextBox.MaxLength = 8;
            this.zipNoTextBox.Name = "zipNoTextBox";
            this.zipNoTextBox.Size = new System.Drawing.Size(78, 27);
            this.zipNoTextBox.TabIndex = 13;
            // 
            // seikyusakiNmTextBox
            // 
            this.seikyusakiNmTextBox.AllowDropDown = false;
            this.seikyusakiNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.seikyusakiNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.seikyusakiNmTextBox.CustomReadOnly = false;
            this.seikyusakiNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.seikyusakiNmTextBox.Location = new System.Drawing.Point(105, 119);
            this.seikyusakiNmTextBox.MaxLength = 60;
            this.seikyusakiNmTextBox.Name = "seikyusakiNmTextBox";
            this.seikyusakiNmTextBox.Size = new System.Drawing.Size(403, 27);
            this.seikyusakiNmTextBox.TabIndex = 11;
            // 
            // settishaNmTextBox
            // 
            this.settishaNmTextBox.AllowDropDown = false;
            this.settishaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.settishaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settishaNmTextBox.CustomReadOnly = true;
            this.settishaNmTextBox.Enabled = false;
            this.settishaNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.settishaNmTextBox.Location = new System.Drawing.Point(103, 77);
            this.settishaNmTextBox.MaxLength = 60;
            this.settishaNmTextBox.Name = "settishaNmTextBox";
            this.settishaNmTextBox.ReadOnly = true;
            this.settishaNmTextBox.Size = new System.Drawing.Size(405, 27);
            this.settishaNmTextBox.TabIndex = 8;
            this.settishaNmTextBox.TabStop = false;
            // 
            // gyoshaNmTextBox
            // 
            this.gyoshaNmTextBox.AllowDropDown = false;
            this.gyoshaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.gyoshaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaNmTextBox.CustomReadOnly = true;
            this.gyoshaNmTextBox.Enabled = false;
            this.gyoshaNmTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.gyoshaNmTextBox.Location = new System.Drawing.Point(156, 47);
            this.gyoshaNmTextBox.MaxLength = 40;
            this.gyoshaNmTextBox.Name = "gyoshaNmTextBox";
            this.gyoshaNmTextBox.ReadOnly = true;
            this.gyoshaNmTextBox.Size = new System.Drawing.Size(407, 27);
            this.gyoshaNmTextBox.TabIndex = 6;
            this.gyoshaNmTextBox.TabStop = false;
            // 
            // seikyuYMTextBox
            // 
            this.seikyuYMTextBox.AllowDropDown = false;
            this.seikyuYMTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NAME;
            this.seikyuYMTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.seikyuYMTextBox.CustomReadOnly = true;
            this.seikyuYMTextBox.Enabled = false;
            this.seikyuYMTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.seikyuYMTextBox.Location = new System.Drawing.Point(317, 14);
            this.seikyuYMTextBox.MaxLength = 7;
            this.seikyuYMTextBox.Name = "seikyuYMTextBox";
            this.seikyuYMTextBox.ReadOnly = true;
            this.seikyuYMTextBox.Size = new System.Drawing.Size(89, 27);
            this.seikyuYMTextBox.TabIndex = 3;
            this.seikyuYMTextBox.TabStop = false;
            // 
            // seikyuPrintLbl
            // 
            this.seikyuPrintLbl.AutoSize = true;
            this.seikyuPrintLbl.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.seikyuPrintLbl.ForeColor = System.Drawing.Color.Red;
            this.seikyuPrintLbl.Location = new System.Drawing.Point(880, 8);
            this.seikyuPrintLbl.Name = "seikyuPrintLbl";
            this.seikyuPrintLbl.Size = new System.Drawing.Size(180, 41);
            this.seikyuPrintLbl.TabIndex = 27;
            this.seikyuPrintLbl.Text = "請求書印刷済";
            // 
            // kojinRadioButton
            // 
            this.kojinRadioButton.AutoSize = true;
            this.kojinRadioButton.Enabled = false;
            this.kojinRadioButton.Location = new System.Drawing.Point(12, 78);
            this.kojinRadioButton.Name = "kojinRadioButton";
            this.kojinRadioButton.Size = new System.Drawing.Size(66, 24);
            this.kojinRadioButton.TabIndex = 7;
            this.kojinRadioButton.Text = "設置者";
            this.kojinRadioButton.UseVisualStyleBackColor = true;
            // 
            // gyoshaRadioButton
            // 
            this.gyoshaRadioButton.AutoSize = true;
            this.gyoshaRadioButton.Checked = true;
            this.gyoshaRadioButton.Enabled = false;
            this.gyoshaRadioButton.Location = new System.Drawing.Point(12, 48);
            this.gyoshaRadioButton.Name = "gyoshaRadioButton";
            this.gyoshaRadioButton.Size = new System.Drawing.Size(53, 24);
            this.gyoshaRadioButton.TabIndex = 4;
            this.gyoshaRadioButton.TabStop = true;
            this.gyoshaRadioButton.Text = "業者";
            this.gyoshaRadioButton.UseVisualStyleBackColor = true;
            // 
            // gyoshaCdTextBox
            // 
            this.gyoshaCdTextBox.AllowDropDown = false;
            this.gyoshaCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_GYOSHA_CD;
            this.gyoshaCdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaCdTextBox.CustomReadOnly = true;
            this.gyoshaCdTextBox.Enabled = false;
            this.gyoshaCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gyoshaCdTextBox.Location = new System.Drawing.Point(103, 47);
            this.gyoshaCdTextBox.MaxLength = 4;
            this.gyoshaCdTextBox.Name = "gyoshaCdTextBox";
            this.gyoshaCdTextBox.ReadOnly = true;
            this.gyoshaCdTextBox.Size = new System.Drawing.Size(47, 27);
            this.gyoshaCdTextBox.TabIndex = 5;
            this.gyoshaCdTextBox.TabStop = false;
            this.gyoshaCdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seikyuTotalTextBox
            // 
            this.seikyuTotalTextBox.AllowDropDown = false;
            this.seikyuTotalTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.seikyuTotalTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.Number;
            this.seikyuTotalTextBox.CustomReadOnly = true;
            this.seikyuTotalTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.seikyuTotalTextBox.Location = new System.Drawing.Point(959, 253);
            this.seikyuTotalTextBox.MaxLength = 10;
            this.seikyuTotalTextBox.Name = "seikyuTotalTextBox";
            this.seikyuTotalTextBox.ReadOnly = true;
            this.seikyuTotalTextBox.Size = new System.Drawing.Size(129, 27);
            this.seikyuTotalTextBox.TabIndex = 26;
            this.seikyuTotalTextBox.TabStop = false;
            this.seikyuTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // meisaiDelButton
            // 
            this.meisaiDelButton.Location = new System.Drawing.Point(734, 248);
            this.meisaiDelButton.Name = "meisaiDelButton";
            this.meisaiDelButton.Size = new System.Drawing.Size(101, 37);
            this.meisaiDelButton.TabIndex = 24;
            this.meisaiDelButton.Text = "F9:明細削除";
            this.meisaiDelButton.UseVisualStyleBackColor = true;
            this.meisaiDelButton.Click += new System.EventHandler(this.meisaiDelButton_Click);
            // 
            // meisaishoButton
            // 
            this.meisaishoButton.Location = new System.Drawing.Point(853, 543);
            this.meisaishoButton.Name = "meisaishoButton";
            this.meisaishoButton.Size = new System.Drawing.Size(101, 37);
            this.meisaishoButton.TabIndex = 32;
            this.meisaishoButton.Text = "F7:明細書";
            this.meisaishoButton.UseVisualStyleBackColor = true;
            this.meisaishoButton.Click += new System.EventHandler(this.meisaishoButton_Click);
            // 
            // seikyushoButton
            // 
            this.seikyushoButton.Location = new System.Drawing.Point(746, 543);
            this.seikyushoButton.Name = "seikyushoButton";
            this.seikyushoButton.Size = new System.Drawing.Size(101, 37);
            this.seikyushoButton.TabIndex = 31;
            this.seikyushoButton.Text = "F６:請求書";
            this.seikyushoButton.UseVisualStyleBackColor = true;
            this.seikyushoButton.Click += new System.EventHandler(this.seikyushoButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 256);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 20);
            this.label19.TabIndex = 20;
            this.label19.Text = "請求日";
            // 
            // seikyuDtDateTimePicker
            // 
            this.seikyuDtDateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.seikyuDtDateTimePicker.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.seikyuDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seikyuDtDateTimePicker.Location = new System.Drawing.Point(105, 251);
            this.seikyuDtDateTimePicker.Name = "seikyuDtDateTimePicker";
            this.seikyuDtDateTimePicker.Size = new System.Drawing.Size(113, 27);
            this.seikyuDtDateTimePicker.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(82, 256);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 20);
            this.label20.TabIndex = 21;
            this.label20.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(82, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 20);
            this.label14.TabIndex = 15;
            this.label14.Text = "住所";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(189, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "例)870-0001 (半角)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "郵便番号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "請求年月";
            // 
            // meisaiAddButton
            // 
            this.meisaiAddButton.Location = new System.Drawing.Point(627, 248);
            this.meisaiAddButton.Name = "meisaiAddButton";
            this.meisaiAddButton.Size = new System.Drawing.Size(101, 37);
            this.meisaiAddButton.TabIndex = 23;
            this.meisaiAddButton.Text = "F8:明細追加";
            this.meisaiAddButton.UseVisualStyleBackColor = true;
            this.meisaiAddButton.Click += new System.EventHandler(this.meisaiAddButton_Click);
            // 
            // seikyuNoTextBox
            // 
            this.seikyuNoTextBox.AllowDropDown = false;
            this.seikyuNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_CD;
            this.seikyuNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.seikyuNoTextBox.CustomReadOnly = false;
            this.seikyuNoTextBox.Enabled = false;
            this.seikyuNoTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.seikyuNoTextBox.Location = new System.Drawing.Point(103, 14);
            this.seikyuNoTextBox.MaxLength = 8;
            this.seikyuNoTextBox.Name = "seikyuNoTextBox";
            this.seikyuNoTextBox.ReadOnly = true;
            this.seikyuNoTextBox.Size = new System.Drawing.Size(98, 27);
            this.seikyuNoTextBox.TabIndex = 1;
            this.seikyuNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "請求No";
            // 
            // seikyuListDataGridView
            // 
            this.seikyuListDataGridView.AllowUserToAddRows = false;
            this.seikyuListDataGridView.AllowUserToDeleteRows = false;
            this.seikyuListDataGridView.AllowUserToResizeRows = false;
            this.seikyuListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seikyuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.seikyuListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seikyusakiCol,
            this.renbanCol,
            this.shishoNmCol,
            this.seikyuKamokuCol,
            this.syohinCol,
            this.suryoCol,
            this.tankaCol,
            this.kingakuCol,
            this.syohizeiCol,
            this.totalCol,
            this.nyukinCol,
            this.kansaiCol,
            this.seikyuKomokuKbnCol,
            this.kazeiFlagCol,
            this.torokuNmCol,
            this.torokuDtCol,
            this.torokuTanmatsuCol,
            this.seikyuNoCol,
            this.shishoCdCol,
            this.changedFlgCol,
            this.SeikyuRenbanCol});
            this.seikyuListDataGridView.Location = new System.Drawing.Point(8, 296);
            this.seikyuListDataGridView.MultiSelect = false;
            this.seikyuListDataGridView.Name = "seikyuListDataGridView";
            this.seikyuListDataGridView.RowHeadersVisible = false;
            this.seikyuListDataGridView.RowHeadersWidth = 30;
            this.seikyuListDataGridView.RowTemplate.Height = 21;
            this.seikyuListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.seikyuListDataGridView.Size = new System.Drawing.Size(1081, 241);
            this.seikyuListDataGridView.TabIndex = 28;
            // 
            // seikyusakiCol
            // 
            this.seikyusakiCol.HeaderText = "請求先";
            this.seikyusakiCol.MaxInputLength = 60;
            this.seikyusakiCol.MinimumWidth = 130;
            this.seikyusakiCol.Name = "seikyusakiCol";
            this.seikyusakiCol.ReadOnly = true;
            this.seikyusakiCol.Width = 130;
            // 
            // renbanCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.renbanCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.renbanCol.HeaderText = "連番";
            this.renbanCol.MaxInputLength = 3;
            this.renbanCol.MinimumWidth = 60;
            this.renbanCol.Name = "renbanCol";
            this.renbanCol.ReadOnly = true;
            this.renbanCol.Width = 60;
            // 
            // shishoNmCol
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.shishoNmCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.shishoNmCol.HeaderText = "支所名";
            this.shishoNmCol.MaxInputLength = 10;
            this.shishoNmCol.MinimumWidth = 80;
            this.shishoNmCol.Name = "shishoNmCol";
            this.shishoNmCol.ReadOnly = true;
            this.shishoNmCol.Width = 80;
            // 
            // seikyuKamokuCol
            // 
            this.seikyuKamokuCol.HeaderText = "請求科目名";
            this.seikyuKamokuCol.MaxInputLength = 40;
            this.seikyuKamokuCol.MinimumWidth = 120;
            this.seikyuKamokuCol.Name = "seikyuKamokuCol";
            this.seikyuKamokuCol.ReadOnly = true;
            this.seikyuKamokuCol.Width = 120;
            // 
            // syohinCol
            // 
            this.syohinCol.HeaderText = "商品名";
            this.syohinCol.MaxInputLength = 60;
            this.syohinCol.MinimumWidth = 170;
            this.syohinCol.Name = "syohinCol";
            this.syohinCol.ReadOnly = true;
            this.syohinCol.Width = 170;
            // 
            // suryoCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.suryoCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.suryoCol.HeaderText = "数量";
            this.suryoCol.MaxInputLength = 4;
            this.suryoCol.MinimumWidth = 60;
            this.suryoCol.Name = "suryoCol";
            this.suryoCol.ReadOnly = true;
            this.suryoCol.Width = 60;
            // 
            // tankaCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.tankaCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.tankaCol.HeaderText = "単価";
            this.tankaCol.MinimumWidth = 70;
            this.tankaCol.Name = "tankaCol";
            this.tankaCol.ReadOnly = true;
            this.tankaCol.Width = 70;
            // 
            // kingakuCol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.kingakuCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.kingakuCol.HeaderText = "金額";
            this.kingakuCol.MinimumWidth = 80;
            this.kingakuCol.Name = "kingakuCol";
            this.kingakuCol.ReadOnly = true;
            this.kingakuCol.Width = 80;
            // 
            // syohizeiCol
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.syohizeiCol.DefaultCellStyle = dataGridViewCellStyle6;
            this.syohizeiCol.HeaderText = "消費税";
            this.syohizeiCol.MinimumWidth = 70;
            this.syohizeiCol.Name = "syohizeiCol";
            this.syohizeiCol.ReadOnly = true;
            this.syohizeiCol.Width = 70;
            // 
            // totalCol
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.totalCol.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalCol.HeaderText = "合計金額";
            this.totalCol.MinimumWidth = 80;
            this.totalCol.Name = "totalCol";
            this.totalCol.ReadOnly = true;
            this.totalCol.Width = 80;
            // 
            // nyukinCol
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.nyukinCol.DefaultCellStyle = dataGridViewCellStyle8;
            this.nyukinCol.HeaderText = "入金額";
            this.nyukinCol.MinimumWidth = 80;
            this.nyukinCol.Name = "nyukinCol";
            this.nyukinCol.ReadOnly = true;
            this.nyukinCol.Width = 80;
            // 
            // kansaiCol
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kansaiCol.DefaultCellStyle = dataGridViewCellStyle9;
            this.kansaiCol.HeaderText = "完済";
            this.kansaiCol.MinimumWidth = 55;
            this.kansaiCol.Name = "kansaiCol";
            this.kansaiCol.ReadOnly = true;
            this.kansaiCol.Width = 55;
            // 
            // seikyuKomokuKbnCol
            // 
            this.seikyuKomokuKbnCol.HeaderText = "請求項目区分（隠し）";
            this.seikyuKomokuKbnCol.Name = "seikyuKomokuKbnCol";
            this.seikyuKomokuKbnCol.ReadOnly = true;
            this.seikyuKomokuKbnCol.Visible = false;
            // 
            // kazeiFlagCol
            // 
            this.kazeiFlagCol.HeaderText = "課税フラグ（隠し）";
            this.kazeiFlagCol.Name = "kazeiFlagCol";
            this.kazeiFlagCol.ReadOnly = true;
            this.kazeiFlagCol.Visible = false;
            // 
            // torokuNmCol
            // 
            this.torokuNmCol.HeaderText = "登録者（隠し）";
            this.torokuNmCol.Name = "torokuNmCol";
            this.torokuNmCol.ReadOnly = true;
            this.torokuNmCol.Visible = false;
            // 
            // torokuDtCol
            // 
            this.torokuDtCol.HeaderText = "登録日時（隠し）";
            this.torokuDtCol.Name = "torokuDtCol";
            this.torokuDtCol.ReadOnly = true;
            this.torokuDtCol.Visible = false;
            // 
            // torokuTanmatsuCol
            // 
            this.torokuTanmatsuCol.HeaderText = "登録端末（隠し）";
            this.torokuTanmatsuCol.Name = "torokuTanmatsuCol";
            this.torokuTanmatsuCol.ReadOnly = true;
            this.torokuTanmatsuCol.Visible = false;
            // 
            // seikyuNoCol
            // 
            this.seikyuNoCol.HeaderText = "請求No";
            this.seikyuNoCol.Name = "seikyuNoCol";
            this.seikyuNoCol.Visible = false;
            // 
            // shishoCdCol
            // 
            this.shishoCdCol.HeaderText = "shishoCdCol";
            this.shishoCdCol.Name = "shishoCdCol";
            this.shishoCdCol.Visible = false;
            // 
            // changedFlgCol
            // 
            this.changedFlgCol.HeaderText = "changedFlgCol";
            this.changedFlgCol.Name = "changedFlgCol";
            this.changedFlgCol.ReadOnly = true;
            this.changedFlgCol.Visible = false;
            // 
            // SeikyuRenbanCol
            // 
            this.SeikyuRenbanCol.HeaderText = "SeikyuRenbanCol";
            this.SeikyuRenbanCol.Name = "SeikyuRenbanCol";
            this.SeikyuRenbanCol.ReadOnly = true;
            this.SeikyuRenbanCol.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(866, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "請求金額合計";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "電話番号";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.Color.Red;
            this.label101.Location = new System.Drawing.Point(82, 122);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(17, 20);
            this.label101.TabIndex = 10;
            this.label101.Text = "*";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(988, 543);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 33;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SeikyuShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SeikyuShosaiForm";
            this.Text = "請求情報";
            this.Load += new System.EventHandler(this.SeikyuShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeikyuShosaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seikyuListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private ZDataGridView seikyuListDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button meisaiAddButton;
        private ZTextBox seikyuNoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private Zynas.Control.ZDate seikyuDtDateTimePicker;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button seikyushoButton;
        private System.Windows.Forms.Button meisaishoButton;
        private System.Windows.Forms.Button meisaiDelButton;
        private Control.ZTextBox seikyuTotalTextBox;
        private System.Windows.Forms.RadioButton kojinRadioButton;
        private System.Windows.Forms.RadioButton gyoshaRadioButton;
        private ZTextBox gyoshaCdTextBox;
        private System.Windows.Forms.Label seikyuPrintLbl;
        private Control.ZTextBox seikyuYMTextBox;
        private Control.ZTextBox gyoshaNmTextBox;
        private Control.ZTextBox settishaNmTextBox;
        private Control.ZTextBox seikyusakiNmTextBox;
        private Control.ZTextBox zipNoTextBox;
        private Control.ZTextBox adrTextBox;
        private Control.ZTextBox telNoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyusakiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn renbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuKamokuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn syohinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn suryoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn tankaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kingakuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn syohizeiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyukinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kansaiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuKomokuKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kazeiFlagCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn torokuNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn torokuDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn torokuTanmatsuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn seikyuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn shishoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn changedFlgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeikyuRenbanCol;
    }
}