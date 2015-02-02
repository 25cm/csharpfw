using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet
{
}

namespace FukjBizSystem.Application.DataSet
{
}

namespace FukjBizSystem.Application.DataSet
{
}

namespace FukjBizSystem.Application.DataSet.ShoriHoshikiMstDataSetTableAdapters
{
    #region ShoriHoshikiMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShoriHoshikiMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShoriHoshikiMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shoriHoshikiKbnFrom"></param>
        /// <param name="shoriHoshikiKbnTo"></param>
        /// <param name="shoriHoshikiCdFrom"></param>
        /// <param name="shoriHoshikiCdTo"></param>
        /// <param name="shoriHoshikiShubetsuNm"></param>
        /// <param name="shoriHoshikiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable GetDataBySearchCond(
            String shoriHoshikiKbnFrom,
            String shoriHoshikiKbnTo,
            String shoriHoshikiCdFrom,
            String shoriHoshikiCdTo,
            String shoriHoshikiShubetsuNm,
            String shoriHoshikiNm)
        {
            SqlCommand command = CreateSqlCommand(shoriHoshikiKbnFrom, 
                                                    shoriHoshikiKbnTo, 
                                                    shoriHoshikiCdFrom,
                                                    shoriHoshikiCdTo,
                                                    shoriHoshikiShubetsuNm,
                                                    shoriHoshikiNm
                                                    );

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable dataTable = new ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable();
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
        /// <param name="shoriHoshikiKbnFrom"></param>
        /// <param name="shoriHoshikiKbnTo"></param>
        /// <param name="shoriHoshikiCdFrom"></param>
        /// <param name="shoriHoshikiCdTo"></param>
        /// <param name="shoriHoshikiShubetsuNm"></param>
        /// <param name="shoriHoshikiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String shoriHoshikiKbnFrom,
            String shoriHoshikiKbnTo,
            String shoriHoshikiCdFrom,
            String shoriHoshikiCdTo,
            String shoriHoshikiShubetsuNm,
            String shoriHoshikiNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                   ");
            sqlContent.Append("     ShoriHoshikiKbn,                                    ");
            sqlContent.Append("     ShoriHoshikiCd,                                     ");
            sqlContent.Append("     ShoriHoshikiShubetsuNm,                             ");
            sqlContent.Append("     ShoriHoshikiNm,                                     ");
            sqlContent.Append("     ShoriHoshikiShubetsuKbn,                            ");
            sqlContent.Append("     ShoriHoshikiNaibuNm,                                ");
            sqlContent.Append("     InsertDt,                                           ");
            sqlContent.Append("     InsertUser,                                         ");
            sqlContent.Append("     InsertTarm,                                         ");
            sqlContent.Append("     UpdateDt,                                           ");
            sqlContent.Append("     UpdateUser,                                         ");
            sqlContent.Append("     UpdateTarm                                          ");

            // FROM
            sqlContent.Append("FROM                                                     ");
            sqlContent.Append("     ShoriHoshikiMst                                     ");

            // WHERE
            sqlContent.Append("WHERE                                                    ");
            sqlContent.Append("     1 = 1                                               ");

            //sqlContent.Append("AND ShoriHoshikiKbn " + DataAccessUtility.SetBetweenCommand(shoriHoshikiKbnFrom, shoriHoshikiKbnTo, 1));
            if (!string.IsNullOrEmpty(shoriHoshikiKbnFrom) && string.IsNullOrEmpty(shoriHoshikiKbnTo))
            {
                sqlContent.Append("AND ShoriHoshikiKbn >= @shoriHoshikiKbnFrom ");
                commandParams.Add("@shoriHoshikiKbnFrom", SqlDbType.NVarChar).Value = shoriHoshikiKbnFrom;
            }
            else if (string.IsNullOrEmpty(shoriHoshikiKbnFrom) && !string.IsNullOrEmpty(shoriHoshikiKbnTo))
            {
                sqlContent.Append("AND ShoriHoshikiKbn <= @shoriHoshikiKbnTo ");
                commandParams.Add("@shoriHoshikiKbnTo", SqlDbType.NVarChar).Value = shoriHoshikiKbnTo;
            }
            else if (!string.IsNullOrEmpty(shoriHoshikiKbnFrom) && !string.IsNullOrEmpty(shoriHoshikiKbnTo))
            {
                sqlContent.Append("AND ShoriHoshikiKbn >= @shoriHoshikiKbnFrom ");
                commandParams.Add("@shoriHoshikiKbnFrom", SqlDbType.NVarChar).Value = shoriHoshikiKbnFrom;

                sqlContent.Append("AND ShoriHoshikiKbn <= @shoriHoshikiKbnTo ");
                commandParams.Add("@shoriHoshikiKbnTo", SqlDbType.NVarChar).Value = shoriHoshikiKbnTo;
            }

            //sqlContent.Append("AND ShoriHoshikiCd " + DataAccessUtility.SetBetweenCommand(shoriHoshikiCdFrom, shoriHoshikiCdTo, 3));
            if (!string.IsNullOrEmpty(shoriHoshikiCdFrom) && string.IsNullOrEmpty(shoriHoshikiCdTo))
            {
                sqlContent.Append("AND ShoriHoshikiCd >= @shoriHoshikiCdFrom ");
                commandParams.Add("@shoriHoshikiCdFrom", SqlDbType.NVarChar).Value = shoriHoshikiCdFrom;
            }
            else if (string.IsNullOrEmpty(shoriHoshikiCdFrom) && !string.IsNullOrEmpty(shoriHoshikiCdTo))
            {
                sqlContent.Append("AND ShoriHoshikiCd <= @shoriHoshikiCdTo ");
                commandParams.Add("@shoriHoshikiCdTo", SqlDbType.NVarChar).Value = shoriHoshikiCdTo;
            }
            else if (!string.IsNullOrEmpty(shoriHoshikiCdFrom) && !string.IsNullOrEmpty(shoriHoshikiCdTo))
            {
                sqlContent.Append("AND ShoriHoshikiCd <= @shoriHoshikiCdTo ");
                commandParams.Add("@shoriHoshikiCdTo", SqlDbType.NVarChar).Value = shoriHoshikiCdTo;

                sqlContent.Append("AND ShoriHoshikiCd >= @shoriHoshikiCdFrom ");
                commandParams.Add("@shoriHoshikiCdFrom", SqlDbType.NVarChar).Value = shoriHoshikiCdFrom;
            }

            if (!String.IsNullOrEmpty(shoriHoshikiShubetsuNm))
            {
                sqlContent.Append("AND ShoriHoshikiShubetsuNm LIKE concat('%', @shoriHoshikiShubetsuNm, '%') ");
                commandParams.Add("@shoriHoshikiShubetsuNm", SqlDbType.NVarChar).Value = shoriHoshikiShubetsuNm;
            }

            if (!String.IsNullOrEmpty(shoriHoshikiNm))
            {
                sqlContent.Append("AND ShoriHoshikiNm LIKE concat('%', @shoriHoshikiNm, '%') ");
                commandParams.Add("@shoriHoshikiNm", SqlDbType.NVarChar).Value = shoriHoshikiNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     ShoriHoshikiKbn, ShoriHoshikiCd                                       ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}

namespace FukjBizSystem.Application.DataSet {

    public partial class ShoriHoshikiMstDataSet {
    }
}
