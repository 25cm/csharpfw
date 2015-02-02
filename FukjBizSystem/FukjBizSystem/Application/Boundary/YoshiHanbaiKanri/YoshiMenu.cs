using System;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    public partial class YoshiMenuForm : FukjBaseForm
    {
        public YoshiMenuForm()
        {
            InitializeComponent();
        }

        #region 保証番号印刷
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ZaikoListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09　清国        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ZaikoListButton_Click(object sender, EventArgs e)
        {
            ZaikoListForm frm = new ZaikoListForm();
            Program.mForm.MoveNext(frm);
        }
        #endregion

        private void ShiireInput_Click(object sender, EventArgs e)
        {
            YoshiMstListForm frm = new YoshiMstListForm();
            Program.mForm.MoveNext(frm);
        }

        private void Tyumon_Click(object sender, EventArgs e)
        {
            //タッチパネル用なので通常のメニュー、ヘッダは出力しない
            TyumonMenu frm = new TyumonMenu();

            Program.tyumonMenuFrm = frm;


            frm.ShowDialog();

            
        }

        private void Uriage_Click(object sender, EventArgs e)
        {
            YoshiUriageListForm frm = new YoshiUriageListForm();
            Program.mForm.MoveNext(frm);
        }


    }
}
