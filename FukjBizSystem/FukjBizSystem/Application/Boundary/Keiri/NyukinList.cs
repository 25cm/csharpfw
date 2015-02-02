using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.NyukinList;
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
    //  クラス名 ： NyukinListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class NyukinListForm : FukjBaseForm
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

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： NyukinListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public NyukinListForm()
        {
            InitializeComponent();
            SetStdControlDomain();
        }
        #endregion

        #region イベント

        #region NyukinListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NyukinListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NyukinListForm_Load(object sender, EventArgs e)
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

        #region NyukinListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NyukinListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NyukinListForm_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F2:
                        shosaiButton.Focus();
                        shosaiButton.PerformClick();
                        break;
                    case Keys.F3:
                        henkinButton.Focus();
                        henkinButton.PerformClick();
                        break;
                    case Keys.F4:
                        ikkatsuSeikyuButton.Focus();
                        ikkatsuSeikyuButton.PerformClick();
                        break;
                    // 2015/01/16 AnhNV ADD v1.04 Start
                    case Keys.F5:
                        ryosyushoButton.Focus();
                        ryosyushoButton.PerformClick();
                        break;
                    // 2015/01/16 AnhNV ADD v1.04 End
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

        #region nyukinDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nyukinDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 入金日（開始）(16)
                nyukinDtFromDateTimePicker.Enabled =

                // 入金日（終了）(17)
                nyukinDtToDateTimePicker.Enabled = nyukinDtUseCheckBox.Checked;
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
        /// 2014/09/15　AnhNV　　    新規作成
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
        /// 2014/09/15　AnhNV　　    新規作成
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
                if (!RelationCheck()) return;

                // Search
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
        /// 2014/09/15　AnhNV　　    新規作成
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open 006-011
                NyukinShosaiForm frm = new NyukinShosaiForm();
                //Program.mForm.ShowForm(frm);
                Program.mForm.MoveNext(frm, FormEnd);
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
        /// 2014/09/15　AnhNV　　    新規作成
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
                if (nyukinListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 入金No from dgv
                string nyukinNo = nyukinListDataGridView.CurrentRow.Cells[nyukinNoCol.Name].Value.ToString();

                // Open 006-011 (Edit mode)
                NyukinShosaiForm frm = new NyukinShosaiForm(nyukinNo, string.Empty);
                Program.mForm.MoveNext(frm, FormEnd);
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

        #region henkinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void henkinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (nyukinListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 入金No from dgv
                string nyukinNo = nyukinListDataGridView.CurrentRow.Cells[nyukinNoCol.Name].Value.ToString();

                // Open 006-021
                HenkinShosaiForm frm = new HenkinShosaiForm(nyukinNo);
                Program.mForm.MoveNext(frm, FormEnd);
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
        /// 2014/09/15　AnhNV　　    新規作成
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
                if (nyukinListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Warning, "対象データがありません。");
                    return;
                }

                // Confirmation!
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧に表示されている内容で内訳書を印刷します。\r\nよろしいですか？") == DialogResult.Yes)
                {
                    // Do print
                    DoPrint();
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
        /// 2014/09/15　AnhNV　　    新規作成
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
                if (nyukinListDataGridView.Rows.Count == 0) return;

                // Export dgv to EXCEL
                Common.Common.FlushGridviewDataToExcel(nyukinListDataGridView, "入金状況一覧");
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
        /// 2014/09/15　AnhNV　　    新規作成
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
                //KeiriMenuForm frm = new KeiriMenuForm();
                //Program.mForm.ShowForm(frm);
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
        /// 2014/10/27　AnhNV　　    基本設計書_006_010_画面_NyukinList_Ver1.03
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
        /// 2015/01/16　AnhNV　　    基本設計書_006_010_画面_NyukinList_Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyushoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row is selected?
                if (nyukinListDataGridView.SelectedRows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // Selected row
                DataGridViewRow selectedRow = nyukinListDataGridView.CurrentRow;

                RyoshushoPrintForm.RyoshushoPrintData ryoshuData = new RyoshushoPrintForm.RyoshushoPrintData();
                ryoshuData.HakkoNo = Convert.ToString(selectedRow.Cells[nyukinNoCol.Name].Value);
                ryoshuData.GyoshaCd = Convert.ToString(selectedRow.Cells[gyosyaCdCol.Name].Value);
                if (Convert.ToString(selectedRow.Cells[NyukinSyubetsuCol.Name].Value) == "1")
                {
                    ryoshuData.RyoshuShoKbn = RyoshushoPrintForm.RyoshuShoKbn.SeikyuNyukin;
                }
                else
                {
                    ryoshuData.RyoshuShoKbn = RyoshushoPrintForm.RyoshuShoKbn.GenkinNyukin;
                }

                // Source for 006-022 dgv
                YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable printTable = new YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable();
                YoshiHanbaiDtlTblDataSet.RyushushoPrintRow newRow = printTable.NewRyushushoPrintRow();
                newRow.Hinban = Convert.ToString(selectedRow.Cells[nyukinNoCol.Name].Value);
                newRow.HinNm = Convert.ToString(selectedRow.Cells[syubetsuCol.Name].Value);
                newRow.SuiRyo = 1;
                newRow.ShouhizeiUmu = "0";
                decimal nyukinTotal;
                decimal.TryParse(Convert.ToString(selectedRow.Cells[nyukinTotalCol.Name].Value), out nyukinTotal);
                newRow.Tanka = nyukinTotal;
                newRow.Kingaku = nyukinTotal;
                newRow.Bikou = string.Empty;

                // Add row to table
                printTable.AddRyushushoPrintRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();
                ryoshuData.RyushushoPrintDataTable = printTable;

                // Call to 006-022
                RyoshushoPrintForm frm = new RyoshushoPrintForm(ryoshuData);
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

        #region nyukinDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinDtFromDateTimePicker_ValueChanged
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
        private void nyukinDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                nyukinDtToDateTimePicker.Value = nyukinDtFromDateTimePicker.Value;
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
        /// 2014/09/15  AnhNV　　    新規作成
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

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

            // 支所(3)
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            // 入金日（開始）(16)
            nyukinDtFromDateTimePicker.Value = new DateTime(_now.Year, _now.Month, 1);

            // 2015.01.05 toyoda Add Start
            // 入金日（終了）(17)
            nyukinDtToDateTimePicker.Value = _now;
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
        /// 2014/09/15  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            nyukinListDataGridView.DataSource = null;
            nyukinListDataGridView.Rows.Clear();
            nyukinListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            SetSearchCond(searchInput);
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.NyukinListKensakuDataTable.Count == 0)
            {
                // 検索結果件数
                srhListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            srhListCountLabel.Text = string.Concat(alOutput.NyukinListKensakuDataTable.Count, "件");

            // Binding source to dgv
            nyukinListDataGridView.DataSource = alOutput.NyukinListKensakuDataTable;
        }
        #endregion

        #region DoPrint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoPrint
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoPrint()
        {
            // Current system date
            DateTime now = Common.Common.GetCurrentTimestamp();

            // Get list of SeikyuNo
            List<string> nyukinNoList = new List<string>();
            foreach (DataGridViewRow dgvr in nyukinListDataGridView.Rows)
            {
                nyukinNoList.Add(dgvr.Cells[nyukinNoCol.Name].Value.ToString());
            }

            // Executes print and update
            IIkkatsuSeikyuBtnClickALInput alInput = new IkkatsuSeikyuBtnClickALInput();
            // 2014/12/16 AnhNV ADD Start
            alInput.IsNyukinDtUse = nyukinDtUseCheckBox.Checked;
            // 2014/12/16 AnhNV ADD End
            alInput.NyukinNoList = nyukinNoList;
            alInput.SystemDt = now;
            alInput.NyukinDtFrom = nyukinDtFromDateTimePicker.Value;
            alInput.NyukinDtTo = nyukinDtToDateTimePicker.Value;
            new IkkatsuSeikyuBtnClickApplicationLogic().Execute(alInput);
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
        /// 2014/09/15  AnhNV　　    新規作成
        /// 2014/11/04  AnhNV　　    基本設計書_006_010_画面_NyukinList_Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 支所(3)
            shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            // 業者コード（開始）(4)
            gyosyaCdFromTextBox.Text = string.Empty;

            // 業者コード（終了）(5)
            gyosyaCdToTextBox.Text = string.Empty;

            // 名称(6)
            nyukinNmTextBox.Text = string.Empty;

            // 入金種別/請求(7)
            seikyuCheckBox.Checked = true;

            // 入金種別/前受金(8)
            maeukekinCheckBox.Checked = true;

            // 入金種別/計量証明(請求外)(9)
            keiryoSyomeiCheckBox.Checked = true;

            // 入金種別/用紙販売(請求外)(10)
            yoshiHanbaiCheckBox.Checked = true;

            // 入金種別/機能保証(請求外)
            kinohoshoCheckBox.Checked = true;

            // 入金種別/年会費(請求外)(11)
            nenkaihiCheckBox.Checked = true;

            // 入金種別/検査手数料(請求外)
            tesuryoCheckBox.Checked = true;

            // 入金方法/郵便(12)
            yubinCheckBox.Checked = true;

            // 入金方法/銀行(13)
            bankCheckBox.Checked = true;

            // 入金方法/現金(14)
            genkinCheckBox.Checked = true;

            // 入金日検索使用フラグ(15)
            nyukinDtUseCheckBox.Checked = false;

            // 入金日（開始）(16)
            nyukinDtFromDateTimePicker.Value = new DateTime(_now.Year, _now.Month, 1);

            // 入金日（終了）(17)
            nyukinDtToDateTimePicker.Value = _now;

            // 追加条件/なし(18)
            nashiRadioButton.Checked = true;
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
        /// 2014/09/15  AnhNV　　    新規作成
        /// 2014/10/27  AnhNV　　    基本設計書_006_010_画面_NyukinList_Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSearchCond(ISearchBtnClickALInput input)
        {
            input.SearchCond = new NyukinKensakuSearchCond();
            input.SearchCond.NyukinSyubetsu = new List<string>();
            input.SearchCond.NyukinHoho = new List<string>();

            // 支所(3)
            input.SearchCond.NyukinShisyoCd = shisyoComboBox.SelectedIndex > 0 ? shisyoComboBox.SelectedValue.ToString() : string.Empty;

            // 業者コード（開始）(4)
            input.SearchCond.NyukinGyosyaCdFrom = gyosyaCdFromTextBox.Text;

            // 業者コード（終了）(5)
            input.SearchCond.NyukinGyosyaCdTo = gyosyaCdToTextBox.Text;

            // 名称(6)
            input.SearchCond.NyukinsyaNm = nyukinNmTextBox.Text.Trim();

            // 入金種別/請求(7)
            if (seikyuCheckBox.Checked) input.SearchCond.NyukinSyubetsu.Add("1");

            // 入金種別/前受金(8)
            if (maeukekinCheckBox.Checked) input.SearchCond.NyukinSyubetsu.Add("2");

            // 入金種別/計量証明(請求外)(9)
            if (keiryoSyomeiCheckBox.Checked) input.SearchCond.NyukinSyubetsu.Add("5");

            // 入金種別/用紙販売(請求外)(10)
            if (yoshiHanbaiCheckBox.Checked) input.SearchCond.NyukinSyubetsu.Add("3");

            // 入金種別/年会費(請求外)(11)
            if (nenkaihiCheckBox.Checked) input.SearchCond.NyukinSyubetsu.Add("4");

            // 入金種別/機能保証(請求外)
            if (kinohoshoCheckBox.Checked) input.SearchCond.NyukinSyubetsu.Add("7");

            // 入金種別/検査手数料(請求外)
            if (tesuryoCheckBox.Checked) input.SearchCond.NyukinSyubetsu.Add("6");

            // 入金方法/郵便(12)
            if (yubinCheckBox.Checked) input.SearchCond.NyukinHoho.Add("001");

            // 入金方法/銀行(13)
            if (bankCheckBox.Checked) input.SearchCond.NyukinHoho.Add("002");

            // 入金方法/現金(14)
            if (genkinCheckBox.Checked) input.SearchCond.NyukinHoho.Add("003");

            // 入金日（開始）(16)
            input.SearchCond.NyukinDtFrom = nyukinDtUseCheckBox.Checked ? nyukinDtFromDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 入金日（終了）(17)
            input.SearchCond.NyukinDtTo = nyukinDtUseCheckBox.Checked ? nyukinDtToDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            // 追加条件/なし/割振残あり/繰越し金あり/返金あり
            input.SearchCond.TsuikaJoken = warifuriRadioButton.Checked ? "1" : (kurikoshiRadioButton.Checked ? "2" : (henkinRadioButton.Checked ? "3" : string.Empty));
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
        /// 2014/09/15  AnhNV　　    新規作成
        /// 2014/11/04  AnhNV　　    基本設計書_006_010_画面_NyukinList_Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool RelationCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 入金日（開始＆終了）
            if (nyukinDtUseCheckBox.Checked
                && nyukinDtFromDateTimePicker.Value.Date > nyukinDtToDateTimePicker.Value.Date)
            {
                errMsg.AppendLine("範囲指定が正しくありません。入金日の大小関係を確認してください。");
            }

            // 業者コード（開始＆終了）
            if (Convert.ToDecimal(string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) ? "0" : gyosyaCdFromTextBox.Text)
                > Convert.ToDecimal(string.IsNullOrEmpty(gyosyaCdToTextBox.Text) ? "9999" : gyosyaCdToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
            }

            // 入金種別
            if (!seikyuCheckBox.Checked
                && !maeukekinCheckBox.Checked
                && !keiryoSyomeiCheckBox.Checked
                && !yoshiHanbaiCheckBox.Checked
                && !kinohoshoCheckBox.Checked
                && !nenkaihiCheckBox.Checked
                && !tesuryoCheckBox.Checked)
            {
                errMsg.AppendLine("入金種別を選択してください");
            }

            // 入金方法
            if (!yubinCheckBox.Checked && !bankCheckBox.Checked && !genkinCheckBox.Checked)
            {
                errMsg.AppendLine("入金方法を選択してください");
            }

            // Has an error?
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
            // 子画面が正常終了した場合
            if (childForm.DialogResult == DialogResult.OK)
            {
                kensakuButton.PerformClick();
            }
        }
        #endregion

        #region SetStdControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            gyosyaCdFromTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            gyosyaCdToTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            nyukinNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            nyukinListDataGridView.SetStdControlDomain(nyukinNoCol.Index, ZControlDomain.ZG_STD_CD, 11);
            nyukinListDataGridView.SetStdControlDomain(ShisyoNmCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            nyukinListDataGridView.SetStdControlDomain(gyosyaCdCol.Index, ZControlDomain.ZG_STD_CD, 4);
            nyukinListDataGridView.SetStdControlDomain(nyukinNmCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            nyukinListDataGridView.SetStdControlDomain(syubetsuCol.Index, ZControlDomain.ZG_STD_NAME, 20);
            nyukinListDataGridView.SetStdControlDomain(nyukinDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            nyukinListDataGridView.SetStdControlDomain(NyukinHohoCol.Index, ZControlDomain.ZG_STD_NAME, 20);
            nyukinListDataGridView.SetStdControlDomain(kozaNoCol.Index, ZControlDomain.ZG_STD_NAME, 40);
            nyukinListDataGridView.SetStdControlDomain(seikyuTotalCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            nyukinListDataGridView.SetStdControlDomain(nyukinTotalCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            nyukinListDataGridView.SetStdControlDomain(sagakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            nyukinListDataGridView.SetStdControlDomain(warifuriCol.Index, ZControlDomain.ZG_STD_CD, 2, DataGridViewContentAlignment.MiddleCenter);
            nyukinListDataGridView.SetStdControlDomain(kurikoshiCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            nyukinListDataGridView.SetStdControlDomain(henkinCol.Index, ZControlDomain.ZG_STD_NUM, 10);
        }
        #endregion

        #endregion
    }
    #endregion
}
