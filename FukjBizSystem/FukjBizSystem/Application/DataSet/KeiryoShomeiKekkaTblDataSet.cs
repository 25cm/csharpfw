using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
    
    public partial class KeiryoShomeiKekkaTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.KeiryoShomeiKekkaTblDataSetTableAdapters
{
    #region KishakuBairitsuShomeiKekkaTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KishakuBairitsuShomeiKekkaTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　豊田   　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KishakuBairitsuShomeiKekkaTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <param name="shikenkoumokuCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable GetDataBySearchCond(KensaIraishoOutputSearchCond searchCond, string shikenkoumokuCd)
        {
            SqlCommand command = CreateSqlCommand(searchCond, shikenkoumokuCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable dataTable = new KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable();
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
        /// <param name="shikenkoumokuCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaIraishoOutputSearchCond searchCond, string shikenkoumokuCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.Append(" SELECT ");
            sqlContent.Append("     A.KeiryoShomeiJokasoDaichoHokenjoCd, ");
            sqlContent.Append("     A.KeiryoShomeiJokasoDaichoNendo, ");
            sqlContent.Append("     A.KeiryoShomeiJokasoDaichoRenban, ");
            sqlContent.Append("     A.KeiryoShomeiIraiUketsukeDt, ");
            sqlContent.Append("     A.KeiryoShomeiKekkaValue, ");
            sqlContent.Append("     A.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append(" FROM ( ");
            sqlContent.Append("     SELECT ");
            sqlContent.Append("         ksit.KeiryoShomeiJokasoDaichoHokenjoCd, ");
            sqlContent.Append("         ksit.KeiryoShomeiJokasoDaichoNendo, ");
            sqlContent.Append("         ksit.KeiryoShomeiJokasoDaichoRenban, ");
            sqlContent.Append("         ksit.KeiryoShomeiIraiUketsukeDt, ");
            sqlContent.Append("         kskt.KeiryoShomeiKekkaValue, ");
            sqlContent.Append("         kskt.KeiryoShomeiShikenkoumokuCd, ");
            sqlContent.Append("         RANK () OVER (PARTITION BY ksit.KeiryoShomeiJokasoDaichoHokenjoCd, ksit.KeiryoShomeiJokasoDaichoNendo, ksit.KeiryoShomeiJokasoDaichoRenban, kskt.KeiryoShomeiShikenkoumokuCd ORDER BY ksit.KeiryoShomeiIraiUketsukeDt DESC, ksit.KeiryoShomeiIraiNendo DESC, ksit.KeiryoShomeiIraiSishoCd DESC, ksit.KeiryoShomeiIraiRenban DESC) AS Rank ");
            sqlContent.Append("     FROM ");
            sqlContent.Append("         KeiryoShomeiIraiTbl ksit ");
            sqlContent.Append("         INNER JOIN  ");
            sqlContent.Append("             ( ");

            #region フィルタリング用

            sqlContent.Append("SELECT TOP 2000 A.JokasoHokenjoCd, A.JokasoTorokuNendo, A.JokasoRenban FROM (");

            #region SELECT
            sqlContent.Append(" SELECT  '1' AS selectCol, ");
            sqlContent.Append(" 		jdm.JokasoHokenjoCd, ");
            sqlContent.Append(" 		jdm.JokasoTorokuNendo, ");
            sqlContent.Append(" 		jdm.JokasoRenban, ");
            sqlContent.Append(" 		CONCAT(jdm.JokasoHokenjoCd, '-',  ");
            sqlContent.Append(" 				[dbo].[FuncConvertIraiNedoToWareki](jdm.JokasoTorokuNendo), '-',  ");
            sqlContent.Append(" 				jdm.JokasoRenban) AS jokasoNoCol, ");
            sqlContent.Append(" 		jdm.JokasoSetchishaNm AS settisyaCol, ");
            sqlContent.Append(" 		jdm.JokasoSetchiBashoAdr AS settiBasyoCol, ");
            sqlContent.Append(" 		jdm.JokasoGenChikuCd, ");
            sqlContent.Append(" 		cm.ChikuNm AS chikuNmCol, ");
            sqlContent.Append(" 		jdm.JokasoGaikanTikuwariKbn AS gaikanChikuCol, ");
            sqlContent.Append(" 		'   ' AS kishakuBairitsuCol, ");
            sqlContent.Append(" 		dskkm.DaichoKensaSetNm AS keiryoShomeiNmCol, ");
            sqlContent.Append(" 		dskkm.DaichoKensaKomokuEdaban AS kensaKomokuEdabanCol, ");
            sqlContent.Append(" 		jdm.JokasoSuisitsuSishoCd ");
            #endregion

            #region FROM
            sqlContent.Append(" FROM JokasoDaichoMst jdm ");
            sqlContent.Append(" LEFT OUTER JOIN ChikuMst cm ON cm.ChikuCd = jdm.JokasoGenChikuCd ");
            sqlContent.Append(" LEFT OUTER JOIN ");
            //sqlContent.Append(" (SELECT TOP(1) ");
            //sqlContent.Append(" DaichoKensaKomokuEdaban, ");
            //sqlContent.Append(" DaichoKensaSetNm, ");
            //sqlContent.Append(" JokasoHokenjoCd, ");
            //sqlContent.Append(" JokasoTorokuNendo, ");
            //sqlContent.Append(" JokasoRenban ");
            //sqlContent.Append(" FROM DaichoSuishitsuKensaKomokuMst ");
            //sqlContent.Append("  ORDER BY DaichoKensaKomokuEdaban ");
            //sqlContent.Append("  ) AS dskkm ON dskkm.JokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            //sqlContent.Append(" 			AND dskkm.JokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            //sqlContent.Append(" 			AND dskkm.JokasoRenban = jdm.JokasoRenban            ");
            sqlContent.Append("(SELECT");
            sqlContent.Append("   MAX(DaichoKensaKomokuEdaban) As DaichoKensaKomokuEdaban, ");
            sqlContent.Append("   JokasoHokenjoCd, ");
            sqlContent.Append("   JokasoTorokuNendo, ");
            sqlContent.Append("   JokasoRenban ");
            sqlContent.Append(" FROM DaichoSuishitsuKensaKomokuMst ");
            sqlContent.Append(" GROUP BY ");
            sqlContent.Append("   JokasoHokenjoCd, ");
            sqlContent.Append("   JokasoTorokuNendo, ");
            sqlContent.Append("   JokasoRenban ");
            sqlContent.Append("  ) AS dskkmmax ON dskkmmax.JokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            sqlContent.Append(" 			  AND dskkmmax.JokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            sqlContent.Append(" 			  AND dskkmmax.JokasoRenban = jdm.JokasoRenban            ");
            sqlContent.Append("LEFT OUTER JOIN");
            sqlContent.Append(" (SELECT ");
            sqlContent.Append(" DaichoKensaKomokuEdaban, ");
            sqlContent.Append(" DaichoKensaSetNm, ");
            sqlContent.Append(" JokasoHokenjoCd, ");
            sqlContent.Append(" JokasoTorokuNendo, ");
            sqlContent.Append(" JokasoRenban ");
            sqlContent.Append(" FROM DaichoSuishitsuKensaKomokuMst ");
            sqlContent.Append("  ) AS dskkm ON dskkm.JokasoHokenjoCd = dskkmmax.JokasoHokenjoCd ");
            sqlContent.Append(" 			AND dskkm.JokasoTorokuNendo = dskkmmax.JokasoTorokuNendo ");
            sqlContent.Append(" 			AND dskkm.JokasoRenban = dskkmmax.JokasoRenban            ");
            sqlContent.Append(" 			AND dskkm.DaichoKensaKomokuEdaban = dskkmmax.DaichoKensaKomokuEdaban ");
            #endregion

            #region WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            //出力依頼書/11条水質
            if (searchCond.Shutsuryoku == "1")
            {
                sqlContent.Append(" AND jdm.JokasoShoriTaishoJinin <= 50  ");
            }

            //外観検査地区
            if (searchCond.GaikanChiku != null && searchCond.GaikanChiku.Count > 0 && searchCond.GaikanChiku.Count < 5)
            {
                string gaikanTikuwariKbn = string.Empty;
                for (int i = 0; i < searchCond.GaikanChiku.Count; i++)
                {
                    gaikanTikuwariKbn += string.Format("'{0}',", searchCond.GaikanChiku[i]);
                }

                sqlContent.Append(" AND jdm.JokasoGaikanTikuwariKbn IN (" + gaikanTikuwariKbn.Remove(gaikanTikuwariKbn.Length - 1) + ")");
            }

            //浄化槽番号（開始） (保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                sqlContent.Append(" AND jdm.JokasoHokenjoCd >= @hokenjoCdFrom");
                commandParams.Add("@hokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }

            //浄化槽番号（開始） (年度)
            if (!string.IsNullOrEmpty(searchCond.NendoFrom))
            {
                sqlContent.Append(" AND jdm.JokasoTorokuNendo >= @nendoFrom");
                commandParams.Add("@nendoFrom", SqlDbType.NVarChar).Value = Utility.DateUtility.ConvertFromWareki(searchCond.NendoFrom, "yyyy");
            }

            //浄化槽番号（開始） (連番)
            if (!string.IsNullOrEmpty(searchCond.RenbanFrom))
            {
                sqlContent.Append(" AND jdm.JokasoRenban >= @renbanFrom");
                commandParams.Add("@renbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;
            }

            //浄化槽番号（終了）(保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                sqlContent.Append(" AND jdm.JokasoHokenjoCd <= @hokenjoCdTo");
                commandParams.Add("@hokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            //浄化槽番号（終了）(年度)
            if (!string.IsNullOrEmpty(searchCond.NendoTo))
            {
                sqlContent.Append(" AND jdm.JokasoTorokuNendo <= @nendoTo");
                commandParams.Add("@nendoTo", SqlDbType.NVarChar).Value = Utility.DateUtility.ConvertFromWareki(searchCond.NendoTo, "yyyy");
            }

            //浄化槽番号（終了）(連番)
            if (!string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append(" AND jdm.JokasoRenban <= @renbanTo");
                commandParams.Add("@renbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }

            //地区コード（開始）
            if (!string.IsNullOrEmpty(searchCond.ChikuCdFrom))
            {
                sqlContent.Append(" AND jdm.JokasoGenChikuCd >= @chikuFrom");
                commandParams.Add("@chikuFrom", SqlDbType.NVarChar).Value = searchCond.ChikuCdFrom;
            }

            //地区コード（終了）
            if (!string.IsNullOrEmpty(searchCond.ChikuCdTo))
            {
                sqlContent.Append(" AND jdm.JokasoGenChikuCd <= @chikuTo");
                commandParams.Add("@chikuTo", SqlDbType.NVarChar).Value = searchCond.ChikuCdTo;
            }

            //設置者
            if (!string.IsNullOrEmpty(searchCond.SetchishaNm))
            {
                sqlContent.Append(" AND jdm.JokasoSetchishaNm LIKE CONCAT('%', @setchishaNm, '%')");
                commandParams.Add("@setchishaNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.SetchishaNm);
            }

            // 2014/12/11 DatNT v1.01 ADD Start
            if (!string.IsNullOrEmpty(searchCond.UketsukeDtFrom) && !string.IsNullOrEmpty(searchCond.UketsukeDtTo))
            {
                if (searchCond.Shutsuryoku == "1")
                {
                    sqlContent.Append(" AND EXISTS                                                                  ");
                    sqlContent.Append("         (   SELECT *                                                        ");
                    sqlContent.Append("             FROM KensaIraiTbl                                               ");
                    sqlContent.Append("             WHERE KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd            ");
                    sqlContent.Append("                   AND KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo    ");
                    sqlContent.Append("                   AND KensaIraiJokasoRenban = jdm.JokasoRenban              ");
                    sqlContent.Append("                   AND KensaIraiSuishitsuUketsukeDt >= @uketsukeDtFrom       ");
                    sqlContent.Append("                   AND KensaIraiSuishitsuUketsukeDt <= @uketsukeDtTo         ");
                    sqlContent.Append("         )                                                                   ");
                }
                else
                {
                    sqlContent.Append(" AND EXISTS                                                                  ");
                    sqlContent.Append("         (   SELECT *                                                        ");
                    sqlContent.Append("             FROM KeiryoShomeiIraiTbl                                        ");
                    sqlContent.Append("             WHERE KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd   ");
                    sqlContent.Append("                   AND KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo ");
                    sqlContent.Append("                   AND KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban     ");
                    sqlContent.Append("                   AND KeiryoShomeiIraiUketsukeDt >= @uketsukeDtFrom         ");
                    sqlContent.Append("                   AND KeiryoShomeiIraiUketsukeDt <= @uketsukeDtTo           ");
                    sqlContent.Append("         )                                                                   ");
                }

                commandParams.Add("@uketsukeDtFrom", SqlDbType.NVarChar).Value = searchCond.UketsukeDtFrom;
                commandParams.Add("@uketsukeDtTo", SqlDbType.NVarChar).Value = searchCond.UketsukeDtTo;
            }
            // 2014/12/11 DatNT v1.01 ADD End

            #endregion

            sqlContent.Append(") As A");

            sqlContent.Append(" ORDER BY ");
            sqlContent.Append(" 		A.JokasoHokenjoCd, ");
            sqlContent.Append(" 		A.JokasoTorokuNendo, ");
            sqlContent.Append(" 		A.JokasoRenban ");

            #endregion

            sqlContent.Append("             ) As filtering ");
            sqlContent.Append("         ON  filtering.JokasoHokenjoCd = ksit.KeiryoShomeiJokasoDaichoHokenjoCd ");
            sqlContent.Append("         AND filtering.JokasoTorokuNendo = ksit.KeiryoShomeiJokasoDaichoNendo ");
            sqlContent.Append("         AND filtering.JokasoRenban = ksit.KeiryoShomeiJokasoDaichoRenban ");
            sqlContent.Append("         INNER JOIN ");
            sqlContent.Append("             KeiryoShomeiKekkaTbl kskt ");
            sqlContent.Append("         ON  kskt.KeiryoShomeiKekkaIraiNendo = ksit.KeiryoShomeiIraiNendo ");
            sqlContent.Append("         AND kskt.KeiryoShomeiKekkaIraiShishoCd = ksit.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append("         AND kskt.KeiryoShomeiKekkaIraiNo = ksit.KeiryoShomeiIraiRenban ");
            sqlContent.Append("     WHERE ");
            sqlContent.Append("         ksit.KeiryoShomeiIraiUketsukeDt <> '' ");
            sqlContent.Append("     AND kskt.KeiryoShomeiKekkaValue > 0 ");

            sqlContent.Append("     AND kskt.KeiryoShomeiShikenkoumokuCd = @KeiryoShomeiShikenkoumokuCd ");
            commandParams.Add("@KeiryoShomeiShikenkoumokuCd", SqlDbType.NVarChar).Value = shikenkoumokuCd;

            sqlContent.Append("     ) As A ");
            sqlContent.Append(" WHERE ");
            sqlContent.Append("     A.Rank = 1 ");
            sqlContent.Append(" ORDER BY ");
            sqlContent.Append("     A.KeiryoShomeiJokasoDaichoHokenjoCd, ");
            sqlContent.Append("     A.KeiryoShomeiJokasoDaichoNendo, ");
            sqlContent.Append("     A.KeiryoShomeiJokasoDaichoRenban, ");
            sqlContent.Append("     A.KeiryoShomeiShikenkoumokuCd ");
            
            command.CommandText = sqlContent.ToString();
            // TODO 水質検査依頼書で使用(遅すぎるので、見直し検討)
            return command;
        }
        #endregion
    }
    #endregion
}