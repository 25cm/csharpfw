using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.ZandakaList;
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
    //  クラス名 ： ZandakaListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ZandakaListForm : FukjBaseForm
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
        /// Result search table
        /// </summary>
        private SeikyuHdrTblDataSet.ZandakaListKensakuDataTable _searchTable;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ZandakaListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ZandakaListForm()
        {
            InitializeComponent();
            SetStdControlDomain();
        }
        #endregion

        #region イベント

        #region ZandakaListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ZandakaListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ZandakaListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default data
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

        #region ZandakaListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ZandakaListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ZandakaListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F2:
                        nyukinInputButton.Focus();
                        nyukinInputButton.PerformClick();
                        break;
                    case Keys.F3:
                        saiseikyuButton.Focus();
                        saiseikyuButton.PerformClick();
                        break;
                    case Keys.F4:
                        ikkatsuSeikyuButton.Focus();
                        ikkatsuSeikyuButton.PerformClick();
                        break;
                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;
                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Reset all search conditions
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
        /// 2014/09/17　AnhNV　　    新規作成
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

                // Do search!
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
        /// 2014/09/17　AnhNV　　    新規作成
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
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void seikyuDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 請求日（開始）(15)
                seikyuDtFromDateTimePicker.Enabled =

                // 請求日（終了）(16)
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

        #region nyukinInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nyukinInputButton_Click(object sender, EventArgs e)
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

                // Selected seikyuNo in dgv
                //string seikyuNo = seikyuListDataGridView.CurrentRow.Cells["seikyuNoCol"].Value == null ?
                //    string.Empty : seikyuListDataGridView.CurrentRow.Cells["seikyuNoCol"].Value.ToString();
                string oyaSeikyuNo = seikyuListDataGridView.CurrentRow.Cells[oyaSeikyuNoCol.Name].Value == null ?
                    string.Empty : seikyuListDataGridView.CurrentRow.Cells[oyaSeikyuNoCol.Name].Value.ToString();
                
                // Move to 006-011(NyukinShosai) screen
                NyukinShosaiForm frm = new NyukinShosaiForm(string.Empty, oyaSeikyuNo);
                Program.mForm.MoveNext(frm);
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

        #region saiseikyuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saiseikyuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saiseikyuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (seikyuListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データがありません。");
                    return;
                }

                // 再請求番号(33)
                if (string.IsNullOrEmpty(saiseikyuNoTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "再請求番号を入力して下さい。");
                    saiseikyuNoTextBox.Focus();
                    return;
                }

                // Confirm to print
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "画面の条件で再請求願いを印刷します。\r\nよろしいですか？") == DialogResult.Yes)
                {
                    ISaiseikyuBtnClickALInput alInput = new SaiseikyuBtnClickALInput();
                    alInput.SeikyuDtTo = seikyuDtToDateTimePicker.Value;
                    alInput.SaiSeikyuNo = saiseikyuNoTextBox.Text;
                    //20150121 HuyTX Mod Start
                    //alInput.SystemDt = Common.Common.GetCurrentTimestamp();
                    //alInput.ZandakaListKensakuDataTable = _searchTable;
                    alInput.SearchCond = MakeSearchCond();
                    alInput.SearchCond.InsertDt = Common.Common.GetCurrentTimestamp();
                    alInput.SearchCond.InsertUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    alInput.SearchCond.InsertTarm = Dns.GetHostName();
                    //End
                    new SaiseikyuBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/09/17　AnhNV　　    新規作成
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
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データがありません。");
                    return;
                }

                // Confirm to print
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "画面の条件で再請求明細を印刷します。\r\nよろしいですか？") == DialogResult.Yes)
                {
                    // Get list of SeikyuNo
                    List<string> seikyuNoList = new List<string>();
                    foreach (DataGridViewRow dgvr in seikyuListDataGridView.Rows)
                    {
                        //seikyuNoList.Add(dgvr.Cells["seikyuNoCol"].Value.ToString());
                        if (!seikyuNoList.Contains(dgvr.Cells[oyaSeikyuNoCol.Name].Value.ToString()))
                        {
                            seikyuNoList.Add(dgvr.Cells[oyaSeikyuNoCol.Name].Value.ToString());
                        }
                    }

                    // Execute print
                    IkkatsuSeikyuBtnClickALInput alInput = new IkkatsuSeikyuBtnClickALInput();
                    alInput.SeikyuNoList = seikyuNoList;
                    new IkkatsuSeikyuBtnClickApplicationLogic().Execute(alInput);
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
        /// 2014/09/17　AnhNV　　    新規作成
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

                Common.Common.FlushGridviewDataToExcel(seikyuListDataGridView, "請求残高一覧");
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
        /// 2014/09/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Back to Keiri menu
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
        /// 2014/11/05　AnhNV　　    基本設計書_006_009_画面_ZandakaList_Ver1.01
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
                Common.Common.PaddingZeroForTextBoxLeave(targetTextBox, gyosyaCdFromTextBox, gyosyaCdToTextBox);
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
        /// 2014/09/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Current system date
            _now = Common.Common.GetCurrentTimestamp();

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            // 請求日（開始）(15)
            seikyuDtFromDateTimePicker.Value = new DateTime(_now.AddMonths(-1).Year, _now.AddMonths(-1).Month, 1);

            // 請求日（終了）(16)
            seikyuDtToDateTimePicker.Value = new DateTime(_now.AddMonths(-1).Year, _now.AddMonths(-1).Month, DateTime.DaysInMonth(_now.AddMonths(-1).Year, _now.AddMonths(-1).Month));
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
        /// 2014/09/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            seikyuListDataGridView.DataSource = null;
            seikyuListDataGridView.Rows.Clear();
            seikyuListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            //20150121 HuyTX Mod Start
            //MakeSearchCond(searchInput);
            searchInput.SearchCond = MakeSearchCond();
            //End
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);
            _searchTable = alOutput.ZandakaListKensakuDataTable;

            // No records was found
            if (alOutput.ZandakaListKensakuDataTable.Count == 0)
            {
                // 検索結果件数
                srhListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            srhListCountLabel.Text = string.Concat(alOutput.ZandakaListKensakuDataTable.Count, "件");

            // Binding source to dgv
            seikyuListDataGridView.DataSource = alOutput.ZandakaListKensakuDataTable;
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
        /// 2014/09/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 業者コード（開始）(3)
            gyosyaCdFromTextBox.Text = string.Empty;

            // 業者コード（終了）(4)
            gyosyaCdToTextBox.Text = string.Empty;

            // 請求先名(5)
            seikyuNmTextBox.Text = string.Empty;

            // 請求科目/7条検査(6)
            kensa7JoCheckBox.Checked = true;

            // 請求科目/11条検査(外観)(7)
            kensa11GaikanCheckBox.Checked = true;

            // 請求科目/11条検査(水質)(8)
            kensa11SuishitsuCheckBox.Checked = true;

            // 請求科目/計量証明(9)
            keiryoShomeiCheckBox.Checked = true;

            // 請求科目/保証登録(10)
            hoshoTorokuCheckBox.Checked = true;

            // 請求科目/用紙販売(11)
            yoshiHanbaiCheckBox.Checked = true;

            // 請求科目/年会費(12)
            nenkaihiCheckBox.Checked = true;

            // 商品名(13)
            syohinNmTextBox.Text = string.Empty;

            // 請求日検索使用フラグ(14)
            seikyuDtUseCheckBox.Checked = false;

            // 請求日（開始）(15)
            seikyuDtFromDateTimePicker.Value = new DateTime(_now.AddMonths(-1).Year, _now.AddMonths(-1).Month, 1);

            // 請求日（終了）(16)
            seikyuDtToDateTimePicker.Value = new DateTime(_now.AddMonths(-1).Year, _now.AddMonths(-1).Month, DateTime.DaysInMonth(_now.AddMonths(-1).Year, _now.AddMonths(-1).Month));
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
        /// 2014/09/17  AnhNV　　    新規作成
        /// 2015/01/21  HuyTX　　    changed return type
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void MakeSearchCond(ISearchBtnClickALInput searchInput)
        private SeikyuSearchCond MakeSearchCond()
        {
            SeikyuSearchCond searchCond = new SeikyuSearchCond();

            // 業者コード（開始）(3)
            searchCond.SeikyuGyoshaCdFrom = gyosyaCdFromTextBox.Text;

            // 業者コード（終了）(4)
            searchCond.SeikyuGyoshaCdTo = gyosyaCdToTextBox.Text;

            // 請求先名(5)
            searchCond.SeikyusakiNm = seikyuNmTextBox.Text.Trim();

            // 請求科目/7条検査(6)
            searchCond.KbnDict.Add("ckb6", kensa7JoCheckBox.Checked ? "ON" : "OFF");

            // 請求科目/11条検査(外観)(7)
            searchCond.KbnDict.Add("ckb7", kensa11GaikanCheckBox.Checked ? "ON" : "OFF");

            // 請求科目/11条検査(水質)(8)
            searchCond.KbnDict.Add("ckb8", kensa11SuishitsuCheckBox.Checked ? "ON" : "OFF");

            // 請求科目/計量証明(9)
            searchCond.KbnDict.Add("ckb9", keiryoShomeiCheckBox.Checked ? "ON" : "OFF");

            // 請求科目/保証登録(10)
            searchCond.KbnDict.Add("ckb10", hoshoTorokuCheckBox.Checked ? "ON" : "OFF");

            // 請求科目/用紙販売(11)
            searchCond.KbnDict.Add("ckb11", yoshiHanbaiCheckBox.Checked ? "ON" : "OFF");

            // 請求科目/年会費(12)
            searchCond.KbnDict.Add("ckb12", nenkaihiCheckBox.Checked ? "ON" : "OFF");

            // 商品名(13)
            searchCond.SeikyuSyohinNm = syohinNmTextBox.Text.Trim();

            // 請求日（開始）(15)
            searchCond.SeikyuDtFrom = seikyuDtUseCheckBox.Checked ? seikyuDtFromDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 請求日（終了）(16)
            searchCond.SeikyuDtTo = seikyuDtUseCheckBox.Checked ? seikyuDtToDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            return searchCond;
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
        /// 2014/09/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();
            //bool gyoshaLenOK = true;

            //// 再請求番号(33)
            //if (string.IsNullOrEmpty(saiseikyuNoTextBox.Text))
            //{
            //    errMsg.AppendLine("再請求番号を入力して下さい。");
            //}

            //// 業者コード（開始）(3)
            //if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) && gyosyaCdFromTextBox.Text.Length != 4)
            //{
            //    errMsg.AppendLine("業者コード（開始）は2桁で入力して下さい。");
            //    gyoshaLenOK = false;
            //}

            //// 業者コード（終了）(4)
            //if (!string.IsNullOrEmpty(gyosyaCdToTextBox.Text) && gyosyaCdToTextBox.Text.Length != 4)
            //{
            //    errMsg.AppendLine("業者コード（終了）は2桁で入力して下さい。");
            //    gyoshaLenOK = false;
            //}

            // 業者コード（開始）(3) greater than 業者コード（終了）(4)
            if (/*gyoshaLenOK &&*/
                Convert.ToInt32(string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) ? "0" : gyosyaCdFromTextBox.Text) >
                Convert.ToInt32(string.IsNullOrEmpty(gyosyaCdToTextBox.Text) ? "9999" : gyosyaCdToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
            }

            // 請求日（開始）(15) greater than  請求日（終了）(16)
            if (seikyuDtUseCheckBox.Checked
                && seikyuDtFromDateTimePicker.Value.Date > seikyuDtToDateTimePicker.Value.Date)
            {
                errMsg.AppendLine("範囲指定が正しくありません。請求日の大小関係を確認してください。");
            }

            // All 請求科目 are OFF
            if (!kensa7JoCheckBox.Checked && !kensa11GaikanCheckBox.Checked
                && !kensa11SuishitsuCheckBox.Checked && !keiryoShomeiCheckBox.Checked
                && !hoshoTorokuCheckBox.Checked && !yoshiHanbaiCheckBox.Checked && !nenkaihiCheckBox.Checked)
            {
                errMsg.AppendLine("請求科目を選択してください");
            }
            
            // An error occurred
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
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
        /// 2014/11/05  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // TextBoxes
            gyosyaCdFromTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            gyosyaCdToTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            saiseikyuNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);
            seikyuNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            syohinNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);

            // DataGridview
            seikyuListDataGridView.SetStdControlDomain(oyaSeikyuNoCol.Index, ZControlDomain.ZG_STD_CD, 8);
            seikyuListDataGridView.SetStdControlDomain(seikyuNoCol.Index, ZControlDomain.ZG_STD_CD, 10);
            seikyuListDataGridView.SetStdControlDomain(seikyuRenbanCol.Index, ZControlDomain.ZG_STD_NUM, 2);
            seikyuListDataGridView.SetStdControlDomain(saiseikyuCntCol.Index, ZControlDomain.ZG_STD_NUM, 2);
            seikyuListDataGridView.SetStdControlDomain(gyosyaCdCol.Index, ZControlDomain.ZG_STD_CD, 4);
            seikyuListDataGridView.SetStdControlDomain(seikyuNmCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            seikyuListDataGridView.SetStdControlDomain(seikyuDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            seikyuListDataGridView.SetStdControlDomain(seikyuKamokuCol.Index, ZControlDomain.ZG_STD_NAME, 40);
            seikyuListDataGridView.SetStdControlDomain(syohinNmCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            seikyuListDataGridView.SetStdControlDomain(seikyuGakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            seikyuListDataGridView.SetStdControlDomain(nyukinGakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
        }
        #endregion

        #endregion
    }
    #endregion
}
