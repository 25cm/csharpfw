using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaHoryuShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaHoryuShosaiForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// 協会No
        /// </summary>
        private string _kyokaiNo;

        /// <summary>
        /// KensaHoryuShosaiDataTable
        /// </summary>
        private KensaHoryuDataSet.KensaHoryuShosaiDataTable _dispTable;

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        private KensaIraiTblDataSet.KensaIraiTblDataTable _kensaIraiTbl;

        /// <summary>
        /// 編集チェック用データ
        /// </summary>
        private KensaIraiTblDataSet.KensaIraiTblDataTable _initLoadData;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaHoryuShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaHoryuShosaiForm()
        {
            InitializeComponent();
            ManageControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaHoryuShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaHoryuShosaiForm(string kyokaiNo)
        {
            this._kyokaiNo = kyokaiNo;
            InitializeComponent();
            ManageControlDomain();
        }
        #endregion

        #region イベント

        #region KensaHoryuShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaHoryuShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaHoryuShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();
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

        #region KensaHoryuShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaHoryuShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// 2014/11/10　AnhNV　　    基本設計書_009_009_画面_KensaHoryuShosai_Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaHoryuShosaiForm_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
                        break;
                    case Keys.F5:
                        jokyoHaakuMakeButton.Focus();
                        jokyoHaakuMakeButton.PerformClick();
                        break;
                    case Keys.F6:
                        jokyoHaakuSaveButton.Focus();
                        jokyoHaakuSaveButton.PerformClick();
                        break;
                    case Keys.F7:
                        jokyoHaakuDeleteButton.Focus();
                        jokyoHaakuDeleteButton.PerformClick();
                        break;
                    case Keys.F8:
                        genkyoHokokuMakeButton.Focus();
                        genkyoHokokuMakeButton.PerformClick();
                        break;
                    case Keys.F9:
                        genkyoHokokuSaveButton.Focus();
                        genkyoHokokuSaveButton.PerformClick();
                        break;
                    case Keys.F10:
                        genkyoHokokuDeleteButton.Focus();
                        genkyoHokokuDeleteButton.PerformClick();
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
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック + 入力内容チェック + 関連チェック
                if (!DataCheck()) return;

                // Confirmation!
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されている内容で保留情報を更新します。よろしいですか？") == DialogResult.Yes)
                {
                    // Update KensaIraiTbl
                    IEntryBtnClickALInput alInput = new EntryBtnClickALInput();
                    alInput.KensaIraiTblDataTable = CreateKensaIraiTblUpdate(_kensaIraiTbl);
                    new EntryBtnClickApplicationLogic().Execute(alInput);

                    // 20141209 habu Add Fixed editCheck
                    // recreate edit checkData
                    _initLoadData = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                    _initLoadData.BeginLoadData();
                    _initLoadData.AddKensaIraiTblRow(_initLoadData.NewKensaIraiTblRow());
                    _initLoadData = CreateKensaIraiTblUpdate(_initLoadData);
                    // 20141209 End
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
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Confirmation!
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "保留内容を取り消します。よろしいですか？") == DialogResult.Yes)
                {
                    // Delete KensaIraiTbl
                    IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                    alInput.KensaIraiTblDataTable = CreateKensaIraiTblDelete(_kensaIraiTbl);
                    new DeleteBtnClickApplicationLogic().Execute(alInput);

                    // Back to 009-008
                    //KensaHoryuListForm frm = new KensaHoryuListForm();
                    //Program.mForm.ShowForm(frm);
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

        #region jokyoHaakuMakeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jokyoHaakuMakeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jokyoHaakuMakeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IJokyoHaakuMakeBtnClickALInput alInput = new JokyoHaakuMakeBtnClickALInput();
                alInput.KyokaiNo = _kyokaiNo;
                alInput.KensaHoryuShosaiDataTable = _dispTable;
                IJokyoHaakuMakeBtnClickALOutput alOutput = new JokyoHaakuMakeBtnClickApplicationLogic().Execute(alInput);

                // An error occured!
                if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
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

        #region jokyoHaakuDeleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jokyoHaakuDeleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jokyoHaakuDeleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Confirmation!
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "対象の状況把握票を削除します。よろしいですか？") == DialogResult.Yes)
                {
                    IJokyoHaakuDeleteBtnClickALInput alInput = new JokyoHaakuDeleteBtnClickALInput();
                    alInput.KyokaiNo = _kyokaiNo;
                    IJokyoHaakuDeleteBtnClickALOutput alOutput = new JokyoHaakuDeleteBtnClickApplicationLogic().Execute(alInput);

                    // Delete file error
                    if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
                        return;
                    }

                    // Delete completedly!
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象の状況把握票を削除しました。");
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

        #region genkyoHokokuMakeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： genkyoHokokuMakeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void genkyoHokokuMakeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] keys = _kyokaiNo.Split('-');

                IGenkyoHokokuMakeBtnClickALInput alInput = new GenkyoHokokuMakeBtnClickALInput();
                alInput.KyokaiNo = _kyokaiNo;
                alInput.KensaIraiHokenjoCd = keys[0];
                alInput.KensaIraiNendo = Utility.DateUtility.ConvertFromWareki(keys[1], "yyyy");
                alInput.KensaIraiRenban = keys[2];
                alInput.ShozokuShisyo = syozokuShisyoComboBox.GetItemText(syozokuShisyoComboBox.SelectedItem);
                alInput.ShozokuBusho = syozokuBusyoComboBox.GetItemText(syozokuBusyoComboBox.SelectedItem);
                alInput.TantoKensain = tantoKensainComboBox.GetItemText(tantoKensainComboBox.SelectedItem);
                IGenkyoHokokuMakeBtnClickALOutput alOutput = new GenkyoHokokuMakeBtnClickApplicationLogic().Execute(alInput);

                // An error occured!
                if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
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

        #region genkyoHokokuDeleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： genkyoHokokuDeleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void genkyoHokokuDeleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Confirmation!
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "対象の現況報告書を削除します。よろしいですか？") == DialogResult.Yes)
                {
                    IGenkyoHokokuDeleteBtnClickALInput alInput = new GenkyoHokokuDeleteBtnClickALInput();
                    alInput.KyokaiNo = _kyokaiNo;
                    IGenkyoHokokuDeleteBtnClickALOutput alOutput = new GenkyoHokokuDeleteBtnClickApplicationLogic().Execute(alInput);

                    // Delete file error
                    if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
                        return;
                    }

                    // Delete completedly!
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象の現況報告書を削除しました。");
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
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // An item is edited!
                if (!WarningTextChanged())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        // Go to 009-008
                        //KensaHoryuListForm frm = new KensaHoryuListForm();
                        //Program.mForm.ShowForm(frm);
                        Program.mForm.MovePrev();
                    }
                }
                else
                {
                    // Go to 009-008
                    //KensaHoryuListForm frm = new KensaHoryuListForm();
                    //Program.mForm.ShowForm(frm);
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

        #region kakuninDtTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuninDtTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuninDtTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Add 6 month to 次回確認期限日(13)
                jikaiKakuninDtTextBox.Value = kakuninDtTextBox.Value.AddMonths(6);
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

        #region jokyoHaakuSaveButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jokyoHaakuSaveButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jokyoHaakuSaveButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IJokyoHaakuSaveBtnClickALInput alInput = new JokyoHaakuSaveBtnClickALInput();
                alInput.KyokaiNo = _kyokaiNo;
                IJokyoHaakuSaveBtnClickALOutput alOutput = new JokyoHaakuSaveBtnClickApplicationLogic().Execute(alInput);

                // Save error
                if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
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

        #region genkyoHokokuSaveButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： genkyoHokokuSaveButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void genkyoHokokuSaveButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IGenkyoHokokuSaveBtnClickALInput alInput = new GenkyoHokokuSaveBtnClickALInput();
                alInput.KyokaiNo = _kyokaiNo;
                IGenkyoHokokuSaveBtnClickALOutput alOutput = new GenkyoHokokuSaveBtnClickApplicationLogic().Execute(alInput);

                // Save error
                if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
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

        #region haakuLabel_MouseDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： haakuLabel_MouseDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void haakuLabel_MouseDown(object sender, MouseEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                label2.Focus();
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
        /// 2014/08/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            string[] keys = _kyokaiNo.Split('-');

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.KensaIraiHokenjoCd = keys[0];
            alInput.KensaIraiNendo = Utility.DateUtility.ConvertFromWareki(keys[1], "yyyy");
            alInput.KensaIraiRenban = keys[2];
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            _dispTable = alOutput.KensaHoryuShosaiDataTable;
            _kensaIraiTbl = alOutput.KensaIraiTblDataTable;

            // Load default value
            DisplayDefault(alOutput);

            // 20141209 habu Add Fixed editCheck
            _initLoadData = new KensaIraiTblDataSet.KensaIraiTblDataTable();
            _initLoadData.BeginLoadData();
            _initLoadData.AddKensaIraiTblRow(_initLoadData.NewKensaIraiTblRow());
            _initLoadData = CreateKensaIraiTblUpdate(_initLoadData);
            // 20141209 End
        }
        #endregion

        #region DisplayDefault
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDefault
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault(IFormLoadALOutput alOutput)
        {
            // 協会No(保健所コード)(1)
            kyokaiNo1TextBox.Text = _dispTable[0].KensaIraiHokenjoCd;

            // 協会No(年度)(2)
            kyokaiNo2TextBox.Text = _dispTable[0].KensaIraiNendo.ToString();

            // 協会No(連番)(3)
            kyokaiNo3TextBox.Text = _dispTable[0].KensaIraiRenban;

            // 設置者名(4)
            settisyaNmTextBox.Text = _dispTable[0].KensaIraiSetchishaNm;

            // 受付支所(5)
            //Utility.Utility.SetComboBoxList(uketsukeShisyoComboBox, alOutput.ComboBoxSources.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(uketsukeShisyoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
            uketsukeShisyoComboBox.SelectedValue = _dispTable[0].KensaIraiUketsukeShishoKbn;

            // 担当検査員(7)
            Utility.Utility.SetComboBoxList(tantoKensainComboBox, alOutput.ComboBoxSources.TantoKensainDataTable, "ShokuinNm", "ShokuinCd", true);
            tantoKensainComboBox.SelectedValue = _dispTable[0].KensaIraiKensaTantoshaCd;

            // 保留の理由(9)
            Utility.Utility.SetComboBoxList(horyuRiyuComboBox, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_009), "ConstNm", "ConstValue", true);
            horyuRiyuComboBox.SelectedValue = _dispTable[0].KensaIraiHoryuKbn;

            // 保留内容(11)
            horyuNaiyoTextBox.Text = _dispTable[0].KensaIraiHoryuRiyu;

            // 確認日(12)
            kakuninDtTextBox.Value = Convert.ToDateTime(_dispTable[0].KensaIrai7joHoryuKakuninDt);

            // 次回確認期限日(13)
            jikaiKakuninDtTextBox.Value = Convert.ToDateTime(_dispTable[0].KensaIraiJikaiKakuninYoteiDt);

            // 起票者/所属支所(14)
            //Utility.Utility.SetComboBoxList(syozokuShisyoComboBox, alOutput.ComboBoxSources.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(syozokuShisyoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
            syozokuShisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            // 起票者/所属部署(15)
            Utility.Utility.SetComboBoxList(syozokuBusyoComboBox, alOutput.ComboBoxSources.BushoMstDataTable, "BushoNm", "BushoCd", true);
            syozokuBusyoComboBox.SelectedValue = alOutput.ShozokuMstDT.Count > 0 ? alOutput.ShozokuMstDT[0].ShozokuBushoCd : string.Empty;

            // 起票者/起票者(16)
            Utility.Utility.SetComboBoxList(kihyosyaComboBox, alOutput.ComboBoxSources.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", true);
            kihyosyaComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;
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
        /// 2014/09/08  AnhNV　　    新規作成
        /// 2014/09/08  AnhNV　　    基本設計書_009_009_画面_KensaHoryuShosai.Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 保留の理由(9)
            if (horyuRiyuComboBox.SelectedValue == null || string.IsNullOrEmpty(horyuRiyuComboBox.SelectedValue.ToString()))
            {
                errMsg.Append("必須項目：保留の理由が選択されていません。\r\n");
            }

            // 確認日(12) is greater than 次回確認期限日(13)
            if (kakuninDtTextBox.Value.Date >= jikaiKakuninDtTextBox.Value.Date)
            {
                errMsg.Append("次回確認期限日は、確認日より先の日付を設定してください。\r\n");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString().Replace("\r\n", string.Empty)))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region CreateKensaIraiTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblUpdate(KensaIraiTblDataSet.KensaIraiTblDataTable table)
        {
            // 検査依頼受付支所
            table[0].KensaIraiUketsukeShishoKbn = uketsukeShisyoComboBox.SelectedIndex > 0 ? uketsukeShisyoComboBox.SelectedValue.ToString() : string.Empty;

            // 検査担当者コード
            table[0].KensaIraiKensaTantoshaCd = tantoKensainComboBox.SelectedIndex > 0 ? tantoKensainComboBox.SelectedValue.ToString() : string.Empty;

            // 保留区分
            table[0].KensaIraiHoryuKbn = horyuRiyuComboBox.SelectedIndex > 0 ? horyuRiyuComboBox.SelectedValue.ToString() : string.Empty;

            // 保留理由
            table[0].KensaIraiHoryuRiyu = horyuNaiyoTextBox.Text;

            // ７条保留確認日
            table[0].KensaIrai7joHoryuKakuninDt = kakuninDtTextBox.Value.ToString("yyyyMMdd");

            // 次回確認予定日
            table[0].KensaIraiJikaiKakuninYoteiDt = jikaiKakuninDtTextBox.Value.ToString("yyyyMMdd");

            // ステータス区分
            table[0].KensaIraiStatusKbn = "90";

            // 更新者
            table[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            table[0].UpdateTarm = Dns.GetHostName();

            return table;
        }
        #endregion

        #region CreateKensaIraiTblDelete
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDelete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDelete(KensaIraiTblDataSet.KensaIraiTblDataTable table)
        {
            // 保留取消日
            table[0].KensaIraiHoryuTorikeshiDt = Common.Common.GetCurrentTimestamp().ToString("yyyyMMdd");

            // ステータス区分
            table[0].KensaIraiStatusKbn = !table[0].IsKensaIraiKensaTantoshaCdNull() && !string.IsNullOrEmpty(table[0].KensaIraiKensaTantoshaCd.Trim()) ? "10" : "00";

            //DEL_20141114_HuyTX Start
            // 更新日
            //table[0].UpdateDt = Common.Common.GetCurrentTimestamp();
            //DEL_20141114_HuyTX End

            // 更新者
            table[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            table[0].UpdateTarm = Dns.GetHostName();

            return table;
        }
        #endregion

        #region WarningTextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： WarningTextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool WarningTextChanged()
        {
            // 20141209 habu Add Modified editCheck
            List<DataColumn> checkColList = new List<DataColumn>();

            checkColList.Add(_initLoadData.KensaIraiUketsukeShishoKbnColumn);
            checkColList.Add(_initLoadData.KensaIraiKensaTantoshaCdColumn);
            checkColList.Add(_initLoadData.KensaIraiHoryuKbnColumn);
            checkColList.Add(_initLoadData.KensaIraiHoryuRiyuColumn);
            checkColList.Add(_initLoadData.KensaIrai7joHoryuKakuninDtColumn);
            checkColList.Add(_initLoadData.KensaIraiJikaiKakuninYoteiDtColumn);
            
            KensaIraiTblDataSet.KensaIraiTblDataTable _editData = new KensaIraiTblDataSet.KensaIraiTblDataTable();
            _editData.BeginLoadData();
            _editData.AddKensaIraiTblRow(_editData.NewKensaIraiTblRow());
            _editData = CreateKensaIraiTblUpdate(_editData);

            if (DataBindingHelper.CheckDataIsEdited(_editData[0], _initLoadData[0], checkColList)) { return false; }
            else { return true; }
            // 20141209 End

            #region to be removed
            //// 受付支所(5)
            //string shishoKbn = uketsukeShisyoComboBox.SelectedValue == null ? string.Empty : uketsukeShisyoComboBox.SelectedValue.ToString();
            //if (shishoKbn != _dispTable[0].KensaIraiUketsukeShishoKbn) return false;

            //// 担当検査員(7)
            //string tantoshaCd = tantoKensainComboBox.SelectedValue == null ? string.Empty : tantoKensainComboBox.SelectedValue.ToString();
            //if (tantoshaCd != _dispTable[0].KensaIraiKensaTantoshaCd) return false;

            //// 保留の理由(9)
            //string horyuKbn = horyuRiyuComboBox.SelectedValue == null ? string.Empty : horyuRiyuComboBox.SelectedValue.ToString();
            //if (horyuKbn != _dispTable[0].KensaIraiHoryuKbn) return false;

            //// 保留内容(11)
            //if (horyuNaiyoTextBox.Text.Trim() != _dispTable[0].KensaIraiHoryuRiyu) return false;

            //// 確認日(12)
            //if (kakuninDtTextBox.Value != Convert.ToDateTime(_dispTable[0].KensaIrai7joHoryuKakuninDt)) return false;

            //// 次回確認期限日(13)
            //if (jikaiKakuninDtTextBox.Value != Convert.ToDateTime(_dispTable[0].KensaIraiJikaiKakuninYoteiDt)) return false;

            //return true;
            #endregion
        }
        #endregion

        #region ManageControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ManageControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ManageControlDomain()
        {
            kyokaiNo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiNo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiNo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            horyuNaiyoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 80);
        }
        #endregion

        #endregion

        
    }
    #endregion
}
