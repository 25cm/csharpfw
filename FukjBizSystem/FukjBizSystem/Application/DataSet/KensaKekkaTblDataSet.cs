using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
    
    public partial class KensaKekkaTblDataSet {
        partial class KensaKekkaShoInfoDataTable
        {
        }
    }

    #region KensaKekkaInputListSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputListSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　DatNT　　 新規作成
    /// 2015/01/14　AnhNV　　 v1.04
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KensaKekkaInputListSearchCond
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
        /// 検査日検索使用フラグ
        /// </summary>
        public bool KensaYoteiDtUse { get; set; }

        /// <summary>
        /// 検査日（開始）
        /// </summary>
        public string KensaDtFrom { get; set; }

        /// <summary>
        /// 検査日（終了）
        /// </summary>
        public string KensaDtTo { get; set; }
        
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
        /// 人槽（開始）
        /// </summary>
        public string NinsoFrom { get; set; }

        /// <summary>
        /// 人槽（終了）
        /// </summary>
        public string NinsoTo { get; set; }

        /// <summary>
        /// 対象物件
        /// </summary>
        public string TaishoBukken { get; set; }

        // 2015/01/14 AnhNV ADD Start
        /// <summary>
        /// 業者名
        /// </summary>
        public string GyoshaNm { get; set; }

        /// <summary>
        /// 現地区コード
        /// </summary>
        public string KensaIraiGenChikuCd { get; set; }
        // 2015/01/14 AnhNV ADD End
    }
    #endregion

    #region KensaKekkaListSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaListSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/09　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KensaKekkaListSearchCond
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// スクリーニング区分 
        /// </summary>
        public string[] KensaIraiScreeningKbn { get; set; }

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
        /// 水質検査依頼番号（開始）
        /// </summary>
        public string KensaIraiSuishitsuIraiNoFrom { get; set; }

        /// <summary>
        /// 水質検査依頼番号（終了）
        /// </summary>
        public string KensaIraiSuishitsuIraiNoTo { get; set; }

        /// <summary>
        /// 設置者名
        /// </summary>
        public string KensaIraiSetchishaNm { get; set; }

        /// <summary>
        /// 施設名称 
        /// </summary>
        public string KensaIraiShisetsuNm { get; set; }

        /// <summary>
        /// 検査依頼日（開始）
        /// </summary>
        public string KensaIraiDtFrom { get; set; }

        /// <summary>
        /// 検査依頼日（終了）
        /// </summary>
        public string KensaIraiDtTo { get; set; }

        /// <summary>
        /// 検査日（開始）
        /// </summary>
        public string KensaDtFrom { get; set; }

        /// <summary>
        /// 検査日（終了）
        /// </summary>
        public string KensaDtTo { get; set; }

        /// <summary>
        /// 判定 
        /// </summary>
        public string[] KensaKekkaHantei { get; set; }

        /// <summary>
        /// 発行区分
        /// </summary>
        public string KensaIraiHakkoKbn { get; set; }
    }
    #endregion
}

namespace FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters
{
    #region SaisuiTekiseiTenkenListKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiTekiseiTenkenListKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/20　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiTekiseiTenkenListKensakuTableAdapter
    {
        #region GetDataByIraiBangoNendo
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByIraiBangoNendo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiBangoFrom"></param>
        /// <param name="iraiBangoTo"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable GetDataByIraiBangoNendo(string iraiBangoFrom, string iraiBangoTo, string nendo)
        {
            SqlCommand command = CreateSqlCommand(iraiBangoFrom, iraiBangoTo, nendo);
            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.SelectCommand.Connection = this.Connection;

            KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable table = new KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable();
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
        /// <param name="iraiBangoFrom"></param>
        /// <param name="iraiBangoTo"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　AnhNV　　 新規作成
        /// 2014/11/10　AnhNV    基本設計書_014_001_画面_SaisuiTekiseiTenken_V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string iraiBangoFrom, string iraiBangoTo, string nendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" select                                                                                                                  ");
            sqlContent.AppendLine("     row_number() over(order by kkt.KensaKekkaSuishitsuIraiNo) as RowNoCol,                                              ");
            sqlContent.AppendLine("     kit.KensaIraiHoteiKbn,                                                                                              ");
            sqlContent.AppendLine("     kit.KensaIraiUketsukeShishoKbn,                                                                                     ");
            sqlContent.AppendLine("     kit.KensaIraiHokenjoCd,                                                                                             ");
            sqlContent.AppendLine("     kit.KensaIraiNendo,                                                                                                 ");
            sqlContent.AppendLine("     kit.KensaIraiRenban,                                                                                                ");
            sqlContent.AppendLine("     kkt.KensaKekkaSuishitsuIraiNo,                                                                                      ");
            sqlContent.AppendLine("     kit.KensaIraiCrossCheckHantei,                                                                                      ");
            sqlContent.AppendLine("     cm1.ConstNm as HanteiCol,                                                                                           ");
            sqlContent.AppendLine("     '' as DaichouShowCol,                                                                                               ");
            sqlContent.AppendLine("     cm2.ConstNm as GaiyouCol,                                                                                           ");
            sqlContent.AppendLine("     kit.KensaIraiCrossCheckRiyu,                                                                                        ");
            sqlContent.AppendLine("     cct.KikitoriTokkijiko,                                                                                              ");
            sqlContent.AppendLine("     case                                                                                                                ");
            sqlContent.AppendLine("         when isnull(cct.KenchikuYoto, '') = '' then km.KenchikuyotoNm                                                   ");
            sqlContent.AppendLine("         else cct.KenchikuYoto                                                                                           ");
            sqlContent.AppendLine("     end as TatemonoYoutoCol,                                                                                            ");
            sqlContent.AppendLine("     case                                                                                                                ");
            sqlContent.AppendLine("         when isdate(cct.KikitoriSeisobi) = 0 then ''                                                                    ");
            sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, cct.KikitoriSeisobi), 111)                                          ");
            sqlContent.AppendLine("     end as KikitoriSeisobi,                                                                                             ");
            sqlContent.AppendLine("     kit.KensaIraiSaisuiinCd,                                                                                            ");
            sqlContent.AppendLine("     sm.SaisuiinNm as SaisuiinNameCol,                                                                                   ");
            sqlContent.AppendLine("     kit.KensaIraiSaisuiGyoshaCd,                                                                                        ");
            sqlContent.AppendLine("     gm.GyoshaNm as ShozokuGyoushaCol,                                                                                   ");
            sqlContent.AppendLine("     kit.KensaIraiShorihoshikiKbn,                                                                                       ");
            sqlContent.AppendLine("     kit.KensaIraiShorihoshikiCd,                                                                                        ");
            sqlContent.AppendLine("     shm.ShoriHoshikiShubetsuNm as ShoriHoushikiCol,                                                                     ");
            sqlContent.AppendLine("     shm.ShoriHoshikiNm as ShoriHoushikiNmCol,                                                                           ");
            sqlContent.AppendLine("     kit.KensaIraiShoriTaishoJinin,                                                                                      ");
            sqlContent.AppendLine("     kkt.KensaKekkaSuisoIonNodo as PHCol,                                                                                ");
            sqlContent.AppendLine("     kkt.KensaKekkaBOD as BODCol,                                                                                        ");
            sqlContent.AppendLine("     kit.KensaIraiJokasoHokenjoCd,                                                                                       ");
            sqlContent.AppendLine("     kit.KensaIraiJokasoTorokuNendo,                                                                                     ");
            sqlContent.AppendLine("     kit.KensaIraiJokasoRenban,                                                                                          ");
            sqlContent.AppendLine("     kkt.KensaKekkaMochikomiDt, -- same as ThisDate                                                                      ");
            sqlContent.AppendLine("     case                                                                                                                ");
            sqlContent.AppendLine("         when isdate(kkt.KensaKekkaMochikomiDt) = 0 then ''                                                              ");
            sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, kkt.KensaKekkaMochikomiDt), 111)                                    ");
            sqlContent.AppendLine("     end as ThisDate,                                                                                                    ");
            sqlContent.AppendLine("     kkt.KensaKekkaSuisoIonNodo as ThisPH,                                                                               ");
            sqlContent.AppendLine("     kkt.KensaKekkaYozonSansoryo1 as ThisYozonSansoRyoFrom,                                                              ");
            sqlContent.AppendLine("     kkt.KensaKekkaYozonSansoryo2 as ThisYozonSansoRyoTo,                                                                ");
            sqlContent.AppendLine("     kkt.KensaKekkaToshido as ThisToshido,                                                                               ");
            sqlContent.AppendLine("     kkt.KensaKekkaToshido2 as ThisToshidoHani,                                                                          ");
            sqlContent.AppendLine("     kkt.KensaKekkaBOD as ThisBOD,                                                                                       ");
            sqlContent.AppendLine("     null as AverageValueCol,                                                                                            ");
            sqlContent.AppendLine("     kkt.KensaKekkaEnsoIonNodo as ThisValue,                                                                             ");
            sqlContent.AppendLine("     -- 過去1");
            sqlContent.AppendLine("     null as PastHoteiKbn1Col,                                                                                           ");
            sqlContent.AppendLine("     null as PastDate1Col,                                                                                               ");
            sqlContent.AppendLine("     null as PastPH1Col,                                                                                                 ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoFrom1Col,                                                                                  ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoTo1Col,                                                                                    ");
            sqlContent.AppendLine("     null as PastToshido1Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastToshidoHani1Col,                                                                                        ");
            sqlContent.AppendLine("     null as PastBOD1Col,                                                                                                ");
            sqlContent.AppendLine("     null as PastBODHani1Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastHyoka1Col,                                                                                              ");
            sqlContent.AppendLine("     null as PastValue1Col,                                                                                              ");
            sqlContent.AppendLine("     -- 過去2");
            sqlContent.AppendLine("     null as PastHoteiKbn2Col,                                                                                           ");
            sqlContent.AppendLine("     null as PastDate2Col,                                                                                               ");
            sqlContent.AppendLine("     null as PastPH2Col,                                                                                                 ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoFrom2Col,                                                                                  ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoTo2Col,                                                                                    ");
            sqlContent.AppendLine("     null as PastToshido2Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastToshidoHani2Col,                                                                                        ");
            sqlContent.AppendLine("     null as PastBOD2Col,                                                                                                ");
            sqlContent.AppendLine("     null as PastBODHani2Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastHyoka2Col,                                                                                              ");
            sqlContent.AppendLine("     null as PastValue2Col,                                                                                              ");
            sqlContent.AppendLine("     -- 過去3");
            sqlContent.AppendLine("     null as PastHoteiKbn3Col,                                                                                           ");
            sqlContent.AppendLine("     null as PastDate3Col,                                                                                               ");
            sqlContent.AppendLine("     null as PastPH3Col,                                                                                                 ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoFrom3Col,                                                                                  ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoTo3Col,                                                                                    ");
            sqlContent.AppendLine("     null as PastToshido3Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastToshidoHani3Col,                                                                                        ");
            sqlContent.AppendLine("     null as PastBOD3Col,                                                                                                ");
            sqlContent.AppendLine("     null as PastBODHani3Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastHyoka3Col,                                                                                              ");
            sqlContent.AppendLine("     null as PastValue3Col,                                                                                              ");
            sqlContent.AppendLine("     -- 過去4");
            sqlContent.AppendLine("     null as PastHoteiKbn4Col,                                                                                           ");
            sqlContent.AppendLine("     null as PastDate4Col,                                                                                               ");
            sqlContent.AppendLine("     null as PastPH4Col,                                                                                                 ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoFrom4Col,                                                                                  ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoTo4Col,                                                                                    ");
            sqlContent.AppendLine("     null as PastToshido4Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastToshidoHani4Col,                                                                                        ");
            sqlContent.AppendLine("     null as PastBOD4Col,                                                                                                ");
            sqlContent.AppendLine("     null as PastBODHani4Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastHyoka4Col,                                                                                              ");
            sqlContent.AppendLine("     null as PastValue4Col,                                                                                              ");
            sqlContent.AppendLine("     -- 過去5");
            sqlContent.AppendLine("     null as PastHoteiKbn5Col,                                                                                           ");
            sqlContent.AppendLine("     null as PastDate5Col,                                                                                               ");
            sqlContent.AppendLine("     null as PastPH5Col,                                                                                                 ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoFrom5Col,                                                                                  ");
            sqlContent.AppendLine("     null as PastYozonSansoRyoTo5Col,                                                                                    ");
            sqlContent.AppendLine("     null as PastToshido5Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastToshidoHani5Col,                                                                                        ");
            sqlContent.AppendLine("     null as PastBOD5Col,                                                                                                ");
            sqlContent.AppendLine("     null as PastBODHani5Col,                                                                                            ");
            sqlContent.AppendLine("     null as PastHyoka5Col,                                                                                              ");
            sqlContent.AppendLine("     null as PastValue5Col,                                                                                              ");
            sqlContent.AppendLine(" -- SQL (3)                                                                                                              ");
            sqlContent.AppendLine("     (                                                                                                                   ");
            sqlContent.AppendLine("     select                                                                                                              ");
            sqlContent.AppendLine("         count(*) as KakuninSuuCol                                                                                       ");
            sqlContent.AppendLine("     from KensaIraiTbl                                                                                                   ");
            sqlContent.AppendLine("     inner join KensaKekkaTbl                                                                                            ");
            sqlContent.AppendLine("         on KensaIraiTbl.KensaIraiHoteiKbn = KensaKekkaTbl.KensaKekkaIraiHoteiKbn                                        ");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd                                     ");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo                                             ");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban                                           ");
            sqlContent.AppendLine("     where                                                                                                               ");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiSaisuiinCd = kit.KensaIraiSaisuiinCd                                                      ");
            sqlContent.AppendLine("         and KensaKekkaTbl.KensaKekkaMochikomiDt <= kkt.KensaKekkaMochikomiDt                                            ");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiCrossCheckHantei > 0                                                                  ");
            sqlContent.AppendLine("     ) as KakuninSuuCol,                                                                                                 ");
            sqlContent.AppendLine(" -- SQL (4)                                                                                                              ");
            sqlContent.AppendLine("     (                                                                                                                   ");
            sqlContent.AppendLine("     select                                                                                                              ");
            sqlContent.AppendLine("         count(*) SoSuuCol                                                                                               ");
            sqlContent.AppendLine("     from KensaIraiTbl                                                                                                   ");
            sqlContent.AppendLine("     inner join KensaKekkaTbl                                                                                            ");
            sqlContent.AppendLine("         on KensaIraiTbl.KensaIraiHoteiKbn = KensaKekkaTbl.KensaKekkaIraiHoteiKbn                                        ");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd                                     ");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo                                             ");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban                                           ");
            sqlContent.AppendLine("     where                                                                                                               ");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiSaisuiinCd = kit.KensaIraiSaisuiinCd                                                      ");
            sqlContent.AppendLine("         and KensaKekkaTbl.KensaKekkaMochikomiDt <= kkt.KensaKekkaMochikomiDt                                            ");
            sqlContent.AppendLine("     ) as SoSuuCol,                                                                                                      ");
            sqlContent.AppendLine("     0.0 as HasseiRateCol,                                                                                               ");
            sqlContent.AppendLine("     kit.UpdateDt as KensaUpdateDt,                                                                                      ");
            sqlContent.AppendLine("     cct.UpdateDt as CrossCheckUpdateDt,                                                                                 ");
            sqlContent.AppendLine("     -- Print data                                                                                                       ");
            sqlContent.AppendLine("     nm.Name,                                                                                                            ");
            sqlContent.AppendLine("     kit.KensaIraiSetchishaNm,                                                                                           ");
            sqlContent.AppendLine("     kit.KensaIraiSetchishaZipCd,                                                                                        ");
            sqlContent.AppendLine("     kit.KensaIraiSetchishaAdr,                                                                                          ");
            sqlContent.AppendLine("     kit.KensaIraiSetchibashoAdr,                                                                                        ");
            sqlContent.AppendLine("     gm.GyoshaTelNo,                                                                                                     ");
            sqlContent.AppendLine("     gm.GyoshaFaxNo,                                                                                                     ");
            sqlContent.AppendLine("     sim.ShishoChoNm,                                                                                                    ");
            sqlContent.AppendLine("     sim.ShishoNm,                                                                                                       ");
            sqlContent.AppendLine("     sim.ShishoTelNo,                                                                                                    ");
            sqlContent.AppendLine("     sim.ShishoFaxNo,                                                                                                    ");
            sqlContent.AppendLine("     gm1.GyoshaNm as MekaGyoshaNm,                                                                                       ");
            sqlContent.AppendLine("     case                                                                                                                ");
            sqlContent.AppendLine("         when jdm.Jokaso3JiShoriFlg = '1' then '有'");
            sqlContent.AppendLine("         else ''                                                                                                         ");
            sqlContent.AppendLine("     end as Jokaso3JiShoriFlg,                                                                                           ");
            sqlContent.AppendLine("     kkt.KensaKekkaMochikomiDt                                                                                           ");
            sqlContent.AppendLine(" from KensaIraiTbl kit                                                                                                   ");
            sqlContent.AppendLine(" inner join KensaKekkaTbl kkt                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn                                                               ");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd                                                            ");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo                                                                    ");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban                                                                  ");
            sqlContent.AppendLine(" left outer join CrossCheckTbl cct                                                                                       ");
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = cct.KensaIraiHoteiKbn                                                                    ");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = cct.KensaIraiHokenjoCd                                                                 ");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = cct.KensaIraiNendo                                                                         ");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = cct.KensaIraiRenban                                                                       ");
            sqlContent.AppendLine(" left outer join ConstMst cm1                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiCrossCheckHantei = cm1.ConstValue                                                                   ");
            sqlContent.AppendLine("     and cm1.ConstKbn = '039'                                                                                            ");
            sqlContent.AppendLine(" left outer join ConstMst cm2                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiCrossCheckRiyu = cm2.ConstValue                                                                     ");
            sqlContent.AppendLine("     and cm2.ConstKbn = '040'                                                                                            ");
            sqlContent.AppendLine(" left outer join SaisuiinMst sm                                                                                          ");
            sqlContent.AppendLine("     on kit.KensaIraiSaisuiinCd = sm.SaisuiinCd                                                                          ");
            sqlContent.AppendLine(" left outer join GyoshaMst gm                                                                                            ");
            sqlContent.AppendLine("     on kit.KensaIraiSaisuiGyoshaCd = gm.GyoshaCd                                                                        ");
            sqlContent.AppendLine(" left outer join ShoriHoshikiMst shm                                                                                     ");
            sqlContent.AppendLine("     on kit.KensaIraiShorihoshikiKbn = shm.ShorihoshikiKbn                                                               ");
            sqlContent.AppendLine("     and kit.KensaIraiShorihoshikiCd = shm.ShorihoshikiCd                                                                ");
            sqlContent.AppendLine(" left outer join KenchikuyotoMst km                                                                                      ");
            sqlContent.AppendLine("     on kit.KenchikuyotoDaibunrui1 = km.KenchikuyotoDaibunrui                                                            ");
            sqlContent.AppendLine("     and kit.KenchikuyotoShobunrui1 = km.KenchikuyotoShobunrui                                                           ");
            sqlContent.AppendLine("     and kit.KenchikuyotoRenban1 = km.KenchikuyotoRenban                                                                 ");
            sqlContent.AppendLine(" -- Data for export EXCEL                                                                                                ");
            sqlContent.AppendLine(" left outer join ShishoMst sim                                                                                           ");
            sqlContent.AppendLine("     on kit.KensaIraiUketsukeShishoKbn = sim.ShishoCd                                                                    ");
            sqlContent.AppendLine(" left outer join NameMst nm                                                                                              ");
            sqlContent.AppendLine("     on kit.KensaIraiHoryusakiCd = nm.NameCd                                                                             ");
            sqlContent.AppendLine("     and nm.DeleteFlg = '1'                                                                                              ");
            sqlContent.AppendLine("     and nm.NameKbn = '001'                                                                                              ");
            sqlContent.AppendLine(" left outer join JokasoDaichoMst jdm                                                                                     ");
            sqlContent.AppendLine("     on kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd                                                               ");
            sqlContent.AppendLine("     and kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo                                                          ");
            sqlContent.AppendLine("     and kit.KensaIraiJokasoRenban = jdm.JokasoRenban                                                                    ");
            sqlContent.AppendLine(" left outer join GyoshaMst gm1                                                                                           ");
            sqlContent.AppendLine("     on jdm.JokasoMekaGyoshaCd = gm1.GyoshaCd                                                                            ");
            sqlContent.AppendLine(" -- End Data for export EXCEL                                                                                            ");
            sqlContent.AppendLine(" where                                                                                                                   ");
            sqlContent.AppendLine("     kit.KensaIraiHoteiKbn = '3'                                                                                         ");
            sqlContent.AppendLine("     and kit.KensaIraiCrossCheckHantei > 0                                                                               ");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = @KensaIraiNendo                                                                            ");
            // 年度(requires)
            commandParams.Add("@KensaIraiNendo", SqlDbType.NVarChar).Value = (string)nendo;
            // 依頼番号（開始）(optional)
            if (!string.IsNullOrEmpty(iraiBangoFrom))
            {
                sqlContent.AppendLine("     and kkt.KensaKekkaSuishitsuIraiNo >= @KensaKekkaSuishitsuIraiNoFrom");
                commandParams.Add("@KensaKekkaSuishitsuIraiNoFrom", SqlDbType.NVarChar).Value = (string)iraiBangoFrom;
            }
            // 依頼番号（終了）(optional)
            if (!string.IsNullOrEmpty(iraiBangoTo))
            {
                sqlContent.AppendLine("     and kkt.KensaKekkaSuishitsuIraiNo <= @KensaKekkaSuishitsuIraiNoTo");
                commandParams.Add("@KensaKekkaSuishitsuIraiNoTo", SqlDbType.NVarChar).Value = (string)iraiBangoTo;
            }

            // Order
            sqlContent.AppendLine(" order by");
            sqlContent.AppendLine("     kkt.KensaKekkaSuishitsuIraiNo");

            #region comments
            /*
            sqlContent.AppendLine(" select");
            sqlContent.AppendLine("     row_number() over(order by kkt.KensaKekkaSuishitsuIraiNo) as RowNoCol,");
            sqlContent.AppendLine("     kit.KensaIraiHoteiKbn,");
            sqlContent.AppendLine("     kit.KensaIraiUketsukeShishoKbn,");
            sqlContent.AppendLine("     kit.KensaIraiHokenjoCd,");
            sqlContent.AppendLine("     kit.KensaIraiNendo,");
            sqlContent.AppendLine("     kit.KensaIraiRenban,");
            sqlContent.AppendLine("     kkt.KensaKekkaSuishitsuIraiNo,");
            sqlContent.AppendLine("     kit.KensaIraiCrossCheckHantei,");
            sqlContent.AppendLine("     cm1.ConstNm as HanteiCol,");
            sqlContent.AppendLine("     '' as DaichouShowCol,");
            sqlContent.AppendLine("     cm2.ConstNm as GaiyouCol,");
            sqlContent.AppendLine("     kit.KensaIraiCrossCheckRiyu,");
            sqlContent.AppendLine("     cct.KikitoriTokkijiko,");
            sqlContent.AppendLine("     case");
            sqlContent.AppendLine("         when isnull(cct.KenchikuYoto, '') = '' then km.KenchikuyotoNm");
            sqlContent.AppendLine("         else cct.KenchikuYoto");
            sqlContent.AppendLine("     end as TatemonoYoutoCol,");
            sqlContent.AppendLine("     case");
            sqlContent.AppendLine("         when isdate(cct.KikitoriSeisobi) = 0 then ''");
            sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, cct.KikitoriSeisobi), 111)");
            sqlContent.AppendLine("     end as KikitoriSeisobi,");
            sqlContent.AppendLine("     kit.KensaIraiSaisuiinCd,");
            sqlContent.AppendLine("     sm.SaisuiinNm as SaisuiinNameCol,");
            sqlContent.AppendLine("     kit.KensaIraiSaisuiGyoshaCd,");
            sqlContent.AppendLine("     gm.GyoshaNm as ShozokuGyoushaCol,");
            sqlContent.AppendLine("     kit.KensaIraiShorihoshikiKbn,");
            sqlContent.AppendLine("     kit.KensaIraiShorihoshikiCd,");
            sqlContent.AppendLine("     shm.ShoriHoshikiShubetsuNm as ShoriHoushikiCol,");
            sqlContent.AppendLine("     shm.ShoriHoshikiNm as ShoriHoushikiNmCol,");
            sqlContent.AppendLine("     kit.KensaIraiShoriTaishoJinin,");
            sqlContent.AppendLine("     kkt.KensaKekkaSuisoIonNodo as PHCol,");
            sqlContent.AppendLine("     kkt.KensaKekkaBOD as BODCol,");
            sqlContent.AppendLine("     kit.KensaIraiJokasoHokenjoCd,");
            sqlContent.AppendLine("     kit.KensaIraiJokasoTorokuNendo,");
            sqlContent.AppendLine("     kit.KensaIraiJokasoRenban,");
            sqlContent.AppendLine("     case");
            sqlContent.AppendLine("         when isdate(kkt.KensaKekkaMochikomiDt) = 0 then ''");
            sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, kkt.KensaKekkaMochikomiDt), 111)");
            sqlContent.AppendLine("     end as ThisDate,");
            sqlContent.AppendLine("     kkt.KensaKekkaSuisoIonNodo as ThisPH,");
            sqlContent.AppendLine("     kkt.KensaKekkaYozonSansoryo1 as ThisYozonSansoRyoFrom,");
            sqlContent.AppendLine("     kkt.KensaKekkaYozonSansoryo2 as ThisYozonSansoRyoTo,");
            sqlContent.AppendLine("     kkt.KensaKekkaToshido as ThisToshido,");
            sqlContent.AppendLine("     kkt.KensaKekkaToshido2 as ThisToshidoHani,");
            sqlContent.AppendLine("     kkt.KensaKekkaBOD as ThisBOD,");
            //sqlContent.AppendLine("     kkt.KensaIraiBOD2 as ThisBODHani,");
            //sqlContent.AppendLine("     (isnull(case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue1Col end, 0)");
            //sqlContent.AppendLine("     + isnull(case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue2Col end, 0)");
            //sqlContent.AppendLine("     + isnull(case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue3Col end, 0)");
            //sqlContent.AppendLine("     + isnull(case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue4Col end, 0)");
            //sqlContent.AppendLine("     + isnull(case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue5Col end, 0)) / 5 as AverageValueCol,");
            sqlContent.AppendLine("     0.0 as AverageValueCol,");
            sqlContent.AppendLine("     kkt.KensaKekkaEnsoIonNodo as ThisValue,");
            sqlContent.AppendLine("     -- 過去1");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHoteiKbn1Col end as PastHoteiKbn1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastDate1Col end as PastDate1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastPH1Col end as PastPH1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoFrom1Col end as PastYozonSansoRyoFrom1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoTo1Col end as PastYozonSansoRyoTo1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshido1Col end as PastToshido1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshidoHani1Col end as PastToshidoHani1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBOD1Col end as PastBOD1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBODHani1Col end as PastBODHani1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHyoka1Col end as PastHyoka1Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate1Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue1Col end as PastValue1Col,");
            sqlContent.AppendLine("     -- 過去2");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHoteiKbn2Col end as PastHoteiKbn2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastDate2Col end as PastDate2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastPH2Col end as PastPH2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoFrom2Col end as PastYozonSansoRyoFrom2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoTo2Col end as PastYozonSansoRyoTo2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshido2Col end as PastToshido2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshidoHani2Col end as PastToshidoHani2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBOD2Col end as PastBOD2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBODHani2Col end as PastBODHani2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHyoka2Col end as PastHyoka2Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate2Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue2Col end as PastValue2Col,");
            sqlContent.AppendLine("     -- 過去3");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHoteiKbn3Col end as PastHoteiKbn3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastDate3Col end as PastDate3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastPH3Col end as PastPH3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoFrom3Col end as PastYozonSansoRyoFrom3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoTo3Col end as PastYozonSansoRyoTo3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshido3Col end as PastToshido3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshidoHani3Col end as PastToshidoHani3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBOD3Col end as PastBOD3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBODHani3Col end as PastBODHani3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHyoka3Col end as PastHyoka3Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate3Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue3Col end as PastValue3Col,");
            sqlContent.AppendLine("     -- 過去4");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHoteiKbn4Col end as PastHoteiKbn4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastDate4Col end as PastDate4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastPH4Col end as PastPH4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoFrom4Col end as PastYozonSansoRyoFrom4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoTo4Col end as PastYozonSansoRyoTo4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshido4Col end as PastToshido4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshidoHani4Col end as PastToshidoHani4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBOD4Col end as PastBOD4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBODHani4Col end as PastBODHani4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHyoka4Col end as PastHyoka4Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate4Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue4Col end as PastValue4Col,");
            sqlContent.AppendLine("     -- 過去5");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHoteiKbn5Col end as PastHoteiKbn5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastDate5Col end as PastDate5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastPH5Col end as PastPH5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoFrom5Col end as PastYozonSansoRyoFrom5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastYozonSansoRyoTo5Col end as PastYozonSansoRyoTo5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshido5Col end as PastToshido5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastToshidoHani5Col end as PastToshidoHani5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBOD5Col end as PastBOD5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastBODHani5Col end as PastBODHani5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastHyoka5Col end as PastHyoka5Col,");
            sqlContent.AppendLine("     case when tbl4.PastDate5Col < kkt.KensaKekkaMochikomiDt then tbl4.PastValue5Col end as PastValue5Col,");
            sqlContent.AppendLine(" -- SQL (3)");
            sqlContent.AppendLine("     (");
            sqlContent.AppendLine("     select");
            sqlContent.AppendLine("         count(*) as KakuninSuuCol");
            sqlContent.AppendLine("     from KensaIraiTbl");
            sqlContent.AppendLine("     inner join KensaKekkaTbl");
            sqlContent.AppendLine("         on KensaIraiTbl.KensaIraiHoteiKbn = KensaKekkaTbl.KensaKekkaIraiHoteiKbn");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban");
            sqlContent.AppendLine("     where");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiSaisuiinCd = kit.KensaIraiSaisuiinCd");
            sqlContent.AppendLine("         and KensaKekkaTbl.KensaKekkaMochikomiDt <= kkt.KensaKekkaMochikomiDt");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiCrossCheckHantei > 0");
            sqlContent.AppendLine("     ) as KakuninSuuCol,");
            sqlContent.AppendLine(" -- SQL (4)");
            sqlContent.AppendLine("     (");
            sqlContent.AppendLine("     select");
            sqlContent.AppendLine("         count(*) SoSuuCol");
            sqlContent.AppendLine("     from KensaIraiTbl");
            sqlContent.AppendLine("     inner join KensaKekkaTbl");
            sqlContent.AppendLine("         on KensaIraiTbl.KensaIraiHoteiKbn = KensaKekkaTbl.KensaKekkaIraiHoteiKbn");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiHokenjoCd = KensaKekkaTbl.KensaKekkaIraiHokenjoCd");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiNendo = KensaKekkaTbl.KensaKekkaIraiNendo");
            sqlContent.AppendLine("         and KensaIraiTbl.KensaIraiRenban = KensaKekkaTbl.KensaKekkaIraiRenban");
            sqlContent.AppendLine("     where ");
            sqlContent.AppendLine("         KensaIraiTbl.KensaIraiSaisuiinCd = kit.KensaIraiSaisuiinCd");
            sqlContent.AppendLine("         and KensaKekkaTbl.KensaKekkaMochikomiDt <= kkt.KensaKekkaMochikomiDt");
            sqlContent.AppendLine("     ) as SoSuuCol,");
            sqlContent.AppendLine("     0.0 as HasseiRateCol,");
            sqlContent.AppendLine("     kit.UpdateDt,");
            sqlContent.AppendLine("     -- Print data");
            sqlContent.AppendLine("     nm.Name,");
            sqlContent.AppendLine("     kit.KensaIraiSetchishaNm,");
            sqlContent.AppendLine("     kit.KensaIraiSetchishaZipCd,");
            sqlContent.AppendLine("     kit.KensaIraiSetchishaAdr,");
            sqlContent.AppendLine("     kit.KensaIraiSetchibashoAdr,");
            sqlContent.AppendLine("     gm.GyoshaTelNo,");
            sqlContent.AppendLine("     gm.GyoshaFaxNo,");
            sqlContent.AppendLine("     sim.ShishoChoNm,");
            sqlContent.AppendLine("     sim.ShishoNm,");
            sqlContent.AppendLine("     sim.ShishoTelNo,");
            sqlContent.AppendLine("     sim.ShishoFaxNo");
            sqlContent.AppendLine(" from KensaIraiTbl kit");
            sqlContent.AppendLine(" inner join KensaKekkaTbl kkt");
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban");
            sqlContent.AppendLine(" left outer join CrossCheckTbl cct");
            sqlContent.AppendLine("     on kit.KensaIraiHoteiKbn = cct.KensaIraiHoteiKbn");
            sqlContent.AppendLine("     and kit.KensaIraiHokenjoCd = cct.KensaIraiHokenjoCd");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = cct.KensaIraiNendo");
            sqlContent.AppendLine("     and kit.KensaIraiRenban = cct.KensaIraiRenban");
            sqlContent.AppendLine(" left outer join ConstMst cm1");
            sqlContent.AppendLine("     on kit.KensaIraiCrossCheckHantei = cm1.ConstValue");
            sqlContent.AppendLine("     and cm1.ConstKbn = '039'");
            sqlContent.AppendLine(" left outer join ConstMst cm2");
            sqlContent.AppendLine("     on kit.KensaIraiCrossCheckRiyu = cm2.ConstValue");
            sqlContent.AppendLine("     and cm2.ConstKbn = '040'");
            sqlContent.AppendLine(" left outer join SaisuiinMst sm");
            sqlContent.AppendLine("     on kit.KensaIraiSaisuiinCd = sm.SaisuiinCd");
            sqlContent.AppendLine(" left outer join GyoshaMst gm");
            sqlContent.AppendLine("     on kit.KensaIraiSaisuiGyoshaCd = gm.GyoshaCd");
            sqlContent.AppendLine(" left outer join ShoriHoshikiMst shm");
            sqlContent.AppendLine("     on kit.KensaIraiShorihoshikiKbn = shm.ShorihoshikiKbn");
            sqlContent.AppendLine("     and kit.KensaIraiShorihoshikiCd = shm.ShorihoshikiCd");
            sqlContent.AppendLine(" left outer join KenchikuyotoMst km");
            sqlContent.AppendLine("     on kit.KenchikuyotoDaibunrui1 = km.KenchikuyotoDaibunrui");
            sqlContent.AppendLine("     and kit.KenchikuyotoShobunrui1 = km.KenchikuyotoShobunrui");
            sqlContent.AppendLine("     and kit.KenchikuyotoRenban1 = km.KenchikuyotoRenban");
            sqlContent.AppendLine(" -- Data for export EXCEL");
            sqlContent.AppendLine(" left outer join ShishoMst sim");
            sqlContent.AppendLine("     on kit.KensaIraiUketsukeShishoKbn = sim.ShishoCd");
            sqlContent.AppendLine(" left outer join NameMst nm");
            sqlContent.AppendLine("     on kit.KensaIraiHoryusakiCd = nm.NameCd");
            sqlContent.AppendLine("     and nm.DeleteFlg = '1'");
            sqlContent.AppendLine("     and nm.NameKbn = '001'");
            sqlContent.AppendLine(" -- End Data for export EXCEL");
            sqlContent.AppendLine(" -- SQL (2) - detail design");
            sqlContent.AppendLine(" left outer join");
            sqlContent.AppendLine(" (");
            sqlContent.AppendLine("     select");
            sqlContent.AppendLine("         tbl3.KensaIraiJokasoHokenjoCd,");
            sqlContent.AppendLine("         tbl3.KensaIraiJokasoTorokuNendo,");
            sqlContent.AppendLine("         tbl3.KensaIraiJokasoRenban,");
            sqlContent.AppendLine("         -- 過去1");
            sqlContent.AppendLine("         max(tbl3.PastHoteiKbn1Col) as PastHoteiKbn1Col,");
            sqlContent.AppendLine("         max(tbl3.PastDate1Col) as PastDate1Col,");
            sqlContent.AppendLine("         max(tbl3.PastPH1Col) as PastPH1Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoFrom1Col) as PastYozonSansoRyoFrom1Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoTo1Col) as PastYozonSansoRyoTo1Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshido1Col) as PastToshido1Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshidoHani1Col) as PastToshidoHani1Col,");
            sqlContent.AppendLine("         max(tbl3.PastBOD1Col) as PastBOD1Col,");
            sqlContent.AppendLine("         max(tbl3.PastBODHani1Col) as PastBODHani1Col,");
            sqlContent.AppendLine("         max(tbl3.PastHyoka1Col) as PastHyoka1Col,");
            sqlContent.AppendLine("         max(tbl3.PastValue1Col) as PastValue1Col,");
            sqlContent.AppendLine("         -- 過去2");
            sqlContent.AppendLine("         max(tbl3.PastHoteiKbn2Col) as PastHoteiKbn2Col,");
            sqlContent.AppendLine("         max(tbl3.PastDate2Col) as PastDate2Col,");
            sqlContent.AppendLine("         max(tbl3.PastPH2Col) as PastPH2Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoFrom2Col) as PastYozonSansoRyoFrom2Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoTo2Col) as PastYozonSansoRyoTo2Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshido2Col) as PastToshido2Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshidoHani2Col) as PastToshidoHani2Col,");
            sqlContent.AppendLine("         max(tbl3.PastBOD2Col) as PastBOD2Col,");
            sqlContent.AppendLine("         max(tbl3.PastBODHani2Col) as PastBODHani2Col,");
            sqlContent.AppendLine("         max(tbl3.PastHyoka2Col) as PastHyoka2Col,");
            sqlContent.AppendLine("         max(tbl3.PastValue2Col) as PastValue2Col,");
            sqlContent.AppendLine("         -- 過去3");
            sqlContent.AppendLine("         max(tbl3.PastHoteiKbn3Col) as PastHoteiKbn3Col,");
            sqlContent.AppendLine("         max(tbl3.PastDate3Col) as PastDate3Col,");
            sqlContent.AppendLine("         max(tbl3.PastPH3Col) as PastPH3Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoFrom3Col) as PastYozonSansoRyoFrom3Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoTo3Col) as PastYozonSansoRyoTo3Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshido3Col) as PastToshido3Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshidoHani3Col) as PastToshidoHani3Col,");
            sqlContent.AppendLine("         max(tbl3.PastBOD3Col) as PastBOD3Col,");
            sqlContent.AppendLine("         max(tbl3.PastBODHani3Col) as PastBODHani3Col,");
            sqlContent.AppendLine("         max(tbl3.PastHyoka3Col) as PastHyoka3Col,");
            sqlContent.AppendLine("         max(tbl3.PastValue3Col) as PastValue3Col,");
            sqlContent.AppendLine("         -- 過去4");
            sqlContent.AppendLine("         max(tbl3.PastHoteiKbn4Col) as PastHoteiKbn4Col,");
            sqlContent.AppendLine("         max(tbl3.PastDate4Col) as PastDate4Col,");
            sqlContent.AppendLine("         max(tbl3.PastPH4Col) as PastPH4Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoFrom4Col) as PastYozonSansoRyoFrom4Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoTo4Col) as PastYozonSansoRyoTo4Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshido4Col) as PastToshido4Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshidoHani4Col) as PastToshidoHani4Col,");
            sqlContent.AppendLine("         max(tbl3.PastBOD4Col) as PastBOD4Col,");
            sqlContent.AppendLine("         max(tbl3.PastBODHani4Col) as PastBODHani4Col,");
            sqlContent.AppendLine("         max(tbl3.PastHyoka4Col) as PastHyoka4Col,");
            sqlContent.AppendLine("         max(tbl3.PastValue4Col) as PastValue4Col,");
            sqlContent.AppendLine("         -- 過去5");
            sqlContent.AppendLine("         max(tbl3.PastHoteiKbn5Col) as PastHoteiKbn5Col,");
            sqlContent.AppendLine("         max(tbl3.PastDate5Col) as PastDate5Col,");
            sqlContent.AppendLine("         max(tbl3.PastPH5Col) as PastPH5Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoFrom5Col) as PastYozonSansoRyoFrom5Col,");
            sqlContent.AppendLine("         max(tbl3.PastYozonSansoRyoTo5Col) as PastYozonSansoRyoTo5Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshido5Col) as PastToshido5Col,");
            sqlContent.AppendLine("         max(tbl3.PastToshidoHani5Col) as PastToshidoHani5Col,");
            sqlContent.AppendLine("         max(tbl3.PastBOD5Col) as PastBOD5Col,");
            sqlContent.AppendLine("         max(tbl3.PastBODHani5Col) as PastBODHani5Col,");
            sqlContent.AppendLine("         max(tbl3.PastHyoka5Col) as PastHyoka5Col,");
            sqlContent.AppendLine("         max(tbl3.PastValue5Col) as PastValue5Col");
            sqlContent.AppendLine("     from");
            sqlContent.AppendLine("     (");
            sqlContent.AppendLine("         select");
            sqlContent.AppendLine("             tbl2.KensaIraiJokasoHokenjoCd,");
            sqlContent.AppendLine("             tbl2.KensaIraiJokasoTorokuNendo,");
            sqlContent.AppendLine("             tbl2.KensaIraiJokasoRenban,");
            sqlContent.AppendLine("             -- 過去1");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaIraiHoteiKbn end as PastHoteiKbn1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaMochikomiDt end as PastDate1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaSuisoIonNodo end as PastPH1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaYozonSansoryo1 end as PastYozonSansoRyoFrom1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaYozonSansoryo2 end as PastYozonSansoRyoTo1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaToshido end as PastToshido1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaToshido2 end as PastToshidoHani1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaBOD end as PastBOD1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaIraiBOD2 end as PastBODHani1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaEnsoIonNodoHantei end as PastHyoka1Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 1 then tbl2.KensaKekkaEnsoIonNodo end as PastValue1Col,");
            sqlContent.AppendLine("             --過去2");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaIraiHoteiKbn end as PastHoteiKbn2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaMochikomiDt end as PastDate2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaSuisoIonNodo end as PastPH2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaYozonSansoryo1 end as PastYozonSansoRyoFrom2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaYozonSansoryo2 end as PastYozonSansoRyoTo2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaToshido end as PastToshido2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaToshido2 end as PastToshidoHani2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaBOD end as PastBOD2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaIraiBOD2 end as PastBODHani2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaEnsoIonNodoHantei end as PastHyoka2Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 2 then tbl2.KensaKekkaEnsoIonNodo end as PastValue2Col,");
            sqlContent.AppendLine("             --過去3");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaIraiHoteiKbn end as PastHoteiKbn3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaMochikomiDt end as PastDate3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaSuisoIonNodo end as PastPH3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaYozonSansoryo1 end as PastYozonSansoRyoFrom3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaYozonSansoryo2 end as PastYozonSansoRyoTo3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaToshido end as PastToshido3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaToshido2 end as PastToshidoHani3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaBOD end as PastBOD3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaIraiBOD2 end as PastBODHani3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaEnsoIonNodoHantei end as PastHyoka3Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 3 then tbl2.KensaKekkaEnsoIonNodo end as PastValue3Col,");
            sqlContent.AppendLine("             --過去4");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaIraiHoteiKbn end as PastHoteiKbn4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaMochikomiDt end as PastDate4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaSuisoIonNodo end as PastPH4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaYozonSansoryo1 end as PastYozonSansoRyoFrom4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaYozonSansoryo2 end as PastYozonSansoRyoTo4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaToshido end as PastToshido4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaToshido2 end as PastToshidoHani4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaBOD end as PastBOD4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaIraiBOD2 end as PastBODHani4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaEnsoIonNodoHantei end as PastHyoka4Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 4 then tbl2.KensaKekkaEnsoIonNodo end as PastValue4Col,");
            sqlContent.AppendLine("             --過去5");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaIraiHoteiKbn end as PastHoteiKbn5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaMochikomiDt end as PastDate5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaSuisoIonNodo end as PastPH5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaYozonSansoryo1 end as PastYozonSansoRyoFrom5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaYozonSansoryo2 end as PastYozonSansoRyoTo5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaToshido end as PastToshido5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaToshido2 end as PastToshidoHani5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaBOD end as PastBOD5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaIraiBOD2 end as PastBODHani5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaEnsoIonNodoHantei end as PastHyoka5Col,");
            sqlContent.AppendLine("             case when tbl2.RowNoCol = 5 then tbl2.KensaKekkaEnsoIonNodo end as PastValue5Col");
            sqlContent.AppendLine("         from");
            sqlContent.AppendLine("         (");
            sqlContent.AppendLine("             select");
            sqlContent.AppendLine("                 row_number() over(partition by");
            sqlContent.AppendLine("                     kit.KensaIraiJokasoHokenjoCd,");
            sqlContent.AppendLine("                     kit.KensaIraiJokasoTorokuNendo,");
            sqlContent.AppendLine("                     kit.KensaIraiJokasoRenban");
            sqlContent.AppendLine("                 order by");
            sqlContent.AppendLine("                     kkt.KensaKekkaMochikomiDt desc) as RowNoCol,");
            sqlContent.AppendLine("                 kit.KensaIraiHoteiKbn,");
            sqlContent.AppendLine("                 kkt.KensaKekkaMochikomiDt,");
            sqlContent.AppendLine("                 kkt.KensaKekkaSuisoIonNodo,");
            sqlContent.AppendLine("                 kkt.KensaKekkaYozonSansoryo1,");
            sqlContent.AppendLine("                 kkt.KensaKekkaYozonSansoryo2,");
            sqlContent.AppendLine("                 kkt.KensaKekkaToshido,");
            sqlContent.AppendLine("                 kkt.KensaKekkaToshido2,");
            sqlContent.AppendLine("                 kkt.KensaKekkaBOD,");
            sqlContent.AppendLine("                 kkt.KensaIraiBOD2,");
            sqlContent.AppendLine("                 kkt.KensaKekkaEnsoIonNodoHantei,");
            sqlContent.AppendLine("                 kkt.KensaKekkaEnsoIonNodo,");
            sqlContent.AppendLine("                 -- Key");
            sqlContent.AppendLine("                 kit.KensaIraiJokasoHokenjoCd,");
            sqlContent.AppendLine("                 kit.KensaIraiJokasoTorokuNendo,");
            sqlContent.AppendLine("                 kit.KensaIraiJokasoRenban");
            sqlContent.AppendLine("             from KensaIraiTbl kit");
            sqlContent.AppendLine("             inner join KensaKekkaTbl kkt");
            sqlContent.AppendLine("                 on kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn");
            sqlContent.AppendLine("                 and kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd");
            sqlContent.AppendLine("                 and kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo");
            sqlContent.AppendLine("                 and kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban");
            sqlContent.AppendLine("         ) tbl2");
            sqlContent.AppendLine("     ) tbl3");
            sqlContent.AppendLine("     group by");
            sqlContent.AppendLine("         tbl3.KensaIraiJokasoHokenjoCd,");
            sqlContent.AppendLine("         tbl3.KensaIraiJokasoTorokuNendo,");
            sqlContent.AppendLine("         tbl3.KensaIraiJokasoRenban");
            sqlContent.AppendLine(" ) tbl4");
            sqlContent.AppendLine("     on kit.KensaIraiJokasoHokenjoCd = tbl4.KensaIraiJokasoHokenjoCd");
            sqlContent.AppendLine("     and kit.KensaIraiJokasoTorokuNendo = tbl4.KensaIraiJokasoTorokuNendo");
            sqlContent.AppendLine("     and kit.KensaIraiJokasoRenban = tbl4.KensaIraiJokasoRenban");
            sqlContent.AppendLine(" where");
            sqlContent.AppendLine("     kit.KensaIraiHoteiKbn = '3'");
            sqlContent.AppendLine("     and kit.KensaIraiCrossCheckHantei > 0");
            sqlContent.AppendLine("     and kit.KensaIraiNendo = @KensaIraiNendo");
            // 年度(requires)
            commandParams.Add("@KensaIraiNendo", SqlDbType.NVarChar).Value = (string)nendo;
            // 依頼番号（開始）(optional)
            if (!string.IsNullOrEmpty(iraiBangoFrom))
            {
                sqlContent.AppendLine("     and kkt.KensaKekkaSuishitsuIraiNo >= @KensaKekkaSuishitsuIraiNoFrom");
                commandParams.Add("@KensaKekkaSuishitsuIraiNoFrom", SqlDbType.NVarChar).Value = (string)iraiBangoFrom;
            }
            // 依頼番号（終了）(optional)
            if (!string.IsNullOrEmpty(iraiBangoTo))
            {
                sqlContent.AppendLine("     and kkt.KensaKekkaSuishitsuIraiNo <= @KensaKekkaSuishitsuIraiNoTo");
                commandParams.Add("@KensaKekkaSuishitsuIraiNoTo", SqlDbType.NVarChar).Value = (string)iraiBangoTo;
            }

            // Order
            sqlContent.AppendLine(" order by");
            sqlContent.AppendLine("     kkt.KensaKekkaSuishitsuIraiNo");
            */
            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaRirekiListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaRirekiListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/30　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaRirekiListTableAdapter {

        #region GetDataByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiJokasoHokenjoCd"></param>
        /// <param name="kensaIraiJokasoTorokuNendo"></param>
        /// <param name="kensaIraiJokasoRenban"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKekkaTblDataSet.KensaRirekiListDataTable GetDataByCond(string kensaIraiJokasoHokenjoCd,
                                                                                string kensaIraiJokasoTorokuNendo,
                                                                                string kensaIraiJokasoRenban)
        {
            SqlCommand command = CreateSqlCommand(kensaIraiJokasoHokenjoCd,
                                                    kensaIraiJokasoTorokuNendo,
                                                    kensaIraiJokasoRenban);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaKekkaTblDataSet.KensaRirekiListDataTable dataTable = new KensaKekkaTblDataSet.KensaRirekiListDataTable();
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
        /// <param name="kensaIraiJokasoHokenjoCd"></param>
        /// <param name="kensaIraiJokasoTorokuNendo"></param>
        /// <param name="kensaIraiJokasoRenban"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　HuyTX　　新規作成
        /// 2014/10/08　HuyTX　　Ver1.03
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string kensaIraiJokasoHokenjoCd,
                                            string kensaIraiJokasoTorokuNendo,
                                            string kensaIraiJokasoRenban)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT ");
            sqlContent.Append("         ROW_NUMBER() OVER(ORDER BY KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban ASC) AS RowNumber, ");
            sqlContent.Append("         kit.KensaIraiHoteiKbn, ");
            sqlContent.Append("         kit.KensaIraiHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiNendo, ");
            sqlContent.Append("         kit.KensaIraiRenban, ");
            sqlContent.Append("         cm.ConstNm, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', REPLACE(STR(kit.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiRenban) AS KensaIraiNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo), '-', kit.KensaIraiRenban) AS KensaIraiNo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISDATE(CONCAT(kit.KensaIraiKensaNen,kit.KensaIraiKensaTsuki,kit.KensaIraiKensaBi)) = 0 THEN '' ");
            sqlContent.Append("             ELSE CONVERT(CHAR(10), CONVERT(DATETIME,CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi)), 111) ");
            sqlContent.Append("         END AS KensaDt, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISDATE(kit.KensaIraiSofuDt) = 0 THEN '' ");
            sqlContent.Append("             ELSE CONVERT(CHAR(10), CONVERT(DATETIME, kit.KensaIraiSofuDt), 111) ");
            sqlContent.Append("         END AS KensaIraiSofuDt, ");
            sqlContent.Append("         sm.ShokuinNm, ");
            sqlContent.Append("         CASE kkt.KensaKekkaHantei WHEN 1 THEN '○' WHEN 2 THEN '△' WHEN 3 THEN '×' END AS KensaKekkaHantei, ");
            sqlContent.Append("         CASE  ");
            sqlContent.Append("             WHEN ISNULL(kkt.KensaKekkaSuisoIonNodo, '') = '' THEN '－' ");
            sqlContent.Append("             ELSE CONCAT(kkt.KensaKekkaSuisoIonNodo, '') ");
            sqlContent.Append("         END AS KensaKekkaSuisoIonNodo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kkt.KensaKekkaYozonSansoryo1, '') = '' THEN '－' ");
            sqlContent.Append("             ELSE CONCAT(kkt.KensaKekkaYozonSansoryo1, '') ");
            sqlContent.Append("         END AS KensaKekkaYozonSansoryo1, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kkt.KensaKekkaToshido, '') = '' THEN '－' ");
            sqlContent.Append("             ELSE CONCAT(kkt.KensaKekkaToshido, '') ");
            sqlContent.Append("         END AS KensaKekkaToshido, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kkt.KensaKekkaZanryuEnsoNodo, '') = '' THEN '－' ");
            sqlContent.Append("             ELSE CONCAT(kkt.KensaKekkaZanryuEnsoNodo, '') ");
            sqlContent.Append("         END AS KensaKekkaZanryuEnsoNodo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kkt.KensaKekkaBOD, '') = '' THEN '－' ");
            sqlContent.Append("             ELSE CONCAT(kkt.KensaKekkaBOD, '') ");
            sqlContent.Append("         END AS KensaKekkaBOD, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN kkt.KensaKekkaEnsoIonNodo IS NULL THEN '－' ");
            sqlContent.Append("             ELSE CONCAT(kkt.KensaKekkaEnsoIonNodo, '') ");
            sqlContent.Append("         END AS KensaKekkaEnsoIonNodo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN kit.KensaIraiStatusKbn = '99' THEN '○' ");
            sqlContent.Append("             ELSE '' ");
            sqlContent.Append("         END AS KensaIraiStatusKbn, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', REPLACE(STR(kit.KensaIraiJokasoTorokuNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiJokasoTorokuNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiJokasoRenban) AS JokasoCd, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiJokasoTorokuNendo, 'yy', 1), '-', kit.KensaIraiJokasoRenban) AS JokasoCd, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiJokasoTorokuNendo), '-', kit.KensaIraiJokasoRenban) AS JokasoCd, ");

            sqlContent.Append("         jdm.JokasoSetchishaNm, ");
            sqlContent.Append("         jdm.JokasoShoriTaishoJinin, ");
            sqlContent.Append("         jdm.JokasoSetchiBashoAdr, ");
            sqlContent.Append("         shm.ShoriHoshikiShubetsuNm, ");
            sqlContent.Append("         shm.ShoriHoshikiNm, ");
            sqlContent.Append("         gm1.GyoshaNm AS JokasoKojiGyoshaKbn, ");
            sqlContent.Append("         gm2.GyoshaNm AS JokasoHoshutenkenGyoshaCd ");

            //FROM
            sqlContent.Append(" FROM KensaIraiTbl kit ");
            
            //JOIN
            sqlContent.Append("         LEFT OUTER JOIN ConstMst cm ");
            sqlContent.Append("                         ON (kit.KensaIraiHoteiKbn = cm.ConstValue ");
            sqlContent.Append("                             AND cm.ConstKbn = '006' ");
            sqlContent.Append("                             AND (ISNULL(kit.KensaIraiScreeningKbn, '') = '' OR kit.KensaIraiScreeningKbn = '0')) ");
            sqlContent.Append("                         OR (kit.KensaIraiScreeningKbn = cm.ConstValue  ");
            sqlContent.Append("                             AND cm.ConstKbn = '024' ");
            sqlContent.Append("                             AND (ISNULL(kit.KensaIraiScreeningKbn, '') <> '' OR kit.KensaIraiScreeningKbn <> '0')) ");
            sqlContent.Append("         LEFT OUTER JOIN ShokuinMst sm ");
            sqlContent.Append("                         ON kit.KensaIraiKensaTantoshaCd = sm.ShokuinCd ");
            sqlContent.Append("         LEFT OUTER JOIN KensaKekkaTbl kkt  ");
            sqlContent.Append("                         ON kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("                         AND kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("                         AND kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo ");
            sqlContent.Append("                         AND kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban ");
            sqlContent.Append("         LEFT OUTER JOIN JokasoDaichoMst jdm  ");
            sqlContent.Append("                         ON kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            sqlContent.Append("                         AND kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            sqlContent.Append("                         AND kit.KensaIraiJokasoRenban = jdm.JokasoRenban ");
            sqlContent.Append("         LEFT OUTER JOIN ShoriHoshikiMst shm ON jdm.JokasoShoriHosikiKbn = shm.ShoriHoshikiKbn ");
            sqlContent.Append("                         AND jdm.JokasoShoriHosikiCd = shm.ShoriHoshikiCd ");
            sqlContent.Append("         LEFT OUTER JOIN GyoshaMst gm1 ");
            sqlContent.Append("                         ON gm1.GyoshaCd = jdm.JokasoKojiGyoshaKbn ");
            sqlContent.Append("         LEFT OUTER JOIN GyoshaMst gm2 ");
            sqlContent.Append("                         ON gm2.GyoshaCd = jdm.JokasoHoshutenkenGyoshaCd ");

            //WHERE
            sqlContent.Append(" WHERE  ");
            sqlContent.Append("         kit.KensaIraiJokasoHokenjoCd = @kensaIraiJokasoHokenjoCd ");
            sqlContent.Append("         AND kit.KensaIraiJokasoTorokuNendo = @kensaIraiJokasoTorokuNendo ");
            sqlContent.Append("         AND kit.KensaIraiJokasoRenban = @kensaIraiJokasoRenban ");

            //ORDER BY
            sqlContent.Append(" ORDER BY ");
            sqlContent.Append("         kit.KensaIraiHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiNendo, ");
            sqlContent.Append("         kit.KensaIraiRenban ");

            //set params value
            commandParams.Add("@kensaIraiJokasoHokenjoCd", SqlDbType.NVarChar).Value = kensaIraiJokasoHokenjoCd;
            commandParams.Add("@kensaIraiJokasoTorokuNendo", SqlDbType.NVarChar).Value = kensaIraiJokasoTorokuNendo;
            commandParams.Add("@kensaIraiJokasoRenban", SqlDbType.NVarChar).Value = kensaIraiJokasoRenban;

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaKekkaInputListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　DatNT　　 新規作成
    /// 2015/01/14　AnhNV　　 v1.04
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaKekkaInputListTableAdapter
    {
        #region GetDataByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKekkaTblDataSet.KensaKekkaInputListDataTable GetDataByCond(KensaKekkaInputListSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaKekkaTblDataSet.KensaKekkaInputListDataTable dataTable = new KensaKekkaTblDataSet.KensaKekkaInputListDataTable();
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
        /// 2014/09/05　DatNT　　新規作成
        /// 2014/10/08  DatNT     v1.01
        /// 2014/11/04  HuyTX     Ver1.03
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// 2014/12/26  小松　　　　TOP(2000)対応（索引[KensaIraiTbl_IDX5_TEST]追加）
        /// 2015/01/14　AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaKekkaInputListSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region SELECT

            sqlContent.Append(" SELECT                                                                                                                  ");
            sqlContent.Append("   TOP(2000)                                                                                                             ");
            sqlContent.Append("         ROW_NUMBER() OVER(ORDER BY                                                                                      ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiKensaNen,                                                         ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiKensaTsuki,                                                       ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiKensaBi,                                                          ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiHoteiKbn,                                                         ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiHokenjoCd,                                                        ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiNendo,                                                            ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiRenban) AS RowNumber,                                             ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHoteiKbn,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHokenjoCd,                                                                                ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiNendo,                                                                                    ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiRenban,                                                                                   ");
            //sqlContent.Append("         CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                    ");
            //sqlContent.Append("                 CAST(KensaIraiTbl.KensaIraiNendo AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), '-', ");
            //sqlContent.Append("                 KensaIraiRenban) AS kyokaiNoCol,                                                                        ");
            sqlContent.Append("         CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                    ");
            //sqlContent.Append("                 [dbo].[FuncConvertToWareki](KensaIraiTbl.KensaIraiNendo, 'yy', 1), '-',                                 ");
            sqlContent.Append("                 [dbo].[FuncConvertIraiNedoToWareki](KensaIraiTbl.KensaIraiNendo), '-',                                  ");
            sqlContent.Append("                 KensaIraiRenban) AS kyokaiNoCol,                                                                        ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaNen,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaTsuki,                                                                               ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaBi,                                                                                  ");
            sqlContent.Append("         CASE                                                                                                            ");
            sqlContent.Append("             WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, '') = ''                                                        ");
            sqlContent.Append("                     AND ISNULL(KensaIraiTbl.KensaIraiKensaTsuki, '') = ''                                               ");
            sqlContent.Append("                     AND ISNULL(KensaIraiTbl.KensaIraiKensaBi, '') = '' THEN ''                                          ");
            //sqlContent.Append("             ELSE CONCAT(CAST(KensaIraiTbl.KensaIraiKensaNen AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) ORDER BY KaishiDt DESC), '/', ");
            sqlContent.Append("             ELSE CONCAT(KensaIraiTbl.KensaIraiKensaNen, '/', ");
            sqlContent.Append("                         KensaIraiTbl.KensaIraiKensaTsuki, '/',                                                          ");
            sqlContent.Append("                         KensaIraiTbl.KensaIraiKensaBi)                                                                  ");
            sqlContent.Append("             END AS yoteiDtCol,                                                                                          ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiSetchishaNm,                                                                              ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiSetchibashoAdr,                                                                           ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiSetchishaKana,                                                                            ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiShoritaishoJinin,                                                                         ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiShorihoshikiKbn,                                                                          ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiShorihoshikiCd,                                                                           ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHakkoKbn10,                                                                               ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaTantoshaCd,                                                                          ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaKanryoKbn,                                                                           ");
            sqlContent.Append("         KensaIraiTbl.KensaIrai7joHoryuKbn,                                                                              ");
            sqlContent.Append("         KensaIraiTbl.KensaIrai7joHoryuKakuninDt,                                                                        ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiJokasoHokenjoCd,                                                                         ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiJokasoTorokuNendo,                                                                       ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiJokasoRenban,                                                                            ");
            sqlContent.Append("         CASE                                                                                                            ");
            sqlContent.Append("             WHEN ISNULL(KensaIraiTbl.KensaIrai7joHoryuKakuninDt, '') = '' THEN ''                                       ");
            //sqlContent.Append("             ELSE CONCAT(CAST (SUBSTRING(KensaIraiTbl.KensaIrai7joHoryuKakuninDt, 0, 5) AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= KensaIraiTbl.KensaIrai7joHoryuKakuninDt ORDER BY KaishiDt DESC), '/', ");
            sqlContent.Append("             ELSE CONCAT(SUBSTRING(KensaIraiTbl.KensaIrai7joHoryuKakuninDt, 0, 5), '/', ");
            sqlContent.Append("                         SUBSTRING(KensaIraiTbl.KensaIrai7joHoryuKakuninDt, 5, 2), '/',                                  ");
            sqlContent.Append("                         SUBSTRING(KensaIraiTbl.KensaIrai7joHoryuKakuninDt, 7, 2))                                       ");
            sqlContent.Append("             END AS horyuDtCol,                                                                                          ");
            sqlContent.Append("         KensaKekkaTbl.KensaKekkaHantei,                                                                                 ");
            sqlContent.Append("         KensaKekkaTbl.KensaKekkaBOD,                                                                                    ");
            sqlContent.Append("         KensaKekkaTbl.KensaKekkaZanryuEnsoNodo,                                                                         ");
            // 2014/10/31 AnhNV ADD Start
            sqlContent.Append("         KensaKekkaTbl.KensaKekkaMochikomiDt,                                                                            ");
            // 2014/10/31 AnhNV ADD End
            sqlContent.Append("         ShoriHoshikiMst.ShoriHoshikiShubetsuNm,                                                                         ");
            //sqlContent.Append("         const1.ConstNm AS kensaSyubetsuCol,                                                                             ");
            sqlContent.Append("         CASE                                                                             ");
            sqlContent.Append("             WHEN KensaIraiTbl.KensaIraiScreeningKbn = '0' THEN const1.ConstNm                                                                            ");
            sqlContent.Append("             ELSE const3.ConstNm                                                                            ");
            sqlContent.Append("         END AS kensaSyubetsuCol,                                                                             ");
            sqlContent.Append("         const2.ConstNm AS hanteiCol,                                                                                     ");
            //20150123 HuyTX Ver1.05 Start
            sqlContent.Append("         gm.GyoshaNm AS iraiGyoshaCol ");
            //End

            #endregion

            #region FROM

            sqlContent.Append(" FROM                                                                                                                    ");
            sqlContent.Append("         KensaIraiTbl                                                                                                    ");
            sqlContent.Append(" LEFT OUTER JOIN KensaKekkaTbl                                                                                           ");
            sqlContent.Append("                 ON KensaKekkaTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn                                ");
            sqlContent.Append("                 AND KensaKekkaTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd                             ");
            sqlContent.Append("                 AND KensaKekkaTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo                                     ");
            sqlContent.Append("                 AND KensaKekkaTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban                                   ");
            sqlContent.Append(" LEFT OUTER JOIN ShoriHoshikiMst                                                                                         ");
            sqlContent.Append("                 ON ShoriHoshikiMst.ShoriHoshikiKbn = KensaIraiTbl.KensaIraiShorihoshikiKbn                              ");
            sqlContent.Append("                 AND ShoriHoshikiMst.ShoriHoshikiCd = KensaIraiTbl.KensaIraiShorihoshikiCd                               ");

            //Ver1.03_20141104_HuyTX Start
            //sqlContent.Append(" LEFT OUTER JOIN ConstMst const1                                                                                         ");
            //sqlContent.Append("                 ON const1.ConstKbn = '006' AND const1.ConstValue = KensaIraiTbl.KensaIraiHoteiKbn                       ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const1 ON KensaIraiTbl.KensaIraiHoteiKbn = const1.ConstValue                                  ");
            sqlContent.Append("                                 AND const1.ConstKbn = '006'                                                             ");
            //sqlContent.Append("                                 AND KensaIraiTbl.KensaIraiScreeningKbn = '0'                                           ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst const3 ON KensaIraiTbl.KensaIraiScreeningKbn = const3.ConstValue                                  ");
            sqlContent.Append("                                 AND const3.ConstKbn = '024'                                                             ");
            //sqlContent.Append("                                 AND KensaIraiTbl.KensaIraiScreeningKbn <> '0'                                          ");
            //Ver1.03 End

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const2                                                                                         ");
            sqlContent.Append("                 ON const2.ConstKbn = '016' AND const2.ConstValue = KensaKekkaTbl.KensaKekkaHantei                       ");

            // 2015/01/14 AnhNV ADD Start
            sqlContent.Append(" left outer join GyoshaMst gm                                                                                            ");
            sqlContent.Append("     on KensaIraiTbl.KensaIraiHoshutenkenGyoshaCd = gm.GyoshaCd                                                          ");
            // 2015/01/14 AnhNV ADD End

            #endregion

            #region WHERE

            sqlContent.Append(" WHERE                                                                                                                   ");
            // 20141226 habu Mod Fixed(Index seek didn't work)
            sqlContent.Append("        KensaIraiTbl.KensaIraiStatusKbn >= '40'                                                               ");
            sqlContent.Append("        AND KensaIraiTbl.KensaIraiStatusKbn < '90'                                                            ");
            // 20141226 End

            //Ver1.01 Start
            //sqlContent.Append("         ISNULL(KensaIraiTbl.KensaIraiHakkoKbn10, '') = ''                                                               ");
            //sqlContent.Append("        KensaIraiTbl.KensaIraiStatusKbn >= 40                                                               ");
            //sqlContent.Append("        AND KensaIraiTbl.KensaIraiStatusKbn < 90                                                            ");
            //Ver1.01 End

            // 検査員
            if (!string.IsNullOrEmpty(searchCond.ShokuinCd))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiKensaTantoshaCd = @shokuinCd ");
                commandParams.Add("@shokuinCd", SqlDbType.NVarChar).Value = searchCond.ShokuinCd;
            }

            // 検査種別
            if (searchCond.KensaIraiHoteiKbn == "0")
            {
                //Ver1.03_20141104_HuyTX Start
                //sqlContent.Append("AND (KensaIraiTbl.KensaIraiHoteiKbn = '1' OR KensaIraiTbl.KensaIraiHoteiKbn = '2')                                   ");
                //sqlContent.Append(" AND (KensaIraiTbl.KensaIraiHoteiKbn = '1' OR (KensaIraiTbl.KensaIraiHoteiKbn IN ('2', '3') AND KensaIraiTbl.KensaIraiScreeningKbn <> '0')) ");
                sqlContent.Append(" AND (KensaIraiTbl.KensaIraiHoteiKbn = '1' OR KensaIraiTbl.KensaIraiHoteiKbn = '2' OR (KensaIraiTbl.KensaIraiHoteiKbn = '3' AND KensaIraiTbl.KensaIraiScreeningKbn <> '0')) ");

                //Ver1.03 End
            }
            else if (searchCond.KensaIraiHoteiKbn == "1")
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHoteiKbn = '1'                                                                             ");
            }
            else if (searchCond.KensaIraiHoteiKbn == "2")
            {
                //Ver1.03_20141104_HuyTX Start
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = '2'                                                                             ");
                //sqlContent.Append(" AND (KensaIraiTbl.KensaIraiHoteiKbn IN ('2', '3') AND KensaIraiTbl.KensaIraiScreeningKbn <> '0')                      ");
                sqlContent.Append(" AND (KensaIraiTbl.KensaIraiHoteiKbn = '2' OR (KensaIraiTbl.KensaIraiHoteiKbn = '3' AND KensaIraiTbl.KensaIraiScreeningKbn <> '0'))                      ");
                //Ver1.03 End
            }

            // 協会No (保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd >= @HokenjoCdFrom ");
                commandParams.Add("@HokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd <= @HokenjoCdTo ");
                commandParams.Add("@HokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            // 協会No (年度)
            string nendoFrom = !string.IsNullOrEmpty(searchCond.NendoFrom) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoFrom, "yyyy") : string.Empty;
            string nendoTo = !string.IsNullOrEmpty(searchCond.NendoTo) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoTo, "yyyy") : string.Empty;

            if (!string.IsNullOrEmpty(searchCond.NendoFrom))
            {
                //MOD_20141117_HuyTX Start
                //sqlContent.Append(" AND (KensaIraiTbl.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC)) " + DataAccessUtility.SetBetweenCommand(searchCond.NendoFrom, searchCond.NendoTo, 2) + " ");
                //sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo " + DataAccessUtility.SetBetweenCommand(nendoFrom, nendoTo, 4));
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo >= @NendoFrom ");
                commandParams.Add("@NendoFrom", SqlDbType.NVarChar).Value = nendoFrom;
                //MOD_20141117_HuyTX End
            }
            if (!string.IsNullOrEmpty(searchCond.NendoTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo <= @NendoTo ");
                commandParams.Add("@NendoTo", SqlDbType.NVarChar).Value = nendoTo;
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

            // 検査日検索使用フラグ
            if (searchCond.KensaYoteiDtUse)
            {
                // 2014/01/14 AnhNV MOD Start
                //sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi)  >= @KensaDtFrom ");
                sqlContent.Append(" and (case isnull(concat(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi), '')");
                sqlContent.Append("     when '' then concat(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki, KensaIraiTbl.KensaIraiKensaYoteiBi)");
                sqlContent.Append("     else concat(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) end) >= @KensaDtFrom");
                commandParams.Add("@KensaDtFrom", SqlDbType.NVarChar).Value = searchCond.KensaDtFrom;

                //sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi)  <= @KensaDtTo ");
                sqlContent.Append(" and (case isnull(concat(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi), '')");
                sqlContent.Append("     when '' then concat(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki, KensaIraiTbl.KensaIraiKensaYoteiBi)");
                sqlContent.Append("     else concat(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) end) <= @KensaDtTo");
                commandParams.Add("@KensaDtTo", SqlDbType.NVarChar).Value = searchCond.KensaDtTo;
                // 2014/01/14 AnhNV MOD End
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

            // 2015/01/14 AnhNV ADD Start
            if (!string.IsNullOrEmpty(searchCond.GyoshaNm))
            {
                sqlContent.Append(" and gm.GyoshaNm like concat('%', @GyoshaNm, '%')");
                commandParams.Add("@GyoshaNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.GyoshaNm);
            }
            if (!string.IsNullOrEmpty(searchCond.KensaIraiGenChikuCd))
            {
                sqlContent.Append(" and KensaIraiTbl.KensaIraiGenChikuCd = @KensaIraiGenChikuCd");
                commandParams.Add("@KensaIraiGenChikuCd", SqlDbType.NVarChar).Value = searchCond.KensaIraiGenChikuCd;
            }
            // 2015/01/14 AnhNV ADD End

            // 2014/10/08 DatNT v1.01 DEL Start
            //if (searchCond.TaishoBukken == "1")
            //{
            //    sqlContent.Append("AND (KensaIraiTbl.KensaIraiKensaKanryoKbn <> '1' OR ISNULL(KensaIraiTbl.KensaIraiKensaKanryoKbn, '') = '' ) ");
            //}
            //else if (searchCond.TaishoBukken == "2")
            //{
            //    // don't handled
            //}
            //else if (searchCond.TaishoBukken == "3")
            //{
            //    sqlContent.Append("AND ISNULL(KensaIraiTbl.KensaIrai7joHoryuKbn, '') <> '' ");
            //}
            //else if (searchCond.TaishoBukken == "4")
            //{
            //    sqlContent.Append("AND ISNULL(KensaIraiTbl.KensaIraiKensaNen, '') = '' ");
            //    sqlContent.Append("AND ISNULL(KensaIraiTbl.KensaIraiKensaTsuki, '') = '' ");
            //    sqlContent.Append("AND ISNULL(KensaIraiTbl.KensaIraiKensaBi, '') = '' ");
            //}
            // 2014/10/08 DatNT v1.01 DEL End

            #endregion

            #region ORDER BY

            sqlContent.Append(" ORDER BY                                                                                                                ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaNen,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaTsuki,                                                                               ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaBi,                                                                                  ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHoteiKbn,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHokenjoCd,                                                                                ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiNendo,                                                                                    ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiRenban                                                                                    ");

            #endregion            

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaKanryoInputListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKanryoInputListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaKanryoInputListTableAdapter
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
        /// 2014/09/08　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKekkaTblDataSet.KensaKanryoInputListDataTable GetDataBySearchCond(KensaKekkaInputListSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaKekkaTblDataSet.KensaKanryoInputListDataTable dataTable = new KensaKekkaTblDataSet.KensaKanryoInputListDataTable();
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
        /// 2014/09/08　DatNT　　新規作成
        /// 2014/10/08　DatNT　　V1.02
        /// 2014/10/15  DatNT    v1.03
        /// 2014/11/04  HuyTX    Ver1.04
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// 2014/11/29　Kiyokuni バグ対応
        /// 2014/12/26　habu     件数制限を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaKekkaInputListSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region SELECT

            // 20141226 habu Mod 件数制限追加
            sqlContent.Append(" SELECT TOP 2000                                                                                                         ");
            //sqlContent.Append(" SELECT                                                                                                                  ");
            sqlContent.Append("         ROW_NUMBER() OVER(ORDER BY                                                                                      ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiKensaNen,                                                         ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiKensaTsuki,                                                       ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiKensaBi,                                                          ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiHoteiKbn,                                                         ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiHokenjoCd,                                                        ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiNendo,                                                            ");
            sqlContent.Append("                                 KensaIraiTbl.KensaIraiRenban) AS RowNumber,                                             ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHoteiKbn,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHokenjoCd,                                                                                ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiNendo,                                                                                    ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiRenban,                                                                                   ");
            //sqlContent.Append("         CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                    ");
            //sqlContent.Append("                 CAST(KensaIraiTbl.KensaIraiNendo AS INT) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), '-', ");
            //sqlContent.Append("                 KensaIraiRenban) AS kyokaiNoCol,                                                                        ");
            sqlContent.Append("         CONCAT(KensaIraiTbl.KensaIraiHokenjoCd, '-',                                                                    ");
            //sqlContent.Append("                 [dbo].[FuncConvertToWareki](KensaIraiTbl.KensaIraiNendo, 'yy', 1), '-', ");
            sqlContent.Append("                 [dbo].[FuncConvertIraiNedoToWareki](KensaIraiTbl.KensaIraiNendo), '-', ");
            sqlContent.Append("                 KensaIraiRenban) AS kyokaiNoCol,                                                                        ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaNen,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaTsuki,                                                                               ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaBi,                                                                                  ");
            sqlContent.Append("         CASE                                                                                                            ");
            sqlContent.Append("             WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, '') = ''                                                        ");
            sqlContent.Append("                     AND ISNULL(KensaIraiTbl.KensaIraiKensaTsuki, '') = ''                                               ");
            sqlContent.Append("                     AND ISNULL(KensaIraiTbl.KensaIraiKensaBi, '') = '' THEN ''                                          ");
            // 2014/10/15 DatNT v1.03 MOD Start
            //sqlContent.Append("             ELSE CONCAT(CAST(KensaIraiTbl.KensaIraiKensaNen AS INT) - 1988, '/',                                        ");
            sqlContent.Append("             ELSE CONCAT(KensaIraiTbl.KensaIraiKensaNen , '/',                                                           ");
            // 2014/10/15 DatNT v1.03 MOD End
            sqlContent.Append("                         KensaIraiTbl.KensaIraiKensaTsuki, '/',                                                          ");
            sqlContent.Append("                         KensaIraiTbl.KensaIraiKensaBi)                                                                  ");
            sqlContent.Append("             END AS yoteiDtCol,                                                                                          ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiSetchishaNm,                                                                              ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiSetchibashoAdr,                                                                           ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiSetchishaKana,                                                                            ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiShoritaishoJinin,                                                                         ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiShorihoshikiKbn,                                                                          ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiShorihoshikiCd,                                                                           ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaTantoshaCd,                                                                          ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaKanryoKbn,                                                                           ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKeninKbn,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiStatusKbn,                                                                                ");

            sqlContent.Append("         CASE WHEN KensaIraiTbl.KensaIraiStatusKbn = '65' THEN '0'                                                       ");
            sqlContent.Append("              WHEN KensaIraiTbl.KensaIraiStatusKbn = '70' THEN '1'                                                       ");
            sqlContent.Append("              ELSE ''                                                                                                    ");
            sqlContent.Append("         END AS keninCol,                                                                                                ");

            sqlContent.Append("         CASE WHEN KensaIraiTbl.KensaIraiStatusKbn >= '65' THEN '1'                                                      ");
            sqlContent.Append("              ELSE '0'                                                                                                   ");
            sqlContent.Append("         END AS kanryoCol,                                                                                               ");

            sqlContent.Append("         KensaIraiTbl.UpdateDt AS KensaIraiTblUpdateDt,                                                                  ");
            sqlContent.Append("         KensaKekkaTbl.KensaKekkaHantei,                                                                                 ");
            sqlContent.Append("         ShoriHoshikiMst.ShoriHoshikiShubetsuNm,                                                                         ");
            sqlContent.Append("         ShokuinMst.ShokuinNm,                                                                                           ");
            sqlContent.Append("         const1.ConstNm AS kensaSyubetsuCol,                                                                             ");
            sqlContent.Append("         const2.ConstValue AS hanteiValue,                                                                               ");
            sqlContent.Append("         const2.ConstNm AS hanteiCol                                                                                     ");
            
            #endregion

            #region FROM

            sqlContent.Append(" FROM                                                                                                                    ");
            sqlContent.Append("         KensaIraiTbl                                                                                                    ");
            sqlContent.Append(" LEFT OUTER JOIN KensaKekkaTbl                                                                                           ");
            sqlContent.Append("                 ON KensaKekkaTbl.KensaKekkaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn                                ");
            sqlContent.Append("                 AND KensaKekkaTbl.KensaKekkaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd                             ");
            sqlContent.Append("                 AND KensaKekkaTbl.KensaKekkaIraiNendo = KensaIraiTbl.KensaIraiNendo                                     ");
            sqlContent.Append("                 AND KensaKekkaTbl.KensaKekkaIraiRenban = KensaIraiTbl.KensaIraiRenban                                   ");
            sqlContent.Append(" LEFT OUTER JOIN ShoriHoshikiMst                                                                                         ");
            sqlContent.Append("                 ON ShoriHoshikiMst.ShoriHoshikiKbn = KensaIraiTbl.KensaIraiShorihoshikiKbn                              ");
            sqlContent.Append("                 AND ShoriHoshikiMst.ShoriHoshikiCd = KensaIraiTbl.KensaIraiShorihoshikiCd                               ");

            //MOD_20141104_HuyTX Ver1.04 Start
            //sqlContent.Append(" LEFT OUTER JOIN ConstMst const1                                                                                         ");
            //sqlContent.Append("                 ON const1.ConstKbn = '006' AND const1.ConstValue = KensaIraiTbl.KensaIraiHoteiKbn                       ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const1 ON (KensaIraiTbl.KensaIraiHoteiKbn = const1.ConstValue                                  ");
            sqlContent.Append("                                 AND const1.ConstKbn = '006'                                                             ");
            sqlContent.Append("                                 AND KensaIraiTbl.KensaIraiScreeningKbn = '0')                                           ");
            sqlContent.Append("                             OR (KensaIraiTbl.KensaIraiScreeningKbn = const1.ConstValue                                  ");
            sqlContent.Append("                                 AND const1.ConstKbn = '024'                                                             ");
            sqlContent.Append("                                 AND KensaIraiTbl.KensaIraiScreeningKbn <> '0')                                          ");
            //MOD_20141104_HuyTX Ver1.04 End

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const2                                                                                         ");
            sqlContent.Append("                 ON const2.ConstKbn = '016' AND const2.ConstValue = KensaKekkaTbl.KensaKekkaHantei                       ");
            sqlContent.Append(" LEFT OUTER JOIN ShokuinMst                                                                                              ");
            sqlContent.Append("                 ON ShokuinMst.ShokuinCd = KensaIraiTbl.KensaIraiKensaTantoshaCd                                         ");

            #endregion

            #region WHERE

            sqlContent.Append(" WHERE                                                                                                                   ");
            sqlContent.Append("     1 = 1                                                                                                               ");
            
            // 2014/10/08 DatNT V1.02 DEL Start
            //sqlContent.Append("         ISNULL(KensaIraiTbl.KensaIraiHakkoKbn10, '') = ''                                                               ");
            // 2014/10/08 DatNT V1.02 DEL End

            // 検査員
            if (!string.IsNullOrEmpty(searchCond.ShokuinCd))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiKensaTantoshaCd = @shokuinCd ");
                commandParams.Add("@shokuinCd", SqlDbType.NVarChar).Value = searchCond.ShokuinCd;
            }

            // 検査種別
            if (searchCond.KensaIraiHoteiKbn == "0")
            {
                //MOD_Ver1.04 Start
                //sqlContent.Append("AND (KensaIraiTbl.KensaIraiHoteiKbn = '1' OR KensaIraiTbl.KensaIraiHoteiKbn = '2')                                   ");
                sqlContent.Append(" AND (KensaIraiTbl.KensaIraiHoteiKbn = '1' OR KensaIraiTbl.KensaIraiHoteiKbn = '2' OR (KensaIraiTbl.KensaIraiHoteiKbn = '3' AND KensaIraiTbl.KensaIraiScreeningKbn <> '0')) ");
                //MOD_Ver1.04 End
            }
            else if (searchCond.KensaIraiHoteiKbn == "1")
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHoteiKbn = '1'                                                                             ");
            }
            else if (searchCond.KensaIraiHoteiKbn == "2")
            {
                //MOD_Ver1.04 Start
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiHoteiKbn = '2'                                                                             ");
                sqlContent.Append(" AND (KensaIraiTbl.KensaIraiHoteiKbn = '2' OR (KensaIraiTbl.KensaIraiHoteiKbn = '3' AND KensaIraiTbl.KensaIraiScreeningKbn <> '0')) ");
                //MOD_Ver1.04 End
            }

            // 協会No (保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                //sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd " + DataAccessUtility.SetBetweenCommand(searchCond.HokenjoCdFrom, searchCond.HokenjoCdTo, 2) + " ");
                //2014.11.29 mod kiyokuni 
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd >= @HokenjoCdFrom ");
                //sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd >= HokenjoCdFrom ");
                commandParams.Add("@HokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                //2014.11.29 mod kiyokuni 
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd <= @HokenjoCdTo ");
                //sqlContent.Append(" AND KensaIraiTbl.KensaIraiHokenjoCd <= HokenjoCdTo ");
                commandParams.Add("@HokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            // 協会No (年度)
            //MOD_20141117_HuyTX Start
            //sqlContent.Append(" AND (KensaIraiTbl.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(KensaIraiTbl.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC)) " + DataAccessUtility.SetBetweenCommand(searchCond.NendoFrom, searchCond.NendoTo, 2) + " ");
            string nendoFrom = !string.IsNullOrEmpty(searchCond.NendoFrom) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoFrom, "yyyy") : string.Empty;
            string nendoTo = !string.IsNullOrEmpty(searchCond.NendoTo) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoTo, "yyyy") : string.Empty;
            //sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo " + DataAccessUtility.SetBetweenCommand(nendoFrom, nendoTo, 4));

            if (!string.IsNullOrEmpty(nendoFrom))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo >= @nendoFrom ");
                commandParams.Add("@nendoFrom", SqlDbType.NVarChar).Value = nendoFrom;
            }
            if (!string.IsNullOrEmpty(nendoTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiNendo <= @nendoTo ");
                commandParams.Add("@nendoTo", SqlDbType.NVarChar).Value = nendoTo;
            }
            //MOD_20141117_HuyTX End

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

            // 検査日検索使用フラグ
            if (searchCond.KensaYoteiDtUse)
            {
                sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi)  >= @KensaDtFrom ");
                commandParams.Add("@KensaDtFrom", SqlDbType.NVarChar).Value = searchCond.KensaDtFrom;

                sqlContent.Append(" AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi)  <= @KensaDtTo ");
                commandParams.Add("@KensaDtTo", SqlDbType.NVarChar).Value = searchCond.KensaDtTo;
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

            // 人槽
            if (!string.IsNullOrEmpty(searchCond.NinsoFrom))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiShoritaishoJinin >= " + searchCond.NinsoFrom + " ");
            }
            if (!string.IsNullOrEmpty(searchCond.NinsoTo))
            {
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiShoritaishoJinin <= " + searchCond.NinsoTo + " ");
            }

            // 2014/10/08 DatNT V1.02 DEL Start
            //if (searchCond.TaishoBukken == "1")
            //{
            //    sqlContent.Append("AND KensaIraiTbl.KensaIraiKensaKanryoKbn <> '1' ");
            //}
            // 2014/10/08 DatNT V1.02 DEL End

            if (searchCond.TaishoBukken == "2")
            {
                // 2014/10/08 DatNT V1.02 MOD Start
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiKensaKanryoKbn = '1' ");
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiKeninKbn <> '1' ");
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiStatusKbn = '65' ");
                // 2014/10/08 DatNT V1.02 MOD End
            }
            else if (searchCond.TaishoBukken == "3")
            {
                // 2014/10/08 DatNT V1.02 MOD Start
                //sqlContent.Append("AND KensaIraiTbl.KensaIraiKeninKbn = '1' ");
                sqlContent.Append(" AND KensaIraiTbl.KensaIraiStatusKbn = '70' ");
                // 2014/10/08 DatNT V1.02 MOD End
            }
            else if (searchCond.TaishoBukken == "4")
            {
                sqlContent.Append(" AND (KensaIraiTbl.KensaIraiStatusKbn = '70' OR KensaIraiTbl.KensaIraiStatusKbn = '65') ");
            }

            #endregion

            #region ORDER BY

            sqlContent.Append(" ORDER BY                                                                                                                ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaNen,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaTsuki,                                                                               ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiKensaBi,                                                                                  ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHoteiKbn,                                                                                 ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiHokenjoCd,                                                                                ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiNendo,                                                                                    ");
            sqlContent.Append("         KensaIraiTbl.KensaIraiRenban                                                                                    ");

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaKekkaListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/09　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKekkaListTableAdapter
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
        /// 2014/10/09　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKekkaTblDataSet.KensaKekkaListDataTable GetDataBySearchCond(KensaKekkaListSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaKekkaTblDataSet.KensaKekkaListDataTable dataTable = new KensaKekkaTblDataSet.KensaKekkaListDataTable();
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
        /// 2014/10/09　HuyTX　　新規作成
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// 2014/12/26　habu　　    件数制限対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaKekkaListSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT TOP 2000 kit.KensaIraiHoteiKbn,                                                                                                      ");
            //sqlContent.Append(" SELECT kit.KensaIraiHoteiKbn,                                                                                                               ");
            sqlContent.Append(" kit.KensaIraiHokenjoCd,                                                                                                                     ");
            sqlContent.Append(" kit.KensaIraiNendo,                                                                                                                         ");
            sqlContent.Append(" kit.KensaIraiRenban,                                                                                                                        ");
            sqlContent.Append("        cm.ConstNm,                                                                                                                          ");
            //sqlContent.Append("        CONCAT(kit.KensaIraiHokenjoCd, '-', REPLACE(STR(kit.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiRenban) AS KensaNo, ");
            //sqlContent.Append("        CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiNendo, 'yy', 1) , '-', kit.KensaIraiRenban) AS KensaNo,     ");
            sqlContent.Append("        CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo), '-', kit.KensaIraiRenban) AS KensaNo,     ");
            sqlContent.Append("        kit.KensaIraiSuishitsuIraiNo,                                                                                                        ");
            sqlContent.Append("        (CASE                                                                                                                                ");
            sqlContent.Append("             WHEN ISDATE(CONCAT(kit.KensaIraiNen,kit.KensaIraiTsuki,kit.KensaIraiBi)) = 0 THEN ''                                            ");
            sqlContent.Append("             ELSE CONVERT(CHAR(10), CONVERT(DATETIME,CONCAT(kit.KensaIraiNen,kit.KensaIraiTsuki,kit.KensaIraiBi)), 111)                      ");
            sqlContent.Append("         END) AS KensaIraiDt,                                                                                                                ");
            sqlContent.Append("        (CASE                                                                                                                                ");
            sqlContent.Append("             WHEN ISDATE(CONCAT(kit.KensaIraiKensaNen,kit.KensaIraiKensaTsuki,kit.KensaIraiKensaBi)) = 0 THEN ''                             ");
            sqlContent.Append("             ELSE CONVERT(CHAR(10), CONVERT(DATETIME,CONCAT(kit.KensaIraiKensaNen,kit.KensaIraiKensaTsuki,kit.KensaIraiKensaBi)), 111)       ");
            sqlContent.Append("         END) AS KensaDt,                                                                                                                    ");
            sqlContent.Append("        kit.KensaIraiSetchishaNm,                                                                                                            ");
            sqlContent.Append("        kit.KensaIraiShisetsuNm,                                                                                                             ");
            sqlContent.Append("        kit.KensaIraiSetchibashoAdr,                                                                                                         ");
            sqlContent.Append("        (CASE kkt.KensaKekkaHantei                                                                                                           ");
            sqlContent.Append("             WHEN 1 THEN '〇'                                                                                                                ");
            sqlContent.Append("             WHEN 2 THEN '△'                                                                                                                ");
            sqlContent.Append("             WHEN 3 THEN '×'                                                                                                                 ");
            sqlContent.Append("         END) AS KensaKekkaHantei,                                                                                                           ");
            sqlContent.Append("         kit.KensaIraiKekkashoInsatsuCnt,                                                                                                    ");
            sqlContent.Append("         kit.UpdateDt                                                                                                                        ");
            sqlContent.Append(" FROM KensaIraiTbl kit                                                                                                                       ");

            sqlContent.Append(" INNER JOIN KensaKekkaTbl kkt ON kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn                                                           ");
            sqlContent.Append("                             AND kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd                                                        ");
            sqlContent.Append("                             AND kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo                                                                ");
            sqlContent.Append("                             AND kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban                                                              ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst cm ON (kit.KensaIraiHoteiKbn = cm.ConstValue                                                                       ");
            sqlContent.Append("                                 AND cm.ConstKbn = '006'                                                                                     ");
            sqlContent.Append("                                 AND (ISNULL(kit.KensaIraiScreeningKbn, '') = '' OR kit.KensaIraiScreeningKbn = '0'))                        ");
            sqlContent.Append("                             OR (kit.KensaIraiScreeningKbn = cm.ConstValue                                                                   ");
            sqlContent.Append("                                 AND cm.ConstKbn = '024'                                                                                     ");
            sqlContent.Append("                                 AND (ISNULL(kit.KensaIraiScreeningKbn, '') <> '' OR kit.KensaIraiScreeningKbn <> '0'))                      ");

            //WHERE
            // 20141226 habu Mod 
            sqlContent.Append(" WHERE kit.KensaIraiStatusKbn >= '70' AND kit.KensaIraiStatusKbn < '90'                                              ");
            //sqlContent.Append(" WHERE kit.KensaIraiStatusKbn >= 70 AND kit.KensaIraiStatusKbn < 90                                              ");
            // 20141226 End

            //検査区分
            if (!string.IsNullOrEmpty(searchCond.KensaIraiHoteiKbn))
            {
                sqlContent.Append(" AND kit.KensaIraiHoteiKbn = @kensaIraiHoteiKbn ");
                commandParams.Add("@kensaIraiHoteiKbn", SqlDbType.NVarChar).Value = searchCond.KensaIraiHoteiKbn;
            }

            //スクリーニング区分 
            for (int i = 0; i < searchCond.KensaIraiScreeningKbn.Length; i++)
            {
                if (i == 0)
                {
                    sqlContent.Append(" AND ( ");
                }

                if (searchCond.KensaIraiScreeningKbn[i] == "0")
                {
                    sqlContent.Append(" kit.KensaIraiScreeningKbn = '0' OR ISNULL(kit.KensaIraiScreeningKbn, '') = '' ");
                }
                else
                {
                    sqlContent.Append(" kit.KensaIraiScreeningKbn = '" + searchCond.KensaIraiScreeningKbn[i] + "'");
                }

                if (i == searchCond.KensaIraiScreeningKbn.Length - 1)
                {
                    sqlContent.Append(" ) ");
                }
                else
                {
                    sqlContent.Append(" OR ");
                }
            }
        
            //検査番号 (保健所コード)
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

            //検査番号 (年度)
            if (!string.IsNullOrEmpty(searchCond.NendoFrom))
            {
                //sqlContent.Append(" AND kit.KensaIraiNendo " + DataAccessUtility.SetBetweenCommand(searchCond.NendoFrom, searchCond.NendoTo, 4));
                sqlContent.Append(" AND kit.KensaIraiNendo >= @NendoFrom ");
                commandParams.Add("@NendoFrom", SqlDbType.NVarChar).Value = searchCond.NendoFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.NendoTo))
            {
                sqlContent.Append(" AND kit.KensaIraiNendo <= @NendoTo ");
                commandParams.Add("@NendoTo", SqlDbType.NVarChar).Value = searchCond.NendoTo;
            }

            //検査番号 (連番)
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

            //水質検査依頼番号 
            if (!string.IsNullOrEmpty(searchCond.KensaIraiSuishitsuIraiNoFrom))
            {
                //sqlContent.Append(" AND kit.KensaIraiSuishitsuIraiNo " + DataAccessUtility.SetBetweenCommand(searchCond.KensaIraiSuishitsuIraiNoFrom, searchCond.KensaIraiSuishitsuIraiNoTo, 6));
                sqlContent.Append(" AND kit.KensaIraiSuishitsuIraiNo >= @KensaIraiSuishitsuIraiNoFrom ");
                commandParams.Add("@KensaIraiSuishitsuIraiNoFrom", SqlDbType.NVarChar).Value = searchCond.KensaIraiSuishitsuIraiNoFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.KensaIraiSuishitsuIraiNoTo))
            {
                sqlContent.Append(" AND kit.KensaIraiSuishitsuIraiNo <= @KensaIraiSuishitsuIraiNoTo ");
                commandParams.Add("@KensaIraiSuishitsuIraiNoTo", SqlDbType.NVarChar).Value = searchCond.KensaIraiSuishitsuIraiNoTo;
            }

            //判定 
            for (int i = 0; i < searchCond.KensaKekkaHantei.Length; i++)
            {
                if (i == 0)
                {
                    sqlContent.Append(" AND ( ");
                }

                sqlContent.Append(" kkt.KensaKekkaHantei = '" + searchCond.KensaKekkaHantei[i] + "'");

                if (i == searchCond.KensaKekkaHantei.Length - 1)
                {
                    sqlContent.Append(" ) ");
                }
                else
                {
                    sqlContent.Append(" OR ");
                }
            }

            //発行区分
            if (searchCond.KensaIraiHakkoKbn == "4" || searchCond.KensaIraiHakkoKbn == "5")
            {
                sqlContent.Append(string.Format(" AND kit.KensaIraiHakkoKbn{0} <> '1' ", searchCond.KensaIraiHakkoKbn));
            }

            //設置者名（漢字） 
            if (!string.IsNullOrEmpty(searchCond.KensaIraiSetchishaNm))
            {
                sqlContent.Append(" AND kit.KensaIraiSetchishaNm LIKE CONCAT('%', @kensaIraiSetchishaNm, '%') ");
                commandParams.Add("@kensaIraiSetchishaNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.KensaIraiSetchishaNm);
            }

            //施設名称 
            if (!string.IsNullOrEmpty(searchCond.KensaIraiShisetsuNm))
            {
                sqlContent.Append(" AND kit.KensaIraiShisetsuNm LIKE CONCAT('%', @kensaIraiShisetsuNm, '%') ");
                commandParams.Add("@kensaIraiShisetsuNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.KensaIraiShisetsuNm);
            }

            //検査依頼日
            //sqlContent.Append(" AND CONCAT(REPLACE(STR(kit.KensaIraiNen, 4), SPACE(1), '0'), ");
            //sqlContent.Append(" REPLACE(STR(kit.KensaIraiTsuki, 2), SPACE(1), '0'),  ");
            //sqlContent.Append(" REPLACE(STR(kit.KensaIraiBi, 2), SPACE(1), '0')) " + DataAccessUtility.SetBetweenCommand(searchCond.KensaIraiDtFrom, searchCond.KensaIraiDtTo, 8));

            if (!string.IsNullOrEmpty(searchCond.KensaIraiDtFrom))
            {
                //sqlContent.Append(" AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi) ");
                //sqlContent.Append(DataAccessUtility.SetBetweenCommand(searchCond.KensaIraiDtFrom, searchCond.KensaIraiDtTo, 8));

                //2015.01.23 mod kiyokuni start  レスポンスタイムアウト改善 CONCAT廃止
                //sqlContent.Append(" AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi) >= @KensaIraiDtFrom ");
                //commandParams.Add("@KensaIraiDtFrom", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtFrom;

                sqlContent.Append(" AND (kit.KensaIraiNen > @kensaIraiDtFromYYYY ");
                sqlContent.Append(" OR (kit.KensaIraiNen = @kensaIraiDtFromYYYY AND kit.KensaIraiTsuki > @kensaIraiDtFromMM) ");
                sqlContent.Append(" OR (kit.KensaIraiNen = @kensaIraiDtFromYYYY AND kit.KensaIraiTsuki = @kensaIraiDtFromMM AND kit.KensaIraiBi >= @kensaIraiDtFromDD))	 ");
                commandParams.Add("@kensaIraiDtFromYYYY", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtFrom.Substring(0, 4);
                commandParams.Add("@kensaIraiDtFromMM", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtFrom.Substring(4, 2);
                commandParams.Add("@kensaIraiDtFromDD", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtFrom.Substring(6, 2);
                //2015.01.23 mod kiyokuni end  
            
            }
            if (!string.IsNullOrEmpty(searchCond.KensaIraiDtTo))
            {
                //2015.01.23 mod kiyokuni start  レスポンスタイムアウト改善 CONCAT廃止
                //sqlContent.Append(" AND CONCAT(kit.KensaIraiNen, kit.KensaIraiTsuki, kit.KensaIraiBi) <= @KensaIraiDtTo ");
                //commandParams.Add("@KensaIraiDtTo", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtTo;

                sqlContent.Append(" AND (kit.KensaIraiNen < @kensaIraiDtToYYYY ");
                sqlContent.Append(" OR (kit.KensaIraiNen = @kensaIraiDtToYYYY AND kit.KensaIraiTsuki < @kensaIraiDtToMM) ");
                sqlContent.Append(" OR (kit.KensaIraiNen = @kensaIraiDtToYYYY AND kit.KensaIraiTsuki = @kensaIraiDtToMM AND kit.KensaIraiBi <= @kensaIraiDtToDD)) ");
                commandParams.Add("@kensaIraiDtToYYYY", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtTo.Substring(0, 4);
                commandParams.Add("@kensaIraiDtToMM", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtTo.Substring(4, 2);
                commandParams.Add("@kensaIraiDtToDD", SqlDbType.NVarChar).Value = searchCond.KensaIraiDtTo.Substring(6, 2);
                //2015.01.23 mod kiyokuni end  
            
            }

            //検査日
            //sqlContent.Append(" AND CONCAT(REPLACE(STR(kit.KensaIraiKensaNen, 4), SPACE(1), '0'), ");
            //sqlContent.Append(" REPLACE(STR(kit.KensaIraiKensaTsuki, 2), SPACE(1), '0'),  ");
            //sqlContent.Append(" REPLACE(STR(kit.KensaIraiKensaBi, 2), SPACE(1), '0')) " + DataAccessUtility.SetBetweenCommand(searchCond.KensaDtFrom, searchCond.KensaDtTo, 8));

            if (!string.IsNullOrEmpty(searchCond.KensaDtFrom))
            {
                //sqlContent.Append(" AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) ");
                //sqlContent.Append(DataAccessUtility.SetBetweenCommand(searchCond.KensaDtFrom, searchCond.KensaDtTo, 8));

                //2015.01.23 mod kiyokuni start  レスポンスタイムアウト改善 CONCAT廃止
                //sqlContent.Append(" AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) >= @KensaDtFrom ");
                //commandParams.Add("@KensaDtFrom", SqlDbType.NVarChar).Value = searchCond.KensaDtFrom;

                sqlContent.Append(" AND (kit.KensaIraiKensaNen > @kensaDtFromYYYY ");
                sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaDtFromYYYY AND kit.KensaIraiKensaTsuki > @kensaDtFromMM) ");
                sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaDtFromYYYY AND kit.KensaIraiKensaTsuki = @kensaDtFromMM AND kit.KensaIraiKensaBi >= @kensaDtFromDD))	 ");
                commandParams.Add("@kensaDtFromYYYY", SqlDbType.NVarChar).Value = searchCond.KensaDtFrom.Substring(0, 4);
                commandParams.Add("@kensaDtFromMM", SqlDbType.NVarChar).Value = searchCond.KensaDtFrom.Substring(4, 2);
                commandParams.Add("@kensaDtFromDD", SqlDbType.NVarChar).Value = searchCond.KensaDtFrom.Substring(6, 2);
                //2015.01.23 mod kiyokuni end  

            }
            if (!string.IsNullOrEmpty(searchCond.KensaDtTo))
            {
                //2015.01.23 mod kiyokuni start  レスポンスタイムアウト改善 CONCAT廃止
                //sqlContent.Append(" AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) <= @KensaDtTo ");
                //commandParams.Add("@KensaDtTo", SqlDbType.NVarChar).Value = searchCond.KensaDtTo;

                sqlContent.Append(" AND (kit.KensaIraiKensaNen < @kensaDtToYYYY ");
                sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaDtToYYYY AND kit.KensaIraiKensaTsuki < @kensaDtToMM) ");
                sqlContent.Append(" OR (kit.KensaIraiKensaNen = @kensaDtToYYYY AND kit.KensaIraiKensaTsuki = @kensaDtToMM AND kit.KensaIraiKensaBi <= @kensaDtToDD)) ");
                commandParams.Add("@kensaDtToYYYY", SqlDbType.NVarChar).Value = searchCond.KensaDtTo.Substring(0, 4);
                commandParams.Add("@kensaDtToMM", SqlDbType.NVarChar).Value = searchCond.KensaDtTo.Substring(4, 2);
                commandParams.Add("@kensaDtToDD", SqlDbType.NVarChar).Value = searchCond.KensaDtTo.Substring(6, 2);
                //2015.01.23 mod kiyokuni end  
            }

            // ORDER BY
            sqlContent.Append("ORDER BY kit.KensaIraiHoteiKbn, ");
            sqlContent.Append(" kit.KensaIraiHokenjoCd, ");
            sqlContent.Append(" kit.KensaIraiNendo, ");
            sqlContent.Append(" kit.KensaIraiRenban ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region SuishitsuKensaKekkaInfoTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaKekkaInfoTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaKekkaInfoTableAdapter
    {
        #region GetAllData
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetAllData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable GetAllData()
        {
            SqlCommand command = CreateSqlCommand();

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable dataTable = new KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable();
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
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16　HuyTX　　新規作成
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand()
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT ");
            sqlContent.Append("         kit.KensaIraiHoteiKbn, ");
            sqlContent.Append("         kit.KensaIraiHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiNendo, ");
            sqlContent.Append("         kit.KensaIraiRenban, ");
            sqlContent.Append("         kit.KensaIraiJokasoHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiJokasoTorokuNendo, ");
            sqlContent.Append("         kit.KensaIraiJokasoRenban, ");
            sqlContent.Append("         kit.KensaIraiSetchishaZipCd, ");
            sqlContent.Append("         kit.KensaIraiSetchishaAdr, ");
            sqlContent.Append("         kit.KensaIraiSetchishaNm, ");
            sqlContent.Append("         kit.KensaIraiSofusakiNm, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISDATE(CONCAT(kit.KensaIraiNen,kit.KensaIraiTsuki,kit.KensaIraiBi)) = 0 THEN '' ");
            sqlContent.Append("             ELSE CONCAT(kit.KensaIraiNen,kit.KensaIraiTsuki,kit.KensaIraiBi) ");
            sqlContent.Append("         END AS UketukeDt, ");
            sqlContent.Append("         hkm.JimukyokuHoteiKanriAdr, ");
            sqlContent.Append("         hkm.JimukyokuTelNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', REPLACE(STR(kit.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiRenban) AS KyokaiNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', REPLACE(STR(kit.KensaIraiJokasoTorokuNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiJokasoTorokuNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiJokasoRenban) AS JokasoNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiNendo, 'yy', 1), '-', kit.KensaIraiRenban) AS KyokaiNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiJokasoTorokuNendo, 'yy', 1), '-', kit.KensaIraiJokasoRenban) AS JokasoNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo), '-', kit.KensaIraiRenban) AS KyokaiNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiJokasoHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiJokasoTorokuNendo), '-', kit.KensaIraiJokasoRenban) AS JokasoNo, ");
            sqlContent.Append("         kit.KensaIraiKensaTantoshaNm, ");
            sqlContent.Append("         kit.KensaIraiSetchishaNm, ");
            sqlContent.Append("         kit.KensaIraiShisetsuNm, ");
            sqlContent.Append("         kit.KensaIraiSetchibashoAdr, ");
            sqlContent.Append("         kit.KensaIraiMakerCd, ");
            sqlContent.Append("         makerGyosha.GyoshaNm MakerGyoshaNm, ");
            sqlContent.Append("         kit.KensaIraiKojiGyoshaCd, ");
            sqlContent.Append("         kojiGyosha.GyoshaNm KojiGyoshaNm, ");
            sqlContent.Append("         kit.KensaIraiHoshutenkenGyoshaCd, ");
            sqlContent.Append("         hoshuGyosha.GyoshaNm HoshuGyoshaNm, ");
            sqlContent.Append("         kit.KensaIraiSeisoGyoshaCd, ");
            sqlContent.Append("         seisoGyosha.GyoshaNm SeisoGyoshaNm, ");
            sqlContent.Append("         kit.KensaIraiShorihoshikiKbn, ");
            sqlContent.Append("         cm.ConstNm AS KensaIraiShorihoshikiKbnValue, ");
            sqlContent.Append("         kit.KensaIraiShorihoshikiCd, ");
            sqlContent.Append("         shm.ShoriHoshikiNm, ");
            sqlContent.Append("         hm.HokenjoNm, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoJyuriHokenjoCd, '-', REPLACE(STR(kit.KensaIraiHokenjoJyuriNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiHokenjoJyuriNendo, '01', '01') ORDER BY KaishiDt DESC), 2), SPACE(1), '0'), '-', kit.KensaIraiHokenjoJyuriShichosonCd, '-', kit.KensaIraiHokenjoJyuriRenban) AS HokenjoJyuriNo, ");
            //sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoJyuriHokenjoCd, '-', [dbo].[FuncConvertToWareki](kit.KensaIraiHokenjoJyuriNendo, 'yy', 1), '-', kit.KensaIraiHokenjoJyuriShichosonCd, '-', kit.KensaIraiHokenjoJyuriRenban) AS HokenjoJyuriNo, ");
            sqlContent.Append("         CONCAT(kit.KensaIraiHokenjoJyuriHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiHokenjoJyuriNendo), '-', kit.KensaIraiHokenjoJyuriShichosonCd, '-', kit.KensaIraiHokenjoJyuriRenban) AS HokenjoJyuriNo, ");
            sqlContent.Append("         kit.KensaIraiBODShoriSeino, ");
            sqlContent.Append("         jdm.JokasoJokasoKumitateKbn, ");
            sqlContent.Append("         km.KatashikiNm, ");
            sqlContent.Append("         kit.KensaIraiKokujiKbn, ");
            sqlContent.Append("         kit.KensaIraiNinteiNo, ");
            sqlContent.Append("         kit.KensaIraiKokujiNendo, ");
            sqlContent.Append("         kit.KensaIraiKokujiNo, ");
            sqlContent.Append("         kit.KensaIraiTatemonoYoto, ");
            sqlContent.Append("         nm1.Name AS KensaIraiTatemonoYotoValue, ");
            sqlContent.Append("         kdm1.KenchikuyotoDaibunruiNm AS KenchikuyotoDaibunruiNm1, ");
            sqlContent.Append("         kdm2.KenchikuyotoDaibunruiNm AS KenchikuyotoDaibunruiNm2, ");
            sqlContent.Append("         kdm3.KenchikuyotoDaibunruiNm AS KenchikuyotoDaibunruiNm3, ");
            sqlContent.Append("         kdm4.KenchikuyotoDaibunruiNm AS KenchikuyotoDaibunruiNm4, ");
            sqlContent.Append("         kdm5.KenchikuyotoDaibunruiNm AS KenchikuyotoDaibunruiNm5, ");
            sqlContent.Append("         ksm1.KenchikuyotoShobunruiNm AS KenchikuyotoShobunruiNm1, ");
            sqlContent.Append("         ksm2.KenchikuyotoShobunruiNm AS KenchikuyotoShobunruiNm2, ");
            sqlContent.Append("         ksm3.KenchikuyotoShobunruiNm AS KenchikuyotoShobunruiNm3, ");
            sqlContent.Append("         ksm4.KenchikuyotoShobunruiNm AS KenchikuyotoShobunruiNm4, ");
            sqlContent.Append("         ksm5.KenchikuyotoShobunruiNm AS KenchikuyotoShobunruiNm5, ");
            sqlContent.Append("         km1.KenchikuyotoNm AS KenchikuyotoNm1, ");
            sqlContent.Append("         km2.KenchikuyotoNm AS KenchikuyotoNm2, ");
            sqlContent.Append("         km3.KenchikuyotoNm AS KenchikuyotoNm3, ");
            sqlContent.Append("         km4.KenchikuyotoNm AS KenchikuyotoNm4, ");
            sqlContent.Append("         km5.KenchikuyotoNm AS KenchikuyotoNm5, ");
            sqlContent.Append("         kit.KensaIraiHoryusakiCd, ");
            sqlContent.Append("         nm2.Name AS KensaIraiHoryusakiCdValue, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISDATE(CONCAT(kit.KensaIraiShiyoKaishiNen,kit.KensaIraiShiyoKaishiTsuki,kit.KensaIraiShiyoKaishiBi)) = 0 THEN '' ");
            sqlContent.Append("             ELSE CONCAT(kit.KensaIraiShiyoKaishiNen,kit.KensaIraiShiyoKaishiTsuki,kit.KensaIraiShiyoKaishiBi) ");
            sqlContent.Append("         END AS ShiyoKaishiDt, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISDATE(CONCAT(kit.KensaIraiSetchiNen,kit.KensaIraiSetchiTsuki,kit.KensaIraiSetchiBi)) = 0 THEN '' ");
            sqlContent.Append("             ELSE CONCAT(kit.KensaIraiSetchiNen,kit.KensaIraiSetchiTsuki,kit.KensaIraiSetchiBi) ");
            sqlContent.Append("         END AS SetchiDt, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kit.KensaIraiShoritaishoJinin, '') = '' THEN '' ");
            sqlContent.Append("             ELSE CONCAT(kit.KensaIraiShoritaishoJinin, ' 人') ");
            sqlContent.Append("         END AS KensaIraiShoritaishoJinin, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kit.KensaIraiJitsushiyoJinin, '') = '' THEN '' ");
            sqlContent.Append("             ELSE CONCAT(kit.KensaIraiJitsushiyoJinin, ' 人') ");
            sqlContent.Append("         END AS KensaIraiJitsushiyoJinin, ");
            sqlContent.Append("         kkt.KensaKekkaHantei, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN kkt.KensaKekkaHantei = '1' THEN '適正です。' ");
            sqlContent.Append("             WHEN kkt.KensaKekkaHantei = '2' THEN 'おおむね適正です。' ");
            sqlContent.Append("             WHEN kkt.KensaKekkaHantei = '3' THEN '不適正 です。' ");
            sqlContent.Append("             ELSE '' ");
            sqlContent.Append("         END AS KensaKekkaHanteiValue, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN ISNULL(kkt.KensaKekkaSuisoIonNodo, '') = '' THEN '－' ");
            sqlContent.Append("            ELSE CONCAT(kkt.KensaKekkaSuisoIonNodo, '') ");
            sqlContent.Append("         END AS KensaKekkaSuisoIonNodo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN ISNULL(kkt.KensaKekkaOdeiChindenritsu, 0) = 0 THEN '－' ");
            sqlContent.Append("            ELSE CONCAT(kkt.KensaKekkaOdeiChindenritsu, '') ");
            sqlContent.Append("         END AS KensaKekkaOdeiChindenritsu, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("             WHEN ISNULL(kkt.KensaKekkaYozonSansoryo1, '') <> '' AND ISNULL(kkt.KensaKekkaYozonSansoryo2, '') <> '' THEN CONCAT(kkt.KensaKekkaYozonSansoryo1, '～', kkt.KensaKekkaYozonSansoryo2) ");
            sqlContent.Append("             ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaYozonSansoryo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN ISNULL(kkt.KensaKekkaEnsoIonNodo, '') = '' THEN '－' ");
            sqlContent.Append("            ELSE CONCAT(kkt.KensaKekkaEnsoIonNodo, '') ");
            sqlContent.Append("         END AS KensaKekkaEnsoIonNodo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN ISNULL(kkt.KensaKekkaToshido2jiSyorisui, '') = '' THEN '－' ");
            sqlContent.Append("            ELSE CONCAT(kkt.KensaKekkaToshido2jiSyorisui, '') ");
            sqlContent.Append("         END AS KensaKekkaToshido2jiSyorisui, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN ISNULL(kkt.KensaKekkaToshido, '') = '' THEN '－' ");
            sqlContent.Append("            ELSE CONCAT(kkt.KensaKekkaToshido, '') ");
            sqlContent.Append("         END AS KensaKekkaToshido, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN ISNULL(kkt.KensaKekkaZanryuEnsoNodo, '') = '' THEN '－' ");
            sqlContent.Append("            ELSE CONCAT(kkt.KensaKekkaZanryuEnsoNodo, '') ");
            sqlContent.Append("         END AS KensaKekkaZanryuEnsoNodo, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN ISNULL(kkt.KensaKekkaBOD, '') = '' THEN '－' ");
            sqlContent.Append("            ELSE CONCAT(kkt.KensaKekkaBOD, '') ");
            sqlContent.Append("         END AS KensaKekkaBOD, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaSuisoIonNodoHantei = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaSuisoIonNodoHantei = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaSuisoIonNodoHantei = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaSuisoIonNodoHantei, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaOdeiChindenritsuHantei = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaOdeiChindenritsuHantei = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaOdeiChindenritsuHantei = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaOdeiChindenritsuHantei, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaYozonSansoryoHantei = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaYozonSansoryoHantei = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaYozonSansoryoHantei = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaYozonSansoryoHantei, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaEnsoIonNodoHantei = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaEnsoIonNodoHantei = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaEnsoIonNodoHantei = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaEnsoIonNodoHantei, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaToshidoHantei2jiSyorisui = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaToshidoHantei2jiSyorisui = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaToshidoHantei2jiSyorisui = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaToshidoHantei2jiSyorisui, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaToshidoHantei = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaToshidoHantei = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaToshidoHantei = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaToshidoHantei, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaZanryuEnsoNodoHantei = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaZanryuEnsoNodoHantei = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaZanryuEnsoNodoHantei = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaZanryuEnsoNodoHantei, ");
            sqlContent.Append("         CASE ");
            sqlContent.Append("            WHEN kkt.KensaKekkaBODHantei = '1' THEN '○' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaBODHantei = '2' THEN '△' ");
            sqlContent.Append("            WHEN kkt.KensaKekkaBODHantei = '3' THEN '×' ");
            sqlContent.Append("            ELSE '－' ");
            sqlContent.Append("         END AS KensaKekkaBODHantei, ");
            sqlContent.Append("         kit.KensaIraiKekkashoInsatsuCnt, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriNendo, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriShichosonCd, ");
            sqlContent.Append("         kit.KensaIraiHokenjoJyuriRenban ");

            sqlContent.Append(" FROM KensaIraiTbl kit ");

            sqlContent.Append(" LEFT OUTER JOIN HoteiKanriMst hkm ON hkm.JimukyokuKbn = '0' ");

            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst makerGyosha ON makerGyosha.GyoshaCd = kit.KensaIraiMakerCd ");

            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst kojiGyosha ON kojiGyosha.GyoshaCd = kit.KensaIraiKojiGyoshaCd ");

            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst hoshuGyosha ON hoshuGyosha.GyoshaCd = kit.KensaIraiHoshutenkenGyoshaCd ");

            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst seisoGyosha ON seisoGyosha.GyoshaCd = kit.KensaIraiSeisoGyoshaCd ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst cm ON cm.ConstValue = kit.KensaIraiShorihoshikiKbn  ");
            sqlContent.Append("                             AND cm.ConstKbn = '022' ");

            sqlContent.Append(" LEFT OUTER JOIN ShoriHoshikiMst shm ON shm.ShoriHoshikiKbn = kit.KensaIraiShorihoshikiKbn  ");
            sqlContent.Append("                                     AND shm.ShoriHoshikiCd = kit.KensaIraiShorihoshikiCd ");

            sqlContent.Append(" LEFT OUTER JOIN HokenjoMst hm ON hm.HokenjoCd = kit.KensaIraiJokasoHokenjoCd AND hm.DelFlg <> '1' ");

            sqlContent.Append(" LEFT OUTER JOIN JokasoDaichoMst jdm ON kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            sqlContent.Append("                                     AND kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            sqlContent.Append("                                     AND kit.KensaIraiJokasoRenban = jdm.JokasoRenban ");

            sqlContent.Append(" LEFT OUTER JOIN KatashikiMst km ON km.KatashikiMakerCd = kit.KensaIraiMakerCd ");
            sqlContent.Append("                                 AND km.KatashikiCd = kit.KensaIraiKatashikiCd ");

            sqlContent.Append(" LEFT OUTER JOIN NameMst nm1 ON nm1.NameCd = kit.KensaIraiTatemonoYoto AND nm1.NameKbn = '002' ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoDaibunruiMst kdm1 ON kdm1.KenchikuyotoDaibunruiCd = kit.KenchikuyotoDaibunrui1 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoDaibunruiMst kdm2 ON kdm2.KenchikuyotoDaibunruiCd = kit.KenchikuyotoDaibunrui2 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoDaibunruiMst kdm3 ON kdm3.KenchikuyotoDaibunruiCd = kit.KenchikuyotoDaibunrui3 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoDaibunruiMst kdm4 ON kdm4.KenchikuyotoDaibunruiCd = kit.KenchikuyotoDaibunrui4 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoDaibunruiMst kdm5 ON kdm5.KenchikuyotoDaibunruiCd = kit.KenchikuyotoDaibunrui5 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoShobunruiMst ksm1 ON ksm1.KenchikuyotoShobunruiCd = kit.KenchikuyotoShobunrui1 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoShobunruiMst ksm2 ON ksm2.KenchikuyotoShobunruiCd = kit.KenchikuyotoShobunrui2 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoShobunruiMst ksm3 ON ksm3.KenchikuyotoShobunruiCd = kit.KenchikuyotoShobunrui3 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoShobunruiMst ksm4 ON ksm4.KenchikuyotoShobunruiCd = kit.KenchikuyotoShobunrui4 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoShobunruiMst ksm5 ON ksm5.KenchikuyotoShobunruiCd = kit.KenchikuyotoShobunrui5 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoMst km1 ON km1.KenchikuyotoDaibunrui = kit.KenchikuyotoDaibunrui1 ");
            sqlContent.Append("                                     AND km1.KenchikuyotoShobunrui = kit.KenchikuyotoShobunrui1 ");
            sqlContent.Append("                                     AND km1.KenchikuyotoRenban = kit.KenchikuyotoRenban1 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoMst km2 ON km2.KenchikuyotoDaibunrui = kit.KenchikuyotoDaibunrui2 ");
            sqlContent.Append("                                     AND km2.KenchikuyotoShobunrui = kit.KenchikuyotoShobunrui2 ");
            sqlContent.Append("                                     AND km2.KenchikuyotoRenban = kit.KenchikuyotoRenban2 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoMst km3 ON km3.KenchikuyotoDaibunrui = kit.KenchikuyotoDaibunrui3 ");
            sqlContent.Append("                                     AND km3.KenchikuyotoShobunrui = kit.KenchikuyotoShobunrui3 ");
            sqlContent.Append("                                     AND km3.KenchikuyotoRenban = kit.KenchikuyotoRenban3 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoMst km4 ON km4.KenchikuyotoDaibunrui = kit.KenchikuyotoDaibunrui4 ");
            sqlContent.Append("                                     AND km4.KenchikuyotoShobunrui = kit.KenchikuyotoShobunrui4 ");
            sqlContent.Append("                                     AND km4.KenchikuyotoRenban = kit.KenchikuyotoRenban4 ");

            sqlContent.Append(" LEFT OUTER JOIN KenchikuyotoMst km5 ON km5.KenchikuyotoDaibunrui = kit.KenchikuyotoDaibunrui5 ");
            sqlContent.Append("                                     AND km5.KenchikuyotoShobunrui = kit.KenchikuyotoShobunrui5 ");
            sqlContent.Append("                                     AND km5.KenchikuyotoRenban = kit.KenchikuyotoRenban5 ");

            sqlContent.Append(" LEFT OUTER JOIN NameMst nm2 ON nm2.NameCd = kit.KensaIraiHoryusakiCd AND nm2.NameKbn = '001' ");

            sqlContent.Append(" LEFT OUTER JOIN KensaKekkaTbl kkt ON kit.KensaIraiHoteiKbn = kkt.KensaKekkaIraiHoteiKbn ");
            sqlContent.Append("                             AND kit.KensaIraiHokenjoCd = kkt.KensaKekkaIraiHokenjoCd ");
            sqlContent.Append("                             AND kit.KensaIraiNendo = kkt.KensaKekkaIraiNendo ");
            sqlContent.Append("                             AND kit.KensaIraiRenban = kkt.KensaKekkaIraiRenban ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KishakuBairitsuKensaKekkaTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　豊田   　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KishakuBairitsuKensaKekkaTableAdapter
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
        /// 2014/12/26　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaDataTable GetDataBySearchCond(KensaIraishoOutputSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaDataTable dataTable = new KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaDataTable();
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
        /// 2014/12/26　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaIraishoOutputSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            sqlContent.Append(" SELECT  ");
            sqlContent.Append("     A.KensaIraiJokasoHokenjoCd, ");
            sqlContent.Append("     A.KensaIraiJokasoTorokuNendo, ");
            sqlContent.Append("     A.KensaIraiJokasoRenban, ");
            sqlContent.Append("     A.KensaIraiSuishitsuUketsukeDt, ");
            sqlContent.Append("     A.KensaKekkaBOD ");
            sqlContent.Append(" FROM ( ");
            sqlContent.Append("     SELECT ");
            sqlContent.Append("         kit.KensaIraiJokasoHokenjoCd, ");
            sqlContent.Append("         kit.KensaIraiJokasoTorokuNendo, ");
            sqlContent.Append("         kit.KensaIraiJokasoRenban, ");
            sqlContent.Append("         kit.KensaIraiSuishitsuUketsukeDt, ");
            sqlContent.Append("         kkt.KensaKekkaBOD, ");
            sqlContent.Append("         RANK () OVER (PARTITION BY kit.KensaIraiJokasoHokenjoCd, kit.KensaIraiJokasoTorokuNendo, kit.KensaIraiJokasoRenban ORDER BY kit.KensaIraiSuishitsuUketsukeDt DESC, kit.KensaIraiHoteiKbn DESC, kit.KensaIraiHokenjoCd DESC, kit.KensaIraiNendo DESC, kit.KensaIraiRenban DESC) AS Rank ");
            sqlContent.Append("     FROM ");
            sqlContent.Append("         KensaIraiTbl AS kit ");
            sqlContent.Append("         INNER JOIN  ");
            sqlContent.Append("             ( ");
            
            #region フィルタリング用

            sqlContent.Append("SELECT TOP 2000 A.JokasoHokenjoCd, A.JokasoTorokuNendo, A.JokasoRenban FROM (");

            #region SELECT
            sqlContent.Append(" SELECT  '1' AS selectCol, ");
            sqlContent.Append("         jdm.JokasoHokenjoCd, ");
            sqlContent.Append("         jdm.JokasoTorokuNendo, ");
            sqlContent.Append("         jdm.JokasoRenban, ");
            sqlContent.Append("         CONCAT(jdm.JokasoHokenjoCd, '-',  ");
            sqlContent.Append("                 [dbo].[FuncConvertIraiNedoToWareki](jdm.JokasoTorokuNendo), '-',  ");
            sqlContent.Append("                 jdm.JokasoRenban) AS jokasoNoCol, ");
            sqlContent.Append("         jdm.JokasoSetchishaNm AS settisyaCol, ");
            sqlContent.Append("         jdm.JokasoSetchiBashoAdr AS settiBasyoCol, ");
            sqlContent.Append("         jdm.JokasoGenChikuCd, ");
            sqlContent.Append("         cm.ChikuNm AS chikuNmCol, ");
            sqlContent.Append("         jdm.JokasoGaikanTikuwariKbn AS gaikanChikuCol, ");
            sqlContent.Append("         '   ' AS kishakuBairitsuCol, ");
            sqlContent.Append("         dskkm.DaichoKensaSetNm AS keiryoShomeiNmCol, ");
            sqlContent.Append("         dskkm.DaichoKensaKomokuEdaban AS kensaKomokuEdabanCol, ");
            sqlContent.Append("         jdm.JokasoSuisitsuSishoCd ");
            #endregion

            #region FROM
            sqlContent.Append(" FROM JokasoDaichoMst jdm ");
            sqlContent.Append(" LEFT OUTER JOIN ChikuMst cm ON cm.ChikuCd = jdm.JokasoGenChikuCd ");
            sqlContent.Append(" LEFT OUTER JOIN ");
            //sqlContent.Append(" (SELECT TOP(1) ");
            //sqlContent.Append(" DaichoKensaKomokuEdaban, ");
            //sqlContent.Append(" DaichoKensaSetNm, ");
            //sqlContent.Append(" JokasoHokenjoCd, ");
            //sqlContent.Append(" JokasoTorokuNendo, ");
            //sqlContent.Append(" JokasoRenban ");
            //sqlContent.Append(" FROM DaichoSuishitsuKensaKomokuMst ");
            //sqlContent.Append("  ORDER BY DaichoKensaKomokuEdaban ");
            //sqlContent.Append("  ) AS dskkm ON dskkm.JokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            //sqlContent.Append("             AND dskkm.JokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            //sqlContent.Append("             AND dskkm.JokasoRenban = jdm.JokasoRenban            ");
            sqlContent.Append("(SELECT");
            sqlContent.Append("   MAX(DaichoKensaKomokuEdaban) As DaichoKensaKomokuEdaban, ");
            sqlContent.Append("   JokasoHokenjoCd, ");
            sqlContent.Append("   JokasoTorokuNendo, ");
            sqlContent.Append("   JokasoRenban ");
            sqlContent.Append(" FROM DaichoSuishitsuKensaKomokuMst ");
            sqlContent.Append(" GROUP BY ");
            sqlContent.Append("   JokasoHokenjoCd, ");
            sqlContent.Append("   JokasoTorokuNendo, ");
            sqlContent.Append("   JokasoRenban ");
            sqlContent.Append("  ) AS dskkmmax ON dskkmmax.JokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            sqlContent.Append("               AND dskkmmax.JokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            sqlContent.Append("               AND dskkmmax.JokasoRenban = jdm.JokasoRenban            ");
            sqlContent.Append("LEFT OUTER JOIN");
            sqlContent.Append(" (SELECT ");
            sqlContent.Append(" DaichoKensaKomokuEdaban, ");
            sqlContent.Append(" DaichoKensaSetNm, ");
            sqlContent.Append(" JokasoHokenjoCd, ");
            sqlContent.Append(" JokasoTorokuNendo, ");
            sqlContent.Append(" JokasoRenban ");
            sqlContent.Append(" FROM DaichoSuishitsuKensaKomokuMst ");
            sqlContent.Append("  ) AS dskkm ON dskkm.JokasoHokenjoCd = dskkmmax.JokasoHokenjoCd ");
            sqlContent.Append("             AND dskkm.JokasoTorokuNendo = dskkmmax.JokasoTorokuNendo ");
            sqlContent.Append("             AND dskkm.JokasoRenban = dskkmmax.JokasoRenban            ");
            sqlContent.Append("             AND dskkm.DaichoKensaKomokuEdaban = dskkmmax.DaichoKensaKomokuEdaban ");
            #endregion

            #region WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            //出力依頼書/11条水質
            if (searchCond.Shutsuryoku == "1")
            {
                sqlContent.Append(" AND jdm.JokasoShoriTaishoJinin <= 50  ");
            }

            //外観検査地区
            if (searchCond.GaikanChiku != null && searchCond.GaikanChiku.Count > 0 && searchCond.GaikanChiku.Count < 5)
            {
                string gaikanTikuwariKbn = string.Empty;
                for (int i = 0; i < searchCond.GaikanChiku.Count; i++)
                {
                    gaikanTikuwariKbn += string.Format("'{0}',", searchCond.GaikanChiku[i]);
                }

                sqlContent.Append(" AND jdm.JokasoGaikanTikuwariKbn IN (" + gaikanTikuwariKbn.Remove(gaikanTikuwariKbn.Length - 1) + ")");
            }

            //浄化槽番号（開始） (保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                sqlContent.Append(" AND jdm.JokasoHokenjoCd >= @hokenjoCdFrom");
                commandParams.Add("@hokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }

            //浄化槽番号（開始） (年度)
            if (!string.IsNullOrEmpty(searchCond.NendoFrom))
            {
                sqlContent.Append(" AND jdm.JokasoTorokuNendo >= @nendoFrom");
                commandParams.Add("@nendoFrom", SqlDbType.NVarChar).Value = Utility.DateUtility.ConvertFromWareki(searchCond.NendoFrom, "yyyy");
            }

            //浄化槽番号（開始） (連番)
            if (!string.IsNullOrEmpty(searchCond.RenbanFrom))
            {
                sqlContent.Append(" AND jdm.JokasoRenban >= @renbanFrom");
                commandParams.Add("@renbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;
            }

            //浄化槽番号（終了）(保健所コード)
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                sqlContent.Append(" AND jdm.JokasoHokenjoCd <= @hokenjoCdTo");
                commandParams.Add("@hokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            //浄化槽番号（終了）(年度)
            if (!string.IsNullOrEmpty(searchCond.NendoTo))
            {
                sqlContent.Append(" AND jdm.JokasoTorokuNendo <= @nendoTo");
                commandParams.Add("@nendoTo", SqlDbType.NVarChar).Value = Utility.DateUtility.ConvertFromWareki(searchCond.NendoTo, "yyyy");
            }

            //浄化槽番号（終了）(連番)
            if (!string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append(" AND jdm.JokasoRenban <= @renbanTo");
                commandParams.Add("@renbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }

            //地区コード（開始）
            if (!string.IsNullOrEmpty(searchCond.ChikuCdFrom))
            {
                sqlContent.Append(" AND jdm.JokasoGenChikuCd >= @chikuFrom");
                commandParams.Add("@chikuFrom", SqlDbType.NVarChar).Value = searchCond.ChikuCdFrom;
            }

            //地区コード（終了）
            if (!string.IsNullOrEmpty(searchCond.ChikuCdTo))
            {
                sqlContent.Append(" AND jdm.JokasoGenChikuCd <= @chikuTo");
                commandParams.Add("@chikuTo", SqlDbType.NVarChar).Value = searchCond.ChikuCdTo;
            }

            //設置者
            if (!string.IsNullOrEmpty(searchCond.SetchishaNm))
            {
                sqlContent.Append(" AND jdm.JokasoSetchishaNm LIKE CONCAT('%', @setchishaNm, '%')");
                commandParams.Add("@setchishaNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.SetchishaNm);
            }

            // 2014/12/11 DatNT v1.01 ADD Start
            if (!string.IsNullOrEmpty(searchCond.UketsukeDtFrom) && !string.IsNullOrEmpty(searchCond.UketsukeDtTo))
            {
                if (searchCond.Shutsuryoku == "1")
                {
                    sqlContent.Append(" AND EXISTS                                                                  ");
                    sqlContent.Append("         (   SELECT *                                                        ");
                    sqlContent.Append("             FROM KensaIraiTbl                                               ");
                    sqlContent.Append("             WHERE KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd            ");
                    sqlContent.Append("                   AND KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo    ");
                    sqlContent.Append("                   AND KensaIraiJokasoRenban = jdm.JokasoRenban              ");
                    sqlContent.Append("                   AND KensaIraiSuishitsuUketsukeDt >= @uketsukeDtFrom       ");
                    sqlContent.Append("                   AND KensaIraiSuishitsuUketsukeDt <= @uketsukeDtTo         ");
                    sqlContent.Append("         )                                                                   ");
                }
                else
                {
                    sqlContent.Append(" AND EXISTS                                                                  ");
                    sqlContent.Append("         (   SELECT *                                                        ");
                    sqlContent.Append("             FROM KeiryoShomeiIraiTbl                                        ");
                    sqlContent.Append("             WHERE KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd   ");
                    sqlContent.Append("                   AND KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo ");
                    sqlContent.Append("                   AND KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban     ");
                    sqlContent.Append("                   AND KeiryoShomeiIraiUketsukeDt >= @uketsukeDtFrom         ");
                    sqlContent.Append("                   AND KeiryoShomeiIraiUketsukeDt <= @uketsukeDtTo           ");
                    sqlContent.Append("         )                                                                   ");
                }

                commandParams.Add("@uketsukeDtFrom", SqlDbType.NVarChar).Value = searchCond.UketsukeDtFrom;
                commandParams.Add("@uketsukeDtTo", SqlDbType.NVarChar).Value = searchCond.UketsukeDtTo;
            }
            // 2014/12/11 DatNT v1.01 ADD End

            #endregion

            sqlContent.Append(") As A");

            sqlContent.Append(" ORDER BY ");
            sqlContent.Append("         A.JokasoHokenjoCd, ");
            sqlContent.Append("         A.JokasoTorokuNendo, ");
            sqlContent.Append("         A.JokasoRenban ");

            #endregion

            sqlContent.Append("             ) As filtering ");
            sqlContent.Append("         ON  filtering.JokasoHokenjoCd = kit.KensaIraiJokasoHokenjoCd ");
            sqlContent.Append("         AND filtering.JokasoTorokuNendo = kit.KensaIraiJokasoTorokuNendo ");
            sqlContent.Append("         AND filtering.JokasoRenban = kit.KensaIraiJokasoRenban ");
            sqlContent.Append("         INNER JOIN ");
            sqlContent.Append("             KensaKekkaTbl AS kkt ");
            sqlContent.Append("         ON  kkt.KensaKekkaIraiHoteiKbn = kit.KensaIraiHoteiKbn ");
            sqlContent.Append("         AND kkt.KensaKekkaIraiHokenjoCd = kit.KensaIraiHokenjoCd ");
            sqlContent.Append("         AND kkt.KensaKekkaIraiNendo = kit.KensaIraiNendo ");
            sqlContent.Append("         AND kkt.KensaKekkaIraiRenban = kit.KensaIraiRenban ");
            sqlContent.Append("     WHERE ");
            sqlContent.Append("         (kit.KensaIraiSuishitsuUketsukeDt <> '') ");
            sqlContent.Append("     AND (kkt.KensaKekkaBOD > 0) ");
            sqlContent.Append("     ) As A ");
            sqlContent.Append("     WHERE ");
            sqlContent.Append("         A.Rank = 1 ");
            sqlContent.Append("     ORDER BY ");
            sqlContent.Append("         A.KensaIraiJokasoHokenjoCd, ");
            sqlContent.Append("         A.KensaIraiJokasoTorokuNendo, ");
            sqlContent.Append("         A.KensaIraiJokasoRenban, ");
            sqlContent.Append("         A.KensaIraiSuishitsuUketsukeDt ");

            command.CommandText = sqlContent.ToString();
            // TODO 水質検査依頼書で使用(遅すぎるので、見直し検討)
            return command;
        }
        #endregion
    }
    #endregion

}
