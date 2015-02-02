using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.CrossCheck.SaisuiTekiseiTenkenList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.JokasoDaichoKanri;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.CrossCheck
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiTekiseiTenkenListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　AnhNV    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiTekiseiTenkenListForm : FukjBaseForm
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

        // 下線付きフォント
        private Font underLineFont;

        // 表示用データテーブル
        //private DataTable displayDataTable;

        ///// <summary>
        ///// 更新日時 - for optimistic locking check
        ///// </summary>
        //private DateTime _kensaUpdateDt;
        //private DateTime _crossUpdateDt;

        /// <summary>
        /// 依頼年度
        /// </summary>
        private int _nendo;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaisuiTekiseiTenkenListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiTekiseiTenkenListForm()
        {
            InitializeComponent();

            // フォームのフォントのベースに下線付きフォントを生成
            underLineFont = new Font(this.Font, this.Font.Style | FontStyle.Strikeout);

            SetControlDomain();
        }
        #endregion

        #region イベント

        #region SaisuiTekiseiTenkenListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiTekiseiTenkenListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiTekiseiTenkenListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = true;
                this._defaultSearchPanelTop = this.searchPanel.Top;
                this._defaultSearchPanelHeight = this.searchPanel.Height;
                this._defaultListPanelTop = this.listPanel.Top;
                this._defaultListPanelHeight = this.listPanel.Height;

                // Get 概要 combobox source
                DataTable constDT = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_040);

                // 概要
                Utility.Utility.SetComboBoxList(gaiyouComboBox, constDT, "ConstNm", "ConstValue", true);

                // 依頼年度（現在日から年度取得した年度を初期設定）
                _nendo = Utility.DateUtility.GetNendo(Boundary.Common.Common.GetCurrentTimestamp());
                nendoTextBox.Text = _nendo.ToString();
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

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void viewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;
                if (this._searchShowFlg)//検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else////検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }

                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.listPanel,
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
        /// 2014/08/26　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Reset all search condition
                ClearSearchPanel();
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
        /// 2014/10/17　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック + 関連チェック
                if (!IsValidData()) return;

                // Search
                DoSearch();

                // Bind data to footer
                if (listDataGridView.Rows.Count > 0)
                {
                    FillUpFooter();
                }
                //else
                //{
                //    ClearFooter();
                //}
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
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (listDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // Confirm update?
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されている内容で調査結果を更新します。よろしいですか？") == DialogResult.Yes)
                {
                    // Update 検査依頼テーブル + クロスチェック結果テーブル
                    DoUpdate();
                    // Refresh the screen
                    DoSearch();
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

        #region ichiranhyoOutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ichiranhyoOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ichiranhyoOutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    // ローカルフォルダの存在確認
                    string localTempDir = Properties.Settings.Default.LocalTempDirectory;
                    if (!Directory.Exists(localTempDir))
                    {
                        // ローカルフォルダが存在しない場合はフォルダ作成
                        Directory.CreateDirectory(localTempDir);
                    }

                    dialog.Description = "野帳ファイルの出力先を指定してください。";
                    // 初期フォルダを指定
                    dialog.SelectedPath = localTempDir;
                    DialogResult result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        DateTime systemDt = Common.Common.GetCurrentTimestamp();
                        string savePath = Path.Combine(dialog.SelectedPath, "クロスチェック_調査一覧表_" + systemDt.ToString("yyyyMMdd_hhmmss"));

                        IIchiranhyoOutputBtnClickALInput alInput = new IchiranhyoOutputBtnClickALInput();
                        alInput.PrintTable = (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable)listDataGridView.DataSource;
                        alInput.SavePath = savePath;
                        new IchiranhyoOutputBtnClickApplicationLogic().Execute(alInput);

                        // Completed!
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "帳票出力処理が完了しました。");
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

        #region iraishoOutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraishoOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraishoOutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    // ローカルフォルダの存在確認
                    string localTempDir = Properties.Settings.Default.LocalTempDirectory;
                    if (!Directory.Exists(localTempDir))
                    {
                        // ローカルフォルダが存在しない場合はフォルダ作成
                        Directory.CreateDirectory(localTempDir);
                    }

                    dialog.Description = "野帳ファイルの出力先を指定してください。";
                    // 初期フォルダを指定
                    dialog.SelectedPath = localTempDir;
                    DialogResult result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        DateTime systemDt = Common.Common.GetCurrentTimestamp();
                        string savePath = Path.Combine(dialog.SelectedPath, "クロスチェック_調査依頼票_" + systemDt.ToString("yyyyMMdd_hhmmss"));

                        IIraishoOutputBtnClickALInput alInput = new IraishoOutputBtnClickALInput();
                        alInput.PrintTable = (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable)listDataGridView.DataSource;
                        alInput.SavePath = savePath;
                        new IraishoOutputBtnClickApplicationLogic().Execute(alInput);

                        // Completed!
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "帳票出力処理が完了しました。");
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

        #region houkokushoOutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： houkokushoOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void houkokushoOutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    // ローカルフォルダの存在確認
                    string localTempDir = Properties.Settings.Default.LocalTempDirectory;
                    if (!Directory.Exists(localTempDir))
                    {
                        // ローカルフォルダが存在しない場合はフォルダ作成
                        Directory.CreateDirectory(localTempDir);
                    }

                    dialog.Description = "野帳ファイルの出力先を指定してください。";
                    // 初期フォルダを指定
                    dialog.SelectedPath = localTempDir;
                    DialogResult result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        IHoukokushoOutputBtnClickALInput alInput = new HoukokushoOutputBtnClickALInput();
                        alInput.PrintTable = (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable)listDataGridView.DataSource;
                        alInput.SavePath = dialog.SelectedPath;
                        new HoukokushoOutputBtnClickApplicationLogic().Execute(alInput);

                        // Completed!
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "帳票出力処理が完了しました。");
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

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //KekkaMenuForm frm = new KekkaMenuForm();
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

        #region SaisuiTekiseiTenkenListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiTekiseiTenkenListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiTekiseiTenkenListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        ichiranhyoOutputButton.PerformClick();
                        break;
                    case Keys.F2:
                        iraishoOutputButton.PerformClick();
                        break;
                    case Keys.F3:
                        houkokushoOutputButton.PerformClick();
                        break;
                    case Keys.F5:
                        torokuButton.PerformClick();
                        break;
                    case Keys.F7:
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F12:
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

        #region listDataGridView_CellClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid user click to header row
                if (e.RowIndex == -1) return;

                // Click to 台帳ボタン(16)
                if (listDataGridView.Columns[e.ColumnIndex].Name == DaichouShowCol.Name)
                {
                    // 浄化槽保健所コード（隠し）(28)
                    string jokasoHokenjoCd = listDataGridView.CurrentRow.Cells[JokasoHokenjoCdCol.Name].Value != null
                        ? listDataGridView.CurrentRow.Cells[JokasoHokenjoCdCol.Name].Value.ToString() : string.Empty;
                    // 浄化槽台帳登録年度（隠し）(29)
                    string jokasoNendo = listDataGridView.CurrentRow.Cells[JokasoTorokuNendoCol.Name].Value != null 
                        ? listDataGridView.CurrentRow.Cells[JokasoTorokuNendoCol.Name].Value.ToString() : string.Empty;
                    // 浄化槽台帳連番（隠し）(30)
                    string jokasoRenban = listDataGridView.CurrentRow.Cells[JokasoRenbanCol.Name].Value != null
                        ? listDataGridView.CurrentRow.Cells[JokasoRenbanCol.Name].Value.ToString() : string.Empty;

                    // Open JokasoDaichoShosai form
                    JokasoDaichoShosai frm = new JokasoDaichoShosai(jokasoHokenjoCd, jokasoNendo, jokasoRenban);
                    Program.mForm.MoveNext(frm);

                    return;
                }

                FillUpFooter();
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

        #region noFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： noFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void noFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not fire this event when textbox is empty
                if (string.IsNullOrEmpty(noFromTextBox.Text)) return;

                // Padding '0' to equal the max length digits
                noFromTextBox.Text = noFromTextBox.Text.PadLeft(noFromTextBox.MaxLength, '0');

                // ~To
                noToTextBox.Text = noFromTextBox.Text;
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

        #region noToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： noToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void noToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not fire this event when textbox is empty
                if (string.IsNullOrEmpty(noToTextBox.Text)) return;

                // Padding '0' to equal the max length digits
                noToTextBox.Text = noToTextBox.Text.PadLeft(noToTextBox.MaxLength, '0');
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

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            listDataGridView.DataSource = null;
            listDataGridView.Rows.Clear();
            listDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            searchInput.IraiBangoFrom = noFromTextBox.Text;
            searchInput.IraiBangoTo = noToTextBox.Text;
            searchInput.Nendo = nendoTextBox.Text;
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.SaisuiTekiseiTenkenListKensakuDataTable.Count == 0)
            {
                // 検索結果件数
                listCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 更新日時
            //this._kensaUpdateDt = alOutput.SaisuiTekiseiTenkenListKensakuDataTable[0].UpdateDt;

            // 検索結果件数
            listCountLabel.Text = string.Concat(alOutput.SaisuiTekiseiTenkenListKensakuDataTable.Count, "件");

            // Binding source to dgv
            listDataGridView.DataSource = alOutput.SaisuiTekiseiTenkenListKensakuDataTable;

            // Coloring the dgv cells
            DgvCellsColor();
        }
        #endregion

        #region ClearSearchPanel
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchPanel
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchPanel()
        {
            //年度
            nendoTextBox.Text = _nendo.ToString();

            //依頼番号（開始）
            noFromTextBox.Clear();

            //依頼番号（終了）
            noToTextBox.Clear();
        }
        #endregion

        #region IsValidData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            // 年度
            if (string.IsNullOrEmpty(nendoTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：年度が入力されていません。");
            }

            // 依頼番号（開始＆終了）
            if (!string.IsNullOrEmpty(noFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(noToTextBox.Text.Trim()) 
                && Convert.ToInt32(noFromTextBox.Text.Trim()) > Convert.ToInt32(noToTextBox.Text.Trim())
                )
            {
                errMsg.AppendLine("範囲指定が正しくありません。依頼番号の大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region DgvCellsColor
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DgvCellsColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DgvCellsColor()
        {
            // Index of 過去 columns
            int pastIdx = 1;

            foreach (DataGridViewColumn dc in listDataGridView.Columns)
            {
                // Skip columns not in 過去(s)
                if (dc.Name != PastValue1Col.Name
                    && dc.Name != PastValue2Col.Name
                    && dc.Name != PastValue3Col.Name
                    && dc.Name != PastValue4Col.Name
                    && dc.Name != PastValue5Col.Name)
                {
                    continue;
                }

                // 過去{n}評価（隠し）(n: 1~5)
                string hyokaColNm = string.Format("PastHyoka{0}Col", pastIdx);

                foreach (DataGridViewRow dr in listDataGridView.Rows)
                {
                    if (null != dr.Cells[hyokaColNm].Value)
                    {
                        // 3:未満
                        if (dr.Cells[hyokaColNm].Value.ToString() == "3")
                        {
                            dr.Cells[dc.Name].Style.BackColor = Color.LightPink;
                            dr.Cells[dc.Name].Style.ForeColor = Color.Red;
                        }
                        else if (dr.Cells[hyokaColNm].Value.ToString() == "2") // 2:以下
                        {
                            dr.Cells[dc.Name].Style.BackColor = Color.LightCyan;
                            dr.Cells[dc.Name].Style.ForeColor = Color.Blue;
                        }
                    }
                }

                // Next 過去 column
                pastIdx++;
            }
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            // システム日付
            DateTime systemDt = Common.Common.GetCurrentTimestamp();
            DateTime kensaUpdateDt = (DateTime)listDataGridView.CurrentRow.Cells[KensaUpdateDtCol.Name].Value;

            // 検査依頼法定区分（隠し）(10)
            string kensaIraiHoteiKbn = listDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value != null
                ? listDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString() : string.Empty;
            // 検査依頼保健所コード（隠し）(11)
            string kensaIraiHokenjoCd = listDataGridView.CurrentRow.Cells[KensaIraiHokenjoCdCol.Name].Value != null
                ? listDataGridView.CurrentRow.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString() : string.Empty;
            // 検査依頼保健所コード（隠し）(12)
            string kensaIraiNendo = listDataGridView.CurrentRow.Cells[KensaIraiNendoCol.Name].Value != null
                ? listDataGridView.CurrentRow.Cells[KensaIraiNendoCol.Name].Value.ToString() : string.Empty;
            // 検査依頼連番（隠し）(13)
            string kensaIraiRenban = listDataGridView.CurrentRow.Cells[KensaIraiRenbanCol.Name].Value != null
                ? listDataGridView.CurrentRow.Cells[KensaIraiRenbanCol.Name].Value.ToString() : string.Empty;

            ITorokuBtnClickALInput alInput = new TorokuBtnClickALInput();
            alInput.SystemDt = systemDt;
            alInput.KensaUpdateDt = kensaUpdateDt;
            if (!string.IsNullOrEmpty(Convert.ToString(listDataGridView.CurrentRow.Cells[CrossCheckUpdateDtCol.Name].Value)))
            {
                alInput.CrossUpdateDt = (DateTime)listDataGridView.CurrentRow.Cells[CrossCheckUpdateDtCol.Name].Value;
            }
            alInput.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            alInput.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
            alInput.KensaIraiNendo = kensaIraiNendo;
            alInput.KensaIraiRenban = kensaIraiRenban;
            alInput.CrossCheckRiyu = gaiyouComboBox.SelectedIndex > -1 ? gaiyouComboBox.SelectedValue.ToString() : string.Empty;
            alInput.TokkiJikou = tokkiJikouTextBox.Text;
            alInput.LastSeisouDt = lastSeisouDateTimePicker.Value.ToString("yyyyMMdd");
            alInput.TatemonoYouto = tatemonoYoutoTextBox.Text;
            new TorokuBtnClickApplicationLogic().Execute(alInput);
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　AnhNV    新規作成
        /// 2014/11/10　AnhNV    基本設計書_014_001_画面_SaisuiTekiseiTenken_V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 年度
            nendoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 4);
            // 依頼番号（開始）
            noFromTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 6, HorizontalAlignment.Left);
            // 依頼番号（終了）
            noToTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 6, HorizontalAlignment.Left);

            #region 結果一覧グリッドビュー
            listDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 6);
            listDataGridView.SetStdControlDomain(IraiNoCol.Index, ZControlDomain.ZT_STD_NUM, 6, DataGridViewContentAlignment.MiddleLeft);
            listDataGridView.SetStdControlDomain(HanteiCol.Index, ZControlDomain.ZT_STD_NAME, 1);
            listDataGridView.SetStdControlDomain(GaiyouCol.Index, ZControlDomain.ZT_STD_NAME, 100);
            listDataGridView.SetStdControlDomain(TokkiJikouCol.Index, ZControlDomain.ZT_STD_NAME, 250);
            listDataGridView.SetStdControlDomain(TatemonoYoutoCol.Index, ZControlDomain.ZT_STD_NAME, 30);
            listDataGridView.SetStdControlDomain(LastSeisouDate.Index, ZControlDomain.ZT_STD_NAME, 10);
            listDataGridView.SetStdControlDomain(SaisuiinNameCol.Index, ZControlDomain.ZT_STD_NAME, 40);
            listDataGridView.SetStdControlDomain(ShoriHoushikiCol.Index, ZControlDomain.ZT_STD_NAME, 14);
            listDataGridView.SetStdControlDomain(ShoriHoushikiNmCol.Index, ZControlDomain.ZT_STD_NAME, 80);
            listDataGridView.SetStdControlDomain(NinsouCol.Index, ZControlDomain.ZT_STD_NUM, 10);
            listDataGridView.SetStdControlDomain(phCol.Index, ZControlDomain.ZT_STD_NUM, 2, 1, InputValidateUtility.SignFlg.Positive);
            listDataGridView.Columns[phCol.Index].DefaultCellStyle.Format = "#0.00";
            listDataGridView.SetStdControlDomain(BodCol.Index, ZControlDomain.ZT_STD_NUM, 4, 1, InputValidateUtility.SignFlg.Positive);
            listDataGridView.Columns[BodCol.Index].DefaultCellStyle.Format = "#0.00";
            listDataGridView.SetStdControlDomain(AverageValueCol.Index, ZControlDomain.ZT_STD_NUM, 4);
            listDataGridView.Columns[AverageValueCol.Index].DefaultCellStyle.Format = "#0.0";
            listDataGridView.SetStdControlDomain(ThisValueCol.Index, ZControlDomain.ZT_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(PastValue1Col.Index, ZControlDomain.ZT_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(PastValue2Col.Index, ZControlDomain.ZT_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(PastValue3Col.Index, ZControlDomain.ZT_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(PastValue4Col.Index, ZControlDomain.ZT_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(PastValue5Col.Index, ZControlDomain.ZT_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(KakuninSuuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            listDataGridView.SetStdControlDomain(SoSuuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            listDataGridView.SetStdControlDomain(HasseiRateCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            listDataGridView.Columns[HasseiRateCol.Index].DefaultCellStyle.Format = "#0.0";
            #endregion

            // 特記事項
            tokkiJikouTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 250);
            // 建物用途
            tatemonoYoutoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
        }
        #endregion

        #region MakeAvgOnDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeAvgOnDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25　AnhNV    基本設計書_014_001_画面_SaisuiTekiseiTenken_V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable MakeAvgOnDgv
        //(
        //    KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable dgvSource
        //)
        //{
        //    foreach (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row in dgvSource)
        //    {
        //        int avgNum = 0;
        //        decimal pastValue = 0;
        //        if (!row.IsPastValue1ColNull())
        //        {
        //            pastValue += row.PastValue1Col;
        //            avgNum++;
        //        }
        //        if (!row.IsPastValue2ColNull())
        //        {
        //            pastValue += row.PastValue2Col;
        //            avgNum++;
        //        }
        //        if (!row.IsPastValue3ColNull())
        //        {
        //            pastValue += row.PastValue3Col;
        //            avgNum++;
        //        }
        //        if (!row.IsPastValue4ColNull())
        //        {
        //            pastValue += row.PastValue4Col;
        //            avgNum++;
        //        }
        //        if (!row.IsPastValue5ColNull())
        //        {
        //            pastValue += row.PastValue5Col;
        //            avgNum++;
        //        }
        //        avgNum = avgNum == 0 ? 1 : avgNum;

        //        // 平均(39)
        //        row.AverageValueCol = Math.Round(pastValue / avgNum, 1);
        //        // 発生率(98)
        //        if (!row.IsSoSuuColNull() && row.SoSuuCol != 0)
        //        {
        //            row.HasseiRateCol = Math.Round((decimal)row.KakuninSuuCol / row.SoSuuCol, 1);
        //        }
        //    }

        //    return dgvSource;
        //}
        #endregion

        #region FillUpFooter
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FillUpFooter
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/27　AnhNV    基本設計書_014_001_画面_SaisuiTekiseiTenken_V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FillUpFooter()
        {
            if (null != listDataGridView.CurrentRow.Cells[GaiyouCol.Name].Value)
            {
                // 概要(100)
                gaiyouComboBox.SelectedIndex = gaiyouComboBox.FindStringExact(listDataGridView.CurrentRow.Cells[GaiyouCol.Name].Value.ToString());
            }

            if (null != listDataGridView.CurrentRow.Cells[TokkiJikouCol.Name].Value)
            {
                // 特記事項(101)
                tokkiJikouTextBox.Text = listDataGridView.CurrentRow.Cells[TokkiJikouCol.Name].Value.ToString();
            }

            if (null != listDataGridView.CurrentRow.Cells[LastSeisouDate.Name].Value
                && Utility.Utility.IsDateFormat(listDataGridView.CurrentRow.Cells[LastSeisouDate.Name].Value.ToString()))
            {
                // 前回清掃日(102)
                lastSeisouDateTimePicker.Value = Convert.ToDateTime(listDataGridView.CurrentRow.Cells[LastSeisouDate.Name].Value.ToString());
            }

            if (null != listDataGridView.CurrentRow.Cells[TatemonoYoutoCol.Name].Value)
            {
                // 建物用途(103)
                tatemonoYoutoTextBox.Text = listDataGridView.CurrentRow.Cells[TatemonoYoutoCol.Name].Value.ToString();
            }
        }
        #endregion

        #region ClearFooter
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearFooter
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/27　AnhNV    基本設計書_014_001_画面_SaisuiTekiseiTenken_V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearFooter()
        {
            // 前回清掃日(102)
            lastSeisouDateTimePicker.Value = Common.Common.GetCurrentTimestamp();
            // 建物用途(103)
            tatemonoYoutoTextBox.Text = string.Empty;
            // 特記事項(101)
            tokkiJikouTextBox.Text = string.Empty;
            // 概要(100)
            gaiyouComboBox.SelectedIndex = 0;
        }
        #endregion

        #endregion
    }
    #endregion
}
