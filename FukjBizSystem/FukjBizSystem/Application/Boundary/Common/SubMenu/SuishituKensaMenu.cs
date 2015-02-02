using System;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.CrossCheck;
using FukjBizSystem.Application.Boundary.KensaKekka;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishituKensaMenuForm
    /// <summary>
    /// サブメニュー画面（水質検査管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishituKensaMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishituKensaMenuForm
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
        public SuishituKensaMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region suishitsuKensaIraishoOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suishitsuKensaIraishoOutputButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaKanri.KensaIraishoOutputListForm frm = new SuishitsuKensaKanri.KensaIraishoOutputListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region suishitsuKensaIraiUketsukeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suishitsuKensaIraiUketsukeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList frm = new SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region yachoOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void yachoOutputButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaKanri.YachoOutputForm frm = new SuishitsuKensaKanri.YachoOutputForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region yachoInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void yachoInputButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaKanri.YachoTorikomiForm frm = new SuishitsuKensaKanri.YachoTorikomiForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaKekkaNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaKekkaNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // TODO このフォームでよいか？
                    SuishitsuKensaKanri.KensaKekkaInputForm frm = new SuishitsuKensaKanri.KensaKekkaInputForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region gaichuKensaListNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void gaichuKensaListNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaKanri.GaichuKensaListForm frm = new SuishitsuKensaKanri.GaichuKensaListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region hoteiKensaDaichoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void hoteiKensaDaichoButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaUketsuke.HoteiKensaDaicho frm = new SuishitsuKensaUketsuke.HoteiKensaDaicho();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region keiryoShomeiDaichoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void keiryoShomeiDaichoButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaUketsuke.KeiryoShomeiKensaDaicho frm = new SuishitsuKensaUketsuke.KeiryoShomeiKensaDaicho();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kakuninKensaJisshiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kakuninKensaJisshiButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaUketsuke.KakuninKensaJisshiKirokuForm frm = new SuishitsuKensaUketsuke.KakuninKensaJisshiKirokuForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region keiryoShomeiOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void keiryoShomeiOutputButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 計量証明書出力
                    SuishitsuKensaKanri.KeiryoShomeiOutputListForm frm = new SuishitsuKensaKanri.KeiryoShomeiOutputListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region suishitsuKensaNippoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void suishitsuKensaNippoButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SuishitsuKensaKanri.SuishitsuKensaNippoForm frm = new SuishitsuKensaKanri.SuishitsuKensaNippoForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaKekkaListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaKekkaListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaKekkaListForm frm = new KensaKekkaListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region saisuiTekiseiTenkenButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void saisuiTekiseiTenkenButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    SaisuiTekiseiTenkenListForm frm = new SaisuiTekiseiTenkenListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

    }
    #endregion
}
