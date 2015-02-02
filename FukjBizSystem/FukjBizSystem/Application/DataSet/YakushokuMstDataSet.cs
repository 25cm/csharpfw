using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
    
    public partial class YakushokuMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.YakushokuMstDataSetTableAdapters
{

    #region YakushokuMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YakushokuMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YakushokuMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameCd"></param>
        /// <param name="yakushokuCdFrom"></param>
        /// <param name="yakushokuCdTo"></param>
        /// <param name="yakushokuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YakushokuMstDataSet.YakushokuMstKensakuDataTable GetDataBySearchCond(
            String nameCd,
            String yakushokuCdFrom,
            String yakushokuCdTo,
            String yakushokuNm)
        {
            SqlCommand command = CreateSqlCommand(nameCd,yakushokuCdFrom, yakushokuCdTo, yakushokuNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YakushokuMstDataSet.YakushokuMstKensakuDataTable dataTable = new YakushokuMstDataSet.YakushokuMstKensakuDataTable();
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
        /// <param name="nameCd"></param>
        /// <param name="yakushokuCdFrom"></param>
        /// <param name="yakushokuCdTo"></param>
        /// <param name="yakushokuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String nameCd,
            String yakushokuCdFrom,
            String yakushokuCdTo,
            String yakushokuNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                   ");
            sqlContent.Append("     YakushokuMst.YakushokuCd,                           ");
            sqlContent.Append("     YakushokuMst.YakushokuKbn,                          ");
            sqlContent.Append("     YakushokuMst.YakushokuNm,                            ");
            sqlContent.Append("     NameMst.Name                                        ");

            // FROM
            sqlContent.Append("FROM                                                     ");
            sqlContent.Append("     YakushokuMst                                        ");
            sqlContent.Append("LEFT OUTER JOIN                                          ");
            sqlContent.Append("     NameMst                                             ");
            sqlContent.Append("         ON NameMst.NameCd = YakushokuMst.YakushokuKbn   ");
            sqlContent.Append("         AND NameMst.NameKbn = '005'                     ");

            // WHERE
            sqlContent.Append("WHERE                                                    ");
            sqlContent.Append("     1 = 1                                               ");

            if (!String.IsNullOrEmpty(nameCd))
            {
                sqlContent.Append("AND YakushokuMst.YakushokuKbn = @nameCd              ");
                commandParams.Add("@nameCd", SqlDbType.NVarChar).Value = nameCd;
            }

            //sqlContent.Append("AND YakushokuMst.YakushokuCd " + DataAccessUtility.SetBetweenCommand(yakushokuCdFrom, yakushokuCdTo, 2));
            if (!String.IsNullOrEmpty(yakushokuCdFrom))
            {
                sqlContent.Append("AND YakushokuMst.YakushokuCd >= @yakushokuCdFrom ");
                commandParams.Add("@yakushokuCdFrom", SqlDbType.NVarChar).Value = yakushokuCdFrom;
            }

            if (!String.IsNullOrEmpty(yakushokuCdTo))
            {
                sqlContent.Append("AND YakushokuMst.YakushokuCd <= @yakushokuCdTo ");
                commandParams.Add("@yakushokuCdTo", SqlDbType.NVarChar).Value = yakushokuCdTo;
            }

            if (!String.IsNullOrEmpty(yakushokuNm))
            {
                sqlContent.Append("AND YakushokuMst.YakushokuNm LIKE concat('%', @yakushokuNm, '%') ");
                commandParams.Add("@yakushokuNm", SqlDbType.NVarChar).Value = yakushokuNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     YakushokuMst.YakushokuCd                             ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
