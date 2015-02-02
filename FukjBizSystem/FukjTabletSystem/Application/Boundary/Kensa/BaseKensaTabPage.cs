using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjTabletSystem.Application.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa
{
    public partial class BaseKensaTabPage : UserControl
    {
        public BaseKensaTabPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面出力内容の編集が行われたか
        /// </summary>
        protected bool IsEdited = false;


        /// <summary>
        /// 表示文字列
        /// </summary>
        private string displayName = string.Empty;
        /// <summary>
        /// 表示文字列
        /// </summary>
        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                this.displayName = value;
            }
        }

        /// <summary>
        /// 
        /// <summary>
        /// タブ移動される際に親画面より呼ばれるメソッド
        /// タブ遷移を制御すること
        /// </summary>
        /// <returns>Closeの可否</returns>
        public bool MenuClosing()
        {
            if (IsEdited)
            {
                if (TabMessageBox.Show2(TabMessageBox.Type.YesNo, this.displayName, "未確定の変更内容があります。このまま移動しますか？\r\n※確定を行わずに画面を閉じた場合、変更内容は破棄されます。") == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
