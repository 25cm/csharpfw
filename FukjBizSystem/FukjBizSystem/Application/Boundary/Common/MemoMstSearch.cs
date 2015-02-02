using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common.MemoMstSearch;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoMstSearchForm
    /// <summary>
    /// メモ検索ダイアログ
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/10  小松        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MemoMstSearchForm : FukjBaseForm
    {
        #region プロパティ(public)

        /// <summary>
        /// Selected dgv row
        /// </summary>
        public MemoMstDataSet.MemoMstSearchListRow _selectedRow = null;

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

        // 20141202 AnhNV ADD Start
        /// <summary>
        /// メモコード
        /// </summary>
        private string _jokasoMemoCd;
        // 20141202 AnhNV ADD End

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MemoMstSearchForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MemoMstSearchForm()
        {
            InitializeComponent();

            //set control domain
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MemoMstSearchForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="jokasoMemoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MemoMstSearchForm(string jokasoMemoCd)
        {
            InitializeComponent();
            _jokasoMemoCd = jokasoMemoCd;
        }
        #endregion

        #region イベント

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 検索ボタン押下イベント
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckCondition())
                {
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

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ダイアログを閉じる
                this.Close();
                //Program.mForm.MovePrev();
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

        #region MemoMstSearchForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MemoMstSearchForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19  DatNT        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MemoMstSearchForm_Load(object sender, EventArgs e)
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
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19  DatNT        新規作成
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

                Boundary.Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.listPanel,
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
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19  DatNT        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 大分類コード（開始）
                daibunruiCdFromTextBox.Clear();

                // 大分類コード（終了）
                daibunruiCdToTextBox.Clear();

                // メモコード（開始）
                memoCdFromTextBox.Clear();

                // メモコード（終了）
                memoCdToTextBox.Clear();

                // メモ内容
                searchWdTextBox.Clear();
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
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19  DatNT        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (memoDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                this._selectedRow = (MemoMstDataSet.MemoMstSearchListRow)((DataRowView)memoDataGridView.CurrentRow.DataBoundItem).Row;

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        #region memoDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： memoDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19  DatNT        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void memoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                this._selectedRow = (MemoMstDataSet.MemoMstSearchListRow)((DataRowView)memoDataGridView.CurrentRow.DataBoundItem).Row;

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        #region MemoMstSearchForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MemoMstSearchForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19  DatNT        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MemoMstSearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.PerformClick();
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
        /// 2014/09/19  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.listPanel.Top;
            this._defaultListPanelHeight = this.listPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            // 20140212 AnhNV EDIT Start
            if (!string.IsNullOrEmpty(_jokasoMemoCd))
            {
                alInput.MemoDaibunruiCdFrom = _jokasoMemoCd;
                alInput.MemoDaibunruiCdTo = _jokasoMemoCd;

                // Default value for textboxes
                daibunruiCdFromTextBox.Text = _jokasoMemoCd;
                daibunruiCdToTextBox.Text = _jokasoMemoCd;
            }
            // 20140212 AnhNV EDIT End
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            memoMstDataSet.Merge(alOutput.MemoMstSearchListDT);

            if (alOutput.MemoMstSearchListDT == null || alOutput.MemoMstSearchListDT.Count == 0)
            {
                listCountLabel.Text = "0件";
            }
            else
            {
                listCountLabel.Text = alOutput.MemoMstSearchListDT.Count + "件";
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
        /// 2014/09/19  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear DGV
            memoMstDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // 大分類コード（開始）
            alInput.MemoDaibunruiCdFrom = daibunruiCdFromTextBox.Text;

            // 大分類コード（終了）
            alInput.MemoDaibunruiCdTo = daibunruiCdToTextBox.Text;

            // メモコード（開始）
            alInput.MemoCdFrom = memoCdFromTextBox.Text;

            // メモコード（終了）
            alInput.MemoCdTo = memoCdToTextBox.Text;

            // メモ内容
            alInput.Memo = searchWdTextBox.Text.Trim();

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            memoMstDataSet.Merge(alOutput.MemoMstSearchListDT);

            if (alOutput.MemoMstSearchListDT == null || alOutput.MemoMstSearchListDT.Count == 0)
            {
                listCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                listCountLabel.Text = alOutput.MemoMstSearchListDT.Count + "件";
            }
        }
        #endregion

        #region CheckCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <returns>True/False</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMsg = new StringBuilder();

            // 大分類コード（開始）
            bool daibunruiFlg = true;
            if (!string.IsNullOrEmpty(daibunruiCdFromTextBox.Text) && daibunruiCdFromTextBox.TextLength != 2)
            {
                errMsg.AppendLine("大分類コード（開始）は2桁で入力して下さい。");
                daibunruiFlg = false;
            }

            // 大分類コード（終了）
            if (!string.IsNullOrEmpty(daibunruiCdToTextBox.Text) && daibunruiCdToTextBox.TextLength != 2)
            {
                errMsg.AppendLine("大分類コード（終了）は2桁で入力して下さい。");
                daibunruiFlg = false;
            }

            if (daibunruiFlg && !string.IsNullOrEmpty(daibunruiCdFromTextBox.Text) && !string.IsNullOrEmpty(daibunruiCdToTextBox.Text))
            {
                if (Convert.ToInt32(daibunruiCdFromTextBox.Text) > Convert.ToInt32(daibunruiCdToTextBox.Text))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。大分類コードの大小関係を確認してください。");
                }
            }

            // メモコード（開始）
            bool memoCdFlg = true;
            if (!string.IsNullOrEmpty(memoCdFromTextBox.Text) && memoCdFromTextBox.Text.Length != 3)
            {
                errMsg.AppendLine("メモコード（開始）は3桁で入力して下さい。");
                memoCdFlg = false;
            }

            // メモコード（終了）
            if (!string.IsNullOrEmpty(memoCdToTextBox.Text) && memoCdToTextBox.Text.Length != 3)
            {
                errMsg.AppendLine("メモコード（終了）は3桁で入力して下さい。");
                memoCdFlg = false;
            }

            if (memoCdFlg && !string.IsNullOrEmpty(memoCdFromTextBox.Text) && !string.IsNullOrEmpty(memoCdToTextBox.Text))
            {
                if (Convert.ToInt32(memoCdFromTextBox.Text) > Convert.ToInt32(memoCdToTextBox.Text))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。メモコードの大小関係を確認してください。");
                }
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
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
        /// 2014/11/03  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            daibunruiCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2, HorizontalAlignment.Left);
            daibunruiCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2, HorizontalAlignment.Left);
            memoCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 3, HorizontalAlignment.Left);
            memoCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 3, HorizontalAlignment.Left);
            searchWdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100, HorizontalAlignment.Left);
            memoDataGridView.SetStdControlDomain(daibunruiCdColumn.Index, ZControlDomain.ZT_STD_NAME, 2);
            memoDataGridView.SetStdControlDomain(memoCdColumn.Index, ZControlDomain.ZT_STD_NAME, 3);
            memoDataGridView.SetStdControlDomain(memoWdColumn.Index, ZControlDomain.ZT_STD_NAME, 160);
            memoDataGridView.SetControlDomain(juyoColumn.Index, ZControlDomain.ZT_STD_NAME);
            memoDataGridView.SetControlDomain(sentakuColumn.Index, ZControlDomain.ZT_STD_NAME);
        }
        #endregion

        #endregion

    }
    #endregion
}
