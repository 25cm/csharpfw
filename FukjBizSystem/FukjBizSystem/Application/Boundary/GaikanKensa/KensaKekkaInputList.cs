using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaKekkaInputList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKekkaInputListForm : FukjBaseForm
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

        /// <summary>
        /// ShokuinMstDT
        /// </summary>
        private ShokuinMstDataSet.ShokuinMstDataTable _shokuinMstDT;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKekkaInputListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKekkaInputListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaKekkaInputListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaInputListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaInputListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

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
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void viewChangeButton_Click(object sender, EventArgs e)
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
        /// 2014/09/05  DatNT　  新規作成
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
        /// 2014/09/05  DatNT　  新規作成
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

        #region inputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： inputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void inputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jissiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                KensaKekkaInputShosaiForm frm = new KensaKekkaInputShosaiForm(jissiListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString(),
                                                                                jissiListDataGridView.CurrentRow.Cells[hokenjoCdCol.Name].Value.ToString(),
                                                                                jissiListDataGridView.CurrentRow.Cells[nendoCol.Name].Value.ToString(),
                                                                                jissiListDataGridView.CurrentRow.Cells[renbanCol.Name].Value.ToString(),
                                                                                jissiListDataGridView.CurrentRow.Cells[KensaKekkaMochikomiDtCol.Name].Value.ToString());
                //Program.mForm.MoveNext(frm);
                frm.ShowDialog();
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

        #region jissiListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jissiListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jissiListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                if (jissiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 2014/10/31 AnhNV ADD Start
                // 検査種別（隠し）
                string hoteiKbn = jissiListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value == null ?
                    string.Empty : jissiListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
                // 保健所コード（隠し）
                string hokenjoCd = jissiListDataGridView.CurrentRow.Cells[hokenjoCdCol.Name].Value == null ?
                    string.Empty : jissiListDataGridView.CurrentRow.Cells[hokenjoCdCol.Name].Value.ToString();
                // 年度（隠し）
                string nendo = jissiListDataGridView.CurrentRow.Cells[nendoCol.Name].Value == null ?
                    string.Empty : jissiListDataGridView.CurrentRow.Cells[nendoCol.Name].Value.ToString();
                // 連番（隠し）
                string renban = jissiListDataGridView.CurrentRow.Cells[renbanCol.Name].Value == null ?
                    string.Empty : jissiListDataGridView.CurrentRow.Cells[renbanCol.Name].Value.ToString();
                // 水質検査持込日付(hidden)
                string mochikomiDt = jissiListDataGridView.CurrentRow.Cells[KensaKekkaMochikomiDtCol.Name].Value == null ?
                    string.Empty : jissiListDataGridView.CurrentRow.Cells[KensaKekkaMochikomiDtCol.Name].Value.ToString();

                // Open 009-005 Shosai
                KensaKekkaInputShosaiForm frm = new KensaKekkaInputShosaiForm(hoteiKbn, hokenjoCd, nendo, renban, mochikomiDt);
                frm.ShowDialog();
                // 2014/10/31 AnhNV ADD End
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

        #region kekkasyoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kekkasyoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kekkasyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jissiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                //Mod_20141105_HuyTX Start
                //KiansyaSelectForm frm = new KiansyaSelectForm(jissiListDataGridView.CurrentRow.Cells["KensaIraiHoteiKbnCol"].Value.ToString(),
                //                                                jissiListDataGridView.CurrentRow.Cells["KensaIraiHokenjoCdCol"].Value.ToString(),
                //                                                jissiListDataGridView.CurrentRow.Cells["KensaIraiNendoCol"].Value.ToString(),
                //                                                jissiListDataGridView.CurrentRow.Cells["KensaIraiRenbanCol"].Value.ToString());
                //frm.ShowDialog();

                string hoteiKbn = jissiListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
                string hokenjoCd = jissiListDataGridView.CurrentRow.Cells[hokenjoCdCol.Name].Value.ToString();
                string nendo = jissiListDataGridView.CurrentRow.Cells[nendoCol.Name].Value.ToString();
                string renban = jissiListDataGridView.CurrentRow.Cells[renbanCol.Name].Value.ToString();

                // 2015.01.09 toyoda Modify Start 処理失敗を通知する
                //// TODO 20141111 habu HotFix
                //Utility.KekkashoUtility.KekkashoOutput(hoteiKbn, hokenjoCd, nendo, renban, 0, 0, 1, 0);
                ////Utility.KekkashoUtility.KekkashoOutput(hoteiKbn, hokenjoCd, nendo, renban, 0, 0);
                ////Mod_20141105_HuyTX End
                int result = 0;
                result = Utility.KekkashoUtility.KekkashoOutput(hoteiKbn, hokenjoCd, nendo, renban, 0, 0, 1, 0);

                switch (result)
                {
                    case 2:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "対象のデータが見つかりません。");
                        break;
                    case 3:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                        break;
                    case 4:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが存在しません。システム管理者に連絡してください。");
                        break;
                    case 9:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "結果書作成に失敗しました。システム管理者に連絡してください。");
                        break;
                    default:
                        break;
                }
                // 2015.01.09 toyoda Modify End
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

        #region kensaRirekiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaRirekiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaRirekiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jissiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string jokasouNo = jissiListDataGridView.CurrentRow.Cells[jokasoHokenjoCdCol.Name].Value.ToString() + "-"
                                    + Common.Common.ConvertToHoshouNendoWareki(jissiListDataGridView.CurrentRow.Cells[jokasoNendoCol.Name].Value.ToString()) + "-"
                                    + jissiListDataGridView.CurrentRow.Cells[jokasoRenbanCol.Name].Value.ToString();

                KensaRirekiForm frm = new KensaRirekiForm(jokasouNo);
                //Program.mForm.ShowForm(frm);
                Program.mForm.MoveNext(frm);
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
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jissiListDataGridView.RowCount == 0) return;

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査実施一覧";
                Common.Common.FlushGridviewDataToExcel(jissiListDataGridView, outputFilename);
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
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //GaikanKensaMenuForm frm = new GaikanKensaMenuForm();
                //Program.mForm.ShowForm(frm);
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
        /// 2014/09/05  DatNT　  新規作成
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
                    kensaDtFromDateTimePicker.Enabled = true;
                    kensaDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    kensaDtFromDateTimePicker.Enabled = false;
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

        #region KensaKekkaInputListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaInputListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaInputListForm_KeyDown(object sender, KeyEventArgs e)
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
                        kekkasyoButton.Focus();
                        kekkasyoButton.PerformClick();
                        break;

                    case Keys.F3:
                        kensaRirekiButton.Focus();
                        kensaRirekiButton.PerformClick();
                        break;

                    case Keys.F4:
                        genkinNyukinButton.Focus();
                        genkinNyukinButton.PerformClick();
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

        #region jissiListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jissiListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jissiListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetCellBGColor();
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

        #region ninsoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ninsoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ninsoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(ninsoFromTextBox.Text))
                {
                    //ninsoFromTextBox.Text = Convert.ToInt32(ninsoFromTextBox.Text).ToString();
                    ninsoToTextBox.Text = ninsoFromTextBox.Text;
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

        #region ninsoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ninsoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ninsoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(ninsoToTextBox.Text))
                {
                    ninsoToTextBox.Text = Convert.ToInt32(ninsoToTextBox.Text).ToString();
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

        #region genkinNyukinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： genkinNyukinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/08  DatNT　   V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void genkinNyukinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jissiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }
                string kensaKbn = "1";
                string kensaIraiHoteiKbn = jissiListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();

                string kensaIraiHokenjoCd = jissiListDataGridView.CurrentRow.Cells[hokenjoCdCol.Name].Value.ToString();

                string kensaIraiNendo = jissiListDataGridView.CurrentRow.Cells[nendoCol.Name].Value.ToString();

                string kensaIraiRenban = jissiListDataGridView.CurrentRow.Cells[renbanCol.Name].Value.ToString();

                GenkinNyukinForm frm = new GenkinNyukinForm(kensaKbn, kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban);
                
                Program.mForm.MoveNext(frm);
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

        #region kyokaiFrom1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text))
                {
                    kyokaiFrom1TextBox.Text = kyokaiFrom1TextBox.Text.PadLeft(2, '0');
                    kyokaiTo1TextBox.Text = kyokaiFrom1TextBox.Text;
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

        #region kyokaiFrom2TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom2TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text))
                {
                    kyokaiFrom2TextBox.Text = kyokaiFrom2TextBox.Text.PadLeft(2, '0');
                    kyokaiTo2TextBox.Text = kyokaiFrom2TextBox.Text;
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

        #region kyokaiFrom3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text))
                {
                    kyokaiFrom3TextBox.Text = kyokaiFrom3TextBox.Text.PadLeft(6, '0');
                    kyokaiTo3TextBox.Text = kyokaiFrom3TextBox.Text;
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

        #region kyokaiTo1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text))
                {
                    kyokaiTo1TextBox.Text = kyokaiTo1TextBox.Text.PadLeft(2, '0');
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

        #region kyokaiFrom1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text))
                {
                    kyokaiTo2TextBox.Text = kyokaiTo2TextBox.Text.PadLeft(2, '0');
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

        #region kyokaiTo3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text))
                {
                    kyokaiTo3TextBox.Text = kyokaiTo3TextBox.Text.PadLeft(6, '0');
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

        #region settisyaKanaFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： settisyaKanaFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  HuyTX　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void settisyaKanaFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(settisyaKanaFromTextBox.Text.Trim()))
                {
                    settisyaKanaToTextBox.Text = settisyaKanaFromTextBox.Text;
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

        #region gyosyaSrhButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaSrhButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/14  AnhNV　   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaSrhButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (null != frm._selectedRow)
                    {
                        gyosyaTextBox.Text = frm._selectedRow.GyoshaNm;
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
        /// 2014/09/05  DatNT　  新規作成
        /// 2015/01/14  AnhNV　  v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            kensaKekkaTblDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShokuinKensainFlg = "1";
            alInput.ShokuinTaishokuFlg = "0";//2015.01.29 add kiyokuni
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            _shokuinMstDT = alOutput.ShokuinMstDataTable;

            // 検査員
            Utility.Utility.SetComboBoxList(kensainComboBox, alOutput.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", true);

            // 2015/01/14 AnhNV ADD Start
            Utility.Utility.SetComboBoxList(shikuchosonComboBox, alOutput.ShikuchosonInfoDataTable, "ChikuNm", "ChikuCd", true);
            // 2015/01/14 AnhNV ADD End

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;
        }
        #endregion

        #region MakeSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alInput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03  DatNT　  新規作成
        /// 2014/10/08  DatNT    v1.01
        /// 2015/01/14  AnhNV    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            KensaKekkaInputListSearchCond searchCond = new KensaKekkaInputListSearchCond();

            // 検査員
            if (kensainComboBox.SelectedValue != null)
            {
                searchCond.ShokuinCd = kensainComboBox.SelectedValue.ToString();
            }

            // 検査種別
            if (kensaAllRadioButton.Checked)
            {
                searchCond.KensaIraiHoteiKbn = "0";
            }
            else if (kensa7JoRadioButton.Checked)
            {
                searchCond.KensaIraiHoteiKbn = "1";
            }
            else if (kensa11JoRadioButton.Checked)
            {
                searchCond.KensaIraiHoteiKbn = "2";
            }

            searchCond.HokenjoCdFrom = kyokaiFrom1TextBox.Text.Trim();
            searchCond.NendoFrom = kyokaiFrom2TextBox.Text.Trim();
            searchCond.RenbanFrom = kyokaiFrom3TextBox.Text.Trim();
            searchCond.HokenjoCdTo = kyokaiTo1TextBox.Text.Trim();
            searchCond.NendoTo = kyokaiTo2TextBox.Text.Trim();
            searchCond.RenbanTo = kyokaiTo3TextBox.Text.Trim();

            // 検査日検索使用フラグ
            searchCond.KensaYoteiDtUse = kensaDtUseCheckBox.Checked;

            // 検査日（開始）
            searchCond.KensaDtFrom = kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査日（終了）
            searchCond.KensaDtTo = kensaDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 設置住所
            searchCond.SettiAdr = settiAdrTextBox.Text.Trim();

            // 設置者カナ（開始）
            searchCond.SettisyaKanaFrom = settisyaKanaFromTextBox.Text.Trim();

            // 設置者カナ（終了）
            searchCond.SettisyaKanaTo = settisyaKanaToTextBox.Text.Trim();

            // 人槽（開始）
            searchCond.NinsoFrom = ninsoFromTextBox.Text;

            // 人槽（終了）
            searchCond.NinsoTo = ninsoToTextBox.Text;

            // 2014/10/08 DatNT v1.01 DEL Start
            //// 対象物件
            //if (bukkenMikanryoRadioButton.Checked)
            //{
            //    searchCond.TaishoBukken = "1";
            //}
            //else if (bukkenAllRadioButton.Checked)
            //{
            //    searchCond.TaishoBukken = "2";
            //}
            //else if (bukkenHoryuRadioButton.Checked)
            //{
            //    searchCond.TaishoBukken = "3";
            //}
            //else if (bukkenMikensaRadioButton.Checked)
            //{
            //    searchCond.TaishoBukken = "4";
            //}
            // 2014/10/08 DatNT v1.01 DEL End

            // 2015/01/14 AnhNV ADD Start
            searchCond.GyoshaNm = gyosyaTextBox.Text;
            searchCond.KensaIraiGenChikuCd = Convert.ToString(shikuchosonComboBox.SelectedValue);
            // 2015/01/14 AnhNV ADD End

            alInput.SearchCond = searchCond;
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
        /// 2014/09/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            kensaKekkaTblDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            //kensaKekkaTblDataSet.Merge(DispData(alOutput.KensaKekkaInputListDT));
            kensaKekkaTblDataSet.Merge(alOutput.KensaKekkaInputListDT);

            if (alOutput.KensaKekkaInputListDT == null || alOutput.KensaKekkaInputListDT.Count == 0)
            {
                srhListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                srhListCountLabel.Text = alOutput.KensaKekkaInputListDT.Count.ToString() + "件";
            }

            SetCellBGColor();
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
        /// 2014/09/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            //bool flg = true;

            // 協会No（開始）
            if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) && kyokaiFrom1TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（開始）(保健所コード)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) && kyokaiFrom2TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（開始） (年度)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) && kyokaiFrom3TextBox.Text.Length != 6)
            {
                errMess.AppendLine("協会No（開始） (連番)は6桁で入力して下さい。");
                //flg = false;
            }

            // 協会No（終了）
            if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text) && kyokaiTo1TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（終了） (保健所コード)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text) && kyokaiTo2TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（終了） (年度)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text) && kyokaiTo3TextBox.Text.Length != 6)
            {
                errMess.AppendLine("協会No（終了） (連番)は6桁で入力して下さい。");
                //flg = false;
            }

            //協会No（開始＆終了）
            // 2014/10/27 AnhNV UPD start
            if (!Utility.Utility.IsValidKyokaiNo(kyokaiFrom1TextBox, kyokaiFrom2TextBox, kyokaiFrom3TextBox, kyokaiTo1TextBox, kyokaiTo2TextBox, kyokaiTo3TextBox))
            {
                errMess.AppendLine("範囲指定が正しくありません。検査番号の大小関係を確認してください。");
            }
            // 2014/10/27 AnhNV UPD end

            //20150128 PhuongDT Add
            if (kensaDtUseCheckBox.Checked
                && kensaDtFromDateTimePicker.Value > kensaDtToDateTimePicker.Value)
            {
                errMess.AppendLine("範囲指定が正しくありません。検査日の大小関係を確認してください。");
            }
            //End

            // 2014/10/27 AnhNV DEL start
            //if (flg
            //    && !string.IsNullOrEmpty(kyokaiFrom1TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiFrom2TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiFrom3TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiTo1TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiTo2TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiTo3TextBox.Text))
            //{
            //    if (Convert.ToDecimal(kyokaiFrom1TextBox.Text + kyokaiFrom2TextBox.Text + kyokaiFrom3TextBox.Text)
            //        > Convert.ToDecimal(kyokaiTo1TextBox.Text + kyokaiTo2TextBox.Text + kyokaiTo3TextBox.Text))
            //    {
            //        errMess.Append("範囲指定が正しくありません。協会Noの大小関係を確認してください。\r\n");
            //    }
            //}
            // 2014/10/27 AnhNV DEL end

            // 設置者カナ（開始＆終了）
            if (!string.IsNullOrEmpty(settisyaKanaFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(settisyaKanaToTextBox.Text.Trim()))
            {
                if (string.Compare(settisyaKanaFromTextBox.Text.Trim(), settisyaKanaToTextBox.Text.Trim()) > 0)
                {
                    errMess.Append("範囲指定が正しくありません。設置者カナの大小関係を確認してください。\r\n");
                }
            }

            // 人槽（開始＆終了）
            if (!string.IsNullOrEmpty(ninsoFromTextBox.Text) && !string.IsNullOrEmpty(ninsoToTextBox.Text))
            {
                if (Convert.ToInt32(ninsoFromTextBox.Text) > Convert.ToInt32(ninsoToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。人槽の大小関係を確認してください。\r\n");
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

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  DatNT　  新規作成
        /// 2014/10/08  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 検査員
            bool flg = true;
            foreach (ShokuinMstDataSet.ShokuinMstRow row in _shokuinMstDT)
            {
                if (row.ShokuinCd == Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd)
                {
                    flg = true;
                }
            }
            if (flg)
            {
                kensainComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;
            }
            else
            {
                kensainComboBox.SelectedIndex = -1;
            }

            // 検査種別/全て
            kensaAllRadioButton.Checked = true;

            // 協会No（開始） (保健所コード)
            kyokaiFrom1TextBox.Clear();

            // 協会No（開始） (年度)
            kyokaiFrom2TextBox.Clear();

            // 協会No（開始） (連番)
            kyokaiFrom3TextBox.Clear();

            // 協会No（終了） (保健所コード)
            kyokaiTo1TextBox.Clear();

            // 協会No（終了） (年度)
            kyokaiTo2TextBox.Clear();

            // 協会No（終了） (連番)
            kyokaiTo3TextBox.Clear();

            // 検査日検索使用フラグ
            kensaDtUseCheckBox.Checked = false;

            // 検査日（開始）
            kensaDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            kensaDtFromDateTimePicker.Enabled = false;

            // 検査日（終了）
            kensaDtToDateTimePicker.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            kensaDtToDateTimePicker.Enabled = false;

            // 設置住所
            settiAdrTextBox.Clear();

            // 設置者カナ（開始）
            settisyaKanaFromTextBox.Clear();

            // 設置者カナ（終了）
            settisyaKanaToTextBox.Clear();

            // 人槽（開始）
            ninsoFromTextBox.Clear();

            // 人槽（終了）
            ninsoToTextBox.Clear();

            // 2014/10/08 DatNT v1.01 DEL Start
            // 対象物件/検査未完了のみ
            //bukkenMikanryoRadioButton.Checked = true;
            // 2014/10/08 DatNT v1.01 DEL End

            // 2015/01/14 AnhNV ADD Start
            // 市区町村
            shikuchosonComboBox.SelectedIndex = 0;
            // 依頼業者(55)
            gyosyaTextBox.Text = string.Empty;
            // 2015/01/14 AnhNV ADD End
        }
        #endregion

        #region SetCellBGColor
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetCellBG
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetCellBGColor()
        {
            foreach (DataGridViewRow row in jissiListDataGridView.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[hanteiCol.Name].Value.ToString()))
                {
                    row.Cells[hanteiCol.Name].Style.BackColor = Color.Red;
                }

                if (!string.IsNullOrEmpty(row.Cells[bodCol.Name].Value.ToString()))
                {
                    row.Cells[bodCol.Name].Style.BackColor = Color.Red;
                }

                if (!string.IsNullOrEmpty(row.Cells[ensoCol.Name].Value.ToString()))
                {
                    row.Cells[ensoCol.Name].Style.BackColor = Color.Red;
                }
            }
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 検査番号（開始） (保健所コード)
            kyokaiFrom1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（開始） (年度)
            kyokaiFrom2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（開始） (連番)
            kyokaiFrom3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            // 検査番号（終了） (保健所コード)
            kyokaiTo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（終了） (年度)
            kyokaiTo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（終了） (連番)
            kyokaiTo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            //ADD_20141104_HuyTX Start
            settiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            settisyaKanaFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
            settisyaKanaToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
            ninsoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);
            ninsoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);
            gyosyaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            //set control domain for GridView
            jissiListDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            jissiListDataGridView.SetStdControlDomain(kensaSyubetsuCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            jissiListDataGridView.SetStdControlDomain(yoteiDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            jissiListDataGridView.SetStdControlDomain(kyokaiNoCol.Index, ZControlDomain.ZG_STD_NAME, 12, DataGridViewContentAlignment.MiddleCenter);
            jissiListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            jissiListDataGridView.SetStdControlDomain(settiBasyoCol.Index, ZControlDomain.ZG_STD_NAME, 80);
            jissiListDataGridView.SetStdControlDomain(ninsoCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            jissiListDataGridView.SetStdControlDomain(syoriHoshikiCol.Index, ZControlDomain.ZG_STD_NAME, 14);
            jissiListDataGridView.SetStdControlDomain(hanteiCol.Index, ZControlDomain.ZG_STD_NAME, 20, DataGridViewContentAlignment.MiddleCenter);
            jissiListDataGridView.SetStdControlDomain(bodCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            jissiListDataGridView.SetStdControlDomain(ensoCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            jissiListDataGridView.SetStdControlDomain(horyuDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);

            //ADD_20141104_HuyTX End
        }
        #endregion

        #region DEL_20141118
        //#region DispData
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： DispData
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/17  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaKekkaTblDataSet.KensaKekkaInputListDataTable DispData(KensaKekkaTblDataSet.KensaKekkaInputListDataTable dataTable)
        //{
        //    KensaKekkaTblDataSet.KensaKekkaInputListDataTable dispDT = new KensaKekkaTblDataSet.KensaKekkaInputListDataTable();

        //    foreach (KensaKekkaTblDataSet.KensaKekkaInputListRow row in dataTable.Rows)
        //    {
        //        row.kyokaiNoCol = row.KensaIraiHokenjoCd + "-"
        //                            + Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy") + "-"
        //                            + row.KensaIraiRenban;

        //        dispDT.ImportRow(row);
        //    }

        //    return dispDT;
        //}
        //#endregion
        #endregion

        #endregion
    }
    #endregion
}
