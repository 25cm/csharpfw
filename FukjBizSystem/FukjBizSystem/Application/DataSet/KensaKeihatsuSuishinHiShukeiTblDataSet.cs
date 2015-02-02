using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {    
    
    public partial class KensaKeihatsuSuishinHiShukeiTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.KensaKeihatsuSuishinHiShukeiTblDataSetTableAdapters
{

    #region KensaKeihatsuSuishinListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKeihatsuSuishinListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKeihatsuSuishinListTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shukeiDtFrom"></param>
        /// <param name="shukeiDtTo"></param>
        /// <param name="gyosyaCdFrom"></param>
        /// <param name="gyosyaCdTo"></param>
        /// <param name="kumiaiCd"></param>
        /// <param name="mochikomi"></param>
        /// <param name="syusyu"></param>
        /// <param name="toriatsukai"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/09  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable GetDataBySearchCond(
            //string suishinhiNendo,
            //string kamiShimoKbn,
            string shukeiDtFrom,
            string shukeiDtTo,
            string gyosyaCdFrom,
            string gyosyaCdTo,
            string kumiaiCd,
            bool mochikomi,
            bool syusyu,
            bool toriatsukai)
        {
            SqlCommand command = CreateSqlCommand(shukeiDtFrom,
                                                    shukeiDtTo,
                                                    gyosyaCdFrom,
                                                    gyosyaCdTo,
                                                    kumiaiCd,
                                                    mochikomi,
                                                    syusyu,
                                                    toriatsukai);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable dataTable = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable();
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
        /// <param name="shukeiDtFrom"></param>
        /// <param name="shukeiDtTo"></param>
        /// <param name="gyosyaCdFrom"></param>
        /// <param name="gyosyaCdTo"></param>
        /// <param name="kumiaiCd"></param>
        /// <param name="mochikomi"></param>
        /// <param name="syusyu"></param>
        /// <param name="toriatsukai"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/09  DatNT     v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            //string suishinhiNendo,
            //string kamiShimoKbn,
            string shukeiDtFrom,
            string shukeiDtTo,
            string gyosyaCdFrom,
            string gyosyaCdTo,
            string kumiaiCd,
            bool mochikomi,
            bool syusyu,
            bool toriatsukai)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            string shukeiDtFromTo = shukeiDtFrom.Substring(0, 4) + "/" + shukeiDtFrom.Substring(4, 2)
                                    + "～"
                                    + shukeiDtTo.Substring(0, 4) + "/" + shukeiDtTo.Substring(4, 2);

            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.SuishinhiNo,                                                        ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ShukeiFromNengetsu,                                                 ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ShukeiToNengetsu,                                                   ");
            //sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KamiShimoKbn,                                                       ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd,                                                           ");

            // 2014/10/09 DatNT v1.01 MOD Start
            //sqlContent.Append("     CASE KensaKeihatsuSuishinHiShukeiTbl.KamiShimoKbn                                                   ");
            //sqlContent.Append("         WHEN '1' THEN CONCAT(KensaKeihatsuSuishinHiShukeiTbl.SuishinhiNendo, '上期')                    ");
            //sqlContent.Append("         WHEN '2' THEN CONCAT(KensaKeihatsuSuishinHiShukeiTbl.SuishinhiNendo, '下期')                    ");
            //sqlContent.Append("         ELSE ''                                                                                         ");
            //sqlContent.Append("     END AS NendokiCol,                                                                                  ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ShukeiFromNengetsu, '') = '' AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ShukeiToNengetsu, '') = '' ");
            sqlContent.Append("             THEN ''                                                                                     ");
            sqlContent.Append("         ELSE CONCAT(KensaKeihatsuSuishinHiShukeiTbl.ShukeiFromNengetsu, '～', KensaKeihatsuSuishinHiShukeiTbl.ShukeiToNengetsu) ");
            sqlContent.Append("     END AS NendokiCol,                                                                                  ");
            // 2014/10/09 DatNT v1.01 MOD End

            // 2014/10/13 AnhNV 022_検査啓発推進費一覧_帳票設計書_vn_V1.03 ADD Start
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ShukeiDt,                                                           ");
            // 2014/10/13 AnhNV 022_検査啓発推進費一覧_帳票設計書_vn_V1.03 ADD End

            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KyodoKumiaiCd,                                                      ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(KensaKeihatsuSuishinHiShukeiTbl.KyodoKumiaiCd, '') = '' THEN '99999'                ");
            sqlContent.Append("         ELSE KensaKeihatsuSuishinHiShukeiTbl.KyodoKumiaiCd                                              ");
            sqlContent.Append("     END AS KyodoKumiaiCdOrder,                                                                          ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn,                                               ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd,                                                ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '1' THEN '取扱'                     ");
            sqlContent.Append("         WHEN KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                 ");
            sqlContent.Append("             AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd, '') = '' THEN '持込'        ");
            sqlContent.Append("         WHEN KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                 ");
            sqlContent.Append("             AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd, '') <> '' THEN '収集'       ");
            sqlContent.Append("         ELSE ''                                                                                         ");
            sqlContent.Append("     END AS GyosyaKbnCol,                                                                                ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ShiharaiTotal,                                                      ");
            //sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ShiharaiDt,                                                         ");
            sqlContent.Append("     CASE WHEN ISDATE(KensaKeihatsuSuishinHiShukeiTbl.ShiharaiDt)=0 THEN ''                              ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,KensaKeihatsuSuishinHiShukeiTbl.ShiharaiDt), 111)       ");
            sqlContent.Append("     END AS ShiharaiDt,                                                                                  ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ShiharaiDt,'') = '' THEN ''                         ");
            sqlContent.Append("         ELSE                                                                                            ");
            sqlContent.Append("             CONCAT(SUBSTRING(KensaKeihatsuSuishinHiShukeiTbl.ShiharaiDt, 0,5), '/',                     ");
            sqlContent.Append("                     SUBSTRING(KensaKeihatsuSuishinHiShukeiTbl.ShiharaiDt, 5,2), '/',                    ");
            sqlContent.Append("                     SUBSTRING(KensaKeihatsuSuishinHiShukeiTbl.ShiharaiDt, 7,2))                         ");
            sqlContent.Append("     END AS ShiharaiDtCol,                                                                               ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiMochiCnt,                                               ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiMochiAmt,                                               ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiShushuCnt,                                              ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiShushuAmt,                                              ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiToriCnt,                                                ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiToriAmt,                                                ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuMochiCnt,                                           ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuMochiAmt,                                           ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuShushuCnt,                                          ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuShushuAmt,                                          ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuToriCnt,                                            ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuToriAmt,                                            ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11GaikanCnt,                                                   ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11GaikanAmt,                                                   ");
            sqlContent.Append("     KyodoKumiaiMst.KumiaiNm,                                                                            ");
            sqlContent.Append("     GyoshaMst.GyoshaNm,                                                                                 ");

            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiMochiUp,                                                ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuShushuUp,                                           ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuToriUp,                                             ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11GaikanUp,                                                    ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiShushuUp,                                               ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.KeiryoShomeiToriUp,                                                 ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.Kensa11SuishitsuMochiUp                                             ");

            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl                                                                     ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                          ");
            sqlContent.Append("     KyodoKumiaiMst                                                                                      ");
            sqlContent.Append("         ON KyodoKumiaiMst.KumiaiCd = KensaKeihatsuSuishinHiShukeiTbl.KyodoKumiaiCd                      ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                          ");
            sqlContent.Append("     GyoshaMst                                                                                           ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd                                ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");
            
            // 2014/10/09 DatNT v1.01 DEL Start
            //if (!string.IsNullOrEmpty(suishinhiNendo))
            //{
            //    sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.SuishinhiNendo = @suishinhiNendo                                 ");
            //    commandParams.Add("@suishinhiNendo", SqlDbType.NVarChar).Value = suishinhiNendo;
            //}

            //if (kamiShimoKbn == "1")
            //{
            //    sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.KamiShimoKbn = '1'                                               ");
            //}
            //else if (kamiShimoKbn == "2")
            //{
            //    sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.KamiShimoKbn = '2'                                               ");
            //}
            // 2014/10/09 DatNT v1.01 DEL End

            // 2014/10/09 DatNT v1.01 ADD Start
            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ShukeiFromNengetsu >= @shukeiDtFrom                                   ");
            commandParams.Add("@shukeiDtFrom", SqlDbType.NVarChar).Value = shukeiDtFrom;

            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ShukeiToNengetsu <= @shukeiDtTo                                       ");
            commandParams.Add("@shukeiDtTo", SqlDbType.NVarChar).Value = shukeiDtTo;
            // 2014/10/09 DatNT v1.01 ADD End

            //sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd " + DataAccessUtility.SetBetweenCommand(gyosyaCdFrom, gyosyaCdTo, 4));
            if (!string.IsNullOrEmpty(gyosyaCdFrom) && string.IsNullOrEmpty(gyosyaCdTo))
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd >= @gyosyaCdFrom ");
                commandParams.Add("@gyosyaCdFrom", SqlDbType.NVarChar).Value = gyosyaCdFrom;
            }
            else if (string.IsNullOrEmpty(gyosyaCdFrom) && !string.IsNullOrEmpty(gyosyaCdTo))
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd <= @gyosyaCdTo ");
                commandParams.Add("@gyosyaCdTo", SqlDbType.NVarChar).Value = gyosyaCdTo;
            }
            else if (!string.IsNullOrEmpty(gyosyaCdFrom) && !string.IsNullOrEmpty(gyosyaCdTo))
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd >= @gyosyaCdFrom ");
                commandParams.Add("@gyosyaCdFrom", SqlDbType.NVarChar).Value = gyosyaCdFrom;

                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd <= @gyosyaCdTo ");
                commandParams.Add("@gyosyaCdTo", SqlDbType.NVarChar).Value = gyosyaCdTo;
            }

            if (!string.IsNullOrEmpty(kumiaiCd))
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.KyodoKumiaiCd = @kumiaiCd ");
                commandParams.Add("@kumiaiCd", SqlDbType.NVarChar).Value = kumiaiCd;
            }

            #region 対象業者

            // 8
            if (mochikomi && !syusyu && !toriatsukai)
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                       ");
                sqlContent.Append("AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd, '') = ''                             ");
            }

            // 9
            if (!mochikomi && syusyu && !toriatsukai)
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                       ");
                sqlContent.Append("AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd, '') <> ''                            ");
            }

            // 10
            if (!mochikomi && !syusyu && toriatsukai)
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '1'                                       ");
            }

            // 8 9
            if (mochikomi && syusyu && !toriatsukai)
            {
                sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                       ");
            }

            // 8 10
            if (mochikomi && !syusyu && toriatsukai)
            {
                sqlContent.Append("AND ((KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                     ");
                sqlContent.Append("         AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd, '') = '' )                  ");
                sqlContent.Append("OR KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '1' )                                      ");
            }

            // 9 10
            if (!mochikomi && syusyu && toriatsukai)
            {
                sqlContent.Append("AND ((KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                     ");
                sqlContent.Append("         AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd, '') <> '' )                 ");
                sqlContent.Append("OR KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '1' )                                      ");
            }

            // 8 9 10
            if (mochikomi && syusyu && toriatsukai)
            {
                sqlContent.Append("AND (KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                      ");
                sqlContent.Append("         OR KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '1' )                             ");
            }

            #endregion

            // ORDER BY
            sqlContent.Append("ORDER BY                                                                                                 ");
			sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.SuishinhiNo,                                                        ");	//受入20141225 add
			sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ShukeiFromNengetsu,                                                 ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.ShukeiToNengetsu,                                                   ");
			sqlContent.Append("     KyodoKumiaiCdOrder,                                                                                 ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd                                                            ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region SeikyuShimeTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26  habu　  新規作成
    /// </history>
    public partial class KensaKeihatsuSuishinhiStdTableAdapter
    {
        #region CommandTimeout
        // コマンドタイムアウト設定（単位は秒）
        public int CommandTimeout
        {
            get { return CommandCollection[0].CommandTimeout; }
            set
            {
                for (int i = 0; i < this.CommandCollection.Length; ++i)
                {
                    if (CommandCollection[i] != null)
                    {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).CommandTimeout = value;
                    }
                }
            }
        }
        #endregion
    }
    #endregion
}
