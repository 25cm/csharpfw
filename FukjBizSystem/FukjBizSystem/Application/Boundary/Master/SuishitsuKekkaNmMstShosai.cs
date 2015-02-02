using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuKekkaNmMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKekkaNmMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/02　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKekkaNmMstShosaiForm : FukjBaseForm
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
        /// shishoCd
        /// </summary>
        private string _shishoCd = string.Empty;

        /// <summary>
        /// suishitsuKekkaCd
        /// </summary>
        private string _suishitsuKekkaCd = string.Empty;

        /// <summary>
        /// SuishitsuKekkaNmMstDT
        /// </summary>
        SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable _suishitsuKekkaNmMstDT = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKekkaNmMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　HuyTX  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKekkaNmMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKekkaNmMstShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="suishitsuKekkaCd"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　HuyTX  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKekkaNmMstShosaiForm(string shishoCd, string suishitsuKekkaCd)
        {
            this._shishoCd = shishoCd;
            this._suishitsuKekkaCd = suishitsuKekkaCd;
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SuishitsuKekkaNmMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKekkaNmMstShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKekkaNmMstShosaiForm_Load(object sender, EventArgs e)
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
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
        /// 2014/07/03　HuyTX　　    新規作成
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
        /// 2014/07/03　HuyTX　　    新規作成
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
                    alInput.ShishoCd = this._shishoCd;
                    alInput.SuishitsuKekkaNmCd = this._suishitsuKekkaCd;

                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    //check not exist record
                    if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                        return;
                    }

                    //close form and redirect SuishitsuKekkaNmMstListForm
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
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(this._shishoCd) && string.IsNullOrEmpty(this._suishitsuKekkaCd))
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
        /// 2014/07/03　HuyTX　　    新規作成
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
                if (string.IsNullOrEmpty(this._shishoCd) && string.IsNullOrEmpty(this._suishitsuKekkaCd))
                {
                    alInput.DisplayMode = DispMode.Add;
                    alInput.SuishitsuKekkaNmDT = CreateSuishitsuKekkaNmMstInsert();
                }
                else
                {
                    //update data
                    alInput.DisplayMode = DispMode.Edit;
                    alInput.SuishitsuKekkaNmDT = CreateSuishitsuKekkaNmMstUpdate(this._suishitsuKekkaNmMstDT);
                }

                IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                    return;
                }

                //close form and redirect SuishitsuKekkaNmMstListForm
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
        /// 2014/07/03　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                if (this._displayMode != DispMode.Detail)
                {
                    if (IsEditedControl())
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes)
                        {
                            return;
                        }
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

        #region SuishitsuKekkaNmMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKekkaNmMstShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　HuyTX　　    新規作成
        /// 2015/01/16  Mehera      v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKekkaNmMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/07/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShishoCd = this._shishoCd;
            alInput.SuishitsuKekkaNmCd = this._suishitsuKekkaCd;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            this._suishitsuKekkaNmMstDT = alOutput.SuishitsuKekkaNmMstDT;

            // Set default Shisho combobox
            Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);

            if (!string.IsNullOrEmpty(this._shishoCd) && !string.IsNullOrEmpty(this._suishitsuKekkaCd))
            {
                this._displayMode = DispMode.Detail;
                this.Text = "水質結果名称マスタ詳細";

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
        /// 2014/07/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            if (this._suishitsuKekkaNmMstDT.Count > 0)
            {
                shishoNmComboBox.SelectedValue = this._suishitsuKekkaNmMstDT[0].SuishitsuKekkaShishoCd;
                suishitsuKekkaNmCdTextBox.Text = this._suishitsuKekkaNmMstDT[0].SuishitsuKekkaNmCd;
                suishitsuKekkaNmTextBox.Text = this._suishitsuKekkaNmMstDT[0].SuishitsuKekkaNm;
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
        /// 2014/07/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            shishoNmComboBox.Enabled = !(this._displayMode == DispMode.Add) ? false : true;
            // UPD 20140724 START ZynasSou
            //suishitsuKekkaNmCdTextBox.ReadOnly = (this._displayMode == DispMode.Add) ? false : true;
            suishitsuKekkaNmCdTextBox.ReadOnly = true;
            // UPD 20140724 END ZynasSou
            suishitsuKekkaNmTextBox.ReadOnly = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Confirm) ? true : false;



            //登録ボタン (4)
            entryButton.Visible = (this._displayMode == DispMode.Add) ? true : false;

            //変更ボタン (5)
            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            //削除ボタン (6)
            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            //再入力ボタン (7) 
            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            //確定ボタン (8) 
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
        /// 2014/07/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (this._displayMode)
            {
                case DispMode.Add:
                    Program.mForm.Text = "水質結果名称マスタ登録";
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "水質結果名称マスタ変更";
                    break;
                case DispMode.Detail:
                    Program.mForm.Text = "水質結果名称マスタ詳細";
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "水質結果名称マスタ入力確認";
                    break;
                default:
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
        /// 2014/07/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            //支所(1)
            if (shishoNmComboBox.SelectedIndex <= 0)
            {
                errMsg.AppendLine("必須項目：支所が選択されていません。");
            }

            // DEL 20140724 START ZynasSou
            ////水質結果名称コード(2)
            //if (string.IsNullOrEmpty(suishitsuKekkaNmCdTextBox.Text))
            //{
            //    errMsg.AppendLine("必須項目：水質結果名称コードが入力されていません。");
            //}
            //else if (suishitsuKekkaNmCdTextBox.TextLength != 3)
            //{
            //    errMsg.AppendLine("水質結果名称コードは3桁で入力して下さい。");
            //}
            // DEL 20140724 END ZynasSou

            //水質結果名称(3)
            if (string.IsNullOrEmpty(suishitsuKekkaNmTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：水質結果名称が入力されていません。");
            }
            else if (suishitsuKekkaNmTextBox.Text.Trim().Length > 28)
            {
                errMsg.AppendLine("水質結果名称は28文字以下で入力して下さい。");
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
        /// 2014/07/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsEditedControl()
        {
            //check edit default value mode Add
            if (string.IsNullOrEmpty(this._shishoCd) && string.IsNullOrEmpty(this._suishitsuKekkaCd))
            {
                if (shishoNmComboBox.SelectedIndex > 0
                    || !string.IsNullOrEmpty(suishitsuKekkaNmCdTextBox.Text)
                    || !string.IsNullOrEmpty(suishitsuKekkaNmTextBox.Text))
                {
                    return true;
                }
            }
            else
            {
                if (this._suishitsuKekkaNmMstDT.Count != 0)
                {
                    if (shishoNmComboBox.SelectedValue.ToString() != this._suishitsuKekkaNmMstDT[0].SuishitsuKekkaShishoCd.ToString()
                        || suishitsuKekkaNmCdTextBox.Text != this._suishitsuKekkaNmMstDT[0].SuishitsuKekkaNmCd
                        || suishitsuKekkaNmTextBox.Text != this._suishitsuKekkaNmMstDT[0].SuishitsuKekkaNm
                        )
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region CreateSuishitsuKekkaNmMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuKekkaNmMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable CreateSuishitsuKekkaNmMstInsert()
        {
            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable suishitsuKekkaNmMstDT = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable();
            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstRow newRow = suishitsuKekkaNmMstDT.NewSuishitsuKekkaNmMstRow();

            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string shokuinNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //支所(1)
            newRow.SuishitsuKekkaShishoCd = shishoNmComboBox.SelectedValue.ToString();

            //水質結果名称コード (2)
            // UPD 20140724 START ZynasSou
            //newRow.SuishitsuKekkaNmCd = suishitsuKekkaNmCdTextBox.Text;
            newRow.SuishitsuKekkaNmCd = Utility.Saiban.GetKeyRenban("SuishitsuKekkaNmMst", shishoNmComboBox.SelectedValue.ToString(), "", "").PadLeft(3, '0');
            // UPD 20140724 END ZynasSou

            //水質結果名称 (3)
            newRow.SuishitsuKekkaNm = suishitsuKekkaNmTextBox.Text;

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
            suishitsuKekkaNmMstDT.AddSuishitsuKekkaNmMstRow(newRow);

            //行の状態を設定
            newRow.AcceptChanges();

            newRow.SetAdded();

            return suishitsuKekkaNmMstDT;

        }
        #endregion

        #region CreateSuishitsuKekkaNmMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuKekkaNmMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable CreateSuishitsuKekkaNmMstUpdate(SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable suishitsuKekkaNmMstDT)
        {
            //支所(1)
            suishitsuKekkaNmMstDT[0].SuishitsuKekkaShishoCd = shishoNmComboBox.SelectedValue.ToString();

            //水質結果名称コード (2)
            suishitsuKekkaNmMstDT[0].SuishitsuKekkaNmCd = suishitsuKekkaNmCdTextBox.Text;

            //水質結果名称 (3)
            suishitsuKekkaNmMstDT[0].SuishitsuKekkaNm = suishitsuKekkaNmTextBox.Text;

            //更新者
            suishitsuKekkaNmMstDT[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //更新端末
            suishitsuKekkaNmMstDT[0].UpdateTarm = Dns.GetHostName();

            return suishitsuKekkaNmMstDT;

        }
        #endregion
        
        #endregion

    }
    #endregion
}
