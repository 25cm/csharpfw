using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiRendoList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaikeiRendoListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaikeiRendoListForm : FukjBaseForm
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

        /// <summary>
        /// shokuinShozokuShishoCd
        /// </summary>
        private string _shokuinShozokuShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        /// <summary>
        /// kaikeiRendoHdrTblKensakuDT 
        /// </summary>
        private KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuDataTable _kaikeiRendoHdrTblKensakuDT = new KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KaikeiRendoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KaikeiRendoListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KaikeiRendoListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaikeiRendoListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaikeiRendoListForm_Load(object sender, EventArgs e)
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
        /// 2014/09/11　HuyTX    新規作成
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

        #region nyukinRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nyukinRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            yubinCheckBox.Enabled = nyukinRadioButton.Checked;
            bankCheckBox.Enabled = nyukinRadioButton.Checked;
            genkinCheckBox.Enabled = nyukinRadioButton.Checked;
            shiharaiCheckBox.Enabled = nyukinRadioButton.Checked;
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
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //set default display control
                SetDefaultDisplayControl();

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
        /// 2014/09/11　HuyTX    新規作成
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

        #region makeDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： makeDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void makeDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                makeDtFromDateTimePicker.Enabled = makeDtUseCheckBox.Checked;
                makeDtToDateTimePicker.Enabled = makeDtUseCheckBox.Checked;

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

        #region syukeiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syukeiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syukeiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                KaikeiMakeFileForm frm = new KaikeiMakeFileForm();
                frm.ShowDialog();

                if (frm.suitoSyukeiStdSuccess)
                {
                    // 対象区分
                    if (frm.returnCond.UriageNyukinKbn == "1")
                    {
                        uriageRadioButton.Checked = true;
                    }
                    else
                    {
                        nyukinRadioButton.Checked = true;
                    }

                    // 支所
                    shisyoComboBox.SelectedValue = frm.returnCond.ShishoCd;

                    //作成対象/郵便
                    if (frm.returnCond.ListMakeKbn.Contains("1")) 
                    { 
                        yubinCheckBox.Checked = true; 
                    }
                    else
                    {
                        yubinCheckBox.Checked = false; 
                    }
                    //作成対象/銀行
                    if (frm.returnCond.ListMakeKbn.Contains("2"))
                    {
                        bankCheckBox.Checked = true;
                    }
                    else
                    {
                        bankCheckBox.Checked = false;
                    }
                    //作成対象/現金
                    if (frm.returnCond.ListMakeKbn.Contains("3"))
                    {
                        genkinCheckBox.Checked = true;
                    }
                    else
                    {
                        genkinCheckBox.Checked = false;
                    }
                    //作成対象/支払
                    if (frm.returnCond.ListMakeKbn.Contains("4"))
                    {
                        shiharaiCheckBox.Checked = true;
                    }
                    else
                    {
                        shiharaiCheckBox.Checked = false;
                    }

                    // 作成日検索使用フラグ
                    makeDtUseCheckBox.Checked = false;

                    // 承認区分
                    syoninCheckBox.Checked = true;
                    miSyoninCheckBox.Checked = true;
                    kyakkaCheckBox.Checked = true;

                    kaikeiNoFromTextBox.Text = frm.returnCond.KaikeiNoFrom;

                    kaikeiNoToTextBox.Text = frm.returnCond.KaikeiNoTo;

                    DoSearch();
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
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsSelectedDgv()) return;
                
                KaikeiRendoShosaiForm frm = new KaikeiRendoShosaiForm(suitoListDataGridView.CurrentRow.Cells[kaikeiNoCol.Name].Value.ToString());
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

        #region ukagaisyoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ukagaisyoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ukagaisyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsSelectedDgv()) return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択された出納伺書を印刷します。よろしいですか？") != DialogResult.Yes) return;

                string kaikeiNo = suitoListDataGridView.CurrentRow.Cells[kaikeiNoCol.Name].Value.ToString();

                KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow[] kaikeiHdrRows = (KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow[])_kaikeiRendoHdrTblKensakuDT.Select(string.Format("KaikeiNo = '{0}'", kaikeiNo));
                if (kaikeiHdrRows.Length == 0) return;

                IUkagaisyoBtnClickALInput alInput = new UkagaisyoBtnClickALInput();
                alInput.KaikeiRendoHdrTblKensakuRow = kaikeiHdrRows[0];
                new UkagaisyoBtnClickApplicationLogic().Execute(alInput);

                DoSearch();

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

        #region kaikeiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaikeiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaikeiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsSelectedDgv()) return;

                Common.Common.ExportKaikeiRendoToCSVFile(suitoListDataGridView.CurrentRow.Cells[kaikeiNoCol.Name].Value.ToString());

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
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (suitoListDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "出納管理一覧";
                Common.Common.FlushGridviewDataToExcel(suitoListDataGridView, outputFilename);

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
        /// 2014/09/11　HuyTX    新規作成
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

        #region KaikeiRendoListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaikeiRendoListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaikeiRendoListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        syukeiButton.PerformClick();
                        break;

                    case Keys.F2:
                        shosaiButton.PerformClick();
                        break;

                    case Keys.F4:
                        ukagaisyoButton.PerformClick();
                        break;

                    case Keys.F5:
                        kaikeiButton.PerformClick();
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

        #region kaikeiNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaikeiNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　HuyTX    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaikeiNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kaikeiNoFromTextBox.Text.Trim())) return;

                kaikeiNoToTextBox.Text = kaikeiNoFromTextBox.Text;
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

        #region makeDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： makeDtFromDateTimePicker_ValueChanged
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
        private void makeDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                makeDtToDateTimePicker.Value = makeDtFromDateTimePicker.Value;
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
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //set source to shishoCombobox
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);

            //検索結果件数
            srhListCountLabel.Text = "0件";

            //set data for display gridview
            suitoListDataGridView.DataSource = null;

            //set default display control
            SetDefaultDisplayControl();

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
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            suitoListDataGridView.DataSource = null;
            suitoListDataGridView.Rows.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            alInput.SearchCond = MakeSearchCond();
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            _kaikeiRendoHdrTblKensakuDT = alOutput.KaikeiRendoHdrTblKensakuDataTable;
            srhListCountLabel.Text = alOutput.KaikeiRendoHdrTblKensakuDataTable.Count + "件";

            if (alOutput.KaikeiRendoHdrTblKensakuDataTable.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            //set data for display gridview
            suitoListDataGridView.DataSource = alOutput.KaikeiRendoHdrTblKensakuDataTable;

        }
        #endregion

        #region MakeSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KaikeiRendoHdrTblSearchCond MakeSearchCond()
        {
            KaikeiRendoHdrTblSearchCond searchCond = new KaikeiRendoHdrTblSearchCond();

            searchCond.UriageNyukinKbn = (uriageRadioButton.Checked) ? "1" : "2";
            searchCond.ShishoCd = (shisyoComboBox.SelectedIndex > 0) ? shisyoComboBox.SelectedValue.ToString() : string.Empty;
            searchCond.KaikeiNoFrom = kaikeiNoFromTextBox.Text.Trim();
            searchCond.KaikeiNoTo = kaikeiNoToTextBox.Text.Trim();

            searchCond.ListMakeKbn = new List<string>();

            if (nyukinRadioButton.Checked)
            {
                if (yubinCheckBox.Checked)
                {
                    searchCond.ListMakeKbn.Add("1");
                }
                if (bankCheckBox.Checked)
                {
                    searchCond.ListMakeKbn.Add("2");
                }
                if (genkinCheckBox.Checked)
                {
                    searchCond.ListMakeKbn.Add("3");
                }
                if (shiharaiCheckBox.Checked)
                {
                    searchCond.ListMakeKbn.Add("4");
                }
            }

            searchCond.MakeDtUse = makeDtUseCheckBox.Checked;
            searchCond.MakeDtFrom = (makeDtUseCheckBox.Checked) ? makeDtFromDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;
            searchCond.MakeDtTo = (makeDtUseCheckBox.Checked) ? makeDtToDateTimePicker.Value.ToString("yyyyMMdd") : string.Empty;

            searchCond.ListSyoninFlg = new List<string>();
            if (syoninCheckBox.Checked)
            {
                searchCond.ListSyoninFlg.Add("1");
            }
            if (miSyoninCheckBox.Checked)
            {
                searchCond.ListSyoninFlg.Add("0");
            }
            if (kyakkaCheckBox.Checked)
            {
                searchCond.ListSyoninFlg.Add("2");
            }

            return searchCond;
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
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            //会計No（開始＆終了）
            if (!string.IsNullOrEmpty(kaikeiNoFromTextBox.Text.Trim()) 
                && !string.IsNullOrEmpty(kaikeiNoToTextBox.Text.Trim())
                && Convert.ToDouble(kaikeiNoFromTextBox.Text.Trim()) > Convert.ToDouble(kaikeiNoToTextBox.Text.Trim())
                )
            {
                errMsg.AppendLine("範囲指定が正しくありません。会計Noの大小関係を確認してください。");
            }

            //作成日（開始＆終了）
            if (makeDtUseCheckBox.Checked
                && Convert.ToDouble(makeDtFromDateTimePicker.Value.ToString("yyyyMMdd")) > Convert.ToDouble(makeDtToDateTimePicker.Value.ToString("yyyyMMdd")))
            {
                errMsg.AppendLine("範囲指定が正しくありません。作成日の大小関係を確認してください。");
            }

            //作成対象
            if (!yubinCheckBox.Checked
                && !bankCheckBox.Checked
                && !genkinCheckBox.Checked
                && !shiharaiCheckBox.Checked)
            {
                errMsg.AppendLine("作成対象を選択してください");
            }

            //承認区分
            if (!syoninCheckBox.Checked
                && !miSyoninCheckBox.Checked
                && !kyakkaCheckBox.Checked)
            {
                errMsg.AppendLine("承認区分を選択してください");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetDefaultDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultDisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultDisplayControl()
        {
            nyukinRadioButton.Checked = true;
            kaikeiNoFromTextBox.Text = string.Empty;
            kaikeiNoToTextBox.Text = string.Empty;
            yubinCheckBox.Checked = true;
            bankCheckBox.Checked = true;
            genkinCheckBox.Checked = true;
            shiharaiCheckBox.Checked = false;
            makeDtUseCheckBox.Checked = false;
            makeDtFromDateTimePicker.Value = new DateTime(_currentDateTime.Year, _currentDateTime.Month, 1);
            makeDtFromDateTimePicker.Enabled = false;
            makeDtToDateTimePicker.Value = _currentDateTime;
            makeDtToDateTimePicker.Enabled = false;
            syoninCheckBox.Checked = true;
            miSyoninCheckBox.Checked = true;
            kyakkaCheckBox.Checked = true;

            shisyoComboBox.SelectedValue = _shokuinShozokuShishoCd;
            if (_shokuinShozokuShishoCd == "0")
            {
                shisyoComboBox.Enabled = true;
                kaikeiButton.Enabled = true;
            }
            else
            {
                shisyoComboBox.Enabled = false;
                kaikeiButton.Enabled = false;
            }
        }
        #endregion

        #region IsSelectedDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsSelectedDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsSelectedDgv()
        {
            if (suitoListDataGridView.RowCount == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                return false;
            }
            return true;
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

        #endregion
    }
    #endregion
}
