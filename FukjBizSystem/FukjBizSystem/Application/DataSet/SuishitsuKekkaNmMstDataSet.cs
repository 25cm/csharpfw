using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet
{


    public partial class SuishitsuKekkaNmMstDataSet
    {
        partial class SuishitsuKekkaNmMstKensakuDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuKekkaNmMstDataSetTableAdapters
{
    #region SuishitsuKekkaNmMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKekkaNmMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKekkaNmMstKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="suishitsuKekkaNm"></param>
        /// <param name="suishitsuKekkaNmCdFrom"></param>
        /// <param name="suishitsuKekkaNmCdTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstKensakuDataTable GetDataBySearchCond(string shishoCd, string suishitsuKekkaNmCdFrom, string suishitsuKekkaNmCdTo, string suishitsuKekkaNm)
        {
            SqlCommand command = CreateSqlCommand(shishoCd, suishitsuKekkaNmCdFrom, suishitsuKekkaNmCdTo, suishitsuKekkaNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstKensakuDataTable dataTable = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstKensakuDataTable();
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
        /// <param name="suishitsuKekkaNm"></param>
        /// <param name="suishitsuKekkaNmCdFrom"></param>
        /// <param name="suishitsuKekkaNmCdTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shishoCd, string suishitsuKekkaNmCdFrom, string suishitsuKekkaNmCdTo, string suishitsuKekkaNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append("SELECT  ");
            sqlContent.Append("sk.SuishitsuKekkaShishoCd,   ");
            sqlContent.Append("ss.ShishoNm,   ");
            sqlContent.Append("sk.SuishitsuKekkaNmCd,   ");
            sqlContent.Append("sk.SuishitsuKekkaNm   ");

            //FROM
            sqlContent.Append("FROM SuishitsuKekkaNmMst sk   ");

            //JOIN
            sqlContent.Append("LEFT JOIN ShishoMst ss   ");
            sqlContent.Append("ON   ");
            sqlContent.Append("sk.SuishitsuKekkaShishoCd = ss.ShishoCd  ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            if (!string.IsNullOrEmpty(shishoCd))
            {
                sqlContent.Append("AND SuishitsuKekkaShishoCd = @suishitsuKekkaShishoCd                  ");
                commandParams.Add("@suishitsuKekkaShishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            //sqlContent.Append("AND SuishitsuKekkaNmCd " + DataAccessUtility.SetBetweenCommand(suishitsuKekkaNmCdFrom, suishitsuKekkaNmCdTo, 3));
            if (!string.IsNullOrEmpty(suishitsuKekkaNmCdFrom) && string.IsNullOrEmpty(suishitsuKekkaNmCdTo))
            {
                sqlContent.Append("AND SuishitsuKekkaNmCd >= @suishitsuKekkaNmCdFrom                      ");
                commandParams.Add("@suishitsuKekkaNmCdFrom", SqlDbType.NVarChar).Value = suishitsuKekkaNmCdFrom;
            }
            else if (string.IsNullOrEmpty(suishitsuKekkaNmCdFrom) && !string.IsNullOrEmpty(suishitsuKekkaNmCdTo))
            {
                sqlContent.Append("AND SuishitsuKekkaNmCd <= @suishitsuKekkaNmCdTo                        ");
                commandParams.Add("@suishitsuKekkaNmCdTo", SqlDbType.NVarChar).Value = suishitsuKekkaNmCdTo;
            }
            else if (!string.IsNullOrEmpty(suishitsuKekkaNmCdFrom) && !string.IsNullOrEmpty(suishitsuKekkaNmCdTo))
            {
                sqlContent.Append("AND SuishitsuKekkaNmCd >= @suishitsuKekkaNmCdFrom                      ");
                sqlContent.Append("AND SuishitsuKekkaNmCd <= @suishitsuKekkaNmCdTo                        ");
                commandParams.Add("@suishitsuKekkaNmCdFrom", SqlDbType.NVarChar).Value = suishitsuKekkaNmCdFrom;
                commandParams.Add("@suishitsuKekkaNmCdTo", SqlDbType.NVarChar).Value = suishitsuKekkaNmCdTo;
            }

            if (!string.IsNullOrEmpty(suishitsuKekkaNm))
            {
                sqlContent.Append("AND SuishitsuKekkaNm LIKE concat('%', @suishitsuKekkaNm, '%')          ");
                commandParams.Add("@suishitsuKekkaNm", SqlDbType.NVarChar).Value = suishitsuKekkaNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY SuishitsuKekkaShishoCd, SuishitsuKekkaNmCd                         ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    #endregion

    #region SuishitsuKekkaNmMstTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKekkaNmMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/07　宗       　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKekkaNmMstTableAdapter
    {
        #region GetDataBySearchCondFromTo
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="suishitsuKekkaNm"></param>
        /// <param name="suishitsuKekkaNmCdFrom"></param>
        /// <param name="suishitsuKekkaNmCdTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/07　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable GetDataBySearchCondFromTo(string shishoCd, string suishitsuKekkaNmCdFrom, string suishitsuKekkaNmCdTo)
        {
            SqlCommand command = CreateSqlCommand(shishoCd, suishitsuKekkaNmCdFrom, suishitsuKekkaNmCdTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable dataTable = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable();
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
        /// <param name="suishitsuKekkaNm"></param>
        /// <param name="suishitsuKekkaNmCdFrom"></param>
        /// <param name="suishitsuKekkaNmCdTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/07　宗       　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shishoCd, string suishitsuKekkaNmCdFrom, string suishitsuKekkaNmCdTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append("SELECT ");
            sqlContent.Append("SuishitsuKekkaShishoCd ");
            sqlContent.Append(", SuishitsuKekkaNmCd ");
            sqlContent.Append(", SuishitsuKekkaNm ");
            sqlContent.Append(", InsertDt ");
            sqlContent.Append(", InsertUser ");
            sqlContent.Append(", InsertTarm ");
            sqlContent.Append(", UpdateDt ");
            sqlContent.Append(", UpdateUser ");
            sqlContent.Append(", UpdateTarm  ");

            //FROM
            sqlContent.Append("FROM SuishitsuKekkaNmMst ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            if (!string.IsNullOrEmpty(shishoCd))
            {
                sqlContent.Append("AND SuishitsuKekkaShishoCd = @suishitsuKekkaShishoCd ");
                commandParams.Add("@suishitsuKekkaShishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            if (!string.IsNullOrEmpty(suishitsuKekkaNmCdFrom))
            {
                sqlContent.Append("AND SuishitsuKekkaNmCd >= @suishitsuKekkaNmCdFrom ");
                commandParams.Add("@suishitsuKekkaNmCdFrom", SqlDbType.NVarChar).Value = suishitsuKekkaNmCdFrom;
            }

            if (!string.IsNullOrEmpty(suishitsuKekkaNmCdTo))
            {
                sqlContent.Append("AND SuishitsuKekkaNmCd <= @suishitsuKekkaNmCdTo ");
                commandParams.Add("@suishitsuKekkaNmCdTo", SqlDbType.NVarChar).Value = suishitsuKekkaNmCdTo;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY SuishitsuKekkaShishoCd, SuishitsuKekkaNmCd ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    #endregion
}

namespace FukjBizSystem.Application.DataSet.SuishitsuKekkaNmMstDataSetTableAdapters
{
    
    
    public partial class SuishitsuKekkaNmMstKensakuTableAdapter {
    }
}
