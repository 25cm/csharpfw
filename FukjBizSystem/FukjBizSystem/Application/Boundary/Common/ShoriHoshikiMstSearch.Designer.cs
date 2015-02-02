namespace FukjBizSystem.Application.Boundary.Common
{
    partial class ShoriHoshikiMstSearchForm
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
            this.shoriHoshikiNmTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.shoriHoshikiCdToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.shoriHoshikiCdFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.shoriHoshikiKbnToTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.shoriHoshikiKbnFromTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.kensakuButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.listDataGridView = new Zynas.Control.ZDataGridView.ZDataGridView(this.components);
            this.shoriHoshikiKbnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiCdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShoriHoshikiShubetsuKbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriHoshikiMstDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shoriHoshikiMstDataSet = new FukjBizSystem.Application.DataSet.ShoriHoshikiMstDataSet();
            this.listPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSet)).BeginInit();
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
            this.viewChangeButton.TabIndex = 12;
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
            this.searchPanel.Controls.Add(this.shoriHoshikiNmTextBox);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.shoriHoshikiCdToTextBox);
            this.searchPanel.Controls.Add(this.shoriHoshikiCdFromTextBox);
            this.searchPanel.Controls.Add(this.shoriHoshikiKbnToTextBox);
            this.searchPanel.Controls.Add(this.shoriHoshikiKbnFromTextBox);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.kensakuButton);
            this.searchPanel.Controls.Add(this.viewChangeButton);
            this.searchPanel.Controls.Add(this.label8);
            this.searchPanel.Location = new System.Drawing.Point(6, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(694, 130);
            this.searchPanel.TabIndex = 0;
            // 
            // shoriHoshikiNmTextBox
            // 
            this.shoriHoshikiNmTextBox.AllowDropDown = false;
            this.shoriHoshikiNmTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiNmTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shoriHoshikiNmTextBox.CustomReadOnly = false;
            this.shoriHoshikiNmTextBox.Location = new System.Drawing.Point(342, 37);
            this.shoriHoshikiNmTextBox.MaxLength = 80;
            this.shoriHoshikiNmTextBox.Name = "shoriHoshikiNmTextBox";
            this.shoriHoshikiNmTextBox.Size = new System.Drawing.Size(187, 27);
            this.shoriHoshikiNmTextBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "処理方式名";
            // 
            // shoriHoshikiCdToTextBox
            // 
            this.shoriHoshikiCdToTextBox.AllowDropDown = false;
            this.shoriHoshikiCdToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiCdToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shoriHoshikiCdToTextBox.CustomReadOnly = false;
            this.shoriHoshikiCdToTextBox.Location = new System.Drawing.Point(210, 69);
            this.shoriHoshikiCdToTextBox.MaxLength = 3;
            this.shoriHoshikiCdToTextBox.Name = "shoriHoshikiCdToTextBox";
            this.shoriHoshikiCdToTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiCdToTextBox.TabIndex = 7;
            // 
            // shoriHoshikiCdFromTextBox
            // 
            this.shoriHoshikiCdFromTextBox.AllowDropDown = false;
            this.shoriHoshikiCdFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiCdFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shoriHoshikiCdFromTextBox.CustomReadOnly = false;
            this.shoriHoshikiCdFromTextBox.Location = new System.Drawing.Point(136, 69);
            this.shoriHoshikiCdFromTextBox.MaxLength = 3;
            this.shoriHoshikiCdFromTextBox.Name = "shoriHoshikiCdFromTextBox";
            this.shoriHoshikiCdFromTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiCdFromTextBox.TabIndex = 5;
            // 
            // shoriHoshikiKbnToTextBox
            // 
            this.shoriHoshikiKbnToTextBox.AllowDropDown = false;
            this.shoriHoshikiKbnToTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiKbnToTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shoriHoshikiKbnToTextBox.CustomReadOnly = false;
            this.shoriHoshikiKbnToTextBox.Location = new System.Drawing.Point(210, 37);
            this.shoriHoshikiKbnToTextBox.MaxLength = 1;
            this.shoriHoshikiKbnToTextBox.Name = "shoriHoshikiKbnToTextBox";
            this.shoriHoshikiKbnToTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiKbnToTextBox.TabIndex = 3;
            // 
            // shoriHoshikiKbnFromTextBox
            // 
            this.shoriHoshikiKbnFromTextBox.AllowDropDown = false;
            this.shoriHoshikiKbnFromTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.shoriHoshikiKbnFromTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.shoriHoshikiKbnFromTextBox.CustomReadOnly = false;
            this.shoriHoshikiKbnFromTextBox.Location = new System.Drawing.Point(136, 37);
            this.shoriHoshikiKbnFromTextBox.MaxLength = 1;
            this.shoriHoshikiKbnFromTextBox.Name = "shoriHoshikiKbnFromTextBox";
            this.shoriHoshikiKbnFromTextBox.Size = new System.Drawing.Size(40, 27);
            this.shoriHoshikiKbnFromTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "～";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "処理方式区分";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "～";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "処理方式コード";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.clearButton.Location = new System.Drawing.Point(482, 90);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 37);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "F7:クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // kensakuButton
            // 
            this.kensakuButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kensakuButton.Location = new System.Drawing.Point(589, 89);
            this.kensakuButton.Name = "kensakuButton";
            this.kensakuButton.Size = new System.Drawing.Size(101, 37);
            this.kensakuButton.TabIndex = 11;
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
            this.shoriHoshikiKbnDataGridViewTextBoxColumn,
            this.shoriHoshikiCdDataGridViewTextBoxColumn,
            this.shoriHoshikiNmDataGridViewTextBoxColumn,
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn,
            this.ShoriHoshikiShubetsuKbn});
            this.listDataGridView.DataMember = "ShoriHoshikiMstKensaku";
            this.listDataGridView.DataSource = this.shoriHoshikiMstDataSetBindingSource;
            this.listDataGridView.Location = new System.Drawing.Point(4, 28);
            this.listDataGridView.MultiSelect = false;
            this.listDataGridView.Name = "listDataGridView";
            this.listDataGridView.ReadOnly = true;
            this.listDataGridView.RowHeadersVisible = false;
            this.listDataGridView.RowTemplate.Height = 21;
            this.listDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listDataGridView.Size = new System.Drawing.Size(684, 334);
            this.listDataGridView.TabIndex = 2;
            // 
            // shoriHoshikiKbnDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiKbn";
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.HeaderText = "処理方式区分";
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.Name = "shoriHoshikiKbnDataGridViewTextBoxColumn";
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.ReadOnly = true;
            this.shoriHoshikiKbnDataGridViewTextBoxColumn.Width = 120;
            // 
            // shoriHoshikiCdDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiCdDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiCd";
            this.shoriHoshikiCdDataGridViewTextBoxColumn.HeaderText = "処理方式コード";
            this.shoriHoshikiCdDataGridViewTextBoxColumn.Name = "shoriHoshikiCdDataGridViewTextBoxColumn";
            this.shoriHoshikiCdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shoriHoshikiCdDataGridViewTextBoxColumn.Width = 140;
            // 
            // shoriHoshikiNmDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiNmDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiNm";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.HeaderText = "処理方式名";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.Name = "shoriHoshikiNmDataGridViewTextBoxColumn";
            this.shoriHoshikiNmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shoriHoshikiShubetsuNmDataGridViewTextBoxColumn
            // 
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.DataPropertyName = "ShoriHoshikiShubetsuNm";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.HeaderText = "処理方式種別名";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.Name = "shoriHoshikiShubetsuNmDataGridViewTextBoxColumn";
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.ReadOnly = true;
            this.shoriHoshikiShubetsuNmDataGridViewTextBoxColumn.Width = 140;
            // 
            // ShoriHoshikiShubetsuKbn
            // 
            this.ShoriHoshikiShubetsuKbn.DataPropertyName = "ShoriHoshikiShubetsuKbn";
            this.ShoriHoshikiShubetsuKbn.HeaderText = "ShoriHoshikiShubetsuKbn";
            this.ShoriHoshikiShubetsuKbn.Name = "ShoriHoshikiShubetsuKbn";
            this.ShoriHoshikiShubetsuKbn.ReadOnly = true;
            this.ShoriHoshikiShubetsuKbn.Visible = false;
            // 
            // shoriHoshikiMstDataSetBindingSource
            // 
            this.shoriHoshikiMstDataSetBindingSource.DataSource = this.shoriHoshikiMstDataSet;
            this.shoriHoshikiMstDataSetBindingSource.Position = 0;
            // 
            // shoriHoshikiMstDataSet
            // 
            this.shoriHoshikiMstDataSet.DataSetName = "ShoriHoshikiMst";
            this.shoriHoshikiMstDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listPanel
            // 
            this.listPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPanel.Controls.Add(this.listCountLabel);
            this.listPanel.Controls.Add(this.label1);
            this.listPanel.Controls.Add(this.listDataGridView);
            this.listPanel.Location = new System.Drawing.Point(6, 138);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(696, 370);
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
            // ShoriHoshikiMstSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 562);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 300);
            this.Name = "ShoriHoshikiMstSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "処理方式マスタ検索";
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoriHoshikiMstDataSet)).EndInit();
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
        private Zynas.Control.ZDataGridView.ZDataGridView listDataGridView;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private Control.ZTextBox shoriHoshikiCdToTextBox;
        private Control.ZTextBox shoriHoshikiCdFromTextBox;
        private Control.ZTextBox shoriHoshikiKbnToTextBox;
        private Control.ZTextBox shoriHoshikiKbnFromTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private Control.ZTextBox shoriHoshikiNmTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource shoriHoshikiMstDataSetBindingSource;
        private DataSet.ShoriHoshikiMstDataSet shoriHoshikiMstDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiKbnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriHoshikiShubetsuNmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShoriHoshikiShubetsuKbn;
    }
}