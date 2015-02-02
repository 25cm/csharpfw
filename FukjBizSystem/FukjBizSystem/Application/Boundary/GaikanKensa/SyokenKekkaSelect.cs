using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.SyokenKekkaSelect;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyokenKekkaSelectForm
    /// <summary>
    /// 検査結果所見選択ダイアログ
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31  AnhNV        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SyokenKekkaSelectForm : FukjBaseForm
    {
        #region ShokenResult
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： ShokenResult
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public class ShokenResult
        {
            /// <summary>
            /// 選択された所見情報
            /// </summary>
            public ShokenMstDataSet.ShokenKekkaSelectRow ShokenRow { get; set; }

            /// <summary>
            /// <summary>
            /// 選択された補足情報
            /// </summary>
            public ShokenMstDataSet.ShokenKekkaSelectDataTable HosokuDT { get; set; }

            /// 挿入位置
            /// </summary>
            public int SonyuIchiNum { get; set; }
        }
        #endregion

        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum Mode
        {
            Shoken,         // ShokenKbn + ShokenShitekiKbn
            ShokenShiteki,  // ShokenShitekiKbn only
        }

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public Mode _mode;

        /// <summary>
        /// ShokenResult
        /// </summary>
        public ShokenResult _shokenResult;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Form loaded OK?
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 所見区分
        /// </summary>
        private string _shokenKbn;

        /// <summary>
        /// 指摘区分(1:外観検査/2:水質検査/3:書類検査)
        /// </summary>
        private string _shokenShitekiKbn;

        // 所見タイプ(外観、水質、書類)
        ShokenUtility.SelectType shokenSelectType;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SyokenKekkaSelectForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SyokenKekkaSelectForm()
        {
            InitializeComponent();
            SetStdControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SyokenKekkaSelectForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="mode"></param>
        /// <param name="shokenKbn"></param>
        /// <param name="shokenShitekiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SyokenKekkaSelectForm(Mode mode, string shokenKbn, string shokenShitekiKbn)
        {
            InitializeComponent();
            SetStdControlDomain();

            this._mode = mode;
            this._shokenKbn = shokenKbn;

            this._shokenShitekiKbn = shokenShitekiKbn;

            if (_shokenShitekiKbn == "1")
            {
                // 外観
                shokenSelectType = ShokenUtility.SelectType.GaikanKensa;
            }
            else if (_shokenShitekiKbn == "2")
            {
                // 水質
                shokenSelectType = ShokenUtility.SelectType.SuishitsuKensa;
            }
            else
            {
                // 書類
                shokenSelectType = ShokenUtility.SelectType.ShoruiKensa;
            }
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SyokenKekkaSelectForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="shokenShitekiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SyokenKekkaSelectForm(Mode mode, string shokenShitekiKbn)
        {
            InitializeComponent();
            SetStdControlDomain();

            this._mode = mode;
            this._shokenShitekiKbn = shokenShitekiKbn;

            if (_shokenShitekiKbn == "1")
            {
                // 外観
                shokenSelectType = ShokenUtility.SelectType.GaikanKensa;
            }
            else if (_shokenShitekiKbn == "2")
            {
                // 水質
                shokenSelectType = ShokenUtility.SelectType.SuishitsuKensa;
            }
            else
            {
                // 書類
                shokenSelectType = ShokenUtility.SelectType.ShoruiKensa;
            }
        }
        #endregion

        #region イベント

        #region SyokenKekkaSelectForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SyokenKekkaSelectForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SyokenKekkaSelectForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default value
                DoFormLoad();

                // Form is loaded successfully
                this._isLoad = true;
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

        #region checkItemComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： checkItemComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void checkItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not fire this event while the form is loading
                if (!_isLoad) return;

                // Reset the dgv
                syokenDataGridView.DataSource = null;
                syokenDataGridView.Rows.Clear();

                ICheckItemComboBoxSelectedIndexChangedALInput alInput = new CheckItemComboBoxSelectedIndexChangedALInput();
                alInput.ShokenKbn = Convert.ToString(checkItemComboBox.SelectedValue);
                // 対象検査ビットマスク取得（所見一覧）
                alInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Shoken, shokenSelectType);
                ICheckItemComboBoxSelectedIndexChangedALOutput alOutput = new CheckItemComboBoxSelectedIndexChangedApplicationLogic().Execute(alInput);

                // Source for dgv
                syokenDataGridView.DataSource = alOutput.ShokenKekkaSelectDataTable;
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
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ダイアログを閉じる
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

        #region selectButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： selectButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void selectButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No record in dgv
                if (syokenDataGridView.Rows.Count == 0) return;

                // 単項目チェック
                if (!UnitCheck()) return;

                _shokenResult = new ShokenResult();
                // 選択した所見情報
                _shokenResult.ShokenRow = (ShokenMstDataSet.ShokenKekkaSelectRow)((DataRowView)syokenDataGridView.CurrentRow.DataBoundItem).Row;

                // 選択した補足情報
                _shokenResult.HosokuDT = new ShokenMstDataSet.ShokenKekkaSelectDataTable();
                for (int i = 0; i < hosokuDataGridView.Rows.Count; i++)
                {
                    if (hosokuDataGridView[TuikaFlgCol.Index, i].Value != System.DBNull.Value && hosokuDataGridView[TuikaFlgCol.Index, i].Value != null && (bool)hosokuDataGridView[TuikaFlgCol.Index, i].Value)
                    {
                        ShokenMstDataSet.ShokenKekkaSelectRow impRow = (ShokenMstDataSet.ShokenKekkaSelectRow)((DataRowView)hosokuDataGridView.Rows[i].DataBoundItem).Row;
                        _shokenResult.HosokuDT.ImportRow(impRow);
                    }
                }
                _shokenResult.SonyuIchiNum = Convert.ToInt32(sonyuIchiNumTextBox.Text);

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

        #region syokenDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syokenDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syokenDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No record in dgv
                if (syokenDataGridView.Rows.Count == 0) return;

                // Avoid user click to header row
                if (e.RowIndex == -1) return;

                selectButton.PerformClick();
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

        #region SyokenKekkaSelectForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SyokenKekkaSelectForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SyokenKekkaSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        selectButton.Focus();
                        selectButton.PerformClick();
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

        #region syokenDataGridView_CellClick
        // 2014.12.16 toyoda Delete Start
        //////////////////////////////////////////////////////////////////////////////
        ////  イベント名 ： syokenDataGridView_CellClick
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/12/15　小松　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void syokenDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        if (e.RowIndex == -1)
        //        {
        //            return;
        //        }
        //        // 所見区分
        //        string shokenKbn = syokenDataGridView[syokenKbnColumn.Index, e.RowIndex].Value.ToString();

        //        // 補足情報取得
        //        ICheckItemComboBoxSelectedIndexChangedALInput alInput = new CheckItemComboBoxSelectedIndexChangedALInput();
        //        alInput.ShokenKbn = "0";
        //        // 対象検査ビットマスク取得（補足一覧）
        //        alInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Hosokubun, shokenSelectType);
        //        ICheckItemComboBoxSelectedIndexChangedALOutput alOutput = new CheckItemComboBoxSelectedIndexChangedApplicationLogic().Execute(alInput);

        //        // 補足一覧にバインド
        //        hosokuDataGridView.DataSource = alOutput.ShokenKekkaSelectDataTable;
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        // 2014.12.16 toyoda Delete End
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
        /// 2014/10/31  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            // 0: ALL
            if (_mode == Mode.ShokenShiteki)
            {
                alInput.ShokenKbn = "0";
            }
            else
            {
                alInput.ShokenKbn = _shokenKbn;
            }
            // 対象検査ビットマスク取得（所見一覧）
            alInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Shoken, shokenSelectType);
            alInput.Mode = _mode;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            if (_mode == Mode.Shoken)
            {
                ShokenMstDataSet.ShokenCheckItemRow[] dr = (ShokenMstDataSet.ShokenCheckItemRow[])alOutput.ShokenCheckItemDataTable.Select(string.Format("Code='{0}'", _shokenKbn));

                // 所見区分(1)
                //checkItemCdTextBox.Text = _shokenKbn;
                checkItemCdTextBox.Text = dr.Length > 0 && _shokenKbn != "0" ? dr[0].Code : string.Empty;
                checkItemCdTextBox.Visible = true;

                // 所見区分名チェック項目名(2)
                //ShokenMstDataSet.ShokenCheckItemRow[] dr = (ShokenMstDataSet.ShokenCheckItemRow[])alOutput.ShokenCheckItemDataTable.Select(string.Format("Code='{0}'", _shokenKbn));
                checkItemNmTextBox.Text = dr.Length > 0 && _shokenKbn != "0" ? dr[0].Name : string.Empty;
                checkItemNmTextBox.Visible = true;

                // 所見区分選択(3) 
                checkItemComboBox.Visible = false;
            }
            else
            {
                // Hide 所見区分(1), 所見区分名チェック項目名(2)
                checkItemCdTextBox.Visible = false;
                checkItemNmTextBox.Visible = false;

                // 所見区分選択(3)
                Utility.Utility.SetComboBoxList(checkItemComboBox, alOutput.ShokenCheckItemDataTable, "Name", "Code", false);
                checkItemComboBox.Location = new Point(100, 12);
                checkItemComboBox.Visible = true;
                checkItemComboBox.SelectedValue = "0"; // 0: ALL
            }

            // 2014.12.16 toyoda Add 補足追加 Start
            // 補足情報取得
            ICheckItemComboBoxSelectedIndexChangedALInput alhosokuInput = new CheckItemComboBoxSelectedIndexChangedALInput();
            alhosokuInput.ShokenKbn = "0";
            // 対象検査ビットマスク取得（補足一覧）
            alhosokuInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Hosokubun, shokenSelectType);
            ICheckItemComboBoxSelectedIndexChangedALOutput alhosokuOutput = new CheckItemComboBoxSelectedIndexChangedApplicationLogic().Execute(alhosokuInput);
            // 補足一覧にバインド
            hosokuDataGridView.DataSource = alhosokuOutput.ShokenKekkaSelectDataTable;
            // 2014.12.16 toyoda Add 補足追加 End

            // 所見一覧データグリッドビュー
            syokenDataGridView.DataSource = alOutput.ShokenKekkaSelectDataTable;

            // Control the visible/invisible of items on header
            //DisplayControl();
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
        /// 2014/10/31  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            syokenDataGridView.SetStdControlDomain(syokenKbnColumn.Index, ZControlDomain.ZT_STD_NAME, 3);
            syokenDataGridView.SetStdControlDomain(syokenCdColumn.Index, ZControlDomain.ZT_STD_NAME, 3);
            syokenDataGridView.SetStdControlDomain(syokenWdColumn.Index, ZControlDomain.ZT_STD_NAME, 160);
            syokenDataGridView.SetControlDomain(juyodoColumn.Index, ZControlDomain.ZT_STD_NAME);
            syokenDataGridView.SetControlDomain(handanColumn.Index, ZControlDomain.ZT_STD_NAME);
            syokenDataGridView.SetControlDomain(hanteiColumn.Index, ZControlDomain.ZT_STD_NAME);
            syokenDataGridView.SetControlDomain(bikoColumn.Index, ZControlDomain.ZT_STD_NAME);
        }
        #endregion

        #region UnitCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UnitCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            // 挿入位置(4)
            decimal sonyu = Convert.ToDecimal(string.IsNullOrEmpty(sonyuIchiNumTextBox.Text) ? "0" : sonyuIchiNumTextBox.Text);
            if (sonyu > 30 || sonyu < 1)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "挿入位置は 1から30の数値で入力して下さい。");
                return false;
            }

            return true;
        }
        #endregion

        #endregion
    }
    #endregion
}
