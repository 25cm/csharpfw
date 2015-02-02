using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KiansyaSelect;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KiansyaSelectForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KiansyaSelectForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// kensaIraiHoteiKbn
        /// </summary>
        private string _kensaIraiHoteiKbn = string.Empty;

        /// <summary>
        /// kensaIraiHokenjoCd
        /// </summary>
        private string _kensaIraiHokenjoCd = string.Empty;

        /// <summary>
        /// kensaIraiNendo
        /// </summary>
        private string _kensaIraiNendo = string.Empty;

        /// <summary>
        /// kensaIraiRenban
        /// </summary>
        private string _kensaIraiRenban = string.Empty;

        /// <summary>
        /// loginNm
        /// </summary>
        private string _loginUserCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KiansyaSelectForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KiansyaSelectForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KiansyaSelectForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="kensaTorisageRow"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KiansyaSelectForm(string kensaIraiHoteiKbn, string kensaIraiHokenjoCd, string kensaIraiNendo, string kensaIraiRenban)
        {
            InitializeComponent();

            _kensaIraiHoteiKbn = kensaIraiHoteiKbn;
            _kensaIraiHokenjoCd = kensaIraiHokenjoCd;
            _kensaIraiNendo = kensaIraiNendo;
            _kensaIraiRenban = kensaIraiRenban;
        }
        #endregion

        #region イベント

        #region KiansyaSelectForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KiansyaSelectForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KiansyaSelectForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFormLoadALInput alInput = new FormLoadALInput();
                alInput.ShokuinCd = _loginUserCd;
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

                //set data to syozokuShisyoComboBox
                Utility.Utility.SetComboBoxList(syozokuShisyoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);

                //set data to syozokuBusyoComboBox
                Utility.Utility.SetComboBoxList(syozokuBusyoComboBox, alOutput.BushoMstDataTable, "BushoNm", "BushoCd", true);

                //set data to kihyosyaComboBox
                Utility.Utility.SetComboBoxList(kianshaComboBox, alOutput.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", true);

                //set display default
                foreach (ShokuinMstDataSet.ShokuinMstRow shokuinRow in alOutput.ShokuinMstDataTable.Select(string.Format("ShokuinCd = {0}", _loginUserCd)))
                {
                    syozokuShisyoComboBox.SelectedValue = shokuinRow.ShokuinShozokuShishoCd;
                }
                syozokuBusyoComboBox.SelectedValue = alOutput.ShozokuMstDataTable.Count > 0 ? alOutput.ShozokuMstDataTable[0].ShozokuBushoCd : string.Empty;
                kianshaComboBox.SelectedValue = _loginUserCd;
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
        /// 2014/08/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                
                alInput.ShishoNm = syozokuShisyoComboBox.GetItemText(syozokuShisyoComboBox.SelectedItem);
                alInput.BushoNm = syozokuBusyoComboBox.GetItemText(syozokuBusyoComboBox.SelectedItem);
                alInput.ShokuinNm = kianshaComboBox.GetItemText(kianshaComboBox.SelectedItem);
                alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                alInput.KensaIraiNendo = _kensaIraiNendo;
                alInput.KensaIraiRenban = _kensaIraiRenban;

                new PrintBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/08/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Program.mForm.MovePrev();
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

        #region KiansyaSelectForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KiansyaSelectForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KiansyaSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        printButton.PerformClick();
                        break;

                    case Keys.F12:
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

        #endregion

    }
    #endregion
}
