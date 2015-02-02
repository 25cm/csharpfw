using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.Jo7KensaChienInput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet.UketsukeKanri;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Jo7KensaChienInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class Jo7KensaChienInput : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;

        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// LoginUser
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// jo7KensaChienInputListDT
        /// </summary>
        private Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable _jo7KensaChienInputListDT = new Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Jo7KensaChienInput
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Jo7KensaChienInput()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region Jo7KensaChienInput_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Jo7KensaChienInput_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Jo7KensaChienInput_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();

                DoFormLoad();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

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

        #region ViewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;
                if (this._searchShowFlg) // 検索条件を開く
                {
                    this.ViewChangeButton.Text = "▲";
                }
                else // 検索条件を閉じる
                {
                    this.ViewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.kensaChienJisshiListPanel,
                    this._defaultListPanelTop,
                    this._defaultListPanelHeight);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion
        
        #region ClearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ClearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region KensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckCondition()) { return; }

                DoSearch();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region csvOutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： csvOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// 2014/11/07  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void csvOutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaChienJisshiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "7条検査遅延実施報告書を出力します。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                //string filePath = Properties.Settings.Default.LocalFileDirectory + @"\"
                //                    + Properties.Settings.Default.KensaChienHokokushoFileFolder + @"\"
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString() + @"\"
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString()
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString()
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString()
                //                    + Properties.Settings.Default.KensaChienHokokushoFormatFile;

                string kensaKbn = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString();
                string hokenjoCd = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString();
                string nendo = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString();
                string renban = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString();

                string serverFolder = SharedFolderUtility.GetKensaIraiKeyFolder(Constants.ConstKbnConstanst.CONST_KBN_047,
                                                                                Constants.ConstRenbanConstanst.CONST_RENBAN_001, 
                                                                                kensaKbn, 
                                                                                hokenjoCd, 
                                                                                nendo, 
                                                                                renban);

                string localFolder = SharedFolderUtility.GetConstLocalFolder(Constants.ConstKbnConstanst.CONST_KBN_047, 
                                                                             Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                string fileName = string.Concat(hokenjoCd, nendo, renban, Properties.Settings.Default.KensaChienHokokushoFormatFile);

                string localFilePath = Path.Combine(localFolder, fileName);

                string shareFilePath = Path.Combine(serverFolder, fileName);

                if (CheckFileExist(localFilePath))
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "ローカルに同名のファイルが存在します。\r\nサーバーのファイルで上書きしてよろしいですか？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (CheckFileExist(shareFilePath))
                {
                    //Process.Start(filePath);

                    kensaChienJisshiListDataGridView.CurrentRow.Cells[serverSaveFlgCol.Name].Value = "0";

                    try
                    {
                        // 共有フォルダに接続
                        if (!SharedFolderUtility.Connect())
                        {
                            return;
                        }

                        // 共有フォルダからダウンロード
                        if (!SharedFolderUtility.DownloadFile(localFilePath, shareFilePath))
                        {
                            return;
                        }

                        // TODO PDF表示方法要検討（統一しなくて良いか？）
                        Process.Start(localFilePath);
                    }
                    catch (Exception)
                    {
                        // エラー処理
                    }
                    finally
                    {
                        // 共有フォルダから切断
                        SharedFolderUtility.Disconnect();
                    }
                }
                else
                {
                    // 一覧の｛サーバー保存フラグ｝に1をセットする。 
                    kensaChienJisshiListDataGridView.CurrentRow.Cells[serverSaveFlgCol.Name].Value = "1";

                    // ADD_HuyTX_20141031 Start
                    // 034_8条検査遅延実施報告書_帳票設計書.xlsx

                    Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow[] jo7KensaChienRows =
                        (Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow[])_jo7KensaChienInputListDT.Select(string.Format("KensaIraiHoteiKbn = '{0}' AND KensaIraiHokenjoCd = '{1}' AND KensaIraiNendo = '{2}' AND KensaIraiRenban = '{3}'", 
                            kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHoteiKbnCol.Name].Value,
                            kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value,
                            kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value,
                            kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value
                        ));


                    // ADD_HuyTX_20141031 End
                    //KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable insertDT = CreatDataInsert(localFilePath);

                    ICsvOutputBtnClickALInput alInput   = new CsvOutputBtnClickALInput();
                    //alInput.KensaIraiKanrenFileTblDT    = insertDT;
                    alInput.Jo7KensaChienInputListRow = jo7KensaChienRows[0];
                    alInput.SavePath = localFilePath;
                    ICsvOutputBtnClickALOutput alOutput = new CsvOutputBtnClickApplicationLogic().Execute(alInput);

                    if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region uploadButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uploadButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uploadButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaChienJisshiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象データを選択して下さい。");
                    return;
                }

                //string filePathLocal = Properties.Settings.Default.LocalFileDirectory + @"\"
                //                    + Properties.Settings.Default.KensaChienHokokushoFileFolder + @"\"
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString() + @"\"
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString()
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString()
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString()
                //                    + Properties.Settings.Default.KensaChienHokokushoFormatFile;

                //string filePathServer = Properties.Settings.Default.ServerPrintDirectory + @"\"
                //                    + Properties.Settings.Default.KensaChienHokokushoFileFolder + @"\"
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString() + @"\"
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString()
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString()
                //                    + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString()
                //                    + Properties.Settings.Default.KensaChienHokokushoFormatFile;

                string kensaKbn = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString();
                string hokenjoCd = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString();
                string nendo = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString();
                string renban = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString();

                string serverFolder = SharedFolderUtility.GetKensaIraiKeyFolder(Constants.ConstKbnConstanst.CONST_KBN_047,
                                                                                Constants.ConstRenbanConstanst.CONST_RENBAN_001,
                                                                                kensaKbn,
                                                                                hokenjoCd,
                                                                                nendo,
                                                                                renban);

                string localFolder = SharedFolderUtility.GetConstLocalFolder(Constants.ConstKbnConstanst.CONST_KBN_047,
                                                                             Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                string fileName = string.Concat(hokenjoCd, nendo, renban, Properties.Settings.Default.KensaChienHokokushoFormatFile);

                string localFilePath = Path.Combine(localFolder, fileName);

                string shareFilePath = Path.Combine(serverFolder, fileName);

                // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
                // アップロード結果フラグ
                bool isUploaded = false;
                // 2015.01.30 toyoda Add End

                try
                {
                    // 共有フォルダに接続
                    if (!SharedFolderUtility.Connect())
                    {
                        return;
                    }

                    // ローカルのファイル非存在チェック
                    //if (!CheckFileExist(shareFilePath))
                    //{
                    //    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("ファイルが存在しません。[ファイル：{0}]", shareFilePath));
                    //    return;
                    //}

                    if (!CheckFileExist(localFilePath))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("ファイルが存在しません。[ファイル：{0}]", localFilePath));
                        return;
                    }

                    // [アップロードの実行確認]
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "ファイルのアップロードを行います。よろしいですか？") != DialogResult.Yes) return;

                    if (!SharedFolderUtility.UploadFile(localFilePath, shareFilePath))
                    {
                        return;
                    }

                    kensaChienJisshiListDataGridView.CurrentRow.Cells[serverSaveFlgCol.Name].Value = "0";

                    // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
                    // アップロード結果フラグ
                    isUploaded = true;
                    // 2015.01.30 toyoda Add End
                }
                catch (Exception)
                {
                    // エラー処理
                }
                finally
                {
                    // 共有フォルダから切断
                    SharedFolderUtility.Disconnect();
                }

                //// サーバーの出力先フォルダにファイルが存在している場合
                //if (CheckFileExist(filePathServer))
                //{
                //    // [ローカルのファイルオープンチェック]を行う
                //    if (IsFileInUse(filePathServer))
                //    {
                //        MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("ファイルが開かれています。\r\n[ファイル：{0}]", filePathServer));
                //        return;
                //    }

                //    // [アップロードの実行確認]
                //    if (MessageForm.Show2(MessageForm.DispModeType.Question, "ファイルのアップロードを行います。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                //    {
                //        return;
                //    }
                //}
                //else
                //{
                //    // [アップロードの実行確認]
                //    if (MessageForm.Show2(MessageForm.DispModeType.Question, "ファイルのアップロードを行います。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                //    {
                //        return;
                //    }
                //}

                //// Copy file
                //File.Copy(filePathLocal, filePathServer, true);
                
                //// Update data
                //IUploadBtnClickALInput alInput      = new UploadBtnClickALInput();
                //alInput.KensaIraiKanrenFileTblDT    = CreatDataUpdate(filePathServer);
                //IUploadBtnClickALOutput alOuput     = new UploadBtnClickApplicationLogic().Execute(alInput);

                // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
                if (isUploaded)
                {
                    // 報告作成済フラグを更新
                    IAfterUploadALInput alAftInput = new AfterUploadALInput();

                    alAftInput.IraiHoteiKbn = kensaKbn;
                    alAftInput.IraiHokenjoCd = hokenjoCd;
                    alAftInput.IraiNendo = nendo;
                    alAftInput.IraiRenban = renban;

                    new AfterUploadApplicationLogic().Execute(alAftInput);

                    // 楽観ロックは取らないため、再描画(検索)はしない※リスト上のメモリに作成状態を保持している為再検索はできない・・・
                    kensaChienJisshiListDataGridView.CurrentRow.Cells[ChienHokokuMakeKbn.Index].Value = "1";
                }
                // 2015.01.30 toyoda Add End
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region to be removed
        #region downLoadButton_Click
        // 2014/11/06 DatNT v1.03 DEL Start
        //////////////////////////////////////////////////////////////////////////////
        /////  イベント名 ： downLoadButton_Click
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/09/15  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void downLoadButton_Click(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (kensaChienJisshiListDataGridView.RowCount == 0)
        //        {
        //            MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
        //            return;
        //        }

        //        string filePathLocal = Properties.Settings.Default.LocalFileDirectory + @"\"
        //                            + Properties.Settings.Default.KensaChienHokokushoFileFolder + @"\"
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString() + @"\"
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString()
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString()
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString()
        //                            + Properties.Settings.Default.KensaChienHokokushoFormatFile;

        //        string filePathServer = Properties.Settings.Default.ServerPrintDirectory + @"\"
        //                            + Properties.Settings.Default.KensaChienHokokushoFileFolder + @"\"
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString() + @"\"
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString()
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString()
        //                            + kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString()
        //                            + Properties.Settings.Default.KensaChienHokokushoFormatFile;

        //        // [サーバーのファイル非存在チェック]を行う
        //        if (!CheckFileExist(filePathServer))
        //        {
        //            MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("ファイルが存在しません。[ファイル：{0}]", filePathServer));
        //            return;
        //        }
        //        else
        //        {
        //            if (!CheckFileExist(filePathLocal))
        //            {

        //            }
        //            else
        //            {
        //                // ローカルのファイルが開かれている場合
        //                if (IsFileInUse(filePathLocal))
        //                {
        //                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("ファイルが開かれています。[ファイル：{0}]", filePathLocal));
        //                    return;
        //                }

        //                if (MessageForm.Show2(MessageForm.DispModeType.Question, "ファイルのダウンロードを行います。\r\n既存の出力ファイルが上書きされますが、よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
        //                {
        //                    return;
        //                }
        //            }

        //            if (MessageForm.Show2(MessageForm.DispModeType.Question, "ファイルのダウンロードを行います。よろしいですか？") == System.Windows.Forms.DialogResult.Yes)
        //            {
        //                // サーバからローカルにファイルをコピーする(上書き)
        //                File.Copy(filePathServer, filePathLocal, true);
        //            }
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        // 2014/11/06 DatNT v1.03 DEL End
        #endregion
        #endregion

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaChienJisshiListDataGridView.RowCount == 0) { return; }

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "7条検査遅延入力一覧";
                OutputExcel(this.kensaChienJisshiListDataGridView, outputFilename);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region TojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!TransitionCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "サーバー保存処理が行われていません。\r\nこのまま画面を閉じてもよろしいですか？")
                        != DialogResult.Yes)
                    {
                        return;
                    }
                }
                
                Program.mForm.MovePrev();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region Jo7KensaChienInput_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Jo7KensaChienInput_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// 2014/11/06  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Jo7KensaChienInput_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        csvOutputButton.Focus();
                        csvOutputButton.PerformClick();
                        break;

                    case Keys.F2:
                        uploadButton.Focus();
                        uploadButton.PerformClick();
                        break;

                    // 2014/11/06 DatNT v1.03 DEL Start
                    //case Keys.F3:
                    //    downLoadButton.Focus();
                    //    downLoadButton.PerformClick();
                    //    break;
                    // 2014/11/06 DatNT v1.03 DEL End

                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;

                    case Keys.F7:
                        ClearButton.Focus();
                        ClearButton.PerformClick();
                        break;

                    case Keys.F8:
                        KensakuButton.Focus();
                        KensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                        tojiruButton.Focus();
                        tojiruButton.PerformClick();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kensaIraiShiyoKaishiDtJokenTuikaFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiShiyoKaishiDtJokenTuikaFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaIraiShiyoKaishiDtJokenTuikaFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaIraiShiyoKaishiDtJokenTuikaFlgCheckBox.Checked)
                {
                    // 使用開始日（開始）
                    kensaIraiShiyoKaishiDtFromDateTimePicker.Enabled = true;

                    // 使用開始日（終了）
                    kensaIraiShiyoKaishiDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    // 使用開始日（開始）
                    kensaIraiShiyoKaishiDtFromDateTimePicker.Enabled = false;

                    // 使用開始日（終了）
                    kensaIraiShiyoKaishiDtToDateTimePicker.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kensaJisshiBijokenTsuikaFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaJisshiBijokenTsuikaFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaJisshiBijokenTsuikaFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaJisshiBijokenTsuikaFlgCheckBox.Checked)
                {
                    // 検査実施日（開始）
                    kensaIraiKensaDtFromDateTimePicker.Enabled = true;

                    // 検査実施日（終了）
                    kensaIraiKensaDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    // 検査実施日（開始）
                    kensaIraiKensaDtFromDateTimePicker.Enabled = false;

                    // 検査実施日（終了）
                    kensaIraiKensaDtToDateTimePicker.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kensaIraiShiyoKaishiDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiShiyoKaishiDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　PhuongDT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaIraiShiyoKaishiDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaIraiShiyoKaishiDtToDateTimePicker.Value = kensaIraiShiyoKaishiDtFromDateTimePicker.Value;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kensaIraiKensaDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiKensaDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　PhuongDT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaIraiKensaDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaIraiKensaDtToDateTimePicker.Value = kensaIraiKensaDtFromDateTimePicker.Value;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            jo7KensaChienInputListDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 支所
            //Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);

            // 20150107 habu 初期ロード時の検索を停止
            kensaChienJisshiListCountLabel.Text = "0件";

            #region to be removed
            //_jo7KensaChienInputListDT = DisplayData(alOutput.Jo7KensaChienInputListDT);

            //// Display data
            //// 20141211 habu MOD set once is enough
            //jo7KensaChienInputListDataSet.Merge(_jo7KensaChienInputListDT);
            ////jo7KensaChienInputListDataSet.Merge(DisplayData(alOutput.Jo7KensaChienInputListDT));

            //if (alOutput.Jo7KensaChienInputListDT == null || alOutput.Jo7KensaChienInputListDT.Count == 0)
            //{
            //    kensaChienJisshiListCountLabel.Text = "0件";
            //}
            //else
            //{
            //    kensaChienJisshiListCountLabel.Text = alOutput.Jo7KensaChienInputListDT.Count.ToString() + "件";
            //}
            #endregion

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.kensaChienJisshiListPanel.Top;
            this._defaultListPanelHeight = this.kensaChienJisshiListPanel.Height;
        }
        #endregion

        #region MakeSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alInput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 支所
            if (shishoNmComboBox.SelectedValue != null)
            {
                alInput.ShishoCd = shishoNmComboBox.SelectedValue.ToString();
            }

            // 人槽
            alInput.KensaIraiShoritaishoJinin = kensaIraiShoritaishoJininComboCox.Text;

            // 使用開始日の条件追加フラグ
            alInput.KensaIraiShiyoKaishiDtJokenTuikaFlg = kensaIraiShiyoKaishiDtJokenTuikaFlgCheckBox.Checked;

            // 使用開始日（開始）
            alInput.KensaIraiShiyoKaishiDtFrom = kensaIraiShiyoKaishiDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 使用開始日（終了）
            alInput.KensaIraiShiyoKaishiDtTo = kensaIraiShiyoKaishiDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査実施日の条件追加フラグ
            alInput.KensaJisshiBijokenTsuikaFlg = kensaJisshiBijokenTsuikaFlgCheckBox.Checked;

            // 検査実施日（開始）
            alInput.KensaIraiKensaDtFrom = kensaIraiKensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査実施日（終了）
            alInput.KensaIraiKensaDtTo = kensaIraiKensaDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
            // 報告書未作成
            alInput.MiSakuseiFlag = miSakuseiCheckBox.Checked;
            // 報告書作成済
            alInput.SakuseiSumiFlag = sakuseiSumiCheckBox.Checked;
            // 2015.01.30 toyoda Add End
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
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            jo7KensaChienInputListDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            _jo7KensaChienInputListDT = DisplayData(alOutput.Jo7KensaChienInputListDT);

            // Display data
            // 20141211 habu MOD set once is enough
            jo7KensaChienInputListDataSet.Merge(_jo7KensaChienInputListDT);
            //jo7KensaChienInputListDataSet.Merge(DisplayData(alOutput.Jo7KensaChienInputListDT));

            if (alOutput.Jo7KensaChienInputListDT == null || alOutput.Jo7KensaChienInputListDT.Count == 0)
            {
                kensaChienJisshiListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                kensaChienJisshiListCountLabel.Text = alOutput.Jo7KensaChienInputListDT.Count.ToString() + "件";
            }
        }
        #endregion

        #region CheckCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            if (kensaIraiShiyoKaishiDtJokenTuikaFlgCheckBox.Checked)
            {
                if (kensaIraiShiyoKaishiDtFromDateTimePicker.Value > kensaIraiShiyoKaishiDtToDateTimePicker.Value)
                {
                    errMess.AppendLine("範囲指定が正しくありません。使用開始日の大小関係を確認してください。");
                }
            }

            if (kensaJisshiBijokenTsuikaFlgCheckBox.Checked)
            {
                if (kensaIraiKensaDtFromDateTimePicker.Value > kensaIraiKensaDtToDateTimePicker.Value)
                {
                    errMess.AppendLine("範囲指定が正しくありません。検査実施日の大小関係を確認してください。");
                }
            }

            // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
            if (!miSakuseiCheckBox.Checked && !sakuseiSumiCheckBox.Checked)
            {
                if (kensaIraiKensaDtFromDateTimePicker.Value > kensaIraiKensaDtToDateTimePicker.Value)
                {
                    errMess.AppendLine("報告書作成有無を選択してください。");
                }
            }
            // 2015.01.30 toyoda Add End

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 支所
            shishoNmComboBox.SelectedIndex = -1;

            // 人槽
            kensaIraiShoritaishoJininComboCox.SelectedIndex = -1;

            // 使用開始日の条件追加フラグ
            kensaIraiShiyoKaishiDtJokenTuikaFlgCheckBox.Checked = false;
            
            // 使用開始日（開始）
            kensaIraiShiyoKaishiDtFromDateTimePicker.Value = today;
            kensaIraiShiyoKaishiDtFromDateTimePicker.Enabled = false;

            // 使用開始日（終了）
            kensaIraiShiyoKaishiDtToDateTimePicker.Value = today;
            kensaIraiShiyoKaishiDtToDateTimePicker.Enabled = false;

            // 検査実施日の条件追加フラグ
            kensaJisshiBijokenTsuikaFlgCheckBox.Checked = false;
            
            // 検査実施日（開始）
            kensaIraiKensaDtFromDateTimePicker.Value = today;
            kensaIraiKensaDtFromDateTimePicker.Enabled = false;

            // 検査実施日（終了）
            kensaIraiKensaDtToDateTimePicker.Value = today;
            kensaIraiKensaDtToDateTimePicker.Enabled = false;

            // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
            miSakuseiCheckBox.Checked = true;
            sakuseiSumiCheckBox.Checked = false;
            // 2015.01.30 toyoda Add End
        }
        #endregion

        #region DisplayData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// 2014/12/06  DatNT    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable DisplayData(Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable dataTable)
        {
            Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable dispDT = new Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable();

            foreach (Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow row in dataTable)
            {
                Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow dispRow = dispDT.NewJo7KensaChienInputListRow();

                // 検査依頼法定区分
                dispRow.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;

                // 検査依頼保健所コード
                dispRow.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;

                // 検査依頼年度
                dispRow.KensaIraiNendo = row.KensaIraiNendo;

                // 検査依頼連番
                dispRow.KensaIraiRenban = row.KensaIraiRenban;

                // 法定支所コード
                dispRow.KensaIraiUketsukeShishoKbn = row.KensaIraiUketsukeShishoKbn;

                // 支所名称
                dispRow.ShishoNm = row.ShishoNm;

                // 20150107 habu 登録年度用の関数に変更
                // 協会No
                dispRow.kyokaiNoCol = string.Concat(row.KensaIraiHokenjoCd, "-", Common.Common.ConvertToHoshouNendoWareki(row.KensaIraiNendo), "-", row.KensaIraiRenban);
                //dispRow.kyokaiNoCol = string.Concat(row.KensaIraiHokenjoCd, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy"), "-", row.KensaIraiRenban);

                // 設置者名（漢字）
                dispRow.KensaIraiSetchishaNm = row.KensaIraiSetchishaNm;

                // 検査依頼設置場所（住所）
                dispRow.KensaIraiSetchibashoAdr = row.KensaIraiSetchibashoAdr;

                // 処理対象人員
                if (!row.IsKensaIraiShoritaishoJininNull())
                {
                    dispRow.KensaIraiShoritaishoJinin = row.KensaIraiShoritaishoJinin;
                }

                // 使用開始日
                dispRow.kensaIraiShiyoKaishiDtCol = row.kensaIraiShiyoKaishiDtCol;

                // 検査実施期限日
                dispRow.kensaJisshiKigenDtCol = row.kensaJisshiKigenDtCol;

                // 検査実施日
                dispRow.kensaIraiKensaDtCol = row.kensaIraiKensaDtCol;

                // 期限日からの経過日数
                dispRow.keikaDtCol = MinusDay(row.kensaJisshiKigenDtCol, row.kensaIraiKensaDtCol);

                // 検査担当者
                dispRow.KensaIraiKensaTantoshaCd = row.KensaIraiKensaTantoshaCd;

                // 2014/12/06 DatNT v1.06 Add Start
                dispRow.ShokuinNm = row.ShokuinNm;
                // 2014/12/06 DatNT v1.06 Add End

                // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
                dispRow.ChienHokokuMakeKbn = row.ChienHokokuMakeKbn;
                // 2015.01.30 toyoda Add End

                dispDT.AddJo7KensaChienInputListRow(dispRow);
                dispRow.AcceptChanges();
                dispRow.SetAdded();
            }

            return dispDT;
        }
        #endregion

        #region MinusDay
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MinusDay
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kigenDt"></param>
        /// <param name="kensaDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// 2014/11/06  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string MinusDay(string kigenDt, string kensaDt)
        {
            string retStr = string.Empty;

            // 20141211 MOD habu 使用開始日が未入力(期限日が不定)の場合を考慮
            if (string.IsNullOrEmpty(kigenDt))
            {
                return string.Empty;
            }
            //if (string.IsNullOrEmpty(kigenDt) && string.IsNullOrEmpty(kensaDt))
            //{
            //    return string.Empty;
            //}
            //else if (string.IsNullOrEmpty(kigenDt) && !string.IsNullOrEmpty(kensaDt))
            //{
            //    return kensaDt;
            //}
            //else if (!string.IsNullOrEmpty(kigenDt) && string.IsNullOrEmpty(kensaDt))
            //{
            //    return kigenDt;
            //}
            // 20141211 End
            else
            {
                // 2014/11/06 DatNT v1.03 MOD Start
                int kigenDtYear = Convert.ToInt32(kigenDt.Substring(0, 4));
                int kigenDtMonth = Convert.ToInt32(kigenDt.Substring(5, 2));
                int kigenDtDay = Convert.ToInt32(kigenDt.Substring(8, 2));

                int kensaDtYear = Convert.ToInt32(kensaDt.Substring(0, 4));
                int kensaDtMonth = Convert.ToInt32(kensaDt.Substring(5, 2));
                int kensaDtDay = Convert.ToInt32(kensaDt.Substring(8, 2));

                //int kigenDtYear = Convert.ToInt32(Common.Common.ConvertToHoshouNendoSeireki(kigenDt.Substring(0, 2)));
                //int kigenDtMonth = Convert.ToInt32(kigenDt.Substring(3, 2));
                //int kigenDtDay = Convert.ToInt32(kigenDt.Substring(6, 2));

                //int kensaDtYear = Convert.ToInt32(Common.Common.ConvertToHoshouNendoSeireki(kensaDt.Substring(0, 2)));
                //int kensaDtMonth = Convert.ToInt32(kensaDt.Substring(3, 2));
                //int kensaDtDay = Convert.ToInt32(kensaDt.Substring(6, 2));
                // 2014/11/06 DatNT v1.03 MOD End

                DateTime kigenDtDate = new DateTime(kigenDtYear, kigenDtMonth, kigenDtDay);

                DateTime kensaDtDate = new DateTime(kensaDtYear, kensaDtMonth, kensaDtDay);

                // 20141211 MOD habu 経過日の計算を修正
                TimeSpan span = (kensaDtDate - kigenDtDate);

                if (span.TotalDays < 0)
                {
                    return string.Empty;
                }

                int yearDiff;
                int monthDiff;
                int daysDiff;

                Zynas.Framework.Utility.DateUtility.DateDiff(kensaDtDate, kigenDtDate, out yearDiff, out monthDiff, out daysDiff);

                retStr = string.Format("-{0:D2}年{1:D2}ヶ月{2:D2}日", yearDiff, monthDiff, daysDiff);
                // 20141211 End

                #region to be removed
                //if (kigenDtDate.Year == kensaDtDate.Year)
                //{
                //    if (kigenDtDate.Month == kensaDtDate.Month)
                //    {
                //        if (kigenDtDate.Day == kensaDtDate.Day)
                //        {
                //            retStr = "-0年0ヶ月0日";
                //        }
                //        else
                //        {
                //            retStr = "-0年0ヶ月" + (kigenDtDate.Day - kensaDtDate.Day) + "日";
                //        }
                //    }
                //    else
                //    {
                //        if (kigenDtDate.Day == kensaDtDate.Day)
                //        {
                //            retStr = "-0年" + (kigenDtDate.Month - kensaDtDate.Month) + "ヶ月0日";
                //        }
                //        else if (kigenDtDate.Day > kensaDtDate.Day)
                //        {
                //            retStr = "-0年" + (kigenDtDate.Month - kensaDtDate.Month) + "ヶ月" + (kigenDtDate.Day - kensaDtDate.Day) + "日";
                //        }
                //        else
                //        {
                //            retStr = "-0年0ヶ月" + (DateTime.DaysInMonth(kensaDtDate.Year, kensaDtDate.Month) - kensaDtDate.Day + kigenDtDate.Day) + "日";
                //        }
                //    }
                //}
                //else
                //{
                //    if (kigenDtDate.Month == kensaDtDate.Month)
                //    {
                //        if (kigenDtDate.Day == kensaDtDate.Day)
                //        {
                //            retStr = "-" + (kigenDtDate.Year - kensaDtDate.Year) + "年0ヶ月0日";
                //        }
                //        else if (kigenDtDate.Day > kensaDtDate.Day)
                //        {
                //            retStr = "-" + (kigenDtDate.Year - kensaDtDate.Year) + "年0ヶ月" + (kigenDtDate.Day - kensaDtDate.Day) + "日";
                //        }
                //        else
                //        {
                //            retStr = "-" + (kigenDtDate.Year - kensaDtDate.Year - 1) + "年11ヶ月" + (DateTime.DaysInMonth(kensaDtDate.Year, kensaDtDate.Month) - kensaDtDate.Day + kigenDtDate.Day) + "日";
                //        }
                //    }
                //    else if (kigenDtDate.Month > kensaDtDate.Month)
                //    {
                //        if (kigenDtDate.Day == kensaDtDate.Day)
                //        {
                //            retStr = "-" + (kigenDtDate.Year - kensaDtDate.Year) + "年" + (kigenDtDate.Month - kensaDtDate.Month) + "ヶ月0日";
                //        }
                //        else if (kigenDtDate.Day > kensaDtDate.Day)
                //        {
                //            retStr = "-" + (kigenDtDate.Year - kensaDtDate.Year) + "年" + (kigenDtDate.Month - kensaDtDate.Month) + "ヶ月" + (kigenDtDate.Day - kensaDtDate.Day) + "日";
                //        }
                //        else
                //        {
                //            retStr = "-" + (kigenDtDate.Year - kensaDtDate.Year - 1) + "年11ヶ月" + (DateTime.DaysInMonth(kensaDtDate.Year, kensaDtDate.Month) - kensaDtDate.Day + kigenDtDate.Day) + "日";
                //        }
                //    }
                //    else
                //    {
                //        int month = (kigenDtDate.Year - kensaDtDate.Year) * 12 + kigenDtDate.Month - kensaDtDate.Month;

                //        if (kigenDtDate.Day == kensaDtDate.Day)
                //        {
                //            retStr = "-" + (int)(month / 12) + "年" + ((month - (int)(month / 12)) % 12) + "ヶ月0日";
                //        }
                //        else if (kigenDtDate.Day > kensaDtDate.Day)
                //        {
                //            retStr = "-" + (int)(month / 12) + "年" + ((month - (int)(month / 12)) % 12) + "ヶ月" + (kigenDtDate.Day - kensaDtDate.Day) + "日";
                //        }
                //        else
                //        {
                //            month = month - 1;

                //            retStr = "-" + (int)(month / 12) + "年" + ((month - (int)(month / 12)) % 12) + "ヶ月" + (DateTime.DaysInMonth(kensaDtDate.Year, kensaDtDate.Month) - kensaDtDate.Day + kigenDtDate.Day) + "日";
                //        }
                //    }
                //}
                #endregion

            }

            return retStr;
        }
        #endregion

        #region releaseObject
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： releaseObject
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void releaseObject(object obj)
        {
            try
            {
                if (null == obj) return;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        #region OutputExcel
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： OutputExcel
        /// <summary>
        ///  指定GridviewのデータをExcelに出力する
        /// </summary>
        /// <param name="targetDataGridView">対象DataGridView</param>
        /// <param name="outputFilename"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15 DatNT　　 新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void OutputExcel(DataGridView targetDataGridView, string outputFilename)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;

            try
            {
                // 保存確認ダイアログの表示
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.FileName = outputFilename + "_" + Common.Common.GetCurrentTimestamp().ToString("yyyyMMddHHmmss");
                dlg.Filter = "Excel files (*.xls)|*.xls";
                dlg.FilterIndex = 1;

                // ＯＫボタンで終了した場合
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    int i = 0;
                    int j = 0;

                    for (i = 0; i <= targetDataGridView.RowCount - 1; i++)
                    {
                        for (j = 0; j <= targetDataGridView.ColumnCount - 1; j++)
                        {
                            // Skip hidden columns
                            if (!targetDataGridView.Columns[j].Visible) continue;

                            DataGridViewCell cell = targetDataGridView[j, i];

                            if (i == 0)
                            {
                                DataGridViewHeaderCell h = targetDataGridView.Columns[j].HeaderCell;
                                xlWorkSheet.Cells[i + 1, j + 1] = h.Value;
                            }

                            // Code & No columns format
                            if (targetDataGridView.Columns[j].Name.Length > 5
                                && (targetDataGridView.Columns[j].Name.Substring(targetDataGridView.Columns[j].Name.Length - 5) == "CdCol"
                                || targetDataGridView.Columns[j].Name.Substring(targetDataGridView.Columns[j].Name.Length - 5) == "NoCol"))
                            {
                                xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value;
                                Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                            }
                            else if (targetDataGridView.Columns[j].Name == "kensaIraiShiyoKaishiDtCol"
                                    || targetDataGridView.Columns[j].Name == "kensaJisshiKigenDtCol"
                                    || targetDataGridView.Columns[j].Name == "kensaIraiKensaDtCol")
                            {
                                xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value;
                                Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                            }
                            else
                            {
                                xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                            }
                            if (targetDataGridView.Columns[j].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
                            {
                                Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                                rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }
                        }
                    }

                    xlWorkBook.SaveAs(dlg.FileName,
                                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                                        misValue,
                                        misValue,
                                        misValue,
                                        misValue,
                                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                                        misValue,
                                        misValue,
                                        misValue,
                                        misValue,
                                        misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
        }
        #endregion

        #region CheckFileExist
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckFileExist
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckFileExist(string filePath)
        {
            if(File.Exists(filePath))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region IsFileInUse
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsFileInUse
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsFileInUse(string filePath)
        {
            FileInfo file = new FileInfo(filePath);

            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return false;
        }
        #endregion

        #region to be removed
        #region CreatDataInsert
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： CreatDataInsert
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="filePath"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/09/17  DatNT　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable CreatDataInsert(string filePath)
        //{
        //    DateTime now = Common.Common.GetCurrentTimestamp();

        //    KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable insertDT = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

        //    KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow insertRow = insertDT.NewKensaIraiKanrenFileTblRow();

        //    // 検査依頼法定区分
        //    insertRow.KensaIraiHoteiKbn = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString();

        //    // 検査依頼保健所コード
        //    insertRow.KensaIraiHokenjoCd = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString();

        //    // 検査依頼年度
        //    insertRow.KensaIraiNendo = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString();

        //    // 検査依頼連番
        //    insertRow.KensaIraiRenban = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString();

        //    // 関連ファイル種別
        //    insertRow.KensaIraiFileShubetsuCd = "1";

        //    // 関連ファイルパス
        //    insertRow.KensaIraiKanrenFilePath = filePath;

        //    // 登録日
        //    insertRow.InsertDt = now;

        //    // 登録者
        //    insertRow.InsertUser = loginUser;

        //    // 登録端末
        //    insertRow.InsertTarm = pcUpdate;

        //    // 更新日
        //    insertRow.UpdateDt = now;

        //    // 更新者
        //    insertRow.UpdateUser = loginUser;

        //    // 更新端末
        //    insertRow.UpdateTarm = pcUpdate;

        //    insertDT.AddKensaIraiKanrenFileTblRow(insertRow);
        //    insertRow.AcceptChanges();
        //    insertRow.SetAdded();

        //    return insertDT;
        //}
        #endregion

        #region CreatDataUpdate
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： CreatDataUpdate
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="filePath"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/09/17  DatNT　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable CreatDataUpdate(string filePath)
        //{
        //    KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable updateDT = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

        //    KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow updateRow = updateDT.NewKensaIraiKanrenFileTblRow();

        //    // 検査依頼法定区分
        //    updateRow.KensaIraiHoteiKbn = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString();

        //    // 検査依頼保健所コード
        //    updateRow.KensaIraiHokenjoCd = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString();

        //    // 検査依頼年度
        //    updateRow.KensaIraiNendo = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiNendoCol.Name].Value.ToString();

        //    // 検査依頼連番
        //    updateRow.KensaIraiRenban = kensaChienJisshiListDataGridView.CurrentRow.Cells[kensaIraiRenbanCol.Name].Value.ToString();

        //    // 関連ファイル種別
        //    updateRow.KensaIraiFileShubetsuCd = "1";

        //    // 関連ファイルパス
        //    updateRow.KensaIraiKanrenFilePath = filePath;

        //    // 登録日
        //    updateRow.InsertDt = today;

        //    // 登録者
        //    updateRow.InsertUser = loginUser;

        //    // 登録端末
        //    updateRow.InsertTarm = pcUpdate;

        //    // 更新日
        //    updateRow.UpdateDt = today;

        //    // 更新者
        //    updateRow.UpdateUser = loginUser;

        //    // 更新端末
        //    updateRow.UpdateTarm = pcUpdate;

        //    updateDT.AddKensaIraiKanrenFileTblRow(updateRow);
        //    updateRow.AcceptChanges();
        //    updateRow.SetAdded();

        //    return updateDT;
        //}
        #endregion
        #endregion

        #region TransitionCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： TransitionCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool TransitionCheck()
        {
            foreach (DataGridViewRow row in kensaChienJisshiListDataGridView.Rows)
            {
                if (row.Cells[serverSaveFlgCol.Name].Value != null)
                {
                    if (row.Cells[serverSaveFlgCol.Name].Value.ToString() == "1")
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        private void kensaChienJisshiListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            //Cursor preCursor = Cursor.Current;

            try
            {
                //Cursor.Current = Cursors.WaitCursor;

                // チェックボックスへの置き換え
                if (e.ColumnIndex == ChienHokokuMakeKbn.Index)
                {
                    if (e.Value.ToString() == "1")
                    {
                        e.Value = true;
                    }
                    else
                    {
                        e.Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                //Cursor.Current = preCursor;
                //TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }

        #endregion

    }
    #endregion
}
