using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zynas.Framework.Core.Base.Boundary;
using Zynas.Framework.Utility;

namespace $rootnamespace$
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： $safeitemname$Form
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class $safeitemname$Form : BaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： $safeitemname$Form
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public $safeitemname$Form() : base()
        {
            // TODO コンストラクタを実装してください

            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： $safeitemname$Form
        /// <summary>
        /// コンストラクタ(終了時イベントあり)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="formEnd">フォーム終了時イベント</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public $safeitemname$Form(FormEnd formEnd) : base(formEnd)
        {
            // TODO コンストラクタを実装してください

            InitializeComponent();
        }
        #endregion
    }
    #endregion
}
