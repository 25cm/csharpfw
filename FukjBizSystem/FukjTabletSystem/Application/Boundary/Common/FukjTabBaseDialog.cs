using System;
using System.Windows.Forms;

namespace FukjTabletSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FukjTabBaseDialog
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
    public partial class FukjTabBaseDialog : Form
    {
        #region コンストラクタ

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FukjTabBaseDialog
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
        public FukjTabBaseDialog()
        {
            InitializeComponent();
        }

        #endregion
        
        #region イベント

        #region FukjTabBaseDialog_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FukjTabBaseDialog_Load
        /// <summary>
        /// 初期ロードの処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// 2014/07/07　豊田　　    タブレット画面向けに修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FukjTabBaseDialog_Load(object sender, EventArgs e)
        {
            if (!Utility.IsInDesignMode)
            {
                // アンカーの設定
                topPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                contentsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                // タイトルバー表示
                this.Text = "福岡県浄化槽タブレットシステム";
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
