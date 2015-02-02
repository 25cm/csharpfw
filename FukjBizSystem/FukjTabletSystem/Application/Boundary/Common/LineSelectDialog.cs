using System;
using System.Windows.Forms;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// 線種選択ダイアログ（仮）
    /// </summary>
    public partial class LineSelectDialog : Form
    {
        public enum LineMode
        {
            Straight,

            Arrow,
            
            Rectangle,
        }

        private LineMode MyLine = LineMode.Straight;

        public LineMode SelectedLine()
        {
            return MyLine;
        }

        public LineSelectDialog(Control parentCtrl)
        {
            InitializeComponent();

            this.Top = parentCtrl.Top + parentCtrl.Height;
            this.Left = parentCtrl.Left;
        }

        private void ok_StraightButton_Click(object sender, EventArgs e)
        {
            MyLine = LineMode.Straight;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ok_ArrowButton_Click(object sender, EventArgs e)
        {
            MyLine = LineMode.Arrow;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ok_RectangleButton_Click(object sender, EventArgs e)
        {
            MyLine = LineMode.Rectangle;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
