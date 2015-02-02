using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {  
    
    public partial class YoshiMstDataSet {
        partial class YoshiMstDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.YoshiMstDataSetTableAdapters
{
    #region YoshiMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YoshiMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoshiCdFrom"></param>
        /// <param name="yoshiCdTo"></param>
        /// <param name="yoshiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 22014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YoshiMstDataSet.YoshiMstKensakuDataTable GetDataBySearchCond(
            String yoshiCdFrom,
            String yoshiCdTo,
            String yoshiNm)
        {
            SqlCommand command = CreateSqlCommand(yoshiCdFrom, yoshiCdTo, yoshiNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YoshiMstDataSet.YoshiMstKensakuDataTable dataTable = new YoshiMstDataSet.YoshiMstKensakuDataTable();
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
        /// <param name="yoshiCdFrom"></param>
        /// <param name="yoshiCdTo"></param>
        /// <param name="yoshiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String yoshiCdFrom,
            String yoshiCdTo,
            String yoshiNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                   ");
            sqlContent.Append("     YoshiCd,                                            ");
            sqlContent.Append("     YoshiNm,                                            ");
            sqlContent.Append("     YoshiKaiinUp,                                       ");
            sqlContent.Append("     YoshiHiKaiinUp,                                     ");
            sqlContent.Append("     YoshiKaiinSetKakaku,                                ");
            sqlContent.Append("     YoshiHiKaiinSetKakaku,                              ");
            sqlContent.Append("     YoshiSetBusu,                                       ");
            sqlContent.Append("     InsertDt,                                           ");
            sqlContent.Append("     InsertUser,                                         ");
            sqlContent.Append("     InsertTarm,                                         ");
            sqlContent.Append("     UpdateDt,                                           ");
            sqlContent.Append("     UpdateUser,                                         ");
            sqlContent.Append("     UpdateTarm                                          ");

            // FROM
            sqlContent.Append("FROM                                                     ");
            sqlContent.Append("     YoshiMst                                            ");

            // WHERE
            sqlContent.Append("WHERE                                                    ");
            sqlContent.Append("     1 = 1                                               ");

            //sqlContent.Append("AND YoshiCd " + DataAccessUtility.SetBetweenCommand(yoshiCdFrom, yoshiCdTo, 2));
            if (!String.IsNullOrEmpty(yoshiCdFrom) && String.IsNullOrEmpty(yoshiCdTo))
            {
                sqlContent.Append("AND YoshiCd >= @yoshiCdFrom ");
                commandParams.Add("@yoshiCdFrom", SqlDbType.NVarChar).Value = yoshiCdFrom;
            }
            else if (String.IsNullOrEmpty(yoshiCdFrom) && !String.IsNullOrEmpty(yoshiCdTo))
            {
                sqlContent.Append("AND YoshiCd <= @yoshiCdTo ");
                commandParams.Add("@yoshiCdTo", SqlDbType.NVarChar).Value = yoshiCdTo;
            }
            else if (!String.IsNullOrEmpty(yoshiCdFrom) && !String.IsNullOrEmpty(yoshiCdTo))
            {
                sqlContent.Append("AND YoshiCd >= @yoshiCdFrom AND YoshiCd <= @yoshiCdTo ");
                commandParams.Add("@yoshiCdFrom", SqlDbType.NVarChar).Value = yoshiCdFrom;
                commandParams.Add("@yoshiCdTo", SqlDbType.NVarChar).Value = yoshiCdTo;
            }

            if (!String.IsNullOrEmpty(yoshiNm))
            {
                sqlContent.Append("AND YoshiNm LIKE CONCAT('%', @yoshiNm, '%')          ");
                commandParams.Add("@yoshiNm", SqlDbType.VarChar).Value = yoshiNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     YoshiCd                                             ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
