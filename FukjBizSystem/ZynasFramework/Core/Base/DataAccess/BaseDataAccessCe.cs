using System.Data.SqlServerCe;
using Zynas.Framework.Core.Base.Common;

namespace Zynas.Framework.Core.Base.DataAccess
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BaseApplicationLogic
    /// <summary>
    /// ベースデータアクセスクラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/12　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public abstract class BaseDataAccessCe<INPUT, OUTPUT>
    {
        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： Execute
        /// <summary>
        /// データアクセスの実行
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/12　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public abstract OUTPUT Execute(INPUT input);
        #endregion

        #endregion

        #region メソッド(protected)

        #region AddSqlConnection
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： AddSqlConnection
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
        public SqlCeConnection AddSqlConnection(SqlCeConnection connection)
        {
            return TransactionManagerCe.AddSqlConnectionTran(connection);
        }
        #endregion

        #endregion

    }
    #endregion
}
