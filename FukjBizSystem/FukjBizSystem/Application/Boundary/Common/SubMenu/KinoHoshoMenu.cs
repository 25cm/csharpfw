using System;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.KinoHoshoKanri;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KinoHoshoMenuForm
    /// <summary>
    /// サブメニュー画面（機能保証管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KinoHoshoMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KinoHoshoMenuForm
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
        public KinoHoshoMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region hoshouNoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void hoshouNoPrintButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    HoshoNoPrintForm frm = new HoshoNoPrintForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region hoshouShinseiNyuryokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void hoshouShinseiNyuryokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    HoshoShinseiListForm frm = new HoshoShinseiListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region hoshouShinseiKoukanButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void hoshouShinseiKoukanButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    HoshoShinseiKokanForm frm = new HoshoShinseiKokanForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

    }
    #endregion
}
