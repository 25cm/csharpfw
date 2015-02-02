using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiInput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanKensaYoteiInputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JinendoGaikanKensaYoteiInputForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Display,
            Update,
            Search,
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
        public DispMode _dispMode = DispMode.Search;

        /// <summary>
        /// Current system date
        /// </summary>
        private DateTime _now;

        /// <summary>
        /// Dgv source
        /// </summary>
        private JokasoDaichoMstDataSet.JinendoGaikanInputDataTable _dispTable;

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
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JinendoGaikanKensaYoteiInputForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region JinendoGaikanKensaYoteiInputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanKensaYoteiInputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanKensaYoteiInputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default data
                DoFormLoad();

                // Enable/visible property control
                ScreenModeControl();
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

        #region JinendoGaikanKensaYoteiInputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanKensaYoteiInputForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanKensaYoteiInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        henkoButton.PerformClick();
                        break;
                    case Keys.F2:
                        torikesiButton.PerformClick();
                        break;
                    case Keys.F3:
                        kakuteiButton.PerformClick();
                        break;
                    case Keys.F4:
                        printButton.PerformClick();
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

        #region gyosyaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open gyoshaMst search form
                Common.GyoshaMstSearchForm frm = new Common.GyoshaMstSearchForm();
                frm.ShowDialog();

                // Avoid user close the form
                if (frm.DialogResult != DialogResult.OK) return;

                // No row was selected
                if (frm._selectedRow == null) return;

                // 業者コード(1)
                gyoshaCdTextBox.Text = frm._selectedRow.GyoshaCd;

                // 業者名称(2)
                gyoshaNmTextBox.Text = frm._selectedRow.GyoshaNm;

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
        /// 2014/09/19　AnhNV　　    新規作成
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
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック
                if (!ValidatorSearch()) return;

                // Do search
                DoSearch();

                // Change to display mode
                _dispMode = DispMode.Display;

                // Control the display of the screen
                ScreenModeControl();
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
        /// 2014/09/19　AnhNV　　    新規作成
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
                    this.kensaIraiListPanel,
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

        #region printButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： printButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                alInput.SeikyusakiCd = gyoshaCdTextBox.Text;
                alInput.NendoFrom = Convert.ToInt32(kensaNendoTextBox.Text) - 1 + "04";
                alInput.NendoTo = kensaNendoTextBox.Text + "03";
                alInput.SystemDt = Common.Common.GetCurrentTimestamp();
                new PrintBtnClickApplicationLogic().Execute(alInput);
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

        #region henkoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void henkoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Change to update mode
                _dispMode = DispMode.Update;

                // Control the display of the screen
                ScreenModeControl();
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

        #region torikesiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torikesiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torikesiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 編集内容破棄チェック
                if (DgvSourceChange())
                {
                    // Confirmation
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // Change to Search mode
                _dispMode = DispMode.Search;

                // Control the display of the screen
                ScreenModeControl();
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

        #region kakuteiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック
                if (!ValidatorUpdate()) return;

                // 重複チェック
                if (!DuplicationCheck()) return;

                // Execute update
                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                alInput.KensaIraiListDgv = kensaIraiListDataGridView;
                alInput.KensaNendoTxt = kensaNendoTextBox.Text;
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                // Move to search mode
                _dispMode = DispMode.Search;

                // Control the display of the screen
                ScreenModeControl();
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
        /// 2014/09/19　AnhNV　　    新規作成
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
                if (kensaIraiListDataGridView.Rows.Count == 0) return;

                // Copy a temp dgv
                DataGridView tempDgv = Common.Common.CopyDataGridView(kensaIraiListDataGridView);

                // Get list of hidden columns
                List<string> hiddenCols = new List<string>();
                foreach (DataGridViewColumn dgvc in kensaIraiListDataGridView.Columns)
                {
                    // Hidden columns
                    if (dgvc.Visible == false)
                    {
                        hiddenCols.Add(dgvc.Name);
                    }
                }

                // Remove all hidden columns
                foreach (string colNm in hiddenCols)
                {
                    tempDgv.Columns.Remove(colNm);
                }

                // Export excel
                Common.Common.FlushGridviewDataToExcel(tempDgv, "次年度外観検査予定入力");
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 編集内容破棄チェック
                if (DgvSourceChange())
                {
                    // Confirmation
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // Back to UketsukeKanriMenu form
                //UketsukeKanriMenuForm frm = new UketsukeKanriMenuForm();
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
        /// 2014/09/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Current system date
            _now = Common.Common.GetCurrentTimestamp();

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.kensaIraiListPanel.Top;
            this._defaultListPanelHeight = this.kensaIraiListPanel.Height;

            // 検査年度(4)
            kensaNendoTextBox.Text = GetNendo();
        }
        #endregion

        #region ScreenModeControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ScreenModeControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ScreenModeControl()
        {
            // 業者コード(1)
            gyoshaCdTextBox.Enabled =

            // 業者名称(2)
            gyoshaNmTextBox.Enabled =

            // 業者検索ボタン(3)
            gyosyaSearchButton.Enabled =

            // 検査年度(4)
            kensaNendoTextBox.Enabled =

            // クリアボタン(5)
            clearButton.Enabled =

            // 検索ボタン(6)
            kensakuButton.Enabled = _dispMode == DispMode.Search ? true : false;

            // 検索依頼一覧(9)
            kensaIraiListDataGridView.ReadOnly = _dispMode == DispMode.Update ? false : true;

            // 11条検査依頼一覧表印刷ボタン(17)
            printButton.Visible = _dispMode == DispMode.Display ? true : false;

            // 変更ボタン(18)
            henkoButton.Visible = _dispMode == DispMode.Display ? true : false;

            // 確定ボタン(19)
            torikesiButton.Visible = _dispMode == DispMode.Update ? true : false;

            // 取消ボタン(20)
            kakuteiButton.Visible = _dispMode == DispMode.Update ? true : false;

            // 一覧出力ボタン(21)
            outputButton.Visible = _dispMode == DispMode.Search ? false : true;
        }
        #endregion

        #region GetNendo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetNendo
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetNendo()
        {
            // システム日付の年度
            return _now.Month >= 4 ? (_now.Year + 1).ToString() : _now.ToString("yyyy");
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
        /// 2014/09/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 業者コード(1)
            gyoshaCdTextBox.Text = string.Empty;

            // 業者名称(2)
            gyoshaNmTextBox.Text = string.Empty;

            // 検査年度(4)
            kensaNendoTextBox.Text = GetNendo();
        }
        #endregion

        #region ValidatorSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ValidatorSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool ValidatorSearch()
        {
            bool nullOK = true;
            StringBuilder errMsg = new StringBuilder();

            // 業者コード(1) is empty
            if (string.IsNullOrEmpty(gyoshaCdTextBox.Text))
            {
                errMsg.AppendLine("必須項目：業者コードが入力されていません。");
                nullOK = false;
            }

            // 検査年度(4) is empty
            if (string.IsNullOrEmpty(kensaNendoTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：検査年度が入力されていません。");
                nullOK = false;
            }

            // 業者コード(1)'s lenght violation
            if (nullOK && gyoshaCdTextBox.Text.Length != 4)
            {
                errMsg.AppendLine("業者コードは4桁で入力して下さい。");
            }

            // An error occurred!
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
        /// 2014/09/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            kensaIraiListDataGridView.DataSource = null;
            kensaIraiListDataGridView.Rows.Clear();
            kensaIraiListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            searchInput.SeikyusakiCd = gyoshaCdTextBox.Text;
            searchInput.NendoFrom = Convert.ToInt32(kensaNendoTextBox.Text) - 1 + "04";
            searchInput.NendoTo = kensaNendoTextBox.Text + "03";
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);
            _dispTable = alOutput.JinendoGaikanInputDataTable;

            // No records was found
            if (alOutput.JinendoGaikanInputDataTable.Count == 0)
            {
                // 検索結果件数
                kensaIraiListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            kensaIraiListCountLabel.Text = string.Concat(alOutput.JinendoGaikanInputDataTable.Count, "件");

            // Binding source to dgv
            kensaIraiListDataGridView.DataSource = alOutput.JinendoGaikanInputDataTable;

            // Populate data to hidden columns, which is using for check dgv source change
            PopulateDataForHiddenCol();
        }
        #endregion

        #region DgvSourceChange
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DgvSourceChange
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/23  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DgvSourceChange()
        {
            foreach (DataGridViewRow dgvr in kensaIraiListDataGridView.Rows)
            {
                // 設置者区分 - hidden(14)
                if (!dgvr.Cells["settisyaKbnHiddenCol"].Value.Equals(_dispTable[dgvr.Index].JokasoSetchishaKbn))
                {
                    return true;
                }

                // 設置者コード - hidden(15)
                if (!dgvr.Cells["setchishaCdHiddenCol"].Value.Equals(_dispTable[dgvr.Index].JokasoSetchishaCd))
                {
                    return true;
                }

                // 予定月 - hidden(16)
                if (!dgvr.Cells["nendoHiddenCol"].Value.Equals(_dispTable[dgvr.Index].KensaIraiKensaYoteiTsuki))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region ValidatorUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ValidatorUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/23  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool ValidatorUpdate()
        {
            string err14 = string.Empty;
            string err15 = string.Empty;
            string err16 = string.Empty;
            StringBuilder errMsg = new StringBuilder();

            foreach (DataGridViewRow dgvr in kensaIraiListDataGridView.Rows)
            {
                // 設置者区分(14)
                if (dgvr.Cells["settisyaKbnCol"].Value == null || string.IsNullOrEmpty(dgvr.Cells["settisyaKbnCol"].Value.ToString()))
                {
                    err14 += dgvr.Index + 1 + ", ";
                }

                // 設置者コード(15)
                if (dgvr.Cells["setchishaCdCol"].Value == null || string.IsNullOrEmpty(dgvr.Cells["setchishaCdCol"].Value.ToString()))
                {
                    err15 += dgvr.Index + 1 + ", ";
                }

                // 予定月(16)
                if (dgvr.Cells["nendoCol"].Value == null || string.IsNullOrEmpty(dgvr.Cells["nendoCol"].Value.ToString()))
                {
                    err16 += dgvr.Index + 1 + ", ";
                }
            }

            if (err14 != string.Empty)
            {
                errMsg.AppendLine(string.Format("行{0}: 必須項目：設置者区分が入力されていません。", err14.Remove(err14.Length - 2)));
            }

            if (err15 != string.Empty)
            {
                errMsg.AppendLine(string.Format("行{0}: 必須項目：設置者コードが入力されていません。", err15.Remove(err15.Length - 2)));
            }

            if (err16 != string.Empty)
            {
                errMsg.AppendLine(string.Format("行{0}: 必須項目：予定月が入力されていません。", err16.Remove(err16.Length - 2)));
            }

            // Error(s)
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region DuplicationCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DuplicationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/23  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DuplicationCheck()
        {
            List<string> errMsg = new List<string>();

            // Use the currentRow to compare against
            for (int currentRow = 0; currentRow < kensaIraiListDataGridView.Rows.Count; currentRow++)
            {
                bool unHighlight = true;

                DataGridViewRow rowToCompare = kensaIraiListDataGridView.Rows[currentRow];
                for (int otherRow = 0; otherRow < kensaIraiListDataGridView.Rows.Count; otherRow++)
                {
                    bool duplicateRow = false;
                    DataGridViewRow row = kensaIraiListDataGridView.Rows[otherRow];

                    // compare cell SetKomokuCdCol between the two rows
                    if (currentRow != otherRow
                        && !string.IsNullOrEmpty(rowToCompare.Cells["settisyaKbnCol"].Value.ToString())
                        && !string.IsNullOrEmpty(rowToCompare.Cells["setchishaCdCol"].Value.ToString())
                        && !string.IsNullOrEmpty(row.Cells["settisyaKbnCol"].Value.ToString())
                        && !string.IsNullOrEmpty(row.Cells["setchishaCdCol"].Value.ToString())
                        && rowToCompare.Cells["settisyaKbnCol"].Value.Equals(row.Cells["settisyaKbnCol"].Value)
                        && rowToCompare.Cells["setchishaCdCol"].Value.Equals(row.Cells["setchishaCdCol"].Value))
                    {
                        duplicateRow = true;
                    }

                    // Highlight duplicate rows
                    if (duplicateRow)
                    {
                        rowToCompare.DefaultCellStyle.BackColor = Color.Red;
                        rowToCompare.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        unHighlight = false;
                        
                        // Append an error message
                        errMsg.Add(string.Format("設置者区分、及び設置者コードが重複しています。[設置者区分：{0}][設置者コード：{1}]",
                            rowToCompare.Cells["settisyaKbnCol"].Value.ToString(),
                            rowToCompare.Cells["setchishaCdCol"].Value.ToString()
                            ));
                    }
                }

                if (unHighlight)
                {
                    rowToCompare.DefaultCellStyle.BackColor = SystemColors.Window;
                }
            }

            // Error!
            if (errMsg.Count > 0)
            {
                string message = string.Empty;

                // Remove duplicate message
                foreach (string err in errMsg.Distinct().ToList())
                {
                    message += err + Environment.NewLine;
                }

                // Show
                MessageForm.Show2(MessageForm.DispModeType.Error, message);
                return false;
            }

            return true;
        }
        #endregion

        #region PopulateDataForHiddenCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PopulateDataForHiddenCol
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/08  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PopulateDataForHiddenCol()
        {
            foreach (DataGridViewRow dgvr in kensaIraiListDataGridView.Rows)
            {
                // 設置者区分 - hidden(14)
                dgvr.Cells["settisyaKbnHiddenCol"].Value = _dispTable[dgvr.Index].JokasoSetchishaKbn;

                // 設置者コード - hidden(15)
                dgvr.Cells["setchishaCdHiddenCol"].Value = _dispTable[dgvr.Index].JokasoSetchishaCd;

                // 予定月 - hidden(16)
                dgvr.Cells["nendoHiddenCol"].Value = _dispTable[dgvr.Index].KensaIraiKensaYoteiTsuki;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
