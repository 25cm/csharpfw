using System;
using System.Windows.Forms;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// カラー選択ダイアログ（仮）
    /// </summary>
    public partial class ColorSelectDialog : Form
    {
        public enum SelectMode
        {
            Color,

            ColorAndStamp,
        }

        public enum ColorMode
        {
            Black,

            Blue,
            
            Red,

            StampB,

            StampS,
        }

        private ColorMode MyColor = ColorMode.Black;

        public ColorMode SelectedColor()
        {
            return MyColor;
        }

        public ColorSelectDialog(Control parentCtrl, SelectMode mode)
        {
            InitializeComponent();


            if (mode == SelectMode.Color)
            {
                stampBButton.Visible = false;
                stampSButton.Visible = false;
                this.Width -= 206; 
            }

            this.Top = parentCtrl.Top + parentCtrl.Height;
            this.Left = parentCtrl.Left;
        }

        private void ok_BlackButton_Click(object sender, EventArgs e)
        {
            MyColor = ColorMode.Black;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ok_BlueButton_Click(object sender, EventArgs e)
        {
            MyColor = ColorMode.Blue;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ok_RedButton_Click(object sender, EventArgs e)
        {
            MyColor = ColorMode.Red;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        
        private void stampBButton_Click(object sender, EventArgs e)
        {
            MyColor = ColorMode.StampB;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void stampSButton_Click(object sender, EventArgs e)
        {
            MyColor = ColorMode.StampS;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
