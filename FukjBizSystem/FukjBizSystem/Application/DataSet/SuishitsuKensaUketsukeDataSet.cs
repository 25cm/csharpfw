using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{
    public partial class SuishitsuKensaUketsukeDataSet
    {
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeDataSetTableAdapters
{
    #region KensaDaicho9joInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaDaicho9joInfoTableAdapter
    /// <summary>
    /// 計量証明用検索
    /// データ検索①
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/03　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaDaicho9joInfoTableAdapter
    {
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

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiNendo">依頼年度(西暦)</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="kensaIraiUketsukeDt">受付日(YYYYMMDD)</param>
        /// <param name="kentaiFromNo">検体番号（開始）(6桁ゼロパディング)</param>
        /// <param name="kentaiToNo">検体番号（終了）(6桁ゼロパディング)</param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/12/03　小松       新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeDataSet.KensaDaicho9joInfoDataTable GetDataBySearchCond(
            string iraiNendo,
            string shishoCd,
            string kensaIraiUketsukeDt,
            string kentaiFromNo,
            string kentaiToNo)
        {
            SqlCommand command = createSqlCommand(iraiNendo, shishoCd, kensaIraiUketsukeDt, kentaiFromNo, kentaiToNo);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeDataSet.KensaDaicho9joInfoDataTable dataTable = new SuishitsuKensaUketsukeDataSet.KensaDaicho9joInfoDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region createSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： createSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiNendo">依頼年度(西暦)</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="kensaIraiUketsukeDt">受付日(YYYYMMDD)</param>
        /// <param name="kentaiFromNo">検体番号（開始）(6桁ゼロパディング)</param>
        /// <param name="kentaiToNo">検体番号（終了）(6桁ゼロパディング)</param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/12/03　小松       新規作成
        /// 2015/01/11　小松       検査セット名も取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand createSqlCommand(
            string iraiNendo,
            string shishoCd,
            string kensaIraiUketsukeDt,
            string kentaiFromNo,
            string kentaiToNo)
        {
            SqlCommand command = new SqlCommand();

            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.Append("select ");
            sqlContent.Append("  kdt.IraiNendo ");
            sqlContent.Append("  , kdt.ShishoCd ");
            sqlContent.Append("  , kdt.SuishitsuKensaIraiNo ");
            sqlContent.Append("  , kdt.KeiryoShomeiIraiNendo ");
            sqlContent.Append("  , kdt.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append("  , kdt.KeiryoShomeiIraiRenban ");
            sqlContent.Append("  , concat(  ");
            sqlContent.Append("    dbo.FuncConvertIraiNedoToWareki(kdt.KeiryoShomeiIraiNendo) ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , kdt.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , kdt.KeiryoShomeiIraiRenban ");
            sqlContent.Append("  ) as KeiryoShomeiIraiNo ");
            sqlContent.Append("  , ksi.KeiryoShomeiUketsukeKbn ");
            sqlContent.Append("  , ksi.KeiryoShomeiGenkinShunyuFlg ");
            sqlContent.Append("  , jdm.JokasoHokenjoCd ");
            sqlContent.Append("  , jdm.JokasoTorokuNendo ");
            sqlContent.Append("  , jdm.JokasoRenban ");
            sqlContent.Append("  , concat(  ");
            sqlContent.Append("    jdm.JokasoHokenjoCd ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , dbo.FuncConvertIraiNedoToWareki(jdm.JokasoTorokuNendo) ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , jdm.JokasoRenban ");
            sqlContent.Append("  ) as KyokaiNo ");
            sqlContent.Append("  , jdm.JokasoSetchishaNm  ");
            sqlContent.Append("  , ksi.UpdateDt as KeiryoShomeiIraiUpdateDt  ");
            sqlContent.Append("  , ksi.KeiryoShomeiSaisuiinCd  ");
            sqlContent.Append("  , isnull(ssm.SaisuiinNm, '')  as SaisuiinNm ");
            sqlContent.Append("  , ksi.KeiryoShomeiSaisuiDt  ");
            sqlContent.Append("  , ksi.KeiryoShomeiSaisuiTime  ");
            sqlContent.Append("  , ksi.KeiryoShomeiSuion  ");
            sqlContent.Append("  , ksi.KeiryoShomeiKion  ");
            sqlContent.Append("  , ksi.KeiryoShomeiSetCd  ");
            sqlContent.Append("  , ksi.KeiryoShomeiKensaRyokin  ");
            sqlContent.Append("  , ksi.KeiryoShomeiShohizei  ");
            sqlContent.Append("  , ksi.KeiryoShomeiKensakomokuEdaban  ");
            sqlContent.Append("  , isnull(skkm.DaichoKensaSetNm, '') as DaichoKensaSetNm ");
            sqlContent.Append("from ");
            sqlContent.Append("  (  ");
            sqlContent.Append("    select ");
            sqlContent.Append("      hdr.*  ");
            sqlContent.Append("    from ");
            sqlContent.Append("      (  ");
            sqlContent.Append("        select ");
            sqlContent.Append("          *  ");
            sqlContent.Append("        from ");
            sqlContent.Append("          KensaDaicho9joHdrTbl  ");
            sqlContent.Append("        where ");
            // 依頼年度
            sqlContent.Append(string.Format(" IraiNendo = '{0}' ", iraiNendo));
            // 支所コード
            sqlContent.Append(string.Format(" and ShishoCd = '{0}' ", shishoCd));
            // 受付日(YYYYMMDD)
            sqlContent.Append(string.Format(" and KensaIraiUketsukeDt = '{0}' ", kensaIraiUketsukeDt));
            // 検体番号（開始）(6桁ゼロパディング)
            if (!string.IsNullOrEmpty(kentaiFromNo))
            {
                sqlContent.Append(string.Format(" and SuishitsuKensaIraiNo >= '{0}' ", kentaiFromNo));
            }
            // 検体番号（終了）(6桁ゼロパディング)
            if (!string.IsNullOrEmpty(kentaiToNo))
            {
                sqlContent.Append(string.Format(" and SuishitsuKensaIraiNo <= '{0}' ", kentaiToNo));
            }
            sqlContent.Append("      ) hdr  ");
            sqlContent.Append("    where ");
            sqlContent.Append("      not exists (  ");
            sqlContent.Append("        select ");
            sqlContent.Append("          1  ");
            sqlContent.Append("        from ");
            sqlContent.Append("          KensaDaichoDtlTbl dtl  ");
            sqlContent.Append("        where ");
            sqlContent.Append("          dtl.KensaKbn = '1'  ");
            sqlContent.Append("          and dtl.IraiNendo = hdr.IraiNendo  ");
            sqlContent.Append("          and dtl.ShishoCd = hdr.ShishoCd  ");
            sqlContent.Append("          and dtl.SuishitsuKensaIraiNo = hdr.SuishitsuKensaIraiNo  ");
            sqlContent.Append("          and dtl.KeiryoShomeiKekkaNyuryoku = '1' ");
            sqlContent.Append("      ) ");
            sqlContent.Append("  ) kdt  ");
            sqlContent.Append("  inner join KeiryoShomeiIraiTbl ksi  ");
            sqlContent.Append("    on kdt.KeiryoShomeiIraiNendo = ksi.KeiryoShomeiIraiNendo  ");
            sqlContent.Append("    and kdt.KeiryoShomeiIraiSishoCd = ksi.KeiryoShomeiIraiSishoCd  ");
            sqlContent.Append("    and kdt.KeiryoShomeiIraiRenban = ksi.KeiryoShomeiIraiRenban  ");
            sqlContent.Append("  inner join JokasoDaichoMst jdm  ");
            sqlContent.Append("    on ksi.KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd  ");
            sqlContent.Append("    and ksi.KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo  ");
            sqlContent.Append("    and ksi.KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban ");
            sqlContent.Append("  left outer join SaisuiinMst ssm  ");
            sqlContent.Append("    on ssm.SaisuiinCd = ksi.KeiryoShomeiSaisuiinCd  ");
            sqlContent.Append("  left outer join DaichoSuishitsuKensaKomokuMst skkm ");
            sqlContent.Append("    on ksi.KeiryoShomeiJokasoDaichoHokenjoCd = skkm.JokasoHokenjoCd ");
            sqlContent.Append("    and ksi.KeiryoShomeiJokasoDaichoNendo = skkm.JokasoTorokuNendo ");
            sqlContent.Append("    and ksi.KeiryoShomeiJokasoDaichoRenban = skkm.JokasoRenban ");
            sqlContent.Append("    and ksi.KeiryoShomeiKensakomokuEdaban = skkm.DaichoKensaKomokuEdaban ");
            sqlContent.Append("order by ");
            sqlContent.Append("  kdt.IraiNendo ");
            sqlContent.Append("  , kdt.ShishoCd ");
            sqlContent.Append("  , kdt.SuishitsuKensaIraiNo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaDaichoSuishitsuInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaDaichoGaikanInfoTableAdapter
    /// <summary>
    /// 水質検査用検索
    /// データ検索②
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/05　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaDaichoSuishitsuInfoTableAdapter
    {
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

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiNendo">依頼年度(西暦)</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="kensaIraiUketsukeDt">受付日(YYYYMMDD)</param>
        /// <param name="kentaiFromNo">検体番号（開始）(6桁ゼロパディング)</param>
        /// <param name="kentaiToNo">検体番号（終了）(6桁ゼロパディング)</param>
        /// <param name="zanryuEnsoCd">残留塩素の試験項目コード(3桁ゼロパディング)</param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/12/05　小松       新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoDataTable GetDataBySearchCond(
            string iraiNendo,
            string shishoCd,
            string kensaIraiUketsukeDt,
            string kentaiFromNo,
            string kentaiToNo,
            string zanryuEnsoCd)
        {
            SqlCommand command = createSqlCommand(iraiNendo, shishoCd, kensaIraiUketsukeDt, kentaiFromNo, kentaiToNo, zanryuEnsoCd);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoDataTable dataTable = new SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region createSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： createSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiNendo">依頼年度(西暦)</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="kensaIraiUketsukeDt">受付日(YYYYMMDD)</param>
        /// <param name="kentaiFromNo">検体番号（開始）(6桁ゼロパディング)</param>
        /// <param name="kentaiToNo">検体番号（終了）(6桁ゼロパディング)</param>
        /// <param name="zanryuEnsoCd">残留塩素の試験項目コード(3桁ゼロパディング)</param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/12/05　小松       新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand createSqlCommand(
            string iraiNendo,
            string shishoCd,
            string kensaIraiUketsukeDt,
            string kentaiFromNo,
            string kentaiToNo,
            string zanryuEnsoCd)
        {
            SqlCommand command = new SqlCommand();

            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.Append("select ");
            sqlContent.Append("  kdt.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("  , kdt.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("  , kdt.KensaKekkaIraiNendo ");
            sqlContent.Append("  , kdt.KensaKekkaIraiRenban ");
            sqlContent.Append("  , concat(  ");
            sqlContent.Append("    kdt.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , kdt.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , dbo.FuncConvertIraiNedoToWareki(kdt.KensaKekkaIraiNendo) ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , kdt.KensaKekkaIraiRenban ");
            sqlContent.Append("  ) as KensaIraiNo ");
            sqlContent.Append("  , '1' as SaisaisuiKbn ");
            sqlContent.Append("  , kdt.SuishitsuKensaIraiNo ");
            sqlContent.Append("  , kit.KensaIraiUketsukeKbn ");
            sqlContent.Append("  , kit.KensaIraiGenkinShunyuKbn ");
            sqlContent.Append("  , isnull(kit.KensaIraiSaisuiinCd, '') as KensaIraiSaisuiinCd ");
            sqlContent.Append("  , isnull(ssm.SaisuiinNm, '') as SaisuiinNm ");
            sqlContent.Append("  , jdm.JokasoHokenjoCd ");
            sqlContent.Append("  , jdm.JokasoTorokuNendo ");
            sqlContent.Append("  , jdm.JokasoRenban ");
            sqlContent.Append("  , concat(  ");
            sqlContent.Append("    jdm.JokasoHokenjoCd ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , dbo.FuncConvertIraiNedoToWareki(jdm.JokasoTorokuNendo) ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , jdm.JokasoRenban ");
            sqlContent.Append("  ) as KyokaiNo ");
            sqlContent.Append("  , jdm.JokasoSetchishaNm ");
            sqlContent.Append("  , kdd.KeiryoShomeiKekkaValue ");
            sqlContent.Append("  , isnull(kit.KensaIraiKensaTantoshaCd, '') as KensaIraiKensaTantoshaCd ");
            sqlContent.Append("  , isnull(skm.ShokuinNm, '') as ShokuinNm  ");
            sqlContent.Append("  , kit.UpdateDt as KensaIraiUpdateDt  ");
            sqlContent.Append("  , kdd.UpdateDt as KensaDaichoDtlUpdateDt  ");
            sqlContent.Append("  , kit.KensaIraiKensaAmt  ");
            sqlContent.Append("  , kit.KensaIraiNyukinzumiAmt  ");
            sqlContent.Append("  , kit.KensaIraiHakkoKbn4  ");
            sqlContent.Append("  , kit.KensaIraiHakkoKbn5  ");
            sqlContent.Append("from ");
            sqlContent.Append("  (  ");
            sqlContent.Append("    select ");
            sqlContent.Append("      hdr.*  ");
            sqlContent.Append("    from ");
            sqlContent.Append("      (  ");
            sqlContent.Append("        select ");
            sqlContent.Append("          *  ");
            sqlContent.Append("        from ");
            sqlContent.Append("          KensaDaicho11joHdrTbl  ");
            sqlContent.Append("        where ");
            sqlContent.Append("          KensaKbn = '2'  ");
            // 依頼年度
            sqlContent.Append(string.Format(" and IraiNendo = '{0}' ", iraiNendo));
            // 支所コード
            sqlContent.Append(string.Format(" and ShishoCd = '{0}' ", shishoCd));
            // 受付日(YYYYMMDD)
            sqlContent.Append(string.Format(" and KensaIraiUketsukeDt = '{0}' ", kensaIraiUketsukeDt));
            // 検体番号（開始）(6桁ゼロパディング)
            if (!string.IsNullOrEmpty(kentaiFromNo))
            {
                sqlContent.Append(string.Format(" and SuishitsuKensaIraiNo >= '{0}' ", kentaiFromNo));
            }
            // 検体番号（終了）(6桁ゼロパディング)
            if (!string.IsNullOrEmpty(kentaiToNo))
            {
                sqlContent.Append(string.Format(" and SuishitsuKensaIraiNo <= '{0}' ", kentaiToNo));
            }
            sqlContent.Append("      ) hdr  ");
            sqlContent.Append("    where ");
            sqlContent.Append("      not exists (  ");
            sqlContent.Append("        select ");
            sqlContent.Append("          1  ");
            sqlContent.Append("        from ");
            sqlContent.Append("          KensaDaichoDtlTbl dtl  ");
            sqlContent.Append("        where ");
            sqlContent.Append("          dtl.KensaKbn = hdr.KensaKbn  ");
            sqlContent.Append("          and dtl.IraiNendo = hdr.IraiNendo  ");
            sqlContent.Append("          and dtl.ShishoCd = hdr.ShishoCd  ");
            sqlContent.Append("          and dtl.SuishitsuKensaIraiNo = hdr.SuishitsuKensaIraiNo  ");
            sqlContent.Append("          and dtl.KeiryoShomeiKekkaNyuryoku = '1' ");
            sqlContent.Append("      ) ");
            sqlContent.Append("  ) kdt  ");
            sqlContent.Append("  inner join KensaDaichoDtlTbl kdd  ");
            sqlContent.Append("    on kdt.KensaKbn = kdd.KensaKbn  ");
            sqlContent.Append("    and kdt.IraiNendo = kdd.IraiNendo  ");
            sqlContent.Append("    and kdt.ShishoCd = kdd.ShishoCd  ");
            sqlContent.Append("    and kdt.SuishitsuKensaIraiNo = kdd.SuishitsuKensaIraiNo  ");
            sqlContent.Append("  inner join KensaIraiTbl kit  ");
            sqlContent.Append("    on kdt.KensaKekkaIraiHoteiKbn = kit.KensaIraiHoteiKbn  ");
            sqlContent.Append("    and kdt.KensaKekkaIraiHokenjoCd = kit.KensaIraiHokenjoCd  ");
            sqlContent.Append("    and kdt.KensaKekkaIraiNendo = kit.KensaIraiNendo  ");
            sqlContent.Append("    and kdt.KensaKekkaIraiRenban = kit.KensaIraiRenban  ");
            sqlContent.Append("  inner join JokasoDaichoMst jdm  ");
            sqlContent.Append("    on kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd  ");
            sqlContent.Append("    and kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo  ");
            sqlContent.Append("    and kit.KensaIraiJokasoRenban = jdm.JokasoRenban  ");
            sqlContent.Append("  left outer join SaisuiinMst ssm  ");
            sqlContent.Append("    on kit.KensaIraiSaisuiinCd = ssm.SaisuiinCd  ");
            sqlContent.Append("  left outer join ShokuinMst skm  ");
            sqlContent.Append("    on kit.KensaIraiKensaTantoshaCd = skm.ShokuinCd  ");
            sqlContent.Append("where ");
            // 残留塩素の試験項目コード
            sqlContent.Append(string.Format(" kdd.ShikenkoumokuCd = '{0}' ", zanryuEnsoCd));
            sqlContent.Append("order by ");
            sqlContent.Append("  kdt.KensaKbn ");
            sqlContent.Append("  , kdt.IraiNendo ");
            sqlContent.Append("  , kdt.ShishoCd ");
            sqlContent.Append("  , kdt.SuishitsuKensaIraiNo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaDaichoGaikanInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaDaichoGaikanInfoTableAdapter
    /// <summary>
    /// 外観検査用検索
    /// データ検索③
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/04　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaDaichoGaikanInfoTableAdapter
    {
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

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiNendo">依頼年度(西暦)</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="kensaIraiUketsukeDt">受付日(YYYYMMDD)</param>
        /// <param name="kentaiFromNo">検体番号（開始）(6桁ゼロパディング)</param>
        /// <param name="kentaiToNo">検体番号（終了）(6桁ゼロパディング)</param>
        /// <param name="toshidoCd">透視度の試験項目コード(3桁ゼロパディング)</param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/12/04　小松       新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuKensaUketsukeDataSet.KensaDaichoGaikanInfoDataTable GetDataBySearchCond(
            string iraiNendo,
            string shishoCd,
            string kensaIraiUketsukeDt,
            string kentaiFromNo,
            string kentaiToNo,
            string toshidoCd)
        {
            SqlCommand command = createSqlCommand(iraiNendo, shishoCd, kensaIraiUketsukeDt, kentaiFromNo, kentaiToNo, toshidoCd);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuKensaUketsukeDataSet.KensaDaichoGaikanInfoDataTable dataTable = new SuishitsuKensaUketsukeDataSet.KensaDaichoGaikanInfoDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region createSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： createSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiNendo">依頼年度(西暦)</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="kensaIraiUketsukeDt">受付日(YYYYMMDD)</param>
        /// <param name="kentaiFromNo">検体番号（開始）(6桁ゼロパディング)</param>
        /// <param name="kentaiToNo">検体番号（終了）(6桁ゼロパディング)</param>
        /// <param name="toshidoCd">透視度の試験項目コード(3桁ゼロパディング)</param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/12/04　小松       新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand createSqlCommand(
            string iraiNendo,
            string shishoCd,
            string kensaIraiUketsukeDt,
            string kentaiFromNo,
            string kentaiToNo,
            string toshidoCd)
        {
            SqlCommand command = new SqlCommand();

            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.Append("select ");
            sqlContent.Append("  kdt.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("  , kdt.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("  , kdt.KensaKekkaIraiNendo ");
            sqlContent.Append("  , kdt.KensaKekkaIraiRenban ");
            sqlContent.Append("  , concat(  ");
            sqlContent.Append("    kdt.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , kdt.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , dbo.FuncConvertIraiNedoToWareki(kdt.KensaKekkaIraiNendo) ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , kdt.KensaKekkaIraiRenban ");
            sqlContent.Append("  ) as KensaIraiNo ");
            sqlContent.Append("  , '0' as SaisaisuiKbn ");
            sqlContent.Append("  , kdt.SuishitsuKensaIraiNo ");
            sqlContent.Append("  , kit.KensaIraiUketsukeKbn ");
            sqlContent.Append("  , kit.KensaIraiGenkinShunyuKbn ");
            sqlContent.Append("  , isnull(kit.KensaIraiSaisuiinCd, '') as KensaIraiSaisuiinCd ");
            sqlContent.Append("  , isnull(ssm.SaisuiinNm, '') as SaisuiinNm ");
            sqlContent.Append("  , jdm.JokasoHokenjoCd ");
            sqlContent.Append("  , jdm.JokasoTorokuNendo ");
            sqlContent.Append("  , jdm.JokasoRenban ");
            sqlContent.Append("  , concat(  ");
            sqlContent.Append("    jdm.JokasoHokenjoCd ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , dbo.FuncConvertIraiNedoToWareki(jdm.JokasoTorokuNendo) ");
            sqlContent.Append("    , '-' ");
            sqlContent.Append("    , jdm.JokasoRenban ");
            sqlContent.Append("  ) as KyokaiNo ");
            sqlContent.Append("  , jdm.JokasoSetchishaNm ");
            sqlContent.Append("  , kdd.KeiryoShomeiKekkaValue ");
            sqlContent.Append("  , isnull(kit.KensaIraiKensaTantoshaCd, '') as KensaIraiKensaTantoshaCd ");
            sqlContent.Append("  , isnull(skm.ShokuinNm, '') as ShokuinNm  ");
            sqlContent.Append("  , kdd.UpdateDt as KensaDaichoDtlUpdateDt  ");
            sqlContent.Append("  , kit.KensaIraiScreeningKbn  ");
            sqlContent.Append("from ");
            sqlContent.Append("  (  ");
            sqlContent.Append("    select ");
            sqlContent.Append("      hdr.*  ");
            sqlContent.Append("    from ");
            sqlContent.Append("      (  ");
            sqlContent.Append("        select ");
            sqlContent.Append("          *  ");
            sqlContent.Append("        from ");
            sqlContent.Append("          KensaDaicho11joHdrTbl  ");
            sqlContent.Append("        where ");
            sqlContent.Append("          KensaKbn = '3'  ");
            // 依頼年度
            sqlContent.Append(string.Format(" and IraiNendo = '{0}' ", iraiNendo));
            // 支所コード
            sqlContent.Append(string.Format(" and ShishoCd = '{0}' ", shishoCd));
            // 受付日(YYYYMMDD)
            sqlContent.Append(string.Format(" and KensaIraiUketsukeDt = '{0}' ", kensaIraiUketsukeDt));
            // 検体番号（開始）(6桁ゼロパディング)
            if (!string.IsNullOrEmpty(kentaiFromNo))
            {
                sqlContent.Append(string.Format(" and SuishitsuKensaIraiNo >= '{0}' ", kentaiFromNo));
            }
            // 検体番号（終了）(6桁ゼロパディング)
            if (!string.IsNullOrEmpty(kentaiToNo))
            {
                sqlContent.Append(string.Format(" and SuishitsuKensaIraiNo <= '{0}' ", kentaiToNo));
            }
            sqlContent.Append("      ) hdr  ");
            sqlContent.Append("    where ");
            sqlContent.Append("      not exists (  ");
            sqlContent.Append("        select ");
            sqlContent.Append("          1  ");
            sqlContent.Append("        from ");
            sqlContent.Append("          KensaDaichoDtlTbl dtl  ");
            sqlContent.Append("        where ");
            sqlContent.Append("          dtl.KensaKbn = hdr.KensaKbn  ");
            sqlContent.Append("          and dtl.IraiNendo = hdr.IraiNendo  ");
            sqlContent.Append("          and dtl.ShishoCd = hdr.ShishoCd  ");
            sqlContent.Append("          and dtl.SuishitsuKensaIraiNo = hdr.SuishitsuKensaIraiNo  ");
            sqlContent.Append("          and dtl.KeiryoShomeiKekkaNyuryoku = '1' ");
            sqlContent.Append("      ) ");
            sqlContent.Append("  ) kdt  ");
            sqlContent.Append("  inner join KensaDaichoDtlTbl kdd  ");
            sqlContent.Append("    on kdt.KensaKbn = kdd.KensaKbn  ");
            sqlContent.Append("    and kdt.IraiNendo = kdd.IraiNendo  ");
            sqlContent.Append("    and kdt.ShishoCd = kdd.ShishoCd  ");
            sqlContent.Append("    and kdt.SuishitsuKensaIraiNo = kdd.SuishitsuKensaIraiNo  ");
            sqlContent.Append("  inner join KensaIraiTbl kit  ");
            sqlContent.Append("    on kdt.KensaKekkaIraiHoteiKbn = kit.KensaIraiHoteiKbn  ");
            sqlContent.Append("    and kdt.KensaKekkaIraiHokenjoCd = kit.KensaIraiHokenjoCd  ");
            sqlContent.Append("    and kdt.KensaKekkaIraiNendo = kit.KensaIraiNendo  ");
            sqlContent.Append("    and kdt.KensaKekkaIraiRenban = kit.KensaIraiRenban  ");
            sqlContent.Append("  inner join JokasoDaichoMst jdm  ");
            sqlContent.Append("    on kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd  ");
            sqlContent.Append("    and kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo  ");
            sqlContent.Append("    and kit.KensaIraiJokasoRenban = jdm.JokasoRenban  ");
            sqlContent.Append("  left outer join SaisuiinMst ssm  ");
            sqlContent.Append("    on kit.KensaIraiSaisuiinCd = ssm.SaisuiinCd  ");
            sqlContent.Append("  left outer join ShokuinMst skm  ");
            sqlContent.Append("    on kit.KensaIraiKensaTantoshaCd = skm.ShokuinCd  ");
            sqlContent.Append("where ");
            // 残留塩素の試験項目コード
            sqlContent.Append(string.Format(" kdd.ShikenkoumokuCd = '{0}' ", toshidoCd));
            sqlContent.Append("order by ");
            sqlContent.Append("  kdt.KensaKbn ");
            sqlContent.Append("  , kdt.IraiNendo ");
            sqlContent.Append("  , kdt.ShishoCd ");
            sqlContent.Append("  , kdt.SuishitsuKensaIraiNo ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region SuishitsuKensaJisshiKomokuInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaJisshiKomokuInfoTableAdapter
    /// <summary>
    /// 処理方式別水質検査実施マスタから情報取得
    /// データ検索⑫
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/04　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaJisshiKomokuInfoTableAdapter
    {
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

    #region SuishitsuKensaEntryInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaEntryInfoTableAdapter
    /// <summary>
    /// 水質検査情報登録用の浄化槽台帳、検査料金情報を取得
    /// データ検索⑦
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/04　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaEntryInfoTableAdapter
    {
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

    #region ZenkaiKensaIraiInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ZenkaiKensaIraiInfoTableAdapter
    /// <summary>
    /// 前回検査情報を取得
    /// データ検索⑨
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/04　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ZenkaiKensaIraiInfoTableAdapter
    {
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

    #region KensaShokenFollowInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaShokenFollowInfoTableAdapter
    /// <summary>
    /// 所見結果テーブルからフォロー対象の所見情報を取得
    /// データ検索⑪
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/04　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaShokenFollowInfoTableAdapter
    {
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

    #region KeiryoShomeiHakkoFlgInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiryoShomeiHakkoFlgInfoTableAdapter
    /// <summary>
    /// 計量証明依頼登録用の計量証明書発行対象フラグ取得
    /// データ検索⑭
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/08　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KeiryoShomeiHakkoFlgInfoTableAdapter
    {
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

    #region SuishitsuNippoCheckInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuNippoCheckInfoTableAdapter
    /// <summary>
    /// 日報の確認状況取得
    /// データ検索⑬
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/09　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuNippoCheckInfoTableAdapter
    {
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

    #region DisplayJokasoDaichoInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DisplayJokasoDaichoInfoTableAdapter
    /// <summary>
    /// 詳細画面の登録時用の浄化槽台帳情報を取得（依頼取込時のみ）
    /// データ検索⑬
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/12/10　小松       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class DisplayJokasoDaichoInfoTableAdapter
    {
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

}
