using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{

    public partial class KeiryoShomeiIraiTblDataSet
    {

    }
}

namespace FukjBizSystem.Application.DataSet.KeiryoShomeiIraiTblDataSetTableAdapters
{
    partial class PrintKeriyoShomeiType1TableAdapter
    {
        #region GetPrintKeiryoShomeiType1ByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetPrintKeiryoShomeiType1ByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keiryoShomeiIraiSishoCd"></param>
        /// <param name="keiryoShomeiIraiNendo"></param>
        /// <param name="settisha"></param>     
        /// <param name="suikenNoFrom"></param>     
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable GetPrintKeiryoShomeiType1ByCond(
            string keiryoShomeiIraiSishoCd,
            string keiryoShomeiIraiNendo,
            string keiryoShomeiIraiRenban
            )
        {            
            SqlCommand command = CreateSqlCommand(keiryoShomeiIraiSishoCd,
                                                  keiryoShomeiIraiNendo,
                                                  keiryoShomeiIraiRenban);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;
            
            KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable dataTable = new KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType1DataTable();
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
        /// <param name="keiryoShomeiIraiSishoCd"></param>
        /// <param name="keiryoShomeiIraiNendo"></param>
        /// <param name="settisha"></param>     
        /// <param name="suikenNoFrom"></param>     
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string keiryoShomeiIraiSishoCd,
            string keiryoShomeiIraiNendo,
            string keiryoShomeiIraiRenban
            )
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            // SELECT
            sqlContent.Append("SELECT                                                                                                                                                                                               ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiNendo,                                                                                                                                                                     ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiSishoCd,                                                                                                                                                                   ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiRenban,                                                                                                                                                                    ");
            sqlContent.Append("     ksit.KeiryoShomeiHiHeikinOsuiRyo,                                                                                                                                                               ");
            sqlContent.Append("     ksit.KeiryoShomeiNinsou,                                                                                                                                                                        ");
            sqlContent.Append("     ksit.UpdateDt,                                                                                                                                                                                  ");
            sqlContent.Append("     ksit.KeiryoShomeiShomeishoInsatsuCnt,                                                                                                                                                           ");
            sqlContent.Append("     jdm.JokasoSetchishaNm,                                                                                                                                                                          ");
            sqlContent.Append("     kskt.KeiryoShomeiGaibuItakuFlg,                                                                                                                                                                 ");
            sqlContent.Append("     CONCAT(ksit.KeiryoShomeiJokasoDaichoHokenjoCd , '-' , [dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiJokasoDaichoNendo), '-', ksit.KeiryoShomeiJokasoDaichoRenban) AS 'JokasoNo',         ");
            sqlContent.Append("     CONCAT(sm.ShishoNm, [dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiIraiNendo), '第', ksit.KeiryoShomeiIraiRenban, '号') AS 'ShishoNm',                                    ");
            sqlContent.Append("     CONCAT(sm.ShishoNm, '検査センター (福岡県登録 第',sm.ShishoKenTorokuNo,'号)') AS ShishoNmTorokuNo,                                                                                                ");
            sqlContent.Append("     sm.ShishoAdr,                                                                                                                                                                                   ");
            sqlContent.Append("     sm.ShishoTelNo,                                                                                                                                                                                 ");
            sqlContent.Append("     sm.ShishoKeiryoKanrisha,                                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoSetchiBashoAdr,                                                                                                                                                                       ");
            sqlContent.Append("     CONCAT('（環境計量士（濃度関係）　登録番号　第', sm.ShishoKankyoKeiryoshiNo, '号）') AS ShishoKankyoKeiryoshiNo,                                                                                     ");
            sqlContent.Append("     CONCAT(shm.ShoriHoshikiShubetsuNm,' ', shm.ShoriHoshikiNm) AS 'ShoriHoshikiShubetsuNm',                                                                                                         ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiUketsukeDt,                                                                                                                                                                ");
            sqlContent.Append("     hm.HokenjoNm,                                                                                                                                                                                   ");
            sqlContent.Append("     ssm.SuishitsuNm,                                                                                                                                                                                ");
            sqlContent.Append("     gm.GyoshaNm,                                                                                                                                                                                    ");
            sqlContent.Append("     case                                                                                                                                                                                            ");
			sqlContent.Append("         when kskt.KeiryoShomeiGaibuItakuFlg IS NOT NULL AND kskt.KeiryoShomeiGaibuItakuFlg = 1 then CONCAT(sskm.SeishikiNm, ' ', '※１') else sskm.SeishikiNm                                       ");	//結合20141227 mod
            sqlContent.Append("     end as SeishikiNm,                                                                                                                                                                              ");
            sqlContent.Append("     sskm.KeiryouHouhouNmUp,                                                                                                                                                                         ");
            sqlContent.Append("     sskm.KeiryouHouhouNmDown,                                                                                                                                                                       ");
            sqlContent.Append("     case                                                                                                                                                                                            ");
            sqlContent.Append("         when kskt.KeiryoShomeiKekkaOndo <= 0 OR kskt.KeiryoShomeiKekkaOndo IS NULL then '' else CONCAT('(',kskt.KeiryoShomeiKekkaOndo,')')                                                          ");
            sqlContent.Append("     end as KeiryoShomeiKekkaOndo,                                                                                                                                                                   ");

            //sqlContent.Append("     case                                                                                                                                                                                            ");
            //sqlContent.Append("         when kskt.KeiryoShomeiKekkaValueHyojiyo != '' AND kskt.KeiryoShomeiKekkaValue < sskm.TeiryoKagenchi1 THEN '定量下限値未満'                                                                   ");
            //sqlContent.Append("         when kskt.KeiryoShomeiKekkaValueHyojiyo = '' THEN CONCAT(kskt.KeiryoShomeiKekkaValueHyojiyo, sskm.Unit,sknm.SuishitsuKekkaNm, case WHEN kskt.KeiryoShomeiKekkaOndo <= 0 THEN '' ELSE CONCAT('(',kskt.KeiryoShomeiKekkaOndo,')') END)");
            //sqlContent.Append("     end AS KeiryouKekka,                                                                                                                                                                            ");
            sqlContent.Append("     CASE                                                                                                                                                                                          ");
            sqlContent.Append("         WHEN kskt.KeiryoShomeiKekkaValueHyojiyo != '' AND kskt.KeiryoShomeiKekkaValue < sskm.TeiryoKagenchi1 THEN                                                                                   ");
            sqlContent.Append("             '定量下限値未満'                                                                                                                                                                        ");
            sqlContent.Append("         ELSE                                                                                                                                                                                        ");
            sqlContent.Append("             CONCAT(                                                                                                                                                                                ");
            sqlContent.Append("                 CONCAT(kskt.KeiryoShomeiKekkaValueHyojiyo, ' ')                                                                                                                                     ");
            // 20150131 sou Start
            //sqlContent.Append("             ,    CONCAT(sskm.Unit, ' ')                                                                                                                                                              ");
            sqlContent.Append("             ,   CASE                                                                                                                                                                                ");
            sqlContent.Append("                 WHEN sskm.Unit != '' THEN ");
            sqlContent.Append("                     CONCAT(sskm.Unit, ' ') ");
            sqlContent.Append("                 ELSE ");
            sqlContent.Append("                     '' ");
            sqlContent.Append("                 END ");
            // 20150131 sou End
            sqlContent.Append("             ,    CASE                                                                                                                                                                                ");
            sqlContent.Append("                 WHEN sknm.SuishitsuKekkaNm != '' THEN                                                                                                                                               ");
            sqlContent.Append("                     CONCAT(sknm.SuishitsuKekkaNm, ' ')                                                                                                                                              ");
            sqlContent.Append("                 ELSE                                                                                                                                                                                ");
            sqlContent.Append("                     ''                                                                                                                                                                              ");
            sqlContent.Append("                 END                                                                                                                                                                                 ");
            sqlContent.Append("             , CASE                                                                                                                                                                                  ");
            sqlContent.Append("                 WHEN kskt.KeiryoShomeiKekkaOndo <= 0 THEN                                                                                                                                           ");
            sqlContent.Append("                     ''                                                                                                                                                                              ");
            sqlContent.Append("                 ELSE                                                                                                                                                                                ");
            sqlContent.Append("                     CONCAT('(', kskt.KeiryoShomeiKekkaOndo, '℃)')                                                                                                                                    ");
            sqlContent.Append("                 END                                                                                                                                                                                 ");
            sqlContent.Append("             )                                                                                                                                                                                           ");
            sqlContent.Append("     END    AS KeiryouKekka,                                                                                                                                                                         ");

            sqlContent.Append("     case                                                                                                                                                                                            ");
            sqlContent.Append("         when sskm.TeiryoHyojiyo1 IS NULL OR sskm.TeiryoHyojiyo1 = '' then '' else CONCAT(sskm.TeiryoHyojiyo1, sskm.Unit)                                                                            ");
            sqlContent.Append("     end AS Teiryou                                                                                                                                                                                  ");
            // FROM
            sqlContent.Append("FROM                                                                                                                                                                                                 ");
            sqlContent.Append("     KeiryoShomeiIraiTbl AS ksit                                                                                                                                                                     ");
            sqlContent.Append("     INNER JOIN JokasoDaichoMst AS jdm                                                                                                                                                               ");
            sqlContent.Append("     ON ksit.KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd                                                                                                                                 ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo                                                                                                                                  ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban                                                                                                                                      ");
            sqlContent.Append("     INNER JOIN KeiryoShomeiKekkaTbl AS kskt                                                                                                                                                         ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiNendo = kskt.KeiryoShomeiKekkaIraiNendo                                                                                                                                 ");
            sqlContent.Append("     AND ksit.KeiryoShomeiIraiSishoCd = kskt.KeiryoShomeiKekkaIraiShishoCd                                                                                                                           ");
            sqlContent.Append("     AND ksit.KeiryoShomeiIraiRenban = kskt.KeiryoShomeiKekkaIraiNo                                                                                                                                  ");
            // 20150131 sou Start
            //sqlContent.Append("     LEFT OUTER JOIN SuishitsuShikenKoumokuMst AS sskm                                                                                                                                               ");
            //sqlContent.Append("     ON kskt.KeiryoShomeiShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd                                                                                                                             ");
            sqlContent.Append("     INNER JOIN SuishitsuShikenKoumokuMst AS sskm ");
            sqlContent.Append("     ON kskt.KeiryoShomeiShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd ");
            sqlContent.Append("     AND '1' = sskm.InjiKbn ");
            // 20150131 sou End
            sqlContent.Append("     LEFT OUTER JOIN ShishoMst AS sm                                                                                                                                                                 ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiSishoCd = sm.ShishoCd                                                                                                                                                   ");
            sqlContent.Append("     LEFT OUTER JOIN ShoriHoshikiMst AS shm                                                                                                                                                          ");
            sqlContent.Append("     ON ksit.KeiryoShomeiShoriHousikiKbn = shm.ShoriHoshikiKbn                                                                                                                                       ");
            sqlContent.Append("     AND ksit.KeiryoShomeiShoriHousikiCd = shm.ShoriHoshikiCd                                                                                                                                        ");
            sqlContent.Append("     LEFT OUTER JOIN HokenjoMst AS hm                                                                                                                                                                ");
            sqlContent.Append("     ON ksit.KeiryoShomeiHokenjoCd = hm.HokenjoCd                                                                                                                                                    ");
            sqlContent.Append("     LEFT OUTER JOIN SuishitsuMst AS ssm                                                                                                                                                             ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiSishoCd = ssm.SuishitsuShishoCd                                                                                                                                         ");
            sqlContent.Append("     AND ksit.KeiryoShomeiSuisitsuCd = ssm.SuishitsuCd                                                                                                                                               ");
            sqlContent.Append("     LEFT OUTER JOIN GyoshaMst AS gm                                                                                                                                                                 ");
            sqlContent.Append("     ON ksit.KeiryoShomeiSaisuiGyoshaCd = gm.GyoshaCd                                                                                                                                                ");
            sqlContent.Append("     LEFT OUTER JOIN SuishitsuKekkaNmMst AS sknm                                                                                                                                                     ");
            sqlContent.Append("     ON kskt.KeiryoShomeiKekkaIraiShishoCd = sknm.SuishitsuKekkaShishoCd                                                                                                                             ");
            sqlContent.Append("     AND kskt.KeiryoShomeiKekkaCd = sknm.SuishitsuKekkaNmCd                                                                                                                                          ");
            // WHERE
            sqlContent.Append("WHERE  ksit.KeiryoShomeiIraiNendo = @KeiryoShomeiIraiNendo                                                                                                                                           ");
            sqlContent.Append("       AND ksit.KeiryoShomeiIraiSishoCd = @KeiryoShomeiIraiSishoCd                                                                                                                                   ");
            sqlContent.Append("       AND ksit.KeiryoShomeiIraiRenban = @KeiryoShomeiIraiRenban                                                                                                                                     ");
            commandParams.Add("@KeiryoShomeiIraiSishoCd", SqlDbType.NVarChar).Value = keiryoShomeiIraiSishoCd;
            commandParams.Add("@KeiryoShomeiIraiNendo", SqlDbType.NVarChar).Value = keiryoShomeiIraiNendo;
            commandParams.Add("@KeiryoShomeiIraiRenban", SqlDbType.NVarChar).Value = keiryoShomeiIraiRenban;
            // SORTING
            sqlContent.Append("ORDER BY  Convert(INT,IsNull(sskm.InjiJyun,'999')) ASC                                                                                                                                                                         ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    partial class PrintKeriyoShomeiType2TableAdapter
    {
        #region GetPrintKeiryoShomeiType2ByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetKeiryoShomeiOutputListByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keiryoShomeiIraiSishoCd"></param>
        /// <param name="keiryoShomeiIraiNendo"></param>
        /// <param name="settisha"></param>     
        /// <param name="suikenNoFrom"></param>     
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable GetPrintKeiryoShomeiType2ByCond(
            string keiryoShomeiIraiSishoCd,
            string keiryoShomeiIraiNendo,
            string keiryoShomeiIraiRenban
            )
        {
            SqlCommand command = CreateSqlCommand(keiryoShomeiIraiSishoCd,
                                                  keiryoShomeiIraiNendo,
                                                  keiryoShomeiIraiRenban);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable dataTable = new KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable();
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
        /// <param name="keiryoShomeiIraiSishoCd"></param>
        /// <param name="keiryoShomeiIraiNendo"></param>
        /// <param name="settisha"></param>     
        /// <param name="suikenNoFrom"></param>     
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string keiryoShomeiIraiSishoCd,
            string keiryoShomeiIraiNendo,
            string keiryoShomeiIraiRenban
            )
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            // SELECT
            sqlContent.Append("SELECT                                                                                                                                                                                               ");
            sqlContent.Append("     jdm.JokasoSetchishaNm,                                                                                                                                                                          ");
            sqlContent.Append("     CONCAT(sm.ShishoNm, [dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiIraiNendo), '第', ksit.KeiryoShomeiIraiRenban, '号') AS 'ShishoNm',                                    ");
            sqlContent.Append("     CONCAT(ksit.KeiryoShomeiJokasoDaichoHokenjoCd , '-' , [dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiJokasoDaichoNendo), '-', ksit.KeiryoShomeiJokasoDaichoRenban) AS 'JokasoNo',         ");
            // 20150106 sou Start
            //sqlContent.Append("     CONCAT(sm.ShishoNm, '検査センター (福岡県登録 第',sm.ShishoKenTorokuNo,'号)') AS ShishoNmTorokuNo,                                                                                                ");
            sqlContent.Append("     CONCAT(sm.ShishoNm, '検査センター') AS ShishoNmTorokuNo,                                                                                                ");
            // 20150106 sou End
            sqlContent.Append("     sm.ShishoAdr,                                                                                                                                                                                   ");
            sqlContent.Append("     sm.ShishoTelNo,                                                                                                                                                                                 ");
            sqlContent.Append("     sm.ShishoKeiryoKanrisha,                                                                                                                                                                        ");
            sqlContent.Append("     jdm.JokasoSetchiBashoAdr,                                                                                                                                                                       ");
            sqlContent.Append("     CONCAT(shm.ShoriHoshikiShubetsuNm,' ', shm.ShoriHoshikiNm) AS 'ShoriHoshikiShubetsuNm',                                                                                                         ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiUketsukeDt,                                                                                                                                                                ");
            sqlContent.Append("     ksit.KeiryoShomeiShomeishoInsatsuCnt,                                                                                                                                                           ");
            sqlContent.Append("     hm.HokenjoNm,                                                                                                                                                                                   ");
            sqlContent.Append("     ksit.KeiryoShomeiNinsou,                                                                                                                                                                        ");
            sqlContent.Append("     ksit.KeiryoShomeiHiHeikinOsuiRyo,                                                                                                                                                               ");
            sqlContent.Append("     ssm.SuishitsuNm,                                                                                                                                                                                ");
            sqlContent.Append("     gm.GyoshaNm,                                                                                                                                                                                    ");
            sqlContent.Append("     sskm.SeishikiNm,                                                                                                                                                                                ");
            sqlContent.Append("     sskm.KeiryouHouhouNmUp,                                                                                                                                                                         ");
            sqlContent.Append("     sskm.KeiryouHouhouNmDown,                                                                                                                                                                       ");
            sqlContent.Append("     case                                                                                                                                                                                            ");
            // 20150131 sou Start
            //sqlContent.Append("     when kskt.KeiryoShomeiKekkaOndo <= 0 OR kskt.KeiryoShomeiKekkaOndo IS NULL then '' else CONCAT('(', kskt.KeiryoShomeiKekkaOndo, ')')                                                            ");
            sqlContent.Append("     when kskt.KeiryoShomeiKekkaOndo <= 0 OR kskt.KeiryoShomeiKekkaOndo IS NULL then '' else CONCAT(' (', kskt.KeiryoShomeiKekkaOndo, '℃)')                                                            ");
            // 20150131 sou End
            sqlContent.Append("     end as 'KeiryoShomeiKekkaOndo',                                                                                                                                                                 ");
            // 20150131 sou Start
            //sqlContent.Append("     CONCAT(kskt.KeiryoShomeiKekkaValueHyojiyo, sskm.Unit, sknm.SuishitsuKekkaNm,case when kskt.KeiryoShomeiKekkaOndo <= 0 OR kskt.KeiryoShomeiKekkaOndo = '' OR  kskt.KeiryoShomeiKekkaOndo IS NULL then ''  else CONCAT('(', kskt.KeiryoShomeiKekkaOndo, ')') END) AS 'BunsekiKekka',");	//結合20141227 "を出力"は不要。
            sqlContent.Append("     CONCAT(kskt.KeiryoShomeiKekkaValueHyojiyo, sskm.Unit, sknm.SuishitsuKekkaNm,case when kskt.KeiryoShomeiKekkaOndo <= 0 OR kskt.KeiryoShomeiKekkaOndo = '' OR  kskt.KeiryoShomeiKekkaOndo IS NULL then ''  else CONCAT(' (', kskt.KeiryoShomeiKekkaOndo, '℃)') END) AS 'BunsekiKekka',");	//結合20141227 "を出力"は不要。
            // 20150131 sou End
            sqlContent.Append("     ksit.KeiryoShomeiIraiUketsukeDt                                                                                                                                                                 ");            
            // FROM
            sqlContent.Append("FROM                                                                                                                                                                                                 ");
            sqlContent.Append("     KeiryoShomeiIraiTbl AS ksit                                                                                                                                                                     ");
            sqlContent.Append("     INNER JOIN JokasoDaichoMst AS jdm                                                                                                                                                               ");
            sqlContent.Append("     ON ksit.KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd                                                                                                                                 ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo                                                                                                                                  ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban                                                                                                                                      ");
            sqlContent.Append("     INNER JOIN KeiryoShomeiKekkaTbl AS kskt                                                                                                                                                         ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiNendo = kskt.KeiryoShomeiKekkaIraiNendo                                                                                                                                 ");
            sqlContent.Append("     AND ksit.KeiryoShomeiIraiSishoCd = kskt.KeiryoShomeiKekkaIraiShishoCd                                                                                                                           ");
            sqlContent.Append("     AND ksit.KeiryoShomeiIraiRenban = kskt.KeiryoShomeiKekkaIraiNo                                                                                                                                  ");
            // 20150131 sou Start
            //sqlContent.Append("     LEFT OUTER JOIN SuishitsuShikenKoumokuMst AS sskm                                                                                                                                               ");
            //sqlContent.Append("     ON kskt.KeiryoShomeiShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd                                                                                                                             ");
            sqlContent.Append("     INNER JOIN SuishitsuShikenKoumokuMst AS sskm ");
            sqlContent.Append("     ON kskt.KeiryoShomeiShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd ");
            sqlContent.Append("     AND '1' = sskm.InjiKbn ");
            // 20150131 sou End
            sqlContent.Append("     LEFT OUTER JOIN ShishoMst AS sm                                                                                                                                                                 ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiSishoCd = sm.ShishoCd                                                                                                                                                   ");
            sqlContent.Append("     LEFT OUTER JOIN ShoriHoshikiMst AS shm                                                                                                                                                          ");
            sqlContent.Append("     ON ksit.KeiryoShomeiShoriHousikiKbn = shm.ShoriHoshikiKbn                                                                                                                                       ");
            sqlContent.Append("     AND ksit.KeiryoShomeiShoriHousikiCd = shm.ShoriHoshikiCd                                                                                                                                        ");
            sqlContent.Append("     LEFT OUTER JOIN HokenjoMst AS hm                                                                                                                                                                ");
            sqlContent.Append("     ON ksit.KeiryoShomeiHokenjoCd = hm.HokenjoCd                                                                                                                                                    ");
            sqlContent.Append("     LEFT OUTER JOIN SuishitsuMst AS ssm                                                                                                                                                             ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiSishoCd = ssm.SuishitsuShishoCd                                                                                                                                         ");
            sqlContent.Append("     AND ksit.KeiryoShomeiSuisitsuCd = ssm.SuishitsuCd                                                                                                                                               ");
            sqlContent.Append("     LEFT OUTER JOIN GyoshaMst AS gm                                                                                                                                                                 ");
            sqlContent.Append("     ON ksit.KeiryoShomeiSaisuiGyoshaCd = gm.GyoshaCd                                                                                                                                                ");
            sqlContent.Append("     LEFT OUTER JOIN SuishitsuKekkaNmMst AS sknm                                                                                                                                                     ");
            // 20150106 sou Start
            //sqlContent.Append("     ON kskt.KeiryoShomeiKekkaCd = sknm.SuishitsuKekkaShishoCd                                                                                                                                       ");
            sqlContent.Append("     ON kskt.KeiryoShomeiKekkaIraiShishoCd = sknm.SuishitsuKekkaShishoCd                                                                                                                             ");
            sqlContent.Append("     AND kskt.KeiryoShomeiKekkaCd = sknm.SuishitsuKekkaNmCd                                                                                                                                          ");
            // 20150106 sou End
            // WHERE
            sqlContent.Append("WHERE  ksit.KeiryoShomeiIraiNendo = @KeiryoShomeiIraiNendo                                                                                                                                           ");
            sqlContent.Append("       AND ksit.KeiryoShomeiIraiSishoCd = @KeiryoShomeiIraiSishoCd                                                                                                                                   ");
            sqlContent.Append("       AND ksit.KeiryoShomeiIraiRenban = @KeiryoShomeiIraiRenban                                                                                                                                     ");
            commandParams.Add("@KeiryoShomeiIraiSishoCd", SqlDbType.NVarChar).Value = keiryoShomeiIraiSishoCd;
            commandParams.Add("@KeiryoShomeiIraiNendo", SqlDbType.NVarChar).Value = keiryoShomeiIraiNendo;
            commandParams.Add("@KeiryoShomeiIraiRenban", SqlDbType.NVarChar).Value = keiryoShomeiIraiRenban;                      
            // SORTING
            sqlContent.Append("ORDER BY  Convert(INT,IsNull(sskm.InjiJyun,'999')) ASC                                                                                                                                                                         ");
            
            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    partial class KeiryoShomeiOutputListTableAdapter
    {
        #region GetKeiryoShomeiOutputListByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetKeiryoShomeiOutputListByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keiryoShomeiIraiSishoCd"></param>
        /// <param name="keiryoShomeiIraiNendo"></param>
        /// <param name="settisha"></param>     
        /// <param name="suikenNoFrom"></param>     
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <param name="chouhyouKubunFlg"></param>
        /// <param name="dispOrder"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// 2015/02/01  宗         表示順を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable GetKeiryoShomeiOutputListByCond(
            string keiryoShomeiIraiSishoCd,
            string keiryoShomeiIraiNendo,
            string suikenNoFrom,
            string suikenNoTo,
            string settisha,
            string uketsukeDtFrom,
            string uketsukeDtTo,
            string chouhyouKubunFlg,
            string dispOrder
            )
        {
            SqlCommand command = CreateSqlCommand(keiryoShomeiIraiSishoCd,
                                                  keiryoShomeiIraiNendo,
                                                  suikenNoFrom,
                                                  suikenNoTo,
                                                  settisha,
                                                  uketsukeDtFrom,
                                                  uketsukeDtTo,
                                                  chouhyouKubunFlg,
                                                  dispOrder);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable dataTable = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable();
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
        /// <param name="keiryoShomeiIraiSishoCd"></param>
        /// <param name="keiryoShomeiIraiNendo"></param>
        /// <param name="settisha"></param>     
        /// <param name="suikenNoFrom"></param>     
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <param name="chouhyouKubunFlg"></param>
        /// <param name="dispOrder"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// 2015/02/01  宗         表示順を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string keiryoShomeiIraiSishoCd,
            string keiryoShomeiIraiNendo,
            string suikenNoFrom,
            string suikenNoTo,
            string settisha,
            string uketsukeDtFrom,
            string uketsukeDtTo,
            string chouhyouKubunFlg,
            string dispOrder
            )
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            // SELECT
            sqlContent.Append("SELECT                                                                                                                   ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiNendo,                                                                                         ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiSishoCd,                                                                                       ");
            sqlContent.Append("     sm.ShishoNm,                                                                                                        ");
            sqlContent.Append("     jdm.JokasoSetchishaNm,                                                                                              ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiRenban,                                                                                        ");
            sqlContent.Append("     CONVERT(varchar(10), CONVERT(date, ksit.KeiryoShomeiIraiUketsukeDt, 111),111) AS KeiryoShomeiIraiUketsukeDt,        ");
            sqlContent.Append("     ksit.KeiryoShomeiJokasoDaichoHokenjoCd,                                                                             ");
            sqlContent.Append("     ksit.KeiryoShomeiJokasoDaichoNendo,                                                                                 ");
            sqlContent.Append("     ksit.KeiryoShomeiJokasoDaichoRenban,                                                                                ");
            sqlContent.Append("     ksit.UpdateDt,                                                                                                      ");
            // Watting update DB
            sqlContent.Append("     ksit.KeiryoShomeiShomeishoInsatsuCnt,                                                                               ");
            sqlContent.Append("     CONCAT(ksit.KeiryoShomeiJokasoDaichoHokenjoCd , '-' , [dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiJokasoDaichoNendo), '-', ksit.KeiryoShomeiJokasoDaichoRenban) AS 'jokasoNoCol', ");
            // 20150201 sou Start
            sqlContent.Append("     ksit.KeiryoShomeiSeikyuGyoshaCd, ");
            sqlContent.Append("     gm.GyoshaNm ");
            // 20150201 sou End
            // FROM
            sqlContent.Append("FROM                                                                                                                     ");
            sqlContent.Append("     KeiryoShomeiIraiTbl AS ksit                                                                                         ");
            sqlContent.Append("     INNER JOIN ShishoMst sm                                                                                             ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiSishoCd = sm.ShishoCd                                                                       ");
            sqlContent.Append("     INNER JOIN JokasoDaichoMst AS jdm                                                                                   ");
            sqlContent.Append("     ON ksit.KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd                                                     ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo                                                      ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban                                                          ");
            // 20150201 sou Start
            sqlContent.Append("     LEFT OUTER JOIN GyoshaMst AS gm ");
            sqlContent.Append("     ON ksit.KeiryoShomeiSeikyuGyoshaCd = gm.GyoshaCd ");
            // 20150201 sou End
            // WHERE
            sqlContent.Append("WHERE  ksit.KeiryoShomeiStatusKbn >= '70'                                                                                ");
            sqlContent.Append("       AND ksit.KeiryoShomeiStatusKbn < '90'                                                                             ");
            sqlContent.Append("       AND ksit.KeiryoShomeiBunsekiKekkashoFlg = @KeiryoShomeiBunsekiKekkashoFlg                                         ");

            commandParams.Add("@KeiryoShomeiBunsekiKekkashoFlg", SqlDbType.NVarChar).Value = chouhyouKubunFlg;
            // 計量証明支所コード 
            if (!String.IsNullOrEmpty(keiryoShomeiIraiSishoCd))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiSishoCd = @KeiryoShomeiIraiSishoCd                                                         ");
                commandParams.Add("@KeiryoShomeiIraiSishoCd", SqlDbType.NVarChar).Value = keiryoShomeiIraiSishoCd;
            }
            // 計量証明検査依頼年度
            if (!String.IsNullOrEmpty(keiryoShomeiIraiNendo))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiNendo = @KeiryoShomeiIraiNendo                                                             ");
                commandParams.Add("@KeiryoShomeiIraiNendo", SqlDbType.NVarChar).Value = keiryoShomeiIraiNendo;
            }
            // 計量証明依頼連番
            if (!String.IsNullOrEmpty(suikenNoFrom))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiRenban >= @KeiryoShomeiIraiRenbanFrom                                                      ");
                commandParams.Add("@KeiryoShomeiIraiRenbanFrom", SqlDbType.NVarChar).Value = suikenNoFrom;
            }
            // 計量証明依頼連番
            if (!String.IsNullOrEmpty(suikenNoTo))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiRenban <= @KeiryoShomeiIraiRenbanTo                                                        ");
                commandParams.Add("@KeiryoShomeiIraiRenbanTo", SqlDbType.NVarChar).Value = suikenNoTo;
            }
            // 設置者氏名 
            if (!String.IsNullOrEmpty(settisha))
            {
                sqlContent.Append("AND  jdm.JokasoSetchishaNm LIKE @JokasoSetchishaNm                                                                   ");
                commandParams.Add("@JokasoSetchishaNm", SqlDbType.NVarChar).Value = String.Format("%{0}%", settisha);
            }
            // 計量証明依頼受付日
            if (!String.IsNullOrEmpty(uketsukeDtFrom) && !String.IsNullOrEmpty(uketsukeDtTo))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiUketsukeDt >= @KeiryoShomeiIraiUketsukeDtFrom                                              ");
                commandParams.Add("@KeiryoShomeiIraiUketsukeDtFrom", SqlDbType.NVarChar).Value = uketsukeDtFrom;
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiUketsukeDt <= @KeiryoShomeiIraiUketsukeDtTo                                                ");
                commandParams.Add("@KeiryoShomeiIraiUketsukeDtTo", SqlDbType.NVarChar).Value = uketsukeDtTo;
            }
            // SORTING
            // 20150201 sou Start
            //sqlContent.Append("ORDER BY  ksit.KeiryoShomeiIraiNendo ASC,                                                                                ");
            //sqlContent.Append("          ksit.KeiryoShomeiIraiSishoCd ASC,                                                                              ");
            //sqlContent.Append("          ksit.KeiryoShomeiIraiRenban ASC                                                                               ");
            if (dispOrder == "0")
            {
                // 受付番号順
                sqlContent.Append("ORDER BY  ksit.KeiryoShomeiIraiRenban ASC ");
            }
            else
            {
                // 業者順
                sqlContent.Append("ORDER BY  ksit.KeiryoShomeiSeikyuGyoshaCd ASC, ");
                sqlContent.Append("          ksit.KeiryoShomeiIraiRenban ASC ");
            }
            // 20150201 sou End

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    partial class GaichuKensaListTableAdapter
    {
        #region GetGaichuKensaByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetGaichuKensaByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="nendo"></param>
        /// <param name="suikenNoFrom"></param>
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable GetGaichuKensaByCond(
            string shishoCd,
            string nendo,
            string suikenNoFrom,
            string suikenNoTo,
            string uketsukeDtFrom,
            string uketsukeDtTo)
        {
            SqlCommand command = CreateSqlCommand(shishoCd, nendo, suikenNoFrom, suikenNoTo, uketsukeDtFrom, uketsukeDtTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable dataTable = new KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable();
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
        /// <param name="nendo"></param>
        /// <param name="suikenNoFrom"></param>
        /// <param name="suikenNoTo"></param>
        /// <param name="uketsukeDtFrom"></param>
        /// <param name="uketsukeDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string shishoCd,
            string nendo,
            string suikenNoFrom,
            string suikenNoTo,
            string uketsukeDtFrom,
            string uketsukeDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                       ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiNendo,                                                                             ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiSishoCd,                                                                           ");
            sqlContent.Append("     sm.ShishoNm,                                                                                            ");
            sqlContent.Append("     ksit.KeiryoShomeiIraiRenban,                                                                            ");
            sqlContent.Append("     CONVERT(varchar(10), CONVERT(date, ksit.KeiryoShomeiIraiUketsukeDt, 111),111) AS KeiryoShomeiIraiUketsukeDt, ");
            sqlContent.Append("     ksit.KeiryoShomeiJokasoDaichoHokenjoCd,                                                                 ");
            sqlContent.Append("     ksit.KeiryoShomeiJokasoDaichoNendo,                                                                     ");
            sqlContent.Append("     ksit.KeiryoShomeiJokasoDaichoRenban,                                                                    ");
            sqlContent.Append("     jdm.JokasoSetchishaNm,                                                                                  ");
            sqlContent.Append("     cm.ConstRenban,                                                                                         ");
            sqlContent.Append("     CONCAT(ksit.KeiryoShomeiJokasoDaichoHokenjoCd , '-' , [dbo].[FuncConvertIraiNedoToWareki](ksit.KeiryoShomeiJokasoDaichoNendo), '-', ksit.KeiryoShomeiJokasoDaichoRenban) AS 'jokasoNoCol',");
            sqlContent.Append("     'daichokinCol' =                                                                                        ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm1.ConstNm = '' OR cm1.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'codCol' =                                                                                              ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm2.ConstNm = '' OR cm2.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'tnCol' =                                                                                               ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm3.ConstNm = '' OR cm3.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'tpCol' =                                                                                               ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm4.ConstNm = '' OR cm4.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'yubunCol' =                                                                                            ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm5.ConstNm = '' OR cm5.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'yubunKouCol' =                                                                                         ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm6.ConstNm = '' OR cm6.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'yubunDouCol' =                                                                                         ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm7.ConstNm = '' OR cm7.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'mbasCol' =                                                                                             ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm8.ConstNm = '' OR cm8.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'znCol' =                                                                                               ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm9.ConstNm = '' OR cm9.ConstNm IS NULL then '' else '1'                                      ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'pbCol' =                                                                                               ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm10.ConstNm = '' OR cm10.ConstNm IS NULL then '' else '1'                                    ");
            sqlContent.Append("     end,                                                                                                    ");
            sqlContent.Append("     'fCol' =                                                                                                ");
            sqlContent.Append("     case                                                                                                    ");
            sqlContent.Append("         when  cm11.ConstNm = '' OR cm11.ConstNm IS NULL then '' else '1'                                    ");
            sqlContent.Append("     end                                                                                                     ");
            // FROM
            sqlContent.Append("FROM                                                                                                         ");
            sqlContent.Append("     KeiryoShomeiIraiTbl AS ksit                                                                             ");
            sqlContent.Append("     INNER JOIN  KeiryoShomeiKekkaTbl AS kskt                                                                ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiNendo = kskt.KeiryoShomeiKekkaIraiNendo                                         ");
            sqlContent.Append("     AND ksit.KeiryoShomeiIraiSishoCd = kskt.KeiryoShomeiKekkaIraiShishoCd                                   ");
            sqlContent.Append("     AND ksit.KeiryoShomeiIraiRenban = kskt.KeiryoShomeiKekkaIraiNo                                          ");
            sqlContent.Append("     INNER JOIN SuishitsuShikenKoumokuMst AS sskm                                                            ");
            sqlContent.Append("     ON kskt.KeiryoShomeiShikenkoumokuCd = sskm.SuishitsuShikenKoumokuCd                                     ");
            sqlContent.Append("     INNER JOIN ShishoMst AS sm                                                                              ");
            sqlContent.Append("     ON ksit.KeiryoShomeiIraiSishoCd = sm.ShishoCd                                                           ");
            sqlContent.Append("     INNER JOIN JokasoDaichoMst AS jdm                                                                       ");
            sqlContent.Append("     ON ksit.KeiryoShomeiJokasoDaichoHokenjoCd = jdm.JokasoHokenjoCd                                         ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoNendo = jdm.JokasoTorokuNendo                                          ");
            sqlContent.Append("     AND ksit.KeiryoShomeiJokasoDaichoRenban = jdm.JokasoRenban                                              ");
            //2014/12/19 Kiyokuni Start
            sqlContent.Append("     JOIN ConstMst cm                                                                             ");
            //2014/12/19 Kiyokuni End
            sqlContent.Append("     ON kskt.KeiryoShomeiShikenkoumokuCd = cm.ConstValue                                                     ");
            sqlContent.Append("     AND cm.ConstKbn = '060'                                                                                 ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm1                                                                            ");
            sqlContent.Append("     ON cm1.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            // 2014/12/18 AnhNV EDIT Start
            // Change ConstRenban to ConstValue
            //sqlContent.Append("     AND cm1.ConstKbn = '060' AND cm1.ConstRenban = '001'                                                    ");
            sqlContent.Append("     AND cm1.ConstKbn = '060' AND cm1.ConstValue = '085'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm2                                                                            ");
            sqlContent.Append("     ON cm2.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm2.ConstKbn = '060' AND cm2.ConstRenban = '002'                                                    ");
            sqlContent.Append("     AND cm2.ConstKbn = '060' AND cm2.ConstValue = '006'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm3                                                                            ");
            sqlContent.Append("     ON cm3.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm3.ConstKbn = '060' AND cm3.ConstRenban = '003'                                                    ");
            sqlContent.Append("     AND cm3.ConstKbn = '060' AND cm3.ConstValue = '009'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm4                                                                            ");
            sqlContent.Append("     ON cm4.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm4.ConstKbn = '060' AND cm4.ConstRenban = '004'                                                    ");
            sqlContent.Append("     AND cm4.ConstKbn = '060' AND cm4.ConstValue = '011'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm5                                                                            ");
            sqlContent.Append("     ON cm5.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm5.ConstKbn = '060' AND cm5.ConstRenban = '005'                                                    ");
            sqlContent.Append("     AND cm5.ConstKbn = '060' AND cm5.ConstValue = '007'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm6                                                                            ");
            sqlContent.Append("     ON cm6.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm6.ConstKbn = '060' AND cm6.ConstRenban = '006'                                                    ");
            sqlContent.Append("     AND cm6.ConstKbn = '060' AND cm6.ConstValue = '038'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm7                                                                            ");
            sqlContent.Append("     ON cm7.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm7.ConstKbn = '060' AND cm7.ConstRenban = '007'                                                    ");
            sqlContent.Append("     AND cm7.ConstKbn = '060' AND cm7.ConstValue = '039'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm8                                                                            ");
            sqlContent.Append("     ON cm8.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm8.ConstKbn = '060' AND cm8.ConstRenban = '008'                                                    ");
            sqlContent.Append("     AND cm8.ConstKbn = '060' AND cm8.ConstValue = '020'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm9                                                                            ");
            sqlContent.Append("     ON cm9.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                    ");
            //sqlContent.Append("     AND cm9.ConstKbn = '060' AND cm9.ConstRenban = '009'                                                    ");
            sqlContent.Append("     AND cm9.ConstKbn = '060' AND cm9.ConstValue = '057'                                                     ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm10                                                                           ");
            sqlContent.Append("     ON cm10.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                   ");
            //sqlContent.Append("     AND cm10.ConstKbn = '060' AND cm10.ConstRenban = '010'                                                  ");
            sqlContent.Append("     AND cm10.ConstKbn = '060' AND cm10.ConstValue = '052'                                                   ");
            sqlContent.Append("     LEFT OUTER JOIN ConstMst cm11                                                                           ");
            sqlContent.Append("     ON cm11.ConstValue = kskt.KeiryoShomeiShikenkoumokuCd                                                   ");
            //sqlContent.Append("     AND cm11.ConstKbn = '060' AND cm11.ConstRenban = '011'                                                  ");
            sqlContent.Append("     AND cm11.ConstKbn = '060' AND cm11.ConstValue = '060'                                                   ");
            // 2014/12/18 AnhNV EDIT End
            // WHERE
            sqlContent.Append("WHERE                                                                                                        ");
            sqlContent.Append("     ksit.KeiryoShomeiStatusKbn >= '50'                                                                      ");
            sqlContent.Append("AND  ksit.KeiryoShomeiStatusKbn < '90'                                                                       ");
            sqlContent.Append("AND  sskm.GaichuItakuKbn = '1'                                                                               ");
            sqlContent.Append("AND  kskt.KeiryoShomeiGaibuItakuFlg <> '1'                                                                   ");
            // 計量証明支所コード 
            if (!String.IsNullOrEmpty(shishoCd))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiSishoCd = @KeiryoShomeiIraiSishoCd                                             ");
                commandParams.Add("@KeiryoShomeiIraiSishoCd", SqlDbType.NVarChar).Value = shishoCd;
            }
            // 計量証明検査依頼年度
            if (!String.IsNullOrEmpty(nendo))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiNendo = @KeiryoShomeiIraiNendo                                                 ");
                commandParams.Add("@KeiryoShomeiIraiNendo", SqlDbType.NVarChar).Value = nendo;
            }
            // 計量証明依頼連番
            if (!String.IsNullOrEmpty(suikenNoFrom))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiRenban >= @KeiryoShomeiIraiRenbanFrom                                          ");
                commandParams.Add("@KeiryoShomeiIraiRenbanFrom", SqlDbType.NVarChar).Value = suikenNoFrom;
            }
            // 計量証明依頼連番
            if (!String.IsNullOrEmpty(suikenNoTo))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiRenban <= @KeiryoShomeiIraiRenbanTo                                            ");
                commandParams.Add("@KeiryoShomeiIraiRenbanTo", SqlDbType.NVarChar).Value = suikenNoTo;
            }
            // 計量証明依頼受付日
            if (!String.IsNullOrEmpty(uketsukeDtFrom) && !String.IsNullOrEmpty(uketsukeDtTo))
            {
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiUketsukeDt >= @KeiryoShomeiIraiUketsukeDtFrom                                  ");
                commandParams.Add("@KeiryoShomeiIraiUketsukeDtFrom", SqlDbType.NVarChar).Value = uketsukeDtFrom;
                sqlContent.Append("AND  ksit.KeiryoShomeiIraiUketsukeDt <= @KeiryoShomeiIraiUketsukeDtTo                                    ");
                commandParams.Add("@KeiryoShomeiIraiUketsukeDtTo", SqlDbType.NVarChar).Value = uketsukeDtTo;
            }
            // SORTING
            sqlContent.Append("ORDER BY  ksit.KeiryoShomeiIraiNendo ASC,                                                                    ");
            sqlContent.Append("          ksit.KeiryoShomeiIraiSishoCd ASC,                                                                  ");
            sqlContent.Append("          ksit.KeiryoShomeiIraiRenban ASC,                                                                   ");
            sqlContent.Append("          cm.ConstRenban ASC                                                                                 ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #region KensaKeihatsuSuishinhiSyukeiStep3TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKeihatsuSuishinhiSyukeiStep3TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKeihatsuSuishinhiSyukeiStep3TableAdapter
    {
        #region GetDataStep3
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataStep3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kaishiDt"></param>
        /// <param name="shuryoDt"></param>
        /// <param name="amount"></param>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep3DataTable GetDataStep3(
            string kaishiDt,
            string shuryoDt,
            decimal amount,
            string gyoshaCd)
        {
            SqlCommand command = CreateSqlCommand(kaishiDt, shuryoDt, amount, gyoshaCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep3DataTable dataTable = new KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep3DataTable();
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
        /// <param name="kaishiDt"></param>
        /// <param name="shuryoDt"></param>
        /// <param name="amount"></param>
        /// <param name="gyoshaCdList"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/10/16  DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kaishiDt,
            string shuryoDt,
            decimal amount,
            string gyoshaCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                       ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                                              ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban                                                              ");

            // FROM
            sqlContent.Append("FROM                                                                                                         ");
            sqlContent.Append("     KeiryoShomeiIraiTbl                                                                                     ");
            sqlContent.Append("INNER JOIN                                                                                                   ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl                                                                         ");
            sqlContent.Append("         ON KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd = KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd        ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                   ");

            //sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt " + DataAccessUtility.SetBetweenCommand(kaishiDt, shuryoDt, 8));

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt >= @kaishiDt ");
            commandParams.Add("@kaishiDt", SqlDbType.NVarChar).Value = kaishiDt;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt <= @shuryoDt ");
            commandParams.Add("@shuryoDt", SqlDbType.NVarChar).Value = shuryoDt;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiUketsukeKbn = '1'                                                        ");

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiKensaRyokin >= @amount                                                   ");
            commandParams.Add("@amount", SqlDbType.Money).Value = amount;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd = KeiryoShomeiIraiTbl.KeiryoShomeiMochikonmiGyoshaCd      ");

            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                               ");
            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd = @gyoshaCd                                                     ");
            commandParams.Add("@gyoshaCd", SqlDbType.NVarChar).Value = gyoshaCd;

            sqlContent.Append("AND                                                                                                          ");
            sqlContent.Append("     (   SELECT COUNT(*)                                                                                     ");
            sqlContent.Append("         FROM GyoshaBukaiMst                                                                                 ");
            sqlContent.Append("         WHERE ISNULL(BukaiNyukaiDt, '') <> '' AND ISNULL(BukaiTaikaiDt, '') = ''                            ");
            sqlContent.Append("                 AND GyoshaBukaiMst.BukaiGyoshaCd  = KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd          ");
            sqlContent.Append("     ) > 0                                                                                                   ");

            // 2014/10/16 DatNT v1.03 ADD Start
            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn >= '70' AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn < '90'   ");
            // 2014/10/16 DatNT v1.03 ADD End

            // GROUP BY
            sqlContent.Append("GROUP BY ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                                              ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban                                                              ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaKeihatsuSuishinhiSyukeiStep4TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKeihatsuSuishinhiSyukeiStep4TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKeihatsuSuishinhiSyukeiStep4TableAdapter
    {
        #region GetDataStep4
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataStep4
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kaishiDt"></param>
        /// <param name="shuryoDt"></param>
        /// <param name="amount"></param>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep4DataTable GetDataStep4(
            string kaishiDt,
            string shuryoDt,
            decimal amount,
            string gyoshaCd)
        {
            SqlCommand command = CreateSqlCommand(kaishiDt, shuryoDt, amount, gyoshaCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep4DataTable dataTable = new KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep4DataTable();
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
        /// <param name="kaishiDt"></param>
        /// <param name="shuryoDt"></param>
        /// <param name="amount"></param>
        /// <param name="gyoshaCdList"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/10/16  DatNT     v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kaishiDt,
            string shuryoDt,
            decimal amount,
            string gyoshaCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                       ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                                              ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban                                                              ");

            // FROM
            sqlContent.Append("FROM                                                                                                         ");
            sqlContent.Append("     KeiryoShomeiIraiTbl                                                                                     ");
            sqlContent.Append("INNER JOIN                                                                                                   ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl                                                                         ");
            sqlContent.Append("         ON KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd = KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd        ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                   ");

            //sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt " + DataAccessUtility.SetBetweenCommand(kaishiDt, shuryoDt, 8));

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt >= @kaishiDt ");
            commandParams.Add("@kaishiDt", SqlDbType.NVarChar).Value = kaishiDt;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt <= @shuryoDt ");
            commandParams.Add("@shuryoDt", SqlDbType.NVarChar).Value = shuryoDt;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiUketsukeKbn = '2'                                                        ");

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiKensaRyokin >= @amount                                                   ");
            commandParams.Add("@amount", SqlDbType.Money).Value = amount;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd <> KeiryoShomeiIraiTbl.KeiryoShomeiMochikonmiGyoshaCd     ");

            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '2'                                               ");
            sqlContent.Append("AND ISNULL(KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaCd, '') <> ''                                    ");

            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd = @gyoshaCd                                                     ");
            commandParams.Add("@gyoshaCd", SqlDbType.NVarChar).Value = gyoshaCd;

            sqlContent.Append("AND                                                                                                          ");
            sqlContent.Append("     (   SELECT COUNT(*)                                                                                     ");
            sqlContent.Append("         FROM GyoshaBukaiMst                                                                                 ");
            sqlContent.Append("         WHERE ISNULL(BukaiNyukaiDt, '') <> '' AND ISNULL(BukaiTaikaiDt, '') = ''                            ");
            sqlContent.Append("                 AND GyoshaBukaiMst.BukaiGyoshaCd  = KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd          ");
            sqlContent.Append("     ) > 0                                                                                                   ");

            // 2014/10/16 DatNT v1.03 ADD Start
            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn >= '70' AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn < '90'   ");
            // 2014/10/16 DatNT v1.03 ADD End

            // GROUP BY
            sqlContent.Append("GROUP BY                                                                                                     ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                                              ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban                                                              ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KensaKeihatsuSuishinhiSyukeiStep5TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKeihatsuSuishinhiSyukeiStep5TableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKeihatsuSuishinhiSyukeiStep5TableAdapter
    {
        #region GetDataStep5
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataStep5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kaishiDt"></param>
        /// <param name="shuryoDt"></param>
        /// <param name="amount"></param>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep5DataTable GetDataStep5(
            string kaishiDt,
            string shuryoDt,
            decimal amount,
            string gyoshaCd)
        {
            SqlCommand command = CreateSqlCommand(kaishiDt, shuryoDt, amount, gyoshaCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep5DataTable dataTable = new KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep5DataTable();
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
        /// <param name="kaishiDt"></param>
        /// <param name="shuryoDt"></param>
        /// <param name="amount"></param>
        /// <param name="gyoshaCdList"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/10/16  DatNT     v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kaishiDt,
            string shuryoDt,
            decimal amount,
            string gyoshaCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                       ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                                              ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban                                                              ");

            // FROM
            sqlContent.Append("FROM                                                                                                         ");
            sqlContent.Append("     KeiryoShomeiIraiTbl                                                                                     ");
            sqlContent.Append("INNER JOIN                                                                                                   ");
            sqlContent.Append("     KensaKeihatsuSuishinHiShukeiTbl                                                                         ");
            sqlContent.Append("         ON KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd = KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd        ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                        ");
            sqlContent.Append("     1 = 1                                                                                                   ");

            //sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt " + DataAccessUtility.SetBetweenCommand(kaishiDt, shuryoDt, 8));

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt >= @kaishiDt ");
            commandParams.Add("@kaishiDt", SqlDbType.NVarChar).Value = kaishiDt;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt <= @shuryoDt ");
            commandParams.Add("@shuryoDt", SqlDbType.NVarChar).Value = shuryoDt;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiUketsukeKbn = '2'                                                        ");

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiKensaRyokin >= @amount                                                   ");
            commandParams.Add("@amount", SqlDbType.Money).Value = amount;

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd <> KeiryoShomeiIraiTbl.KeiryoShomeiMochikonmiGyoshaCd     ");

            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd = KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd                ");

            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.ToriatsukaiGyoshaKbn = '1'                                               ");

            sqlContent.Append("AND KensaKeihatsuSuishinHiShukeiTbl.GyoshaCd = @gyoshaCd                                                     ");
            commandParams.Add("@gyoshaCd", SqlDbType.NVarChar).Value = gyoshaCd;

            sqlContent.Append("AND                                                                                                          ");
            sqlContent.Append("     (   SELECT COUNT(*)                                                                                     ");
            sqlContent.Append("         FROM GyoshaBukaiMst                                                                                 ");
            sqlContent.Append("         WHERE ISNULL(BukaiNyukaiDt, '') <> '' AND ISNULL(BukaiTaikaiDt, '') = ''                            ");
            sqlContent.Append("                 AND GyoshaBukaiMst.BukaiGyoshaCd  = KeiryoShomeiIraiTbl.KeiryoShomeiSaisuiGyoshaCd          ");
            sqlContent.Append("     ) > 0                                                                                                   ");

            // 2014/10/16 DatNT v1.03 ADD Start
            sqlContent.Append("AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn >= '70' AND KeiryoShomeiIraiTbl.KeiryoShomeiStatusKbn < '90'   ");
            // 2014/10/16 DatNT v1.03 ADD End

            // GROUP BY
            sqlContent.Append("GROUP BY ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                                              ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban                                                              ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region KeiryouShomeiIncompleteCountTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiryouShomeiIncompleteCountTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KeiryouShomeiIncompleteCountTableAdapter
    {
        #region CountKeiryouShomeiDailyReportIncomplete
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CountKeiryouShomeiDailyReportIncomplete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiKensaNenTsuki"></param>
        /// <param name="gyoshaCdFrom"></param>
        /// <param name="gyoshaCdTo"></param>
        /// <param name="shimeKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal int CountKeiryouShomeiDailyReportIncomplete(
            string kensaIraiKensaNenTsuki,
            string gyoshaCdFrom,
            string gyoshaCdTo,
            string shimeKbn)
        {
            SqlCommand command = CreateSqlCommand(kensaIraiKensaNenTsuki, gyoshaCdFrom, gyoshaCdTo, shimeKbn);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.KeiryouShomeiIncompleteCountDataTable dataTable = new KeiryoShomeiIraiTblDataSet.KeiryouShomeiIncompleteCountDataTable();
            adpt.Fill(dataTable);

            return Convert.ToInt32(dataTable[0].KeiryoShomeiIncompleteCount);
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
        /// <param name="shimeKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  DatNT　  新規作成
        /// 2014/12/10  kiyokuni　  Ver1.07 完了フラグの変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kensaIraiKensaNenTsuki,
            string gyoshaCdFrom,
            string gyoshaCdTo,
            string shimeKbn)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     COUNT(*) AS KeiryoShomeiIncompleteCount                                                             ");

            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     KeiryoShomeiIraiTbl                                                                                 ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");
            
            sqlContent.Append("     AND KeiryoShomeiSuishitsuNippoKbn < '1'                                                             ");
            sqlContent.Append("     AND SUBSTRING(KeiryoShomeiIraiUketsukeDt,1,6) = '" + kensaIraiKensaNenTsuki + "'                                                             ");

            if (!string.IsNullOrEmpty(gyoshaCdFrom) || !string.IsNullOrEmpty(gyoshaCdTo))
            {
                if (!string.IsNullOrEmpty(gyoshaCdFrom) && string.IsNullOrEmpty(gyoshaCdTo))
                {
                    sqlContent.Append("AND KeiryoShomeiSeikyuGyoshaCd >= '" + gyoshaCdFrom + "'                                         ");
                }
                else if (string.IsNullOrEmpty(gyoshaCdFrom) && !string.IsNullOrEmpty(gyoshaCdTo))
                {
                    sqlContent.Append("AND KeiryoShomeiSeikyuGyoshaCd <= '" + gyoshaCdTo + "'                                           ");
                }
                else
                {
                    sqlContent.Append("AND KeiryoShomeiSeikyuGyoshaCd >= '" + gyoshaCdFrom + "'                                         ");
                    sqlContent.Append("AND KeiryoShomeiSeikyuGyoshaCd <= '" + gyoshaCdTo + "'                                           ");
                }
            }

            if (shimeKbn == "1")
            {
                sqlContent.Append("AND KeiryoShomeiIraiSishoCd = '1'                                                                    ");
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region JinendoGaikanKensaYoteiListOutput6TableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanKensaYoteiListOutput6TableAdapter
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
    partial class JinendoGaikanKensaYoteiListOutput6TableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
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
        internal KeiryoShomeiIraiTblDataSet.JinendoGaikanKensaYoteiListOutput6DataTable GetDataBySearchCond(
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string nendo)
        {
            SqlCommand command = CreateSqlCommand(jokasoHokenjoCd, jokasoTorokuNendo, jokasoRenban, nendo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KeiryoShomeiIraiTblDataSet.JinendoGaikanKensaYoteiListOutput6DataTable dataTable = new KeiryoShomeiIraiTblDataSet.JinendoGaikanKensaYoteiListOutput6DataTable();
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
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string nendo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // TODO 平成1ケタの場合に正常に動作しない(今後発生することは無いだろうが、、、)
            string uketsukeDtFrom = (Convert.ToInt32(nendo) - 2) + "0401";
            string uketsukeDtTo = Convert.ToInt32(nendo) + "0331";

            #region SELECT

            sqlContent.Append("SELECT                                                                                                                       ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiNendo,                                                                              ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiSishoCd,                                                                            ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiRenban,                                                                             ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiSeikyuGyoshaCd,                                                                         ");
            sqlContent.Append("     KeiryoShomeiIraiTbl.KeiryoShomeiIraiUketsukeDt,                                                                         ");
            sqlContent.Append("     GyoshaMst.GyoshaNm                                                                                                      ");

            #endregion

            #region FROM

            sqlContent.Append("FROM                                                                                                                         ");
            sqlContent.Append("     KeiryoShomeiIraiTbl                                                                                                     ");
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
            sqlContent.Append("         WHERE KeiryoShomeiJokasoDaichoHokenjoCd = @jokasoHokenjoCd                                                          ");
            sqlContent.Append("                 AND KeiryoShomeiJokasoDaichoNendo = @jokasoTorokuNendo                                                      ");
            sqlContent.Append("                 AND KeiryoShomeiJokasoDaichoRenban = @jokasoRenban                                                          ");
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
}
