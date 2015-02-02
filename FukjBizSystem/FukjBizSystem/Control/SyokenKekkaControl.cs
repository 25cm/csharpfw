using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Control
{
    // 検査結果入力画面の所見結果用ユーザコントロール
    // （モック作成用：現在、ロジック実装などはありません）
    public partial class SyokenKekkaControl : UserControl
    {
        #region 所見区分
        // 所見区分（1:所見/2:所見補足）
        public class ShokenKekkaKbnType
        {
            // 所見
            public const string Shoken = "1";
            // 所見補足
            public const string ShokenHosoku = "2";
        }
        #endregion

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
        /// 所見区分
        /// </summary>
        private string _syokenKbn;
        public string SyokenKbn
        {
            get
            {
                return _syokenKbn;
            }
            set
            {
                _syokenKbn = value;
                syokenKbnTextBox.Text = _syokenKbn;
            }
        }

        /// <summary>
        /// 所見CD
        /// </summary>
        private string _syokenCd;
        public string SyokenCd
        {
            get
            {
                return _syokenCd;
            }
            set
            {
                _syokenCd = value;
                syokenCdTextBox.Text = _syokenCd;
            }
        }

        /// <summary>
        /// 所見文章
        /// </summary>
        private string _syokenWd;
        public string SyokenWd
        {
            get
            {
                return _syokenWd;
            }
            set
            {
                _syokenWd = value;
                syokenWdTextBox.Text = _syokenWd;
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

        // 所見手書き
        private string _shokenTegaki;
        public string ShokenTegaki
        {
            get
            {
                return _shokenTegaki;
            }
            set
            {
                _shokenTegaki = value;
            }
        }
        // チェック項目
        private string _shokenCheckKomoku;
        public string ShokenCheckKomoku
        {
            get
            {
                return _shokenCheckKomoku;
            }
            set
            {
                _shokenCheckKomoku = value;
            }
        }
        // チェック項目判定
        private string _shokenCheckHantei;
        public string ShokenCheckHantei
        {
            get
            {
                return _shokenCheckHantei;
            }
            set
            {
                _shokenCheckHantei = value;
            }
        }
        // 指摘箇所No
        private string _shokenShitekiKashoNo;
        public string ShokenShitekiKashoNo
        {
            get
            {
                return _shokenShitekiKashoNo;
            }
            set
            {
                _shokenShitekiKashoNo = value;
            }
        }
        // 設置者連絡有無
        private string _shokenSetchishaRenrakuFlg;
        public string ShokenSetchishaRenrakuFlg
        {
            get
            {
                return _shokenSetchishaRenrakuFlg;
            }
            set
            {
                _shokenSetchishaRenrakuFlg = value;
            }
        }
        // 保守点検業者連絡有無
        private string _shokenHoshuGyoshaRenrakuFlg;
        public string ShokenHoshuGyoshaRenrakuFlg
        {
            get
            {
                return _shokenHoshuGyoshaRenrakuFlg;
            }
            set
            {
                _shokenHoshuGyoshaRenrakuFlg = value;
            }
        }
        // 清掃業者連絡有無
        private string _shokenSeisoGyoshaRenrakuFlg;
        public string ShokenSeisoGyoshaRenrakuFlg
        {
            get
            {
                return _shokenSeisoGyoshaRenrakuFlg;
            }
            set
            {
                _shokenSeisoGyoshaRenrakuFlg = value;
            }
        }
        // 工事業者連絡有無
        private string _shokenKojiGyoshaRenrakuFlg;
        public string ShokenKojiGyoshaRenrakuFlg
        {
            get
            {
                return _shokenKojiGyoshaRenrakuFlg;
            }
            set
            {
                _shokenKojiGyoshaRenrakuFlg = value;
            }
        }
        // メーカー連絡有無
        private string _shokenMakerRenrakuFlg;
        public string ShokenMakerRenrakuFlg
        {
            get
            {
                return _shokenMakerRenrakuFlg;
            }
            set
            {
                _shokenMakerRenrakuFlg = value;
            }
        }
        // 保健所連絡有無
        private string _shokenHokenjoRenrakuFlg;
        public string ShokenHokenjoRenrakuFlg
        {
            get
            {
                return _shokenHokenjoRenrakuFlg;
            }
            set
            {
                _shokenHokenjoRenrakuFlg = value;
            }
        }
        // 保守契約確認有無
        private string _shokenHoshuKeiyakuKakuninFlg;
        public string ShokenHoshuKeiyakuKakuninFlg
        {
            get
            {
                return _shokenHoshuKeiyakuKakuninFlg;
            }
            set
            {
                _shokenHoshuKeiyakuKakuninFlg = value;
            }
        }
        // 点検回数確認有無
        private string _shokenTenkenKaisuuKakuninFlg;
        public string ShokenTenkenKaisuuKakuninFlg
        {
            get
            {
                return _shokenTenkenKaisuuKakuninFlg;
            }
            set
            {
                _shokenTenkenKaisuuKakuninFlg = value;
            }
        }
        // 清掃回数確認有無
        private string _shokenSeisouKaisuuKakuninFlg;
        public string ShokenSeisouKaisuuKakuninFlg
        {
            get
            {
                return _shokenSeisouKaisuuKakuninFlg;
            }
            set
            {
                _shokenSeisouKaisuuKakuninFlg = value;
            }
        }

        // 所見区分（1:所見/2:所見補足）
        private string _shokenKekkaKbn;
        public string ShokenKekkaKbn
        {
            get
            {
                return _shokenKekkaKbn;
            }
            set
            {
                _shokenKekkaKbn = value;
            }
        }

        // 単位装置名
        private string _taniSochiNm;
        public string TaniSochiNm
        {
            get
            {
                return _taniSochiNm;
            }
            set
            {
                _taniSochiNm = value;
            }
        }

        #endregion

        #region カスタムイベント
        // 行移動ボタンクリック
        public event EventHandler CustomUpButtonClick;
        protected virtual void OnUpButtonClick(EventArgs e)
        {
            if (CustomUpButtonClick != null)
            {
                CustomUpButtonClick(this, e);
            }
        }

        // 所見検索ボタンクリック
        public event EventHandler CustomSearchButtonClick;
        protected virtual void OnSearchButtonClick(EventArgs e)
        {
            if (CustomSearchButtonClick != null)
            {
                CustomSearchButtonClick(this, e);
            }
        }

        // 削除ボタンクリック
        public event EventHandler CustomDeleteButtonClick;
        protected virtual void OnDeleteButtonClick(EventArgs e)
        {
            if (CustomDeleteButtonClick != null)
            {
                CustomDeleteButtonClick(this, e);
            }
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SyokenKekkaControl
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SyokenKekkaControl()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region wdUpButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： wdUpButton_Click
        /// <summary>
        /// 行移動ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void wdUpButton_Click(object sender, EventArgs e)
        {
            OnUpButtonClick(new EventArgs());
        }
        #endregion

        #region mstSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： mstSearchButton_Click
        /// <summary>
        /// 所見検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void mstSearchButton_Click(object sender, EventArgs e)
        {
            OnSearchButtonClick(new EventArgs());
        }
        #endregion

        #region DelButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DelButton_Click
        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DelButton_Click(object sender, EventArgs e)
        {
            OnDeleteButtonClick(new EventArgs());
        }
        #endregion


        #endregion
    }
}
