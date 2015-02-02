using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;
using System;


namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class ShokenMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.ShokenMstDataSetTableAdapters
{


    #region ShokenKekkaSelectTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShokenKekkaSelectTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class ShokenKekkaSelectTableAdapter
    {
        #region GetDataByKbn
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByKbn
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokenKbn"></param>
        /// <param name="shokenShitekiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShokenMstDataSet.ShokenKekkaSelectDataTable GetDataByKbn(string shokenKbn, int shokenTaishoKensaBitMask)
        {
            SqlCommand command = CreateSqlCommand(shokenKbn, shokenTaishoKensaBitMask);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShokenMstDataSet.ShokenKekkaSelectDataTable table = new ShokenMstDataSet.ShokenKekkaSelectDataTable();
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
        /// <param name="shokenKbn"></param>
        /// <param name="shokenShitekiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　新規作成
        /// 2015/01/21　小松　　　　重要度、判断、判定のコード値を取得
        /// 2015/01/22　小松　　　　指摘箇所No等の項目も取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shokenKbn, int shokenTaishoKensaBitMask)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" select                                                                                                              ");
	        sqlContent.AppendLine("     sm.ShokenKbn,                                                                                                   ");
	        sqlContent.AppendLine("     sm.ShokenCd,                                                                                                    ");
	        sqlContent.AppendLine("     sm.ShokenWd,                                                                                                    ");
	        sqlContent.AppendLine("     cm1.ConstNm as Juyodo,                                                                                          ");
	        sqlContent.AppendLine("     cm2.ConstNm as Handan,                                                                                          ");
	        sqlContent.AppendLine("     cm3.ConstNm as Hantei,                                                                                          ");
	        sqlContent.AppendLine("     case                                                                                                            ");
		    sqlContent.AppendLine("         when isnull(sm.ShokenBiko, '') <> '' then '有'                                                              ");
		    sqlContent.AppendLine("         else ''                                                                                                     ");
	        sqlContent.AppendLine("     end as ShokenBiko                                                                                               ");
	        sqlContent.AppendLine("     , sm.ShokenJuyodo                                                                                               ");
	        sqlContent.AppendLine("     , sm.ShokenHandan                                                                                               ");
            sqlContent.AppendLine("     , sm.ShokenHantei                                                                                               ");
            sqlContent.AppendLine("	    , sm.ShokenHyokiJun                                                                                             ");
            sqlContent.AppendLine("	    , sm.ShokenWdRyaku                                                                                              ");
            sqlContent.AppendLine("	    , sm.ShokenHokokuLevel                                                                                          ");
            sqlContent.AppendLine("	    , sm.ShokenShitekiKbn                                                                                           ");
            sqlContent.AppendLine("	    , sm.ShokenShitekiNo                                                                                            ");
            sqlContent.AppendLine("	    , sm.ShokenDojiCheckKomoku                                                                                      ");
            sqlContent.AppendLine("	    , sm.ShokenDojiCheckHandan                                                                                      ");
            sqlContent.AppendLine("	    , sm.ShokenFollowFlg                                                                                            ");
            sqlContent.AppendLine("	    , sm.ShokenTaishoKensaBitMask                                                                                   ");
            sqlContent.AppendLine(" from ShokenMst sm                                                                                                   ");
            sqlContent.AppendLine(" left outer join ConstMst cm1                                                                                        ");
	        sqlContent.AppendLine("     on sm.ShokenJuyodo = cm1.ConstValue                                                                             ");
	        sqlContent.AppendLine("     and cm1.ConstKbn = '012'                                                                                        ");
            sqlContent.AppendLine(" left outer join ConstMst cm2                                                                                        ");
	        sqlContent.AppendLine("     on sm.ShokenHandan = cm2.ConstValue                                                                             ");
	        sqlContent.AppendLine("     and cm2.ConstKbn = '025'                                                                                        ");
            sqlContent.AppendLine(" left outer join ConstMst cm3                                                                                        ");
	        sqlContent.AppendLine("     on sm.ShokenHantei = cm3.ConstValue                                                                             ");
	        sqlContent.AppendLine("     and cm3.ConstKbn = '016'                                                                                        ");
            sqlContent.AppendLine(" where                                                                                                               ");
            sqlContent.AppendLine("     1 = 1                                                                                                           ");

            // 0: ALL
            if (shokenKbn != "0")
            {
                // 所見区分
                if (!string.IsNullOrEmpty(shokenKbn))
                {
                    sqlContent.AppendLine(" and sm.ShokenKbn = @ShokenKbn");
                    commandParams.Add("@ShokenKbn", SqlDbType.NVarChar).Value = shokenKbn;
                }
            }

            // 指摘区分
            if (shokenTaishoKensaBitMask > 0)
            {
                sqlContent.AppendLine(" and sm.ShokenTaishoKensaBitMask & @ShokenTaishoKensaBitMask <> 0");
                commandParams.Add("@ShokenTaishoKensaBitMask", SqlDbType.Int).Value = shokenTaishoKensaBitMask;

                //sqlContent.AppendLine(" and sm.ShokenshitekiKbn = @ShokenshitekiKbn");
                //commandParams.Add("@ShokenshitekiKbn", SqlDbType.NVarChar).Value = shokenShitekiKbn;
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region ShokenCheckItemTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShokenCheckItemTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShokenCheckItemTableAdapter
    {
        #region GetDataByShokenTaishoKensaBitMask
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByShokenTaishoKensaBitMask
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokenShitekiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShokenMstDataSet.ShokenCheckItemDataTable GetDataByShokenTaishoKensaBitMask(int shokenTaishoKensaBitMask)
        {
            SqlCommand command = CreateSqlCommand(shokenTaishoKensaBitMask);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShokenMstDataSet.ShokenCheckItemDataTable table = new ShokenMstDataSet.ShokenCheckItemDataTable();
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
        /// <param name="shokenShitekiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(int shokenTaishoKensaBitMask)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" select                                                                                                          ");
            sqlContent.AppendLine("     '0' as Code,                                                                                                ");
            sqlContent.AppendLine("     'ALL' as Name                                                                                               ");

            // ShokenShiteki mode
            if (shokenTaishoKensaBitMask == Convert.ToInt32("00000010", 2)) // (2) in Search spec.
            {
                // 水質
                sqlContent.AppendLine(" union all                                                                                                   ");
                sqlContent.AppendLine(" select distinct                                                                                             ");
	            sqlContent.AppendLine("     skm.SuishitsuShikenKoumokuCd as Code,                                                                   ");
	            sqlContent.AppendLine("     skm.SeishikiNm as Name                                                                                  ");
                sqlContent.AppendLine(" from ShokenMst sm                                                                                           ");
                sqlContent.AppendLine(" inner join SuishitsuShikenKoumokuMst skm                                                                    ");
	            sqlContent.AppendLine("     on sm.ShokenKbn = skm.SuishitsuShikenKoumokuCd                                                          ");
                sqlContent.AppendLine(" where                                                                                                       ");
                //sqlContent.AppendLine("     sm.ShokenShitekiKbn = @ShokenShitekiKbn                                                                 ");
                sqlContent.AppendLine("     sm.ShokenTaishoKensaBitMask & @ShokenTaishoKensaBitMask <> 0                                            ");
                //sqlContent.AppendLine(" order by                                                                                                    ");
                //sqlContent.AppendLine("     skm.SuishitsuShikenKoumokuCd                                                                            ");
            }
            else // (1) in Search spec.
            {
                // 外観
                sqlContent.AppendLine(" union all                                                                                                   ");
                sqlContent.AppendLine(" select distinct                                                                                             ");
	            sqlContent.AppendLine("     gkm.GaikankensaKomokuCd as Code,                                                                        ");
	            sqlContent.AppendLine("     gkm.GaikankensaKomokuNm as Name                                                                         ");
                sqlContent.AppendLine(" from ShokenMst sm                                                                                           ");
                sqlContent.AppendLine(" inner join GaikankensaKomokuMst gkm                                                                         ");
	            sqlContent.AppendLine("     on sm.ShokenKbn = gkm.GaikankensaKomokuCd                                                               ");
                sqlContent.AppendLine(" where                                                                                                       ");
                //sqlContent.AppendLine("     sm.ShokenShitekiKbn = @ShokenShitekiKbn                                                                 ");
                sqlContent.AppendLine("     sm.ShokenTaishoKensaBitMask & @ShokenTaishoKensaBitMask <> 0                                            ");
                //sqlContent.AppendLine(" order by                                                                                                    ");
                //sqlContent.AppendLine("     gkm.GaikankensaKomokuCd                                                                                 ");
            }

            // Order
            sqlContent.AppendLine(" order by                                                                                                        ");
            sqlContent.AppendLine("     Code                                                                                                        ");

            // Param
            //commandParams.Add("@ShokenShitekiKbn", SqlDbType.NVarChar).Value = shokenShitekiKbn;
            commandParams.Add("@ShokenTaishoKensaBitMask", SqlDbType.Int).Value = shokenTaishoKensaBitMask;

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region ShokenMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShokenMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShokenMstKensakuTableAdapter {

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShokenMstDataSet.ShokenMstKensakuDataTable GetDataBySearchCond(
            string shokenKbn,
            string shokenCdFrom,
            string shokenCdTo,
            string shokenJuyodo,
            string shokenShitekiKbn)
        {
            SqlCommand command = CreateSqlCommand(shokenKbn,
                                                shokenCdFrom,
                                                shokenCdTo,
                                                shokenJuyodo,
                                                shokenShitekiKbn);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShokenMstDataSet.ShokenMstKensakuDataTable dataTable = new ShokenMstDataSet.ShokenMstKensakuDataTable();
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
        /// 2014/08/22　HuyTX　　新規作成
        /// 2015/01/23  DatNT   v1.03 ADD
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string shokenKbn,
            string shokenCdFrom,
            string shokenCdTo,
            string shokenJuyodo,
            string shokenShitekiKbn)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append(" SELECT                                      ");
            sqlContent.Append(" 	ShokenKbn,                              ");
            sqlContent.Append(" 	ShokenCd,                               ");
            sqlContent.Append(" 	ShokenJuyodo,                           ");
            sqlContent.Append(" 	ShokenHandan,                           ");
            sqlContent.Append(" 	ShokenWd,                               ");
            // 2015/01/23 DatNT v1.03 ADD Start
            sqlContent.Append(" 	ShokenWdRyaku,                          ");
            sqlContent.Append(" 	ShokenFollowFlg,                        ");
            // 2015/01/23 DatNT v1.03 ADD End
            sqlContent.Append(" 	ShokenHantei,                           ");
            sqlContent.Append(" 	ShokenBiko,                             ");
            sqlContent.Append(" 	ShokenHokokuLevel,                      ");
            sqlContent.Append(" 	ShokenShitekiKbn,                       ");
            sqlContent.Append(" 	ShokenShitekiNo,                        ");
            sqlContent.Append(" 	ShokenDojiCheckKomoku                   ");

            sqlContent.Append(" FROM ShokenMst ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            //所見区分
            if (!string.IsNullOrEmpty(shokenKbn))
            {
                sqlContent.Append(" AND ShokenKbn = @shokenKbn ");
                commandParams.Add("@shokenKbn", SqlDbType.NVarChar).Value = shokenKbn;
            }

            //所見コード（開始 ~ 終了）
            //sqlContent.Append(" AND ShokenCd " + DataAccessUtility.SetBetweenCommand(shokenCdFrom, shokenCdTo, 5));
            if (!string.IsNullOrEmpty(shokenCdFrom) && string.IsNullOrEmpty(shokenCdTo))
            {
                sqlContent.Append(" AND ShokenCd >= @shokenCdFrom ");
                commandParams.Add("@shokenCdFrom", SqlDbType.NVarChar).Value = shokenCdFrom;
            }
            else if (string.IsNullOrEmpty(shokenCdFrom) && !string.IsNullOrEmpty(shokenCdTo))
            {
                sqlContent.Append(" AND ShokenCd <= @shokenCdTo ");
                commandParams.Add("@shokenCdTo", SqlDbType.NVarChar).Value = shokenCdTo;
            }
            else if (!string.IsNullOrEmpty(shokenCdFrom) && !string.IsNullOrEmpty(shokenCdTo))
            {
                sqlContent.Append(" AND ShokenCd >= @shokenCdFrom ");
                commandParams.Add("@shokenCdFrom", SqlDbType.NVarChar).Value = shokenCdFrom;

                sqlContent.Append(" AND ShokenCd <= @shokenCdTo ");
                commandParams.Add("@shokenCdTo", SqlDbType.NVarChar).Value = shokenCdTo;
            }

            //重要度
            if (!string.IsNullOrEmpty(shokenJuyodo))
            {
                sqlContent.Append(" AND ShokenJuyodo = @shokenJuyodo ");
                commandParams.Add("@shokenJuyodo", SqlDbType.NVarChar).Value = shokenJuyodo;
            }

            //指摘区分
            if (!string.IsNullOrEmpty(shokenShitekiKbn))
            {
                sqlContent.Append(" AND ShokenShitekiKbn = @shokenShitekiKbn ");
                commandParams.Add("@shokenShitekiKbn", SqlDbType.NVarChar).Value = shokenShitekiKbn;
            }

            // ORDER BY
            sqlContent.Append(" ORDER BY                                                                ");
            sqlContent.Append("         	ShokenKbn,ShokenCd                                          ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

    }
    #endregion

    #region SyokenMstSearchListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyokenMstSearchListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class SyokenMstSearchListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokenShitekiKbn"></param>
        /// <param name="shokenKbn"></param>
        /// <param name="shokenWd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShokenMstDataSet.SyokenMstSearchListDataTable GetDataBySearchCond(
            string shokenShitekiKbn,
            string shokenKbn,
            string shokenWd)
        {
            SqlCommand command = CreateSqlCommand(shokenShitekiKbn, shokenKbn, shokenWd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShokenMstDataSet.SyokenMstSearchListDataTable dataTable = new ShokenMstDataSet.SyokenMstSearchListDataTable();
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
        /// <param name="shokenShitekiKbn"></param>
        /// <param name="shokenKbn"></param>
        /// <param name="shokenWd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22　DatNT　　新規作成
        /// 2014/12/29  小松        並びが、所見コード順になっていた。所見区分、コード順
        /// 2015/01/23  小松        指摘箇所No（ShokenShitekiNo）を取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string shokenShitekiKbn,
            string shokenKbn,
            string shokenWd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            
            // SELECT
            sqlContent.Append(" SELECT                                                                  ");
            sqlContent.Append(" 	ShokenMst.ShokenKbn,                                                ");
            sqlContent.Append(" 	ShokenMst.ShokenCd,                                                 ");
            sqlContent.Append(" 	ShokenMst.ShokenWd,                                                 ");
            sqlContent.Append(" 	ShokenMst.ShokenJuyodo,                                             ");
            sqlContent.Append(" 	ShokenMst.ShokenHandan,                                             ");
            sqlContent.Append(" 	ShokenMst.ShokenHantei,                                             ");
            //MOD_HuyTX Start
            //sqlContent.Append(" 	ShokenMst.ShokenBiko,                                               ");
            sqlContent.Append(" 	CASE                                                                ");
            sqlContent.Append(" 	    WHEN ISNULL(ShokenMst.ShokenBiko, '') <> '' THEN '有'           ");
            sqlContent.Append(" 	    ELSE ''                                                         ");
            sqlContent.Append(" 	END AS ShokenBiko,                                                  ");
            //MOD_HuyTX End

            sqlContent.Append(" 	ShokenMst.ShokenShitekiKbn,                                         ");
            sqlContent.Append(" 	const1.ConstNm AS juyodoCol,                                        ");
            sqlContent.Append(" 	const2.ConstNm AS handanCol,                                        ");
            sqlContent.Append(" 	const3.ConstNm AS hanteiCol                                         ");
            sqlContent.Append(" 	, ShokenMst.ShokenShitekiNo                                         ");

            sqlContent.Append(" FROM                                                                    ");
            sqlContent.Append("     ShokenMst                                                           ");
            sqlContent.Append(" LEFT OUTER JOIN                                                         ");
            sqlContent.Append("     ConstMst const1                                                     ");
            sqlContent.Append("         ON const1.ConstKbn = '012'                                      ");
            sqlContent.Append("         AND const1.ConstValue = ShokenMst.ShokenJuyodo                  ");
            sqlContent.Append(" LEFT OUTER JOIN                                                         ");
            sqlContent.Append("     ConstMst const2                                                     ");
            sqlContent.Append("         ON const2.ConstKbn = '025'                                      ");
            sqlContent.Append("         AND const2.ConstValue = ShokenMst.ShokenHandan                  ");
            sqlContent.Append(" LEFT OUTER JOIN                                                         ");
            sqlContent.Append("     ConstMst const3                                                     ");
            sqlContent.Append("         ON const3.ConstKbn = '016'                                      ");
            sqlContent.Append("         AND const3.ConstValue = ShokenMst.ShokenHantei                  ");

            // WHERE
            sqlContent.Append(" WHERE                                                                   ");
            sqlContent.Append("     1 = 1                                                               ");

            //指摘区分
            if (!string.IsNullOrEmpty(shokenShitekiKbn))
            {
                sqlContent.Append(" AND ShokenMst.ShokenShitekiKbn = @shokenShitekiKbn                  ");
                commandParams.Add("@shokenShitekiKbn", SqlDbType.NVarChar).Value = shokenShitekiKbn;
            }

            //所見区分
            if (!string.IsNullOrEmpty(shokenKbn))
            {
                sqlContent.Append(" AND ShokenMst.ShokenKbn = @shokenKbn                                ");
                commandParams.Add("@shokenKbn", SqlDbType.NVarChar).Value = shokenKbn;
            }

            // 所見文章
            if (!string.IsNullOrEmpty(shokenWd))
            {
                sqlContent.Append("AND ShokenMst.ShokenWd LIKE concat('%', @shokenWd, '%')              ");
                commandParams.Add("@shokenWd", SqlDbType.VarChar).Value = shokenWd;
            }

            // ORDER BY
            sqlContent.Append(" ORDER BY                                                                ");
            sqlContent.Append("     ShokenMst.ShokenKbn, ShokenMst.ShokenCd                             ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
