namespace FukjBizSystem.Application.Boundary.Common
{
    partial class KatashikiMstSearchForm
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
            this.listCountLabel = new System.Windows.Forms.Label();
            this.viewChangeButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.listDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.katashikiMakerCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GyoshaNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiShubetsuKbnTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KatashikiShorihoushikiKbnTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KatashikiShorihoushikiCdTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiShubetsuNmTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiNmTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katashikiMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.katashikiMstDataSet = new FukjBizSystem.Application.DataSet.KatashikiMstDataSet();
            this.listPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.katashikiCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.katashikiCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.katashikiMakerCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.katashikiMakerCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.gyoshaNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.katashikiNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSet)).BeginInit();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listCountLabel
            // 
            this.listCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listCountLabel.AutoSize = true;
            this.listCountLabel.Location = new System.Drawing.Point(622, 4);
            this.listCountLabel.Name = "listCountLabel";
            this.listCountLabel.Size = new System.Drawing.Size(30, 20);
            this.listCountLabel.TabIndex = 1;
            this.listCountLabel.Text = "0件";
            // 
            // viewChangeButton
            // 
            this.viewChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewChangeButton.Location = new System.Drawing.Point(662, 0);
            this.viewChangeButton.Name = "viewChangeButton";
            this.viewChangeButton.Size = new System.Drawing.Size(29, 21);
            this.viewChangeButton.TabIndex = 14;
            this.viewChangeButton.Text = "▲";
            this.viewChangeButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "検索条件";
            // 
            // searchPanel
            // 
            this.searchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPanel.Controls.Add(this.katashikiCdToTextBox);
            this.searchPanel.Controls.Add(this.katashikiCdFromTextBox);
            this.searchPanel.Controls.Add(this.katashikiMakerCdToTextBox);
            this.searchPanel.Controls.Add(this.katashikiMakerCdFromTextBox);
            this.searchPanel.Controls.Add(this.gyoshaNmTextBox);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.katashikiNmTextBox);
            this.searchPanel.Controls.Add(this.label4);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Location = new System.Drawing.Point(6, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(694, 153);
            this.searchPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "メーカー業者名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "型式コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "型式名称";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "メーカー業者コード";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.clearButton.Location = new System.Drawing.Point(482, 113);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // kensakuButton
            // 
            this.kensakuButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kensakuButton.Location = new System.Drawing.Point(589, 112);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 13;
            this.kensakuButton.Text = "F8:検索";
            this.kensakuButton.UseVisualStyleBackColor = true;
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectButton.Location = new System.Drawing.Point(490, 516);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(101, 37);
            this.selectButton.TabIndex = 2;
            this.selectButton.Text = "F1:選択戻り";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // listDataGridView
            // 
            this.listDataGridView.AllowUserToAddRows = false;
            this.listDataGridView.AllowUserToDeleteRows = false;
            this.listDataGridView.AllowUserToResizeRows = false;
            this.listDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDataGridView.AutoGenerateColumns = false;
            this.listDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.katashikiMakerCdDataGridViewTextBoxColumn,
            this.GyoshaNmDataGridViewTextBoxColumn,
            this.katashikiCdDataGridViewTextBoxColumn,
            this.katashikiNmDataGridViewTextBoxColumn,
            this.ShoriHoshikiShubetsuKbnTextBoxColumn,
            this.KatashikiShorihoushikiKbnTextBoxColumn,
            this.KatashikiShorihoushikiCdTextBoxColumn,
            this.ShoriHoshikiShubetsuNmTextBoxColumn,
            this.ShoriHoshikiNmTextBoxColumn});
            this.listDataGridView.DataMember = "KatashikiMstSearch";
            this.listDataGridView.DataSource = this.katashikiMstDataSetBindingSource;
            this.listDataGridView.Location = new System.Drawing.Point(4, 28);
            this.listDataGridView.MultiSelect = false;
            this.listDataGridView.Name = "listDataGridView";
            this.listDataGridView.ReadOnly = true;
            this.listDataGridView.RowHeadersVisible = false;
            this.listDataGridView.RowTemplate.Height = 21;
            this.listDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listDataGridView.Size = new System.Drawing.Size(684, 314);
            this.listDataGridView.TabIndex = 2;
            // 
            // katashikiMakerCdDataGridViewTextBoxColumn
            // 
            this.katashikiMakerCdDataGridViewTextBoxColumn.DataPropertyName = "KatashikiMakerCd";
            this.katashikiMakerCdDataGridViewTextBoxColumn.HeaderText = "メーカーコード";
            this.katashikiMakerCdDataGridViewTextBoxColumn.Name = "katashikiMakerCdDataGridViewTextBoxColumn";
            this.katashikiMakerCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.katashikiMakerCdDataGridViewTextBoxColumn.Width = 150;
            // 
            // GyoshaNmDataGridViewTextBoxColumn
            // 
            this.GyoshaNmDataGridViewTextBoxColumn.DataPropertyName = "GyoshaNm";
            this.GyoshaNmDataGridViewTextBoxColumn.HeaderText = "メーカー名";
            this.GyoshaNmDataGridViewTextBoxColumn.Name = "GyoshaNmDataGridViewTextBoxColumn";
            this.GyoshaNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.GyoshaNmDataGridViewTextBoxColumn.Width = 200;
            // 
            // katashikiCdDataGridViewTextBoxColumn
            // 
            this.katashikiCdDataGridViewTextBoxColumn.DataPropertyName = "KatashikiCd";
            this.katashikiCdDataGridViewTextBoxColumn.HeaderText = "型式コード";
            this.katashikiCdDataGridViewTextBoxColumn.Name = "katashikiCdDataGridViewTextBoxColumn";
            this.katashikiCdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // katashikiNmDataGridViewTextBoxColumn
            // 
            this.katashikiNmDataGridViewTextBoxColumn.DataPropertyName = "KatashikiNm";
            this.katashikiNmDataGridViewTextBoxColumn.HeaderText = "型式名称";
            this.katashikiNmDataGridViewTextBoxColumn.Name = "katashikiNmDataGridViewTextBoxColumn";
            this.katashikiNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.katashikiNmDataGridViewTextBoxColumn.Width = 200;
            // 
            // ShoriHoshikiShubetsuKbnTextBoxColumn
            // 
            this.ShoriHoshikiShubetsuKbnTextBoxColumn.DataPropertyName = "ShoriHoshikiShubetsuKbn";
            this.ShoriHoshikiShubetsuKbnTextBoxColumn.HeaderText = "ShoriHoshikiShubetsuKbn";
            this.ShoriHoshikiShubetsuKbnTextBoxColumn.Name = "ShoriHoshikiShubetsuKbnTextBoxColumn";
            this.ShoriHoshikiShubetsuKbnTextBoxColumn.ReadOnly = true;
            this.ShoriHoshikiShubetsuKbnTextBoxColumn.Visible = false;
            // 
            // KatashikiShorihoushikiKbnTextBoxColumn
            // 
            this.KatashikiShorihoushikiKbnTextBoxColumn.DataPropertyName = "KatashikiShorihoushikiKbn";
            this.KatashikiShorihoushikiKbnTextBoxColumn.HeaderText = "KatashikiShorihoushikiKbn";
            this.KatashikiShorihoushikiKbnTextBoxColumn.Name = "KatashikiShorihoushikiKbnTextBoxColumn";
            this.KatashikiShorihoushikiKbnTextBoxColumn.ReadOnly = true;
            this.KatashikiShorihoushikiKbnTextBoxColumn.Visible = false;
            // 
            // KatashikiShorihoushikiCdTextBoxColumn
            // 
            this.KatashikiShorihoushikiCdTextBoxColumn.DataPropertyName = "KatashikiShorihoushikiCd";
            this.KatashikiShorihoushikiCdTextBoxColumn.HeaderText = "KatashikiShorihoushikiCd";
            this.KatashikiShorihoushikiCdTextBoxColumn.Name = "KatashikiShorihoushikiCdTextBoxColumn";
            this.KatashikiShorihoushikiCdTextBoxColumn.ReadOnly = true;
            this.KatashikiShorihoushikiCdTextBoxColumn.Visible = false;
            // 
            // ShoriHoshikiShubetsuNmTextBoxColumn
            // 
            this.ShoriHoshikiShubetsuNmTextBoxColumn.DataPropertyName = "ShoriHoshikiShubetsuNm";
            this.ShoriHoshikiShubetsuNmTextBoxColumn.HeaderText = "ShoriHoshikiShubetsuNm";
            this.ShoriHoshikiShubetsuNmTextBoxColumn.Name = "ShoriHoshikiShubetsuNmTextBoxColumn";
            this.ShoriHoshikiShubetsuNmTextBoxColumn.ReadOnly = true;
            this.ShoriHoshikiShubetsuNmTextBoxColumn.Visible = false;
            // 
            // ShoriHoshikiNmTextBoxColumn
            // 
            this.ShoriHoshikiNmTextBoxColumn.DataPropertyName = "ShoriHoshikiNm";
            this.ShoriHoshikiNmTextBoxColumn.HeaderText = "ShoriHoshikiNm";
            this.ShoriHoshikiNmTextBoxColumn.Name = "ShoriHoshikiNmTextBoxColumn";
            this.ShoriHoshikiNmTextBoxColumn.ReadOnly = true;
            this.ShoriHoshikiNmTextBoxColumn.Visible = false;
            // 
            // katashikiMstDataSetBindingSource
            // 
            this.katashikiMstDataSetBindingSource.DataSource = this.katashikiMstDataSet;
            this.katashikiMstDataSetBindingSource.Position = 0;
            // 
            // katashikiMstDataSet
            // 
            this.katashikiMstDataSet.DataSetName = "KatashikiMstDataSet";
            this.katashikiMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listPanel
            // 
            this.listPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPanel.Controls.Add(this.listCountLabel);
            this.listPanel.Controls.Add(this.label1);
            this.listPanel.Controls.Add(this.listDataGridView);
            this.listPanel.Location = new System.Drawing.Point(6, 161);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(696, 350);
            this.listPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索結果：";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(598, 516);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(101, 37);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "F12:閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // katashikiCdToTextBox
            // 
            this.katashikiCdToTextBox.AllowDropDown = false;
            this.katashikiCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.katashikiCdToTextBox.CustomReadOnly = false;
            this.katashikiCdToTextBox.Location = new System.Drawing.Point(542, 37);
            this.katashikiCdToTextBox.MaxLength = 4;
            this.katashikiCdToTextBox.Name = "katashikiCdToTextBox";
            this.katashikiCdToTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiCdToTextBox.TabIndex = 9;
            // 
            // katashikiCdFromTextBox
            // 
            this.katashikiCdFromTextBox.AllowDropDown = false;
            this.katashikiCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.katashikiCdFromTextBox.CustomReadOnly = false;
            this.katashikiCdFromTextBox.Location = new System.Drawing.Point(449, 37);
            this.katashikiCdFromTextBox.MaxLength = 4;
            this.katashikiCdFromTextBox.Name = "katashikiCdFromTextBox";
            this.katashikiCdFromTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiCdFromTextBox.TabIndex = 7;
            // 
            // katashikiMakerCdToTextBox
            // 
            this.katashikiMakerCdToTextBox.AllowDropDown = false;
            this.katashikiMakerCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiMakerCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.katashikiMakerCdToTextBox.CustomReadOnly = false;
            this.katashikiMakerCdToTextBox.Location = new System.Drawing.Point(234, 37);
            this.katashikiMakerCdToTextBox.MaxLength = 4;
            this.katashikiMakerCdToTextBox.Name = "katashikiMakerCdToTextBox";
            this.katashikiMakerCdToTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiMakerCdToTextBox.TabIndex = 3;
            // 
            // katashikiMakerCdFromTextBox
            // 
            this.katashikiMakerCdFromTextBox.AllowDropDown = false;
            this.katashikiMakerCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiMakerCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.katashikiMakerCdFromTextBox.CustomReadOnly = false;
            this.katashikiMakerCdFromTextBox.Location = new System.Drawing.Point(141, 37);
            this.katashikiMakerCdFromTextBox.MaxLength = 4;
            this.katashikiMakerCdFromTextBox.Name = "katashikiMakerCdFromTextBox";
            this.katashikiMakerCdFromTextBox.Size = new System.Drawing.Size(59, 27);
            this.katashikiMakerCdFromTextBox.TabIndex = 1;
            // 
            // gyoshaNmTextBox
            // 
            this.gyoshaNmTextBox.AllowDropDown = false;
            this.gyoshaNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.gyoshaNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.gyoshaNmTextBox.CustomReadOnly = false;
            this.gyoshaNmTextBox.Location = new System.Drawing.Point(141, 70);
            this.gyoshaNmTextBox.MaxLength = 40;
            this.gyoshaNmTextBox.Name = "gyoshaNmTextBox";
            this.gyoshaNmTextBox.Size = new System.Drawing.Size(221, 27);
            this.gyoshaNmTextBox.TabIndex = 5;
            // 
            // katashikiNmTextBox
            // 
            this.katashikiNmTextBox.AllowDropDown = false;
            this.katashikiNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.katashikiNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.katashikiNmTextBox.CustomReadOnly = false;
            this.katashikiNmTextBox.Location = new System.Drawing.Point(449, 70);
            this.katashikiNmTextBox.MaxLength = 20;
            this.katashikiNmTextBox.Name = "katashikiNmTextBox";
            this.katashikiNmTextBox.Size = new System.Drawing.Size(221, 27);
            this.katashikiNmTextBox.TabIndex = 11;
            // 
            // KatashikiMstSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 562);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 300);
            this.Name = "KatashikiMstSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "型式マスタ検索";
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.katashikiMstDataSet)).EndInit();
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label listCountLabel;
        private System.Windows.Forms.Button viewChangeButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button kensakuButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.BindingSource katashikiMstDataSetBindingSource;
        private DataSet.KatashikiMstDataSet katashikiMstDataSet;
        private Control.ZTextBox katashikiCdToTextBox;
        private Control.ZTextBox katashikiCdFromTextBox;
        private Control.ZTextBox katashikiMakerCdToTextBox;
        private Control.ZTextBox katashikiMakerCdFromTextBox;
        private Control.ZTextBox gyoshaNmTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private Control.ZTextBox katashikiNmTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private Zynas.Control.ZDataGridView.ZDataGridView listDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiMakerCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GyoshaNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn katashikiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiShubetsuKbnTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KatashikiShorihoushikiKbnTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KatashikiShorihoushikiCdTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiShubetsuNmTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiNmTextBoxColumn;
    }
}