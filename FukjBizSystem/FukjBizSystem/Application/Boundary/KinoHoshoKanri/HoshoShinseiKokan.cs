using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiKokan;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KinoHoshoKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoShinseiKokanForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11　HuyTX     新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HoshoShinseiKokanForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// shishoCdArr
        /// </summary>
        private Dictionary<string, int> _shishoCdArr = new Dictionary<string, int>();

        /// <summary>
        /// HoshoTorokuShinseiKokanInfoDataTable
        /// </summary>
        private HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable _hoshoTorokuShinseiKokanInfoDataTable = new HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable();

        /// <summary>
        /// _errMsgExistCheck
        /// </summary>
        private StringBuilder _errMsgExistCheck = new StringBuilder();

        /// <summary>
        /// shishoMstDataTable
        /// </summary>
        private ShishoMstDataSet.ShishoMstDataTable _shishoMstDataTable = new ShishoMstDataSet.ShishoMstDataTable();

        /// <summary>
        /// hoshoTorokuTblInfoDT
        /// </summary>
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable _hoshoTorokuTblInfoDT = new HoshoTorokuTblDataSet.HoshoTorokuTblDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HoshoShinseiKokanForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HoshoShinseiKokanForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region HoshoShinseiKokanForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoShinseiKokanForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoShinseiKokanForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFormLoadALInput alInput = new FormLoadALInput();
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

                _hoshoTorokuShinseiKokanInfoDataTable = GetHoshoTorokuShinseiKokanInfo(alOutput.HoshoTorokuShinseiKokanInfoDataTable);
                _shishoMstDataTable = alOutput.ShishoMstDataTable;
                _hoshoTorokuTblInfoDT = alOutput.HoshoTorokuTblDataTable;

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

        #region exChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： exChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void exChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidData()) return;

                IExChangeBtnClickALInput alInput = new ExChangeBtnClickALInput();

                //Reset shisho array before count up
                _shishoCdArr = new Dictionary<string, int>();
                foreach (ShishoMstDataSet.ShishoMstRow row in _shishoMstDataTable)
                {
                    _shishoCdArr.Add(row.ShishoCd, 0);
                }

                //count up shisho array
                CountUpShishoArray(alInput);

                if (!string.IsNullOrEmpty(_errMsgExistCheck.ToString()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, _errMsgExistCheck.ToString());
                    return;
                }

                alInput.IsUpdate = true;
                alInput.HoshoTorokuInfoDataGridView = oldHoshoTorokuInfoDataGridView;
                alInput.ShishoArr = _shishoCdArr;
                alInput.HoshoTorokuTblDTLoadForm = _hoshoTorokuTblInfoDT;

                IExChangeBtnClickALOutput alOutput = new ExChangeBtnClickApplicationLogic().Execute(alInput);

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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (oldHoshoTorokuInfoDataGridView.RowCount > 1
                    && MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes) return;

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

        #region oldHoshoTorokuInfoDataGridView_CellValidating
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： oldHoshoTorokuInfoDataGridView_CellValidating
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void oldHoshoTorokuInfoDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (oldHoshoTorokuInfoDataGridView.Columns[e.ColumnIndex].Name != OldHoshoTorokuNoCol.Name) return;

                string oldHoshoTorokuNo = string.Empty;

                if (e.FormattedValue == null || string.IsNullOrEmpty(e.FormattedValue.ToString())) goto Changed;

                string errMsgHoshoTorokuNo = GetErrMsgHoshoTorokuNo(e.FormattedValue.ToString().Trim(), "旧保証No");

                if (!string.IsNullOrEmpty(errMsgHoshoTorokuNo))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, errMsgHoshoTorokuNo);
                    e.Cancel = true;
                    goto Changed;
                }

                oldHoshoTorokuNo = e.FormattedValue.ToString().Trim();

            Changed:
                //set data fill to gridview by HoshoTorokuNo
                SetDataFillToGridView(oldHoshoTorokuNo, e.RowIndex);

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

        #region newHoshoTorokuNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： newHoshoTorokuNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void newHoshoTorokuNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string errMsgNewHoshoToroku = GetErrMsgHoshoTorokuNo(newHoshoTorokuNoFromTextBox.Text.Trim(), "新保証No(開始)");

                if (!string.IsNullOrEmpty(errMsgNewHoshoToroku))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, errMsgNewHoshoToroku);
                    newHoshoTorokuNoFromTextBox.Focus();
                }

                //create NewHoshoTorokuNoTo 
                CreateNewHoshoTorokuNoTo();

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

        #region maisuTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： maisuTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void maisuTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //create NewHoshoTorokuNoTo 
                CreateNewHoshoTorokuNoTo();

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

        #region oldHoshoTorokuInfoDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： oldHoshoTorokuInfoDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void oldHoshoTorokuInfoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DataGridViewColumn col = oldHoshoTorokuInfoDataGridView.Columns[oldHoshoTorokuInfoDataGridView.CurrentCell.ColumnIndex];

                if (col.Name == OldHoshoTorokuNoCol.Name || col.Name == HoshoTorokuTorisageDtCol.Name)
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

        #region HoshoShinseiKokanForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoShinseiKokanForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoShinseiKokanForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        exChangeButton.PerformClick();
                        break;
                    case Keys.F12:
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

        #region SetDataFillToGridView
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： SetDataFillToGridView
        /// <summary>
        ///
        /// </summary>
        /// <param name="hoshoTorokuNo"></param>
        /// <param name="rowIdx"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void SetDataFillToGridView(string hoshoTorokuNo, int rowIdx)
        {
            string hoshoTorokuShishoKbn = string.Empty;
            string shishoNm = string.Empty;
            string hoshoTorokuHanbaisakiCd = string.Empty;
            string gyoshaNm = string.Empty;
            string hoshoTorokuUriageDt = string.Empty;
            DateTime updateDt = new DateTime();

            ICellValidatingALInput alInput = new CellValidatingALInput();
            ICellValidatingALOutput alOutput = new CellValidatingApplicationLogic().Execute(alInput);
            _hoshoTorokuShinseiKokanInfoDataTable = GetHoshoTorokuShinseiKokanInfo(alOutput.HoshoTorokuShinseiKokanInfoDataTable);

            foreach (HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoRow row
                in _hoshoTorokuShinseiKokanInfoDataTable.Select(string.Format("HoshoTorokuNo = '{0}' AND HoshoTorokuShishoKbn <> '' AND HoshoTorokuHanbaisakiCd <> '' AND HoshoTorokuUriageDt <> ''", hoshoTorokuNo)))
            {
                hoshoTorokuShishoKbn = row.HoshoTorokuShishoKbn;
                shishoNm = row.ShishoNm;
                hoshoTorokuHanbaisakiCd = row.HoshoTorokuHanbaisakiCd;
                gyoshaNm = row.GyoshaNm;
                hoshoTorokuUriageDt = row.HoshoTorokuUriageDt;
                updateDt = row.UpdateDt;
            }

            DataGridViewRow gridViewRow = oldHoshoTorokuInfoDataGridView.Rows[rowIdx];

            gridViewRow.Cells[HoshoTorokuShishoKbnCol.Name].Value = hoshoTorokuShishoKbn;
            gridViewRow.Cells[ShishoNmCol.Name].Value = shishoNm;
            gridViewRow.Cells[HoshoTorokuHanbaisakiCdCol.Name].Value = hoshoTorokuHanbaisakiCd;
            gridViewRow.Cells[HoshoTorokuHanbaisakiNmCol.Name].Value = gyoshaNm;
            gridViewRow.Cells[HoshoTorokuUriageDtCol.Name].Value = hoshoTorokuUriageDt;
            gridViewRow.Cells[UpdateDtCol.Name].Value = updateDt;

        }
        #endregion

        #region CreateNewHoshoTorokuNoTo
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： CreateNewHoshoTorokuNoTo
        /// <summary>
        ///
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void CreateNewHoshoTorokuNoTo()
        {
            if (newHoshoTorokuNoFromTextBox.Text.Trim().Length != 11 || string.IsNullOrEmpty(maisuTextBox.Text.Trim()))
            {
                newHoshoTorokuNoToTextBox.Text = string.Empty;
                return;
            }

            int newHoshoTorokuNoFrom = Int32.Parse(newHoshoTorokuNoFromTextBox.Text.Trim().Substring(newHoshoTorokuNoFromTextBox.Text.Trim().Length - 5));
            double maisu= Double.Parse(maisuTextBox.Text.Trim());

            newHoshoTorokuNoToTextBox.Text = newHoshoTorokuNoFromTextBox.Text.Trim().Substring(0, 6) + (newHoshoTorokuNoFrom + maisu - 1).ToString().PadLeft(5, '0').Substring((newHoshoTorokuNoFrom + maisu - 1).ToString().PadLeft(5, '0').Length - 5);
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
        /// 2014/08/11　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
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
        #endregion

        #region GetErrMsgHoshoTorokuNo
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetErrMsgHoshoTorokuNo
        /// <summary>
        ///
        /// </summary>
        /// <param name="hoshoTorokuNo"></param>
        /// <param name="itemName"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private string GetErrMsgHoshoTorokuNo(string hoshoTorokuNo, string itemName)
        {
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(hoshoTorokuNo)) return string.Empty;

            if (!Utility.Utility.IsDecimal(hoshoTorokuNo))
            {
                errMsg += itemName + "は半角数字で入力して下さい。";
            }
            else if (hoshoTorokuNo.Length != 11) { errMsg += itemName + "は11桁で入力して下さい。"; }

            return errMsg;
        }
        #endregion

        #region IsValidData
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： IsValidData
        /// <summary>
        ///
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();
            StringBuilder errMsgSoldCheck = new StringBuilder();

            string lineEmptyOldHoshoTorokuNo = string.Empty;
            string lineEmptyHoshoTorokuTorisageDt = string.Empty;
            string lineNotIsNumberOldHoshoTorokuNo = string.Empty;
            string lineNotIsNumberHoshoTorokuTorisageDt = string.Empty;
            string lineNotValidLengthHoshoTorokuNo = string.Empty;
            string lineNotValidLengthHoshoTorokuTorisageDt = string.Empty;

            for (int i = 0; i < oldHoshoTorokuInfoDataGridView.RowCount; i++)
            {
                if (oldHoshoTorokuInfoDataGridView.RowCount > 1 && i == oldHoshoTorokuInfoDataGridView.RowCount - 1) break;

                DataGridViewRow row = oldHoshoTorokuInfoDataGridView.Rows[i];

                object oldHoshoTorokuNo = row.Cells[OldHoshoTorokuNoCol.Name].Value;
                object hoshoTorokuTorisageDt = row.Cells[HoshoTorokuTorisageDtCol.Name].Value;

                //旧保証No
                if (oldHoshoTorokuNo == null)
                {
                    lineEmptyOldHoshoTorokuNo += (i + 1) + ", ";
                }
                else
                {
                    if (!Utility.Utility.IsDecimal(oldHoshoTorokuNo.ToString()))
                    {
                        lineNotIsNumberOldHoshoTorokuNo += (i + 1) + ", ";
                    }
                    else if (oldHoshoTorokuNo.ToString().Trim().Length != 11)
                    {
                        lineNotValidLengthHoshoTorokuNo += (i + 1) + ", ";
                    }
                }

                //取下日
                if (hoshoTorokuTorisageDt == null)
                {
                    lineEmptyHoshoTorokuTorisageDt += (i + 1) + ", ";
                }
                else
                {
                    if (!Utility.Utility.IsDecimal(hoshoTorokuTorisageDt.ToString()))
                    {
                        lineNotIsNumberHoshoTorokuTorisageDt += (i + 1) + ", ";
                    }
                    else if (hoshoTorokuTorisageDt.ToString().Trim().Length != 8)
                    {
                        lineNotValidLengthHoshoTorokuTorisageDt += (i + 1) + ", ";
                    }
                }

                //Sold check
                DataRow[] existRows = _hoshoTorokuShinseiKokanInfoDataTable.Select(string.Format("HoshoTorokuNo = '{0}'", row.Cells[OldHoshoTorokuNoCol.Name].Value));

                if (oldHoshoTorokuNo != null && (((row.Cells[HoshoTorokuShishoKbnCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[HoshoTorokuShishoKbnCol.Name].Value.ToString()))
                    && (row.Cells[HoshoTorokuHanbaisakiCdCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[HoshoTorokuHanbaisakiCdCol.Name].Value.ToString()))
                    && (row.Cells[HoshoTorokuUriageDtCol.Name].Value == null || string.IsNullOrEmpty(row.Cells[HoshoTorokuUriageDtCol.Name].Value.ToString()))
                    && existRows.Length != 0)
                    || existRows.Length == 0)
                    )
                {
                    errMsgSoldCheck.AppendLine(string.Format("該当Noの申請書は販売されていません。[旧保証No：{0}]", row.Cells[OldHoshoTorokuNoCol.Name].Value));
                }

            }

            #region Throw errors message

            //旧保証No
            if (!string.IsNullOrEmpty(lineEmptyOldHoshoTorokuNo))
            {
                errMsg.AppendLine("行 : " + lineEmptyOldHoshoTorokuNo.Remove(lineEmptyOldHoshoTorokuNo.Length - 2) + " 必須項目：旧保証Noが入力されていません。");
            }

            if (!string.IsNullOrEmpty(lineNotIsNumberOldHoshoTorokuNo))
            {
                errMsg.AppendLine("行 : " + lineNotIsNumberOldHoshoTorokuNo.Remove(lineNotIsNumberOldHoshoTorokuNo.Length - 2) + " 旧保証Noは半角数字で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(lineNotValidLengthHoshoTorokuNo))
            {
                errMsg.AppendLine("行 : " + lineNotValidLengthHoshoTorokuNo.Remove(lineNotValidLengthHoshoTorokuNo.Length - 2) + " 旧保証Noは11桁で入力して下さい。");
            }

            //取下日
            if (!string.IsNullOrEmpty(lineEmptyHoshoTorokuTorisageDt))
            {
                errMsg.AppendLine("行 : " + lineEmptyHoshoTorokuTorisageDt.Remove(lineEmptyHoshoTorokuTorisageDt.Length - 2) + " 必須項目：取下日が入力されていません。");
            }

            if (!string.IsNullOrEmpty(lineNotIsNumberHoshoTorokuTorisageDt))
            {
                errMsg.AppendLine("行 : " + lineNotIsNumberHoshoTorokuTorisageDt.Remove(lineNotIsNumberHoshoTorokuTorisageDt.Length - 2) + " 取下日は半角数字で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(lineNotValidLengthHoshoTorokuTorisageDt))
            {
                errMsg.AppendLine("行 : " + lineNotValidLengthHoshoTorokuTorisageDt.Remove(lineNotValidLengthHoshoTorokuTorisageDt.Length - 2) + " 取下日は8桁で入力して下さい。");
            }

            //新保証No(開始)
            if (string.IsNullOrEmpty(newHoshoTorokuNoFromTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：新保証No(開始)が入力されていません。");
            }

            if (!string.IsNullOrEmpty(newHoshoTorokuNoFromTextBox.Text.Trim()) && newHoshoTorokuNoFromTextBox.Text.Trim().Length != 11)
            {
                errMsg.AppendLine("新保証No(開始)は11桁で入力して下さい。");
            }

            //枚数
            if (string.IsNullOrEmpty(maisuTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：枚数が入力されていません。");
            }

            //Relation check
            if (!string.IsNullOrEmpty(maisuTextBox.Text.Trim()) && oldHoshoTorokuInfoDataGridView.RowCount - 1 != Double.Parse(maisuTextBox.Text.Trim()))
            {
                errMsg.AppendLine("旧保証Noの件数と新保証Noの枚数に差異があります。");
            }

            //Sold check
            if (!string.IsNullOrEmpty(errMsgSoldCheck.ToString()))
            {
                errMsg.AppendLine(errMsgSoldCheck.ToString());
            }

            #endregion

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region CountUpShishoArray
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： CountUpShishoArray
        /// <summary>
        ///
        /// </summary>
        /// <param name="alInput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void CountUpShishoArray(IExChangeBtnClickALInput alInput)
        {
            alInput.IsUpdate = false;
            IExChangeBtnClickALOutput alOutput = new ExChangeBtnClickApplicationLogic().Execute(alInput);
            _hoshoTorokuShinseiKokanInfoDataTable = GetHoshoTorokuShinseiKokanInfo(alOutput.HoshoTorokuShinseiKokanInfoDataTable);

            _errMsgExistCheck = new StringBuilder();

            for (int i = 0; i < oldHoshoTorokuInfoDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = oldHoshoTorokuInfoDataGridView.Rows[i];
                string shishoKbn = row.Cells[HoshoTorokuShishoKbnCol.Name].Value.ToString();
                if (_shishoCdArr.ContainsKey(shishoKbn))
                {
                    _shishoCdArr[shishoKbn] = _shishoCdArr[shishoKbn] + 1;
                }

                decimal newHoshoTorokuNoFrom = Decimal.Parse(newHoshoTorokuNoFromTextBox.Text.Trim());

                object newHoshoTorokuNo = row.Cells[NewHoshoTorokuNoCol.Name].Value = (newHoshoTorokuNoFrom + i).ToString().PadLeft(11, '0');

                //exist check
                if ((_hoshoTorokuShinseiKokanInfoDataTable.Select(string.Format("HoshoTorokuNo = '{0}'", row.Cells[NewHoshoTorokuNoCol.Name].Value.ToString()))).Length == 0)
                {
                    _errMsgExistCheck.AppendLine(string.Format("該当Noの申請書は発行されていません。[新保証No：{0}]", newHoshoTorokuNo));
                }
            }
        }
        #endregion

        #region GetHoshoTorokuShinseiKokanInfo
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetHoshoTorokuShinseiKokanInfo
        /// <summary>
        ///
        /// </summary>
        /// <param name="hoshoTorokuShinseiKokanDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable GetHoshoTorokuShinseiKokanInfo(HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable hoshoTorokuShinseiKokanDT)
        {
            HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable returnDT = new HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable();

            foreach (HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoRow row in hoshoTorokuShinseiKokanDT.Rows)
            {
                row.HoshoTorokuNo = string.Concat(row.HoshoTorokuKensakikan, Utility.DateUtility.ConvertToWareki(row.HoshoTorokuNendo, "yy"), row.HoshoTorokuRenban);
                returnDT.ImportRow(row);
            }

            return returnDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
