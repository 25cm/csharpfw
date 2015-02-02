using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {    
    
    public partial class KensaDaicho9joHdrTblDataSet {
    }

    #region KensaKekkaInputSearch2SearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputSearch2SearchCond
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
    public class KensaKekkaInputSearch2SearchCond
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

    #region KeiryoShomeiDaichoSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiryoShomeiDaichoSearchCond
    /// <summary>
    /// 計量証明 検査台帳の検索条件
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　宗     　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KeiryoShomeiDaichoSearchCond
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
        /// 試験項目コード(SS)
        /// </summary>
        public string KmkCdSs { get; set; }
        /// <summary>
        /// 試験項目コード(BOD（A）)
        /// </summary>
        public string KmkCdBodA { get; set; }
        /// <summary>
        /// 試験項目コード(アンモニア性窒素)
        /// </summary>
        public string KmkCdNh4n { get; set; }
        /// <summary>
        /// 試験項目コード(塩化物イオン)
        /// </summary>
        public string KmkCdCl { get; set; }
        /// <summary>
        /// 試験項目コード(COD)
        /// </summary>
        public string KmkCdCod { get; set; }
        /// <summary>
        /// 試験項目コード(ヘキサン抽出物質（A）)
        /// </summary>
        public string KmkCdHekisanA { get; set; }
        /// <summary>
        /// 試験項目コード(MLSS)
        /// </summary>
        public string KmkCdMlss { get; set; }
        /// <summary>
        /// 試験項目コード(全窒素（A))
        /// </summary>
        public string KmkCdTnA { get; set; }
        /// <summary>
        /// 試験項目コード(陰イオン界面活性剤（A）)
        /// </summary>
        public string KmkCdAbsA { get; set; }
        /// <summary>
        /// 試験項目コード(全りん（A))
        /// </summary>
        public string KmkCdTpA { get; set; }
        /// <summary>
        /// 試験項目コード(りん酸イオン)
        /// </summary>
        public string KmkCdRinsan { get; set; }
        /// <summary>
        /// 試験項目コード(亜硝酸性窒素（定量）)
        /// </summary>
        public string KmkCdNo2nTeiryo { get; set; }
        /// <summary>
        /// 試験項目コード(硝酸性窒素（定量）)
        /// </summary>
        public string KmkCdNo3nTeiryo { get; set; }
        /// <summary>
        /// 試験項目コード(陰イオン界面活性剤（B))
        /// </summary>
        public string KmkCdAbsB { get; set; }
        /// <summary>
        /// 試験項目コード(全窒素（B))
        /// </summary>
        public string KmkCdTnB { get; set; }
        /// <summary>
        /// 試験項目コード(全りん（B))
        /// </summary>
        public string KmkCdTpB { get; set; }
        /// <summary>
        /// 試験項目コード(色度)
        /// </summary>
        public string KmkCdShikido { get; set; }
        /// <summary>
        /// 試験項目コード(BOD（B）)
        /// </summary>
        public string KmkCdBodB { get; set; }
        /// <summary>
        /// 試験項目コード(ヘキサン抽出物質（鉱油類）)
        /// </summary>
        public string KmkCdHekisanKoyu { get; set; }
        /// <summary>
        /// 試験項目コード(ヘキサン抽出物質（動植物油類）)
        /// </summary>
        public string KmkCdHekisanDoshoku { get; set; }
        /// <summary>
        /// 試験項目コード(ヘキサン抽出物質（B）)
        /// </summary>
        public string KmkCdHekisanB { get; set; }
        /// <summary>
        /// 試験項目コード(鉛)
        /// </summary>
        public string KmkCdNamari { get; set; }
        /// <summary>
        /// 試験項目コード(亜鉛)
        /// </summary>
        public string KmkCdAen { get; set; }
        /// <summary>
        /// 試験項目コード(ほう素)
        /// </summary>
        public string KmkCdHouso { get; set; }
        /// <summary>
        /// 試験項目コード(残塩)
        /// </summary>
        public string KmkCdZanen { get; set; }
        /// <summary>
        /// 試験項目コード(外観)
        /// </summary>
        public string KmkCdGaikan { get; set; }
        /// <summary>
        /// 試験項目コード(臭気)
        /// </summary>
        public string KmkCdShuki { get; set; }
        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        public string KmkCdTr { get; set; }
        /// <summary>
        /// 試験項目コード(亜硝酸性窒素（定性）)
        /// </summary>
        public string KmkCdNo2nTeisei { get; set; }
        /// <summary>
        /// 試験項目コード(硝酸性窒素（定性）)
        /// </summary>
        public string KmkCdNo3nTeisei { get; set; }
        /// <summary>
        /// 試験項目コード(大腸菌群数)
        /// </summary>
        public string KmkCdDaichokin { get; set; }

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
        /// 依頼No(開始)
        /// </summary>
        public string IraiNoFrom { get; set; }
        /// <summary>
        /// 依頼No(終了)
        /// </summary>
        public string IraiNoTo { get; set; }

        //20141206_HuyTX add property
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }
        //end
    }
    #endregion
}
namespace FukjBizSystem.Application.DataSet.KensaDaicho9joHdrTblDataSetTableAdapters
{

    #region KensaKekkaInputSearch2TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputSearch2TableAdapter
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
    partial class KensaKekkaInputSearch2TableAdapter
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
        internal KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable GetDataBySearchCond(KensaKekkaInputSearch2SearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable dataTable = new KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable();
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
        private SqlCommand CreateSqlCommand(KensaKekkaInputSearch2SearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                                   ");
            sqlContent.Append("     ROW_NUMBER() OVER (ORDER BY kd9h.SuishitsuKensaIraiNo ASC) AS RowNumber ,                                           ");
            sqlContent.Append(" { fn CONCAT({ fn CONCAT({ fn CONCAT({ fn CONCAT(kd9h.KeiryoShomeiIraiSishoCd, '-') },                                   ");
            sqlContent.Append(" dbo.FuncConvertIraiNedoToWareki(kd9h.KeiryoShomeiIraiNendo)) }, '-') }, kd9h.KeiryoShomeiIraiRenban) } AS KensaIraiNo,  ");
            sqlContent.Append("     kd9h.KeiryoShomeiIraiNendo, kd9h.SuishitsuKensaIraiNo,                                                              ");
            sqlContent.Append("     kd9h.KeiryoShomeiIraiSishoCd, kd9h.KeiryoShomeiIraiRenban ,                                                         ");
            sqlContent.Append("     kdd.ShikenkoumokuCd, kdd.SaikensaKbn, kdd.KeiryoShomeiKekkaCd, kdd.SaikensaKbn AS SaikensaKbnDisp,                  ");
            sqlContent.Append("     kdd.KeiryoShomeiKekkaValue, kdd.KeiryoShomeiKekkaValue2,                                                            ");
            sqlContent.Append("     kdd.KeiryoShomeiKekkaOndo, kdd.KeiryoShomeiGaibuItakuFlg,                                                           ");
            sqlContent.Append("     kdd.UpdateDt, sskm.GaichuItakuKbn                                                                                   ");

            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     KensaDaicho9joHdrTbl AS kd9h                                                                        ");
            sqlContent.Append("INNER JOIN                                                                                               ");
            sqlContent.Append("     KensaDaichoDtlTbl AS kdd                                                                            ");
            sqlContent.Append("         ON '1' = kdd.KensaKbn                                                                           ");
            sqlContent.Append("         AND kd9h.IraiNendo = kdd.IraiNendo                                                              ");
            sqlContent.Append("         AND kd9h.ShishoCd = kdd.ShishoCd                                                                ");
            sqlContent.Append("         AND kd9h.SuishitsuKensaIraiNo = kdd.SuishitsuKensaIraiNo                                        ");
            sqlContent.Append("INNER JOIN                                                                                               ");
            sqlContent.Append("     SuishitsuShikenKoumokuMst AS sskm                                                                   ");
            sqlContent.Append("         ON kdd.ShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd                                          ");
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
			// 受入20141218 ShishoCdが２つある。ShikenkoumokuCdが正しい。
			sqlContent.Append("         AND TargetMeisaiView.ShikenkoumokuCd = kdd.ShikenkoumokuCd                                      ");
			sqlContent.Append("         AND TargetMeisaiView.MaxSaikensaKbn = kdd.SaikensaKbn                                           ");
            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 依頼年度
            sqlContent.Append("AND kd9h.IraiNendo = @IraiNendo                                                                          ");
            commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = searchCond.IraiNendo;
            // 支所コード
            sqlContent.Append("AND kd9h.ShishoCd = @ShishoCd                                                                            ");
            commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = searchCond.ShishoCd;
            // 依頼年度
            sqlContent.Append("AND kdd.ShikenkoumokuCd = @ShikenkoumokuCd                                                               ");
            commandParams.Add("@ShikenkoumokuCd", SqlDbType.NVarChar).Value = searchCond.ShikenkoumokuCd;

            sqlContent.Append("AND kd9h.KachoKeninKbn = '0'                                                                             ");
            sqlContent.Append("AND kd9h.HukuKachoKeninKbn = '0'                                                                         ");
            sqlContent.Append("AND kd9h.KeiryoKanrishaKeninKbn = '0'                                                                    ");

            // 水質検査依頼番号
            if (!string.IsNullOrEmpty(searchCond.SuishitsuKensaIraiNoFrom))
            {
                sqlContent.Append("AND kd9h.SuishitsuKensaIraiNo >= @SuishitsuKensaIraiNoFrom                                           ");
                commandParams.Add("@SuishitsuKensaIraiNoFrom", SqlDbType.NVarChar).Value = searchCond.SuishitsuKensaIraiNoFrom;
            }

            if (!string.IsNullOrEmpty(searchCond.SuishitsuKensaIraiNoTo))
            {
                sqlContent.Append("AND kd9h.SuishitsuKensaIraiNo <= @SuishitsuKensaIraiNoTo                                           ");
                commandParams.Add("@SuishitsuKensaIraiNoTo", SqlDbType.NVarChar).Value = searchCond.SuishitsuKensaIraiNoTo;
            }

            // ORDER BY

            sqlContent.Append("         ORDER BY kd9h.SuishitsuKensaIraiNo ASC                                                         ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KakuninKensaJisshiKiroku2TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninKensaJisshiKiroku2TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KakuninKensaJisshiKiroku2TableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShishoCd"></param>
        /// <param name="Nendo"></param>
        /// <param name="IraiUketsukeDtFrom"></param>
        /// <param name="IraiUketsukeDtTo"></param>
        /// <param name="SuishitsuIraiNoFrom"></param>
        /// <param name="SuishitsuIraiNoTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/27　DatNT　　 新規作成
        /// 2015/01/16  宗          引数変更(UketsukeDtFrom,UketsukeDtTo → Nendo)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable GetDataBySearchCond(
            string ShishoCd,
            string Nendo,
            string IraiUketsukeDtFrom,
            string IraiUketsukeDtTo,
            string SuishitsuIraiNoFrom,
            // 20150121 sou Start
            //string SuishitsuIraiNoTo)
            string SuishitsuIraiNoTo,
            string kmkCdBodA,
            string kmkCdBodB,
            string kmkCdTr,
            string kmkCdCl,
            string kmkCdSs,
            string kmkCdNh4n,
            string kmkCdTnA,
            string kmkCdTnB,
            string kmkCdCod,
            string kmkCdGaikan,
            string kmkCdShuki,
            string kmkCdNo2n,
            string kmkCdNo3n)
            // 20150121 sou End
        {
            SqlCommand command = CreateSqlCommand(ShishoCd,
                                                    Nendo,
                                                    IraiUketsukeDtFrom,
                                                    IraiUketsukeDtTo,
                                                    SuishitsuIraiNoFrom,
                                                    // 20150121 sou Start
                                                    //SuishitsuIraiNoTo);
                                                    SuishitsuIraiNoTo,
                                                    kmkCdBodA,
                                                    kmkCdBodB,
                                                    kmkCdTr,
                                                    kmkCdCl,
                                                    kmkCdSs,
                                                    kmkCdNh4n,
                                                    kmkCdTnA,
                                                    kmkCdTnB,
                                                    kmkCdCod,
                                                    kmkCdGaikan,
                                                    kmkCdShuki,
                                                    kmkCdNo2n,
                                                    kmkCdNo3n);
                                                    // 20150121 sou End

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable dataTable = new KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable();
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
        /// <param name="Shisho"></param>
        /// <param name="Nendo"></param>
        /// <param name="IraiUketsukeDtFrom"></param>
        /// <param name="IraiUketsukeDtTo"></param>
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
            string SuishitsuIraiNoFrom,
            // 20150121 sou Start
            //string SuishitsuIraiNoTo)
            string SuishitsuIraiNoTo,
            string kmkCdBodA,
            string kmkCdBodB,
            string kmkCdTr,
            string kmkCdCl,
            string kmkCdSs,
            string kmkCdNh4n,
            string kmkCdTnA,
            string kmkCdTnB,
            string kmkCdCod,
            string kmkCdGaikan,
            string kmkCdShuki,
            string kmkCdNo2n,
            string kmkCdNo3n)
            // 20150121 sou End
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // 20150109 sou Start
            #region UNION SELECT
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
            sqlContent.Append("     '' AS kensaIraiHoteiKbnCol,                                                                         ");
            sqlContent.Append("     '' AS kensaIraiHokenjoCdCol,                                                                        ");
            sqlContent.Append("     '' AS kensaIraiNendoCol,                                                                            ");
            sqlContent.Append("     '' AS kensaIraiRenbanCol,                                                                           ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo AS keiryoShomeiIraiNendoCol,                             ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd AS keiryoShomeiIraiSishoCdCol,                         ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban AS keiryoShomeiIraiRenbanCol,                           ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd AS jokasoHokenjoCdCol,                        ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoNendo AS jokasoTorokuNendoCol,                          ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoRenban AS jokasoRenbanCol,                              ");
            sqlContent.Append("     '' AS saisaisuiKbnCol,                                                                              ");
            sqlContent.Append("     '1' AS kensaKbnCol,                                                                                 ");
            //MOD_20141212_HuyTX Ver1.02 Start
            //sqlContent.Append("     '9条' AS kensaKbnNmCol,                                                                             ");
            sqlContent.Append("     '計量証明' AS kensaKbnNmCol,                                                                         ");
            //MOD_20141212_HuyTX Ver1.02 End
            sqlContent.Append("     KensaDaicho9joHdrTbl.IraiNendo AS iraiNendoCol,                                                     ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.ShishoCd AS shishoCdCol,                                                       ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo AS iraiNoCol,                                             ");
            sqlContent.Append("     '情報' AS kakoJohoCol,                                                                              ");
            sqlContent.Append("     KensaDaichoDtlTbl.ShikenkoumokuCd AS komokuCdCol,                                                   ");
            sqlContent.Append("     SuishitsuShikenKoumokuMst.SeishikiNm AS komokuNmCol,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue AS pH1Col,                                                 ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaOndo AS ondo1Col,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaCd AS ph1KekkaCdCol,                                             ");
            sqlContent.Append("     CASE                                                                                                ");
            // 20141219 sou Ver1.04 Start
            //sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '007') ");
            //sqlContent.Append("             THEN const2.ConstNm                                                                         ");
            //sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '008') ");
            //sqlContent.Append("             THEN const2.ConstNm                                                                         ");
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '030') ");
            sqlContent.Append("             THEN const2.ConstNm                                                                         ");
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '031') ");
            sqlContent.Append("             THEN const2.ConstNm                                                                         ");
            // 20150111 sou Start
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            // 20150111 sou End
            // 20141219 sou Ver1.04 END
            sqlContent.Append("         ELSE const1.ConstNm                                                                             ");
            sqlContent.Append("     END AS ph1KekkaNmCol,                                                                               ");
            //20141218 HuyTX Ver1.04 Start
            //sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaOndo AS pH2Col,                                                ");
            //sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaValue2 AS ondo2Col,                                            ");
            //sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiSaiyoKbn AS ph2KekkaCdCol,                                          ");
            //sqlContent.Append("     CASE KensaDaichoDtlTbl.KakuninKensaSoti                                                             ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaValue AS pH2Col,                                               ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaOndo AS ondo2Col,                                              ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaCd AS ph2KekkaCdCol,                                           ");
            // 20150116 sou Start
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '030') ");
            sqlContent.Append("             THEN const12.ConstNm                                                                         ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '031') ");
            sqlContent.Append("             THEN const12.ConstNm                                                                         ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst2.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst2.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         ELSE const11.ConstNm                                                                             ");
            sqlContent.Append("     END AS ph2KekkaNmCol,                                                                               ");
            // 20150116 sou End
            sqlContent.Append("     CASE KakuninKensa.KakuninKeiryoShomeiSaiyoKbn                                                       ");
            //End
            sqlContent.Append("         WHEN '1' THEN '1'                                                                               ");
            sqlContent.Append("         ELSE '0' END AS saiyotipH2Col,                                                                  ");
            sqlContent.Append("     KensaDaichoDtlTbl.KakuninKensaSoti AS kakuninKekkaSotiCol,	                                        ");
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
            sqlContent.Append("     '' AS KensaIraiSuishitsuUketsukeDt,                                                                 ");
            sqlContent.Append("     '' AS KensaIraiSuishitsuIraiNo,                                                                     ");
            sqlContent.Append("     KakuninKensa.SaikensaKbn AS SaikensaKbnKakuninKensa,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.SaikensaKbn                                                                       ");

            // 20150109 sou Start
            sqlContent.Append("  , KensaDaichoDtlTbl.IraiNendo as orderIraiNendo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShishoCd as orderShishoCd ");
            sqlContent.Append("  , KensaDaichoDtlTbl.SuishitsuKensaIraiNo as orderHuishitsuKensaIraiNo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShikenkoumokuCd as orderShikenkoumokuCd ");
            // 20150109 sou End
            #endregion

            #region FROM
            // FROM
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
            //20141218 HuyTX Ver1.04 Start
            //sqlContent.Append("           KeiryoShomeiKekkaValue2 AS KakuninKeiryoShomeiKekkaValue2, ");
            sqlContent.Append("           KeiryoShomeiKekkaCd AS KakuninKeiryoShomeiKekkaCd, ");
            //20141218 HuyTX Ver1.04 End
            sqlContent.Append("           KeiryoShomeiSaiyoKbn AS KakuninKeiryoShomeiSaiyoKbn ");
            sqlContent.Append("    FROM KensaDaichoDtlTbl) KakuninKensa ON KakuninKensa.KensaKbn = KensaDaichoDtlTbl.KensaKbn ");
            sqlContent.Append(" AND KakuninKensa.IraiNendo = KensaDaichoDtlTbl.IraiNendo ");
            sqlContent.Append(" AND KakuninKensa.ShishoCd = KensaDaichoDtlTbl.ShishoCd ");
            sqlContent.Append(" AND KakuninKensa.SuishitsuKensaIraiNo = KensaDaichoDtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append(" AND KakuninKensa.ShikenkoumokuCd = KensaDaichoDtlTbl.ShikenkoumokuCd ");
            // 20141224 sou Strat
            sqlContent.Append(" AND KakuninKensa.SaikensaKbn = '1' ");
            // 20141224 sou End

            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho9joHdrTbl ");
            sqlContent.Append(" ON KensaDaichoDtlTbl.IraiNendo = KensaDaicho9joHdrTbl.IraiNendo ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.ShishoCd = KensaDaicho9joHdrTbl.ShishoCd ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo = KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo ");

            sqlContent.Append(" LEFT OUTER JOIN KeiryoShomeiIraiTbl ON KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo = KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo ");
            sqlContent.Append(" AND KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd = KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append(" AND KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban = KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban ");

            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst ON KensaDaichoDtlTbl.ShikenkoumokuCd = SuishitsuShikenKoumokuMst.SuishitsuShikenKoumokuCd ");
            // 20141219 sou Ver1.04 Start
            //sqlContent.Append(" LEFT OUTER JOIN ConstMst const1 ON const1.ConstKbn = '052' ");
            //sqlContent.Append(" AND const1.ConstValue = KakuninKensa.KakuninKeiryoShomeiSaiyoKbn ");
            //sqlContent.Append(" LEFT OUTER JOIN ConstMst const2 ON const2.ConstKbn = '053' ");
            //sqlContent.Append(" AND const2.ConstValue = KakuninKensa.KakuninKeiryoShomeiSaiyoKbn ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const1 ON const1.ConstKbn = '052' ");
            sqlContent.Append(" AND const1.ConstValue = KensaDaichoDtlTbl.KeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const2 ON const2.ConstKbn = '053' ");
            sqlContent.Append(" AND const2.ConstValue = KensaDaichoDtlTbl.KeiryoShomeiKekkaCd ");
            // 20141219 sou Ver1.04 End
            // 20150111 sou Start
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuKekkaNmMst kekkaNmMst ON kekkaNmMst.SuishitsuKekkaShishoCd = @kekkaShishoCd ");
            sqlContent.Append(" AND kekkaNmMst.SuishitsuKekkaNmCd = KensaDaichoDtlTbl.KeiryoShomeiKekkaCd ");
            commandParams.Add("@kekkaShishoCd", SqlDbType.NVarChar).Value = (ShishoCd == "0" ? "3" : ShishoCd);
            // 20150111 sou End
            // 20150116 sou Start
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const11 ON const11.ConstKbn = '052' ");
            sqlContent.Append(" AND const11.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const12 ON const12.ConstKbn = '053' ");
            sqlContent.Append(" AND const12.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuKekkaNmMst kekkaNmMst2 ON kekkaNmMst2.SuishitsuKekkaShishoCd = @kekkaShishoCd ");
            sqlContent.Append(" AND kekkaNmMst2.SuishitsuKekkaNmCd = KakuninKensa.KakuninKeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ");
            sqlContent.Append(" ON SOTI.ConstValue = KensaDaichoDtlTbl.KakuninKensaSoti ");
            sqlContent.Append(" AND SOTI.ConstKbn = '061' ");
            // 20150116 sou End
            #endregion

            #region WHERE
            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 検査区分
            sqlContent.Append("AND KensaDaichoDtlTbl.KensaKbn = '1'                                                                     ");

            // 支所コード
            sqlContent.Append("AND KensaDaichoDtlTbl.ShishoCd = @shishoCd                                                               ");
            commandParams.Add("@shishoCd", SqlDbType.NVarChar).Value = ShishoCd;

            // 再検査回数
            sqlContent.Append("AND KensaDaichoDtlTbl.SaikensaKbn = '0'                                                                  ");
            // 20141224 sou Strat
            //sqlContent.Append("AND KakuninKensa.SaikensaKbn = '1'                                                                       ");
            // 20141224 sou End

            // ステータス区分
            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn = '50'                                                     ");

            // 20150121 sou Start
            //// 20141219 sou Start
            //// 確認検査種別
            //sqlContent.Append("AND (                                                                                                    ");
            //sqlContent.Append("       (KensaDaichoDtlTbl.KensaShubetsuSsTr = '2')                                                    ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuBodTr = '2')                                                   ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuKako = '2')                                                    ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuEnkaIon = '2')                                                 ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuAnmonia = '2')                                                 ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuAnmoniaTn = '2')                                               ");
            //sqlContent.Append("    OR (KensaDaichoDtlTbl.KensaShubetsuCodOver = '2')                                                 ");
            //sqlContent.Append(" )                                                                                                       ");
            //// 20141219 sou End
            // 確認検査種別
            sqlContent.Append("AND ( ");
            sqlContent.Append("       ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@ss, @tr)) AND (KensaDaichoDtlTbl.KensaShubetsuSsTr = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@bodA, @bodB, @tr)) AND (KensaDaichoDtlTbl.KensaShubetsuBodTr = '2')) ");
            sqlContent.Append("    OR (NOT (KensaDaichoDtlTbl.ShikenkoumokuCd in(@gaikan, @shuki, @no2n, @no3n)) AND (KensaDaichoDtlTbl.KensaShubetsuKako = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@cl)) AND (KensaDaichoDtlTbl.KensaShubetsuEnkaIon = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@nh4n)) AND (KensaDaichoDtlTbl.KensaShubetsuAnmonia = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@nh4n, @tnA, @tnB)) AND (KensaDaichoDtlTbl.KensaShubetsuAnmoniaTn = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@cod)) AND (KensaDaichoDtlTbl.KensaShubetsuCodOver = '2')) ");
            sqlContent.Append(" ) ");
            commandParams.Add("@ss", SqlDbType.NVarChar).Value = kmkCdSs;
            commandParams.Add("@tr", SqlDbType.NVarChar).Value = kmkCdTr;
            commandParams.Add("@bodA", SqlDbType.NVarChar).Value = kmkCdBodA;
            commandParams.Add("@bodB", SqlDbType.NVarChar).Value = kmkCdBodB;
            commandParams.Add("@gaikan", SqlDbType.NVarChar).Value = kmkCdGaikan;
            commandParams.Add("@shuki", SqlDbType.NVarChar).Value = kmkCdShuki;
            commandParams.Add("@no2n", SqlDbType.NVarChar).Value = kmkCdNo2n;
            commandParams.Add("@no3n", SqlDbType.NVarChar).Value = kmkCdNo3n;
            commandParams.Add("@cl", SqlDbType.NVarChar).Value = kmkCdCl;
            commandParams.Add("@nh4n", SqlDbType.NVarChar).Value = kmkCdNh4n;
            commandParams.Add("@tnA", SqlDbType.NVarChar).Value = kmkCdTnA;
            commandParams.Add("@tnB", SqlDbType.NVarChar).Value = kmkCdTnB;
            commandParams.Add("@cod", SqlDbType.NVarChar).Value = kmkCdCod;
            // 20150121 sou End

            // ・｛年度｝が空以外の場合
            // 20150116 sou Start
            //if (!string.IsNullOrEmpty(UketsukeDtFrom))
            //{
            //    sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt >= @UketsukeDtFrom ");
            //    commandParams.Add("@UketsukeDtFrom", SqlDbType.NVarChar).Value = UketsukeDtFrom;
            //}

            //if (!string.IsNullOrEmpty(UketsukeDtTo))
            //{
            //    sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt <= @UketsukeDtTo ");
            //    commandParams.Add("@UketsukeDtTo", SqlDbType.NVarChar).Value = UketsukeDtTo;
            //}

            if (!string.IsNullOrEmpty(Nendo))
            {
                sqlContent.Append("AND KensaDaicho9joHdrTbl.IraiNendo = @Nendo ");
                commandParams.Add("@Nendo", SqlDbType.NVarChar).Value = Nendo;
            }
            // 20150116 sou End

            // ・｛依頼受付日（開始）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtFrom))
            {
                sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt >= @IraiUketsukeDtFrom ");
                commandParams.Add("@IraiUketsukeDtFrom", SqlDbType.NVarChar).Value = IraiUketsukeDtFrom;
            }

            // ・｛依頼受付日（終了）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtTo))
            {
                sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt <= @IraiUketsukeDtTo ");
                commandParams.Add("@IraiUketsukeDtTo", SqlDbType.NVarChar).Value = IraiUketsukeDtTo;
            }

            // ・｛依頼No（開始）｝が空以外の場合
            if (!string.IsNullOrEmpty(SuishitsuIraiNoFrom))
            {
                // 20141219 sou Ver1.04 Start
                //sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban >= @SuishitsuIraiNoFrom ");
                sqlContent.Append("AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo >= @SuishitsuIraiNoFrom ");
                // 20141219 sou Ver1.04 End
                commandParams.Add("@SuishitsuIraiNoFrom", SqlDbType.NVarChar).Value = SuishitsuIraiNoFrom;
            }

            // ・｛依頼No（終了）｝が空以外の場合
            if (!string.IsNullOrEmpty(SuishitsuIraiNoTo))
            {
                // 20141219 sou Ver1.04 Start
                //sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban <= @SuishitsuIraiNoTo ");
                sqlContent.Append("AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo <= @SuishitsuIraiNoTo ");
                // 20141219 sou Ver1.04 End
                commandParams.Add("@SuishitsuIraiNoTo", SqlDbType.NVarChar).Value = SuishitsuIraiNoTo;
            }
            #endregion

            // 20150109 sou Start
            //#region ORDER BY
            //// ORDER BY
            //sqlContent.Append("ORDER BY                                                                                                 ");
            //sqlContent.Append("     KensaDaicho9joHdrTbl.IraiNendo,                                                                     ");
            //sqlContent.Append("     KensaDaicho9joHdrTbl.ShishoCd,                                                                      ");
            //sqlContent.Append("     KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo,                                                          ");
            //sqlContent.Append("     KensaDaichoDtlTbl.ShikenkoumokuCd                                                                   ");
            //#endregion

            sqlContent.Append("UNION ");

            #region SELECT
            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     '' AS kensaIraiHoteiKbnCol,                                                                         ");
            sqlContent.Append("     '' AS kensaIraiHokenjoCdCol,                                                                        ");
            sqlContent.Append("     '' AS kensaIraiNendoCol,                                                                            ");
            sqlContent.Append("     '' AS kensaIraiRenbanCol,                                                                           ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo AS keiryoShomeiIraiNendoCol,                             ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd AS keiryoShomeiIraiSishoCdCol,                         ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban AS keiryoShomeiIraiRenbanCol,                           ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd AS jokasoHokenjoCdCol,                        ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoNendo AS jokasoTorokuNendoCol,                          ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoRenban AS jokasoRenbanCol,                              ");
            sqlContent.Append("     '' AS saisaisuiKbnCol,                                                                              ");
            sqlContent.Append("     '1' AS kensaKbnCol,                                                                                 ");
            sqlContent.Append("     '計量証明' AS kensaKbnNmCol,                                                                         ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.IraiNendo AS iraiNendoCol,                                                     ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.ShishoCd AS shishoCdCol,                                                       ");
            sqlContent.Append("     KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo AS iraiNoCol,                                             ");
            sqlContent.Append("     '情報' AS kakoJohoCol,                                                                              ");
            sqlContent.Append("     KensaDaichoDtlTbl.ShikenkoumokuCd AS komokuCdCol,                                                   ");
            sqlContent.Append("     SuishitsuShikenKoumokuMst.SeishikiNm AS komokuNmCol,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaValue AS pH1Col,                                                 ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaOndo AS ondo1Col,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.KeiryoShomeiKekkaCd AS ph1KekkaCdCol,                                             ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '030') ");
            sqlContent.Append("             THEN const2.ConstNm                                                                         ");
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '031') ");
            sqlContent.Append("             THEN const2.ConstNm                                                                         ");
            // 20150111 sou Start
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN KensaDaichoDtlTbl.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            // 20150111 sou End
            sqlContent.Append("         ELSE const1.ConstNm                                                                             ");
            sqlContent.Append("     END AS ph1KekkaNmCol,                                                                               ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaValue AS pH2Col,                                               ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaOndo AS ondo2Col,                                              ");
            sqlContent.Append("     KakuninKensa.KakuninKeiryoShomeiKekkaCd AS ph2KekkaCdCol,                                           ");
            // 20150116 sou Start
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '030') ");
            sqlContent.Append("             THEN const12.ConstNm                                                                         ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '031') ");
            sqlContent.Append("             THEN const12.ConstNm                                                                         ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst2.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN KakuninKensa.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst2.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         ELSE const11.ConstNm                                                                             ");
            sqlContent.Append("     END AS ph2KekkaNmCol,                                                                               ");
            // 20150116 sou End
            sqlContent.Append("     CASE KakuninKensa.KakuninKeiryoShomeiSaiyoKbn                                                       ");
            sqlContent.Append("         WHEN '1' THEN '1'                                                                               ");
            sqlContent.Append("         ELSE '0' END AS saiyotipH2Col,                                                                  ");
            sqlContent.Append("     KensaDaichoDtlTbl.KakuninKensaSoti AS kakuninKekkaSotiCol,	                                        ");
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
            sqlContent.Append("     '' AS KensaIraiSuishitsuUketsukeDt,                                                                 ");
            sqlContent.Append("     '' AS KensaIraiSuishitsuIraiNo,                                                                     ");
            sqlContent.Append("     KakuninKensa.SaikensaKbn AS SaikensaKbnKakuninKensa,                                                ");
            sqlContent.Append("     KensaDaichoDtlTbl.SaikensaKbn                                                                       ");

            sqlContent.Append("  , KensaDaichoDtlTbl.IraiNendo as orderIraiNendo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShishoCd as orderShishoCd ");
            sqlContent.Append("  , KensaDaichoDtlTbl.SuishitsuKensaIraiNo as orderHuishitsuKensaIraiNo ");
            sqlContent.Append("  , KensaDaichoDtlTbl.ShikenkoumokuCd as orderShikenkoumokuCd ");
            #endregion

            #region FROM
            // FROM
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
            sqlContent.Append("           KeiryoShomeiKekkaCd AS KakuninKeiryoShomeiKekkaCd, ");
            sqlContent.Append("           KeiryoShomeiSaiyoKbn AS KakuninKeiryoShomeiSaiyoKbn ");
            sqlContent.Append("    FROM KensaDaichoDtlTbl) KakuninKensa ON KakuninKensa.KensaKbn = KensaDaichoDtlTbl.KensaKbn ");
            sqlContent.Append(" AND KakuninKensa.IraiNendo = KensaDaichoDtlTbl.IraiNendo ");
            sqlContent.Append(" AND KakuninKensa.ShishoCd = KensaDaichoDtlTbl.ShishoCd ");
            sqlContent.Append(" AND KakuninKensa.SuishitsuKensaIraiNo = KensaDaichoDtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append(" AND KakuninKensa.ShikenkoumokuCd = KensaDaichoDtlTbl.ShikenkoumokuCd ");
            sqlContent.Append(" AND KakuninKensa.SaikensaKbn = '1' ");

            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho9joHdrTbl ");
            sqlContent.Append(" ON KensaDaichoDtlTbl.IraiNendo = KensaDaicho9joHdrTbl.IraiNendo ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.ShishoCd = KensaDaicho9joHdrTbl.ShishoCd ");
            sqlContent.Append(" AND KensaDaichoDtlTbl.SuishitsuKensaIraiNo = KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo ");

            sqlContent.Append(" LEFT OUTER JOIN KeiryoShomeiIraiTbl ON KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo = KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo ");
            sqlContent.Append(" AND KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd = KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append(" AND KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban = KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban ");

            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst ON KensaDaichoDtlTbl.ShikenkoumokuCd = SuishitsuShikenKoumokuMst.SuishitsuShikenKoumokuCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const1 ON const1.ConstKbn = '052' ");
            sqlContent.Append(" AND const1.ConstValue = KensaDaichoDtlTbl.KeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const2 ON const2.ConstKbn = '053' ");
            sqlContent.Append(" AND const2.ConstValue = KensaDaichoDtlTbl.KeiryoShomeiKekkaCd ");
            // 20150111 sou Start
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuKekkaNmMst kekkaNmMst ON kekkaNmMst.SuishitsuKekkaShishoCd = @kekkaShishoCd2 ");
            sqlContent.Append(" AND kekkaNmMst.SuishitsuKekkaNmCd = KensaDaichoDtlTbl.KeiryoShomeiKekkaCd ");
            commandParams.Add("@kekkaShishoCd2", SqlDbType.NVarChar).Value = (ShishoCd == "0" ? "3" : ShishoCd);
            // 20150111 sou End
            // 20150116 sou Start
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const11 ON const11.ConstKbn = '052' ");
            sqlContent.Append(" AND const11.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const12 ON const12.ConstKbn = '053' ");
            sqlContent.Append(" AND const12.ConstValue = KakuninKensa.KakuninKeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuKekkaNmMst kekkaNmMst2 ON kekkaNmMst2.SuishitsuKekkaShishoCd = @kekkaShishoCd ");
            sqlContent.Append(" AND kekkaNmMst2.SuishitsuKekkaNmCd = KakuninKensa.KakuninKeiryoShomeiKekkaCd ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ");
            sqlContent.Append(" ON SOTI.ConstValue = KensaDaichoDtlTbl.KakuninKensaSoti ");
            sqlContent.Append(" AND SOTI.ConstKbn = '061' ");
            // 20150116 sou End
            #endregion

            #region WHERE
            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // 検査区分
            sqlContent.Append("AND KensaDaichoDtlTbl.KensaKbn = '1'                                                                     ");

            // 支所コード
            sqlContent.Append("AND KensaDaichoDtlTbl.ShishoCd = @shishoCd2                                                              ");
            commandParams.Add("@shishoCd2", SqlDbType.NVarChar).Value = ShishoCd;

            // 再検査回数
            sqlContent.Append("AND KensaDaichoDtlTbl.SaikensaKbn = '0'                                                                  ");

            // ステータス区分
            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn = '50'                                                     ");

            // 20150121 sou Start
            //// 確認検査種別
            //sqlContent.Append("AND ((KensaDaichoDtlTbl.KensaShubetsuSsTr != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuBodTr != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuKako != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuEnkaIon != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuAnmonia != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuAnmoniaTn != '2') ");
            //sqlContent.Append("    AND (KensaDaichoDtlTbl.KensaShubetsuCodOver != '2')) ");
            // 確認検査種別
            sqlContent.Append("AND NOT( ");
            sqlContent.Append("       ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@ss, @tr)) AND (KensaDaichoDtlTbl.KensaShubetsuSsTr = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@bodA, @bodB, @tr)) AND (KensaDaichoDtlTbl.KensaShubetsuBodTr = '2')) ");
            sqlContent.Append("    OR (NOT (KensaDaichoDtlTbl.ShikenkoumokuCd in(@gaikan, @shuki, @no2n, @no3n)) AND (KensaDaichoDtlTbl.KensaShubetsuKako = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@cl)) AND (KensaDaichoDtlTbl.KensaShubetsuEnkaIon = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@nh4n)) AND (KensaDaichoDtlTbl.KensaShubetsuAnmonia = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@nh4n, @tnA, @tnB)) AND (KensaDaichoDtlTbl.KensaShubetsuAnmoniaTn = '2')) ");
            sqlContent.Append("    OR ((KensaDaichoDtlTbl.ShikenkoumokuCd in(@cod)) AND (KensaDaichoDtlTbl.KensaShubetsuCodOver = '2')) ");
            sqlContent.Append(" ) ");
            // 20150121 sou End

            // ・｛年度｝が空以外の場合
            // 20150116 sou Start
            //if (!string.IsNullOrEmpty(UketsukeDtFrom))
            //{
            //    sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt >= @UketsukeDtFrom2 ");
            //    commandParams.Add("@UketsukeDtFrom2", SqlDbType.NVarChar).Value = UketsukeDtFrom;
            //}
            //
            //if (!string.IsNullOrEmpty(UketsukeDtTo))
            //{
            //    sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt <= @UketsukeDtTo2 ");
            //    commandParams.Add("@UketsukeDtTo2", SqlDbType.NVarChar).Value = UketsukeDtTo;
            //}

            if (!string.IsNullOrEmpty(Nendo))
            {
                sqlContent.Append("AND KensaDaicho9joHdrTbl.IraiNendo = @Nendo2 ");
                commandParams.Add("@Nendo2", SqlDbType.NVarChar).Value = Nendo;
            }
            // 20150116 sou End

            // ・｛依頼受付日（開始）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtFrom))
            {
                sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt >= @IraiUketsukeDtFrom2 ");
                commandParams.Add("@IraiUketsukeDtFrom2", SqlDbType.NVarChar).Value = IraiUketsukeDtFrom;
            }

            // ・｛依頼受付日（終了）｝が空以外の場合
            if (!string.IsNullOrEmpty(IraiUketsukeDtTo))
            {
                sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt <= @IraiUketsukeDtTo2 ");
                commandParams.Add("@IraiUketsukeDtTo2", SqlDbType.NVarChar).Value = IraiUketsukeDtTo;
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
            sqlContent.Append("  orderIraiNendo ");
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

    #region KeiryoShomeiDaichoSearchTableAdapter
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
    /// 2014/12/05　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KeiryoShomeiDaichoSearchTableAdapter
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
        /// 2014/12/05　宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchDataTable GetDataBySearchCond(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchDataTable dataTable = new KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchDataTable();
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
        /// 2014/12/05　宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region SELECT

            sqlContent.Append("Select ");

            sqlContent.Append("KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban ");
            sqlContent.Append(", IraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd ");
            sqlContent.Append(", IraiTbl.KeiryoShomeiJokasoDaichoNendo ");
            sqlContent.Append(", IraiTbl.KeiryoShomeiJokasoDaichoRenban ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.IraiNendo ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.ShishoCd ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append(", IraiTbl.KeiryoShomeiSuisitsuCd ");
            sqlContent.Append(", IraiTbl.SuishitsuNm ");
            sqlContent.Append(", IraiTbl.KeiryoShomeiShoriHousikiKbn ");
            sqlContent.Append(", IraiTbl.KeiryoShomeiShoriHousikiCd ");
            sqlContent.Append(", IraiTbl.ShoriHoshikiShubetsuNm ");
            sqlContent.Append(", IraiTbl.ShoriHoshikiNm ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.KachoKeninKbn ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.HukuKachoKeninKbn ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.KeiryoKanrishaKeninKbn ");

            sqlContent.Append(", Ph1.KeiryoShomeiKekkaValue as Ph1KekkaValue ");
            sqlContent.Append(", Ph1.KeiryoShomeiKekkaOndo as Ph1KekkaOndo ");
            sqlContent.Append(", Ph1.KeiryoShomeiKekkaCd as Ph1KekkaCd ");
            sqlContent.Append(", Ph1.KensaShubetsu as Ph1KensaShubetsu ");
            sqlContent.Append(", Ph1.KeiryoShomeiSaiyoKbn as Ph1SaiyoKbn ");
            sqlContent.Append(", Ph1.KensaShubetsuKako as Ph1KensaShubetsuKako ");
            sqlContent.Append(", Ph1.KeiryoShomeiKekkaNyuryoku as Ph1KekkaNyuryoku ");
            sqlContent.Append(", Ph2.KeiryoShomeiKekkaValue as Ph2KekkaValue ");
            sqlContent.Append(", Ph2.KeiryoShomeiKekkaOndo as Ph2KekkaOndo ");
            sqlContent.Append(", Ph2.KeiryoShomeiKekkaCd as Ph2KekkaCd ");
            sqlContent.Append(", Ph2.KensaShubetsu as Ph2KensaShubetsu ");
            sqlContent.Append(", Ph2.KeiryoShomeiSaiyoKbn as Ph2SaiyoKbn ");
            sqlContent.Append(", Ph2.KensaShubetsuKako as Ph2KensaShubetsuKako ");
            sqlContent.Append(", Ph2.KeiryoShomeiKekkaNyuryoku as Ph2KekkaNyuryoku ");
            sqlContent.Append(", Ss1.KeiryoShomeiKekkaValue as Ss1KekkaValue ");
            sqlContent.Append(", Ss1.KeiryoShomeiKekkaCd as Ss1KekkaCd ");
            sqlContent.Append(", Ss1.KensaShubetsu as Ss1KensaShubetsu ");
            sqlContent.Append(", Ss1.KeiryoShomeiSaiyoKbn as Ss1SaiyoKbn ");
            sqlContent.Append(", Ss1.KensaShubetsuKako as Ss1KensaShubetsuKako ");
            sqlContent.Append(", Ss1.KeiryoShomeiKekkaNyuryoku as Ss1KekkaNyuryoku ");
            sqlContent.Append(", Ss2.KeiryoShomeiKekkaValue as Ss2KekkaValue ");
            sqlContent.Append(", Ss2.KeiryoShomeiKekkaCd as Ss2KekkaCd ");
            sqlContent.Append(", Ss2.KensaShubetsu as Ss2KensaShubetsu ");
            sqlContent.Append(", Ss2.KeiryoShomeiSaiyoKbn as Ss2SaiyoKbn ");
            sqlContent.Append(", Ss2.KensaShubetsuKako as Ss2KensaShubetsuKako ");
            sqlContent.Append(", Ss2.KeiryoShomeiKekkaNyuryoku as Ss2KekkaNyuryoku ");
            sqlContent.Append(", BodA1.KeiryoShomeiKekkaValue as BodA1KekkaValue ");
            sqlContent.Append(", BodA1.KeiryoShomeiKekkaCd as BodA1KekkaCd ");
            sqlContent.Append(", BodA1.KensaShubetsu as BodA1KensaShubetsu ");
            sqlContent.Append(", BodA1.KeiryoShomeiSaiyoKbn as BodA1SaiyoKbn ");
            sqlContent.Append(", BodA1.KensaShubetsuKako as BodA1KensaShubetsuKako ");
            sqlContent.Append(", BodA1.KeiryoShomeiKekkaNyuryoku as BodA1KekkaNyuryoku ");
            sqlContent.Append(", BodA2.KeiryoShomeiKekkaValue as BodA2KekkaValue ");
            sqlContent.Append(", BodA2.KeiryoShomeiKekkaCd as BodA2KekkaCd ");
            sqlContent.Append(", BodA2.KensaShubetsu as BodA2KensaShubetsu ");
            sqlContent.Append(", BodA2.KeiryoShomeiSaiyoKbn as BodA2SaiyoKbn ");
            sqlContent.Append(", BodA2.KensaShubetsuKako as BodA2KensaShubetsuKako ");
            sqlContent.Append(", BodA2.KeiryoShomeiKekkaNyuryoku as BodA2KekkaNyuryoku ");
            sqlContent.Append(", Nh4n1.KeiryoShomeiKekkaValue as Nh4n1KekkaValue ");
            sqlContent.Append(", Nh4n1.KeiryoShomeiKekkaCd as Nh4n1KekkaCd ");
            sqlContent.Append(", Nh4n1.KensaShubetsu as Nh4n1KensaShubetsu ");
            sqlContent.Append(", Nh4n1.KeiryoShomeiSaiyoKbn as Nh4n1SaiyoKbn ");
            sqlContent.Append(", Nh4n1.KensaShubetsuKako as Nh4n1KensaShubetsuKako ");
            sqlContent.Append(", Nh4n1.KeiryoShomeiKekkaNyuryoku as Nh4n1KekkaNyuryoku ");
            sqlContent.Append(", Nh4n2.KeiryoShomeiKekkaValue as Nh4n2KekkaValue ");
            sqlContent.Append(", Nh4n2.KeiryoShomeiKekkaCd as Nh4n2KekkaCd ");
            sqlContent.Append(", Nh4n2.KensaShubetsu as Nh4n2KensaShubetsu ");
            sqlContent.Append(", Nh4n2.KeiryoShomeiSaiyoKbn as Nh4n2SaiyoKbn ");
            sqlContent.Append(", Nh4n2.KensaShubetsuKako as Nh4n2KensaShubetsuKako ");
            sqlContent.Append(", Nh4n2.KeiryoShomeiKekkaNyuryoku as Nh4n2KekkaNyuryoku ");
            sqlContent.Append(", Cl1.KeiryoShomeiKekkaValue as Cl1KekkaValue ");
            sqlContent.Append(", Cl1.KeiryoShomeiKekkaCd as Cl1KekkaCd ");
            sqlContent.Append(", Cl1.KensaShubetsu as Cl1KensaShubetsu ");
            sqlContent.Append(", Cl1.KeiryoShomeiSaiyoKbn as Cl1SaiyoKbn ");
            sqlContent.Append(", Cl1.KensaShubetsuKako as Cl1KensaShubetsuKako ");
            sqlContent.Append(", Cl1.KeiryoShomeiKekkaNyuryoku as Cl1KekkaNyuryoku ");
            sqlContent.Append(", Cl2.KeiryoShomeiKekkaValue as Cl2KekkaValue ");
            sqlContent.Append(", Cl2.KeiryoShomeiKekkaCd as Cl2KekkaCd ");
            sqlContent.Append(", Cl2.KensaShubetsu as Cl2KensaShubetsu ");
            sqlContent.Append(", Cl2.KeiryoShomeiSaiyoKbn as Cl2SaiyoKbn ");
            sqlContent.Append(", Cl2.KensaShubetsuKako as Cl2KensaShubetsuKako ");
            sqlContent.Append(", Cl2.KeiryoShomeiKekkaNyuryoku as Cl2KekkaNyuryoku ");
            sqlContent.Append(", Cod1.KeiryoShomeiKekkaValue as Cod1KekkaValue ");
            sqlContent.Append(", Cod1.KeiryoShomeiKekkaCd as Cod1KekkaCd ");
            sqlContent.Append(", Cod1.KensaShubetsu as Cod1KensaShubetsu ");
            sqlContent.Append(", Cod1.KeiryoShomeiSaiyoKbn as Cod1SaiyoKbn ");
            sqlContent.Append(", Cod1.KensaShubetsuKako as Cod1KensaShubetsuKako ");
            sqlContent.Append(", Cod1.KeiryoShomeiKekkaNyuryoku as Cod1KekkaNyuryoku ");
            sqlContent.Append(", Cod2.KeiryoShomeiKekkaValue as Cod2KekkaValue ");
            sqlContent.Append(", Cod2.KeiryoShomeiKekkaCd as Cod2KekkaCd ");
            sqlContent.Append(", Cod2.KensaShubetsu as Cod2KensaShubetsu ");
            sqlContent.Append(", Cod2.KeiryoShomeiSaiyoKbn as Cod2SaiyoKbn ");
            sqlContent.Append(", Cod2.KensaShubetsuKako as Cod2KensaShubetsuKako ");
            sqlContent.Append(", Cod2.KeiryoShomeiKekkaNyuryoku as Cod2KekkaNyuryoku ");
            sqlContent.Append(", HekisanA1.KeiryoShomeiKekkaValue as HekisanA1KekkaValue ");
            sqlContent.Append(", HekisanA1.KeiryoShomeiKekkaCd as HekisanA1KekkaCd ");
            sqlContent.Append(", HekisanA1.KensaShubetsu as HekisanA1KensaShubetsu ");
            sqlContent.Append(", HekisanA1.KeiryoShomeiSaiyoKbn as HekisanA1SaiyoKbn ");
            sqlContent.Append(", HekisanA1.KensaShubetsuKako as HekisanA1KensaShubetsuKako ");
            sqlContent.Append(", HekisanA1.KeiryoShomeiKekkaNyuryoku as HekisanA1KekkaNyuryoku ");
            sqlContent.Append(", HekisanA2.KeiryoShomeiKekkaValue as HekisanA2KekkaValue ");
            sqlContent.Append(", HekisanA2.KeiryoShomeiKekkaCd as HekisanA2KekkaCd ");
            sqlContent.Append(", HekisanA2.KensaShubetsu as HekisanA2KensaShubetsu ");
            sqlContent.Append(", HekisanA2.KeiryoShomeiSaiyoKbn as HekisanA2SaiyoKbn ");
            sqlContent.Append(", HekisanA2.KensaShubetsuKako as HekisanA2KensaShubetsuKako ");
            sqlContent.Append(", HekisanA2.KeiryoShomeiKekkaNyuryoku as HekisanA2KekkaNyuryoku ");
            sqlContent.Append(", Mlss1.KeiryoShomeiKekkaValue as Mlss1KekkaValue ");
            sqlContent.Append(", Mlss1.KeiryoShomeiKekkaCd as Mlss1KekkaCd ");
            sqlContent.Append(", Mlss1.KensaShubetsu as Mlss1KensaShubetsu ");
            sqlContent.Append(", Mlss1.KeiryoShomeiSaiyoKbn as Mlss1SaiyoKbn ");
            sqlContent.Append(", Mlss1.KensaShubetsuKako as Mlss1KensaShubetsuKako ");
            sqlContent.Append(", Mlss1.KeiryoShomeiKekkaNyuryoku as Mlss1KekkaNyuryoku ");
            sqlContent.Append(", Mlss2.KeiryoShomeiKekkaValue as Mlss2KekkaValue ");
            sqlContent.Append(", Mlss2.KeiryoShomeiKekkaCd as Mlss2KekkaCd ");
            sqlContent.Append(", Mlss2.KensaShubetsu as Mlss2KensaShubetsu ");
            sqlContent.Append(", Mlss2.KeiryoShomeiSaiyoKbn as Mlss2SaiyoKbn ");
            sqlContent.Append(", Mlss2.KensaShubetsuKako as Mlss2KensaShubetsuKako ");
            sqlContent.Append(", Mlss2.KeiryoShomeiKekkaNyuryoku as Mlss2KekkaNyuryoku ");
            sqlContent.Append(", TnA1.KeiryoShomeiKekkaValue as TnA1KekkaValue ");
            sqlContent.Append(", TnA1.KeiryoShomeiKekkaCd as TnA1KekkaCd ");
            sqlContent.Append(", TnA1.KensaShubetsu as TnA1KensaShubetsu ");
            sqlContent.Append(", TnA1.KeiryoShomeiSaiyoKbn as TnA1SaiyoKbn ");
            sqlContent.Append(", TnA1.KensaShubetsuKako as TnA1KensaShubetsuKako ");
            sqlContent.Append(", TnA1.KeiryoShomeiKekkaNyuryoku as TnA1KekkaNyuryoku ");
            sqlContent.Append(", TnA2.KeiryoShomeiKekkaValue as TnA2KekkaValue ");
            sqlContent.Append(", TnA2.KeiryoShomeiKekkaCd as TnA2KekkaCd ");
            sqlContent.Append(", TnA2.KensaShubetsu as TnA2KensaShubetsu ");
            sqlContent.Append(", TnA2.KeiryoShomeiSaiyoKbn as TnA2SaiyoKbn ");
            sqlContent.Append(", TnA2.KensaShubetsuKako as TnA2KensaShubetsuKako ");
            sqlContent.Append(", TnA2.KeiryoShomeiKekkaNyuryoku as TnA2KekkaNyuryoku ");
            sqlContent.Append(", AbsA1.KeiryoShomeiKekkaValue as AbsA1KekkaValue ");
            sqlContent.Append(", AbsA1.KeiryoShomeiKekkaCd as AbsA1KekkaCd ");
            sqlContent.Append(", AbsA1.KensaShubetsu as AbsA1KensaShubetsu ");
            sqlContent.Append(", AbsA1.KeiryoShomeiSaiyoKbn as AbsA1SaiyoKbn ");
            sqlContent.Append(", AbsA1.KensaShubetsuKako as AbsA1KensaShubetsuKako ");
            sqlContent.Append(", AbsA1.KeiryoShomeiKekkaNyuryoku as AbsA1KekkaNyuryoku ");
            sqlContent.Append(", AbsA2.KeiryoShomeiKekkaValue as AbsA2KekkaValue ");
            sqlContent.Append(", AbsA2.KeiryoShomeiKekkaCd as AbsA2KekkaCd ");
            sqlContent.Append(", AbsA2.KensaShubetsu as AbsA2KensaShubetsu ");
            sqlContent.Append(", AbsA2.KeiryoShomeiSaiyoKbn as AbsA2SaiyoKbn ");
            sqlContent.Append(", AbsA2.KensaShubetsuKako as AbsA2KensaShubetsuKako ");
            sqlContent.Append(", AbsA2.KeiryoShomeiKekkaNyuryoku as AbsA2KekkaNyuryoku ");
            sqlContent.Append(", TpA1.KeiryoShomeiKekkaValue as TpA1KekkaValue ");
            sqlContent.Append(", TpA1.KeiryoShomeiKekkaCd as TpA1KekkaCd ");
            sqlContent.Append(", TpA1.KensaShubetsu as TpA1KensaShubetsu ");
            sqlContent.Append(", TpA1.KeiryoShomeiSaiyoKbn as TpA1SaiyoKbn ");
            sqlContent.Append(", TpA1.KensaShubetsuKako as TpA1KensaShubetsuKako ");
            sqlContent.Append(", TpA1.KeiryoShomeiKekkaNyuryoku as TpA1KekkaNyuryoku ");
            sqlContent.Append(", TpA2.KeiryoShomeiKekkaValue as TpA2KekkaValue ");
            sqlContent.Append(", TpA2.KeiryoShomeiKekkaCd as TpA2KekkaCd ");
            sqlContent.Append(", TpA2.KensaShubetsu as TpA2KensaShubetsu ");
            sqlContent.Append(", TpA2.KeiryoShomeiSaiyoKbn as TpA2SaiyoKbn ");
            sqlContent.Append(", TpA2.KensaShubetsuKako as TpA2KensaShubetsuKako ");
            sqlContent.Append(", TpA2.KeiryoShomeiKekkaNyuryoku as TpA2KekkaNyuryoku ");
            sqlContent.Append(", Rinsan1.KeiryoShomeiKekkaValue as Rinsan1KekkaValue ");
            sqlContent.Append(", Rinsan1.KeiryoShomeiKekkaCd as Rinsan1KekkaCd ");
            sqlContent.Append(", Rinsan1.KensaShubetsu as Rinsan1KensaShubetsu ");
            sqlContent.Append(", Rinsan1.KeiryoShomeiSaiyoKbn as Rinsan1SaiyoKbn ");
            sqlContent.Append(", Rinsan1.KensaShubetsuKako as Rinsan1KensaShubetsuKako ");
            sqlContent.Append(", Rinsan1.KeiryoShomeiKekkaNyuryoku as Rinsan1KekkaNyuryoku ");
            sqlContent.Append(", Rinsan2.KeiryoShomeiKekkaValue as Rinsan2KekkaValue ");
            sqlContent.Append(", Rinsan2.KeiryoShomeiKekkaCd as Rinsan2KekkaCd ");
            sqlContent.Append(", Rinsan2.KensaShubetsu as Rinsan2KensaShubetsu ");
            sqlContent.Append(", Rinsan2.KeiryoShomeiSaiyoKbn as Rinsan2SaiyoKbn ");
            sqlContent.Append(", Rinsan2.KensaShubetsuKako as Rinsan2KensaShubetsuKako ");
            sqlContent.Append(", Rinsan2.KeiryoShomeiKekkaNyuryoku as Rinsan2KekkaNyuryoku ");
            sqlContent.Append(", No2nTeiryo1.KeiryoShomeiKekkaValue as No2nTeiryo1KekkaValue ");
            sqlContent.Append(", No2nTeiryo1.KeiryoShomeiKekkaCd as No2nTeiryo1KekkaCd ");
            sqlContent.Append(", No2nTeiryo1.KensaShubetsu as No2nTeiryo1KensaShubetsu ");
            sqlContent.Append(", No2nTeiryo1.KeiryoShomeiSaiyoKbn as No2nTeiryo1SaiyoKbn ");
            sqlContent.Append(", No2nTeiryo1.KensaShubetsuKako as No2nTeiryo1KensaShubetsuKako ");
            sqlContent.Append(", No2nTeiryo1.KeiryoShomeiKekkaNyuryoku as No2nTeiryo1KekkaNyuryoku ");
            sqlContent.Append(", No2nTeiryo2.KeiryoShomeiKekkaValue as No2nTeiryo2KekkaValue ");
            sqlContent.Append(", No2nTeiryo2.KeiryoShomeiKekkaCd as No2nTeiryo2KekkaCd ");
            sqlContent.Append(", No2nTeiryo2.KensaShubetsu as No2nTeiryo2KensaShubetsu ");
            sqlContent.Append(", No2nTeiryo2.KeiryoShomeiSaiyoKbn as No2nTeiryo2SaiyoKbn ");
            sqlContent.Append(", No2nTeiryo2.KensaShubetsuKako as No2nTeiryo2KensaShubetsuKako ");
            sqlContent.Append(", No2nTeiryo2.KeiryoShomeiKekkaNyuryoku as No2nTeiryo2KekkaNyuryoku ");
            sqlContent.Append(", No3nTeiryo1.KeiryoShomeiKekkaValue as No3nTeiryo1KekkaValue ");
            sqlContent.Append(", No3nTeiryo1.KeiryoShomeiKekkaCd as No3nTeiryo1KekkaCd ");
            sqlContent.Append(", No3nTeiryo1.KensaShubetsu as No3nTeiryo1KensaShubetsu ");
            sqlContent.Append(", No3nTeiryo1.KeiryoShomeiSaiyoKbn as No3nTeiryo1SaiyoKbn ");
            sqlContent.Append(", No3nTeiryo1.KensaShubetsuKako as No3nTeiryo1KensaShubetsuKako ");
            sqlContent.Append(", No3nTeiryo1.KeiryoShomeiKekkaNyuryoku as No3nTeiryo1KekkaNyuryoku ");
            sqlContent.Append(", No3nTeiryo2.KeiryoShomeiKekkaValue as No3nTeiryo2KekkaValue ");
            sqlContent.Append(", No3nTeiryo2.KeiryoShomeiKekkaCd as No3nTeiryo2KekkaCd ");
            sqlContent.Append(", No3nTeiryo2.KensaShubetsu as No3nTeiryo2KensaShubetsu ");
            sqlContent.Append(", No3nTeiryo2.KeiryoShomeiSaiyoKbn as No3nTeiryo2SaiyoKbn ");
            sqlContent.Append(", No3nTeiryo2.KensaShubetsuKako as No3nTeiryo2KensaShubetsuKako ");
            sqlContent.Append(", No3nTeiryo2.KeiryoShomeiKekkaNyuryoku as No3nTeiryo2KekkaNyuryoku ");
            sqlContent.Append(", AbsB1.KeiryoShomeiKekkaValue as AbsB1KekkaValue ");
            sqlContent.Append(", AbsB1.KeiryoShomeiKekkaCd as AbsB1KekkaCd ");
            sqlContent.Append(", AbsB1.KensaShubetsu as AbsB1KensaShubetsu ");
            sqlContent.Append(", AbsB1.KeiryoShomeiSaiyoKbn as AbsB1SaiyoKbn ");
            sqlContent.Append(", AbsB1.KensaShubetsuKako as AbsB1KensaShubetsuKako ");
            sqlContent.Append(", AbsB1.KeiryoShomeiKekkaNyuryoku as AbsB1KekkaNyuryoku ");
            sqlContent.Append(", AbsB2.KeiryoShomeiKekkaValue as AbsB2KekkaValue ");
            sqlContent.Append(", AbsB2.KeiryoShomeiKekkaCd as AbsB2KekkaCd ");
            sqlContent.Append(", AbsB2.KensaShubetsu as AbsB2KensaShubetsu ");
            sqlContent.Append(", AbsB2.KeiryoShomeiSaiyoKbn as AbsB2SaiyoKbn ");
            sqlContent.Append(", AbsB2.KensaShubetsuKako as AbsB2KensaShubetsuKako ");
            sqlContent.Append(", AbsB2.KeiryoShomeiKekkaNyuryoku as AbsB2KekkaNyuryoku ");
            sqlContent.Append(", TnB1.KeiryoShomeiKekkaValue as TnB1KekkaValue ");
            sqlContent.Append(", TnB1.KeiryoShomeiKekkaCd as TnB1KekkaCd ");
            sqlContent.Append(", TnB1.KensaShubetsu as TnB1KensaShubetsu ");
            sqlContent.Append(", TnB1.KeiryoShomeiSaiyoKbn as TnB1SaiyoKbn ");
            sqlContent.Append(", TnB1.KensaShubetsuKako as TnB1KensaShubetsuKako ");
            sqlContent.Append(", TnB1.KeiryoShomeiKekkaNyuryoku as TnB1KekkaNyuryoku ");
            sqlContent.Append(", TnB2.KeiryoShomeiKekkaValue as TnB2KekkaValue ");
            sqlContent.Append(", TnB2.KeiryoShomeiKekkaCd as TnB2KekkaCd ");
            sqlContent.Append(", TnB2.KensaShubetsu as TnB2KensaShubetsu ");
            sqlContent.Append(", TnB2.KeiryoShomeiSaiyoKbn as TnB2SaiyoKbn ");
            sqlContent.Append(", TnB2.KensaShubetsuKako as TnB2KensaShubetsuKako ");
            sqlContent.Append(", TnB2.KeiryoShomeiKekkaNyuryoku as TnB2KekkaNyuryoku ");
            sqlContent.Append(", TpB1.KeiryoShomeiKekkaValue as TpB1KekkaValue ");
            sqlContent.Append(", TpB1.KeiryoShomeiKekkaCd as TpB1KekkaCd ");
            sqlContent.Append(", TpB1.KensaShubetsu as TpB1KensaShubetsu ");
            sqlContent.Append(", TpB1.KeiryoShomeiSaiyoKbn as TpB1SaiyoKbn ");
            sqlContent.Append(", TpB1.KensaShubetsuKako as TpB1KensaShubetsuKako ");
            sqlContent.Append(", TpB1.KeiryoShomeiKekkaNyuryoku as TpB1KekkaNyuryoku ");
            sqlContent.Append(", TpB2.KeiryoShomeiKekkaValue as TpB2KekkaValue ");
            sqlContent.Append(", TpB2.KeiryoShomeiKekkaCd as TpB2KekkaCd ");
            sqlContent.Append(", TpB2.KensaShubetsu as TpB2KensaShubetsu ");
            sqlContent.Append(", TpB2.KeiryoShomeiSaiyoKbn as TpB2SaiyoKbn ");
            sqlContent.Append(", TpB2.KensaShubetsuKako as TpB2KensaShubetsuKako ");
            sqlContent.Append(", TpB2.KeiryoShomeiKekkaNyuryoku as TpB2KekkaNyuryoku ");
            sqlContent.Append(", Shikido1.KeiryoShomeiKekkaValue as Shikido1KekkaValue ");
            sqlContent.Append(", Shikido1.KeiryoShomeiKekkaCd as Shikido1KekkaCd ");
            sqlContent.Append(", Shikido1.KensaShubetsu as Shikido1KensaShubetsu ");
            sqlContent.Append(", Shikido1.KeiryoShomeiSaiyoKbn as Shikido1SaiyoKbn ");
            sqlContent.Append(", Shikido1.KensaShubetsuKako as Shikido1KensaShubetsuKako ");
            sqlContent.Append(", Shikido1.KeiryoShomeiKekkaNyuryoku as Shikido1KekkaNyuryoku ");
            sqlContent.Append(", Shikido2.KeiryoShomeiKekkaValue as Shikido2KekkaValue ");
            sqlContent.Append(", Shikido2.KeiryoShomeiKekkaCd as Shikido2KekkaCd ");
            sqlContent.Append(", Shikido2.KensaShubetsu as Shikido2KensaShubetsu ");
            sqlContent.Append(", Shikido2.KeiryoShomeiSaiyoKbn as Shikido2SaiyoKbn ");
            sqlContent.Append(", Shikido2.KensaShubetsuKako as Shikido2KensaShubetsuKako ");
            sqlContent.Append(", Shikido2.KeiryoShomeiKekkaNyuryoku as Shikido2KekkaNyuryoku ");
            sqlContent.Append(", BodB1.KeiryoShomeiKekkaValue as BodB1KekkaValue ");
            sqlContent.Append(", BodB1.KeiryoShomeiKekkaCd as BodB1KekkaCd ");
            sqlContent.Append(", BodB1.KensaShubetsu as BodB1KensaShubetsu ");
            sqlContent.Append(", BodB1.KeiryoShomeiSaiyoKbn as BodB1SaiyoKbn ");
            sqlContent.Append(", BodB1.KensaShubetsuKako as BodB1KensaShubetsuKako ");
            sqlContent.Append(", BodB1.KeiryoShomeiKekkaNyuryoku as BodB1KekkaNyuryoku ");
            sqlContent.Append(", BodB2.KeiryoShomeiKekkaValue as BodB2KekkaValue ");
            sqlContent.Append(", BodB2.KeiryoShomeiKekkaCd as BodB2KekkaCd ");
            sqlContent.Append(", BodB2.KensaShubetsu as BodB2KensaShubetsu ");
            sqlContent.Append(", BodB2.KeiryoShomeiSaiyoKbn as BodB2SaiyoKbn ");
            sqlContent.Append(", BodB2.KensaShubetsuKako as BodB2KensaShubetsuKako ");
            sqlContent.Append(", BodB2.KeiryoShomeiKekkaNyuryoku as BodB2KekkaNyuryoku ");
            sqlContent.Append(", HekisanKoyu1.KeiryoShomeiKekkaValue as HekisanKoyu1KekkaValue ");
            sqlContent.Append(", HekisanKoyu1.KeiryoShomeiKekkaCd as HekisanKoyu1KekkaCd ");
            sqlContent.Append(", HekisanKoyu1.KensaShubetsu as HekisanKoyu1KensaShubetsu ");
            sqlContent.Append(", HekisanKoyu1.KeiryoShomeiSaiyoKbn as HekisanKoyu1SaiyoKbn ");
            sqlContent.Append(", HekisanKoyu1.KensaShubetsuKako as HekisanKoyu1KensaShubetsuKako ");
            sqlContent.Append(", HekisanKoyu1.KeiryoShomeiKekkaNyuryoku as HekisanKoyu1KekkaNyuryoku ");
            sqlContent.Append(", HekisanKoyu2.KeiryoShomeiKekkaValue as HekisanKoyu2KekkaValue ");
            sqlContent.Append(", HekisanKoyu2.KeiryoShomeiKekkaCd as HekisanKoyu2KekkaCd ");
            sqlContent.Append(", HekisanKoyu2.KensaShubetsu as HekisanKoyu2KensaShubetsu ");
            sqlContent.Append(", HekisanKoyu2.KeiryoShomeiSaiyoKbn as HekisanKoyu2SaiyoKbn ");
            sqlContent.Append(", HekisanKoyu2.KensaShubetsuKako as HekisanKoyu2KensaShubetsuKako ");
            sqlContent.Append(", HekisanKoyu2.KeiryoShomeiKekkaNyuryoku as HekisanKoyu2KekkaNyuryoku ");
            sqlContent.Append(", HekisanDoshoku1.KeiryoShomeiKekkaValue as HekisanDoshoku1KekkaValue ");
            sqlContent.Append(", HekisanDoshoku1.KeiryoShomeiKekkaCd as HekisanDoshoku1KekkaCd ");
            sqlContent.Append(", HekisanDoshoku1.KensaShubetsu as HekisanDoshoku1KensaShubetsu ");
            sqlContent.Append(", HekisanDoshoku1.KeiryoShomeiSaiyoKbn as HekisanDoshoku1SaiyoKbn ");
            sqlContent.Append(", HekisanDoshoku1.KensaShubetsuKako as HekisanDoshoku1KensaShubetsuKako ");
            sqlContent.Append(", HekisanDoshoku1.KeiryoShomeiKekkaNyuryoku as HekisanDoshoku1KekkaNyuryoku ");
            sqlContent.Append(", HekisanDoshoku2.KeiryoShomeiKekkaValue as HekisanDoshoku2KekkaValue ");
            sqlContent.Append(", HekisanDoshoku2.KeiryoShomeiKekkaCd as HekisanDoshoku2KekkaCd ");
            sqlContent.Append(", HekisanDoshoku2.KensaShubetsu as HekisanDoshoku2KensaShubetsu ");
            sqlContent.Append(", HekisanDoshoku2.KeiryoShomeiSaiyoKbn as HekisanDoshoku2SaiyoKbn ");
            sqlContent.Append(", HekisanDoshoku2.KensaShubetsuKako as HekisanDoshoku2KensaShubetsuKako ");
            sqlContent.Append(", HekisanDoshoku2.KeiryoShomeiKekkaNyuryoku as HekisanDoshoku2KekkaNyuryoku ");
            sqlContent.Append(", HekisanB1.KeiryoShomeiKekkaValue as HekisanB1KekkaValue ");
            sqlContent.Append(", HekisanB1.KeiryoShomeiKekkaCd as HekisanB1KekkaCd ");
            sqlContent.Append(", HekisanB1.KensaShubetsu as HekisanB1KensaShubetsu ");
            sqlContent.Append(", HekisanB1.KeiryoShomeiSaiyoKbn as HekisanB1SaiyoKbn ");
            sqlContent.Append(", HekisanB1.KensaShubetsuKako as HekisanB1KensaShubetsuKako ");
            sqlContent.Append(", HekisanB1.KeiryoShomeiKekkaNyuryoku as HekisanB1KekkaNyuryoku ");
            sqlContent.Append(", HekisanB2.KeiryoShomeiKekkaValue as HekisanB2KekkaValue ");
            sqlContent.Append(", HekisanB2.KeiryoShomeiKekkaCd as HekisanB2KekkaCd ");
            sqlContent.Append(", HekisanB2.KensaShubetsu as HekisanB2KensaShubetsu ");
            sqlContent.Append(", HekisanB2.KeiryoShomeiSaiyoKbn as HekisanB2SaiyoKbn ");
            sqlContent.Append(", HekisanB2.KensaShubetsuKako as HekisanB2KensaShubetsuKako ");
            sqlContent.Append(", HekisanB2.KeiryoShomeiKekkaNyuryoku as HekisanB2KekkaNyuryoku ");
            sqlContent.Append(", Namari1.KeiryoShomeiKekkaValue as Namari1KekkaValue ");
            sqlContent.Append(", Namari1.KeiryoShomeiKekkaCd as Namari1KekkaCd ");
            sqlContent.Append(", Namari1.KensaShubetsu as Namari1KensaShubetsu ");
            sqlContent.Append(", Namari1.KeiryoShomeiSaiyoKbn as Namari1SaiyoKbn ");
            sqlContent.Append(", Namari1.KensaShubetsuKako as Namari1KensaShubetsuKako ");
            sqlContent.Append(", Namari1.KeiryoShomeiKekkaNyuryoku as Namari1KekkaNyuryoku ");
            sqlContent.Append(", Namari2.KeiryoShomeiKekkaValue as Namari2KekkaValue ");
            sqlContent.Append(", Namari2.KeiryoShomeiKekkaCd as Namari2KekkaCd ");
            sqlContent.Append(", Namari2.KensaShubetsu as Namari2KensaShubetsu ");
            sqlContent.Append(", Namari2.KeiryoShomeiSaiyoKbn as Namari2SaiyoKbn ");
            sqlContent.Append(", Namari2.KensaShubetsuKako as Namari2KensaShubetsuKako ");
            sqlContent.Append(", Namari2.KeiryoShomeiKekkaNyuryoku as Namari2KekkaNyuryoku ");
            sqlContent.Append(", Aen1.KeiryoShomeiKekkaValue as Aen1KekkaValue ");
            sqlContent.Append(", Aen1.KeiryoShomeiKekkaCd as Aen1KekkaCd ");
            sqlContent.Append(", Aen1.KensaShubetsu as Aen1KensaShubetsu ");
            sqlContent.Append(", Aen1.KeiryoShomeiSaiyoKbn as Aen1SaiyoKbn ");
            sqlContent.Append(", Aen1.KensaShubetsuKako as Aen1KensaShubetsuKako ");
            sqlContent.Append(", Aen1.KeiryoShomeiKekkaNyuryoku as Aen1KekkaNyuryoku ");
            sqlContent.Append(", Aen2.KeiryoShomeiKekkaValue as Aen2KekkaValue ");
            sqlContent.Append(", Aen2.KeiryoShomeiKekkaCd as Aen2KekkaCd ");
            sqlContent.Append(", Aen2.KensaShubetsu as Aen2KensaShubetsu ");
            sqlContent.Append(", Aen2.KeiryoShomeiSaiyoKbn as Aen2SaiyoKbn ");
            sqlContent.Append(", Aen2.KensaShubetsuKako as Aen2KensaShubetsuKako ");
            sqlContent.Append(", Aen2.KeiryoShomeiKekkaNyuryoku as Aen2KekkaNyuryoku ");
            sqlContent.Append(", Houso1.KeiryoShomeiKekkaValue as Houso1KekkaValue ");
            sqlContent.Append(", Houso1.KeiryoShomeiKekkaCd as Houso1KekkaCd ");
            sqlContent.Append(", Houso1.KensaShubetsu as Houso1KensaShubetsu ");
            sqlContent.Append(", Houso1.KeiryoShomeiSaiyoKbn as Houso1SaiyoKbn ");
            sqlContent.Append(", Houso1.KensaShubetsuKako as Houso1KensaShubetsuKako ");
            sqlContent.Append(", Houso1.KeiryoShomeiKekkaNyuryoku as Houso1KekkaNyuryoku ");
            sqlContent.Append(", Houso2.KeiryoShomeiKekkaValue as Houso2KekkaValue ");
            sqlContent.Append(", Houso2.KeiryoShomeiKekkaCd as Houso2KekkaCd ");
            sqlContent.Append(", Houso2.KensaShubetsu as Houso2KensaShubetsu ");
            sqlContent.Append(", Houso2.KeiryoShomeiSaiyoKbn as Houso2SaiyoKbn ");
            sqlContent.Append(", Houso2.KensaShubetsuKako as Houso2KensaShubetsuKako ");
            sqlContent.Append(", Houso2.KeiryoShomeiKekkaNyuryoku as Houso2KekkaNyuryoku ");
            sqlContent.Append(", Zanen1.KeiryoShomeiKekkaValue as Zanen1KekkaValue ");
            sqlContent.Append(", Zanen1.KeiryoShomeiKekkaCd as Zanen1KekkaCd ");
            sqlContent.Append(", Zanen1.KensaShubetsu as Zanen1KensaShubetsu ");
            sqlContent.Append(", Zanen1.KeiryoShomeiSaiyoKbn as Zanen1SaiyoKbn ");
            sqlContent.Append(", Zanen1.KensaShubetsuKako as Zanen1KensaShubetsuKako ");
            sqlContent.Append(", Zanen1.KeiryoShomeiKekkaNyuryoku as Zanen1KekkaNyuryoku ");
            sqlContent.Append(", Zanen2.KeiryoShomeiKekkaValue as Zanen2KekkaValue ");
            sqlContent.Append(", Zanen2.KeiryoShomeiKekkaCd as Zanen2KekkaCd ");
            sqlContent.Append(", Zanen2.KensaShubetsu as Zanen2KensaShubetsu ");
            sqlContent.Append(", Zanen2.KeiryoShomeiSaiyoKbn as Zanen2SaiyoKbn ");
            sqlContent.Append(", Zanen2.KensaShubetsuKako as Zanen2KensaShubetsuKako ");
            sqlContent.Append(", Zanen2.KeiryoShomeiKekkaNyuryoku as Zanen2KekkaNyuryoku ");
            sqlContent.Append(", Gaikan1.KeiryoShomeiKekkaValue as Gaikan1KekkaValue ");
            sqlContent.Append(", Gaikan1.KeiryoShomeiKekkaCd as Gaikan1KekkaCd ");
            sqlContent.Append(", Gaikan1.KensaShubetsu as Gaikan1KensaShubetsu ");
            sqlContent.Append(", Gaikan1.KeiryoShomeiSaiyoKbn as Gaikan1SaiyoKbn ");
            sqlContent.Append(", Gaikan1.KensaShubetsuKako as Gaikan1KensaShubetsuKako ");
            sqlContent.Append(", Gaikan1.KeiryoShomeiKekkaNyuryoku as Gaikan1KekkaNyuryoku ");
            sqlContent.Append(", Gaikan2.KeiryoShomeiKekkaValue as Gaikan2KekkaValue ");
            sqlContent.Append(", Gaikan2.KeiryoShomeiKekkaCd as Gaikan2KekkaCd ");
            sqlContent.Append(", Gaikan2.KensaShubetsu as Gaikan2KensaShubetsu ");
            sqlContent.Append(", Gaikan2.KeiryoShomeiSaiyoKbn as Gaikan2SaiyoKbn ");
            sqlContent.Append(", Gaikan2.KensaShubetsuKako as Gaikan2KensaShubetsuKako ");
            sqlContent.Append(", Gaikan2.KeiryoShomeiKekkaNyuryoku as Gaikan2KekkaNyuryoku ");
            sqlContent.Append(", Shuki1.KeiryoShomeiKekkaValue as Shuki1KekkaValue ");
            sqlContent.Append(", Shuki1.KeiryoShomeiKekkaCd as Shuki1KekkaCd ");
            sqlContent.Append(", Shuki1.KensaShubetsu as Shuki1KensaShubetsu ");
            sqlContent.Append(", Shuki1.KeiryoShomeiSaiyoKbn as Shuki1SaiyoKbn ");
            sqlContent.Append(", Shuki1.KensaShubetsuKako as Shuki1KensaShubetsuKako ");
            sqlContent.Append(", Shuki1.KeiryoShomeiKekkaNyuryoku as Shuki1KekkaNyuryoku ");
            sqlContent.Append(", Shuki2.KeiryoShomeiKekkaValue as Shuki2KekkaValue ");
            sqlContent.Append(", Shuki2.KeiryoShomeiKekkaCd as Shuki2KekkaCd ");
            sqlContent.Append(", Shuki2.KensaShubetsu as Shuki2KensaShubetsu ");
            sqlContent.Append(", Shuki2.KeiryoShomeiSaiyoKbn as Shuki2SaiyoKbn ");
            sqlContent.Append(", Shuki2.KensaShubetsuKako as Shuki2KensaShubetsuKako ");
            sqlContent.Append(", Shuki2.KeiryoShomeiKekkaNyuryoku as Shuki2KekkaNyuryoku ");
            sqlContent.Append(", Tr1.KeiryoShomeiKekkaValue as Tr1KekkaValue ");
            sqlContent.Append(", Tr1.KeiryoShomeiKekkaCd as Tr1KekkaCd ");
            sqlContent.Append(", Tr1.KensaShubetsu as Tr1KensaShubetsu ");
            sqlContent.Append(", Tr1.KeiryoShomeiSaiyoKbn as Tr1SaiyoKbn ");
            sqlContent.Append(", Tr1.KensaShubetsuKako as Tr1KensaShubetsuKako ");
            sqlContent.Append(", Tr1.KeiryoShomeiKekkaNyuryoku as Tr1KekkaNyuryoku ");
            sqlContent.Append(", Tr2.KeiryoShomeiKekkaValue as Tr2KekkaValue ");
            sqlContent.Append(", Tr2.KeiryoShomeiKekkaCd as Tr2KekkaCd ");
            sqlContent.Append(", Tr2.KensaShubetsu as Tr2KensaShubetsu ");
            sqlContent.Append(", Tr2.KeiryoShomeiSaiyoKbn as Tr2SaiyoKbn ");
            sqlContent.Append(", Tr2.KensaShubetsuKako as Tr2KensaShubetsuKako ");
            sqlContent.Append(", Tr2.KeiryoShomeiKekkaNyuryoku as Tr2KekkaNyuryoku ");
            sqlContent.Append(", No2nTeisei1.KeiryoShomeiKekkaValue as No2nTeisei1KekkaValue ");
            sqlContent.Append(", No2nTeisei1.KeiryoShomeiKekkaCd as No2nTeisei1KekkaCd ");
            sqlContent.Append(", No2nTeisei1.KensaShubetsu as No2nTeisei1KensaShubetsu ");
            sqlContent.Append(", No2nTeisei1.KeiryoShomeiSaiyoKbn as No2nTeisei1SaiyoKbn ");
            sqlContent.Append(", No2nTeisei1.KensaShubetsuKako as No2nTeisei1KensaShubetsuKako ");
            sqlContent.Append(", No2nTeisei1.KeiryoShomeiKekkaNyuryoku as No2nTeisei1KekkaNyuryoku ");
            sqlContent.Append(", No2nTeisei2.KeiryoShomeiKekkaValue as No2nTeisei2KekkaValue ");
            sqlContent.Append(", No2nTeisei2.KeiryoShomeiKekkaCd as No2nTeisei2KekkaCd ");
            sqlContent.Append(", No2nTeisei2.KensaShubetsu as No2nTeisei2KensaShubetsu ");
            sqlContent.Append(", No2nTeisei2.KeiryoShomeiSaiyoKbn as No2nTeisei2SaiyoKbn ");
            sqlContent.Append(", No2nTeisei2.KensaShubetsuKako as No2nTeisei2KensaShubetsuKako ");
            sqlContent.Append(", No2nTeisei2.KeiryoShomeiKekkaNyuryoku as No2nTeisei2KekkaNyuryoku ");
            sqlContent.Append(", No3nTeisei1.KeiryoShomeiKekkaValue as No3nTeisei1KekkaValue ");
            sqlContent.Append(", No3nTeisei1.KeiryoShomeiKekkaCd as No3nTeisei1KekkaCd ");
            sqlContent.Append(", No3nTeisei1.KensaShubetsu as No3nTeisei1KensaShubetsu ");
            sqlContent.Append(", No3nTeisei1.KeiryoShomeiSaiyoKbn as No3nTeisei1SaiyoKbn ");
            sqlContent.Append(", No3nTeisei1.KensaShubetsuKako as No3nTeisei1KensaShubetsuKako ");
            sqlContent.Append(", No3nTeisei1.KeiryoShomeiKekkaNyuryoku as No3nTeisei1KekkaNyuryoku ");
            sqlContent.Append(", No3nTeisei2.KeiryoShomeiKekkaValue as No3nTeisei2KekkaValue ");
            sqlContent.Append(", No3nTeisei2.KeiryoShomeiKekkaCd as No3nTeisei2KekkaCd ");
            sqlContent.Append(", No3nTeisei2.KensaShubetsu as No3nTeisei2KensaShubetsu ");
            sqlContent.Append(", No3nTeisei2.KeiryoShomeiSaiyoKbn as No3nTeisei2SaiyoKbn ");
            sqlContent.Append(", No3nTeisei2.KensaShubetsuKako as No3nTeisei2KensaShubetsuKako ");
            sqlContent.Append(", No3nTeisei2.KeiryoShomeiKekkaNyuryoku as No3nTeisei2KekkaNyuryoku ");
            sqlContent.Append(", Daichokin1.KeiryoShomeiKekkaValue as Daichokin1KekkaValue ");
            sqlContent.Append(", Daichokin1.KeiryoShomeiKekkaCd as Daichokin1KekkaCd ");
            sqlContent.Append(", Daichokin1.KensaShubetsu as Daichokin1KensaShubetsu ");
            sqlContent.Append(", Daichokin1.KeiryoShomeiSaiyoKbn as Daichokin1SaiyoKbn ");
            sqlContent.Append(", Daichokin1.KensaShubetsuKako as Daichokin1KensaShubetsuKako ");
            sqlContent.Append(", Daichokin1.KeiryoShomeiKekkaNyuryoku as Daichokin1KekkaNyuryoku ");
            sqlContent.Append(", Daichokin2.KeiryoShomeiKekkaValue as Daichokin2KekkaValue ");
            sqlContent.Append(", Daichokin2.KeiryoShomeiKekkaCd as Daichokin2KekkaCd ");
            sqlContent.Append(", Daichokin2.KensaShubetsu as Daichokin2KensaShubetsu ");
            sqlContent.Append(", Daichokin2.KeiryoShomeiSaiyoKbn as Daichokin2SaiyoKbn ");
            sqlContent.Append(", Daichokin2.KensaShubetsuKako as Daichokin2KensaShubetsuKako ");
            sqlContent.Append(", Daichokin2.KeiryoShomeiKekkaNyuryoku as Daichokin2KekkaNyuryoku ");

            sqlContent.Append(", KensaDaicho9joHdrTbl.KensaKekkaKakuteiDt ");

            sqlContent.Append(", Ss1.KensaShubetsuSsTr as Ss1KensaShubetsuSsTr ");
            sqlContent.Append(", Ss2.KensaShubetsuSsTr as Ss2KensaShubetsuSsTr ");
            sqlContent.Append(", Tr1.KensaShubetsuSsTr as Tr1KensaShubetsuSsTr ");
            sqlContent.Append(", Tr2.KensaShubetsuSsTr as Tr2KensaShubetsuSsTr ");
            sqlContent.Append(", BodA1.KensaShubetsuBodTr as BodA1KensaShubetsuBodTr ");
            sqlContent.Append(", BodA2.KensaShubetsuBodTr as BodA2KensaShubetsuBodTr ");
            sqlContent.Append(", BodB1.KensaShubetsuBodTr as BodB1KensaShubetsuBodTr ");
            sqlContent.Append(", BodB2.KensaShubetsuBodTr as BodB2KensaShubetsuBodTr ");
            sqlContent.Append(", Tr1.KensaShubetsuBodTr as Tr1KensaShubetsuBodTr ");
            sqlContent.Append(", Tr2.KensaShubetsuBodTr as Tr2KensaShubetsuBodTr ");
            sqlContent.Append(", Cl1.KensaShubetsuEnkaIon as Cl1KensaShubetsuEnkaIon ");
            sqlContent.Append(", Cl2.KensaShubetsuEnkaIon as Cl2KensaShubetsuEnkaIon ");
            sqlContent.Append(", Nh4n1.KensaShubetsuAnmonia as Nh4n1KensaShubetsuAnmonia ");
            sqlContent.Append(", Nh4n2.KensaShubetsuAnmonia as Nh4n2KensaShubetsuAnmonia ");
            sqlContent.Append(", Nh4n1.KensaShubetsuAnmoniaTn as Nh4n1KensaShubetsuAnmoniaTn ");
            sqlContent.Append(", Nh4n2.KensaShubetsuAnmoniaTn as Nh4n2KensaShubetsuAnmoniaTn ");
            sqlContent.Append(", TnA1.KensaShubetsuAnmoniaTn as TnA1KensaShubetsuAnmoniaTn ");
            sqlContent.Append(", TnA2.KensaShubetsuAnmoniaTn as TnA2KensaShubetsuAnmoniaTn ");
            sqlContent.Append(", TnB1.KensaShubetsuAnmoniaTn as TnB1KensaShubetsuAnmoniaTn ");
            sqlContent.Append(", TnB2.KensaShubetsuAnmoniaTn as TnB2KensaShubetsuAnmoniaTn ");
            sqlContent.Append(", Cod1.KensaShubetsuCodOver as Cod1KensaShubetsuCodOver ");
            sqlContent.Append(", Cod2.KensaShubetsuCodOver as Cod2KensaShubetsuCodOver ");
            // 20150111 sou Start
            sqlContent.Append(", IraiTbl.KeiryoShomeiIraiUketsukeDt as UketsukeDt ");
            // 20150111 sou End

            #endregion

            #region FROM

            sqlContent.Append("From ");

            sqlContent.Append("KensaDaicho9joHdrTbl ");

            sqlContent.Append("Inner Join ");
            sqlContent.Append("( ");
            sqlContent.Append("	Select ");
            sqlContent.Append("		KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoNendo ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoRenban ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiSuisitsuCd ");
            sqlContent.Append("		, SuishitsuMst.SuishitsuNm ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiKbn ");
            sqlContent.Append("		, KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiCd ");
            sqlContent.Append("		, ShoriHoshikiMst.ShoriHoshikiShubetsuNm ");
            sqlContent.Append("		, ShoriHoshikiMst.ShoriHoshikiNm ");
            // 20150111 sou Start
            sqlContent.Append("     , KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt ");
            // 20150111 sou End
            sqlContent.Append("	From ");
            sqlContent.Append("		KeiryoShomeiIraiTbl ");
            sqlContent.Append("	Left Join SuishitsuMst ");
            sqlContent.Append("		On KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd = SuishitsuMst.SuishitsuShishoCd ");
            sqlContent.Append("		And KeiryoShomeiIraiTbl.KeiryoShomeiSuisitsuCd = SuishitsuMst.SuishitsuCd ");
            sqlContent.Append("	Left Join ShoriHoshikiMst ");
            sqlContent.Append("		On KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiKbn = ShoriHoshikiMst.ShoriHoshikiKbn ");
            sqlContent.Append("		And KeiryoShomeiIraiTbl.KeiryoShomeiShoriHousikiCd = ShoriHoshikiMst.ShoriHoshikiCd ");
            sqlContent.Append(") as IraiTbl ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.KeiryoShomeiIraiNendo = IraiTbl.KeiryoShomeiIraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.KeiryoShomeiIraiSishoCd = IraiTbl.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.KeiryoShomeiIraiRenban = IraiTbl.KeiryoShomeiIraiRenban ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ph1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Ph1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Ph1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Ph1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Ph1.KensaKbn ");
            sqlContent.Append("	And @kmkCdPh = Ph1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Ph1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ph2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Ph2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Ph2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Ph2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Ph2.KensaKbn ");
            sqlContent.Append("	And @kmkCdPh = Ph2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Ph2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ss1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Ss1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Ss1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Ss1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Ss1.KensaKbn ");
            sqlContent.Append("	And @kmkCdSs = Ss1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Ss1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ss2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Ss2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Ss2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Ss2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Ss2.KensaKbn ");
            sqlContent.Append("	And @kmkCdSs = Ss2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Ss2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodA1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = BodA1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = BodA1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = BodA1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = BodA1.KensaKbn ");
            sqlContent.Append("	And @kmkCdBodA = BodA1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = BodA1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodA2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = BodA2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = BodA2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = BodA2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = BodA2.KensaKbn ");
            sqlContent.Append("	And @kmkCdBodA = BodA2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = BodA2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Nh4n1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Nh4n1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Nh4n1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Nh4n1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Nh4n1.KensaKbn ");
            sqlContent.Append("	And @kmkCdNh4n = Nh4n1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Nh4n1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Nh4n2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Nh4n2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Nh4n2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Nh4n2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Nh4n2.KensaKbn ");
            sqlContent.Append("	And @kmkCdNh4n = Nh4n2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Nh4n2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cl1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Cl1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Cl1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Cl1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Cl1.KensaKbn ");
            sqlContent.Append("	And @kmkCdCl = Cl1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Cl1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cl2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Cl2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Cl2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Cl2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Cl2.KensaKbn ");
            sqlContent.Append("	And @kmkCdCl = Cl2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Cl2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cod1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Cod1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Cod1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Cod1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Cod1.KensaKbn ");
            sqlContent.Append("	And @kmkCdCod = Cod1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Cod1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cod2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Cod2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Cod2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Cod2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Cod2.KensaKbn ");
            sqlContent.Append("	And @kmkCdCod = Cod2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Cod2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanA1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanA1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanA1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanA1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanA1.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanA = HekisanA1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = HekisanA1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanA2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanA2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanA2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanA2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanA2.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanA = HekisanA2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = HekisanA2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Mlss1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Mlss1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Mlss1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Mlss1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Mlss1.KensaKbn ");
            sqlContent.Append("	And @kmkCdMlss = Mlss1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Mlss1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Mlss2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Mlss2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Mlss2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Mlss2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Mlss2.KensaKbn ");
            sqlContent.Append("	And @kmkCdMlss = Mlss2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Mlss2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnA1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TnA1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TnA1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TnA1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TnA1.KensaKbn ");
            sqlContent.Append("	And @kmkCdTnA = TnA1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = TnA1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnA2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TnA2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TnA2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TnA2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TnA2.KensaKbn ");
            sqlContent.Append("	And @kmkCdTnA = TnA2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = TnA2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsA1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = AbsA1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = AbsA1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = AbsA1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = AbsA1.KensaKbn ");
            sqlContent.Append("	And @kmkCdAbsA = AbsA1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = AbsA1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsA2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = AbsA2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = AbsA2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = AbsA2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = AbsA2.KensaKbn ");
            sqlContent.Append("	And @kmkCdAbsA = AbsA2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = AbsA2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpA1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TpA1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TpA1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TpA1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TpA1.KensaKbn ");
            sqlContent.Append("	And @kmkCdTpA = TpA1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = TpA1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpA2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TpA2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TpA2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TpA2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TpA2.KensaKbn ");
            sqlContent.Append("	And @kmkCdTpA = TpA2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = TpA2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Rinsan1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Rinsan1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Rinsan1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Rinsan1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Rinsan1.KensaKbn ");
            sqlContent.Append("	And @kmkCdRinsan = Rinsan1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Rinsan1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Rinsan2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Rinsan2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Rinsan2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Rinsan2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Rinsan2.KensaKbn ");
            sqlContent.Append("	And @kmkCdRinsan = Rinsan2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Rinsan2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeiryo1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No2nTeiryo1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No2nTeiryo1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No2nTeiryo1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No2nTeiryo1.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo2nTeiryo = No2nTeiryo1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = No2nTeiryo1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeiryo2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No2nTeiryo2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No2nTeiryo2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No2nTeiryo2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No2nTeiryo2.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo2nTeiryo = No2nTeiryo2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = No2nTeiryo2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeiryo1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No3nTeiryo1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No3nTeiryo1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No3nTeiryo1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No3nTeiryo1.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo3nTeiryo = No3nTeiryo1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = No3nTeiryo1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeiryo2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No3nTeiryo2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No3nTeiryo2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No3nTeiryo2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No3nTeiryo2.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo3nTeiryo = No3nTeiryo2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = No3nTeiryo2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsB1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = AbsB1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = AbsB1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = AbsB1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = AbsB1.KensaKbn ");
            sqlContent.Append("	And @kmkCdAbsB = AbsB1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = AbsB1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsB2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = AbsB2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = AbsB2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = AbsB2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = AbsB2.KensaKbn ");
            sqlContent.Append("	And @kmkCdAbsB = AbsB2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = AbsB2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnB1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TnB1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TnB1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TnB1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TnB1.KensaKbn ");
            sqlContent.Append("	And @kmkCdTnB = TnB1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = TnB1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnB2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TnB2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TnB2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TnB2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TnB2.KensaKbn ");
            sqlContent.Append("	And @kmkCdTnB = TnB2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = TnB2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpB1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TpB1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TpB1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TpB1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TpB1.KensaKbn ");
            sqlContent.Append("	And @kmkCdTpB = TpB1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = TpB1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpB2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = TpB2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = TpB2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = TpB2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = TpB2.KensaKbn ");
            sqlContent.Append("	And @kmkCdTpB = TpB2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = TpB2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shikido1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Shikido1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Shikido1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Shikido1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Shikido1.KensaKbn ");
            sqlContent.Append("	And @kmkCdShikido = Shikido1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Shikido1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shikido2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Shikido2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Shikido2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Shikido2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Shikido2.KensaKbn ");
            sqlContent.Append("	And @kmkCdShikido = Shikido2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Shikido2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodB1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = BodB1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = BodB1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = BodB1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = BodB1.KensaKbn ");
            sqlContent.Append("	And @kmkCdBodB = BodB1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = BodB1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodB2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = BodB2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = BodB2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = BodB2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = BodB2.KensaKbn ");
            sqlContent.Append("	And @kmkCdBodB = BodB2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = BodB2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanKoyu1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanKoyu1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanKoyu1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanKoyu1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanKoyu1.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanKoyu = HekisanKoyu1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = HekisanKoyu1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanKoyu2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanKoyu2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanKoyu2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanKoyu2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanKoyu2.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanKoyu = HekisanKoyu2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = HekisanKoyu2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanDoshoku1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanDoshoku1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanDoshoku1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanDoshoku1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanDoshoku1.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanDoshoku = HekisanDoshoku1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = HekisanDoshoku1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanDoshoku2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanDoshoku2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanDoshoku2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanDoshoku2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanDoshoku2.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanDoshoku = HekisanDoshoku2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = HekisanDoshoku2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanB1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanB1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanB1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanB1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanB1.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanB = HekisanB1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = HekisanB1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanB2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = HekisanB2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = HekisanB2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = HekisanB2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = HekisanB2.KensaKbn ");
            sqlContent.Append("	And @kmkCdHekisanB = HekisanB2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = HekisanB2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Namari1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Namari1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Namari1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Namari1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Namari1.KensaKbn ");
            sqlContent.Append("	And @kmkCdNamari = Namari1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Namari1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Namari2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Namari2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Namari2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Namari2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Namari2.KensaKbn ");
            sqlContent.Append("	And @kmkCdNamari = Namari2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Namari2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Aen1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Aen1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Aen1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Aen1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Aen1.KensaKbn ");
            sqlContent.Append("	And @kmkCdAen = Aen1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Aen1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Aen2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Aen2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Aen2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Aen2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Aen2.KensaKbn ");
            sqlContent.Append("	And @kmkCdAen = Aen2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Aen2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Houso1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Houso1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Houso1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Houso1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Houso1.KensaKbn ");
            sqlContent.Append("	And @kmkCdHouso = Houso1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Houso1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Houso2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Houso2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Houso2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Houso2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Houso2.KensaKbn ");
            sqlContent.Append("	And @kmkCdHouso = Houso2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Houso2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Zanen1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Zanen1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Zanen1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Zanen1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Zanen1.KensaKbn ");
            sqlContent.Append("	And @kmkCdZanen = Zanen1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Zanen1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Zanen2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Zanen2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Zanen2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Zanen2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Zanen2.KensaKbn ");
            sqlContent.Append("	And @kmkCdZanen = Zanen2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Zanen2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Gaikan1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Gaikan1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Gaikan1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Gaikan1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Gaikan1.KensaKbn ");
            sqlContent.Append("	And @kmkCdGaikan = Gaikan1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Gaikan1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Gaikan2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Gaikan2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Gaikan2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Gaikan2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Gaikan2.KensaKbn ");
            sqlContent.Append("	And @kmkCdGaikan = Gaikan2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Gaikan2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shuki1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Shuki1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Shuki1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Shuki1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Shuki1.KensaKbn ");
            sqlContent.Append("	And @kmkCdShuki = Shuki1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Shuki1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shuki2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Shuki2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Shuki2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Shuki2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Shuki2.KensaKbn ");
            sqlContent.Append("	And @kmkCdShuki = Shuki2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Shuki2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Tr1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Tr1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Tr1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Tr1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Tr1.KensaKbn ");
            sqlContent.Append("	And @kmkCdTr = Tr1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Tr1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Tr2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Tr2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Tr2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Tr2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Tr2.KensaKbn ");
            sqlContent.Append("	And @kmkCdTr = Tr2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Tr2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeisei1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No2nTeisei1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No2nTeisei1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No2nTeisei1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No2nTeisei1.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo2nTeisei = No2nTeisei1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = No2nTeisei1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeisei2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No2nTeisei2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No2nTeisei2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No2nTeisei2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No2nTeisei2.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo2nTeisei = No2nTeisei2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = No2nTeisei2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeisei1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No3nTeisei1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No3nTeisei1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No3nTeisei1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No3nTeisei1.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo3nTeisei = No3nTeisei1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = No3nTeisei1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeisei2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = No3nTeisei2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = No3nTeisei2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = No3nTeisei2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = No3nTeisei2.KensaKbn ");
            sqlContent.Append("	And @kmkCdNo3nTeisei = No3nTeisei2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = No3nTeisei2.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Daichokin1 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Daichokin1.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Daichokin1.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Daichokin1.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Daichokin1.KensaKbn ");
            sqlContent.Append("	And @kmkCdDaichokin = Daichokin1.ShikenkoumokuCd ");
            sqlContent.Append("	And '0' = Daichokin1.SaikensaKbn ");

            sqlContent.Append("Left Join KensaDaichoDtlTbl as Daichokin2 ");
            sqlContent.Append("	On KensaDaicho9joHdrTbl.IraiNendo = Daichokin2.IraiNendo ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.ShishoCd = Daichokin2.ShishoCd ");
            sqlContent.Append("	And KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo = Daichokin2.SuishitsuKensaIraiNo ");
            sqlContent.Append("	And '1' = Daichokin2.KensaKbn ");
            sqlContent.Append("	And @kmkCdDaichokin = Daichokin2.ShikenkoumokuCd ");
            sqlContent.Append("	And '1' = Daichokin2.SaikensaKbn ");

            commandParams.Add("@kmkCdPh", SqlDbType.NVarChar).Value = searchCond.KmkCdPh;
            commandParams.Add("@kmkCdSs", SqlDbType.NVarChar).Value = searchCond.KmkCdSs;
            commandParams.Add("@kmkCdBodA", SqlDbType.NVarChar).Value = searchCond.KmkCdBodA;
            commandParams.Add("@kmkCdNh4n", SqlDbType.NVarChar).Value = searchCond.KmkCdNh4n;
            commandParams.Add("@kmkCdCl", SqlDbType.NVarChar).Value = searchCond.KmkCdCl;
            commandParams.Add("@kmkCdCod", SqlDbType.NVarChar).Value = searchCond.KmkCdCod;
            commandParams.Add("@kmkCdHekisanA", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanA;
            commandParams.Add("@kmkCdMlss", SqlDbType.NVarChar).Value = searchCond.KmkCdMlss;
            commandParams.Add("@kmkCdTnA", SqlDbType.NVarChar).Value = searchCond.KmkCdTnA;
            commandParams.Add("@kmkCdAbsA", SqlDbType.NVarChar).Value = searchCond.KmkCdAbsA;
            commandParams.Add("@kmkCdTpA", SqlDbType.NVarChar).Value = searchCond.KmkCdTpA;
            commandParams.Add("@kmkCdRinsan", SqlDbType.NVarChar).Value = searchCond.KmkCdRinsan;
            commandParams.Add("@kmkCdNo2nTeiryo", SqlDbType.NVarChar).Value = searchCond.KmkCdNo2nTeiryo;
            commandParams.Add("@kmkCdNo3nTeiryo", SqlDbType.NVarChar).Value = searchCond.KmkCdNo3nTeiryo;
            commandParams.Add("@kmkCdAbsB", SqlDbType.NVarChar).Value = searchCond.KmkCdAbsB;
            commandParams.Add("@kmkCdTnB", SqlDbType.NVarChar).Value = searchCond.KmkCdTnB;
            commandParams.Add("@kmkCdTpB", SqlDbType.NVarChar).Value = searchCond.KmkCdTpB;
            commandParams.Add("@kmkCdShikido", SqlDbType.NVarChar).Value = searchCond.KmkCdShikido;
            commandParams.Add("@kmkCdBodB", SqlDbType.NVarChar).Value = searchCond.KmkCdBodB;
            commandParams.Add("@kmkCdHekisanKoyu", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanKoyu;
            commandParams.Add("@kmkCdHekisanDoshoku", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanDoshoku;
            commandParams.Add("@kmkCdHekisanB", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanB;
            commandParams.Add("@kmkCdNamari", SqlDbType.NVarChar).Value = searchCond.KmkCdNamari;
            commandParams.Add("@kmkCdAen", SqlDbType.NVarChar).Value = searchCond.KmkCdAen;
            commandParams.Add("@kmkCdHouso", SqlDbType.NVarChar).Value = searchCond.KmkCdHouso;
            commandParams.Add("@kmkCdZanen", SqlDbType.NVarChar).Value = searchCond.KmkCdZanen;
            commandParams.Add("@kmkCdGaikan", SqlDbType.NVarChar).Value = searchCond.KmkCdGaikan;
            commandParams.Add("@kmkCdShuki", SqlDbType.NVarChar).Value = searchCond.KmkCdShuki;
            commandParams.Add("@kmkCdTr", SqlDbType.NVarChar).Value = searchCond.KmkCdTr;
            commandParams.Add("@kmkCdNo2nTeisei", SqlDbType.NVarChar).Value = searchCond.KmkCdNo2nTeisei;
            commandParams.Add("@kmkCdNo3nTeisei", SqlDbType.NVarChar).Value = searchCond.KmkCdNo3nTeisei;
            commandParams.Add("@kmkCdDaichokin", SqlDbType.NVarChar).Value = searchCond.KmkCdDaichokin;

            #endregion

            #region WHERE(定型)

            sqlContent.Append("Where ");

            sqlContent.Append("KensaDaicho9joHdrTbl.ShishoCd = @LoginShishoCd ");
            sqlContent.Append("And (KensaDaicho9joHdrTbl.KachoKeninKbn = '0' ");
            sqlContent.Append("Or KensaDaicho9joHdrTbl.HukuKachoKeninKbn = '0' ");
            sqlContent.Append("Or KensaDaicho9joHdrTbl.KeiryoKanrishaKeninKbn = '0') ");

            commandParams.Add("@LoginShishoCd", SqlDbType.NVarChar).Value = searchCond.ShishoCd;

            #endregion

            #region WHERE(動的)

            // 年度
            if (!string.IsNullOrEmpty(searchCond.Nendo))
            {
                sqlContent.Append("AND KensaDaicho9joHdrTbl.IraiNendo = @IraiNendo ");
                commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = searchCond.Nendo;
            }

            // 依頼受付日入力区分の有無
            if (searchCond.IraiUketsukeDtInputKbn == "1")
            {
                // 依頼受付日(開始)
                sqlContent.Append("AND KensaDaicho9joHdrTbl.KensaIraiUketsukeDt >= @IraiUketsukeFromDt ");
                commandParams.Add("@IraiUketsukeFromDt", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeFromDt;
                // 依頼受付日(開始)
                sqlContent.Append("AND KensaDaicho9joHdrTbl.KensaIraiUketsukeDt <= @IraiUketsukeToDt ");
                commandParams.Add("@IraiUketsukeToDt", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeToDt;
            }

            // 依頼No(開始)
            if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
            {
                sqlContent.Append("AND KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo >= @IraiNoFrom ");
                commandParams.Add("@IraiNoFrom", SqlDbType.NVarChar).Value = searchCond.IraiNoFrom;
            }

            // 依頼No(終了)
            if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
            {
                sqlContent.Append("AND KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo <= @IraiNoTo ");
                commandParams.Add("@IraiNoTo", SqlDbType.NVarChar).Value = searchCond.IraiNoTo;
            }

            #endregion

            #region ORDER BY

            sqlContent.Append("Order By ");

            sqlContent.Append("KensaDaicho9joHdrTbl.IraiNendo ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.ShishoCd ");
            sqlContent.Append(", KensaDaicho9joHdrTbl.SuishitsuKensaIraiNo ");

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region Jo9KakuninKensaJisshiKirokuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Jo9KakuninKensaJisshiKirokuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HuyTX         新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class Jo9KakuninKensaJisshiKirokuTableAdapter
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
        /// 2014/12/05　HuyTX      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho9joHdrTblDataSet.Jo9KakuninKensaJisshiKirokuDataTable GetDataBySearchCond(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho9joHdrTblDataSet.Jo9KakuninKensaJisshiKirokuDataTable dataTable = new KensaDaicho9joHdrTblDataSet.Jo9KakuninKensaJisshiKirokuDataTable();
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
        /// 2014/12/05　HuyTX      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // 20150112 sou Start
            #region UNION SELECT
            sqlContent.Append(" SELECT ");
            sqlContent.Append(" KensaKbn, ");
            sqlContent.Append(" IraiNendo, ");
            sqlContent.Append(" ShishoCd, ");
            sqlContent.Append(" SuishitsuKensaIraiNo, ");
            sqlContent.Append(" ShikenkoumokuCd, ");
            sqlContent.Append(" SeishikiNm, ");
            sqlContent.Append(" OldKekkaValue, ");
            sqlContent.Append(" OldKekkaOndo, ");
            sqlContent.Append(" OldKekkaNm, ");
            sqlContent.Append(" OldSaiyoKbn, ");
            sqlContent.Append(" NewKekkaValue, ");
            sqlContent.Append(" NewKekkaOndo, ");
            sqlContent.Append(" NewKekkaNm, ");
            sqlContent.Append(" NewSaiyoKbn, ");
            sqlContent.Append(" SotiNm, ");
            sqlContent.Append(" KachoKeninKbn, ");
            sqlContent.Append(" HukuKachoKeninKbn, ");
            sqlContent.Append(" KeiryoKanrishaKeninKbn, ");
            sqlContent.Append(" YachoKinyuKakuninKbn ");
            #endregion

            sqlContent.Append(" FROM ");
            sqlContent.Append(" ( ");
            // 20150112 sou End

            #region SELECT

            sqlContent.Append(" SELECT ");
            sqlContent.Append(" 		OLDRESULT.KensaKbn, ");
            sqlContent.Append(" 		OLDRESULT.IraiNendo, ");
            sqlContent.Append(" 		OLDRESULT.ShishoCd, ");
            sqlContent.Append(" 		OLDRESULT.SuishitsuKensaIraiNo, ");
            sqlContent.Append(" 		OLDRESULT.ShikenkoumokuCd, ");
            sqlContent.Append(" 		sskm.SeishikiNm, ");
            sqlContent.Append(" 		OLDRESULT.KeiryoShomeiKekkaValue AS OldKekkaValue, ");
            sqlContent.Append(" 		OLDRESULT.KeiryoShomeiKekkaOndo AS OldKekkaOndo, ");
            //sqlContent.Append(" 		OLDRESULTNM.ConstNm AS OldKekkaNm, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         ELSE OLDRESULTNM.ConstNm ");
            sqlContent.Append("         END AS OldKekkaNm, ");

            sqlContent.Append(" 		OLDRESULT.KeiryoShomeiSaiyoKbn AS OldSaiyoKbn, ");
            sqlContent.Append(" 		NEWRESULT.KeiryoShomeiKekkaValue AS NewKekkaValue, ");
            sqlContent.Append(" 		NEWRESULT.KeiryoShomeiKekkaOndo AS NewKekkaOndo, ");
            //sqlContent.Append(" 		NEWRESULTNM.ConstNm AS NewKekkaNm, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         ELSE NEWRESULTNM.ConstNm ");
            sqlContent.Append("         END AS NewKekkaNm, ");

            sqlContent.Append(" 		NEWRESULT.KeiryoShomeiSaiyoKbn AS NewSaiyoKbn, ");
            sqlContent.Append(" 		SOTI.ConstNm AS SotiNm, ");
            sqlContent.Append(" 		OLDRESULT.KachoKeninKbn, ");
            sqlContent.Append(" 		OLDRESULT.HukuKachoKeninKbn, ");
            sqlContent.Append(" 		OLDRESULT.KeiryoKanrishaKeninKbn, ");
            sqlContent.Append(" 		OLDRESULT.YachoKinyuKakuninKbn ");

            #endregion

            #region FROM

            sqlContent.Append(" FROM KensaDaichoDtlTbl OLDRESULT ");
            sqlContent.Append(" LEFT OUTER JOIN KensaDaichoDtlTbl NEWRESULT ON 	NEWRESULT.KensaKbn = OLDRESULT.KensaKbn ");
            sqlContent.Append(" 											AND NEWRESULT.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append(" 											AND NEWRESULT.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append(" 											AND NEWRESULT.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append(" 											AND NEWRESULT.ShikenkoumokuCd = OLDRESULT.ShikenkoumokuCd  ");
            sqlContent.Append(" 	                                        AND NEWRESULT.SaikensaKbn = '1' ");
            // 20141219 sou Start
            //sqlContent.Append(" LEFT OUTER JOIN ConstMst OLDRESULTNM ON  OLDRESULTNM.ConstValue = OLDRESULT.KeiryoShomeiKekkaValue2 ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst OLDRESULTNM ON  OLDRESULTNM.ConstValue = OLDRESULT.KeiryoShomeiKekkaCd ");
            // 20141219 sou End
            sqlContent.Append("                                     AND (OLDRESULTNM.ConstKbn = '052' OR OLDRESULTNM.ConstKbn = '053') ");
            // 20141219 sou Start
            //sqlContent.Append(" LEFT OUTER JOIN ConstMst NEWRESULTNM ON NEWRESULTNM.ConstValue = NEWRESULT.KeiryoShomeiKekkaValue2 ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst NEWRESULTNM ON NEWRESULTNM.ConstValue = NEWRESULT.KeiryoShomeiKekkaCd ");
            // 20141219 sou End
            sqlContent.Append(" 	                                AND (NEWRESULTNM.ConstKbn = '052' OR NEWRESULTNM.ConstKbn = '053') ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ON SOTI.ConstValue = OLDRESULT.KakuninKensaSoti ");
            sqlContent.Append(" 	                                AND SOTI.ConstKbn = '061' ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst sskm ON sskm.SuishitsuShikenKoumokuCd = OLDRESULT.ShikenkoumokuCd ");
            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho9joHdrTbl kd9ht ON kd9ht.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append(" 											AND kd9ht.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append(" 											AND kd9ht.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append(" LEFT OUTER JOIN KeiryoShomeiIraiTbl ksit ON ksit.KeiryoShomeiIraiNendo = kd9ht.KeiryoShomeiIraiNendo ");
            sqlContent.Append(" 										AND ksit.KeiryoShomeiIraiSishoCd = kd9ht.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append(" 										AND ksit.KeiryoShomeiIraiRenban = kd9ht.KeiryoShomeiIraiRenban ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuKekkaNmMst kekkaNmMst ON  kekkaNmMst.SuishitsuKekkaShishoCd = @kekkaShishoCd ");
            sqlContent.Append("                                                AND kekkaNmMst.SuishitsuKekkaNmCd = OLDRESULT.KeiryoShomeiKekkaCd ");
            commandParams.Add("@kekkaShishoCd", SqlDbType.NVarChar).Value = (searchCond.ShishoCd == "0" ? "3" : searchCond.ShishoCd);
            #endregion

            #region WHERE

            sqlContent.Append(" WHERE OLDRESULT.KensaKbn = '1' ");
            sqlContent.Append(" 	AND OLDRESULT.SaikensaKbn = '0' ");
            sqlContent.Append(" 	AND ksit.KeiryoShomeiStatusKbn = '50' ");
            // 20150112 sou Start
            //sqlContent.Append(" 	AND(OLDRESULT.KensaShubetsuSsTr = '1' ");
            //sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuBodTr = '1' ");
            //sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuKako = '1' ");
            //sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuEnkaIon = '1' ");
            //sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuAnmonia = '1' ");
            //sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuAnmoniaTn = '1' ");
            //sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuCodOver = '1') ");
            sqlContent.Append(" 	AND(OLDRESULT.KensaShubetsuSsTr = '2' ");
            sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuBodTr = '2' ");
            sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuKako = '2' ");
            sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuEnkaIon = '2' ");
            sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuAnmonia = '2' ");
            sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuAnmoniaTn = '2' ");
            sqlContent.Append(" 		OR OLDRESULT.KensaShubetsuCodOver = '2') ");

            // 支所コード
            sqlContent.Append("AND OLDRESULT.ShishoCd = @shishoCd1 ");
            commandParams.Add("@shishoCd1", SqlDbType.NVarChar).Value = searchCond.ShishoCd;
            // 20150112 sou End

            //年度
            if (!string.IsNullOrEmpty(searchCond.Nendo))
            {
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt >= @iraiUketsukeNendoDtFrom1");
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt <= @iraiUketsukeNendoDtTo1");

                commandParams.Add("@iraiUketsukeNendoDtFrom1", SqlDbType.NVarChar).Value = searchCond.Nendo + "0401";
                commandParams.Add("@iraiUketsukeNendoDtTo1", SqlDbType.NVarChar).Value = (Int32.Parse(searchCond.Nendo) + 1) + "0331";
            }

            //依頼受付日（開始）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeFromDt))
            {
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt >= @iraiUketsukeDtFrom1");
                commandParams.Add("@iraiUketsukeDtFrom1", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeFromDt;
            }

            //依頼受付日（終了）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeToDt))
            {
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt <= @iraiUketsukeDtTo1");
                commandParams.Add("@iraiUketsukeDtTo1", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeToDt;
            }

            //依頼No（開始）
            if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
            {
                // 20141219 sou Start
                //sqlContent.Append(" AND ksit.KeiryoShomeiIraiRenban >= @iraiNoFrom");
                sqlContent.Append(" AND OLDRESULT.SuishitsuKensaIraiNo >= @iraiNoFrom1");
                // 20141219 sou End
                commandParams.Add("@iraiNoFrom1", SqlDbType.NVarChar).Value = searchCond.IraiNoFrom;
            }

            //依頼No（終了）
            if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
            {
                // 20141219 sou Start
                //sqlContent.Append(" AND ksit.KeiryoShomeiIraiRenban <= @iraiNoTo");
                sqlContent.Append(" AND OLDRESULT.SuishitsuKensaIraiNo <= @iraiNoTo1");
                // 20141219 sou End
                commandParams.Add("@iraiNoTo1", SqlDbType.NVarChar).Value = searchCond.IraiNoTo;
            }

            #endregion

            // 20150112 sou Start
            #region ORDER BY

            //sqlContent.Append(" ORDER BY OLDRESULT.IraiNendo, ");
            //sqlContent.Append(" 		OLDRESULT.ShishoCd, ");
            //sqlContent.Append(" 		OLDRESULT.SuishitsuKensaIraiNo, ");
            //sqlContent.Append(" 		OLDRESULT.ShikenkoumokuCd ");

            #endregion

            sqlContent.Append(" UNION ");

            #region SELECT

            sqlContent.Append(" SELECT ");
            sqlContent.Append(" 		OLDRESULT.KensaKbn, ");
            sqlContent.Append(" 		OLDRESULT.IraiNendo, ");
            sqlContent.Append(" 		OLDRESULT.ShishoCd, ");
            sqlContent.Append(" 		OLDRESULT.SuishitsuKensaIraiNo, ");
            sqlContent.Append(" 		OLDRESULT.ShikenkoumokuCd, ");
            sqlContent.Append(" 		sskm.SeishikiNm, ");
            sqlContent.Append(" 		OLDRESULT.KeiryoShomeiKekkaValue AS OldKekkaValue, ");
            sqlContent.Append(" 		OLDRESULT.KeiryoShomeiKekkaOndo AS OldKekkaOndo, ");
            //sqlContent.Append(" 		OLDRESULTNM.ConstNm AS OldKekkaNm, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         ELSE OLDRESULTNM.ConstNm ");
            sqlContent.Append("         END OldKekkaNm, ");

            sqlContent.Append(" 		OLDRESULT.KeiryoShomeiSaiyoKbn AS OldSaiyoKbn, ");
            sqlContent.Append(" 		NEWRESULT.KeiryoShomeiKekkaValue AS NewKekkaValue, ");
            sqlContent.Append(" 		NEWRESULT.KeiryoShomeiKekkaOndo AS NewKekkaOndo, ");
            //sqlContent.Append(" 		NEWRESULTNM.ConstNm AS NewKekkaNm, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '027') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         WHEN OLDRESULT.ShikenkoumokuCd = (SELECT ConstValue FROM ConstMst WHERE ConstKbn = '049' AND ConstRenban = '028') ");
            sqlContent.Append("             THEN kekkaNmMst.SuishitsuKekkaNm                                                            ");
            sqlContent.Append("         ELSE NEWRESULTNM.ConstNm ");
            sqlContent.Append("         END NewKekkaNm, ");

            sqlContent.Append(" 		NEWRESULT.KeiryoShomeiSaiyoKbn AS NewSaiyoKbn, ");
            sqlContent.Append(" 		SOTI.ConstNm AS SotiNm, ");
            sqlContent.Append(" 		OLDRESULT.KachoKeninKbn, ");
            sqlContent.Append(" 		OLDRESULT.HukuKachoKeninKbn, ");
            sqlContent.Append(" 		OLDRESULT.KeiryoKanrishaKeninKbn, ");
            sqlContent.Append(" 		OLDRESULT.YachoKinyuKakuninKbn ");

            #endregion

            #region FROM

            sqlContent.Append(" FROM KensaDaichoDtlTbl OLDRESULT ");
            sqlContent.Append(" INNER JOIN KensaDaichoDtlTbl NEWRESULT ON  NEWRESULT.KensaKbn = OLDRESULT.KensaKbn ");
            sqlContent.Append(" 									   AND NEWRESULT.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append(" 									   AND NEWRESULT.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append(" 									   AND NEWRESULT.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append(" 									   AND NEWRESULT.ShikenkoumokuCd = OLDRESULT.ShikenkoumokuCd  ");
            sqlContent.Append(" 	                                   AND NEWRESULT.SaikensaKbn = '1' ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst OLDRESULTNM ON  OLDRESULTNM.ConstValue = OLDRESULT.KeiryoShomeiKekkaCd ");
            sqlContent.Append("                                     AND (OLDRESULTNM.ConstKbn = '052' OR OLDRESULTNM.ConstKbn = '053') ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst NEWRESULTNM ON NEWRESULTNM.ConstValue = NEWRESULT.KeiryoShomeiKekkaCd ");
            sqlContent.Append(" 	                                AND (NEWRESULTNM.ConstKbn = '052' OR NEWRESULTNM.ConstKbn = '053') ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst SOTI ON SOTI.ConstValue = OLDRESULT.KakuninKensaSoti ");
            sqlContent.Append(" 	                                AND SOTI.ConstKbn = '061' ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuShikenKoumokuMst sskm ON sskm.SuishitsuShikenKoumokuCd = OLDRESULT.ShikenkoumokuCd ");
            sqlContent.Append(" LEFT OUTER JOIN KensaDaicho9joHdrTbl kd9ht ON kd9ht.IraiNendo = OLDRESULT.IraiNendo ");
            sqlContent.Append(" 											AND kd9ht.ShishoCd = OLDRESULT.ShishoCd ");
            sqlContent.Append(" 											AND kd9ht.SuishitsuKensaIraiNo = OLDRESULT.SuishitsuKensaIraiNo ");
            sqlContent.Append(" LEFT OUTER JOIN KeiryoShomeiIraiTbl ksit ON ksit.KeiryoShomeiIraiNendo = kd9ht.KeiryoShomeiIraiNendo ");
            sqlContent.Append(" 										AND ksit.KeiryoShomeiIraiSishoCd = kd9ht.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append(" 										AND ksit.KeiryoShomeiIraiRenban = kd9ht.KeiryoShomeiIraiRenban ");
            sqlContent.Append(" LEFT OUTER JOIN SuishitsuKekkaNmMst kekkaNmMst ON  kekkaNmMst.SuishitsuKekkaShishoCd = @kekkaShishoCd2 ");
            sqlContent.Append("                                                AND kekkaNmMst.SuishitsuKekkaNmCd = OLDRESULT.KeiryoShomeiKekkaCd ");
            commandParams.Add("@kekkaShishoCd2", SqlDbType.NVarChar).Value = (searchCond.ShishoCd == "0" ? "3" : searchCond.ShishoCd);

            #endregion

            #region WHERE

            sqlContent.Append(" WHERE OLDRESULT.KensaKbn = '1' ");
            sqlContent.Append(" 	AND OLDRESULT.SaikensaKbn = '0' ");
            sqlContent.Append(" 	AND ksit.KeiryoShomeiStatusKbn = '50' ");
            sqlContent.Append(" 	AND(OLDRESULT.KensaShubetsuSsTr != '2' ");
            sqlContent.Append(" 	AND OLDRESULT.KensaShubetsuBodTr != '2' ");
            sqlContent.Append(" 	AND OLDRESULT.KensaShubetsuKako != '2' ");
            sqlContent.Append(" 	AND OLDRESULT.KensaShubetsuEnkaIon != '2' ");
            sqlContent.Append(" 	AND OLDRESULT.KensaShubetsuAnmonia != '2' ");
            sqlContent.Append(" 	AND OLDRESULT.KensaShubetsuAnmoniaTn != '2' ");
            sqlContent.Append(" 	AND OLDRESULT.KensaShubetsuCodOver != '2') ");

            // 支所コード
            sqlContent.Append("AND OLDRESULT.ShishoCd = @shishoCd2 ");
            commandParams.Add("@shishoCd2", SqlDbType.NVarChar).Value = searchCond.ShishoCd;

            //年度
            if (!string.IsNullOrEmpty(searchCond.Nendo))
            {
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt >= @iraiUketsukeNendoDtFrom2");
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt <= @iraiUketsukeNendoDtTo2");

                commandParams.Add("@iraiUketsukeNendoDtFrom2", SqlDbType.NVarChar).Value = searchCond.Nendo + "0401";
                commandParams.Add("@iraiUketsukeNendoDtTo2", SqlDbType.NVarChar).Value = (Int32.Parse(searchCond.Nendo) + 1) + "0331";
            }

            //依頼受付日（開始）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeFromDt))
            {
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt >= @iraiUketsukeDtFrom2");
                commandParams.Add("@iraiUketsukeDtFrom2", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeFromDt;
            }

            //依頼受付日（終了）
            if (!string.IsNullOrEmpty(searchCond.IraiUketsukeToDt))
            {
                sqlContent.Append(" AND ksit.KeiryoShomeiIraiUketsukeDt <= @iraiUketsukeDtTo2");
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

            #endregion

            sqlContent.Append(" ) as tbl ");

            #region UNION ORDER BY

            sqlContent.Append(" ORDER BY ");
            sqlContent.Append(" IraiNendo, ");
            sqlContent.Append(" ShishoCd, ");
            sqlContent.Append(" SuishitsuKensaIraiNo, ");
            sqlContent.Append(" ShikenkoumokuCd ");

            #endregion
            // 20150112 sou End

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KeiryoShomeiDaichoUpdateDtTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiryoShomeiDaichoUpdateDtTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　宗          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KeiryoShomeiDaichoUpdateDtTableAdapter
    {
        #region GetDataUpdateDtByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataUpdateDtByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtDataTable GetDataUpdateDtByCond(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtDataTable dataTable
                = new KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtDataTable();
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
        /// 2014/12/08　宗          新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KeiryoShomeiDaichoSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region SELECT

            sqlContent.Append("Select ");

            // 検査台帳(9条)ヘッダテーブル
            sqlContent.Append("HdrTbl.IraiNendo ");
            sqlContent.Append(", HdrTbl.ShishoCd ");
            sqlContent.Append(", HdrTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append(", HdrTbl.UpdateDt as HdrUpdateDt ");
            // 計量証明依頼テーブル
            sqlContent.Append(", IraiTbl.UpdateDt as IraiUpdateDt ");
            // 計量証明結果テーブル
            sqlContent.Append(", PhKekkaTbl.UpdateDt as PhKekkaUpdateDt ");
            sqlContent.Append(", SsKekkaTbl.UpdateDt as SsKekkaUpdateDt ");
            sqlContent.Append(", BodAKekkaTbl.UpdateDt as BodAKekkaUpdateDt ");
            sqlContent.Append(", Nh4nKekkaTbl.UpdateDt as Nh4nKekkaUpdateDt ");
            sqlContent.Append(", ClKekkaTbl.UpdateDt as ClKekkaUpdateDt ");
            sqlContent.Append(", CodKekkaTbl.UpdateDt as CodKekkaUpdateDt ");
            sqlContent.Append(", HekisanAKekkaTbl.UpdateDt as HekisanAKekkaUpdateDt ");
            sqlContent.Append(", MlssKekkaTbl.UpdateDt as MlssKekkaUpdateDt ");
            sqlContent.Append(", TnAKekkaTbl.UpdateDt as TnAKekkaUpdateDt ");
            sqlContent.Append(", AbsAKekkaTbl.UpdateDt as AbsAKekkaUpdateDt ");
            sqlContent.Append(", TpAKekkaTbl.UpdateDt as TpAKekkaUpdateDt ");
            sqlContent.Append(", RinsanKekkaTbl.UpdateDt as RinsanKekkaUpdateDt ");
            sqlContent.Append(", No2nTeiryoKekkaTbl.UpdateDt as No2nTeiryoKekkaUpdateDt ");
            sqlContent.Append(", No3nTeiryoKekkaTbl.UpdateDt as No3nTeiryoKekkaUpdateDt ");
            sqlContent.Append(", AbsBKekkaTbl.UpdateDt as AbsBKekkaUpdateDt ");
            sqlContent.Append(", TnBKekkaTbl.UpdateDt as TnBKekkaUpdateDt ");
            sqlContent.Append(", TpBKekkaTbl.UpdateDt as TpBKekkaUpdateDt ");
            sqlContent.Append(", ShikidoKekkaTbl.UpdateDt as ShikidoKekkaUpdateDt ");
            sqlContent.Append(", BodBKekkaTbl.UpdateDt as BodBKekkaUpdateDt ");
            sqlContent.Append(", HekisanKoyuKekkaTbl.UpdateDt as HekisanKoyuKekkaUpdateDt ");
            sqlContent.Append(", HekisanDoshokuKekkaTbl.UpdateDt as HekisanDoshokuKekkaUpdateDt ");
            sqlContent.Append(", HekisanBKekkaTbl.UpdateDt as HekisanBKekkaUpdateDt ");
            sqlContent.Append(", NamariKekkaTbl.UpdateDt as NamariKekkaUpdateDt ");
            sqlContent.Append(", AenKekkaTbl.UpdateDt as AenKekkaUpdateDt ");
            sqlContent.Append(", HousoKekkaTbl.UpdateDt as HousoKekkaUpdateDt ");
            sqlContent.Append(", ZanenKekkaTbl.UpdateDt as ZanenKekkaUpdateDt ");
            sqlContent.Append(", GaikanKekkaTbl.UpdateDt as GaikanKekkaUpdateDt ");
            sqlContent.Append(", ShukiKekkaTbl.UpdateDt as ShukiKekkaUpdateDt ");
            sqlContent.Append(", TrKekkaTbl.UpdateDt as TrKekkaUpdateDt ");
            sqlContent.Append(", No2nTeiseiKekkaTbl.UpdateDt as No2nTeiseiKekkaUpdateDt ");
            sqlContent.Append(", No3nTeiseiKekkaTbl.UpdateDt as No3nTeiseiKekkaUpdateDt ");
            sqlContent.Append(", DaichokinKekkaTbl.UpdateDt as DaichokinKekkaUpdateDt ");
            // 検査台帳明細テーブル
            sqlContent.Append(", Ph1DtlTbl.UpdateDt as Ph1DtlUpdateDt ");
            sqlContent.Append(", Ph2DtlTbl.UpdateDt as Ph2DtlUpdateDt ");
            sqlContent.Append(", Ss1DtlTbl.UpdateDt as Ss1DtlUpdateDt ");
            sqlContent.Append(", Ss2DtlTbl.UpdateDt as Ss2DtlUpdateDt ");
            sqlContent.Append(", BodA1DtlTbl.UpdateDt as BodA1DtlUpdateDt ");
            sqlContent.Append(", BodA2DtlTbl.UpdateDt as BodA2DtlUpdateDt ");
            sqlContent.Append(", Nh4n1DtlTbl.UpdateDt as Nh4n1DtlUpdateDt ");
            sqlContent.Append(", Nh4n2DtlTbl.UpdateDt as Nh4n2DtlUpdateDt ");
            sqlContent.Append(", Cl1DtlTbl.UpdateDt as Cl1DtlUpdateDt ");
            sqlContent.Append(", Cl2DtlTbl.UpdateDt as Cl2DtlUpdateDt ");
            sqlContent.Append(", Cod1DtlTbl.UpdateDt as Cod1DtlUpdateDt ");
            sqlContent.Append(", Cod2DtlTbl.UpdateDt as Cod2DtlUpdateDt ");
            sqlContent.Append(", HekisanA1DtlTbl.UpdateDt as HekisanA1DtlUpdateDt ");
            sqlContent.Append(", HekisanA2DtlTbl.UpdateDt as HekisanA2DtlUpdateDt ");
            sqlContent.Append(", Mlss1DtlTbl.UpdateDt as Mlss1DtlUpdateDt ");
            sqlContent.Append(", Mlss2DtlTbl.UpdateDt as Mlss2DtlUpdateDt ");
            sqlContent.Append(", TnA1DtlTbl.UpdateDt as TnA1DtlUpdateDt ");
            sqlContent.Append(", TnA2DtlTbl.UpdateDt as TnA2DtlUpdateDt ");
            sqlContent.Append(", AbsA1DtlTbl.UpdateDt as AbsA1DtlUpdateDt ");
            sqlContent.Append(", AbsA2DtlTbl.UpdateDt as AbsA2DtlUpdateDt ");
            sqlContent.Append(", TpA1DtlTbl.UpdateDt as TpA1DtlUpdateDt ");
            sqlContent.Append(", TpA2DtlTbl.UpdateDt as TpA2DtlUpdateDt ");
            sqlContent.Append(", Rinsan1DtlTbl.UpdateDt as Rinsan1DtlUpdateDt ");
            sqlContent.Append(", Rinsan2DtlTbl.UpdateDt as Rinsan2DtlUpdateDt ");
            sqlContent.Append(", No2nTeiryo1DtlTbl.UpdateDt as No2nTeiryo1DtlUpdateDt ");
            sqlContent.Append(", No2nTeiryo2DtlTbl.UpdateDt as No2nTeiryo2DtlUpdateDt ");
            sqlContent.Append(", No3nTeiryo1DtlTbl.UpdateDt as No3nTeiryo1DtlUpdateDt ");
            sqlContent.Append(", No3nTeiryo2DtlTbl.UpdateDt as No3nTeiryo2DtlUpdateDt ");
            sqlContent.Append(", AbsB1DtlTbl.UpdateDt as AbsB1DtlUpdateDt ");
            sqlContent.Append(", AbsB2DtlTbl.UpdateDt as AbsB2DtlUpdateDt ");
            sqlContent.Append(", TnB1DtlTbl.UpdateDt as TnB1DtlUpdateDt ");
            sqlContent.Append(", TnB2DtlTbl.UpdateDt as TnB2DtlUpdateDt ");
            sqlContent.Append(", TpB1DtlTbl.UpdateDt as TpB1DtlUpdateDt ");
            sqlContent.Append(", TpB2DtlTbl.UpdateDt as TpB2DtlUpdateDt ");
            sqlContent.Append(", Shikido1DtlTbl.UpdateDt as Shikido1DtlUpdateDt ");
            sqlContent.Append(", Shikido2DtlTbl.UpdateDt as Shikido2DtlUpdateDt ");
            sqlContent.Append(", BodB1DtlTbl.UpdateDt as BodB1DtlUpdateDt ");
            sqlContent.Append(", BodB2DtlTbl.UpdateDt as BodB2DtlUpdateDt ");
            sqlContent.Append(", HekisanKoyu1DtlTbl.UpdateDt as HekisanKoyu1DtlUpdateDt ");
            sqlContent.Append(", HekisanKoyu2DtlTbl.UpdateDt as HekisanKoyu2DtlUpdateDt ");
            sqlContent.Append(", HekisanDoshoku1DtlTbl.UpdateDt as HekisanDoshoku1DtlUpdateDt ");
            sqlContent.Append(", HekisanDoshoku2DtlTbl.UpdateDt as HekisanDoshoku2DtlUpdateDt ");
            sqlContent.Append(", HekisanB1DtlTbl.UpdateDt as HekisanB1DtlUpdateDt ");
            sqlContent.Append(", HekisanB2DtlTbl.UpdateDt as HekisanB2DtlUpdateDt ");
            sqlContent.Append(", Namari1DtlTbl.UpdateDt as Namari1DtlUpdateDt ");
            sqlContent.Append(", Namari2DtlTbl.UpdateDt as Namari2DtlUpdateDt ");
            sqlContent.Append(", Aen1DtlTbl.UpdateDt as Aen1DtlUpdateDt ");
            sqlContent.Append(", Aen2DtlTbl.UpdateDt as Aen2DtlUpdateDt ");
            sqlContent.Append(", Houso1DtlTbl.UpdateDt as Houso1DtlUpdateDt ");
            sqlContent.Append(", Houso2DtlTbl.UpdateDt as Houso2DtlUpdateDt ");
            sqlContent.Append(", Zanen1DtlTbl.UpdateDt as Zanen1DtlUpdateDt ");
            sqlContent.Append(", Zanen2DtlTbl.UpdateDt as Zanen2DtlUpdateDt ");
            sqlContent.Append(", Gaikan1DtlTbl.UpdateDt as Gaikan1DtlUpdateDt ");
            sqlContent.Append(", Gaikan2DtlTbl.UpdateDt as Gaikan2DtlUpdateDt ");
            sqlContent.Append(", Shuki1DtlTbl.UpdateDt as Shuki1DtlUpdateDt ");
            sqlContent.Append(", Shuki2DtlTbl.UpdateDt as Shuki2DtlUpdateDt ");
            sqlContent.Append(", Tr1DtlTbl.UpdateDt as Tr1DtlUpdateDt ");
            sqlContent.Append(", Tr2DtlTbl.UpdateDt as Tr2DtlUpdateDt ");
            sqlContent.Append(", No2nTeisei1DtlTbl.UpdateDt as No2nTeisei1DtlUpdateDt ");
            sqlContent.Append(", No2nTeisei2DtlTbl.UpdateDt as No2nTeisei2DtlUpdateDt ");
            sqlContent.Append(", No3nTeisei1DtlTbl.UpdateDt as No3nTeisei1DtlUpdateDt ");
            sqlContent.Append(", No3nTeisei2DtlTbl.UpdateDt as No3nTeisei2DtlUpdateDt ");
            sqlContent.Append(", Daichokin1DtlTbl.UpdateDt as Daichokin1DtlUpdateDt ");
            sqlContent.Append(", Daichokin2DtlTbl.UpdateDt as Daichokin2DtlUpdateDt ");

            #endregion

            #region FROM

            sqlContent.Append("From ");

            // 検査台帳(9条)ヘッダテーブル
            sqlContent.Append("KensaDaicho9joHdrTbl as HdrTbl ");
            // 検査台帳(9条)ヘッダテーブル　→　計量証明依頼
            sqlContent.Append("Inner Join KeiryoShomeiIraiTbl as IraiTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = IraiTbl.KeiryoShomeiIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = IraiTbl.KeiryoShomeiIraiSishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = IraiTbl.KeiryoShomeiIraiRenban ");
            // 検査台帳(9条)ヘッダテーブル　→　計量証明結果テーブル
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as PhKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = PhKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = PhKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = PhKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdPh = PhKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as SsKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = SsKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = SsKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = SsKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdSs = SsKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as BodAKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = BodAKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = BodAKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = BodAKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdBodA = BodAKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as Nh4nKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = Nh4nKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = Nh4nKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = Nh4nKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdNh4n = Nh4nKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as ClKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = ClKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = ClKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = ClKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdCl = ClKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as CodKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = CodKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = CodKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = CodKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdCod = CodKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as HekisanAKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = HekisanAKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = HekisanAKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = HekisanAKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanA = HekisanAKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as MlssKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = MlssKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = MlssKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = MlssKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdMlss = MlssKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as TnAKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = TnAKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = TnAKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = TnAKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdTnA = TnAKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as AbsAKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = AbsAKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = AbsAKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = AbsAKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdAbsA = AbsAKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as TpAKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = TpAKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = TpAKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = TpAKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdTpA = TpAKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as RinsanKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = RinsanKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = RinsanKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = RinsanKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdRinsan = RinsanKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as No2nTeiryoKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = No2nTeiryoKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = No2nTeiryoKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = No2nTeiryoKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdNo2nTeiryo = No2nTeiryoKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as No3nTeiryoKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = No3nTeiryoKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = No3nTeiryoKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = No3nTeiryoKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdNo3nTeiryo = No3nTeiryoKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as AbsBKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = AbsBKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = AbsBKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = AbsBKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdAbsB = AbsBKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as TnBKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = TnBKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = TnBKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = TnBKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdTnB = TnBKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as TpBKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = TpBKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = TpBKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = TpBKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdTpB = TpBKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as ShikidoKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = ShikidoKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = ShikidoKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = ShikidoKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdShikido = ShikidoKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as BodBKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = BodBKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = BodBKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = BodBKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdBodB = BodBKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as HekisanKoyuKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = HekisanKoyuKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = HekisanKoyuKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = HekisanKoyuKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanKoyu = HekisanKoyuKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as HekisanDoshokuKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = HekisanDoshokuKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = HekisanDoshokuKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = HekisanDoshokuKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanDoshoku = HekisanDoshokuKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as HekisanBKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = HekisanBKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = HekisanBKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = HekisanBKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanB = HekisanBKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as NamariKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = NamariKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = NamariKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = NamariKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdNamari = NamariKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as AenKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = AenKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = AenKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = AenKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdAen = AenKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as HousoKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = HousoKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = HousoKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = HousoKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdHouso = HousoKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as ZanenKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = ZanenKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = ZanenKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = ZanenKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdZanen = ZanenKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as GaikanKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = GaikanKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = GaikanKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = GaikanKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdGaikan = GaikanKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as ShukiKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = ShukiKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = ShukiKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = ShukiKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdShuki = ShukiKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as TrKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = TrKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = TrKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = TrKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdTr = TrKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as No2nTeiseiKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = No2nTeiseiKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = No2nTeiseiKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = No2nTeiseiKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdNo2nTeisei = No2nTeiseiKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as No3nTeiseiKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = No3nTeiseiKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = No3nTeiseiKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = No3nTeiseiKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdNo3nTeisei = No3nTeiseiKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            sqlContent.Append("Left Join KeiryoShomeiKekkaTbl as DaichokinKekkaTbl ");
            sqlContent.Append("	On HdrTbl.KeiryoShomeiIraiNendo = DaichokinKekkaTbl.KeiryoShomeiKekkaIraiNendo ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiSishoCd = DaichokinKekkaTbl.KeiryoShomeiKekkaIraiShishoCd ");
            sqlContent.Append("	and HdrTbl.KeiryoShomeiIraiRenban = DaichokinKekkaTbl.KeiryoShomeiKekkaIraiNo ");
            sqlContent.Append("	and @kmkCdDaichokin = DaichokinKekkaTbl.KeiryoShomeiShikenkoumokuCd ");
            // 検査台帳(9条)ヘッダテーブル　→　検査台帳明細テーブル
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ph1DtlTbl ");
            sqlContent.Append("	On '1' = Ph1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Ph1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Ph1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Ph1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdPh = Ph1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Ph1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ph2DtlTbl ");
            sqlContent.Append("	On '1' = Ph2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Ph2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Ph2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Ph2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdPh = Ph2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Ph2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ss1DtlTbl ");
            sqlContent.Append("	On '1' = Ss1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Ss1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Ss1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Ss1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdSs = Ss1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Ss1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Ss2DtlTbl ");
            sqlContent.Append("	On '1' = Ss2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Ss2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Ss2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Ss2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdSs = Ss2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Ss2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodA1DtlTbl ");
            sqlContent.Append("	On '1' = BodA1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = BodA1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = BodA1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = BodA1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdBodA = BodA1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = BodA1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodA2DtlTbl ");
            sqlContent.Append("	On '1' = BodA2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = BodA2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = BodA2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = BodA2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdBodA = BodA2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = BodA2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Nh4n1DtlTbl ");
            sqlContent.Append("	On '1' = Nh4n1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Nh4n1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Nh4n1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Nh4n1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNh4n = Nh4n1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Nh4n1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Nh4n2DtlTbl ");
            sqlContent.Append("	On '1' = Nh4n2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Nh4n2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Nh4n2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Nh4n2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNh4n = Nh4n2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Nh4n2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cl1DtlTbl ");
            sqlContent.Append("	On '1' = Cl1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Cl1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Cl1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Cl1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdCl = Cl1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Cl1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cl2DtlTbl ");
            sqlContent.Append("	On '1' = Cl2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Cl2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Cl2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Cl2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdCl = Cl2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Cl2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cod1DtlTbl ");
            sqlContent.Append("	On '1' = Cod1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Cod1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Cod1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Cod1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdCod = Cod1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Cod1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Cod2DtlTbl ");
            sqlContent.Append("	On '1' = Cod2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Cod2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Cod2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Cod2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdCod = Cod2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Cod2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanA1DtlTbl ");
            sqlContent.Append("	On '1' = HekisanA1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanA1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanA1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanA1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanA = HekisanA1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = HekisanA1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanA2DtlTbl ");
            sqlContent.Append("	On '1' = HekisanA2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanA2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanA2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanA2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanA = HekisanA2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = HekisanA2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Mlss1DtlTbl ");
            sqlContent.Append("	On '1' = Mlss1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Mlss1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Mlss1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Mlss1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdMlss = Mlss1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Mlss1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Mlss2DtlTbl ");
            sqlContent.Append("	On '1' = Mlss2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Mlss2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Mlss2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Mlss2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdMlss = Mlss2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Mlss2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnA1DtlTbl ");
            sqlContent.Append("	On '1' = TnA1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TnA1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TnA1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TnA1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTnA = TnA1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = TnA1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnA2DtlTbl ");
            sqlContent.Append("	On '1' = TnA2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TnA2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TnA2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TnA2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTnA = TnA2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = TnA2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsA1DtlTbl ");
            sqlContent.Append("	On '1' = AbsA1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = AbsA1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = AbsA1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = AbsA1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdAbsA = AbsA1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = AbsA1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsA2DtlTbl ");
            sqlContent.Append("	On '1' = AbsA2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = AbsA2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = AbsA2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = AbsA2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdAbsA = AbsA2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = AbsA2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpA1DtlTbl ");
            sqlContent.Append("	On '1' = TpA1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TpA1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TpA1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TpA1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTpA = TpA1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = TpA1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpA2DtlTbl ");
            sqlContent.Append("	On '1' = TpA2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TpA2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TpA2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TpA2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTpA = TpA2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = TpA2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Rinsan1DtlTbl ");
            sqlContent.Append("	On '1' = Rinsan1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Rinsan1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Rinsan1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Rinsan1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdRinsan = Rinsan1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Rinsan1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Rinsan2DtlTbl ");
            sqlContent.Append("	On '1' = Rinsan2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Rinsan2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Rinsan2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Rinsan2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdRinsan = Rinsan2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Rinsan2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeiryo1DtlTbl ");
            sqlContent.Append("	On '1' = No2nTeiryo1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No2nTeiryo1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No2nTeiryo1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No2nTeiryo1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo2nTeiryo = No2nTeiryo1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = No2nTeiryo1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeiryo2DtlTbl ");
            sqlContent.Append("	On '1' = No2nTeiryo2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No2nTeiryo2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No2nTeiryo2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No2nTeiryo2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo2nTeiryo = No2nTeiryo2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = No2nTeiryo2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeiryo1DtlTbl ");
            sqlContent.Append("	On '1' = No3nTeiryo1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No3nTeiryo1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No3nTeiryo1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No3nTeiryo1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo3nTeiryo = No3nTeiryo1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = No3nTeiryo1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeiryo2DtlTbl ");
            sqlContent.Append("	On '1' = No3nTeiryo2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No3nTeiryo2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No3nTeiryo2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No3nTeiryo2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo3nTeiryo = No3nTeiryo2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = No3nTeiryo2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsB1DtlTbl ");
            sqlContent.Append("	On '1' = AbsB1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = AbsB1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = AbsB1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = AbsB1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdAbsB = AbsB1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = AbsB1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as AbsB2DtlTbl ");
            sqlContent.Append("	On '1' = AbsB2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = AbsB2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = AbsB2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = AbsB2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdAbsB = AbsB2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = AbsB2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnB1DtlTbl ");
            sqlContent.Append("	On '1' = TnB1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TnB1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TnB1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TnB1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTnB = TnB1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = TnB1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TnB2DtlTbl ");
            sqlContent.Append("	On '1' = TnB2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TnB2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TnB2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TnB2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTnB = TnB2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = TnB2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpB1DtlTbl ");
            sqlContent.Append("	On '1' = TpB1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TpB1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TpB1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TpB1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTpB = TpB1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = TpB1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as TpB2DtlTbl ");
            sqlContent.Append("	On '1' = TpB2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = TpB2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = TpB2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = TpB2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTpB = TpB2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = TpB2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shikido1DtlTbl ");
            sqlContent.Append("	On '1' = Shikido1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Shikido1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Shikido1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Shikido1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdShikido = Shikido1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Shikido1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shikido2DtlTbl ");
            sqlContent.Append("	On '1' = Shikido2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Shikido2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Shikido2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Shikido2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdShikido = Shikido2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Shikido2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodB1DtlTbl ");
            sqlContent.Append("	On '1' = BodB1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = BodB1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = BodB1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = BodB1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdBodB = BodB1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = BodB1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as BodB2DtlTbl ");
            sqlContent.Append("	On '1' = BodB2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = BodB2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = BodB2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = BodB2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdBodB = BodB2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = BodB2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanKoyu1DtlTbl ");
            sqlContent.Append("	On '1' = HekisanKoyu1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanKoyu1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanKoyu1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanKoyu1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanKoyu = HekisanKoyu1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = HekisanKoyu1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanKoyu2DtlTbl ");
            sqlContent.Append("	On '1' = HekisanKoyu2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanKoyu2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanKoyu2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanKoyu2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanKoyu = HekisanKoyu2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = HekisanKoyu2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanDoshoku1DtlTbl ");
            sqlContent.Append("	On '1' = HekisanDoshoku1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanDoshoku1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanDoshoku1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanDoshoku1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanDoshoku = HekisanDoshoku1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = HekisanDoshoku1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanDoshoku2DtlTbl ");
            sqlContent.Append("	On '1' = HekisanDoshoku2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanDoshoku2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanDoshoku2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanDoshoku2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanDoshoku = HekisanDoshoku2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = HekisanDoshoku2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanB1DtlTbl ");
            sqlContent.Append("	On '1' = HekisanB1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanB1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanB1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanB1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanB = HekisanB1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = HekisanB1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as HekisanB2DtlTbl ");
            sqlContent.Append("	On '1' = HekisanB2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = HekisanB2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = HekisanB2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = HekisanB2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHekisanB = HekisanB2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = HekisanB2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Namari1DtlTbl ");
            sqlContent.Append("	On '1' = Namari1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Namari1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Namari1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Namari1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNamari = Namari1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Namari1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Namari2DtlTbl ");
            sqlContent.Append("	On '1' = Namari2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Namari2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Namari2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Namari2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNamari = Namari2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Namari2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Aen1DtlTbl ");
            sqlContent.Append("	On '1' = Aen1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Aen1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Aen1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Aen1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdAen = Aen1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Aen1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Aen2DtlTbl ");
            sqlContent.Append("	On '1' = Aen2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Aen2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Aen2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Aen2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdAen = Aen2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Aen2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Houso1DtlTbl ");
            sqlContent.Append("	On '1' = Houso1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Houso1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Houso1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Houso1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHouso = Houso1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Houso1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Houso2DtlTbl ");
            sqlContent.Append("	On '1' = Houso2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Houso2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Houso2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Houso2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdHouso = Houso2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Houso2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Zanen1DtlTbl ");
            sqlContent.Append("	On '1' = Zanen1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Zanen1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Zanen1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Zanen1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdZanen = Zanen1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Zanen1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Zanen2DtlTbl ");
            sqlContent.Append("	On '1' = Zanen2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Zanen2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Zanen2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Zanen2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdZanen = Zanen2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Zanen2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Gaikan1DtlTbl ");
            sqlContent.Append("	On '1' = Gaikan1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Gaikan1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Gaikan1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Gaikan1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdGaikan = Gaikan1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Gaikan1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Gaikan2DtlTbl ");
            sqlContent.Append("	On '1' = Gaikan2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Gaikan2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Gaikan2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Gaikan2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdGaikan = Gaikan2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Gaikan2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shuki1DtlTbl ");
            sqlContent.Append("	On '1' = Shuki1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Shuki1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Shuki1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Shuki1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdShuki = Shuki1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Shuki1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Shuki2DtlTbl ");
            sqlContent.Append("	On '1' = Shuki2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Shuki2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Shuki2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Shuki2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdShuki = Shuki2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Shuki2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Tr1DtlTbl ");
            sqlContent.Append("	On '1' = Tr1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Tr1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Tr1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Tr1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTr = Tr1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Tr1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Tr2DtlTbl ");
            sqlContent.Append("	On '1' = Tr2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Tr2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Tr2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Tr2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdTr = Tr2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Tr2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeisei1DtlTbl ");
            sqlContent.Append("	On '1' = No2nTeisei1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No2nTeisei1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No2nTeisei1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No2nTeisei1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo2nTeisei = No2nTeisei1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = No2nTeisei1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No2nTeisei2DtlTbl ");
            sqlContent.Append("	On '1' = No2nTeisei2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No2nTeisei2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No2nTeisei2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No2nTeisei2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo2nTeisei = No2nTeisei2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = No2nTeisei2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeisei1DtlTbl ");
            sqlContent.Append("	On '1' = No3nTeisei1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No3nTeisei1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No3nTeisei1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No3nTeisei1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo3nTeisei = No3nTeisei1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = No3nTeisei1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as No3nTeisei2DtlTbl ");
            sqlContent.Append("	On '1' = No3nTeisei2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = No3nTeisei2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = No3nTeisei2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = No3nTeisei2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdNo3nTeisei = No3nTeisei2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = No3nTeisei2DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Daichokin1DtlTbl ");
            sqlContent.Append("	On '1' = Daichokin1DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Daichokin1DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Daichokin1DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Daichokin1DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdDaichokin = Daichokin1DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '0' = Daichokin1DtlTbl.SaikensaKbn ");
            sqlContent.Append("Left Join KensaDaichoDtlTbl as Daichokin2DtlTbl ");
            sqlContent.Append("	On '1' = Daichokin2DtlTbl.KensaKbn ");
            sqlContent.Append("	and HdrTbl.IraiNendo = Daichokin2DtlTbl.IraiNendo ");
            sqlContent.Append("	and HdrTbl.ShishoCd = Daichokin2DtlTbl.ShishoCd ");
            sqlContent.Append("	and HdrTbl.SuishitsuKensaIraiNo = Daichokin2DtlTbl.SuishitsuKensaIraiNo ");
            sqlContent.Append("	and @kmkCdDaichokin = Daichokin2DtlTbl.ShikenkoumokuCd ");
            sqlContent.Append("	and '1' = Daichokin2DtlTbl.SaikensaKbn ");

            commandParams.Add("@kmkCdPh", SqlDbType.NVarChar).Value = searchCond.KmkCdPh;
            commandParams.Add("@kmkCdSs", SqlDbType.NVarChar).Value = searchCond.KmkCdSs;
            commandParams.Add("@kmkCdBodA", SqlDbType.NVarChar).Value = searchCond.KmkCdBodA;
            commandParams.Add("@kmkCdNh4n", SqlDbType.NVarChar).Value = searchCond.KmkCdNh4n;
            commandParams.Add("@kmkCdCl", SqlDbType.NVarChar).Value = searchCond.KmkCdCl;
            commandParams.Add("@kmkCdCod", SqlDbType.NVarChar).Value = searchCond.KmkCdCod;
            commandParams.Add("@kmkCdHekisanA", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanA;
            commandParams.Add("@kmkCdMlss", SqlDbType.NVarChar).Value = searchCond.KmkCdMlss;
            commandParams.Add("@kmkCdTnA", SqlDbType.NVarChar).Value = searchCond.KmkCdTnA;
            commandParams.Add("@kmkCdAbsA", SqlDbType.NVarChar).Value = searchCond.KmkCdAbsA;
            commandParams.Add("@kmkCdTpA", SqlDbType.NVarChar).Value = searchCond.KmkCdTpA;
            commandParams.Add("@kmkCdRinsan", SqlDbType.NVarChar).Value = searchCond.KmkCdRinsan;
            commandParams.Add("@kmkCdNo2nTeiryo", SqlDbType.NVarChar).Value = searchCond.KmkCdNo2nTeiryo;
            commandParams.Add("@kmkCdNo3nTeiryo", SqlDbType.NVarChar).Value = searchCond.KmkCdNo3nTeiryo;
            commandParams.Add("@kmkCdAbsB", SqlDbType.NVarChar).Value = searchCond.KmkCdAbsB;
            commandParams.Add("@kmkCdTnB", SqlDbType.NVarChar).Value = searchCond.KmkCdTnB;
            commandParams.Add("@kmkCdTpB", SqlDbType.NVarChar).Value = searchCond.KmkCdTpB;
            commandParams.Add("@kmkCdShikido", SqlDbType.NVarChar).Value = searchCond.KmkCdShikido;
            commandParams.Add("@kmkCdBodB", SqlDbType.NVarChar).Value = searchCond.KmkCdBodB;
            commandParams.Add("@kmkCdHekisanKoyu", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanKoyu;
            commandParams.Add("@kmkCdHekisanDoshoku", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanDoshoku;
            commandParams.Add("@kmkCdHekisanB", SqlDbType.NVarChar).Value = searchCond.KmkCdHekisanB;
            commandParams.Add("@kmkCdNamari", SqlDbType.NVarChar).Value = searchCond.KmkCdNamari;
            commandParams.Add("@kmkCdAen", SqlDbType.NVarChar).Value = searchCond.KmkCdAen;
            commandParams.Add("@kmkCdHouso", SqlDbType.NVarChar).Value = searchCond.KmkCdHouso;
            commandParams.Add("@kmkCdZanen", SqlDbType.NVarChar).Value = searchCond.KmkCdZanen;
            commandParams.Add("@kmkCdGaikan", SqlDbType.NVarChar).Value = searchCond.KmkCdGaikan;
            commandParams.Add("@kmkCdShuki", SqlDbType.NVarChar).Value = searchCond.KmkCdShuki;
            commandParams.Add("@kmkCdTr", SqlDbType.NVarChar).Value = searchCond.KmkCdTr;
            commandParams.Add("@kmkCdNo2nTeisei", SqlDbType.NVarChar).Value = searchCond.KmkCdNo2nTeisei;
            commandParams.Add("@kmkCdNo3nTeisei", SqlDbType.NVarChar).Value = searchCond.KmkCdNo3nTeisei;
            commandParams.Add("@kmkCdDaichokin", SqlDbType.NVarChar).Value = searchCond.KmkCdDaichokin;

            #endregion

            #region WHERE(定型)

            sqlContent.Append("Where ");

            sqlContent.Append("HdrTbl.ShishoCd = @LoginShishoCd ");
            sqlContent.Append("And (HdrTbl.KachoKeninKbn = '0' ");
            sqlContent.Append("Or HdrTbl.HukuKachoKeninKbn = '0' ");
            sqlContent.Append("Or HdrTbl.KeiryoKanrishaKeninKbn = '0') ");

            commandParams.Add("@LoginShishoCd", SqlDbType.NVarChar).Value = searchCond.ShishoCd;

            #endregion

            #region WHERE(動的)

            // 年度
            if (!string.IsNullOrEmpty(searchCond.Nendo))
            {
                sqlContent.Append("AND HdrTbl.IraiNendo = @IraiNendo ");
                commandParams.Add("@IraiNendo", SqlDbType.NVarChar).Value = searchCond.Nendo;
            }

            // 依頼受付日入力区分の有無
            if (searchCond.IraiUketsukeDtInputKbn == "1")
            {
                // 依頼受付日(開始)
                sqlContent.Append("AND HdrTbl.KensaIraiUketsukeDt >= @IraiUketsukeFromDt ");
                commandParams.Add("@IraiUketsukeFromDt", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeFromDt;
                // 依頼受付日(開始)
                sqlContent.Append("AND HdrTbl.KensaIraiUketsukeDt <= @IraiUketsukeToDt ");
                commandParams.Add("@IraiUketsukeToDt", SqlDbType.NVarChar).Value = searchCond.IraiUketsukeToDt;
            }

            // 依頼No(開始)
            if (!string.IsNullOrEmpty(searchCond.IraiNoFrom))
            {
                sqlContent.Append("AND HdrTbl.SuishitsuKensaIraiNo >= @IraiNoFrom ");
                commandParams.Add("@IraiNoFrom", SqlDbType.NVarChar).Value = searchCond.IraiNoFrom;
            }

            // 依頼No(終了)
            if (!string.IsNullOrEmpty(searchCond.IraiNoTo))
            {
                sqlContent.Append("AND HdrTbl.SuishitsuKensaIraiNo <= @IraiNoTo ");
                commandParams.Add("@IraiNoTo", SqlDbType.NVarChar).Value = searchCond.IraiNoTo;
            }

            #endregion

            #region ORDER BY

            sqlContent.Append("Order By ");

            sqlContent.Append("HdrTbl.IraiNendo ");
            sqlContent.Append(", HdrTbl.ShishoCd ");
            sqlContent.Append(", HdrTbl.SuishitsuKensaIraiNo ");

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
