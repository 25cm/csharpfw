using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaYoteiList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaYoteiListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaYoteiListForm : FukjBaseForm
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
        /// Radio button before checked changed
        /// </summary>
        private RadioButton _lastRdChecked;
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaYoteiListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaYoteiListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaYoteiListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaYoteiListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaYoteiListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.hagakiSyubetsuTableAdapter.Fill(this.constMstDataSet.HagakiSyubetsu);

                SetControlDomain();

                SetDefaultValues();

                DoFormLoad();

                _lastRdChecked = kensa7JoRadioButton;
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
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
        /// 2014/09/03  DatNT　  新規作成
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

                printCntTextBox.Clear();
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

        #region gyosyaSrhButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaSrhButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaSrhButton_Click(object sender, EventArgs e)
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
                    gyosyaTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region allButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： allButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void allButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[SelectCol.Name];
                    chk.Value = true;
                }

                if (yoteiListDataGridView.RowCount > 0)
                {
                    printCntTextBox.Text = yoteiListDataGridView.RowCount.ToString();
                }
                else
                {
                    printCntTextBox.Clear();
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

        #region kaijoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaijoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaijoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[SelectCol.Name];
                    chk.Value = false;
                }

                printCntTextBox.Text = string.Empty;
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

        #region torikeshiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torikeshiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torikeshiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 未選択チェック
                if (!UnselectedCheck()) { return; }

                // 更新チェック
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択された検査の検査票、はがき出力済を取り消します。よろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                {
                    DoUpdate();
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

        #region hagakiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hagakiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hagakiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 未選択チェック
                if (!UnselectedCheck()) { return; }

                // はがき印刷
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択された検査のはがきを印刷します。よろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                {
                    // Printer is not installed
                    // 2014.12.16 toyoda Mod Start プリンタ設定をDB保持に変更
                    //string printer = Common.Common.GetPrinterName(Utility.Constants.PrinterConstant.PRINT_TYPE_HAGAKI);
                    string printer = Common.Common.GetPrinterName(Utility.Constants.PrintKbn.PRINT_KBN_HAGAKI);
                    // 2014.12.16 toyoda Mod End

                    if (!Common.Common.PrinterExist(printer))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "印刷先のプリンターが設定されていません。");
                        return;
                    }

                    DoHagaki();

                    printCntTextBox.Clear();
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

        #region seisoKakuninButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： seisoKakuninButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void seisoKakuninButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 未選択チェック
                if (!UnselectedCheck()) { return; }

                // 清掃確認表印刷
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択された検査の清掃確認表を印刷します。よろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                {
                    ISeisoKakuninBtnClickALInput alInput = new SeisoKakuninBtnClickALInput();
                    alInput.KensaYoteiListDataTable = GetTablePrintFromDgv();
                    alInput.KensaYoteiPrintCheck = kensaYoteiPrintCheckBox.Checked;

                    new SeisoKakuninBtnClickApplicationLogic().Execute(alInput);
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (yoteiListDataGridView.RowCount == 0) return;

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査予定一覧";
                FlushDGVExcel(yoteiListDataGridView, outputFilename);
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
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //GaikanKensaMenuForm frm = new GaikanKensaMenuForm();
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

        #region kensaYoteiDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaYoteiDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaYoteiDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaYoteiDtUseCheckBox.Checked)
                {
                    // 検査予定日（開始）
                    kensaYoteiDtFromDateTimePicker.Enabled = true;

                    // 検査予定日（終了）
                    kensaYoteiDtToDateTimePicker.Enabled = true;

                    // 検査日未定含む（年月での検索）
                    kensaMiteiCheckBox.Enabled = true;
                }
                else
                {
                    // 検査予定日（開始）
                    kensaYoteiDtFromDateTimePicker.Enabled = false;

                    // 検査予定日（終了）
                    kensaYoteiDtToDateTimePicker.Enabled = false;

                    // 検査日未定含む（年月での検索）
                    kensaMiteiCheckBox.Enabled = false;
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

        #region yoteiListDataGridView_CellContentClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoteiListDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoteiListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                int printCnt = 0;

                string colName = yoteiListDataGridView.Columns[e.ColumnIndex].Name;

                if (colName == "SelectCol")
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)yoteiListDataGridView.CurrentRow.Cells[colName];

                    if (chk.Value == null || chk.Value.ToString() == "0" || string.IsNullOrEmpty(chk.Value.ToString()))
                    {
                        chk.Value = "1";
                    }
                    else
                    {
                        chk.Value = "0";
                    }

                    foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell ch = (DataGridViewCheckBoxCell)row.Cells[colName];

                        if (ch.Value != null && ch.Value.ToString() == "1")
                        {
                            printCnt++;
                        }
                    }

                    if (printCnt != 0)
                    {
                        printCntTextBox.Text = printCnt.ToString();
                    }
                    else
                    {
                        printCntTextBox.Text = string.Empty;
                    }

                    yoteiListDataGridView.EndEdit();
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

        #region kensa7JoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensa7JoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensa7JoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                RadioButton rd = sender as RadioButton;

                if (!rd.Checked || _lastRdChecked == rd) return;

                if (!ChangeRadioBtnCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧をクリアしてもよろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                    {
                        ClearDgv();

                        _lastRdChecked = kensa7JoRadioButton;
                    }
                    else
                    {
                        _lastRdChecked.Checked = true;
                    }
                }
                else
                {
                    ClearDgv();
                    _lastRdChecked = kensa7JoRadioButton;
                }

                if (kensa7JoRadioButton.Checked)
                {
                    seisoKakuninButton.Enabled = false;
                }
                else
                {
                    seisoKakuninButton.Enabled = true;
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

        #region kensa11JoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensa11JoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensa11JoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                RadioButton rd = sender as RadioButton;

                if (!rd.Checked || _lastRdChecked == rd) return;

                if (!ChangeRadioBtnCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧をクリアしてもよろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                    {
                        ClearDgv();

                        _lastRdChecked = kensa11JoRadioButton;
                    }
                    else
                    {
                        _lastRdChecked.Checked = true;
                    }
                }
                else
                {
                    ClearDgv();
                    _lastRdChecked = kensa11JoRadioButton;
                }

                if (kensa7JoRadioButton.Checked)
                {
                    seisoKakuninButton.Enabled = false;
                }
                else
                {
                    seisoKakuninButton.Enabled = true;
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

        #region KensaYoteiListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaYoteiListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaYoteiListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        torikeshiButton.Focus();
                        torikeshiButton.PerformClick();
                        break;

                    case Keys.F2:
                        hagakiButton.PerformClick();
                        hagakiButton.Focus();
                        break;

                    case Keys.F3:
                        seisoKakuninButton.PerformClick();
                        seisoKakuninButton.Focus();
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

        #region ninsoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ninsoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ninsoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(ninsoFromTextBox.Text))
                {
                    ninsoToTextBox.Text = ninsoFromTextBox.Text;
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

        #region ninsoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ninsoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ninsoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(ninsoToTextBox.Text))
                {
                    ninsoToTextBox.Text = Convert.ToInt32(ninsoToTextBox.Text).ToString();
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

        #region kyokaiFrom1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text))
                {
                    kyokaiFrom1TextBox.Text = kyokaiFrom1TextBox.Text.PadLeft(2, '0');
                    kyokaiTo1TextBox.Text = kyokaiFrom1TextBox.Text;
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

        #region kyokaiFrom2TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom2TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text))
                {
                    kyokaiFrom2TextBox.Text = kyokaiFrom2TextBox.Text.PadLeft(2, '0');
                    kyokaiTo2TextBox.Text = kyokaiFrom2TextBox.Text;
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

        #region kyokaiFrom3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text))
                {
                    kyokaiFrom3TextBox.Text = kyokaiFrom3TextBox.Text.PadLeft(6, '0');
                    kyokaiTo3TextBox.Text = kyokaiFrom3TextBox.Text;
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

        #region kyokaiTo1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text))
                {
                    kyokaiTo1TextBox.Text = kyokaiTo1TextBox.Text.PadLeft(2, '0');
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

        #region kyokaiFrom1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text))
                {
                    kyokaiTo2TextBox.Text = kyokaiTo2TextBox.Text.PadLeft(2, '0');
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

        #region kyokaiTo3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text))
                {
                    kyokaiTo3TextBox.Text = kyokaiTo3TextBox.Text.PadLeft(6, '0');
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

        #region settisyaKanaFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： settisyaKanaFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20  DatNT　   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void settisyaKanaFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(settisyaKanaFromTextBox.Text))
                {
                    settisyaKanaToTextBox.Text = settisyaKanaFromTextBox.Text;
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

        #region kensaYoteiDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaYoteiDtFromDateTimePicker_ValueChanged
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
        private void kensaYoteiDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaYoteiDtToDateTimePicker.Value = kensaYoteiDtFromDateTimePicker.Value;
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
        /// 2014/09/03  DatNT　  新規作成
        /// 2015/01/13  HuyTX　  Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            kensaIraiTblDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShokuinKensainFlg = "1";
            alInput.ShokuinTaishokuFlg = "0";//2015.01.29 add kiyokuni
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検査員
            Utility.Utility.SetComboBoxList(kensainComboBox, alOutput.ShokuinMstDT, "ShokuinNm", "ShokuinCd", true);

            yoteiListDataGridView.Columns["SelectCol"].DisplayIndex = 0;

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            //Ver1.04 start
            //市区町村
            Utility.Utility.SetComboBoxList(shikuchosonComboBox,
                                alOutput.ShikuchosonInfoDataTable,
                                alOutput.ShikuchosonInfoDataTable.ChikuNmColumn.ColumnName,
                                alOutput.ShikuchosonInfoDataTable.ChikuCdColumn.ColumnName,
                                true);
            //End
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
        /// 2014/09/03  DatNT　  新規作成
        /// 2015/01/14  HuyTX　  Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            KensaYoteiListSearchCond searchCond = new KensaYoteiListSearchCond();

            // 検査員
            if (kensainComboBox.SelectedValue != null)
            {
                searchCond.ShokuinCd = kensainComboBox.SelectedValue.ToString();
            }
            
            // 検査種別
            searchCond.KensaIraiHoteiKbn = kensa7JoRadioButton.Checked ? "1" : "2";

            searchCond.HokenjoCdFrom = kyokaiFrom1TextBox.Text.Trim();
            searchCond.NendoFrom = !string.IsNullOrEmpty(kyokaiFrom2TextBox.Text.Trim()) ? Utility.DateUtility.ConvertFromWareki(kyokaiFrom2TextBox.Text.Trim(), "yyyy") : string.Empty;
            searchCond.RenbanFrom = kyokaiFrom3TextBox.Text.Trim();
            searchCond.HokenjoCdTo = kyokaiTo1TextBox.Text.Trim();
            searchCond.NendoTo = !string.IsNullOrEmpty(kyokaiTo2TextBox.Text.Trim()) ? Utility.DateUtility.ConvertFromWareki(kyokaiTo2TextBox.Text.Trim(), "yyyy") : string.Empty;
            searchCond.RenbanTo = kyokaiTo3TextBox.Text.Trim();

            // 出力順
            if (settibasyoJunRadioButton.Checked)
            {
                searchCond.OutputOrder = "1";
            }
            if (tizuNoJunRadioButton.Checked)
            {
                searchCond.OutputOrder = "2";
            }
            if (yoteiDtJunRadioButton.Checked)
            {
                searchCond.OutputOrder = "3";
            }
            if (kyokaiNoJunRadioButton.Checked)
            {
                searchCond.OutputOrder = "4";
            }

            // 検査予定日検索使用フラグ
            searchCond.KensaYoteiDtUse = kensaYoteiDtUseCheckBox.Checked;

            // 検査予定日（開始）
            searchCond.KensaYoteiDtFrom = kensaYoteiDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査予定日（終了）
            searchCond.KensaYoteiDtTo = kensaYoteiDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査日未定含む（年月での検索）
            searchCond.KensaMitei = kensaMiteiCheckBox.Checked;

            // 設置住所
            searchCond.SettiAdr = settiAdrTextBox.Text.Trim();

            // 設置者カナ（開始）
            searchCond.SettisyaKanaFrom = settisyaKanaFromTextBox.Text.Trim();

            // 設置者カナ（終了）
            searchCond.SettisyaKanaTo = settisyaKanaToTextBox.Text.Trim();

            // 依頼業者
            searchCond.GyoshaNm = gyosyaTextBox.Text.Trim();

            // 人槽（開始）
            searchCond.NinsoFrom = ninsoFromTextBox.Text;

            // 人槽（終了）
            searchCond.NinsoTo = ninsoToTextBox.Text;

            //Ver1.04 start
            //市区町村
            searchCond.Shikuchoson = shikuchosonComboBox.SelectedValue != null ? shikuchosonComboBox.SelectedValue.ToString() : string.Empty;
            //End

            alInput.SearchCond = searchCond;
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
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            printCntTextBox.Clear();

            // Clear datagirdview
            kensaIraiTblDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            //kensaIraiTblDataSet.Merge(DispData(alOutput.KensaYoteiListDT));
            kensaIraiTblDataSet.Merge(alOutput.KensaYoteiListDT);

            if (alOutput.KensaYoteiListDT == null || alOutput.KensaYoteiListDT.Count == 0)
            {
                srhListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                srhListCountLabel.Text = alOutput.KensaYoteiListDT.Count.ToString() + "件";
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
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            //bool flg = true;
            //bool isValid = true;
            string kyokaiFrom = string.Concat(kyokaiFrom1TextBox.Text, kyokaiFrom2TextBox.Text, kyokaiFrom3TextBox.Text);
            string kyokaiTo = string.Concat(kyokaiTo1TextBox.Text, kyokaiTo2TextBox.Text, kyokaiTo3TextBox.Text);

            // 協会No（開始）
            if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) && kyokaiFrom1TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（開始）(保健所コード)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) && kyokaiFrom2TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（開始） (年度)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) && kyokaiFrom3TextBox.Text.Length != 6)
            {
                errMess.AppendLine("協会No（開始） (連番)は6桁で入力して下さい。");
                //flg = false;
            }

            // 協会No（終了）
            if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text) && kyokaiTo1TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（終了） (保健所コード)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text) && kyokaiTo2TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（終了） (年度)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text) && kyokaiTo3TextBox.Text.Length != 6)
            {
                errMess.AppendLine("協会No（終了） (連番)は6桁で入力して下さい。");
                //flg = false;
            }

            if (kensaYoteiDtUseCheckBox.Checked)
            {
                // 検査予定日
                if (kensaYoteiDtFromDateTimePicker.Value > kensaYoteiDtToDateTimePicker.Value)
                {
                    errMess.AppendLine("範囲指定が正しくありません。検査予定日の大小関係を確認してください。");
                }
            }

            //協会No（開始＆終了）
            // 2014/10/27 AnhNV UPD start
            if (!Utility.Utility.IsValidKyokaiNo(kyokaiFrom1TextBox, kyokaiFrom2TextBox, kyokaiFrom3TextBox, kyokaiTo1TextBox, kyokaiTo2TextBox, kyokaiTo3TextBox))
            {
                errMess.AppendLine("範囲指定が正しくありません。検査番号の大小関係を確認してください。");
            }
            // 2014/10/27 AnhNV UPD end

            // 2014/10/27 AnhNV DEL start
            //if (kyokaiFrom.Length == 10 && kyokaiTo.Length == 10
            //    && (Convert.ToDecimal(kyokaiFrom) > Convert.ToDecimal(kyokaiTo)))
            //{
            //    isValid = false;
            //}

            //if (flg
            //    && (kyokaiFrom.Length != 10 || kyokaiTo.Length != 10)
            //    && ((!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) 
            //        && !string.IsNullOrEmpty(kyokaiTo1TextBox.Text)
            //        && Convert.ToInt32(kyokaiFrom1TextBox.Text) > Convert.ToInt32(kyokaiTo1TextBox.Text))
            //    || (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text)
            //        && !string.IsNullOrEmpty(kyokaiTo2TextBox.Text)
            //        && Convert.ToInt32(kyokaiFrom2TextBox.Text) > Convert.ToInt32(kyokaiTo2TextBox.Text))
            //    || (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text)
            //        && !string.IsNullOrEmpty(kyokaiTo3TextBox.Text)
            //        && Convert.ToInt32(kyokaiFrom3TextBox.Text) > Convert.ToInt32(kyokaiTo3TextBox.Text))))
            //{
            //    isValid = false;
            //}

            //if (!isValid)
            //{
            //    errMess.Append("範囲指定が正しくありません。検査番号の大小関係を確認してください。\r\n");
            //}
            // 2014/10/27 AnhNV DEL end

            // 設置者カナ（開始＆終了）
            if (!string.IsNullOrEmpty(settisyaKanaFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(settisyaKanaToTextBox.Text.Trim()))
            {
                if (string.Compare(settisyaKanaFromTextBox.Text.Trim(), settisyaKanaToTextBox.Text.Trim()) > 0)
                {
                    errMess.Append("範囲指定が正しくありません。設置者カナの大小関係を確認してください。\r\n");
                }
            }

            // 人槽（開始＆終了）
            if (!string.IsNullOrEmpty(ninsoFromTextBox.Text) && !string.IsNullOrEmpty(ninsoToTextBox.Text))
            {
                if (Convert.ToInt32(ninsoFromTextBox.Text) > Convert.ToInt32(ninsoToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。人槽の大小関係を確認してください。\r\n");
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
        /// 2014/09/03  DatNT　  新規作成
        /// 2015/01/14  HuyTX　  Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 検査員
            kensainComboBox.SelectedIndex = -1;

            // 検査種別/７条検査
            kensa7JoRadioButton.Checked = true;

            // 協会No（開始） (保健所コード)
            kyokaiFrom1TextBox.Clear();

            // 協会No（開始） (年度)
            kyokaiFrom2TextBox.Clear();

            // 協会No（開始） (連番)
            kyokaiFrom3TextBox.Clear();

            // 協会No（終了） (保健所コード)
            kyokaiTo1TextBox.Clear();

            // 協会No（終了） (年度)
            kyokaiTo2TextBox.Clear();

            // 協会No（終了） (連番)
            kyokaiTo3TextBox.Clear();

            // 出力順/設置場所順
            settibasyoJunRadioButton.Checked = true;

            // 検査予定日検索使用フラグ
            kensaYoteiDtUseCheckBox.Checked = false;

            // 検査予定日（開始）
            kensaYoteiDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            kensaYoteiDtFromDateTimePicker.Enabled = false;

            // 検査予定日（終了）
            kensaYoteiDtToDateTimePicker.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            kensaYoteiDtToDateTimePicker.Enabled = false;

            // 検査日未定含む（年月での検索）
            kensaMiteiCheckBox.Checked = false;
            kensaMiteiCheckBox.Enabled = false;

            // 設置住所
            settiAdrTextBox.Clear();

            // 設置者カナ（開始）
            settisyaKanaFromTextBox.Clear();

            // 設置者カナ（終了）
            settisyaKanaToTextBox.Clear();

            // 依頼業者
            gyosyaTextBox.Clear();

            // 人槽（開始）
            ninsoFromTextBox.Clear();

            // 人槽（終了）
            ninsoToTextBox.Clear();

            // {清掃確認表ボタン} =  非活性
            seisoKakuninButton.Enabled = false;

            //Ver1.04 Start
            //市区町村
            shikuchosonComboBox.SelectedIndex = -1;
            //End
        }
        #endregion

        #region UnselectedCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UnselectedCheck
        /// <summary>
        /// 未選択チェック
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnselectedCheck()
        {
            if (string.IsNullOrEmpty(printCntTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "対象の検査が選択されていません。");
                return false;
            }

            return true;
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
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            // KensaIraiTblDataTable
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            // JokasoDaichoMstDataTable
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable daichoMstDT = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
            {
                if (row.Cells[SelectCol.Name].Value == null || (int)row.Cells[SelectCol.Name].Value == 0)
                {
                    // don't handled
                }
                else
                {
                    #region KensaIraiTblRow

                    KensaIraiTblDataSet.KensaIraiTblRow kensaIraiTblRow = kensaIraiTblDT.NewKensaIraiTblRow();

                    // 検査依頼法定区分
                    kensaIraiTblRow.KensaIraiHoteiKbn = row.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();

                    // 検査依頼保健所コード
                    kensaIraiTblRow.KensaIraiHokenjoCd = row.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();

                    // 検査依頼年度
                    kensaIraiTblRow.KensaIraiNendo = row.Cells[KensaIraiNendoCol.Name].Value.ToString();

                    // 検査依頼連番
                    kensaIraiTblRow.KensaIraiRenban = row.Cells[KensaIraiRenbanCol.Name].Value.ToString();

                    kensaIraiTblRow.UpdateDt                    = (DateTime)row.Cells[KensaIraiTblUpdateDtCol.Name].Value;
                    kensaIraiTblRow.UpdateUser                  = string.Empty;
                    kensaIraiTblRow.UpdateTarm                  = string.Empty;
                    kensaIraiTblRow.KensaIraiUketsukeShishoKbn  = string.Empty;
                    kensaIraiTblRow.KensaIraiJokasoHokenjoCd    = string.Empty;
                    kensaIraiTblRow.KensaIraiJokasoTorokuNendo  = string.Empty;
                    kensaIraiTblRow.KensaIraiJokasoRenban       = string.Empty;
                    kensaIraiTblRow.InsertDt                    = today;
                    kensaIraiTblRow.InsertTarm                  = string.Empty;
                    kensaIraiTblRow.InsertUser                  = string.Empty;

                    kensaIraiTblDT.AddKensaIraiTblRow(kensaIraiTblRow);

                    #endregion

                    #region JokasoDaichoMstRow

                    JokasoDaichoMstDataSet.JokasoDaichoMstRow daichoRow = daichoMstDT.NewJokasoDaichoMstRow();

                    // 浄化槽保健所コード
                    daichoRow.JokasoHokenjoCd = row.Cells[JokasoHokenjoCdCol.Name].Value.ToString();

                    // 浄化槽台帳登録年度
                    daichoRow.JokasoTorokuNendo = row.Cells[JokasoTorokuNendoCol.Name].Value.ToString();

                    // 浄化槽台帳連番
                    daichoRow.JokasoRenban = row.Cells[JokasoRenbanCol.Name].Value.ToString();

                    // はがき区分
                    daichoRow.JokasoHagakiKbn = row.Cells[hagakiSyubetsuCol.Name].Value.ToString();

                    daichoRow.UpdateDt          = (DateTime)row.Cells[JokasoDaichoMstUpdateDtCol.Name].Value;
                    daichoRow.UpdateTarm        = string.Empty;
                    daichoRow.UpdateUser        = string.Empty;
                    daichoRow.InsertDt          = today;
                    daichoRow.InsertTarm        = string.Empty;
                    daichoRow.InsertUser        = string.Empty;

                    bool flg = true;

                    if (daichoMstDT != null && daichoMstDT.Count > 0)
                    {
                        foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow checkRow in daichoMstDT)
                        {
                            if (daichoRow.JokasoHokenjoCd == checkRow.JokasoHokenjoCd
                                && daichoRow.JokasoTorokuNendo == checkRow.JokasoTorokuNendo
                                && daichoRow.JokasoRenban == checkRow.JokasoRenban)
                            {
                                flg = false;
                            }
                        }
                    }

                    if (flg)
                    {
                        daichoMstDT.AddJokasoDaichoMstRow(daichoRow);
                    }

                    #endregion
                }
            }

            ITorikeshiBtnClickALInput alInput   = new TorikeshiBtnClickALInput();
            alInput.KensaIraiTblDataTable       = kensaIraiTblDT;
            alInput.JokasoDaichoMstDT           = daichoMstDT;
            ITorikeshiBtnClickALOutput alOutput = new TorikeshiBtnClickApplicationLogic().Execute(alInput);

            DoSearch();
        }
        #endregion

        #region DoHagaki
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoHagaki
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoHagaki()
        {
            // KensaIraiTblDataTable
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            // JokasoDaichoMstDataTable
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable daichoMstDT = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
            {
                if (row.Cells[SelectCol.Name].Value == null || (int)row.Cells[SelectCol.Name].Value == 0)
                {
                    // don't handled
                }
                else
                {
                    #region KensaIraiTblRow

                    KensaIraiTblDataSet.KensaIraiTblRow kensaIraiTblRow = kensaIraiTblDT.NewKensaIraiTblRow();

                    // 検査依頼法定区分
                    kensaIraiTblRow.KensaIraiHoteiKbn = row.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();

                    // 検査依頼保健所コード
                    kensaIraiTblRow.KensaIraiHokenjoCd = row.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();

                    // 検査依頼年度
                    kensaIraiTblRow.KensaIraiNendo = row.Cells[KensaIraiNendoCol.Name].Value.ToString();

                    // 検査依頼連番
                    kensaIraiTblRow.KensaIraiRenban = row.Cells[KensaIraiRenbanCol.Name].Value.ToString();

                    kensaIraiTblRow.UpdateDt = (DateTime)row.Cells[KensaIraiTblUpdateDtCol.Name].Value;
                    kensaIraiTblRow.UpdateUser = string.Empty;
                    kensaIraiTblRow.UpdateTarm = string.Empty;
                    kensaIraiTblRow.KensaIraiUketsukeShishoKbn = string.Empty;
                    kensaIraiTblRow.KensaIraiJokasoHokenjoCd = string.Empty;
                    kensaIraiTblRow.KensaIraiJokasoTorokuNendo = string.Empty;
                    kensaIraiTblRow.KensaIraiJokasoRenban = string.Empty;
                    kensaIraiTblRow.InsertDt = today;
                    kensaIraiTblRow.InsertTarm = string.Empty;
                    kensaIraiTblRow.InsertUser = string.Empty;

                    kensaIraiTblDT.AddKensaIraiTblRow(kensaIraiTblRow);

                    #endregion

                    #region JokasoDaichoMstRow

                    JokasoDaichoMstDataSet.JokasoDaichoMstRow daichoRow = daichoMstDT.NewJokasoDaichoMstRow();

                    // 浄化槽保健所コード
                    daichoRow.JokasoHokenjoCd = row.Cells[JokasoHokenjoCdCol.Name].Value.ToString();

                    // 浄化槽台帳登録年度
                    daichoRow.JokasoTorokuNendo = row.Cells[JokasoTorokuNendoCol.Name].Value.ToString();

                    // 浄化槽台帳連番
                    daichoRow.JokasoRenban = row.Cells[JokasoRenbanCol.Name].Value.ToString();

                    // はがき区分
                    daichoRow.JokasoHagakiKbn = row.Cells[hagakiSyubetsuCol.Name].Value.ToString();

                    daichoRow.UpdateDt = (DateTime)row.Cells[JokasoDaichoMstUpdateDtCol.Name].Value;
                    daichoRow.UpdateTarm = string.Empty;
                    daichoRow.UpdateUser = string.Empty;
                    daichoRow.InsertDt = today;
                    daichoRow.InsertTarm = string.Empty;
                    daichoRow.InsertUser = string.Empty;

                    bool flg = true;

                    if (daichoMstDT != null && daichoMstDT.Count > 0)
                    {
                        foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow checkRow in daichoMstDT)
                        {
                            if (daichoRow.JokasoHokenjoCd == checkRow.JokasoHokenjoCd
                                && daichoRow.JokasoTorokuNendo == checkRow.JokasoTorokuNendo
                                && daichoRow.JokasoRenban == checkRow.JokasoRenban)
                            {
                                flg = false;
                            }
                        }
                    }

                    if (flg)
                    {
                        daichoMstDT.AddJokasoDaichoMstRow(daichoRow);
                    }

                    #endregion
                }
            }

            IHagakiBtnClickALInput alInput = new HagakiBtnClickALInput();
            alInput.KensaIraiTblDataTable = kensaIraiTblDT;
            alInput.JokasoDaichoMstDT = daichoMstDT;
            //get table print
            alInput.KensaYoteiListDataTable = GetTablePrintFromDgv();
            IHagakiBtnClickALOutput alOutput = new HagakiBtnClickApplicationLogic().Execute(alInput);

            DoSearch();
        }
        #endregion

        #region ClearDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearDgv()
        {
            kensaIraiTblDataSet.Clear();

            printCntTextBox.Clear();

            srhListCountLabel.Text = "0件";
        }
        #endregion

        #region GetTablePrintFromDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetTablePrintFromDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaYoteiListDataTable GetTablePrintFromDgv()
        {
            KensaIraiTblDataSet.KensaYoteiListDataTable table = new KensaIraiTblDataSet.KensaYoteiListDataTable();

            foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
            {
                if (row.Cells[SelectCol.Name].Value != null && row.Cells[SelectCol.Name].Value.ToString() == "1")
                {
                    KensaIraiTblDataSet.KensaYoteiListRow dr = (KensaIraiTblDataSet.KensaYoteiListRow)(row.DataBoundItem as DataRowView).Row;

                    table.ImportRow(dr);
                }
            }

            return table;
        }
        #endregion

        #region ChangeRadioBtnCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeRadioBtnCheck
        /// <summary>
        /// 検査種別切替チェック
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool ChangeRadioBtnCheck()
        {
            if (yoteiListDataGridView.RowCount == 0) return true;

            foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
            {
                if (row.Cells[SelectCol.Name].Value != null && (int)row.Cells[SelectCol.Name].Value == 1)
                {
                    return false;
                }
            }

            return true;
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

        #region FlushDGVExcel
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： FlushDGVExcel
        /// <summary>
        ///  指定GridviewのデータをExcelに出力する
        /// </summary>
        /// <param name="targetDataGridView">対象DataGridView</param>
        /// <param name="outputFilename"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　DatNT　　 新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void FlushDGVExcel(DataGridView targetDataGridView, string outputFilename)
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
                            if (targetDataGridView.Columns[j].Name == "ninsoCol")
                            {
                                xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value;
                                Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];

                                continue;
                            }

                            // Date columns format
                            if (targetDataGridView.Columns[j].Name.Length > 5
                                && targetDataGridView.Columns[j].Name.Substring(targetDataGridView.Columns[j].Name.Length - 5) == "DtCol")
                            {
                                xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                                Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                                rng.EntireColumn.NumberFormat = "yyyy/MM/dd";

                                continue;
                            }

                            if (targetDataGridView.Columns[j].Name == "hagakiSyubetsuCol")
                            {
                                xlWorkSheet.Cells[i + 2, j + 1] = cell.FormattedValue.ToString();

                                continue;
                            }

                            xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
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

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 検査番号（開始） (保健所コード)
            kyokaiFrom1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（開始） (年度)
            kyokaiFrom2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（開始） (連番)
            kyokaiFrom3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            // 検査番号（終了） (保健所コード)
            kyokaiTo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（終了） (年度)
            kyokaiTo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（終了） (連番)
            kyokaiTo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            // 設置住所
            settiAdrTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 80);

            // 設置者カナ（開始）;
            settisyaKanaFromTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 30);

            // 設置者カナ（終了）
            settisyaKanaToTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 30);

            // 依頼業者
            gyosyaTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 40);

            // 人槽（開始）
            ninsoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);

            // 人槽（終了）
            ninsoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);

            // 行
            yoteiListDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 予定日
            yoteiListDataGridView.SetStdControlDomain(yoteiDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);

            // 検査番号
            yoteiListDataGridView.SetStdControlDomain(kyokaiNoCol.Index, ZControlDomain.ZG_STD_NAME, 12, DataGridViewContentAlignment.MiddleCenter);

            // 設置者名
            yoteiListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);

            // 設置場所
            yoteiListDataGridView.SetStdControlDomain(settiBasyoCol.Index, ZControlDomain.ZG_STD_NAME, 80);

            // 地図番号
            yoteiListDataGridView.SetStdControlDomain(chizuNoCol.Index, ZControlDomain.ZG_STD_NAME, 10);

            // 単/合
            yoteiListDataGridView.SetStdControlDomain(syoriHoshikiCol.Index, ZControlDomain.ZG_STD_NAME, 14);

            // 人槽
            yoteiListDataGridView.SetStdControlDomain(ninsoCol.Index, ZControlDomain.ZG_STD_NUM, 4);

            // 管理業者
            yoteiListDataGridView.SetStdControlDomain(gyosyaCol.Index, ZControlDomain.ZG_STD_NAME, 40);

            // はがき
            yoteiListDataGridView.SetStdControlDomain(hagakiCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);
        }
        #endregion

        #region DEL_20141118
        //#region DispData
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： DispData
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/13  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaIraiTblDataSet.KensaYoteiListDataTable DispData(KensaIraiTblDataSet.KensaYoteiListDataTable dataTable)
        //{
        //    KensaIraiTblDataSet.KensaYoteiListDataTable dispDT = new KensaIraiTblDataSet.KensaYoteiListDataTable();

        //    foreach (KensaIraiTblDataSet.KensaYoteiListRow row in dataTable.Rows)
        //    {
        //        row.kyokaiNoCol = row.KensaIraiHokenjoCd + "-" 
        //                            + Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy") + "-"
        //                            + row.KensaIraiRenban;

        //        dispDT.ImportRow(row);
        //    }            

        //    return dispDT;
        //}
        //#endregion
        #endregion

        #endregion

    }
    #endregion
}
