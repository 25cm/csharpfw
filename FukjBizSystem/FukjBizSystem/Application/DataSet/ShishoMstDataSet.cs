using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class ShishoMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.ShishoMstDataSetTableAdapters
{
    #region ShishoMstTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShishoMstTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShishoMstTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCdFrom"></param>
        /// <param name="shishoCdTo"></param>
        /// <param name="shishoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal ShishoMstDataSet.ShishoMstDataTable GetDataBySearchCond
            (
                string shishoCdFrom,
                string shishoCdTo,
                string shishoNm
            )
        {
            SqlCommand command = CreateSqlCommand(shishoCdFrom, shishoCdTo, shishoNm);
            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            ShishoMstDataSet.ShishoMstDataTable dataTable = new ShishoMstDataSet.ShishoMstDataTable();
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
        /// <param name="shishoCdFrom"></param>
        /// <param name="shishoCdTo"></param>
        /// <param name="shishoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand
            (
                string shishoCdFrom,
                string shishoCdTo,
                string shishoNm
            )
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sb = new StringBuilder();

            // SQL content
            sb.Append("SELECT ");
            sb.Append("  ShishoCd ");
            sb.Append("  , ShishoNm ");
            sb.Append("  , ShishoZipCd ");
            sb.Append("  , ShishoAdr ");
            sb.Append("  , ShishoTelNo ");
            sb.Append("  , ShishoFaxNo ");
            sb.Append("  , ShishoFreeDial ");
            sb.Append("  , ShishoChoNm ");
            sb.Append("  , ShishoKeiryoKanrisha ");
            sb.Append("  , ShishoKankyoKeiryoshiNo ");
            sb.Append("  , ShishoKenTorokuNo ");
            sb.Append("  , InsertDt ");
            sb.Append("  , InsertUser ");
            sb.Append("  , InsertTarm ");
            sb.Append("  , UpdateDt ");
            sb.Append("  , UpdateUser ");
            sb.Append("  , UpdateTarm ");
            sb.Append("FROM ");
            sb.Append("  ShishoMst ");

            //sqlContent.Append(" select                                             ");
            //sqlContent.Append("     sm.ShishoCd,                                   ");
            //sqlContent.Append("     sm.ShishoNm,                                   ");
            //sqlContent.Append("     sm.ShishoZipCd,                                ");
            //sqlContent.Append("     sm.ShishoAdr,                                  ");
            //sqlContent.Append("     sm.ShishoTelNo,                                ");
            //sqlContent.Append("     sm.ShishoFaxNo,                                ");
            //sqlContent.Append("     sm.ShishoFreeDial,                             ");
            //sqlContent.Append("     sm.InsertDt,                                   ");
            //sqlContent.Append("     sm.InsertUser,                                 ");
            //sqlContent.Append("     sm.InsertTarm,                                 ");
            //sqlContent.Append("     sm.UpdateDt,                                   ");
            //sqlContent.Append("     sm.UpdateUser,                                 ");
            //sqlContent.Append("     sm.UpdateTarm                                  ");
            //sqlContent.Append(" from ShishoMst sm                                  ");
            sb.Append(" WHERE 1 = 1                                        ");

            // 支所コード FROM ~ TO
            //sqlContent.Append(" and sm.ShishoCd " + DataAccessUtility.SetBetweenCommand(shishoCdFrom, shishoCdTo, 1));

            if (!string.IsNullOrEmpty(shishoCdFrom) && string.IsNullOrEmpty(shishoCdTo))
            {
                sb.Append(" and ShishoCd >= @shishoCdFrom ");
                commandParams.Add("@shishoCdFrom", System.Data.SqlDbType.NVarChar).Value = shishoCdFrom;
            }
            else if (string.IsNullOrEmpty(shishoCdFrom) && !string.IsNullOrEmpty(shishoCdTo))
            {
                sb.Append(" and ShishoCd <= @shishoCdTo ");
                commandParams.Add("@shishoCdTo", System.Data.SqlDbType.NVarChar).Value = shishoCdTo;
            }
            else if (!string.IsNullOrEmpty(shishoCdFrom) && !string.IsNullOrEmpty(shishoCdTo))
            {
                sb.Append(" and ShishoCd >= @shishoCdFrom ");
                sb.Append(" and ShishoCd <= @shishoCdTo ");
                commandParams.Add("@shishoCdFrom", System.Data.SqlDbType.NVarChar).Value = shishoCdFrom;
                commandParams.Add("@shishoCdTo", System.Data.SqlDbType.NVarChar).Value = shishoCdTo;
            }

            if (!string.IsNullOrEmpty(shishoNm))
            {
                // 支所名称
                sb.Append(" AND ShishoNm LIKE CONCAT('%', @shishoNm, '%')");
                commandParams.Add("@shishoNm", System.Data.SqlDbType.VarChar).Value = shishoNm;
            }

            // ORDER BY
            sb.Append(" ORDER BY ShishoCd");

            command.CommandText = sb.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
namespace FukjBizSystem.Application.DataSet.ShishoMstDataSetTableAdapters
{

    
}
