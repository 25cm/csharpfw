using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KensaSetSelect;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaSetSelectForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HuyTX     新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaSetSelectForm : Form
    {
        #region プロパティ(private)

        /// <summary>
        ///  保健所コード
        /// </summary>
        private string _hokenjoCd;

        /// <summary>
        /// 年度
        /// </summary>
        private string _nendo;

        /// <summary>
        /// 連番
        /// </summary>
        private string _renban;

        /// <summary>
        /// 検査項目枝番
        /// </summary>
        private string _kensaKomokuEdaba;

        /// <summary>
        /// kensaKomokuPatternInfoDT
        /// </summary>
        private DaichoSuishitsuKensaKomokuMstDataSet.KensaKomokuPatternInfoDataTable _kensaKomokuPatternInfoDT = new DaichoSuishitsuKensaKomokuMstDataSet.KensaKomokuPatternInfoDataTable();

        /// <summary>
        /// setNm 
        /// </summary>
        private string _setNm = string.Empty;

        /// <summary>
        /// komokuNm 
        /// </summary>
        private string _komokuNm = string.Empty;

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// daichoKensaSetNmReturn
        /// </summary>
        public string _daichoKensaSetNmReturn;

        /// <summary>
        /// kensaKomokuEdabaReturn
        /// </summary>
        public string _kensaKomokuEdabaReturn;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaSetSelectForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaSetSelectForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaSetSelectForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaSetSelectForm(string hokenjoCd, string nendo, string renban, string kensaKomokuEdaba)
        {
            InitializeComponent();
            _hokenjoCd = hokenjoCd;
            _nendo = nendo;
            _renban = renban;
            _kensaKomokuEdaba = kensaKomokuEdaba;
        }
        #endregion

        #region イベント

        #region KensaSetSelectForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaSetSelectForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaSetSelectForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFormLoadALInput alInput = new FormLoadALInput();
                alInput.JokasoHokenjoCd = _hokenjoCd;
                alInput.JokasoTorokuNendo = _nendo;
                alInput.JokasoRenban = _renban;
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
                _kensaKomokuPatternInfoDT = alOutput.KensaKomokuPatternInfoDataTable;

                //set source for kensaKomokuPatternComboBox
                Utility.Utility.SetComboBoxList(kensaKomokuPatternComboBox,
                                                _kensaKomokuPatternInfoDT, 
                                                alOutput.KensaKomokuPatternInfoDataTable.DispValueColumn.ColumnName, 
                                                alOutput.KensaKomokuPatternInfoDataTable.DaichoKensaKomokuEdabanColumn.ColumnName, 
                                                true);

                if (!string.IsNullOrEmpty(_kensaKomokuEdaba))
                {
                    kensaKomokuPatternComboBox.SelectedValue = _kensaKomokuEdaba;
                    //call function 041 計量証明のセット検査項目名称取得
                    Utility.KeiryoShomeiUtility.GetJokasoSuishitsuSetKomokuNm(_hokenjoCd, _nendo, _renban, _kensaKomokuEdaba, out _setNm, out _komokuNm);

                    kensaKomokuNaiyoTextBox.Text = string.Format("セット内容：{0}\r\n{1}", _setNm, _komokuNm);
                }


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

        #region kensaKomokuPatternComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaKomokuPatternComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaKomokuPatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaKomokuPatternComboBox.SelectedIndex <= 0
                    || !Utility.KeiryoShomeiUtility.GetJokasoSuishitsuSetKomokuNm(_hokenjoCd, _nendo, _renban, kensaKomokuPatternComboBox.SelectedValue.ToString(), out _setNm, out _komokuNm)
                    )
                {
                    kensaKomokuNaiyoTextBox.Text = string.Empty;
                    return;
                }

                kensaKomokuNaiyoTextBox.Text = string.Format("セット内容：{0}\r\n{1}", _setNm, _komokuNm);

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

        #region choiceButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： choiceButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void choiceButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _kensaKomokuEdabaReturn = kensaKomokuPatternComboBox.SelectedIndex > 0 ? kensaKomokuPatternComboBox.SelectedValue.ToString() : string.Empty;
                DaichoSuishitsuKensaKomokuMstDataSet.KensaKomokuPatternInfoRow[] patternRows = (DaichoSuishitsuKensaKomokuMstDataSet.KensaKomokuPatternInfoRow[])_kensaKomokuPatternInfoDT.Select(string.Format("{0} = '{1}'", 
                                                                                                                        _kensaKomokuPatternInfoDT.DaichoKensaKomokuEdabanColumn.ColumnName, 
                                                                                                                        kensaKomokuPatternComboBox.SelectedValue));

                _daichoKensaSetNmReturn = patternRows != null && patternRows.Length > 0 ? patternRows[0].DaichoKensaSetNm : string.Empty;

                this.DialogResult = DialogResult.OK;
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
        /// 2014/12/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
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

        #region KensaSetSelectForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaSetSelectForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaSetSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        choiceButton.Focus();
                        choiceButton.PerformClick();
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

        #endregion
    }
    #endregion
}


