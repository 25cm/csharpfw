using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaNippoList;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaNippoListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaNippoListForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;

        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaNippoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaNippoListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaNippoListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaNippoListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaNippoListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetStdControlDomain();

                DoFormLoad();

                SetDefaultValues();
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

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;
                if (this._searchShowFlg) // 検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else // 検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.srhListPanel,
                    this._defaultListPanelTop,
                    this._defaultListPanelHeight);
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

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();
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

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckCondition()) { return; }

                DoSearch();
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

        #region KensaNippoListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaNippoListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void inputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                KensaNippoInputForm frm = new KensaNippoInputForm();
                Program.mForm.MoveNext(frm, FormEnd);
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

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nippoListDataGridView.RowCount == 0) return;

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査日報一覧";
                Common.Common.FlushGridviewDataToExcel(nippoListDataGridView, outputFilename);
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
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region hensyuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hensyuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hensyuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nippoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                KensaNippoInputForm frm = new KensaNippoInputForm(nippoListDataGridView.CurrentRow.Cells["hideKensaDtCol"].Value.ToString(),
                                                                  nippoListDataGridView.CurrentRow.Cells["hideKensainCdCol"].Value.ToString());
                Program.mForm.MoveNext(frm, FormEnd);

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
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nippoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 削除不可チェック
                IDeleteBtnClickALInput checkInput = new DeleteBtnClickALInput();
                checkInput.IsDeleteCheck = true;
                checkInput.NippoKensaDt = nippoListDataGridView.CurrentRow.Cells["hideKensaDtCol"].Value.ToString();
                checkInput.NippoKensainCd = nippoListDataGridView.CurrentRow.Cells["hideKensainCdCol"].Value.ToString();
                IDeleteBtnClickALOutput checkOutput = new DeleteBtnClickApplicationLogic().Execute(checkInput);

                if (!checkOutput.DeleteCheckOutput)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検印済、または、承認済、または、請求済のため、更新できません。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択された日報を削除します。よろしいですか？") != DialogResult.Yes)
                {
                    return;
                }

                IDeleteBtnClickALInput delInput = new DeleteBtnClickALInput();
                delInput.IsDeleteCheck = false;
                delInput.NippoKensaDt = nippoListDataGridView.CurrentRow.Cells["hideKensaDtCol"].Value.ToString();
                delInput.NippoKensainCd = nippoListDataGridView.CurrentRow.Cells["hideKensainCdCol"].Value.ToString();
                IDeleteBtnClickALOutput delOutput = new DeleteBtnClickApplicationLogic().Execute(delInput);

                DoSearch();
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

        #region nippoPrintButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nippoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// 2014/10/22  HuyTX　  Print 039
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nippoPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nippoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                INippoPrintBtnClickALInput alInput = new NippoPrintBtnClickALInput();
                alInput.NippoKensaDt = nippoListDataGridView.CurrentRow.Cells[hideKensaDtCol.Name].Value.ToString();
                alInput.NippoKensainCd = nippoListDataGridView.CurrentRow.Cells[hideKensainCdCol.Name].Value.ToString();

                new NippoPrintBtnClickApplicationLogic().Execute(alInput);

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

        #region KensaNippoListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaNippoListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaNippoListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        inputButton.Focus();
                        inputButton.PerformClick();
                        break;

                    case Keys.F2:
                        hensyuButton.PerformClick();
                        hensyuButton.Focus();
                        break;

                    case Keys.F3:
                        deleteButton.PerformClick();
                        deleteButton.Focus();
                        break;

                    case Keys.F5:
                        nippoPrintButton.Focus();
                        nippoPrintButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;

                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
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

        #region kensaDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaDtUseCheckBox.Checked)
                {
                    // 検査日（開始）
                    kensaDtFromDateTimePicker.Enabled = true;

                    // 検査日（終了）
                    kensaDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    // 検査日（開始）
                    kensaDtFromDateTimePicker.Enabled = false;

                    // 検査日（終了）
                    kensaDtToDateTimePicker.Enabled = false;
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

        #region nippoListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nippoListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nippoListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                KensaNippoInputForm frm = new KensaNippoInputForm(nippoListDataGridView.CurrentRow.Cells["hideKensaDtCol"].Value.ToString(),
                                                                  nippoListDataGridView.CurrentRow.Cells["hideKensainCdCol"].Value.ToString());
                //結合20141227 グリッドのセルダブルクリックは、編集ボタンと同じ動作にする。
				//Program.mForm.MoveNext(frm);
				Program.mForm.MoveNext(frm, FormEnd);
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

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
			//結合20141227
			//// 子画面が正常終了した場合
			//if (childForm.DialogResult == DialogResult.OK)
			//{
                kensakuButton.PerformClick();
			//}
        }
        #endregion

        #region kensaDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　PhuongDT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaDtToDateTimePicker.Value = kensaDtFromDateTimePicker.Value;
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
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShokuinKensainFlg = "1";
            alInput.ShokuinTaishokuFlg = "0";
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検査員
            Utility.Utility.SetComboBoxList(kensainComboBox, alOutput.ShokuinMstDT, "ShokuinNm", "ShokuinCd", true);
            
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;
        }
        #endregion

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 検査員
            kensainComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

            // 検査日検索使用フラグ
            kensaDtUseCheckBox.Checked = false;

            // 検査日（開始）
            kensaDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            kensaDtFromDateTimePicker.Enabled = false;

            // 検査日（終了）
            kensaDtToDateTimePicker.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            kensaDtToDateTimePicker.Enabled = false;

            // 対象区分/検査完了分
            nippoKanryoRadioButton.Checked = true;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            nippoHdrTblDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // 職員コード
            if (kensainComboBox.SelectedValue != null)
            {
                alInput.ShokuinCd = kensainComboBox.SelectedValue.ToString();
            }

            // 検査日検索使用フラグ
            alInput.KensaDtUse = kensaDtUseCheckBox.Checked;

            // 検査日（開始）
            alInput.KensaDtFrom = kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査日（終了）
            alInput.KensaDtTo = kensaDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 対象区分
            if (nippoKanryoRadioButton.Checked)
            {
                alInput.Taishokbn = "1";
            }
            else if (nippoFukuKaChoRadioButton.Checked)
            {
                alInput.Taishokbn = "2";
            }
            else if (nippoKaChoRadioButton.Checked)
            {
                alInput.Taishokbn = "3";
            }

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            nippoHdrTblDataSet.Merge(alOutput.KensaNippoListDT);

            if (alOutput.KensaNippoListDT == null || alOutput.KensaNippoListDT.Count == 0)
            {
                srhListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                srhListCountLabel.Text = alOutput.KensaNippoListDT.Count.ToString() + "件";
            }
        }
        #endregion

        #region CheckCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            if (kensaDtUseCheckBox.Checked)
            {
                if (kensaDtFromDateTimePicker.Value > kensaDtToDateTimePicker.Value)
                {
                    errMess.Append("範囲指定が正しくありません。検査日の大小関係を確認してください。");
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

        #region SetStdControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // 行
            nippoListDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 検査日
            nippoListDataGridView.SetStdControlDomain(kensaDtCol.Index, ZControlDomain.ZG_STD_NAME, 8);

            // 検査員
            nippoListDataGridView.SetStdControlDomain(kensainCol.Index, ZControlDomain.ZG_STD_NAME, 20);

            // 検査日（隠し）
            nippoListDataGridView.SetStdControlDomain(hideKensaDtCol.Index, ZControlDomain.ZG_STD_NAME, 8);

            // 検査員（隠し）
            nippoListDataGridView.SetStdControlDomain(hideKensainCdCol.Index, ZControlDomain.ZG_STD_NAME, 20);

            // 走行距離(km)
            //nippoListDataGridView.SetStdControlDomain(sokoKyoriCol.Index, ZControlDomain.ZG_STD_NUM, 

            // 給油(ℓ)
            //nippoListDataGridView.SetStdControlDomain(kyuyuCol.Index, ZControlDomain.ZG_STD_NUM, 

            // 車両点検記録
            nippoListDataGridView.SetStdControlDomain(tenkenKirokuCol.Index, ZControlDomain.ZG_STD_NAME, 40);

            // 実地調査件数
            nippoListDataGridView.SetStdControlDomain(jittiCntCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 超過原因確認件数
            nippoListDataGridView.SetStdControlDomain(chokaCntCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // クロスチェック件数
            nippoListDataGridView.SetStdControlDomain(crossChkCntCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 検査員報告
            nippoListDataGridView.SetStdControlDomain(kensainHokokuCol.Index, ZControlDomain.ZG_STD_NAME, 100);

            // 管理者指示
            nippoListDataGridView.SetStdControlDomain(kanrisyaShijiCol.Index, ZControlDomain.ZG_STD_NAME, 100);

            // 検査完了
            nippoListDataGridView.SetStdControlDomain(kensaKanryoCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);

            // 副課長確認
            nippoListDataGridView.SetStdControlDomain(fukuKachoKakuninCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);

            // 課長確認
            nippoListDataGridView.SetStdControlDomain(kachoKakuninCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);
        }
        #endregion

        #endregion
    }
    #endregion

}
