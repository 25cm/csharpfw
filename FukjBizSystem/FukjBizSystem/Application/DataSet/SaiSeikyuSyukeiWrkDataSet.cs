using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSetTableAdapters;
namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class SaiSeikyuSyukeiWrkDataSet {
        partial class SaiseiKyuShoDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.SaiSeikyuSyukeiWrkDataSetTableAdapters
{
    #region SaiSeikyuSyukeiWrkTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaiSeikyuSyukeiWrkTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/20　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaiSeikyuSyukeiWrkTableAdapter
    {
        #region InsertSaiSeikyuStep2
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： InsertSaiSeikyuStep2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void InsertSaiSeikyuStep2(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommandStep2(searchCond);
            command.Connection = this.Connection;
            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandStep2
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommandStep2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandStep2(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            ZandakaListKensakuTableAdapter zanAdt = new ZandakaListKensakuTableAdapter();

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.Append(" INSERT INTO SaiSeikyuSyukeiWrk ");
            sqlContent.Append(" 			(SeikyusakiKbn, ");
            sqlContent.Append(" 			SeikyuGyosyaCd, ");
            sqlContent.Append(" 			JokasoHokenjoCd, ");
            sqlContent.Append(" 			JokasoTorokuNendo, ");
            sqlContent.Append(" 			JokasoRenban, ");
            sqlContent.Append(" 			SeikyuYM, ");
            sqlContent.Append(" 			GyoshaNm, ");
            sqlContent.Append(" 			InsertDt, ");
            sqlContent.Append(" 			InsertUser, ");
            sqlContent.Append(" 			InsertTarm, ");
            sqlContent.Append(" 			UpdateDt, ");
            sqlContent.Append(" 			UpdateUser, ");
            sqlContent.Append(" 			UpdateTarm) ");

            sqlContent.Append(" SELECT  ");
            sqlContent.Append(" 		Tbl.SeikyusakiKbn, ");
            sqlContent.Append(" 		Tbl.IkkatsuSeikyuSakiCd, ");
            sqlContent.Append(" 		Tbl.JokasoHokenjoCd, ");
            sqlContent.Append(" 		Tbl.JokasoTorokuNendo, ");
            sqlContent.Append(" 		Tbl.JokasoRenban, ");
            sqlContent.Append(" 		Tbl.SeikyuNenGetsu AS SeikyuYM, ");
            sqlContent.Append(" 		MAX(Tbl.SeikyusakiNm) AS GyoshaNm, ");
            sqlContent.AppendFormat(" '{0}' AS InsertDt, ", searchCond.InsertDt);
            sqlContent.AppendFormat(" '{0}' AS InsertUser, ", searchCond.InsertUser);
            sqlContent.AppendFormat(" '{0}' AS InsertTarm, ", searchCond.InsertTarm);
            sqlContent.AppendFormat(" '{0}' AS UpdateDt, ", searchCond.InsertDt);
            sqlContent.AppendFormat(" '{0}' AS UpdateUser, ", searchCond.InsertUser);
            sqlContent.AppendFormat(" '{0}' AS UpdateTarm", searchCond.InsertTarm);

            sqlContent.Append(" FROM ");

            sqlContent.Append(zanAdt.SelectSeikyusyoQuery(searchCond) + "Tbl");
            sqlContent.Append(GroupByQuery());

            command.CommandText = sqlContent.ToString();
            return command;
        }
        #endregion

        #region UpdateSaiSeikyuStep3
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： UpdateSaiSeikyuStep3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateSaiSeikyuStep3(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommandStep3(searchCond);
            command.Connection = this.Connection;
            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandStep3
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommandStep3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandStep3(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            ZandakaListKensakuTableAdapter zanAdt = new ZandakaListKensakuTableAdapter();

            StringBuilder sqlContent = new StringBuilder();

            //UPDATE
            sqlContent.Append(" UPDATE SaiSeikyuSyukeiWrk ");
            sqlContent.Append(" SET SaiSeikyuSyukeiWrk.Kensa11Suishitsu = Tbl1.Kensa11Suishitsu ");
            sqlContent.Append(" FROM SaiSeikyuSyukeiWrk ");
            //JOIN
            sqlContent.Append(" INNER JOIN ");
            sqlContent.Append(" (SELECT  ");
            sqlContent.Append(" 		Tbl.SeikyusakiKbn, ");
            sqlContent.Append(" 		Tbl.IkkatsuSeikyuSakiCd, ");
            sqlContent.Append(" 		Tbl.JokasoHokenjoCd, ");
            sqlContent.Append(" 		Tbl.JokasoTorokuNendo, ");
            sqlContent.Append(" 		Tbl.JokasoRenban, ");
            sqlContent.Append(" 		Tbl.SeikyuNenGetsu, ");
            sqlContent.Append(" 		SUM(Tbl.SeikyuKingakuKei - Tbl.NyukinTotal) AS Kensa11Suishitsu ");
            sqlContent.Append(" FROM ");
            sqlContent.Append(zanAdt.SelectSeikyusyoQuery(searchCond) + "Tbl");
            sqlContent.Append(" WHERE Tbl.SeikyuKomokuKbn = '1' ");
	        sqlContent.Append(" AND Tbl.KensaIraiHoteiKbn = '3' ");
            sqlContent.Append(GroupByQuery());
            sqlContent.Append(" ) Tbl1 ");
            //ON
            sqlContent.Append(" 		ON SaiSeikyuSyukeiWrk.SeikyusakiKbn = Tbl1.SeikyusakiKbn ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuGyosyaCd = Tbl1.IkkatsuSeikyuSakiCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoHokenjoCd = Tbl1.JokasoHokenjoCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoTorokuNendo = Tbl1.JokasoTorokuNendo ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoRenban = Tbl1.JokasoRenban ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuYM = Tbl1.SeikyuNenGetsu ");

            command.CommandText = sqlContent.ToString();
            return command;
        }
        #endregion

        #region UpdateSaiSeikyuStep4
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： UpdateSaiSeikyuStep4
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateSaiSeikyuStep4(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommandStep4(searchCond);
            command.Connection = this.Connection;
            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandStep4
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommandStep4
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandStep4(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            ZandakaListKensakuTableAdapter zanAdt = new ZandakaListKensakuTableAdapter();

            StringBuilder sqlContent = new StringBuilder();

            //UPDATE
            sqlContent.Append(" UPDATE SaiSeikyuSyukeiWrk ");
            sqlContent.Append(" SET SaiSeikyuSyukeiWrk.Kensa11Gaikan = Tbl1.Kensa11Gaikan ");
            sqlContent.Append(" FROM SaiSeikyuSyukeiWrk ");
            //JOIN
            sqlContent.Append(" INNER JOIN ");
            sqlContent.Append(" (SELECT  ");
            sqlContent.Append(" 		Tbl.SeikyusakiKbn, ");
            sqlContent.Append(" 		Tbl.IkkatsuSeikyuSakiCd, ");
            sqlContent.Append(" 		Tbl.JokasoHokenjoCd, ");
            sqlContent.Append(" 		Tbl.JokasoTorokuNendo, ");
            sqlContent.Append(" 		Tbl.JokasoRenban, ");
            sqlContent.Append(" 		Tbl.SeikyuNenGetsu, ");
            sqlContent.Append(" 		SUM(Tbl.SeikyuKingakuKei - Tbl.NyukinTotal) AS Kensa11Gaikan ");
            sqlContent.Append(" FROM ");
            sqlContent.Append(zanAdt.SelectSeikyusyoQuery(searchCond) + "Tbl");
            sqlContent.Append(" WHERE Tbl.SeikyuKomokuKbn = '1' ");
            sqlContent.Append(" AND Tbl.KensaIraiHoteiKbn = '2' ");
            sqlContent.Append(GroupByQuery());
            sqlContent.Append(" ) Tbl1 ");
            //ON
            sqlContent.Append(" 		ON SaiSeikyuSyukeiWrk.SeikyusakiKbn = Tbl1.SeikyusakiKbn ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuGyosyaCd = Tbl1.IkkatsuSeikyuSakiCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoHokenjoCd = Tbl1.JokasoHokenjoCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoTorokuNendo = Tbl1.JokasoTorokuNendo ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoRenban = Tbl1.JokasoRenban ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuYM = Tbl1.SeikyuNenGetsu ");

            command.CommandText = sqlContent.ToString();
            return command;
        }
        #endregion

        #region UpdateSaiSeikyuStep5
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： UpdateSaiSeikyuStep5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateSaiSeikyuStep5(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommandStep5(searchCond);
            command.Connection = this.Connection;
            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandStep5
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommandStep5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandStep5(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            ZandakaListKensakuTableAdapter zanAdt = new ZandakaListKensakuTableAdapter();

            StringBuilder sqlContent = new StringBuilder();

            //UPDATE
            sqlContent.Append(" UPDATE SaiSeikyuSyukeiWrk ");
            sqlContent.Append(" SET SaiSeikyuSyukeiWrk.KeiryoShomei = Tbl1.KeiryoShomei ");
            sqlContent.Append(" FROM SaiSeikyuSyukeiWrk ");
            //JOIN
            sqlContent.Append(" INNER JOIN ");
            sqlContent.Append(" (SELECT  ");
            sqlContent.Append(" 		Tbl.SeikyusakiKbn, ");
            sqlContent.Append(" 		Tbl.IkkatsuSeikyuSakiCd, ");
            sqlContent.Append(" 		Tbl.JokasoHokenjoCd, ");
            sqlContent.Append(" 		Tbl.JokasoTorokuNendo, ");
            sqlContent.Append(" 		Tbl.JokasoRenban, ");
            sqlContent.Append(" 		Tbl.SeikyuNenGetsu, ");
            sqlContent.Append(" 		SUM(Tbl.SeikyuKingakuKei - Tbl.NyukinTotal) AS KeiryoShomei ");
            sqlContent.Append(" FROM ");
            sqlContent.Append(zanAdt.SelectSeikyusyoQuery(searchCond) + "Tbl");
            sqlContent.Append(" WHERE Tbl.SeikyuKomokuKbn = '2' ");
            sqlContent.Append(GroupByQuery());
            sqlContent.Append(" ) Tbl1 ");
            //ON
            sqlContent.Append(" 		ON SaiSeikyuSyukeiWrk.SeikyusakiKbn = Tbl1.SeikyusakiKbn ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuGyosyaCd = Tbl1.IkkatsuSeikyuSakiCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoHokenjoCd = Tbl1.JokasoHokenjoCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoTorokuNendo = Tbl1.JokasoTorokuNendo ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoRenban = Tbl1.JokasoRenban ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuYM = Tbl1.SeikyuNenGetsu ");

            command.CommandText = sqlContent.ToString();
            return command;
        }
        #endregion

        #region UpdateSaiSeikyuStep6
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： UpdateSaiSeikyuStep6
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateSaiSeikyuStep6(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommandStep6(searchCond);
            command.Connection = this.Connection;
            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandStep6
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommandStep6
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandStep6(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            ZandakaListKensakuTableAdapter zanAdt = new ZandakaListKensakuTableAdapter();

            StringBuilder sqlContent = new StringBuilder();

            //UPDATE
            sqlContent.Append(" UPDATE SaiSeikyuSyukeiWrk ");
            sqlContent.Append(" SET SaiSeikyuSyukeiWrk.YoshiHanbai = Tbl1.YoshiHanbai ");
            sqlContent.Append(" FROM SaiSeikyuSyukeiWrk ");
            //JOIN
            sqlContent.Append(" INNER JOIN ");
            sqlContent.Append(" (SELECT  ");
            sqlContent.Append(" 		Tbl.SeikyusakiKbn, ");
            sqlContent.Append(" 		Tbl.IkkatsuSeikyuSakiCd, ");
            sqlContent.Append(" 		Tbl.JokasoHokenjoCd, ");
            sqlContent.Append(" 		Tbl.JokasoTorokuNendo, ");
            sqlContent.Append(" 		Tbl.JokasoRenban, ");
            sqlContent.Append(" 		Tbl.SeikyuNenGetsu, ");
            sqlContent.Append(" 		SUM(Tbl.SeikyuKingakuKei - Tbl.NyukinTotal) AS YoshiHanbai ");
            sqlContent.Append(" FROM ");
            sqlContent.Append(zanAdt.SelectSeikyusyoQuery(searchCond) + "Tbl");
            sqlContent.Append(" WHERE Tbl.SeikyuKomokuKbn = '3' ");
            sqlContent.Append("     OR Tbl.SeikyuKomokuKbn = '4' ");
            sqlContent.Append("     OR Tbl.SeikyuKomokuKbn = '7' ");
            sqlContent.Append(GroupByQuery());
            sqlContent.Append(" ) Tbl1 ");
            //ON
            sqlContent.Append(" 		ON SaiSeikyuSyukeiWrk.SeikyusakiKbn = Tbl1.SeikyusakiKbn ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuGyosyaCd = Tbl1.IkkatsuSeikyuSakiCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoHokenjoCd = Tbl1.JokasoHokenjoCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoTorokuNendo = Tbl1.JokasoTorokuNendo ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoRenban = Tbl1.JokasoRenban ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuYM = Tbl1.SeikyuNenGetsu ");

            command.CommandText = sqlContent.ToString();
            return command;
        }
        #endregion

        #region UpdateSaiSeikyuStep7
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： UpdateSaiSeikyuStep7
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateSaiSeikyuStep7(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommandStep7(searchCond);
            command.Connection = this.Connection;
            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandStep7
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommandStep7
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandStep7(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            ZandakaListKensakuTableAdapter zanAdt = new ZandakaListKensakuTableAdapter();

            StringBuilder sqlContent = new StringBuilder();

            //UPDATE
            sqlContent.Append(" UPDATE SaiSeikyuSyukeiWrk ");
            sqlContent.Append(" SET SaiSeikyuSyukeiWrk.Nenkaihi = Tbl1.Nenkaihi ");
            sqlContent.Append(" FROM SaiSeikyuSyukeiWrk ");
            //JOIN
            sqlContent.Append(" INNER JOIN ");
            sqlContent.Append(" (SELECT  ");
            sqlContent.Append(" 		Tbl.SeikyusakiKbn, ");
            sqlContent.Append(" 		Tbl.IkkatsuSeikyuSakiCd, ");
            sqlContent.Append(" 		Tbl.JokasoHokenjoCd, ");
            sqlContent.Append(" 		Tbl.JokasoTorokuNendo, ");
            sqlContent.Append(" 		Tbl.JokasoRenban, ");
            sqlContent.Append(" 		Tbl.SeikyuNenGetsu, ");
            sqlContent.Append(" 		SUM(Tbl.SeikyuKingakuKei - Tbl.NyukinTotal) AS Nenkaihi ");
            sqlContent.Append(" FROM ");
            sqlContent.Append(zanAdt.SelectSeikyusyoQuery(searchCond) + "Tbl");
            sqlContent.Append(" WHERE Tbl.SeikyuKomokuKbn = '5' ");
            sqlContent.Append(GroupByQuery());
            sqlContent.Append(" ) Tbl1 ");
            //ON
            sqlContent.Append(" 		ON SaiSeikyuSyukeiWrk.SeikyusakiKbn = Tbl1.SeikyusakiKbn ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuGyosyaCd = Tbl1.IkkatsuSeikyuSakiCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoHokenjoCd = Tbl1.JokasoHokenjoCd ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoTorokuNendo = Tbl1.JokasoTorokuNendo ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.JokasoRenban = Tbl1.JokasoRenban ");
            sqlContent.Append(" 		AND SaiSeikyuSyukeiWrk.SeikyuYM = Tbl1.SeikyuNenGetsu ");

            command.CommandText = sqlContent.ToString();
            return command;
        }
        #endregion

        #region UpdateSeikyuHdrStep8
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： UpdateSeikyuHdrStep8
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateSeikyuHdrStep8(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommandStep8(searchCond);
            command.Connection = this.Connection;
            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandStep8
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommandStep8
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandStep8(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            ZandakaListKensakuTableAdapter zanAdt = new ZandakaListKensakuTableAdapter();

            StringBuilder sqlContent = new StringBuilder();

            //UPDATE
            sqlContent.Append(" UPDATE SeikyuHdrTbl ");
            sqlContent.Append(" SET     SeikyuHdrTbl.SaiseikyuCnt = SeikyuHdrTbl.SaiseikyuCnt + 1, ");
            sqlContent.Append(" 	    SeikyuHdrTbl.SaiseikyuDt = CONVERT(VARCHAR(8), GETDATE(), 112), ");
            sqlContent.AppendFormat(" 	SeikyuHdrTbl.UpdateDt = '{0}', ", searchCond.InsertDt);
            sqlContent.AppendFormat(" 	SeikyuHdrTbl.UpdateUser = '{0}', ", searchCond.InsertUser);
            sqlContent.AppendFormat(" 	SeikyuHdrTbl.UpdateTarm = '{0}' ", searchCond.InsertTarm);
            sqlContent.Append(" FROM SeikyuHdrTbl ");

            //JOIN
            sqlContent.Append(" INNER JOIN ");
            sqlContent.Append(" (SELECT  ");
            sqlContent.Append(" 		Tbl.SeikyuNo ");
            sqlContent.Append(" FROM ");
            sqlContent.Append(zanAdt.SelectSeikyusyoQuery(searchCond) + "Tbl GROUP BY Tbl.SeikyuNo");
            sqlContent.Append(" ) Tbl1 ");
            //ON
            sqlContent.Append(" ON SeikyuHdrTbl.SeikyuNo = Tbl1.SeikyuNo ");

            command.CommandText = sqlContent.ToString();
            return command;
        }
        #endregion

        #region GroupByQuery
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GroupByQuery
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GroupByQuery()
        {
            StringBuilder sqlGroup = new StringBuilder();
            
            sqlGroup.Append(" GROUP BY ");
            sqlGroup.Append(" Tbl.SeikyusakiKbn, ");
            sqlGroup.Append(" Tbl.IkkatsuSeikyuSakiCd, ");
            sqlGroup.Append(" Tbl.JokasoHokenjoCd, ");
            sqlGroup.Append(" Tbl.JokasoTorokuNendo, ");
            sqlGroup.Append(" Tbl.JokasoRenban, ");
            sqlGroup.Append(" Tbl.SeikyuNenGetsu ");

            return sqlGroup.ToString();
        }
        #endregion
    }
    #endregion
}
