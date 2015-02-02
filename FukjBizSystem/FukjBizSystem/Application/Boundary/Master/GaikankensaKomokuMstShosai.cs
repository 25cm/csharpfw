using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.GaikankensaKomokuMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaikankensaKomokuMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/02  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GaikankensaKomokuMstShosaiForm : FukjBaseForm
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
        /// gaikankensaKomokuCd
        /// </summary>
        private string _gaikankensaKomokuCd = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Update mode
        /// </summary>
        private DispMode _updateMode;

        /// <summary>
        /// GaikankensaKomokuMstDataTable
        /// </summary>
        private GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable _dispDT;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GaikankensaKomokuMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GaikankensaKomokuMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GaikankensaKomokuMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="gaikankensaKomokuCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GaikankensaKomokuMstShosaiForm(string gaikankensaKomokuCd)
        {
            InitializeComponent();

            this._gaikankensaKomokuCd = gaikankensaKomokuCd;
        }
        #endregion

        #region イベント

        #region GaikankensaKomokuMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GaikankensaKomokuMstShosaiForm_Load
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
        private void GaikankensaKomokuMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_gaikankensaKomokuCd))
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
        /// 2014/07/02  DatNT　　    新規作成
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
        /// 2014/07/02  DatNT　　    新規作成
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
        /// 2014/07/02  DatNT　　    新規作成
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
                    IDeleteBtnClickALInput alInput      = new DeleteBtnClickALInput();
                    alInput.GaikankensaKomokuCd         = gaikankensaKomokuCdTextBox.Text;
                    IDeleteBtnClickALOutput alOutput    = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    if (alOutput.Result)
                    {
                        this.DialogResult = DialogResult.OK;
                        Program.mForm.MovePrev();
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error,
                            string.Format("該当するデータは登録されていません。[外観検査項目コード：{0}]",
                            new string[] { gaikankensaKomokuCdTextBox.Text }));
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
        /// 2014/07/02  DatNT　　    新規作成
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
        /// 2014/07/02  DatNT　　    新規作成
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
        /// 2014/07/02  DatNT　　    新規作成
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
                            Program.mForm.MovePrev();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Program.mForm.MovePrev();
                    }
                }
                else
                {
                    Program.mForm.MovePrev();
                }

                // Enable menu
                Program.mForm.SetMenuEnabled(true);
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

        #region GaikankensaKomokuMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GaikankensaKomokuMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02  DatNT　　    新規作成
        /// 2015/01/16  Mehara      v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GaikankensaKomokuMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.GaikankensaKomokuCd = _gaikankensaKomokuCd;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            if (alOutput.GaikankensaKomokuMstDT != null && alOutput.GaikankensaKomokuMstDT.Count > 0)
            {
                SetValues(alOutput.GaikankensaKomokuMstDT[0]);

                _dispDT = alOutput.GaikankensaKomokuMstDT;
            }

            SetControlModeView();
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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // 外観検査項目コード
                    // UPD 20140724 START ZynasSou
                    //gaikankensaKomokuCdTextBox.ReadOnly = false;
                    gaikankensaKomokuCdTextBox.ReadOnly = true;
                    // UPD 20140724 END ZynasSou

                    // 外観検査項目名称
                    gaikankensaKomokuNmTextBox.ReadOnly = false;

                    // DEL START 20140718 ZynasSou
                    //// 前外観検査項目コード
                    //zenGaikankensaKomokuCdTextBox.ReadOnly = false;
                    //
                    //// 前外観検査項目略名
                    //zenGaikankensaKomokuRyakumeiTextBox.ReadOnly = false;
                    // DEL END 20140718 ZynasSou

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

                    this.Text = "外観検査項目マスタ登録";
                    Program.mForm.Text = "外観検査項目マスタ登録";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:

                    // 外観検査項目コード
                    gaikankensaKomokuCdTextBox.ReadOnly = true;

                    // 外観検査項目名称
                    gaikankensaKomokuNmTextBox.ReadOnly = false;

                    // DEL START 20140718 ZynasSou
                    //// 前外観検査項目コード
                    //zenGaikankensaKomokuCdTextBox.ReadOnly = false;
                    //
                    //// 前外観検査項目略名
                    //zenGaikankensaKomokuRyakumeiTextBox.ReadOnly = false;
                    // DEL END 20140718 ZynasSou
                    
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

                    this.Text = " 外観検査項目マスタ変更";
                    Program.mForm.Text = " 外観検査項目マスタ変更";

                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // 外観検査項目コード
                    gaikankensaKomokuCdTextBox.ReadOnly = true;

                    // 外観検査項目名称
                    gaikankensaKomokuNmTextBox.ReadOnly = true;

                    // DEL START 20140718 ZynasSou
                    //// 前外観検査項目コード
                    //zenGaikankensaKomokuCdTextBox.ReadOnly = true;
                    //
                    //// 前外観検査項目略名
                    //zenGaikankensaKomokuRyakumeiTextBox.ReadOnly = true;
                    // DEL END 20140718 ZynasSou

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

                    this.Text = "外観検査項目マスタ詳細";
                    Program.mForm.Text = "外観検査項目マスタ詳細";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // 外観検査項目コード
                    gaikankensaKomokuCdTextBox.ReadOnly = true;

                    // 外観検査項目名称
                    gaikankensaKomokuNmTextBox.ReadOnly = true;

                    // DEL START 20140718 ZynasSou
                    //// 前外観検査項目コード
                    //zenGaikankensaKomokuCdTextBox.ReadOnly = true;
                    //
                    //// 前外観検査項目略名
                    //zenGaikankensaKomokuRyakumeiTextBox.ReadOnly = true;
                    // DEL END 20140718 ZynasSou

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

                    this.Text = "外観検査項目マスタ入力確認";
                    Program.mForm.Text = "外観検査項目マスタ入力確認";

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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable updateDT = new GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable();

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
            alInput.GaikankensaKomokuMstDT      = updateDT;
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
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable CreateDataInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable insertDT = new GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable();

            GaikankensaKomokuMstDataSet.GaikankensaKomokuMstRow insertRow = insertDT.NewGaikankensaKomokuMstRow();

            // ADD 20140724 START ZynasSou
            // 未入力項目の値設定（暫定）
            // 前外観検査項目コード
            insertRow.ZenGaikankensaKomokuCd = string.Empty;
            // 前外観検査項目略名
            insertRow.ZenGaikankensaKomokuRyakumei = string.Empty;
            // ADD 20140724 START ZynasSou

            // 外観検査項目コード
            // UPD 20140724 START ZynasSou
            //insertRow.GaikankensaKomokuCd = gaikankensaKomokuCdTextBox.Text.Trim();
            insertRow.GaikankensaKomokuCd = Utility.Saiban.GetKeyRenban("GaikankensaKomokuMst", "", "", "").PadLeft(3, '0');
            // UPD 20140724 END ZynasSou

            // 外観検査項目名称
            insertRow.GaikankensaKomokuNm = gaikankensaKomokuNmTextBox.Text.Trim();

            // DEL START 20140718 ZynasSou
            //// 前外観検査項目コード
            //insertRow.ZenGaikankensaKomokuCd = zenGaikankensaKomokuCdTextBox.Text.Trim();
            //
            //// 前外観検査項目略名
            //insertRow.ZenGaikankensaKomokuRyakumei = zenGaikankensaKomokuRyakumeiTextBox.Text.Trim();
            // DEL END 20140718 ZynasSou

            insertRow.InsertDt = now;
            insertRow.InsertTarm = terminal;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = terminal;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddGaikankensaKomokuMstRow(insertRow);

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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable CreateDataUpdate(
            GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable dataTable)
        {
            // 外観検査項目コード
            dataTable[0].GaikankensaKomokuCd = gaikankensaKomokuCdTextBox.Text.Trim();

            // 外観検査項目名称
            dataTable[0].GaikankensaKomokuNm = gaikankensaKomokuNmTextBox.Text.Trim();

            // DEL START 20140718 ZynasSou
            //// 前外観検査項目コード
            //dataTable[0].ZenGaikankensaKomokuCd = zenGaikankensaKomokuCdTextBox.Text.Trim();
            //
            //// 前外観検査項目略名
            //dataTable[0].ZenGaikankensaKomokuRyakumei = zenGaikankensaKomokuRyakumeiTextBox.Text.Trim();
            // DEL END 20140718 ZynasSou

            return dataTable;
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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(GaikankensaKomokuMstDataSet.GaikankensaKomokuMstRow row)
        {
            // 外観検査項目コード
            gaikankensaKomokuCdTextBox.Text = row.GaikankensaKomokuCd;

            // 外観検査項目名称
            gaikankensaKomokuNmTextBox.Text = row.GaikankensaKomokuNm;

            // DEL START 20140718 ZynasSou
            //// 前外観検査項目コード
            //zenGaikankensaKomokuCdTextBox.Text = row.ZenGaikankensaKomokuCd;
            //
            //// 前外観検査項目略名
            //zenGaikankensaKomokuRyakumeiTextBox.Text = row.ZenGaikankensaKomokuRyakumei;
            // DEL END 20140718 ZynasSou
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
        /// 2014/07/03  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // DEL 20140724 START ZynasSou
            //// 外観検査項目コード
            //if (string.IsNullOrEmpty(gaikankensaKomokuCdTextBox.Text))
            //{
            //    errMsg.Append("必須項目：外観検査項目コードが入力されていません。\r\n");
            //}
            //else
            //{
            //    if (gaikankensaKomokuCdTextBox.Text.Length != 3)
            //    {
            //        errMsg.Append("外観検査項目コードは3桁で入力して下さい。\r\n");
            //    }
            //}
            // DEL 20140724 END ZynasSou

            // 外観検査項目名称
            if (string.IsNullOrEmpty(gaikankensaKomokuNmTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：外観検査項目名称が入力されていません。\r\n");
            }
            else
            {
                if (gaikankensaKomokuNmTextBox.Text.Trim().Length > 80)
                {
                    errMsg.Append("外観検査項目名称は80文字以下で入力して下さい。\r\n");
                }
            }

            // DEL START 20140718 ZynasSou
            //// 前外観検査項目コード
            //if (string.IsNullOrEmpty(zenGaikankensaKomokuCdTextBox.Text))
            //{
            //    errMsg.Append("必須項目：前外観検査項目コードが入力されていません。\r\n");
            //}
            //else
            //{
            //    if (zenGaikankensaKomokuCdTextBox.Text.Length != 3)
            //    {
            //        errMsg.Append("前外観検査項目コードは3桁で入力して下さい。\r\n");
            //    }
            //}
            // DEL END 20140718 ZynasSou

            // DEL START 20140718 ZynasSou
            //// 前外観検査項目略名
            //if (string.IsNullOrEmpty(zenGaikankensaKomokuRyakumeiTextBox.Text.Trim()))
            //{
            //    errMsg.Append("必須項目：前外観検査項目略名が入力されていません。\r\n");
            //}
            //else
            //{
            //    if (zenGaikankensaKomokuRyakumeiTextBox.Text.Trim().Length > 24)
            //    {
            //        errMsg.Append("前外観検査項目略名は24文字以下で入力して下さい。\r\n");
            //    }
            //}
            // DEL END 20140718 ZynasSou

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            //check edit mode add
            if (string.IsNullOrEmpty(_gaikankensaKomokuCd))
            {
                // UPD START 20140718 ZynasSou
                //if (gaikankensaKomokuCdTextBox.Text != string.Empty
                //    || gaikankensaKomokuNmTextBox.Text != string.Empty
                //    || zenGaikankensaKomokuCdTextBox.Text != string.Empty
                //    || zenGaikankensaKomokuRyakumeiTextBox.Text != string.Empty
                //    )
                if (gaikankensaKomokuCdTextBox.Text != string.Empty
                    || gaikankensaKomokuNmTextBox.Text != string.Empty
                    )
                // UPD END 20140718 ZynasSou
                {
                    return false;
                }
            }

            if (_dispDT != null && _dispDT.Count > 0)
            {
                // UPD START 20140718 ZynasSou
                //if (gaikankensaKomokuCdTextBox.Text != _dispDT[0].GaikankensaKomokuCd
                //        || gaikankensaKomokuNmTextBox.Text != _dispDT[0].GaikankensaKomokuNm
                //        || zenGaikankensaKomokuCdTextBox.Text != _dispDT[0].ZenGaikankensaKomokuCd
                //        || zenGaikankensaKomokuRyakumeiTextBox.Text != _dispDT[0].ZenGaikankensaKomokuRyakumei)
                if (gaikankensaKomokuCdTextBox.Text != _dispDT[0].GaikankensaKomokuCd
                        || gaikankensaKomokuNmTextBox.Text != _dispDT[0].GaikankensaKomokuNm)
                // UPD END 20140718 ZynasSou
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
