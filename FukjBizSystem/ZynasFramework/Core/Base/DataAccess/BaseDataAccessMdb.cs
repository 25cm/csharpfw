﻿using System.Data.OleDb;
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
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public abstract class BaseDataAccessMdb<INPUT, OUTPUT>
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
        /// 2014/08/05　豊田　　    新規作成
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
        /// 2014/08/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public OleDbConnection AddSqlConnection(OleDbConnection connection)
        {
            return TransactionManagerMdb.AddSqlConnectionTran(connection);
        }
        #endregion

        #endregion

    }
    #endregion
}
