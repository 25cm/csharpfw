using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.MaeukekinList;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MaeukekinListForm
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
    public partial class MaeukekinListForm : FukjBaseForm
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
        //  コンストラクタ名 ： MaeukekinListForm
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
        public MaeukekinListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region MaeukekinListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MaeukekinListForm_Load
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
        private void MaeukekinListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

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
                    this.maeukekinListPanel,
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

                if (!(UnitCheck()))
                {
                    return;
                }

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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
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
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                MaeukekinShosaiForm frm = new MaeukekinShosaiForm();
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

                if (maeukekinListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string no1 = maeukekinListDataGridView.CurrentRow.Cells["MaeukeNo1Col"].Value.ToString();
                string no2 = maeukekinListDataGridView.CurrentRow.Cells["MaeukeNo2CdCol"].Value.ToString();
                
                MaeukekinShosaiForm frm = new MaeukekinShosaiForm(no1, no2);
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

                if (maeukekinListDataGridView.RowCount == 0) { return; }

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "前受金一覧";
                Common.Common.FlushGridviewDataToExcel(this.maeukekinListDataGridView, outputFilename);
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

                //KeiriMenuForm frm = new KeiriMenuForm();
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

        #region nyukinDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinDtUseCheckBox_CheckedChanged
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
        private void nyukinDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nyukinDtUseCheckBox.Checked)
                {
                    nyukinDtFromDateTimePicker.Enabled = true;
                    nyukinDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    nyukinDtFromDateTimePicker.Enabled = false;
                    nyukinDtToDateTimePicker.Enabled = false;
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

        #region uriageDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uriageDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT　  v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uriageDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (uriageDtUseCheckBox.Checked)
                {
                    uriageDtFromDateTimePicker.Enabled = true;
                    uriageDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    uriageDtFromDateTimePicker.Enabled = false;
                    uriageDtToDateTimePicker.Enabled = false;
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

        #region maeukekinListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： maeukekinListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/12/19  habu　  終了後ハンドラを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void maeukekinListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                string no1 = maeukekinListDataGridView.CurrentRow.Cells["MaeukeNo1Col"].Value.ToString();
                string no2 = maeukekinListDataGridView.CurrentRow.Cells["MaeukeNo2CdCol"].Value.ToString();

                MaeukekinShosaiForm frm = new MaeukekinShosaiForm(no1, no2);
                // 20141218 habu added shosaFormEnd handler
                Program.mForm.MoveNext(frm, FormEnd);
                //Program.mForm.MoveNext(frm);

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

        #region MaeukekinListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MaeukekinListForm_KeyDown
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
        private void MaeukekinListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.PerformClick();
                        break;

                    case Keys.F2:
                        shosaiButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.PerformClick();
                        break;

                    case Keys.F7:
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
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

        #region nyukinDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinDtFromDateTimePicker_ValueChanged
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
        private void nyukinDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                nyukinDtToDateTimePicker.Value = nyukinDtFromDateTimePicker.Value;
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

        #region uriageDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uriageDtFromDateTimePicker_ValueChanged
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
        private void uriageDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                uriageDtToDateTimePicker.Value = uriageDtFromDateTimePicker.Value;
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
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            maeukekinTblDataSet.Clear();

            // 2014.12.30 toyoda Modify Start
            //IFormLoadALInput alInput = new FormLoadALInput();
            //IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //// Display data
            //maeukekinTblDataSet.Merge(alOutput.MaeukekinTblKensakuDT);

            //if (alOutput.MaeukekinTblKensakuDT == null || alOutput.MaeukekinTblKensakuDT.Count == 0)
            //{
            //    maeukekinListCountLabel.Text = "0件";
            //}
            //else
            //{
            //    maeukekinListCountLabel.Text = alOutput.MaeukekinTblKensakuDT.Count.ToString() + "件";
            //}
            maeukekinListCountLabel.Text = "0件";
            // 2014.12.30 toyoda Modify End

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.maeukekinListPanel.Top;
            this._defaultListPanelHeight = this.maeukekinListPanel.Height;
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
        /// 2014/11/10  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 2014/11/10 DatNT v1.02 MOD Start

            //// 採番区分 
            //if (ryohoRadioButton.Checked)
            //{
            //    alInput.SaibanKbn = string.Empty;
            //}
            //else if (kisaiAriRadioButton.Checked)
            //{
            //    alInput.SaibanKbn = "0";
            //}
            //else if (kisaiNashiRadioButton.Checked)
            //{
            //    alInput.SaibanKbn = "1";
            //}

            //// 前受金No（開始）
            //alInput.MaeukeNoFrom = maeukeNoFromTextBox.Text;

            //// 前受金No（終了）
            //alInput.MaeukeNoTo = maeukeNoToTextBox.Text;

            // 連動区分
            if (allRadioButton.Checked)
            {
                alInput.RendoKbn = string.Empty;
            }
            else if (mirendoRadioButton.Checked)
            {
                alInput.RendoKbn = "0";
            }
            else
            {
                alInput.RendoKbn = "1";
            }

            // 前受金No
            alInput.MaeukeNo = maeukeNoTextBox.Text;

            // 売上日検索使用フラグ
            alInput.UriageDtUse = uriageDtUseCheckBox.Checked;

            // 売上日（開始）
            alInput.UriageDtFrom = uriageDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 売上日（終了）
            alInput.UriageDtTo = uriageDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 強制売上のみフラグ
            alInput.KyoseiUriage = kyoseiUriageCheckBox.Checked;

            // 2014/11/10 DatNT v1.02 MOD End

            // 振込人
            alInput.FurikomininNm = furikomiNmTextBox.Text.Trim();

            // 入金日検索使用フラグ
            alInput.NyukinDtUse = nyukinDtUseCheckBox.Checked;

            // 入金日（開始）
            alInput.NyukinDtFrom = nyukinDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 入金日（終了）
            alInput.NyukinDtTo = nyukinDtToDateTimePicker.Value.ToString("yyyyMMdd");
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
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            maeukekinTblDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            maeukekinTblDataSet.Merge(alOutput.MaeukekinTblKensakuDT);

            if (alOutput.MaeukekinTblKensakuDT == null || alOutput.MaeukekinTblKensakuDT.Count == 0)
            {
                maeukekinListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                maeukekinListCountLabel.Text = alOutput.MaeukekinTblKensakuDT.Count.ToString() + "件";
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
        /// 2014/07/21  DatNT　  新規作成
        /// 2014/11/10  DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 2014/11/10 DatNT v1.02 MOD Start
            
            //// 前受金No（開始）
            //if (!string.IsNullOrEmpty(maeukeNoFromTextBox.Text) && maeukeNoFromTextBox.Text.Length != 6)
            //{
            //    errMsg.Append("前受金No（開始）は6桁で入力して下さい。\r\n");
            //}

            //// 前受金No（終了）
            //if (!string.IsNullOrEmpty(maeukeNoToTextBox.Text) && maeukeNoToTextBox.Text.Length != 6)
            //{
            //    errMsg.Append("前受金No（終了）は6桁で入力して下さい。\r\n");
            //}

            //if (!string.IsNullOrEmpty(maeukeNoToTextBox.Text) && !string.IsNullOrEmpty(maeukeNoFromTextBox.Text)
            //    && string.IsNullOrEmpty(errMsg.ToString()))
            //{
            //   if(!string.IsNullOrEmpty(maeukeNoFromTextBox.Text) && !string.IsNullOrEmpty(maeukeNoToTextBox.Text)
            //       && Convert.ToInt32(maeukeNoFromTextBox.Text) > Convert.ToInt32(maeukeNoToTextBox.Text))
            //   {
            //       errMsg.Append("範囲指定が正しくありません。前受金Noの大小関係を確認してください。\r\n");
            //   }
            //}

            // 前受金No
            if (!string.IsNullOrEmpty(maeukeNoTextBox.Text) && maeukeNoTextBox.Text.Length != 6)
            {
                errMsg.AppendLine("前受金Noは6桁で入力して下さい。");
            }

            // 2014/11/10 DatNT v1.02 MOD End

            // 振込人
            if (!string.IsNullOrEmpty(furikomiNmTextBox.Text.Trim()) && furikomiNmTextBox.Text.Trim().Length > 20)
            {
                errMsg.Append("振込人は20文字以下で入力して下さい。\r\n");
            }

            // 入金日（開始＆終了）
            if (nyukinDtUseCheckBox.Checked)
            {
                if (nyukinDtFromDateTimePicker.Value > nyukinDtToDateTimePicker.Value.AddDays(1))
                {
                    errMsg.Append("範囲指定が正しくありません。入金日の大小関係を確認してください。\r\n");
                }
            }

            // 2014/11/10 DatNT v1.02 ADD Start
            // 売上日（開始＆終了）
            if (uriageDtUseCheckBox.Checked)
            {
                if (uriageDtFromDateTimePicker.Value > uriageDtToDateTimePicker.Value)
                {
                    errMsg.AppendLine("範囲指定が正しくありません。売上日の大小関係を確認してください。");
                }
            }
            // 2014/11/10 DatNT v1.02 ADD End

            if(!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
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
        /// 2014/07/23  DatNT　  新規作成
        /// 2014/11/10  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 2014/11/10 DatNT v1.02 MOD Start

            //// 採番区分 両方
            //ryohoRadioButton.Checked = true;

            //// 前受金No（開始）
            //maeukeNoFromTextBox.Clear();

            //// 前受金No（終了）
            //maeukeNoToTextBox.Clear();

            // 連動区分 全件
            allRadioButton.Checked = true;

            // 前受金No
            maeukeNoTextBox.Clear();

            // 振込人/カナ
            furikomiNmTextBox.Clear();

            // 売上日検索使用フラグ
            uriageDtUseCheckBox.Checked = false;

            // 売上日（開始）
            uriageDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            uriageDtFromDateTimePicker.Enabled = false;

            // 売上日（終了）
            uriageDtToDateTimePicker.Value = today;
            uriageDtToDateTimePicker.Enabled = false;

            // 強制売上のみフラグ
            kyoseiUriageCheckBox.Checked = false;

            // 2014/11/10 DatNT v1.02 MOD End

            // 振込人
            furikomiNmTextBox.Clear();

            // 入金日検索使用フラグ
            nyukinDtUseCheckBox.Checked = false;

            // 入金日（開始）
            nyukinDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            nyukinDtFromDateTimePicker.Enabled = false;

            // 入金日（終了）
            nyukinDtToDateTimePicker.Value = today;
            nyukinDtToDateTimePicker.Enabled = false;
        }
        #endregion

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14　HuyTX    新規作成
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

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 前受金No
            maeukeNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // 振込人/カナ
            furikomiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);
        }
        #endregion

        #endregion

    }
    #endregion

}
