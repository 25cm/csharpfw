using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet
{
    public partial class KensaIraiTblDataSet
    {
    }

    #region KensaIraiTblSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraiTblSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　AnhNV　　 新規作成
    /// 2014/10/08　AnhNV　　    基本設計書_009_008_画面_KensaHoryuList.Ver1.03
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KensaIraiTblSearchCond
    {
        /// <summary>
        /// 保健所コード（開始）
        /// </summary>
        public string HokenjoCdFrom { get; set; }

        /// <summary>
        /// 保健所コード（終了）
        /// </summary>
        public string HokenjoCdTo { get; set; }

        /// <summary>
        /// 年度（開始）
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// 年度（終了）
        /// </summary>
        public string NendoTo { get; set; }

        /// <summary>
        /// 連番（開始）
        /// </summary>
        public string RenbanFrom { get; set; }

        /// <summary>
        /// 連番（終了）
        /// </summary>
        public string RenbanTo { get; set; }

        /// <summary>
        /// 保留区分
        /// </summary>
        public string KensaIraiHoryuKbn { get; set; }

        /// <summary>
        /// 検査責任者
        /// </summary>
        public string KensaIraiKensaSekininsha { get; set; }

        /// <summary>
        /// 検査担当者コード
        /// </summary>
        public string KensaIraiKensaTantoshaCd { get; set; }

        /// <summary>
        /// 検査依頼法定区分 
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 設置者名（漢字）
        /// </summary>
        public string KensaIraiSetchishaNm { get; set; }

        /// <summary>
        /// 検査依頼設置場所（住所）
        /// </summary>
        public string KensaIraiSetchibashoAdr { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
    }
    #endregion

    #region KensaYoteiListSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaYoteiListSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KensaYoteiListSearchCond
    {
        /// <summary>
        /// 職員コード
        /// </summary>
        public string ShokuinCd { get; set; }

        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 保健所コード（開始）
        /// </summary>
        public string HokenjoCdFrom { get; set; }

        /// <summary>
        /// 保健所コード（終了）
        /// </summary>
        public string HokenjoCdTo { get; set; }

        /// <summary>
        /// 年度（開始）
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// 年度（終了）
        /// </summary>
        public string NendoTo { get; set; }

        /// <summary>
        /// 連番（開始）
        /// </summary>
        public string RenbanFrom { get; set; }

        /// <summary>
        /// 連番（終了）
        /// </summary>
        public string RenbanTo { get; set; }

        /// <summary>
        /// 出力順
        /// </summary>
        public string OutputOrder { get; set; }

        /// <summary>
        /// 検査予定日検索使用フラグ
        /// </summary>
        public bool KensaYoteiDtUse { get; set; }

        /// <summary>
        /// 検査予定日（開始）
        /// </summary>
        public string KensaYoteiDtFrom { get; set; }

        /// <summary>
        /// 検査予定日（終了）
        /// </summary>
        public string KensaYoteiDtTo { get; set; }

        /// <summary>
        /// 検査日未定含む（年月での検索）
        /// </summary>
        public bool KensaMitei { get; set; }

        /// <summary>
        /// 設置住所
        /// </summary>
        public string SettiAdr { get; set; }

        /// <summary>
        /// 設置者カナ（開始）
        /// </summary>
        public string SettisyaKanaFrom { get; set; }

        /// <summary>
        /// 設置者カナ（終了）
        /// </summary>
        public string SettisyaKanaTo { get; set; }

        /// <summary>
        /// 依頼業者
        /// </summary>
        public string GyoshaNm { get; set; }

        /// <summary>
        /// 人槽（開始）
        /// </summary>
        public string NinsoFrom { get; set; }

        /// <summary>
        /// 人槽（終了）
        /// </summary>
        public string NinsoTo { get; set; }

        /// <summary>
        /// 市区町村
        /// </summary>
        public string Shikuchoson { get; set; }

    }
    #endregion
}

namespace FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters
{    
    #region KensaJokyoListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaJokyoListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　 新規作成
    /// 2014/12/28　habu　　  CommandTimeout追加
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaJokyoListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="jokasoSetchishaNm"></param>
        /// <param name="jokasoShisetsuNm"></param>
        /// <param name="settisyaCd"></param>
        /// <param name="kensaIraiDtFrom"></param>
        /// <param name="kensaIraiDtTo"></param>
        /// <param name="kensaDtFrom"></param>
        /// <param name="kensaDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.KensaJokyoListDataTable GetDataBySearchCond(
            List<string> kensaIraiHoteiKbn,
            string jokasoSetchishaNm,
            string jokasoShisetsuNm,
            string settisyaCd,
            string kensaIraiDtFrom,
            string kensaIraiDtTo,
            string kensaDtFrom,
            string kensaDtTo)
        {
            SqlCommand command = CreateSqlCommand(kensaIraiHoteiKbn,
                                                    jokasoSetchishaNm,
                                                    jokasoShisetsuNm,
                                                    settisyaCd,
                                                    kensaIraiDtFrom,
                                                    kensaIraiDtTo,
                                                    kensaDtFrom,
                                                    kensaDtTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.KensaJokyoListDataTable dataTable = new KensaIraiTblDataSet.KensaJokyoListDataTable();
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
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="jokasoSetchishaNm"></param>
        /// <param name="jokasoShisetsuNm"></param>
        /// <param name="settisyaCd"></param>
        /// <param name="kensaIraiDtFrom"></param>
        /// <param name="kensaIraiDtTo"></param>
        /// <param name="kensaDtFrom"></param>
        /// <param name="kensaDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX　　新規作成
        /// 2014/11/24　AnhNV　　チケット8051対応
        /// 2014/12/15　HuyTX　　Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            List<string> kensaIraiHoteiKbn,
            string jokasoSetchishaNm,
            string jokasoShisetsuNm,
            string settisyaCd,
            string kensaIraiDtFrom,
            string kensaIraiDtTo,
            string kensaDtFrom,
            string kensaDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();
            StringBuilder sqlSubContent = new StringBuilder();

            string hoteiKbn = string.Empty;

            //get kensaIraiHoteiKbn
            foreach (var item in kensaIraiHoteiKbn)
            {
                hoteiKbn += "'" + item.ToString() + "', ";
            }

            //Sub query
            sqlSubContent.Append("         SELECT kit.KensaIraiHoteiKbn AS KensaIraiHoteiKbn, ");
            //20141215 Mod Start
            //sqlSubContent.Append("                 cm.ConstNm AS ConstNm, ");
            sqlSubContent.Append("                 CASE  ");
			sqlSubContent.Append("                 	    WHEN kit.KensaIraiScreeningKbn = '0' THEN cmHoteiKbn.ConstNm ");
			sqlSubContent.Append("                 	    ELSE cmScreeningKbn.ConstNm ");
			sqlSubContent.Append("                 END AS ConstNm, ");
            //20141215 Mod End
            //sqlSubContent.Append("                 CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', REPLACE(STR(kit.KensaIraiJokasoTorokuNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiJokasoTorokuNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiJokasoRenban) AS JokasoCd, ");
            //sqlSubContent.Append("                 CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiJokasoTorokuNendo, 'yy', 1), '-', kit.KensaIraiJokasoRenban) AS JokasoCd, ");
            sqlSubContent.Append("                 CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiJokasoTorokuNendo), '-', kit.KensaIraiJokasoRenban) AS JokasoCd, ");
            sqlSubContent.Append("                 jdm.JokasoSetchishaNm AS JokasoSetchishaNm, ");
            sqlSubContent.Append("                 jdm.JokasoShisetsuNm AS JokasoShisetsuNm , ");
            //sqlSubContent.Append("                 CONCAT(kit.KensaIraiHokenjoCd, '-', REPLACE(STR(kit.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiRenban) AS KensaIraiCd, ");
            //sqlSubContent.Append("                 CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiNendo, 'yy', 1), '-', kit.KensaIraiRenban) AS KensaIraiCd, ");
            sqlSubContent.Append("                 CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo), '-', kit.KensaIraiRenban) AS KensaIraiCd, ");
            sqlSubContent.Append("                 (CASE ");
            sqlSubContent.Append("                     WHEN ISDATE(CONCAT(kit.KensaIraiNen,kit.KensaIraiTsuki,kit.KensaIraiBi)) = 0 THEN '' ");
            sqlSubContent.Append("                     ELSE CONVERT(CHAR(10), CONVERT(DATETIME,CONCAT(kit.KensaIraiNen,kit.KensaIraiTsuki,kit.KensaIraiBi)), 111) ");
            sqlSubContent.Append("                 END) AS KensaIraiDt, ");
            sqlSubContent.Append("                 CASE  ");

            // 2014.12.29 toyoda Modify Start
            //sqlSubContent.Append("                     WHEN ISNULL(kit.KensaIraiSuishitsuUketsukeDt, '') = '' THEN ''  ");
            sqlSubContent.Append("                     WHEN ISDATE(kit.KensaIraiSuishitsuUketsukeDt) <> 1 THEN ''  ");
            // 2014.12.29 toyoda Modify End

            sqlSubContent.Append("                     ELSE CONVERT(CHAR(10), CONVERT(DATETIME, kit.KensaIraiSuishitsuUketsukeDt), 111)  ");
            sqlSubContent.Append("                 END AS KensaUketsukeDt, ");
            sqlSubContent.Append("                 (CASE ");
            sqlSubContent.Append("                     WHEN ISDATE(CONCAT(kit.KensaIraiKensaNen,kit.KensaIraiKensaTsuki,kit.KensaIraiKensaBi)) = 0 THEN '' ");
            sqlSubContent.Append("                     ELSE CONVERT(CHAR(10), CONVERT(DATETIME,CONCAT(kit.KensaIraiKensaNen,kit.KensaIraiKensaTsuki,kit.KensaIraiKensaBi)), 111) ");
            sqlSubContent.Append("                 END) AS KensaDt, ");
            sqlSubContent.Append("                 (CASE kkt.KensaKekkaHantei ");
            sqlSubContent.Append("                     WHEN 1 THEN '○' ");
            sqlSubContent.Append("                     WHEN 2 THEN '△' ");
            sqlSubContent.Append("                     WHEN 3 THEN '×' ");
            sqlSubContent.Append("                 END) AS Hantei, ");

            //ADD_20141117_HuyTX Start
            sqlSubContent.Append("                 kit.KensaIraiJokasoHokenjoCd AS JokasoCd1, ");
            sqlSubContent.Append("                 kit.KensaIraiJokasoTorokuNendo AS JokasoCd2, ");
            sqlSubContent.Append("                 kit.KensaIraiJokasoRenban AS JokasoCd3, ");
            sqlSubContent.Append("                 kit.KensaIraiHokenjoCd AS KensaIraiCd1, ");
            sqlSubContent.Append("                 kit.KensaIraiNendo AS KensaIraiCd2, ");
            sqlSubContent.Append("                 kit.KensaIraiRenban AS KensaIraiCd3, ");
            sqlSubContent.Append("                 '0' AS KeiryoShomeiFlg ");
            //ADD_20141117_HuyTX End

            sqlSubContent.Append("         FROM KensaIraiTbl kit  ");
            //20141215 Mod Start
            //sqlSubContent.Append("         LEFT OUTER JOIN ConstMst cm ON kit.KensaIraiHoteiKbn = cm.ConstValue AND cm.ConstKbn = '006' ");
            sqlSubContent.Append("         LEFT OUTER JOIN ConstMst cmHoteiKbn ON kit.KensaIraiHoteiKbn = cmHoteiKbn.ConstValue AND cmHoteiKbn.ConstKbn = '006' ");
            sqlSubContent.Append("         LEFT OUTER JOIN ConstMst cmScreeningKbn ON kit.KensaIraiScreeningKbn = cmScreeningKbn.ConstValue AND cmScreeningKbn.ConstKbn = '024' ");
            //20141215 Mod End
            sqlSubContent.Append("         LEFT OUTER JOIN JokasoDaichoMst jdm  ");
            sqlSubContent.Append("                         ON kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd  ");
            sqlSubContent.Append("                         AND kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo  ");
            sqlSubContent.Append("                         AND kit.KensaIraiJokasoRenban = jdm.JokasoRenban ");

            sqlSubContent.Append("         LEFT OUTER JOIN KensaKekkaTbl kkt ON kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn ");
            sqlSubContent.Append("         AND kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd ");
            sqlSubContent.Append("         AND kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo ");
            sqlSubContent.Append("         AND kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban ");

//2014.11.27 Mod kiyokuni ------ start
            //sqlSubContent.Append(" WHERE kit.KensaIraiStatusKbn BETWEEN 40 AND 89 ");
            sqlSubContent.Append(" WHERE kit.KensaIraiStatusKbn >= '40' ");
            sqlSubContent.Append(" AND kit.KensaIraiStatusKbn < '90' ");
//2014.11.27 Mod kiyokuni ------ end

            //検査日
            if (!string.IsNullOrEmpty(kensaDtFrom))
            {
                //sqlSubContent.Append(" AND CONCAT(REPLACE(STR(kit.KensaIraiKensaNen, 4), SPACE(1), '0'), ");
                //sqlSubContent.Append(" REPLACE(STR(kit.KensaIraiKensaTsuki, 2), SPACE(1), '0'),  ");
                //sqlSubContent.Append(" REPLACE(STR(kit.KensaIraiKensaBi, 2), SPACE(1), '0')) " + DataAccessUtility.SetBetweenCommand(kensaDtFrom, kensaDtTo, 8));
                //sqlSubContent.Append(" AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) ");
                //sqlSubContent.Append(DataAccessUtility.SetBetweenCommand(kensaDtFrom, kensaDtTo, 8));

                sqlSubContent.Append(" AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) >= @kensaDtFrom ");
                commandParams.Add("@kensaDtFrom", SqlDbType.NVarChar).Value = kensaDtFrom;
            }
            if (!string.IsNullOrEmpty(kensaDtTo))
            {
                sqlSubContent.Append(" AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) <= @kensaDtTo ");
                commandParams.Add("@kensaDtTo", SqlDbType.NVarChar).Value = kensaDtTo;
            }

            //SELECT
            // 20141228 habu
            sqlContent.Append(" SELECT TOP 2000 * FROM  ");
            //sqlContent.Append(" SELECT * FROM  ");
            // 20141228 End
            sqlContent.Append(" ( ");

            //HoteiKbn = 1, 2
            if (kensaIraiHoteiKbn.Contains("1") || kensaIraiHoteiKbn.Contains("2"))
            {
                sqlContent.Append(sqlSubContent.ToString());

                sqlContent.Append(" AND kit.KensaIraiHoteiKbn IN('1', '2') ");

                if (!string.IsNullOrEmpty(kensaIraiDtFrom))
                {
                    //sqlContent.Append(" AND CONCAT(REPLACE(STR(kit.KensaIraiNen, 4), SPACE(1), '0'), ");
                    //sqlContent.Append(" REPLACE(STR(kit.KensaIraiTsuki, 2), SPACE(1), '0'),  ");
                    //sqlContent.Append(" REPLACE(STR(kit.KensaIraiBi, 2), SPACE(1), '0')) " + DataAccessUtility.SetBetweenCommand(kensaIraiDtFrom, kensaIraiDtTo, 8));
                    //sqlContent.Append(" AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi) ");
                    //sqlContent.Append(DataAccessUtility.SetBetweenCommand(kensaIraiDtFrom, kensaIraiDtTo, 8));
                    //sqlContent.Append(" AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi)  >= @kensaIraiDtFrom ");
                    //commandParams.Add("@kensaIraiDtFrom", SqlDbType.NVarChar).Value = kensaIraiDtFrom;

                    // 2014.12.29 toyoda Modify Start
                    sqlContent.Append(" AND (kit.KensaIraiKensaNen > @kensaIraiDtFromYYYY ");
                    sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaIraiDtFromYYYY AND kit.KensaIraiKensaTsuki > @kensaIraiDtFromMM) ");
                    sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaIraiDtFromYYYY AND kit.KensaIraiKensaTsuki = @kensaIraiDtFromMM AND kit.KensaIraiKensaBi >= @kensaIraiDtFromDD))	 ");
                    // 2014.12.29 toyoda Modify End
                }
                if (!string.IsNullOrEmpty(kensaIraiDtTo))
                {
                    //sqlContent.Append(" AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi)  <= @kensaIraiDtTo ");
                    //commandParams.Add("@kensaIraiDtTo", SqlDbType.NVarChar).Value = kensaIraiDtTo;

                    // 2014.12.29 toyoda Modify Start
                    sqlContent.Append(" AND (kit.KensaIraiKensaNen < @kensaIraiDtToYYYY ");
                    sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaIraiDtToYYYY AND kit.KensaIraiKensaTsuki < @kensaIraiDtToMM) ");
                    sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaIraiDtToYYYY AND kit.KensaIraiKensaTsuki = @kensaIraiDtToMM AND kit.KensaIraiKensaBi <= @kensaIraiDtToDD)) ");
                    // 2014.12.29 toyoda Modify End
                }
            }

            //HoteiKbn = 3
            if (kensaIraiHoteiKbn.Contains("3"))
            {
                if (kensaIraiHoteiKbn.Contains("1") || kensaIraiHoteiKbn.Contains("2"))
                {
                    sqlContent.Append(" UNION  ");
                }

                sqlContent.Append(sqlSubContent.ToString());

                sqlContent.Append(" AND kit.KensaIraiHoteiKbn = '3' ");

                if (!string.IsNullOrEmpty(kensaIraiDtFrom))
                {
                    //sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt " + DataAccessUtility.SetBetweenCommand(kensaIraiDtFrom, kensaIraiDtTo, 8));
                    sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt >= @kensaIraiDtFrom ");
                    //commandParams.Add("@kensaIraiDtFrom", SqlDbType.NVarChar).Value = kensaIraiDtFrom;
                }
                if (!string.IsNullOrEmpty(kensaIraiDtTo))
                {
                    sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt <= @kensaIraiDtTo ");
                    //commandParams.Add("@kensaIraiDtTo", SqlDbType.NVarChar).Value = kensaIraiDtTo;
                }
            }

            //HoteiKbn = 4
            if (kensaIraiHoteiKbn.Contains("4"))
            {
                //UNION
                if (kensaIraiHoteiKbn.Count > 1)
                {
                    sqlContent.Append(" UNION ");
                }

                sqlContent.Append("     SELECT '4' AS KensaIraiHoteiKbn, ");
                sqlContent.Append("             '計量証明' AS ConstNm, ");
                //sqlContent.Append("             CONCAT(ksit.KeiryoShomeiJokasoDaichoHokenjoCd, '-',  REPLACE(STR(ksit.KeiryoShomeiJokasoDaichoNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(ksit.KeiryoShomeiJokasoDaichoNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', ksit.KeiryoShomeiJokasoDaichoRenban) AS JokasoCd, ");
                //sqlContent.Append("             CONCAT(ksit.KeiryoShomeiJokasoDaichoHokenjoCd, '-',  [dbo].[FuncConvertToWareki](ksit.KeiryoShomeiJokasoDaichoNendo, 'yy', 1), '-', ksit.KeiryoShomeiJokasoDaichoRenban) AS JokasoCd, ");
                sqlContent.Append("             CONCAT(ksit.KeiryoShomeiJokasoDaichoHokenjoCd, '-',  [dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiJokasoDaichoNendo), '-', ksit.KeiryoShomeiJokasoDaichoRenban) AS JokasoCd, ");
                sqlContent.Append("             jdm.JokasoSetchishaNm AS JokasoSetchishaNm, ");
                sqlContent.Append("             jdm.JokasoShisetsuNm AS JokasoShisetsuNm , ");
                //sqlContent.Append("             CONCAT(REPLACE(STR(ksit.KeiryoShomeiIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(ksit.KeiryoShomeiIraiNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', ksit.KeiryoShomeiIraiSishoCd, '-', ksit.KeiryoShomeiIraiRenban) AS KensaIraiCd, ");
                sqlContent.Append("             CONCAT([dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiIraiNendo), '-', ksit.KeiryoShomeiIraiSishoCd, '-', ksit.KeiryoShomeiIraiRenban) AS KensaIraiCd, ");
                sqlContent.Append("             '' AS KensaIraiDt, ");
                sqlContent.Append("             CASE  ");

                // 2014.12.29 toyoda Modify Start
                //sqlContent.Append("                 WHEN ISNULL(ksit.KeiryoShomeiIraiUketsukeDt, '') = '' THEN ''  ");
                sqlContent.Append("                 WHEN ISDATE(ksit.KeiryoShomeiIraiUketsukeDt) <> 1 THEN ''  ");
                // 2014.12.29 toyoda Modify End

                sqlContent.Append("                 ELSE CONVERT(CHAR(10), CONVERT(DATETIME, ksit.KeiryoShomeiIraiUketsukeDt), 111)  ");
                sqlContent.Append("             END AS KensaUketsukeDt, ");
                sqlContent.Append("             '' AS KensaDt, ");
                sqlContent.Append("             CASE ");
                sqlContent.Append("                 WHEN (kskt11.cnt IS NULL OR kskt11.cnt = '') AND (kskt22.cnt IS NOT NULL OR kskt22.cnt <> '')  THEN CONCAT('0/', kskt22.cnt) ");
                sqlContent.Append("                 WHEN (kskt11.cnt IS NULL OR kskt11.cnt = '') AND (kskt22.cnt IS NULL OR kskt22.cnt = '') THEN '' ");
                sqlContent.Append("                 WHEN kskt11.cnt = kskt22.cnt THEN '済'  ");
                sqlContent.Append("                 ELSE CONCAT(kskt11.cnt, '/', kskt22.cnt)  ");
                sqlContent.Append("             END AS Hantei, ");

                //ADD_20141117_HuyTX Start
                sqlContent.Append("             ksit.KeiryoShomeiJokasoDaichoHokenjoCd AS JokasoCd1, ");
                sqlContent.Append("             ksit.KeiryoShomeiJokasoDaichoNendo AS JokasoCd2, ");
                sqlContent.Append("             ksit.KeiryoShomeiJokasoDaichoRenban AS JokasoCd3, ");
                sqlContent.Append("             ksit.KeiryoShomeiIraiNendo AS KensaIraiCd1, ");
                sqlContent.Append("             ksit.KeiryoShomeiIraiSishoCd AS KensaIraiCd2, ");
                sqlContent.Append("             ksit.KeiryoShomeiIraiRenban AS KensaIraiCd3, ");
                sqlContent.Append("             '1' AS KeiryoShomeiFlg ");
                //ADD_20141117_HuyTX End

                sqlContent.Append("     FROM KeiryoShomeiIraiTbl ksit  ");

                sqlContent.Append("     LEFT OUTER JOIN JokasoDaichoMst jdm  ");
                sqlContent.Append("                     ON ksit.KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd  ");
                sqlContent.Append("                     AND ksit.KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo  ");
                sqlContent.Append("                     AND ksit.KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban ");

                sqlContent.Append("     LEFT OUTER JOIN   ");
                sqlContent.Append("             (SELECT KeiryoShomeiKekkaIraiNendo, KeiryoShomeiKekkaIraiShishoCd, KeiryoShomeiKekkaIraiNo, COUNT(*) AS cnt FROM KeiryoShomeiKekkaTbl  ");
                sqlContent.Append("                                         WHERE KeiryoShomeiKekkaNyuryoku = '1' ");
                sqlContent.Append("                                         GROUP BY KeiryoShomeiKekkaIraiNendo, KeiryoShomeiKekkaIraiShishoCd, KeiryoShomeiKekkaIraiNo ) AS kskt11 ");
                sqlContent.Append("             ON ( ");
                sqlContent.Append("                 ksit.KeiryoShomeiIraiNendo = kskt11.KeiryoShomeiKekkaIraiNendo ");
                sqlContent.Append("                 AND ksit.KeiryoShomeiIraiSishoCd = kskt11.KeiryoShomeiKekkaIraiShishoCd ");
                sqlContent.Append("                 AND ksit.KeiryoShomeiIraiRenban = kskt11.KeiryoShomeiKekkaIraiNo ");

                sqlContent.Append("             ) ");

                sqlContent.Append("     LEFT OUTER JOIN ");

                sqlContent.Append("             (SELECT KeiryoShomeiKekkaIraiNendo, KeiryoShomeiKekkaIraiShishoCd, KeiryoShomeiKekkaIraiNo, COUNT(*) AS cnt FROM KeiryoShomeiKekkaTbl  ");
                sqlContent.Append("                                     GROUP BY KeiryoShomeiKekkaIraiNendo, KeiryoShomeiKekkaIraiShishoCd, KeiryoShomeiKekkaIraiNo) AS kskt22 ");

                sqlContent.Append("             ON ( ");
                sqlContent.Append("                 ksit.KeiryoShomeiIraiNendo = kskt22.KeiryoShomeiKekkaIraiNendo ");
                sqlContent.Append("                 AND ksit.KeiryoShomeiIraiSishoCd = kskt22.KeiryoShomeiKekkaIraiShishoCd ");
                sqlContent.Append("                 AND ksit.KeiryoShomeiIraiRenban = kskt22.KeiryoShomeiKekkaIraiNo ");

                sqlContent.Append("             ) ");

                //WHERE
                //2014.11.27 Mod kiyokuni ------ start
                //sqlContent.Append(" WHERE ksit.KeiryoShomeiStatusKbn BETWEEN 40 AND 89 ");
                //20141217 HuyTX Mod Start
                //sqlSubContent.Append(" WHERE ksit.KeiryoShomeiStatusKbn >= '40' ");
                //sqlSubContent.Append(" AND ksit.KeiryoShomeiStatusKbn < '90' ");
                sqlContent.Append(" WHERE ksit.KeiryoShomeiStatusKbn >= '40' ");
                sqlContent.Append(" AND ksit.KeiryoShomeiStatusKbn < '90' ");
                //20141217 HuyTX Mod End
                //2014.11.27 Mod kiyokuni ------ end

                if (!string.IsNullOrEmpty(kensaIraiDtFrom))
                {
                    //sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt " + DataAccessUtility.SetBetweenCommand(kensaIraiDtFrom, kensaIraiDtTo, 8));

                    sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt >= @kensaIraiDtFrom ");
                    //commandParams.Add("@kensaIraiDtFrom", SqlDbType.NVarChar).Value = kensaIraiDtFrom;
                }
                if (!string.IsNullOrEmpty(kensaIraiDtTo))
                {
                    sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt <= @kensaIraiDtTo ");
                    //commandParams.Add("@kensaIraiDtTo", SqlDbType.NVarChar).Value = kensaIraiDtTo;
                }
            }

            sqlContent.Append(" )  AS tbl ");


            /*----------WHERE-----------*/

            sqlContent.Append(" WHERE 1 = 1 ");

            if (kensaIraiHoteiKbn.Count != 0)
            {
                sqlContent.Append(" AND tbl.KensaIraiHoteiKbn IN ( " + hoteiKbn.Remove(hoteiKbn.Length - 2) + " )");
            }

            if (!string.IsNullOrEmpty(settisyaCd))
            {
                sqlContent.Append(" AND tbl.JokasoCd = @jokasoCd ");
                commandParams.Add("@jokasoCd", SqlDbType.NVarChar).Value = settisyaCd;
            }

            if (!string.IsNullOrEmpty(jokasoSetchishaNm))
            {
                sqlContent.Append(" AND tbl.JokasoSetchishaNm LIKE CONCAT('%', @jokasoSetchishaNm, '%') ");
                commandParams.Add("@jokasoSetchishaNm", SqlDbType.NVarChar).Value = jokasoSetchishaNm;
            }

            if (!string.IsNullOrEmpty(jokasoShisetsuNm))
            {
                sqlContent.Append(" AND tbl.JokasoShisetsuNm LIKE CONCAT('%', @jokasoShisetsuNm, '%') ");
                commandParams.Add("@jokasoShisetsuNm", SqlDbType.NVarChar).Value = jokasoShisetsuNm;
            }

            // Add Params
            if (!string.IsNullOrEmpty(kensaIraiDtFrom))
            {
                commandParams.Add("@kensaIraiDtFrom", SqlDbType.NVarChar).Value = kensaIraiDtFrom;

                commandParams.Add("@kensaIraiDtFromYYYY", SqlDbType.NVarChar).Value = kensaIraiDtFrom.Substring(0, 4);

                commandParams.Add("@kensaIraiDtFromMM", SqlDbType.NVarChar).Value = kensaIraiDtFrom.Substring(4, 2);

                commandParams.Add("@kensaIraiDtFromDD", SqlDbType.NVarChar).Value = kensaIraiDtFrom.Substring(6, 2);
            }

            if (!string.IsNullOrEmpty(kensaIraiDtFrom))
            {
                commandParams.Add("@kensaIraiDtTo", SqlDbType.NVarChar).Value = kensaIraiDtTo;

                commandParams.Add("@kensaIraiDtToYYYY", SqlDbType.NVarChar).Value = kensaIraiDtTo.Substring(0, 4);

                commandParams.Add("@kensaIraiDtToMM", SqlDbType.NVarChar).Value = kensaIraiDtTo.Substring(4, 2);

                commandParams.Add("@kensaIraiDtToDD", SqlDbType.NVarChar).Value = kensaIraiDtTo.Substring(6, 2);
            }

            sqlContent.Append(" ORDER BY tbl.KensaIraiHoteiKbn, ");
            sqlContent.Append("         tbl.JokasoCd1, ");
            sqlContent.Append("         tbl.JokasoCd2, ");
            sqlContent.Append("         tbl.JokasoCd3, ");
            sqlContent.Append("         tbl.KensaIraiCd1, ");
            sqlContent.Append("         tbl.KensaIraiCd2, ");
            sqlContent.Append("         tbl.KensaIraiCd3 ");

            command.CommandText = sqlContent.ToString();

            // 20141228 habu CommandTimeout追加
            command.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

            return command;
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

    #region EnkabutsuIonNodoHikakuListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EnkabutsuIonNodoHikakuListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class EnkabutsuIonNodoHikakuListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saisuiDtFrom"></param>
        /// <param name="saisuiDtTo"></param>
        /// <param name="saisuiinNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.EnkabutsuIonNodoHikakuListDataTable GetDataBySearchCond(
            string saisuiDtFrom,
            string saisuiDtTo,
            string saisuiinNm)
        {
            SqlCommand command = CreateSqlCommand(saisuiDtFrom, saisuiDtTo, saisuiinNm);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.EnkabutsuIonNodoHikakuListDataTable dataTable = new KensaIraiTblDataSet.EnkabutsuIonNodoHikakuListDataTable();
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
        /// <param name="saisuiDtFrom"></param>
        /// <param name="saisuiDtTo"></param>
        /// <param name="saisuiinNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/20　DatNT　　新規作成
        /// 2014/10/08  DatNT    v1.02
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string saisuiDtFrom,
            string saisuiDtTo,
            string saisuiinNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                                       ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSaisuiinCd,                                                                                       ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoHokenjoCd,                                                                                  ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoTorokuNendo,                                                                                ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoRenban,                                                                                     ");
            //sqlContent.Append("     CONCAT(KensaIraiTbl.KensaIraiJokasoHokenjoCd, '-',                                                                      ");
            //sqlContent.Append("            (CAST(KensaIraiTbl.KensaIraiJokasoTorokuNendo AS INT) -                                                          ");
            //sqlContent.Append("                 (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0,5) AS INT) - 1                                                    ");
            //sqlContent.Append("                  FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiJokasoTorokuNendo, '01', '01')               ");
            //sqlContent.Append("                  ORDER BY KaishiDt DESC)                                                                                    ");
            //sqlContent.Append("            ), '-',                                                                                                          ");
            //sqlContent.Append("             KensaIraiTbl.KensaIraiJokasoRenban) AS JokasoNoCol,                                                             ");
            // 2014/11/18 AnhNV Add start
            //sqlContent.Append("     CONCAT(KensaIraiTbl.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertToWareki](KensaIraiTbl.KensaIraiJokasoTorokuNendo, 'yy', 1) , '-', KensaIraiTbl.KensaIraiJokasoRenban) AS JokasoNoCol,");
            sqlContent.Append("     CONCAT(KensaIraiTbl.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](KensaIraiTbl.KensaIraiJokasoTorokuNendo) , '-', KensaIraiTbl.KensaIraiJokasoRenban) AS JokasoNoCol,");
            // 2014/11/18 AnhNV Add end
            sqlContent.Append("     KensaIraiTbl.KensaIraiSetchishaNm,                                                                                      ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiShorihoshikiKbn,                                                                                  ");

            // 2014/10/08 DatNT v1.02 MOD Start
            //sqlContent.Append("     CASE KensaIraiTbl.KensaIraiShorihoshikiKbn                                                                              ");
            //sqlContent.Append("         WHEN '1' THEN '単独'                                                                                                ");
            //sqlContent.Append("         WHEN '2' THEN '合併'                                                                                                ");
            //sqlContent.Append("         WHEN '3' THEN '小合'                                                                                                ");
            //sqlContent.Append("         ELSE '' END AS SyoriHoshikiCol,                                                                                     ");
            sqlContent.Append("     ConstMst.ConstNm AS SyoriHoshikiCol,                                                                                    ");
            // 2014/10/08 DatNT v1.02 MOD End

            sqlContent.Append("     KensaKekkaTbl.KensaKekkaSaisuiDt,                                                                                       ");

            sqlContent.Append("     CASE                                                                                                                    ");
            sqlContent.Append("         WHEN ISNULL(KensaKekkaTbl.KensaKekkaSaisuiDt, '') = '' THEN ''                                                      ");
            sqlContent.Append("         ELSE CONCAT(SUBSTRING(KensaKekkaTbl.KensaKekkaSaisuiDt, 0, 5), '/',                                                 ");
            sqlContent.Append("                     SUBSTRING(KensaKekkaTbl.KensaKekkaSaisuiDt, 5, 2), '/',                                                 ");
            sqlContent.Append("                     SUBSTRING(KensaKekkaTbl.KensaKekkaSaisuiDt, 7, 2)) END AS SaisuiDtCol,                                  ");

            sqlContent.Append("     KensaKekkaTbl.KensaKekkaEnsoIonNodo,                                                                                    ");
            sqlContent.Append("     SaiSaisuiTbl.SaiSaisuiDt,                                                                                               ");

            sqlContent.Append("     CASE                                                                                                                    ");
            sqlContent.Append("         WHEN ISNULL(SaiSaisuiTbl.SaiSaisuiDt, '') = '' THEN ''                                                              ");
            sqlContent.Append("         ELSE CONCAT(SUBSTRING(SaiSaisuiTbl.SaiSaisuiDt, 0, 5), '/',                                                         ");
            sqlContent.Append("                     SUBSTRING(SaiSaisuiTbl.SaiSaisuiDt, 5, 2), '/',                                                         ");
            sqlContent.Append("                     SUBSTRING(SaiSaisuiTbl.SaiSaisuiDt, 7, 2)) END AS SaisaisuiDtCol,                                       ");

            sqlContent.Append("     SaiSaisuiTbl.SaiSaisuiEnkaIonNodo,                                                                                      ");

            // 2015/01/13 MOD Start
            sqlContent.Append("     CASE                                                                                                                    ");
            sqlContent.Append("         WHEN SaiSaisuiTbl.SaiSaisuiEnkaIonNodo IS NULL AND KensaKekkaTbl.KensaKekkaEnsoIonNodo IS NULL                      ");
            sqlContent.Append("             THEN 0                                                                                                          ");
            sqlContent.Append("         WHEN SaiSaisuiTbl.SaiSaisuiEnkaIonNodo IS NULL AND KensaKekkaTbl.KensaKekkaEnsoIonNodo IS NOT NULL                  ");
            sqlContent.Append("             THEN (0 - CAST(KensaKekkaTbl.KensaKekkaEnsoIonNodo AS INT))                                                     ");
            sqlContent.Append("         WHEN SaiSaisuiTbl.SaiSaisuiEnkaIonNodo IS NOT NULL AND KensaKekkaTbl.KensaKekkaEnsoIonNodo IS NULL                  ");
            sqlContent.Append("             THEN (CAST(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo AS INT))                                                           ");
            sqlContent.Append("         WHEN SaiSaisuiTbl.SaiSaisuiEnkaIonNodo IS NOT NULL AND KensaKekkaTbl.KensaKekkaEnsoIonNodo IS NOT NULL              ");
            sqlContent.Append("             THEN (CAST(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo AS INT) - CAST(KensaKekkaTbl.KensaKekkaEnsoIonNodo AS INT))        ");
            sqlContent.Append("         END AS SaCol,                                                                                                       ");
            //sqlContent.Append("     CASE                                                                                                                    ");
            //sqlContent.Append("         WHEN ISNULL(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo, '') = '' AND ISNULL(KensaKekkaTbl.KensaKekkaEnsoIonNodo, '') = ''    ");
            //sqlContent.Append("             THEN 0                                                                                                          ");
            //sqlContent.Append("         WHEN ISNULL(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo, '') = '' AND ISNULL(KensaKekkaTbl.KensaKekkaEnsoIonNodo, '') <> ''   ");
            //sqlContent.Append("             THEN (0 - CAST(KensaKekkaTbl.KensaKekkaEnsoIonNodo AS INT))                                                     ");
            //sqlContent.Append("         WHEN ISNULL(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo, '') <> '' AND ISNULL(KensaKekkaTbl.KensaKekkaEnsoIonNodo, '') = ''   ");
            //sqlContent.Append("             THEN (CAST(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo AS INT))                                                       ");
            //sqlContent.Append("         WHEN ISNULL(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo, '') <> '' AND ISNULL(KensaKekkaTbl.KensaKekkaEnsoIonNodo, '') <> ''  ");
            //sqlContent.Append("             THEN (CAST(SaiSaisuiTbl.SaiSaisuiEnkaIonNodo AS INT) - CAST(KensaKekkaTbl.KensaKekkaEnsoIonNodo AS INT))        ");
            //sqlContent.Append("         END AS SaCol,                                                                                                       ");
            // 2015/01/13 MOD End

            sqlContent.Append("     SaisuiinMst.SaisuiinNm,                                                                                                 ");
            sqlContent.Append("     SaisuiinMst.SaisuiinShiteiNo,                                                                                           ");
            sqlContent.Append("     SaisuiinMst.SyozokuGyosyaCd,                                                                                            ");
            sqlContent.Append("     GyoshaMst.GyoshaNm                                                                                                      ");

            // FROM
            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     KensaIraiTbl                                                                                                            ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     KensaKekkaTbl                                                                                                           ");
            sqlContent.Append("         ON KensaKekkaTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn                                            ");
            sqlContent.Append("         AND KensaKekkaTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd                                          ");
            sqlContent.Append("         AND KensaKekkaTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo                                              ");
            sqlContent.Append("         AND KensaKekkaTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban                                             ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     SaiSaisuiTbl                                                                                                            ");
            sqlContent.Append("         ON SaiSaisuiTbl.SaiSaisuiIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn                                              ");
            sqlContent.Append("         AND SaiSaisuiTbl.SaiSaisuiIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd                                           ");
            sqlContent.Append("         AND SaiSaisuiTbl.SaiSaisuiIraiNendo = KensaIraiTbl.KensaIraiNendo                                                   ");
            sqlContent.Append("         AND SaiSaisuiTbl.SaiSaisuiIraiRrenban = KensaIraiTbl.KensaIraiRenban                                                ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     SaisuiinMst                                                                                                             ");
            sqlContent.Append("         ON SaisuiinMst.SaisuiinCd = KensaIraiTbl.KensaIraiSaisuiinCd                                                        ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     GyoshaMst                                                                                                               ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = SaisuiinMst.SyozokuGyosyaCd                                                                 ");

            // 2014/10/08 DatNT v1.02 ADD Start
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     ConstMst                                                                                                                ");
            sqlContent.Append("         ON ConstMst.ConstKbn = '022'                                                                                        ");
            sqlContent.Append("         AND ConstMst.ConstValue = KensaIraiTbl.KensaIraiShorihoshikiKbn                                                                 ");
            // 2014/10/08 DatNT v1.02 ADD End

            // WHERE
            sqlContent.Append("WHERE                                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                                   ");

            //sqlContent.Append("AND KensaKekkaTbl.KensaKekkaSaisuiDt " + DataAccessUtility.SetBetweenCommand(saisuiDtFrom, saisuiDtTo, 8));
            if (!string.IsNullOrEmpty(saisuiDtFrom))
            {
                sqlContent.Append("AND KensaKekkaTbl.KensaKekkaSaisuiDt >= @saisuiDtFrom ");
                commandParams.Add("@saisuiDtFrom", SqlDbType.NVarChar).Value = saisuiDtFrom;
            }
            if (!string.IsNullOrEmpty(saisuiDtTo))
            {
                sqlContent.Append("AND KensaKekkaTbl.KensaKekkaSaisuiDt <= @saisuiDtTo ");
                commandParams.Add("@saisuiDtTo", SqlDbType.NVarChar).Value = saisuiDtTo;
            }

            // 2014/10/08 DatNT v1.02 ADD Start
            sqlContent.Append("AND KensaIraiTbl.KensaIraiStatusKbn >= 70 AND KensaIraiTbl.KensaIraiStatusKbn < 90 ");
            // 2014/10/08 DatNT v1.02 ADD End

            if (!string.IsNullOrEmpty(saisuiinNm))
            {
                sqlContent.Append("AND SaisuiinMst.SaisuiinNm LIKE CONCAT('%', @saisuiinNm, '%') ");
                commandParams.Add("@saisuiinNm", SqlDbType.NVarChar).Value = saisuiinNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY                                                                                                                     ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSaisuiinCd,                                                                                       ");
            sqlContent.Append("     SaisuiinMst.SaisuiinNm                                                                                                  ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaTorisageListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaTorisageListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaTorisageListTableAdapter
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
        /// 2014/08/25　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.KensaTorisageListDataTable GetDataBySearchCond(KensaIraiTblSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.KensaTorisageListDataTable dataTable = new KensaIraiTblDataSet.KensaTorisageListDataTable();
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
        /// 2014/08/25　HuyTX　　新規作成
        /// 2014/10/02　HuyTX　　Ver1.05
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// 2014/12/28　habu　　 件数制限追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaIraiTblSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT ");
            // 20141228 habu 件数制限追加
            sqlContent.Append(" TOP 2000 ");
            // 20141228 End
            sqlContent.Append("         '0' AS SelectChk, ");
            sqlContent.Append("         '0' AS GesuiChk, ");
            sqlContent.Append("         '0' AS HaishiChk, ");
            sqlContent.Append("         '0' AS GyohenChk, ");
            sqlContent.Append("         '0' AS HokaChk, ");
            sqlContent.Append("         ROW_NUMBER() OVER(ORDER BY KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban ASC) AS RowNumber, ");
            sqlContent.Append("         kit.KensaIraiHoteiKbn, ");
            sqlContent.Append("         kit.KensaIraiHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiNendo, ");
            sqlContent.Append("         kit.KensaIraiRenban, ");
            sqlContent.Append("         cm.ConstNm, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', REPLACE(STR(kit.KensaIraiNendo - (SELECT TOP(1)CAST(SUBSTRING(KaishiDt,0,5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiRenban) AS KensaIraiNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiNendo,'yy',1), '-', kit.KensaIraiRenban) AS KensaIraiNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo), '-', kit.KensaIraiRenban) AS KensaIraiNo, ");
            sqlContent.Append("         kit.KensaIraiSetchishaNm, ");
            sqlContent.Append("         kit.KensaIraiSetchibashoAdr, ");
            sqlContent.Append("         kit.KensaIraiShoritaishoJinin, ");
            sqlContent.Append("         shm.ShoriHoshikiShubetsuNm, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', REPLACE(STR(kit.KensaIraiJokasoTorokuNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiJokasoTorokuNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiJokasoRenban) AS JokasoNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiJokasoTorokuNendo, 'yy', 1), '-', kit.KensaIraiJokasoRenban) AS JokasoNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiJokasoTorokuNendo), '-', kit.KensaIraiJokasoRenban) AS JokasoNo, ");
            sqlContent.Append("         kit.KensaIraiKensaTantoshaCd, ");
            sqlContent.Append("         kit.UpdateDt, ");
            sqlContent.Append("         kit.KensaIraiJokasoHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiJokasoTorokuNendo, ");
            sqlContent.Append("         kit.KensaIraiJokasoRenban ");

            //FROM 
            sqlContent.Append(" FROM KensaIraiTbl kit ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm  ");
            sqlContent.Append("                     ON kit.KensaIraiHoteiKbn = cm.ConstValue  ");
            sqlContent.Append("                     AND cm.ConstKbn = '006' ");
            sqlContent.Append("     LEFT OUTER JOIN ShoriHoshikiMst shm  ");
            sqlContent.Append("                     ON kit.KensaIraiShorihoshikiKbn = shm.ShoriHoshikiKbn  ");
            sqlContent.Append("                     AND kit.KensaIraiShorihoshikiCd = shm.ShoriHoshikiCd ");
            sqlContent.Append("     LEFT OUTER JOIN ShokuinMst sm ");
            sqlContent.Append("                     ON kit.KensaIraiKensaTantoshaCd = sm.ShokuinCd ");

            //WHERE
            //sqlContent.Append(" WHERE RTRIM(LTRIM(kit.KensaIraiHakkoKbn10)) <> '1'  ");
            // 20141228 habu
            sqlContent.Append(" WHERE (kit.KensaIraiStatusKbn < '50' OR kit.KensaIraiStatusKbn = '90' ) ");
            //sqlContent.Append(" WHERE (kit.KensaIraiStatusKbn < 50 OR kit.KensaIraiStatusKbn = '90' ) ");
            // 20141228 End
            
            //検査責任者 
            if (!string.IsNullOrEmpty(searchCond.KensaIraiKensaTantoshaCd))
            {
                sqlContent.Append(" AND kit.KensaIraiKensaTantoshaCd = @kensaIraiKensaTantoshaCd ");
                commandParams.Add("@kensaIraiKensaTantoshaCd", SqlDbType.NVarChar).Value = searchCond.KensaIraiKensaTantoshaCd;
            }

            //検査依頼法定区分 
            if (!string.IsNullOrEmpty(searchCond.KensaIraiHoteiKbn))
            {
                sqlContent.Append(" AND kit.KensaIraiHoteiKbn = @kensaIraiHoteiKbn ");
                commandParams.Add("@kensaIraiHoteiKbn", SqlDbType.NVarChar).Value = searchCond.KensaIraiHoteiKbn;
            }

            //協会No (保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                //sqlContent.Append(" AND kit.KensaIraiHokenjoCd " + DataAccessUtility.SetBetweenCommand(searchCond.HokenjoCdFrom, searchCond.HokenjoCdTo, 2));
                sqlContent.Append(" AND kit.KensaIraiHokenjoCd >= @HokenjoCdFrom ");
                commandParams.Add("@HokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                sqlContent.Append(" AND kit.KensaIraiHokenjoCd <= @HokenjoCdTo ");
                commandParams.Add("@HokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            //協会No (年度)
            if (!string.IsNullOrEmpty(searchCond.NendoFrom) || !string.IsNullOrEmpty(searchCond.NendoTo))
            {
                //MOD_20141117_HuyTX Start
                //sqlContent.Append(" AND (kit.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC)) " + DataAccessUtility.SetBetweenCommand(searchCond.NendoFrom, searchCond.NendoTo, 2));
                string nendoFrom = !string.IsNullOrEmpty(searchCond.NendoFrom) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoFrom, "yyyy") : string.Empty;
                string nendoTo = !string.IsNullOrEmpty(searchCond.NendoTo) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoTo, "yyyy") : string.Empty;

                //sqlContent.Append(" AND kit.KensaIraiNendo " + DataAccessUtility.SetBetweenCommand(nendoFrom, nendoTo, 4));
                if (!string.IsNullOrEmpty(nendoFrom))
                {
                    sqlContent.Append(" AND kit.KensaIraiNendo >= @nendoFrom ");
                    commandParams.Add("@nendoFrom", SqlDbType.NVarChar).Value = nendoFrom;
                }
                if (!string.IsNullOrEmpty(nendoTo))
                {
                    sqlContent.Append(" AND kit.KensaIraiNendo <= @nendoTo ");
                    commandParams.Add("@nendoTo", SqlDbType.NVarChar).Value = nendoTo;
                }
                //MOD_20141117_HuyTX End
            }

            //協会No (連番)
            if (!string.IsNullOrEmpty(searchCond.RenbanFrom))
            {
                //sqlContent.Append(" AND kit.KensaIraiRenban " + DataAccessUtility.SetBetweenCommand(searchCond.RenbanFrom, searchCond.RenbanTo, 6));
                sqlContent.Append(" AND kit.KensaIraiRenban >= @RenbanFrom ");
                commandParams.Add("@RenbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append(" AND kit.KensaIraiRenban <= @RenbanTo ");
                commandParams.Add("@RenbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }

            //設置者名（漢字） 
            if (!string.IsNullOrEmpty(searchCond.KensaIraiSetchishaNm))
            {
                sqlContent.Append(" AND kit.KensaIraiSetchishaNm LIKE CONCAT('%', @kensaIraiSetchishaNm, '%') ");
                commandParams.Add("@kensaIraiSetchishaNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.KensaIraiSetchishaNm);
            }

            //検査依頼設置場所（住所）
            if (!string.IsNullOrEmpty(searchCond.KensaIraiSetchibashoAdr))
            {
                sqlContent.Append(" AND kit.KensaIraiSetchibashoAdr LIKE CONCAT('%', @kensaIraiSetchibashoAdr, '%') ");
                commandParams.Add("@kensaIraiSetchibashoAdr", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.KensaIraiSetchibashoAdr);
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append(" kit.KensaIraiHokenjoCd, ");
            sqlContent.Append(" kit.KensaIraiNendo, ");
            sqlContent.Append(" kit.KensaIraiRenban ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaYoteiListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaYoteiListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaYoteiListTableAdapter
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
        /// 2014/09/03　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.KensaYoteiListDataTable GetDataBySearchCond(KensaYoteiListSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.KensaYoteiListDataTable dataTable = new KensaIraiTblDataSet.KensaYoteiListDataTable();
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
        /// 2014/09/03　DatNT　　新規作成
        /// 2014/10/20  DatNT    v1.02
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// 2014/12/26　habu　　 件数制限対応
        /// 2015/01/13　HuyTX　　 Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaYoteiListSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region SELECT

            // 20141226 habu Mod 件数制限対応
            sqlContent.Append("SELECT TOP 2000                                                                                                              ");
            //sqlContent.Append("SELECT                                                                                                                       ");
            // 20141226 End
            sqlContent.Append("     ROW_NUMBER() OVER(ORDER BY                                                                                              ");

            if (searchCond.OutputOrder == "1")
            {
                sqlContent.Append("     KensaIraiTbl.KensaIraiSetchibashoAdr,                                                                               ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                    ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban) AS RowNumber,                                                                         ");
            }
            else if (searchCond.OutputOrder == "2")
            {
                sqlContent.Append("     JokasoDaichoMst.JokasoChizuNo,                                                                                      ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                    ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban) AS RowNumber,                                                                         ");
            }
            else if (searchCond.OutputOrder == "3")
            {
                sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiNen,                                                                                ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiTsuki,                                                                              ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiBi,                                                                                 ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                    ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban) AS RowNumber,                                                                         ");
            }
            else if (searchCond.OutputOrder == "4")
            {
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                    ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban) AS RowNumber,                                                                         ");
            }

            sqlContent.Append("     0 AS SelectCol,                                                                                                         ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHoteiKbn,                                                                                         ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                        ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                            ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiRenban,                                                                                           ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoHokenjoCd,                                                                                  ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoTorokuNendo,                                                                                ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoRenban,                                                                                     ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSetchibashoAdr,                                                                                   ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiNen,                                                                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiTsuki,                                                                                  ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiBi,                                                                                     ");

            sqlContent.Append("     CASE                                                                                                                    ");
            sqlContent.Append("         WHEN ISNULL(KensaIraiTbl.KensaIraiKensaYoteiNen, '') = ''                                                           ");
            sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiKensaYoteiTsuki, '') = ''                                                  ");
            sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiKensaYoteiBi, '') = ''                                                     ");
            sqlContent.Append("         THEN ''                                                                                                             ");
            // 2014/10/20 DatNT v1.02 MOD Start
            //sqlContent.Append("         ELSE CONCAT(CAST(KensaIraiTbl.KensaIraiKensaYoteiNen AS INT) - 1988,                                                ");
            sqlContent.Append("         ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen,                                                                    ");
            // 2014/10/20 DatNT v1.02 MOD End
            sqlContent.Append("                         '/', KensaIraiTbl.KensaIraiKensaYoteiTsuki,                                                         ");
            sqlContent.Append("                         '/', KensaIraiTbl.KensaIraiKensaYoteiBi)                                                            ");
            sqlContent.Append("         END AS yoteiDtCol,                                                                                                  ");

            //sqlContent.Append("     CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                            ");
            //sqlContent.Append("             CAST(KensaIraiTbl.KensaIraiNendo AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), '-', ");
            //sqlContent.Append("             KensaIraiTbl.KensaIraiRenban) AS kyokaiNoCol,                                                                   ");

            sqlContent.Append("     CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                            ");
            sqlContent.Append("             [dbo].[FuncConvertIraiNedoToWareki](KensaIraiTbl.KensaIraiNendo), '-',                                          ");
            sqlContent.Append("             KensaIraiTbl.KensaIraiRenban) AS kyokaiNoCol,                                                                   ");

            sqlContent.Append("     KensaIraiTbl.KensaIraiSetchishaNm,                                                                                      ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSetchishaKana,                                                                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiShoritaishoJinin,                                                                                 ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiShorihoshikiKbn,                                                                                  ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKojiGyoshaCd,                                                                                     ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHoshutenkenGyoshaCd,                                                                              ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHagakiInsatsuzumiKbn,                                                                             ");
            sqlContent.Append("     CASE WHEN KensaIraiTbl.KensaIraiHagakiInsatsuzumiKbn = '1' THEN '済' ELSE '' END AS hagakiCol,                          ");
            sqlContent.Append("     KensaIraiTbl.UpdateDt AS KensaIraiTblUpdateDt,                                                                          ");

            sqlContent.Append("     JokasoDaichoMst.JokasoHokenjoCd,                                                                                        ");
            sqlContent.Append("     JokasoDaichoMst.JokasoTorokuNendo,                                                                                      ");
            sqlContent.Append("     JokasoDaichoMst.JokasoRenban,                                                                                           ");
            sqlContent.Append("     JokasoDaichoMst.UpdateDt AS JokasoDaichoMstUpdateDt,                                                                    ");
            sqlContent.Append("     JokasoDaichoMst.JokasoChizuNo,                                                                                          ");
            sqlContent.Append("     JokasoDaichoMst.JokasoHagakiKbn,                                                                                        ");
            sqlContent.Append("     ShoriHoshikiMst.ShoriHoshikiShubetsuNm,                                                                                 ");
            sqlContent.Append("     ConstMst.ConstNm,                                                                                                       ");
            sqlContent.Append("     GyoshaMst.GyoshaNm,                                                                                                     ");

            /////////////////
            sqlContent.Append("     JokasoDaichoMst.JokasoHagakiSoufusakiKbn,                                                                               ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSetchiBashoZipCd,                                                                                 ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSoufusakiZipCd,                                                                                   ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSeikyusakiZipCd,                                                                                  ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSetchishaZipCd,                                                                                   ");
            sqlContent.Append("     JokasoDaichoMst.JokasoRenrakusakiZipCd,                                                                                 ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSetchiBashoAdr,                                                                                   ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSoufusakiAdr,                                                                                     ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSeikyusakiAdr,                                                                                    ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSetchishaAdr,                                                                                     ");
            sqlContent.Append("     JokasoDaichoMst.JokasoRenrakusakiAdr,                                                                                   ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSetchishaNm,                                                                                      ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSoufusakiNm,                                                                                      ");
            sqlContent.Append("     JokasoDaichoMst.JokasoSeikyusakiNm,                                                                                     ");
            sqlContent.Append("     JokasoDaichoMst.JokasoRenrakusakiNm,                                                                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiShichosonSetchigata,                                                                              ");
            sqlContent.Append("     ChikuMst.ChikuNm,                                                                                                       ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiGokeiAmt,                                                                                         ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiNyukinzumiAmt,                                                                                    ");
            sqlContent.Append("     (CASE                                                                                                                   ");
            sqlContent.Append("          WHEN ISDATE(CONCAT(KensaIraiTbl.KensaIraiKensaNen,KensaIraiTbl.KensaIraiKensaTsuki,KensaIraiTbl.KensaIraiKensaBi)) = 0 THEN '' ");
            sqlContent.Append("          ELSE CONVERT(CHAR(10), CONVERT(DATETIME,CONCAT(KensaIraiTbl.KensaIraiKensaNen,KensaIraiTbl.KensaIraiKensaTsuki,KensaIraiTbl.KensaIraiKensaBi)), 111) ");
            sqlContent.Append("     END) AS KensaDt,                                                                                                        ");
            sqlContent.Append("     ShishoMst.ShishoNm,                                                                                                     ");
            sqlContent.Append("     ShishoMst.ShishoAdr,                                                                                                    ");
            sqlContent.Append("     ShishoMst.ShishoFreeDial,                                                                                               ");
            sqlContent.Append("     ShokuinMst.ShokuinNm,                                                                                                   ");
            sqlContent.Append("     ShishoMst.ShishoFaxNo,                                                                                                  ");
            sqlContent.Append("     ShishoMst.ShishoTelNo,                                                                                                  ");
            sqlContent.Append("     gm.GyoshaNm AS IkkatsuSeikyusakiNm                                                                                      ");

            ///////////////////

            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     KensaIraiTbl                                                                                                            ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     JokasoDaichoMst                                                                                                         ");
            sqlContent.Append("         ON JokasoDaichoMst.JokasoHokenjoCd = KensaIraiTbl.KensaIraiJokasoHokenjoCd                                          ");
            sqlContent.Append("         AND JokasoDaichoMst.JokasoTorokuNendo = KensaIraiTbl.KensaIraiJokasoTorokuNendo                                     ");
            sqlContent.Append("         AND JokasoDaichoMst.JokasoRenban = KensaIraiTbl.KensaIraiJokasoRenban                                               ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     ShoriHoshikiMst                                                                                                         ");
            sqlContent.Append("         ON ShoriHoshikiMst.ShoriHoshikiKbn = KensaIraiTbl.KensaIraiShorihoshikiKbn                                          ");
            sqlContent.Append("         AND ShoriHoshikiMst.ShoriHoshikiCd = KensaIraiTbl.KensaIraiShorihoshikiCd                                           ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     ConstMst                                                                                                                ");
            sqlContent.Append("         ON ConstMst.ConstKbn = '020'                                                                                        ");
            sqlContent.Append("         AND ConstMst.ConstValue = JokasoDaichoMst.JokasoHagakiKbn                                                           ");

            //ADD_HuyTX_20101031_Ver1.03 Start
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const1                                                                                             ");
            sqlContent.Append("         ON const1.ConstValue = KensaIraiTbl.KensaIraiScreeningKbn                                                           ");
            sqlContent.Append("         AND const1.ConstKbn = '024'                                                                                         ");
            
            //ADD_HuyTX_20101031_Ver1.03 End

            if (searchCond.KensaIraiHoteiKbn == "1")
            {
                sqlContent.Append("LEFT OUTER JOIN                                                                                                          ");
                sqlContent.Append("     GyoshaMst                                                                                                           ");
                sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiKojiGyoshaCd                                                      ");
            }
            else if (searchCond.KensaIraiHoteiKbn == "2")
            {
                sqlContent.Append("LEFT OUTER JOIN                                                                                                          ");
                sqlContent.Append("     GyoshaMst                                                                                                           ");
                sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiHoshutenkenGyoshaCd                                               ");
            }

            /////////////////////

            sqlContent.Append(" LEFT OUTER JOIN ChikuMst ON ChikuMst.ChikuCd = KensaIraiTbl.KensaIraiGenChikuCd                                             ");
            sqlContent.Append(" LEFT OUTER JOIN ShokuinMst ON KensaIraiTbl.KensaIraiKensaTantoshaCd = ShokuinMst.ShokuinCd                                  ");
            sqlContent.Append(" LEFT OUTER JOIN ShishoMst ON ShokuinMst.ShokuinShozokuShishoCd = ShishoMst.ShishoCd                                         ");
            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst gm ON gm.GyoshaCd = KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd                                     ");
            /////////////////////

            #endregion

            #region WHERE

            sqlContent.Append("WHERE                                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                                   ");

            // 20141226 habu Mod 
            sqlContent.Append("AND KensaIraiTbl.KensaIraiStatusKbn >= '20'                                                                                  ");
            sqlContent.Append("AND KensaIraiTbl.KensaIraiStatusKbn <  '90'                                                                                  ");
            // 20141226 End
            // Start Ver1.01条件変更
            //sqlContent.Append("AND KensaIraiTbl.KensaIraiStatusKbn >= 20                                                                                  ");
            //sqlContent.Append("AND KensaIraiTbl.KensaIraiStatusKbn <  90                                                                                  ");
            // End Ver1.01条件変更

            // 検査員
            if (!string.IsNullOrEmpty(searchCond.ShokuinCd))
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiKensaTantoshaCd = @shokuinCd ");
                commandParams.Add("@shokuinCd", SqlDbType.NVarChar).Value = searchCond.ShokuinCd;
            }

            // 検査種別
            if (searchCond.KensaIraiHoteiKbn == "1")
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = '1' ");
            }
            else if (searchCond.KensaIraiHoteiKbn == "2")
            {
                //MOD_HuyTX_20101031_Ver1.03 Start
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = '2' ");
                sqlContent.Append(" AND (KensaIraiTbl.KensaIraiHoteiKbn ='2' ");
                sqlContent.Append("         OR (KensaIraiTbl.KensaIraiHoteiKbn = '3' AND KensaIraiTbl.KensaIraiScreeningKbn <> '0')) ");
                //MOD_HuyTX_20101031_Ver1.03 End
            }

            // 協会No (保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                //sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd " + DataAccessUtility.SetBetweenCommand(searchCond.HokenjoCdFrom, searchCond.HokenjoCdTo, 2) + " ");

                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd >= @HokenjoCdFrom ");
                commandParams.Add("@HokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd <= @HokenjoCdTo ");
                commandParams.Add("@HokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            // 協会No (年度)
            if (!string.IsNullOrEmpty(searchCond.NendoFrom))
            {
                //sqlContent.Append(" AND (KensaIraiTbl.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT('2014', '01', '01') ORDER BY KaishiDt DESC)) " + DataAccessUtility.SetBetweenCommand(searchCond.NendoFrom, searchCond.NendoTo, 2) + " ");
                //sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo " + DataAccessUtility.SetBetweenCommand(searchCond.NendoFrom, searchCond.NendoTo, 4) + " ");

                sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo >= @NendoFrom ");
                commandParams.Add("@NendoFrom", SqlDbType.NVarChar).Value = searchCond.NendoFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.NendoTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo <= @NendoTo ");
                commandParams.Add("@NendoTo", SqlDbType.NVarChar).Value = searchCond.NendoTo;
            }

            // 協会No (連番)
            if (!string.IsNullOrEmpty(searchCond.RenbanFrom))
            {
                //sqlContent.Append(" AND KensaIraiTbl.KensaIraiRenban " + DataAccessUtility.SetBetweenCommand(searchCond.RenbanFrom, searchCond.RenbanTo, 6) + " ");

                sqlContent.Append(" AND KensaIraiTbl.KensaIraiRenban >= @RenbanFrom ");
                commandParams.Add("@RenbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiRenban <= @RenbanTo ");
                commandParams.Add("@RenbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }

            // 検査予定日検索使用フラグ
            if (searchCond.KensaYoteiDtUse)
            {
                if (searchCond.KensaMitei)
                {
                    sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki)  >= @kensaYoteiDtFrom ");
                    commandParams.Add("@kensaYoteiDtFrom", SqlDbType.NVarChar).Value = searchCond.KensaYoteiDtFrom.Substring(0, 6);

                    sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki)  <= @kensaYoteiDtTo ");
                    commandParams.Add("@kensaYoteiDtTo", SqlDbType.NVarChar).Value = searchCond.KensaYoteiDtTo.Substring(0, 6);
                }
                else
                {
                    sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki, KensaIraiTbl.KensaIraiKensaYoteiBi)  >= @kensaYoteiDtFrom ");
                    commandParams.Add("@kensaYoteiDtFrom", SqlDbType.NVarChar).Value = searchCond.KensaYoteiDtFrom;

                    sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki, KensaIraiTbl.KensaIraiKensaYoteiBi)  <= @kensaYoteiDtTo ");
                    commandParams.Add("@kensaYoteiDtTo", SqlDbType.NVarChar).Value = searchCond.KensaYoteiDtTo;
                }
            }

            // 設置住所
            if (!string.IsNullOrEmpty(searchCond.SettiAdr))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiSetchibashoAdr LIKE CONCAT('%', @SettiAdr, '%') ");
                commandParams.Add("@SettiAdr", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.SettiAdr);
            }

            // 設置者カナ
            if (!string.IsNullOrEmpty(searchCond.SettisyaKanaFrom))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiSetchishaKana >= @SettisyaKanaFrom ");
                commandParams.Add("@SettisyaKanaFrom", SqlDbType.NVarChar).Value = searchCond.SettisyaKanaFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.SettisyaKanaTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiSetchishaKana <= @SettisyaKanaTo ");
                commandParams.Add("@SettisyaKanaTo", SqlDbType.NVarChar).Value = searchCond.SettisyaKanaTo;
            }

            // 依頼業者
            if (!string.IsNullOrEmpty(searchCond.GyoshaNm))
            {
                sqlContent.Append(" AND GyoshaMst.GyoshaNm LIKE CONCAT('%', @GyoshaNm, '%') ");
                commandParams.Add("@GyoshaNm", SqlDbType.NVarChar).Value = searchCond.GyoshaNm;
            }

            // 人槽
            if (!string.IsNullOrEmpty(searchCond.NinsoFrom))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiShoritaishoJinin >= @ninsoFrom  ");
                commandParams.Add("@ninsoFrom", SqlDbType.NVarChar).Value = searchCond.NinsoFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.NinsoTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiShoritaishoJinin <= @ninsoTo  ");
                commandParams.Add("@ninsoTo", SqlDbType.NVarChar).Value = searchCond.NinsoTo;
            }

            //Ver1.04 start
            if (!string.IsNullOrEmpty(searchCond.Shikuchoson))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiGenChikuCd = @shikuchoson ");
                commandParams.Add("@shikuchoson", SqlDbType.NVarChar).Value = searchCond.Shikuchoson;
            }
            //End

            #endregion

            #region ORDER BY

            sqlContent.Append("ORDER BY                                                                                                                         ");

            if (searchCond.OutputOrder == "1")
            {
                sqlContent.Append("     KensaIraiTbl.KensaIraiSetchibashoAdr,                                                                                   ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                            ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban                                                                                            ");
            }
            else if (searchCond.OutputOrder == "2")
            {
                sqlContent.Append("     JokasoDaichoMst.JokasoChizuNo,                                                                                          ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                            ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban                                                                                            ");
            }
            else if (searchCond.OutputOrder == "3")
            {
                sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiNen,                                                                                    ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiTsuki,                                                                                  ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiBi,                                                                                     ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                            ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban                                                                                            ");
            }
            else if (searchCond.OutputOrder == "4")
            {
                sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                        ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                            ");
                sqlContent.Append("     KensaIraiTbl.KensaIraiRenban                                                                                            ");
            }
            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Jo7KensaIraiListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Jo7KensaIraiListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class Jo7KensaIraiListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiDtFrom"></param>
        /// <param name="kensaIraiDtTo"></param>
        /// <param name="isCheckKensaIraiSofuDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.Jo7KensaIraiListDataTable GetDataBySearchCond(string kensaIraiDtFrom, string kensaIraiDtTo, bool isCheckKensaIraiSofuDt)
        {
            SqlCommand command = CreateSqlCommand(kensaIraiDtFrom, kensaIraiDtTo, isCheckKensaIraiSofuDt);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.Jo7KensaIraiListDataTable dataTable = new KensaIraiTblDataSet.Jo7KensaIraiListDataTable();
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
        /// <param name="kensaIraiDtFrom"></param>
        /// <param name="kensaIraiDtTo"></param>
        /// <param name="isCheckKensaIraiSofuDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04　HuyTX　　新規作成
        /// 2014/12/28　habu　　件数制限追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string kensaIraiDtFrom, string kensaIraiDtTo, bool isCheckKensaIraiSofuDt)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT  ");
            // 20141228 habu Add
            sqlContent.Append(" TOP 2000 ");
            // 20141228 End
            sqlContent.Append("         '0' AS SelectFlg, ");
            sqlContent.Append("         kit.KensaIraiNen, ");
            sqlContent.Append("         kit.KensaIraiTsuki, ");
            sqlContent.Append("         kit.KensaIraiBi, ");
            sqlContent.Append("         kit.KensaIraiHoteiKbn, ");
            sqlContent.Append("         kit.KensaIraiHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiNendo, ");
            sqlContent.Append("         kit.KensaIraiRenban, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', REPLACE(STR(kit.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiRenban) AS KyokaiNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiNendo, 'yy', 1), '-', kit.KensaIraiRenban) AS KyokaiNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo), '-', kit.KensaIraiRenban) AS KyokaiNo, ");
            sqlContent.Append("         kit.KensaIraiSetchishaNm, ");
            sqlContent.Append("         kit.KensaIraiSetchishaAdr, ");
            sqlContent.Append("         kit.KensaIraiSetchibashoAdr, ");
            sqlContent.Append("         CASE  ");
            sqlContent.Append("             WHEN ISDATE(CONCAT(kit.KensaIraiNen,kit.KensaIraiTsuki,kit.KensaIraiBi)) = 0 then ''  ");
            sqlContent.Append("            ELSE CONCAT(kit.KensaIraiNen, '/', kit.KensaIraiTsuki, '/', kit.KensaIraiBi) ");
            sqlContent.Append("         END AS KensaIraiDt, ");
            //sqlContent.Append("         CASE ");
            //sqlContent.Append("            WHEN ISDATE(kit.KensaIraiSofuDt) = 0 THEN '' ");
            //sqlContent.Append("            ELSE CONVERT(CHAR(10), CONVERT(DATETIME, kit.KensaIraiSofuDt), 111) ");
            //sqlContent.Append("         END AS KensaIraiSofuDt, ");
            sqlContent.Append("         hoshuGM.GyoshaZipCd, ");
            sqlContent.Append("         hoshuGM.GyoshaAdr, ");
            sqlContent.Append("         hoshuGM.GyoshaNm AS HoshugyoshaNm, ");
            sqlContent.Append("         kit.KensaIraiHoshutenkenGyoshaCd, ");
            sqlContent.Append("         jdm.JokasoHoshuyoteiGyoshaCd, ");
            sqlContent.Append("         cm.ChikuNm, ");
            sqlContent.Append("         kit.KensaIraiShoritaishoJinin, ");
            //sqlContent.Append("         nm.Name, ");
            sqlContent.Append("         const.ConstNm AS Name, ");
            sqlContent.Append("         shm.ShoriHoshikiNm, ");

            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kit.KensaIraiShiyoKaishiNen, '') = '' THEN '' ");
            sqlContent.Append("             WHEN ISNULL(kit.KensaIraiShiyoKaishiTsuki, '') = '' THEN '' ");
            sqlContent.Append("             ELSE CONCAT(kit.KensaIraiShiyoKaishiNen, kit.KensaIraiShiyoKaishiTsuki, '01') ");
            sqlContent.Append("         END AS KensaIraiShiyoKaishiYM, ");

            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoJyuriHokenjoCd, '-', kit.KensaIraiHokenjoJyuriNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiHokenjoJyuriNendo, '01', '01') ORDER BY KaishiDt DESC), '-', kit.KensaIraiHokenjoJyuriShichosonCd, '-', kit.KensaIraiHokenjoJyuriRenban) AS HokenjyoUketukeNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoJyuriHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiHokenjoJyuriNendo, 'yy', 1), '-', kit.KensaIraiHokenjoJyuriRenban) AS HokenjyoUketukeNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoJyuriHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiHokenjoJyuriNendo),'-', kit.KensaIraiHokenjoJyuriShichosonCd, '-', kit.KensaIraiHokenjoJyuriRenban) AS HokenjyoUketukeNo, ");
            sqlContent.Append("         kojiGM.GyoshaNm AS KojigyoshaNm, ");
            sqlContent.Append("         kit.UpdateDt, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriNendo, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriShichosonCd, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriRenban ");

            //FROM
            sqlContent.Append(" FROM KensaIraiTbl kit ");

            //JOIN
            sqlContent.Append("     LEFT OUTER JOIN JokasoDaichoMst jdm ");
            sqlContent.Append("                     ON kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            sqlContent.Append("                     AND kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            sqlContent.Append("                     AND kit.KensaIraiJokasoRenban = jdm.JokasoRenban ");

            //ADD_Ver1.05 Start
            sqlContent.Append("     LEFT OUTER JOIN GyoshaMst hoshuGM  ");
            sqlContent.Append("                     ON jdm.JokasoHoshuyoteiGyoshaCd = hoshuGM.GyoshaCd ");
            //ADD_Ver1.05 End

            sqlContent.Append("     LEFT OUTER JOIN ChikuMst cm ");
            sqlContent.Append("                     ON cm.ChikuCd = jdm.JokasoGenChikuCd ");

            //sqlContent.Append("     LEFT OUTER JOIN NameMst nm ");
            //sqlContent.Append("                     ON RIGHT(nm.NameCd, 1) = kit.KensaIraiShorihoshikiKbn ");
            //sqlContent.Append("                     AND nm.NameKbn = '007' ");

            sqlContent.Append("     LEFT OUTER JOIN ConstMst const ");
            sqlContent.Append("                     ON const.ConstValue = kit.KensaIraiShorihoshikiKbn ");
            sqlContent.Append("                     AND const.ConstKbn = '022' ");

            sqlContent.Append("     LEFT OUTER JOIN ShoriHoshikiMst shm ");
            sqlContent.Append("                     ON shm.ShoriHoshikiKbn = kit.KensaIraiShorihoshikiKbn ");
            sqlContent.Append("                     AND shm.ShoriHoshikiCd = kit.KensaIraiShorihoshikiCd ");

            sqlContent.Append("     LEFT OUTER JOIN GyoshaMst As kojiGM ");
            sqlContent.Append("                     ON kojiGM.GyoshaCd = kit.KensaIraiKojiGyoshaCd ");

            //WHERE
            // 20141229 7条件依頼画面としては00のみを対象とする -> 検査依頼一覧画面を別画面として実装を検討
            sqlContent.Append(" WHERE kit.KensaIraiHoteiKbn = '1' AND kit.KensaIraiStatusKbn = '00' ");

            if (!string.IsNullOrEmpty(kensaIraiDtFrom))
            {
                //sqlContent.Append(" AND CONCAT(REPLACE(STR(kit.KensaIraiNen, 4), SPACE(1), '0'), REPLACE(STR(kit.KensaIraiTsuki, 2), SPACE(1), '0'), REPLACE(STR(kit.KensaIraiBi, 2), SPACE(1), '0')) " + DataAccessUtility.SetBetweenCommand(kensaIraiDtFrom, kensaIraiDtTo, 8));
                //sqlContent.Append(" AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi) " + DataAccessUtility.SetBetweenCommand(kensaIraiDtFrom, kensaIraiDtTo, 8));

                sqlContent.Append("AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi) >= @kensaIraiDtFrom ");
                commandParams.Add("@kensaIraiDtFrom", SqlDbType.NVarChar).Value = kensaIraiDtFrom;                
            }
            if (!string.IsNullOrEmpty(kensaIraiDtTo))
            {
                sqlContent.Append("AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi) <= @kensaIraiDtTo ");
                commandParams.Add("@kensaIraiDtTo", SqlDbType.NVarChar).Value = kensaIraiDtTo;
            }

            //if (!isCheckKensaIraiSofuDt)
            //{
            //    sqlContent.Append(" AND ISNULL(kit.KensaIraiSofuDt, '') <> '' ");
            //}

            //ORDER BY
            sqlContent.Append(" ORDER BY kit.KensaIraiHoteiKbn, ");
            sqlContent.Append("             kit.KensaIraiHokenjoCd, ");
            sqlContent.Append("             kit.KensaIraiNendo, ");
            sqlContent.Append("             kit.KensaIraiRenban ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaNippoInputTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaNippoInputTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaNippoInputTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaDt"></param>
        /// <param name="kensainCd"></param>
        /// <param name="mode">1: ADD, 2: EDIT/NON-EDIT</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.KensaNippoInputDataTable GetDataByKensaDtKensainCd(DateTime kensaDt, string kensainCd, string mode)
        {
            SqlCommand command = CreateSqlCommand(kensaDt, kensainCd, mode);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.KensaNippoInputDataTable dataTable = new KensaIraiTblDataSet.KensaNippoInputDataTable();
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
        /// <param name="kensaDt"></param>
        /// <param name="kensainCd"></param>
        /// <param name="mode">1: ADD, 2: EDIT/NON-EDIT</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　AnhNV　　 新規作成
        /// 2014/11/20　AnhNV　　 基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(DateTime kensaDt, string kensainCd, string mode)
        {
			String nendoStr = String.Empty;
			nendoStr = Utility.DateUtility.GetNendo(kensaDt).ToString();

            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" select                                                                                                                                  ");
            sqlContent.AppendLine("     kit.KensaIraiSeikyuKbn,                                                                                                             ");
            sqlContent.AppendLine("     kit.KensaIraiStatusKbn,                                                                                                             ");
            sqlContent.AppendLine("     ndt.NippoDtlRenban,                                                                                                                 ");
            sqlContent.AppendLine("     kit.KensaIraiHoteiKbn,                                                                                                              ");
            sqlContent.AppendLine("     kit.KensaIraiHokenjoCd,                                                                                                             ");
            sqlContent.AppendLine("     kit.KensaIraiNendo,                                                                                                                 ");
            sqlContent.AppendLine("     kit.KensaIraiRenban,                                                                                                                ");
            sqlContent.AppendLine("     sm1.ShokuinNm as Kensain,                                                                                                           ");
            sqlContent.AppendLine("     sm2.ShokuinCd as Hojoin,                                                                                                            ");
			// 受入20141219 mod sta 検査種別名スクリーニング区分に応じて取得を分ける
			//sqlContent.AppendLine("     cm1.ConstNm as KensaSyubetsu,                                                                                                       ");
			sqlContent.AppendLine("     case                                                                                                                                ");
			sqlContent.AppendLine("         when kit.KensaIraiScreeningKbn = '0' then cm1.ConstNm                                                                           ");
			sqlContent.AppendLine("         else cm5.ConstNm                                                                                                                ");
			sqlContent.AppendLine("     end as KensaSyubetsu,                                                                                                               ");
			// 受入20141219 mod end
			sqlContent.AppendLine("     ckm.ChikuRyakusho,                                                                                                                  ");
            sqlContent.AppendLine("     kit.KensaIraiSuishitsuIraiNo,                                                                                                       ");
            sqlContent.AppendLine("     kit.KensaIraiSetchishaNm,                                                                                                           ");
            sqlContent.AppendLine("     cm3.ConstNm as SyoriHoshiki,                                                                                                        ");
            sqlContent.AppendLine("     kit.KensaIraiShoritaishoJinin,                                                                                                      ");
            sqlContent.AppendLine("     ndt.NippoDtlKensaChushiRiyu,                                                                                                        ");
            sqlContent.AppendLine("     kkt.KensaKekkaKensaTimes,                                                                                                           ");
            sqlContent.AppendLine("     cm2.ConstNm as SeikyuHoho,                                                                                                          ");
            sqlContent.AppendLine("     ndt.NippoDtlKensaChushiFlg,                                                                                                         ");
            sqlContent.AppendLine("     kit.UpdateDt as KensaIraiUpdateDt,                                                                                                  ");
            sqlContent.AppendLine("     ndt.UpdateDt as NippoDtlUpdateDt,                                                                                                   ");
			// 受入20141219 add sta
			sqlContent.AppendLine("     kit.KensaIraiGaikanNippoKbn,                                                                                                        ");
			sqlContent.AppendLine("     kit.KensaIraiSuishitsuNippoKbn,                                                                                                     ");
			// 受入20141219 add end
			// 1: chushi, 0: jisshi
            sqlContent.AppendLine("     '' as KensaChushiFlg,                                                                                                               ");
            // 1: moving down
            sqlContent.AppendLine("     '' as RowMove,                                                                                                                      ");
            sqlContent.AppendLine("     ndt.NippoDtlKensaDt,                                                                                                                ");
            // v1.04 ADD Start
            if (mode == "1") // ADD mode
            {
                sqlContent.AppendLine(" case                                                                                                                                "); 
                sqlContent.AppendLine("     when kkt.KensaKekkaKensaJoukyouKbn = '001' then '0'                                                                             ");
                sqlContent.AppendLine("     when kkt.KensaKekkaKensaJoukyouKbn = '002' and isnull(kit.KensaIraiSuishitsuIraiNo, '') = '' then '0'                           ");
                sqlContent.AppendLine("     when kkt.KensaKekkaKensaJoukyouKbn = '002' and isnull(kit.KensaIraiSuishitsuIraiNo, '') <> '' then '1'                          ");
                sqlContent.AppendLine("     when kkt.KensaKekkaKensaJoukyouKbn = '003' then '1'                                                                             ");
                //2015.01.09 add kiyokuni start
                sqlContent.AppendLine("     when kkt.KensaKekkaKensaJoukyouKbn = '004' and isnull(kit.KensaIraiSuishitsuIraiNo, '') = '' then '0'                           ");
                sqlContent.AppendLine("     when kkt.KensaKekkaKensaJoukyouKbn = '004' and isnull(kit.KensaIraiSuishitsuIraiNo, '') <> '' then '1'                          ");
                //2015.01.09 add kiyokuni end
                sqlContent.AppendLine("     else '0' -- default value                                                                                                       ");
                sqlContent.AppendLine(" end as NippoAdd,                                                                                                                    ");
                
            }
            else // EDIT mode
            {
                // Always check ON
                sqlContent.AppendLine(" '1' as NippoAdd,                                                                                                                    ");
            }

            //2015.01.09 add kiyokuni start
            //sqlContent.AppendLine("     kkt.KensaKekkaKensaJoukyouKbn,                                                                                                      ");
            //sqlContent.AppendLine("     cm4.ConstNm as DataRenkei,                                                                                                          ");
            sqlContent.AppendLine(" case                                                                                                                                ");
            sqlContent.AppendLine("     when isnull(kkt.KensaKekkaKensaJoukyouKbn,'') = '' then '001'                                                                             ");
            sqlContent.AppendLine("     else kkt.KensaKekkaKensaJoukyouKbn                                                                                                      ");
            sqlContent.AppendLine(" end as KensaKekkaKensaJoukyouKbn,                                                                                                      ");

            sqlContent.AppendLine(" case                                                                                                                                ");
            sqlContent.AppendLine("     when isnull(kkt.KensaKekkaKensaJoukyouKbn,'') = '' then (select ConstNm from ConstMst where ConstKbn = '056' and ConstRenban = '001')      ");
            sqlContent.AppendLine(" else cm4.ConstNm end as DataRenkei,                                                                                                          ");
            //2015.01.09 add kiyokuni end
            
            // v1.04 ADD End
            sqlContent.AppendLine("     case                                                                                                                                ");
            sqlContent.AppendLine("         when kit.KensaIraiHoteiKbn = '2' then gm.GyoshaNm                                                                               ");
            sqlContent.AppendLine("         else ''                                                                                                                         ");
            sqlContent.AppendLine("     end as SeikyuGyosya,                                                                                                                ");
            sqlContent.AppendLine("     case                                                                                                                                ");
            sqlContent.AppendLine("         when kkt.KensaKekkaZaitakuUmu = '1' then '○'                                                                                    ");
            sqlContent.AppendLine("         else '×'                                                                                                                        ");
            sqlContent.AppendLine("     end as KensaKekkaZaitakuUmu,                                                                                                        ");
            sqlContent.AppendLine("     case                                                                                                                                ");
            sqlContent.AppendLine("         when sql3.MonitorRow = 1 then mgm.MonitoringGroupNm                                                                             ");
            sqlContent.AppendLine("         when sql3.MonitorRow > 1 then concat(mgm.MonitoringGroupNm, '、他')");
            sqlContent.AppendLine("     end as Iken,                                                                                                                        ");
            sqlContent.AppendLine("     case                                                                                                                                ");
            sqlContent.AppendLine("         when sql1.ShokenSetchishaRenrakuFlg = '1' then '要'");
            sqlContent.AppendLine("         else ''                                                                                                                         ");
            sqlContent.AppendLine("     end as RenrakuKanrisya,                                                                                                             ");
            sqlContent.AppendLine("     case                                                                                                                                ");
            sqlContent.AppendLine("         when ShokenHoshuGyoshaRenrakuFlg = '1'                                                                                          ");
            sqlContent.AppendLine("         or ShokenSeisoGyoshaRenrakuFlg = '1'                                                                                            ");
            sqlContent.AppendLine("         or ShokenKojiGyoshaRenrakuFlg = '1'                                                                                             ");
            sqlContent.AppendLine("         or ShokenMakerRenrakuFlg = '1'                                                                                                  ");
            sqlContent.AppendLine("         or ShokenHokenjoRenrakuFlg = '1' then '要'");
            sqlContent.AppendLine("     else ''                                                                                                                             ");
            sqlContent.AppendLine("     end as RenrakuGyosya,                                                                                                               ");
            // 2014/12/11 AnhNV ADD Hidden parameter to 009-005
            sqlContent.AppendLine("     kkt.KensaKekkaMochikomiDt                                                                                                           ");
            // 2014/12/11 AnhNV ADD End
			// 受入20141217 add sta
			sqlContent.AppendLine(",		(SELECT                                                                                                                                     ");
			sqlContent.AppendLine(" 		CONVERT(DECIMAL, SUM(KensaKekkaTbl.KensaKekkaKensaTimes)) / 60                                                                              ");
			sqlContent.AppendLine(" 		FROM NippoDtlTbl                                                                                                                            ");
			sqlContent.AppendLine(" 		LEFT OUTER JOIN KensaKekkaTbl ON NippoDtlTbl.NippoDtlKensaSyubetsu = KensaKekkaTbl.KensaKekkaIraiHoteiKbn                                   ");
			sqlContent.AppendLine(" 											AND NippoDtlTbl.NippoDtlKensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd                      ");
			sqlContent.AppendLine(" 											AND NippoDtlTbl.NippoDtlKensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo                              ");
			sqlContent.AppendLine(" 											AND NippoDtlTbl.NippoDtlKensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban                            ");
			sqlContent.AppendLine(" 		WHERE NippoDtlTbl.NippoDtlKensaDt = @nippoKensaDt                                                                                           ");
			sqlContent.AppendLine(" 		GROUP BY NippoDtlTbl.NippoDtlKensaDt) AS KensaKekkaKensaTimesByKensaDt,                                                                     ");
			sqlContent.AppendLine(" 		(SELECT                                                                                                                                     ");
			sqlContent.AppendLine(" 		CONVERT(DECIMAL, SUM(KensaKekkaTbl.KensaKekkaKensaTimes)) / 60                                                                              ");
			sqlContent.AppendLine(" 		FROM NippoDtlTbl                                                                                                                            ");
			sqlContent.AppendLine(" 		LEFT OUTER JOIN KensaKekkaTbl ON NippoDtlTbl.NippoDtlKensaSyubetsu = KensaKekkaTbl.KensaKekkaIraiHoteiKbn                                   ");
			sqlContent.AppendLine(" 											AND NippoDtlTbl.NippoDtlKensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd                      ");
			sqlContent.AppendLine(" 											AND NippoDtlTbl.NippoDtlKensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo                              ");
			sqlContent.AppendLine(" 											AND NippoDtlTbl.NippoDtlKensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban                            ");
			sqlContent.AppendLine(" 		WHERE NippoDtlTbl.NippoDtlKensainCd = @nippoKensainCd                                                                                       ");
			sqlContent.AppendLine(" 		AND SUBSTRING(NippoDtlKensaDt, 1, 6) BETWEEN CONCAT(SUBSTRING('" + nendoStr + "', 1, 4), '04') AND SUBSTRING (@nippoKensaDt, 1, 6)          ");
			sqlContent.AppendLine(" 		AND NippoDtlKensaDt <= @nippoKensaDt                                                                                                        ");
			sqlContent.AppendLine(" 		GROUP BY NippoDtlTbl.NippoDtlKensainCd) AS KensaKekkaKensaTimesByKensainCd                                                                  ");
			// 受入20141217 add end
            sqlContent.AppendLine(" from KensaIraiTbl kit                                                                                                                   ");
			// 2015.01.08 mod kiyokuni start
            sqlContent.AppendLine(" join KensaKekkaTbl kkt                                                                                                       ");
            //sqlContent.AppendLine(" left outer join KensaKekkaTbl kkt                                                                                                       ");
			// 2015.01.08 mod kiyokuni start
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn                                                                               ");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd                                                                            ");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo                                                                                    ");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban                                                                                  ");
 
			// 2015.01.08 mod kiyokuni start
            // 編集の時は日報明細直結  
            if (mode == "1") // Add mode
            {
                sqlContent.AppendLine(" left outer join NippoDtlTbl ndt                                                                                                         ");
            }
            else
            {
                sqlContent.AppendLine(" join NippoDtlTbl ndt                                                                                                         ");
            }
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = ndt.NippoDtlKensaSyubetsu                                                                                ");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = ndt.NippoDtlKensaIraiHokenjoCd                                                                         ");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = ndt.NippoDtlKensaIraiNendo                                                                                 ");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = ndt.NippoDtlKensaIraiRenban                                                                               ");
            sqlContent.AppendLine("     and ndt.NippoDtlKensaDt = @nippoKensaDt                                                                               ");
            sqlContent.AppendLine("     and ndt.NippoDtlKensainCd = @nippoKensainCd                                                                               ");
            // 2015.01.08 mod kiyokuni end
            sqlContent.AppendLine(" left outer join GyoshaMst gm                                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiIkkatsuSeikyusakiCd = gm.GyoshaCd                                                                                   ");
            sqlContent.AppendLine(" left outer join ShokuinMst sm1                                                                                                          ");
            if (mode == "1") // ADD mode
            {
                sqlContent.AppendLine(" on kit.KensaIraiKensaTantoshaCd = sm1.ShokuinCd                                                                                     ");
            }
            else // EDIT/NON-EDIT mode
            {
                sqlContent.AppendLine(" on ndt.NippoDtlKensainCd = sm1.ShokuinCd                                                                                            ");
            }
            sqlContent.AppendLine(" left outer join ShokuinMst sm2                                                                                                          ");
            sqlContent.AppendLine("     on ndt.NippoDtlHojoinCd = sm2.ShokuinCd                                                                                             ");
            sqlContent.AppendLine(" left outer join ChikuMst ckm                                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiGenChikuCd = ckm.ChikuCd                                                                                            ");
            sqlContent.AppendLine(" left outer join ConstMst cm1                                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = cm1.ConstValue                                                                                           ");
            sqlContent.AppendLine("     and cm1.ConstKbn = '006'                                                                                                            ");
            sqlContent.AppendLine(" left outer join ConstMst cm2                                                                                                            ");
            // v1.04 Edit Start
            //sqlContent.AppendLine("     on kit.KensaIraiNyukinHohoKbn = cm2.ConstValue                                                                                      ");
            sqlContent.AppendLine("     on kit.KensaIraiNyukinHohoKbn = cm2.ConstRenban                                                                                     ");
            // v1.04 Edit End
            sqlContent.AppendLine("     and cm2.ConstKbn = '021'                                                                                                            ");
            sqlContent.AppendLine(" left outer join ConstMst cm3                                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiShorihoshikiKbn = cm3.ConstValue                                                                                    ");
            sqlContent.AppendLine("     and cm3.ConstKbn = '022'                                                                                                            ");
            // v1.04 ADD Start
            sqlContent.AppendLine(" left outer join ConstMst cm4                                                                                                            ");
            sqlContent.AppendLine("     on kkt.KensaKekkaKensaJoukyouKbn = cm4.ConstRenban                                                                                  ");
            sqlContent.AppendLine("     and cm4.ConstKbn = '056'                                                                                                            ");
            // v1.04 ADD End
			// 受入20141219 add sta 検査種別名スクリーニング区分に応じて取得を分ける
			sqlContent.AppendLine(" left outer join ConstMst cm5                                                                                                            ");
			sqlContent.AppendLine("     on kit.KensaIraiScreeningKbn = cm5.ConstValue                                                                                           ");
			sqlContent.AppendLine("     and cm5.ConstKbn = '024'                                                                                                            ");
			// 受入20141219 add end
			sqlContent.AppendLine(" left outer join                                                                                                                         ");
            sqlContent.AppendLine(" (                                                                                                                                       ");
            sqlContent.AppendLine(" select                                                                                                                                  ");
            sqlContent.AppendLine("     skt.KensaIraiShokanIraiHoteiKbn,                                                                                                    ");
            sqlContent.AppendLine("     skt.KensaIraiShokenIraiHokenjoCd,                                                                                                   ");
            sqlContent.AppendLine("     skt.KensaIraiShokenIraiNendo,                                                                                                       ");
            sqlContent.AppendLine("     skt.KensaIraiShokenIraiRenban,                                                                                                      ");
            sqlContent.AppendLine("     max(skt.ShokenSetchishaRenrakuFlg) as ShokenSetchishaRenrakuFlg,                                                                    ");
            sqlContent.AppendLine("     max(skt.ShokenHoshuGyoshaRenrakuFlg) as ShokenHoshuGyoshaRenrakuFlg,                                                                ");
            sqlContent.AppendLine("     max(skt.ShokenSeisoGyoshaRenrakuFlg) as ShokenSeisoGyoshaRenrakuFlg,                                                                ");
            sqlContent.AppendLine("     max(skt.ShokenKojiGyoshaRenrakuFlg) as ShokenKojiGyoshaRenrakuFlg,                                                                  ");
            sqlContent.AppendLine("     max(skt.ShokenMakerRenrakuFlg) as ShokenMakerRenrakuFlg,                                                                            ");
            sqlContent.AppendLine("     max(skt.ShokenHokenjoRenrakuFlg) as ShokenHokenjoRenrakuFlg                                                                         ");
            sqlContent.AppendLine(" from ShokenKekkaTbl skt                                                                                                                 ");
            sqlContent.AppendLine(" group by                                                                                                                                ");
            sqlContent.AppendLine("     skt.KensaIraiShokanIraiHoteiKbn,                                                                                                    ");
            sqlContent.AppendLine("     skt.KensaIraiShokenIraiHokenjoCd,                                                                                                   ");
            sqlContent.AppendLine("     skt.KensaIraiShokenIraiNendo,                                                                                                       ");
            sqlContent.AppendLine("     skt.KensaIraiShokenIraiRenban                                                                                                       ");
            sqlContent.AppendLine(" ) sql1                                                                                                                                  ");
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = sql1.KensaIraiShokanIraiHoteiKbn                                                                         ");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = sql1.KensaIraiShokenIraiHokenjoCd                                                                      ");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = sql1.KensaIraiShokenIraiNendo                                                                              ");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = sql1.KensaIraiShokenIraiRenban                                                                            ");
            sqlContent.AppendLine(" left outer join                                                                                                                         ");
            sqlContent.AppendLine(" (                                                                                                                                       ");
            sqlContent.AppendLine(" select                                                                                                                                  ");
            sqlContent.AppendLine("     count(*) as MonitorRow,                                                                                                             ");
            sqlContent.AppendLine("     mt.KensaIraiHoteiKbn,                                                                                                               ");
            sqlContent.AppendLine("     mt.KensaIraiHokenjoCd,                                                                                                              ");
            sqlContent.AppendLine("     mt.KensaIraiNendo,                                                                                                                  ");
            sqlContent.AppendLine("     mt.KensaIraiRenban,                                                                                                                 ");
            sqlContent.AppendLine("     min(mt.MonitoringGroupCd) as MonitoringGroupCd                                                                                      ");
            sqlContent.AppendLine(" from MonitoringTbl mt                                                                                                                   ");
            sqlContent.AppendLine(" group by                                                                                                                                ");
            sqlContent.AppendLine("     mt.KensaIraiHoteiKbn,                                                                                                               ");
            sqlContent.AppendLine("     mt.KensaIraiHokenjoCd,                                                                                                              ");
            sqlContent.AppendLine("     mt.KensaIraiNendo,                                                                                                                  ");
            sqlContent.AppendLine("     mt.KensaIraiRenban                                                                                                                  ");
            sqlContent.AppendLine(" ) sql3                                                                                                                                  ");
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = sql3.KensaIraiHoteiKbn                                                                                   ");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = sql3.KensaIraiHokenjoCd                                                                                ");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = sql3.KensaIraiNendo                                                                                        ");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = sql3.KensaIraiRenban                                                                                      ");
            sqlContent.AppendLine(" left outer join MonitoringGroupMst mgm                                                                                                  ");
            sqlContent.AppendLine("     on sql3.MonitoringGroupCd = mgm.MonitoringGroupCd                                                                                   ");
            //2015.01.09 mod kiyokuni start
            if (mode == "1") // ADD mode
            {
                sqlContent.AppendLine(" where                                                                                                                                   ");
                sqlContent.AppendLine("     kit.KensaIraiKensaYoteiNen = @KensaDtYear                                                                                           ");
                sqlContent.AppendLine("     and kit.KensaIraiKensaYoteiTsuki = @KensaDtMonth                                                                                    ");
                sqlContent.AppendLine("     and kit.KensaIraiKensaYoteiBi = @KensaDtDay                                                                                         ");
                sqlContent.AppendLine("     and kit.KensaIraiKensaTantoshaCd = @KensainCd                                                                                       ");
            }
            else
            {
                sqlContent.AppendLine(" where                                                                                                                                   ");
                sqlContent.AppendLine("     ndt.NippoDtlKensaDt = @nippoKensaDt                                                                               ");
            }

            // 受入20141217 mod sta
			if(mode.Equals("1"))
			{
				sqlContent.AppendLine("     and kit.KensaIraiStatusKbn >= '40'                                                                                              ");
				sqlContent.AppendLine("     and kit.KensaIraiStatusKbn < '90'                                                                                               ");
			}
			// 受入20141217 mod sta
            sqlContent.AppendLine("     and (                                                                                                                               ");
            sqlContent.AppendLine("         kit.KensaIraiHoteiKbn <= '2'                                                                                                    ");
            sqlContent.AppendLine("         or (kit.KensaIraiHoteiKbn = '3' and kit.KensaIraiScreeningKbn <> '0')                                                           ");
            sqlContent.AppendLine("     )                                                                                                                                   ");
            // v1.04 ADD Start
            if (mode == "1") // Add mode
            {
                sqlContent.AppendLine(" and not exists                                                                                                                      ");
                sqlContent.AppendLine(" (                                                                                                                                   ");
                sqlContent.AppendLine("     select                                                                                                                          ");
                sqlContent.AppendLine("         NippoDtlKensaDt                                                                                                             ");
                sqlContent.AppendLine("     from NippoDtlTbl ndt                                                                                                            ");
                sqlContent.AppendLine("     where                                                                                                                           ");
                sqlContent.AppendLine("         ndt.NippoDtlKensaSyubetsu = kit.KensaIraiHoteiKbn                                                                           ");
                sqlContent.AppendLine("         and ndt.NippoDtlKensaIraiHokenjoCd = kit.KensaIraiHokenjoCd                                                                 ");
                sqlContent.AppendLine("         and ndt.NippoDtlKensaIraiNendo = kit.KensaIraiNendo                                                                         ");
                sqlContent.AppendLine("         and ndt.NippoDtlKensaIraiRenban = kit.KensaIraiRenban                                                                       ");
                sqlContent.AppendLine("         and ndt.NippoDtlKensaChushiFlg = '0'                                                                                        ");
                sqlContent.AppendLine(" )                                                                                                                                   ");
            }
                // v1.04 ADD End

			//編集モードの場合、検査日報明細が作られているデータだけを一覧に表示したいが、ここで取得したデータは確認項目タブでも使われているため、取得せざるを得ない。
			//表示制御はバウンダリ側で行う事にする。
			//// 受入20141217 add sta
			//if (mode.Equals("2")) // Edit mode
			//{
			//    // 編集モードの場合、検査日報明細が作られているデータだけを一覧に表示する。
			//    sqlContent.AppendLine(" and exists                                                                                                                          ");
			//    sqlContent.AppendLine(" (                                                                                                                                   ");
			//    sqlContent.AppendLine("     select                                                                                                                          ");
			//    sqlContent.AppendLine("         NippoDtlKensaDt                                                                                                             ");
			//    sqlContent.AppendLine("     from NippoDtlTbl ndt                                                                                                            ");
			//    sqlContent.AppendLine("     where                                                                                                                           ");
			//    sqlContent.AppendLine("         ndt.NippoDtlKensaSyubetsu = kit.KensaIraiHoteiKbn                                                                           ");
			//    sqlContent.AppendLine("         and ndt.NippoDtlKensaIraiHokenjoCd = kit.KensaIraiHokenjoCd                                                                 ");
			//    sqlContent.AppendLine("         and ndt.NippoDtlKensaIraiNendo = kit.KensaIraiNendo                                                                         ");
			//    sqlContent.AppendLine("         and ndt.NippoDtlKensaIraiRenban = kit.KensaIraiRenban                                                                       ");
			//    sqlContent.AppendLine(" )                                                                                                                                   ");
			//}
			//// 受入20141217 add end

            // ORDER
            sqlContent.AppendLine(" order by                                                                                                                                ");
            sqlContent.AppendLine("     kkt.KensaKekkaKensaStartDt                                                                                                          ");

            // Parameters
            commandParams.Add("@KensaDtYear", SqlDbType.VarChar).Value = kensaDt.ToString("yyyy");
            commandParams.Add("@KensaDtMonth", SqlDbType.VarChar).Value = kensaDt.ToString("MM");
            commandParams.Add("@KensaDtDay", SqlDbType.VarChar).Value = kensaDt.ToString("dd");
            commandParams.Add("@KensainCd", SqlDbType.VarChar).Value = kensainCd;

			// 受入20141217 add sta
			commandParams.Add("@nippoKensaDt", SqlDbType.NVarChar).Value = kensaDt.ToString("yyyyMMdd");
			commandParams.Add("@nippoKensainCd", SqlDbType.NVarChar).Value = kensainCd;
			// 受入20141217 add end

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region JinendoGaikanKensaYoteiListOutput3TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanKensaYoteiListOutput3TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class JinendoGaikanKensaYoteiListOutput3TableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput3DataTable GetDataBySearchCond(
            string kensaIraiHoteiKbn,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string nendo)
        {
            SqlCommand command = CreateSqlCommand(kensaIraiHoteiKbn, jokasoHokenjoCd, jokasoTorokuNendo, jokasoRenban, nendo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput3DataTable dataTable = new KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput3DataTable();
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
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kensaIraiHoteiKbn,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string nendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region SELECT

            sqlContent.Append("SELECT                                                                                                                       ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHoteiKbn,                                                                                         ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                        ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                            ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiRenban,                                                                                           ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoHokenjoCd,                                                                                  ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd,                                                                              ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaNen,                                                                                         ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaTsuki,                                                                                       ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaBi,                                                                                          ");
            sqlContent.Append("     CONCAT( KensaIraiTbl.KensaIraiKensaNen,                                                                                 ");
            sqlContent.Append("             KensaIraiTbl.KensaIraiKensaTsuki,                                                                               ");
            sqlContent.Append("             KensaIraiTbl.KensaIraiKensaBi) AS NenTsukiBi,                                                                   ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiNen,                                                                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiTsuki,                                                                                  ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiKensaYoteiBi,                                                                                     ");
            sqlContent.Append("     CONCAT( KensaIraiTbl.KensaIraiKensaYoteiNen,                                                                            ");
            sqlContent.Append("             KensaIraiTbl.KensaIraiKensaYoteiTsuki,                                                                          ");
            sqlContent.Append("             KensaIraiTbl.KensaIraiKensaYoteiBi) AS YoteiNenTsukiBi,                                                         ");
            sqlContent.Append("     GyoshaMst.GyoshaNm                                                                                                      ");

            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     KensaIraiTbl                                                                                                            ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     GyoshaMst                                                                                                               ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd                                                   ");
            
            #endregion

            #region WHERE

            sqlContent.Append("WHERE                                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                                   ");
            
            sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = @kensaIraiHoteiKbn                                                                      ");
            commandParams.Add("@kensaIraiHoteiKbn", SqlDbType.NVarChar).Value = kensaIraiHoteiKbn;

            sqlContent.Append("AND KensaIraiTbl.KensaIraiHokenjoCd = @jokasoHokenjoCd                                                                       ");
            commandParams.Add("@jokasoHokenjoCd", SqlDbType.NVarChar).Value = jokasoHokenjoCd;

            sqlContent.Append("AND KensaIraiTbl.KensaIraiNendo = @jokasoTorokuNendo                                                                         ");
            commandParams.Add("@jokasoTorokuNendo", SqlDbType.NVarChar).Value = jokasoTorokuNendo;

            sqlContent.Append("AND KensaIraiTbl.KensaIraiRenban = @jokasoRenban                                                                             ");
            commandParams.Add("@jokasoRenban", SqlDbType.NVarChar).Value = jokasoRenban;

            sqlContent.Append("AND                                                                                                                          ");
            sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) >=                                                  ");
            sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) <> ''                           ");
            sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT) - 1, '04')                                                                  ");
            sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) END)                          ");
            
            sqlContent.Append("AND                                                                                                                          ");
            sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) <=                                                  ");
            sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) <> ''                           ");
            sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT), '03')                                                                      ");
            sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) END)                          ");

            sqlContent.Append("AND                                                                                                                          ");
            sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) >=                                        ");
            sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) = ''                            ");
            sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT) - 1, '04')                                                                  ");
            sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) END)                ");

            sqlContent.Append("AND                                                                                                                          ");
            sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) <=                                        ");
            sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) = ''                            ");
            sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT), '03')                                                                      ");
            sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) END)                ");

            commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;

            #endregion
            
            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region JinendoGaikanKensaYoteiListOutput4TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanKensaYoteiListOutput4TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class JinendoGaikanKensaYoteiListOutput4TableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/23　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput4DataTable GetDataBySearchCond(
            string kensaIraiHoteiKbn,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string nendo)
        {
            SqlCommand command = CreateSqlCommand(kensaIraiHoteiKbn, jokasoHokenjoCd, jokasoTorokuNendo, jokasoRenban, nendo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput4DataTable dataTable = new KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput4DataTable();
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
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/23　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kensaIraiHoteiKbn,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string nendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            string uketsukeDtFrom = (Convert.ToInt32(nendo) - 2) + "0401";
            string uketsukeDtTo = Convert.ToInt32(nendo) + "0331";

            #region SELECT

            sqlContent.Append("SELECT                                                                                                                       ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHoteiKbn,                                                                                         ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                                        ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                            ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiRenban,                                                                                           ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd,                                                                              ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSuishitsuUketsukeDt,                                                                              ");
            sqlContent.Append("     GyoshaMst.GyoshaNm                                                                                                      ");

            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     KensaIraiTbl                                                                                                            ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     GyoshaMst                                                                                                               ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd                                                   ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     (   SELECT                                                                                                              ");
            sqlContent.Append("             KensaIraiJokasoHokenjoCd,                                                                                       ");
            sqlContent.Append("             KensaIraiJokasoTorokuNendo,                                                                                     ");
            sqlContent.Append("             KensaIraiJokasoRenban,                                                                                          ");
            sqlContent.Append("             MAX(KensaIraiSuishitsuUketsukeDt) AS UketsukeDt                                                                 ");
            sqlContent.Append("         FROM KensaIraiTbl                                                                                                   ");
            sqlContent.Append("         WHERE KensaIraiHoteiKbn = @kensaIraiHoteiKbn                                                                        ");
            sqlContent.Append("                 AND KensaIraiJokasoHokenjoCd = @jokasoHokenjoCd                                                             ");
            sqlContent.Append("                 AND KensaIraiJokasoTorokuNendo = @jokasoTorokuNendo                                                         ");
            sqlContent.Append("                 AND KensaIraiJokasoRenban = @jokasoRenban                                                                   ");
            sqlContent.Append("                 AND KensaIraiSuishitsuUketsukeDt >= @uketsukeDtFrom                                                         ");
            sqlContent.Append("                 AND KensaIraiSuishitsuUketsukeDt <= @uketsukeDtTo                                                           ");
            sqlContent.Append("         GROUP BY                                                                                                            ");
            sqlContent.Append("             KensaIraiJokasoHokenjoCd,                                                                                       ");
            sqlContent.Append("             KensaIraiJokasoTorokuNendo,                                                                                     ");
            sqlContent.Append("             KensaIraiJokasoRenban   ) Tbl                                                                                   ");
            sqlContent.Append("     ON Tbl.KensaIraiJokasoHokenjoCd = KensaIraiTbl.KensaIraiJokasoHokenjoCd                                                 ");
            sqlContent.Append("     AND Tbl.KensaIraiJokasoTorokuNendo = KensaIraiTbl.KensaIraiJokasoTorokuNendo                                            ");
            sqlContent.Append("     AND Tbl.KensaIraiJokasoRenban = KensaIraiTbl.KensaIraiJokasoRenban                                                      ");
            sqlContent.Append("     AND Tbl.UketsukeDt = KensaIraiTbl.KensaIraiSuishitsuUketsukeDt                                                          ");

            #endregion

            #region WHERE

            sqlContent.Append("WHERE                                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                                   ");

            commandParams.Add("@kensaIraiHoteiKbn", SqlDbType.NVarChar).Value = kensaIraiHoteiKbn;
            commandParams.Add("@jokasoHokenjoCd", SqlDbType.NVarChar).Value = jokasoHokenjoCd;
            commandParams.Add("@jokasoTorokuNendo", SqlDbType.NVarChar).Value = jokasoTorokuNendo;
            commandParams.Add("@jokasoRenban", SqlDbType.NVarChar).Value = jokasoRenban;
            commandParams.Add("@uketsukeDtFrom", SqlDbType.NVarChar).Value = uketsukeDtFrom;
            commandParams.Add("@uketsukeDtTo", SqlDbType.NVarChar).Value = uketsukeDtTo;

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region CenterKeikokuListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CenterKeikokuListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class CenterKeikokuListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShishoCd"></param>
        /// <param name="KensaDateBefore"></param>
        /// <param name="ShiyoKaishiDateBefore"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.CenterKeikokuListDataTable GetDataBySearchCond(
            string ShishoCd,
            string KensaDateBefore,
            string ShiyoKaishiDateBefore)
        {
            SqlCommand command = CreateSqlCommand(ShishoCd,
                                                    KensaDateBefore,
                                                    ShiyoKaishiDateBefore);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.CenterKeikokuListDataTable dataTable = new KensaIraiTblDataSet.CenterKeikokuListDataTable();
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
        /// <param name="ShishoCd"></param>
        /// <param name="KensaDateBefore"></param>
        /// <param name="ShiyoKaishiDateBefore"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗      　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string ShishoCd,
            string KensaDateBefore,
            string ShiyoKaishiDateBefore)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append("SELECT ");
            sqlContent.Append("  kensaIraiUketsukeShishoKbn ");
            sqlContent.Append("  , KensaIraiKensaTantoshaCd ");
            sqlContent.Append("  , KensaIraiStatusKbn ");
            sqlContent.Append("  , KensaIraiHoryuKbn ");
            sqlContent.Append("  , CONCAT( ");
            sqlContent.Append("    KensaIraiKensaNen ");
            sqlContent.Append("    , KensaIraiKensaTsuki ");
            sqlContent.Append("    , KensaIraiKensaBi ");
            sqlContent.Append("  ) As KensaDateYYYYMMDD ");
            sqlContent.Append("  , CONCAT( ");
            sqlContent.Append("    KensaIraiShiyoKaishiNen ");
            sqlContent.Append("    , KensaIraiShiyoKaishiTsuki ");
            sqlContent.Append("    , KensaIraiShiyoKaishiBi ");
            sqlContent.Append("  ) As ShiyoKaishiDateYYYYMMDD ");

            //FROM
            sqlContent.Append("FROM ");
            sqlContent.Append("  KensaIraiTbl ");

            //WHERE
            sqlContent.Append("WHERE ");
            sqlContent.Append("  ISNULL(KensaIraiKensaTantoshaCd, '') <> '' ");
            sqlContent.Append("  AND ( ");
            sqlContent.Append("    ( ");
            sqlContent.Append("      CONCAT(KensaIraiKensaNen, KensaIraiKensaTsuki, KensaIraiKensaBi) <= @KensaDateBeforeYYYYMMDD ");
            sqlContent.Append("      AND KensaIraiStatusKbn < '65' ");
            sqlContent.Append("    ) ");
            sqlContent.Append("    OR ( ");
            sqlContent.Append("      KensairaiHoteiKbn = '1' ");
            sqlContent.Append("      AND CONCAT(KensaIraiShiyoKaishiNen, KensaIraiShiyoKaishiTsuki , KensaIraiShiyoKaishiBi) <= @ShiyoKaishiDateBeforeYYYYMMDD ");
            sqlContent.Append("      AND KensaIraiStatusKbn < '50' ");
            sqlContent.Append("    ) ");
            sqlContent.Append("    OR ( ");
            sqlContent.Append("      KensairaiHoteiKbn = '1' ");
            sqlContent.Append("      AND KensaIraiStatusKbn < '50' ");
            sqlContent.Append("      AND KensaIraiHoryuKbn = '1' ");
            sqlContent.Append("    ) ");
            sqlContent.Append("  ) ");
            commandParams.Add("@KensaDateBeforeYYYYMMDD", SqlDbType.NVarChar).Value = KensaDateBefore;
            commandParams.Add("@ShiyoKaishiDateBeforeYYYYMMDD", SqlDbType.NVarChar).Value = ShiyoKaishiDateBefore;

            if (!string.IsNullOrEmpty(ShishoCd))
            {
                sqlContent.Append("AND kensaIraiUketsukeShishoKbn = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = ShishoCd;
            }

            //ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("  kensaIraiUketsukeShishoKbn ");
            sqlContent.Append("  , KensaIraiKensaTantoshaCd ");
            sqlContent.Append("  , KensaIraiStatusKbn ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Miwariate11JoListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Miwariate11JoListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class Miwariate11JoListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.Miwariate11JoListDataTable GetDataBySearchCond(string ShishoCd)
        {
            SqlCommand command = CreateSqlCommand(ShishoCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.Miwariate11JoListDataTable dataTable = new KensaIraiTblDataSet.Miwariate11JoListDataTable();
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
        /// <param name="ShishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗      　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string ShishoCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append("SELECT ");
            sqlContent.Append("  KensaIraiNendo ");
            sqlContent.Append("  , COUNT(*) As KeikokuCount  ");

            //FROM
            sqlContent.Append("FROM ");
            sqlContent.Append("  KensaIraiTbl  ");

            //WHERE
            sqlContent.Append("WHERE ");
            sqlContent.Append("  KensairaiHoteiKbn = '2'  ");
            sqlContent.Append("  AND ISNULL(KensaIraiKensaTantoshaCd, '') = ''  ");

            if (!string.IsNullOrEmpty(ShishoCd))
            {
                sqlContent.Append("AND kensaIraiUketsukeShishoKbn = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = ShishoCd;
            }

            // GROPU BY
            sqlContent.Append("GROUP BY ");
            sqlContent.Append("  KensaIraiNendo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Miwariate7JoListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Miwariate7JoListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class Miwariate7JoListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaIraiTblDataSet.Miwariate7JoListDataTable GetDataBySearchCond(string ShishoCd)
        {
            SqlCommand command = CreateSqlCommand(ShishoCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaIraiTblDataSet.Miwariate7JoListDataTable dataTable = new KensaIraiTblDataSet.Miwariate7JoListDataTable();
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
        /// <param name="ShishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗      　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string ShishoCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append("SELECT ");
            sqlContent.Append("  COUNT(*) As KeikokuCount ");

            //FROM
            sqlContent.Append("FROM ");
            sqlContent.Append("  KensaIraiTbl ");

            //WHERE
            sqlContent.Append("WHERE ");
            sqlContent.Append("  KensairaiHoteiKbn = '1' ");
            sqlContent.Append("  AND ISNULL(KensaIraiKensaTantoshaCd, '') = '' ");

            if (!string.IsNullOrEmpty(ShishoCd))
            {
                sqlContent.Append("AND kensaIraiUketsukeShishoKbn = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = ShishoCd;
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
