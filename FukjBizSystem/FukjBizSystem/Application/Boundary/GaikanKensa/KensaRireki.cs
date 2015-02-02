using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaRireki;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.JokasoDaichoKanri;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaRirekiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/30　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaRirekiForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// jokasoNo
        /// </summary>
        private string _jokasoNo = string.Empty;

        /// <summary>
        /// kensaRirekiListDataTable
        /// </summary>
        private KensaKekkaTblDataSet.KensaRirekiListDataTable _kensaRirekiListDataTable = new KensaKekkaTblDataSet.KensaRirekiListDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaRirekiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaRirekiForm()
        {
            InitializeComponent();

            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaRirekiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="jokasoNo"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaRirekiForm(string jokasoNo)
        {
            InitializeComponent();

            SetControlDomain();

            _jokasoNo = jokasoNo;
        }
        #endregion

        #region イベント

        #region KensaRirekiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaRirekiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaRirekiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(_jokasoNo) && _jokasoNo.Length == 11)
                {
                    kyokaiNoTextBox.Text = _jokasoNo;

                    IFormLoadALInput alInput = new FormLoadALInput();
                    alInput.KensaIraiJokasoHokenjoCd = _jokasoNo.Substring(0, 2);
                    alInput.KensaIraiJokasoTorokuNendo = Utility.DateUtility.ConvertFromWareki(_jokasoNo.Substring(3, 2), "yyyy");
                    alInput.KensaIraiJokasoRenban = _jokasoNo.Substring(6, 5);
                    IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

                    _kensaRirekiListDataTable = alOutput.KensaRirekiListDataTable;
                }

                //set default value control
                SetDefaultValueControl();

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
        /// 2014/08/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kekkasyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaRirekiListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string kensaIraiHoteiKbn = kensaRirekiListDataGridView.CurrentRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString();
                string kensaIraiHokenjoCd = kensaRirekiListDataGridView.CurrentRow.Cells[hokenjoCdCol.Name].Value.ToString();
                string kensaIraiNendo = kensaRirekiListDataGridView.CurrentRow.Cells[nendoCol.Name].Value.ToString();
                string kensaIraiRenban = kensaRirekiListDataGridView.CurrentRow.Cells[renbanCol.Name].Value.ToString();

                // 2015.01.09 toyoda Modify Start 処理失敗を通知する
                //// TODO 20141111 habu HotFix
                //Utility.KekkashoUtility.KekkashoOutput(kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban, 0, 0, 1, 0);
                ////Utility.KekkashoUtility.KekkashoOutput(kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban, 0, 0);
                int result = 0;
                result = Utility.KekkashoUtility.KekkashoOutput(kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban, 0, 0, 1, 0);

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

        #region kihonJohoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kihonJohoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　HuyTX    新規作成
        /// 2014/10/08　HuyTX    Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kihonJohoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] jokasoNo = _jokasoNo.Split(new char[] { '-' });

                if (jokasoNo.Length < 3) return;

                string hokenjoCd = jokasoNo[0];
                string torokuNendo = Common.Common.ConvertToHoshouNendoSeireki(jokasoNo[1].ToString());
                string renban = jokasoNo[2];

                JokasoDaichoShosai frm = new JokasoDaichoShosai(hokenjoCd, torokuNendo, renban);
                //Program.mForm.ShowForm(frm);
                Program.mForm.MoveNext(frm);

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
        /// 2014/08/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
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

        #region KensaRirekiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaRirekiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaRirekiForm_KeyDown(object sender, KeyEventArgs e)
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

                    case Keys.F5:
                        kihonJohoButton.Focus();
                        kihonJohoButton.PerformClick();
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

        #region メソッド(private)

        #region SetDefaultValueControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValueControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValueControl()
        {
            if (_kensaRirekiListDataTable.Count == 0) return;

            kensaRirekiListDataGridView.DataSource = null;
            kyokaiNoTextBox.Text = _jokasoNo;
            settisyaTextBox.Text = _kensaRirekiListDataTable[0].JokasoSetchishaNm;
            taisyoNinzuTextBox.Text = _kensaRirekiListDataTable[0].IsJokasoShoriTaishoJininNull() ? string.Empty : _kensaRirekiListDataTable[0].JokasoShoriTaishoJinin.ToString();
            settiBasyoTextBox.Text = _kensaRirekiListDataTable[0].IsJokasoSetchiBashoAdrNull() ? string.Empty : _kensaRirekiListDataTable[0].JokasoSetchiBashoAdr;
            syoriHoshikiTextBox.Text = _kensaRirekiListDataTable[0].IsShoriHoshikiShubetsuNmNull() ? string.Empty : _kensaRirekiListDataTable[0].ShoriHoshikiShubetsuNm;
            syoriNmTextBox.Text = _kensaRirekiListDataTable[0].IsShoriHoshikiNmNull() ? string.Empty : _kensaRirekiListDataTable[0].ShoriHoshikiNm;
            kojiGyosyaTextBox.Text = _kensaRirekiListDataTable[0].IsJokasoKojiGyoshaKbnNull() ? string.Empty : _kensaRirekiListDataTable[0].JokasoKojiGyoshaKbn;
            hosyuGyosyaTextBox.Text = _kensaRirekiListDataTable[0].IsJokasoHoshutenkenGyoshaCdNull() ? string.Empty : _kensaRirekiListDataTable[0].JokasoHoshutenkenGyoshaCd;

            kensaRirekiListDataGridView.DataSource = _kensaRirekiListDataTable;

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
        /// 2014/11/04　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            kyokaiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 11);
            settisyaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            taisyoNinzuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
            settiBasyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            syoriHoshikiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 14);
            syoriNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            kojiGyosyaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            hosyuGyosyaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            //set control domain for GridView
            kensaRirekiListDataGridView.SetStdControlDomain(rowNoCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            kensaRirekiListDataGridView.SetStdControlDomain(kensaSyubetsuCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            kensaRirekiListDataGridView.SetStdControlDomain(kensaNoCol.Index, ZControlDomain.ZG_STD_NAME, 12);
            kensaRirekiListDataGridView.SetStdControlDomain(kensaDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            kensaRirekiListDataGridView.SetStdControlDomain(sofuDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            kensaRirekiListDataGridView.SetStdControlDomain(kensainCol.Index, ZControlDomain.ZG_STD_NAME, 20);
            kensaRirekiListDataGridView.SetStdControlDomain(hanteiCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);
            kensaRirekiListDataGridView.SetStdControlDomain(phCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            kensaRirekiListDataGridView.SetStdControlDomain(doCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            kensaRirekiListDataGridView.SetStdControlDomain(trCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            kensaRirekiListDataGridView.SetStdControlDomain(zanenCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            kensaRirekiListDataGridView.SetStdControlDomain(bodCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            kensaRirekiListDataGridView.SetStdControlDomain(clCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleRight);
            kensaRirekiListDataGridView.SetStdControlDomain(torisageCol.Index, ZControlDomain.ZG_STD_NAME, 2, DataGridViewContentAlignment.MiddleCenter);

        }
        #endregion

        #endregion

    }
    #endregion
}
