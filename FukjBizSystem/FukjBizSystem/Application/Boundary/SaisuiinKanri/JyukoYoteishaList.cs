using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.JyukoYoteishaList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JyukoYoteishaListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JyukoYoteishaListForm : FukjBaseForm
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
        /// Export data table
        /// </summary>
        private SaisuiinMstDataSet.JyukoYoteishaListDataTable _exportDT;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JyukoYoteishaListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JyukoYoteishaListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region JyukoYoteishaList_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JyukoYoteishaList_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JyukoYoteishaList_Load(object sender, EventArgs e)
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
        /// 2014/07/29  DatNT　  新規作成
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
                    this.jyukuoYoteisyaListPanel,
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
        /// 2014/07/29  DatNT　  新規作成
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
        /// 2014/07/29  DatNT　  新規作成
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

        #region Output1Button_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Output1Button_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Output1Button_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jyukuoYoteisyaListDataGridView.RowCount == 0) { return; }

                IOutput1BtnClickALInput alInput = new Output1BtnClickALInput();
                alInput.CurrentDate             = today;
                alInput.ExportDT                = _exportDT;
                new Output1BtnClickApplicationLogic().Execute(alInput);
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

        #region Output2Button_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Output2Button_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Output2Button_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jyukuoYoteisyaListDataGridView.RowCount == 0) { return; }

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "受講予定者一覧";
                Common.Common.FlushGridviewDataToExcel(this.jyukuoYoteisyaListDataGridView, outputFilename);
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TojiruButton_Click(object sender, EventArgs e)
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

        #region gyosyaNmFromSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaNmFromSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaNmFromSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    syozokuGyosyaCdFromTextBox.Text = frm._selectedRow.GyoshaCd;

                    gyoshaNmFromTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region gyosyaNmToSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaNmToSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaNmToSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    syozokuGyosyaCdToTextBox.Text = frm._selectedRow.GyoshaCd;

                    gyoshaNmToTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region JyukoYoteishaList_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JyukoYoteishaList_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JyukoYoteishaList_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        output1Button.PerformClick();
                        break;

                    case Keys.F2:
                        output2Button.PerformClick();
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

        #region zenkaiJukoDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaNmToSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zenkaiJukoDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (zenkaiJukoDtAddFlgCheckBox.Checked)
                {
                    // 前回受講日（開始）
                    zenkaiJukoDtFromDateTimePicker.Enabled = true;

                    // 前回受講日（終了）
                    zenkaiJukoDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    // 前回受講日（開始）
                    zenkaiJukoDtFromDateTimePicker.Enabled = false;

                    // 前回受講日（終了）
                    zenkaiJukoDtToDateTimePicker.Enabled = false;
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

        #region saisuiinYukokigenDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinYukokigenDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinYukokigenDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (saisuiinYukokigenDtAddFlgCheckBox.Checked)
                {
                    // 有効期限（開始）
                    saisuiinYukokigenDtFromDateTimePicker.Enabled = true;

                    // 有効期限（終了）
                    saisuiinYukokigenDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    // 有効期限（開始）
                    saisuiinYukokigenDtFromDateTimePicker.Enabled = false;

                    // 有効期限（終了）
                    saisuiinYukokigenDtToDateTimePicker.Enabled = false;
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20  DatNT　   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text))
                {
                    saisuiinCdFromTextBox.Text = saisuiinCdFromTextBox.Text.PadLeft(5, '0');
                    saisuiinCdToTextBox.Text = saisuiinCdFromTextBox.Text;
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

        #region saisuiinCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20  DatNT　   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text))
                {
                    saisuiinCdToTextBox.Text = saisuiinCdToTextBox.Text.PadLeft(5, '0');
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            saisuiinMstDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Display data
            saisuiinMstDataSet.Merge(alOutput.JyukoYoteishaListDT);

            if (alOutput.JyukoYoteishaListDT == null || alOutput.JyukoYoteishaListDT.Count == 0)
            {
                jyukuoYoteisyaListCountLabel.Text = "0件";
            }
            else
            {
                jyukuoYoteisyaListCountLabel.Text = alOutput.JyukoYoteishaListDT.Count.ToString() + "件";

                _exportDT = alOutput.JyukoYoteishaListDT;
            }

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.jyukuoYoteisyaListPanel.Top;
            this._defaultListPanelHeight = this.jyukuoYoteisyaListPanel.Height;
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 前回受講日追加フラグ
            alInput.ZenkaiJukoDtAddFlg = zenkaiJukoDtAddFlgCheckBox.Checked;

            // 前回受講日（開始）
            alInput.ZenkaiJukoDtFrom = zenkaiJukoDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 前回受講日（終了）
            alInput.ZenkaiJukoDtTo = zenkaiJukoDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 有効期限追加フラグ
            alInput.SaisuiinYukokigenDtAddFlg = saisuiinYukokigenDtAddFlgCheckBox.Checked;

            // 有効期限（開始）
            alInput.SaisuiinYukokigenDtFrom = saisuiinYukokigenDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 有効期限（終了）
            alInput.SaisuiinYukokigenDtTo = saisuiinYukokigenDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 採水員コード（開始）
            alInput.SaisuiinCdFrom = saisuiinCdFromTextBox.Text;

            // 採水員コード（終了）
            alInput.SaisuiinCdTo = saisuiinCdToTextBox.Text;

            // 所属業者コード（開始）
            alInput.SyozokuGyosyaCdFrom = syozokuGyosyaCdFromTextBox.Text;

            // 所属業者コード（終了）
            alInput.SyozokuGyosyaCdTo = syozokuGyosyaCdToTextBox.Text;
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            saisuiinMstDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            saisuiinMstDataSet.Merge(alOutput.JyukoYoteishaListDT);

            if (alOutput.JyukoYoteishaListDT == null || alOutput.JyukoYoteishaListDT.Count == 0)
            {
                jyukuoYoteisyaListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                jyukuoYoteisyaListCountLabel.Text = alOutput.JyukoYoteishaListDT.Count.ToString() + "件";

                _exportDT = alOutput.JyukoYoteishaListDT;
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 前回受講日
            if (zenkaiJukoDtAddFlgCheckBox.Checked)
            {
                if (zenkaiJukoDtFromDateTimePicker.Value > zenkaiJukoDtToDateTimePicker.Value)
                {
                    errMess.Append("範囲指定が正しくありません。前回受講日の大小関係を確認してください。\r\n");
                }
            }

            // 有効期限
            if (saisuiinYukokigenDtAddFlgCheckBox.Checked)
            {
                if (saisuiinYukokigenDtFromDateTimePicker.Value > saisuiinYukokigenDtToDateTimePicker.Value)
                {
                    errMess.Append("範囲指定が正しくありません。有効期限の大小関係を確認してください。\r\n");
                }
            }

            // 採水員コード（開始）
            bool saisuiinFlg = true;
            if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text) && saisuiinCdFromTextBox.Text.Length != 5)
            {
                errMess.Append("採水員コード（開始）は5桁で入力して下さい。\r\n");
                saisuiinFlg = false;
            }

            // 採水員コード（終了）
            if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text) && saisuiinCdToTextBox.Text.Length != 5)
            {
                errMess.Append("採水員コード（終了）は5桁で入力して下さい。\r\n");
                saisuiinFlg = false;
            }

            if (saisuiinFlg)
            {
                if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text) && !string.IsNullOrEmpty(saisuiinCdToTextBox.Text)
                    && Convert.ToInt32(saisuiinCdFromTextBox.Text) > Convert.ToInt32(saisuiinCdToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。採水員コードの大小関係を確認してください。\r\n");
                }
            }

            // 所属業者コード（開始＆終了）
            if (!string.IsNullOrEmpty(gyoshaNmFromTextBox.Text) && !string.IsNullOrEmpty(gyoshaNmToTextBox.Text)
                && Convert.ToInt32(syozokuGyosyaCdFromTextBox.Text) > Convert.ToInt32(syozokuGyosyaCdToTextBox.Text))
            {
                errMess.Append("範囲指定が正しくありません。所属業者の大小関係を確認してください。\r\n");
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 前回受講日追加フラグ
            zenkaiJukoDtAddFlgCheckBox.Checked = false;

            // 前回受講日（開始）
            zenkaiJukoDtFromDateTimePicker.Value = today;
            zenkaiJukoDtFromDateTimePicker.Enabled = false;

            // 前回受講日（終了）
            zenkaiJukoDtToDateTimePicker.Value = today;
            zenkaiJukoDtToDateTimePicker.Enabled = false;

            // 有効期限追加フラグ
            saisuiinYukokigenDtAddFlgCheckBox.Checked = false;

            // 有効期限（開始）
            saisuiinYukokigenDtFromDateTimePicker.Value = today;
            saisuiinYukokigenDtFromDateTimePicker.Enabled = false;

            // 有効期限（終了）
            saisuiinYukokigenDtToDateTimePicker.Value = today;
            saisuiinYukokigenDtToDateTimePicker.Enabled = false;

            // 採水員コード（開始）
            saisuiinCdFromTextBox.Clear();

            // 採水員コード（終了）
            saisuiinCdToTextBox.Clear();

            // 所属業者名（開始）
            gyoshaNmFromTextBox.Clear();

            // 所属業者名（終了）
            gyoshaNmToTextBox.Clear();

            // 所属業者コード（開始）
            syozokuGyosyaCdFromTextBox.Clear();

            // 所属業者コード（終了）
            syozokuGyosyaCdToTextBox.Clear();
        }
        #endregion

        #endregion

    }
    #endregion
}
