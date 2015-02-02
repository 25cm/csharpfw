using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{
    public partial class HokenjoMstDataSet
    {
    }
}

namespace FukjBizSystem.Application.DataSet.HokenjoMstDataSetTableAdapters
{

    #region HokenjoMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HokenjoMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HokenjoMstKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjyoCdTo"></param>
        /// <param name="hokenjyoCdFrom"></param>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal HokenjoMstDataSet.HokenjoMstKensakuDataTable GetDataBySearchCond(
            String hokenjyoCdFrom,
            String hokenjyoCdTo,
            String hokenjyoNm)
        {
            SqlCommand command = CreateHokenjoMstKensakuSqlCommand(hokenjyoCdFrom, hokenjyoCdTo, hokenjyoNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            HokenjoMstDataSet.HokenjoMstKensakuDataTable dataTable = new HokenjoMstDataSet.HokenjoMstKensakuDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateHokenjoMstKensakuSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateHokenjoMstKensakuSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjyoCdFrom"></param>
        /// <param name="hokenjyoCdTo"></param>
        /// <param name="hokenjyoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateHokenjoMstKensakuSqlCommand(
            String hokenjyoCdFrom,
            String hokenjyoCdTo,
            String hokenjyoNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                   ");
            sqlContent.Append("     HokenjoCd,                                          ");
            sqlContent.Append("     HokenjoNm,                                          ");
            sqlContent.Append("     HokenjoZipCd,                                       ");
            sqlContent.Append("     HokenjoTelNo,                                       ");
            sqlContent.Append("     HokenjoAdr,                                         ");
            //20150123 HuyTX Ver1.02
            sqlContent.Append("     DelFlg,                                             ");
            //End
            sqlContent.Append("     InsertDt,                                           ");
            sqlContent.Append("     InsertUser,                                         ");
            sqlContent.Append("     InsertTarm,                                         ");
            sqlContent.Append("     UpdateDt,                                           ");
            sqlContent.Append("     UpdateUser,                                         ");
            sqlContent.Append("     UpdateTarm                                          ");

            // FROM
            sqlContent.Append("FROM                                                     ");
            sqlContent.Append("     HokenjoMst                                          ");

            // WHERE
            sqlContent.Append("WHERE                                                    ");
            sqlContent.Append("     1 = 1                                               ");

            //sqlContent.Append("AND HokenjoCd " + DataAccessUtility.SetBetweenCommand(hokenjyoCdFrom, hokenjyoCdTo, 2));

            if (!string.IsNullOrEmpty(hokenjyoCdFrom) && string.IsNullOrEmpty(hokenjyoCdTo))
            {
                sqlContent.Append("AND HokenjoCd >= @hokenjyoCdFrom ");
                commandParams.Add("@hokenjyoCdFrom", SqlDbType.NVarChar).Value = hokenjyoCdFrom;
            }
            else if (string.IsNullOrEmpty(hokenjyoCdFrom) && !string.IsNullOrEmpty(hokenjyoCdTo))
            {
                sqlContent.Append("AND HokenjoCd <= @hokenjyoCdTo ");
                commandParams.Add("@hokenjyoCdTo", SqlDbType.NVarChar).Value = hokenjyoCdTo;
            }
            else if (!string.IsNullOrEmpty(hokenjyoCdFrom) && !string.IsNullOrEmpty(hokenjyoCdTo))
            {
                sqlContent.Append("AND HokenjoCd >= @hokenjyoCdFrom ");
                commandParams.Add("@hokenjyoCdFrom", SqlDbType.NVarChar).Value = hokenjyoCdFrom;

                sqlContent.Append("AND HokenjoCd <= @hokenjyoCdTo ");
                commandParams.Add("@hokenjyoCdTo", SqlDbType.NVarChar).Value = hokenjyoCdTo;
            }

            if (!String.IsNullOrEmpty(hokenjyoNm))
            {
                sqlContent.Append("AND HokenjoNm LIKE concat('%', @hokenjyoNm, '%')     ");
                commandParams.Add("@hokenjyoNm", SqlDbType.VarChar).Value = hokenjyoNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     HokenjoCd                                           ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
