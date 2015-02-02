using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.SaisuiinShomeishoHakko;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiinMstListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiinShomeishoHakkoForm : FukjBaseForm
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
        /// Data table for export
        /// </summary>
        private SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable _exportDT
            = new SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaisuiinShomeishoHakkoForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiinShomeishoHakkoForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SaisuiinShomeishoHakkoForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinShomeishoHakkoForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinShomeishoHakkoForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2015.01.05 toyoda Add Start
                // 検索条件の初期化
                ClearSearchCond();
                // 2015.01.05 toyoda Add End

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
        /// 2014/07/25　AnhNV　　    新規作成
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
                    this.saisuiinListPanel,
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

        #region saisuiinYukokigenDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinYukokigenDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinYukokigenDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 有効期限（開始）(4)
                saisuiinYukokigenDtFromDateTimePicker.Enabled =
                // 有効期限（終了） (5)
                saisuiinYukokigenDtToDateTimePicker.Enabled = saisuiinYukokigenDtAddFlgCheckBox.Checked;
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

        #region zenkaiJukoDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zenkaiJukoDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zenkaiJukoDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 受講日（開始）(13)
                zenkaiJukoDtFromDateTimePicker.Enabled =
                // 受講日（終了）(14)
                zenkaiJukoDtToDateTimePicker.Enabled = zenkaiJukoDtAddFlgCheckBox.Checked;
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

        #region syozokuGyoshaFromSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syozokuGyoshaFromSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syozokuGyoshaFromSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open gyoshaMst search form
                GyoshaMstSearchForm form = new GyoshaMstSearchForm();
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 所属業者名（開始）(8)
                syozokuGyoshaNmFromTextBox.Text = form._selectedRow.GyoshaNm;

                // 所属業者コード（開始）(hidden)
                syozokuGyosyaCdFromTextBox.Text = form._selectedRow.GyoshaCd;
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

        #region syozokuGyoshaToSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syozokuGyoshaToSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syozokuGyoshaToSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open gyoshaMst search form
                GyoshaMstSearchForm form = new GyoshaMstSearchForm();
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 所属業者名（終了）(10)
                syozokuGyoshaNmToTextBox.Text = form._selectedRow.GyoshaNm;

                // 所属業者コード（終了）(hidden)
                syozokuGyosyaCdToTextBox.Text = form._selectedRow.GyoshaCd;
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
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Reset all input
                ClearSearchCond();
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
        /// 2014/07/25　AnhNV　　    新規作成
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
                if (!DataCheck()) return;

                // Do search
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

        #region shomeishoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shomeishoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shomeishoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No record was found
                if (saisuiinListDataGridView.Rows.Count == 0) return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "設定された内容で[指定採水員証明書]の印刷を実行します。よろしいですか？") == DialogResult.Yes)
                {
                    // Export with DB update
                    IShomeishoBtnClickALInput alInput = new ShomeishoBtnClickALInput();
                    alInput.HakkoDt = hakkoDtDateTimePicker.Value;
                    alInput.SaisuiinShomeishoHakkoKensakuDataTable = _exportDT;
                    new ShomeishoBtnClickApplicationLogic().Execute(alInput);
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

        #region shiteishoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shiteishoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shiteishoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No record was found
                if (saisuiinListDataGridView.Rows.Count == 0) return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "設定された内容で[指定採水員指定書]の印刷を実行します。よろしいですか？") == DialogResult.Yes)
                {
                    // Export with DB update
                    IShiteishoBtnClickALInput alInput = new ShiteishoBtnClickALInput();
                    alInput.HakkoDt = hakkoDtDateTimePicker.Value;
                    alInput.SaisuiinShomeishoHakkoKensakuDataTable = _exportDT;
                    new ShiteishoBtnClickApplicationLogic().Execute(alInput);
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

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //SaisuiinMenuForm frm = new SaisuiinMenuForm();
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

        #region SaisuiinShomeishoHakkoForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinShomeishoHakkoForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinShomeishoHakkoForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        shomeishoButton.PerformClick();
                        break;
                    case Keys.F2:
                        shiteishoButton.PerformClick();
                        break;
                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #region saisuiinCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　AnhNV　　    基本設計書_004_004_画面_SaisuiinShomeishoHakko_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not fire this event when textbox is empty
                if (string.IsNullOrEmpty(saisuiinCdFromTextBox.Text)) return;

                // Padding '0' to equal the max length digits
                saisuiinCdFromTextBox.Text = saisuiinCdFromTextBox.Text.PadLeft(saisuiinCdFromTextBox.MaxLength, '0');

                // ~To
                saisuiinCdToTextBox.Text = saisuiinCdFromTextBox.Text;
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

        #region saisuiinCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　AnhNV　　    基本設計書_004_004_画面_SaisuiinShomeishoHakko_V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not fire this event when textbox is empty
                if (string.IsNullOrEmpty(saisuiinCdToTextBox.Text)) return;

                // Padding '0' to equal the max length digits
                saisuiinCdToTextBox.Text = saisuiinCdToTextBox.Text.PadLeft(saisuiinCdToTextBox.MaxLength, '0');
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

        #region saisuiinYukokigenDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinYukokigenDtFromDateTimePicker_ValueChanged
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
        private void saisuiinYukokigenDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                saisuiinYukokigenDtToDateTimePicker.Value = saisuiinYukokigenDtFromDateTimePicker.Value;
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

        #region zenkaiJukoDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zenkaiJukoDtFromDateTimePicker_ValueChanged
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
        private void zenkaiJukoDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                zenkaiJukoDtToDateTimePicker.Value = zenkaiJukoDtFromDateTimePicker.Value;
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
        /// 2014/07/25  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.saisuiinListPanel.Top;
            this._defaultListPanelHeight = this.saisuiinListPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SearchCond = new SaisuiinMstSearchCond();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検索結果件数
            saisuiinListCountLabel.Text = string.Concat(alOutput.SaisuiinShomeishoHakkoKensakuDataTable.Count, "件");
            // Binding source to dgv
            saisuiinListDataGridView.DataSource = alOutput.SaisuiinShomeishoHakkoKensakuDataTable;
            // For export
            _exportDT = alOutput.SaisuiinShomeishoHakkoKensakuDataTable;
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
        /// 2014/07/25  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            saisuiinListDataGridView.DataSource = null;
            saisuiinListDataGridView.Rows.Clear();
            saisuiinListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            searchInput.SearchCond = SetSearchCond();
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.SaisuiinShomeishoHakkoKensakuDataTable.Count == 0)
            {
                // 検索結果件数
                saisuiinListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            saisuiinListCountLabel.Text = string.Concat(alOutput.SaisuiinShomeishoHakkoKensakuDataTable.Count, "件");

            // Binding source to dgv
            saisuiinListDataGridView.DataSource = alOutput.SaisuiinShomeishoHakkoKensakuDataTable;

            // For export
            _exportDT = alOutput.SaisuiinShomeishoHakkoKensakuDataTable;
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();
            // Input check is OK
            bool cdLenCheckOK = true;

            // 有効期限（開始）(4) > 有効期限（終了）(5)
            if (saisuiinYukokigenDtAddFlgCheckBox.Checked
                && saisuiinYukokigenDtFromDateTimePicker.Value.Date > saisuiinYukokigenDtToDateTimePicker.Value.Date)
            {
                errMsg.Append("範囲指定が正しくありません。有効期限の大小関係を確認してください。\r\n");
            }

            // 採水員コード（開始）(6) not equals 5 digits
            if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text.Trim()) && saisuiinCdFromTextBox.Text.Length != 5)
            {
                errMsg.Append("採水員コード（開始）は5桁で入力して下さい。\r\n");
                cdLenCheckOK = false;
            }

            // 採水員コード（終了）(7) not equals 5 digits
            if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text.Trim()) && saisuiinCdToTextBox.Text.Length != 5)
            {
                errMsg.Append("採水員コード（終了）は5桁で入力して下さい。\r\n");
                cdLenCheckOK = false;
            }

            // 採水員コード（開始）(6) > 採水員コード（終了）(7)
            if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(saisuiinCdToTextBox.Text.Trim())
                && Convert.ToDecimal(saisuiinCdFromTextBox.Text) > Convert.ToDecimal(saisuiinCdToTextBox.Text)
                && cdLenCheckOK)
            {
                errMsg.Append("範囲指定が正しくありません。採水員コードの大小関係を確認してください。\r\n");
            }

            // 所属業者名（開始）(8) > 所属業者名（終了）(10)
            if (!string.IsNullOrEmpty(syozokuGyosyaCdFromTextBox.Text)
                && !string.IsNullOrEmpty(syozokuGyosyaCdToTextBox.Text)
                && Convert.ToInt32(syozokuGyosyaCdFromTextBox.Text) > Convert.ToInt32(syozokuGyosyaCdToTextBox.Text))
            {
                errMsg.Append("範囲指定が正しくありません。所属業者の大小関係を確認してください。\r\n");
            }

            // 受講日（開始）(13) > 受講日（終了）(14)
            if (zenkaiJukoDtAddFlgCheckBox.Checked
                && zenkaiJukoDtFromDateTimePicker.Value.Date > zenkaiJukoDtToDateTimePicker.Value.Date)
            {
                errMsg.Append("範囲指定が正しくありません。受講日の大小関係を確認してください。\r\n");
            }

            // Throw error messages
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstSearchCond SetSearchCond()
        {
            SaisuiinMstSearchCond searchCond = new SaisuiinMstSearchCond();

            // 採水員有効期限FROM ~ TO
            if (saisuiinYukokigenDtAddFlgCheckBox.Checked)
            {
                searchCond.SaisuiinYukokigenDtFrom = saisuiinYukokigenDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                searchCond.SaisuiinYukokigenDtTo = saisuiinYukokigenDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }

            // 採水員コードFROM
            if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text))
            {
                searchCond.SaisuiinCdFrom = saisuiinCdFromTextBox.Text;
            }

            // 採水員コードTO
            if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text))
            {
                searchCond.SaisuiinCdTo = saisuiinCdToTextBox.Text;
            }

            // 所属業者コードFROM
            if (!string.IsNullOrEmpty(syozokuGyosyaCdFromTextBox.Text))
            {
                searchCond.SyozokuGyosyaCdFrom = syozokuGyosyaCdFromTextBox.Text;
            }

            // 所属業者コードTO
            if (!string.IsNullOrEmpty(syozokuGyosyaCdToTextBox.Text))
            {
                searchCond.SyozokuGyosyaCdTo = syozokuGyosyaCdToTextBox.Text;
            }

            // 受講日FROM ~ TO
            if (zenkaiJukoDtAddFlgCheckBox.Checked)
            {
                searchCond.JukoDtFrom = zenkaiJukoDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                searchCond.JukoDtTo = zenkaiJukoDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }

            return searchCond;
        }
        #endregion

        #region ClearSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // Current datetime in DB
            DateTime now = Common.Common.GetCurrentTimestamp();

            // 有効期限追加フラグ(3)
            saisuiinYukokigenDtAddFlgCheckBox.Checked = false;

            // 有効期限（開始）(4)
            saisuiinYukokigenDtFromDateTimePicker.Value =

            // 有効期限（終了）(5)
            saisuiinYukokigenDtToDateTimePicker.Value = 

            // 受講日（開始）(13)
            zenkaiJukoDtFromDateTimePicker.Value =

            // 受講日（終了）(14)
            zenkaiJukoDtToDateTimePicker.Value = now;

            // 採水員コード（開始)(6)
            saisuiinCdFromTextBox.Clear();

            // 採水員コード（終了)(7)
            saisuiinCdToTextBox.Clear();

            // 所属業者名（開始）(8)
            syozokuGyoshaNmFromTextBox.Clear();

            // 所属業者名（終了）(10)
            syozokuGyoshaNmToTextBox.Clear();

            // 所属業者コード（開始）(hidden)
            syozokuGyosyaCdFromTextBox.Clear();

            // 所属業者コード（終了）(hidden)
            syozokuGyosyaCdToTextBox.Clear();

            // 受講日追加フラグ(12)
            zenkaiJukoDtAddFlgCheckBox.Checked = false;
        }
        #endregion

        #endregion
    }
    #endregion
}
