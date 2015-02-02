using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class NippoDtlTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.NippoDtlTblDataSetTableAdapters
{
    #region KensaNippoPrintInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaNippoPrintInfoTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaNippoPrintInfoTableAdapter {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nippoKensaDt"></param>
        /// <param name="nippoKensainCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal NippoDtlTblDataSet.KensaNippoPrintInfoDataTable GetDataBySearchCond(string nippoKensaDt, string nippoKensainCd)
        {
            SqlCommand command = CreateSqlCommand(nippoKensaDt, nippoKensainCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            NippoDtlTblDataSet.KensaNippoPrintInfoDataTable dataTable = new NippoDtlTblDataSet.KensaNippoPrintInfoDataTable();
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
        /// <param name="nippoKensaDt"></param>
        /// <param name="nippoKensainCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　HuyTX　　新規作成
        /// 2014/11/06　HuyTX　　Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string nippoKensaDt, string nippoKensainCd)
        {
			// Remain: 本来ならば"xxxxByM"を"xxxxByNendo"に変えるべきだが、修正対象が多いので意味は違うが、そのままにしておきます。
			DateTime nendoDt;
			String nendoStr = String.Empty;
			if (DateTime.TryParse(
							nippoKensaDt.Substring(0, 4) + "/" +
							nippoKensaDt.Substring(4, 2) + "/" +
							nippoKensaDt.Substring(6, 2),
							out nendoDt
						 ))
			{
				nendoStr = Utility.DateUtility.GetNendo(nendoDt).ToString();
			}


            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append(" SELECT  DISTINCT                                                                                                                                    ");
            sqlContent.Append(" 		nht.NippoKensainCd,                                                                                                                         ");
            sqlContent.Append(" 		sho1.ShokuinShozokuShishoCd,                                                                                                                ");
            sqlContent.Append(" 		shi.ShishoNm,                                                                                                                               ");
            sqlContent.Append(" 		CASE                                                                                                                                        ");
            sqlContent.Append(" 			WHEN ISDATE(nht.NippoKensaDt) = 0 THEN ''                                                                                               ");
            sqlContent.Append(" 			ELSE CONVERT(CHAR(10), CONVERT(DATETIME,nht.NippoKensaDt), 111)                                                                         ");
            sqlContent.Append(" 		END AS NippoKensaDt,                                                                                                                        ");
            sqlContent.Append(" 		nht.NippoKensaDt AS OrginalNippoKensaDt,                                                                                                    ");
            sqlContent.Append(" 		ndt.NippoDtlKensainCd,                                                                                                                      ");
            sqlContent.Append(" 		sho2.ShokuinNm AS NippoDtlKensainNm,                                                                                                        ");
            sqlContent.Append(" 		ndt.NippoDtlHojoinCd,                                                                                                                       ");
            sqlContent.Append(" 		sho3.ShokuinNm AS NippoDtlHojoinCdNm,                                                                                                       ");
            sqlContent.Append(" 		ndt.NippoDtlKensaSyubetsu,                                                                                                                  ");
            // 20150107 habu スクリーニングの場合はスクリーニング区分を出力
            sqlContent.Append(" 		case when kit.KensaIraiScreeningKbn = '0' then const1.ConstNm else const4.ConstNm end AS NippoDtlKensaSyubetsuValue,                        ");
            //sqlContent.Append(" 		const1.ConstNm AS NippoDtlKensaSyubetsuValue,                                                                                               ");
            sqlContent.Append(" 		cm.ChikuRyakusho,                                                                                                                           ");
            sqlContent.Append(" 		kit.KensaIraiSuishitsuIraiNo,                                                                                                               ");
            sqlContent.Append(" 		kit.KensaIraiSetchishaNm,                                                                                                                   ");
            sqlContent.Append(" 		kit.KensaIraiShorihoshikiKbn,                                                                                                               ");
            sqlContent.Append(" 		const2.ConstNm AS KensaIraiShorihoshikiKbnValue,                                                                                            ");
            sqlContent.Append(" 		kit.KensaIraiShoritaishoJinin,                                                                                                              ");
            sqlContent.Append(" 		kit.KensaIraiNyukinHohoKbn,                                                                                                                 ");
            sqlContent.Append(" 		const3.ConstNm AS KensaIraiNyukinHohoKbnValue,                                                                                              ");
            sqlContent.Append(" 		kit.KensaIraiIkkatsuSeikyusakiCd,                                                                                                           ");
            sqlContent.Append(" 		gm.GyoshaNm,                                                                                                                                ");
            sqlContent.Append(" 		hdrTbl1.CntHdrByYM,                                                                                                                         ");
            sqlContent.Append(" 		hdrTbl2.Cnt1,                                                                                                                               ");
            sqlContent.Append(" 		CONVERT(decimal,hdrTbl2.Cnt1) / CONVERT(decimal, hdrTbl2.Cnt2) AS NippoHdrAvg,                                                              ");
            sqlContent.Append(" 		dtlTbl1.CntDtlByYM,                                                                                                                         ");
            sqlContent.Append(" 		dtlTbl2.CntDtlByM,                                                                                                                          ");
            sqlContent.Append(" 		nht.NippoSokoKyori,                                                                                                                         ");
            sqlContent.Append(" 		hdrTbl1.CntNippoSokoKyoriByYM,                                                                                                              ");
            sqlContent.Append(" 		hdrTbl2.CntNippoSokoKyoriByM,                                                                                                               ");
            sqlContent.Append(" 		nht.NippoKyuyu,                                                                                                                             ");
            sqlContent.Append(" 		hdrTbl1.CntNippoKyuyuByYM,                                                                                                                  ");
            sqlContent.Append(" 		hdrTbl2.CntNippoKyuyuByM,                                                                                                                   ");
            sqlContent.Append(" 		nht.NippoCrosscheckKensu,                                                                                                                   ");
            sqlContent.Append(" 		nht.NippoJitchichosaKensu,                                                                                                                  ");
            sqlContent.Append(" 		nht.NippoChokageninchosaKensu,                                                                                                              ");
            sqlContent.Append(" 		nht.NippoSharyoTenkenKiroku,                                                                                                                ");
            sqlContent.Append(" 		ndt.NippoDtlKensaChushiRiyu,                                                                                                                ");
            sqlContent.Append(" 		nht.NippoHokokujiko,                                                                                                                        ");
            sqlContent.Append(" 		nht.NippoShijinaiyo,                                                                                                                        ");
            sqlContent.Append(" 		nht.NippoFukukachoCheckFlg,                                                                                                                 ");
            sqlContent.Append(" 		CASE                                                                                                                                        ");
            sqlContent.Append(" 			WHEN nht.NippoFukukachoCheckFlg = '1' THEN '済'                                                                                         ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                 ");
            sqlContent.Append(" 		END AS NippoFukukachoCheckFlgValue,                                                                                                         ");
            sqlContent.Append(" 		nht.NippoKachoCheckFlg,                                                                                                                     ");
            sqlContent.Append(" 		CASE                                                                                                                                        ");
            sqlContent.Append(" 			WHEN nht.NippoKachoCheckFlg = '1' THEN '済'                                                                                             ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                 ");
            sqlContent.Append(" 		END AS NippoKachoCheckFlgValue,                                                                                                             ");
            sqlContent.Append(" 		ndt.NippoDtlKensaChushiFlg,                                                                                                                 ");
            //ADD_Ver1.03 Start
	        sqlContent.Append(" 		ndt.NippoDtlKensaIraiHokenjoCd,                                                                                                             ");
            sqlContent.Append(" 		ndt.NippoDtlKensaIraiNendo,                                                                                                                 ");
            sqlContent.Append(" 		ndt.NippoDtlKensaIraiRenban,                                                                                                                ");
            sqlContent.Append(" 		ndt.NippoDtlRenban,                                                                                                                         ");
            sqlContent.Append(" 		kkt.KensaKekkaKensaTimes,                                                                                                                   ");
            sqlContent.Append(" 		CASE                                                                                                                                        ");
            sqlContent.Append(" 			WHEN kkt.KensaKekkaZaitakuUmu = '1' THEN '○'                                                                                            ");
            sqlContent.Append(" 			WHEN kkt.KensaKekkaZaitakuUmu = '0' THEN '×'                                                                                            ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                 ");
            sqlContent.Append(" 		END AS KensaKekkaZaitakuUmu,                                                                                                                ");
            sqlContent.Append(" 		skt1.KensaIraiShokanIraiHoteiKbn AS ShokenIraiHoteiKbn1,                                                                                    ");
            sqlContent.Append(" 		skt2.KensaIraiShokanIraiHoteiKbn AS ShokenIraiHoteiKbn2,                                                                                    ");
            sqlContent.Append(" 		(SELECT                                                                                                                                     ");
            sqlContent.Append(" 		CONVERT(DECIMAL, SUM(KensaKekkaTbl.KensaKekkaKensaTimes)) / 60                                                                              ");
            sqlContent.Append(" 		FROM NippoDtlTbl                                                                                                                            ");
		    sqlContent.Append(" 		LEFT OUTER JOIN KensaKekkaTbl ON NippoDtlTbl.NippoDtlKensaSyubetsu = KensaKekkaTbl.KensaKekkaIraiHoteiKbn                                   ");
		    sqlContent.Append(" 											AND NippoDtlTbl.NippoDtlKensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd                      ");
		    sqlContent.Append(" 											AND NippoDtlTbl.NippoDtlKensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo                              ");
		    sqlContent.Append(" 											AND NippoDtlTbl.NippoDtlKensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban                            ");
		    sqlContent.Append(" 		WHERE NippoDtlTbl.NippoDtlKensaDt = @nippoKensaDt                                                                                           ");
		    sqlContent.Append(" 		GROUP BY NippoDtlTbl.NippoDtlKensaDt) AS KensaKekkaKensaTimesByKensaDt,                                                                     ");
		    sqlContent.Append(" 		(SELECT                                                                                                                                     ");
		    sqlContent.Append(" 		CONVERT(DECIMAL, SUM(KensaKekkaTbl.KensaKekkaKensaTimes)) / 60                                                                              ");
		    sqlContent.Append(" 		FROM NippoDtlTbl                                                                                                                            ");
		    sqlContent.Append(" 		LEFT OUTER JOIN KensaKekkaTbl ON NippoDtlTbl.NippoDtlKensaSyubetsu = KensaKekkaTbl.KensaKekkaIraiHoteiKbn                                   ");
		    sqlContent.Append(" 											AND NippoDtlTbl.NippoDtlKensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd                      ");
		    sqlContent.Append(" 											AND NippoDtlTbl.NippoDtlKensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo                              ");
		    sqlContent.Append(" 											AND NippoDtlTbl.NippoDtlKensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban                            ");
		    sqlContent.Append(" 		WHERE NippoDtlTbl.NippoDtlKensainCd = @nippoKensainCd                                                                                       ");
			sqlContent.Append(" 		AND SUBSTRING(NippoDtlKensaDt, 1, 6) BETWEEN CONCAT(SUBSTRING('" + nendoStr + "', 1, 4), '04') AND SUBSTRING (@nippoKensaDt, 1, 6)          ");
			sqlContent.Append(" 		AND NippoDtlKensaDt <= @nippoKensaDt                                                                                                        ");
			sqlContent.Append(" 		GROUP BY NippoDtlTbl.NippoDtlKensainCd) AS KensaKekkaKensaTimesByKensainCd                                                                  ");
            //ADD_Ver1.03 End

            //FROM
            sqlContent.Append(" FROM NippoDtlTbl ndt                                                                                                                                ");

            //JOIN
            sqlContent.Append(" FULL OUTER JOIN NippoHdrTbl nht ON ndt.NippoDtlKensaDt = nht.NippoKensaDt                                                                                ");
            sqlContent.Append(" 								AND ndt.NippoDtlKensainCd = nht.NippoKensainCd                                                                      ");

            sqlContent.Append(" LEFT OUTER JOIN ShokuinMst sho1 ON sho1.ShokuinCd = nht.NippoKensainCd                                                                              ");

            sqlContent.Append(" LEFT OUTER JOIN ShishoMst shi ON shi.ShishoCd = sho1.ShokuinShozokuShishoCd                                                                         ");

            sqlContent.Append(" LEFT OUTER JOIN ShokuinMst sho2 ON sho2.ShokuinCd = ndt.NippoDtlKensainCd                                                                           ");

            sqlContent.Append(" LEFT OUTER JOIN ShokuinMst sho3 ON sho3.ShokuinCd = ndt.NippoDtlHojoinCd                                                                            ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const1 ON const1.ConstValue = ndt.NippoDtlKensaSyubetsu                                                                    ");
            sqlContent.Append(" 								AND const1.ConstKbn = '006'                                                                                         ");

            sqlContent.Append(" LEFT OUTER JOIN KensaIraiTbl kit ON kit.KensaIraiHoteiKbn = ndt.NippoDtlKensaSyubetsu                                                               ");
            sqlContent.Append(" 								AND kit.KensaIraiHokenjoCd = ndt.NippoDtlKensaIraiHokenjoCd                                                         ");
            sqlContent.Append(" 								AND kit.KensaIraiNendo = ndt.NippoDtlKensaIraiNendo                                                                 ");
            sqlContent.Append(" 								AND kit.KensaIraiRenban = ndt.NippoDtlKensaIraiRenban                                                               ");

            sqlContent.Append(" LEFT OUTER JOIN ChikuMst cm ON cm.ChikuCd = kit.KensaIraiGenChikuCd                                                                            ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const2 ON const2.ConstValue = kit.KensaIraiShorihoshikiKbn                                                                 ");
            sqlContent.Append(" 								AND const2.ConstKbn = '022'                                                                                         ");

			//受入20141218
			//sqlContent.Append(" LEFT OUTER JOIN ConstMst const3 ON const3.ConstValue = kit.KensaIraiNyukinHohoKbn                                                                   ");
			sqlContent.Append(" LEFT OUTER JOIN ConstMst const3 ON const3.ConstRenban = kit.KensaIraiNyukinHohoKbn                                                                   ");
            sqlContent.Append(" 								AND const3.ConstKbn = '021'                                                                                         ");
            // 20150107 habu
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const4 ON const4.ConstValue = kit.KensaIraiScreeningKbn                                                                   ");
            sqlContent.Append(" 								AND const4.ConstKbn = '024'                                                                                         ");

            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst gm ON gm.GyoshaCd = kit.KensaIraiIkkatsuSeikyusakiCd                                                                      ");

            sqlContent.Append(" LEFT OUTER JOIN (SELECT                                                                                                                             ");
            sqlContent.Append(" 					NippoKensainCd,                                                                                                                 ");
            sqlContent.Append(" 					COUNT(*) AS CntHdrByYM,                                                                                                         ");
            sqlContent.Append(" 					SUM(NippoSokoKyori) AS CntNippoSokoKyoriByYM,                                                                                   ");
            sqlContent.Append(" 					SUM(NippoKyuyu) AS CntNippoKyuyuByYM                                                                                            ");
            sqlContent.Append(" 					FROM NippoHdrTbl                                                                                                                ");
            sqlContent.Append(" 					WHERE SUBSTRING(NippoKensaDt, 1, 6) = SUBSTRING(@nippoKensaDt, 1, 6)                                                            ");
			sqlContent.Append(" 					AND NippoKensaDt <= @nippoKensaDt                                                                                               ");
			sqlContent.Append(" 					GROUP BY NippoKensainCd                                                                                                         ");
            sqlContent.Append(" 					) hdrTbl1                                                                                                                       ");
            sqlContent.Append(" 					ON hdrTbl1.NippoKensainCd = nht.NippoKensainCd                                                                                  ");
					
            sqlContent.Append(" LEFT OUTER JOIN (SELECT                                                                                                                             ");
            sqlContent.Append(" 					NippoKensainCd,                                                                                                                 ");
            sqlContent.Append(" 					COUNT(*) AS Cnt1,                                                                                                               ");
            sqlContent.Append(" 					COUNT(DISTINCT SUBSTRING(NippoKensaDt, 5, 2)) AS Cnt2,                                                                          ");
            sqlContent.Append(" 					SUM(NippoSokoKyori) AS CntNippoSokoKyoriByM,                                                                                    ");
            sqlContent.Append(" 					SUM(NippoKyuyu) AS CntNippoKyuyuByM                                                                                             ");
            sqlContent.Append(" 					FROM NippoHdrTbl                                                                                                                ");
			sqlContent.Append(" 					WHERE SUBSTRING(NippoKensaDt, 1, 6) BETWEEN CONCAT(SUBSTRING('" + nendoStr + "', 1, 4), '04') AND SUBSTRING(@nippoKensaDt, 1, 6) ");
			sqlContent.Append(" 					AND NippoKensaDt <= @nippoKensaDt                                                                                               ");
			sqlContent.Append(" 						GROUP BY NippoKensainCd) hdrTbl2                                                                                            ");
            sqlContent.Append(" 					ON hdrTbl2.NippoKensainCd = nht.NippoKensainCd                                                                                  ");

            sqlContent.Append(" LEFT OUTER JOIN (SELECT                                                                                                                             ");
            sqlContent.Append(" 					NippoDtlKensainCd,                                                                                                              ");
            sqlContent.Append(" 					COUNT(*) AS CntDtlByYM                                                                                                          ");
            sqlContent.Append(" 					FROM NippoDtlTbl                                                                                                                ");
            sqlContent.Append(" 					WHERE NippoDtlKensaChushiFlg <> '1'                                                                                             ");
            sqlContent.Append(" 					AND SUBSTRING(NippoDtlKensaDt, 1, 6) = SUBSTRING(@nippoKensaDt, 1, 6)                                                           ");
			sqlContent.Append(" 					AND NippoDtlKensaDt <= @nippoKensaDt                                                                                            ");
			sqlContent.Append(" 					GROUP BY NippoDtlKensainCd                                                                                                      ");
            sqlContent.Append(" 					) dtlTbl1                                                                                                                       ");
            sqlContent.Append(" 					ON dtlTbl1.NippoDtlKensainCd = nht.NippoKensainCd                                                                               ");

            sqlContent.Append(" LEFT OUTER JOIN (SELECT                                                                                                                             ");
            sqlContent.Append(" 					NippoDtlKensainCd,                                                                                                              ");
            sqlContent.Append(" 					COUNT(*) AS CntDtlByM                                                                   ");
            sqlContent.Append(" 					FROM NippoDtlTbl                                                                                                                ");
            sqlContent.Append(" 					WHERE NippoDtlKensaChushiFlg <> '1'                                                                                             ");
			sqlContent.Append(" 					AND SUBSTRING(NippoDtlKensaDt, 1, 6) BETWEEN CONCAT(SUBSTRING('" + nendoStr + "', 1, 4), '04') AND SUBSTRING (@nippoKensaDt, 1, 6) ");
			sqlContent.Append(" 					AND NippoDtlKensaDt <= @nippoKensaDt                                                                                            ");
			sqlContent.Append(" 					GROUP BY NippoDtlKensainCd                                                                                                      ");
            sqlContent.Append(" 					) dtlTbl2                                                                                                                       ");
            sqlContent.Append(" 					ON dtlTbl2.NippoDtlKensainCd = nht.NippoKensainCd                                                                               ");

            //ADD_Ver1.03 Start
            sqlContent.Append(" LEFT OUTER JOIN KensaKekkaTbl kkt ON kkt.KensaKekkaIraiHoteiKbn = ndt.NippoDtlKensaSyubetsu                                                         ");
            sqlContent.Append(" AND kkt.KensaKekkaIraiHokenjoCd = ndt.NippoDtlKensaIraiHokenjoCd                                                                                    ");
            sqlContent.Append(" AND kkt.KensaKekkaIraiNendo = ndt.NippoDtlKensaIraiNendo                                                                                            ");
            sqlContent.Append(" AND kkt.KensaKekkaIraiRenban = ndt.NippoDtlKensaIraiRenban                                                                                          ");

            sqlContent.Append(" LEFT OUTER JOIN ShokenKekkaTbl skt1 ON skt1.KensaIraiShokanIraiHoteiKbn = ndt.NippoDtlKensaSyubetsu                                                 ");
            sqlContent.Append(" 									AND skt1.KensaIraiShokenIraiHokenjoCd = ndt.NippoDtlKensaIraiHokenjoCd                                          ");
            sqlContent.Append(" 									AND skt1.KensaIraiShokenIraiNendo = ndt.NippoDtlKensaIraiNendo                                                  ");
            sqlContent.Append(" 									AND skt1.KensaIraiShokenIraiRenban = ndt.NippoDtlKensaIraiRenban                                                ");
            sqlContent.Append(" 									AND skt1.ShokenSetchishaRenrakuFlg = '1'                                                                        ");

            sqlContent.Append(" LEFT OUTER JOIN ShokenKekkaTbl skt2 ON skt2.KensaIraiShokanIraiHoteiKbn = ndt.NippoDtlKensaSyubetsu                                                 ");
            sqlContent.Append(" 									AND skt2.KensaIraiShokenIraiHokenjoCd = ndt.NippoDtlKensaIraiHokenjoCd                                          ");
            sqlContent.Append(" 									AND skt2.KensaIraiShokenIraiNendo = ndt.NippoDtlKensaIraiNendo                                                  ");
            sqlContent.Append(" 									AND skt2.KensaIraiShokenIraiRenban = ndt.NippoDtlKensaIraiRenban                                                ");
            sqlContent.Append(" 									AND (skt2.ShokenHoshuGyoshaRenrakuFlg = '1' OR skt2.ShokenSeisoGyoshaRenrakuFlg = '1'                           ");
            sqlContent.Append(" 										OR skt2.ShokenKojiGyoshaRenrakuFlg = '1' OR skt2.ShokenMakerRenrakuFlg = '1'                                ");
            sqlContent.Append(" 										OR skt2.ShokenHokenjoRenrakuFlg = '1')                                                                      ");
            //ADD_Ver1.03 End

            //WHERE
            sqlContent.Append(" WHERE nht.NippoKensainCd = @nippoKensainCd AND nht.NippoKensaDt = @nippoKensaDt                                                                     ");

            //ORDER
            sqlContent.Append(" ORDER BY ndt.NippoDtlRenban                                                                                                                         ");

            commandParams.Add("@nippoKensaDt", SqlDbType.NVarChar).Value = nippoKensaDt;
            commandParams.Add("@nippoKensainCd", SqlDbType.NVarChar).Value = nippoKensainCd;

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
