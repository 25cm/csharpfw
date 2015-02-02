using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
    public partial class GaikankensaKomokuMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.GaikankensaKomokuMstDataSetTableAdapters
{

    #region GaikankensaKomokuMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaikankensaKomokuMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GaikankensaKomokuMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gaikankensaKomokuCdFrom"></param>
        /// <param name="gaikankensaKomokuCdTo"></param>
        /// <param name="gaikankensaKomokuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal GaikankensaKomokuMstDataSet.GaikankensaKomokuMstKensakuDataTable GetDataBySearchCond(
            String gaikankensaKomokuCdFrom,
            String gaikankensaKomokuCdTo,
            String gaikankensaKomokuNm)
        {
            SqlCommand command = CreateSqlCommand(gaikankensaKomokuCdFrom, gaikankensaKomokuCdTo, gaikankensaKomokuNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            GaikankensaKomokuMstDataSet.GaikankensaKomokuMstKensakuDataTable dataTable = new GaikankensaKomokuMstDataSet.GaikankensaKomokuMstKensakuDataTable();
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
        /// <param name="gaikankensaKomokuCdFrom"></param>
        /// <param name="gaikankensaKomokuCdTo"></param>
        /// <param name="gaikankensaKomokuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String gaikankensaKomokuCdFrom,
            String gaikankensaKomokuCdTo,
            String gaikankensaKomokuNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                   ");
            sqlContent.Append("     GaikankensaKomokuCd,                                ");
            sqlContent.Append("     GaikankensaKomokuNm,                                ");
            sqlContent.Append("     ZenGaikankensaKomokuCd,                             ");
            sqlContent.Append("     ZenGaikankensaKomokuRyakumei,                       ");
            sqlContent.Append("     InsertDt,                                           ");
            sqlContent.Append("     InsertUser,                                         ");
            sqlContent.Append("     InsertTarm,                                         ");
            sqlContent.Append("     UpdateDt,                                           ");
            sqlContent.Append("     UpdateUser,                                         ");
            sqlContent.Append("     UpdateTarm                                          ");

            // FROM
            sqlContent.Append("FROM                                                     ");
            sqlContent.Append("     GaikankensaKomokuMst                                ");

            // WHERE
            sqlContent.Append("WHERE                                                    ");
            sqlContent.Append("     1 = 1                                               ");

            //sqlContent.Append("AND GaikankensaKomokuCd " + DataAccessUtility.SetBetweenCommand(gaikankensaKomokuCdFrom, gaikankensaKomokuCdTo, 3));

            if (!string.IsNullOrEmpty(gaikankensaKomokuCdFrom) && string.IsNullOrEmpty(gaikankensaKomokuCdTo))
            {
                sqlContent.Append("AND GaikankensaKomokuCd >= @gaikankensaKomokuCdFrom ");
                commandParams.Add("@gaikankensaKomokuCdFrom", SqlDbType.NVarChar).Value = gaikankensaKomokuCdFrom;
            }
            else if (string.IsNullOrEmpty(gaikankensaKomokuCdFrom) && !string.IsNullOrEmpty(gaikankensaKomokuCdTo))
            {
                sqlContent.Append("AND GaikankensaKomokuCd <= @gaikankensaKomokuCdTo ");
                commandParams.Add("@gaikankensaKomokuCdTo", SqlDbType.NVarChar).Value = gaikankensaKomokuCdTo;
            }
            else if (!string.IsNullOrEmpty(gaikankensaKomokuCdFrom) && !string.IsNullOrEmpty(gaikankensaKomokuCdTo))
            {
                sqlContent.Append("AND GaikankensaKomokuCd >= @gaikankensaKomokuCdFrom ");
                commandParams.Add("@gaikankensaKomokuCdFrom", SqlDbType.NVarChar).Value = gaikankensaKomokuCdFrom;

                sqlContent.Append("AND GaikankensaKomokuCd <= @gaikankensaKomokuCdTo ");
                commandParams.Add("@gaikankensaKomokuCdTo", SqlDbType.NVarChar).Value = gaikankensaKomokuCdTo;
            }
            
            if (!String.IsNullOrEmpty(gaikankensaKomokuNm))
            {
                sqlContent.Append("AND GaikankensaKomokuNm LIKE concat('%', @gaikankensaKomokuNm, '%')     ");
                commandParams.Add("@gaikankensaKomokuNm", SqlDbType.VarChar).Value = gaikankensaKomokuNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     GaikankensaKomokuCd                                 ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
