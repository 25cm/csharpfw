using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Zynas.Control.Common;

namespace Zynas.Control
{
    /// <summary>
    /// ZButtonコントロールクラス
    /// 継承元：Buttonコントロール
    /// </summary>
    public partial class ZButton : Button
    {        
        /// <summary>
        /// 処理中ボタンの親フォーム一覧が保持されます。
        /// </summary>
        private static HashSet<Form> formHashSet = new HashSet<Form>();

        #region コンストラクタ
        /// <summary>
        /// デザイナで表示時のコンストラクタ
        /// </summary>
        public ZButton()
        {
            #region デザイナによる初期化
            InitializeComponent();
            #endregion
        }

        /// <summary>
        /// プログラム実行時のコンストラクタ
        /// </summary>
        /// <param name="container"></param>
        public ZButton(IContainer container)
        {
            #region デザイナによる初期化
            container.Add(this);

            InitializeComponent();
            #endregion
        }
        #endregion

        #region イベント定義用
        /// <summary>
        /// クリックイベント時に行われる処理です。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            // クリック処理が行われたボタンの親フォームを取得
            Form ownerForm = FindForm();
            
            // 親フォームをハッシュセットに登録
            if (!formHashSet.Add(ownerForm))
            {
                // 登録に失敗したとき処理を終了
                // (同じフォームの別のボタンで処理が行われている)
                return;
            }

            try
            {
                // クリックイベントを発行
                base.OnClick(e);
            }
            finally
            {
                // メッセージキューの処理を先に行う。
                // クリックイベント中に同じフォーム上のボタンが押されたとき
                // ハッシュリストに登録できず、処理が終了する。
                Application.DoEvents();

                // ハッシュリストから登録を解除
                formHashSet.Remove(ownerForm);
            }
        }
        #endregion
    }
}
