using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{

    public partial class KensaDaicho11joHdrTblDataSet
    {
    }

    #region 法定検査 検査台帳の検索条件
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoteiKensaDaichoSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28　宗     　　 新規作成
    /// 2015/01/29  宗          外観検査の試験項目追加
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class HoteiKensaDaichoSearchCond
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 試験項目コード(pH)
        /// </summary>
        public string KmkCdPh { get; set; }
        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        public string KmkCdTr { get; set; }
        /// <summary>
        /// 試験項目コード(BOD)
        /// </summary>
        public string KmkCdBod { get; set; }
        /// <summary>
        /// 試験項目コード(残塩)
        /// </summary>
        public string KmkCdZanen { get; set; }
        /// <summary>
        /// 試験項目コード(塩化物イオン)
        /// </summary>
        public string KmkCdCl { get; set; }
        /// <summary>
        /// 試験項目コード(ATUBOD)
        /// </summary>
        public string KmkCdAtubod { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }
        /// <summary>
        /// 依頼受付日入力区分
        /// </summary>
        public string IraiUketsukeDtInputKbn { get; set; }
        /// <summary>
        /// 依頼受付日(開始)
        /// </summary>
        public string IraiUketsukeFromDt { get; set; }
        /// <summary>
        /// 依頼受付日(終了)
        /// </summary>
        public string IraiUketsukeToDt { get; set; }
        /// <summary>
        /// 検査区分：11条水質
        /// </summary>
        public string KensaKbnSuisitsu { get; set; }
        /// <summary>
        /// 検査区分：外観検査
        /// </summary>
        public string KensaKbnGaikan { get; set; }
        /// <summary>
        /// 依頼No(開始)
        /// </summary>
        public string IraiNoFrom { get; set; }
        /// <summary>
        /// 依頼No(終了)
        /// </summary>
        public string IraiNoTo { get; set; }
    }
    #endregion

    #region KensaKekkaInputSearch1SearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputSearch1SearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KensaKekkaInputSearch1SearchCond
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 試験項目コード
        /// </summary>
        public string ShikenkoumokuCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string SuishitsuKensaIraiNoFrom { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string SuishitsuKensaIraiNoTo { get; set; }
    }
    #endregion

    #region YachoOutputSearchCond

    /// <summary>
    /// 外観/水質/計量証明
    /// </summary>
    public enum TypeSearch
    {
        GaikanKensa,        // 外観
        SuishitsuKensa,     // 水質
        KeiryoKensa         // 計量証明
    }

    #region YachoOutputSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YachoOutputSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04　AnhNV     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class YachoOutputSearchCond
    {
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号（開始）
        /// </summary>
        public string IraiNoFrom { get; set; }
        /// <summary>
        /// 水質検査依頼番号（終了）
        /// </summary>
        public string IraiNoTo { get; set; }
        /// <summary>
        /// 外観/水質/計量証明
        /// </summary>
        public TypeSearch TypeSearch { get; set; }
    }
    #endregion

    #endregion
}

namespace FukjBizSystem.Application.DataSet.KensaDaicho11joHdrTblDataSetTableAdapters
{
    
    #region KensaKekkaInputSearch1TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputSearch1TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaKekkaInputSearch1TableAdapter
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
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable GetDataBySearchCond(KensaKekkaInputSearch1SearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable dataTable = new KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable();
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
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaKekkaInputSearch1SearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                                   ");
            sqlContent.Append("     ROW_NUMBER() OVER (ORDER BY kd11h.SuishitsuKensaIraiNo ASC) AS RowNumber ,                                          ");
            sqlContent.Append(" { fn CONCAT({ fn CONCAT({ fn CONCAT({ fn CONCAT(kd11h.KensaKekkaIraiHokenjoCd, '-') },                                  ");
            sqlContent.Append(" dbo.FuncConvertIraiNedoToWareki(kd11h.KensaKekkaIraiNendo)) }, '-') }, kd11h.KensaKekkaIraiRenban) } AS KensaIraiNo,    ");
            sqlContent.Append("     kd11h.KensaKekkaIraiHoteiKbn, kd11h.SuishitsuKensaIraiNo,                                                           ");
            sqlContent.Append("     kd11h.KensaKekkaIraiHokenjoCd, kd11h.KensaKekkaIraiNendo, kd11h.KensaKekkaIraiRenban,                               ");
            sqlContent.Append("     kdd.ShikenkoumokuCd, kdd.SaikensaKbn, kdd.KeiryoShomeiKekkaCd, kdd.SaikensaKbn AS SaikensaKbnDisp,                  ");
            sqlContent.Append("     kdd.KeiryoShomeiKekkaValue, kdd.KeiryoShomeiKekkaValue2,                                                            ");
            sqlContent.Append("     kdd.KeiryoShomeiKekkaOndo, kdd.KeiryoShomeiGaibuItakuFlg,                                                           ");
            sqlContent.Append("     kdd.UpdateDt, sskm.GaichuItakuKbn,                                                                                  ");
            sqlContent.Append("     ISNULL(KeisaIraiHoteiKbnView.ConstNm, '') AS ConstNm                                                                ");

            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     KensaDaicho11joHdrTbl AS kd11h                                                                      ");
            sqlContent.Append("INNER JOIN                                                                                               ");
            sqlContent.Append("     KensaDaichoDtlTbl AS kdd                                                                            ");
            sqlContent.Append("         ON kd11h.KensaKbn = kdd.KensaKbn                                                                ");
            sqlContent.Append("         AND kd11h.IraiNendo = kdd.IraiNendo                                                             ");
            sqlContent.Append("         AND kd11h.ShishoCd = kdd.ShishoCd                                                               ");
            sqlContent.Append("         AND kd11h.SuishitsuKensaIraiNo = kdd.SuishitsuKensaIraiNo                                       ");
            sqlContent.Append("INNER JOIN                                                                                               ");
            sqlContent.Append("     SuishitsuShikenKoumokuMst AS sskm                                                                   ");
            sqlContent.Append("         ON kdd.ShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd                                          ");
            sqlContent.Append("LEFT JOIN                                                                                                ");
            sqlContent.Append("     (   SELECT ConstNm, ConstValue                                                                      ");
            sqlContent.Append("         FROM ConstMst                                                                                   ");
            sqlContent.Append("         WHERE    ConstMst.ConstKbn = '" + Utility.Constants.ConstKbnConstanst.CONST_KBN_006 + "'         ");
            sqlContent.Append("     ) AS KeisaIraiHoteiKbnView                                                                          ");
            sqlContent.Append("         ON KeisaIraiHoteiKbnView.ConstValue = kd11h.KensaKekkaIraiHoteiKbn                              ");
            sqlContent.Append("INNER JOIN                                                                                               ");
            sqlContent.Append("     ( SELECT KensaKbn, IraiNendo, ShishoCd, SuishitsuKensaIraiNo, ShikenkoumokuCd,                      ");
            sqlContent.Append("         MAX(SaikensaKbn) AS MaxSaikensaKbn                                                              ");
            sqlContent.Append("         FROM KensaDaichoDtlTbl                                                                          ");
            sqlContent.Append("         GROUP BY KensaKbn, IraiNendo, ShishoCd, SuishitsuKensaIraiNo, ShikenkoumokuCd                   ");
            sqlContent.Append("     )  AS TargetMeisaiView                                                                              ");
            sqlContent.Append("         ON TargetMeisaiView.KensaKbn = kdd.KensaKbn                                                     ");
			sqlContent.Append("         AND TargetMeisaiView.IraiNendo = kdd.IraiNendo                                                  ");
			sqlContent.Append("         AND TargetMeisaiView.ShishoCd = kdd.ShishoCd                                                    ");
            sqlContent.Append("         AND TargetMeisaiView.SuishitsuKensaIraiNo = kdd.SuishitsuKensaIraiNo                            ");
			sqlContent.Append("         AND TargetMeisaiView.ShikenkoumokuCd = kdd.ShikenkoumokuCd                                      ");
			sqlContent.Append("         AND TargetMeisaiView.MaxSaikensaKbn = kdd.SaikensaKbn                                           ");
            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 検査区分
            sqlContent.Append("AND kd11h.KensaKbn = @KensaKbn                                                                           ");
            commandParams.Add("@KensaKbn", SqlDbType.NVarChar).Value = searchCond.KensaKbn;
            // 依頼年度
            sqlContent.Append("AND kd11h.IraiNendo = @IraiNendo                                                                         ");
            commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = searchCond.IraiNendo;
            // 支所コード
            sqlContent.Append("AND kd11h.ShishoCd = @ShishoCd                                                                           ");
            commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = searchCond.ShishoCd;
            // 依頼年度
            sqlContent.Append("AND kdd.ShikenkoumokuCd = @ShikenkoumokuCd                                                               ");
            commandParams.Add("@ShikenkoumokuCd", SqlDbType.NVarChar).Value = searchCond.ShikenkoumokuCd;

            // 水質検査依頼番号
            if (!string.IsNullOrEmpty(searchCond.SuishitsuKensaIraiNoFrom))
            {
                sqlContent.Append("AND kd11h.SuishitsuKensaIraiNo >= @SuishitsuKensaIraiNoFrom                                          ");
                commandParams.Add("@SuishitsuKensaIraiNoFrom", SqlDbType.NVarChar).Value = searchCond.SuishitsuKensaIraiNoFrom;
            }

            if (!string.IsNullOrEmpty(searchCond.SuishitsuKensaIraiNoTo))
            {
                sqlContent.Append("AND kd11h.SuishitsuKensaIraiNo <= @SuishitsuKensaIraiNoTo                                          ");
                commandParams.Add("@SuishitsuKensaIraiNoTo", SqlDbType.NVarChar).Value = searchCond.SuishitsuKensaIraiNoTo;
            }

            sqlContent.Append("AND  ((                                                                                                  ");
            sqlContent.Append("kd11h.SaisaisuiKbn = '0'                                                                             ");
            sqlContent.Append("AND kd11h.KachoKeninKbn = '0'                                                                            ");
            sqlContent.Append("AND kd11h.HukuKachoKeninKbn = '0'                                                                        ");
            sqlContent.Append("     )    OR                                                                                             ");


            sqlContent.Append("(   kd11h.SaisaisuiKbn = '1'                                                                              ");
            sqlContent.Append("AND kd11h.KachoKeninKbnScreening = '0'                                                                    ");
            sqlContent.Append("AND kd11h.HukuKachoKeninKbnScreening = '0'                                                                ");
            sqlContent.Append("     ))                                                                                                   ");

            // ORDER BY

            sqlContent.Append("         ORDER BY kd11h.SuishitsuKensaIraiNo ASC                                                         ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KakuninKensaJisshiKiroku1TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninKensaJisshiKiroku1TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/27　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KakuninKensaJisshiKiroku1TableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Shisho"></param>
        /// <param name="Nendo"></param>
        /// <param name="IraiUketsukeDtFrom"></param>
        /// <param name="IraiUketsukeDtTo"></param>
        /// <param name="RadioChoosed"></param>
        /// <param name="SuishitsuIraiNoFrom"></param>
        /// <param name="SuishitsuIraiNoTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/27　DatNT　　 新規作成
        /// 2015/01/16  宗          引数変更(UketsukeDtFrom,UketsukeDtTo → Nendo)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho11joHdrTblDataSet.KakuninKensaJisshiKiroku1DataTable GetDataBySearchCond(
            string ShishoCd,
            string Nendo,
            string IraiUketsukeDtFrom,
            string IraiUketsukeDtTo,
            string RadioChoosed,
            string SuishitsuIraiNoFrom,
            // 20150121 sou Start
            //string SuishitsuIraiNoTo)
            string SuishitsuIraiNoTo,
            string kmkCdBodA,
            string kmkCdBodB,
            string kmkCdTr,
            string kmkCdGaikan,
            string kmkCdShuki,
            string kmkCdNo2n,
            string kmkCdNo3n,
            string kmkCdCl)
            // 20150121 sou End
        {
            SqlCommand command = CreateSqlCommand(ShishoCd,
                                                    Nendo,
                                                    IraiUketsukeDtFrom,
                                                    IraiUketsukeDtTo,
                                                    RadioChoosed,
                                                    SuishitsuIraiNoFrom,
                                                    // 20150121 sou Start
                                                    //SuishitsuIraiNoTo);
                                                    SuishitsuIraiNoTo,
                                                    kmkCdBodA,
                                                    kmkCdBodB,
                                                    kmkCdTr,
                                                    kmkCdGaikan,
                                                    kmkCdShuki,
                                                    kmkCdNo2n,
                                                    kmkCdNo3n,
                                                    kmkCdCl);
                                                    // 20150121 sou End

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho11joHdrTblDataSet.KakuninKensaJisshiKiroku1DataTable dataTable = new KensaDaicho11joHdrTblDataSet.KakuninKensaJisshiKiroku1DataTable();
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
        /// <param name="Nendo"></param>
        /// <param name="IraiUketsukeDtFrom"></param>
        /// <param name="IraiUketsukeDtTo"></param>
        /// <param name="RadioChoosed"></param>
        /// <param name="SuishitsuIraiNoFrom"></param>
        /// <param name="SuishitsuIraiNoTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/27　DatNT　　新規作成
        /// 2014/12/12　HuyTX　　Ver1.02
        /// 2015/01/16  宗          引数変更(UketsukeDtFrom,UketsukeDtTo → Nendo)
        /// 2015/01/16  宗          検索条件変更(UketsukeDtFrom,UketsukeDtTo → Nendo)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string ShishoCd,
            string Nendo,
            string IraiUketsukeDtFrom,
            string IraiUketsukeDtTo,
            string RadioChoosed,
            string SuishitsuIraiNoFrom,
            // 20150121 sou Start
            //string SuishitsuIraiNoTo)
            string SuishitsuIraiNoTo,
            string kmkCdBodA,
            string kmkCdBodB,
            string kmkCdTr,
            string kmkCdGaikan,
            string kmkCdShuki,
            string kmkCdNo2n,
            string kmkCdNo3n,
            string kmkCdCl)
            // 20150121 sou End
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // 20150109 sou Start
            #region UNION SELECT
            // SELECT
            sqlContent.Append("SELECT ");
            sqlContent.Append("  kensaIraiHoteiKbnCol ");
            sqlContent.Append("  , kensaIraiHokenjoCdCol ");
            sqlContent.Append("  , kensaIraiNendoCol ");
            sqlContent.Append("  , kensaIraiRenbanCol ");
            sqlContent.Append("  , keiryoShomeiIraiNendoCol ");
            sqlContent.Append("  , keiryoShomeiIraiSishoCdCol ");
            sqlContent.Append("  , keiryoShomeiIraiRenbanCol ");
            sqlContent.Append("  , jokasoHokenjoCdCol ");
            sqlContent.Append("  , jokasoTorokuNendoCol ");
            sqlContent.Append("  , jokasoRenbanCol ");
            sqlContent.Append("  , saisaisuiKbnCol ");
            sqlContent.Append("  , kensaKbnCol ");
            sqlContent.Append("  , kensaKbnNmCol ");
            sqlContent.Append("  , iraiNendoCol ");
            sqlContent.Append("  , shishoCdCol ");
            sqlContent.Append("  , iraiNoCol ");
            sqlContent.Append("  , kakoJohoCol ");
            sqlContent.Append("  , komokuCdCol ");
            sqlContent.Append("  , komokuNmCol ");
            sqlContent.Append("  , pH1Col ");
            sqlContent.Append("  , ondo1Col ");
            sqlContent.Append("  , ph1KekkaCdCol ");
            sqlContent.Append("  , ph1KekkaNmCol ");
            sqlContent.Append("  , pH2Col ");
            sqlContent.Append("  , ondo2Col ");
            sqlContent.Append("  , ph2KekkaCdCol ");
            sqlContent.Append("  , ph2KekkaNmCol ");
            sqlContent.Append("  , saiyotipH2Col ");
            sqlContent.Append("  , kakuninKekkaSotiCol ");
            sqlContent.Append("  , kakuninKekkaSotiNmCol ");
            sqlContent.Append("  , kachoKeninCol ");
            sqlContent.Append("  , hukuKachoKeninCol ");
            sqlContent.Append("  , keiryokanrisyaKeninCol ");
            sqlContent.Append("  , yachoKakuninCol ");
            sqlContent.Append("  , koshinKbnCol ");
            sqlContent.Append("  , koshinKeninKbnCol ");
            sqlContent.Append("  , kachoKeninCheckBoxCol ");
            sqlContent.Append("  , hukukachoKeninCheckBoxCol ");
            sqlContent.Append("  , keiryoKanriKeninCheckBoxCol ");
            sqlContent.Append("  , KakuninKeiryoShomeiSaiyoKbn ");
            sqlContent.Append("  , KensaIraiSuishitsuUketsukeDt ");
            sqlContent.Append("  , KensaIraiSuishitsuIraiNo ");
            sqlContent.Append("  , SaikensaKbnKakuninKensa ");
            sqlContent.Append("  , SaikensaKbn  ");
            #endregion

            sqlContent.Append("FROM ");
            sqlContent.Append("( ");
            // 20150109 sou End

            #region SELECT
            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn AS kensaIraiHoteiKbnCol,                               ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd AS kensaIraiHokenjoCdCol,                             ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiNendo AS kensaIraiNendoCol,                                     ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiRenban AS kensaIraiRenbanCol,                                   ");
            sqlContent.Append("     '' AS keiryoShomeiIraiNendoCol,                                                                     ");
            sqlContent.Append("     '' AS keiryoShomeiIraiSishoCdCol,                                                                   ");
            sqlContent.Append("     '' AS keiryoShomeiIraiRenbanCol,                                                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoHokenjoCd AS jokasoHokenjoCdCol,                                        ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoTorokuNendo AS jokasoTorokuNendoCol,                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoRenban AS jokasoRenbanCol,                                              ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.SaisaisuiKbn AS saisaisuiKbnCol,                                              ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKbn AS kensaKbnCol,                                                      ");
            sqlContent.Append("     CASE KensaDaicho11joHdrTbl.KensaKbn                                                                 ");
            sqlContent.Append("         WHEN '2' THEN '11条水質'                                                                        ");
            //MOD_20141212_HuyTX Ver1.02 Start
            //sqlContent.Append("         WHEN '3' THEN '11条外観' END AS kensaKbnNmCol,                                                  ");
            sqlContent.Append("         WHEN '3' THEN '外観検査' END AS kensaKbnNmCol,                                                  ");
            //MOD_20141212_HuyTX Ver1.02 End
            sqlContent.Append("     KensaDaicho11joHdrTbl.IraiNendo AS iraiNendoCol,                                                    ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.ShishoCd AS shishoCdCol,                                                      ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo AS iraiNoCol,                                            ");
            sqlContent.Append("     '情報' AS kakoJohoCol,                                                                              ");
            sqlContent.Append("     KensaDaichoDtlTbl.ShikenkoumokuCd AS komokuCdCol,                                                   ");
            sqlContent.Append("     SuishitsuShikenKoumokuMst.SeishikiNm AS komokuNmCol,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue AS pH1Col,                                                 ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaOndo AS ondo1Col,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue2 AS ph1KekkaCdCol,                                         ");
            sqlContent.Append("     ConstMst.ConstNm AS ph1KekkaNmCol,                                                                  ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaValue AS pH2Col,                                               ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaOndo AS ondo2Col,                                              ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaValue2 AS ph2KekkaCdCol,                                       ");
            // 20150116 sou Start
            sqlContent.Append("     ConstMst2.ConstNm AS ph2KekkaNmCol,                                                                 ");
            // 20150116 sou End
            sqlContent.Append("     CASE KakuninKensa.KakuninKeiryoShomeiSaiyoKbn                                                       ");
            sqlContent.Append("         WHEN '1' THEN '1'                                                                               ");
            sqlContent.Append("         ELSE '0' END AS saiyotipH2Col,                                                                  ");
            sqlContent.Append("     KensaDaichoDtlTbl.KakuninKensaSoti AS kakuninKekkaSotiCol,                                          ");
            // 20150116 sou Start
            sqlContent.Append("     SOTI.ConstNm AS kakuninKekkaSotiNmCol,                                                              ");
            // 20150116 sou End
            sqlContent.Append("     KensaDaichoDtlTbl.KachoKeninKbn AS kachoKeninCol,                                                   ");
            sqlContent.Append("     KensaDaichoDtlTbl.HukuKachoKeninKbn AS hukuKachoKeninCol,                                           ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoKanrishaKeninKbn AS keiryokanrisyaKeninCol,                                 ");
            sqlContent.Append("     KensaDaichoDtlTbl.YachoKinyuKakuninKbn AS yachoKakuninCol,                                          ");
            sqlContent.Append("     '0' AS koshinKbnCol,                                                                                ");
            sqlContent.Append("     '0' AS koshinKeninKbnCol,                                                                           ");
            sqlContent.Append("     '0' AS kachoKeninCheckBoxCol,                                                                       ");
            sqlContent.Append("     '0' AS hukukachoKeninCheckBoxCol,                                                                   ");
            sqlContent.Append("     '0' AS keiryoKanriKeninCheckBoxCol,                                                                 ");

            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiSaiyoKbn,                                                           ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSuishitsuUketsukeDt,                                                          ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSuishitsuIraiNo,                                                              ");
            sqlContent.Append("     KakuninKensa.SaikensaKbn AS SaikensaKbnKakuninKensa,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.SaikensaKbn                                                                       ");

            // 20150109 sou Start
            sqlContent.Append("  , KensaDaichoDtlTbl.KensaKbn as orderKensaKbn ");
            sqlContent.Append("  , KensaDaichoDtlTbl.IraiNendo as orderIraiNendo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShishoCd as orderShishoCd ");
            sqlContent.Append("  , KensaDaichoDtlTbl.SuishitsuKensaIraiNo as orderHuishitsuKensaIraiNo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShikenkoumokuCd as orderShikenkoumokuCd ");
            // 20150109 sou End

            //20141217 HuyTX Mod Start
            // FROM
            //sqlContent.Append("FROM                                                                                                     ");
            //sqlContent.Append("     KensaDaicho11joHdrTbl                                                                               ");
            //sqlContent.Append("INNER JOIN                                                                                               ");
            //sqlContent.Append("     KensaIraiTbl                                                                                        ");
            //sqlContent.Append("         ON KensaIraiTbl.KensaIraiHoteiKbn = KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn                ");
            //sqlContent.Append("         AND KensaIraiTbl.KensaIraiHokenjoCd = KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd             ");
            //sqlContent.Append("         AND KensaIraiTbl.KensaIraiNendo = KensaDaicho11joHdrTbl.KensaKekkaIraiNendo                     ");
            //sqlContent.Append("         AND KensaIraiTbl.KensaIraiRenban = KensaDaicho11joHdrTbl.KensaKekkaIraiRenban                   ");
            //sqlContent.Append("INNER JOIN                                                                                               ");
            //sqlContent.Append("     KensaDaichoDtlTbl                                                                                   ");
            //sqlContent.Append("         ON KensaDaichoDtlTbl.KensaKbn = KensaDaicho11joHdrTbl.KensaKbn                                  ");
            //sqlContent.Append("         AND KensaDaichoDtlTbl.IraiNendo = KensaDaicho11joHdrTbl.IraiNendo                               ");
            //sqlContent.Append("         AND KensaDaichoDtlTbl.ShishoCd = KensaDaicho11joHdrTbl.ShishoCd                                 ");
            //sqlContent.Append("         AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo = KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo         ");
            //sqlContent.Append("INNER JOIN                                                                                               ");
            //sqlContent.Append("     (   SELECT    KensaKbn,                                                                               ");
            //sqlContent.Append("                 IraiNendo,                                                                              ");
            //sqlContent.Append("                 ShishoCd,                                                                               ");
            //sqlContent.Append("                 SuishitsuKensaIraiNo,                                                                   ");
            //sqlContent.Append("                 ShikenkoumokuCd,                                                                        ");
            //sqlContent.Append("                 SaikensaKbn,                                                                            ");
            //sqlContent.Append("                 KeiryoShomeiKekkaValue AS KakuninKeiryoShomeiKekkaValue,                                ");
            //sqlContent.Append("                 KeiryoShomeiKekkaOndo AS KakuninKeiryoShomeiKekkaOndo,                                  ");
            //sqlContent.Append("                 KeiryoShomeiKekkaValue2 AS KakuninKeiryoShomeiKekkaValue2,                              ");
            //sqlContent.Append("                 KeiryoShomeiSaiyoKbn AS KakuninKeiryoShomeiSaiyoKbn                                     ");
            //sqlContent.Append("         FROM    KensaDaichoDtlTbl                                                                        ");
            //sqlContent.Append("     ) KakuninKensa                                                                                      ");
            //sqlContent.Append("         ON KakuninKensa.KensaKbn = KensaDaichoDtlTbl.KensaKbn                                           ");
            //sqlContent.Append("         AND KakuninKensa.IraiNendo = KensaDaichoDtlTbl.IraiNendo                                        ");
            //sqlContent.Append("         AND KakuninKensa.ShishoCd = KensaDaichoDtlTbl.ShishoCd                                          ");
            //sqlContent.Append("         AND KakuninKensa.SuishitsuKensaIraiNo = KensaDaichoDtlTbl.SuishitsuKensaIraiNo                  ");
            //sqlContent.Append("LEFT OUTER JOIN SuishitsuShikenKoumokuMst                                                                ");
            //sqlContent.Append("     ON SuishitsuShikenKoumokuMst.SuishitsuShikenKoumokuCd = KensaDaichoDtlTbl.ShikenkoumokuCd           ");
            //sqlContent.Append("LEFT OUTER JOIN ConstMst                                                                                 ");
            //sqlContent.Append("     ON ConstMst.ConstKbn = '027'                                                                        ");
            //sqlContent.Append("     AND ConstMst.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaValue2                               ");
            #endregion

            #region FROM
            sqlContent.Append(" FROM KensaDaichoDtlTbl ");

            // 20141222 sou Start
            //sqlContent.Append(" INNER JOIN ");
            sqlContent.Append(" LEFT JOIN ");
            // 20141222 sou End
            sqlContent.Append("   (SELECT KensaKbn, ");
            sqlContent.Append("           IraiNendo, ");
            sqlContent.Append("           ShishoCd, ");
            sqlContent.Append("           SuishitsuKensaIraiNo, ");
            sqlContent.Append("           ShikenkoumokuCd, ");
            sqlContent.Append("           SaikensaKbn, ");
            sqlContent.Append("           KeiryoShomeiKekkaValue AS KakuninKeiryoShomeiKekkaValue, ");
            sqlContent.Append("           KeiryoShomeiKekkaOndo AS KakuninKeiryoShomeiKekkaOndo, ");
            sqlContent.Append("           KeiryoShomeiKekkaValue2 AS KakuninKeiryoShomeiKekkaValue2, ");
            sqlContent.Append("           KeiryoShomeiSaiyoKbn AS KakuninKeiryoShomeiSaiyoKbn ");
            sqlContent.Append("    FROM KensaDaichoDtlTbl) KakuninKensa  ");
            sqlContent.Append("    ON KakuninKensa.KensaKbn = KensaDaichoDtlTbl.KensaKbn ");
            sqlContent.Append(" AND KakuninKensa.IraiNendo = KensaDaichoDtlTbl.IraiNendo ");
            sqlContent.Append(" AND KakuninKensa.ShishoCd = KensaDaichoDtlTbl.ShishoCd ");
            sqlContent.Append(" AND KakuninKensa.SuishitsuKensaIraiNo = KensaDaichoDtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append(" AND KakuninKensa.ShikenkoumokuCd = KensaDaichoDtlTbl.ShikenkoumokuCd ");
            // 20141224 sou Strat
            sqlContent.Append(" AND KakuninKensa.SaikensaKbn = '1' ");
            // 20141224 sou End

            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho11joHdrTbl ON KensaDaichoDtlTbl.KensaKbn = KensaDaicho11joHdrTbl.KensaKbn ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.IraiNendo = KensaDaicho11joHdrTbl.IraiNendo ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.ShishoCd = KensaDaicho11joHdrTbl.ShishoCd ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo = KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo ");

            sqlContent.Append(" LEFT OUTER JOIN KensaIraiTbl ON KensaIraiTbl.KensaIraiHoteiKbn = KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd = KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo = KensaDaicho11joHdrTbl.KensaKekkaIraiNendo ");
            sqlContent.Append(" AND KensaIraiTbl.KensaIraiRenban = KensaDaicho11joHdrTbl.KensaKekkaIraiRenban ");

            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst ON SuishitsuShikenKoumokuMst.SuishitsuShikenKoumokuCd = KensaDaichoDtlTbl.ShikenkoumokuCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst ON ConstMst.ConstKbn = '027' ");
            // 20141219 sou Ver1.04 Start
            //sqlContent.Append(" AND ConstMst.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaValue2 ");
            sqlContent.Append(" AND ConstMst.ConstValue = KensaDaichoDtlTbl.KeiryoShomeiKekkaValue2 ");
            // 20141219 sou Ver1.04 End
            // 20150116 sou Start
            sqlContent.Append(" LEFT OUTER JOIN ConstMst AS ConstMst2 ON ConstMst2.ConstKbn = '027' ");
            sqlContent.Append(" AND ConstMst2.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaValue2 ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ON SOTI.ConstValue = KensaDaichoDtlTbl.KakuninKensaSoti AND SOTI.ConstKbn = '061' ");
            // 20150116 sou End

            //20141217 HuyTX Mod End
            #endregion

            #region WHERE
            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 検査区分
            sqlContent.Append("AND KensaDaichoDtlTbl.KensaKbn IN ('2', '3')                                                             ");

            // 支所コード
            sqlContent.Append("AND KensaDaichoDtlTbl.ShishoCd = @shishoCd                                                               ");
            commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = ShishoCd;

            // 再検査回数
            sqlContent.Append("AND KensaDaichoDtlTbl.SaikensaKbn = '0'                                                                  ");
            // 20141224 sou Strat
            //sqlContent.Append("AND KakuninKensa.SaikensaKbn = '1'                                                                      ");
            // 20141224 sou End

            sqlContent.Append("AND (                                                                                                    ");
            sqlContent.Append("         (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '0'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn = '50'                                                  ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiScreeningKbn = '0' )                                              ");
            sqlContent.Append("      OR (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '0'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn < '60'                                                  ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiScreeningKbn IN ('1', '3') )                                      ");
            // 20141219 sou Start
            //sqlContent.Append("      OR (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '1'                                                    ");
            //sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn = '50'                                                  ");
            //sqlContent.Append("             AND KensaIraiTbl.KensaIraiScreeningKbn IN ('1', '3') )                                      ");
            sqlContent.Append("      OR (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '1'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn = '50' )                                                ");
            // 20141219 sou End
            sqlContent.Append("      OR (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '0'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn < '65'                                                  ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiScreeningKbn = '2' )                                              ");
            sqlContent.Append(" )                                                                                                       ");

            // 20150121 sou Start
            //// 20141219 sou Start
            //// 確認検査種別
            //sqlContent.Append("AND (                                                                                                    ");
            //sqlContent.Append("       (KensaDaichoDtlTbl.KensaShubetsuBodTr = '2')                                                   ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuKako = '2')                                                    ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuBodOver = '2')                                                 ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuEnkaIon = '2')                                                 ");
            //sqlContent.Append(" )                                                                                                       ");
            //// 20141219 sou End
            // 確認検査種別()
            sqlContent.Append("AND ( ");
            sqlContent.Append("       ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@bodA, @bodB, @tr)) AND (KensaDaichoDtlTbl.KensaShubetsuBodTr = '2')) ");
            sqlContent.Append("    OR ((NOT KensaDaichoDtlTbl.ShikenkoumokuCd in(@gaikan, @shuki, @no2n, @no3n)) AND (KensaDaichoDtlTbl.KensaShubetsuKako = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@bodA, @bodB)) AND (KensaDaichoDtlTbl.KensaShubetsuBodOver = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@cl)) AND (KensaDaichoDtlTbl.KensaShubetsuEnkaIon = '2')) ");
            sqlContent.Append(" ) ");
            commandParams.Add("@bodA", SqlDbType.NVarChar).Value = kmkCdBodA;
            commandParams.Add("@bodB", SqlDbType.NVarChar).Value = kmkCdBodB;
            commandParams.Add("@tr", SqlDbType.NVarChar).Value = kmkCdTr;
            commandParams.Add("@gaikan", SqlDbType.NVarChar).Value = kmkCdGaikan;
            commandParams.Add("@shuki", SqlDbType.NVarChar).Value = kmkCdShuki;
            commandParams.Add("@no2n", SqlDbType.NVarChar).Value = kmkCdNo2n;
            commandParams.Add("@no3n", SqlDbType.NVarChar).Value = kmkCdNo3n;
            commandParams.Add("@cl", SqlDbType.NVarChar).Value = kmkCdCl;
            // 20150121 sou End

            // ・｛年度｝が空以外の場合
            // 20150116 sou Start
            //if (!string.IsNullOrEmpty(UketsukeDtFrom))
            //{
            //    sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @UketsukeDtFrom ");
            //    commandParams.Add("@UketsukeDtFrom", SqlDbType.NVarChar).Value = UketsukeDtFrom;
            //}
            //
            //if (!string.IsNullOrEmpty(UketsukeDtTo))
            //{
            //    sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @UketsukeDtTo ");
            //    commandParams.Add("@UketsukeDtTo", SqlDbType.NVarChar).Value = UketsukeDtTo;
            //}

            if (!string.IsNullOrEmpty(Nendo))
            {
                sqlContent.Append("AND KensaDaicho11joHdrTbl.IraiNendo = @Nendo ");
                commandParams.Add("@Nendo", SqlDbType.NVarChar).Value = Nendo;
            }
            // 20150116 sou End

            // ・｛依頼受付日（開始）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtFrom))
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @IraiUketsukeDtFrom ");
                commandParams.Add("@IraiUketsukeDtFrom", SqlDbType.NVarChar).Value = IraiUketsukeDtFrom;
            }

            // ・｛依頼受付日（終了）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtTo))
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @IraiUketsukeDtTo ");
                commandParams.Add("@IraiUketsukeDtTo", SqlDbType.NVarChar).Value = IraiUketsukeDtTo;
            }

            // ・｛11条水質｝が選択されている場合
            if (RadioChoosed == "2")
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = '3' ");
            }

            // ・｛外観検査｝が選択されている場合
            if (RadioChoosed == "3")
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn IN ('1', '2') ");
            }

            // ・｛依頼No（開始）｝が空以外の場合
            if (!string.IsNullOrEmpty(SuishitsuIraiNoFrom))
            {
                // 20141219 sou Ver1.04 Start
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuIraiNo >= @SuishitsuIraiNoFrom ");
                sqlContent.Append("AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo >= @SuishitsuIraiNoFrom ");
                // 20141219 sou Ver1.04 End
                commandParams.Add("@SuishitsuIraiNoFrom", SqlDbType.NVarChar).Value = SuishitsuIraiNoFrom;
            }

            // ・｛依頼No（終了）｝が空以外の場合
            if (!string.IsNullOrEmpty(SuishitsuIraiNoTo))
            {
                // 20141219 sou Ver1.04 Start
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuIraiNo <= @SuishitsuIraiNoTo ");
                sqlContent.Append("AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo <= @SuishitsuIraiNoTo ");
                // 20141219 sou Ver1.04 End
                commandParams.Add("@SuishitsuIraiNoTo", SqlDbType.NVarChar).Value = SuishitsuIraiNoTo;
            }
            #endregion

            // 20150109 sou Start
            #region ORDER BY
            //// ORDER BY
            //sqlContent.Append("ORDER BY                                                                                                 ");
            //sqlContent.Append("     KensaDaichoDtlTbl.KensaKbn,                                                                         ");
            //sqlContent.Append("     KensaDaichoDtlTbl.IraiNendo,                                                                        ");
            //sqlContent.Append("     KensaDaichoDtlTbl.ShishoCd,                                                                         ");
            //sqlContent.Append("     KensaDaichoDtlTbl.SuishitsuKensaIraiNo,                                                             ");
            //sqlContent.Append("     KensaDaichoDtlTbl.ShikenkoumokuCd                                                                   ");
            #endregion

            sqlContent.Append("UNION ");

            #region SELECT
            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn AS kensaIraiHoteiKbnCol,                               ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd AS kensaIraiHokenjoCdCol,                             ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiNendo AS kensaIraiNendoCol,                                     ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKekkaIraiRenban AS kensaIraiRenbanCol,                                   ");
            sqlContent.Append("     '' AS keiryoShomeiIraiNendoCol,                                                                     ");
            sqlContent.Append("     '' AS keiryoShomeiIraiSishoCdCol,                                                                   ");
            sqlContent.Append("     '' AS keiryoShomeiIraiRenbanCol,                                                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoHokenjoCd AS jokasoHokenjoCdCol,                                        ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoTorokuNendo AS jokasoTorokuNendoCol,                                    ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiJokasoRenban AS jokasoRenbanCol,                                              ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.SaisaisuiKbn AS saisaisuiKbnCol,                                              ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.KensaKbn AS kensaKbnCol,                                                      ");
            sqlContent.Append("     CASE KensaDaicho11joHdrTbl.KensaKbn                                                                 ");
            sqlContent.Append("         WHEN '2' THEN '11条水質'                                                                        ");
            sqlContent.Append("         WHEN '3' THEN '外観検査' END AS kensaKbnNmCol,                                                  ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.IraiNendo AS iraiNendoCol,                                                    ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.ShishoCd AS shishoCdCol,                                                      ");
            sqlContent.Append("     KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo AS iraiNoCol,                                            ");
            sqlContent.Append("     '情報' AS kakoJohoCol,                                                                              ");
            sqlContent.Append("     KensaDaichoDtlTbl.ShikenkoumokuCd AS komokuCdCol,                                                   ");
            sqlContent.Append("     SuishitsuShikenKoumokuMst.SeishikiNm AS komokuNmCol,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue AS pH1Col,                                                 ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaOndo AS ondo1Col,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue2 AS ph1KekkaCdCol,                                         ");
            sqlContent.Append("     ConstMst.ConstNm AS ph1KekkaNmCol,                                                                  ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaValue AS pH2Col,                                               ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaOndo AS ondo2Col,                                              ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaValue2 AS ph2KekkaCdCol,                                       ");
            // 20150116 sou Start
            sqlContent.Append("     ConstMst2.ConstNm AS ph2KekkaNmCol,                                                                 ");
            // 20150116 sou End
            sqlContent.Append("     CASE KakuninKensa.KakuninKeiryoShomeiSaiyoKbn                                                       ");
            sqlContent.Append("         WHEN '1' THEN '1'                                                                               ");
            sqlContent.Append("         ELSE '0' END AS saiyotipH2Col,                                                                  ");
            sqlContent.Append("     KensaDaichoDtlTbl.KakuninKensaSoti AS kakuninKekkaSotiCol,                                          ");
            // 20150116 sou Start
            sqlContent.Append("     SOTI.ConstNm AS kakuninKekkaSotiNmCol,                                                              ");
            // 20150116 sou End
            sqlContent.Append("     KensaDaichoDtlTbl.KachoKeninKbn AS kachoKeninCol,                                                   ");
            sqlContent.Append("     KensaDaichoDtlTbl.HukuKachoKeninKbn AS hukuKachoKeninCol,                                           ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoKanrishaKeninKbn AS keiryokanrisyaKeninCol,                                 ");
            sqlContent.Append("     KensaDaichoDtlTbl.YachoKinyuKakuninKbn AS yachoKakuninCol,                                          ");
            sqlContent.Append("     '0' AS koshinKbnCol,                                                                                ");
            sqlContent.Append("     '0' AS koshinKeninKbnCol,                                                                           ");
            sqlContent.Append("     '0' AS kachoKeninCheckBoxCol,                                                                       ");
            sqlContent.Append("     '0' AS hukukachoKeninCheckBoxCol,                                                                   ");
            sqlContent.Append("     '0' AS keiryoKanriKeninCheckBoxCol,                                                                 ");

            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiSaiyoKbn,                                                           ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSuishitsuUketsukeDt,                                                          ");
            sqlContent.Append("     KensaIraiTbl.KensaIraiSuishitsuIraiNo,                                                              ");
            sqlContent.Append("     KakuninKensa.SaikensaKbn AS SaikensaKbnKakuninKensa,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.SaikensaKbn                                                                       ");

            sqlContent.Append("  , KensaDaichoDtlTbl.KensaKbn as orderKensaKbn ");
            sqlContent.Append("  , KensaDaichoDtlTbl.IraiNendo as orderIraiNendo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShishoCd as orderShishoCd ");
            sqlContent.Append("  , KensaDaichoDtlTbl.SuishitsuKensaIraiNo as orderHuishitsuKensaIraiNo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShikenkoumokuCd as orderShikenkoumokuCd ");
            #endregion

            #region FROM
            sqlContent.Append(" FROM KensaDaichoDtlTbl ");

            sqlContent.Append(" INNER JOIN ");
            sqlContent.Append("   (SELECT KensaKbn, ");
            sqlContent.Append("           IraiNendo, ");
            sqlContent.Append("           ShishoCd, ");
            sqlContent.Append("           SuishitsuKensaIraiNo, ");
            sqlContent.Append("           ShikenkoumokuCd, ");
            sqlContent.Append("           SaikensaKbn, ");
            sqlContent.Append("           KeiryoShomeiKekkaValue AS KakuninKeiryoShomeiKekkaValue, ");
            sqlContent.Append("           KeiryoShomeiKekkaOndo AS KakuninKeiryoShomeiKekkaOndo, ");
            sqlContent.Append("           KeiryoShomeiKekkaValue2 AS KakuninKeiryoShomeiKekkaValue2, ");
            sqlContent.Append("           KeiryoShomeiSaiyoKbn AS KakuninKeiryoShomeiSaiyoKbn ");
            sqlContent.Append("    FROM KensaDaichoDtlTbl) KakuninKensa  ");
            sqlContent.Append("    ON KakuninKensa.KensaKbn = KensaDaichoDtlTbl.KensaKbn ");
            sqlContent.Append(" AND KakuninKensa.IraiNendo = KensaDaichoDtlTbl.IraiNendo ");
            sqlContent.Append(" AND KakuninKensa.ShishoCd = KensaDaichoDtlTbl.ShishoCd ");
            sqlContent.Append(" AND KakuninKensa.SuishitsuKensaIraiNo = KensaDaichoDtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append(" AND KakuninKensa.ShikenkoumokuCd = KensaDaichoDtlTbl.ShikenkoumokuCd ");
            sqlContent.Append(" AND KakuninKensa.SaikensaKbn = '1' ");

            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho11joHdrTbl ON KensaDaichoDtlTbl.KensaKbn = KensaDaicho11joHdrTbl.KensaKbn ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.IraiNendo = KensaDaicho11joHdrTbl.IraiNendo ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.ShishoCd = KensaDaicho11joHdrTbl.ShishoCd ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo = KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo ");

            sqlContent.Append(" LEFT OUTER JOIN KensaIraiTbl ON KensaIraiTbl.KensaIraiHoteiKbn = KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd = KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo = KensaDaicho11joHdrTbl.KensaKekkaIraiNendo ");
            sqlContent.Append(" AND KensaIraiTbl.KensaIraiRenban = KensaDaicho11joHdrTbl.KensaKekkaIraiRenban ");

            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst ON SuishitsuShikenKoumokuMst.SuishitsuShikenKoumokuCd = KensaDaichoDtlTbl.ShikenkoumokuCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst ON ConstMst.ConstKbn = '027' ");
            sqlContent.Append(" AND ConstMst.ConstValue = KensaDaichoDtlTbl.KeiryoShomeiKekkaValue2 ");
            // 20150116 sou Start
            sqlContent.Append(" LEFT OUTER JOIN ConstMst ConstMst2 ON ConstMst2.ConstKbn = '027' ");
            sqlContent.Append(" AND ConstMst2.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaValue2 ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ON SOTI.ConstValue = KensaDaichoDtlTbl.KakuninKensaSoti AND SOTI.ConstKbn = '061' ");
            // 20150116 sou End
            #endregion

            #region WHERE
            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 検査区分
            sqlContent.Append("AND KensaDaichoDtlTbl.KensaKbn IN ('2', '3')                                                             ");

            // 支所コード
            sqlContent.Append("AND KensaDaichoDtlTbl.ShishoCd = @shishoCd2                                                              ");
            commandParams.Add("@shishoCd2", SqlDbType.NVarChar).Value = ShishoCd;

            // 再検査回数
            sqlContent.Append("AND KensaDaichoDtlTbl.SaikensaKbn = '0'                                                                  ");

            sqlContent.Append("AND (                                                                                                    ");
            sqlContent.Append("         (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '0'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn = '50'                                                  ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiScreeningKbn = '0' )                                              ");
            sqlContent.Append("      OR (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '0'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn < '60'                                                  ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiScreeningKbn IN ('1', '3') )                                      ");
            sqlContent.Append("      OR (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '1'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn = '50' )                                                ");
            sqlContent.Append("      OR (   KensaDaicho11joHdrTbl.SaisaisuiKbn = '0'                                                    ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiStatusKbn < '65'                                                  ");
            sqlContent.Append("             AND KensaIraiTbl.KensaIraiScreeningKbn = '2' )                                              ");
            sqlContent.Append(" )                                                                                                       ");

            // 20150121 sou Start
            //// 確認検査種別
            //sqlContent.Append("AND ((KensaDaichoDtlTbl.KensaShubetsuBodTr != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuKako != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuBodOver != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuEnkaIon != '2')) ");
            // 確認検査種別
            sqlContent.Append("AND NOT( ");
            sqlContent.Append("       ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@bodA, @bodB, @tr)) AND (KensaDaichoDtlTbl.KensaShubetsuBodTr = '2')) ");
            sqlContent.Append("    OR ((NOT KensaDaichoDtlTbl.ShikenkoumokuCd in(@gaikan, @shuki, @no2n, @no3n)) AND (KensaDaichoDtlTbl.KensaShubetsuKako = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@bodA, @bodB)) AND (KensaDaichoDtlTbl.KensaShubetsuBodOver = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@cl)) AND (KensaDaichoDtlTbl.KensaShubetsuEnkaIon = '2')) ");
            sqlContent.Append(" ) ");
            // 20150121 sou End

            // ・｛年度｝が空以外の場合
            // 20150116 sou Start
            //if (!string.IsNullOrEmpty(UketsukeDtFrom))
            //{
            //    sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @UketsukeDtFrom2 ");
            //    commandParams.Add("@UketsukeDtFrom2", SqlDbType.NVarChar).Value = UketsukeDtFrom;
            //}
            //
            //if (!string.IsNullOrEmpty(UketsukeDtTo))
            //{
            //    sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @UketsukeDtTo2 ");
            //    commandParams.Add("@UketsukeDtTo2", SqlDbType.NVarChar).Value = UketsukeDtTo;
            //}

            if (!string.IsNullOrEmpty(Nendo))
            {
                sqlContent.Append("AND KensaDaicho11joHdrTbl.IraiNendo = @Nendo2 ");
                commandParams.Add("@Nendo2", SqlDbType.NVarChar).Value = Nendo;
            }
            // 20150116 sou Start

            // ・｛依頼受付日（開始）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtFrom))
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt >= @IraiUketsukeDtFrom2 ");
                commandParams.Add("@IraiUketsukeDtFrom2", SqlDbType.NVarChar).Value = IraiUketsukeDtFrom;
            }

            // ・｛依頼受付日（終了）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtTo))
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiSuishitsuUketsukeDt <= @IraiUketsukeDtTo2 ");
                commandParams.Add("@IraiUketsukeDtTo2", SqlDbType.NVarChar).Value = IraiUketsukeDtTo;
            }

            // ・｛11条水質｝が選択されている場合
            if (RadioChoosed == "2")
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = '3' ");
            }

            // ・｛外観検査｝が選択されている場合
            if (RadioChoosed == "3")
            {
                sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn IN ('1', '2') ");
            }

            // ・｛依頼No（開始）｝が空以外の場合
            if (!string.IsNullOrEmpty(SuishitsuIraiNoFrom))
            {
                sqlContent.Append("AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo >= @SuishitsuIraiNoFrom2 ");
                commandParams.Add("@SuishitsuIraiNoFrom2", SqlDbType.NVarChar).Value = SuishitsuIraiNoFrom;
            }

            // ・｛依頼No（終了）｝が空以外の場合
            if (!string.IsNullOrEmpty(SuishitsuIraiNoTo))
            {
                sqlContent.Append("AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo <= @SuishitsuIraiNoTo2 ");
                commandParams.Add("@SuishitsuIraiNoTo2", SqlDbType.NVarChar).Value = SuishitsuIraiNoTo;
            }
            #endregion

            sqlContent.Append(") as tbl ");

            #region UNION ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("   orderKensaKbn ");
            sqlContent.Append("  , orderIraiNendo ");
            sqlContent.Append("  , orderShishoCd ");
            sqlContent.Append("  , orderHuishitsuKensaIraiNo ");
            sqlContent.Append("  , orderShikenkoumokuCd ");
            #endregion
            // 20150109 sou End

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region HoteiKensaDaichoSearchTableAdapter
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
    /// 2014/11/28　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class HoteiKensaDaichoSearchTableAdapter
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
        /// 2014/11/28　宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable GetDataBySearchCond(HoteiKensaDaichoSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable dataTable = new KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable();
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
        /// 2014/11/28　宗          新規作成
        /// 2015/01/21　宗          結果コードを結果値２に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(HoteiKensaDaichoSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region SELECT

            sqlContent.Append("SELECT ");

            sqlContent.Append("KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.KensaKekkaIraiNendo ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.KensaKekkaIraiRenban ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiJokasoHokenjoCd ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiJokasoTorokuNendo ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiJokasoRenban ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiSaisuiinCd ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiHoryusakiCd ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.KensaKbn ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.IraiNendo ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.ShishoCd ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.SaisaisuiKbn ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.ScreeningKoho ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.FollowKoho ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.CrossCheckSuishitsu ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.CrossCheckKako ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.HanteiCd ");
            sqlContent.Append(", ConstMst.ConstNm ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiShorihoshikiKbn ");
            sqlContent.Append(", KensaIraiTbl.ShoriHoshikiShubetsuNm ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiShorimokuhyoSuishitsu ");
            sqlContent.Append(", KensaIraiTbl.KensaIraiScreeningKbn ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.KachoKeninKbn ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.HukuKachoKeninKbn ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.KachoKeninKbnScreening ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.HukuKachoKeninKbnScreening ");
            sqlContent.Append(", PH1.KeiryoShomeiKekkaValue as PH1KekkaValue ");
            sqlContent.Append(", PH1.KeiryoShomeiKekkaOndo as PH1KekkaOndo ");
            //sqlContent.Append(", PH1.KeiryoShomeiKekkaCd as PH1KekkaCd ");
            sqlContent.Append(", PH1.KeiryoShomeiKekkaValue2 as PH1KekkaCd ");
            sqlContent.Append(", PH1.KensaShubetsu as PH1KensaShubetsu ");
            sqlContent.Append(", PH1.KeiryoShomeiKekkaNyuryoku as PH1KekkaNyuryoku ");
            sqlContent.Append(", PH1.KeiryoShomeiSaiyoKbn as PH1SaiyoKbn ");
            sqlContent.Append(", PH2.KeiryoShomeiKekkaValue as PH2KekkaValue ");
            sqlContent.Append(", PH2.KeiryoShomeiKekkaOndo as PH2KekkaOndo ");
            //sqlContent.Append(", PH2.KeiryoShomeiKekkaCd as PH2KekkaCd ");
            sqlContent.Append(", PH2.KeiryoShomeiKekkaValue2 as PH2KekkaCd ");
            sqlContent.Append(", PH2.KensaShubetsu as PH2KensaShubetsu ");
            sqlContent.Append(", PH2.KeiryoShomeiKekkaNyuryoku as PH2KekkaNyuryoku ");
            sqlContent.Append(", PH2.KeiryoShomeiSaiyoKbn as PH2SaiyoKbn ");
            sqlContent.Append(", TR1.KeiryoShomeiKekkaValue as TR1KekkaValue ");
            sqlContent.Append(", TR1.KeiryoShomeiKekkaOndo as TR1KekkaOndo ");
            //sqlContent.Append(", TR1.KeiryoShomeiKekkaCd as TR1KekkaCd ");
            sqlContent.Append(", TR1.KeiryoShomeiKekkaValue2 as TR1KekkaCd ");
            sqlContent.Append(", TR1.KensaShubetsu as TR1KensaShubetsu ");
            sqlContent.Append(", TR1.KeiryoShomeiKekkaNyuryoku as TR1KekkaNyuryoku ");
            sqlContent.Append(", TR1.KeiryoShomeiSaiyoKbn as TR1SaiyoKbn ");
            sqlContent.Append(", TR2.KeiryoShomeiKekkaValue as TR2KekkaValue ");
            sqlContent.Append(", TR2.KeiryoShomeiKekkaOndo as TR2KekkaOndo ");
            //sqlContent.Append(", TR2.KeiryoShomeiKekkaCd as TR2KekkaCd ");
            sqlContent.Append(", TR2.KeiryoShomeiKekkaValue2 as TR2KekkaCd ");
            sqlContent.Append(", TR2.KensaShubetsu as TR2KensaShubetsu ");
            sqlContent.Append(", TR2.KeiryoShomeiKekkaNyuryoku as TR2KekkaNyuryoku ");
            sqlContent.Append(", TR2.KeiryoShomeiSaiyoKbn as TR2SaiyoKbn ");
            sqlContent.Append(", BOD1.KeiryoShomeiKekkaValue as BOD1KekkaValue ");
            sqlContent.Append(", BOD1.KeiryoShomeiKekkaOndo as BOD1KekkaOndo ");
            //sqlContent.Append(", BOD1.KeiryoShomeiKekkaCd as BOD1KekkaCd ");
            sqlContent.Append(", BOD1.KeiryoShomeiKekkaValue2 as BOD1KekkaCd ");
            sqlContent.Append(", BOD1.KensaShubetsu as BOD1KensaShubetsu ");
            sqlContent.Append(", BOD1.KeiryoShomeiKekkaNyuryoku as BOD1KekkaNyuryoku ");
            sqlContent.Append(", BOD1.KeiryoShomeiSaiyoKbn as BOD1SaiyoKbn ");
            sqlContent.Append(", BOD2.KeiryoShomeiKekkaValue as BOD2KekkaValue ");
            sqlContent.Append(", BOD2.KeiryoShomeiKekkaOndo as BOD2KekkaOndo ");
            //sqlContent.Append(", BOD2.KeiryoShomeiKekkaCd as BOD2KekkaCd ");
            sqlContent.Append(", BOD2.KeiryoShomeiKekkaValue2 as BOD2KekkaCd ");
            sqlContent.Append(", BOD2.KensaShubetsu as BOD2KensaShubetsu ");
            sqlContent.Append(", BOD2.KeiryoShomeiKekkaNyuryoku as BOD2KekkaNyuryoku ");
            sqlContent.Append(", BOD2.KeiryoShomeiSaiyoKbn as BOD2SaiyoKbn ");
            sqlContent.Append(", ZANEN1.KeiryoShomeiKekkaValue as ZANEN1KekkaValue ");
            sqlContent.Append(", ZANEN1.KeiryoShomeiKekkaOndo as ZANEN1KekkaOndo ");
            //sqlContent.Append(", ZANEN1.KeiryoShomeiKekkaCd as ZANEN1KekkaCd ");
            sqlContent.Append(", ZANEN1.KeiryoShomeiKekkaValue2 as ZANEN1KekkaCd ");
            sqlContent.Append(", ZANEN1.KensaShubetsu as ZANEN1KensaShubetsu ");
            sqlContent.Append(", ZANEN1.KeiryoShomeiKekkaNyuryoku as ZANEN1KekkaNyuryoku ");
            sqlContent.Append(", ZANEN1.KeiryoShomeiSaiyoKbn as ZANEN1SaiyoKbn ");
            sqlContent.Append(", ZANEN2.KeiryoShomeiKekkaValue as ZANEN2KekkaValue ");
            sqlContent.Append(", ZANEN2.KeiryoShomeiKekkaOndo as ZANEN2KekkaOndo ");
            //sqlContent.Append(", ZANEN2.KeiryoShomeiKekkaCd as ZANEN2KekkaCd ");
            sqlContent.Append(", ZANEN2.KeiryoShomeiKekkaValue2 as ZANEN2KekkaCd ");
            sqlContent.Append(", ZANEN2.KensaShubetsu as ZANEN2KensaShubetsu ");
            sqlContent.Append(", ZANEN2.KeiryoShomeiKekkaNyuryoku as ZANEN2KekkaNyuryoku ");
            sqlContent.Append(", ZANEN2.KeiryoShomeiSaiyoKbn as ZANEN2SaiyoKbn ");
            sqlContent.Append(", CL1.KeiryoShomeiKekkaValue as CL1KekkaValue ");
            sqlContent.Append(", CL1.KeiryoShomeiKekkaOndo as CL1KekkaOndo ");
            //sqlContent.Append(", CL1.KeiryoShomeiKekkaCd as CL1KekkaCd ");
            sqlContent.Append(", CL1.KeiryoShomeiKekkaValue2 as CL1KekkaCd ");
            sqlContent.Append(", CL1.KensaShubetsu as CL1KensaShubetsu ");
            sqlContent.Append(", CL1.KeiryoShomeiKekkaNyuryoku as CL1KekkaNyuryoku ");
            sqlContent.Append(", CL1.KeiryoShomeiSaiyoKbn as CL1SaiyoKbn ");
            sqlContent.Append(", CL2.KeiryoShomeiKekkaValue as CL2KekkaValue ");
            sqlContent.Append(", CL2.KeiryoShomeiKekkaOndo as CL2KekkaOndo ");
            //sqlContent.Append(", CL2.KeiryoShomeiKekkaCd as CL2KekkaCd ");
            sqlContent.Append(", CL2.KeiryoShomeiKekkaValue2 as CL2KekkaCd ");
            sqlContent.Append(", CL2.KensaShubetsu as CL2KensaShubetsu ");
            sqlContent.Append(", CL2.KeiryoShomeiKekkaNyuryoku as CL2KekkaNyuryoku ");
            sqlContent.Append(", CL2.KeiryoShomeiSaiyoKbn as CL2SaiyoKbn ");
            // 20150129 sou Start
            sqlContent.Append(", ATUBOD1.KeiryoShomeiKekkaValue as ATUBOD1KekkaValue ");
            sqlContent.Append(", ATUBOD1.KeiryoShomeiKekkaOndo as ATUBOD1KekkaOndo ");
            sqlContent.Append(", ATUBOD1.KeiryoShomeiKekkaValue2 as ATUBOD1KekkaCd ");
            sqlContent.Append(", ATUBOD1.KensaShubetsu as ATUBOD1KensaShubetsu ");
            sqlContent.Append(", ATUBOD1.KeiryoShomeiKekkaNyuryoku as ATUBOD1KekkaNyuryoku ");
            sqlContent.Append(", ATUBOD1.KeiryoShomeiSaiyoKbn as ATUBOD1SaiyoKbn ");
            sqlContent.Append(", ATUBOD2.KeiryoShomeiKekkaValue as ATUBOD2KekkaValue ");
            sqlContent.Append(", ATUBOD2.KeiryoShomeiKekkaOndo as ATUBOD2KekkaOndo ");
            sqlContent.Append(", ATUBOD2.KeiryoShomeiKekkaValue2 as ATUBOD2KekkaCd ");
            sqlContent.Append(", ATUBOD2.KensaShubetsu as ATUBOD2KensaShubetsu ");
            sqlContent.Append(", ATUBOD2.KeiryoShomeiKekkaNyuryoku as ATUBOD2KekkaNyuryoku ");
            sqlContent.Append(", ATUBOD2.KeiryoShomeiSaiyoKbn as ATUBOD2SaiyoKbn ");
            // 20150129 sou End
            sqlContent.Append(", KensaDaicho11joHdrTbl.EnkaIonKako1 ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.EnkaIonKako2 ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.EnkaIonKako3 ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.EnkaIonKako4 ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.EnkaIonKako5 ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.KensaKekkaKakuteiDt ");
            sqlContent.Append(", BOD1.KensaShubetsuBodTr as BOD1KensaShubetsuBodTr ");
            sqlContent.Append(", BOD2.KensaShubetsuBodTr as BOD2KensaShubetsuBodTr ");
            sqlContent.Append(", TR1.KensaShubetsuBodTr as Tr1KensaShubetsuBodTr ");
            sqlContent.Append(", TR2.KensaShubetsuBodTr as Tr2KensaShubetsuBodTr ");
            // 20150129 sou Start
            sqlContent.Append(", ATUBOD1.KensaShubetsuBodTr as ATUBOD1KensaShubetsuBodTr ");
            sqlContent.Append(", ATUBOD2.KensaShubetsuBodTr as ATUBOD2KensaShubetsuBodTr ");
            // 20150129 sou End
            sqlContent.Append(", PH1.KensaShubetsuKako as Ph1KensaShubetsuKako ");
            sqlContent.Append(", PH2.KensaShubetsuKako as Ph2KensaShubetsuKako ");
            sqlContent.Append(", TR1.KensaShubetsuKako as Tr1KensaShubetsuKako ");
            sqlContent.Append(", TR2.KensaShubetsuKako as Tr2KensaShubetsuKako ");
            sqlContent.Append(", BOD1.KensaShubetsuKako as Bod1KensaShubetsuKako ");
            sqlContent.Append(", BOD2.KensaShubetsuKako as Bod2KensaShubetsuKako ");
            // 20150129 sou Start
            sqlContent.Append(", ATUBOD1.KensaShubetsuKako as Atubod1KensaShubetsuKako ");
            sqlContent.Append(", ATUBOD2.KensaShubetsuKako as Atubod2KensaShubetsuKako ");
            // 20150129 sou End
            sqlContent.Append(", ZANEN1.KensaShubetsuKako as Zanen1KensaShubetsuKako ");
            sqlContent.Append(", ZANEN2.KensaShubetsuKako as Zanen2KensaShubetsuKako ");
            sqlContent.Append(", CL1.KensaShubetsuKako as Cl1KensaShubetsuKako ");
            sqlContent.Append(", CL2.KensaShubetsuKako as Cl2KensaShubetsuKako ");
            sqlContent.Append(", BOD1.KensaShubetsuBodOver as BOD1KensaShubetsuBodOver ");
            sqlContent.Append(", BOD2.KensaShubetsuBodOver as BOD2KensaShubetsuBodOver ");
            // 20150129 sou Start
            sqlContent.Append(", ATUBOD1.KensaShubetsuBodOver as ATUBOD1KensaShubetsuBodOver ");
            sqlContent.Append(", ATUBOD2.KensaShubetsuBodOver as ATUBOD2KensaShubetsuBodOver ");
            // 20150129 sou End
            sqlContent.Append(", CL1.KensaShubetsuEnkaIon as Cl1KensaShubetsuEnkaIon ");
            sqlContent.Append(", CL2.KensaShubetsuEnkaIon as Cl2KensaShubetsuEnkaIon ");

            sqlContent.Append(", KensaKekkaTbl.KensaKekkaKensaJoukyouKbn ");
            sqlContent.Append(", KensaIraiTbl.UpdateDt as IraiUpdateDt ");
            sqlContent.Append(", KensaKekkaTbl.UpdateDt as KekkaUpdateDt ");
            sqlContent.Append(", SaiSaisuiTbl.UpdateDt as SaisaisuiUpdateDt ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.UpdateDt as HeaderUpdateDt ");
            sqlContent.Append(", PH1.UpdateDt as PH1UpdateDt ");
            sqlContent.Append(", PH2.UpdateDt as PH2UpdateDt ");
            sqlContent.Append(", TR1.UpdateDt as TR1UpdateDt ");
            sqlContent.Append(", TR2.UpdateDt as TR2UpdateDt ");
            sqlContent.Append(", BOD1.UpdateDt as BOD1UpdateDt ");
            sqlContent.Append(", BOD2.UpdateDt as BOD2UpdateDt ");
            sqlContent.Append(", ZANEN1.UpdateDt as ZANEN1UpdateDt ");
            sqlContent.Append(", ZANEN2.UpdateDt as ZANEN2UpdateDt ");
            sqlContent.Append(", CL1.UpdateDt as CL1UpdateDt ");
            sqlContent.Append(", CL2.UpdateDt as CL2UpdateDt ");
            // 20150129 sou Start
            sqlContent.Append(", ATUBOD1.UpdateDt as ATUBOD1UpdateDt ");
            sqlContent.Append(", ATUBOD2.UpdateDt as ATUBOD2UpdateDt ");
            // 20150129 sou End
            // 20150119 sou Start
            //// 20150111 sou Start
            //sqlContent.Append(", KensaIraiTbl.KensaIraiSuishitsuUketsukeDt as UketsukeDt ");
            //// 20150111 sou End
            sqlContent.Append(", KensaDaicho11joHdrTbl.KensaIraiUketsukeDt as UketsukeDt ");
            // 20150119 sou Start

            #endregion

            #region FROM

            sqlContent.Append("FROM ");

            sqlContent.Append("KensaDaicho11joHdrTbl ");
            sqlContent.Append("Inner Join ");
            sqlContent.Append("( ");
            sqlContent.Append("    select KensaIraiTbl.* ");
            sqlContent.Append("    , ShoriHoshikiMst.ShoriHoshikiKbn ");
            sqlContent.Append("    , ShoriHoshikiMst.ShoriHoshikiCd ");
            sqlContent.Append("    , ShoriHoshikiMst.ShoriHoshikiShubetsuNm ");
            sqlContent.Append("    , ShoriHoshikiMst.ShoriHoshikiNm ");
            sqlContent.Append("    from KensaIraiTbl Left Join ShoriHoshikiMst ");
            sqlContent.Append("    On KensaIraiTbl.KensaIraiShorihoshikiKbn = ShoriHoshikiMst.ShoriHoshikiKbn ");
            sqlContent.Append("    and KensaIraiTbl.KensaIraiShorihoshikiCd = ShoriHoshikiMst.ShoriHoshikiCd ");
            sqlContent.Append(") as KensaIraiTbl ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban ");
            sqlContent.Append("Left Join ConstMst ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.HanteiCd = ConstMst.ConstValue ");
            sqlContent.Append("    and '016' = ConstMst.ConstKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as PH1 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = PH1.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = PH1.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = PH1.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = PH1.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdPh = PH1.ShikenkoumokuCd ");
            sqlContent.Append("    and '0' = PH1.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as PH2 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = PH2.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = PH2.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = PH2.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = PH2.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdPh = PH2.ShikenkoumokuCd ");
            sqlContent.Append("    and '1' = PH2.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TR1 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = TR1.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = TR1.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = TR1.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = TR1.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdTr = TR1.ShikenkoumokuCd ");
            sqlContent.Append("    and '0' = TR1.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TR2 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = TR2.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = TR2.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = TR2.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = TR2.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdTr = TR2.ShikenkoumokuCd ");
            sqlContent.Append("    and '1' = TR2.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as BOD1 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = BOD1.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = BOD1.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = BOD1.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = BOD1.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdBod = BOD1.ShikenkoumokuCd ");
            sqlContent.Append("    and '0' = BOD1.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as BOD2 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = BOD2.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = BOD2.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = BOD2.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = BOD2.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdBod = BOD2.ShikenkoumokuCd ");
            sqlContent.Append("    and '1' = BOD2.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as ZANEN1 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = ZANEN1.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = ZANEN1.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = ZANEN1.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = ZANEN1.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdZanen = ZANEN1.ShikenkoumokuCd ");
            sqlContent.Append("    and '0' = ZANEN1.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as ZANEN2 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = ZANEN2.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = ZANEN2.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = ZANEN2.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = ZANEN2.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdZanen = ZANEN2.ShikenkoumokuCd ");
            sqlContent.Append("    and '1' = ZANEN2.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as CL1 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = CL1.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = CL1.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = CL1.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = CL1.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdCl = CL1.ShikenkoumokuCd ");
            sqlContent.Append("    and '0' = CL1.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as CL2 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = CL2.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = CL2.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = CL2.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = CL2.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdCl = CL2.ShikenkoumokuCd ");
            sqlContent.Append("    and '1' = CL2.SaikensaKbn ");

            // 20150129 sou Start
            sqlContent.Append("Left Join KensaDaichoDtlTbl as ATUBOD1 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = ATUBOD1.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = ATUBOD1.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = ATUBOD1.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = ATUBOD1.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdAtubod = ATUBOD1.ShikenkoumokuCd ");
            sqlContent.Append("    and '0' = ATUBOD1.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as ATUBOD2 ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKbn = ATUBOD2.KensaKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.IraiNendo = ATUBOD2.IraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.ShishoCd = ATUBOD2.ShishoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo = ATUBOD2.SuishitsuKensaIraiNo ");
            sqlContent.Append("    and @kmkCdAtubod = ATUBOD2.ShikenkoumokuCd ");
            sqlContent.Append("    and '1' = ATUBOD2.SaikensaKbn ");
            // 20150129 sou End

            sqlContent.Append("Left Join KensaKekkaTbl ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn = KensaKekkaTbl.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban ");
            sqlContent.Append("Left Join SaisaisuiTbl ");
            sqlContent.Append("    On KensaDaicho11joHdrTbl.KensaKekkaIraiHoteiKbn = SaisaisuiTbl.SaiSaisuiIraiHoteiKbn ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiHokenjoCd = SaisaisuiTbl.SaiSaisuiIraiHokenjoCd ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiNendo = SaisaisuiTbl.SaiSaisuiIraiNendo ");
            sqlContent.Append("    and KensaDaicho11joHdrTbl.KensaKekkaIraiRenban = SaisaisuiTbl.SaiSaisuiIraiRrenban ");

            commandParams.Add("@kmkCdPh", SqlDbType.NVarChar).Value = searchCond.KmkCdPh;
            commandParams.Add("@kmkCdTr", SqlDbType.NVarChar).Value = searchCond.KmkCdTr;
            commandParams.Add("@kmkCdBod", SqlDbType.NVarChar).Value = searchCond.KmkCdBod;
            commandParams.Add("@kmkCdZanen", SqlDbType.NVarChar).Value = searchCond.KmkCdZanen;
            commandParams.Add("@kmkCdCl", SqlDbType.NVarChar).Value = searchCond.KmkCdCl;
            commandParams.Add("@kmkCdAtubod", SqlDbType.NVarChar).Value = searchCond.KmkCdAtubod;

            #endregion

            #region WHERE(定型)

            sqlContent.Append("WHERE ");

            sqlContent.Append("KensaDaicho11joHdrTbl.ShishoCd = @LoginShishoCd ");
            sqlContent.Append("and( ");
            sqlContent.Append("    ( ");
            sqlContent.Append("        KensaDaicho11joHdrTbl.SaisaisuiKbn = '0' ");
            sqlContent.Append("        and( ");
            sqlContent.Append("            KensaDaicho11joHdrTbl.KachoKeninKbn = '0' ");
            sqlContent.Append("            or ");
            sqlContent.Append("            KensaDaicho11joHdrTbl.HukuKachoKeninKbn = '0' ");
            sqlContent.Append("        ) ");
            sqlContent.Append("    ) ");
            sqlContent.Append("    or ");
            sqlContent.Append("    ( ");
            sqlContent.Append("        KensaDaicho11joHdrTbl.SaisaisuiKbn = '1' ");
            sqlContent.Append("        and( ");
            sqlContent.Append("            KensaDaicho11joHdrTbl.KachoKeninKbn = '0' ");
            sqlContent.Append("        or ");
            sqlContent.Append("            KensaDaicho11joHdrTbl.HukuKachoKeninKbn = '0' ");
            sqlContent.Append("        or ");
            sqlContent.Append("            KensaDaicho11joHdrTbl.KachoKeninKbnScreening = '0' ");
            sqlContent.Append("        or ");
            sqlContent.Append("            KensaDaicho11joHdrTbl.HukuKachoKeninKbnScreening = '0' ");
            sqlContent.Append("        ) ");
            sqlContent.Append("    ) ");
            sqlContent.Append(") ");

            commandParams.Add("@LoginShishoCd", SqlDbType.NVarChar).Value = searchCond.ShishoCd;

            #endregion

            #region WHERE(動的)

            // 年度
            if (!string.IsNullOrEmpty(searchCond.Nendo))
            {
                sqlContent.Append("AND KensaDaicho11joHdrTbl.IraiNendo = @IraiNendo ");
                commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = searchCond.Nendo;
            }

            // 依頼受付日入力区分の有無
            if (searchCond.IraiUketsukeDtInputKbn == "1")
            {
                // 依頼受付日(開始)
                sqlContent.Append("AND KensaDaicho11joHdrTbl.KensaIraiUketsukeDt >= @IraiUketsukeFromDt ");
                commandParams.Add("@IraiUketsukeFromDt", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeFromDt;
                // 依頼受付日(開始)
                sqlContent.Append("AND KensaDaicho11joHdrTbl.KensaIraiUketsukeDt <= @IraiUketsukeToDt ");
                commandParams.Add("@IraiUketsukeToDt", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeToDt;
            }

            // 11条水質
            if (searchCond.KensaKbnSuisitsu == "1")
            {
                sqlContent.Append("AND KensaDaicho11joHdrTbl.KensaKbn = @KensaKbnSuisitsu ");
                commandParams.Add("@KensaKbnSuisitsu", SqlDbType.NVarChar).Value = "2";
            }

            // 外観探査
            if (searchCond.KensaKbnGaikan == "1")
            {
                sqlContent.Append("AND KensaDaicho11joHdrTbl.KensaKbn = @KensaKbnGaikan ");
                commandParams.Add("@KensaKbnGaikan", SqlDbType.NVarChar).Value = "3";
            }

            // 依頼No(開始)
            if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
            {
                sqlContent.Append("AND KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo >= @IraiNoFrom ");
                commandParams.Add("@IraiNoFrom", SqlDbType.NVarChar).Value = searchCond.IraiNoFrom;
            }

            // 依頼No(終了)
            if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
            {
                sqlContent.Append("AND KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo <= @IraiNoTo ");
                commandParams.Add("@IraiNoTo", SqlDbType.NVarChar).Value = searchCond.IraiNoTo;
            }

            #endregion

            #region ORDER BY

            sqlContent.Append("ORDER BY ");

            sqlContent.Append("KensaDaicho11joHdrTbl.KensaKbn ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.IraiNendo ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.ShishoCd ");
            sqlContent.Append(", KensaDaicho11joHdrTbl.SuishitsuKensaIraiNo ");

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region YachoOutputKensaListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YachoOutputKensaListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04　AnhNV          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class YachoOutputKensaListTableAdapter
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
        /// 2014/12/04　AnhNV　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable GetDataBySearchCond(YachoOutputSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable table = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
            adpt.Fill(table);

            return table;
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
        /// 2014/12/04　AnhNV　　　新規作成
        /// 2014/12/28  小松　　　　外観検査時は、検査結果テーブル．検査状況を判定してリストアップ(検査状況が003:完了)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(YachoOutputSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();

            // 外観
            if (searchCond.TypeSearch == TypeSearch.GaikanKensa)
            {
                sqlContent.AppendLine(" select                                                                                                                                              ");
                sqlContent.AppendLine("     '0' as OutputCol,                                                                                                                               ");
                sqlContent.AppendLine("     row_number() over(order by kdht.SuishitsuKensaIraiNo) as RowNoCol,                                                                              ");
                sqlContent.AppendLine("     kdht.IraiNendo as IraiNendoCol,                                                                                                                 ");
                sqlContent.AppendLine("     kdht.ShishoCd as ShishoCdCol,                                                                                                                   ");
                sqlContent.AppendLine("     kdht.SuishitsuKensaIraiNo as SuishitsuKensaIraiNoCol,                                                                                           ");
                sqlContent.AppendLine("     cm1.ConstNm as HoteiKbnCol,                                                                                                                     ");
                sqlContent.AppendLine("     concat(concat(concat(concat(kit.KensaIraiHokenjoCd, '-'),                                                                                       ");
                sqlContent.AppendLine("         dbo.FuncConvertIraiNedoToWareki(kit.KensaIraiNendo)), '-'), kit.KensaIraiRenban) as KensaNoCol,                                             ");
                sqlContent.AppendLine("     case                                                                                                                                            ");
                sqlContent.AppendLine("         when isdate(kit.KensaIraiSuishitsuUketsukeDt) = 0 then ''                                                                                   ");
                sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, kit.KensaIraiSuishitsuUketsukeDt), 111)                                                         ");
                sqlContent.AppendLine("     end as UketsukeDtCol,                                                                                                                           ");
                sqlContent.AppendLine("     concat(concat(concat(concat(kit.KensaIraiJokasoHokenjoCd, '-'),                                                                                 ");
                sqlContent.AppendLine("         dbo.FuncConvertIraiNedoToWareki(kit.KensaIraiJokasoTorokuNendo)), '-'), kit.KensaIraiJokasoRenban) as DaichoNoCol,                          ");
                sqlContent.AppendLine("     '' as SaisuiDtCol,                                                                                                                              ");
                sqlContent.AppendLine("     '' as SaisuiinNmCol,                                                                                                                            ");
                sqlContent.AppendLine("     kit.KensaIraiSetchishaNm as SetchishaNmCol,                                                                                                     ");
                sqlContent.AppendLine("     kit.KensaIraiSetchishaAdr as SetchishaAdrCol,                                                                                                   ");
                sqlContent.AppendLine("     kit.KensaIraiSetchibashoAdr as SetchiAdrCol,                                                                                                    ");
                sqlContent.AppendLine("     gm.GyoshaNm as MakerNmCol,                                                                                                                      ");
                sqlContent.AppendLine("     km.KatashikiNm as KatashikiNmCol,                                                                                                               ");
                sqlContent.AppendLine("     shm.ShoriHoshikiShubetsuNm as ShorihoshikiKbnCol,                                                                                               ");
                sqlContent.AppendLine("     shm.ShoriHoshikiNm as ShorihoshikiNmCol,                                                                                                        ");
                sqlContent.AppendLine("     kit.KensaIraiShoritaishoJinin as NinsoCol,                                                                                                      ");
                sqlContent.AppendLine("     cm2.ConstNm as ScreeningKbnCol,                                                                                                                 ");
                sqlContent.AppendLine("     '' as SuishitsuShikenKoumokuCd,                                                                                                                 ");
                sqlContent.AppendLine("     '' as YachoFileNm                                                                                                                               ");
                sqlContent.AppendLine(" from KensaDaicho11joHdrTbl kdht                                                                                                                     ");
                sqlContent.AppendLine(" inner join KensaIraiTbl kit                                                                                                                         ");
                sqlContent.AppendLine("     on kdht.KensaKekkaIraiHoteiKbn = kit.KensaIraiHoteiKbn                                                                                          ");
                sqlContent.AppendLine("     and kdht.KensaKekkaIraiHokenjoCd = kit.KensaIraiHokenjoCd                                                                                       ");
                sqlContent.AppendLine("     and kdht.KensaKekkaIraiNendo = kit.KensaIraiNendo                                                                                               ");
                sqlContent.AppendLine("     and kdht.KensaKekkaIraiRenban = kit.KensaIraiRenban                                                                                             ");
                sqlContent.AppendLine(" inner join KensaKekkaTbl kkt                                                                                                                        ");
                sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn                                                                                           ");
                sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd                                                                                        ");
                sqlContent.AppendLine("     and kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo                                                                                                ");
                sqlContent.AppendLine("     and kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban                                                                                              ");
                sqlContent.AppendLine(" left outer join KatashikiMst km                                                                                                                     ");
                sqlContent.AppendLine("     on kit.KensaIraiMakerCd = km.KatashikiMakerCd                                                                                                   ");
                sqlContent.AppendLine("     and kit.KensaIraiKatashikiCd = km.KatashikiCd                                                                                                   ");
                sqlContent.AppendLine(" left outer join ShoriHoshikiMst shm                                                                                                                 ");
                sqlContent.AppendLine("     on kit.KensaIraiShorihoshikiKbn = shm.ShoriHoshikiKbn                                                                                           ");
                sqlContent.AppendLine("     and kit.KensaIraiShorihoshikiCd = shm.ShoriHoshikiCd                                                                                            ");
                sqlContent.AppendLine(" left outer join GyoshaMst gm                                                                                                                        ");
                sqlContent.AppendLine("     on kit.KensaIraiMakerCd = gm.GyoshaCd                                                                                                           ");
                sqlContent.AppendLine(" left outer join ConstMst cm1                                                                                                                        ");
                sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = cm1.ConstValue                                                                                                       ");
                sqlContent.AppendLine("     and cm1.ConstKbn = '006'                                                                                                                        ");
                sqlContent.AppendLine(" left outer join ConstMst cm2                                                                                                                        ");
                sqlContent.AppendLine("     on kit.KensaIraiScreeningKbn = cm2.ConstValue                                                                                                   ");
                sqlContent.AppendLine("     and cm2.ConstKbn = '024'                                                                                                                        ");
                // WHERE
                sqlContent.AppendLine(" where                                                                                                                                               ");
                sqlContent.AppendLine("     kit.KensaIraiStatusKbn <= '50'                                                                                                                  ");
                sqlContent.AppendLine(" and kkt.KensaKekkaKensaJoukyouKbn != '003'                                                                                                       ");

                // 依頼年度
                if (!string.IsNullOrEmpty(searchCond.IraiNendo))
                {
                    sqlContent.AppendLine(" and kdht.IraiNendo = @IraiNendo                                                                                                                 ");
                    commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = (string)searchCond.IraiNendo;
                }
                // 支所コード
                if (!string.IsNullOrEmpty(searchCond.ShishoCd))
                {
                    sqlContent.AppendLine(" and kdht.ShishoCd = @ShishoCd                                                                                                                   ");
                    commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = (string)searchCond.ShishoCd;
                }
                // 水質検査依頼番号（開始）
                if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
                {
                    sqlContent.AppendLine(" and kdht.SuishitsuKensaIraiNo >= @SuishitsuKensaIraiNoFrom                                                                                      ");
                    commandParams.Add("@SuishitsuKensaIraiNoFrom", SqlDbType.NVarChar).Value = (string)searchCond.IraiNoFrom;
                }
                // 水質検査依頼番号（終了）
                if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
                {
                    sqlContent.AppendLine(" and kdht.SuishitsuKensaIraiNo <= @SuishitsuKensaIraiNoTo                                                                                        ");
                    commandParams.Add("@SuishitsuKensaIraiNoTo", SqlDbType.NVarChar).Value = (string)searchCond.IraiNoTo;
                }

                sqlContent.AppendLine("     and                                                                                                                                             ");
                sqlContent.AppendLine("     (                                                                                                                                               ");
                sqlContent.AppendLine("         kit.KensaIraiHoteiKbn = '1'                                                                                                                 ");
                sqlContent.AppendLine("         or kit.KensaIraiHoteiKbn = '2'                                                                                                              ");
                sqlContent.AppendLine("         or (kit.KensaIraiHoteiKbn = '3' and kit.KensaIraiScreeningKbn = '1')                                                                        ");
                sqlContent.AppendLine("         or (kit.KensaIraiHoteiKbn = '3' and kit.KensaIraiScreeningKbn = '3')                                                                        ");
                sqlContent.AppendLine("     )                                                                                                                                               ");
                // 並び順
                sqlContent.AppendLine(" order by kdht.SuishitsuKensaIraiNo ");
            }
            else if (searchCond.TypeSearch == TypeSearch.SuishitsuKensa) // 水質
            {
                sqlContent.AppendLine(" select");
                sqlContent.AppendLine("     '0' as OutputCol,                                                                                                                               ");
                sqlContent.AppendLine("     row_number() over(order by kdht.SuishitsuKensaIraiNo) as RowNoCol,                                                                              ");
                sqlContent.AppendLine("     kdht.IraiNendo as IraiNendoCol,                                                                                                                 ");
                sqlContent.AppendLine("     kdht.ShishoCd as ShishoCdCol,                                                                                                                   ");
                sqlContent.AppendLine("     kdht.SuishitsuKensaIraiNo as SuishitsuKensaIraiNoCol,                                                                                           ");
                sqlContent.AppendLine("     cm1.ConstNm as HoteiKbnCol,                                                                                                                     ");
                sqlContent.AppendLine("     concat(concat(concat(concat(kit.KensaIraiHokenjoCd, '-'),                                                                                       ");
                sqlContent.AppendLine("         dbo.FuncConvertIraiNedoToWareki(kit.KensaIraiNendo)), '-'), kit.KensaIraiRenban) as KensaNoCol,                                             ");
                sqlContent.AppendLine("     case                                                                                                                                            ");
                sqlContent.AppendLine("         when isdate(kit.KensaIraiSuishitsuUketsukeDt) = 0 then ''                                                                                   ");
                sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, kit.KensaIraiSuishitsuUketsukeDt), 111)                                                         ");
                sqlContent.AppendLine("     end as UketsukeDtCol,                                                                                                                           ");
                sqlContent.AppendLine("     concat(concat(concat(concat(kit.KensaIraiJokasoHokenjoCd, '-'),                                                                                 ");
                sqlContent.AppendLine("         dbo.FuncConvertIraiNedoToWareki(kit.KensaIraiJokasoTorokuNendo)), '-'), kit.KensaIraiJokasoRenban) as DaichoNoCol,                          ");
                sqlContent.AppendLine("     '' as SaisuiDtCol,                                                                                                                              ");
                sqlContent.AppendLine("     sm.SaisuiinNm as SaisuiinNmCol,                                                                                                                 ");
                sqlContent.AppendLine("     kit.KensaIraiSetchishaNm as SetchishaNmCol,                                                                                                     ");
                sqlContent.AppendLine("     kit.KensaIraiSetchishaAdr as SetchishaAdrCol,                                                                                                   ");
                sqlContent.AppendLine("     kit.KensaIraiSetchibashoAdr as SetchiAdrCol,                                                                                                    ");
                sqlContent.AppendLine("     gm.GyoshaNm as MakerNmCol,                                                                                                                      ");
                sqlContent.AppendLine("     km.KatashikiNm as KatashikiNmCol,                                                                                                               ");
                sqlContent.AppendLine("     shm.ShoriHoshikiShubetsuNm as ShorihoshikiKbnCol,                                                                                               ");
                sqlContent.AppendLine("     shm.ShoriHoshikiNm as ShorihoshikiNmCol,                                                                                                        ");
                sqlContent.AppendLine("     kit.KensaIraiShoritaishoJinin as NinsoCol,                                                                                                      ");
                sqlContent.AppendLine("     '' as ScreeningKbnCol,                                                                                                                          ");
                sqlContent.AppendLine("     '' as SuishitsuShikenKoumokuCd,                                                                                                                 ");
                sqlContent.AppendLine("     '' as YachoFileNm                                                                                                                               ");
                sqlContent.AppendLine(" from KensaDaicho11joHdrTbl kdht                                                                                                                     ");
                sqlContent.AppendLine(" left outer join KensaIraiTbl kit                                                                                                                    ");
                sqlContent.AppendLine("     on kdht.KensaKekkaIraiHoteiKbn = kit.KensaIraiHoteiKbn                                                                                          ");
                sqlContent.AppendLine("     and kdht.KensaKekkaIraiHokenjoCd = kit.KensaIraiHokenjoCd                                                                                       ");
                sqlContent.AppendLine("     and kdht.KensaKekkaIraiNendo = kit.KensaIraiNendo                                                                                               ");
                sqlContent.AppendLine("     and kdht.KensaKekkaIraiRenban = kit.KensaIraiRenban                                                                                             ");
                sqlContent.AppendLine(" left outer join KatashikiMst km                                                                                                                     ");
                sqlContent.AppendLine("     on kit.KensaIraiMakerCd = km.KatashikiMakerCd                                                                                                   ");
                sqlContent.AppendLine("     and kit.KensaIraiKatashikiCd = km.KatashikiCd                                                                                                   ");
                sqlContent.AppendLine(" left outer join ShoriHoshikiMst shm                                                                                                                 ");
                sqlContent.AppendLine("     on kit.KensaIraiShorihoshikiKbn = shm.ShoriHoshikiKbn                                                                                           ");
                sqlContent.AppendLine("     and kit.KensaIraiShorihoshikiCd = shm.ShoriHoshikiCd                                                                                            ");
                sqlContent.AppendLine(" left outer join SaisuiinMst sm                                                                                                                      ");
                sqlContent.AppendLine("     on kit.KensaIraiSaisuiinCd = sm.SaisuiinCd                                                                                                      ");
                sqlContent.AppendLine(" left outer join GyoshaMst gm                                                                                                                        ");
                sqlContent.AppendLine("     on kit.KensaIraiMakerCd = gm.GyoshaCd                                                                                                           ");
                sqlContent.AppendLine(" left outer join ConstMst cm1                                                                                                                        ");
                sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = cm1.ConstValue                                                                                                       ");
                sqlContent.AppendLine("     and cm1.ConstKbn = '006'                                                                                                                        ");
                // WHERE
                sqlContent.AppendLine(" where                                                                                                                                               ");
                sqlContent.AppendLine("     kit.KensaIraiStatusKbn = '50'                                                                                                                   ");
                sqlContent.AppendLine("     and kit.KensaIraiHoteiKbn = '3'                                                                                                                 ");
                sqlContent.AppendLine("     and kit.KensaIraiScreeningKbn = '0'                                                                                                             ");
                // 依頼年度
                if (!string.IsNullOrEmpty(searchCond.IraiNendo))
                {
                    sqlContent.AppendLine(" and kdht.IraiNendo = @IraiNendo                                                                                                                 ");
                    commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = (string)searchCond.IraiNendo;
                }
                // 支所コード
                if (!string.IsNullOrEmpty(searchCond.ShishoCd))
                {
                    sqlContent.AppendLine(" and kdht.ShishoCd = @ShishoCd                                                                                                                   ");
                    commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = (string)searchCond.ShishoCd;
                }
                // 水質検査依頼番号（開始）
                if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
                {
                    sqlContent.AppendLine(" and kdht.SuishitsuKensaIraiNo >= @SuishitsuKensaIraiNoFrom                                                                                      ");
                    commandParams.Add("@SuishitsuKensaIraiNoFrom", SqlDbType.NVarChar).Value = (string)searchCond.IraiNoFrom;
                }
                // 水質検査依頼番号（終了）
                if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
                {
                    sqlContent.AppendLine(" and kdht.SuishitsuKensaIraiNo <= @SuishitsuKensaIraiNoTo                                                                                        ");
                    commandParams.Add("@SuishitsuKensaIraiNoTo", SqlDbType.NVarChar).Value = (string)searchCond.IraiNoTo;
                }
                // 並び順
                sqlContent.AppendLine(" order by kdht.SuishitsuKensaIraiNo ");
            }
            else if (searchCond.TypeSearch == TypeSearch.KeiryoKensa) // 計量証明 
            {
                sqlContent.AppendLine(" select                                                                                                                                              ");
                sqlContent.AppendLine("     '0' as OutputCol,                                                                                                                               ");
                sqlContent.AppendLine("     row_number() over(order by kdht.SuishitsuKensaIraiNo, kskt.KeiryoShomeiShikenkoumokuCd) as RowNoCol,                                            ");
                sqlContent.AppendLine("     kdht.IraiNendo as IraiNendoCol,                                                                                                                 ");
                sqlContent.AppendLine("     kdht.ShishoCd as ShishoCdCol,                                                                                                                   ");
                sqlContent.AppendLine("     kdht.SuishitsuKensaIraiNo as SuishitsuKensaIraiNoCol,                                                                                           ");
                sqlContent.AppendLine("     '' as HoteiKbnCol,                                                                                                                              ");
                sqlContent.AppendLine("     concat(concat(concat(concat(ksit.KeiryoShomeiIraiSishoCd, '-'),                                                                                 ");
                sqlContent.AppendLine("         dbo.FuncConvertIraiNedoToWareki(ksit.KeiryoShomeiIraiNendo)), '-'), ksit.KeiryoShomeiIraiRenban) as KensaNoCol,                             ");
                sqlContent.AppendLine("     case                                                                                                                                            ");
                sqlContent.AppendLine("         when isdate(ksit.KeiryoShomeiIraiUketsukeDt) = 0 then ''                                                                                    ");
                sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, ksit.KeiryoShomeiIraiUketsukeDt), 111)                                                          ");
                sqlContent.AppendLine("     end as UketsukeDtCol,                                                                                                                           ");
                sqlContent.AppendLine("     concat(concat(concat(concat(ksit.KeiryoShomeiJokasoDaichoHokenjoCd, '-'),                                                                       ");
                sqlContent.AppendLine("         dbo.FuncConvertIraiNedoToWareki(ksit.KeiryoShomeiJokasoDaichoNendo)), '-'), ksit.KeiryoShomeiJokasoDaichoRenban) as DaichoNoCol,            ");
                sqlContent.AppendLine("     case                                                                                                                                            ");
                sqlContent.AppendLine("         when isdate(ksit.KeiryoShomeiSaisuiDt) = 0 then ''                                                                                          ");
                sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, ksit.KeiryoShomeiSaisuiDt), 111)                                                                ");
                sqlContent.AppendLine("     end as SaisuiDtCol,                                                                                                                             ");
                sqlContent.AppendLine("     gm2.GyoshaNm as SaisuiinNmCol,                                                                                                                  ");
                sqlContent.AppendLine("     jdm.JokasoSetchishaNm as SetchishaNmCol,                                                                                                        ");
                sqlContent.AppendLine("     jdm.JokasoSetchishaAdr as SetchishaAdrCol,                                                                                                      ");
                sqlContent.AppendLine("     jdm.JokasoSetchiBashoAdr as SetchiAdrCol,                                                                                                       ");
                sqlContent.AppendLine("     gm1.GyoshaNm as MakerNmCol,                                                                                                                     ");
                sqlContent.AppendLine("     km.KatashikiNm as KatashikiNmCol,                                                                                                               ");
                sqlContent.AppendLine("     shm.ShoriHoshikiShubetsuNm as ShorihoshikiKbnCol,                                                                                               ");
                sqlContent.AppendLine("     shm.ShoriHoshikiNm as ShorihoshikiNmCol,                                                                                                        ");
                sqlContent.AppendLine("     isnull(try_parse(ksit.KeiryoShomeiNinsou as int), null) as NinsoCol,                                                                            ");
                sqlContent.AppendLine("     '' as ScreeningKbnCol,                                                                                                                          ");
                sqlContent.AppendLine("     sskm.SuishitsuShikenKoumokuCd,                                                                                                                  ");
                sqlContent.AppendLine("     sskm.YachoFileNm                                                                                                                                ");
                sqlContent.AppendLine(" from KensaDaicho9joHdrTbl kdht                                                                                                                      ");
                sqlContent.AppendLine(" left outer join KeiryoShomeiIraiTbl ksit                                                                                                            ");
                sqlContent.AppendLine("     on kdht.KeiryoShomeiIraiNendo = ksit.KeiryoShomeiIraiNendo                                                                                      ");
                sqlContent.AppendLine("     and kdht.KeiryoShomeiIraiSishoCd = ksit.KeiryoShomeiIraiSishoCd                                                                                 ");
                sqlContent.AppendLine("     and kdht.KeiryoShomeiIraiRenban = ksit.KeiryoShomeiIraiRenban                                                                                   ");
                sqlContent.AppendLine(" left outer join KeiryoShomeiKekkaTbl kskt                                                                                                           ");
                sqlContent.AppendLine("     on ksit.KeiryoShomeiIraiNendo = kskt.KeiryoShomeiKekkaIraiNendo                                                                                 ");
                sqlContent.AppendLine("     and ksit.KeiryoShomeiIraiSishoCd = kskt.KeiryoShomeiKekkaIraiShishoCd                                                                           ");
                sqlContent.AppendLine("     and ksit.KeiryoShomeiIraiRenban = kskt.KeiryoShomeiKekkaIraiNo                                                                                  ");
                sqlContent.AppendLine(" left outer join SuishitsuShikenKoumokuMst sskm                                                                                                      ");
                sqlContent.AppendLine("     on kskt.KeiryoShomeiShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd                                                                             ");
                sqlContent.AppendLine(" left outer join JokasoDaichoMst jdm                                                                                                                 ");
                sqlContent.AppendLine("     on ksit.KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd                                                                                 ");
                sqlContent.AppendLine("     and ksit.KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo                                                                                  ");
                sqlContent.AppendLine("     and ksit.KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban                                                                                      ");
                sqlContent.AppendLine(" left outer join GyoshaMst gm1                                                                                                                       ");
                sqlContent.AppendLine("     on jdm.JokasoMekaGyoshaCd = gm1.GyoshaCd                                                                                                        ");
                sqlContent.AppendLine(" left outer join KatashikiMst km                                                                                                                     ");
                sqlContent.AppendLine("     on jdm.JokasoMekaGyoshaCd = km.KatashikiMakerCd                                                                                                 ");
                sqlContent.AppendLine("     and jdm.JokasoKatashikiCd = km.KatashikiCd                                                                                                      ");
                sqlContent.AppendLine(" left outer join ShoriHoshikiMst shm                                                                                                                 ");
                sqlContent.AppendLine("     on ksit.KeiryoShomeiShoriHousikiKbn = shm.ShoriHoshikiKbn                                                                                       ");
                sqlContent.AppendLine("     and ksit.KeiryoShomeiShoriHousikiCd = shm.ShoriHoshikiCd                                                                                        ");
                sqlContent.AppendLine(" left outer join GyoshaMst gm2                                                                                                                       ");
                sqlContent.AppendLine("     on ksit.KeiryoShomeiSaisuiGyoshaCd = gm2.GyoshaCd                                                                                               ");
                // WHERE
                sqlContent.AppendLine(" where                                                                                                                                               ");
                sqlContent.AppendLine("     ksit.KeiryoShomeiStatusKbn = '50'                                                                                                               ");
                // 依頼年度
                if (!string.IsNullOrEmpty(searchCond.IraiNendo))
                {
                    sqlContent.AppendLine(" and kdht.IraiNendo = @IraiNendo                                                                                                                 ");
                    commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = (string)searchCond.IraiNendo;
                }
                // 支所コード
                if (!string.IsNullOrEmpty(searchCond.ShishoCd))
                {
                    sqlContent.AppendLine(" and kdht.ShishoCd = @ShishoCd                                                                                                                   ");
                    commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = (string)searchCond.ShishoCd;
                }
                // 水質検査依頼番号（開始）
                if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
                {
                    sqlContent.AppendLine(" and kdht.SuishitsuKensaIraiNo >= @SuishitsuKensaIraiNoFrom                                                                                      ");
                    commandParams.Add("@SuishitsuKensaIraiNoFrom", SqlDbType.NVarChar).Value = (string)searchCond.IraiNoFrom;
                }
                // 水質検査依頼番号（終了）
                if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
                {
                    sqlContent.AppendLine(" and kdht.SuishitsuKensaIraiNo <= @SuishitsuKensaIraiNoTo                                                                                        ");
                    commandParams.Add("@SuishitsuKensaIraiNoTo", SqlDbType.NVarChar).Value = (string)searchCond.IraiNoTo;
                }
                // 並び順
                sqlContent.AppendLine(" order by kdht.SuishitsuKensaIraiNo, kskt.KeiryoShomeiShikenkoumokuCd ");
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Jo11KakuninKensaJisshiKirokuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Jo11KakuninKensaJisshiKirokuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06　HuyTX         新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class Jo11KakuninKensaJisshiKirokuTableAdapter
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
        /// 2014/12/06　HuyTX      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho11joHdrTblDataSet.Jo11KakuninKensaJisshiKirokuDataTable GetDataBySearchCond(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho11joHdrTblDataSet.Jo11KakuninKensaJisshiKirokuDataTable dataTable = new KensaDaicho11joHdrTblDataSet.Jo11KakuninKensaJisshiKirokuDataTable();
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
        /// 2014/12/06　HuyTX      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // 20150112 sou Start
            #region UNION SELECT
            // SELECT
            sqlContent.Append("SELECT DISTINCT ");
            sqlContent.Append("KensaKbn, ");
            sqlContent.Append("IraiNendo, ");
            sqlContent.Append("ShishoCd, ");
            sqlContent.Append("SuishitsuKensaIraiNo, ");
            sqlContent.Append("ShikenkoumokuCd, ");
            sqlContent.Append("SeishikiNm, ");
            sqlContent.Append("OldKekkaValue, ");
            sqlContent.Append("OldKekkaOndo, ");
            sqlContent.Append("OldKekkaNm, ");
            sqlContent.Append("OldSaiyoKbn, ");
            sqlContent.Append("NewKekkaValue, ");
            sqlContent.Append("NewKekkaOndo, ");
            sqlContent.Append("NewKekkaNm, ");
            sqlContent.Append("NewSaiyoKbn, ");
            sqlContent.Append("SotiNm, ");
            sqlContent.Append("KachoKeninKbn, ");
            sqlContent.Append("HukuKachoKeninKbn, ");
            sqlContent.Append("YachoKinyuKakuninKbn ");
            #endregion

            sqlContent.Append("FROM ");
            sqlContent.Append("( ");
            // 20150112 sou End

            #region SELECT

            sqlContent.Append(" SELECT DISTINCT ");
            sqlContent.Append("         OLDRESULT.KensaKbn, ");
            sqlContent.Append("         OLDRESULT.IraiNendo, ");
            sqlContent.Append("         OLDRESULT.ShishoCd, ");
            sqlContent.Append("         OLDRESULT.SuishitsuKensaIraiNo, ");
            sqlContent.Append("         OLDRESULT.ShikenkoumokuCd, ");
            sqlContent.Append("         sskm.SeishikiNm, ");
            sqlContent.Append("         OLDRESULT.KeiryoShomeiKekkaValue AS OldKekkaValue, ");
            sqlContent.Append("         OLDRESULT.KeiryoShomeiKekkaOndo AS OldKekkaOndo, ");
            sqlContent.Append("         OLDRESULTCNST.ConstNm AS OldKekkaNm, ");
            sqlContent.Append("         OLDRESULT.KeiryoShomeiSaiyoKbn AS OldSaiyoKbn, ");
            sqlContent.Append("         NEWRESULT.KeiryoShomeiKekkaValue AS NewKekkaValue, ");
            sqlContent.Append("         NEWRESULT.KeiryoShomeiKekkaOndo AS NewKekkaOndo, ");
            sqlContent.Append("         NEWRESULTCNST.ConstNm AS NewKekkaNm, ");
            sqlContent.Append("         NEWRESULT.KeiryoShomeiSaiyoKbn AS NewSaiyoKbn, ");
            sqlContent.Append("         SOTI.ConstNm AS SotiNm, ");
            sqlContent.Append("         OLDRESULT.KachoKeninKbn, ");
            sqlContent.Append("         OLDRESULT.HukuKachoKeninKbn, ");
            sqlContent.Append("         OLDRESULT.YachoKinyuKakuninKbn ");

            #endregion

            #region FROM

            sqlContent.Append(" FROM KensaDaichoDtlTbl OLDRESULT ");
            sqlContent.Append(" LEFT OUTER JOIN KensaDaichoDtlTbl NEWRESULT ON     NEWRESULT.KensaKbn = OLDRESULT.KensaKbn ");
            sqlContent.Append("                                             AND NEWRESULT.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append("                                             AND NEWRESULT.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append("                                             AND NEWRESULT.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append("                                             AND NEWRESULT.ShikenkoumokuCd = OLDRESULT.ShikenkoumokuCd  ");
            sqlContent.Append("                                             AND NEWRESULT.SaikensaKbn = '1' ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst sskm ON sskm.SuishitsuShikenKoumokuCd = OLDRESULT.ShikenkoumokuCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst OLDRESULTCNST ON OLDRESULTCNST.ConstValue = OLDRESULT.KeiryoShomeiKekkaValue2 AND OLDRESULTCNST.ConstKbn = '027' ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst NEWRESULTCNST ON NEWRESULTCNST.ConstValue = NEWRESULT.KeiryoShomeiKekkaValue2 AND NEWRESULTCNST.ConstKbn = '027' ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ON SOTI.ConstValue = OLDRESULT.KakuninKensaSoti AND SOTI.ConstKbn = '061' ");
            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho11joHdrTbl ks11ht ON ks11ht.KensaKbn = OLDRESULT.KensaKbn ");
            sqlContent.Append("                                                 AND ks11ht.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append("                                                 AND ks11ht.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append("                                                 AND ks11ht.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append(" LEFT OUTER JOIN KensaIraiTbl kit ON kit.KensaIraiHoteiKbn = ks11ht.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("                                     AND kit.KensaIraiHokenjoCd = ks11ht.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("                                     AND kit.KensaIraiNendo = ks11ht.KensaKekkaIraiNendo ");
            sqlContent.Append("                                     AND kit.KensaIraiRenban = ks11ht.KensaKekkaIraiRenban ");

            #endregion 

            #region WHERE

            sqlContent.Append(" WHERE OLDRESULT.SaikensaKbn = '0' ");
            sqlContent.Append("         AND ((ks11ht.SaisaisuiKbn = '0' AND kit.KensaIraiStatusKbn = '50' AND kit.KensaIraiScreeningKbn  = '0') ");
            sqlContent.Append("             OR (ks11ht.SaisaisuiKbn = '0' AND kit.KensaIraiStatusKbn < 60 AND kit.KensaIraiScreeningKbn  IN ('1', '3')) ");
            // 20141219 sou Start
            //sqlContent.Append("             OR (ks11ht.SaisaisuiKbn = '1' AND kit.KensaIraiStatusKbn = '50' AND kit.KensaIraiScreeningKbn  IN ('1', '3')) ");
            sqlContent.Append("             OR (ks11ht.SaisaisuiKbn = '1' AND kit.KensaIraiStatusKbn = '50') ");
            // 20141219 sou End
            sqlContent.Append("             OR (ks11ht.SaisaisuiKbn = '0' AND kit.KensaIraiStatusKbn < 65 AND kit.KensaIraiScreeningKbn = '2')) ");
            // 20150112 sou Start
            //sqlContent.Append("         AND (OLDRESULT.KensaShubetsuBodTr = '1' ");
            //sqlContent.Append("             OR OLDRESULT.KensaShubetsuKako = '1' ");
            //sqlContent.Append("             OR OLDRESULT.KensaShubetsuBodOver = '1' ");
            //sqlContent.Append("             OR OLDRESULT.KensaShubetsuEnkaIon = '1') ");
            sqlContent.Append("         AND (OLDRESULT.KensaShubetsuBodTr = '2' ");
            sqlContent.Append("             OR OLDRESULT.KensaShubetsuKako = '2' ");
            sqlContent.Append("             OR OLDRESULT.KensaShubetsuBodOver = '2' ");
            sqlContent.Append("             OR OLDRESULT.KensaShubetsuEnkaIon = '2') ");

            // 支所コード
            sqlContent.Append("AND OLDRESULT.ShishoCd = @shishoCd1 ");
            commandParams.Add("@shishoCd1", SqlDbType.NVarChar).Value = searchCond.ShishoCd;
            // 20150112 sou End

            //年度
            if (!string.IsNullOrEmpty(searchCond.Nendo))
            {
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt >= @iraiUketsukeNendoDtFrom1");
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt <= @iraiUketsukeNendoDtTo1");

                commandParams.Add("@iraiUketsukeNendoDtFrom1", SqlDbType.NVarChar).Value = searchCond.Nendo + "0401";
                commandParams.Add("@iraiUketsukeNendoDtTo1", SqlDbType.NVarChar).Value = (Int32.Parse(searchCond.Nendo) + 1) + "0331";
            }

            //依頼受付日（開始）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeFromDt))
            {
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt >= @iraiUketsukeDtFrom1");
                commandParams.Add("@iraiUketsukeDtFrom1", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeFromDt;
            }

            //依頼受付日（終了）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeToDt))
            {
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt <= @iraiUketsukeDtTo1");
                commandParams.Add("@iraiUketsukeDtTo1", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeToDt;
            }

            //依頼No（開始）
            if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
            {
                // 20141219 sou Start
                //sqlContent.Append(" AND kit.KensaIraiSuishitsuIraiNo >= @iraiNoFrom");
                sqlContent.Append(" AND OLDRESULT.SuishitsuKensaIraiNo >= @iraiNoFrom1");
                // 20141219 sou End
                commandParams.Add("@iraiNoFrom1", SqlDbType.NVarChar).Value = searchCond.IraiNoFrom;
            }

            //依頼No（終了）
            if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
            {
                // 20141219 sou Start
                //sqlContent.Append(" AND kit.KensaIraiSuishitsuIraiNo <= @iraiNoTo");
                sqlContent.Append(" AND OLDRESULT.SuishitsuKensaIraiNo <= @iraiNoTo1");
                // 20141219 sou End
                commandParams.Add("@iraiNoTo1", SqlDbType.NVarChar).Value = searchCond.IraiNoTo;
            }

            //検査区分
            if (!string.IsNullOrEmpty(searchCond.KensaKbn))
            {
                //20141217 HuyTX Mod Start
                //sqlContent.Append(" AND OLDRESULT.KensaKbn = @kensaKbn ");
                //commandParams.Add("@kensaKbn", SqlDbType.NVarChar).Value = searchCond.KensaKbn;
                sqlContent.Append(" AND (OLDRESULT.KensaKbn = '2' OR OLDRESULT.KensaKbn = '3') ");
                //20141217 HuyTX Mod End

                sqlContent.Append(" AND kit.KensaIraiHoteiKbn " + (searchCond.KensaKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU
                    ? string.Format(" = '{0}' ", searchCond.KensaKbn) 
                    : string.Format(" IN('{0}', '{1}')", Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN, Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN)));
            }

            #endregion

            // 20150112 sou Start
            #region ORDER BY

            //sqlContent.Append(" ORDER BY OLDRESULT.KensaKbn, ");
            //sqlContent.Append("         OLDRESULT.IraiNendo, ");
            //sqlContent.Append("         OLDRESULT.ShishoCd, ");
            //sqlContent.Append("         OLDRESULT.SuishitsuKensaIraiNo ");

            #endregion

            sqlContent.Append(" UNION ");

            #region SELECT

            sqlContent.Append(" SELECT DISTINCT ");
            sqlContent.Append("         OLDRESULT.KensaKbn, ");
            sqlContent.Append("         OLDRESULT.IraiNendo, ");
            sqlContent.Append("         OLDRESULT.ShishoCd, ");
            sqlContent.Append("         OLDRESULT.SuishitsuKensaIraiNo, ");
            sqlContent.Append("         OLDRESULT.ShikenkoumokuCd, ");
            sqlContent.Append("         sskm.SeishikiNm, ");
            sqlContent.Append("         OLDRESULT.KeiryoShomeiKekkaValue AS OldKekkaValue, ");
            sqlContent.Append("         OLDRESULT.KeiryoShomeiKekkaOndo AS OldKekkaOndo, ");
            sqlContent.Append("         OLDRESULTCNST.ConstNm AS OldKekkaNm, ");
            sqlContent.Append("         OLDRESULT.KeiryoShomeiSaiyoKbn AS OldSaiyoKbn, ");
            sqlContent.Append("         NEWRESULT.KeiryoShomeiKekkaValue AS NewKekkaValue, ");
            sqlContent.Append("         NEWRESULT.KeiryoShomeiKekkaOndo AS NewKekkaOndo, ");
            sqlContent.Append("         NEWRESULTCNST.ConstNm AS NewKekkaNm, ");
            sqlContent.Append("         NEWRESULT.KeiryoShomeiSaiyoKbn AS NewSaiyoKbn, ");
            sqlContent.Append("         SOTI.ConstNm AS SotiNm, ");
            sqlContent.Append("         OLDRESULT.KachoKeninKbn, ");
            sqlContent.Append("         OLDRESULT.HukuKachoKeninKbn, ");
            sqlContent.Append("         OLDRESULT.YachoKinyuKakuninKbn ");

            #endregion

            #region FROM

            sqlContent.Append(" FROM KensaDaichoDtlTbl OLDRESULT ");
            sqlContent.Append(" INNER JOIN KensaDaichoDtlTbl NEWRESULT ON  NEWRESULT.KensaKbn = OLDRESULT.KensaKbn ");
            sqlContent.Append("                                        AND NEWRESULT.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append("                                        AND NEWRESULT.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append("                                        AND NEWRESULT.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append("                                        AND NEWRESULT.ShikenkoumokuCd = OLDRESULT.ShikenkoumokuCd  ");
            sqlContent.Append("                                        AND NEWRESULT.SaikensaKbn = '1' ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst sskm ON sskm.SuishitsuShikenKoumokuCd = OLDRESULT.ShikenkoumokuCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst OLDRESULTCNST ON OLDRESULTCNST.ConstValue = OLDRESULT.KeiryoShomeiKekkaValue2 AND OLDRESULTCNST.ConstKbn = '027' ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst NEWRESULTCNST ON NEWRESULTCNST.ConstValue = NEWRESULT.KeiryoShomeiKekkaValue2 AND NEWRESULTCNST.ConstKbn = '027' ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ON SOTI.ConstValue = OLDRESULT.KakuninKensaSoti AND SOTI.ConstKbn = '061' ");
            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho11joHdrTbl ks11ht ON ks11ht.KensaKbn = OLDRESULT.KensaKbn ");
            sqlContent.Append("                                                 AND ks11ht.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append("                                                 AND ks11ht.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append("                                                 AND ks11ht.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append(" LEFT OUTER JOIN KensaIraiTbl kit ON kit.KensaIraiHoteiKbn = ks11ht.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("                                     AND kit.KensaIraiHokenjoCd = ks11ht.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("                                     AND kit.KensaIraiNendo = ks11ht.KensaKekkaIraiNendo ");
            sqlContent.Append("                                     AND kit.KensaIraiRenban = ks11ht.KensaKekkaIraiRenban ");

            #endregion

            #region WHERE

            sqlContent.Append(" WHERE OLDRESULT.SaikensaKbn = '0' ");
            sqlContent.Append("         AND ((ks11ht.SaisaisuiKbn = '0' AND kit.KensaIraiStatusKbn = '50' AND kit.KensaIraiScreeningKbn  = '0') ");
            sqlContent.Append("             OR (ks11ht.SaisaisuiKbn = '0' AND kit.KensaIraiStatusKbn < 60 AND kit.KensaIraiScreeningKbn  IN ('1', '3')) ");
            sqlContent.Append("             OR (ks11ht.SaisaisuiKbn = '1' AND kit.KensaIraiStatusKbn = '50') ");
            sqlContent.Append("             OR (ks11ht.SaisaisuiKbn = '0' AND kit.KensaIraiStatusKbn < 65 AND kit.KensaIraiScreeningKbn = '2')) ");
            sqlContent.Append("         AND (OLDRESULT.KensaShubetsuBodTr != '2' ");
            sqlContent.Append("             AND OLDRESULT.KensaShubetsuKako != '2' ");
            sqlContent.Append("             AND OLDRESULT.KensaShubetsuBodOver != '2' ");
            sqlContent.Append("             AND OLDRESULT.KensaShubetsuEnkaIon != '2') ");

            // 支所コード
            sqlContent.Append("AND OLDRESULT.ShishoCd = @shishoCd2 ");
            commandParams.Add("@shishoCd2", SqlDbType.NVarChar).Value = searchCond.ShishoCd;

            //年度
            if (!string.IsNullOrEmpty(searchCond.Nendo))
            {
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt >= @iraiUketsukeNendoDtFrom2");
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt <= @iraiUketsukeNendoDtTo2");

                commandParams.Add("@iraiUketsukeNendoDtFrom2", SqlDbType.NVarChar).Value = searchCond.Nendo + "0401";
                commandParams.Add("@iraiUketsukeNendoDtTo2", SqlDbType.NVarChar).Value = (Int32.Parse(searchCond.Nendo) + 1) + "0331";
            }

            //依頼受付日（開始）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeFromDt))
            {
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt >= @iraiUketsukeDtFrom2");
                commandParams.Add("@iraiUketsukeDtFrom2", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeFromDt;
            }

            //依頼受付日（終了）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeToDt))
            {
                sqlContent.Append(" AND kit.KensaIraiSuishitsuUketsukeDt <= @iraiUketsukeDtTo2");
                commandParams.Add("@iraiUketsukeDtTo2", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeToDt;
            }

            //依頼No（開始）
            if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
            {
                sqlContent.Append(" AND OLDRESULT.SuishitsuKensaIraiNo >= @iraiNoFrom2");
                commandParams.Add("@iraiNoFrom2", SqlDbType.NVarChar).Value = searchCond.IraiNoFrom;
            }

            //依頼No（終了）
            if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
            {
                sqlContent.Append(" AND OLDRESULT.SuishitsuKensaIraiNo <= @iraiNoTo2");
                commandParams.Add("@iraiNoTo2", SqlDbType.NVarChar).Value = searchCond.IraiNoTo;
            }

            //検査区分
            if (!string.IsNullOrEmpty(searchCond.KensaKbn))
            {
                sqlContent.Append(" AND (OLDRESULT.KensaKbn = '2' OR OLDRESULT.KensaKbn = '3') ");

                sqlContent.Append(" AND kit.KensaIraiHoteiKbn " + (searchCond.KensaKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU
                    ? string.Format(" = '{0}' ", searchCond.KensaKbn)
                    : string.Format(" IN('{0}', '{1}')", Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN, Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN)));
            }

            #endregion

            sqlContent.Append(") as tbl ");

            #region UNION ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("KensaKbn, ");
            sqlContent.Append("IraiNendo, ");
            sqlContent.Append("ShishoCd, ");
            sqlContent.Append("SuishitsuKensaIraiNo ");
            #endregion
            // 20150112 sou End

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
