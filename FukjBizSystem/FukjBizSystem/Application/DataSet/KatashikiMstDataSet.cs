using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {    
    
    public partial class KatashikiMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.KatashikiMstDataSetTableAdapters
{

    #region KatashikiMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KatashikiMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KatashikiMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="katashikiMakerCdFrom"></param>
        /// <param name="katashikiMakerCdTo"></param>
        /// <param name="gyoshaNm"></param>
        /// <param name="katashikiCdFrom"></param>
        /// <param name="katashikiCdTo"></param>
        /// <param name="katashikiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KatashikiMstDataSet.KatashikiMstKensakuDataTable GetDataBySearchCond(
            String katashikiMakerCdFrom,
            String katashikiMakerCdTo,
            String gyoshaNm,
            String katashikiCdFrom,
            String katashikiCdTo,
            String katashikiNm)
        {
            SqlCommand command = CreateSqlCommand(katashikiMakerCdFrom,
                                                    katashikiMakerCdTo,
                                                    gyoshaNm,
                                                    katashikiCdFrom,
                                                    katashikiCdTo,
                                                    katashikiNm
                                                    );

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KatashikiMstDataSet.KatashikiMstKensakuDataTable dataTable = new KatashikiMstDataSet.KatashikiMstKensakuDataTable();
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
        /// <param name="katashikiMakerCdFrom"></param>
        /// <param name="katashikiMakerCdTo"></param>
        /// <param name="gyoshaNm"></param>
        /// <param name="katashikiCdFrom"></param>
        /// <param name="katashikiCdTo"></param>
        /// <param name="katashikiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　DatNT　　新規作成
        /// 2014/11/04  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String katashikiMakerCdFrom,
            String katashikiMakerCdTo,
            String gyoshaNm,
            String katashikiCdFrom,
            String katashikiCdTo,
            String katashikiNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                               ");
            sqlContent.Append("     KatashikiMst.KatashikiMakerCd,                                                  ");
            sqlContent.Append("     KatashikiMst.KatashikiCd,                                                       ");
            sqlContent.Append("     KatashikiMst.KatashikiNm,                                                       ");
            sqlContent.Append("     KatashikiMst.ZenjorenTourokuNo,                                                 ");
            //sqlContent.Append("     KatashikiMst.ZenjorenTourokuBi,                                                 ");
            sqlContent.Append("     CASE WHEN ISDATE(KatashikiMst.ZenjorenTourokuBi) = 0                                                 ");
            sqlContent.Append("             THEN ''                                                                 ");
            sqlContent.Append("             ELSE CONVERT(VARCHAR (10), CONVERT(DATETIME, KatashikiMst.ZenjorenTourokuBi), 111) ");
            sqlContent.Append("         END AS ZenjorenTourokuBi,                                                   ");
            sqlContent.Append("     KatashikiMst.TokuCho,                                                           ");
            sqlContent.Append("     KatashikiMst.SeinohyokakataKbn,                                                 ");
            sqlContent.Append("     KatashikiMst.KonpakutokataKbn,                                                  ");
            // 2014/11/04 DatNT v1.01 MOD Start
            //sqlContent.Append("     KatashikiMst.KouzoreijikataKbn,                                                 ");
            sqlContent.Append("     KatashikiMst.BODKodoshorikataKbn,                                               ");
            sqlContent.Append("     KatashikiMst.ChissojokyokataKbn,                                                ");
            sqlContent.Append("     KatashikiMst.RinjokyokataKbn,                                                   ");
            //sqlContent.Append("     KatashikiMst.TenkenKaisuTsuki,                                                  ");
            //sqlContent.Append("     KatashikiMst.TenkenKaisuShu,                                                    ");
            sqlContent.Append("     KatashikiMst.TenkenKaisuKbn,                                                    ");
            sqlContent.Append("     KatashikiMst.SeisoKaisuKbn,                                                     ");
            // 2014/11/04 DatNT v1.01 MOD End
            sqlContent.Append("     KatashikiMst.KatashikiShorihoushikiCd,                                          ");
            sqlContent.Append("     KatashikiMst.KatashikiShorihoushikiKbn,                                         ");

            sqlContent.Append("     CASE KatashikiMst.KatashikiShorihoushikiKbn                                     ");
            sqlContent.Append("         WHEN '1' THEN '単独'                                                        ");
            sqlContent.Append("         WHEN '2' THEN '合併'                                                        ");
            // 2014/11/04 DatNT v1.01 DEL Start
            sqlContent.Append("         WHEN '3' THEN '小合'                                                        ");
            // 2014/11/04 DatNT v1.01 DEL End
            sqlContent.Append("         ELSE ''                                                                     ");
            sqlContent.Append("     END AS KatashikiShorihoushikiKbnCol ,                                           ");

            sqlContent.Append("     GyoshaMst.GyoshaNm,                                                             ");
            sqlContent.Append("     ShoriHoshikiMst.ShoriHoshikiNm                                                  ");

            // FROM
            sqlContent.Append("FROM                                                                                 ");
            sqlContent.Append("     KatashikiMst                                                                    ");
            sqlContent.Append("LEFT OUTER JOIN                                                                      ");
            sqlContent.Append("     GyoshaMst                                                                       ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KatashikiMst.KatashikiMakerCd                       ");
            sqlContent.Append("LEFT OUTER JOIN                                                                      ");
            sqlContent.Append("     ShoriHoshikiMst                                                                 ");
            sqlContent.Append("         ON ShoriHoshikiMst.ShoriHoshikiCd = KatashikiMst.KatashikiShorihoushikiCd   ");
            sqlContent.Append("         AND ShoriHoshikiMst.ShoriHoshikiKbn = KatashikiMst.KatashikiShorihoushikiKbn ");

            // WHERE
            sqlContent.Append("WHERE                                                                                ");
            sqlContent.Append("     1 = 1                                                                           ");

            //sqlContent.Append("AND KatashikiMst.KatashikiMakerCd " + DataAccessUtility.SetBetweenCommand(katashikiMakerCdFrom, katashikiMakerCdTo, 4));
            if (!string.IsNullOrEmpty(katashikiMakerCdFrom) && string.IsNullOrEmpty(katashikiMakerCdTo))
            {
                sqlContent.Append("AND KatashikiMst.KatashikiMakerCd >= @katashikiMakerCdFrom ");
                commandParams.Add("@katashikiMakerCdFrom", SqlDbType.NVarChar).Value = katashikiMakerCdFrom;
            }
            else if (string.IsNullOrEmpty(katashikiMakerCdFrom) && !string.IsNullOrEmpty(katashikiMakerCdTo))
            {
                sqlContent.Append("AND KatashikiMst.KatashikiMakerCd <= @katashikiMakerCdTo ");
                commandParams.Add("@katashikiMakerCdTo", SqlDbType.NVarChar).Value = katashikiMakerCdTo;
            }
            else if (!string.IsNullOrEmpty(katashikiMakerCdFrom) && !string.IsNullOrEmpty(katashikiMakerCdTo))
            {
                sqlContent.Append("AND KatashikiMst.KatashikiMakerCd >= @katashikiMakerCdFrom ");
                commandParams.Add("@katashikiMakerCdFrom", SqlDbType.NVarChar).Value = katashikiMakerCdFrom;

                sqlContent.Append("AND KatashikiMst.KatashikiMakerCd <= @katashikiMakerCdTo ");
                commandParams.Add("@katashikiMakerCdTo", SqlDbType.NVarChar).Value = katashikiMakerCdTo;
            }

            //sqlContent.Append("AND KatashikiMst.KatashikiCd " + DataAccessUtility.SetBetweenCommand(katashikiCdFrom, katashikiCdTo, 4));
            if (!string.IsNullOrEmpty(katashikiCdFrom) && string.IsNullOrEmpty(katashikiCdTo))
            {
                sqlContent.Append("AND KatashikiMst.KatashikiCd >= @katashikiCdFrom ");
                commandParams.Add("@katashikiCdFrom", SqlDbType.NVarChar).Value = katashikiCdFrom;
            }
            else if (string.IsNullOrEmpty(katashikiCdFrom) && !string.IsNullOrEmpty(katashikiCdTo))
            {
                sqlContent.Append("AND KatashikiMst.KatashikiCd <= @katashikiCdTo ");
                commandParams.Add("@katashikiCdTo", SqlDbType.NVarChar).Value = katashikiCdTo;
            }
            else if (!string.IsNullOrEmpty(katashikiCdFrom) && !string.IsNullOrEmpty(katashikiCdTo))
            {
                sqlContent.Append("AND KatashikiMst.KatashikiCd >= @katashikiCdFrom ");
                commandParams.Add("@katashikiCdFrom", SqlDbType.NVarChar).Value = katashikiCdFrom;

                sqlContent.Append("AND KatashikiMst.KatashikiCd <= @katashikiCdTo ");
                commandParams.Add("@katashikiCdTo", SqlDbType.NVarChar).Value = katashikiCdTo;
            }

            if (!String.IsNullOrEmpty(gyoshaNm))
            {
                sqlContent.Append("AND GyoshaMst.GyoshaNm LIKE concat('%', @gyoshaNm, '%') ");
                commandParams.Add("@gyoshaNm", SqlDbType.NVarChar).Value = gyoshaNm;
            }

            if (!String.IsNullOrEmpty(katashikiNm))
            {
                sqlContent.Append("AND KatashikiMst.KatashikiNm LIKE concat('%', @katashikiNm, '%') ");
                commandParams.Add("@katashikiNm", SqlDbType.NVarChar).Value = katashikiNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     KatashikiMst.KatashikiMakerCd                                       ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
