using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FukjBizSystem.Control
{
    // 検査結果入力画面のチェック項目用ユーザコントロール
    // （モック作成用：現在、ロジック実装などはありません）
    public partial class CheckItemControl : UserControl
    {
        #region プロパティ
        /// <summary>
        /// 項目番号
        /// </summary>
        private int _itemNo;
        public int ItemNo
        {
            get
            {
                return _itemNo;
            }
            set
            {
                _itemNo = value;
                itemNoLabel.Text = _itemNo.ToString();
            }
        }

        /// <summary>
        /// 項目名
        /// </summary>
        private string _itemText;
        public string ItemText
        {
            get
            {
                return _itemText;
            }
            set
            {
                _itemText = value;
                itemTextBox.Text = _itemText;
            }
        }

        /// <summary>
        /// 判定
        /// </summary>
        private string _hanteiKekka;
        public string HanteiKekka
        {
            get
            {
                return _hanteiKekka;
            }
            set
            {
                _hanteiKekka = value;
                hanteiTextLabel.Text = _hanteiKekka;
            }
        }

        /// <summary>
        /// 変更フラグ
        /// </summary>
        private bool _editFlag;
        public bool EditFlag
        {
            get
            {
                return _editFlag;
            }
            set
            {
                _editFlag = value;
            }
        }
        #endregion

        #region カスタムイベント
        // 項目名ラベルクリック
        public event EventHandler CustomItemClick;
        protected virtual void OnItemLabelClick(EventArgs e)
        {
            if (CustomItemClick != null)
            {
                CustomItemClick(this, e);
            }
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CheckItemControl
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CheckItemControl()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region itemTextBox_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： itemTextBox_Click
        /// <summary>
        /// 項目名ラベルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void itemTextBox_Click(object sender, EventArgs e)
        {
            OnItemLabelClick(new EventArgs());
        }
        #endregion

        #endregion
    }
}
