using System;
using System.Data;
using System.IO;
using System.Reflection;
using FukjBizSystem;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.BusinessLogic.Sync;
using FukjTabletSystem.Properties;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPushTransactionDataALInput
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
    interface IPushTransactionDataALInput : IBseALInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PushTransactionDataALInput
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
    class PushTransactionDataALInput : IPushTransactionDataALInput
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
    //  インターフェイス名 ： IPushTransactionDataALOutput
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
    interface IPushTransactionDataALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PushTransactionDataALOutput
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
    class PushTransactionDataALOutput : IPushTransactionDataALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PushTransactionDataApplicationLogic
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
    class PushTransactionDataApplicationLogic : BaseApplicationLogic<IPushTransactionDataALInput, IPushTransactionDataALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TopMenu：PushTransactionData";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PushTransactionDataApplicationLogic
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
        public PushTransactionDataApplicationLogic()
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
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPushTransactionDataALOutput Execute(IPushTransactionDataALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPushTransactionDataALOutput output = new PushTransactionDataALOutput();

            try
            {
                #region 同期日付管理（取得）
                                
                // 前回同期(ダウンロード)日時取得
                IGetSyncHistoryBLInput historyDLInput = new GetSyncHistoryBLInput();

                historyDLInput.Type = 1;

                IGetSyncHistoryBLOutput historyDLOutput = new GetSyncHistoryBusinessLogic().Execute(historyDLInput);

                // ダウンロードデータなし（Boundaryでチェックしている為、想定外）
                if (historyDLOutput.SyncHistory.Count == 0)
                {
                    throw new CustomException(0, "アップロードする検査結果データが存在しません。");
                }

                // アップロード
                short thisType = 2;
                
                // 今回同期日時
                DateTime thisSyncDate = historyDLOutput.SyncHistory[0].LastSyncDate;

                // 前回同期日時取得
                IGetSyncHistoryBLInput historyInput = new GetSyncHistoryBLInput();

                historyInput.Type = thisType;

                IGetSyncHistoryBLOutput historyOutput = new GetSyncHistoryBusinessLogic().Execute(historyInput);
                
                #endregion

                // ローカルデータベースからアップロードデータ取得
                IGetTransactionDataFromCeBLOutput getOutput = new GetTransactionDataFromCeBusinessLogic().Execute(new GetTransactionDataFromCeBLInput());
                                
                try
                {
                    // 検査依頼のステータスを更新
                    foreach (KensaIraiTblDataSet.KensaIraiTblRow row in getOutput.KensaIraiTbl)
                    {
                        // 返却
                        row.KensaIraiStatusKbn = "40";
                    }

                    // トランザクション開始
                    StartTransaction();

                    // 浄化槽台帳履歴を作成（連番の採番を行うためにトランザクション内で行う）
                    JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable jokasoDaichiRirekiTbl = new JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable();
                    foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow daicho in getOutput.JokasoDaichoMst)
                    {
                        if (daicho.RowState != DataRowState.Modified)
                        {
                            continue;
                        }

                        // 浄化槽台帳履歴の最大番号を取得
                        IGetMaxRirekiRenbanBLInput getRenbanInput = new GetMaxRirekiRenbanBLInput();
                        getRenbanInput.HokenjoCd = daicho.JokasoHokenjoCd;
                        getRenbanInput.TorokuNendo = daicho.JokasoTorokuNendo;
                        getRenbanInput.Renban = daicho.JokasoRenban;
                        IGetMaxRirekiRenbanBLOutput getRenbanOutput = new GetMaxRirekiRenbanBusinessLogic().Execute(getRenbanInput);

                        // 浄化槽台帳をサーバから取得（現在の状態を履歴に退避する）
                        IGetJokasoDaichoMstByKeyFromSqlsvBLInput selectJokasoDaichoMstInput = new GetJokasoDaichoMstByKeyFromSqlsvBLInput();
                        // 保健所コード
                        selectJokasoDaichoMstInput.HokenjoCd = daicho.JokasoHokenjoCd;
                        // 登録年度
                        selectJokasoDaichoMstInput.TorokuNendo = daicho.JokasoTorokuNendo;
                        // 連番
                        selectJokasoDaichoMstInput.Renban = daicho.JokasoRenban;
                        // 検索
                        IGetJokasoDaichoMstByKeyFromSqlsvBLOutput selectJokasoDaichoMstOutput = new GetJokasoDaichoMstByKeyFromSqlsvBusinessLogic().Execute(selectJokasoDaichoMstInput);
                        
                        // 登録データを作成
                        JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblRow newRow = jokasoDaichiRirekiTbl.NewJokasoDaichiRirekiTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in jokasoDaichiRirekiTbl.Columns)
                        {
                            if (col.ColumnName == "JokasoRirekiRenban")
                            {
                                // 最大番号＋１
                                if (string.IsNullOrEmpty(getRenbanOutput.MaxJokasoRirekiRenban))
                                {
                                    newRow.JokasoRirekiRenban = "001";
                                }
                                else
                                {
                                    newRow.JokasoRirekiRenban = string.Format("{0:000}", (int.Parse(getRenbanOutput.MaxJokasoRirekiRenban) + 1));
                                }
                            }
                            else
                            {
                                newRow[col.ColumnName] = selectJokasoDaichoMstOutput.JokasoDaichoMst[0][col.ColumnName];
                            }
                        }

                        jokasoDaichiRirekiTbl.AddJokasoDaichiRirekiTblRow(newRow);
                        newRow.AcceptChanges();
                        newRow.SetAdded();
                    }

                    // サーバデータベースを更新
                    IReflectTransactionDataToSqlsvBLInput updInput = new ReflectTransactionDataToSqlsvBLInput();

                    // 現場写真
                    updInput.GenbaShashinTbl = getOutput.GenbaShashinTbl;
                    // 浄化槽台帳マスタ
                    updInput.JokasoDaichoMst = getOutput.JokasoDaichoMst;
                    // 浄化槽保有単位装置グループ
                    updInput.JokasoHoyuTaniSochiGroupTbl = getOutput.JokasoHoyuTaniSochiGroupTbl;
                    // 浄化槽メモ
                    updInput.JokasoMemoTbl = getOutput.JokasoMemoTbl;
                    // 検査依頼
                    updInput.KensaIraiTbl = getOutput.KensaIraiTbl;
                    // 検査結果
                    updInput.KensaKekkaTbl = getOutput.KensaKekkaTbl;
                    // 再採水
                    updInput.SaiSaisuiTbl = getOutput.SaiSaisuiTbl;
                    // 所見結果
                    updInput.ShokenKekkaTbl = getOutput.ShokenKekkaTbl;
                    // 所見結果補足
                    updInput.ShokenKekkaHosokuTbl = getOutput.ShokenKekkaHosokuTbl;
                    // モニタリング
                    updInput.MonitoringTbl = getOutput.MonitoringTbl;
                    // 浄化槽台帳履歴
                    updInput.JokasoDaichiRirekiTbl = jokasoDaichiRirekiTbl;
                    // 外観検査結果
                    updInput.GaikanKensaKekkaTbl = getOutput.GaikanKensaKekkaTbl;

                    // 更新
                    new ReflectTransactionDataToSqlsvBusinessLogic().Execute(updInput);
                    
                    try
                    {
                        // トランザクション開始
                        StartTransactionCe();
                        
                        #region 同期日付管理（更新）

                        // 前回同期日時更新
                        FukjTabletSystem.Application.DataSet.SQLCE.SyncHistoryDataSet.SyncHistoryDataTable syncHistory
                            = new FukjTabletSystem.Application.DataSet.SQLCE.SyncHistoryDataSet.SyncHistoryDataTable();

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

                // 現場写真ファイルのコピー
                foreach (GenbaShashinTblDataSet.GenbaShashinTblRow shashin in getOutput.GenbaShashinTbl)
                {
                    string sourcePath = Path.Combine(Settings.Default.FileDirectory, shashin.GenbaShashinFilePath);
                    string targetPath = Path.Combine(SettingReader.SharedFolderDirectory, shashin.GenbaShashinFilePath);

                    try
                    {
                        FileUtility.CopyToServer(sourcePath, targetPath, false);
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
