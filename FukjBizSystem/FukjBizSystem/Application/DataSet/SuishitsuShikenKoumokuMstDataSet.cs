using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class SuishitsuShikenKoumokuMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuShikenKoumokuMstDataSetTableAdapters
{


    #region SuishitsuShikenKoumokuMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuShikenKoumokuMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuShikenKoumokuMstKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="suishitsuShikenKoumokuCdFrom"></param>
        /// <param name="suishitsuShikenKoumokuCdTo"></param>
        /// <param name="seishikiNm"></param>
        /// <param name="ryakushikiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstKensakuDataTable GetDataBySearchCond
            (
                string suishitsuShikenKoumokuCdFrom,
                string suishitsuShikenKoumokuCdTo,
                string seishikiNm,
                string ryakushikiNm
            )
        {
            SqlCommand command = CreateSqlCommand(suishitsuShikenKoumokuCdFrom, suishitsuShikenKoumokuCdTo, seishikiNm, ryakushikiNm);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstKensakuDataTable dataTable = 
                new SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstKensakuDataTable();
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
        /// <param name="suishitsuShikenKoumokuCdFrom"></param>
        /// <param name="suishitsuShikenKoumokuCdTo"></param>
        /// <param name="seishikiNm"></param>
        /// <param name="ryakushikiNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　 新規作成
        /// 2015/01/26  DatNT     v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand
            (
                string suishitsuShikenKoumokuCdFrom,
                string suishitsuShikenKoumokuCdTo,
                string seishikiNm,
                string ryakushikiNm
            )
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append(" select                                                                                                                          ");
            sqlContent.Append("     sskm.SuishitsuShikenKoumokuCd,                                                                                              ");
            sqlContent.Append("     sskm.SeishikiNm,                                                                                                            ");
            sqlContent.Append("     sskm.RyakushikiNm,                                                                                                          ");
            sqlContent.Append("     sskm.KeiryouHouhouNmUp,                                                                                                     ");
            sqlContent.Append("     sskm.KeiryouHouhouNmDown,                                                                                                   ");
            sqlContent.Append("     sskm.SuishitsuShikenKomokuAmt,                                                                                              ");
            sqlContent.Append("     sskm.ShosubuKetasu,                                                                                                         ");
            sqlContent.Append("     sskm.ZeroHyojiKbn,                                                                                                          ");
            sqlContent.Append("     sskm.InjiKbn,                                                                                                               ");
            sqlContent.Append("     sskm.YukoKetasu,                                                                                                            ");
            sqlContent.Append("     sskm.KekkaNyuryokuShoryakuKbn,                                                                                              ");
            sqlContent.Append("     sskm.InjiJyun,                                                                                                              ");
            sqlContent.Append("     sskm.GaichuItakuKbn,                                                                                                        ");
            sqlContent.Append("     sskm.Unit,                                                                                                                  ");
            sqlContent.Append("     sskm.TeiryoKagenchi1,                                                                                                       ");
            sqlContent.Append("     (case when sskm.TeiryoHyojiyo1 is null then '' else ltrim(rtrim(sskm.TeiryoHyojiyo1)) end) as TeiryoHyojiyo1,               ");
            sqlContent.Append("     sskm.TeiryoKagenchi2,                                                                                                       ");
            sqlContent.Append("     (case when sskm.TeiryoHyojiyo2 is null then '' else ltrim(rtrim(sskm.TeiryoHyojiyo2)) end) as TeiryoHyojiyo2,               ");
            // 2015/01/26 DatNT v1.01 ADD Start
            sqlContent.Append("     sskm.KeiryoshomeiHakkoFlg                                                                                                   ");
            // 2015/01/26 DatNT v1.01 ADD End
            sqlContent.Append(" from SuishitsuShikenKoumokuMst sskm                                                                                             ");
            sqlContent.Append(" where 1 = 1                                                                                                                     ");

            // 水質試験項目コードFROM ~ TO
            if (!string.IsNullOrEmpty(suishitsuShikenKoumokuCdFrom))
            {
                sqlContent.Append(" and sskm.SuishitsuShikenKoumokuCd >= @suishitsuShikenKoumokuCdFrom ");
                commandParams.Add("@suishitsuShikenKoumokuCdFrom", System.Data.SqlDbType.NVarChar).Value = suishitsuShikenKoumokuCdFrom;
            }

            if (!string.IsNullOrEmpty(suishitsuShikenKoumokuCdTo))
            {
                sqlContent.Append(" and sskm.SuishitsuShikenKoumokuCd <= @suishitsuShikenKoumokuCdTo ");
                commandParams.Add("@suishitsuShikenKoumokuCdTo", System.Data.SqlDbType.NVarChar).Value = suishitsuShikenKoumokuCdTo;
            }

            if (!string.IsNullOrEmpty(seishikiNm))
            {
                // 正式名称
                sqlContent.Append(" and sskm.SeishikiNm like concat('%', @seishikiNm, '%')");
                commandParams.Add("@seishikiNm", System.Data.SqlDbType.VarChar).Value = seishikiNm;
            }

            if (!string.IsNullOrEmpty(ryakushikiNm))
            {
                // 略式名称
                sqlContent.Append(" and sskm.RyakushikiNm like concat('%', @ryakushikiNm, '%')");
                commandParams.Add("@ryakushikiNm", System.Data.SqlDbType.VarChar).Value = ryakushikiNm;
            }

            // ORDER BY
            sqlContent.Append(" order by sskm.SuishitsuShikenKoumokuCd                                  ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
