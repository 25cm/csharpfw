using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.JyukoshaInput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JyukoshaInputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JyukoshaInputForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// saisuiinInfoListDT
        /// </summary>
        private SaisuiinMstDataSet.SaisuiinInfoListDataTable _saisuiinInfoListDT = new SaisuiinMstDataSet.SaisuiinInfoListDataTable();

        /// <summary>
        /// isLoad
        /// </summary>
        private bool _isLoad = false;

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JyukoshaInputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JyukoshaInputForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region JyukoshaInputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JyukoshaInputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JyukoshaInputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kaisaibiDateTimePicker.Value = _currentDateTime;

                SetValueYukokigenDate();

                IFormLoadALInput alInput = new FormLoadALInput();
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

                _saisuiinInfoListDT = alOutput.SaisuiinInfoListDT;

                _isLoad = true;

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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidInput()) return;

                IEntryBtnClickALInput alInput = new EntryBtnClickALInput();

                alInput.JyukoshaListDataGridView = jyukoshaListDataGridView;
                alInput.Kaisaibi = kaisaibiDateTimePicker.Value.ToString("yyyyMMdd");
                alInput.YukokigenDt = yukokigenDateTimePicker.Value.ToString("yyyyMMdd");

                new EntryBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jyukoshaListDataGridView.RowCount > 1 && MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes) return;

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

        #region jyukoshaListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jyukoshaListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jyukoshaListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string saisuiinNm = string.Empty;
                string gyoshaNm = string.Empty;
                DateTime updateDt = new DateTime();

                if (!_isLoad) return;

                string saisuiinCd = (jyukoshaListDataGridView.Rows[e.RowIndex].Cells[SaisuiinCdCol.Name].Value == null) ? "" : jyukoshaListDataGridView.Rows[e.RowIndex].Cells[SaisuiinCdCol.Name].Value.ToString().Trim();

                //if (!Utility.Utility.IsDecimal(saisuiinCd)) { return; }

                foreach (SaisuiinMstDataSet.SaisuiinInfoListRow row in _saisuiinInfoListDT.Select(string.Format("SaisuiinCd = '{0}'", saisuiinCd)))
                {
                    saisuiinNm = row.SaisuiinNm;
                    gyoshaNm = row.GyoshaNm;
                    updateDt = row.UpdateDt;
                }

                if (string.IsNullOrEmpty(saisuiinNm) && saisuiinCd.Length == 5)
                {
                    jyukoshaListDataGridView.Rows[e.RowIndex].Cells[SaisuiinCdCol.Name].Value = string.Empty;
                }

                jyukoshaListDataGridView.Rows[e.RowIndex].Cells[SaisuiinNmCol.Name].Value = saisuiinNm;
                jyukoshaListDataGridView.Rows[e.RowIndex].Cells[SyozokuGyosyaNmCol.Name].Value = gyoshaNm;
                jyukoshaListDataGridView.Rows[e.RowIndex].Cells[UpdateDtCol.Name].Value = updateDt;

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

        #region kaisaibiDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaisaibiDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaisaibiDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetValueYukokigenDate();
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

        #region JyukoshaInputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JyukoshaInputForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JyukoshaInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        entryButton.PerformClick();
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

        #region jyukoshaListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jyukoshaListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14　AnhNV    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jyukoshaListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Prevent from input non-integer value to datagridview cells
                if (jyukoshaListDataGridView.CurrentCell.ColumnIndex == 0)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(jyukoshaListDataGridView_ControlKeyPress);
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

        #region IsValidInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidInput()
        {
            StringBuilder errMsg = new StringBuilder();
            bool isEmptySaisuiinCd = true; ;
            string lineIncorrectSaisuiinCd = string.Empty;
            string lineNotValidSaisuiinCd = string.Empty;

            for (int i = 0; i < jyukoshaListDataGridView.RowCount - 1; i++)
            {
                string saisuiinCd = jyukoshaListDataGridView.Rows[i].Cells[SaisuiinCdCol.Name].Value != null ? jyukoshaListDataGridView.Rows[i].Cells[SaisuiinCdCol.Name].Value.ToString().Trim() : string.Empty;

                if (!string.IsNullOrEmpty(saisuiinCd))
                {
                    isEmptySaisuiinCd = false;

                    if (!Utility.Utility.IsDecimal(saisuiinCd))
                    {
                        lineIncorrectSaisuiinCd += (i + 1) + ", ";
                    }
                    else if (saisuiinCd.Length != 5)
                    {
                        lineNotValidSaisuiinCd += (i + 1) + ", ";
                    }

                }
            }

            if (isEmptySaisuiinCd)
            {
                errMsg.AppendLine("必須項目：採水員コードが入力されていません。");
            }

            if (!string.IsNullOrEmpty(lineIncorrectSaisuiinCd))
            {
                errMsg.AppendLine("行 : " + lineIncorrectSaisuiinCd.Remove(lineIncorrectSaisuiinCd.Length - 2) + " : 採水員コードは半角数字で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(lineNotValidSaisuiinCd))
            {
                errMsg.AppendLine("行 : " + lineNotValidSaisuiinCd.Remove(lineNotValidSaisuiinCd.Length - 2) + " : 採水員コードは5桁で入力して下さい。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetValueYukokigenDate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetValueYukokigenDate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValueYukokigenDate()
        {
            int kaisaibi = Int32.Parse(kaisaibiDateTimePicker.Value.ToString("MMdd"));

            yukokigenDateTimePicker.Value = (kaisaibi > 331) ? DateTime.Parse(kaisaibiDateTimePicker.Value.AddYears(4).Year.ToString() + "/03/31") : DateTime.Parse(kaisaibiDateTimePicker.Value.AddYears(3).Year.ToString() + "/03/31");
        }
        #endregion

        #region jyukoshaListDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： jyukoshaListDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jyukoshaListDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (jyukoshaListDataGridView.CurrentCell.ColumnIndex == 0)
            {
                e.Handled = !IsOKForDecimalTextBox(e.KeyChar, sender as TextBox) ? true : false;
            }
        }
        #endregion

        #region IsOKForDecimalTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsOKForDecimalTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="textBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/14　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsOKForDecimalTextBox(char character, TextBox textBox)
        {
            if (!char.IsControl(character)
                && !char.IsDigit(character))
            {
                return false;
            }

            return true;
        }
        #endregion

        #endregion

    }
    #endregion
}
