using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Core.Common.DataAccess;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Generic.DataAccess
{
    #region 入力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public interface IStdFilteredSelectDataDAInput
    {
        /// <summary>
        /// Type of TableAdapter. Use typeof(XXXTableAdapter)
        /// </summary>
        Type TableAdapterType { get; set; }

        /// <summary>
        /// Type of DataTable. Use typeof(XXXDataTable)
        /// </summary>
        Type DataTableType { get; set; }

        /// <summary>
        /// SQL QueryBuilder
        /// </summary>
        QueryBuilder Query { get; set; }

        /// <summary>
        /// Applies DISTINCT if true
        /// </summary>
        bool IsDistinct { get; set; }

        /// <summary>
        /// Row Count Limit
        /// </summary>
        int RowLimit { get; set; }

        /// <summary>
        /// Query CommantTimeout(seconds)
        /// </summary>
        int CommandTimeOut { get; set; }
    }
    #endregion

    #region 入力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public class StdFilteredSelectDataDAInput : IStdFilteredSelectDataDAInput
    {
        /// <summary>
        /// Type of TableAdapter. Use typeof(XXXTableAdapter)
        /// </summary>
        public Type TableAdapterType { get; set; }

        /// <summary>
        /// Type of DataTable. Use typeof(XXXDataTable)
        /// </summary>
        public Type DataTableType { get; set; }

        /// <summary>
        /// SQL QueryBuilder
        /// </summary>
        public QueryBuilder Query { get; set; }

        /// <summary>
        /// Applies DISTINCT if true
        /// </summary>
        public bool IsDistinct { get; set; }

        /// <summary>
        /// Row Count Limit
        /// </summary>
        public int RowLimit { get; set; }

        /// <summary>
        /// Query CommantTimeout(seconds)
        /// </summary>
        public int CommandTimeOut { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StdFilteredSelectDataDAInput()
        {
            Query = new QueryBuilder();

            IsDistinct = false;
            RowLimit = -1;
            // NOTICE デフォルトのCommandTimeoutを設定する(暫定で10分)
            CommandTimeOut = 600;
        }
    }
    #endregion

    #region 出力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public interface IStdFilteredSelectDataDAOutput
    {
        /// <summary>
        /// result of query(Typed DataTable)
        /// </summary>
        DataTable SelectDataTable { set; get; }
    }
    #endregion

    #region 出力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public class StdFilteredSelectDataDAOutput : IStdFilteredSelectDataDAOutput
    {
        /// <summary>
        /// result of query(Typed DataTable)
        /// </summary>
        public DataTable SelectDataTable { set; get; }
    }
    #endregion

    #region クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public class StdFilteredSelectDataDataAccess : BaseDataAccess<IStdFilteredSelectDataDAInput, IStdFilteredSelectDataDAOutput>
    {
        #region プロパティ(private)



        #endregion

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　habu　　    新規作成
        /// </history>
        public StdFilteredSelectDataDataAccess()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　habu　　    新規作成
        /// </history>
        public override IStdFilteredSelectDataDAOutput Execute(IStdFilteredSelectDataDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IStdFilteredSelectDataDAOutput output = new StdFilteredSelectDataDAOutput();

            try
            {
                // TableAdapter実体作成(Instanciate TableAdapter)
                object adap = Activator.CreateInstance(input.TableAdapterType);

                #region 接続の解決(manage connection using TransactionManager)

                PropertyInfo propInfo = adap.GetType().GetProperty("Connection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                SqlConnection connection = (SqlConnection)propInfo.GetValue(adap, null);

                connection = AddSqlConnection(connection);

                propInfo.SetValue(adap, connection, null);

                #endregion

                #region Base Select Commandの取得(Get Base Command from adapter's CommandCollection)

                PropertyInfo propInfoCommand = adap.GetType().GetProperty("CommandCollection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                SqlCommand[] baseCommandCollection = (SqlCommand[])propInfoCommand.GetValue(adap, null);
                SqlCommand baseCommand = baseCommandCollection[0];

                #endregion

                #region (Create filtered query text)

                SqlCommand executeCommand = new SqlCommand();
                executeCommand.Connection = connection;

                // クエリに「;」が含まれている場合は、一旦クリアする
                string baseQueryText = baseCommand.CommandText.Trim(new char[] { ';', ' ', '\r', '\n' });

                // クエリにOrderByが含まれている場合、一旦クリアする
                int orderIdx = baseQueryText.LastIndexOf("ORDER", StringComparison.InvariantCultureIgnoreCase);
                int fromIdx = baseQueryText.LastIndexOf("FROM", StringComparison.InvariantCultureIgnoreCase);

                if (orderIdx >= 0 && orderIdx > fromIdx)
                {
                    baseQueryText = baseQueryText.Substring(0, orderIdx);
                }

                string topStr = string.Empty;
                if (input.RowLimit >= 0)
                {
                    topStr = string.Format(" TOP {0} ", input.RowLimit);
                }

                executeCommand.CommandText = string.Format("SELECT {3} {4} * FROM ({0}) A {1} {2}", baseQueryText, input.Query.WhereStr, input.Query.OrderStr, (input.IsDistinct ? "DISTINCT" : string.Empty), topStr);
                executeCommand.CommandType = CommandType.Text;

                if (input.CommandTimeOut > 0)
                {
                    executeCommand.CommandTimeout = input.CommandTimeOut;
                }

                #endregion

                #region (Excecute query)

                SqlDataAdapter executeAdaper = new SqlDataAdapter(executeCommand);

                DataTable table = (DataTable)Activator.CreateInstance(input.DataTableType);
                if (input.RowLimit >= 0)
                {
                    executeAdaper.Fill(0, input.RowLimit, table);
                }
                else
                {
                    executeAdaper.Fill(table);
                }

                #endregion

                output.SelectDataTable = table;
            }
            catch (Exception e)
            {
                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("エラー内容:{0}", e.Message));

                // ＤＢエラー
                throw new CustomException(ResultCode.DBError, string.Format("エラー内容:{0}", e.Message));
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
