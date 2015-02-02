using System;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.JokasoDaichoKanri;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DaichoMenuForm
    /// <summary>
    /// サブメニュー画面（台帳管理）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class DaichoMenuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DaichoMenuForm
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
        public DaichoMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region jokasoDaichoListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25  habu　　    新規作成
        /// </history>
        private void jokasoDaichoListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 浄化槽台帳一覧に遷移
                    JokasoDaichoList frm = new JokasoDaichoList();
                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion
    }
    #endregion
}
