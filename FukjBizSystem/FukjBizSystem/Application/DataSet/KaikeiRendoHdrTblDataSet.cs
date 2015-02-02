using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{
    public partial class KaikeiRendoHdrTblDataSet
    {
    }

    #region KaikeiRendoHdrTblSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaikeiRendoHdrTblSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KaikeiRendoHdrTblSearchCond
    {
        /// <summary>
        /// 売上入金区分 
        /// </summary>
        public string UriageNyukinKbn { get; set; }

        /// <summary>
        /// 支所
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 会計No（開始）
        /// </summary>
        public string KaikeiNoFrom { get; set; }

        /// <summary>
        /// 会計No（終了）
        /// </summary>
        public string KaikeiNoTo { get; set; }

        /// <summary>
        /// 作成区分
        /// </summary>
        public List<string> ListMakeKbn { get; set; }

        /// <summary>
        /// 作成日検索使用フラグ 
        /// </summary>
        public bool MakeDtUse { get; set; }

        /// <summary>
        /// 作成日（開始）
        /// </summary>
        public string MakeDtFrom { get; set; }

        /// <summary>
        /// 作成日（終了）
        /// </summary>
        public string MakeDtTo { get; set; }

        /// <summary>
        /// 承認フラグ 
        /// </summary>
        public List<string> ListSyoninFlg { get; set; }
    }
    #endregion
}

namespace FukjBizSystem.Application.DataSet.KaikeiRendoHdrTblDataSetTableAdapters
{
    #region SuitoSyukeiStdTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuitoSyukeiStdTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/21　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class SuitoSyukeiStdTableAdapter
    {
        #region ExecProcSuitoSyukeiStd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ExecProcSuitoSyukeiStd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TaishoKbn"></param>
        /// <param name="ShishoCd"></param>
        /// <param name="TaisyoFrom"></param>
        /// <param name="TaisyoTo"></param>
        /// <param name="SakuseiTaisho"></param>
        /// <param name="SakuseiHani"></param>
        /// <param name="Wareki"></param>
        /// <param name="LoginUser"></param>
        /// <param name="PcUpdate"></param>
        /// <param name="KaikeiSaibanNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容 
        /// 2014/12/03　DatNT 　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public List<string> ExecProcSuitoSyukeiStd( string TaishoKbn,
                                            string ShishoCd,
                                            string TaisyoFrom,
                                            string TaisyoTo,
                                            string SakuseiTaisho,
                                            string SakuseiHani,
                                            string Wareki,
                                            string LoginUser,
                                            string PcUpdate,
                                            string KaikeiSaibanNo)
        {
            List<string> retList = new List<string>();

            SqlCommand command = new SqlCommand("SuitoSyukeiStd", this.Connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@TaishoKbn", SqlDbType.NVarChar).Value = TaishoKbn;
            command.Parameters.Add("@ShishoCd", SqlDbType.NVarChar).Value = ShishoCd;
            command.Parameters.Add("@TaisyoFrom", SqlDbType.NVarChar).Value = TaisyoFrom;
            command.Parameters.Add("@TaisyoTo", SqlDbType.NVarChar).Value = TaisyoTo;
            command.Parameters.Add("@SakuseiTaisho", SqlDbType.NVarChar).Value = SakuseiTaisho;
            command.Parameters.Add("@SakuseiHani", SqlDbType.NVarChar).Value = SakuseiHani;
            command.Parameters.Add("@Wareki", SqlDbType.NVarChar).Value = "0";
            command.Parameters.Add("@LoginUser", SqlDbType.NVarChar).Value = LoginUser;
            command.Parameters.Add("@PcUpdate", SqlDbType.NVarChar).Value = PcUpdate;
            command.Parameters.Add("@KaikeiSaibanNo", SqlDbType.NVarChar, 10);
            
            command.Parameters["@KaikeiSaibanNo"].Direction = ParameterDirection.Output;
                        
            string errFlg = (string)command.ExecuteScalar();

            retList.Add(errFlg);

            string kaikeiNo = command.Parameters["@KaikeiSaibanNo"].Value.ToString();

            retList.Add(kaikeiNo);

            return retList;
        }
        #endregion        

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

    #region KaikeiRendoHdrTblKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaikeiRendoHdrTblKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaikeiRendoHdrTblKensakuTableAdapter
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
        /// 2014/09/11　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuDataTable GetDataBySearchCond(KaikeiRendoHdrTblSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuDataTable dataTable = new KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuDataTable();
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
        /// 2014/09/11　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KaikeiRendoHdrTblSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();
            int condIdx = 1;
            string cond = "'____'";

            //SELECT
            sqlContent.Append(" SELECT                                                                                                                                                ");
            sqlContent.Append(" 		krht.KaikeiNo,                                                                                                                                ");
            sqlContent.Append(" 		CASE krht.UriageNyukinKbn                                                                                                                     ");
            sqlContent.Append(" 			WHEN '1' THEN '売上'                                                                                                                      ");
            sqlContent.Append(" 			WHEN '2' THEN '入金'                                                                                                                      ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                   ");
            sqlContent.Append(" 		END AS UriageNyukinKbn,                                                                                                                       ");
            sqlContent.Append(" 		krht.KaikeiShisyoCd,                                                                                                                          ");
            sqlContent.Append(" 		sm.ShishoNm,                                                                                                                                  ");
            sqlContent.Append(" 		CASE                                                                                                                                          ");
            sqlContent.Append("             WHEN ISDATE(krht.KaikeiMakeDt) = 0 THEN ''                                                                                                ");
            sqlContent.Append("             ELSE CONVERT(CHAR(10), CONVERT(DATETIME,krht.KaikeiMakeDt), 111)                                                                          ");
            sqlContent.Append("         END as KaikeiMakeDt,                                                                                                                          ");
            sqlContent.Append(" 		CASE                                                                                                                                          ");
            sqlContent.Append("             WHEN ISDATE(krht.KaikeiHaniFromDt) = 0 THEN ''                                                                                            ");
            sqlContent.Append("             ELSE CONVERT(CHAR(10), CONVERT(DATETIME,krht.KaikeiHaniFromDt), 111)                                                                      ");
            sqlContent.Append("         END as KaikeiHaniFromDt,                                                                                                                      ");
            sqlContent.Append(" 		CASE                                                                                                                                          ");
            sqlContent.Append("             WHEN ISDATE(krht.KaikeiHaniToDt) = 0 THEN ''                                                                                              ");
            sqlContent.Append("             ELSE CONVERT(CHAR(10), CONVERT(DATETIME,krht.KaikeiHaniToDt), 111)                                                                        ");
            sqlContent.Append("         END as KaikeiHaniToDt,                                                                                                                        ");
            sqlContent.Append(" 		(SELECT COUNT(*) FROM KaikeiRendoDtlTbl WHERE KaikeiRendoDtlTbl.KaikeiNo = krht.KaikeiNo) as Cnt,                                             ");
            sqlContent.Append(" 		CASE SUBSTRING(krht.MakeKbn, 1, 1)                                                                                                            ");
            sqlContent.Append(" 			WHEN '1' THEN '○'                                                                                                                         ");
            sqlContent.Append(" 			WHEN '0' THEN '×'                                                                                                                         ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                   ");
            sqlContent.Append(" 		END as Yubin,                                                                                                                                 ");
            sqlContent.Append(" 		CASE SUBSTRING(krht.MakeKbn, 2, 1)                                                                                                            ");
            sqlContent.Append(" 			WHEN '1' THEN '○'                                                                                                                         ");
            sqlContent.Append(" 			WHEN '0' THEN '×'                                                                                                                         ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                   ");
            sqlContent.Append(" 		END as Bank	,                                                                                                                                 ");
            sqlContent.Append(" 		CASE SUBSTRING(krht.MakeKbn, 3, 1)                                                                                                            ");
            sqlContent.Append(" 			WHEN '1' THEN '○'                                                                                                                         ");
            sqlContent.Append(" 			WHEN '0' THEN '×'                                                                                                                         ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                   ");
            sqlContent.Append(" 		END as Genkin,                                                                                                                                ");
            sqlContent.Append(" 		CASE SUBSTRING(krht.MakeKbn, 4, 1)                                                                                                            ");
            sqlContent.Append(" 			WHEN '1' THEN '○'                                                                                                                         ");
            sqlContent.Append(" 			WHEN '0' THEN '×'                                                                                                                         ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                   ");
            sqlContent.Append(" 		END as Shiharai,                                                                                                                              ");
            sqlContent.Append(" 		(SELECT SUM(KarikataKingaku) FROM KaikeiRendoDtlTbl WHERE KaikeiRendoDtlTbl.KaikeiNo = krht.KaikeiNo GROUP BY KaikeiNo) as KarikataKingaku,   ");
            sqlContent.Append(" 		(SELECT SUM(KashikataKingaku) FROM KaikeiRendoDtlTbl WHERE KaikeiRendoDtlTbl.KaikeiNo = krht.KaikeiNo GROUP BY KaikeiNo) as KashikataKingaku, ");
            sqlContent.Append(" 		CASE SyoninFlg                                                                                                                                ");
            sqlContent.Append(" 			WHEN '0' THEN '未'                                                                                                                        ");
            sqlContent.Append(" 			WHEN '1' THEN '済'                                                                                                                        ");
            sqlContent.Append(" 			WHEN '2' THEN '却下'                                                                                                                      ");
            sqlContent.Append(" 			ELSE ''                                                                                                                                   ");
            sqlContent.Append(" 		END as SyoninFlg,                                                                                                                             ");
            sqlContent.Append(" 		krht.KarikataTotal,                                                                                                                           ");
            sqlContent.Append(" 		krht.KashikataTotal,                                                                                                                          ");
            sqlContent.Append(" 		krht.UpdateDt,                                                                                                                                ");
            //Add HuyTX 20150114
            sqlContent.Append(" 		krht.UriageNyukinKbn AS UriageNyukinKbnOrg                                                                                                    ");
            //End

            //FROM
            sqlContent.Append(" FROM KaikeiRendoHdrTbl krht                                                                                                                           ");
            sqlContent.Append(" LEFT OUTER JOIN ShishoMst sm ON krht.KaikeiShisyoCd = sm.ShishoCd                                                                                     ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            //売上入金区分 
            if (!string.IsNullOrEmpty(searchCond.UriageNyukinKbn))
            {
                sqlContent.Append(" AND krht.UriageNyukinKbn = @uriageNyukinKbn ");
                commandParams.Add("@uriageNyukinKbn", SqlDbType.NVarChar).Value = searchCond.UriageNyukinKbn;
            }

            //支所
            if (!string.IsNullOrEmpty(searchCond.ShishoCd))
            {
                sqlContent.Append(" AND krht.KaikeiShisyoCd = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = searchCond.ShishoCd;
            }

            //会計No（開始） ~ （終了）
            //sqlContent.Append(" AND krht.KaikeiNo " + DataAccessUtility.SetBetweenCommand(searchCond.KaikeiNoFrom, searchCond.KaikeiNoTo, 10));

            if (!string.IsNullOrEmpty(searchCond.KaikeiNoFrom) && string.IsNullOrEmpty(searchCond.KaikeiNoTo))
            {
                sqlContent.Append("AND krht.KaikeiNo >= @KaikeiNoFrom ");
                commandParams.Add("@KaikeiNoFrom", SqlDbType.NVarChar).Value = searchCond.KaikeiNoFrom;
            }
            else if (string.IsNullOrEmpty(searchCond.KaikeiNoFrom) && !string.IsNullOrEmpty(searchCond.KaikeiNoTo))
            {
                sqlContent.Append("AND krht.KaikeiNo <= @KaikeiNoTo ");
                commandParams.Add("@KaikeiNoTo", SqlDbType.NVarChar).Value = searchCond.KaikeiNoTo;
            }
            else if (!string.IsNullOrEmpty(searchCond.KaikeiNoFrom) && !string.IsNullOrEmpty(searchCond.KaikeiNoTo))
            {
                sqlContent.Append("AND krht.KaikeiNo >= @KaikeiNoFrom ");
                commandParams.Add("@KaikeiNoFrom", SqlDbType.NVarChar).Value = searchCond.KaikeiNoFrom;

                sqlContent.Append("AND krht.KaikeiNo <= @KaikeiNoTo ");
                commandParams.Add("@KaikeiNoTo", SqlDbType.NVarChar).Value = searchCond.KaikeiNoTo;
            }

            //DEL_20141114_HuyTX Start
            //作成区分 
            //for (int i = 0; i < searchCond.ListMakeKbn.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        sqlContent.Append(" AND ( ");
            //        sqlContent.Append(" SUBSTRING(krht.MakeKbn, " + searchCond.ListMakeKbn[i] + ", 1) = '1' ");
            //    }
            //    if (i > 0)
            //    {
            //        sqlContent.Append(" OR SUBSTRING(krht.MakeKbn, " + searchCond.ListMakeKbn[i] + ", 1) = '1' ");
            //    }

            //    if (i == searchCond.ListMakeKbn.Count - 1)
            //    {
            //        sqlContent.Append(" ) ");
            //    }

            //}
            //DEL_20141114_HuyTX End

            //ADD_20141114_HuyTX Start
            //作成区分 
            for (int i = 0; i < searchCond.ListMakeKbn.Count; i++)
            {
                condIdx = Int32.Parse(searchCond.ListMakeKbn[i]);

                if (i == 0)
                {
                    sqlContent.Append(" AND ( ");
                    sqlContent.Append(" krht.MakeKbn LIKE " + cond.Remove(condIdx, 1).Insert(condIdx, "1"));
                }
                if (i > 0)
                {
                    sqlContent.Append(" OR krht.MakeKbn LIKE " + cond.Remove(condIdx, 1).Insert(condIdx, "1"));
                }

                if (i == searchCond.ListMakeKbn.Count - 1)
                {
                    sqlContent.Append(" ) ");
                }
            }
            //ADD_20141114_HuyTX End

            //作成日（開始） ~ （終了）
            if (searchCond.MakeDtUse)
            {
                //sqlContent.Append(" AND krht.KaikeiMakeDt " + DataAccessUtility.SetBetweenCommand(searchCond.MakeDtFrom, searchCond.MakeDtTo, 8));

                sqlContent.Append(" AND krht.KaikeiMakeDt >= @MakeDtFrom ");
                commandParams.Add("@MakeDtFrom", SqlDbType.NVarChar).Value = searchCond.MakeDtFrom;

                sqlContent.Append(" AND krht.KaikeiMakeDt <= @MakeDtTo ");
                commandParams.Add("@MakeDtTo", SqlDbType.NVarChar).Value = searchCond.MakeDtTo;
            }

            //承認フラグ 
            for (int i = 0; i < searchCond.ListSyoninFlg.Count; i++)
            {
                if (i == 0)
                {
                    sqlContent.Append(" AND ( ");
                    sqlContent.Append(" krht.SyoninFlg = " + searchCond.ListSyoninFlg[i]);
                }

                if (i > 0)
                {
                    sqlContent.Append(" OR krht.SyoninFlg = " + searchCond.ListSyoninFlg[i]);
                }

                if (i == searchCond.ListSyoninFlg.Count - 1)
                {
                    sqlContent.Append(" ) ");
                }
            }

            //ORDER
            sqlContent.Append(" ORDER BY krht.KaikeiMakeDt, krht.KaikeiNo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KaikeiRendoShosaiTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaikeiRendoShosaiTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KaikeiRendoShosaiTableAdapter
    {
        #region GetDataByKaikeiNo
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByKaikeiNo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kaikeiNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KaikeiRendoHdrTblDataSet.KaikeiRendoShosaiDataTable GetDataByKaikeiNo(string kaikeiNo)
        {
            SqlCommand command = CreateSqlCommand(kaikeiNo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KaikeiRendoHdrTblDataSet.KaikeiRendoShosaiDataTable dataTable = new KaikeiRendoHdrTblDataSet.KaikeiRendoShosaiDataTable();
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
        /// <param name="kaikeiNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string kaikeiNo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append(" SELECT                                                                                                    ");
            sqlContent.Append("     KaikeiRendoHdrTbl.KaikeiNo,                                                                           ");
            sqlContent.Append(" 	KaikeiRendoHdrTbl.UriageNyukinKbn,                                                                    ");
            sqlContent.Append(" 	CASE KaikeiRendoHdrTbl.UriageNyukinKbn                                                                ");
            sqlContent.Append(" 	        WHEN '1' THEN '売上'                                                                          ");
            sqlContent.Append(" 			WHEN '2' THEN '入金'                                                                          ");
            sqlContent.Append(" 		    ELSE ''                                                                                       ");
            sqlContent.Append(" 		END AS taisyoKbnTextBox,                                                                          ");
            sqlContent.Append(" 	KaikeiRendoHdrTbl.KaikeiShisyoCd,                                                                     ");
            sqlContent.Append(" 	KaikeiRendoHdrTbl.KaikeiHaniFromDt,                                                                   ");
            sqlContent.Append("     CASE WHEN ISNULL(KaikeiRendoHdrTbl.KaikeiHaniFromDt, '') = '' THEN ''                                 ");
            sqlContent.Append("          ELSE CONCAT(SUBSTRING(KaikeiRendoHdrTbl.KaikeiHaniFromDt, 0, 5), '/',                            ");
            sqlContent.Append("                         SUBSTRING(KaikeiRendoHdrTbl.KaikeiHaniFromDt, 5, 2), '/',                         ");
            sqlContent.Append(" 		                SUBSTRING(KaikeiRendoHdrTbl.KaikeiHaniFromDt, 7, 2))                              ");
            sqlContent.Append("          END AS taisyoDtFromTextBox,                                                                      ");
            sqlContent.Append("     KaikeiRendoHdrTbl.KaikeiHaniToDt,                                                                     ");
            sqlContent.Append("     CASE WHEN ISNULL(KaikeiRendoHdrTbl.KaikeiHaniToDt, '') = '' THEN ''                                   ");
            sqlContent.Append(" 		 ELSE CONCAT(SUBSTRING(KaikeiRendoHdrTbl.KaikeiHaniToDt, 0, 5), '/',                              ");
            sqlContent.Append("                         SUBSTRING(KaikeiRendoHdrTbl.KaikeiHaniToDt, 5, 2), '/',                           ");
            sqlContent.Append("                         SUBSTRING(KaikeiRendoHdrTbl.KaikeiHaniToDt, 7, 2))                                ");
            sqlContent.Append("         END AS taisyoDtToTextBox,                                                                         ");
            sqlContent.Append(" 	KaikeiRendoHdrTbl.MakeKbn,                                                                            ");
            sqlContent.Append(" 	KaikeiRendoHdrTbl.MakeHaniKbn,                                                                        ");
            sqlContent.Append(" 	CASE KaikeiRendoHdrTbl.MakeHaniKbn                                                                    ");
            sqlContent.Append(" 			WHEN '1' THEN '全件'                                                                          ");
            sqlContent.Append(" 			WHEN '2' THEN '差分'                                                                          ");
            sqlContent.Append(" 		    ELSE ''                                                                                       ");
            sqlContent.Append(" 		END AS makeHaniKbnTextBox,                                                                        ");
            sqlContent.Append(" 	KaikeiRendoHdrTbl.SyoninFlg,                                                                          ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.OutputKbn,                                                                          ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KeikeiRenban,                                                                       ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataJigyoCd,                                                                    ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataKamokuCd,                                                                   ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataKamokuNm,                                                                   ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataHojoKamokuCd,                                                               ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataHojoKamokuNm,                                                               ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataZeiKbn,                                                                     ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataKingaku,                                                                    ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KashikataJigyoCd,                                                                   ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KashikataKamokuCd,                                                                  ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KashikataKamokuNm,                                                                  ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KashikataHojoKamokuCd,                                                              ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KashikataHojoKamokuNm,                                                              ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KashikataZeiKbn,                                                                    ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KashikataKingaku,                                                                   ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.Tekiyo,                                                                             ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.SyohizeiGaku,                                                                       ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.UpdateDt AS KaikeiRendoDtlTblUpdateDt,                                              ");
            // 2014/11/05 DatNT v1.04 ADD Start
            sqlContent.Append(" 	KaikeiRendoDtlTbl.RendoKaikeiCD,                                                                      ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.DenpyoDt,                                                                           ");
            sqlContent.Append(" 	KaikeiRendoDtlTbl.KarikataSyohizei,                                                                   ");
            // 2014/11/05 DatNT v1.04 ADD End
            sqlContent.Append(" 	ShishoMst.ShishoNm                                                                                    ");

            // FROM
            sqlContent.Append(" FROM                                                                                                      ");
            sqlContent.Append("     KaikeiRendoHdrTbl                                                                                     ");
            sqlContent.Append(" INNER JOIN                                                                                                ");
            sqlContent.Append("     KaikeiRendoDtlTbl                                                                                     ");
            sqlContent.Append("         ON KaikeiRendoDtlTbl.KaikeiNo = KaikeiRendoHdrTbl.KaikeiNo                                        ");
            sqlContent.Append(" LEFT OUTER JOIN                                                                                           ");
            sqlContent.Append("     ShishoMst                                                                                             ");
            sqlContent.Append("         ON ShishoMst.ShishoCd = KaikeiRendoHdrTbl.KaikeiShisyoCd                                          ");

            // WHERE
            sqlContent.Append(" WHERE                                                                                                     ");
            sqlContent.Append("     KaikeiRendoHdrTbl.KaikeiNo = @KaikeiNo                                                                ");
            commandParams.Add("@KaikeiNo", SqlDbType.NVarChar).Value = kaikeiNo;

            // ORDER BY 
            sqlContent.Append(" ORDER BY                                                                                                  ");
            sqlContent.Append("     KaikeiRendoDtlTbl.KeikeiRenban                                                                        ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
