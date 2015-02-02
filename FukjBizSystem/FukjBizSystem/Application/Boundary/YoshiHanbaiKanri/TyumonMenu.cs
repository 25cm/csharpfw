using System;
using System.Drawing;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    public partial class TyumonMenu : FukjBaseForm
    {
        public TyumonMenu()
        {
            InitializeComponent();
            ////画面フルスクリーン
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //ラベル透過処理
            this.label1.BackColor = Color.Transparent;
            this.label1.Parent = this.panel1;
            this.label1.Location -= (Size)this.panel1.Location;


        }

        private void tojiru_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void TyumonPrint_Click(object sender, EventArgs e)
        //{
        //    TyumonPrintForm frm = new TyumonPrintForm();
        //    frm.ShowDialog();
        //}

        private void TyumonInput_Click(object sender, EventArgs e)
        {
            TyumonShosaiForm frm = new TyumonShosaiForm();
            frm.ShowDialog();

        }

        private void TyumonList_Click(object sender, EventArgs e)
        {
            TyumonListForm frm = new TyumonListForm();
            frm.ShowDialog();

        }
    }
}
