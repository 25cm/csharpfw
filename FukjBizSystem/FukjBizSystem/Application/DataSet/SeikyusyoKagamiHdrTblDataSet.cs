using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet {
    
    public partial class SeikyusyoKagamiHdrTblDataSet {
    }

    public class SeikyushoKagamiHdrSearchCond
    {
        /// <summary>
        /// 入金No
        /// </summary>
        public string NyukinNo { get; set; }

        /// <summary>
        /// 請求No 
        /// </summary>
        public string SeikyuNo { get; set; }

        /// <summary>
        /// 業者コード 
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度 
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string JokasoRenban { get; set; }
    }
}

namespace FukjBizSystem.Application.DataSet.SeikyusyoKagamiHdrTblDataSetTableAdapters
{
    #region SeikyushoKagamiHdrInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyushoKagamiHdrInfoTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SeikyushoKagamiHdrInfoTableAdapter 
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
        /// 2014/11/13　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable GetDataBySearchCond(SeikyushoKagamiHdrSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable dataTable = new SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable();
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
        /// 2014/11/13　HuyTX　　新規作成
        /// 2015/01/07　kiyokuni　浄化槽番号取得を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(SeikyushoKagamiHdrSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder subSearchBySeikyuNo = new StringBuilder();
            StringBuilder subSearchByGyosha = new StringBuilder();
            StringBuilder subSearchByJokaso = new StringBuilder();

            #region sub query search by SeikyuNo

            //SELECT
            subSearchBySeikyuNo.Append(" SELECT                                                                                 ");
            subSearchBySeikyuNo.Append(" 		skht.OyaSeikyuNo,                                                               ");
            subSearchBySeikyuNo.Append(" 		skht.SeikyusakiKbn,                                                             ");
            subSearchBySeikyuNo.Append(" 		skht.IkkatsuSeikyuSakiCd,                                                       ");
            subSearchBySeikyuNo.Append(" 		gm.GyoshaNm,                                                                    ");
            subSearchBySeikyuNo.Append(" 		jdm.JokasoSetchishaNm,                                                          ");
            subSearchBySeikyuNo.Append(" 		skht.SeikyusakiNm,                                                              ");
            //20141219 HuyTX Mod 
            //subSearchBySeikyuNo.Append("		kkt.KurikoshiKin, ");
            subSearchBySeikyuNo.Append("		SUM(kkt.KurikoshiKin) AS KurikoshiKin,                                          ");
            //End
            subSearchBySeikyuNo.Append("		(SELECT ");
            subSearchBySeikyuNo.Append("				SUM(SeikyuKingakuKei)                                                   ");
            subSearchBySeikyuNo.Append("		FROM SeikyuDtlTbl                                                               ");
            subSearchBySeikyuNo.Append("		INNER JOIN SeikyuHdrTbl ON SeikyuHdrTbl.SeikyuNo = SeikyuDtlTbl.SeikyuNo        ");
            //20141219 Del
            //subSearchBySeikyuNo.Append("		INNER JOIN SeikyushoKagamiHdrTbl                                                ");
            //subSearchBySeikyuNo.Append("		                ON SeikyushoKagamiHdrTbl.OyaSeikyuNo = SeikyuHdrTbl.OyaSeikyuNo ");
            //End
            subSearchBySeikyuNo.Append("		WHERE SeikyuDtlTbl.SeikyuKomokuKbn = '9' AND SeikyuDtlTbl.SeikyuKingakuKei < 0  ");
            //subSearchBySeikyuNo.Append("		        AND SeikyushoKagamiHdrTbl.OyaSeikyuNo = @seikyuNo                       ");
            subSearchBySeikyuNo.Append("		        AND SeikyuHdrTbl.OyaSeikyuNo = @seikyuNo                                ");
            subSearchBySeikyuNo.Append("		) AS TotalSeikyuKingakuKeiNeg                                                   ");
            //2015.01.07 add kiyokuni start
            subSearchBySeikyuNo.Append(" 		,skht.JokasoHokenjoCd                                                           ");
            subSearchBySeikyuNo.Append(" 		,skht.JokasoTorokuNendo                                                         ");
            subSearchBySeikyuNo.Append(" 		,skht.JokasoRenban                                                              ");
            //2015.01.07 add kiyokuni end
            //FROM
            subSearchBySeikyuNo.Append(" FROM SeikyushoKagamiHdrTbl skht                                                        ");
            subSearchBySeikyuNo.Append(" LEFT OUTER JOIN GyoshaMst gm ON skht.IkkatsuSeikyuSakiCd = gm.GyoshaCd                 ");
            subSearchBySeikyuNo.Append(" LEFT OUTER JOIN JokasoDaichoMst jdm ON skht.JokasoHokenjoCd = jdm.JokasoHokenjoCd      ");
            subSearchBySeikyuNo.Append(" 									AND skht.JokasoTorokuNendo = jdm.JokasoTorokuNendo  ");
            subSearchBySeikyuNo.Append(" 									AND skht.JokasoRenban = jdm.JokasoRenban            ");
            ////20141219 HuyTX Mod 
            //subSearchBySeikyuNo.Append(" LEFT OUTER JOIN KurikoshiKinTbl kkt ON kkt.GyosyaCd = skht.IkkatsuSeikyuSakiCd         ");
            //subSearchBySeikyuNo.Append(" 									AND kkt.JokasoHokenjoCd = skht.JokasoHokenjoCd      ");
            //subSearchBySeikyuNo.Append(" 									AND kkt.JokasoTorokuNendo = skht.JokasoTorokuNendo  ");
            //subSearchBySeikyuNo.Append(" 									AND kkt.JokasoRenban = skht.JokasoRenban            ");
            subSearchBySeikyuNo.Append(" LEFT OUTER JOIN KurikoshiKinTbl kkt                                                    ");
            subSearchBySeikyuNo.Append(" 				ON (skht.IkkatsuSeikyuSakiCd = kkt.GyosyaCd AND skht.SeikyusakiKbn = '1' AND kkt.GyosyaKojinKbn = '1') ");
            subSearchBySeikyuNo.Append(" 				OR (skht.JokasoHokenjoCd = kkt.JokasoHokenjoCd                          ");
            subSearchBySeikyuNo.Append(" 					AND skht.JokasoTorokuNendo = kkt.JokasoTorokuNendo                  ");
            subSearchBySeikyuNo.Append(" 					AND skht.JokasoRenban = kkt.JokasoRenban                            ");
            subSearchBySeikyuNo.Append(" 					AND skht.SeikyusakiKbn = '2'                                        ");
            subSearchBySeikyuNo.Append(" 					AND kkt.GyosyaKojinKbn = '2')                                       ");
            //End
            //WHERE
            subSearchBySeikyuNo.Append(" WHERE skht.OyaSeikyuNo = @seikyuNo                                                     ");
            //20141219 Add
            subSearchBySeikyuNo.Append(" GROUP BY skht.OyaSeikyuNo,                                                             ");
		    subSearchBySeikyuNo.Append(" skht.SeikyusakiKbn,                                                                    ");
		    subSearchBySeikyuNo.Append(" skht.IkkatsuSeikyuSakiCd,                                                              ");
		    subSearchBySeikyuNo.Append(" gm.GyoshaNm,                                                                           ");
		    subSearchBySeikyuNo.Append(" jdm.JokasoSetchishaNm,                                                                 ");
		    subSearchBySeikyuNo.Append(" skht.SeikyusakiNm                                                                      ");
            //End

            #endregion

            #region sub query seach by Gyosha
            
            //SELECT
            subSearchByGyosha.Append(" SELECT TOP(1)                                                                        ");
            subSearchByGyosha.Append(" 		skht.OyaSeikyuNo,                                                               ");
            subSearchByGyosha.Append(" 		skht.SeikyusakiKbn,                                                             ");
            subSearchByGyosha.Append(" 		skht.IkkatsuSeikyuSakiCd,                                                       ");
            subSearchByGyosha.Append(" 		gm.GyoshaNm,                                                                    ");
            subSearchByGyosha.Append(" 		'' AS JokasoSetchishaNm,                                                        ");
            subSearchByGyosha.Append(" 		skht.SeikyusakiNm,                                                              ");
            //subSearchByGyosha.Append("		kkt.KurikoshiKin,                                                               ");
            subSearchByGyosha.Append(" 		SUM(kkt.KurikoshiKin) AS KurikoshiKin,                                          ");
            subSearchByGyosha.Append("		(SELECT                                                                         ");
            subSearchByGyosha.Append("				SUM(SeikyuKingakuKei)                                                   ");
            subSearchByGyosha.Append("		FROM SeikyuDtlTbl                                                               ");
            subSearchByGyosha.Append("		INNER JOIN SeikyuHdrTbl ON SeikyuHdrTbl.SeikyuNo = SeikyuDtlTbl.SeikyuNo        ");
            subSearchByGyosha.Append("		INNER JOIN SeikyushoKagamiHdrTbl                                                ");
            subSearchByGyosha.Append("		                ON SeikyushoKagamiHdrTbl.OyaSeikyuNo = SeikyuHdrTbl.OyaSeikyuNo ");
            subSearchByGyosha.Append("		WHERE SeikyuDtlTbl.SeikyuKomokuKbn = '9' AND SeikyuDtlTbl.SeikyuKingakuKei < 0  ");
            subSearchByGyosha.Append("		        AND SeikyushoKagamiHdrTbl.IkkatsuSeikyuSakiCd = @gyoshaCd               ");
            subSearchByGyosha.Append("		) AS TotalSeikyuKingakuKeiNeg                                                   ");
            //2015.01.07 add kiyokuni start
            subSearchBySeikyuNo.Append(" 		,skht.JokasoHokenjoCd                                                           ");
            subSearchBySeikyuNo.Append(" 		,skht.JokasoTorokuNendo                                                         ");
            subSearchBySeikyuNo.Append(" 		,skht.JokasoRenban                                                              ");
            //2015.01.07 add kiyokuni end
            //FROM
            subSearchByGyosha.Append(" FROM SeikyushoKagamiHdrTbl skht                                                      ");
            subSearchByGyosha.Append(" LEFT OUTER JOIN GyoshaMst gm ON skht.IkkatsuSeikyuSakiCd = gm.GyoshaCd               ");
            //20141219 Mod Start
            //subSearchByGyosha.Append(" LEFT OUTER JOIN KurikoshiKinTbl kkt ON kkt.GyosyaCd = skht.IkkatsuSeikyuSakiCd       ");
            //subSearchByGyosha.Append(" 									AND kkt.JokasoHokenjoCd = skht.JokasoHokenjoCd      ");
            //subSearchByGyosha.Append(" 									AND kkt.JokasoTorokuNendo = skht.JokasoTorokuNendo  ");
            //subSearchByGyosha.Append(" 									AND kkt.JokasoRenban = skht.JokasoRenban            ");
            subSearchByGyosha.Append(" LEFT OUTER JOIN KurikoshiKinTbl kkt ON skht.IkkatsuSeikyuSakiCd = kkt.GyosyaCd       ");
            subSearchByGyosha.Append(" 									AND kkt.GyosyaKojinKbn = '1'                        ");
            //End
            //WHERE
            subSearchByGyosha.Append(" WHERE skht.IkkatsuSeikyuSakiCd = @gyoshaCd                                           ");
            //20141219 Add
            subSearchByGyosha.Append(" GROUP BY skht.OyaSeikyuNo,                                                           ");
            subSearchByGyosha.Append("          skht.SeikyusakiKbn,                                                         ");
            subSearchByGyosha.Append("          skht.IkkatsuSeikyuSakiCd,                                                   ");
            subSearchByGyosha.Append("          gm.GyoshaNm,                                                                ");
            subSearchByGyosha.Append("          skht.SeikyusakiNm                                                           ");
            //End

            #endregion

            #region sub query search by Jokaso

            //SELECT
            subSearchByJokaso.Append(" SELECT TOP(1)                                                                        ");
            subSearchByJokaso.Append(" 		skht.OyaSeikyuNo,                                                               ");
            subSearchByJokaso.Append(" 		skht.SeikyusakiKbn,                                                             ");
            subSearchByJokaso.Append(" 		skht.IkkatsuSeikyuSakiCd,                                                       ");
            subSearchByJokaso.Append(" 		'' AS GyoshaNm,                                                                 ");
            subSearchByJokaso.Append(" 		jdm.JokasoSetchishaNm,                                                          ");
            subSearchByJokaso.Append(" 		skht.SeikyusakiNm,                                                              ");
            //subSearchByJokaso.Append("		kkt.KurikoshiKin,                                                               ");
            subSearchByJokaso.Append(" 		SUM(kkt.KurikoshiKin) AS KurikoshiKin,                                          ");
            subSearchByJokaso.Append("		(SELECT                                                                         ");
            subSearchByJokaso.Append("				SUM(SeikyuKingakuKei)                                                   ");
            subSearchByJokaso.Append("		FROM SeikyuDtlTbl                                                               ");
            subSearchByJokaso.Append("		INNER JOIN SeikyuHdrTbl ON SeikyuHdrTbl.SeikyuNo = SeikyuDtlTbl.SeikyuNo        ");
            subSearchByJokaso.Append("		INNER JOIN SeikyushoKagamiHdrTbl                                                ");
            subSearchByJokaso.Append("		                ON SeikyushoKagamiHdrTbl.OyaSeikyuNo = SeikyuHdrTbl.OyaSeikyuNo ");
            subSearchByJokaso.Append("		WHERE SeikyuDtlTbl.SeikyuKomokuKbn = '9' AND SeikyuDtlTbl.SeikyuKingakuKei < 0  ");
            subSearchByJokaso.Append("              AND SeikyushoKagamiHdrTbl.JokasoHokenjoCd = @jokasoHokenjoCd            ");
            subSearchByJokaso.Append(" 		        AND SeikyushoKagamiHdrTbl.JokasoTorokuNendo = @jokasoTorokuNendo        ");
            subSearchByJokaso.Append(" 		        AND SeikyushoKagamiHdrTbl.JokasoRenban = @jokasoRenban                  ");
            subSearchByJokaso.Append("		) AS TotalSeikyuKingakuKeiNeg                                                   ");
            //2015.01.07 add kiyokuni start
            subSearchBySeikyuNo.Append(" 		,skht.JokasoHokenjoCd                                                           ");
            subSearchBySeikyuNo.Append(" 		,skht.JokasoTorokuNendo                                                         ");
            subSearchBySeikyuNo.Append(" 		,skht.JokasoRenban                                                              ");
            //2015.01.07 add kiyokuni end
            //FROM
            subSearchByJokaso.Append(" FROM SeikyushoKagamiHdrTbl skht                                                      ");
            subSearchByJokaso.Append(" LEFT OUTER JOIN JokasoDaichoMst jdm ON skht.JokasoHokenjoCd = jdm.JokasoHokenjoCd    ");
            subSearchByJokaso.Append(" 									AND skht.JokasoTorokuNendo = jdm.JokasoTorokuNendo  ");
            subSearchByJokaso.Append(" 									AND skht.JokasoRenban = jdm.JokasoRenban            ");
            //20141219 Mod Start
            //subSearchByJokaso.Append(" LEFT OUTER JOIN KurikoshiKinTbl kkt ON kkt.GyosyaCd = skht.IkkatsuSeikyuSakiCd       ");
            //subSearchByJokaso.Append(" 									AND kkt.JokasoHokenjoCd = skht.JokasoHokenjoCd      ");
            //subSearchByJokaso.Append(" 									AND kkt.JokasoTorokuNendo = skht.JokasoTorokuNendo  ");
            //subSearchByJokaso.Append(" 									AND kkt.JokasoRenban = skht.JokasoRenban            ");
            subSearchByJokaso.Append(" LEFT OUTER JOIN KurikoshiKinTbl kkt ON skht.JokasoHokenjoCd = kkt.JokasoHokenjoCd    ");
            subSearchByJokaso.Append(" 									AND skht.JokasoTorokuNendo = kkt.JokasoTorokuNendo  ");
            subSearchByJokaso.Append(" 									AND skht.JokasoRenban = kkt.JokasoRenban            ");
            subSearchByJokaso.Append(" 									AND kkt.GyosyaKojinKbn = '2'                        ");
            //End
            //WHERE
            subSearchByJokaso.Append(" WHERE skht.JokasoHokenjoCd = @jokasoHokenjoCd                                        ");
            subSearchByJokaso.Append(" 		AND skht.JokasoTorokuNendo = @jokasoTorokuNendo                                 ");
            subSearchByJokaso.Append(" 		AND skht.JokasoRenban = @jokasoRenban                                           ");
            //20141219 Add
            subSearchByJokaso.Append("             GROUP BY skht.OyaSeikyuNo,                                               ");
            subSearchByJokaso.Append(" 		               skht.SeikyusakiKbn,                                              ");
            subSearchByJokaso.Append(" 		               skht.IkkatsuSeikyuSakiCd,                                        ");
            subSearchByJokaso.Append(" 		               jdm.JokasoSetchishaNm,                                           ");
            subSearchByJokaso.Append(" 		               skht.SeikyusakiNm                                                ");
            //End

            #endregion

            if (!string.IsNullOrEmpty(searchCond.SeikyuNo))
            {
                commandParams.Add("@seikyuNo", SqlDbType.NVarChar).Value = searchCond.SeikyuNo;
                command.CommandText = subSearchBySeikyuNo.ToString();
            }
            else if (!string.IsNullOrEmpty(searchCond.GyoshaCd))
            {
                commandParams.Add("@gyoshaCd", SqlDbType.NVarChar).Value = searchCond.GyoshaCd;
                command.CommandText = subSearchByGyosha.ToString();
            }
            else if (!string.IsNullOrEmpty(searchCond.JokasoHokenjoCd))
            {
                commandParams.Add("@jokasoHokenjoCd", SqlDbType.NVarChar).Value = searchCond.JokasoHokenjoCd;
                commandParams.Add("@jokasoTorokuNendo", SqlDbType.NVarChar).Value = searchCond.JokasoTorokuNendo;
                commandParams.Add("@jokasoRenban", SqlDbType.NVarChar).Value = searchCond.JokasoRenban;
                command.CommandText = subSearchByJokaso.ToString();
            }

            return command;
        }
        #endregion
    }
    #endregion
}
