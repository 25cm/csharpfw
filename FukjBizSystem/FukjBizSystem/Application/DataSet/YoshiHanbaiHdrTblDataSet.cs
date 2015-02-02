using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {   
    
    public partial class YoshiHanbaiHdrTblDataSet {

        partial class YoshiHanbaiHdrTblDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.YoshiHanbaiHdrTblDataSetTableAdapters
{

    #region YoshiUriageListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiUriageListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YoshiUriageListTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupByDay"></param>
        /// <param name="yoshiHanbaiDtFrom"></param>
        /// <param name="yoshiHanbaiDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YoshiHanbaiHdrTblDataSet.YoshiUriageListDataTable GetDataBySearchCond(
            bool groupByDay,
            String yoshiHanbaiDtFrom,
            String yoshiHanbaiDtTo)
        {
            SqlCommand command = CreateSqlCommand(groupByDay, yoshiHanbaiDtFrom, yoshiHanbaiDtTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YoshiHanbaiHdrTblDataSet.YoshiUriageListDataTable dataTable = new YoshiHanbaiHdrTblDataSet.YoshiUriageListDataTable();
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
        /// <param name="groupByDay"></param>
        /// <param name="yoshiHanbaiDtFrom"></param>
        /// <param name="yoshiHanbaiDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            bool groupByDay,
            String yoshiHanbaiDtFrom,
            String yoshiHanbaiDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                               ");
            sqlContent.Append("     GyoshaMst.GyoshaNm,                                                             ");
            sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd,                                      ");

            if (groupByDay)
            {
                sqlContent.Append("YoshiHanbaiHdrTbl.YoshiHanbaiDt,                                                 ");
            }
            else
            {
                sqlContent.Append("CONCAT(YoshiHanbaiHdrTbl.YoshiHanbaiDt, '00') AS   YoshiHanbaiDt ,               ");
            }
            
            sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaiGokeiKingaku                                       ");

            // FROM
            sqlContent.Append("FROM                                                                                 ");
            sqlContent.Append("     GyoshaMst                                                                       ");
            sqlContent.Append("LEFT OUTER JOIN                                                                      ");

            if (groupByDay)
            {
                sqlContent.Append("(SELECT                                                                          ");
                sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd,                                  ");
                sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaiDt,                                            ");
                sqlContent.Append("     SUM(YoshiHanbaiHdrTbl.YoshiHanbaiGokeiKingaku) AS YoshiHanbaiGokeiKingaku   ");
                sqlContent.Append("FROM                                                                             ");
                sqlContent.Append("     YoshiHanbaiHdrTbl                                                           ");
                sqlContent.Append("GROUP BY                                                                         ");
                sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd,                                  ");
                sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaiDt                                             ");
                sqlContent.Append(") AS YoshiHanbaiHdrTbl                                                           ");
                sqlContent.Append("ON YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd = GyoshaMst.GyoshaCd                ");
            }
            else
            {
                sqlContent.Append("(SELECT                                                                          ");
                sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd,                                  ");
                sqlContent.Append("     SUBSTRING(YoshiHanbaiHdrTbl.YoshiHanbaiDt, 0, 7) AS YoshiHanbaiDt,          ");
                sqlContent.Append("     SUM(YoshiHanbaiHdrTbl.YoshiHanbaiGokeiKingaku) AS YoshiHanbaiGokeiKingaku   ");
                sqlContent.Append("FROM                                                                             ");
                sqlContent.Append("     YoshiHanbaiHdrTbl                                                           ");
                sqlContent.Append("GROUP BY                                                                         ");
                sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd,                                  ");
                sqlContent.Append("     SUBSTRING(YoshiHanbaiHdrTbl.YoshiHanbaiDt, 0, 7)                            ");
                sqlContent.Append(") AS YoshiHanbaiHdrTbl                                                           ");
                sqlContent.Append("ON YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd = GyoshaMst.GyoshaCd                ");
            }

            // WHERE
            sqlContent.Append("WHERE                                                                                ");
            sqlContent.Append("     1 = 1                                                                           ");
            sqlContent.Append("     AND ISNULL(YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd, '') <> ''                 ");

            sqlContent.Append("AND YoshiHanbaiHdrTbl.YoshiHanbaiDt >= @yoshiHanbaiDtFrom                            ");
            commandParams.Add("@yoshiHanbaiDtFrom", SqlDbType.NVarChar).Value = yoshiHanbaiDtFrom;

            sqlContent.Append("AND YoshiHanbaiHdrTbl.YoshiHanbaiDt <= @yoshiHanbaiDtTo                              ");
            commandParams.Add("@yoshiHanbaiDtTo", SqlDbType.NVarChar).Value = yoshiHanbaiDtTo;
            

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaisakiGyoshaCd,                                      ");
            sqlContent.Append("     YoshiHanbaiHdrTbl.YoshiHanbaiDt                                                 ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region TyumonShosaiTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TyumonShosaiTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22  AnhNV　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class TyumonShosaiTableAdapter
    {
        #region GetDataByYoshiHanbaiChumonNo
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByYoshiHanbaiChumonNo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoshiHanbaiChumonNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable GetDataByYoshiHanbaiChumonNo(string yoshiHanbaiChumonNo)
        {
            SqlCommand command = CreateSqlCommand(yoshiHanbaiChumonNo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable dataTable = new YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable();
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
        /// <param name="yoshiHanbaiChumonNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　     新規作成
        /// 2015/01/09  habu　      登録時に注文されなかった用紙が参照時に、表示されない不具合を修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string yoshiHanbaiChumonNo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // Sql for add mode
            if (string.IsNullOrEmpty(yoshiHanbaiChumonNo))
            {
                sqlContent.AppendLine(" select                                                                                              ");
                sqlContent.AppendLine("     ym.YoshiCd,                                                                                     ");
                sqlContent.AppendLine("     ym.YoshiNm,                                                                                     ");
                sqlContent.AppendLine("     case                                                                                            ");
                sqlContent.AppendLine("         when ym.YoshiKaiinSetKakaku > 0 then ym.YoshiKaiinSetKakaku                                 ");
                sqlContent.AppendLine("         else ym.YoshiKaiinUp                                                                        ");
                sqlContent.AppendLine("     end as KaiinTanka,                                                                              ");
                sqlContent.AppendLine("     case                                                                                            ");
                sqlContent.AppendLine("         when ym.YoshiHiKaiinSetKakaku > 0 then ym.YoshiHiKaiinSetKakaku                             ");
                sqlContent.AppendLine("         else ym.YoshiHiKaiinUp                                                                      ");
                sqlContent.AppendLine("     end as HiKaiinTanka,                                                                            ");
                sqlContent.AppendLine("     case                                                                                            ");
                sqlContent.AppendLine("         when ym.YoshiSetBusu = 0 then null                                                          ");
                sqlContent.AppendLine("         else ym.YoshiSetBusu                                                                        ");
                sqlContent.AppendLine("     end as YoshiSetBusu,                                                                            ");
                sqlContent.AppendLine("     null as HanbaiCnt,                                                                              ");
                sqlContent.AppendLine("     null as HanbaiKakaku,                                                                           ");
                sqlContent.AppendLine("     null as Syohizei,                                                                               ");
                sqlContent.AppendLine("     null as HanbaiKingaku,                                                                          ");
                sqlContent.AppendLine("     '' as [Set]                                                                                     ");
                sqlContent.AppendLine(" from YoshiMst ym                                                                                    ");
            }
            else // Update mode
            {
                sqlContent.AppendLine(" select                                                                                              ");                                                             
                sqlContent.AppendLine("     ym.YoshiCd,                                                                                     ");
                sqlContent.AppendLine("     ym.YoshiNm,                                                                                     ");
                sqlContent.AppendLine("     case                                                                                            ");
		        sqlContent.AppendLine("         when ym.YoshiKaiinSetKakaku > 0 then ym.YoshiKaiinSetKakaku                                 ");
		        sqlContent.AppendLine("         else ym.YoshiKaiinUp                                                                        ");
	            sqlContent.AppendLine("     end as KaiinTanka,                                                                              ");
                sqlContent.AppendLine("     case                                                                                            ");
		        sqlContent.AppendLine("         when ym.YoshiHiKaiinSetKakaku > 0 then ym.YoshiHiKaiinSetKakaku                             ");
		        sqlContent.AppendLine("         else ym.YoshiHiKaiinUp                                                                      ");
	            sqlContent.AppendLine("     end as HiKaiinTanka,                                                                            ");
                sqlContent.AppendLine("     case                                                                                            "); 
                sqlContent.AppendLine("         when ym.YoshiSetBusu = 0 then null                                                          ");
                sqlContent.AppendLine("         else ym.YoshiSetBusu                                                                        ");
                sqlContent.AppendLine("     end as YoshiSetBusu,                                                                            ");
                sqlContent.AppendLine("     case                                                                                            ");
                sqlContent.AppendLine("         when isnull(yhdt.YoshiHanbaiSetSuryo, '') = '' then yhdt.YoshiHanbaiSuryo                   ");
                sqlContent.AppendLine("         else yhdt.YoshiHanbaiSetSuryo                                                               ");
                sqlContent.AppendLine("     end as HanbaiCnt,                                                                               ");
                sqlContent.AppendLine("     null as HanbaiKakaku,                                                                           ");
                sqlContent.AppendLine("     null as Syohizei,                                                                               ");
                sqlContent.AppendLine("     null as HanbaiKingaku,                                                                          ");
                sqlContent.AppendLine("     case                                                                                            ");
                sqlContent.AppendLine("         when isnull(yhdt.YoshiHanbaiSetSuryo, '') = '' then '0'                                     "); // セット無の場合
                sqlContent.AppendLine("         else '1'                                                                                    "); // セット有の場合
                sqlContent.AppendLine("     end as [Set]                                                                                    ");
                sqlContent.AppendLine(" from YoshiMst ym                                                                                    ");
                sqlContent.AppendLine(" left outer join (select * from YoshiHanbaiDtlTbl where YoshiHanbaiChumonNo = @YoshiHanbaiChumonNo) as yhdt ");
                //sqlContent.AppendLine(" from YoshiHanbaiDtlTbl yhdt                                                                         ");
                //sqlContent.AppendLine(" left outer join YoshiMst ym                                                                         ");
                sqlContent.AppendLine("     on yhdt.YoshiHanbaiYoshiCd = ym.YoshiCd                                                         ");

                // Param
                commandParams.Add("@YoshiHanbaiChumonNo", SqlDbType.NVarChar).Value = yoshiHanbaiChumonNo;
            }

            // ORDER
            sqlContent.Append(" order by ym.YoshiCd                                                                                         ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region YoshiHanbaiHdrTblKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiHanbaiHdrTblKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23  HuyTX　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class YoshiHanbaiHdrTblKensakuTableAdapter
    {

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoshiHanbaiChumonNoFrom"></param>
        /// <param name="yoshiHanbaiChumonNoTo"></param>
        /// <param name="yoshiHanbaiDtFrom"></param>
        /// <param name="yoshiHanbaiDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblKensakuDataTable GetDataBySearchCond(string gyoshaCd,
            string yoshiHanbaiChumonNoFrom,
            string yoshiHanbaiChumonNoTo,
            string yoshiHanbaiDtFrom,
            string yoshiHanbaiDtTo)
        {
            SqlCommand command = CreateSqlCommand(gyoshaCd,
                                                yoshiHanbaiChumonNoFrom,
                                                yoshiHanbaiChumonNoTo,
                                                yoshiHanbaiDtFrom,
                                                yoshiHanbaiDtTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblKensakuDataTable dataTable = new YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblKensakuDataTable();
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
        /// <param name="yoshiHanbaiChumonNoFrom"></param>
        /// <param name="yoshiHanbaiChumonNoTo"></param>
        /// <param name="yoshiHanbaiDtFrom"></param>
        /// <param name="yoshiHanbaiDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string gyoshaCd,
            string yoshiHanbaiChumonNoFrom,
            string yoshiHanbaiChumonNoTo,
            string yoshiHanbaiDtFrom,
            string yoshiHanbaiDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append("SELECT ");
            sqlContent.Append("LTRIM(yhht.YoshiHanbaiChumonNo) AS YoshiHanbaiChumonNo, ");
            sqlContent.Append("CONVERT(CHAR(10), CONVERT(DATETIME, yhht.YoshiHanbaiDt), 111) as YoshiHanbaiDt , ");
            sqlContent.Append("gm.GyoshaNm, ");
            // 2014/12/15 AnhNV ADD Start
            sqlContent.Append("gm.GyoshaCd, ");
            // 2014/12/15 AnhNV ADD End
            sqlContent.Append("yhht.YoshiHanbaiGokeiKingaku ");

            //FROM
            sqlContent.Append("FROM YoshiHanbaiHdrTbl yhht ");

            //JOIN
            sqlContent.Append("LEFT JOIN GyoshaMst gm ");
            sqlContent.Append("ON gm.GyoshaCd = yhht.YoshiHanbaisakiGyoshaCd ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1  ");

            if (!string.IsNullOrEmpty(gyoshaCd))
            {
                sqlContent.Append(" AND yhht.YoshiHanbaisakiGyoshaCd = @gyoshaCd ");
                commandParams.Add("@gyoshaCd", SqlDbType.NVarChar).Value = gyoshaCd;
            }

            //MOD_20141117_HuyTX Start
            //sqlContent.Append(" AND REPLACE(STR(yhht.YoshiHanbaiChumonNo, 10), SPACE(1), '0') " + DataAccessUtility.SetBetweenCommand(yoshiHanbaiChumonNoFrom, yoshiHanbaiChumonNoTo, 10));
            //sqlContent.Append(" AND yhht.YoshiHanbaiChumonNo " + DataAccessUtility.SetBetweenCommand(yoshiHanbaiChumonNoFrom, yoshiHanbaiChumonNoTo, 10));
            if (!string.IsNullOrEmpty(yoshiHanbaiChumonNoFrom) && string.IsNullOrEmpty(yoshiHanbaiChumonNoTo))
            {
                sqlContent.Append(" AND yhht.YoshiHanbaiChumonNo >= @yoshiHanbaiChumonNoFrom ");
                commandParams.Add("@yoshiHanbaiChumonNoFrom", SqlDbType.NVarChar).Value = yoshiHanbaiChumonNoFrom;
            }
            else if (string.IsNullOrEmpty(yoshiHanbaiChumonNoFrom) && !string.IsNullOrEmpty(yoshiHanbaiChumonNoTo))
            {
                sqlContent.Append(" AND yhht.YoshiHanbaiChumonNo <= @yoshiHanbaiChumonNoTo ");
                commandParams.Add("@yoshiHanbaiChumonNoTo", SqlDbType.NVarChar).Value = yoshiHanbaiChumonNoTo;
            }
            else if (!string.IsNullOrEmpty(yoshiHanbaiChumonNoFrom) && !string.IsNullOrEmpty(yoshiHanbaiChumonNoTo))
            {
                sqlContent.Append(" AND yhht.YoshiHanbaiChumonNo >= @yoshiHanbaiChumonNoFrom ");
                commandParams.Add("@yoshiHanbaiChumonNoFrom", SqlDbType.NVarChar).Value = yoshiHanbaiChumonNoFrom;

                sqlContent.Append(" AND yhht.YoshiHanbaiChumonNo <= @yoshiHanbaiChumonNoTo ");
                commandParams.Add("@yoshiHanbaiChumonNoTo", SqlDbType.NVarChar).Value = yoshiHanbaiChumonNoTo;
            }
            //MOD_20141117_HuyTX End

            if (!string.IsNullOrEmpty(yoshiHanbaiDtFrom) && !string.IsNullOrEmpty(yoshiHanbaiDtTo))
            {
                sqlContent.Append(" AND YoshiHanbaiDt BETWEEN CAST(@yoshiHanbaiDtFrom AS DATE) AND CAST(@yoshiHanbaiDtTo AS DATE) ");
                commandParams.Add("@yoshiHanbaiDtFrom", SqlDbType.NVarChar).Value = yoshiHanbaiDtFrom;
                commandParams.Add("@yoshiHanbaiDtTo", SqlDbType.NVarChar).Value = yoshiHanbaiDtTo;
            }

            //ORDER BY
            sqlContent.Append(" ORDER BY yhht.YoshiHanbaiChumonNo ");

            command.CommandText = sqlContent.ToString();
            return command;
        }
    }
        #endregion

    #endregion
}


namespace FukjBizSystem.Application.DataSet.YoshiHanbaiHdrTblDataSetTableAdapters
{
    
    
    
}
