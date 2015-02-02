using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiList;
using FukjBizSystem.Application.Boundary.Common;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KinoHoshoKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoShinseiList
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HoshoShinseiListForm : FukjBaseForm
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
        //  コンストラクタ名 ： HoshoShinseiListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HoshoShinseiListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region HoshoShinseiListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoShinseiListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoShinseiListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.hoshoTorokuTblKensakuTableAdapter.Fill(this.hoshoTorokuTblDataSet.HoshoTorokuTblKensaku);
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
        /// 2014/07/17　HuyTX    新規作成
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
                    this.kinoHoshoKanriListPanel,
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
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                hoshoTorokuKensakikanFromTextBox.Text = string.Empty;
                hoshoTorokuKensakikanToTextBox.Text = string.Empty;
                hoshoTorokuNendoFromTextBox.Text = string.Empty;
                hoshoTorokuNendoToTextBox.Text = string.Empty;
                hoshoTorokuRenbanFromTextBox.Text = string.Empty;
                hoshoTorokuRenbanToTextBox.Text = string.Empty;
                addConditionsFlgCheckBox.Checked = false;
                torokuKakuninDtFromDateTimePicker.Value = _currentDateTime;
                torokuKakuninDtToDateTimePicker.Value = _currentDateTime;
                torokuKakuninDtFromDateTimePicker.Enabled = false;
                torokuKakuninDtToDateTimePicker.Enabled = false;

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
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidData())
                {
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
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kinoHoshoKanriListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string kenshakikan = kinoHoshoKanriListDataGridView.CurrentRow.Cells[HoshoTorokuKensakikanNoCol.Name].Value.ToString();
                string nendo = kinoHoshoKanriListDataGridView.CurrentRow.Cells[HoshoTorokuNendoNoCol.Name].Value.ToString();
                string renban = kinoHoshoKanriListDataGridView.CurrentRow.Cells[HoshoTorokuRenbanNoCol.Name].Value.ToString();

                HoshoShinseiShosaiForm frm = new HoshoShinseiShosaiForm(kenshakikan, nendo, renban);
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

        #region checkDataOutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： checkDataOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void checkDataOutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kinoHoshoKanriListDataGridView.RowCount == 0) return;

                //Ver1.05 Start
                //string fileName = Properties.Settings.Default.InputCheckFileNm.ToString();
                //string sourcePath = Properties.Settings.Default.InputCheckFileFolder.ToString();

                string fileName = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_046, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002);
                string sourcePath = FukjBizSystem.Application.Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_046, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                //Ver1.05 End

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = Path.Combine(sourcePath, fileName);
                    string targetFile = Path.Combine(fbd.SelectedPath, fileName);

                    if (File.Exists(targetFile))
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, string.Format("既に同名のファイル（{0}）が存在しています。上書きして処理を続行しますか？", fileName)) == DialogResult.Yes)
                        {
                            FileInfo fi = new FileInfo(targetFile);
                            if (fi.IsReadOnly)
                            {
                                MessageForm.Show2(MessageForm.DispModeType.Error, fileName + "を上書きできません。");
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    File.Copy(sourceFile, targetFile, true);

                    //output excel
                    OutputExcel(kinoHoshoKanriListDataGridView, targetFile);

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
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kinoHoshoKanriListDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "機能保証マスタ一覧";
                Common.Common.FlushGridviewDataToExcel(kinoHoshoKanriListDataGridView, outputFilename);
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
        /// 2014/07/17　HuyTX    新規作成
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

        #region addConditionsFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： addConditionsFlgCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void addConditionsFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                torokuKakuninDtFromDateTimePicker.Enabled = addConditionsFlgCheckBox.Checked;
                torokuKakuninDtToDateTimePicker.Enabled = addConditionsFlgCheckBox.Checked;

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

        #region kinoHoshoKanriListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kinoHoshoKanriListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kinoHoshoKanriListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1)
                {
                    return;
                }

                string kenshakikan = kinoHoshoKanriListDataGridView.CurrentRow.Cells[HoshoTorokuKensakikanNoCol.Name].Value.ToString().Trim();
                string nendo = kinoHoshoKanriListDataGridView.CurrentRow.Cells[HoshoTorokuNendoNoCol.Name].Value.ToString();
                string renban = kinoHoshoKanriListDataGridView.CurrentRow.Cells[HoshoTorokuRenbanNoCol.Name].Value.ToString().Trim();

                HoshoShinseiShosaiForm frm = new HoshoShinseiShosaiForm(kenshakikan, nendo, renban);
                //Program.mForm.ShowForm(frm);
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

        #region HoshoShinseiListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoShinseiListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoShinseiListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F2:
                        shosaiButton.PerformClick();
                        break;

                    case Keys.F5:
                        checkDataOutputButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.PerformClick();
                        break;

                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #region hoshoTorokuKensakikanFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuKensakikanFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　HuyTX    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuKensakikanFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if(string.IsNullOrEmpty(hoshoTorokuKensakikanFromTextBox.Text.Trim())) return;

                hoshoTorokuKensakikanFromTextBox.Text = hoshoTorokuKensakikanFromTextBox.Text.PadLeft(4, '0');
                hoshoTorokuKensakikanToTextBox.Text = hoshoTorokuKensakikanFromTextBox.Text.PadLeft(4, '0');

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

        #region hoshoTorokuNendoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuNendoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　HuyTX    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuNendoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if(string.IsNullOrEmpty(hoshoTorokuNendoFromTextBox.Text.Trim())) return;

                hoshoTorokuNendoFromTextBox.Text = hoshoTorokuNendoFromTextBox.Text.Trim().PadLeft(2, '0');
                hoshoTorokuNendoToTextBox.Text = hoshoTorokuNendoFromTextBox.Text.Trim().PadLeft(2, '0');

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

        #region hoshoTorokuRenbanFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuRenbanFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　HuyTX    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuRenbanFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(hoshoTorokuRenbanFromTextBox.Text.Trim())) return;

                hoshoTorokuRenbanFromTextBox.Text = hoshoTorokuRenbanFromTextBox.Text.Trim().PadLeft(5, '0');
                hoshoTorokuRenbanToTextBox.Text = hoshoTorokuRenbanFromTextBox.Text.Trim().PadLeft(5, '0');

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

        #region hoshoTorokuKensakikanToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuKensakikanToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　HuyTX    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuKensakikanToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(hoshoTorokuKensakikanToTextBox.Text.Trim())) return;

                hoshoTorokuKensakikanToTextBox.Text = hoshoTorokuKensakikanToTextBox.Text.Trim().PadLeft(4, '0');

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

        #region hoshoTorokuNendoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuNendoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　HuyTX    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuNendoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(hoshoTorokuNendoToTextBox.Text.Trim())) return;

                hoshoTorokuNendoToTextBox.Text = hoshoTorokuNendoToTextBox.Text.Trim().PadLeft(2, '0');

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

        #region hoshoTorokuRenbanToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuRenbanToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　HuyTX    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuRenbanToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(hoshoTorokuRenbanToTextBox.Text.Trim())) return;

                hoshoTorokuRenbanToTextBox.Text = hoshoTorokuRenbanToTextBox.Text.Trim().PadLeft(5, '0');

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

        #region torokuKakuninDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuKakuninDtFromDateTimePicker_ValueChanged
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
        private void torokuKakuninDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                torokuKakuninDtToDateTimePicker.Value = torokuKakuninDtFromDateTimePicker.Value;
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
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.kinoHoshoKanriListPanel.Top;
            this._defaultListPanelHeight = this.kinoHoshoKanriListPanel.Height;

            torokuKakuninDtFromDateTimePicker.Value = _currentDateTime;
            torokuKakuninDtToDateTimePicker.Value = _currentDateTime;

            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //検索結果件数
            kinoHoshoKanriListCountLabel.Text = alOutput.HoshoTorokuTblDT.Count + "件";

            //set data for display gridview
            kinoHoshoKanriListDataGridView.DataSource = alOutput.HoshoTorokuTblDT;

            //convert nendo to Heisei
            ConvertNendoToHeisei();

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
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            kinoHoshoKanriListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            alInput.KenshakikanFrom = hoshoTorokuKensakikanFromTextBox.Text.Trim();
            alInput.KenshakikanTo = hoshoTorokuKensakikanToTextBox.Text.Trim();
            alInput.NendoFrom = hoshoTorokuNendoFromTextBox.Text.Trim();
            alInput.NendoTo = hoshoTorokuNendoToTextBox.Text.Trim();

            alInput.RenbanFrom = hoshoTorokuRenbanFromTextBox.Text.Trim();
            alInput.RenbanTo = hoshoTorokuRenbanToTextBox.Text.Trim();
            if (addConditionsFlgCheckBox.Checked)
            {
                alInput.KakuninDtFrom = torokuKakuninDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                alInput.KakuninDtTo = torokuKakuninDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            kinoHoshoKanriListCountLabel.Text = alOutput.HoshoTorokuTblDT.Count + "件";

            if (alOutput.HoshoTorokuTblDT.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            //set data for display gridview
            kinoHoshoKanriListDataGridView.DataSource = alOutput.HoshoTorokuTblDT;

            ConvertNendoToHeisei();

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
        /// 2014/07/17　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            string torokuNoFrom = hoshoTorokuKensakikanFromTextBox.Text.Trim() + hoshoTorokuNendoFromTextBox.Text.Trim() + hoshoTorokuRenbanFromTextBox.Text.Trim();

            string torokuNoTo = hoshoTorokuKensakikanToTextBox.Text.Trim() + hoshoTorokuNendoToTextBox.Text.Trim() + hoshoTorokuRenbanToTextBox.Text.Trim();

            //（開始）
            if ((!string.IsNullOrEmpty(hoshoTorokuKensakikanFromTextBox.Text.Trim())
                || !string.IsNullOrEmpty(hoshoTorokuNendoFromTextBox.Text.Trim())
                || !string.IsNullOrEmpty(hoshoTorokuRenbanFromTextBox.Text.Trim()))
                && torokuNoFrom.Length != 11)
            {
                errMsg.AppendLine("保証登録番号（開始）は[4桁]-[2桁]-[5桁]で入力して下さい。");
            }

            //（終了）
            if ((!string.IsNullOrEmpty(hoshoTorokuKensakikanToTextBox.Text.Trim())
                || !string.IsNullOrEmpty(hoshoTorokuNendoToTextBox.Text.Trim())
                || !string.IsNullOrEmpty(hoshoTorokuRenbanToTextBox.Text.Trim()))
                && torokuNoTo.Length != 11)
            {
                errMsg.AppendLine("保証登録番号（終了）は[4桁]-[2桁]-[5桁]で入力して下さい。");
            }

            //関連チェック

            //保証登録番号（開始＆終了)
            if (string.IsNullOrEmpty(errMsg.ToString()))
            {
                if (!string.IsNullOrEmpty(torokuNoFrom) 
                    && !string.IsNullOrEmpty(torokuNoTo) 
                    && Convert.ToDouble(torokuNoFrom) > Convert.ToDouble(torokuNoTo))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。保証登録番号の大小関係を確認してください。");
                }

            }

            //登録確認年月日（開始＆終了）(8, 9)
            if (addConditionsFlgCheckBox.Checked && Convert.ToInt32(torokuKakuninDtFromDateTimePicker.Value.ToString("yyyyMMdd")) > Convert.ToInt32(torokuKakuninDtToDateTimePicker.Value.ToString("yyyyMMdd")))
            {
                errMsg.AppendLine("範囲指定が正しくありません。登録確認年月日の大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region OutputExcel
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： OutputExcel
        /// <summary>
        ///  指定GridviewのデータをExcelに出力する
        /// </summary>
        /// <param name="targetDataGridView">対象DataGridView</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void OutputExcel(DataGridView targetDataGridView, string outputFilename)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet renbanWorkSheet = null;
            Microsoft.Office.Interop.Excel.Worksheet csvWorkSheet = null;

            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                object misValue = System.Reflection.Missing.Value;

                xlApp.Visible = true;
                xlApp.DisplayAlerts = false;

                xlWorkBook = xlApp.Workbooks.Open(
                    outputFilename,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing);

                renbanWorkSheet = (Worksheet)xlWorkBook.Sheets["保証連番"];
                csvWorkSheet = (Worksheet)xlWorkBook.Sheets["CSV"];

                for (int i = 0; i <= targetDataGridView.Rows.Count - 1; i++)
                {
                    DataGridViewCellCollection cell = targetDataGridView.Rows[i].Cells;
                    int rowIdx = i + 1;

                    #region Sheet 保証連番

                    //C列 = 保証登録年度(和暦2桁)
                    CellOuputFormat(renbanWorkSheet, rowIdx + 1, 3, cell[HoshoTorokuNendoNoCol.Name].Value.ToString());

                    //D列 = 保証登録連番
                    CellOuputFormat(renbanWorkSheet, rowIdx + 1, 4, cell[HoshoTorokuRenbanNoCol.Name].Value.ToString());

                    #endregion

                    #region Sheet CSV

                    //A列 = 保証登録年度(西暦4桁)
                    // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
                    //csvWorkSheet.Cells[rowIdx, 1] = Common.Common.ConvertToHoshouNendoSeireki(cell[HoshoTorokuNendoNoCol.Name].Value.ToString());
                    //csvWorkSheet.Cells[rowIdx, 1] = Utility.Utility.ConvertToSeireki(Int32.Parse(cell["HoshoTorokuNendoNoCol"].Value.ToString()));
                    // 20140811 habu End
                    csvWorkSheet.Cells[rowIdx, 1] = Utility.DateUtility.ConvertFromWareki(cell[HoshoTorokuNendoNoCol.Name].Value.ToString()).Substring(0, 4);

                    //B列 = 保証登録連番
                    CellOuputFormat(csvWorkSheet, rowIdx, 2, cell[HoshoTorokuRenbanNoCol.Name].Value.ToString());

                    //C列 = 登録確認年(西暦4桁)
                    CellOuputFormat(csvWorkSheet, rowIdx, 3, cell[TorokuKakuninDtCol.Name].Value.ToString().PadLeft(10, ' ').Substring(0, 4));

                    //D列 = 登録確認月
                    CellOuputFormat(csvWorkSheet, rowIdx, 4, cell[TorokuKakuninDtCol.Name].Value.ToString().PadLeft(10, ' ').Substring(5, 2));

                    //E列 = 登録確認日
                    CellOuputFormat(csvWorkSheet, rowIdx, 5, cell[TorokuKakuninDtCol.Name].Value.ToString().PadLeft(10, ' ').Substring(8, 2));

                    //F列 = 使用年(西暦4桁)
                    //CellOuputFormat(csvWorkSheet, rowIdx, 6, cell["ShiyoKaisiDtCol"].Value.ToString().PadLeft(10, ' ').Substring(0, 4));
                    csvWorkSheet.Cells[rowIdx, 6] = cell[ShiyoKaisiDtCol.Name].Value.ToString().PadLeft(10, ' ').Substring(0, 4);

                    //G列 = 使用月
                    CellOuputFormat(csvWorkSheet, rowIdx, 7, cell[ShiyoKaisiDtCol.Name].Value.ToString().PadLeft(10, ' ').Substring(5, 2));

                    //H列 = 使用日
                    CellOuputFormat(csvWorkSheet, rowIdx, 8, cell[ShiyoKaisiDtCol.Name].Value.ToString().PadLeft(10, ' ').Substring(8, 2));

                    //I列 = 全浄連登録番号
                    CellOuputFormat(csvWorkSheet, rowIdx, 9, cell[JokasoZenjyokyoTorokuNoCol.Name].Value.ToString());

                    //J列 = 人槽
                    CellOuputFormat(csvWorkSheet, rowIdx, 10, cell[JokasoNinsoCol.Name].Value.ToString());

                    //K列 = 補助市町村
                    CellOuputFormat(csvWorkSheet,rowIdx, 11, cell[ShichosonCdCol.Name].Value.ToString());

                    #endregion
                }

                xlWorkBook.SaveAs(outputFilename,
                                    Missing.Value,
                                    Missing.Value,
                                    Missing.Value,
                                    false,
                                    Missing.Value,
                                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                                    Missing.Value,
                                    Missing.Value,
                                    Missing.Value,
                                    Missing.Value,
                                    Missing.Value);

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (renbanWorkSheet != null) Marshal.ReleaseComObject(renbanWorkSheet);

                if (csvWorkSheet != null) Marshal.ReleaseComObject(csvWorkSheet);

                if (xlWorkBook != null) Marshal.ReleaseComObject(xlWorkBook);

                if (xlApp != null) Marshal.ReleaseComObject(xlApp);

                GC.Collect();
            }
        }
        #endregion

        #region CellOuputFormat
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： CellOuputFormat
        /// <summary>
        ///
        /// </summary>
        /// <param name="workSheet"></param>
        /// <param name="rowIdx"></param>
        /// <param name="colIdx"></param>
        /// <param name="value"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void CellOuputFormat(Worksheet workSheet, int rowIdx, int colIdx, object value)
        {
            workSheet.Cells[rowIdx, colIdx] = "'" + value;
            Range rng = (Range)workSheet.Cells[rowIdx, colIdx];
            rng.HorizontalAlignment = XlHAlign.xlHAlignRight;
        }
        #endregion

        #region ConvertNendoToHeisei
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： ConvertNendoToHeisei
        /// <summary>
        ///
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void ConvertNendoToHeisei()
        {
            //convert nendo to Heisei
            foreach (DataGridViewRow row in kinoHoshoKanriListDataGridView.Rows)
            {
                // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
                //row.Cells[HoshoTorokuNendoNoCol.Name].Value = Common.Common.ConvertToHoshouNendoWareki(row.Cells[HoshoTorokuNendoNoCol.Name].Value.ToString());
                //row.Cells["HoshoTorokuNendoNoCol"].Value = Utility.Utility.ConvertToHeisei(Int32.Parse(row.Cells["HoshoTorokuNendoNoCol"].Value.ToString()));
                // 20140811 habu End
                row.Cells[HoshoTorokuNendoNoCol.Name].Value = Utility.DateUtility.ConvertToWareki(row.Cells[HoshoTorokuNendoNoCol.Name].Value.ToString(), "yy");
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
        /// 2014/10/14　AnhNV　　    新規作成
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
