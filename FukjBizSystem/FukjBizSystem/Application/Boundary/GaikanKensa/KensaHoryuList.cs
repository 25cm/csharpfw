using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using FukjBizSystem.Control;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaHoryuListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaHoryuListForm : FukjBaseForm
    {
        #region 置換文字列

        /// <summary>
        /// Parts of genkyo and jokyo file name
        /// </summary>
        private const string GENKYOFILE_SUFFIX = "_現況報告書.xlsx";
        private const string JOKYOFILE_SUFFIX = "_状況把握票.xlsx";

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

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaHoryuListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaHoryuListForm()
        {
            InitializeComponent();

            // Control domain
            // TextBox
            kyokaiFrom1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiFrom2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiFrom3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            kyokaiTo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiTo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiTo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            // Dgv
            horyuListDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            horyuListDataGridView.SetStdControlDomain(kyokaiNoCol.Index, ZControlDomain.ZG_STD_NAME, 12, DataGridViewContentAlignment.MiddleCenter);
            horyuListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            horyuListDataGridView.SetStdControlDomain(kensainCol.Index, ZControlDomain.ZG_STD_NAME, 20);
            horyuListDataGridView.SetStdControlDomain(horyuRiyuCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            horyuListDataGridView.SetStdControlDomain(horyuNaiyoCol.Index, ZControlDomain.ZG_STD_NAME, 80);
            horyuListDataGridView.SetStdControlDomain(kakuninDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            horyuListDataGridView.SetStdControlDomain(jikaiKakuninDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            horyuListDataGridView.SetStdControlDomain(genkyoHokokuCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);
            horyuListDataGridView.SetStdControlDomain(jokyoHaakuCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);
        }
        #endregion

        #region イベント

        #region KensaHoryuListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaHoryuListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaHoryuListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default value
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

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Clear all input
                ClearSearchCond();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック + 関連チェック
                if (!DataCheck()) return;

                // Do search
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

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (horyuListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // Call to 009-009
                KensaHoryuShosaiForm frm = new KensaHoryuShosaiForm(horyuListDataGridView.CurrentRow.Cells[kyokaiNoCol.Name].Value.ToString());
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No record was found
                if (horyuListDataGridView.Rows.Count == 0) return;

                string outputFilename = "検査保留一覧";
                Common.Common.FlushGridviewDataToExcel(this.horyuListDataGridView, outputFilename);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
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

        #region horyuListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： horyuListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void horyuListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid user click to header row
                if (e.RowIndex > -1)
                {
                    torokuButton.PerformClick();
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

        #region KensaHoryuListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaHoryuListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaHoryuListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.Focus();
                        torokuButton.PerformClick();
                        break;
                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;
                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #region KyokaiTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KyokaiTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KyokaiTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ZTextBox kyokaiTextBox = sender as ZTextBox;
                Common.Common.PaddingZeroForTextBoxLeave(kyokaiTextBox,
                    kyokaiFrom1TextBox,
                    kyokaiTo1TextBox,
                    kyokaiFrom2TextBox,
                    kyokaiTo2TextBox,
                    kyokaiFrom3TextBox,
                    kyokaiTo3TextBox);
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
        /// 2014/08/27  AnhNV　　    新規作成
        /// 2014/10/08　AnhNV　　    基本設計書_009_008_画面_KensaHoryuList.Ver1.03
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
            alInput.ShokuinKensainFlg = "1";
            alInput.ShokuinTaishokuFlg = "0";   //2015.01.29 add kiyokuni
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検査員(3)
            Utility.Utility.SetComboBoxList(kensainComboBox, alOutput.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", true);

            // 支所(5)
            //Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
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
        /// 2014/08/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Refresh the dgv
            horyuListDataGridView.DataSource = null;
            horyuListDataGridView.Rows.Clear();
            horyuListDataGridView.AutoGenerateColumns = false;

            ISearchBtnClickALInput searchInput = new SearchBtnClickALInput();
            searchInput.SearchCond = SetSearchCond();
            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(searchInput);

            // No records was found
            if (alOutput.KensaHoryuListDataTable.Count == 0)
            {
                // 検索結果件数
                srhListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            // 検索結果件数
            srhListCountLabel.Text = string.Concat(alOutput.KensaHoryuListDataTable.Count, "件");

            // Binding source to dgv
            horyuListDataGridView.DataSource = MakeDgvSource(alOutput.KensaHoryuListDataTable);
            ColorDgv();
        }
        #endregion

        #region ClearSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchCond()
        {
            // 対象区分 保留入力済(2)
            horyuRadioButton.Checked = true;

            // 検査員(3)
            kensainComboBox.SelectedIndex = 0;

            // 支所
            shishoComboBox.SelectedIndex = 0;

            // 協会No（開始） (保健所コード)(4)
            kyokaiFrom1TextBox.Text = string.Empty;

            // 協会No（開始） (年度)(5)
            kyokaiFrom2TextBox.Text = string.Empty;

            // 協会No（開始） (連番)(6)
            kyokaiFrom3TextBox.Text = string.Empty;

            // 協会No（終了） (保健所コード)(7)
            kyokaiTo1TextBox.Text = string.Empty;

            // 協会No（終了） (年度)(8)
            kyokaiTo2TextBox.Text = string.Empty;

            // 協会No（終了） (連番)(9)
            kyokaiTo3TextBox.Text = string.Empty;
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  AnhNV　　    新規作成
        /// 2014/11/11  AnhNV　　    基本設計書_009_008_画面_KensaHoryuList_Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            #region to be removed
            //// 協会No（開始） (保健所コード)
            //if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) && kyokaiFrom1TextBox.Text.Length != 2)
            //{
            //    errMsg.AppendLine("協会No（開始） (保健所コード)は2桁で入力して下さい。");
            //}

            //// 協会No（開始） (年度)
            //if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) && kyokaiFrom2TextBox.Text.Length != 2)
            //{
            //    errMsg.AppendLine("協会No（開始） (年度)は2桁で入力して下さい。");
            //}

            //// 協会No（開始） (連番)
            //if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) && kyokaiFrom3TextBox.Text.Length != 6)
            //{
            //    errMsg.AppendLine("協会No（開始） (連番)は6桁で入力して下さい。");
            //}

            //// 協会No（終了） (保健所コード)
            //if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text) && kyokaiTo1TextBox.Text.Length != 2)
            //{
            //    errMsg.AppendLine("協会No（終了） (保健所コード)は2桁で入力して下さい。");
            //}

            //// 協会No（終了） (年度)
            //if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text) && kyokaiTo2TextBox.Text.Length != 2)
            //{
            //    errMsg.AppendLine("協会No（終了） (年度)は2桁で入力して下さい。");
            //}

            //// 協会No（終了） (連番)
            //if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text) && kyokaiTo3TextBox.Text.Length != 6)
            //{
            //    errMsg.AppendLine("協会No（終了） (連番)は6桁で入力して下さい。");
            //}
            // No error in checking length
            //lenOK = !string.IsNullOrEmpty(errMsg.ToString()) ? false : true;

            #endregion

            // 協会No（開始）> 協会No（終了）?
            if (!Utility.Utility.IsValidKyokaiNo(kyokaiFrom1TextBox, kyokaiFrom2TextBox, kyokaiFrom3TextBox, kyokaiTo1TextBox, kyokaiTo2TextBox, kyokaiTo3TextBox))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査番号の大小関係を確認してください。");
            }

            #region to be removed
            //// 協会No（開始）
            //string kyokaiFrom = string.Concat(string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) ? "00" : kyokaiFrom1TextBox.Text.PadLeft(2, '0'),
            //    string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) ? "00" : kyokaiFrom2TextBox.Text.PadLeft(2, '0'),
            //    string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) ? "000000" : kyokaiFrom3TextBox.Text.PadLeft(6, '0'));
            //// 協会No（終了）
            //string kyokaiTo = string.Concat(string.IsNullOrEmpty(kyokaiTo1TextBox.Text) ? "99" : kyokaiTo1TextBox.Text.PadLeft(2, '0'),
            //    string.IsNullOrEmpty(kyokaiTo2TextBox.Text) ? "99" : kyokaiTo2TextBox.Text.PadLeft(2, '0'),
            //    string.IsNullOrEmpty(kyokaiTo3TextBox.Text) ? "999999" : kyokaiTo3TextBox.Text.PadLeft(6, '0'));

            //// 協会No（開始）> 協会No（終了）
            //if (lenOK && Convert.ToDecimal(kyokaiFrom) > Convert.ToDecimal(kyokaiTo))
            //{
            //    errMsg.AppendLine("範囲指定が正しくありません。協会Noの大小関係を確認してください。");
            //}
            #endregion

            // An eror occurred
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23  AnhNV　　    新規作成
        /// 2014/10/08　AnhNV　　    基本設計書_009_008_画面_KensaHoryuList.Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblSearchCond SetSearchCond()
        {
            KensaIraiTblSearchCond searchCond = new KensaIraiTblSearchCond();

            // 対象区分 保留入力済(2)
            searchCond.KensaIraiHoryuKbn = horyuRadioButton.Checked ? "1" : string.Empty;

            // 検査員(3)
            searchCond.KensaIraiKensaSekininsha = kensainComboBox.SelectedIndex > 0 ? kensainComboBox.SelectedValue.ToString() : string.Empty;

            // 支所(5)
            searchCond.ShishoCd = shishoComboBox.SelectedIndex > 0 ? shishoComboBox.SelectedValue.ToString() : string.Empty;

            // 協会No（開始） (保健所コード)(4)
            searchCond.HokenjoCdFrom = kyokaiFrom1TextBox.Text;

            // 協会No（開始） (年度)(5)
            searchCond.NendoFrom = kyokaiFrom2TextBox.Text;

            // 協会No（開始） (連番)(6)
            searchCond.RenbanFrom =  kyokaiFrom3TextBox.Text;

            // 協会No（終了） (保健所コード)(7)
            searchCond.HokenjoCdTo = kyokaiTo1TextBox.Text;

            // 協会No（終了） (年度)(8)
            searchCond.NendoTo = kyokaiTo2TextBox.Text;

            // 協会No（終了） (連番)(9)
            searchCond.RenbanTo = kyokaiTo3TextBox.Text;

            return searchCond;
        }
        #endregion

        #region MakeDgvSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeDgvSource
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  AnhNV　　    新規作成
        /// 2014/10/30  AnhNV　　    基本設計書_009_008_画面_KensaHoryuList_Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaHoryuDataSet.KensaHoryuListDataTable MakeDgvSource(KensaHoryuDataSet.KensaHoryuListDataTable rawSource)
        {
            string genkyoFile = string.Empty;
            string genkyoFolder = string.Empty;
            string fullGenkyoPath = string.Empty;
            string jokyoFile = string.Empty;
            string jokyoFolder = string.Empty;
            string fullJokyoPath = string.Empty;

            try
            {
                // Connect to server
                Utility.SharedFolderUtility.Connect();

                // 現況報告書、状況把握書の出力済チェックを行う
                foreach (KensaHoryuDataSet.KensaHoryuListRow row in rawSource)
                {
                    // 現況報告書
                    genkyoFile = string.Concat(row.KensaIraiHokenjoCd, "-", row.KensaIraiNendo, "-", row.KensaIraiRenban, GENKYOFILE_SUFFIX);
                    genkyoFolder = Utility.SharedFolderUtility.GetKensaIraiKeyFolder(
                        Utility.Constants.ConstKbnConstanst.CONST_KBN_010,
                        Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002,
                        row.KensaIraiHoteiKbn,
                        row.KensaIraiHokenjoCd,
                        row.KensaIraiNendo,
                        row.KensaIraiRenban);

                    fullGenkyoPath = Path.Combine(genkyoFolder, genkyoFile);
                    if (File.Exists(fullGenkyoPath))
                    {
                        row.GenkyoHokoku = "○";
                    }

                    // 状況把握票
                    jokyoFile = string.Concat(row.KensaIraiHokenjoCd, "-", row.KensaIraiNendo, "-", row.KensaIraiRenban, JOKYOFILE_SUFFIX);
                    jokyoFolder = Utility.SharedFolderUtility.GetKensaIraiKeyFolder(
                        Utility.Constants.ConstKbnConstanst.CONST_KBN_010,
                        Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001,
                        row.KensaIraiHoteiKbn,
                        row.KensaIraiHokenjoCd,
                        row.KensaIraiNendo,
                        row.KensaIraiRenban);

                    fullJokyoPath = Path.Combine(jokyoFolder, jokyoFile);
                    if (File.Exists(fullJokyoPath))
                    {
                        row.JokyoHaaku = "○";
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                // Disconnect from server
                Utility.SharedFolderUtility.Disconnect();
            }

            return rawSource;
        }
        #endregion

        #region ColorDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ColorDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ColorDgv()
        {
            foreach (DataGridViewRow dgvr in horyuListDataGridView.Rows)
            {
                if (dgvr.Cells[Color.Name].Value.ToString() == "1")
                {
                    dgvr.Cells[jikaiKakuninDtCol.Name].Style.ForeColor = System.Drawing.Color.Red;
                }
            }
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
        /// 2014/10/13　AnhNV　　    新規作成
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
