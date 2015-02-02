namespace TestDataSet
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.logOutputTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.assemblyPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.namespaceTextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "GetDataTestRun";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logOutputTextBox
            // 
            this.logOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logOutputTextBox.Location = new System.Drawing.Point(12, 92);
            this.logOutputTextBox.Multiline = true;
            this.logOutputTextBox.Name = "logOutputTextBox";
            this.logOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logOutputTextBox.Size = new System.Drawing.Size(727, 517);
            this.logOutputTextBox.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "QueryList";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(304, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "DynQueryList";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // assemblyPathTextBox
            // 
            this.assemblyPathTextBox.Location = new System.Drawing.Point(147, 13);
            this.assemblyPathTextBox.Name = "assemblyPathTextBox";
            this.assemblyPathTextBox.Size = new System.Drawing.Size(297, 19);
            this.assemblyPathTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "AssemblyPath";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "DataSetRootNamespace";
            // 
            // namespaceTextBox
            // 
            this.namespaceTextBox.Location = new System.Drawing.Point(147, 38);
            this.namespaceTextBox.Name = "namespaceTextBox";
            this.namespaceTextBox.Size = new System.Drawing.Size(297, 19);
            this.namespaceTextBox.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(450, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "CompareTableType";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "出力結果はCSVとして使用します";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(596, 63);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "CompareTableColCnt";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 621);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.namespaceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assemblyPathTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.logOutputTextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "DataSet整合性チェック";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox logOutputTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox assemblyPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox namespaceTextBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
    }
}

