using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Utility
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04　habu　　    新規作成
    /// </history>
    public class TypeUtility
    {
        #region Utility overrides

        #region GetString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetString(object value)
        {
            return (string)GetConvertedValueForDB(value, typeof(string));
        }
        #endregion

        #region GetInt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetInt(object value)
        {
            return (int)GetConvertedValueForDB(value, typeof(int));
        }
        #endregion

        #region GetDecimal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetDecimal(object value)
        {
            return (decimal)GetConvertedValueForDB(value, typeof(decimal));
        }
        #endregion

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　habu　　    新規作成
        /// </history>
        public static object GetConvertedValueForDB(object value, Type targetType)
        {
            // 変換先の型毎に処理を分岐する
            // same type
            if (value.GetType() == targetType)
            {
                return value;
            }
            // null value handling
            else if (value == null)
            {
                return GetDBDefaultValue(targetType);
            }
            // null value handling
            else if (value == DBNull.Value)
            {
                return GetDBDefaultValue(targetType);
            }
            // value convertion
            else
            {
                // string -> number type
                if (value is string && IsValueNumberType(targetType))
                {
                    return StringToValueNumberType(value as string, targetType);
                }
                // number type -> string
                else if (IsValueNumberType(value.GetType()) && targetType == typeof(string))
                {
                    return value.ToString();
                }
                // else applies default value
                else
                {
                    return GetDBDefaultValue(targetType);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　habu　　    新規作成
        /// </history>
        public static object GetDBDefaultValue(Type targetType)
        {
            if (targetType == typeof(string))
            {
                return string.Empty;
            }
            else if (targetType == typeof(int)) { return (int)0; }
            else if (targetType == typeof(decimal)) { return (decimal)0; }
            else if (targetType == typeof(double)) { return (double)0; }
            else if (targetType == typeof(float)) { return (float)0; }
            else if (targetType == typeof(long)) { return (long)0; }
            else if (targetType == typeof(short)) { return (short)0; }
            else if (targetType == typeof(uint)) { return (uint)0; }
            else if (targetType == typeof(ulong)) { return (ulong)0; }
            else if (targetType == typeof(ushort)) { return (ushort)0; }
            else if (targetType == typeof(sbyte)) { return (sbyte)0; }
            else if (targetType == typeof(byte)) { return (byte)0; }
            else if (targetType == typeof(char))
            {
                return (char)0;
            }
            else if (targetType == typeof(DateTime))
            {
                return DBNull.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static bool IsValueNumberType(Type targetType)
        {
            if (targetType == typeof(int)) { return true; }
            else if (targetType == typeof(decimal)) { return true; }
            else if (targetType == typeof(double)) { return true; }
            else if (targetType == typeof(float)) { return true; }
            else if (targetType == typeof(long)) { return true; }
            else if (targetType == typeof(short)) { return true; }
            else if (targetType == typeof(uint)) { return true; }
            else if (targetType == typeof(ulong)) { return true; }
            else if (targetType == typeof(ushort)) { return true; }
            else if (targetType == typeof(sbyte)) { return true; }
            else if (targetType == typeof(byte)) { return true; }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object StringToValueNumberType(string value, Type targetType)
        {
            if (targetType == typeof(int))
            {
                int t = 0;
                if (int.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(decimal))
            {
                decimal t = 0;
                if (decimal.TryParse((value as string), out t)) { return t; }
            }

            else if (targetType == typeof(double))
            {
                double t = 0;
                if (double.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(float))
            {
                float t = 0;
                if (float.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(long))
            {
                long t = 0;
                if (long.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(short))
            {
                short t = 0;
                if (short.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(uint))
            {
                uint t = 0;
                if (uint.TryParse((value as string), out t)) { return t; }
            }

            else if (targetType == typeof(ulong))
            {
                ulong t = 0;
                if (ulong.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(ushort))
            {
                ushort t = 0;
                if (ushort.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(sbyte))
            {
                sbyte t = 0;
                if (sbyte.TryParse((value as string), out t)) { return t; }
            }
            else if (targetType == typeof(byte))
            {
                byte t = 0;
                if (byte.TryParse((value as string), out t)) { return t; }
            }

            return GetDBDefaultValue(targetType);
        }
    }
}
