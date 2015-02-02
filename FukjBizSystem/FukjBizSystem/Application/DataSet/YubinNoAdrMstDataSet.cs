using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet {
    
    public partial class YubinNoAdrMstDataSet {
        partial class YubinNoAdrMstKensakuDataTable
        {
        }
    }

}

namespace FukjBizSystem.Application.DataSet.YubinNoAdrMstDataSetTableAdapters
{
    #region YubinNoAdrMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YubinNoAdrMstKensakuTableAdapter
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
    public partial class YubinNoAdrMstKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipCd"></param>
        /// <param name="address"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YubinNoAdrMstDataSet.YubinNoAdrMstKensakuDataTable GetDataBySearchCond(string zipCd, string address)
        {
            SqlCommand command = CreateSqlCommand(zipCd, address);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YubinNoAdrMstDataSet.YubinNoAdrMstKensakuDataTable dataTable = new YubinNoAdrMstDataSet.YubinNoAdrMstKensakuDataTable();
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
        /// <param name="zipCd"></param>
        /// <param name="address"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string zipCd, string address)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append("SELECT                   ");
            sqlContent.Append("ZipCd,                   ");
            sqlContent.Append("OldZipCd,                ");
            sqlContent.Append("TodofukenKana,           ");
            sqlContent.Append("ShikuchosonKana,         ");
            sqlContent.Append("ChoikiKana,              ");
            sqlContent.Append("TodofukenNm,             ");
            sqlContent.Append("ShikuchosonNm,           ");
            sqlContent.Append("ChoikiNm,                ");
            sqlContent.Append("ChihoKokyoDantaiCd       ");

            //FROM
            sqlContent.Append("FROM   ");
            sqlContent.Append("YubinNoAdrMst  ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            if (!string.IsNullOrEmpty(zipCd))
            {
                sqlContent.Append("AND ZipCd LIKE CONCAT('%', @zipCd, '%')");
                commandParams.Add("@zipCd", SqlDbType.NVarChar).Value = zipCd;
            }

            if (!string.IsNullOrEmpty(address))
            {
                sqlContent.Append("AND ( CONCAT(TodofukenNm, ShikuchosonNm, ChoikiNm) LIKE CONCAT ('%', @address, '%') ");
                sqlContent.Append("OR CONCAT(TodofukenKana, ShikuchosonKana, ChoikiKana) LIKE CONCAT ('%', @address, '%') ) ");
                commandParams.Add("@address", SqlDbType.NVarChar).Value = address;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ZipCd");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

    }
    #endregion
}
