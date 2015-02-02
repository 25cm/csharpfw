using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaTorisageListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/26　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaTorisageListForm : FukjBaseForm
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
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// kensaTorisageListDataTable
        /// </summary>
        private KensaIraiTblDataSet.KensaTorisageListDataTable _kensaTorisageListDataTable = new KensaIraiTblDataSet.KensaTorisageListDataTable();

        /// <summary>
        /// rdChecked
        /// </summary>
        private RadioButton _rdChecked = new RadioButton();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaTorisageListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaTorisageListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaTorisageListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaTorisageListForm_Load
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
        private void KensaTorisageListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                //set default control domain
                SetControlDomain();

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

        #region KensaShubetsuRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaShubetsuRadioButton_CheckedChanged
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
        private void KensaShubetsuRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                RadioButton rd = sender as RadioButton;
                if (!rd.Checked || _rdChecked == rd) return;

                if (IsShowWarning()
                    && MessageForm.Show2(MessageForm.DispModeType.Question, "表示している一覧は更新されていません。\n一覧をクリアしてもよろしいですか？") != DialogResult.Yes)
                {
                    _rdChecked.Checked = true;
                    return;

                }
                _rdChecked = rd;

                SetDisplayControl();

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
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensainComboBox.SelectedIndex = 0;
                kensa7JoRadioButton.Checked = true;
                kyokaiFrom1TextBox.Text = string.Empty;
                kyokaiFrom2TextBox.Text = string.Empty;
                kyokaiFrom3TextBox.Text = string.Empty;
                kyokaiTo1TextBox.Text = string.Empty;
                kyokaiTo2TextBox.Text = string.Empty;
                kyokaiTo3TextBox.Text = string.Empty;
                settisyaTextBox.Text = string.Empty;
                settiAdrTextBox.Text = string.Empty;
                kensaListDataGridView.DataSource = null;
                srhListCountLabel.Text = kensaListDataGridView.RowCount + "件";
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
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidDataSearch()) return;

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

        #region kensaListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaListDataGridView_CellDoubleClick
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
        private void kensaListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1
                    || e.ColumnIndex == selectCol.Index
                    || e.ColumnIndex == gesuiCol.Index
                    || e.ColumnIndex == haishiCol.Index
                    || e.ColumnIndex == gyohenCol.Index
                    || e.ColumnIndex == hokaCol.Index)
                { return; }

                KensaRirekiForm frm = new KensaRirekiForm(kensaListDataGridView.CurrentRow.Cells[jokasoNoCol.Name].Value.ToString());
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

        #region kensaListDataGridView_CellContentClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaListDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int[] cell11JoKensa = new int[] { 1, 2, 3, 4 };
                bool isCell = Array.Exists(cell11JoKensa, element => element == e.ColumnIndex);

                if (e.RowIndex == -1 || !isCell) return;

                for (int i = 0; i < cell11JoKensa.Length; i++)
                {
                    if (cell11JoKensa[i] == e.ColumnIndex)
                    {
                        kensaListDataGridView.Rows[e.RowIndex].Cells[cell11JoKensa[i]].Value = "1";
                        continue;
                    }
                    kensaListDataGridView.Rows[e.RowIndex].Cells[cell11JoKensa[i]].Value = "0";
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
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void allButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in kensaListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[selectCol.Name];
                    chk.Value = chk.TrueValue;
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
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaijoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in kensaListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[selectCol.Name];
                    chk.Value = chk.FalseValue;
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

        #region koshinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： koshinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/26　HuyTX    新規作成
        /// 2014/12/09　HuyTX    Fix bugs
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void koshinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidCheckBeforeSelect()) return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択された検査を取下げます。よろしいですか？") != DialogResult.Yes) return;

                KoshinBtnClickALInput alInput = new KoshinBtnClickALInput();
                alInput.KensaTorisageListDataTable = _kensaTorisageListDataTable;
                new KoshinBtnClickApplicationLogic().Execute(alInput);

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新完了しました。");

                //kensaListDataGridView.DataSource = null;
                //kensaListDataGridView.Rows.Clear();
                //srhListCountLabel.Text = kensaListDataGridView.RowCount + "件";
                
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

        #region kensaRirekiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaRirekiButton_Click
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
        private void kensaRirekiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //if (!IsSelectedDgv())
                if (kensaListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                KensaRirekiForm frm = new KensaRirekiForm(kensaListDataGridView.CurrentRow.Cells[jokasoNoCol.Name].Value.ToString());
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

        #region henkinIraiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkinIraiButton_Click
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
        private void henkinIraiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //if (!IsSelectedDgv())
                if (kensaListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                DataGridViewRow selectedRow = kensaListDataGridView.CurrentRow;

                KiansyaSelectForm frm = new KiansyaSelectForm(selectedRow.Cells[hideKensaSyubetsuCol.Name].Value.ToString(),
                                                            selectedRow.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString(),
                                                            selectedRow.Cells[KensaIraiNendoCol.Name].Value.ToString(),
                                                            selectedRow.Cells[KensaIraiRenbanCol.Name].Value.ToString());

                frm.ShowDialog();


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
        /// 2014/08/26　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaListDataGridView.RowCount == 0) return;

                List<string> hiddenCol = new List<string>();
                DataGridView dgvOutput = Common.Common.CopyDataGridView(kensaListDataGridView);

                foreach (DataGridViewColumn col in dgvOutput.Columns)
                {
                    if (col.Visible) continue;
                    hiddenCol.Add(col.Name);
                }

                foreach (var colRemove in hiddenCol)
                {
                    dgvOutput.Columns.Remove(colRemove);
                }
                
                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査取下げ一覧";
                Common.Common.FlushGridviewDataToExcel(dgvOutput, outputFilename);
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
        /// 2014/08/26　HuyTX    新規作成
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

        #region KensaTorisageListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaTorisageListForm_KeyDown
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
        private void KensaTorisageListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        koshinButton.PerformClick();
                        break;

                    case Keys.F2:
                        kensaRirekiButton.PerformClick();
                        break;

                    case Keys.F3:
                        henkinIraiButton.PerformClick();
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
        /// 2014/10/20　HuyTX     Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kyokaiFrom1TextBox.Text.Trim())) return;

                kyokaiFrom1TextBox.Text = kyokaiFrom1TextBox.Text.Trim().PadLeft(2, '0');
                kyokaiTo1TextBox.Text = kyokaiFrom1TextBox.Text.Trim().PadLeft(2, '0');

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
        /// 2014/10/20　HuyTX     Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kyokaiFrom2TextBox.Text.Trim())) return;

                kyokaiFrom2TextBox.Text = kyokaiFrom2TextBox.Text.Trim().PadLeft(2, '0');
                kyokaiTo2TextBox.Text = kyokaiFrom2TextBox.Text.Trim().PadLeft(2, '0');

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
        /// 2014/10/20　HuyTX     Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kyokaiFrom3TextBox.Text.Trim())) return;

                kyokaiFrom3TextBox.Text = kyokaiFrom3TextBox.Text.Trim().PadLeft(6, '0');
                kyokaiTo3TextBox.Text = kyokaiFrom3TextBox.Text.Trim().PadLeft(6, '0');

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
        /// 2014/10/20　HuyTX     Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kyokaiTo1TextBox.Text.Trim())) return;

                kyokaiTo1TextBox.Text = kyokaiTo1TextBox.Text.Trim().PadLeft(2, '0');

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

        #region kyokaiTo2TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo2TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　HuyTX     Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kyokaiTo2TextBox.Text.Trim())) return;

                kyokaiTo2TextBox.Text = kyokaiTo2TextBox.Text.Trim().PadLeft(2, '0');

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
        /// 2014/10/20　HuyTX     Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kyokaiTo3TextBox.Text.Trim())) return;

                kyokaiTo3TextBox.Text = kyokaiTo3TextBox.Text.Trim().PadLeft(6, '0');

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
        /// 2014/08/27　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //fill data to kensainComboBox
            Utility.Utility.SetComboBoxList(kensainComboBox, alOutput.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", true);

            //set Display control
            SetDisplayControl();

            _rdChecked = kensa7JoRadioButton;
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
        /// 2014/08/27　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            kensaListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            KensaIraiTblSearchCond searchCond = new KensaIraiTblSearchCond();

            if (kensainComboBox.SelectedIndex > 0)
            {
                searchCond.KensaIraiKensaTantoshaCd = kensainComboBox.SelectedValue.ToString();
            }

            searchCond.KensaIraiHoteiKbn = kensa7JoRadioButton.Checked ? "1" : "2";

            searchCond.HokenjoCdFrom = kyokaiFrom1TextBox.Text.Trim();
            searchCond.NendoFrom = kyokaiFrom2TextBox.Text.Trim();
            searchCond.RenbanFrom = kyokaiFrom3TextBox.Text.Trim();
            searchCond.HokenjoCdTo = kyokaiTo1TextBox.Text.Trim();
            searchCond.NendoTo = kyokaiTo2TextBox.Text.Trim();
            searchCond.RenbanTo = kyokaiTo3TextBox.Text.Trim();

            searchCond.KensaIraiSetchishaNm = settisyaTextBox.Text.Trim();
            searchCond.KensaIraiSetchibashoAdr = settiAdrTextBox.Text.Trim();

            alInput.SearchCond = searchCond;

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            //_kensaTorisageListDataTable = GetKensaTorisageList(alOutput.KensaTorisageListDataTable);
            _kensaTorisageListDataTable = alOutput.KensaTorisageListDataTable;

            srhListCountLabel.Text = _kensaTorisageListDataTable.Count + "件";

            if (alOutput.KensaTorisageListDataTable.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            //set data for display gridview
            kensaListDataGridView.DataSource = _kensaTorisageListDataTable;
        }
        #endregion

        #region IsValidDataSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidDataSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　HuyTX    新規作成
        /// 2014/10/20　HuyTX    Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidDataSearch()
        {
            StringBuilder errMsg = new StringBuilder();
            string kyokaiFrom = string.Concat(kyokaiFrom1TextBox.Text, kyokaiFrom2TextBox.Text, kyokaiFrom3TextBox.Text);
            string kyokaiTo = string.Concat(kyokaiTo1TextBox.Text, kyokaiTo2TextBox.Text, kyokaiTo3TextBox.Text);

            //協会No（開始） 
            if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) && kyokaiFrom1TextBox.Text.Trim().Length != 2)
            {
                errMsg.AppendLine("協会No（開始） (保健所コード)は2桁で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) && kyokaiFrom2TextBox.Text.Trim().Length != 2)
            {
                errMsg.AppendLine("協会No（開始） (年度)は2桁で入力して下さい。");   
            }

            if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) && kyokaiFrom3TextBox.Text.Trim().Length != 6)
            {
                errMsg.AppendLine("協会No（開始） (連番)は6桁で入力して下さい。");
            }

            //協会No（終了） 
            if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text) && kyokaiTo1TextBox.Text.Trim().Length != 2)
            {
                errMsg.AppendLine("協会No（終了） (保健所コード)は2桁で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text) && kyokaiTo2TextBox.Text.Trim().Length != 2)
            {
                errMsg.AppendLine("協会No（終了） (年度)は2桁で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text) && kyokaiTo3TextBox.Text.Trim().Length != 6)
            {
                errMsg.AppendLine("協会No（終了） (連番)は6桁で入力して下さい。");
            }

            //Relation check
            if (!Utility.Utility.IsValidKyokaiNo(kyokaiFrom1TextBox, kyokaiFrom2TextBox, kyokaiFrom3TextBox, kyokaiTo1TextBox, kyokaiTo2TextBox, kyokaiTo3TextBox))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査番号の大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            kensaListDataGridView.Columns[gesuiCol.Name].Visible = kensa11JoRadioButton.Checked;
            kensaListDataGridView.Columns[haishiCol.Name].Visible = kensa11JoRadioButton.Checked;
            kensaListDataGridView.Columns[gyohenCol.Name].Visible = kensa11JoRadioButton.Checked;
            kensaListDataGridView.Columns[hokaCol.Name].Visible = kensa11JoRadioButton.Checked;
            henkinIraiButton.Enabled = !kensa11JoRadioButton.Checked;

            kensaListDataGridView.DataSource = null;
            srhListCountLabel.Text = kensaListDataGridView.RowCount + "件";
        }
        #endregion

        #region IsShowWarning
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsShowWarning
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsShowWarning()
        {
            bool isWarning = false;
            int selectRow = 0;

            foreach (DataGridViewRow row in kensaListDataGridView.Rows)
            {
                if (row.Cells[selectCol.Name].Value != null && row.Cells[selectCol.Name].Value.ToString() == "1")
                {
                    selectRow++;
                }

                if ((row.Cells[gesuiCol.Name].Value != null && row.Cells[gesuiCol.Name].Value.ToString() == "1")
                    || (row.Cells[haishiCol.Name].Value != null && row.Cells[haishiCol.Name].Value.ToString() == "1")
                    || (row.Cells[gyohenCol.Name].Value != null && row.Cells[gyohenCol.Name].Value.ToString() == "1")
                    || (row.Cells[hokaCol.Name].Value != null && row.Cells[hokaCol.Name].Value.ToString() == "1")
                    )
                {
                    isWarning = true;
                }
            }

            if ((kensa7JoRadioButton.Checked && (selectRow >= 1 || isWarning)) || kensa11JoRadioButton.Checked && selectRow >= 1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region IsValidCheckBeforeSelect
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidCheckBeforeSelect
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidCheckBeforeSelect()
        {
            StringBuilder errMsg = new StringBuilder();

            int selectRow = 0;
            bool isValid = true;

            foreach (DataGridViewRow row in kensaListDataGridView.Rows)
            {
                if (row.Cells[selectCol.Name].Value != null && row.Cells[selectCol.Name].Value.ToString() == "1")
                {
                    selectRow++;
                    if (kensa11JoRadioButton.Checked
                        && (row.Cells[gesuiCol.Name].Value == null || row.Cells[gesuiCol.Name].Value.ToString() == "0")
                        && (row.Cells[haishiCol.Name].Value == null || row.Cells[haishiCol.Name].Value.ToString() == "0")
                        && (row.Cells[gyohenCol.Name].Value == null || row.Cells[gyohenCol.Name].Value.ToString() == "0")
                        && (row.Cells[hokaCol.Name].Value == null || row.Cells[hokaCol.Name].Value.ToString() == "0"))
                    {
                        isValid = false;
                    }
                }
            }

            //取下げ選択
            if (selectRow == 0)
            {
                errMsg.AppendLine("取下げ対象の検査が選択されていません。");
            }

            //11条検査取下げ理由選択
            if (!isValid)
            {
                errMsg.AppendLine("11条検査の取下げ理由が選択されていません。");
            }

            //throw error message
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region IsSelectedDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsSelectedDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsSelectedDgv()
        {
            foreach (DataGridViewRow row in kensaListDataGridView.Rows)
            {
                if (row.Cells[selectCol.Name].Value != null && row.Cells[selectCol.Name].Value.ToString() == "1")
                {
                    return true;
                }
            }

            return false;
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
        /// 2014/10/20  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            kyokaiFrom1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiFrom2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiFrom3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            kyokaiTo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiTo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiTo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            settisyaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            settiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            kensaListDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            kensaListDataGridView.SetStdControlDomain(hideKensaSyubetsuCol.Index, ZControlDomain.ZG_STD_NUM, 1);
            kensaListDataGridView.SetStdControlDomain(kensaSyubetsuCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            kensaListDataGridView.SetStdControlDomain(kyokaiNoCol.Index, ZControlDomain.ZG_STD_NAME, 12, DataGridViewContentAlignment.MiddleCenter);
            kensaListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            kensaListDataGridView.SetStdControlDomain(settiBasyoCol.Index, ZControlDomain.ZG_STD_NAME, 80);
            kensaListDataGridView.SetStdControlDomain(ninsoCol.Index, ZControlDomain.ZG_STD_NAME, 5, DataGridViewContentAlignment.MiddleCenter);
            kensaListDataGridView.SetStdControlDomain(syoriHoshikiCol.Index, ZControlDomain.ZG_STD_NAME, 14);
            kensaListDataGridView.SetStdControlDomain(jokasoNoCol.Index, ZControlDomain.ZG_STD_NAME, 11);

        }
        #endregion

        #region DEL_20141118
        //#region GetKensaTorisageList
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： GetKensaTorisageList
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="kensaTorisageListDT"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/20  HuyTX　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaIraiTblDataSet.KensaTorisageListDataTable GetKensaTorisageList(KensaIraiTblDataSet.KensaTorisageListDataTable kensaTorisageListDT)
        //{
        //    foreach (KensaIraiTblDataSet.KensaTorisageListRow row in kensaTorisageListDT.Rows)
        //    {
        //        row.KensaIraiNo = string.Concat(row.KensaIraiHokenjoCd, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy"), "-", row.KensaIraiRenban);
        //        row.JokasoNo = string.Concat(row.KensaIraiJokasoHokenjoCd, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiJokasoTorokuNendo, "yy"), "-", row.KensaIraiJokasoRenban);
        //    }

        //    return kensaTorisageListDT;
        //}
        //#endregion
        #endregion

        #endregion
    }

    #endregion
}
