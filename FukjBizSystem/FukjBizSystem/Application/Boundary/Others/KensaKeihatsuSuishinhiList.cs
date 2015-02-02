using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Others.KensaKeihatsuSuishinhiList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Others
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKeihatsuSuishinhiListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKeihatsuSuishinhiListForm : FukjBaseForm
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
        /// DateTime Today
        /// </summary>
        private DateTime _today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// 職員名
        /// </summary>
        private string _loginNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        private KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable _printTable;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKeihatsuSuishinhiListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKeihatsuSuishinhiListForm()
        {
            InitializeComponent();
			SetControlDomain();		//受入20141224 add
		}
        #endregion

        #region イベント

        #region KensaKeihatsuSuishinhiListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKeihatsuSuishinhiListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKeihatsuSuishinhiListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region ViewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
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
        /// 2014/08/18  DatNT　  新規作成
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckCondition()) { return; }

                DoSearch(true);
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syukeiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2014/11/10 AnhNV ADD Start

                KensaKeihatsuSuishinhiSyukeiForm frm = new KensaKeihatsuSuishinhiSyukeiForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    SetDefaultValues();

                    yearFromTextBox.Text = frm._syukei.YearFrom;
                    yearToTextBox.Text = frm._syukei.YearTo;
                    monthFromComboBox.Text = frm._syukei.MonthFrom;
                    monthToComboBox.Text = frm._syukei.MonthTo;
                    gyosyaCdFromTextBox.Text = frm._syukei.GyoshaCdFrom;
                    gyosyaCdToTextBox.Text = frm._syukei.GyoshaCdTo;

                    // Perform a search action
                    DoSearch(false);
                }
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

        #region ikkatsuPrintButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ikkatsuPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/09  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ikkatsuPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (srhListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "印刷可能なデータが検索されていません。");
                    return;
                }

                // 2014/10/09 DatNT v1.01 DEL Start
                //// 一覧印刷時に集計年度が未入力、上下期区分が全件だった場合
                //if (string.IsNullOrEmpty(syukeiNendoTextBox.Text) && kamikiRadioButton.Checked)
                //{
                //    MessageForm.Show2(MessageForm.DispModeType.Error, "一覧印刷は、集計年度、上期・下期を指定して検索したデータしか印刷できません。");
                //    return;
                //}
                // 2014/10/09 DatNT v1.01 DEL End

                if (!RequiredCheck()) { return; }

				// 受入20141224 mod revive DispModeType.Question.  Yes or No
				//if (MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("選択した推進費No（{0}）の支払票を一括印刷します。\r\nよろしいですか？", srhListDataGridView.CurrentRow.Cells[suishinhiNoCol.Name].Value.ToString()))
				//    == System.Windows.Forms.DialogResult.OK)
				if (MessageForm.Show2(MessageForm.DispModeType.Question, string.Format("選択した推進費No（{0}）の支払票を一括印刷します。\r\nよろしいですか？", srhListDataGridView.CurrentRow.Cells[suishinhiNoCol.Name].Value.ToString()))
					== System.Windows.Forms.DialogResult.Yes)
                {
                    IIkkatsuPrintBtnClickALInput alInput = new IkkatsuPrintBtnClickALInput();
                    alInput.KensaKeihatsuSuishinListDataTable = _printTable;
                    alInput.PrintNo = printNoTextBox.Text.Trim();
                    alInput.SystemDt = _today;
                    alInput.LoginNm = _loginNm;
                    //ADD_HuyTX 2014/10/17 excel 019_Ver1.03 START
                    alInput.SuishinhiNo = srhListDataGridView.CurrentRow.Cells[suishinhiNoCol.Name].Value.ToString();
                    alInput.GyoshaCd = srhListDataGridView.CurrentRow.Cells[GyosyaCdCol.Name].Value.ToString();
                    //ADD_HuyTX 2014/10/17 excel 019_Ver1.03 END

                    new IkkatsuPrintBtnClickApplicationLogic().Execute(alInput);
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

        #region kobetsuGyosyaButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kobetsuGyosyaButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/17  HuyTX　  Excel 019_Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kobetsuGyosyaButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (srhListDataGridView.RowCount == 0) { return; }

                // 選択行の業者が組合一括支払の場合
                if (!string.IsNullOrEmpty(srhListDataGridView.CurrentRow.Cells[KumiaiCdCol.Name].Value.ToString().Trim()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "選択された業者は組合一括支払いになるため、個別印刷はできません。");
                    return;
                }

                if (!RequiredCheck()) { return; }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択した業者の個別業者支払票を印刷します。よろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                {
                    IKobetsuGyosyaBtnClickALInput alInput = new KobetsuGyosyaBtnClickALInput();

                    DataGridViewRow currentRow = srhListDataGridView.CurrentRow;

                    alInput.KensaKeihatsuSuishinListRows = (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[])_printTable.Select(string.Format("SuishinhiNo = {0} AND GyoshaCd = {1}",
                                    currentRow.Cells[suishinhiNoCol.Name].Value,
                                    currentRow.Cells[GyosyaCdCol.Name].Value));

                    alInput.PrintNo = printNoTextBox.Text.Trim();
                    alInput.SystemDt = _today;
                    alInput.LoginNm = _loginNm;
                    
                    new KobetsuGyosyaBtnClickApplicationLogic().Execute(alInput);
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

        #region kobetsuKumiaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kobetsuKumiaiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/16  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kobetsuKumiaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (srhListDataGridView.RowCount == 0) { return; }

                if (string.IsNullOrEmpty(srhListDataGridView.CurrentRow.Cells[KumiaiCdCol.Name].Value.ToString().Trim()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "選択された業者は組合に加入していないため、一括印刷対象外です。");
                    return;
                }

                if (!RequiredCheck()) { return; }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, string.Format("選択した組合、推進費No（{0}）の個別業者支払票を印刷します。よろしいですか？", srhListDataGridView.CurrentRow.Cells[suishinhiNoCol.Name].Value.ToString())) 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    // Export 021
                    IKobetsuKumiaiBtnClickALInput alInput = new KobetsuKumiaiBtnClickALInput();
                    alInput.PrintNo = printNoTextBox.Text.Trim();
                    alInput.SystemDt = _today;
                    alInput.LoginNm = _loginNm;
                    alInput.KyodoKumiaiCd = srhListDataGridView.CurrentRow.Cells[KumiaiCdCol.Name].Value.ToString();
                    alInput.KensaKeihatsuSuishinListDataTable = _printTable;
                    new KobetsuKumiaiBtnClickApplicationLogic().Execute(alInput);
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
        /// 2014/08/11  DatNT　  新規作成
        /// 2014/10/09  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No record in dgv!
                if (srhListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "印刷可能なデータが検索されていません。");
                    return;
                }

                //// 必須入力チェック
                //if (!RequiredCheck()) return;

                // 2014/10/09 DatNT v1.01 DEL Start
                //if (string.IsNullOrEmpty(syukeiNendoTextBox.Text) && allOptionRadioButton.Checked)
                //{
                //    MessageForm.Show2(MessageForm.DispModeType.Error, "一覧印刷は、集計年度、上期・下期を指定して検索したデータしか印刷できません");
                //    return;
                //}
                // 2014/10/09 DatNT v1.01 DEL End

                if (MessageForm.Show2(MessageForm.DispModeType.Question, string.Format("選択した推進費No（{0}）の検査啓発推進費一覧を印刷します。よろしいですか？", srhListDataGridView.CurrentRow.Cells[suishinhiNoCol.Name].Value.ToString()))
                    == DialogResult.Yes)
                {
                    IOutputBtnClickALInput alInput = new OutputBtnClickALInput();
                    //alInput.SyukeiNendo = Common.Common.ConvertToHoshouNendoWareki(syukeiNendoTextBox.Text);
                    //alInput.Option = allOptionRadioButton.Checked ? "1" : (kamikiRadioButton.Checked ? "2" : "3");
					
					//受入20141225 mod sta 選択した推進費No.のデータだけを出力する。
                    //alInput.KensaKeihatsuSuishinListDataTable = _printTable;

			        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable partPrintTable = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable();
					foreach( KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow partRow in 
						_printTable.Select(string.Format("SuishinhiNo = {0}",srhListDataGridView.CurrentRow.Cells[suishinhiNoCol.Name].Value.ToString())) )
					{
						partPrintTable.ImportRow(partRow);
					}

					alInput.KensaKeihatsuSuishinListDataTable = partPrintTable;
					//受入20141225 mod end

					new OutputBtnClickApplicationLogic().Execute(alInput);
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //OthersMenuForm frm = new OthersMenuForm();
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

        #region KensaKeihatsuSuishinhiListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKeihatsuSuishinhiListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKeihatsuSuishinhiListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        syukeiButton.Focus();
                        syukeiButton.PerformClick();
                        break;

                    case Keys.F2:
                        ikkatsuPrintButton.Focus();
                        ikkatsuPrintButton.PerformClick();
                        break;

                    case Keys.F3:
                        kobetsuGyosyaButton.Focus();
                        kobetsuGyosyaButton.PerformClick();
                        break;

                    case Keys.F4:
                        kobetsuKumiaiButton.Focus();
                        kobetsuKumiaiButton.PerformClick();
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

                    case Keys.F9:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
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

        #region deleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09  DatNT　    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (srhListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 2014/11/10 AnhNV DEL Start
                //if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？")
                //    != System.Windows.Forms.DialogResult.Yes)
                //{
                //    return;
                //}
                // 2014/11/10 AnhNV DEL End

                // 2014/11/10 AnhNV ADD Start
                string suishinhiNo = srhListDataGridView.CurrentRow.Cells[suishinhiNoCol.Name].Value.ToString();
                if (MessageForm.Show2(MessageForm.DispModeType.Question, string.Format("選択した推進費No（{0}）の集計データを一括削除します。よろしいですか？", suishinhiNo))
                    != DialogResult.Yes)
                {
                    return;
                }
                // 2014/11/10 AnhNV ADD End

                IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                alInput.SuishinhiNo = suishinhiNo;
                IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                DoSearch(false);
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
        /// 2014/10/20  DatNT　    v1.02
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
        /// 2014/10/20  DatNT　    v1.02
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
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/09  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            kensaKeihatsuSuishinHiShukeiTblDataSet.Clear();

            IFormLoadALInput alInput    = new FormLoadALInput();            
            //alInput.SuishinhiNendo      = syukeiNendoTextBox.Text;
            //alInput.KamiShimoKbn        = "1";
            alInput.ShukeiDtFrom        = yearFromTextBox.Text + GetMonth(monthFromComboBox.SelectedIndex);
            alInput.ShukeiDtTo          = yearToTextBox.Text + GetMonth(monthToComboBox.SelectedIndex);
            alInput.Mochikomi           = mochikomiCheckBox.Checked;
            alInput.Syusyu              = syusyuCheckBox.Checked;
            alInput.Toriatsukai         = toriatsukaiCheckBox.Checked;
            
            IFormLoadALOutput alOutput  = new FormLoadApplicationLogic().Execute(alInput);
            _printTable = alOutput.KensaKeihatsuSuishinListDT;

            // 共同組合
            Utility.Utility.SetComboBoxList(kyodoKumiaiComboBox, alOutput.KyodoKumiaiMstInfoDT, "KumiaiNm", "KumiaiCd", true);

            // Display data
            kensaKeihatsuSuishinHiShukeiTblDataSet.Merge(alOutput.KensaKeihatsuSuishinListDT);

            if (alOutput.KensaKeihatsuSuishinListDT == null || alOutput.KensaKeihatsuSuishinListDT.Count == 0)
            {
                srhListCountLabel.Text = "0件";

                ikkatsuPrintButton.Enabled = false;
                kobetsuGyosyaButton.Enabled = false;
                kobetsuKumiaiButton.Enabled = false;
                outputButton.Enabled = false;
            }
            else
            {
                srhListCountLabel.Text = alOutput.KensaKeihatsuSuishinListDT.Count.ToString() + "件";

                ikkatsuPrintButton.Enabled = true;
                kobetsuGyosyaButton.Enabled = true;
                kobetsuKumiaiButton.Enabled = true;
                outputButton.Enabled = true;
            }

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
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/09  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 2014/10/09 DatNT v1.01 DEL Start
            //// 集計年度
            //alInput.SuishinhiNendo = syukeiNendoTextBox.Text;
            
            //// 上下期区分 
            //if (kamikiRadioButton.Checked)
            //{
            //    alInput.KamiShimoKbn = "1";
            //}
            //else if (shimokiRadioButton.Checked)
            //{
            //    alInput.KamiShimoKbn = "2";
            //}
            // 2014/10/09 DatNT v1.01 DEL End

            // 2014/11/10 AnhNV DEL Start
            //// 2014/10/09 DatNT v1.01 ADD Start
            //alInput.ShukeiDtFrom = yearFromTextBox.Text + GetMonth(monthFromComboBox.SelectedIndex) + "01";
            //alInput.ShukeiDtTo = yearToTextBox.Text + GetMonth(monthToComboBox.SelectedIndex) + "31";
            //// 2014/10/09 DatNT v1.01 ADD End
            // 2014/11/10 AnhNV DEL End

            // 2014/11/10 AnhNV ADD Start
            alInput.ShukeiDtFrom = yearFromTextBox.Text + GetMonth(monthFromComboBox.SelectedIndex);
            alInput.ShukeiDtTo = yearToTextBox.Text + GetMonth(monthToComboBox.SelectedIndex);
            // 2014/11/10 AnhNV ADD End

            // 業者コード（開始）
            alInput.GyosyaCdFrom = gyosyaCdFromTextBox.Text;

            // 業者コード（終了）
            alInput.GyosyaCdTo = gyosyaCdToTextBox.Text;

            // 組合CD
            if (kyodoKumiaiComboBox.SelectedValue != null)
            {
                alInput.KumiaiCd = kyodoKumiaiComboBox.SelectedValue.ToString();
            }

            // 対象業者/持込
            alInput.Mochikomi = mochikomiCheckBox.Checked;

            // 対象業者/収集
            alInput.Syusyu = syusyuCheckBox.Checked;

            // 対象業者/取扱
            alInput.Toriatsukai = toriatsukaiCheckBox.Checked;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clickBtnSearch"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch(bool clickBtnSearch)
        {
            // Clear datagirdview
            kensaKeihatsuSuishinHiShukeiTblDataSet.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            // Create conditions
            MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);
            _printTable = alOutput.KensaKeihatsuSuishinListDT;

            // Display data
            kensaKeihatsuSuishinHiShukeiTblDataSet.Merge(alOutput.KensaKeihatsuSuishinListDT);

            if (alOutput.KensaKeihatsuSuishinListDT == null || alOutput.KensaKeihatsuSuishinListDT.Count == 0)
            {
                srhListCountLabel.Text = "0件";

                if (clickBtnSearch)
                {
                    // 保健所一覧 : リスト数 = 0
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                }

                ikkatsuPrintButton.Enabled = false;
                kobetsuGyosyaButton.Enabled = false;
                kobetsuKumiaiButton.Enabled = false;
                outputButton.Enabled = false;
            }
            else
            {
                srhListCountLabel.Text = alOutput.KensaKeihatsuSuishinListDT.Count.ToString() + "件";

                ikkatsuPrintButton.Enabled = true;
                kobetsuGyosyaButton.Enabled = true;
                kobetsuKumiaiButton.Enabled = true;
                outputButton.Enabled = true;
            }
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
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/10/09  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            // 2014/10/09 DatNT ADD Start
            
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

            if(string.IsNullOrEmpty(errMess.ToString()))
            {
                if (Convert.ToInt32(yearFromTextBox.Text + GetMonth(monthFromComboBox.SelectedIndex))
                    > Convert.ToInt32(yearToTextBox.Text + GetMonth(monthToComboBox.SelectedIndex)))
                {
                    errMess.AppendLine("範囲指定が正しくありません。集計年月の大小関係を確認してください。");
                }
            }

            // 2014/10/09 DatNT ADD End

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

            if(flg)
            {
                if (!string.IsNullOrEmpty(gyosyaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyosyaCdToTextBox.Text))
                {
                    if (Convert.ToInt32(gyosyaCdFromTextBox.Text) > Convert.ToInt32(gyosyaCdToTextBox.Text))
                    {
                        errMess.Append("範囲指定が正しくありません。業者コードの大小関係を確認してください。\r\n");
                    }
                }
            }

            // 対象業者のチェックが全てOFFの場合
            if (!mochikomiCheckBox.Checked && !syusyuCheckBox.Checked && !toriatsukaiCheckBox.Checked)
            {
                errMess.Append("対象業者を選択してください。\r\n");
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            // 2014/10/09 DatNT v1.01 DEL Start
            //// 集計年度
            //if (_today.Month > 3)
            //{
            //    syukeiNendoTextBox.Text = _today.Year.ToString();
            //}
            //else
            //{
            //    syukeiNendoTextBox.Text = (_today.Year - 1).ToString();
            //}

            //if (_today.Month >= 4 && _today.Month <= 10)
            //{
            //    // 上下期区分/上期
            //    kamikiRadioButton.Checked = true;
            //}
            //else
            //{
            //    // 上下期区分/下期
            //    shimokiRadioButton.Checked = true;
            //}
            // 2014/10/09 DatNT v1.01 DEL End

            // 2014/10/09 DatNT v1.01 ADD Start
            // 集計年月
            if (_today.Month >= 4 && _today.Month <= 9)
            {
                yearFromTextBox.Text = (_today.Year - 1).ToString();
                yearToTextBox.Text = _today.Year.ToString();
                monthFromComboBox.SelectedIndex = 9;
                monthToComboBox.SelectedIndex = 2;
            }
            else if (_today.Month >= 10 && _today.Month <= 12)
            {
                yearFromTextBox.Text = _today.Year.ToString();
                yearToTextBox.Text = _today.Year.ToString();
                monthFromComboBox.SelectedIndex = 3;
                monthToComboBox.SelectedIndex = 8;
            }
            else
            {
                yearFromTextBox.Text = (_today.Year - 1).ToString();
                yearToTextBox.Text = (_today.Year - 1).ToString();
                monthFromComboBox.SelectedIndex = 3;
                monthToComboBox.SelectedIndex = 8;
            }
            // 2014/10/09 DatNT v1.01 ADD End

            // 業者コード（開始）
            gyosyaCdFromTextBox.Clear();

            // 業者コード（終了）
            gyosyaCdToTextBox.Clear();

            // 共同組合
            kyodoKumiaiComboBox.SelectedIndex = -1;

            // 対象業者/持込
            mochikomiCheckBox.Checked = true;

            // 対象業者/収集
            syusyuCheckBox.Checked = true;

            // 対象業者/取扱
            toriatsukaiCheckBox.Checked = true;

            // 支払票印刷第○号
            printNoTextBox.Clear();
        }
        #endregion

        #region RequiredCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RequiredCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool RequiredCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // 支払票印刷時に支払票番号が未入力
            if (string.IsNullOrEmpty(printNoTextBox.Text))
            {
                // 2014/11/10 AnhNV DEL Start
                //errMess.Append("支払票印刷時は支払票番号は必須です。");
                // 2014/11/10 AnhNV DEL End
                // 2014/11/10 AnhNV ADD Start
                errMess.Append("支払票印刷時は支払票番号が必須です。");
                // 2014/11/10 AnhNV ADD End
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
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
}
