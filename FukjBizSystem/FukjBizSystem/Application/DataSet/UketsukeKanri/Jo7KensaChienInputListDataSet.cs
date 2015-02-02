using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ComponentModel;

namespace FukjBizSystem.Application.DataSet.UketsukeKanri
{
    public partial class Jo7KensaChienInputListDataSet
    {

    }

}

namespace FukjBizSystem.Application.DataSet.UketsukeKanri.Jo7KensaChienInputListDataSetTableAdapters
{
    #region Jo7KensaChienInputListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Jo7KensaChienInputListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　DatNT　　 新規作成
    /// 2014/12/08　habu　　 Moved from JokasoDaichoMst
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class Jo7KensaChienInputListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="kensaIraiShoritaishoJinin"></param>
        /// <param name="kensaIraiShiyoKaishiDtJokenTuikaFlg"></param>
        /// <param name="kensaIraiShiyoKaishiDtFrom"></param>
        /// <param name="kensaIraiShiyoKaishiDtTo"></param>
        /// <param name="kensaJisshiBijokenTsuikaFlg"></param>
        /// <param name="kensaIraiKensaDtFrom"></param>
        /// <param name="kensaIraiKensaDtTo"></param>
        /// <param name="miSakuseiFlag"></param>
        /// <param name="sakuseiSumiFlag"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable GetDataBySearchCond(
            string shishoCd,
            string kensaIraiShoritaishoJinin,
            bool kensaIraiShiyoKaishiDtJokenTuikaFlg,
            string kensaIraiShiyoKaishiDtFrom,
            string kensaIraiShiyoKaishiDtTo,
            bool kensaJisshiBijokenTsuikaFlg,
            string kensaIraiKensaDtFrom,
            string kensaIraiKensaDtTo,
            bool miSakuseiFlag,
            bool sakuseiSumiFlag)
        {
            SqlCommand command = CreateSqlCommand(shishoCd,
                                                    kensaIraiShoritaishoJinin,
                                                    kensaIraiShiyoKaishiDtJokenTuikaFlg,
                                                    kensaIraiShiyoKaishiDtFrom,
                                                    kensaIraiShiyoKaishiDtTo,
                                                    kensaJisshiBijokenTsuikaFlg,
                                                    kensaIraiKensaDtFrom,
                                                    kensaIraiKensaDtTo,
                                                    miSakuseiFlag,
                                                    sakuseiSumiFlag);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable dataTable = new Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable();
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
        /// <param name="shishoCd"></param>
        /// <param name="kensaIraiShoritaishoJinin"></param>
        /// <param name="kensaIraiShiyoKaishiDtJokenTuikaFlg"></param>
        /// <param name="kensaIraiShiyoKaishiDtFrom"></param>
        /// <param name="kensaIraiShiyoKaishiDtTo"></param>
        /// <param name="kensaJisshiBijokenTsuikaFlg"></param>
        /// <param name="kensaIraiKensaDtFrom"></param>
        /// <param name="kensaIraiKensaDtTo"></param>
        /// <param name="miSakuseiFlag"></param>
        /// <param name="sakuseiSumiFlag"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　DatNT　　新規作成
        /// 2014/10/14  DatNT   v1.02
        /// 2014/11/06  DatNT   v1.03
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// 2014/12/06  DatNT   v1.04
        /// 2014/12/11  habu   replace some case statements to function
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string shishoCd,
            string kensaIraiShoritaishoJinin,
            bool kensaIraiShiyoKaishiDtJokenTuikaFlg,
            string kensaIraiShiyoKaishiDtFrom,
            string kensaIraiShiyoKaishiDtTo,
            bool kensaJisshiBijokenTsuikaFlg,
            string kensaIraiKensaDtFrom,
            string kensaIraiKensaDtTo,
            bool miSakuseiFlag,
            bool sakuseiSumiFlag)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ");
            // 20150107 habu 件数制限を追加
            sb.Append("TOP 2000 ");
            sb.Append("  KensaIraiTbl.KensaIraiHoteiKbn ");
            sb.Append("  , KensaIraiTbl.KensaIraiHokenjoCd ");
            sb.Append("  , KensaIraiTbl.KensaIraiNendo ");
            sb.Append("  , KensaIraiTbl.KensaIraiRenban ");
            sb.Append("  , CONCAT( ");
            sb.Append("    KensaIraiTbl.KensaIraiHokenjoCd ");
            sb.Append("    , '-' ");
            sb.Append("    , [dbo].[FuncConvertIraiNedoToWareki](KensaIraiTbl.KensaIraiNendo) ");
            sb.Append("    , '-' ");
            sb.Append("    , KensaIraiTbl.KensaIraiRenban ");
            sb.Append("  ) AS kyokaiNoCol ");
            sb.Append("  , KensaIraiTbl.KensaIraiSetchishaNm ");
            sb.Append("  , KensaIraiTbl.KensaIraiSetchibashoAdr ");
            sb.Append("  , KensaIraiTbl.KensaIraiKensaTantoshaCd ");
            sb.Append("  , KensaIraiTbl.KensaIraiShoritaishoJinin ");
            sb.Append("  , KensaIraiTbl.KensaIraiKensaNen ");
            sb.Append("  , KensaIraiTbl.KensaIraiKensaTsuki ");
            sb.Append("  , KensaIraiTbl.KensaIraiKensaBi ");
            sb.Append("  , [dbo].[FuncStrDateFormat]( ");
            sb.Append("    CONCAT( ");
            sb.Append("      KensaIraiTbl.KensaIraiKensaNen ");
            sb.Append("      , KensaIraiTbl.KensaIraiKensaTsuki ");
            sb.Append("      , KensaIraiTbl.KensaIraiKensaBi ");
            sb.Append("    ) ");
            sb.Append("    , 'yyyy年MM月dd日' ");
            sb.Append("  ) AS kensaIraiKensaDtCol ");
            sb.Append("  , KensaIraiTbl.KensaIraiShiyoKaishiNen ");
            sb.Append("  , KensaIraiTbl.KensaIraiShiyoKaishiTsuki ");
            sb.Append("  , KensaIraiTbl.KensaIraiShiyoKaishiBi ");
            sb.Append("  , [dbo].[FuncStrDateFormat]( ");
            sb.Append("    CONCAT( ");
            sb.Append("      KensaIraiTbl.KensaIraiShiyoKaishiNen ");
            sb.Append("      , KensaIraiTbl.KensaIraiShiyoKaishiTsuki ");
            sb.Append("      , KensaIraiTbl.KensaIraiShiyoKaishiBi ");
            sb.Append("    ) ");
            sb.Append("    , 'yyyy年MM月dd日' ");
            sb.Append("  ) AS kensaIraiShiyoKaishiDtCol ");
            sb.Append("  , [dbo].[FuncStrDateFormat]( ");
            sb.Append("    [dbo].[FuncStrDateAddMonth]( ");
            sb.Append("      CONCAT( ");
            sb.Append("        KensaIraiTbl.KensaIraiShiyoKaishiNen ");
            sb.Append("        , KensaIraiTbl.KensaIraiShiyoKaishiTsuki ");
            sb.Append("        , KensaIraiTbl.KensaIraiShiyoKaishiBi ");
            sb.Append("      ) ");
            sb.Append("      , 8 ");
            sb.Append("    ) ");
            sb.Append("    , 'yyyy年MM月dd日' ");
            sb.Append("  ) AS kensaJisshiKigenDtCol ");
            sb.Append("  , '' AS keikaDtCol ");
            sb.Append("  , ShokuinMst.ShokuinNm ");
            sb.Append("  , KensaIraiTbl.KensaIraiUketsukeShishoKbn ");
            sb.Append("  , ShishoMst.ShishoNm ");
            // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
            sb.Append("  , KensaIraiTbl.ChienHokokuMakeKbn ");
            // 2015.01.30 toyoda Add End
            sb.Append("FROM ");

            // 2014.12.29 toyoda Modify Start
            //sb.Append("  KensaIraiTbl ");
            sb.Append("     ( ");
            sb.Append(" select ");
            sb.Append(" KensaIraiTbl.KensaIraiHoteiKbn, ");
            sb.Append(" KensaIraiTbl.KensaIraiHokenjoCd, ");
            sb.Append(" KensaIraiTbl.KensaIraiNendo, ");
            sb.Append(" KensaIraiTbl.KensaIraiRenban, ");
            sb.Append(" KensaIraiTbl.KensaIraiJokasoHokenjoCd, ");
            sb.Append(" KensaIraiTbl.KensaIraiJokasoTorokuNendo, ");
            sb.Append(" KensaIraiTbl.KensaIraiJokasoRenban, ");
            sb.Append(" KensaIraiTbl.KensaIraiUketsukeShishoKbn, ");
            sb.Append(" KensaIraiTbl.KensaIraiKensaNen, ");
            sb.Append(" KensaIraiTbl.KensaIraiKensaTsuki, ");
            sb.Append(" KensaIraiTbl.KensaIraiKensaBi, ");
            sb.Append(" KensaIraiTbl.KensaIraiKensaTantoshaCd, ");
            sb.Append(" KensaIraiTbl.KensaIraiShiyoKaishiNen, ");
            sb.Append(" KensaIraiTbl.KensaIraiShiyoKaishiTsuki, ");
            sb.Append(" KensaIraiTbl.KensaIraiShiyoKaishiBi, ");
            sb.Append(" KensaIraiTbl.KensaIraiSetchishaNm, ");
            sb.Append(" KensaIraiTbl.KensaIraiSetchibashoAdr, ");
            sb.Append(" KensaIraiTbl.KensaIraiShoritaishoJinin, ");
            // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
            sb.Append(" KensaIraiTbl.ChienHokokuMakeKbn ");
            // 2015.01.30 toyoda Add End
            sb.Append(" from ");
            sb.Append(" KensaIraiTbl ");
            sb.Append(" where  ");
            sb.Append(" KensaIraiTbl.KensaIraiHoteiKbn = '1' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiKensaNen <> '' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiKensaNen <> '0000' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiKensaTsuki <> '' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiKensaTsuki <> '00' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiKensaBi <> '' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiKensaBi <> '00' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiShiyoKaishiNen <> '' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiShiyoKaishiNen <> '0000' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiShiyoKaishiTsuki <> '' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiShiyoKaishiTsuki <> '00' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiShiyoKaishiBi <> '' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiShiyoKaishiBi <> '00' ");
            sb.Append(" AND KensaIraiTbl.KensaIraiStatusKbn < '90' ");

            // 支所
            if (!string.IsNullOrEmpty(shishoCd))
            {
                sb.Append("AND KensaIraiTbl.KensaIraiUketsukeShishoKbn = @shishoCd                                                                           ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            // 人槽
            if (kensaIraiShoritaishoJinin == "50↓")
            {
                sb.Append("AND KensaIraiTbl.KensaIraiShoritaishoJinin <= 50                                                              ");
            }
            else if (kensaIraiShoritaishoJinin == "51↑")
            {
                sb.Append("AND KensaIraiTbl.KensaIraiShoritaishoJinin >= 51                                                              ");
            }

            // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
            if (!miSakuseiFlag || !sakuseiSumiFlag)
            {
                if (miSakuseiFlag)
                {
                    sb.Append(" AND KensaIraiTbl.ChienHokokuMakeKbn = '0' ");
                }
                else
                {
                    sb.Append(" AND KensaIraiTbl.ChienHokokuMakeKbn = '1' ");
                }
            }
            // 2015.01.30 toyoda Add End

            sb.Append(" ) AS KensaIraiTbl ");
            // 2014.12.29 toyoda Modify End

            sb.Append("  INNER JOIN JokasoDaichoMst ");
            sb.Append("    ON JokasoDaichoMst.JokasoHokenjoCd = KensaIraiTbl.KensaIraiJokasoHokenjoCd ");
            sb.Append("    AND JokasoDaichoMst.JokasoTorokuNendo = KensaIraiTbl.KensaIraiJokasoTorokuNendo ");
            sb.Append("    AND JokasoDaichoMst.JokasoRenban = KensaIraiTbl.KensaIraiJokasoRenban ");
            sb.Append("  LEFT OUTER JOIN ShishoMst ");
            sb.Append("    ON ShishoMst.ShishoCd = KensaIraiTbl.KensaIraiUketsukeShishoKbn ");
            sb.Append("  LEFT OUTER JOIN ShokuinMst ");
            sb.Append("    ON ShokuinMst.ShokuinCd = KensaIraiTbl.KensaIraiKensaTantoshaCd ");
            sb.Append("WHERE ");

            // 2014.12.29 toyoda Modify Start
            //sb.Append("  KensaIraiTbl.KensaIraiHoteiKbn = '1' ");
            //sb.Append("  AND CONCAT( ");
            sb.Append("  CONCAT( ");
            // 2014.12.29 toyoda Modify End

            sb.Append("    KensaIraiTbl.KensaIraiKensaNen ");
            sb.Append("    , KensaIraiTbl.KensaIraiKensaTsuki ");
            sb.Append("    , KensaIraiTbl.KensaIraiKensaBi ");
            sb.Append("  ) >= [dbo].[FuncStrDateAddMonth]( ");
            sb.Append("    CONCAT( ");
            sb.Append("      KensaIraiTbl.KensaIraiShiyoKaishiNen ");
            sb.Append("      , KensaIraiTbl.KensaIraiShiyoKaishiTsuki ");
            sb.Append("      , KensaIraiTbl.KensaIraiShiyoKaishiBi ");
            sb.Append("    ) ");
            sb.Append("    , 8 ");
            sb.Append("  ) ");

            // 2014.12.29 toyoda Delete Start
            //// 20141211 ADD habu 使用開始日が未入力の場合は対象外(遅延とは判断できない)
            //sb.Append("  AND CONCAT( ");
            //sb.Append("    KensaIraiTbl.KensaIraiShiyoKaishiNen ");
            //sb.Append("    , KensaIraiTbl.KensaIraiShiyoKaishiTsuki ");
            //sb.Append("    , KensaIraiTbl.KensaIraiShiyoKaishiBi ");
            //sb.Append("  ) <> '' ");
            //sb.Append("  AND KensaIraiTbl.KensaIraiStatusKbn < '90' ");
            //// 20141211 
            // 2014.12.29 toyoda Delete End

            #region to be removed

            //// SELECT
            //sqlContent.Append(" SELECT                                                                                                           ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiHoteiKbn,                                                                              ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                             ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                 ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiRenban,                                                                                ");

            ////sqlContent.Append("     CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                 ");
            ////sqlContent.Append("             CAST(KensaIraiTbl.KensaIraiNendo AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), '-', ");
            ////sqlContent.Append("             KensaIraiTbl.KensaIraiRenban) AS kyokaiNoCol,                                                        ");

            //sqlContent.Append("     CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                 ");
            //sqlContent.Append("             [dbo].[FuncConvertIraiNedoToWareki](KensaIraiTbl.KensaIraiNendo), '-',                               ");
            //sqlContent.Append("             KensaIraiTbl.KensaIraiRenban) AS kyokaiNoCol,                                                        ");

            //sqlContent.Append("     KensaIraiTbl.KensaIraiSetchishaNm,                                                                           ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiSetchibashoAdr,                                                                        ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiKensaTantoshaCd,                                                                       ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiShoritaishoJinin,                                                                      ");

            //sqlContent.Append("     KensaIraiTbl.KensaIraiKensaNen,                                                                              ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiKensaTsuki,                                                                            ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiKensaBi,                                                                               ");

            //sqlContent.Append("     CASE                                                                                                         ");
            //sqlContent.Append("         WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, '') <> ''                                                    ");
            //sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiKensaTsuki, '') <> ''                                           ");
            //sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiKensaBi, '') <> ''                                              ");
            //// 2014/11/06 DatNT v1.03 MOD Start
            ////sqlContent.Append("             THEN CONCAT(CAST(KensaIraiTbl.KensaIraiKensaNen AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) ORDER BY KaishiDt DESC), '年', ");
            //sqlContent.Append("             THEN CONCAT(KensaIraiTbl.KensaIraiKensaNen, '年',                                                    ");
            //// 2014/11/06 DatNT v1.03 MOD End
            //sqlContent.Append("                         KensaIraiTbl.KensaIraiKensaTsuki, '月',                                                  ");
            //sqlContent.Append("                         KensaIraiTbl.KensaIraiKensaBi, '日')                                                     ");
            //sqlContent.Append("         ELSE ''                                                                                                  ");
            //sqlContent.Append("         END AS kensaIraiKensaDtCol,                                                                              ");

            //sqlContent.Append("     KensaIraiTbl.KensaIraiShiyoKaishiNen,                                                                        ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiShiyoKaishiTsuki,                                                                      ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiShiyoKaishiBi,                                                                         ");

            //sqlContent.Append("     CASE                                                                                                         ");
            //sqlContent.Append("         WHEN ISNULL(KensaIraiTbl.KensaIraiShiyoKaishiNen, '') <> ''                                              ");
            //sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiShiyoKaishiTsuki, '') <> ''                                     ");
            //sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiShiyoKaishiBi, '') <> ''                                        ");
            //// 2014/11/06 DatNT v1.03 MOD Start
            ////sqlContent.Append("             THEN CONCAT(CAST(KensaIraiTbl.KensaIraiShiyoKaishiNen AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen, KensaIraiTbl.KensaIraiShiyoKaishiTsuki, KensaIraiTbl.KensaIraiShiyoKaishiBi) ORDER BY KaishiDt DESC), '年', ");
            //sqlContent.Append("             THEN CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen, '年',                                              ");
            //// 2014/11/06 DatNT v1.03 MOD End
            //sqlContent.Append("                         KensaIraiTbl.KensaIraiShiyoKaishiTsuki, '月',                                            ");
            //sqlContent.Append("                         KensaIraiTbl.KensaIraiShiyoKaishiBi, '日')                                               ");
            //sqlContent.Append("         ELSE ''                                                                                                  ");
            //sqlContent.Append("         END AS kensaIraiShiyoKaishiDtCol,                                                                        ");

            //sqlContent.Append("     CASE                                                                                                         ");
            //sqlContent.Append("         WHEN ISNULL(KensaIraiTbl.KensaIraiShiyoKaishiNen, '') <> ''                                              ");
            //sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiShiyoKaishiTsuki, '') <> ''                                     ");
            //sqlContent.Append("                 AND ISNULL(KensaIraiTbl.KensaIraiShiyoKaishiBi, '') <> ''                                        ");
            //sqlContent.Append("             THEN CONCAT(SUBSTRING(CONVERT(VARCHAR(8),                                                            ");
            //sqlContent.Append("                                             DATEADD(MONTH,                                                       ");
            //sqlContent.Append("                                             8,                                                                   ");
            //sqlContent.Append("                                             (CAST(CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen,                   ");
            //sqlContent.Append("                                                             KensaIraiTbl.KensaIraiShiyoKaishiTsuki,              ");
            //sqlContent.Append("                                                             KensaIraiTbl.KensaIraiShiyoKaishiBi)  AS DATE)))     ");
            //sqlContent.Append("                                             ,112)                                                                ");
            //sqlContent.Append("                                     , 0, 5),                                                                     ");

            //// 2014/11/06 DatNT v1.03 DEL Start
            ////// 和暦元号
            ////sqlContent.Append("                                     (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1                    ");
            ////sqlContent.Append("                                      FROM WarekiMst                                                              ");
            ////sqlContent.Append("                                      WHERE KaishiDt <= (CONVERT(VARCHAR(8),                                      ");
            ////sqlContent.Append("                                                                 DATEADD(MONTH,                                   ");
            ////sqlContent.Append("                                                                 8,                                               ");
            ////sqlContent.Append("                                                                 (CAST(CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen,              ");
            ////sqlContent.Append("                                                                              KensaIraiTbl.KensaIraiShiyoKaishiTsuki,            ");
            ////sqlContent.Append("                                                                              KensaIraiTbl.KensaIraiShiyoKaishiBi) AS DATE))) ,  ");
            ////sqlContent.Append("                                                                 112))                                                           ");
            ////sqlContent.Append("                                      ORDER BY KaishiDt DESC),                                                                   ");
            //// 2014/11/06 DatNT v1.03 DEL End

            //sqlContent.Append("                         '年',                                                                                    ");
            //sqlContent.Append("                         SUBSTRING(CONVERT(VARCHAR(8),                                                            ");
            //sqlContent.Append("                                             DATEADD(MONTH,                                                       ");
            //sqlContent.Append("                                             8,                                                                   ");
            //sqlContent.Append("                                             (CAST(CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen,                   ");
            //sqlContent.Append("                                                             KensaIraiTbl.KensaIraiShiyoKaishiTsuki,              ");
            //sqlContent.Append("                                                             KensaIraiTbl.KensaIraiShiyoKaishiBi)  AS DATE)))     ");
            //sqlContent.Append("                                             ,112)                                                                ");
            //sqlContent.Append("                                     , 5, 2),                                                                     ");
            //sqlContent.Append("                         '月',                                                                                    ");
            //sqlContent.Append("                         SUBSTRING(CONVERT(VARCHAR(8),                                                            ");
            //sqlContent.Append("                                             DATEADD(MONTH,                                                       ");
            //sqlContent.Append("                                             8,                                                                   ");
            //sqlContent.Append("                                             (CAST(CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen,                   ");
            //sqlContent.Append("                                                             KensaIraiTbl.KensaIraiShiyoKaishiTsuki,              ");
            //sqlContent.Append("                                                             KensaIraiTbl.KensaIraiShiyoKaishiBi)  AS DATE)))     ");
            //sqlContent.Append("                                             ,112)                                                                ");
            //sqlContent.Append("                                     , 7, 2),                                                                     ");
            //sqlContent.Append("                         '日')                                                                                    ");
            //sqlContent.Append("         ELSE ''                                                                                                  ");
            //sqlContent.Append("         END AS kensaJisshiKigenDtCol,                                                                            ");

            //sqlContent.Append("     '' AS keikaDtCol,                                                                                            ");

            //// 2014/12/06 DatNT v1.04 ADD Start
            //sqlContent.Append("     ShokuinMst.ShokuinNm,                                                                                       ");
            //// 2014/12/06 DatNT v1.04 ADD End

            //// 2014/11/06 DatNT v1.03 MOD Start
            ////sqlContent.Append("     JokasoDaichoMst.JokasoHoteiSishoCd,                                                                          ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiUketsukeShishoKbn,                                                                     ");
            //// 2014/11/06 DatNT v1.03 MOD End
            //sqlContent.Append("     ShishoMst.ShishoNm                                                                                           ");

            //// FROM
            //sqlContent.Append(" FROM                                                                                                             ");
            //sqlContent.Append("     KensaIraiTbl                                                                                                 ");
            //sqlContent.Append(" INNER JOIN                                                                                                       ");
            //sqlContent.Append("     JokasoDaichoMst                                                                                              ");
            //sqlContent.Append("         ON JokasoDaichoMst.JokasoHokenjoCd = KensaIraiTbl.KensaIraiJokasoHokenjoCd                               ");
            //sqlContent.Append("         AND JokasoDaichoMst.JokasoTorokuNendo = KensaIraiTbl.KensaIraiJokasoTorokuNendo                          ");
            //sqlContent.Append("         AND JokasoDaichoMst.JokasoRenban = KensaIraiTbl.KensaIraiJokasoRenban                                    ");
            //sqlContent.Append(" LEFT OUTER JOIN                                                                                                  ");
            //sqlContent.Append("     ShishoMst                                                                                                    ");
            //// 2014/11/06 DatNT v1.03 MOD Start
            ////sqlContent.Append("     ON ShishoMst.ShishoCd = JokasoDaichoMst.JokasoHoteiSishoCd                                                   ");
            //sqlContent.Append("     ON ShishoMst.ShishoCd = KensaIraiTbl.KensaIraiUketsukeShishoKbn                                              ");
            //// 2014/11/06 DatNT v1.03 MOD End
            //// 2014/12/06 DatNT v1.04 ADD Start
            //sqlContent.Append(" LEFT OUTER JOIN                                                                                                  ");
            //sqlContent.Append("     ShokuinMst                                                                                                   ");
            //sqlContent.Append("         ON ShokuinMst.ShokuinCd = KensaIraiTbl.KensaIraiKensaTantoshaCd                                          ");
            //// 2014/12/06 DatNT v1.04 ADD End

            //// WHERE
            //sqlContent.Append(" WHERE                                                                                                            ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiHoteiKbn = '1'                                                                         ");

            //sqlContent.Append("AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) >= CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen, KensaIraiTbl.KensaIraiShiyoKaishiTsuki, KensaIraiTbl.KensaIraiShiyoKaishiBi) ");

            //// 2014/10/14 DatNT v1.02 Start ADD
            //sqlContent.Append("AND KensaIraiTbl.KensaIraiStatusKbn < '90'                                                                        ");
            //// 2014/10/14 DatNT v1.02 End ADD
            #endregion

            // 2014.12.29 toyoda Delete Start
            //// 支所
            //if (!string.IsNullOrEmpty(shishoCd))
            //{
            //    sb.Append("AND KensaIraiTbl.KensaIraiUketsukeShishoKbn = @shishoCd                                                                           ");
            //    commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            //}

            //// 人槽
            //if (kensaIraiShoritaishoJinin == "50↓")
            //{
            //    sb.Append("AND KensaIraiTbl.KensaIraiShoritaishoJinin <= 50                                                              ");
            //}
            //else if (kensaIraiShoritaishoJinin == "51↑")
            //{
            //    sb.Append("AND KensaIraiTbl.KensaIraiShoritaishoJinin >= 51                                                              ");
            //}
            // 2014.12.29 toyoda Delete End

            // ・｛使用開始日の追加条件フラグ｝ = True 場合
            if (kensaIraiShiyoKaishiDtJokenTuikaFlg)
            {
                sb.Append("AND CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen, KensaIraiTbl.KensaIraiShiyoKaishiTsuki, KensaIraiTbl.KensaIraiShiyoKaishiBi) >= @kensaIraiShiyoKaishiDtFrom ");
                commandParams.Add("@kensaIraiShiyoKaishiDtFrom", SqlDbType.NVarChar).Value = kensaIraiShiyoKaishiDtFrom;

                sb.Append("AND CONCAT(KensaIraiTbl.KensaIraiShiyoKaishiNen, KensaIraiTbl.KensaIraiShiyoKaishiTsuki, KensaIraiTbl.KensaIraiShiyoKaishiBi) <= @kensaIraiShiyoKaishiDtTo ");
                commandParams.Add("@kensaIraiShiyoKaishiDtTo", SqlDbType.NVarChar).Value = kensaIraiShiyoKaishiDtTo;
            }

            // ・｛検査実施日の条件追加フラグ｝ = True の場合
            if (kensaJisshiBijokenTsuikaFlg)
            {
                sb.Append("AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) >= @kensaIraiKensaDtFrom ");
                commandParams.Add("@kensaIraiKensaDtFrom", SqlDbType.NVarChar).Value = kensaIraiKensaDtFrom;

                sb.Append("AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) <= @kensaIraiKensaDtTo ");
                commandParams.Add("@kensaIraiKensaDtTo", SqlDbType.NVarChar).Value = kensaIraiKensaDtTo;
            }

            #region to be removed
            //// ORDER BY
            //sqlContent.Append("ORDER BY                                                                                                          ");
            //sqlContent.Append("     ShishoMst.ShishoCd,                                                                                          ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiHoteiKbn,                                                                              ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiHokenjoCd,                                                                             ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiNendo,                                                                                 ");
            //sqlContent.Append("     KensaIraiTbl.KensaIraiRenban                                                                                 ");
            #endregion

            sb.Append("ORDER BY ");
            sb.Append("  ShishoMst.ShishoCd ");
            sb.Append("  , KensaIraiTbl.KensaIraiHoteiKbn ");
            sb.Append("  , KensaIraiTbl.KensaIraiHokenjoCd ");
            sb.Append("  , KensaIraiTbl.KensaIraiNendo ");
            sb.Append("  , KensaIraiTbl.KensaIraiRenban ");

            command.CommandText = sb.ToString();

            return command;
        }
        #endregion

    }
    #endregion
}