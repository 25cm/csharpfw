using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet
{

    public partial class ChikuMstDataSet
    {

        partial class ChikuMstKensakuDataTable
        {
        }

        partial class ChikuMstDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.ChikuMstDataSetTableAdapters
{

    #region ChikuMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChikuMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class ChikuMstKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chikuCdTo"></param>
        /// <param name="chikuCdFrom"></param>
        /// <param name="chikuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ChikuMstDataSet.ChikuMstKensakuDataTable GetDataBySearchCond(
            String chikuCdFrom,
            String chikuCdTo,
            String chikuNm)
        {
            SqlCommand command = CreateSqlCommand(chikuCdFrom, chikuCdTo, chikuNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ChikuMstDataSet.ChikuMstKensakuDataTable dataTable = new ChikuMstDataSet.ChikuMstKensakuDataTable();
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
        /// <param name="chikuCdFrom"></param>
        /// <param name="chikuCdTo"></param>
        /// <param name="chikuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　HuyTX　　新規作成
        /// 2015/01/23　HuyTX　　Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String chikuCdFrom,
            String chikuCdTo,
            String chikuNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append("SELECT                                                                  ");
            sqlContent.Append("      ck.ChikuCd,                                                       ");
            sqlContent.Append("      ck.ChikuNm,                                                       ");
            sqlContent.Append("      ck.ChikuRyakusho,                                                 ");
            sqlContent.Append("      ck.KankatsuHokenjoCd,                                             ");
            sqlContent.Append("      hj.HokenjoNm,                                                     ");
            sqlContent.Append("      ck.HoteiTantoShishoCd,                                            ");
            sqlContent.Append("      ss.ShishoNm  AS HoteiShishoName,                                  ");
            sqlContent.Append("      ck.SuishitsuTantoShishoCd,                                        ");
            sqlContent.Append("      st.ShishoNm AS SuishitsuShishoName,                               ");
            sqlContent.Append("      ck.GaikanChikuwariCd,                                             ");
            sqlContent.Append("      ck.GaikanChikuwari2Cd,                                            ");
            sqlContent.Append("      ck.GappeigoChikuCd,                                               ");
            //Ver1.02 Add
            sqlContent.Append("      ck.ChikuTantoKa,                                                  ");
            sqlContent.Append("      ck.ChikuTantoYubinNo,                                             ");
            sqlContent.Append("      ck.ChikuTantoAdr,                                                 ");
            sqlContent.Append("      ck.ChikuTantoTelNo,                                               ");
            sqlContent.Append("      ck.ChikuTantoFax,                                                 ");
            sqlContent.Append("      ck.ChikuHyojunChi7Jo,                                             ");
            sqlContent.Append("      ck.ChikuHyojunChi11JoTandoku,                                     ");
            sqlContent.Append("      ck.ChikuHyojunChi11JoGappei,                                      ");
            sqlContent.Append("      ck.DelFlg,                                                        ");
            //End
            sqlContent.Append("      ck.InsertDt,                                                      ");
            sqlContent.Append("      ck.InsertUser,                                                    ");
            sqlContent.Append("      ck.InsertTarm,                                                    ");
            sqlContent.Append("      ck.UpdateDt,                                                      ");
            sqlContent.Append("      ck.UpdateUser,                                                    ");
            sqlContent.Append("      ck.UpdateTarm                                                     ");
            //FROM
            sqlContent.Append("FROM                                                                    ");
            sqlContent.Append("      ChikuMst ck                                                       ");
            //JOIN
            sqlContent.Append("LEFT JOIN                                                              ");
            sqlContent.Append("              HokenjoMst hj                                             ");
            sqlContent.Append("        ON    ck.KankatsuHokenjoCd = hj.HokenjoCd                       ");
            sqlContent.Append("LEFT JOIN                                                              ");
            sqlContent.Append("              ShishoMst ss                                              ");
            sqlContent.Append("        ON    ck.HoteiTantoShishoCd = ss.ShishoCd                       ");
            sqlContent.Append("LEFT JOIN                                                              ");
            sqlContent.Append("              ShishoMst st                                           ");
            sqlContent.Append("        ON    ck.SuishitsuTantoShishoCd = st.ShishoCd                ");
            //WHERE
            sqlContent.Append("WHERE 1 = 1                                                             ");

            //sqlContent.Append("AND ck.ChikuCd " + DataAccessUtility.SetBetweenCommand(chikuCdFrom, chikuCdTo, 5));

            if (!string.IsNullOrEmpty(chikuCdFrom) && string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append("AND ck.ChikuCd >= @chikuCdFrom ");
                commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;
            }
            else if (string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append("AND ck.ChikuCd <= @chikuCdTo ");
                commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            }
            else if (!string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append("AND ck.ChikuCd >= @chikuCdFrom ");
                commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;

                sqlContent.Append("AND ck.ChikuCd <= @chikuCdTo ");
                commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            }

            if (!String.IsNullOrEmpty(chikuNm))
            {
                sqlContent.Append(" AND ck.ChikuNm LIKE concat('%', @chikuNm, '%')                         ");
                commandParams.Add("@chikuNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(chikuNm);
            }

            // ORDER BY
            sqlContent.Append("ORDER BY                                                                ");
            sqlContent.Append("         ChikuCd                                                        ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    #endregion

    #region ChikuMstSearchCommonTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChikuMstSearchCommonTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/08　HuyTX　　 Ver1.01
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class ChikuMstSearchCommonTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chikuCdTo"></param>
        /// <param name="chikuCdFrom"></param>
        /// <param name="chikuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/08　HuyTX　　 Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ChikuMstDataSet.ChikuMstSearchCommonDataTable GetDataBySearchCond(
            string chikuCdFrom,
            string chikuCdTo,
            string chikuNm)
        {
            SqlCommand command = CreateSqlCommand(chikuCdFrom, chikuCdTo, chikuNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ChikuMstDataSet.ChikuMstSearchCommonDataTable dataTable = new ChikuMstDataSet.ChikuMstSearchCommonDataTable();
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
        /// <param name="chikuCdFrom"></param>
        /// <param name="chikuCdTo"></param>
        /// <param name="chikuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/08　HuyTX　　 Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string chikuCdFrom,
            string chikuCdTo,
            string chikuNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append("SELECT                                                                  ");
            sqlContent.Append("      ck.ChikuCd,                                                       ");
            sqlContent.Append("      ck.ChikuNm,                                                       ");
            sqlContent.Append("      ck.ChikuRyakusho,                                                 ");
            sqlContent.Append("      ck.KankatsuHokenjoCd,                                             ");
            sqlContent.Append("      hj.HokenjoNm,                                                     ");
            sqlContent.Append("      ck.HoteiTantoShishoCd,                                            ");
            sqlContent.Append("      ss.ShishoNm  AS HoteiShishoName,                                  ");
            sqlContent.Append("      ck.SuishitsuTantoShishoCd,                                        ");
            sqlContent.Append("      st.ShishoNm AS SuishitsuShishoName,                               ");
            sqlContent.Append("      ck.GaikanChikuwariCd,                                             ");
            sqlContent.Append("      ck.GaikanChikuwari2Cd,                                            ");
            sqlContent.Append("      ck.GappeigoChikuCd,                                               ");
            sqlContent.Append("      ck.ChikuTantoKa,                                                  ");
            sqlContent.Append("      ck.ChikuTantoYubinNo,                                             ");
            sqlContent.Append("      ck.ChikuTantoAdr,                                                 ");
            sqlContent.Append("      ck.ChikuTantoTelNo,                                               ");
            sqlContent.Append("      ck.ChikuTantoFax                                                  ");

            //FROM
            sqlContent.Append("FROM                                                                    ");
            sqlContent.Append("      ChikuMst ck                                                       ");

            //JOIN
            sqlContent.Append("LEFT JOIN                                                               ");
            sqlContent.Append("              HokenjoMst hj                                             ");
            sqlContent.Append("        ON    ck.KankatsuHokenjoCd = hj.HokenjoCd                       ");
            sqlContent.Append("LEFT JOIN                                                               ");
            sqlContent.Append("              ShishoMst ss                                              ");
            sqlContent.Append("        ON    ck.HoteiTantoShishoCd = ss.ShishoCd                       ");
            sqlContent.Append("LEFT JOIN                                                               ");
            sqlContent.Append("              ShishoMst st                                              ");
            sqlContent.Append("        ON    ck.SuishitsuTantoShishoCd = st.ShishoCd                   ");

            //WHERE
            sqlContent.Append("WHERE ck.DelFlg <> '1'                                                  ");

            if (!string.IsNullOrEmpty(chikuCdFrom) && string.IsNullOrEmpty(chikuCdTo))
            {
                //sqlContent.Append("AND ck.ChikuCd " + DataAccessUtility.SetBetweenCommand(chikuCdFrom, chikuCdTo, 5));

                sqlContent.Append("AND ck.ChikuCd >= @chikuCdFrom ");
                commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;
            }
            else if (string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append("AND ck.ChikuCd <= @chikuCdTo ");
                commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            }
            else if (!string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append("AND ck.ChikuCd >= @chikuCdFrom ");
                commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;

                sqlContent.Append("AND ck.ChikuCd <= @chikuCdTo ");
                commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            }

            if (!String.IsNullOrEmpty(chikuNm))
            {
                sqlContent.Append(" AND ck.ChikuNm LIKE concat('%', @chikuNm, '%')                     ");
                commandParams.Add("@chikuNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(chikuNm);
            }

            // ORDER BY
            sqlContent.Append("ORDER BY                                                                ");
            sqlContent.Append("         ck.ChikuCd                                                     ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    #endregion

}