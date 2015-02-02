using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
        
    public partial class ZenkaiKensaDataWrkDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.ZenkaiKensaDataWrkDataSetTableAdapters
{

    #region ZenkaiKensaDataWrkTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ZenkaiKensaDataWrkTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03　DatNT 　 新規作成
    /// 2014/12/05　kiyokuni SQLの項目のミスや判定間違いを一括修正
    /// 2015/01/22　小松　　　　コマンドタイムアウト設定
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class ZenkaiKensaDataWrkTableAdapter
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

        #region JinendoGaikenStep2
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JinendoGaikenStep2
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
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容 
        /// 2014/12/03　DatNT 　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void JinendoGaikenStep2( string nendo,
                                        string chikuCdFrom,
                                        string chikuCdTo,
                                        bool sakuhyoKbn11,
                                        bool sakuhyoKbn12,
                                        bool sakuhyoKbn13,
                                        bool sakuhyoKbn31,
                                        bool sakuhyoKbn32,
                                        bool sakuhyoKbn33,
                                        DateTime now)
        {
            SqlCommand command = CreateSqlCommandJinendoGaikenStep2(nendo,
                                                                    chikuCdFrom,
                                                                    chikuCdTo,
                                                                    sakuhyoKbn11,
                                                                    sakuhyoKbn12,
                                                                    sakuhyoKbn13,
                                                                    sakuhyoKbn31,
                                                                    sakuhyoKbn32,
                                                                    sakuhyoKbn33,
                                                                    now);
            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            command.Connection = this.Connection;

            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandJinendoGaikenStep2
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommandJinendoGaikenStep2
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
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandJinendoGaikenStep2(
            string nendo,
            string chikuCdFrom,
            string chikuCdTo,
            bool sakuhyoKbn11,
            bool sakuhyoKbn12,
            bool sakuhyoKbn13,
            bool sakuhyoKbn31,
            bool sakuhyoKbn32,
            bool sakuhyoKbn33,
            DateTime now)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region INSERT INTO

            sqlContent.Append(" INSERT INTO ZenkaiKensaDataWrk (                                                                                         ");
            sqlContent.Append("     JokasoHokenjoCd,                                                                            ");
            sqlContent.Append("     JokasoTorokuNendo,                                                                          ");
            sqlContent.Append("     JokasoRenban,                                                                               ");
            sqlContent.Append("     KensaIraiHoteiKbn,                                                                          ");
            sqlContent.Append("     KensaIraiHokenjoCd,                                                                         ");
            sqlContent.Append("     KensaIraiNendo,                                                                             ");
            sqlContent.Append("     KensaIraiRenban,                                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiNendo,                                                                      ");
            sqlContent.Append("     KeiryoShomeiIraiShishoCd,                                                                   ");
            sqlContent.Append("     KeiryoShomeiIraiRenban,                                                                     ");
            sqlContent.Append("     GyoshaCd,                                                                                   ");
            sqlContent.Append("     GyoshaNm,                                                                                   ");
            sqlContent.Append("     NinsoKbn,                                                                                   ");
            sqlContent.Append("     KensaPeriod,                                                                                ");
            sqlContent.Append("     ShichosonNm,                                                                                ");
            sqlContent.Append("     SetchishaNm,                                                                                ");
            sqlContent.Append("     SetchishaAdr,                                                                               ");
            sqlContent.Append("     Ninso,                                                                                      ");
            sqlContent.Append("     ShoriHoshikiKbn,                                                                            ");
            sqlContent.Append("     ZenkaiKensaDt,                                                                              ");
            sqlContent.Append("     KensaKbn,                                                                                   ");
            sqlContent.Append("     SetchishaKbn,                                                                               ");
            sqlContent.Append("     SetchishaCd,                                                                                ");
            sqlContent.Append("     SetteiKbn,                                                                                  ");
            sqlContent.Append("     ShichosonCd,                                                                                ");
            sqlContent.Append("     RenkeiKbn,                                                                                  ");
            sqlContent.Append("     NyuryokuKbn,                                                                                ");
            sqlContent.Append("     InsertDt,                                                                                   ");
            sqlContent.Append("     InsertTarm,                                                                                 ");
            sqlContent.Append("     InsertUser,                                                                                 ");
            sqlContent.Append("     UpdateDt,                                                                                   ");
            sqlContent.Append("     UpdateTarm,                                                                                 ");
            sqlContent.Append("     UpdateUser                                                                                  ");
            sqlContent.Append("     )                                                                                           ");

            #endregion

            #region SELECT

            sqlContent.Append(" SELECT                                                                                          ");
            sqlContent.Append("         JokasoDaichoMst.JokasoHokenjoCd,                                                        ");
            sqlContent.Append("         JokasoDaichoMst.JokasoTorokuNendo,                                                      ");
            sqlContent.Append("         JokasoDaichoMst.JokasoRenban,                                                           ");
            sqlContent.Append("         '' AS KensaIraiHoteiKbn,                                                                ");
            sqlContent.Append("         '' AS KensaIraiHokenjoCd,                                                               ");
            sqlContent.Append("         '' AS KensaIraiNendo,                                                                   ");
            sqlContent.Append("         '' AS KensaIraiRenban,                                                                  ");
            sqlContent.Append("         '' AS KeiryoShomeiIraiNendo,                                                            ");
            sqlContent.Append("         '' AS KeiryoShomeiIraiShishoCd,                                                         ");
            sqlContent.Append("         '' AS KeiryoShomeiIraiRenban,                                                           ");
            sqlContent.Append("         '' AS GyoshaCd,                                                                         ");
            sqlContent.Append("         '' AS GyoshaNm,                                                                         ");
            sqlContent.Append("         CASE WHEN JokasoDaichoMst.JokasoShoriTaishoJinin <= 50 THEN '1'                         ");
            sqlContent.Append("              WHEN JokasoDaichoMst.JokasoShoriTaishoJinin >= 51 THEN '2' END AS NinsoKbn,        ");
            sqlContent.Append("         '' AS KensaPeriod,                                                                      ");
            sqlContent.Append("         ChikuMst.ChikuNm AS ShichosonNm,                                                        ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchishaNm AS SetchishaNm,                                       ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchiBashoAdr AS SetchishaAdr,                                   ");
            sqlContent.Append("         JokasoDaichoMst.JokasoShoriTaishoJinin AS Ninso,                                        ");
            sqlContent.Append("         JokasoDaichoMst.JokasoShoriHosikiKbn AS ShoriHoshikiKbn,                                ");
            sqlContent.Append("         '' AS ZenkaiKensaDt,                                                                    ");
            sqlContent.Append("         '' AS KensaKbn,                                                                         ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchishaKbn AS SetchishaKbn,                                     ");
            sqlContent.Append("         JokasoDaichoMst.JokasoSetchishaCd AS SetchishaCd,                                       ");
            sqlContent.Append("         '0' AS SetteiKbn,                                                                       ");
            sqlContent.Append("         JokasoDaichoMst.JokasoGenChikuCd AS ShichosonCd,                                        ");
            sqlContent.Append("         CASE WHEN ISNULL(JinendoGaikanYoteiOutputTbl.IraiMakeKbn, '') = '' THEN '0'             ");
            sqlContent.Append("              ELSE '1' END AS RenkeiKbn,                                                         ");
            sqlContent.Append("         CASE WHEN JinendoGaikanYoteiOutputTbl.IraiMakeKbn = '1' THEN '1'                        ");
            sqlContent.Append("              ELSE '0' END AS NyuryokuKbn,    ");//2014.12.05 kiyokuni mod
//            sqlContent.Append("              WHEN JinendoGaikanYoteiOutputTbl.IraiMakeKbn <> '1' THEN '0' END AS NyuryokuKbn,    ");
            sqlContent.Append("         @Now,                                                                                   ");
            sqlContent.Append("         @PcUpdate,                                                                              ");
            sqlContent.Append("         @LoginUser,                                                                             ");
            sqlContent.Append("         @Now,                                                                                   ");
            sqlContent.Append("         @PcUpdate,                                                                              ");
            sqlContent.Append("         @LoginUser                                                                              ");

            commandParams.Add("@Now", SqlDbType.DateTime).Value = now;
            commandParams.Add("@PcUpdate", SqlDbType.NVarChar).Value = Dns.GetHostName();
            commandParams.Add("@LoginUser", SqlDbType.NVarChar).Value = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            #endregion

            #region FROM

            sqlContent.Append(" FROM                                                                                            ");
            sqlContent.Append("         JokasoDaichoMst                                                                         ");
            sqlContent.Append(" LEFT JOIN JinendoGaikanYoteiOutputTbl                                                          ");
//            sqlContent.Append(" INNER JOIN JinendoGaikanYoteiOutputTbl                                                          ");
            sqlContent.Append("         ON JinendoGaikanYoteiOutputTbl.JokasoHokenjoCd = JokasoDaichoMst.JokasoHokenjoCd        ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoTorokuNendo = JokasoDaichoMst.JokasoTorokuNendo   ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoRenban = JokasoDaichoMst.JokasoRenban             ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.Nendo = @nendo                                          ");

            commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;

            sqlContent.Append(" LEFT OUTER JOIN ChikuMst                                                                        ");
            sqlContent.Append("         ON ChikuMst.ChikuCd = JokasoDaichoMst.JokasoGenChikuCd                                  ");

            #endregion

            #region WHERE

            sqlContent.Append(" WHERE                                                                                           ");
            sqlContent.Append("         1 = 1                                                                                   ");

            // 浄化槽状態区分
            sqlContent.Append(" AND JokasoDaichoMst.JokasoJotaiKbn <> '2'                                                       ");
            
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

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

        #region JinendoGaikenStep3
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JinendoGaikenStep3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容 
        /// 2014/12/03　DatNT 　 新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void JinendoGaikenStep3(string nendo)
        {
            SqlCommand command = CreateSqlCommandJinendoGaikenStep3(nendo);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            command.Connection = this.Connection;

            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandJinendoGaikenStep3
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommandJinendoGaikenStep3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　DatNT　　新規作成
        /// 2014/12/04　kiyokuni　日付の検索条件を修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandJinendoGaikenStep3(string nendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region UPDATE

            sqlContent.Append("UPDATE                                                                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("SET                                                                                                                          ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn,                                                  ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd,                                                ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiNendo = KensaIraiTbl.KensaIraiNendo,                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiRenban = KensaIraiTbl.KensaIraiRenban,                                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd = KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd,                                                ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaNm = GyoshaMst.GyoshaNm,                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaPeriod = '1',                                                                                   ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ZenkaiKensaDt = ( CASE WHEN ISNULL(CONCAT(KensaIraiTbl.KensaIraiKensaNen,                            ");
            sqlContent.Append("                                                                  KensaIraiTbl.KensaIraiKensaTsuki,                          ");
            sqlContent.Append("                                                                  KensaIraiTbl.KensaIraiKensaBi), '') <> ''                  ");
            sqlContent.Append("                                               THEN CONCAT(KensaIraiTbl.KensaIraiKensaNen,                                   ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaTsuki,                                 ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaBi)                                    ");
            sqlContent.Append("                                               ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen,                              ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaYoteiTsuki,                            ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaYoteiBi)                               ");
            sqlContent.Append("                                          END ),                                                                             ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaKbn = '1',                                                                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetteiKbn = '1'                                                                                      ");

            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     KensaIraiTbl                                                                                                            ");
            sqlContent.Append("         ON KensaIraiTbl.KensaIraiJokasoHokenjoCd = ZenkaiKensaDataWrk.JokasoHokenjoCd                                             ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiJokasoTorokuNendo = ZenkaiKensaDataWrk.JokasoTorokuNendo                                              ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiJokasoRenban = ZenkaiKensaDataWrk.JokasoRenban                                                  ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiHoteiKbn = '2'                                                                            ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     GyoshaMst                                                                                                               ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiIkkatsuSeikyusakiCd                                                   ");

            #endregion

            #region WHERE

            sqlContent.Append("WHERE                                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                                   ");

            //2014.12.04 mod kiyokuni --- start
            sqlContent.Append("AND CASE WHEN ISNULL(CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki),'') <> ''                        ");
            sqlContent.Append("         THEN CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki)                                        ");
            sqlContent.Append("         ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) END  >= CONCAT(CAST(@nendo AS INT) - 1, '04')  ");

            sqlContent.Append("AND CASE WHEN ISNULL(CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki),'') <> ''                        ");
            sqlContent.Append("         THEN CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki)                                        ");
            sqlContent.Append("         ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) END  <= CONCAT(CAST(@nendo AS INT), '03')  ");


            //sqlContent.Append("AND                                                                                                                          ");
            //sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) >=                                                  ");
            //sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) <> ''                           ");
            //sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT) - 1, '04')                                                                  ");
            //sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) END)                          ");

            //sqlContent.Append("AND                                                                                                                          ");
            //sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) <=                                                  ");
            //sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) <> ''                           ");
            //sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT), '03')                                                                      ");
            //sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) END)                          ");

            //sqlContent.Append("AND                                                                                                                          ");
            //sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) >=                                        ");
            //sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) = ''                            ");
            //sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT) - 1, '04')                                                                  ");
            //sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) END)                ");

            //sqlContent.Append("AND                                                                                                                          ");
            //sqlContent.Append("CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) <=                                        ");
            //sqlContent.Append("         (CASE WHEN ISNULL(KensaIraiTbl.KensaIraiKensaNen, KensaIraiTbl.KensaIraiKensaTsuki) = ''                            ");
            //sqlContent.Append("                 THEN CONCAT(CAST(@nendo AS INT), '03')                                                                      ");
            //sqlContent.Append("                 ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen, KensaIraiTbl.KensaIraiKensaYoteiTsuki) END)                ");
            //2014.12.04 mod kiyokuni --- end

            commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

        #region JinendoGaikenStep4
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JinendoGaikenStep4
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容 
        /// 2014/12/03　DatNT 　 新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void JinendoGaikenStep4(string nendo)
        {
            SqlCommand command = CreateSqlCommandJinendoGaikenStep4(nendo);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            command.Connection = this.Connection;

            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandJinendoGaikenStep4
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommandJinendoGaikenStep4
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandJinendoGaikenStep4(string nendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            string uketsukeDtFrom = (Convert.ToInt32(nendo) - 2) + "0401";
            string uketsukeDtTo = Convert.ToInt32(nendo) + "0331";

            #region UPDATE

            sqlContent.Append("UPDATE                                                                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("SET                                                                                                                          ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn,                                                  ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd,                                                ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiNendo = KensaIraiTbl.KensaIraiNendo,                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiRenban = KensaIraiTbl.KensaIraiRenban,                                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd = KensaIraiTbl.KensaIraiSeikyuGyoshaCd,                                                ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaNm = GyoshaMst.GyoshaNm,                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaPeriod = '1',                                                                                   ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ZenkaiKensaDt = KensaIraiTbl.KensaIraiSuishitsuUketsukeDt,                                           ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaKbn = '2',                                                                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetteiKbn = '1'                                                                                      ");
            
            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     KensaIraiTbl                                                                                                            ");
            sqlContent.Append("         ON KensaIraiTbl.KensaIraiJokasoHokenjoCd = ZenkaiKensaDataWrk.JokasoHokenjoCd                                             ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiJokasoTorokuNendo = ZenkaiKensaDataWrk.JokasoTorokuNendo                                              ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiJokasoRenban = ZenkaiKensaDataWrk.JokasoRenban                                                  ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     GyoshaMst                                                                                                               ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiSeikyuGyoshaCd                                                   ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     (   SELECT                                                                                                              ");
            sqlContent.Append("             KensaIraiJokasoHokenjoCd,                                                                                       ");
            sqlContent.Append("             KensaIraiJokasoTorokuNendo,                                                                                     ");
            sqlContent.Append("             KensaIraiJokasoRenban,                                                                                          ");
            sqlContent.Append("             MAX(KensaIraiSuishitsuUketsukeDt) AS UketsukeDt                                                                 ");
            sqlContent.Append("         FROM KensaIraiTbl                                                                                                   ");
            sqlContent.Append("         WHERE KensaIraiHoteiKbn = '3'                                                                                       ");
            sqlContent.Append("                 AND KensaIraiJokasoHokenjoCd = KensaIraiTbl.KensaIraiJokasoHokenjoCd                                              ");
            sqlContent.Append("                 AND KensaIraiJokasoTorokuNendo = KensaIraiTbl.KensaIraiJokasoTorokuNendo                                                ");
            sqlContent.Append("                 AND KensaIraiJokasoRenban = KensaIraiTbl.KensaIraiJokasoRenban                                                    ");
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

            sqlContent.Append("AND ZenkaiKensaDataWrk.SetteiKbn = '0'                                                                                       ");

            commandParams.Add("@uketsukeDtFrom", SqlDbType.NVarChar).Value = uketsukeDtFrom;
            commandParams.Add("@uketsukeDtTo", SqlDbType.NVarChar).Value = uketsukeDtTo;

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

        #region JinendoGaikenStep5
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JinendoGaikenStep5
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容 
        /// 2014/12/03　DatNT 　 新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void JinendoGaikenStep5()
        {
            SqlCommand command = CreateSqlCommandJinendoGaikenStep5();

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            command.Connection = this.Connection;

            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandJinendoGaikenStep5
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommandJinendoGaikenStep5
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandJinendoGaikenStep5()
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region UPDATE

            sqlContent.Append("UPDATE                                                                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("SET                                                                                                                          ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiHoteiKbn = KensaIraiTbl.KensaIraiHoteiKbn,                                                  ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiHokenjoCd = KensaIraiTbl.KensaIraiHokenjoCd,                                                ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiNendo = KensaIraiTbl.KensaIraiNendo,                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaIraiRenban = KensaIraiTbl.KensaIraiRenban,                                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd = KensaIraiTbl.KensaIraiHoshutenkenGyoshaCd,                                                ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaNm = GyoshaMst.GyoshaNm,                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaPeriod = '2',                                                                                   ");

            sqlContent.Append("     ZenkaiKensaDataWrk.ZenkaiKensaDt = ( CASE WHEN ISNULL(CONCAT(KensaIraiTbl.KensaIraiKensaNen,                            ");
            sqlContent.Append("                                                                  KensaIraiTbl.KensaIraiKensaTsuki,                          ");
            sqlContent.Append("                                                                  KensaIraiTbl.KensaIraiKensaBi), '') <> ''                  ");
            sqlContent.Append("                                               THEN CONCAT(KensaIraiTbl.KensaIraiKensaNen,                                   ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaTsuki,                                 ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaBi)                                    ");
            sqlContent.Append("                                               ELSE CONCAT(KensaIraiTbl.KensaIraiKensaYoteiNen,                              ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaYoteiTsuki,                            ");
            sqlContent.Append("                                                           KensaIraiTbl.KensaIraiKensaYoteiBi)                               ");
            sqlContent.Append("                                          END ),                                                                             ");
            
            //sqlContent.Append("     ZenkaiKensaDataWrk.ZenkaiKensaDt = KensaIraiTbl.KensaIraiSuishitsuUketsukeDt,                                           ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaKbn = '3',                                                                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetteiKbn = '1'                                                                                      ");

            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     KensaIraiTbl                                                                                                            ");
            sqlContent.Append("         ON KensaIraiTbl.KensaIraiJokasoHokenjoCd = ZenkaiKensaDataWrk.JokasoHokenjoCd                                             ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiJokasoTorokuNendo = ZenkaiKensaDataWrk.JokasoTorokuNendo                                              ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiJokasoRenban = ZenkaiKensaDataWrk.JokasoRenban                                                  ");
            sqlContent.Append("         AND KensaIraiTbl.KensaIraiHoteiKbn = '1'                                                                            ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     GyoshaMst                                                                                                               ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KensaIraiTbl.KensaIraiHoshutenkenGyoshaCd                                                   ");

            #endregion

            #region WHERE

            sqlContent.Append("WHERE                                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                                   ");

            sqlContent.Append("AND ZenkaiKensaDataWrk.SetteiKbn = '0'                                                                                       ");

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

        #region JinendoGaikenStep6
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JinendoGaikenStep5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容 
        /// 2014/12/03　DatNT 　 新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void JinendoGaikenStep6(string nendo)
        {
            SqlCommand command = CreateSqlCommandJinendoGaikenStep6(nendo);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            command.Connection = this.Connection;

            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandJinendoGaikenStep6
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommandJinendoGaikenStep6
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandJinendoGaikenStep6(string nendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            string uketsukeDtFrom = (Convert.ToInt32(nendo) - 2) + "0401";
            string uketsukeDtTo = Convert.ToInt32(nendo) + "0331";

            #region UPDATE

            sqlContent.Append("UPDATE                                                                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("SET                                                                                                                          ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KeiryoShomeiIraiNendo = KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                   ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KeiryoShomeiIraiShishoCd = KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                              ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KeiryoShomeiIraiRenban = KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban,                                 ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd = KeiryoShomeiIraiTbl.KeiryoShomeiSeikyuGyoshaCd,                                           ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaNm = GyoshaMst.GyoshaNm,                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaPeriod = '2',                                                                                   ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ZenkaiKensaDt = KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt,                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaKbn = '4',                                                                                      ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetteiKbn = '1'                                                                                      ");

            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     ZenkaiKensaDataWrk                                                                                                      ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     KeiryoShomeiIraiTbl                                                                                                     ");
            sqlContent.Append("         ON KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd = ZenkaiKensaDataWrk.JokasoHokenjoCd                       ");
            sqlContent.Append("         AND KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoNendo = ZenkaiKensaDataWrk.JokasoTorokuNendo                        ");
            sqlContent.Append("         AND KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoRenban = ZenkaiKensaDataWrk.JokasoRenban                            ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                                              ");
            sqlContent.Append("     GyoshaMst                                                                                                               ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = KeiryoShomeiIraiTbl.KeiryoShomeiSeikyuGyoshaCd                                              ");
            sqlContent.Append("INNER JOIN                                                                                                                   ");
            sqlContent.Append("     (   SELECT                                                                                                              ");
            sqlContent.Append("             KeiryoShomeiJokasoDaichoHokenjoCd,                                                                              ");
            sqlContent.Append("             KeiryoShomeiJokasoDaichoNendo,                                                                                  ");
            sqlContent.Append("             KeiryoShomeiJokasoDaichoRenban,                                                                                 ");
            sqlContent.Append("             MAX(KeiryoShomeiIraiUketsukeDt) AS UketsukeDt                                                                   ");
            sqlContent.Append("         FROM KeiryoShomeiIraiTbl                                                                                            ");
            sqlContent.Append("         WHERE KeiryoShomeiJokasoDaichoHokenjoCd = KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd                     ");
            sqlContent.Append("                 AND KeiryoShomeiJokasoDaichoNendo = KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoNendo                       ");
            sqlContent.Append("                 AND KeiryoShomeiJokasoDaichoRenban = KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoRenban                     ");
            sqlContent.Append("                 AND KeiryoShomeiIraiUketsukeDt >= @uketsukeDtFrom                                                           ");
            sqlContent.Append("                 AND KeiryoShomeiIraiUketsukeDt <= @uketsukeDtTo                                                             ");
            sqlContent.Append("         GROUP BY                                                                                                            ");
            sqlContent.Append("             KeiryoShomeiJokasoDaichoHokenjoCd,                                                                              ");
            sqlContent.Append("             KeiryoShomeiJokasoDaichoNendo,                                                                                  ");
            sqlContent.Append("             KeiryoShomeiJokasoDaichoRenban   ) Tbl                                                                          ");
            sqlContent.Append("     ON Tbl.KeiryoShomeiJokasoDaichoHokenjoCd = KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoHokenjoCd                        ");
            sqlContent.Append("     AND Tbl.KeiryoShomeiJokasoDaichoNendo = KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoNendo                               ");
            sqlContent.Append("     AND Tbl.KeiryoShomeiJokasoDaichoRenban = KeiryoShomeiIraiTbl.KeiryoShomeiJokasoDaichoRenban                             ");
            sqlContent.Append("     AND Tbl.UketsukeDt = KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt                                                     ");

            #endregion

            #region WHERE

            sqlContent.Append("WHERE                                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                                   ");

            sqlContent.Append("AND ZenkaiKensaDataWrk.SetteiKbn = '0'                                                                                       ");

            commandParams.Add("@uketsukeDtFrom", SqlDbType.NVarChar).Value = uketsukeDtFrom;
            commandParams.Add("@uketsukeDtTo", SqlDbType.NVarChar).Value = uketsukeDtTo;

            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

        #region JinendoGaikenStep7
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JinendoGaikenStep5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCdFrom"></param>
        /// <param name="gyoshaCdTo"></param>
        /// <param name="nendo"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容 
        /// 2014/12/03　DatNT 　 新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void JinendoGaikenStep7(
            string gyoshaCdFrom, 
            string gyoshaCdTo, 
            string nendo,
            DateTime now)
        {
            SqlCommand command = CreateSqlCommandJinendoGaikenStep7(gyoshaCdFrom, gyoshaCdTo, nendo, now);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            command.Connection = this.Connection;

            command.ExecuteNonQuery();
        }
        #endregion

        #region CreateSqlCommandJinendoGaikenStep7
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommandJinendoGaikenStep7
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCdFrom"></param>
        /// <param name="gyoshaCdTo"></param>
        /// <param name="nendo"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　DatNT　　新規作成
        /// 2014/12/16　kiyokuni　仕様変更 業者コードも更新
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommandJinendoGaikenStep7(
            string gyoshaCdFrom, 
            string gyoshaCdTo,
            string nendo,
            DateTime now)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region INSERT INTO

            sqlContent.Append("INSERT INTO JinendoGaikanYoteiOutputTbl (                                                                                                      ");
            sqlContent.Append("     Nendo,                                                                                                  ");
            sqlContent.Append("     JokasoHokenjoCd,                                                                                        ");
            sqlContent.Append("     JokasoTorokuNendo,                                                                                      ");
            sqlContent.Append("     JokasoRenban,                                                                                           ");
            sqlContent.Append("     ZenkaiKensaDt,                                                                                          ");
            sqlContent.Append("     NinsoKbn,                                                                                               ");
            sqlContent.Append("     KensaKbn,                                                                                               ");
            sqlContent.Append("     ShoriHoshikiKbn,                                                                                        ");
            sqlContent.Append("     SeikyuGyoshaCd,                                                                                         ");
            sqlContent.Append("     YoteiNengetsu,                                                                                          ");
            sqlContent.Append("     IraiMakeKbn,                                                                                            ");
            sqlContent.Append("     RenkeiMakeKbn,                                                                                          ");
            sqlContent.Append("     InsertDt,                                                                                               ");
            sqlContent.Append("     InsertTarm,                                                                                             ");
            sqlContent.Append("     InsertUser,                                                                                             ");
            sqlContent.Append("     UpdateDt,                                                                                               ");
            sqlContent.Append("     UpdateTarm,                                                                                             ");
            sqlContent.Append("     UpdateUser                                                                                              ");
            sqlContent.Append("   )                                                                                                         ");

            #endregion

            #region SELECT

            sqlContent.Append("SELECT                                                                                                       ");
            sqlContent.Append("     @nendo AS Nendo,                                                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.JokasoHokenjoCd,                                                                     ");
            sqlContent.Append("     ZenkaiKensaDataWrk.JokasoTorokuNendo,                                                                   ");
            sqlContent.Append("     ZenkaiKensaDataWrk.JokasoRenban,                                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ZenkaiKensaDt,                                                                       ");
            sqlContent.Append("     ZenkaiKensaDataWrk.NinsoKbn,                                                                            ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaKbn,                                                                            ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ShoriHoshikiKbn,                                                                     ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd,                                                                                   ");
            //sqlContent.Append("     '' AS SeikyuGyoshaCd,                                                                                   ");
            sqlContent.Append("     CASE WHEN ISNULL(ZenkaiKensaDataWrk.ZenkaiKensaDt, '') <> ''                                            ");
            sqlContent.Append("         THEN CONCAT(SUBSTRING(ZenkaiKensaDataWrk.ZenkaiKensaDt, 0, 5) + 1,                                  ");
            sqlContent.Append("                     SUBSTRING(ZenkaiKensaDataWrk.ZenkaiKensaDt, 5, 2)) END AS YoteiNengetsu,                ");
            sqlContent.Append("     '0' AS IraiMakeKbn,                                                                                     ");
            sqlContent.Append("     '1' AS RenkeiMakeKbn,                                                                                   ");
            sqlContent.Append("     @Now,                                                                                                   ");
            sqlContent.Append("     @PcUpdate,                                                                                              ");
            sqlContent.Append("     @LoginUser,                                                                                             ");
            sqlContent.Append("     @Now,                                                                                                   ");
            sqlContent.Append("     @PcUpdate,                                                                                              ");
            sqlContent.Append("     @LoginUser                                                                                              ");

            #endregion

            #region FROM

            sqlContent.Append("FROM ZenkaiKensaDataWrk                                                                                      ");

            #endregion

            #region WHERE

            sqlContent.Append("WHERE 1 = 1                                                                                                  ");

            // 設定区分
            sqlContent.Append("AND ZenkaiKensaDataWrk.SetteiKbn = '1'                                                                       ");

            // 業者コード
            if (!string.IsNullOrEmpty(gyoshaCdFrom))
            {
                sqlContent.Append("AND ZenkaiKensaDataWrk.GyoshaCd >= @gyoshaCdFrom ");
                commandParams.Add("@gyoshaCdFrom", SqlDbType.NVarChar).Value = gyoshaCdFrom;
            }
            if (!string.IsNullOrEmpty(gyoshaCdTo))
            {
                sqlContent.Append("AND ZenkaiKensaDataWrk.GyoshaCd <= @gyoshaCdTo ");
                commandParams.Add("@gyoshaCdTo", SqlDbType.NVarChar).Value = gyoshaCdTo;
            }

            sqlContent.Append("AND NOT EXISTS (                                                                                             ");
            sqlContent.Append("     SELECT                                                                                                  ");
            sqlContent.Append("         *                                                                                                   ");
            sqlContent.Append("     FROM                                                                                                    ");
            sqlContent.Append("         JinendoGaikanYoteiOutputTbl                                                                         ");
            sqlContent.Append("     WHERE                                                                                                   ");
            sqlContent.Append("         JinendoGaikanYoteiOutputTbl.JokasoHokenjoCd = ZenkaiKensaDataWrk.JokasoHokenjoCd                    ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoTorokuNendo = ZenkaiKensaDataWrk.JokasoTorokuNendo            ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoRenban = ZenkaiKensaDataWrk.JokasoRenban                      ");
            sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.Nendo = @nendo                                                      ");
            sqlContent.Append("     )                                                                                                       ");

            #endregion

            #region ORDER BY

            sqlContent.Append("ORDER BY                                                                                                     ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd,                                                                            ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.ShichosonCd,                                                                         ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.ShichosonNm,                                                                         ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.JokasoHokenjoCd,                                                                     ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.JokasoTorokuNendo,                                                                   ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.JokasoRenban                                                                         ");

            #endregion

            commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
            commandParams.Add("@Now", SqlDbType.DateTime).Value = now;
            commandParams.Add("@PcUpdate", SqlDbType.NVarChar).Value = Dns.GetHostName();
            commandParams.Add("@LoginUser", SqlDbType.NVarChar).Value = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region ZenkaiKensaDataWrkKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ZenkaiKensaDataWrkKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24　HuyTX　　 新規作成
    /// 2014/11/23  DatNT     v1.02
    /// 2015/01/22　小松　　　　コマンドタイムアウト設定
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class ZenkaiKensaDataWrkKensakuTableAdapter
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
        /// <param name="gyoshaCdFrom"></param>
        /// <param name="gyoshaCdTo"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24　HuyTX　　 新規作成
        /// 2014/11/23  DatNT    v1.02
        /// 2014/12/04  DatNT   add nendo
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable GetDataBySearchCond(
            string gyoshaCdFrom, 
            string gyoshaCdTo,
            string nendo)
            //bool existFlg)
        {
            SqlCommand command = CreateSqlCommand(gyoshaCdFrom, gyoshaCdTo, nendo);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable dataTable = new ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable();
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
        /// <param name="gyoshaCdFrom"></param>
        /// <param name="gyoshaCdTo"></param>
        /// <param name="nendo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24　HuyTX　　新規作成
        /// 2014/11/23  DatNT   v1.02
        /// 2014/12/04  DatNT   add nendo
        /// 2014/12/04  habu    件数制限対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string gyoshaCdFrom, 
            string gyoshaCdTo, 
            string nendo)
            //bool existFlg)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            // 20141228 habu → 仕様上戻す kiyokuni
            //sqlContent.Append("SELECT TOP 2000                                                                                              ");
            sqlContent.Append("SELECT                                                                                                       ");
            // 20141228 End
            sqlContent.Append("     ZenkaiKensaDataWrk.RenkeiKbn,                                                                           ");
            sqlContent.Append("     CASE WHEN ZenkaiKensaDataWrk.RenkeiKbn = '1' THEN '済' ELSE '' END AS outputKbnCol,                     ");
            sqlContent.Append("     ZenkaiKensaDataWrk.NyuryokuKbn,                                                                         ");
            sqlContent.Append("     CASE WHEN ZenkaiKensaDataWrk.NyuryokuKbn = '1' THEN '済' ELSE '' END AS inputKbnCol,                    ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd,                                                                            ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaNm,                                                                            ");
            sqlContent.Append("     ZenkaiKensaDataWrk.NinsoKbn,                                                                            ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaPeriod,                                                                         ");
            sqlContent.Append("     CASE ZenkaiKensaDataWrk.NinsoKbn                                                                        ");
            sqlContent.Append("         WHEN '1' THEN CASE ZenkaiKensaDataWrk.KensaPeriod                                                   ");
            sqlContent.Append("                         WHEN '1' THEN '《５０人槽以下》★近年検査受付分★'                                    ");
            sqlContent.Append("                         WHEN '2' THEN '《５０人槽以下》★その他検査実施分★' END                              ");
            sqlContent.Append("         WHEN '2' THEN CASE ZenkaiKensaDataWrk.KensaPeriod                                                   ");
            sqlContent.Append("                         WHEN '1' THEN '《５１人槽以上》★近年検査受付分★'                                    ");
            sqlContent.Append("                         WHEN '2' THEN '《５１人槽以上》★その他検査実施分★' END                              ");
            sqlContent.Append("     END AS sakuhyoKbnCol,                                                                                   ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ShichosonNm,                                                                         ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetchishaNm,                                                                         ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetchishaAdr,                                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.Ninso,                                                                               ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ShoriHoshikiKbn,                                                                     ");
            sqlContent.Append("     ZenkaiKensaDataWrk.ZenkaiKensaDt,                                                                       ");
            sqlContent.Append("     dbo.FuncConvertToWareki(ZenkaiKensaDt, 'yy.MM.dd', 1) AS kensaDtCol,                                    ");
            sqlContent.Append("     ZenkaiKensaDataWrk.KensaKbn,                                                                            ");
            sqlContent.Append("     CASE ZenkaiKensaDataWrk.KensaKbn                                                                        ");
            sqlContent.Append("         WHEN '1' THEN '11条外観'                                                                            ");
            sqlContent.Append("         WHEN '2' THEN '11条水質'                                                                            ");
            sqlContent.Append("         WHEN '3' THEN '7条検査'                                                                             ");
            sqlContent.Append("         WHEN '4' THEN '水質検査' END AS kensaKbnCol,                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetchishaKbn,                                                                        ");
            sqlContent.Append("     ZenkaiKensaDataWrk.SetchishaCd,                                                                         ");
            sqlContent.Append("     ZenkaiKensaDataWrk.JokasoHokenjoCd,                                                                     ");
            sqlContent.Append("     ZenkaiKensaDataWrk.JokasoTorokuNendo,                                                                   ");
            sqlContent.Append("     ZenkaiKensaDataWrk.JokasoRenban,                                                                        ");
            sqlContent.Append("     CONCAT(ZenkaiKensaDataWrk.JokasoHokenjoCd, '-',                                                         ");
            sqlContent.Append("             dbo.FuncConvertIraiNedoToWareki(ZenkaiKensaDataWrk.JokasoTorokuNendo), '-',                     ");
            sqlContent.Append("             ZenkaiKensaDataWrk.JokasoRenban) AS jokasoCdCol,                                                ");
            sqlContent.Append("     ConstMst.ConstNm                                                                                        ");

            // FROM
            sqlContent.Append("FROM ZenkaiKensaDataWrk                                                                                      ");
            sqlContent.Append("LEFT OUTER JOIN ConstMst                                                                                     ");
            sqlContent.Append(" 	ON ConstMst.ConstKbn = '022' AND ConstMst.ConstValue = ZenkaiKensaDataWrk.ShoriHoshikiKbn               ");

            // WHERE
            sqlContent.Append("WHERE 1 = 1                                                                                                  ");

            // 設定区分
            sqlContent.Append("AND ZenkaiKensaDataWrk.SetteiKbn = '1'                                                                       ");

            // 業者コード
            if (!string.IsNullOrEmpty(gyoshaCdFrom))
            {
                sqlContent.Append("AND ZenkaiKensaDataWrk.GyoshaCd >= @gyoshaCdFrom ");
                commandParams.Add("@gyoshaCdFrom", SqlDbType.NVarChar).Value = gyoshaCdFrom;
            }
            if (!string.IsNullOrEmpty(gyoshaCdTo))
            {
                sqlContent.Append("AND ZenkaiKensaDataWrk.GyoshaCd <= @gyoshaCdTo ");
                commandParams.Add("@gyoshaCdTo", SqlDbType.NVarChar).Value = gyoshaCdTo;
            }

            // 2014/12/04 DatNT Add Start
            //if (existFlg)
            //{
            //    sqlContent.Append("AND NOT EXISTS (                                                                                         ");
            //    sqlContent.Append("     SELECT                                                                                              ");
            //    sqlContent.Append("         *                                                                                               ");
            //    sqlContent.Append("     FROM                                                                                                ");
            //    sqlContent.Append("         JinendoGaikanYoteiOutputTbl                                                                     ");
            //    sqlContent.Append("     WHERE                                                                                               ");
            //    sqlContent.Append("         JinendoGaikanYoteiOutputTbl.JokasoHokenjoCd = ZenkaiKensaDataWrk.JokasoHokenjoCd                ");
            //    sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoTorokuNendo = ZenkaiKensaDataWrk.JokasoTorokuNendo        ");
            //    sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.JokasoRenban = ZenkaiKensaDataWrk.JokasoRenban                  ");
            //    sqlContent.Append("         AND JinendoGaikanYoteiOutputTbl.Nendo = @nendo                                                  ");
            //    sqlContent.Append("     )                                                                                                   ");

            //    commandParams.Add("@nendo", SqlDbType.NVarChar).Value = nendo;
            //}
            // 2014/12/04 DatNT Add End

            // ORDER BY
            sqlContent.Append("ORDER BY                                                                                                     ");
            sqlContent.Append("     ZenkaiKensaDataWrk.GyoshaCd,                                                                            ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.ShichosonCd,                                                                         ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.ShichosonNm,                                                                         ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.JokasoHokenjoCd,                                                                     ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.JokasoTorokuNendo,                                                                   ");
            sqlContent.Append(" 	ZenkaiKensaDataWrk.JokasoRenban                                                                         ");

            #region 2014/11/23 DatNT DEL
            ////SELECT
            //sqlContent.Append(" SELECT ");
            //sqlContent.Append(" 	zkdw.GyoshaCd as gyoshaCdCol, ");
            //sqlContent.Append(" 	zkdw.GyoshaNm as gyoshaNmCol, ");
            //sqlContent.Append(" 	CASE  ");
            //sqlContent.Append(" 		WHEN zkdw.NinsoKbn = '1' AND zkdw.KensaPeriod = '1' THEN '《５０人槽以下》★近年検査受付分★' ");
            //sqlContent.Append(" 		WHEN zkdw.NinsoKbn = '1' AND zkdw.KensaPeriod = '2' THEN '《５０人槽以下》★その他検査実施分★' ");
            //sqlContent.Append(" 		WHEN zkdw.NinsoKbn = '2' AND zkdw.KensaPeriod = '1' THEN '《５１人槽以上》★近年検査受付分★' ");
            //sqlContent.Append(" 		WHEN zkdw.NinsoKbn = '2' AND zkdw.KensaPeriod = '2' THEN '《５１人槽以上》★その他検査実施分★' ");
            //sqlContent.Append(" 		ELSE '' ");
            //sqlContent.Append(" 	END as sakuhyoKbnCol, ");
            //sqlContent.Append(" 	cm.ChikuNm as chikuNmCol, ");
            //sqlContent.Append(" 	zkdw.SetchishaNm as kensaIraiSetchishaNmCol, ");
            //sqlContent.Append(" 	zkdw.SetchishaAdr as kensaIraiSetchibashoAdrCol, ");
            //sqlContent.Append(" 	zkdw.Ninso as kensaIraiShoritaishoJininCol, ");
            //sqlContent.Append(" 	const.ConstNm as shoriHoshikiCol, ");
            ////sqlContent.Append(" 	CASE  ");
            ////sqlContent.Append(" 		WHEN ISDATE(zkdw.ZenkaiKensaDt) = 0 THEN '' ");
            ////sqlContent.Append(" 		ELSE CONCAT((SUBSTRING(zkdw.ZenkaiKensaDt, 1, 4) - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= zkdw.ZenkaiKensaDt ORDER BY KaishiDt DESC)), '/', SUBSTRING(zkdw.ZenkaiKensaDt, 5, 2), '/', SUBSTRING(zkdw.ZenkaiKensaDt, 7, 2)) ");
            ////sqlContent.Append(" 	END as kensaDtCol, ");
            //sqlContent.Append(" 	CASE  ");
            //sqlContent.Append(" 		WHEN ISDATE(zkdw.ZenkaiKensaDt) = 0 THEN '' ");
            //sqlContent.Append(" 		ELSE CONCAT([dbo].[FuncConvertToWareki](SUBSTRING(zkdw.ZenkaiKensaDt, 1, 4), 'yy', 1), '/', SUBSTRING(zkdw.ZenkaiKensaDt, 5, 2), '/', SUBSTRING(zkdw.ZenkaiKensaDt, 7, 2)) ");
            //sqlContent.Append(" 	END as kensaDtCol, ");
            //sqlContent.Append(" 	CASE zkdw.KensaKbn ");
            //sqlContent.Append(" 		WHEN '1' THEN '11条外観' ");
            //sqlContent.Append(" 		WHEN '2' THEN '11条水質' ");
            //sqlContent.Append(" 		WHEN '3' THEN '7条検査' ");
            //sqlContent.Append(" 		WHEN '4' THEN '水質検査' ");
            //sqlContent.Append(" 		ELSE '' ");
            //sqlContent.Append(" 	END as kensaKbnCol, ");
            //sqlContent.Append(" 	zkdw.SetchishaKbn as jokasoSetchishaKbnCol, ");
            //sqlContent.Append(" 	zkdw.SetchishaCd as jokasoSetchishaCdCol ");

            ////FROM
            //sqlContent.Append(" FROM ZenkaiKensaDataWrk zkdw ");
            //sqlContent.Append(" 	LEFT OUTER JOIN ChikuMst cm ON cm.ChikuCd = zkdw.ShichosonCd ");
            //sqlContent.Append(" 	LEFT OUTER JOIN ConstMst const ON const.ConstValue = zkdw.ShoriHoshikiKbn AND const.ConstKbn = '022' ");

            ////WHERE
            //sqlContent.Append(" WHERE 1 = 1 ");

            ////市町村
            //if (!string.IsNullOrEmpty(chikuCdFrom) && string.IsNullOrEmpty(chikuCdTo))
            //{
            //    //sqlContent.Append(" AND zkdw.ShichosonCd " + DataAccessUtility.SetBetweenCommand(chikuCdFrom, chikuCdTo, 5));
            //    sqlContent.Append(" AND zkdw.ShichosonCd >= @chikuCdFrom ");
            //    commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;
            //}
            //else if (string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            //{
            //    sqlContent.Append(" AND zkdw.ShichosonCd <= @chikuCdTo ");
            //    commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            //}
            //else if (!string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            //{
            //    sqlContent.Append(" AND zkdw.ShichosonCd >= @chikuCdFrom ");
            //    commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;

            //    sqlContent.Append(" AND zkdw.ShichosonCd <= @chikuCdTo ");
            //    commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            //}
            
            ////業者コード
            //if (!string.IsNullOrEmpty(gyoshaCdFrom) && string.IsNullOrEmpty(gyoshaCdTo))
            //{
            //    //sqlContent.Append(" AND zkdw.GyoshaCd " + DataAccessUtility.SetBetweenCommand(gyoshaCdFrom, gyoshaCdTo, 4));
            //    sqlContent.Append(" AND zkdw.GyoshaCd >= @gyoshaCdFrom ");
            //    commandParams.Add("@gyoshaCdFrom", SqlDbType.NVarChar).Value = gyoshaCdFrom;
            //}
            //else if (string.IsNullOrEmpty(gyoshaCdFrom) && !string.IsNullOrEmpty(gyoshaCdTo))
            //{
            //    sqlContent.Append(" AND zkdw.GyoshaCd <= @gyoshaCdTo ");
            //    commandParams.Add("@gyoshaCdTo", SqlDbType.NVarChar).Value = gyoshaCdTo;
            //}
            //else if (!string.IsNullOrEmpty(gyoshaCdFrom) && !string.IsNullOrEmpty(gyoshaCdTo))
            //{
            //    sqlContent.Append(" AND zkdw.GyoshaCd >= @gyoshaCdFrom ");
            //    commandParams.Add("@gyoshaCdFrom", SqlDbType.NVarChar).Value = gyoshaCdFrom;

            //    sqlContent.Append(" AND zkdw.GyoshaCd <= @gyoshaCdTo ");
            //    commandParams.Add("@gyoshaCdTo", SqlDbType.NVarChar).Value = gyoshaCdTo;
            //}
            
            ////ORDER BY
            //sqlContent.Append(" ORDER BY zkdw.JokasoHokenjoCd, ");
            //sqlContent.Append(" 		 zkdw.JokasoTorokuNendo, ");
            //sqlContent.Append(" 		 zkdw.JokasoRenban ");
            #endregion

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
