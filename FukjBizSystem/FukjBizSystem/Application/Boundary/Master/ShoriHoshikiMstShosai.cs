using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.ShoriHoshikiMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShoriHoshikiMstShosaiForm
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
    public partial class ShoriHoshikiMstShosaiForm : FukjBaseForm
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
        /// shoriHoshikiKbn
        /// </summary>
        private string _shoriHoshikiKbn = string.Empty;

        /// <summary>
        /// shoriHoshikiCd
        /// </summary>
        private string _shoriHoshikiCd = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Update mode
        /// </summary>
        private DispMode _updateMode;

        /// <summary>
        /// HokenjoMstDataTable
        /// </summary>
        private ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable _dispDT;

        /// <summary>
        /// suishitsuKensaJisshiListDT
        /// </summary>
        private ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiListDataTable _suishitsuKensaJisshiListDT;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShoriHoshikiMstShosaiForm
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
        public ShoriHoshikiMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShoriHoshikiMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="shoriHoshikiKbn"></param>
        /// <param name="shoriHoshikiCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShoriHoshikiMstShosaiForm(string shoriHoshikiKbn, string shoriHoshikiCd)
        {
            InitializeComponent();

            this._shoriHoshikiKbn = shoriHoshikiKbn;
            this._shoriHoshikiCd = shoriHoshikiCd;
        }
        #endregion

        #region イベント

        #region ShoriHoshikiMstShosai_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShoriHoshikiMstShosai_Load
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
        private void ShoriHoshikiMstShosai_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_shoriHoshikiCd) && string.IsNullOrEmpty(_shoriHoshikiKbn))
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
        /// 2014/06/30  DatNT　　    新規作成
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
        /// 2014/06/30  DatNT　　    新規作成
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
        /// 2014/06/30  DatNT　　    新規作成
        /// 2015/01/28  HuyTX　　    Ver1.02
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
                    // 保健所マスタに対象となる保健所コードが登録されている事を確認する。
                    IDeleteBtnClickALInput alInput   = new DeleteBtnClickALInput();
                    alInput.ShoriHoshikiKbn          = shoriHoshikiKbnTextBox.Text.Trim();
                    alInput.ShoriHoshikiCd           = shoriHoshikiCdTextBox.Text.Trim();
                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    //Ver1.02 Start
                    //if (alOutput.Result)
                    //{
                    //    this.DialogResult = DialogResult.OK;
                    //    Program.mForm.MovePrev();
                    //}
                    //else
                    //{
                    //    MessageForm.Show2(MessageForm.DispModeType.Error,
                    //        string.Format("該当するデータは登録されていません。[処理方式区分：{0}、処理方式コード：{1}]",
                    //        new string[] { shoriHoshikiKbnTextBox.Text, shoriHoshikiCdTextBox.Text }));
                    //}
                    if (!string.IsNullOrEmpty(alOutput.ErrorMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrorMessage);
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                    Program.mForm.MovePrev();
                    //Ver1.02 End
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
        /// 2014/06/30  DatNT　　    新規作成
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
        /// 2014/06/30  DatNT　　    新規作成
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //20150127 HuyTX Mod Start
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
                //20150127 HuyTX Mod End

                //SHOWFORM:
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

        #region ShoriHoshikiMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShoriHoshikiMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShoriHoshikiMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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

        #region ShoriHoshikiMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShoriHoshikiMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shoriHoshikiSuishitsuKensaJisshiListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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
        /// 2015/01/27  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.ShoriHoshikiKbn     = _shoriHoshikiKbn;
            alInput.ShoriHoshikiCd      = _shoriHoshikiCd;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            if (alOutput.ShoriHoshikiMstDT != null && alOutput.ShoriHoshikiMstDT.Count > 0)
            {
                SetValues(alOutput.ShoriHoshikiMstDT[0]);

                _dispDT = alOutput.ShoriHoshikiMstDT;
            }

            //Ver1.02 Add
            _suishitsuKensaJisshiListDT = alOutput.ShoriHoshikiSuishitsuKensaJisshiListDataTable;
            shoriHoshikiSuishitsuKensaJisshiListDataGridView.DataSource = _suishitsuKensaJisshiListDT;
            //End

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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(ShoriHoshikiMstDataSet.ShoriHoshikiMstRow row)
        {
            // 処理方式区分 2
            shoriHoshikiKbnTextBox.Text = row.ShoriHoshikiKbn;

            // 処理方式コード 3
            shoriHoshikiCdTextBox.Text = row.ShoriHoshikiCd;

            // 処理方式種別名 4
            shoriHoshikiShubetsuNmTextBox.Text = row.ShoriHoshikiShubetsuNm;

            // 処理方式名 5
            shoriHoshikiNmTextBox.Text = row.ShoriHoshikiNm;

            // 処理方式種別区分 6
            shoriHoshikiShubetsuKbnTextBox.Text = row.ShoriHoshikiShubetsuKbn;

            // 処理方式内部名 7
            shoriHoshikiNaibuNmTextBox.Text = row.ShoriHoshikiNaibuNm;
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
        /// 2014/06/30  DatNT　　    新規作成
        /// 2015/01/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // 処理方式区分 2
                    shoriHoshikiKbnTextBox.ReadOnly = false;

                    // 処理方式コード 3
                    // UPD 20140724 START ZynasSou
                    //shoriHoshikiCdTextBox.ReadOnly = false;
                    shoriHoshikiCdTextBox.ReadOnly = true;
                    // UPD 20140724 END ZynasSou

                    // 処理方式種別名 4
                    shoriHoshikiShubetsuNmTextBox.ReadOnly = false;

                    // 処理方式名 5
                    shoriHoshikiNmTextBox.ReadOnly = false;

                    // 処理方式種別区分 6
                    shoriHoshikiShubetsuKbnTextBox.ReadOnly = false;

                    // 処理方式内部名 7
                    shoriHoshikiNaibuNmTextBox.ReadOnly = false;

                    // 登録ボタン (8) 
                    entryButton.Visible = true;

                    // 変更ボタン (9) 
                    changeButton.Visible = false;

                    // 削除ボタン (10) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (11)
                    reInputButton.Visible = false;

                    // 確定ボタン　(12) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (13)
                    closeButton.Visible = true;

                    //Ver1.02 Add
                    //水質検査実施一覧
                    //検査実施区分（7条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi7JyoUmuFlgCheckBoxCol.Name].ReadOnly = false;
                    //検査実施区分（11条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi11JyoUmuFlgCheckBoxCol.Name].ReadOnly = false;
                    //End

                    this.Text = "処理方式マスタ登録";
                    Program.mForm.Text = "処理方式マスタ登録";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:

                    // 処理方式区分 2
                    shoriHoshikiKbnTextBox.ReadOnly = true;

                    // 処理方式コード 3
                    shoriHoshikiCdTextBox.ReadOnly = true;

                    // 処理方式種別名 4
                    shoriHoshikiShubetsuNmTextBox.ReadOnly = false;

                    // 処理方式名 5
                    shoriHoshikiNmTextBox.ReadOnly = false;

                    // 処理方式種別区分 6
                    shoriHoshikiShubetsuKbnTextBox.ReadOnly = false;

                    // 処理方式内部名 7
                    shoriHoshikiNaibuNmTextBox.ReadOnly = false;

                    // 登録ボタン (8) 
                    entryButton.Visible = false;

                    // 変更ボタン (9) 
                    changeButton.Visible = true;

                    // 削除ボタン (10) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (11)
                    reInputButton.Visible = false;

                    // 確定ボタン　(12) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (13)
                    closeButton.Visible = true;

                    //Ver1.02 Add
                    //水質検査実施一覧
                    //検査実施区分（7条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi7JyoUmuFlgCheckBoxCol.Name].ReadOnly = false;
                    //検査実施区分（11条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi11JyoUmuFlgCheckBoxCol.Name].ReadOnly = false;
                    //End

                    this.Text = "処理方式マスタ変更";
                    Program.mForm.Text = "処理方式マスタ変更";

                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // 処理方式区分 2
                    shoriHoshikiKbnTextBox.ReadOnly = true;

                    // 処理方式コード 3
                    shoriHoshikiCdTextBox.ReadOnly = true;

                    // 処理方式種別名 4
                    shoriHoshikiShubetsuNmTextBox.ReadOnly = true;

                    // 処理方式名 5
                    shoriHoshikiNmTextBox.ReadOnly = true;

                    // 処理方式種別区分 6
                    shoriHoshikiShubetsuKbnTextBox.ReadOnly = true;

                    // 処理方式内部名 7
                    shoriHoshikiNaibuNmTextBox.ReadOnly = true;

                    // 登録ボタン (8) 
                    entryButton.Visible = false;

                    // 変更ボタン (9) 
                    changeButton.Visible = true;

                    // 削除ボタン (10) 
                    deleteButton.Visible = true;

                    // 再入力ボタン (11)
                    reInputButton.Visible = false;

                    // 確定ボタン　(12) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (13)
                    closeButton.Visible = true;

                    //Ver1.02 Add
                    //水質検査実施一覧
                    //検査実施区分（7条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi7JyoUmuFlgCheckBoxCol.Name].ReadOnly = true;
                    //検査実施区分（11条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi11JyoUmuFlgCheckBoxCol.Name].ReadOnly = true;
                    //End

                    this.Text = "処理方式マスタ詳細";
                    Program.mForm.Text = "処理方式マスタ詳細";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // 処理方式区分 2
                    shoriHoshikiKbnTextBox.ReadOnly = true;

                    // 処理方式コード 3
                    shoriHoshikiCdTextBox.ReadOnly = true;

                    // 処理方式種別名 4
                    shoriHoshikiShubetsuNmTextBox.ReadOnly = true;

                    // 処理方式名 5
                    shoriHoshikiNmTextBox.ReadOnly = true;

                    // 処理方式種別区分 6
                    shoriHoshikiShubetsuKbnTextBox.ReadOnly = true;

                    // 処理方式内部名 7
                    shoriHoshikiNaibuNmTextBox.ReadOnly = true;

                    // 登録ボタン (8) 
                    entryButton.Visible = false;

                    // 変更ボタン (9) 
                    changeButton.Visible = false;

                    // 削除ボタン (10) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (11)
                    reInputButton.Visible = true;

                    // 確定ボタン　(12) 
                    decisionButton.Visible = true;

                    // 閉じるボタン (13)
                    closeButton.Visible = true;

                    //Ver1.02 Add
                    //水質検査実施一覧
                    //検査実施区分（7条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi7JyoUmuFlgCheckBoxCol.Name].ReadOnly = true;
                    //検査実施区分（11条）
                    shoriHoshikiSuishitsuKensaJisshiListDataGridView.Columns[KensaJisshi11JyoUmuFlgCheckBoxCol.Name].ReadOnly = true;
                    //End

                    this.Text = "処理方式マスタ入力確認";
                    Program.mForm.Text = "処理方式マスタ入力確認";

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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable updateDT = new ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

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
            alInput.ShoriHoshikiMstDT           = updateDT;
            //20150127 HuyTX Ver1.02 Add
            alInput.ShoriHoshikiSuishitsuKensaJisshiListDataTable = _suishitsuKensaJisshiListDT;
            //End
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable CreateDataInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable insertDT = new ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

            ShoriHoshikiMstDataSet.ShoriHoshikiMstRow insertRow = insertDT.NewShoriHoshikiMstRow();

            // 処理方式区分 2
            insertRow.ShoriHoshikiKbn = shoriHoshikiKbnTextBox.Text.Trim();            

            // 処理方式コード 3
            // UPD 20140724 START ZynasSou
            //insertRow.ShoriHoshikiCd = shoriHoshikiCdTextBox.Text.Trim();
            insertRow.ShoriHoshikiCd = Utility.Saiban.GetKeyRenban("ShoriHoshikiMst", shoriHoshikiKbnTextBox.Text.Trim(), "", "").PadLeft(3, '0');
            // UPD 20140724 END ZynasSou

            // 処理方式種別名 4
            insertRow.ShoriHoshikiShubetsuNm = shoriHoshikiShubetsuNmTextBox.Text.Trim();

            // 処理方式名 5
            insertRow.ShoriHoshikiNm = shoriHoshikiNmTextBox.Text.Trim();

            // 処理方式種別区分 6
            insertRow.ShoriHoshikiShubetsuKbn = shoriHoshikiShubetsuKbnTextBox.Text.Trim();

            // 処理方式内部名 7
            insertRow.ShoriHoshikiNaibuNm = shoriHoshikiNaibuNmTextBox.Text.Trim();

            insertRow.InsertDt = now;
            insertRow.InsertTarm = terminal;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = terminal;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddShoriHoshikiMstRow(insertRow);

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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable CreateDataUpdate(
            ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable dataTable)
        {
            // 処理方式区分 2
            dataTable[0].ShoriHoshikiKbn = shoriHoshikiKbnTextBox.Text.Trim();

            // 処理方式コード 3
            dataTable[0].ShoriHoshikiCd = shoriHoshikiCdTextBox.Text.Trim();

            // 処理方式種別名 4
            dataTable[0].ShoriHoshikiShubetsuNm = shoriHoshikiShubetsuNmTextBox.Text.Trim();

            // 処理方式名 5
            dataTable[0].ShoriHoshikiNm = shoriHoshikiNmTextBox.Text.Trim();

            // 処理方式種別区分 6
            dataTable[0].ShoriHoshikiShubetsuKbn = shoriHoshikiShubetsuKbnTextBox.Text.Trim();

            // 処理方式内部名 7
            dataTable[0].ShoriHoshikiNaibuNm = shoriHoshikiNaibuNmTextBox.Text.Trim();

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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // 処理方式区分
            if (string.IsNullOrEmpty(shoriHoshikiKbnTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：処理方式区分が入力されていません。\r\n");
            }
            else
            {
                if (shoriHoshikiKbnTextBox.Text.Trim().Length != 1)
                {
                    errMess.Append("処理方式区分は1桁で入力して下さい。\r\n");
                }

                //20150127 HuyTX Del Start
                //if (Convert.ToInt32(shoriHoshikiKbnTextBox.Text) != 1
                //    && Convert.ToInt32(shoriHoshikiKbnTextBox.Text) != 2
                //    )
                //{
                //    errMess.Append("処理方式区分は1,2を入力して下さい。\r\n");
                //}
                //20150127 HuyTX Del End
            }

            // DEL 20140724 START ZynasSou
            //// 処理方式コード
            //if (string.IsNullOrEmpty(shoriHoshikiCdTextBox.Text.Trim()))
            //{
            //    errMess.Append("必須項目：処理方式コードが入力されていません。\r\n");
            //}
            //else
            //{
            //    if (shoriHoshikiCdTextBox.Text.Trim().Length != 3)
            //    {
            //        errMess.Append("処理方式コードは3桁で入力して下さい。\r\n");
            //    }
            //}
            // DEL 20140724 END ZynasSou

            // 処理方式種別区分
            if (string.IsNullOrEmpty(shoriHoshikiShubetsuKbnTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：処理方式種別区分が入力されていません。\r\n");
            }
            else
            {
                if (shoriHoshikiShubetsuKbnTextBox.Text.Trim().Length != 1)
                {
                    errMess.Append("処理方式種別区分は1桁で入力して下さい。\r\n");
                }

                //20150127 HuyTX Del Start
                //if (Convert.ToInt32(shoriHoshikiShubetsuKbnTextBox.Text) != 1
                //           && Convert.ToInt32(shoriHoshikiShubetsuKbnTextBox.Text) != 2
                //           && Convert.ToInt32(shoriHoshikiShubetsuKbnTextBox.Text) != 3
                //           && Convert.ToInt32(shoriHoshikiShubetsuKbnTextBox.Text) != 4
                //           && Convert.ToInt32(shoriHoshikiShubetsuKbnTextBox.Text) != 5
                //           && Convert.ToInt32(shoriHoshikiShubetsuKbnTextBox.Text) != 8)
                //{
                //    errMess.Append("処理方式種別区分は1,2,3,4,5,8を入力して下さい。\r\n");
                //}
                //20150127 HuyTX Del End
            }           

            // 処理方式種別名
            if (string.IsNullOrEmpty(shoriHoshikiShubetsuNmTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：処理方式種別名が入力されていません。\r\n");
            }
            else
            {
                if (shoriHoshikiShubetsuNmTextBox.Text.Trim().Length > 14)
                {
                    errMess.Append("処理方式種別名は14文字以下で入力して下さい。\r\n");
                }
            }

            // 処理方式名
            if (string.IsNullOrEmpty(shoriHoshikiNmTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：処理方式名が入力されていません。\r\n");
            }
            else
            {
                if (shoriHoshikiNmTextBox.Text.Trim().Length > 80)
                {
                    errMess.Append("処理方式名は80文字以下で入力して下さい。\r\n");
                }
            }

            // 処理方式内部名
            if (string.IsNullOrEmpty(shoriHoshikiNaibuNmTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：処理方式内部名が入力されていません。\r\n");
            }
            else
            {
                if (shoriHoshikiNaibuNmTextBox.Text.Trim().Length > 40)
                {
                    errMess.Append("処理方式内部名は40文字以下で入力して下さい。\r\n");
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

        #region CheckEdit
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckEdit
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  DatNT　　    新規作成
        /// 2015/01/27  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            //check edit mode add
            if (string.IsNullOrEmpty(_shoriHoshikiCd) && string.IsNullOrEmpty(_shoriHoshikiKbn))
            {
                if (shoriHoshikiKbnTextBox.Text             != string.Empty
                    || shoriHoshikiCdTextBox.Text           != string.Empty
                    || shoriHoshikiShubetsuKbnTextBox.Text  != string.Empty
                    || shoriHoshikiShubetsuNmTextBox.Text   != string.Empty
                    || shoriHoshikiNmTextBox.Text           != string.Empty
                    || shoriHoshikiNaibuNmTextBox.Text      != string.Empty
                    //Ver1.02
                    || IsEditedDgv()
                    //End
                    )
                {
                    return false;
                }
            }

            if (_dispDT != null && _dispDT.Count > 0)
            {
                if (shoriHoshikiKbnTextBox.Text                 != _dispDT[0].ShoriHoshikiKbn
                        || shoriHoshikiCdTextBox.Text           != _dispDT[0].ShoriHoshikiCd
                        || shoriHoshikiShubetsuKbnTextBox.Text  != _dispDT[0].ShoriHoshikiShubetsuKbn
                        || shoriHoshikiShubetsuNmTextBox.Text   != _dispDT[0].ShoriHoshikiShubetsuNm
                        || shoriHoshikiNaibuNmTextBox.Text      != _dispDT[0].ShoriHoshikiNaibuNm
                        || shoriHoshikiNmTextBox.Text           != _dispDT[0].ShoriHoshikiNm
                        //Ver1.02
                        || IsEditedDgv()
                        //End
                    )
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region IsEditedDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsEditedDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedDgv()
        {
            foreach (ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiListRow suiKensaJisshiRow 
                in _suishitsuKensaJisshiListDT)
            {
                if (suiKensaJisshiRow.KensaJisshi7JyoUmuFlgCheckBoxCol != suiKensaJisshiRow.KensaJisshi7JyoUmuFlgOrgCheckBoxCol
                    || suiKensaJisshiRow.KensaJisshi11JyoUmuFlgCheckBoxCol != suiKensaJisshiRow.KensaJisshi11JyoUmuFlgOrgCheckBoxCol)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion
    }
    #endregion
}
