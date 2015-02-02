using System;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FukjTabBaseForm
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
    public partial class FukjTabBaseForm : Form
    {
        #region コンストラクタ

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FukjTabBaseForm
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
        public FukjTabBaseForm()
        {
            InitializeComponent();
        }

        #endregion
        
        #region イベント

        #region FukjTabBaseForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FukjTabBaseForm_Load
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
        private void FukjTabBaseForm_Load(object sender, EventArgs e)
        {
            if (!Utility.IsInDesignMode)
            {
                // アンカーの設定
                topPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                contentsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                // フォームの最大化
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                this.titleLabel.Text = this.Text;

                this.Text = string.Format("{0} - 福岡県浄化槽タブレットシステム", this.Text);

                // 検査員
                kensainNameLabel.Text = string.Format("検査員:{0}", ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm);

                // 現在時刻
                SetDateTime();

                dateTimeTimer.Interval = 10 * 1000;
                dateTimeTimer.Start();
            }
        }
        #endregion

        #region dateTimeTimer_Tick(object sender, EventArgs e)
        /// <summary>
        /// 時刻表示更新用タイマー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimeTimer_Tick(object sender, EventArgs e)
        {
            // 分が変わったタイミングのみ表示を更新
            if (DateTime.Now.Minute != currentTime.Minute)
            {
                SetDateTime();
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        private DateTime currentTime;

        #region SetDateTime()
        /// <summary>
        /// 現在時刻の表示
        /// </summary>
        private void SetDateTime()
        {
            dateTimeLabel.Text = DateTime.Now.ToString("yyyy/MM/dd (ddd) HH:mm");

            currentTime = DateTime.Now;
        }
        #endregion
        
        #endregion
    }
    #endregion
}
