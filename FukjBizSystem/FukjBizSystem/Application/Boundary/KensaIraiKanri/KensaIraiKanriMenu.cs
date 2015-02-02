using System;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    public partial class KensaIraiKanriMenu : FukjBaseForm
    {
        public KensaIraiKanriMenu()
        {
            InitializeComponent();
        }

        private void kensaIraiToroku7joButton_Click(object sender, EventArgs e)
        {
            KensaIraiToroku7jo frm = new KensaIraiToroku7jo();
            Program.mForm.MoveNext(frm);
            //Program.mForm.ShowForm(frm);
        }
    }
}
