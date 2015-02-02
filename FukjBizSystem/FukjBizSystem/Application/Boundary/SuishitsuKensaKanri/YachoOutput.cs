using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.YachoOutput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YachoOutputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  AnhNV        新規作成
    /// 2015/01/22  小松　　　　クリアボタン押下時は初期値を設定
    ///                         検査区分を切り替えた時の処理を正しく修正
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YachoOutputForm : FukjBaseForm
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
        /// DataGridView source
        /// </summary>
        private KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable _dgvSource;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YachoOutputForm
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public YachoOutputForm()
        {
            InitializeComponent();
            SetStdControlDomain();
        }
        #endregion

        #region イベント

        #region YachoOutputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YachoOutputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YachoOutputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region gaikanKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gaikanKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gaikanKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!gaikanKensaRadioButton.Checked) { return; }
                DgvDisplayControl();
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

        #region suishitsuKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!suishitsuKensaRadioButton.Checked) { return; }
                DgvDisplayControl();
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

        #region keiryoShomeiKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoShomeiKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiryoShomeiKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!keiryoShomeiKensaRadioButton.Checked) { return; }
                DgvDisplayControl();
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

        #region suishitsuKensaIraiNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaIraiNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaIraiNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Skip empty string
                if (string.IsNullOrEmpty(suishitsuKensaIraiNoFromTextBox.Text)) { return; }

                // Pad '0' to fixed length
                suishitsuKensaIraiNoFromTextBox.Text = suishitsuKensaIraiNoFromTextBox.Text.PadLeft(suishitsuKensaIraiNoFromTextBox.MaxLength, '0');
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

        #region suishitsuKensaIraiNoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaIraiNoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaIraiNoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Skip empty string
                if (string.IsNullOrEmpty(suishitsuKensaIraiNoToTextBox.Text)) { return; }

                // Pad '0' to fixed length
                suishitsuKensaIraiNoToTextBox.Text = suishitsuKensaIraiNoToTextBox.Text.PadLeft(suishitsuKensaIraiNoToTextBox.MaxLength, '0');
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Reset all search input
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 関連チェック
                if (!RelationCheck()) { return; }

                // Clear the dgv
                kensaListDataGridView.DataSource = null;
                kensaListDataGridView.Rows.Clear();

                ISearchBtnClickALInput alInput = new SearchBtnClickALInput();
                MakeSearchCond(alInput);
                ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(alInput);
                _dgvSource = alOutput.YachoOutputKensaListDataTable;

                // Binding the new source
                if (keiryoShomeiKensaRadioButton.Checked)
                {
                    //// Group the result search
                    //var result = from resultRow in alOutput.YachoOutputKensaListDataTable.AsEnumerable()
                    //                              group resultRow by new { resultRow.IraiNendoCol, resultRow.ShishoCdCol, resultRow.SuishitsuKensaIraiNoCol };

                    //DataTable newDgvSource = result.CopyToDataTable();

                    string tempIraiNendo = string.Empty;
                    string tempShisho = string.Empty;
                    string tempIraiNo = string.Empty;
                    KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable newTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

                    int rowIdx = 1;
                    foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in
                        alOutput.YachoOutputKensaListDataTable.Select(string.Empty, "IraiNendoCol, ShishoCdCol, SuishitsuKensaIraiNoCol, SuishitsuShikenKoumokuCd"))
                    {
                        // Select distinct
                        if (tempIraiNendo != row.IraiNendoCol
                            || tempShisho != row.ShishoCdCol
                            || tempIraiNo != row.SuishitsuKensaIraiNoCol)
                        {
                            row.RowNoCol = rowIdx;

                            newTable.ImportRow(row);
                            rowIdx++;
                        }

                        tempIraiNendo = row.IraiNendoCol;
                        tempShisho = row.ShishoCdCol;
                        tempIraiNo = row.SuishitsuKensaIraiNoCol;
                    }

                    // No records was found
                    if (newTable.Count == 0)
                    {
                        // 検索結果件数
                        srhListCountLabel.Text = "0件";
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                        return;
                    }

                    // 検索結果件数
                    srhListCountLabel.Text = string.Concat(newTable.Count, "件");
                    kensaListDataGridView.DataSource = newTable;
                }
                else
                {
                    // No records was found
                    if (alOutput.YachoOutputKensaListDataTable.Count == 0)
                    {
                        // 検索結果件数
                        srhListCountLabel.Text = "0件";
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                        return;
                    }

                    // 検索結果件数
                    srhListCountLabel.Text = string.Concat(alOutput.YachoOutputKensaListDataTable.Count, "件");
                    kensaListDataGridView.DataSource = alOutput.YachoOutputKensaListDataTable;
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

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
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
                    this.srhListPanel,
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

        #region allButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： allButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void allButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (kensaListDataGridView.Rows.Count == 0) { return; }

                // Check all for checkboxes
                CkbChecked("1");
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

        #region kaijoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaijoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaijoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (kensaListDataGridView.Rows.Count == 0) { return; }

                // Clear all checkboxes checked
                CkbChecked("0");
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

        #region YachoOutputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YachoOutputForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YachoOutputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
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

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Back to menu
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

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Print data
                KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable printTable = GetTableFromSelectedDgvRows();

                // 未選択チェック
                if (printTable.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象の検査が選択されていません。");
                    return;
                }

                // ローカルフォルダの存在確認
                string localTempDir = Properties.Settings.Default.LocalTempDirectory;
                if (!Directory.Exists(localTempDir))
                {
                    // ローカルフォルダが存在しない場合はフォルダ作成
                    Directory.CreateDirectory(localTempDir);
                }

                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "野帳ファイルの出力先を指定してください。";
                // 初期フォルダを指定
                dialog.SelectedPath = localTempDir;
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Current system date
                    DateTime systemDt = Common.Common.GetCurrentTimestamp();

                    IOutputBtnClickALInput alInput = new OutputBtnClickALInput();
                    alInput.SelectedPath = dialog.SelectedPath;
                    alInput.TypeSearch = GetTypeSearch();
                    alInput.SystemDt = systemDt;
                    alInput.IraiNoFolder = GetIraiNoFolder();
                    alInput.PrintTable = printTable;
                    IOutputBtnClickALOutput alOutput = new OutputBtnClickApplicationLogic().Execute(alInput);

                    // Error
                    if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
                        return;
                    }

                    // Export completed!
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "野帳出力処理が完了しました。");
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
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            // System date
            DateTime systemDt = Common.Common.GetCurrentTimestamp();

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());
            // 依頼年度(5)
            //iraiNendoTextBox.Text = systemDt.ToString("yyyy");
            iraiNendoTextBox.Text = (Utility.DateUtility.GetNendo(systemDt)).ToString();
            // 支所(6)
            //Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
            shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 水質検査デフォルト
            suishitsuKensaRadioButton.Checked = true;

            // Control the display of dgv (show/hide columns)
            DgvDisplayControl();
        }
        #endregion

        #region DgvDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DgvDisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DgvDisplayControl()
        {
            // Clear the dgv
            kensaListDataGridView.DataSource = null;
            kensaListDataGridView.Rows.Clear();
            // 検索結果件数
            srhListCountLabel.Text = "0件";

            // 検査種別/外観(2) is ON
            if (gaikanKensaRadioButton.Checked)
            {
                kensaListDataGridView.Columns[saisuiDtCol.Name].Visible = false;
                kensaListDataGridView.Columns[saisuiinNmCol.Name].Visible = false;
                kensaListDataGridView.Columns[screeningKbnCol.Name].Visible = true;
                kensaListDataGridView.Columns[kensaNoCol.Name].HeaderText = "検査依頼番号";
            }

            // 検査種別/水質(3) is ON
            if (suishitsuKensaRadioButton.Checked)
            {
                kensaListDataGridView.Columns[saisuiDtCol.Name].Visible = false;
                kensaListDataGridView.Columns[saisuiinNmCol.Name].Visible = true;
                kensaListDataGridView.Columns[saisuiinNmCol.Name].HeaderText = "採水員名";
                kensaListDataGridView.Columns[screeningKbnCol.Name].Visible = false;
                kensaListDataGridView.Columns[kensaNoCol.Name].HeaderText = "検査依頼番号";
            }

            // 検査種別/計量証明(4) is ON
            if (keiryoShomeiKensaRadioButton.Checked)
            {
                kensaListDataGridView.Columns[saisuiDtCol.Name].Visible = true;
                kensaListDataGridView.Columns[saisuiinNmCol.Name].Visible = true;
                kensaListDataGridView.Columns[saisuiinNmCol.Name].HeaderText = "採水業者";
                kensaListDataGridView.Columns[screeningKbnCol.Name].Visible = false;
                kensaListDataGridView.Columns[hoteiKbnCol.Name].Visible = false;
                kensaListDataGridView.Columns[kensaNoCol.Name].HeaderText = "計量証明番号";
            }
        }
        #endregion

        #region SetStdControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // TextBoxes
            iraiNendoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 4);
            suishitsuKensaIraiNoFromTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 6);
            suishitsuKensaIraiNoToTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 6);

            // Dgv
            //kensaListDataGridView.SetControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM);
            //kensaListDataGridView.SetControlDomain(iraiNendoCol.Index, ZControlDomain.ZG_STD_NUM);
            //kensaListDataGridView.SetControlDomain(shishoCdCol.Index, ZControlDomain.ZG_STD_CD);
            kensaListDataGridView.SetStdControlDomain(suishitsuKensaIraiNoCol.Index, ZControlDomain.ZG_STD_CD, DataGridViewContentAlignment.MiddleRight);
            //kensaListDataGridView.SetControlDomain(hoteiKbnCol.Index, ZControlDomain.ZG_STD_NAME);
            kensaListDataGridView.SetStdControlDomain(kensaNoCol.Index, ZControlDomain.ZG_STD_NAME);
            kensaListDataGridView.SetStdControlDomain(uketsukeDtCol.Index, ZControlDomain.ZG_STD_NAME, Int32.MaxValue, DataGridViewContentAlignment.MiddleCenter);
            kensaListDataGridView.SetStdControlDomain(daichoNoCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(setchishaNmCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(setchishaAdrCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(setchiAdrCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(makerNmCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(katashikiNmCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(shorihoshikiKbnCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(shorihoshikiNmCol.Index, ZControlDomain.ZG_STD_NAME);
            //kensaListDataGridView.SetControlDomain(ninsoCol.Index, ZControlDomain.ZG_STD_NUM);
            //kensaListDataGridView.SetControlDomain(screeningKbnCol.Index, ZControlDomain.ZG_STD_NAME);
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
        /// 2014/12/04  AnhNV　　    新規作成
        /// 2015/01/22  小松　　　　クリアボタン押下時は初期値を設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchPanel()
        {
            // 水質検査デフォルト
            suishitsuKensaRadioButton.Checked = true;
            // 依頼年度(5)
            //iraiNendoTextBox.Text = string.Empty;
            DateTime systemDt = Common.Common.GetCurrentTimestamp();
            iraiNendoTextBox.Text = (Utility.DateUtility.GetNendo(systemDt)).ToString();
            // 支所(6)
            //shishoComboBox.SelectedIndex = -1;
            shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 水質検査依頼番号（開始）(7)
            suishitsuKensaIraiNoFromTextBox.Text = string.Empty;
            // 水質検査依頼番号（終了）(8)
            suishitsuKensaIraiNoToTextBox.Text = string.Empty;
            // 一覧再表示
            DgvDisplayControl();
        }
        #endregion

        #region RelationCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RelationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool RelationCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 年度(5)
            if (string.IsNullOrEmpty(iraiNendoTextBox.Text))
            {
                errMsg.AppendLine("年度が入力されていません。");
            }

            // 支所(6)
            if (string.IsNullOrEmpty(Convert.ToString(shishoComboBox.SelectedValue)))
            {
                errMsg.AppendLine("支所が選択されていません。");
            }

            // 水質検査依頼番号（開始＆終了）
            if (!string.IsNullOrEmpty(suishitsuKensaIraiNoFromTextBox.Text)
                && !string.IsNullOrEmpty(suishitsuKensaIraiNoToTextBox.Text)
                && Decimal.Parse(suishitsuKensaIraiNoFromTextBox.Text) > Decimal.Parse(suishitsuKensaIraiNoToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。水質検査依頼番号の大小関係を確認してください。");
            }

            // Error?
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region MakeSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(ISearchBtnClickALInput input)
        {
            // 検査種別/外観/水質/計量証明
            input.SearchCond.TypeSearch = GetTypeSearch();
            // 依頼年度(5)
            input.SearchCond.IraiNendo = iraiNendoTextBox.Text;
            // 支所(6)
            input.SearchCond.ShishoCd = Convert.ToString(shishoComboBox.SelectedValue);
            // 水質検査依頼番号（開始）(7)
            input.SearchCond.IraiNoFrom = suishitsuKensaIraiNoFromTextBox.Text;
            // 水質検査依頼番号（終了）(8)
            input.SearchCond.IraiNoTo = suishitsuKensaIraiNoToTextBox.Text;
        }
        #endregion

        #region CkbChecked
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CkbChecked
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">1: checked, 0: uncheck</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CkbChecked(string value)
        {
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable dgvSource
                = (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable)kensaListDataGridView.DataSource;

            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in dgvSource)
            {
                row.OutputCol = value;
            }
        }
        #endregion

        #region GetTableFromSelectedDgvRows
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetTableFromSelectedDgvRows
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable GetTableFromSelectedDgvRows()
        {
            // No row in dgv
            if (kensaListDataGridView.Rows.Count == 0)
            {
                return new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
            }

            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable resTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable currentSource =
                (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable)kensaListDataGridView.DataSource;

            string tempIraiNendo = string.Empty;
            string tempShishoCd = string.Empty;
            string tempIraiNo = string.Empty;
            string tempKomokuCd = string.Empty;
            string filter = string.Empty;
            string sort = keiryoShomeiKensaRadioButton.Checked ? "IraiNendoCol, ShishoCdCol, SuishitsuKensaIraiNoCol, SuishitsuShikenKoumokuCd"
                : "IraiNendoCol, ShishoCdCol, SuishitsuKensaIraiNoCol";

            //dgv.DataSource = from t in _dgvSource
            //             join x in dgvSource on new { t.IraiNendoCol, t.ShishoCdCol, t.SuishitsuKensaIraiNoCol } equals new { x.IraiNendoCol, x.ShishoCdCol, x.SuishitsuKensaIraiNoCol }
            //             where x.OutputCol == "1"
            //             select t;
            //resTable = (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable)result;

            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in
                _dgvSource.Select(string.Empty, sort))
            {
                // Select distinct
                if (tempIraiNendo != row.IraiNendoCol
                    || tempShishoCd != row.ShishoCdCol
                    || tempIraiNo != row.SuishitsuKensaIraiNoCol
                    || tempKomokuCd != row.SuishitsuShikenKoumokuCd)
                {
                    ////resTable.ImportRow(row);
                    filter = string.Format("OutputCol = '1' and IraiNendoCol = '{0}' and ShishoCdCol = '{1}' and SuishitsuKensaIraiNoCol = '{2}'",
                        row.IraiNendoCol, row.ShishoCdCol, row.SuishitsuKensaIraiNoCol);
                    KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] joinRow
                        = (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])currentSource.Select(filter, string.Empty);

                    // Checkbox is checked?
                    if (joinRow.Length > 0)
                    {
                        resTable.ImportRow(row);
                    }
                }

                tempIraiNendo = row.IraiNendoCol;
                tempShishoCd = row.ShishoCdCol;
                tempIraiNo = row.SuishitsuKensaIraiNoCol;
                tempKomokuCd = row.SuishitsuShikenKoumokuCd;
            }

            return resTable;
        }
        #endregion

        #region GetTypeSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetTypeSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private TypeSearch GetTypeSearch()
        {
            TypeSearch ts;

            if (gaikanKensaRadioButton.Checked)
            {
                ts = TypeSearch.GaikanKensa;
            }
            else if (suishitsuKensaRadioButton.Checked)
            {
                ts = TypeSearch.SuishitsuKensa;
            }
            else
            {
                ts = TypeSearch.KeiryoKensa;
            }

            return ts;
        }
        #endregion

        #region GetIraiNoFolder
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetIraiNoFolder
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetIraiNoFolder()
        {
            string minIraiNo = string.Empty;
            string maxIraiNo = string.Empty;
            string iraiFolder = string.Empty;
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable dgvSource =
                (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable)kensaListDataGridView.DataSource;

            // <水質検査依頼番号の最小値>
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] row
                = (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])dgvSource.Select(string.Empty, "SuishitsuKensaIraiNoCol asc");
            minIraiNo = row[0].SuishitsuKensaIraiNoCol;

            // <水質検査依頼番号の最大値>
            row = (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])dgvSource.Select(string.Empty, "SuishitsuKensaIraiNoCol desc");
            maxIraiNo = row[0].SuishitsuKensaIraiNoCol;

            // <水質検査依頼番号の最小値>-<水質検査依頼番号の最大値>
            iraiFolder = string.Concat(minIraiNo, "-", maxIraiNo);

            return iraiFolder;
        }
        #endregion

        #endregion
    }
    #endregion
}
