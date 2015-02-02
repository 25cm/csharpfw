using System;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using FukjBizSystem;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.BusinessLogic.Sync;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Properties;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPullTransactionDataALInput
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
    interface IPullTransactionDataALInput : IBseALInput
    {
        /// <summary>
        /// 検査予定日
        /// </summary>
        DateTime Yoteibi { get; set; }

        /// <summary>
        /// 担当者コード
        /// </summary>
        string TantoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PullTransactionDataALInput
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
    class PullTransactionDataALInput : IPullTransactionDataALInput
    {
        /// <summary>
        /// 検査予定日
        /// </summary>
        public DateTime Yoteibi { get; set; }

        /// <summary>
        /// 担当者コード
        /// </summary>
        public string TantoshaCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査予定日[{0}], 担当者コード[{1}]", this.Yoteibi.ToString("yyyy年MM月dd日"), this.TantoshaCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPullTransactionDataALOutput
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
    interface IPullTransactionDataALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PullTransactionDataALOutput
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
    class PullTransactionDataALOutput : IPullTransactionDataALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PullTransactionDataApplicationLogic
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
    class PullTransactionDataApplicationLogic : BaseApplicationLogic<IPullTransactionDataALInput, IPullTransactionDataALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TopMenu：PullTransactionData";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PullTransactionDataApplicationLogic
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
        public PullTransactionDataApplicationLogic()
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
        public override IPullTransactionDataALOutput Execute(IPullTransactionDataALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPullTransactionDataALOutput output = new PullTransactionDataALOutput();

            try
            {
                #region 前回データのステータスリカバリ

                try
                {
                    // 持出し中データの取得
                    IGetKensaIraiTblFromCeBLOutput iraiOutput = new GetKensaIraiTblFromCeBusinessLogic().Execute(new GetKensaIraiTblFromCeBLInput());

                    StartTransaction();

                    // 前回データが持出し中のままの場合は、持出し可能状態に戻す
                    IReflectKensaIraiStatusKbnToSqlsvBLInput statusInput = new ReflectKensaIraiStatusKbnToSqlsvBLInput();
                    statusInput.KensaIraiTbl = iraiOutput.KensaIraiTbl;
                    new ReflectKensaIraiStatusKbnToSqlsvBusinessLogic().Execute(statusInput);

                    CompleteTransaction();
                }
                finally
                {
                    EndTransaction();
                }

                #endregion

                #region 同期日付管理（取得）

                // ダウンロード
                short thisType = 1;

                // 今回同期日時
                DateTime thisSyncDate = input.Yoteibi;

                // 前回同期日時取得
                IGetSyncHistoryBLInput historyInput = new GetSyncHistoryBLInput();

                historyInput.Type = thisType;

                IGetSyncHistoryBLOutput historyOutput = new GetSyncHistoryBusinessLogic().Execute(historyInput);

                #endregion

                // サーバから対象データを取得
                IGetTransactionDataFromSqlsvBLInput getInput = new GetTransactionDataFromSqlsvBLInput();
                // 検査予定日
                getInput.Yoteibi = input.Yoteibi;
                // 担当者コード
                getInput.TantoshaCd = input.TantoshaCd;
                // 検索
                IGetTransactionDataFromSqlsvBLOutput getOutput = new GetTransactionDataFromSqlsvBusinessLogic().Execute(getInput);

                // 検査依頼のステータスを"30"に更新
                FukjBizSystem.Application.DataSet.KensaIraiTblDataSet.KensaIraiTblDataTable updKensaIraiTbl = new FukjBizSystem.Application.DataSet.KensaIraiTblDataSet.KensaIraiTblDataTable();
                
                foreach (KensaIraiTblDataSet.KensaIraiTblRow row in getOutput.KensaIraiTbl)
                {
                    // サーバデータの更新用
                    FukjBizSystem.Application.DataSet.KensaIraiTblDataSet.KensaIraiTblRow modRow = updKensaIraiTbl.NewKensaIraiTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in updKensaIraiTbl.Columns)
                    {
                        modRow[col.ColumnName] = row[col.ColumnName];
                    }

                    DateTime now = DateTime.Now;

                    // 持出し中（サーバデータの更新）
                    modRow.KensaIraiStatusKbn = "30";
                    modRow.UpdateDt = now;
                    modRow.UpdateTarm = Dns.GetHostName();
                    modRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    updKensaIraiTbl.AddKensaIraiTblRow(modRow);
                    modRow.AcceptChanges();
                    modRow.SetModified();

                    // 持出し中（ローカルに登録するデータを更新）
                    row.KensaIraiStatusKbn = "30";
                    row.UpdateDt = now;
                    row.UpdateTarm = Dns.GetHostName();
                    row.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    row.AcceptChanges();
                    row.SetAdded();
                }

                try
                {
                    // トランザクション開始
                    StartTransactionCe();

                    // ローカルデータベースを更新（削除→登録）
                    IReflectTransactionDataToCeBLInput reflectInput = new ReflectTransactionDataToCeBLInput();

                    // 検査依頼
                    reflectInput.KensaIraiTbl = getOutput.KensaIraiTbl;
                    // 検査依頼履歴
                    reflectInput.KensaIraiHistTbl = getOutput.KensaIraiHistTbl;
                    // 現場写真
                    reflectInput.GenbaShashinTbl = getOutput.GenbaShashinTbl;
                    // 関連ファイル
                    reflectInput.KensaIraiKanrenFileTbl = getOutput.KensaIraiKanrenFileTbl;
                    // 検査結果
                    reflectInput.KensaKekkaTbl = getOutput.KensaKekkaTbl;
                    // 再採水
                    reflectInput.SaiSaisuiTbl = getOutput.SaiSaisuiTbl;
                    // 所見結果
                    reflectInput.ShokenKekkaTbl = getOutput.ShokenKekkaTbl;
                    // 所見結果補足文
                    reflectInput.ShokenKekkaHosokuTbl = getOutput.ShokenKekkaHosokuTbl;
                    // モニタリング
                    reflectInput.MonitoringTbl = getOutput.MonitoringTbl;
                    // 浄化槽台帳
                    reflectInput.JokasoDaichoMst = getOutput.JokasoDaichoMst;
                    // 浄化槽保有単位装置グループ
                    reflectInput.JokasoHoyuTaniSochiGroupTbl = getOutput.JokasoHoyuTaniSochiGroupTbl;
                    // 浄化槽メモ
                    reflectInput.JokasoMemoTbl = getOutput.JokasoMemoTbl;
                    // 外観検査結果
                    reflectInput.GaikanKensaKekkaTbl = getOutput.GaikanKensaKekkaTbl;

                    // 更新処理
                    IReflectTransactionDataToCeBLOutput reflectOutput = new ReflectTransactionDataToCeBusinessLogic().Execute(reflectInput);

                    #region 同期日付管理（更新）

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

                    #endregion
                    
                    try
                    {
                        StartTransaction();

                        IReflectTransactionDataToSqlsvBLInput statusUpdInput = new ReflectTransactionDataToSqlsvBLInput();

                        // 検査依頼のステータスを更新
                        statusUpdInput.KensaIraiTbl = updKensaIraiTbl;

                        // 更新処理
                        IReflectTransactionDataToSqlsvBLOutput statusUpdOutput = new ReflectTransactionDataToSqlsvBusinessLogic().Execute(statusUpdInput);

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
                    }

                    // コミット
                    CompleteTransactionCe();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    // トランザクション終了
                    EndTransactionCe();
                }
                
                // ローカルファイルの削除
                DirectoryInfo[] DirInfos = new DirectoryInfo(FukjTabletSystem.Properties.Settings.Default.FileDirectory).GetDirectories();
                for (int i = 0; i < DirInfos.Length; i++)
                {
                    DirInfos[i].Delete(true);
                }
                
                // 現場写真ファイルのコピー
                foreach (GenbaShashinTblDataSet.GenbaShashinTblRow shashin in getOutput.GenbaShashinTbl)
                {
                    string sourcePath = Path.Combine(SettingReader.SharedFolderDirectory, shashin.GenbaShashinFilePath);
                    string targetPath = Path.Combine(Settings.Default.FileDirectory, shashin.GenbaShashinFilePath);

                    try
                    {
                        FileUtility.CopyToLocal(sourcePath, targetPath, true);
                    }
                    catch
                    {
                    }
                }

                // 検査依頼関連ファイルのコピー
                foreach (KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow kanrenFile in getOutput.KensaIraiKanrenFileTbl)
                {
                    string sourcePath = Path.Combine(SettingReader.SharedFolderDirectory, kanrenFile.KensaIraiKanrenFilePath);
                    string targetPath = Path.Combine(Settings.Default.FileDirectory, kanrenFile.KensaIraiKanrenFilePath);

                    try
                    {
                        FileUtility.CopyToLocal(sourcePath, targetPath, true);
                    }
                    catch
                    {
                    }
                }
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
