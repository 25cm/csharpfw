using System;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.GaikanKensa;
using FukjBizSystem.Application.Boundary.KensaKekka;
using FukjBizSystem.Application.Boundary.UketsukeKanri;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoteiKensaMenuForm
    /// <summary>
    /// サブメニュー画面（法定検査管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HoteiKensaMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HoteiKensaMenuForm
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
        public HoteiKensaMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region jo7KensaIraiNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void jo7KensaIraiNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaIraiKanri.KensaIraiToroku7jo frm = new KensaIraiKanri.KensaIraiToroku7jo();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region jo7KensaIraiListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void jo7KensaIraiListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    Jo7KensaIraiListForm frm = new Jo7KensaIraiListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region jo7KensaChienNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void jo7KensaChienNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    Jo7KensaChienInput frm = new Jo7KensaChienInput();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaTorisageUketsukeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaTorisageUketsukeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaTorisageListForm frm = new KensaTorisageListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region jinendoGaikanYoteiNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void jinendoGaikanYoteiNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    JinendoGaikanKensaYoteiNyuryokuForm frm = new JinendoGaikanKensaYoteiNyuryokuForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region jinendoGaikanYoteiListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void jinendoGaikanYoteiListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    JinendoGaikanKensaYoteiListOutputForm frm = new JinendoGaikanKensaYoteiListOutputForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region jinendoGaikanYoteiHassouListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void jinendoGaikanYoteiHassouListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    JinendoGaikanYoteiListHassoOutputForm frm = new JinendoGaikanYoteiListHassoOutputForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaYoteiWariateButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaYoteiWariateButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaIraiKanri.KensaKeikaku.KensaYoteiWariateForm frm = new KensaIraiKanri.KensaKeikaku.KensaYoteiWariateForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaYoteiHeijyunButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaYoteiHeijyunButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaIraiKanri.KensaKeikaku.KensaYoteiHeijyunForm frm = new KensaIraiKanri.KensaKeikaku.KensaYoteiHeijyunForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaKeikakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaKeikakuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaIraiKanri.KensaKeikaku.KensaYoteiMap frm = new KensaIraiKanri.KensaKeikaku.KensaYoteiMap();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaHoryuListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaHoryuListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaHoryuListForm frm = new KensaHoryuListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaYoteiListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaYoteiListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaYoteiListForm frm = new KensaYoteiListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaYoteiPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26  habu　　    新規作成
        /// </history>
        private void kensaYoteiPrintButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 出力条件画面をダイアログ表示
                    KensainBetsuKensaYoteiPrintForm frm = new KensainBetsuKensaYoteiPrintForm();
                    frm.ShowDialog(this);
                });
        }
        #endregion

        #region kentaiJujuHyoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26  habu　　    新規作成
        /// </history>
        private void kentaiJujuHyoPrintButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 出力条件画面をダイアログ表示
                    KentaiJujuHyouPrintForm frm = new KentaiJujuHyouPrintForm();
                    frm.ShowDialog(this);
                });
        }
        #endregion

        #region kensaJisshiListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaJisshiListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaKekkaInputListForm frm = new KensaKekkaInputListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaKanryoNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaKanryoNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaKanryoInputListForm frm = new KensaKanryoInputListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaNippoListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaNippoListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaNippoListForm frm = new KensaNippoListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region kensaNippoNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kensaNippoNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaNippoInputForm frm = new KensaNippoInputForm();
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

    }
    #endregion
}
