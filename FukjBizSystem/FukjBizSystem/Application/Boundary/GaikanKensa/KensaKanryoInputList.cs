using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaKanryoInputList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKanryoInputListForm : FukjBaseForm
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

        /// <summary>
        /// Edit Flg
        /// </summary>
        private bool editFlg = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKanryoInputListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKanryoInputListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaKanryoInputListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKanryoInputListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKanryoInputListForm_Load(object sender, EventArgs e)
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
        /// 2014/09/08  DatNT　  新規作成
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
        /// 2014/09/08  DatNT　  新規作成
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
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (editFlg)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "検印、検査完了区分は更新されていません。\r\n一覧をクリアしてもよろしいですか？")
                        != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (!CheckCondition()) { return; }

                DoSearch();

                editFlg = false;
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
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void koshinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kanryoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "更新対象データがありません。");
                    return;
                }

                // 更新関連チェック
                int check = 0;
                foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
                {
                    // 検印済、未完了は無い
                    if (row.Cells[keninCol.Name].Value.ToString() == "1" && row.Cells[kanryoCol.Name].Value.ToString() == "0")
                    {
                        check++;
                    }
                }

                if (check > 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検査完了でない場合、検印完了にはできません。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されている状態で検査の検印、検査完了します。よろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                {
                    DoUpdate();

                    DoSearch();
                }
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
        /// 2014/09/08  DatNT　  新規作成
        /// 2014/11/04  HuyTX　  Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kekkasyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //ADD_Ver1.04 Start
                if (kanryoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string hoteiKbn = kanryoListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
                string hokenjoCd = kanryoListDataGridView.CurrentRow.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();
                string nendo = kanryoListDataGridView.CurrentRow.Cells[KensaIraiNendoCol.Name].Value.ToString();
                string renban = kanryoListDataGridView.CurrentRow.Cells[KensaIraiRenbanCol.Name].Value.ToString();

                // 2015.01.09 toyoda Modify Start 処理失敗を通知する
                //// TODO 20141111 habu HotFix
                //Utility.KekkashoUtility.KekkashoOutput(hoteiKbn, hokenjoCd, nendo, renban, 0, 0, 1, 0);
                ////Utility.KekkashoUtility.KekkashoOutput(hoteiKbn, hokenjoCd, nendo, renban, 0, 0);
                ////ADD_Ver1.04 End
                int result = 0;
                result = Utility.KekkashoUtility.KekkashoOutput(hoteiKbn, hokenjoCd, nendo, renban, 0, 0, 1, 0);

                switch (result)
                {
                    case 2:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "対象のデータが見つかりません。");
                        break;
                    case 3:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                        break;
                    case 4:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが存在しません。システム管理者に連絡してください。");
                        break;
                    case 9:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "結果書作成に失敗しました。システム管理者に連絡してください。");
                        break;
                    default:
                        break;
                }
                // 2015.01.09 toyoda Modify End
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

        #region chienHokokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chienHokokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  DatNT　  新規作成
        /// 2014/11/04  HuyTX　  Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chienHokokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //ADD_Ver1.04 Start
                if (kanryoListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string kensaKbn = kanryoListDataGridView.CurrentRow.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();
                string hokenjoCd = kanryoListDataGridView.CurrentRow.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();
                string nendo = kanryoListDataGridView.CurrentRow.Cells[KensaIraiNendoCol.Name].Value.ToString();
                string renban = kanryoListDataGridView.CurrentRow.Cells[KensaIraiRenbanCol.Name].Value.ToString();

                string serverFolder = Utility.SharedFolderUtility.GetKensaIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_047, 
                                        Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001, kensaKbn, hokenjoCd, nendo, renban);
                string localFolder = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_047, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                string fileName = string.Concat(hokenjoCd, nendo, renban, Properties.Settings.Default.KensaChienHokokushoFormatFile);
                string localFilePath = Path.Combine(localFolder, fileName);
                string shareFilePath = Path.Combine(serverFolder, fileName);
                string pdfFilePath = Path.Combine(localFolder, fileName.Split('.')[0] + ".pdf");

                //connect
                Utility.SharedFolderUtility.Connect();

                if (File.Exists(shareFilePath))
                {
                    Utility.SharedFolderUtility.DownloadFile(localFilePath, shareFilePath);

                    //convert excel to pdf
                    Common.Common.ConvertExcelToPdf(localFilePath, pdfFilePath);

                    //delete excel file
                    File.Delete(localFilePath);
                }
                else
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "遅延報告書は作成されていません。");
                }

                //ADD_Ver1.04 End
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                //disconnect
                Utility.SharedFolderUtility.Disconnect();

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
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kanryoListDataGridView.RowCount == 0) return;

                // DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査完了入力";
                Common.Common.FlushGridviewDataToExcel(kanryoListDataGridView, outputFilename);
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
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //GaikanKensaMenuForm frm = new GaikanKensaMenuForm();
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

        #region KensaKanryoInputListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKanryoInputListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKanryoInputListForm_KeyDown(object sender, KeyEventArgs e)
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

                    case Keys.F2:
                        kekkasyoButton.Focus();
                        kekkasyoButton.PerformClick();
                        break;

                    case Keys.F3:
                        chienHokokuButton.Focus();
                        chienHokokuButton.PerformClick();
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

        #region keninAllButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keninAllButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keninAllButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (keninAllButton.Text == "ALL")
                {
                    foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells[keninCol.Name];
                        cb.Value = "1";
                    }

                    keninAllButton.Text = "解除";
                    keninCntTextBox.Text = kanryoListDataGridView.RowCount.ToString();
                }
                else if (keninAllButton.Text == "解除")
                {
                    foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells[keninCol.Name];
                        cb.Value = "0";
                    }

                    keninAllButton.Text = "ALL";
                    keninCntTextBox.Clear();
                }

                editFlg = true;
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

        #region 2014/10/09 DatNT V1.02 DEL
        //#region kanryoAllButton_Click
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： kanryoAllButton_Click
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/09/08  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void kanryoAllButton_Click(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (kanryoAllButton.Text == "ALL")
        //        {
        //            foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
        //            {
        //                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells["kanryoCol"];
        //                cb.Value = "1";
        //            }

        //            kanryoAllButton.Text = "解除";
        //            kanryoCntTextBox.Text = kanryoListDataGridView.RowCount.ToString();
        //        }
        //        else if (kanryoAllButton.Text == "解除")
        //        {
        //            foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
        //            {
        //                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells["kanryoCol"];
        //                cb.Value = "0";
        //            }

        //            kanryoAllButton.Text = "ALL";
        //            kanryoCntTextBox.Clear();
        //        }

        //        editFlg = true;
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

        #region kanryoListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kanryoListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kanryoListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //e.ThrowException = false;
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

        #region kensaDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaDtUseCheckBox.Checked)
                {
                    kensaDtFromDateTimePicker.Enabled = true;
                    kensaDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    kensaDtFromDateTimePicker.Enabled = false;
                    kensaDtToDateTimePicker.Enabled = false;
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

        #region kanryoListDataGridView_CellContentClick
        // 2014/10/15 DatNT DEL Start
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： kensaChienJisshiListDataGridView_CellContentClick
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/09/15  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void kanryoListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        if (e.RowIndex == -1) { return; }

        //        string colName = kanryoListDataGridView.Columns[e.ColumnIndex].Name;

        //        if (colName == "keninCol" || colName == "kanryoCol")
        //        {
        //            editFlg = true;
        //        }

        //        if (colName == "keninCol")
        //        {
        //            int countKenin = 0;

        //            DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)kanryoListDataGridView.CurrentRow.Cells["keninCol"];
        //            if (cb.Value.ToString() == "1")
        //            {
        //                cb.Value = "0";
        //            }
        //            else
        //            {
        //                cb.Value = "1";
        //            }

        //            foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
        //            {
        //                if (row.Cells["keninCol"].Value != null && row.Cells["keninCol"].Value.ToString() == "1")
        //                {
        //                    countKenin++;
        //                }
        //            }

        //            if (countKenin != 0)
        //            {
        //                keninCntTextBox.Text = countKenin.ToString();
        //            }
        //            else
        //            {
        //                keninCntTextBox.Text = string.Empty;
        //            }

        //            if (countKenin == kanryoListDataGridView.RowCount)
        //            {
        //                keninAllButton.Text = "解除";
        //            }
        //            else
        //            {
        //                keninAllButton.Text = "ALL";
        //            }
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
        // 2014/10/15 DatNT DEL End
        #endregion

        #region kanryoListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kanryoListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kanryoListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                string colName = kanryoListDataGridView.Columns[e.ColumnIndex].Name;

                if (colName == keninCol.Name || colName == kanryoCol.Name)
                {
                    editFlg = true;
                }

                if (colName == keninCol.Name)
                {
                    int countKenin = 0;

                    #region to be removed
                    //DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)kanryoListDataGridView.CurrentRow.Cells[keninCol.Name];
                    //if (cb.Value.ToString() == "1")
                    //{
                    //    //cb.Value = "0";
                    //}
                    //else
                    //{
                    //    //cb.Value = "1";
                    //}
                    #endregion

                    foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
                    {
                        if (row.Cells[keninCol.Name].Value != null && row.Cells[keninCol.Name].Value.ToString() == "1")
                        {
                            countKenin++;
                        }
                    }

                    if (countKenin != 0)
                    {
                        keninCntTextBox.Text = countKenin.ToString();
                    }
                    else
                    {
                        keninCntTextBox.Text = string.Empty;
                    }

                    if (countKenin == kanryoListDataGridView.RowCount)
                    {
                        keninAllButton.Text = "解除";
                    }
                    else
                    {
                        keninAllButton.Text = "ALL";
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
        
        #region kanryoListDataGridView_CurrentCellDirtyStateChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kanryoListDataGridView_CurrentCellDirtyStateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  DatNT　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kanryoListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kanryoListDataGridView.IsCurrentCellDirty)
                {
                    kanryoListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text))
                {
                    kyokaiFrom1TextBox.Text = kyokaiFrom1TextBox.Text.PadLeft(2, '0');
                    kyokaiTo1TextBox.Text = kyokaiFrom1TextBox.Text;
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
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text))
                {
                    kyokaiFrom2TextBox.Text = kyokaiFrom2TextBox.Text.PadLeft(2, '0');
                    kyokaiTo2TextBox.Text = kyokaiFrom2TextBox.Text;
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
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiFrom3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text))
                {
                    kyokaiFrom3TextBox.Text = kyokaiFrom3TextBox.Text.PadLeft(6, '0');
                    kyokaiTo3TextBox.Text = kyokaiFrom3TextBox.Text;
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
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text))
                {
                    kyokaiTo1TextBox.Text = kyokaiTo1TextBox.Text.PadLeft(2, '0');
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
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text))
                {
                    kyokaiTo2TextBox.Text = kyokaiTo2TextBox.Text.PadLeft(2, '0');
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
        /// 2014/10/15  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyokaiTo3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text))
                {
                    kyokaiTo3TextBox.Text = kyokaiTo3TextBox.Text.PadLeft(6, '0');
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

        #region settisyaKanaFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： settisyaKanaFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void settisyaKanaFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(settisyaKanaFromTextBox.Text))
                {
                    settisyaKanaToTextBox.Text = settisyaKanaFromTextBox.Text;
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

        #region ninsoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ninsoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ninsoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(ninsoFromTextBox.Text))
                {
                    ninsoToTextBox.Text = ninsoFromTextBox.Text;
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
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            kensaKekkaTblDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShokuinKensainFlg = "1";
            alInput.ShokuinTaishokuFlg = "0";
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検査員
            Utility.Utility.SetComboBoxList(kensainComboBox, alOutput.ShokuinMstDT, "ShokuinNm", "ShokuinCd", true);
            
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;
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
        /// 2014/09/08  DatNT　  新規作成
        /// 2014/10/08  DatNT　  V1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            KensaKekkaInputListSearchCond searchCond = new KensaKekkaInputListSearchCond();

            // 検査員
            if (kensainComboBox.SelectedValue != null)
            {
                searchCond.ShokuinCd = kensainComboBox.SelectedValue.ToString();
            }

            // 検査種別
            if (kensaAllRadioButton.Checked)
            {
                searchCond.KensaIraiHoteiKbn = "0";
            }
            else if (kensa7JoRadioButton.Checked)
            {
                searchCond.KensaIraiHoteiKbn = "1";
            }
            else if (kensa11JoRadioButton.Checked)
            {
                searchCond.KensaIraiHoteiKbn = "2";
            }

            searchCond.HokenjoCdFrom = kyokaiFrom1TextBox.Text.Trim();
            searchCond.NendoFrom = kyokaiFrom2TextBox.Text.Trim();
            searchCond.RenbanFrom = kyokaiFrom3TextBox.Text.Trim();
            searchCond.HokenjoCdTo = kyokaiTo1TextBox.Text.Trim();
            searchCond.NendoTo = kyokaiTo2TextBox.Text.Trim();
            searchCond.RenbanTo = kyokaiTo3TextBox.Text.Trim();

            // 検査日検索使用フラグ
            searchCond.KensaYoteiDtUse = kensaDtUseCheckBox.Checked;

            // 検査日（開始）
            searchCond.KensaDtFrom = kensaDtFromDateTimePicker.Value.ToString("yyyyMMdd");

            // 検査日（終了）
            searchCond.KensaDtTo = kensaDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 設置住所
            searchCond.SettiAdr = settiAdrTextBox.Text.Trim();

            // 設置者カナ（開始）
            searchCond.SettisyaKanaFrom = settisyaKanaFromTextBox.Text.Trim();

            // 設置者カナ（終了）
            searchCond.SettisyaKanaTo = settisyaKanaToTextBox.Text.Trim();

            // 人槽（開始）
            searchCond.NinsoFrom = ninsoFromTextBox.Text;

            // 人槽（終了）
            searchCond.NinsoTo = ninsoToTextBox.Text;

            // 対象物件
            //if (bukkenMikanryoRadioButton.Checked)
            //{
            //    searchCond.TaishoBukken = "1";
            //}
            if (bukkenMikeninRadioButton.Checked)
            {
                searchCond.TaishoBukken = "2";
            }
            else if (bukkenKeninSumiRadioButton.Checked)
            {
                searchCond.TaishoBukken = "3";
            }
            else if (bukkenAllRadioButton.Checked)
            {
                searchCond.TaishoBukken = "4";
            }

            alInput.SearchCond = searchCond;
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
        /// 2014/09/08  DatNT　  新規作成
        /// 2015/01/07  habu　  不具合対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear datagirdview
            kensaKekkaTblDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // Display data
            //kensaKekkaTblDataSet.Merge(DispData(alOutput.KensaKanryoInputListDT));
            kensaKekkaTblDataSet.Merge(alOutput.KensaKanryoInputListDT);

            // 20150107 habu 検印できない不具合修正
            kensaKekkaTblDataSet.KensaKanryoInputList.keninColColumn.ReadOnly = false;
            kensaKekkaTblDataSet.KensaKanryoInputList.kanryoColColumn.ReadOnly = false;

            keninCol.ReadOnly = false;
            kanryoCol.ReadOnly = false;
            // 20150107 End

            if (alOutput.KensaKanryoInputListDT == null || alOutput.KensaKanryoInputListDT.Count == 0)
            {
                srhListCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                srhListCountLabel.Text = alOutput.KensaKanryoInputListDT.Count.ToString() + "件";
            }

            if (kanryoListDataGridView.RowCount > 0)
            {
                foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
                {
                    row.Cells[keninOriginalCol.Name].Value = row.Cells[keninCol.Name].Value;
                    row.Cells[kanryoOriginalCol.Name].Value = row.Cells[kanryoCol.Name].Value;                    
                }
            }

            SetColorCountKeninKanryo();
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
        /// 2014/09/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            //bool flg = true;

            // 協会No（開始）
            if (!string.IsNullOrEmpty(kyokaiFrom1TextBox.Text) && kyokaiFrom1TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（開始）(保健所コード)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiFrom2TextBox.Text) && kyokaiFrom2TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（開始） (年度)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiFrom3TextBox.Text) && kyokaiFrom3TextBox.Text.Length != 6)
            {
                errMess.AppendLine("協会No（開始） (連番)は6桁で入力して下さい。");
                //flg = false;
            }

            // 協会No（終了）
            if (!string.IsNullOrEmpty(kyokaiTo1TextBox.Text) && kyokaiTo1TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（終了） (保健所コード)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiTo2TextBox.Text) && kyokaiTo2TextBox.Text.Length != 2)
            {
                errMess.AppendLine("協会No（終了） (年度)は2桁で入力して下さい。");
                //flg = false;
            }
            if (!string.IsNullOrEmpty(kyokaiTo3TextBox.Text) && kyokaiTo3TextBox.Text.Length != 6)
            {
                errMess.AppendLine("協会No（終了） (連番)は6桁で入力して下さい。");
                //flg = false;
            }

            //協会No（開始＆終了）
            // 2014/10/27 AnhNV UPD start
            if (!Utility.Utility.IsValidKyokaiNo(kyokaiFrom1TextBox, kyokaiFrom2TextBox, kyokaiFrom3TextBox, kyokaiTo1TextBox, kyokaiTo2TextBox, kyokaiTo3TextBox))
            {
                errMess.AppendLine("範囲指定が正しくありません。検査番号の大小関係を確認してください。");
            }
            // 2014/10/27 AnhNV UPD end

            if(kensaDtUseCheckBox.Checked)
            {
                if (kensaDtFromDateTimePicker.Value > kensaDtToDateTimePicker.Value)
                {
                    errMess.AppendLine("範囲指定が正しくありません。検査日の大小関係を確認してください。");
                }
            }            

            // 2014/10/27 AnhNV DEL start
            //if (flg
            //    && !string.IsNullOrEmpty(kyokaiFrom1TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiFrom2TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiFrom3TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiTo1TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiTo2TextBox.Text)
            //    && !string.IsNullOrEmpty(kyokaiTo3TextBox.Text))
            //{
            //    if (Convert.ToDecimal(kyokaiFrom1TextBox.Text + kyokaiFrom2TextBox.Text + kyokaiFrom3TextBox.Text)
            //        > Convert.ToDecimal(kyokaiTo1TextBox.Text + kyokaiTo2TextBox.Text + kyokaiTo3TextBox.Text))
            //    {
            //        errMess.Append("範囲指定が正しくありません。協会Noの大小関係を確認してください。\r\n");
            //    }
            //}
            // 2014/10/27 AnhNV DEL end

            // 設置者カナ（開始＆終了）
            if (!string.IsNullOrEmpty(settisyaKanaFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(settisyaKanaToTextBox.Text.Trim()))
            {
                if (string.Compare(settisyaKanaFromTextBox.Text.Trim(), settisyaKanaToTextBox.Text.Trim()) > 0)
                {
                    errMess.Append("範囲指定が正しくありません。設置者カナの大小関係を確認してください。\r\n");
                }
            }

            // 人槽（開始＆終了）
            if (!string.IsNullOrEmpty(ninsoFromTextBox.Text) && !string.IsNullOrEmpty(ninsoToTextBox.Text))
            {
                if (Convert.ToInt32(ninsoFromTextBox.Text) > Convert.ToInt32(ninsoToTextBox.Text))
                {
                    errMess.Append("範囲指定が正しくありません。人槽の大小関係を確認してください。\r\n");
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
        /// 2014/09/08  DatNT　  新規作成
        /// 2014/10/08  DatNT　  V1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 検査員
            kensainComboBox.SelectedIndex = -1;

            // 検査種別/全て
            kensaAllRadioButton.Checked = true;

            // 協会No（開始） (保健所コード)
            kyokaiFrom1TextBox.Clear();

            // 協会No（開始） (年度)
            kyokaiFrom2TextBox.Clear();

            // 協会No（開始） (連番)
            kyokaiFrom3TextBox.Clear();

            // 協会No（終了） (保健所コード)
            kyokaiTo1TextBox.Clear();

            // 協会No（終了） (年度)
            kyokaiTo2TextBox.Clear();

            // 協会No（終了） (連番)
            kyokaiTo3TextBox.Clear();

            // 検査日検索使用フラグ
            kensaDtUseCheckBox.Checked = false;

            // 検査日（開始）
            kensaDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            kensaDtFromDateTimePicker.Enabled = false;

            // 検査日（終了）
            kensaDtToDateTimePicker.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            kensaDtToDateTimePicker.Enabled = false;

            // 設置住所
            settiAdrTextBox.Clear();

            // 設置者カナ（開始）
            settisyaKanaFromTextBox.Clear();

            // 設置者カナ（終了）
            settisyaKanaToTextBox.Clear();

            // 人槽（開始）
            ninsoFromTextBox.Clear();

            // 人槽（終了）
            ninsoToTextBox.Clear();

            // 未検印のみ
            bukkenMikeninRadioButton.Checked = true;

            // 対象物件/検査未完了のみ
            //bukkenMikanryoRadioButton.Checked = true;
        }
        #endregion

        #region SetColorCountKeninKanryo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetColorCountKeninKanryo
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09  DatNT　  新規作成
        /// 2014/10/08  DatNT　  V1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetColorCountKeninKanryo()
        {
            int keninCnt = 0;
            int kanryoCnt = 0;

            foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
            {
                if (row.Cells[keninCol.Name].Value == null || row.Cells[keninCol.Name].Value.ToString() == "0")
                {
                    // don't handled
                }
                else if(row.Cells[keninCol.Name].Value.ToString() == "1")
                {
                    keninCnt++;
                }

                if (row.Cells[kanryoCol.Name].Value == null || row.Cells[kanryoCol.Name].Value.ToString() == "0")
                {
                    // don't handled
                }
                else if (row.Cells[kanryoCol.Name].Value.ToString() == "1")
                {
                    kanryoCnt++;
                }

                if (row.Cells[hanteiValueCol.Name].Value != null && row.Cells[hanteiValueCol.Name].Value.ToString() == "3")
                {
                    row.Cells[hanteiCol.Name].Style.ForeColor = Color.Red;
                }
            }

            if (keninCnt != 0)
            {
                keninCntTextBox.Text = keninCnt.ToString();
            }
            else
            {
                keninCntTextBox.Clear();
            }

            if (keninCnt == kanryoListDataGridView.RowCount && keninCnt != 0)
            {
                keninAllButton.Text = "解除";
            }
            else
            {
                keninAllButton.Text = "ALL";
            }

            // 2014/10/09 DatNT V1.02 DEL Start
            //if (kanryoCnt != 0)
            //{
            //    kanryoCntTextBox.Text = kanryoCnt.ToString();
            //}
            //else
            //{
            //    kanryoCntTextBox.Clear();
            //}
            // 2014/10/09 DatNT V1.02 DEL End
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
        /// 2014/09/09  DatNT　  新規作成
        /// 2014/10/08  DatNT　  V1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            KensaIraiTblDataSet.KensaIraiTblDataTable updateDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            foreach (DataGridViewRow row in kanryoListDataGridView.Rows)
            {
                if ((row.Cells[keninCol.Name].Value != row.Cells[keninOriginalCol.Name].Value)
                    || (row.Cells[kanryoCol.Name].Value != row.Cells[kanryoOriginalCol.Name].Value))
                {
                    KensaIraiTblDataSet.KensaIraiTblRow updateRow = updateDT.NewKensaIraiTblRow();

                    // 検査依頼法定区分
                    updateRow.KensaIraiHoteiKbn = row.Cells[KensaIraiHoteiKbnCol.Name].Value.ToString();

                    // 検査依頼保健所コード
                    updateRow.KensaIraiHokenjoCd = row.Cells[KensaIraiHokenjoCdCol.Name].Value.ToString();

                    // 検査依頼年度
                    updateRow.KensaIraiNendo = row.Cells[KensaIraiNendoCol.Name].Value.ToString();

                    // 検査依頼連番
                    updateRow.KensaIraiRenban = row.Cells[KensaIraiRenbanCol.Name].Value.ToString();

                    // 2014/10/08 DatNT V1.02 DEL Start
                    //// 検印区分
                    //updateRow.KensaIraiKeninKbn = (row.Cells["keninCol"].Value != null) ? row.Cells["keninCol"].Value.ToString() : null;

                    //// 検査完了区分
                    //updateRow.KensaIraiKensaKanryoKbn = (row.Cells["kanryoCol"].Value != null) ? row.Cells["kanryoCol"].Value.ToString() : null;
                    // 2014/10/08 DatNT V1.02 DEL END

                    // 2014/10/08 DatNT V1.02 ADD Start
                    // ステータス区分
                    if (row.Cells[keninCol.Name].Value.ToString() == "1" && row.Cells[kanryoCol.Name].Value.ToString() == "1")
                    {
                        updateRow.KensaIraiStatusKbn = "70";
                    }
                    if (row.Cells[keninCol.Name].Value.ToString() == "0" && row.Cells[kanryoCol.Name].Value.ToString() == "1")
                    {
                        updateRow.KensaIraiStatusKbn = "65";
                    }
                    if (row.Cells[keninCol.Name].Value.ToString() == "0" && row.Cells[kanryoCol.Name].Value.ToString() == "0")
                    {
                        updateRow.KensaIraiStatusKbn = "60";
                    }
                    // 2014/10/08 DatNT V1.02 ADD End

                    updateRow.KensaIraiUketsukeShishoKbn = string.Empty;
                    updateRow.KensaIraiJokasoHokenjoCd = string.Empty;
                    updateRow.KensaIraiJokasoTorokuNendo = string.Empty;
                    updateRow.KensaIraiJokasoRenban = string.Empty;
                    updateRow.InsertDt = today;
                    updateRow.InsertTarm = string.Empty;
                    updateRow.InsertUser = string.Empty;
                    updateRow.UpdateDt = (DateTime)row.Cells[KensaIraiTblUpdateDtCol.Name].Value;
                    updateRow.UpdateTarm = string.Empty;
                    updateRow.UpdateUser = string.Empty;

                    updateDT.AddKensaIraiTblRow(updateRow);
                    updateRow.AcceptChanges();
                    updateRow.SetAdded();
                }
            }

            if (updateDT != null && updateDT.Count > 0)
            {
                IKoshinBtnClickALInput alInput = new KoshinBtnClickALInput();
                alInput.KensaIraiTblDataTable = updateDT;
                IKoshinBtnClickALOutput alOuput = new KoshinBtnClickApplicationLogic().Execute(alInput);

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新処理が完了しました。");
            }
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
        /// 2014/10/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 検査番号（開始） (保健所コード)
            kyokaiFrom1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（開始） (年度)
            kyokaiFrom2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（開始） (連番)
            kyokaiFrom3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            // 検査番号（終了） (保健所コード)
            kyokaiTo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（終了） (年度)
            kyokaiTo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            // 検査番号（終了） (連番)
            kyokaiTo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            //ADD_HuyTX Start
            settiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            settisyaKanaFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
            settisyaKanaToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
            ninsoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);
            ninsoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);

            kanryoListDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            kanryoListDataGridView.SetStdControlDomain(kensainCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            kanryoListDataGridView.SetStdControlDomain(kensaSyubetsuCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            kanryoListDataGridView.SetStdControlDomain(yoteiDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            kanryoListDataGridView.SetStdControlDomain(kyokaiNoCol.Index, ZControlDomain.ZG_STD_NAME, 12, DataGridViewContentAlignment.MiddleCenter);
            kanryoListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            kanryoListDataGridView.SetStdControlDomain(settiBasyoCol.Index, ZControlDomain.ZG_STD_NAME, 80);
            kanryoListDataGridView.SetStdControlDomain(ninsoCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            kanryoListDataGridView.SetStdControlDomain(syoriHoshikiCol.Index, ZControlDomain.ZG_STD_NAME, 14, DataGridViewContentAlignment.MiddleCenter);
            kanryoListDataGridView.SetStdControlDomain(hanteiCol.Index, ZControlDomain.ZG_STD_NAME, 20, DataGridViewContentAlignment.MiddleCenter);
            //ADD_HuyTX End
        }
        #endregion
        
        #region DEL_20141118
        //#region DispData
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： DispData
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/17  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaKekkaTblDataSet.KensaKanryoInputListDataTable DispData(KensaKekkaTblDataSet.KensaKanryoInputListDataTable dataTable)
        //{
        //    KensaKekkaTblDataSet.KensaKanryoInputListDataTable dispDT = new KensaKekkaTblDataSet.KensaKanryoInputListDataTable();

        //    foreach (KensaKekkaTblDataSet.KensaKanryoInputListRow row in dataTable.Rows)
        //    {
        //        row.kyokaiNoCol = row.KensaIraiHokenjoCd + "-"
        //                            + Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy") + "-"
        //                            + row.KensaIraiRenban;

        //        dispDT.ImportRow(row);
        //    }

        //    return dispDT;
        //}
        //#endregion
        #endregion

        #endregion
    }
    #endregion
}
