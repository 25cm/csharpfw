using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.YachoTorikomi;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YachoTorikomiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04　HieuNH　　　新規作成
    /// 2014/12/19  宗          受入試験結果対応
    /// 2014/12/29  小松        法定検査と計量証明で検査項目コンボの内容を切替
    /// 2015/01/09  小松        確認検査取込処理追加（2回目以降の取込分）
    /// 2015/01/22  小松　　　　クリアボタン押下時は初期値を設定
    ///                         検査区分を切り替えた時の処理を正しく修正
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YachoTorikomiForm : FukjBaseForm
    {
        #region 定義(public)

        #endregion

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
        private DateTime _currentDateTime;

        /// <summary>
        /// Data source for hoteiKensaListDataGridView
        /// </summary>
        private DataTable _hoteiKensaListDataTable = new DataTable();

        /// <summary>
        /// Data source for keiryoKensaListDataGridView
        /// </summary>
        private DataTable _keiryoShomeiListDataTable = new DataTable();

        /// <summary>
        /// Previous KensaRadioButton checked
        /// </summary>
        private RadioButton _previousKensaRadioButtonChecked;

        /// <summary>
        /// ShokuinShozokuShishoCd
        /// </summary>
        private string shozokuShishoLoginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        // 20151119 sou Start
        /// <summary>
        /// 法定検査用水質試験項目マスタ
        /// </summary>
        //private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable HoteiSuishitsuShikenKoumokuMstDataTable;
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiSuishitsuShikenKoumokuMstSelectListDataTable;
        /// <summary>
        /// 計量証明用水質試験項目マスタ
        /// </summary>
        //private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable KeiryoSuishitsuShikenKoumokuMstDataTable;
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable KeiryoSuishitsuShikenKoumokuMstSelectListDataTable;
        // 20151119 sou End
        // 20150129 sou Start
        /// <summary>
        /// 法定検査用外観試験項目マスタ
        /// </summary>
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiGaikanShikenKoumokuMstSelectListDataTable;
        // 20150129 sou End

        // 20151119 sou Start
        /// <summary>
        /// 水質試験項目コード
        /// </summary>
        // 外観
        private string gaikanCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_027);
        // 臭気
        private string shukiCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_028);
        // 亜硝酸性窒素(定性)
        private string no2nCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_030);
        // 硝酸性窒素(定性)
        private string no3nCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_031);
        // 20151119 sou End
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YachoTorikomiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　HieuNH　　　新規作成
        /// 2014/12/19  宗          受入試験結果対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public YachoTorikomiForm()
            : base()
        {
            InitializeComponent();
            SetControlDomain();
            keiryoShomeiListDataGridView.Location = hoteiKensaListDataGridView.Location;
            keiryoShomeiListDataGridView.Height = hoteiKensaListDataGridView.Height;
        }
        #endregion

        #region イベント

        #region YachoTorikomiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YachoTorikomiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2015/01/29  宗          外観検査用の選択リストを追加で取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YachoTorikomiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = true;
                this._defaultSearchPanelTop = this.torikomiPanel.Top;
                this._defaultSearchPanelHeight = this.torikomiPanel.Height;
                this._defaultListPanelTop = this.listPanel.Top;
                this._defaultListPanelHeight = this.listPanel.Height;

                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

                // 支所 (8)
                //Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
                Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
                shishoComboBox.SelectedValue = shozokuShishoLoginUser;

                // 検査項目用コンボボックス値取得
                // 20151119 sou Start
                //HoteiSuishitsuShikenKoumokuMstDataTable = alOutput.HoteiSuishitsuShikenKoumokuMstDataTable;
                //KeiryoSuishitsuShikenKoumokuMstDataTable = alOutput.KeiryoSuishitsuShikenKoumokuMstDataTable;
                HoteiSuishitsuShikenKoumokuMstSelectListDataTable = alOutput.HoteiSuishitsuShikenKoumokuMstSelectListDataTable;
                KeiryoSuishitsuShikenKoumokuMstSelectListDataTable = alOutput.KeiryoSuishitsuShikenKoumokuMstSelectListDataTable;
                // 20151119 sou End
                // 20150129 sou Start
                HoteiGaikanShikenKoumokuMstSelectListDataTable = alOutput.HoteiGaikanShikenKoumokuMstSelectListDataTable;
                // 20150129 sou End

                // 検査項目 (9)
                // 20151119 sou Start
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                // 20151119 sou End

                hoteiKensaListDataGridView.AutoGenerateColumns = false;
                hoteiKensaListDataGridView.DataSource = _hoteiKensaListDataTable;

                keiryoShomeiListDataGridView.AutoGenerateColumns = false;
                keiryoShomeiListDataGridView.DataSource = _keiryoShomeiListDataTable;

                _currentDateTime = Common.Common.GetCurrentTimestamp();
                iraiNendoTextBox.Text = (Utility.DateUtility.GetNendo(_currentDateTime)).ToString();
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

        #region torikomiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torikomiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torikomiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoTorikomi();
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
        /// 2014/12/05　HieuNH　　　新規作成
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
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ClearSearchPanel();
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
        /// 2014/12/04　HieuNH　　　新規作成
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
                    this.torikomiPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.listPanel,
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

        #region gaikanKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gaikanKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2015/01/29  宗          水質検査と外観検査で選択リストを切り替える
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gaikanKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDisplayGridview(sender as RadioButton);

                // 検査項目 (法定検査用)
                // 20150129 sou Start
                #region to be removed
                //// 20151119 sou Start
                ////Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                //// 20151119 sou End
                #endregion
                Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiGaikanShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                // 20150129 sou End
                kensaKomokuComboBox.SelectedIndex = 0;
                // 野帳ファイルパス
                torikomiFilePathTextBox.Text = string.Empty;
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

        #region keiryoShomeiKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoShomeiKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiryoShomeiKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDisplayGridview(sender as RadioButton);

                // 検査項目 (計量証明用)
                // 20151119 sou Start
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, KeiryoSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                Utility.Utility.SetComboBoxList(kensaKomokuComboBox, KeiryoSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                // 20151119 sou End
                kensaKomokuComboBox.SelectedIndex = 0;
                // 野帳ファイルパス
                torikomiFilePathTextBox.Text = string.Empty;
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

        #region suishitsuKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDisplayGridview(sender as RadioButton);

                // 検査項目 (法定検査用)
                // 20151119 sou Start
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                // 20151119 sou End
                kensaKomokuComboBox.SelectedIndex = 0;
                // 野帳ファイルパス
                torikomiFilePathTextBox.Text = string.Empty;
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

        #region YachoTorikomi_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： YachoTorikomi_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void YachoTorikomi_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F6:
                        torikomiButton.Focus();
                        torikomiButton.PerformClick();
                        break;
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F12:
                        closeButton.Focus();
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

        #region fileSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： fileSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　HieuNH　　　新規作成
        /// 2014/12/19  宗          受入試験結果対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void fileSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Create an instance of the open file dialog box.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set filter options and filter index.
                openFileDialog1.Filter = "検索対象の拡張子 (.xls)|*.xls;*.xlsx;*.csv";
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = false;

                // Call the ShowDialog method to show the dialog box.
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    torikomiFilePathTextBox.Text = openFileDialog1.FileName.ToString();
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

        #region keiryoShomeiListDataGridView_DataBindingComplete
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoShomeiListDataGridView_DataBindingComplete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiryoShomeiListDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in keiryoShomeiListDataGridView.Rows)
                {
                    if (row.Cells[keiryoTorikomiKekkaCol.Index].Value != null && row.Cells[keiryoTorikomiKekkaCol.Index].Value.Equals("取込エラー"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
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

        #region hoteiKensaListDataGridView_DataBindingComplete
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoteiKensaListDataGridView_DataBindingComplete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoteiKensaListDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in hoteiKensaListDataGridView.Rows)
                {
                    if (row.Cells[hoteiTorikomiKekkaCol.Index].Value != null && row.Cells[hoteiTorikomiKekkaCol.Index].Value.Equals("取込エラー"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
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
        
        #endregion
        
        #region メソッド(private)

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2014/12/20　小松  　　　数値は右詰め、コード・名称は左詰め
        /// 2015/01/15　小松  　　　測定値（decimal(9,3)）、温度（decimal(5,3)）の桁数設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            iraiNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, HorizontalAlignment.Right);

            hoteiKensaListDataGridView.SetStdControlDomain(hoteiRowNoCol.Index, ZControlDomain.ZG_STD_NUM, -1, DataGridViewContentAlignment.MiddleRight);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiSuishitsuKensaIraiNoCol.Index, ZControlDomain.ZG_STD_CD, 6, DataGridViewContentAlignment.MiddleRight);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiSokuteiValueCol.Index, ZControlDomain.ZG_STD_NUM, 9, 3, InputValidateUtility.SignFlg.Positive);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiSokuteiHaniCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiOndoCol.Index, ZControlDomain.ZG_STD_NUM, 5, 3, InputValidateUtility.SignFlg.Positive);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiHoteiKbnCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiKensaNoCol.Index, ZControlDomain.ZG_STD_CD, -1, DataGridViewContentAlignment.MiddleLeft);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiTorikomiKekkaCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiTorikomiErrorCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);

            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoRowNoCol.Index, ZControlDomain.ZG_STD_NUM, -1, DataGridViewContentAlignment.MiddleRight);
            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoSuishitsuKensaIraiNoCol.Index, ZControlDomain.ZG_STD_CD, 6, DataGridViewContentAlignment.MiddleRight);
            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoSokuteiValueCol.Index, ZControlDomain.ZG_STD_NUM, 9, 3, InputValidateUtility.SignFlg.Positive);
            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoSokuteiHaniCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoSokuteiKekkaCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoTorikomiKekkaCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoTorikomiErrorCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            keiryoShomeiListDataGridView.SetStdControlDomain(keiryoKensaNoCol.Index, ZControlDomain.ZG_STD_CD, -1, DataGridViewContentAlignment.MiddleLeft);
        }
        #endregion

        #region ClearSearchPanel
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchPanel
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// 2015/01/22  小松　　　　クリアボタン押下時は初期値を設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchPanel()
        {
            // 水質検査デフォルト
            suishitsuKensaRadioButton.Checked = true;
            //iraiNendoTextBox.Text = string.Empty;
            _currentDateTime = Common.Common.GetCurrentTimestamp();
            iraiNendoTextBox.Text = (Utility.DateUtility.GetNendo(_currentDateTime)).ToString();
            //shishoComboBox.SelectedIndex = 0;
            shishoComboBox.SelectedValue = shozokuShishoLoginUser;
            kensaKomokuComboBox.SelectedIndex = 0;
            torikomiFilePathTextBox.Text = string.Empty;
            normalKensaRadioButton.Checked = true;

            hoteiKensaListDataGridView.Visible = true;
            _hoteiKensaListDataTable.Clear();
            keiryoShomeiListDataGridView.Visible = false;
            _keiryoShomeiListDataTable.Clear();
            // 検索結果件数
            listCountLabel.Text = "0件";
        }
        #endregion

        #region SetDisplayGridview
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayGridview
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2014/12/19  宗          受入試験結果対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayGridview(RadioButton rb)
        {
            if (rb != null)
            {
                if (rb.Checked)
                {
                    // 検査種別：外観、水質
                    if (rb.Name.Equals(gaikanKensaRadioButton.Name) || rb.Name.Equals(suishitsuKensaRadioButton.Name))
                    {

                            hoteiKensaListDataGridView.Visible = true;
                            _hoteiKensaListDataTable.Clear();
                            keiryoShomeiListDataGridView.Visible = false;
                            _keiryoShomeiListDataTable.Clear();
                            // 検索結果件数
                            listCountLabel.Text = "0件";
                    }
                    else if (rb.Name.Equals(keiryoShomeiKensaRadioButton.Name))
                    {

                            hoteiKensaListDataGridView.Visible = false;
                            _hoteiKensaListDataTable.Clear();
                            keiryoShomeiListDataGridView.Visible = true;
                            _keiryoShomeiListDataTable.Clear();
                            // 検索結果件数
                            listCountLabel.Text = "0件";
                    }
                }
                else
                {
                    _previousKensaRadioButtonChecked = rb;
                }
            }
        }
        #endregion

        #region RelationCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RelationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2015/01/29  宗          支所の入力確認を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool RelationCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            if (string.IsNullOrEmpty(shishoComboBox.Text))
                errMsg.AppendLine("支所が入力されていません。");
            if (string.IsNullOrEmpty(iraiNendoTextBox.Text))
                errMsg.AppendLine("年度が入力されていません。");
            if (shishoComboBox.SelectedIndex == 0)
                errMsg.AppendLine("支所が選択されていません。");
            if (kensaKomokuComboBox.SelectedIndex == 0)
                errMsg.AppendLine("検査項目が選択されていません。");
            if (string.IsNullOrEmpty(torikomiFilePathTextBox.Text))
                errMsg.AppendLine("取込ファイルが選択されていません。");

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SelectFileCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SelectFileCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool SelectFileCheck()
        {
            if (!File.Exists(torikomiFilePathTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("指定された取込ファイルが存在しません。{0}", torikomiFilePathTextBox.Text));
                return false;
            }
            return true;
        }
        #endregion

        #region DoTorikomi
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoTorikomi
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoTorikomi()
        {
            _hoteiKensaListDataTable.Clear();
            _keiryoShomeiListDataTable.Clear();
            // 検索結果件数
            listCountLabel.Text = "0件";

            if (!RelationCheck())
                return;
            if (!SelectFileCheck())
                return;

            ITorikomiBtnClickALInput alInput = new TorikomiBtnClickALInput();
            MakeALInput(alInput);
            // ITorikomiBtnClickALOutput alOutput = new TorikomiBtnClickApplicationLogic().Execute(alInput);
            TorikomiBtnClickApplicationLogic al = new TorikomiBtnClickApplicationLogic();
            
            // 取込チェック
            ITorikomiBtnClickALOutput alOutput = al.TorikomiCheck(alInput);
            if (alOutput.ErrorCode != 0)
            {
                if (alOutput.ErrorCode == 1)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("指定ファイルの列数が不一致です。{0}", torikomiFilePathTextBox.Text));
                    return;
                }
                else if (alOutput.ErrorCode == 11)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("通常検査が行われていないため、確認検査の取込は行えません。\n確認検査の取込は通常検査の取込後に行う必要があります。{0}", torikomiFilePathTextBox.Text));
                    return;
                }
                else if (alOutput.ErrorCode == 12 || alOutput.ErrorCode == 13)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "指定の野帳ファイルに既に登録済のレコードが存在します。\n上書きで取込を実行しますがよろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrorMessage);
                    return;
                }
            }

            // 取込実行
            alOutput = al.Execute(alInput);
            if (alOutput.ErrorCode != 0)
            {
                if (alOutput.ErrorCode == 1)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("指定ファイルの列数が不一致です。{0}", torikomiFilePathTextBox.Text));
                }
                else if (alOutput.ErrorCode == 2)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrorMessage);
                }
                else
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrorMessage);
                }
                return;
            }
            else
            {
                if (gaikanKensaRadioButton.Checked || suishitsuKensaRadioButton.Checked)
                {
                    _hoteiKensaListDataTable = alOutput.YachoTorikomiDataTable;
                    hoteiKensaListDataGridView.AutoGenerateColumns = false;
                    hoteiKensaListDataGridView.DataSource = _hoteiKensaListDataTable;
                    listCountLabel.Text = _hoteiKensaListDataTable == null? "0件": _hoteiKensaListDataTable.Rows.Count.ToString() + "件";
                }
                else
                {
                    _keiryoShomeiListDataTable = alOutput.YachoTorikomiDataTable;
                    keiryoShomeiListDataGridView.AutoGenerateColumns = false;
                    keiryoShomeiListDataGridView.DataSource = _keiryoShomeiListDataTable;
                    listCountLabel.Text = _keiryoShomeiListDataTable == null ? "0件" : _keiryoShomeiListDataTable.Rows.Count.ToString() + "件";

                    //20150119 sou Start
                    // 測定値と範囲の表示＆非表示切り替え
                    if ((kensaKomokuComboBox.SelectedValue.ToString() == gaikanCd)
                        || (kensaKomokuComboBox.SelectedValue.ToString() == shukiCd)
                        || (kensaKomokuComboBox.SelectedValue.ToString() == no2nCd)
                        || (kensaKomokuComboBox.SelectedValue.ToString() == no3nCd))
                    {
                        keiryoShomeiListDataGridView.Columns[keiryoSokuteiValueCol.Index].Visible = false;
                        keiryoShomeiListDataGridView.Columns[keiryoSokuteiHaniCol.Index].Visible = false;
                    }
                    else
                    {
                        keiryoShomeiListDataGridView.Columns[keiryoSokuteiValueCol.Index].Visible = true;
                        keiryoShomeiListDataGridView.Columns[keiryoSokuteiHaniCol.Index].Visible = true;
                    }
                    //20150119 sou End
                }

                if (alOutput.YachoTorikomiDataTable.Count > 0)
                {
                    if (alOutput.YachoTorikomiDataTable.Select("TorikomiKekka='取込エラー'").Length == 0)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "取込処理が完了しました。");
                    }
                    else
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Warning, "取込処理が完了しました。\n取込エラーが含まれます。");
                    }
                }
                else
                {
                    MessageForm.Show2(MessageForm.DispModeType.Warning, "取込データがありません。");
                }
            }
        }
        #endregion

        #region MakeALInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeALInput
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alInput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeALInput(ITorikomiBtnClickALInput alInput)
        {
            // 検査種別
            if (gaikanKensaRadioButton.Checked)
            {
                alInput.KensaShubetsu = "3";
                alInput.RadioBtnNm = gaikanKensaRadioButton.Text;
            }
            else if (suishitsuKensaRadioButton.Checked)
            {
                alInput.KensaShubetsu = "2";
                alInput.RadioBtnNm = suishitsuKensaRadioButton.Text;
            }
            else
            {
                alInput.KensaShubetsu = "1";
                alInput.RadioBtnNm = keiryoShomeiKensaRadioButton.Text;
            }

            // 依頼年度
            alInput.IraiNendo = iraiNendoTextBox.Text;

            // 支所CD
            alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();

            // 検査項目
            alInput.KoumokuCd = kensaKomokuComboBox.SelectedValue.ToString();

            // 取込ファイルパス名
            alInput.ExcelPath = torikomiFilePathTextBox.Text;

            alInput.ShishoNm = shishoComboBox.Text;

            alInput.SeishikiNm = kensaKomokuComboBox.Text;

            // 取込種別
            if (normalKensaRadioButton.Checked)
            {
                // 通常検査
                alInput.TorikomiKensa = "0";
            }
            else
            {
                // 確認検査
                alInput.TorikomiKensa = "1";
            }

        }
        #endregion

        #endregion


    }
    #endregion
}
