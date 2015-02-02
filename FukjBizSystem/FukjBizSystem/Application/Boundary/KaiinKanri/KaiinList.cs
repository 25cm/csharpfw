using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using System.Collections.Generic;

namespace FukjBizSystem.Application.Boundary.KaiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaiinListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaiinListForm : FukjBaseForm 
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
        //  コンストラクタ名 ： KaiinListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KaiinListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KaiinListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaiinListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaiinListForm_Load(object sender, EventArgs e)
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

        #region ViewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
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
                    this.kaiinListPanel,
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
        /// 2014/07/21  DatNT　  新規作成
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
        /// 2014/07/21  DatNT　  新規作成
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

        #region shosaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shosaiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kaiinListDataGridView.RowCount == 0) {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return; 
                }

                KaiinShosaiForm frm = new KaiinShosaiForm(kaiinListDataGridView.CurrentRow.Cells["GyosyaCdCol"].Value.ToString());
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

        #region KakuninsyoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KakuninsyoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2015/01/30  DatNT   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KakuninsyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //ADD HuyTX 20140806 START

                if (kaiinListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 2015/01/30 DatNT v1.04 MOD Start
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "一覧の業者の会員情報確認書を印刷します。よろしいですか？") != DialogResult.Yes) return;
                //if (MessageForm.Show2(MessageForm.DispModeType.Question, "会員情報確認書を印刷します。よろしいですか？") != DialogResult.Yes) return;
                // 2015/01/30 DatNT v1.04 MOD End

                IKakuninsyoBtnClickALInput alInput = new KakuninsyoBtnClickALInput();
                // 2015.01.30 AnhNV MOD Start
                //alInput.GyoshaCd = kaiinListDataGridView.CurrentRow.Cells["GyosyaCdCol"].Value.ToString();
                List<string> gyoshaCdList = new List<string>();
                foreach (DataGridViewRow dgvr in kaiinListDataGridView.Rows)
                {
                    gyoshaCdList.Add(Convert.ToString(dgvr.Cells["GyosyaCdCol"].Value));
                }
                alInput.GyoshaCdList = gyoshaCdList;
                // 2015.01.30 AnhNV MOD End

                new KakuninsyoBtnClickApplicationLogic().Execute(alInput);

                //ADD HuyTX 20140806 END
                
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
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kaiinListDataGridView.RowCount == 0) { return; }

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "業者部会マスタ一覧";
                Common.Common.FlushGridviewDataToExcel(this.kaiinListDataGridView, outputFilename);
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

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //KaiinMenuForm frm = new KaiinMenuForm();
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

        #region nyukaiDtUseCheckBox_CheckedChanged
        // 2015/01/30 DatNT v1.04 DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： nyukaiDtUseCheckBox_CheckedChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/07/21  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void nyukaiDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (nyukaiDtUseCheckBox.Checked)
        //        {
        //            nyukaiDtFromDateTimePicker.Enabled = true;
        //            nyukaiDtToDateTimePicker.Enabled = true;
        //        }
        //        else
        //        {
        //            nyukaiDtFromDateTimePicker.Enabled = false;
        //            nyukaiDtToDateTimePicker.Enabled = false;
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
        #endregion

        #region KaiinListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaiinListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaiinListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        shosaiButton.Focus();
                        shosaiButton.PerformClick();
                        break;

                    case Keys.F2:
                        nyukinButton.Focus();
                        nyukinButton.PerformClick();
                        break;

                    case Keys.F5:
                        KakuninsyoButton.Focus();
                        KakuninsyoButton.PerformClick();
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
                        tojiruButton.Focus();
                        tojiruButton.PerformClick();
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

        #region kaiinListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaiinListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaiinListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                KaiinShosaiForm frm = new KaiinShosaiForm(kaiinListDataGridView.CurrentRow.Cells["GyosyaCdCol"].Value.ToString());
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

        #region nyukinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  HuyTX　   Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nyukinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kaiinListDataGridView.RowCount == 0) 
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return; 
                }

                GyoshaBukaiMstDataSet.KaiinListRow selectedRow = (GyoshaBukaiMstDataSet.KaiinListRow)(kaiinListDataGridView.CurrentRow.DataBoundItem as DataRowView).Row;

                KaiinNyukinForm frm = new KaiinNyukinForm(selectedRow);
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

        #region gyosyaCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text))
                {
                    gyosyaCdFromTextBox.Text = gyosyaCdFromTextBox.Text.PadLeft(4, '0');

                    gyosyaCdToTextBox.Text = gyosyaCdFromTextBox.Text;
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

        #region gyosyaCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20  DatNT　   v1.03
        /// </history>
        private void gyosyaCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyosyaCdToTextBox.Text))
                {
                    gyosyaCdToTextBox.Text = gyosyaCdToTextBox.Text.PadLeft(4, '0');
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
        /// 2014/11/07　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
            // 子画面が正常終了した場合
            if (childForm.DialogResult == DialogResult.OK)
            {
                kensakuButton.PerformClick();
            }
        }
        #endregion

        #region nyukaiDtFromDateTimePicker_ValueChanged
        // 2015/01/30 DatNT v1.04 DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： nyukaiDtFromDateTimePicker_ValueChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2015/01/28　PhuongDT    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void nyukaiDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        nyukaiDtToDateTimePicker.Value = nyukaiDtFromDateTimePicker.Value;
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
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            gyoshaBukaiMstDataSet.Clear();

            // 2015/01/30 DatNT DEL Start
            //IFormLoadALInput alInput = new FormLoadALInput();
            //MakeSearchCondFormLoad(alInput);
            //IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //// Display data
            //gyoshaBukaiMstDataSet.Merge(alOutput.KaiinListDT);

            //if (alOutput.KaiinListDT == null || alOutput.KaiinListDT.Count == 0)
            //{
            //    kaiinListCountLabel.Text = "0件";
            //}
            //else
            //{
            //    kaiinListCountLabel.Text = alOutput.KaiinListDT.Count.ToString() + "件";
            //}
            // 2015/01/30 DatNT DEL End

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.kaiinListPanel.Top;
            this._defaultListPanelHeight = this.kaiinListPanel.Height;
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
        /// 2014/07/21  DatNT　  新規作成
        /// 2015/01/30  DatNT   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 業者コード（開始）
            alInput.GyosyaCdFrom = gyosyaCdFromTextBox.Text;

            // 業者コード（終了）
            alInput.GyosyaCdTo = gyosyaCdToTextBox.Text;

            // 業者名称
            alInput.GyosyaNm = gyosyaNmTextBox.Text.Trim();

            // 2015/01/30 DatNT v1.04 DEL Start
            //// 入会日検索使用フラグ
            //alInput.NyukaiDtUse = nyukaiDtUseCheckBox.Checked;

            //// 入会日（開始）
            //alInput.NyukaiDtFrom = nyukaiDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            //// 入会日（終了）
            //alInput.NyukaiDtTo = nyukaiDtToDateTimePicker.Value.ToString("yyyyMMdd");
            // 2015/01/30 DatNT v1.04 DEL End

            // 製造
            alInput.Seizo = seizoCheckBox.Checked;

            // 工事
            alInput.Koji = kojiCheckBox.Checked;

            // 保守
            alInput.Hosyu = hosyuCheckBox.Checked;

            // 清掃
            alInput.Seiso = seisoCheckBox.Checked;

            // 未加入
            alInput.Mikanyu = mikanyuCheckBox.Checked;
        }
        #endregion

        #region MakeSearchCondFormLoad
        // 2015/01/30 DatNT DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： MakeSearchCondFormLoad
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="alInput"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/07/25  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void MakeSearchCondFormLoad(IFormLoadALInput alInput)
        //{
        //    // 業者コード（開始）
        //    alInput.GyosyaCdFrom = gyosyaCdFromTextBox.Text;

        //    // 業者コード（終了）
        //    alInput.GyosyaCdTo = gyosyaCdToTextBox.Text;

        //    // 業者名称
        //    alInput.GyosyaNm = gyosyaNmTextBox.Text.Trim();

        //    // 入会日検索使用フラグ
        //    alInput.NyukaiDtUse = nyukaiDtUseCheckBox.Checked;

        //    // 入会日（開始）
        //    alInput.NyukaiDtFrom = nyukaiDtFromDateTimePicker.Value.ToString("yyyyMMdd");

        //    // 入会日（終了）
        //    alInput.NyukaiDtTo = nyukaiDtToDateTimePicker.Value.ToString("yyyyMMdd");
            
        //    // 製造
        //    alInput.Seizo = seizoCheckBox.Checked;

        //    // 工事
        //    alInput.Koji = kojiCheckBox.Checked;

        //    // 保守
        //    alInput.Hosyu = hosyuCheckBox.Checked;

        //    // 清掃
        //    alInput.Seiso = seisoCheckBox.Checked;

        //    // 未加入
        //    alInput.Mikanyu = mikanyuCheckBox.Checked;
        //}
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2015/01/30  DatNT   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            gyoshaBukaiMstDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            gyoshaBukaiMstDataSet.Merge(alOutput.KaiinListDT);

            if (alOutput.KaiinListDT == null || alOutput.KaiinListDT.Count == 0)
            {
                kaiinListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                // 2015/01/30 DatNT v1.04 MOD Start
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力可能な業者が検索されていません。");
                //MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                // 2015/01/30 DatNT v1.04 MOD End
            }
            else
            {
                kaiinListCountLabel.Text = alOutput.KaiinListDT.Count.ToString() + "件";
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
        /// 2014/07/02  DatNT　　    新規作成
        /// 2015/01/30  DatNT       v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 業者コード（開始）
            bool gyosyaCdFlg = true;
            if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) && gyosyaCdFromTextBox.Text.Length != 4)
            {
                errMess.Append("業者コード（開始）は4桁で入力して下さい。\r\n");
                gyosyaCdFlg = false;
            }

            // 業者コード（終了）
            if (!string.IsNullOrEmpty(gyosyaCdToTextBox.Text) && gyosyaCdToTextBox.Text.Length != 4)
            {
                errMess.Append("業者コード（終了）は4桁で入力して下さい。\r\n");
                gyosyaCdFlg = false;
            }

            if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyosyaCdToTextBox.Text) && gyosyaCdFlg)
            {
                if (Convert.ToInt32(gyosyaCdFromTextBox.Text) > Convert.ToInt32(gyosyaCdToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。業者コードの大小関係を確認してください。\r\n");
                }
            }

            // 業者名称
            if (!string.IsNullOrEmpty(gyosyaNmTextBox.Text) && gyosyaNmTextBox.Text.Trim().Length > 40)
            {
                errMess.Append("業者名称は40文字以下で入力して下さい。 \r\n");
            }

            // 2015/01/30 DatNT v1.04 DEL Start
            //// 入会日（開始＆終了）
            //if (nyukaiDtFromDateTimePicker.Value > nyukaiDtToDateTimePicker.Value)
            //{
            //    errMess.Append("範囲指定が正しくありません。入会日の大小関係を確認してください。\r\n");
            //}
            // 2015/01/30 DatNT v1.04 DEL End

            // 会員区分
            if (!seizoCheckBox.Checked
                && !kojiCheckBox.Checked
                && !hosyuCheckBox.Checked
                && !seisoCheckBox.Checked
                && !mikanyuCheckBox.Checked)
            {
                errMess.Append("会員区分は１つ以上選択してください。\r\n");
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
        /// 2014/07/25  DatNT　　    新規作成
        /// 2015/01/30  DatNT       v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 業者コード（開始）
            gyosyaCdFromTextBox.Clear();

            // 業者コード（終了）
            gyosyaCdToTextBox.Clear();

            // 業者名称
            gyosyaNmTextBox.Clear();

            // 2015/01/30 DatNT v1.04 DEL Start
            //// 入会日検索使用フラグ
            //nyukaiDtUseCheckBox.Checked = false;

            //// 入会日（開始）
            //nyukaiDtFromDateTimePicker.Enabled = false;
            //nyukaiDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);

            //// 入会日（終了）
            //nyukaiDtToDateTimePicker.Value = today;
            //nyukaiDtToDateTimePicker.Enabled = false;
            // 2015/01/30 DatNT v1.04 DEL End

            // 製造
            seizoCheckBox.Checked = true;

            // 工事
            kojiCheckBox.Checked = true;

            // 保守
            hosyuCheckBox.Checked = true;

            // 清掃
            seisoCheckBox.Checked = true;

            // 会員外
            mikanyuCheckBox.Checked = false;
        }
        #endregion

        #endregion
        
    }
    #endregion
}
