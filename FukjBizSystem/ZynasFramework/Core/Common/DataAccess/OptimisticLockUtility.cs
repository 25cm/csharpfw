using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class OptimisticLockUtility
    {
        #region 定数

        /// <summary>
        /// 更新日カラム名
        /// </summary>
        public static readonly string COL_NAME_UPDATE_DT = "UpdateDt";

        #endregion

        #region 楽観ロック

        #region CheckOptimisticLock
        /// <summary>
        /// 更新データの楽観ロックチェック(材料手配システムテーブル向け)
        /// 
        /// </summary>
        /// <param name="loadData">更新データ(ロード時の更新日時を保持)</param>
        /// <param name="currentData">現在のDBデータ(最新の更新日時を保持)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/04/14　土生　　    新規作成
        /// </history>
        public static bool CheckOptimisticLockRow(DataRow loadData, DataRow currentData)
        {
            // 楽観ロックチェック
            // 現在のDBデータに更新日が設定されていない場合、
            if (currentData[COL_NAME_UPDATE_DT] == DBNull.Value && loadData[COL_NAME_UPDATE_DT] == DBNull.Value)
            {
                return true;
            }

            // 現在のDBデータの更新日が今回更新対象と同じ場合
            if (currentData[COL_NAME_UPDATE_DT].Equals(loadData[COL_NAME_UPDATE_DT]))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region CheckOptimisticLock
        /// <summary>
        /// 更新データの楽観ロックチェック(材料手配システムテーブル向け)
        /// 
        /// </summary>
        /// <param name="loadData">更新データ(ロード時の更新日時を保持)</param>
        /// <param name="currentData">現在のDBデータ(最新の更新日時を保持)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/04/14　土生　　    新規作成
        /// </history>
        public static bool CheckOptimisticLockTable(List<string> keyColumnList, DataTable loadData, DataTable currentData)
        {
            Dictionary<string, DataRow> keyRowMap = new Dictionary<string, DataRow>();

            // 件数が異なれば、そもそも異なる
            if (loadData.Rows.Count != currentData.Rows.Count)
            {
                return false;
            }

            // 編集前データのキー値のハッシュを生成
            foreach (DataRow row in loadData.Rows)
            {
                StringBuilder keyColValues = new StringBuilder();
                foreach (string keyCol in keyColumnList)
                {
                    keyColValues.Append(row[keyCol].ToString());
                    keyColValues.Append(";");
                }

                keyRowMap.Add(keyColValues.ToString(), row);
            }

            // 編集後データのキー値のハッシュを生成
            foreach (DataRow row in currentData.Rows)
            {
                StringBuilder keyColValues = new StringBuilder();
                foreach (string keyCol in keyColumnList)
                {
                    keyColValues.Append(row[keyCol].ToString());
                    keyColValues.Append(";");
                }

                // 同じキー値の行が無い場合は、変更されていると判断する
                if (!keyRowMap.ContainsKey(keyColValues.ToString()))
                {
                    return false;
                }

                // ハッシュ値基準で判定したので、実際に同じキー値かを確認
                bool isSameKey = true;
                DataRow loadRow = keyRowMap[keyColValues.ToString()];

                foreach (string keyCol in keyColumnList)
                {
                    // 1カラムでも異なれば、異なるキーとする
                    if (!loadRow[keyCol].Equals(row[keyCol]))
                    {
                        isSameKey = false;
                    }
                }

                // 同じキー値であれば
                if (isSameKey)
                {
                    // 各行について、1行でも更新日時が異なれば、楽観ロックエラー
                    if (!CheckOptimisticLockRow(loadRow, row))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region GetDataForUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <param name="selColNameList"></param>
        /// <param name="valueList"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/04/14　土生　　    新規作成
        /// </history>
        /// <returns></returns>
        public static DataTable GetDataForUpdate(SqlConnection connection, string tableName, List<string> selColNameList, List<string> whereColNameList, List<object> valueList)
        {
            StringBuilder colNameBuf = new StringBuilder();

            // 選択列リストを生成
            // colnameList.Count > valueList.Count である事
            for (int i = 0; i < selColNameList.Count; i++)
            {
                if (i > 0)
                {
                    colNameBuf.Append(" ,");
                }
                colNameBuf.Append(string.Format("[{0}]", selColNameList[i]));
            }
            colNameBuf.Append(string.Format(" ,[{0}]", COL_NAME_UPDATE_DT));

            StringBuilder sqlTextBuf = new StringBuilder();

            // テーブル名に[]を付与すると、データベース名の指定も必要になる。
            // なので当面付与しない。テーブル名が(Transact SQLの)予約語と重複しなければ問題は無い（材料手配システムのテーブルには該当なし）
            sqlTextBuf.Append(string.Format("SELECT {0} FROM {1}", colNameBuf.ToString(), tableName));

            // 行ロック指定、共有ロック指定
            sqlTextBuf.Append(" WITH(ROWLOCK, UPDLOCK)");

            for (int i = 0; i < valueList.Count; i++)
            {
                if (i == 0)
                {
                    sqlTextBuf.Append(" WHERE");
                }
                else
                {
                    sqlTextBuf.Append(" AND");
                }

                sqlTextBuf.Append(string.Format(" [{0}] = @{1}", whereColNameList[i], whereColNameList[i]));
            }

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection;
            sqlCommand.CommandText = sqlTextBuf.ToString();
            sqlCommand.CommandType = CommandType.Text;

            // SQLパラメータ変数設定
            for (int i = 0; i < valueList.Count; i++)
            {
                sqlCommand.Parameters.Add(new SqlParameter(string.Format("@{0}", whereColNameList[i]), valueList[i]));
            }

            // アダプター初期化
            SqlDataAdapter adap = new SqlDataAdapter(sqlCommand);

            // 取得結果保持DataTable
            DataTable table = new DataTable(tableName);

            // SQL実行
            adap.Fill(table);

            // 取得結果を返す
            return table;
        }
        #endregion

        #endregion
    }
}
