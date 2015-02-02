using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
    
    public partial class ShokuinMstDataSet {
        partial class ShokuinMstDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.ShokuinMstDataSetTableAdapters
{
    #region ShokuinMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShokuinMstKensakuTableAdapter
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
    public partial class ShokuinMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="shokuinCdFrom"></param>
        /// <param name="shokuinCdTo"></param>
        /// <param name="shokuinNm"></param>
        /// <param name="shokuinKana"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShokuinMstDataSet.ShokuinMstKensakuDataTable GetDataBySearchCond(
            String shishoCd,
            String shokuinCdFrom,
            String shokuinCdTo,
            String shokuinNm,
            String shokuinKana)
        {
            SqlCommand command = CreateSqlCommand(shishoCd,
                                                    shokuinCdFrom,
                                                    shokuinCdTo,
                                                    shokuinNm,
                                                    shokuinKana
                                                    );

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShokuinMstDataSet.ShokuinMstKensakuDataTable dataTable = new ShokuinMstDataSet.ShokuinMstKensakuDataTable();
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
        /// <param name="shokuinCdFrom"></param>
        /// <param name="shokuinCdTo"></param>
        /// <param name="shokuinNm"></param>
        /// <param name="shokuinKana"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　新規作成
        /// 2015/01/23  DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String shishoCd,
            String shokuinCdFrom,
            String shokuinCdTo,
            String shokuinNm,
            String shokuinKana)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                               ");
            sqlContent.Append("     ShokuinMst.ShokuinShozokuShishoCd,                                              ");
            sqlContent.Append("     ShokuinMst.ShokuinCd,                                                           ");
            sqlContent.Append("     ShokuinMst.ShokuinNm,                                                           ");
            sqlContent.Append("     ShokuinMst.ShokuinKana,                                                         ");
            sqlContent.Append("     CASE                                                                            ");
            sqlContent.Append("         WHEN ISNULL(ShokuinMst.ShokuinSeinengappi, '') <> ''                        ");
            sqlContent.Append("             THEN                                                                    ");
            sqlContent.Append("                 CONCAT(SUBSTRING(ShokuinMst.ShokuinSeinengappi, 0, 5), '/',         ");
            sqlContent.Append("                         SUBSTRING(ShokuinMst.ShokuinSeinengappi, 5, 2), '/',        ");
            sqlContent.Append("                         SUBSTRING(ShokuinMst.ShokuinSeinengappi, 7, 2))             ");
            sqlContent.Append("         ELSE ''                                                                     ");
            sqlContent.Append("     END AS ShokuinSeinengappi,                                                      ");
            sqlContent.Append("     CASE                                                                            ");
            sqlContent.Append("         WHEN ISNULL(ShokuinMst.ShokuinNyushaDt, '') <> ''                           ");
            sqlContent.Append("             THEN                                                                    ");
            sqlContent.Append("                 CONCAT(SUBSTRING(ShokuinMst.ShokuinNyushaDt, 0, 5), '/',            ");
            sqlContent.Append("                         SUBSTRING(ShokuinMst.ShokuinNyushaDt, 5, 2), '/',           ");
            sqlContent.Append("                         SUBSTRING(ShokuinMst.ShokuinNyushaDt, 7, 2))                ");
            sqlContent.Append("         ELSE ''                                                                     ");
            sqlContent.Append("     END AS ShokuinNyushaDt,                                                         ");
            sqlContent.Append("     ShokuinMst.ShokuinKensainFlg,                                                   ");
            // 2015/01/23 DatNT v1.02 ADD Start
            sqlContent.Append("     ShokuinMst.ShokuinShukeiJogaiFlg,                                               ");
            // 2015/01/23 DatNT v1.02 ADD End
            sqlContent.Append("     CASE                                                                            ");
            sqlContent.Append("         WHEN ISNULL(ShokuinMst.ShokuinTaishokuDt, '') <> ''                         ");
            sqlContent.Append("             THEN                                                                    ");
            sqlContent.Append("                 CONCAT(SUBSTRING(ShokuinMst.ShokuinTaishokuDt, 0, 5), '/',          ");
            sqlContent.Append("                         SUBSTRING(ShokuinMst.ShokuinTaishokuDt, 5, 2), '/',         ");
            sqlContent.Append("                         SUBSTRING(ShokuinMst.ShokuinTaishokuDt, 7, 2))              ");
            sqlContent.Append("         ELSE ''                                                                     ");
            sqlContent.Append("     END AS ShokuinTaishokuDt,                                                       ");
            sqlContent.Append("     ShokuinMst.ShokuinTaishokuFlg,                                                  ");
            sqlContent.Append("     ShokuinMst.ShokuinPassword,                                                     ");
            sqlContent.Append("     ShokuinMst.ShokuinInjiJun,                                                      ");
            sqlContent.Append("     ShishoMst.ShishoNm                                                              ");
            
            // FROM
            sqlContent.Append("FROM                                                                                 ");
            sqlContent.Append("     ShokuinMst                                                                      ");
            sqlContent.Append("LEFT OUTER JOIN                                                                      ");
            sqlContent.Append("     ShishoMst                                                                       ");
            sqlContent.Append("         ON ShishoMst.ShishoCd = ShokuinMst.ShokuinShozokuShishoCd                   ");

            // WHERE
            sqlContent.Append("WHERE                                                                                ");
            sqlContent.Append("     1 = 1                                                                           ");
            
            if (!String.IsNullOrEmpty(shishoCd))
            {
                sqlContent.Append("AND ShokuinMst.ShokuinShozokuShishoCd = @shishoCd                                ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            if (!string.IsNullOrEmpty(shokuinCdFrom))
            {
                sqlContent.Append("AND ShokuinMst.ShokuinCd >= @shokuinCdFrom ");
                commandParams.Add("@shokuinCdFrom", SqlDbType.NVarChar).Value = shokuinCdFrom;
            }
            
            if (!string.IsNullOrEmpty(shokuinCdTo))
            {
                sqlContent.Append("AND ShokuinMst.ShokuinCd <= @shokuinCdTo ");
                commandParams.Add("@shokuinCdTo", SqlDbType.NVarChar).Value = shokuinCdTo;
            }

            if (!String.IsNullOrEmpty(shokuinNm))
            {
                sqlContent.Append("AND ShokuinMst.ShokuinNm LIKE concat('%', @shokuinNm, '%') ");
                commandParams.Add("@shokuinNm", SqlDbType.NVarChar).Value = shokuinNm;
            }

            if (!String.IsNullOrEmpty(shokuinKana))
            {
                sqlContent.Append("AND ShokuinMst.ShokuinKana LIKE concat('%', @shokuinKana, '%') ");
                commandParams.Add("@shokuinKana", SqlDbType.NVarChar).Value = shokuinKana;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     ShokuinMst.ShokuinShozokuShishoCd, ShokuinMst.ShokuinCd        ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region ShokuinMstTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 : ShokuinMstShishoCdTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShokuinMstTableAdapter
    {
        #region GetDataByShishoCd
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByShishoCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShokuinMstDataSet.ShokuinMstDataTable GetDataByShishoCd(String shishoCd)
        {
            SqlCommand command = CreateSqlCommand(shishoCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShokuinMstDataSet.ShokuinMstDataTable dataTable = new ShokuinMstDataSet.ShokuinMstDataTable();
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
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(String shishoCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT ");
            sqlContent.Append("  ShokuinCd ");
            sqlContent.Append("  , ShokuinShozokuShishoCd ");
            sqlContent.Append("  , ShokuinNm ");
            sqlContent.Append("  , ShokuinKana ");
            sqlContent.Append("  , ShokuinSeinengappi ");
            sqlContent.Append("  , ShokuinNyushaDt ");
            sqlContent.Append("  , ShokuinKensainFlg ");
            sqlContent.Append("  , ShokuinTaishokuDt ");
            sqlContent.Append("  , ShokuinTaishokuFlg ");
            sqlContent.Append("  , ShokuinPassword ");
            sqlContent.Append("  , ShokuinInjiJun ");
            sqlContent.Append("  , ShokuinShukeiJogaiFlg ");
            sqlContent.Append("  , InsertDt ");
            sqlContent.Append("  , InsertUser ");
            sqlContent.Append("  , InsertTarm ");
            sqlContent.Append("  , UpdateDt ");
            sqlContent.Append("  , UpdateUser ");
            sqlContent.Append("  , UpdateTarm ");

            // FROM
            sqlContent.Append("FROM ");
            sqlContent.Append("  ShokuinMst ");

            // WHERE
            sqlContent.Append("WHERE ");
            sqlContent.Append("  ShokuinKensainFlg = '1' ");
            sqlContent.Append("  AND ShokuinTaishokuFlg = '0' ");

            if (!String.IsNullOrEmpty(shishoCd))
            {
                sqlContent.Append("AND ShokuinShozokuShishoCd = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
