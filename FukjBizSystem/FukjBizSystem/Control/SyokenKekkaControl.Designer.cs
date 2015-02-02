namespace FukjBizSystem.Control
{
    partial class SyokenKekkaControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.itemNoLabel = new System.Windows.Forms.Label();
            this.wdUpButton = new Zynas.Control.ZButton(this.components);
            this.mstSearchButton = new Zynas.Control.ZButton(this.components);
            this.delButton = new Zynas.Control.ZButton(this.components);
            this.syokenWdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.syokenCdTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.syokenKbnTextBox = new FukjBizSystem.Control.ZTextBox(this.components);
            this.SuspendLayout();
            // 
            // itemNoLabel
            // 
            this.itemNoLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemNoLabel.Location = new System.Drawing.Point(0, 0);
            this.itemNoLabel.Name = "itemNoLabel";
            this.itemNoLabel.Size = new System.Drawing.Size(24, 20);
            this.itemNoLabel.TabIndex = 0;
            this.itemNoLabel.Text = "0";
            this.itemNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // wdUpButton
            // 
            this.wdUpButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wdUpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.wdUpButton.Location = new System.Drawing.Point(1086, 0);
            this.wdUpButton.Name = "wdUpButton";
            this.wdUpButton.Size = new System.Drawing.Size(20, 20);
            this.wdUpButton.TabIndex = 5;
            this.wdUpButton.Text = "↑";
            this.wdUpButton.UseVisualStyleBackColor = true;
            this.wdUpButton.Click += new System.EventHandler(this.wdUpButton_Click);
            // 
            // mstSearchButton
            // 
            this.mstSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mstSearchButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mstSearchButton.Image = global::FukjBizSystem.Properties.Resources.icon_search_small;
            this.mstSearchButton.Location = new System.Drawing.Point(88, 0);
            this.mstSearchButton.Name = "mstSearchButton";
            this.mstSearchButton.Size = new System.Drawing.Size(20, 20);
            this.mstSearchButton.TabIndex = 3;
            this.mstSearchButton.UseVisualStyleBackColor = true;
            this.mstSearchButton.Click += new System.EventHandler(this.mstSearchButton_Click);
            // 
            // delButton
            // 
            this.delButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.delButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.delButton.Location = new System.Drawing.Point(1106, 0);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(20, 20);
            this.delButton.TabIndex = 6;
            this.delButton.Text = "×";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // syokenWdTextBox
            // 
            this.syokenWdTextBox.AllowDropDown = false;
            this.syokenWdTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.syokenWdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.syokenWdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.syokenWdTextBox.CustomReadOnly = true;
            this.syokenWdTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.syokenWdTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.syokenWdTextBox.Location = new System.Drawing.Point(110, 0);
            this.syokenWdTextBox.MaxLength = 2;
            this.syokenWdTextBox.Name = "syokenWdTextBox";
            this.syokenWdTextBox.ReadOnly = true;
            this.syokenWdTextBox.Size = new System.Drawing.Size(976, 20);
            this.syokenWdTextBox.TabIndex = 4;
            this.syokenWdTextBox.TabStop = false;
            // 
            // syokenCdTextBox
            // 
            this.syokenCdTextBox.AllowDropDown = false;
            this.syokenCdTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.syokenCdTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.syokenCdTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.syokenCdTextBox.CustomReadOnly = false;
            this.syokenCdTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.syokenCdTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.syokenCdTextBox.Location = new System.Drawing.Point(56, 0);
            this.syokenCdTextBox.MaxLength = 2;
            this.syokenCdTextBox.Name = "syokenCdTextBox";
            this.syokenCdTextBox.ReadOnly = true;
            this.syokenCdTextBox.Size = new System.Drawing.Size(32, 20);
            this.syokenCdTextBox.TabIndex = 2;
            this.syokenCdTextBox.TabStop = false;
            this.syokenCdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // syokenKbnTextBox
            // 
            this.syokenKbnTextBox.AllowDropDown = false;
            this.syokenKbnTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.syokenKbnTextBox.CustomControlDomain = Zynas.Control.Common.ZControlDomain.NONE;
            this.syokenKbnTextBox.CustomInputMode = FukjBizSystem.Control.ZTextBox.InputMode.None;
            this.syokenKbnTextBox.CustomReadOnly = false;
            this.syokenKbnTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.syokenKbnTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.syokenKbnTextBox.Location = new System.Drawing.Point(24, 0);
            this.syokenKbnTextBox.MaxLength = 2;
            this.syokenKbnTextBox.Name = "syokenKbnTextBox";
            this.syokenKbnTextBox.ReadOnly = true;
            this.syokenKbnTextBox.Size = new System.Drawing.Size(32, 20);
            this.syokenKbnTextBox.TabIndex = 1;
            this.syokenKbnTextBox.TabStop = false;
            this.syokenKbnTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SyokenKekkaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.syokenWdTextBox);
            this.Controls.Add(this.syokenCdTextBox);
            this.Controls.Add(this.syokenKbnTextBox);
            this.Controls.Add(this.wdUpButton);
            this.Controls.Add(this.mstSearchButton);
            this.Controls.Add(this.itemNoLabel);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SyokenKekkaControl";
            this.Size = new System.Drawing.Size(1127, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemNoLabel;
        private Zynas.Control.ZButton mstSearchButton;
        private Zynas.Control.ZButton wdUpButton;
        private ZTextBox syokenKbnTextBox;
        private ZTextBox syokenCdTextBox;
        private ZTextBox syokenWdTextBox;
        private Zynas.Control.ZButton delButton;

    }
}
