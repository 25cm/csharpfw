using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaFukaJohoAdd;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaFukaJohoAddForm
    /// <summary>
    /// 検査付加情報ダイアログ
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  AnhNV        新規作成
    /// 2014/12/18  小松　　    再作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaFukaJohoAddForm : Form
    {
        #region プロパティ(public)

        /// <summary>
        /// Display mode
        /// </summary>
        public enum DispMode
        {
            // 追加
            Insert,
            // 変更
            Update,
            // 削除
            Delete,
            // 参照
            View,
        }

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 検査付加情報見出し
        /// </summary>
        private string _midashi;
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        private string _kensaIraiHoteiKbn;
        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        private string _kensaIraiHokenjoCd;
        /// <summary>
        /// 検査依頼年度
        /// </summary>
        private string _kensaIraiNendo;
        /// <summary>
        /// 検査依頼連番
        /// </summary>
        private string _kensaIraiRenban;
        /// <summary>
        /// 関連ファイル種別（連番）（更新削除時のみ）
        /// </summary>
        private string _kensaIraiFileShubetsuCd;
        /// <summary>
        /// 関連ファイル名（更新削除時のみ）
        /// </summary>
        private string _kensaIraiKanrenFilePath;
        /// <summary>
        /// Display mode
        /// </summary>
        public DispMode _mode;

        // 検査依頼関連ファイルテーブル（検査依頼番号：ｎ件）
        private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable _allTable;

        // 検査依頼関連ファイルテーブル（種別までの主キー：１件）
        private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable _kkfTable;

        // 新規追加関連ファイル名（追加ボタン押下後にセット）
        private string _localFilePath = string.Empty;

        #endregion

        #region 定数定義

        // 関連ファイル名のベース
        private const string DEF_FILE_BASE_NAME = "検査依頼関連ファイル";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaFukaJohoAddForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="midashi">検査付加情報見出し</param>
        /// <param name="kensaIraiHoteiKbn">検査依頼法定区分</param>
        /// <param name="kensaIraiHokenjoCd">検査依頼保健所CD</param>
        /// <param name="kensaIraiNendo">検査依頼年度</param>
        /// <param name="kensaIraiRenban">検査依頼連番</param>
        /// <param name="mode">画面モード</param>
        /// <param name="kensaIraiFileShubetsuCd">関連ファイル種別（連番）</param>
        /// <param name="kensaIraiKanrenFilePath">関連ファイルパス</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaFukaJohoAddForm
        (
            string midashi,
            string kensaIraiHoteiKbn,
            string kensaIraiHokenjoCd,
            string kensaIraiNendo,
            string kensaIraiRenban,
            DispMode mode,
            string kensaIraiFileShubetsuCd = "",
            string kensaIraiKanrenFilePath = ""
        )
        {
            InitializeComponent();
            this._midashi = midashi;
            this._kensaIraiHoteiKbn = kensaIraiHoteiKbn;
            this._kensaIraiHokenjoCd = kensaIraiHokenjoCd;
            this._kensaIraiNendo = kensaIraiNendo;
            this._kensaIraiRenban = kensaIraiRenban;
            this._mode = mode;
            this._kensaIraiFileShubetsuCd = kensaIraiFileShubetsuCd;
            this._kensaIraiKanrenFilePath = kensaIraiKanrenFilePath;
        }
        #endregion


        #region イベント

        #region KensaFukaJohoAddForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaFukaJohoAddForm_Load
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaFukaJohoAddForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Initial load
                DoFormLoad();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region KensaFukaJohoAddForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaFukaJohoAddForm_KeyDown
        /// <summary>
        /// フォームキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaFukaJohoAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.Focus();
                        torokuButton.PerformClick();
                        break;
                    case Keys.F5:
                        uploadButton.Focus();
                        uploadButton.PerformClick();
                        break;
                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 追加・変更・削除ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_mode != DispMode.Delete)
                {
                    // 見出し(1) is empty?
                    if (string.IsNullOrEmpty(midashiTextBox.Text.Trim()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "見出しを入力してください。");
                        return;
                    }
                }

                _localFilePath = string.Empty;

                // Which mode?
                switch (_mode)
                {
                    case DispMode.Insert:
                        // 新規に関連ファイルを作成
                        DoInsert();
                        // 追加ボタン非活性
                        torokuButton.Enabled = false;
                        // 見出しも入力不可
                        midashiTextBox.ReadOnly = true;
                        // アップロードボタン活性
                        uploadButton.Enabled = true;
                        // 作成した Excelファイルを開く
                        openKanrenFile(_localFilePath);
                        break;
                    case DispMode.Update:
                        // 変更対象の関連ファイルをダウンロード
                        DoDownload();
                        // 追加ボタン非活性
                        torokuButton.Enabled = false;
                        // 見出しも入力不可
                        midashiTextBox.ReadOnly = true;
                        // アップロードボタン活性
                        uploadButton.Enabled = true;
                        // ダウンロードした関連ファイルを開く
                        openKanrenFile(_localFilePath);
                        break;
                    case DispMode.Delete:
                        // ファイル削除
                        if (DoDelete())
                        {
                            // 正常の場合は、閉じる。
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        break;
                    default:
                        break;
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

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.Close();
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
        /// アップロードボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uploadButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (_mode)
                {
                    case DispMode.Insert:
                    case DispMode.Update:
                        // 追加 or 変更したファイルをアップロード
                        if (DoUpload(_mode))
                        {
                            // アップロード後は閉じる
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        break;
                    default:
                        break;
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

        #endregion


        #region メソッド(private)

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// フォームロード時処理
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // 検査依頼関連ファイルテーブルからデータ取得
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
            alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
            alInput.KensaIraiNendo = _kensaIraiNendo;
            alInput.KensaIraiRenban = _kensaIraiRenban;
            alInput.KensaIraiFileShubetsuCd = _kensaIraiFileShubetsuCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            // 検査依頼番号に紐付く分（ｎ件）
            _allTable = alOutput.KensaIraiKanrenFileTblAllDT;
            // 関連ファイル種別を指定（１件）
            _kkfTable = alOutput.KensaIraiKanrenFileTblDT;

            // Control screen
            switch (_mode)
            {
                case DispMode.Insert:
                    this.Text = "検査付加情報追加";
                    torokuButton.Text = "F1:追加";
                    midashiTextBox.Text = string.Empty;
                    // 初期は非表示。追加後に表示
                    uploadButton.Enabled = false;
                    midashiTextBox.Focus();
                    break;
                case DispMode.Update:
                    this.Text = "検査付加情報変更";
                    torokuButton.Text = "F1:変更";
                    midashiTextBox.Text = _midashi;
                    // 初期は非表示。追加後に表示
                    uploadButton.Enabled = false;
                    //CopyFileFromServer();
                    midashiTextBox.Focus();
                    break;
                case DispMode.Delete:
                    this.Text = "検査付加情報削除";
                    torokuButton.Text = "F1:削除";
                    midashiTextBox.Text = _midashi;
                    midashiTextBox.ReadOnly = true;
                    uploadButton.Enabled = false;
                    torokuButton.Focus();
                    this.ActiveControl = torokuButton;
                    break;
                case DispMode.View:
                    // 変更対象の関連ファイルをダウンロード
                    DoDownload();
                    // ダウンロードした関連ファイルを開く
                    openKanrenFile(_localFilePath);
                    // 開いたら自身は閉じる。表示するのみ。
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region openKanrenFile
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： openKanrenFile
        /// <summary>
        /// 関連ファイル実行（関連付けられているアプリで開く）
        /// </summary>
        /// <param name="filePathName"></param>
        /// <return>
        /// 
        /// </return>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool openKanrenFile(string filePathName)
        {
            if (File.Exists(filePathName))
            {
                // ファイルを開く
                System.Diagnostics.Process.Start(filePathName);
            }
            else
            {
                MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("ファイルが存在しません。{0}", filePathName));
                return false;
            }
            return true;
        }
        #endregion

        #region DoInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoInsert
        /// <summary>
        /// 新規に関連ファイル(.xls)を作成
        /// </summary>
        /// <param name="workbook"></param>
        /// <return>
        /// 
        /// </return>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoInsert()
        {
            // ローカルにファイル作成

            // 保存フォルダ
            string saveDir = Path.Combine(Path.Combine(Path.Combine(Path.Combine(_kensaIraiHoteiKbn, _kensaIraiHokenjoCd), _kensaIraiNendo), _kensaIraiRenban), FukjBizSystem.SettingReader.KensaFukaJohoFileFolder);
            string localDir = Path.Combine(Properties.Settings.Default.LocalTempDirectory, saveDir);
            // ローカルフォルダの存在確認
            if (!Directory.Exists(localDir))
            {
                // ローカルフォルダが存在しない場合はフォルダ作成
                Directory.CreateDirectory(localDir);
            }

            string fileName = DEF_FILE_BASE_NAME + "_" + Common.Common.GetCurrentTimestamp().ToString("yyyyMMddHHmmss") + ".xls";
            _localFilePath = Path.Combine(localDir, fileName);
            // 取込ローカルファイル名の存在確認
            if (File.Exists(_localFilePath))
            {
                // ローカルファイルが存在する場合は一旦削除
                File.Delete(_localFilePath);
            }

            // 新規に関連ファイルを作成
            CreateNewKanrenExcelFile(_localFilePath);
        }
        #endregion

        #region DoUpload
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpload
        /// <summary>
        /// 追加・変更した関連ファイルをサーバにアップロード
        /// （関連テーブルの登録・更新）
        /// </summary>
        /// <param name="mode">画面モード</param>
        /// <return>
        /// 
        /// </return>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoUpload(DispMode mode)
        {
            // サーバファイル名の存在確認
            if (!File.Exists(_localFilePath))
            {
                MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("アップロードするファイルが存在しません。{0}", _localFilePath));
                return false;
            }

            // 保存フォルダ
            string saveDir = Path.Combine(Path.Combine(Path.Combine(Path.Combine(_kensaIraiHoteiKbn, _kensaIraiHokenjoCd), _kensaIraiNendo), _kensaIraiRenban), FukjBizSystem.SettingReader.KensaFukaJohoFileFolder);
            // サーバフォルダ名
            string serverFolder = Path.Combine(Properties.Settings.Default.SharedFolderDirectory, saveDir);
            // サーバファイル名
            string shareFilePath = Path.Combine(serverFolder, Path.GetFileName(_localFilePath));

            try
            {
                // 共有フォルダに接続
                if (!SharedFolderUtility.Connect())
                {
                    // サーバに接続できません
                    // 「サーバに接続できません。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバに接続できません。{0}", serverFolder));
                    return false;
                }

                // サーバに保存先の存在確認
                if (!Directory.Exists(serverFolder))
                {
                    // 存在しない場合は、作成
                    Directory.CreateDirectory(serverFolder);
                }
                // 保存するファイル名の存在確認
                if (File.Exists(shareFilePath))
                {
                    // 同ファイル名のファイルが存在する場合は削除
                    File.Delete(shareFilePath);
                }

                // 共有フォルダにアップロード
                if (!SharedFolderUtility.UploadFile(_localFilePath, shareFilePath))
                {
                    // サーバへのアップロードに失敗しました。
                    // 「サーバへのアップロードに失敗しました。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバへのアップロードに失敗しました。{0} {1}", shareFilePath, _localFilePath));
                    return false;
                }
            }
            catch (Exception ex)
            {
                // エラー処理
                // 共有フォルダへのアクセスに失敗しました。
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("共有フォルダへのアクセスに失敗しました。{0}", shareFilePath));
                throw ex;
            }
            finally
            {
                // 共有フォルダから切断
                SharedFolderUtility.Disconnect();
            }

            if (mode == DispMode.Insert)
            {
                // DB登録
                ITorokuBtnClickALInput alInput = new TorokuBtnClickALInput();
                alInput.DispMode = _mode;
                alInput.SystemDt = Common.Common.GetCurrentTimestamp();
                alInput.KensaIraiKanrenFileTblDataTable = CreateKensaIraiKanrenFileTblInsert(shareFilePath);
                new TorokuBtnClickApplicationLogic().Execute(alInput);
            }
            else
            {
                // DB更新
                ITorokuBtnClickALInput alInput = new TorokuBtnClickALInput();
                alInput.DispMode = _mode;
                alInput.SystemDt = Common.Common.GetCurrentTimestamp();
                alInput.KensaIraiKanrenFileTblDataTable = CreateKensaIraiKanrenFileTblUpdate(shareFilePath);
                new TorokuBtnClickApplicationLogic().Execute(alInput);
            }

            return true;
        }
        #endregion

        #region DoDownload
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoDownload
        /// <summary>
        /// サーバの関連ファイルをローカルフォルダにダウンロード
        /// </summary>
        /// <return>
        /// 
        /// </return>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoDownload()
        {
            // 保存フォルダ
            string saveDir = Path.Combine(Path.Combine(Path.Combine(Path.Combine(_kensaIraiHoteiKbn, _kensaIraiHokenjoCd), _kensaIraiNendo), _kensaIraiRenban), FukjBizSystem.SettingReader.KensaFukaJohoFileFolder);
            // ローカルフォルダ名
            string localFolder = Path.Combine(Properties.Settings.Default.LocalTempDirectory, saveDir);
            // ローカルファイル名
            _localFilePath = Path.Combine(localFolder, Path.GetFileName(_kensaIraiKanrenFilePath));

            // 取込ローカルフォルダの存在確認
            if (!Directory.Exists(localFolder))
            {
                // ローカルフォルダが存在しない場合はフォルダ作成
                Directory.CreateDirectory(localFolder);
            }

            // 取込ローカルファイル名の存在確認
            if (File.Exists(_localFilePath))
            {
                // ローカルファイルが存在する場合は削除
                File.Delete(_localFilePath);
            }

            try
            {
                // 共有フォルダに接続
                if (!SharedFolderUtility.Connect())
                {
                    // サーバに接続できません
                    // 「サーバに接続できません。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバに接続できません。{0}", Path.GetDirectoryName(_kensaIraiKanrenFilePath)));
                    return false;
                }

                // サーバファイル名の存在確認
                if (!File.Exists(_kensaIraiKanrenFilePath))
                {
                    // サーバに 関連ファイルが存在しない
                    // 「指定された{0}は存在しません。」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("指定された関連ファイルが存在しません。{0}", _kensaIraiKanrenFilePath));
                    // エラー
                    return false;
                }

                // 共有フォルダからダウンロード
                if (!SharedFolderUtility.DownloadFile(_localFilePath, _kensaIraiKanrenFilePath))
                {
                    // サーバから 関連ファイルのダウンロードに失敗しました。
                    // 「サーバから 関連ファイルのダウンロードに失敗しました。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバから関連ファイルのダウンロードに失敗しました。{0} {1}", _kensaIraiKanrenFilePath, _localFilePath));
                    return false;
                }
            }
            catch (Exception ex)
            {
                // エラー処理
                // 共有フォルダへのアクセスに失敗しました。
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("共有フォルダへのアクセスに失敗しました。{0}", Path.GetDirectoryName(_kensaIraiKanrenFilePath)));
                throw ex;
            }
            finally
            {
                // 共有フォルダから切断
                SharedFolderUtility.Disconnect();
            }
            return true;
        }
        #endregion

        #region DoDelete
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoDelete
        /// <summary>
        /// サーバの関連ファイルを削除
        /// （関連テーブルの削除）
        /// </summary>
        /// <return>
        /// 
        /// </return>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoDelete()
        {
            // 取込確認
            if (MessageForm.Show2(MessageForm.DispModeType.Question,
                string.Format("関連ファイル[{0}]を削除します。よろしいですか？", midashiTextBox.Text))
                != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            }

            try
            {
                // 共有フォルダに接続
                if (!SharedFolderUtility.Connect())
                {
                    // サーバに接続できません
                    // 「サーバに接続できません。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバに接続できません。{0}", Path.GetDirectoryName(_kensaIraiKanrenFilePath)));
                    return false;
                }

                // サーバファイル名の存在確認
                if (!File.Exists(_kensaIraiKanrenFilePath))
                {
                    // サーバに 関連ファイルが存在しない
                    // 「指定された{0}は存在しません。」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("指定された関連ファイルが存在しません。{0}", _kensaIraiKanrenFilePath));
                    // エラー
                    return false;
                }

                try
                {

                    // サーバファイルを削除
                    File.Delete(_kensaIraiKanrenFilePath);
                }
                catch
                {
                    // サーバから 関連ファイルのダウンロードに失敗しました。
                    // 「サーバから 関連ファイルのダウンロードに失敗しました。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバから関連ファイルの削除に失敗しました。{0}", _kensaIraiKanrenFilePath));
                    return false;
                }
            }
            catch (Exception ex)
            {
                // エラー処理
                // 共有フォルダへのアクセスに失敗しました。
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("共有フォルダへのアクセスに失敗しました。{0}", Path.GetDirectoryName(_kensaIraiKanrenFilePath)));
                throw ex;
            }
            finally
            {
                // 共有フォルダから切断
                SharedFolderUtility.Disconnect();
            }

            // レコード削除
            ITorokuBtnClickALInput alInput = new TorokuBtnClickALInput();
            alInput.DispMode = _mode;
            alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
            alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
            alInput.KensaIraiNendo = _kensaIraiNendo;
            alInput.KensaIraiRenban = _kensaIraiRenban;
            alInput.KensaIraiFileShubetsuCd = _kensaIraiFileShubetsuCd;
            alInput.SystemDt = Common.Common.GetCurrentTimestamp();
            new TorokuBtnClickApplicationLogic().Execute(alInput);

            return true;
        }
        #endregion

        #region CreateKensaIraiKanrenFileTblInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiKanrenFileTblInsert
        /// <summary>
        /// 登録用の検査情報関連ファイルテーブル作成
        /// </summary>
        /// <param name="serverFile">サーバの関連ファイル名</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable CreateKensaIraiKanrenFileTblInsert(string serverFile)
        {
            DateTime nowDt = Common.Common.GetCurrentTimestamp();

            int maxKensaIraiFileShubetsuCd = 0;
            object maxKekkaIndexValue = _allTable.Compute("MAX(KensaIraiFileShubetsuCd)", null);
            if (maxKekkaIndexValue != System.DBNull.Value && maxKekkaIndexValue != null)
            {
                try
                {
                    maxKensaIraiFileShubetsuCd = Convert.ToInt32((string)maxKekkaIndexValue);
                }
                catch
                {
                }
            }

            KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable table = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();
            KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow newRow = table.NewKensaIraiKanrenFileTblRow();

            // 検査依頼法定区分
            newRow.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
            // 検査依頼保健所コード
            newRow.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
            // 検査依頼年度
            newRow.KensaIraiNendo = _kensaIraiNendo;
            // 検査依頼連番
            newRow.KensaIraiRenban = _kensaIraiRenban;
            // 関連ファイル種別
            maxKensaIraiFileShubetsuCd++;
            newRow.KensaIraiFileShubetsuCd = maxKensaIraiFileShubetsuCd.ToString().PadLeft(3, '0');
            // 関連ファイルパス
            newRow.KensaIraiKanrenFilePath = serverFile;
            // 見出し
            newRow.KensaIraiKanrenFileMidashi = midashiTextBox.Text;
            // 登録日
            newRow.InsertDt = nowDt;
            // 登録者
            newRow.InsertUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 登録端末
            newRow.InsertTarm = Dns.GetHostName();
            // 更新日
            newRow.UpdateDt = nowDt;
            // 更新者
            newRow.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            newRow.UpdateTarm = Dns.GetHostName();

            // Add new
            table.AddKensaIraiKanrenFileTblRow(newRow);
            newRow.AcceptChanges();
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateKensaIraiKanrenFileTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiKanrenFileTblUpdate
        /// <summary>
        /// 更新用の検査情報関連ファイルテーブル作成
        /// </summary>
        /// <param name="serverFile">サーバの関連ファイル名</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable CreateKensaIraiKanrenFileTblUpdate
        (
            string serverFile
        )
        {
            // 関連ファイルパス
            _kkfTable[0].KensaIraiKanrenFilePath = serverFile;
            // 見出し
            _kkfTable[0].KensaIraiKanrenFileMidashi = midashiTextBox.Text;
            // 更新日
            //table[0].UpdateDt = Common.Common.GetCurrentTimestamp();
            // 更新者
            _kkfTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            _kkfTable[0].UpdateTarm = Dns.GetHostName();

            return _kkfTable;
        }
        #endregion

        #region CreateNewKanrenExcelFile
        ///////////////////////////////////////////////////////////////
        // メソッド名 ： CreateNewKanrenExcelFile
        /// <summary>
        /// 新規に関連ファイルを作成
        /// </summary>
        /// <param name="filePathName">ファイル名</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  小松        新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public void CreateNewKanrenExcelFile(string filePathName)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;

            try
            {
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                // 見出し設定
                xlWorkSheet.Cells[1, 1] = midashiTextBox.Text.Trim();

                // ファイル保存
                xlWorkBook.SaveAs(filePathName,
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
            catch
            {
                throw;
            }
            finally
            {
                Common.Common.releaseObject(xlWorkSheet);
                Common.Common.releaseObject(xlWorkBook);
                Common.Common.releaseObject(xlApp);
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
