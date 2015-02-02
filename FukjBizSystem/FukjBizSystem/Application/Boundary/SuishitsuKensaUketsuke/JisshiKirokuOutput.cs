using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.JisshiKirokuOutput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JisshiKirokuOutputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JisshiKirokuOutputForm : FukjBaseForm
    {
        #region private

        /// <summary>
        /// Print Conditions
        /// </summary>
        KeiryoShomeiDaichoSearchCond _printCond = new KeiryoShomeiDaichoSearchCond();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JisshiKirokuOutputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="printCond"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JisshiKirokuOutputForm(KeiryoShomeiDaichoSearchCond printCond)
        {
            InitializeComponent();

            this._printCond = printCond;
        }
        #endregion

        #region イベント

        #region JisshiKirokuOutputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JisshiKirokuOutputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JisshiKirokuOutputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

                SetValues();
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
        /// 2014/12/02  DatNT　  新規作成
        /// 2014/12/05  HuyTX　  Print 047_9, 049_11
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                KeiryoShomeiDaichoSearchCond searchCond = new KeiryoShomeiDaichoSearchCond();
                //年度
                searchCond.Nendo = nendoTextBox.Text.Trim();
                //依頼受付日（開始）
                searchCond.IraiUketsukeFromDt = iraiUketsukeDtFromTextBox.Text.Trim();
                //依頼受付日（終了）
                searchCond.IraiUketsukeToDt = iraiUketsukeDtToTextBox.Text.Trim();
                //依頼No（開始）
                // 20141219 sou Ver1.04 Start
                //searchCond.IraiNoFrom = iraiNoFromTextBox.Text.Trim();
                searchCond.IraiNoFrom = string.IsNullOrEmpty(iraiNoFromTextBox.Text.Trim()) ? string.Empty : iraiNoFromTextBox.Text.Trim().PadLeft(6, '0');
                //依頼No（終了）
                //searchCond.IraiNoTo = iraiNoToTextBox.Text.Trim();
                searchCond.IraiNoTo = string.IsNullOrEmpty(iraiNoToTextBox.Text.Trim()) ? string.Empty : iraiNoToTextBox.Text.Trim().PadLeft(6, '0');
                // 20141219 sou Ver1.04 End
                //検査区分
                searchCond.KensaKbn = suishitsuRadioButton.Checked 
                    ? Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU 
                    : gaikanRadioButton.Checked ? Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN 
                                                : Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN;

                IOutputBtnClickALInput alInput = new OutputBtnClickALInput();
                alInput.SearchCond = searchCond;
                new OutputBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region JisshiKirokuOutputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JisshiKirokuOutputForm_KeyDown
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
        private void JisshiKirokuOutputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        outputButton.Focus();
                        outputButton.PerformClick();
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

        #endregion

        #region メソッド(private)

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 年度
            nendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);

            // 依頼受付日（開始）
            iraiUketsukeDtFromTextBox.SetControlDomain(ZControlDomain.ZT_DT);

            // 依頼受付日（終了）
            iraiUketsukeDtToTextBox.SetControlDomain(ZControlDomain.ZT_DT);

            // 依頼No（開始）
            iraiNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // 依頼No（終了）
            iraiNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
        }
        #endregion

        #region SetValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues()
        {
            // 年度
            nendoTextBox.Text = _printCond.Nendo;

            // 依頼受付日（開始）
            iraiUketsukeDtFromTextBox.Text = _printCond.IraiUketsukeFromDt;

            // 依頼受付日（終了）
            iraiUketsukeDtToTextBox.Text = _printCond.IraiUketsukeToDt;

            // 依頼No（開始）
            iraiNoFromTextBox.Text = _printCond.IraiNoFrom;

            // 依頼No（終了）
            iraiNoToTextBox.Text = _printCond.IraiNoTo;

            if (_printCond.KensaKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU)
            {
                suishitsuRadioButton.Checked = true;
            }
            else if (_printCond.KensaKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN)
            {
                gaikanRadioButton.Checked = true;
            }
            else
            {
                keiryoShomeiRadioButton.Checked = true;
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
