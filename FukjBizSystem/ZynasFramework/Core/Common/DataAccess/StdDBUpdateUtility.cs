using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/01　habu　　    新規作成
    /// </history>
    public class StdDBUpdateUtility
    {
        #region 定数

        /// <summary>
        /// 登録日時カラム名
        /// </summary>
        public static readonly string COL_NAME_INSERT_DT = "InsertDt";
        /// <summary>
        /// 登録ユーザカラム名
        /// </summary>
        public static readonly string COL_NAME_INSERT_USER = "InsertUser";
        /// <summary>
        /// 登録端末カラム名
        /// </summary>
        public static readonly string COL_NAME_INSERT_TERM = "InsertTarm";
        /// <summary>
        /// 更新日時カラム名
        /// </summary>
        public static readonly string COL_NAME_UPDATE_DT = "UpdateDt";
        /// <summary>
        /// 更新ユーザ名カラム
        /// </summary>
        public static readonly string COL_NAME_UPDATE_USER = "UpdateUser";
        /// <summary>
        /// 更新端末名カラム
        /// </summary>
        public static readonly string COL_NAME_UPDATE_TERM = "UpdateTarm";
        /// <summary>
        /// クエリパラメータprefix
        /// </summary>
        public static readonly string SQL_PARAM_PREFIX = "@";

        /// <summary>
        /// INSERT時にUPDATE共通カラムを設定するか否か
        /// </summary>
        private static bool SET_UPDATE_COL_ON_INSERT = true;

        #endregion

        #region 汎用更新

        #region CreateUpdateAdapter
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　habu　　    新規作成
        /// </history>
        public static SqlDataAdapter CreateDBUpdateAdapter(SqlConnection connection, DataTable srcTable, string tableName, List<string> keyColNameList, Dictionary<string, string> targetColumnMapping)
        {
            // 更新対象カラム未指定時は、全てのカラムを更新する
            if (targetColumnMapping == null || targetColumnMapping.Keys.Count == 0)
            {
                targetColumnMapping = new Dictionary<string, string>();
                foreach (DataColumn col in srcTable.Columns)
                {
                    targetColumnMapping.Add(col.ColumnName, col.ColumnName);
                }
            }

            // アダプター初期化
            SqlDataAdapter adap = new SqlDataAdapter();

            #region INSERTコマンド生成

            adap.InsertCommand = CreateInsertCommand(connection, srcTable, tableName, targetColumnMapping);

            #endregion

            #region UPDATEコマンド生成

            adap.UpdateCommand = CreateUpdateCommand(connection, srcTable, tableName, keyColNameList, targetColumnMapping);

            #endregion

            #region DELETEコマンド生成

            adap.DeleteCommand = CreateDeleteCommand(connection, srcTable, tableName, keyColNameList);

            #endregion

            return adap;
        }
        #endregion

        #region CreateUpdateAdapter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="srcTable"></param>
        /// <param name="tableName"></param>
        /// <param name="keyColNameList"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　habu　　    新規作成
        /// </history>
        public static SqlDataAdapter CreateDBUpdateAdapter(SqlConnection connection, DataTable srcTable, string tableName, List<string> keyColNameList)
        {
            Dictionary<string, string> targetColumnMapping = new Dictionary<string, string>();
            foreach (DataColumn col in srcTable.Columns)
            {
                targetColumnMapping.Add(col.ColumnName, col.ColumnName);
            }

            return CreateDBUpdateAdapter(connection, srcTable, tableName, keyColNameList, targetColumnMapping);
        }
        #endregion

        #region 旧バージョン
        //#region CreateUpdateAdapter
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="connection"></param>
        ///// <param name="table"></param>
        ///// <param name="tableName"></param>
        ///// <param name="keyColNameList"></param>
        ///// <returns></returns>
        //public static SqlDataAdapter CreateDBUpdateAdapter(SqlConnection connection, DataTable table, string tableName, List<string> keyColNameList)
        //{
        //    // アダプター初期化
        //    SqlDataAdapter adap = new SqlDataAdapter();

        //    #region INSERTコマンド生成

        //    adap.InsertCommand = CreateInsertCommand(connection, table, tableName);

        //    #endregion

        //    #region UPDATEコマンド生成

        //    adap.UpdateCommand = CreateUpdateCommand(connection, table, tableName, keyColNameList);

        //    #endregion

        //    #region DELETEコマンド生成

        //    adap.DeleteCommand = CreateDeleteCommand(connection, table, tableName, keyColNameList);

        //    #endregion

        //    return adap;
        //}
        //#endregion
        #endregion

        #region CreateDeleteCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="srcTable"></param>
        /// <param name="tableName"></param>
        /// <param name="whereColNameList"></param>
        /// <returns></returns>
        public static SqlCommand CreateDeleteCommand(SqlConnection connection, DataTable srcTable, string tableName, List<string> whereColNameList)
        {
            #region DELETE SQL生成

            //string tableName = table.TableName;

            StringBuilder sqlBuf = new StringBuilder();
            int idx = 0;

            sqlBuf.AppendFormat("DELETE FROM {0} ", tableName);

            sqlBuf.Append("WHERE ");
            idx = 0;
            foreach (DataColumn col in srcTable.Columns)
            {
                if (!whereColNameList.Contains(col.ColumnName))
                {
                    continue;
                }

                if (idx > 0) { sqlBuf.Append("AND "); }

                sqlBuf.AppendFormat("{0} = {2}{1} ", col.ColumnName, col.ColumnName, SQL_PARAM_PREFIX);

                idx++;
            }

            #endregion

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection;
            sqlCommand.CommandText = sqlBuf.ToString();
            sqlCommand.CommandType = CommandType.Text;

            #region SQLパラメータ生成

            foreach (DataColumn col in srcTable.Columns)
            {
                SqlParameter param = sqlCommand.Parameters.Add(new SqlParameter());
                param.ParameterName = string.Format("{1}{0}", col.ColumnName, SQL_PARAM_PREFIX);
                param.SourceColumn = col.ColumnName;
            }

            #endregion

            return sqlCommand;
        }
        #endregion

        #region CreateInsertCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="srcTable"></param>
        /// <param name="tableName"></param>
        /// <param name="targetColumnMapping"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　habu　　    新規作成
        /// </history>
        public static SqlCommand CreateInsertCommand(SqlConnection connection, DataTable srcTable, string tableName, Dictionary<string, string> targetColumnMapping)
        {
            #region INSERT SQL生成

            //string tableName = table.TableName;

            StringBuilder sqlBuf = new StringBuilder();
            int idx = 0;

            sqlBuf.AppendFormat("INSERT INTO {0} ", tableName);

            sqlBuf.Append("(");

            idx = 0;
            foreach (DataColumn col in srcTable.Columns)
            {
                string colName;
                // 更新対象外のカラムはスキップ
                if (targetColumnMapping == null || !targetColumnMapping.ContainsKey(col.ColumnName))
                {
                    continue;
                }
                else
                {
                    colName = targetColumnMapping[col.ColumnName];
                }

                if (!SET_UPDATE_COL_ON_INSERT)
                {
                    // 更新時情報は除外する
                    if (new List<string>(new string[] { COL_NAME_UPDATE_DT, COL_NAME_UPDATE_USER, COL_NAME_UPDATE_TERM }).Contains(colName))
                    {
                        continue;
                    }
                }

                if (idx > 0) { sqlBuf.Append(" ,"); }

                sqlBuf.AppendFormat("{0}", colName);

                idx++;
            }

            sqlBuf.Append(") ");

            sqlBuf.Append("VALUES(");
            idx = 0;
            foreach (DataColumn col in srcTable.Columns)
            {
                string colName;
                // 更新対象外のカラムはスキップ
                if (targetColumnMapping == null || !targetColumnMapping.ContainsKey(col.ColumnName))
                {
                    continue;
                }
                else
                {
                    colName = targetColumnMapping[col.ColumnName];
                }

                // 登録時に更新情報を設定しない場合
                if (!SET_UPDATE_COL_ON_INSERT)
                {
                    // 更新時情報は除外する
                    if (new List<string>(new string[] { COL_NAME_UPDATE_DT, COL_NAME_UPDATE_USER, COL_NAME_UPDATE_TERM }).Contains(colName))
                    {
                        continue;
                    }
                }

                if (idx > 0) { sqlBuf.Append(" ,"); }

                sqlBuf.AppendFormat("{1}{0}", colName, SQL_PARAM_PREFIX);

                idx++;
            }

            sqlBuf.Append(") ");

            #endregion

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection;
            sqlCommand.CommandText = sqlBuf.ToString();
            sqlCommand.CommandType = CommandType.Text;

            #region SQLパラメータ生成

            foreach (DataColumn col in srcTable.Columns)
            {
                string colName;
                if (targetColumnMapping != null && targetColumnMapping.ContainsKey(col.ColumnName))
                {
                    colName = targetColumnMapping[col.ColumnName];
                }
                else
                {
                    colName = col.ColumnName;
                }

                SqlParameter param = sqlCommand.Parameters.Add(new SqlParameter());
                param.ParameterName = string.Format("{1}{0}", col.ColumnName, SQL_PARAM_PREFIX);
                param.SourceColumn = colName;
            }

            #endregion

            return sqlCommand;
        }

        #region 旧バージョン
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="connection"></param>
        ///// <param name="table"></param>
        ///// <param name="tableName"></param>
        ///// <returns></returns>
        //public static SqlCommand CreateInsertCommand(SqlConnection connection, DataTable table, string tableName)
        //{
        //    #region INSERT SQL生成

        //    //string tableName = table.TableName;

        //    StringBuilder sqlBuf = new StringBuilder();
        //    int idx = 0;

        //    sqlBuf.AppendFormat("INSERT INTO {0} ", tableName);

        //    sqlBuf.Append("(");

        //    idx = 0;
        //    foreach (DataColumn col in table.Columns)
        //    {
        //        if (!SET_UPDATE_COL_ON_INSERT)
        //        {
        //            // 更新時情報は除外する
        //            if (new List<string>(new string[] { COL_NAME_UPDATE_DT, COL_NAME_UPDATE_USER, COL_NAME_UPDATE_TERM }).Contains(col.ColumnName))
        //            {
        //                continue;
        //            }
        //        }

        //        if (idx > 0) { sqlBuf.Append(" ,"); }

        //        sqlBuf.AppendFormat("{0}", col.ColumnName);

        //        idx++;
        //    }

        //    sqlBuf.Append(") ");

        //    sqlBuf.Append("VALUES(");
        //    idx = 0;
        //    foreach (DataColumn col in table.Columns)
        //    {
        //        if (!SET_UPDATE_COL_ON_INSERT)
        //        {
        //            // 更新時情報は除外する
        //            if (new List<string>(new string[] { COL_NAME_UPDATE_DT, COL_NAME_UPDATE_USER, COL_NAME_UPDATE_TERM }).Contains(col.ColumnName))
        //            {
        //                continue;
        //            }
        //        }

        //        if (idx > 0) { sqlBuf.Append(" ,"); }

        //        sqlBuf.AppendFormat("{1}{0}", col.ColumnName, SQL_PARAM_PREFIX);

        //        idx++;
        //    }

        //    sqlBuf.Append(") ");

        //    #endregion

        //    SqlCommand sqlCommand = new SqlCommand();

        //    sqlCommand.Connection = connection;
        //    sqlCommand.CommandText = sqlBuf.ToString();
        //    sqlCommand.CommandType = CommandType.Text;

        //    #region SQLパラメータ生成

        //    foreach (DataColumn col in table.Columns)
        //    {
        //        SqlParameter param = sqlCommand.Parameters.Add(new SqlParameter());
        //        param.ParameterName = string.Format("{1}{0}", col.ColumnName, SQL_PARAM_PREFIX);
        //        param.SourceColumn = col.ColumnName;
        //    }

        //    #endregion

        //    return sqlCommand;
        //}
        #endregion
        #endregion

        #region CreateUpdateCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="srcTable"></param>
        /// <param name="tableName"></param>
        /// <param name="whereColNameList"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　habu　　    新規作成
        /// </history>
        public static SqlCommand CreateUpdateCommand(SqlConnection connection, DataTable srcTable, string tableName, List<string> whereColNameList, Dictionary<string, string> targetColumnMapping)
        {
            #region UPDATE SQL生成

            //string tableName = table.TableName;

            StringBuilder sqlBuf = new StringBuilder();
            int idx = 0;

            sqlBuf.AppendFormat("UPDATE {0} ", tableName);

            sqlBuf.Append("SET ");
            idx = 0;

            // 更新対象DataTableに定義されているカラム全てを更新する、UPDATEを生成する
            foreach (DataColumn col in srcTable.Columns)
            {
                string colName;
                // 更新対象外のカラムはスキップ
                if (targetColumnMapping == null || !targetColumnMapping.ContainsKey(col.ColumnName))
                {
                    continue;
                }
                else
                {
                    colName = targetColumnMapping[col.ColumnName];
                }

                // 主キーは更新対象に含めない
                if (whereColNameList.Contains(colName))
                {
                    continue;
                }

                // 登録時情報は除外する
                if (new List<string>(new string[] { COL_NAME_INSERT_DT, COL_NAME_INSERT_USER, COL_NAME_INSERT_TERM }).Contains(colName))
                {
                    continue;
                }

                if (idx > 0) { sqlBuf.Append(" ,"); }

                sqlBuf.AppendFormat("{0} = {2}{1} ", colName, colName, SQL_PARAM_PREFIX);

                idx++;
            }

            sqlBuf.Append("WHERE ");
            idx = 0;
            foreach (DataColumn col in srcTable.Columns)
            {
                string colName;
                if (targetColumnMapping != null && targetColumnMapping.ContainsKey(col.ColumnName))
                {
                    colName = targetColumnMapping[col.ColumnName];
                }
                else
                {
                    colName = col.ColumnName;
                }

                if (!whereColNameList.Contains(colName))
                {
                    continue;
                }

                if (idx > 0) { sqlBuf.Append("AND "); }

                sqlBuf.AppendFormat("{0} = {2}{1} ", colName, colName, SQL_PARAM_PREFIX);

                idx++;
            }

            #endregion

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection;
            sqlCommand.CommandText = sqlBuf.ToString();
            sqlCommand.CommandType = CommandType.Text;

            #region SQLパラメータ生成

            foreach (DataColumn col in srcTable.Columns)
            {
                string colName;
                if (targetColumnMapping != null && targetColumnMapping.ContainsKey(col.ColumnName))
                {
                    colName = targetColumnMapping[col.ColumnName];
                }
                else
                {
                    colName = col.ColumnName;
                }

                SqlParameter param = sqlCommand.Parameters.Add(new SqlParameter());
                param.ParameterName = string.Format("{1}{0}", colName, SQL_PARAM_PREFIX);
                param.SourceColumn = colName;
            }

            #endregion

            return sqlCommand;
        }

        #region 旧バージョン
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="connection"></param>
        ///// <param name="table"></param>
        ///// <param name="tableName"></param>
        ///// <param name="whereColNameList"></param>
        ///// <returns></returns>
        //public static SqlCommand CreateUpdateCommand(SqlConnection connection, DataTable table, string tableName, List<string> whereColNameList)
        //{
        //    #region UPDATE SQL生成

        //    //string tableName = table.TableName;

        //    StringBuilder sqlBuf = new StringBuilder();
        //    int idx = 0;

        //    sqlBuf.AppendFormat("UPDATE {0} ", tableName);

        //    sqlBuf.Append("SET ");
        //    idx = 0;

        //    // 更新対象DataTableに定義されているカラム全てを更新する、UPDATEを生成する
        //    foreach (DataColumn col in table.Columns)
        //    {
        //        // 主キーは更新対象に含めない
        //        if (whereColNameList.Contains(col.ColumnName))
        //        {
        //            continue;
        //        }

        //        // 登録時情報は除外する
        //        if (new List<string>(new string[] { COL_NAME_INSERT_DT, COL_NAME_INSERT_USER, COL_NAME_INSERT_TERM }).Contains(col.ColumnName))
        //        {
        //            continue;
        //        }

        //        if (idx > 0) { sqlBuf.Append(" ,"); }

        //        sqlBuf.AppendFormat("{0} = {2}{1} ", col.ColumnName, col.ColumnName, SQL_PARAM_PREFIX);

        //        idx++;
        //    }

        //    sqlBuf.Append("WHERE ");
        //    idx = 0;
        //    foreach (DataColumn col in table.Columns)
        //    {
        //        if (!whereColNameList.Contains(col.ColumnName))
        //        {
        //            continue;
        //        }

        //        if (idx > 0) { sqlBuf.Append("AND "); }

        //        sqlBuf.AppendFormat("{0} = {2}{1} ", col.ColumnName, col.ColumnName, SQL_PARAM_PREFIX);

        //        idx++;
        //    }

        //    #endregion

        //    SqlCommand sqlCommand = new SqlCommand();

        //    sqlCommand.Connection = connection;
        //    sqlCommand.CommandText = sqlBuf.ToString();
        //    sqlCommand.CommandType = CommandType.Text;

        //    #region SQLパラメータ生成

        //    foreach (DataColumn col in table.Columns)
        //    {
        //        SqlParameter param = sqlCommand.Parameters.Add(new SqlParameter());
        //        param.ParameterName = string.Format("{1}{0}", col.ColumnName, SQL_PARAM_PREFIX);
        //        param.SourceColumn = col.ColumnName;
        //    }

        //    #endregion

        //    return sqlCommand;
        //}
        #endregion
        #endregion

        #region CreateDeleteByKey
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <param name="whereColNameList"></param>
        /// <param name="valueList"></param>
        /// <returns></returns>
        public static SqlCommand CreateDeleteByKeyCommand(SqlConnection connection, string tableName, List<string> whereColNameList, List<object> valueList)
        {
            #region DELETE SQL生成

            //string tableName = table.TableName;

            StringBuilder sqlBuf = new StringBuilder();
            int idx = 0;

            sqlBuf.AppendFormat("DELETE FROM {0} ", tableName);

            sqlBuf.Append("WHERE ");
            idx = 0;
            foreach (string col in whereColNameList)
            {
                if (idx > 0) { sqlBuf.Append("AND "); }

                sqlBuf.AppendFormat("{0} = '{1}' ", col, valueList[idx]);

                idx++;
            }

            #endregion

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection;
            sqlCommand.CommandText = sqlBuf.ToString();
            sqlCommand.CommandType = CommandType.Text;

            return sqlCommand;
        }
        #endregion

        #endregion
    }
}
