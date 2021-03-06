﻿using System;
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
    public class QueryBuilder
    {
        private StringBuilder whereBuf;
        private StringBuilder orderBuf;

        /// <summary>
        /// Where claus generated by AddXXXmethods
        /// </summary>
        public string WhereStr
        {
            get
            {
                if (whereBuf.Length > 0) { return " WHERE " + whereBuf.ToString(); }
                else { return string.Empty; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WhereStrPlain
        {
            get { return whereBuf.ToString(); }
        }

        /// <summary>
        /// Order by claus generated
        /// </summary>
        public string OrderStr
        {
            get
            {
                if (orderBuf.Length > 0) { return " ORDER BY " + orderBuf.ToString(); }
                else { return string.Empty; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OrderStrPlain
        {
            get { return orderBuf.ToString(); }
        }

        public QueryBuilder()
        {
            whereBuf = new StringBuilder();
            orderBuf = new StringBuilder();
        }

        /// <summary>
        /// represents '='
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddEqualCond(string colName, object value)
        {
            QueryBuilderUtility.AddEqualCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents '>'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddGreaterCond(string colName, object value)
        {
            QueryBuilderUtility.AddGreaterCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents '>='
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddGreaterEqualCond(string colName, object value)
        {
            QueryBuilderUtility.AddGreaterEqualCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents '<'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddLesserCond(string colName, object value)
        {
            QueryBuilderUtility.AddLesserCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents '<='
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddLesserEqualCond(string colName, object value)
        {
            QueryBuilderUtility.AddLesserEqualCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents '<>'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddNotEqualCond(string colName, object value)
        {
            QueryBuilderUtility.AddNotEqualCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents 'LIKE'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddLikeCond(string colName, object value)
        {
            QueryBuilderUtility.AddLikeCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents 'LIKE'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        public void AddReverseLikeCond(string colName, object value)
        {
            QueryBuilderUtility.AddReverseLikeCond(whereBuf, colName, value);
        }

        /// <summary>
        /// represents 'IN(,,,)'
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="valueList">
        /// list of value placed in "IN(...)". 
        /// Array, List<T>, any other "foreachable" collection accepted />
        /// </param>
        public void AddInCond(string colName, IEnumerable<object> valueList)
        {
            QueryBuilderUtility.AddInCond(whereBuf, colName, valueList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        public void AddCondUnit(string cond)
        {
            QueryBuilderUtility.AddCondUnit(whereBuf, cond);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colNameList"></param>
        /// <param name="value"></param>
        public void AddAnyColEqualCond(IEnumerable<string> colNameList, object value)
        {
            QueryBuilderUtility.AddAnyColEqualCond(whereBuf, colNameList, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="isAsc"></param>
        public void AddOrderCol(string colName, bool isAsc)
        {
            QueryBuilderUtility.AddOrderCol(orderBuf, colName, isAsc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        public void AddOrderCol(string colName)
        {
            QueryBuilderUtility.AddOrderCol(orderBuf, colName, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="isAsc"></param>
        public void AddOrderColAsInt(string colName, bool isAsc)
        {
            const string maxInjiJyun = "2147483647";
            QueryBuilderUtility.AddOrderCol(orderBuf, string.Format("CONVERT(int, ISNULL({0}, '{1}'))", colName, maxInjiJyun), isAsc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colName"></param>
        public void AddOrderColAsInt(string colName)
        {
            AddOrderColAsInt(colName, true);
        }
    }
}
