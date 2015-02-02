using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.SuishitsuKensaNippo;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaNippoForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaNippoForm : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            InputKey,    // キー入力待ちモード
            Edit,        // 編集モード
            View,        // 編集不可モード
        }
        #endregion

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
        /// Today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// LoginUser
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// pcUpdate
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// ログインユーザーの所属支所コード
        /// </summary>
        private string LoginUserShozokuShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        /// <summary>
        /// Display mode
        /// </summary>
        private DispMode _dispMode;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaNippoForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaNippoForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SuishitsuKensaNippoForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaNippoForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaNippoForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _dispMode = DispMode.InputKey;

                DoFormLoad();

                SetDefaultValues();

                SetControlModeView();
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
        /// 2014/12/05  DatNT　  新規作成
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
                    this.SearchPanel,
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
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
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
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shishoNmComboBox.SelectedIndex < 1)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "必須項目：支所が入力されていません。");
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

        #region AllCheckCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： AllCheckCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void AllCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow dgvRow in nippoListDataGridView.Rows)
                {
                    //if (int.Parse(dgvRow.Cells[RecordTypeCol.Index].Value.ToString()) != 3
                    //    && int.Parse(dgvRow.Cells[RecordTypeCol.Index].Value.ToString()) != 4)
                    //{
                    //    dgvRow.Cells[kakuninCol.Index].Value = allCheckCheckBox.Checked;
                    //}

                    if (dgvRow.Cells[kensaShubetsuCol.Name].Value.ToString() == "■ 事業所計 ■"
                        || dgvRow.Cells[kensaShubetsuCol.Name].Value.ToString() == "■■ 総合計 ■■")
                    {
                        dgvRow.Cells[kakuninCol.Index].Value = "0";
                    }
                    else
                    {
                        if (_dispMode != DispMode.View)
                        {
                            dgvRow.Cells[kakuninCol.Index].Value = allCheckCheckBox.Checked ? "1" : "0";
                        }
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

        #region koshinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： koshinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void koshinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nippoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "更新対象データがありません。");
                    return;
                }

                // 変更不可チェック
                IKoshinBtnClickALInput alInput = new KoshinBtnClickALInput();
                alInput.UpdateCheck = true;
                alInput.UketsukeDt = uketsukeDtDateTimePicker.Value.ToString("yyyyMMdd");
                IKoshinBtnClickALOutput alOutput = new KoshinBtnClickApplicationLogic().Execute(alInput);

                if (!alOutput.UpdateCheckOutput)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "請求済のため、更新できません。");
                    return;
                }

                // 更新チェック
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された内容で日報を更新します。よろしいですか？") != DialogResult.Yes)
                {
                    return;
                }

                DoUpdate();
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

        #region nippoPrintButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nippoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// 2014/12/07  HuyTX　  Print 056_水質検査日報
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nippoPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!EditedCheck())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "表示されているデータが変更されています。\r\n日報出力前に更新を行ってください。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "日報を印刷します。よろしいですか？") != DialogResult.Yes)
                {
                    return;
                }

                //Print 056
                SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintDataTable printDT = GetDataPrint();
                INippoPrintBtnClickALInput alInput = new NippoPrintBtnClickALInput();
                alInput.SuishitsuKensaNippoPrintDataTable = printDT;
                new NippoPrintBtnClickApplicationLogic().Execute(alInput);

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

        #region CloseButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CloseButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
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

        #region SuishitsuKensaNippoForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaNippoForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaNippoForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        koshinButton.Focus();
                        koshinButton.PerformClick();
                        break;

                    case Keys.F6:
                        nippoPrintButton.Focus();
                        nippoPrintButton.PerformClick();
                        break;

                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F9:
                        TorikeshiButton.Focus();
                        TorikeshiButton.PerformClick();
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

        #region TorikeshiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TorikeshiButton_Click
        /// <summary>
        /// 取消ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  小松　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TorikeshiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _dispMode = DispMode.InputKey;

                nippoListDataGridView.Rows.Clear();

                ClearTextBox();

                SetDefaultValues();

                SetControlModeView();

                shishoNmComboBox.Focus();
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

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 支所
            shishoNmComboBox.SelectedValue = LoginUserShozokuShishoCd;

            // 受付日
            uketsukeDtDateTimePicker.Value = today;

            // 全て確認チェックボックス
            allCheckCheckBox.Checked = false;
        }
        #endregion

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.SearchPanel.Top;
            this._defaultSearchPanelHeight = this.SearchPanel.Height;
            this._defaultListPanelTop = this.listPanel.Top;
            this._defaultListPanelHeight = this.listPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 支所
            //Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
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
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // 既存データクリア
            nippoListDataGridView.Rows.Clear();

            ClearTextBox();

            //DataTable table = GetData();

            //StringBuilder cond = new StringBuilder();
            
            //SetData(table, cond);

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            
            alInput.UketsukeDt = uketsukeDtDateTimePicker.Value.ToString("yyyyMMdd");
            
            if (shishoNmComboBox.SelectedValue != null)
            {
                alInput.ShishoCd = shishoNmComboBox.SelectedValue.ToString();
            }

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.ExecProcFailure)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "日報データの作成に失敗しました。");
                return;
            }

            if (alOutput.KensakuCheck)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "表示データがありません。");
                return;
            }

            // Display data
            if (alOutput.SuisitsuKensaNippoKensakuDT != null && alOutput.SuisitsuKensaNippoKensakuDT.Count > 0)
            {
                DispData(alOutput.SuisitsuKensaNippoKensakuDT);

                _dispMode = alOutput.DispMode;
            }
            else
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新対象データがありません。");
                _dispMode = DispMode.InputKey;
            }

            SetControlModeView();
        }
        #endregion

        #region SetControlModeView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlModeView
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            switch (_dispMode)
            {
                case DispMode.InputKey:
                    
                    // 受付日
                    uketsukeDtDateTimePicker.Enabled = true;

                    // クリアボタン
                    clearButton.Enabled = true;

                    // 検索ボタン
                    kensakuButton.Enabled = true;

                    // 確認
                    nippoListDataGridView.Columns[kakuninCol.Name].ReadOnly = true;

                    // 更新ボタン
                    koshinButton.Enabled = false;

                    // 日報印刷ボタン 
                    nippoPrintButton.Enabled = false;

                    // 取消ボタン 
                    TorikeshiButton.Enabled = false;

                    break;
                    
                case DispMode.Edit:

                    // 受付日
                    uketsukeDtDateTimePicker.Enabled = false;

                    // クリアボタン
                    clearButton.Enabled = false;

                    // 検索ボタン
                    kensakuButton.Enabled = false;

                    // 確認
                    nippoListDataGridView.Columns[kakuninCol.Name].ReadOnly = false; // ペンディング：権限判定方法

                    // 更新ボタン
                    koshinButton.Enabled = true; // ペンディング：権限判定方法

                    // 日報印刷ボタン 
                    nippoPrintButton.Enabled = true;

                    // 取消ボタン 
                    TorikeshiButton.Enabled = true;

                    break;

                case DispMode.View:

                    // 受付日
                    uketsukeDtDateTimePicker.Enabled = false;

                    // クリアボタン
                    clearButton.Enabled = false;

                    // 検索ボタン
                    kensakuButton.Enabled = false;

                    // 確認
                    nippoListDataGridView.Columns[kakuninCol.Name].ReadOnly = true;

                    // 更新ボタン
                    koshinButton.Enabled = false;

                    // 日報印刷ボタン 
                    nippoPrintButton.Enabled = true;

                    // 取消ボタン 
                    TorikeshiButton.Enabled = true;

                    break;

                default:
                    break;
            }
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
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DispData(SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuDataTable dataTable)
        {
            #region Display SuishitsuNippoIraiNoInfoTbl

            SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuRow kensakuRow = dataTable[0];

            // 9条依頼番号From
            uketsukeNo9joFromTextBox.Text = kensakuRow.KeiryoShomeiNoFrom;

            // 9条依頼番号To
            uketsukeNo9joToTextBox.Text = kensakuRow.KeiryoShomeiNoTo;

            // 9条依頼件数
            uketsukeHonsu9joTextBox.Text = kensakuRow.KeiryoShomeiCnt.ToString("N0");

            // 11条依頼番号From
            uketsukeNoSuishitsu11joFromTextBox.Text = kensakuRow.SuishitsuNoFrom;

            // 11条依頼番号To
            uketsukeNoSuishitsu11joToTextBox.Text = kensakuRow.SuishitsuNoTo;

            // 11条依頼件数
            uketsukeHonsuSuishitsu11joTextBox.Text = kensakuRow.SuishitsuCnt.ToString("N0");

            // 外観依頼番号From
            uketsukeNoGaikanFromTextBox.Text = kensakuRow.GaikanNoFrom;

            // 外観依頼番号To
            uketsukeNoGaikanToTextBox.Text = kensakuRow.GaikanNoTo;

            // 外観依頼件数
            uketsukeHonsuGaikanTextBox.Text = kensakuRow.GaikanCnt.ToString("N0");

            #endregion

            #region Display DGV

            string gyoshaCd = string.Empty;

            Dictionary<string, decimal> mochikomiDic    = new Dictionary<string, decimal>();
            Dictionary<string, decimal> shushuDic       = new Dictionary<string, decimal>();
            Dictionary<string, decimal> kingkauDic      = new Dictionary<string, decimal>();
            Dictionary<string, decimal> nyukingakuDic   = new Dictionary<string, decimal>();
            
            decimal mochikomi       = 0;
            decimal shushu          = 0;
            decimal kingkau         = 0;
            decimal nyukingaku      = 0;
            decimal mochikomiAll    = 0;
            decimal shushuAll       = 0;
            decimal kingkauAll      = 0;
            decimal nyukingakuAll   = 0;

            foreach (SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuRow calRow in dataTable)
            {
                if (gyoshaCd != calRow.SuishitsuGyoshaCd)
                {
                    mochikomi   = 0;
                    shushu      = 0;
                    kingkau     = 0;
                    nyukingaku  = 0;

                    foreach (SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuRow row
                        in dataTable.Select(string.Format("SuishitsuGyoshaCd = {0}", calRow.SuishitsuGyoshaCd)))
                    {
                        mochikomi   += row.IsMochikomiCntNull() ? 0 : row.MochikomiCnt;
                        shushu      += row.IsShushuCntNull()    ? 0 : row.ShushuCnt;
                        kingkau     += row.IsGokeiAmtNull()     ? 0 : row.GokeiAmt;
                        nyukingaku  += row.IsNyukinAmtNull()    ? 0 : row.NyukinAmt;
                    }

                    mochikomiDic.Add(calRow.SuishitsuGyoshaCd, mochikomi);
                    shushuDic.Add(calRow.SuishitsuGyoshaCd, shushu);
                    kingkauDic.Add(calRow.SuishitsuGyoshaCd, kingkau);
                    nyukingakuDic.Add(calRow.SuishitsuGyoshaCd, nyukingaku);
                }

                gyoshaCd = calRow.SuishitsuGyoshaCd;

                mochikomiAll    += calRow.IsMochikomiCntNull()  ? 0 : calRow.MochikomiCnt;
                shushuAll       += calRow.IsShushuCntNull()     ? 0 : calRow.ShushuCnt;
                kingkauAll      += calRow.IsGokeiAmtNull()      ? 0 : calRow.GokeiAmt;
                nyukingakuAll   += calRow.IsNyukinAmtNull()     ? 0 : calRow.NyukinAmt;
            }

            gyoshaCd = string.Empty;

            for (int i = 0; i < dataTable.Count; i++ )
            {
                SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuRow row = dataTable[i];

                SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuRow preRow = i > 0 ? dataTable[i - 1] : row;

                SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuRow nextRow = dataTable[i == dataTable.Count - 1 ? i : (i + 1)];

                nippoListDataGridView.Rows.Add(row.GyoshaNm,                        // 事業所名
                                                row.SuishitsuGyoshaCd,              // 業者コード
                                                row.SuishitsuKensaKbn,              // 法定検査区分
                                                row.SuishitsuKensaShubetsuCd,       // 検査種別コード
                                                row.SuishitsuKensaShubetsuNm,       // 検査種別
                                                row.KaiinFlg,                       // 会員外
                                                row.GenkinFlg,                      // 現金
                                                row.SuishitsuKensaAmt,              // 検査料金
                                                row.MochikomiCnt,                   // 持込
                                                row.ShushuCnt,                      // 収集
                                                row.GokeiAmt,                       // 金額
                                                row.NyukinAmt,                      // 入金額
                                                row.CheckFlg,                       // 確認
                                                string.Empty,                       // データ種別
                                                row.ShishoCd,                       // ShishoCd
                                                row.SuishitsuUketsukeDt,            // SuishitsuUketsukeDt
                                                row.CheckFlg,                       // CheckFlg
                                                row.UpdateDt);                      // UpdateDt

                if (row.SuishitsuGyoshaCd != nextRow.SuishitsuGyoshaCd || i == dataTable.Count - 1)
                {
                    nippoListDataGridView.Rows.Add(row.GyoshaNm,
                                                    row.SuishitsuGyoshaCd,
                                                    string.Empty,
                                                    string.Empty,
                                                    "■ 事業所計 ■",
                                                    "0",
                                                    "0",
                                                    string.Empty,
                                                    mochikomiDic[row.SuishitsuGyoshaCd],
                                                    shushuDic[row.SuishitsuGyoshaCd],
                                                    kingkauDic[row.SuishitsuGyoshaCd],
                                                    nyukingakuDic[row.SuishitsuGyoshaCd],
                                                    "0",
                                                    "2",
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty);
                    //受入20141220 mod CkeckBoxColumnのReadOnly指定はCell指定だとうまくいかない。計行は全部編集不可で良いので、Row指定する。
                    //nippoListDataGridView.Rows[nippoListDataGridView.RowCount - 1].Cells[kakuninCol.Index].ReadOnly = true;
                    nippoListDataGridView.Rows[nippoListDataGridView.RowCount - 1].ReadOnly = true;
                    nippoListDataGridView.Rows[nippoListDataGridView.RowCount - 1].DefaultCellStyle.BackColor = Color.Yellow;
                }

                gyoshaCd = row.SuishitsuGyoshaCd;
            }

            // Last Row
            nippoListDataGridView.Rows.Add(string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            "■■ 総合計 ■■",
                                            "0",
                                            "0",
                                            string.Empty,
                                            mochikomiAll,
                                            shushuAll,
                                            kingkauAll,
                                            nyukingakuAll,
                                            "0",
                                            "3",
                                            string.Empty,
                                            string.Empty,
                                            string.Empty);

            //受入20141220 mod CkeckBoxColumnのReadOnly指定はCell指定だとうまくいかない。計行は全部編集不可で良いので、Row指定する。
            //nippoListDataGridView.Rows[nippoListDataGridView.RowCount - 1].Cells[kakuninCol.Index].ReadOnly = true;
            nippoListDataGridView.Rows[nippoListDataGridView.RowCount - 1].ReadOnly = true;
            nippoListDataGridView.Rows[nippoListDataGridView.RowCount - 1].DefaultCellStyle.BackColor = Color.Orange;

            #endregion            
        }
        #endregion
        
        #region ClearTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearTextBox()
        {
            // 9条依頼番号From
            uketsukeNo9joFromTextBox.Clear();

            // 9条依頼番号To
            uketsukeNo9joToTextBox.Clear();

            // 9条依頼件数
            uketsukeHonsu9joTextBox.Clear();

            // 11条依頼番号From
            uketsukeNoSuishitsu11joFromTextBox.Clear();

            // 11条依頼番号To
            uketsukeNoSuishitsu11joToTextBox.Clear();

            // 11条依頼件数
            uketsukeHonsuSuishitsu11joTextBox.Clear();

            // 外観依頼番号From
            uketsukeNoGaikanFromTextBox.Clear();

            // 外観依頼番号To
            uketsukeNoGaikanToTextBox.Clear();

            // 外観依頼件数
            uketsukeHonsuGaikanTextBox.Clear();
        }
        #endregion

        #region EditedCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditedCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditedCheck()
        {
            // 受入20141220 mod sta「表示しているデータに変更があった場合」なので、検索条件が変わった場合ではなく、印刷対象の「確認」が変わったかをチェックする。
            //if (shishoNmComboBox.SelectedValue == null)
            //{
            //    return false;
            //}

            //if (shishoNmComboBox.SelectedValue.ToString() != LoginUserShozokuShishoCd)
            //{
            //    return false;
            //}

            //if (uketsukeDtDateTimePicker.Value.ToString("yyyyMMdd") != today.ToString("yyyyMMdd"))
            //{
            //    return false;
            //}

            foreach (DataGridViewRow row in nippoListDataGridView.Rows)
            {
                string orgChkVal = String.IsNullOrEmpty(row.Cells[CheckFlgCol.Name].Value.ToString()) ? "0" : row.Cells[CheckFlgCol.Name].Value.ToString();
                if (!row.Cells[kakuninCol.Name].Value.ToString().Equals(orgChkVal))
                {
                    return false;
                }

            }
            // 受入20141220 mod end
            return true;
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            IKoshinBtnClickALInput updateInput = new KoshinBtnClickALInput();
            updateInput.SuishitsuNippoHdrTblDT = CreateNippoHdrDT(now);
            updateInput.UketsukeDt = uketsukeDtDateTimePicker.Value.ToString("yyyyMMdd");
            updateInput.ShishoCd = shishoNmComboBox.SelectedValue.ToString();
            IKoshinBtnClickALOutput updateOutput = new KoshinBtnClickApplicationLogic().Execute(updateInput);

            if (updateOutput.UpdateSuccess)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新処理が完了しました。");
            }

            // 既存データクリア
            nippoListDataGridView.Rows.Clear();

            // Display data
            if (updateOutput.SuisitsuKensaNippoKensakuDT != null && updateOutput.SuisitsuKensaNippoKensakuDT.Count > 0)
            {
                DispData(updateOutput.SuisitsuKensaNippoKensakuDT);
            }
        }
        #endregion

        #region CreateNippoHdrDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNippoHdrDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable CreateNippoHdrDT(DateTime now)
        {
            SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable nippoHdrDT = new SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable();

            foreach (DataGridViewRow row in nippoListDataGridView.Rows)
            {
                // 受入20141220 del sta「確認」Cbが変更されていなくても、UPDATEを行う。更新対象でないのは、小計、合計行のみ。
                //if (row.Cells[kakuninCol.Name].Value.ToString() == "0" && string.IsNullOrEmpty(row.Cells[CheckFlgCol.Name].Value.ToString()))
                //{
                //    continue;
                //}

                //if (row.Cells[kakuninCol.Name].Value.ToString() == row.Cells[CheckFlgCol.Name].Value.ToString())
                //{
                //    continue;
                //}

                if (row.Cells[kensaShubetsuCol.Name].Value.ToString() == "■ 事業所計 ■" ||
                    row.Cells[kensaShubetsuCol.Name].Value.ToString() == "■■ 総合計 ■■")
                {
                    continue;
                }    
                // 受入20141220 del end

                SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblRow nippoRow = nippoHdrDT.NewSuishitsuNippoHdrTblRow();

                // 支所コード
                nippoRow.ShishoCd = row.Cells[ShishoCdCol.Name].Value.ToString();
                
                // 受付日
                nippoRow.SuishitsuUketsukeDt = row.Cells[SuishitsuUketsukeDtCol.Name].Value.ToString();

                // 業者コード
                nippoRow.SuishitsuGyoshaCd = row.Cells[gyoshaCdCol.Name].Value.ToString();

                // 法定検査区分
                nippoRow.SuishitsuKensaKbn = row.Cells[kensaKbnCol.Name].Value.ToString();

                // 検査種別コード
                nippoRow.SuishitsuKensaShubetsuCd = row.Cells[kensaShubetsuCdCol.Name].Value.ToString();

                // 検査料金
                nippoRow.SuishitsuKensaAmt = Convert.ToDecimal(row.Cells[kensaRyokinCol.Name].Value);

                // チェックフラグ
                nippoRow.CheckFlg = row.Cells[kakuninCol.Name].Value.ToString();

                nippoRow.UpdateDt = (DateTime)row.Cells[UpdateDtCol.Name].Value;
                nippoRow.UpdateTarm = pcUpdate;
                nippoRow.UpdateUser = loginUser;
                nippoRow.InsertDt = now;
                nippoRow.InsertTarm = pcUpdate;
                nippoRow.InsertUser = loginUser;

                nippoHdrDT.AddSuishitsuNippoHdrTblRow(nippoRow);
                nippoRow.AcceptChanges();
                nippoRow.SetAdded();
            }

            return nippoHdrDT;
        }
        #endregion

        #region MockUp Process

        //private string gyoshaNm;
        //private string gyoshaCd;

        //private int motikomiCnt;
        //private int shushuCnt;
        //private int kingaku;
        //private int nyukingaku;

        //private int motikomiCntAll;
        //private int shushuCntAll;
        //private int kingakuAll;
        //private int nyukingakuAll;

        #region to be removed
        //private DataTable GetData()
        //{
        //    DataTable table = new DataTable();

        //    table.Columns.Add("GyoshaNm", typeof(string));
        //    table.Columns.Add("GyoshaCd", typeof(string));
        //    table.Columns.Add("kensaKbn", typeof(string));
        //    table.Columns.Add("kensaShubetsuCd", typeof(string));
        //    table.Columns.Add("kensaShubetsu", typeof(string));
        //    table.Columns.Add("KaiingaiKbn", typeof(int));
        //    table.Columns.Add("GenkinKbn", typeof(int));
        //    table.Columns.Add("KensaRyokin", typeof(int));
        //    table.Columns.Add("MotikomiKensu", typeof(int));
        //    table.Columns.Add("ShushuKensu", typeof(int));
        //    table.Columns.Add("Kingaku", typeof(int));
        //    table.Columns.Add("Nyukingaku", typeof(int));
        //    table.Columns.Add("KakuninKbn", typeof(int));
        //    table.Columns.Add("RecordType", typeof(int)); // 1=明細、2=事業所計、3=総合計

        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "(株)○○○○○";
        //        row["GyoshaCd"]      = "123";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "500人槽以下A";
        //        row["KaiingaiKbn"]   = 0;
        //        row["GenkinKbn"]     = 0;
        //        row["KensaRyokin"]   = 8100;
        //        row["MotikomiKensu"] = 1;
        //        row["ShushuKensu"]   = 0;
        //        row["Kingaku"]       = 8100;
        //        row["Nyukingaku"]    = 0;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }
        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "(株)○○○○○";
        //        row["GyoshaCd"]      = "123";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "500人槽以上A";
        //        row["KaiingaiKbn"]   = 0;
        //        row["GenkinKbn"]     = 0;
        //        row["KensaRyokin"]   = 8640;
        //        row["MotikomiKensu"] = 2;
        //        row["ShushuKensu"]   = 0;
        //        row["Kingaku"]       = 17280;
        //        row["Nyukingaku"]    = 0;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }
        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "(株)○○○○○";
        //        row["GyoshaCd"]      = "123";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "流入水A";
        //        row["KaiingaiKbn"]   = 0;
        //        row["GenkinKbn"]     = 0;
        //        row["KensaRyokin"]   = 7560;
        //        row["MotikomiKensu"] = 0;
        //        row["ShushuKensu"]   = 4;
        //        row["Kingaku"]       = 30240;
        //        row["Nyukingaku"]    = 0;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }
        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "(株)○○○○○";
        //        row["GyoshaCd"]      = "123";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "水濁法A";
        //        row["KaiingaiKbn"]   = 0;
        //        row["GenkinKbn"]     = 0;
        //        row["KensaRyokin"]   = 11340;
        //        row["MotikomiKensu"] = 0;
        //        row["ShushuKensu"]   = 8;
        //        row["Kingaku"]       = 90720;
        //        row["Nyukingaku"]    = 0;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }

        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "(有)△△△△△";
        //        row["GyoshaCd"]      = "124";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "11条(～10)";
        //        row["KaiingaiKbn"]   = 0;
        //        row["GenkinKbn"]     = 0;
        //        row["KensaRyokin"]   = 5600;
        //        row["MotikomiKensu"] = 2;
        //        row["ShushuKensu"]   = 8;
        //        row["Kingaku"]       = 56000;
        //        row["Nyukingaku"]    = 0;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }
        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "(有)△△△△△";
        //        row["GyoshaCd"]      = "124";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "11条(21～50)";
        //        row["KaiingaiKbn"]   = 0;
        //        row["GenkinKbn"]     = 0;
        //        row["KensaRyokin"]   = 8000;
        //        row["MotikomiKensu"] = 1;
        //        row["ShushuKensu"]   = 16;
        //        row["Kingaku"]       = 136000;
        //        row["Nyukingaku"]    = 0;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }

        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "□□□□□(株)";
        //        row["GyoshaCd"]      = "125";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "500人槽以下A";
        //        row["KaiingaiKbn"]   = 1;
        //        row["GenkinKbn"]     = 1;
        //        row["KensaRyokin"]   = 8100;
        //        row["MotikomiKensu"] = 0;
        //        row["ShushuKensu"]   = 4;
        //        row["Kingaku"]       = 0;
        //        row["Nyukingaku"]    = 32400;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }
        //    {
        //        DataRow row = table.NewRow();

        //        row["GyoshaNm"]      = "□□□□□(株)";
        //        row["GyoshaCd"]      = "125";
        //        row["kensaKbn"] = 0;
        //        row["kensaShubetsuCd"] = 0;
        //        row["kensaShubetsu"] = "500人槽以上A";
        //        row["KaiingaiKbn"]   = 0;
        //        row["GenkinKbn"]     = 0;
        //        row["KensaRyokin"]   = 8640;
        //        row["MotikomiKensu"] = 2;
        //        row["ShushuKensu"]   = 0;
        //        row["Kingaku"]       = 17280;
        //        row["Nyukingaku"]    = 0;
        //        row["KakuninKbn"]    = 0;
        //        row["RecordType"]    = 1;

        //        table.Rows.Add(row);
        //    }

        //    return table;
        //}

        //private void SetData(DataTable table, StringBuilder cond)
        //{
        //    gyoshaNm = "";
        //    gyoshaCd = string.Empty;

        //    motikomiCnt = 0;
        //    shushuCnt = 0;
        //    kingaku = 0;
        //    nyukingaku = 0;

        //    motikomiCntAll = 0;
        //    shushuCntAll = 0;
        //    kingakuAll = 0;
        //    nyukingakuAll = 0;

        //    foreach (DataRow row in table.Select(cond.ToString()))
        //    {
        //        if(gyoshaCd == string.Empty)
        //        {
        //            // 業者コード退避
        //            gyoshaNm = row["GyoshaNm"].ToString();
        //            gyoshaCd = row["GyoshaCd"].ToString();
        //        }
        //        else if(gyoshaCd != row["GyoshaCd"].ToString())
        //        {

        //            // 事業所計表示
        //            DispSubTotal();

        //            // 業者コード退避
        //            gyoshaNm = row["GyoshaNm"].ToString();
        //            gyoshaCd = row["GyoshaCd"].ToString();

        //        }

        //        // 各レコード表示
        //        DispRecoard(row);

        //        // 事業所計加算
        //        SetSubTotal(row);
        //    }
        //    if(gyoshaCd != string.Empty)
        //    {

        //        // 事業所計表示
        //        DispSubTotal();
                
        //        // 総合計表示
        //        DispTotal();

        //    }

        //    // 集計行の背景色変更＆チェックボックス非活性
        //    foreach(DataGridViewRow row in nippoListDataGridView.Rows)
        //    {
        //        if (int.Parse(row.Cells[RecordTypeCol.Index].Value.ToString()) == 2)
        //        {
        //            row.Cells[kakuninCol.Index].ReadOnly = true;  
        //            row.DefaultCellStyle.BackColor = Color.Yellow;
        //        }
        //        else if (int.Parse(row.Cells[RecordTypeCol.Index].Value.ToString()) == 3)
        //        {
        //            row.Cells[kakuninCol.Index].ReadOnly = true;
        //            row.DefaultCellStyle.BackColor = Color.Orange;
        //        }
        //    }

        //    // 受付No表示　9条
        //    uketsukeNo9joFromTextBox.Text = "1212";
        //    uketsukeNo9joToTextBox.Text = "1233";
        //    uketsukeHonsu9joTextBox.Text = "21";
        //    // 受付No表示　水質11条
        //    uketsukeNoSuishitsu11joFromTextBox.Text = "4578";
        //    uketsukeNoSuishitsu11joToTextBox.Text = "4605";
        //    uketsukeHonsuSuishitsu11joTextBox.Text = "27";
        //    // 受付No表示　外観11条
        //    uketsukeNoGaikanFromTextBox.Text = "2567";
        //    uketsukeNoGaikanToTextBox.Text = "2607";
        //    uketsukeHonsuGaikanTextBox.Text = "40";

        //}

        //// 各レコード表示
        //private void DispRecoard(DataRow row)
        //{
        //    nippoListDataGridView.Rows.Add(
        //        row["GyoshaNm"]
        //        , row["GyoshaCd"]
        //        , row["kensaKbn"]
        //        , row["kensaShubetsuCd"]
        //        , row["kensaShubetsu"]
        //        , row["KaiingaiKbn"]
        //        , row["GenkinKbn"]
        //        , row["KensaRyokin"]
        //        , row["MotikomiKensu"]
        //        , row["ShushuKensu"]
        //        , row["Kingaku"]
        //        , row["Nyukingaku"]
        //        , row["KakuninKbn"]
        //        , row["RecordType"]
        //        );
        //}

        //// 事業所計表示
        //private void DispSubTotal()
        //{
        //    nippoListDataGridView.Rows.Add(
        //        gyoshaNm
        //        , gyoshaCd
        //        , 0
        //        , 0
        //        , "■ 事業所計 ■"
        //        , 0
        //        , 0
        //        , 0
        //        , motikomiCnt
        //        , shushuCnt
        //        , kingaku
        //        , nyukingaku
        //        , 0
        //        , 2
        //        );

        //    // 総合計加算
        //    SetTotal();

        //    motikomiCnt = 0;
        //    shushuCnt = 0;
        //    kingaku = 0;
        //    nyukingaku = 0;
        //}

        //// 総合計表示
        //private void DispTotal()
        //{
        //    nippoListDataGridView.Rows.Add(
        //        ""
        //        , ""
        //        , 0
        //        , 0
        //        , "■■ 総合計 ■■"
        //        , 0
        //        , 0
        //        , 0
        //        , motikomiCntAll
        //        , shushuCntAll
        //        , kingakuAll
        //        , nyukingakuAll
        //        , 0
        //        , 3
        //        );
        //}

        //// 事業所計加算
        //private void SetSubTotal(DataRow row)
        //{
        //    motikomiCnt = motikomiCnt + int.Parse(row["MotikomiKensu"].ToString());
        //    shushuCnt   = shushuCnt   + int.Parse(row["ShushuKensu"].ToString());
        //    kingaku     = kingaku     + int.Parse(row["Kingaku"].ToString());
        //    nyukingaku  = nyukingaku  + int.Parse(row["Nyukingaku"].ToString());

        //}

        //// 総合計加算
        //private void SetTotal()
        //{
        //    motikomiCntAll = motikomiCntAll + motikomiCnt;
        //    shushuCntAll   = shushuCntAll   + shushuCnt;
        //    kingakuAll     = kingakuAll     + kingaku;
        //    nyukingakuAll  = nyukingakuAll  + nyukingaku;
        //}
        #endregion

        #endregion

        #region GetDataPrint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDataPrint
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintDataTable GetDataPrint()
        {
            SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintDataTable dataTable = new SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintDataTable();
            SuishitsuNippoDtlTblDataSet.SuishitsuKensaNippoPrintRow newRow;
            newRow = dataTable.NewSuishitsuKensaNippoPrintRow();
            //支所
            newRow.ShishoNm = shishoNmComboBox.SelectedIndex > 0 ? shishoNmComboBox.GetItemText(shishoNmComboBox.SelectedItem) : string.Empty;
            //受付日
            newRow.UketsukeDtDate = uketsukeDtDateTimePicker.Value.ToString("yyyy/MM/dd");
            //9条依頼番号From
            newRow.UketsukeNo9joFrom = uketsukeNo9joFromTextBox.Text;
            //9条依頼番号To
            newRow.UketsukeNo9joTo = uketsukeNo9joToTextBox.Text;
            //9条依頼件数
            newRow.UketsukeHonsu9jo = uketsukeHonsu9joTextBox.Text;
            //11条依頼番号From
            newRow.UketsukeNoSuishitsu11joFrom = uketsukeNoSuishitsu11joFromTextBox.Text;
            //11条依頼番号To
            newRow.UketsukeNoSuishitsu11joTo = uketsukeNoSuishitsu11joToTextBox.Text;
            //11条依頼件数
            newRow.UketsukeHonsuSuishitsu11jo = uketsukeHonsuSuishitsu11joTextBox.Text;
            //外観依頼番号From
            newRow.UketsukeNoGaikanFrom = uketsukeNoGaikanFromTextBox.Text;
            //外観依頼番号To
            newRow.UketsukeNoGaikanTo = uketsukeNoGaikanToTextBox.Text;
            //外観依頼件数
            newRow.UketsukeHonsuGaikan = uketsukeHonsuGaikanTextBox.Text;

            dataTable.AddSuishitsuKensaNippoPrintRow(newRow);
            dataTable.AcceptChanges();
            newRow.SetAdded();

            //get data from GridView
            foreach (DataGridViewRow row in nippoListDataGridView.Rows)
            {
                newRow = dataTable.NewSuishitsuKensaNippoPrintRow();

                //事業所名
                newRow.GyoshaNm = row.Cells[gyoshaNmCol.Index].Value.ToString();
                //業者コード
                newRow.GyoshaCd = row.Cells[gyoshaCdCol.Index].Value.ToString();
                //検査種別
                newRow.KensaShubetsu = row.Cells[kensaShubetsuCol.Index].Value.ToString();
                //会員外
                newRow.KaiingaiFlg = row.Cells[kaiingaiFlgCol.Index].Value.ToString();
                //現金
                newRow.GenkinFlg = row.Cells[genkinFlgCol.Index].Value.ToString();
                //検査料金
                newRow.KensaRyokin = row.Cells[kensaRyokinCol.Index].Value.ToString();
                //持込
                newRow.Mochikomi = row.Cells[mochikomiCol.Index].Value.ToString();
                //収集
                newRow.Shushu = row.Cells[shushuCol.Index].Value.ToString();
                //金額
                newRow.Kingaku = row.Cells[kingkauCol.Index].Value.ToString();
                //入金額
                newRow.Nyukingaku = row.Cells[nyukingakuCol.Index].Value.ToString();
                //データ種別
                newRow.RecordType = row.Cells[RecordTypeCol.Index].Value.ToString();
                
                dataTable.Rows.Add(newRow);
                dataTable.AcceptChanges();
                newRow.SetAdded();
            }

            return dataTable;
        }
        #endregion

        #endregion

    }
    #endregion
}
