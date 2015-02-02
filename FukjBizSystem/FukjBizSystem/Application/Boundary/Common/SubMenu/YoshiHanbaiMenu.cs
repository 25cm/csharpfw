using System;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.YoshiHanbaiKanri;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiHanbaiMenuForm
    /// <summary>
    /// サブメニュー画面（用紙販売管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YoshiHanbaiMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YoshiHanbaiMenuForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public YoshiHanbaiMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region zaikoListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void zaikoListButton_Click(object sender, EventArgs e)
        {
            ZaikoListForm frm = new ZaikoListForm();
            Program.mForm.MoveNext(frm);
        }
        #endregion

        #region shiireNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void shiireNyuryokuButton_Click(object sender, EventArgs e)
        {
            YoshiMstListForm frm = new YoshiMstListForm();
            Program.mForm.MoveNext(frm);
        }
        #endregion

        #region chumonButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void chumonButton_Click(object sender, EventArgs e)
        {
            //タッチパネル用なので通常のメニュー、ヘッダは出力しない
            TyumonMenu frm = new TyumonMenu();

            Program.tyumonMenuFrm = frm;

            frm.ShowDialog();
        }
        #endregion

        #region yoshiUriageJissekiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void yoshiUriageJissekiButton_Click(object sender, EventArgs e)
        {
            YoshiUriageListForm frm = new YoshiUriageListForm();
            Program.mForm.MoveNext(frm);
        }
        #endregion

    }
    #endregion
}
