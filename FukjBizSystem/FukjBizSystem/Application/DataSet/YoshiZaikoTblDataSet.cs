using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet
{
    
    public partial class YoshiZaikoTblDataSet {
    }
}


namespace FukjBizSystem.Application.DataSet.YoshiZaikoTblDataSetTableAdapters
{
    #region YoshiZaikoTblTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiZaikoTblTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class YoshiZaikoTblTableAdapter
    {
        #region DeleteByShishoCdAndYoshiCd
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： DeleteByShishoCdAndYoshiCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Delete)]
        internal void DeleteByShishoCdAndYoshiCd(List<string> listKey)
        {
            SqlCommand sqlCommand = new SqlCommand();
            StringBuilder sqlContent = new StringBuilder();

            sqlContent.Append("DELETE FROM YoshiZaikoTbl WHERE YoshiZaikoShishoCd = '' AND YoshiZaikoYoshiCd = ''");
            
            int idx = 0;

            foreach (string key in listKey)
            {
                string shishoCd = key.Split('-')[0];
                string yoshiCd = key.Split('-')[1];

                sqlContent.AppendFormat(" OR (YoshiZaikoShishoCd = @yoshiZaikoShishoCd{0} AND YoshiZaikoYoshiCd = @yoshiZaikoYoshiCd{0})", idx);

                sqlCommand.Parameters.Add("@yoshiZaikoShishoCd" + idx, SqlDbType.NVarChar).Value = shishoCd;
                sqlCommand.Parameters.Add("@yoshiZaikoYoshiCd" + idx, SqlDbType.NVarChar).Value = yoshiCd;

                idx ++;
            }

            sqlCommand.CommandText = sqlContent.ToString();
            sqlCommand.Connection = this.Connection;

            //execute
            sqlCommand.ExecuteNonQuery();
        }
        #endregion
    }
    #endregion

    #region YoshiZaikoTblKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiZaikoTblKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YoshiZaikoTblKensakuTableAdapter {

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="yoshiCdFrom"></param>
        /// <param name="yoshiCdTo"></param>
        /// <param name="yoshiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YoshiZaikoTblDataSet.YoshiZaikoTblKensakuDataTable GetDataBySearchCond(string shishoCd, string yoshiCdFrom, string yoshiCdTo, string yoshiNm)
        {
            SqlCommand command = CreateSqlCommand(shishoCd, yoshiCdFrom, yoshiCdTo, yoshiNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YoshiZaikoTblDataSet.YoshiZaikoTblKensakuDataTable dataTable = new YoshiZaikoTblDataSet.YoshiZaikoTblKensakuDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="yoshiCdFrom"></param>
        /// <param name="yoshiCdTo"></param>
        /// <param name="yoshiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shishoCd, string yoshiCdFrom, string yoshiCdTo, string yoshiNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append("SELECT                   ");
            sqlContent.Append("      yzt.YoshiZaikoShishoCd, ");
            sqlContent.Append("      yzt.YoshiZaikoYoshiCd, ");
            sqlContent.Append("      yzt.YoshiZaikoSuryo, ");
            sqlContent.Append("      yzt.InsertDt, ");
            sqlContent.Append("      yzt.InsertUser, ");
            sqlContent.Append("      yzt.InsertTarm, ");
            sqlContent.Append("      yzt.UpdateDt, ");
            sqlContent.Append("      yzt.UpdateUser, ");
            sqlContent.Append("      yzt.UpdateTarm ");

            //FROM
            sqlContent.Append(" FROM                ");
            sqlContent.Append("      YoshiZaikoTbl yzt  ");

            if (!string.IsNullOrEmpty(yoshiNm))
            {            
                //JOIN
                sqlContent.Append(" INNER JOIN YoshiMst ym ON yzt.YoshiZaikoYoshiCd = ym.YoshiCd   ");
            }
            
            //WHERE
            sqlContent.Append(" WHERE 1=1 ");

            if (!string.IsNullOrEmpty(shishoCd))
            {
                sqlContent.Append(" AND yzt.YoshiZaikoShishoCd = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            //sqlContent.Append(" AND yzt.YoshiZaikoYoshiCd " + DataAccessUtility.SetBetweenCommand(yoshiCdFrom, yoshiCdTo, 2));
            if (!string.IsNullOrEmpty(yoshiCdFrom) && string.IsNullOrEmpty(yoshiCdTo))
            {
                sqlContent.Append(" AND yzt.YoshiZaikoYoshiCd >= @yoshiCdFrom  ");
                commandParams.Add("@yoshiCdFrom", SqlDbType.NVarChar).Value = yoshiCdFrom;
            }
            else if (string.IsNullOrEmpty(yoshiCdFrom) && !string.IsNullOrEmpty(yoshiCdTo))
            {
                sqlContent.Append(" AND yzt.YoshiZaikoYoshiCd <= @yoshiCdTo ");
                commandParams.Add("@yoshiCdTo", SqlDbType.NVarChar).Value = yoshiCdTo;
            }
            else if (!string.IsNullOrEmpty(yoshiCdFrom) && !string.IsNullOrEmpty(yoshiCdTo))
            {
                sqlContent.Append(" AND yzt.YoshiZaikoYoshiCd >= @yoshiCdFrom AND yzt.YoshiZaikoYoshiCd <= @yoshiCdTo ");
                commandParams.Add("@yoshiCdFrom", SqlDbType.NVarChar).Value = yoshiCdFrom;
                commandParams.Add("@yoshiCdTo", SqlDbType.NVarChar).Value = yoshiCdTo;
            }

            if (!string.IsNullOrEmpty(yoshiNm))
            {
                sqlContent.Append(" AND ym.YoshiNm LIKE CONCAT('%', @yoshiNm, '%') ");
                commandParams.Add("yoshiNm", SqlDbType.NVarChar).Value = yoshiNm;
            }

            sqlContent.Append(" ORDER BY yzt.YoshiZaikoShishoCd, yzt.YoshiZaikoYoshiCd");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    #endregion
}
