using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class NyukinTblDataSet {
    }

    #region NyukinKensakuSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： NyukinKensakuSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class NyukinKensakuSearchCond
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string NyukinShisyoCd { get; set; }

        /// <summary>
        /// 業者コードFROM
        /// </summary>
        public string NyukinGyosyaCdFrom { get; set; }

        /// <summary>
        /// 業者コードTO
        /// </summary>
        public string NyukinGyosyaCdTo { get; set; }

        /// <summary>
        /// 入金者名称
        /// </summary>
        public string NyukinsyaNm { get; set; }

        /// <summary>
        /// 入金日FROM
        /// </summary>
        public string NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日TO
        /// </summary>
        public string NyukinDtTo { get; set; }

        /// <summary>
        /// 追加条件
        /// </summary>
        public string TsuikaJoken { get; set; }

        /// <summary>
        /// 入金種別
        /// </summary>
        public List<string> NyukinSyubetsu { get; set; }

        /// <summary>
        /// 入金方法
        /// </summary>
        public List<string> NyukinHoho { get; set; }
    }
    #endregion
}

namespace FukjBizSystem.Application.DataSet.NyukinTblDataSetTableAdapters
{

    #region NyukinListKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： NyukinListKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class NyukinListKensakuTableAdapter
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
        /// 2014/09/15　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal NyukinTblDataSet.NyukinListKensakuDataTable GetDataBySearchCond(NyukinKensakuSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            NyukinTblDataSet.NyukinListKensakuDataTable dataTable = new NyukinTblDataSet.NyukinListKensakuDataTable();
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
        /// 2014/09/15　AnhNV　　 新規作成
        /// 2015/01/16　AnhNV　　 v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(NyukinKensakuSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.AppendLine(" select                                                                                                                          ");
            sqlContent.AppendLine("     nt.NyukinNo,                                                                                                                ");
            sqlContent.AppendLine("     sm.ShishoNm,                                                                                                                ");
            sqlContent.AppendLine("     nt.NyukinGyosyaCd,                                                                                                          ");
            sqlContent.AppendLine("     nt.NyukinsyaNm,                                                                                                             ");
            sqlContent.AppendLine("     cm1.ConstNm as Syubetsu,                                                                                                    ");
            sqlContent.AppendLine("     case                                                                                                                        ");
            sqlContent.AppendLine("         when isdate(nt.NyukinDt) = 0  then ''                                                                                   ");
            sqlContent.AppendLine("         else convert(char(10), convert(datetime, nt.NyukinDt), 111)                                                             ");
            sqlContent.AppendLine("     end as NyukinDt,                                                                                                            ");
            sqlContent.AppendLine("     cm2.ConstValue as NyukinHoho,                                                                                               ");
            sqlContent.AppendLine("     nt.NyukinKoza,                                                                                                              ");
            sqlContent.AppendLine("     nt.SeikyuGaku,                                                                                                              ");
            //2015.01.07 mod 仕様変更 kiyokuni start
            sqlContent.AppendLine("     nt.WarifuriGaku as JitsuNyukinGaku,                                                                                         ");
            sqlContent.AppendLine("     nt.SeikyuGaku - nt.WarifuriGaku as Sagaku,                                                                                  ");
            //sqlContent.AppendLine("     nt.JitsuNyukinGaku,                                                                                                         ");
            //sqlContent.AppendLine("     nt.SeikyuGaku - nt.JitsuNyukinGaku as Sagaku,                                                                               ");
            //2015.01.07 mod 仕様変更 kiyokuni end
            sqlContent.AppendLine("     case                                                                                                                        ");
            sqlContent.AppendLine("         when nt.WarifuriFlg = '0' then '未'                                                                                     ");
            sqlContent.AppendLine("         when nt.WarifuriFlg = '1' then '済'                                                                                     ");
            sqlContent.AppendLine("     end as WarifuriFlg,                                                                                                         ");
            sqlContent.AppendLine("     nt.JikaiKurikoshiKin,                                                                                                       ");
            sqlContent.AppendLine("     nt.HenkinGaku,                                                                                                              ");
            // 2015/01/16 AnhNV ADD v1.04 Start
            sqlContent.AppendLine("     nt.NyukinSyubetsu                                                                                                           ");
            // 2015/01/16 AnhNV ADD v1.04 End
            sqlContent.AppendLine(" from NyukinTbl nt                                                                                                               ");
            sqlContent.AppendLine(" left outer join ShishoMst sm                                                                                                    ");
            sqlContent.AppendLine("     on nt.NyukinShisyoCd = sm.ShishoCd                                                                                          ");
            sqlContent.AppendLine(" left outer join ConstMst cm1                                                                                                    ");
            sqlContent.AppendLine("     on nt.NyukinSyubetsu = cm1.ConstValue                                                                                       ");
            sqlContent.AppendLine("     and cm1.ConstKbn = '032'                                                                                                    ");
            sqlContent.AppendLine(" left outer join ConstMst cm2                                                                                                    ");
            sqlContent.AppendLine("     on nt.NyukinHoho = cm2.ConstRenban                                                                                          ");
            sqlContent.AppendLine("     and cm2.ConstKbn = '002'                                                                                                    ");
            // WHERE
            sqlContent.AppendLine(" where 1 = 1                                                                                                                     ");

            // 業者コード（開始）, 業者コード（終了）
            //sqlContent.AppendLine("     nt.NyukinGyosyaCd " + DataAccessUtility.SetBetweenCommand(searchCond.NyukinGyosyaCdFrom, searchCond.NyukinGyosyaCdTo, 4));
            if (!string.IsNullOrEmpty(searchCond.NyukinGyosyaCdFrom))
            {
                sqlContent.AppendLine(" AND nt.NyukinGyosyaCd >= @NyukinGyosyaCdFrom ");
                commandParams.Add("@NyukinGyosyaCdFrom", SqlDbType.NVarChar).Value = searchCond.NyukinGyosyaCdFrom;
            }
            if (!string.IsNullOrEmpty(searchCond.NyukinGyosyaCdTo))
            {
                sqlContent.AppendLine(" AND nt.NyukinGyosyaCd <= @NyukinGyosyaCdTo ");
                commandParams.Add("@NyukinGyosyaCdTo", SqlDbType.NVarChar).Value = searchCond.NyukinGyosyaCdTo;
            }

            // 支所(3)
            if (!string.IsNullOrEmpty(searchCond.NyukinShisyoCd))
            {
                sqlContent.AppendLine(" and nt.NyukinShisyoCd = @NyukinShisyoCd                                                                                     ");
                commandParams.Add("@NyukinShisyoCd", SqlDbType.NVarChar).Value = (string)searchCond.NyukinShisyoCd;
            }

            // 名称(6)
            if (!string.IsNullOrEmpty(searchCond.NyukinsyaNm))
            {
                sqlContent.AppendLine(" and nt.NyukinsyaNm like concat('%', @NyukinsyaNm, '%')                                                                      ");
                commandParams.Add("@NyukinsyaNm", SqlDbType.NVarChar).Value = DataAccessUtility.EscapeSQLString(searchCond.NyukinsyaNm);
            }

            // 入金種別
            sqlContent.AppendLine(" and nt.NyukinSyubetsu " + GenerateInSql(searchCond.NyukinSyubetsu));

            // 入金方法
            sqlContent.AppendLine(" and nt.NyukinHoho " + GenerateInSql(searchCond.NyukinHoho));

            // 入金日
            if (!string.IsNullOrEmpty(searchCond.NyukinDtFrom) && !string.IsNullOrEmpty(searchCond.NyukinDtTo))
            {
                sqlContent.AppendLine(" and nt.NyukinDt between @NyukinDtFrom and @NyukinDtTo                                                                       ");
                commandParams.Add("@NyukinDtFrom", SqlDbType.NVarChar).Value = (string)searchCond.NyukinDtFrom;
                commandParams.Add("@NyukinDtTo", SqlDbType.NVarChar).Value = (string)searchCond.NyukinDtTo;
            }

            // 追加条件
            switch (searchCond.TsuikaJoken)
            {
                case "1": // 割振残あり(19)
                    sqlContent.AppendLine(" and nt.WarifuriFlg <> 1                                                                                                 ");
                    break;
                case "2": // 繰越し金あり(20)
                    sqlContent.AppendLine(" and nt.JikaiKurikoshiKin > 0                                                                                            ");
                    break;
                case "3": // 返金あり(21)
                    sqlContent.AppendLine(" and nt.HenkinGaku > 0                                                                                                   ");
                    break;
                default:
                    break;
            }

            // ORDER
            sqlContent.AppendLine(" order by                                                                                                                        ");
            sqlContent.AppendLine("     nt.NyukinDt,                                                                                                                ");
            sqlContent.AppendLine("     nt.NyukinNo                                                                                                                 ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

        #region GenerateInSql
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GenerateInSql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst">At least 1 element</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GenerateInSql(List<string> lst)
        {
            // 1 checkbox is checked!
            if (lst.Count == 1)
            {
                return string.Concat(" = '", lst[0], "'");
            }

            // Multiple choices
            string sqlPart = " in (";

            foreach (string val in lst)
            {
                sqlPart += string.Concat("'", val, "',");
            }

            sqlPart = sqlPart.Remove(sqlPart.Length - 1) + ") ";
            return sqlPart;
        }
        #endregion
    }
    #endregion
}
