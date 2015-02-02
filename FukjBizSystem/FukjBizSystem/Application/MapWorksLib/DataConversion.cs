using System;
using System.Collections.Generic;
using System.Text;

namespace MapWorksViewer.MapWorks
{
    public class DataConversion
    {
        //******************************************************************************
        //                           DataConversion
        //                   ﾃﾞｰﾀ型を他のﾃﾞｰﾀ型に変換する関数群
        //******************************************************************************

        /// <summary>
        /// Nullが与えられた場合はEMPTYを返し､それ以外は与えられた値をそのまま返します｡
        /// </summary>
        /// <param name="varValue">ﾃｽﾄする値</param>
        /// <returns>EMPTYまたは与えられた値</returns>
        public static object EmptyIfNull(object Value)
        {
            object returnValue = null;

            try
            {
                returnValue = (Value == DBNull.Value) ? "" : Value;
                return returnValue;
            }
            catch
            {
                returnValue = "";
                return returnValue;
            }
        }

        /// <summary>
        /// NullまたはEmptyが与えられた場合はゼロを返し､それ以外は与えられた値をそのまま返します｡
        /// </summary>
        /// <param name="varValue">ﾃｽﾄする値</param>
        /// <returns>0または与えられた値</returns>
        public static object ZeroIfNull(object Value)
        {
            object returnValue = null;

            try
            {
                if (Value == DBNull.Value)
                    returnValue = 0;
                else if (Value.ToString() == "")
                    returnValue = 0;
                else
                    returnValue = Convert.ToDouble(Value);
                return returnValue; 
            }
            catch
            {
                returnValue = 0;
                return returnValue;
            }
        }

        /// <summary>
        /// 与えられたBoolean型の値をTrueを1,Falseを0としてInteger型ので返します｡
        /// </summary>
        /// <param name="bValue">ﾃｽﾄする値</param>
        /// <returns>0または1</returns>
        public static int BoolToInt(ref bool Value)
        {
            return Convert.ToInt32(Value);
        }

        /// <summary>
        /// 与えられたInteger型の値をｾﾞﾛ以外をTrue,ｾﾞﾛをFalseとしてBoolean型で返します｡
        /// </summary>
        /// <param name="intValue">ﾃｽﾄする値</param>
        /// <returns>TrueまたはFalse</returns>
        public static bool IntToBool(ref int Value)
        {
            return Convert.ToBoolean(Value);
        }

        /// <summary>
        /// 数値を8文字のHEXに変換する
        /// </summary>
        /// <param name="nLong">変換する値</param>
        /// <returns>HEX文字列</returns>
        public static string IntToHex8(ref int Value)
        {
            return "&H" + Value.ToString("X8") + "&";
        }

        /// <summary>
        /// 地図座標をﾌｫｰﾏｯﾄした文字列(度,分,秒,秒以下)に変換します
        /// </summary>
        /// <param name="Coord">変換する値(単位：1/1000秒)</param>
        /// <returns>座標文字列</returns>
        public static string FormatCoord(ref int Coord)
        {
            int deg = Coord / 3600000;
            int min = (Coord / 60000) % 60;
            int sec = (Coord / 1000) % 60;
            int ssec = Coord % 1000;

            return string.Format("{0:D}ﾟ {1:D}' {2:D}\" {3:D3}", deg, min, sec, ssec);
        }
    }
}
