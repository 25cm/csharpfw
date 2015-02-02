using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ComponentModel;

namespace FukjBizSystem.Application.DataSet.GaikanKensa
{
    public partial class KensaHoryuDataSet
    {

    }
}

namespace FukjBizSystem.Application.DataSet.GaikanKensa.KensaHoryuDataSetTableAdapters
{
    #region KensaHoryuListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaHoryuListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　AnhNV　　 新規作成
    /// 2014/12/08　habu　　 Moved from KensaIraiTblDataSet
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class KensaHoryuListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yokaiFrom"></param>
        /// <param name="yokaiTo"></param>
        /// <param name="taishoKbn"></param>
        /// <param name="shokuiinCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal KensaHoryuDataSet.KensaHoryuListDataTable GetDataBySearchCond(KensaIraiTblSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            KensaHoryuDataSet.KensaHoryuListDataTable dataTable = new KensaHoryuDataSet.KensaHoryuListDataTable();
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
        /// 2014/08/29　AnhNV　　 新規作成
        /// 2014/10/08　AnhNV　　    基本設計書_009_008_画面_KensaHoryuList.Ver1.03
        /// 2014/11/24　AnhNV　　    チケット8051対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(KensaIraiTblSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append(" select                                                                                                                                                                              ");
            sqlContent.Append("     row_number() over (order by kit.KensaIraiHokenjoCd) as RowNum,                                                                                                                  ");
            sqlContent.Append("     kit.KensaIraiHokenjoCd,                                                                                                                                                         ");
            sqlContent.Append("     kit.KensaIraiHoteiKbn,                                                                                                                                                          ");
            //sqlContent.Append("     [dbo].[FuncConvertToWareki](kit.KensaIraiNendo, 'yy', 1),                                                                                                                     ");
            sqlContent.Append("     [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo) as KensaIraiNendo,                                                                                                      ");
            sqlContent.Append("     kit.KensaIraiRenban,                                                                                                                                                            ");
            //sqlContent.Append("     concat(concat(concat(concat(kit.KensaIraiHokenjoCd, '-'), [dbo].[FuncConvertToWareki](kit.KensaIraiNendo, 'yy', 1)), '-'), kit.KensaIraiRenban) as KyokaiNo,                  ");
            sqlContent.Append("     concat(concat(concat(concat(kit.KensaIraiHokenjoCd, '-'), [dbo].[FuncConvertIraiNedoToWareki](kit.KensaIraiNendo)), '-'), kit.KensaIraiRenban) as KyokaiNo,                     ");
            sqlContent.Append("     kit.KensaIraiSetchishaNm,                                                                                                                                                       ");
            sqlContent.Append("     kit.KensaIraiKensaSekininsha,                                                                                                                                                   ");
            sqlContent.Append("     kit.KensaIraiKensaTantoshaCd,                                                                                                                                                   ");
            sqlContent.Append("     sm.ShokuinNm,                                                                                                                                                                   ");
            sqlContent.Append("     kit.KensaIraiHoryuKbn,                                                                                                                                                          ");
            sqlContent.Append("     cm.ConstNm,                                                                                                                                                                     ");
            sqlContent.Append("     kit.KensaIraiHoryuRiyu,                                                                                                                                                         ");
            sqlContent.Append("     (case                                                                                                                                                                           ");
            sqlContent.Append("      when isdate(kit.KensaIrai7joHoryuKakuninDt)=0                                                                                                                                  ");
            sqlContent.Append("      then ''                                                                                                                                                                        ");
            sqlContent.Append("      else convert(char(10), convert(datetime,kit.KensaIrai7joHoryuKakuninDt), 111)                                                                                                  ");
            sqlContent.Append("      end                                                                                                                                                                            ");
            sqlContent.Append("     ) as KensaIrai7joHoryuKakuninDt,                                                                                                                                                ");
            sqlContent.Append("     (case                                                                                                                                                                           ");
            sqlContent.Append("      when isdate(kit.KensaIraiJikaiKakuninYoteiDt)=0                                                                                                                                ");
            sqlContent.Append("      then ''                                                                                                                                                                        ");
            sqlContent.Append("      else convert(char(10), convert(datetime,kit.KensaIraiJikaiKakuninYoteiDt), 111)                                                                                                ");
            sqlContent.Append("      end                                                                                                                                                                            ");
            sqlContent.Append("     ) as KensaIraiJikaiKakuninYoteiDt,                                                                                                                                              ");
            sqlContent.Append("     (case                                                                                                                                                                           ");
            sqlContent.Append("      when isnull(KensaIraiJikaiKakuninYoteiDt, '') = '' then ''                                                                                                                     ");
            sqlContent.Append("      when convert(char(8), convert(date, CURRENT_TIMESTAMP), 112) >= KensaIraiJikaiKakuninYoteiDt                                                                                   ");
            sqlContent.Append("      then '1'                                                                                                                                                                       ");
            sqlContent.Append("      else '0'                                                                                                                                                                       ");
            sqlContent.Append("      end                                                                                                                                                                            ");
            sqlContent.Append("     ) as Color,                                                                                                                                                                     ");
            sqlContent.Append("     '' as GenkyoHokoku,                                                                                                                                                             ");
            sqlContent.Append("     '' as JokyoHaaku,                                                                                                                                                               ");
            sqlContent.Append("     (select ConstValue from ConstMst where ConstKbn = '010' and ConstRenban = '002') as GenkyoHokokuPath,                                                                           ");
            sqlContent.Append("     (select ConstValue from ConstMst where ConstKbn = '010' and ConstRenban = '002') as JokyoHaakuPath                                                                              ");
            sqlContent.Append(" from KensaIraiTbl kit                                                                                                                                                               ");
            sqlContent.Append(" left outer join ShokuinMst sm                                                                                                                                                       ");
            sqlContent.Append("     on kit.KensaIraiKensaTantoshaCd = sm.ShokuinCd                                                                                                                                  ");
            sqlContent.Append(" left outer join ConstMst cm                                                                                                                                                         ");
            sqlContent.Append("     on kit.KensaIraiHoryuKbn = cm.ConstValue                                                                                                                                        ");
            sqlContent.Append("     and cm.ConstKbn = '009'                                                                                                                                                         ");

            // WHERE
            sqlContent.Append(" where                                                                                                                                                                               ");
            sqlContent.Append("     kit.KensaIraiHoteiKbn = '1'                                                                                                                                                     ");
            //sqlContent.Append("     and isnull(kit.KensaIraiHoryuTorikeshiDt, '') = ''                                                                                                                            ");

            // 支所(5)
            if (!string.IsNullOrEmpty(searchCond.ShishoCd))
            {
                sqlContent.Append(" and kit.KensaIraiUketsukeShishoKbn = @KensaIraiUketsukeShishoKbn                                                                                                                ");
                commandParams.Add("@KensaIraiUketsukeShishoKbn", SqlDbType.VarChar).Value = (string)searchCond.ShishoCd;
            }

            // 保健所コード（開始）~ （終了）
            //sqlContent.Append("     and kit.KensaIraiHokenjoCd                                                                                                                                                      ");
            //sqlContent.Append(DataAccessUtility.SetBetweenCommand(searchCond.HokenjoCdFrom, searchCond.HokenjoCdTo, 2));
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdFrom))
            {
                sqlContent.Append(" AND kit.KensaIraiHokenjoCd >= @HokenjoCdFrom ");
                commandParams.Add("@HokenjoCdFrom", SqlDbType.NVarChar).Value = searchCond.HokenjoCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.HokenjoCdTo))
            {
                sqlContent.Append(" AND kit.KensaIraiHokenjoCd <= @HokenjoCdTo ");
                commandParams.Add("@HokenjoCdTo", SqlDbType.NVarChar).Value = searchCond.HokenjoCdTo;
            }

            // 年度（開始）~ （終了）
            //MOD_20141117_HuyTX Start
            //sqlContent.Append("     and (kit.KensaIraiNendo - (SELECT TOP(1) CAST(SUBSTRING(KaishiDt, 0, 5) AS INT) - 1 FROM WarekiMst WHERE KaishiDt <= CONCAT(kit.KensaIraiNendo, '01', '01') ORDER BY KaishiDt DESC)) ");
            //sqlContent.Append(DataAccessUtility.SetBetweenCommand(searchCond.NendoFrom, searchCond.NendoTo, 2));

            string nendoFrom = !string.IsNullOrEmpty(searchCond.NendoFrom) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoFrom, "yyyy") : string.Empty;
            string nendoTo = !string.IsNullOrEmpty(searchCond.NendoTo) ? Utility.DateUtility.ConvertFromWareki(searchCond.NendoTo, "yyyy") : string.Empty;
            //sqlContent.Append("     and kit.KensaIraiNendo ");
            //sqlContent.Append(DataAccessUtility.SetBetweenCommand(nendoFrom, nendoTo, 4));
            if (!string.IsNullOrEmpty(nendoFrom))
            {
                sqlContent.Append(" AND kit.KensaIraiNendo >= @nendoFrom ");
                commandParams.Add("@nendoFrom", SqlDbType.NVarChar).Value = nendoFrom;
            }
            if (!string.IsNullOrEmpty(nendoTo))
            {
                sqlContent.Append(" AND kit.KensaIraiNendo <= @nendoTo ");
                commandParams.Add("@nendoTo", SqlDbType.NVarChar).Value = nendoTo;
            }

            //MOD_20141117_HuyTX End
            // 連番（開始）~（終了）
            //sqlContent.Append("     and kit.KensaIraiRenban                                                                                                     ");
            //sqlContent.Append(DataAccessUtility.SetBetweenCommand(searchCond.RenbanFrom, searchCond.RenbanTo, 6));
            if (!string.IsNullOrEmpty(searchCond.RenbanFrom))
            {
                sqlContent.Append(" AND kit.KensaIraiRenban >= @RenbanFrom ");
                commandParams.Add("@RenbanFrom", SqlDbType.NVarChar).Value = searchCond.RenbanFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.RenbanTo))
            {
                sqlContent.Append(" AND kit.KensaIraiRenban <= @RenbanTo ");
                commandParams.Add("@RenbanTo", SqlDbType.NVarChar).Value = searchCond.RenbanTo;
            }

            // 検査員
            if (!string.IsNullOrEmpty(searchCond.KensaIraiKensaSekininsha))
            {
                sqlContent.Append(" and kit.KensaIraiKensaTantoshaCd = @KensaIraiKensaTantoshaCd                                                                ");
                commandParams.Add("@KensaIraiKensaTantoshaCd", SqlDbType.VarChar).Value = (string)searchCond.KensaIraiKensaSekininsha;
            }

            // 対象区分 保留入力済(3) is on?
            if (!string.IsNullOrEmpty(searchCond.KensaIraiHoryuKbn))
            {
                sqlContent.Append(" and kit.KensaIraiStatusKbn = '90'                                                                                           ");
            }
            else // 対象区分 検査未実施全件(4) is on
            {
                // 20141209 habu varchar column had better to compared to varchar value
                sqlContent.Append(" and (kit.KensaIraiStatusKbn = '90' or kit.KensaIraiStatusKbn < '50')                                                          ");
                //sqlContent.Append(" and (kit.KensaIraiStatusKbn = '90' or kit.KensaIraiStatusKbn < 50)                                                          ");
            }

            // ORDER
            sqlContent.Append(" order by                                                                                                                        ");
            sqlContent.Append("     kit.KensaIraiHokenjoCd,                                                                                                     ");
            sqlContent.Append("     kit.KensaIraiNendo,                                                                                                         ");
            sqlContent.Append("     kit.KensaIraiRenban                                                                                                         ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
