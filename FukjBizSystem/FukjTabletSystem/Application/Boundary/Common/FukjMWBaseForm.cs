using System.Windows.Forms;

namespace FukjTabletSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FukjMWBaseForm
    /// <summary>
    /// フォームの基本クラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class FukjMWBaseForm : Form
    {
        #region コンストラクタ

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FukjMWBaseForm
        /// <summary>
        /// クラスの構築を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// 2014/07/07　豊田　　    タブレット画面向けに修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FukjMWBaseForm()
        {
            InitializeComponent();
        }

        #endregion
    }
    #endregion
}
