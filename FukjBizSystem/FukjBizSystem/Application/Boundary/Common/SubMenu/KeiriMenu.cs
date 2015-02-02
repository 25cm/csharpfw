using System;
using System.Text;
using System.Windows.Forms;
using Zynas.Framework.Core.Common.Boundary;
using FukjBizSystem.Application.Boundary.Keiri;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiriMenuForm
    /// <summary>
    /// サブメニュー画面（経理管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KeiriMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KeiriMenuForm
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
        public KeiriMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region maeukekinKanriButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void maeukekinKanriButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    MaeukekinListForm frm = new MaeukekinListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region seikyuKanriButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void seikyuKanriButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SeikyuListForm frm = new SeikyuListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region seikyuZandakaListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void seikyuZandakaListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    ZandakaListForm frm = new ZandakaListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region nyukinJokyoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void nyukinJokyoButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    NyukinListForm frm = new NyukinListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region nyukiNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void nyukiNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    NyukinShosaiForm frm = new NyukinShosaiForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region henkinNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void henkinNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    HenkinShosaiForm frm = new HenkinShosaiForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region suitouKanriButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suitouKanriButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KaikeiRendoListForm frm = new KaikeiRendoListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kingakuShisanButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kingakuShisanButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KingakuShisanForm frm = new KingakuShisanForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region ryosyuOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void ryosyuOutputButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    RyoshushoPrintForm frm = new RyoshushoPrintForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

    }
    #endregion
}
