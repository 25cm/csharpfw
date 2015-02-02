using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {    
    
    public partial class NippoHdrTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.NippoHdrTblDataSetTableAdapters
{   

    #region DailyIncompleteCountTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DailyIncompleteCountTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class DailyIncompleteCountTableAdapter
    {
        #region CountDailyReportIncomplete
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CountDailyReportIncomplete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiKensaNenTsuki"></param>
        /// <param name="gyoshaCdFrom"></param>
        /// <param name="gyoshaCdTo"></param>
        /// <param name="shimeKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/25　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal int CountDailyReportIncomplete(
            string kensaIraiKensaNenTsuki,
            string gyoshaCdFrom,
            string gyoshaCdTo,
            string shimeKbn)
        {
            SqlCommand command = CreateSqlCommand(kensaIraiKensaNenTsuki, gyoshaCdFrom, gyoshaCdTo, shimeKbn);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            NippoHdrTblDataSet.DailyIncompleteCountDataTable dataTable = new NippoHdrTblDataSet.DailyIncompleteCountDataTable();
            adpt.Fill(dataTable);

            return Convert.ToInt32(dataTable[0].DailyIncompleteCount);
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiKensaNenTsuki"></param>
        /// <param name="gyoshaCdFrom"></param>
        /// <param name="gyoshaCdTo"></param>
        /// <param name="shimeKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// 2014/10/29  DatNT    v1.06
        /// 2014/12/10  kiyokuni v1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kensaIraiKensaNenTsuki,
            string gyoshaCdFrom,
            string gyoshaCdTo,
            string shimeKbn)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     COUNT(*) AS DailyIncompleteCount                                                                    ");
            
            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     KensaIraiTbl                                                                                        ");
            
            // 2014/10/29 DatNT v1.03 DEL Start
            //sqlContent.Append("INNER JOIN NippoDtlTbl                                                                                   ");
            //sqlContent.Append("         ON NippoDtlTbl.NippoDtlKensaSyubetsu = KensaIraiTbl.KensaIraiHoteiKbn                           ");
            //sqlContent.Append("         AND NippoDtlTbl.NippoDtlKensaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd                    ");
            //sqlContent.Append("         AND NippoDtlTbl.NippoDtlKensaIraiNendo = KensaIraiTbl.KensaIraiNendo                            ");
            //sqlContent.Append("         AND NippoDtlTbl.NippoDtlKensaIraiRenban = KensaIraiTbl.KensaIraiRenban                          ");
            //sqlContent.Append("INNER JOIN NippoHdrTbl                                                                                   ");
            //sqlContent.Append("         ON NippoHdrTbl.NippoKensaDt = NippoDtlTbl.NippoDtlKensaDt                                       ");
            //sqlContent.Append("         AND NippoHdrTbl.NippoKensainCd = NippoDtlTbl.NippoDtlKensainCd                                  ");
            // 2014/10/29 DatNT v1.03 DEL End

            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 2014/10/29 DatNT v1.03 DEL Start
            //sqlContent.Append("     AND (	NippoHdrTbl.NippoKanryoFlg = '0'                                                            ");
            //sqlContent.Append("             OR                                                                                          ");
            //sqlContent.Append("             NippoHdrTbl.NippoFukukachoCheckFlg = '0'                                                    ");
            //sqlContent.Append("             OR                                                                                          ");
            //sqlContent.Append("             NippoHdrTbl.NippoKachoCheckFlg = '0'                                                        ");
            //sqlContent.Append("         )                                                                                               ");
            // 2014/10/29 DatNT v1.03 DEL End

            // 2014/12/10 kiyokuni v1.07 MOD Start
            ////// 2014/10/29 DatNT v1.03 ADD Start
            ////// 外観、水質が未承認
            ////sqlContent.Append("     AND (KensaIraiTbl.KensaIraiGaikanNippoKbn < '2' OR KensaIraiTbl.KensaIraiSuishitsuNippoKbn < '2')   ");
            //sqlContent.Append("     AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) = '" + kensaIraiKensaNenTsuki + "' ");
            ////// 2014/10/29 DatNT v1.03 ADD End

            sqlContent.Append("     AND ((KensaIraiTbl.KensaIraiHoteiKbn <=2 AND KensaIraiTbl.KensaIraiGaikanNippoKbn < '2')   ");
            sqlContent.Append("       OR (KensaIraiTbl.KensaIraiHoteiKbn =3 AND KensaIraiTbl.KensaIraiSuishitsuNippoKbn < '1'))   ");

            sqlContent.Append("     AND ((KensaIraiTbl.KensaIraiHoteiKbn <=2 AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) = '" + kensaIraiKensaNenTsuki + "') ");
            sqlContent.Append("       OR (KensaIraiTbl.KensaIraiHoteiKbn =3 AND SUBSTRING(KensaIraiTbl.KensaIraiSuishitsuUketsukeDt,1,6) = '" + kensaIraiKensaNenTsuki + "')) ");
            
            // 2014/12/10 kiyokuni v1.07 MOD End
            
            sqlContent.Append("     AND ISNULL(KensaIraiTbl.KensaIraiTorisageNen, '') = ''                                              ");
            sqlContent.Append("     AND ISNULL(KensaIraiTbl.KensaIraiTorisageTsuki, '') = ''                                            ");
            sqlContent.Append("     AND ISNULL(KensaIraiTbl.KensaIraiTorisageBi, '') = ''                                               ");

            if (!string.IsNullOrEmpty(gyoshaCdFrom) || !string.IsNullOrEmpty(gyoshaCdTo))
            {
                if (!string.IsNullOrEmpty(gyoshaCdFrom) && string.IsNullOrEmpty(gyoshaCdTo))
                {
                    sqlContent.Append("AND (    (KensaIraiTbl.KensaIraiHoteiKbn <= '2'                                                  ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd >= '" + gyoshaCdFrom + "' )           ");
                    sqlContent.Append("         OR                                                                                      ");
                    sqlContent.Append("         (KensaIraiTbl.KensaIraiHoteiKbn = '3'                                                   ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiSeikyuGyoshaCd >= '" + gyoshaCdFrom + "' )                ");
                    sqlContent.Append("     )                                                                                           ");
                }
                else if (string.IsNullOrEmpty(gyoshaCdFrom) && !string.IsNullOrEmpty(gyoshaCdTo))
                {
                    sqlContent.Append("AND (    (KensaIraiTbl.KensaIraiHoteiKbn <= '2'                                                  ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd <= '" + gyoshaCdTo + "' )             ");
                    sqlContent.Append("         OR                                                                                      ");
                    sqlContent.Append("         (KensaIraiTbl.KensaIraiHoteiKbn = '3'                                                   ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiSeikyuGyoshaCd <= '" + gyoshaCdTo + "' )                  ");
                    sqlContent.Append("     )                                                                                           ");
                }
                else
                {
                    sqlContent.Append("AND (    (KensaIraiTbl.KensaIraiHoteiKbn <= '2'                                                  ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd >= '" + gyoshaCdFrom + "'             ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd <= '" + gyoshaCdTo + "' )             ");
                    sqlContent.Append("         OR                                                                                      ");
                    sqlContent.Append("         (KensaIraiTbl.KensaIraiHoteiKbn = '3'                                                   ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiSeikyuGyoshaCd >= '" + gyoshaCdFrom + "'                  ");
                    sqlContent.Append("             AND KensaIraiTbl.KensaIraiSeikyuGyoshaCd <= '" + gyoshaCdTo + "' )                  ");
                    sqlContent.Append("     )                                                                                           ");
                }
            }            

            if (shimeKbn == "1")
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiUketsukeShishoKbn = '1'                                                    ");
                sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = '3'                                                             ");
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaNippoListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaNippoListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaNippoListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokuinCd"></param>
        /// <param name="kensaDtUse"></param>
        /// <param name="kensaDtFrom"></param>
        /// <param name="kensaDtTo"></param>
        /// <param name="taishokbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal NippoHdrTblDataSet.KensaNippoListDataTable GetDataBySearchCond(
            string shokuinCd,
            bool kensaDtUse,
            string kensaDtFrom,
            string kensaDtTo,
            string taishokbn)
        {
            SqlCommand command = CreateSqlCommand(shokuinCd, kensaDtUse, kensaDtFrom, kensaDtTo, taishokbn);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            NippoHdrTblDataSet.KensaNippoListDataTable dataTable = new NippoHdrTblDataSet.KensaNippoListDataTable();
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
        /// <param name="shokuinCd"></param>
        /// <param name="kensaDtUse"></param>
        /// <param name="kensaDtFrom"></param>
        /// <param name="kensaDtTo"></param>
        /// <param name="taishokbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// 2014/11/05  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string shokuinCd,
            bool kensaDtUse,
            string kensaDtFrom,
            string kensaDtTo,
            string taishokbn)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append(" 	ROW_NUMBER() OVER(ORDER BY NippoHdrTbl.NippoKensaDt, NippoHdrTbl.NippoKensainCd ASC) AS RowNumber,  ");
            sqlContent.Append("     NippoHdrTbl.NippoKensaDt,                                                                           ");
            // 2014/11/05 DatNT v1.03 MOD Start
            //sqlContent.Append("     CONCAT(CAST(SUBSTRING(NippoHdrTbl.NippoKensaDt, 0, 5) AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= NippoHdrTbl.NippoKensaDt ORDER BY KaishiDt DESC), '/', ");
            //sqlContent.Append("                 SUBSTRING(NippoHdrTbl.NippoKensaDt, 5, 2), '/',                                         ");
            //sqlContent.Append("                 SUBSTRING(NippoHdrTbl.NippoKensaDt, 7, 2)) AS kensaDtCol,                               ");
            sqlContent.Append("     CONCAT(     SUBSTRING(NippoHdrTbl.NippoKensaDt, 0, 5), '/',                                         ");
            sqlContent.Append("                 SUBSTRING(NippoHdrTbl.NippoKensaDt, 5, 2), '/',                                         ");
            sqlContent.Append("                 SUBSTRING(NippoHdrTbl.NippoKensaDt, 7, 2)) AS kensaDtCol,                               ");
            // 2014/11/05 DatNT v1.03 MOD End
            sqlContent.Append("     NippoHdrTbl.NippoKensainCd,                                                                         ");
            sqlContent.Append("     NippoHdrTbl.NippoSokoKyori,                                                                         ");
            sqlContent.Append("     NippoHdrTbl.NippoKyuyu,                                                                             ");
            sqlContent.Append("     NippoHdrTbl.NippoSharyoTenkenKiroku,                                                                ");
            sqlContent.Append("     NippoHdrTbl.NippoJitchichosaKensu,                                                                  ");
            sqlContent.Append("     NippoHdrTbl.NippoChokageninchosaKensu,                                                              ");
            sqlContent.Append("     NippoHdrTbl.NippoCrosscheckKensu,                                                                   ");
            sqlContent.Append("     NippoHdrTbl.NippoHokokujiko,                                                                        ");
            sqlContent.Append("     NippoHdrTbl.NippoShijinaiyo,                                                                        ");
            sqlContent.Append("     NippoHdrTbl.NippoKanryoFlg,                                                                         ");
            sqlContent.Append("     CASE NippoHdrTbl.NippoKanryoFlg WHEN '1' THEN '済' ELSE '' END AS kensaKanryoCol,                   ");
            sqlContent.Append("     NippoHdrTbl.NippoFukukachoCheckFlg,                                                                 ");
            sqlContent.Append("     CASE NippoHdrTbl.NippoFukukachoCheckFlg WHEN '1' THEN '済' ELSE '' END AS fukuKachoKakuninCol,      ");
            sqlContent.Append("     NippoHdrTbl.NippoKachoCheckFlg,                                                                     ");
            sqlContent.Append("     CASE NippoHdrTbl.NippoKachoCheckFlg WHEN '1' THEN '済' ELSE '' END AS kachoKakuninCol,              ");
            sqlContent.Append("     ShokuinMst.ShokuinNm                                                                                ");

            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     NippoHdrTbl                                                                                         ");
            sqlContent.Append("LEFT OUTER JOIN ShokuinMst                                                                               ");
            sqlContent.Append("         ON ShokuinMst.ShokuinCd = NippoHdrTbl.NippoKensainCd                                            ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 職員コード
            if (!string.IsNullOrEmpty(shokuinCd))
            {
                sqlContent.Append("AND NippoHdrTbl.NippoKensainCd = @shokuinCd ");
                commandParams.Add("@shokuinCd", SqlDbType.NVarChar).Value = shokuinCd;
            }

            if (kensaDtUse)
            {
                sqlContent.Append("AND NippoHdrTbl.NippoKensaDt >= @kensaDtFrom ");
                commandParams.Add("@kensaDtFrom", SqlDbType.NVarChar).Value = kensaDtFrom;

                sqlContent.Append("AND NippoHdrTbl.NippoKensaDt <= @kensaDtTo ");
                commandParams.Add("@kensaDtTo", SqlDbType.NVarChar).Value = kensaDtTo;
            }

            if (taishokbn == "1")
            {
                sqlContent.Append("AND NippoHdrTbl.NippoKanryoFlg = '1' ");
            }
            else if (taishokbn == "2")
            {
                sqlContent.Append("AND NippoHdrTbl.NippoFukukachoCheckFlg <> '1' ");
            }
            else if (taishokbn == "3")
            {
                sqlContent.Append("AND NippoHdrTbl.NippoKachoCheckFlg <> '1' ");
            }

            // ORDER BY
            sqlContent.Append("ORDER BY                                                                                                 ");
            sqlContent.Append("     NippoHdrTbl.NippoKensaDt,                                                                           ");
            sqlContent.Append("     NippoHdrTbl.NippoKensainCd                                                                          ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
