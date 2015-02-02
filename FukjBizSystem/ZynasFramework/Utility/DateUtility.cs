using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Zynas.Framework.Utility
{
    public class DateUtility
    {
        #region 西暦和暦変換

        #region 元号起原

        /// <summary>
        /// 明治
        /// </summary>
        private static readonly DateTime ERA_BEGIN_MEIJI = new DateTime(1868, 10, 23);
        /// <summary>
        /// 大正
        /// </summary>
        private static readonly DateTime ERA_BEGIN_TAISHO = new DateTime(1912, 7, 30);
        /// <summary>
        /// 昭和
        /// </summary>
        private static readonly DateTime ERA_BEGIN_SHOWA = new DateTime(1926, 12, 25);
        /// <summary>
        /// 平成
        /// </summary>
        private static readonly DateTime ERA_BEGIN_HEISEI = new DateTime(1989, 1, 8);

        private static DateTime[] ERA_LIST = { ERA_BEGIN_MEIJI, ERA_BEGIN_TAISHO, ERA_BEGIN_SHOWA, ERA_BEGIN_HEISEI };

        private static string[] ERA_STR_LIST = { "M", "T", "S", "H" };

        #endregion

        #region ConvertToWareki
        /// <summary>
        /// 西暦文字列(yyyyMMdd)を和暦文字列(geeMMdd)に変換する
        /// </summary>
        /// <param name="seirekiStr"></param>
        /// <returns></returns>
        [Obsolete("代わりに 'FukjBizSystem.Application.Utility.DateUtility.ConvertToWareki(string, string, GengoKbn)' を使用します。")]
        public static string ConvertToWareki(string seirekiStr, string outFormat)
        {
            string ret = string.Empty;

            // エラーチェック(想定外の場合は、エラーログ出力し、空文字を返す)
            if (seirekiStr.Length == 8)
            {
                // OK
            }
            // yyyyMMの場合、1日とみなす
            else if (seirekiStr.Length == 6)
            {
                seirekiStr = seirekiStr + "01";
            }
            // yyyyMMddの場合、1月1日とみなす
            else if (seirekiStr.Length == 4)
            {
                seirekiStr = seirekiStr + "0101";
            }
            else
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", seirekiStr));

                return ret;
            }

            // 一旦日付型に変換
            DateTime date;
            if (DateTime.TryParseExact(seirekiStr, "yyyyMMdd", null, DateTimeStyles.None, out date))
            {
                string eraStr;
                int nendo;
                GetWarekiNendo(date, out eraStr, out nendo);

                // 書式文字列に応じて和暦に変換する
                ret = outFormat;
                ret = ret.Replace("g", eraStr);
                ret = ret.Replace("yy", nendo.ToString("00"));
                ret = ret.Replace("y", nendo.ToString("0"));
                ret = ret.Replace("MM", date.Month.ToString("00"));
                ret = ret.Replace("M", date.Month.ToString("0"));
                ret = ret.Replace("dd", date.Day.ToString("00"));
                ret = ret.Replace("d", date.Day.ToString("0"));

                //ret = eraStr + nendo.ToString("00") + date.ToString("MMdd");
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warekiStr"></param>
        /// <returns></returns>
        [Obsolete("代わりに 'FukjBizSystem.Application.Utility.DateUtility.ConvertToWareki(string)' を使用します。")]
        public static string ConvertToWareki(string warekiStr)
        {
            return ConvertToWareki(warekiStr, "gyyMMdd");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        [Obsolete("代わりに 'FukjBizSystem.Application.Utility.DateUtility.ConvertToWareki(string, string, string)' を使用します。")]
        public static string ConvertToWareki(string year, string month, string day)
        {
            return ConvertToWareki(year + month + day);
        }

        #endregion

        #region ConvertFromWareki
        /// <summary>
        /// 和暦文字列(geeMMdd)を西暦文字列(yyyyMMdd)に変換する
        /// </summary>
        /// <param name="warekiStr"></param>
        /// <returns></returns>
        [Obsolete("代わりに 'FukjBizSystem.Application.Utility.DateUtility.ConvertFromWareki(string)' を使用します。")]
        public static string ConvertFromWareki(string warekiStr)
        {
            string ret = string.Empty;

            // エラーチェック(想定外の場合は、エラーログ出力し、空文字を返す)
            if (warekiStr.Length == 7)
            {
                // OK
            }
            else if (warekiStr.Length == 5)
            {
                warekiStr = warekiStr + "01";
            }
            else if (warekiStr.Length == 3)
            {
                warekiStr = warekiStr + "0101";
            }
            // 年度のみの場合は、平成とみなす
            else if (warekiStr.Length == 2)
            {
                warekiStr = "H" + warekiStr + "0101";
            }
            else
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiStr));
            }

            DateTime date;

            if (!ParseFromWarekiStr(warekiStr, out date))
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiStr));
            }

            ret = date.ToString("yyyyMMdd");

            return ret;
        }
        #endregion

        #region GetWarekiNendo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="eraStr"></param>
        /// <param name="nendo"></param>
        private static void GetWarekiNendo(DateTime date, out string eraStr, out int nendo)
        {
            eraStr = string.Empty;
            nendo = 0;

            if (date >= ERA_BEGIN_MEIJI && date < ERA_BEGIN_TAISHO)
            {
                eraStr = "M";
                nendo = date.Year - (ERA_BEGIN_MEIJI.Year - 1);
            }
            else if (date >= ERA_BEGIN_TAISHO && date < ERA_BEGIN_SHOWA)
            {
                eraStr = "T";
                nendo = date.Year - (ERA_BEGIN_TAISHO.Year - 1);
            }
            else if (date >= ERA_BEGIN_SHOWA && date < ERA_BEGIN_HEISEI)
            {
                eraStr = "S";
                nendo = date.Year - (ERA_BEGIN_SHOWA.Year - 1);
            }
            else
            {
                eraStr = "H";
                nendo = date.Year - (ERA_BEGIN_HEISEI.Year - 1);
            }
        }
        #endregion

        #region ParseFromWarekiStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warekiStr"></param>
        /// <param name="seireki"></param>
        /// <returns></returns>
        private static bool ParseFromWarekiStr(string warekiStr, out DateTime seireki)
        {
            seireki = DateTime.MinValue;

            // 元号を含まない場合
            if (!ERA_STR_LIST.Contains<string>(warekiStr.Substring(0, 1)))
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiStr));

                return false;
            }

            int nendo = int.Parse(warekiStr.Substring(1, 2));
            int month = int.Parse(warekiStr.Substring(3, 2));
            int day = int.Parse(warekiStr.Substring(5, 2));

            if (warekiStr.Substring(0, 1) == "M")
            {
                nendo = nendo + (ERA_BEGIN_MEIJI.Year - 1);
            }
            else if (warekiStr.Substring(0, 1) == "T")
            {
                nendo = nendo + (ERA_BEGIN_TAISHO.Year - 1);
            }
            else if (warekiStr.Substring(0, 1) == "S")
            {
                nendo = nendo + (ERA_BEGIN_SHOWA.Year - 1);
            }
            else if (warekiStr.Substring(0, 1) == "H")
            {
                nendo = nendo + (ERA_BEGIN_HEISEI.Year - 1);
            }

            seireki = new DateTime(nendo, month, day);

            return true;
        }
        #endregion

        /// <summary>
        /// 経過年月日を算出する
        /// </summary>
        /// <param name="toDate"></param>
        /// <param name="fromDate"></param>
        /// <param name="yearDiff"></param>
        /// <param name="monthDiff"></param>
        /// <param name="daysDiff"></param>
        public static void DateDiff(DateTime toDate, DateTime fromDate, out int yearDiff, out int monthDiff, out int daysDiff)
        {
            yearDiff = toDate.Year - fromDate.Year;
            monthDiff = toDate.Month - fromDate.Month;
            daysDiff = toDate.Day - fromDate.Day;

            if (monthDiff < 0)
            {
                monthDiff += 12;
                // carry down year
                yearDiff -= 1;
            }

            if (daysDiff < 0)
            {
                // calculate passed days from former month, same day in month
                DateTime formerDt = fromDate.AddMonths(monthDiff - 1);

                daysDiff = (int)(toDate - formerDt).TotalDays;
                // carry down month
                monthDiff -= 1;
            }
        }
        #endregion
    }
}
