using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.ShokuinMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShokuinMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShokuinMstShosaiForm : FukjBaseForm
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
        /// shokuinCd
        /// </summary>
        private string _shokuinCd = string.Empty;

        /// <summary>
        /// shokuinMstDT
        /// </summary>
        ShokuinMstDataSet.ShokuinMstDataTable _shokuinMstDT = new ShokuinMstDataSet.ShokuinMstDataTable();

        /// <summary>
        /// shozokuMstDT
        /// </summary>
        ShozokuMstDataSet.ShozokuMstDataTable _shozokuMstDT = new ShozokuMstDataSet.ShozokuMstDataTable();

        /// <summary>
        /// shozokuCount
        /// </summary>
        private int _shozokuCount = 0;

        /// <summary>
        /// currentDt
        /// </summary>
        private DateTime _currentDt = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShokuinMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShokuinMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShokuinMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="shokuinCd"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShokuinMstShosaiForm(string shokuinCd)
        {
            this._shokuinCd = shokuinCd;
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region ShokuinMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShokuinMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShokuinMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

                this.shozokuMstTableAdapter.Fill(this.shozokuMstDataSet.ShozokuMst);
                this.yakushokuMstTableAdapter.Fill(this.yakushokuMstDataSet.YakushokuMst);
                this.bushoMstTableAdapter.Fill(this.bushoMstDataSet.BushoMst);

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DataCheck())
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
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
                    if (!DataCheck())
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") == DialogResult.Yes)
                {
                    IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                    alInput.ShokuinCd = this._shokuinCd;

                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    //check not exist record
                    if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                        return;
                    }

                    //close form and redirect ShokuinMstListForm
                    this.DialogResult = DialogResult.OK;
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
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(this._shokuinCd))
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
        /// 2014/07/07　HuyTX　　    新規作成
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
                if (string.IsNullOrEmpty(this._shokuinCd))
                {
                    alInput.DisplayMode = DispMode.Add;
                    alInput.ShokuinMstDT = CreateShokuinMstInsert();
                }
                else
                {
                    //update data
                    alInput.DisplayMode = DispMode.Edit;
                    alInput.ShokuinMstDT = CreateShokuinMstUpdate(this._shokuinMstDT);
                }
                // create data ShozokuMst
                CreateShozokuMstData();
                alInput.ShozokuMstDT = this._shozokuMstDT;

                IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                    return;
                }

                //close form and redirect ShokuinMstListForm
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
        /// 2014/07/07　HuyTX　　    新規作成
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

        #region ShokuinMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShokuinMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShokuinMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
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
                    case Keys.Delete:
                        RemoveCurrentRow();
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

        #region yakushokuListDataGridView_DefaultValuesNeeded
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yakushokuListDataGridView_DefaultValuesNeeded
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yakushokuListDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                e.Row.Cells["ShozokuShokuinCdCol"].Value = string.Empty;
                e.Row.Cells["BushoComboBoxCol"].Value = string.Empty;
                e.Row.Cells["YakushokuComboBoxCol"].Value = string.Empty;
                e.Row.Cells["InsertDtCol"].Value = _currentDt;
                e.Row.Cells["InsertUserCol"].Value = string.Empty;
                e.Row.Cells["InsertTarmCol"].Value = string.Empty;
                e.Row.Cells["UpdateDtCol"].Value = _currentDt;
                e.Row.Cells["UpdateUserCol"].Value = string.Empty;
                e.Row.Cells["UpdateTarmCol"].Value = string.Empty;
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

        #region yakushokuListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yakushokuListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yakushokuListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Exception ex = e.Exception;

                // Do not throw any exception
                e.ThrowException = false;
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

        #region number_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： number_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
                {
                    e.Handled = true;
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

        #region shokuinCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shokuinCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　DatNT    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shokuinCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(shokuinCdTextBox, shokuinCdTextBox, shokuinCdTextBox);
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
        /// 2014/07/07　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            shokuinPasswordTextBox.KeyPress += new KeyPressEventHandler(number_KeyPress);
            shokuinInjiJunTextBox.KeyPress += new KeyPressEventHandler(number_KeyPress);
            shokuinSeinengappiTextBox.KeyPress += new KeyPressEventHandler(number_KeyPress);
            shokuinNyushaDtTextBox.KeyPress += new KeyPressEventHandler(number_KeyPress);
            shokuinTaishokuDtTextBox.KeyPress += new KeyPressEventHandler(number_KeyPress);

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShokuinCd = this._shokuinCd;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Load default data Shisho combobox
            Utility.Utility.SetComboBoxList(shozokuShishoComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);

            if (!string.IsNullOrEmpty(this._shokuinCd))
            {
                this._displayMode = DispMode.Detail;
                this.Text = "職員マスタ詳細";
                this._shokuinMstDT = alOutput.ShokuinMstDT;
                this._shozokuMstDT = alOutput.ShozokuMstDT;
                this._shozokuCount = this._shozokuMstDT.Count;

                SetDefaultValueControl();
            }

            DisplayData();

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
        /// 2014/07/07　HuyTX    新規作成
        /// 2014/08/29　Mehara　 検査員フラグ追加
        /// 2015/01/26  DatNT    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            if (this._shokuinMstDT.Count > 0)
            {
                shozokuShishoComboBox.SelectedValue = this._shokuinMstDT[0].ShokuinShozokuShishoCd;
                shokuinCdTextBox.Text = this._shokuinMstDT[0].ShokuinCd;
                shokuinNmTextBox.Text = this._shokuinMstDT[0].ShokuinNm;
                shokuinKanaTextBox.Text = this._shokuinMstDT[0].ShokuinKana;
                shokuinPasswordTextBox.Text = this._shokuinMstDT[0].ShokuinPassword;
                shokuinInjiJunTextBox.Text = this._shokuinMstDT[0].ShokuinInjiJun.ToString();
                shokuinSeinengappiTextBox.Text = this._shokuinMstDT[0].ShokuinSeinengappi;
                shokuinNyushaDtTextBox.Text = this._shokuinMstDT[0].ShokuinNyushaDt;
                shokuinKensainFlgCheckBox.Checked = (this._shokuinMstDT[0].ShokuinKensainFlg == "1") ? true : false;
                shokuinTaishokuFlgCheckBox.Checked = (this._shokuinMstDT[0].ShokuinTaishokuFlg == "1") ? true : false;
                shokuinTaishokuDtTextBox.Text = this._shokuinMstDT[0].ShokuinTaishokuDt.Trim();
                // 2015/01/26 DatNT v1.04 ADD Start
                // 検査員月報役職フラグ
                shokuinShukeiJogaiFlgCheckBox.Checked = (this._shokuinMstDT[0].ShokuinShukeiJogaiFlg == "1") ? true : false;
                // 2015/01/26 DatNT v1.04 ADD End
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
        /// 2014/07/07　HuyTX    新規作成
        /// 2014/08/29　Mehara　 検査員フラグ追加
        /// 2015/01/26  DatNT    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            //所属支所(1)
            // UPD 20140724 START ZynasSou
            //shozokuShishoComboBox.Enabled = !(this._displayMode == DispMode.Add) ? false : true;
            shozokuShishoComboBox.Enabled = !(this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;
            // UPD 20140724 END ZynasSou

            //職員コード(2)
            shokuinCdTextBox.ReadOnly = (this._displayMode == DispMode.Add) ? false : true;

            //職員名(3)
            shokuinNmTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //職員名カナ(4)
            shokuinKanaTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //生年月日(5)
            shokuinSeinengappiTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //入社日付(6)
            shokuinNyushaDtTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //検査員フラグ
            shokuinKensainFlgCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            //退職フラグ(7)
            shokuinTaishokuFlgCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;

            // 2015/01/26 DatNT v1.04 ADD Start
            // 月報集計除外フラグ
            shokuinShukeiJogaiFlgCheckBox.Enabled = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? false : true;
            // 2015/01/26 DatNT v1.04 ADD End

            //退職日付{8)
            shokuinTaishokuDtTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //パスワード(9)
            shokuinPasswordTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //印字順(10)
            shokuinInjiJunTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //部署(12)
            BushoComboBoxCol.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

            //役職(13)
            YakushokuComboBoxCol.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;

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

            shokuinCdTextBox.Focus();

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
        /// 2014/07/07　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (this._displayMode)
            {
                case DispMode.Add:
                    Program.mForm.Text = "職員マスタ登録";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "職員マスタ変更";
                    Program.mForm.SetMenuEnabled(false);
                    break;
                case DispMode.Detail:
                    Program.mForm.Text = "職員マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "職員マスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
            }
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX    新規作成
        /// 2015/01/26  DatNT   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            List<string> listKey = new List<string>();
            StringBuilder errMsg = new StringBuilder();
            int rowIdx = 0;
            string emptyBushoCd = string.Empty;
            string emptyYakushokuCd = string.Empty;

            //所属支所(1)
            if (shozokuShishoComboBox.SelectedIndex <= 0)
            {
                errMsg.AppendLine("必須項目：所属支所が選択されていません。");
            }

            //職員コード(2)
            if (string.IsNullOrEmpty(shokuinCdTextBox.Text))
            {
                errMsg.AppendLine("必須項目：職員コードが入力されていません。");
            }
            else if (shokuinCdTextBox.TextLength != 3)
            {
                errMsg.AppendLine("職員コードは3桁で入力して下さい。");
            }

            //職員名(3)
            if (string.IsNullOrEmpty(shokuinNmTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：職員名が入力されていません。");
            }
            else if (shokuinNmTextBox.Text.Trim().Length > 20)
            {
                errMsg.AppendLine("職員名は20文字以下で入力して下さい。");
            }

            //職員名カナ(4)
            //if (string.IsNullOrEmpty(shokuinKanaTextBox.Text.Trim()))
            //{
            //    errMsg.AppendLine("必須項目：職員名カナが入力されていません。");
            //}
            //else if (shokuinKanaTextBox.Text.Trim().Length > 20)
            //{
            //    errMsg.AppendLine("職員名カナは20文字以下で入力して下さい。");
            //}

            //パスワード(9)
            if (string.IsNullOrEmpty(shokuinPasswordTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：パスワードが入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(shokuinPasswordTextBox.Text))
                {
                    errMsg.AppendLine("パスワードは半角数字で入力して下さい。");
                }
                //else if (shokuinPasswordTextBox.Text.Trim().Length != 10)
                //{
                //    errMsg.AppendLine("パスワードは10桁で入力して下さい。");
                //}
            }

            //印字順(10)
            if (string.IsNullOrEmpty(shokuinInjiJunTextBox.Text))
            {
                //errMsg.AppendLine("必須項目：印字順が入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(shokuinInjiJunTextBox.Text))
                {
                    errMsg.AppendLine("印字順は半角数字で入力して下さい。");
                }
                else if (Convert.ToDouble(shokuinInjiJunTextBox.Text) > Int32.MaxValue)
                {
                    errMsg.AppendLine(string.Format("印字順は{0}以下を入力して下さい。", Int32.MaxValue));
                }
            }

            //生年月日(5)
            if (string.IsNullOrEmpty(shokuinSeinengappiTextBox.Text.Trim()))
            {
               // errMsg.AppendLine("必須項目：生年月日が入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(shokuinSeinengappiTextBox.Text))
                {
                    errMsg.AppendLine("生年月日は半角数字で入力して下さい。");
                }
                else if (shokuinSeinengappiTextBox.TextLength != 8)
                {
                    errMsg.AppendLine("生年月日は8桁で入力して下さい。");
                }
            }

            //入社日付(6)
            if (string.IsNullOrEmpty(shokuinNyushaDtTextBox.Text.Trim()))
            {
                //errMsg.AppendLine("必須項目：入社日付が入力されていません。");
            }
            else
            {
                if (!Utility.Utility.IsDecimal(shokuinNyushaDtTextBox.Text))
                {
                    errMsg.AppendLine("入社日付は半角数字で入力して下さい。");
                }
                else if (shokuinNyushaDtTextBox.TextLength != 8)
                {
                    errMsg.AppendLine("入社日付は8桁で入力して下さい。");
                }
            }

            //退職日付(8)
            if (shokuinTaishokuFlgCheckBox.Checked && string.IsNullOrEmpty(shokuinTaishokuDtTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：退職日付が入力されていません。");
            }

            if (!string.IsNullOrEmpty(shokuinTaishokuDtTextBox.Text.Trim()))
            {
                if (!Utility.Utility.IsDecimal(shokuinTaishokuDtTextBox.Text))
                {
                    errMsg.AppendLine("退職日付は半角数字で入力して下さい。");
                }
                else if (shokuinTaishokuDtTextBox.Text.Trim().Length != 8)
                {
                    errMsg.AppendLine("退職日付は8桁で入力して下さい。");
                }
            }

            //役職一覧(11)
            if (yakushokuListDataGridView.Rows.Count <= 1)
            {
                errMsg.AppendLine("必須項目：役職が入力されていません。");
            }
            else
            {
                foreach (DataGridViewRow row in yakushokuListDataGridView.Rows)
                {
                    if (yakushokuListDataGridView.Rows.Count > 1 && yakushokuListDataGridView.Rows.Count - 1 == rowIdx) break;

                    //部署(12)
                    if (row.Cells["BushoComboBoxCol"].Value == null || string.IsNullOrEmpty(row.Cells["BushoComboBoxCol"].Value.ToString()))
                    {
                        emptyBushoCd += (rowIdx + 1).ToString() + ", ";
                    }

                    //役職(13)
                    if (row.Cells["YakushokuComboBoxCol"].Value == null || string.IsNullOrEmpty(row.Cells["YakushokuComboBoxCol"].Value.ToString()))
                    {
                        emptyYakushokuCd += (rowIdx + 1).ToString() + ", ";
                    }

                    rowIdx++;
                }
            }

            //部署(12)
            if (!string.IsNullOrEmpty(emptyBushoCd))
            {
                errMsg.AppendLine("行 : " + emptyBushoCd.Remove(emptyBushoCd.Length - 2) + " : 必須項目：部署が選択されていません。");
            }

            //役職(13)
            if (!string.IsNullOrEmpty(emptyYakushokuCd))
            {
                errMsg.AppendLine("行 : " + emptyYakushokuCd.Remove(emptyYakushokuCd.Length - 2) + " : 必須項目：役職が選択されていません。");
            }

            //check duplicate shozoku
            listKey = getDuplicateShozoku();
            ChangeBackGroundCell(listKey);

            if (listKey.Count != 0)
            {
                errMsg.AppendLine("部署＆役職が重複しています。");
            }

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
        /// 2014/07/07  HuyTX　　    新規作成
        /// 2014/08/29  Mehara      検査員フラグ
        /// 2015/01/26  DatNT       v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedControl()
        {
            //check edit default value mode Add
            if (string.IsNullOrEmpty(this._shokuinCd))
            {
                if (shozokuShishoComboBox.SelectedIndex > 0
                    || !string.IsNullOrEmpty(shokuinCdTextBox.Text)
                    || !string.IsNullOrEmpty(shokuinNmTextBox.Text)
                    || !string.IsNullOrEmpty(shokuinKanaTextBox.Text)
                    || !string.IsNullOrEmpty(shokuinPasswordTextBox.Text)
                    || !string.IsNullOrEmpty(shokuinInjiJunTextBox.Text)
                    || !string.IsNullOrEmpty(shokuinSeinengappiTextBox.Text)
                    || !string.IsNullOrEmpty(shokuinNyushaDtTextBox.Text)
                    || shokuinKensainFlgCheckBox.Checked
                    || shokuinTaishokuFlgCheckBox.Checked
                    || !string.IsNullOrEmpty(shokuinTaishokuDtTextBox.Text)
                    || yakushokuListDataGridView.Rows.Count > 1
                    // 2015/01/26 DatNT v1.04 ADD Start
                    || shokuinShukeiJogaiFlgCheckBox.Checked
                    // 2015/01/26 DatNT v1.04 ADD End
                    )
                {
                    return true;
                }
            }
            else
            {
                if (this._shokuinMstDT.Count != 0)
                {
                    if (shozokuShishoComboBox.SelectedValue.ToString() != this._shokuinMstDT[0].ShokuinShozokuShishoCd
                        || shokuinCdTextBox.Text != this._shokuinMstDT[0].ShokuinCd
                        || shokuinNmTextBox.Text != this._shokuinMstDT[0].ShokuinNm
                        || shokuinKanaTextBox.Text != this._shokuinMstDT[0].ShokuinKana
                        || shokuinPasswordTextBox.Text != this._shokuinMstDT[0].ShokuinPassword
                        || shokuinInjiJunTextBox.Text != this._shokuinMstDT[0].ShokuinInjiJun.ToString()
                        || shokuinSeinengappiTextBox.Text != this._shokuinMstDT[0].ShokuinSeinengappi
                        || shokuinNyushaDtTextBox.Text != this._shokuinMstDT[0].ShokuinNyushaDt
                        || shokuinKensainFlgCheckBox.Checked!=(this._shokuinMstDT[0].ShokuinKensainFlg == "1" ) ? true:false
                        || shokuinTaishokuFlgCheckBox.Checked != (this._shokuinMstDT[0].ShokuinTaishokuFlg == "1") ? true : false
                        || shokuinTaishokuDtTextBox.Text.Trim() != this._shokuinMstDT[0].ShokuinTaishokuDt.Trim()
                        // 2015/01/26 DatNT v1.04 ADD Start
                        || (shokuinShukeiJogaiFlgCheckBox.Checked && this._shokuinMstDT[0].ShokuinKensainFlg == "0")
                        || (!shokuinShukeiJogaiFlgCheckBox.Checked && this._shokuinMstDT[0].ShokuinKensainFlg == "1")
                        // 2015/01/26 DatNT v1.04 ADD End
                        )
                    {
                        return true;
                    }
                }

                int count = this._shozokuMstDT.Count;

                if (yakushokuListDataGridView.Rows.Count - 1 != this._shozokuCount) return true;

                for (int i = 0; i < yakushokuListDataGridView.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = yakushokuListDataGridView.Rows[i];
                    if (row.Cells["BushoComboBoxCol"].Value.ToString() != row.Cells["ShozokuBushoCdOrgCol"].Value.ToString()
                        || row.Cells["YakushokuComboBoxCol"].Value.ToString() != row.Cells["ShozokuYakushokuCdOrgCol"].Value.ToString())
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        #endregion

        #region getDuplicateShozoku
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： getDuplicateShozoku
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private List<string> getDuplicateShozoku()
        {
            List<string> listKey = new List<string>();
            for (int i = 0; i < yakushokuListDataGridView.Rows.Count - 1; i++)
            {
                string bushoCd = yakushokuListDataGridView.Rows[i].Cells["BushoComboBoxCol"].Value.ToString();
                string yakushokuCd = yakushokuListDataGridView.Rows[i].Cells["YakushokuComboBoxCol"].Value.ToString();

                for (int j = i + 1; j < yakushokuListDataGridView.Rows.Count - 1; j++)
                {
                    if ((!string.IsNullOrEmpty(yakushokuListDataGridView.Rows[i].Cells["BushoComboBoxCol"].Value.ToString())
                            && !string.IsNullOrEmpty(yakushokuListDataGridView.Rows[i].Cells["YakushokuComboBoxCol"].Value.ToString()))
                        && (yakushokuListDataGridView.Rows[j].Cells["BushoComboBoxCol"].Value.ToString() == yakushokuListDataGridView.Rows[i].Cells["BushoComboBoxCol"].Value.ToString()
                            && yakushokuListDataGridView.Rows[j].Cells["YakushokuComboBoxCol"].Value.ToString() == yakushokuListDataGridView.Rows[i].Cells["YakushokuComboBoxCol"].Value.ToString())
                        )
                    {
                        if (!listKey.Contains(bushoCd + "-" + yakushokuCd))
                        {
                            listKey.Add(bushoCd + "-" + yakushokuCd);
                        }
                    }
                    else if (yakushokuListDataGridView.Rows[j].Cells["ShozokuBushoCdOrgCol"].Value.ToString() == yakushokuListDataGridView.Rows[i].Cells["BushoComboBoxCol"].Value.ToString()
                            && yakushokuListDataGridView.Rows[j].Cells["ShozokuYakushokuCdOrgCol"].Value.ToString() == yakushokuListDataGridView.Rows[i].Cells["YakushokuComboBoxCol"].Value.ToString())
                    {
                        listKey.Add(bushoCd + "-" + yakushokuCd);
                    }
                }
            }

            return listKey;
        }
        #endregion

        #region CreateShokuinMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokuinMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  HuyTX　　    新規作成
        /// 2015/01/26  DatNT     v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokuinMstDataSet.ShokuinMstDataTable CreateShokuinMstInsert()
        {
            ShokuinMstDataSet.ShokuinMstDataTable shokuinMstDT = new ShokuinMstDataSet.ShokuinMstDataTable();
            ShokuinMstDataSet.ShokuinMstRow newRow = shokuinMstDT.NewShokuinMstRow();

            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string shokuinNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //所属支所コード(1)
            newRow.ShokuinShozokuShishoCd = shozokuShishoComboBox.SelectedValue.ToString();

            //職員コード(2)
            newRow.ShokuinCd = shokuinCdTextBox.Text;

            //職員名(3)
            newRow.ShokuinNm = shokuinNmTextBox.Text;

            //職員名カナ(4)
            newRow.ShokuinKana = shokuinKanaTextBox.Text;

            //生年月日(5)
            newRow.ShokuinSeinengappi = shokuinSeinengappiTextBox.Text;

            //入社日付(6)
            newRow.ShokuinNyushaDt = shokuinNyushaDtTextBox.Text;

            //検査員フラグ
            newRow.ShokuinKensainFlg = (shokuinKensainFlgCheckBox.Checked) ? "1" : "0";

            //退職フラグ(7)
            newRow.ShokuinTaishokuFlg = (shokuinTaishokuFlgCheckBox.Checked) ? "1" : "0";

            //退職日付(8)
            newRow.ShokuinTaishokuDt = shokuinTaishokuDtTextBox.Text;

            //パスワード(9)
            newRow.ShokuinPassword = shokuinPasswordTextBox.Text;

            //印字順(10)
            if (!string.IsNullOrEmpty(shokuinInjiJunTextBox.Text))
            {
                newRow.ShokuinInjiJun = Convert.ToInt32(shokuinInjiJunTextBox.Text);
            }
            else
            {
                newRow.ShokuinInjiJun = 0;
            }

            // 2015/01/26 DatNT v1.04 ADD Start
            // 月報集計除外フラグ
            newRow.ShokuinShukeiJogaiFlg = shokuinShukeiJogaiFlgCheckBox.Checked ? "1" : "0";
            // 2015/01/26 DatNT v1.04 ADD End

            //登録日
            newRow.InsertDt = currentDateTime;

            //登録者
            newRow.InsertUser = shokuinNm;

            //登録端末
            newRow.InsertTarm = Dns.GetHostName();

            //更新日
            newRow.UpdateDt = currentDateTime;

            //更新者
            newRow.UpdateUser = shokuinNm;

            //更新端末
            newRow.UpdateTarm = Dns.GetHostName();

            // 行を挿入
            shokuinMstDT.AddShokuinMstRow(newRow);

            //行の状態を設定
            newRow.AcceptChanges();

            newRow.SetAdded();

            return shokuinMstDT;

        }
        #endregion

        #region CreateShokuinMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokuinMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  HuyTX　　    新規作成
        /// 2014/08/29　Mehara　　　検査員フラグ
        /// 2015/01/26  DatNT       v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokuinMstDataSet.ShokuinMstDataTable CreateShokuinMstUpdate(ShokuinMstDataSet.ShokuinMstDataTable shokuinMstDT)
        {
            // 2015.01.09 toyoda Add Start
            //所属支所コード(1)
            shokuinMstDT[0].ShokuinShozokuShishoCd = shozokuShishoComboBox.SelectedValue.ToString();
            // 2015.01.09 toyoda Add End

            //職員名(3)
            shokuinMstDT[0].ShokuinNm = shokuinNmTextBox.Text;

            //職員名カナ(4)
            shokuinMstDT[0].ShokuinKana = shokuinKanaTextBox.Text;

            //生年月日(5)
            shokuinMstDT[0].ShokuinSeinengappi = shokuinSeinengappiTextBox.Text;

            //入社日付(6)
            shokuinMstDT[0].ShokuinNyushaDt = shokuinNyushaDtTextBox.Text;

            //検査員フラグ
            shokuinMstDT[0].ShokuinKensainFlg = (shokuinKensainFlgCheckBox.Checked) ? "1" : "0";

            //退職フラグ(7)
            shokuinMstDT[0].ShokuinTaishokuFlg = (shokuinTaishokuFlgCheckBox.Checked) ? "1" : "0";

            // 2015/01/26 DatNT v1.04 ADD Start
            // 月報集計除外フラグ
            shokuinMstDT[0].ShokuinShukeiJogaiFlg = shokuinShukeiJogaiFlgCheckBox.Checked ? "1" : "0";
            // 2015/01/26 DatNT v1.04 ADD End

            //退職日付(8)
            shokuinMstDT[0].ShokuinTaishokuDt = shokuinTaishokuDtTextBox.Text;

            //パスワード(9)
            shokuinMstDT[0].ShokuinPassword = shokuinPasswordTextBox.Text;

            //印字順(10)
            shokuinMstDT[0].ShokuinInjiJun = Convert.ToInt32(shokuinInjiJunTextBox.Text);

            //更新者
            shokuinMstDT[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //更新端末
            shokuinMstDT[0].UpdateTarm = Dns.GetHostName();

            return shokuinMstDT;

        }
        #endregion

        #region CreateShozokuMstData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShozokuMstData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateShozokuMstData()
        {
            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string shokuinNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            for (int i = 0; i < yakushokuListDataGridView.Rows.Count - 1; i++)
            {
                yakushokuListDataGridView.Rows[i].Cells["ShozokuShokuinCdCol"].Value = shokuinCdTextBox.Text;
                if (this._displayMode == DispMode.Add || yakushokuListDataGridView.Rows[i].Cells["IsUpdate"].Value.ToString() != "1")
                {
                    yakushokuListDataGridView.Rows[i].Cells["InsertDtCol"].Value = currentDateTime;
                    yakushokuListDataGridView.Rows[i].Cells["InsertUserCol"].Value = shokuinNm;
                    yakushokuListDataGridView.Rows[i].Cells["InsertTarmCol"].Value = Dns.GetHostName();
                }

                yakushokuListDataGridView.Rows[i].Cells["UpdateDtCol"].Value = currentDateTime;
                yakushokuListDataGridView.Rows[i].Cells["UpdateUserCol"].Value = shokuinNm;
                yakushokuListDataGridView.Rows[i].Cells["UpdateTarmCol"].Value = Dns.GetHostName();

                string bushoNm = ((DataGridViewComboBoxCell)yakushokuListDataGridView.Rows[i].Cells["BushoComboBoxCol"]).FormattedValue.ToString();
                yakushokuListDataGridView.Rows[i].Cells["BushoNmCol"].Value = bushoNm;

                string yakushokuNm = ((DataGridViewComboBoxCell)yakushokuListDataGridView.Rows[i].Cells["YakushokuComboBoxCol"]).FormattedValue.ToString();
                yakushokuListDataGridView.Rows[i].Cells["YakushokuNmCol"].Value = yakushokuNm;

            }

        }
        #endregion

        #region ChangeBackGroundCell
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeBackGroundCell
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeBackGroundCell(List<string> listKey)
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.Red;

            foreach (DataGridViewRow row in yakushokuListDataGridView.Rows)
            {
                row.DefaultCellStyle = new DataGridViewCellStyle();
            }

            if (listKey.Count <= 0) return;

            foreach (string key in listKey)
            {
                string bushoCd = key.Split('-')[0];
                string yakushokuCd = key.Split('-')[1];

                for (int i = 0; i < yakushokuListDataGridView.RowCount - 1; i++)
                {
                    DataGridViewRow row = yakushokuListDataGridView.Rows[i];
                    if (row.Cells["BushoComboBoxCol"].Value.ToString() == bushoCd
                        && row.Cells["YakushokuComboBoxCol"].Value.ToString() == yakushokuCd)
                    {
                        row.DefaultCellStyle = cellStyle;
                    }
                }
            }
        }
        #endregion

        #region DisplayData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayData()
        {
            this._shozokuMstDT.PrimaryKey = null;

            _shozokuMstDT.Columns.Add("ShozokuBushoCdOrg", typeof(string));
            _shozokuMstDT.Columns.Add("ShozokuYakushokuCdOrg", typeof(string));
            _shozokuMstDT.Columns.Add("IsUpdate", typeof(string));
            _shozokuMstDT.Columns.Add("BushoNm", typeof(string));
            _shozokuMstDT.Columns.Add("YakushokuNm", typeof(string));

            for (int i = 0; i < _shozokuMstDT.Count; i++)
            {
                _shozokuMstDT[i]["ShozokuBushoCdOrg"] = _shozokuMstDT[i].ShozokuBushoCd;
                _shozokuMstDT[i]["ShozokuYakushokuCdOrg"] = _shozokuMstDT[i].ShozokuYakushokuCd;
                _shozokuMstDT[i]["IsUpdate"] = "1";
                _shozokuMstDT[i]["BushoNm"] = string.Empty;
                _shozokuMstDT[i]["YakushokuNm"] = string.Empty;
            }

            yakushokuListDataGridView.DataSource = _shozokuMstDT;
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
        /// 2015/01/26　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // パスワード
            shokuinPasswordTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
        }
        #endregion

        #region RemoveCurrentRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RemoveCurrentRow
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RemoveCurrentRow()
        {
            if (_displayMode == DispMode.Add || _displayMode == DispMode.Edit)
            {
                try
                {
                    ShozokuMstDataSet.ShozokuMstRow removeRow = (ShozokuMstDataSet.ShozokuMstRow)(yakushokuListDataGridView.CurrentRow.DataBoundItem as DataRowView).Row;
                    _shozokuMstDT.RemoveShozokuMstRow(removeRow);
                }
                catch (Exception)
                {
                    // do nothing
                }
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
