using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{

    public partial class NameMstDataSet
    {
    }
}

namespace FukjBizSystem.Application.DataSet.NameMstDataSetTableAdapters
{
    #region NameMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： NameMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class NameMstKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameKbn"></param>
        /// <param name="nameCdFrom"></param>
        /// <param name="nameCdTo"></param>
        /// <param name="name"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal NameMstDataSet.NameMstKensakuDataTable GetDataBySearchCond(
            String nameKbn,
            String nameCdFrom,
            String nameCdTo,
            String name)
        {
            SqlCommand command = CreateNameMstKensakuSqlCommand(nameKbn, nameCdFrom, nameCdTo, name);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            NameMstDataSet.NameMstKensakuDataTable dataTable = new NameMstDataSet.NameMstKensakuDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateNameMstKensakuSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateNameMstKensakuSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameKbn"></param>
        /// <param name="nameCdFrom"></param>
        /// <param name="nameCdTo"></param>
        /// <param name="name"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateNameMstKensakuSqlCommand(
            String nameKbn,
            String nameCdFrom,
            String nameCdTo,
            String name)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                   ");
            sqlContent.Append("     NameKbn,                                            ");
            sqlContent.Append("     NameCd,                                             ");
            sqlContent.Append("     Name,                                               ");
            sqlContent.Append("     DeleteFlg,                                          ");
            sqlContent.Append("     InsertDt,                                           ");
            sqlContent.Append("     InsertUser,                                         ");
            sqlContent.Append("     InsertTarm,                                         ");
            sqlContent.Append("     UpdateDt,                                           ");
            sqlContent.Append("     UpdateUser,                                         ");
            sqlContent.Append("     UpdateTarm                                          ");

            // FROM
            sqlContent.Append("FROM                                                     ");
            sqlContent.Append("     NameMst                                             ");

            // WHERE
            sqlContent.Append("WHERE                                                    ");
            sqlContent.Append("     1 = 1                                               ");

            if (!String.IsNullOrEmpty(nameKbn))
            {
                sqlContent.Append("AND NameKbn = @nameKbn                                ");
                commandParams.Add("@nameKbn", SqlDbType.NVarChar).Value = nameKbn;
            }
            else
            {
                sqlContent.Append("AND NameKbn <> '000'                                 ");
            }

            //sqlContent.Append("AND NameCd " + DataAccessUtility.SetBetweenCommand(nameCdFrom, nameCdTo, 3));
            if (!String.IsNullOrEmpty(nameCdFrom) && String.IsNullOrEmpty(nameCdTo))
            {
                sqlContent.Append("AND NameCd >= @nameCdFrom ");
                commandParams.Add("@nameCdFrom", SqlDbType.NVarChar).Value = nameCdFrom;
            }
            else if (String.IsNullOrEmpty(nameCdFrom) &&! String.IsNullOrEmpty(nameCdTo))
            {
                sqlContent.Append("AND NameCd <= @nameCdTo ");
                commandParams.Add("@nameCdTo", SqlDbType.NVarChar).Value = nameCdTo;
            }
            else if (!String.IsNullOrEmpty(nameCdFrom) && !String.IsNullOrEmpty(nameCdTo))
            {
                sqlContent.Append("AND NameCd >= @nameCdFrom ");
                commandParams.Add("@nameCdFrom", SqlDbType.NVarChar).Value = nameCdFrom;

                sqlContent.Append("AND NameCd <= @nameCdTo ");
                commandParams.Add("@nameCdTo", SqlDbType.NVarChar).Value = nameCdTo;
            }

            if (!String.IsNullOrEmpty(name))
            {
                sqlContent.Append("AND Name LIKE concat('%', @name, '%')                ");
                commandParams.Add("@name", SqlDbType.NVarChar).Value = name;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     NameKbn, NameCd                                     ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}