using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Transactions;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Base.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TransactionManager
    /// <summary>
    /// トランザクション管理クラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/05/20　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class TransactionManager
    {
        #region 静的プロパティ(private)

        /// <summary>
        /// 
        /// </summary>
        // マルチスレッド対応
        private static Dictionary<Thread, Stack<TransactionManager>> transactionManagers = new Dictionary<Thread, Stack<TransactionManager>>();
        //private static Stack<TransactionManager> transactionManagers = new Stack<TransactionManager>();

        #endregion

        #region 静的メソッド(public)

        #region CreateTran
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateTran
        /// <summary>
        /// トランザクション管理クラスの実体作成
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>クラスの実体</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// 2010/11/04　稗田　　    修正(分離レベルをSnapshotに変更)
        /// 2010/11/25　稗田　　    修正(分離レベルをReadCommitted(DBの設定によりReadCommittedSnapshotになる)に変更)
        /// 2014/10/24　土生　　    修正(タイムアウト値のデフォルトを変更)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void CreateTran(params int[] timeout)
        {
            if (!transactionManagers.ContainsKey(Thread.CurrentThread))
            {
                transactionManagers.Add(Thread.CurrentThread, new Stack<TransactionManager>());
            }

            // 2011/11/17 障害対応No1015 Hieda Mod Start
            transactionManagers[Thread.CurrentThread].Push(
                new TransactionManager(new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted, Timeout = new System.TimeSpan(0, timeout.Length > 0 ? timeout[0] : FrameworkParams.DEFAULT_TRANSACTION_TIMEOUT, 0) }));
            
            //transactionManagers[Thread.CurrentThread].Push(
            //    new TransactionManager(new TransactionOptions()
            //        //{IsolationLevel = IsolationLevel.Snapshot, Timeout = new System.TimeSpan(0, timeout.Length > 0 ? timeout[0] : 1, 0)}));
            //        {IsolationLevel = IsolationLevel.ReadCommitted, Timeout = new System.TimeSpan(0, timeout.Length > 0 ? timeout[0] : 1, 0)}));
            //        //{IsolationLevel = IsolationLevel.ReadCommitted, Timeout = new System.TimeSpan(0, 1, 0)}));
            //        //{IsolationLevel = IsolationLevel.Serializable, Timeout = new System.TimeSpan(0, 1, 0)}));
            // 2011/11/17 障害対応No1015 Hieda Mod End
        }
        #endregion

        #region ReleaseTran
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ReleaseTran
        /// <summary>
        /// トランザクション管理クラスの実体解放
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void ReleaseTran()
        {
            if (transactionManagers[Thread.CurrentThread].Count > 0)
            {
                try
                {
                    transactionManagers[Thread.CurrentThread].Peek().Dispose();
                }
                finally
                {
                    transactionManagers[Thread.CurrentThread].Pop();
                }
                // 2011/11/17 障害対応No1015 Hieda Mod Start
                //transactionManagers[Thread.CurrentThread].Peek().Dispose();
                //transactionManagers[Thread.CurrentThread].Pop();
                // 2011/11/17 障害対応No1015 Hieda Mod End
            }
        }
        #endregion

        #region CompleteTran
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CompleteTran
        /// <summary>
        /// トランザクションの完了
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void CompleteTran()
        {
            if (transactionManagers[Thread.CurrentThread].Count > 0)
            {
                transactionManagers[Thread.CurrentThread].Peek().Complete();
            }
        }
        #endregion

        #region AddSqlConnectionTran
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddSqlConnectionTran
        /// <summary>
        /// トランザクションの完了
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="connection">接続情報</param>
        /// <returns>接続情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static SqlConnection AddSqlConnectionTran(SqlConnection connection)
        {
            if (transactionManagers.Count != 0 && transactionManagers.ContainsKey(Thread.CurrentThread) && transactionManagers[Thread.CurrentThread].Count > 0)
            {
                return transactionManagers[Thread.CurrentThread].Peek().AddSqlConnection(connection);
            }
            else
            {
                return connection;
            }
        }
        #endregion

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 接続文字列をキーとする接続のディクショナリ
        /// </summary>
        private Dictionary<string, SqlConnection> connections;

        /// <summary>
        /// トランザクションスコープ
        /// </summary>
        private TransactionScope transactionScope;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TransactionManager
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="transactionOptions">トランザクションのオプション</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private TransactionManager(TransactionOptions transactionOptions)
        {
            // 接続文字列をキーとする接続のディクショナリを作成
            connections = new Dictionary<string, SqlConnection>();

            // トランザクションスコープを作成
            transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions);
        }
        #endregion

        #region メソッド(private)

        #region Dispose
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Dispose
        /// <summary>
        /// クラスの解放
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="transactionOptions">トランザクションのオプション</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Dispose()
        {
            foreach (SqlConnection connection in connections.Values)
            {
                connection.Close();
            }
            transactionScope.Dispose();
        }
        #endregion

        #region Complete
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Complete
        /// <summary>
        /// トランザクションの完了
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Complete()
        {
            transactionScope.Complete();
        }
        #endregion

        #region AddSqlConnection
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddSqlConnection
        /// <summary>
        /// トランザクション時に同じ接続先のセッションを１つにまとめる
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="connection">接続情報</param>
        /// <returns>接続情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlConnection AddSqlConnection(SqlConnection connection)
        {
            SqlConnection result;

            if (connection == null)
            {
                result = null;
            }
            else if (connections.ContainsKey(connection.ConnectionString))
            {
                // 2011/11/17 障害対応No1015 Hieda Add Start
                // トランザクションステータスのチェック
                if (Transaction.Current.TransactionInformation.Status != TransactionStatus.Active)
                {
                    throw new CustomException(ResultCode.DBError, "トランザクション異常");
                }
                // 2011/11/17 障害対応No1015 Hieda Add End

                // 保持する接続に、同じ接続文字列の接続がある場合は保持する接続を返す
                result = connections[connection.ConnectionString];
            }
            else
            {
                // 保持する接続に、同じ接続文字列の接続がない場合は、引数の接続を追加して返す
                connections.Add(connection.ConnectionString, connection);
                // DBへ接続する
                connection.Open();
                result = connection;
            }

            return result;
        }
        #endregion

        #endregion
    }
    #endregion
}
