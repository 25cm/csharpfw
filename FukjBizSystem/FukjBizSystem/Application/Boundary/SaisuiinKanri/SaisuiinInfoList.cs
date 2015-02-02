using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.SaisuiinInfoList;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SaisuiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaisuiinInfoList
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SaisuiinInfoListForm : FukjBaseForm
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
        //  コンストラクタ名 ： SaisuiinInfoList
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaisuiinInfoListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SaisuiinInfoList_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinInfoList_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinInfoList_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();

                DoFormLoad();
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
        /// 2014/07/24  DatNT　  新規作成
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
                    this.ViewChangeButton.Text = "▲";
                }
                else // 検索条件を閉じる
                {
                    this.ViewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.saisuiinKanriListPanel,
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

        #region ClearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ClearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearButton_Click(object sender, EventArgs e)
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

        #region KensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensakuButton_Click(object sender, EventArgs e)
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

        #region TorokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TorokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TorokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SaisuiinInfoShosaiForm frm = new SaisuiinInfoShosaiForm();
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

        #region ShosaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ShosaiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (saisuiinKanriListDataGridView.RowCount == 0) 
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return; 
                }

                SaisuiinInfoShosaiForm frm = new SaisuiinInfoShosaiForm(saisuiinKanriListDataGridView.CurrentRow.Cells["SaisuiinCdCol"].Value.ToString());
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

        #region OutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： OutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void OutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (saisuiinKanriListDataGridView.RowCount == 0) { return; }

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "採水員情報一覧";
                Common.Common.FlushGridviewDataToExcel(this.saisuiinKanriListDataGridView, outputFilename);
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

        #region TojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //SaisuiinMenuForm frm = new SaisuiinMenuForm();
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

        #region SaisuiinInfoList_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SaisuiinInfoList_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SaisuiinInfoList_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        TorokuButton.Focus();
                        TorokuButton.PerformClick();
                        break;

                    case Keys.F2:
                        ShosaiButton.Focus();
                        ShosaiButton.PerformClick();
                        break;

                    case Keys.F6:
                        OutputButton.Focus();
                        OutputButton.PerformClick();
                        break;

                    case Keys.F7:
                        ClearButton.Focus();
                        ClearButton.PerformClick();
                        break;

                    case Keys.F8:
                        KensakuButton.Focus();
                        KensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                        TojiruButton.Focus();
                        TojiruButton.PerformClick();
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

        #region AddConditionsFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： AddConditionsFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void AddConditionsFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (addConditionsFlgCheckBox.Checked == true)
                {
                    jukoDtFromDateTimePicker.Enabled = true;
                    jukoDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    jukoDtFromDateTimePicker.Enabled = false;
                    jukoDtToDateTimePicker.Enabled = false;
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

        #region gyoshaFromSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaFromSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaFromSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    syozokuGyosyaCdFromTextBox.Text = frm._selectedRow.GyoshaCd;

                    gyoshaNmFromTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region gyoshaToSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaToSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaToSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    syozokuGyosyaCdToTextBox.Text = frm._selectedRow.GyoshaCd;

                    gyoshaNmToTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region saisuiinKanriListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinKanriListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinKanriListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                SaisuiinInfoShosaiForm frm = new SaisuiinInfoShosaiForm(saisuiinKanriListDataGridView.CurrentRow.Cells["SaisuiinCdCol"].Value.ToString());
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

        #region saisuiinCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text))
                {
                    saisuiinCdFromTextBox.Text = saisuiinCdFromTextBox.Text.PadLeft(5, '0');
                    saisuiinCdToTextBox.Text = saisuiinCdFromTextBox.Text;
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

        #region saisuiinCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text))
                {
                    saisuiinCdToTextBox.Text = saisuiinCdToTextBox.Text.PadLeft(5, '0');
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

        #region jukoDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jukoDtFromDateTimePicker_ValueChanged
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
        private void jukoDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                jukoDtToDateTimePicker.Value = jukoDtFromDateTimePicker.Value;
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
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            saisuiinMstDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Display data
            saisuiinMstDataSet.Merge(alOutput.SaisuiinInfoListDT);

            if (alOutput.SaisuiinInfoListDT == null || alOutput.SaisuiinInfoListDT.Count == 0)
            {
                saisuiinKanriListCountLabel.Text = "0件";
            }
            else
            {
                saisuiinKanriListCountLabel.Text = alOutput.SaisuiinInfoListDT.Count.ToString() + "件";
            }

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.saisuiinKanriListPanel.Top;
            this._defaultListPanelHeight = this.saisuiinKanriListPanel.Height;
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
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 採水員コード（開始）
            alInput.SaisuiinCdFrom = saisuiinCdFromTextBox.Text;

            // 採水員コード（終了）
            alInput.SaisuiinCdTo = saisuiinCdToTextBox.Text;

            // 所属業者コード（開始）
            alInput.SyozokuGyosyaCdFrom = syozokuGyosyaCdFromTextBox.Text;

            // 所属業者コード（終了）
            alInput.SyozokuGyosyaCdTo = syozokuGyosyaCdToTextBox.Text;

            // 採水員名
            alInput.SaisuiinNm = saisuiinNmTextBox.Text.Trim();

            // 条件追加フラグ
            alInput.AddConditionsFlg = addConditionsFlgCheckBox.Checked;

            // 受講日（開始）
            alInput.JukoDtFrom = jukoDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 受講日（終了）
            alInput.JukoDtTo = jukoDtToDateTimePicker.Value.ToString("yyyyMMdd");
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
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            saisuiinMstDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            saisuiinMstDataSet.Merge(alOutput.SaisuiinInfoListDT);

            if (alOutput.SaisuiinInfoListDT == null || alOutput.SaisuiinInfoListDT.Count == 0)
            {
                saisuiinKanriListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                saisuiinKanriListCountLabel.Text = alOutput.SaisuiinInfoListDT.Count.ToString() + "件";
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
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 採水員コード（開始）
            if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text) && saisuiinCdFromTextBox.Text.Length != 5)
            {
                errMess.Append("採水員コード（開始）は5桁で入力して下さい。\r\n");
            }

            // 採水員コード（終了）
            if (!string.IsNullOrEmpty(saisuiinCdToTextBox.Text) && saisuiinCdToTextBox.Text.Length != 5)
            {
                errMess.Append("採水員コード（終了）は5桁で入力して下さい。\r\n");
            }

            if (string.IsNullOrEmpty(errMess.ToString()))
            {
                if (!string.IsNullOrEmpty(saisuiinCdFromTextBox.Text) && !string.IsNullOrEmpty(saisuiinCdToTextBox.Text)
                    && Convert.ToInt32(saisuiinCdFromTextBox.Text) > Convert.ToInt32(saisuiinCdToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。採水員コードの大小関係を確認してください。\r\n");
                }
            }

            // 所属業者コード（開始＆終了）
            if (!string.IsNullOrEmpty(gyoshaNmFromTextBox.Text) && !string.IsNullOrEmpty(gyoshaNmToTextBox.Text)
                && Convert.ToInt32(syozokuGyosyaCdFromTextBox.Text) > Convert.ToInt32(syozokuGyosyaCdToTextBox.Text))
            {
                errMess.Append("範囲指定が正しくありません。所属業者の大小関係を確認してください。\r\n");
            }

            // 受講日（開始＆終了）
            if (addConditionsFlgCheckBox.Checked)
            {
                if (jukoDtFromDateTimePicker.Value > jukoDtToDateTimePicker.Value)
                {
                    errMess.Append("範囲指定が正しくありません。受講日の大小関係を確認してください。\r\n");
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
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 採水員コード（開始）
            saisuiinCdFromTextBox.Clear();

　　        // 採水員コード（終了）
            saisuiinCdToTextBox.Clear();

　　        // 所属業者名（開始）
            gyoshaNmFromTextBox.Clear();

　　        // 所属業者名（終了）
            gyoshaNmToTextBox.Clear();

            // 所属業者コード（終了）
            syozokuGyosyaCdFromTextBox.Clear();

            // 所属業者名（終了）
            syozokuGyosyaCdToTextBox.Clear();

　　        // 採水員名
            saisuiinNmTextBox.Clear();

            // 条件追加フラグ
            addConditionsFlgCheckBox.Checked = false;

　　        // 受講日（開始）　　　　　=　システム年月日
            jukoDtFromDateTimePicker.Value = today;
            jukoDtFromDateTimePicker.Enabled = false;

　　        // 受講日（終了）　　　　　=　システム年月日
            jukoDtToDateTimePicker.Value = today;
            jukoDtToDateTimePicker.Enabled = false;
        }
        #endregion

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
            // 子画面が正常終了した場合    
            if (childForm.DialogResult == DialogResult.OK)
            {
                KensakuButton.PerformClick();
            }
        }
        #endregion

        #endregion
        
    }
    #endregion
}
