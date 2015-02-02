using System.Text;

namespace FukjTabletSystem.Application.DataAccess
{
    class DataAccessUtility
    {
        /// <summary>
        /// エスケープ対象文字列
        /// </summary>
        private static char[] sqlEscapeChar = { '_', '%', '[', '*', '\\' };

        /// <summary>
        /// SQL文字列中のエスケープ対象文字列をエスケープする
        /// </summary>
        /// <param name="paramStr">SQL文字列</param>
        /// <returns>エスケープ済SQL文字列</returns>
        public static string EscapeSQLString(string paramStr)
        {
            if (paramStr == null) { return null; }
            StringBuilder buf = new StringBuilder();
            foreach (char c in paramStr)
            {
                foreach (char escapeChar in sqlEscapeChar)
                {
                    if (c == escapeChar)
                    {
                        buf.Append('[');
                        buf.Append(c);
                        buf.Append(']');
                        goto FOUND_ESCAPE_CHAR;
                    }
                }
                buf.Append(c);
            FOUND_ESCAPE_CHAR: ;
            }
            return buf.ToString();
        }

        #region SetBetweenCommand
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： SetBetweenCommand
        /// <summary>
        /// SetBetweenCommand
        /// </summary>
        /// <param name="cdFrom"></param>
        /// <param name="cdTo"></param>
        /// <param name="cdLength"></param>
        /// <returns>SQL text: between [x...] and [x...]</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　豊田   　　 新規作成
        /// </history>
        public static string SetBetweenCommand(string cdFrom, string cdTo, int cdLength)
        {
            string sqlPart = " between ";

            if (string.IsNullOrEmpty(cdFrom) && string.IsNullOrEmpty(cdTo))
            {
                sqlPart += string.Format("'{0}' and '{1}'", new string('0', cdLength), new string('9', cdLength));
            }

            if (!string.IsNullOrEmpty(cdFrom) && !string.IsNullOrEmpty(cdTo))
            {
                sqlPart += string.Format("'{0}' and '{1}'", cdFrom, cdTo);
            }

            if (string.IsNullOrEmpty(cdFrom) && !string.IsNullOrEmpty(cdTo))
            {
                sqlPart += string.Format("'{0}' and '{1}'", new string('0', cdLength), cdTo);
            }

            if (!string.IsNullOrEmpty(cdFrom) && string.IsNullOrEmpty(cdTo))
            {
                sqlPart += string.Format("'{0}' and '{1}'", cdFrom, new string('9', cdLength));
            }

            return sqlPart;
        }
        #endregion
    }
}