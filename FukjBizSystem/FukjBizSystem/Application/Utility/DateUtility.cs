using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.WarekiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Utility
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DateUtility
    /// <summary>
    /// 日付関連のユーティリティクラス
    /// 　Zynas.Framework.Utility.DateUtilityより移設
    /// 　和暦マスタを参照し、西暦と和暦の相互変換を行うように変更
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class DateUtility
    {
        #region 西暦和暦変換

        #region 定数定義

        #region 和暦元号区分
        /// <summary>
        /// 和暦元号区分
        /// </summary>
        public enum GengoKbn
        {
            /// <summary>
            /// 和暦
            /// </summary>
            Wareki,
            /// <summary>
            /// 和暦略
            /// </summary>
            WarekiRyaku,
            /// <summary>
            /// 和暦英略
            /// </summary>
            WarekiEiRyaku,
        }
        #endregion

        #endregion

        #region ConvertToWareki
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ConvertToWareki
        /// <summary>
        /// 西暦文字列(yyyyMMdd)を和暦文字列に変換する
        /// （指定の和暦フォーマットで取得。また、取得する元号の形式を、GengoKbnで指定）
        /// </summary>
        /// <param name="seirekiStr">西暦年月日(yyyyMMdd)</param>
        /// <param name="outFormat">和暦取得フォーマット</param>
        /// <param name="gengoKbn">元号種別</param>
        /// <returns>和暦年月日</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string ConvertToWareki(string seirekiStr, string outFormat, GengoKbn gengoKbn = GengoKbn.WarekiEiRyaku)
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
            else if (seirekiStr.Length <= 4)
            {
                seirekiStr = seirekiStr.PadLeft(4, '0');
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
                // 対象日付の和暦マスタを取得
                WarekiMstDataSet.WarekiMstDataTable warekiMst = getTargetWarekiMstByKaishiDt(date.ToString("yyyyMMdd"));
                if (warekiMst.Rows.Count > 0)
                {
                    WarekiMstDataSet.WarekiMstRow row = (WarekiMstDataSet.WarekiMstRow)warekiMst.Rows[0];
                    // 年号を取得
                    string eraStr = string.Empty;
                    switch (gengoKbn)
                    {
                        case GengoKbn.Wareki:
                            // 和暦
                            eraStr = row.Gengo;
                            break;
                        case GengoKbn.WarekiRyaku:
                            // 和暦略
                            eraStr = row.GengoRyaku;
                            break;
                        case GengoKbn.WarekiEiRyaku:
                            // 和暦英略
                            eraStr = row.GengoEiRyaku;
                            break;
                        default:
                            eraStr = string.Empty;
                            break;
                    }
                    // 和暦年を算出
                    int nen = date.Year - (Convert.ToInt32(row.KaishiDt.Substring(0, 4)) - 1);

                    // 書式文字列に応じて和暦に変換する
                    ret = outFormat;
                    ret = ret.Replace("yy", nen.ToString("00"));
                    ret = ret.Replace("y", nen.ToString("0"));
                    ret = ret.Replace("MM", date.Month.ToString("00"));
                    ret = ret.Replace("M", date.Month.ToString("0"));
                    ret = ret.Replace("dd", date.Day.ToString("00"));
                    ret = ret.Replace("d", date.Day.ToString("0"));
                    ret = ret.Replace("g", eraStr);
                }
            }

#if DEBUG
            Debug.WriteLine("西暦：" + seirekiStr + "　和暦:" + ret);
#endif
            return ret;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ConvertToWareki
        /// <summary>
        /// 西暦文字列(yyyyMMdd)を和暦文字列(geeMMdd)に変換する
        /// （取得する元号の形式を、GengoKbnで指定）
        /// </summary>
        /// <param name="warekiStr">西暦年月日(yyyyMMdd)</param>
        /// <param name="gengoKbn">元号種別</param>
        /// <returns>和暦年月日</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string ConvertToWareki(string warekiStr, GengoKbn gengoKbn = GengoKbn.WarekiEiRyaku)
        {
            return ConvertToWareki(warekiStr, "gyyMMdd", gengoKbn);
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ConvertToWareki
        /// <summary>
        /// 西暦文字列(yyyyMMdd)を和暦文字列(geeMMdd)に変換する
        /// （取得する元号の形式を、GengoKbnで指定）
        /// </summary>
        /// <param name="year">西暦年(yyyy)</param>
        /// <param name="month">月(MM)</param>
        /// <param name="day">日(dd)</param>
        /// <param name="gengoKbn">元号種別</param>
        /// <returns>和暦年月日</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string ConvertToWareki(string year, string month, string day, GengoKbn gengoKbn = GengoKbn.WarekiEiRyaku)
        {
            return ConvertToWareki(year + month + day, gengoKbn);
        }

        #endregion


        #region ConvertFromWareki
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ConvertFromWareki
        /// <summary>
        /// 和暦文字列(geeMMdd)を西暦文字列(yyyyMMdd)に変換する
        /// </summary>
        /// <param name="warekiStr">和暦年月日(gyyMMdd)</param>
        /// <param name="gengoKbn">元号種別</param>
        /// <returns>西暦年月日</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string ConvertFromWareki(string warekiStr, GengoKbn gengoKbn = GengoKbn.WarekiEiRyaku)
        {
            string ret = string.Empty;

            // エラーチェック(想定外の場合は、エラーログ出力し、空文字を返す)
            if (warekiStr.Length == 7 && (gengoKbn == GengoKbn.WarekiEiRyaku || gengoKbn == GengoKbn.WarekiRyaku))
            {
                // OK(H261006, 平261006)
            }
            else if (warekiStr.Length == 8 && gengoKbn == GengoKbn.Wareki)
            {
                // OK(平成261006)
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

            if (!parseFromWarekiStr(warekiStr, out date))
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiStr));
            }

            ret = date.ToString("yyyyMMdd");

#if DEBUG
            Debug.WriteLine("和暦：" + warekiStr + "　西暦:" + ret);
#endif
            return ret;
        }
        #endregion

        #region ConvertFromWareki
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ConvertFromWareki
        /// <summary>
        /// 和暦文字列(geeMMdd)を西暦文字列(yyyyMMdd)に変換する
        /// </summary>
        /// <param name="warekiStr">和暦年月日(gyyMMdd)</param>
        /// <param name="outFormat">Custom output format</param>
        /// <param name="gengoKbn">元号種別</param>
        /// <returns>西暦年月日</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string ConvertFromWareki(string warekiStr, string outFormat, GengoKbn gengoKbn = GengoKbn.WarekiEiRyaku)
        {
            string ret = string.Empty;

            // エラーチェック(想定外の場合は、エラーログ出力し、空文字を返す)
            if (warekiStr.Length == 7 && (gengoKbn == GengoKbn.WarekiEiRyaku || gengoKbn == GengoKbn.WarekiRyaku))
            {
                // OK(H261006, 平261006)
            }
            else if (warekiStr.Length == 8 && gengoKbn == GengoKbn.Wareki)
            {
                // OK(平成261006)
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

            if (!parseFromWarekiStr(warekiStr, out date))
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiStr));
            }

            ret = date.ToString(outFormat);

#if DEBUG
            Debug.WriteLine("和暦：" + warekiStr + "　西暦:" + ret);
#endif
            return ret;
        }
        #endregion

        #region parseFromWarekiStr
        /// <summary>
        /// 和暦から西暦に変換
        /// </summary>
        /// <param name="warekiStr"></param>
        /// <param name="seireki"></param>
        /// <returns></returns>
        private static bool parseFromWarekiStr(string warekiStr, out DateTime seireki)
        {
            seireki = DateTime.MinValue;

            if (string.IsNullOrEmpty(warekiStr) || string.IsNullOrEmpty(warekiStr.Trim()) || warekiStr.Length < 2)
            {
                return false;
            }

            // 和暦マスタを取得(先頭から１文字を元号として指定)
            string eraStr = warekiStr.Substring(0, 1);
            WarekiMstDataSet.WarekiMstDataTable warekiMst = getTargetWarekiMstByGengo(eraStr);
            if (warekiMst.Rows.Count <= 0)
            {
                // 和暦マスタを取得(先頭から２文字を元号として指定)
                eraStr = warekiStr.Substring(0, 2);
                warekiMst = getTargetWarekiMstByGengo(eraStr);
            }

            if (warekiMst.Rows.Count <= 0)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiStr));

                return false;
            }

            // 対象の和暦レコードを取得
            WarekiMstDataSet.WarekiMstRow row = (WarekiMstDataSet.WarekiMstRow)warekiMst.Rows[0];

            // 和暦年
            int year = int.Parse(warekiStr.Substring(eraStr.Length + 0, 2));
            // 月
            int month = int.Parse(warekiStr.Substring(eraStr.Length + 2, 2));
            // 日
            int day = int.Parse(warekiStr.Substring(eraStr.Length + 4, 2));
            // 西暦を計算
            year = year + (Convert.ToInt32(row.KaishiDt.Substring(0, 4)) - 1);
            seireki = new DateTime(year, month, day);

            return true;
        }
        #endregion

        #region getTargetWarekiMstByKaishiDt
        /// <summary>
        /// 対象日付の和暦マスタを取得
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  小松　　    新規作成
        /// </history>
        private static WarekiMstDataSet.WarekiMstDataTable getTargetWarekiMstByKaishiDt(string kaishiDt)
        {
            string value = string.Empty;

            IGetWarekiMstByKaishiDtBLInput input = new GetWarekiMstByKaishiDtBLInput();
            input.KaishiDt = kaishiDt;

            IGetWarekiMstByKaishiDtBLOutput output = new GetWarekiMstByKaishiDtBusinessLogic().Execute(input);

            return output.WarekiMstDataTable;
        }
        #endregion

        #region getWarekiMst
        /// <summary>
        /// 指定した和暦の元号の和暦マスタを取得
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  小松　　    新規作成
        /// </history>
        private static WarekiMstDataSet.WarekiMstDataTable getTargetWarekiMstByGengo(string gengo)
        {
            IGetWarekiMstByGengoBLInput input = new GetWarekiMstByGengoBLInput();
            // 和暦の元号
            input.Gengo = gengo;
            // 指定された和暦の元号と一致する和暦レコードを取得
            IGetWarekiMstByGengoBLOutput output = new GetWarekiMstByGengoBusinessLogic().Execute(input);

            return output.WarekiMstDataTable;
        }
        #endregion

        #endregion


        #region 年度取得

        #region 定数定義

        // 年度の開始月
        private const int FiscalYearStartingMonth = 4;

        #endregion

        #region GetNendo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetNendo
        /// <summary>
        /// 該当日付の年度を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="startingMonth">int : 年度の開始月</param>
        /// <returns>年度(西暦)</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static int GetNendo(DateTime dt, int startingMonth = FiscalYearStartingMonth)
        {
            int nendo = (dt.Month >= startingMonth ? dt.Year : dt.Year - 1);
#if DEBUG
            Debug.WriteLine("日付：" + dt.ToString() + "　年度:" + nendo);
#endif
            return nendo;
        }
        #endregion

        #endregion
    }
}
