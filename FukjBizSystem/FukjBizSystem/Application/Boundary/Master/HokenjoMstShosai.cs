using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.HokenjoMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HokenjoMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// 2014/11/20  habu　　    Added DelFlg
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HokenjoMstShosaiForm : FukjBaseForm
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
        /// HokenjoCd
        /// </summary>
        private string _hokenjoCd = string.Empty;

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
        private HokenjoMstDataSet.HokenjoMstDataTable _dispDT;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HokenjoMstShosaiForm
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
        public HokenjoMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HokenjoMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="hokenjoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HokenjoMstShosaiForm(string hokenjoCd)
        {
            this._hokenjoCd = hokenjoCd;

            InitializeComponent();
        }
        #endregion

        #region イベント

        #region HokenjoMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HokenjoMstShosaiForm_Load
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
        private void HokenjoMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_hokenjoCd))
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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
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

                // update mode
                _updateMode = _dispMode;

                // display mode
                _dispMode = DispMode.Confirm;

                Program.mForm.Text = "保健所マスタ入力確認";

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
        /// 2014/06/20  DatNT　　    新規作成
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
                    if (!string.IsNullOrEmpty(UnitCheck()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, UnitCheck());
                        return;
                    }

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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // TODO 物理削除でなく、論理削除に対応する

                // データを削除する際に、警告を表示する。
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？")
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    // 保健所マスタに対象となる保健所コードが登録されている事を確認する。
                    IDeleteBtnClickALInput alInput      = new DeleteBtnClickALInput();
                    alInput.HokenjoCd                   = hokenjyoCdTextBox.Text;
                    IDeleteBtnClickALOutput alOutput    = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    if (alOutput.Result)
                    {
                        this.DialogResult = DialogResult.OK;
                        Program.mForm.MovePrev();
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error,
                            string.Format("該当するデータは登録されていません。[保健所コード：{0}]",
                            new string[] { hokenjyoCdTextBox.Text }));
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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_updateMode == DispMode.Add )
                {
                    _dispMode = DispMode.Add;

                    Program.mForm.Text = "保健所マスタ登録";
                }
                else if (_updateMode == DispMode.Edit)
                {
                    _dispMode = DispMode.Edit;

                    Program.mForm.Text = "保健所マスタ変更";
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
        /// 2014/06/20  DatNT　　    新規作成
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
        /// 2014/06/20  DatNT　　    新規作成
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
                    // 画面表示時の内容から変化している（編集されている）場合は警告を表示する。

                    if (!CheckEdit())
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                            != System.Windows.Forms.DialogResult.Yes)
                        {
                            //goto SHOWFORM;
                            return;
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

        #region HokenjoMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
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
        private void HokenjoMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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

        #region hokenjyoZipCdTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hokenjyoZipCdTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hokenjyoZipCdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '-')
                {
                    e.Handled = true;
                }

                // only allow one negative sign
                if (e.KeyChar == '-'
                    && (sender as TextBox).Text.IndexOf('-') > -1)
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

        #region hokenjyoTelNoTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hokenjyoTelNoTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hokenjyoTelNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '-')
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

        #region hokenjyoCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hokenjyoCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23　HuyTX　　  Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hokenjyoCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if(!string.IsNullOrEmpty(hokenjyoCdTextBox.Text.Trim()))
                {
                    hokenjyoCdTextBox.Text = hokenjyoCdTextBox.Text.PadLeft(2, '0');
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
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.HokenjoCd           = _hokenjoCd;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            if (alOutput.HokenjoMstDT != null && alOutput.HokenjoMstDT.Count > 0)
            {
                SetValues(alOutput.HokenjoMstDT[0]);

                _dispDT = alOutput.HokenjoMstDT;
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
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(HokenjoMstDataSet.HokenjoMstRow row)
        {
            // 保健所コード 2
            hokenjyoCdTextBox.Text = row.HokenjoCd;

            // 保健所名称 3
            hokenjyoNmTextBox.Text = row.HokenjoNm;

            // 郵便番号 4
            hokenjyoZipCdTextBox.Text = row.HokenjoZipCd;

            // 住所 5
            hokenjyoAdrTextBox.Text = row.HokenjoAdr;

            // 電話番号 6
            hokenjyoTelNoTextBox.Text = row.HokenjoTelNo;

            //20150123 HuyTX Ver1.01
            delFlgCheckBox.Checked = row.DelFlg == "1" ? true : false;
            //End
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
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // 保健所コード (2) 
                    hokenjyoCdTextBox.ReadOnly = false;

                    // 保健所名称 (3) 
                    hokenjyoNmTextBox.ReadOnly = false;

                    // 郵便番号 (4) 
                    hokenjyoZipCdTextBox.ReadOnly = false;

                    // 住所 (5) 
                    hokenjyoAdrTextBox.ReadOnly = false;

                    // 電話番号 (6)
                    hokenjyoTelNoTextBox.ReadOnly = false;

                    //20150123 HuyTX Ver1.01
                    delFlgCheckBox.Enabled = true;
                    //End

                    // 登録ボタン (7) 
                    entryButton.Visible = true;

                    // 変更ボタン (8) 
                    changeButton.Visible = false;

                    // 削除ボタン (9) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (10)
                    reInputButton.Visible = false;

                    // 確定ボタン　(11) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (12)
                    closeButton.Visible = true;

                    this.Text = "保健所マスタ登録";

                    // メニューボタンからの遷移を制御                            
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:

                    // 保健所コード (2) 
                    hokenjyoCdTextBox.ReadOnly = true;

                    // 保健所名称 (3) 
                    hokenjyoNmTextBox.ReadOnly = false;

                    // 郵便番号 (4) 
                    hokenjyoZipCdTextBox.ReadOnly = false;

                    // 住所 (5) 
                    hokenjyoAdrTextBox.ReadOnly = false;

                    // 電話番号 (6)
                    hokenjyoTelNoTextBox.ReadOnly = false;

                    //20150123 HuyTX Ver1.01
                    delFlgCheckBox.Enabled = true;
                    //End

                    // 登録ボタン (7) 
                    entryButton.Visible = false;

                    // 変更ボタン (8) 
                    changeButton.Visible = true;

                    // 削除ボタン (9) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (10)
                    reInputButton.Visible = false;

                    // 確定ボタン　(11) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (12)
                    closeButton.Visible = true;

                    Program.mForm.Text = "保健所マスタ変更";

                    // メニューボタンからの遷移を制御                            
                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // 保健所コード (2) 
                    hokenjyoCdTextBox.ReadOnly = true;

                    // 保健所名称 (3) 
                    hokenjyoNmTextBox.ReadOnly = true;

                    // 郵便番号 (4) 
                    hokenjyoZipCdTextBox.ReadOnly = true;

                    // 住所 (5) 
                    hokenjyoAdrTextBox.ReadOnly = true;

                    // 電話番号 (6)
                    hokenjyoTelNoTextBox.ReadOnly = true;

                    //20150123 HuyTX Ver1.01
                    delFlgCheckBox.Enabled = false;
                    //End

                    // 登録ボタン (7) 
                    entryButton.Visible = false;

                    // 変更ボタン (8) 
                    changeButton.Visible = true;

                    // 削除ボタン (9) 
                    deleteButton.Visible = true;

                    // 再入力ボタン (10)
                    reInputButton.Visible = false;

                    // 確定ボタン　(11) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (12)
                    closeButton.Visible = true;

                    this.Text = "保健所マスタ詳細";

                    // メニューボタンからの遷移を制御                            
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // 保健所コード (2) 
                    hokenjyoCdTextBox.ReadOnly = true;

                    // 保健所名称 (3) 
                    hokenjyoNmTextBox.ReadOnly = true;

                    // 郵便番号 (4) 
                    hokenjyoZipCdTextBox.ReadOnly = true;

                    // 住所 (5) 
                    hokenjyoAdrTextBox.ReadOnly = true;

                    // 電話番号 (6)
                    hokenjyoTelNoTextBox.ReadOnly = true;

                    //20150123 HuyTX Ver1.01
                    delFlgCheckBox.Enabled = false;
                    //End

                    // 登録ボタン (7) 
                    entryButton.Visible = false;

                    // 変更ボタン (8) 
                    changeButton.Visible = false;

                    // 削除ボタン (9) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (10)
                    reInputButton.Visible = true;

                    // 確定ボタン　(11) 
                    decisionButton.Visible = true;

                    // 閉じるボタン (12)
                    closeButton.Visible = true;

                    Program.mForm.Text = "保健所マスタ入力確認";

                    // メニューボタンからの遷移を制御                            
                    Program.mForm.SetMenuEnabled(true);

                    break;

                default:
                    
                    // メニューボタンからの遷移を制御                            
                    Program.mForm.SetMenuEnabled(true);

                    break;
            }
        }
        #endregion
        
        #region CheckInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckInput()
        {
            // 保健所コード 2
            if (hokenjyoCdTextBox.Text.Trim().Length != 2)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "保健所コードは2桁で入力して下さい。");
                return false;
            }

            //保健所名称 3
            if (hokenjyoNmTextBox.Text.Trim().Length > 24)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "保健所名称は24文字以下で入力して下さい。");
                return false;
            }

            // 郵便番号 4
            if (!Utility.Utility.IsZipCode(hokenjyoZipCdTextBox.Text.Trim()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "郵便番号は半角数字と-(半角ハイフン)で入力して下さい。");
                return false;
            }

            // 電話番号 5
            if (!Utility.Utility.IsPhoneNumber(hokenjyoTelNoTextBox.Text.Trim()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "電話番号は半角数字と-(半角ハイフン)で入力して下さい。");
                return false;
            }

            // 住所 6
            if (hokenjyoAdrTextBox.Text.Trim().Length > 80)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "住所は80文字以下で入力して下さい。");
                return false;
            }

            return true;
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
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string UnitCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 保健所コード 2
            if (string.IsNullOrEmpty(hokenjyoCdTextBox.Text))
            {
                errMsg.AppendLine("必須項目：保健所コードが入力されていません。");
            }
            else if (hokenjyoCdTextBox.Text.Trim().Length != 2)
            {
                errMsg.AppendLine("保健所コードは2桁で入力して下さい。");
            }

            // 保健所名称 3
            if (string.IsNullOrEmpty(hokenjyoNmTextBox.Text))
            {
                errMsg.AppendLine("必須項目：保健所名称が入力されていません。");
            }
            else if (hokenjyoNmTextBox.Text.Trim().Length > 24)
            {
                errMsg.AppendLine("保健所名称は24文字以下で入力して下さい。");
            }

            // 郵便番号 4
            if (string.IsNullOrEmpty(hokenjyoZipCdTextBox.Text))
            {
                errMsg.Append("必須項目：郵便番号が入力されていません。\r\n");
            }
            else if (hokenjyoZipCdTextBox.Text.Length != 8)
            {
                errMsg.Append("郵便番号は8桁で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsNumAndNegative(hokenjyoZipCdTextBox.Text))
            {
                errMsg.Append("郵便番号は半角数字と-(半角ハイフン)で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsZipCode(hokenjyoZipCdTextBox.Text))
            {
                errMsg.Append("郵便番号の形式が不正です。\r\n");
            }

            // 電話番号 5
            if (string.IsNullOrEmpty(hokenjyoTelNoTextBox.Text))
            {
                errMsg.Append("必須項目：電話番号が入力されていません。\r\n");
            }
            else if (hokenjyoTelNoTextBox.Text.Length < 12)
            {
                errMsg.Append("電話番号は12～13桁で入力して下さい。\r\n");
            }
            //else if (telNoTextBox.Text.Length != 13)
            //{
            //    errMsg.Append("電話番号は13文字で入力して下さい。\r\n");
            //}
            else if (!Utility.Utility.IsNumAndNegative(hokenjyoTelNoTextBox.Text.Trim()))
            {
                errMsg.Append("電話番号は半角数字と-(半角ハイフン)で入力して下さい。\r\n");
            }
            //else if (!Utility.Utility.IsPhoneNumber(telNoTextBox.Text))
            //{
            //    errMsg.Append("電話番号の形式が不正です。\r\n");
            //}

            // 住所 6
            if (string.IsNullOrEmpty(hokenjyoAdrTextBox.Text))
            {
                errMsg.AppendLine("必須項目：住所が入力されていません。");
            }
            else if (hokenjyoAdrTextBox.Text.Trim().Length > 80)
            {
                errMsg.AppendLine("住所は80文字以下で入力して下さい。");
            }

            return errMsg.ToString();
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
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            HokenjoMstDataSet.HokenjoMstDataTable updateDT = new HokenjoMstDataSet.HokenjoMstDataTable();

            if (_updateMode == DispMode.Add)
            {
                updateDT = CreateHokenjoMstDTInsert();
            }
            else
            {
                updateDT = CreateHokenjoMstDTUpdate(_dispDT);
            }

            IConfirmBtnClickALInput alInput     = new ConfirmBtnClickALInput();
            alInput.DispMode                    = _updateMode;
            alInput.HokenjoMstDT                = updateDT;
            IConfirmBtnClickALOutput alOutput   = new ConfirmBtnClickApplicationLogic().Execute(alInput);

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

        #region CheckEdit
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckEdit
        /// <summary>
        /// 編集内容破棄チェック
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23  DatNT　　    新規作成
        /// 2015/01/23  HuyTX　　    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            //check edit mode add
            if (string.IsNullOrEmpty(_hokenjoCd))
            {
                if (hokenjyoCdTextBox.Text != string.Empty
                    || hokenjyoNmTextBox.Text != string.Empty
                    || hokenjyoZipCdTextBox.Text != string.Empty
                    || hokenjyoTelNoTextBox.Text != string.Empty
                    || hokenjyoAdrTextBox.Text != string.Empty
                    || delFlgCheckBox.Checked == true
                    )
                {
                    return false;
                }
            }

            if (_dispDT != null && _dispDT.Count > 0)
            {
                if (hokenjyoCdTextBox.Text              != _dispDT[0].HokenjoCd
                        || hokenjyoNmTextBox.Text       != _dispDT[0].HokenjoNm
                        || hokenjyoZipCdTextBox.Text    != _dispDT[0].HokenjoZipCd
                        || hokenjyoTelNoTextBox.Text    != _dispDT[0].HokenjoTelNo
                        || hokenjyoAdrTextBox.Text      != _dispDT[0].HokenjoAdr
                        || (delFlgCheckBox.Checked && _dispDT[0].DelFlg != "1")
                        || (!delFlgCheckBox.Checked && _dispDT[0].DelFlg == "1")
                    )
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region CreateHokenjoMstDTInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHokenjoMstDTInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HokenjoMstDataSet.HokenjoMstDataTable CreateHokenjoMstDTInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            HokenjoMstDataSet.HokenjoMstDataTable insertDT = new HokenjoMstDataSet.HokenjoMstDataTable();

            HokenjoMstDataSet.HokenjoMstRow insertRow = insertDT.NewHokenjoMstRow();

            // 保健所コード 2
            insertRow.HokenjoCd = hokenjyoCdTextBox.Text.Trim();

            // 保健所名称 3
            insertRow.HokenjoNm = hokenjyoNmTextBox.Text.Trim();

            // 郵便番号 4
            insertRow.HokenjoZipCd = hokenjyoZipCdTextBox.Text.Trim();

            // 住所 5
            insertRow.HokenjoAdr = hokenjyoAdrTextBox.Text.Trim();

            // 電話番号 6
            insertRow.HokenjoTelNo = hokenjyoTelNoTextBox.Text.Trim();

            //20150123 HuyTX Mod
            // 20141120 habu 
            // 削除フラグ
            //insertRow.DelFlg = "0";
            insertRow.DelFlg = delFlgCheckBox.Checked ? "1" : "0";
            //End

            insertRow.InsertDt = now;
            insertRow.InsertTarm = terminal;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = terminal;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddHokenjoMstRow(insertRow);

            // 行の状態を設定
            insertRow.AcceptChanges();

            // 行の状態を設定（新規）
            insertRow.SetAdded();

            return insertDT;
        }
        #endregion

        #region CreateHokenjoMstDTUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHokenjoMstDTUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HokenjoMstDataSet.HokenjoMstDataTable CreateHokenjoMstDTUpdate(
            HokenjoMstDataSet.HokenjoMstDataTable dataTable)
        {
            // 保健所名称 (3)
            dataTable[0].HokenjoNm = hokenjyoNmTextBox.Text.Trim();

            // 郵便番号 (4) 
            dataTable[0].HokenjoZipCd = hokenjyoZipCdTextBox.Text.Trim();

            // 住所  (5)
            dataTable[0].HokenjoAdr = hokenjyoAdrTextBox.Text.Trim();

            // 電話番号 (6)
            dataTable[0].HokenjoTelNo = hokenjyoTelNoTextBox.Text.Trim();

            //20150123 HuyTX Ver1.01
            //削除フラグ
            dataTable[0].DelFlg = delFlgCheckBox.Checked ? "1" : "0";
            //End

            return dataTable;
        }
        #endregion

        #endregion

    }
    #endregion
}
