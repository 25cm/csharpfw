using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zynas.Control.Common;

namespace Zynas.Control
{
    /// <summary>
    /// コントロールのプロパティを一括変更するプロパティ変更イベント引数クラス
    /// </summary>
    public class CustomControlDomainChangedEventArgs : EventArgs
    {

        private ZControlDomain readOnlyValue;

        /// <summary>
        /// 読み取り専用プロパティの値
        /// </summary>
        public ZControlDomain ReadOnly
        {
            get { return readOnlyValue; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value">読み取り専用プロパティの値</param>
        public CustomControlDomainChangedEventArgs(ZControlDomain value)
        {
            readOnlyValue = value;
        }
    }
}
