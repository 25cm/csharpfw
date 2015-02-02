using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Zynas.Framework.Core.Common.DataAccess;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Base.DataAccess
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    public interface IBaseStdDeleteDataDAInput
    {
        /// <summary>
        /// 
        /// </summary>
        DataTable TargetDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        List<string> KeyColNameList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        List<object> ValueList { get; set; }
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    public class BaseStdDeleteDataDAInput : IBaseStdDeleteDataDAInput
    {
        /// <summary>
        /// 
        /// </summary>
        public DataTable TargetDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> KeyColNameList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<object> ValueList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseStdDeleteDataDAInput()
        {
            KeyColNameList = new List<string>();
            ValueList = new List<object>();
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    public interface IBaseStdDeleteDataDAOutput
    {
        /// <summary>
        /// Deleted Row Count
        /// </summary>
        int RowCount { get; set; }
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    public class BaseStdDeleteDataDAOutput : IBaseStdDeleteDataDAOutput
    {
        /// <summary>
        /// Deleted Row Count
        /// </summary>
        public int RowCount { get; set; }
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    public class BaseStdDeleteDataDataAccess : BaseDataAccess<IBaseStdDeleteDataDAInput, IBaseStdDeleteDataDAOutput>
    {
        #region プロパティ(private)

        private SqlConnection connection = new global::System.Data.SqlClient.SqlConnection();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="connectionString">ConnectionString.Typycally get from app.config</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　habu　　    新規作成
        /// </history>
        public BaseStdDeleteDataDataAccess(string connectionString)
        {
            connection.ConnectionString = connectionString;
        }
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
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        public BaseStdDeleteDataDataAccess()
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
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        public override IBaseStdDeleteDataDAOutput Execute(IBaseStdDeleteDataDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IBaseStdDeleteDataDAOutput output = new BaseStdDeleteDataDAOutput();

            try
            {
                // 接続の解決
                connection = AddSqlConnection(connection);

                // build DELETE sql command
                SqlCommand command = StdDBUpdateUtility.CreateDeleteByKeyCommand(connection, input.TableName, input.KeyColNameList, input.ValueList);

                // execute DELETE
                output.RowCount = command.ExecuteNonQuery();
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
