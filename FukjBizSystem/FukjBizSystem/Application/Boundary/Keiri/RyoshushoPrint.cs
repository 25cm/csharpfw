using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.RyoshushoPrint;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.YoshiHanbaiKanri;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： RyoshushoPrintForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class RyoshushoPrintForm : FukjBaseForm
    {
        #region ShouhizeiKbn
        /// <summary>
        /// 消費税区分(13)/(14)/(15) radio buttons
        /// </summary>
        public enum ShouhizeiKbn
        {
            /// <summary>
            /// なし(15)
            /// </summary>
            Nashi,
            /// <summary>
            /// 内税(13)
            /// </summary>
            Uchizei,
            /// <summary>
            /// 外税(14)
            /// </summary>
            Sotozei,
        }
        #endregion

        #region RyoshuShoKbn
        /// <summary>
        /// 領収書区分(17)/(18)/(19) radio buttons
        /// </summary>
        public enum RyoshuShoKbn
        {
            /// <summary>
            /// 現金入金時(17)
            /// </summary>
            GenkinNyukin,
            /// <summary>
            /// 請求売上時(18)
            /// </summary>
            SeikyuUriage,
            /// <summary>
            /// 請求入金時(19)
            /// </summary>
            SeikyuNyukin
        }
        #endregion

        #region ScreenName
        /// <summary>
        /// Come from screen?
        /// </summary>
        //public enum ScreenName
        //{
        //    /// <summary>
        //    /// 会費入金入力 005-003
        //    /// </summary>
        //    KaiinNyukin,
        //    /// <summary>
        //    /// 現金入金 012-002
        //    /// </summary>
        //    GenkinNyukin
        //}
        #endregion

        #region RyoshushoPrintData
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： RyoshushoPrintData
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public class RyoshushoPrintData
        {
            /// <summary>
            /// 発行No(4)
            /// </summary>
            public string HakkoNo { get; set; }

            /// <summary>
            /// 業者コード(6)
            /// </summary>
            public string GyoshaCd { get; set; }

            /// <summary>
            /// 消費税区分(13)/(14)/(15) radio buttons
            /// </summary>
            public ShouhizeiKbn ShouhizeiKbn { get; set; }

            /// <summary>
            /// 領収書区分(17)/(18)/(19) radio buttons
            /// </summary>
            public RyoshuShoKbn RyoshuShoKbn { get; set; }

            ///// <summary>
            ///// Screen name goes here
            ///// </summary>
            //public ScreenName ScreenName { get; set; }

            /// <summary>
            /// DataGridView source 領収一覧グリッドビュー(20)
            /// </summary>
            public YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable RyushushoPrintDataTable { get; set; }
        }
        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Form loaded successfully?
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 税率
        /// </summary>
        private decimal _zeiritsu;

        /// <summary>
        /// isBackTouchPnl(back to touch panel 003-004)
        /// </summary>
        private bool _isBackTouchPnl = false;

        /// <summary>
        /// Current system date
        /// </summary>
        private DateTime _now;

        /// <summary>
        /// RyoshushoPrintData
        /// </summary>
        private RyoshushoPrintData _ryoshuData = null;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： RyoshushoPrintForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public RyoshushoPrintForm()
        {
            InitializeComponent();

            SetStdControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： RyoshushoPrintForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="ryoshuData">RyoshushoPrintData</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public RyoshushoPrintForm(RyoshushoPrintData ryoshuData)
        {
            InitializeComponent();

            this._ryoshuData = ryoshuData;

            SetStdControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： RyoshushoPrintForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="ryoshuData">RyoshushoPrintData</param>
        /// <param name="isBackTouchPnl"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public RyoshushoPrintForm(RyoshushoPrintData ryoshuData, bool isBackTouchPnl)
        {
            InitializeComponent();

            this._ryoshuData = ryoshuData;
            _isBackTouchPnl = isBackTouchPnl;

            SetStdControlDomain();
        }
        #endregion

        #region イベント

        #region RyoshushoPrintForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： RyoshushoPrintForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RyoshushoPrintForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Current system in db
                this._now = Common.Common.GetCurrentTimestamp();

                // Initial load
                DoFormLoad();

                // Loaded OK!
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

        #region RyoshushoPrintForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： RyoshushoPrintForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　AnhNV　　    新規作成
        /// 2014/12/21  小松        Fキーで対象ボタンへフォーカスを移動移す
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RyoshushoPrintForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        ryosyuPrintButton.Focus();
                        ryosyuPrintButton.PerformClick();
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

        #region gyosyaSrhButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyosyaSrhButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaSrhButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open gyoshaMst search form
                Common.GyoshaMstSearchForm frm = new Common.GyoshaMstSearchForm();
                frm.ShowDialog();

                // Avoid user close the form
                if (frm.DialogResult != DialogResult.OK) return;

                // No row was selected
                if (frm._selectedRow == null) return;

                // 業者コード(6)
                gyosyaCdTextBox.Text = frm._selectedRow.GyoshaCd;
                // 業者名称(7)
                gyosyaNmTextBox.Text = frm._selectedRow.GyoshaNm;
                // 住所(9)
                adrTextBox.Text = frm._selectedRow.GyoshaAdr;
                // 郵便番号(10)
                zipNoTextBox.Text = frm._selectedRow.GyoshaZipCd;
                // TEL(11)
                telTextBox.Text = frm._selectedRow.GyoshaTelNo;
                // FAX(12)
                faxTextBox.Text = frm._selectedRow.GyoshaFaxNo;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Set GyoshaMst info
                SetGyoshaInfoByGyoshaCd(gyosyaCdTextBox.Text);
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

        #region ryosyuPrintButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyuPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyuPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Confirmation!!!
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "領収書を印刷します。よろしいですか？") == DialogResult.Yes)
                {
                    IRyosyuPrintBtnClickALInput alInput = new RyosyuPrintBtnClickALInput();
                    MakeRyosyuPrintData(alInput);
                    new RyosyuPrintBtnClickApplicationLogic().Execute(alInput);
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

        #region hakkoDtDateTimePicker_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hakkoDtDateTimePicker_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hakkoDtDateTimePicker_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Get 税率
                _zeiritsu = Common.Common.GetSyohizei(hakkoDtDateTimePicker.Value.ToString("yyyyMMdd"));

                // 合計算出処理
                GoukeiSanshutsu();
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

        #region uchizeiRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uchizeiRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uchizeiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (uchizeiRadioButton.Checked)
                {
                    // 合計算出処理
                    GoukeiSanshutsu();
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

        #region sotozeiRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sotozeiRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void sotozeiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (sotozeiRadioButton.Checked)
                {
                    // 合計算出処理
                    GoukeiSanshutsu();
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

        #region nashiRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nashiRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nashiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (nashiRadioButton.Checked)
                {
                    // 合計算出処理
                    GoukeiSanshutsu();
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

        #region ryosyuListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyuListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyuListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Do not handle while form is initializing
                if (!_isLoad) return;

                switch (ryosyuListDataGridView.Columns[e.ColumnIndex].Name)
                {
                    case "suryoCol": // 数量(23)
                    case "syohizeiCol": // 消費税(25)
                    case "tankaCol": // 単価(26)
                    case "kingakuCol": // 金額(27)
                        // 合計算出処理
                        GoukeiSanshutsu();
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

        #region ryosyuListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyuListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyuListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Prevent from input non-integer value to datagridview cells
                switch (ryosyuListDataGridView.Columns[ryosyuListDataGridView.CurrentCell.ColumnIndex].Name)
                {
                    case "suryoCol": // 数量(23)
                    case "tankaCol": // 単価(26)
                    case "kingakuCol": // 金額(27)
                        e.Control.KeyPress += new KeyPressEventHandler(ryosyuListDataGridView_ControlKeyPress);
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

        #region ryosyuListDataGridView_CellEnter
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyuListDataGridView_CellEnter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyuListDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Prevent from input 2-bytes value to datagridview cells
                switch (ryosyuListDataGridView.Columns[ryosyuListDataGridView.CurrentCell.ColumnIndex].Name)
                {
                    case "suryoCol": // 数量(23)
                    case "tankaCol": // 単価(26)
                    case "kingakuCol": // 金額(27)
                        ryosyuListDataGridView.ImeMode = ImeMode.Disable;
                        break;
                    default:
                        ryosyuListDataGridView.ImeMode = ImeMode.On;
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

        #region ryosyuListDataGridView_CurrentCellDirtyStateChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyuListDataGridView_CurrentCellDirtyStateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyuListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Handle for 消費税(25) only
                if (ryosyuListDataGridView.Columns[ryosyuListDataGridView.CurrentCell.ColumnIndex].Name != "syohizeiCol") return;

                // Forced committed
                if (ryosyuListDataGridView.IsCurrentCellDirty)
                {
                    ryosyuListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
        /// 2014/09/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //ADD_HuyTX_20141114_START
                //call back touch panel
                if (_isBackTouchPnl)
                {
                    _isBackTouchPnl = false;
                    //this.Close();
                    Program.tyumonMenuFrm = null;
                    TyumonListForm frm = new TyumonListForm();
                    frm.ShowDialog();
                    this.Close();
                    return;
                }
                else if (null != _ryoshuData) // From some screen with params
                {
                    Program.mForm.MovePrev();
                }
                //ADD_HuyTX_20141114_END
                // 2014/12/17 AnhNV ADD Start
                else // From menu
                {
                    Program.mForm.MovePrev();
                    //this.Close();
                }
                // 2014/12/17 AnhNV ADD End
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
        /// 2014/09/26  AnhNV　　    新規作成
        /// 2014/12/21  小松        単位コンボボックスに空行追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Get comboboxes source
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

            // 発行者(2)
            Utility.Utility.SetComboBoxList(hakkoshaComboBox, alOutput.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", true);
            hakkoshaComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;
            // 支所(3)
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 発行日(5)
            hakkoDtDateTimePicker.Value = _now;

            // From menu
            if (null == _ryoshuData)
            {
                // 初期化処理
                InitialLoad();
            }
            else // From 005-003, 012-002, etc...
            {
                // 発行No(4)
                hakkoNoTextBox.Text = _ryoshuData.HakkoNo;

                // 消費税区分(13)/(14)/(15) radio buttons
                ShouhizeiRdChecked(_ryoshuData.ShouhizeiKbn);
                // 領収書区分(17)/(18)/(19) radio buttons
                RyoshuShoRdChecked(_ryoshuData.RyoshuShoKbn);

                if (!string.IsNullOrEmpty(_ryoshuData.GyoshaCd))
                {
                    // 業者コード(6), 宛名(7), 住所(9), 郵便番号(10), TEL(11), FAX(12)
                    SetGyoshaInfoByGyoshaCd(_ryoshuData.GyoshaCd);
                }

                // Make sure 領収一覧グリッドビュー(20) always contains maximum of 5 rows
                ControlDgvRowNum(_ryoshuData.RyushushoPrintDataTable);
            }

            // 単位コンボボックスに空行追加
            NameMstDataSet.NameMstDataTable cbTaniDT = new NameMstDataSet.NameMstDataTable();
            {
                bool firstFlg = true;
                foreach (NameMstDataSet.NameMstRow addRow in alOutput.NameMstDataTable)
                {
                    NameMstDataSet.NameMstRow newRow = null;
                    if (firstFlg)
                    {
                        // 新しいNull行を生成
                        newRow = cbTaniDT.NewNameMstRow();
                        // コピー
                        newRow.ItemArray = addRow.ItemArray;
                        newRow.NameCd = "000";
                        newRow.Name = " ";
                        cbTaniDT.AddNameMstRow(newRow);
                        firstFlg = false;
                    }
                    // コピー
                    newRow = cbTaniDT.NewNameMstRow();
                    newRow.ItemArray = addRow.ItemArray;
                    // 追加
                    cbTaniDT.AddNameMstRow(newRow);
                }
            }
            // Source for 単位(24)
            foreach (DataGridViewRow dgvr in ryosyuListDataGridView.Rows)
            {
                DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvr.Cells[taniCol.Name];
                // cbCell.DataSource = alOutput.NameMstDataTable;
                cbCell.DataSource = cbTaniDT;
                cbCell.DisplayMember = "Name";
                cbCell.ValueMember = "NameCd";
            }

            // 税率
            _zeiritsu = Common.Common.GetSyohizei(_now.ToString("yyyyMMdd"));

            // 合計算出処理
            GoukeiSanshutsu();
        }
        #endregion

        #region InitialLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitialLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InitialLoad()
        {
            //// 発行者(2)
            //hakkoshaComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;
            //// 支所(3)
            //shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 発行No(4)
            hakkoNoTextBox.Text = string.Empty;
            // 発行日(5)
            //hakkoDtDateTimePicker.Value = _now;
            // 業者コード(6)
            gyosyaCdTextBox.Text = string.Empty;
            // 宛名(7)
            gyosyaNmTextBox.Text = string.Empty;
            // 住所(9)
            adrTextBox.Text = string.Empty;
            // 郵便番号(10)
            zipNoTextBox.Text = string.Empty;
            // TEL(11)
            telTextBox.Text = string.Empty;
            // FAX(12)
            faxTextBox.Text = string.Empty;
            // 消費税区分/なし(15) - ON
            nashiRadioButton.Checked = true;
            // 口座名(16)
            kozaNmTextBox.Text = string.Empty;
            // 領収書区分/現金入金時(17) - ON
            genkinNyukinRadioButton.Checked = true;
            // 補足事項(29)
            hosokuTextBox.Text = string.Empty;
            // 消費税額(30)
            syohizeiTextBox.Text = string.Empty;
            // 合計金額(31)
            totalTextBox.Text = string.Empty;

            // 領収一覧グリッドビュー(20)- 5 blank rows
            ControlDgvRowNum(new YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable()); // 0 rows

            #region Comments
            ////////////////////
            //YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable ryushuTable = alOutput.RyushushoPrintDataTable;

            //// 発行者(2)
            //Utility.Utility.SetComboBoxList(hakkoshaComboBox, alOutput.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", true);
            //hakkoshaComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

            //// 支所(3)
            //Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            //shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            //// 発行No(4)
            ////hakkoNoTextBox.Text = _ryoshuData == null ? string.Empty : (ryushuTable != null && ryushuTable.Count > 0 ? ryushuTable[0].HakkoNo : string.Empty);
            //hakkoNoTextBox.Text = (_ryoshuData != null && !string.IsNullOrEmpty(_ryoshuData.HakkoNo)) ? _ryoshuData.HakkoNo : (ryushuTable != null && ryushuTable.Count > 0 ? ryushuTable[0].HakkoNo : string.Empty);

            //// 発行日(5)
            //hakkoDtDateTimePicker.Value = _now;

            //// 業者コード(6), 宛名(7), 住所(9), 郵便番号(10), TEL(11), FAX(12)
            //string gyoshaCd = _ryoshuData == null ? string.Empty : (ryushuTable != null && ryushuTable.Count > 0 ? ryushuTable[0].GyoshaCd : string.Empty);
            //SetGyoshaInfoByGyoshaCd(gyoshaCd);

            //if (_ryoshuData == null)
            //{
            //    // 消費税区分/なし(15)
            //    nashiRadioButton.Checked = true;
            //}
            //else
            //{
            //    // 消費税区分/外税(14)
            //    sotozeiRadioButton.Checked = true;

            //    //ADD_20141106_HuyTX Start
            //    if (_ryoshuData.RyushushoPrintDT != null)
            //    {
            //        //業者コード(6)
            //        gyosyaCdTextBox.Text = _ryoshuData.GyoshaCd;

            //        // 消費税区分/なし(15)
            //        nashiRadioButton.Checked = true;

            //        //ADD_20141121_ThanhVX Start
            //        if (_ryoshuData.ShouhizeiKbn == "2")
            //        {
            //            uchizeiRadioButton.Checked = true;
            //        }
            //        //ADD_20141121_ThanhVX End
            //    }
            //    //ADD_HuyTX End
            //}

            //// 口座名(16)
            //kozaNmTextBox.Text = string.Empty;

            //if (null == _ryoshuData)
            //{
            //    // 領収書区分/現金入金時(17)
            //    genkinNyukinRadioButton.Checked = true;
            //}
            //else // From 005-003
            //{
            //    // 領収書区分/現金入金時(17)
            //    //genkinNyukinRadioButton.Checked = true;
            //    genkinNyukinRadioButton.Checked = /*string.IsNullOrEmpty(_ryoshuData.ShushushoShubetsu) || */_ryoshuData.ShushushoShubetsu == "1" ? true : false;

            //    //領収書区分/請求売上時 (18)
            //    seikyuUriageRadioButton.Checked = _ryoshuData.ShushushoShubetsu == "2" ? true : false;
            //}

            //// 補足事項(29)
            //hosokuTextBox.Text = string.Empty;

            //// 消費税額(30)
            //syohizeiTextBox.Text = string.Empty;

            //// 合計金額(31)
            //totalTextBox.Text = string.Empty;

            //if (_ryoshuData == null)
            //{
            //    // Adding 5 blank rows to dgv
            //    YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable table = new YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable();
            //    for (int i = 0; i < 5; i++)
            //    {
            //        YoshiHanbaiDtlTblDataSet.RyushushoPrintRow newRow = table.NewRyushushoPrintRow();
            //        table.AddRyushushoPrintRow(newRow);
            //    }

            //    // 領収一覧グリッドビュー
            //    ryosyuListDataGridView.DataSource = table;
            //}
            //else
            //{
            //    // 領収一覧グリッドビュー
            //    ryosyuListDataGridView.DataSource = alOutput.RyushushoPrintDataTable;

            //    //set source from KaiinNyukin screen
            //    if (_ryoshuData.RyushushoPrintDT != null && _ryoshuData.RyushushoPrintDT.Count > 0)
            //    {
            //        ryosyuListDataGridView.DataSource = _ryoshuData.RyushushoPrintDT;
            //    }
            //}
            #endregion
        }
        #endregion

        #region GoukeiSanshutsu
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GoukeiSanshutsu
        /// <summary>
        /// 合計算出処理
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29  AnhNV　　    新規作成
        /// 2014/12/19  kiyokuni　　 空白行があると合計の計算をしていなかったので修正
        /// 2014/12/21  小松         小数以下切り捨て
        /// 2014/12/21  小松         金額のみでも計算可能に修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GoukeiSanshutsu()
        {

            // Total of 金額(27)
            decimal kingakuTotal = 0;
            // Total of 金額(27) which 消費税(25) is ON
            decimal kingakuSyohizei = 0;

            //// Loop dgv
            //foreach (DataGridViewRow dgvr in ryosyuListDataGridView.Rows)
            //{
            //    // Stop handling when 数量(23) or 単価(26) is null
            //    if (dgvr.Cells[suryoCol.Name].Value == null || dgvr.Cells[suryoCol.Name].Value.ToString() == string.Empty
            //        || dgvr.Cells[tankaCol.Name].Value == null || dgvr.Cells[tankaCol.Name].Value.ToString() == string.Empty)
            //    {
            //        //return;
            //        break;
            //    }

            //    // 金額(27) = 数量(23) x 単価(26)
            //    decimal kingaku = Convert.ToDecimal(dgvr.Cells[suryoCol.Name].Value) * Convert.ToDecimal(dgvr.Cells[tankaCol.Name].Value);
            //    dgvr.Cells[kingakuCol.Name].Value = kingaku;

            //    // Total of 金額(27)
            //    kingakuTotal += kingaku;

            //    // Total of 金額(27) which 消費税(25) is ON
            //    kingakuSyohizei += (dgvr.Cells[syohizeiCol.Name].Value.ToString() == "1") ? kingaku : 0;
            //}
            // Loop dgv
            foreach (DataGridViewRow dgvr in ryosyuListDataGridView.Rows)
            {
                decimal suryo = 0;
                if (dgvr.Cells[suryoCol.Name].Value != null)
                {
                    Decimal.TryParse(dgvr.Cells[suryoCol.Name].Value.ToString(), out suryo);
                }
                decimal tanka = 0;
                if (dgvr.Cells[tankaCol.Name].Value != null)
                {
                    Decimal.TryParse(dgvr.Cells[tankaCol.Name].Value.ToString(), out tanka);
                }
                decimal kingaku = 0;
                if (suryo != 0 && tanka != 0)
                {
                    // 数量と単価が両方入ってれば金額を計算（税抜）
                    kingaku = Convert.ToDecimal(dgvr.Cells[suryoCol.Name].Value) * Convert.ToDecimal(dgvr.Cells[tankaCol.Name].Value);
                    dgvr.Cells[kingakuCol.Name].Value = kingaku;
                }
                //else if (dgvr.Cells[kingakuCol.Name].Value != null && !string.IsNullOrEmpty(dgvr.Cells[kingakuCol.Name].Value.ToString()))
                //{
                //    // 金額に入力されていれば金額をそのまま使用
                //    kingaku = Convert.ToDecimal(dgvr.Cells[kingakuCol.Name].Value);
                //}
                else if (dgvr.Cells[HanbaiGakuCol.Name].Value != null && !string.IsNullOrEmpty(dgvr.Cells[HanbaiGakuCol.Name].Value.ToString()))
                {
                    // 販売額（税抜）をセット
                    kingaku = Convert.ToDecimal(dgvr.Cells[HanbaiGakuCol.Name].Value);
                    dgvr.Cells[kingakuCol.Name].Value = kingaku;
                }
                else
                {
                    // 次の行
                    continue;
                }

                // Total of 金額(27)
                kingakuTotal += kingaku;

                // Total of 金額(27) which 消費税(25) is ON
                kingakuSyohizei += (dgvr.Cells[syohizeiCol.Name].Value.ToString() == "1") ? kingaku : 0;
            }

            // 消費税区分/内税(13) is ON
            if (uchizeiRadioButton.Checked)
            {
                // 消費税額(30)
                //syohizeiTextBox.Text = (kingakuSyohizei * (_zeiritsu * 100) / (100 + (_zeiritsu * 100))).ToString("N0");
                // 切り捨て
                syohizeiTextBox.Text = Math.Floor(kingakuSyohizei * (_zeiritsu * 100) / (100 + (_zeiritsu * 100))).ToString("N0");

                // 合計金額(31)
                totalTextBox.Text = kingakuTotal.ToString("N0");
            }

            // 消費税区分/外税(14) is ON
            else if (sotozeiRadioButton.Checked)
            {
                // 消費税額(30)
                //syohizeiTextBox.Text = (kingakuSyohizei * _zeiritsu).ToString("N0");
                // 切り捨て
                syohizeiTextBox.Text = Math.Floor(kingakuSyohizei * _zeiritsu).ToString("N0");

                // 合計金額(31)
                //totalTextBox.Text = (kingakuTotal + (kingakuSyohizei * _zeiritsu)).ToString("N0");
                // 切り捨て
                totalTextBox.Text = (kingakuTotal + Math.Floor(kingakuSyohizei * _zeiritsu)).ToString("N0");
            }

            // 消費税区分/なし(15) is ON
            else if (nashiRadioButton.Checked)
            {
                // 消費税額(30)
                syohizeiTextBox.Text = "0";
                // 合計金額(31)
                totalTextBox.Text = kingakuTotal.ToString("N0");
            }
        }
        #endregion

        #region SetGyoshaInfoByGyoshaCd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetGyoshaInfoByGyoshaCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetGyoshaInfoByGyoshaCd(string gyoshaCd)
        {
            IGyoshaCdTextBoxLeaveALInput alInput = new GyoshaCdTextBoxLeaveALInput();
            alInput.GyoshaCd = gyoshaCd;
            IGyoshaCdTextBoxLeaveALOutput alOutput = new GyoshaCdTextBoxLeaveApplicationLogic().Execute(alInput);

            if (alOutput.GyoshaMstDataTable.Rows.Count > 0)
            {
                // 業者コード(6)
                gyosyaCdTextBox.Text = gyoshaCd;
                // 宛名(7)
                gyosyaNmTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaNm;
                // 住所(9)
                adrTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaAdr;
                // 郵便番号(10)
                zipNoTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaZipCd;
                // TEL(11)
                telTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaTelNo;
                // FAX(12)
                faxTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaFaxNo;
            }
            else // GyoshaCd does not match
            {
                // 業者コード(6)
                gyosyaCdTextBox.Text = string.Empty;
                // 宛名(7)
                gyosyaNmTextBox.Text = string.Empty;
                // 住所(9)
                adrTextBox.Text = string.Empty;
                // 郵便番号(10)
                zipNoTextBox.Text = string.Empty;
                // TEL(11)
                telTextBox.Text = string.Empty;
                // FAX(12)
                faxTextBox.Text = string.Empty;
            }
        }
        #endregion

        #region ryosyuListDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ryosyuListDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyuListDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (ryosyuListDataGridView.Columns[ryosyuListDataGridView.CurrentCell.ColumnIndex].Name)
            {
                case "suryoCol": // 数量(23)
                case "tankaCol": // 単価(26)
                case "kingakuCol": // 金額(27)
                    e.Handled = !IsOKForDecimalTextBox(e.KeyChar, sender as TextBox) ? true : false;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region IsOKForDecimalTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsOKForDecimalTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="textBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsOKForDecimalTextBox(char character, TextBox textBox)
        {
            if (!char.IsControl(character)
                && !char.IsDigit(character))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region MakeRyosyuPrintData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeRyosyuPrintData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeRyosyuPrintData(IRyosyuPrintBtnClickALInput input)
        {
            // 郵便番号
            input.SyusyuShoData.ZipNo = zipNoTextBox.Text;

            // 住所
            input.SyusyuShoData.Adr = adrTextBox.Text;

            // TEL
            input.SyusyuShoData.Tel = telTextBox.Text;

            // FAX
            input.SyusyuShoData.Fax = faxTextBox.Text;

            // 宛名
            input.SyusyuShoData.GyoshaNm = gyosyaNmTextBox.Text;

            // 支所コード
            input.SyusyuShoData.ShishoCd = shisyoComboBox.SelectedValue != null ? shisyoComboBox.SelectedValue.ToString() : string.Empty;

            // 業者コード
            input.SyusyuShoData.GyoshaCd = gyosyaCdTextBox.Text;

            // 発行No
            input.SyusyuShoData.HakkoNo = hakkoNoTextBox.Text;

            // 発行日
            input.SyusyuShoData.HakkoDt = hakkoDtDateTimePicker.Value.ToString("yyyy/MM/dd");

            // 職員名
            input.SyusyuShoData.ShokuinNm = hakkoshaComboBox.GetItemText(hakkoshaComboBox.SelectedItem);

            // 口座名
            input.SyusyuShoData.KozaNm = kozaNmTextBox.Text;

            // 1: Pattern 1
            // 2: Pattern 2
            // 3: Pattern 3
            input.SyusyuShoData.PatternNo = genkinNyukinRadioButton.Checked ? "1" : (seikyuUriageRadioButton.Checked ? "2" : "3");

            // 1: 消費税区分/内税(13)
            // 2: 消費税区分/外税(14)
            // 3: 消費税区分/なし(15)
            input.SyusyuShoData.ShohizeiKbn = uchizeiRadioButton.Checked ? "1" : (sotozeiRadioButton.Checked ? "2" : "3");

            // 補足事項(29)
            input.SyusyuShoData.Hoshoku = hosokuTextBox.Text;

            // 消費税額(30)
            input.SyusyuShoData.Shohizei = !string.IsNullOrEmpty(syohizeiTextBox.Text) ? Convert.ToDecimal(syohizeiTextBox.Text) : 0;

            // 合計金額(31)
            input.SyusyuShoData.Total = !string.IsNullOrEmpty(totalTextBox.Text) ? Convert.ToDecimal(totalTextBox.Text) : 0;

            // Get RyushushoPrintDataTable
            foreach (DataGridViewRow dgvr in ryosyuListDataGridView.Rows)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvr.Cells[taniCol.Name];
                dgvr.Cells[TaniNm.Name].Value = cb.FormattedValue;
            }
            input.SyusyuShoData.PrintTable = (YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable)ryosyuListDataGridView.DataSource;
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
        /// 2014/11/14　AnhNV　　    新規作成
        /// 2014/12/21  小松        制限桁数以上入力できる件の対応
        ///                         印字すると全て収まらない項目の対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // Textboxes
            hakkoNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 10);
            gyosyaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4);
            gyosyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            //adrTextBox.SetStdControlDomain(ZControlDomain.ZT_ADR);
            //zipNoTextBox.SetStdControlDomain(ZControlDomain.ZT_ZIP_CD);
            //telTextBox.SetStdControlDomain(ZControlDomain.ZT_TEL_NO);
            //faxTextBox.SetStdControlDomain(ZControlDomain.ZT_TEL_NO);
            adrTextBox.SetControlDomain(ZControlDomain.ZT_ADR);
            zipNoTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            telTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);
            faxTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            kozaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            //hosokuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            hosokuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
            syohizeiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            totalTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            // Gridview
            ryosyuListDataGridView.SetStdControlDomain(hinbanCol.Index, ZControlDomain.ZG_STD_CD, 10);
            //ryosyuListDataGridView.SetStdControlDomain(hinNmCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            ryosyuListDataGridView.SetStdControlDomain(hinNmCol.Index, ZControlDomain.ZG_STD_NAME, 25);
            ryosyuListDataGridView.SetStdControlDomain(suryoCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            ryosyuListDataGridView.SetStdControlDomain(tankaCol.Index, ZControlDomain.ZG_STD_NUM, 8);
            ryosyuListDataGridView.SetStdControlDomain(kingakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            //ryosyuListDataGridView.SetStdControlDomain(bikoCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            ryosyuListDataGridView.SetStdControlDomain(bikoCol.Index, ZControlDomain.ZG_STD_NAME, 10);
        }
        #endregion

        #region ShouhizeiRdChecked
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShouhizeiRdChecked
        /// <summary>
        /// Default checked for (13), (14), (15)
        /// </summary>
        /// <param name="shouhizeiKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShouhizeiRdChecked(ShouhizeiKbn shouhizeiKbn)
        {
            // 消費税区分/内税(13)
            if (shouhizeiKbn == ShouhizeiKbn.Uchizei)
            {
                uchizeiRadioButton.Checked = true;
            }

            // 消費税区分/外税(14)
            if (shouhizeiKbn == ShouhizeiKbn.Sotozei)
            {
                sotozeiRadioButton.Checked = true;
            }

            // 消費税区分/なし(15)
            if (shouhizeiKbn == ShouhizeiKbn.Nashi)
            {
                nashiRadioButton.Checked = true;
            }
        }
        #endregion

        #region RyoshuShoRdChecked
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RyoshuShoRdChecked
        /// <summary>
        /// Default checked for (17), (18), (19)
        /// </summary>
        /// <param name="ryoshuShoKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RyoshuShoRdChecked(RyoshuShoKbn ryoshuShoKbn)
        {
            // 領収書区分/現金入金時(17)
            if (ryoshuShoKbn == RyoshuShoKbn.GenkinNyukin)
            {
                genkinNyukinRadioButton.Checked = true;
            }

            // 領収書区分/請求売上時(18)
            if (ryoshuShoKbn == RyoshuShoKbn.SeikyuUriage)
            {
                seikyuUriageRadioButton.Checked = true;
            }

            // 領収書区分/請求入金時(19)
            if (ryoshuShoKbn == RyoshuShoKbn.SeikyuNyukin)
            {
                seikyuNyukinRadioButton.Checked = true;
            }
        }
        #endregion

        #region ControlDgvRowNum
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ControlDgvRowNum
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvSource"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlDgvRowNum(YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable dgvSource)
        {
            int rowNum = dgvSource.Rows.Count;

            // 5 rows is OK, no handle
            if (rowNum == 5)
            {
            }
            else if (rowNum < 5) // less than 5 rows
            {
                for (int i = 1; i <= 5 - rowNum; i++)
                {
                    YoshiHanbaiDtlTblDataSet.RyushushoPrintRow newRow = dgvSource.NewRyushushoPrintRow();
                    dgvSource.AddRyushushoPrintRow(newRow);
                }
            }
            else // greater than 5 rows, can use "SELECT TOP 5" query instead.
            {
                // Logic unreachable code when using sql query to limit
                for (int i = 1; i <= rowNum - 5; i++)
                {
                    dgvSource.Rows.RemoveAt(rowNum - i);
                }
            }

            // Bind new source to dgv
            ryosyuListDataGridView.DataSource = null;
            ryosyuListDataGridView.Rows.Clear();
            ryosyuListDataGridView.DataSource = dgvSource;
        }
        #endregion

        #endregion
    }
    #endregion
}
