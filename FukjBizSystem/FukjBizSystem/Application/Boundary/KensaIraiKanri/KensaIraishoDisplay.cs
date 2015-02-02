using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    public partial class KensaIraishoDisplay : Form
    {
        private KensaIraiToroku7jo parentDispForm;

        private KensaIraishoList frmlist;

        // 画面位置管理クラス
        FormLocation formLocation = new FormLocation();

        public string SelectedFilePath { get; set; }

        public KensaIraishoDisplay()
        {
            InitializeComponent();
        }

        public KensaIraishoDisplay(KensaIraiToroku7jo f)
        {
            parentDispForm = f; // メイン・フォームへの参照を保存

            InitializeComponent();
        }

        private void KensaIraishoDisplay_Load(object sender, EventArgs e)
        {
            frmlist = new KensaIraishoList(this);
            frmlist.Show(this);

            // 保存画面位置取得
            Location = formLocation.GetPoint(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this);
            Size = formLocation.GetSize(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, this.Size);
        }

        private void KensaIraishoDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmlist.Close();
        }

        private void KensaIraishoDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面位置保存
            formLocation.SetPoint(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, Location);
            formLocation.SetSize(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, Size);
        }

        #region 画面連携インターフェース

        public void SelectPdfFile(string filePath)
        {
            axAcroPDF1.LoadFile(filePath);

            SelectedFilePath = filePath;

            axAcroPDF1.Refresh();
        }

        #endregion
    }
}
