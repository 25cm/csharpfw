using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{    
    public partial class SuishitsuKensaUketsukeReportDataSet
    {
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeReportDataSetTableAdapters
{
    #region PrintFollowKensaListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintFollowKensaListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田   　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class PrintFollowKensaListTableAdapter
    {
        #region GetDataByCondition
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCondition
        /// <summary>
        /// フォロー検査対象リスト取得
        /// </summary>
        /// <param name="shikenCdPh">試験項目コード(pH)</param>
        /// <param name="shikenCdToshido">試験項目コード(透視度)</param>
        /// <param name="shikenCdBod">試験項目コード(BOD)</param>
        /// <param name="shikenCdZanen">試験項目コード(残塩)</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// 2015/01/15　habu   　　 条件に支所を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListDataTable GetDataByCondition(string shikenCdPh, string shikenCdToshido, string shikenCdBod, string shikenCdZanen,
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo, string shishoCd)
        {
            // クエリの作成
            SqlCommand command = CreateSqlCommand(shikenCdPh, shikenCdToshido, shikenCdBod, shikenCdZanen,
                nendo, uketsukeDateKbn, uketsukeDateFrom, uketsukeDateTo, iraiNoFrom, iraiNoTo, shishoCd);

            SqlDataAdapter adapt = new SqlDataAdapter(command);

            adapt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListDataTable table = new SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListDataTable();

            // 検索実行
            adapt.Fill(table);

            return table;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shikenCdPh">試験項目コード(pH)</param>
        /// <param name="shikenCdToshido">試験項目コード(透視度)</param>
        /// <param name="shikenCdBod">試験項目コード(BOD)</param>
        /// <param name="shikenCdZanen">試験項目コード(残塩)</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// 2015/01/15　habu   　　 条件に支所を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shikenCdPh, string shikenCdToshido, string shikenCdBod, string shikenCdZanen,
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo, string shishoCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" Select ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHokenjoCd, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiNendo, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiRenban, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiScreeningKbn, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiStatusKbn, ");
            sqlContent.AppendLine("     HdrTbl.SaisaisuiKbn, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd, ");
            sqlContent.AppendLine("     GyoshaMst.GyoshaNm, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuUketsukeDt, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuIraiNo, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSetchishaNm, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSetchibashoAdr, ");
            sqlContent.AppendLine("     ShoriHoshikiMst.ShoriHoshikiShubetsuNm, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiShoritaishoJinin, ");
            sqlContent.AppendLine("     PH.KeiryoShomeiKekkaValue as PhValue, ");
            sqlContent.AppendLine("     PH.KeiryoShomeiKekkaValue2 as PhKekka, ");
            sqlContent.AppendLine("     TR.KeiryoShomeiKekkaValue as TrValue, ");
            sqlContent.AppendLine("     TR.KeiryoShomeiKekkaValue2 as TrKekka, ");
            sqlContent.AppendLine("     ZANEN.KeiryoShomeiKekkaValue as ZanenValue, ");
            sqlContent.AppendLine("     ZANEN.KeiryoShomeiKekkaValue2 as ZanenKekka, ");
            sqlContent.AppendLine("     BOD.KeiryoShomeiKekkaValue as BodValue, ");
            sqlContent.AppendLine("     BOD.KeiryoShomeiKekkaValue2 as BodKekka ");
            sqlContent.AppendLine(" From ");
            sqlContent.AppendLine("     KensaDaicho11joHdrTbl as HdrTbl ");
            sqlContent.AppendLine("     Inner Join ");
            sqlContent.AppendLine("         KensaIraiTbl ");
            sqlContent.AppendLine("     On  HdrTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         GyoshaMst ");
            sqlContent.AppendLine("     On  GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         ShoriHoshikiMst ");
            sqlContent.AppendLine("     On  ShoriHoshikiMst.ShoriHoshikiKbn = KensaIraiTbl.KensaIraiShorihoshikiKbn ");
            sqlContent.AppendLine("     And ShoriHoshikiMst.ShoriHoshikiCd = KensaIraiTbl.KensaIraiShorihoshikiCd ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as PH ");
            sqlContent.AppendLine("     On  PH.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And PH.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And PH.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And PH.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And PH.ShikenkoumokuCd = @KmkCdPh ");
            sqlContent.AppendLine("     And PH.KeiryoShomeiSaiyoKbn = '1' ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as TR ");
            sqlContent.AppendLine("     On  TR.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And TR.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And TR.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And TR.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And TR.ShikenkoumokuCd = @KmkCdTr ");
            sqlContent.AppendLine("     And TR.KeiryoShomeiSaiyoKbn = '1' ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as ZANEN ");
            sqlContent.AppendLine("     On  ZANEN.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And ZANEN.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And ZANEN.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And ZANEN.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And ZANEN.ShikenkoumokuCd = @KmkCdZanen ");
            sqlContent.AppendLine("     And ZANEN.KeiryoShomeiSaiyoKbn = '1' ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as BOD ");
            sqlContent.AppendLine("     On  BOD.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And BOD.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And BOD.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And BOD.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And BOD.ShikenkoumokuCd = @KmkCdBod ");
            sqlContent.AppendLine("     And BOD.KeiryoShomeiSaiyoKbn = '1' ");
            
            // 結合条件の設定（必須パラメータ）
            commandParams.Add("@KmkCdPh", SqlDbType.NVarChar).Value = shikenCdPh;
            commandParams.Add("@KmkCdTr", SqlDbType.NVarChar).Value = shikenCdToshido;
            commandParams.Add("@KmkCdZanen", SqlDbType.NVarChar).Value = shikenCdZanen;
            commandParams.Add("@KmkCdBod", SqlDbType.NVarChar).Value = shikenCdBod;

            sqlContent.AppendLine(" Where ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn = '3' ");
            sqlContent.AppendLine(" And ( ");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiScreeningKbn = '2' ");
            sqlContent.AppendLine("     Or  KensaIraiTbl.KensaIraiScreeningKbn = '3' ");
            sqlContent.AppendLine("     ) ");
            // 20150110 sou Start
            //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiStatusKbn = '50' ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiStatusKbn <= '50' ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuKeninKbn <> '1' ");
            // 20150110 sou End
            sqlContent.AppendLine(" And HdrTbl.SaisaisuiKbn = '0' ");
            
            // 201501015 habu 取得条件に支所を追加
            // 受付支所
            if (!string.IsNullOrEmpty(shishoCd))
            {
                sqlContent.AppendLine(" And HdrTbl.ShishoCd = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            // 受付年度
            if (!string.IsNullOrEmpty(nendo))
            {
                // 20150120 sou Start
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @nendo1+'0401' ");
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @nendo2+'0331' ");
                //commandParams.Add("@nendo1", SqlDbType.NVarChar).Value = nendo;
                //commandParams.Add("@nendo2", SqlDbType.NVarChar).Value = int.Parse(nendo) + 1;
                sqlContent.AppendLine(" And HdrTbl.IraiNendo = @nendo ");
                commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
                // 20150120 sou End
            }
            
            // 受付日
            if (!string.IsNullOrEmpty(uketsukeDateKbn) && uketsukeDateKbn == "1")
            {
                // 受付日(From)
                if (!string.IsNullOrEmpty(uketsukeDateFrom))
                {
                    // 20150120 sou Start
                    //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @fromDt ");
                    sqlContent.AppendLine(" And HdrTbl.KensaIraiUketsukeDt >= @fromDt ");
                    // 20150120 sou End
                    commandParams.Add("@fromDt", SqlDbType.NVarChar).Value = uketsukeDateFrom;
                }

                // 受付日(To)
                if (!string.IsNullOrEmpty(uketsukeDateTo))
                {
                    // 20150120 sou Start
                    //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @toDt ");
                    sqlContent.AppendLine(" And HdrTbl.KensaIraiUketsukeDt <= @toDt ");
                    // 20150120 sou End
                    commandParams.Add("@toDt", SqlDbType.NVarChar).Value = uketsukeDateTo;
                }
            }
            
            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoFrom))
            {
                // 20150120 sou Start
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo >= @fromIraiNo ");
                sqlContent.AppendLine(" And HdrTbl.SuishitsuKensaIraiNo >= @fromIraiNo ");
                // 20150120 sou End
                commandParams.Add("@fromIraiNo", SqlDbType.NVarChar).Value = iraiNoFrom;
            }

            // 依頼番号(To)
            if (!string.IsNullOrEmpty(iraiNoTo))
            {
                // 20150120 sou Start
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo <= @toIraiNo ");
                sqlContent.AppendLine(" And HdrTbl.SuishitsuKensaIraiNo <= @toIraiNo ");
                // 20150120 sou End
                commandParams.Add("@toIraiNo", SqlDbType.NVarChar).Value = iraiNoTo;
            }

            sqlContent.AppendLine(" Order By ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuUketsukeDt, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuIraiNo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region PrintHotei11joIjoListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHotei11joIjoListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田   　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class PrintHotei11joIjoListTableAdapter
    {
        #region GetDataByCondition
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCondition
        /// <summary>
        /// フォロー検査対象リスト取得
        /// </summary>
        /// <param name="shikenCdPh">試験項目コード(pH)</param>
        /// <param name="shikenCdToshido">試験項目コード(透視度)</param>
        /// <param name="shikenCdBod">試験項目コード(BOD)</param>
        /// <param name="shikenCdZanen">試験項目コード(残塩)</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListDataTable GetDataByCondition(string shikenCdPh, string shikenCdToshido, string shikenCdBod, string shikenCdZanen,
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo, string shishoCd)
        {
            // クエリの作成
            SqlCommand command = CreateSqlCommand(shikenCdPh, shikenCdToshido, shikenCdBod, shikenCdZanen,
                nendo, uketsukeDateKbn, uketsukeDateFrom, uketsukeDateTo, iraiNoFrom, iraiNoTo, shishoCd);

            SqlDataAdapter adapt = new SqlDataAdapter(command);

            adapt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListDataTable table = new SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListDataTable();

            // 検索実行
            adapt.Fill(table);

            return table;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shikenCdPh">試験項目コード(pH)</param>
        /// <param name="shikenCdToshido">試験項目コード(透視度)</param>
        /// <param name="shikenCdBod">試験項目コード(BOD)</param>
        /// <param name="shikenCdZanen">試験項目コード(残塩)</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// </history>
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shikenCdPh, string shikenCdToshido, string shikenCdBod, string shikenCdZanen,
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo, string shishoCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();
            sqlContent.AppendLine(" Select ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHokenjoCd, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiNendo, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiRenban, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSeikyuGyoshaCd, ");
            sqlContent.AppendLine("     GyoshaMst.GyoshaNm, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuUketsukeDt, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuIraiNo, ");
            sqlContent.AppendLine("     HdrTbl.ScreeningKoho, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSetchishaNm, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSetchibashoAdr, ");
            sqlContent.AppendLine("     ShoriHoshikiMst.ShoriHoshikiShubetsuNm, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiShoritaishoJinin, ");
            sqlContent.AppendLine("     PH.KeiryoShomeiKekkaValue as PhValue, ");
            sqlContent.AppendLine("     PH.KeiryoShomeiKekkaValue2 as PhKekka, ");
            sqlContent.AppendLine("     TR.KeiryoShomeiKekkaValue as TrValue, ");
            sqlContent.AppendLine("     TR.KeiryoShomeiKekkaValue2 as TrKekka, ");
            sqlContent.AppendLine("     ZANEN.KeiryoShomeiKekkaValue as ZanenValue, ");
            sqlContent.AppendLine("     ZANEN.KeiryoShomeiKekkaValue2 as ZanenKekka, ");
            sqlContent.AppendLine("     BOD.KeiryoShomeiKekkaValue as BodValue, ");
            sqlContent.AppendLine("     BOD.KeiryoShomeiKekkaValue2 as BodKekka ");
            sqlContent.AppendLine(" From ");
            sqlContent.AppendLine("     KensaDaicho11joHdrTbl as HdrTbl ");
            sqlContent.AppendLine("     Inner Join ");
            sqlContent.AppendLine("         KensaIraiTbl ");
            sqlContent.AppendLine("     On  HdrTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         GyoshaMst ");
            sqlContent.AppendLine("     On  GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiSeikyuGyoshaCd ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         ShoriHoshikiMst ");
            sqlContent.AppendLine("     On  ShoriHoshikiMst.ShoriHoshikiKbn = KensaIraiTbl.KensaIraiShorihoshikiKbn ");
            sqlContent.AppendLine("     And ShoriHoshikiMst.ShoriHoshikiCd = KensaIraiTbl.KensaIraiShorihoshikiCd ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as PH ");
            sqlContent.AppendLine("     On  PH.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And PH.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And PH.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And PH.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And PH.ShikenkoumokuCd = @KmkCdPh ");
            sqlContent.AppendLine("     And PH.KeiryoShomeiSaiyoKbn = '1' ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as TR ");
            sqlContent.AppendLine("     On  TR.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And TR.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And TR.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And TR.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And TR.ShikenkoumokuCd = @KmkCdTr ");
            sqlContent.AppendLine("     And TR.KeiryoShomeiSaiyoKbn = '1' ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as ZANEN ");
            sqlContent.AppendLine("     On  ZANEN.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And ZANEN.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And ZANEN.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And ZANEN.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And ZANEN.ShikenkoumokuCd = @KmkCdZanen ");
            sqlContent.AppendLine("     And ZANEN.KeiryoShomeiSaiyoKbn = '1' ");
            sqlContent.AppendLine("     Left Join ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl as BOD ");
            sqlContent.AppendLine("     On  BOD.KensaKbn = HdrTbl.KensaKbn ");
            sqlContent.AppendLine("     And BOD.IraiNendo = HdrTbl.IraiNendo ");
            sqlContent.AppendLine("     And BOD.ShishoCd = HdrTbl.ShishoCd ");
            sqlContent.AppendLine("     And BOD.SuishitsuKensaIraiNo = HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine("     And BOD.ShikenkoumokuCd = @KmkCdBod ");
            sqlContent.AppendLine("     And BOD.KeiryoShomeiSaiyoKbn = '1' ");
            
            // 結合条件の設定（必須パラメータ）
            commandParams.Add("@KmkCdPh", SqlDbType.NVarChar).Value = shikenCdPh;
            commandParams.Add("@KmkCdTr", SqlDbType.NVarChar).Value = shikenCdToshido;
            commandParams.Add("@KmkCdZanen", SqlDbType.NVarChar).Value = shikenCdZanen;
            commandParams.Add("@KmkCdBod", SqlDbType.NVarChar).Value = shikenCdBod;

            sqlContent.AppendLine(" Where ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn = '3' ");
            sqlContent.AppendLine(" And ( ");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiScreeningKbn = '1' ");
            sqlContent.AppendLine("     Or  KensaIraiTbl.KensaIraiScreeningKbn = '3' ");
            sqlContent.AppendLine("     ) ");
            // 20150110 sou Start
            //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiStatusKbn = '50' ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiStatusKbn <= '50' ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuKeninKbn <> '1' ");
            // 20150110 sou End
            sqlContent.AppendLine(" And HdrTbl.SaisaisuiKbn = '0' ");
            
            // 20150115 habu 取得条件に支所を追加
            // 受付支所
            if (!string.IsNullOrEmpty(shishoCd))
            {
                sqlContent.AppendLine(" And HdrTbl.ShishoCd = @shishoCd ");
                commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }

            // 受付年度
            if (!string.IsNullOrEmpty(nendo))
            {
                // 20150120 sou Start
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @nendo1+'0401' ");
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @nendo2+'0331' ");
                //commandParams.Add("@nendo1", SqlDbType.NVarChar).Value = nendo;
                //commandParams.Add("@nendo2", SqlDbType.NVarChar).Value = int.Parse(nendo) + 1;
                sqlContent.AppendLine(" And HdrTbl.IraiNendo = @nendo ");
                commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
                // 20150120 sou End
            }
            
            // 受付日
            if (!string.IsNullOrEmpty(uketsukeDateKbn) && uketsukeDateKbn == "1")
            {
                // 受付日(From)
                if (!string.IsNullOrEmpty(uketsukeDateFrom))
                {
                    // 20150120 sou Start
                    //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @fromDt ");
                    sqlContent.AppendLine(" And HdrTbl.KensaIraiUketsukeDt >= @fromDt ");
                    // 20150120 sou End
                    commandParams.Add("@fromDt", SqlDbType.NVarChar).Value = uketsukeDateFrom;
                }

                // 受付日(To)
                if (!string.IsNullOrEmpty(uketsukeDateTo))
                {
                    // 20150120 sou Start
                    //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @toDt ");
                    sqlContent.AppendLine(" And HdrTbl.KensaIraiUketsukeDt <= @toDt ");
                    // 20150120 sou End
                    commandParams.Add("@toDt", SqlDbType.NVarChar).Value = uketsukeDateTo;
                }
            }
            
            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoFrom))
            {
                // 20150120 sou Start
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo >= @fromIraiNo ");
                sqlContent.AppendLine(" And HdrTbl.SuishitsuKensaIraiNo >= @fromIraiNo ");
                // 20150120 sou End
                commandParams.Add("@fromIraiNo", SqlDbType.NVarChar).Value = iraiNoFrom;
            }

            // 依頼番号(To)
            if (!string.IsNullOrEmpty(iraiNoTo))
            {
                // 20150120 sou Start
                //sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo <= @toIraiNo ");
                sqlContent.AppendLine(" And HdrTbl.SuishitsuKensaIraiNo <= @toIraiNo ");
                // 20150120 sou End
                commandParams.Add("@toIraiNo", SqlDbType.NVarChar).Value = iraiNoTo;
            }

            sqlContent.AppendLine(" Order By ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuUketsukeDt, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiSuishitsuIraiNo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Print9joKensaDaichoHdrTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print9joKensaDaichoHdrTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田   　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class Print9joKensaDaichoHdrTableAdapter
    {
        #region GetDataByCondition
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCondition
        /// <summary>
        /// ９条検査台帳ヘッダリスト取得
        /// </summary>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoHdrDataTable GetDataByCondition(string shishoCd, string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            // クエリの作成
            SqlCommand command = CreateSqlCommand(shishoCd, nendo, uketsukeDateKbn, uketsukeDateFrom, uketsukeDateTo, iraiNoFrom, iraiNoTo);

            SqlDataAdapter adapt = new SqlDataAdapter(command);

            adapt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoHdrDataTable table = new SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoHdrDataTable();

            // 検索実行
            adapt.Fill(table);

            return table;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// </history>
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shishoCd, string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();
            
            sqlContent.AppendLine(" SELECT ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban, ");
            sqlContent.AppendLine("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd, ");
            sqlContent.AppendLine("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoNendo, ");
            sqlContent.AppendLine("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoRenban, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.IraiNendo, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.ShishoCd, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo, ");
            sqlContent.AppendLine("     KeiryoShomeiIraiTbl.KeiryoShomeiSuisitsuCd, ");
            sqlContent.AppendLine("     SuishitsuMst.SuishitsuNm, ");
            sqlContent.AppendLine("     KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiKbn, ");
            sqlContent.AppendLine("     KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiCd, ");
            sqlContent.AppendLine("     ShoriHoshikiMst.ShoriHoshikiShubetsuNm, ");
            sqlContent.AppendLine("     ShoriHoshikiMst.ShoriHoshikiNm, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.KachoKeninKbn, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.HukuKachoKeninKbn, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.KeiryoKanrishaKeninKbn ");
            sqlContent.AppendLine(" FROM ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl ");
            sqlContent.AppendLine("     INNER JOIN ");
            sqlContent.AppendLine("         KeiryoShomeiIraiTbl ");
            sqlContent.AppendLine("     ON  KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo = KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo ");
            sqlContent.AppendLine("     AND KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd = KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd ");
            sqlContent.AppendLine("     AND KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban = KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban ");
            sqlContent.AppendLine("     LEFT OUTER JOIN ");
            sqlContent.AppendLine("         SuishitsuMst ");
            sqlContent.AppendLine("     ON  KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd = SuishitsuMst.SuishitsuShishoCd ");
            sqlContent.AppendLine("     AND KeiryoShomeiIraiTbl.KeiryoShomeiSuisitsuCd = SuishitsuMst.SuishitsuCd ");
            sqlContent.AppendLine("     LEFT OUTER JOIN ");
            sqlContent.AppendLine("         ShoriHoshikiMst ");
            sqlContent.AppendLine("     ON  KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiKbn = ShoriHoshikiMst.ShoriHoshikiKbn ");
            sqlContent.AppendLine("     AND KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiCd = ShoriHoshikiMst.ShoriHoshikiCd ");
            sqlContent.AppendLine(" WHERE ");
            
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.ShishoCd = @ShishoCd ");
            commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = shishoCd;

            sqlContent.AppendLine(" AND ( ");
            sqlContent.AppendLine("         KensaDaicho9joHdrTbl.KachoKeninKbn = '0' ");
            sqlContent.AppendLine("     OR  KensaDaicho9joHdrTbl.HukuKachoKeninKbn = '0' ");
            sqlContent.AppendLine("     OR  KensaDaicho9joHdrTbl.KeiryoKanrishaKeninKbn = '0' ");
            sqlContent.AppendLine("     ) ");                        

            // 受付年度
            if (!string.IsNullOrEmpty(nendo))
            {
                sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.IraiNendo = @nendo");
                commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
            }

            // 受付日
            if (!string.IsNullOrEmpty(uketsukeDateKbn) && uketsukeDateKbn == "1")
            {
                // 受付日(From)
                if (!string.IsNullOrEmpty(uketsukeDateFrom))
                {
                    sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.KensaIraiUketsukeDt >= @fromDt ");
                    commandParams.Add("@fromDt", SqlDbType.NVarChar).Value = uketsukeDateFrom;
                }

                // 受付日(To)
                if (!string.IsNullOrEmpty(uketsukeDateTo))
                {
                    sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.KensaIraiUketsukeDt <= @toDt ");
                    commandParams.Add("@toDt", SqlDbType.NVarChar).Value = uketsukeDateTo;
                }
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoFrom))
            {
                sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo >= @fromIraiNo ");
                commandParams.Add("@fromIraiNo", SqlDbType.NVarChar).Value = iraiNoFrom;
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoTo))
            {
                sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo <= @toIraiNo ");
                commandParams.Add("@toIraiNo", SqlDbType.NVarChar).Value = iraiNoTo;
            }

            sqlContent.AppendLine(" ORDER BY ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.IraiNendo, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.ShishoCd, ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Print9joKensaDaichoDtlTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print9joKensaDaichoDtlTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田   　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class Print9joKensaDaichoDtlTableAdapter
    {
        #region GetDataByCondition
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCondition
        /// <summary>
        /// ９条検査台帳ヘッダリスト取得
        /// </summary>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoDtlDataTable GetDataByCondition(string shishoCd, string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            // クエリの作成
            SqlCommand command = CreateSqlCommand(shishoCd, nendo, uketsukeDateKbn, uketsukeDateFrom, uketsukeDateTo, iraiNoFrom, iraiNoTo);

            SqlDataAdapter adapt = new SqlDataAdapter(command);

            adapt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoDtlDataTable table = new SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoDtlDataTable();

            // 検索実行
            adapt.Fill(table);

            return table;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　豊田   　　 新規作成
        /// </history>
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shishoCd, string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" SELECT ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaKbn, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.IraiNendo, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.ShishoCd, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.SuishitsuKensaIraiNo, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.ShikenkoumokuCd, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.SaikensaKbn, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsu, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuBodTr, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuKako, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuBodOver, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuEnkaIon, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuSsTr, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuAnmonia, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuAnmoniaTn, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KensaShubetsuCodOver, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue2, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoShomeiKekkaCd, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoShomeiKekkaOndo, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoShomeiKekkaNyuryoku, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoShomeiGaibuItakuFlg, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoShomeiSaiyoKbn, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KakuninKensaSoti, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KachoKeninKbn, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.HukuKachoKeninKbn, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.KeiryoKanrishaKeninKbn, ");
            sqlContent.AppendLine("     KensaDaichoDtlTbl.YachoKinyuKakuninKbn ");
            sqlContent.AppendLine(" FROM ");
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl ");
            sqlContent.AppendLine("     INNER JOIN ");
            sqlContent.AppendLine("         KensaDaichoDtlTbl ");
            sqlContent.AppendLine("     ON  KensaDaichoDtlTbl.KensaKbn = '1' ");
            sqlContent.AppendLine("     AND KensaDaichoDtlTbl.IraiNendo = KensaDaicho9joHdrTbl.IraiNendo ");
            sqlContent.AppendLine("     AND KensaDaichoDtlTbl.ShishoCd = KensaDaicho9joHdrTbl.ShishoCd ");
            sqlContent.AppendLine("     AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo = KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.AppendLine(" WHERE ");
            
            sqlContent.AppendLine("     KensaDaicho9joHdrTbl.ShishoCd = @ShishoCd ");
            commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = shishoCd;

            sqlContent.AppendLine(" AND ( ");
            sqlContent.AppendLine("         KensaDaicho9joHdrTbl.KachoKeninKbn = '0' ");
            sqlContent.AppendLine("     OR  KensaDaicho9joHdrTbl.HukuKachoKeninKbn = '0' ");
            sqlContent.AppendLine("     OR  KensaDaicho9joHdrTbl.KeiryoKanrishaKeninKbn = '0' ");
            sqlContent.AppendLine("     ) ");

            // 受付年度
            if (!string.IsNullOrEmpty(nendo))
            {
                sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.IraiNendo = @nendo");
                commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
            }

            // 受付日
            if (!string.IsNullOrEmpty(uketsukeDateKbn) && uketsukeDateKbn == "1")
            {
                // 受付日(From)
                if (!string.IsNullOrEmpty(uketsukeDateFrom))
                {
                    sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.KensaIraiUketsukeDt >= @fromDt ");
                    commandParams.Add("@fromDt", SqlDbType.NVarChar).Value = uketsukeDateFrom;
                }

                // 受付日(To)
                if (!string.IsNullOrEmpty(uketsukeDateTo))
                {
                    sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.KensaIraiUketsukeDt <= @toDt ");
                    commandParams.Add("@toDt", SqlDbType.NVarChar).Value = uketsukeDateTo;
                }
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoFrom))
            {
                sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo >= @fromIraiNo ");
                commandParams.Add("@fromIraiNo", SqlDbType.NVarChar).Value = iraiNoFrom;
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoTo))
            {
                sqlContent.AppendLine(" And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo <= @toIraiNo ");
                commandParams.Add("@toIraiNo", SqlDbType.NVarChar).Value = iraiNoTo;
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Print11joKensaDaichoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print11joKensaDaichoTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class Print11joKensaDaichoTableAdapter
    {
        #region to be removed
        //#region GetDataByCondition
        //////////////////////////////////////////////////////////////////////////////
        ////  インターフェイス名 ： GetDataByCondition
        ///// <summary>
        ///// ９条検査台帳ヘッダリスト取得
        ///// </summary>
        ///// <param name="shishoCd">支所コード</param>
        ///// <param name="nendo">年度</param>
        ///// <param name="uketsukeDateKbn">条件追加区分</param>
        ///// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        ///// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        ///// <param name="iraiNoFrom">依頼No（開始）</param>
        ///// <param name="iraiNoTo">依頼No（終了）</param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/12/16　宗     　　 新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //[DataObjectMethod(DataObjectMethodType.Select)]
        //internal SuishitsuKensaUketsukeReportDataSet.Print11joKensaDaichoDataTable GetDataByCondition(string shishoCd, string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string kensaKbn, string iraiNoFrom, string iraiNoTo,
        //    string kmkCdPh, string kmkCdTr, string kmkCdBod, string kmkCdZanen, string kmkCdCl)
        //{
        //    // クエリの作成
        //    SqlCommand command = CreateSqlCommand(shishoCd, nendo, uketsukeDateKbn, uketsukeDateFrom, uketsukeDateTo, kensaKbn, iraiNoFrom, iraiNoTo,
        //        kmkCdPh, kmkCdTr, kmkCdBod, kmkCdZanen, kmkCdCl);

        //    SqlDataAdapter adapt = new SqlDataAdapter(command);

        //    adapt.SelectCommand.Connection = this.Connection;

        //    SuishitsuKensaUketsukeReportDataSet.Print11joKensaDaichoDataTable table = new SuishitsuKensaUketsukeReportDataSet.Print11joKensaDaichoDataTable();

        //    // 検索実行
        //    adapt.Fill(table);

        //    return table;
        //}
        //#endregion

        //#region CreateSqlCommand
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： CreateSqlCommand
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="shishoCd">支所コード</param>
        ///// <param name="nendo">年度</param>
        ///// <param name="uketsukeDateKbn">条件追加区分</param>
        ///// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        ///// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        ///// <param name="iraiNoFrom">依頼No（開始）</param>
        ///// <param name="iraiNoTo">依頼No（終了）</param>
        ///// <param name="kmkCdPh">試験項目コード(pH)</param>
        ///// <param name="kmkCdTr">試験項目コード(透視度)</param>
        ///// <param name="kmkCdBod">試験項目コード(BOD)</param>
        ///// <param name="kmkCdZanen">試験項目コード(残塩)</param>
        ///// <param name="kmkCdCl">試験項目コード(塩化物イオン)</param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/12/16　宗     　　 新規作成
        ///// </history>
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private SqlCommand CreateSqlCommand(string shishoCd, string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string kensaKbn, string iraiNoFrom, string iraiNoTo,
        //    string kmkCdPh, string kmkCdTr, string kmkCdBod, string kmkCdZanen, string kmkCdCl)
        //{
        //    SqlCommand command = new SqlCommand();
        //    SqlParameterCollection commandParams = command.Parameters;
        //    StringBuilder sqlContent = new StringBuilder();

        //    sqlContent.AppendLine("Select KensaDaicho11joHdrTbl.KensaKbn ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.IraiNendo ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.ShishoCd ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.ScreeningKoho ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.FollowKoho ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.CrossCheckSuishitsu ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.CrossCheckKako ");
        //    sqlContent.AppendLine(", ConstMst.ConstNm ");
        //    sqlContent.AppendLine(", KensaIraiTbl.ShoriHoshikiShubetsuNm ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.KachoKeninKbn ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.HukuKachoKeninKbn ");
        //    sqlContent.AppendLine(", PH1.KeiryoShomeiKekkaValue as PH1KekkaValue ");
        //    sqlContent.AppendLine(", PH1.KeiryoShomeiKekkaOndo as PH1KekkaOndo ");
        //    sqlContent.AppendLine(", PH1.KeiryoShomeiKekkaCd as PH1KekkaCd ");
        //    sqlContent.AppendLine(", PH1.KensaShubetsu as PH1KensaShubetsu ");
        //    sqlContent.AppendLine(", PH1.KeiryoShomeiKekkaNyuryoku as PH1KekkaNyuryoku ");
        //    sqlContent.AppendLine(", PH1.KeiryoShomeiSaiyoKbn as PH1SaiyoKbn ");
        //    sqlContent.AppendLine(", PH2.KeiryoShomeiKekkaValue as PH2KekkaValue ");
        //    sqlContent.AppendLine(", PH2.KeiryoShomeiKekkaOndo as PH2KekkaOndo ");
        //    sqlContent.AppendLine(", PH2.KeiryoShomeiKekkaCd as PH2KekkaCd ");
        //    sqlContent.AppendLine(", PH2.KensaShubetsu as PH2KensaShubetsu ");
        //    sqlContent.AppendLine(", PH2.KeiryoShomeiKekkaNyuryoku as PH2KekkaNyuryoku ");
        //    sqlContent.AppendLine(", PH2.KeiryoShomeiSaiyoKbn as PH2SaiyoKbn ");
        //    sqlContent.AppendLine(", TR1.KeiryoShomeiKekkaValue as TR1KekkaValue ");
        //    sqlContent.AppendLine(", TR1.KeiryoShomeiKekkaOndo as TR1KekkaOndo ");
        //    sqlContent.AppendLine(", TR1.KeiryoShomeiKekkaCd as TR1KekkaCd ");
        //    sqlContent.AppendLine(", TR1.KensaShubetsu as TR1KensaShubetsu ");
        //    sqlContent.AppendLine(", TR1.KeiryoShomeiKekkaNyuryoku as TR1KekkaNyuryoku ");
        //    sqlContent.AppendLine(", TR1.KeiryoShomeiSaiyoKbn as TR1SaiyoKbn ");
        //    sqlContent.AppendLine(", TR2.KeiryoShomeiKekkaValue as TR2KekkaValue ");
        //    sqlContent.AppendLine(", TR2.KeiryoShomeiKekkaOndo as TR2KekkaOndo ");
        //    sqlContent.AppendLine(", TR2.KeiryoShomeiKekkaCd as TR2KekkaCd ");
        //    sqlContent.AppendLine(", TR2.KensaShubetsu as TR2KensaShubetsu ");
        //    sqlContent.AppendLine(", TR2.KeiryoShomeiKekkaNyuryoku as TR2KekkaNyuryoku ");
        //    sqlContent.AppendLine(", TR2.KeiryoShomeiSaiyoKbn as TR2SaiyoKbn ");
        //    sqlContent.AppendLine(", BOD1.KeiryoShomeiKekkaValue as BOD1KekkaValue ");
        //    sqlContent.AppendLine(", BOD1.KeiryoShomeiKekkaOndo as BOD1KekkaOndo ");
        //    sqlContent.AppendLine(", BOD1.KeiryoShomeiKekkaCd as BOD1KekkaCd ");
        //    sqlContent.AppendLine(", BOD1.KensaShubetsu as BOD1KensaShubetsu ");
        //    sqlContent.AppendLine(", BOD1.KeiryoShomeiKekkaNyuryoku as BOD1KekkaNyuryoku ");
        //    sqlContent.AppendLine(", BOD1.KeiryoShomeiSaiyoKbn as BOD1SaiyoKbn ");
        //    sqlContent.AppendLine(", BOD2.KeiryoShomeiKekkaValue as BOD2KekkaValue ");
        //    sqlContent.AppendLine(", BOD2.KeiryoShomeiKekkaOndo as BOD2KekkaOndo ");
        //    sqlContent.AppendLine(", BOD2.KeiryoShomeiKekkaCd as BOD2KekkaCd ");
        //    sqlContent.AppendLine(", BOD2.KensaShubetsu as BOD2KensaShubetsu ");
        //    sqlContent.AppendLine(", BOD2.KeiryoShomeiKekkaNyuryoku as BOD2KekkaNyuryoku ");
        //    sqlContent.AppendLine(", BOD2.KeiryoShomeiSaiyoKbn as BOD2SaiyoKbn ");
        //    sqlContent.AppendLine(", ZANEN1.KeiryoShomeiKekkaValue as ZANEN1KekkaValue ");
        //    sqlContent.AppendLine(", ZANEN1.KeiryoShomeiKekkaOndo as ZANEN1KekkaOndo ");
        //    sqlContent.AppendLine(", ZANEN1.KeiryoShomeiKekkaCd as ZANEN1KekkaCd ");
        //    sqlContent.AppendLine(", ZANEN1.KensaShubetsu as ZANEN1KensaShubetsu ");
        //    sqlContent.AppendLine(", ZANEN1.KeiryoShomeiKekkaNyuryoku as ZANEN1KekkaNyuryoku ");
        //    sqlContent.AppendLine(", ZANEN1.KeiryoShomeiSaiyoKbn as ZANEN1SaiyoKbn ");
        //    sqlContent.AppendLine(", ZANEN2.KeiryoShomeiKekkaValue as ZANEN2KekkaValue ");
        //    sqlContent.AppendLine(", ZANEN2.KeiryoShomeiKekkaOndo as ZANEN2KekkaOndo ");
        //    sqlContent.AppendLine(", ZANEN2.KeiryoShomeiKekkaCd as ZANEN2KekkaCd ");
        //    sqlContent.AppendLine(", ZANEN2.KensaShubetsu as ZANEN2KensaShubetsu ");
        //    sqlContent.AppendLine(", ZANEN2.KeiryoShomeiKekkaNyuryoku as ZANEN2KekkaNyuryoku ");
        //    sqlContent.AppendLine(", ZANEN2.KeiryoShomeiSaiyoKbn as ZANEN2SaiyoKbn ");
        //    sqlContent.AppendLine(", CL1.KeiryoShomeiKekkaValue as CL1KekkaValue ");
        //    sqlContent.AppendLine(", CL1.KeiryoShomeiKekkaOndo as CL1KekkaOndo ");
        //    sqlContent.AppendLine(", CL1.KeiryoShomeiKekkaCd as CL1KekkaCd ");
        //    sqlContent.AppendLine(", CL1.KensaShubetsu as CL1KensaShubetsu ");
        //    sqlContent.AppendLine(", CL1.KeiryoShomeiKekkaNyuryoku as CL1KekkaNyuryoku ");
        //    sqlContent.AppendLine(", CL1.KeiryoShomeiSaiyoKbn as CL1SaiyoKbn ");
        //    sqlContent.AppendLine(", CL2.KeiryoShomeiKekkaValue as CL2KekkaValue ");
        //    sqlContent.AppendLine(", CL2.KeiryoShomeiKekkaOndo as CL2KekkaOndo ");
        //    sqlContent.AppendLine(", CL2.KeiryoShomeiKekkaCd as CL2KekkaCd ");
        //    sqlContent.AppendLine(", CL2.KensaShubetsu as CL2KensaShubetsu ");
        //    sqlContent.AppendLine(", CL2.KeiryoShomeiKekkaNyuryoku as CL2KekkaNyuryoku ");
        //    sqlContent.AppendLine(", CL2.KeiryoShomeiSaiyoKbn as CL2SaiyoKbn ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.EnkaIonKako1 ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.EnkaIonKako2 ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.EnkaIonKako3 ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.EnkaIonKako4 ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.EnkaIonKako5 ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.KensaKekkaKakuteiDt ");
        //    sqlContent.AppendLine(", BOD1.KensaShubetsuBodTr as BOD1KensaShubetsuBodTr ");
        //    sqlContent.AppendLine(", BOD2.KensaShubetsuBodTr as BOD2KensaShubetsuBodTr ");
        //    sqlContent.AppendLine(", TR1.KensaShubetsuBodTr as Tr1KensaShubetsuBodTr ");
        //    sqlContent.AppendLine(", TR2.KensaShubetsuBodTr as Tr2KensaShubetsuBodTr ");
        //    sqlContent.AppendLine(", PH1.KensaShubetsuKako as Ph1KensaShubetsuKako ");
        //    sqlContent.AppendLine(", PH2.KensaShubetsuKako as Ph2KensaShubetsuKako ");
        //    sqlContent.AppendLine(", TR1.KensaShubetsuKako as Tr1KensaShubetsuKako ");
        //    sqlContent.AppendLine(", TR2.KensaShubetsuKako as Tr2KensaShubetsuKako ");
        //    sqlContent.AppendLine(", BOD1.KensaShubetsuKako as Bod1KensaShubetsuKako ");
        //    sqlContent.AppendLine(", BOD2.KensaShubetsuKako as Bod2KensaShubetsuKako ");
        //    sqlContent.AppendLine(", ZANEN1.KensaShubetsuKako as Zanen1KensaShubetsuKako ");
        //    sqlContent.AppendLine(", ZANEN2.KensaShubetsuKako as Zanen2KensaShubetsuKako ");
        //    sqlContent.AppendLine(", CL1.KensaShubetsuKako as Cl1KensaShubetsuKako ");
        //    sqlContent.AppendLine(", CL2.KensaShubetsuKako as Cl2KensaShubetsuKako ");
        //    sqlContent.AppendLine(", BOD1.KensaShubetsuBodOver as BOD1KensaShubetsuBodOver ");
        //    sqlContent.AppendLine(", BOD2.KensaShubetsuBodOver as BOD2KensaShubetsuBodOver ");
        //    sqlContent.AppendLine(", CL1.KensaShubetsuEnkaIon as Cl1KensaShubetsuEnkaIon ");
        //    sqlContent.AppendLine(", CL2.KensaShubetsuEnkaIon as Cl2KensaShubetsuEnkaIon ");
        //    // 20150111 sou Start
        //    sqlContent.AppendLine(", KensaIraiTbl.KensaIraiJokasoHokenjoCd ");
        //    sqlContent.AppendLine(", KensaIraiTbl.KensaIraiJokasoTorokuNendo ");
        //    sqlContent.AppendLine(", KensaIraiTbl.KensaIraiJokasoRenban ");
        //    sqlContent.AppendLine(", KensaIraiTbl.UketsukeDt ");
        //    // 20150111 sou End
        //    sqlContent.AppendLine(" ");
        //    sqlContent.AppendLine("From KensaDaicho11joHdrTbl ");
        //    sqlContent.AppendLine("Inner Join ");
        //    sqlContent.AppendLine("( ");
        //    sqlContent.AppendLine("    Select KensaIraiTbl.KensaIraiHoteiKbn ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiHokenjoCd ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiNendo ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiRenban ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiShorihoshikiKbn ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiShorihoshikiCd ");
        //    sqlContent.AppendLine("    , ShoriHoshikiMst.ShoriHoshikiKbn ");
        //    sqlContent.AppendLine("    , ShoriHoshikiMst.ShoriHoshikiCd ");
        //    sqlContent.AppendLine("    , ShoriHoshikiMst.ShoriHoshikiShubetsuNm ");
        //    sqlContent.AppendLine("    , ShoriHoshikiMst.ShoriHoshikiNm ");
        //    // 20150111 sou Start
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiJokasoHokenjoCd ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiJokasoTorokuNendo ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiJokasoRenban ");
        //    sqlContent.AppendLine("    , KensaIraiTbl.KensaIraiSuishitsuUketsukeDt as UketsukeDt ");
        //    // 20150111 sou End
        //    sqlContent.AppendLine("    From KensaIraiTbl Left Join ShoriHoshikiMst ");
        //    sqlContent.AppendLine("    On KensaIraiTbl.KensaIraiShorihoshikiKbn = ShoriHoshikiMst.ShoriHoshikiKbn ");
        //    sqlContent.AppendLine("    and KensaIraiTbl.KensaIraiShorihoshikiCd = ShoriHoshikiMst.ShoriHoshikiCd ");
        //    sqlContent.AppendLine(") as KensaIraiTbl ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban ");
        //    sqlContent.AppendLine("Left Join ConstMst ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.HanteiCd = ConstMst.ConstValue ");
        //    sqlContent.AppendLine("    and '016' = ConstMst.ConstKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as PH1 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = PH1.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = PH1.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = PH1.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = PH1.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdPh = PH1.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '0' = PH1.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as PH2 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = PH2.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = PH2.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = PH2.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = PH2.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdPh = PH2.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '1' = PH2.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as TR1 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = TR1.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = TR1.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = TR1.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = TR1.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdTr = TR1.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '0' = TR1.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as TR2 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = TR2.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = TR2.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = TR2.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = TR2.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdTr = TR2.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '1' = TR2.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as BOD1 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = BOD1.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = BOD1.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = BOD1.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = BOD1.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdBod = BOD1.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '0' = BOD1.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as BOD2 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = BOD2.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = BOD2.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = BOD2.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = BOD2.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdBod = BOD2.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '1' = BOD2.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as ZANEN1 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = ZANEN1.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = ZANEN1.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = ZANEN1.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = ZANEN1.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdZanen = ZANEN1.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '0' = ZANEN1.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as ZANEN2 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = ZANEN2.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = ZANEN2.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = ZANEN2.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = ZANEN2.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdZanen = ZANEN2.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '1' = ZANEN2.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as CL1 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = CL1.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = CL1.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = CL1.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = CL1.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdCl = CL1.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '0' = CL1.SaikensaKbn ");
        //    sqlContent.AppendLine("Left Join KensaDaichoDtlTbl as CL2 ");
        //    sqlContent.AppendLine("    On KensaDaicho11joHdrTbl.KensaKbn = CL2.KensaKbn ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.IraiNendo = CL2.IraiNendo ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.ShishoCd = CL2.ShishoCd ");
        //    sqlContent.AppendLine("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = CL2.SuishitsuKensaIraiNo ");
        //    sqlContent.AppendLine("    and @kmkCdCl = CL2.ShikenkoumokuCd ");
        //    sqlContent.AppendLine("    and '1' = CL2.SaikensaKbn ");
        //    sqlContent.AppendLine(" ");
        //    sqlContent.AppendLine("Where KensaDaicho11joHdrTbl.ShishoCd = @ShishoCd ");
        //    sqlContent.AppendLine("and( ");
        //    sqlContent.AppendLine("    ( ");
        //    sqlContent.AppendLine("        KensaDaicho11joHdrTbl.SaisaisuiKbn = '0' ");
        //    sqlContent.AppendLine("        and(KensaDaicho11joHdrTbl.KachoKeninKbn = '0' ");
        //    sqlContent.AppendLine("        or KensaDaicho11joHdrTbl.HukuKachoKeninKbn = '0' ");
        //    sqlContent.AppendLine("        ) ");
        //    sqlContent.AppendLine("    ) ");
        //    sqlContent.AppendLine("    or ");
        //    sqlContent.AppendLine("    ( ");
        //    sqlContent.AppendLine("        KensaDaicho11joHdrTbl.SaisaisuiKbn = '1' ");
        //    sqlContent.AppendLine("        and(KensaDaicho11joHdrTbl.KachoKeninKbn = '0' ");
        //    sqlContent.AppendLine("        or KensaDaicho11joHdrTbl.HukuKachoKeninKbn = '0' ");
        //    sqlContent.AppendLine("        or KensaDaicho11joHdrTbl.KachoKeninKbnScreening = '0' ");
        //    sqlContent.AppendLine("        or KensaDaicho11joHdrTbl.HukuKachoKeninKbnScreening = '0' ");
        //    sqlContent.AppendLine("        ) ");
        //    sqlContent.AppendLine("    ) ");
        //    sqlContent.AppendLine(") ");
        //    sqlContent.AppendLine(" ");

        //    commandParams.Add("@kmkCdPh", SqlDbType.NVarChar).Value = kmkCdPh;
        //    commandParams.Add("@kmkCdTr", SqlDbType.NVarChar).Value = kmkCdTr;
        //    commandParams.Add("@kmkCdBod", SqlDbType.NVarChar).Value = kmkCdBod;
        //    commandParams.Add("@kmkCdZanen", SqlDbType.NVarChar).Value = kmkCdZanen;
        //    commandParams.Add("@kmkCdCl", SqlDbType.NVarChar).Value = kmkCdCl;

        //    commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = shishoCd;

        //    // 受付年度
        //    if (!string.IsNullOrEmpty(nendo))
        //    {
        //        sqlContent.AppendLine(" And KensaDaicho11joHdrTbl.IraiNendo = @nendo");
        //        commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
        //    }

        //    // 受付日
        //    if (!string.IsNullOrEmpty(uketsukeDateKbn) && uketsukeDateKbn == "1")
        //    {
        //        // 受付日(From)
        //        if (!string.IsNullOrEmpty(uketsukeDateFrom))
        //        {
        //            sqlContent.AppendLine(" And KensaDaicho11joHdrTbl.KensaIraiUketsukeDt >= @fromDt ");
        //            commandParams.Add("@fromDt", SqlDbType.NVarChar).Value = uketsukeDateFrom;
        //        }

        //        // 受付日(To)
        //        if (!string.IsNullOrEmpty(uketsukeDateTo))
        //        {
        //            sqlContent.AppendLine(" And KensaDaicho11joHdrTbl.KensaIraiUketsukeDt <= @toDt ");
        //            commandParams.Add("@toDt", SqlDbType.NVarChar).Value = uketsukeDateTo;
        //        }
        //    }

        //    // 検査区分
        //    if(!string.IsNullOrEmpty(kensaKbn))
        //    {
        //        sqlContent.AppendLine(" And KensaDaicho11joHdrTbl.KensaKbn = @kensaKbn ");
        //        commandParams.Add("@kensaKbn", SqlDbType.NVarChar).Value = kensaKbn;
        //    }

        //    // 依頼番号(From)
        //    if (!string.IsNullOrEmpty(iraiNoFrom))
        //    {
        //        sqlContent.AppendLine(" And KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo >= @fromIraiNo ");
        //        commandParams.Add("@fromIraiNo", SqlDbType.NVarChar).Value = iraiNoFrom;
        //    }

        //    // 依頼番号(To)
        //    if (!string.IsNullOrEmpty(iraiNoTo))
        //    {
        //        sqlContent.AppendLine(" And KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo <= @toIraiNo ");
        //        commandParams.Add("@toIraiNo", SqlDbType.NVarChar).Value = iraiNoTo;
        //    }

        //    sqlContent.AppendLine("Order By KensaDaicho11joHdrTbl.KensaKbn ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.IraiNendo ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.ShishoCd ");
        //    sqlContent.AppendLine(", KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo ");

        //    command.CommandText = sqlContent.ToString();

        //    return command;
        //}
        //#endregion
        #endregion
    }
    #endregion

    #region PrintFollowKensaListCountTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintFollowKensaListCountTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/11　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class PrintFollowKensaListCountTableAdapter
    {
        #region GetDataByCondition
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCondition
        /// <summary>
        /// フォロー検査対象リスト取得
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListCountDataTable GetDataByCondition(
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            // クエリの作成
            SqlCommand command = CreateSqlCommand(
                nendo, uketsukeDateKbn, uketsukeDateFrom, uketsukeDateTo, iraiNoFrom, iraiNoTo);

            SqlDataAdapter adapt = new SqlDataAdapter(command);

            adapt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListCountDataTable table = new SuishitsuKensaUketsukeReportDataSet.PrintFollowKensaListCountDataTable();

            // 検索実行
            adapt.Fill(table);

            return table;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" Select ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHokenjoCd, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiNendo, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiRenban ");
            sqlContent.AppendLine(" From ");
            sqlContent.AppendLine("     KensaIraiTbl ");
            sqlContent.AppendLine("     Inner Join ");
            sqlContent.AppendLine("         KensaDaicho11joHdrTbl as HdrTbl ");
            sqlContent.AppendLine("     On  HdrTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban ");
            sqlContent.AppendLine(" Where ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn = '3' ");
            sqlContent.AppendLine(" And ( ");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiScreeningKbn = '2' ");
            sqlContent.AppendLine("     Or  KensaIraiTbl.KensaIraiScreeningKbn = '3' ");
            sqlContent.AppendLine("     ) ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiStatusKbn <= '50' ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuKeninKbn <> '1' ");
            sqlContent.AppendLine(" And HdrTbl.SaisaisuiKbn = '0' ");

            // 受付年度
            if (!string.IsNullOrEmpty(nendo))
            {
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @nendo1+'0401' ");
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @nendo2+'0331' ");
                commandParams.Add("@nendo1", SqlDbType.NVarChar).Value = nendo;
                commandParams.Add("@nendo2", SqlDbType.NVarChar).Value = int.Parse(nendo) + 1;
            }

            // 受付日
            if (!string.IsNullOrEmpty(uketsukeDateKbn) && uketsukeDateKbn == "1")
            {
                // 受付日(From)
                if (!string.IsNullOrEmpty(uketsukeDateFrom))
                {
                    sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @fromDt ");
                    commandParams.Add("@fromDt", SqlDbType.NVarChar).Value = uketsukeDateFrom;
                }

                // 受付日(To)
                if (!string.IsNullOrEmpty(uketsukeDateTo))
                {
                    sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @toDt ");
                    commandParams.Add("@toDt", SqlDbType.NVarChar).Value = uketsukeDateTo;
                }
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoFrom))
            {
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo >= @fromIraiNo ");
                commandParams.Add("@fromIraiNo", SqlDbType.NVarChar).Value = iraiNoFrom;
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoTo))
            {
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo >= @toIraiNo ");
                commandParams.Add("@toIraiNo", SqlDbType.NVarChar).Value = iraiNoTo;
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region PrintHotei11joIjoListCountTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHotei11joIjoListCountTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/11　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class PrintHotei11joIjoListCountTableAdapter
    {
        #region GetDataByCondition
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCondition
        /// <summary>
        /// フォロー検査対象リスト取得
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListCountDataTable GetDataByCondition(
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            // クエリの作成
            SqlCommand command = CreateSqlCommand(
                nendo, uketsukeDateKbn, uketsukeDateFrom, uketsukeDateTo, iraiNoFrom, iraiNoTo);

            SqlDataAdapter adapt = new SqlDataAdapter(command);

            adapt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListCountDataTable table = new SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListCountDataTable();

            // 検索実行
            adapt.Fill(table);

            return table;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="uketsukeDateKbn">条件追加区分</param>
        /// <param name="uketsukeDateFrom">依頼受付日（開始）</param>
        /// <param name="uketsukeDateTo">依頼受付日（終了）</param>
        /// <param name="iraiNoFrom">依頼No（開始）</param>
        /// <param name="iraiNoTo">依頼No（終了）</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11　宗     　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string nendo, string uketsukeDateKbn, string uketsukeDateFrom, string uketsukeDateTo, string iraiNoFrom, string iraiNoTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();
            sqlContent.AppendLine(" Select ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHokenjoCd, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiNendo, ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiRenban ");
            sqlContent.AppendLine(" From ");
            sqlContent.AppendLine("     KensaIraiTbl ");
            sqlContent.AppendLine("     Inner Join ");
            sqlContent.AppendLine("         KensaDaicho11joHdrTbl as HdrTbl ");
            sqlContent.AppendLine("     On  HdrTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo ");
            sqlContent.AppendLine("     And HdrTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban ");
            sqlContent.AppendLine(" Where ");
            sqlContent.AppendLine("     KensaIraiTbl.KensaIraiHoteiKbn = '3' ");
            sqlContent.AppendLine(" And ( ");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiScreeningKbn = '1' ");
            sqlContent.AppendLine("     Or  KensaIraiTbl.KensaIraiScreeningKbn = '3' ");
            sqlContent.AppendLine("     ) ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiStatusKbn <= '50' ");
            sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuKeninKbn <> '1' ");
            sqlContent.AppendLine(" And HdrTbl.SaisaisuiKbn = '0' ");

            // 受付年度
            if (!string.IsNullOrEmpty(nendo))
            {
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @nendo1+'0401' ");
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @nendo2+'0331' ");
                commandParams.Add("@nendo1", SqlDbType.NVarChar).Value = nendo;
                commandParams.Add("@nendo2", SqlDbType.NVarChar).Value = int.Parse(nendo) + 1;
            }

            // 受付日
            if (!string.IsNullOrEmpty(uketsukeDateKbn) && uketsukeDateKbn == "1")
            {
                // 受付日(From)
                if (!string.IsNullOrEmpty(uketsukeDateFrom))
                {
                    sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @fromDt ");
                    commandParams.Add("@fromDt", SqlDbType.NVarChar).Value = uketsukeDateFrom;
                }

                // 受付日(To)
                if (!string.IsNullOrEmpty(uketsukeDateTo))
                {
                    sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @toDt ");
                    commandParams.Add("@toDt", SqlDbType.NVarChar).Value = uketsukeDateTo;
                }
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoFrom))
            {
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo >= @fromIraiNo ");
                commandParams.Add("@fromIraiNo", SqlDbType.NVarChar).Value = iraiNoFrom;
            }

            // 依頼番号(From)
            if (!string.IsNullOrEmpty(iraiNoTo))
            {
                sqlContent.AppendLine(" And KensaIraiTbl.KensaIraiSuishitsuIraiNo >= @toIraiNo ");
                commandParams.Add("@toIraiNo", SqlDbType.NVarChar).Value = iraiNoTo;
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}