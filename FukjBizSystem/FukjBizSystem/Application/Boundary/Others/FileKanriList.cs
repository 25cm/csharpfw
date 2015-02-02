using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.FileKanriList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FileKanriListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class FileKanriListForm : FukjBaseForm
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
        /// DateTime Today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// File server directory
        /// </summary>
        private string fileServerDirectory = Utility.SharedFolderUtility.GetConstServerFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_004, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FileKanriListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FileKanriListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region FileKanriListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FileKanriListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FileKanriListForm_Load(object sender, EventArgs e)
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
        /// 2014/08/06  DatNT　  新規作成
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
                    this.viewChangeButton.Text = "▲";
                }
                else // 検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.fileListPanel,
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
        
        #region torokuDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (torokuDtUseCheckBox.Checked)
                {
                    torokuDtFromDateTimePicker.Enabled = true;
                    torokuDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    torokuDtFromDateTimePicker.Enabled = false;
                    torokuDtToDateTimePicker.Enabled = false;
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

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
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

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckCondition()) { return; }

                DoSearch(true);
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

        #region entryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： entryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ダイアログのタイトルを設定する
                openFileDialog.Title = "ファイル選択";

                // 初期表示するディレクトリを設定する
                openFileDialog.InitialDirectory = @"C:\";

                // 初期表示するファイル名を設定する
                openFileDialog.FileName = "";

                // ファイルのフィルタを設定する
                openFileDialog.Filter = "PDF ファイル|*.pdf";

                // ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
                openFileDialog.FilterIndex = 1;

                // ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 false)
                openFileDialog.RestoreDirectory = true;

                // 複数のファイルを選択可能にする (初期値 false)
                //openFileDialog1.Multiselect = false;

                // [ヘルプ] ボタンを表示する (初期値 false)
                //openFileDialog1.ShowHelp = false;

                // [読み取り専用] チェックボックスを表示する (初期値 false)
                //openFileDialog1.ShowReadOnly = true;

                // [読み取り専用] チェックボックスをオンにする (初期値 false)
                //openFileDialog1.ReadOnlyChecked = true;

                // 存在しないファイルを指定した場合は警告を表示する (初期値 true)
                //openFileDialog1.CheckFileExists = true;

                // 存在しないパスを指定した場合は警告を表示する (初期値 true)
                //openFileDialog1.CheckPathExists = true;

                // 拡張子を指定しない場合は自動的に拡張子を付加する (初期値 true)
                //openFileDialog1.AddExtension = true;

                // 有効な Win32 ファイル名だけを受け入れるようにする (初期値 true)
                //openFileDialog1.ValidateNames = true;

                // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //チェック処理、登録処理

                    // Data insert
                    FileKanriTblDataSet.FileKanriTblDataTable insertDT = CreateDataInsert(openFileDialog.SafeFileName);

                    IEntryBtnClickALInput alInput   = new EntryBtnClickALInput();
                    alInput.FileKanriTblDT          = insertDT;
                    alInput.FileNameUpload          = openFileDialog.SafeFileName;
                    alInput.FilePathUpload          = openFileDialog.FileName;
                    alInput.FileServerDirectory     = fileServerDirectory;
                    alInput.Today                   = today;
                    IEntryBtnClickALOutput alOuput  = new EntryBtnClickApplicationLogic().Execute(alInput);

                    if (!string.IsNullOrEmpty(alOuput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOuput.ErrMessage);
                        return;
                    }

                    DoSearch(false);
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

        #region changeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： changeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (fileListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // ダイアログのタイトルを設定する
                openFileDialog.Title = "ファイル選択";

                // 初期表示するディレクトリを設定する
                openFileDialog.InitialDirectory = @"C:\";

                // 初期表示するファイル名を設定する
                openFileDialog.FileName = "";

                // ファイルのフィルタを設定する
                openFileDialog.Filter = "PDF ファイル|*.pdf";

                // ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
                openFileDialog.FilterIndex = 1;

                // ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 false)
                openFileDialog.RestoreDirectory = true;

                // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileNameNew = fileListDataGridView.CurrentRow.Cells["FileNoCol"].Value.ToString() 
                                            + "_"                
                                            + openFileDialog.SafeFileName;

                    if (!CheckReadFilePermission(fileServerDirectory + fileListDataGridView.CurrentRow.Cells["FileNmCol"].Value.ToString(), false))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "ファイルの登録に失敗しました。\r\nシステム管理者に連絡してください。");
                        return;
                    }

                    // Data update
                    FileKanriTblDataSet.FileKanriTblDataTable updateDT = CreateDataUpdate(fileNameNew, openFileDialog.SafeFileName);

                    IChangeBtnClickALInput alInput  = new ChangeBtnClickALInput();
                    alInput.FileKanriTblDT          = updateDT;
                    alInput.FileNameOld             = fileListDataGridView.CurrentRow.Cells["FileNmCol"].Value.ToString();
                    alInput.FileNameUpload          = openFileDialog.SafeFileName;
                    alInput.FilePathUpload          = openFileDialog.FileName;
                    alInput.FileServerDirectory     = fileServerDirectory;
                    IChangeBtnClickALOutput alOuput = new ChangeBtnClickApplicationLogic().Execute(alInput);

                    if (!string.IsNullOrEmpty(alOuput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOuput.ErrMessage);
                        return;
                    }

                    DoSearch(false);
                }
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
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

        #region deleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (fileListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string fileKbn = fileListDataGridView.CurrentRow.Cells["FileKbnCol"].Value.ToString();
                string fileNo = fileListDataGridView.CurrentRow.Cells["FileNoCol"].Value.ToString();
                
                IDeleteBtnClickALInput alInput      = new DeleteBtnClickALInput();
                alInput.FileKbn                     = fileKbn;
                alInput.FileNo                      = fileNo;
                alInput.FileServerDirectory         = fileServerDirectory;
                IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                }

                DoSearch(false);
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

        #region fileOpenButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： fileOpenButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void fileOpenButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (fileListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string filePath = fileListDataGridView.CurrentRow.Cells["FilePathCol"].Value.ToString();

                // 選択したファイルが存在しない場合
                if (!File.Exists(filePath))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "選択されたファイルが存在しません。");
                    return;
                }

                if (!CheckReadFilePermission(filePath, true))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "ファイルオープンに失敗しました。");
                    return;
                }

                Process.Start(filePath);
                
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
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (fileListDataGridView.RowCount == 0) { return; }

                string outputFilename = "ファイル管理テーブル一覧";
                Common.Common.FlushGridviewDataToExcel(this.fileListDataGridView, outputFilename);
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

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //OthersMenuForm frm = new OthersMenuForm();
                //Program.mForm.ShowForm(frm);
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

        #region FileKanriListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FileKanriListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FileKanriListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        entryButton.PerformClick();
                        break;

                    case Keys.F2:
                        changeButton.PerformClick();
                        break;

                    case Keys.F3:
                        deleteButton.PerformClick();
                        break;

                    case Keys.F5:
                        fileOpenButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.PerformClick();
                        break;

                    case Keys.F7:
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
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

        #region fileListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： fileListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void fileListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                string filePath = fileListDataGridView.CurrentRow.Cells["FilePathCol"].Value.ToString();

                // 選択したファイルが存在しない場合
                if (!File.Exists(filePath))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "選択されたファイルが存在しません。");
                    return;
                }

                if (!CheckReadFilePermission(filePath, true))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "ファイルオープンに失敗しました。");
                    return;
                }

                Process.Start(filePath);
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

        #region torokuDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuDtFromDateTimePicker_ValueChanged
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
        private void torokuDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                torokuDtToDateTimePicker.Value = torokuDtFromDateTimePicker.Value;
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
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            fileKanriTblDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Display data
            fileKanriTblDataSet.Merge(alOutput.FileKanriTblKensakuDT);

            if (alOutput.FileKanriTblKensakuDT == null || alOutput.FileKanriTblKensakuDT.Count == 0)
            {
                fileListCountLabel.Text = "0件";
            }
            else
            {
                fileListCountLabel.Text = alOutput.FileKanriTblKensakuDT.Count.ToString() + "件";
            }

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.fileListPanel.Top;
            this._defaultListPanelHeight = this.fileListPanel.Height;
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
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // ファイル名
            alInput.FileName =  fileNmTextBox.Text.Trim();

            // 登録日検索使用区分
            alInput.TorokuDtUse = torokuDtUseCheckBox.Checked;

            // 登録日（開始）
            alInput.TorokuDtFrom = torokuDtFromDateTimePicker.Value;

            // 登録日（終了）
            alInput.TorokuDtTo = torokuDtToDateTimePicker.Value.AddDays(1);
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clickBtnSearch"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch(bool clickBtnSearch)
        {
            // Clear datagirdview
            fileKanriTblDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            fileKanriTblDataSet.Merge(alOutput.FileKanriTblKensakuDT);

            if (alOutput.FileKanriTblKensakuDT == null || alOutput.FileKanriTblKensakuDT.Count == 0)
            {
                fileListCountLabel.Text = "0件";

                if (clickBtnSearch)
                {
                    // 保健所一覧 : リスト数 = 0
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                }
            }
            else
            {
                fileListCountLabel.Text = alOutput.FileKanriTblKensakuDT.Count.ToString() + "件";
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
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // ファイル名
            if (!string.IsNullOrEmpty(fileNmTextBox.Text.Trim()) && fileNmTextBox.Text.Trim().Length > 100)
            {
                errMess.Append("ファイル名は100文字以下で入力して下さい。\r\n");
            }

            if (torokuDtUseCheckBox.Checked)
            {
                if (torokuDtFromDateTimePicker.Value > torokuDtToDateTimePicker.Value)
                {
                    errMess.Append("範囲指定が正しくありません。登録日の大小関係を確認してください。\r\n");
                }
            }

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
        /// 2014/08/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // ファイル名
            fileNmTextBox.Clear();

            // 登録日検索使用区分
            torokuDtUseCheckBox.Checked = false;

            // 登録日（開始）
            torokuDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            torokuDtFromDateTimePicker.Enabled = false;

            // 登録日（終了）
            torokuDtToDateTimePicker.Value = today;
            torokuDtToDateTimePicker.Enabled = false;
        }
        #endregion

        #region CreateDataInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private FileKanriTblDataSet.FileKanriTblDataTable CreateDataInsert(string fileNmBefore)
        {
            FileKanriTblDataSet.FileKanriTblDataTable insertDT = new FileKanriTblDataSet.FileKanriTblDataTable();
            FileKanriTblDataSet.FileKanriTblRow newRow = insertDT.NewFileKanriTblRow();

            DateTime now = Common.Common.GetCurrentTimestamp();

            // ファイル区分
            newRow.FileKbn = "1";

            // ファイルNo
            newRow.FileNo = now.Year.ToString() + Utility.Saiban.GetSaibanRenban(now.Year.ToString(), Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_09);

            // 元ファイル名
            newRow.FileNmBefore = fileNmBefore;

            // ファイル名
            newRow.FileNm = newRow.FileNo + "_" + fileNmBefore;

            // ファイルパス
            newRow.FilePath = fileServerDirectory + newRow.FileNm;

            //登録日
            newRow.InsertDt = now;

            //登録者
            newRow.InsertUser = loginUser;

            //登録端末
            newRow.InsertTarm = pcUpdate;

            //更新日
            newRow.UpdateDt = now;

            //更新者
            newRow.UpdateUser = loginUser;

            //更新端末
            newRow.UpdateTarm = pcUpdate;

            // 行を挿入
            insertDT.AddFileKanriTblRow(newRow);

            //行の状態を設定
            newRow.AcceptChanges();

            newRow.SetAdded();

            return insertDT;
        }
        #endregion

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNameNew"></param>
        /// <param name="fileNmBeforeNew"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private FileKanriTblDataSet.FileKanriTblDataTable CreateDataUpdate(string fileNameNew, string fileNmBeforeNew)
        {
            // DataTable for update
            FileKanriTblDataSet.FileKanriTblDataTable updateDT = new FileKanriTblDataSet.FileKanriTblDataTable();

            FileKanriTblDataSet.FileKanriTblRow updateRow = updateDT.NewFileKanriTblRow();

            // DataRow from current DGV
            FileKanriTblDataSet.FileKanriTblKensakuRow row = (FileKanriTblDataSet.FileKanriTblKensakuRow)((DataRowView)this.fileListDataGridView.CurrentRow.DataBoundItem).Row;

            // ファイル区分 
            updateRow.FileKbn = row.FileKbn;

            // ファイルNo 
            updateRow.FileNo = row.FileNo;

            // ファイル名 
            updateRow.FileNm = fileNameNew;

            // ファイルパス 
            updateRow.FilePath = fileServerDirectory + fileNameNew;

            // 元ファイル名
            updateRow.FileNmBefore = fileNmBeforeNew;

            updateRow.InsertDt = row.InsertDt;
            updateRow.InsertTarm = row.InsertTarm;
            updateRow.InsertUser = row.InsertUser;
            updateRow.UpdateDt = row.UpdateDt;
            updateRow.UpdateTarm = row.UpdateTarm;
            updateRow.UpdateUser = row.UpdateUser;

            updateDT.AddFileKanriTblRow(updateRow);

            updateRow.AcceptChanges();

            updateRow.SetAdded();

            return updateDT;
        }
        #endregion

        #region CheckReadFilePermission
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckReadFilePermission
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="read"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckReadFilePermission(string filePath, bool read)
        {
            FileStream fs = null;

            try
            {
                if (read)
                {
                    fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                }
                else
                {
                    fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                }

                if (fs.CanRead)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

            return false;
        }
        #endregion

        #endregion

    }
    #endregion
}
