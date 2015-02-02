using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Common;
using FukjTabletSystem.Application.ApplicationLogic.Sync;
using FukjTabletSystem.Application.Boundary.Kensa;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TopMenuForm
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
    public partial class TopMenuForm : FukjTabBaseForm
    {
        #region フィールド(private)
        
        /// <summary>
        /// オン／オフラインモード判定
        /// </summary>
        private bool isOnline = false;

        /// <summary>
        /// 前回ダウンロード日
        /// </summary>
        private DateTime? lastDownloadDate = null;
        
        /// <summary>
        /// 前回アップロード日
        /// </summary>
        private DateTime? lastUploadDate = null;

        /// <summary>
        /// 前回同期日時
        /// </summary>
        private DateTime? lastSyncDate = null;
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TopMenuForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TopMenuForm(bool IsOnline)
            : base()
        {
            InitializeComponent();

            isOnline = IsOnline;
        }
        #endregion

        #region イベントハンドラ

        #region TopMenuForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopMenuForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                versionLabel.Text = string.Format("Ver.{0}", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);

                SetSyncAvailable(isOnline);

                DoSearch();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region closeButton_Click
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region syncMasterButton_Click
        /// <summary>
        /// マスタ同期（ダウンロード）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void syncMasterButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                if (lastDownloadDate.HasValue && (!lastUploadDate.HasValue || lastDownloadDate.Value != lastUploadDate.Value))
                {
                    if (TabMessageBox.Show2(TabMessageBox.Type.YesNo,
                                            "ダウンロード確認",
                                            string.Format("{0}\r\n{1}",
                                                "端末内検査予定の結果がアップロードされていません。",
                                                "端末内のデータは破棄されますが宜しいですか？"))
                        != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                // 検査予定日
                DateTime targertDate;

                using (SelectDateDialog dateDiag = new SelectDateDialog())
                {
                    dateDiag.ShowDialog();

                    if (dateDiag.DialogResult != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }

                    targertDate = dateDiag.SelectedDate.Value;
                }

                object[] ret;

                using (ProgressDialog sg = new ProgressDialog(new DoWorkEventHandler(PullMasterData_DoWork), targertDate))
                {
                    //進行状況ダイアログを表示する
                    DialogResult result = sg.ShowDialog(this);

                   // 結果を取得する
                    ret = (object[])sg.Result;
                }
                
                DoSearch();

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region PullMasterData_DoWork(object sender, DoWorkEventArgs e)
        /// <summary>
        /// マスタ同期処理ワーカー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PullMasterData_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            
            IPullMasterDataALInput alInput = new PullMasterDataALInput();
            alInput.TargetMasterList = new List<string>();

            //コントロールの表示を変更する
            bw.ReportProgress(30, null);

            // 同期実行
            new PullMasterDataApplicationLogic().Execute(alInput);

            //コントロールの表示を変更する
            bw.ReportProgress(50, null);
            
            IPullTransactionDataALInput alTransInput = new PullTransactionDataALInput();

            // 検査予定日
            alTransInput.Yoteibi = (DateTime)e.Argument;
            // 担当者
            alTransInput.TantoshaCd = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

            //コントロールの表示を変更する
            bw.ReportProgress(80, null);

            // 同期実行
            new PullTransactionDataApplicationLogic().Execute(alTransInput);
            
            //コントロールの表示を変更する
            bw.ReportProgress(100, null);

            TabMessageBox.Show2(TabMessageBox.Type.Info, "ダウンロードが完了しました。");
            
            //結果を設定する
            e.Result = null;
        }
        #endregion

        #region syncDataButton_Click
        /// <summary>
        /// トランザクションデータ同期（アップロード）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void syncDataButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!lastDownloadDate.HasValue)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Info,
                                            "アップロード確認",
                                            string.Format("{0}\r\n{1}",
                                                "端末内に検査予定がダウンロードされていません。",
                                                "アップロードをキャンセルします。"));

                    return;
                }

                object[] ret;

                using (ProgressDialog sg = new ProgressDialog(new DoWorkEventHandler(PushTransactionData_DoWork)))
                {
                    //進行状況ダイアログを表示する
                    DialogResult result = sg.ShowDialog(this);

                    // 結果を取得する
                    ret = (object[])sg.Result;
                }

                DoSearch();

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region PushTransactionData_DoWork(object sender, DoWorkEventArgs e)
        /// <summary>
        /// トランザクションデータ同期処理ワーカー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PushTransactionData_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            IPushTransactionDataALInput alInput = new PushTransactionDataALInput();
            
            //コントロールの表示を変更する
            bw.ReportProgress(50, null);

            // 同期実行
            new PushTransactionDataApplicationLogic().Execute(alInput);
            
            //コントロールの表示を変更する
            bw.ReportProgress(100, null);

            TabMessageBox.Show2(TabMessageBox.Type.Info, "アップロードが完了しました。");

            //結果を設定する
            e.Result = null;
        }
        #endregion

        #region syncOVLButton_Click
        /// <summary>
        /// マップOVL同期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void syncOVLButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                object[] ret;

                using (ProgressDialog sg = new ProgressDialog(new DoWorkEventHandler(SyncOVL_DoWork)))
                {
                    //進行状況ダイアログを表示する
                    DialogResult result = sg.ShowDialog(this);

                    // 結果を取得する
                    ret = (object[])sg.Result;
                }

                DoSearch();

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region SyncOVL_DoWork(object sender, DoWorkEventArgs e)
        /// <summary>
        /// マップOVL同期処理ワーカー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyncOVL_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            ISyncMapOVLALInput alInput = new SyncMapOVLALInput();
            
            //コントロールの表示を変更する
            bw.ReportProgress(80, null);

            // 同期実行
            new SyncMapOVLApplicationLogic().Execute(alInput);

            //コントロールの表示を変更する
            bw.ReportProgress(100, null);

            TabMessageBox.Show2(TabMessageBox.Type.Info, "マップ情報の同期が完了しました。");
            
            //結果を設定する
            e.Result = null;
        }
        #endregion

        #region closeButton_Click
        /// <summary>
        /// 検査一覧ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaListButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                KensaListForm form = new KensaListForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region メソッド（private）

        #region SetSyncAvailable
        /// <summary>
        /// 同期可否を制御
        /// </summary>
        /// <param name="enable"></param>
        private void SetSyncAvailable(bool enable)
        {
            // オンライン
            syncMasterButton.Enabled = enable;
            
            syncDataButton.Enabled = enable;

            syncOVLButton.Enabled = enable;
        }
        #endregion
        
        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                lastDownloadDate = null;
                lastUploadDate = null;
                lastSyncDate = null;

                // 前回同期日時を取得
                IGetSyncHistoryALOutput alOutput = new GetSyncHistoryApplicationLogic().Execute(new GetSyncHistoryALInput());

                if (alOutput.SyncHistoryDownload.Count > 0)
                {
                    lastDownloadDate = alOutput.SyncHistoryDownload[0].LastSyncDate.Date;
                    lastDownloadLabel.Text = alOutput.SyncHistoryDownload[0].LastSyncDate.ToString("yyyy/MM/dd (ddd)");
                }

                if (alOutput.SyncHistoryUpload.Count > 0)
                {
                    lastUploadDate = alOutput.SyncHistoryUpload[0].LastSyncDate.Date;
                    lastUploadLabel.Text = alOutput.SyncHistoryUpload[0].LastSyncDate.ToString("yyyy/MM/dd (ddd)");
                }

                if (alOutput.SyncHistoryMapOVL.Count > 0)
                {
                    lastSyncDate = alOutput.SyncHistoryMapOVL[0].LastSyncDate;
                    lastSyncLabel.Text = alOutput.SyncHistoryMapOVL[0].LastSyncDate.ToString("yyyy/MM/dd (ddd) HH:mm");
                }
            }
            finally
            {
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
