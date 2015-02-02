using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class SeikyuHdrTblDataSet {
    }

    #region SeikyuSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyuSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SeikyuSearchCond
    {
        /// <summary>
        /// 請求年月 
        /// </summary>
        public string SeikyuYM { get; set; }

        /// <summary>
        /// 業者コードFROM
        /// </summary>
        public string SeikyuGyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コードTO
        /// </summary>
        public string SeikyuGyoshaCdTo { get; set; }

        /// <summary>
        /// 請求先名称
        /// </summary>
        public string SeikyusakiNm { get; set; }

        /// <summary>
        /// 締め区分
        /// </summary>
        public string ShimeKbn { get; set; }

        /// <summary>
        /// 請求書発行フラグ
        /// </summary>
        public string SeikyushoHakkoFlg { get; set; }

        /// <summary>
        /// 請求日 FROM
        /// </summary>
        public string SeikyuDtFrom { get; set; }

        /// <summary>
        /// 請求日 TO
        /// </summary>
        public string SeikyuDtTo { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string SeikyuSyohinNm { get; set; }

        /// <summary>
        /// 請求科目
        /// TKey: ckb[6-12]
        /// TValue: ON/OFF
        /// </summary>
        public Dictionary<string, string> KbnDict { get; set; }

        //20150120 HuyTX Add
        /// <summary>
        /// 登録日
        /// </summary>
        public DateTime InsertDt { get; set; }

        /// <summary>
        /// 登録者
        /// </summary>
        public string InsertUser { get; set; }

        /// <summary>
        /// 登録端末
        /// </summary>
        public string InsertTarm { get; set; }
        //End

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SeikyuSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SeikyuSearchCond()
        {
            this.KbnDict = new Dictionary<string, string>();
        }
        #endregion
    }
    #endregion
}

namespace FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSetTableAdapters
{


    #region SeikyuListKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyuListKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SeikyuListKensakuTableAdapter
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
        /// 2014/09/10　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SeikyuHdrTblDataSet.SeikyuListKensakuDataTable GetDataBySearchCond(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SeikyuHdrTblDataSet.SeikyuListKensakuDataTable dataTable = new SeikyuHdrTblDataSet.SeikyuListKensakuDataTable();
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
        /// 2014/09/10　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.AppendLine(" select                                                                                                              ");
            sqlContent.AppendLine("     skht.OyaSeikyuNo,                                                                                               ");
            sqlContent.AppendLine("     case                                                                                                            ");
            sqlContent.AppendLine("         when skht.ShimeKbn = '1' then '事務局'");
            sqlContent.AppendLine("         when skht.ShimeKbn = '2' then '筑豊（水質検査）'");
            sqlContent.AppendLine("     end as ShimeKbn,                                                                                                ");
            sqlContent.AppendLine("     skht.IkkatsuSeikyuSakiCd,                                                                                       ");
            sqlContent.AppendLine("     skht.SeikyusakiNm,                                                                                              ");
            sqlContent.AppendLine("     case                                                                                                            ");
            sqlContent.AppendLine("         when isdate(skht.SeikyuDt) = 1 then convert(char(10), convert(datetime, skht.SeikyuDt), 111)                ");
            sqlContent.AppendLine("         else ''                                                                                                     ");
            sqlContent.AppendLine("     end as SeikyuDt,                                                                                                ");
            sqlContent.AppendLine("     skht.SeikyuKingaku,                                                                                             ");
            sqlContent.AppendLine("     case                                                                                                            ");
            sqlContent.AppendLine("         when skht.SeikyusyoHakkoFlg = '0' then '未'");
            sqlContent.AppendLine("         when skht.SeikyusyoHakkoFlg = '1' then '済'");
            sqlContent.AppendLine("     end as SeikyusyoHakkoFlg,                                                                                       ");
            sqlContent.AppendLine("     skht.UpdateDt                                                                                                   ");
            sqlContent.AppendLine(" from SeikyushoKagamiHdrTbl skht                                                                                     ");
            // WHERE
            sqlContent.Append(" where 1 = 1                                                                                                             ");

            // 請求年月
            if (!string.IsNullOrEmpty(searchCond.SeikyuYM))
            {
                sqlContent.Append(" and skht.SeikyuNenGetsu = @SeikyuYM                                                                                 ");
                commandParams.Add("@SeikyuYM", SqlDbType.NVarChar).Value = (string)searchCond.SeikyuYM;
            }

            // 業者コードFROM ~ TO
            //sqlContent.Append(" and skht.IkkatsuSeikyuSakiCd " + DataAccessUtility.SetBetweenCommand(searchCond.SeikyuGyoshaCdFrom, searchCond.SeikyuGyoshaCdTo, 4));
            if (!string.IsNullOrEmpty(searchCond.SeikyuGyoshaCdFrom))
            {
                sqlContent.AppendLine("AND skht.IkkatsuSeikyuSakiCd >= @SeikyuGyoshaCdFrom ");
                commandParams.Add("@SeikyuGyoshaCdFrom", SqlDbType.NVarChar).Value = searchCond.SeikyuGyoshaCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.SeikyuGyoshaCdTo))
            {
                sqlContent.AppendLine("AND skht.IkkatsuSeikyuSakiCd <= @SeikyuGyoshaCdTo ");
                commandParams.Add("@SeikyuGyoshaCdTo", SqlDbType.NVarChar).Value = searchCond.SeikyuGyoshaCdTo;
            }

            // 請求先名称
            if (!string.IsNullOrEmpty(searchCond.SeikyusakiNm))
            {
                sqlContent.Append(" and skht.SeikyusakiNm like concat('%', @SeikyusakiNm, '%')");
                commandParams.Add("@SeikyusakiNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.SeikyusakiNm);
            }

            // 締め区分
            sqlContent.Append(" and skht.ShimeKbn = @ShimeKbn");
            commandParams.Add("@ShimeKbn", SqlDbType.NVarChar).Value = (string)searchCond.ShimeKbn;

            // 請求書発行フラグ
            if (searchCond.SeikyushoHakkoFlg == "1")
            {
                sqlContent.Append(" and skht.SeikyusyoHakkoFlg = 1");
            }
            else if (searchCond.SeikyushoHakkoFlg == "2")
            {
                sqlContent.Append(" and skht.SeikyusyoHakkoFlg <> 1");
            }

            // 請求日
            if (!string.IsNullOrEmpty(searchCond.SeikyuDtFrom + searchCond.SeikyuDtTo))
            {
                sqlContent.Append(" and skht.SeikyuDt between @SeikyuDtFrom and @SeikyuDtTo");
                commandParams.Add("@SeikyuDtFrom", SqlDbType.NVarChar).Value = (string)searchCond.SeikyuDtFrom;
                commandParams.Add("@SeikyuDtTo", SqlDbType.NVarChar).Value = (string)searchCond.SeikyuDtTo;
            }

            // ORDER
            sqlContent.AppendLine(" order by                                                                                                            ");
            sqlContent.AppendLine("     skht.SeikyuNenGetsu,                                                                                            ");
            sqlContent.AppendLine("     skht.OyaSeikyuNo                                                                                                ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region ZandakaListKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ZandakaListKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ZandakaListKensakuTableAdapter
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
        /// 2014/09/17　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SeikyuHdrTblDataSet.ZandakaListKensakuDataTable GetDataBySearchCond(SeikyuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SeikyuHdrTblDataSet.ZandakaListKensakuDataTable dataTable = new SeikyuHdrTblDataSet.ZandakaListKensakuDataTable();
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
        /// 2014/09/17　AnhNV　　 新規作成
        /// 2014/11/05　AnhNV　　 基本設計書_006_009_画面_ZandakaList_Ver1.01
        /// 2014/12/22  kiyokuni  受入れで仕様バグがあったので仕様とともに修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(SeikyuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.AppendLine(" select                                                                                                                              ");
            sqlContent.AppendLine("     sht.SeikyuNo,                                                                                                                   ");
            sqlContent.AppendLine("     sht.OyaSeikyuNo,                                                                                                                ");
            sqlContent.AppendLine("     sdt.SeikyuRenban,                                                                                                               ");
            sqlContent.AppendLine("     sdt.SeikyuKomokuKbn,                                                                                                            ");
            sqlContent.AppendLine("     sdt.KensaIraiHoteiKbn,                                                                                                          ");
            sqlContent.AppendLine("     sht.SaiseikyuCnt,                                                                                                               ");
            sqlContent.AppendLine("     sht.SeikyuGyosyaCd,                                                                                                             ");
            sqlContent.AppendLine("     sht.SeikyuYM,                                                                                                                   ");
            sqlContent.AppendLine("     sht.SeikyusakiNm,                                                                                                               ");
            sqlContent.AppendLine("     case                                                                                                                            ");
            sqlContent.AppendLine("         when isdate(sht.SeikyuDt) = 0 then ''                                                                                       ");
            sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, sht.SeikyuDt), 111)                                                             ");
            sqlContent.AppendLine("     end as SeikyuDt,                                                                                                                ");
            sqlContent.AppendLine("     sdt.SeikyuKomokuNm,                                                                                                             ");
            sqlContent.AppendLine("     sdt.SeikyuSyohinNm,                                                                                                             ");
            sqlContent.AppendLine("     sdt.SeikyuKingakuKei,                                                                                                           ");
            sqlContent.AppendLine("     sdt.NyukinTotal,                                                                                                                ");
            sqlContent.AppendLine("     skht.IkkatsuSeikyuSakiCd,                                                                                                       ");
            sqlContent.AppendLine("     skht.SeikyuNenGetsu,                                                                                                            ");
            sqlContent.AppendLine("     skht.SeikyusakiNm as KagamiSeikyusakiNm,                                                                                        ");
            //ADD_20141114_HuyTX Start
            sqlContent.AppendLine("     sht.UpdateDt                                                                                                                    ");
            //ADD_20141114_HuyTX End
            sqlContent.AppendLine(" from                                                                                                                                ");
            sqlContent.AppendLine("     SeikyushoKagamiHdrTbl skht                                                                                                      ");
            sqlContent.AppendLine(" inner join SeikyuHdrTbl sht                                                                                                         ");
            sqlContent.AppendLine("     on skht.OyaSeikyuNo = sht.OyaSeikyuNo                                                                                           ");
            sqlContent.AppendLine(" inner join SeikyuDtlTbl sdt                                                                                                         ");
            sqlContent.AppendLine("     on sht.SeikyuNo = sdt.SeikyuNo                                                                                                  ");
            sqlContent.AppendLine("     and sdt.SeikyuKansaiFlg = '0'                                                                                                   ");
            // WHERE
            sqlContent.AppendLine(" where 1 = 1                                                                                                                         ");

            // 業者コード（開始）~ 業者コード（終了）
            //sqlContent.AppendLine("     skht.IkkatsuSeikyuSakiCd " + DataAccessUtility.SetBetweenCommand(searchCond.SeikyuGyoshaCdFrom, searchCond.SeikyuGyoshaCdTo, 4));
            if (!string.IsNullOrEmpty(searchCond.SeikyuGyoshaCdFrom))
            {
                sqlContent.AppendLine("AND sht.SeikyuGyosyaCd >= @SeikyuGyoshaCdFrom ");
                commandParams.Add("@SeikyuGyoshaCdFrom", SqlDbType.NVarChar).Value = searchCond.SeikyuGyoshaCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.SeikyuGyoshaCdTo))
            {
                sqlContent.AppendLine("AND sht.SeikyuGyosyaCd<= @SeikyuGyoshaCdTo ");
                commandParams.Add("@SeikyuGyoshaCdTo", SqlDbType.NVarChar).Value = searchCond.SeikyuGyoshaCdTo;
            }

            // 請求先名称
            if (!string.IsNullOrEmpty(searchCond.SeikyusakiNm))
            {
                sqlContent.AppendLine(" and sht.SeikyusakiNm like concat('%', @SeikyusakiNm, '%')");
                commandParams.Add("@SeikyusakiNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.SeikyusakiNm);
            }

            // 請求項目区分 + 検査依頼法定区分
            if (searchCond.KbnDict.Count > 0)
            {
                sqlContent.AppendLine(" and (" + MakeKbnSearchCond(searchCond.KbnDict) + ")");
            }

            // 商品名
            if (!string.IsNullOrEmpty(searchCond.SeikyuSyohinNm))
            {
                sqlContent.AppendLine(" and sdt.SeikyuSyohinNm like concat('%', @SeikyuSyohinNm, '%')");
                commandParams.Add("@SeikyuSyohinNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.SeikyuSyohinNm);
            }

            // 請求日
            if (!string.IsNullOrEmpty(searchCond.SeikyuDtFrom + searchCond.SeikyuDtTo))
            {
                sqlContent.AppendLine(" and sht.SeikyuDt between @SeikyuDtFrom and @SeikyuDtTo");
                commandParams.Add("@SeikyuDtFrom", SqlDbType.NVarChar).Value = (string)searchCond.SeikyuDtFrom;
                commandParams.Add("@SeikyuDtTo", SqlDbType.NVarChar).Value = (string)searchCond.SeikyuDtTo;
            }

            // ORDER
            sqlContent.AppendLine(" order by                                                                                                                            ");
            sqlContent.AppendLine("     skht.OyaSeikyuNo,                                                                                                               ");
            sqlContent.AppendLine("     sdt.SeikyuNo,                                                                                                                   ");
            sqlContent.AppendLine("     sdt.SeikyuRenban                                                                                                                ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

        #region MakeKbnSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeKbnSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string MakeKbnSearchCond(Dictionary<string, string> kbnDict)
        {
            StringBuilder sql = new StringBuilder();

            // 請求科目/7条検査 is ON
            if (kbnDict["ckb6"] == "ON")
            {
                sql.AppendLine("or");
                sql.AppendLine("(sdt.SeikyuKomokuKbn = 1 and sdt.KensaIraiHoteiKbn = 1)");
            }

            // 請求科目/11条検査(外観) is ON
            if (kbnDict["ckb7"] == "ON")
            {
                sql.AppendLine("or");
                sql.AppendLine("(sdt.SeikyuKomokuKbn = 1 and sdt.KensaIraiHoteiKbn = 2)");
            }

            // 請求科目/11条検査(水質) is ON
            if (kbnDict["ckb8"] == "ON")
            {
                sql.AppendLine("or");
                sql.AppendLine("(sdt.SeikyuKomokuKbn = 1 and sdt.KensaIraiHoteiKbn = 3)");
            }

            // 請求科目/計量証明 is ON
            if (kbnDict["ckb9"] == "ON")
            {
                sql.AppendLine("or");
                sql.AppendLine("(sdt.SeikyuKomokuKbn = 2)");
            }

            // 請求科目/保証登録 is ON
            if (kbnDict["ckb10"] == "ON")
            {
                sql.AppendLine("or");
                sql.AppendLine("(sdt.SeikyuKomokuKbn = 3)");
            }

            // 請求科目/用紙販売 is ON
            if (kbnDict["ckb11"] == "ON")
            {
                sql.AppendLine("or");
                sql.AppendLine("(sdt.SeikyuKomokuKbn = 4)");
            }

            // 請求科目/年会費 is ON
            if (kbnDict["ckb12"] == "ON")
            {
                sql.AppendLine("or");
                sql.AppendLine("(sdt.SeikyuKomokuKbn = 5)");
            }

            return sql.ToString().Remove(0, 2);
        }
        #endregion

        #region GenerateInSql
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GenerateInSql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst">At least 1 element</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GenerateInSql(List<string> lst)
        {
            // 1 checkbox is checked!
            if (lst.Count == 1)
            {
                return string.Concat(" = '", lst[0], "'");
            }

            // Multiple choices
            string sqlPart = " in (";

            foreach (string val in lst)
            {
                sqlPart += string.Concat("'", val, "',");
            }

            return sqlPart.Remove(sqlPart.Length - 1) + ") ";
        }
        #endregion

        #region SelectSeikyusyoQuery
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SelectSeikyusyoQuery
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public string SelectSeikyusyoQuery(SeikyuSearchCond searchCond)
        {
            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append(" (SELECT                                     ");
            sqlContent.Append(" 		skht.SeikyusakiKbn,                 ");
            sqlContent.Append(" 		skht.IkkatsuSeikyuSakiCd,           ");
            sqlContent.Append(" 		skht.JokasoHokenjoCd,               ");
            sqlContent.Append(" 		skht.JokasoTorokuNendo,             ");
            sqlContent.Append(" 		skht.JokasoRenban,                  ");
            sqlContent.Append(" 		skht.SeikyuNenGetsu,                ");
            sqlContent.Append(" 		skht.SeikyusakiNm,                  ");
            sqlContent.Append(" 		sdt.SeikyuKingakuKei,               ");
            sqlContent.Append(" 		sdt.NyukinTotal,                    ");
            sqlContent.Append(" 		sdt.SeikyuKomokuKbn,                ");
            sqlContent.Append(" 		sdt.KensaIraiHoteiKbn,              ");
            sqlContent.Append(" 		sht.SeikyuNo                        ");

            //FROM
            sqlContent.Append(" FROM                                        ");
            sqlContent.Append("     SeikyushoKagamiHdrTbl skht              ");
            sqlContent.Append(" INNER JOIN SeikyuHdrTbl sht                 ");
            sqlContent.Append("     ON skht.OyaSeikyuNo = sht.OyaSeikyuNo   ");
            sqlContent.Append(" INNER JOIN SeikyuDtlTbl sdt                 ");
            sqlContent.Append("     ON sht.SeikyuNo = sdt.SeikyuNo          ");
            sqlContent.Append("     AND sdt.SeikyuKansaiFlg = '0'           ");

            // WHERE
            sqlContent.Append(" WHERE 1 = 1                                 ");

            // 業者コード（開始）~ 業者コード（終了）
            if (!string.IsNullOrEmpty(searchCond.SeikyuGyoshaCdFrom))
            {
                sqlContent.Append(" AND sht.SeikyuGyosyaCd >= '" + searchCond.SeikyuGyoshaCdFrom + "' ");
            }
            if (!string.IsNullOrEmpty(searchCond.SeikyuGyoshaCdTo))
            {
                sqlContent.Append(" AND sht.SeikyuGyosyaCd<= '" + searchCond.SeikyuGyoshaCdTo + "' ");
            }

            // 請求先名称
            if (!string.IsNullOrEmpty(searchCond.SeikyusakiNm))
            {
                sqlContent.Append(" AND sht.SeikyusakiNm LIKE CONCAT('%', '" + DataAccessUtility.EscapeSQLString(searchCond.SeikyusakiNm) + "', '%') ");
            }

            // 請求項目区分 + 検査依頼法定区分
            if (searchCond.KbnDict.Count > 0)
            {
                sqlContent.Append(" AND (" + MakeKbnSearchCond(searchCond.KbnDict) + ")");
            }

            // 商品名
            if (!string.IsNullOrEmpty(searchCond.SeikyuSyohinNm))
            {
                sqlContent.Append(" AND sdt.SeikyuSyohinNm LIKE CONCAT('%', '" + DataAccessUtility.EscapeSQLString(searchCond.SeikyuSyohinNm) + "', '%') ");
            }

            // 請求日
            if (!string.IsNullOrEmpty(searchCond.SeikyuDtFrom))
            {
                sqlContent.Append(" AND sht.SeikyuDt >= '" + searchCond.SeikyuDtFrom + "' ");
            }
            if (!string.IsNullOrEmpty(searchCond.SeikyuDtTo))
            {
                sqlContent.Append(" AND sht.SeikyuDt <= '" + searchCond.SeikyuDtTo + "' ");
            }

            sqlContent.Append(" ) ");

            return sqlContent.ToString();
        }
        #endregion
    }
    #endregion
}
