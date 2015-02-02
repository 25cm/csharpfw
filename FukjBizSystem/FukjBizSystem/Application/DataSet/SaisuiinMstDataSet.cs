using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet
{

    #region SaisuiinMstSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SaisuiinMstSearchCond
    {
        /// <summary>
        /// 採水員コードFROM
        /// </summary>
        public string SaisuiinCdFrom { get; set; }

        /// <summary>
        /// 採水員コードTO
        /// </summary>
        public string SaisuiinCdTo { get; set; }

        /// <summary>
        /// 採水員名
        /// </summary>
        public string SaisuiinNm { get; set; }

        /// <summary>
        /// 所属業者コードFROM
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 所属業者コードTO
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 業者名
        /// </summary>
        public string GyoshaNm { get; set; }

        /// <summary>
        /// 採水員有効期限FROM
        /// </summary>
        public string SaisuiinYukokigenDtFrom { get; set; }

        /// <summary>
        /// 採水員有効期限TO
        /// </summary>
        public string SaisuiinYukokigenDtTo { get; set; }

        /// <summary>
        /// 所属業者コードFROM
        /// </summary>
        public string SyozokuGyosyaCdFrom { get; set; }

        /// <summary>
        /// 所属業者コードTO
        /// </summary>
        public string SyozokuGyosyaCdTo { get; set; }

        /// <summary>
        /// 受講日FROM
        /// </summary>
        public string JukoDtFrom { get; set; }

        /// <summary>
        /// 受講日TO
        /// </summary>
        public string JukoDtTo { get; set; }
    }
    #endregion

    public partial class SaisuiinMstDataSet {
        
    }
}

namespace FukjBizSystem.Application.DataSet.SaisuiinMstDataSetTableAdapters
{
    #region SaisuiinMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiinMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiinMstKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SaisuiinMstDataSet.SaisuiinMstKensakuDataTable GetDataBySearchCond(SaisuiinMstSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SaisuiinMstDataSet.SaisuiinMstKensakuDataTable dataTable = new SaisuiinMstDataSet.SaisuiinMstKensakuDataTable();
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
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(SaisuiinMstSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            
            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append(" select                                                                                                                                                              ");
	        sqlContent.Append("     sm.SaisuiinCd,                                                                                                                                                  ");
            sqlContent.Append("     sm.SaisuiinNm,                                                                                                                                                  ");
            sqlContent.Append("     gm.GyoshaCd,                                                                                                                                                    ");
            sqlContent.Append("     gm.GyoshaNm,                                                                                                                                                    ");
            sqlContent.Append("     sm.SaisuiinKana,                                                                                                                                                ");
            sqlContent.Append("     sm.SyozokuGyosyaCd,                                                                                                                                             ");
            sqlContent.Append("     sm.SaisuiinShiteiNo,                                                                                                                                            ");
            sqlContent.Append("     (CASE WHEN ISDATE(sm.JukoDt)=0 then '' ELSE CONVERT(CHAR(10), CONVERT(DATETIME,sm.JukoDt), 111) END) AS JukoDt,                                                 ");
            sqlContent.Append("     (CASE WHEN ISDATE(sm.SaisuiinSyutokuDt)=0 then '' ELSE CONVERT(CHAR(10), CONVERT(DATETIME,sm.SaisuiinSyutokuDt), 111) END) AS SaisuiinSyutokuDt,                ");
            sqlContent.Append("     (CASE WHEN ISDATE(sm.ZenkaiJukoDt)=0 then '' ELSE CONVERT(CHAR(10), CONVERT(DATETIME,sm.ZenkaiJukoDt), 111) END) AS ZenkaiJukoDt,                               ");
            sqlContent.Append("     (CASE WHEN ISDATE(sm.SaisuiinYukokigenDt)=0 then '' ELSE CONVERT(CHAR(10), CONVERT(DATETIME,sm.SaisuiinYukokigenDt), 111) END) AS SaisuiinYukokigenDt,          ");
            sqlContent.Append("     sm.SaisuiinZipCd,                                                                                                                                               ");
            sqlContent.Append("     sm.SaisuiinAdr,                                                                                                                                                 ");
            sqlContent.Append("     sm.SaisuiinTelNo,                                                                                                                                               ");
            sqlContent.Append("     (CASE WHEN ISDATE(sm.SaisuiinSeinegappi)=0 then '' ELSE CONVERT(CHAR(10), CONVERT(DATETIME,sm.SaisuiinSeinegappi), 111) END) AS SaisuiinSeinegappi,             ");
            sqlContent.Append("     sm.KanrishiNo,                                                                                                                                                  ");
            sqlContent.Append("     (CASE WHEN ISDATE(sm.KanrishiSyutokuDt)=0 then '' ELSE CONVERT(CHAR(10), CONVERT(DATETIME,sm.KanrishiSyutokuDt), 111) END) AS KanrishiSyutokuDt,                ");
            sqlContent.Append("     (CASE WHEN ISDATE(sm.SaisuiinTorikeshiDt)=0 then '' ELSE CONVERT(CHAR(10), CONVERT(DATETIME,sm.SaisuiinTorikeshiDt), 111) END) AS SaisuiinTorikeshiDt           ");
            // FROM
            sqlContent.Append(" from SaisuiinMst sm                                                                                                                                                 ");
            sqlContent.Append(" left outer join GyoshaMst gm                                                                                                                                        ");
            sqlContent.Append("     on sm.SyozokuGyosyaCd = gm.GyoshaCd                                                                                                                             ");
            // WHERE
            sqlContent.Append(" where 1 = 1                                                                                                                                                         ");

            // 採水員コード FROM ~ TO
            if (!string.IsNullOrEmpty(searchCond.SaisuiinCdFrom) && string.IsNullOrEmpty(searchCond.SaisuiinCdTo))
            {
                sqlContent.Append("AND sm.SaisuiinCd >= @SaisuiinCdFrom ");
                commandParams.Add("@SaisuiinCdFrom", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdFrom;
            }
            else if (string.IsNullOrEmpty(searchCond.SaisuiinCdFrom) && !string.IsNullOrEmpty(searchCond.SaisuiinCdTo))
            {
                sqlContent.Append("AND sm.SaisuiinCd <= @SaisuiinCdTo ");
                commandParams.Add("@SaisuiinCdTo", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdTo;
            }
            // 20141120 habu Fixed range search
            else if (!string.IsNullOrEmpty(searchCond.SaisuiinCdFrom) && !string.IsNullOrEmpty(searchCond.SaisuiinCdTo))
            {
                sqlContent.Append("AND sm.SaisuiinCd >= @SaisuiinCdFrom ");
                commandParams.Add("@SaisuiinCdFrom", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdFrom;

                sqlContent.Append("AND sm.SaisuiinCd <= @SaisuiinCdTo ");
                commandParams.Add("@SaisuiinCdTo", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdTo;
            }
            //sqlContent.Append("AND sm.SaisuiinCd " + DataAccessUtility.SetBetweenCommand(searchCond.SaisuiinCdFrom, searchCond.SaisuiinCdTo, 5));

            if (!string.IsNullOrEmpty(searchCond.SaisuiinNm))
            {
                // 採水員名
                sqlContent.Append(" and sm.SaisuiinNm like concat('%', @saisuiinNm, '%')");
                commandParams.Add("@saisuiinNm", SqlDbType.VarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.SaisuiinNm);
            }

            // 所属業者コードFROM ~ TO
            if (!string.IsNullOrEmpty(searchCond.GyoshaCdFrom))
            {
                sqlContent.Append("AND sm.SyozokuGyosyaCd >= @GyoshaCdFrom ");
                commandParams.Add("@GyoshaCdFrom", SqlDbType.NVarChar).Value = searchCond.GyoshaCdFrom;
            }
            
            if (!string.IsNullOrEmpty(searchCond.GyoshaCdTo))
            {
                sqlContent.Append("AND sm.SyozokuGyosyaCd <= @GyoshaCdTo ");
                commandParams.Add("@GyoshaCdTo", SqlDbType.NVarChar).Value = searchCond.GyoshaCdTo;
            }

            //sqlContent.Append("AND gm.GyoshaCd " + DataAccessUtility.SetBetweenCommand(searchCond.GyoshaCdFrom, searchCond.GyoshaCdTo, 4));

            if (!string.IsNullOrEmpty(searchCond.GyoshaNm))
            {
                // 業者名
                sqlContent.Append(" and gm.GyoshaNm like concat('%', @gyoshaNm, '%')");
                commandParams.Add("@gyoshaNm", SqlDbType.VarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.GyoshaNm);
            }

            // ORDER BY
            sqlContent.Append(" order by sm.SaisuiinCd");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region SaisuiinInfoListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiinInfoListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class SaisuiinInfoListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saisuiinCdFrom"></param>
        /// <param name="saisuiinCdTo"></param>
        /// <param name="syozokuGyosyaCdFrom"></param>
        /// <param name="syozokuGyosyaCdTo"></param>
        /// <param name="saisuiinNm"></param>
        /// <param name="addConditionsFlg"></param>
        /// <param name="jukoDtFrom"></param>
        /// <param name="jukoDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SaisuiinMstDataSet.SaisuiinInfoListDataTable GetDataBySearchCond(
            string saisuiinCdFrom,
            string saisuiinCdTo,
            string syozokuGyosyaCdFrom,
            string syozokuGyosyaCdTo,
            string saisuiinNm,
            bool addConditionsFlg,
            string jukoDtFrom,
            string jukoDtTo)
        {
            SqlCommand command = CreateSqlCommand(saisuiinCdFrom, 
                                                    saisuiinCdTo, 
                                                    syozokuGyosyaCdFrom, 
                                                    syozokuGyosyaCdTo,
                                                    saisuiinNm,
                                                    addConditionsFlg,
                                                    jukoDtFrom,
                                                    jukoDtTo);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SaisuiinMstDataSet.SaisuiinInfoListDataTable dataTable = new SaisuiinMstDataSet.SaisuiinInfoListDataTable();
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
        /// <param name="saisuiinCdFrom"></param>
        /// <param name="saisuiinCdTo"></param>
        /// <param name="syozokuGyosyaCdFrom"></param>
        /// <param name="syozokuGyosyaCdTo"></param>
        /// <param name="saisuiinNm"></param>
        /// <param name="addConditionsFlg"></param>
        /// <param name="jukoDtFrom"></param>
        /// <param name="jukoDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string saisuiinCdFrom,
            string saisuiinCdTo,
            string syozokuGyosyaCdFrom,
            string syozokuGyosyaCdTo,
            string saisuiinNm,
            bool addConditionsFlg,
            string jukoDtFrom,
            string jukoDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                           ");
            sqlContent.Append("     SaisuiinMst.SaisuiinCd,                                                                     ");
            sqlContent.Append("     SaisuiinMst.SaisuiinNm,                                                                     ");
            sqlContent.Append("     SaisuiinMst.SyozokuGyosyaCd,                                                                ");
            sqlContent.Append("     SaisuiinMst.JukoDt,                                                                         ");      
            sqlContent.Append("     CASE                                                                                        ");
            sqlContent.Append("         WHEN ISNULL(SaisuiinMst.JukoDt, '') = '' THEN ''                                        ");
            sqlContent.Append("         ELSE CONCAT(                                                                            ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.JukoDt,0,5), '/',                                             ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.JukoDt,5,2), '/',                                             ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.JukoDt,7,2)) END AS JukoDtCol,                                ");
            sqlContent.Append("     SaisuiinMst.SaisuiinSyutokuDt,                                                              ");
            sqlContent.Append("     CASE                                                                                        ");
            sqlContent.Append("         WHEN ISNULL(SaisuiinMst.SaisuiinSyutokuDt, '') = '' THEN ''                             ");
            sqlContent.Append("         ELSE CONCAT(                                                                            ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinSyutokuDt,0,5), '/',                                  ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinSyutokuDt,5,2), '/',                                  ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinSyutokuDt,7,2)) END AS SaisuiinSyutokuDtCol,          ");
            sqlContent.Append("     SaisuiinMst.SaisuiinYukokigenDt,                                                            ");
            sqlContent.Append("     CASE                                                                                        ");
            sqlContent.Append("         WHEN ISNULL(SaisuiinMst.SaisuiinYukokigenDt, '') = '' THEN ''                           ");
            sqlContent.Append("         ELSE CONCAT(                                                                            ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinYukokigenDt,0,5), '/',                                ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinYukokigenDt,5,2), '/',                                ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinYukokigenDt,7,2)) END AS SaisuiinYukokigenDtCol,      ");
            sqlContent.Append("     GyoshaMst.GyoshaNm,                                                                         ");
            sqlContent.Append("     SaisuiinMst.UpdateDt                                                                        ");

            // FROM
            sqlContent.Append("FROM                                                                                             ");
            sqlContent.Append("     SaisuiinMst                                                                                 ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                  ");
            sqlContent.Append("     GyoshaMst                                                                                   ");
            sqlContent.Append("ON   GyoshaMst.GyoshaCd = SaisuiinMst.SyozokuGyosyaCd                                            ");

            // WHERE
            sqlContent.Append("WHERE                                                                                            ");
            sqlContent.Append("     1 = 1                                                                                       ");

            // 採水員コード FROM ~ TO
            //sqlContent.Append("AND SaisuiinMst.SaisuiinCd " + DataAccessUtility.SetBetweenCommand(saisuiinCdFrom, saisuiinCdTo, 5));
            if (!string.IsNullOrEmpty(saisuiinCdFrom) && string.IsNullOrEmpty(saisuiinCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinCd >= @saisuiinCdFrom ");
                commandParams.Add("@saisuiinCdFrom", SqlDbType.NVarChar).Value = saisuiinCdFrom;
            }
            else if (string.IsNullOrEmpty(saisuiinCdFrom) && !string.IsNullOrEmpty(saisuiinCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinCd <= @saisuiinCdTo ");
                commandParams.Add("@saisuiinCdTo", SqlDbType.NVarChar).Value = saisuiinCdTo;
            }
            else if (!string.IsNullOrEmpty(saisuiinCdFrom) && !string.IsNullOrEmpty(saisuiinCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinCd >= @saisuiinCdFrom ");
                commandParams.Add("@saisuiinCdFrom", SqlDbType.NVarChar).Value = saisuiinCdFrom;

                sqlContent.Append("AND SaisuiinMst.SaisuiinCd <= @saisuiinCdTo ");
                commandParams.Add("@saisuiinCdTo", SqlDbType.NVarChar).Value = saisuiinCdTo;
            }

            // 所属業者コード FROM ~ TO
            //sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd " + DataAccessUtility.SetBetweenCommand(syozokuGyosyaCdFrom, syozokuGyosyaCdTo, 4));
            if (!string.IsNullOrEmpty(syozokuGyosyaCdFrom) && string.IsNullOrEmpty(syozokuGyosyaCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd >= @syozokuGyosyaCdFrom ");
                commandParams.Add("@syozokuGyosyaCdFrom", SqlDbType.NVarChar).Value = syozokuGyosyaCdFrom;
            }
            else if (string.IsNullOrEmpty(syozokuGyosyaCdFrom) && !string.IsNullOrEmpty(syozokuGyosyaCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd <= @syozokuGyosyaCdTo ");
                commandParams.Add("@syozokuGyosyaCdTo", SqlDbType.NVarChar).Value = syozokuGyosyaCdTo;
            }
            else if (!string.IsNullOrEmpty(syozokuGyosyaCdFrom) && !string.IsNullOrEmpty(syozokuGyosyaCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd >= @syozokuGyosyaCdFrom ");
                commandParams.Add("@syozokuGyosyaCdFrom", SqlDbType.NVarChar).Value = syozokuGyosyaCdFrom;

                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd <= @syozokuGyosyaCdTo ");
                commandParams.Add("@syozokuGyosyaCdTo", SqlDbType.NVarChar).Value = syozokuGyosyaCdTo;
            }

            // 採水員名
            if (!string.IsNullOrEmpty(saisuiinNm))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinNm LIKE CONCAT('%', @saisuiinNm, '%')");
                commandParams.Add("@saisuiinNm", SqlDbType.NVarChar).Value = saisuiinNm;
            }

            if (addConditionsFlg)
            {
                //sqlContent.Append("AND SaisuiinMst.JukoDt " + DataAccessUtility.SetBetweenCommand(jukoDtFrom, jukoDtTo, 8));

                sqlContent.Append("AND SaisuiinMst.JukoDt >= @jukoDtFrom ");
                commandParams.Add("@jukoDtFrom", SqlDbType.NVarChar).Value = jukoDtFrom;

                sqlContent.Append("AND SaisuiinMst.JukoDt <= @jukoDtTo ");
                commandParams.Add("@jukoDtTo", SqlDbType.NVarChar).Value = jukoDtTo;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     SaisuiinMst.SaisuiinCd                                       ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region SaisuiinShomeishoHakkoKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiinShomeishoHakkoKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiinShomeishoHakkoKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable GetDataBySearchCond(SaisuiinMstSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable dataTable = new SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable();
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
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(SaisuiinMstSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append(" select                                                                                                                                                                  ");
            sqlContent.Append("     sm.SaisuiinCd,                                                                                                                                                      ");
            sqlContent.Append("     sm.SaisuiinShiteiNo,                                                                                                                                                ");
            sqlContent.Append("     gm.GyoshaNm,                                                                                                                                                        ");
            sqlContent.Append("     sm.SaisuiinNm,                                                                                                                                                      ");
            sqlContent.Append("     sm.SaisuiinAdr,                                                                                                                                                     ");
            sqlContent.Append("     sm.UpdateDt,                                                                                                                                                        ");
            sqlContent.Append("     (case when isdate(sm.SaisuiinSeinegappi)=0 then '' else convert(char(10), convert(datetime,sm.SaisuiinSeinegappi), 111) end) as SaisuiinSeinegappi,                 ");
            sqlContent.Append("     (case when isdate(sm.SaisuiinSyutokuDt)=0 then '' else convert(char(10), convert(datetime,sm.SaisuiinSyutokuDt), 111) end) as SaisuiinSyutokuDt,                    ");
            sqlContent.Append("     (case when isdate(sm.JukoDt)=0 then '' else convert(char(10), convert(datetime,sm.JukoDt), 111) end) as JukoDt,                                                     ");
            sqlContent.Append("     (case when isdate(sm.SaisuiinYukokigenDt)=0 then '' else convert(char(10), convert(datetime,sm.SaisuiinYukokigenDt), 111) end) as SaisuiinYukokigenDt               ");
            sqlContent.Append(" from SaisuiinMst sm                                                                                                                                                     ");
            sqlContent.Append(" left outer join GyoshaMst gm                                                                                                                                            ");
            sqlContent.Append("     on sm.SyozokuGyosyaCd = gm.GyoshaCd                                                                                                                                 ");

            // WHERE
            sqlContent.Append(" where 1 = 1                                                                                                                                                             ");

            if (!string.IsNullOrEmpty(searchCond.SaisuiinYukokigenDtFrom) && !string.IsNullOrEmpty(searchCond.SaisuiinYukokigenDtTo))
            {
                // 採水員有効期限FROM ~ TO
                sqlContent.Append(" and sm.SaisuiinYukokigenDt >= @saisuiinYukokigenDtFrom and sm.SaisuiinYukokigenDt <= @saisuiinYukokigenDtTo                                                         ");
                commandParams.Add("@saisuiinYukokigenDtFrom", SqlDbType.NVarChar).Value = searchCond.SaisuiinYukokigenDtFrom;
                commandParams.Add("@saisuiinYukokigenDtTo", SqlDbType.NVarChar).Value = searchCond.SaisuiinYukokigenDtTo;
            }

            // 採水員コードFROM ~ TO
            //sqlContent.Append(" and sm.SaisuiinCd " + DataAccessUtility.SetBetweenCommand(searchCond.SaisuiinCdFrom, searchCond.SaisuiinCdTo, 5));
            if (!string.IsNullOrEmpty(searchCond.SaisuiinCdFrom) && string.IsNullOrEmpty(searchCond.SaisuiinCdTo))
            {
                sqlContent.Append(" and sm.SaisuiinCd >= @SaisuiinCdFrom ");
                commandParams.Add("@SaisuiinCdFrom", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdFrom;
            }
            else if (string.IsNullOrEmpty(searchCond.SaisuiinCdFrom) && !string.IsNullOrEmpty(searchCond.SaisuiinCdTo))
            {
                sqlContent.Append(" and sm.SaisuiinCd <= @SaisuiinCdTo ");
                commandParams.Add("@SaisuiinCdTo", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdTo;
            }
            else if (!string.IsNullOrEmpty(searchCond.SaisuiinCdFrom) && !string.IsNullOrEmpty(searchCond.SaisuiinCdTo))
            {
                sqlContent.Append(" and sm.SaisuiinCd >= @SaisuiinCdFrom ");
                commandParams.Add("@SaisuiinCdFrom", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdFrom;

                sqlContent.Append(" and sm.SaisuiinCd <= @SaisuiinCdTo ");
                commandParams.Add("@SaisuiinCdTo", SqlDbType.NVarChar).Value = searchCond.SaisuiinCdTo;
            }

            // 所属業者コードFROM ~ TO
            //sqlContent.Append(" and sm.SyozokuGyosyaCd " + DataAccessUtility.SetBetweenCommand(searchCond.SyozokuGyosyaCdFrom, searchCond.SyozokuGyosyaCdTo, 4));
            if (!string.IsNullOrEmpty(searchCond.SyozokuGyosyaCdFrom) && string.IsNullOrEmpty(searchCond.SyozokuGyosyaCdTo))
            {
                sqlContent.Append(" and sm.SyozokuGyosyaCd >= @SyozokuGyosyaCdFrom ");
                commandParams.Add("@SyozokuGyosyaCdFrom", SqlDbType.NVarChar).Value = searchCond.SyozokuGyosyaCdFrom;
            }
            else if (string.IsNullOrEmpty(searchCond.SyozokuGyosyaCdFrom) && !string.IsNullOrEmpty(searchCond.SyozokuGyosyaCdTo))
            {
                sqlContent.Append(" and sm.SyozokuGyosyaCd <= @SyozokuGyosyaCdTo ");
                commandParams.Add("@SyozokuGyosyaCdTo", SqlDbType.NVarChar).Value = searchCond.SyozokuGyosyaCdTo;
            }
            else if (!string.IsNullOrEmpty(searchCond.SyozokuGyosyaCdFrom) && !string.IsNullOrEmpty(searchCond.SyozokuGyosyaCdTo))
            {
                sqlContent.Append(" and sm.SyozokuGyosyaCd >= @SyozokuGyosyaCdFrom ");
                commandParams.Add("@SyozokuGyosyaCdFrom", SqlDbType.NVarChar).Value = searchCond.SyozokuGyosyaCdFrom;

                sqlContent.Append(" and sm.SyozokuGyosyaCd <= @SyozokuGyosyaCdTo ");
                commandParams.Add("@SyozokuGyosyaCdTo", SqlDbType.NVarChar).Value = searchCond.SyozokuGyosyaCdTo;
            }

            if (!string.IsNullOrEmpty(searchCond.JukoDtFrom) && !string.IsNullOrEmpty(searchCond.JukoDtTo))
            {
                // 受講日FROM ~ TO
                sqlContent.Append(" and sm.JukoDt >= @jukoDtFrom and sm.JukoDt <= @jukoDtTo                                                                     ");
                commandParams.Add("@jukoDtFrom", SqlDbType.NVarChar).Value = searchCond.JukoDtFrom;
                commandParams.Add("@jukoDtTo", SqlDbType.NVarChar).Value = searchCond.JukoDtTo;
            }

            // ORDER BY
            sqlContent.Append(" order by sm.SaisuiinShiteiNo                                                                                                    ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region JyukoYoteishaListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JyukoYoteishaListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class JyukoYoteishaListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zenkaiJukoDtAddFlg"></param>
        /// <param name="zenkaiJukoDtFrom"></param>
        /// <param name="zenkaiJukoDtTo"></param>
        /// <param name="saisuiinYukokigenDtAddFlg"></param>
        /// <param name="saisuiinYukokigenDtFrom"></param>
        /// <param name="saisuiinYukokigenDtTo"></param>
        /// <param name="saisuiinCdFrom"></param>
        /// <param name="saisuiinCdTo"></param>
        /// <param name="syozokuGyosyaCdFrom"></param>
        /// <param name="syozokuGyosyaCdTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SaisuiinMstDataSet.JyukoYoteishaListDataTable GetDataBySearchCond(
            bool zenkaiJukoDtAddFlg,
            string zenkaiJukoDtFrom,
            string zenkaiJukoDtTo,
            bool saisuiinYukokigenDtAddFlg,
            string saisuiinYukokigenDtFrom,
            string saisuiinYukokigenDtTo,
            string saisuiinCdFrom,
            string saisuiinCdTo,
            string syozokuGyosyaCdFrom,
            string syozokuGyosyaCdTo)
        {
            SqlCommand command = CreateSqlCommand(zenkaiJukoDtAddFlg,
                                                    zenkaiJukoDtFrom,
                                                    zenkaiJukoDtTo,
                                                    saisuiinYukokigenDtAddFlg,
                                                    saisuiinYukokigenDtFrom,
                                                    saisuiinYukokigenDtTo,
                                                    saisuiinCdFrom,
                                                    saisuiinCdTo,
                                                    syozokuGyosyaCdFrom,
                                                    syozokuGyosyaCdTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SaisuiinMstDataSet.JyukoYoteishaListDataTable dataTable = new SaisuiinMstDataSet.JyukoYoteishaListDataTable();
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
        /// <param name="zenkaiJukoDtAddFlg"></param>
        /// <param name="zenkaiJukoDtFrom"></param>
        /// <param name="zenkaiJukoDtTo"></param>
        /// <param name="saisuiinYukokigenDtAddFlg"></param>
        /// <param name="saisuiinYukokigenDtFrom"></param>
        /// <param name="saisuiinYukokigenDtTo"></param>
        /// <param name="saisuiinCdFrom"></param>
        /// <param name="saisuiinCdTo"></param>
        /// <param name="syozokuGyosyaCdFrom"></param>
        /// <param name="syozokuGyosyaCdTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            bool zenkaiJukoDtAddFlg,
            string zenkaiJukoDtFrom,
            string zenkaiJukoDtTo,
            bool saisuiinYukokigenDtAddFlg,
            string saisuiinYukokigenDtFrom,
            string saisuiinYukokigenDtTo,
            string saisuiinCdFrom,
            string saisuiinCdTo,
            string syozokuGyosyaCdFrom,
            string syozokuGyosyaCdTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                           ");
            sqlContent.Append("     SaisuiinMst.SaisuiinCd,                                                                     ");
            sqlContent.Append("     SaisuiinMst.SaisuiinNm,                                                                     ");
            sqlContent.Append("     SaisuiinMst.SyozokuGyosyaCd,                                                                ");
            sqlContent.Append("     SaisuiinMst.SaisuiinAdr,                                                                    ");
            sqlContent.Append("     SaisuiinMst.SaisuiinShiteiNo,                                                               ");
            sqlContent.Append("     SaisuiinMst.KanrishiNo,                                                                     ");
            sqlContent.Append("     SaisuiinMst.SaisuiinKana,                                                                   ");
            sqlContent.Append("     SaisuiinMst.ZenkaiJukoDt,                                                                   ");
            sqlContent.Append("     CASE                                                                                        ");
            sqlContent.Append("         WHEN ISNULL(SaisuiinMst.ZenkaiJukoDt, '') = '' THEN ''                                  ");
            sqlContent.Append("         ELSE CONCAT(                                                                            ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.ZenkaiJukoDt,0,5), '/',                                       ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.ZenkaiJukoDt,5,2), '/',                                       ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.ZenkaiJukoDt,7,2)) END AS ZenkaiJukoDtCol,                    ");
            sqlContent.Append("     SaisuiinMst.SaisuiinYukokigenDt,                                                            ");
            sqlContent.Append("     CASE                                                                                        ");
            sqlContent.Append("         WHEN ISNULL(SaisuiinMst.SaisuiinYukokigenDt, '') = '' THEN ''                           ");
            sqlContent.Append("         ELSE CONCAT(                                                                            ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinYukokigenDt,0,5), '/',                                ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinYukokigenDt,5,2), '/',                                ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinYukokigenDt,7,2)) END AS SaisuiinYukokigenDtCol,      ");
            sqlContent.Append("     SaisuiinMst.SaisuiinSeinegappi,                                                             ");
            sqlContent.Append("     CASE                                                                                        ");
            sqlContent.Append("         WHEN ISNULL(SaisuiinMst.SaisuiinSeinegappi, '') = '' THEN ''                            ");
            sqlContent.Append("         ELSE CONCAT(                                                                            ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinSeinegappi,0,5), '/',                                 ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinSeinegappi,5,2), '/',                                 ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.SaisuiinSeinegappi,7,2)) END AS SaisuiinSeinegappiCol,        ");
            sqlContent.Append("     SaisuiinMst.KanrishiSyutokuDt,                                                              ");
            sqlContent.Append("     CASE                                                                                        ");
            sqlContent.Append("         WHEN ISNULL(SaisuiinMst.KanrishiSyutokuDt, '') = '' THEN ''                             ");
            sqlContent.Append("         ELSE CONCAT(                                                                            ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.KanrishiSyutokuDt,0,5), '/',                                  ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.KanrishiSyutokuDt,5,2), '/',                                  ");
            sqlContent.Append("             SUBSTRING(SaisuiinMst.KanrishiSyutokuDt,7,2)) END AS KanrishiSyutokuDtCol,          ");
            sqlContent.Append("     GyoshaMst.GyoshaNm,                                                                         ");
            sqlContent.Append("     GyoshaMst.DaihyoshaNm,                                                                      ");
            sqlContent.Append("     GyoshaMst.GyoshaAdr                                                                         ");

            // FROM
            sqlContent.Append("FROM                                                                                             ");
            sqlContent.Append("     SaisuiinMst                                                                                 ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                  ");
            sqlContent.Append("     GyoshaMst                                                                                   ");
            sqlContent.Append("ON   GyoshaMst.GyoshaCd = SaisuiinMst.SyozokuGyosyaCd                                            ");

            // WHERE
            sqlContent.Append("WHERE                                                                                            ");
            sqlContent.Append("     1 = 1                                                                                       ");

            if (zenkaiJukoDtAddFlg)
            {
                //sqlContent.Append("AND SaisuiinMst.ZenkaiJukoDt " + DataAccessUtility.SetBetweenCommand(zenkaiJukoDtFrom, zenkaiJukoDtTo, 8));

                sqlContent.Append("AND SaisuiinMst.ZenkaiJukoDt >= @zenkaiJukoDtFrom ");
                commandParams.Add("@zenkaiJukoDtFrom", SqlDbType.NVarChar).Value = zenkaiJukoDtFrom;

                sqlContent.Append("AND SaisuiinMst.ZenkaiJukoDt <= @zenkaiJukoDtTo ");
                commandParams.Add("@zenkaiJukoDtTo", SqlDbType.NVarChar).Value = zenkaiJukoDtTo;
            }

            if (saisuiinYukokigenDtAddFlg)
            {
                //sqlContent.Append("AND SaisuiinMst.SaisuiinYukokigenDt " + DataAccessUtility.SetBetweenCommand(saisuiinYukokigenDtFrom, saisuiinYukokigenDtTo, 8));

                sqlContent.Append("AND SaisuiinMst.SaisuiinYukokigenDt >= @saisuiinYukokigenDtFrom ");
                commandParams.Add("@saisuiinYukokigenDtFrom", SqlDbType.NVarChar).Value = saisuiinYukokigenDtFrom;

                sqlContent.Append("AND SaisuiinMst.SaisuiinYukokigenDt <= @saisuiinYukokigenDtTo ");
                commandParams.Add("@saisuiinYukokigenDtTo", SqlDbType.NVarChar).Value = saisuiinYukokigenDtTo;
            }

            // 採水員コード FROM ~ TO
            //sqlContent.Append("AND SaisuiinMst.SaisuiinCd " + DataAccessUtility.SetBetweenCommand(saisuiinCdFrom, saisuiinCdTo, 5));
            if (!string.IsNullOrEmpty(saisuiinCdFrom) && string.IsNullOrEmpty(saisuiinCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinCd >= @saisuiinCdFrom ");
                commandParams.Add("@saisuiinCdFrom", SqlDbType.NVarChar).Value = saisuiinCdFrom;
            }
            else if (string.IsNullOrEmpty(saisuiinCdFrom) && !string.IsNullOrEmpty(saisuiinCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinCd <= @saisuiinCdTo ");
                commandParams.Add("@saisuiinCdTo", SqlDbType.NVarChar).Value = saisuiinCdTo;
            }
            else if (!string.IsNullOrEmpty(saisuiinCdFrom) && !string.IsNullOrEmpty(saisuiinCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinCd >= @saisuiinCdFrom ");
                commandParams.Add("@saisuiinCdFrom", SqlDbType.NVarChar).Value = saisuiinCdFrom;

                sqlContent.Append("AND SaisuiinMst.SaisuiinCd <= @saisuiinCdTo ");
                commandParams.Add("@saisuiinCdTo", SqlDbType.NVarChar).Value = saisuiinCdTo;
            }

            // 所属業者コード FROM ~ TO
            //sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd " + DataAccessUtility.SetBetweenCommand(syozokuGyosyaCdFrom, syozokuGyosyaCdTo, 4));
            if (!string.IsNullOrEmpty(syozokuGyosyaCdFrom) && string.IsNullOrEmpty(syozokuGyosyaCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd >= @syozokuGyosyaCdFrom ");
                commandParams.Add("@syozokuGyosyaCdFrom", SqlDbType.NVarChar).Value = syozokuGyosyaCdFrom;
            }
            else if (string.IsNullOrEmpty(syozokuGyosyaCdFrom) && !string.IsNullOrEmpty(syozokuGyosyaCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd <= @syozokuGyosyaCdTo ");
                commandParams.Add("@syozokuGyosyaCdTo", SqlDbType.NVarChar).Value = syozokuGyosyaCdTo;
            }
            else if (!string.IsNullOrEmpty(syozokuGyosyaCdFrom) && !string.IsNullOrEmpty(syozokuGyosyaCdTo))
            {
                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd >= @syozokuGyosyaCdFrom ");
                commandParams.Add("@syozokuGyosyaCdFrom", SqlDbType.NVarChar).Value = syozokuGyosyaCdFrom;

                sqlContent.Append("AND SaisuiinMst.SyozokuGyosyaCd <= @syozokuGyosyaCdTo ");
                commandParams.Add("@syozokuGyosyaCdTo", SqlDbType.NVarChar).Value = syozokuGyosyaCdTo;
            }
            
            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     SaisuiinMst.SaisuiinCd                                       ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}