using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet
{


    public partial class SeikyuNyukinTblDataSet
    {
    }
}

namespace FukjBizSystem.Application.DataSet.SeikyuNyukinTblDataSetTableAdapters
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
    public partial class SeikyuNyukinTblListTableAdapter
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
        internal SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable GetDataBySearchCond(SeikyushoKagamiHdrSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable dataTable = new SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable();
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(SeikyushoKagamiHdrSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder subSearchByNyukinNo = new StringBuilder();
            StringBuilder subSearchBySeikyuNo = new StringBuilder();
            StringBuilder subSearchByGyosha = new StringBuilder();
            StringBuilder subSearchByJokaso = new StringBuilder();

            #region sub query search by NyukinNo

            //SELECT
            subSearchByNyukinNo.Append(" SELECT                                                                                         ");
            subSearchByNyukinNo.Append(" 		sht.SeikyusakiNm AS shishosakiNmCol,                                                    ");
            subSearchByNyukinNo.Append(" 		snt.SeikyuNo AS shishoNoCol,                                                            ");
            subSearchByNyukinNo.Append(" 		snt.SeikyuRenban AS renbanCol,                                                          ");
            subSearchByNyukinNo.Append(" 		snt.SeikyuKomokuNm AS seikyuKamokuCol,                                                  ");
            subSearchByNyukinNo.Append(" 		snt.SeikyuSyohinNm AS syohinCol,                                                        ");
            subSearchByNyukinNo.Append(" 		snt.SeikyuKingaku AS seikyuKingakuCol,                                                  ");
            subSearchByNyukinNo.Append(" 		snt.NyukinWarifuriGaku AS nyukinWarifuriCol,                                            ");
            subSearchByNyukinNo.Append(" 		(CONVERT(decimal, snt.SeikyuKingaku) - CONVERT(decimal, snt.NyukinWarifuriGaku)) AS zangakuCol, ");
            subSearchByNyukinNo.Append(" 		sdt.SeikyuKomokuKbn AS seikyuKomokuKbnCol,                                              ");
            subSearchByNyukinNo.Append(" 		sdt.SeikyuKomokuCd AS seikyuKomokuCdCol,                                                ");
            subSearchByNyukinNo.Append(" 		sdt.NyukinTotal AS nyukinTotalCol,                                                      ");
            subSearchByNyukinNo.Append(" 		snt.NyukinWarifuriGaku AS nyukinWarifuriGakuCol,                                        ");
            subSearchByNyukinNo.Append(" 		snt.KaikeiRendoFlg, ");
		    subSearchByNyukinNo.Append(" 		sdt.YoshiHanbaiNo ");

            //FROM
            subSearchByNyukinNo.Append(" FROM SeikyuNyukinTbl snt                                                                       ");
            subSearchByNyukinNo.Append(" LEFT OUTER JOIN SeikyuHdrTbl sht ON sht.SeikyuNo = snt.SeikyuNo                                ");
            subSearchByNyukinNo.Append(" LEFT OUTER JOIN SeikyuDtlTbl sdt ON sdt.SeikyuNo = snt.SeikyuNo                                ");
            subSearchByNyukinNo.Append(" 									AND sdt.SeikyuRenban = snt.SeikyuRenban                     ");
            //WHERE
            subSearchByNyukinNo.Append(" WHERE snt.NyukinNo = @nyukinNo                                                                 ");
            //ORDER
            subSearchByNyukinNo.Append(" ORDER BY snt.SeikyuNo, snt.SeikyuRenban                                                        ");

            #endregion

            #region sub query search by SeikyuNo

            //SELECT
            subSearchBySeikyuNo.Append(" SELECT	                                                              ");
            subSearchBySeikyuNo.Append("        sht.SeikyusakiNm AS shishosakiNmCol,                          ");
            subSearchBySeikyuNo.Append(" 		sdt.SeikyuNo AS shishoNoCol,                                  ");
            subSearchBySeikyuNo.Append(" 		sdt.SeikyuRenban AS renbanCol,                                ");
            subSearchBySeikyuNo.Append(" 		sdt.SeikyuKomokuNm AS seikyuKamokuCol,                        ");
            subSearchBySeikyuNo.Append(" 		sdt.SeikyuSyohinNm AS syohinCol,                              ");
            subSearchBySeikyuNo.Append(" 		CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS seikyuKingakuCol,   ");
            subSearchBySeikyuNo.Append(" 		0 AS nyukinWarifuriCol,                                       ");
            subSearchBySeikyuNo.Append(" 		CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS zangakuCol,         ");
            //subSearchBySeikyuNo.Append(" 		CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS nyukinWarifuriCol,   ");
            //subSearchBySeikyuNo.Append(" 		0 AS zangakuCol,                                              ");
            subSearchBySeikyuNo.Append(" 		sdt.SeikyuKomokuKbn AS seikyuKomokuKbnCol,                    ");
            subSearchBySeikyuNo.Append(" 		sdt.SeikyuKomokuCd AS seikyuKomokuCdCol,                      ");
            subSearchBySeikyuNo.Append(" 		sdt.NyukinTotal AS nyukinTotalCol,                            ");
            subSearchBySeikyuNo.Append(" 		0 AS nyukinWarifuriGakuCol,                                   ");
            subSearchBySeikyuNo.Append(" 		'' KaikeiRendoFlg,                                            ");
            subSearchBySeikyuNo.Append(" 		sdt.YoshiHanbaiNo                                             ");

            //FROM
            subSearchBySeikyuNo.Append(" FROM SeikyuDtlTbl sdt                                                ");
            subSearchBySeikyuNo.Append(" INNER JOIN SeikyuHdrTbl sht ON sht.SeikyuNo = sdt.SeikyuNo           ");
            //WHERE
            subSearchBySeikyuNo.Append(" WHERE sdt.SeikyuKingakuKei > sdt.NyukinTotal                         ");
            subSearchBySeikyuNo.Append(" 		AND sht.OyaSeikyuNo = @seikyuNo                               ");
            //ORDER
            subSearchBySeikyuNo.Append(" ORDER BY sdt.SeikyuNo, sdt.SeikyuRenban                              ");

            #endregion

            #region sub query seach by Gyosha

            //SELECT
            subSearchByGyosha.Append(" SELECT                                                                       ");
            subSearchByGyosha.Append("        sht.SeikyusakiNm AS shishosakiNmCol,                                  ");
            subSearchByGyosha.Append(" 		  sdt.SeikyuNo AS shishoNoCol,                                          ");
            subSearchByGyosha.Append(" 		  sdt.SeikyuRenban AS renbanCol,                                        ");
            subSearchByGyosha.Append(" 		  sdt.SeikyuKomokuNm AS seikyuKamokuCol,                                ");
            subSearchByGyosha.Append(" 		  sdt.SeikyuSyohinNm AS syohinCol,                                      ");
            subSearchByGyosha.Append(" 		  CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS seikyuKingakuCol,           ");
            subSearchByGyosha.Append(" 		  0 AS nyukinWarifuriCol,                                               ");
            subSearchByGyosha.Append(" 		  CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS zangakuCol,                 ");
            //subSearchByGyosha.Append(" 		  CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS nyukinWarifuriCol, ");
            //subSearchByGyosha.Append(" 		  0 AS zangakuCol,                 ");
            subSearchByGyosha.Append(" 		  sdt.SeikyuKomokuKbn AS seikyuKomokuKbnCol,                            ");
            subSearchByGyosha.Append(" 		  sdt.SeikyuKomokuCd AS seikyuKomokuCdCol,                              ");
            subSearchByGyosha.Append(" 		  sdt.NyukinTotal AS nyukinTotalCol,                                    ");
            subSearchByGyosha.Append(" 		  0 AS nyukinWarifuriGakuCol,                                           ");
            subSearchByGyosha.Append(" 		'' KaikeiRendoFlg,                                            ");
            subSearchByGyosha.Append(" 		sdt.YoshiHanbaiNo                                             ");

            //FROM
            subSearchByGyosha.Append(" FROM SeikyuDtlTbl sdt                                                        ");
            subSearchByGyosha.Append(" INNER JOIN SeikyuHdrTbl sht ON sht.SeikyuNo = sdt.SeikyuNo                   ");
            subSearchByGyosha.Append(" INNER JOIN SeikyushoKagamiHdrTbl skht ON skht.OyaSeikyuNo = sht.OyaSeikyuNo  ");
            //WHERE
            subSearchByGyosha.Append(" WHERE sdt.SeikyuKingakuKei > sdt.NyukinTotal                                 ");
            subSearchByGyosha.Append(" 		AND skht.IkkatsuSeikyuSakiCd = @gyoshaCd                                ");
            //ORDER
            subSearchByGyosha.Append(" ORDER BY sdt.SeikyuNo, sdt.SeikyuRenban                                      ");

            #endregion

            #region sub query search by Jokaso

            //SELECT
            subSearchByJokaso.Append(" SELECT                                                                       ");
            subSearchByJokaso.Append(" 		sht.SeikyusakiNm AS shishosakiNmCol,                                    ");
            subSearchByJokaso.Append(" 		sdt.SeikyuNo AS shishoNoCol,                                            ");
            subSearchByJokaso.Append(" 		sdt.SeikyuRenban AS renbanCol,                                          ");
            subSearchByJokaso.Append(" 		sdt.SeikyuKomokuNm AS seikyuKamokuCol,                                  ");
            subSearchByJokaso.Append(" 		sdt.SeikyuSyohinNm AS syohinCol,                                        ");
            subSearchByJokaso.Append(" 		CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS seikyuKingakuCol, ");
            subSearchByJokaso.Append(" 		0 AS nyukinWarifuriCol,                                                 ");
            subSearchByJokaso.Append(" 		CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS zangakuCol,                   ");
            //subSearchByJokaso.Append(" 		CONVERT(decimal, sdt.SeikyuKingakuKei) - CONVERT(decimal, sdt.NyukinTotal) AS nyukinWarifuriCol, ");
            //subSearchByJokaso.Append(" 		0 AS zangakuCol,                                                        ");
            subSearchByJokaso.Append(" 		sdt.SeikyuKomokuKbn AS seikyuKomokuKbnCol,                              ");
            subSearchByJokaso.Append(" 		sdt.SeikyuKomokuCd AS seikyuKomokuCdCol,                                ");
            subSearchByJokaso.Append(" 		sdt.NyukinTotal AS nyukinTotalCol,                                      ");
            subSearchByJokaso.Append(" 		0 AS nyukinWarifuriGakuCol,                                             ");
            subSearchByJokaso.Append(" 		'' KaikeiRendoFlg,                                            ");
            subSearchByJokaso.Append(" 		sdt.YoshiHanbaiNo                                             ");

            //FROM
            subSearchByJokaso.Append(" FROM SeikyuDtlTbl sdt                                                        ");
            subSearchByJokaso.Append(" INNER JOIN SeikyuHdrTbl sht ON sht.SeikyuNo = sdt.SeikyuNo                   ");
            subSearchByJokaso.Append(" INNER JOIN SeikyushoKagamiHdrTbl skht ON skht.OyaSeikyuNo = sht.OyaSeikyuNo  ");
            //WHERE
            subSearchByJokaso.Append(" WHERE sdt.SeikyuKingakuKei > sdt.NyukinTotal                                 ");
            subSearchByJokaso.Append(" 		AND skht.JokasoHokenjoCd = @jokasoHokenjoCd                             ");
            subSearchByJokaso.Append(" 		AND skht.JokasoTorokuNendo = @jokasoTorokuNendo                         ");
            subSearchByJokaso.Append(" 		AND skht.JokasoRenban = @jokasoRenban                                   ");
            //ORDER
            subSearchByJokaso.Append(" ORDER BY sdt.SeikyuNo, sdt.SeikyuRenban                                      ");

            #endregion

            #region set param value

            if (!string.IsNullOrEmpty(searchCond.NyukinNo))
            {
                commandParams.Add("@nyukinNo", SqlDbType.NVarChar).Value = searchCond.NyukinNo;
                command.CommandText = subSearchByNyukinNo.ToString();
            }
            else if (!string.IsNullOrEmpty(searchCond.SeikyuNo))
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

            #endregion

            return command;
        }
        #endregion
    }
    #endregion
}
