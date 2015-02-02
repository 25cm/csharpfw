using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.KensainGeppoList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensainGeppoListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensainGeppoListForm : FukjBaseForm
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
        /// DateTime today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensainGeppoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensainGeppoListForm()
        {
            InitializeComponent();

            //set control domain
            SetControlDomain();
        }
        #endregion

        #region イベント

        #region KensainGeppoListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensainGeppoListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensainGeppoListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();

                DoFormLoad();

                kensaKensuButton.Enabled = false;
                gaikanGeppoButton.Enabled = false;
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
        /// 2014/08/18  DatNT　  新規作成
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
        /// 2014/08/18  DatNT　  新規作成
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
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/12/21  habu　  Fixed message condition
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

                if (misakuseiRadioButton.Checked || saisyukeiRadioButton.Checked)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "集計処理を実行します。よろしいですか？")
                        != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                DoSearch();

                if (geppoListDataGridView.RowCount == 0)
                //if (kisakuseiRadioButton.Checked && geppoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力できるデータがありません。");
                }

                if (geppoListDataGridView.RowCount == 0)
                {
                    jokyoListCountLabel.Text = "0件";
                    kensaKensuButton.Enabled = false;
                    gaikanGeppoButton.Enabled = false;
                }
                else
                {
                    jokyoListCountLabel.Text = geppoListDataGridView.RowCount / 3 + "件";
                    kensaKensuButton.Enabled = true;
                    gaikanGeppoButton.Enabled = true;
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

        #region kensaKensuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaKensuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaKensuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (geppoListDataGridView.RowCount == 0) { return; }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査員別検査件数一覧を印刷します。よろしいですか？")
                    != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                //excel 024
                IKensaKensuBtnClickALInput alInput = new KensaKensuBtnClickALInput();
                alInput.KensainGeppoListDgv = geppoListDataGridView;
                alInput.TaisyoYMFrom = taisyoYMFromTextBox.Text.Trim();
                alInput.TaisyoYMTo = taisyoYMToTextBox.Text.Trim();
                alInput.PrintKensainGeppoListDataTable = CreatePrintKensainGeppo();

                new KensaKensuBtnClickApplicationLogic().Execute(alInput);

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

        #region gaikanGeppoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gaikanGeppoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gaikanGeppoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (geppoListDataGridView.RowCount == 0) { return; }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "外観検査月報を印刷します。よろしいですか？")
                    != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                //excel 023
                IGaikanGeppoBtnClickALInput alInput = new GaikanGeppoBtnClickALInput();
                alInput.KensainGeppoListDgv = geppoListDataGridView;
                alInput.TaisyoYMFrom = taisyoYMFromTextBox.Text.Trim();
                alInput.TaisyoYMTo = taisyoYMToTextBox.Text.Trim();
                alInput.ShishoCd = geppoListDataGridView.CurrentRow.Cells[ShishoCdCol.Name].Value.ToString();

                new GaikanGeppoBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/08/18  DatNT　  新規作成
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

        #region KensainGeppoListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensainGeppoListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensainGeppoListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        kensaKensuButton.Focus();
                        kensaKensuButton.PerformClick();
                        break;

                    case Keys.F2:
                        gaikanGeppoButton.Focus();
                        gaikanGeppoButton.PerformClick();
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            geppoListDataGridView.Rows.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 支所
            //Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.jokyoListPanel.Top;
            this._defaultListPanelHeight = this.jokyoListPanel.Height;
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // 対象範囲（開始）
            alInput.TaisyoYMFrom = taisyoYMFromTextBox.Text;

            // 対象範囲（終了）
            alInput.TaisyoYMTo = taisyoYMToTextBox.Text;

            // 支所
            if (shisyoComboBox.SelectedValue != null)
            {
                alInput.ShishoCd = shisyoComboBox.SelectedValue.ToString();
            }

            // 集計処理区分
            if (misakuseiRadioButton.Checked)
            {
                alInput.ShoriKbn = "1";
            }
            else if (saisyukeiRadioButton.Checked)
            {
                alInput.ShoriKbn = "2";
            }
            else
            {
                alInput.ShoriKbn = "3";
            }

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Clear datagirdview
            geppoListDataGridView.Rows.Clear();

            // Display data
            DispData(alOutput.KensainGeppoListDT);
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();
            
            // 対象範囲（開始＆終了）
            if (string.IsNullOrEmpty(taisyoYMFromTextBox.Text))
            {
                errMess.Append("必須項目：対象範囲（開始）が入力されていません。\r\n");
            }
            else
            {
                if (taisyoYMFromTextBox.Text.Length != 6)
                {
                    errMess.AppendLine("対象範囲（開始）は6桁で入力して下さい。");
                }
            }

            if (string.IsNullOrEmpty(taisyoYMToTextBox.Text))
            {
                errMess.Append("必須項目：対象範囲（終了）が入力されていません。\r\n");
            }
            else
            {
                if(taisyoYMToTextBox.Text.Length != 6)
                {
                    errMess.AppendLine("対象範囲（終了）は6桁で入力して下さい。");
                }
            }

            if (string.IsNullOrEmpty(errMess.ToString())
                && !string.IsNullOrEmpty(taisyoYMFromTextBox.Text) && !string.IsNullOrEmpty(taisyoYMToTextBox.Text))
            {
                if (Convert.ToInt32(taisyoYMFromTextBox.Text) > Convert.ToInt32(taisyoYMToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。対象範囲の大小関係を確認してください。\r\n");
                }
                else
                {
                    int yearFrom = Convert.ToInt32(taisyoYMFromTextBox.Text.Substring(0, 4));
                    int yearTo = Convert.ToInt32(taisyoYMToTextBox.Text.Substring(0, 4));
                    int monthFrom = Convert.ToInt32(taisyoYMFromTextBox.Text.Substring(4, 2));
                    int monthTo = Convert.ToInt32(taisyoYMToTextBox.Text.Substring(4, 2));

                    if ((yearTo * 12 + monthTo) - (yearFrom * 12 + monthFrom) > 11)
                    {
                        errMess.Append("対象範囲は1年を超えて指定できません。\r\n");
                    }
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
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/12/22  habu　  Fixed
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 対象範囲
            // 20141222 habu Mod include 4
            if (today.Month <= 4)
            //if (today.Month < 4)
            {
                taisyoYMFromTextBox.Text = today.Year - 1 + "04";
            }
            else
            {
                taisyoYMFromTextBox.Text = today.Year + "04";
            }

            taisyoYMToTextBox.Text = today.Month == 1 ? string.Format("{0}12", today.Year - 1) : string.Concat(today.Year, (today.Month - 1).ToString().PadLeft(2, '0'));

            // 支所
            shisyoComboBox.SelectedIndex = -1;

            // 集計処理区分/未作成月のみ集計
            misakuseiRadioButton.Checked = true;
        }
        #endregion

        #region DispData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/10  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DispData(KensainGeppoTblDataSet.KensainGeppoListDataTable dataTable)
        {
            string kensaiinCd = string.Empty;
            string month = string.Empty;
            string shishoNm = string.Empty;
            int i = 2;

            bool isFirstRow = true;

            foreach (KensainGeppoTblDataSet.KensainGeppoListRow row in dataTable)
            {
                month = row.ShukeiNengetsu.Substring(4, 2);

                if (kensaiinCd != row.KensainCd || isFirstRow)
                {
                    if (shishoNm != row.ShishoNm)
                    {
                        geppoListDataGridView.Rows.Add(row.ShishoNm, row.KensainCd, row.ShokuinNm, "7条", "", "", "", "", "");
                    }
                    else
                    {
                        geppoListDataGridView.Rows.Add("", row.KensainCd, row.ShokuinNm, "7条", "", "", "", "", "");
                    }

                    geppoListDataGridView.Rows.Add("", "", "", "11条", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    geppoListDataGridView.Rows.Add("", "", "", "合計", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

                    if (isFirstRow)
                    {
                    }
                    else
                    {
                        if (kensaiinCd != row.KensainCd)
                        {
                            i += 3;
                        }
                    }
                }

                #region 月

                string monthCntCol = string.Empty;
                string monthAmtCol = string.Empty;
                string monthNissuCol = string.Empty;

                switch (month)
                {
                    case "04":

                        #region 4月

                        monthCntCol = Month4Col.Name;
                        monthAmtCol = Month4AmtCol.Name;
                        monthNissuCol = KadoNissu4Col.Name;

                        break;

                        #endregion

                    case "05":

                        #region 5月

                        monthCntCol = Month5Col.Name;
                        monthAmtCol = Month5AmtCol.Name;
                        monthNissuCol = KadoNissu5Col.Name;

                        break;

                        #endregion

                    case "06":

                        #region 6月

                        monthCntCol = Month6Col.Name;
                        monthAmtCol = Month6AmtCol.Name;
                        monthNissuCol = KadoNissu6Col.Name;

                        break;

                        #endregion

                    case "07":

                        #region 7月

                        monthCntCol = Month7Col.Name;
                        monthAmtCol = Month7AmtCol.Name;
                        monthNissuCol = KadoNissu7Col.Name;

                        break;

                        #endregion

                    case "08":

                        #region 8月

                        monthCntCol = Month8Col.Name;
                        monthAmtCol = Month8AmtCol.Name;
                        monthNissuCol = KadoNissu8Col.Name;

                        break;

                        #endregion

                    case "09":

                        #region 9月

                        monthCntCol = Month9Col.Name;
                        monthAmtCol = Month9AmtCol.Name;
                        monthNissuCol = KadoNissu9Col.Name;

                        break;

                        #endregion

                    case "10":

                        #region 10月

                        monthCntCol = Month10Col.Name;
                        monthAmtCol = Month10AmtCol.Name;
                        monthNissuCol = KadoNissu10Col.Name;

                        break;

                        #endregion

                    case "11":

                        #region 11月

                        monthCntCol = Month11Col.Name;
                        monthAmtCol = Month11AmtCol.Name;
                        monthNissuCol = KadoNissu11Col.Name;

                        break;

                        #endregion

                    case "12":

                        #region 12月

                        monthCntCol = Month12Col.Name;
                        monthAmtCol = Month12AmtCol.Name;
                        monthNissuCol = KadoNissu12Col.Name;

                        break;

                        #endregion

                    case "01":

                        #region 1月

                        monthCntCol = Month1Col.Name;
                        monthAmtCol = Month1AmtCol.Name;
                        monthNissuCol = KadoNissu1Col.Name;

                        break;

                        #endregion

                    case "02":

                        #region 2月

                        monthCntCol = Month2Col.Name;
                        monthAmtCol = Month2AmtCol.Name;
                        monthNissuCol = KadoNissu2Col.Name;

                        break;

                        #endregion

                    case "03":

                        #region 3月

                        monthCntCol = Month3Col.Name;
                        monthAmtCol = Month3AmtCol.Name;
                        monthNissuCol = KadoNissu3Col.Name;

                        break;

                        #endregion

                    default:
                        break;
                }

                if(!string.IsNullOrEmpty(monthCntCol))
                {
                    // 7Jo Cnt
                    geppoListDataGridView.Rows[i - 2].Cells[monthCntCol].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                    // 11Jo Cnt
                    geppoListDataGridView.Rows[i - 1].Cells[monthCntCol].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                    // 7Jo + 11Jo Cnt
                    if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[monthCntCol].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[monthCntCol].Value.ToString()))
                    {
                        geppoListDataGridView.Rows[i].Cells[monthCntCol].Value = string.Empty;
                    }
                    else
                    {
                        geppoListDataGridView.Rows[i].Cells[monthCntCol].Value =
                            ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[monthCntCol].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[monthCntCol].Value))
                            + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[monthCntCol].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[monthCntCol].Value))).ToString("N0");
                    }
                }

                if (!string.IsNullOrEmpty(monthAmtCol))
                {
                    // 7Jo Amt
                    geppoListDataGridView.Rows[i - 2].Cells[monthAmtCol].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                    // 11Jo Amt
                    geppoListDataGridView.Rows[i - 1].Cells[monthAmtCol].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                    // 7Jo + 11Jo Amt
                    geppoListDataGridView.Rows[i].Cells[monthAmtCol].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[monthAmtCol].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[monthAmtCol].Value);
                }

                if (!string.IsNullOrEmpty(monthNissuCol))
                {
                    //add KadoNissu
                    geppoListDataGridView.Rows[i - 2].Cells[monthNissuCol].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;
                }

                #region to be removed
                //switch (month)
                //{
                //    case "04":

                //        #region 4月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month4Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month4Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month4Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month4Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month4Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month4Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month4Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month4Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month4Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month4Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month4AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month4AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month4AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month4AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month4AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu4Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "05":

                //        #region 5月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month5Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month5Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month5Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month5Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month5Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month5Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month5Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month5Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month5Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month5Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month5AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month5AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month5AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month5AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month5AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu5Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "06":

                //        #region 6月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month6Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month6Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month6Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month6Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month6Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month6Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month6Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month6Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month6Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month6Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month6AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month6AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month6AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month6AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month6AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu6Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "07":

                //        #region 7月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month7Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month7Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month7Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month7Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month7Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month7Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month7Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month7Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month7Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month7Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month7AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month7AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month7AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month7AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month7AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu7Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "08":

                //        #region 8月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month8Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month8Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month8Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month8Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month8Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month8Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month8Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month8Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month8Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month8Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month8AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month8AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month8AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month8AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month8AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu8Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "09":

                //        #region 9月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month9Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month9Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month9Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month9Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month9Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month9Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month9Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month9Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month9Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month9Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month9AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month9AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month9AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month9AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month9AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu9Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "10":

                //        #region 10月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month10Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month10Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month10Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month10Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month10Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month10Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month10Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month10Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month10Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month10Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month10AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month10AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month10AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month10AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month10AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu10Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "11":

                //        #region 11月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month11Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month11Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month11Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month11Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month11Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month11Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month11Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month11Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month11Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month11Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month11AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month11AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month11AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month11AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month11AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu11Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "12":

                //        #region 12月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month12Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month12Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month12Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month12Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month12Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month12Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month12Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month12Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month12Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month12Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month12AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month12AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month12AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month12AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month12AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu12Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "01":

                //        #region 1月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month1Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month1Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month1Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month1Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month1Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month1Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month1Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month1Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month1Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month1Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month1AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month1AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month1AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month1AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month1AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu1Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "02":

                //        #region 2月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month2Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month2Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month2Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month2Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month2Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month2Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month2Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month2Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month2Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month2Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month2AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month2AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month2AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month2AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month2AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu2Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    case "03":

                //        #region 3月

                //        geppoListDataGridView.Rows[i - 2].Cells[Month3Col.Name].Value = (row.IsKensa7JoCntNull() || row.Kensa7JoCnt == 0) ? string.Empty : row.Kensa7JoCnt.ToString("N0");
                //        geppoListDataGridView.Rows[i - 1].Cells[Month3Col.Name].Value = (row.IsKensa11JoCntNull() || row.Kensa11JoCnt == 0) ? string.Empty : row.Kensa11JoCnt.ToString("N0");

                //        if (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month3Col.Name].Value.ToString()) && string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month3Col.Name].Value.ToString()))
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month3Col.Name].Value = string.Empty;
                //        }
                //        else
                //        {
                //            geppoListDataGridView.Rows[i].Cells[Month3Col.Name].Value =
                //                ((string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 2].Cells[Month3Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 2].Cells[Month3Col.Name].Value))
                //                + (string.IsNullOrEmpty(geppoListDataGridView.Rows[i - 1].Cells[Month3Col.Name].Value.ToString()) ? 0 : Convert.ToDecimal(geppoListDataGridView.Rows[i - 1].Cells[Month3Col.Name].Value))).ToString("N0");
                //        }

                //        geppoListDataGridView.Rows[i - 2].Cells[Month3AmtCol.Name].Value = row.IsKensa7JoAmtNull() ? 0 : row.Kensa7JoAmt;
                //        geppoListDataGridView.Rows[i - 1].Cells[Month3AmtCol.Name].Value = row.IsKensa11JoAmtNull() ? 0 : row.Kensa11JoAmt;
                //        geppoListDataGridView.Rows[i].Cells[Month3AmtCol.Name].Value = Convert.ToInt32(geppoListDataGridView.Rows[i - 2].Cells[Month3AmtCol.Name].Value) + Convert.ToInt32(geppoListDataGridView.Rows[i - 1].Cells[Month3AmtCol.Name].Value);

                //        //add KadoNissu
                //        geppoListDataGridView.Rows[i - 2].Cells[KadoNissu3Col.Name].Value = (row.IsKadoNissuNull() || row.KadoNissu == 0) ? 0 : row.KadoNissu;

                //        break;

                //        #endregion

                //    default:
                //        break;
                //}
                #endregion

                #endregion

                kensaiinCd = row.KensainCd;
                shishoNm = row.ShishoNm;

                isFirstRow = false;

                //add column ShishoCd, YakushokuFlg
                geppoListDataGridView.Rows[i - 2].Cells[ShishoCdCol.Name].Value = row.ShokuinShozokuShishoCd;
                geppoListDataGridView.Rows[i - 1].Cells[ShishoCdCol.Name].Value = row.ShokuinShozokuShishoCd;
                geppoListDataGridView.Rows[i].Cells[ShishoCdCol.Name].Value = row.ShokuinShozokuShishoCd;
                geppoListDataGridView.Rows[i - 2].Cells[YakushokuFlgCol.Name].Value = row.YakushokuFlg;
            }

            #region 合計 - 検査結果

            foreach (DataGridViewRow dgvRow in geppoListDataGridView.Rows)
            {
                // 合計
                if ((dgvRow.Cells[Month4Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month4Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month5Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month5Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month6Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month6Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month7Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month7Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month8Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month8Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month9Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month9Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month10Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month10Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month11Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month11Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month12Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month12Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month1Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month1Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month2Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month2Col.Name].Value.ToString()))
                    && (dgvRow.Cells[Month3Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month3Col.Name].Value.ToString())))
                {
                    dgvRow.Cells[TotalCol.Name].Value = string.Empty;
                }
                else
                {
                    decimal month4 = (dgvRow.Cells[Month4Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month4Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month4Col.Name].Value);
                    decimal month5 = (dgvRow.Cells[Month5Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month5Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month5Col.Name].Value);
                    decimal month6 = (dgvRow.Cells[Month6Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month6Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month6Col.Name].Value);
                    decimal month7 = (dgvRow.Cells[Month7Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month7Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month7Col.Name].Value);
                    decimal month8 = (dgvRow.Cells[Month8Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month8Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month8Col.Name].Value);
                    decimal month9 = (dgvRow.Cells[Month9Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month9Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month9Col.Name].Value);
                    decimal month10 = (dgvRow.Cells[Month10Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month10Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month10Col.Name].Value);
                    decimal month11 = (dgvRow.Cells[Month11Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month11Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month11Col.Name].Value);
                    decimal month12 = (dgvRow.Cells[Month12Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month12Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month12Col.Name].Value);
                    decimal month1 = (dgvRow.Cells[Month1Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month1Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month1Col.Name].Value);
                    decimal month2 = (dgvRow.Cells[Month2Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month2Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month2Col.Name].Value);
                    decimal month3 = (dgvRow.Cells[Month3Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month3Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month3Col.Name].Value);

                    decimal total = month4 + month5 + month6 + month7 + month8 + month9 + month10 + month11 + month12 + month1 + month2 + month3;

                    if (total == 0)
                    {
                        dgvRow.Cells[TotalCol.Name].Value = string.Empty;
                    }
                    else
                    {
                        dgvRow.Cells[TotalCol.Name].Value = total;
                    }
                }

                // 検査結果
                if ((dgvRow.Cells[Month4AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month4AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month5AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month5AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month6AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month6AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month7AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month7AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month8AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month8AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month9AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month9AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month10AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month10AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month11AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month11AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month12AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month12AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month1AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month1AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month2AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month2AmtCol.Name].Value.ToString()))
                    && (dgvRow.Cells[Month3AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month3AmtCol.Name].Value.ToString())))
                {
                    dgvRow.Cells[KingakuCol.Name].Value = string.Empty;
                }
                else
                {
                    decimal month4 = (dgvRow.Cells[Month4AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month4AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month4AmtCol.Name].Value);
                    decimal month5 = (dgvRow.Cells[Month5AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month5AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month5AmtCol.Name].Value);
                    decimal month6 = (dgvRow.Cells[Month6AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month6AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month6AmtCol.Name].Value);
                    decimal month7 = (dgvRow.Cells[Month7AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month7AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month7AmtCol.Name].Value);
                    decimal month8 = (dgvRow.Cells[Month8AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month8AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month8AmtCol.Name].Value);
                    decimal month9 = (dgvRow.Cells[Month9AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month9AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month9AmtCol.Name].Value);
                    decimal month10 = (dgvRow.Cells[Month10AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month10AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month10AmtCol.Name].Value);
                    decimal month11 = (dgvRow.Cells[Month11AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month11AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month11AmtCol.Name].Value);
                    decimal month12 = (dgvRow.Cells[Month12AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month12AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month12AmtCol.Name].Value);
                    decimal month1 = (dgvRow.Cells[Month1AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month1AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month1AmtCol.Name].Value);
                    decimal month2 = (dgvRow.Cells[Month2AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month2AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month2AmtCol.Name].Value);
                    decimal month3 = (dgvRow.Cells[Month3AmtCol.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[Month3AmtCol.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[Month3AmtCol.Name].Value);

                    decimal hantei = month4 + month5 + month6 + month7 + month8 + month9 + month10 + month11 + month12 + month1 + month2 + month3;

                    if (hantei == 0)
                    {
                        dgvRow.Cells[KingakuCol.Name].Value = string.Empty;
                    }
                    else
                    {
                        dgvRow.Cells[KingakuCol.Name].Value = hantei;
                    }
                }

                //get total KadoNissu 
                if ((dgvRow.Cells[KadoNissu4Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu4Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu5Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu5Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu6Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu6Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu7Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu7Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu8Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu8Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu9Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu9Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu10Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu10Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu11Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu11Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu12Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu12Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu1Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu1Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu2Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu2Col.Name].Value.ToString()))
                    && (dgvRow.Cells[KadoNissu3Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu3Col.Name].Value.ToString())))
                {
                    dgvRow.Cells[KadoNissuTotalCol.Name].Value = string.Empty;
                }
                else
                {
                    decimal kadoNissu4 = (dgvRow.Cells[KadoNissu4Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu4Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu4Col.Name].Value);
                    decimal kadoNissu5 = (dgvRow.Cells[KadoNissu5Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu5Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu5Col.Name].Value);
                    decimal kadoNissu6 = (dgvRow.Cells[KadoNissu6Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu6Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu6Col.Name].Value);
                    decimal kadoNissu7 = (dgvRow.Cells[KadoNissu7Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu7Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu7Col.Name].Value);
                    decimal kadoNissu8 = (dgvRow.Cells[KadoNissu8Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu8Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu8Col.Name].Value);
                    decimal kadoNissu9 = (dgvRow.Cells[KadoNissu9Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu9Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu9Col.Name].Value);
                    decimal kadoNissu10 = (dgvRow.Cells[KadoNissu10Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu10Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu10Col.Name].Value);
                    decimal kadoNissu11 = (dgvRow.Cells[KadoNissu11Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu11Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu11Col.Name].Value);
                    decimal kadoNissu12 = (dgvRow.Cells[KadoNissu12Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu12Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu12Col.Name].Value);
                    decimal kadoNissu1 = (dgvRow.Cells[KadoNissu1Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu1Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu1Col.Name].Value);
                    decimal kadoNissu2 = (dgvRow.Cells[KadoNissu2Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu2Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu2Col.Name].Value);
                    decimal kadoNissu3 = (dgvRow.Cells[KadoNissu3Col.Name].Value == null || string.IsNullOrEmpty(dgvRow.Cells[KadoNissu3Col.Name].Value.ToString())) ? 0 : Convert.ToDecimal(dgvRow.Cells[KadoNissu3Col.Name].Value);

                    decimal kadoNissuTotal = kadoNissu4 + kadoNissu5 + kadoNissu6 + kadoNissu7 + kadoNissu8 + kadoNissu9 + kadoNissu10 + kadoNissu11 + kadoNissu12 + kadoNissu1 + kadoNissu2 + kadoNissu3;

                    dgvRow.Cells[KadoNissuTotalCol.Name].Value = (kadoNissuTotal == 0) ? string.Empty : kadoNissuTotal.ToString();

                }


            }
            #endregion
        }
        #endregion

        #region CreatePrintKensainGeppo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreatePrintKensainGeppo
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensainGeppoTblDataSet.PrintKensainGeppoListDataTable CreatePrintKensainGeppo()
        {
            KensainGeppoTblDataSet.PrintKensainGeppoListDataTable printKensainGeppoListDT = new KensainGeppoTblDataSet.PrintKensainGeppoListDataTable();
            

            for (int i = 0; i < geppoListDataGridView.RowCount; i++)
            {
                DataGridViewRow row = geppoListDataGridView.Rows[i];

                if (row.Cells[SyokuinCdCol.Name].Value != null && row.Cells[SyokuinCdCol.Name].Value.ToString() != "")
                {
                    KensainGeppoTblDataSet.PrintKensainGeppoListRow newRow = printKensainGeppoListDT.NewPrintKensainGeppoListRow();

                    DataGridViewRow rowTotal = geppoListDataGridView.Rows[i + 2];

                    newRow.ShokuinCd = row.Cells[SyokuinCdCol.Name].Value.ToString();
                    newRow.ShishoCd = row.Cells[ShishoCdCol.Name].Value.ToString();
                    newRow.KensainNm = row.Cells[KensainNmCol.Name].Value.ToString();
                    newRow.Total = rowTotal.Cells[TotalCol.Name].Value.ToString();
                    newRow.KadoNissu= row.Cells[KadoNissuTotalCol.Name].Value.ToString();
                    newRow.YakushokuFlg = row.Cells[YakushokuFlgCol.Name].Value.ToString();

                    printKensainGeppoListDT.AddPrintKensainGeppoListRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetAdded();
                }
            }

            return printKensainGeppoListDT;
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
        /// 2014/10/24  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            //set control domain
            //対象範囲（開始）
            taisyoYMFromTextBox.SetStdControlDomain(Zynas.Control.Common.ZControlDomain.ZT_NEN_GETSU, 6);

            //対象範囲（終了）
            taisyoYMToTextBox.SetStdControlDomain(Zynas.Control.Common.ZControlDomain.ZT_NEN_GETSU, 6);

            geppoListDataGridView.SetStdControlDomain(ShisyoCol.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NAME, 10);
            geppoListDataGridView.SetStdControlDomain(SyokuinCdCol.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_CD, 3);
            geppoListDataGridView.SetStdControlDomain(KensainNmCol.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NAME, 20);
            geppoListDataGridView.SetStdControlDomain(KbnCol.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NAME, 10);
            geppoListDataGridView.SetStdControlDomain(Month4Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month5Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month6Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month7Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month8Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month9Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month10Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month11Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month12Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month1Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month2Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(Month3Col.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(TotalCol.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 4);
            geppoListDataGridView.SetStdControlDomain(KingakuCol.Index, Zynas.Control.Common.ZControlDomain.ZG_STD_NUM, 10);
        }
        #endregion

        #endregion

    }
    #endregion
}
