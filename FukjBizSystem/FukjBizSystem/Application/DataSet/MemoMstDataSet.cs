using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
       
    public partial class MemoMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.MemoMstDataSetTableAdapters
{

    #region MemoMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MemoMstKensakuTableAdapter 
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoDaibunruiCd"></param>
        /// <param name="memo"></param>
        /// <param name="juyo"></param>
        /// <param name="hutsu"></param>
        /// <param name="sentakuKa"></param>
        /// <param name="sentakuHuka"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal MemoMstDataSet.MemoMstKensakuDataTable GetDataBySearchCond(
            string memoDaibunruiCd,
            string memo,
            bool juyo,
            bool hutsu,
            bool sentakuKa,
            bool sentakuHuka)
        {
            SqlCommand command = CreateSqlCommand(memoDaibunruiCd, memo, juyo, hutsu, sentakuKa, sentakuHuka);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            MemoMstDataSet.MemoMstKensakuDataTable dataTable = new MemoMstDataSet.MemoMstKensakuDataTable();
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
        /// <param name="memoDaibunruiCd"></param>
        /// <param name="memo"></param>
        /// <param name="juyo"></param>
        /// <param name="hutsu"></param>
        /// <param name="sentakuKa"></param>
        /// <param name="sentakuHuka"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string memoDaibunruiCd,
            string memo,
            bool juyo,
            bool hutsu,
            bool sentakuKa,
            bool sentakuHuka)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     MemoMst.MemoDaibunruiCd,                                                                            ");
            sqlContent.Append("     MemoMst.MemoCd,                                                                                     ");
            sqlContent.Append("     MemoMst.Memo,                                                                                       ");
            sqlContent.Append("     MemoMst.MemoJuyoFlg,                                                                                ");
            sqlContent.Append("     MemoMst.MemoSelectFlg,                                                                              ");
            sqlContent.Append("     MemoDaibunruiMst.MemoDaibunruiNm                                                                                        ");

            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     MemoMst                                                                                             ");
            sqlContent.Append("LEFT OUTER JOIN                                                                                          ");
            sqlContent.Append("     MemoDaibunruiMst                                                                                    ");
            sqlContent.Append("         ON MemoDaibunruiMst.MemoDaibunruiCd = MemoMst.MemoDaibunruiCd                                   ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            if (!string.IsNullOrEmpty(memoDaibunruiCd))
            {
                sqlContent.Append("AND MemoMst.MemoDaibunruiCd = @memoDaibunruiCd ");
                commandParams.Add("@memoDaibunruiCd", SqlDbType.NVarChar).Value = memoDaibunruiCd;
            }

            if (!string.IsNullOrEmpty(memo))
            {
                sqlContent.Append("AND MemoMst.Memo LIKE CONCAT('%', @memo, '%')     ");
                commandParams.Add("@memo", SqlDbType.NVarChar).Value = memo;
            }

            if (juyo && !hutsu)
            {
                sqlContent.Append("AND MemoMst.MemoJuyoFlg = '1' ");
            }
            else if (!juyo && hutsu)
            {
                sqlContent.Append("AND MemoMst.MemoJuyoFlg = '0' ");
            }
            if ((juyo && hutsu) || (!juyo && !hutsu))
            {
                sqlContent.Append("AND (MemoMst.MemoJuyoFlg = '1' OR MemoMst.MemoJuyoFlg = '0') ");
            }

            if (sentakuKa && !sentakuHuka)
            {
                sqlContent.Append("AND MemoMst.MemoSelectFlg = '0' ");
            }
            else if (!sentakuKa && sentakuHuka)
            {
                sqlContent.Append("AND MemoMst.MemoSelectFlg = '1' ");
            }
            if ((sentakuKa && sentakuHuka) || (!sentakuKa && !sentakuHuka))
            {
                sqlContent.Append("AND (MemoMst.MemoSelectFlg = '0' OR MemoMst.MemoSelectFlg = '1') ");
            }
            
            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     MemoMst.MemoDaibunruiCd,                                                                            ");
            sqlContent.Append("     MemoMst.MemoCd                                                                                      ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region MemoMstSearchListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoMstSearchListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class MemoMstSearchListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoDaibunruiCdFrom"></param>
        /// <param name="memoDaibunruiCdTo"></param>
        /// <param name="memoCdFrom"></param>
        /// <param name="memoCdTo"></param>
        /// <param name="memo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal MemoMstDataSet.MemoMstSearchListDataTable GetDataBySearchCond(
            string memoDaibunruiCdFrom,
            string memoDaibunruiCdTo,
            string memoCdFrom,
            string memoCdTo,
            string memo)
        {
            SqlCommand command = CreateSqlCommand(memoDaibunruiCdFrom, memoDaibunruiCdTo, memoCdFrom, memoCdTo, memo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            MemoMstDataSet.MemoMstSearchListDataTable dataTable = new MemoMstDataSet.MemoMstSearchListDataTable();
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
        /// <param name="memoDaibunruiCdFrom"></param>
        /// <param name="memoDaibunruiCdTo"></param>
        /// <param name="memoCdFrom"></param>
        /// <param name="memoCdTo"></param>
        /// <param name="memo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string memoDaibunruiCdFrom,
            string memoDaibunruiCdTo,
            string memoCdFrom,
            string memoCdTo,
            string memo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                                   ");
            sqlContent.Append("     MemoMst.MemoDaibunruiCd,                                                                            ");
            sqlContent.Append("     MemoMst.MemoCd,                                                                                     ");
            sqlContent.Append("     MemoMst.Memo,                                                                                       ");
            sqlContent.Append("     MemoMst.MemoJuyoFlg,                                                                                ");
            sqlContent.Append("     MemoMst.MemoSelectFlg,                                                                              ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         MemoMst.MemoJuyoFlg                                                                             ");
            sqlContent.Append("             WHEN '0' THEN '通常'                                                                        ");
            sqlContent.Append("             WHEN '1' THEN '重要'                                                                        ");
            sqlContent.Append("             ELSE ''                                                                                     ");
            sqlContent.Append("         END AS JuyoCol,                                                                                 ");
            sqlContent.Append("     CASE                                                                                                ");
            sqlContent.Append("         MemoMst.MemoSelectFlg                                                                           ");
            sqlContent.Append("             WHEN '0' THEN '選択可'                                                                       ");
            sqlContent.Append("             WHEN '1' THEN '選択不可'                                                                     ");
            sqlContent.Append("             ELSE ''                                                                                     ");
            sqlContent.Append("         END AS sentakuCol                                                                               ");


            // FROM
            sqlContent.Append("FROM                                                                                                     ");
            sqlContent.Append("     MemoMst                                                                                             ");

            // WHERE
            sqlContent.Append("WHERE                                                                                                    ");
            sqlContent.Append("     1 = 1                                                                                               ");

            // メモ大分類コード
            if (string.IsNullOrEmpty(memoDaibunruiCdFrom) && !string.IsNullOrEmpty(memoDaibunruiCdTo))
            {
                sqlContent.Append("AND MemoMst.MemoDaibunruiCd <= @memoDaibunruiCdTo                                                    ");
                commandParams.Add("@memoDaibunruiCdTo", SqlDbType.NVarChar).Value = memoDaibunruiCdTo;
            }
            else if (!string.IsNullOrEmpty(memoDaibunruiCdFrom) && string.IsNullOrEmpty(memoDaibunruiCdTo))
            {
                sqlContent.Append("AND MemoMst.MemoDaibunruiCd >= @memoDaibunruiCdFrom                                                  ");
                commandParams.Add("@memoDaibunruiCdFrom", SqlDbType.NVarChar).Value = memoDaibunruiCdFrom;
            }
            else if (!string.IsNullOrEmpty(memoDaibunruiCdFrom) && !string.IsNullOrEmpty(memoDaibunruiCdTo))
            {
                sqlContent.Append("AND MemoMst.MemoDaibunruiCd >= @memoDaibunruiCdFrom                                                  ");
                commandParams.Add("@memoDaibunruiCdFrom", SqlDbType.NVarChar).Value = memoDaibunruiCdFrom;

                sqlContent.Append("AND MemoMst.MemoDaibunruiCd <= @memoDaibunruiCdTo                                                    ");
                commandParams.Add("@memoDaibunruiCdTo", SqlDbType.NVarChar).Value = memoDaibunruiCdTo;
            }

            // メモコード
            if (string.IsNullOrEmpty(memoCdFrom) && !string.IsNullOrEmpty(memoCdTo))
            {
                sqlContent.Append("AND MemoMst.MemoCd <= @memoCdTo                                                                      ");
                commandParams.Add("@memoCdTo", SqlDbType.NVarChar).Value = memoCdTo;
            }
            else if (!string.IsNullOrEmpty(memoCdFrom) && string.IsNullOrEmpty(memoCdTo))
            {
                sqlContent.Append("AND MemoMst.MemoCd >= @memoCdFrom                                                                    ");
                commandParams.Add("@memoCdFrom", SqlDbType.NVarChar).Value = memoCdFrom;
            }
            else if (!string.IsNullOrEmpty(memoCdFrom) && !string.IsNullOrEmpty(memoCdTo))
            {
                sqlContent.Append("AND MemoMst.MemoCd <= @memoCdTo                                                                      ");
                commandParams.Add("@memoCdTo", SqlDbType.NVarChar).Value = memoCdTo;

                sqlContent.Append("AND MemoMst.MemoCd >= @memoCdFrom                                                                    ");
                commandParams.Add("@memoCdFrom", SqlDbType.NVarChar).Value = memoCdFrom;
            }

            if (!string.IsNullOrEmpty(memo))
            {
                sqlContent.Append("AND MemoMst.Memo LIKE CONCAT('%', @memo, '%')     ");
                commandParams.Add("@memo", SqlDbType.NVarChar).Value = memo;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     MemoMst.MemoDaibunruiCd,                                                                            ");
            sqlContent.Append("     MemoMst.MemoCd                                                                                      ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
