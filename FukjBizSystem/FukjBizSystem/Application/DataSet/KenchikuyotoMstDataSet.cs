using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class KenchikuyotoMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.KenchikuyotoMstDataSetTableAdapters
{
    #region KenchikuyotoMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KenchikuyotoMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/28　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KenchikuyotoMstKensakuTableAdapter {

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        ///<param name="kenchikuyotoDaibunrui"></param>
        /// <param name="kenchikuyotoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable GetDataBySearchCond(string kenchikuyotoDaibunrui, string kenchikuyotoNm)
        {
            SqlCommand command = CreateSqlCommand(kenchikuyotoDaibunrui, kenchikuyotoNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable dataTable = new KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable();
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
        /// <param name="kenchikuyotoDaibunrui"></param>
        /// <param name="kenchikuyotoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string kenchikuyotoDaibunrui, string kenchikuyotoNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append("SELECT                                                                                           ");

            sqlContent.Append("KenchikuyotoMst.KenchikuyotoDaibunrui,                                                           ");
            sqlContent.Append("KenchikuyotoDaibunruiMst.KenchikuyotoDaibunruiNm,                                                ");
            sqlContent.Append("KenchikuyotoMst.KenchikuyotoShobunrui,                                                           ");
            sqlContent.Append("KenchikuyotoShobunruiMst.KenchikuyotoShobunruiNm,                                                ");
            sqlContent.Append("KenchikuyotoMst.KenchikuyotoRenban,                                                              ");
            sqlContent.Append("KenchikuyotoMst.KenchikuyotoNm                                                                   ");
            sqlContent.Append("FROM                                                                                             ");
            sqlContent.Append("KenchikuyotoMst                                                                                  ");

            //JOIN
            sqlContent.Append("LEFT JOIN                                                                                        ");
            sqlContent.Append("         KenchikuyotoDaibunruiMst                                                                ");
            sqlContent.Append("ON KenchikuyotoMst. KenchikuyotoDaibunrui = KenchikuyotoDaibunruiMst.KenchikuyotoDaibunruiCd     ");
            sqlContent.Append("LEFT JOIN                                                                                        ");
            sqlContent.Append("         KenchikuyotoShobunruiMst                                                                ");
            sqlContent.Append("ON KenchikuyotoMst.KenchikuyotoShobunrui = KenchikuyotoShobunruiMst.KenchikuyotoShobunruiCd      ");

            //WHERE
            sqlContent.Append("WHERE 1 = 1                                  ");

            if (!string.IsNullOrEmpty(kenchikuyotoDaibunrui))
            {
                sqlContent.Append("AND KenchikuyotoMst.KenchikuyotoDaibunrui = @kenchikuyotoDaibunrui                               ");
                commandParams.Add("@kenchikuyotoDaibunrui", SqlDbType.NVarChar).Value = kenchikuyotoDaibunrui;
            }

            if (!string.IsNullOrEmpty(kenchikuyotoNm))
            {
                sqlContent.Append("AND KenchikuyotoMst.KenchikuyotoNm LIKE CONCAT('%', @kenchikuyotoNm, '%')                        ");
                commandParams.Add("@kenchikuyotoNm", SqlDbType.NVarChar).Value = kenchikuyotoNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY                                     ");
            sqlContent.Append("KenchikuyotoMst.KenchikuyotoDaibunrui,       ");
            sqlContent.Append("KenchikuyotoMst.KenchikuyotoShobunrui,       ");
            sqlContent.Append("KenchikuyotoMst.KenchikuyotoRenban           ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
