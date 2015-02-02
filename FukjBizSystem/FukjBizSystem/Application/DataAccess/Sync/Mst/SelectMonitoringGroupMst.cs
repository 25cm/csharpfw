using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MonitoringGroupMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.Sync.Mst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMonitoringGroupMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface ISelectMonitoringGroupMstDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMonitoringGroupMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectMonitoringGroupMstDAInput : ISelectMonitoringGroupMstDAInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMonitoringGroupMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface ISelectMonitoringGroupMstDAOutput
    {
        /// <summary>
        /// MonitoringGroupMst
        /// </summary>
        MonitoringGroupMstDataSet.MonitoringGroupMstDataTable MonitoringGroupMst { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMonitoringGroupMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectMonitoringGroupMstDAOutput : ISelectMonitoringGroupMstDAOutput
    {
        /// <summary>
        /// MonitoringGroupMst
        /// </summary>
        public MonitoringGroupMstDataSet.MonitoringGroupMstDataTable MonitoringGroupMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMonitoringGroupMstDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectMonitoringGroupMstDataAccess : BaseDataAccess<ISelectMonitoringGroupMstDAInput, ISelectMonitoringGroupMstDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MonitoringGroupMstTableAdapter tableAdapter = new MonitoringGroupMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMonitoringGroupMstDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMonitoringGroupMstDataAccess()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMonitoringGroupMstDAOutput Execute(ISelectMonitoringGroupMstDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMonitoringGroupMstDAOutput output = new SelectMonitoringGroupMstDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MonitoringGroupMst = tableAdapter.GetData();

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
