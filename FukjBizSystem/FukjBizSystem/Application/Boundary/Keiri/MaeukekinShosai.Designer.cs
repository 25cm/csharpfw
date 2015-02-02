using FukjBizSystem.Control;
namespace FukjBizSystem.Application.Boundary.Keiri
{
    partial class MaeukekinShosaiForm
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
            this.kinyuNmComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.furikomiNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.entryButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.decisionButton = new System.Windows.Forms.Button();
            this.reInputButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.jokasoNo3TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.jokasoNo2TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.jokasoNo1TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.kensaNo3TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.kensaNo2TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kensaNo1TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.IraiRendoLbl = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.torisageDtTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.oldHenkingakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.oldHenkinDtTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.henkinButton = new System.Windows.Forms.Button();
            this.uriageDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.nyukinToriatukaiDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.nyukinDtDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.zankinTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.nyukingakuTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label33 = new System.Windows.Forms.Label();
            this.kyoseiUriCheckBox = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bikoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.furikomiKanaTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.kisaiNashiRadioButton = new System.Windows.Forms.RadioButton();
            this.kisaiAriRadioButton = new System.Windows.Forms.RadioButton();
            this.maeukeNoTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.renzokuNyuryokuCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kinyuNmComboBox
            // 
            this.kinyuNmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kinyuNmComboBox.FormattingEnabled = true;
            this.kinyuNmComboBox.Location = new System.Drawing.Point(136, 48);
            this.kinyuNmComboBox.Name = "kinyuNmComboBox";
            this.kinyuNmComboBox.Size = new System.Drawing.Size(191, 28);
            this.kinyuNmComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "入金方法";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "振込人名";
            // 
            // furikomiNmTextBox
            // 
            this.furikomiNmTextBox.AllowDropDown = false;
            this.furikomiNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.furikomiNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.furikomiNmTextBox.CustomReadOnly = false;
            this.furikomiNmTextBox.Location = new System.Drawing.Point(136, 213);
            this.furikomiNmTextBox.MaxLength = 20;
            this.furikomiNmTextBox.Name = "furikomiNmTextBox";
            this.furikomiNmTextBox.Size = new System.Drawing.Size(448, 27);
            this.furikomiNmTextBox.TabIndex = 22;
            // 
            // entryButton
            // 
            this.entryButton.Location = new System.Drawing.Point(418, 543);
            this.entryButton.Name = "entryButton";
            this.entryButton.Size = new System.Drawing.Size(101, 37);
            this.entryButton.TabIndex = 52;
            this.entryButton.Text = "F1:登録";
            this.entryButton.UseVisualStyleBackColor = true;
            this.entryButton.Click += new System.EventHandler(this.EntryButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(525, 543);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(101, 37);
            this.changeButton.TabIndex = 53;
            this.changeButton.Text = "F2:変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // decisionButton
            // 
            this.decisionButton.Location = new System.Drawing.Point(846, 543);
            this.decisionButton.Name = "decisionButton";
            this.decisionButton.Size = new System.Drawing.Size(101, 37);
            this.decisionButton.TabIndex = 56;
            this.decisionButton.Text = "F5:確定";
            this.decisionButton.UseVisualStyleBackColor = true;
            this.decisionButton.Click += new System.EventHandler(this.DecisionButton_Click);
            // 
            // reInputButton
            // 
            this.reInputButton.Location = new System.Drawing.Point(739, 543);
            this.reInputButton.Name = "reInputButton";
            this.reInputButton.Size = new System.Drawing.Size(101, 37);
            this.reInputButton.TabIndex = 55;
            this.reInputButton.Text = "F4:再入力";
            this.reInputButton.UseVisualStyleBackColor = true;
            this.reInputButton.Click += new System.EventHandler(this.ReInputButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(632, 543);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 37);
            this.deleteButton.TabIndex = 54;
            this.deleteButton.Text = "F3:削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.renzokuNyuryokuCheckBox);
            this.mainPanel.Controls.Add(this.label21);
            this.mainPanel.Controls.Add(this.label22);
            this.mainPanel.Controls.Add(this.jokasoNo3TextBox);
            this.mainPanel.Controls.Add(this.label24);
            this.mainPanel.Controls.Add(this.jokasoNo2TextBox);
            this.mainPanel.Controls.Add(this.jokasoNo1TextBox);
            this.mainPanel.Controls.Add(this.label20);
            this.mainPanel.Controls.Add(this.label18);
            this.mainPanel.Controls.Add(this.kensaNo3TextBox);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.kensaNo2TextBox);
            this.mainPanel.Controls.Add(this.kensaNo1TextBox);
            this.mainPanel.Controls.Add(this.IraiRendoLbl);
            this.mainPanel.Controls.Add(this.clearButton);
            this.mainPanel.Controls.Add(this.torisageDtTextBox);
            this.mainPanel.Controls.Add(this.oldHenkingakuTextBox);
            this.mainPanel.Controls.Add(this.label13);
            this.mainPanel.Controls.Add(this.oldHenkinDtTextBox);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.henkinButton);
            this.mainPanel.Controls.Add(this.uriageDtDateTimePicker);
            this.mainPanel.Controls.Add(this.nyukinToriatukaiDtDateTimePicker);
            this.mainPanel.Controls.Add(this.label17);
            this.mainPanel.Controls.Add(this.label34);
            this.mainPanel.Controls.Add(this.nyukinDtDateTimePicker);
            this.mainPanel.Controls.Add(this.zankinTextBox);
            this.mainPanel.Controls.Add(this.nyukingakuTextBox);
            this.mainPanel.Controls.Add(this.label33);
            this.mainPanel.Controls.Add(this.kyoseiUriCheckBox);
            this.mainPanel.Controls.Add(this.label23);
            this.mainPanel.Controls.Add(this.label16);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.bikoTextBox);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.furikomiKanaTextBox);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label10);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.kisaiNashiRadioButton);
            this.mainPanel.Controls.Add(this.kisaiAriRadioButton);
            this.mainPanel.Controls.Add(this.maeukeNoTextBox);
            this.mainPanel.Controls.Add(this.label19);
            this.mainPanel.Controls.Add(this.label101);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.kinyuNmComboBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.furikomiNmTextBox);
            this.mainPanel.Controls.Add(this.entryButton);
            this.mainPanel.Controls.Add(this.changeButton);
            this.mainPanel.Controls.Add(this.decisionButton);
            this.mainPanel.Controls.Add(this.reInputButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Location = new System.Drawing.Point(2, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(21, 315);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 20);
            this.label21.TabIndex = 31;
            this.label21.Text = "連動浄化槽番号";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(237, 315);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(22, 20);
            this.label22.TabIndex = 35;
            this.label22.Text = "－";
            // 
            // jokasoNo3TextBox
            // 
            this.jokasoNo3TextBox.AllowDropDown = false;
            this.jokasoNo3TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.jokasoNo3TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.jokasoNo3TextBox.CustomReadOnly = false;
            this.jokasoNo3TextBox.Location = new System.Drawing.Point(265, 312);
            this.jokasoNo3TextBox.Name = "jokasoNo3TextBox";
            this.jokasoNo3TextBox.ReadOnly = true;
            this.jokasoNo3TextBox.Size = new System.Drawing.Size(62, 27);
            this.jokasoNo3TextBox.TabIndex = 36;
            this.jokasoNo3TextBox.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(171, 315);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 20);
            this.label24.TabIndex = 33;
            this.label24.Text = "－";
            // 
            // jokasoNo2TextBox
            // 
            this.jokasoNo2TextBox.AllowDropDown = false;
            this.jokasoNo2TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.jokasoNo2TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.jokasoNo2TextBox.CustomReadOnly = false;
            this.jokasoNo2TextBox.Location = new System.Drawing.Point(199, 312);
            this.jokasoNo2TextBox.Name = "jokasoNo2TextBox";
            this.jokasoNo2TextBox.ReadOnly = true;
            this.jokasoNo2TextBox.Size = new System.Drawing.Size(33, 27);
            this.jokasoNo2TextBox.TabIndex = 34;
            this.jokasoNo2TextBox.TabStop = false;
            // 
            // jokasoNo1TextBox
            // 
            this.jokasoNo1TextBox.AllowDropDown = false;
            this.jokasoNo1TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.jokasoNo1TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.jokasoNo1TextBox.CustomReadOnly = false;
            this.jokasoNo1TextBox.Location = new System.Drawing.Point(136, 312);
            this.jokasoNo1TextBox.Name = "jokasoNo1TextBox";
            this.jokasoNo1TextBox.ReadOnly = true;
            this.jokasoNo1TextBox.Size = new System.Drawing.Size(33, 27);
            this.jokasoNo1TextBox.TabIndex = 32;
            this.jokasoNo1TextBox.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(21, 282);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 20);
            this.label20.TabIndex = 25;
            this.label20.Text = "連動検査番号";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(237, 282);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 20);
            this.label18.TabIndex = 29;
            this.label18.Text = "－";
            // 
            // kensaNo3TextBox
            // 
            this.kensaNo3TextBox.AllowDropDown = false;
            this.kensaNo3TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaNo3TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaNo3TextBox.CustomReadOnly = false;
            this.kensaNo3TextBox.Location = new System.Drawing.Point(265, 279);
            this.kensaNo3TextBox.Name = "kensaNo3TextBox";
            this.kensaNo3TextBox.ReadOnly = true;
            this.kensaNo3TextBox.Size = new System.Drawing.Size(62, 27);
            this.kensaNo3TextBox.TabIndex = 30;
            this.kensaNo3TextBox.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(171, 282);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 20);
            this.label15.TabIndex = 27;
            this.label15.Text = "－";
            // 
            // kensaNo2TextBox
            // 
            this.kensaNo2TextBox.AllowDropDown = false;
            this.kensaNo2TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaNo2TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaNo2TextBox.CustomReadOnly = false;
            this.kensaNo2TextBox.Location = new System.Drawing.Point(199, 279);
            this.kensaNo2TextBox.Name = "kensaNo2TextBox";
            this.kensaNo2TextBox.ReadOnly = true;
            this.kensaNo2TextBox.Size = new System.Drawing.Size(33, 27);
            this.kensaNo2TextBox.TabIndex = 28;
            this.kensaNo2TextBox.TabStop = false;
            // 
            // kensaNo1TextBox
            // 
            this.kensaNo1TextBox.AllowDropDown = false;
            this.kensaNo1TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kensaNo1TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kensaNo1TextBox.CustomReadOnly = false;
            this.kensaNo1TextBox.Location = new System.Drawing.Point(136, 279);
            this.kensaNo1TextBox.Name = "kensaNo1TextBox";
            this.kensaNo1TextBox.ReadOnly = true;
            this.kensaNo1TextBox.Size = new System.Drawing.Size(33, 27);
            this.kensaNo1TextBox.TabIndex = 26;
            this.kensaNo1TextBox.TabStop = false;
            // 
            // IraiRendoLbl
            // 
            this.IraiRendoLbl.AutoSize = true;
            this.IraiRendoLbl.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IraiRendoLbl.ForeColor = System.Drawing.Color.Red;
            this.IraiRendoLbl.Location = new System.Drawing.Point(887, 28);
            this.IraiRendoLbl.Name = "IraiRendoLbl";
            this.IraiRendoLbl.Size = new System.Drawing.Size(180, 48);
            this.IraiRendoLbl.TabIndex = 46;
            this.IraiRendoLbl.Text = "依頼連動済";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(826, 183);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 51;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // torisageDtTextBox
            // 
            this.torisageDtTextBox.AllowDropDown = false;
            this.torisageDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.torisageDtTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.torisageDtTextBox.CustomReadOnly = false;
            this.torisageDtTextBox.Enabled = false;
            this.torisageDtTextBox.Location = new System.Drawing.Point(137, 406);
            this.torisageDtTextBox.MaxLength = 9;
            this.torisageDtTextBox.Name = "torisageDtTextBox";
            this.torisageDtTextBox.ReadOnly = true;
            this.torisageDtTextBox.Size = new System.Drawing.Size(100, 27);
            this.torisageDtTextBox.TabIndex = 42;
            // 
            // oldHenkingakuTextBox
            // 
            this.oldHenkingakuTextBox.AllowDropDown = false;
            this.oldHenkingakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.oldHenkingakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.oldHenkingakuTextBox.CustomReadOnly = false;
            this.oldHenkingakuTextBox.Enabled = false;
            this.oldHenkingakuTextBox.Location = new System.Drawing.Point(365, 442);
            this.oldHenkingakuTextBox.MaxLength = 9;
            this.oldHenkingakuTextBox.Name = "oldHenkingakuTextBox";
            this.oldHenkingakuTextBox.ReadOnly = true;
            this.oldHenkingakuTextBox.Size = new System.Drawing.Size(100, 27);
            this.oldHenkingakuTextBox.TabIndex = 47;
            this.oldHenkingakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(271, 444);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 46;
            this.label13.Text = "前回返金額";
            // 
            // oldHenkinDtTextBox
            // 
            this.oldHenkinDtTextBox.AllowDropDown = false;
            this.oldHenkinDtTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.oldHenkinDtTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.oldHenkinDtTextBox.CustomReadOnly = false;
            this.oldHenkinDtTextBox.Enabled = false;
            this.oldHenkinDtTextBox.Location = new System.Drawing.Point(137, 442);
            this.oldHenkinDtTextBox.MaxLength = 9;
            this.oldHenkinDtTextBox.Name = "oldHenkinDtTextBox";
            this.oldHenkinDtTextBox.ReadOnly = true;
            this.oldHenkinDtTextBox.Size = new System.Drawing.Size(100, 27);
            this.oldHenkinDtTextBox.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "前回返金日";
            // 
            // henkinButton
            // 
            this.henkinButton.Location = new System.Drawing.Point(364, 397);
            this.henkinButton.Name = "henkinButton";
            this.henkinButton.Size = new System.Drawing.Size(101, 37);
            this.henkinButton.TabIndex = 43;
            this.henkinButton.Text = "F8:返金処理";
            this.henkinButton.UseVisualStyleBackColor = true;
            this.henkinButton.Click += new System.EventHandler(this.henkinButton_Click);
            // 
            // uriageDtDateTimePicker
            // 
            this.uriageDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.uriageDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uriageDtDateTimePicker.Location = new System.Drawing.Point(137, 374);
            this.uriageDtDateTimePicker.Name = "uriageDtDateTimePicker";
            this.uriageDtDateTimePicker.Size = new System.Drawing.Size(191, 27);
            this.uriageDtDateTimePicker.TabIndex = 40;
            // 
            // nyukinToriatukaiDtDateTimePicker
            // 
            this.nyukinToriatukaiDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.nyukinToriatukaiDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nyukinToriatukaiDtDateTimePicker.Location = new System.Drawing.Point(136, 114);
            this.nyukinToriatukaiDtDateTimePicker.Name = "nyukinToriatukaiDtDateTimePicker";
            this.nyukinToriatukaiDtDateTimePicker.Size = new System.Drawing.Size(191, 27);
            this.nyukinToriatukaiDtDateTimePicker.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(113, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 20);
            this.label17.TabIndex = 12;
            this.label17.Text = "*";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(21, 114);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(74, 20);
            this.label34.TabIndex = 11;
            this.label34.Text = "入金取扱日";
            // 
            // nyukinDtDateTimePicker
            // 
            this.nyukinDtDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.nyukinDtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nyukinDtDateTimePicker.Location = new System.Drawing.Point(136, 85);
            this.nyukinDtDateTimePicker.Name = "nyukinDtDateTimePicker";
            this.nyukinDtDateTimePicker.Size = new System.Drawing.Size(191, 27);
            this.nyukinDtDateTimePicker.TabIndex = 10;
            this.nyukinDtDateTimePicker.ValueChanged += new System.EventHandler(this.nyukinDtDateTimePicker_ValueChanged);
            // 
            // zankinTextBox
            // 
            this.zankinTextBox.AllowDropDown = false;
            this.zankinTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.zankinTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.zankinTextBox.CustomReadOnly = false;
            this.zankinTextBox.Enabled = false;
            this.zankinTextBox.Location = new System.Drawing.Point(589, 442);
            this.zankinTextBox.MaxLength = 9;
            this.zankinTextBox.Name = "zankinTextBox";
            this.zankinTextBox.ReadOnly = true;
            this.zankinTextBox.Size = new System.Drawing.Size(100, 27);
            this.zankinTextBox.TabIndex = 49;
            this.zankinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nyukingakuTextBox
            // 
            this.nyukingakuTextBox.AllowDropDown = false;
            this.nyukingakuTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.nyukingakuTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.nyukingakuTextBox.CustomReadOnly = false;
            this.nyukingakuTextBox.Location = new System.Drawing.Point(136, 147);
            this.nyukingakuTextBox.MaxLength = 9;
            this.nyukingakuTextBox.Name = "nyukingakuTextBox";
            this.nyukingakuTextBox.Size = new System.Drawing.Size(100, 27);
            this.nyukingakuTextBox.TabIndex = 16;
            this.nyukingakuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(495, 444);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 20);
            this.label33.TabIndex = 48;
            this.label33.Text = "残金";
            // 
            // kyoseiUriCheckBox
            // 
            this.kyoseiUriCheckBox.AutoSize = true;
            this.kyoseiUriCheckBox.Location = new System.Drawing.Point(206, 354);
            this.kyoseiUriCheckBox.Name = "kyoseiUriCheckBox";
            this.kyoseiUriCheckBox.Size = new System.Drawing.Size(15, 14);
            this.kyoseiUriCheckBox.TabIndex = 38;
            this.kyoseiUriCheckBox.UseVisualStyleBackColor = true;
            this.kyoseiUriCheckBox.CheckedChanged += new System.EventHandler(this.kyoseiUriCheckBox_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(133, 350);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(61, 20);
            this.label23.TabIndex = 37;
            this.label23.Text = "強制売上";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 409);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 20);
            this.label16.TabIndex = 41;
            this.label16.Text = "返金日";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 376);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 20);
            this.label14.TabIndex = 39;
            this.label14.Text = "売上日付";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "備考";
            // 
            // bikoTextBox
            // 
            this.bikoTextBox.AllowDropDown = false;
            this.bikoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.bikoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.bikoTextBox.CustomReadOnly = false;
            this.bikoTextBox.Location = new System.Drawing.Point(136, 246);
            this.bikoTextBox.MaxLength = 40;
            this.bikoTextBox.Name = "bikoTextBox";
            this.bikoTextBox.Size = new System.Drawing.Size(791, 27);
            this.bikoTextBox.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(113, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "振込人カナ";
            // 
            // furikomiKanaTextBox
            // 
            this.furikomiKanaTextBox.AllowDropDown = false;
            this.furikomiKanaTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.furikomiKanaTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.furikomiKanaTextBox.CustomReadOnly = false;
            this.furikomiKanaTextBox.Location = new System.Drawing.Point(136, 180);
            this.furikomiKanaTextBox.MaxLength = 20;
            this.furikomiKanaTextBox.Name = "furikomiKanaTextBox";
            this.furikomiKanaTextBox.Size = new System.Drawing.Size(448, 27);
            this.furikomiKanaTextBox.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(113, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "入金額";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(113, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "入金日";
            // 
            // kisaiNashiRadioButton
            // 
            this.kisaiNashiRadioButton.AutoSize = true;
            this.kisaiNashiRadioButton.Location = new System.Drawing.Point(141, 21);
            this.kisaiNashiRadioButton.Name = "kisaiNashiRadioButton";
            this.kisaiNashiRadioButton.Size = new System.Drawing.Size(79, 24);
            this.kisaiNashiRadioButton.TabIndex = 2;
            this.kisaiNashiRadioButton.Text = "自動採番";
            this.kisaiNashiRadioButton.UseVisualStyleBackColor = true;
            // 
            // kisaiAriRadioButton
            // 
            this.kisaiAriRadioButton.AutoSize = true;
            this.kisaiAriRadioButton.Checked = true;
            this.kisaiAriRadioButton.Location = new System.Drawing.Point(226, 21);
            this.kisaiAriRadioButton.Name = "kisaiAriRadioButton";
            this.kisaiAriRadioButton.Size = new System.Drawing.Size(123, 24);
            this.kisaiAriRadioButton.TabIndex = 3;
            this.kisaiAriRadioButton.TabStop = true;
            this.kisaiAriRadioButton.Text = "振込用紙記載No";
            this.kisaiAriRadioButton.UseVisualStyleBackColor = true;
            this.kisaiAriRadioButton.CheckedChanged += new System.EventHandler(this.kisaiAriRadioButton_CheckedChanged);
            // 
            // maeukeNoTextBox
            // 
            this.maeukeNoTextBox.AllowDropDown = false;
            this.maeukeNoTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.maeukeNoTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.maeukeNoTextBox.CustomReadOnly = false;
            this.maeukeNoTextBox.Location = new System.Drawing.Point(355, 20);
            this.maeukeNoTextBox.MaxLength = 6;
            this.maeukeNoTextBox.Name = "maeukeNoTextBox";
            this.maeukeNoTextBox.Size = new System.Drawing.Size(69, 27);
            this.maeukeNoTextBox.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "前受金No";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.Color.Red;
            this.label101.Location = new System.Drawing.Point(113, 183);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(17, 20);
            this.label101.TabIndex = 18;
            this.label101.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(113, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(114, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "*";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(988, 543);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 57;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // renzokuNyuryokuCheckBox
            // 
            this.renzokuNyuryokuCheckBox.AutoSize = true;
            this.renzokuNyuryokuCheckBox.Location = new System.Drawing.Point(864, 502);
            this.renzokuNyuryokuCheckBox.Name = "renzokuNyuryokuCheckBox";
            this.renzokuNyuryokuCheckBox.Size = new System.Drawing.Size(80, 24);
            this.renzokuNyuryokuCheckBox.TabIndex = 50;
            this.renzokuNyuryokuCheckBox.Text = "連続入力";
            this.renzokuNyuryokuCheckBox.UseVisualStyleBackColor = true;
            // 
            // MaeukekinShosaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MaeukekinShosaiForm";
            this.Text = "前受金情報";
            this.Load += new System.EventHandler(this.MaeukekinShosaiForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaeukekinShosaiForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox kinyuNmComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ZTextBox furikomiNmTextBox;
        private System.Windows.Forms.Button entryButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button decisionButton;
        private System.Windows.Forms.Button reInputButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton kisaiNashiRadioButton;
        private System.Windows.Forms.RadioButton kisaiAriRadioButton;
        private ZTextBox maeukeNoTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private ZTextBox bikoTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ZTextBox furikomiKanaTextBox;
        private Control.ZTextBox nyukingakuTextBox;
        private Zynas.Control.ZDate nyukinToriatukaiDtDateTimePicker;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label34;
        private Zynas.Control.ZDate nyukinDtDateTimePicker;
        private Zynas.Control.ZDate uriageDtDateTimePicker;
        private Control.ZTextBox zankinTextBox;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox kyoseiUriCheckBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button henkinButton;
        private System.Windows.Forms.Label label5;
        private Control.ZTextBox oldHenkinDtTextBox;
        private Control.ZTextBox oldHenkingakuTextBox;
        private System.Windows.Forms.Label label13;
        private Control.ZTextBox torisageDtTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label IraiRendoLbl;
        private System.Windows.Forms.Label label18;
        private ZTextBox kensaNo3TextBox;
        private System.Windows.Forms.Label label15;
        private ZTextBox kensaNo2TextBox;
        private ZTextBox kensaNo1TextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private ZTextBox jokasoNo3TextBox;
        private System.Windows.Forms.Label label24;
        private ZTextBox jokasoNo2TextBox;
        private ZTextBox jokasoNo1TextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox renzokuNyuryokuCheckBox;
    }
}