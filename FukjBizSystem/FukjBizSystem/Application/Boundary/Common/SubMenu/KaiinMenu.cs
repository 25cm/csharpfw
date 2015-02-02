using System;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.KaiinKanri;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaiinMenuForm
    /// <summary>
    /// サブメニュー画面（会員管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaiinMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KaiinMenuForm
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
        public KaiinMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region kaiinListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void kaiinListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 会員一覧に遷移
                    KaiinListForm frm = new KaiinListForm();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

    }
    #endregion
}
