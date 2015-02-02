using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoNoPrint;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KinoHoshoKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoNoPrintForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HoshoNoPrintForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// 端末
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// _hoshoNoPrintInfoDataTable
        /// </summary>
        private HoshoTorokuTblDataSet.HoshoNoPrintInfoDataTable _hoshoNoPrintInfoDataTable = new HoshoTorokuTblDataSet.HoshoNoPrintInfoDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HoshoNoPrintForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HoshoNoPrintForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region HoshoNoPrintForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoNoPrintForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoNoPrintForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                shinkiHakkoRadioButton_CheckedChanged(null, null);

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

        #region shinkiHakkoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shinkiHakkoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shinkiHakkoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                hoshoTorokuKensakikanFromTextBox.Enabled = false;
                hoshoTorokuNendoFromTextBox.Enabled = false;
                hoshoTorokuRenbanFromTextBox.Enabled = false;
                hoshoTorokuKensakikanToTextBox.Enabled = false;
                hoshoTorokuNendoToTextBox.Enabled = false;
                hoshoTorokuRenbanToTextBox.Enabled = false;
                printCountTextBox.Enabled = true;
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

        #region saiHakkoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saiHakkoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saiHakkoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                hoshoTorokuKensakikanFromTextBox.Enabled = true;
                hoshoTorokuNendoFromTextBox.Enabled = true;
                hoshoTorokuRenbanFromTextBox.Enabled = true;
                hoshoTorokuKensakikanToTextBox.Enabled = true;
                hoshoTorokuNendoToTextBox.Enabled = true;
                hoshoTorokuRenbanToTextBox.Enabled = true;
                printCountTextBox.Enabled = false;
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
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string unitCheck = string.Empty;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "設定された内容で印刷を実行します。よろしいですか？") 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    if (shinkiHakkoRadioButton.Checked) // mode New issues
                    {
                        unitCheck = UnitCheck(true);
                    }
                    else // re-issues
                    {
                        unitCheck = UnitCheck(false);
                    }

                    if (!string.IsNullOrEmpty(unitCheck))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, unitCheck);
                        return;
                    }

                    DoUpdate();
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
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //KinoMenuForm frm = new KinoMenuForm();
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

        #region HoshoNoPrint_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoNoPrint_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoNoPrint_KeyDown(object sender, KeyEventArgs e)
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

        #region districtMasterSearchButton_Click
        // DEL 20140804 START ZynasSou
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： districtMasterSearchButton_Click
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="sender"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/07/16  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void districtMasterSearchButton_Click(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        ChikuMstSearchForm frm = new ChikuMstSearchForm();
        //        frm.ShowDialog();

        //        if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
        //        {
        //            hojyoShichosonNmTextBox.Text = frm._selectedRow.Cells["ChikuNmCol"].Value.ToString();
        //            hojyoShichosonCdTextBox.Text = frm._selectedRow.Cells["ChikuCdCol"].Value.ToString();
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
        // DEL 20140804 END ZynasSou
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
        /// 2014/10/14  DatNT　  v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuKensakikanFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(hoshoTorokuKensakikanFromTextBox.Text))
                {
                    hoshoTorokuKensakikanFromTextBox.Text = hoshoTorokuKensakikanFromTextBox.Text.PadLeft(4, '0');

                    hoshoTorokuKensakikanToTextBox.Text = hoshoTorokuKensakikanFromTextBox.Text;
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
        /// 2014/10/14  DatNT　   v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuNendoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(hoshoTorokuNendoFromTextBox.Text))
                {
                    hoshoTorokuNendoFromTextBox.Text = hoshoTorokuNendoFromTextBox.Text.PadLeft(2, '0');

                    hoshoTorokuNendoToTextBox.Text = hoshoTorokuNendoFromTextBox.Text;
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
        /// 2014/10/14  DatNT　   v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuRenbanFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(hoshoTorokuRenbanFromTextBox.Text))
                {
                    hoshoTorokuRenbanFromTextBox.Text = hoshoTorokuRenbanFromTextBox.Text.PadLeft(5, '0');

                    hoshoTorokuRenbanToTextBox.Text = hoshoTorokuRenbanFromTextBox.Text;
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
        /// 2014/10/14  DatNT　   v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuKensakikanToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(hoshoTorokuKensakikanToTextBox.Text))
                {
                    hoshoTorokuKensakikanToTextBox.Text = hoshoTorokuKensakikanToTextBox.Text.PadLeft(4, '0');
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
        /// 2014/10/14  DatNT　   v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuNendoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(hoshoTorokuNendoToTextBox.Text))
                {
                    hoshoTorokuNendoToTextBox.Text = hoshoTorokuNendoToTextBox.Text.PadLeft(2, '0');
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
        /// 2014/10/14  DatNT　   v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuRenbanToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(hoshoTorokuRenbanToTextBox.Text))
                {
                    hoshoTorokuRenbanToTextBox.Text = hoshoTorokuRenbanToTextBox.Text.PadLeft(5, '0');
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
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 検査機関名称
            Utility.Utility.SetComboBoxList(kensaKikanNmComboBox, alOutput.HoteiKanriMstDataTable, "JimukyokuNm", "JimukyokuKbn", true);

            // 登録確認法人名称
            Utility.Utility.SetComboBoxList(torokuKakuninHojinNmComboBox, alOutput.HoteiKanriMstDataTable, "JimukyokuNm", "JimukyokuKbn", true);
        }
        #endregion

        #region UnitCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UnitCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string UnitCheck(bool isNewIssues)
        {
            StringBuilder errMess = new StringBuilder();

            if (isNewIssues)
            {
                // 印刷枚数 9
                if(string.IsNullOrEmpty(printCountTextBox.Text.Trim()))
                {
                    errMess.Append("必須項目：印刷枚数が入力されていません。\r\n");
                }
            }
            else // re-issues
            {
                // 保証登録検査機関, 保証登録年度, 保証登録連番
                if (string.IsNullOrEmpty(hoshoTorokuKensakikanFromTextBox.Text)
                    || string.IsNullOrEmpty(hoshoTorokuNendoFromTextBox.Text)
                    || string.IsNullOrEmpty(hoshoTorokuRenbanFromTextBox.Text)
                    || string.IsNullOrEmpty(hoshoTorokuKensakikanToTextBox.Text)
                    || string.IsNullOrEmpty(hoshoTorokuNendoToTextBox.Text)
                    || string.IsNullOrEmpty(hoshoTorokuRenbanToTextBox.Text))
                {
                    errMess.Append("必須項目：保証登録番号が全て入力されていません。\r\n");
                }
                else
                {
                    if (hoshoTorokuKensakikanFromTextBox.Text.Length != 4
                        || hoshoTorokuNendoFromTextBox.Text.Length != 2
                        || hoshoTorokuRenbanFromTextBox.Text.Length != 5)
                    {
                        errMess.Append("保証登録番号(開始)は[4桁]-[2桁]-[5桁]の形式で入力して下さい。\r\n");
                    }

                    if(hoshoTorokuKensakikanToTextBox.Text.Length != 4
                        || hoshoTorokuNendoToTextBox.Text.Length != 2
                        || hoshoTorokuRenbanToTextBox.Text.Length != 5)
                    {
                        errMess.Append("保証登録番号(終了)は[4桁]-[2桁]-[5桁]の形式で入力して下さい。\r\n");
                    }
                }

                if (string.IsNullOrEmpty(errMess.ToString()))
                {
                    if ((Convert.ToDecimal(hoshoTorokuKensakikanFromTextBox.Text + "" + hoshoTorokuNendoFromTextBox.Text + "" + hoshoTorokuRenbanFromTextBox.Text)
                        > Convert.ToDecimal(hoshoTorokuKensakikanToTextBox.Text + "" + hoshoTorokuNendoToTextBox.Text + "" + hoshoTorokuRenbanToTextBox.Text))
                        )
                    {
                        errMess.Append("範囲指定が正しくありません。保証登録番号の大小関係を確認してください。\r\n");
                    }
                }
            }

            // 検査機関 10
            if (kensaKikanNmComboBox.SelectedIndex == -1 || kensaKikanNmComboBox.SelectedIndex == 0)
            {
                errMess.Append("必須項目：検査機関が選択されていません。\r\n");
            }

            // 設置場所 11
            // DEL 20140804 START ZynasSou
            //if (settibashoTextBox.Text.Trim().Length > 80)
            //{
            //    errMess.Append("設置場所は80文字以下で入力して下さい。\r\n");
            //}
            // DEL 20140804 END ZynasSou
            
            // 登録確認法人 15
            if (torokuKakuninHojinNmComboBox.SelectedIndex == -1 || torokuKakuninHojinNmComboBox.SelectedIndex == 0)
            {
                errMess.Append("必須項目：登録確認法人が選択されていません。\r\n");
            }

            // 確認者名 16
            if (string.IsNullOrEmpty(kakuninshaNmTextBox.Text.Trim()))
            {
                errMess.Append("必須項目：確認者名が入力されていません。\r\n");
            }
            else
            {
                if (kakuninshaNmTextBox.Text.Trim().Length > 20)
                {
                    errMess.Append("確認者名は20文字以下で入力して下さい。\r\n");
                }
            }

            return errMess.ToString();
        }
        #endregion

        #region CreateDataInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable CreateDataInsert()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            string nendo = Utility.DateUtility.GetNendo(now).ToString();

            HoshoTorokuTblDataSet.HoshoTorokuTblDataTable insertDT = new HoshoTorokuTblDataSet.HoshoTorokuTblDataTable();

            int count = Convert.ToInt32(printCountTextBox.Text);

            for (int i = 0; i < count; i++)
            {
                HoshoTorokuTblDataSet.HoshoTorokuTblRow insertRow = insertDT.NewHoshoTorokuTblRow();

                // 保証登録検査機関
                insertRow.HoshoTorokuKensakikan = "40" + kensaKikanNmComboBox.SelectedValue.ToString().PadLeft(2, '0');

                // 保証登録年度
                insertRow.HoshoTorokuNendo = nendo;

                // 保証登録連番
                if (kensaKikanNmComboBox.SelectedValue.ToString() == "0")
                {
                    insertRow.HoshoTorokuRenban = Utility.Saiban.GetSaibanRenban(nendo, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_00);
                }
                else if (kensaKikanNmComboBox.SelectedValue.ToString() == "1")
                {
                    insertRow.HoshoTorokuRenban = Utility.Saiban.GetSaibanRenban(nendo, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_01);
                }

                // 保健所受理番号２（保健所）
                insertRow.HoshoTorokuHokenjoCd = string.Empty;

                // 保健所受理番号１（年度）
                insertRow.HoshoTorokuHokenjoNendo = string.Empty;

                // 保健所受理番号３（市町村）
                insertRow.HoshoTorokuHokenjoShichosonCd = string.Empty;

                // 保健所受理番号４（連番）
                insertRow.HoshoTorokuHokenjoRenban = string.Empty;

                // 支所区分
                insertRow.HoshoTorokuShishoKbn = string.Empty;

                // 売上日付
                insertRow.HoshoTorokuUriageDt = string.Empty;

                // 販売先コード
                insertRow.HoshoTorokuHanbaisakiCd = string.Empty;
                
                // 金額
                insertRow.HoshoTorokuAmt = 0;

                // 入金額
                insertRow.HoshoTorokuNyukinAmt = 0;

                // 入金区分
                insertRow.HoshoTorokuNyukinKbn = string.Empty;

                // 入金日付
                insertRow.HoshoTorokuNyukinDt = string.Empty;

                // 入金完了区分
                insertRow.HoshoTorokuNyukinKanryoKbn = string.Empty;

                // 発行日付
                insertRow.HoshoTorokuHakkoDt = string.Empty;

                // 受理入力日付
                insertRow.HoshoTorokuJyurinyuryokuDt = string.Empty;

                // 工事業者
                insertRow.HoshoTorokuKojiGyosha = string.Empty;

                // 浄化槽台帳保健所コード
                insertRow.HoshoTorokuJokasoHokenjoCd = string.Empty;

                // 浄化槽台帳登録年月
                insertRow.HoshoTorokuJokasoTorokuNendo = string.Empty;
                
                // 浄化槽台帳連番
                insertRow.HoshoTorokuJokasoRenban = string.Empty;

                // 設置者名カナ
                insertRow.HoshoTorokuSetchishaKana = string.Empty;

                // 設置者名漢字
                insertRow.HoshoTorokuSetchishaNm = string.Empty;

                // 設置者郵便番号
                insertRow.HoshoTorokuSetchishaZipCd = string.Empty;

                // 保証登録住所
                insertRow.HoshoTorokuSetchishaAdr = string.Empty;

                // 電話番号
                insertRow.HoshoTorokuSetchishaTelNo = string.Empty;
                
                // 設置場所
                // UPD 20140804 START ZynasSou
                //insertRow.HoshoTorokuSetchibashoAdr = settibashoTextBox.Text.Trim();
                insertRow.HoshoTorokuSetchibashoAdr = string.Empty;
                // UPD 20140804 END ZynasSou

                // 郵便番号
                insertRow.HoshoTorokuSetchibashoZipCd = string.Empty;

                // 建物の用途
                insertRow.HoshoTorokuTatemonoyoto = string.Empty;

                // 実使用人員
                insertRow.HoshoTorokuJitsushiyojinin = string.Empty;

                // 補助市町村
                // UPD 20140804 START ZynasSou
                //insertRow.HoshoTorokuHojoShichosonCd = hojyoShichosonCdTextBox.Text;
                insertRow.HoshoTorokuHojoShichosonCd = string.Empty;
                // UPD 20140804 END ZynasSou

                // 浄化槽登録番号
                insertRow.HoshoTorokuJokasoTorokuNo = string.Empty;

                // 人槽
                insertRow.HoshoTorokuNinso = string.Empty;

                // メーカー
                insertRow.HoshoTorokuMakerCd = string.Empty;

                // 浄化槽検査機関
                insertRow.HoshoTorokuJokasoKensakikan = kensaKikanNmComboBox.SelectedValue.ToString();

                // 使用開始日付
                insertRow.HoshoTorokuShiyokaishiDt = string.Empty;

                // 受理日付
                insertRow.HoshoTorokuJyuriDt = string.Empty;

                // 登録確認日付
                insertRow.HoshoTorokuTorokuKakuninDt = string.Empty;

                // 取下日付
                insertRow.HoshoTorokuTorisageDt = string.Empty;

                // 交換日付
                insertRow.HoshoTorokuKokanDt = string.Empty;

                // 返金
                insertRow.HoshoTorokuHenkin = 0;

                // 削除フラグ
                insertRow.HoshoTorokuDeleteFlg = "0";

                insertRow.InsertDt = now;
                insertRow.InsertTarm = pcUpdate;
                insertRow.InsertUser = loginUser;
                insertRow.UpdateDt = now;
                insertRow.UpdateTarm = pcUpdate;
                insertRow.UpdateUser = loginUser;

                // 行を挿入
                insertDT.AddHoshoTorokuTblRow(insertRow);

                // 行の状態を設定
                insertRow.AcceptChanges();

                // 行の状態を設定（新規）
                insertRow.SetAdded();

                //ADD HuyTX 20140807 START
                HoshoTorokuTblDataSet.HoshoNoPrintInfoRow printRow = _hoshoNoPrintInfoDataTable.NewHoshoNoPrintInfoRow();

                printRow.HoshoTorokuKensakikan = insertRow.HoshoTorokuKensakikan;
                printRow.HoshoTorokuNendo = insertRow.HoshoTorokuNendo;
                printRow.HoshoTorokuRenban = insertRow.HoshoTorokuRenban;
                printRow.JimukyokuNm1 = kensaKikanNmComboBox.GetItemText(kensaKikanNmComboBox.SelectedItem);
                printRow.TsuikaKisaiKomoku = tsuikaKisaiKomokuTextBox.Text;
                printRow.JimukyokuKbn2 = torokuKakuninHojinNmComboBox.SelectedValue.ToString();
                printRow.JimukyokuNm2 = torokuKakuninHojinNmComboBox.GetItemText(torokuKakuninHojinNmComboBox.SelectedItem);
                printRow.KakuninShaNm = kakuninshaNmTextBox.Text;

                _hoshoNoPrintInfoDataTable.AddHoshoNoPrintInfoRow(printRow);
                printRow.AcceptChanges();
                printRow.SetAdded();

                //ADD HuyTX 20140807 END
            }

            return insertDT;
        }
        #endregion

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable CreateDataUpdate(
            HoshoTorokuTblDataSet.HoshoTorokuTblDataTable dataTable)
        {
            for (int i = 0; i < dataTable.Count; i++)
            {
                // DEL 20140804 START ZynasSou
                //// 設置場所
                ////dataTable[i].HoshoTorokuSetchibashoAdr = settibashoTextBox.Text.Trim();
                // DEL 20140804 END ZynasSou

                // DEL 20140804 START ZynasSou
                //// 補助市町村
                //dataTable[i].HoshoTorokuHojoShichosonCd = hojyoShichosonCdTextBox.Text;
                // DEL 20140804 END ZynasSou

                // 浄化槽検査機関
                dataTable[i].HoshoTorokuJokasoKensakikan = kensaKikanNmComboBox.SelectedValue.ToString();

                //ADD HuyTX 20140807 START
                HoshoTorokuTblDataSet.HoshoNoPrintInfoRow printRow = _hoshoNoPrintInfoDataTable.NewHoshoNoPrintInfoRow();

                printRow.HoshoTorokuKensakikan = dataTable[i].HoshoTorokuKensakikan;
                printRow.HoshoTorokuNendo = dataTable[i].HoshoTorokuNendo;
                printRow.HoshoTorokuRenban = dataTable[i].HoshoTorokuRenban;
                printRow.JimukyokuNm1 = kensaKikanNmComboBox.GetItemText(kensaKikanNmComboBox.SelectedItem);
                printRow.TsuikaKisaiKomoku = tsuikaKisaiKomokuTextBox.Text;
                printRow.JimukyokuKbn2 = torokuKakuninHojinNmComboBox.SelectedValue.ToString();
                printRow.JimukyokuNm2 = torokuKakuninHojinNmComboBox.GetItemText(torokuKakuninHojinNmComboBox.SelectedItem);
                printRow.KakuninShaNm = kakuninshaNmTextBox.Text;

                _hoshoNoPrintInfoDataTable.AddHoshoNoPrintInfoRow(printRow);
                printRow.AcceptChanges();
                printRow.SetAdded();

                //ADD HuyTX 20140807 END
            }

            return dataTable;
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
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            // insert table
            HoshoTorokuTblDataSet.HoshoTorokuTblDataTable insertDT = new HoshoTorokuTblDataSet.HoshoTorokuTblDataTable();

            // update table
            HoshoTorokuTblDataSet.HoshoTorokuTblDataTable updateDT;

            IPrintBtnClickALInput printInput = new PrintBtnClickALInput();

            //clear all data of table print
            _hoshoNoPrintInfoDataTable.Rows.Clear();

            if (shinkiHakkoRadioButton.Checked)
            {
                insertDT = CreateDataInsert();
                printInput.HoshoTorokuTblInsertDT = insertDT;
            }
            else
            {
                IPrintBtnClickALInput alInput       = new PrintBtnClickALInput();
                
                alInput.KensakikanNendoRenbanFrom   = hoshoTorokuKensakikanFromTextBox.Text  
                                                        // 2014/10/23 DatNT use common Utility.DateUtility.ConvertFromWareki MOD Start
                                                        //// 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
                                                        //+ Common.Common.ConvertToHoshouNendoSeireki(hoshoTorokuNendoFromTextBox.Text)
                                                        ////+ Utility.Utility.ConvertToSeireki(Convert.ToInt32(hoshoTorokuNendoFromTextBox.Text))
                                                        //// 20140811 habu End
                                                        + Utility.DateUtility.ConvertFromWareki(hoshoTorokuNendoFromTextBox.Text).Substring(0, 4)
                                                        // 2014/10/23 DatNT use common Utility.DateUtility.ConvertFromWareki MOD End
                                                        + hoshoTorokuRenbanFromTextBox.Text;

                alInput.KensakikanNendoRenbanTo     = hoshoTorokuKensakikanToTextBox.Text
                                                        // 2014/10/23 DatNT use common Utility.DateUtility.ConvertFromWareki MOD Start
                                                        //// 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
                                                        //+ Common.Common.ConvertToHoshouNendoSeireki(hoshoTorokuNendoToTextBox.Text)
                                                        ////+ Utility.Utility.ConvertToSeireki(Convert.ToInt32(hoshoTorokuNendoToTextBox.Text))
                                                        //// 20140811 habu End
                                                        + Utility.DateUtility.ConvertFromWareki(hoshoTorokuNendoFromTextBox.Text).Substring(0, 4)
                                                        // 2014/10/23 DatNT use common Utility.DateUtility.ConvertFromWareki MOD End
                                                        + hoshoTorokuRenbanToTextBox.Text;

                alInput.IsUpdate                    = false;

                IPrintBtnClickALOutput alOutput     = new PrintBtnClickApplicationLogic().Execute(alInput);

                if (string.IsNullOrEmpty(alOutput.ErrMsg))
                {
                    updateDT = CreateDataUpdate(alOutput.HoshoTorokuTblDT);

                    printInput.HoshoTorokuTblUpdateDT = updateDT;
                }
                else
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
                    return;
                }
            }

            printInput.IsUpdate                     = true;

            //ADD HuyTX 20140807 START
            printInput.HoshoNoPrintInfoDataTable    = _hoshoNoPrintInfoDataTable;
            //ADD HuyTX 20140807 END

            IPrintBtnClickALOutput printOutput      = new PrintBtnClickApplicationLogic().Execute(printInput);
        }
        #endregion

        #endregion

    }
    #endregion
}
