using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.ShoriHoshikiMstList;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShoriHoshikiMstForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShoriHoshikiMstListForm : FukjBaseForm
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

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShoriHoshikiMstForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShoriHoshikiMstListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region ShoriHoshikiMst_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShoriHoshikiMst_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShoriHoshikiMst_Load(object sender, EventArgs e)
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
        /// 2014/06/30  DatNT　　    新規作成
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
                else // 検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.shoriHoshikiListPanel,
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 処理方式区分（開始）3
                shoriHoshikiKbnFromTextBox.Text = string.Empty;

                // 処理方式区分（終了）4
                shoriHoshikiKbnToTextBox.Text = string.Empty;

                // 処理方式コード（開始）5
                shoriHoshikiCdFromTextBox.Text = string.Empty;

                // 処理方式コード（終了）6
                shoriHoshikiCdToTextBox.Text = string.Empty;

                // 処理方式種別名 7
                shoriHoshikiShubetsuNmTextBox.Text = string.Empty;

                // 処理方式名 8
                shoriHoshikiNmTextBox.Text = string.Empty;
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
        /// 2014/06/30  DatNT　　    新規作成
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ShoriHoshikiMstShosaiForm frm = new ShoriHoshikiMstShosaiForm();
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shoriHoshikiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string kbn = shoriHoshikiListDataGridView.CurrentRow.Cells["ShoriHoshikiKbnCol"].Value.ToString();

                string cd = shoriHoshikiListDataGridView.CurrentRow.Cells["ShoriHoshikiCdCol"].Value.ToString();

                ShoriHoshikiMstShosaiForm frm = new ShoriHoshikiMstShosaiForm(kbn, cd);
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shoriHoshikiListDataGridView.RowCount == 0) { return; }

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "処理方式マスタ一覧";
                Common.Common.FlushGridviewDataToExcel(this.shoriHoshikiListDataGridView, outputFilename);
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
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

        #region ShoriHoshikiMstListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShoriHoshikiMstListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShoriHoshikiMstListForm_KeyDown(object sender, KeyEventArgs e)
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

        #region shoriHoshikiListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shoriHoshikiListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shoriHoshikiListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                string kbn = shoriHoshikiListDataGridView.CurrentRow.Cells["ShoriHoshikiKbnCol"].Value.ToString();

                string cd = shoriHoshikiListDataGridView.CurrentRow.Cells["ShoriHoshikiCdCol"].Value.ToString();

                ShoriHoshikiMstShosaiForm frm = new ShoriHoshikiMstShosaiForm(kbn, cd);
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

        #region shoriHoshikiKbnFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shoriHoshikiKbnFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26  DatNT　　  v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shoriHoshikiKbnFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(shoriHoshikiKbnFromTextBox.Text))
                {
                    shoriHoshikiKbnToTextBox.Text = shoriHoshikiKbnFromTextBox.Text;
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

        #region shoriHoshikiCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shoriHoshikiCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26  DatNT　　  v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shoriHoshikiCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(shoriHoshikiCdFromTextBox, shoriHoshikiCdFromTextBox, shoriHoshikiCdToTextBox);
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

        #region shoriHoshikiCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shoriHoshikiCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26  DatNT　　  v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shoriHoshikiCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(shoriHoshikiCdToTextBox, shoriHoshikiCdToTextBox, shoriHoshikiCdToTextBox);
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            shoriHoshikiMstDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Display data
            shoriHoshikiMstDataSet.Merge(alOutput.ShoriHoshikiMstKensakuDT);

            if (alOutput.ShoriHoshikiMstKensakuDT == null || alOutput.ShoriHoshikiMstKensakuDT.Count == 0)
            {
                shoriHoshikiListCountLabel.Text = "0件";
            }
            else
            {
                shoriHoshikiListCountLabel.Text = alOutput.ShoriHoshikiMstKensakuDT.Count.ToString() + "件";
            }

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.shoriHoshikiListPanel.Top;
            this._defaultListPanelHeight = this.shoriHoshikiListPanel.Height;
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 処理方式区分（開始）3
            if (!string.IsNullOrEmpty(shoriHoshikiKbnFromTextBox.Text))
            {
                alInput.ShoriHoshikiKbnFrom = shoriHoshikiKbnFromTextBox.Text;
            }

            // 処理方式区分（終了）4
            if (!string.IsNullOrEmpty(shoriHoshikiKbnToTextBox.Text))
            {
                alInput.ShoriHoshikiKbnTo = shoriHoshikiKbnToTextBox.Text;
            }

            // 処理方式コード（開始）5
            if (!string.IsNullOrEmpty(shoriHoshikiCdFromTextBox.Text))
            {
                alInput.ShoriHoshikiCdFrom = shoriHoshikiCdFromTextBox.Text;
            }

            // 処理方式コード（終了）6
            if (!string.IsNullOrEmpty(shoriHoshikiCdToTextBox.Text))
            {
                alInput.ShoriHoshikiCdTo = shoriHoshikiCdToTextBox.Text;
            }

            // 処理方式種別名 7
            if (!string.IsNullOrEmpty(shoriHoshikiShubetsuNmTextBox.Text.Trim()))
            {
                alInput.ShoriHoshikiShubetsuNm = shoriHoshikiShubetsuNmTextBox.Text.Trim();
            }

            // 処理方式名 8
            if (!string.IsNullOrEmpty(shoriHoshikiNmTextBox.Text.Trim()))
            {
                alInput.ShoriHoshikiNm = shoriHoshikiNmTextBox.Text.Trim();
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            shoriHoshikiMstDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            shoriHoshikiMstDataSet.Merge(alOutput.ShoriHoshikiMstKensakuDT);

            if (alOutput.ShoriHoshikiMstKensakuDT == null || alOutput.ShoriHoshikiMstKensakuDT.Count == 0)
            {
                shoriHoshikiListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                shoriHoshikiListCountLabel.Text = alOutput.ShoriHoshikiMstKensakuDT.Count.ToString() + "件";
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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 処理方式区分（開始）3
            if (!string.IsNullOrEmpty(shoriHoshikiKbnFromTextBox.Text.Trim()) && shoriHoshikiKbnFromTextBox.Text.Trim().Length > 1)
            {
                errMess.Append("処理方式区分（開始）は1桁で入力して下さい。\r\n");
            }

            // 処理方式区分（終了）4
            if (!string.IsNullOrEmpty(shoriHoshikiKbnToTextBox.Text.Trim()) && shoriHoshikiKbnToTextBox.Text.Trim().Length > 1)
            {
                errMess.Append("処理方式区分（終了）は1桁で入力して下さい。\r\n");
            }

            if (string.IsNullOrEmpty(errMess.ToString()))
            {
                // 「処理方式区分（開始）　>　処理方式区分（終了）」の場合 ( 3 > 4)
                if (!string.IsNullOrEmpty(shoriHoshikiKbnFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(shoriHoshikiKbnToTextBox.Text.Trim()))
                {
                    if (Convert.ToInt32(shoriHoshikiKbnFromTextBox.Text) > Convert.ToInt32(shoriHoshikiKbnToTextBox.Text))
                    {
                        errMess.Append("範囲指定が正しくありません。処理方式区分の大小関係を確認してください。\r\n");
                    }
                }
            }

            // 処理方式コード（開始）5
            bool flg = false;
            if (!string.IsNullOrEmpty(shoriHoshikiCdFromTextBox.Text) && shoriHoshikiCdFromTextBox.Text.Trim().Length != 3)
            {
                errMess.Append("処理方式コード（開始）は3桁で入力して下さい。\r\n");
                flg = true;
            }

            // 処理方式コード（終了）6
            if (!string.IsNullOrEmpty(shoriHoshikiCdToTextBox.Text) && shoriHoshikiCdToTextBox.Text.Trim().Length != 3)
            {
                errMess.Append("処理方式コード（終了）は3桁で入力して下さい。\r\n");
                flg = true;
            }

            if (!flg)
            {
                // 「処理方式コード（開始）　>　処理方式コード（終了）」の場合 ( 5 > 6)
                if (!string.IsNullOrEmpty(shoriHoshikiCdFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(shoriHoshikiCdToTextBox.Text.Trim()))
                {
                    if (Convert.ToInt32(shoriHoshikiCdFromTextBox.Text) > Convert.ToInt32(shoriHoshikiCdToTextBox.Text))
                    {
                        errMess.Append("範囲指定が正しくありません。処理方式コードの大小関係を確認してください。\r\n");
                    }
                }
            }

            // 処理方式種別名
            if (!string.IsNullOrEmpty(shoriHoshikiShubetsuNmTextBox.Text.Trim()) && shoriHoshikiShubetsuNmTextBox.Text.Trim().Length > 14)
            {
                errMess.Append("処理方式種別名は14文字以下で入力して下さい。\r\n");
            }

            // 処理方式名
            if (!string.IsNullOrEmpty(shoriHoshikiNmTextBox.Text.Trim()) && shoriHoshikiNmTextBox.Text.Trim().Length > 80)
            {
                errMess.Append("処理方式名は80文字以下で入力して下さい。\r\n");
            }

            if(!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
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

        #endregion
    }
    #endregion
}
