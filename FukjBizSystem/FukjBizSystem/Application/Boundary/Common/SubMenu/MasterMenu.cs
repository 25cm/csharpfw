using System;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Master;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MasterMenuForm
    /// <summary>
    /// サブメニュー画面（マスタ管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MasterMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MasterMenuForm
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
        public MasterMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region hokenjoMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void hokenjoMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    HokenjoMstListForm frm = new HokenjoMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region chikuMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void chikuMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    ChikuMstListForm frm = new ChikuMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region shishoMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void shishoMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    ShishoMstListForm frm = new ShishoMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region bushoMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void bushoMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    BushoMstListForm frm = new BushoMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region yakushokuMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void yakushokuMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    YakushokuMstListForm frm = new YakushokuMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region shokuinMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void shokuinMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    ShokuinMstListForm frm = new ShokuinMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region katashikiMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void katashikiMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KatashikiMstListForm frm = new KatashikiMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region shoriHoshikiMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void shoriHoshikiMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    ShoriHoshikiMstListForm frm = new ShoriHoshikiMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region suishitsuMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suishitsuMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuMstListForm frm = new SuishitsuMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kenchikuYotoMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kenchikuYotoMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KenchikuyotoMstListForm frm = new KenchikuyotoMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region memoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void memoButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    MemoMstListForm frm = new MemoMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region gaikenKensaKomokuMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void gaikenKensaKomokuMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    GaikankensaKomokuMstListForm frm = new GaikankensaKomokuMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region shokenMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void shokenMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    ShokenMstListForm frm = new ShokenMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region suishitsuShikenKomokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suishitsuShikenKomokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuShikenKoumokuMstListForm frm = new SuishitsuShikenKoumokuMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region suishitsuKensaSetButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suishitsuKensaSetButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaSetMstListForm frm = new SuishitsuKensaSetMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region suishitsuKekkaNameButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suishitsuKekkaNameButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKekkaNmMstListForm frm = new SuishitsuKekkaNmMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region gyoshaMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void gyoshaMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    GyoshaMstListForm frm = new GyoshaMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region saisuiinMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void saisuiinMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SaisuiinMstListForm frm = new SaisuiinMstListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region nameMstButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void nameMstButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    NameMstEditListForm frm = new NameMstEditListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

    }
    #endregion
}
