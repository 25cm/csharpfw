using FukjBizSystem.Control;
using Zynas.Control.ZDataGridView;
namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    partial class KensaYoteiListForm
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
            this.yoteiListDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.SelectCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rowNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoteiDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyokaiNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settisyaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settiBasyoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chizuNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syoriHoshikiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ninsoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyosyaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hagakiSyubetsuCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.hagakiSyubetsuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.constMstDataSet = new FukjBizSystem.Application.DataSet.ConstMstDataSet();
            this.hagakiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiHoteiKbnCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiHokenjoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiNendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiSetchibashoAdrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKensaYoteiBiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiSetchishaKanaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiShoritaishoJininDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiSetchishaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hagakiColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoChizuNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jokasoHagakiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiJokasoRenbanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoteiDtColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyokaiNoColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gyoshaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoDaichoMstUpdateDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaIraiTblUpdateDtCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoRenbanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoHokenjoCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JokasoTorokuNendoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kensaIraiTblDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kensaIraiTblDataSet = new FukjBizSystem.Application.DataSet.KensaIraiTblDataSet();
            this.torikeshiButton = new System.Windows.Forms.Button();
            this.srhListPanel = new System.Windows.Forms.Panel();
            this.srhListCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.outputButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.shikuchosonComboBox = new System.Windows.Forms.ComboBox();
            this.kyokaiTo1TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiTo2TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiTo3TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiFrom1TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiFrom2TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kyokaiFrom3TextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.ninsoToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.yoteiDtJunRadioButton = new System.Windows.Forms.RadioButton();
            this.settibasyoJunRadioButton = new System.Windows.Forms.RadioButton();
            this.tizuNoJunRadioButton = new System.Windows.Forms.RadioButton();
            this.kyokaiNoJunRadioButton = new System.Windows.Forms.RadioButton();
            this.ninsoFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.settisyaKanaToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.settisyaKanaFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.gyosyaTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.settiAdrTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.kensaYoteiDtToDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.kensaYoteiDtFromDateTimePicker = new Zynas.Control.ZDate(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gyosyaSrhButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.kensaMiteiCheckBox = new System.Windows.Forms.CheckBox();
            this.kensaYoteiDtUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.kensa11JoRadioButton = new System.Windows.Forms.RadioButton();
            this.kensa7JoRadioButton = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.kensainComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.hagakiButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.printCntTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.kensaYoteiPrintCheckBox = new System.Windows.Forms.CheckBox();
            this.seisoKakuninButton = new System.Windows.Forms.Button();
            this.kaijoButton = new System.Windows.Forms.Button();
            this.hagakiSyubetsuTableAdapter = new FukjBizSystem.Application.DataSet.ConstMstDataSetTableAdapters.HagakiSyubetsuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.yoteiListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hagakiSyubetsuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constMstDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSet)).BeginInit();
            this.srhListPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yoteiListDataGridView
            // 
            this.yoteiListDataGridView.AllowUserToAddRows = false;
            this.yoteiListDataGridView.AllowUserToDeleteRows = false;
            this.yoteiListDataGridView.AllowUserToResizeRows = false;
            this.yoteiListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yoteiListDataGridView.AutoGenerateColumns = false;
            this.yoteiListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.yoteiListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectCol,
            this.rowNoCol,
            this.yoteiDtCol,
            this.kyokaiNoCol,
            this.settisyaCol,
            this.settiBasyoCol,
            this.chizuNoCol,
            this.syoriHoshikiCol,
            this.ninsoCol,
            this.gyosyaCol,
            this.hagakiSyubetsuCol,
            this.hagakiCol,
            this.KensaIraiHoteiKbnCol,
            this.KensaIraiHokenjoCdCol,
            this.KensaIraiNendoCol,
            this.KensaIraiRenbanCol,
            this.kensaIraiSetchibashoAdrDataGridViewTextBoxColumn,
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn,
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn,
            this.kensaIraiKensaYoteiBiDataGridViewTextBoxColumn,
            this.kensaIraiSetchishaKanaDataGridViewTextBoxColumn,
            this.kensaIraiShoritaishoJininDataGridViewTextBoxColumn,
            this.kensaIraiSetchishaNmDataGridViewTextBoxColumn,
            this.kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn,
            this.kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn,
            this.kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn,
            this.kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn,
            this.hagakiColDataGridViewTextBoxColumn,
            this.jokasoChizuNoDataGridViewTextBoxColumn,
            this.jokasoHagakiKbnDataGridViewTextBoxColumn,
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn,
            this.constNmDataGridViewTextBoxColumn,
            this.kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn,
            this.kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn,
            this.kensaIraiJokasoRenbanDataGridViewTextBoxColumn,
            this.yoteiDtColDataGridViewTextBoxColumn,
            this.kyokaiNoColDataGridViewTextBoxColumn,
            this.gyoshaNmDataGridViewTextBoxColumn,
            this.JokasoDaichoMstUpdateDtCol,
            this.KensaIraiTblUpdateDtCol,
            this.JokasoRenbanCol,
            this.JokasoHokenjoCdCol,
            this.JokasoTorokuNendoCol});
            this.yoteiListDataGridView.DataMember = "KensaYoteiList";
            this.yoteiListDataGridView.DataSource = this.kensaIraiTblDataSetBindingSource;
            this.yoteiListDataGridView.Location = new System.Drawing.Point(2, 24);
            this.yoteiListDataGridView.MultiSelect = false;
            this.yoteiListDataGridView.Name = "yoteiListDataGridView";
            this.yoteiListDataGridView.RowHeadersVisible = false;
            this.yoteiListDataGridView.RowTemplate.Height = 21;
            this.yoteiListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.yoteiListDataGridView.Size = new System.Drawing.Size(1085, 215);
            this.yoteiListDataGridView.TabIndex = 2;
            this.yoteiListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.yoteiListDataGridView_CellContentClick);
            this.yoteiListDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.yoteiListDataGridView_CellContentClick);
            // 
            // SelectCol
            // 
            this.SelectCol.DataPropertyName = "SelectCol";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.NullValue = false;
            this.SelectCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.SelectCol.FalseValue = "0";
            this.SelectCol.HeaderText = "選択";
            this.SelectCol.MinimumWidth = 50;
            this.SelectCol.Name = "SelectCol";
            this.SelectCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectCol.TrueValue = "1";
            this.SelectCol.Width = 50;
            // 
            // rowNoCol
            // 
            this.rowNoCol.DataPropertyName = "RowNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.rowNoCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.rowNoCol.HeaderText = "行";
            this.rowNoCol.MinimumWidth = 35;
            this.rowNoCol.Name = "rowNoCol";
            this.rowNoCol.ReadOnly = true;
            this.rowNoCol.Width = 35;
            // 
            // yoteiDtCol
            // 
            this.yoteiDtCol.DataPropertyName = "yoteiDtCol";
            this.yoteiDtCol.HeaderText = "予定日";
            this.yoteiDtCol.MinimumWidth = 90;
            this.yoteiDtCol.Name = "yoteiDtCol";
            this.yoteiDtCol.ReadOnly = true;
            this.yoteiDtCol.Width = 90;
            // 
            // kyokaiNoCol
            // 
            this.kyokaiNoCol.DataPropertyName = "kyokaiNoCol";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kyokaiNoCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.kyokaiNoCol.HeaderText = "検査番号";
            this.kyokaiNoCol.MaxInputLength = 12;
            this.kyokaiNoCol.MinimumWidth = 110;
            this.kyokaiNoCol.Name = "kyokaiNoCol";
            this.kyokaiNoCol.ReadOnly = true;
            this.kyokaiNoCol.Width = 110;
            // 
            // settisyaCol
            // 
            this.settisyaCol.DataPropertyName = "KensaIraiSetchishaNm";
            this.settisyaCol.HeaderText = "設置者名";
            this.settisyaCol.MaxInputLength = 60;
            this.settisyaCol.MinimumWidth = 120;
            this.settisyaCol.Name = "settisyaCol";
            this.settisyaCol.ReadOnly = true;
            this.settisyaCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.settisyaCol.Width = 120;
            // 
            // settiBasyoCol
            // 
            this.settiBasyoCol.DataPropertyName = "KensaIraiSetchibashoAdr";
            this.settiBasyoCol.HeaderText = "設置場所";
            this.settiBasyoCol.MaxInputLength = 80;
            this.settiBasyoCol.MinimumWidth = 160;
            this.settiBasyoCol.Name = "settiBasyoCol";
            this.settiBasyoCol.ReadOnly = true;
            this.settiBasyoCol.Width = 160;
            // 
            // chizuNoCol
            // 
            this.chizuNoCol.DataPropertyName = "JokasoChizuNo";
            this.chizuNoCol.HeaderText = "地図番号";
            this.chizuNoCol.MaxInputLength = 10;
            this.chizuNoCol.MinimumWidth = 70;
            this.chizuNoCol.Name = "chizuNoCol";
            this.chizuNoCol.ReadOnly = true;
            this.chizuNoCol.Width = 70;
            // 
            // syoriHoshikiCol
            // 
            this.syoriHoshikiCol.DataPropertyName = "ShoriHoshikiShubetsuNm";
            this.syoriHoshikiCol.HeaderText = "単/合";
            this.syoriHoshikiCol.MaxInputLength = 14;
            this.syoriHoshikiCol.MinimumWidth = 80;
            this.syoriHoshikiCol.Name = "syoriHoshikiCol";
            this.syoriHoshikiCol.ReadOnly = true;
            this.syoriHoshikiCol.Width = 80;
            // 
            // ninsoCol
            // 
            this.ninsoCol.DataPropertyName = "KensaIraiShoritaishoJinin";
            this.ninsoCol.HeaderText = "人槽";
            this.ninsoCol.MaxInputLength = 4;
            this.ninsoCol.MinimumWidth = 50;
            this.ninsoCol.Name = "ninsoCol";
            this.ninsoCol.ReadOnly = true;
            this.ninsoCol.Width = 50;
            // 
            // gyosyaCol
            // 
            this.gyosyaCol.DataPropertyName = "GyoshaNm";
            this.gyosyaCol.HeaderText = "管理業者";
            this.gyosyaCol.MaxInputLength = 40;
            this.gyosyaCol.MinimumWidth = 130;
            this.gyosyaCol.Name = "gyosyaCol";
            this.gyosyaCol.ReadOnly = true;
            this.gyosyaCol.Width = 130;
            // 
            // hagakiSyubetsuCol
            // 
            this.hagakiSyubetsuCol.DataPropertyName = "JokasoHagakiKbn";
            this.hagakiSyubetsuCol.DataSource = this.hagakiSyubetsuBindingSource;
            this.hagakiSyubetsuCol.DisplayMember = "ConstNm";
            this.hagakiSyubetsuCol.HeaderText = "はがき種別";
            this.hagakiSyubetsuCol.MinimumWidth = 120;
            this.hagakiSyubetsuCol.Name = "hagakiSyubetsuCol";
            this.hagakiSyubetsuCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hagakiSyubetsuCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hagakiSyubetsuCol.ValueMember = "ConstValue";
            this.hagakiSyubetsuCol.Width = 120;
            // 
            // hagakiSyubetsuBindingSource
            // 
            this.hagakiSyubetsuBindingSource.DataMember = "HagakiSyubetsu";
            this.hagakiSyubetsuBindingSource.DataSource = this.constMstDataSet;
            // 
            // constMstDataSet
            // 
            this.constMstDataSet.DataSetName = "ConstMstDataSet";
            this.constMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hagakiCol
            // 
            this.hagakiCol.DataPropertyName = "hagakiCol";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hagakiCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.hagakiCol.HeaderText = "はがき";
            this.hagakiCol.MinimumWidth = 60;
            this.hagakiCol.Name = "hagakiCol";
            this.hagakiCol.ReadOnly = true;
            this.hagakiCol.Width = 60;
            // 
            // KensaIraiHoteiKbnCol
            // 
            this.KensaIraiHoteiKbnCol.DataPropertyName = "KensaIraiHoteiKbn";
            this.KensaIraiHoteiKbnCol.HeaderText = "KensaIraiHoteiKbn";
            this.KensaIraiHoteiKbnCol.Name = "KensaIraiHoteiKbnCol";
            this.KensaIraiHoteiKbnCol.Visible = false;
            // 
            // KensaIraiHokenjoCdCol
            // 
            this.KensaIraiHokenjoCdCol.DataPropertyName = "KensaIraiHokenjoCd";
            this.KensaIraiHokenjoCdCol.HeaderText = "KensaIraiHokenjoCd";
            this.KensaIraiHokenjoCdCol.Name = "KensaIraiHokenjoCdCol";
            this.KensaIraiHokenjoCdCol.Visible = false;
            // 
            // KensaIraiNendoCol
            // 
            this.KensaIraiNendoCol.DataPropertyName = "KensaIraiNendo";
            this.KensaIraiNendoCol.HeaderText = "KensaIraiNendo";
            this.KensaIraiNendoCol.Name = "KensaIraiNendoCol";
            this.KensaIraiNendoCol.Visible = false;
            // 
            // KensaIraiRenbanCol
            // 
            this.KensaIraiRenbanCol.DataPropertyName = "KensaIraiRenban";
            this.KensaIraiRenbanCol.HeaderText = "KensaIraiRenban";
            this.KensaIraiRenbanCol.Name = "KensaIraiRenbanCol";
            this.KensaIraiRenbanCol.Visible = false;
            // 
            // kensaIraiSetchibashoAdrDataGridViewTextBoxColumn
            // 
            this.kensaIraiSetchibashoAdrDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiSetchibashoAdr";
            this.kensaIraiSetchibashoAdrDataGridViewTextBoxColumn.HeaderText = "KensaIraiSetchibashoAdr";
            this.kensaIraiSetchibashoAdrDataGridViewTextBoxColumn.Name = "kensaIraiSetchibashoAdrDataGridViewTextBoxColumn";
            this.kensaIraiSetchibashoAdrDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKensaYoteiNenDataGridViewTextBoxColumn
            // 
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKensaYoteiNen";
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.HeaderText = "KensaIraiKensaYoteiNen";
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.Name = "kensaIraiKensaYoteiNenDataGridViewTextBoxColumn";
            this.kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn
            // 
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKensaYoteiTsuki";
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.HeaderText = "KensaIraiKensaYoteiTsuki";
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.Name = "kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn";
            this.kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKensaYoteiBiDataGridViewTextBoxColumn
            // 
            this.kensaIraiKensaYoteiBiDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKensaYoteiBi";
            this.kensaIraiKensaYoteiBiDataGridViewTextBoxColumn.HeaderText = "KensaIraiKensaYoteiBi";
            this.kensaIraiKensaYoteiBiDataGridViewTextBoxColumn.Name = "kensaIraiKensaYoteiBiDataGridViewTextBoxColumn";
            this.kensaIraiKensaYoteiBiDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiSetchishaKanaDataGridViewTextBoxColumn
            // 
            this.kensaIraiSetchishaKanaDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiSetchishaKana";
            this.kensaIraiSetchishaKanaDataGridViewTextBoxColumn.HeaderText = "KensaIraiSetchishaKana";
            this.kensaIraiSetchishaKanaDataGridViewTextBoxColumn.Name = "kensaIraiSetchishaKanaDataGridViewTextBoxColumn";
            this.kensaIraiSetchishaKanaDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiShoritaishoJininDataGridViewTextBoxColumn
            // 
            this.kensaIraiShoritaishoJininDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiShoritaishoJinin";
            this.kensaIraiShoritaishoJininDataGridViewTextBoxColumn.HeaderText = "KensaIraiShoritaishoJinin";
            this.kensaIraiShoritaishoJininDataGridViewTextBoxColumn.Name = "kensaIraiShoritaishoJininDataGridViewTextBoxColumn";
            this.kensaIraiShoritaishoJininDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiSetchishaNmDataGridViewTextBoxColumn
            // 
            this.kensaIraiSetchishaNmDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiSetchishaNm";
            this.kensaIraiSetchishaNmDataGridViewTextBoxColumn.HeaderText = "KensaIraiSetchishaNm";
            this.kensaIraiSetchishaNmDataGridViewTextBoxColumn.Name = "kensaIraiSetchishaNmDataGridViewTextBoxColumn";
            this.kensaIraiSetchishaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn
            // 
            this.kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiShorihoshikiKbn";
            this.kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn.HeaderText = "KensaIraiShorihoshikiKbn";
            this.kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn.Name = "kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn";
            this.kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiKojiGyoshaCd";
            this.kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiKojiGyoshaCd";
            this.kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn.Name = "kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn";
            this.kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiHoshutenkenGyoshaCd";
            this.kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiHoshutenkenGyoshaCd";
            this.kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn.Name = "kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn";
            this.kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn
            // 
            this.kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiHagakiInsatsuzumiKbn";
            this.kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn.HeaderText = "KensaIraiHagakiInsatsuzumiKbn";
            this.kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn.Name = "kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn";
            this.kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // hagakiColDataGridViewTextBoxColumn
            // 
            this.hagakiColDataGridViewTextBoxColumn.DataPropertyName = "hagakiCol";
            this.hagakiColDataGridViewTextBoxColumn.HeaderText = "hagakiCol";
            this.hagakiColDataGridViewTextBoxColumn.Name = "hagakiColDataGridViewTextBoxColumn";
            this.hagakiColDataGridViewTextBoxColumn.ReadOnly = true;
            this.hagakiColDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoChizuNoDataGridViewTextBoxColumn
            // 
            this.jokasoChizuNoDataGridViewTextBoxColumn.DataPropertyName = "JokasoChizuNo";
            this.jokasoChizuNoDataGridViewTextBoxColumn.HeaderText = "JokasoChizuNo";
            this.jokasoChizuNoDataGridViewTextBoxColumn.Name = "jokasoChizuNoDataGridViewTextBoxColumn";
            this.jokasoChizuNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // jokasoHagakiKbnDataGridViewTextBoxColumn
            // 
            this.jokasoHagakiKbnDataGridViewTextBoxColumn.DataPropertyName = "JokasoHagakiKbn";
            this.jokasoHagakiKbnDataGridViewTextBoxColumn.HeaderText = "JokasoHagakiKbn";
            this.jokasoHagakiKbnDataGridViewTextBoxColumn.Name = "jokasoHagakiKbnDataGridViewTextBoxColumn";
            this.jokasoHagakiKbnDataGridViewTextBoxColumn.Visible = false;
            // 
            // shoriHoshikiShubetsuNmDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiShubetsuNm";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.HeaderText = "ShoriHoshikiShubetsuNm";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.Name = "shoriHoshikiShubetsuNmDataGridViewTextBoxColumn";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // constNmDataGridViewTextBoxColumn
            // 
            this.constNmDataGridViewTextBoxColumn.DataPropertyName = "ConstNm";
            this.constNmDataGridViewTextBoxColumn.HeaderText = "ConstNm";
            this.constNmDataGridViewTextBoxColumn.Name = "constNmDataGridViewTextBoxColumn";
            this.constNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn
            // 
            this.kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiJokasoHokenjoCd";
            this.kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn.HeaderText = "KensaIraiJokasoHokenjoCd";
            this.kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn.Name = "kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn";
            this.kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn
            // 
            this.kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiJokasoTorokuNendo";
            this.kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn.HeaderText = "KensaIraiJokasoTorokuNendo";
            this.kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn.Name = "kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn";
            this.kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn.Visible = false;
            // 
            // kensaIraiJokasoRenbanDataGridViewTextBoxColumn
            // 
            this.kensaIraiJokasoRenbanDataGridViewTextBoxColumn.DataPropertyName = "KensaIraiJokasoRenban";
            this.kensaIraiJokasoRenbanDataGridViewTextBoxColumn.HeaderText = "KensaIraiJokasoRenban";
            this.kensaIraiJokasoRenbanDataGridViewTextBoxColumn.Name = "kensaIraiJokasoRenbanDataGridViewTextBoxColumn";
            this.kensaIraiJokasoRenbanDataGridViewTextBoxColumn.Visible = false;
            // 
            // yoteiDtColDataGridViewTextBoxColumn
            // 
            this.yoteiDtColDataGridViewTextBoxColumn.DataPropertyName = "yoteiDtCol";
            this.yoteiDtColDataGridViewTextBoxColumn.HeaderText = "yoteiDtCol";
            this.yoteiDtColDataGridViewTextBoxColumn.Name = "yoteiDtColDataGridViewTextBoxColumn";
            this.yoteiDtColDataGridViewTextBoxColumn.ReadOnly = true;
            this.yoteiDtColDataGridViewTextBoxColumn.Visible = false;
            // 
            // kyokaiNoColDataGridViewTextBoxColumn
            // 
            this.kyokaiNoColDataGridViewTextBoxColumn.DataPropertyName = "kyokaiNoCol";
            this.kyokaiNoColDataGridViewTextBoxColumn.HeaderText = "kyokaiNoCol";
            this.kyokaiNoColDataGridViewTextBoxColumn.Name = "kyokaiNoColDataGridViewTextBoxColumn";
            this.kyokaiNoColDataGridViewTextBoxColumn.ReadOnly = true;
            this.kyokaiNoColDataGridViewTextBoxColumn.Visible = false;
            // 
            // gyoshaNmDataGridViewTextBoxColumn
            // 
            this.gyoshaNmDataGridViewTextBoxColumn.DataPropertyName = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.HeaderText = "GyoshaNm";
            this.gyoshaNmDataGridViewTextBoxColumn.Name = "gyoshaNmDataGridViewTextBoxColumn";
            this.gyoshaNmDataGridViewTextBoxColumn.Visible = false;
            // 
            // JokasoDaichoMstUpdateDtCol
            // 
            this.JokasoDaichoMstUpdateDtCol.DataPropertyName = "JokasoDaichoMstUpdateDt";
            this.JokasoDaichoMstUpdateDtCol.HeaderText = "JokasoDaichoMstUpdateDt";
            this.JokasoDaichoMstUpdateDtCol.Name = "JokasoDaichoMstUpdateDtCol";
            this.JokasoDaichoMstUpdateDtCol.Visible = false;
            // 
            // KensaIraiTblUpdateDtCol
            // 
            this.KensaIraiTblUpdateDtCol.DataPropertyName = "KensaIraiTblUpdateDt";
            this.KensaIraiTblUpdateDtCol.HeaderText = "KensaIraiTblUpdateDt";
            this.KensaIraiTblUpdateDtCol.Name = "KensaIraiTblUpdateDtCol";
            this.KensaIraiTblUpdateDtCol.Visible = false;
            // 
            // JokasoRenbanCol
            // 
            this.JokasoRenbanCol.DataPropertyName = "JokasoRenban";
            this.JokasoRenbanCol.HeaderText = "JokasoRenban";
            this.JokasoRenbanCol.Name = "JokasoRenbanCol";
            this.JokasoRenbanCol.Visible = false;
            // 
            // JokasoHokenjoCdCol
            // 
            this.JokasoHokenjoCdCol.DataPropertyName = "JokasoHokenjoCd";
            this.JokasoHokenjoCdCol.HeaderText = "JokasoHokenjoCd";
            this.JokasoHokenjoCdCol.Name = "JokasoHokenjoCdCol";
            this.JokasoHokenjoCdCol.Visible = false;
            // 
            // JokasoTorokuNendoCol
            // 
            this.JokasoTorokuNendoCol.DataPropertyName = "JokasoTorokuNendo";
            this.JokasoTorokuNendoCol.HeaderText = "JokasoTorokuNendo";
            this.JokasoTorokuNendoCol.Name = "JokasoTorokuNendoCol";
            this.JokasoTorokuNendoCol.Visible = false;
            // 
            // kensaIraiTblDataSetBindingSource
            // 
            this.kensaIraiTblDataSetBindingSource.DataSource = this.kensaIraiTblDataSet;
            this.kensaIraiTblDataSetBindingSource.Position = 0;
            // 
            // kensaIraiTblDataSet
            // 
            this.kensaIraiTblDataSet.DataSetName = "KensaIraiTblDataSet";
            this.kensaIraiTblDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // torikeshiButton
            // 
            this.torikeshiButton.Location = new System.Drawing.Point(476, 544);
            this.torikeshiButton.Name = "torikeshiButton";
            this.torikeshiButton.Size = new System.Drawing.Size(116, 37);
            this.torikeshiButton.TabIndex = 7;
            this.torikeshiButton.Text = "F1:出力済取消";
            this.torikeshiButton.UseVisualStyleBackColor = true;
            this.torikeshiButton.Click += new System.EventHandler(this.torikeshiButton_Click);
            // 
            // srhListPanel
            // 
            this.srhListPanel.Controls.Add(this.srhListCountLabel);
            this.srhListPanel.Controls.Add(this.label4);
            this.srhListPanel.Controls.Add(this.yoteiListDataGridView);
            this.srhListPanel.Location = new System.Drawing.Point(1, 296);
            this.srhListPanel.Name = "srhListPanel";
            this.srhListPanel.Size = new System.Drawing.Size(1090, 242);
            this.srhListPanel.TabIndex = 1;
            // 
            // srhListCountLabel
            // 
            this.srhListCountLabel.AutoSize = true;
            this.srhListCountLabel.Location = new System.Drawing.Point(987, 0);
            this.srhListCountLabel.Name = "srhListCountLabel";
            this.srhListCountLabel.Size = new System.Drawing.Size(30, 20);
            this.srhListCountLabel.TabIndex = 1;
            this.srhListCountLabel.Text = "0件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "検索結果：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "検査種別";
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(868, 544);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(101, 37);
            this.outputButton.TabIndex = 10;
            this.outputButton.Text = "F6:一覧出力";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "検査員";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Location = new System.Drawing.Point(1058, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 42;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            this.viewChangeButton.Click += new System.EventHandler(this.ViewChangeButton_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.shikuchosonComboBox);
            this.searchPanel.Controls.Add(this.kyokaiTo1TextBox);
            this.searchPanel.Controls.Add(this.kyokaiTo2TextBox);
            this.searchPanel.Controls.Add(this.kyokaiTo3TextBox);
            this.searchPanel.Controls.Add(this.kyokaiFrom1TextBox);
            this.searchPanel.Controls.Add(this.kyokaiFrom2TextBox);
            this.searchPanel.Controls.Add(this.kyokaiFrom3TextBox);
            this.searchPanel.Controls.Add(this.ninsoToTextBox);
            this.searchPanel.Controls.Add(this.panel1);
            this.searchPanel.Controls.Add(this.ninsoFromTextBox);
            this.searchPanel.Controls.Add(this.settisyaKanaToTextBox);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.settisyaKanaFromTextBox);
            this.searchPanel.Controls.Add(this.label20);
            this.searchPanel.Controls.Add(this.gyosyaTextBox);
            this.searchPanel.Controls.Add(this.settiAdrTextBox);
            this.searchPanel.Controls.Add(this.kensaYoteiDtToDateTimePicker);
            this.searchPanel.Controls.Add(this.kensaYoteiDtFromDateTimePicker);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.label11);
            this.searchPanel.Controls.Add(this.label18);
            this.searchPanel.Controls.Add(this.label17);
            this.searchPanel.Controls.Add(this.gyosyaSrhButton);
            this.searchPanel.Controls.Add(this.label16);
            this.searchPanel.Controls.Add(this.label9);
            this.searchPanel.Controls.Add(this.kensaMiteiCheckBox);
            this.searchPanel.Controls.Add(this.kensaYoteiDtUseCheckBox);
            this.searchPanel.Controls.Add(this.label14);
            this.searchPanel.Controls.Add(this.label15);
            this.searchPanel.Controls.Add(this.label13);
            this.searchPanel.Controls.Add(this.kensa11JoRadioButton);
            this.searchPanel.Controls.Add(this.kensa7JoRadioButton);
            this.searchPanel.Controls.Add(this.label10);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.kensainComboBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label22);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Location = new System.Drawing.Point(1, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1090, 290);
            this.searchPanel.TabIndex = 0;
            // 
            // shikuchosonComboBox
            // 
            this.shikuchosonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shikuchosonComboBox.FormattingEnabled = true;
            this.shikuchosonComboBox.Location = new System.Drawing.Point(108, 163);
            this.shikuchosonComboBox.Name = "shikuchosonComboBox";
            this.shikuchosonComboBox.Size = new System.Drawing.Size(191, 28);
            this.shikuchosonComboBox.TabIndex = 26;
            // 
            // kyokaiTo1TextBox
            // 
            this.kyokaiTo1TextBox.AllowDropDown = false;
            this.kyokaiTo1TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.kyokaiTo1TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiTo1TextBox.CustomReadOnly = false;
            this.kyokaiTo1TextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kyokaiTo1TextBox.Location = new System.Drawing.Point(307, 100);
            this.kyokaiTo1TextBox.Name = "kyokaiTo1TextBox";
            this.kyokaiTo1TextBox.Size = new System.Drawing.Size(32, 27);
            this.kyokaiTo1TextBox.TabIndex = 12;
            this.kyokaiTo1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kyokaiTo1TextBox.Leave += new System.EventHandler(this.kyokaiTo1TextBox_Leave);
            // 
            // kyokaiTo2TextBox
            // 
            this.kyokaiTo2TextBox.AllowDropDown = false;
            this.kyokaiTo2TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kyokaiTo2TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiTo2TextBox.CustomReadOnly = false;
            this.kyokaiTo2TextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kyokaiTo2TextBox.Location = new System.Drawing.Point(361, 100);
            this.kyokaiTo2TextBox.Name = "kyokaiTo2TextBox";
            this.kyokaiTo2TextBox.Size = new System.Drawing.Size(31, 27);
            this.kyokaiTo2TextBox.TabIndex = 14;
            this.kyokaiTo2TextBox.Leave += new System.EventHandler(this.kyokaiTo2TextBox_Leave);
            // 
            // kyokaiTo3TextBox
            // 
            this.kyokaiTo3TextBox.AllowDropDown = false;
            this.kyokaiTo3TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kyokaiTo3TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiTo3TextBox.CustomReadOnly = false;
            this.kyokaiTo3TextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kyokaiTo3TextBox.Location = new System.Drawing.Point(414, 100);
            this.kyokaiTo3TextBox.Name = "kyokaiTo3TextBox";
            this.kyokaiTo3TextBox.Size = new System.Drawing.Size(59, 27);
            this.kyokaiTo3TextBox.TabIndex = 16;
            this.kyokaiTo3TextBox.Leave += new System.EventHandler(this.kyokaiTo3TextBox_Leave);
            // 
            // kyokaiFrom1TextBox
            // 
            this.kyokaiFrom1TextBox.AllowDropDown = false;
            this.kyokaiFrom1TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.kyokaiFrom1TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiFrom1TextBox.CustomReadOnly = false;
            this.kyokaiFrom1TextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kyokaiFrom1TextBox.Location = new System.Drawing.Point(110, 100);
            this.kyokaiFrom1TextBox.Name = "kyokaiFrom1TextBox";
            this.kyokaiFrom1TextBox.Size = new System.Drawing.Size(32, 27);
            this.kyokaiFrom1TextBox.TabIndex = 6;
            this.kyokaiFrom1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kyokaiFrom1TextBox.Leave += new System.EventHandler(this.kyokaiFrom1TextBox_Leave);
            // 
            // kyokaiFrom2TextBox
            // 
            this.kyokaiFrom2TextBox.AllowDropDown = false;
            this.kyokaiFrom2TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.kyokaiFrom2TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiFrom2TextBox.CustomReadOnly = false;
            this.kyokaiFrom2TextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kyokaiFrom2TextBox.Location = new System.Drawing.Point(164, 100);
            this.kyokaiFrom2TextBox.Name = "kyokaiFrom2TextBox";
            this.kyokaiFrom2TextBox.Size = new System.Drawing.Size(31, 27);
            this.kyokaiFrom2TextBox.TabIndex = 8;
            this.kyokaiFrom2TextBox.Leave += new System.EventHandler(this.kyokaiFrom2TextBox_Leave);
            // 
            // kyokaiFrom3TextBox
            // 
            this.kyokaiFrom3TextBox.AllowDropDown = false;
            this.kyokaiFrom3TextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.kyokaiFrom3TextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.kyokaiFrom3TextBox.CustomReadOnly = false;
            this.kyokaiFrom3TextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.kyokaiFrom3TextBox.Location = new System.Drawing.Point(217, 100);
            this.kyokaiFrom3TextBox.Name = "kyokaiFrom3TextBox";
            this.kyokaiFrom3TextBox.Size = new System.Drawing.Size(59, 27);
            this.kyokaiFrom3TextBox.TabIndex = 10;
            this.kyokaiFrom3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kyokaiFrom3TextBox.Leave += new System.EventHandler(this.kyokaiFrom3TextBox_Leave);
            // 
            // ninsoToTextBox
            // 
            this.ninsoToTextBox.AllowDropDown = false;
            this.ninsoToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.ninsoToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.ninsoToTextBox.CustomReadOnly = false;
            this.ninsoToTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ninsoToTextBox.Location = new System.Drawing.Point(743, 229);
            this.ninsoToTextBox.MaxLength = 5;
            this.ninsoToTextBox.Name = "ninsoToTextBox";
            this.ninsoToTextBox.Size = new System.Drawing.Size(65, 27);
            this.ninsoToTextBox.TabIndex = 39;
            this.ninsoToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ninsoToTextBox.Leave += new System.EventHandler(this.ninsoToTextBox_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.yoteiDtJunRadioButton);
            this.panel1.Controls.Add(this.settibasyoJunRadioButton);
            this.panel1.Controls.Add(this.tizuNoJunRadioButton);
            this.panel1.Controls.Add(this.kyokaiNoJunRadioButton);
            this.panel1.Location = new System.Drawing.Point(646, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 49);
            this.panel1.TabIndex = 18;
            // 
            // yoteiDtJunRadioButton
            // 
            this.yoteiDtJunRadioButton.AutoSize = true;
            this.yoteiDtJunRadioButton.Location = new System.Drawing.Point(202, 19);
            this.yoteiDtJunRadioButton.Name = "yoteiDtJunRadioButton";
            this.yoteiDtJunRadioButton.Size = new System.Drawing.Size(105, 24);
            this.yoteiDtJunRadioButton.TabIndex = 2;
            this.yoteiDtJunRadioButton.Text = "検査予定日順";
            this.yoteiDtJunRadioButton.UseVisualStyleBackColor = true;
            // 
            // settibasyoJunRadioButton
            // 
            this.settibasyoJunRadioButton.AutoSize = true;
            this.settibasyoJunRadioButton.Checked = true;
            this.settibasyoJunRadioButton.Location = new System.Drawing.Point(6, 19);
            this.settibasyoJunRadioButton.Name = "settibasyoJunRadioButton";
            this.settibasyoJunRadioButton.Size = new System.Drawing.Size(92, 24);
            this.settibasyoJunRadioButton.TabIndex = 0;
            this.settibasyoJunRadioButton.TabStop = true;
            this.settibasyoJunRadioButton.Text = "設置場所順";
            this.settibasyoJunRadioButton.UseVisualStyleBackColor = true;
            // 
            // tizuNoJunRadioButton
            // 
            this.tizuNoJunRadioButton.AutoSize = true;
            this.tizuNoJunRadioButton.Location = new System.Drawing.Point(104, 19);
            this.tizuNoJunRadioButton.Name = "tizuNoJunRadioButton";
            this.tizuNoJunRadioButton.Size = new System.Drawing.Size(92, 24);
            this.tizuNoJunRadioButton.TabIndex = 1;
            this.tizuNoJunRadioButton.Text = "地図番号順";
            this.tizuNoJunRadioButton.UseVisualStyleBackColor = true;
            // 
            // kyokaiNoJunRadioButton
            // 
            this.kyokaiNoJunRadioButton.AutoSize = true;
            this.kyokaiNoJunRadioButton.Location = new System.Drawing.Point(313, 19);
            this.kyokaiNoJunRadioButton.Name = "kyokaiNoJunRadioButton";
            this.kyokaiNoJunRadioButton.Size = new System.Drawing.Size(92, 24);
            this.kyokaiNoJunRadioButton.TabIndex = 3;
            this.kyokaiNoJunRadioButton.Text = "検査番号順";
            this.kyokaiNoJunRadioButton.UseVisualStyleBackColor = true;
            // 
            // ninsoFromTextBox
            // 
            this.ninsoFromTextBox.AllowDropDown = false;
            this.ninsoFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZT_STD_NUM;
            this.ninsoFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.ninsoFromTextBox.CustomReadOnly = false;
            this.ninsoFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ninsoFromTextBox.Location = new System.Drawing.Point(644, 229);
            this.ninsoFromTextBox.MaxLength = 5;
            this.ninsoFromTextBox.Name = "ninsoFromTextBox";
            this.ninsoFromTextBox.Size = new System.Drawing.Size(65, 27);
            this.ninsoFromTextBox.TabIndex = 37;
            this.ninsoFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ninsoFromTextBox.Leave += new System.EventHandler(this.ninsoFromTextBox_Leave);
            // 
            // settisyaKanaToTextBox
            // 
            this.settisyaKanaToTextBox.AllowDropDown = false;
            this.settisyaKanaToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZG_STD_NAME;
            this.settisyaKanaToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settisyaKanaToTextBox.CustomReadOnly = false;
            this.settisyaKanaToTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.settisyaKanaToTextBox.Location = new System.Drawing.Point(791, 196);
            this.settisyaKanaToTextBox.MaxLength = 30;
            this.settisyaKanaToTextBox.Name = "settisyaKanaToTextBox";
            this.settisyaKanaToTextBox.Size = new System.Drawing.Size(113, 27);
            this.settisyaKanaToTextBox.TabIndex = 32;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(715, 232);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 20);
            this.label19.TabIndex = 38;
            this.label19.Text = "～";
            // 
            // settisyaKanaFromTextBox
            // 
            this.settisyaKanaFromTextBox.AllowDropDown = false;
            this.settisyaKanaFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZG_STD_NAME;
            this.settisyaKanaFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settisyaKanaFromTextBox.CustomReadOnly = false;
            this.settisyaKanaFromTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.settisyaKanaFromTextBox.Location = new System.Drawing.Point(644, 196);
            this.settisyaKanaFromTextBox.MaxLength = 30;
            this.settisyaKanaFromTextBox.Name = "settisyaKanaFromTextBox";
            this.settisyaKanaFromTextBox.Size = new System.Drawing.Size(113, 27);
            this.settisyaKanaFromTextBox.TabIndex = 30;
            this.settisyaKanaFromTextBox.Leave += new System.EventHandler(this.settisyaKanaFromTextBox_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(560, 233);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 20);
            this.label20.TabIndex = 36;
            this.label20.Text = "人槽";
            // 
            // gyosyaTextBox
            // 
            this.gyosyaTextBox.AllowDropDown = false;
            this.gyosyaTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZG_STD_NAME;
            this.gyosyaTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyosyaTextBox.CustomReadOnly = false;
            this.gyosyaTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.gyosyaTextBox.Location = new System.Drawing.Point(108, 230);
            this.gyosyaTextBox.MaxLength = 40;
            this.gyosyaTextBox.Name = "gyosyaTextBox";
            this.gyosyaTextBox.Size = new System.Drawing.Size(362, 27);
            this.gyosyaTextBox.TabIndex = 34;
            // 
            // settiAdrTextBox
            // 
            this.settiAdrTextBox.AllowDropDown = false;
            this.settiAdrTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.ZG_STD_NAME;
            this.settiAdrTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.settiAdrTextBox.CustomReadOnly = false;
            this.settiAdrTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.settiAdrTextBox.Location = new System.Drawing.Point(108, 197);
            this.settiAdrTextBox.MaxLength = 80;
            this.settiAdrTextBox.Name = "settiAdrTextBox";
            this.settiAdrTextBox.Size = new System.Drawing.Size(362, 27);
            this.settiAdrTextBox.TabIndex = 28;
            // 
            // kensaYoteiDtToDateTimePicker
            // 
            this.kensaYoteiDtToDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kensaYoteiDtToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kensaYoteiDtToDateTimePicker.Location = new System.Drawing.Point(307, 133);
            this.kensaYoteiDtToDateTimePicker.Name = "kensaYoteiDtToDateTimePicker";
            this.kensaYoteiDtToDateTimePicker.Size = new System.Drawing.Size(165, 27);
            this.kensaYoteiDtToDateTimePicker.TabIndex = 23;
            // 
            // kensaYoteiDtFromDateTimePicker
            // 
            this.kensaYoteiDtFromDateTimePicker.CustomFormat = "yyyy年MM月dd日";
            this.kensaYoteiDtFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.kensaYoteiDtFromDateTimePicker.Location = new System.Drawing.Point(110, 133);
            this.kensaYoteiDtFromDateTimePicker.Name = "kensaYoteiDtFromDateTimePicker";
            this.kensaYoteiDtFromDateTimePicker.Size = new System.Drawing.Size(165, 27);
            this.kensaYoteiDtFromDateTimePicker.TabIndex = 21;
            this.kensaYoteiDtFromDateTimePicker.ValueChanged += new System.EventHandler(this.kensaYoteiDtFromDateTimePicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "－";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(338, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "－";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(763, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 20);
            this.label18.TabIndex = 31;
            this.label18.Text = "～";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(560, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 20);
            this.label17.TabIndex = 29;
            this.label17.Text = "設置者カナ";
            // 
            // gyosyaSrhButton
            // 
            this.gyosyaSrhButton.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.gyosyaSrhButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gyosyaSrhButton.Location = new System.Drawing.Point(473, 230);
            this.gyosyaSrhButton.Name = "gyosyaSrhButton";
            this.gyosyaSrhButton.Size = new System.Drawing.Size(29, 26);
            this.gyosyaSrhButton.TabIndex = 35;
            this.gyosyaSrhButton.UseVisualStyleBackColor = true;
            this.gyosyaSrhButton.Click += new System.EventHandler(this.gyosyaSrhButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 233);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "依頼業者";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(562, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "出力順";
            // 
            // kensaMiteiCheckBox
            // 
            this.kensaMiteiCheckBox.AutoSize = true;
            this.kensaMiteiCheckBox.Location = new System.Drawing.Point(478, 134);
            this.kensaMiteiCheckBox.Name = "kensaMiteiCheckBox";
            this.kensaMiteiCheckBox.Size = new System.Drawing.Size(209, 24);
            this.kensaMiteiCheckBox.TabIndex = 24;
            this.kensaMiteiCheckBox.Text = "検査日未定含む(年月での検索)";
            this.kensaMiteiCheckBox.UseVisualStyleBackColor = true;
            // 
            // kensaYoteiDtUseCheckBox
            // 
            this.kensaYoteiDtUseCheckBox.AutoSize = true;
            this.kensaYoteiDtUseCheckBox.Location = new System.Drawing.Point(12, 140);
            this.kensaYoteiDtUseCheckBox.Name = "kensaYoteiDtUseCheckBox";
            this.kensaYoteiDtUseCheckBox.Size = new System.Drawing.Size(15, 14);
            this.kensaYoteiDtUseCheckBox.TabIndex = 19;
            this.kensaYoteiDtUseCheckBox.UseVisualStyleBackColor = true;
            this.kensaYoteiDtUseCheckBox.CheckedChanged += new System.EventHandler(this.kensaYoteiDtUseCheckBox_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(279, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 20);
            this.label14.TabIndex = 22;
            this.label14.Text = "～";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "検査予定日";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "設置住所";
            // 
            // kensa11JoRadioButton
            // 
            this.kensa11JoRadioButton.AutoSize = true;
            this.kensa11JoRadioButton.Location = new System.Drawing.Point(189, 69);
            this.kensa11JoRadioButton.Name = "kensa11JoRadioButton";
            this.kensa11JoRadioButton.Size = new System.Drawing.Size(82, 24);
            this.kensa11JoRadioButton.TabIndex = 4;
            this.kensa11JoRadioButton.Text = "11条検査";
            this.kensa11JoRadioButton.UseVisualStyleBackColor = true;
            this.kensa11JoRadioButton.CheckedChanged += new System.EventHandler(this.kensa11JoRadioButton_CheckedChanged);
            // 
            // kensa7JoRadioButton
            // 
            this.kensa7JoRadioButton.AutoSize = true;
            this.kensa7JoRadioButton.Checked = true;
            this.kensa7JoRadioButton.Location = new System.Drawing.Point(108, 69);
            this.kensa7JoRadioButton.Name = "kensa7JoRadioButton";
            this.kensa7JoRadioButton.Size = new System.Drawing.Size(74, 24);
            this.kensa7JoRadioButton.TabIndex = 3;
            this.kensa7JoRadioButton.TabStop = true;
            this.kensa7JoRadioButton.Text = "7条検査";
            this.kensa7JoRadioButton.UseVisualStyleBackColor = true;
            this.kensa7JoRadioButton.CheckedChanged += new System.EventHandler(this.kensa7JoRadioButton_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "－";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "－";
            // 
            // kensainComboBox
            // 
            this.kensainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kensainComboBox.FormattingEnabled = true;
            this.kensainComboBox.Location = new System.Drawing.Point(108, 39);
            this.kensainComboBox.Name = "kensainComboBox";
            this.kensainComboBox.Size = new System.Drawing.Size(191, 28);
            this.kensainComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "～";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(26, 166);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 20);
            this.label22.TabIndex = 25;
            this.label22.Text = "市区町村";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "検査番号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索条件";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(867, 243);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 40;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // kensakuButton
            // 
            this.kensakuButton.Location = new System.Drawing.Point(974, 242);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 41;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            this.kensakuButton.Click += new System.EventHandler(this.kensakuButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(990, 544);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // hagakiButton
            // 
            this.hagakiButton.Location = new System.Drawing.Point(608, 544);
            this.hagakiButton.Name = "hagakiButton";
            this.hagakiButton.Size = new System.Drawing.Size(108, 37);
            this.hagakiButton.TabIndex = 8;
            this.hagakiButton.Text = "F2:はがき";
            this.hagakiButton.UseVisualStyleBackColor = true;
            this.hagakiButton.Click += new System.EventHandler(this.hagakiButton_Click);
            // 
            // allButton
            // 
            this.allButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.allButton.Location = new System.Drawing.Point(3, 544);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(62, 37);
            this.allButton.TabIndex = 2;
            this.allButton.Text = "↑ALL";
            this.allButton.UseVisualStyleBackColor = false;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // printCntTextBox
            // 
            this.printCntTextBox.Location = new System.Drawing.Point(189, 549);
            this.printCntTextBox.MaxLength = 6;
            this.printCntTextBox.Name = "printCntTextBox";
            this.printCntTextBox.ReadOnly = true;
            this.printCntTextBox.Size = new System.Drawing.Size(65, 27);
            this.printCntTextBox.TabIndex = 5;
            this.printCntTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(135, 552);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "印刷数";
            // 
            // kensaYoteiPrintCheckBox
            // 
            this.kensaYoteiPrintCheckBox.AutoSize = true;
            this.kensaYoteiPrintCheckBox.Location = new System.Drawing.Point(260, 551);
            this.kensaYoteiPrintCheckBox.Name = "kensaYoteiPrintCheckBox";
            this.kensaYoteiPrintCheckBox.Size = new System.Drawing.Size(132, 24);
            this.kensaYoteiPrintCheckBox.TabIndex = 6;
            this.kensaYoteiPrintCheckBox.Text = "検査予定日を印刷";
            this.kensaYoteiPrintCheckBox.UseVisualStyleBackColor = true;
            // 
            // seisoKakuninButton
            // 
            this.seisoKakuninButton.Location = new System.Drawing.Point(722, 544);
            this.seisoKakuninButton.Name = "seisoKakuninButton";
            this.seisoKakuninButton.Size = new System.Drawing.Size(107, 37);
            this.seisoKakuninButton.TabIndex = 9;
            this.seisoKakuninButton.Text = "F3:清掃確認表";
            this.seisoKakuninButton.UseVisualStyleBackColor = true;
            this.seisoKakuninButton.Click += new System.EventHandler(this.seisoKakuninButton_Click);
            // 
            // kaijoButton
            // 
            this.kaijoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.kaijoButton.Location = new System.Drawing.Point(64, 544);
            this.kaijoButton.Name = "kaijoButton";
            this.kaijoButton.Size = new System.Drawing.Size(62, 37);
            this.kaijoButton.TabIndex = 3;
            this.kaijoButton.Text = "解除";
            this.kaijoButton.UseVisualStyleBackColor = false;
            this.kaijoButton.Click += new System.EventHandler(this.kaijoButton_Click);
            // 
            // hagakiSyubetsuTableAdapter
            // 
            this.hagakiSyubetsuTableAdapter.ClearBeforeFill = true;
            // 
            // KensaYoteiListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 593);
            this.Controls.Add(this.kaijoButton);
            this.Controls.Add(this.seisoKakuninButton);
            this.Controls.Add(this.kensaYoteiPrintCheckBox);
            this.Controls.Add(this.printCntTextBox);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.hagakiButton);
            this.Controls.Add(this.torikeshiButton);
            this.Controls.Add(this.srhListPanel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KensaYoteiListForm";
            this.Text = "検査予定一覧";
            this.Load += new System.EventHandler(this.KensaYoteiListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KensaYoteiListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.yoteiListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hagakiSyubetsuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.constMstDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kensaIraiTblDataSet)).EndInit();
            this.srhListPanel.ResumeLayout(false);
            this.srhListPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZDataGridView yoteiListDataGridView;
        private System.Windows.Forms.Button torikeshiButton;
        private System.Windows.Forms.Panel srhListPanel;
        private System.Windows.Forms.Label srhListCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox kensainComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton kensa11JoRadioButton;
        private System.Windows.Forms.RadioButton kensa7JoRadioButton;
        private System.Windows.Forms.Button hagakiButton;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton kyokaiNoJunRadioButton;
        private System.Windows.Forms.RadioButton yoteiDtJunRadioButton;
        private System.Windows.Forms.RadioButton tizuNoJunRadioButton;
        private System.Windows.Forms.RadioButton settibasyoJunRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox kensaMiteiCheckBox;
        private System.Windows.Forms.CheckBox kensaYoteiDtUseCheckBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button gyosyaSrhButton;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox printCntTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox kensaYoteiPrintCheckBox;
        private System.Windows.Forms.Button seisoKakuninButton;
        private System.Windows.Forms.Button kaijoButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private Zynas.Control.ZDate kensaYoteiDtToDateTimePicker;
        private Zynas.Control.ZDate kensaYoteiDtFromDateTimePicker;
        private Control.ZTextBox gyosyaTextBox;
        private Control.ZTextBox settiAdrTextBox;
        private Control.ZTextBox settisyaKanaToTextBox;
        private Control.ZTextBox settisyaKanaFromTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource kensaIraiTblDataSetBindingSource;
        private DataSet.KensaIraiTblDataSet kensaIraiTblDataSet;
        private DataSet.ConstMstDataSet constMstDataSet;
        private System.Windows.Forms.BindingSource hagakiSyubetsuBindingSource;
        private DataSet.ConstMstDataSetTableAdapters.HagakiSyubetsuTableAdapter hagakiSyubetsuTableAdapter;
        private ZTextBox ninsoToTextBox;
        private ZTextBox ninsoFromTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private Control.ZTextBox kyokaiTo1TextBox;
        private Control.ZTextBox kyokaiTo2TextBox;
        private Control.ZTextBox kyokaiTo3TextBox;
        private Control.ZTextBox kyokaiFrom1TextBox;
        private Control.ZTextBox kyokaiFrom2TextBox;
        private Control.ZTextBox kyokaiFrom3TextBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoteiDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyokaiNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn settisyaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn settiBasyoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn chizuNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn syoriHoshikiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ninsoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyosyaCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn hagakiSyubetsuCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hagakiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiHoteiKbnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiHokenjoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiNendoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiRenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiSetchibashoAdrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKensaYoteiNenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKensaYoteiBiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiSetchishaKanaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShoritaishoJininDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiSetchishaNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiShorihoshikiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiKojiGyoshaCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHoshutenkenGyoshaCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiHagakiInsatsuzumiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hagakiColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoChizuNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jokasoHagakiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiShubetsuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn constNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiJokasoHokenjoCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiJokasoTorokuNendoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kensaIraiJokasoRenbanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoteiDtColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyokaiNoColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyoshaNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoDaichoMstUpdateDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaIraiTblUpdateDtCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoRenbanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoHokenjoCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn JokasoTorokuNendoCol;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox shikuchosonComboBox;

    }
}