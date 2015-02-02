using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanYoteiListHassoOutput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Control;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanYoteiListHassoOutputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JinendoGaikanYoteiListHassoOutputForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// errFlg
        /// </summary>
        private bool _errFlg = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JinendoGaikanYoteiListHassoOutputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JinendoGaikanYoteiListHassoOutputForm()
        {
            InitializeComponent();

            SetControlDomain();
        }
        #endregion

        #region イベント

        #region JinendoGaikanYoteiListHassoOutputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanYoteiListHassoOutputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanYoteiListHassoOutputForm_Load(object sender, EventArgs e)
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
        /// 2014/09/18  DatNT　  新規作成
        /// 2014/09/26  HuyTX　  新規作成
        /// 2014/11/17  HuyTX　  Add new property pass to AL layout
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_errFlg || !IsValidData()) return;

                // 印刷チェック
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "設定された内容で印刷を実行します。よろしいですか？") != System.Windows.Forms.DialogResult.Yes) return;

                //DEL_HuyTX Start
                //string iraiNoFrom = string.Concat(iraiNoFromHokenjoTextBox.Text.Trim().PadLeft(2, '0'), iraiNoFromNendoTextBox.Text.Trim().PadLeft(4, '0'), iraiNoFromRenbanTextBox.Text.Trim().PadLeft(6, '0'));
                //string iraiNoTo = string.Concat(iraiNoToHokenjoTextBox.Text.Trim().PadLeft(2, '9'), iraiNoToNendoTextBox.Text.Trim().PadLeft(4, '9'), iraiNoToRenbanTextBox.Text.Trim().PadLeft(6, '9'));
                //DEL_HuyTX End

                IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                
                //search param
                GaikanYoteiListHassoOutputSearchCond searchCond = new GaikanYoteiListHassoOutputSearchCond();

                searchCond.KensaIraiNendo = nendoTextBox.Text.Trim();
                //MOD_HuyTX Start
                searchCond.KensaIraiIkkatsuSeikyusakiCd = gyoshaCdTextBox.Text.Trim();
                searchCond.HokenjoCdFrom = iraiNoFromHokenjoTextBox.Text.Trim();
                searchCond.HokenjoCdTo = iraiNoToHokenjoTextBox.Text.Trim();
                searchCond.NendoFrom = iraiNoFromNendoTextBox.Text.Trim();
                searchCond.NendoTo = iraiNoToNendoTextBox.Text.Trim();
                searchCond.RenbanFrom = iraiNoFromRenbanTextBox.Text.Trim();
                searchCond.RenbanTo = iraiNoToRenbanTextBox.Text.Trim();

                //MOD_HuyTX End

                searchCond.UketsukeShishoKbnFrom = hijasiGiteuSusgiCdFromTextBox.Text.Trim();
                searchCond.UketsukeShishoKbnTo = hijasiGiteuSusgiCdToTextBox.Text.Trim();

                //print param
                searchCond.MakeList = makeList1RadioButton.Checked ? "1" : (makeList2RadioButton.Checked ? "2" : "3");
                searchCond.Sort1 = sort11RadioButton.Checked ? "1" : "2";
                searchCond.Sort2 = sort21RadioButton.Checked ? "1" : "2";
                searchCond.PrintType1 = printType11RadioButton.Checked ? "1" : "2";
                searchCond.PrintType2 = printType21RadioButton.Checked ? "1" : "2";
                alInput.SearchCond = searchCond;

                new PrintBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/09/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //UketsukeKanriMenuForm frm = new UketsukeKanriMenuForm();
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

        #region JinendoGaikanYoteiListHassoOutputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JinendoGaikanYoteiListHassoOutputForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JinendoGaikanYoteiListHassoOutputForm_KeyDown(object sender, KeyEventArgs e)
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

        #region gyoshaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gyoshaCdTextBox.Text = frm._selectedRow.GyoshaCd;

                    gyoshaNmTextBox.Text = frm._selectedRow.GyoshaNm;
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

        #region iraiNoFromHokenjoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromHokenjoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromHokenjoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boundary.Common.Common.PaddingZeroForTextBoxLeave(sender as ZTextBox,
                                                                iraiNoFromHokenjoTextBox,
                                                                iraiNoToHokenjoTextBox,
                                                                iraiNoFromNendoTextBox,
                                                                iraiNoToNendoTextBox,
                                                                iraiNoFromRenbanTextBox,
                                                                iraiNoToRenbanTextBox);
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

        #region iraiNoFromNendoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromNendoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromNendoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boundary.Common.Common.PaddingZeroForTextBoxLeave(sender as ZTextBox,
                                                                iraiNoFromHokenjoTextBox,
                                                                iraiNoToHokenjoTextBox,
                                                                iraiNoFromNendoTextBox,
                                                                iraiNoToNendoTextBox,
                                                                iraiNoFromRenbanTextBox,
                                                                iraiNoToRenbanTextBox);
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

        #region iraiNoFromRenbanTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromRenbanTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromRenbanTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boundary.Common.Common.PaddingZeroForTextBoxLeave(sender as ZTextBox,
                                                                iraiNoFromHokenjoTextBox,
                                                                iraiNoToHokenjoTextBox,
                                                                iraiNoFromNendoTextBox,
                                                                iraiNoToNendoTextBox,
                                                                iraiNoFromRenbanTextBox,
                                                                iraiNoToRenbanTextBox);
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

        #region iraiNoToHokenjoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoToHokenjoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoToHokenjoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boundary.Common.Common.PaddingZeroForTextBoxLeave(sender as ZTextBox,
                                                                iraiNoFromHokenjoTextBox,
                                                                iraiNoToHokenjoTextBox,
                                                                iraiNoFromNendoTextBox,
                                                                iraiNoToNendoTextBox,
                                                                iraiNoFromRenbanTextBox,
                                                                iraiNoToRenbanTextBox);
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

        #region iraiNoToNendoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoToNendoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoToNendoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boundary.Common.Common.PaddingZeroForTextBoxLeave(sender as ZTextBox,
                                                                iraiNoFromHokenjoTextBox,
                                                                iraiNoToHokenjoTextBox,
                                                                iraiNoFromNendoTextBox,
                                                                iraiNoToNendoTextBox,
                                                                iraiNoFromRenbanTextBox,
                                                                iraiNoToRenbanTextBox);
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

        #region iraiNoToRenbanTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoToRenbanTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoToRenbanTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boundary.Common.Common.PaddingZeroForTextBoxLeave(sender as ZTextBox,
                                                                iraiNoFromHokenjoTextBox,
                                                                iraiNoToHokenjoTextBox,
                                                                iraiNoFromNendoTextBox,
                                                                iraiNoToNendoTextBox,
                                                                iraiNoFromRenbanTextBox,
                                                                iraiNoToRenbanTextBox);
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

        #region hijasiGiteuSusgiCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hijasiGiteuSusgiCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hijasiGiteuSusgiCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boundary.Common.Common.PaddingZeroForTextBoxLeave(sender as ZTextBox,
                                                                hijasiGiteuSusgiCdFromTextBox,
                                                                hijasiGiteuSusgiCdToTextBox);

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

        #region gyoshaCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　  Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _errFlg = false;

                if (string.IsNullOrEmpty(gyoshaCdTextBox.Text.Trim()))
                {
                    gyoshaNmTextBox.Text = string.Empty;
                    return;
                }

                gyoshaCdTextBox.Text = gyoshaCdTextBox.Text.PadLeft(4, '0');

                Boundary.Common.Common.SetGyoshaNmByCd(gyoshaCdTextBox.Text, gyoshaCdTextBox, gyoshaNmTextBox, false);

                if (string.IsNullOrEmpty(gyoshaNmTextBox.Text.Trim()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "業者データが存在しません。");
                    gyoshaCdTextBox.Focus();
                    _errFlg = true;
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

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  DatNT　  新規作成
        /// 2014/11/18  HuyTX　  Ver1.02 
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 年度
            //MOD_Ver1.02 Start
            //nendoTextBox.Text = (today.Year + 1).ToString();
            nendoTextBox.Text = (Utility.DateUtility.GetNendo(today) + 1).ToString();
            //MOD_Ver1.02 End

            // 業者コード
            gyoshaCdTextBox.Clear();

            // 業者名称
            gyoshaNmTextBox.Clear();

            // 依頼No（開始）保健所
            iraiNoFromHokenjoTextBox.Clear();

            // 依頼No（開始）年度
            iraiNoFromNendoTextBox.Clear();

            // 依頼No（開始）連番
            iraiNoFromRenbanTextBox.Clear();

            // 依頼No（終了）保健所
            iraiNoToHokenjoTextBox.Clear();

            // 依頼No（終了）年度
            iraiNoToNendoTextBox.Clear();

            // 依頼No（終了）連番
            iraiNoToRenbanTextBox.Clear();

            // 支所（開始）
            hijasiGiteuSusgiCdFromTextBox.Clear();

            // 支所（終了）
            hijasiGiteuSusgiCdToTextBox.Clear();

            // 作表対象１
            makeList1RadioButton.Checked = true;

            // 出力順１－１
            sort11RadioButton.Checked = true;

            // 出力順２－１
            sort21RadioButton.Checked = true;

            // 印字方法１－２
            printType12RadioButton.Checked = true;

            // 印字方法２－２
            printType22RadioButton.Checked = true;
        }
        #endregion

        #region IsValidData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidData
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true/false</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            //unit check

            //年度
            if (string.IsNullOrEmpty(nendoTextBox.Text.Trim()))
            {
                errMsg.AppendLine("年度を入力して下さい。");
            }

            // 関連チェック
            //依頼No（開始＆終了）
            if (!Utility.Utility.IsValidKyokaiNo(iraiNoFromHokenjoTextBox, iraiNoFromNendoTextBox, iraiNoFromRenbanTextBox, iraiNoToHokenjoTextBox, iraiNoToNendoTextBox, iraiNoToRenbanTextBox))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検査番号の大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
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
        /// 2014/11/18  HuyTX　   Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            gyoshaCdTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            iraiNoFromHokenjoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoFromNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoFromRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            iraiNoToHokenjoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoToNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            iraiNoToRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

        }
        #endregion

        #endregion

    }
    #endregion
}
