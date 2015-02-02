using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Common.DataAccess
{
    public class DataAccessUtility
    {
        public static DbCommand CreateDbCommand()
        {
            return new System.Data.SqlClient.SqlCommand();
        }

        #region SetDefaultDBColumnValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTable"></param>
        /// <param name="newRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/02　habu　　    新規作成
        /// </history>
        public static void SetDefaultDBColumnValue(DataTable newTable, DataRow newRow)
        {
            foreach (DataColumn col in newTable.Columns)
            {
                if (col.ColumnName == "InsertDt"
                    || col.ColumnName == "InsertUser"
                    || col.ColumnName == "InsertTarm"
                    || col.ColumnName == "UpdateDt"
                    || col.ColumnName == "UpdateUser"
                    || col.ColumnName == "UpdateTarm")
                {
                    continue;
                }

                // 既に設定されている場合はスキップ
                if (newRow[col.ColumnName] != DBNull.Value)
                {
                    continue;
                }

                // 文字列の場合は空文字、数値は0を設定
                newRow[col.ColumnName] = TypeUtility.GetDBDefaultValue(col.DataType);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTable"></param>
        public static void SetDefaultDBColumnValue(DataTable newTable)
        {
            foreach (DataRow newRow in newTable.Rows)
            {
                SetDefaultDBColumnValue(newTable, newRow);
            }
        }
        #endregion

        //public static void Test()
        //{
        //    //DataAdapter adap = new DataAdapter();


        //}

    }
}
