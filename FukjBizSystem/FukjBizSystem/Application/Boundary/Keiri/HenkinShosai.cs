using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.HenkinShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HenkinShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HenkinShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum Mode
        {
            Add, // キー入力待ち
            Update // 編集
        }

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public Mode _mode;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 入金No
        /// </summary>
        private string _nyukinNo;

        /// <summary>
        /// Source for dgv
        /// </summary>
        private HenkinTblDataSet.HenkinShosaiDataTable _dgvSource;

        /// <summary>
        /// Header data
        /// </summary>
        private HenkinTblDataSet.HekinShosaiHdrDataTable _headerTable;

        /// <summary>
        /// Update Flg
        /// </summary>
        private bool _updateSuccess = false;

        // 2014.12.28 toyoda Delete Start
        ///// <summary>
        ///// 入金テーブル
        ///// </summary>
        //private NyukinTblDataSet.NyukinTblDataTable _nyukinTable;

        ///// <summary>
        ///// 繰越金テーブル
        ///// </summary>
        //private KurikoshiKinTblDataSet.KurikoshiKinTblDataTable _kurikoshiTable;

        ///// <summary>
        ///// 検査依頼テーブル
        ///// </summary>
        //private KensaIraiTblDataSet.KensaIraiTblDataTable _kensaIraiTable;

        ///// <summary>
        ///// 前受金テーブル
        ///// </summary>
        //private MaeukekinTblDataSet.MaeukekinTblDataTable _maeukekinTable;
        // 2014.12.28 toyoda Delete End

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HenkinShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HenkinShosaiForm()
        {
            InitializeComponent();
            SetStdControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HenkinShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="nyukinNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HenkinShosaiForm(string nyukinNo)
        {
            InitializeComponent();
            SetStdControlDomain();

            this._nyukinNo = nyukinNo;
        }
        #endregion

        #region イベント

        #region HenkinShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HenkinShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HenkinShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default data
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

        #region HenkinShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HenkinShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HenkinShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F5:
                        kakuteiButton.Focus();
                        kakuteiButton.PerformClick();
                        break;
                    case Keys.F6:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F9:
                        henkinInputButton.Focus();
                        henkinInputButton.PerformClick();
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

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック
                if (string.IsNullOrEmpty(nyukinNoTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "入金Noが入力されていません。");
                    return;
                }

                // Execute search
                IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
                alInput.NyukinNo = nyukinNoTextBox.Text;
                IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);
                _dgvSource = alOutput.HenkinShosaiDataTable;
                _headerTable = alOutput.HekinShosaiHdrDataTable;

                // 2014.12.28 toyoda Delete Start
                //// Rakkan check tables
                //_nyukinTable = alOutput.NyukinTblDataTable;
                //_kurikoshiTable = alOutput.KurikoshiKinTblDataTable;
                //_kensaIraiTable = alOutput.KensaIraiTblDataTable;
                //_maeukekinTable = alOutput.MaeukekinTblDataTable;
                // 2014.12.28 toyoda Delete End

                // No record was found?
                if (_headerTable.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "入力された入金Noは存在しません。");
                    return;
                }

                // Change to update mode
                _mode = Mode.Update;
                ItemsControl();

                // Binding result source
                DisplayDefault(_dgvSource, _headerTable);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Reset all items to default
                ResetScreen();

                // Change to Add mode
                _mode = Mode.Add;
                ItemsControl();
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

        #region kakuteiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// 2014/12/21　kiyokuni　　 満額返済の場合は完済にする
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _updateSuccess = false;

                //// 今回返金額(21) is empty or zero
                //if (string.IsNullOrEmpty(henkinGakuTextBox.Text) || henkinGakuTextBox.Text == "0")
                //{
                //    MessageForm.Show2(MessageForm.DispModeType.Error, "今回返金額が入力されていません。");
                //    return;
                //}

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された内容で返金情報を更新します。よろしいですか？")
                    == DialogResult.Yes)
                {
                    IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                    alInput.SystemDt = Common.Common.GetCurrentTimestamp();
                    alInput.HeninsumiGaku = Convert.ToDecimal(string.IsNullOrEmpty(heninsumiGakuTextBox.Text) ? "0" : heninsumiGakuTextBox.Text);
                    //decimal henkinGaku;
                    //if (Decimal.TryParse(henkinGakuTextBox.Text, out henkinGaku))
                    //{
                    //    alInput.HenkinGaku = henkinGaku;
                    //}
                    if ((string.IsNullOrEmpty(heninZanGakuTextBox.Text) ? "0" : heninZanGakuTextBox.Text) == "0")
                    {
                        alInput.KansaiFlg = "1";
                    }
                    else
                    {
                        alInput.KansaiFlg = _headerTable[0].KansaiFlag;
                    }

                    alInput.NyukinGaku = Convert.ToDecimal(string.IsNullOrEmpty(nyukinGakuTextBox.Text) ? "0" : nyukinGakuTextBox.Text);
                    alInput.NyukinNo = nyukinNoTextBox.Text;
                    alInput.NyukinSyubetsu = _headerTable[0].NyukinSyubetsu;
                    alInput.DgvSource = _dgvSource;

                    // 2014.12.28 toyoda Delete Start
                    //// Rakkan check tables
                    //alInput.RakkanNyukinTblDataTable = _nyukinTable;
                    //alInput.RakkanKurikoshiKinTblDataTable = _kurikoshiTable;
                    //alInput.RakkanKensaIraiTblDataTable = _kensaIraiTable;
                    //alInput.RakkanMaeukekinTblDataTable = _maeukekinTable;
                    // 2014.12.28 toyoda Delete End

                    new KakuteiBtnClickApplicationLogic().Execute(alInput);

                    // Update completed?
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新処理が完了しました。");
                    // Clear screen
                    clearButton.PerformClick();

                    _updateSuccess = true;
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

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "更新処理が行われていない場合、入力した内容は全て破棄されます。\r\n返金入力を終了しますか？")
                    == DialogResult.Yes)
                {
                    this.DialogResult = _updateSuccess ? DialogResult.OK : DialogResult.None;

                    Program.mForm.MovePrev();
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

        #region henkinListDataGridView_CellContentClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkinListDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void henkinListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid user click to header row
                if (e.RowIndex == -1) return;
                // Handler for deleteBtn column only
                if (e.ColumnIndex != deleteButton.Index) return;

                // Delete target row
                HenkinTblDataSet.HenkinShosaiRow targetRow = (HenkinTblDataSet.HenkinShosaiRow)((DataRowView)henkinListDataGridView.CurrentRow.DataBoundItem).Row;

                // 削除チェック
                if (targetRow.KaikeiRendoFlag == "1")
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "会計済のため削除できません。");
                    return;
                }

                // Delete row and re-order dgv
                targetRow.Delete();

                if (e.RowIndex != henkinListDataGridView.RowCount)
                {
                    ReOrderDgv();
                }

                // Value of 返金済額(19) and 返金残合計額(24)
                SetGakuText();
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

        #region henkinInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkinInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void henkinInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 返金入力チェック
                if (!HenkinInputCheck()) return;

                int lastIdx = 0;

                // Last row in dgv
                lastIdx = henkinListDataGridView.RowCount > 0 ? Convert.ToInt32(henkinListDataGridView.Rows[henkinListDataGridView.RowCount - 1].Cells[renbanCol.Name].Value) : 0;
                
                // Create a new dgv row
                HenkinTblDataSet.HenkinShosaiRow newRow = _dgvSource.NewHenkinShosaiRow();
                // 連番(27)
                newRow.HenkinRenban = lastIdx + 1;
                // 返金日(28)
                newRow.HenkinDt = henkinDtTextBox.Value.ToString("yyyy/MM/dd");
                // 返金額(29)
                // カンマ処理対応
                //newRow.HenkinGaku = Convert.ToDecimal(henkinGakuTextBox.Text);
                decimal henkinGaku = 0;
                Decimal.TryParse(henkinGakuTextBox.Text.Trim().Replace(",", string.Empty), out henkinGaku);
                newRow.HenkinGaku = henkinGaku;
                // 会計済(30)
                newRow.KaikeiRendoFlag = "0";

                // Committed
                _dgvSource.AddHenkinShosaiRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();
                
                // Binding new source to dgv
                henkinListDataGridView.DataSource = null;
                henkinListDataGridView.Rows.Clear();
                henkinListDataGridView.DataSource = _dgvSource;

                // Value of 返金済額(19) and 返金残合計額(24)
                SetGakuText();
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

        #region henkinGakuTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkinGakuTextBox_Leave
        /// <summary>
        /// 返金額入力域ロストフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/21　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void henkinGakuTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            try
            {
                if (!string.IsNullOrEmpty(henkinGakuTextBox.Text))
                {
                    // 今回返金額
                    decimal henkinGaku = 0;
                    Decimal.TryParse(henkinGakuTextBox.Text.Trim().Replace(",", string.Empty), out henkinGaku);
                    // カンマ処理
                    henkinGakuTextBox.Text = henkinGaku.ToString("#,0");
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
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
        /// 2014/11/05  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.NyukinNo = _nyukinNo;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Add mode
            if (string.IsNullOrEmpty(this._nyukinNo))
            {
                _mode = Mode.Add;

                // 返金日(22)
                henkinDtTextBox.Value = Common.Common.GetCurrentTimestamp();
            }
            else // Update mode
            {
                _dgvSource = alOutput.HenkinShosaiDataTable;
                _headerTable = alOutput.HekinShosaiHdrDataTable;

                // Default items
                DisplayDefault(_dgvSource, _headerTable);

                // 2015.01.08 toyoda Modify Start 
                // 返金日(22)（初期ロード後のモードチェンジ時は初期ロードの値を引き継ぐ）
                henkinDtTextBox.Value = Common.Common.GetCurrentTimestamp();
                // 2015.01.08 toyoda Modify End

                _mode = Mode.Update;
            }

            // Control the display of all items
            ItemsControl();
        }
        #endregion

        #region SetStdControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // Textboxes
            nyukinNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 11);
            shishoNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            gyoshaCdTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            gyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            settishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            nyukinshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            nyukinGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            nyukinHohoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            heninsumiGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            nyukinDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            henkinGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            heninZanGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);

            // Datagridview
            henkinListDataGridView.SetStdControlDomain(renbanCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            henkinListDataGridView.SetStdControlDomain(henkinDtCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            henkinListDataGridView.SetStdControlDomain(henkinGakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
        }
        #endregion

        #region ItemsControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ItemsControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05  AnhNV　　    新規作成
        /// 2014/12/21  kiyokuni　　 完済チェック追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemsControl()
        {
            // 検索ボタン(2)
            kensakuButton.Enabled =
            // 今回返金額(21)
            henkinGakuTextBox.ReadOnly = _mode == Mode.Add ? true : false;
            // 入金No(1)
            nyukinNoTextBox.ReadOnly =
            // クリアボタン(3)
            clearButton.Enabled =
            // 返金日(22)
            henkinDtTextBox.Enabled =
            // 返金入力ボタン(23)
            henkinInputButton.Enabled =
            // 返金一覧(26)
            henkinListDataGridView.Enabled =
            // 完済チェックボックス
            kansaiCheckBox.Enabled =
            // 確定ボタン(35)
            kakuteiButton.Enabled = _mode == Mode.Add ? false : true;
        }
        #endregion

        #region DisplayDefault
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDefault
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvSource"></param>
        /// <param name="headerTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05  AnhNV　　    新規作成
        /// 2014/12/21  kiyokuni　　 返金可能額仕様変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault(HenkinTblDataSet.HenkinShosaiDataTable dgvSource, HenkinTblDataSet.HekinShosaiHdrDataTable headerTable)
        {
            // 入金No(1)
            nyukinNoTextBox.Text = headerTable[0].NyukinNo;
            // 支所(4)
            shishoNmTextBox.Text = headerTable[0].ShishoNm;
            // 入金者区分/業者(5)
            gyoshaRadioButton.Checked = headerTable[0].NyukinmotoKbn == "1" ? true : false;
            // 入金者区分/個人(6)
            kojinRadioButton.Checked = headerTable[0].NyukinmotoKbn == "2" ? true : false;

            if (headerTable[0].NyukinmotoKbn == "1")
            {
                // 業者コード(7)
                gyoshaCdTextBox.Text = headerTable[0].NyukinGyosyaCd;
                // 業者名(8)
                gyoshaNmTextBox.Text = headerTable[0].GyoshaNm;
            }

            // 設置者名(9)
            settishaNmTextBox.Text = headerTable[0].NyukinmotoKbn == "2" ? headerTable[0].JokasoSetchishaNm : string.Empty;
            // 入金者(10)
            nyukinshaNmTextBox.Text = headerTable[0].NyukinsyaNm;

            switch (headerTable[0].NyukinSyubetsu)
            {
                case "1":
                    seikyuRadioButton.Checked = true; // 入金種別/請求(11)
                    break;
                case "2":
                    maeukekinRadioButton.Checked = true; // 入金種別/前受金(12)
                    break;
                case "3":
                    yoshiHanbaiRadioButton.Checked = true; // 入金種別/用紙販売(請求外)(13)
                    break;
                case "4":
                    nenkaihiRadioButton.Checked = true; // 入金種別/年会費(請求外)(14)
                    break;
                case "5":
                    eiryoSyomeiRadioButton.Checked = true; // 入金種別/計量証明(請求外)(15)
                    break;
                case "6":
                    kensaTesuryoRadioButton.Checked = true; // 入金種別/検査手数料(請求外)(16)
                    break;
                default:
                    break;
            }

            // 返金可能額(17)
            if (headerTable[0].NyukinSyubetsu == "1")
            {
                nyukinGakuTextBox.Text = ((headerTable[0].IsNyukinGakuNull() ? 0 : headerTable[0].NyukinGaku) + (headerTable[0].IsHenkinGakuNull() ? 0 : headerTable[0].HenkinGaku)).ToString("N0");
            }
            else
            {
                nyukinGakuTextBox.Text = headerTable[0].IsNyukinGakuNull() ? string.Empty : headerTable[0].NyukinGaku.ToString("N0");
            }
            // 入金方法(18)
            nyukinHohoTextBox.Text = headerTable[0].ConstValue;
            // 返金済額(19)
            heninsumiGakuTextBox.Text = headerTable[0].IsHenkinGakuNull() ? string.Empty : headerTable[0].HenkinGaku.ToString("N0");
            // 入金日(20)
            nyukinDtTextBox.Text = headerTable[0].NyukinDt;
            // 返金残合計額(24)
            heninZanGakuTextBox.Text = (Convert.ToDecimal(string.IsNullOrEmpty(nyukinGakuTextBox.Text) ? "0" : nyukinGakuTextBox.Text)
                - Convert.ToDecimal(string.IsNullOrEmpty(heninsumiGakuTextBox.Text) ? "0" : heninsumiGakuTextBox.Text)).ToString("N0");

            // 完済(25)
            kansaiCheckBox.Checked = headerTable[0].KansaiFlag == "1" ? true : false;

            // 返金一覧グリッドビュー(26)
            henkinListDataGridView.DataSource = dgvSource;
        }
        #endregion

        #region ResetScreen
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ResetScreen
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05  AnhNV　　    新規作成
        /// 2014/12/21  小松        入金種別の初期値：請求、入金日：空白、返金日：当日
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ResetScreen()
        {
            // Current system date
            DateTime now = Common.Common.GetCurrentTimestamp();

            // 入金No(1)
            nyukinNoTextBox.Text = string.Empty;
            // 支所(4)
            shishoNmTextBox.Text = string.Empty;
            // 入金者区分/業者(5)
            gyoshaRadioButton.Checked = true;
            // 入金者区分/個人(6)
            kojinRadioButton.Checked = false;
            // 業者コード(7)
            gyoshaCdTextBox.Text = string.Empty;
            // 業者名(8)
            gyoshaNmTextBox.Text = string.Empty;
            // 設置者名(9)
            settishaNmTextBox.Text = string.Empty;
            // 入金者(10)
            nyukinshaNmTextBox.Text = string.Empty;
            // 入金種別/請求(11)
            //seikyuRadioButton.Checked = true; kensaTesuryoRadioButton.Checked = true;
            seikyuRadioButton.Checked = true;
            // 返金可能額(17)
            nyukinGakuTextBox.Text = string.Empty;
            // 入金方法(18)
            nyukinHohoTextBox.Text = string.Empty;
            // 返金済額(19)
            heninsumiGakuTextBox.Text = string.Empty;
            // 入金日(20)
            //nyukinDtTextBox.Text = now.ToString("yyyy/MM/dd");
            nyukinDtTextBox.Text = string.Empty;
            // 今回返金額(21)
            henkinGakuTextBox.Text = string.Empty;
            // 返金日(22)
            //henkinDtTextBox.Text = string.Empty;
            henkinDtTextBox.Text = now.ToString("yyyy/MM/dd");
            // 返金残合計額(24)
            heninZanGakuTextBox.Text = string.Empty;
            // 完済(25)
            kansaiCheckBox.Checked = false;

            // 返金一覧グリッドビュー(26)
            henkinListDataGridView.DataSource = null;
            henkinListDataGridView.Rows.Clear();
        }
        #endregion
        
        #region ReOrderDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ReOrderDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ReOrderDgv()
        {
            foreach (DataGridViewRow dgvr in henkinListDataGridView.Rows)
            {
                dgvr.Cells[renbanCol.Name].Value = dgvr.Index + 1;
            }
        }
        #endregion

        #region GetSumHenkinGaku
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSumHenkinGaku
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private decimal GetSumHenkinGaku()
        {
            // 返金済額
            decimal henkinGaku = 0;

            foreach (DataGridViewRow dgvr in henkinListDataGridView.Rows)
            {
                // Sum of 返金額(29)
                henkinGaku += Convert.ToDecimal(dgvr.Cells[henkinGakuCol.Name].Value == null ? "0" : dgvr.Cells[henkinGakuCol.Name].Value);
            }

            return henkinGaku;
        }
        #endregion

        #region SetGakuText
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetGakuText
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetGakuText()
        {
            // 返金済額
            decimal heninsumiGaku = GetSumHenkinGaku();
            // 返金済額(19)
            heninsumiGakuTextBox.Text = heninsumiGaku.ToString("N0");
            // 返金残合計額(24)
            heninZanGakuTextBox.Text = (Convert.ToDecimal(string.IsNullOrEmpty(nyukinGakuTextBox.Text) ? "0" : nyukinGakuTextBox.Text) - heninsumiGaku).ToString("N0");
        }
        #endregion

        #region HenkinInputCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： HenkinInputCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool HenkinInputCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 今回返金額(21)
            // カンマ処理対応
            //decimal henkinGaku;
            //Decimal.TryParse(henkinGakuTextBox.Text, out henkinGaku);
            decimal henkinGaku = 0;
            Decimal.TryParse(henkinGakuTextBox.Text.Trim().Replace(",", string.Empty), out henkinGaku);

            // 返金済額
            decimal heninsumiGaku = GetSumHenkinGaku() + henkinGaku;

            // 今回返金額(21) is empty or zero
            if (string.IsNullOrEmpty(henkinGakuTextBox.Text) || henkinGakuTextBox.Text == "0")
            {
                errMsg.AppendLine("今回返金額が入力されていません。");
            }

            // 返金額(29) > 返金可能額(17)
            if (heninsumiGaku > Convert.ToDecimal(string.IsNullOrEmpty(nyukinGakuTextBox.Text) ? "0" : nyukinGakuTextBox.Text))
            {
                errMsg.AppendLine("返金額が返金可能額をオーバーしています。");
            }

            // 完済(25) is ON
            if (kansaiCheckBox.Checked)
            {
                errMsg.AppendLine("完済フラグが立っているため、返金入力はできません。");
            }

            // An error occurred?
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
