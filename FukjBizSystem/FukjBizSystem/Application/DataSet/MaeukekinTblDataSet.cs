using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
    
    public partial class MaeukekinTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.MaeukekinTblDataSetTableAdapters
{
    #region MaeukekinTblKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MaeukekinTblKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MaeukekinTblKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rendoKbn"></param>
        /// <param name="maeukeNo"></param>
        /// <param name="uriageDtUse"></param>
        /// <param name="uriageDtFrom"></param>
        /// <param name="uriageDtTo"></param>
        /// <param name="kyoseiUriage"></param>
        /// <param name="furikomininNm"></param>
        /// <param name="nyukinDtUse"></param>
        /// <param name="nyukinDtFrom"></param>
        /// <param name="nyukinDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　 新規作成
        /// 2014/11/10  DatNT     v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal MaeukekinTblDataSet.MaeukekinTblKensakuDataTable GetDataBySearchCond(
            // 2014/11/10 DatNT v1.02 MOD Start
            //String saibanKbn,
            //String maeukeNoFrom,
            //String maeukeNoTo,
            string rendoKbn,
            string maeukeNo,
            bool uriageDtUse,
            string uriageDtFrom,
            string uriageDtTo,
            bool kyoseiUriage,
            // 2014/11/10 DatNT v1.02 MOD End
            String furikomininNm,
            bool nyukinDtUse,
            String nyukinDtFrom,
            String nyukinDtTo)
        {
            //SqlCommand command = CreateSqlCommand(saibanKbn, maeukeNoFrom, maeukeNoTo, furikomininNm, nyukinDtUse, nyukinDtFrom, nyukinDtTo);

            SqlCommand command = CreateSqlCommand(  rendoKbn, 
                                                    maeukeNo,
                                                    uriageDtUse, 
                                                    uriageDtFrom, 
                                                    uriageDtTo,
                                                    kyoseiUriage,
                                                    furikomininNm, 
                                                    nyukinDtUse, 
                                                    nyukinDtFrom, 
                                                    nyukinDtTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            MaeukekinTblDataSet.MaeukekinTblKensakuDataTable dataTable = new MaeukekinTblDataSet.MaeukekinTblKensakuDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateHokenjoMstKensakuSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rendoKbn"></param>
        /// <param name="maeukeNo"></param>
        /// <param name="uriageDtUse"></param>
        /// <param name="uriageDtFrom"></param>
        /// <param name="uriageDtTo"></param>
        /// <param name="kyoseiUriage"></param>
        /// <param name="furikomininNm"></param>
        /// <param name="nyukinDtUse"></param>
        /// <param name="nyukinDtFrom"></param>
        /// <param name="nyukinDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// 2014/11/10  DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            // 2014/11/10 DatNT v1.02 MOD Start
            //String saibanKbn,
            //String maeukeNoFrom,
            //String maeukeNoTo,
            string rendoKbn,
            string maeukeNo,
            bool uriageDtUse,
            string uriageDtFrom,
            string uriageDtTo,
            bool kyoseiUriage,
            // 2014/11/10 DatNT v1.02 MOD End
            String furikomininNm,
            bool nyukinDtUse,
            String nyukinDtFrom,
            String nyukinDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            // 20150107 habu 件数制限を追加
            sqlContent.Append("TOP 2000                                                                                                 ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinSyogoNo1,                                                                     ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinSyogoNo2,                                                                     ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinNyukinDt,                                                                     ");
            
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(MaeukekinTbl.MaeukekinNyukinDt, '') = '' THEN ''                                    ");
            sqlContent.Append("         ELSE CONCAT(                                                                                    ");
            sqlContent.Append("                 SUBSTRING(MaeukekinTbl.MaeukekinNyukinDt,0,5), '/',                                     ");
            sqlContent.Append("                 SUBSTRING(MaeukekinTbl.MaeukekinNyukinDt,5,2), '/',                                     ");
            sqlContent.Append("                 SUBSTRING(MaeukekinTbl.MaeukekinNyukinDt,7,2)) END AS MaeukekinNyukinDtCol,             ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinNyukinAmt,                                                                    ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinFurikomininNm,                                                                ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinFurikomininKana,                                                              ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinBiko,                                                                         ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinUriageDt,                                                                     ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(MaeukekinTbl.MaeukekinUriageDt, '') = '' THEN ''                                    ");
            sqlContent.Append("         ELSE CONCAT(                                                                                    ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinUriageDt,0,5), '/',                                         ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinUriageDt,5,2), '/',                                         ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinUriageDt,7,2)) END AS MaeukekinUriageDtCol,                 ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinTorisageDt,                                                                   ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(MaeukekinTbl.MaeukekinTorisageDt, '') = '' THEN ''                                  ");
            sqlContent.Append("         ELSE CONCAT(                                                                                    ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinTorisageDt,0,5), '/',                                       ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinTorisageDt,5,2), '/',                                       ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinTorisageDt,7,2)) END AS MaeukekinTorisageDtCol,             ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinKensaIraiHoteiKbn,                                                            ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinKensaIraiHokenjoCd,                                                           ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinKensaIraiNendo,                                                               ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinKensaIraiRenban,                                                              ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinKyoseiUriageAmt,                                                              ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinKyoseiUriageFlg,                                                              ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinNyukintoriatukaiDt,                                                           ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(MaeukekinTbl.MaeukekinNyukintoriatukaiDt, '') = '' THEN ''                          ");
            sqlContent.Append("         ELSE CONCAT(                                                                                    ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinNyukintoriatukaiDt,0,5), '/',                               ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinNyukintoriatukaiDt,5,2), '/',                               ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinNyukintoriatukaiDt,7,2)) END AS MaeukekinNyukintoriatukaiDtCol, ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinIchibuHenkinDt,                                                               ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN ISNULL(MaeukekinTbl.MaeukekinIchibuHenkinDt, '') = '' THEN ''                              ");
            sqlContent.Append("         ELSE CONCAT(                                                                                    ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinIchibuHenkinDt,0,5), '/',                                   ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinIchibuHenkinDt,5,2), '/',                                   ");
            sqlContent.Append("             SUBSTRING(MaeukekinTbl.MaeukekinIchibuHenkinDt,7,2)) END AS MaeukekinIchibuHenkinDtCol,     ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinIchibuHenkinAmt,                                                              ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinZanAmt,                                                                       ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinJokasoHokenjoCd,                                                              ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinJokasoTorokuNendo,                                                            ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinJokasoRenban,                                                                 ");
            //sqlContent.Append("     NameMst.Name                                                                                        ");
            sqlContent.Append("     ConstMst.ConstValue AS Name                                                                         ");

            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     MaeukekinTbl                                                                                        ");
            // 2014/11/10 DatNT v1.02 MOD Start
            //sqlContent.Append("INNER JOIN                                                                                               ");
            //sqlContent.Append("     ConstMst                                                                                            ");
            //sqlContent.Append("         ON ConstMst.NameCd = MaeukekinTbl.MaeukekinKinyukikan                                           ");
            //sqlContent.Append("         AND ConstMst.ConstValue = '002'                                                                 ");
            //sqlContent.Append("     NameMst                                                                                             ");
            //sqlContent.Append("         ON NameMst.NameCd = MaeukekinTbl.MaeukekinKinyukikan                                            ");
            //sqlContent.Append("         AND NameMst.NameKbn = '006'                                                                     ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                          ");
            sqlContent.Append("     ConstMst                                                                                            ");
            sqlContent.Append("         ON ConstMst.ConstRenban = MaeukekinTbl.MaeukekinKinyukikan                                      ");
            sqlContent.Append("         AND ConstMst.ConstKbn = '002'                                                                   ");
            // 2014/11/10 DatNT v1.02 MOD End

            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 2014/11/10 DatNT v1.02 MOD Start

            //if (!string.IsNullOrEmpty(saibanKbn))
            //{
            //    if (saibanKbn == "0")
            //    {
            //        sqlContent.Append(" AND MaeukekinSyogoNo1 = '0'                                                                     ");
            //    }
            //    else if (saibanKbn == "1")
            //    {
            //        sqlContent.Append(" AND MaeukekinSyogoNo1 = '1'                                                                     ");
            //    }
            //}

            //sqlContent.Append("AND MaeukekinTbl.MaeukekinSyogoNo2 " + DataAccessUtility.SetBetweenCommand(maeukeNoFrom, maeukeNoTo, 6));

            //if (!String.IsNullOrEmpty(furikomininNm))
            //{
            //    sqlContent.Append("AND MaeukekinTbl.MaeukekinFurikomininNm LIKE CONCAT('%', @furikomininNm, '%')     ");
            //    commandParams.Add("@furikomininNm", SqlDbType.NVarChar).Value = furikomininNm;
            //}

            if (rendoKbn == "0")
            {
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiHoteiKbn, '') = ''                                              ");
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiHokenjoCd, '') = ''                                             ");
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiNendo, '') = ''                                                 ");
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiRenban, '') = ''                                                ");
            }
            else if (rendoKbn == "1")
            {
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiHoteiKbn, '') <> ''                                             ");
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiHokenjoCd, '') <> ''                                            ");
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiNendo, '') <> ''                                                ");
                sqlContent.Append("AND ISNULL(MaeukekinKensaIraiRenban, '') <> ''                                               ");
            }

            if (!string.IsNullOrEmpty(maeukeNo))
            {
                sqlContent.Append("AND MaeukekinTbl.MaeukekinSyogoNo2 = @maeukeNo                                               ");
                commandParams.Add("@maeukeNo", SqlDbType.NVarChar).Value = maeukeNo;
            }

            if (!String.IsNullOrEmpty(furikomininNm))
            {
                sqlContent.Append("AND (MaeukekinTbl.MaeukekinFurikomininNm LIKE CONCAT('%', @furikomininNm, '%') OR MaeukekinTbl.MaeukekinFurikomininKana LIKE CONCAT('%', @furikomininNm, '%') )   ");
                commandParams.Add("@furikomininNm", SqlDbType.NVarChar).Value = furikomininNm;
            }

            // 売上日検索使用フラグ
            if (uriageDtUse)
            {
                sqlContent.Append("AND MaeukekinTbl.MaeukekinUriageDt >= @uriageDtFrom AND MaeukekinTbl.MaeukekinUriageDt <= @uriageDtTo ");
                commandParams.Add("@uriageDtFrom", SqlDbType.NVarChar).Value = uriageDtFrom;
                commandParams.Add("@uriageDtTo", SqlDbType.NVarChar).Value = uriageDtTo;
            }

            // 強制売上のみフラグ
            if (kyoseiUriage)
            {
                sqlContent.Append("AND MaeukekinTbl.MaeukekinKyoseiUriageFlg = '1' ");
            }

            // 2014/11/10 DatNT v1.02 MOD End

            if (nyukinDtUse)
            {
                sqlContent.Append("AND MaeukekinTbl.MaeukekinNyukinDt >= CAST(@nyukinDtFrom AS INT) AND MaeukekinTbl.MaeukekinNyukinDt <= CAST(@nyukinDtTo AS INT) ");
                commandParams.Add("@nyukinDtFrom", SqlDbType.NVarChar).Value = nyukinDtFrom;
                commandParams.Add("@nyukinDtTo", SqlDbType.NVarChar).Value = nyukinDtTo;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinSyogoNo1,                                                             ");
            sqlContent.Append("     MaeukekinTbl.MaeukekinSyogoNo2                                                              ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
