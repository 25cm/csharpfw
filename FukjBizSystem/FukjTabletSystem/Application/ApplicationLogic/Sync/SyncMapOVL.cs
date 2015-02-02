using System;
using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Sync;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISyncMapOVLALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISyncMapOVLALInput : IBseALInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyncMapOVLALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SyncMapOVLALInput : ISyncMapOVLALInput
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
    //  インターフェイス名 ： ISyncMapOVLALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISyncMapOVLALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyncMapOVLALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SyncMapOVLALOutput : ISyncMapOVLALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyncMapOVLApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SyncMapOVLApplicationLogic : BaseApplicationLogic<ISyncMapOVLALInput, ISyncMapOVLALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TopMenu：SyncMapOVL";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SyncMapOVLApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SyncMapOVLApplicationLogic()
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
        /// 2014/07/02　HuyTX　　    新規作成
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
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISyncMapOVLALOutput Execute(ISyncMapOVLALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISyncMapOVLALOutput output = new SyncMapOVLALOutput();

            try
            {
                // マップOVL同期
                short thisType = 3;

                // 今回同期日時
                DateTime thisSyncDate = DateTime.Now;

                // 前回同期日時取得
                IGetSyncHistoryBLInput historyInput = new GetSyncHistoryBLInput();

                // マップOVL同期
                historyInput.Type = thisType;

                IGetSyncHistoryBLOutput historyOutput = new GetSyncHistoryBusinessLogic().Execute(historyInput);
                
                // Pullデータ取得（リモートSQLSV→ローカルMDB）
                IGetMapOVLFromSqlsvBLInput getPullInput = new GetMapOVLFromSqlsvBLInput();

                getPullInput.LastUpdateFrom = historyOutput.SyncHistory.Count > 0 ? historyOutput.SyncHistory[0].LastSyncDate : new DateTime(2014, 1, 1);

                getPullInput.LastUpdateTo = thisSyncDate;

                IGetMapOVLFromSqlsvBLOutput getPullOutput = new GetMapOVLFromSqlsvBusinessLogic().Execute(getPullInput);

                // Pushデータ取得（ローカルMDB→リモートSQLSV）
                IGetMapOVLFromMDBBLInput getPushInput = new GetMapOVLFromMDBBLInput();

                getPushInput.LastUpdateFrom = historyOutput.SyncHistory.Count > 0 ? historyOutput.SyncHistory[0].LastSyncDate : new DateTime(2014, 1, 1);

                getPushInput.LastUpdateTo = thisSyncDate;

                IGetMapOVLFromMDBBLOutput getPushOutput = new GetMapOVLFromMDBBusinessLogic().Execute(getPushInput);

                // Push実行
                if (getPushOutput.Bitmaps.Count > 0 || getPushOutput.Object.Count > 0)
                {
                    try
                    {
                        // トランザクション開始
                        StartTransaction();

                        IReflectMapOVLToSqlsvBLInput pushInput = new ReflectMapOVLToSqlsvBLInput();

                        pushInput.Bitmaps = getPushOutput.Bitmaps;

                        pushInput.Object = getPushOutput.Object;

                        new ReflectMapOVLToSqlsvBusinessLogic().Execute(pushInput);

                        // コミット
                        CompleteTransaction();
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        // トランザクション終了
                        EndTransaction();

                        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
                    }
                }
                
                // Pull実行
                if (getPullOutput.Bitmaps.Count > 0 || getPullOutput.Object.Count > 0)
                {
                    try
                    {
                        IReflectMapOVLToMDBBLInput pullInput = new ReflectMapOVLToMDBBLInput();

                        pullInput.Bitmaps = getPullOutput.Bitmaps;

                        pullInput.Object = getPullOutput.Object;

                        new ReflectMapOVLToMDBBusinessLogic().Execute(pullInput);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
                    }
                }


                // 前回同期日時更新
                SyncHistoryDataSet.SyncHistoryDataTable syncHistory = new SyncHistoryDataSet.SyncHistoryDataTable();

                syncHistory.AddSyncHistoryRow(thisType, thisSyncDate);

                if (historyOutput.SyncHistory.Count > 0)
                {
                    // Update
                    syncHistory[0].AcceptChanges();
                    syncHistory[0].SetModified();
                }
                else
                {
                    // Insert
                    syncHistory[0].AcceptChanges();
                    syncHistory[0].SetAdded();
                }

                IReflectSyncHistoryBLInput updateInput = new ReflectSyncHistoryBLInput();

                updateInput.SyncHistory = syncHistory;

                new ReflectSyncHistoryBusinessLogic().Execute(updateInput);

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
