using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using Zynas.Control.Common;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku;
using FukjBizSystem.Application.Boundary.JokasoDaichoKanri;
using System.Text.RegularExpressions;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanKensaYoteiNyuryokuForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JinendoGaikanKensaYoteiNyuryokuForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Update,
            Init,
        }

        #endregion

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
        /// 表示モード
        /// </summary>
        public DispMode _dispMode = DispMode.Init;

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime;

        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuDataTable
        /// </summary>
        private JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable _jinendoGaikanKensaYoteiNyuryokuDataTable = new JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable();

        /// <summary>
        /// _jokasoNo
        /// </summary>
        private string _jokasoNo = string.Empty;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JinendoGaikanKensaYoteiInputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JinendoGaikanKensaYoteiNyuryokuForm()
        {
            InitializeComponent();

            SetControlDomain();
        }
        #endregion

        #region イベント

        #region JinendoGaikanKensaYoteiNyuryokuForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanKensaYoteiNyuryokuForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanKensaYoteiNyuryokuForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();

                //// ADD HieuNH 2014/12/04 BEGIN
                this.yoteiListDataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(yoteiListDataGridView_EditingControlShowing);
                //// ADD HieuNH 2014/12/04 END
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

        #region yoteiListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoteiListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　HieuNH　　　新規作成
        /// 2014/12/09　HieuNH　　　Add new row when edit last row
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        void yoteiListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (yoteiListDataGridView.CurrentCell.ColumnIndex == jokasoCdCol.Index)
                {
                    TextBox tb = (TextBox)e.Control;
                    tb.TextChanged += new EventHandler(tb_TextChanged);
                    //// ADD HieuNH 2014/12/09 BEGIN
                    AddNewRow(yoteiListDataGridView.CurrentCell.RowIndex);
                    //// ADD HieuNH 2014/12/09 END
                }
                else if (yoteiListDataGridView.CurrentCell.ColumnIndex == yoteiTukiCol.Index)
                {
                    TextBox tb = (TextBox)e.Control;
                    tb.TextChanged -= new EventHandler(tb_TextChanged);
                    //// ADD HieuNH 2014/12/09 BEGIN
                    AddNewRow(yoteiListDataGridView.CurrentCell.RowIndex);
                    //// ADD HieuNH 2014/12/09 END
                }
                else
                {
                    TextBox tb = (TextBox)e.Control;
                    tb.TextChanged -= new EventHandler(tb_TextChanged);
                }
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

        #region tb_TextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoteiListDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　HieuNH　　　新規作成
        /// 2014/12/08　HieuNH　　　Check is in edit mode
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        void tb_TextChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //// MODIFY HieuNH 2014/12/08 BEGIN
                //if (yoteiListDataGridView.CurrentCell.ColumnIndex == jokasoCdCol.Index)
                if (yoteiListDataGridView.CurrentCell.ColumnIndex == jokasoCdCol.Index && yoteiListDataGridView.EditingControl != null)
                //// MODIFY HieuNH 2014/12/08 END
                {
                    TextBox tb = sender as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                        ClearRow(yoteiListDataGridView.CurrentRow.Index);
                }
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

        #region chikuCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chikuCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chikuCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region chikuCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chikuCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chikuCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region gyoshaCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region gyoshaCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region iraiNoFromHokenjoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromHokenjoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromHokenjoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region iraiNoFromNendoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromNendoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromNendoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region iraiNoFromRenbanTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromRenbanTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromRenbanTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region iraiNoToHokenjoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoToHokenjoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoToHokenjoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region iraiNoToNendoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoToNendoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoToNendoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region iraiNoToRenbanTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoToRenbanTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoToRenbanTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _jinendoGaikanKensaYoteiNyuryokuDataTable.Clear();

                AddNewRow(-1);

                SetControlData();
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
        /// 2014/11/17　HieuNH　　　新規作成
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

        #region JinendoGaikanKensaYoteiNyuryokuForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanKensaYoteiNyuryokuForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanKensaYoteiNyuryokuForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        sakuseiButton.Focus();
                        sakuseiButton.PerformClick();
                        break;
                    case Keys.F3:
                        torikeshiButton.Focus();
                        torikeshiButton.PerformClick();
                        break;
                    case Keys.F5:
                        printButton.Focus();
                        printButton.PerformClick();
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
                    case Keys.F9:
                        tyokusetsuButton.Focus();
                        tyokusetsuButton.PerformClick();
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// 2014/12/03　HieuNH　　　Display CloseConfirm Only in Update mode
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //// BEGIN HieuNH 2014/12/03 ADD
                if (_dispMode == DispMode.Update)
                {
                //// END HieuNH 2014/12/03 ADD
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧の内容で作成処理が行われていませんが、画面を閉じてよろしいですか？") == DialogResult.Yes)
                    {
                        Program.mForm.MovePrev();
                    }
                //// BEGIN HieuNH 2014/12/03 ADD
                }
                else
                    Program.mForm.MovePrev();
                //// END HieuNH 2014/12/03 ADD
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidInput()) return;

                DoSearch();

                InitScreen(DispMode.Update);
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

        #region tyokusetsuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tyokusetsuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tyokusetsuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(sakuseiNendoTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "作成年度を入力してください。");
                }
                else
                {
                    InitScreen(DispMode.Update);
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

        #region sakuseiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sakuseiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void sakuseiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!GridViewCheck())
                    return;

                if (!TorokuConfirm())
                    return;

                yoteiListDataGridView.EndEdit();

                ISakuseiBtnClickALInput alInput = new SakuseiBtnClickALInput();
                alInput.Nendo = sakuseiNendoTextBox.Text;
                alInput.JinendoGaikanKensaYoteiNyuryokuDataTable = _jinendoGaikanKensaYoteiNyuryokuDataTable;
                new SakuseiBtnClickApplicationLogic().Execute(alInput);

                InitScreen(DispMode.Init);
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
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torikeshiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (DeleteConfirm())
                {
                    InitScreen(DispMode.Init);
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

        #region printButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： printButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HieuNH　　　新規作成
        /// 2014/11/25　HieuNH　　　Add PrintConfirm
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                //// BEGIN HieuNH 2014/12/03 ADD
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "チェックリストを印刷します。よろしいですか？") == DialogResult.Yes)
                {
                //// END HieuNH 2014/12/03 ADD
                    Cursor.Current = Cursors.WaitCursor;

                    IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                    alInput.Nendo = sakuseiNendoTextBox.Text;
                    alInput.SystemDt = Common.Common.GetCurrentTimestamp();
                    alInput.JinendoGaikanKensaYoteiNyuryokuDataTable = _jinendoGaikanKensaYoteiNyuryokuDataTable;
                    new PrintBtnClickApplicationLogic().Execute(alInput);

                //// BEGIN HieuNH 2014/12/03 ADD
                }
                //// END HieuNH 2014/12/03 ADD

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
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuRow row in _jinendoGaikanKensaYoteiNyuryokuDataTable)
                {
                    if ((row.IsSakuseiNull() || row.Sakusei.Equals("0")) && !row.IsJokasoNoNull())
                        row.Sakusei = "0";
                }

                Common.Common.FlushGridviewDataToExcel(this.yoteiListDataGridView, "次年度外観検査予定入力一覧");
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
        /// 2014/11/18　HieuNH　　　新規作成
        /// 2014/12/08　HieuNH　　　Add new row when click button
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoteiListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0 && _dispMode == DispMode.Update)
                {
                    if (yoteiListDataGridView.Columns[e.ColumnIndex].Name.Equals(jokasoSrhCol.Name))
                    {
                        // Open JokasoMstSearchForm
                        JokasoDaichoSearchForm jFrm = new JokasoDaichoSearchForm();
                        jFrm.ShowDialog();

                        // User close the form without selection
                        if (jFrm.DialogResult != DialogResult.OK) return;

                        // No row was selected
                        if (jFrm._selectedRow == null) return;
                        // 浄化槽番号
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoCdCol.Name].Value = jFrm._selectedRow.JokasoHokenjoCd + "-" + Utility.DateUtility.ConvertToWareki(jFrm._selectedRow.JokasoTorokuNendo,"yy") + "-" +  jFrm._selectedRow.JokasoRenban;
                        // 浄化槽台帳保健所コード(隠し)
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoHokenjoCdCol.Name].Value = jFrm._selectedRow.JokasoHokenjoCd;
                        // 浄化槽台帳年度(隠し)
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoNendoCol.Name].Value = jFrm._selectedRow.JokasoTorokuNendo;
                        // 浄化槽台帳連番(隠し)
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoRenbanCol.Name].Value = jFrm._selectedRow.JokasoRenban;
                        // 設置者名
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[setchishaNmCol.Name].Value = jFrm._selectedRow.JokasoSetchishaNm;
                        // 前回検査日
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[zenkaiKensaDtCol.Name].Value = string.Empty;
                        // 人槽
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[ninsoCol.Name].Value = jFrm._selectedRow.IsJokasoShoriTaishoJininNull()? 0: jFrm._selectedRow.JokasoShoriTaishoJinin;
                        // 処理方式
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[shoriHoshikiCol.Name].Value = Boundary.Common.Common.GetConstNmByKbnValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_022, jFrm._selectedRow.JokasoShoriHosikiKbn);
                        // 業者CD
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[gyoshaCdCol.Name].Value = jFrm._selectedRow.JokasoItkatsuSeikyuGyoshaCd;

                        // 作成
                        yoteiListDataGridView.Rows[e.RowIndex].Cells[sakuseiCol.Name].Value = 0;

                        // 業者名
                        TextBox gyoshaCd = new TextBox();
                        gyoshaCd.Text = jFrm._selectedRow.JokasoItkatsuSeikyuGyoshaCd;
                        TextBox gyoshaNm = new TextBox();
                        Boundary.Common.Common.SetGyoshaNmByCd(jFrm._selectedRow.JokasoItkatsuSeikyuGyoshaCd, gyoshaCd, gyoshaNm);

                        yoteiListDataGridView.Rows[e.RowIndex].Cells[gyoshaNmCol.Name].Value = gyoshaNm.Text;

                        _jokasoNo = yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoCdCol.Name].Value.ToString();
                        SearchByJokasoNo(e.RowIndex);
                        //// ADD HieuNH 2014/12/08 BEGIN
                        AddNewRow(e.RowIndex);
                        //// ADD HieuNH 2014/12/08 END
                    }
                    else if (yoteiListDataGridView.Columns[e.ColumnIndex].Name.Equals(jokasoUpdCol.Name))
                    {
                        if (string.IsNullOrEmpty(yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoCdCol.Name].Value.ToString()))
                        {
                            MessageForm.Show2(MessageForm.DispModeType.Error, "浄化槽番号を入力してください。");
                            return;
                        }
                        else if (!CheckJokasoNoFormat1(yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoCdCol.Name].Value.ToString()) || !CheckJokasoNoFormat2(yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoCdCol.Name].Value.ToString()))
                        {
                            MessageForm.Show2(MessageForm.DispModeType.Error, "浄化槽番号を正しい形式で入力してください。");
                            return;
                        }
                        else
                        {
                            // 浄化槽台帳保健所コード(隠し)
                            string jokasoHokenjoCd = yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoHokenjoCdCol.Name].Value != null
                                ? yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoHokenjoCdCol.Name].Value.ToString() : string.Empty;
                            // 浄化槽台帳年度(隠し)
                            string jokasoNendo = yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoNendoCol.Name].Value != null
                                ? yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoNendoCol.Name].Value.ToString() : string.Empty;
                            // 浄化槽台帳連番(隠し)
                            string jokasoRenban = yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoRenbanCol.Name].Value != null
                                ? yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoRenbanCol.Name].Value.ToString() : string.Empty;

                            // 浄化槽台帳詳細
                            JokasoDaichoShosai frm = new JokasoDaichoShosai(jokasoHokenjoCd, jokasoNendo, jokasoRenban);
                            Program.mForm.MoveNext(frm);
                        }
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

        #region yoteiListDataGridView_CellValidating
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoteiListDataGridView_CellValidating
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　HieuNH　　　新規作成
        /// 2014/12/03　HieuNH　　　Don't set 00 when leave YoteiNengetsu = Empty
        /// 2014/12/04　HieuNH　　　Clear row when JokasoNo text change
        /// 2014/12/08　HieuNH　　　Check JokasoNo has changed or not, add new row when change data
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoteiListDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var senderGrid = (DataGridView)sender;

                if (e.RowIndex >= 0)
                {
                    if (yoteiListDataGridView.Columns[e.ColumnIndex].Name.Equals(jokasoCdCol.Name))
                    {
                        if (yoteiListDataGridView.EditingControl != null)
                        {
                            //// DELETE HieuNH 2014/12/04 BEGIN
                            //ClearRow(e.RowIndex);
                            //// DELETE HieuNH 2014/12/04 END

                            _jokasoNo = e.FormattedValue.ToString();

                            //// ADD HieuNH 2014/12/08 BEGIN
                            if (yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoCdCol.Index].Value != null && !_jokasoNo.Equals(yoteiListDataGridView.Rows[e.RowIndex].Cells[jokasoCdCol.Index].Value.ToString()))
                            {
                                //// ADD HieuNH 2014/12/08 END
                                SearchByJokasoNo(e.RowIndex);
                            //// ADD HieuNH 2014/12/08 BEGIN
                                //AddNewRow(e.RowIndex);
                            }
                            //// ADD HieuNH 2014/12/08 END
                        }
                    }

                    else if (yoteiListDataGridView.Columns[e.ColumnIndex].Name.Equals(yoteiTukiCol.Name))
                    {
                        if (yoteiListDataGridView.EditingControl != null)
                        //// BEGIN HieuNH 2014/12/03 ADD
                        {
                            if (string.IsNullOrEmpty(yoteiListDataGridView.EditingControl.Text))
                                yoteiListDataGridView.EditingControl.Text = string.Empty;
                            else
                        //// END HieuNH 2014/12/03 ADD
                                yoteiListDataGridView.EditingControl.Text = yoteiListDataGridView.EditingControl.Text.PadLeft(2, '0');
                        //// BEGIN HieuNH 2014/12/03 ADD
                            yoteiListDataGridView.EndEdit();
                            //// ADD HieuNH 2014/12/08 BEGIN
                            //AddNewRow(e.RowIndex);
                            //// ADD HieuNH 2014/12/08 END

                        }
                        //// END HieuNH 2014/12/03 ADD
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

        #region yoteiListDataGridView_CurrentCellDirtyStateChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoteiListDataGridView_CurrentCellDirtyStateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoteiListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (yoteiListDataGridView.CurrentCell is DataGridViewCheckBoxCell && yoteiListDataGridView.CurrentCell.ColumnIndex == sakuseiCol.Index)
                {
                    yoteiListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

        #region yoteiListDataGridView_CellEndEdit
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoteiListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoteiListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.ColumnIndex == sakuseiCol.Index)
                {
                    AddNewRow(e.RowIndex);
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            InitScreen(DispMode.Init);

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            yoteiListDataGridView.Rows.Clear();
            _jinendoGaikanKensaYoteiNyuryokuDataTable.Clear();
            yoteiListDataGridView.AutoGenerateColumns = false;
            AddNewRow(-1);
            yoteiListDataGridView.DataSource = _jinendoGaikanKensaYoteiNyuryokuDataTable;
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            bool disabled = true;

            // 編集不可モードの場合は、各コントロールを無効にする
            if (_dispMode == DispMode.Init)
            {
                disabled = false;
            }
            else if (_dispMode == DispMode.Update)
            {
                disabled = true;
            }

            {
                // 作成年度
                sakuseiNendoTextBox.ReadOnly = disabled;
                // 地区コード（開始）（終了）
                chikuCdFromTextBox.ReadOnly = disabled;
                chikuCdToTextBox.ReadOnly = disabled;
                // 業者コード（開始）（終了）
                gyoshaCdFromTextBox.ReadOnly = disabled;
                gyoshaCdToTextBox.ReadOnly = disabled;
                // 浄化槽番号（開始）（終了）
                iraiNoFromHokenjoTextBox.ReadOnly = disabled;
                iraiNoFromNendoFromTextBox.ReadOnly = disabled;
                iraiNoFromRenbanTextBox.ReadOnly = disabled;
                iraiNoToHokenjoTextBox.ReadOnly = disabled;
                iraiNoToNendoTextBox.ReadOnly = disabled;
                iraiNoToRenbanTextBox.ReadOnly = disabled;
                // 人槽区分
                ninsoKbn50ikaRadioButton.Enabled = !disabled;
                ninsoKbn51ijoRadioButton.Enabled = !disabled;
                ninsoKbnAllRadioButton.Enabled = !disabled;
                // 差分出力
                sabunAllRadioButton.Enabled = !disabled;
                sabunMisakuseiRadioButton.Enabled = !disabled;
                // 検索ボタン
                kensakuButton.Enabled = !disabled;
                // クリアボタン
                clearButton.Enabled = !disabled;
                // 直接入力ボタン
                tyokusetsuButton.Enabled = !disabled;
            }

            disabled = !disabled;
            {
                // 検査予定一覧

                // 作成ボタン
                sakuseiButton.Enabled = !disabled;
                // 取消ボタン
                torikeshiButton.Enabled = !disabled;
                // チェックリスト印刷ボタン
                printButton.Enabled = !disabled;
                // 一覧出力ボタン
                outputButton.Enabled = !disabled;
                // 検査予定一覧
                yoteiListDataGridView.ReadOnly = disabled;

                setchishaNmCol.ReadOnly = true;
                zenkaiKensaDtCol.ReadOnly = true;
                ninsoCol.ReadOnly = true;
                shoriHoshikiCol.ReadOnly = true;
                gyoshaCdCol.ReadOnly = true;
                gyoshaNmCol.ReadOnly = true;
                nendonaiUmuCol.ReadOnly = true;
            }
            // 閉じるボタン
            closeButton.Enabled = true;
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// 2014/11/17　HieuNH　　　Set Alignment for correcting export excel
        /// 2014/12/17　kiyokuni　　設計書にない左詰めを削除
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            sakuseiNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_NENDO);
            chikuCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_CHIKU_CD, 5);
            chikuCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_CHIKU_CD, 5);
            gyoshaCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4);
            gyoshaCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4);
            iraiNoFromHokenjoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoFromNendoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoFromRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, HorizontalAlignment.Left);
            iraiNoToHokenjoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoToNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoToRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, HorizontalAlignment.Left);

            // yoteiListDataGridView
            yoteiListDataGridView.SetStdControlDomain(jokasoCdCol.Index, ZControlDomain.ZG_STD_NUM, 11, DataGridViewContentAlignment.MiddleLeft);
            yoteiListDataGridView.SetStdControlDomain(yoteiTukiCol.Index, ZControlDomain.ZG_STD_NUM, 2);
            //DEL kiyokuni 2014/12/17
            ////// BEGIN HieuNH 2014/12/03 ADD
            //yoteiTukiCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ////// END HieuNH 2014/12/03 ADD
            yoteiListDataGridView.SetStdControlDomain(setchishaNmCol.Index, ZControlDomain.ZG_STD_NAME, 60, DataGridViewContentAlignment.MiddleLeft);
            yoteiListDataGridView.SetStdControlDomain(zenkaiKensaDtCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleLeft);
            yoteiListDataGridView.SetStdControlDomain(ninsoCol.Index, ZControlDomain.ZG_STD_NUM, 5);
            yoteiListDataGridView.SetStdControlDomain(shoriHoshikiCol.Index, ZControlDomain.ZG_STD_NAME, 4, DataGridViewContentAlignment.MiddleLeft);
            yoteiListDataGridView.SetStdControlDomain(gyoshaCdCol.Index, ZControlDomain.ZG_STD_CD, 4, DataGridViewContentAlignment.MiddleLeft);
            yoteiListDataGridView.SetStdControlDomain(gyoshaNmCol.Index, ZControlDomain.ZG_STD_NAME, 40, DataGridViewContentAlignment.MiddleLeft);
            yoteiListDataGridView.SetStdControlDomain(nendonaiUmuCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);
        }
        #endregion

        #region SetControlData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlData()
        {
            _currentDateTime = Common.Common.GetCurrentTimestamp();
            sakuseiNendoTextBox.Text = (Utility.DateUtility.GetNendo(_currentDateTime) +1).ToString();
            ninsoKbnAllRadioButton.Checked = true;
            sabunMisakuseiRadioButton.Checked = true;
            chikuCdFromTextBox.Text = chikuCdToTextBox.Text = string.Empty;
            gyoshaCdFromTextBox.Text = gyoshaCdToTextBox.Text = string.Empty;
            iraiNoFromHokenjoTextBox.Text = iraiNoFromNendoFromTextBox.Text = iraiNoFromRenbanTextBox.Text = string.Empty;
            iraiNoToHokenjoTextBox.Text = iraiNoToNendoTextBox.Text = iraiNoToRenbanTextBox.Text = string.Empty;

        }
        #endregion

        #region PaddingZeroForTextBoxLeave
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PaddingZeroForTextBoxLeave
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PaddingZeroForTextBoxLeave(Control.ZTextBox targetTextBox)
        {
            // Stop handle for empty target textbox
            if (string.IsNullOrEmpty(targetTextBox.Text)) return;

            // 地区コード（開始）
            if (targetTextBox.Name == chikuCdFromTextBox.Name)
            {
                chikuCdFromTextBox.Text = chikuCdFromTextBox.Text.PadLeft(chikuCdFromTextBox.MaxLength, '0');
                chikuCdToTextBox.Text = chikuCdFromTextBox.Text;
                return;
            }

            // 地区コード（終了）
            if (targetTextBox.Name == chikuCdToTextBox.Name)
            {
                chikuCdToTextBox.Text = chikuCdToTextBox.Text.PadLeft(chikuCdToTextBox.MaxLength, '0');
                return;
            }

            // 業者コード（開始）
            if (targetTextBox.Name == gyoshaCdFromTextBox.Name)
            {
                gyoshaCdFromTextBox.Text = gyoshaCdFromTextBox.Text.PadLeft(gyoshaCdFromTextBox.MaxLength, '0');
                gyoshaCdToTextBox.Text = gyoshaCdFromTextBox.Text;
                return;
            }

            // 業者コード（終了）
            if (targetTextBox.Name == gyoshaCdToTextBox.Name)
            {
                gyoshaCdToTextBox.Text = gyoshaCdToTextBox.Text.PadLeft(gyoshaCdToTextBox.MaxLength, '0');
                return;
            }

            // 浄化槽番号（開始） (保健所コード)
            if (targetTextBox.Name == iraiNoFromHokenjoTextBox.Name)
            {
                iraiNoFromHokenjoTextBox.Text = iraiNoFromHokenjoTextBox.Text.PadLeft(iraiNoFromHokenjoTextBox.MaxLength, '0');
                iraiNoToHokenjoTextBox.Text = iraiNoFromHokenjoTextBox.Text;
                return;
            }

            // 浄化槽番号（開始） (年度)
            if (targetTextBox.Name == iraiNoFromNendoFromTextBox.Name)
            {
                iraiNoFromNendoFromTextBox.Text = iraiNoFromNendoFromTextBox.Text.PadLeft(iraiNoFromNendoFromTextBox.MaxLength, '0');
                iraiNoToNendoTextBox.Text = iraiNoFromNendoFromTextBox.Text;
                return;
            }

            // 浄化槽番号（開始） (連番)
            if (targetTextBox.Name == iraiNoFromRenbanTextBox.Name)
            {
                iraiNoFromRenbanTextBox.Text = iraiNoFromRenbanTextBox.Text.PadLeft(iraiNoFromRenbanTextBox.MaxLength, '0');
                iraiNoToRenbanTextBox.Text = iraiNoFromRenbanTextBox.Text;
                return;
            }

            // 浄化槽番号（終了） (保健所コード)
            if (targetTextBox.Name == iraiNoToHokenjoTextBox.Name)
            {
                iraiNoToHokenjoTextBox.Text = iraiNoToHokenjoTextBox.Text.PadLeft(iraiNoToHokenjoTextBox.MaxLength, '0');
                return;
            }

            // 浄化槽番号（終了） (年度)
            if (targetTextBox.Name == iraiNoToNendoTextBox.Name)
            {
                iraiNoToNendoTextBox.Text = iraiNoToNendoTextBox.Text.PadLeft(iraiNoToNendoTextBox.MaxLength, '0');
                return;
            }

            // 浄化槽番号（終了） (連番)
            if (targetTextBox.Name == iraiNoToRenbanTextBox.Name)
            {
                iraiNoToRenbanTextBox.Text = iraiNoToRenbanTextBox.Text.PadLeft(iraiNoToRenbanTextBox.MaxLength, '0');
                return;
            }
        }
        #endregion

        #region IsValidInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// 2014/12/01　kiyokuni　　大小チェック修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidInput()
        {
            StringBuilder errMsg = new StringBuilder();
            //bool isValidIrai = true;

            #region UnitCheck

            if (string.IsNullOrEmpty(sakuseiNendoTextBox.Text))
            {
                errMsg.AppendLine("作成年度を入力してください。");
            }

            #endregion

            #region RelationCheck

            //// BEGIN HieuNH 2014/12/03 ADD
            if (!string.IsNullOrEmpty(chikuCdFromTextBox.Text) & !string.IsNullOrEmpty(chikuCdToTextBox.Text)
                && Convert.ToInt32(chikuCdFromTextBox.Text) > Convert.ToInt32(chikuCdToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。地区コードの大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) & !string.IsNullOrEmpty(gyoshaCdToTextBox.Text)
                && Convert.ToInt32(gyoshaCdFromTextBox.Text) > Convert.ToInt32(gyoshaCdToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
            }
            //// END HieuNH 2014/12/03 ADD

            //2014.12.03 mod kiyokuni ------ start
            //if (!string.IsNullOrEmpty(iraiNoFromHokenjoTextBox.Text) & !string.IsNullOrEmpty(iraiNoToHokenjoTextBox.Text)
            //    && Convert.ToInt32(iraiNoFromHokenjoTextBox.Text) > Convert.ToInt32(iraiNoToHokenjoTextBox.Text))
            //{
            //    isValidIrai = false;
            //}

            //if (!string.IsNullOrEmpty(iraiNoFromNendoFromTextBox.Text) & !string.IsNullOrEmpty(iraiNoToNendoTextBox.Text)
            //    && Convert.ToInt32(iraiNoFromNendoFromTextBox.Text) > Convert.ToInt32(iraiNoToNendoTextBox.Text))
            //{
            //    isValidIrai = false;
            //}

            //if (!string.IsNullOrEmpty(iraiNoFromRenbanTextBox.Text) & !string.IsNullOrEmpty(iraiNoToRenbanTextBox.Text)
            //    && Convert.ToInt32(iraiNoFromRenbanTextBox.Text) > Convert.ToInt32(iraiNoToRenbanTextBox.Text))
            //{
            //    isValidIrai = false;
            //}

            //if (!isValidIrai)
            if (!Utility.Utility.IsValidKyokaiNo(iraiNoFromHokenjoTextBox, iraiNoFromNendoFromTextBox, iraiNoFromRenbanTextBox, iraiNoToHokenjoTextBox, iraiNoToNendoTextBox, iraiNoToRenbanTextBox))
            {
                errMsg.AppendLine("範囲指定が正しくありません。浄化槽番号の大小関係を確認してください。");
            }
            //2014.12.03 mod kiyokuni ------ end

            //// BEGIN HieuNH 2014/12/03 DELETE
            //if (!string.IsNullOrEmpty(chikuCdFromTextBox.Text) & !string.IsNullOrEmpty(chikuCdToTextBox.Text)
            //    && Convert.ToInt32(chikuCdFromTextBox.Text) > Convert.ToInt32(chikuCdToTextBox.Text))
            //{
            //    errMsg.AppendLine("範囲指定が正しくありません。地区コードの大小関係を確認してください。");
            //}

            //if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) & !string.IsNullOrEmpty(gyoshaCdToTextBox.Text)
            //    && Convert.ToInt32(gyoshaCdFromTextBox.Text) > Convert.ToInt32(gyoshaCdToTextBox.Text))
            //{
            //    errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
            //}
            //// END HieuNH 2014/12/03 DELETE

            #endregion

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// 2014/12/08　HieuNH　　　Add new row after search
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            alInput.Nendo = sakuseiNendoTextBox.Text;
            alInput.ChikuCdFrom = chikuCdFromTextBox.Text;
            alInput.ChikuCdTo = chikuCdToTextBox.Text;
            alInput.GyoshaCdFrom = gyoshaCdFromTextBox.Text;
            alInput.GyoshaCdTo = gyoshaCdToTextBox.Text;
            alInput.IraiMakeKbn = sabunMisakuseiRadioButton.Checked ? 0 : 1;
            alInput.IraiNoFromHokenjo = iraiNoFromHokenjoTextBox.Text;
            alInput.IraiNoFromNendo = string.IsNullOrEmpty(iraiNoFromNendoFromTextBox.Text)?null: Utility.DateUtility.ConvertFromWareki(iraiNoFromNendoFromTextBox.Text, "yyyy");
            alInput.IraiNoFromRenban = iraiNoFromRenbanTextBox.Text;
            alInput.IraiNoToHokenjo = iraiNoToHokenjoTextBox.Text;
            alInput.IraiNoToNendo = string.IsNullOrEmpty(iraiNoToNendoTextBox.Text) ? null : Utility.DateUtility.ConvertFromWareki(iraiNoToNendoTextBox.Text, "yyyy");
            alInput.IraiNoToRenban = iraiNoToRenbanTextBox.Text;
            if (ninsoKbn50ikaRadioButton.Checked)
                alInput.NinsoKbn = 1;
            else if (ninsoKbn51ijoRadioButton.Checked)
                alInput.NinsoKbn = 2;
            else
                alInput.NinsoKbn = 0;

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            srhListCountLabel.Text = alOutput.JinendoGaikanKensaYoteiNyuryokuDataTable.Count + "件";

            //set data for display gridview
            _jinendoGaikanKensaYoteiNyuryokuDataTable.Clear();
            _jinendoGaikanKensaYoteiNyuryokuDataTable.Merge(alOutput.JinendoGaikanKensaYoteiNyuryokuDataTable);
            yoteiListDataGridView.DataSource = _jinendoGaikanKensaYoteiNyuryokuDataTable;

            //// ADD HieuNH 2014/12/08 BEGIN
            AddNewRow(_jinendoGaikanKensaYoteiNyuryokuDataTable.Count - 1);
            //// ADD HieuNH 2014/12/08 END

            if (_jinendoGaikanKensaYoteiNyuryokuDataTable.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
        }
        #endregion

        #region CheckJokasoNoFormat1
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckJokasoNoFormat1
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckJokasoNoFormat1(string target)
        {
            if (!target.Contains("-"))
            {
                var r = new Regex(@"^[0-9]{9}$");
                return r.IsMatch(target);
            }
            else
                return true;
        }
        #endregion

        #region CheckJokasoNoFormat2
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckJokasoNoFormat2
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckJokasoNoFormat2(string target)
        {
            if (target.Contains("-"))
            {
                var r = new Regex(@"^[0-9]{1,2}-[0-9]{1,2}-[0-9]{1,5}$");
                bool res = r.IsMatch(target);
                return res;
            }
            else
                return true;
        }
        #endregion

        #region JokasoNoConfirm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckJokasoNoFormat2
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// 2014/12/01　HieuNH　　　v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoNoConfirm(IJokasoCdCellLeaveALOutput alOutput)
        {
            StringBuilder infoMsg = new StringBuilder();

            if (!alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].IsJokasoShoriTaishoJininNull()
                && !alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].IsJokasoGaikanTikuwariKbnNull())
            {
                if (alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].JokasoShoriTaishoJinin <= 50 && !alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].JokasoGaikanTikuwariKbn.Equals(Boundary.Common.Common.GaikanKensaChikuHantei(sakuseiNendoTextBox.Text)))
                {
                    infoMsg.AppendLine("対象浄化槽は外観検査年度ではありません。");
                }
            }

            // ADD TTM-HieuNH 20141201 BEGIN
            if (!alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].IsJokasoJotaiKbnNull() && "2".Equals(alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].JokasoJotaiKbn))
            {
                infoMsg.AppendLine("対象浄化槽は廃止されています。");
            }
            // ADD TTM-HieuNH 20141201 END

            if (alOutput.KensaIraiTblDataTable.Count > 0)
            {
                infoMsg.AppendLine("年度内に既に検査依頼が作成されています。");
            }

            if(!string.IsNullOrEmpty(infoMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, infoMsg.ToString());
                return;
            }
        }
        #endregion

        #region SearchByJokasoNo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SearchByJokasoNo
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SearchByJokasoNo(int rowIndex)
        {
            if (!string.IsNullOrEmpty(_jokasoNo))
            {
                if (!CheckJokasoNoFormat1(_jokasoNo) || !CheckJokasoNoFormat2(_jokasoNo))
                {
                    if (yoteiListDataGridView.EditingControl != null)
                        yoteiListDataGridView.EditingControl.Text = string.Empty;
                    else
                        yoteiListDataGridView.Rows[rowIndex].Cells[jokasoCdCol.Name].Value = string.Empty;

                    MessageForm.Show2(MessageForm.DispModeType.Error, "浄化槽番号を正しい形式で入力してください。");
                    return;
                }
                else
                {
                    // Format JokasoNo
                    string hokenjo, nendo, renban;

                    if (_jokasoNo.Contains("-"))
                    {
                        hokenjo = _jokasoNo.Split('-')[0];
                        hokenjo = hokenjo.PadLeft(2, '0');
                        nendo = _jokasoNo.Split('-')[1];
                        nendo = nendo.PadLeft(2, '0');
                        renban = _jokasoNo.Split('-')[2];
                        renban = renban.PadLeft(5, '0');
                    }
                    else
                    {
                        hokenjo = _jokasoNo.Substring(0, 2);
                        nendo = _jokasoNo.Substring(2, 2);
                        renban = _jokasoNo.Substring(4, 5);
                    }

                    if (yoteiListDataGridView.EditingControl != null)
                        yoteiListDataGridView.EditingControl.Text = hokenjo + "-" + nendo + "-" + renban;
                    else
                        yoteiListDataGridView.Rows[rowIndex].Cells[jokasoCdCol.Name].Value = hokenjo + "-" + nendo + "-" + renban;

                    IJokasoCdCellLeaveALInput alInput = new JokasoCdCellLeaveALInput();
                    alInput.HokenjoCd = hokenjo;
                    alInput.TorokuNendo = Utility.DateUtility.ConvertFromWareki(nendo, "yyyy");
                    alInput.Renban = renban;
                    alInput.Nendo = sakuseiNendoTextBox.Text;
                    IJokasoCdCellLeaveALOutput alOutput = new JokasoCdCellLeaveApplicationLogic().Execute(alInput);

                    if (alOutput.JinendoGaikanYoteiOutputTbl.Count > 0)
                    {
                        yoteiListDataGridView.Rows[rowIndex].Cells[updateDtCol.Name].Value = alOutput.JinendoGaikanYoteiOutputTbl[0].UpdateDt;
                    }

                    if (alOutput.JokasoDaichoGyoshaMstSearchDataTable.Count > 0)
                    {
                        yoteiListDataGridView.Rows[rowIndex].Cells[jokasoNendoCol.Name].Value = Utility.DateUtility.ConvertFromWareki(nendo, "yyyy");
                        yoteiListDataGridView.Rows[rowIndex].Cells[jokasoHokenjoCdCol.Name].Value = hokenjo;
                        yoteiListDataGridView.Rows[rowIndex].Cells[jokasoRenbanCol.Name].Value = renban;

                        // 設置者名
                        yoteiListDataGridView.Rows[rowIndex].Cells[setchishaNmCol.Name].Value = alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].JokasoSetchishaNm;
                        // 前回検査日
                        yoteiListDataGridView.Rows[rowIndex].Cells[zenkaiKensaDtCol.Name].Value = string.Empty;
                        // 人槽
                        yoteiListDataGridView.Rows[rowIndex].Cells[ninsoCol.Name].Value = alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].IsJokasoShoriTaishoJininNull() ? 0 : alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].JokasoShoriTaishoJinin;
                        // 処理方式
                        yoteiListDataGridView.Rows[rowIndex].Cells[shoriHoshikiCol.Name].Value = alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].IsConstNmNull() ? "" : alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].ConstNm;
                        // 業者CD
                        yoteiListDataGridView.Rows[rowIndex].Cells[gyoshaCdCol.Name].Value = alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].IsJokasoItkatsuSeikyuGyoshaCdNull() ? string.Empty : alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].JokasoItkatsuSeikyuGyoshaCd;
                        // 業者名
                        yoteiListDataGridView.Rows[rowIndex].Cells[gyoshaNmCol.Name].Value = alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].IsGyoshaNmNull() ? "" : alOutput.JokasoDaichoGyoshaMstSearchDataTable[0].GyoshaNm;

                        // 作成
                        yoteiListDataGridView.Rows[rowIndex].Cells[sakuseiCol.Name].Value = 0;

                        if (alOutput.KensaIraiTblDataTable.Count > 0)
                        {
                            // 年度内有無
                            yoteiListDataGridView.Rows[rowIndex].Cells[nendonaiUmuCol.Name].Value = "有";
                        }

                        JokasoNoConfirm(alOutput);
                    }
                    else
                    {
                        if (yoteiListDataGridView.EditingControl != null)
                            yoteiListDataGridView.EditingControl.Text = string.Empty;
                        else
                            yoteiListDataGridView.Rows[rowIndex].Cells[jokasoCdCol.Name].Value = string.Empty;

                        yoteiListDataGridView.EndEdit();
                        MessageForm.Show2(MessageForm.DispModeType.Error, "浄化槽番号のデータは存在しません。");
                        return;
                    }

                    yoteiListDataGridView.EndEdit();
                }
            }
        }
        #endregion

        #region GridViewCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GridViewCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　HieuNH　　　新規作成
        /// 2014/12/03　HieuNH　　　Not error when set YoteiNengetsu = Empty
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool GridViewCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            StringBuilder errorCode = new StringBuilder("1000");

            foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value != null && chk.TrueValue.ToString().Equals(chk.Value.ToString()))
                {
                    errorCode[0] = '0';

                    if (yoteiListDataGridView.Rows[row.Index].Cells[jokasoCdCol.Name].Value == null || string.IsNullOrEmpty(yoteiListDataGridView.Rows[row.Index].Cells[jokasoCdCol.Name].Value.ToString()))
                    {
                        errorCode[1] = '1';
                    }
                    if ((yoteiListDataGridView.Rows[row.Index].Cells[zenkaiKensaDtCol.Name].Value == null || string.IsNullOrEmpty(yoteiListDataGridView.Rows[row.Index].Cells[zenkaiKensaDtCol.Name].Value.ToString())) && (yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value == null || string.IsNullOrEmpty(yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value.ToString())))
                    {
                        errorCode[2] = '1';
                    }

                    //// BEGIN HieuNH 2014/12/03 MODIFY
                    //if (yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value == null || string.IsNullOrEmpty(yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value.ToString()) || (int.Parse(yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value.ToString()) < 1 || int.Parse(yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value.ToString()) > 12))
                    if ((yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value != null && !string.IsNullOrEmpty(yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value.ToString())) && (int.Parse(yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value.ToString()) < 1 || int.Parse(yoteiListDataGridView.Rows[row.Index].Cells[yoteiTukiCol.Name].Value.ToString()) > 12))
                    //// END HieuNH 2014/12/03 MODIFY
                    {
                        errorCode[3] = '1';
                    }
                }
            }

            if (errorCode[0].Equals('1'))
               errMsg.AppendLine("作成対象が選択されていません。");
            if (errorCode[1].Equals('1'))
                errMsg.AppendLine("浄化槽番号を入力してださい。");
            if (errorCode[2].Equals('1'))
            {
                errMsg.AppendLine("予定月を入力してださい。");
            }
            else
            {
                if (errorCode[3].Equals('1'))
                    errMsg.AppendLine("予定月が範囲外です。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region TorokuConfirm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： TorokuConfirm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool TorokuConfirm()
        {
            bool isValid = true;

            foreach (DataGridViewRow row in yoteiListDataGridView.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value != null && chk.TrueValue.ToString().Equals(chk.Value.ToString()))
                {
                    if (yoteiListDataGridView.Rows[row.Index].Cells[nendonaiUmuCol.Name].Value != null && "有".Equals(yoteiListDataGridView.Rows[row.Index].Cells[nendonaiUmuCol.Name].Value.ToString()))
                    {
                        isValid = false;
                    }
                }
            }

            if (!isValid)
            {
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "既に年度内に対象浄化槽の依頼が作成されているものがあります。\n検査依頼データを作成しますか？") == System.Windows.Forms.DialogResult.No)
                    return false;
            }
            else
            {
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査依頼データを作成しますか？") == System.Windows.Forms.DialogResult.No)
                    return false;
            }

            return true;
        }
        #endregion

        #region InitScreen
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitScreen
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InitScreen(DispMode mode)
        {
            _dispMode = mode;

            if (_dispMode == DispMode.Init)
            {
                _jinendoGaikanKensaYoteiNyuryokuDataTable.Clear();

                AddNewRow(-1);

                SetControlData();
            }

            SetDisplayControl();
        }
        #endregion

        #region DeleteConfirm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteConfirm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DeleteConfirm()
        {
            if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧の内容で作成処理が行われていませんが、全てクリアしてよろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                return true;
            else
                return false;
        }
        #endregion

        #region ClearRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearRow(int rowIndex)
        {
            // 設置者名
            yoteiListDataGridView.Rows[rowIndex].Cells[setchishaNmCol.Name].Value = string.Empty;
            // 前回検査日
            yoteiListDataGridView.Rows[rowIndex].Cells[zenkaiKensaDtCol.Name].Value = string.Empty;
            // 人槽
            yoteiListDataGridView.Rows[rowIndex].Cells[ninsoCol.Name].Value = DBNull.Value;
            // 処理方式
            yoteiListDataGridView.Rows[rowIndex].Cells[shoriHoshikiCol.Name].Value = string.Empty;
            // 業者CD
            yoteiListDataGridView.Rows[rowIndex].Cells[gyoshaCdCol.Name].Value = string.Empty;
            // 業者名
            yoteiListDataGridView.Rows[rowIndex].Cells[gyoshaNmCol.Name].Value = string.Empty;
            // 年度内有無
            yoteiListDataGridView.Rows[rowIndex].Cells[nendonaiUmuCol.Name].Value = string.Empty;
        }
        #endregion

        #region AddNewRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddNewRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void AddNewRow(int rowIndex)
        {
            // Add a new row at the bottom of dgv for next input
            if (rowIndex == yoteiListDataGridView.Rows.Count - 1)
            {
                _jinendoGaikanKensaYoteiNyuryokuDataTable.AddJinendoGaikanKensaYoteiNyuryokuRow(_jinendoGaikanKensaYoteiNyuryokuDataTable.NewJinendoGaikanKensaYoteiNyuryokuRow());
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
