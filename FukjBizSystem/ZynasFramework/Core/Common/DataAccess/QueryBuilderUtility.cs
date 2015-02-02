using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public class QueryBuilderUtility
    {
        #region Where Claus Builder

        #region Comparison Oprator Builder

        /// <summary>
        /// represents '='
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public static void AddEqualCond(StringBuilder whereBuf, string colName, object value)
        {
            AddOperatorCond(whereBuf, colName, value, "=");
        }

        /// <summary>
        /// represents '>'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public static void AddGreaterCond(StringBuilder whereBuf, string colName, object value)
        {
            AddOperatorCond(whereBuf, colName, value, ">");
        }

        /// <summary>
        /// represents '>='
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public static void AddGreaterEqualCond(StringBuilder whereBuf, string colName, object value)
        {
            AddOperatorCond(whereBuf, colName, value, ">=");
        }

        /// <summary>
        /// represents '<'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public static void AddLesserCond(StringBuilder whereBuf, string colName, object value)
        {
            AddOperatorCond(whereBuf, colName, value, "<");
        }

        /// <summary>
        /// represents '<='
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public static void AddLesserEqualCond(StringBuilder whereBuf, string colName, object value)
        {
            AddOperatorCond(whereBuf, colName, value, "<=");
        }

        /// <summary>
        /// represents '<>'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public static void AddNotEqualCond(StringBuilder whereBuf, string colName, object value)
        {
            AddOperatorCond(whereBuf, colName, value, "<>");
        }

        /// <summary>
        /// represents 'LIKE'
        /// </summary>
        /// <remarks>
        /// add '%' to original value
        /// </remarks>
        /// <param name="colName"></param>
        /// <param name="value">add '%' to original value</param>
        public static void AddLikeCond(StringBuilder whereBuf, string colName, object value)
        {
            string cond = string.Format("({0} LIKE '{1}')", colName, value.ToString());

            AddCondUnit(whereBuf, cond);
        }

        /// <summary>
        /// represents 'LIKE'
        /// </summary>
        /// <param name="whereBuf"></param>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public static void AddReverseLikeCond(StringBuilder whereBuf, string colName, object value)
        {
            string cond = string.Format("('{1}' LIKE '%' + {0} + '%')", colName, value.ToString());

            AddCondUnit(whereBuf, cond);
        }

        /// <summary>
        /// represents 'IN(,,,)'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="valueList">
        /// list of value placed in "IN(...)". 
        /// Array, List<T>, any other "foreachable" collection accepted />
        /// 
        /// </param>
        public static void AddInCond(StringBuilder whereBuf, string colName, IEnumerable<object> valueList)
        {
            StringBuilder condBuf = new StringBuilder();

            foreach (object value in valueList)
            {
                if (condBuf.Length > 0)
                {
                    condBuf.Append(" ,");
                }

                condBuf.AppendFormat("'{0}'", value);
            }

            string cond = string.Format("{0} IN({1})", colName, condBuf.ToString());

            AddCondUnit(whereBuf, cond);
        }

        /// <summary>
        /// represents 'IN(,,,)'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="valueList">
        /// list of value placed in "IN(...)". 
        /// Array, List<T>, any other "foreachable" collection accepted />
        /// 
        /// </param>
        public static void AddAnyColEqualCond(StringBuilder whereBuf, IEnumerable<string> colNameList, object value)
        {
            StringBuilder condBuf = new StringBuilder();

            foreach (string colName in colNameList)
            {
                if (condBuf.Length > 0)
                {
                    condBuf.Append(" OR ");
                }

                condBuf.Append(string.Format("({0} = '{1}')", colName, value.ToString()));
            }

            AddCondUnit(whereBuf, string.Format("({0})", condBuf.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereBuf"></param>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        /// <param name="ope"></param>
        protected static void AddOperatorCond(StringBuilder whereBuf, string colName, object value, string ope)
        {
            string cond = string.Format("({0} {2} '{1}')", colName, value.ToString(), ope);

            AddCondUnit(whereBuf, cond);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        public static void AddCondUnit(StringBuilder whereBuf, string cond)
        {
            if (whereBuf.Length == 0)
            {
                whereBuf.Append(" ");
            }
            else
            {
                whereBuf.Append(" AND ");
            }

            whereBuf.Append(cond);
        }

        #endregion

        #region Order By Claus Builder

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBuf"></param>
        /// <param name="colName"></param>
        /// <param name="asc"></param>
        public static void AddOrderCol(StringBuilder orderBuf, string colName, bool isAsc)
        {
            if (isAsc)
            {
                AddOrderUnit(orderBuf, colName);
            }
            else
            {
                AddOrderUnit(orderBuf, colName + " DESC");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBuf"></param>
        /// <param name="colName"></param>
        public static void AddOrderCol(StringBuilder orderBuf, string colName)
        {
            AddOrderCol(orderBuf, colName, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBuf"></param>
        /// <param name="orderCol"></param>
        protected static void AddOrderUnit(StringBuilder orderBuf, string orderCol)
        {
            if (orderBuf.Length == 0)
            {
                orderBuf.Append(" ");
            }
            else
            {
                orderBuf.Append(" ,");
            }

            orderBuf.Append(orderCol);
        }

        #endregion
    }
}
