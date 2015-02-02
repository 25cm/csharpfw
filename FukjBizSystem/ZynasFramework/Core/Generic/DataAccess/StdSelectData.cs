using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Zynas.Framework.Core.Base.DataAccess;
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
    public interface IStdSelectDataDAInput
    {
        /// <summary>
        /// type of TableAdapter(use typeof(XXXTableAdapter))
        /// </summary>
        Type TableAdapterType { get; set; }

        /// <summary>
        /// method name of TableAdapter(GetData, GetDataByXXX)
        /// </summary>
        string GetMethodName { get; set; }

        /// <summary>
        /// parameters to TableAdapter method
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
    public class StdSelectDataDAInput : IStdSelectDataDAInput
    {
        /// <summary>
        /// type of TableAdapter(use typeof(XXXTableAdapter))
        /// </summary>
        public Type TableAdapterType { get; set; }

        /// <summary>
        /// method name of TableAdapter(GetData, GetDataByXXX)
        /// </summary>
        public string GetMethodName { get; set; }

        /// <summary>
        /// parameters to TableAdapter method
        /// </summary>
        public List<object> ValueList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StdSelectDataDAInput()
        {
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
    public interface IStdSelectDataDAOutput
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
    public class StdSelectDataDAOutput : IStdSelectDataDAOutput
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
    public class StdSelectDataDataAccess : BaseDataAccess<IStdSelectDataDAInput, IStdSelectDataDAOutput>
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
        public StdSelectDataDataAccess()
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
        public override IStdSelectDataDAOutput Execute(IStdSelectDataDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IStdSelectDataDAOutput output = new StdSelectDataDAOutput();

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

                // Selectの実行
                MethodInfo methInfo = adap.GetType().GetMethod(input.GetMethodName);

                output.SelectDataTable = (DataTable)methInfo.Invoke(adap, input.ValueList.ToArray());
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
