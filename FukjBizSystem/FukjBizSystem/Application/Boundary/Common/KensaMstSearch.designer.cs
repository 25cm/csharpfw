namespace FukjBizSystem.Application.Boundary.Common
{
    partial class KensaMstSearchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tojiruButton = new System.Windows.Forms.Button();
            this.torokuButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuishistuListDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SelectCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SetTanCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaCdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KensaNmCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ryokin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ninso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kensa7JoGappei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kensa11JoTandoku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kensa11JoGappei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuishistuListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tojiruButton
            // 
            this.tojiruButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tojiruButton.Location = new System.Drawing.Point(993, 613);
            this.tojiruButton.Name = "tojiruButton";
            this.tojiruButton.Size = new System.Drawing.Size(101, 37);
            this.tojiruButton.TabIndex = 19;
            this.tojiruButton.Text = "F12:閉じる";
            this.tojiruButton.UseVisualStyleBackColor = true;
            this.tojiruButton.Click += new System.EventHandler(this.tojiruButton_Click);
            // 
            // torokuButton
            // 
            this.torokuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.torokuButton.Location = new System.Drawing.Point(885, 613);
            this.torokuButton.Name = "torokuButton";
            this.torokuButton.Size = new System.Drawing.Size(101, 37);
            this.torokuButton.TabIndex = 16;
            this.torokuButton.Text = "F1:選択戻り";
            this.torokuButton.UseVisualStyleBackColor = true;
            this.torokuButton.Click += new System.EventHandler(this.torokuButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(15, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "対象浄化槽";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.SuishistuListDataGridView);
            this.searchPanel.Controls.Add(this.dataGridView1);
            this.searchPanel.Controls.Add(this.label7);
            this.searchPanel.Controls.Add(this.textBox1);
            this.searchPanel.Controls.Add(this.button2);
            this.searchPanel.Controls.Add(this.textBox2);
            this.searchPanel.Controls.Add(this.label19);
            this.searchPanel.Location = new System.Drawing.Point(1, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1103, 605);
            this.searchPanel.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(15, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 159;
            this.label2.Text = "水質検査";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 158;
            this.label1.Text = "法定検査";
            // 
            // SuishistuListDataGridView
            // 
            this.SuishistuListDataGridView.AllowUserToAddRows = false;
            this.SuishistuListDataGridView.AllowUserToDeleteRows = false;
            this.SuishistuListDataGridView.AllowUserToResizeRows = false;
            this.SuishistuListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SuishistuListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SuishistuListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectCol,
            this.SetTanCol,
            this.KensaCdCol,
            this.KensaNmCol,
            this.Ryokin});
            this.SuishistuListDataGridView.Location = new System.Drawing.Point(129, 288);
            this.SuishistuListDataGridView.MultiSelect = false;
            this.SuishistuListDataGridView.Name = "SuishistuListDataGridView";
            this.SuishistuListDataGridView.RowHeadersVisible = false;
            this.SuishistuListDataGridView.RowTemplate.Height = 21;
            this.SuishistuListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SuishistuListDataGridView.Size = new System.Drawing.Size(913, 314);
            this.SuishistuListDataGridView.TabIndex = 157;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ninso,
            this.Kensa7JoGappei,
            this.Kensa11JoTandoku,
            this.Kensa11JoGappei});
            this.dataGridView1.Location = new System.Drawing.Point(129, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(589, 239);
            this.dataGridView1.TabIndex = 156;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(106, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 155;
            this.label7.Text = "*";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox1.Location = new System.Drawing.Point(387, 10);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(383, 27);
            this.textBox1.TabIndex = 154;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::FukjBizSystem.Properties.Resources.icon_search;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(785, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 26);
            this.button2.TabIndex = 153;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox2.Location = new System.Drawing.Point(129, 10);
            this.textBox2.MaxLength = 20;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(252, 27);
            this.textBox2.TabIndex = 152;
            // 
            // SelectCol
            // 
            this.SelectCol.HeaderText = "選択";
            this.SelectCol.MinimumWidth = 80;
            this.SelectCol.Name = "SelectCol";
            this.SelectCol.ReadOnly = true;
            this.SelectCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectCol.Width = 80;
            // 
            // SetTanCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SetTanCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.SetTanCol.HeaderText = "セット/単";
            this.SetTanCol.MinimumWidth = 100;
            this.SetTanCol.Name = "SetTanCol";
            this.SetTanCol.ReadOnly = true;
            // 
            // KensaCdCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.KensaCdCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.KensaCdCol.HeaderText = "コード";
            this.KensaCdCol.MinimumWidth = 100;
            this.KensaCdCol.Name = "KensaCdCol";
            this.KensaCdCol.ReadOnly = true;
            // 
            // KensaNmCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.KensaNmCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.KensaNmCol.HeaderText = "検査名";
            this.KensaNmCol.MinimumWidth = 500;
            this.KensaNmCol.Name = "KensaNmCol";
            this.KensaNmCol.ReadOnly = true;
            this.KensaNmCol.Width = 500;
            // 
            // Ryokin
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Ryokin.DefaultCellStyle = dataGridViewCellStyle4;
            this.Ryokin.HeaderText = "検査料金";
            this.Ryokin.Name = "Ryokin";
            // 
            // Ninso
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Ninso.DefaultCellStyle = dataGridViewCellStyle5;
            this.Ninso.HeaderText = "人槽区分(人)";
            this.Ninso.MinimumWidth = 130;
            this.Ninso.Name = "Ninso";
            this.Ninso.ReadOnly = true;
            this.Ninso.Width = 130;
            // 
            // Kensa7JoGappei
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Kensa7JoGappei.DefaultCellStyle = dataGridViewCellStyle6;
            this.Kensa7JoGappei.HeaderText = "7条検査(合併)";
            this.Kensa7JoGappei.MinimumWidth = 150;
            this.Kensa7JoGappei.Name = "Kensa7JoGappei";
            this.Kensa7JoGappei.ReadOnly = true;
            this.Kensa7JoGappei.Width = 150;
            // 
            // Kensa11JoTandoku
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Kensa11JoTandoku.DefaultCellStyle = dataGridViewCellStyle7;
            this.Kensa11JoTandoku.HeaderText = "11条検査(単独)";
            this.Kensa11JoTandoku.MinimumWidth = 150;
            this.Kensa11JoTandoku.Name = "Kensa11JoTandoku";
            this.Kensa11JoTandoku.ReadOnly = true;
            this.Kensa11JoTandoku.Width = 150;
            // 
            // Kensa11JoGappei
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Kensa11JoGappei.DefaultCellStyle = dataGridViewCellStyle8;
            this.Kensa11JoGappei.HeaderText = "11条検査(合併)";
            this.Kensa11JoGappei.MinimumWidth = 150;
            this.Kensa11JoGappei.Name = "Kensa11JoGappei";
            this.Kensa11JoGappei.ReadOnly = true;
            this.Kensa11JoGappei.Width = 150;
            // 
            // KensaMstSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 662);
            this.Controls.Add(this.tojiruButton);
            this.Controls.Add(this.torokuButton);
            this.Controls.Add(this.searchPanel);
            this.Font = new System.Drawing.Font("メイリオ", 10F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1103, 700);
            this.Name = "KensaMstSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "検査検索";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaisuiinMstListForm_KeyDown);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuishistuListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tojiruButton;
        private System.Windows.Forms.Button torokuButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SuishistuListDataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetTanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaCdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KensaNmCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ryokin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ninso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kensa7JoGappei;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kensa11JoTandoku;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kensa11JoGappei;
    }
}