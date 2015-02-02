using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiMakeFile;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaikeiMakeFileForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/10  DatNT　  新規作成
    /// 2014/12/09  kiyokuni　Ver1.03 データなしに対応
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaikeiMakeFileForm : FukjBaseForm
    {
        #region public var

        /// <summary>
        /// returnCond
        /// </summary>
        public KaikeiRendoHdrTblSearchCond returnCond = new KaikeiRendoHdrTblSearchCond();

        /// <summary>
        /// Run SuitoSyukeiStd Success
        /// </summary>
        public bool suitoSyukeiStdSuccess = false;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// DateTime today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();
        
        #region 処理メッセージ

        /// <summary>
        /// 処理開始
        /// </summary>
        private const string MSG_INFO_START_PROCESSING = "処理を開始します。";

        /// <summary>
        /// 処理完了
        /// </summary>
        private const string MSG_INFO_COMPLETE_PROCESSING = "正常に処理が完了しました。";

        /// <summary>
        /// 売上集計処理エラー
        /// </summary>
        private const string MSG_ERR_URIAGE = "売上集計処理に失敗しました。\r\nシステム管理者に連絡してください。";

        /// <summary>
        /// 売上出納集計処理
        /// </summary>
        private const string MSG_ERR_STEP_2 = "売上出納集計処理に失敗しました。\r\nシステム管理者に連絡してください。";

        /// <summary>
        /// 入金出納集計処理
        /// </summary>
        private const string MSG_ERR_STEP_3 = "入金出納集計処理に失敗しました。\r\nシステム管理者に連絡してください。";

        /// <summary>
        /// 対象データなし
        /// </summary>
        private const string MSG_ERR_NO_DATA = "対象データがありません。";

        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KaikeiMakeFileForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KaikeiMakeFileForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KaikeiMakeFileForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaikeiMakeFileForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaikeiMakeFileForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //DoFormLoad();

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

        #region syukeiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syukeiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT　  新規作成
        /// 2014/12/09  kiyokuni　正常完了時のメッセージ判定を追加、ボタンロック処理を追加。メッセージクリアタイミング修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syukeiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                suitoSyukeiStdSuccess = false;

                msgTextBox.Clear();

                if (!CheckCondition()) { return; }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された条件で出納集計処理を実施します。よろしいですか？") != DialogResult.Yes)
                {
                    return;
                }

                syukeiButton.Enabled = false;
                closeButton.Enabled = false;

                msgTextBox.SelectionColor = Color.Blue;
                msgTextBox.AppendText(MSG_INFO_START_PROCESSING + Environment.NewLine);

                // Run UriageSyukeiStd
                if (uriageRadioButton.Checked && uriageBatchCheckBox.Checked)
                {
                    ISyukeiBtnClickALInput uriageInput = new SyukeiBtnClickALInput();
                    MakeALInput(uriageInput, true);
                    ISyukeiBtnClickALOutput uriageOutput = new SyukeiBtnClickApplicationLogic().Execute(uriageInput);
                    
                    // Display Message
                    if (!DispMsg(uriageOutput.UriageErrorFlg, true)) { return; }
                }                

                // Run SuitoSyukeiStd
                ISyukeiBtnClickALInput alInput = new SyukeiBtnClickALInput();
                MakeALInput(alInput, false);
                ISyukeiBtnClickALOutput alOutput = new SyukeiBtnClickApplicationLogic().Execute(alInput);

                // Display Message
                DispMsg(alOutput.ListResult[0], false);

                // KaikeiNo is Returned
                string kaikeiNo = alOutput.ListResult[1];

                if (suitoSyukeiStdSuccess)
                {
                    msgTextBox.SelectionColor = Color.Blue;
                    msgTextBox.AppendText(MSG_INFO_COMPLETE_PROCESSING + Environment.NewLine);
                    SetReturnConds(kaikeiNo);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                syukeiButton.Enabled = true;
                closeButton.Enabled = true;
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
        /// 2014/11/10  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                if (suitoSyukeiStdSuccess)
                {
                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }

                this.Close();
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

        #region KaikeiMakeFileForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaikeiMakeFileForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/10  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaikeiMakeFileForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        syukeiButton.Focus();
                        syukeiButton.PerformClick();
                        break;

                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
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

        #region taisyoFromDtDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： taisyoFromDtDateTimePicker_ValueChanged
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
        private void taisyoFromDtDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                taisyoToDtDateTimePicker.Value = taisyoFromDtDateTimePicker.Value;
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
        /// 2014/11/10  DatNT　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 対象区分/入金
            nyukinRadioButton.Checked = true;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());
            // 支所(3)
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            if (Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd == "0")
            {
                shisyoComboBox.Enabled = true;
            }
            else
            {
                shisyoComboBox.Enabled = false;
            }


            // 対象日（開始）
            taisyoFromDtDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);

            // 対象日（終了）
            taisyoToDtDateTimePicker.Value = today;

            // 売上バッチも実行
            uriageBatchCheckBox.Checked = false;

            // 作成対象/郵便
            yubinCheckBox.Checked = true;

            // 作成対象/銀行
            bankCheckBox.Checked = true;

            // 作成対象/現金
            genkinCheckBox.Checked = true;

            // 作成対象/支払
            shiharaiCheckBox.Checked = false;

            // 作成範囲/対象全件
            allRadioButton.Checked = true;

            // 処理メッセージ
            msgTextBox.Clear();
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
        /// 2014/11/10  DatNT　  新規作成
        /// 2014/12/11  kiyokuni　年度跨ぎチェック修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMsg = new StringBuilder();

            // 対象日（開始＆終了）
            if (taisyoFromDtDateTimePicker.Value > taisyoToDtDateTimePicker.Value)
            {
                errMsg.AppendLine("範囲指定が正しくありません。対象日の大小関係を確認してください。");
            }
            else
            {

                if (Utility.DateUtility.GetNendo(taisyoFromDtDateTimePicker.Value) != Utility.DateUtility.GetNendo(taisyoToDtDateTimePicker.Value))
                //if (taisyoFromDtDateTimePicker.Value.Month <= 3 && taisyoToDtDateTimePicker.Value.Month >= 4)
                {
                    errMsg.AppendLine("年度を跨いだ集計はできません。");
                }
            }

            // 作成対象未選択
            if (nyukinRadioButton.Checked
                && !yubinCheckBox.Checked
                && !bankCheckBox.Checked
                && !genkinCheckBox.Checked
                && !shiharaiCheckBox.Checked)
            {
                errMsg.AppendLine("作成対象を選択してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion        

        #region MakeALInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeALInput
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alInput"></param>
        /// <param name="runUriageSyukeiStd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  DatNT　　 新規作成
        /// 2014/12/08  kiyokuni　採番、和暦はストアド内に変更。作成対象をパラメータセットしていなかったのを修正。
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeALInput(ISyukeiBtnClickALInput alInput, bool runUriageSyukeiStd)
        {
            //if (!runUriageSyukeiStd)
            //{
                //2014.12.08 Del kiyokuni
                //string kaikeiSaibanNo = Utility.Saiban.GetSaibanRenban(Utility.DateUtility.GetNendo(today).ToString(), Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_08);

                // 対象区分
                alInput.TaishoKbn = uriageRadioButton.Checked ? "1" : "2";

                // 支所
                if (shisyoComboBox.SelectedValue != null)
                {
                    alInput.ShishoCd = shisyoComboBox.SelectedValue.ToString();
                }

                // 作成対象
                string sakuseiTaisho = string.Empty;
                sakuseiTaisho = sakuseiTaisho + (yubinCheckBox.Checked ? "1" : "0");
                sakuseiTaisho = sakuseiTaisho + (bankCheckBox.Checked ? "1" : "0");
                sakuseiTaisho = sakuseiTaisho + (genkinCheckBox.Checked ? "1" : "0");
                sakuseiTaisho = sakuseiTaisho + (shiharaiCheckBox.Checked ? "1" : "0");
                alInput.SakuseiTaisho = sakuseiTaisho;

                // 作成範囲
                alInput.SakuseiHani = allRadioButton.Checked ? "1" : "2";

                // 和暦
                alInput.Wareki = string.Empty;
                //alInput.Wareki = Utility.DateUtility.ConvertToWareki(today.ToString("yyyyMMdd"));

                // 会計採番No
                //2014.12.08 Mod kiyokuni
                alInput.KaikeiSaibanNo = string.Empty;
                //alInput.KaikeiSaibanNo = kaikeiSaibanNo;
            //}

            // 対象日（開始）
            alInput.TaisyoFrom = taisyoFromDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 対象日（終了）
            alInput.TaisyoTo = taisyoToDtDateTimePicker.Value.ToString("yyyyMMdd");

            // ログイン者名
            alInput.LoginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 端末名
            alInput.PcUpdate = Dns.GetHostName();

            alInput.RunUriageSyukeiStd = runUriageSyukeiStd;
        }
        #endregion

        #region DispMsg
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispMsg
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errFlg"></param>
        /// <param name="runUriageSyukeiStd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  DatNT　　 新規作成
        /// 2014/12/09  kiyokuni　データなしのメッセージ対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DispMsg(string errFlg, bool runUriageSyukeiStd)
        {
            if (runUriageSyukeiStd)
            {
                if (errFlg == "0")
                {
                    // UriageSyukeiStd : OK
                }
                else
                {
                    msgTextBox.SelectionColor = Color.Red;
                    msgTextBox.AppendText(MSG_ERR_URIAGE + Environment.NewLine);

                    msgTextBox.SelectionColor = Color.Blue;
                    msgTextBox.AppendText(MSG_INFO_COMPLETE_PROCESSING + Environment.NewLine);

                    return false;
                }
            }
            else
            {
                if (errFlg == "0")
                {
                    suitoSyukeiStdSuccess = true;
                }
                else if (errFlg == "9")
                {
                    suitoSyukeiStdSuccess = false;
                    msgTextBox.SelectionColor = Color.Red;
                    msgTextBox.AppendText(MSG_ERR_NO_DATA + Environment.NewLine);
                }
                else
                {
                    suitoSyukeiStdSuccess = false;

                    string[] err = new string[errFlg.Length];

                    if (errFlg.Contains(","))
                    {
                        err = errFlg.Split(',');
                    }
                    else
                    {
                        err[0] = errFlg;
                    }

                    foreach (string errStr in err)
                    {
                        msgTextBox.SelectionColor = Color.Red;

                        switch (errStr)
                        {
                            //case "1": msgTextBox.AppendText(MSG_ERR_STEP_1 + Environment.NewLine); break;
                            case "2": msgTextBox.AppendText(MSG_ERR_STEP_2 + Environment.NewLine); break;
                            case "3": msgTextBox.AppendText(MSG_ERR_STEP_3 + Environment.NewLine); break;
                            default: break;
                        }
                    }
                }
            }

            return true;
        }
        #endregion

        #region SetReturnConds
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetReturnConds
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kaikeiNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetReturnConds(string kaikeiNo)
        {
            returnCond.UriageNyukinKbn = uriageRadioButton.Checked ? "1" : "2";

            returnCond.ShishoCd = (shisyoComboBox.SelectedIndex > 0) ? shisyoComboBox.SelectedValue.ToString() : string.Empty;

            //20141215 HuyTX Del
            //if (nyukinRadioButton.Checked)
            //{
            returnCond.ListMakeKbn = new List<string>();

            if (yubinCheckBox.Checked)
            {
                returnCond.ListMakeKbn.Add("1");
            }
            if (bankCheckBox.Checked)
            {
                returnCond.ListMakeKbn.Add("2");
            }
            if (genkinCheckBox.Checked)
            {
                returnCond.ListMakeKbn.Add("3");
            }
            if (shiharaiCheckBox.Checked)
            {
                returnCond.ListMakeKbn.Add("4");
            }
            //}

            returnCond.KaikeiNoFrom = kaikeiNo;

            returnCond.KaikeiNoTo = kaikeiNo;
        }
        #endregion

        #endregion

    }
    #endregion
}
