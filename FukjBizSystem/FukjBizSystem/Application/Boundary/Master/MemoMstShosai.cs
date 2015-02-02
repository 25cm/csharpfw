using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.MemoMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoMstShosai
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MemoMstShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Add,        // 登録モード
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
        }
        #endregion

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// 端末
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// メモ大分類コード
        /// </summary>
        private string _memoDaibunruiCd = string.Empty;

        /// <summary>
        /// メモコード
        /// </summary>
        private string _memoCd = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Update mode
        /// </summary>
        private DispMode _updateMode;

        /// <summary>
        /// MemoMstDataTable
        /// </summary>
        private MemoMstDataSet.MemoMstDataTable _dispDT;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MemoMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MemoMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MemoMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="memoDaibunruiCd"></param>
        /// <param name="memoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MemoMstShosaiForm(string memoDaibunruiCd, string memoCd)
        {
            InitializeComponent();

            this._memoDaibunruiCd = memoDaibunruiCd;
            this._memoCd = memoCd;
        }
        #endregion

        #region イベント

        #region MemoMstShosai_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MemoMstShosai_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MemoMstShosai_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_memoDaibunruiCd) && string.IsNullOrEmpty(_memoCd))
                {
                    _dispMode = DispMode.Add;
                }
                else
                {
                    _dispMode = DispMode.Detail;
                }

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

        #region entryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： entryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!UnitCheck()) { return; }

                // update mode
                _updateMode = _dispMode;

                // display mode
                _dispMode = DispMode.Confirm;

                SetControlModeView();

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

        #region changeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： changeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_dispMode == DispMode.Detail)
                {
                    _dispMode = DispMode.Edit;
                }
                else if (_dispMode == DispMode.Edit)
                {
                    if (!UnitCheck()) { return; }

                    // update mode = EDIT
                    _updateMode = _dispMode;

                    // display mode
                    _dispMode = DispMode.Confirm;
                }

                SetControlModeView();
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

        #region deleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //// データを削除する際に、警告を表示する。
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？")
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    // 保健所マスタに対象となる保健所コードが登録されている事を確認する。
                    IDeleteBtnClickALInput alInput      = new DeleteBtnClickALInput();
                    alInput.MemoDaibunruiCd             = _memoDaibunruiCd;
                    alInput.MemoCd                      = _memoCd;
                    IDeleteBtnClickALOutput alOutput    = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    if (alOutput.Result)
                    {
                        this.DialogResult = DialogResult.OK;
                        Program.mForm.MovePrev();
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error,
                            string.Format("該当するデータは登録されていません。[大分類コード：{0}][メモコード：{1}]",
                            new string[] { _memoDaibunruiCd, _memoCd }));
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

        #region reInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： reInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_updateMode == DispMode.Add)
                {
                    _dispMode = DispMode.Add;
                }
                else if (_updateMode == DispMode.Edit)
                {
                    _dispMode = DispMode.Edit;
                }

                SetControlModeView();
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

        #region decisionButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： decisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoUpdate();
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
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //// Enable menu
                //Program.mForm.SetMenuEnabled(true);

                if (_dispMode != DispMode.Detail)
                {
                    if (!CheckEdit())
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                            == System.Windows.Forms.DialogResult.Yes)
                        {
                            goto SHOWFORM;
                        }
                    }
                    else
                    {
                        goto SHOWFORM;
                    }
                }
                else
                {
                    goto SHOWFORM;
                }

                SHOWFORM:
                Program.mForm.SetMenuEnabled(true);
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

        #region MemoMstShosai_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MemoMstShosai_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// 2015/01/16  Mehara      v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MemoMstShosai_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                    case Keys.Alt | Keys.E:
                        entryButton.Focus();
                        entryButton.PerformClick();
                        break;

                    case Keys.F2:
                        changeButton.Focus();
                        changeButton.PerformClick();
                        break;

                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
                        break;

                    case Keys.F4:
                        reInputButton.Focus();
                        reInputButton.PerformClick();
                        break;

                    case Keys.F5:
                        decisionButton.Focus();
                        decisionButton.PerformClick();
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
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.MemoDaibunruiCd     = _memoDaibunruiCd;
            alInput.MemoCd              = _memoCd;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            Utility.Utility.SetListBoxSource(memoDaibunruiListBox, alOutput.MemoDaibunruiMstInfoDT, "MemoDaibunruiNm", "MemoDaibunruiCd");

            if (alOutput.MemoMstDT != null && alOutput.MemoMstDT.Count > 0)
            {
                SetValues(alOutput.MemoMstDT[0]);

                _dispDT = alOutput.MemoMstDT;
            }

            SetControlModeView();
        }
        #endregion

        #region SetValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetValues
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(MemoMstDataSet.MemoMstRow row)
        {
            // 大分類リスト
            memoDaibunruiListBox.SelectedValue = row.MemoDaibunruiCd;

            // 重要
            if (row.MemoJuyoFlg == "1")
            {
                juyodoCheckBox.Checked = true;
            }
            else if (row.MemoJuyoFlg == "0")
            {
                juyodoCheckBox.Checked = false; 
            }

            // 選択不可
            if (row.MemoSelectFlg == "1")
            {
                sentakuFlgCheckBox.Checked = true;
            }
            else if (row.MemoSelectFlg == "0")
            {
                sentakuFlgCheckBox.Checked = false;
            }

            // メモコード
            memoCdTextBox.Text = row.MemoCd;

            // メモ
            memoTextBox.Text = row.Memo;
        }
        #endregion

        #region SetControlModeView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlModeView
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // 大分類リスト
                    memoDaibunruiListBox.Enabled = true;

                    // 重要フラグ
                    juyodoCheckBox.Enabled = true;

                    // 選択フラグ
                    sentakuFlgCheckBox.Enabled = true;

                    // メモコード
                    memoCdTextBox.ReadOnly = true;

                    // メモ
                    memoTextBox.ReadOnly = false;

                    // 登録ボタン
                    entryButton.Visible = true;

                    // 変更ボタン
                    changeButton.Visible = false;

                    // 削除ボタン 
                    deleteButton.Visible = false;

                    // 再入力ボタン 
                    reInputButton.Visible = false;

                    // 確定ボタン
                    decisionButton.Visible = false;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    Program.mForm.Text = "メモマスタ登録";
                    this.Text = "メモマスタ登録";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:

                    // 大分類リスト
                    memoDaibunruiListBox.Enabled = false;

                    // 重要フラグ
                    juyodoCheckBox.Enabled = true;

                    // 選択フラグ
                    sentakuFlgCheckBox.Enabled = true;

                    // メモコード
                    memoCdTextBox.ReadOnly = true;

                    // メモ
                    memoTextBox.ReadOnly = false;

                    // 登録ボタン
                    entryButton.Visible = false;

                    // 変更ボタン
                    changeButton.Visible = true;

                    // 削除ボタン
                    deleteButton.Visible = false;

                    // 再入力ボタン
                    reInputButton.Visible = false;

                    // 確定ボタン
                    decisionButton.Visible = false;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    Program.mForm.Text = "メモマスタ変更";
                    this.Text = "メモマスタ変更";

                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // 大分類リスト
                    memoDaibunruiListBox.Enabled = false;

                    // 重要フラグ
                    juyodoCheckBox.Enabled = false;

                    // 選択フラグ
                    sentakuFlgCheckBox.Enabled = false;

                    // メモコード
                    memoCdTextBox.ReadOnly = true;

                    // メモ
                    memoTextBox.ReadOnly = true;

                    // 登録ボタン
                    entryButton.Visible = false;

                    // 変更ボタン
                    changeButton.Visible = true;

                    // 削除ボタン
                    deleteButton.Visible = true;

                    // 再入力ボタン
                    reInputButton.Visible = false;

                    // 確定ボタン
                    decisionButton.Visible = false;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    Program.mForm.Text = "メモマスタ詳細";
                    this.Text = "メモマスタ詳細";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // 大分類リスト
                    memoDaibunruiListBox.Enabled = false;

                    // 重要フラグ
                    juyodoCheckBox.Enabled = false;

                    // 選択フラグ
                    sentakuFlgCheckBox.Enabled = false;

                    // メモコード
                    memoCdTextBox.ReadOnly = true;

                    // メモ
                    memoTextBox.ReadOnly = true;

                    // 登録ボタン
                    entryButton.Visible = false;

                    // 変更ボタン
                    changeButton.Visible = false;

                    // 削除ボタン
                    deleteButton.Visible = false;

                    // 再入力ボタン
                    reInputButton.Visible = true;

                    // 確定ボタン
                    decisionButton.Visible = true;

                    // 閉じるボタン
                    closeButton.Visible = true;

                    Program.mForm.Text = "メモマスタ入力確認";
                    this.Text = "メモマスタ入力確認";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
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
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // メモ
            if (string.IsNullOrEmpty(memoTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：メモが入力されていません。\r\n");
            }
            else
            {
                if (memoTextBox.Text.Trim().Length > 100)
                {
                    errMess.Append("メモは100文字以下で入力して下さい。\r\n");
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

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            MemoMstDataSet.MemoMstDataTable updateDT = new MemoMstDataSet.MemoMstDataTable();

            if (_updateMode == DispMode.Add)
            {
                updateDT = CreateDataInsert();
            }
            else
            {
                updateDT = CreateDataUpdate(_dispDT);
            }

            IDecisionBtnClickALInput alInput    = new DecisionBtnClickALInput();
            alInput.DispMode                    = _updateMode;
            alInput.MemoMstDT                   = updateDT;
            IDecisionBtnClickALOutput alOutput  = new DecisionBtnClickApplicationLogic().Execute(alInput);

            if (!string.IsNullOrEmpty(alOutput.ErrMessage))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();
            }
        }
        #endregion

        #region CreateDataInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private MemoMstDataSet.MemoMstDataTable CreateDataInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            MemoMstDataSet.MemoMstDataTable insertDT = new MemoMstDataSet.MemoMstDataTable();

            MemoMstDataSet.MemoMstRow insertRow = insertDT.NewMemoMstRow();

            // メモ大分類コード
            insertRow.MemoDaibunruiCd = memoDaibunruiListBox.SelectedValue.ToString();

            // メモコード
            insertRow.MemoCd = Utility.Saiban.GetKeyRenban("MemoMst", memoDaibunruiListBox.SelectedValue.ToString(), "", "").PadLeft(3, '0');

            // メモ
            insertRow.Memo = memoTextBox.Text.Trim();

            // 重要フラグ
            insertRow.MemoJuyoFlg = juyodoCheckBox.Checked ? "1" : "0";

            // 選択フラグ
            insertRow.MemoSelectFlg = sentakuFlgCheckBox.Checked ? "1" : "0";         

            insertRow.InsertDt = now;
            insertRow.InsertTarm = pcUpdate;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = pcUpdate;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddMemoMstRow(insertRow);

            // 行の状態を設定
            insertRow.AcceptChanges();

            // 行の状態を設定（新規）
            insertRow.SetAdded();

            return insertDT;
        }
        #endregion

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private MemoMstDataSet.MemoMstDataTable CreateDataUpdate(MemoMstDataSet.MemoMstDataTable dataTable)
        {
            // メモ
            dataTable[0].Memo = memoTextBox.Text.Trim();

            // 重要フラグ
            dataTable[0].MemoJuyoFlg = juyodoCheckBox.Checked ? "1" : "0";

            // 選択フラグ
            dataTable[0].MemoSelectFlg = sentakuFlgCheckBox.Checked ? "1" : "0";     
            
            return dataTable;
        }
        #endregion

        #region CheckEdit
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckEdit
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            //check edit mode add
            if (string.IsNullOrEmpty(_memoDaibunruiCd) && string.IsNullOrEmpty(_memoCd))
            {
                if (memoDaibunruiListBox.SelectedIndex != 0
                    || memoTextBox.Text != string.Empty
                    || juyodoCheckBox.Checked
                    || sentakuFlgCheckBox.Checked)
                {
                    return false;
                }
            }

            if (_dispDT != null && _dispDT.Count > 0)
            {
                if (memoDaibunruiListBox.SelectedValue.ToString() != _dispDT[0].MemoDaibunruiCd
                        || memoTextBox.Text != _dispDT[0].Memo
                        || (juyodoCheckBox.Checked && _dispDT[0].MemoJuyoFlg == "0")
                        || (!juyodoCheckBox.Checked && _dispDT[0].MemoJuyoFlg == "1")
                        || (sentakuFlgCheckBox.Checked && _dispDT[0].MemoJuyoFlg == "1")
                        || (!sentakuFlgCheckBox.Checked && _dispDT[0].MemoJuyoFlg == "0")
                    )
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #endregion
    }
    #endregion
}
