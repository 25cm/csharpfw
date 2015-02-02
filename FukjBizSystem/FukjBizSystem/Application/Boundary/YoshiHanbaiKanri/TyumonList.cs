using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.TyumonList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.Keiri;
using FukjBizSystem.Application.Boundary.Others;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TyumonListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class TyumonListForm : FukjBaseForm
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
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TyumonListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TyumonListForm()
        {
            InitializeComponent();
            //ラベル透過処理
            this.label5.BackColor = Color.Transparent;
            this.label5.Parent = this.panel1;
            this.label5.Location -= (Size)this.panel1.Location;

            tyumonListDataGridView.DefaultCellStyle.Font = new Font(tyumonListDataGridView.Font.Name, 16);
            tyumonListDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(tyumonListDataGridView.Font.Name, 16);
            tyumonListDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }
        #endregion

        #region イベント

        #region TyumonListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TyumonListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TyumonListForm_Load(object sender, EventArgs e)
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
        /// 2014/07/23　HuyTX    新規作成
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

                Common.Common.SwitchSearchPanelTouch(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.tyumonListPanel,
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
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                gyosyaCdTextBox.Text = string.Empty;
                gyosyaNmTextBox.Text = string.Empty;
                tyumonNoFromTextBox.Text = string.Empty;
                tyumonNoToTextBox.Text = string.Empty;
                tyumonDtFromDateTimePicker.Value = _currentDateTime.AddMonths(-1);
                tyumonDtToDateTimePicker.Value = _currentDateTime;

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
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidInput()) return;

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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                TyumonShosaiForm frm = new TyumonShosaiForm();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    kensakuButton.PerformClick();
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

        #region shosaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shosaiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (tyumonListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                TyumonShosaiForm frm = new TyumonShosaiForm(tyumonListDataGridView.CurrentRow.Cells[TyumonNoCol.Name].Value.ToString());
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    kensakuButton.PerformClick();
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
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (tyumonListDataGridView.RowCount == 0) return;

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "注文一覧";
                Common.Common.FlushGridviewDataToExcel(tyumonListDataGridView, outputFilename);
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

        #region ryosyuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// 2014/09/23　HuyTX    V1.02
        /// 2014/09/23　HuyTX    V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (tyumonListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                string yoshiHanbaiChumonNo = tyumonListDataGridView.CurrentRow.Cells[TyumonNoCol.Name].Value.ToString();
                string gyoshaCd = Convert.ToString(tyumonListDataGridView.CurrentRow.Cells[GyoshaCdCol.Name].Value);
                // Get RyoshushoPrint table by yoshiHanbaiChumonNo
                IRyosyuBtnClickALInput alInput = new RyosyuBtnClickALInput();
                alInput.YoshiHanbaiChumonNo = yoshiHanbaiChumonNo;
                IRyosyuBtnClickALOutput alOutput = new RyosyuBtnClickApplicationLogic().Execute(alInput);

                //transition 006-022
                RyoshushoPrintForm.RyoshushoPrintData rpData = new RyoshushoPrintForm.RyoshushoPrintData();
                rpData.HakkoNo = yoshiHanbaiChumonNo;
                rpData.GyoshaCd = gyoshaCd;
                rpData.ShouhizeiKbn = RyoshushoPrintForm.ShouhizeiKbn.Sotozei;
                rpData.RyoshuShoKbn = RyoshushoPrintForm.RyoshuShoKbn.GenkinNyukin;
                //ryoshushoPrint.YoshiHanbaiChumonNo = yoshiHanbaiChumonNo;
                rpData.RyushushoPrintDataTable = alOutput.RyushushoPrintDataTable;
                RyoshushoPrintForm frm = new RyoshushoPrintForm(rpData, true);

                Program.mForm.MoveNext(frm);

                if (Program.tyumonMenuFrm != null)
                {
                    Program.tyumonMenuFrm.Close();
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

        #region atenaButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： atenaButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// 2014/09/23　HuyTX    V1.02
        /// 2014/09/23　HuyTX    V1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void atenaButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //transition 008-003
                TuckSealListForm frm = new TuckSealListForm(true);
                Program.mForm.MoveNext(frm);
                //frm.ShowDialog();
                if (Program.tyumonMenuFrm != null)
                {
                    Program.tyumonMenuFrm.Close();
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
        /// 2014/07/23　HuyTX    新規作成
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

                if (Program.tyumonMenuFrm == null)
                {
                    YoshiMenuForm frm = new YoshiMenuForm();
                    Program.mForm.MoveNext(frm);
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

        #region gyosyaCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(gyosyaCdTextBox.Text.Trim()))
                {
                    gyosyaNmTextBox.Text = string.Empty;
                    return;
                }
                else
                {
                    gyosyaCdTextBox.Text = gyosyaCdTextBox.Text.Trim().PadLeft(4, '0');
                }

                Common.Common.SetGyoshaNmByCd(gyosyaCdTextBox.Text.Trim(), gyosyaCdTextBox, gyosyaNmTextBox);

                if (string.IsNullOrEmpty(gyosyaNmTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "業者データが存在しません。");
                    gyosyaCdTextBox.Focus();
                    return;
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

        #region gyosyaSrhButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaSrhButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaSrhButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm gyoshaFrm = new GyoshaMstSearchForm();

                if (gyoshaFrm.ShowDialog() == DialogResult.OK)
                {
                    if (gyoshaFrm._selectedRow == null) return;

                    gyosyaCdTextBox.Text = gyoshaFrm._selectedRow.GyoshaCd;
                    gyosyaNmTextBox.Text = gyoshaFrm._selectedRow.GyoshaNm;

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

        #region tyumonListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tyumonListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tyumonListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) return;

                TyumonShosaiForm frm = new TyumonShosaiForm(tyumonListDataGridView.CurrentRow.Cells[TyumonNoCol.Name].Value.ToString());
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    kensakuButton.PerformClick();
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

        #region TyumonListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TyumonListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TyumonListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        torokuButton.PerformClick();
                        break;

                    case Keys.F2:
                        shosaiButton.PerformClick();
                        break;

                    case Keys.F3:
                        outputButton.PerformClick();
                        break;

                    case Keys.F4:
                        ryosyuButton.PerformClick();
                        break;

                    case Keys.F6:
                        atenaButton.PerformClick();
                        break;

                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #region tyumonNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tyumonNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tyumonNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if(string.IsNullOrEmpty(tyumonNoFromTextBox.Text.Trim())) return;

                tyumonNoToTextBox.Text = tyumonNoFromTextBox.Text;
             
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

        #region tyumonDtFromDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tyumonDtFromDateTimePicker_ValueChanged
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
        private void tyumonDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                tyumonDtToDateTimePicker.Value = tyumonDtFromDateTimePicker.Value;
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
        /// 2014/07/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.tyumonListPanel.Top;
            this._defaultListPanelHeight = this.tyumonListPanel.Height;

            tyumonDtFromDateTimePicker.Value = _currentDateTime.AddMonths(-1);
            tyumonDtToDateTimePicker.Value = _currentDateTime;

            string tyumonDtFrom = tyumonDtFromDateTimePicker.Value.ToString("yyyy-MM-dd");
            string tyumonDtTo = tyumonDtToDateTimePicker.Value.ToString("yyyy-MM-dd");
            

            IFormLoadALInput alInput = new FormLoadALInput();

            alInput.YoshiHanbaiDtFrom = tyumonDtFrom;
            alInput.YoshiHanbaiDtTo = tyumonDtTo;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //検索結果件数
            tyumonListCountLabel.Text = alOutput.YoshiHanbaiHdrTblKensakuDT.Count + "件";

            //set data for display gridview
            tyumonListDataGridView.DataSource = alOutput.YoshiHanbaiHdrTblKensakuDT;

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
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            tyumonListDataGridView.DataSource = null;

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            alInput.GyoshaCd = gyosyaCdTextBox.Text.Trim();
            alInput.YoshiHanbaiChumonNoFrom = tyumonNoFromTextBox.Text.Trim();
            alInput.YoshiHanbaiChumonNoTo = tyumonNoToTextBox.Text.Trim();
            alInput.YoshiHanbaiDtFrom = tyumonDtFromDateTimePicker.Value.ToString("yyyy-MM-dd");
            alInput.YoshiHanbaiDtTo = tyumonDtToDateTimePicker.Value.ToString("yyyy-MM-dd");

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            tyumonListCountLabel.Text = alOutput.YoshiHanbaiHdrTblKensakuDT.Count + "件";

            if (alOutput.YoshiHanbaiHdrTblKensakuDT.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                return;
            }

            //set data for display gridview
            tyumonListDataGridView.DataSource = alOutput.YoshiHanbaiHdrTblKensakuDT;

        }
        #endregion

        #region IsValidInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidInput()
        {
            StringBuilder errMsg = new StringBuilder();

            #region UnitCheck

            //注文番号（開始）
            if (!string.IsNullOrEmpty(tyumonNoFromTextBox.Text.Trim()) && tyumonNoFromTextBox.Text.Trim().Length != 10)
            {
                errMsg.AppendLine("注文番号（開始）は10桁で入力して下さい。");
            }

            //注文番号（終了）
            if (!string.IsNullOrEmpty(tyumonNoToTextBox.Text.Trim()) && tyumonNoToTextBox.Text.Trim().Length != 10)
            {
                errMsg.AppendLine("注文番号（終了）は10桁で入力して下さい。");
            }

            #endregion

            #region RelationCheck

            //注文番号（開始＆終了）
            if (string.IsNullOrEmpty(errMsg.ToString()) && !string.IsNullOrEmpty(tyumonNoFromTextBox.Text.Trim())
                && !string.IsNullOrEmpty(tyumonNoToTextBox.Text.Trim())
                && Convert.ToDouble(tyumonNoFromTextBox.Text.Trim()) > Convert.ToDouble(tyumonNoToTextBox.Text.Trim()))
            {
                errMsg.AppendLine("範囲指定が正しくありません。注文番号の大小関係を確認してください。");
            }

            //販売日付（開始＆終了）
            if (tyumonDtFromDateTimePicker.Value.Date > tyumonDtToDateTimePicker.Value.Date)
            {
                errMsg.AppendLine("範囲指定が正しくありません。販売日付の大小関係を確認してください。");
            }

            #endregion

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
