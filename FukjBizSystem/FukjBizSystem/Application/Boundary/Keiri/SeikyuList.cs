using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Control;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyuListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SeikyuListForm : FukjBaseForm
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
        /// Current system date
        /// </summary>
        private DateTime _now;

        /// <summary>
        /// SeikyuListKensakuDataTable
        /// </summary>
        private SeikyuHdrTblDataSet.SeikyuListKensakuDataTable _resTable;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SeikyuListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SeikyuListForm()
        {
            InitializeComponent();
            SetStdControl();
        }
        #endregion

        #region イベント

        #region SeikyuListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SeikyuListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeikyuListForm_Load(object sender, EventArgs e)
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

        #region SeikyuListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SeikyuListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeikyuListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        shimeSyoriButton.Focus();
                        shimeSyoriButton.PerformClick();
                        break;
                    case Keys.F2:
                        shosaiButton.Focus();
                        shosaiButton.PerformClick();
                        break;
                    case Keys.F3:
                        ikkatsuSeikyuButton.Focus();
                        ikkatsuSeikyuButton.PerformClick();
                        break;
                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
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
        /// 2014/09/10　AnhNV　　    新規作成
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
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Reset to default!
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

        #region seikyuDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： seikyuDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void seikyuDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 請求日（開始）(13)
                seikyuDtFromDateTimePicker.Enabled =

                // 請求日（終了）(14)
                seikyuDtToDateTimePicker.Enabled = seikyuDtUseCheckBox.Checked;
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
        /// 2014/09/10　AnhNV　　    新規作成
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

        #region shimeSyoriButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shimeSyoriButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shimeSyoriButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SeikyuShimeForm frm = new SeikyuShimeForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ClearSearchCond();

                    shimeNenGetsuTextBox.Text = frm.shimeNenGetsu;
                    gyosyaCdFromTextBox.Text = frm.gyoshaCdFrom;
                    gyosyaCdToTextBox.Text = frm.gyoshaCdTo;

                    // 2015.01.07 toyoda Modify Start
                    //jimukyokuRadioButton.Checked = frm.shimeKbn;
                    if (frm.shimeKbn)
                    {
                        jimukyokuRadioButton.Checked = true;
                    }
                    else
                    {
                        chikuhoRadioButton.Checked = true;
                    }
                    // 2015.01.07 toyoda Modify End

                    allRadioButton.Checked = true;
                    seikyuDtUseCheckBox.Checked = false;

                    DoSearch();
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

        #region shosaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shosaiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (seikyuListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                SeikyuShosaiForm frm = new SeikyuShosaiForm(seikyuListDataGridView.CurrentRow.Cells[seikyuNoCol.Name].Value.ToString());
                //Program.mForm.ShowForm(frm);

                // 2015.01.07 toyoda Modify Start
                //Program.mForm.MoveNext(frm);
                Program.mForm.MoveNext(frm, ShosaiFormEnd);
                // 2015.01.07 toyoda Modify End
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

        #region ikkatsuSeikyuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ikkatsuSeikyuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10　AnhNV　　    新規作成
        /// 2014/12/18  kiyokuni     明細のプリンタ追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ikkatsuSeikyuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (seikyuListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Warning, "対象データがありません。");
                    return;
                }

                // Printer name for Seikyu
                // 2014.12.16 toyoda Mod Start プリンタ設定をDB保持に変更
                //string printer = Common.Common.GetPrinterName(Utility.Constants.PrinterConstant.PRINT_TYPE_SEIKYU);
                string printer = Common.Common.GetPrinterName(Utility.Constants.PrintKbn.PRINT_KBN_SEIKYUSHO);
                // 2014.12.16 toyoda Mod End

                // Printer is installed?
                if (!Common.Common.PrinterExist(printer))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "請求書発行先プリンタが設定されていません。");
                    return;
                }

                // Confirmation
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧に表示されている請求書、請求明細書を一括印刷します。\r\nよろしいですか？") == DialogResult.Yes)
                {
                    // Export EXCEL and update database
                    DoPrint(printer);

                    // Completed!
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "請求書一括印刷処理が完了しました。");

                    // Refresh the result set
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
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (seikyuListDataGridView.Rows.Count == 0) return;

                // Export to EXCEL
                Common.Common.FlushGridviewDataToExcel(seikyuListDataGridView, "請求状況一覧");
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
        /// 2014/09/10　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region GyoshaCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GyoshaCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　AnhNV　　    基本設計書_006_006_画面_SeikyuList_Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ZTextBox targetTextBox = sender as ZTextBox;
                Common.Common.PaddingZeroForTextBoxLeave(targetTextBox,
                    gyosyaCdFromTextBox,
                    gyosyaCdToTextBox);
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

        #region seikyuDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： seikyuDtFromDateTimePicker_ValueChanged
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
        private void seikyuDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                seikyuDtToDateTimePicker.Value = seikyuDtFromDateTimePicker.Value;
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
        /// 2014/09/10  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;
            this._now = Common.Common.GetCurrentTimestamp();

            // Get first day of current month
            DateTime firstDt = new DateTime(_now.Year, _now.Month, 1);

            // 締め年月(3)
            shimeNenGetsuTextBox.Text = _now.AddMonths(-1).ToString("yyyyMM");

            // 請求日（開始）(13)
            seikyuDtFromDateTimePicker.Value = firstDt;

            // 2015.01.05 toyoda Add Start
            // 請求日（終了）(14)
            seikyuDtToDateTimePicker.Value = _now;
            // 2015.01.05 toyoda Add End
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
        /// 2014/09/10  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            seikyuListDataGridView.DataSource = null;
            seikyuListDataGridView.Rows.Clear();
            seikyuListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            MakeSearchCond(searchInput);
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);
            _resTable = alOutput.SeikyuListKensakuDataTable;

            // No records was found
            if (alOutput.SeikyuListKensakuDataTable.Count == 0)
            {
                // 検索結果件数
                srhListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            srhListCountLabel.Text = string.Concat(alOutput.SeikyuListKensakuDataTable.Count, "件");

            // Binding source to dgv
            seikyuListDataGridView.DataSource = alOutput.SeikyuListKensakuDataTable;
        }
        #endregion

        #region DoPrint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoPrint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="printer"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoPrint(string printer)
        {
            // Current system date
            DateTime now = Common.Common.GetCurrentTimestamp();

            // Get list of SeikyuNo
            List<string> seikyuNoList = new List<string>();
            foreach (DataGridViewRow dgvr in seikyuListDataGridView.Rows)
            {
                seikyuNoList.Add(dgvr.Cells[seikyuNoCol.Name].Value.ToString());
            }

            // Executes print and update
            IIkkatsuSeikyuBtnClickALInput alInput = new IkkatsuSeikyuBtnClickALInput();
            alInput.PrinterName = printer;
            alInput.SeikyuNoList = seikyuNoList;
            alInput.Now = now;
            alInput.SeikyuListKensakuDataTable = _resTable;
            new IkkatsuSeikyuBtnClickApplicationLogic().Execute(alInput);
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
        /// 2014/09/10  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();

            // 締め年月(3)
            if (string.IsNullOrEmpty(shimeNenGetsuTextBox.Text))
            {
                errMsg.AppendLine("締め年月を入力して下さい。");
            }

            // 業者コード（開始＆終了）
            if (Convert.ToDecimal(string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) ? "0" : gyosyaCdFromTextBox.Text)
                > Convert.ToDecimal(string.IsNullOrEmpty(gyosyaCdToTextBox.Text) ? "9999" : gyosyaCdToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
            }

            // 請求日（開始＆終了）
            if (seikyuDtUseCheckBox.Checked
                && seikyuDtFromDateTimePicker.Value.Date > seikyuDtToDateTimePicker.Value.Date)
            {
                errMsg.AppendLine("範囲指定が正しくありません。請求日の大小関係を確認してください。");
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

        #region ClearSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 締め年月(3)
            shimeNenGetsuTextBox.Text = _now.AddMonths(-1).ToString("yyyyMM");

            // 業者コード（開始）(4)
            gyosyaCdFromTextBox.Text = string.Empty;

            // 業者コード（終了）(5)
            gyosyaCdToTextBox.Text = string.Empty;

            // 請求先名(6)
            seikyuNmTextBox.Text = string.Empty;

            // 締め区分/事務局(7)
            jimukyokuRadioButton.Checked = true;

            // 発行区分/全件(9)
            allRadioButton.Checked = true;

            // 請求日検索使用フラグ(12)
            seikyuDtUseCheckBox.Checked = false;

            // 請求日（開始）(13)
            seikyuDtFromDateTimePicker.Value = new DateTime(_now.Year, _now.Month, 1);

            // 請求日（終了）(14)
            seikyuDtToDateTimePicker.Value = _now;
        }
        #endregion

        #region MakeSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(ISearchBtnClickALInput input)
        {
            input.SearchCond = new SeikyuSearchCond();

            // 締め年月(3)
            if (!string.IsNullOrEmpty(shimeNenGetsuTextBox.Text.Trim()))
            {
                input.SearchCond.SeikyuYM = shimeNenGetsuTextBox.Text;
            }

            // 業者コード（開始）(4)
            if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text))
            {
                input.SearchCond.SeikyuGyoshaCdFrom = gyosyaCdFromTextBox.Text;
            }

            // 業者コード（終了）(5)
            if (!string.IsNullOrEmpty(gyosyaCdToTextBox.Text))
            {
                input.SearchCond.SeikyuGyoshaCdTo = gyosyaCdToTextBox.Text;
            }

            // 請求先名(6)
            if (!string.IsNullOrEmpty(seikyuNmTextBox.Text.Trim()))
            {
                input.SearchCond.SeikyusakiNm = seikyuNmTextBox.Text;
            }

            // 締め区分/事務局(7)
            input.SearchCond.ShimeKbn = jimukyokuRadioButton.Checked ? "1" : "2";

            // 発行区分/全件(9)
            input.SearchCond.SeikyushoHakkoFlg = hakkozumiRadioButton.Checked ? "1" : (miHakkoRadioButton.Checked ? "2" : string.Empty);

            // 請求日（開始）(13)
            input.SearchCond.SeikyuDtFrom = seikyuDtUseCheckBox.Checked ? seikyuDtFromDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 請求日（終了）(14)
            input.SearchCond.SeikyuDtTo = seikyuDtUseCheckBox.Checked ? seikyuDtToDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;
        }
        #endregion

        #region SetStdControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControl()
        {
            shimeNenGetsuTextBox.SetStdControlDomain(ZControlDomain.ZT_NEN_GETSU, 6);
            gyosyaCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4);
            gyosyaCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4);
            seikyuNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            seikyuListDataGridView.SetStdControlDomain(seikyuNoCol.Index, ZControlDomain.ZG_STD_CD, 8);
            seikyuListDataGridView.SetStdControlDomain(shimeKbnCol.Index, ZControlDomain.ZG_STD_NAME, 14);
            seikyuListDataGridView.SetStdControlDomain(gyosyaCdCol.Index, ZControlDomain.ZG_STD_CD, 4);
            seikyuListDataGridView.SetStdControlDomain(seikyuNmCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            seikyuListDataGridView.SetStdControlDomain(seikyuDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            seikyuListDataGridView.SetStdControlDomain(seikyuTotalCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            //seikyuListDataGridView.SetStdControlDomain(kbnCol.Index, ZControlDomain.ZG_STD_NAME, 4, DataGridViewContentAlignment.MiddleCenter); // This does not work
        }
        #endregion

        #region ShosaiFormEnd(Form childForm)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ListFormEnd
        /// <summary>
        /// 詳細画面終了時
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/07  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShosaiFormEnd(Form childForm)
        {
            // 再検索を行う
            kensakuButton.PerformClick();
        }
        #endregion

        #endregion
    }
    #endregion
}
