using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.KensaJokyoList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaJokyoListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaJokyoListForm : FukjBaseForm
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
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaJokyoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaJokyoListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaJokyoListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaJokyoListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaJokyoListForm_Load(object sender, EventArgs e)
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
        /// 2014/08/18　HuyTX    新規作成
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
                if (this._searchShowFlg)//検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else////検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }

                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.jokyoListPanel,
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

        #region jokasoSrhButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jokasoSrhButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jokasoSrhButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                JokasoDaichoSearchForm frm = new JokasoDaichoSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    settisyaCdTextBox.Text = frm._selectedRow.JokasoHokenjoCd
                        + "-"
                        + Common.Common.ConvertToHoshouNendoWareki(frm._selectedRow.JokasoTorokuNendo)
                        + "-"
                        + frm._selectedRow.JokasoRenban;
                    settisyaTextBox.Text = frm._selectedRow.JokasoSetchishaNm;
                    shisetsuNmTextBox.Text = frm._selectedRow.JokasoShisetsuNm;
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

        #region kensaIraiDtUseCheckBox_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiDtUseCheckBox_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaIraiDtUseCheckBox_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaIraiDtFromDateTimePicker.Enabled = kensaIraiDtUseCheckBox.Checked;
                kensaIraiDtToDateTimePicker.Enabled = kensaIraiDtUseCheckBox.Checked;
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

        #region kensaDtUseCheckBox_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaDtUseCheckBox_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaDtUseCheckBox_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaDtFromDateTimePicker.Enabled = kensaDtUseCheckBox.Checked;
                kensaDtToDateTimePicker.Enabled = kensaDtUseCheckBox.Checked;
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
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //set default control
                SetDisplayDefaultControl();
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
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidData()) return;

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
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jokyoListDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査状況一覧";
                Common.Common.FlushGridviewDataToExcel(jokyoListDataGridView, outputFilename);

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
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
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

        #region KensaJokyoListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaJokyoListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaJokyoListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
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

        #region kensaIraiDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiDtFromDateTimePicker_ValueChanged
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
        private void kensaIraiDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaIraiDtToDateTimePicker.Value = kensaIraiDtFromDateTimePicker.Value;
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
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.jokyoListPanel.Top;
            this._defaultListPanelHeight = this.jokyoListPanel.Height;

            //set default control
            SetDisplayDefaultControl();

            //20141215 Del Start
            //IFormLoadALInput alInput = new FormLoadALInput();

            //alInput.HoteiKbn = new List<string>();

            //alInput.HoteiKbn.Add("1");
            //alInput.HoteiKbn.Add("2");
            //alInput.HoteiKbn.Add("3");
            //alInput.HoteiKbn.Add("4");
            //alInput.KensaDtFrom = kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");
            //alInput.KensaDtTo = kensaDtToDateTimePicker.Value.ToString("yyyyMMdd");

            //IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            ////検索結果件数
            //jokyoListCountLabel.Text = alOutput.KensaJokyoListDataTable.Count + "件";

            ////set data for display gridview
            ////jokyoListDataGridView.DataSource = GetKensaJokyoList(alOutput.KensaJokyoListDataTable);
            //jokyoListDataGridView.DataSource = alOutput.KensaJokyoListDataTable;

            //if (alOutput.KensaJokyoListDataTable != null && alOutput.KensaJokyoListDataTable.Count > 0)
            //{
            //    outputButton.Enabled = true;
            //}
            //else
            //{
            //    outputButton.Enabled = false;
            //}
            //20141215 Del End
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
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            jokyoListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            jokyoListCountLabel.Text = alOutput.KensaJokyoListDataTable.Count + "件";

            if (alOutput.KensaJokyoListDataTable.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                outputButton.Enabled = false;
                return;
            }

            //set data for display gridview
            //jokyoListDataGridView.DataSource = GetKensaJokyoList(alOutput.KensaJokyoListDataTable);
            jokyoListDataGridView.DataSource = alOutput.KensaJokyoListDataTable;
            outputButton.Enabled = true;
        }
        #endregion

        #region IsValidData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            //検査依頼日（開始＆終了）
            if (kensaIraiDtUseCheckBox.Checked
                && Convert.ToInt32(kensaIraiDtFromDateTimePicker.Value.ToString("yyyyMMdd")) > Convert.ToInt32(kensaIraiDtToDateTimePicker.Value.ToString("yyyyMMdd")))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査依頼日の大小関係を確認してください。");
            }

            //検査日（開始＆終了）
            if (kensaDtUseCheckBox.Checked
                && Convert.ToInt32(kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd")) > Convert.ToInt32(kensaDtToDateTimePicker.Value.ToString("yyyyMMdd")))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査日の大小関係を確認してください。");
            }

            //検査区分
            if (!kensa7JoCheckBox.Checked && !kensa11JoGaikanCheckBox.Checked && !kensa11JoSuiShitsuCheckBox.Checked && !kensaKeiryoSyomeiCheckBox.Checked)
            {
                errMsg.AppendLine("検査区分を選択してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetDisplayDefaultControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayDefaultControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/19　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayDefaultControl()
        {
            jokyoListDataGridView.DataSource = null;
            jokyoListCountLabel.Text = "0件";

            kensa7JoCheckBox.Checked = true;
            kensa11JoGaikanCheckBox.Checked = true;
            kensa11JoSuiShitsuCheckBox.Checked = true;
            kensaKeiryoSyomeiCheckBox.Checked = true;
            settisyaTextBox.Text = string.Empty;
            shisetsuNmTextBox.Text = string.Empty;
            settisyaCdTextBox.Text = string.Empty;

            // 2014.12.29 toyoda Modify Start
            //kensaIraiDtUseCheckBox.Checked = false;
            //kensaDtUseCheckBox.Checked = true;
            kensaIraiDtUseCheckBox.Checked = true;
            kensaDtUseCheckBox.Checked = false;
            // 2014.12.29 toyoda Modify End

            kensaIraiDtFromDateTimePicker.Value = new DateTime(_currentDateTime.Year, _currentDateTime.Month, 1);
            kensaIraiDtToDateTimePicker.Value = _currentDateTime;

            kensaDtFromDateTimePicker.Value = new DateTime(_currentDateTime.Year, _currentDateTime.Month, 1);
            kensaDtToDateTimePicker.Value = _currentDateTime;

            kensaIraiDtUseCheckBox_Click(null, null);
            kensaDtUseCheckBox_Click(null, null);

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
        /// 2014/08/19　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            alInput.HoteiKbn = new List<string>();

            if (kensa7JoCheckBox.Checked) alInput.HoteiKbn.Add("1");

            if (kensa11JoGaikanCheckBox.Checked) alInput.HoteiKbn.Add("2");

            if (kensa11JoSuiShitsuCheckBox.Checked) alInput.HoteiKbn.Add("3");

            if (kensaKeiryoSyomeiCheckBox.Checked) alInput.HoteiKbn.Add("4");

            alInput.JokasoSetchishaNm = settisyaTextBox.Text.Trim();
            alInput.JokasoShisetsuNm = shisetsuNmTextBox.Text.Trim();
            alInput.SettisyaCd = settisyaCdTextBox.Text.Trim();

            if (kensaIraiDtUseCheckBox.Checked)
            {
                alInput.KensaIraiDtFrom = kensaIraiDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                alInput.KensaIraiDtTo = kensaIraiDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }

            if (kensaDtUseCheckBox.Checked)
            {
                alInput.KensaDtFrom = kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                alInput.KensaDtTo = kensaDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }

        }
        #endregion

        #region DEL_20141118
        //#region GetKensaJokyoList
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： GetKensaJokyoList
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="kensaJokyoListDT"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/17　HuyTX    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaIraiTblDataSet.KensaJokyoListDataTable GetKensaJokyoList(KensaIraiTblDataSet.KensaJokyoListDataTable kensaJokyoListDT)
        //{
        //    foreach (KensaIraiTblDataSet.KensaJokyoListRow row in kensaJokyoListDT.Rows)
        //    {
        //        row.JokasoCd = string.Concat(row.JokasoCd1, "-", Utility.DateUtility.ConvertToWareki(row.JokasoCd2, "yy"), "-", row.JokasoCd3);

        //        if (row.KeiryoShomeiFlg == "1")
        //        {
        //            row.KensaIraiCd = string.Concat(Utility.DateUtility.ConvertToWareki(row.KensaIraiCd1, "yy"), "-", row.KensaIraiCd2, "-", row.KensaIraiCd3);
        //        }
        //        else
        //        {
        //            row.KensaIraiCd = string.Concat(row.KensaIraiCd1, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiCd2, "yy"), "-", row.KensaIraiCd3);
        //        }
        //    }

        //    return kensaJokyoListDT;
        //}
        //#endregion
        #endregion

        #endregion
    }
    #endregion
}
