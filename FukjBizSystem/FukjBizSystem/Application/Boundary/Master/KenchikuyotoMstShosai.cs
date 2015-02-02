using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.KenchikuyotoMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KenchikuyotoMstListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KenchikuyotoMstShosaiForm : FukjBaseForm
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

        #region プロパティ(public)

        /// <summary>
        /// displayMode
        /// </summary>
        public DispMode _displayMode = DispMode.Add;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// kenchikuyotoDaibunruiCd
        /// </summary>
        private string _kenchikuyotoDaibunruiCd = string.Empty;

        /// <summary>
        /// kenchikuyotoShobunruiCd
        /// </summary>
        private string _kenchikuyotoShobunruiCd = string.Empty;

        /// <summary>
        /// kenchikuyotoRenban
        /// </summary>
        private string _kenchikuyotoRenban = string.Empty;

        /// <summary>
        /// kenchikuyotoMstDataTable
        /// </summary>
        private KenchikuyotoMstDataSet.KenchikuyotoMstDataTable _kenchikuyotoMstDataTable = new KenchikuyotoMstDataSet.KenchikuyotoMstDataTable();

        /// <summary>
        /// kenchikuyotoDaibunruiMstDataTable 
        /// </summary>
        private KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable _kenchikuyotoDaibunruiMstDataTable = new KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable();

        /// <summary>
        /// kenchikuyotoShobunruiMstDataTable
        /// </summary>
        private KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable _kenchikuyotoShobunruiMstDataTable = new KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KenchikuyotoMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KenchikuyotoMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KenchikuyotoMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="kenchikuyotoDaibunruiCd"></param>
        /// <param name="kenchikuyotoShobunruiCd"></param>
        /// <param name="kenchikuyotoRenban"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KenchikuyotoMstShosaiForm(string kenchikuyotoDaibunruiCd, string kenchikuyotoShobunruiCd, string kenchikuyotoRenban)
        {
            InitializeComponent();

            this._kenchikuyotoDaibunruiCd = kenchikuyotoDaibunruiCd;
            this._kenchikuyotoShobunruiCd = kenchikuyotoShobunruiCd;
            this._kenchikuyotoRenban = kenchikuyotoRenban;
        }
        #endregion

        #region イベント

        #region KenchikuyotoMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KenchikuyotoMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KenchikuyotoMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();

                SetDisplayControl();
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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidData())
                {
                    return;
                }

                this._displayMode = DispMode.Confirm;

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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._displayMode == DispMode.Edit)
                {
                    if (!IsValidData())
                    {
                        return;
                    }
                    this._displayMode = DispMode.Confirm;
                }

                if (this._displayMode == DispMode.Detail)
                {
                    this._displayMode = DispMode.Edit;
                }

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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") != DialogResult.Yes) return;

                IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                alInput.KenchikuyotoDaibunruiCd = this._kenchikuyotoDaibunruiCd;
                alInput.KenchikuyotoShobunruiCd = this._kenchikuyotoShobunruiCd;
                alInput.KenchikuyotoRenban = Int32.Parse(this._kenchikuyotoRenban);

                IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                //check not exist record
                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    string kenchikuyotoDaibunruiNm = kenchikuyotoDaibunruiListBox.GetItemText(kenchikuyotoDaibunruiListBox.SelectedItem);
                    string kenchikuyotoShobunruiNm = kenchikuyotoShobunruiListBox.GetItemText(kenchikuyotoShobunruiListBox.SelectedItem);

                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format(alOutput.ErrMessage,
                        new string[] { kenchikuyotoDaibunruiNm, kenchikuyotoShobunruiNm, _kenchikuyotoRenban }));
                    return;
                }

                //close form and redirect KenchikuyotoMstListForm
                this.DialogResult = DialogResult.OK;
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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_kenchikuyotoDaibunruiCd) && string.IsNullOrEmpty(_kenchikuyotoShobunruiCd) && string.IsNullOrEmpty(_kenchikuyotoRenban))
                {
                    this._displayMode = DispMode.Add;
                }
                else
                {
                    this._displayMode = DispMode.Edit;
                }

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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();

                //insert data
                if (string.IsNullOrEmpty(this._kenchikuyotoDaibunruiCd) && string.IsNullOrEmpty(this._kenchikuyotoShobunruiCd) && string.IsNullOrEmpty(this._kenchikuyotoRenban))
                {
                    alInput.DisplayMode = DispMode.Add;
                    alInput.KenchikuyotoMstDataTable = CreateKenchikuyotoMstInsert();
                }
                else
                {
                    //update data
                    alInput.DisplayMode = DispMode.Edit;
                    alInput.KenchikuyotoMstDataTable = CreateKenchikuyotoMstUpdate(_kenchikuyotoMstDataTable);
                }

                IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    string kenchikuyotoDaibunruiNm = kenchikuyotoDaibunruiListBox.GetItemText(kenchikuyotoDaibunruiListBox.SelectedItem);
                    string kenchikuyotoShobunruiNm = kenchikuyotoShobunruiListBox.GetItemText(kenchikuyotoShobunruiListBox.SelectedItem);

                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format(alOutput.ErrMessage,
                        new string[] { kenchikuyotoDaibunruiNm, kenchikuyotoShobunruiNm, alInput.KenchikuyotoMstDataTable[0].KenchikuyotoRenban.ToString() }));
                    return;
                }

                //close form and redirect KenchikuyotoMstListForm
                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();
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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._displayMode != DispMode.Detail && IsEditedControl())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // Enable menu
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

        #region KenchikuyotoMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KenchikuyotoMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KenchikuyotoMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            
            alInput.HenchikuyotoDaibunruiCd = _kenchikuyotoDaibunruiCd;
            alInput.KenchikuyotoShobunruiCd = _kenchikuyotoShobunruiCd;
            alInput.KenchikuyotoRenban = (string.IsNullOrEmpty(_kenchikuyotoRenban))? 0 : Int32.Parse(_kenchikuyotoRenban);

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            this._kenchikuyotoMstDataTable = alOutput.KenchikuyotoMstDataTable;
            this._kenchikuyotoDaibunruiMstDataTable = alOutput.KenchikuyotoDaibunruiMstDataTable;
            this._kenchikuyotoShobunruiMstDataTable = alOutput.KenchikuyotoShobunruiMstDataTable;

            if (!string.IsNullOrEmpty(_kenchikuyotoDaibunruiCd)
                && !string.IsNullOrEmpty(_kenchikuyotoShobunruiCd)
                && !string.IsNullOrEmpty(_kenchikuyotoRenban))
            {
                this._displayMode = DispMode.Detail;
                this.Text = "建築用途マスタ詳細";

                SetDefaultValueControl();
            }
            else
            {
                // Set data Daibunrui listbox
                Utility.Utility.SetListBoxSource(kenchikuyotoDaibunruiListBox, _kenchikuyotoDaibunruiMstDataTable, "KenchikuyotoDaibunruiNm", "KenchikuyotoDaibunruiCd");

                // Set data Shobunrui listbox
                Utility.Utility.SetListBoxSource(kenchikuyotoShobunruiListBox, _kenchikuyotoShobunruiMstDataTable, "KenchikuyotoShobunruiNm", "KenchikuyotoShobunruiCd");
            }

            kenchikuyotoDaibunruiListBox.SelectedIndex = _kenchikuyotoDaibunruiMstDataTable.Count > 0 ? 0 : -1;
            kenchikuyotoShobunruiListBox.SelectedIndex = _kenchikuyotoShobunruiMstDataTable.Count > 0 ? 0 : -1;
        }
        #endregion

        #region SetDefaultValueControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValueControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            if (this._kenchikuyotoMstDataTable.Count > 0)
            {
                foreach (KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstRow row in _kenchikuyotoDaibunruiMstDataTable.Select(string.Format("KenchikuyotoDaibunruiCd = '{0}'", _kenchikuyotoDaibunruiCd)))
                {
                    kenchikuyotoDaibunruiListBox.Items.Add(row.KenchikuyotoDaibunruiNm);
                }

                foreach (KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstRow row in _kenchikuyotoShobunruiMstDataTable.Select(string.Format("KenchikuyotoShobunruiCd = '{0}'", _kenchikuyotoShobunruiCd)))
                {
                    kenchikuyotoShobunruiListBox.Items.Add(row.KenchikuyotoShobunruiNm);
                }

                kenchikuyotoRenbanTextBox.Text = _kenchikuyotoMstDataTable[0].KenchikuyotoRenban.ToString();
                kenchikuyotoNmTextBox.Text = _kenchikuyotoMstDataTable[0].KenchikuyotoNm;
            }
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
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            kenchikuyotoDaibunruiListBox.Enabled = !(this._displayMode == DispMode.Add) ? false : true;
            kenchikuyotoShobunruiListBox.Enabled = !(this._displayMode == DispMode.Add) ? false : true;

            kenchikuyotoNmTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //登録ボタン 
            entryButton.Visible = (this._displayMode == DispMode.Add) ? true : false;

            //変更ボタン 
            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            //削除ボタン 
            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            //再入力ボタン
            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //確定ボタン 
            decisionButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //change screen title
            SetScreenTitle();
        }
        #endregion

        #region SetScreenTitle
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetScreenTitle
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (this._displayMode)
            {
                case DispMode.Add:
                    Program.mForm.Text = "建築用途マスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "建築用途マスタ変更";
                    Program.mForm.SetMenuEnabled(false);
                    break;
                case DispMode.Detail:
                    Program.mForm.Text = "建築用途マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "建築用途マスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
            }
        }
        #endregion

        #region IsValidData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            string errMsg = string.Empty;

            //建築用途名称
            if (string.IsNullOrEmpty(kenchikuyotoNmTextBox.Text.Trim()))
            {
                errMsg += "必須項目：建築用途名称が入力されていません。";
            }
            else if (kenchikuyotoNmTextBox.Text.Trim().Length > 20)
            {
                errMsg += "建築用途名称は20文字以下で入力して下さい。";
            }

            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region IsEditedControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsEditedControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedControl()
        {
            //check edit default value mode Add
            if (string.IsNullOrEmpty(_kenchikuyotoDaibunruiCd) && string.IsNullOrEmpty(this._kenchikuyotoShobunruiCd) && string.IsNullOrEmpty(_kenchikuyotoRenban))
            {
                if (kenchikuyotoDaibunruiListBox.SelectedIndex > 0
                    || kenchikuyotoShobunruiListBox.SelectedIndex > 0
                    || !string.IsNullOrEmpty(kenchikuyotoNmTextBox.Text))
                {
                    return true;
                }
            }
            else
            {
                if (_kenchikuyotoMstDataTable.Count != 0 && kenchikuyotoNmTextBox.Text.Trim() != _kenchikuyotoMstDataTable[0].KenchikuyotoNm)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region CreateKenchikuyotoMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKenchikuyotoMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KenchikuyotoMstDataSet.KenchikuyotoMstDataTable CreateKenchikuyotoMstInsert()
        {
            KenchikuyotoMstDataSet.KenchikuyotoMstDataTable kenchikuyotoMstDataTable = new KenchikuyotoMstDataSet.KenchikuyotoMstDataTable();
            KenchikuyotoMstDataSet.KenchikuyotoMstRow newRow = kenchikuyotoMstDataTable.NewKenchikuyotoMstRow();

            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string tarmName = Dns.GetHostName();

            //建築用途大分類
            newRow.KenchikuyotoDaibunrui = kenchikuyotoDaibunruiListBox.SelectedValue.ToString();

            //建築用途小分類
            newRow.KenchikuyotoShobunrui = kenchikuyotoShobunruiListBox.SelectedValue.ToString();

            //建築用途連番
            newRow.KenchikuyotoRenban = Int32.Parse(Utility.Saiban.GetKeyRenban("KenchikuyotoMst", kenchikuyotoDaibunruiListBox.SelectedValue.ToString(), kenchikuyotoShobunruiListBox.SelectedValue.ToString(), ""));

            //建築用途名称
            newRow.KenchikuyotoNm = kenchikuyotoNmTextBox.Text.Trim();

            //登録日
            newRow.InsertDt = currentDateTime;

            //登録者
            newRow.InsertUser = loginUser;

            //登録端末
            newRow.InsertTarm = tarmName;

            //更新日
            newRow.UpdateDt = currentDateTime;

            //更新者
            newRow.UpdateUser = loginUser;

            //更新端末
            newRow.UpdateTarm = tarmName;

            // 行を挿入
            kenchikuyotoMstDataTable.AddKenchikuyotoMstRow(newRow);

            //行の状態を設定
            newRow.AcceptChanges();

            newRow.SetAdded();

            return kenchikuyotoMstDataTable;

        }
        #endregion

        #region CreateKenchikuyotoMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKenchikuyotoMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KenchikuyotoMstDataSet.KenchikuyotoMstDataTable CreateKenchikuyotoMstUpdate(KenchikuyotoMstDataSet.KenchikuyotoMstDataTable kenchikuyotoMstDataTable)
        {
            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string tarmName = Dns.GetHostName();

            //建築用途名称
            kenchikuyotoMstDataTable[0].KenchikuyotoNm = kenchikuyotoNmTextBox.Text.Trim();

            //更新者
            kenchikuyotoMstDataTable[0].UpdateUser = loginUser;

            //更新端末
            kenchikuyotoMstDataTable[0].UpdateTarm = tarmName;

            return kenchikuyotoMstDataTable;

        }
        #endregion

        #endregion

    }
    #endregion
}
