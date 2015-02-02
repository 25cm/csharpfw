using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.KatashikiMstShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KatashikiMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KatashikiMstShosaiForm : FukjBaseForm
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
        /// katashikiMakerCd
        /// </summary>
        private string _katashikiMakerCd = string.Empty;

        /// <summary>
        /// katashikiCd
        /// </summary>
        private string _katashikiCd = string.Empty;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// Update mode
        /// </summary>
        private DispMode _updateMode;

        /// <summary>
        /// KatashikiMstDataTable
        /// </summary>
        private KatashikiMstDataSet.KatashikiMstDataTable _mstDT;

        /// <summary>
        /// KatashikiBurowaMstDataTable
        /// </summary>
        private KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable _katashikiBurowaMstDT;

        /// <summary>
        /// KatashikiBetsuTaniSochiListDataTable
        /// </summary>
        private KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiListDataTable _katashikiBetsuTaniSochiListDT;

        /// <summary>
        /// ShoriHoshikiMstDataTable
        /// </summary>
        private ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable _shoriHoshikiMstDT;

        /// <summary>
        /// Loaded form
        /// </summary>
        private bool isLoad = false;

        /// <summary>
        /// katashikiBurowaListDataGridView changed
        /// </summary>
        private bool katashikiBurowaListDgvchanged = false;

        /// <summary>
        /// taniSouchiListDataGridView changed
        /// </summary>
        private bool taniSouchiListDgvchanged = false;
        
        /// <summary>
        /// listTanisochiCd
        /// </summary>
        private List<string> listTanisochiCd = new List<string>();

        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KatashikiMstShosaiForm
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
        public KatashikiMstShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KatashikiMstShosaiForm
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="katashikiMakerCd"></param>
        /// <param name="katashikiCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KatashikiMstShosaiForm(string katashikiMakerCd, string katashikiCd)
        {
            InitializeComponent();

            this._katashikiMakerCd = katashikiMakerCd;
            this._katashikiCd = katashikiCd;
        }
        #endregion

        #region イベント

        #region KatashikiMstShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KatashikiMstShosaiForm_Load
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
        private void KatashikiMstShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //SetControlDomain();

                if (string.IsNullOrEmpty(_katashikiMakerCd) && string.IsNullOrEmpty(_katashikiCd))
                {
                    //  Clear GridView tab 2
                    katashikiBurowaListDataGridView.DataSource = null;

                    //  Clear GridView (27)

                    _dispMode = DispMode.Add;
                }
                else
                {
                    _dispMode = DispMode.Detail;
                }

                DoFormLoad();

                isLoad = true;
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

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？")
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                    alInput.KatashikiMakerCd = katashikiMakerCdTextBox.Text;
                    alInput.KatashikiCd = katashikiCdTextBox.Text;
                    IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                    if (string.IsNullOrEmpty(alOutput.ErrorMessage))
                    {
                        this.DialogResult = DialogResult.OK;
                        Program.mForm.MovePrev();
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrorMessage);
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

                //// Enable menu
                //Program.mForm.SetMenuEnabled(true);

                if (_dispMode != DispMode.Detail)
                {
                    if (!CheckEdit())
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？")
                                != System.Windows.Forms.DialogResult.Yes)
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

        #region KatashikiMstShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KatashikiMstShosaiForm_KeyDown
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
        private void KatashikiMstShosaiForm_KeyDown(object sender, KeyEventArgs e)
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

        #region katashikiMakerCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiMakerCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// 2014/11/04  DatNT       v1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiMakerCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2014/11/04 DatNT v1.05 DEL Start
                //if (!isLoad) { return; }

                //string makerCd = katashikiMakerCdTextBox.Text;

                //if (string.IsNullOrEmpty(makerCd))
                //{
                //    gyoshaNmComboBox.SelectedIndex = 0;
                //    return;
                //}

                //bool flg = false;

                //DataTable dataTable = (DataTable)(gyoshaNmComboBox.DataSource);

                //foreach (DataRow row in dataTable.Rows)
                //{
                //    if (makerCd == row["GyoshaCd"].ToString())
                //    {
                //        flg = true;
                //        break;
                //    }
                //}

                //if (flg)
                //{
                //    gyoshaNmComboBox.SelectedValue = makerCd;
                //}
                //else
                //{
                //    gyoshaNmComboBox.SelectedIndex = 0;
                //}
                // 2014/11/04 DatNT v1.05 DEL End

                // 2014/11/04 DatNT v1.05 ADD Start

                makerGyoshaNmTextBox.Clear();

                if (!string.IsNullOrEmpty(katashikiMakerCdTextBox.Text))
                {
                    katashikiMakerCdTextBox.Text = katashikiMakerCdTextBox.Text.PadLeft(4, '0');

                    Common.Common.SetGyoshaNmByCd(katashikiMakerCdTextBox.Text, katashikiMakerCdTextBox, makerGyoshaNmTextBox);

                    if (string.IsNullOrEmpty(katashikiMakerCdTextBox.Text))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "業者マスタに存在しません。");
                        return;
                    }
                }
                // 2014/11/04 DatNT v1.05 ADD End
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

        #region gyoshaNmComboBox_SelectedIndexChanged
        //// 2014/11/04 DatNT v1.05 DEL Start
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： gyoshaNmComboBox_SelectedIndexChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/07/07  DatNT　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void gyoshaNmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (gyoshaNmComboBox.SelectedIndex != 0 || gyoshaNmComboBox.SelectedIndex != -1)
        //        {
        //            katashikiMakerCdTextBox.Text = gyoshaNmComboBox.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            katashikiMakerCdTextBox.Text = string.Empty;
        //        }
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
        // 2014/11/04 DatNT v1.05 DEL End
        #endregion

        #region katashikiShorihoushikiCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiShorihoushikiCdTextBox_Leave
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
        private void katashikiShorihoushikiCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!isLoad) { return; }

                string cd = katashikiShorihoushikiCdTextBox.Text;

                if (string.IsNullOrEmpty(cd))
                {
                    shoriHoshikiNmComboBox.SelectedIndex = 0;
                    return;
                }

                bool flg = false;

                DataTable dataTable = (DataTable)(shoriHoshikiNmComboBox.DataSource);

                foreach (DataRow row in dataTable.Rows)
                {
                    if (cd == row["ShoriHoshikiCd"].ToString())
                    {
                        flg = true;
                        break;
                    }
                }

                if (flg)
                {
                    shoriHoshikiNmComboBox.SelectedValue = cd;
                }
                else
                {
                    shoriHoshikiNmComboBox.SelectedIndex = 0;
                    katashikiShorihoushikiCdTextBox.Clear();
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

        #region shoriHoshikiNmComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shoriHoshikiNmComboBox_SelectedIndexChanged
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
        private void shoriHoshikiNmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shoriHoshikiNmComboBox.SelectedIndex != 0 || shoriHoshikiNmComboBox.SelectedIndex != -1)
                {
                    katashikiShorihoushikiCdTextBox.Text = shoriHoshikiNmComboBox.SelectedValue.ToString();
                }
                else
                {
                    katashikiShorihoushikiCdTextBox.Text = string.Empty;
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
        
        #region selectInsertButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： selectInsertButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  DatNT　　    新規作成
        /// 2015/01/29  DatNT       v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void selectInsertButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (taniSouchiGroupList.SelectedIndex == -1)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "追加する単位装置グループを選択して下さい。");
                    return;
                }

                // 2015/01/29 DatNT v1.06 DEL Start
                //foreach (DataGridViewRow row in taniSouchiListDataGridView.Rows)
                //{
                //    if (row.Cells["TaniSouchiGroupCdCol"].Value.ToString() == taniSouchiGroupList.SelectedValue.ToString())
                //    {
                //        MessageForm.Show2(MessageForm.DispModeType.Error, "既に追加されている単位装置グループです。");
                //        return;
                //    }
                //}
                // 2015/01/29 DatNT v1.06 DEL End

                taniSouchiListDataGridView.Rows.Add(taniSouchiGroupList.SelectedValue.ToString(),
                                                    taniSouchiGroupList.GetItemText(taniSouchiGroupList.SelectedItem),
                                                    string.Empty);

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

        #region selectDeleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： selectDeleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void selectDeleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 連携対象の単位装置一覧
                // 選択行数が0件の場合
                if (taniSouchiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "削除する単位装置を選択して下さい。");
                    return;
                }

                // Remove current row
                taniSouchiListDataGridView.Rows.Remove(taniSouchiListDataGridView.CurrentRow);

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

        #region katashikiBurowaListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiBurowaListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiBurowaListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string colName = katashikiBurowaListDataGridView.Columns[katashikiBurowaListDataGridView.CurrentCell.ColumnIndex].Name;

                if (colName == "BurowaNinsouCol"
                    || colName == "BurowaRenbanCol"
                    || colName == "BurowaKiteiFuryoCol")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(ControlKeyPress);
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

        #region katashikiBurowaListDataGridView_DefaultValuesNeeded
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiBurowaListDataGridView_DefaultValuesNeeded
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiBurowaListDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_dispMode == DispMode.Edit)
                {
                    e.Row.Cells["BurowaKatashikiMakerCdCol"].Value = katashikiMakerCdTextBox.Text;
                    e.Row.Cells["BurowaKatashikiCdCol"].Value = katashikiCdTextBox.Text;
                    e.Row.Cells["BurowaNinsouCol"].Value = string.Empty;
                    e.Row.Cells["BurowaRenbanCol"].Value = string.Empty;
                    e.Row.Cells["BurowaKiteiBurowaNmCol"].Value = string.Empty;
                    e.Row.Cells["BurowaKiteiFuryoCol"].Value = string.Empty;
                    e.Row.Cells["InsertDtCol"].Value = today;
                    e.Row.Cells["InsertUserCol"].Value = loginUser;
                    e.Row.Cells["InsertTarmCol"].Value = terminal;
                    e.Row.Cells["UpdateDtCol"].Value = today;
                    e.Row.Cells["UpdateUserCol"].Value = loginUser;
                    e.Row.Cells["UpdateTarmCol"].Value = terminal;
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

        #region katashikiBurowaListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiBurowaListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiBurowaListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        #endregion

        #region katashikiBurowaListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiBurowaListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiBurowaListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (isLoad)
                {
                    katashikiBurowaListDgvchanged = true;
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

        #region taniSouchiListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： taniSouchiListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void taniSouchiListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (isLoad)
                {
                    taniSouchiListDgvchanged = true;
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

        #region katashikiShorihoushikiKbnRadioButton1_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiShorihoushikiKbnRadioButton1_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiShorihoushikiKbnRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (katashikiShorihoushikiKbnRadioButton1.Checked)
                {
                    // shoriHoshikiNmComboBox
                    ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable shoriHoshikiNmComboBoxSource = new ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

                    foreach (ShoriHoshikiMstDataSet.ShoriHoshikiMstRow row in _shoriHoshikiMstDT.Select("ShoriHoshikiKbn = '1'"))
                    {
                        shoriHoshikiNmComboBoxSource.ImportRow(row);
                    }

                    katashikiShorihoushikiCdTextBox.Clear();
                    shoriHoshikiNmComboBox.SelectedIndex = 0;

                    Utility.Utility.SetComboBoxList(shoriHoshikiNmComboBox, shoriHoshikiNmComboBoxSource, "ShoriHoshikiNm", "ShoriHoshikiCd", true);
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

        #region katashikiShorihoushikiKbnRadioButton2_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiShorihoushikiKbnRadioButton2_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiShorihoushikiKbnRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (katashikiShorihoushikiKbnRadioButton2.Checked)
                {
                    // shoriHoshikiNmComboBox
                    ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable shoriHoshikiNmComboBoxSource = new ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

                    foreach (ShoriHoshikiMstDataSet.ShoriHoshikiMstRow row in _shoriHoshikiMstDT.Select("ShoriHoshikiKbn = '2'"))
                    {
                        shoriHoshikiNmComboBoxSource.ImportRow(row);
                    }

                    katashikiShorihoushikiCdTextBox.Clear();
                    shoriHoshikiNmComboBox.SelectedIndex = 0;

                    Utility.Utility.SetComboBoxList(shoriHoshikiNmComboBox, shoriHoshikiNmComboBoxSource, "ShoriHoshikiNm", "ShoriHoshikiCd", true);
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

        #region makeGyoshaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： makeGyoshaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04  DatNT　　  v1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void makeGyoshaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    katashikiMakerCdTextBox.Text = frm._selectedRow.GyoshaCd;
                    makerGyoshaNmTextBox.Text = frm._selectedRow.GyoshaNm;
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
            alInput.KatashikiMakerCd    = _katashikiMakerCd;
            alInput.KatashikiCd         = _katashikiCd;
            alInput.SeizoGyoShaKbn      = "1";
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);

            _shoriHoshikiMstDT = alOutput.ShoriHoshikiMstDT;

            // 20141120 habu save load data here(should keep if row count is 0)
            _katashikiBurowaMstDT = alOutput.KatashikiBurowaMstDT;
            _katashikiBetsuTaniSochiListDT = alOutput.KatashikiBetsuTaniSochiListDT;

            // Display data in tab 1
            DisplayDataTab01(alOutput);

            // Display data in tab 2
            DisplayDataTab02(alOutput);

            // Display data in tab 3
            DisplayDataTab03(alOutput);

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
        /// 2014/11/04  DatNT       v1.05
        /// 2015/01/28  DatNT       v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(KatashikiMstDataSet.KatashikiMstRow row)
        {
            // メーカー業者コード
            katashikiMakerCdTextBox.Text = row.KatashikiMakerCd;

            // 型式コード
            katashikiCdTextBox.Text = row.KatashikiCd;

            // メーカー業者名称
            // 2014/11/04 DatNT v1.05 MOD Start
            //gyoshaNmComboBox.SelectedValue = row.KatashikiMakerCd;
            Common.Common.SetGyoshaNmByCd(row.KatashikiMakerCd, katashikiMakerCdTextBox, makerGyoshaNmTextBox);
            // 2014/11/04 DatNT v1.05 MOD End

            // 型式名称
            katashikiNmTextBox.Text = row.KatashikiNm;

            // 全浄連登録番号
            zenjorenTourokuNoTextBox.Text = row.ZenjorenTourokuNo;

            // 全浄連登録日
            zenjorenTourokuBiTextBox.Text = row.ZenjorenTourokuBi;

            // 特徴
            tokuChoTextBox.Text = row.TokuCho;

            // 性能評価型区分
            if (row.SeinohyokakataKbn == "0")
            {
                seinohyokakataKbnCheckBox.Checked = false;
            }
            else if (row.SeinohyokakataKbn == "1")
            {
                seinohyokakataKbnCheckBox.Checked = true;
            }

            // コンパクト型区分
            if (row.KonpakutokataKbn == "0")
            {
                konpakutokataKbnCheckBox.Checked = false;
            }
            else if (row.KonpakutokataKbn == "1")
            {
                konpakutokataKbnCheckBox.Checked = true;
            }

            // 2014/11/04 DatNT v1.05 DEL Start
            //// 構造例示型区分
            //if (row.KouzoreijikataKbn == "0")
            //{
            //    kouzoreijikataKbnCheckBox.Checked = false;
            //}
            //else if (row.KouzoreijikataKbn == "1")
            //{
            //    kouzoreijikataKbnCheckBox.Checked = true;
            //}
            // 2014/11/04 DatNT v1.05 DEL End

            // 処理方式区分
            if (row.KatashikiShorihoushikiKbn == "1")
            {
                katashikiShorihoushikiKbnRadioButton1.Checked = true;
            }
            else if (row.KatashikiShorihoushikiKbn == "2")
            {
                katashikiShorihoushikiKbnRadioButton2.Checked = true;
            }

            // 2014/11/04 DatNT v1.05 ADD Start
            // ＢＯＤ高度処理型区分
            if (row.BODKodoshorikataKbn == "0")
            {
                bodKodokataKbnCheckBox.Checked = false;
            }
            else if (row.BODKodoshorikataKbn == "1")
            {
                bodKodokataKbnCheckBox.Checked = true;
            }

            // 窒素除去型区分
            if (row.ChissojokyokataKbn == "0")
            {
                chissoJokyokataKbnCheckBox.Checked = false;
            }
            else if (row.ChissojokyokataKbn == "1")
            {
                chissoJokyokataKbnCheckBox.Checked = true;
            }

            // リン除去型区分
            if (row.RinjokyokataKbn == "0")
            {
                rinJokyokataKbnCheckBox.Checked = false;
            }
            else if (row.RinjokyokataKbn == "1")
            {
                rinJokyokataKbnCheckBox.Checked = true;
            }

            //// 点検回数月毎
            ////tenkenKaisuTsukiTextBox.Text = row.TenkenKaisuTsuki.ToString();
            //tenkenKaisuTsukiTextBox.Text = row.TenkenKaisuKbn;

            //// 点検回数週毎
            ////tenkenKaisuShuTextBox.Text = row.TenkenKaisuShu.ToString();
            //tenkenKaisuShuTextBox.Text = row.SeisoKaisuKbn.ToString();
            // 2014/11/04 DatNT v1.05 ADD End

            // 2015/01/28 DatNT v1.06 ADD Start
            // 点検回数区分
            if (!string.IsNullOrEmpty(row.TenkenKaisuKbn))
            {
                tenkenKaisuKbnComboBox.SelectedValue = row.TenkenKaisuKbn;
            }
            // 清掃回数区分
            if (!string.IsNullOrEmpty(row.SeisoKaisuKbn))
            {
                seisoKaisuKbnComboBox.SelectedValue = row.SeisoKaisuKbn;
            }
            // 2015/01/28 DatNT v1.06 ADD End

            // 処理方式コード
            katashikiShorihoushikiCdTextBox.Text = row.KatashikiShorihoushikiCd;

            // 処理方式名称
            // 2014/11/04 DatNT v1.05 MOD Start
            if (!string.IsNullOrEmpty(row.KatashikiShorihoushikiCd))
            {
                shoriHoshikiNmComboBox.SelectedValue = row.KatashikiShorihoushikiCd;
            }
            // 2014/11/04 DatNT v1.05 MOD End
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
        /// 2014/11/04  DatNT       v1.05
        /// 2015/01/28  DatNT       v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.Add:

                    // メーカー業者コード 4
                    katashikiMakerCdTextBox.ReadOnly = false;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// メーカー業者名称 5
                    //gyoshaNmComboBox.Enabled = true;
                    makeGyoshaSearchButton.Visible = true;
                    // 2014/11/04 DatNT v1.05 DEL End

                    // 型式コード 6
                    //katashikiCdTextBox.ReadOnly = false;
                    katashikiCdTextBox.ReadOnly = true;
                    // UPD 20140731 END ZynasSou

                    // 型式名称 7
                    katashikiNmTextBox.ReadOnly = false;

                    // 全浄連登録番号 8
                    zenjorenTourokuNoTextBox.ReadOnly = false;

                    // 全浄連登録日 9
                    zenjorenTourokuBiTextBox.ReadOnly = false;

                    // 特徴 10
                    tokuChoTextBox.ReadOnly = false;

                    // 性能評価型区分 11
                    seinohyokakataKbnCheckBox.Enabled = true;

                    // コンパクト型区分 12
                    konpakutokataKbnCheckBox.Enabled = true;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// 構造例示型区分 13
                    //kouzoreijikataKbnCheckBox.Enabled = true;
                    // ＢＯＤ高度処理型区分
                    bodKodokataKbnCheckBox.Enabled = true;
                    // 窒素除去型区分
                    chissoJokyokataKbnCheckBox.Enabled = true;
                    // リン除去型区分
                    rinJokyokataKbnCheckBox.Enabled = true;
                    //// 点検回数月毎
                    //tenkenKaisuTsukiTextBox.Enabled = true;
                    //// 点検回数週毎
                    //tenkenKaisuShuTextBox.Enabled = true;
                    // 2014/11/04 DatNT v1.05 MOD End

                    // 2015/01/28 DatNT v1.06 ADD Start
                    // 点検回数区分
                    tenkenKaisuKbnComboBox.Enabled = true;
                    // 清掃回数区分
                    seisoKaisuKbnComboBox.Enabled = true;
                    // 2015/01/28 DatNT v1.06 ADD End

                    // 処理方式区分 14 15 16
                    katashikiShorihoushikiKbnGroupBox.Enabled = true;

                    // 処理方式コード 17
                    katashikiShorihoushikiCdTextBox.ReadOnly = false;

                    // 処理方式名称 18
                    shoriHoshikiNmComboBox.Enabled = true;

                    // 人槽 20
                    katashikiBurowaListDataGridView.Columns["BurowaNinsouCol"].ReadOnly = false;

                    // 連番 21
                    katashikiBurowaListDataGridView.Columns["BurowaRenbanCol"].ReadOnly = false;

                    // 規定ブロブ名称 22
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiBurowaNmCol"].ReadOnly = false;

                    // 規定風量 23
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiFuryoCol"].ReadOnly = false;

                    // ADD 20140731 START ZynasSou
                    // 単位装置名
                    taniSouchiListDataGridView.Columns["TaniSouchiNmCol"].ReadOnly = false;
                    // ADD 20140731 START ZynasSou

                    // 選択追加ボタン 30
                    selectInsertButton.Visible = true;

                    // 選択削除ボタン 31
                    selectDeleteButton.Visible = true;

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

                    this.Text = "型式マスタ登録";
                    Program.mForm.Text = "型式マスタ登録";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Edit:

                    // メーカー業者コード 4
                    katashikiMakerCdTextBox.ReadOnly = true;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// メーカー業者名称 5
                    //gyoshaNmComboBox.Enabled = false;
                    makeGyoshaSearchButton.Visible = true;
                    // 2014/11/04 DatNT v1.05 MOD End

                    // 型式コード 6
                    katashikiCdTextBox.ReadOnly = true;

                    // 型式名称 7
                    katashikiNmTextBox.ReadOnly = false;

                    // 全浄連登録番号 8
                    zenjorenTourokuNoTextBox.ReadOnly = false;

                    // 全浄連登録日 9
                    zenjorenTourokuBiTextBox.ReadOnly = false;

                    // 特徴 10
                    tokuChoTextBox.ReadOnly = false;

                    // 性能評価型区分 11
                    seinohyokakataKbnCheckBox.Enabled = true;

                    // コンパクト型区分 12
                    konpakutokataKbnCheckBox.Enabled = true;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// 構造例示型区分 13
                    //kouzoreijikataKbnCheckBox.Enabled = true;
                    // ＢＯＤ高度処理型区分
                    bodKodokataKbnCheckBox.Enabled = true;
                    // 窒素除去型区分
                    chissoJokyokataKbnCheckBox.Enabled = true;
                    // リン除去型区分
                    rinJokyokataKbnCheckBox.Enabled = true;
                    //// 点検回数月毎
                    //tenkenKaisuTsukiTextBox.Enabled = true;
                    //// 点検回数週毎
                    //tenkenKaisuShuTextBox.Enabled = true;
                    // 2014/11/04 DatNT v1.05 MOD End

                    // 2015/01/28 DatNT v1.06 ADD Start
                    // 点検回数区分
                    tenkenKaisuKbnComboBox.Enabled = true;
                    // 清掃回数区分
                    seisoKaisuKbnComboBox.Enabled = true;
                    // 2015/01/28 DatNT v1.06 ADD End

                    // 処理方式区分 14 15 16
                    katashikiShorihoushikiKbnGroupBox.Enabled = true;

                    // 処理方式コード 17
                    katashikiShorihoushikiCdTextBox.ReadOnly = false;

                    // 処理方式名称 18
                    shoriHoshikiNmComboBox.Enabled = true;

                    // 人槽 20
                    katashikiBurowaListDataGridView.Columns["BurowaNinsouCol"].ReadOnly = false;

                    // 連番 21
                    katashikiBurowaListDataGridView.Columns["BurowaRenbanCol"].ReadOnly = false;

                    // 規定ブロブ名称 22
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiBurowaNmCol"].ReadOnly = false;

                    // 規定風量 23
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiFuryoCol"].ReadOnly = false;

                    // ADD 20140731 START ZynasSou
                    // 単位装置名
                    taniSouchiListDataGridView.Columns["TaniSouchiNmCol"].ReadOnly = false;
                    // ADD 20140731 START ZynasSou

                    // 選択追加ボタン 30
                    selectInsertButton.Visible = true;

                    // 選択削除ボタン 31
                    selectDeleteButton.Visible = true;

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

                    this.Text = "型式マスタ変更";
                    Program.mForm.Text = "型式マスタ変更";

                    Program.mForm.SetMenuEnabled(false);

                    break;

                case DispMode.Detail:

                    // メーカー業者コード 4
                    katashikiMakerCdTextBox.ReadOnly = true;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// メーカー業者名称 5
                    //gyoshaNmComboBox.Enabled = false;
                    makeGyoshaSearchButton.Visible = false;
                    // 2014/11/04 DatNT v1.05 MOD End

                    // 型式コード 6
                    katashikiCdTextBox.ReadOnly = true;

                    // 型式名称 7
                    katashikiNmTextBox.ReadOnly = true;

                    // 全浄連登録番号 8
                    zenjorenTourokuNoTextBox.ReadOnly = true;

                    // 全浄連登録日 9
                    zenjorenTourokuBiTextBox.ReadOnly = true;

                    // 特徴 10
                    tokuChoTextBox.ReadOnly = true;

                    // 性能評価型区分 11
                    seinohyokakataKbnCheckBox.Enabled = false;

                    // コンパクト型区分 12
                    konpakutokataKbnCheckBox.Enabled = false;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// 構造例示型区分 13
                    //kouzoreijikataKbnCheckBox.Enabled = false;
                    // ＢＯＤ高度処理型区分
                    bodKodokataKbnCheckBox.Enabled = false;
                    // 窒素除去型区分
                    chissoJokyokataKbnCheckBox.Enabled = false;
                    // リン除去型区分
                    rinJokyokataKbnCheckBox.Enabled = false;
                    //// 点検回数月毎
                    //tenkenKaisuTsukiTextBox.Enabled = false;
                    //// 点検回数週毎
                    //tenkenKaisuShuTextBox.Enabled = false;
                    // 2014/11/04 DatNT v1.05 MOD End

                    // 2015/01/28 DatNT v1.06 ADD Start
                    // 点検回数区分
                    tenkenKaisuKbnComboBox.Enabled = false;
                    // 清掃回数区分
                    seisoKaisuKbnComboBox.Enabled = false;
                    // 2015/01/28 DatNT v1.06 ADD End

                    // 処理方式区分 14 15 16
                    katashikiShorihoushikiKbnGroupBox.Enabled = false;

                    // 処理方式コード 17
                    katashikiShorihoushikiCdTextBox.ReadOnly = true;

                    // 処理方式名称 18
                    shoriHoshikiNmComboBox.Enabled = false;

                    // 人槽 20
                    katashikiBurowaListDataGridView.Columns["BurowaNinsouCol"].ReadOnly = true;

                    // 連番 21
                    katashikiBurowaListDataGridView.Columns["BurowaRenbanCol"].ReadOnly = true;

                    // 規定ブロブ名称 22
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiBurowaNmCol"].ReadOnly = true;

                    // 規定風量 23
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiFuryoCol"].ReadOnly = true;

                    // ADD 20140731 START ZynasSou
                    // 単位装置名
                    taniSouchiListDataGridView.Columns["TaniSouchiNmCol"].ReadOnly = true;
                    // ADD 20140731 START ZynasSou

                    // 選択追加ボタン 30
                    selectInsertButton.Visible = false;

                    // 選択削除ボタン 31
                    selectDeleteButton.Visible = false;

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

                    this.Text = "型式マスタ詳細";
                    Program.mForm.Text = "型式マスタ詳細";

                    Program.mForm.SetMenuEnabled(true);

                    break;

                case DispMode.Confirm:

                    // メーカー業者コード 4
                    katashikiMakerCdTextBox.ReadOnly = true;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// メーカー業者名称 5
                    //gyoshaNmComboBox.Enabled = false;
                    makeGyoshaSearchButton.Visible = false;
                    // 2014/11/04 DatNT v1.05 MOD End

                    // 型式コード 6
                    katashikiCdTextBox.ReadOnly = true;

                    // 型式名称 7
                    katashikiNmTextBox.ReadOnly = true;

                    // 全浄連登録番号 8
                    zenjorenTourokuNoTextBox.ReadOnly = true;

                    // 全浄連登録日 9
                    zenjorenTourokuBiTextBox.ReadOnly = true;

                    // 特徴 10
                    tokuChoTextBox.ReadOnly = true;

                    // 性能評価型区分 11
                    seinohyokakataKbnCheckBox.Enabled = false;

                    // コンパクト型区分 12
                    konpakutokataKbnCheckBox.Enabled = false;

                    // 2014/11/04 DatNT v1.05 MOD Start
                    //// 構造例示型区分 13
                    //kouzoreijikataKbnCheckBox.Enabled = false;
                    // ＢＯＤ高度処理型区分
                    bodKodokataKbnCheckBox.Enabled = false;
                    // 窒素除去型区分
                    chissoJokyokataKbnCheckBox.Enabled = false;
                    // リン除去型区分
                    rinJokyokataKbnCheckBox.Enabled = false;
                    //// 点検回数月毎
                    //tenkenKaisuTsukiTextBox.Enabled = false;
                    //// 点検回数週毎
                    //tenkenKaisuShuTextBox.Enabled = false;
                    // 2014/11/04 DatNT v1.05 MOD End

                    // 2015/01/28 DatNT v1.06 ADD Start
                    // 点検回数区分
                    tenkenKaisuKbnComboBox.Enabled = false;
                    // 清掃回数区分
                    seisoKaisuKbnComboBox.Enabled = false;
                    // 2015/01/28 DatNT v1.06 ADD End

                    // 処理方式区分 14 15 16
                    katashikiShorihoushikiKbnGroupBox.Enabled = false;

                    // 処理方式コード 17
                    katashikiShorihoushikiCdTextBox.ReadOnly = true;

                    // 処理方式名称 18
                    shoriHoshikiNmComboBox.Enabled = false;

                    // 人槽 20
                    katashikiBurowaListDataGridView.Columns["BurowaNinsouCol"].ReadOnly = true;

                    // 連番 21
                    katashikiBurowaListDataGridView.Columns["BurowaRenbanCol"].ReadOnly = true;

                    // 規定ブロブ名称 22
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiBurowaNmCol"].ReadOnly = true;

                    // 規定風量 23
                    katashikiBurowaListDataGridView.Columns["BurowaKiteiFuryoCol"].ReadOnly = true;

                    // ADD 20140731 START ZynasSou
                    // 単位装置名
                    taniSouchiListDataGridView.Columns["TaniSouchiNmCol"].ReadOnly = true;
                    // ADD 20140731 START ZynasSou

                    // 選択追加ボタン 30
                    selectInsertButton.Visible = false;

                    // 選択削除ボタン 31
                    selectDeleteButton.Visible = false;

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

                    this.Text = "型式マスタ入力確認";
                    Program.mForm.Text = "型式マスタ入力確認";

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
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            katashikiMakerCdTextBox_Leave(null, null);
            katashikiShorihoushikiCdTextBox_Leave(null, null);

            StringBuilder errMess = new StringBuilder();

            // メーカー業者コード 4
            if (string.IsNullOrEmpty(katashikiMakerCdTextBox.Text))
            {
                errMess.Append("必須項目：メーカー業者コードが入力されていません。\r\n");
            }
            else
            {
                if (katashikiMakerCdTextBox.Text.Length != 4)
                {
                    errMess.Append("メーカー業者コードは4桁で入力して下さい。\r\n");
                }
            }

            // 2014/11/04 DatNT v1.05 DEL Start
            //// メーカー業者名称 5
            //if (gyoshaNmComboBox.SelectedIndex == -1 || gyoshaNmComboBox.SelectedIndex == 0)
            //{
            //    errMess.Append("必須項目：メーカー業者名称が選択されていません。\r\n");
            //}
            // 2014/11/04 DatNT v1.05 DEL End

            // 型式名称 7
            if (string.IsNullOrEmpty(katashikiNmTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：型式名称が入力されていません。\r\n");
            }
            else
            {
                if (katashikiNmTextBox.Text.Trim().Length > 20)
                {
                    errMess.Append("型式名称は20文字以下で入力して下さい。\r\n");
                }
            }

            // 全浄連登録番号 8
            if (string.IsNullOrEmpty(zenjorenTourokuNoTextBox.Text))
            {
                //errMess.Append("必須項目：全浄連登録番号が入力されていません。\r\n");
            }
            else
            {
                if (zenjorenTourokuNoTextBox.Text.Length != 7)
                {
                    errMess.Append("全浄連登録番号は7桁で入力して下さい。\r\n");
                }
            }

            // 全浄連登録日 9
            if (string.IsNullOrEmpty(zenjorenTourokuBiTextBox.Text))
            {
                //errMess.Append("必須項目：全浄連登録日が入力されていません。\r\n");
            }
            else
            {
                if (zenjorenTourokuBiTextBox.Text.Length != 8)
                {
                    errMess.Append("全浄連登録日は8桁で入力して下さい。\r\n");
                }
            }

            // 特徴 10
            if (string.IsNullOrEmpty(tokuChoTextBox.Text.Trim()))
            {
                //errMess.Append("必須項目：特徴が入力されていません。\r\n");
            }
            else
            {
                if (tokuChoTextBox.Text.Trim().Length > 40)
                {
                    errMess.Append("特徴は40文字以下で入力して下さい。\r\n");
                }
            }

            // 2014/11/04 DatNT v1.05 DEL Start
            //// 処理方式コード 17
            //if (string.IsNullOrEmpty(katashikiShorihoushikiCdTextBox.Text))
            //{
            //    errMess.Append("必須項目：処理方式コードが入力されていません。\r\n");
            //}
            //else
            //{
            //    if (katashikiShorihoushikiCdTextBox.Text.Length != 3)
            //    {
            //        errMess.Append("処理方式コードは3桁で入力して下さい。\r\n");
            //    }
            //}

            //// 処理方式名 18
            //if (shoriHoshikiNmComboBox.SelectedIndex == -1 || shoriHoshikiNmComboBox.SelectedIndex == 0)
            //{
            //    errMess.Append("必須項目：処理方式名が選択されていません。\r\n");
            //}
            // 2014/11/04 DatNT v1.05 DEL End

            bool emptyNinsou = false;
            string emptyNinsouRow = string.Empty;

            bool lengthNinsou = false;
            string lengthNinsouRow = string.Empty;

            bool emptyRenban = false;
            string emptyRenbanRow = string.Empty;

            bool lengthRenban = false;
            string lengthRenbanRow = string.Empty;

            bool emptyNm = false;
            string emptyNmRow = string.Empty;

            bool lengthNm = false;
            string lengthNmRow = string.Empty;

            bool emptyFuryo = false;
            string emptyFuryoRow = string.Empty;

            bool lengthFuryo = false;
            string lengthFuryoRow = string.Empty;

            List<string> lstRow = new List<string>();
            string duplicateRow = string.Empty;

            for (int i = 0; i < katashikiBurowaListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = katashikiBurowaListDataGridView.Rows[i];

                if ((row.Cells["BurowaNinsouCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaNinsouCol"].Value.ToString()))
                    && (row.Cells["BurowaRenbanCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaRenbanCol"].Value.ToString()))
                    && (row.Cells["BurowaKiteiBurowaNmCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaKiteiBurowaNmCol"].Value.ToString()))
                    && (row.Cells["BurowaKiteiFuryoCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaKiteiFuryoCol"].Value.ToString()))
                    )
                {
                    // Row empty
                    // don't check
                }
                else
                {
                    // 人槽
                    if (row.Cells["BurowaNinsouCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaNinsouCol"].Value.ToString()))
                    {
                        emptyNinsouRow += (i + 1).ToString() + ",";
                        emptyNinsou = true;
                    }
                    else
                    {
                        if (row.Cells["BurowaNinsouCol"].Value.ToString().Length != 2)
                        {
                            lengthNinsouRow += (i + 1).ToString() + ",";
                            lengthNinsou = true;
                        }
                    }

                    // 連番
                    if (row.Cells["BurowaRenbanCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaRenbanCol"].Value.ToString()))
                    {
                        emptyRenbanRow += (i + 1).ToString() + ",";
                        emptyRenban = true;
                    }
                    else
                    {
                        if (row.Cells["BurowaRenbanCol"].Value.ToString().Length != 2)
                        {
                            lengthRenbanRow += (i + 1).ToString() + ",";
                            lengthRenban = true;
                        }
                    }

                    // 規定ブロワ名称
                    if (row.Cells["BurowaKiteiBurowaNmCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaKiteiBurowaNmCol"].Value.ToString()))
                    {
                        emptyNmRow += (i + 1).ToString() + ",";
                        emptyNm = true;
                    }
                    else
                    {
                        if (row.Cells["BurowaKiteiBurowaNmCol"].Value.ToString().Length > 16)
                        {
                            lengthNmRow += (i + 1).ToString() + ",";
                            lengthNm = true;
                        }
                    }

                    // 規定風量
                    if (row.Cells["BurowaKiteiFuryoCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaKiteiFuryoCol"].Value.ToString()))
                    {
                        emptyFuryoRow += (i + 1).ToString() + ",";
                        emptyFuryo = true;
                    }
                    else
                    {
                        // UPD 20140731 START ZynasSou
                        //if (row.Cells["BurowaKiteiFuryoCol"].Value.ToString().Length != 12)
                        if (row.Cells["BurowaKiteiFuryoCol"].Value.ToString().Length > 12)
                        // UPD 20140731 END ZynasSou
                        {
                            lengthFuryoRow += (i + 1).ToString() + ",";
                            lengthFuryo = true;
                        }
                    }
                }
            }

            if (emptyNinsou)
            {
                //errMess.Append("行" + emptyNinsouRow.Remove(emptyNinsouRow.Length - 1) + ": 必須項目：人槽が入力されていません。\r\n");
            }

            if (lengthNinsou)
            {
                errMess.Append("行" + lengthNinsouRow.Remove(lengthNinsouRow.Length - 1) + ": 人槽は2桁で入力して下さい。\r\n");
            }

            if (emptyRenban)
            {
                //errMess.Append("行" + emptyRenbanRow.Remove(emptyRenbanRow.Length - 1) + ": 必須項目：連番が入力されていません。\r\n");
            }

            if (lengthRenban)
            {
                errMess.Append("行" + lengthRenbanRow.Remove(lengthRenbanRow.Length - 1) + ": 連番は2桁で入力して下さい。\r\n");
            }

            if (emptyNm)
            {
                //errMess.Append("行" + emptyNmRow.Remove(emptyNmRow.Length - 1) + ": 必須項目：規定ブロワ名称が入力されていません。\r\n");
            }

            if (lengthNm)
            {
                errMess.Append("行" + lengthNmRow.Remove(lengthNmRow.Length - 1) + ": 規定ブロワ名称は16文字以下で入力して下さい。\r\n");
            }

            if (emptyFuryo)
            {
                //errMess.Append("行" + emptyFuryoRow.Remove(emptyFuryoRow.Length - 1) + ": 必須項目：規定風量が入力されていません。\r\n");
            }

            if (lengthFuryo)
            {
                errMess.Append("行" + lengthFuryoRow.Remove(lengthFuryoRow.Length - 1) + ": 規定風量は12桁で入力して下さい。\r\n");
            }

            if (!string.IsNullOrEmpty(duplicateRow))
            {
                errMess.Append("行" + duplicateRow.Remove(duplicateRow.Length - 1) + ": 人槽＆連番が重複しています。\r\n");
            }

            //if (katashikiBurowaListDataGridView.RowCount == 1)
            //{
            //    errMess.Append("必須項目：人槽が入力されていません。\r\n");
            //    errMess.Append("必須項目：連番が入力されていません。\r\n");
            //    errMess.Append("必須項目：規定ブロワ名称が入力されていません。\r\n");
            //    errMess.Append("必須項目：規定風量が入力されていません。\r\n");
            //}

            // Relation check
            List<string> listKey = new List<string>();

            listKey = GetListDuplicate();

            if (listKey.Count > 0)
            {
                errMess.Append("人槽＆連番が重複しています。\r\n");
                ChangeBackground(listKey);
            }

            // Tab 3
            string emptyTaniSouchiNm = string.Empty;

            if (taniSouchiListDataGridView.RowCount > 0)
            {
                for (int i = 0; i < taniSouchiListDataGridView.RowCount; i++)
                {
                    DataGridViewRow row = taniSouchiListDataGridView.Rows[i];

                    if (row.Cells["TaniSouchiNmCol"].Value == null || string.IsNullOrEmpty(row.Cells["TaniSouchiNmCol"].Value.ToString().Trim()))
                    {
                        emptyTaniSouchiNm += (i + 1).ToString() + ",";
                    }
                }
            }

            if (!string.IsNullOrEmpty(emptyTaniSouchiNm))
            {
                //errMess.Append("行" + emptyTaniSouchiNm.Remove(emptyTaniSouchiNm.Length - 1) + ": 必須項目：単位装置名が入力されていません。\r\n");
            }

            
            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region DispColumnKatashikiBurowaListdgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispColumnKatashikiBurowaListdgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DispColumnKatashikiBurowaListdgv()
        {
            foreach (DataGridViewColumn col in katashikiBurowaListDataGridView.Columns)
            {
                if (col.Name == "BurowaNinsouCol"
                    || col.Name == "BurowaRenbanCol"
                    || col.Name == "BurowaKiteiBurowaNmCol"
                    || col.Name == "BurowaKiteiFuryoCol")
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
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
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            // KatashikiMst
            KatashikiMstDataSet.KatashikiMstDataTable mstDT = new KatashikiMstDataSet.KatashikiMstDataTable();

            // KatashikiBurowaMst
            KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable buroDT = new KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable();

            // KatashikiBetsuTaniSochiMst
            KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable sochiDT = new KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable();

            // current time
            DateTime now = Common.Common.GetCurrentTimestamp();

            if (_updateMode == DispMode.Add)
            {
                mstDT = CreateMstDTInsert(now);

                buroDT = CreateBuroDTInsert(now);

                sochiDT = CreateSochiDTInsert(now);
            }
            else
            {
                mstDT = CreateMstDTUpdate(_mstDT, now);

                buroDT = CreateBuroDTUpdate(now);

                sochiDT = CreateSochiDTInsert(now);
            }

            IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();
            alInput.DispMode = _updateMode;
            alInput.KatashikiMstDT = mstDT;
            alInput.KatashikiBurowaMstDT = buroDT;
            alInput.KatashikiBetsuTaniSochiMstDT = sochiDT;
            IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

            if (!string.IsNullOrEmpty(alOutput.ErrorMessage))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrorMessage);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();
            }
        }
        #endregion

        #region CreateMstDTInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateMstDTInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// 2014/11/04  DatNT       v1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KatashikiMstDataSet.KatashikiMstDataTable CreateMstDTInsert(DateTime now)
        {
            KatashikiMstDataSet.KatashikiMstDataTable insertDT = new KatashikiMstDataSet.KatashikiMstDataTable();

            KatashikiMstDataSet.KatashikiMstRow insertRow = insertDT.NewKatashikiMstRow();

            // メーカー業者コード
            insertRow.KatashikiMakerCd = katashikiMakerCdTextBox.Text;

            // 型式コード
            // ADD 20140731 START ZynasSou
            katashikiCdTextBox.Text = Utility.Saiban.GetKeyRenban("KatashikiMst", katashikiMakerCdTextBox.Text, "", "").PadLeft(4, '0');
            // ADD 20140731 END ZynasSou
            insertRow.KatashikiCd = katashikiCdTextBox.Text;

            // 型式名称
            insertRow.KatashikiNm = katashikiNmTextBox.Text.Trim();

            // 全浄連登録番号
            insertRow.ZenjorenTourokuNo = zenjorenTourokuNoTextBox.Text;

            // 全浄連登録日
            insertRow.ZenjorenTourokuBi = zenjorenTourokuBiTextBox.Text.Trim();

            // 特徴
            insertRow.TokuCho = tokuChoTextBox.Text.Trim();

            // 性能評価型区分
            insertRow.SeinohyokakataKbn = seinohyokakataKbnCheckBox.Checked ? "1" : "0";

            // コンパクト型区分
            insertRow.KonpakutokataKbn = konpakutokataKbnCheckBox.Checked ? "1" : "0";

            // 2014/11/04 DatNT v1.05 MOD Start
            // 構造例示型区分
            //insertRow.KouzoreijikataKbn = kouzoreijikataKbnCheckBox.Checked ? "1" : "0";
            // TODO HotFix
            // TODO 初期値は、0でなく空白でよいのか？
            insertRow.KouzoreijikataKbn = "0";
            //insertRow.KouzoreijikataKbn = string.Empty;

            // ＢＯＤ高度処理型区分
            insertRow.BODKodoshorikataKbn = bodKodokataKbnCheckBox.Checked ? "1" : "0";

            // 窒素除去型区分
            insertRow.ChissojokyokataKbn = chissoJokyokataKbnCheckBox.Checked ? "1" : "0";

            // リン除去型区分
            insertRow.RinjokyokataKbn = rinJokyokataKbnCheckBox.Checked ? "1" : "0";

            //// 点検回数月毎
            ////insertRow.TenkenKaisuTsuki = !string.IsNullOrEmpty(tenkenKaisuShuTextBox.Text) ? Convert.ToInt32(tenkenKaisuTsukiTextBox.Text) : 0;
            //insertRow.TenkenKaisuKbn = tenkenKaisuShuTextBox.Text;

            //// 点検回数週毎 
            ////insertRow.TenkenKaisuShu = !string.IsNullOrEmpty(tenkenKaisuShuTextBox.Text) ? Convert.ToInt32(tenkenKaisuShuTextBox.Text) : 0;
            //insertRow.SeisoKaisuKbn = tenkenKaisuShuTextBox.Text;
            // 2014/11/04 DatNT v1.05 MOD End

            // 2015/01/28 DatNT v1.06 ADD Start
            // 点検回数区分
            if (tenkenKaisuKbnComboBox.SelectedValue != null)
            {
                insertRow.TenkenKaisuKbn = tenkenKaisuKbnComboBox.SelectedValue.ToString();
            }
            else
            {
                insertRow.TenkenKaisuKbn = null;
            }
            // 清掃回数区分
            if (seisoKaisuKbnComboBox.SelectedValue != null)
            {
                insertRow.SeisoKaisuKbn = seisoKaisuKbnComboBox.SelectedValue.ToString();
            }
            else
            {
                insertRow.SeisoKaisuKbn = null;
            }
            // 2015/01/28 DatNT v1.06 ADD End

            // 処理方式区分
            if (katashikiShorihoushikiKbnRadioButton1.Checked)
            {
                insertRow.KatashikiShorihoushikiKbn = "1";
            }
            else if (katashikiShorihoushikiKbnRadioButton2.Checked)
            {
                insertRow.KatashikiShorihoushikiKbn = "2";
            }
            else
            {
                insertRow.KatashikiShorihoushikiKbn = "3";
            }

            // 処理方式コード
            insertRow.KatashikiShorihoushikiCd = katashikiShorihoushikiCdTextBox.Text;

            insertRow.InsertDt = now;
            insertRow.InsertTarm = terminal;
            insertRow.InsertUser = loginUser;
            insertRow.UpdateDt = now;
            insertRow.UpdateTarm = terminal;
            insertRow.UpdateUser = loginUser;

            // 行を挿入
            insertDT.AddKatashikiMstRow(insertRow);

            // 行の状態を設定
            insertRow.AcceptChanges();

            // 行の状態を設定（新規）
            insertRow.SetAdded();

            return insertDT;
        }
        #endregion

        #region CreateMstDTUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateMstDTUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// 2014/11/04  DatNT       v1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KatashikiMstDataSet.KatashikiMstDataTable CreateMstDTUpdate(
            KatashikiMstDataSet.KatashikiMstDataTable dataTable,
            DateTime now)
        {
            // 型式名称
            dataTable[0].KatashikiNm = katashikiNmTextBox.Text.Trim();

            // 全浄連登録番号
            dataTable[0].ZenjorenTourokuNo = zenjorenTourokuNoTextBox.Text;

            // 全浄連登録日
            dataTable[0].ZenjorenTourokuBi = zenjorenTourokuBiTextBox.Text.Trim();

            // 特徴
            dataTable[0].TokuCho = tokuChoTextBox.Text.Trim();

            // 性能評価型区分
            dataTable[0].SeinohyokakataKbn = seinohyokakataKbnCheckBox.Checked ? "1" : "0";

            // コンパクト型区分
            dataTable[0].KonpakutokataKbn = konpakutokataKbnCheckBox.Checked ? "1" : "0";

            // 2014/11/04 DatNT v1.05 MOD Start
            // 構造例示型区分
            //dataTable[0].KouzoreijikataKbn = kouzoreijikataKbnCheckBox.Checked ? "1" : "0";

            // ＢＯＤ高度処理型区分
            dataTable[0].BODKodoshorikataKbn = bodKodokataKbnCheckBox.Checked ? "1" : "0";

            // 窒素除去型区分
            dataTable[0].ChissojokyokataKbn = chissoJokyokataKbnCheckBox.Checked ? "1" : "0";

            // リン除去型区分
            dataTable[0].RinjokyokataKbn = rinJokyokataKbnCheckBox.Checked ? "1" : "0";

            //// 点検回数月毎
            ////dataTable[0].TenkenKaisuTsuki = !string.IsNullOrEmpty(tenkenKaisuShuTextBox.Text) ? Convert.ToInt32(tenkenKaisuTsukiTextBox.Text) : 0;
            //dataTable[0].TenkenKaisuKbn = tenkenKaisuShuTextBox.Text;

            //// 点検回数週毎 
            ////dataTable[0].TenkenKaisuShu = !string.IsNullOrEmpty(tenkenKaisuShuTextBox.Text) ? Convert.ToInt32(tenkenKaisuShuTextBox.Text) : 0;
            //dataTable[0].SeisoKaisuKbn = tenkenKaisuShuTextBox.Text;
            // 2014/11/04 DatNT v1.05 MOD End

            // 2015/01/28 DatNT v1.06 ADD Start
            // 点検回数区分
            if (tenkenKaisuKbnComboBox.SelectedValue != null)
            {
                dataTable[0].TenkenKaisuKbn = tenkenKaisuKbnComboBox.SelectedValue.ToString();
            }
            else
            {
                dataTable[0].TenkenKaisuKbn = null;
            }
            // 清掃回数区分
            if (seisoKaisuKbnComboBox.SelectedValue != null)
            {
                dataTable[0].SeisoKaisuKbn = seisoKaisuKbnComboBox.SelectedValue.ToString();
            }
            else
            {
                dataTable[0].SeisoKaisuKbn = null;
            }
            // 2015/01/28 DatNT v1.06 ADD End

            // 処理方式区分
            if (katashikiShorihoushikiKbnRadioButton1.Checked)
            {
                dataTable[0].KatashikiShorihoushikiKbn = "1";
            }
            else if (katashikiShorihoushikiKbnRadioButton2.Checked)
            {
                dataTable[0].KatashikiShorihoushikiKbn = "2";
            }
            else
            {
                dataTable[0].KatashikiShorihoushikiKbn = "3";
            }

            // 処理方式コード
            dataTable[0].KatashikiShorihoushikiCd = katashikiShorihoushikiCdTextBox.Text;

            //DEL_20141114_HuyTX Start
            //dataTable[0].UpdateDt = now;
            //DEL_20141114_HuyTX End
            dataTable[0].UpdateTarm = terminal;
            dataTable[0].UpdateUser = loginUser;

            return dataTable;
        }
        #endregion

        #region CreateBuroDTInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateBuroDTInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable CreateBuroDTInsert(DateTime now)
        {
            KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable insertDT = new KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable();

            for (int i = 0; i < katashikiBurowaListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = katashikiBurowaListDataGridView.Rows[i];

                if ((row.Cells["BurowaNinsouCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaNinsouCol"].Value.ToString()))
                    && (row.Cells["BurowaRenbanCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaRenbanCol"].Value.ToString()))
                    && (row.Cells["BurowaKiteiBurowaNmCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaKiteiBurowaNmCol"].Value.ToString()))
                    && (row.Cells["BurowaKiteiFuryoCol"].Value == null || string.IsNullOrEmpty(row.Cells["BurowaKiteiFuryoCol"].Value.ToString()))
                    )
                {
                    // Row empty
                    // don't add
                }
                else
                {
                    KatashikiBurowaMstDataSet.KatashikiBurowaMstRow insertRow = insertDT.NewKatashikiBurowaMstRow();

                    // メーカー業者コード
                    insertRow.BurowaKatashikiMakerCd = katashikiMakerCdTextBox.Text;

                    // 型式コード
                    insertRow.BurowaKatashikiCd = katashikiCdTextBox.Text;

                    // 人槽
                    insertRow.BurowaNinsou = row.Cells["BurowaNinsouCol"].Value.ToString();

                    // 連番
                    insertRow.BurowaRenban = row.Cells["BurowaRenbanCol"].Value.ToString();

                    // 規定ブロブ名称
                    insertRow.BurowaKiteiBurowaNm = row.Cells["BurowaKiteiBurowaNmCol"].Value.ToString();

                    // 規定風量
                    insertRow.BurowaKiteiFuryo = row.Cells["BurowaKiteiFuryoCol"].Value.ToString();

                    insertRow.InsertDt = now;
                    insertRow.InsertTarm = terminal;
                    insertRow.InsertUser = loginUser;
                    insertRow.UpdateDt = now;
                    insertRow.UpdateTarm = terminal;
                    insertRow.UpdateUser = loginUser;

                    // 行を挿入
                    insertDT.AddKatashikiBurowaMstRow(insertRow);

                    // 行の状態を設定
                    insertRow.AcceptChanges();

                    // 行の状態を設定（新規）
                    insertRow.SetAdded();
                }
            }

            return insertDT;
        }
        #endregion

        #region CreateBuroDTUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateBuroDTUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable CreateBuroDTUpdate(DateTime now)
        {
            KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable dataTable = new KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable();

            foreach (DataRow dr in _katashikiBurowaMstDT)
            {
                if (!string.IsNullOrEmpty(dr["BurowaNinsou"].ToString())
                    && !string.IsNullOrEmpty(dr["BurowaRenban"].ToString())
                    && !string.IsNullOrEmpty(dr["BurowaKiteiBurowaNm"].ToString())
                    && !string.IsNullOrEmpty(dr["BurowaKiteiFuryo"].ToString()))
                {
                    dr["InsertDt"] = now;
                    dr["InsertUser"] = loginUser;
                    dr["InsertTarm"] = terminal;
                    dr["UpdateDt"] = now;
                    dr["UpdateUser"] = loginUser;
                    dr["UpdateTarm"] = terminal;

                    dataTable.ImportRow(dr);
                }
            }
            return dataTable;
        }
        #endregion

        #region CreateSochiDTInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSochiDTInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// 2015/01/29  DatNT       v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable CreateSochiDTInsert(DateTime now)
        {
            KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable insertDT = new KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable();

            if (taniSouchiListDataGridView.RowCount == 0)
            {
                // don't handled
            }
            else
            {
                for (int i = 0; i < taniSouchiListDataGridView.RowCount; i++)
                {
                    DataGridViewRow row = taniSouchiListDataGridView.Rows[i];

                    KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstRow insertRow = insertDT.NewKatashikiBetsuTaniSochiMstRow();

                    // メーカー業者コード
                    insertRow.KatashikiMakerCd = katashikiMakerCdTextBox.Text;

                    // 型式コード
                    insertRow.KatashikiCd = katashikiCdTextBox.Text;
                    
                    // 単位装置グループコード
                    insertRow.TaniSochiGroupCd = row.Cells["TaniSouchiGroupCdCol"].Value.ToString();

                    // 単位装置名
                    insertRow.TaniSochiNm = row.Cells["TaniSouchiNmCol"].Value.ToString();
                    // UPD 20140731 END ZynasSou

                    // 2015/01/29 DatNT v1.06 ADD Start
                    insertRow.Renban = i + 1;
                    // 2015/01/29 DatNT v1.06 ADD End

                    insertRow.InsertDt = now;
                    insertRow.InsertTarm = terminal;
                    insertRow.InsertUser = loginUser;
                    insertRow.UpdateDt = now;
                    insertRow.UpdateTarm = terminal;
                    insertRow.UpdateUser = loginUser;

                    // 行を挿入
                    insertDT.AddKatashikiBetsuTaniSochiMstRow(insertRow);

                    // 行の状態を設定
                    insertRow.AcceptChanges();

                    // 行の状態を設定（新規）
                    insertRow.SetAdded();
                }
            }

            return insertDT;
        }
        #endregion

        #region ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            string colName = katashikiBurowaListDataGridView.Columns[katashikiBurowaListDataGridView.CurrentCell.ColumnIndex].Name;

            if (colName == "BurowaNinsouCol"
                || colName == "BurowaRenbanCol"
                || colName == "BurowaKiteiFuryoCol")
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
        #endregion
        
        #region DisplayDataTab01
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDataTab01
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alOutput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// 2014/11/04  DatNT       v1.05
        /// 2015/01/28  DatNT       v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDataTab01(IFormLoadALOutput alOutput)
        {
            // 2014/11/04 DatNT v1.05 DEL Start
            //// gyoshaNmComboBox
            //Utility.Utility.SetComboBoxList(gyoshaNmComboBox, alOutput.GyoshaMstDT, "GyoshaNm", "GyoshaCd", true);
            // 2014/11/04 DatNT v1.05 DEL End

            // 2015/01/28 DatNT v1.06 ADD Start
            // 点検回数区分
            Utility.Utility.SetComboBoxList(tenkenKaisuKbnComboBox,
                                            Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_067),
                                            "ConstNm",
                                            "ConstValue",
                                            true);
            // 清掃回数区分
            Utility.Utility.SetComboBoxList(seisoKaisuKbnComboBox,
                                            Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_068),
                                            "ConstNm",
                                            "ConstValue",
                                            true);
            // 2015/01/28 DatNT v1.06 ADD End

            // shoriHoshikiNmComboBox
            ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable shoriHoshikiNmComboBoxSource = new ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

            foreach (ShoriHoshikiMstDataSet.ShoriHoshikiMstRow row in _shoriHoshikiMstDT.Select("ShoriHoshikiKbn = '1'"))
            {
                shoriHoshikiNmComboBoxSource.ImportRow(row);
            }

            Utility.Utility.SetComboBoxList(shoriHoshikiNmComboBox, shoriHoshikiNmComboBoxSource, "ShoriHoshikiNm", "ShoriHoshikiCd", true);

            if (alOutput.KatashikiMstDT != null && alOutput.KatashikiMstDT.Count > 0)
            {
                SetValues(alOutput.KatashikiMstDT[0]);

                _mstDT = alOutput.KatashikiMstDT;
            }
        }
        #endregion

        #region DisplayDataTab02
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDataTab02
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alOutput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDataTab02(IFormLoadALOutput alOutput)
        {
            if (alOutput.KatashikiBurowaMstDT != null && alOutput.KatashikiBurowaMstDT.Count > 0)
            {
                // ADD 20140731 START ZynasSou
                foreach (KatashikiBurowaMstDataSet.KatashikiBurowaMstRow row in alOutput.KatashikiBurowaMstDT.Rows)
                {
                    row.BurowaKiteiFuryo = row.BurowaKiteiFuryo.Trim();
                }
                // ADD 20140731 END ZynasSou

                // 2014 20141120 habu DEL save at upper layer
                //_katashikiBurowaMstDT = alOutput.KatashikiBurowaMstDT;

                katashikiBurowaListDataGridView.DataSource = _katashikiBurowaMstDT;

                _katashikiBurowaMstDT.PrimaryKey = null;

                foreach (DataColumn dc in _katashikiBurowaMstDT.Columns)
                {
                    dc.AllowDBNull = true;

                    if (dc.ColumnName == "BurowaNinsou"
                        || dc.ColumnName == "BurowaRenban"
                        || dc.ColumnName == "BurowaKiteiBurowaNm"
                        || dc.ColumnName == "BurowaKiteiFuryo")
                    {
                        dc.MaxLength = Int32.MaxValue;
                    }
                }
            }
            // display columns of katashikiBurowaListDgv
            DispColumnKatashikiBurowaListdgv();
        }
        #endregion

        #region DisplayDataTab03
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDataTab03
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alOutput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDataTab03(IFormLoadALOutput alOutput)
        {
            // taniSouchiGroupList
            Utility.Utility.SetListBoxSource(taniSouchiGroupList, alOutput.TaniSochiGroupMstDT, "TaniSochiGroupNm", "TaniSochiGroupCd");
            
            if (alOutput.KatashikiBetsuTaniSochiListDT != null && alOutput.KatashikiBetsuTaniSochiListDT.Count > 0)
            {
                // 2014 20141120 habu DEL save at upper layer
                //_katashikiBetsuTaniSochiListDT = alOutput.KatashikiBetsuTaniSochiListDT;

                //taniSouchiListDataGridView.DataSource = _katashikiBetsuTaniSochiListDT;

                //dt = (DataTable)_katashikiBetsuTaniSochiListDT;
                foreach (KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiListRow row in alOutput.KatashikiBetsuTaniSochiListDT)
                {
                    taniSouchiListDataGridView.Rows.Add(row.TaniSochiGroupCd, row.TaniSochiGroupNm, row.TaniSochiNm);
                }


                foreach (KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiListRow row in _katashikiBetsuTaniSochiListDT)
                {
                    listTanisochiCd.Add(row.TaniSochiGroupCd);
                }
            }

            foreach (DataGridViewColumn col in taniSouchiListDataGridView.Columns)
            {
                if (col.Name == "TaniSouchiGroupNmCol" || col.Name == "TaniSouchiNmCol")
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }
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
        /// 2014/07/09  DatNT　　    新規作成
        /// 2014/11/04  DatNT       v1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckEdit()
        {
            //check edit mode add
            if (string.IsNullOrEmpty(_katashikiMakerCd) && string.IsNullOrEmpty(_katashikiCd))
            {
                if (katashikiMakerCdTextBox.Text != string.Empty
                    || katashikiCdTextBox.Text != string.Empty
                    // 2014/11/04 DatNT v1.05 DEL Start
                    //|| gyoshaNmComboBox.SelectedIndex != 0
                    // 2014/11/04 DatNT v1.05 DEL End
                    || katashikiNmTextBox.Text != string.Empty
                    || zenjorenTourokuNoTextBox.Text != string.Empty
                    || zenjorenTourokuBiTextBox.Text != string.Empty
                    || tokuChoTextBox.Text != string.Empty
                    || seinohyokakataKbnCheckBox.Checked
                    || konpakutokataKbnCheckBox.Checked
                    // 2014/11/04 DatNT v1.05 MOD Start
                    //|| kouzoreijikataKbnCheckBox.Checked
                    || bodKodokataKbnCheckBox.Checked
                    || chissoJokyokataKbnCheckBox.Checked
                    || rinJokyokataKbnCheckBox.Checked
                    // 2014/11/04 DatNT v1.05 MOD End
                    || !katashikiShorihoushikiKbnRadioButton1.Checked
                    || katashikiShorihoushikiCdTextBox.Text != string.Empty
                    // 2015/01/28 DatNT v1.06 ADD Start
                    || tenkenKaisuKbnComboBox.SelectedIndex != 0
                    || seisoKaisuKbnComboBox.SelectedIndex != 0
                    // 2015/01/28 DatNT v1.06 ADD End
                    )
                {
                    return false;
                }

                // tab 2
                if (katashikiBurowaListDataGridView.RowCount != 1)
                {
                    return false;
                }

                // tab 3
                if (taniSouchiListDataGridView.RowCount != 0)
                {
                    return false;
                }
            }
            else
            {
                // Check tab 1
                if (katashikiNmTextBox.Text != _mstDT[0].KatashikiNm
                        || katashikiCdTextBox.Text != _mstDT[0].KatashikiCd
                        || zenjorenTourokuNoTextBox.Text != _mstDT[0].ZenjorenTourokuNo
                        || zenjorenTourokuBiTextBox.Text != _mstDT[0].ZenjorenTourokuBi
                        || tokuChoTextBox.Text != _mstDT[0].TokuCho
                        || (seinohyokakataKbnCheckBox.Checked && _mstDT[0].SeinohyokakataKbn == "0")
                        || (!seinohyokakataKbnCheckBox.Checked && _mstDT[0].SeinohyokakataKbn == "1")
                        || (konpakutokataKbnCheckBox.Checked && _mstDT[0].KonpakutokataKbn == "0")
                        || (!konpakutokataKbnCheckBox.Checked && _mstDT[0].KonpakutokataKbn == "1")
                        // 2014/11/04 DatNT v1.05 MOD Start
                        //|| (kouzoreijikataKbnCheckBox.Checked && _mstDT[0].KouzoreijikataKbn == "0")
                        //|| (!kouzoreijikataKbnCheckBox.Checked && _mstDT[0].KouzoreijikataKbn == "1")
                        || (bodKodokataKbnCheckBox.Checked && _mstDT[0].BODKodoshorikataKbn == "0")
                        || (!bodKodokataKbnCheckBox.Checked && _mstDT[0].BODKodoshorikataKbn == "1")
                        || (chissoJokyokataKbnCheckBox.Checked && _mstDT[0].ChissojokyokataKbn == "0")
                        || (!chissoJokyokataKbnCheckBox.Checked && _mstDT[0].ChissojokyokataKbn == "1")
                        || (rinJokyokataKbnCheckBox.Checked && _mstDT[0].RinjokyokataKbn == "0")
                        || (!rinJokyokataKbnCheckBox.Checked && _mstDT[0].RinjokyokataKbn == "1")
                        // 2014/11/04 DatNT v1.05 MOD End
                        || (katashikiShorihoushikiKbnRadioButton1.Checked && _mstDT[0].KatashikiShorihoushikiKbn != "1")
                        || (katashikiShorihoushikiKbnRadioButton2.Checked && _mstDT[0].KatashikiShorihoushikiKbn != "2")
                        || katashikiShorihoushikiCdTextBox.Text != _mstDT[0].KatashikiShorihoushikiCd
                        // 2015/01/29 DatNT v1.06 ADD Start
                        || (Convert.ToString(tenkenKaisuKbnComboBox.SelectedValue) != _mstDT[0].TenkenKaisuKbn)
                        || (Convert.ToString(seisoKaisuKbnComboBox.SelectedValue) != _mstDT[0].SeisoKaisuKbn)
                        // 2015/01/29 DatNT v1.06 ADD End
                    )
                {
                    return false;
                }

                // Check tab 2
                if (katashikiBurowaListDgvchanged)
                {
                    return false;
                }

                // Check tab 3
                foreach (DataGridViewRow row in taniSouchiListDataGridView.Rows)
                {
                    // UPD 20140731 START ZynasSou
                    //if (!listTanisochiCd.Contains(row.Cells["TaniSouchiCdCol"].Value.ToString())
                    //    || listTanisochiCd.Count != taniSouchiListDataGridView.RowCount)
                    if (!listTanisochiCd.Contains(row.Cells["TaniSouchiGroupCdCol"].Value.ToString())
                        || listTanisochiCd.Count != taniSouchiListDataGridView.RowCount)
                        // UPD 20140731 END ZynasSou
                    {
                        return false;
                    }

                    if (taniSouchiListDgvchanged)
                    {
                        return false;
                    }
                }

                if (listTanisochiCd.Count != taniSouchiListDataGridView.RowCount)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region GetListDuplicate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetListDuplicate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public List<string> GetListDuplicate()
        {
            List<string> listKey = new List<string>();

            for (int i = 0; i < katashikiBurowaListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = katashikiBurowaListDataGridView.Rows[i];

                // RelationCheck
                if (row.Cells["BurowaNinsouCol"].Value != null && row.Cells["BurowaRenbanCol"].Value != null)
                {
                    string namePK = row.Cells["BurowaNinsouCol"].Value.ToString() + "-" + row.Cells["BurowaRenbanCol"].Value.ToString();

                    for (int j = i + 1; j < katashikiBurowaListDataGridView.RowCount; j++)
                    {
                        DataGridViewRow rowJ = katashikiBurowaListDataGridView.Rows[j];

                        if (rowJ.Cells["BurowaNinsouCol"].Value != null && rowJ.Cells["BurowaRenbanCol"].Value != null)
                        {
                            string key = rowJ.Cells["BurowaNinsouCol"].Value.ToString() + "-" + rowJ.Cells["BurowaRenbanCol"].Value.ToString();

                            if (namePK == key)
                            {
                                listKey.Add(key);
                            }
                        }
                    }
                }
            }

            return listKey;
        }
        #endregion

        #region ChangeBackground
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeBackground
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listKey"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/15  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeBackground(List<string> listKey)
        {
            DataGridViewCellStyle styleWhite = new DataGridViewCellStyle();

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;

            // if have data duplicate
            if (listKey != null && listKey.Count > 0)
            {
                foreach (string key in listKey)
                {
                    string ninsou = key.Split('-')[0];
                    string renban = key.Split('-')[1];

                    foreach (DataGridViewRow row in katashikiBurowaListDataGridView.Rows)
                    {
                        if (row.Cells["BurowaNinsouCol"].Value != null)
                        {
                            if (row.Cells["BurowaNinsouCol"].Value.ToString() == ninsou
                                && row.Cells["BurowaRenbanCol"].Value.ToString() == renban)
                            {
                                row.DefaultCellStyle = style;
                            }
                            else
                            {
                                //row.DefaultCellStyle = styleWhite;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in katashikiBurowaListDataGridView.Rows)
                {
                    row.DefaultCellStyle = styleWhite;
                }
            }
        }
        #endregion

        #region SetControlDomain
        // 2015/01/28 DatNT v1.06 DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： SetControlDomain
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/12/26  DatNT　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void SetControlDomain()
        //{
        //    // 点検回数月毎
        //    tenkenKaisuTsukiTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 3);

        //    // 点検回数週毎
        //    tenkenKaisuShuTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 3);
        //}
        #endregion
        
        #endregion

    }
    #endregion
}
