using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KensaIraishoOutputList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraishoOutputListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01　HuyTX       新規作成
    /// 2014/12/26　豊田        希釈倍率の絞り込みなどをデータ取得時に行うよう変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaIraishoOutputListForm : FukjBaseForm
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
        /// BOD検査項目コード
        /// </summary>
        private string _kensaBOD = String.Empty;

        /// <summary>
        /// DateTime Today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// kishakuBairitsuDT
        /// </summary>
        private ConstMstDataSet.ConstMstDataTable _kishakuBairitsuDT = new ConstMstDataSet.ConstMstDataTable();

        /// <summary>
        /// kensaIraishoOutputListDT 
        /// </summary>
        private JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable _kensaIraishoOutputListDT = new JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable();

        #endregion

        #region フィールド(peivate)

        // 2015.01.06 toyoda Add Start 検索実行時の選択状態に応じて出力する依頼書を設定
        /// <summary>
        /// 出力依頼書(true：11条水質 false：計量証明)
        /// </summary>
        private bool outputIraisho = true;
        // 2015.01.06 toyoda Add End

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaIraishoOutputListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaIraishoOutputListForm()
        {
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region イベント

        #region KensaIraishoOutputListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoOutputListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaIraishoOutputListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'constMstDataSet.KishakuBairitsu' table. You can move, or remove it, as needed.
            this.kishakuBairitsuTableAdapter.Fill(this.constMstDataSet.KishakuBairitsu);
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //reset search panel
                ClearSearchPanel();

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
        /// 2014/12/01　HuyTX    新規作成
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
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ClearSearchPanel();
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
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidDataSearch()) return;

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

        #region chikuCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chikuCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chikuCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(chikuCdFromTextBox, chikuCdFromTextBox, chikuCdToTextBox);
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

        #region chikuCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chikuCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chikuCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(chikuCdToTextBox, chikuCdFromTextBox, chikuCdToTextBox);
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

        #region daichoFrom1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoFrom1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoFrom1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(daichoFrom1TextBox,
                                                        daichoFrom1TextBox,
                                                        daichoTo1TextBox,
                                                        daichoFrom2TextBox,
                                                        daichoTo2TextBox,
                                                        daichoFrom3TextBox,
                                                        daichoTo3TextBox);
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

        #region daichoFrom2TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoFrom2TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoFrom2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(daichoFrom2TextBox,
                                                        daichoFrom1TextBox,
                                                        daichoTo1TextBox,
                                                        daichoFrom2TextBox,
                                                        daichoTo2TextBox,
                                                        daichoFrom3TextBox,
                                                        daichoTo3TextBox);
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

        #region daichoFrom3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoFrom3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoFrom3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(daichoFrom3TextBox,
                                                        daichoFrom1TextBox,
                                                        daichoTo1TextBox,
                                                        daichoFrom2TextBox,
                                                        daichoTo2TextBox,
                                                        daichoFrom3TextBox,
                                                        daichoTo3TextBox);
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

        #region daichoTo1TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoTo1TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoTo1TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(daichoTo1TextBox,
                                                        daichoFrom1TextBox,
                                                        daichoTo1TextBox,
                                                        daichoFrom2TextBox,
                                                        daichoTo2TextBox,
                                                        daichoFrom3TextBox,
                                                        daichoTo3TextBox);
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

        #region daichoTo2TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoTo2TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoTo2TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(daichoTo2TextBox,
                                                        daichoFrom1TextBox,
                                                        daichoTo1TextBox,
                                                        daichoFrom2TextBox,
                                                        daichoTo2TextBox,
                                                        daichoFrom3TextBox,
                                                        daichoTo3TextBox);
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

        #region daichoTo3TextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoTo3TextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoTo3TextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.PaddingZeroForTextBoxLeave(daichoTo3TextBox,
                                                        daichoFrom1TextBox,
                                                        daichoTo1TextBox,
                                                        daichoFrom2TextBox,
                                                        daichoTo2TextBox,
                                                        daichoFrom3TextBox,
                                                        daichoTo3TextBox);
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

        #region allButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： allButton_Click
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
        private void allButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in jokasoListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[selectCol.Name];
                    chk.Value = chk.TrueValue;
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

        #region kaijoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaijoButton_Click
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
        private void kaijoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in jokasoListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[selectCol.Name];
                    chk.Value = chk.FalseValue;
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

        #region KensaIraishoOutputListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoOutputListForm_KeyDown
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
        private void KensaIraishoOutputListForm_KeyDown(object sender, KeyEventArgs e)
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

        #region jokasoListDataGridView_CellContentClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jokasoListDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jokasoListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.ColumnIndex != changeButton.Index) return;

                JokasoDaichoMstDataSet.KensaIraishoOutputListRow iraishoRow =
                    (JokasoDaichoMstDataSet.KensaIraishoOutputListRow)((DataRowView)jokasoListDataGridView.CurrentRow.DataBoundItem).Row;

                KensaSetSelectForm selectFrm = new KensaSetSelectForm(iraishoRow.JokasoHokenjoCd,
                                                                        iraishoRow.JokasoTorokuNendo,
                                                                        iraishoRow.JokasoRenban,
                                                                        iraishoRow.kensaKomokuEdabanCol);

                selectFrm.ShowDialog();

                if (selectFrm.DialogResult == DialogResult.OK)
                {
                    jokasoListDataGridView.CurrentRow.Cells[keiryoShomeiNmCol.Index].Value = selectFrm._daichoKensaSetNmReturn;
                    jokasoListDataGridView.CurrentRow.Cells[kensaKomokuEdabanCol.Index].Value = selectFrm._kensaKomokuEdabaReturn;
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
        /// 2014/12/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            
            
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //check input data to GridView
                if (!IsCheckInputGridView()) return;

                //Print check
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "依頼書を印刷します。よろしいですか？") != DialogResult.Yes) return;

                //Print data
                IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                alInput.InsatsuKbn = selectJokasoRadioButton.Checked ? "1" : "2";
                alInput.CopyCount = Int32.Parse(busuTextBox.Text.Trim());
                alInput.KensaIraishoOutputListDataTable = _kensaIraishoOutputListDT;

                // 2015.01.06 toyoda Modify Start 検索実行時の選択状態に応じて出力する依頼書を設定
                //alInput.Shutsuryoku = kensa11JoButton.Checked ? "1" : "2";
                alInput.Shutsuryoku = outputIraisho ? "1" : "2";
                // 2015.01.06 toyoda Modify End

                new PrintBtnClickApplicationLogic().Execute(alInput);

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
        /// 2014/12/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jokasoListDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "検査依頼書出力一覧";
                Common.Common.FlushGridviewDataToExcel(jokasoListDataGridView, outputFilename);

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
        /// 2014/12/03　HuyTX    新規作成
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

        #region kensaUketsukeDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaUketsukeDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaUketsukeDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaUketsukeDtFromDateTimePicker.Enabled = kensaUketsukeDtUseCheckBox.Checked;
                kensaUketsukeDtToDateTimePicker.Enabled = kensaUketsukeDtUseCheckBox.Checked;
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

        #region kensaUketsukeDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaUketsukeDtFromDateTimePicker_ValueChanged
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
        private void kensaUketsukeDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                kensaUketsukeDtToDateTimePicker.Value = kensaUketsukeDtFromDateTimePicker.Value;
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
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            //浄化槽番号（開始） (保健所コード)
            daichoFrom1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //浄化槽番号（開始） (年度)
            daichoFrom2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //浄化槽番号（開始） (連番)
            daichoFrom3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, HorizontalAlignment.Left);
            //浄化槽番号（終了） (保健所コード)
            daichoTo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //浄化槽番号（終了） (年度)
            daichoTo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //浄化槽番号（終了） (連番)
            daichoTo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, HorizontalAlignment.Left);
            //設置者
            settisyaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            //地区コード（開始） 
            chikuCdFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, HorizontalAlignment.Left);
            //地区コード（開始） 
            chikuCdToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, HorizontalAlignment.Left);
            //部数
            busuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);

            //浄化槽一覧グリッドビュー
            //浄化槽番号
            jokasoListDataGridView.SetStdControlDomain(jokasoNoCol.Index, ZControlDomain.ZG_STD_NAME, 11);
            //設置者名
            jokasoListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            //設置場所
            jokasoListDataGridView.SetStdControlDomain(settiBasyoCol.Index, ZControlDomain.ZG_STD_NAME, 80);
            //地区名
            jokasoListDataGridView.SetStdControlDomain(chikuNmCol.Index, ZControlDomain.ZG_STD_NAME, 20);
            //外観検査地区
            jokasoListDataGridView.SetStdControlDomain(gaikanChikuCol.Index, ZControlDomain.ZG_STD_CD, 1);
            //計量証明パターン
            jokasoListDataGridView.SetStdControlDomain(keiryoShomeiNmCol.Index, ZControlDomain.ZG_STD_NAME, 80);

        }
        #endregion

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;
            busuTextBox.Text = "1";

            //BOD検査項目コード
            //float.TryParse(Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_065, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001), out _kensaBOD);
            _kensaBOD = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_065, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

            _kishakuBairitsuDT = (ConstMstDataSet.ConstMstDataTable)Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_064);

        }
        #endregion

        #region ClearSearchPanel
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchPanel
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HuyTX    新規作成
        /// 2014/12/11  DatNT   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchPanel()
        {
            //出力依頼書/11条水質
            kensa11JoButton.Checked = true;
            //外観検査地区/A
            gaikanChikuACheckBox.Checked = true;
            //外観検査地区/B
            gaikanChikuBCheckBox.Checked = true;
            //外観検査地区/C
            gaikanChikuCCheckBox.Checked = true;
            //外観検査地区/D
            gaikanChikuDCheckBox.Checked = true;
            //外観検査地区/E
            gaikanChikuECheckBox.Checked = true;
            //浄化槽番号（開始） (保健所コード)
            daichoFrom1TextBox.Text = string.Empty;
            //浄化槽番号（開始） (年度)
            daichoFrom2TextBox.Text = string.Empty;
            //浄化槽番号（開始） (連番)
            daichoFrom3TextBox.Text = string.Empty;
            //浄化槽番号（終了） (保健所コード)
            daichoTo1TextBox.Text = string.Empty;
            //浄化槽番号（終了） (年度)
            daichoTo2TextBox.Text = string.Empty;
            //浄化槽番号（終了） (連番)
            daichoTo3TextBox.Text = string.Empty;
            //設置者
            settisyaTextBox.Text = string.Empty;
            //地区コード（開始） 
            chikuCdFromTextBox.Text = string.Empty;
            //地区コード（開始） 
            chikuCdToTextBox.Text = string.Empty;

            // 2014/12/11 DatNT v1.01 ADD Start
            // 検査受付日検索使用フラグ
            kensaUketsukeDtUseCheckBox.Checked = false;
            // 検査受付日（開始）
            kensaUketsukeDtFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            kensaUketsukeDtFromDateTimePicker.Enabled = false;
            // 検査受付日（終了）
            kensaUketsukeDtToDateTimePicker.Value = today;
            kensaUketsukeDtToDateTimePicker.Enabled = false;
            // 2014/12/11 DatNT v1.01 ADD End
        }
        #endregion

        #region IsValidDataSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidDataSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// 2014/12/11  DatNT   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidDataSearch()
        {
            StringBuilder errMsg = new StringBuilder();

            //[未選択チェック] - 外観検査地区選択
            if (!gaikanChikuACheckBox.Checked
                && !gaikanChikuBCheckBox.Checked
                && !gaikanChikuCCheckBox.Checked
                && !gaikanChikuDCheckBox.Checked
                && !gaikanChikuECheckBox.Checked)
            {
                errMsg.AppendLine("外観検査地区が選択されていません。");
            }

            //[関連チェック]
            //浄化槽番号（開始＆終了）
            if (!Utility.Utility.IsValidKyokaiNo(daichoFrom1TextBox,
                                                daichoFrom2TextBox,
                                                daichoFrom3TextBox,
                                                daichoTo1TextBox,
                                                daichoTo2TextBox,
                                                daichoTo3TextBox))
            {
                errMsg.AppendLine("範囲指定が正しくありません。浄化槽番号の大小関係を確認してください。");
            }

            //地区コード（開始＆終了）
            if (!string.IsNullOrEmpty(chikuCdFromTextBox.Text)
                && !string.IsNullOrEmpty(chikuCdToTextBox.Text)
                && Convert.ToInt32(chikuCdFromTextBox.Text) > Convert.ToInt32(chikuCdToTextBox.Text)
                )
            {
                errMsg.AppendLine("範囲指定が正しくありません。地区コードの大小関係を確認してください。");
            }

            // 2014/12/11 DatNT v1.01 ADD Start
            if (kensaUketsukeDtUseCheckBox.Checked)
            {
                if (kensaUketsukeDtFromDateTimePicker.Value > kensaUketsukeDtToDateTimePicker.Value)
                {
                    errMsg.AppendLine("範囲指定が正しくありません。検査受付日の大小関係を確認してください。");
                }
            }
            // 2014/12/11 DatNT v1.01 ADD End

            //throw error message
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
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
        /// 2014/12/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            //clear GridView
            jokasoListDataGridView.DataSource = null;
            jokasoListDataGridView.Rows.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            alInput.SearchCond = MakeSearchCondition();
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);
            
            _kensaIraishoOutputListDT = MakeGridViewDataSource(alOutput.KensaIraishoOutputListDataTable,
                                                                        alOutput.KishakuBairitsuKensaKekkaDataTable,
                                                                        alOutput.KishakuBairitsuShomeiKekkaDataTable);

            //set data source to GridView
            jokasoListDataGridView.DataSource = _kensaIraishoOutputListDT;
            srhListCountLabel.Text = jokasoListDataGridView.RowCount + "件";

            // 2015.01.06 toyoda Add Start 検索実行時の選択状態に応じて出力する依頼書を設定
            outputIraisho = kensa11JoButton.Checked;
            // 2015.01.06 toyoda Add End

            if (jokasoListDataGridView.RowCount == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }

        }
        #endregion

        #region MakeSearchCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// 2014/12/11  DatNT   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraishoOutputSearchCond MakeSearchCondition()
        {
            KensaIraishoOutputSearchCond searchCond = new KensaIraishoOutputSearchCond();

            //出力依頼書
            searchCond.Shutsuryoku = kensa11JoButton.Checked ? "1" : "2";

            List<string> gaikanChikuList = new List<string>();
            //外観検査地区/A
            if (gaikanChikuACheckBox.Checked)
            {
                gaikanChikuList.Add(Utility.Constants.GaikanChikuConstant.GAIKAN_CHIKU_A);
            }
            //外観検査地区/B
            if (gaikanChikuBCheckBox.Checked)
            {
                gaikanChikuList.Add(Utility.Constants.GaikanChikuConstant.GAIKAN_CHIKU_B);
            }
            //外観検査地区/C
            if (gaikanChikuCCheckBox.Checked)
            {
                gaikanChikuList.Add(Utility.Constants.GaikanChikuConstant.GAIKAN_CHIKU_C);
            }
            //外観検査地区/D
            if (gaikanChikuDCheckBox.Checked)
            {
                gaikanChikuList.Add(Utility.Constants.GaikanChikuConstant.GAIKAN_CHIKU_D);
            }
            //外観検査地区/E
            if (gaikanChikuECheckBox.Checked)
            {
                gaikanChikuList.Add(Utility.Constants.GaikanChikuConstant.GAIKAN_CHIKU_E);
            }
            //外観検査地区
            searchCond.GaikanChiku = gaikanChikuList;

            //浄化槽番号（開始） (保健所コード)
            searchCond.HokenjoCdFrom = daichoFrom1TextBox.Text.Trim();
            //浄化槽番号（開始） (年度)
            searchCond.NendoFrom = daichoFrom2TextBox.Text.Trim();
            //浄化槽番号（開始） (連番)
            searchCond.RenbanFrom = daichoFrom3TextBox.Text.Trim();

            //浄化槽番号（終了） (保健所コード)
            searchCond.HokenjoCdTo = daichoTo1TextBox.Text.Trim();
            //浄化槽番号（終了） (年度)
            searchCond.NendoTo = daichoTo2TextBox.Text.Trim();
            //浄化槽番号（終了） (連番)
            searchCond.RenbanTo = daichoTo3TextBox.Text.Trim();

            //設置者
            searchCond.SetchishaNm = settisyaTextBox.Text.Trim();

            //地区コード（開始） 
            searchCond.ChikuCdFrom = chikuCdFromTextBox.Text.Trim();
            //地区コード（終了） 
            searchCond.ChikuCdTo = chikuCdToTextBox.Text.Trim();

            // 2014/12/11 DatNT v1.01 ADD Start
            if (kensaUketsukeDtUseCheckBox.Checked)
            {
                searchCond.UketsukeDtFrom = kensaUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                searchCond.UketsukeDtTo = kensaUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }
            // 2014/12/11 DatNT v1.01 ADD End

            return searchCond;
        }
        #endregion

        #region MakeGridViewDataSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeGridViewDataSource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraishoOutputListDT"></param>
        /// <param name="kishakuBairitsuKensaKekkaDT"></param>
        /// <param name="kishakuBairitsuShomeiKekkaDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX    新規作成
        /// 2014/12/25  小松　　　　受付日が直近のレコードを取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable MakeGridViewDataSource(
            JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable iraishoOutputListDT,
            KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaDataTable kishakuBairitsuKensaKekkaDT,
            KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable kishakuBairitsuShomeiKekkaDT)
        {
            string hokenjoCdColumn = string.Empty;
            string nendoColumn = string.Empty;
            string renbanColumn = string.Empty;
            string shikenkoumokuCdColumn = string.Empty;

            // 2014.12.26 toyoda delete start
            //string condition = string.Empty;
            // 2014.12.26 toyoda delete end            

            string constCondition = string.Empty;
            string kishakuBairitsu = string.Empty;
            decimal kekkaBOD = 0;
            bool hasKekkaValue = false;
            JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable returnDataTable = new JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable();

            hokenjoCdColumn = kensa11JoButton.Checked ? kishakuBairitsuKensaKekkaDT.KensaIraiJokasoHokenjoCdColumn.ColumnName
                : kishakuBairitsuShomeiKekkaDT.KeiryoShomeiJokasoDaichoHokenjoCdColumn.ColumnName;
            nendoColumn = kensa11JoButton.Checked ? kishakuBairitsuKensaKekkaDT.KensaIraiJokasoTorokuNendoColumn.ColumnName
                : kishakuBairitsuShomeiKekkaDT.KeiryoShomeiJokasoDaichoNendoColumn.ColumnName;
            renbanColumn = kensa11JoButton.Checked ? kishakuBairitsuKensaKekkaDT.KensaIraiJokasoRenbanColumn.ColumnName
                : kishakuBairitsuShomeiKekkaDT.KeiryoShomeiJokasoDaichoRenbanColumn.ColumnName;
            shikenkoumokuCdColumn = kishakuBairitsuShomeiKekkaDT.KeiryoShomeiShikenkoumokuCdColumn.ColumnName;

            for (int i = 0; i < iraishoOutputListDT.Count; i++)
            {
                JokasoDaichoMstDataSet.KensaIraishoOutputListRow iraishoOutputRow = iraishoOutputListDT[i];

                // 2014.12.26 toyoda delete start
                //condition = string.Empty;
                // 2014.12.26 toyoda delete end

                constCondition = string.Empty;
                kishakuBairitsu = string.Empty;
                kekkaBOD = 0;
                hasKekkaValue = false;

                // 2014.12.26 toyoda delete start
                ////make condition
                //condition = string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'{6}",
                //    new string[] { hokenjoCdColumn,
                //                    iraishoOutputRow.JokasoHokenjoCd,
                //                    nendoColumn,
                //                    iraishoOutputRow.JokasoTorokuNendo,
                //                    renbanColumn,
                //                    iraishoOutputRow.JokasoRenban,
                //                    keiryoShomeiButton.Checked ? string.Format(" AND {0} = {1}", shikenkoumokuCdColumn, _kensaBOD) : string.Empty
                //                });
                // 2014.12.26 toyoda delete end

                if (kensa11JoButton.Checked)
                {
                    constCondition = string.Format("{0} >= '{1}'", _kishakuBairitsuDT.ConstRenbanColumn.ColumnName, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_003);

                    // 2014.12.26 toyoda modify start
                    //get TOP(1) KensaKekkaBOD
                    //foreach (KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaRow kensaKekkaRow in kishakuBairitsuKensaKekkaDT.Select(condition))
                    //foreach (KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaRow kensaKekkaRow in kishakuBairitsuKensaKekkaDT.Select(condition, kishakuBairitsuKensaKekkaDT.KensaIraiSuishitsuUketsukeDtColumn.ColumnName + " DESC"))
                    //{
                    //    kekkaBOD = (decimal)kensaKekkaRow.KensaKekkaBOD;
                    //    hasKekkaValue = true;
                    //    break;
                    //}
                    KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaRow row = kishakuBairitsuKensaKekkaDT.FindByKensaIraiJokasoHokenjoCdKensaIraiJokasoTorokuNendoKensaIraiJokasoRenban(iraishoOutputRow.JokasoHokenjoCd, iraishoOutputRow.JokasoTorokuNendo, iraishoOutputRow.JokasoRenban);
                    if(row != null)
                    {
                        kekkaBOD = (decimal)row.KensaKekkaBOD;
                        hasKekkaValue = true;
                    }
                    // 2014.12.26 toyoda modify end
                }
                else
                {
                    // 2014.12.26 toyoda modify start
                    //get TOP(1) KeiryoShomeiKekkaValue
                    //foreach (KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaRow shomeiKekkaRow in kishakuBairitsuShomeiKekkaDT.Select(condition))
                    //foreach (KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaRow shomeiKekkaRow in kishakuBairitsuShomeiKekkaDT.Select(condition, kishakuBairitsuShomeiKekkaDT.KeiryoShomeiIraiUketsukeDtColumn.ColumnName + " DESC"))
                    //{
                    //    kekkaBOD = shomeiKekkaRow.KeiryoShomeiKekkaValue;
                    //    hasKekkaValue = true;
                    //    break;
                    //}
                    KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaRow row = kishakuBairitsuShomeiKekkaDT.FindByKeiryoShomeiJokasoDaichoHokenjoCdKeiryoShomeiJokasoDaichoNendoKeiryoShomeiJokasoDaichoRenbanKeiryoShomeiShikenkoumokuCd(iraishoOutputRow.JokasoHokenjoCd, iraishoOutputRow.JokasoTorokuNendo, iraishoOutputRow.JokasoRenban, _kensaBOD);
                    if (row != null)
                    {
                        kekkaBOD = row.KeiryoShomeiKekkaValue;
                        hasKekkaValue = true;
                    }
                    // 2014.12.26 toyoda modify end
                }

                //get Top(1) ConstRenban
                foreach (ConstMstDataSet.ConstMstRow constRow in _kishakuBairitsuDT.Select(constCondition, _kishakuBairitsuDT.ConstRenbanColumn.ColumnName))
                {
                    if (Decimal.Parse(constRow.ConstValue) >= kekkaBOD)
                    {
                        kishakuBairitsu = constRow.ConstRenban; break;
                    }
                }
                //set data for kishakuBairitsuCol
                //iraishoOutputRow.kishakuBairitsuCol = kishakuBairitsu;
                iraishoOutputRow.kishakuBairitsuCol = string.IsNullOrEmpty(constCondition) && !hasKekkaValue ? string.Empty : kishakuBairitsu;
                returnDataTable.ImportRow(iraishoOutputRow);
            }

            return returnDataTable;
        }
        #endregion

        #region IsCheckInputGridView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsCheckInputGridView
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsCheckInputGridView()
        {
            StringBuilder errMsg = new StringBuilder();
            bool isSelectedDgv = false;
            bool isValidDgv = true;

            foreach (DataGridViewRow row in jokasoListDataGridView.Rows)
            {
                if (!isSelectedDgv
                    && (row.Cells[selectCol.Index].Value != null && row.Cells[selectCol.Index].Value.ToString() == "1"))
                {
                    isSelectedDgv = true;
                }

                if (isValidDgv && (row.Cells[selectCol.Index].Value != null && row.Cells[selectCol.Index].Value.ToString() == "1")
                    && (row.Cells[kishakuBairitsuCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[kishakuBairitsuCol.Index].Value.ToString())))
                {
                    isValidDgv = false;
                }
                
                // 2015.01.06 toyoda Add Start 入力値チェック仕様追加
                if(row.Cells[selectCol.Index].Value != null && row.Cells[selectCol.Index].Value.ToString() == "1")
                {
                    // 11条水質
                    if (outputIraisho)
                    {
                        // 5人槽未満は出力不可
                        if (row.Cells[JokasoShoriTaishoJinin.Index].Value == null || int.Parse(row.Cells[JokasoShoriTaishoJinin.Index].Value.ToString()) < 5)
                        {
                            errMsg.AppendLine(string.Format("処理対象人員を見直してください。浄化槽番号[{0}]", row.Cells[jokasoNoCol.Index].Value.ToString()));
                        }
                    }
                    // 計量証明
                    else
                    {
                        // 必須：計量証明パターン
                        if (row.Cells[kensaKomokuEdabanCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[kensaKomokuEdabanCol.Index].Value.ToString()))
                        {
                            errMsg.AppendLine(string.Format("計量証明パターンを選択してください。浄化槽番号[{0}]", row.Cells[jokasoNoCol.Index].Value.ToString()));
                        }
                    }
                }
                // 2015.01.06 toyoda Add End
            }

            //部数
            if (string.IsNullOrEmpty(busuTextBox.Text.Trim()))
            {
                errMsg.AppendLine("部数を入力してください。");
            }

            //印刷チェックボックス
            if (selectJokasoRadioButton.Checked && !isSelectedDgv)
            {
                errMsg.AppendLine("印刷対象の浄化槽が選択されていません。");
            }

            //希釈倍率
            if (!isValidDgv)
            {
                errMsg.AppendLine("希釈倍率が選択されていません。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #endregion
    }
    #endregion

}
