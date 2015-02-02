using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.JokasoDaichoSyukeiList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoDaichoSyukeiListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JokasoDaichoSyukeiListForm : FukjBaseForm
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

        /// <summary>
        /// rdChecked
        /// </summary>
        private RadioButton _rdChecked = new RadioButton();

        /// <summary>
        /// jokasoDaichoSyukeiListDT
        /// </summary>
        private JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable _jokasoDaichoSyukeiListDT = new JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable();
        
        /// <summary>
        /// isResetForm
        /// </summary>
        private bool _isResetForm = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JokasoDaichoSyukeiListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JokasoDaichoSyukeiListForm()
        {
            InitializeComponent();
            shukeiKaishiNendoTextBox.SetStdControlDomain(Zynas.Control.Common.ZControlDomain.ZT_NENDO, 4);
        }
        #endregion

        #region イベント

        #region JokasoDaichoSyukeiListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JokasoDaichoSyukeiListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoDaichoSyukeiListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();

                DoFormLoad();

                _rdChecked = futekiseiRadioButton;
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
        /// 2014/10/17  DatNT　  新規作成
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
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _isResetForm = true;

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
        /// 2014/12/15  HuyTX　  Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Ver1.03 Start
                //if (shoteiRadioButton.Checked)
                //{
                //    outputButton.Enabled = true;
                //    return;
                //}
                //Ver1.03 End

                if (!CheckCondition()) { return; }

                DoSearch();

                _isResetForm = false;
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
        /// 2014/10/17  DatNT　  新規作成
        /// 2014/10/28  HuyTX　  Ver1.02
        /// 2014/12/15  HuyTX　  Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //単項目チェック
                if ((ikoJokyoRadioButton.Checked || shoteiRadioButton.Checked) && string.IsNullOrEmpty(shukeiKaishiNendoTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "年度を入力してください。");
                    return;
                }

                //印刷チェック
                if ((futekiseiRadioButton.Checked && MessageForm.Show2(MessageForm.DispModeType.Question, "不適正浄化槽一覧を印刷します。よろしいですか？") != DialogResult.Yes)
                    || (mukanriRadioButton.Checked && MessageForm.Show2(MessageForm.DispModeType.Question, "無管理浄化槽一覧を印刷します。よろしいですか？") != DialogResult.Yes)
                    || (ikoJokyoRadioButton.Checked && MessageForm.Show2(MessageForm.DispModeType.Question, "7条⇒11条移行状況一覧を集計、印刷します。よろしいですか？") != DialogResult.Yes)
                    || (mijukenRadioButton.Checked && MessageForm.Show2(MessageForm.DispModeType.Question, "11条検査未受検一覧を印刷します。よろしいですか？") != DialogResult.Yes)
                    || (shoteiRadioButton.Checked && MessageForm.Show2(MessageForm.DispModeType.Question, "所要算定人員予測表を集計、印刷します。よろしいですか？") != DialogResult.Yes)
                    ) return;


                IOutputBtnClickALInput alInput = new OutputBtnClickALInput();
                //alInput.ShutsuryokuChohyo = futekiseiRadioButton.Checked ? "1" : (mukanriRadioButton.Checked ? "2" : (ikoJokyoRadioButton.Checked ? "3" : "4"));
                alInput.ShutsuryokuChohyo = futekiseiRadioButton.Checked ? "1" : (mukanriRadioButton.Checked ? "2" : (ikoJokyoRadioButton.Checked ? "3" : (mijukenRadioButton.Checked ? "4" : "5")));
                alInput.JokasoDaichoSyukeiListDataTable = _jokasoDaichoSyukeiListDT;
                alInput.ShukeiKaishiNendo = Int32.Parse(shukeiKaishiNendoTextBox.Text);
                IOutputBtnClickALOutput alOutput = new OutputBtnClickApplicationLogic().Execute(alInput);

                //集計処理エラー(7条⇒11条)
                if (ikoJokyoRadioButton.Checked && alOutput.IsError)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "7条⇒11条移行状況集計処理にてエラーが発生しました。\nシステム管理者に連絡してください。");
                }
                //集計処理エラー(所要算定)
                if (shoteiRadioButton.Checked && alOutput.IsError)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "所要算定人員集計処理にてエラーが発生しました。\nシステム管理者に連絡してください。");
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

        #region listOutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listOutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (listDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "浄化槽台帳集計一覧";
                Common.Common.FlushGridviewDataToExcel(listDataGridView, outputFilename);
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
        /// 2014/10/17  DatNT　  新規作成
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

        #region JokasoDaichoSyukeiListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JokasoDaichoSyukeiListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoDaichoSyukeiListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F5:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;

                    case Keys.F6:
                        listOutputButton.Focus();
                        listOutputButton.PerformClick();
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

        #region comment

        //#region FutekiseiRadioButton_CheckedChanged
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： FutekiseiRadioButton_CheckedChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/17  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void FutekiseiRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (futekiseiRadioButton.Checked)
        //        {
        //            jokasoDaichoMstDataSet.Clear();

        //            // 検査区分
        //            this.listDataGridView.Columns["KensaKbnCol"].Visible = true;

        //            // 放流水BOD
        //            this.listDataGridView.Columns["HoryuBodCol"].Visible = true;

        //            // 主な指摘
        //            this.listDataGridView.Columns["ShitekiCol"].Visible = true;

        //            // 7条⇒11条集計開始年度
        //            shukeiKaishiNendoLabel.Visible = false;
        //            shukeiKaishiNendoTextBox.Visible = false;

        //            outputButton.Enabled = false;
        //            listOutputButton.Enabled = false;
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
        //#endregion

        //#region MukanriRadioButton_CheckedChanged
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： MukanriRadioButton_CheckedChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/17  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void MukanriRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (mukanriRadioButton.Checked)
        //        {
        //            jokasoDaichoMstDataSet.Clear();

        //            // 検査区分
        //            this.listDataGridView.Columns["KensaKbnCol"].Visible = false;

        //            // 放流水BOD
        //            this.listDataGridView.Columns["HoryuBodCol"].Visible = false;

        //            // 主な指摘
        //            this.listDataGridView.Columns["ShitekiCol"].Visible = false;

        //            // 7条⇒11条集計開始年度
        //            shukeiKaishiNendoLabel.Visible = false;
        //            shukeiKaishiNendoTextBox.Visible = false;

        //            outputButton.Enabled = false;
        //            listOutputButton.Enabled = false;
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
        //#endregion

        //#region IkoJokyoRadioButton_CheckedChanged
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： IkoJokyoRadioButton_CheckedChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/17  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void IkoJokyoRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (ikoJokyoRadioButton.Checked)
        //        {
        //            jokasoDaichoMstDataSet.Clear();

        //            // 検査区分
        //            this.listDataGridView.Columns["KensaKbnCol"].Visible = false;

        //            // 放流水BOD
        //            this.listDataGridView.Columns["HoryuBodCol"].Visible = false;

        //            // 主な指摘
        //            this.listDataGridView.Columns["ShitekiCol"].Visible = false;

        //            // 7条⇒11条集計開始年度
        //            shukeiKaishiNendoLabel.Visible = true;
        //            shukeiKaishiNendoTextBox.Visible = true;

        //            outputButton.Enabled = false;
        //            listOutputButton.Enabled = false;
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
        //#endregion

        //#region MijukenRadioButton_CheckedChanged
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： MijukenRadioButton_CheckedChanged
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/17  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void MijukenRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (mijukenRadioButton.Checked)
        //        {
        //            jokasoDaichoMstDataSet.Clear();

        //            // 検査区分
        //            this.listDataGridView.Columns["KensaKbnCol"].Visible = false;

        //            // 放流水BOD
        //            this.listDataGridView.Columns["HoryuBodCol"].Visible = false;

        //            // 主な指摘
        //            this.listDataGridView.Columns["ShitekiCol"].Visible = false;

        //            // 7条⇒11条集計開始年度
        //            shukeiKaishiNendoLabel.Visible = false;
        //            shukeiKaishiNendoTextBox.Visible = false;

        //            outputButton.Enabled = false;
        //            listOutputButton.Enabled = false;
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
        //#endregion

        #endregion

        #region shutsuryokuChohyoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shutsuryokuChohyoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shutsuryokuChohyoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //if (_isResetForm) return;

                RadioButton rd = (RadioButton)sender;

                //if (!rd.Checked || _rdChecked == rd || _isResetForm) return;
                if (!rd.Checked || _rdChecked == rd) return;

                //if (listDataGridView.RowCount > 0 && MessageForm.Show2(MessageForm.DispModeType.Question, "一覧内容がクリアされます。よろしいですか？") != DialogResult.Yes)
                if (!_isResetForm && listDataGridView.RowCount > 0 && MessageForm.Show2(MessageForm.DispModeType.Question, "一覧内容がクリアされます。よろしいですか？") != DialogResult.Yes)
                {
                    _rdChecked.Checked = true;
                    return;
                }

                _rdChecked = rd;

                //set display items
                SetDispItem();

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

        #region uketsukeUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　  新規作成
        /// 2014/10/27  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 受付日（開始）
                uketsukeDtFromDateTimePicker.Enabled = uketsukeUseCheckBox.Checked;

                // 受付日（終了）
                uketsukeDtToDateTimePicker.Enabled = uketsukeUseCheckBox.Checked;
            
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

        #region kensaUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　  新規作成
        /// 2014/10/27  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 検査日（開始）
                kensaDtFromDateTimePicker.Enabled = kensaUseCheckBox.Checked;

                // 検査日（終了）
                kensaDtToDateTimePicker.Enabled = kensaUseCheckBox.Checked;
                
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

        #region uketsukeDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　Mehara      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                uketsukeDtToDateTimePicker.Value = uketsukeDtFromDateTimePicker.Value;
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
        /// 2015/01/29　Mehara      新規作成
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
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 保健所
            Utility.Utility.SetComboBoxList(hokenjoComboBox, alOutput.HokenjoMstDT, "HokenjoNm", "HokenjoCd", true);

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;
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
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            listDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // 出力帳票
            alInput.ShutsuryokuChohyo = futekiseiRadioButton.Checked ? "1" : (mukanriRadioButton.Checked ? "2" : (ikoJokyoRadioButton.Checked ? "3" : "4"));

            // 保健所
            if (hokenjoComboBox.SelectedValue != null)
            {
                alInput.HokenjoCd = hokenjoComboBox.SelectedValue.ToString();
            }

            // 受付日使用有無
            alInput.UketsukeUse = uketsukeUseCheckBox.Checked;

            // 受付日（開始）
            alInput.UketsukeDtFrom = uketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 受付日（終了）
            alInput.UketsukeDtTo = uketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査日使用有無
            alInput.KensaUse = kensaUseCheckBox.Checked;

            // 検査日（開始）
            alInput.KensaDtFrom = kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査日（終了）
            alInput.KensaDtTo = kensaDtToDateTimePicker.Value.ToString("yyyyMMdd");

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            _jokasoDaichoSyukeiListDT = alOutput.JokasoDaichoSyukeiListDT;
            listDataGridView.DataSource = alOutput.JokasoDaichoSyukeiListDT;

			if (alOutput.JokasoDaichoSyukeiListDT != null && alOutput.JokasoDaichoSyukeiListDT.Count > 0)
            {
                srhListCountLabel.Text = alOutput.JokasoDaichoSyukeiListDT.Count + "件";

                outputButton.Enabled = true;
            }
            else
            {
                srhListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");

				//受入20141226 mod sta
				//outputButton.Enabled = false;
				if (ikoJokyoRadioButton.Checked)
				{
					outputButton.Enabled = true;	// 7条⇒11条移行状況の場合、検索結果の有無に関係なく「帳票出力」ボタンを押せるようにする。
				}
				else
				{
					outputButton.Enabled = false;
				}
				//受入20141226 mod end
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
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 受付日（開始＆終了）
            if (uketsukeUseCheckBox.Checked && uketsukeDtFromDateTimePicker.Value > uketsukeDtToDateTimePicker.Value)
            {
                errMess.AppendLine("範囲指定が正しくありません。受付日の大小関係を確認してください。");
            }

            // 検査日（開始＆終了）
            if (kensaUseCheckBox.Checked && kensaDtFromDateTimePicker.Value > kensaDtToDateTimePicker.Value)
            {
                errMess.AppendLine("範囲指定が正しくありません。検査日の大小関係を確認してください。");
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
        /// 2014/10/17  DatNT　  新規作成
        /// 2014/10/27  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 出力帳票/不適正浄化槽
            futekiseiRadioButton.Checked = true;

            // 保健所
            hokenjoComboBox.SelectedIndex = -1;

            // 受付日使用有無
            uketsukeUseCheckBox.Checked = true;

            // 受付日（開始）
            uketsukeDtFromDateTimePicker.Value = new DateTime(today.AddMonths(-1).Year, today.AddMonths(-1).Month, 1);

            // 受付日（終了）
            uketsukeDtToDateTimePicker.Value = new DateTime(today.AddMonths(-1).Year, today.AddMonths(-1).Month, DateTime.DaysInMonth(today.AddMonths(-1).Year, today.AddMonths(-1).Month));

            // 検査日使用有無
            kensaUseCheckBox.Checked = true;

            // 検査日（開始）
            kensaDtFromDateTimePicker.Value = new DateTime(today.AddMonths(-1).Year, today.AddMonths(-1).Month, 1);

            // 検査日（終了）
            kensaDtToDateTimePicker.Value = new DateTime(today.AddMonths(-1).Year, today.AddMonths(-1).Month, DateTime.DaysInMonth(today.AddMonths(-1).Year, today.AddMonths(-1).Month));

            // 7条⇒11条集計開始年度
            shukeiKaishiNendoTextBox.Text = (Utility.DateUtility.GetNendo(today) - 4).ToString();

            //set display items
            SetDispItem();

        }
        #endregion

        #region SetDispItem
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDispItem
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  HuyTX　  新規作成
        /// 2014/12/15  HuyTX　  Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDispItem()
        {
            //Ver1.03 Add Start
            //保健所名
            hokenjoComboBox.Enabled = !shoteiRadioButton.Checked;
            //受付日使用有無
            uketsukeUseCheckBox.Checked = !shoteiRadioButton.Checked;
            //受付日（開始）
            uketsukeDtFromDateTimePicker.Enabled = !shoteiRadioButton.Checked;
            //受付日（終了）
            uketsukeDtToDateTimePicker.Enabled = !shoteiRadioButton.Checked;
            //検査日使用有無
            kensaUseCheckBox.Checked = !shoteiRadioButton.Checked;
            //検査日（開始）
            kensaDtFromDateTimePicker.Enabled = !shoteiRadioButton.Checked;
            //検査日（終了）
            kensaDtToDateTimePicker.Enabled = !shoteiRadioButton.Checked;
            //検索ボタン
            kensakuButton.Enabled = !shoteiRadioButton.Checked;
            // 7条⇒11条集計開始年度
            shukeiKaishiNendoTextBox.Text = ikoJokyoRadioButton.Checked ? Convert.ToString(Utility.DateUtility.GetNendo(today) - 4) : Convert.ToString(Utility.DateUtility.GetNendo(today));
            //一覧出力
            listOutputButton.Enabled = !shoteiRadioButton.Checked;

            //Ver1.03 Add End


            //検査区分
            this.listDataGridView.Columns[KensaKbnCol.Name].Visible = futekiseiRadioButton.Checked;

            //放流水BOD
            this.listDataGridView.Columns[HoryuBodCol.Name].Visible = futekiseiRadioButton.Checked;

            //主な指摘
            this.listDataGridView.Columns[ShitekiCol.Name].Visible = futekiseiRadioButton.Checked;

            //写真有無
            this.listDataGridView.Columns[SyashinUmuCol.Name].Visible = futekiseiRadioButton.Checked;

            //7条⇒11条集計開始年度
            shukeiKaishiNendoLabel.Enabled = ikoJokyoRadioButton.Checked || shoteiRadioButton.Checked;
            shukeiKaishiNendoTextBox.Enabled = ikoJokyoRadioButton.Checked || shoteiRadioButton.Checked;

            //clear datagridview
            listDataGridView.DataSource = null;
            listDataGridView.Rows.Clear();

            //帳票出力ボタン
            //outputButton.Enabled = listDataGridView.RowCount == 0 ? false : true;
            //outputButton.Enabled = listDataGridView.RowCount > 0 || shoteiRadioButton.Checked ? true : false;
			//受入20141226 mod
			// 7条⇒11条移行状況の場合、検索結果の有無に関係なく「帳票出力」ボタンを押せるようにする。
			outputButton.Enabled = (listDataGridView.RowCount > 0 || shoteiRadioButton.Checked || ikoJokyoRadioButton.Checked) ? true : false;

            //一覧出力ボタン
            //listOutputButton.Enabled = listDataGridView.RowCount == 0 ? false : true;

            //検索結果件数
            srhListCountLabel.Text = listDataGridView.RowCount + "件";
        }
        #endregion

        #endregion

    }
    #endregion
}
