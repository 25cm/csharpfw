using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Master.GyoshaMstList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Master
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GyoshaMstListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GyoshaMstListForm : FukjBaseForm
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

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GyoshaMstListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GyoshaMstListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX    新規作成
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
                    this.gyoshaListPanel,
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

        #region GyoshaMstListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GyoshaMstListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaMstListForm_Load(object sender, EventArgs e)
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

                // 画面を終了（前画面に戻る）
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
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(DataCheck()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, DataCheck());
                    return;
                }

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
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstShosaiForm frm = new GyoshaMstShosaiForm();
                Program.mForm.MoveNext(frm, FormEnd);
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
        /// 2014/06/30　HuyTX    新規作成
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
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gyoshaListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                GyoshaMstShosaiForm frm = new GyoshaMstShosaiForm(gyoshaListDataGridView.CurrentRow.Cells[0].Value.ToString());
                Program.mForm.MoveNext(frm, FormEnd);

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
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gyoshaListDataGridView.RowCount == 0) { return; }

                //DataGridViewのデータをExcelへ出力する
                string outputFilename = "業者マスタ一覧";
                Common.Common.FlushGridviewDataToExcel(gyoshaListDataGridView, outputFilename);
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

        #region gyoshaListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex == -1) { return; }

                GyoshaMstShosaiForm frm = new GyoshaMstShosaiForm(gyoshaListDataGridView.SelectedRows[0].Cells["GyoshaCdCol"].Value.ToString());
                Program.mForm.MoveNext(frm, FormEnd);

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
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            //業者コード（開始）
            gyoshaCdFromTextBox.Text = string.Empty;

            //業者コード（終了）
            gyoshaCdToTextBox.Text = string.Empty;

            //業者名称
            gyoshaNmTextBox.Text = string.Empty;

            //業者カナ名
            gyoshaKanaTextBox.Text = string.Empty;
        }
        #endregion

        #region GyoshaMstListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GyoshaMstListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GyoshaMstListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.Focus();
                        torokuButton.PerformClick();
                        break;

                    case Keys.F2:
                        shosaiButton.Focus();
                        shosaiButton.PerformClick();
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

        #region gyoshaCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text))
                {
                    gyoshaCdFromTextBox.Text = gyoshaCdFromTextBox.Text.PadLeft(4, '0');
                    gyoshaCdToTextBox.Text = gyoshaCdFromTextBox.Text;
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

        #region gyoshaCdToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　DatNT    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
                {
                    gyoshaCdToTextBox.Text = gyoshaCdToTextBox.Text.PadLeft(4, '0');
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

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            gyoshaListDataGridView.DataSource = null;
            gyoshaListDataGridView.Rows.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

            GyoshaMstSearchCond gyoshaMst = new GyoshaMstSearchCond();
            gyoshaMst.GyoshaCdFrom = gyoshaCdFromTextBox.Text.Trim();
            gyoshaMst.GyoshaCdTo = gyoshaCdToTextBox.Text.Trim();
            gyoshaMst.GyoshaNm = gyoshaNmTextBox.Text.Trim();
            gyoshaMst.GyoshaKana = gyoshaKanaTextBox.Text.Trim();

            alInput.GyoshaMstSearchCond = gyoshaMst;

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.GyoshaMstKensakuDT == null || alOutput.GyoshaMstKensakuDT.Count == 0)
            {
                gyoshaListCountLabel.Text = "0件";
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                gyoshaListCountLabel.Text = alOutput.GyoshaMstKensakuDT.Count + "件";
                gyoshaListDataGridView.DataSource = alOutput.GyoshaMstKensakuDT;
            }

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
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.gyoshaListPanel.Top;
            this._defaultListPanelHeight = this.gyoshaListPanel.Height;

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.GyoshaMstSearchCond = new GyoshaMstSearchCond();
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //検索結果件数
            gyoshaListCountLabel.Text = alOutput.GyoshaMstKensakuDT.Count + "件";

            //set data for display gridview
            gyoshaListDataGridView.DataSource = alOutput.GyoshaMstKensakuDT;

        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <returns>True/False</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            //業者コード（開始）(1)
            if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && gyoshaCdFromTextBox.Text.Length != 4)
            {
                errMsg.AppendLine("業者コード（開始）は4桁で入力して下さい。");
            }

            //業者コード（終了）(2)
            if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text) && gyoshaCdToTextBox.Text.Length != 4)
            {
                errMsg.AppendLine("業者コード（終了）は4桁で入力して下さい。");
            }

            if (string.IsNullOrEmpty(errMsg.ToString()) && !string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
            {
                if (Convert.ToInt32(gyoshaCdFromTextBox.Text) > Convert.ToInt32(gyoshaCdToTextBox.Text))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
                }
            }

            //業者名称(3)
            if (gyoshaNmTextBox.Text.Trim().Length > 40)
            {
                errMsg.AppendLine("業者名称は40文字以下で入力して下さい。");
            }

            //業者カナ名(4)
            if (gyoshaKanaTextBox.Text.Trim().Length > 40)
            {
                errMsg.AppendLine("業者カナ名は40文字以下で入力して下さい。");
            }

            return errMsg.ToString();
        }
        #endregion

        #region gyoshaListDataGridView_CellFormatting
        // ADD 20140728 START ZynasSZou
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： 業者マスタ一覧のチェックボックス表示変換
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　宗 　　　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // 対象項目判定
            if (dgv.Columns[e.ColumnIndex].Name == "KanpuUmuFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "Jo7KensaIraiIchiranHakkoFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "HaigyoFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "DataWatashiFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "Jo5DataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "Jo7DataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "Jo11SuishitsuDataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "Jo11GaikanDataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "KihonDataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "SuishitsuDataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "ShokenDataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "GaikanDataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "ShoruiDataFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "ZenEigyoKuikiFlgCol"
                || dgv.Columns[e.ColumnIndex].Name == "SeikyuBunriFlgCol"
                )
            {
                // 未変換項目のみ表示変換
                if (e.Value.ToString() != "True" && e.Value.ToString() != "False")
                {
                    e.Value = (e.Value.ToString() == "1") ? true : false;
                }
            }
        }
        // ADD 20140728 END ZynasSZou
        #endregion

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
            // 子画面が正常終了した場合
            if (childForm.DialogResult == DialogResult.OK)
            {
                kensakuButton.PerformClick();
            }
        }
        #endregion

        #endregion

    }

    #endregion

}
