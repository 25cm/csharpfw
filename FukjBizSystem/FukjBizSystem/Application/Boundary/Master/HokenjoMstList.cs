using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.HokenjoMstList;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HokenjoMstListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HokenjoMstListForm : FukjBaseForm
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
        //  コンストラクタ名 ： HokenjoMstListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HokenjoMstListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region HokenjoMstListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HokenjoMstListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HokenjoMstListForm_Load(object sender, EventArgs e)
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
        /// 2014/06/20  DatNT　　 新規作成
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
                    this.HokenjyoListPanel,
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
        /// 2014/06/20  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(UnitCheck()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, UnitCheck());
                    return;
                }

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
        /// 2014/06/20  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 保健所コード（開始）
                hokenjyoCdFromTextBox.Clear();

                // 保健所コード（終了）
                hokenjyoCdToTextBox.Text = string.Empty;

                // 保健所名称
                hokenjyoNmTextBox.Text = string.Empty;

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
        /// 2014/06/20  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (hokenjyoListDataGridView.RowCount == 0) { return; }

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "保健所マスタ一覧";
                Common.Common.FlushGridviewDataToExcel(this.hokenjyoListDataGridView, outputFilename);
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
        /// 2014/06/20  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (hokenjyoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string hokenjoCd = hokenjyoListDataGridView.CurrentRow.Cells["HokenjyoCdCol"].Value.ToString();

                HokenjoMstShosaiForm frm = new HokenjoMstShosaiForm(hokenjoCd);
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

        #region hokenjyoListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hokenjyoListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hokenjyoListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                string hokenjoCd = hokenjyoListDataGridView.CurrentRow.Cells["HokenjyoCdCol"].Value.ToString();

                HokenjoMstShosaiForm frm = new HokenjoMstShosaiForm(hokenjoCd);
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
        /// 2014/06/20  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                HokenjoMstShosaiForm frm = new HokenjoMstShosaiForm();
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

        #region HokenjoMstListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HokenjoMstListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HokenjoMstListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
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
        /// 2014/06/20  DatNT　　 新規作成
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

        #region hokenjyoCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hokenjyoCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23  HuyTX　　 Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hokenjyoCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(hokenjyoCdFromTextBox, hokenjyoCdFromTextBox, hokenjyoCdToTextBox);
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

        #region hokenjyoCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hokenjyoCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23  HuyTX　　 Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hokenjyoCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(hokenjyoCdToTextBox, hokenjyoCdFromTextBox, hokenjyoCdToTextBox);
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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            hokenjoMstDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Display data
            hokenjoMstDataSet.Merge(alOutput.HokenjoMstKensakuDT);

            if (alOutput.HokenjoMstKensakuDT == null || alOutput.HokenjoMstKensakuDT.Count == 0)
            {
                hokenjyoListCountLabel.Text = "0件";
            }
            else
            {
                hokenjyoListCountLabel.Text = alOutput.HokenjoMstKensakuDT.Count.ToString() + "件";
            }

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.HokenjyoListPanel.Top;
            this._defaultListPanelHeight = this.HokenjyoListPanel.Height;
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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(ISearchBtnClickALInput alInput)
        {
            // 保健所コード（開始）
            if (!String.IsNullOrEmpty(hokenjyoCdFromTextBox.Text))
            {
                alInput.HokenjyoCdFrom = hokenjyoCdFromTextBox.Text;
            }

            // 保健所コード（終了）
            if (!String.IsNullOrEmpty(hokenjyoCdToTextBox.Text))
            {
                alInput.HokenjyoCdTo = hokenjyoCdToTextBox.Text;
            }

            // 保健所名称
            if (!String.IsNullOrEmpty(hokenjyoNmTextBox.Text))
            {
                alInput.HokenjyoNm = hokenjyoNmTextBox.Text.Trim();
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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            hokenjoMstDataSet.Clear();

            ISearchBtnClickALInput alInput = new SearchBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(alInput);

            // Display data
            hokenjoMstDataSet.Merge(alOutput.HokenjoMstKensakuDT);

            if (alOutput.HokenjoMstKensakuDT == null || alOutput.HokenjoMstKensakuDT.Count == 0)
            {
                hokenjyoListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                hokenjyoListCountLabel.Text = alOutput.HokenjoMstKensakuDT.Count.ToString() + "件";
            }
        }
        #endregion

        #region UnitCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UnitCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string UnitCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 保健所コード（開始）
            if (hokenjyoCdFromTextBox.Text.Length > 0 && hokenjyoCdFromTextBox.Text.Length != 2)
            {
                errMsg.AppendLine("保健所コード（開始）は2桁で入力して下さい。");
            }

            // 保健所コード（終了）
            if (hokenjyoCdToTextBox.Text.Length > 0 && hokenjyoCdToTextBox.Text.Length != 2)
            {
                errMsg.AppendLine("保健所コード（終了）は2桁で入力して下さい。");
            }

            // 保健所コードの(開始)と(終了)の両方が入力されていて、
            // 「保健所コード（開始）　>　保健所コード（終了）」の場合
            if (string.IsNullOrEmpty(errMsg.ToString()) && !string.IsNullOrEmpty(hokenjyoCdFromTextBox.Text) && !string.IsNullOrEmpty(hokenjyoCdToTextBox.Text))
            {
                if (Convert.ToInt32(hokenjyoCdFromTextBox.Text) > Convert.ToInt32(hokenjyoCdToTextBox.Text))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。保健所コードの大小関係を確認してください。");
                }
            }

            //保健所名称
            if (hokenjyoNmTextBox.Text.Trim().Length > 24)
            {
                errMsg.AppendLine("保健所名称は24文字以下で入力して下さい。");
            }

            return errMsg.ToString();
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