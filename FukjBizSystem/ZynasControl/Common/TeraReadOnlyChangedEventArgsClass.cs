using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Control
{
    /// <summary>
    /// 背景色を変更する読み取り専用プロパティ変更イベント引数クラス
    /// </summary>
    public class CustomReadOnlyChangedEventArgs : EventArgs
    {
        private bool readOnlyValue;

        /// <summary>
        /// 読み取り専用プロパティの値
        /// </summary>
        public bool ReadOnly
        {
            get { return readOnlyValue; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value">読み取り専用プロパティの値</param>
        public CustomReadOnlyChangedEventArgs(bool value)
        {
            readOnlyValue = value;
        }
    }
}
