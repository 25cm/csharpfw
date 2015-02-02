using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.KensaKeihatsuSuishinhiSyukei;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKeihatsuSuishinhiSyukeiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKeihatsuSuishinhiSyukeiForm : FukjBaseForm
    {
        #region プロパティ(public)

        /// <summary>
        /// SyukeiResult
        /// </summary>
        public SyukeiResult _syukei;
        
        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// 開始日
        /// </summary>
        private string _kaishiDt = string.Empty;

        /// <summary>
        /// 終了日
        /// </summary>
        private string _shuryoDt = string.Empty;

        // 2014/11/10 AnhNV ADD Start
        /// <summary>
        /// TRUE: Form is executed, otherwise FALSE
        /// </summary>
        private bool _isEntry;
        // 2014/11/10 AnhNV ADD End

        /// <summary>
        /// 処理開始 : 集計ボタンクリック直後
        /// </summary>
        private const string MESSAGE_START = "処理を開始します。";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKeihatsuSuishinhiSyukeiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKeihatsuSuishinhiSyukeiForm()
        {
            InitializeComponent();
			SetControlDomain();		//受入20141224 add
		}
        #endregion

        #region イベント

        #region KensaKeihatsuSuishinhiSyukeiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKeihatsuSuishinhiSyukeiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKeihatsuSuishinhiSyukeiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region EntryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： EntryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/10/16  DatNT     v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void EntryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 処理メッセージ
                messageTextBox.Clear();

                if (!CheckCondition()) { return; }

                // 実行確認
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査啓発推進費集計処理を開始します。よろしいですか？") != DialogResult.Yes)
                {
                    return;
                }

                //if (!RegisterCheck())
                //{
                //    if (MessageForm.Show2(MessageForm.DispModeType.Question, "作成対象の集計年度、上下期区分のデータがすでに存在します。\r\n既存のデータを全て破棄して再作成しますか？") == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        if (!ReCreateCheck()) { return; }

                //        GetKaishiDtShuryoDt();

                //        DoUpdate();
                //    }
                //}
                //else
                //{
                //    if (!ReCreateCheck()) { return; }

                //    GetKaishiDtShuryoDt();

                //    DoUpdate();
                //}

                GetKaishiDtShuryoDt();	//受入20141223 revive

                DoUpdate();

                // 2014/11/10 AnhNV ADD Start
                this._isEntry = true;
                // 2014/11/10 AnhNV ADD End
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
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2014/11/10 AnhNV ADD Start
                if (_isEntry)
                {
                    _syukei = new SyukeiResult();
                    _syukei.YearFrom = yearFromTextBox.Text;
                    _syukei.YearTo = yearToTextBox.Text;
                    _syukei.MonthFrom = monthFromComboBox.Text;
                    _syukei.MonthTo = monthToComboBox.Text;
                    _syukei.GyoshaCdFrom = gyosyaCdFromTextBox.Text;
                    _syukei.GyoshaCdTo = gyosyaCdToTextBox.Text;
                    this.DialogResult = DialogResult.OK;
                }
                // 2014/11/10 AnhNV ADD End

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

        #region KensaKeihatsuSuishinhiSyukeiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKeihatsuSuishinhiSyukeiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKeihatsuSuishinhiSyukeiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        entryButton.Focus();
                        entryButton.PerformClick();
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

        #region gyosyaCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  DatNT　   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text))
                {
                    gyosyaCdFromTextBox.Text = gyosyaCdFromTextBox.Text.PadLeft(4, '0');
                    gyosyaCdToTextBox.Text = gyosyaCdFromTextBox.Text;
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

        #region gyosyaCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  DatNT　   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyosyaCdToTextBox.Text))
                {
                    gyosyaCdToTextBox.Text = gyosyaCdToTextBox.Text.PadLeft(4, '0');
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

		//受入20141224 add sta
		#region SetControlDomain
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： SetControlDomain
		/// <summary>
		/// 
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/12/24　toguchi     新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private void SetControlDomain()
		{
			this.yearFromTextBox.SetStdControlDomain(ZControlDomain.ZT_NEN, 4, HorizontalAlignment.Right);
			this.yearToTextBox.SetStdControlDomain(ZControlDomain.ZT_NEN, 4, HorizontalAlignment.Right);
			this.gyosyaCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4, HorizontalAlignment.Left);
			this.gyosyaCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4, HorizontalAlignment.Left);
		}
		#endregion
		//受入20141224 add end


        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/10/16  DatNT　  v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // 2014/10/16 v1.03 DatNT DEL Start
            #region del
            //IFormLoadALInput alInput = new FormLoadALInput();
            //IFormLoadALOutput alOuput = new FormLoadApplicationLogic().Execute(alInput);

            //if (alOuput.KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT != null && alOuput.KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT.Count > 0)
            //{
            //    KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow row = alOuput.KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT[0];

            //    //if (row.KamiShimoKbn == "1")
            //    //{
            //    //    nendoTextBox.Text = row.SuishinhiNendo;
            //    //    shimokiRadioButton.Checked = true;
            //    //}
            //    //else if (row.KamiShimoKbn == "2")
            //    //{
            //    //    nendoTextBox.Text = (Convert.ToInt32(row.SuishinhiNendo) + 1).ToString();
            //    //    kamikiRadioButton.Checked = true;
            //    //}
            //}
            //else
            //{
            //    if (today.Month == 1 || today.Month == 2 || today.Month == 3)
            //    {
            //        nendoTextBox.Text = (today.Year - 1).ToString();
            //        kamikiRadioButton.Checked = true;
            //    }
            //    else if (today.Month == 4 || today.Month == 5 || today.Month == 6 || today.Month == 7 || today.Month == 8 || today.Month == 9)
            //    {
            //        nendoTextBox.Text = (today.Year - 1).ToString();
            //        shimokiRadioButton.Checked = true;
            //    }
            //    else
            //    {
            //        nendoTextBox.Text = today.Year.ToString();
            //        kamikiRadioButton.Checked = true;
            //    }
            //}
            #endregion
            // 2014/10/16 v1.03 DatNT DEL End

            // 2014/10/16 DatNT v1.03 ADD Start
            
            // 集計年月
            if (today.Month >= 4 && today.Month <= 9)
            {
                yearFromTextBox.Text = (today.Year - 1).ToString();
                yearToTextBox.Text = today.Year.ToString();
                monthFromComboBox.SelectedIndex = 9;
                monthToComboBox.SelectedIndex = 2;
            }
            else if (today.Month >= 10 && today.Month <= 12)
            {
                yearFromTextBox.Text = today.Year.ToString();
                yearToTextBox.Text = today.Year.ToString();
                monthFromComboBox.SelectedIndex = 3;
                monthToComboBox.SelectedIndex = 8;
            }
            else
            {
                yearFromTextBox.Text = (today.Year - 1).ToString();
                yearToTextBox.Text = (today.Year - 1).ToString();
                monthFromComboBox.SelectedIndex = 3;
                monthToComboBox.SelectedIndex = 8;
            }

            // 支払日
            shiharaiDtDateTimePicker.Value = today;

            // 業者コード（開始）
            gyosyaCdFromTextBox.Clear();

            // 業者コード（終了）
            gyosyaCdToTextBox.Clear();

            messageTextBox.Clear();

            // 2014/10/16 DatNT v1.03 ADD End
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
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/10/16  DatNT　  v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 2014/10/16 v1.03 DatNT DEL Start
            //if (string.IsNullOrEmpty(nendoTextBox.Text))
            //{
            //    errMess.Append("必須項目：集計年度が入力されていません。\r\n");
            //}
            //else
            //{
            //    if (nendoTextBox.Text.Trim().Length != 4)
            //    {
            //        errMess.Append("集計年度は4桁で入力して下さい。\r\n");
            //    }
            //}
            // 2014/10/16 v1.03 DatNT DEL End

            // 2014/10/16 v1.03 DatNT ADD Start

            // 集計年月（開始年）
            if (string.IsNullOrEmpty(yearFromTextBox.Text))
            {
                errMess.AppendLine("必須項目：集計年月（開始年）が入力されていません。");
            }
            else
            {
                if (yearFromTextBox.Text.Length != 4)
                {
                    errMess.AppendLine("集計年月（開始年）は4桁で入力して下さい。");
                }
            }

            // 集計年月（終了年）
            if (string.IsNullOrEmpty(yearToTextBox.Text))
            {
                errMess.AppendLine("必須項目：集計年月（終了年）が入力されていません。");
            }
            else
            {
                if (yearToTextBox.Text.Length != 4)
                {
                    errMess.AppendLine("集計年月（終了年）は4桁で入力して下さい。");
                }
            }

            if (string.IsNullOrEmpty(errMess.ToString()))
            {
                if (Convert.ToInt32(yearFromTextBox.Text + GetMonth(monthFromComboBox.SelectedIndex))
                    > Convert.ToInt32(yearToTextBox.Text + GetMonth(monthToComboBox.SelectedIndex)))
                {
                    errMess.AppendLine("範囲指定が正しくありません。集計年月の大小関係を確認してください。");
                }
            }

            // 業者コード（開始）
            bool flg = true;
            if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) && gyosyaCdFromTextBox.Text.ToString().Trim().Length != 4)
            {
                errMess.Append("業者コード（開始）は4桁で入力して下さい。\r\n");
                flg = false;
            }

            // 業者コード（終了）
            if (!string.IsNullOrEmpty(gyosyaCdToTextBox.Text) && gyosyaCdToTextBox.Text.ToString().Trim().Length != 4)
            {
                errMess.Append("業者コード（終了）は4桁で入力して下さい。\r\n");
                flg = false;
            }

            if (flg)
            {
                if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyosyaCdToTextBox.Text))
                {
                    if (Convert.ToInt32(gyosyaCdFromTextBox.Text) > Convert.ToInt32(gyosyaCdToTextBox.Text))
                    {
                        errMess.Append("範囲指定が正しくありません。業者コードの大小関係を確認してください。\r\n");
                    }
                }
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;

            // 2014/10/16 v1.03 DatNT ADD End
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
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/12/13  DatNT   v1.05 : use PROC KensaKeihatsuSuishinhiStd
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            //KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataTableInput = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();
            
            string nendo = Utility.DateUtility.GetNendo(today).ToString();

            string saibanNo = nendo + Utility.Saiban.GetSaibanRenban(nendo, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_10);

            bool hasErr = false;

            int rowCount = 0;

            // Message Start
            messageTextBox.SelectionColor = Color.Blue;
            messageTextBox.AppendText(MESSAGE_START + Environment.NewLine);

            for (int i = 1; i < 11; i++)
            {
                IEntryBtnClickALInput alInput   = new EntryBtnClickALInput();
                // 2014/10/16 v1.03 DatNT MOD Start
                //alInput.SuishinhiNendo          = nendoTextBox.Text;
                //alInput.KamiShimoKbn            = kamikiRadioButton.Checked ? "1" : "2";
                alInput.GyoshaCdFrom            = gyosyaCdFromTextBox.Text;
                alInput.GyoshaCdTo              = gyosyaCdToTextBox.Text;
                alInput.SaibanNo                = saibanNo;
                alInput.ShukeiFromNengetsu      = yearFromTextBox.Text + GetMonth(monthFromComboBox.SelectedIndex);
                alInput.ShukeiToNengetsu        = yearToTextBox.Text + GetMonth(monthToComboBox.SelectedIndex);
                // 2014/10/16 v1.03 DatNT MOD End
				alInput.KaishiDt = _kaishiDt;	//受入20141223 revive
				alInput.ShuryoDt = _shuryoDt;	//受入20141223 revive
                alInput.ShiharaiDt              = shiharaiDtDateTimePicker.Value;
                alInput.StepProcessing          = i;
                alInput.HasError                = hasErr;
                //alInput.DataTableInput          = dataTableInput;
            
                IEntryBtnClickALOutput alOuput  = new EntryBtnClickApplicationLogic().Execute(alInput);

                if (!string.IsNullOrEmpty(alOuput.MessageStep))
                {
					// 受入20141223 del
					//if (i == 2 && alOuput.MessageStep == "処理が正常に終了しました。（対象件数：0件）")
					//{
					//    return;
					//}

                    messageTextBox.SelectionColor = Color.Blue;
                    messageTextBox.AppendText(alOuput.MessageStep + Environment.NewLine);
                }

                if (!string.IsNullOrEmpty(alOuput.ErrMessageStep))
                {
                    messageTextBox.SelectionColor = Color.Red;
                    messageTextBox.AppendText(alOuput.ErrMessageStep + Environment.NewLine);

                    hasErr = true;
					break;	// 受入20141223 add	途中でエラーが発生した場合、以降の集計処理は行わない。
                }

                if (i == 10)
                {
                    rowCount = alOuput.RowCount;
                }
            }

            // Message End
			if (!hasErr)	// 受入20141223 add
			{
				messageTextBox.SelectionColor = Color.Blue;
				messageTextBox.AppendText(string.Format("処理が正常に終了しました。（対象件数：{0}件）", rowCount) + Environment.NewLine);
			}

            messageTextBox.Focus();
        }
        #endregion

        #region GetKaishiDtShuryoDt
        // 2014/12/13 DatNT DEL
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： GetKaishiDtShuryoDt
		/// <summary>
		/// 
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/08/25  DatNT　  新規作成
		/// 2014/10/16  DatNT    v1.03
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private void GetKaishiDtShuryoDt()
		{
			// 受入20141223 revive ストアド引数は年月日。
			// 2014/10/16 DatNT v1.03 DEL Start
			//if (kamikiRadioButton.Checked)
			//{
			//    _kaishiDt = nendoTextBox.Text + "0401";
			//    _shuryoDt = nendoTextBox.Text + "0930";
			//}
			//else
			//{
			//    _kaishiDt = nendoTextBox.Text + "1001";
			//    _shuryoDt = (Convert.ToInt32(nendoTextBox.Text) + 1).ToString() + "0331";
			//}
			// 2014/10/16 DatNT v1.03 DEL End

			// 2014/10/16 DatNT v1.03 ADD Start
			_kaishiDt = yearFromTextBox.Text + GetMonth(monthFromComboBox.SelectedIndex) + "01";
			_shuryoDt = yearToTextBox.Text + GetMonth(monthToComboBox.SelectedIndex) + DateTime.DaysInMonth(Convert.ToInt32(yearToTextBox.Text), Convert.ToInt32(GetMonth(monthToComboBox.SelectedIndex))).ToString().PadLeft(2, '0');
			// 2014/10/16 DatNT v1.03 ADD End
		}
        #endregion

        #region RegisterCheck
        // 2014/12/13 DatNT DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： RegisterCheck
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/26  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private bool RegisterCheck()
        //{
        //    IEntryBtnClickALInput alInput   = new EntryBtnClickALInput();
        //    //alInput.SuishinhiNendo          = nendoTextBox.Text;
        //    //alInput.KamiShimoKbn            = kamikiRadioButton.Checked ? "1" : "2";
        //    alInput.RegisterCheck           = true;
        //    IEntryBtnClickALOutput alOuput  = new EntryBtnClickApplicationLogic().Execute(alInput);

        //    if (!alOuput.RegisterCheckOutput)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        #endregion

        #region ReCreateCheck
        // 2014/12/13 DatNT DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： ReCreateCheck
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/26  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private bool ReCreateCheck()
        //{
        //    IEntryBtnClickALInput alInput   = new EntryBtnClickALInput();
        //    //alInput.SuishinhiNendo          = nendoTextBox.Text;
        //    //alInput.KamiShimoKbn            = kamikiRadioButton.Checked ? "1" : "2";
        //    alInput.ReCreateCheck           = true;
        //    IEntryBtnClickALOutput alOuput = new EntryBtnClickApplicationLogic().Execute(alInput);

        //    if (!alOuput.ReCreateCheckOutput)
        //    {
        //        MessageForm.Show2(MessageForm.DispModeType.Error, "会計連動済のデータが存在するため、再作成はできません。");

        //        return false;
        //    }

        //    return true;
        //}
        #endregion

        #region GetMonth
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetMonth
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09  DatNT　   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetMonth(int index)
        {
            string month = string.Empty;

            switch (index)
            {
                case 0:
                    month = "01";
                    break;
                case 1:
                    month = "02";
                    break;
                case 2:
                    month = "03";
                    break;
                case 3:
                    month = "04";
                    break;
                case 4:
                    month = "05";
                    break;
                case 5:
                    month = "06";
                    break;
                case 6:
                    month = "07";
                    break;
                case 7:
                    month = "08";
                    break;
                case 8:
                    month = "09";
                    break;
                case 9:
                    month = "10";
                    break;
                case 10:
                    month = "11";
                    break;
                case 11:
                    month = "12";
                    break;
                default:
                    break;
            }

            return month;
        }
        #endregion

        #endregion
    }
    #endregion

    #region SyukeiResult
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyukeiResult
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/10  AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SyukeiResult
    {
        /// <summary>
        /// 集計年月（開始年）
        /// </summary>
        public string YearFrom { get; set; }

        /// <summary>
        /// 集計年月（終了年）
        /// </summary>
        public string YearTo { get; set; }

        /// <summary>
        /// 集計年月（開始月）
        /// </summary>
        public string MonthFrom { get; set; }

        /// <summary>
        /// 集計年月（終了月）
        /// </summary>
        public string MonthTo { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyoshaCdTo { get; set; }
    }
    #endregion
}
