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
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public interface IBaseStdSelectDataForUpdateDAInput
    {
        /// <summary>
        /// 
        /// </summary>
        string TableName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        List<string> SelColNameList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        List<string> WhereColNameList { get; set; }
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
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public class BaseStdSelectDataForUpdateDAInput : IBaseStdSelectDataForUpdateDAInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> SelColNameList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> WhereColNameList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> ValueList { get; set; }

        public BaseStdSelectDataForUpdateDAInput()
        {
            SelColNameList = new List<string>();
            WhereColNameList = new List<string>();
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
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    public interface IBaseStdSelectDataForUpdateDAOutput
    {
        /// <summary>
        /// 
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
    public class BaseStdSelectDataForUpdateDAOutput : IBaseStdSelectDataForUpdateDAOutput
    {
        /// <summary>
        /// 
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
    public class BaseStdSelectDataForUpdateDataAccess : BaseDataAccess<IBaseStdSelectDataForUpdateDAInput, IBaseStdSelectDataForUpdateDAOutput>
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
        public BaseStdSelectDataForUpdateDataAccess(string connectionString)
        {
            connection.ConnectionString = connectionString;
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
        public override IBaseStdSelectDataForUpdateDAOutput Execute(IBaseStdSelectDataForUpdateDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IBaseStdSelectDataForUpdateDAOutput output = new BaseStdSelectDataForUpdateDAOutput();

            try
            {
                // 接続の解決
                connection = AddSqlConnection(connection);
                
                output.SelectDataTable = OptimisticLockUtility.GetDataForUpdate(connection, input.TableName, input.SelColNameList, input.WhereColNameList, input.ValueList);
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
