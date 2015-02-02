using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KensaKekka.KensaKekkaList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KensaKekka
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08　HuyTX     新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKekkaListForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// PrintMode
        /// </summary>
        public enum PrintMode
        {
            FaxMk,        // FaxMk
            FaxHosyu,     // FaxHosyu
            FaxKoji,      // FaxKoji
            FaxHoken      // FaxHoken
        }
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
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// kensaKekkaListDT
        /// </summary>
        private KensaKekkaTblDataSet.KensaKekkaListDataTable _kensaKekkaListDT = new KensaKekkaTblDataSet.KensaKekkaListDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKekkaListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKekkaListForm()
        {
            InitializeComponent();

            SetControlDomain();
        }
        #endregion

        #region イベント

        #region KensaKekkaListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// 2014/10/09　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //reset search panel
                ClearSearchPanel();

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
        /// 2014/08/08　HuyTX    新規作成
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
                    this.kekkaListPanel,
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
        /// 2014/08/08　HuyTX    新規作成
        /// 2014/10/09　HuyTX    Ver1.05
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
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidInput()) return;

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

        #region kekkasyoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kekkasyoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// 2014/10/16　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kekkasyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kekkaListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (string.IsNullOrEmpty(busuTextBox.Text.Trim()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "部数を入力してください。");
                    return;
                }

                //print check
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "結果書を印刷します。よろしいですか？") != DialogResult.Yes) return;

                //MOD_Ver1.07 Start
                #region to be removed
                //IKekkasyoBtnClickALInput alInput = new KekkasyoBtnClickALInput();
                //alInput.InsatsuKbn = tsujoRadioButton.Checked ? "1" : "2";
                //alInput.IsOutputPages = ikkatsuRadioButton.Checked;
                //alInput.KensaKekkaListDataTable = CreateKensaKekkaDT();

                //if (kensa11JoSuishitsuRadioButton.Checked && tujoScrKbnCheckBox.Checked)
                //{
                //    //print 042
                //    alInput.PrintSuishitsu = true;
                //}
                //else
                //{
                //    //print 003
                //    alInput.PrintSuishitsu = false;
                //}

                //new KekkasyoBtnClickApplicationLogic().Execute(alInput);
                #endregion

                string kensaKbn = string.Empty;
                string kensaHokenjoCd = string.Empty;
                string kensaNendo = string.Empty;
                string kensaRenban = string.Empty;
                int printKaisu;

                //print data (call common function 000-026)
                // 選択分指定の場合は、現在選択行の出力を行う
                if (sentakubunRadioButton.Checked)
                {
                    DataGridViewRow row = kekkaListDataGridView.CurrentRow;

                    kensaKbn = row.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
                    kensaHokenjoCd = row.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();
                    kensaNendo = row.Cells[KensaIraiNendoCol.Name].Value.ToString();
                    kensaRenban = row.Cells[KensaIraiRenbanCol.Name].Value.ToString();
                    printKaisu = row.Cells[printKaisuCol.Name].Value != null && !string.IsNullOrEmpty(row.Cells[printKaisuCol.Name].Value.ToString()) ? Int32.Parse(row.Cells[printKaisuCol.Name].Value.ToString()) : 0;

                    if(!PrintKekkashoData(kensaKbn, kensaHokenjoCd, kensaNendo, kensaRenban, printKaisu)) return;

                    //update data
                    if (senyoshiRadioButton.Checked)
                    {
                        IKekkasyoBtnClickALInput alInput = new KekkasyoBtnClickALInput();
                        alInput.IsEdaban = edabanCheckBox.Checked ? true : false;
                        alInput.KensaKekkaListDataTable = CreateKensaKekkaDT(row.Index);

                        new KekkasyoBtnClickApplicationLogic().Execute(alInput);
                    }
                }
                // 一括指定の場合は表示中の全権を出力を行う
                else
                {
                    for (int i = 0; i < kekkaListDataGridView.RowCount; i++)
                    {
                        DataGridViewRow row = kekkaListDataGridView.Rows[i];

                        kensaKbn = row.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
                        kensaHokenjoCd = row.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();
                        kensaNendo = row.Cells[KensaIraiNendoCol.Name].Value.ToString();
                        kensaRenban = row.Cells[KensaIraiRenbanCol.Name].Value.ToString();
                        printKaisu = row.Cells[printKaisuCol.Name].Value != null && !string.IsNullOrEmpty(row.Cells[printKaisuCol.Name].Value.ToString()) ? Int32.Parse(row.Cells[printKaisuCol.Name].Value.ToString()) : 0;

                        if (!PrintKekkashoData(kensaKbn, kensaHokenjoCd, kensaNendo, kensaRenban, printKaisu)) return;

                        //update data
                        if (senyoshiRadioButton.Checked)
                        {
                            IKekkasyoBtnClickALInput alInput = new KekkasyoBtnClickALInput();
                            alInput.IsEdaban = edabanCheckBox.Checked ? true : false;
                            alInput.KensaKekkaListDataTable = CreateKensaKekkaDT(row.Index);

                            new KekkasyoBtnClickApplicationLogic().Execute(alInput);
                        }
                    }
                }

                //update data
                // 専用紙指定 = データ更新実行なので、再取得を行う
                if (senyoshiRadioButton.Checked)
                {
                    #region to be removed
                    //IKekkasyoBtnClickALInput alInput = new KekkasyoBtnClickALInput();
                    //alInput.IsEdaban = edabanCheckBox.Checked ? true : false;
                    //alInput.KensaKekkaListDataTable = CreateKensaKekkaDT();

                    //new KekkasyoBtnClickApplicationLogic().Execute(alInput);
                    #endregion

                    // ReLoad
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        if (IsValidInput())
                        {
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
                    }
                }
                busuTextBox.Text = "1";
                //MOD_Ver1.07 End

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

        #region faxMkButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxMkButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxMkButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kekkaListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "FAX送付書(メーカー)を印刷します。よろしいですか？") != DialogResult.Yes) return;

                //print data
                PrintSouShinhyoInfo(PrintMode.FaxMk);

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

        #region faxHosyuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxHosyuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxHosyuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kekkaListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "FAX送付書(保守点検業者)を印刷します。よろしいですか？") != DialogResult.Yes) return;

                //print data
                PrintSouShinhyoInfo(PrintMode.FaxHosyu);

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

        #region faxKojiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxKojiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxKojiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kekkaListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "FAX送付書(工事業者)を印刷します。よろしいですか？") != DialogResult.Yes) return;

                //print data
                PrintSouShinhyoInfo(PrintMode.FaxKoji);
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

        #region faxHokenButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxHokenButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxHokenButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kekkaListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "FAX送付書(保健所)を印刷します。よろしいですか？") != DialogResult.Yes) return;

                //print data
                PrintSouShinhyoInfo(PrintMode.FaxHoken);
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
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kekkaListDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査結果一覧";
                Common.Common.FlushGridviewDataToExcel(kekkaListDataGridView, outputFilename);

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
        /// 2014/08/08　HuyTX    新規作成
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

        #region KensaKekkaListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        kekkasyoButton.Focus();
                        kekkasyoButton.PerformClick();
                        break;
                    case Keys.F2:
                        faxMkButton.Focus();
                        faxMkButton.PerformClick();
                        break;
                    case Keys.F3:
                        faxHosyuButton.Focus();
                        faxHosyuButton.PerformClick();
                        break;
                    case Keys.F4:
                        faxKojiButton.Focus();
                        faxKojiButton.PerformClick();
                        break;
                    case Keys.F5:
                        faxHokenButton.Focus();
                        faxHokenButton.PerformClick();
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
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaIraiDtUseCheckBox_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaIraiDtFromDateTimePicker.Enabled = kensaIraiDtToDateTimePicker.Enabled = kensaIraiDtUseCheckBox.Checked;
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
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaDtUseCheckBox_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaDtFromDateTimePicker.Enabled = kensaDtToDateTimePicker.Enabled = kensaDtUseCheckBox.Checked;
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

        #region kyokaiFrom1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
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

        #region kyokaiFrom2TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom2TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
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

        #region kyokaiFrom3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiFrom3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
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

        #region kyokaiTo1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
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

        #region kyokaiTo2TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo2TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
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

        #region kyokaiTo3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyokaiTo3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
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

        #region suikenFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suikenFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suikenFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
                                                         suikenFromTextBox,
                                                         suikenToTextBox);

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

        #region suikenToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suikenToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suikenToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave((Control.ZTextBox)sender,
                                                         suikenFromTextBox,
                                                         suikenToTextBox);

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

        #region tsujoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tsujoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28　DatNT    Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tsujoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (tsujoRadioButton.Checked)
                {
                    edabanCheckBox.Checked = false;
                    edabanCheckBox.Enabled = false;
                }
                else if (senyoshiRadioButton.Checked)
                {
                    edabanCheckBox.Enabled = true;
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

        #region senyoshiRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： senyoshiRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28　DatNT    Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void senyoshiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (tsujoRadioButton.Checked)
                {
                    edabanCheckBox.Checked = false;
                    edabanCheckBox.Enabled = false;
                }
                else if (senyoshiRadioButton.Checked)
                {
                    edabanCheckBox.Enabled = true;
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
        /// 2015/01/28　PhuongDT    新規作成
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
        /// 2014/08/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.kekkaListPanel.Top;
            this._defaultListPanelHeight = this.kekkaListPanel.Height;
            busuTextBox.Text = "1";

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.SearchCond = MakeSearchCond();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            //_kensaKekkaListDT = GetKensaKekkaList(alOutput.KensaKekkaListDataTable);
            _kensaKekkaListDT = alOutput.KensaKekkaListDataTable;
            //検索結果件数
            kekkaListCountLabel.Text = _kensaKekkaListDT.Count + "件";

            ////set data for display gridview
            kekkaListDataGridView.DataSource = _kensaKekkaListDT;

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
        /// 2014/08/08　HuyTX    新規作成
        /// 2014/10/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            kekkaListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            alInput.SearchCond = MakeSearchCond();
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);
            //_kensaKekkaListDT = GetKensaKekkaList(alOutput.KensaKekkaListDataTable);
            _kensaKekkaListDT = alOutput.KensaKekkaListDataTable;

            kekkaListCountLabel.Text = _kensaKekkaListDT.Count + "件";

            if (alOutput.KensaKekkaListDataTable.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            //set data for display gridview
            kekkaListDataGridView.DataSource = _kensaKekkaListDT;

        }
        #endregion

        #region IsValidInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08　HuyTX    新規作成
        /// 2014/10/09　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidInput()
        {
            StringBuilder errMsg = new StringBuilder();
            bool isValidKensaNo = true;


            #region UnitCheck

            #endregion

            #region RelationCheck

            //スクリーニング区分
            if (kensa11JoSuishitsuRadioButton.Checked
                && !tujoScrKbnCheckBox.Checked
                && !scrnScrKbnCheckBox.Checked
                && !flwScrKbnCheckBox.Checked
                && !scrflwScrKbnCheckBox.Checked
                )
            {
                errMsg.AppendLine("スクリーニング区分が未選択です。");
            }

            //検査番号（開始＆終了）
            if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) & !string.IsNullOrEmpty(kyokaiTo1TextBox.Text)
                && Convert.ToInt32(kyokaiFrom1TextBox.Text) > Convert.ToInt32(kyokaiTo1TextBox.Text))
            {
                isValidKensaNo = false;
            }

            if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) & !string.IsNullOrEmpty(kyokaiTo2TextBox.Text)
                && Convert.ToInt32(kyokaiFrom2TextBox.Text) > Convert.ToInt32(kyokaiTo2TextBox.Text))
            {
                isValidKensaNo = false;
            }

            if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) & !string.IsNullOrEmpty(kyokaiTo3TextBox.Text)
                && Convert.ToInt32(kyokaiFrom3TextBox.Text) > Convert.ToInt32(kyokaiTo3TextBox.Text))
            {
                isValidKensaNo = false;
            }

            if (!isValidKensaNo)
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査番号の大小関係を確認してください。");
            }

            //水検No（開始＆終了）
            if (!string.IsNullOrEmpty(suikenFromTextBox.Text) && !string.IsNullOrEmpty(suikenToTextBox.Text)
                && Convert.ToInt32(suikenFromTextBox.Text) > Convert.ToInt32(suikenToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。水検Noの大小関係を確認してください。");
            }

            //検査依頼日（開始＆終了）
            if (kensaIraiDtUseCheckBox.Checked
                && Int32.Parse(kensaIraiDtFromDateTimePicker.Value.ToString("yyyyMMdd")) > Int32.Parse(kensaIraiDtToDateTimePicker.Value.ToString("yyyyMMdd")))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査依頼日の大小関係を確認してください。");
            }

            //検査日（開始＆終了）
            if (kensaDtUseCheckBox.Checked
                && Int32.Parse(kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd")) > Int32.Parse(kensaDtToDateTimePicker.Value.ToString("yyyyMMdd")))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査日の大小関係を確認してください。");
            }

            //判定
            if (!tekiseiHntKbnCheckBox.Checked
                && !omuneHntKbnCheckBox.Checked
                && !futekiseiHntKbnCheckBox.Checked
                )
            {
                errMsg.AppendLine("判定が未選択です。");
            }

            #endregion

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
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
        /// 2014/08/08　HuyTX    新規作成
        /// 2014/10/09　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaKekkaListSearchCond MakeSearchCond()
        {
            KensaKekkaListSearchCond searchCond = new KensaKekkaListSearchCond();
            string kensaIraiScreeningKbn = string.Empty;
            string[] listKensaIraiScreeningKbn = new string[] { };
            string kensaKekkaHantei = string.Empty;
            string[] listKensaKekkaHantei = new string[] { };

            searchCond.KensaIraiHoteiKbn = kensa7JoRadioButton.Checked ? "1" : (kensa11JoGaikanRadioButton.Checked ? "2" : "3");
            if (kensa11JoSuishitsuRadioButton.Checked)
            {
                kensaIraiScreeningKbn += string.Format("{0}", tujoScrKbnCheckBox.Checked ? "0," : string.Empty);
                kensaIraiScreeningKbn += string.Format("{0}", scrnScrKbnCheckBox.Checked ? "1," : string.Empty);
                kensaIraiScreeningKbn += string.Format("{0}", flwScrKbnCheckBox.Checked ? "2," : string.Empty);
                kensaIraiScreeningKbn += string.Format("{0}", scrflwScrKbnCheckBox.Checked ? "3," : string.Empty);
                listKensaIraiScreeningKbn = !string.IsNullOrEmpty(kensaIraiScreeningKbn)
                                            ? kensaIraiScreeningKbn.Remove(kensaIraiScreeningKbn.Length - 1).Split(',')
                                            : new string[] { };
            }
            searchCond.KensaIraiScreeningKbn = listKensaIraiScreeningKbn.Length == 4 ? new string[] { } : listKensaIraiScreeningKbn;

            searchCond.HokenjoCdFrom = kyokaiFrom1TextBox.Text.Trim();
            searchCond.HokenjoCdTo = kyokaiTo1TextBox.Text.Trim();
            searchCond.NendoFrom = !string.IsNullOrEmpty(kyokaiFrom2TextBox.Text.Trim()) ? Utility.DateUtility.ConvertFromWareki(kyokaiFrom2TextBox.Text.Trim(), "yyyy") : string.Empty;
            searchCond.NendoTo = !string.IsNullOrEmpty(kyokaiTo2TextBox.Text.Trim()) ? Utility.DateUtility.ConvertFromWareki(kyokaiTo2TextBox.Text.Trim(), "yyyy") : string.Empty;
            searchCond.RenbanFrom = kyokaiFrom3TextBox.Text.Trim();
            searchCond.RenbanTo = kyokaiTo3TextBox.Text.Trim();

            searchCond.KensaIraiSuishitsuIraiNoFrom = suikenFromTextBox.Text.Trim();
            searchCond.KensaIraiSuishitsuIraiNoTo = suikenToTextBox.Text.Trim();

            searchCond.KensaIraiSetchishaNm = settisyaTextBox.Text.Trim();
            searchCond.KensaIraiShisetsuNm = shisetsuNmTextBox.Text.Trim();

            if (kensaIraiDtUseCheckBox.Checked)
            {
                searchCond.KensaIraiDtFrom = kensaIraiDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                searchCond.KensaIraiDtTo = kensaIraiDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }

            if (kensaDtUseCheckBox.Checked)
            {
                searchCond.KensaDtFrom = kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                searchCond.KensaDtTo = kensaDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }

            kensaKekkaHantei += tekiseiHntKbnCheckBox.Checked ? "1," : string.Empty;
            kensaKekkaHantei += omuneHntKbnCheckBox.Checked ? "2," : string.Empty;
            kensaKekkaHantei += futekiseiHntKbnCheckBox.Checked ? "3," : string.Empty;
            listKensaKekkaHantei = !string.IsNullOrEmpty(kensaKekkaHantei) 
                                    ? kensaKekkaHantei.Remove(kensaKekkaHantei.Length - 1).Split(',') 
                                    : new string[] { };

            searchCond.KensaKekkaHantei = listKensaKekkaHantei.Length == 3 ? new string[] { } : listKensaKekkaHantei;

            searchCond.KensaIraiHakkoKbn = tuchiAllRadioButton.Checked ? "3" : (tuchiHokenjoRadioButton.Checked ? "4" : "5");


            return searchCond;
        }
        #endregion

        #region SetValueDateTimePicker
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetValueDateTimePicker
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValueDateTimePicker()
        {
            kensaIraiDtFromDateTimePicker.Value = new DateTime(_currentDateTime.Year, _currentDateTime.Month, 1);
            kensaIraiDtToDateTimePicker.Value = _currentDateTime;

            kensaDtFromDateTimePicker.Value = new DateTime(_currentDateTime.Year, _currentDateTime.Month, 1);
            kensaDtToDateTimePicker.Value = _currentDateTime;
        }
        #endregion

        #region PrintSouShinhyoInfo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintSouShinhyoInfo
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintSouShinhyoInfo(PrintMode printMode)
        {
            DataGridViewRow printRow = kekkaListDataGridView.CurrentRow;

            IFaxPrintBtnClickALInput alInput = new FaxPrintBtnClickALInput();
            alInput.PrintMode = printMode;

            alInput.KensaIraiHoteiKbn = printRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
            alInput.KensaIraiHokenjoCd = printRow.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();
            alInput.KensaIraiNendo = printRow.Cells[KensaIraiNendoCol.Name].Value.ToString();
            alInput.KensaIraiRenban = printRow.Cells[KensaIraiRenbanCol.Name].Value.ToString();

            new FaxPrintBtnClickApplicationLogic().Execute(alInput);


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
        /// 2014/10/09　HuyTX     Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchPanel()
        {
            kensa7JoRadioButton.Checked = true;
            tujoScrKbnCheckBox.Checked = true;
            scrnScrKbnCheckBox.Checked = true;
            flwScrKbnCheckBox.Checked = true;
            scrflwScrKbnCheckBox.Checked = true;
            kyokaiFrom1TextBox.Clear();
            kyokaiFrom2TextBox.Clear();
            kyokaiFrom3TextBox.Clear();
            kyokaiTo1TextBox.Clear();
            kyokaiTo2TextBox.Clear();
            kyokaiTo3TextBox.Clear();
            suikenFromTextBox.Clear();
            suikenToTextBox.Clear();
            tekiseiHntKbnCheckBox.Checked = true;
            omuneHntKbnCheckBox.Checked = true;
            futekiseiHntKbnCheckBox.Checked = true;
            tuchiAllRadioButton.Checked = true;
            settisyaTextBox.Text = string.Empty;
            shisetsuNmTextBox.Text = string.Empty;
            kensaIraiDtUseCheckBox.Checked = false;
            kensaDtUseCheckBox.Checked = true;
            tsujoRadioButton.Checked = true;
            sentakubunRadioButton.Checked = true;
            kensaIraiDtUseCheckBox_Click(null, null);
            kensaDtUseCheckBox_Click(null, null);

            // set default datetime
            SetValueDateTimePicker();
        }
        #endregion

        #region CreateKensaKekkaDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaKekkaDT
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15　HuyTX       新規作成
        /// 2015/01/22　habu        行指定に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaKekkaTblDataSet.KensaKekkaListDataTable CreateKensaKekkaDT(int rowIdx)
        {
            KensaKekkaTblDataSet.KensaKekkaListDataTable kensaKekkaListDT = new KensaKekkaTblDataSet.KensaKekkaListDataTable();

            {
                DataGridViewRow gridRow = kekkaListDataGridView.Rows[rowIdx];

                string kensaIraiHoteiKbn = gridRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
                string kensaIraiHokenjoCd = gridRow.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();
                string kensaIraiNendo = gridRow.Cells[KensaIraiNendoCol.Name].Value.ToString();
                string kensaIraiRenban = gridRow.Cells[KensaIraiRenbanCol.Name].Value.ToString();

                KensaKekkaTblDataSet.KensaKekkaListRow[] kensaKekkaRows = (KensaKekkaTblDataSet.KensaKekkaListRow[])_kensaKekkaListDT.Select(string.Format("KensaIraiHoteiKbn = '{0}' AND KensaIraiHokenjoCd = '{1}' AND KensaIraiNendo = '{2}' AND KensaIraiRenban = '{3}'",
                    new string[] { kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban }));

                kensaKekkaListDT.ImportRow(kensaKekkaRows[0]);
            }

            #region to be removed
            //if (!sentakubunRadioButton.Checked)
            //{
            //    return _kensaKekkaListDT;
            //}
            //else
            //{
            //    string kensaIraiHoteiKbn = kekkaListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
            //    string kensaIraiHokenjoCd = kekkaListDataGridView.CurrentRow.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();
            //    string kensaIraiNendo = kekkaListDataGridView.CurrentRow.Cells[KensaIraiNendoCol.Name].Value.ToString();
            //    string kensaIraiRenban = kekkaListDataGridView.CurrentRow.Cells[KensaIraiRenbanCol.Name].Value.ToString();

            //    KensaKekkaTblDataSet.KensaKekkaListRow[] kensaKekkaRows = (KensaKekkaTblDataSet.KensaKekkaListRow[])_kensaKekkaListDT.Select(string.Format("KensaIraiHoteiKbn = '{0}' AND KensaIraiHokenjoCd = '{1}' AND KensaIraiNendo = '{2}' AND KensaIraiRenban = '{3}'",
            //        new string[] { kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban }));

            //    kensaKekkaListDT.ImportRow(kensaKekkaRows[0]);
            //}
            #endregion

            return kensaKekkaListDT;
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
        /// 2014/11/11　HuyTX     新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            kyokaiFrom1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiFrom2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiFrom3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            kyokaiTo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiTo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiTo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            suikenFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            suikenToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            kekkaListDataGridView.SetStdControlDomain(suikenNoCol.Index, ZControlDomain.ZT_STD_NUM, 6);
            busuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
        }
        #endregion

        #region PrintKekkashoData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintKekkashoData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaKbn"></param>
        /// <param name="kensaHokenjoCd"></param>
        /// <param name="kensaNendo"></param>
        /// <param name="kensaRenban"></param>
        /// <param name="printKaisu"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　HuyTX     Ver1.06
        /// 2014/12/02　habu     Added fdMkKbn
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool PrintKekkashoData(string kensaKbn, string kensaHokenjoCd, string kensaNendo, string kensaRenban, int printKaisu)
        {
            int result = 0;
            result = Utility.KekkashoUtility.KekkashoOutput(kensaKbn, kensaHokenjoCd, kensaNendo, kensaRenban, Int32.Parse(busuTextBox.Text), tsujoRadioButton.Checked ? 0 : 1, tsujoRadioButton.Checked ? 0 : 1, edabanCheckBox.Checked ? (printKaisu + 1) : 0);
            //result = Utility.KekkashoUtility.KekkashoOutput(kensaKbn, kensaHokenjoCd, kensaNendo, kensaRenban, Int32.Parse(busuTextBox.Text), tsujoRadioButton.Checked ? 0 : 1, 1, edabanCheckBox.Checked ? (printKaisu + 1) : 0);

            switch (result)
            {
                case 2:
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象のデータが見つかりません。");
                    return false;
                case 3:
                    MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                    return false;
                case 4:
                    MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが存在しません。システム管理者に連絡してください。");
                    return false;
                case 9:
                    MessageForm.Show2(MessageForm.DispModeType.Error, "結果書作成に失敗しました。システム管理者に連絡してください。");
                    return false;
                default:
                    break;
            }

            return true;
        }
        #endregion

        #region DEL_20141118
        //#region GetKensaKekkaList
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： GetKensaKekkaList
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="kensaKekkaListDT"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/17　HuyTX     新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaKekkaTblDataSet.KensaKekkaListDataTable GetKensaKekkaList(KensaKekkaTblDataSet.KensaKekkaListDataTable kensaKekkaListDT)
        //{
        //    foreach (KensaKekkaTblDataSet.KensaKekkaListRow row in kensaKekkaListDT.Rows)
        //    {
        //        row.KensaNo = string.Concat(row.KensaIraiHokenjoCd, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy"), "-", row.KensaIraiRenban);
        //    }

        //    return kensaKekkaListDT;
        //}
        //#endregion
        #endregion

        #endregion

    }

    #endregion

}
