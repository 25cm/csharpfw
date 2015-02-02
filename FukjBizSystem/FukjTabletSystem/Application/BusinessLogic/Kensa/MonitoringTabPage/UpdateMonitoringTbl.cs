using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.MonitoringTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateMonitoringTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateMonitoringTblBLInput : IUpdateMonitoringTblDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateMonitoringTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateMonitoringTblBLInput : IUpdateMonitoringTblBLInput
    {
        /// <summary>
        /// MonitoringTbl
        /// </summary>
        public MonitoringTblDataSet.MonitoringTblDataTable MonitoringTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateMonitoringTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateMonitoringTblBLOutput : IUpdateMonitoringTblDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateMonitoringTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateMonitoringTblBLOutput : IUpdateMonitoringTblBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateMonitoringTblBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateMonitoringTblBusinessLogic : BaseBusinessLogic<IUpdateMonitoringTblBLInput, IUpdateMonitoringTblBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateMonitoringTblBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateMonitoringTblBusinessLogic()
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
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateMonitoringTblBLOutput Execute(IUpdateMonitoringTblBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateMonitoringTblBLOutput output = new UpdateMonitoringTblBLOutput();

            try
            {
                new UpdateMonitoringTblDataAccess().Execute(input);
            }
            catch
            {
                throw;
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
