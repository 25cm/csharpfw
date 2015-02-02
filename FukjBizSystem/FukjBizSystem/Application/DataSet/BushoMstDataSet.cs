using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{

    public partial class BushoMstDataSet
    {
        partial class BushoMstKensakuDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.BushoMstDataSetTableAdapters
{
    #region BushoMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BushoMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/02　HuyTX　　 新規作成
    /// 2014/10/14　小松　　    コマンドタイムアウト設定
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class BushoMstKensakuTableAdapter
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
        /// <param name="bushoCdFrom"></param>
        /// <param name="bushoCdTo"></param>
        /// <param name="bushoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　HuyTX　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal BushoMstDataSet.BushoMstKensakuDataTable GetDataBySearchCond(string bushoCdFrom, string bushoCdTo, string bushoNm)
        {
            SqlCommand command = CreateSqlCommand(bushoCdFrom, bushoCdTo, bushoNm);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            BushoMstDataSet.BushoMstKensakuDataTable dataTable = new BushoMstDataSet.BushoMstKensakuDataTable();
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
        /// <param name="bushoCdFrom"></param>
        /// <param name="bushoCdTo"></param>
        /// <param name="bushoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　HuyTX　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string bushoCdFrom, string bushoCdTo, string bushoNm)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            sqlContent.Append("SELECT  ");
            sqlContent.Append("BushoCd,  ");
            sqlContent.Append("BushoNm  ");

            //FROM
            sqlContent.Append("FROM BushoMst   ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            //sqlContent.Append("AND BushoCd " + DataAccessUtility.SetBetweenCommand(bushoCdFrom, bushoCdTo, 2));

            if (!string.IsNullOrEmpty(bushoCdFrom) && string.IsNullOrEmpty(bushoCdTo))
            {
                sqlContent.Append("AND BushoCd >= @bushoCdFrom                      ");
                commandParams.Add("@bushoCdFrom", SqlDbType.NVarChar).Value = bushoCdFrom;
            }
            else if (string.IsNullOrEmpty(bushoCdFrom) && !string.IsNullOrEmpty(bushoCdTo))
            {
                sqlContent.Append("AND BushoCd <= @bushoCdTo                        ");
                commandParams.Add("@bushoCdTo", SqlDbType.NVarChar).Value = bushoCdTo;
            }
            else if (!string.IsNullOrEmpty(bushoCdFrom) && !string.IsNullOrEmpty(bushoCdTo))
            {
                sqlContent.Append("AND BushoCd >= @bushoCdFrom                      ");
                sqlContent.Append("AND BushoCd <= @bushoCdTo                        ");
                commandParams.Add("@bushoCdFrom", SqlDbType.NVarChar).Value = bushoCdFrom;
                commandParams.Add("@bushoCdTo", SqlDbType.NVarChar).Value = bushoCdTo;
            }

            if (!string.IsNullOrEmpty(bushoNm))
            {
                sqlContent.Append("AND BushoNm LIKE concat('%', @bushoNm, '%')          ");
                commandParams.Add("@bushoNm", SqlDbType.NVarChar).Value = bushoNm;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY BushoCd");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

    }
    #endregion


    #region BushoMstTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BushoMstTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14　小松　　    コマンドタイムアウト設定
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class BushoMstTableAdapter
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
    }
    #endregion
}
