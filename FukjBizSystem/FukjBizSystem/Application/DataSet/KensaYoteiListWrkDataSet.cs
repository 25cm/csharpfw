using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet
{
    
    public partial class KensaYoteiListWrkDataSet {
    }

    #region GaikanYoteiListHassoOutputSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaikanYoteiListHassoOutputSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class GaikanYoteiListHassoOutputSearchCond
    {
        /// <summary>
        /// 検査依頼年度 
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 法定請求業者コード  
        /// </summary>
        public string KensaIraiIkkatsuSeikyusakiCd { get; set; }

        /// <summary>
        /// 検査番号（開始） (保健所コード) 
        /// </summary>
        public string HokenjoCdFrom { get; set; }

        /// <summary>
        /// 検査番号（終了） (保健所コード) 
        /// </summary>
        public string HokenjoCdTo { get; set; }

        /// <summary>
        /// 検査番号（開始） (年度) 
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// 検査番号（終了） (年度) 
        /// </summary>
        public string NendoTo { get; set; }

        /// <summary>
        /// 検査番号（開始） (連番) 
        /// </summary>
        public string RenbanFrom { get; set; }

        /// <summary>
        /// 検査番号（終了） (連番) 
        /// </summary>
        public string RenbanTo { get; set; }

        /// <summary>
        /// 支所（開始） 
        /// </summary>
        public string UketsukeShishoKbnFrom { get; set; }

        /// <summary>
        /// 支所（終了） 
        /// </summary>
        public string UketsukeShishoKbnTo { get; set; }

        /// <summary>
        /// 作表対象
        /// </summary>
        public string MakeList { get; set; }

        /// <summary>
        /// 出力順１
        /// </summary>
        public string Sort1 { get; set; }

        /// <summary>
        /// 出力順２
        /// </summary>
        public string Sort2 { get; set; }

        /// <summary>
        /// 印字方法１
        /// </summary>
        public string PrintType1 { get; set; }

        /// <summary>
        /// 印字方法２
        /// </summary>
        public string PrintType2 { get; set; }

    }
    #endregion
}

namespace FukjBizSystem.Application.DataSet.KensaYoteiListWrkDataSetTableAdapters
{

    #region JinendoGaikanYoteiListHassoOutputTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanYoteiListHassoOutputTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JinendoGaikanYoteiListHassoOutputTableAdapter {

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaYoteiListWrkDataSet.JinendoGaikanYoteiListHassoOutputDataTable GetDataBySearchCond(GaikanYoteiListHassoOutputSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaYoteiListWrkDataSet.JinendoGaikanYoteiListHassoOutputDataTable dataTable = new KensaYoteiListWrkDataSet.JinendoGaikanYoteiListHassoOutputDataTable();
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
        /// 2014/09/26　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(GaikanYoteiListHassoOutputSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            StringBuilder sqlSub = new StringBuilder();
            StringBuilder sqlWhere = new StringBuilder();

            #region sub query

            sqlSub.Append(" INNER JOIN (SELECT ");
            sqlSub.Append(" 		jgyot.Nendo, ");
            sqlSub.Append(" 		jgyot.JokasoHokenjoCd, ");
            sqlSub.Append(" 		jgyot.JokasoTorokuNendo, ");
            sqlSub.Append(" 		jgyot.JokasoRenban ");
            sqlSub.Append(" FROM JinendoGaikanYoteiOutputTbl jgyot ");
            sqlSub.Append(" INNER JOIN JokasoDaichoMst jdm1 ON jdm1.JokasoHokenjoCd = jgyot.JokasoHokenjoCd ");
            sqlSub.Append(" 								AND jdm1.JokasoTorokuNendo = jgyot.JokasoTorokuNendo ");
            sqlSub.Append(" 								AND jdm1.JokasoRenban = jgyot.JokasoRenban ");
            sqlSub.Append(" WHERE 1 = 1 ");

            #endregion

            #region make condition 

            //年度
            if (!string.IsNullOrEmpty(searchCond.KensaIraiNendo))
            {
                sqlWhere.Append(" AND kit.KensaIraiNendo = @kensaIraiNendo ");
                sqlSub.Append(" AND jgyot.Nendo = @kensaIraiNendo ");
                commandParams.Add("@kensaIraiNendo", SqlDbType.NVarChar).Value = searchCond.KensaIraiNendo;
            }

            //業者コード
            if (!string.IsNullOrEmpty(searchCond.KensaIraiIkkatsuSeikyusakiCd))
            {
                //sqlWhere.Append(" AND kit.KensaIraiIkkatsuSeikyusakiCd = @gyoshaCd ");
                sqlSub.Append(" AND jgyot.SeikyuGyoshaCd = @gyoshaCd ");
                commandParams.Add("@gyoshaCd", SqlDbType.NVarChar).Value = searchCond.KensaIraiIkkatsuSeikyusakiCd;
            }

            if (searchCond.MakeList == "2")
            {
                sqlWhere.Append(" AND kit.KensaIraiStatusKbn <= 20 ");
            }
            else if (searchCond.MakeList == "3")
            {
                sqlSub.Append(" AND jgyot.IraiMakeKbn = '0' ");
            }

            //保健所コード（開始＆終了）
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                //sqlWhere.Append(" AND kit.KensaIraiHokenjoCd " + DataAccessUtility.SetBetweenCommand(searchCond.HokenjoCdFrom, searchCond.HokenjoCdTo, 2));
                sqlWhere.Append(" AND kit.KensaIraiHokenjoCd >= @HokenjoCdFrom ");
                commandParams.Add("@HokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }
            
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                sqlWhere.Append(" AND kit.KensaIraiHokenjoCd <= @HokenjoCdTo ");
                commandParams.Add("@HokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            //年度（開始＆終了）
            string nendoFrom = !string.IsNullOrEmpty(searchCond.NendoFrom) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoFrom, "yyyy") : string.Empty;
            string nendoTo = !string.IsNullOrEmpty(searchCond.NendoTo) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoTo, "yyyy") : string.Empty;
           
            if (!string.IsNullOrEmpty(searchCond.NendoFrom))
            {
                //sqlWhere.Append(" AND kit.KensaIraiNendo " + DataAccessUtility.SetBetweenCommand(nendoFrom, nendoTo, 4));
                sqlWhere.Append(" AND kit.KensaIraiNendo >= @NendoFrom ");
                commandParams.Add("@NendoFrom", SqlDbType.NVarChar).Value = nendoFrom;
            }

            if (!string.IsNullOrEmpty(searchCond.NendoTo))
            {
                sqlWhere.Append(" AND kit.KensaIraiNendo <= @NendoTo ");
                commandParams.Add("@NendoTo", SqlDbType.NVarChar).Value = nendoTo;
            }

            //連番（開始＆終了）
            if (!string.IsNullOrEmpty(searchCond.RenbanFrom))
            {
                //sqlWhere.Append(" AND kit.KensaIraiRenban " + DataAccessUtility.SetBetweenCommand(searchCond.RenbanFrom, searchCond.RenbanTo, 6));
                sqlWhere.Append(" AND kit.KensaIraiRenban >= @RenbanFrom ");
                commandParams.Add("@RenbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;
            }
            
            if (!string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlWhere.Append(" AND kit.KensaIraiRenban <= @RenbanTo ");
                commandParams.Add("@RenbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }

            //支所（開始＆終了）
            if (!string.IsNullOrEmpty(searchCond.UketsukeShishoKbnFrom))
            {
                //sqlWhere.Append(" AND kit.KensaIraiUketsukeShishoKbn " + DataAccessUtility.SetBetweenCommand(searchCond.UketsukeShishoKbnFrom, searchCond.UketsukeShishoKbnTo, 1));
                sqlWhere.Append(" AND kit.KensaIraiUketsukeShishoKbn >= @UketsukeShishoKbnFrom ");
                commandParams.Add("@UketsukeShishoKbnFrom", SqlDbType.NVarChar).Value = searchCond.UketsukeShishoKbnFrom;
            }
            
            if (!string.IsNullOrEmpty(searchCond.UketsukeShishoKbnTo))
            {
                sqlWhere.Append(" AND kit.KensaIraiUketsukeShishoKbn <= @UketsukeShishoKbnTo ");
                commandParams.Add("@UketsukeShishoKbnTo", SqlDbType.NVarChar).Value = searchCond.UketsukeShishoKbnTo;
            }

            //NOT EXISTS条件
            if (searchCond.PrintType2 == "1")
            {
                sqlWhere.Append(" AND CONCAT(kit.KensaIraiJokasoHokenjoCd, kit.KensaIraiJokasoTorokuNendo, kit.KensaIraiJokasoRenban) ");
                sqlWhere.Append(" NOT IN (SELECT DISTINCT CONCAT(KensaIraiTbl.KensaIraiJokasoHokenjoCd, KensaIraiTbl.KensaIraiJokasoTorokuNendo, KensaIraiTbl.KensaIraiJokasoRenban)  ");
                sqlWhere.Append(" FROM KensaIraiTbl  ");
                sqlWhere.Append(" INNER JOIN JokasoDaichoMst ON KensaIraiTbl.KensaIraiJokasoHokenjoCd = JokasoDaichoMst.JokasoHokenjoCd ");
                sqlWhere.Append(" 							AND KensaIraiTbl.KensaIraiJokasoTorokuNendo = JokasoDaichoMst.JokasoTorokuNendo ");
                sqlWhere.Append(" 							AND KensaIraiTbl.KensaIraiJokasoRenban = JokasoDaichoMst.JokasoRenban ");
                sqlWhere.Append(" WHERE KensaIraiTbl.KensaIraiHoteiKbn = '1')                ");
            }

            sqlSub.Append(" ) AS Tbl ON Tbl.JokasoHokenjoCd = kit.KensaIraiJokasoHokenjoCd ");
            sqlSub.Append(" 		AND Tbl.JokasoTorokuNendo = kit.KensaIraiJokasoTorokuNendo ");
            sqlSub.Append(" 		AND Tbl.JokasoRenban = kit.KensaIraiJokasoRenban ");

            #endregion

            //SELECT
            sqlContent.Append(" 		SELECT DISTINCT kit.KensaIraiHoteiKbn, ");
            sqlContent.Append(" 		                kit.KensaIraiHokenjoCd, ");
            sqlContent.Append(" 		                kit.KensaIraiNendo, ");
            sqlContent.Append(" 		                kit.KensaIraiRenban, ");
            sqlContent.Append(" 		                kit.KensaIraiUketsukeShishoKbn, ");           
            sqlContent.Append(" 						jdm.JokasoItkatsuSeikyuGyoshaCd, ");
            sqlContent.Append(" 		                gm.GyoshaNm, ");
            sqlContent.Append(" 		                gm.GyoshaTelNo, ");
            sqlContent.Append(" 		                gm.GyoshaZipCd, ");
            sqlContent.Append(" 		                gm.GyoshaAdr, ");
            sqlContent.Append(" 		                jdm.JokasoGenChikuCd, ");
            sqlContent.Append(" 		                cm.ChikuNm, ");
            sqlContent.Append(" 						jdm.JokasoHokenjoCd, ");
            sqlContent.Append(" 						cm.ChikuTantoTelNo, ");
            sqlContent.Append(" 						cm.ChikuTantoYubinNo, ");
            sqlContent.Append(" 						cm.ChikuTantoAdr, ");
            sqlContent.Append(" 		                kit.KensaIraiKensaYoteiNen, ");
            sqlContent.Append(" 		                kit.KensaIraiKensaYoteiTsuki, ");
            sqlContent.Append(" 		                kit.KensaIraiKensaYoteiBi, ");
            sqlContent.Append(" 		                kit.KensaIraiSetchishaNm, ");
            sqlContent.Append(" 						jdm.JokasoSetchiBashoAdr, ");
            sqlContent.Append(" 		                jdm.JokasoShoriHosikiKbn, ");
            sqlContent.Append(" 		                const.ConstNm, ");
            sqlContent.Append(" 		                jdm.JokasoShoriTaishoJinin, ");
            sqlContent.Append(" 		                jdm.JokasoSetchishaKbn, ");
            sqlContent.Append(" 		                jdm.JokasoSetchishaCd, ");
            sqlContent.Append(" 		                CASE ");
            sqlContent.Append(" 		                    WHEN jdm.JokasoShoriTaishoJinin <= 50 THEN '0' ");
            sqlContent.Append(" 		                    WHEN jdm.JokasoShoriTaishoJinin >= 51 THEN '1' ");
            sqlContent.Append(" 		                    ELSE '' ");
            sqlContent.Append(" 		                END as NinsoKbn, ");
            sqlContent.Append(" 		                kit.KensaIraiJokasoHokenjoCd, ");
            sqlContent.Append(" 		                kit.KensaIraiJokasoTorokuNendo, ");
            sqlContent.Append(" 		                kit.KensaIraiJokasoRenban ");

            //FROM
            sqlContent.Append(" FROM  ");
            sqlContent.Append(" 	KensaIraiTbl kit  ");
            sqlContent.Append(" 	INNER JOIN JokasoDaichoMst jdm  ");
            sqlContent.Append(" 				ON jdm.JokasoHokenjoCd = kit.KensaIraiJokasoHokenjoCd ");
            sqlContent.Append(" 				AND jdm.JokasoTorokuNendo = kit.KensaIraiJokasoTorokuNendo ");
            sqlContent.Append(" 				AND jdm.JokasoRenban = kit.KensaIraiJokasoRenban ");

            //JOIN
            sqlContent.Append(" 	LEFT OUTER JOIN GyoshaMst gm ON gm.GyoshaCd = jdm.JokasoItkatsuSeikyuGyoshaCd ");
            sqlContent.Append(" 	LEFT OUTER JOIN ChikuMst cm ON cm.ChikuCd = jdm.JokasoGenChikuCd AND cm.DelFlg <> '1' ");
            sqlContent.Append(" 	LEFT OUTER JOIN HokenjoMst hm ON hm.HokenjoCd = jdm.JokasoHokenjoCd AND hm.DelFlg <> '1' ");
            sqlContent.Append(" 	LEFT OUTER JOIN ConstMst const ON const.ConstValue = jdm.JokasoShoriHosikiKbn AND const.ConstKbn = '022' ");

            //EXISTS 条件
            sqlContent.Append(sqlSub.ToString());

            //WHERE
            sqlContent.Append(" 	WHERE kit.KensaIraiHoteiKbn = '2' ");
            sqlContent.Append(sqlWhere.ToString());
 
            //ORDER BY
            sqlContent.Append(" 	ORDER BY kit.KensaIraiHoteiKbn, ");
            sqlContent.Append(" 			kit.KensaIraiHokenjoCd, ");
            sqlContent.Append(" 			kit.KensaIraiNendo, ");
            sqlContent.Append(" 			kit.KensaIraiRenban ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

    }
    #endregion
}
