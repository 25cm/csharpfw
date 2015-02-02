using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuMstShosaiForm : FukjBaseForm
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
        /// SuishitsuCd
        /// </summary>
        private string _suishitsuCd = string.Empty;

        /// <summary>
        /// SuishitsuShishoCd
        /// </summary>
        private string _suishitsuShishoCd = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Update mode
        /// </summary>
        private DispMode _updateMode;

        /// <summary>
        /// SuishitsuMstDataTable
        /// </summary>
        private SuishitsuMstDataSet.SuishitsuMstDataTable _dispDT;
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuMstList
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuMstList
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="suishitsuCd"></param>
        /// <param name="suishitsuShishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuMstShosaiForm(string suishitsuCd, string suishitsuShishoCd)
        {
            this._suishitsuCd = suishitsuCd;
            this._suishitsuShishoCd = suishitsuShishoCd;

            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SuishitsuMstShosai_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuMstShosai_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuMstShosai_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_suishitsuCd) && string.IsNullOrEmpty(_suishitsuShishoCd))
                {
                    _dispMode = DispMode.Add;
                    this.Text = "水質マスタ登録";
                }
                else
                {
                    _dispMode = DispMode.Detail;
                    this.Text = "水質マスタ詳細";
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

        #region EntryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： EntryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void EntryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DataCheck()) { return; }

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

        #region ChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeButton_Click(object sender, EventArgs e)
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
                    if (!DataCheck()) return;

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

        #region DeleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DeleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DeleteButton_Click(object sender, EventArgs e)
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
                    // 水質マスタに対象となる水質コードが登録されている事を確認する。
                    IDeleteBtnClickALInput alInput   = new DeleteBtnClickALInput();
                    alInput.SuishitsuShishoCd        = _suishitsuShishoCd;
                    alInput.SuishitsuCd              = _suishitsuCd;
                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    if (alOutput.Result)
                    {
                        this.DialogResult = DialogResult.OK;
                        Program.mForm.MovePrev();
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error,
                            string.Format("該当するデータは登録されていません。[水質コード：{0}]",
                            new string[] { suishitsuCdTextBox.Text }));
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

        #region ReInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ReInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ReInputButton_Click(object sender, EventArgs e)
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

        #region DecisionButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DecisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DecisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Update successfully!
                if (DoUpdate())
                {
                    this.DialogResult = DialogResult.OK;
                    Program.mForm.MovePrev();
                }
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

        #region CloseButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CloseButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Detail mode
                if (this._dispMode == DispMode.Detail)
                {
                    goto SHOWFORM;
                }

                // Add mode
                if (string.IsNullOrEmpty(_suishitsuCd))
                {
                    if (!EditControl() || MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        goto SHOWFORM;
                    }

                    return;
                }

                // Other modes
                if (!CheckEdit())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        goto SHOWFORM;
                    }

                    return;
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

        #region SuishitsuMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput    = new FormLoadALInput();
            alInput.SuishitsuCd         = _suishitsuCd;
            alInput.SuishitsuShishoCd   = _suishitsuShishoCd;
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);

            if (alOutput.SuishitsuMstDT != null && alOutput.SuishitsuMstDT.Count > 0)
            {
                SetValues(alOutput.SuishitsuMstDT[0]);

                _dispDT = alOutput.SuishitsuMstDT;
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(SuishitsuMstDataSet.SuishitsuMstRow row)
        {
            // 支所名称 2
            shishoNmComboBox.SelectedValue = row.SuishitsuShishoCd.ToString();

            // 水質コード 3
            suishitsuCdTextBox.Text = row.SuishitsuCd;

            // 水質名称 4
            suishitsuNmTextBox.Text = row.SuishitsuNm;
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
        /// 2014/06/23  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // 支所名称 (2)
                    shishoNmComboBox.Enabled = true;

                    // 水質コード (3)
                    // UPD 20140724 START ZynasSou
                    //suishitsuCdTextBox.ReadOnly = false;
                    suishitsuCdTextBox.ReadOnly = true;
                    // UPD 20140724 END ZynasSou

                    // 水質名称 (4)
                    suishitsuNmTextBox.ReadOnly = false;

                    // 登録ボタン (5) 
                    entryButton.Visible = true;

                    // 変更ボタン (6) 
                    changeButton.Visible = false;

                    // 削除ボタン (7) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (8)
                    reInputButton.Visible = false;

                    // 確定ボタン　(9) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (10)
                    closeButton.Visible = true;

                    Program.mForm.Text = "水質マスタ登録";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:

                    // 支所名称 (2)
                    shishoNmComboBox.Enabled = false;

                    // 水質コード (3)
                    suishitsuCdTextBox.ReadOnly = true;

                    // 水質名称 (4)
                    suishitsuNmTextBox.ReadOnly = false;

                    // 登録ボタン (5) 
                    entryButton.Visible = false;

                    // 変更ボタン (6) 
                    changeButton.Visible = true;

                    // 削除ボタン (7) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (8)
                    reInputButton.Visible = false;

                    // 確定ボタン　(9) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (10)
                    closeButton.Visible = true;

                    Program.mForm.Text = "水質マスタ変更";
                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // 支所名称 (2)
                    shishoNmComboBox.Enabled = false;

                    // 水質コード (3)
                    suishitsuCdTextBox.ReadOnly = true;

                    // 水質名称 (4)
                    suishitsuNmTextBox.ReadOnly = true;

                    // 登録ボタン (5) 
                    entryButton.Visible = false;

                    // 変更ボタン (6) 
                    changeButton.Visible = true;

                    // 削除ボタン (7) 
                    deleteButton.Visible = true;

                    // 再入力ボタン (8)
                    reInputButton.Visible = false;

                    // 確定ボタン　(9) 
                    decisionButton.Visible = false;

                    // 閉じるボタン (10)
                    closeButton.Visible = true;

                    Program.mForm.Text = "水質マスタ変更";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // 支所名称 (2)
                    shishoNmComboBox.Enabled = false;

                    // 水質コード (3)
                    suishitsuCdTextBox.ReadOnly = true;

                    // 水質名称 (4)
                    suishitsuNmTextBox.ReadOnly = true;

                    // 登録ボタン (5) 
                    entryButton.Visible = false;

                    // 変更ボタン (6) 
                    changeButton.Visible = false;

                    // 削除ボタン (7) 
                    deleteButton.Visible = false;

                    // 再入力ボタン (8)
                    reInputButton.Visible = true;

                    // 確定ボタン　(9) 
                    decisionButton.Visible = true;

                    // 閉じるボタン (10)
                    closeButton.Visible = true;

                    Program.mForm.Text = "水質マスタ入力確認";
                    Program.mForm.SetMenuEnabled(true);

                    break;

                default:
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckInput()
        {
            // DEL 20140724 START ZynasSou
            //// 水質コード 3
            //if (!Utility.Utility.IsDecimal(suishitsuCdTextBox.Text))
            //{
            //    MessageForm.Show2(MessageForm.DispModeType.Error, "水質コードは半角数字で入力して下さい。");
            //    return false;
            //}
            // DEL 20140724 END ZynasSou

            //// DEL 20140724 START ZynasSou
            //// 水質コード 3
            //if (suishitsuCdTextBox.Text.Trim().Length != 3)
            //{
            //    MessageForm.Show2(MessageForm.DispModeType.Error, "水質コードは3桁で入力して下さい。");
            //    return false;
            //}
            // DEL 20140724 END ZynasSou

            // 水質名称 4
            if (suishitsuNmTextBox.Text.Trim().Length > 30)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "水質名称は30文字以下で入力して下さい。");
                return false;
            }

            return true;
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
        /// 2014/06/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 支所名称 (2)
            if (shishoNmComboBox.SelectedIndex == -1 || shishoNmComboBox.SelectedIndex == 0)
            {
                errMsg.Append("必須項目：支所名称が選択されていません。\r\n");
            }

            // DEL 20140724 START ZynasSou
            //// 水質コード (3)
            //if (String.IsNullOrEmpty(suishitsuCdTextBox.Text.Trim()))
            //{
            //    errMsg.Append("必須項目：水質コードが入力されていません。\r\n");
            //}
            //else if (!Utility.Utility.IsDecimal(suishitsuCdTextBox.Text))
            //{
            //    errMsg.Append("水質コードは半角数字で入力して下さい。\r\n");
            //}
            //else if (suishitsuCdTextBox.Text.Trim().Length != 3)
            //{
            //    errMsg.Append("水質コードは3桁で入力して下さい。\r\n");
            //}
            // DEL 20140724 END ZynasSou

            // 水質名称 (4)
            if (String.IsNullOrEmpty(suishitsuNmTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：水質名称が入力されていません。\r\n");
            }
            else if (suishitsuNmTextBox.Text.Trim().Length > 30)
            {
                errMsg.Append("水質名称は30文字以下で入力して下さい。\r\n");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
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
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoUpdate()
        {
            SuishitsuMstDataSet.SuishitsuMstDataTable updateDT = new SuishitsuMstDataSet.SuishitsuMstDataTable();

            if (_updateMode == DispMode.Add)
            {
                updateDT = CreateSuishitsuMstDTInsert();
            }
            else
            {
                updateDT = CreateSuishitsuMstDTUpdate(_dispDT);
            }

            IConfirmBtnClickALInput alInput     = new ConfirmBtnClickALInput();
            alInput.DispMode                    = _updateMode;
            alInput.SuishitsuMstDT              = updateDT;
            IConfirmBtnClickALOutput alOutput   = new ConfirmBtnClickApplicationLogic().Execute(alInput);

            // An error occur
            if (!string.IsNullOrEmpty(alOutput.ErrMsg))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
                return false;
            }

            return true;
        }
        #endregion

        #region CreateSuishitsuMstDTInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuMstDTInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuMstDataSet.SuishitsuMstDataTable CreateSuishitsuMstDTInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            SuishitsuMstDataSet.SuishitsuMstDataTable insertDT = new SuishitsuMstDataSet.SuishitsuMstDataTable();

            SuishitsuMstDataSet.SuishitsuMstRow insertRow = insertDT.NewSuishitsuMstRow();

            // 支所名称 2
            insertRow.SuishitsuShishoCd = shishoNmComboBox.SelectedValue.ToString();

            // 水質コード 3
            // UPD 20140724 START ZynasSou
            //insertRow.SuishitsuCd = suishitsuCdTextBox.Text.Trim();
            insertRow.SuishitsuCd = Utility.Saiban.GetKeyRenban("SuishitsuMst", shishoNmComboBox.SelectedValue.ToString(), "", "").PadLeft(3,'0');
            // UPD 20140724 START ZynasSou

            // 水質名称 4
            insertRow.SuishitsuNm = suishitsuNmTextBox.Text.Trim();

            insertRow.InsertDt = now;
            insertRow.InsertTarm = terminal;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = terminal;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddSuishitsuMstRow(insertRow);

            // 行の状態を設定
            insertRow.AcceptChanges();

            // 行の状態を設定（新規）
            insertRow.SetAdded();

            return insertDT;
        }
        #endregion

        #region CreateSuishitsuMstDTUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuMstDTUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuMstDataSet.SuishitsuMstDataTable CreateSuishitsuMstDTUpdate(
            SuishitsuMstDataSet.SuishitsuMstDataTable dataTable)
        {
            // 支所名称 2
            dataTable[0].SuishitsuShishoCd = shishoNmComboBox.SelectedValue.ToString();

            // 水質コード 3
            dataTable[0].SuishitsuCd = suishitsuCdTextBox.Text.Trim();

            // 水質名称 4
            dataTable[0].SuishitsuNm = suishitsuNmTextBox.Text.Trim();

            return dataTable;
        }
        #endregion

        #region CheckEdit
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckEdit
        /// <summary>
        /// チェック内容
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            if (_dispDT != null && _dispDT.Count > 0)
            {
                if (shishoNmComboBox.SelectedValue.ToString()   != _dispDT[0].SuishitsuShishoCd
                        || suishitsuCdTextBox.Text.Trim() != _dispDT[0].SuishitsuCd
                        || suishitsuNmTextBox.Text.Trim()       != _dispDT[0].SuishitsuNm)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region EditControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditControl
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// TRUE: Control is edited
        /// FALSE: Control is not edited
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditControl()
        {
            // Any item is edited
            if (shishoNmComboBox.SelectedIndex > 0
                || !string.IsNullOrEmpty(suishitsuCdTextBox.Text)
                || !string.IsNullOrEmpty(suishitsuNmTextBox.Text))
            {
                return true;
            }

            // No items is edited
            return false;
        }
        #endregion

        #endregion

    }
    #endregion
}
