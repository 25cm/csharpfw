using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.ShokenMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShokenShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25　HuyTX     新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShokenMstShosaiForm : FukjBaseForm
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
        /// shokenKbn
        /// </summary>
        private string _shokenKbn = string.Empty;

        /// <summary>
        /// shokenCd
        /// </summary>
        private string _shokenCd = string.Empty;

        /// <summary>
        /// shokenMstDataTable
        /// </summary>
        private ShokenMstDataSet.ShokenMstDataTable _shokenMstDataTable = new ShokenMstDataSet.ShokenMstDataTable();

        /// <summary>
        /// isLoad
        /// </summary>
        private bool _isLoad = false;

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// loginUser
        /// </summary>
        private string _loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// loginTarm 
        /// </summary>
        private string _loginTarm = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShokenShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShokenMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShokenShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="shokenCd"></param>
        /// <param name="shokenKbn"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShokenMstShosaiForm(string shokenKbn, string shokenCd)
        {
            InitializeComponent();
            this._shokenKbn = shokenKbn;
            this._shokenCd = shokenCd;
        }
        #endregion

        #region イベント

        #region ShokenMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShokenMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShokenMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

                DoFormLoad();

                SetDisplayControl();

                _isLoad = true;

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

        #region shokenKbnTextBox_TextChanged
        // 2015/01/23 DatNT DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： shokenKbnTextBox_TextChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/25　HuyTX　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void shokenKbnTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        shokenKbnNmComboBox.SelectedValue = shokenKbnTextBox.Text.Trim();
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        #endregion

        #region shokenKbnTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shokenKbnTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shokenKbnTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(shokenKbnTextBox, shokenKbnTextBox, shokenKbnTextBox);

                shokenKbnNmComboBox.SelectedValue = shokenKbnTextBox.Text.Trim();
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

        #region shokenKbnNmComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shokenKbnNmComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shokenKbnNmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shokenKbnNmComboBox.SelectedIndex == -1 || !_isLoad) return;

                shokenKbnTextBox.Text = shokenKbnNmComboBox.SelectedValue.ToString();

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

        #region shokenCheckNoTextBox_TextChanged
        // 2015/01/23 DatNT DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： shokenCheckNoTextBox_TextChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/25　HuyTX　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void shokenCheckNoTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        shokenCheckNoNmComboBox.SelectedValue = shokenCheckNoTextBox.Text.Trim();
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        #endregion

        #region shokenCheckNoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shokenCheckNoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shokenCheckNoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(shokenCheckNoTextBox, shokenCheckNoTextBox, shokenCheckNoTextBox);

                shokenCheckNoNmComboBox.SelectedValue = shokenCheckNoTextBox.Text.Trim();
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

        #region shokenCheckNoNmComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shokenCheckNoNmComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shokenCheckNoNmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shokenCheckNoNmComboBox.SelectedIndex == -1 || !_isLoad) return;
                
                shokenCheckNoTextBox.Text = shokenCheckNoNmComboBox.SelectedValue.ToString();
                
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

        #region entryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： entryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidData()) return;

                _displayMode = DispMode.Confirm;

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
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
                    if (!IsValidData()) return;

                    _displayMode = DispMode.Confirm;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
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
                alInput.ShokenKbn = _shokenKbn;
                alInput.ShokenCd = _shokenCd;

                IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                //check not exist record
                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                    return;
                }

                //close form and redirect ShokenMstListForm
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_shokenKbn) && string.IsNullOrEmpty(_shokenCd))
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
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
                if (string.IsNullOrEmpty(_shokenKbn) && string.IsNullOrEmpty(_shokenCd))
                {
                    alInput.DisplayMode = DispMode.Add;
                    alInput.ShokenMstDataTable = CreateShokenMstInsert();
                }
                else
                {
                    //update data
                    alInput.DisplayMode = DispMode.Edit;
                    alInput.ShokenMstDataTable = CreateShokenMstUpdate(_shokenMstDataTable);
                }

                IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                    return;
                }

                //close form and redirect ShokenMstListForm
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_displayMode != DispMode.Detail )
                {
                    if (IsEditedControl() && MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes) return;
                }

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

        #region ShokenMstShosai_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShokenMstShosai_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShokenMstShosai_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
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

        #region shokenCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shokenCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shokenCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(shokenCdTextBox, shokenCdTextBox, shokenCdTextBox);
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
        /// 2014/08/25　HuyTX    新規作成
        /// 2014/11/03　HuyTX    Ver1.02
        /// 2015/01/26  DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShokenKbn = _shokenKbn;
            alInput.ShokenCd = _shokenCd;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            _shokenMstDataTable = alOutput.ShokenMstDataTable;

            //set data to shokenKbnNmComboBox
            Utility.Utility.SetComboBoxList(shokenKbnNmComboBox, alOutput.GaikankensaKomokuMstDataTable, "GaikankensaKomokuNm", "GaikankensaKomokuCd", true);

            //重要度(5)
            //Utility.Utility.SetComboBoxList(shokenJuyodoComboBox, alOutput.NameMst010DataTable, "Name", "NameCdValue1", true);
            Utility.Utility.SetComboBoxList(shokenJuyodoComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_012), "ConstNm", "ConstValue", true);

            //判断(6)
            //Utility.Utility.SetComboBoxList(shokenHandanComboBox, alOutput.NameMst013DataTable, "Name", "NameCdValue1", true);
            Utility.Utility.SetComboBoxList(shokenHandanComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_015) , "ConstNm", "ConstValue", true);

            //表記順優先度(7)  Ver1.02
            Utility.Utility.SetComboBoxList(shokenYusendoComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_012), "ConstNm", "ConstValue", true);

            //判定(8)
            //Utility.Utility.SetComboBoxList(shokenHanteiComboBox, alOutput.NameMst014DataTable, "Name", "NameCdValue1", true);
            Utility.Utility.SetComboBoxList(shokenHanteiComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_016), "ConstNm", "ConstValue", true);

            //指摘区分(9)
            //Utility.Utility.SetComboBoxList(shokenShitekiKbnComboBox, alOutput.NameMst011DataTable, "Name", "NameCdValue1", true);
            Utility.Utility.SetComboBoxList(shokenShitekiKbnComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_013), "ConstNm", "ConstValue", true);

            //行政報告レベル(10)
            //Utility.Utility.SetComboBoxList(gyoseiHokokuLevelComboBox, alOutput.NameMst015DataTable, "Name", "NameCdValue1", true);
            Utility.Utility.SetComboBoxList(gyoseiHokokuLevelComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_017), "ConstNm", "ConstValue", true);

            //指摘箇所(11)
            //Utility.Utility.SetComboBoxList(shokenShitekiKashoComboBox, alOutput.NameMst012DataTable, "Name", "NameCdValue2", true);
            Utility.Utility.SetComboBoxList(shokenShitekiKashoComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_014), "ConstNm", "ConstValue", true);

            //同時チェック番号名称(13)
            Utility.Utility.SetComboBoxList(shokenCheckNoNmComboBox, alOutput.GaikankensaKomokuMstDataTable, "GaikankensaKomokuNm", "GaikankensaKomokuCd", true);

            //同時チェック判断(14)  Ver1.02
            Utility.Utility.SetComboBoxList(shokenCheckHandanCombobox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_015), "ConstNm", "ConstValue", true);

            // 2015/01/26 DatNT v1.03 ADD Start
            // 対象検査
            Utility.Utility.SetComboBoxList(shokenTaishoKensaBitMaskComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_076), "ConstNm", "ConstValue", true);
            // 2015/01/26 DatNT v1.03 ADD End

            if (!string.IsNullOrEmpty(_shokenKbn) && !string.IsNullOrEmpty(_shokenCd))
            {
                this._displayMode = DispMode.Detail;
                this.Text = "所見マスタ詳細";

                SetDefaultValueControl();
            }
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
        /// 2014/08/25　HuyTX    新規作成
        /// 2014/11/03　HuyTX    Ver1.02
        /// 2015/01/23  DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            if (_shokenMstDataTable.Count == 0) return;

            //所見区分
            shokenKbnTextBox.Text = _shokenMstDataTable[0].ShokenKbn;

            //所見区分名称
            //shokenKbnTextBox_TextChanged(null, null);
            shokenKbnTextBox_Leave(null, null);

            //所見コード
            shokenCdTextBox.Text = _shokenMstDataTable[0].ShokenCd;

            //重要度
            shokenJuyodoComboBox.SelectedValue = _shokenMstDataTable[0].ShokenJuyodo;

            //判断
            shokenHandanComboBox.SelectedValue = _shokenMstDataTable[0].ShokenHandan;

            //表記順優先度  Ver1.02
            shokenYusendoComboBox.SelectedValue = _shokenMstDataTable[0].ShokenHyokiJun;

            //判定
            shokenHanteiComboBox.SelectedValue = _shokenMstDataTable[0].ShokenHantei;

            //指摘区分
            shokenShitekiKbnComboBox.SelectedValue = _shokenMstDataTable[0].ShokenShitekiKbn;

            //行政報告レベル
            gyoseiHokokuLevelComboBox.SelectedValue = _shokenMstDataTable[0].ShokenHokokuLevel;

            //指摘箇所
            shokenShitekiKashoComboBox.SelectedValue = _shokenMstDataTable[0].ShokenShitekiNo;

            //チェック番号
            shokenCheckNoTextBox.Text = _shokenMstDataTable[0].ShokenDojiCheckKomoku.Trim();

            //チェック番号名称
            //shokenCheckNoTextBox_TextChanged(null, null);
            shokenCheckNoTextBox_Leave(null, null);

            //同時チェック判断  Ver1.02
            shokenCheckHandanCombobox.SelectedValue = _shokenMstDataTable[0].ShokenDojiCheckHandan;

            //所見文章
            shokenBunshoTextBox.Text = _shokenMstDataTable[0].ShokenWd;

            //備考
            shokenBikoTextBox.Text = _shokenMstDataTable[0].ShokenBiko;

            // 2015/01/23 DatNT v1.03 ADD Start

            // フォロー対象フラグ
            if (_shokenMstDataTable[0].ShokenFollowFlg == "1")
            {
                shokenFollowFlgCheckBox.Checked = true;
            }
            else
            {
                shokenFollowFlgCheckBox.Checked = false;
            }

            // 対象検査
            shokenTaishoKensaBitMaskComboBox.SelectedValue = _shokenMstDataTable[0].ShokenTaishoKensaBitMask;

            // 所見略文
            shokenWdRyakuTextBox.Text = _shokenMstDataTable[0].ShokenWdRyaku;

            // 2015/01/23 DatNT v1.03 ADD End
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
        /// 2014/08/25　HuyTX    新規作成
        /// 2014/11/03　HuyTX    Ver1.02
        /// 2015/01/23  DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            //所見区分
            shokenKbnTextBox.ReadOnly = (this._displayMode == DispMode.Add) ? false : true;

            //所見区分名称
            shokenKbnNmComboBox.Enabled = (this._displayMode == DispMode.Add) ? true : false;

            //所見コード
            shokenCdTextBox.ReadOnly = (this._displayMode == DispMode.Add) ? false : true;

            //重要度
            shokenJuyodoComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //判断
            shokenHandanComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //表記順優先度  Ver1.02
            shokenYusendoComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //判定
            shokenHanteiComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //指摘区分
            shokenShitekiKbnComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //行政報告レベル
            gyoseiHokokuLevelComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //指摘箇所
            shokenShitekiKashoComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //同時チェック番号
            shokenCheckNoTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //同時チェック名称
            shokenCheckNoNmComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //同時チェック判断  Ver1.02
            shokenCheckHandanCombobox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //所見文章
            shokenBunshoTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //備考
            shokenBikoTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            // 2015/01/23 DatNT v1.03 ADD Start
            // 所見略文
            shokenWdRyakuTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            // フォロー対象フラグ
            shokenFollowFlgCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            // 対象検査
            shokenTaishoKensaBitMaskComboBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;
            // 2015/01/23 DatNT v1.03 ADD End

            //登録ボタン (14)
            entryButton.Visible = (this._displayMode == DispMode.Add) ? true : false;

            //変更ボタン (15)
            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            //削除ボタン (16)
            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            //再入力ボタン (17) 
            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //確定ボタン (18) 
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
        /// 2014/08/25　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (this._displayMode)
            {
                case DispMode.Add:
                    Program.mForm.Text = "所見マスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "所見マスタ変更";
                    Program.mForm.SetMenuEnabled(false);
                    break;
                case DispMode.Detail:
                    Program.mForm.Text = "所見マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "所見マスタ入力確認";
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
        /// 2014/08/25　HuyTX    新規作成
        /// 2015/01/23  DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            //所見区分 (1)
            if (string.IsNullOrEmpty(shokenKbnTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：所見区分が入力されていません。");
            }
            else if (shokenKbnTextBox.Text.Trim().Length != 3)
            {
                errMsg.AppendLine("所見区分は3桁で入力して下さい。");
            }

            //所見コード (3)
            if (string.IsNullOrEmpty(shokenCdTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：所見コードが入力されていません。");
            }
            else if (shokenCdTextBox.Text.Trim().Length != 3)
            {
                errMsg.AppendLine("所見コードは3桁で入力して下さい。");
            }

            // 2015/01/23 DatNT v1.03 DEL Start
            ////重要度 (4)
            //if (shokenJuyodoComboBox.SelectedIndex <= 0)
            //{
            //    errMsg.AppendLine("必須項目：重要度が入力されていません。");
            //}

            ////判断 (5)
            //if (shokenHandanComboBox.SelectedIndex <= 0)
            //{
            //    errMsg.AppendLine("必須項目：判断が入力されていません。");
            //}

            ////表記順優先度  Ver1.02
            //if (shokenYusendoComboBox.SelectedIndex <= 0)
            //{
            //    errMsg.AppendLine("必須項目：表記順優先度が入力されていません。");
            //}

            ////判定 (6)
            //if (shokenHanteiComboBox.SelectedIndex <= 0)
            //{
            //    errMsg.AppendLine("必須項目：判定が入力されていません。");
            //}

            ////指摘区分 (7)
            //if (shokenShitekiKbnComboBox.SelectedIndex <= 0)
            //{
            //    errMsg.AppendLine("必須項目：指摘区分が入力されていません。");
            //}
            // 2015/01/23 DatNT v1.03 DEL End

            //チェック番号 (10)
            if (!string.IsNullOrEmpty(shokenCheckNoTextBox.Text.Trim()) && shokenCheckNoTextBox.Text.Trim().Length != 3)
            {
                errMsg.AppendLine("同時チェック番号は3桁で入力して下さい。");
            }

            //所見文章 (12)
            if (string.IsNullOrEmpty(shokenBunshoTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：所見文章が入力されていません。");
            }

            // 2015/01/23 DatNT v1.03 ADD Start
            // 所見略文
            if (string.IsNullOrEmpty(shokenWdRyakuTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：所見略文が入力されていません。");
            }
            // 2015/01/23 DatNT v1.03 ADD End

            if (!string.IsNullOrEmpty(errMsg.ToString()))
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
        /// 2014/08/25  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedControl()
        {
            //check edit default value mode Add
            if (string.IsNullOrEmpty(_shokenKbn) && string.IsNullOrEmpty(_shokenCd))
            {
                if (!string.IsNullOrEmpty(shokenKbnTextBox.Text.Trim())
                    || !string.IsNullOrEmpty(shokenCdTextBox.Text.Trim())
                    || shokenJuyodoComboBox.SelectedIndex > 0
                    || shokenHandanComboBox.SelectedIndex > 0
                    || shokenHanteiComboBox.SelectedIndex > 0
                    || shokenShitekiKbnComboBox.SelectedIndex > 0
                    || gyoseiHokokuLevelComboBox.SelectedIndex > 0
                    || shokenShitekiKashoComboBox.SelectedIndex > 0
                    || !string.IsNullOrEmpty(shokenCheckNoTextBox.Text.Trim())
                    || !string.IsNullOrEmpty(shokenBunshoTextBox.Text.Trim())
                    || !string.IsNullOrEmpty(shokenBikoTextBox.Text.Trim())
                    || shokenYusendoComboBox.SelectedIndex > 0
                    || shokenCheckHandanCombobox.SelectedIndex > 0
                    // 2015/01/26 DatNT v1.03 ADD Start
                    || shokenFollowFlgCheckBox.Checked
                    || shokenTaishoKensaBitMaskComboBox.SelectedIndex > 0
                    || !string.IsNullOrEmpty(shokenWdRyakuTextBox.Text.Trim())
                    // 2015/01/26 DatNT v1.03 ADD End
                    )
                {
                    return true;
                }
            }
            else
            {
                if (_shokenMstDataTable.Count != 0 &&
                    ((shokenJuyodoComboBox.SelectedValue != null && shokenJuyodoComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenJuyodo)
                    || (shokenHandanComboBox.SelectedValue != null && shokenHandanComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenHandan)
                    || (shokenHanteiComboBox.SelectedValue != null && shokenHanteiComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenHantei)
                    || (shokenShitekiKbnComboBox.SelectedValue != null && shokenShitekiKbnComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenShitekiKbn)
                    || (gyoseiHokokuLevelComboBox.SelectedValue!= null && gyoseiHokokuLevelComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenHokokuLevel)
                    || (shokenShitekiKashoComboBox.SelectedValue != null && shokenShitekiKashoComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenShitekiNo)
                    || shokenCheckNoTextBox.Text.Trim() != _shokenMstDataTable[0].ShokenDojiCheckKomoku.Trim()
                    || shokenBunshoTextBox.Text != _shokenMstDataTable[0].ShokenWd
                    || shokenBikoTextBox.Text != _shokenMstDataTable[0].ShokenBiko
                    || (shokenYusendoComboBox.SelectedValue != null && shokenYusendoComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenHyokiJun)
                    || (shokenCheckHandanCombobox.SelectedValue != null && shokenCheckHandanCombobox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenDojiCheckHandan))
                    // 2015/01/26 DatNT v1.03 ADD Start
                    || (shokenFollowFlgCheckBox.Checked && _shokenMstDataTable[0].ShokenFollowFlg == "0")
                    || (!shokenFollowFlgCheckBox.Checked && _shokenMstDataTable[0].ShokenFollowFlg == "1")
                    || (shokenTaishoKensaBitMaskComboBox.SelectedValue != null && shokenTaishoKensaBitMaskComboBox.SelectedValue.ToString() != _shokenMstDataTable[0].ShokenTaishoKensaBitMask.ToString())
                    || shokenWdRyakuTextBox.Text.Trim() != _shokenMstDataTable[0].ShokenWdRyaku
                    // 2015/01/26 DatNT v1.03 ADD End
                    )
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region CreateShokenMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokenMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  HuyTX　　    新規作成
        /// 2015/01/23  DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokenMstDataSet.ShokenMstDataTable CreateShokenMstInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            ShokenMstDataSet.ShokenMstDataTable shokenMstDT = new ShokenMstDataSet.ShokenMstDataTable();
            ShokenMstDataSet.ShokenMstRow newRow = shokenMstDT.NewShokenMstRow();

            //所見区分 (1)
            newRow.ShokenKbn = shokenKbnTextBox.Text.Trim();

            //所見コード (3)
            newRow.ShokenCd = shokenCdTextBox.Text.Trim();

            //重要度 (4)
            newRow.ShokenJuyodo = shokenJuyodoComboBox.SelectedValue.ToString();

            //判断 (5)
            newRow.ShokenHandan = shokenHandanComboBox.SelectedValue.ToString();

            //表記順優先度 Ver1.02
            newRow.ShokenHyokiJun = shokenYusendoComboBox.SelectedValue.ToString();

            //判定 (6)
            newRow.ShokenHantei = shokenHanteiComboBox.SelectedValue.ToString();

            //指摘区分 (7)
            newRow.ShokenShitekiKbn = shokenShitekiKbnComboBox.SelectedValue.ToString();

            //行政報告レベル (8)
            newRow.ShokenHokokuLevel = gyoseiHokokuLevelComboBox.SelectedValue.ToString();

            //指摘箇所 (9)
            newRow.ShokenShitekiNo = shokenShitekiKashoComboBox.SelectedValue.ToString();

            //同時チェック番号 (10)
            newRow.ShokenDojiCheckKomoku = shokenCheckNoTextBox.Text.Trim();

            //同時チェック判断  Ver1.02
            newRow.ShokenDojiCheckHandan = shokenCheckHandanCombobox.SelectedIndex > 0 ? shokenCheckHandanCombobox.SelectedValue.ToString() : string.Empty;

            //所見文章 (12)
            newRow.ShokenWd = shokenBunshoTextBox.Text.Trim();

            //備考 (13)
            newRow.ShokenBiko = shokenBikoTextBox.Text.Trim();

            // フォロー対象フラグ
            newRow.ShokenFollowFlg = shokenFollowFlgCheckBox.Checked ? "1" : "0";

            // 対象検査ビットマスク
            int mask;
            if (shokenTaishoKensaBitMaskComboBox.SelectedValue != null)
            {
                if (int.TryParse(shokenTaishoKensaBitMaskComboBox.SelectedValue.ToString(), out mask))
                {
                    newRow.ShokenTaishoKensaBitMask = mask;
                }
                else
                {
                    newRow.ShokenTaishoKensaBitMask = 0;
                }
            }
            else
            {
                newRow.ShokenTaishoKensaBitMask = 0;
            }

            // 所見略文
            newRow.ShokenWdRyaku = shokenWdRyakuTextBox.Text.Trim();

            //登録日
            newRow.InsertDt = now;

            //登録者
            newRow.InsertUser = _loginUser;

            //登録端末
            newRow.InsertTarm = _loginTarm;

            //更新日
            newRow.UpdateDt = now;

            //更新者
            newRow.UpdateUser = _loginUser;

            //更新端末
            newRow.UpdateTarm = _loginTarm;

            // 行を挿入
            shokenMstDT.AddShokenMstRow(newRow);

            //行の状態を設定
            newRow.AcceptChanges();

            newRow.SetAdded();

            return shokenMstDT;

        }
        #endregion

        #region CreateShokenMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokenMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokenMstDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  HuyTX　　    新規作成
        /// 2015/01/23  DatNT       v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokenMstDataSet.ShokenMstDataTable CreateShokenMstUpdate(ShokenMstDataSet.ShokenMstDataTable shokenMstDT)
        {
            //重要度 (4)
            if (shokenJuyodoComboBox.SelectedValue != null)
            {
                shokenMstDT[0].ShokenJuyodo = shokenJuyodoComboBox.SelectedValue.ToString();
            }
            else
            {
                shokenMstDT[0].ShokenJuyodo = string.Empty;
            }

            //判断 (5)
            if (shokenJuyodoComboBox.SelectedValue != null)
            {
                shokenMstDT[0].ShokenHandan = shokenHandanComboBox.SelectedValue.ToString();
            }
            else
            {
                shokenMstDT[0].ShokenHandan = string.Empty;
            }

            //表記順優先度  Ver1.02
            if (shokenYusendoComboBox.SelectedValue != null)
            {
                shokenMstDT[0].ShokenHyokiJun = shokenYusendoComboBox.SelectedValue.ToString();
            }
            else
            {
                shokenMstDT[0].ShokenHyokiJun = string.Empty;
            }

            //判定 (6)
            if (shokenHanteiComboBox.SelectedValue != null)
            {
                shokenMstDT[0].ShokenHantei = shokenHanteiComboBox.SelectedValue.ToString();
            }
            else
            {
                shokenMstDT[0].ShokenHantei = string.Empty;
            }

            //指摘区分 (7)
            if (shokenShitekiKbnComboBox.SelectedValue != null)
            {
                shokenMstDT[0].ShokenShitekiKbn = shokenShitekiKbnComboBox.SelectedValue.ToString();
            }
            else
            {
                shokenMstDT[0].ShokenShitekiKbn = string.Empty;
            }

            //行政報告レベル (8)
            shokenMstDT[0].ShokenHokokuLevel = (gyoseiHokokuLevelComboBox.SelectedIndex > 0) ? gyoseiHokokuLevelComboBox.SelectedValue.ToString() : " ";

            //指摘箇所 (9)
            shokenMstDT[0].ShokenShitekiNo = (shokenShitekiKashoComboBox.SelectedIndex > 0) ? shokenShitekiKashoComboBox.SelectedValue.ToString() : "  ";

            //同時チェック項目 (10)
            shokenMstDT[0].ShokenDojiCheckKomoku = shokenCheckNoTextBox.Text.Trim();

            //同時チェック判断  Ver1.02
            shokenMstDT[0].ShokenDojiCheckHandan = shokenCheckHandanCombobox.SelectedIndex > 0 ? shokenCheckHandanCombobox.SelectedValue.ToString() : string.Empty;

            //所見文章 (12)
            shokenMstDT[0].ShokenWd = shokenBunshoTextBox.Text.Trim();

            //備考 (13)
            shokenMstDT[0].ShokenBiko = shokenBikoTextBox.Text.Trim();

            //更新者
            shokenMstDT[0].UpdateUser = _loginUser;

            //更新端末
            shokenMstDT[0].UpdateTarm = _loginTarm;

            // 2015/01/23 DatNT v1.03 ADD Start
            // 所見略文
            shokenMstDT[0].ShokenWdRyaku = shokenWdRyakuTextBox.Text.Trim();

            // フォロー対象フラグ
            shokenMstDT[0].ShokenFollowFlg = shokenFollowFlgCheckBox.Checked ? "1" : "0";

            // 対象検査ビットマスク
            int mask;
            if (shokenTaishoKensaBitMaskComboBox.SelectedValue != null)
            {
                if (int.TryParse(shokenTaishoKensaBitMaskComboBox.SelectedValue.ToString(), out mask))
                {
                    shokenMstDT[0].ShokenTaishoKensaBitMask = mask;
                }
                else
                {
                    shokenMstDT[0].ShokenTaishoKensaBitMask = 0;
                }
            }
            else
            {
                shokenMstDT[0].ShokenTaishoKensaBitMask = 0;
            }
            // 2015/01/23 DatNT v1.03 ADD End

            return shokenMstDT;

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
        /// 2015/01/23　DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 所見略文
            shokenWdRyakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
        }
        #endregion

        #endregion
    }
    #endregion
}
