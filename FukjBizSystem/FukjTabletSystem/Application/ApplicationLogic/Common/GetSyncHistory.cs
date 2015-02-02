using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Sync;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSyncHistoryALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSyncHistoryALInput : IBseALInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSyncHistoryALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSyncHistoryALInput : IGetSyncHistoryALInput
    {
        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSyncHistoryALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSyncHistoryALOutput
    {
        /// <summary>
        /// SyncHistoryDownload
        /// </summary>
        SyncHistoryDataSet.SyncHistoryDataTable SyncHistoryDownload { get; set; }

        /// <summary>
        /// SyncHistoryUpload
        /// </summary>
        SyncHistoryDataSet.SyncHistoryDataTable SyncHistoryUpload { get; set; }

        /// <summary>
        /// SyncHistoryMapOVL
        /// </summary>
        SyncHistoryDataSet.SyncHistoryDataTable SyncHistoryMapOVL { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSyncHistoryALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSyncHistoryALOutput : IGetSyncHistoryALOutput
    {
        /// <summary>
        /// SyncHistoryDownload
        /// </summary>
        public SyncHistoryDataSet.SyncHistoryDataTable SyncHistoryDownload { get; set; }

        /// <summary>
        /// SyncHistoryUpload
        /// </summary>
        public SyncHistoryDataSet.SyncHistoryDataTable SyncHistoryUpload { get; set; }

        /// <summary>
        /// SyncHistoryMapOVL
        /// </summary>
        public SyncHistoryDataSet.SyncHistoryDataTable SyncHistoryMapOVL { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSyncHistoryApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSyncHistoryApplicationLogic : BaseApplicationLogic<IGetSyncHistoryALInput, IGetSyncHistoryALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "Common：GetSyncHistory";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSyncHistoryApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSyncHistoryApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSyncHistoryALOutput Execute(IGetSyncHistoryALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSyncHistoryALOutput output = new GetSyncHistoryALOutput();

            try
            {
                // 前回同期日付（時刻）を取得
                IGetSyncHistoryBLInput getInput = new GetSyncHistoryBLInput();

                getInput.Type = 1;

                output.SyncHistoryDownload = new GetSyncHistoryBusinessLogic().Execute(getInput).SyncHistory;

                getInput.Type = 2;

                output.SyncHistoryUpload = new GetSyncHistoryBusinessLogic().Execute(getInput).SyncHistory;

                getInput.Type = 3;

                output.SyncHistoryMapOVL = new GetSyncHistoryBusinessLogic().Execute(getInput).SyncHistory;
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
