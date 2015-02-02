using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet
{

    #region TuckSealSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TuckSealSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class TuckSealSearchCond
    {
        /// <summary>
        /// 1: 発行区分/業者(3)
        /// 2: 発行区分/保健所(4)
        /// 3: 発行区分/設置者(5)
        /// </summary>
        public string RdSelect { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        public string SearchNm { get; set; }

        /// <summary>
        /// 登録年月
        /// </summary>
        public string Nengetsu { get; set; }

        /// <summary>
        /// 保健所コード
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// コード（開始）
        /// </summary>
        public string CdFrom { get; set; }

        /// <summary>
        /// コード（終了）
        /// </summary>
        public string CdTo { get; set; }
    }
    #endregion

    #region JokasoDaichoMstSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoDaichoMstSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class JokasoDaichoMstSearchCond
    {
        /// <summary>
        /// 保健所コード
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年月 
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番FROM
        /// </summary>
        public string RenbanFrom { get; set; }

        /// <summary>
        /// 浄化槽台帳連番TO
        /// </summary>
        public string RenbanTo { get; set; }

        /// <summary>
        /// 設置者名
        /// </summary>
        public string SettisyaNm { get; set; }

        /// <summary>
        /// 設置住所
        /// </summary>
        public string SettiAdr { get; set; }
    }
    #endregion

    #region KensaIraishoOutputSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraishoOutputSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02 HuyTX　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KensaIraishoOutputSearchCond
    {
        /// <summary>
        /// 出力依頼書
        /// </summary>
        public string Shutsuryoku { get; set; }

        /// <summary>
        /// 外観検査地区/A
        /// 外観検査地区/B
        /// 外観検査地区/C
        /// 外観検査地区/D
        /// 外観検査地区/E
        /// </summary>
        public List<string> GaikanChiku { get; set; }

        /// <summary>
        /// 浄化槽番号（開始） (保健所コード)
        /// </summary>
        public string HokenjoCdFrom { get; set; }

        /// <summary>
        /// 浄化槽番号（開始） (年度)
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// 浄化槽番号（開始） (連番)
        /// </summary>
        public string RenbanFrom { get; set; }

        /// <summary>
        /// 浄化槽番号（終了） (保健所コード)
        /// </summary>
        public string HokenjoCdTo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了） (年度)
        /// </summary>
        public string NendoTo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了） (連番)
        /// </summary>
        public string RenbanTo { get; set; }

        /// <summary>
        /// 地区コード（開始） 
        /// </summary>
        public string ChikuCdFrom { get; set; }

        /// <summary>
        /// 地区コード（終了） 
        /// </summary>
        public string ChikuCdTo { get; set; }

        /// <summary>
        /// 設置者
        /// </summary>
        public string SetchishaNm { get; set; }

        /// <summary>
        /// 検査受付日（開始）
        /// </summary>
        public string UketsukeDtFrom { get; set; }

        /// <summary>
        /// 検査受付日（終了）
        /// </summary>
        public string UketsukeDtTo { get; set; }

    }
    #endregion

    public partial class JokasoDaichoMstDataSet
    {
        partial class JokasoDaichoSyukeiListDataTable
        {
        }
    
        partial class JokasoDaichoMstSearchDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters
{
    partial class JokasoDaichoGyoshaMstSearchTableAdapter
    {
    }
    
    #region JokasoDaichoMstSearchTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoDaichoMstSearchTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class JokasoDaichoMstSearchTableAdapter
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
        /// 2014/08/12　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable GetDataBySearchCond(JokasoDaichoMstSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable dataTable = new JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable();
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
        /// 2014/08/12　AnhNV　　新規作成
        /// 2014/09/29  AnhNV   基本設計書_000_007_画面_浄化槽台帳v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(JokasoDaichoMstSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            // 20141228 habu
            sqlContent.Append(" select TOP 2000                                                                                                                                                                         ");
            //sqlContent.Append(" select                                                                                                                                                                                  ");
            // 20141228 End
            sqlContent.Append("     jdm.JokasoHokenjoCd,                                                                                                                                                                ");
            sqlContent.Append("     hm.HokenjoNm,                                                                                                                                                                       ");
            sqlContent.Append("     jdm.JokasoTorokuNendo,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoRenban,                                                                                                                                                                   ");
            sqlContent.Append("     jdm.JokasoKbn,                                                                                                                                                                      ");
            sqlContent.Append("     jdm.JokasoSetchishaKbn,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoSetchishaCd,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoSetchishaKana,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoKensakuKana,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoSetchishaNm,                                                                                                                                                              ");
            //sqlContent.Append("     -- jdm.JokasoSetchishaShikuchoson,                                                                                       ");
            sqlContent.Append("     jdm.JokasoSetchishaAdr,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoSetchishaZipCd,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoSetchishaTelNo,                                                                                                                                                           ");
            //sqlContent.Append("     -- jdm.JokasoSetchiBashoShikuchoson,                                                                                     ");
            sqlContent.Append("     jdm.JokasoSetchiBashoAdr,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoSetchiBashoZipCd,                                                                                                                                                         ");
            sqlContent.Append("     jdm.JokasoSetchiBashoTelNo,                                                                                                                                                         ");
            sqlContent.Append("     jdm.JokasoShisetsuNm,                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoSetchiBashoHokenjoCd,                                                                                                                                                     ");
            sqlContent.Append("     jdm.JokasoKyuChikuCd,                                                                                                                                                               ");
            // 2014/09/29 AnhNV ADD START
            sqlContent.Append("     jdm.JokasoTodokedeSetchishaNm,                                                                                                                                                      ");
            sqlContent.Append("     jdm.JokasoTodokedeSetchishaAdr,                                                                                                                                                     ");
            sqlContent.Append("     jdm.JokasoTodokedeSetchishaZipCd,                                                                                                                                                   ");
            sqlContent.Append("     jdm.JokasoTodokedeSetchishaTelNo,                                                                                                                                                   ");
            sqlContent.Append("     jdm.JokasoShiyoshaNm,                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoShiyoshaAdr,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoShiyoshaZipCd,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoShiyoshaTelNo,                                                                                                                                                            ");
            // 2014/09/29 AnhNV ADD END
            sqlContent.Append("     jdm.JokasoHoteiSishoCd,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoSuisitsuSishoCd,                                                                                                                                                          ");
            sqlContent.Append("     jdm.JokasoSaisuiGyoshaCd,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoSeikyuGyoshaCd,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoMochikomiGyoshaCd,                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoKatashikiCd,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoShoriHosikiKbn,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoShoriHosikiCd,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoShoriHosikiShubetu,                                                                                                                                                       ");
            sqlContent.Append("     jdm.JokasoSyoriMokuhyoBOD,                                                                                                                                                          ");
            sqlContent.Append("     jdm.JokasoShohinNm,                                                                                                                                                                 ");
            sqlContent.Append("     jdm.JokasoShoriTaishoJinin,                                                                                                                                                         ");
            sqlContent.Append("     jdm.JokasoHiHeikinOsuiRyo,                                                                                                                                                          ");
            sqlContent.Append("     jdm.JokasoJitsuSiyoJinin,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoJitsuHiHeikinOsuiRyo,                                                                                                                                                     ");
            sqlContent.Append("     jdm.JokasoSuisitsuKensaKaisu,                                                                                                                                                       ");
            sqlContent.Append("     jdm.JokasoHojokinKoufuFlg,                                                                                                                                                          ");
            sqlContent.Append("     (CASE WHEN ISDATE(concat(jdm.JokasoSiyokaisiNen, jdm.JokasoSiyokaisiTsuki, jdm.JokasoSiyokaisiBi))=0 then ''                                                                        ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,concat(jdm.JokasoSiyokaisiNen, jdm.JokasoSiyokaisiTsuki, jdm.JokasoSiyokaisiBi)), 111) END) AS JokasoSiyokaisiNenTsukiBi,               ");
            sqlContent.Append("     (CASE WHEN ISDATE(concat(jdm.JokasoSetchiNen, jdm.JokasoSetchiTsuki, jdm.JokasoSetchiBi))=0 then ''                                                                                 ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,concat(jdm.JokasoSetchiNen, jdm.JokasoSetchiTsuki, jdm.JokasoSetchiBi)), 111) END) AS JokasoSetchiNenTsukiBi,                           ");
            sqlContent.Append("     jdm.JokasoTorikesiKbn,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoShodokuSetsubiUmuFlg,                                                                                                                                                     ");
            sqlContent.Append("     jdm.JokasoGaikanTikuwariKbn,                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoRiyuKbn,                                                                                                                                                                  ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.JokasoSaishuKensaBi)=0 then ''                                                                                                                                ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.JokasoSaishuKensaBi), 111) END) AS JokasoSaishuKensaBi,                                                                             ");
            sqlContent.Append("     jdm.JokasoSoufusakiNm,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoSoufusakiZipCd,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoSoufusakiAdr,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoSoufusakiTelNo,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoSeikyusakiNm,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoSeikyusakiZipCd,                                                                                                                                                          ");
            sqlContent.Append("     jdm.JokasoSeikyusakiAdr,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoSeikyusakiTelNo,                                                                                                                                                          ");
            sqlContent.Append("     jdm.JokasoRenrakusakiNm,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoRenrakusakiZipCd,                                                                                                                                                         ");
            sqlContent.Append("     jdm.JokasoRenrakusakiAdr,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoRenrakusakiTelNo,                                                                                                                                                         ");
            sqlContent.Append("     jdm.JokasoItkatsuSoufuGyoshaCd,                                                                                                                                                     ");
            sqlContent.Append("     jdm.JokasoItkatsuSeikyuGyoshaCd,                                                                                                                                                    ");
            sqlContent.Append("     jdm.JokasoBettoSoufuGyoshaCd1,                                                                                                                                                      ");
            sqlContent.Append("     jdm.JokasoBettoSoufuGyoshaCd2,                                                                                                                                                      ");
            sqlContent.Append("     jdm.JokasoBettoSoufuGyoshaCd3,                                                                                                                                                      ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.JokasoTorisageBi)=0 then ''                                                                                                                                   ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.JokasoTorisageBi), 111) END) AS JokasoTorisageBi,                                                                                   ");
            // 2014/09/29 ANHNV ADD START
            sqlContent.Append("     jdm.KenchikuyotoDaibunrui1,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoShobunrui1,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoRenban1,                                                                                                                                                            ");
            sqlContent.Append("     jdm.KenchikuyotoDaibunrui2,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoShobunrui2,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoRenban2,                                                                                                                                                            ");
            sqlContent.Append("     jdm.KenchikuyotoDaibunrui3,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoShobunrui3,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoRenban3,                                                                                                                                                            ");
            sqlContent.Append("     jdm.KenchikuyotoDaibunrui4,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoShobunrui4,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoRenban4,                                                                                                                                                            ");
            sqlContent.Append("     jdm.KenchikuyotoDaibunrui5,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoShobunrui5,                                                                                                                                                         ");
            sqlContent.Append("     jdm.KenchikuyotoRenban5,                                                                                                                                                            ");
            // 2014/09/29 ANHNV ADD END
            sqlContent.Append("     jdm.JokasoOldKentikuYoutoCd,                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoJokasoTorokuNo,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoMekaGyoshaCd,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoKojiGyoshaKbn,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoHoshutenkenGyoshaCd,                                                                                                                                                      ");
            sqlContent.Append("     jdm.JokasoSeisouGyoshaCd,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoHoryusakiCd,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoJokasoKumitateKbn,                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoHoshoNoKensakikan,                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoHoshoNoNendo,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoHoshoNoRenban,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoHouKonkyoKbn,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoHokenjoJuriNoHokenCd,                                                                                                                                                     ");
            sqlContent.Append("     jdm.JokasoHokenjoJuriNoNendo,                                                                                                                                                       ");
            sqlContent.Append("     jdm.JokasoHokenjoJuriNoSichosonCd,                                                                                                                                                  ");
            sqlContent.Append("     jdm.JokasoHokenjoJuriNoRenban,                                                                                                                                                      ");
            sqlContent.Append("     jdm.JokasoChizuNo,                                                                                                                                                                  ");
            sqlContent.Append("     jdm.JokasoKensaHitsuyoJinin,                                                                                                                                                        ");
            sqlContent.Append("     jdm.Jokaso11JoJissiKbn,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoHagakiSoufusakiKbn,                                                                                                                                                       ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.Jokaso7JoKensaBi)=0 then ''                                                                                                                                  ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.Jokaso7JoKensaBi), 111) END) AS Jokaso7JoKensaBi,                                                                                 ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.Jokaso11JokensaBi)=0 then ''                                                                                                                                  ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.Jokaso11JokensaBi), 111) END) AS Jokaso11JokensaBi,                                                                                 ");
            sqlContent.Append("     jdm.Jokaso7JoKensaJokyoKbn,                                                                                                                                                         ");
            sqlContent.Append("     jdm.Jokaso11JoKensaJokyoKbn,                                                                                                                                                        ");
            sqlContent.Append("     jdm.Jokaso7JoKensaRyokin,                                                                                                                                                           ");
            sqlContent.Append("     jdm.Jokaso11JoKensaRyokin,                                                                                                                                                          ");
            sqlContent.Append("     jdm.Jokaso3JiShoriFlg,                                                                                                                                                              ");
            sqlContent.Append("     jdm.Jokaso3JiShoriType,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoGensuiPonpuFlg,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoHoryuPonpuFlg,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoDisupozaFlg,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoKoujiKbn,                                                                                                                                                                 ");
            sqlContent.Append("     jdm.JokasoKoujiNen,                                                                                                                                                                 ");
            sqlContent.Append("     jdm.JokasoKoujiNo,                                                                                                                                                                  ");
            sqlContent.Append("     jdm.JokasoNinteiNo,                                                                                                                                                                 ");
            sqlContent.Append("     jdm.JokasoDMHassouKbn,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoDMKekkaKbn,                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoSichosonSetchiKbn,                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoJukenKeihatsuDMHassouKbn,                                                                                                                                                 ");
            sqlContent.Append("     jdm.JokasoJukenKeihatsuDMKekkaKbn,                                                                                                                                                  ");
            sqlContent.Append("     jdm.JokasoShogouSetchishaCd,                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoShuyakumaeSuisitsuSetchishaCd,                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoTegakiMemo,                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoTegakiMemo2,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoTatemonoNobeMenseki,                                                                                                                                                      ");
            //sqlContent.Append("     jdm.JokasoSinSichosonCd,                                                                                                                                                            ");
            // 2014/11/18 HieuNH ADD 
            //sqlContent.Append("     jdm.IkkatsuSeikyuSakiCd,                                                                                                                                                            ");
            
            sqlContent.Append("     jdm.JokasoJitsuSiyouJininSuchi,                                                                                                                                                     ");
            sqlContent.Append("     jdm.JokasoKasaageTakasa,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoChizuNendo,                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoChizuPageNo,                                                                                                                                                              ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.JokasoUketsukeBi)=0 then ''                                                                                                                                   ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.JokasoUketsukeBi), 111) END) AS JokasoUketsukeBi,                                                                                   ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.JokasoJuriBi)=0 then ''                                                                                                                                       ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.JokasoJuriBi), 111) END) AS JokasoJuriBi,                                                                                           ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.JokasoChosaBi)=0 then ''                                                                                                                                      ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.JokasoChosaBi), 111) END) AS JokasoChosaBi,                                                                                         ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.JokasoKanrishaHenkouBi)=0 then ''                                                                                                                             ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.JokasoKanrishaHenkouBi), 111) END) AS JokasoKanrishaHenkouBi,                                                                       ");
            sqlContent.Append("     jdm.JokasoHenkoumaeKanrishaNm,                                                                                                                                                      ");
            sqlContent.Append("     jdm.JokasoHenkoumaeSetchiBashoAdr,                                                                                                                                                  ");
            sqlContent.Append("     jdm.JokasoJotaiKbn,                                                                                                                                                                 ");
            sqlContent.Append("     (CASE WHEN ISDATE(jdm.JokasoHaishiBi)=0 then ''                                                                                                                                     ");
            sqlContent.Append("         ELSE CONVERT(CHAR(10), CONVERT(DATETIME,jdm.JokasoHaishiBi), 111) END) AS JokasoHaishiBi,                                                                                       ");
            sqlContent.Append("     jdm.JokasoJohogenKbn,                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoRyunyuTairyuTakasa,                                                                                                                                                       ");
            sqlContent.Append("     jdm.JokasoHouryuTairyuTakasa,                                                                                                                                                       ");
            sqlContent.Append("     jdm.JokasoKensaTantoshaNm,                                                                                                                                                          ");
            sqlContent.Append("     jdm.JokasoChizuNendo1,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoChizuPageNo1,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoHagakiKbn,                                                                                                                                                                ");
            sqlContent.Append("     jdm.JokasoGenChikuCd,                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoZenrinLinkCd,                                                                                                                                                             ");
            sqlContent.Append("     jdm.JokasoZenrinIdoCd,                                                                                                                                                              ");
            sqlContent.Append("     jdm.JokasoZenrinKeidoCd,                                                                                                                                                            ");
            sqlContent.Append("     jdm.JokasoChizuShutokuAdr,                                                                                                                                                          ");
            sqlContent.Append("     jdm.JokasoChizuShutokuNm                                                                                                                                                            ");
            // FROM
            sqlContent.Append(" from JokasoDaichoMst jdm                                                                                                                                                                ");
            sqlContent.Append(" left outer join HokenjoMst hm                                                                                                                                                           ");
            sqlContent.Append("     on jdm.JokasoHokenjoCd = hm.HokenjoCd                                                                                                                                               ");
            // WHERE
            sqlContent.Append(" where 1 = 1 ");

            // 台帳連番（開始）~ 台帳連番（終了）
            //sqlContent.Append("     jdm.JokasoRenban " + DataAccessUtility.SetBetweenCommand(searchCond.RenbanFrom, searchCond.RenbanTo, 5));
            if (!string.IsNullOrEmpty(searchCond.RenbanFrom) && string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append("AND jdm.JokasoRenban >= @RenbanFrom ");
                commandParams.Add("@RenbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;
            }
            else if (string.IsNullOrEmpty(searchCond.RenbanFrom) && !string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append("AND jdm.JokasoRenban <= @RenbanTo ");
                commandParams.Add("@RenbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }
            else if (!string.IsNullOrEmpty(searchCond.RenbanFrom) && !string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append("AND jdm.JokasoRenban >= @RenbanFrom ");
                commandParams.Add("@RenbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;

                sqlContent.Append("AND jdm.JokasoRenban <= @RenbanTo ");
                commandParams.Add("@RenbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }

            // 保健所コード
            if (!string.IsNullOrEmpty(searchCond.HokenjoCd))
            {
                sqlContent.Append(" and jdm.JokasoHokenjoCd = @JokasoHokenjoCd");
                commandParams.Add("@JokasoHokenjoCd", SqlDbType.NVarChar).Value = (string)searchCond.HokenjoCd;
            }

            // 登録年月
            if (!string.IsNullOrEmpty(searchCond.JokasoTorokuNendo))
            {
                sqlContent.Append(" and jdm.JokasoTorokuNendo = @JokasoTorokuNendo");
                commandParams.Add("@JokasoTorokuNendo", SqlDbType.NVarChar).Value = (string)searchCond.JokasoTorokuNendo;
            }

            // 設置者名
            if (!string.IsNullOrEmpty(searchCond.SettisyaNm))
            {
                sqlContent.Append(" and (jdm.JokasoSetchishaKana like concat('%', @JokasoSetchishaNm1, '%')");
                sqlContent.Append("   or jdm.JokasoKensakuKana like concat('%', @JokasoSetchishaNm2, '%')");
                sqlContent.Append("   or jdm.JokasoSetchishaNm like concat('%', @JokasoSetchishaNm3, '%'))");
                commandParams.Add("@JokasoSetchishaNm1", SqlDbType.NVarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SettisyaNm);
                commandParams.Add("@JokasoSetchishaNm2", SqlDbType.NVarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SettisyaNm);
                commandParams.Add("@JokasoSetchishaNm3", SqlDbType.NVarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SettisyaNm);
            }

            // 設置住所
            if (!string.IsNullOrEmpty(searchCond.SettiAdr))
            {
                sqlContent.Append(" and jdm.JokasoSetchishaAdr like concat('%', @JokasoSetchishaAdr, '%')");
                commandParams.Add("@JokasoSetchishaAdr", SqlDbType.NVarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SettiAdr);
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region TuckSealListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TuckSealListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class TuckSealListTableAdapter
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
        /// 2014/08/08　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal JokasoDaichoMstDataSet.TuckSealListDataTable GetDataBySearchCond(TuckSealSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            JokasoDaichoMstDataSet.TuckSealListDataTable dataTable = new JokasoDaichoMstDataSet.TuckSealListDataTable();
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
        /// 2014/08/08　AnhNV　　新規作成
        /// 2014/10/09  AnhNV　　    新規作成基本設計書_008_003_画面_TuckSealList_V1.04
        /// 2015/01/26　kiyokuni　TOP 2000対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(TuckSealSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // 業者マスタ search
            if (searchCond.RdSelect == "1")
            {
                sqlContent.Append(" select TOP 2000                                                                                                                          ");
                //sqlContent.Append(" select                                                                                                                          ");
                sqlContent.Append("     '1' as KbnCol,                                                                                                              ");
                sqlContent.Append("     gm.GyoshaCd as CdCol,                                                                                                       ");
                sqlContent.Append("     '' as NengetsuCol,                                                                                                          ");
                sqlContent.Append("     '' as RenbanCol,                                                                                                            ");
                sqlContent.Append("     gm.GyoshaNm as NmCol,                                                                                                       ");
                sqlContent.Append("     gm.GyoshaZipCd as ZipNoCol,                                                                                                 ");
                sqlContent.Append("     gm.GyoshaAdr as AdrCol                                                                                                      ");
                sqlContent.Append(" from GyoshaMst gm                                                                                                               ");
                sqlContent.Append(" where 1 = 1                                                                                                                     ");
                // 業者コードFROM ~ TO
                //sqlContent.Append("     gm.GyoshaCd " + DataAccessUtility.SetBetweenCommand(searchCond.CdFrom, searchCond.CdTo, 4));

                if (!string.IsNullOrEmpty(searchCond.CdFrom) && string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND gm.GyoshaCd >= @CdFrom ");
                    commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;
                }
                else if (string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND gm.GyoshaCd <= @CdTo ");
                    commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                }
                else if (!string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND gm.GyoshaCd >= @CdFrom ");
                    commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;

                    sqlContent.Append("AND gm.GyoshaCd <= @CdTo ");
                    commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                }
                
                if (!string.IsNullOrEmpty(searchCond.SearchNm))
                {
                    // 業者名称
                    sqlContent.Append(" and gm.GyoshaNm like concat('%', @GyoshaNm, '%')");
                    commandParams.Add("@GyoshaNm", SqlDbType.VarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SearchNm);
                }

                // ORDER BY
                sqlContent.Append(" order by gm.GyoshaCd");
            }
            else if (searchCond.RdSelect == "2") // 保健所マスタ search
            {
                sqlContent.Append(" select TOP 2000                                                                                                                          ");
                //sqlContent.Append(" select                                                                                                                          ");
                sqlContent.Append("     '1' as KbnCol,                                                                                                              ");
                sqlContent.Append("     hm.HokenjoCd as CdCol,                                                                                                      ");
                sqlContent.Append("     '' as NengetsuCol,                                                                                                          ");
                sqlContent.Append("     '' as RenbanCol,                                                                                                            ");
                sqlContent.Append("     hm.HokenjoNm as NmCol,                                                                                                      ");
                sqlContent.Append("     hm.HokenjoZipCd as ZipNoCol,                                                                                                ");
                sqlContent.Append("     hm.HokenjoAdr as AdrCol                                                                                                     ");
                sqlContent.Append(" from HokenjoMst hm                                                                                                              ");
                sqlContent.Append(" where 1=1                                                                                                                       ");

                // 保健所コードFROM ~ TO
                if (!string.IsNullOrEmpty(searchCond.HokenjoCd))
                {
                    sqlContent.Append("     and hm.HokenjoCd = @HokenjoCd ");
                    commandParams.Add("@HokenjoCd", SqlDbType.NVarChar).Value = (string)searchCond.HokenjoCd;
                }
                else
                {
                    //sqlContent.Append("     and hm.HokenjoCd " + DataAccessUtility.SetBetweenCommand(searchCond.CdFrom, searchCond.CdTo, 2));

                    if (!string.IsNullOrEmpty(searchCond.CdFrom) && string.IsNullOrEmpty(searchCond.CdTo))
                    {
                        sqlContent.Append(" AND hm.HokenjoCd >= @CdFrom ");
                        commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;
                    }
                    else if (string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                    {
                        sqlContent.Append(" AND hm.HokenjoCd <= @CdTo ");
                        commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                    }
                    else if (!string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                    {
                        sqlContent.Append(" AND hm.HokenjoCd >= @CdFrom ");
                        commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;

                        sqlContent.Append(" AND hm.HokenjoCd <= @CdTo ");
                        commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                    }
                }

                if (!string.IsNullOrEmpty(searchCond.SearchNm))
                {
                    // 設置者氏名
                    sqlContent.Append(" and hm.HokenjoNm like concat('%', @HokenjoNm, '%')");
                    commandParams.Add("@HokenjoNm", SqlDbType.NVarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SearchNm);
                }

                // ORDER BY
                sqlContent.Append(" order by hm.HokenjoCd");
            }
            else if (searchCond.RdSelect == "3") // 地区マスタ search
            {
                sqlContent.Append(" select TOP 2000                                                                                                                          ");
                //sqlContent.Append(" select                                                                                                                          ");
                sqlContent.Append("     '1' as KbnCol,                                                                                                              ");
                sqlContent.Append("     cm.ChikuCd as CdCol,                                                                                                        ");
                sqlContent.Append("     '' as NengetsuCol,                                                                                                          ");
                sqlContent.Append("     '' as RenbanCol,                                                                                                            ");
                sqlContent.Append("     cm.ChikuTantoKa as NmCol,                                                                                                   ");
                sqlContent.Append("     cm.ChikuTantoYubinNo as ZipNoCol,                                                                                           ");
                sqlContent.Append("     cm.ChikuTantoAdr as AdrCol                                                                                                  ");
                sqlContent.Append(" from ChikuMst cm                                                                                                                ");
                sqlContent.Append(" where                                                                                                                           ");
                sqlContent.Append("     cm. DelFlg != '1'                                                                                                           ");
                // 浄化槽台帳連番
                //sqlContent.Append("     and cm.ChikuCd " + DataAccessUtility.SetBetweenCommand(searchCond.CdFrom, searchCond.CdTo, 5));

                if (!string.IsNullOrEmpty(searchCond.CdFrom) && string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND cm.ChikuCd >= @CdFrom ");
                    commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;
                }
                else if (string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND cm.ChikuCd <= @CdTo ");
                    commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                }
                else if (!string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND cm.ChikuCd >= @CdFrom ");
                    commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;

                    sqlContent.Append("AND cm.ChikuCd <= @CdTo ");
                    commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                }

                if (!string.IsNullOrEmpty(searchCond.SearchNm))
                {
                    // 設置者氏名
                    sqlContent.Append(" and cm.ChikuTantoKa like concat('%', @ChikuTantoKa, '%')");
                    commandParams.Add("@ChikuTantoKa", SqlDbType.VarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SearchNm);
                }

                // ORDER BY
                sqlContent.Append(" order by cm.ChikuCd");
            }
            else // 浄化槽台帳マスタ search
            {
                sqlContent.Append(" select TOP 2000                                                                                                                          ");
                //sqlContent.Append(" select                                                                                                                          ");
                sqlContent.Append("     '1' as KbnCol,                                                                                                              ");
                sqlContent.Append("     jdm.JokasoHokenjoCd as CdCol,                                                                                               ");
                sqlContent.Append("     jdm.JokasoTorokuNendo as NengetsuCol,                                                                                       ");
                sqlContent.Append("     jdm.JokasoRenban as RenbanCol,                                                                                              ");
                sqlContent.Append("     jdm.JokasoSetchishaNm as NmCol,                                                                                             ");
                sqlContent.Append("     jdm.JokasoSetchishaZipCd as ZipNoCol,                                                                                       ");
                sqlContent.Append("     jdm.JokasoSetchishaAdr as AdrCol                                                                                            ");
                sqlContent.Append(" from JokasoDaichoMst jdm                                                                                                        ");
                sqlContent.Append(" where  1 = 1                                                                                                                    ");
                // 浄化槽台帳連番
                //sqlContent.Append("     jdm.JokasoRenban " + DataAccessUtility.SetBetweenCommand(searchCond.CdFrom, searchCond.CdTo, 5));

                if (!string.IsNullOrEmpty(searchCond.CdFrom) && string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND jdm.JokasoRenban >= @CdFrom ");
                    commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;
                }
                else if (string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND jdm.JokasoRenban <= @CdTo ");
                    commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                }
                else if (!string.IsNullOrEmpty(searchCond.CdFrom) && !string.IsNullOrEmpty(searchCond.CdTo))
                {
                    sqlContent.Append("AND jdm.JokasoRenban >= @CdFrom ");
                    commandParams.Add("@CdFrom", SqlDbType.NVarChar).Value = searchCond.CdFrom;

                    sqlContent.Append("AND jdm.JokasoRenban <= @CdTo ");
                    commandParams.Add("@CdTo", SqlDbType.NVarChar).Value = searchCond.CdTo;
                }

                if (!string.IsNullOrEmpty(searchCond.HokenjoCd))
                {
                    // 浄化槽台帳保健所コード
                    sqlContent.Append(" and jdm.JokasoHokenjoCd = @JokasoHokenjoCd");
                    commandParams.Add("@JokasoHokenjoCd", SqlDbType.VarChar).Value = (string)searchCond.HokenjoCd;
                }
                if (!string.IsNullOrEmpty(searchCond.Nengetsu))
                {
                    // 浄化槽台帳年度
                    sqlContent.Append(" and jdm.JokasoTorokuNendo = @JokasoTorokuNengetsu");
                    commandParams.Add("@JokasoTorokuNengetsu", SqlDbType.VarChar).Value = (string)searchCond.Nengetsu;
                }
                if (!string.IsNullOrEmpty(searchCond.SearchNm))
                {
                    // 設置者氏名
                    sqlContent.Append(" and jdm.JokasoSetchishaNm like concat('%', @JokasoSetchishaNm, '%')");
                    commandParams.Add("@JokasoSetchishaNm", SqlDbType.VarChar).Value = (string)DataAccessUtility.EscapeSQLString(searchCond.SearchNm);
                }

                // ORDER BY
                sqlContent.Append(" order by jdm.JokasoHokenjoCd, jdm.JokasoTorokuNendo, jdm.JokasoRenban");
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region JinendoGaikanOutputTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanOutputTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/23　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class JinendoGaikanOutputTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sakuhyoKbn1"></param>
        /// <param name="kensaNendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/23　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal JokasoDaichoMstDataSet.JinendoGaikanOutputDataTable GetDataBySearchCond(string sakuhyoKbn1, string kensaNendo)
        {
            SqlCommand command = CreateSqlCommand(sakuhyoKbn1, kensaNendo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            JokasoDaichoMstDataSet.JinendoGaikanOutputDataTable dataTable = new JokasoDaichoMstDataSet.JinendoGaikanOutputDataTable();
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
        /// <param name="sakuhyoKbn1"></param>
        /// <param name="kensaNendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/23　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string sakuhyoKbn1, string kensaNendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT                                                                      ");
            sqlContent.Append("         jdm.JokasoHokenjoCd,                                                ");
            sqlContent.Append("         jdm.JokasoTorokuNendo,                                              ");
            sqlContent.Append("         jdm.JokasoRenban,                                                   ");
            sqlContent.Append("         jdm.JokasoGenChikuCd,                                               ");
            sqlContent.Append("         jdm.JokasoSetchishaNm,                                              ");
            sqlContent.Append("         jdm.JokasoSetchishaAdr,                                             ");
            sqlContent.Append("         jdm.JokasoShoriTaishoJinin,                                         ");
            sqlContent.Append("         jdm.JokasoShoriHosikiKbn,                                           ");
            sqlContent.Append("         jdm.JokasoSetchishaKbn,                                             ");
            sqlContent.Append("         jdm.JokasoSetchishaCd                                               ");

            //FROM
            sqlContent.Append("FROM JokasoDaichoMst jdm                                                     ");

            //JOIN
            sqlContent.Append("         LEFT OUTER JOIN ChikuMst cm ON cm.ChikuCd = jdm.JokasoGenChikuCd    ");

            //WHERE
            sqlContent.Append("         WHERE jdm.JokasoKbn = '1'                                           ");

            string subContent1 = " jdm.JokasoShoriTaishoJinin <= 50 AND jdm.JokasoGaikanTikuwariKbn = @jokasoGaikanTikuwariKbn ";
            string subContent2 = " jdm.JokasoShoriTaishoJinin >= 51 ";

            //50人以下
            if (sakuhyoKbn1 == "1")
            {
                sqlContent.Append(string.Format("AND {0}", subContent1));
                commandParams.Add("@jokasoGaikanTikuwariKbn", SqlDbType.NVarChar).Value = Boundary.Common.Common.GaikanKensaChikuHantei(kensaNendo);
            }

            //51人以上
            if (sakuhyoKbn1 == "2")
            {
                sqlContent.Append(string.Format("AND {0}", subContent2));
            }

            //すべて
            if (sakuhyoKbn1 == "3")
            {
                sqlContent.Append(string.Format(" AND (({0}) OR {1})", subContent1, subContent2));
                commandParams.Add("@jokasoGaikanTikuwariKbn", SqlDbType.NVarChar).Value = Boundary.Common.Common.GaikanKensaChikuHantei(kensaNendo);
            }

            sqlContent.Append(" ORDER BY jdm.JokasoHokenjoCd,   ");
            sqlContent.Append("          jdm.JokasoTorokuNendo, ");
            sqlContent.Append("          jdm.JokasoRenban       ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region JokasoDaichoSyukeiListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoDaichoSyukeiListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　DatNT　　 新規作成
    /// 2014/10/24　HuyTX　　 Ver1.02
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class JokasoDaichoSyukeiListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shutsuryokuChohyo"></param>
        /// <param name="hokenjoCd"></param>
        /// <param name="uketsukeUse"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <param name="kensaUse"></param>
        /// <param name="kensaDtFrom"></param>
        /// <param name="kensaDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable GetDataBySearchCond(
            string shutsuryokuChohyo,
            string hokenjoCd,
            bool uketsukeUse,
            string uketsukeDtFrom,
            string uketsukeDtTo,
            bool kensaUse,
            string kensaDtFrom,
            string kensaDtTo)
        {
            SqlCommand command = CreateSqlCommand(shutsuryokuChohyo,
                                                    hokenjoCd,
                                                    uketsukeUse,
                                                    uketsukeDtFrom,
                                                    uketsukeDtTo,
                                                    kensaUse,
                                                    kensaDtFrom,
                                                    kensaDtTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable dataTable = new JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable();
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
        /// <param name="shutsuryokuChohyo"></param>
        /// <param name="hokenjoCd"></param>
        /// <param name="uketsukeUse"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <param name="kensaUse"></param>
        /// <param name="kensaDtFrom"></param>
        /// <param name="kensaDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　DatNT　　新規作成
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string shutsuryokuChohyo,
            string hokenjoCd,
            bool uketsukeUse,
            string uketsukeDtFrom,
            string uketsukeDtTo,
            bool kensaUse,
            string kensaDtFrom,
            string kensaDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;
            StringBuilder sqlContent = new StringBuilder();
            StringBuilder subShokenQuery = new StringBuilder();
            StringBuilder subGenbaShashinQuery = new StringBuilder();
            string sqlWhere = string.Empty;
            string sqlOrder = string.Empty;

            #region sub query select ShokenMst

            //20141225 HuyTX Mod Start
            //select shoken
            //subShokenQuery.Append(" (SELECT ");
            //subShokenQuery.Append(" 		ROW_NUMBER() OVER (ORDER BY ShokenMst.ShokenHokokuLevel, ShokenMst.ShokenKbn, ShokenMst.ShokenCd) as RowNum, ");
            //subShokenQuery.Append(" 		ShokenMst.ShokenHokokuLevel, ");
            //subShokenQuery.Append(" 		ShokenMst.ShokenKbn, ");
            //subShokenQuery.Append(" 		ShokenMst.ShokenCd, ");
            //subShokenQuery.Append(" 		ShokenMst.ShokenWdRyaku, ");
            //subShokenQuery.Append(" 		ShokenKekkaTbl.KensaIraiShokanIraiHoteiKbn, ");
            //subShokenQuery.Append(" 		ShokenKekkaTbl.KensaIraiShokenIraiHokenjoCd, ");
            //subShokenQuery.Append(" 		ShokenKekkaTbl.KensaIraiShokenIraiNendo, ");
            //subShokenQuery.Append(" 		ShokenKekkaTbl.KensaIraiShokenIraiRenban, ");
            //subShokenQuery.Append(" 		ShokenKekkaTbl.KensaIraiShokenRenban ");
            //subShokenQuery.Append("FROM ShokenMst  ");
            //subShokenQuery.Append(" 		INNER JOIN ShokenKekkaTbl ON ShokenKekkaTbl.ShokenKbn = ShokenMst.ShokenKbn ");
            //subShokenQuery.Append(" 		AND ShokenKekkaTbl.ShokenCd = ShokenMst.ShokenCd) ");

            subShokenQuery.Append(" (SELECT   DISTINCT ");
            subShokenQuery.Append("           ShokenMst.ShokenHokokuLevel, ");
            subShokenQuery.Append("           ShokenMst.ShokenKbn, ");
            subShokenQuery.Append("           ShokenMst.ShokenCd, ");
            subShokenQuery.Append("           ShokenMst.ShokenWdRyaku, ");
            subShokenQuery.Append("           ShokenKekkaTbl.KensaIraiShokanIraiHoteiKbn, ");
            subShokenQuery.Append("           ShokenKekkaTbl.KensaIraiShokenIraiHokenjoCd, ");
            subShokenQuery.Append("           ShokenKekkaTbl.KensaIraiShokenIraiNendo, ");
            subShokenQuery.Append("           ShokenKekkaTbl.KensaIraiShokenIraiRenban ");
            subShokenQuery.Append(" FROM ShokenMst ");
            subShokenQuery.Append(" INNER JOIN ShokenKekkaTbl ON ShokenKekkaTbl.ShokenKbn = ShokenMst.ShokenKbn ");
            subShokenQuery.Append(" AND ShokenKekkaTbl.ShokenCd = ShokenMst.ShokenCd ");
            subShokenQuery.Append(" WHERE ShokenMst.ShokenJuyodo <= '2' AND ShokenMst.ShokenHantei = '2') ");
            //20141225 HuyTX Mod End

            #endregion

            #region sub query select GenbaShashinTbl

            //20141225 HuyTX Mod Start
            //select GenbaShashin
            //subGenbaShashinQuery.Append(" (SELECT  ");
            //subGenbaShashinQuery.Append(" 		ROW_NUMBER() OVER (ORDER BY GenbaShashinKensaHoteiKbn,  ");
            //subGenbaShashinQuery.Append(" 									GenbaShashinKensaHokenjoCd,  ");
            //subGenbaShashinQuery.Append(" 									GenbaShashinKensaNendo,  ");
            //subGenbaShashinQuery.Append(" 									GenbaShashinKensaRenban,  ");
            //subGenbaShashinQuery.Append(" 									GenbaShashinCd) AS RowNum, ");
            //subGenbaShashinQuery.Append(" 		GenbaShashinKensaHoteiKbn, ");
            //subGenbaShashinQuery.Append(" 		GenbaShashinKensaHokenjoCd, ");
            //subGenbaShashinQuery.Append(" 		GenbaShashinKensaNendo, ");
            //subGenbaShashinQuery.Append(" 		GenbaShashinKensaRenban, ");
            //subGenbaShashinQuery.Append(" 		GenbaShashinCd, ");
            //subGenbaShashinQuery.Append(" 		GenbaShashinFilePath ");
            //subGenbaShashinQuery.Append(" FROM GenbaShashinTbl) ");

            subGenbaShashinQuery.Append(" (SELECT  ");
            subGenbaShashinQuery.Append(" 	Tbl2.GenbaShashinKensaHoteiKbn, ");
            subGenbaShashinQuery.Append(" 	Tbl2.GenbaShashinKensaHokenjoCd, ");
            subGenbaShashinQuery.Append(" 	Tbl2.GenbaShashinKensaNendo, ");
            subGenbaShashinQuery.Append(" 	Tbl2.GenbaShashinKensaRenban, ");
            subGenbaShashinQuery.Append(" 	max(case when Tbl2.SyashinPath1Col is null then '' else Tbl2.SyashinPath1Col end) filePath1, ");
            subGenbaShashinQuery.Append(" 	max(case when Tbl2.SyashinPath2Col is null then '' else Tbl2.SyashinPath2Col end) filePath2, ");
            subGenbaShashinQuery.Append(" 	max(case when Tbl2.SyashinPath3Col is null then '' else Tbl2.SyashinPath3Col end) filePath3 ");
            subGenbaShashinQuery.Append(" FROM ");
            subGenbaShashinQuery.Append(" 	(SELECT ");
            subGenbaShashinQuery.Append(" 		Tbl1.GenbaShashinKensaHoteiKbn, ");
            subGenbaShashinQuery.Append(" 		Tbl1.GenbaShashinKensaHokenjoCd, ");
            subGenbaShashinQuery.Append(" 		Tbl1.GenbaShashinKensaNendo, ");
            subGenbaShashinQuery.Append(" 		Tbl1.GenbaShashinKensaRenban, ");
            subGenbaShashinQuery.Append(" 		CASE WHEN Tbl1.RowNum = '1' THEN Tbl1.GenbaShashinFilePath END AS SyashinPath1Col, ");
            subGenbaShashinQuery.Append(" 		CASE WHEN Tbl1.RowNum = '2' THEN Tbl1.GenbaShashinFilePath END AS SyashinPath2Col, ");
            subGenbaShashinQuery.Append(" 		CASE WHEN Tbl1.RowNum = '3' THEN Tbl1.GenbaShashinFilePath END AS SyashinPath3Col ");
            subGenbaShashinQuery.Append(" 		FROM  ");
            subGenbaShashinQuery.Append(" 		(SELECT ROW_NUMBER() OVER (PARTITION BY GenbaShashinKensaHoteiKbn,  ");
            subGenbaShashinQuery.Append(" 													GenbaShashinKensaHokenjoCd,  ");
            subGenbaShashinQuery.Append(" 													GenbaShashinKensaNendo,  ");
            subGenbaShashinQuery.Append(" 													GenbaShashinKensaRenban ");
            subGenbaShashinQuery.Append(" 						ORDER BY GenbaShashinKensaHoteiKbn,  ");
            subGenbaShashinQuery.Append(" 						GenbaShashinKensaHokenjoCd,  ");
            subGenbaShashinQuery.Append(" 						GenbaShashinKensaNendo,  ");
            subGenbaShashinQuery.Append(" 						GenbaShashinKensaRenban,  ");
            subGenbaShashinQuery.Append(" 						GenbaShashinCd) AS RowNum, ");
            subGenbaShashinQuery.Append(" 					  GenbaShashinKensaHoteiKbn, ");
            subGenbaShashinQuery.Append(" 					  GenbaShashinKensaHokenjoCd, ");
            subGenbaShashinQuery.Append(" 					  GenbaShashinKensaNendo, ");
            subGenbaShashinQuery.Append(" 					  GenbaShashinKensaRenban, ");
            subGenbaShashinQuery.Append(" 					  GenbaShashinCd, ");
            subGenbaShashinQuery.Append(" 					  GenbaShashinFilePath ");
            subGenbaShashinQuery.Append(" 			   FROM GenbaShashinTbl) Tbl1) AS Tbl2 ");
            subGenbaShashinQuery.Append(" GROUP BY Tbl2.GenbaShashinKensaHoteiKbn, ");
            subGenbaShashinQuery.Append(" 			Tbl2.GenbaShashinKensaHokenjoCd, ");
            subGenbaShashinQuery.Append(" 			Tbl2.GenbaShashinKensaNendo, ");
            subGenbaShashinQuery.Append(" 			Tbl2.GenbaShashinKensaRenban) ");
            //20141225 HuyTX Mod End

            #endregion

            #region select JokasoDaichoMst, KensaIraiTbl

            #region SELECT

            sqlContent.Append(" SELECT ");

            sqlContent.Append(" 		jdm.JokasoHokenjoCd, ");
            sqlContent.Append(" 		jdm.JokasoTorokuNendo, ");
            sqlContent.Append(" 		jdm.JokasoRenban, ");
            sqlContent.Append(" 		kit.KensaIraiHoteiKbn, ");
            sqlContent.Append(" 	    kit.KensaIraiHokenjoCd, ");
            sqlContent.Append(" 	    kit.KensaIraiNendo, ");
            sqlContent.Append(" 	    kit.KensaIraiRenban, ");
            sqlContent.Append(" 		hm.HokenjoNm, ");
            sqlContent.Append(" 		jdm.JokasoGenChikuCd, ");
            sqlContent.Append(" 		cm.ChikuNm, ");
            sqlContent.Append(" 		jdm.JokasoHokenjoJuriNoNendo, ");
            sqlContent.Append(" 		jdm.JokasoHokenjoJuriNoSichosonCd, ");
            sqlContent.Append(" 		jdm.JokasoHokenjoJuriNoRenban, ");
            //sqlContent.Append(" 		CASE ");
            //sqlContent.Append(" 			WHEN ISNULL(jdm.JokasoHokenjoJuriNoNendo, '') <> '' THEN CONCAT(CAST(jdm.JokasoHokenjoJuriNoNendo AS INT) - ");
            //sqlContent.Append(" 																							(SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 ");
            //sqlContent.Append(" 																							FROM WarekiMst ");
            //sqlContent.Append(" 																							WHERE KaishiDt <= CONCAT(jdm.JokasoHokenjoJuriNoNendo, '01', '01') ");
            //sqlContent.Append(" 																							ORDER BY KaishiDt DESC), '-', jdm.JokasoHokenjoJuriNoSichosonCd, '-', jdm.JokasoHokenjoJuriNoRenban) ");
            //sqlContent.Append(" 			ELSE '' ");
            //sqlContent.Append(" 		END AS UketsukeNoCol, ");
            //sqlContent.Append(" 		CASE ");
            //sqlContent.Append(" 			WHEN ISNULL(jdm.JokasoHokenjoJuriNoNendo, '') <> '' THEN CONCAT(dbo.FuncConvertToWareki(jdm.JokasoHokenjoJuriNoNendo, 'yy', 1), '-', jdm.JokasoHokenjoJuriNoSichosonCd, '-', jdm.JokasoHokenjoJuriNoRenban) ");
            //sqlContent.Append(" 			ELSE '' ");
            //sqlContent.Append(" 		END AS UketsukeNoCol, ");
            sqlContent.Append(" 		CASE ");
            sqlContent.Append(" 			WHEN ISNULL(jdm.JokasoHokenjoJuriNoNendo, '') <> '' THEN CONCAT([dbo].[FuncConvertIraiNedoToWareki](jdm.JokasoHokenjoJuriNoNendo), '-', jdm.JokasoHokenjoJuriNoSichosonCd, '-', jdm.JokasoHokenjoJuriNoRenban) ");
            sqlContent.Append(" 			ELSE '' ");
            sqlContent.Append(" 		END AS UketsukeNoCol, ");
            sqlContent.Append(" 		jdm.JokasoJuriBi, ");
            sqlContent.Append(" 		CASE  ");
            sqlContent.Append(" 			WHEN ISDATE(jdm.JokasoJuriBi) = 0 THEN ''  ");
            sqlContent.Append(" 			ELSE CONVERT(CHAR(10), CONVERT(DATETIME, jdm.JokasoJuriBi), 111) ");
            sqlContent.Append(" 		END AS JuriDtCol, ");
            //sqlContent.Append("         CONCAT(jdm.JokasoHokenjoCd, '-', CAST(jdm.JokasoTorokuNendo AS INT) - ");
            //sqlContent.Append("                 (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 ");
            //sqlContent.Append("                  FROM WarekiMst ");
            //sqlContent.Append("                  WHERE KaishiDt <= CONCAT(jdm.JokasoTorokuNendo, '01', '01') ");
            //sqlContent.Append("                  ORDER BY KaishiDt DESC), '-', jdm.JokasoRenban)  ");
            //sqlContent.Append(" 		AS jokasoNoCol, ");
            //sqlContent.Append("         CONCAT(jdm.JokasoHokenjoCd, '-', [dbo].[FuncConvertToWareki](jdm.JokasoTorokuNendo, 'yy', 1), '-', jdm.JokasoRenban)  ");
            //sqlContent.Append(" 		AS jokasoNoCol, ");
            sqlContent.Append("         CONCAT(jdm.JokasoHokenjoCd, '-', [dbo].[FuncConvertIraiNedoToWareki](jdm.JokasoTorokuNendo), '-', jdm.JokasoRenban)  ");
            sqlContent.Append(" 		AS jokasoNoCol, ");

            //4, 6 = ON
            if (shutsuryokuChohyo == "2" || shutsuryokuChohyo == "4")
            {
                //sqlContent.Append(" 		jdm.JokasoSaishuKensaBi AS KensaDtCol, ");
                sqlContent.Append(" 		CASE  ");
                sqlContent.Append(" 			WHEN ISDATE(jdm.JokasoSaishuKensaBi) = 0 THEN ''  ");
                sqlContent.Append(" 			ELSE CONVERT(CHAR(10), CONVERT(DATETIME, jdm.JokasoSaishuKensaBi), 111) ");
                sqlContent.Append(" 		END AS KensaDtCol, ");
            }
            else
            {
                // 3, 5 = ON 
                sqlContent.Append(" 		CASE ");
                sqlContent.Append("            WHEN ISNULL(kit.KensaIraiKensaNen, '') <> '' ");
                sqlContent.Append("                 AND ISNULL(kit.KensaIraiKensaTsuki, '') <> '' ");
                sqlContent.Append("                 AND ISNULL(kit.KensaIraiKensaBi, '') <> '' THEN CONCAT(kit.KensaIraiKensaNen, '/', kit.KensaIraiKensaTsuki, '/', kit.KensaIraiKensaBi) ");
                sqlContent.Append("            ELSE '' ");
                sqlContent.Append(" 		END AS KensaDtCol, ");
            }

            sqlContent.Append(" 		const1.ConstNm AS KensaKbnCol, ");

            if (shutsuryokuChohyo == "2" || shutsuryokuChohyo == "3" || shutsuryokuChohyo == "4")
            {
                //4, 5,6 = ON
                sqlContent.Append(" 		jdm.JokasoSetchishaNm AS KanrisyaNmCol, ");
                sqlContent.Append(" 		jdm.JokasoSetchiBashoAdr AS AdrCol, ");
                //20141226 Mod
                //sqlContent.Append(" 		jdm.JokasoSetchiBashoTelNo AS TelCol, ");
                sqlContent.Append(" 		jdm.JokasoSetchishaTelNo AS TelCol, ");
                //End
                sqlContent.Append(" 		const2.ConstNm AS ShoriHosikiCol, ");
                sqlContent.Append(" 		jdm.JokasoShoriTaishoJinin AS NinsoCol, ");

                sqlContent.Append(" 		0 AS HoryuBodCol, ");
                sqlContent.Append(" 		'' AS ShitekiCol, ");
                sqlContent.Append(" 		'' AS SyashinPath1Col, ");
                sqlContent.Append(" 		'' AS SyashinPath2Col, ");
                sqlContent.Append(" 		'' AS SyashinPath3Col, ");
                sqlContent.Append(" 		'' AS SyashinUmuCol, ");

            }
            else
            {
                //3 = ON
                sqlContent.Append(" 		kit.KensaIraiSetchishaNm AS KanrisyaNmCol, ");
                sqlContent.Append(" 		kit.KensaIraiSetchibashoAdr AS AdrCol, ");
                //20141226 Mod
                //sqlContent.Append(" 		kit.KensaIraiSetchibashoTelNo AS TelCol, ");
                sqlContent.Append(" 		kit.KensaIraiSetchishaTelNo AS TelCol, ");
                //End
                sqlContent.Append(" 		const3.ConstNm AS ShoriHosikiCol, ");
                sqlContent.Append(" 		kit.KensaIraiShoritaishoJinin AS NinsoCol, ");

                sqlContent.Append(" 		kkt.KensaKekkaBOD AS HoryuBodCol, ");
                sqlContent.Append(" 		STUFF((SELECT TOP (2) '、' + skm.ShokenWdRyaku ");
                sqlContent.Append(" 		FROM  ");
                sqlContent.Append(          subShokenQuery);
                sqlContent.Append("         skm ");
                sqlContent.Append(" 		WHERE skm.KensaIraiShokanIraiHoteiKbn = kit.KensaIraiHoteiKbn ");
                sqlContent.Append(" 				AND skm.KensaIraiShokenIraiHokenjoCd = kit.KensaIraiHokenjoCd ");
                sqlContent.Append(" 				AND skm.KensaIraiShokenIraiNendo = kit.KensaIraiNendo ");
                sqlContent.Append(" 				AND skm.KensaIraiShokenIraiRenban = kit.KensaIraiRenban ");
                sqlContent.Append(" 				ORDER BY skm.ShokenHokokuLevel, skm.ShokenKbn, skm.ShokenCd ");
                sqlContent.Append(" 		FOR XML PATH('')), 1, 1, '') AS ShitekiCol, ");
                sqlContent.Append(" 		gst.filePath1 AS SyashinPath1Col, ");
                sqlContent.Append(" 		gst.filePath2 AS SyashinPath2Col, ");
                sqlContent.Append(" 		gst.filePath3 AS SyashinPath3Col, ");
                sqlContent.Append(" 		CASE  ");
                sqlContent.Append(" 			WHEN ISNULL(gst.filePath1, '') = '' THEN '無' ");
                sqlContent.Append(" 			ELSE '有' ");
                sqlContent.Append(" 		END AS SyashinUmuCol, ");
            }

            sqlContent.Append(" 		gm.GyoshaNm AS HosyuTenkenGyosyaCol, ");

            sqlContent.Append(" 		jdm.Jokaso11JokensaBi, ");
            sqlContent.Append(" 		jdm.JokasoSetchishaTelNo, ");
            sqlContent.Append(" 		kit.KensaIraiSetchishaTelNo, ");
            sqlContent.Append(" 		jdm.JokasoSaishuKensaBi ");

            #endregion

            #region FROM

            sqlContent.Append(" FROM JokasoDaichoMst jdm ");

            #endregion

            #region JOIN

            sqlContent.Append(" LEFT OUTER JOIN KensaIraiTbl kit ON kit.KensaIraiJokasoHokenjoCd = jdm.JokasoHokenjoCd ");
            sqlContent.Append(" 									AND kit.KensaIraiJokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            sqlContent.Append(" 									AND kit.KensaIraiJokasoRenban = jdm.JokasoRenban ");

            sqlContent.Append(" LEFT OUTER JOIN HokenjoMst hm ON ");

            //(3)
            if (shutsuryokuChohyo == "1")
            {
                sqlContent.Append(" hm.HokenjoCd = kit.KensaIraiHokenjoCd ");
            }
            else
            {
                //(4), (5), (6) = ON
                sqlContent.Append(" hm.HokenjoCd = jdm.JokasoHokenjoCd ");
            }

            sqlContent.Append(" LEFT OUTER JOIN ChikuMst cm ON cm.ChikuCd = jdm.JokasoGenChikuCd ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const1 ON const1.ConstValue = kit.KensaIraiHoteiKbn ");
            sqlContent.Append(" 								AND const1.ConstKbn = '006' ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const2 ON const2.ConstValue = jdm.JokasoShoriHosikiKbn ");
            sqlContent.Append(" 								AND const2.ConstKbn = '022' ");

            sqlContent.Append(" LEFT OUTER JOIN ConstMst const3 ON const3.ConstValue = kit.KensaIraiShorihoshikiKbn ");
            sqlContent.Append(" 								AND const3.ConstKbn = '022' ");

            //(3) = ON
            if (shutsuryokuChohyo == "1")
            {
                sqlContent.Append(" LEFT OUTER JOIN KensaKekkaTbl kkt ON kkt.KensaKekkaIraiHoteiKbn = kit.KensaIraiHoteiKbn ");
                sqlContent.Append(" 									AND kkt.KensaKekkaIraiHokenjoCd = kit.KensaIraiHokenjoCd ");
                sqlContent.Append(" 									AND kkt.KensaKekkaIraiNendo = kit.KensaIraiNendo ");
                sqlContent.Append(" 									AND kkt.KensaKekkaIraiRenban = kit.KensaIraiRenban ");

                //join with GenbaShashinTbl
                sqlContent.Append(" LEFT OUTER JOIN ");
                sqlContent.Append(subGenbaShashinQuery.ToString());
                sqlContent.Append(" gst ON gst.GenbaShashinKensaHoteiKbn = kit.KensaIraiHoteiKbn ");
                sqlContent.Append(" 			AND gst.GenbaShashinKensaHokenjoCd = kit.KensaIraiHokenjoCd ");
                sqlContent.Append(" 			AND gst.GenbaShashinKensaNendo = kit.KensaIraiNendo ");
                sqlContent.Append(" 			AND gst.GenbaShashinKensaRenban = kit.KensaIraiRenban ");
            }

            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst gm ON ");
            //4 = ON
            if (shutsuryokuChohyo == "2")
            {
                sqlContent.Append(" gm.GyoshaCd = jdm.JokasoHoshuyoteiGyoshaCd ");
            }
            else if (shutsuryokuChohyo == "3" || shutsuryokuChohyo == "4")
            {
                //5, 6 = ON 
                sqlContent.Append(" gm.GyoshaCd = jdm.JokasoHoshutenkenGyoshaCd ");
            }
            else
            {
                //3 = ON
                sqlContent.Append(" gm.GyoshaCd = kit.KensaIraiHoshutenkenGyoshaCd ");
            }

            #endregion

            #region WHERE

            sqlContent.Append(" WHERE 1 = 1 ");

            //search by UketsukeDt
            if (uketsukeUse)
            {
                //sqlWhere += " AND jdm.JokasoJuriBi " + DataAccessUtility.SetBetweenCommand(uketsukeDtFrom, uketsukeDtTo, 8);

                sqlWhere += " AND jdm.JokasoJuriBi >= @uketsukeDtFrom ";
                commandParams.Add("@uketsukeDtFrom", SqlDbType.NVarChar).Value = uketsukeDtFrom;

                sqlWhere += " AND jdm.JokasoJuriBi <= @uketsukeDtTo ";
                commandParams.Add("@uketsukeDtTo", SqlDbType.NVarChar).Value = uketsukeDtTo;
            }

            switch (shutsuryokuChohyo)
            {
                case "1":
                    #region (3) = ON

                    //search by HokenjoCd
                    if (!string.IsNullOrEmpty(hokenjoCd))
                    {
                        sqlWhere += " AND kit.KensaIraiHokenjoCd = @hokenjoCd ";
                    }

                    //search by KensaDt
                    if (kensaUse)
                    {
                        //sqlWhere += " AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) " + DataAccessUtility.SetBetweenCommand(kensaDtFrom, kensaDtTo, 8);

                        sqlWhere += " AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) >= @kensaDtFrom ";
                        commandParams.Add("@kensaDtFrom", SqlDbType.NVarChar).Value = kensaDtFrom;

                        sqlWhere += " AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) <= @kensaDtTo ";
                        commandParams.Add("@kensaDtTo", SqlDbType.NVarChar).Value = kensaDtTo;
                    }

                    sqlWhere += " AND kkt.KensaKekkaHantei = '3' ";
                    sqlOrder += " kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi";
                    break;

                    #endregion

                case "2":
                    #region (4) = ON

                    //search by HokenjoCd
                    if (!string.IsNullOrEmpty(hokenjoCd))
                    {
                        sqlWhere += " AND jdm.JokasoHokenjoCd = @hokenjoCd ";
                    }

                    sqlWhere += " AND ISNULL(jdm.JokasoHoshutenkenGyoshaCd, '') = '' ";

                    //NOT EXISTS
                    sqlWhere += "   AND NOT EXISTS (SELECT * FROM KensaIraiTbl ";
                    sqlWhere += " 				    WHERE jdm.JokasoHokenjoCd = KensaIraiTbl.KensaIraiJokasoHokenjoCd ";
                    sqlWhere += " 						AND jdm.JokasoTorokuNendo = KensaIraiTbl.KensaIraiJokasoTorokuNendo ";
                    sqlWhere += " 						AND jdm.JokasoRenban = KensaIraiTbl.KensaIraiJokasoRenban ";
                    sqlWhere += " 						AND KensaIraiTbl.KensaIraiHoteiKbn >= '2' ";
                    sqlWhere += " 				 ) ";

                    sqlOrder += " jdm.JokasoHokenjoCd, jdm.JokasoHokenjoJuriNoNendo, jdm.JokasoHokenjoJuriNoSichosonCd, jdm.JokasoHokenjoJuriNoRenban";

                    break;

                    #endregion

                case "3":
                    #region (5) = ON

                    //search by HokenjoCd
                    if (!string.IsNullOrEmpty(hokenjoCd))
                    {
                        sqlWhere += " AND jdm.JokasoHokenjoCd = @hokenjoCd ";
                    }

                    //search by KensaDt
                    if (kensaUse)
                    {
                        //sqlWhere += " AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) " + DataAccessUtility.SetBetweenCommand(kensaDtFrom, kensaDtTo, 8);

                        sqlWhere += " AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) >= @kensaDtFrom ";
                        commandParams.Add("@kensaDtFrom", SqlDbType.NVarChar).Value = kensaDtFrom;

                        sqlWhere += " AND CONCAT(kit.KensaIraiKensaNen, kit.KensaIraiKensaTsuki, kit.KensaIraiKensaBi) <= @kensaDtTo ";
                        commandParams.Add("@kensaDtTo", SqlDbType.NVarChar).Value = kensaDtTo;
                    }

                    sqlWhere += " AND kit.KensaIraiHoteiKbn = '1' ";
                    //NOT EXISTS
                    sqlWhere += "   AND NOT EXISTS (SELECT * FROM KensaIraiTbl ";
                    sqlWhere += " 				    WHERE jdm.JokasoHokenjoCd = KensaIraiTbl.KensaIraiJokasoHokenjoCd ";
                    sqlWhere += " 						AND jdm.JokasoTorokuNendo = KensaIraiTbl.KensaIraiJokasoTorokuNendo ";
                    sqlWhere += " 						AND jdm.JokasoRenban = KensaIraiTbl.KensaIraiJokasoRenban ";
                    sqlWhere += " 						AND KensaIraiTbl.KensaIraiHoteiKbn >= '2' ";
                    sqlWhere += " 				 ) ";

                    sqlOrder += " jdm.JokasoHokenjoCd, jdm.JokasoHokenjoJuriNoNendo, jdm.JokasoHokenjoJuriNoSichosonCd, jdm.JokasoHokenjoJuriNoRenban";
                    break;

                    #endregion

                case "4":
                    #region (6) = ON
                    //search by HokenjoCd
                    if (!string.IsNullOrEmpty(hokenjoCd))
                    {
                        //20141227 HuyTX Mod Start
                        //sqlWhere += " AND kit.KensaIraiHokenjoCd = @hokenjoCd ";
                        sqlWhere += " AND jdm.JokasoHokenjoCd = @hokenjoCd ";
                        //End
                    }

                    //20141227 HuyTX Add Start
                    sqlWhere += "   AND EXISTS (SELECT * FROM KensaIraiTbl  ";
                    sqlWhere += " 			  WHERE kit.KensaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn ";
                    sqlWhere += " 					AND kit.KensaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd  ";
                    sqlWhere += " 					AND kit.KensaIraiNendo = KensaIraiTbl.KensaIraiNendo ";
                    sqlWhere += " 					AND kit.KensaIraiRenban = KensaIraiTbl.KensaIraiRenban ";
                    sqlWhere += " 					AND KensaIraiTbl.KensaIraiHoteiKbn >= '2' ";
                    if (kensaUse)
                    {
                        sqlWhere += " AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) >= @kensaDtFrom ";
                        commandParams.Add("@kensaDtFrom", SqlDbType.NVarChar).Value = kensaDtFrom;

                        sqlWhere += " AND CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki, KensaIraiTbl.KensaIraiKensaBi) <= @kensaDtTo ";
                        commandParams.Add("@kensaDtTo", SqlDbType.NVarChar).Value = kensaDtTo;
                    }
                    sqlWhere += " 					AND KensaIraiTbl.KensaIraiStatusKbn < '20' ";
                    sqlWhere += " 			) ";
                    //End

                    sqlOrder += " jdm.JokasoHokenjoCd, jdm.JokasoHokenjoJuriNoNendo, jdm.JokasoHokenjoJuriNoSichosonCd, jdm.JokasoHokenjoJuriNoRenban";
                    break;

                    #endregion

                default:
                    break;
            }

            sqlContent.Append(sqlWhere);

            #endregion

            #region ORDER

            sqlContent.Append(" ORDER BY " + sqlOrder);

            #endregion

            #endregion

            if (!string.IsNullOrEmpty(hokenjoCd))
            {
                commandParams.Add("@hokenjoCd", SqlDbType.NVarChar).Value = hokenjoCd;
            }
            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region DataInsertZenkaiKensaDataWrkTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DataInsertZenkaiKensaDataWrkTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class DataInsertZenkaiKensaDataWrkTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="chikuCdFrom"></param>
        /// <param name="chikuCdTo"></param>
        /// <param name="sakuhyoKbn11"></param>
        /// <param name="sakuhyoKbn12"></param>
        /// <param name="sakuhyoKbn13"></param>
        /// <param name="sakuhyoKbn31"></param>
        /// <param name="sakuhyoKbn32"></param>
        /// <param name="sakuhyoKbn33"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal JokasoDaichoMstDataSet.DataInsertZenkaiKensaDataWrkDataTable GetDataBySearchCond(
            string nendo,
            string chikuCdFrom,
            string chikuCdTo,
            bool sakuhyoKbn11,
            bool sakuhyoKbn12,
            bool sakuhyoKbn13,
            bool sakuhyoKbn31,
            bool sakuhyoKbn32,
            bool sakuhyoKbn33)
        {
            SqlCommand command = CreateSqlCommand(  nendo,
                                                    chikuCdFrom,
                                                    chikuCdTo,
                                                    sakuhyoKbn11,
                                                    sakuhyoKbn12,
                                                    sakuhyoKbn13,
                                                    sakuhyoKbn31,
                                                    sakuhyoKbn32,
                                                    sakuhyoKbn33);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            JokasoDaichoMstDataSet.DataInsertZenkaiKensaDataWrkDataTable dataTable = new JokasoDaichoMstDataSet.DataInsertZenkaiKensaDataWrkDataTable();
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
        /// <param name="nendo"></param>
        /// <param name="chikuCdFrom"></param>
        /// <param name="chikuCdTo"></param>
        /// <param name="sakuhyoKbn11"></param>
        /// <param name="sakuhyoKbn12"></param>
        /// <param name="sakuhyoKbn13"></param>
        /// <param name="sakuhyoKbn31"></param>
        /// <param name="sakuhyoKbn32"></param>
        /// <param name="sakuhyoKbn33"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　DatNT　　新規作成
        /// 2014/12/01  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string nendo,
            string chikuCdFrom,
            string chikuCdTo,
            bool sakuhyoKbn11,
            bool sakuhyoKbn12,
            bool sakuhyoKbn13,
            bool sakuhyoKbn31,
            bool sakuhyoKbn32,
            bool sakuhyoKbn33)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT                                                                                          ");
            sqlContent.Append("         JokasoDaichoMst.JokasoHokenjoCd,                                                        ");
            sqlContent.Append("         JokasoDaichoMst.JokasoTorokuNendo,                                                      ");
            sqlContent.Append("         JokasoDaichoMst.JokasoRenban,                                                           ");
            sqlContent.Append("         JokasoDaichoMst.JokasoShoriTaishoJinin,                                                 ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchishaNm,                                                      ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchiBashoAdr,                                                   ");
            sqlContent.Append("         JokasoDaichoMst.JokasoShoriTaishoJinin,                                                 ");
            sqlContent.Append("         JokasoDaichoMst.JokasoShoriHosikiKbn,                                                   ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchishaKbn,                                                     ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchishaCd,                                                      ");
            sqlContent.Append("         JokasoDaichoMst.JokasoGenChikuCd,                                                       ");
            sqlContent.Append("         JokasoDaichoMst.JokasoKbn,                                                              ");
            sqlContent.Append("         JokasoDaichoMst.JokasoGenChikuCd,                                                       ");
            sqlContent.Append("         JokasoDaichoMst.JokasoGaikanTikuwariKbn,                                                ");

            sqlContent.Append("         JinendoGaikanYoteiOutputTbl.Nendo,                                                      ");
            sqlContent.Append("         JinendoGaikanYoteiOutputTbl.IraiMakeKbn,                                                ");

            sqlContent.Append("         ChikuMst.ChikuNm                                                                        ");

            //FROM
            sqlContent.Append(" FROM                                                                                            ");
            sqlContent.Append("         JokasoDaichoMst                                                                         ");
            sqlContent.Append(" INNER JOIN JinendoGaikanYoteiOutputTbl                                                          ");
            sqlContent.Append("         ON JinendoGaikanYoteiOutputTbl.JokasoHokenjoCd = JokasoDaichoMst.JokasoHokenjoCd        ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoTorokuNendo = JokasoDaichoMst.JokasoTorokuNendo   ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoRenban = JokasoDaichoMst.JokasoRenban             ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.Nendo = @nendo                                          ");

            commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
            
            sqlContent.Append(" LEFT OUTER JOIN ChikuMst                                                                        ");
            sqlContent.Append("         ON ChikuMst.ChikuCd = JokasoDaichoMst.JokasoGenChikuCd                                  ");

            // WHERE
            sqlContent.Append(" WHERE                                                                                           ");
            sqlContent.Append("         1 = 1                                                                                   ");

            // 2014/12/01 DatNT v1.03 MOD Start
            //// 浄化槽台帳区分
            //sqlContent.Append(" AND JokasoDaichoMst.JokasoKbn = '1'                                                             ");

            // 浄化槽状態区分
            sqlContent.Append(" AND JokasoDaichoMst.JokasoJotaiKbn <> '2'                                                       ");
            // 2014/12/01 DatNT v1.03 MOD End

            // ・地区コードが入力されている場合
            if (!string.IsNullOrEmpty(chikuCdFrom))
            {
                sqlContent.Append(" AND JokasoDaichoMst.JokasoGenChikuCd >= @chikuCdFrom                                        ");
                commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;
            }
            if (!string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append(" AND JokasoDaichoMst.JokasoGenChikuCd <= @chikuCdTo                                          ");
                commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            }

            // 外観検査地区
            string chiku = Boundary.Common.Common.GaikanKensaChikuHantei(nendo);

            // ・｛作表区分１/50人槽以下｝が選択されている場合
            if (sakuhyoKbn11)
            {
                // 処理対象人員
                sqlContent.Append(" AND JokasoDaichoMst.JokasoShoriTaishoJinin <= 50                                            ");

                // 外観地区割区分
                sqlContent.Append(" AND JokasoDaichoMst.JokasoGaikanTikuwariKbn = @chiku                                        ");
                commandParams.Add("@chiku", SqlDbType.NVarChar).Value = chiku;
            }

            // ・｛作表区分１/51人槽以上｝が選択されている場合
            if (sakuhyoKbn12)
            {
                // 処理対象人員
                sqlContent.Append(" AND JokasoDaichoMst.JokasoShoriTaishoJinin >= 51                                            ");
            }

            // ・｛作表区分１/すべて｝が選択されている場合
            if (sakuhyoKbn13)
            {
                sqlContent.Append(" AND (                                                                                       ");

                // 処理対象人員
                sqlContent.Append("         (JokasoDaichoMst.JokasoShoriTaishoJinin <= 50                                       ");

                // 外観地区割区分
                sqlContent.Append("         AND JokasoDaichoMst.JokasoGaikanTikuwariKbn = @chiku)                               ");
                commandParams.Add("@chiku", SqlDbType.NVarChar).Value = chiku;

                // 処理対象人員
                sqlContent.Append("     OR JokasoDaichoMst.JokasoShoriTaishoJinin >= 51                                         ");

                sqlContent.Append("     )                                                                                       ");
            }

            // ・｛差分出力/出力差分｝OR｛差分出力/入力差分｝が選択されている場合
            if (sakuhyoKbn31 || sakuhyoKbn32)
            {
                sqlContent.Append(" AND NOT EXISTS (                                                                            ");
                sqlContent.Append("             SELECT * FROM JinendoGaikanYoteiOutputTbl                                       ");
                sqlContent.Append("             WHERE   JokasoHokenjoCd = JokasoDaichoMst.JokasoHokenjoCd                       ");
                sqlContent.Append("                     AND JokasoTorokuNendo = JokasoDaichoMst.JokasoTorokuNendo               ");
                sqlContent.Append("                     AND JokasoRenban = JokasoDaichoMst.JokasoRenban                         ");
                sqlContent.Append("                     AND JokasoRenban = JokasoDaichoMst.JokasoRenban                         ");
                sqlContent.Append("                     AND Nendo = '" + nendo + "'                                             ");

                // ・｛差分出力/入力差分｝が選択されている場合
                if (sakuhyoKbn32)
                {
                    sqlContent.Append("                 AND IraiMakeKbn = '1'                                                   ");
                }
                sqlContent.Append("             )                                                                               ");
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaIraishoOutputListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraishoOutputListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaIraishoOutputListTableAdapter
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
        /// 2014/12/02　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable GetDataBySearchCond(KensaIraishoOutputSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable dataTable = new JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable();
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
        /// 2014/12/02　HuyTX　　新規作成
        /// 2014/12/11  DatNT   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaIraishoOutputSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.Append("SELECT TOP 2000 A.* FROM (");

            #region SELECT
            sqlContent.Append(" SELECT  '1' AS selectCol, ");
            sqlContent.Append(" 		jdm.JokasoHokenjoCd, ");
            sqlContent.Append(" 		jdm.JokasoTorokuNendo, ");
            sqlContent.Append(" 		jdm.JokasoRenban, ");
            sqlContent.Append(" 		CONCAT(jdm.JokasoHokenjoCd, '-',  ");
            sqlContent.Append(" 				[dbo].[FuncConvertIraiNedoToWareki](jdm.JokasoTorokuNendo), '-',  ");
            sqlContent.Append(" 				jdm.JokasoRenban) AS jokasoNoCol, ");
            sqlContent.Append(" 		jdm.JokasoSetchishaNm AS settisyaCol, ");
            sqlContent.Append(" 		jdm.JokasoSetchiBashoAdr AS settiBasyoCol, ");
            sqlContent.Append(" 		jdm.JokasoGenChikuCd, ");
            sqlContent.Append(" 		cm.ChikuNm AS chikuNmCol, ");
            sqlContent.Append(" 		jdm.JokasoGaikanTikuwariKbn AS gaikanChikuCol, ");
            sqlContent.Append(" 		'   ' AS kishakuBairitsuCol, ");
            sqlContent.Append(" 		dskkm.DaichoKensaSetNm AS keiryoShomeiNmCol, ");
            sqlContent.Append(" 		dskkm.DaichoKensaKomokuEdaban AS kensaKomokuEdabanCol, ");
            sqlContent.Append(" 		jdm.JokasoSuisitsuSishoCd, ");
            sqlContent.Append(" 		jdm.JokasoShoriTaishoJinin ");
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
            //sqlContent.Append(" 			AND dskkm.JokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            //sqlContent.Append(" 			AND dskkm.JokasoRenban = jdm.JokasoRenban            ");
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
            sqlContent.Append(" 			  AND dskkmmax.JokasoTorokuNendo = jdm.JokasoTorokuNendo ");
            sqlContent.Append(" 			  AND dskkmmax.JokasoRenban = jdm.JokasoRenban            ");
            sqlContent.Append("LEFT OUTER JOIN");
            sqlContent.Append(" (SELECT ");
            sqlContent.Append(" DaichoKensaKomokuEdaban, ");
            sqlContent.Append(" DaichoKensaSetNm, ");
            sqlContent.Append(" JokasoHokenjoCd, ");
            sqlContent.Append(" JokasoTorokuNendo, ");
            sqlContent.Append(" JokasoRenban ");
            sqlContent.Append(" FROM DaichoSuishitsuKensaKomokuMst ");
            sqlContent.Append("  ) AS dskkm ON dskkm.JokasoHokenjoCd = dskkmmax.JokasoHokenjoCd ");
            sqlContent.Append(" 			AND dskkm.JokasoTorokuNendo = dskkmmax.JokasoTorokuNendo ");
            sqlContent.Append(" 			AND dskkm.JokasoRenban = dskkmmax.JokasoRenban            ");
            sqlContent.Append(" 			AND dskkm.DaichoKensaKomokuEdaban = dskkmmax.DaichoKensaKomokuEdaban ");
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
            sqlContent.Append(" 		A.JokasoHokenjoCd, ");
            sqlContent.Append(" 		A.JokasoTorokuNendo, ");
            sqlContent.Append(" 		A.JokasoRenban ");

            command.CommandText = sqlContent.ToString();
            // TODO 水質検査依頼書で使用(遅すぎるので、見直し検討)
            return command;
        }
        #endregion
    }
    #endregion
}
