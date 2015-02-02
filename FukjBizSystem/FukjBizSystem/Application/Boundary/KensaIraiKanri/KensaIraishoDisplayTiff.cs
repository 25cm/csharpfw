using System;
using System.Drawing;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    public partial class KensaIraishoDisplayTiff : FukjBaseForm
    {
        public KensaIraishoDisplayTiff()
        {
            InitializeComponent();
        }

        private void KensaIraishoDisplayTiff_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(@"C:\kino\work\FukjBizSystem\fj_biz-system_bk20140710\FukjBizSystem\TestImage.tif");

            pictureBox1.Image = bm;

        }
    }
}
