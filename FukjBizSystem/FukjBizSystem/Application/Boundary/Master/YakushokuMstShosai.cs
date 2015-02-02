using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.YakushokuMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YakushokuMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YakushokuMstShosaiForm : FukjBaseForm
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
        private string terminal = Dns.GetHostName();

        /// <summary>
        /// yakushokuCd
        /// </summary>
        private string _yakushokuCd = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Update mode
        /// </summary>
        private DispMode _updateMode;

        /// <summary>
        /// YakushokuMstDataTable
        /// </summary>
        private YakushokuMstDataSet.YakushokuMstDataTable _dispDT;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YakushokuMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public YakushokuMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YakushokuMstShosaiForm
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="yakushokuCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public YakushokuMstShosaiForm(string yakushokuCd)
        {
            InitializeComponent();

            this._yakushokuCd = yakushokuCd;
        }
        #endregion

        #region イベント

        #region YakushokuMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YakushokuMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YakushokuMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_yakushokuCd))
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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // データを削除する際に、警告を表示する。
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？")
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    IDeleteBtnClickALInput alInput      = new DeleteBtnClickALInput();
                    alInput.YakushokuCd                 = yakushokuCdTextBox.Text;
                    IDeleteBtnClickALOutput alOutput    = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    if (alOutput.Result)
                    {
                        this.DialogResult = DialogResult.OK;
                        Program.mForm.MovePrev();
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error,
                            string.Format("該当するデータは登録されていません。[役職コード：{0}]",
                            new string[] { yakushokuCdTextBox.Text }));
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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //20150130 HuyTX Mod Start
                //if (_dispMode != DispMode.Detail)
                //{
                //    if (!CheckEdit())
                //    {
                //        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                //                == System.Windows.Forms.DialogResult.Yes)
                //        {
                //            goto SHOWFORM;
                //        }
                //    }
                //    else
                //    {
                //        goto SHOWFORM;
                //    }
                //}
                //else
                //{
                //    goto SHOWFORM;
                //}

                if (_dispMode != DispMode.Detail && !CheckEdit())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                            != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                //SHOWFORM:
                //End
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

        #region YakushokuMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YakushokuMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// 2015/01/16  Mehara      v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YakushokuMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.YakushokuCd         = _yakushokuCd;
            alInput.NameKbn             = Utility.Constants.NameKbnConstant.NAME_KBN_005;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            Utility.Utility.SetComboBoxList(yakushokuKbnCombobox, alOutput.NameMstDT, "NAME", "NAMECD", true);

            if (alOutput.YakushokuMstDT != null && alOutput.YakushokuMstDT.Count > 0)
            {
                SetValues(alOutput.YakushokuMstDT[0]);

                _dispDT = alOutput.YakushokuMstDT;
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(YakushokuMstDataSet.YakushokuMstRow row)
        {
            // 役職コード
            yakushokuCdTextBox.Text = row.YakushokuCd;

            // 役職名
            yakushokuNmTextBox.Text = row.YakushokuNm;

            // 役職区分
            yakushokuKbnCombobox.SelectedValue = row.YakushokuKbn;
        }
        #endregion

        #region SetControlModeView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // 役職コード
                    // UPD 20140724 START ZynasSou
                    //yakushokuCdTextBox.ReadOnly = false;
                    yakushokuCdTextBox.ReadOnly = true;
                    // UPD 20140724 END ZynasSou

                    // 役職名
                    yakushokuNmTextBox.ReadOnly = false;

                    // 役職区分
                    yakushokuKbnCombobox.Enabled = true;

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

                    this.Text = "役職マスタ登録";
                    Program.mForm.Text = "役職マスタ登録";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:
                    
                    // 役職コード
                    yakushokuCdTextBox.ReadOnly = true;

                    // 役職名
                    yakushokuNmTextBox.ReadOnly = false;

                    // 役職区分
                    yakushokuKbnCombobox.Enabled = true;

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

                    this.Text = "役職マスタ変更";
                    Program.mForm.Text = "役職マスタ変更";
                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // 役職コード
                    yakushokuCdTextBox.ReadOnly = true;

                    // 役職名
                    yakushokuNmTextBox.ReadOnly = true;

                    // 役職区分
                    yakushokuKbnCombobox.Enabled = false;

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

                    this.Text = "役職マスタ詳細";
                    Program.mForm.Text = "役職マスタ詳細";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // 役職コード
                    yakushokuCdTextBox.ReadOnly = true;

                    // 役職名
                    yakushokuNmTextBox.ReadOnly = true;

                    // 役職区分
                    yakushokuKbnCombobox.Enabled = false;

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

                    this.Text = "役職マスタ入力確認";
                    Program.mForm.Text = "役職マスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
            }
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            YakushokuMstDataSet.YakushokuMstDataTable updateDT = new YakushokuMstDataSet.YakushokuMstDataTable();

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
            alInput.YakushokuMstDT              = updateDT;
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YakushokuMstDataSet.YakushokuMstDataTable CreateDataInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            YakushokuMstDataSet.YakushokuMstDataTable insertDT = new YakushokuMstDataSet.YakushokuMstDataTable();

            YakushokuMstDataSet.YakushokuMstRow insertRow = insertDT.NewYakushokuMstRow();

            // 役職コード
            // UPD 20140724 START ZynasSou
            //insertRow.YakushokuCd = yakushokuCdTextBox.Text;
            insertRow.YakushokuCd = Utility.Saiban.GetKeyRenban("YakushokuMst", "", "", "").PadLeft(2, '0');
            // UPD 20140724 END ZynasSou

            // 役職名
            insertRow.YakushokuNm = yakushokuNmTextBox.Text.Trim();

            // 役職区分
            insertRow.YakushokuKbn = yakushokuKbnCombobox.SelectedValue.ToString();

            insertRow.InsertDt = now;
            insertRow.InsertTarm = terminal;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = terminal;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddYakushokuMstRow(insertRow);

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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YakushokuMstDataSet.YakushokuMstDataTable CreateDataUpdate(
            YakushokuMstDataSet.YakushokuMstDataTable dataTable)
        {
            // 役職コード
            dataTable[0].YakushokuCd = yakushokuCdTextBox.Text;

            // 役職名
            dataTable[0].YakushokuNm = yakushokuNmTextBox.Text.Trim();

            // 役職区分
            dataTable[0].YakushokuKbn = yakushokuKbnCombobox.SelectedValue.ToString();

            return dataTable;
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // DEL 20140724 START ZynasSou
            //// 役職コード
            //if (string.IsNullOrEmpty(yakushokuCdTextBox.Text))
            //{
            //    errMess.Append("必須項目：役職コードが入力されていません。\r\n");
            //}
            //else
            //{
            //    if (yakushokuCdTextBox.Text.Length != 2)
            //    {
            //        errMess.Append("役職コードは2桁で入力して下さい。\r\n");
            //    }
            //}
            // DEL 20140724 END ZynasSou

            // 役職名
            if (string.IsNullOrEmpty(yakushokuNmTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：役職名が入力されていません。\r\n");
            }
            else
            {
                if (yakushokuNmTextBox.Text.Trim().Length > 10)
                {
                    errMess.Append("役職名は10文字以下で入力して下さい。\r\n");
                }
            }

            // 役職区分
            if (yakushokuKbnCombobox.SelectedIndex == -1 || yakushokuKbnCombobox.SelectedIndex == 0)
            {
                errMess.Append("必須項目：役職区分が選択されていません。\r\n");
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            //check edit mode add
            if (string.IsNullOrEmpty(_yakushokuCd))
            {
                if (yakushokuCdTextBox.Text != string.Empty
                    || yakushokuNmTextBox.Text != string.Empty
                    || yakushokuKbnCombobox.SelectedIndex != 0
                    )
                {
                    return false;
                }
            }

            if (_dispDT != null && _dispDT.Count > 0)
            {
                if (yakushokuCdTextBox.Text != _dispDT[0].YakushokuCd
                        || yakushokuNmTextBox.Text != _dispDT[0].YakushokuNm
                        || yakushokuKbnCombobox.SelectedValue.ToString() != _dispDT[0].YakushokuKbn)
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
