using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Zynas.Framework.Core.Common.DataAccess
{
    public class FilteredAdapterUtility
    {
        public static SqlDataAdapter CreateFilteredDataAdapter(SqlConnection connection, Type tableAdapterType, string whereStr, string orderStr)
        {
            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(tableAdapterType);

            #region Base Select Commandの取得(Get Base Command from adapter's CommandCollection)

            PropertyInfo propInfoCommand = adap.GetType().GetProperty("CommandCollection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            SqlCommand[] baseCommandCollection = (SqlCommand[])propInfoCommand.GetValue(adap, null);
            SqlCommand baseCommand = baseCommandCollection[0];

            #endregion

            #region (Create filtered query text)

            SqlCommand executeCommand = new SqlCommand();
            executeCommand.Connection = connection;
            executeCommand.CommandText = string.Format("SELECT * FROM ({0}) A {1} {2}", baseCommand.CommandText, whereStr, orderStr);
            executeCommand.CommandType = CommandType.Text;

            #endregion

            SqlDataAdapter executeAdaper = new SqlDataAdapter(executeCommand);

            return executeAdaper;
        }
    }
}
