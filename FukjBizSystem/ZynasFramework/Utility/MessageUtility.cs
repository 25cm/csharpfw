using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Utility
{
    public class MessageUtility
    {
        /// <summary>
        /// showing exceptional error message , use instead of string.Format(for runtime-safe purpose)
        /// </summary>
        /// <param name="dispNameList"></param>
        /// <param name="valueList"></param>
        /// <returns></returns>
        public static string FormatParamList(IEnumerable<string> dispNameList, IEnumerable<object> valueList)
        {
            string message = string.Empty;
            
#if DEBUG
            if (dispNameList.Count() != valueList.Count())
            {
                throw new FormatException();
            }
#else

#endif

            StringBuilder buf = new StringBuilder();

            int i = 0;
            foreach (string dispName in dispNameList)
            {
                string value = string.Empty;
                if (valueList.Count() > i && valueList.ElementAt(i) != null)
                {
                    value = valueList.ElementAt(i).ToString();
                }

                buf.AppendFormat("[{0}：{1}]", dispName, value.ToString());

                i++;
            }

            message = buf.ToString();

            return message;
        }
    }
}
