using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.KingakuShisan;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KingakuShisanForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KingakuShisanForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// Loaded Form
        /// </summary>
        private bool isLoad = false;

        /// <summary>
        /// 
        /// </summary>
        private List<string> listCd = new List<string>();
        
        /// <summary>
        /// 税率
        /// </summary>
        private decimal zeiritsu = Common.Common.GetSyohizei(Common.Common.GetCurrentTimestamp().ToString("yyyyMMdd"));

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KingakuShisanForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KingakuShisanForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KingakuShisanForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KingakuShisanForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KingakuShisanForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();

                isLoad = true;
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

        #region shisanButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shisanButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// 2014/10/22  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shisanButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int selcol = 0;
                int selrow = 0;

                decimal hotei = 0;
                decimal suishitsu1 = 0;
                decimal suishitsu2 = 0;
                decimal yoshi1 = 0;
                decimal yoshi2 = 0;

                foreach (DataGridViewCell c in hoteiKensaListDataGridView.SelectedCells)
                {
                    selcol = c.ColumnIndex;
                    selrow = c.RowIndex;
                }

                if (selcol > 0)
                {
                    hotei = Convert.ToDecimal(hoteiKensaListDataGridView.Rows[selrow].Cells[selcol].Value);
                }

                foreach (DataGridViewRow suiRow in suishitsuKensaListDataGridView.Rows)
                {
                    if (suiRow.Cells["SelectCol"].Value == null || suiRow.Cells["SelectCol"].Value.ToString() == "False")
                    {
                        // don't handled
                    }
                    else
                    {
                        suishitsu1 += Convert.ToDecimal(suiRow.Cells["zeikomiCol"].Value);

                        if (kaiinRadioButton.Checked)
                        {
                            suishitsu2 += Convert.ToDecimal(suiRow.Cells["KensaRyokinCol"].Value);
                        }
                        else
                        {
                            suishitsu2 += Convert.ToDecimal(suiRow.Cells["hiKaiinRyokinCol"].Value);
                        }
                    }
                }

                foreach (DataGridViewRow yoshiRow in yoshiListDataGridView.Rows)
                {
                    // 2014/10/22 DatNT v1.01 START DEL
                    //if (yoshiRow.Cells["BaraCntCol"].Value != null && !string.IsNullOrEmpty(yoshiRow.Cells["BaraCntCol"].Value.ToString()))
                    //{
                    //    if (kaiinRadioButton.Checked)
                    //    {
                    //        yoshi += Convert.ToDecimal(yoshiRow.Cells["BaraCntCol"].Value) * Convert.ToDecimal(yoshiRow.Cells["KaiinTankaCol"].Value);
                    //    }
                    //    else
                    //    {
                    //        yoshi += Convert.ToDecimal(yoshiRow.Cells["BaraCntCol"].Value) * Convert.ToDecimal(yoshiRow.Cells["HiKaiinTankaCol"].Value);
                    //    }
                    //}

                    //if (yoshiRow.Cells["SetCntCol"].Value != null && !string.IsNullOrEmpty(yoshiRow.Cells["SetCntCol"].Value.ToString()))
                    //{
                    //    if (kaiinRadioButton.Checked)
                    //    {
                    //        yoshi += Convert.ToDecimal(yoshiRow.Cells["SetCntCol"].Value) * Convert.ToDecimal(yoshiRow.Cells["KaiinSetKakakuCol"].Value);
                    //    }
                    //    else
                    //    {
                    //        yoshi += Convert.ToDecimal(yoshiRow.Cells["SetCntCol"].Value) * Convert.ToDecimal(yoshiRow.Cells["HiKaiinSetKakakuCol"].Value);
                    //    }
                    //}
                    // 2014/10/22 DatNT v1.01 END DEL

                    // 2014/10/22 DatNT v1.01 START ADD
                    if (yoshiRow.Cells["BaraCntCol"].Value != null && !string.IsNullOrEmpty(yoshiRow.Cells["BaraCntCol"].Value.ToString()))
                    {
                        if (Convert.ToDecimal(yoshiRow.Cells["BaraCntCol"].Value) > 0)
                        {
                            yoshi1 += Convert.ToDecimal(yoshiRow.Cells["hanbaiKingakuCol"].Value);

                            yoshi2 += Convert.ToDecimal(yoshiRow.Cells["hanbaiKakakuCol"].Value);
                        }
                    }
                    // 2014/10/22 DatNT v1.01 END ADD
                }

                decimal total1 = hotei + suishitsu1 + yoshi1;

                decimal total2 = hotei + suishitsu2 + yoshi2;

                // 試算金額(税抜)
                shisanZeikomiTextBox.Text = total1.ToString("#,0");

                // 試算金額(税込)
                shisanZeinukiTextBox.Text = total2.ToString("#,0");
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
        /// 2014/08/22  DatNT　  新規作成
        /// 2014/10/23  DatNT    v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 試算金額(税抜)
                shisanZeikomiTextBox.Text = "0";

                // 試算金額(税込)
                shisanZeinukiTextBox.Text = "0";

                if (hoteiKensaListDataGridView.RowCount > 0)
                {
                    hoteiKensaListDataGridView.Rows[0].Selected = true;
                    hoteiKensaListDataGridView.CurrentCell = hoteiKensaListDataGridView.Rows[0].Cells["NinsoCol"];
                }

                if (suishitsuKensaListDataGridView.RowCount > 0)
                {
                    // 法定検査一覧 ⇒ 1行目1列目にフォーカス移動
                    suishitsuKensaListDataGridView.Rows[0].Selected = true;
                    suishitsuKensaListDataGridView.CurrentCell = suishitsuKensaListDataGridView.Rows[0].Cells["SelectCol"];

                    // 水質検査一覧 ⇒ 選択列のチェックを全てOFF(false)に変更
                    foreach (DataGridViewRow row in suishitsuKensaListDataGridView.Rows)
                    {
                        row.Cells["SelectCol"].Value = false;
                    }
                }

                // 会員/非会員区分 ⇒ 会員を選択(true)
                kaiinRadioButton.Checked = true;

                // 用紙一覧 ⇒ バラ数、セット数の入力欄を全行クリア
                if (yoshiListDataGridView.RowCount > 0)
                {
                    foreach (DataGridViewRow yoshiRow in yoshiListDataGridView.Rows)
                    {
                        yoshiRow.Cells["BaraCntCol"].Value = string.Empty;
                        // 2014/10/23 DatNT v1.01 MOD START
                        //yoshiRow.Cells["SetCntCol"].Value = string.Empty;
                        yoshiRow.Cells["hanbaiKakakuCol"].Value = string.Empty;
                        yoshiRow.Cells["ShohizeiCol"].Value = string.Empty;
                        yoshiRow.Cells["hanbaiKingakuCol"].Value = string.Empty;
                        // 2014/10/23 DatNT v1.01 MOD END
                    }

                    yoshiListDataGridView.Rows[0].Selected = true;
                    yoshiListDataGridView.CurrentCell = yoshiListDataGridView.Rows[0].Cells[YoshiCdCol.Name];
                }

                hoteiKensaListDataGridView.Focus();
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
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
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

        #region KingakuShisanForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KingakuShisanForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KingakuShisanForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        shisanButton.PerformClick();
                        shisanButton.Focus();
                        break;

                    case Keys.F7:
                        clearButton.PerformClick();
                        clearButton.Focus();
                        break;

                    case Keys.F12:
                        tojiruButton.PerformClick();
                        tojiruButton.Focus();
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

        #region yoshiListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                e.Control.KeyPress += new KeyPressEventHandler(ControlKeyPress);
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

        #region yoshiListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!isLoad) { return; }

                string colName = yoshiListDataGridView.Columns[yoshiListDataGridView.CurrentCell.ColumnIndex].Name;

                if (colName == BaraCntCol.Name)
                {
                    if (yoshiListDataGridView.CurrentRow.Cells[colName].Value != null)
                    {
                        int number;
                        if (!Int32.TryParse(yoshiListDataGridView.CurrentRow.Cells[colName].Value.ToString(), out number))
                        {
                            yoshiListDataGridView.CurrentRow.Cells[colName].Value = string.Empty;
                        }
                    }

                    CalcDgv(kaiinRadioButton.Checked);
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

        #region suishitsuKensaListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (listCd.Count > 0)
                {
                    foreach (DataGridViewRow row in suishitsuKensaListDataGridView.Rows)
                    {
                        foreach (string cd in listCd)
                        {
                            string kbn = cd.Split('-')[0];
                            string kensaCd = cd.Split('-')[1];

                            if (row.Cells["SetTanKbnCol"].Value.ToString() == kbn && row.Cells["KensaCdCol"].Value.ToString() == kensaCd)
                            {
                                row.Cells["SelectCol"].Value = true;
                            }
                        }
                    }
                }

                shisanZeikomiTextBox.Focus();
                suishitsuKensaListDataGridView.Focus();
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

        #region suishitsuKensaListDataGridView_CellEndEdit
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                listCd = new List<string>();

                string colName = suishitsuKensaListDataGridView.Columns[e.ColumnIndex].Name;

                if (colName != "SelectCol") { return; }

                foreach (DataGridViewRow row in suishitsuKensaListDataGridView.Rows)
                {
                    string cd = row.Cells["SetTanKbnCol"].Value.ToString() + "-" + row.Cells["KensaCdCol"].Value.ToString();
                    listCd.Add(cd);
                }

                foreach (DataGridViewRow row in suishitsuKensaListDataGridView.Rows)
                {
                    string cd = row.Cells["SetTanKbnCol"].Value.ToString() + "-" + row.Cells["KensaCdCol"].Value.ToString();

                    if (row.Cells["SelectCol"].Value == null || row.Cells["SelectCol"].Value.ToString() == "False")
                    {
                        if (listCd.Contains(cd))
                        {
                            listCd.Remove(cd);
                        }
                    }
                    else
                    {
                        if (!listCd.Contains(cd))
                        {
                            listCd.Add(cd);
                        }

                    }
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

        #region kaiinRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaiinRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaiinRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kaiinRadioButton.Checked)
                {
                    CalcDgv(true);
                }
                else
                {
                    CalcDgv(false);
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

        #region hiKaiinRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hiKaiinRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  DatNT　  v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hiKaiinRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (hiKaiinRadioButton.Checked)
                {
                    CalcDgv(false);
                }
                else
                {
                    CalcDgv(true);
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
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear datagirdview
            hoteiKensaRyokinMstDataSet.Clear();
            suishitsuShikenKoumokuMstDataSet.Clear();
            yoshiMstDataSet.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.Zeiritsu = zeiritsu;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Display data
            hoteiKensaRyokinMstDataSet.Merge(alOutput.HoteiKensaListKbn0DT);

            suishitsuKensaListDataGridView.Columns["SelectCol"].DisplayIndex = 0;
            suishitsuShikenKoumokuMstDataSet.Merge(alOutput.SuishitsuKensaListDT);
            
            yoshiMstDataSet.Merge(alOutput.KingakuShisanYoshiListDT);

            kaiinRadioButton_CheckedChanged(null, null);
        }
        #endregion

        #region ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            string colName = yoshiListDataGridView.Columns[yoshiListDataGridView.CurrentCell.ColumnIndex].Name;

            if (colName == "BaraCntCol" || colName == "SetCntCol")
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
        #endregion                
        
        #region CalcDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CalcDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  DatNT　   v1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CalcDgv(bool kbn)
        {
            if (suishitsuKensaListDataGridView.RowCount > 0)
            {
                foreach (DataGridViewRow row in suishitsuKensaListDataGridView.Rows)
                {
                    decimal kensaRyokin = (row.Cells["KensaRyokinCol"].Value != null && !string.IsNullOrEmpty(row.Cells["KensaRyokinCol"].Value.ToString())) ? Convert.ToDecimal(row.Cells["KensaRyokinCol"].Value) : 0;

                    decimal hiKaiinRyokin = (row.Cells["hiKaiinRyokinCol"].Value != null && !string.IsNullOrEmpty(row.Cells["hiKaiinRyokinCol"].Value.ToString())) ? Convert.ToDecimal(row.Cells["hiKaiinRyokinCol"].Value) : 0;

                    decimal syohizei = 0;

                    if (kbn)
                    {
                        row.Cells["syohizeiCol"].Value = Decimal.Truncate(kensaRyokin * zeiritsu);

                        syohizei = (row.Cells["syohizeiCol"].Value != null && !string.IsNullOrEmpty(row.Cells["syohizeiCol"].Value.ToString())) ? Convert.ToDecimal(row.Cells["syohizeiCol"].Value) : 0;

                        row.Cells["zeikomiCol"].Value = kensaRyokin + syohizei;
                    }
                    else
                    {
                        row.Cells["syohizeiCol"].Value = Decimal.Truncate(hiKaiinRyokin * zeiritsu);

                        syohizei = (row.Cells["syohizeiCol"].Value != null && !string.IsNullOrEmpty(row.Cells["syohizeiCol"].Value.ToString())) ? Convert.ToDecimal(row.Cells["syohizeiCol"].Value) : 0;

                        row.Cells["zeikomiCol"].Value = hiKaiinRyokin + syohizei;
                    }
                }
            }

            if (yoshiListDataGridView.RowCount > 0)
            {
                foreach (DataGridViewRow row in yoshiListDataGridView.Rows)
                {
                    decimal kaiinTanka = (row.Cells["KaiinTankaCol"].Value != null && !string.IsNullOrEmpty(row.Cells["KaiinTankaCol"].ToString())) ? Convert.ToDecimal(row.Cells["KaiinTankaCol"].Value) : 0;

                    decimal hiKaiinTanka = (row.Cells["HiKaiinTankaCol"].Value != null && !string.IsNullOrEmpty(row.Cells["HiKaiinTankaCol"].ToString())) ? Convert.ToDecimal(row.Cells["HiKaiinTankaCol"].Value) : 0;

                    decimal number = (row.Cells["BaraCntCol"].Value != null && !string.IsNullOrEmpty(row.Cells["BaraCntCol"].Value.ToString())) ? Convert.ToDecimal(row.Cells["BaraCntCol"].Value) : 0;

                    // 販売価格
                    if (row.Cells["BaraCntCol"].Value != null && !string.IsNullOrEmpty(row.Cells["BaraCntCol"].Value.ToString()))
                    {
                        if (kbn)
                        {
                            row.Cells["hanbaiKakakuCol"].Value = kaiinTanka * number;
                        }
                        else
                        {
                            row.Cells["hanbaiKakakuCol"].Value = hiKaiinTanka * number;
                        }

                        decimal hanbaiKakaku = !string.IsNullOrEmpty(row.Cells["hanbaiKakakuCol"].Value.ToString()) ? Convert.ToDecimal(row.Cells["hanbaiKakakuCol"].Value) : 0;

                        // 消費税
                        if (row.Cells["kazeiFlgCol"].Value.ToString() == "1")
                        {
                            if (hanbaiKakaku == 0)
                            {
                                row.Cells[ShohizeiCol.Name].Value = 0;
                            }
                            else
                            {
                                row.Cells[ShohizeiCol.Name].Value = Decimal.Truncate(hanbaiKakaku * zeiritsu);
                            }
                        }
                        else
                        {
                            row.Cells[ShohizeiCol.Name].Value = 0;
                        }

                        decimal shohizei = !string.IsNullOrEmpty(row.Cells[ShohizeiCol.Name].Value.ToString()) ? Convert.ToDecimal(row.Cells[ShohizeiCol.Name].Value) : 0;

                        // 販売金額
                        if ((hanbaiKakaku + shohizei) == 0)
                        {
                            row.Cells["hanbaiKingakuCol"].Value = 0;
                        }
                        else
                        {
                            row.Cells["hanbaiKingakuCol"].Value = hanbaiKakaku + shohizei;
                        }
                    }
                    else
                    {
                        row.Cells[hanbaiKakakuCol.Name].Value = string.Empty;
                        row.Cells[ShohizeiCol.Name].Value = string.Empty;
                        row.Cells[hanbaiKingakuCol.Name].Value = string.Empty;
                    }
                }
            }
        }
        #endregion
        
        #endregion

    }
    #endregion
}
