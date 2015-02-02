using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SofuDtInputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JinendoGaikanKensaYoteiListOutputForm : FukjBaseForm
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
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        private ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable dataTable;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JinendoGaikanKensaYoteiListOutputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JinendoGaikanKensaYoteiListOutputForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region JinendoGaikanKensaYoteiListOutputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanKensaYoteiListOutputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanKensaYoteiListOutputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

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
        /// 2014/09/22　HuyTX    新規作成
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
                    this.jinendoGaikanKensaYoteiListOutputPanel,
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
        /// 2014/09/22　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //set default value control
                SetDefaultValueControl();

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
        /// 2014/09/22　HuyTX    新規作成
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

        #region csvOutputButton_Click
        // 2014/11/20 DatNT v1.02 DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： csvOutputButton_Click
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/09/22　HuyTX    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void csvOutputButton_Click(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (jinendoGaikanKensaYoteiListOutputDataGridView.RowCount == 0) return;

        //        if (MessageForm.Show2(MessageForm.DispModeType.Question, "CSVを出力します。よろしいですか？") != DialogResult.Yes) return;

        //        Common.Common.ExportCSVFromDataGridView("次年度外観検査予定一覧表出力", jinendoGaikanKensaYoteiListOutputDataGridView);
                
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
        /// 2014/09/22　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jinendoGaikanKensaYoteiListOutputDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "次年度外観検査予定一覧表出力";
                Common.Common.FlushGridviewDataToExcel(jinendoGaikanKensaYoteiListOutputDataGridView, outputFilename);

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
        /// 2014/09/22　HuyTX    新規作成
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

        #region JinendoGaikanKensaYoteiListOutputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanKensaYoteiListOutputForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanKensaYoteiListOutputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        printButton.Focus();
                        printButton.PerformClick();
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

        #region chikuCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chikuCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chikuCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(chikuCdFromTextBox.Text))
                {
                    chikuCdFromTextBox.Text = chikuCdFromTextBox.Text.PadLeft(5, '0');
                    chikuCdToTextBox.Text = chikuCdFromTextBox.Text;
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

        #region chikuCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chikuCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chikuCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(chikuCdToTextBox.Text))
                {
                    chikuCdToTextBox.Text = chikuCdToTextBox.Text.PadLeft(5, '0');
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

        #region gyoshaCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text))
                {
                    gyoshaCdFromTextBox.Text = gyoshaCdFromTextBox.Text.PadLeft(4, '0');
                    gyoshaCdToTextBox.Text = gyoshaCdFromTextBox.Text;
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

        #region gyoshaCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
                {
                    gyoshaCdToTextBox.Text = gyoshaCdToTextBox.Text.PadLeft(4, '0');
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

        #region printButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： printButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jinendoGaikanKensaYoteiListOutputDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 帳票出力チェック
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "外観検査依頼書を出力します。よろしいですか？") != DialogResult.Yes)
                {
                    return;
                }

                IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                alInput.Nendo = kensaNendoTextBox.Text;
                alInput.ZenkaiKensaDataWrkKensakuDT = dataTable;
                IPrintBtnClickALOutput alOutput = new PrintBtnClickApplicationLogic().Execute(alInput);
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
        /// 2014/09/22　HuyTX    新規作成
        /// 2014/11/19  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.jinendoGaikanKensaYoteiListOutputPanel.Top;
            this._defaultListPanelHeight = this.jinendoGaikanKensaYoteiListOutputPanel.Height;

            //set default value control
            SetDefaultValueControl();

            //IFormLoadALInput alInput = new FormLoadALInput();
            //alInput.KensaNendo = kensaNendoTextBox.Text.Trim();
            //alInput.SakuhyoKbn1 = sakuhyoKbn13RadioButton.Checked ? "3" : ((sakuhyoKbn11RadioButton.Checked) ? "1" : "2");
            //alInput.SakuhyoKbn2 = sakuhyoKbn23RadioButton.Checked ? "3" : ((sakuhyoKbn21RadioButton.Checked) ? "1" : "2");
            //IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //jinendoGaikanKensaYoteiListOutputCountLabel.Text = alOutput.ZenkaiKensaDataWrkKensakuDataTable.Count + "件";
            //jinendoGaikanKensaYoteiListOutputDataGridView.DataSource = alOutput.ZenkaiKensaDataWrkKensakuDataTable;
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
        /// 2014/09/22　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            //検査年度
            if (string.IsNullOrEmpty(kensaNendoTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：指定年度が入力されていません。");
            }

            //地区コード（開始＆終了）
            //if (!string.IsNullOrEmpty(chikuCdFromTextBox.Text.Trim()) && chikuCdFromTextBox.Text.Trim().Length != 5)
            //{
            //    errMsg.AppendLine("地区コード（開始）は5桁で入力して下さい。");
            //}

            //if (!string.IsNullOrEmpty(chikuCdToTextBox.Text.Trim()) && chikuCdToTextBox.Text.Trim().Length != 5)
            //{
            //    errMsg.AppendLine("地区コード（終了）は5桁で入力して下さい。");
            //}

            if (chikuCdFromTextBox.Text.Trim().Length == 5
                && chikuCdToTextBox.Text.Trim().Length == 5
                && Convert.ToInt32(chikuCdFromTextBox.Text.Trim()) > Convert.ToInt32(chikuCdToTextBox.Text.Trim()))
            {
                errMsg.AppendLine("範囲指定が正しくありません。地区コードの大小関係を確認してください。");
            }

            //業者コード（開始＆終了）
            //if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text.Trim()) && gyoshaCdFromTextBox.Text.Trim().Length != 4)
            //{
            //    errMsg.AppendLine("業者コード（開始）は4桁で入力して下さい。");
            //}

            //if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text.Trim()) && gyoshaCdToTextBox.Text.Trim().Length != 4)
            //{
            //    errMsg.AppendLine("業者コード（終了）は4桁で入力して下さい。");
            //}

            if (gyoshaCdFromTextBox.Text.Trim().Length == 4
                && gyoshaCdToTextBox.Text.Trim().Length == 4
                && Convert.ToInt32(gyoshaCdFromTextBox.Text.Trim()) > Convert.ToInt32(gyoshaCdToTextBox.Text.Trim()))
            {
                errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region SetDefaultValueControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValueControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22　HuyTX    新規作成
        /// 2014/11/19  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            //kensaNendoTextBox.Text = (_currentDateTime.Year + 1).ToString();
            kensaNendoTextBox.Text = (Utility.DateUtility.GetNendo(_currentDateTime) + 1).ToString();
            chikuCdFromTextBox.Text = string.Empty;
            chikuCdToTextBox.Text = string.Empty;
            gyoshaCdFromTextBox.Text = string.Empty;
            gyoshaCdToTextBox.Text = string.Empty;
            sakuhyoKbn13RadioButton.Checked = true;
            sakuhyoKbn23RadioButton.Checked = true;
            sakuhyoKbn33RadioButton.Checked = true;

            //jinendoGaikanKensaYoteiListOutputDataGridView.DataSource = null;
            //jinendoGaikanKensaYoteiListOutputDataGridView.Rows.Clear();
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
        /// 2014/09/25　HuyTX    新規作成
        /// 2014/12/04  DatNT   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            jinendoGaikanKensaYoteiListOutputDataGridView.DataSource = null;
            jinendoGaikanKensaYoteiListOutputDataGridView.Rows.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            alInput.ChikuCdFrom = chikuCdFromTextBox.Text.Trim();
            alInput.ChikuCdTo = chikuCdToTextBox.Text.Trim();
            alInput.GyoshaCdFrom = gyoshaCdFromTextBox.Text.Trim();
            alInput.GyoshaCdTo = gyoshaCdToTextBox.Text.Trim();
            alInput.KensaNendo = kensaNendoTextBox.Text.Trim();
            alInput.SakuhyoKbn11 = sakuhyoKbn11RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn12 = sakuhyoKbn12RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn13 = sakuhyoKbn13RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn21 = sakuhyoKbn21RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn22 = sakuhyoKbn22RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn23 = sakuhyoKbn23RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn31 = sakuhyoKbn31RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn32 = sakuhyoKbn32RadioButton.Checked ? true : false;
            alInput.SakuhyoKbn33 = sakuhyoKbn33RadioButton.Checked ? true : false;

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            jinendoGaikanKensaYoteiListOutputCountLabel.Text = alOutput.ZenkaiKensaDataWrkKensakuDataTable.Count + "件";

            if (alOutput.ZenkaiKensaDataWrkKensakuDataTable.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            //set data for display gridview
            jinendoGaikanKensaYoteiListOutputDataGridView.DataSource = alOutput.ZenkaiKensaDataWrkKensakuDataTable;

            dataTable = alOutput.ZenkaiKensaDataWrkKensakuDataTable;
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
        /// 2014/11/19　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 検査年度
            kensaNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);

            // 地区コード（開始）
            chikuCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            // 地区コード（終了）
            chikuCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            // 業者コード（開始）
            gyoshaCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            // 業者コード（終了）
            gyoshaCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
        }
        #endregion                

        #endregion

    }
    #endregion
}
