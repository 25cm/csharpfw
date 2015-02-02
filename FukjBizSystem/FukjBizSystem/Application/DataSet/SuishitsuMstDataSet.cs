using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
    
    public partial class SuishitsuMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuMstDataSetTableAdapters
{

    #region SuishitsuMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShishoCd"></param>
        /// <param name="SuishitsuCdFrom"></param>
        /// <param name="SuishitsuCdTo"></param>
        /// <param name="SuishitsuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuMstDataSet.SuishitsuMstKensakuDataTable GetDataBySearchCond(
            String shishoCd,
            String suishitsuCdFrom,
            String suishitsuCdTo,
            String suishitsuNm)
        {
            SqlCommand command = CreateSuishitsuMstKensakuSqlCommand
                (
                    shishoCd,
                    suishitsuCdFrom,
                    suishitsuCdTo,
                    suishitsuNm
                );

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuMstDataSet.SuishitsuMstKensakuDataTable dataTable = new SuishitsuMstDataSet.SuishitsuMstKensakuDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateSuishitsuMstKensakuSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSuishitsuMstKensakuSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShishoCd"></param>
        /// <param name="ShishoNm"></param>
        /// <param name="SuishitsuCdFrom"></param>
        /// <param name="SuishitsuCdTo"></param>
        /// <param name="SuishitsuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSuishitsuMstKensakuSqlCommand(
            String shishoCd,
            String suishitsuCdFrom,
            String suishitsuCdTo,
            String suishitsuNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                   ");
            sqlContent.Append("     SuishitsuCd,                                        ");
            sqlContent.Append("     SuishitsuNm,                                        ");
            sqlContent.Append("     ShishoCd,                                           ");
            sqlContent.Append("     ShishoNm,                                           ");
            sqlContent.Append("     SuishitsuShishoCd,                                  ");
            sqlContent.Append("     ShishoZipCd,                                        ");
            sqlContent.Append("     ShishoAdr,                                          ");
            sqlContent.Append("     ShishoTelNo,                                        ");
            sqlContent.Append("     ShishoFaxNo,                                        ");
            sqlContent.Append("     ShishoFreeDial                                      ");

            // FROM
            sqlContent.Append("FROM                                                     ");
            sqlContent.Append("     SuishitsuMst                                        ");
            sqlContent.Append("INNER JOIN                                               ");
            sqlContent.Append("     ShishoMst                                           ");
            sqlContent.Append("ON   ShishoMst.ShishoCd = SuishitsuMst.SuishitsuShishoCd ");

            // WHERE
            sqlContent.Append("WHERE                                                    ");
            sqlContent.Append("     1 = 1                                               ");

            if (!String.IsNullOrEmpty(shishoCd))
            {
                sqlContent.Append("AND ShishoCd = CAST(@shishoCd AS INT) ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            //sqlContent.Append("AND SuishitsuCd " + DataAccessUtility.SetBetweenCommand(suishitsuCdFrom, suishitsuCdTo, 3));
            if (!string.IsNullOrEmpty(suishitsuCdFrom) && string.IsNullOrEmpty(suishitsuCdTo))
            {
                sqlContent.Append("AND SuishitsuCd >= @suishitsuCdFrom ");
                commandParams.Add("@suishitsuCdFrom", SqlDbType.NVarChar).Value = suishitsuCdFrom;
            }
            else if (string.IsNullOrEmpty(suishitsuCdFrom) && !string.IsNullOrEmpty(suishitsuCdTo))
            {
                sqlContent.Append("AND SuishitsuCd <= @suishitsuCdTo ");
                commandParams.Add("@suishitsuCdTo", SqlDbType.NVarChar).Value = suishitsuCdTo;
            }
            else if (!string.IsNullOrEmpty(suishitsuCdFrom) && !string.IsNullOrEmpty(suishitsuCdTo))
            {
                sqlContent.Append("AND SuishitsuCd >= @suishitsuCdFrom ");
                commandParams.Add("@suishitsuCdFrom", SqlDbType.NVarChar).Value = suishitsuCdFrom;

                sqlContent.Append("AND SuishitsuCd <= @suishitsuCdTo ");
                commandParams.Add("@suishitsuCdTo", SqlDbType.NVarChar).Value = suishitsuCdTo;
            }

            if (!String.IsNullOrEmpty(suishitsuNm))
            {
                sqlContent.Append("AND SuishitsuNm LIKE CONCAT('%', @suishitsuNm, '%')    ");
                commandParams.Add("@suishitsuNm", SqlDbType.NVarChar).Value = suishitsuNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     SuishitsuCd                                          ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
