using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.NameMstEditList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： NameMstEditListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class NameMstEditListForm : FukjBaseForm
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
        /// Edit Flag
        /// </summary>
        private bool editFlg = false;

        /// <summary>
        /// Loaded Form
        /// </summary>
        private bool isLoad = false;

        /// <summary>
        /// Login user
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// Terminal Name
        /// </summary>
        private string terminalName = Dns.GetHostName();
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： NameMstEditListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public NameMstEditListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region NameMstEditListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NameMstEditListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NameMstEditListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();

                isLoad = true;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 画面を終了（前画面に戻る）
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
        /// 2014/06/25  DatNT　　 新規作成
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
                if (this._searchShowFlg) // 検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else //検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.nameListPanel,
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
        /// 2014/06/25  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 名称区分 3
                nameKbnComboBox.SelectedIndex = -1;

                // 名称コード（開始）4
                nameCdFromTextBox.Text = string.Empty;

                // 名称コード（終了）5
                nameCdToTextBox.Text = string.Empty;

                // 名称 6
                nameTextBox.Text = string.Empty;

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
        /// 2014/06/25  DatNT　　 新規作成
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

                editFlg = false;
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
        /// 2014/06/25  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void koshinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                nameListDataGridView.EndEdit();

                if (!editFlg) { return; }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "名称一覧の編集内容を登録します。よろしいですか？") 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!InputCheck()) { return; }

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
        /// 2014/06/25  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nameListDataGridView.RowCount == 0 || editFlg) { return; }

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "名称マスタ一覧";
                OutputExcel(this.nameListDataGridView, outputFilename);
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (editFlg)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                        == System.Windows.Forms.DialogResult.Yes)
                    {
                        Program.mForm.MovePrev();
                    }
                }
                else
                {
                    Program.mForm.MovePrev();
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

        #region NameMstEditListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NameMstEditListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　 新規作成
        /// 2015/01/16  Mehara      v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NameMstEditListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        koshinButton.Focus();
                        koshinButton.PerformClick();
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
                        tojiruButton.Focus();
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

        #region nameListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nameListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nameListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewColumn col in nameListDataGridView.Columns)
                {
                    if (col.Name == "NameKbnCol")
                    {
                        col.DataPropertyName = "NameKbnNew";
                    }
                }

                for (int i = 0; i < nameListDataGridView.RowCount - 1; i++)
                {
                    if (nameListDataGridView.Rows[i].Cells["NameCdCol"].Value.ToString() == nameListDataGridView.Rows[i].Cells["NameCdOldCol"].Value.ToString()
                        || nameListDataGridView.Rows[i].Cells["DeleteFlgCol"].Value.ToString() == nameListDataGridView.Rows[i].Cells["DeleteFlgOldCol"].Value.ToString()
                        || nameListDataGridView.Rows[i].Cells["NameCol"].Value.ToString() == nameListDataGridView.Rows[i].Cells["NameOldCol"].Value.ToString())
                    {
                        outputButton.Enabled = true;
                    }
                }

                List<string> listKey = GetListDuplicate();
                ChangeBackground(listKey);
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

        #region nameListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nameListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nameListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (isLoad)
                {
                    editFlg = true;

                    outputButton.Enabled = false;

                    DataGridViewColumn col = nameListDataGridView.Columns[nameListDataGridView.CurrentCell.ColumnIndex];

                    if (col.Name == "NameCdCol")
                    {
                        int number;

                        if (!Int32.TryParse(nameListDataGridView.CurrentRow.Cells[col.Name].Value.ToString(), out number))
                        {
                            nameListDataGridView.CurrentRow.Cells[col.Name].Value = string.Empty;
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

        #region nameListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nameListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nameListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DataGridViewColumn col = nameListDataGridView.Columns[nameListDataGridView.CurrentCell.ColumnIndex];

                if (col.Name == "NameCdCol")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(ControlKeyPress);
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

        #region nameListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nameListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nameListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                return;
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

        #region NameCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NameCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/16  Mehara　   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nameCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(nameCdFromTextBox.Text))
                {
                    nameCdFromTextBox.Text = nameCdFromTextBox.Text.PadLeft(3, '0');

                    nameCdToTextBox.Text = nameCdFromTextBox.Text;
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

        #region NameCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NameCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/16  Mehara　   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nameCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(nameCdToTextBox.Text))
                {
                    nameCdToTextBox.Text = nameCdToTextBox.Text.PadLeft(3, '0');
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this.nameMstNameKbn000TableAdapter.Fill(this.nameMstDataSet.NameMstNameKbn000);

            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.NameKbn             = Constants.NameKbnConstant.NAME_KBN_000;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            Utility.Utility.SetComboBoxList(nameKbnComboBox, alOutput.NameMstDT, "NAME", "NAMECD", true);

            NameMstUpdateDataSet.NameMstUpdateDataTable dataTable = CreateNameMstUpdateDT(alOutput.NameMstKensakuDT);

            // Display data
            nameListDataGridView.DataSource = dataTable;

            DispData(alOutput.NameMstKensakuDT);

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.nameListPanel.Top;
            this._defaultListPanelHeight = this.nameListPanel.Height;
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(ISearchBtnClickALInput alInput)
        {
            // 名称区分 3
            if (nameKbnComboBox.SelectedIndex != -1)
            {
                alInput.NameKbn = nameKbnComboBox.SelectedValue.ToString();
            }

            // 名称コード（開始）4
            if (!String.IsNullOrEmpty(nameCdFromTextBox.Text.Trim()))
            {
                alInput.NameCdFrom = nameCdFromTextBox.Text.Trim();
            }

            // 名称コード（終了）5
            if (!String.IsNullOrEmpty(nameCdToTextBox.Text.Trim()))
            {
                alInput.NameCdTo = nameCdToTextBox.Text.Trim();
            }

            // 名称 6
            if(!String.IsNullOrEmpty(nameTextBox.Text.Trim()))
            {
                alInput.Name = nameTextBox.Text.Trim();
            }
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            ISearchBtnClickALInput alInput = new SearchBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.NameMstKensakuDT != null && alOutput.NameMstKensakuDT.Count > 0)
            {
                NameMstUpdateDataSet.NameMstUpdateDataTable dataTable = CreateNameMstUpdateDT(alOutput.NameMstKensakuDT);

                // Display data
                nameListDataGridView.DataSource = dataTable;
            }
            else
            {
                DataTable d = (DataTable)nameListDataGridView.DataSource;

                NameMstUpdateDataSet.NameMstUpdateDataTable dataTable = new NameMstUpdateDataSet.NameMstUpdateDataTable();

                nameListDataGridView.DataSource = dataTable;
            }

            DispData(alOutput.NameMstKensakuDT);
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 名称コード（開始）4
            if (!string.IsNullOrEmpty(nameCdFromTextBox.Text) && nameCdFromTextBox.Text.Trim().Length != 3)
            {
                errMess.Append("名称コード（開始）は3桁で入力して下さい。\r\n");
            }

            // 名称コード（終了）5
            if (!string.IsNullOrEmpty(nameCdToTextBox.Text) && nameCdToTextBox.Text.Trim().Length != 3)
            {
                errMess.Append("名称コード（終了）は3桁で入力して下さい。");
            }

            if (string.IsNullOrEmpty(errMess.ToString()))
            {
                // 「名称コード（開始）　>　名称コード（終了）」の場合 (4) > (5)
                if (!String.IsNullOrEmpty(nameCdFromTextBox.Text.Trim())
                    && !String.IsNullOrEmpty(nameCdToTextBox.Text.Trim()))
                {
                    if (Convert.ToInt32(nameCdToTextBox.Text.Trim()) < Convert.ToInt32(nameCdFromTextBox.Text.Trim()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。名称コードの大小関係を確認してください。\r\n");
                        return false;
                    }
                }
            }

            if(!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region DispData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DispData(NameMstDataSet.NameMstKensakuDataTable dataTable)
        {
            for (int i = 0; i < nameListDataGridView.RowCount - 1; i++)
            {
                nameListDataGridView.Rows[i].Cells["NameKbnCol"].Value = dataTable[i].NameKbn;
            }

            foreach (DataGridViewColumn col in nameListDataGridView.Columns)
            {
                if (col.Name == "NameKbnCol" || col.Name == "NameCdCol" || col.Name == "NameCol" || col.Name == "DeleteFlgCol")
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }

            if (dataTable == null || dataTable.Count == 0)
            {
                nameListCountLabel.Text = "0件";

                // 一覧出力ボタン
                outputButton.Enabled = false;

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                nameListCountLabel.Text = dataTable.Count.ToString() + "件";

                // 一覧出力ボタン
                outputButton.Enabled = true;
            }
        }
        #endregion

        #region InputCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InputCheck
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool InputCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // list key duplicate
            List<string> listKey = new List<string>();

            string emptyNameKbn = string.Empty;
            string emptyNameCd = string.Empty;
            string emptyName = string.Empty;
            string invalidNameCd = string.Empty;
            string invalidName = string.Empty;

            for(int i = 0; i <nameListDataGridView.RowCount - 1 ; i++)
            {
                DataGridViewRow row = nameListDataGridView.Rows[i];

                if ((row.Cells["NameKbnCol"].Value == null || string.IsNullOrEmpty(row.Cells["NameKbnCol"].Value.ToString()))
                    && (row.Cells["NameCdCol"].Value == null || string.IsNullOrEmpty(row.Cells["NameCdCol"].Value.ToString()))
                    && (row.Cells["NameCol"].Value == null || string.IsNullOrEmpty(row.Cells["NameCol"].Value.ToString()))
                    && (row.Cells["DeleteFlgCol"].Value == null
                        || row.Cells["DeleteFlgCol"].Value.ToString() == "0"
                        || (string.IsNullOrEmpty(row.Cells["DeleteFlgCol"].Value.ToString()))
                        )
                    )
                {
                    // don't check
                }
                else
                {
                    // 名称区分 13
                    if (row.Cells["NameKbnCol"].Value == null || string.IsNullOrEmpty(row.Cells["NameKbnCol"].Value.ToString()))
                    {
                        emptyNameKbn += (i + 1).ToString() + ", ";
                    }

                    // DEL 20140724 START ZynasSou
                    //// 名称コード 14
                    //if (string.IsNullOrEmpty(row.Cells["NameCdCol"].Value.ToString()))
                    //{
                    //    emptyNameCd += (i + 1).ToString() + ", ";
                    //}
                    //else
                    //{
                    //    if (row.Cells["NameCdCol"].Value.ToString().Length != 3)
                    //    {
                    //        invalidNameCd += (i + 1).ToString() + ", ";
                    //    }
                    //}
                    // DEL 20140724 END ZynasSou

                    // 名称 15
                    if (string.IsNullOrEmpty(row.Cells["NameCol"].Value.ToString()))
                    {
                        emptyName += (i + 1).ToString() + ", ";
                    }
                    else
                    {
                        if (row.Cells["NameCol"].Value.ToString().Length > 60)
                        {
                            invalidName += (i + 1).ToString() + ", ";
                        }
                    }
                }
            }

            //名称区分(13)
            if (!string.IsNullOrEmpty(emptyNameKbn))
            {
                errMess.Append("行 : " + emptyNameKbn.Remove(emptyNameKbn.Length - 2) + " : 必須項目：名称区分が選択されていません。\r\n");
            }

            // DEL 20140724 START ZynasSou
            ////名称コード(14)
            //if (!string.IsNullOrEmpty(emptyNameCd))
            //{
            //    errMess.Append("行 : " + emptyNameCd.Remove(emptyNameCd.Length - 2) + " : 必須項目：名称コードが入力されていません。\r\n");
            //}
            //else if (!string.IsNullOrEmpty(invalidNameCd))
            //{
            //    errMess.Append("行 : " + invalidNameCd.Remove(invalidNameCd.Length - 2) + " : 名称コードは3桁で入力して下さい。\r\n");
            //}
            // DEL 20140724 END ZynasSou

            //名称(15)
            if(!string.IsNullOrEmpty(emptyName))
            {
                errMess.Append("行 : " + emptyName.Remove(emptyName.Length - 2) + " : 必須項目：名称が入力されていません。\r\n");
            }
            else if (!string.IsNullOrEmpty(invalidName))
            {
                errMess.Append("行 : " + invalidName.Remove(invalidName.Length - 2) + " : 名称は60文字以下で入力して下さい。\r\n");
            }

            listKey = GetListDuplicate();
            ChangeBackground(listKey);

            if (listKey.Count > 0)
            {
                errMess.Append("名称区分＆名称コードが重複しています。\r\n");
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion
        
        #region ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewColumn col = nameListDataGridView.Columns[nameListDataGridView.CurrentCell.ColumnIndex];

            if (col.Name == "NameCdCol")
            {
                if (!IsOKForDecimalTextBox(e.KeyChar, sender as TextBox))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
        #endregion

        #region IsOKForDecimalTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsOKForDecimalTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="textBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/03/26　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsOKForDecimalTextBox(char character, TextBox textBox)
        {
            // Only allow control characters, digits, plus and minus signs.
            // Only allow ONE plus sign.
            // Only allow ONE minus sign.
            // Only allow the plus or minus sign as the FIRST character.
            // Only allow ONE decimal point.
            // Do NOT allow decimal point or digits BEFORE any plus or minus sign.

            if (
                !char.IsControl(character)
                && !char.IsDigit(character)
                && (character != '.')
                && (character != '-')
                && (character != '+')
            )
            {
                // Then it is NOT a character we want allowed in the text box.
                return false;
            }

            // Only allow one decimal point.
            if (character == '.'
                && textBox.Text.IndexOf('.') > -1)
            {
                // Then there is already a decimal point in the text box.
                return false;
            }

            // Only allow one minus sign.
            if (character == '-'
                && textBox.Text.IndexOf('-') > -1)
            {
                // Then there is already a minus sign in the text box.
                return false;
            }

            // Only allow one plus sign.
            if (character == '+'
                && textBox.Text.IndexOf('+') > -1)
            {
                // Then there is already a plus sign in the text box.
                return false;
            }

            // Only allow one plus sign OR minus sign, but not both.
            if (
                (
                    (character == '-')
                    || (character == '+')
                )
                &&
                (
                    (textBox.Text.IndexOf('-') > -1)
                    ||
                    (textBox.Text.IndexOf('+') > -1)
                )
                )
            {
                // Then the user is trying to enter a plus or minus sign and
                // there is ALREADY a plus or minus sign in the text box.
                return false;
            }

            // Only allow a minus or plus sign at the first character position.
            if (
                (
                    (character == '-')
                    || (character == '+')
                )
                && textBox.SelectionStart != 0
                )
            {
                // Then the user is trying to enter a minus or plus sign at some position 
                // OTHER than the first character position in the text box.
                return false;
            }

            // Only allow digits and decimal point AFTER any existing plus or minus sign
            if (
                    (
                // Is digit or decimal point
                        char.IsDigit(character)
                        ||
                        (character == '.')
                    )
                    &&
                    (
                // A plus or minus sign EXISTS
                        (textBox.Text.IndexOf('-') > -1)
                        ||
                        (textBox.Text.IndexOf('+') > -1)
                    )
                    &&
                // Attempting to put the character at the beginning of the field.
                        textBox.SelectionStart == 0
                )
            {
                // Then the user is trying to enter a digit or decimal point in front of a minus or plus sign.
                return false;
            }

            // Otherwise the character is perfectly fine for a decimal value and the character
            // may indeed be placed at the current insertion position.
            return true;
        }
        #endregion

        #region CreateNameMstUpdateDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNameMstUpdateDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensakuDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NameMstUpdateDataSet.NameMstUpdateDataTable CreateNameMstUpdateDT(NameMstDataSet.NameMstKensakuDataTable kensakuDT)
        {
            NameMstUpdateDataSet.NameMstUpdateDataTable dataTable = new NameMstUpdateDataSet.NameMstUpdateDataTable();

            foreach (NameMstDataSet.NameMstKensakuRow row in kensakuDT)
            {
                NameMstUpdateDataSet.NameMstUpdateRow nameRow = dataTable.NewNameMstUpdateRow();

                nameRow.NameCdNew = row.NameCd;

                nameRow.NameKbnNew = row.NameKbn;

                nameRow.Name = row.Name;

                nameRow.NameOld = row.Name;

                nameRow.NameCdOld = row.NameCd;

                nameRow.NameKbnOld = row.NameKbn;

                nameRow.DeleteFlg = row.DeleteFlg;

                nameRow.DeleteFlgOld = row.DeleteFlg;

                nameRow.IsUpdate = "1";

                nameRow.InsertDt = row.InsertDt;

                nameRow.InsertTarm = row.InsertTarm;

                nameRow.InsertUser = row.InsertUser;

                nameRow.UpdateDt = row.UpdateDt;

                nameRow.UpdateTarm = row.UpdateTarm;

                nameRow.UpdateUser = row.UpdateUser;

                dataTable.AddNameMstUpdateRow(nameRow);

                nameRow.AcceptChanges();

                nameRow.SetAdded();

            }

            return dataTable;
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            this.nameMstNameKbn000TableAdapter.Fill(this.nameMstDataSet.NameMstNameKbn000);

            // table update
            NameMstUpdateDataSet.NameMstUpdateDataTable dataTable = new NameMstUpdateDataSet.NameMstUpdateDataTable();

            // table insert
            NameMstDataSet.NameMstDataTable insertTable = new NameMstDataSet.NameMstDataTable();

            DateTime now = Common.Common.GetCurrentTimestamp();

            for (int i = 0; i < nameListDataGridView.RowCount - 1; i++)
            {
                // update
                if (nameListDataGridView.Rows[i].Cells["IsUpdateCol"].Value.ToString() == "1")
                {
                    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)nameListDataGridView.Rows[i].Cells["NameKbnCol"];
                    string valueKbnNew = cb.Value.ToString();

                    if (valueKbnNew != nameListDataGridView.Rows[i].Cells["NameKbnOldCol"].Value.ToString()
                        || nameListDataGridView.Rows[i].Cells["NameCdCol"].Value.ToString() != nameListDataGridView.Rows[i].Cells["NameCdOldCol"].Value.ToString()
                        || nameListDataGridView.Rows[i].Cells["NameCol"].Value.ToString() != nameListDataGridView.Rows[i].Cells["NameOldCol"].Value.ToString()
                        || nameListDataGridView.Rows[i].Cells["DeleteFlgCol"].Value.ToString() != nameListDataGridView.Rows[i].Cells["DeleteFlgOldCol"].Value.ToString()
                        )
                    {
                        NameMstUpdateDataSet.NameMstUpdateRow updateRow = dataTable.NewNameMstUpdateRow();

                        updateRow.NameKbnNew = valueKbnNew;

                        updateRow.NameCdNew = nameListDataGridView.Rows[i].Cells["NameCdCol"].Value.ToString();

                        updateRow.Name = nameListDataGridView.Rows[i].Cells["NameCol"].Value.ToString();

                        updateRow.NameCdOld = nameListDataGridView.Rows[i].Cells["NameCdOldCol"].Value.ToString();

                        updateRow.NameKbnOld = nameListDataGridView.Rows[i].Cells["NameKbnOldCol"].Value.ToString();

                        updateRow.InsertDt = (DateTime)nameListDataGridView.Rows[i].Cells["InsertDt"].Value;

                        updateRow.InsertUser = nameListDataGridView.Rows[i].Cells["InsertUser"].Value.ToString();

                        updateRow.InsertTarm = nameListDataGridView.Rows[i].Cells["InsertTarm"].Value.ToString();

                        updateRow.UpdateDt = (DateTime)nameListDataGridView.Rows[i].Cells["UpdateDt"].Value;

                        updateRow.UpdateUser = nameListDataGridView.Rows[i].Cells["UpdateUser"].Value.ToString();

                        updateRow.UpdateTarm = nameListDataGridView.Rows[i].Cells["UpdateTarm"].Value.ToString();

                        updateRow.DeleteFlg = nameListDataGridView.Rows[i].Cells["DeleteFlgCol"].Value.ToString();

                        dataTable.AddNameMstUpdateRow(updateRow);

                        updateRow.AcceptChanges();
                        updateRow.SetAdded();
                    }
                }
                else // insert
                {
                    if ((nameListDataGridView.Rows[i].Cells["NameKbnCol"].Value == null
                            || string.IsNullOrEmpty(nameListDataGridView.Rows[i].Cells["NameKbnCol"].Value.ToString()))
                        && (nameListDataGridView.Rows[i].Cells["NameCdCol"].Value == null
                            || string.IsNullOrEmpty(nameListDataGridView.Rows[i].Cells["NameCdCol"].Value.ToString()))
                        && (nameListDataGridView.Rows[i].Cells["NameCol"].Value == null
                            || string.IsNullOrEmpty(nameListDataGridView.Rows[i].Cells["NameCol"].Value.ToString()))
                        && (nameListDataGridView.Rows[i].Cells["DeleteFlgCol"].Value == null
                            || (string.IsNullOrEmpty(nameListDataGridView.Rows[i].Cells["DeleteFlgOldCol"].Value.ToString()))
                        )
                    )
                    {
                        // don't insert
                    }
                    else
                    {
                        NameMstDataSet.NameMstRow insertRow = insertTable.NewNameMstRow();

                        insertRow.NameKbn = nameListDataGridView.Rows[i].Cells["NameKbnCol"].Value.ToString();

                        // UPD 20140724 START ZynasSou
                        //insertRow.NameCd = nameListDataGridView.Rows[i].Cells["NameCdCol"].Value.ToString();
                        insertRow.NameCd = Utility.Saiban.GetKeyRenban("NameMst", nameListDataGridView.Rows[i].Cells["NameKbnCol"].Value.ToString(), "", "").PadLeft(3,'0');
                        // UPD 20140724 END ZynasSou

                        insertRow.Name = nameListDataGridView.Rows[i].Cells["NameCol"].Value.ToString();

                        if (string.IsNullOrEmpty(nameListDataGridView.Rows[i].Cells["DeleteFlgCol"].Value.ToString())
                            || nameListDataGridView.Rows[i].Cells["DeleteFlgCol"].Value.ToString() == "0")
                        {
                            insertRow.DeleteFlg = "0";
                        }
                        else
                        {
                            insertRow.DeleteFlg = "1";
                        }
                        
                        insertRow.InsertDt = now;

                        insertRow.InsertUser = loginUser;

                        insertRow.InsertTarm = terminalName;

                        insertRow.UpdateDt = now;

                        insertRow.UpdateUser = loginUser;

                        insertRow.UpdateTarm = terminalName;

                        insertTable.AddNameMstRow(insertRow);

                        insertRow.AcceptChanges();

                        insertRow.SetAdded();
                    }
                }
            }

            IKoshinBtnClickALInput alInput = new KoshinBtnClickALInput();
            alInput.NameMstUpdateDT = dataTable;
            alInput.NameMstDT = insertTable;
            IKoshinBtnClickALOutput alOutput = new KoshinBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.ListKey.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "登録しました。");

                DoSearch();
            }
            else
            {
                ChangeBackgroundUpdate(alOutput.ListKey);
            }
        }
        #endregion

        #region ChangeBackground
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeBackground
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeBackground(List<string> listKey)
        {
            DataGridViewCellStyle styleWhite = new DataGridViewCellStyle();

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;

            // if have data duplicate
            if (listKey != null && listKey.Count > 0)
            {
                foreach (string key in listKey)
                {
                    string nameKbn = key.Split('-')[0];
                    string nameCd = key.Split('-')[1];

                    foreach (DataGridViewRow row in nameListDataGridView.Rows)
                    {
                        if (row.Cells["NameKbnCol"].Value != null)
                        {
                            if (row.Cells["NameKbnCol"].Value.ToString() == nameKbn && row.Cells["NameCdCol"].Value.ToString() == nameCd)
                            {
                                row.DefaultCellStyle = style;
                            }
                            else
                            {
                                row.DefaultCellStyle = styleWhite;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in nameListDataGridView.Rows)
                {
                    row.DefaultCellStyle = styleWhite;
                }
            }
        }
        #endregion

        #region ChangeBackgroundUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeBackground
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeBackgroundUpdate(List<string> listKey)
        {
            DataGridViewCellStyle styleWhite = new DataGridViewCellStyle();

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;

            bool flg = false;

            // if have data duplicate
            if (listKey != null && listKey.Count > 0)
            {
                foreach (string key in listKey)
                {
                    string nameKbn = key.Split('-')[0];
                    string nameCd = key.Split('-')[1];

                    foreach (DataGridViewRow row in nameListDataGridView.Rows)
                    {
                        if (row.Cells["NameKbnCol"].Value != null)
                        {
                            if (row.Cells["NameKbnCol"].Value.ToString() == nameKbn && row.Cells["NameCdCol"].Value.ToString() == nameCd)
                            {
                                row.DefaultCellStyle = style;
                                flg = true;
                            }
                            else
                            {
                                row.DefaultCellStyle = styleWhite;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in nameListDataGridView.Rows)
                {
                    row.DefaultCellStyle = styleWhite;
                }
            }

            if (flg)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "名称区分＆名称コードが重複しています。\r\n");
            }
        }
        #endregion

        #region OutputExcel
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： OutputExcel
        /// <summary>
        ///  指定GridviewのデータをExcelに出力する
        /// </summary>
        /// <param name="targetDataGridView">対象DataGridView</param>
        /// <param name="outputFilename"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　DatNT　　 新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private static void OutputExcel(DataGridView targetDataGridView,string outputFilename)
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

                    for (i = 0; i <= targetDataGridView.Rows.Count - 1; i++)
                    {
                        for (j = 0; j <= targetDataGridView.Columns.Count - 1; j++)
                        {
                            if (targetDataGridView.Columns[j].Visible)
                            {
                                DataGridViewCell cell = targetDataGridView[j, i];

                                if (i == 0)
                                {
                                    DataGridViewHeaderCell h = targetDataGridView.Columns[j].HeaderCell;
                                    xlWorkSheet.Cells[i + 1, j + 1] = h.Value;
                                }

                                // Code columns format
                                if (targetDataGridView.Columns[j].Name.Length > 5
                                    && targetDataGridView.Columns[j].Name.Substring(targetDataGridView.Columns[j].Name.Length - 5) == "CdCol")
                                {
                                    xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value;
                                    Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                                    continue;
                                }

                                if (targetDataGridView.Columns[j].Name == "NameKbnCol")
                                {
                                    xlWorkSheet.Cells[i + 2, j + 1] = cell.FormattedValue.ToString();

                                    continue;
                                }

                                if (targetDataGridView.Columns[j].Name == "NameCol")
                                {
                                    xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value;

                                    continue;
                                }

                                xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                            }
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
        private static void releaseObject(object obj)
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

        #region GetListDuplicate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetListDuplicate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private List<string> GetListDuplicate()
        {
            List<string> listKey = new List<string>();

            for (int i = 0; i < nameListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = nameListDataGridView.Rows[i];

                // ADD 20140724 START ZynasSou
                if (string.IsNullOrEmpty(row.Cells["NameCdCol"].Value.ToString()))
                {
                    continue;
                }
                // ADD 20140724 START ZynasSou

                // RelationCheck
                if (row.Cells["NameKbnCol"].Value != null && row.Cells["NameCdCol"].Value != null)
                {
                    string namePK = row.Cells["NameKbnCol"].Value.ToString() + "-" + row.Cells["NameCdCol"].Value.ToString();

                    for (int j = i + 1; j < nameListDataGridView.RowCount; j++)
                    {
                        DataGridViewRow rowJ = nameListDataGridView.Rows[j];

                        if (rowJ.Cells["NameKbnCol"].Value != null && rowJ.Cells["NameCdCol"].Value != null)
                        {
                            string key = rowJ.Cells["NameKbnCol"].Value.ToString() + "-" + rowJ.Cells["NameCdCol"].Value.ToString();

                            if (namePK == key)
                            {
                                listKey.Add(key);
                            }
                        }
                    }
                }
            }

            return listKey;
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

        #endregion

    }
    #endregion
}
